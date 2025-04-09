#!/usr/bin/env bash
set -e
set -x

MY_PATH=$(realpath $(dirname "$0"))
PROJECT_ROOT=$(realpath ${MY_PATH}/..)

pushd ${MY_PATH}

rm -rf .terra
rm -rf node_modules
rm -rf package-lock.json
rm -rf yarn.lock
yarn

popd
