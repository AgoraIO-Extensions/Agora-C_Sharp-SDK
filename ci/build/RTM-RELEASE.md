# Unity RTM release automation (EP-936)

The dedicated RTM 2.x maintenance branch is `release/rtm-2.x`, created from
`release/RTM-2.1`. Target RTM dependency/API/release changes here, not `main`.
The existing `release/RTM-2.1` branch remains as historical baseline.

RTM 2.x APIs are intentionally handwritten. Do not run the RTC Terra workflow
or label a dependency PR as generated RTM API coverage.

Historical design and packaging contracts:

- [RTM 2.x code generation](https://confluence.agoralab.co/pages/viewpage.action?pageId=1731626439)
  (2025-04-25): no generator; the small, designed API is handwritten.
- [RTM 2.x release details](https://confluence.agoralab.co/pages/viewpage.action?pageId=1731625484)
  (2025-04-25): SDK lives in Agora-C_Sharp-SDK, examples in Agora-Unity-Quickstart,
  reuse Unity_SDK_Build/build_mac with RTC=false and RTM=true. Historical branch
  examples are not a requirement to use an old branch today.

Dispatch the `rtm.yml` entry from `main`, setting `rtm-branch` to
`release/rtm-2.x` and supplying the release-family result text. The entry checks
out that RTM branch and opens the dependency PR against that same branch.
Only the workflow entry belongs on `main`; implementation scripts stay on RTM.
It parses the existing dependency result format, requires all four Native
and Iris ZIPs, writes `ci/build/rtm_dependencies.json`, compiles a temporary
RTM-only copy using the packaging source selector, then creates a PR. Native
URLs must be RTM; Iris requires Standalone on Android/iOS/Windows and Unity on
Mac. Ambiguous or incomplete results fail before PR creation. API changes need
handwritten binding review; a successful managed compile is not native API or
runtime acceptance.

After review and merge, sync the exact SDK/Quickstart branches to the CI mirror,
then run packaging with RTC=false, RTM=true, SDK_VERSION set to the wrapper
version and the reviewed branches. Pure RTM packaging requires the manifest;
explicit URL overrides must match it. No video/audio RTC fallback is allowed.
Existing RTC packaging keeps its old configuration. Do not mix incomplete
manifests or substitute macOS Standalone ZIPs for Unity bundles.

The compile check targets .NET 8 solely to validate the packaged managed source;
it does not replace Unity Editor/device builds or claim a new supported SDK
framework. SDK and example tags must be reviewed separately: the existing
tag.yml can overwrite remote tags.

Local checks: `python3 -m unittest discover -s ci/build -p test_rtm_dependencies.py`
and `bash ci/build/rtm-compile.sh` (requires .NET 8).
