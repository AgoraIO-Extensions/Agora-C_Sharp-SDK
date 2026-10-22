# Verify downloaded CodeSign outputs on Windows, including the nested NuGet payload.
[CmdletBinding()]
param([string]$UrlsFile = 'csharp-signing-urls.json')
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
Add-Type -AssemblyName System.IO.Compression.FileSystem
$output = Join-Path (Get-Location) 'csharp-signed'
$release = Join-Path (Get-Location) 'csharp-release'
$extracted = Join-Path (Get-Location) 'csharp-verification'
if (Test-Path $output) { throw 'Use a clean signing verification directory' }
New-Item -ItemType Directory -Path $output | Out-Null
$records = @()
$errors = @()
$packages = @()
try {
    $urls = @(Get-Content -LiteralPath $UrlsFile -Raw | ConvertFrom-Json)
    if ($urls.Count -ne 3) { throw "Expected three signed SDK/Demo ZIPs, got $($urls.Count)" }
    foreach ($url in $urls) {
        $uri = [Uri]$url
        if ($uri.Scheme -ne 'https' -or $uri.UserInfo -or $uri.Host -notmatch '^artifactory(?:-api\.bj2)?\.agoralab\.co$') {
            throw 'Signed package must use the internal HTTPS Artifactory host'
        }
        $name = [IO.Path]::GetFileName($uri.AbsolutePath)
        if ($name -notmatch '^Agora_CSharp_[A-Za-z0-9_.-]+\.zip$') { throw 'Unexpected signed package name' }
        $zip = Join-Path $output $name
        $headers = @{}
        if ($env:JFROG_TOKEN) { $headers['X-JFrog-Art-Api'] = $env:JFROG_TOKEN }
        Invoke-WebRequest -Uri $uri -Headers $headers -OutFile $zip -UseBasicParsing -TimeoutSec 600
        $packages += @{ name = $name; url = $url; sha256 = (Get-FileHash $zip -Algorithm SHA256).Hash.ToLowerInvariant() }
    }
    & py -3 (Join-Path $PSScriptRoot 'finalize_signed.py') $output $release 'csharp-output/manifest.json'
    if ($LASTEXITCODE -ne 0) { throw 'Signed package finalization failed' }
    & py -3 (Join-Path $PSScriptRoot 'verify_package.py') $release
    if ($LASTEXITCODE -ne 0) { throw 'Final signed package consistency verification failed' }
    foreach ($zip in @(Get-ChildItem $release -File -Filter '*.zip')) {
        $directory = Join-Path $extracted $zip.BaseName
        [IO.Compression.ZipFile]::ExtractToDirectory($zip.FullName, $directory)
        foreach ($nuget in @(Get-ChildItem $directory -Filter '*.nupkg' -Recurse -File)) {
            [IO.Compression.ZipFile]::ExtractToDirectory($nuget.FullName, ($nuget.FullName + '.contents'))
        }
        foreach ($binary in @(Get-ChildItem $directory -Recurse -File | Where-Object { $_.Extension -in @('.dll', '.exe') })) {
            $signature = Get-AuthenticodeSignature -LiteralPath $binary.FullName
            $relative = $binary.FullName.Substring($extracted.Length + 1).Replace('\', '/')
            $records += @{ path = $relative; status = $signature.Status.ToString();
                signer = $(if ($signature.SignerCertificate) { $signature.SignerCertificate.Subject } else { $null });
                thumbprint = $(if ($signature.SignerCertificate) { $signature.SignerCertificate.Thumbprint } else { $null });
                timestamp_signer = $(if ($signature.TimeStamperCertificate) { $signature.TimeStamperCertificate.Subject } else { $null });
                sha256 = (Get-FileHash $binary.FullName -Algorithm SHA256).Hash.ToLowerInvariant() }
            if ($signature.Status -ne 'Valid') { $errors += "$relative : $($signature.Status)" }
        }
    }
    $sdk = @(Get-ChildItem $extracted -Directory -Filter 'Agora_CSharp_RTC_SDK_*')
    if ($sdk.Count -ne 1) { throw 'Expected one signed SDK directory' }
    $nugets = @(Get-ChildItem $sdk[0].FullName -Recurse -File -Filter '*.nupkg')
    if ($nugets.Count -ne 1) { throw 'Expected one nested candidate NuGet package' }
    $nugetRoot = $nugets[0].FullName + '.contents'
    foreach ($tfm in @('net40', 'netstandard2.0')) {
        if (-not (Test-Path (Join-Path $nugetRoot "lib/$tfm/agorartc.dll"))) { throw "Missing managed target $tfm" }
    }
    foreach ($arch in @('x86', 'x64')) {
        $demos = @(Get-ChildItem $extracted -Directory -Filter "Agora_CSharp_APIExample_*_$arch")
        if ($demos.Count -ne 1) { throw "Missing signed $arch Demo" }
        foreach ($name in @('agorartc.dll', 'agora_rtc_sdk.dll', 'AgoraRtcWrapper.dll')) {
            $packageFile = if ($name -eq 'agorartc.dll') { "lib/netstandard2.0/$name" } else { "runtimes/win-$arch/native/$name" }
            $demoHash = (Get-FileHash (Join-Path $demos[0].FullName $name) -Algorithm SHA256).Hash
            $packageHash = (Get-FileHash (Join-Path $nugetRoot $packageFile) -Algorithm SHA256).Hash
            if ($demoHash -ne $packageHash) { $errors += "Signed Demo/NuGet mismatch: $arch/$name" }
        }
        if (-not (Test-Path (Join-Path $demos[0].FullName 'C_Sharp-API_Example.exe'))) { throw "Missing $arch Demo executable" }
    }
    if ($records.Count -eq 0) { throw 'No binaries were inspected' }
} catch {
    $errors += $_.Exception.Message
} finally {
    @{ packages = $packages; binaries = $records; errors = $errors; passed = ($errors.Count -eq 0) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $output 'signature-report.json') -Encoding UTF8
}
Write-Host "Inspected $($records.Count) signed binaries; validation errors: $($errors.Count)"
if ($errors.Count) { throw ($errors -join "`n") }
Write-Host 'Signed SDK, nested NuGet and both Demo signatures/dependency equality verified'
