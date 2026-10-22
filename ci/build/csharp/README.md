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
| SDK_VERSION | Concrete 4.5 series version; prerelease `4.5.3.6-alpha.1`, stable `4.5.3.6` |
| IRIS_WIN_URL / NATIVE_WIN_URL | Optional explicit overrides; otherwise use the selected branch's `ci/build/url_config.txt` video section (audio when TYPE=VOICE) |
| Package_Publish | True uploads internal ZIPs to `CSharp_SDK_Build/<version>/<build>/windows`, waits for CodeSign, then emits release URLs; false only archives unsigned Jenkins candidates. Neither mode pushes NuGet, publishes CDN, or sends a webhook. |

Version naming follows the existing `agora_rtc_sdk` NuGet history (for example `4.2.6.19-alpha.1`): use `<base-version>-alpha.<sequence>` for prereleases and `<base-version>` for stable releases. For this 4.5 baseline, start with `4.5.3.6-alpha.1`, increment to `alpha.2` for the next prerelease, and use `4.5.3.6` for stable. Keep issue IDs, Jenkins build numbers and signing attempts in build records/manifest provenance rather than customer release versions. CI uses its run number as the alpha sequence for unpublished validation candidates; select the customer release sequence explicitly through SDK_VERSION. Existing acceptance artifacts retain their original names and hashes.

## Windows CodeSign integration

The C# upload path reuses Iris's existing `CodeSign` Job with `PACKAGE_URLS`, package whitelist `Agora_CSharp_*.zip` and file whitelist `*.dll,*.exe`. It waits for SUCCESS; failed, aborted, unstable or missing signing results stop the pipeline before `package_urls` and release-result output. Unity dispatch is unchanged. No certificate or signing credential is copied into this repository.

CodeSign only extracts the outer ZIP. It does not sign DLLs inside a nested `.nupkg`, and independently signing duplicate DLLs produces different timestamp bytes. Therefore inputs are uploaded under `windows/signing-input`; after CodeSign succeeds, `verify_signed.ps1` downloads all three ZIPs and `finalize_signed.py` repacks the NuGet and Demo dependencies from the canonical signed SDK `managed`/`native` binaries. The Demo's own signed executable and assembly are preserved. The final candidate is verified again for hashes, PE architecture, managed targets, exact Demo/NuGet DLL equality and Windows Authenticode validity of every DLL/EXE, including the nested NuGet. Only then are final ZIPs uploaded under `windows` and release URLs emitted.

`csharp-output` contains pre-signing Jenkins candidates; `csharp-release` contains the final signed ZIPs, the same standalone NuGet payload embedded in the SDK ZIP, and a newly generated manifest for the signed bytes. `csharp-signed/signature-report.json` records source signing URLs and final per-binary signatures, certificate thumbprints, timestamp signers and hashes. This is Authenticode signing of package binaries, not NuGet repository/package signing or NuGet publication. Live acceptance must verify the real CodeSign result and signature report; local packaging/stub tests alone do not establish signing success.

The Windows agent needs PowerShell 5.1+, Git and Python 3 (`py -3`) for package verification. When a compatible .NET SDK is unavailable, the build installs official .NET SDK 8.0.203 into its private staging directory and changes PATH only for the child build process. The installation is removed with the workspace; no machine-wide SDK or environment is changed. A C#-scoped global.json prevents a newer preinstalled SDK from silently taking over; the script uses a temporary NuGet.Config for the local candidate and nuget.org. It restores .NET Framework reference assemblies and .NET Core 3.1 Windows targeting/host packages through NuGet. The example retains its existing runtime requirement; upgrading that framework is a separate compatibility change. Set explicit Windows native URLs when branch defaults are not the intended version/product.

## Local / CI verification

```powershell
./ci/build/csharp/build.ps1 -Version 4.5.3.6-alpha.1 -IrisUrl <iris-windows-standalone-zip> -NativeUrl <native-windows-zip>
python ci/build/csharp/verify_package.py csharp-output
```

The script creates `net40` and `netstandard2.0` managed libraries, a candidate `agora_rtc_sdk` NuGet package containing x86/x64 native libraries, two Windows RID-specific Demo ZIPs and a raw SDK ZIP. Demo restore uses an isolated cache and `AgoraSdkVersion` to select the candidate package, not public 4.2.0.1. Opening the Demo directly without that property references the local standalone SDK project, so its updated 4.5 calls also compile outside CI. Consumers of the .NET Framework package must explicitly select x86 or x64. Each output has a SHA256 in `manifest.json`, together with source commit/dirty state and dependency URLs. Windows DLLs/hosts can be cross-compiled and inspected on macOS; this is not Windows runtime/call acceptance.

The new PR workflow runs these checks on a Windows runner. `test_dispatch.groovy` executes the real Jenkins dispatcher against stubs, checking Unity default/explicit/empty behavior, C# workspace isolation, internal upload and invalid-target rejection. It does not claim a Unity Editor regression run.

## Independent NuGet consumer acceptance

On a clean Windows workspace, run `powershell -NoProfile -ExecutionPolicy Bypass -File ci/build/csharp/consumer/verify.ps1` with the existing Jenkins Artifactory credential injected as `JFROG_TOKEN`. This acceptance script is pinned to the signed alpha.1 package delivered by build #662 and its final SDK/NuGet SHA256 values. It downloads that actual final SDK ZIP, creates a local NuGet feed and isolated package cache, and creates fresh net40/net8.0 projects for x86/x64. There are no SDK source/project references or manual DLL copies into client output directories. Modern .NET clients publish self-contained so no machine-level runtime installation is needed.

The check validates NuGet compile-asset selection, automatic native/managed file copy and exact signed-package bytes, process architecture, managed version, native GetVersion and three create/dispose cycles. It records `csharp-consumer-check/result.json` and per-case project/source/runtime logs. By default it runs without an App ID. To additionally check initialization, inject the test App ID as `CONSUMER_APP_ID` and set `CONSUMER_REQUIRE_INITIALIZE=true`; each client must then complete three Initialize/GetVersion/dispose cycles with Initialize returning zero. The App ID is read at runtime and hidden in archived stdout/stderr; native SDK logs are confined to the private client directory. It never calls JoinChannel or uses a Token, so successful initialization does not imply call/device acceptance. SDK tooling and caches remain in the private workspace for the caller to clean.

## Rehoboam

Use the companion EP-916 change in TOOL/rehoboam. It registers the independent `csharp` framework and emits Connection-ready Pipeline/template configurations. C# and Unity share `terra/release/4.5`; C# tags default to `csharp-v<version>`. The Demo lives in this repository, so it has no Unity Quickstart tag step.

Merge/deploy the framework support and merge the SDK change before enabling live C# execution. Start with `Package_Publish=false` on the actual Windows agent, then inspect the candidate packages and perform Windows runtime smoke testing before a business release. CDN remains an explicitly approved existing release task. NuGet push remains a separate release operation with credentials held outside normal template parameters.
