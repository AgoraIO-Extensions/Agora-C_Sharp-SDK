import { CustomHead } from "../../type_definition";

export const customHeads: CustomHead[] = [
    {
        name: "ExternalVideoFrame",
        custom_members: [
            `public ExternalVideoFrame(VIDEO_BUFFER_TYPE type, VIDEO_PIXEL_FORMAT format, byte[] buffer, int stride, int height, int cropLeft, int cropTop, int cropRight, int cropBottom, int rotation, long timestamp, IntPtr eglContext, EGL_CONTEXT_TYPE eglType, int textureId, long fenceObject, float[] matrix, byte[] metadataBuffer, int metadataSize, byte[] alphaBuffer, bool fillAlphaBuffer, ALPHA_STITCH_MODE alphaStitchMode, IntPtr d3d11Texture2d, int textureSliceIndex, Hdr10MetadataInfo hdr10MetadataInfo, ColorSpace colorSpace)
        : this(type, format, buffer, stride, height, cropLeft, cropTop, cropRight, cropBottom, rotation, timestamp, eglContext, eglType, textureId, fenceObject, matrix, metadataBuffer, metadataSize, alphaBuffer, fillAlphaBuffer, alphaStitchMode, d3d11Texture2d, textureSliceIndex, hdr10MetadataInfo, colorSpace, IntPtr.Zero)
    {
    }`
        ]
    },
    {
        name: "ChannelMediaOptions",
        custom_members: [
            `public ChannelMediaOptions(Optional<bool> publishCameraTrack, Optional<bool> publishSecondaryCameraTrack, Optional<bool> publishThirdCameraTrack, Optional<bool> publishFourthCameraTrack, Optional<bool> publishMicrophoneTrack, Optional<bool> publishScreenCaptureAudio, Optional<bool> publishScreenCaptureVideo, Optional<bool> publishScreenTrack, Optional<bool> publishSecondaryScreenTrack, Optional<bool> publishThirdScreenTrack, Optional<bool> publishFourthScreenTrack, Optional<bool> publishCustomAudioTrack, Optional<int> publishCustomAudioTrackId, Optional<bool> publishCustomVideoTrack, Optional<bool> publishEncodedVideoTrack, Optional<bool> publishMediaPlayerAudioTrack, Optional<bool> publishMediaPlayerVideoTrack, Optional<bool> publishTranscodedVideoTrack, Optional<bool> publishMixedAudioTrack, Optional<bool> publishLipSyncTrack, Optional<bool> autoSubscribeAudio, Optional<bool> autoSubscribeVideo, Optional<bool> enableAudioRecordingOrPlayout, Optional<int> publishMediaPlayerId, Optional<CLIENT_ROLE_TYPE> clientRoleType, Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel, Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType, Optional<CHANNEL_PROFILE_TYPE> channelProfile, Optional<int> audioDelayMs, Optional<int> mediaPlayerAudioDelayMs, Optional<string> token, Optional<bool> enableBuiltInMediaEncryption, Optional<bool> publishRhythmPlayerTrack, Optional<bool> isInteractiveAudience, Optional<uint> customVideoTrackId, Optional<bool> isAudioFilterable, Optional<string> parameters, Optional<bool> enableMultipath, Optional<MultipathMode> uplinkMultipathMode, Optional<MultipathMode> downlinkMultipathMode, Optional<MultipathType> preferMultipathType)
        : this(publishCameraTrack, publishSecondaryCameraTrack, publishThirdCameraTrack, publishFourthCameraTrack, publishMicrophoneTrack, publishScreenCaptureAudio, publishScreenCaptureVideo, publishScreenTrack, publishSecondaryScreenTrack, publishThirdScreenTrack, publishFourthScreenTrack, publishCustomAudioTrack, publishCustomAudioTrackId, new Optional<bool>(), new Optional<AudioTrackIdList>(), publishCustomVideoTrack, publishEncodedVideoTrack, publishMediaPlayerAudioTrack, publishMediaPlayerVideoTrack, publishTranscodedVideoTrack, publishMixedAudioTrack, publishLipSyncTrack, autoSubscribeAudio, autoSubscribeVideo, enableAudioRecordingOrPlayout, publishMediaPlayerId, clientRoleType, audienceLatencyLevel, defaultVideoStreamType, channelProfile, audioDelayMs, mediaPlayerAudioDelayMs, token, enableBuiltInMediaEncryption, publishRhythmPlayerTrack, isInteractiveAudience, customVideoTrackId, isAudioFilterable, parameters, enableMultipath, uplinkMultipathMode, downlinkMultipathMode, preferMultipathType, new Optional<string>())
    {
    }`
        ]
    },
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
