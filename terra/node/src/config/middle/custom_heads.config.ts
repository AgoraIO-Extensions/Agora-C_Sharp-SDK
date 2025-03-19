import { CustomHead } from "../common/types";

export const customHeads: CustomHead[] = [
    {
        name: "IAgoraParameter",
        isHide: true,
    },
    {
        name: "IVideoFrameMetaInfo",
        isHide: true
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
            "enumeratePlaybackDevices",
            "enumerateRecordingDevices",
            "release"
        ]
    },
    {
        name: "IAudioFrameObserverBase",
        isHide: true
    },
    {
        name: "IRtcEngineEventHandlerEx",
        isHide: true
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
                isHide: true
            },
            {
                name: "IMediaEngine",
                isHide: true
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
                isHide: false
            }
        ]
    }
];
