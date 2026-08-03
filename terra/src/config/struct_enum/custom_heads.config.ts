import { CustomHead } from "../../type_definition";

export const customHeads: CustomHead[] = [
    {
        name: "AREA_CODE",
        parent: "uint"
    },
    {
        name: "AREA_CODE_EX",
        parent: "uint"
    },
    {
        name:"VIDEO_EFFECT_NODE_ID",
        parent: "uint"
    },
    {
        name: "VIDEO_MODULE_POSITION",
        attributes: ["Flags"]
    },
    {
        name: "AUDIO_FRAME_POSITION",
        attributes: ["Flags"]
    },
    {
        name: "UserInfo",
        is_hide: true
    },
    {
        //there will some enumz or struct name is empty, so we need to hide them, wtf
        name: "",
        is_hide: true
    },
    {
        name: "DeviceInfo",
        is_hide: true
    },
    {
        name: "Packet",
        is_hide: true
    },
    {
        name: "DownlinkNetworkInfo",
        is_hide: true
    },
    {
        name: "EncryptionConfig",
        is_hide: true
    },
    {
        name: "VideoFrame",
        custom_members: [
            "public IntPtr yBufferPtr;",
            "public IntPtr uBufferPtr;",
            "public IntPtr vBufferPtr;",
            "public IntPtr alphaBufferPtr;"
        ]
    },
    {
        name: "AudioFrame",
        custom_members: [
            "public byte[] RawBuffer = new byte[0];"
        ]
    },
    {
        name: "AudioFrame",
        is_hide: true
    },
    {
        name: "MediaSource",
        hide_to_json: [
            "provider"
        ]
    },
    {
        name: "MusicContentCenterConfiguration",
        hide_members: [
            "eventHandler"
        ]
    },
    {
        name: "RefCountReleaseStatus",
        is_hide: true
    },
    {
        name: "STREAMING_SRC_STATE",
        is_hide: true
    },
    {
        name: "STREAMING_SRC_ERR",
        is_hide: true
    },
    {
        name: "InputSeiData",
        is_hide: true
    },
    {
        name: "VideoCanvas",
        custom_members: [
            `public VideoCanvas(uint uid, uint subviewUid, view_t view, uint backgroundColor, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, VIDEO_VIEW_SETUP_MODE setupMode, VIDEO_SOURCE_TYPE sourceType, int mediaPlayerId, Rectangle cropArea, bool enableAlphaMask, VIDEO_MODULE_POSITION position)
        : this(uid, subviewUid, view, backgroundColor, renderMode, mirrorMode, setupMode, sourceType, mediaPlayerId, cropArea, enableAlphaMask, position, VIDEO_ORIENTATION.VIDEO_ORIENTATION_0)
    {
    }`
        ]
    },
    {
        name: "ChannelMediaOptions",
        custom_members: [
            `public ChannelMediaOptions(Optional<bool> publishCameraTrack, Optional<bool> publishSecondaryCameraTrack, Optional<bool> publishThirdCameraTrack, Optional<bool> publishFourthCameraTrack, Optional<bool> publishMicrophoneTrack, Optional<bool> publishScreenCaptureAudio, Optional<bool> publishScreenCaptureVideo, Optional<bool> publishScreenTrack, Optional<bool> publishSecondaryScreenTrack, Optional<bool> publishThirdScreenTrack, Optional<bool> publishFourthScreenTrack, Optional<bool> publishCustomAudioTrack, Optional<int> publishCustomAudioTrackId, Optional<bool> publishCustomVideoTrack, Optional<bool> publishEncodedVideoTrack, Optional<bool> publishMediaPlayerAudioTrack, Optional<bool> publishMediaPlayerVideoTrack, Optional<bool> publishTranscodedVideoTrack, Optional<bool> publishMixedAudioTrack, Optional<bool> publishLipSyncTrack, Optional<bool> autoSubscribeAudio, Optional<bool> autoSubscribeVideo, Optional<bool> enableAudioRecordingOrPlayout, Optional<int> publishMediaPlayerId, Optional<CLIENT_ROLE_TYPE> clientRoleType, Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel, Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType, Optional<CHANNEL_PROFILE_TYPE> channelProfile, Optional<int> audioDelayMs, Optional<int> mediaPlayerAudioDelayMs, Optional<string> token, Optional<bool> enableBuiltInMediaEncryption, Optional<bool> publishRhythmPlayerTrack, Optional<bool> isInteractiveAudience, Optional<uint> customVideoTrackId, Optional<bool> isAudioFilterable, Optional<string> parameters, Optional<bool> enableMultipath, Optional<MultipathMode> uplinkMultipathMode, Optional<MultipathMode> downlinkMultipathMode, Optional<MultipathType> preferMultipathType)
        : this(publishCameraTrack, publishSecondaryCameraTrack, publishThirdCameraTrack, publishFourthCameraTrack, publishMicrophoneTrack, publishScreenCaptureAudio, publishScreenCaptureVideo, publishScreenTrack, publishSecondaryScreenTrack, publishThirdScreenTrack, publishFourthScreenTrack, publishCustomAudioTrack, publishCustomAudioTrackId, new Optional<bool>(), new Optional<int>(), publishCustomVideoTrack, publishEncodedVideoTrack, publishMediaPlayerAudioTrack, publishMediaPlayerVideoTrack, publishTranscodedVideoTrack, publishMixedAudioTrack, publishLipSyncTrack, autoSubscribeAudio, autoSubscribeVideo, enableAudioRecordingOrPlayout, publishMediaPlayerId, clientRoleType, audienceLatencyLevel, defaultVideoStreamType, channelProfile, audioDelayMs, mediaPlayerAudioDelayMs, token, enableBuiltInMediaEncryption, publishRhythmPlayerTrack, isInteractiveAudience, customVideoTrackId, isAudioFilterable, parameters, enableMultipath, uplinkMultipathMode, downlinkMultipathMode, preferMultipathType, new Optional<CHANNEL_TYPE>())
    {
    }`
        ]
    },
    {
        name: "RtcEngineContext",
        hide_members: [
            "eventHandler"
        ],
        custom_members: [
            `public RtcEngineContext(string appId, ulong context, CHANNEL_PROFILE_TYPE channelProfile, string license, AUDIO_SCENARIO_TYPE audioScenario, AREA_CODE areaCode, LogConfig logConfig, Optional<THREAD_PRIORITY_TYPE> threadPriority, bool useExternalEglContext, bool domainLimit, bool autoRegisterAgoraExtensions)
        : this(appId, context, channelProfile, license, audioScenario, areaCode, logConfig, threadPriority, useExternalEglContext, domainLimit, autoRegisterAgoraExtensions, string.Empty)
    {
    }`
        ]
    },
    {
        name: "MAX_DEVICE_ID_LENGTH_TYPE",
        is_hide: true
    }
];
