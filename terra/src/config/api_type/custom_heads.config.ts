import { CustomHead } from "../../type_definition";

export const customHeads: CustomHead[] = [
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
                is_hide: true
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
    }
];
