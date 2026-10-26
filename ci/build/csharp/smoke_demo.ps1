# Validate final signed WinForms ZIPs without depending on a machine-level .NET install.
[CmdletBinding()]
param([string]$Packages = 'csharp-release')
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
Add-Type -AssemblyName System.IO.Compression.FileSystem
$output = Join-Path (Get-Location) 'csharp-startup-check'
New-Item -ItemType Directory -Path $output -ErrorAction Stop | Out-Null
$results = @()
$environmentNames = @('DOTNET_ROOT', 'DOTNET_ROOT_X86', 'DOTNET_ROOT_X64', 'DOTNET_MULTILEVEL_LOOKUP')
$saved = @{}
foreach ($name in $environmentNames) { $saved[$name] = [Environment]::GetEnvironmentVariable($name, 'Process') }
try {
    foreach ($name in @('DOTNET_ROOT', 'DOTNET_ROOT_X86', 'DOTNET_ROOT_X64')) {
        [Environment]::SetEnvironmentVariable($name, (Join-Path $output 'no-shared-runtime'), 'Process')
    }
    $env:DOTNET_MULTILEVEL_LOOKUP = '0'
    foreach ($arch in @('x86', 'x64')) {
        $zips = @(Get-ChildItem $Packages -Filter "*APIExample*_$arch.zip" -File)
        if ($zips.Count -ne 1) { throw "Expected one final $arch Demo ZIP" }
        $directory = Join-Path $output $arch
        [IO.Compression.ZipFile]::ExtractToDirectory($zips[0].FullName, $directory)
        $process = $null
        try {
            $process = Start-Process (Join-Path $directory 'C_Sharp-API_Example.exe') -WorkingDirectory $directory -PassThru `
                -RedirectStandardOutput (Join-Path $output "$arch.stdout.log") -RedirectStandardError (Join-Path $output "$arch.stderr.log")
            if ($process.WaitForExit(10000)) { throw "Demo $arch exited during startup: $($process.ExitCode)" }
            $process.Refresh()
            if ($process.MainWindowHandle -eq [IntPtr]::Zero) { throw "Demo $arch did not create its main window" }
            $runtime = @($process.Modules | Where-Object { $_.ModuleName -ieq 'coreclr.dll' })
            if ($runtime.Count -ne 1 -or -not $runtime[0].FileName.StartsWith($directory + '\', [StringComparison]::OrdinalIgnoreCase)) {
                throw "Demo $arch did not load its bundled CLR"
            }
            $results += @{ architecture = $arch; passed = $true; window_title = $process.MainWindowTitle; runtime = $runtime[0].FileName }
        } finally {
            if ($process -and -not $process.HasExited) { Stop-Process -Id $process.Id -Force }
            if (Test-Path $directory) { Remove-Item $directory -Recurse -Force }
        }
    }
} finally {
    foreach ($name in $environmentNames) { [Environment]::SetEnvironmentVariable($name, $saved[$name], 'Process') }
    @{ results = $results; passed = ($results.Count -eq 2) } | ConvertTo-Json -Depth 4 | Set-Content (Join-Path $output 'result.json') -Encoding UTF8
}
