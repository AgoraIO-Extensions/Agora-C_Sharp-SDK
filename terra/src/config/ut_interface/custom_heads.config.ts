import { CustomHead } from "../../type_definition";

export const customHeads: CustomHead[] = [
    {
        name: "ILyricInfo",
        is_hide: true
    },
    {
        name: "ISentence",
        is_hide: true
    },
    {
        name: "IWord",
        is_hide: true
    },
    {
        name: "IVideoFrameMetaInfo",
        is_hide: true
    },
    {
        name: "IAgoraParameter",
        is_hide: true,
    },
    {
        name: "IAudioDeviceCollection",
        is_hide: true,
    },
    {
        name: "IContainer",
        is_hide: true,
    },
    {
        name: "IEngineBase",
        is_hide: true,
    },
    {
        name: "ILogWriter",
        is_hide: true,
    },
    {
        name: "IMediaPlayerSource",
        is_hide: true,
    },
    {
        name: "IMediaStreamingSource",
        is_hide: true,
    },
    {
        name: "IRtcEngineEventHandlerEx",
        is_hide: true
    },
    {
        name: "IScreenCaptureSourceList",
        is_hide: true
    },
    {
        name: "IString",
        is_hide: true
    },
    {
        name: "IVideoDeviceCollection",
        is_hide: true
    },
    {
        name: "IIterator",
        is_hide: true
    },
    {
        name: "IRhythmPlayer",
        is_hide: true
    },
    {
        name: "IAudioDeviceManager",
        custom_methods: [
            "public abstract DeviceInfo[] EnumeratePlaybackDevices();",
            "public abstract DeviceInfo[] EnumerateRecordingDevices();",
            "public abstract int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceName);",
            "public abstract int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName);",
            "public abstract int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName);",
            "public abstract int GetRecordingDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName);"
        ],
        hide_methods: [
            "enumeratePlaybackDevices",
            "enumerateRecordingDevices",
            "release"
        ]
    },
    {
        name: "ILocalSpatialAudioEngine",
        custom_methods: [
            "public abstract void Dispose();"
        ],
        hide_methods: [
            "release",
            "updateRemotePosition",
            "updateRemotePositionEx",
            "removeRemotePosition",
            "removeRemotePositionEx",
            "updateSelfPositionEx",
            "setMaxAudioRecvCount",
            "setAudioRecvRange",
            "setDistanceUnit",
            "updateSelfPosition",
            "updatePlayerPositionInfo",
            "setRemoteAudioAttenuation",
            "setZones",
            "setPlayerAttenuation"
        ]
    },
    {
        name: "IMediaPlayer",
        custom_methods: [
            "public abstract void Dispose();",
            "public abstract int GetId();",
            "public abstract int InitEventHandler(IMediaPlayerSourceObserver engineEventHandler);"
        ],
        hide_methods: [
            "release",
            "initialize",
            "getMediaPlayerId",
            "registerVideoFrameObserver",
            "unregisterVideoFrameObserver",
            "registerPlayerSourceObserver",
            "unregisterPlayerSourceObserver",
            "openWithMediaSource",
            "registerAudioFrameObserver",
            "unregisterAudioFrameObserver",
            "registerMediaPlayerAudioSpectrumObserver",
            "setMediaRecorderObserver",
            "openWithCustomSource"
        ]
    },
    {
        name: "IMetadataObserver",
        methods_with_macros: [
            {
                name: "getMaxMetadataSize",
                macro: "!(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)"
            },
            {
                name: "onReadyToSendMetadata",
                macro: "!(UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID)"
            },
        ]
    },
    {
        name: "IRtcEngine",
        merge_nodes: [
            {
                name: "IMediaEngine",
                is_hide: true
            }
        ],
        custom_methods: [
            "public abstract void Dispose(bool sync = false);",
            "public abstract int SetParameters(string key, object value);",
            "public abstract int GetNativeHandler(ref IntPtr nativeHandler);",
            "public abstract int UnRegisterAudioEncodedFrameObserver();",
            "public abstract int InitEventHandler(IRtcEngineEventHandler engineEventHandler);",
            "public abstract IAudioDeviceManager GetAudioDeviceManager();",
            "public abstract IVideoDeviceManager GetVideoDeviceManager();",
            "public abstract IMusicContentCenter GetMusicContentCenter();",
            "public abstract IMediaPlayerCacheManager GetMediaPlayerCacheManager();",
            "public abstract ILocalSpatialAudioEngine GetLocalSpatialAudioEngine();",
            "public abstract IH265Transcoder GetH265Transcoder();",
            "#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS \n public abstract int SetMaxMetadataSize(int size); \n #endif",
            "#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS \n public abstract int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type); \n #endif",
            "#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS \n public abstract int SetLocalVideoDataSourcePosition(VIDEO_MODULE_POSITION position); \n #endif"
        ],
        hide_methods: [
            "release",
            "queryInterface",
            "registerPacketObserver",
            "registerEventHandler",
            "unregisterEventHandler",
            "joinChannelWithUserAccountEx",
            "startScreenCapture",
            "setLogFile",
            "createMediaPlayer",
            "destroyMediaPlayer",
            "createMediaRecorder",
            "destroyMediaRecorder",
            "getScreenCaptureSources",
            "registerAudioSpectrumObserver",
            "unregisterAudioSpectrumObserver",
            "unregisterMediaMetadataObserver",
            "initialize",
            "registerAudioEncodedFrameObserver",
            "registerMediaMetadataObserver"
        ],
        ut_compare: {
            "enableFaceDetection": "Assert.AreEqual(-4, nRet);",
            "enableMultiCamera": "Assert.AreEqual(-4, nRet);",
            "getAudioDeviceInfo": "Assert.AreEqual(-4, nRet);",
            "getErrorDescription": "Assert.AreEqual(\"fatal\", nRet);",
            "getNtpWallTimeInMs": "Assert.AreEqual(true, nRet > 0);",
            "createCustomEncodedVideoTrack": "Assert.AreEqual(true, nRet > 0);",
            "createCustomAudioTrack": "Assert.AreEqual(true, nRet > 0);",
            "getVersion": "Assert.AreEqual(\"v1\", nRet);",
            "isCameraAutoExposureFaceModeSupported": "Assert.AreEqual(false, nRet);",
            "isCameraAutoFocusFaceModeSupported": "Assert.AreEqual(false, nRet);",
            "isCameraExposurePositionSupported": "Assert.AreEqual(false, nRet);",
            "isCameraExposureSupported": "Assert.AreEqual(false, nRet);",
            "isCameraFaceDetectSupported": "Assert.AreEqual(false, nRet);",
            "isCameraFocusSupported": "Assert.AreEqual(false, nRet);",
            "isCameraTorchSupported": "Assert.AreEqual(false, nRet);",
            "isCameraZoomSupported": "Assert.AreEqual(false, nRet);",
            "isSpeakerphoneEnable": "Assert.AreEqual(false, nRet);",
            "loadExtensionProvider": "Assert.AreEqual(-4, nRet);",
            "isSpeakerphoneEnabled": "Assert.AreEqual(false, nRet);",
            "queryCameraFocalLengthCapability": "Assert.AreEqual(-4, nRet);",
            "queryScreenCaptureCapability": "Assert.AreEqual(-4, nRet);",
            "setAudioSessionOperationRestriction": "Assert.AreEqual(-4, nRet);",
            "setCameraAutoExposureFaceModeEnabled": "Assert.AreEqual(-4, nRet);",
            "setCameraAutoFocusFaceModeEnabled": "Assert.AreEqual(-4, nRet);",
            "setCameraExposureFactor": "Assert.AreEqual(-4, nRet);",
            "setCameraExposurePosition": "Assert.AreEqual(-4, nRet);",
            "setCameraFocusPositionInPreview": "Assert.AreEqual(-4, nRet);",
            "setCameraStabilizationMode": "Assert.AreEqual(-4, nRet);",
            "setCameraTorchOn": "Assert.AreEqual(-4, nRet);",
            "setCameraZoomFactor": "Assert.AreEqual(-4, nRet);",
            "setDefaultAudioRouteToSpeakerphone": "Assert.AreEqual(-4, nRet);",
            "setEnableSpeakerphone": "Assert.AreEqual(-4, nRet);",
            "setExternalMediaProjection": "Assert.AreEqual(-4, nRet);",
            "switchCamera": "Assert.AreEqual(-4, nRet);",
            "createCustomVideoTrack": "Assert.AreEqual(true, nRet > 0);",
            "setExternalVideoSource": "Assert.AreEqual(-4, nRet);",
            "setRouteInCommunicationMode": "Assert.AreEqual(-4, nRet);",
            "startScreenCaptureByScreenRect": "Assert.AreEqual(-4, nRet);",
            "updateScreenCapture": "Assert.AreEqual(-4, nRet);",
            "isPipSupported": "Assert.AreEqual(false, nRet);",
            "setupPip": "Assert.AreEqual(-4, nRet);",
            "startPip": "Assert.AreEqual(-4, nRet);",
            "stopPip": "Assert.AreEqual(-4, nRet);"
        }
    },
    {
        name: "IMediaEngine",
        custom_methods: [
            "public abstract int RegisterVideoFrameObserver(IVideoFrameObserver observer, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);",
            "public abstract int UnRegisterVideoFrameObserver();",
            "public abstract int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver observer, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);",
            "public abstract int UnRegisterVideoEncodedFrameObserver();",
            "public abstract int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);",
            "public abstract int UnRegisterAudioFrameObserver();",
            "public abstract int UnRegisterFaceInfoObserver();"
        ],
        hide_methods: [
            "release",
            "enableCustomAudioLocalPlayback",
            "registerAudioFrameObserver",
            "registerVideoFrameObserver",
            "registerVideoEncodedFrameObserver",
            "addVideoFrameRenderer",
            "removeVideoFrameRenderer",
            "registerFaceInfoObserver",
        ],
        ut_compare: {
            "createCustomAudioTrack": "Assert.AreEqual(true, nRet > 0);",
            "createCustomVideoTrack": "Assert.AreEqual(true, nRet > 0);",
            "setExternalRemoteEglContext": "Assert.AreEqual(-4, nRet);",
        }
    },
    {
        name: "IRtcEngineEx",
        parent: "IRtcEngine",
        custom_methods: [
            "public abstract int SetParametersEx(RtcConnection connection, string key, object value);",
        ]
    },
    {
        name: "IVideoDeviceManager",
        custom_methods: [
            "public abstract DeviceInfo[] EnumerateVideoDevices();",
        ],
        hide_methods: [
            "enumerateVideoDevices",
            "release"
        ]
    },
    {
        name: "IRtcEngineEventHandler",
        hide_methods: [
            "eventHandlerType",
            "onAudioMetadataReceived",
            "onStreamMessage"
        ],
        merge_nodes: [{
            name: "IDirectCdnStreamingEventHandler",
            is_hide: true
        }],
        ut_compare: {
            "onFacePositionChanged": "Assert.AreEqual(false, callback.OnFacePositionChangedPassed(imageWidth, imageHeight, vecRectangle, vecDistance, numFaces));",
            "onPipStateChanged": "Assert.AreEqual(false, callback.OnPipStateChangedPassed(state));"
        }
    },
    {
        name: "IMusicContentCenter",
        hide_methods: [
            "release",
            "createMusicPlayer",
            "destroyMusicPlayer",
            "registerEventHandler",
            "registerScoreEventHandler"
        ]
    },
    {
        name: "IMusicPlayer",
        merge_nodes: [
            {
                name: "IMediaPlayer",
                is_hide: false
            }
        ]
    },
    {
        name: "IMediaRecorder",
        hide_methods: [
            "setMediaRecorderObserver"
        ]
    },
    {
        name: "IH265TranscoderObserver",
        is_abstract: true
    },
    {
        name: "IH265Transcoder",
        hide_methods: [
            "registerTranscoderObserver",
            "unregisterTranscoderObserver"
        ]
    },
    {
        name: "IMusicContentCenterEventHandler",
        is_abstract: true
    },
    {
        name: "IAudioFrameObserverBase",
        hide_methods: [
            "getObservedAudioFramePosition",
            "getPlaybackAudioParams",
            "getRecordAudioParams",
            "getMixedAudioParams",
            "getEarMonitoringAudioParams"
        ]
    },
    {
        name: "IAudioFrameObserver",
        name_space: [
            "agora",
            "media"
        ],
        merge_nodes: [
            {
                name: "IAudioFrameObserverBase",
                is_hide: true
            }
        ]
    },
    {
        name: "IMediaStreamingSourceObserver",
        is_hide: true
    },
    {
        name: "IPacketObserver",
        is_hide: true
    },
    {
        name: "IVideoFrameObserver",
        hide_methods: [
            "getVideoFrameProcessMode",
            "getVideoFormatPreference",
            "getRotationApplied",
            "getObservedFramePosition",
            "isExternal",
            "getMirrorApplied"
        ]
    },
    {
        name: "IAudioSpectrumObserver",
        hide_methods: [
            "onLocalAudioSpectrum",
            "onRemoteAudioSpectrum"
        ]
    },
    {
        name: "IMediaPlayerSourceObserver",
        hide_methods: [
            "onMetaData",
        ]
    }
];
