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

MAC_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "macOS") | .cdn[]')
IRIS_MAC_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "macOS") | .iris_cdn[]')
WINDOWS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Windows") | .cdn[]')
IRIS_WINDOWS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Windows") | .iris_cdn[]')
DEP_VERSION=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Windows") | .version')

# Optional: gather IRIS dependencies for iOS/Android as well
IRIS_IOS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "iOS") | .iris_cdn[]')
IRIS_ANDROID_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Android") | .iris_cdn[]')

# Helper: choose first Standalone link if present; otherwise first item
choose_iris_dep() {
  local list="$1"
  local chosen=""
  for DEP in $list; do
    if [[ "$DEP" == *Standalone* ]]; then
      chosen="$DEP"
      break
    fi
    if [ -z "$chosen" ]; then
      chosen="$DEP"
    fi
  done
  echo "$chosen"
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
  awk -v sec="${section}" -v key="${key}" -v val="${value}" '
    $0 ~ ">>>"sec {in=1; print; next}
    in==1 && $0 ~ /^<<<end/ {in=0; print; next}
    in==1 && $0 ~ ("^"key"=") { print key"="val; next }
    { print }
  ' "$URL_CONFIG_PATH" > "$URL_CONFIG_PATH.tmp" && mv "$URL_CONFIG_PATH.tmp" "$URL_CONFIG_PATH"
}

if [ -z "$MAC_DEPENDENCIES" ]; then
  echo "No mac native dependencies need to change."
else
  for DEP in $MAC_DEPENDENCIES; do
    sed 's|"native_sdk_mac": "\(.*\)"|"native_sdk_mac": "'"$DEP"'"|g' $PACKAGE_JSON_PATH > tmp
    mv tmp package.json
    break
  done
fi

if [ -z "$IRIS_MAC_DEPENDENCIES" ]; then
  echo "No iris mac native dependencies need to change."
else
  CHOSEN=$(choose_iris_dep "$IRIS_MAC_DEPENDENCIES")
  if [ -n "$CHOSEN" ]; then
    sed 's|"iris_sdk_mac": "\(.*\)"|"iris_sdk_mac": '"$CHOSEN"'|g' $PACKAGE_JSON_PATH > tmp
    mv tmp package.json
    # Update url_config.txt IRIS_MAC in both sections
    update_url_config_key video IRIS_MAC "$CHOSEN"
    update_url_config_key audio IRIS_MAC "$CHOSEN"
  fi
fi

if [ -z "$WINDOWS_DEPENDENCIES" ]; then
  echo "No windows native dependencies need to change."
else
  sed 's|"native_sdk_win": "\(.*\)"|"native_sdk_win": "'"$WINDOWS_DEPENDENCIES"'"|g' $PACKAGE_JSON_PATH > tmp
  mv tmp package.json
fi

if [ -z "$IRIS_WINDOWS_DEPENDENCIES" ]; then
  echo "No iris windows native dependencies need to change."
else
  CHOSEN=$(choose_iris_dep "$IRIS_WINDOWS_DEPENDENCIES")
  if [ -n "$CHOSEN" ]; then
    sed 's|"iris_sdk_win": "\(.*\)"|"iris_sdk_win": '"$CHOSEN"'|g' $PACKAGE_JSON_PATH > tmp
    mv tmp package.json
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
CHOSEN_IOS=$(choose_iris_dep "$IRIS_IOS_DEPENDENCIES")
if [ -n "$CHOSEN_IOS" ]; then
  update_url_config_key video IRIS_IOS "$CHOSEN_IOS"
  update_url_config_key audio IRIS_IOS "$CHOSEN_IOS"
fi

CHOSEN_ANDROID=$(choose_iris_dep "$IRIS_ANDROID_DEPENDENCIES")
if [ -n "$CHOSEN_ANDROID" ]; then
  update_url_config_key video IRIS_ANDROID "$CHOSEN_ANDROID"
  update_url_config_key audio IRIS_ANDROID "$CHOSEN_ANDROID"
fi