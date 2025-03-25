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
        isHide: true
    },
    {
        //there will some enumz or struct name is empty, so we need to hide them, wtf
        name: "",
        isHide: true
    },
    {
        name: "DeviceInfo",
        isHide: true
    },
    {
        name: "Packet",
        isHide: true
    },
    {
        name: "DownlinkNetworkInfo",
        isHide: true
    },
    {
        name: "EncryptionConfig",
        isHide: true
    },
    {
        name: "VideoFrame",
        isHide: true
    },
    {
        name: "AudioFrame",
        isHide: true
    },
    {
        name: "AudioFrame",
        isHide: true
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
        isHide: true
    },
    {
        name: "STREAMING_SRC_STATE",
        isHide: true
    },
    {
        name: "STREAMING_SRC_ERR",
        isHide: true
    },
    {
        name: "InputSeiData",
        isHide: true
    },
    {
        name: "RtcEngineContext",
        hide_members: [
            "eventHandler"
        ]
    },
    {
        name: "MAX_DEVICE_ID_LENGTH_TYPE",
        isHide: true
    }
];
