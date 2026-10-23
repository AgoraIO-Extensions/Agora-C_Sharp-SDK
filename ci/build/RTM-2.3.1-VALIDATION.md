# Unity RTM 2.3.1 candidate (EP-936)

The RTM maintenance branch starts at release/RTM-2.1. Import only the RTM and
four shared utility files from released tag RTM-v2.2.2.1, commit
81c6e4a0f9aded0c5f6a7190645e6089241187d7. This brings the supported creation,
request-ID callbacks, history and metadata behavior onto that old baseline;
RTC source and Terra renderers are not imported. A later Metadata default
constructor fix is also carried to support JSON deserialization.

Additional handwritten bindings follow the actual 2026-10-22 MINI_RTM headers:
GetUserOnlineStatusAsync and nullable error callback data; TokenEvent with
affected message channels; PresenceEvent.totalOccupancy; RtmConfig parameters,
reconnectTimeout and ispPolicyEnabled. The new routing IDs were read from the
actual dev.4 Iris binary, not invented from API names.

Evidence collected on 2026-10-23:

- Managed compile and callback regressions pass: online/offline responses,
  request correlation, null failure payloads, immediate error, TokenEvent
  channel data, configuration forwarding and presence conversion.
- All C# dispatch IDs except the retained legacy onConnectionStateChanged ID
  occur in the actual iOS Iris binary. All hashed RTM dispatch names found in
  that binary have corresponding C# constants. String presence is a routing
  audit, not complete wire-format or behavioral verification.
- Actual macOS Unity bundle loads through the managed P/Invoke resolver;
  GetIrisRtmVersion, CreateIrisRtmEngine and DestroyIrisRtmEngine pass without
  a login or service call. Iris reports dev.4 / b55b8f5b / build 321000;
  Native reports engineering build 1354431, matching the selected Mac package.
- The four public Native CDN ZIP SHA-256 values match the previously registered
  original MINI_RTM artifacts byte for byte:
  Android 09d0bc1781f79535498f82c934aa8c138aab2973d700649327778f9bf5ed5e81;
  Windows bb2b8765005568ee4d3aaf218b6be70e1aa066ec7a86940f1a33d5bbeeb9d90e;
  Mac bd4cfe39c11e86770152574fc6f3e8afe34ec113c664f4139a8be5a494954edc;
  iOS 99f99b48ae3263cad0e141068cb80eab05cc116182301dd7464ce535d9b8f9da.
- The actual shared dependency parser roundtrips all eight manifest URLs.
  Native public preview filenames retain the original ZIP layouts; iOS uses
  ios-arm64_armv7. The packager accepts that device slice and emits distinct
  framework importer GUIDs. The old baseline needed the iOS importer template.

Not yet verified: Unity Editor export, platform device compilation, authenticated
login/messaging, reconnection, permission revocation and customer QA. There is
no Unity Editor installed on the local validation host. Do not mark QA or final
delivery complete based on these checks. Test this candidate with the actual
Unity Job after review and merge; no Native/Iris rebuild is needed.

Run `bash ci/build/rtm-compile.sh` with .NET 8. Optionally set
AGORA_RTM_NATIVE_SMOKE to a downloaded actual Mac Unity bundle executable to
repeat the non-network native ABI smoke.
