#!/bin/bash
#============================================================================== 
#   package.sh :  pack Agora Unity RTC SDK into a unity package
#   
#  $1 SDK Type:
#  video/audio
#
#  $2 The branch name of API-Example
#
#  $3 API Key
#
#  $4 Unity Editor Version
#
#  $5 iris_url_mac (optional)
#
#  $6 iris_url_windows (optional)
#
#  $7 iris_url_ios (optional)
#
#  $8 iris_url_android (optional)
#
#============================================================================== 

SDK_TYPE=$1
API_KEY=$3
DEMO_BRANCH=$2
PLUGIN_NAME="Agora-Plugin"
ROOT_DIR=$(pwd)/Agora-C_Sharp-RTC-SDK
CI_DIR=$(pwd)/Agora-C_Sharp-RTC-SDK/CI
UNITY_DIR=/Applications/Unity/Hub/Editor/$4/Unity.app/Contents/MacOS

#--------------------------------------
# Prepare all the required resources
#--------------------------------------
echo "[Unity CI] start preparing resources"
cd "$CI_DIR" || exit 1
mkdir temp
./download_plugin.sh "$SDK_TYPE" "$API_KEY" "$5" "$6" "$7" "$8"
ANDROID_SRC_PATH="$CI_DIR"/temp/android/iris_*
IOS_SRC_PATH=$CI_DIR/temp/ios/iris_*
MAC_SRC_PATH="$CI_DIR"/temp/mac/iris_*
WIN_SRC_PATH="$CI_DIR"/temp/win/iris_*
cd temp || exit 1
git clone -b "$DEMO_BRANCH" ssh://git@git.agoralab.co/agio/agora-unity-quickstart.git
cd "$CI_DIR" || exit 1
echo "[Unity CI] finish preparing resources"

#--------------------------------------
# Create a Unity project
#--------------------------------------
echo "[Unity CI] start creating unity project"
$UNITY_DIR/Unity -quit -batchmode -nographics -createProject "project"
echo "[Unity CI] finish creating unity project"

#--------------------------------------
# Copy files to the Unity project
#--------------------------------------
echo "[Unity CI] start copying files"
mkdir project/Assets/"$PLUGIN_NAME"
PLUGIN_PATH="$CI_DIR/project/Assets/$PLUGIN_NAME"

# Copy API-Example
echo "[Unity CI] copying API-Example ..."
cp -r "$CI_DIR"/temp/Agora-Unity-Quickstart/API-Example-Unity/Assets/API-Example "$PLUGIN_PATH"

# Copy SDK
echo "[Unity CI] copying scripts ..."
mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK
cp -r "$ROOT_DIR"/Unity/Editor "$PLUGIN_PATH"/Agora-Unity-RTC-SDK
if [ "$SDK_TYPE" == "audio" ]; then
    POST_PROCESS_SCRIPT_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Editor/BL_BuildPostProcess.cs
    sed -i '' 's/var cameraPermission = "NSCameraUsageDescription";//' "$POST_PROCESS_SCRIPT_PATH"
    sed -i '' 's/rootDic.SetString(cameraPermission, "Video need to use camera");//' "$POST_PROCESS_SCRIPT_PATH"
    perl -0777 -pi -e 's|Start Tag for video SDK only[\s\S]*End Tag||g' "$POST_PROCESS_SCRIPT_PATH"
fi
cp -r "$ROOT_DIR"/Unity/Plugins "$PLUGIN_PATH"/Agora-Unity-RTC-SDK
cp -r "$ROOT_DIR"/Unity/AgoraTools "$PLUGIN_PATH"/Agora-Unity-RTC-SDK
cp -r "$ROOT_DIR"/agorartc "$PLUGIN_PATH"/Agora-Unity-RTC-SDK
rm -rf "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/agorartc/agorartc.csproj

# Copy Plugins
mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/iOS
mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/macOS
mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86_64
mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86

# Android
echo "[Unity CI] copying Android ..."
mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android/AgoraRtcEngineKit.plugin

ANDROID_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android/AgoraRtcEngineKit.plugin

mv "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android/project.properties "$ANDROID_DST_PATH"

if [ "$SDK_TYPE" == "audio" ]; then
    mv "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android/AndroidManifest-audio.xml "$ANDROID_DST_PATH"/AndroidManifest.xml
    rm -r "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android/AndroidManifest-video.xml
elif [ "$SDK_TYPE" == "video" ]; then
    mv "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android/AndroidManifest-video.xml "$ANDROID_DST_PATH"/AndroidManifest.xml
    rm -r "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android/AndroidManifest-audio.xml
fi

mkdir "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/RTC/Agora_*/libs/*.jar "$ANDROID_DST_PATH"/libs

cp -r $ANDROID_SRC_PATH/RTC/Agora_*/libs/arm64-v8a "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/arm64-v8a/Release/*.so "$ANDROID_DST_PATH"/libs/arm64-v8a

cp -r $ANDROID_SRC_PATH/RTC/Agora_*/libs/armeabi-v7a "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/armeabi-v7a/Release/*.so "$ANDROID_DST_PATH"/libs/armeabi-v7a

cp -r $ANDROID_SRC_PATH/RTC/Agora_*/libs/x86 "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/x86/Release/*.so "$ANDROID_DST_PATH"/libs/x86

# iOS
echo "[Unity CI] copying iOS ..."
IOS_DST_PATH="$PLUGIN_PATH/Agora-Unity-RTC-SDK/Plugins/iOS"
cp -PRf $IOS_SRC_PATH/RTC/Agora_*/libs/ALL_ARCHITECTURE/*.framework "$IOS_DST_PATH"
cp -PRf $IOS_SRC_PATH/ALL_ARCHITECTURE/Release/*.framework "$IOS_DST_PATH"

# macOS
echo "[Unity CI] copying macOS ..."
MAC_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/macOS
cp -PRf $MAC_SRC_PATH/MAC/Release/*.bundle "$MAC_DST_PATH"

# Windows x86-64
echo "[Unity CI] copying Windows x86-64 ..."
WIN64_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86_64
cp $WIN_SRC_PATH/RTC/Agora_*/libs/x86_64/*.dll "$WIN64_DST_PATH"
cp $WIN_SRC_PATH/x64/Release/*.dll "$WIN64_DST_PATH"
cp $WIN_SRC_PATH/x64/Release/*.exe "$WIN64_DST_PATH"

# Windows x86
echo "[Unity CI] copying Windows x86 ..."
WIN32_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86
cp $WIN_SRC_PATH/RTC/Agora_*/libs/x86/*.dll "$WIN32_DST_PATH"
cp $WIN_SRC_PATH/Win32/Release/*.dll "$WIN32_DST_PATH"
cp $WIN_SRC_PATH/Win32/Release/*.exe "$WIN32_DST_PATH"

echo "[Unity CI] finish copying files"

#--------------------------------------
# Export Package
#--------------------------------------
$UNITY_DIR/Unity -quit -batchmode -nographics -openProjects  "$CI_DIR/project" -exportPackage "Assets/$PLUGIN_NAME" "$PLUGIN_NAME.unitypackage"

#--------------------------------------
# Copy to $CI_DIR/output
#--------------------------------------
mkdir "$CI_DIR"/output
cp "$CI_DIR"/project/*.unitypackage "$CI_DIR"/output || exit 1
rm -rf "$CI_DIR"/project "$CI_DIR"/temp

exit 0
