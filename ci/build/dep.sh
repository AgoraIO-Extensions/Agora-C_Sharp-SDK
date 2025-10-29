#!/bin/bash
set -e
set +x
MY_PATH=$(realpath $(dirname "$0"))
PROJECT_ROOT=$(realpath ${MY_PATH}/../..)
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

# Extract version from first platform that has a non-empty version
DEP_VERSION=$(echo "$INPUT" | jq -r '.[] | select(.version != "" and .version != null) | .version' | head -n 1)
echo "Detected version: $DEP_VERSION"

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

# Helper: compare version numbers (returns 0 if v1 >= v2, 1 otherwise)
version_compare() {
  local v1="$1"
  local v2="$2"
  
  # Extract major.minor from version string (e.g., "4.5.2.2" -> "4.5")
  local v1_major_minor=$(echo "$v1" | cut -d. -f1,2)
  local v2_major_minor=$(echo "$v2" | cut -d. -f1,2)
  
  # Convert to comparable format by removing dots
  local v1_num=$(echo "$v1_major_minor" | tr -d '.')
  local v2_num=$(echo "$v2_major_minor" | tr -d '.')
  
  if [ "$v1_num" -ge "$v2_num" ]; then
    return 0
  else
    return 1
  fi
}

# Helper: choose appropriate IRIS link (POSIX sh compatible)
# Rules:
# 1. macOS: always prefer "Unity"
# 2. Other platforms:
#    - If version < 4.5: prefer link WITHOUT "Standalone"
#    - If version >= 4.5: prefer link WITH "Standalone"
# 3. If no match, take the first available link
choose_iris_dep() {
  local list="$1"
  local platform="$2"
  local version="$3"  # New parameter for version
  local chosen=""
  
  echo "Selecting IRIS dependency for platform: $platform, version: $version" >&2
  
  if [ "$platform" = "macOS" ]; then
    # macOS: always prefer Unity
    for DEP in $list; do
      case "$DEP" in
        *Unity*) 
          echo "  -> Selected Unity link: $DEP" >&2
          echo "$DEP"
          return ;;
      esac
      if [ -z "$chosen" ]; then chosen="$DEP"; fi
    done
    echo "  -> No Unity link found, using: $chosen" >&2
    echo "$chosen"; return
  else
    # Other platforms: version-based selection
    local prefer_standalone=0
    
    # Determine if we should prefer Standalone based on version
    if [ -n "$version" ]; then
      if version_compare "$version" "4.5"; then
        prefer_standalone=1
        echo "  -> Version >= 4.5, preferring Standalone" >&2
      else
        echo "  -> Version < 4.5, preferring non-Standalone" >&2
      fi
    fi
    
    if [ "$prefer_standalone" -eq 1 ]; then
      # Version >= 4.5: prefer WITH Standalone
      for DEP in $list; do
        case "$DEP" in
          *Standalone*) 
            echo "  -> Selected Standalone link: $DEP" >&2
            echo "$DEP"
            return ;;
        esac
        if [ -z "$chosen" ]; then chosen="$DEP"; fi
      done
    else
      # Version < 4.5: prefer WITHOUT Standalone
      for DEP in $list; do
        case "$DEP" in
          *Standalone*) ;;  # Skip Standalone links
          *) 
            if [ -z "$chosen" ]; then
              chosen="$DEP"
            fi
            ;;
        esac
      done
      # If all links have Standalone, use the first one anyway
      if [ -z "$chosen" ]; then
        for DEP in $list; do
          chosen="$DEP"
          break
        done
      fi
    fi
    
    echo "  -> Selected link: $chosen" >&2
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
  
  echo "Updating $key in section '$section' with value: $value"
  
  # Use awk for safer URL replacement
  awk -v section="$section" -v key="$key" -v value="$value" '
    /^>>>/ {
      section_name = substr($0, 4)
      if (section_name == section) {
        in_section = 1
        # DEBUG: uncomment to see section detection
        # print "# DEBUG: Entering section: " section_name > "/dev/stderr"
      } else {
        in_section = 0
      }
      print
      next
    }
    /^<<<end/ {
      in_section = 0
      print
      next
    }
    {
      if (in_section) {
        # Check if this line starts with the key
        if (index($0, key "=") == 1) {
          # DEBUG: uncomment to see replacements
          # print "# DEBUG: Replacing line: " $0 > "/dev/stderr"
          # print "# DEBUG: With: " key "=" value > "/dev/stderr"
          print key "=" value
        } else {
          print
        }
      } else {
        print
      }
    }
  ' "$URL_CONFIG_PATH" > "$URL_CONFIG_PATH.tmp"
  
  if [ $? -eq 0 ]; then
    mv "$URL_CONFIG_PATH.tmp" "$URL_CONFIG_PATH"
    echo "Successfully updated $key in section '$section' to: $value"
  else
    echo "Failed to update $key in section '$section'"
    rm -f "$URL_CONFIG_PATH.tmp"
    return 1
  fi
}

if [ -z "$MAC_DEPENDENCIES" ]; then
  echo "No mac native dependencies need to change."
else
  NATIVE_MAC=$(choose_native_dep "$MAC_DEPENDENCIES")
  if [ -n "$NATIVE_MAC" ]; then
    echo "Mac native dependency: $NATIVE_MAC"
    update_url_config_key video NATIVE_MAC "$NATIVE_MAC"
    update_url_config_key audio NATIVE_MAC "$NATIVE_MAC"
  fi
fi

if [ -z "$IRIS_MAC_DEPENDENCIES" ]; then
  echo "No iris mac native dependencies need to change."
else
  CHOSEN=$(choose_iris_dep "$IRIS_MAC_DEPENDENCIES" "macOS" "$DEP_VERSION")
  IRIS_MAC_CHOSEN="$CHOSEN"
  if [ -n "$CHOSEN" ]; then
    echo "Iris Mac dependency: $CHOSEN"
    # Update url_config.txt IRIS_MAC in both sections
    update_url_config_key video IRIS_MAC "$CHOSEN"
    update_url_config_key audio IRIS_MAC "$CHOSEN"
  fi
fi

if [ -z "$WINDOWS_DEPENDENCIES" ]; then
  echo "No windows native dependencies need to change."
else
  NATIVE_WIN=$(choose_native_dep "$WINDOWS_DEPENDENCIES")
  if [ -n "$NATIVE_WIN" ]; then
    echo "Windows native dependency: $NATIVE_WIN"
    update_url_config_key video NATIVE_WIN "$NATIVE_WIN"
    update_url_config_key audio NATIVE_WIN "$NATIVE_WIN"
  fi
fi

if [ -z "$IRIS_WINDOWS_DEPENDENCIES" ]; then
  echo "No iris windows native dependencies need to change."
else
  CHOSEN=$(choose_iris_dep "$IRIS_WINDOWS_DEPENDENCIES" "Windows" "$DEP_VERSION")
  IRIS_WIN_CHOSEN="$CHOSEN"
  if [ -n "$CHOSEN" ]; then
    echo "Iris Windows dependency: $CHOSEN"
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
CHOSEN_IOS=$(choose_iris_dep "$IRIS_IOS_DEPENDENCIES" "iOS" "$DEP_VERSION")
CHOSEN_ANDROID=$(choose_iris_dep "$IRIS_ANDROID_DEPENDENCIES" "Android" "$DEP_VERSION")

# Update IRIS_* for mobile based on global RELEASE_TYPE
if [ -n "$CHOSEN_IOS" ]; then
  echo "Iris iOS dependency: $CHOSEN_IOS"
  if [ "$RELEASE_TYPE" = "audio" ]; then
    update_url_config_key audio IRIS_IOS "$CHOSEN_IOS"
  else
    update_url_config_key video IRIS_IOS "$CHOSEN_IOS"
  fi
fi

if [ -n "$CHOSEN_ANDROID" ]; then
  echo "Iris Android dependency: $CHOSEN_ANDROID"
  if [ "$RELEASE_TYPE" = "audio" ]; then
    update_url_config_key audio IRIS_ANDROID "$CHOSEN_ANDROID"
  else
    update_url_config_key video IRIS_ANDROID "$CHOSEN_ANDROID"
  fi
fi

# Update NATIVE_* in url_config.txt from cdn lists (first item if exists)
NATIVE_IOS=$(choose_native_dep "$IOS_DEPENDENCIES")
if [ -n "$NATIVE_IOS" ]; then
  echo "iOS native dependency: $NATIVE_IOS"
  if [ "$RELEASE_TYPE" = "audio" ]; then
    update_url_config_key audio NATIVE_IOS "$NATIVE_IOS"
  else
    update_url_config_key video NATIVE_IOS "$NATIVE_IOS"
  fi
fi

NATIVE_ANDROID=$(choose_native_dep "$ANDROID_DEPENDENCIES")
if [ -n "$NATIVE_ANDROID" ]; then
  echo "Android native dependency: $NATIVE_ANDROID"
  if [ "$RELEASE_TYPE" = "audio" ]; then
    update_url_config_key audio NATIVE_ANDROID "$NATIVE_ANDROID"
  else
    update_url_config_key video NATIVE_ANDROID "$NATIVE_ANDROID"
  fi
fi

echo "Dependencies update completed successfully!"
