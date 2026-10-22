# Consume the actual signed alpha.1 through NuGet; no source reference or business call.
[CmdletBinding()]
param()
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'
Set-StrictMode -Version Latest
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
$output = Join-Path (Get-Location) 'csharp-consumer-check'
if (Test-Path $output) { throw 'Use a clean consumer verification workspace' }
New-Item -ItemType Directory -Path $output | Out-Null
$cases = @()
$errors = @()
$version = '4.5.3.6-alpha.1'
$initialize = $env:CONSUMER_REQUIRE_INITIALIZE -eq 'true'
function Run-Dotnet {
    & dotnet @args
    if ($LASTEXITCODE -ne 0) { throw "dotnet $($args[0]) failed ($LASTEXITCODE)" }
}
try {
    if ($initialize -and $env:CONSUMER_APP_ID -notmatch '^[a-fA-F0-9]{32}$') { throw 'Initialization requires a runtime 32-character App ID' }
    $stage = Join-Path $output 'stage'
    New-Item -ItemType Directory -Path $stage | Out-Null
    $installer = Join-Path $stage 'dotnet-install.ps1'
    $sdk = Join-Path $stage 'dotnet-sdk'
    Invoke-WebRequest 'https://builds.dotnet.microsoft.com/dotnet/scripts/v1/dotnet-install.ps1' -OutFile $installer -UseBasicParsing -TimeoutSec 120
    & $installer -Version '8.0.203' -InstallDir $sdk -NoPath
    if (-not (Test-Path (Join-Path $sdk 'dotnet.exe'))) { throw 'Private .NET SDK installation failed' }
    $env:DOTNET_ROOT = $sdk
    $env:PATH = "$sdk;$env:PATH"
    $env:MSBUILDDISABLENODEREUSE = '1'
    $env:DOTNET_CLI_USE_MSBUILD_SERVER = '0'
    $env:DOTNET_CLI_TELEMETRY_OPTOUT = '1'
    $cache = Join-Path $stage 'cache'
    $env:NUGET_PACKAGES = $cache
    $bundle = Join-Path $stage 'sdk.zip'
    $url = 'https://artifactory-api.bj2.agoralab.co/artifactory/CSDC_repo/CSharp_SDK_Build/4.5.3.6-alpha.1/662/windows/Agora_CSharp_RTC_SDK_4.5.3.6-alpha.1_Release.zip'
    Write-Host 'Downloading the final signed SDK from build #662'
    Invoke-WebRequest $url -Headers @{'X-JFrog-Art-Api' = $env:JFROG_TOKEN} -OutFile $bundle -UseBasicParsing -TimeoutSec 600
    if ((Get-FileHash $bundle -Algorithm SHA256).Hash -ne '74b55b6cd3b00a18cee092280c0735382f70397937869d6309a77d1384b0672b') {
        throw 'Published SDK ZIP hash differs from build #662 final manifest'
    }
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $unpacked = Join-Path $stage 'sdk'
    [IO.Compression.ZipFile]::ExtractToDirectory($bundle, $unpacked)
    $package = Join-Path $unpacked "agora_rtc_sdk.$version.nupkg"
    if ((Get-FileHash $package -Algorithm SHA256).Hash -ne '456a81cd75fac60d0ee8e43dee3a12c6c120073ec87d030d596e6fbe5aafd8c0') {
        throw 'Signed NuGet hash differs from build #662 final manifest'
    }
    $payload = Join-Path $stage 'payload'
    [IO.Compression.ZipFile]::ExtractToDirectory($package, $payload)
    $feed = Join-Path $stage 'feed'
    New-Item -ItemType Directory -Path $feed | Out-Null
    Copy-Item $package $feed
    $feedXml = [Security.SecurityElement]::Escape($feed)
    $config = Join-Path $stage 'NuGet.Config'
    @"
<configuration>
  <packageSources><clear /><add key="candidate" value="$feedXml" /><add key="nuget.org" value="https://api.nuget.org/v3/index.json" /></packageSources>
  <packageSourceMapping><packageSource key="candidate"><package pattern="agora_rtc_sdk" /></packageSource><packageSource key="nuget.org"><package pattern="*" /></packageSource></packageSourceMapping>
</configuration>
"@ | Set-Content $config -Encoding UTF8
    foreach ($tfm in @('net40', 'net8.0')) {
        foreach ($arch in @('x86', 'x64')) {
            $name = "$tfm-$arch"
            $case = Join-Path $output $name
            New-Item -ItemType Directory -Path $case | Out-Null
            $record = @{ name = $name; passed = $false; package_version = $version }
            $cases += $record
            try {
                Write-Host "CONSUMER START $name"
                Copy-Item (Join-Path $PSScriptRoot 'Program.cs') $case
                $extraProperties = if ($tfm -eq 'net8.0') {
                    "<RuntimeIdentifier>win-$arch</RuntimeIdentifier><SelfContained>true</SelfContained><RuntimeFrameworkVersion>8.0.3</RuntimeFrameworkVersion>"
                } else { '' }
                $references = if ($tfm -eq 'net40') {
                    '<PackageReference Include="Microsoft.NETFramework.ReferenceAssemblies.net40" Version="1.0.3" PrivateAssets="all" />'
                } else { '' }
                $project = Join-Path $case 'Consumer.csproj'
                @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><OutputType>Exe</OutputType><TargetFramework>$tfm</TargetFramework><PlatformTarget>$arch</PlatformTarget><LangVersion>latest</LangVersion><UseSharedCompilation>false</UseSharedCompilation>$extraProperties</PropertyGroup>
  <ItemGroup><PackageReference Include="agora_rtc_sdk" Version="$version" />$references</ItemGroup>
</Project>
"@ | Set-Content $project -Encoding UTF8
                Run-Dotnet @('restore', $project, '--configfile', $config, '--packages', $cache)
                $assets = Get-Content (Join-Path $case 'obj/project.assets.json') -Raw | ConvertFrom-Json
                $key = "agora_rtc_sdk/$version"
                if (-not $assets.libraries.PSObject.Properties[$key]) { throw 'Candidate NuGet was not restored' }
                $expectedAsset = if ($tfm -eq 'net40') { 'lib/net40/agorartc.dll' } else { 'lib/netstandard2.0/agorartc.dll' }
                $compileAssets = @($assets.targets.PSObject.Properties | ForEach-Object {
                    $dependency = $_.Value.PSObject.Properties[$key]
                    if ($dependency) { $dependency.Value.compile.PSObject.Properties.Name }
                })
                if ($expectedAsset -notin $compileAssets) { throw "Unexpected NuGet compile asset: $compileAssets" }
                $record.compile_asset = $expectedAsset
                $publish = Join-Path $case 'publish'
                $command = if ($tfm -eq 'net40') { 'build' } else { 'publish' }
                Run-Dotnet @($command, $project, '-c', 'Release', '--no-restore', '--disable-build-servers', '-o', $publish)
                $expected = @{ 'agorartc.dll' = (Join-Path $payload $expectedAsset) }
                Get-ChildItem (Join-Path $payload "runtimes/win-$arch/native") -File | ForEach-Object { $expected[$_.Name] = $_.FullName }
                foreach ($item in $expected.GetEnumerator()) {
                    $installed = Join-Path $publish $item.Key
                    if (-not (Test-Path $installed)) { throw "NuGet did not copy $($item.Key)" }
                    if ((Get-FileHash $installed -Algorithm SHA256).Hash -ne (Get-FileHash $item.Value -Algorithm SHA256).Hash) {
                        throw "Installed binary differs from signed NuGet: $($item.Key)"
                    }
                }
                $record.verified_sdk_files = $expected.Count
                $log = Join-Path $case 'run.log'
                $stderr = Join-Path $case 'run-error.log'
                $startInfo = New-Object System.Diagnostics.ProcessStartInfo
                $startInfo.FileName = Join-Path $publish 'Consumer.exe'
                $startInfo.Arguments = "$arch $tfm"
                $startInfo.WorkingDirectory = $publish
                $startInfo.UseShellExecute = $false
                $startInfo.CreateNoWindow = $true
                $startInfo.RedirectStandardOutput = $true
                $startInfo.RedirectStandardError = $true
                $process = New-Object System.Diagnostics.Process
                $process.StartInfo = $startInfo
                if (-not $process.Start()) { throw 'Consumer process did not start' }
                $stdoutTask = $process.StandardOutput.ReadToEndAsync()
                $stderrTask = $process.StandardError.ReadToEndAsync()
                $finished = $process.WaitForExit(60000)
                if (-not $finished) { $process.Kill(); $process.WaitForExit() }
                $text = $stdoutTask.Result
                $errorText = $stderrTask.Result
                if ($env:CONSUMER_APP_ID) {
                    $text = [regex]::Replace($text, [regex]::Escape($env:CONSUMER_APP_ID), '[APP_ID]', [Text.RegularExpressions.RegexOptions]::IgnoreCase)
                    $errorText = [regex]::Replace($errorText, [regex]::Escape($env:CONSUMER_APP_ID), '[APP_ID]', [Text.RegularExpressions.RegexOptions]::IgnoreCase)
                }
                $exitCode = $process.ExitCode
                $process.Dispose()
                $text | Set-Content $log -Encoding UTF8
                $errorText | Set-Content $stderr -Encoding UTF8
                $record.exit_code = $exitCode
                Write-Host $text
                if (-not $finished) { throw 'Consumer exceeded 60 seconds' }
                if ($exitCode -ne 0 -or $text -notmatch 'CONSUMER_PASS') {
                    throw "Consumer runtime failed ($exitCode): $errorText"
                }
                if ($initialize) {
                    $record.initialization_successes = [regex]::Matches($text, 'INITIALIZE_RESULT=0 ATTEMPT=[012]').Count
                    if ($record.initialization_successes -ne 3) { throw 'Expected three successful SDK initializations' }
                }
                $record.runtime_output = $text
                $record.passed = $true
                Write-Host "CONSUMER PASS $name"
            } catch {
                $record.error = $_.Exception.Message
                $errors += "$name : $($_.Exception.Message)"
                Write-Host "CONSUMER FAIL $name : $($_.Exception.Message)"
            }
        }
    }
} catch { $errors += $_.Exception.Message }
finally {
    $scope = if ($initialize) { 'NuGet restore/build/native-load/Initialize/GetVersion/dispose; no channel calls' } else { 'NuGet restore/build/native-load/GetVersion/dispose; no Initialize or channel calls' }
    @{ sdk_version = $version; source_build = 662; cases = $cases; errors = $errors; passed = ($cases.Count -eq 4 -and $errors.Count -eq 0); initialize_requested = $initialize; scope = $scope } |
        ConvertTo-Json -Depth 8 | Set-Content (Join-Path $output 'result.json') -Encoding UTF8
}
if ($errors.Count -or $cases.Count -ne 4) { throw ($errors -join "`n") }
Write-Host 'All four independent NuGet consumers passed'
