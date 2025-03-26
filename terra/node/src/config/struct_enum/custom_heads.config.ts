import { CustomHead } from "../../rtc/type_definition";

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
        ]
    },
    {
        name: "MAX_DEVICE_ID_LENGTH_TYPE",
        is_hide: true
    }
];
