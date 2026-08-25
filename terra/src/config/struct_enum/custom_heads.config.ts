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
