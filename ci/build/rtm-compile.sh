#!/usr/bin/env bash
set -euo pipefail
root=$(cd "$(dirname "$0")/../.." && pwd)
candidate=$(mktemp -d)
trap 'rm -rf "$candidate"' EXIT
cp -R "$root/Agora-C_Sharp-RTC-SDK" "$candidate/sdk"
# Compile the same RTM-only source selection as the Unity packaging job.
python3 "$root/ci/build/remove_code_by_macor.py" "$candidate/sdk" false true false false true false
cp "$root/ci/build/rtm-compile.csproj" "$candidate/rtm.csproj"
cp "$root/ci/build/rtm-regression.cs" "$candidate/rtm-regression.cs"
dotnet run --project "$candidate/rtm.csproj" --configuration Release
