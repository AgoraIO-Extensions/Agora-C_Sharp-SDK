import { CustomHead } from "../../type_definition";

export const customHeads: CustomHead[] = [
    {
        name: "IAgoraParameter",
        is_hide: true,
    },
    {
        name: "IVideoFrameMetaInfo",
        is_hide: true
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
            "enumeratePlaybackDevices",
            "enumerateRecordingDevices",
            "release"
        ]
    },
    {
        name: "IAudioFrameObserverBase",
        is_hide: true
    },
    {
        name: "IRtcEngineEventHandlerEx",
        is_hide: true
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
            "registerPlayerSourceObserver",
            "unregisterPlayerSourceObserver"
        ]
    },
    {
        name: "IRtcEngine",
        parent: "IRtcEngineEx",
        merge_nodes: [
            {
                name: "IRtcEngineEx",
                is_hide: true
            },
            {
                name: "IMediaEngine",
                is_hide: true
            }
        ],
        hide_methods: [
            "release",
            "queryInterface",
            "registerPacketObserver",
            "registerEventHandler",
            "unregisterEventHandler",
            "joinChannelWithUserAccountEx",
            "createMediaPlayer",
            "destroyMediaPlayer",
            "createMediaRecorder",
            "destroyMediaRecorder"
        ]
    },
    {
        name: "IMediaEngine",
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
        name: "IVideoDeviceManager",
        hide_methods: [
            "enumerateVideoDevices",
            "release"
        ]
    },
    {
        name: "IMusicContentCenter",
        hide_methods: [
            "release"
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
    }
];
