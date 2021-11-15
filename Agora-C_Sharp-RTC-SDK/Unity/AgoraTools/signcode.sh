#!/bin/bash
################################################################################
# Notarize help script - Code signing, for Unity SDK Iris releases
#
# Prerequisites:
#
#  Required envirnmental variable "$SIGNATURE"
#
#  possible command line:
#     (export SIGNATURE="my apple developer identity (xxxxx)"; ./codesign.sh MyApp.app)
#
#  To find available signatures, use
#	security find-identity -v -p codesigning
################################################################################

if [ "$1" == "" ] || [ $# -lt 1 ]; then
   echo "Please enter the app name!"
   exit 1
fi

if [ "" == "$SIGNATURE" ]; then
    echo "You must provide signature for codesign!"
    echo possible command line:
    echo '  (export SIGNATURE="my apple developer identity (xxxxx)";' $0 $1
    echo To find available signatures, use
    echo '  security find-identity -v -p codesigning'
    security find-identity -v -p codesigning
    exit 2
fi

ENTITLEMENT="App.entitlements"
APP="$1"

BUNDLE="AgoraRtcWrapperUnity.bundle"

UNITY_FRAMEWORKS="$APP/Contents/Frameworks"
AGORA_FRAMEWORKS="$APP/Contents/PlugIns/$BUNDLE/Contents/MacOS/Resources"
AGORA_CLIB="$APP/Contents/Plugins/$BUNDLE/Contents/MacOS/AgoraRtcWrapperUnity"
PROJ_BIN="$APP/Contents/MacOS"

# with option the executable can't be run before notarization
OPTIONS="-o runtime"

if [ ! -e $ENTITLEMENT ]; then
    echo "$ENTITLEMENT is not found! quit..."
    exit 1
fi

function CodeSign {
    target="$1"
    echo "codesigning $target"
    codesign $OPTIONS -f -v --timestamp --deep -s "$SIGNATURE" --entitlements $ENTITLEMENT $target
}

#set -x
chmod -R a+xr $APP
#read $b

echo ""
echo "==== frameworks"
for framework in $UNITY_FRAMEWORKS/*; do
    CodeSign $framework
done
for framework in $AGORA_FRAMEWORKS/*; do
    CodeSign $framework
done

echo "==== bin "
for bin in $PROJ_BIN/*; do
    CodeSign "$bin"
done

CodeSign $AGORA_CLIB
CodeSign $APP

# verify
echo ""
echo "Code sign is done. next, verify..."
codesign -v --strict --deep --verbose=2 $APP

# after notarize
# spctl --assess -vv TestMacSign.app
# After this, run the build, it should still runs
#set +x
