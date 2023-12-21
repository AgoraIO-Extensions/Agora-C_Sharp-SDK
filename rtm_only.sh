#!/bin/bash

SCRIPT_PATH=$(dirname "$(readlink -f "$0")")
echo "shell path: $SCRIPT_PATH"
python3 $SCRIPT_PATH/ci/build/remove_code_by_macor.py "$SCRIPT_PATH/Agora-C_Sharp-RTC-SDK" false true false true true false
