import { CustomHead } from "../../rtc/type_definition";

export const customHeads: CustomHead[] = [
    {
        name: "IAgoraParameter",
        isHide: true,
    },
    {
        name: "IAudioDeviceCollection",
        isHide: true,
    },
    {
        name: "IContainer",
        isHide: true,
    },
    {
        name: "IEngineBase",
        isHide: true,
    },
    {
        name: "ILogWriter",
        isHide: true,
    },
    {
        name: "IMediaPlayerSource",
        isHide: true,
    },
    {
        name: "IMediaStreamingSource",
        isHide: true,
    },
    {
        name: "IRtcEngineEventHandlerEx",
        isHide: true
    },
    {
        name: "IScreenCaptureSourceList",
        isHide: true
    },
    {
        name: "IString",
        isHide: true
    },
    {
        name: "IVideoDeviceCollection",
        isHide: true
    },
    {
        name: "IIterator",
        isHide: true
    },
    {
        name: "IRhythmPlayer",
        isHide: true
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
            "release"
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
            "unregisterPlayerSourceObserver"
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
                isHide: true
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
            "joinChannelWithUserAccountEx"
        ]
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
            "removeVideoFrameRenderer"
        ]
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
            "eventHandlerType"
        ],
        merge_nodes: [{
            name: "IDirectCdnStreamingEventHandler",
            isHide: true
        }]
    },
    {
        name: "IMusicContentCenter",
        hide_methods: [
            "release"
        ]
    },
    {
        name: "IMusicPlayer",
        parent: "IMediaPlayer"
    },
    {
        name: "IH265TranscoderObserver",
        isAbstract: true
    },
    {
        name: "IMusicContentCenterEventHandler",
        isAbstract: true
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
                isHide: true
            }
        ]
    },
    {
        name: "IMediaStreamingSourceObserver",
        isHide: true
    },
    {
        name: "IPacketObserver",
        isHide: true
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
    }
];
