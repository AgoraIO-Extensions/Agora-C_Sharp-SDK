#!/usr/bin/env bash

AGORA_LIB_NAME=$1
DEBUG_LIB_NAME=$2
FULLY_QUALIFIED_NAME=$3

MY_PATH=$(realpath $(dirname "$0"))
PROJECT_ROOT=$(realpath ${MY_PATH}/..)

UT_CSPROJ_PATH=${PROJECT_ROOT}/Agora-C_Sharp_RTC-SDK_UT/ut/ut.csproj

if [ -f "$UT_CSPROJ_PATH" ]; then
    sed -i '' 's/<TargetFramework>.*<\/TargetFramework>/<TargetFramework>net7.0<\/TargetFramework>/g' "$UT_CSPROJ_PATH"
    echo "TargetFramework has been updated to net7.0"
else
    echo "Error: ut.csproj file not found: $UT_CSPROJ_PATH"
    exit 1
fi

AGORA_RTC_CS=${PROJECT_ROOT}/Agora-C_Sharp-RTC-SDK/Code/Rtc/Impl/Private/Native/AgoraRtcApiNative.cs
AGORA_RTM_CS=${PROJECT_ROOT}/Agora-C_Sharp-RTC-SDK/Code/Rtm/Internal/Impl/Private/Native/AgoraRtmApiNative.cs

if [ -f "$AGORA_RTC_CS" ]; then
    perl -i -pe 's|"AgoraRtcWrapper"|"'$AGORA_LIB_NAME'"|g' "$AGORA_RTC_CS"
    # 设置变量以便后续使用
    AGORA_RTC_LIB_NAME=$AGORA_LIB_NAME
    echo "AgoraRtcLibName in AgoraRtcApiNative.cs has been updated to $AGORA_RTC_LIB_NAME"
else
    echo "Error: AgoraRtcApiNative.cs file not found: $AGORA_RTC_CS"
    exit 1
fi

if [ -f "$AGORA_RTM_CS" ]; then
    perl -i -pe 's|"AgoraRtmWrapper"|"'$AGORA_LIB_NAME'"|g' "$AGORA_RTM_CS"
    echo "AgoraRtmLibName in AgoraRtmApiNative.cs has been updated to $DEBUG_LIB_NAME"
else
    echo "Error: AgoraRtmApiNative.cs file not found: $AGORA_RTM_CS"
    exit 1
fi

DLL_CS=${PROJECT_ROOT}/Agora-C_Sharp_RTC-SDK_UT/ut/Tool/DLLHelper.cs
if [ -f "$DLL_CS" ]; then
    perl -i -pe 's|"libName"|"'$DEBUG_LIB_NAME'"|g' "$DLL_CS"
    echo "DebugLibName in DLLHelper.cs has been updated to $DEBUG_LIB_NAME"
else
    echo "Error: DLLHelper.cs file not found: $DLL_CS"
    exit 1
fi

echo "All files have been updated successfully"

dotnet test ${UT_CSPROJ_PATH} --filter FullyQualifiedName~${FULLY_QUALIFIED_NAME} --logger "trx;LogFileName=${PROJECT_ROOT}/testResults.xml"
ls ${PROJECT_ROOT}
