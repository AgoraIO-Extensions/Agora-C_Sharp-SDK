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
echo source_root: $source_root$
echo output: /tmp/jenkins/${project}_out
echo build_date: $build_date
echo build_time: $build_time
echo release_version: $release_version
echo short_version: $short_version
echo pwd: $(pwd)
echo UNITY_VERSION: $UNITY_VERSION
echo SDK_VERSION: $SDK_VERSION
echo IRIS_MAC_URL: $IRIS_MAC_URL
echo IRIS_WIN_URL: $IRIS_WIN_URL
echo IRIS_ANDROID_URL: $IRIS_ANDROID_URL
echo IRIS_IOS_URL: $IRIS_IOS_URL
echo VISIONOS_URL: $VISIONOS_URL
echo NATIVE_MAC_URL: $NATIVE_MAC_URL
echo NATIVE_WIN_URL: $NATIVE_WIN_URL
echo NATIVE_ANDROID_URL: $NATIVE_ANDROID_URL
echo NATIVE_IOS_URL: $NATIVE_IOS_URL
echo TYPE: $TYPE
echo RTC: $RTC
echo RTM: $RTM
echo NUMBER_UID: $NUMBER_UID
echo STRING_UID: $STRING_UID
echo SUFFIX: $SUFFIX
echo robot_key: $robot_key
echo SPLIT_VISIONOS: $SPLIT_VISIONOS
echo EXCLUDE_LIST_IN_DESKTOP $EXCLUDE_LIST_IN_DESKTOP
echo EXCLUDE_LIST_IN_MOBILE $EXCLUDE_LIST_IN_MOBILE
echo BRAND $BRAND

delete_files() {
    local path=$1
    local exclude_list=$2

    IFS=',' read -ra files <<<"$exclude_list"
    for file in "${files[@]}"; do
        for item in $(find "$path" -name "$file"); do
            # 第二步：检查每个匹配项的类型并删除它
            if [ -f "$item" ]; then
                # 如果是文件，直接删除
                rm "$item"
            elif [ -d "$item" ]; then
                # 如果是目录，递归删除
                rm -rf "$item"
            fi
        done
    done
}

decode_uri() {
    local uri="$1"
    # 使用 sed 命令将 %2B 替换为 +，将 %20 替换为空格
    local decoded_uri=$(echo "$uri" | sed 's/%2B/+/g' | sed 's/%20/ /g')
    echo "$decoded_uri"
}

if [ "$RTC" == "true" ]; then
    PLUGIN_NAME="${BRAND}-RTC-Plugin"
    PLUGIN_CODE_NAME="${BRAND}-Unity-RTC-SDK"
else
    PLUGIN_NAME="${BRAND}-RTM-Plugin"
    PLUGIN_CODE_NAME="${BRAND}-Unity-RTM-SDK"
fi

if [ "$RTC" == "true" ] && [ "$RTM" == "true" ]; then
    NATIVE_FOLDER="ALL"
    SUB_PATH="rtc"
elif [ "$RTC" == "true" ]; then
    NATIVE_FOLDER="DCG"
    SUB_PATH="rtc"
elif [ "$RTM" == "true" ]; then
    NATIVE_FOLDER="RTM"
    SUB_PATH="rtm"
fi

echo PLUGIN_NAME $PLUGIN_NAME
echo PLUGIN_CODE_NAME $PLUGIN_CODE_NAME
ROOT=$(pwd)
ROOT_DIR=$(pwd)/Agora-C_Sharp-RTC-SDK

echo "agora-c_sharp-sdk git status:"
git status

cd ../agora-unity-quickstart
echo "agora-unity-quickstart git status:"
git status

cd $ROOT

if [ -d "./tempDir" ]; then
    rm -rf "./tempDir"
fi

mkdir tempDir || exit 1
cd tempDir

echo "[Unity CI] finish preparing resources"

UNITY_DIR=/Applications/Unity/Hub/Editor/${UNITY_VERSION}/Unity.app/Contents/MacOS

#--------------------------------------
# Create a Unity project
#--------------------------------------
echo "[Unity CI] start creating unity project"
$UNITY_DIR/Unity -quit -batchmode -nographics -createProject "project"
echo "[Unity CI] finish creating unity project"

# make allowUnsafeCode true
python3 ${ROOT}/ci/build/set_allowUnsafeCode_true.py ${ROOT}/tempDir/project

#--------------------------------------
# Copy files to the Unity project
#--------------------------------------
echo "[Unity CI] start copying files"
mkdir ./project/Assets/"$PLUGIN_NAME"
PLUGIN_PATH="./project/Assets/$PLUGIN_NAME"

# Copy API-Example
echo "[Unity CI] copying API-Example ..."
if [ "$TYPE" == "VOICE" ]; then
    FULL="false"
    VOICE="true"
else
    FULL="true"
    VOICE="false"
fi

python3 ../../agora-unity-quickstart/ci/build/remove_example_by_macor.py $ROOT/../agora-unity-quickstart/API-Example-Unity/Assets ${RTC} ${RTM} ${NUMBER_UID} ${STRING_UID} ${FULL} ${VOICE}
cp -r ../../agora-unity-quickstart/API-Example-Unity/Assets/API-Example "$PLUGIN_PATH"
cp -r ../../agora-unity-quickstart/API-Example-Unity/README.md $PLUGIN_PATH/API-Example/
cp -r ../../agora-unity-quickstart/API-Example-Unity/README.zh.md $PLUGIN_PATH/API-Example/

# Copy SDK
echo "[Unity CI] copying scripts ..."
python3 $ROOT/ci/build/remove_code_by_macor.py "$ROOT_DIR" ${RTC} ${RTM} ${NUMBER_UID} ${STRING_UID} ${FULL} ${VOICE}
mkdir "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
cp -r "$ROOT_DIR"/Unity/Editor "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
if [ "$TYPE" == "VOICE" ]; then
    POST_PROCESS_SCRIPT_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Editor/BL_BuildPostProcess.cs
    sed -i '' 's/var cameraPermission = "NSCameraUsageDescription";//' "$POST_PROCESS_SCRIPT_PATH"
    sed -i '' 's/rootDic.SetString(cameraPermission, "Video need to use camera");//' "$POST_PROCESS_SCRIPT_PATH"
    perl -0777 -pi -e 's|Start Tag for video SDK only[\s\S]*End Tag||g' "$POST_PROCESS_SCRIPT_PATH"
fi

cp -r "$ROOT_DIR"/Unity/Plugins "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
cp -r "$ROOT_DIR"/Unity/Tools "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
cp -r "$ROOT_DIR"/Code "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
cp -r "$ROOT_DIR"/Resources "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"
rm -rf "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Code/*.csproj

# Android
if [ "$IRIS_ANDROID_URL" != "" ]; then
    if [ "$NATIVE_ANDROID_URL" == "" ]; then
        ehco "NATIVE_ANDROID_URL is null"
        exit 1
    fi

    if [[ "$IRIS_ANDROID_URL" != *"Standalone"* ]]; then
        echo "IRIS_ANDROID_URL does not contain 'Standalone'"
        exit 1
    fi

    echo "[Unity CI] copying Android ..."

    #download iris
    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${IRIS_ANDROID_URL}
    temp_zip_name=$(basename "$IRIS_ANDROID_URL")
    7za x ./${temp_zip_name} || exit 1
    IRIS_ANDROID_SRC_PATH="./iris_*_Android"
    rm ./${temp_zip_name}

    #download native
    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${NATIVE_ANDROID_URL}
    temp_zip_name=$(basename "$NATIVE_ANDROID_URL")
    7za x ./${temp_zip_name} || exit 1
    NATIVE_ANDROID_SRC_PATH="./*_Native_SDK_for_Android_*"
    rm ./${temp_zip_name}

    if [ "$RTC" == "true" ]; then
        ANDROID_PATH="AgoraRtcEngineKit.plugin"
    else
        ANDROID_PATH="AgoraRtmEngineKit.plugin"
    fi

    mkdir "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/"$ANDROID_PATH"
    ANDROID_DST_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/"$ANDROID_PATH"
    mv "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/project.properties "$ANDROID_DST_PATH"

    if [ "$RTC" == "false" ]; then
        mv "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AndroidManifest-rtm.xml "$ANDROID_DST_PATH"/AndroidManifest.xml
    elif [ "$TYPE" == "VOICE" ]; then
        mv "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AndroidManifest-audio.xml "$ANDROID_DST_PATH"/AndroidManifest.xml
    elif [ "$TYPE" == "FULL" ]; then
        mv "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AndroidManifest-video.xml "$ANDROID_DST_PATH"/AndroidManifest.xml
    fi
    rm -r "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android/AndroidManifest-*.xml

    mkdir "$ANDROID_DST_PATH"/libs

    #copy native
    cp ${NATIVE_ANDROID_SRC_PATH}/$SUB_PATH/sdk/*.jar "$ANDROID_DST_PATH"/libs

    if [ -f ${NATIVE_ANDROID_SRC_PATH}/$SUB_PATH/sdk/*.aar ]; then
        cp ${NATIVE_ANDROID_SRC_PATH}/$SUB_PATH/sdk/*.aar "$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/Android
    fi

    cp -r ${NATIVE_ANDROID_SRC_PATH}/$SUB_PATH/sdk/x86 "$ANDROID_DST_PATH"/libs
    cp -r ${NATIVE_ANDROID_SRC_PATH}/$SUB_PATH/sdk/x86_64 "$ANDROID_DST_PATH"/libs
    cp -r ${NATIVE_ANDROID_SRC_PATH}/$SUB_PATH/sdk/armeabi-v7a "$ANDROID_DST_PATH"/libs
    cp -r ${NATIVE_ANDROID_SRC_PATH}/$SUB_PATH/sdk/arm64-v8a "$ANDROID_DST_PATH"/libs

    #copy iris
    cp $IRIS_ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/arm64-v8a/libAgora*Wrapper.so "$ANDROID_DST_PATH"/libs/arm64-v8a
    delete_files "$ANDROID_DST_PATH"/libs/arm64-v8a "$EXCLUDE_LIST_IN_MOBILE"

    cp $IRIS_ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/armeabi-v7a/libAgora*Wrapper.so "$ANDROID_DST_PATH"/libs/armeabi-v7a
    delete_files "$ANDROID_DST_PATH"/libs/armeabi-v7a "$EXCLUDE_LIST_IN_MOBILE"

    cp $IRIS_ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/x86/libAgora*Wrapper.so "$ANDROID_DST_PATH"/libs/x86
    delete_files "$ANDROID_DST_PATH"/libs/x86 "$EXCLUDE_LIST_IN_MOBILE"

    cp $IRIS_ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/x86_64/libAgora*Wrapper.so "$ANDROID_DST_PATH"/libs/x86_64
    delete_files "$ANDROID_DST_PATH"/libs/x86_64 "$EXCLUDE_LIST_IN_MOBILE"

    cp $IRIS_ANDROID_SRC_PATH/ALL_ARCHITECTURE/Release/*.jar "$ANDROID_DST_PATH"/libs

    rm -rf ${IRIS_ANDROID_SRC_PATH}
    rm -rf ${NATIVE_ANDROID_SRC_PATH}
fi

# iOS
if [ "$IRIS_IOS_URL" != "" ]; then

    if [ "$NATIVE_IOS_URL" == "" ]; then
        ehco "NATIVE_IOS_URL is null"
        exit 1
    fi

    if [[ "$IRIS_IOS_URL" != *"Standalone"* ]]; then
        echo "IRIS_IOS_URL does not contain 'Standalone'"
        exit 1
    fi

    echo "[Unity CI] copying iOS ..."

    #download iris ios
    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${IRIS_IOS_URL}
    temp_zip_name=$(basename "$IRIS_IOS_URL")
    7za x ./${temp_zip_name} || exit 1
    IRIS_IOS_SRC_PATH="./iris_*_iOS"
    rm ./${temp_zip_name}

    #download native ios
    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${NATIVE_IOS_URL}
    temp_zip_name=$(basename "$NATIVE_IOS_URL")
    7za x ./${temp_zip_name} || exit 1
    rm ./${temp_zip_name}

    if [ -d ./*_Native_SDK_for_iOS_* ]; then
        NATIVE_IOS_SRC_PATH="./*_Native_SDK_for_iOS_*"
    elif [ -d ./*_Native_SDK_for_APPLE_* ]; then
        NATIVE_IOS_SRC_PATH="./*_Native_SDK_for_APPLE_*"
    fi

    IOS_DST_PATH="$PLUGIN_PATH/"$PLUGIN_CODE_NAME"/Plugins/iOS"

    #remove x86_64 from iris ios framework
    files=$(ls $IRIS_IOS_SRC_PATH/ALL_ARCHITECTURE/Release)
    for filename in $files; do
        extension=${filename##*.}
        basename=${filename%.*}
        if [ "$extension" == "framework" ]; then
            lipo -remove x86_64 $IRIS_IOS_SRC_PATH/ALL_ARCHITECTURE/Release/$filename/$basename -o $IRIS_IOS_SRC_PATH/ALL_ARCHITECTURE/Release/$filename/$basename
        fi
    done

    #copy iris ios
    cp -PRf $IRIS_IOS_SRC_PATH/ALL_ARCHITECTURE/Release/*.framework "$IOS_DST_PATH"
    #copy native ios
    cp -PRf $NATIVE_IOS_SRC_PATH/libs/*.xcframework/ios-arm64_armv7/*.framework "$IOS_DST_PATH"
    #remove framework
    delete_files "$IOS_DST_PATH" "$EXCLUDE_LIST_IN_MOBILE"

    files=$(ls $IOS_DST_PATH)
    for filename in $files; do
        cp -f "$ROOT_DIR"/Unity/Plugins/iOS/ios.meta $IOS_DST_PATH/${filename}.meta
    done

    rm $IOS_DST_PATH/ios.meta
    rm -rf ${IRIS_IOS_SRC_PATH}
    rm -rf ${NATIVE_IOS_SRC_PATH}

fi

# Vision OS
if [ "$VISIONOS_URL" != "" ]; then
    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${VISIONOS_URL}
    7za x ./iris_*_xrOS_*.zip || exit 1
    VISIONOS_SRC_PATH="./iris_*_xrOS"
    rm ./iris_*_xrOS_*.zip
    VISIONOS_DST_PATH="$PLUGIN_PATH/"$PLUGIN_CODE_NAME"/Plugins/visionOS"
    cp -PRf $VISIONOS_SRC_PATH/$NATIVE_FOLDER/Agora_*/libs/*.xcframework "$VISIONOS_DST_PATH"
    cp -PRf $VISIONOS_SRC_PATH/ALL_ARCHITECTURE/Release/*.xcframework "$VISIONOS_DST_PATH"

    files=$(ls $VISIONOS_DST_PATH)
    for filename in $files; do
        extension=${filename##*.}
        basename=${filename%.*}
        if [ "$extension" == "xcframework" ]; then

            # check if a directory exists
            if [ -d $VISIONOS_DST_PATH/$basename.xcframework/ios-arm64_armv7 ]; then
                rm -rf $VISIONOS_DST_PATH/$basename.xcframework/ios-arm64_armv7
            fi

            if [ -d $VISIONOS_DST_PATH/$basename.xcframework/ios-arm64_x86_64-simulator ]; then
                rm -rf $VISIONOS_DST_PATH/$basename.xcframework/ios-arm64_x86_64-simulator
            fi

            cp -f "$ROOT_DIR"/Unity/Plugins/visionOS/devices.meta $VISIONOS_DST_PATH/$basename.xcframework/xros-arm64/$basename.framework.meta
            cp -f "$ROOT_DIR"/Unity/Plugins/visionOS/simulator.meta $VISIONOS_DST_PATH/$basename.xcframework/xros-arm64_x86_64-simulator/$basename.framework.meta
        fi
    done

    rm $VISIONOS_DST_PATH/devices.meta
    rm $VISIONOS_DST_PATH/simulator.meta
    delete_files "$VISIONOS_DST_PATH" "$EXCLUDE_LIST_IN_MOBILE"
fi

# macOS
if [ "$IRIS_MAC_URL" != "" ]; then
    if [ "$NATIVE_MAC_URL" == "" ]; then
        echo "NATIVE_MAC_URL is null"
        exit 1
    fi

    if [[ "$IRIS_MAC_URL" != *"_Unity_"* ]]; then
        echo "IRIS_MAC_URL does not contain 'Unity'"
        exit 1
    fi

    echo "[Unity CI] copying macOS ..."
    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${IRIS_MAC_URL}
    temp_zip_name=$(basename "$IRIS_MAC_URL")
    7za x ./${temp_zip_name} || exit 1
    IRIS_MAC_SRC_PATH="./iris_*_Mac"
    rm ./${temp_zip_name}

    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${NATIVE_MAC_URL}
    temp_zip_name=$(basename "$NATIVE_MAC_URL")
    7za x ./${temp_zip_name} || exit 1
    rm ./${temp_zip_name}

    if [ -d ./*_Native_SDK_for_Mac_* ]; then
        NATIVE_MAC_SRC_PATH="./*_Native_SDK_for_Mac_*"
    elif [ -d ./*_Native_SDK_for_APPLE_* ]; then
        NATIVE_MAC_SRC_PATH="./*_Native_SDK_for_APPLE_*"
    fi

    MAC_DST_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/macOS

    bundle_name=$(ls $IRIS_MAC_SRC_PATH/MAC/Release/)

    #copy iris
    cp -PRf $IRIS_MAC_SRC_PATH/MAC/Release/$bundle_name "$MAC_DST_PATH"
    rm -rf "$MAC_DST_PATH/$bundle_name/Contents/Frameworks/*.framework"

    #copy native
    cp -r $NATIVE_MAC_SRC_PATH/libs/*.xcframework/macos-arm64_x86_64/*.framework $MAC_DST_PATH/$bundle_name/Contents/Frameworks

    delete_files "$MAC_DST_PATH"/$bundle_name/Contents/Frameworks "$EXCLUDE_LIST_IN_DESKTOP"

    rm -rf ${IRIS_MAC_SRC_PATH}
    rm -rf ${NATIVE_MAC_SRC_PATH}
fi

#Windows
if [ "$IRIS_WIN_URL" != "" ]; then

    if [ "$NATIVE_WIN_URL" == "" ]; then
        echo "NATIVE_WIN_URL is null"
        exit 1
    fi

    if [[ "$IRIS_WIN_URL" != *"Standalone"* ]]; then
        echo "IRIS_WIN_URL does not contain 'Standalone'"
        exit 1
    fi

    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${IRIS_WIN_URL}
    temp_zip_name=$(basename "$IRIS_WIN_URL")
    7za x ./${temp_zip_name} || exit 1
    IRIS_WIN_SRC_PATH="./iris_*_Windows"
    rm ./${temp_zip_name}

    python3 ${WORKSPACE}/artifactory_utils.py --action=download_file --file=${NATIVE_WIN_URL}
    temp_zip_name=$(basename "$NATIVE_WIN_URL")
    ls ./
    7za x ./${temp_zip_name} || exit 1
    NATIVE_WIN_SRC_PATH="./*_Native_SDK_for_Windows_*"
    rm ./${temp_zip_name}

    WIN64_DST_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/x86_64
    WIN32_DST_PATH="$PLUGIN_PATH"/"$PLUGIN_CODE_NAME"/Plugins/x86

    #copy iris
    cp $IRIS_WIN_SRC_PATH/x64/Release/*.dll "$WIN64_DST_PATH"
    cp $IRIS_WIN_SRC_PATH/Win32/Release/*.dll "$WIN32_DST_PATH"

    #copy native
    cp $NATIVE_WIN_SRC_PATH/sdk/x86_64/*.dll "$WIN64_DST_PATH"
    cp $NATIVE_WIN_SRC_PATH/sdk/x86/*.dll "$WIN32_DST_PATH"

    #remove dll
    delete_files "$WIN64_DST_PATH" "$EXCLUDE_LIST_IN_DESKTOP"
    delete_files "$WIN32_DST_PATH" "$EXCLUDE_LIST_IN_DESKTOP"

    #create dll.meta
    files=$(ls $WIN64_DST_PATH)
    for filename in $files; do
        extension=${filename##*.}
        basename=${filename%.*}
        if [ "$extension" == "dll" ]; then
            cp "$ROOT_DIR"/Unity/Plugins/x86_64/dll.meta $WIN64_DST_PATH/${filename}.meta
        fi

    done

    files=$(ls $WIN32_DST_PATH)
    for filename in $files; do
        extension=${filename##*.}
        basename=${filename%.*}
        if [ "$extension" == "dll" ]; then
            cp "$ROOT_DIR"/Unity/Plugins/x86/dll.meta $WIN32_DST_PATH/${filename}.meta
        fi

    done

    rm -rf ${IRIS_WIN_SRC_PATH}
    rm -rf ${NATIVE_WIN_SRC_PATH}
fi

echo "[Unity CI] finish copying files"

#--------------------------------------
# Export Package
#--------------------------------------

# API-Example replace guids
if [ "$RTC" == "false" ]; then
    $UNITY_DIR/Unity -quit -batchmode -nographics -projectPath "./project" -executeMethod Agora_RTC_Plugin.API_Example.PackageTools.ReplaceGUIDs
    echo "replace guids for rtm finish"
    rm -r $PLUGIN_PATH/API-Example/Editor/PackageTools.cs
fi

# split vision os package as sub package
if [ "$VISIONOS_URL" != "" -a "$SPLIT_VISIONOS" == "true" ]; then
    $UNITY_DIR/Unity -quit -batchmode -nographics -openProjects "./project" -exportPackage "Assets/$PLUGIN_NAME/$PLUGIN_CODE_NAME/Plugins/visionOS" "$PLUGIN_NAME-VisionOS.unitypackage" || exit 1
    ZIP_FILE="Unknow"
    if [ "$RTC" == "true" ]; then
        ZIP_FILE=Agora_Unity_RTC_VisionOS_SDK_${SDK_VERSION}_${TYPE}_${build_date}_${BUILD_NUMBER}_${SUFFIX}.zip
    else
        ZIP_FILE=Agora_Unity_RTM_VisionOS_SDK_${SDK_VERSION}_${build_date}_${BUILD_NUMBER}_${SUFFIX}.zip
    fi
    7za a ./${ZIP_FILE} ./project/"$PLUGIN_NAME-VisionOS.unitypackage"

    download_file=$(python3 ${WORKSPACE}/artifactory_utils.py --action=upload_file --file=./$ZIP_FILE --project)
    payload1='{
            "msgtype": "text",
            "text": {
                "content": "Unity SDK 【'${SDK_VERSION}'】 打包:\n'${download_file}'"
            }
        }'

    # 发送 POST 请求
    curl -k -X POST -H "Content-Type: application/json; charset=UTF-8" \
        -d "$payload1" \
        "https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key=$robot_key"

    rm -rf $VISIONOS_DST_PATH
fi

$UNITY_DIR/Unity -quit -batchmode -nographics -openProjects "./project" -exportPackage "Assets" "$PLUGIN_NAME.unitypackage" || exit 1
ZIP_FILE="Unknow"
if [ "$RTC" == "true" ]; then
    ZIP_FILE="$BRAND"_Unity_RTC_SDK_${SDK_VERSION}_${TYPE}_${build_date}_${BUILD_NUMBER}_${SUFFIX}.zip
else
    ZIP_FILE="$BRAND"_Unity_RTM_SDK_${SDK_VERSION}_${build_date}_${BUILD_NUMBER}_${SUFFIX}.zip
fi
7za a ./${ZIP_FILE} ./project/"$PLUGIN_NAME.unitypackage"

download_file=$(python3 ${WORKSPACE}/artifactory_utils.py --action=upload_file --file=./$ZIP_FILE --project)
payload1='{
            "msgtype": "text",
            "text": {
                "content": "Unity SDK 【'${SDK_VERSION}'】 打包:\n'${download_file}'"
            }
        }'

# 发送 POST 请求
curl -k -X POST -H "Content-Type: application/json; charset=UTF-8" \
    -d "$payload1" \
    "https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key=$robot_key"

cd ..
rm -rf ./tempDir
