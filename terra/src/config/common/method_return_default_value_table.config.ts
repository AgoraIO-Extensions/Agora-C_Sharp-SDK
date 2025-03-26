
export const methodReturnDefaultValueTable: Record<string, { callback: string, interface: string, impl: string }> = {
    "void": { callback: "", interface: "", impl: "" },
    "int": { callback: "0", interface: "ErrorCode", impl: "nRet" },
    "long": { callback: "0", interface: "0", impl: "nRet" },
    "bool": { callback: "true", interface: "false", impl: "false" },
    "float": { callback: "0", interface: "0", impl: "0" },
    "double": { callback: "0", interface: "0", impl: "nRet" },
    "string": { callback: "\"\"", interface: "\"\"", impl: "\"\"" },
    "IMusicPlayer": { callback: "null", interface: "null", impl: "null" },
    "IMediaPlayer": { callback: "null", interface: "null", impl: "null" },
    "IMediaRecorder": { callback: "null", interface: "null", impl: "null" },
    "uint": { callback: "0", interface: "0", impl: "0" },
    "ulong": { callback: "0", interface: "0", impl: "0" },
    "MEDIA_PLAYER_STATE": { callback: "MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL", interface: "MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL", impl: "MEDIA_PLAYER_STATE.PLAYER_STATE_FAILED" },
    "ScreenCaptureSourceInfo[]": { callback: "null", interface: "null", impl: "null" },
    "CONNECTION_STATE_TYPE": { callback: "CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED", interface: "CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED", impl: "CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED" },
}