#!/bin/bash
#============================================================================== 
#   download_plugin.sh :  download all the plugins from URLs
#
#    If there is no URL input, the URLs will be set from url_config.txt.
#   
#  $1 SDK Type:
#	 video - download video plugins
#	 audio - download audio plugins
#
#  $2 API Key
#
#  $3 macOS plugin URL (optional)
#
#  $4 Windows plugin URL (optional)
#
#  $5 iOS plugin URL (optional)
#
#  $6 Android plugin URL (optional)
#
#============================================================================== 

SDK_TYPE=$1
API_KEY=$2
CUR_DIR=$(pwd)

#--------------------------------------
# Set URL
#--------------------------------------
FLAG=0
while read -r line; do
    if [[ $line == *">>>$SDK_TYPE"* ]]; then
        FLAG=1
    fi
    if [[ $line == *"<<<end"* ]]; then
        FLAG=0
    fi

    if [[ $FLAG == 1 ]]; then
        case $line in
            *"IOS"*)
                if [ -z "$5" ]; then
                    IOS_URL=$(echo "$line" | sed 's/IOS[[:space:]]*=//;s/^[[:space:]]*//')
                else
                    IOS_URL=$5
                fi
                IOS_URL=$(echo "$IOS_URL" | sed 's/https:\/\/artifactory./https:\/\/artifactory-api.bj2./')
                ;;
            *"ANDROID"*)
                if [ -z "$6" ]; then
                    ANDROID_URL=$(echo "$line" | sed 's/ANDROID[[:space:]]*=//;s/^[[:space:]]*//')
                else
                    ANDROID_URL=$6
                fi
                ANDROID_URL=$(echo "$ANDROID_URL" | sed 's/https:\/\/artifactory./https:\/\/artifactory-api.bj2./')
                ;;
            *"MAC"*)
                if [ -z "$3" ]; then
                    MAC_URL=$(echo "$line" | sed 's/MAC[[:space:]]*=//;s/^[[:space:]]*//')
                else
                    MAC_URL=$3
                fi
                MAC_URL=$(echo "$MAC_URL" | sed 's/https:\/\/artifactory./https:\/\/artifactory-api.bj2./')
                ;;
            *"WIN"*)
                if [ -z "$4" ]; then
                    WIN_URL=$(echo "$line" | sed 's/WIN[[:space:]]*=//;s/^[[:space:]]*//')
                else
                    WIN_URL=$4
                fi
                WIN_URL=$(echo "$WIN_URL" | sed 's/https:\/\/artifactory./https:\/\/artifactory-api.bj2./')
                ;;
        esac
    fi
done < "$CUR_DIR/url_config.txt"


#--------------------------------------
# Download plugins
#--------------------------------------
echo "IOS URL: $IOS_URL"
echo "ANDROID URL: $ANDROID_URL"
echo "MAC URL: $MAC_URL"
echo "WIN URL: $WIN_URL"
HEADER="X-JFrog-Art-Api: $API_KEY"
mkdir "$CUR_DIR"/temp/ios "$CUR_DIR"/temp/android "$CUR_DIR"/temp/mac "$CUR_DIR"/temp/win || exit 1
wget -q --header="$HEADER" "$IOS_URL" -P "$CUR_DIR"/temp/ios || exit 1
wget -q --header="$HEADER" "$ANDROID_URL" -P "$CUR_DIR"/temp/android || exit 1
wget -q --header="$HEADER" "$MAC_URL" -P "$CUR_DIR"/temp/mac || exit 1
wget -q --header="$HEADER" "$WIN_URL" -P "$CUR_DIR"/temp/win || exit 1


#--------------------------------------
# Extract plugins
#--------------------------------------
unzip -d "$CUR_DIR"/temp/ios/ "$CUR_DIR"/temp/ios/iris_*.zip || exit 1
unzip -d "$CUR_DIR"/temp/android/ "$CUR_DIR"/temp/android/iris_*.zip || exit 1
unzip -d "$CUR_DIR"/temp/mac/ "$CUR_DIR"/temp/mac/iris_*.zip || exit 1
unzip -d "$CUR_DIR"/temp/win/ "$CUR_DIR"/temp/win/iris_*.zip || exit 1

#--------------------------------------
# Delete zip files
#--------------------------------------
rm "$CUR_DIR"/temp/ios/iris_*.zip "$CUR_DIR"/temp/android/iris_*.zip "$CUR_DIR"/temp/mac/iris_*.zip "$CUR_DIR"/temp/win/iris_*.zip

exit 0