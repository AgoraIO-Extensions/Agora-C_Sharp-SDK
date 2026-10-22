# Standalone C# Windows RTC packaging (EP-916)

This is the .NET SDK and WinForms APIExample path for `release/4.5`. Unity continues to use its existing scripts and defaults. Generated SDK code is not modified.

## Existing Jenkins Job

Use `Unity_SDK_Build/build_mac` with `SDK_TARGET=CSharp`. Missing, empty or `Unity` targets retain the existing `mac && unity` pipeline. CSharp uses the shared Windows node selector and a build-number-specific workspace; it does not check out Unity Quickstart. The workspace is cleaned after archiving, including failures.

Before enabling C# callers, add this **custom parameter to the Unity_SDK_Build project metadata** (build params, available to mac), preserving every existing field:

```json
{"paramName":"SDK_TARGET","paramType":"choice","defaultValue":"Unity,CSharp","description":"Unity or standalone C# Windows SDK","platforms":"mac"}
```

Also ensure the current Jenkins Job parameter definitions contain the same selector. The shared library rebuilds definitions from project metadata; changing only the Jenkins form is insufficient. Do not replace the Job definition or existing Unity parameters. This code intentionally does not update shared library or project metadata at runtime.

C# parameters:

| Parameter | Meaning |
|---|---|
| SDK_TARGET | Explicitly `CSharp` |
| agora_c_sharp_sdk_branch | The SDK branch used by the existing SCM definition; initially `release/4.5` |
| SDK_VERSION | Concrete `4.5.x[.x][-suffix]` candidate version |
| IRIS_WIN_URL / NATIVE_WIN_URL | Optional explicit overrides; otherwise use the selected branch's `ci/build/url_config.txt` video section (audio when TYPE=VOICE) |
| Package_Publish | True uploads internal ZIPs to `CSharp_SDK_Build/<version>/<build>/windows`; false only archives Jenkins artifacts. Neither mode pushes NuGet, publishes CDN, or sends a webhook. |

The Windows agent needs .NET SDK 8, PowerShell 5.1+ and Git. It restores .NET Framework reference assemblies and .NET Core 3.1 Windows targeting/host packages through NuGet. The example retains its existing runtime requirement; upgrading that framework is a separate compatibility change. Set explicit Windows native URLs when branch defaults are not the intended version/product.

## Local / CI verification

```powershell
./ci/build/csharp/build.ps1 -Version 4.5.3.6-dev.1 -IrisUrl <iris-windows-standalone-zip> -NativeUrl <native-windows-zip>
python ci/build/csharp/verify_package.py csharp-output
```

The script creates `net40` and `netstandard2.0` managed libraries, a candidate `agora_rtc_sdk` NuGet package containing x86/x64 native libraries, two Windows RID-specific Demo ZIPs and a raw SDK ZIP. Demo restore uses an isolated cache and the candidate package, not public 4.2.0.1. Consumers of the .NET Framework package must explicitly select x86 or x64. Each output has a SHA256 in `manifest.json`, together with source commit/dirty state and dependency URLs. Windows DLLs/hosts can be cross-compiled and inspected on macOS; this is not Windows runtime/call acceptance.

The new PR workflow runs these checks on a Windows runner. `test_dispatch.groovy` executes the real Jenkins dispatcher against stubs, checking Unity default/explicit/empty behavior, C# workspace isolation, internal upload and invalid-target rejection. It does not claim a Unity Editor regression run.

## Rehoboam

Use the companion EP-916 change in TOOL/rehoboam. It registers the independent `csharp` framework and emits Connection-ready Pipeline/template configurations. C# and Unity share `terra/release/4.5`; C# tags default to `csharp-v<version>`. The Demo lives in this repository, so it has no Unity Quickstart tag step.

Merge/deploy the framework support and merge the SDK change before enabling live C# execution. Start with `Package_Publish=false` on the actual Windows agent, then inspect the candidate packages and perform Windows runtime smoke testing before a business release. CDN remains an explicitly approved existing release task. NuGet push remains a separate release operation with credentials held outside normal template parameters.
