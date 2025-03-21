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
            "setMaxAudioRecvCount",
            "setAudioRecvRange",
            "setDistanceUnit",
            "updateSelfPosition",
            "updateSelfPositionEx",
            "updatePlayerPositionInfo",
            "muteLocalAudioStream",
            "muteAllRemoteAudioStreams",
            "setZones",
            "setPlayerAttenuation",
            "muteRemoteAudioStream",
            "updateRemotePosition",
            "updateRemotePositionEx",
            "removeRemotePosition",
            "removeRemotePositionEx",
            "clearRemotePositions",
            "clearRemotePositionsEx",
            "setRemoteAudioAttenuation",
            "initialize",
            "release"
        ]
    },
    {
        //todo IMediaPlayer 的实现非常特殊需要额外写
        name: "IMediaPlayer",
        isHide: false,
        hide_methods: [
            "release",
            "initialize",
            "getMediaPlayerId",
            "registerAudioFrameObserver",
            "unregisterAudioFrameObserver",
            "registerVideoFrameObserver",
            "unregisterVideoFrameObserver",
            "registerPlayerSourceObserver",
            "unregisterPlayerSourceObserver",
            "registerMediaPlayerAudioSpectrumObserver",
            "unregisterMediaPlayerAudioSpectrumObserver",
            "openWithMediaSource",
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
            "initialize",
            "queryInterface",
            "registerPacketObserver",
            "registerEventHandler",
            "unregisterEventHandler",
            "joinChannelWithUserAccountEx",
            "createMediaPlayer",
            "destroyMediaPlayer",
            "createMediaRecorder",
            "destroyMediaRecorder",
            "registerAudioEncodedFrameObserver",
            "registerAudioSpectrumObserver",
            "unregisterAudioSpectrumObserver",
            "registerMediaMetadataObserver",
            "unregisterMediaMetadataObserver",
            "getScreenCaptureSources",
            "startDirectCdnStreaming",
            "registerAudioEncodedFrameObserver",
            "registerAudioSpectrumObserver",
            "unregisterAudioSpectrumObserver",
            "registerMediaMetadataObserver",
            "unregisterMediaMetadataObserver",
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
            "removeVideoFrameRenderer",
            "pushEncodedVideoImage",
            "pushVideoFrame",
            "pullAudioFrame",
            "pushAudioFrame",
            "registerFaceInfoObserver"
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
            "release",
            "registerEventHandler",
            "unregisterEventHandler",
            "createMusicPlayer",
            "destroyMusicPlayer"
        ]
    },
    {
        name: "IMusicPlayer",
        isHide: false,
        hide_methods: [
            "initialize",
            "getMediaPlayerId",
            "registerPlayerSourceObserver",
            "unregisterPlayerSourceObserver",
            "registerVideoFrameObserver",
            "unregisterVideoFrameObserver"
        ],
        merge_nodes: [
            {
                name: "IMediaPlayer",
                isHide: false,
                override_method_hide: true
            }
        ]
    },
    {
        name: "IH265Transcoder",
        hide_methods: [
            "registerTranscoderObserver",
            "unregisterTranscoderObserver",
        ]
    },
    {
        name: "IMediaRecorder",
        hide_methods: [
            "setMediaRecorderObserver",
        ]
    }
];
