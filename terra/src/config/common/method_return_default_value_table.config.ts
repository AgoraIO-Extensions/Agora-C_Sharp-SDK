
export const methodReturnDefaultValueTable: Record<string, { callback: string, interface: string, impl: string, ut: string }> = {
    "void": { callback: "", interface: "", impl: "", ut: "" },
    "int": { callback: "0", interface: "ErrorCode", impl: "nRet", ut: "0" },
    "long": { callback: "0", interface: "0", impl: "nRet", ut: "0" },
    "bool": { callback: "true", interface: "false", impl: "false", ut: "true" },
    "float": { callback: "0", interface: "0", impl: "0", ut: "0" },
    "double": { callback: "0", interface: "0", impl: "nRet", ut: "0" },
    "string": { callback: "\"\"", interface: "\"\"", impl: "\"\"", ut: "\"\"" },
    "IMusicPlayer": { callback: "null", interface: "null", impl: "null", ut: "null" },
    "IMediaPlayer": { callback: "null", interface: "null", impl: "null", ut: "null" },
    "IMediaRecorder": { callback: "null", interface: "null", impl: "null", ut: "null" },
    "uint": { callback: "0", interface: "0", impl: "0", ut: "0" },
    "ulong": { callback: "0", interface: "0", impl: "0", ut: "0" },
    "IVideoEffectObject":{ callback: "null", interface: "null", impl: "null", ut: "null" },
    "MEDIA_PLAYER_STATE": { callback: "MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL", interface: "MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL", impl: "MEDIA_PLAYER_STATE.PLAYER_STATE_FAILED", ut: "MEDIA_PLAYER_STATE.PLAYER_STATE_IDLE" },
    "ScreenCaptureSourceInfo[]": { callback: "null", interface: "null", impl: "null", ut: "0" },
    "CONNECTION_STATE_TYPE": { callback: "CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED", interface: "CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED", impl: "CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED", ut: "CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED" },
}