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
#  $9 build_package
#  "true"/"false"
#
#  $10 build_Wayang
#  "true"/"false"
#
#  $11 wayang_branch (The branch name of Wayang unitydemo)
#
#============================================================================== 

set -ex

SDK_TYPE=$1
API_KEY=$3
DEMO_BRANCH=$2
PLUGIN_NAME="Agora-RTC-Plugin"
ROOT_DIR=$(pwd)/Agora-C_Sharp-RTC-SDK
CI_DIR=$(pwd)/Agora-C_Sharp-RTC-SDK/CI
UNITY_DIR=/Applications/Unity/Hub/Editor/$4/Unity.app/Contents/MacOS
BUILD_PACKAGE=$9
BUILD_WAYANG=${10}
WAYANG_BRANCH=${11}

#--------------------------------------
# Prepare all the required resources
#--------------------------------------
echo "[Unity CI] start preparing resources"
cd "$CI_DIR" || exit 1
mkdir temp
./download_plugin.sh "$SDK_TYPE" "$API_KEY" "$5" "$6" "$7" "$8"
ANDROID_SRC_PATH="$CI_DIR"/temp/android/iris_4.0.1_RTM_Android
ANDROID_RTC_PATH="$CI_DIR"/temp/android/iris_4.0.1_DCG_Android
IOS_SRC_PATH=$CI_DIR/temp/ios/iris_4.0.1_RTM_iOS
IOS_RTC_PATH=$CI_DIR/temp/ios/iris_4.0.1_DCG_iOS
MAC_SRC_PATH="$CI_DIR"/temp/mac/iris_*
WIN_SRC_PATH="$CI_DIR"/temp/win
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
cp -r "$CI_DIR"/temp/Agora-Unity-Quickstart/API-Example-Unity/README.md "$PLUGIN_PATH"/API-Example/
cp -r "$CI_DIR"/temp/Agora-Unity-Quickstart/API-Example-Unity/README.zh.md "$PLUGIN_PATH"/API-Example/
cp -r "$CI_DIR"/temp/Agora-Unity-Quickstart/API-Example-Unity/Assets/StreamingAssets "$CI_DIR"/project/Assets/


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
cp -r "$ROOT_DIR"/Unity/Tools "$PLUGIN_PATH"/Agora-Unity-RTC-SDK
cp -r "$ROOT_DIR"/Code "$PLUGIN_PATH"/Agora-Unity-RTC-SDK
rm -rf "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Code/agorartc.csproj

# Copy Plugins
#mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/iOS
#mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/macOS
#mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86_64
#mkdir "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86

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
cp $ANDROID_SRC_PATH/RTM/Agora_*/rtc/sdk/*.jar "$ANDROID_DST_PATH"/libs

if [ "$SDK_TYPE" == "video" ]; then
cp $ANDROID_SRC_PATH/RTM/Agora_*/rtc/sdk/*.aar "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android
fi

cp -r $ANDROID_SRC_PATH/RTM/Agora_*/rtc/sdk/arm64-v8a "$ANDROID_DST_PATH"/libs
cp $ANDROID_RTC_PATH/ALL_ARCHITECTURE/Release/arm64-v8a/libAgoraRtcWrapper.so "$ANDROID_DST_PATH"/libs/arm64-v8a
cp $ANDROID_SRC_PATH/arm64-v8a/Release/libAgoraRtmWrapper.so "$ANDROID_DST_PATH"/libs/arm64-v8a

cp -r $ANDROID_SRC_PATH/RTM/Agora_*/rtc/sdk/armeabi-v7a "$ANDROID_DST_PATH"/libs
cp $ANDROID_RTC_PATH/ALL_ARCHITECTURE/Release/armeabi-v7a/libAgoraRtcWrapper.so "$ANDROID_DST_PATH"/libs/armeabi-v7a
cp $ANDROID_SRC_PATH/armeabi-v7a/Release/libAgoraRtmWrapper.so "$ANDROID_DST_PATH"/libs/armeabi-v7a

cp -r $ANDROID_SRC_PATH/RTM/Agora_*/rtc/sdk/x86 "$ANDROID_DST_PATH"/libs
cp $ANDROID_RTC_PATH/ALL_ARCHITECTURE/Release/x86/libAgoraRtcWrapper.so "$ANDROID_DST_PATH"/libs/x86
cp $ANDROID_SRC_PATH/x86/Release/libAgoraRtmWrapper.so "$ANDROID_DST_PATH"/libs/x86

cp -r $ANDROID_SRC_PATH/RTM/Agora_*/rtc/sdk/x86_64 "$ANDROID_DST_PATH"/libs
cp $ANDROID_RTC_PATH/ALL_ARCHITECTURE/Release/x86_64/libAgoraRtcWrapper.so "$ANDROID_DST_PATH"/libs/x86_64
cp $ANDROID_SRC_PATH/x86_64/Release/libAgoraRtmWrapper.so "$ANDROID_DST_PATH"/libs/x86_64

# iOS
echo "[Unity CI] copying iOS ..."
IOS_DST_PATH="$PLUGIN_PATH/Agora-Unity-RTC-SDK/Plugins/iOS"
cp -PRf $IOS_SRC_PATH/RTM/Agora_*/libs/*.xcframework/ios-arm64_armv7/*.framework "$IOS_DST_PATH"
cp -PRf $IOS_SRC_PATH/ALL_ARCHITECTURE/Release/*.framework "$IOS_DST_PATH"
cp -PRf $IOS_RTC_PATH/ALL_ARCHITECTURE/Release/*.framework "$IOS_DST_PATH"

# macOS
echo "[Unity CI] copying macOS ..."
MAC_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/macOS
cp -PRf $MAC_SRC_PATH/MAC/Release/Release/*.bundle "$MAC_DST_PATH"

# Windows x86-64
echo "[Unity CI] copying Windows x86-64 ..."
WIN64_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86_64
cp $WIN_SRC_PATH/iris_4.0.1_RTM_Windows/RTM/Agora_*/sdk/x86_64/*.dll "$WIN64_DST_PATH"
cp $WIN_SRC_PATH/iris_4.0.1_RTM_Windows/x64/Release/Release/*.dll "$WIN64_DST_PATH"
cp $WIN_SRC_PATH/iris_4.0.1_DCG_Windows/x64/Release/*.dll "$WIN64_DST_PATH"

# Windows x86
echo "[Unity CI] copying Windows x86 ..."
WIN32_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86
cp $WIN_SRC_PATH/iris_4.0.1_RTM_Windows/RTM/Agora_*/sdk/x86/*.dll "$WIN32_DST_PATH"
cp $WIN_SRC_PATH/iris_4.0.1_RTM_Windows/Win32/Release/Release/*.dll "$WIN32_DST_PATH"
cp $WIN_SRC_PATH/iris_4.0.1_DCG_Windows/Win32/Release/*.dll "$WIN32_DST_PATH"

echo "[Unity CI] finish copying files"

#--------------------------------------
# Export Package
#--------------------------------------
$UNITY_DIR/Unity -quit -batchmode -nographics -openProjects  "$CI_DIR/project" -exportPackage "Assets" "$PLUGIN_NAME.unitypackage"

#--------------------------------------
# Copy to $CI_DIR/output
#--------------------------------------
mkdir "$CI_DIR"/output
cp "$CI_DIR"/project/*.unitypackage "$CI_DIR"/output || exit 1


if [ $BUILD_PACKAGE == "true" ] 
then
    echo "[Unity CI] Build package. It may take a while ..."
    mkdir "$CI_DIR"/temp/Agora-Unity-Quickstart/API-Example-Unity/Assets/Agora-RTC-Plugin
    cp -r "$PLUGIN_PATH"/Agora-Unity-RTC-SDK "$CI_DIR"/temp/Agora-Unity-Quickstart/API-Example-Unity/Assets/Agora-RTC-Plugin || exit 1
    $UNITY_DIR/Unity -quit -batchmode -nographics -projectPath "$CI_DIR/temp/Agora-Unity-Quickstart/API-Example-Unity" -executeMethod CommandBuild.BuildAll
    cp -r "$CI_DIR"/temp/Agora-Unity-Quickstart/Build "$CI_DIR"/output || exit 1
    echo "[Unity CI] Build package finish"
else 
    echo "[Unity CI] Do not build package"
fi


if [ $BUILD_WAYANG == "true" ]
then 
    echo "[Unity CI] Build Wayang, It may take a while ..."
    cd temp
    git clone -b $WAYANG_BRANCH ssh://git@git.agoralab.co/apps/unitydemo.git
    mkdir "$CI_DIR"/temp/unitydemo/Assets/Agora-RTC-Plugin
    cp -r "$PLUGIN_PATH"/Agora-Unity-RTC-SDK "$CI_DIR"/temp/unitydemo/Assets/Agora-RTC-Plugin || exit 1
    $UNITY_DIR/Unity -quit -batchmode -nographics -projectPath "$CI_DIR/temp/unitydemo" -executeMethod Wayang.CommandBuild.BuildAll
    cp -r "$CI_DIR"/temp/unitydemo/Wayang "$CI_DIR"/output || exit 1
    echo "[Unity CI] Build Wayang finish"
else
    echo "[Unity CI] Do not build wayang"
fi

rm -rf "$CI_DIR"/project "$CI_DIR"/temp

exit 0
