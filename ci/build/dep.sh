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

# Extract and split cdn links (handles both array format and \n-separated strings)
# The gsub converts literal \n in the string to actual newlines, then we process each line
IOS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "iOS") | .cdn[] | split("\\n") | .[]')
MAC_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "macOS") | .cdn[] | split("\\n") | .[]')
ANDROID_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Android") | .cdn[] | split("\\n") | .[]')
WINDOWS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Windows") | .cdn[] | split("\\n") | .[]')

# Extract IRIS links
IRIS_IOS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "iOS") | .iris_cdn[]')
IRIS_MAC_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "macOS") | .iris_cdn[]')
IRIS_ANDROID_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Android") | .iris_cdn[]')
IRIS_WINDOWS_DEPENDENCIES=$(echo "$INPUT" | jq -r '.[] | select(.platform == "Windows") | .iris_cdn[]')

# Debug: show what we extracted
echo "=== Debug: Extracted Native SDK Links ==="
echo "iOS Native: $(echo "$IOS_DEPENDENCIES" | head -c 200)..."
echo "Mac Native: $(echo "$MAC_DEPENDENCIES" | head -c 200)..."
echo "Android Native: $(echo "$ANDROID_DEPENDENCIES" | head -c 200)..."
echo "Windows Native: $(echo "$WINDOWS_DEPENDENCIES" | head -c 200)..."
echo ""
echo "=== Debug: Extracted IRIS Links ==="
echo "iOS IRIS: $(echo "$IRIS_IOS_DEPENDENCIES" | head -c 200)..."
echo "Mac IRIS: $(echo "$IRIS_MAC_DEPENDENCIES" | head -c 200)..."
echo "Android IRIS: $(echo "$IRIS_ANDROID_DEPENDENCIES" | head -c 200)..."
echo "Windows IRIS: $(echo "$IRIS_WINDOWS_DEPENDENCIES" | head -c 200)..."
echo ""

# Extract version from first platform that has a non-empty version
DEP_VERSION=$(echo "$INPUT" | jq -r '.[] | select(.version != "" and .version != null) | .version' | head -n 1)
echo "Detected version: $DEP_VERSION"

# Helper: detect release types from IRIS urls (returns "audio", "video", or "both")
detect_release_types() {
  local list="$1"
  local has_video=0
  local has_audio=0
  local audio_count=0
  local video_count=0
  
  for DEP in $list; do
    # Convert to lowercase for case-insensitive matching
    local dep_lower=$(echo "$DEP" | tr '[:upper:]' '[:lower:]')
    case "$dep_lower" in
      *video*|*full*) 
        has_video=1
        video_count=$((video_count + 1))
        echo "  [DEBUG] Found video/full link: $(basename "$DEP")" >&2
        ;;
      *audio*|*voice*) 
        has_audio=1
        audio_count=$((audio_count + 1))
        echo "  [DEBUG] Found audio/voice link: $(basename "$DEP")" >&2
        ;;
    esac
  done
  
  echo "  [DEBUG] Total: $audio_count audio/voice, $video_count video/full" >&2
  
  if [ "$has_video" = "1" ] && [ "$has_audio" = "1" ]; then
    echo "both"
  elif [ "$has_audio" = "1" ]; then
    echo "audio"
  elif [ "$has_video" = "1" ]; then
    echo "video"
  else
    echo "video"  # default
  fi
}

# Determine release types from all IRIS and Native SDK links
ALL_IRIS_DEPS="$IRIS_IOS_DEPENDENCIES $IRIS_ANDROID_DEPENDENCIES $IRIS_MAC_DEPENDENCIES $IRIS_WINDOWS_DEPENDENCIES"
ALL_NATIVE_DEPS="$IOS_DEPENDENCIES $MAC_DEPENDENCIES $ANDROID_DEPENDENCIES $WINDOWS_DEPENDENCIES"
ALL_DEPS="$ALL_IRIS_DEPS $ALL_NATIVE_DEPS"

RELEASE_TYPES=$(detect_release_types "$ALL_DEPS")
echo "Detected release types from IRIS and Native SDK links: $RELEASE_TYPES"

# Determine which sections to update
UPDATE_AUDIO=0
UPDATE_VIDEO=0
if [ "$RELEASE_TYPES" = "both" ]; then
  UPDATE_AUDIO=1
  UPDATE_VIDEO=1
  echo "Will update both audio and video sections"
elif [ "$RELEASE_TYPES" = "audio" ]; then
  UPDATE_AUDIO=1
  echo "Will update audio section only"
else
  UPDATE_VIDEO=1
  echo "Will update video section only"
fi

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

# Helper: filter links by type (audio or video)
filter_links_by_type() {
  local list="$1"
  local type="$2"  # "audio" or "video"
  local result=""
  
  for DEP in $list; do
    # Convert to lowercase for case-insensitive matching
    local dep_lower=$(echo "$DEP" | tr '[:upper:]' '[:lower:]')
    local is_audio=0
    local is_video=0
    
    # Check for audio keywords (voice, audio)
    case "$dep_lower" in
      *audio*|*voice*) is_audio=1 ;;
    esac
    
    # Check for video keywords (video, full)
    case "$dep_lower" in
      *video*|*full*) is_video=1 ;;
    esac
    
    # Add to result based on type
    if [ "$type" = "audio" ] && [ "$is_audio" = "1" ]; then
      result="$result $DEP"
    elif [ "$type" = "video" ] && [ "$is_video" = "1" ]; then
      result="$result $DEP"
    elif [ "$type" = "video" ] && [ "$is_audio" = "0" ] && [ "$is_video" = "0" ]; then
      # If no audio/video keyword found, treat as video by default
      result="$result $DEP"
    fi
  done
  
  echo "$result"
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

# Helper: choose native link from cdn list with priority
# Priority: 1. CDN (download.agora.io) 2. Numeric IP 3. Artifactory
# Parameters: $1=list of links, $2=platform name (iOS, Android, macOS, Windows)
choose_native_dep() {
  local list="$1"
  local platform="$2"
  local cdn_links=""
  local ip_links=""
  local artifactory_links=""
  local other_links=""
  
  # Map platform name for matching in URLs
  local platform_pattern=""
  case "$platform" in
    iOS) platform_pattern="iOS" ;;
    Android) platform_pattern="Android" ;;
    macOS) platform_pattern="Mac" ;;
    Windows) platform_pattern="Windows" ;;
  esac
  
  # Classify links by priority, filtering by platform
  for DEP in $list; do
    # Skip links that don't match the platform
    if [ -n "$platform_pattern" ]; then
      case "$DEP" in
        *"$platform_pattern"*)
          # Link matches platform, continue to classify
          ;;
        *)
          # Link doesn't match platform, skip it
          continue
          ;;
      esac
    fi
    
    # Classify by priority using POSIX-compatible pattern matching
    case "$DEP" in
      *download.agora.io*)
        # Priority 1: CDN links
        cdn_links="$cdn_links $DEP"
        ;;
      http://[0-9]*|https://[0-9]*)
        # Priority 2: Numeric IP links (simplified check)
        ip_links="$ip_links $DEP"
        ;;
      *artifactory*)
        # Priority 3: Artifactory links
        artifactory_links="$artifactory_links $DEP"
        ;;
      *)
        # Other links
        other_links="$other_links $DEP"
        ;;
    esac
  done
  
  # Return the first link from highest priority category
  if [ -n "$cdn_links" ]; then
    for DEP in $cdn_links; do
      echo "  -> Selected CDN link (priority 1)" >&2
      echo "$DEP"
      return
    done
  elif [ -n "$ip_links" ]; then
    for DEP in $ip_links; do
      echo "  -> Selected IP link (priority 2)" >&2
      echo "$DEP"
      return
    done
  elif [ -n "$artifactory_links" ]; then
    for DEP in $artifactory_links; do
      echo "  -> Selected Artifactory link (priority 3)" >&2
      echo "$DEP"
      return
    done
  elif [ -n "$other_links" ]; then
    for DEP in $other_links; do
      echo "  -> Selected other link" >&2
      echo "$DEP"
      return
    done
  fi
  
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
  
  # escape replacement for sed (&, \\ and delimiter #)
  local esc
  esc=$(printf '%s' "$value" | sed -e 's/[&#\\]/\\&/g')
  
  sed \
    -e "/^>>>$section/,/^<<<end/ s#^$key=.*#$key=$esc#" \
    "$URL_CONFIG_PATH" > "$URL_CONFIG_PATH.tmp"
  
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
  # Update audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    AUDIO_LINKS=$(filter_links_by_type "$MAC_DEPENDENCIES" "audio")
    NATIVE_MAC_AUDIO=$(choose_native_dep "$AUDIO_LINKS" "macOS")
    if [ -n "$NATIVE_MAC_AUDIO" ]; then
      echo "Mac native dependency (audio): $NATIVE_MAC_AUDIO"
      update_url_config_key audio NATIVE_MAC "$NATIVE_MAC_AUDIO"
    fi
  fi
  
  # Update video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    VIDEO_LINKS=$(filter_links_by_type "$MAC_DEPENDENCIES" "video")
    NATIVE_MAC_VIDEO=$(choose_native_dep "$VIDEO_LINKS" "macOS")
    if [ -n "$NATIVE_MAC_VIDEO" ]; then
      echo "Mac native dependency (video): $NATIVE_MAC_VIDEO"
      update_url_config_key video NATIVE_MAC "$NATIVE_MAC_VIDEO"
    fi
  fi
fi

if [ -z "$IRIS_MAC_DEPENDENCIES" ]; then
  echo "No iris mac native dependencies need to change."
else
  # Update audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    AUDIO_LINKS=$(filter_links_by_type "$IRIS_MAC_DEPENDENCIES" "audio")
    CHOSEN=$(choose_iris_dep "$AUDIO_LINKS" "macOS" "$DEP_VERSION")
    if [ -n "$CHOSEN" ]; then
      echo "Iris Mac dependency (audio): $CHOSEN"
      update_url_config_key audio IRIS_MAC "$CHOSEN"
    fi
  fi
  
  # Update video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    VIDEO_LINKS=$(filter_links_by_type "$IRIS_MAC_DEPENDENCIES" "video")
    CHOSEN=$(choose_iris_dep "$VIDEO_LINKS" "macOS" "$DEP_VERSION")
    IRIS_MAC_CHOSEN="$CHOSEN"
    if [ -n "$CHOSEN" ]; then
      echo "Iris Mac dependency (video): $CHOSEN"
      update_url_config_key video IRIS_MAC "$CHOSEN"
    fi
  fi
fi

if [ -z "$WINDOWS_DEPENDENCIES" ]; then
  echo "No windows native dependencies need to change."
else
  # Update audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    AUDIO_LINKS=$(filter_links_by_type "$WINDOWS_DEPENDENCIES" "audio")
    NATIVE_WIN_AUDIO=$(choose_native_dep "$AUDIO_LINKS" "Windows")
    if [ -n "$NATIVE_WIN_AUDIO" ]; then
      echo "Windows native dependency (audio): $NATIVE_WIN_AUDIO"
      update_url_config_key audio NATIVE_WIN "$NATIVE_WIN_AUDIO"
    fi
  fi
  
  # Update video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    VIDEO_LINKS=$(filter_links_by_type "$WINDOWS_DEPENDENCIES" "video")
    NATIVE_WIN_VIDEO=$(choose_native_dep "$VIDEO_LINKS" "Windows")
    if [ -n "$NATIVE_WIN_VIDEO" ]; then
      echo "Windows native dependency (video): $NATIVE_WIN_VIDEO"
      update_url_config_key video NATIVE_WIN "$NATIVE_WIN_VIDEO"
    fi
  fi
fi

if [ -z "$IRIS_WINDOWS_DEPENDENCIES" ]; then
  echo "No iris windows native dependencies need to change."
else
  # Update audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    AUDIO_LINKS=$(filter_links_by_type "$IRIS_WINDOWS_DEPENDENCIES" "audio")
    CHOSEN=$(choose_iris_dep "$AUDIO_LINKS" "Windows" "$DEP_VERSION")
    if [ -n "$CHOSEN" ]; then
      echo "Iris Windows dependency (audio): $CHOSEN"
      update_url_config_key audio IRIS_WIN "$CHOSEN"
    fi
  fi
  
  # Update video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    VIDEO_LINKS=$(filter_links_by_type "$IRIS_WINDOWS_DEPENDENCIES" "video")
    CHOSEN=$(choose_iris_dep "$VIDEO_LINKS" "Windows" "$DEP_VERSION")
    IRIS_WIN_CHOSEN="$CHOSEN"
    if [ -n "$CHOSEN" ]; then
      echo "Iris Windows dependency (video): $CHOSEN"
      update_url_config_key video IRIS_WIN "$CHOSEN"
    fi
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

# Optionally update iOS IRIS URLs in url_config.txt when present in the input
if [ -n "$IRIS_IOS_DEPENDENCIES" ]; then
  # Update audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    AUDIO_LINKS=$(filter_links_by_type "$IRIS_IOS_DEPENDENCIES" "audio")
    CHOSEN_IOS=$(choose_iris_dep "$AUDIO_LINKS" "iOS" "$DEP_VERSION")
    if [ -n "$CHOSEN_IOS" ]; then
      echo "Iris iOS dependency (audio): $CHOSEN_IOS"
      update_url_config_key audio IRIS_IOS "$CHOSEN_IOS"
    fi
  fi
  
  # Update video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    VIDEO_LINKS=$(filter_links_by_type "$IRIS_IOS_DEPENDENCIES" "video")
    CHOSEN_IOS=$(choose_iris_dep "$VIDEO_LINKS" "iOS" "$DEP_VERSION")
    if [ -n "$CHOSEN_IOS" ]; then
      echo "Iris iOS dependency (video): $CHOSEN_IOS"
      update_url_config_key video IRIS_IOS "$CHOSEN_IOS"
    fi
  fi
fi

# Optionally update Android IRIS URLs in url_config.txt when present in the input
if [ -n "$IRIS_ANDROID_DEPENDENCIES" ]; then
  # Update audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    AUDIO_LINKS=$(filter_links_by_type "$IRIS_ANDROID_DEPENDENCIES" "audio")
    CHOSEN_ANDROID=$(choose_iris_dep "$AUDIO_LINKS" "Android" "$DEP_VERSION")
    if [ -n "$CHOSEN_ANDROID" ]; then
      echo "Iris Android dependency (audio): $CHOSEN_ANDROID"
      update_url_config_key audio IRIS_ANDROID "$CHOSEN_ANDROID"
    fi
  fi
  
  # Update video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    VIDEO_LINKS=$(filter_links_by_type "$IRIS_ANDROID_DEPENDENCIES" "video")
    CHOSEN_ANDROID=$(choose_iris_dep "$VIDEO_LINKS" "Android" "$DEP_VERSION")
    if [ -n "$CHOSEN_ANDROID" ]; then
      echo "Iris Android dependency (video): $CHOSEN_ANDROID"
      update_url_config_key video IRIS_ANDROID "$CHOSEN_ANDROID"
    fi
  fi
fi

# Update NATIVE_* in url_config.txt from cdn lists
if [ -n "$IOS_DEPENDENCIES" ]; then
  # Update audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    AUDIO_LINKS=$(filter_links_by_type "$IOS_DEPENDENCIES" "audio")
    NATIVE_IOS=$(choose_native_dep "$AUDIO_LINKS" "iOS")
    if [ -n "$NATIVE_IOS" ]; then
      echo "iOS native dependency (audio): $NATIVE_IOS"
      update_url_config_key audio NATIVE_IOS "$NATIVE_IOS"
    fi
  fi
  
  # Update video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    VIDEO_LINKS=$(filter_links_by_type "$IOS_DEPENDENCIES" "video")
    NATIVE_IOS=$(choose_native_dep "$VIDEO_LINKS" "iOS")
    if [ -n "$NATIVE_IOS" ]; then
      echo "iOS native dependency (video): $NATIVE_IOS"
      update_url_config_key video NATIVE_IOS "$NATIVE_IOS"
    fi
  fi
fi

if [ -n "$ANDROID_DEPENDENCIES" ]; then
  # Update audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    AUDIO_LINKS=$(filter_links_by_type "$ANDROID_DEPENDENCIES" "audio")
    NATIVE_ANDROID=$(choose_native_dep "$AUDIO_LINKS" "Android")
    if [ -n "$NATIVE_ANDROID" ]; then
      echo "Android native dependency (audio): $NATIVE_ANDROID"
      update_url_config_key audio NATIVE_ANDROID "$NATIVE_ANDROID"
    fi
  fi
  
  # Update video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    VIDEO_LINKS=$(filter_links_by_type "$ANDROID_DEPENDENCIES" "video")
    NATIVE_ANDROID=$(choose_native_dep "$VIDEO_LINKS" "Android")
    if [ -n "$NATIVE_ANDROID" ]; then
      echo "Android native dependency (video): $NATIVE_ANDROID"
      update_url_config_key video NATIVE_ANDROID "$NATIVE_ANDROID"
    fi
  fi
fi

# Update SDKVer and increment Build number in >>>audio and/or >>>video sections
if [ -f "$URL_CONFIG_PATH" ]; then
  # Function to increment build number for a specific section
  increment_build_for_section() {
    local section="$1"
    echo "Incrementing Build number for $section in url_config.txt..."
    
    # Read current build number from the section
    BUILD_NUM=0
    FLAG=0
    while IFS= read -r line; do
      case "$line" in
        *">>>$section"*)
          FLAG=1
          ;;
      esac
      if [ "$FLAG" = "1" ]; then
        case "$line" in
          *"<<<end"*)
            FLAG=0
            ;;
        esac
      fi
      
      if [ "$FLAG" = "1" ]; then
        case "$line" in
          *"Build="*)
            BUILD_NUM=$(echo "$line" | sed 's/Build[[:space:]]*=//' | tr -d '\r' | sed 's/^[[:space:]]*//;s/[[:space:]]*$//')
            break
            ;;
        esac
      fi
    done < "$URL_CONFIG_PATH"
    
    # Increment and update
    NEW_BUILD_NUM=$((BUILD_NUM + 1))
    sed -i.bak "/>>>$section/,/<<<end/ s/Build=.*/Build=$NEW_BUILD_NUM/" "$URL_CONFIG_PATH"
    rm -f "$URL_CONFIG_PATH.bak"
    
    echo "Build number for $section updated: $BUILD_NUM -> $NEW_BUILD_NUM"
  }
  
  # Update SDKVer if we have a version
  if [ -n "$DEP_VERSION" ]; then
    # Extract major.minor.patch from version (e.g., "4.5.2.3" -> "4.5.2")
    SDK_VER=$(echo "$DEP_VERSION" | cut -d. -f1,2,3)
    
    if [ "$UPDATE_AUDIO" -eq 1 ]; then
      echo "Updating SDKVer for audio section to: $SDK_VER"
      update_url_config_key audio SDKVer "$SDK_VER"
    fi
    
    if [ "$UPDATE_VIDEO" -eq 1 ]; then
      echo "Updating SDKVer for video section to: $SDK_VER"
      update_url_config_key video SDKVer "$SDK_VER"
    fi
  fi
  
  # Increment audio section if needed
  if [ "$UPDATE_AUDIO" -eq 1 ]; then
    increment_build_for_section "audio"
  fi
  
  # Increment video section if needed
  if [ "$UPDATE_VIDEO" -eq 1 ]; then
    increment_build_for_section "video"
  fi
fi

echo "Dependencies update completed successfully!"
