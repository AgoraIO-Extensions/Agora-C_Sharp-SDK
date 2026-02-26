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
        is_hide: false,
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
                is_hide: true
            },
            {
                name: "IMediaEngine",
                is_hide: true
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
            "setupRemoteVideo",
            "setupLocalVideo",
            "sendStreamMessage",
            "sendAudioMetadata",
            "createVideoEffectObject",
            "destroyVideoEffectObject"
        ]
    },
    {
        name: "IRtcEngineEx",
        hide_methods: [
            "setupRemoteVideoEx",
            "setupLocalVideoEx",
            "sendStreamMessageEx",
            "sendAudioMetadataEx",
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
            "destroyMusicPlayer",
            "getCaches"
        ]
    },
    {
        name: "IMusicPlayer",
        is_hide: false,
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
                is_hide: false,
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
    },
    {
        name: "IAudioEncodedFrameObserver",
        is_hide: true
    },
    {
        name: "IAudioFrameObserver",
        is_hide: true
    },
    {
        name: "IAudioPcmFrameSink",
        is_hide: true
    },
    {
        name: "IAudioSpectrumObserver",
        is_hide: true
    },
    {
        name: "IFaceInfoObserver",
        is_hide: true
    },
    {
        name: "IMediaPlayerAudioSpectrumObserver",
        is_hide: true
    },
    {
        name: "IMediaPlayerCustomDataProvider",
        is_hide: true
    },
    {
        name: "IMediaRecorderObserver",
        is_hide: true
    },
    {
        name: "IMetadataObserver",
        is_hide: true
    },
    {
        name: "IVideoEncodedFrameObserver",
        is_hide: true
    },
    {
        name: "IVideoFrameObserver",
        is_hide: true
    },
    {
        name: "IH265TranscoderObserver",
        is_callback_cross_thread: true,
        listener_name: "EventHandler"
    },
    {
        name: "IMediaPlayerSourceObserver",
        hide_methods: [
            "onMetaData"
        ],
        is_callback_cross_thread: true,
        listeners_map_name: "mediaPlayerSourceObserverDic",
        listeners_map_key: "playerId",
        listeners_map_key_type: "int"
    },
    {
        name: "IMusicContentCenterEventHandler",
        is_callback_cross_thread: true,
        listener_name: "EventHandler"
    },
    {
        name: "IRtcEngineEventHandler",
        hide_methods: [
            "eventHandlerType",
            "onStreamMessage",
            "onAudioMetadataReceived",
            "onLocalVideoStats",
            "onJoinChannelSuccess",
            "onLeaveChannel",
        ],
        merge_nodes: [{
            name: "IDirectCdnStreamingEventHandler",
            is_hide: true
        }],
        is_callback_cross_thread: true,
        listener_name: "rtcEngineEventHandler"
    },
    {
        name: "IMediaStreamingSourceObserver",
        is_hide: true
    },
    {
        name: "IPacketObserver",
        is_hide: true
    }
];