#!/usr/bin/env bash
set -e
set -x

MY_PATH=$(realpath $(dirname "$0"))
PROJECT_ROOT=$(realpath ${MY_PATH}/..)

echo "MY_PATH: ${MY_PATH}"
echo "PROJECT_ROOT: ${PROJECT_ROOT}"

cd ${MY_PATH}

# rtc
npm exec terra -- run \
    --config ${MY_PATH}/rtc.yaml \
    --output-dir=${PROJECT_ROOT}

dotnet format ${PROJECT_ROOT}/Agora-C_Sharp_RTC-SDK_UT/Agora_C_Sharp_SDK_UT.sln
yarn doc
