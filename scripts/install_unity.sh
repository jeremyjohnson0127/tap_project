#!/bin/bash

die() {
    out "$*"
    exit 1
}

out() {
    echo -e $*
}

start() {
    out "Starting: $*"
}

end() {
    out "Finished: $*"
}

PROJECT_ROOT: $PWD/tap_project
UNITY_DOWNLOAD_DIR: $PROJECT_ROOT/unity
UNITY_PKG_LOCATION: $UNITY_DOWNLOAD_DIR/Unity.pkg
UNITY_PKG_URL: https://download.unity3d.com/download_unity/5d30cf096e79/MacEditorInstaller/Unity-2017.1.1f1.pkg
IOS_PKG_LOCATION: $UNITY_DOWNLOAD_DIR/Unity-iOS.pkg
IOS_PKG_URL: http://netstorage.unity3d.com/unity/5d30cf096e79/MacEditorTargetInstaller/UnitySetup-iOS-Support-for-Editor.pkg
UNITY_CIRCLE_XML_DIR: $CIRCLE_TEST_REPORTS/Unity
UNITY_CIRCLE_XML_OUT_PATH: $UNITY_CIRCLE_XML_DIR/junit.xml

if [[ ! -e $UNITY_PKG_LOCATION ]] ; then
    echo $UNITY_DOWNLOAD_DIR
    echo $UNITY_PKG_LOCATION
    echo $PWD
    out "Downloading Unity to $UNITY_DOWNLOAD_DIR"
    out "Downloading from {$UNITY_PKG_URL}"
    mkdir -p "$UNITY_DOWNLOAD_DIR"
    curl -o "$UNITY_PKG_LOCATION" "$UNITY_PKG_URL"
    out "Finished Downloading Unity"
fi

if [[ ! -e $IOS_PKG_LOCATION ]] ; then
    out "Downloading iOS Editor Support to $UNITY_DOWNLOAD_DIR"
    out "Downloading from {$IOS_PKG_URL}"
    curl -o "$IOS_PKG_LOCATION" "$IOS_PKG_URL"
    out "Finished Downloading iOS Editor Support"
fi

out "Start Install Unity"
sudo installer -dumplog -package "$UNITY_PKG_LOCATION" -target /
INSTALL_UNITY_RESULT=$?

if [[ $INSTALL_UNITY_RESULT = 0 ]] ; then
    out "Finished Install Unity"
else
    die "Unable to install Unity"
fi

out "Start Install iOS Editor Support"
sudo installer -dumplog -package "$IOS_PKG_LOCATION" -target /
INSTALL_IOS_RESULT=$?

if [[ $INSTALL_IOS_RESULT = 0 ]] ; then
    out "Finished Install iOS Editor Support"
else
    die "Unable to install iOS Editor Support"
fi