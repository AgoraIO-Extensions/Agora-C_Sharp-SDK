#!/bin/bash
set -e
set +x
MY_PATH=$(realpath $(dirname "$0"))
PROJECT_ROOT=$(realpath ${MY_PATH}/../..)
PACKAGE_JSON_PATH="${PROJECT_ROOT}/package.json"
# TERRA_CONFIG_PATH1="${PROJECT_ROOT}/scripts/terra/config/types_config.yaml"
# TERRA_CONFIG_PATH2="${PROJECT_ROOT}/scripts/terra/config/impl_config.yaml"
URL_CONFIG_PATH="${PROJECT_ROOT}/ci/build/url_config.txt"

if [ "$#" -lt 1 ]; then
    exit 1
fi
INPUT=$1

IOS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "iOS") | .cdn[]')
MAC_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "macOS") | .cdn[]')
ANDROID_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Android") | .cdn[]')
WINDOWS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Windows") | .cdn[]')

IRIS_IOS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "iOS") | .iris_cdn[]')
IRIS_MAC_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "macOS") | .iris_cdn[]')
IRIS_ANDROID_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Android") | .iris_cdn[]')
IRIS_WINDOWS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Windows") | .iris_cdn[]')

DEP_VERSION=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Windows") | .version')

# Helper: detect release type from IRIS urls for a platform (video|audio), default video
detect_release_type() {
  local list="$1"
  local has_video=0
  local has_audio=0
  for DEP in $list; do
    case "$DEP" in
      *Video*) has_video=1 ;;
      *Audio*|*Voice*) has_audio=1 ;;
    esac
  done
  if [ "$has_video" = "1" ] && [ "$has_audio" != "1" ]; then
    echo video
  elif [ "$has_audio" = "1" ] && [ "$has_video" != "1" ]; then
    echo audio
  else
    echo video
  fi
}

# Determine global RELEASE_TYPE from all IRIS links (iOS/Android/macOS/Windows)
RELEASE_TYPE=$(detect_release_type "$IRIS_IOS_DEPENDENCIES $IRIS_ANDROID_DEPENDENCIES $IRIS_MAC_DEPENDENCIES $IRIS_WINDOWS_DEPENDENCIES")

# Helper: choose appropriate IRIS link (POSIX sh compatible)
# macOS 优先包含 "Unity"；其他平台优先包含 "Standalone"；否则取第一个
choose_iris_dep() {
  local list="$1"
  local platform="$2"
  local chosen=""
  if [ "$platform" = "macOS" ]; then
    for DEP in $list; do
      case "$DEP" in
        *Unity*) echo "$DEP"; return ;;
      esac
      if [ -z "$chosen" ]; then chosen="$DEP"; fi
    done
    echo "$chosen"; return
  else
    for DEP in $list; do
      case "$DEP" in
        *Standalone*) echo "$DEP"; return ;;
      esac
      if [ -z "$chosen" ]; then chosen="$DEP"; fi
    done
    echo "$chosen"; return
  fi
}

# Helper: choose first native link from cdn list
choose_native_dep() {
  local list="$1"
  for DEP in $list; do
    echo "$DEP"; return
  done
  echo ""
}

# Helper: update a key within a named section (>>>section ... <<<end)
update_url_config_key() {
  local section="$1"   # e.g. video | audio
  local key="$2"       # e.g. IRIS_MAC
  local value="$3"     # url value
  [ -z "$value" ] && return 0
  if [ ! -f "$URL_CONFIG_PATH" ]; then
    echo "url_config.txt not found at $URL_CONFIG_PATH"
    return 1
  fi
  # escape replacement for sed (&, \\ and delimiter #)
  local esc
  esc=$(printf '%s' "$value" | sed -e 's/[&#\\]/\\&/g')
  sed \
    -e "/^>>>$section/,/^<<<end/ s#^$key=.*#$key=$esc#" \
    "$URL_CONFIG_PATH" > "$URL_CONFIG_PATH.tmp" && mv "$URL_CONFIG_PATH.tmp" "$URL_CONFIG_PATH"
}

if [ -z "$MAC_DEPENDENCIES" ]; then
  echo "No mac native dependencies need to change."
else
  for DEP in $MAC_DEPENDENCIES; do
    if [ -f "$PACKAGE_JSON_PATH" ]; then
      sed 's|"native_sdk_mac": "\(.*\)"|"native_sdk_mac": '"$DEP"'|g' "$PACKAGE_JSON_PATH" > tmp && mv tmp "$PACKAGE_JSON_PATH"
    else
      echo "package.json not found at $PACKAGE_JSON_PATH, skip updating native_sdk_mac"
    fi
    break
  done
fi

if [ -z "$IRIS_MAC_DEPENDENCIES" ]; then
  echo "No iris mac native dependencies need to change."
else
  CHOSEN=$(choose_iris_dep "$IRIS_MAC_DEPENDENCIES" "macOS")
  IRIS_MAC_CHOSEN="$CHOSEN"
  if [ -n "$CHOSEN" ]; then
    if [ -f "$PACKAGE_JSON_PATH" ]; then
      sed 's|"iris_sdk_mac": "\(.*\)"|"iris_sdk_mac": '"$CHOSEN"'|g' "$PACKAGE_JSON_PATH" > tmp && mv tmp "$PACKAGE_JSON_PATH"
    else
      echo "package.json not found at $PACKAGE_JSON_PATH, skip updating iris_sdk_mac"
    fi
    # Update url_config.txt IRIS_MAC in both sections
    update_url_config_key video IRIS_MAC "$CHOSEN"
    update_url_config_key audio IRIS_MAC "$CHOSEN"
  fi
fi

if [ -z "$WINDOWS_DEPENDENCIES" ]; then
  echo "No windows native dependencies need to change."
else
  if [ -f "$PACKAGE_JSON_PATH" ]; then
    sed 's|"native_sdk_win": "\(.*\)"|"native_sdk_win": '"$WINDOWS_DEPENDENCIES"'|g' "$PACKAGE_JSON_PATH" > tmp && mv tmp "$PACKAGE_JSON_PATH"
  else
    echo "package.json not found at $PACKAGE_JSON_PATH, skip updating native_sdk_win"
  fi
fi

if [ -z "$IRIS_WINDOWS_DEPENDENCIES" ]; then
  echo "No iris windows native dependencies need to change."
else
  CHOSEN=$(choose_iris_dep "$IRIS_WINDOWS_DEPENDENCIES" "Windows")
  IRIS_WIN_CHOSEN="$CHOSEN"
  if [ -n "$CHOSEN" ]; then
    if [ -f "$PACKAGE_JSON_PATH" ]; then
      sed 's|"iris_sdk_win": "\(.*\)"|"iris_sdk_win": '"$CHOSEN"'|g' "$PACKAGE_JSON_PATH" > tmp && mv tmp "$PACKAGE_JSON_PATH"
    else
      echo "package.json not found at $PACKAGE_JSON_PATH, skip updating iris_sdk_win"
    fi
    # Update url_config.txt IRIS_WIN in both sections
    update_url_config_key video IRIS_WIN "$CHOSEN"
    update_url_config_key audio IRIS_WIN "$CHOSEN"
  fi
fi

# if [ -z "$DEP_VERSION" ]; then
#   echo "can not find dependencies version."
# else
#   echo "update dependencies version to $TERRA_CONFIG_PATH1"
#   sed 's|sdkVersion: \(.*\)|sdkVersion: '$DEP_VERSION'|g' $TERRA_CONFIG_PATH1 > tmp
#   mv tmp $TERRA_CONFIG_PATH1
#   sed 's|sdkVersion: \(.*\)|sdkVersion: '$DEP_VERSION'|g' $TERRA_CONFIG_PATH2 > tmp
#   mv tmp $TERRA_CONFIG_PATH2
# fi

# Optionally update iOS/Android IRIS URLs in url_config.txt when present in the input
CHOSEN_IOS=$(choose_iris_dep "$IRIS_IOS_DEPENDENCIES" "iOS")
CHOSEN_ANDROID=$(choose_iris_dep "$IRIS_ANDROID_DEPENDENCIES" "Android")

# Update IRIS_* for mobile based on global RELEASE_TYPE
if [ -n "$CHOSEN_IOS" ]; then
  if [ "$RELEASE_TYPE" = "audio" ]; then
    update_url_config_key audio IRIS_IOS "$CHOSEN_IOS"
  else
    update_url_config_key video IRIS_IOS "$CHOSEN_IOS"
  fi
fi

if [ -n "$CHOSEN_ANDROID" ]; then
  if [ "$RELEASE_TYPE" = "audio" ]; then
    update_url_config_key audio IRIS_ANDROID "$CHOSEN_ANDROID"
  else
    update_url_config_key video IRIS_ANDROID "$CHOSEN_ANDROID"
  fi
fi

# Update NATIVE_* in url_config.txt from cdn lists (first item if exists)
NATIVE_IOS=$(choose_native_dep "$IOS_DEPENDENCIES")
if [ -n "$NATIVE_IOS" ]; then
  if [ "$RELEASE_TYPE" = "audio" ]; then
    update_url_config_key audio NATIVE_IOS "$NATIVE_IOS"
  else
    update_url_config_key video NATIVE_IOS "$NATIVE_IOS"
  fi
fi

NATIVE_ANDROID=$(choose_native_dep "$ANDROID_DEPENDENCIES")
if [ -n "$NATIVE_ANDROID" ]; then
  if [ "$RELEASE_TYPE" = "audio" ]; then
    update_url_config_key audio NATIVE_ANDROID "$NATIVE_ANDROID"
  else
    update_url_config_key video NATIVE_ANDROID "$NATIVE_ANDROID"
  fi
fi

NATIVE_MAC=$(choose_native_dep "$MAC_DEPENDENCIES")
if [ -n "$NATIVE_MAC" ]; then
  update_url_config_key video NATIVE_MAC "$NATIVE_MAC"
  update_url_config_key audio NATIVE_MAC "$NATIVE_MAC"
fi

NATIVE_WIN=$(choose_native_dep "$WINDOWS_DEPENDENCIES")
if [ -n "$NATIVE_WIN" ]; then
  update_url_config_key video NATIVE_WIN "$NATIVE_WIN"
  update_url_config_key audio NATIVE_WIN "$NATIVE_WIN"
fi