# Standalone C# packaging only. Never pushes NuGet, publishes CDN or sends notifications.
[CmdletBinding()]
param(
    [string]$Version = $env:SDK_VERSION,
    [string]$IrisUrl = $env:IRIS_WIN_URL,
    [string]$NativeUrl = $env:NATIVE_WIN_URL,
    [string]$Output = 'csharp-output'
)
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'
Set-StrictMode -Version Latest
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

function Run-Dotnet {
    & dotnet @args
    if ($LASTEXITCODE -ne 0) { throw "dotnet $($args[0]) failed ($LASTEXITCODE)" }
}
function Ensure-Dotnet {
    # Scope SDK installation and PATH to this build; leave Unity and the agent unchanged.
    if (Get-Command dotnet -ErrorAction SilentlyContinue) {
        & dotnet --version
        if ($LASTEXITCODE -eq 0) { return }
    }
    if ([Environment]::OSVersion.Platform -ne 'Win32NT') {
        throw 'Install .NET SDK 8 before cross-compiling on a non-Windows host'
    }
    $installedDirectory = Join-Path $env:ProgramFiles 'dotnet'
    $installedExecutable = Join-Path $installedDirectory 'dotnet.exe'
    if (Test-Path $installedExecutable) {
        & $installedExecutable --version
        if ($LASTEXITCODE -eq 0) {
            $env:DOTNET_ROOT = $installedDirectory
            $env:PATH = "$installedDirectory;$env:PATH"
            return
        }
    }
    Write-Host 'Preparing private .NET SDK 8.0.203 in this build workspace'
    $installScript = Join-Path $temp 'dotnet-install.ps1'
    $sdkDirectory = Join-Path $temp 'dotnet-sdk'
    Invoke-WebRequest -Uri 'https://builds.dotnet.microsoft.com/dotnet/scripts/v1/dotnet-install.ps1' -OutFile $installScript -UseBasicParsing -TimeoutSec 120
    & $installScript -Version '8.0.203' -InstallDir $sdkDirectory -NoPath
    if (-not (Test-Path (Join-Path $sdkDirectory 'dotnet.exe'))) { throw 'Private .NET SDK installation failed' }
    $env:DOTNET_ROOT = $sdkDirectory
    $env:PATH = "$sdkDirectory;$env:PATH"
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
    Write-Host "Downloading $Name dependency"
    Invoke-WebRequest -Uri $uri -Headers $headers -OutFile $zip -UseBasicParsing
    Write-Host "Downloaded $Name dependency ($((Get-Item $zip).Length) bytes)"
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
    Push-Location $PSScriptRoot
    Ensure-Dotnet
    $env:MSBUILDDISABLENODEREUSE = '1'
    $env:DOTNET_CLI_USE_MSBUILD_SERVER = '0'
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
    Run-Dotnet @('pack', $project, '--disable-build-servers', '-p:UseSharedCompilation=false', '-c', 'Release', '-p:Platform=AnyCPU', '-o', $outputPath,
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
    $nugetConfig = Join-Path $temp 'NuGet.Config'
    $escapedSource = [Security.SecurityElement]::Escape($outputPath)
    @"
<?xml version="1.0" encoding="utf-8"?>
<configuration><packageSources><clear />
  <add key="candidate" value="$escapedSource" />
  <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
</packageSources></configuration>
"@ | Set-Content -LiteralPath $nugetConfig -Encoding UTF8
    foreach ($arch in @('x86', 'x64')) {
        $demoOutput = Join-Path $temp "APIExample-$arch"
        Run-Dotnet @('publish', $demoProject, '--disable-build-servers', '-p:UseSharedCompilation=false', '-c', 'Release', '-r', "win-$arch", '--self-contained', 'false', "-p:Platform=$arch", "-p:PlatformTarget=$arch",
            "-p:AgoraSdkVersion=$candidateVersion", "-p:RestorePackagesPath=$cache", "-p:EnableWindowsTargeting=true", "-p:RestoreConfigFile=$nugetConfig", '-o', $demoOutput)
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
    Pop-Location
    if (Test-Path $temp) { Remove-Item -LiteralPath $temp -Recurse -Force }
}
