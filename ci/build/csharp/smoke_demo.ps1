# Validate actual WinForms ZIPs without depending on a machine-level .NET install.
[CmdletBinding()]
param([string]$Packages = 'csharp-release')
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
Add-Type -AssemblyName System.IO.Compression.FileSystem
$output = Join-Path (Get-Location) 'csharp-startup-check'
New-Item -ItemType Directory -Path $output -ErrorAction Stop | Out-Null
$results = @()
$environmentNames = @('DOTNET_ROOT', 'DOTNET_ROOT_X86', 'DOTNET_ROOT_X64', 'DOTNET_MULTILEVEL_LOOKUP', 'AGORA_DEMO_STARTUP_REPORT')
$saved = @{}
foreach ($name in $environmentNames) { $saved[$name] = [Environment]::GetEnvironmentVariable($name, 'Process') }
try {
    foreach ($name in @('DOTNET_ROOT', 'DOTNET_ROOT_X86', 'DOTNET_ROOT_X64')) {
        [Environment]::SetEnvironmentVariable($name, (Join-Path $output 'no-shared-runtime'), 'Process')
    }
    $env:DOTNET_MULTILEVEL_LOOKUP = '0'
    foreach ($arch in @('x86', 'x64')) {
        $zips = @(Get-ChildItem $Packages -Filter "*APIExample*_$arch.zip" -File)
        if ($zips.Count -ne 1) { throw "Expected one $arch Demo ZIP" }
        $directory = Join-Path $output $arch
        [IO.Compression.ZipFile]::ExtractToDirectory($zips[0].FullName, $directory)
        $uiReport = Join-Path $output "$arch.business-ui.json"
        $uiProcess = Start-Process (Join-Path $directory 'C_Sharp-API_Example.exe') -WorkingDirectory $directory -PassThru `
            -ArgumentList "--business-api-ui-check `"$uiReport`"" `
            -RedirectStandardOutput (Join-Path $output "$arch.business-ui.stdout.log") -RedirectStandardError (Join-Path $output "$arch.business-ui.stderr.log")
        $null = $uiProcess.Handle
        if (-not $uiProcess.WaitForExit(60000)) {
            Stop-Process -Id $uiProcess.Id -Force
            throw "Demo $arch business API UI check timed out"
        }
        if ($uiProcess.ExitCode -ne 0 -or -not (Test-Path $uiReport)) { throw "Demo $arch business API UI check failed" }
        $ui = Get-Content $uiReport -Raw -Encoding UTF8 | ConvertFrom-Json
        if (-not $ui.passed -or $ui.overloads -lt 100 -or $ui.scene_count -ne 6 -or $ui.standalone_popup -or $ui.generic_argument_editor -or $ui.architecture -ine $arch) {
            throw "Demo $arch business API UI evidence is invalid"
        }
        $env:AGORA_DEMO_STARTUP_REPORT = Join-Path $output "$arch.startup.json"
        $process = $null
        try {
            $process = Start-Process (Join-Path $directory 'C_Sharp-API_Example.exe') -WorkingDirectory $directory -PassThru `
                -RedirectStandardOutput (Join-Path $output "$arch.stdout.log") -RedirectStandardError (Join-Path $output "$arch.stderr.log")
            if ($process.WaitForExit(10000)) { throw "Demo $arch exited during startup: $($process.ExitCode)" }
            if (-not (Test-Path $env:AGORA_DEMO_STARTUP_REPORT)) { throw "Demo $arch did not report its shown main window" }
            $report = Get-Content $env:AGORA_DEMO_STARTUP_REPORT -Raw -Encoding UTF8 | ConvertFrom-Json
            if ($report.process_id -ne $process.Id -or $report.architecture -ine $arch -or
                $report.window_handle -eq 0 -or -not $report.visible -or -not $report.window_title) {
                throw "Demo $arch main window evidence is invalid"
            }
            if ($report.runtime -notlike '.NET 10.*' -or -not $report.runtime_directory.StartsWith($directory + '\', [StringComparison]::OrdinalIgnoreCase)) {
                throw "Demo $arch did not load its bundled .NET 10 runtime"
            }
            $results += @{ architecture = $arch; passed = $true; window_title = $report.window_title; runtime = $report.runtime_directory }
            Write-Host "Demo $arch shown main window and bundled .NET 10 runtime verified"
        } finally {
            if ($process -and -not $process.HasExited) { Stop-Process -Id $process.Id -Force }
            if (Test-Path $directory) { Remove-Item $directory -Recurse -Force }
        }
    }
} finally {
    foreach ($name in $environmentNames) { [Environment]::SetEnvironmentVariable($name, $saved[$name], 'Process') }
    @{ results = $results; passed = ($results.Count -eq 2) } | ConvertTo-Json -Depth 4 | Set-Content (Join-Path $output 'result.json') -Encoding UTF8
}
