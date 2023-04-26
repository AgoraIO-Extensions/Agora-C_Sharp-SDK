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
IOS_SRC_PATH=$CI_DIR/temp/ios
MAC_SRC_PATH="$CI_DIR"/temp/mac
WIN_SRC_PATH="$CI_DIR"/temp/win
ANDROID_SRC_PATH="$CI_DIR"/temp/android
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
cp $ANDROID_SRC_PATH/iris_*_DCG_Android/DCG/Agora_*/rtc/sdk/*.jar "$ANDROID_DST_PATH"/libs

if [ "$SDK_TYPE" == "video" ]; then
cp $ANDROID_SRC_PATH/iris_*_DCG_Android/DCG/Agora_*/rtc/sdk/*.aar "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android
fi

for so_path in "arm64-v8a" "armeabi-v7a" "x86" "x86_64"
do
    cp -r $ANDROID_SRC_PATH/DCG/Agora_*/rtc/sdk/${so_path} "$ANDROID_DST_PATH"/libs
    #copy libAgoraIrisEngine.so libAgoraRtcWrapper.so libAgoraRtmWrapper.so
    cp $ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/${so_path}/*.so "$ANDROID_DST_PATH"/libs/${so_path}  
done

#copy AgoraRtcWrapper.jar AgoraIrisEngine.jar AgoraRtmWrapper.jar
cp $ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/*.jar "$ANDROID_DST_PATH"/libs


# iOS
echo "[Unity CI] copying iOS ..."
IOS_DST_PATH="$PLUGIN_PATH/Agora-Unity-RTC-SDK/Plugins/iOS"
cp -PRf $IOS_SRC_PATH/DCG/Agora_*/libs/*.xcframework/ios-arm64_armv7/*.framework "$IOS_DST_PATH"
cp -PRf $IOS_SRC_PATH/ALL_ARCHITECTURE/Release/*.framework "$IOS_DST_PATH"


# macOS
echo "[Unity CI] copying macOS ..."
MAC_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/macOS
cp -PRf $MAC_SRC_PATH/MAC/Release/AgoraIrisEngineUnity.bundle "$MAC_DST_PATH"
cp -PRf $MAC_SRC_PATH/MAC/Release/AgoraRtcWrapperUnity.bundle "$MAC_DST_PATH"

# Windows x86-64
echo "[Unity CI] copying Windows x86-64 ..."
WIN64_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86_64
cp $WIN_SRC_PATH/x64/Release/*.dll "$WIN64_DST_PATH"
cp $WIN_SRC_PATH/DCG/Agora_*/sdk/x86_64/*.dll "$WIN64_DST_PATH"

# Windows x86
echo "[Unity CI] copying Windows x86 ..."
WIN32_DST_PATH="$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/x86
cp $WIN_SRC_PATH/Win32/Release/*.dll "$WIN32_DST_PATH"
cp $WIN_SRC_PATH/DCG/Agora_*/sdk/x86/*.dll "$WIN32_DST_PATH"

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
