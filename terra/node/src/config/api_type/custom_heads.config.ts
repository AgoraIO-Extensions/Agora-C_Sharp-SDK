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
        hide_methods: [
            "release"
        ]
    },
    {
        name: "ILocalSpatialAudioEngine",
        hide_methods: [
            "release"
        ]
    },
    {
        name: "IMediaPlayer",
        hide_methods: [
            "release",
            "initialize",
            "getMediaPlayerId",
            "registerVideoFrameObserver",
            "unregisterVideoFrameObserver",
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
        hide_methods: [
            "release",
            "queryInterface",
            "registerPacketObserver",
            "unregisterEventHandler",
            "joinChannelWithUserAccountEx"
        ]
    },
    {
        name: "IMediaEngine",
        hide_methods: [
            "release",
            "enableCustomAudioLocalPlayback",
            "addVideoFrameRenderer",
            "removeVideoFrameRenderer"
        ]
    },
    {
        name: "IRtcEngineEx",
        parent: "IRtcEngine"
    },
    {
        name: "IVideoDeviceManager",
        hide_methods: [
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
