# Standalone C# packaging only. Never pushes NuGet, publishes CDN or sends notifications.
[CmdletBinding()]
param(
    [string]$Version = $env:SDK_VERSION,
    [string]$IrisUrl = $env:IRIS_WIN_URL,
    [string]$NativeUrl = $env:NATIVE_WIN_URL,
    [string]$Output = 'csharp-output'
)
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

function Run-Dotnet {
    & dotnet @args
    if ($LASTEXITCODE -ne 0) { throw "dotnet $($args[0]) failed ($LASTEXITCODE)" }
}
function Download-Package([string]$Url, [string]$Name) {
    $uri = [Uri]$Url
    if (-not $uri.IsAbsoluteUri -or $uri.Scheme -ne 'https' -or $uri.UserInfo) {
        throw "$Name requires an HTTPS artifact URL without credentials"
    }
    $headers = @{}
    if ($uri.Host -match '^artifactory(?:-api\.bj2)?\.agoralab\.co$' -and $env:JFROG_TOKEN) {
        $headers['X-JFrog-Art-Api'] = $env:JFROG_TOKEN
    }
    $zip = Join-Path $temp "$Name.zip"
    Invoke-WebRequest -Uri $uri -Headers $headers -OutFile $zip -UseBasicParsing
    $directory = Join-Path $temp $Name
    Expand-Archive -LiteralPath $zip -DestinationPath $directory
    return $directory
}
function Find-OneDirectory([string]$Root, [string]$Pattern) {
    $matches = @(Get-ChildItem -LiteralPath $Root -Directory -Recurse | Where-Object { $_.FullName.Replace('\', '/') -match $Pattern })
    if ($matches.Count -ne 1) { throw "Expected one $Pattern directory, found $($matches.Count)" }
    return $matches[0].FullName
}

if ($Version -notmatch '^4\.5\.\d+(?:\.\d+)?(?:-[0-9A-Za-z]+(?:[.-][0-9A-Za-z]+)*)?$') {
    throw 'SDK_VERSION must be a concrete 4.5 series NuGet version'
}
$root = (Resolve-Path (Join-Path $PSScriptRoot '../../..')).Path
if (-not $IrisUrl -or -not $NativeUrl) {
    $section = if ($env:TYPE -eq 'VOICE') { 'audio' } else { 'video' }
    $config = Get-Content (Join-Path $root 'ci/build/url_config.txt') -Raw
    $block = [regex]::Match($config, "(?s)>>>$section\s*(.*?)<<<end").Groups[1].Value
    if (-not $IrisUrl) { $IrisUrl = [regex]::Match($block, '(?m)^IRIS_WINDOWS=(.+)').Groups[1].Value.Trim() }
    if (-not $NativeUrl) { $NativeUrl = [regex]::Match($block, '(?m)^NATIVE_WINDOWS=(.+)').Groups[1].Value.Trim() }
}
if (-not $IrisUrl -or -not $NativeUrl) { throw 'Both IRIS_WIN_URL and NATIVE_WIN_URL are required (parameters or url_config.txt)' }
$outputPath = [IO.Path]::GetFullPath((Join-Path $root $Output))
# The job gives every build a private workspace. Do not accept cleanup outside it.
if (-not $outputPath.StartsWith($root + [IO.Path]::DirectorySeparatorChar, [StringComparison]::OrdinalIgnoreCase) -or $outputPath -eq $PSScriptRoot) {
    throw 'Output must be a child directory of the private checkout'
}
if (Test-Path $outputPath) { throw 'Output directory already exists; use a clean private workspace' }
New-Item -ItemType Directory -Path $outputPath | Out-Null
$temp = Join-Path $outputPath 'staging'
New-Item -ItemType Directory -Path $temp | Out-Null
try {
    Run-Dotnet @('--info')
    $iris = Download-Package $IrisUrl 'iris'
    $native = Download-Package $NativeUrl 'native'
    $nativeRoot = Join-Path $temp 'native-dlls'
    foreach ($arch in @('x86', 'x64')) {
        $nativeArch = if ($arch -eq 'x64') { 'x86_64' } else { 'x86' }
        $irisArch = if ($arch -eq 'x64') { 'x64' } else { 'Win32' }
        $sdkDir = Find-OneDirectory $native "/sdk/$nativeArch`$"
        $irisDir = Find-OneDirectory $iris "/$irisArch/Release`$"
        $dest = Join-Path $nativeRoot $arch
        New-Item -ItemType Directory -Path $dest | Out-Null
        Get-ChildItem -LiteralPath $sdkDir -File | Where-Object { $_.Extension -in @('.dll', '.exe') } | Copy-Item -Destination $dest
        Copy-Item (Join-Path $irisDir '*.dll') $dest
        foreach ($file in @('agora_rtc_sdk.dll', 'AgoraRtcWrapper.dll')) {
            if (-not (Test-Path (Join-Path $dest $file))) { throw "Missing $arch/$file" }
        }
    }
    $project = Join-Path $PSScriptRoot 'agorartc.csproj'
    $assemblyVersion = ($Version -split '-')[0]
    Run-Dotnet @('pack', $project, '-c', 'Release', '-o', $outputPath,
        "-p:Version=$Version", "-p:AssemblyVersion=$assemblyVersion", "-p:FileVersion=$assemblyVersion", "-p:NativeRoot=$nativeRoot")
    $packages = @(Get-ChildItem $outputPath -Filter '*.nupkg')
    if ($packages.Count -ne 1) { throw 'Expected exactly one candidate NuGet package' }
    $demoSource = Join-Path $root 'Agora-C_Sharp-RTC-SDK-API_Example'
    $demo = Join-Path $temp 'demo'
    Copy-Item $demoSource $demo -Recurse
    $demoProject = Join-Path $demo 'C_Sharp-API_Example.csproj'
    # Read the normalized NuGet version from the actual package, not an old public package.
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $package = [IO.Compression.ZipFile]::OpenRead($packages[0].FullName)
    try {
        $entry = @($package.Entries | Where-Object { $_.FullName -like '*.nuspec' })[0]
        $reader = New-Object IO.StreamReader($entry.Open())
        try { [xml]$spec = $reader.ReadToEnd() } finally { $reader.Dispose() }
        $candidateVersion = $spec.package.metadata.version
    } finally { $package.Dispose() }
    $cache = Join-Path $temp 'nuget-cache'
    foreach ($arch in @('x86', 'x64')) {
        $demoOutput = Join-Path $temp "APIExample-$arch"
        Run-Dotnet @('publish', $demoProject, '-c', 'Release', '-r', "win-$arch", '--self-contained', 'false', "-p:Platform=$arch", "-p:PlatformTarget=$arch",
            "-p:AgoraSdkVersion=$candidateVersion", "-p:RestorePackagesPath=$cache", "-p:EnableWindowsTargeting=true", '--source', $outputPath, '--source', 'https://api.nuget.org/v3/index.json', '-o', $demoOutput)
        foreach ($file in @('agorartc.dll', 'agora_rtc_sdk.dll', 'AgoraRtcWrapper.dll')) {
            if (-not (Test-Path (Join-Path $demoOutput $file))) { throw "Demo $arch missing $file" }
        }
        Compress-Archive -Path "$demoOutput/*" -DestinationPath (Join-Path $outputPath "Agora_CSharp_APIExample_${Version}_${arch}.zip")
    }
    $sdk = Join-Path $temp 'sdk'
    New-Item -ItemType Directory -Path $sdk | Out-Null
    Copy-Item $packages[0].FullName $sdk
    Copy-Item $nativeRoot (Join-Path $sdk 'native') -Recurse
    Copy-Item (Join-Path $PSScriptRoot 'bin/Release') (Join-Path $sdk 'managed') -Recurse
    Compress-Archive -Path "$sdk/*" -DestinationPath (Join-Path $outputPath "Agora_CSharp_RTC_SDK_${Version}_Release.zip")
    $files = @(Get-ChildItem $outputPath -File | ForEach-Object {
        @{ name = $_.Name; sha256 = (Get-FileHash $_.FullName -Algorithm SHA256).Hash.ToLowerInvariant() }
    })
    $commit = (& git -C $root rev-parse HEAD)
    if ($LASTEXITCODE -ne 0) { throw 'Cannot resolve source commit' }
    $dirty = [bool](& git -C $root status --porcelain --untracked-files=normal)
    @{ sdk_version = $Version; source_commit = $commit; source_dirty = $dirty; iris_url = $IrisUrl; native_url = $NativeUrl; files = $files } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $outputPath 'manifest.json') -Encoding UTF8
} finally {
    if (Test-Path $temp) { Remove-Item -LiteralPath $temp -Recurse -Force }
}
