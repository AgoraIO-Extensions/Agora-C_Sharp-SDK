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
            is_hide: true
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
        is_abstract: true
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
        name: "IScoreEventHandler",
        is_abstract: true
    }
];
