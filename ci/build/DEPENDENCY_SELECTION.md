# Native dependency modes (EP-1027)

`Update-Deps.py` preserves the selected URLs and complete versions. Native FULL/VIDEO and VOICE/AUDIO filenames retain their known video/audio modes. A custom profile such as FAV is not an audio profile by default: its mode is taken from the selected, eligible Iris archives for the same platform when exactly one mode is present.

When no eligible Iris mode is available or both modes are present, explicitly select `native-mode: video` or `native-mode: audio` in the Terra workflow. For direct script use, pass `--native-mode video` or `--native-mode audio`. `auto` is the default; known Native modes are unaffected by this fallback. An unresolved custom mode stops before either configuration file is written, with instructions to select Iris artifacts or set the mode. It never silently keeps the video configuration while writing an unknown SDK into audio.

Existing desktop video-to-audio Native fallback is retained. Select the exact source artifacts and review the generated PR before builds. No historical dependencies or business jobs are rewritten/replayed by this fix. Rehoboam callers can use the usual dependency-content input when the Iris mode is unambiguous; to expose the optional mode input, refresh the configured workflow parameters after this workflow is merged, then explicitly select the intended mode.

Run `python3 -m unittest discover -s ci/build -p test_update_deps.py -v` for isolated, temporary-file regression checks. The tests never update repository configuration or start CI jobs.

The Terra workflow restores only `ci/build/Update-Deps.py` from the exact triggering commit (`github.sha`) after checking out its existing result branch. This prevents stale `terra/...` tooling from undoing the fix; generated SDK files, selected dependencies, and other result-branch changes are not reset. Only the maintained entry branches need the workflow fix; ordinary result branches use the pinned updater on their next run.
