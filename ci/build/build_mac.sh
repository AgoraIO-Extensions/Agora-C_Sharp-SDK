# --------------------------------------------------------------------------------------------------------------------------
# =====================================
# ========== Guidelines ===============
# =====================================
#
# -------------------------------------
# ---- Common Environment Variable ----
# -------------------------------------
# ${Package_Publish} (boolean): Indicates whether it is build package process, e.g. If you want to get one CI SDK package.
# ${Clean_Clone} (boolean): Indicates whether it is clean build. If true, CI will clean ${output} for each build process.
# ${is_tag_fetch} (boolean): If true, git checkout will work as tag fetch mode.
# ${is_official_build} (boolean): Indicates whether it is official build release.
# ${arch} (string): Indicates build arch set in build pipeline.
# ${short_version} (string): CI auto generated short version string.
# ${release_version} (string): CI auto generated version string.
# ${build_date} (string(yyyyMMdd)): Build date generated by CI.
# ${build_timestamp} (string (yyyyMMdd_hhmm)): Build timestamp generated by CI.
# ${platform} (string): Build platform generated by CI.
# ${BUILD_NUMBER} (string): Build number generated by CI.
# ${WORKSPACE} (string): Working dir generated by CI.
#
# -------------------------------------
# ------- Job Custom Parameters -------
# -------------------------------------
# If you added one custom parameter via rehoboam website, e.g. extra_args.
# You could use $extra_args to get its value.
#
# -------------------------------------
# ------------- Input -----------------
# -------------------------------------
# ${source_root}: Source root which checkout the source code.
# ${WORKSPACE}: project owned private workspace.
#
# -------------------------------------
# ------------- Output ----------------
# -------------------------------------
# Generally, we should put the output files into ${WORKSPACE}
# 1. for pull request: Output files should be zipped to test.zip, and then copy to ${WORKSPACE}.
# 2. for pull request (options): Output static xml should be static_${platform}.xml, and then copy to ${WORKSPACE}.
# 3. for others: Output files should be zipped to anything_you_want.zip, and then copy it to {WORKSPACE}.
#
# -------------------------------------
# --------- Avaliable Tools -----------
# -------------------------------------
# Compressing & Decompressing: 7za a, 7za x
#
# -------------------------------------
# ----------- Test Related ------------
# -------------------------------------
# PR build, zip test related to test.zip
# Package build, zip package related to package.zip
#
# -------------------------------------
# ------ Publish to artifactory -------
# -------------------------------------
# [Download] artifacts from artifactory:
# python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=ARTIFACTORY_URL
#
# [Upload] artifacts to artifactory:
# python3 ${WORKSPACE}/artifactory_utils.py --action=upload_file --file=FILEPATTERN --project
# Sample Code:
# python3 ${WORKSPACE}/artifactory_utils.py --action=upload_file --file=*.zip --project
#
# [Upload] artifacts folder to artifactory
# python3 ${WORKSPACE}/artifactory_utils.py --action=upload_file --file=FILEPATTERN --project --with_folder
# Sample Code:
# python3 ${WORKSPACE}/artifactory_utils.py --action=upload_file --file=./folder --project --with_folder
#
# ========== Guidelines End=============
# --------------------------------------------------------------------------------------------------------------------------

set -ex

echo Package_Publish: $Package_Publish
echo is_tag_fetch: $is_tag_fetch
echo arch: $arch
echo source_root: %source_root%
echo output: /tmp/jenkins/${project}_out
echo build_date: $build_date
echo build_time: $build_time
echo release_version: $release_version
echo short_version: $short_version
echo pwd: `pwd`
echo UNITY_VERSION: $UNITY_VERSION
echo SDK_VERSION: $SDK_VERSION
echo MAC_URL: $MAC_URL
echo WIN_URL: $WIN_URL
echo ANDROID_URL: $ANDROID_URL
echo IOS_URL: $IOS_URL
echo TYPE: $TYPE
echo RTC: $RTC
echo RTM: $RTM
echo DEMO_BRANCH: $DEMO_BRANCH

if [ "$RTC" == "true" ]
then
    PLUGIN_NAME="Agora-RTC-Plugin"
    PLUGIN_CODE_NAME="Agora-Unity-RTC-SDK"
else
    PLUGIN_NAME="Agora-RTM-Plugin"
    PLUGIN_CODE_NAME="Agora-Unity-RTM-SDK"
fi
echo PLUGIN_NAME $PLUGIN_NAME
echo PLUGIN_CODE_NAME $PLUGIN_CODE_NAME

ROOT=`pwd`
ROOT_DIR=$(pwd)/Agora-C_Sharp-RTC-SDK

if [ -d "./tempDir"]
then
    rm -rf "./tempDir"
fi

mkdir tempDir || exit 1
cd tempDir


# git clone -b "$DEMO_BRANCH" ssh://git@git.agoralab.co/agio/agora-unity-quickstart.git
git clone -b "$DEMO_BRANCH" https://gitee.com/agoraio-community/Agora-Unity-Quickstart.git
echo "[Unity CI] finish preparing resources"

UNITY_DIR=/Applications/Unity/Hub/Editor/${UNITY_VERSION}/Unity.app/Contents/MacOS

#--------------------------------------
# Create a Unity project
#--------------------------------------
echo "[Unity CI] start creating unity project"
$UNITY_DIR/Unity -quit -batchmode -nographics -createProject "project"
echo "[Unity CI] finish creating unity project"

ls ./
#--------------------------------------
# Copy files to the Unity project
#--------------------------------------
echo "[Unity CI] start copying files"
mkdir ./project/Assets/"$PLUGIN_NAME"
PLUGIN_PATH="./project/Assets/$PLUGIN_NAME"

# Copy API-Example
echo "[Unity CI] copying API-Example ..."
cp -r ./Agora-Unity-Quickstart/API-Example-Unity/Assets/API-Example "$PLUGIN_PATH"
ls $PLUGIN_PATH
ls $PLUGIN_PATH/API-Example/
cp -r ./Agora-Unity-Quickstart/API-Example-Unity/README.md $PLUGIN_PATH/API-Example/
cp -r ./Agora-Unity-Quickstart/API-Example-Unity/README.zh.md $PLUGIN_PATH/API-Example/


# Copy SDK
echo "[Unity CI] copying scripts ..."
mkdir "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
cp -r "$ROOT_DIR"/Unity/Editor "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
if [ "$TYPE" == "VOICE" ]; then
    POST_PROCESS_SCRIPT_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Editor/BL_BuildPostProcess.cs
    sed -i '' 's/var cameraPermission = "NSCameraUsageDescription";//' "$POST_PROCESS_SCRIPT_PATH"
    sed -i '' 's/rootDic.SetString(cameraPermission, "Video need to use camera");//' "$POST_PROCESS_SCRIPT_PATH"
    perl -0777 -pi -e 's|Start Tag for video SDK only[\s\S]*End Tag||g' "$POST_PROCESS_SCRIPT_PATH"
fi

mkdir "$ROOT_DIR"/Unity/Plugins/iOS
cp -r "$ROOT_DIR"/Unity/Plugins "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
cp -r "$ROOT_DIR"/Unity/Tools "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
cp -r "$ROOT_DIR"/Code "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
cp -r "$ROOT_DIR"/Resources "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
rm -rf "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Code/agorartc.csproj


python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${MAC_URL}
unzip -d ./ ./iris_*_Mac_*.zip || exit 1
python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${WIN_URL}
unzip -d ./ ./iris_*_Windows_*.zip || exit 1
python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${IOS_URL}
unzip -d ./ ./iris_*_iOS_*.zip || exit 1
python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${ANDROID_URL}
unzip -d ./ ./iris_*_Android_*.zip || exit 1

ANDROID_SRC_PATH="./iris_*_Android"
IOS_SRC_PATH="./iris_*_iOS"
MAC_SRC_PATH="./iris_*_Mac"
WIN_SRC_PATH="./iris_*_Windows"

# Android
echo "[Unity CI] copying Android ..."
mkdir "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AgoraRtcEngineKit.plugin
ANDROID_DST_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AgoraRtcEngineKit.plugin
mv "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/project.properties "$ANDROID_DST_PATH"

if [ "$TYPE" == "VOICE" ]; then
    mv "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AndroidManifest-audio.xml "$ANDROID_DST_PATH"/AndroidManifest.xml
    rm -r "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AndroidManifest-video.xml
elif [ "$TYPE" == "FULL" ]; then
    mv "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AndroidManifest-video.xml "$ANDROID_DST_PATH"/AndroidManifest.xml
    rm -r "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AndroidManifest-audio.xml
fi

mkdir "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/DCG/Agora_*/rtc/sdk/*.jar "$ANDROID_DST_PATH"/libs

if [ "$TYPE" == "FULL" ]; then
cp $ANDROID_SRC_PATH/DCG/Agora_*/rtc/sdk/*.aar "$PLUGIN_PATH"/Agora-Unity-RTC-SDK/Plugins/Android
fi

cp -r $ANDROID_SRC_PATH/DCG/Agora_*/rtc/sdk/arm64-v8a "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/arm64-v8a/libAgoraRtcWrapper.so "$ANDROID_DST_PATH"/libs/arm64-v8a

cp -r $ANDROID_SRC_PATH/DCG/Agora_*/rtc/sdk/armeabi-v7a "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/armeabi-v7a/libAgoraRtcWrapper.so "$ANDROID_DST_PATH"/libs/armeabi-v7a

cp -r $ANDROID_SRC_PATH/DCG/Agora_*/rtc/sdk/x86 "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/x86/libAgoraRtcWrapper.so "$ANDROID_DST_PATH"/libs/x86

cp -r $ANDROID_SRC_PATH/DCG/Agora_*/rtc/sdk/x86_64 "$ANDROID_DST_PATH"/libs
cp $ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/x86_64/libAgoraRtcWrapper.so "$ANDROID_DST_PATH"/libs/x86_64

# iOS
echo "[Unity CI] copying iOS ..."
IOS_DST_PATH="$PLUGIN_PATH/"$PLUGIN_CODE_NAME"/Plugins/iOS"
cp -PRf $IOS_SRC_PATH/DCG/Agora_*/libs/*.xcframework/ios-arm64_armv7/*.framework "$IOS_DST_PATH"
cp -PRf $IOS_SRC_PATH/ALL_ARCHITECTURE/Release/*.framework "$IOS_DST_PATH"

# macOS
echo "[Unity CI] copying macOS ..."
MAC_DST_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/macOS
cp -PRf $MAC_SRC_PATH/MAC/Release/*.bundle "$MAC_DST_PATH"

# Windows x86-64
echo "[Unity CI] copying Windows x86-64 ..."
WIN64_DST_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/x86_64
cp $WIN_SRC_PATH/DCG/Agora_*/sdk/x86_64/*.dll "$WIN64_DST_PATH"
cp $WIN_SRC_PATH/DCG/Agora_*/sdk/x86_64/*.lib "$WIN64_DST_PATH"
cp $WIN_SRC_PATH/x64/Release/*.dll "$WIN64_DST_PATH"
cp $WIN_SRC_PATH/x64/Release/*.lib "$WIN64_DST_PATH"

# Windows x86
echo "[Unity CI] copying Windows x86 ..."
WIN32_DST_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/x86
cp $WIN_SRC_PATH/DCG/Agora_*/sdk/x86/*.dll "$WIN32_DST_PATH"
cp $WIN_SRC_PATH/DCG/Agora_*/sdk/x86/*.lib "$WIN32_DST_PATH"
cp $WIN_SRC_PATH/Win32/Release/*.dll "$WIN32_DST_PATH"
cp $WIN_SRC_PATH/Win32/Release/*.lib "$WIN32_DST_PATH"

echo "[Unity CI] finish copying files"

#--------------------------------------
# Export Package
#--------------------------------------
if [ "$SDK_TYPE" == "audio" ]; then
    python3 ${ROOT}/ci/build/remove_video_case.py "$PLUGIN_PATH"/API-Example
fi

//todo RTM or RTC clear code and meta file

$UNITY_DIR/Unity -quit -batchmode -nographics -openProjects  "./project" -exportPackage "Assets" "$PLUGIN_NAME.unitypackage" || exit 1
ZIP_FILE="$PLUGIN_CODE_NAME"_${SDK_VERSION}_${TYPE}_${build_time}.zip
7za a ./${ZIP_FILE} ./project/"$PLUGIN_NAME.unitypackage

python3 ${WORKSPACE}/artifactory_utils.py --action=upload_file --file=./{ZIP_FILE} --project

cd ..
rm -rf ./tempDir