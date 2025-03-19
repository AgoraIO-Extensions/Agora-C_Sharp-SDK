
export const methodReturnDefaultValueTable: Record<string, { callback: string, interface: string }> = {
    "void": { callback: "", interface: "" },
    "int": { callback: "0", interface: "ErrorCode" },
    "long": { callback: "0", interface: "0" },
    "bool": { callback: "true", interface: "false" },
    "float": { callback: "0", interface: "0" },
    "double": { callback: "0", interface: "0" },
    "string": { callback: "\"\"", interface: "\"\"" },
    "IMusicPlayer": { callback: "null", interface: "null" },
    "IMediaPlayer": { callback: "null", interface: "null" },
    "IMediaRecorder": { callback: "null", interface: "null" },
    "uint": { callback: "0", interface: "0" },
    "ulong": { callback: "0", interface: "0" },
    "MEDIA_PLAYER_STATE": { callback: "MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL", interface: "MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL" },
    "ScreenCaptureSourceInfo[]": { callback: "null", interface: "null" },
    "CONNECTION_STATE_TYPE": { callback: "CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED", interface: "CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED" },
}