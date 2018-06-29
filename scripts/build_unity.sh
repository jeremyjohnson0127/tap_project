#!/bin/bash

. "$(dirname "$0")"/common.sh

UNITY_IOS_LOG_PATH="$PROJECT_ROOT"/buildIOS.log

echo "Attempting to build project for iOS"
"$UNITY_PATH" \
  -batchmode \
  -silent-crashes \
  -username "$UNITY_USERNAME" \
  -password "$UNITY_PASSWORD" \
  -logFile "$UNITY_IOS_LOG_PATH" \
  -projectPath "$PROJECT_ROOT" \
  -executeMethod CommandLineBuild.iOSBuild \
  -quit

cp "$UNITY_IOS_LOG_PATH" $CIRCLE_ARTIFACTS/unity_build.log

echo "returning the license"

"$UNITY_PATH" \
  -batchmode \
  -returnlicense \
  -silent-crashes \
  -username "$UNITY_USERNAME" \
  -password "$UNITY_PASSWORD" \
  -logFile "$UNITY_IOS_LOG_PATH" \
  -projectPath "$PROJECT_ROOT" \
  -quit

cp "$UNITY_IOS_LOG_PATH" $CIRCLE_ARTIFACTS/unity_return_key.log
#
cd Builds/iOS
# xcodebuild \
#   -project Unity-iPhone.xcodeproj \
#   -scheme Unity-iPhone \
#   clean \
#   build \
#   CONFIGURATION_BUILD_DIR=$CIRCLE_ARTIFACTS/build \
#   DEVELOPMENT_TEAM=$XCODE_TEAM_ID

xcodebuild archive \
   -project Unity-iPhone.xcodeproj \
   -scheme Unity-iPhone \
   -configuration Unity-iPhone \
   -derivedDataPath ./build \
   -archivePath ./build/Products/MyApp.xcarchive

xcodebuild -exportArchive \
 -archivePath ./build/Products/MyApp.xcarchive \
 -exportOptionsPlist ./export/exportOptions-Enterprise.plist \
 -exportPath ./build/Products/IPA