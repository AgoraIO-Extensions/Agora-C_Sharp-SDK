//  AgoraEnums.cs
//
//  Created by Yiqing Huang on May 25, 2021.
//  Modified by Yiqing Huang on July 21, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    using uid_t = UInt32;
    using view_t = UInt64;

    /**
     * Warning codes. See https://docs.agora.io/en/Interactive%20Broadcast/error_rtc.
     */
    public enum WARN_CODE_TYPE
    {
        WARN_INVALID_VIEW = 8,

        WARN_INIT_VIDEO = 16,

        WARN_PENDING = 20,

        WARN_NO_AVAILABLE_CHANNEL = 103,

        WARN_LOOKUP_CHANNEL_TIMEOUT = 104,

        WARN_LOOKUP_CHANNEL_REJECTED = 105,

        WARN_OPEN_CHANNEL_TIMEOUT = 106,

        WARN_OPEN_CHANNEL_REJECTED = 107,

        // sdk: 100~1000
        WARN_SWITCH_LIVE_VIDEO_TIMEOUT = 111,

        WARN_SET_CLIENT_ROLE_TIMEOUT = 118,

        WARN_OPEN_CHANNEL_INVALID_TICKET = 121,

        WARN_OPEN_CHANNEL_TRY_NEXT_VOS = 122,

        WARN_CHANNEL_CONNECTION_UNRECOVERABLE = 131,

        WARN_CHANNEL_CONNECTION_IP_CHANGED = 132,

        WARN_CHANNEL_CONNECTION_PORT_CHANGED = 133,

        WARN_CHANNEL_SOCKET_ERROR = 134,

        WARN_AUDIO_MIXING_OPEN_ERROR = 701,

        WARN_ADM_RUNTIME_PLAYOUT_WARNING = 1014,

        WARN_ADM_RUNTIME_RECORDING_WARNING = 1016,

        WARN_ADM_RECORD_AUDIO_SILENCE = 1019,

        WARN_ADM_PLAYOUT_MALFUNCTION = 1020,

        WARN_ADM_RECORD_MALFUNCTION = 1021,

        WARN_ADM_CALL_INTERRUPTION = 1025,

        WARN_ADM_IOS_CATEGORY_NOT_PLAYANDRECORD = 1029,

        WARN_ADM_RECORD_AUDIO_LOWLEVEL = 1031,

        WARN_ADM_PLAYOUT_AUDIO_LOWLEVEL = 1032,

        WARN_ADM_RECORD_AUDIO_IS_ACTIVE = 1033,

        WARN_ADM_WINDOWS_NO_DATA_READY_EVENT = 1040,

        WARN_ADM_INCONSISTENT_AUDIO_DEVICE = 1042,

        WARN_APM_HOWLING = 1051,

        WARN_ADM_GLITCH_STATE = 1052,

        WARN_APM_RESIDUAL_ECHO = 1053,

        /// @cond
        WARN_ADM_WIN_CORE_NO_RECORDING_DEVICE = 1322,

        /// @endcond
        WARN_ADM_WIN_CORE_NO_PLAYOUT_DEVICE = 1323,

        WARN_ADM_WIN_CORE_IMPROPER_CAPTURE_RELEASE = 1324,

        WARN_SUPER_RESOLUTION_STREAM_OVER_LIMITATION = 1610,

        WARN_SUPER_RESOLUTION_USER_COUNT_OVER_LIMITATION = 1611,

        WARN_SUPER_RESOLUTION_DEVICE_NOT_SUPPORTED = 1612,

        /// @cond
        WARN_RTM_LOGIN_TIMEOUT = 2005,

        WARN_RTM_KEEP_ALIVE_TIMEOUT = 2009
        /// @endcond
    }

    /**
     * Error codes. See https://docs.agora.io/en/Interactive%20Broadcast/error_rtc.
     */
    public enum ERROR_CODE_TYPE
    {
        ERR_OK = 0,

        //1~1000
        ERR_FAILED = 1,

        ERR_INVALID_ARGUMENT = 2,

        ERR_NOT_READY = 3,

        ERR_NOT_SUPPORTED = 4,

        ERR_REFUSED = 5,

        ERR_BUFFER_TOO_SMALL = 6,

        ERR_NOT_INITIALIZED = 7,

        ERR_NO_PERMISSION = 9,

        ERR_TIMEDOUT = 10,

        ERR_CANCELED = 11,

        ERR_TOO_OFTEN = 12,

        ERR_BIND_SOCKET = 13,

        ERR_NET_DOWN = 14,

        ERR_NET_NOBUFS = 15,

        ERR_JOIN_CHANNEL_REJECTED = 17,

        ERR_LEAVE_CHANNEL_REJECTED = 18,

        ERR_ALREADY_IN_USE = 19,

        ERR_ABORTED = 20,

        ERR_INIT_NET_ENGINE = 21,

        ERR_RESOURCE_LIMITED = 22,

        ERR_INVALID_APP_ID = 101,

        ERR_INVALID_CHANNEL_NAME = 102,

        ERR_NO_SERVER_RESOURCES = 103,

        ERR_TOKEN_EXPIRED = 109,

        ERR_INVALID_TOKEN = 110,

        ERR_CONNECTION_INTERRUPTED = 111, // only used in web sdk

        ERR_CONNECTION_LOST = 112, // only used in web sdk

        ERR_NOT_IN_CHANNEL = 113,

        ERR_SIZE_TOO_LARGE = 114,

        ERR_BITRATE_LIMIT = 115,

        ERR_TOO_MANY_DATA_STREAMS = 116,

        ERR_STREAM_MESSAGE_TIMEOUT = 117,

        ERR_SET_CLIENT_ROLE_NOT_AUTHORIZED = 119,

        ERR_DECRYPTION_FAILED = 120,

        ERR_CLIENT_IS_BANNED_BY_SERVER = 123,

        ERR_WATERMARK_PARAM = 124,

        ERR_WATERMARK_PATH = 125,

        ERR_WATERMARK_PNG = 126,

        ERR_WATERMARKR_INFO = 127,

        ERR_WATERMARK_ARGB = 128,

        ERR_WATERMARK_READ = 129,

        ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH = 130,

        ERR_INVALID_USER_ACCOUNT = 134,

        ERR_PUBLISH_STREAM_CDN_ERROR = 151,

        ERR_PUBLISH_STREAM_NUM_REACH_LIMIT = 152,

        ERR_PUBLISH_STREAM_NOT_AUTHORIZED = 153,

        ERR_PUBLISH_STREAM_INTERNAL_SERVER_ERROR = 154,

        ERR_PUBLISH_STREAM_NOT_FOUND = 155,

        ERR_PUBLISH_STREAM_FORMAT_NOT_SUPPORTED = 156,

        ERR_MODULE_NOT_FOUND = 157,

        /// @cond
        ERR_MODULE_SUPER_RESOLUTION_NOT_FOUND = 158,

        /// @endcond
        ERR_ALREADY_IN_RECORDING = 160,

        //signaling: 400~600
        ERR_LOGOUT_OTHER = 400, //
        ERR_LOGOUT_USER = 401, // logout by user
        ERR_LOGOUT_NET = 402, // network failure
        ERR_LOGOUT_KICKED = 403, // login in other device
        ERR_LOGOUT_PACKET = 404, //
        ERR_LOGOUT_TOKEN_EXPIRED = 405, // token expired
        ERR_LOGOUT_OLDVERSION = 406, //
        ERR_LOGOUT_TOKEN_WRONG = 407,
        ERR_LOGOUT_ALREADY_LOGOUT = 408,
        ERR_LOGIN_OTHER = 420,
        ERR_LOGIN_NET = 421,
        ERR_LOGIN_FAILED = 422,
        ERR_LOGIN_CANCELED = 423,
        ERR_LOGIN_TOKEN_EXPIRED = 424,
        ERR_LOGIN_OLD_VERSION = 425,
        ERR_LOGIN_TOKEN_WRONG = 426,
        ERR_LOGIN_TOKEN_KICKED = 427,
        ERR_LOGIN_ALREADY_LOGIN = 428,
        ERR_JOIN_CHANNEL_OTHER = 440,
        ERR_SEND_MESSAGE_OTHER = 440,
        ERR_SEND_MESSAGE_TIMEOUT = 441,
        ERR_QUERY_USERNUM_OTHER = 450,
        ERR_QUERY_USERNUM_TIMEOUT = 451,
        ERR_QUERY_USERNUM_BYUSER = 452,
        ERR_LEAVE_CHANNEL_OTHER = 460,
        ERR_LEAVE_CHANNEL_KICKED = 461,
        ERR_LEAVE_CHANNEL_BYUSER = 462,
        ERR_LEAVE_CHANNEL_LOGOUT = 463,
        ERR_LEAVE_CHANNEL_DISCONNECTED = 464,
        ERR_INVITE_OTHER = 470,
        ERR_INVITE_REINVITE = 471,
        ERR_INVITE_NET = 472,
        ERR_INVITE_PEER_OFFLINE = 473,
        ERR_INVITE_TIMEOUT = 474,
        ERR_INVITE_CANT_RECV = 475,


        //1001~2000
        ERR_LOAD_MEDIA_ENGINE = 1001,

        ERR_START_CALL = 1002,

        ERR_START_CAMERA = 1003,

        ERR_START_VIDEO_RENDER = 1004,

        ERR_ADM_GENERAL_ERROR = 1005,

        ERR_ADM_JAVA_RESOURCE = 1006,

        ERR_ADM_SAMPLE_RATE = 1007,

        ERR_ADM_INIT_PLAYOUT = 1008,

        ERR_ADM_START_PLAYOUT = 1009,

        ERR_ADM_STOP_PLAYOUT = 1010,

        ERR_ADM_INIT_RECORDING = 1011,

        ERR_ADM_START_RECORDING = 1012,

        ERR_ADM_STOP_RECORDING = 1013,

        ERR_ADM_RUNTIME_PLAYOUT_ERROR = 1015,

        ERR_ADM_RUNTIME_RECORDING_ERROR = 1017,

        ERR_ADM_RECORD_AUDIO_FAILED = 1018,

        ERR_ADM_INIT_LOOPBACK = 1022,

        ERR_ADM_START_LOOPBACK = 1023,

        ERR_ADM_NO_PERMISSION = 1027,

        ERR_ADM_RECORD_AUDIO_IS_ACTIVE = 1033,

        ERR_ADM_ANDROID_JNI_JAVA_RESOURCE = 1101,

        ERR_ADM_ANDROID_JNI_NO_RECORD_FREQUENCY = 1108,

        ERR_ADM_ANDROID_JNI_NO_PLAYBACK_FREQUENCY = 1109,

        ERR_ADM_ANDROID_JNI_JAVA_START_RECORD = 1111,

        ERR_ADM_ANDROID_JNI_JAVA_START_PLAYBACK = 1112,

        ERR_ADM_ANDROID_JNI_JAVA_RECORD_ERROR = 1115,

        ERR_ADM_ANDROID_OPENSL_CREATE_ENGINE = 1151,

        ERR_ADM_ANDROID_OPENSL_CREATE_AUDIO_RECORDER = 1153,

        ERR_ADM_ANDROID_OPENSL_START_RECORDER_THREAD = 1156,

        ERR_ADM_ANDROID_OPENSL_CREATE_AUDIO_PLAYER = 1157,

        ERR_ADM_ANDROID_OPENSL_START_PLAYER_THREAD = 1160,

        ERR_ADM_IOS_INPUT_NOT_AVAILABLE = 1201,

        ERR_ADM_IOS_ACTIVATE_SESSION_FAIL = 1206,

        ERR_ADM_IOS_VPIO_INIT_FAIL = 1210,

        ERR_ADM_IOS_VPIO_REINIT_FAIL = 1213,

        ERR_ADM_IOS_VPIO_RESTART_FAIL = 1214,

        ERR_ADM_IOS_SET_RENDER_CALLBACK_FAIL = 1219,

        ERR_ADM_IOS_SESSION_SAMPLERATR_ZERO = 1221,

        ERR_ADM_WIN_CORE_INIT = 1301,

        ERR_ADM_WIN_CORE_INIT_RECORDING = 1303,

        ERR_ADM_WIN_CORE_INIT_PLAYOUT = 1306,

        ERR_ADM_WIN_CORE_INIT_PLAYOUT_NULL = 1307,

        ERR_ADM_WIN_CORE_START_RECORDING = 1309,

        ERR_ADM_WIN_CORE_CREATE_REC_THREAD = 1311,

        ERR_ADM_WIN_CORE_CAPTURE_NOT_STARTUP = 1314,

        ERR_ADM_WIN_CORE_CREATE_RENDER_THREAD = 1319,

        ERR_ADM_WIN_CORE_RENDER_NOT_STARTUP = 1320,

        ERR_ADM_WIN_CORE_NO_RECORDING_DEVICE = 1322,

        ERR_ADM_WIN_CORE_NO_PLAYOUT_DEVICE = 1323,

        ERR_ADM_WIN_WAVE_INIT = 1351,

        ERR_ADM_WIN_WAVE_INIT_RECORDING = 1353,

        ERR_ADM_WIN_WAVE_INIT_MICROPHONE = 1354,

        ERR_ADM_WIN_WAVE_INIT_PLAYOUT = 1355,

        ERR_ADM_WIN_WAVE_INIT_SPEAKER = 1356,

        ERR_ADM_WIN_WAVE_START_RECORDING = 1357,

        ERR_ADM_WIN_WAVE_START_PLAYOUT = 1358,

        ERR_ADM_NO_RECORDING_DEVICE = 1359,

        ERR_ADM_NO_PLAYOUT_DEVICE = 1360,

        // VDM error code starts from 1500
        ERR_VDM_CAMERA_NOT_AUTHORIZED = 1501,

        // VDM error code starts from 1500
        ERR_VDM_WIN_DEVICE_IN_USE = 1502,

        // VCM error code starts from 1600
        ERR_VCM_UNKNOWN_ERROR = 1600,

        ERR_VCM_ENCODER_INIT_ERROR = 1601,

        ERR_VCM_ENCODER_ENCODE_ERROR = 1602,

        ERR_VCM_ENCODER_SET_ERROR = 1603,
    }

    /**
     * The output log level of the SDK.
     */
    [Flags]
    public enum LOG_FILTER_TYPE
    {
        /**0: Do not output any log information.*/
        LOG_FILTER_OFF = 0,

        /**0x080f: Output all log information. Set your log filter as DEBUG if you want to get the most complete log file.*/
        LOG_FILTER_DEBUG = 0x080f,

        /**0x000f: Output CRITICAL, ERROR, WARNING, and INFO level log information. We recommend setting your log filter as this level.*/
        LOG_FILTER_INFO = 0x000f,

        /**0x000e: Output CRITICAL, ERROR, and WARNING level log information.*/
        LOG_FILTER_WARN = 0x000e,

        /**0x000c: Output CRITICAL and ERROR level log information.*/
        LOG_FILTER_ERROR = 0x000c,

        /**0x0008: Output CRITICAL level log information.*/
        LOG_FILTER_CRITICAL = 0x0008,

        /// @cond
        /// @endcond
    }

    /**
     * The output log level of the SDK.
     */
    [Flags]
    public enum LOG_LEVEL
    {
        /**0: Do not output any log information.*/
        LOG_LEVEL_NONE = 0x0000,

        /**
         * 0x0001: (Default) Output FATAL, ERROR,
         *  WARN, and INFO level log information. We
         *  recommend setting your log filter as this level.
         */
        LOG_LEVEL_INFO = 0x0001,

        /**
         * 0x0002: Output FATAL, ERROR, and WARN level
         *  log information.
         */
        LOG_LEVEL_WARN = 0x0002,

        /**0x0004: Output FATAL and ERROR level log information.*/
        LOG_LEVEL_ERROR = 0x0004,

        /**0x0008: Output FATAL level log information.*/
        LOG_LEVEL_FATAL = 0x0008,
    }

    /**
     * The maximum length of the device ID.
     */
    public enum MAX_DEVICE_ID_LENGTH_TYPE
    {
        /**The maximum length of the device ID is 512 bytes.*/
        MAX_DEVICE_ID_LENGTH = 512
    }

    /**
     * The maximum length of the user account.
     */
    public enum MAX_USER_ACCOUNT_LENGTH_T
    {
        /**The maximum length of the user account is 256 bytes.*/
        MAX_USER_ACCOUNT_LENGTH = 256
    }

    /**
     * The maximum length of the channel name.
     */
    public enum MAX_CHANNEL_ID_LENGTH_TYPE
    {
        /**The maximum length of the channel name is 64 bytes.*/
        MAX_CHANNEL_ID_LENGTH = 65
    }

    /**
     * Formats of the quality report.
     */
    public enum QUALITY_REPORT_FORMAT_TYPE
    {
        /**0: The quality report in JSON format.*/
        QUALITY_REPORT_JSON = 0,

        /**1: The quality report in HTML format.*/
        QUALITY_REPORT_HTML = 1,
    }

    public enum MEDIA_ENGINE_EVENT_CODE_TYPE
    {
        MEDIA_ENGINE_RECORDING_ERROR = 0,

        MEDIA_ENGINE_PLAYOUT_ERROR = 1,

        MEDIA_ENGINE_RECORDING_WARNING = 2,

        MEDIA_ENGINE_PLAYOUT_WARNING = 3,

        MEDIA_ENGINE_AUDIO_FILE_MIX_FINISH = 10,

        MEDIA_ENGINE_AUDIO_FAREND_MUSIC_BEGINS = 12,

        MEDIA_ENGINE_AUDIO_FAREND_MUSIC_ENDS = 13,

        MEDIA_ENGINE_LOCAL_AUDIO_RECORD_ENABLED = 14,

        MEDIA_ENGINE_LOCAL_AUDIO_RECORD_DISABLED = 15,

        // media engine role changed
        MEDIA_ENGINE_ROLE_BROADCASTER_SOLO = 20,

        MEDIA_ENGINE_ROLE_BROADCASTER_INTERACTIVE = 21,

        MEDIA_ENGINE_ROLE_AUDIENCE = 22,

        MEDIA_ENGINE_ROLE_COMM_PEER = 23,

        MEDIA_ENGINE_ROLE_GAME_PEER = 24,

        // iOS adm sample rate changed
        MEDIA_ENGINE_AUDIO_ADM_REQUIRE_RESTART = 110,

        MEDIA_ENGINE_AUDIO_ADM_SPECIAL_RESTART = 111,

        MEDIA_ENGINE_AUDIO_ADM_USING_COMM_PARAMS = 112,

        MEDIA_ENGINE_AUDIO_ADM_USING_NORM_PARAMS = 113,

        MEDIA_ENGINE_AUDIO_ADM_ROUTING_UPDATE = 114,

        // audio mix state
        MEDIA_ENGINE_AUDIO_EVENT_MIXING_PLAY = 710,

        MEDIA_ENGINE_AUDIO_EVENT_MIXING_PAUSED = 711,

        MEDIA_ENGINE_AUDIO_EVENT_MIXING_RESTART = 712,

        MEDIA_ENGINE_AUDIO_EVENT_MIXING_STOPPED = 713,

        MEDIA_ENGINE_AUDIO_EVENT_MIXING_ERROR = 714,

        //Mixing error codes
        MEDIA_ENGINE_AUDIO_ERROR_MIXING_OPEN = 701,

        MEDIA_ENGINE_AUDIO_ERROR_MIXING_TOO_FREQUENT = 702,

        MEDIA_ENGINE_AUDIO_ERROR_MIXING_INTERRUPTED_EOF = 703,

        MEDIA_ENGINE_AUDIO_ERROR_MIXING_NO_ERROR = 0,
    }

    /**
     * The playback state of the music file.
     */
    public enum AUDIO_MIXING_STATE_TYPE
    {
        /**
         * 710: The music file is playing.
         *  The possible reasons include:
         *  AUDIO_MIXING_REASON_STARTED_BY_USER(710)
         *  AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED(720)
         *  AUDIO_MIXING_REASON_START_NEW_LOOP(722)
         *  AUDIO_MIXING_REASON_RESUMED_BY_USER(726) 
         */
        AUDIO_MIXING_STATE_PLAYING = 710,

        /**
         * 711: The music file pauses playing.
         *  This state is due toAUDIO_MIXING_REASON_PAUSED_BY_USER (725).
         *  
         */
        AUDIO_MIXING_STATE_PAUSED = 711,

        /**
         * 713: The music file stops playing.
         *  The possible reasons include:
         *  AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED(723)
         *  AUDIO_MIXING_REASON_STOPPED_BY_USER(724) 
         */
        AUDIO_MIXING_STATE_STOPPED = 713,

        /**
         * 714: An error occurs during the playback of the audio mixing file.
         *  The possible reasons include:
         *  AUDIO_MIXING_REASON_CAN_NOT_OPEN(701)
         *  AUDIO_MIXING_REASON_TOO_FREQUENT_CALL(702)
         *  AUDIO_MIXING_REASON_INTERRUPTED_EOF(703) 
         */
        AUDIO_MIXING_STATE_FAILED = 714,
    }

    /**
     * The reason why the playback state of the music file changes. Reported in the OnAudioMixingStateChanged callback.
     */
    public enum AUDIO_MIXING_REASON_TYPE
    {
        /**
         * 701: The SDK cannot open the music file. For example, the local music file
         *  does not exist, the SDK does not support the file format, or the SDK cannot
         *  access the music file URL.
         */
        AUDIO_MIXING_REASON_CAN_NOT_OPEN = 701,

        /**702: The SDK opens the music file too frequently. If you need to call startAudioMixing multiple times, ensure that the call interval is more than 500 ms.*/
        AUDIO_MIXING_REASON_TOO_FREQUENT_CALL = 702,

        /**703: The music file playback is interrupted.*/
        AUDIO_MIXING_REASON_INTERRUPTED_EOF = 703,

        /**
         * 720: The method call of startAudioMixing to play music
         *  files succeeds.
         */
        AUDIO_MIXING_REASON_STARTED_BY_USER = 720,

        /**721: The music file completes a loop playback.*/
        AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED = 721,

        /**722: The music file starts a new loop playback.*/
        AUDIO_MIXING_REASON_START_NEW_LOOP = 722,

        /**723: The music file completes all loop playbacks.*/
        AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED = 723,

        /**
         * 724: The method call of StopAudioMixing to stop playing the
         *  music file succeeds.
         */
        AUDIO_MIXING_REASON_STOPPED_BY_USER = 724,

        /**
         * 725: The method call of PauseAudioMixing to pause playing
         *  the music file succeeds.
         */
        AUDIO_MIXING_REASON_PAUSED_BY_USER = 725,

        /**
         * 726: The method call of ResumeAudioMixing to resume playing
         *  the music file succeeds.
         */
        AUDIO_MIXING_REASON_RESUMED_BY_USER = 726,
    }

    /**
     * Media device states.
     */
    public enum MEDIA_DEVICE_STATE_TYPE
    {
        /**0: The device is ready for use.*/
        MEDIA_DEVICE_STATE_IDLE = 0,

        /**1: The device is in use.*/
        MEDIA_DEVICE_STATE_ACTIVE = 1,

        /**2: The device is disabled.*/
        MEDIA_DEVICE_STATE_DISABLED = 2,

        /**4: The device is not found.*/
        MEDIA_DEVICE_STATE_NOT_PRESENT = 4,

        /**8: The device is unplugged.*/
        MEDIA_DEVICE_STATE_UNPLUGGED = 8,

        /**16: The device is not recommended.*/
        MEDIA_DEVICE_STATE_UNRECOMMENDED = 16
    }

    /**
     * Media device types.
     */
    public enum MEDIA_DEVICE_TYPE
    {
        /**-1: Unknown device type.*/
        UNKNOWN_AUDIO_DEVICE = -1,

        /**0: Audio playback device.*/
        AUDIO_PLAYOUT_DEVICE = 0,

        /**1: Audio capturing device.*/
        AUDIO_RECORDING_DEVICE = 1,

        /**2: Video renderer.*/
        VIDEO_RENDER_DEVICE = 2,

        /**3: Video capturer.*/
        VIDEO_CAPTURE_DEVICE = 3,

        /**4: Application audio playback device.*/
        AUDIO_APPLICATION_PLAYOUT_DEVICE = 4,
    }

    /**
     * Local video state types
     */
    public enum LOCAL_VIDEO_STREAM_STATE
    {
        /**0: The local video is in the initial state.*/
        LOCAL_VIDEO_STREAM_STATE_STOPPED = 0,

        /**1: The local video capturing device starts successfully. */
        LOCAL_VIDEO_STREAM_STATE_CAPTURING = 1,

        /**2: The first video frame is successfully encoded.*/
        LOCAL_VIDEO_STREAM_STATE_ENCODING = 2,

        /**3: Fails to start the local video.*/
        LOCAL_VIDEO_STREAM_STATE_FAILED = 3
    }

    /**
     * Local video state error codes.
     */
    public enum LOCAL_VIDEO_STREAM_ERROR
    {
        /**0: The local video is normal.*/
        LOCAL_VIDEO_STREAM_ERROR_OK = 0,

        /**1: No specified reason for the local video failure.*/
        LOCAL_VIDEO_STREAM_ERROR_FAILURE = 1,

        /**2: No permission to use the local video capturing device.*/
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        /**3: The local video capturing device is in use.*/
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY = 3,

        /**4: The local video capture fails. Check whether the capturing device is working properly.*/
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE = 4,

        /**5: The local video encoding fails.*/
        LOCAL_VIDEO_STREAM_ERROR_ENCODE_FAILURE = 5,

        /**6: The local video capturing device not available due to app did enter background.*/
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_INBACKGROUND = 6,

        /**7: The local video capturing device not available because the app is running in a multi-app layout (generally on the pad).*/
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_MULTIPLE_FOREGROUND_APPS = 7,

        /**8: Fails to find a local video capture device.*/
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NOT_FOUND = 8,

        /**11: When calling StartScreenCaptureByWindowId to share the window, the shared window is in a minimized state.*/
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED = 11,

        /**
         *  Since
         *  v3.2.0 12: The error code indicates that a window shared by the window ID has been closed, or a full-screen window shared by the window ID has exited full-screen mode. After exiting full-screen mode, remote users cannot see the shared window. To prevent remote users from seeing a black screen, Agora recommends that you immediately stop screen sharing.
         *  Common scenarios for reporting this error code:
         *  When the local user closes the shared window, the SDK reports this error code.
         *  The local user shows some slides in full-screen mode first, and then shares the cpp of the slides. After the user exits full-screen mode, the SDK reports this error code.
         *  The local user watches web video or reads web document in full-screen mode first, and then shares the window of the web video or document. After the user exits full-screen mode, the SDK reports this error code. 
         */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_CLOSED = 12,
        /**13: (Windows only) The window being shared is overlapped by another window, so the overlapped area is blacked out by the SDK during window sharing.*/
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_OCCLUDED = 13,
        /**20: (Windows only) The SDK does not support sharing this type of window.*/
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_NOT_SUPPORTED = 20,
    }

    /**
     * Local audio states.
     */
    public enum LOCAL_AUDIO_STREAM_STATE
    {
        /**0: The local audio is in the initial state.*/
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        /**1: The capturing device starts successfully.*/
        LOCAL_AUDIO_STREAM_STATE_RECORDING = 1,

        /**2: The first audio frame encodes successfully.*/
        LOCAL_AUDIO_STREAM_STATE_ENCODING = 2,

        /**3: The local audio fails to start.*/
        LOCAL_AUDIO_STREAM_STATE_FAILED = 3
    }

    /**
     * Local audio state error codes.
     */
    public enum LOCAL_AUDIO_STREAM_ERROR
    {
        /**0: The local audio is normal.*/
        LOCAL_AUDIO_STREAM_ERROR_OK = 0,

        /**1: No specified reason for the local audio failure.*/
        LOCAL_AUDIO_STREAM_ERROR_FAILURE = 1,

        /**2: No permission to use the local audio device.*/
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        /**3: The microphone is in use.*/
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_BUSY = 3,

        /**4: The local audio capturing fails. Check whether the capturing device is working properly.*/
        LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE = 4,

        /**5: The local audio encoding fails.*/
        LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE = 5,

        /**6: No audio recording device.*/
        LOCAL_AUDIO_STREAM_ERROR_NO_RECORDING_DEVICE = 6,

        /**7: No audio playout device.*/
        LOCAL_AUDIO_STREAM_ERROR_NO_PLAYOUT_DEVICE = 7,

        /**8: The local audio capture is interrupted by a system call. If the local audio capture is required, remind your user to hang up the phone.*/
        LOCAL_AUDIO_STREAM_ERROR_INTERRUPTED = 8,

        /**9: The ID of the local audio-capture device is invalid. Check the audio capture device ID.*/
        LOCAL_AUDIO_STREAM_ERROR_RECORD_INVALID_ID = 9,

        /**10: The ID of the local audio-playback device is invalid. Check the audio playback device ID.*/
        LOCAL_AUDIO_STREAM_ERROR_PLAYOUT_INVALID_ID = 10
    }

    /**
     * Audio recording quality.
     */
    public enum AUDIO_RECORDING_QUALITY_TYPE
    {
        /**0: Low quality. The sample rate is 32 kHz, and the file size is around 1.2 MB after 10 minutes of recording.*/
        AUDIO_RECORDING_QUALITY_LOW = 0,

        /**1: Medium quality. The sample rate is 32 kHz, and the file size is around 2 MB after 10 minutes of recording.*/
        AUDIO_RECORDING_QUALITY_MEDIUM = 1,

        /**2: High quality. The sample rate is 32 kHz, and the file size is around 3.75 MB after 10 minutes of recording.*/
        AUDIO_RECORDING_QUALITY_HIGH = 2,
        /**3: Ultra high quality. The sample rate is 32 kHz, and the file size is around 7.5 MB after 10 minutes of recording.*/
        AUDIO_RECORDING_QUALITY_ULTRA_HIGH = 3,
    }

    /**
     * Network quality types.
     */
    public enum QUALITY_TYPE
    {
        /**0: The network quality is unknown.*/
        QUALITY_UNKNOWN = 0,

        /**1: The network quality is excellent.*/
        QUALITY_EXCELLENT = 1,

        /**2: The network quality is quite good, but the bitrate may be slightly lower than excellent.*/
        QUALITY_GOOD = 2,

        /**3: Users can feel the communication slightly impaired.*/
        QUALITY_POOR = 3,

        /**4: Users cannot communicate smoothly.*/
        QUALITY_BAD = 4,

        /**5: The quality is so bad that users can barely communicate.*/
        QUALITY_VBAD = 5,

        /**6: The network is down and users cannot communicate at all.*/
        QUALITY_DOWN = 6,

        /**7: Users cannot detect the network quality. (Not in use.)*/
        QUALITY_UNSUPPORTED = 7,

        /**8: Detecting the network quality.*/
        QUALITY_DETECTING = 8,
    }

    /**
     * Video display modes.
     */
    public enum RENDER_MODE_TYPE
    {
        /**1: Uniformly scale the video until one of its dimension fits the boundary (zoomed to fit). Hidden mode. One dimension of the video may have clipped contents.*/
        RENDER_MODE_HIDDEN = 1,

        /**2: Uniformly scale the video until one of its dimension fits the boundary (zoomed to fit). Fit mode. Areas that are not filled due to disparity in the aspect ratio are filled with black.*/
        RENDER_MODE_FIT = 2,

        /**
         *  Deprecated:
         *  3: This mode is deprecated. 
         */
        RENDER_MODE_ADAPTIVE = 3,

        /**4: The fill mode. In this mode, the SDK stretches or zooms the video to fill the display window.*/
        RENDER_MODE_FILL = 4,
    }

    /**
     * Video mirror mode.
     */
    public enum VIDEO_MIRROR_MODE_TYPE
    {
        /**0: (Default) The SDK determines the mirror mode.*/
        VIDEO_MIRROR_MODE_AUTO = 0, //determined by SDK

        /**1: Enable mirror mode.*/
        VIDEO_MIRROR_MODE_ENABLED = 1, //enabled mirror

        /**2: Disable mirror mode.*/
        VIDEO_MIRROR_MODE_DISABLED = 2, //disable mirror
    }

    /**
     * Video profile
     */
    public enum VIDEO_PROFILE_TYPE
    {
        /**0: 160 × 120, frame rate 15 fps, bitrate 65 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_120P = 0,

        /**2: 120 × 120, frame rate 15 fps, bitrate 50 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_120P_3 = 2,

        /**10: 320 × 180, frame rate 15 fps, bitrate 140 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_180P = 10,

        /**12: 180 × 180, frame rate 15 fps, bitrate 100 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_180P_3 = 12,

        /**13: 240 × 180, frame rate 15 fps, bitrate 120 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_180P_4 = 13,

        /**20: 320 × 240, frame rate 15 fps, bitrate 200 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_240P = 20,

        /**22: 240 × 240, frame rate 15 fps, bitrate 140 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_240P_3 = 22,

        /**23: 424 × 240, frame rate 15 fps, bitrate 220 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_240P_4 = 23,

        /**30: 640 × 360, frame rate 15 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_360P = 30,

        /**32: 360 × 360, frame rate 15 fps, bitrate 260 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_360P_3 = 32,

        /**33: 640 × 360, frame rate 30 fps, bitrate 600 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_360P_4 = 33,

        /**35: 360 × 360, frame rate 30 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_360P_6 = 35,

        /**36: 480 × 360, frame rate 15 fps, bitrate 320 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_360P_7 = 36,

        /**37: 480 × 360, frame rate 30 fps, bitrate 490 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_360P_8 = 37,

        /**
         * 38: 640 × 360, frame rate 15 fps, bitrate 800 Kbps.
         *  This profile applies only to the live streaming channel profile.
         *  
         */
        VIDEO_PROFILE_LANDSCAPE_360P_9 = 38,

        /**
         * 39: 640 × 360, frame rate 24 fps, bitrate 800 Kbps.
         *  This profile applies only to the live streaming channel profile.
         */
        VIDEO_PROFILE_LANDSCAPE_360P_10 = 39,

        /**
         * 100: 640 × 360, frame rate 24 fps, bitrate 1000 Kbps.
         *  This profile applies only to the live streaming channel profile.
         */
        VIDEO_PROFILE_LANDSCAPE_360P_11 = 100,

        /**40: 640 × 480, frame rate 15 fps, bitrate 500 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_480P = 40,

        /**42: 480 × 480, frame rate 15 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_480P_3 = 42,

        /**43: 640 × 480, frame rate 30 fps, bitrate 750 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_480P_4 = 43,

        /**45: 480 × 480, frame rate 30 fps, bitrate 600 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_480P_6 = 45,

        /**47: 848 × 480, frame rate 15 fps, bitrate 610 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_480P_8 = 47,

        /**48: 848 × 480, frame rate 30 fps, bitrate 930 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_480P_9 = 48,

        /**49: 640 × 480, frame rate 10 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_480P_10 = 49,

        /**50: 1280 × 720, frame rate 15 fps, bitrate 1130 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_720P = 50,

        /**52: 1280 × 720, frame rate 30 fps, bitrate 1710 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_720P_3 = 52,

        /**54: 960 × 720, frame rate 15 fps, bitrate 910 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_720P_5 = 54,

        /**55: 960 × 720, frame rate 30 fps, bitrate 1380 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_720P_6 = 55,

        /**60: 1920 × 1080, frame rate 15 fps, bitrate 2080 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_1080P = 60,

        /**60: 1920 × 1080, frame rate 30 fps, bitrate 3150 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_1080P_3 = 62,

        /**64: 1920 × 1080, frame rate 60 fps, bitrate 4780 Kbps.*/
        VIDEO_PROFILE_LANDSCAPE_1080P_5 = 64,

        VIDEO_PROFILE_LANDSCAPE_1440P = 66,

        VIDEO_PROFILE_LANDSCAPE_1440P_2 = 67,

        VIDEO_PROFILE_LANDSCAPE_4K = 70,

        VIDEO_PROFILE_LANDSCAPE_4K_3 = 72,

        /**1000: 120 × 160, frame rate 15 fps, bitrate 65 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_120P = 1000,

        /**1002: 120 × 120, frame rate 15 fps, bitrate 50 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_120P_3 = 1002,

        /**1010: 180 × 320, frame rate 15 fps, bitrate 140 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_180P = 1010,

        /**1012: 180 × 180, frame rate 15 fps, bitrate 100 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_180P_3 = 1012,

        /**1013: 180 × 240, frame rate 15 fps, bitrate 120 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_180P_4 = 1013,

        /**1020: 240 × 320, frame rate 15 fps, bitrate 200 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_240P = 1020,

        /**1022: 240 × 240, frame rate 15 fps, bitrate 140 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_240P_3 = 1022,

        /**1023: 240 × 424, frame rate 15 fps, bitrate 220 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_240P_4 = 1023,

        /**1030: 360 × 640, frame rate 15 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_360P = 1030,

        /**1032: 360 × 360, frame rate 15 fps, bitrate 260 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_360P_3 = 1032,

        /**1033: 360 × 640, frame rate 15 fps, bitrate 600 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_360P_4 = 1033,

        /**1035: 360 × 360, frame rate 30 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_360P_6 = 1035,

        /**1036: 360 × 480, frame rate 15 fps, bitrate 320 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_360P_7 = 1036,

        /**1037: 360 × 480, frame rate 30 fps, bitrate 490 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_360P_8 = 1037,

        /**
         * 1038: 360 × 640, frame rate 15 fps, bitrate 800 Kbps.
         *  This profile applies only to the live streaming channel profile.
         *  
         */
        VIDEO_PROFILE_PORTRAIT_360P_9 = 1038,

        /**
         * 1039: 360 × 640, frame rate 24 fps, bitrate 800 Kbps.
         *  This profile applies only to the live streaming channel profile.
         *  
         */
        VIDEO_PROFILE_PORTRAIT_360P_10 = 1039,

        /**
         * 1100: 360 × 640, frame rate 24 fps, bitrate 1000 Kbps.
         *  This profile applies only to the live streaming channel profile.
         *  
         */
        VIDEO_PROFILE_PORTRAIT_360P_11 = 1100,

        /**1040: 480 × 640, frame rate 15 fps, bitrate 500 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_480P = 1040,

        /**1042: 480 × 480, frame rate 15 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_480P_3 = 1042,

        /**1043: 480 × 640, frame rate 30 fps, bitrate 750 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_480P_4 = 1043,

        /**1045: 480 × 480, frame rate 30 fps, bitrate 600 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_480P_6 = 1045,

        /**1047: 480 × 848, frame rate 15 fps, bitrate 610 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_480P_8 = 1047,

        /**1048: 480 × 848, frame rate 30 fps, bitrate 930 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_480P_9 = 1048,

        /**1049: 480 × 640, frame rate 10 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_480P_10 = 1049,

        /**1050: 720 × 1280, frame rate 15 fps, bitrate 1130 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_720P = 1050,

        /**1052: 720 × 1280, frame rate 30 fps, bitrate 1710 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_720P_3 = 1052,

        /**1054: 720 × 960, frame rate 15 fps, bitrate 910 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_720P_5 = 1054,

        /**1055: 720 × 960, frame rate 30 fps, bitrate 1380 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_720P_6 = 1055,

        /**1060: 1080 × 1920, frame rate 15 fps, bitrate 2080 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_1080P = 1060,

        /**1062: 1080 × 1920, frame rate 30 fps, bitrate 3150 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_1080P_3 = 1062,

        /**1064: 1080 × 1920, frame rate 60 fps, bitrate 4780 Kbps.*/
        VIDEO_PROFILE_PORTRAIT_1080P_5 = 1064,

        VIDEO_PROFILE_PORTRAIT_1440P = 1066,

        VIDEO_PROFILE_PORTRAIT_1440P_2 = 1067,

        VIDEO_PROFILE_PORTRAIT_4K = 1070,

        VIDEO_PROFILE_PORTRAIT_4K_3 = 1072,

        /**(Default) 640 × 360, frame rate 15 fps, bitrate 400 Kbps.*/
        VIDEO_PROFILE_DEFAULT = VIDEO_PROFILE_LANDSCAPE_360P,
    }

    /**
     * The audio profile.
     */
    public enum AUDIO_PROFILE_TYPE
    {
        /**
         * 0: The default audio profile.
         *  For the interactive streaming profile: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 64 Kbps.
         *  For the communication profile: 
         */
        AUDIO_PROFILE_DEFAULT = 0, // use default settings

        /**1: A sample rate of 32 kHz, audio encoding, mono, and a bitrate of up to 18 Kbps.*/
        AUDIO_PROFILE_SPEECH_STANDARD = 1, // 32Khz, 18Kbps, mono, speech

        /**2: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 64 Kbps.*/
        AUDIO_PROFILE_MUSIC_STANDARD = 2, // 48Khz, 48Kbps, mono, music

        /**3: A sample rate of 48 kHz, music encoding, stereo, and a bitrate of up to 80 Kbps.*/
        AUDIO_PROFILE_MUSIC_STANDARD_STEREO = 3, // 48Khz, 56Kbps, stereo, music

        /**4: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 96 Kbps.*/
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY = 4, // 48Khz, 128Kbps, mono, music

        /**5: A sample rate of 48 kHz, music encoding, stereo, and a bitrate of up to 128 Kbps.*/
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO = 5, // 48Khz, 192Kbps, stereo, music

        /**
         * 6: A sample rate of 16 kHz, audio encoding, mono, and Acoustic Echo Cancellation (AES) enabled.
         *  
         */
        AUDIO_PROFILE_IOT = 6,
        /**Enumerator boundary.*/
        AUDIO_PROFILE_NUM = 7,
    }

    /**
     * Audio application scenarios.
     */
    public enum AUDIO_SCENARIO_TYPE
    {
        /**0: The default audio scenario.*/
        AUDIO_SCENARIO_DEFAULT = 0,

        /**1: Entertainment scenario where users need to frequently switch the user role.*/
        AUDIO_SCENARIO_CHATROOM_ENTERTAINMENT = 1,

        /**2: Education scenario where users want smoothness and stability.*/
        AUDIO_SCENARIO_EDUCATION = 2,

        /**3: High-quality audio chatroom scenario where hosts mainly play music.*/
        AUDIO_SCENARIO_GAME_STREAMING = 3,

        /**4: Showroom scenario where a single host wants high-quality audio.*/
        AUDIO_SCENARIO_SHOWROOM = 4,

        /**5: Gaming scenario for group chat that only contains the human voice.*/
        AUDIO_SCENARIO_CHATROOM_GAMING = 5,

        /**6: IoT (Internet of Things) scenario where users use IoT devices with low power consumption.*/
        AUDIO_SCENARIO_IOT = 6,

        /**
         *  8: Meeting scenario that mainly contains the human voice.
         *  
         */
        AUDIO_SCENARIO_MEETING = 8,

        /**The number of elements in the enumeration.*/
        AUDIO_SCENARIO_NUM = 9,
    }

    /**
     * The channel profile.
     */
    public enum CHANNEL_PROFILE_TYPE
    {
        /**0: (Default) The communication profile. This profile applies to scenarios such as an audio call or video call, where all users can publish and subscribe to streams.*/
        CHANNEL_PROFILE_COMMUNICATION = 0,

        /**1: Live streaming. In this profile, you can set the role of users as the host or audience by calling SetClientRole [2/2]. A host both publishes and subscribes to streams, while an audience subscribes to streams only. This profile applies to scenarios such as a chat room or interactive video streaming.*/
        CHANNEL_PROFILE_LIVE_BROADCASTING = 1,

        /**2: Gaming. Agora does not recommend using this setting.*/
        CHANNEL_PROFILE_GAME = 2,
    }

    /**
     * The user role in the interactive live streaming.
     */
    public enum CLIENT_ROLE_TYPE
    {
        /**1: Host. A host can both send and receive streams.*/
        CLIENT_ROLE_BROADCASTER = 1,

        /**2: (Default) Audience. An audience member can only receive streams.*/
        CLIENT_ROLE_AUDIENCE = 2,
    }

    /**
     * The latency level of an audience member in interactive live streaming. This enum takes effect only when the user role is set to CLIENT_ROLE_AUDIENCE.
     */
    public enum AUDIENCE_LATENCY_LEVEL_TYPE
    {
        /**1: Low latency.*/
        AUDIENCE_LATENCY_LEVEL_LOW_LATENCY = 1,

        /**2: (Default) Ultra low latency.*/
        AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY = 2,
    }

    /**
     * The reason why super resolution is not successfully enabled.
     * Since
     *  v3.5.1
     */
    public enum SUPER_RESOLUTION_STATE_REASON
    {
        /**0: Super resolution is successfully enabled.*/
        SR_STATE_REASON_SUCCESS = 0,

        /**1: The original resolution of the remote video is beyond the range where super resolution can be applied.*/
        SR_STATE_REASON_STREAM_OVER_LIMITATION = 1,

        /**2: Super resolution is already being used to boost another remote user’s video.*/
        SR_STATE_REASON_USER_COUNT_OVER_LIMITATION = 2,

        /**3: The device does not support using super resolution.*/
        SR_STATE_REASON_DEVICE_NOT_SUPPORTED = 3,
    }

    /// @endcond
    /**
     * The reason why virtual background is not successfully enabled.
     * Since
     *  v3.5.0
     */
    public enum VIRTUAL_BACKGROUND_SOURCE_STATE_REASON
    {
        /**0: The virtual background is successfully enabled.*/
        VIRTUAL_BACKGROUND_SOURCE_STATE_REASON_SUCCESS = 0,

        // background image does not exist
        /**1: The custom background image does not exist. Please check the value of source in VirtualBackgroundSource .*/
        VIRTUAL_BACKGROUND_SOURCE_STATE_REASON_IMAGE_NOT_EXIST = 1,

        // color format is not supported
        /**2: The color format of the custom background image is invalid. Please check the value of color in VirtualBackgroundSource .*/
        VIRTUAL_BACKGROUND_SOURCE_STATE_REASON_COLOR_FORMAT_NOT_SUPPORTED = 2,

        // The device is not supported
        /**3: The device does not support using the virtual background.*/
        VIRTUAL_BACKGROUND_SOURCE_STATE_REASON_DEVICE_NOT_SUPPORTED = 3,
    }

    /**
     * Reasons for a user being offline.
     */
    public enum USER_OFFLINE_REASON_TYPE
    {
        /**0: The user quits the call.*/
        USER_OFFLINE_QUIT = 0,

        /**
         * 1: The SDK times out and the user drops offline because no data packet is received within a certain period of time.
         *  If the user quits the call and the message is not passed to the SDK (due to an unreliable channel), the SDK assumes the user dropped offline.
         */
        USER_OFFLINE_DROPPED = 1,

        /**2: The user switches the client role from the host to the audience.*/
        USER_OFFLINE_BECOME_AUDIENCE = 2,
    }

    /**
     * States of the Media Push.
     */
    public enum RTMP_STREAM_PUBLISH_STATE
    {
        /**0: The Media Push has not started or has ended. This state is also triggered after you remove a RTMP or RTMPS stream from the CDN by calling RemovePublishStreamUrl .*/
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        /**1: The SDK is connecting to Agora's streaming server and the CDN server. This state is triggered after you call the AddPublishStreamUrl method.*/
        RTMP_STREAM_PUBLISH_STATE_CONNECTING = 1,

        /**2: The RTMP or RTMPS streaming publishes. The SDK successfully publishes the RTMP or RTMPS streaming and returns this state.*/
        RTMP_STREAM_PUBLISH_STATE_RUNNING = 2,

        /**
         * 3: The RTMP or RTMPS streaming is recovering. When exceptions occur to the CDN, or the streaming is interrupted, the SDK tries to resume RTMP or RTMPS streaming and returns this state. If the SDK successfully resumes the streaming, RTMP_STREAM_PUBLISH_STATE_RUNNING(2) returns.
         *  If the streaming does not resume within 60 seconds or server errors occur, RTMP_STREAM_PUBLISH_STATE_FAILURE(4) returns. You can also reconnect to the server by calling the RemovePublishStreamUrl and AddPublishStreamUrl methods.
         *  
         */
        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        /**4: The RTMP or RTMPS streaming fails. See the errCode parameter for the detailed error information. You can also call the AddPublishStreamUrl method to publish the RTMP or RTMPS streaming again.*/
        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,
        /**5: The SDK is disconnecting from the Agora streaming server and CDN. When you call RemovePublishStreamUrl or StopRtmpStream to stop the streaming normally, the SDK reports the streaming state as RTMP_STREAM_PUBLISH_STATE_DISCONNECTING, RTMP_STREAM_PUBLISH_STATE_IDLE in sequence.*/
        RTMP_STREAM_PUBLISH_STATE_DISCONNECTING = 5,
    }

    /**
     * Error codes of the RTMP or RTMPS streaming.
     */
    public enum RTMP_STREAM_PUBLISH_ERROR_TYPE
    {
        /**0: The RTMP or RTMPS streaming publishes successfully.*/
        RTMP_STREAM_PUBLISH_ERROR_OK = 0,

        /**1: Invalid argument used. Please check the parameter setting. For example, if you do not call SetLiveTranscoding to set the transcoding parameters before calling AddPublishStreamUrl , the SDK returns this error.*/
        RTMP_STREAM_PUBLISH_ERROR_INVALID_ARGUMENT = 1,

        /**2: The RTMP or RTMPS streaming is encrypted and cannot be published.*/
        RTMP_STREAM_PUBLISH_ERROR_ENCRYPTED_STREAM_NOT_ALLOWED = 2,

        /**3: Timeout for the RTMP or RTMPS streaming. Call the AddPublishStreamUrl method to publish the streaming again.*/
        RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT = 3,

        /**4: An error occurs in Agora's streaming server. Call the AddPublishStreamUrl method to publish the streaming again.*/
        RTMP_STREAM_PUBLISH_ERROR_INTERNAL_SERVER_ERROR = 4,

        /**5: An error occurs in the CDN server.*/
        RTMP_STREAM_PUBLISH_ERROR_RTMP_SERVER_ERROR = 5,

        /**6: The RTMP or RTMPS streaming publishes too frequently.*/
        RTMP_STREAM_PUBLISH_ERROR_TOO_OFTEN = 6,

        /**7: The host publishes more than 10 URLs. Delete the unnecessary URLs before adding new ones.*/
        RTMP_STREAM_PUBLISH_ERROR_REACH_LIMIT = 7,

        /**8: The host manipulates other hosts' URLs. For example, the host updates or stops other hosts' streams. Check your app logic.*/
        RTMP_STREAM_PUBLISH_ERROR_NOT_AUTHORIZED = 8,

        /**9: Agora's server fails to find the RTMP or RTMPS streaming.*/
        RTMP_STREAM_PUBLISH_ERROR_STREAM_NOT_FOUND = 9,

        /**10: The format of the RTMP or RTMPS streaming URL is not supported. Check whether the URL format is correct.*/
        RTMP_STREAM_PUBLISH_ERROR_FORMAT_NOT_SUPPORTED = 10,
        /**11: The user role is not host, so the user cannot use the CDN live streaming function. Check your application code logic.*/
        RTMP_STREAM_PUBLISH_ERROR_NOT_BROADCASTER = 11,  // Note: match to ERR_PUBLISH_STREAM_NOT_BROADCASTER in AgoraBase.h
        /**The UpdateRtmpTranscoding or SetLiveTranscoding method is called to update the transcoding configuration in a scenario where there is streaming without transcoding. Check your application code logic.*/
        RTMP_STREAM_PUBLISH_ERROR_TRANSCODING_NO_MIX_STREAM = 13,  // Note: match to ERR_PUBLISH_STREAM_TRANSCODING_NO_MIX_STREAM in AgoraBase.h
        /**14: Errors occurred in the host's network.*/
        RTMP_STREAM_PUBLISH_ERROR_NET_DOWN = 14,  // Note: match to ERR_NET_DOWN in AgoraBase.h
        /**15: Your App ID does not have permission to use the CDN live streaming function. Refer to Prerequisites to enable the CDN live streaming permission.*/
        RTMP_STREAM_PUBLISH_ERROR_INVALID_APPID = 15,  // Note: match to ERR_PUBLISH_STREAM_APPID_INVALID in AgoraBase.h

        /**100: The streaming has been stopped normally. After you call RemovePublishStreamUrl to stop streaming, the SDK returns this value.*/
        RTMP_STREAM_UNPUBLISH_ERROR_OK = 100,
    }

    /**
     * Events during the media push.
     */
    public enum RTMP_STREAMING_EVENT
    {
        /**1: An error occurs when you add a background image or a watermark image in the media push.*/
        RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE = 1,

        /**2: The streaming URL is already being used for CDN live streaming. If you want to start new streaming, use a new streaming URL.*/
        RTMP_STREAMING_EVENT_URL_ALREADY_IN_USE = 2,
        /**3: The feature is not supported.*/
        RTMP_STREAMING_EVENT_ADVANCED_FEATURE_NOT_SUPPORT = 3,
        /**4: Reserved.*/
        RTMP_STREAMING_EVENT_REQUEST_TOO_OFTEN = 4,
    }

    /**
     * States of importing an external video stream in the interactive live streaming.
     */
    public enum INJECT_STREAM_STATUS
    {
        /**0: The external video stream is imported successfully.*/
        INJECT_STREAM_STATUS_START_SUCCESS = 0,

        /**1: The external video stream already exists.*/
        INJECT_STREAM_STATUS_START_ALREADY_EXISTS = 1,

        /**2: The external video stream to be imported is unauthorized.*/
        INJECT_STREAM_STATUS_START_UNAUTHORIZED = 2,

        /**3: A timeout occurs when importing the external video stream.*/
        INJECT_STREAM_STATUS_START_TIMEDOUT = 3,

        /**4: The SDK fails to import the external video stream.*/
        INJECT_STREAM_STATUS_START_FAILED = 4,

        /**5: The SDK successfully stops importing the external video stream.*/
        INJECT_STREAM_STATUS_STOP_SUCCESS = 5,

        /**6: The external video stream to be stopped importing is not found.*/
        INJECT_STREAM_STATUS_STOP_NOT_FOUND = 6,

        /**7: The external video stream to be stopped importing is unauthorized.*/
        INJECT_STREAM_STATUS_STOP_UNAUTHORIZED = 7,

        /**8: A timeout occurs when stopping importing the external video stream.*/
        INJECT_STREAM_STATUS_STOP_TIMEDOUT = 8,

        /**9: The SDK fails to stop importing the external video stream.*/
        INJECT_STREAM_STATUS_STOP_FAILED = 9,

        /**10: The external video stream is corrupted.*/
        INJECT_STREAM_STATUS_BROKEN = 10,
    }

    /**
     * The type of video streams.
     */
    public enum REMOTE_VIDEO_STREAM_TYPE
    {
        /**0: High-quality video stream.*/
        REMOTE_VIDEO_STREAM_HIGH = 0,

        /**1: Low-quality video stream.*/
        REMOTE_VIDEO_STREAM_LOW = 1,
    }

    /**
     * The brightness level of the video image captured by the local camera.
     */
    public enum CAPTURE_BRIGHTNESS_LEVEL_TYPE
    {
        /**-1: The SDK does not detect the brightness level of the video image. Wait a few seconds to get the brightness level from captureBrightnessLevel in the next callback.*/
        CAPTURE_BRIGHTNESS_LEVEL_INVALID = -1,

        /**0: The brightness level of the video image is normal.*/
        CAPTURE_BRIGHTNESS_LEVEL_NORMAL = 0,

        /**1: The brightness level of the video image is too bright.*/
        CAPTURE_BRIGHTNESS_LEVEL_BRIGHT = 1,

        /**2: The brightness level of the video image is too dark.*/
        CAPTURE_BRIGHTNESS_LEVEL_DARK = 2,
    }

    /**
     * The use mode of the audio data.
     */
    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        /**0: Read-only mode: */
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        /**1: Write-only mode: */
        RAW_AUDIO_FRAME_OP_MODE_WRITE_ONLY = 1,

        /**2: Read and write mode: */
        RAW_AUDIO_FRAME_OP_MODE_READ_WRITE = 2,
    }

    /**
     * The audio sampling rate of the stream to be pushed to the CDN.
     */
    public enum AUDIO_SAMPLE_RATE_TYPE
    {
        /**32000: 32 kHz*/
        AUDIO_SAMPLE_RATE_32000 = 32000,

        /**44100: 44.1 kHz*/
        AUDIO_SAMPLE_RATE_44100 = 44100,

        /**48000: (Default) 48 kHz*/
        AUDIO_SAMPLE_RATE_48000 = 48000,
    }

    /**
     * Video codec profile types.
     */
    public enum VIDEO_CODEC_PROFILE_TYPE
    {
        /**66: Baseline video codec profile. Generally used for video calls on mobile phones.*/
        VIDEO_CODEC_PROFILE_BASELINE = 66,

        /**77: Main video codec profile. Generally used in mainstream electronics such as MP4 players, portable video players, PSP, and iPads.*/
        VIDEO_CODEC_PROFILE_MAIN = 77,

        /**100: (Default) High video codec profile. Generally used in high-resolution live streaming or television.*/
        VIDEO_CODEC_PROFILE_HIGH = 100,
    }

    /**
     * Video codec types.
     */
    public enum VIDEO_CODEC_TYPE
    {
        /**Standard VP8.*/
        VIDEO_CODEC_VP8 = 1,

        /**Standard H.264.*/
        VIDEO_CODEC_H264 = 2,

        /**Enhanced VP8.*/
        VIDEO_CODEC_EVP = 3,

        /**Enhanced H.264.*/
        VIDEO_CODEC_E264 = 4,
    }

    /**
     * The codec type of the output video.
     */
    public enum VIDEO_CODEC_TYPE_FOR_STREAM
    {
        /**1: (Default) H.264.*/
        VIDEO_CODEC_H264_FOR_STREAM = 1,
        /**2: H.265.*/
        VIDEO_CODEC_H265_FOR_STREAM = 2,
    }

    /**
     * The midrange frequency for audio equalization.
     */
    public enum AUDIO_EQUALIZATION_BAND_FREQUENCY
    {
        /**0: 31 Hz*/
        AUDIO_EQUALIZATION_BAND_31 = 0,

        /**1: 62 Hz*/
        AUDIO_EQUALIZATION_BAND_62 = 1,

        /**2: 125 Hz*/
        AUDIO_EQUALIZATION_BAND_125 = 2,

        /**3: 250 Hz*/
        AUDIO_EQUALIZATION_BAND_250 = 3,

        /**4: 500 Hz*/
        AUDIO_EQUALIZATION_BAND_500 = 4,

        /**5: 1 kHz*/
        AUDIO_EQUALIZATION_BAND_1K = 5,

        /**6: 2 kHz*/
        AUDIO_EQUALIZATION_BAND_2K = 6,

        /**7: 4 kHz*/
        AUDIO_EQUALIZATION_BAND_4K = 7,

        /**8: 8 kHz*/
        AUDIO_EQUALIZATION_BAND_8K = 8,

        /**9: 16 kHz*/
        AUDIO_EQUALIZATION_BAND_16K = 9,
    }

    /**
     * Audio reverberation types.
     */
    public enum AUDIO_REVERB_TYPE
    {
        /**0: The level of the dry signal (dB). The value is between -20 and 10.*/
        AUDIO_REVERB_DRY_LEVEL = 0, // (dB, [-20,10]), the level of the dry signal

        /**1: The level of the early reflection signal (wet signal) (dB). The value is between -20 and 10.*/
        AUDIO_REVERB_WET_LEVEL = 1, // (dB, [-20,10]), the level of the early reflection signal (wet signal)

        /**2: The room size of the reflection. The value is between 0 and 100.*/
        AUDIO_REVERB_ROOM_SIZE = 2, // ([0,100]), the room size of the reflection

        /**3: The length of the initial delay of the wet signal (ms). The value is between 0 and 200.*/
        AUDIO_REVERB_WET_DELAY = 3, // (ms, [0,200]), the length of the initial delay of the wet signal in ms

        /**4: The reverberation strength. The value is between 0 and 100.*/
        AUDIO_REVERB_STRENGTH = 4, // ([0,100]), the strength of the reverberation
    }

    /**
     * Local voice changer options.
     */
    [Flags]
    public enum VOICE_CHANGER_PRESET
    {
        /**The original voice (no local voice change).*/
        VOICE_CHANGER_OFF = 0x00000000, //Turn off the voice changer

        /**The voice of an old man.*/
        VOICE_CHANGER_OLDMAN = 0x00000001,

        /**The voice of a little boy.*/
        VOICE_CHANGER_BABYBOY = 0x00000002,

        /**The voice of a little girl.*/
        VOICE_CHANGER_BABYGIRL = 0x00000003,

        /**The voice of Zhu Bajie, a character in Journey to the West who has a voice like that of a growling bear.*/
        VOICE_CHANGER_ZHUBAJIE = 0x00000004,

        /**The ethereal voice.*/
        VOICE_CHANGER_ETHEREAL = 0x00000005,

        /**The voice of Hulk.*/
        VOICE_CHANGER_HULK = 0x00000006,

        /**A more vigorous voice.*/
        VOICE_BEAUTY_VIGOROUS = 0x00100001, //7,

        /**A deeper voice.*/
        VOICE_BEAUTY_DEEP = 0x00100002,

        /**A mellower voice.*/
        VOICE_BEAUTY_MELLOW = 0x00100003,

        /**Falsetto.*/
        VOICE_BEAUTY_FALSETTO = 0x00100004,

        /**A fuller voice.*/
        VOICE_BEAUTY_FULL = 0x00100005,

        /**A clearer voice.*/
        VOICE_BEAUTY_CLEAR = 0x00100006,

        /**A more resounding voice.*/
        VOICE_BEAUTY_RESOUNDING = 0x00100007,

        /**A more ringing voice.*/
        VOICE_BEAUTY_RINGING = 0x00100008,

        /**A more spatially resonant voice.*/
        VOICE_BEAUTY_SPACIAL = 0x00100009,

        /**(For male only) A more magnetic voice. Do not use it when the speaker is a female; otherwise, voice distortion occurs.*/
        GENERAL_BEAUTY_VOICE_MALE_MAGNETIC = 0x00200001,

        /**(For female only) A fresher voice. Do not use it when the speaker is a male; otherwise, voice distortion occurs.*/
        GENERAL_BEAUTY_VOICE_FEMALE_FRESH = 0x00200002,

        /**(For female only) A more vital voice. Do not use it when the speaker is a male; otherwise, voice distortion occurs.*/
        GENERAL_BEAUTY_VOICE_FEMALE_VITALITY = 0x00200003
    }

    /**
     * Voice reverb presets.
     */
    [Flags]
    public enum AUDIO_REVERB_PRESET
    {
        /**Turn off voice reverb, that is, to use the original voice.*/
        AUDIO_REVERB_OFF = 0x00000000, // Turn off audio reverb

        /**The reverb style typical of a KTV venue (enhanced).*/
        AUDIO_REVERB_FX_KTV = 0x00100001,

        /**The reverb style typical of a concert hall (enhanced).*/
        AUDIO_REVERB_FX_VOCAL_CONCERT = 0x00100002,

        /**A middle-aged man's voice.*/
        AUDIO_REVERB_FX_UNCLE = 0x00100003,

        /**The reverb style typical of a young woman's voice.*/
        AUDIO_REVERB_FX_SISTER = 0x00100004,

        /**The reverb style typical of a recording studio (enhanced).*/
        AUDIO_REVERB_FX_STUDIO = 0x00100005,

        /**The reverb style typical of popular music (enhanced).*/
        AUDIO_REVERB_FX_POPULAR = 0x00100006,

        /**The reverb style typical of R&B music (enhanced).*/
        AUDIO_REVERB_FX_RNB = 0x00100007,

        /**The voice effect typical of a vintage phonograph.*/
        AUDIO_REVERB_FX_PHONOGRAPH = 0x00100008,

        /**The voice effect typical of popular music.*/
        AUDIO_REVERB_POPULAR = 0x00000001,

        /**The voice effect typical of R&B music.*/
        AUDIO_REVERB_RNB = 0x00000002,

        /**The reverb style typical of rock music.*/
        AUDIO_REVERB_ROCK = 0x00000003,

        /**The reverb style typical of hip-hop music.*/
        AUDIO_REVERB_HIPHOP = 0x00000004,

        /**The voice effect typical of a concert hall.*/
        AUDIO_REVERB_VOCAL_CONCERT = 0x00000005,

        /**The voice effect typical of a KTV venue.*/
        AUDIO_REVERB_KTV = 0x00000006,

        /**The voice effect typical of a recording studio.*/
        AUDIO_REVERB_STUDIO = 0x00000007,

        /**The reverberation of the virtual stereo. The virtual stereo is an effect that renders the monophonic audio as the stereo audio, so that all users in the channel can hear the stereo voice effect.*/
        AUDIO_VIRTUAL_STEREO = 0x00200001,

        /**A pitch correction effect that corrects the user's pitch based on the pitch of the natural C major scale.*/
        AUDIO_ELECTRONIC_VOICE = 0x00300001,

        /**A 3D voice effect that makes the voice appear to be moving around the user.*/
        AUDIO_THREEDIM_VOICE = 0x00400001
    }

    /**
     * The options for SDK preset voice beautifier effects.
     */
    [Flags]
    public enum VOICE_BEAUTIFIER_PRESET
    {
        /**Turn off voice beautifier effects and use the original voice.*/
        VOICE_BEAUTIFIER_OFF = 0x00000000,

        /**
         * A more magnetic voice.
         *  Agora recommends using this enumerator to process a male-sounding voice; otherwise, you may experience vocal distortion.
         */
        CHAT_BEAUTIFIER_MAGNETIC = 0x01010100,

        /**
         * A fresher voice.
         *  Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion.
         *  
         */
        CHAT_BEAUTIFIER_FRESH = 0x01010200,

        /**
         * A more vital voice.
         *  Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion.
         *  
         */
        CHAT_BEAUTIFIER_VITALITY = 0x01010300,

        /**
         *  Singing beautifier effect. If you call SetVoiceBeautifierPreset (SINGING_BEAUTIFIER), you can beautify a male-sounding voice and add a reverberation effect that sounds like singing in a small room. Agora recommends using this enumerator to process a male-sounding voice; otherwise, you might experience vocal distortion.
         *  If you call SetVoiceBeautifierParameters (SINGING_BEAUTIFIER, param1, param2), you can beautify a male- or female-sounding voice and add a reverberation effect. 
         */
        SINGING_BEAUTIFIER = 0x01020100,

        /**A more vigorous voice.*/
        TIMBRE_TRANSFORMATION_VIGOROUS = 0x01030100,

        /**A deep voice.*/
        TIMBRE_TRANSFORMATION_DEEP = 0x01030200,

        /**A mellower voice.*/
        TIMBRE_TRANSFORMATION_MELLOW = 0x01030300,

        /**Falsetto.*/
        TIMBRE_TRANSFORMATION_FALSETTO = 0x01030400,

        /**A fuller voice.*/
        TIMBRE_TRANSFORMATION_FULL = 0x01030500,

        /**A clearer voice.*/
        TIMBRE_TRANSFORMATION_CLEAR = 0x01030600,

        /**A more resounding voice.*/
        TIMBRE_TRANSFORMATION_RESOUNDING = 0x01030700,

        /**A more ringing voice.*/
        TIMBRE_TRANSFORMATION_RINGING = 0x01030800
    }

    /**
     * Preset voice effects.
     * For better voice effects, Agora recommends setting the profile parameter of SetAudioProfile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO before using the following presets: ROOM_ACOUSTICS_KTV
     *  ROOM_ACOUSTICS_VOCAL_CONCERT
     *  ROOM_ACOUSTICS_STUDIO
     *  ROOM_ACOUSTICS_PHONOGRAPH
     *  ROOM_ACOUSTICS_SPACIAL
     *  ROOM_ACOUSTICS_ETHEREAL
     *  VOICE_CHANGER_EFFECT_UNCLE
     *  VOICE_CHANGER_EFFECT_OLDMAN
     *  VOICE_CHANGER_EFFECT_BOY
     *  VOICE_CHANGER_EFFECT_SISTER
     *  VOICE_CHANGER_EFFECT_GIRL
     *  VOICE_CHANGER_EFFECT_PIGKING
     *  VOICE_CHANGER_EFFECT_HULK
     *  PITCH_CORRECTION
     */
    [Flags]
    public enum AUDIO_EFFECT_PRESET
    {
        /**Turn off voice effects, that is, use the original voice.*/
        AUDIO_EFFECT_OFF = 0x00000000,

        /**The voice effect typical of a KTV venue.*/
        ROOM_ACOUSTICS_KTV = 0x02010100,

        /**The voice effect typical of a concert hall.*/
        ROOM_ACOUSTICS_VOCAL_CONCERT = 0x02010200,

        /**The voice effect typical of a recording studio.*/
        ROOM_ACOUSTICS_STUDIO = 0x02010300,

        /**The voice effect typical of a vintage phonograph.*/
        ROOM_ACOUSTICS_PHONOGRAPH = 0x02010400,

        /**
         * The virtual stereo effect, which renders monophonic audio as stereo audio.
         *  Before using this preset, set the profile parameter of SetAudioProfile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO; otherwise, the preset setting is invalid.
         *  
         */
        ROOM_ACOUSTICS_VIRTUAL_STEREO = 0x02010500,

        /**A more spatial voice effect.*/
        ROOM_ACOUSTICS_SPACIAL = 0x02010600,

        /**A more ethereal voice effect.*/
        ROOM_ACOUSTICS_ETHEREAL = 0x02010700,

        /**
         * A 3D voice effect that makes the voice appear to be moving around the user. The default movement cycle is 10 seconds. After setting this effect, you can call SetAudioEffectParameters to modify the movement period. Before using this preset, set the profile parameter of SetAudioProfile to AUDIO_PROFILE_MUSIC_STANDARD_STEREO or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO; otherwise, the preset setting is invalid.
         *  If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect. 
         */
        ROOM_ACOUSTICS_3D_VOICE = 0x02010800,

        /**
         * A middle-aged man's voice.
         *  Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
         *  
         */
        VOICE_CHANGER_EFFECT_UNCLE = 0x02020100,

        /**
         * A senior man's voice.
         *  Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
         *  
         */
        VOICE_CHANGER_EFFECT_OLDMAN = 0x02020200,

        /**
         * A boy's voice.
         *  Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
         *  
         */
        VOICE_CHANGER_EFFECT_BOY = 0x02020300,

        /**
         * A young woman's voice.
         *  Agora recommends using this preset to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect.
         *  
         */
        VOICE_CHANGER_EFFECT_SISTER = 0x02020400,

        /**
         * A girl's voice.
         *  Agora recommends using this preset to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect.
         *  
         */
        VOICE_CHANGER_EFFECT_GIRL = 0x02020500,

        /**The voice of Pig King, a character in Journey to the West who has a voice like a growling bear.*/
        VOICE_CHANGER_EFFECT_PIGKING = 0x02020600,

        /**The Hulk's voice.*/
        VOICE_CHANGER_EFFECT_HULK = 0x02020700,

        /**
         * The voice effect typical of R&B music.
         *  Before using this preset, set the profile parameter of SetAudioProfile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO; otherwise, the preset setting is invalid.
         *  
         */
        STYLE_TRANSFORMATION_RNB = 0x02030100,

        /**
         * The voice effect typical of popular music.
         *  Before using this preset, set the profile parameter of SetAudioProfile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO; otherwise, the preset setting is invalid.
         *  
         */
        STYLE_TRANSFORMATION_POPULAR = 0x02030200,

        /**A pitch correction effect that corrects the user's pitch based on the pitch of the natural C major scale. After setting this voice effect, you can call SetAudioEffectParameters to adjust the basic mode of tuning and the pitch of the main tone.*/
        PITCH_CORRECTION = 0x02040100
    }

    /**
     * The options for SDK preset voice conversion effects.
     */
    [Flags]
    public enum VOICE_CONVERSION_PRESET
    {
        /**Turn off voice conversion effects and use the original voice.*/
        VOICE_CONVERSION_OFF = 0x00000000,
        /**A gender-neutral voice. To avoid audio distortion, ensure that you use this enumerator to process a female-sounding voice.*/
        VOICE_CHANGER_NEUTRAL = 0x03010100,
        /**A sweet voice. To avoid audio distortion, ensure that you use this enumerator to process a female-sounding voice.*/
        VOICE_CHANGER_SWEET = 0x03010200,
        /**A steady voice. To avoid audio distortion, ensure that you use this enumerator to process a male-sounding voice.*/
        VOICE_CHANGER_SOLID = 0x03010300,
        /**A deep voice. To avoid audio distortion, ensure that you use this enumerator to process a male-sounding voice.*/
        VOICE_CHANGER_BASS = 0x03010400
    }

    /**
     * Self-defined audio codec profile.
     */
    public enum AUDIO_CODEC_PROFILE_TYPE
    {
        /**0: (Default) LC-AAC.*/
        AUDIO_CODEC_PROFILE_LC_AAC = 0,

        /**1: HE-AAC.*/
        AUDIO_CODEC_PROFILE_HE_AAC = 1,
        /**2: HE-AAC v2.*/
        AUDIO_CODEC_PROFILE_HE_AAC_V2 = 2,
    }

    /**
     * Remote audio states.
     */
    public enum REMOTE_AUDIO_STATE
    {
        /**0: The local audio is in the initial state. The SDK reports this state in the case of REMOTE_AUDIO_STATE_REASON_LOCAL_MUTED, REMOTE_AUDIO_STATE_REASON_REMOTE_MUTED or REMOTE_AUDIO_STATE_REASON_REMOTE_OFFLINE.*/
        REMOTE_AUDIO_STATE_STOPPED = 0, // Default state, audio is started or remote user disabled/muted audio stream

        /**1: The first remote audio packet is received.*/
        REMOTE_AUDIO_STATE_STARTING = 1, // The first audio frame packet has been received

        /**2: The remote audio stream is decoded and plays normally. The SDK reports this state in the case of REMOTE_AUDIO_STATE_REASON_NETWORK_RECOVERY, REMOTE_AUDIO_STATE_REASON_LOCAL_UNMUTED or REMOTE_AUDIO_STATE_REASON_REMOTE_UNMUTED.*/
        REMOTE_AUDIO_STATE_DECODING = 2, // The first remote audio frame has been decoded or fronzen state ends

        /**3: The remote audio is frozen. The SDK reports this state in the case of REMOTE_AUDIO_STATE_REASON_NETWORK_CONGESTION.*/
        REMOTE_AUDIO_STATE_FROZEN = 3, // Remote audio is frozen, probably due to network issue

        /**4: The remote audio fails to start. The SDK reports this state in the case of REMOTE_AUDIO_STATE_REASON_INTERNAL.*/
        REMOTE_AUDIO_STATE_FAILED = 4, // Remote audio play failed
    }

    /**
     * The reason for the remote audio state change.
     */
    public enum REMOTE_AUDIO_STATE_REASON
    {
        /**0: The SDK reports this reason when the audio state changes.*/
        REMOTE_AUDIO_REASON_INTERNAL = 0,

        /**1: Network congestion.*/
        REMOTE_AUDIO_REASON_NETWORK_CONGESTION = 1,

        /**2: Network recovery.*/
        REMOTE_AUDIO_REASON_NETWORK_RECOVERY = 2,

        /**3: The local user stops receiving the remote audio stream or disables the audio module.*/
        REMOTE_AUDIO_REASON_LOCAL_MUTED = 3,

        /**4: The local user resumes receiving the remote audio stream or enables the audio module.*/
        REMOTE_AUDIO_REASON_LOCAL_UNMUTED = 4,

        /**5: The remote user stops sending the audio stream or disables the audio module.*/
        REMOTE_AUDIO_REASON_REMOTE_MUTED = 5,

        /**6: The remote user resumes sending the audio stream or enables the audio module.*/
        REMOTE_AUDIO_REASON_REMOTE_UNMUTED = 6,

        /**7: The remote user leaves the channel.*/
        REMOTE_AUDIO_REASON_REMOTE_OFFLINE = 7,
    }

    /**
     * The state of the remote video.
     */
    public enum REMOTE_VIDEO_STATE
    {
        /**0: The remote video is in the initial state. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED, REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED or REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE.*/
        REMOTE_VIDEO_STATE_STOPPED = 0,

        /**1: The first remote video packet is received.*/
        REMOTE_VIDEO_STATE_STARTING = 1,

        /**2: The remote video stream is decoded and plays normally. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY, REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED,REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED, or REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY.*/
        REMOTE_VIDEO_STATE_DECODING = 2,

        /**3: The remote video is frozen. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION or REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK.*/
        REMOTE_VIDEO_STATE_FROZEN = 3,

        /**4: The remote video fails to start. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_INTERNAL.*/
        REMOTE_VIDEO_STATE_FAILED = 4
    }

    /**
     * The publishing state.
     */
    public enum STREAM_PUBLISH_STATE
    {
        /**0: The initial publishing state after joining the channel.*/
        PUB_STATE_IDLE = 0,

        /**
         * 1: Fails to publish the local stream. Possible reasons:
         *  The local user calls MuteLocalAudioStream (true) or MuteLocalVideoStream (true) to stop sending the local media stream.
         *  The local user calls DisableAudio or DisableVideo to disable the local audio or video module.
         *  The local user calls EnableLocalAudio (false) or EnableLocalVideo (false) to disable the local audio or video capture.
         *  The role of the local user is audience. 
         */
        PUB_STATE_NO_PUBLISHED = 1,

        /**2: Publishing.*/
        PUB_STATE_PUBLISHING = 2,

        /**3: Publishes successfully.*/
        PUB_STATE_PUBLISHED = 3
    }

    /**
     * The subscribing state.
     */
    public enum STREAM_SUBSCRIBE_STATE
    {
        /**0: The initial subscribing state after joining the channel.*/
        SUB_STATE_IDLE = 0,

        /**
         * 1: Fails to subscribe to the remote stream. Possible reasons:
         *  The remote user:
         * Calls MuteLocalAudioStream (true) or MuteLocalVideoStream (true) to stop sending local media stream.
         * Calls DisableAudio or DisableVideo to disable the local audio or video module.
         *  Calls EnableLocalAudio (false) or EnableLocalVideo (false) to disable the local audio or video capture.
         *  The role of the remote user is audience. The local user calls the following methods to stop receiving remote streams:
         *  Calls MuteRemoteAudioStream (true), MuteAllRemoteAudioStreams (true) or SetDefaultMuteAllRemoteAudioStreams (true) to stop receiving the remote audio streams.
         *  Calls MuteRemoteVideoStream (true), MuteAllRemoteVideoStreams (true) or SetDefaultMuteAllRemoteVideoStreams (true) to stop receiving the remote video streams. 
         */
        SUB_STATE_NO_SUBSCRIBED = 1,

        /**2: Subscribing.*/
        SUB_STATE_SUBSCRIBING = 2,

        /**3: Subscribes to and receives the remote stream successfully.*/
        SUB_STATE_SUBSCRIBED = 3
    }

    public enum XLA_REMOTE_VIDEO_FROZEN_TYPE
    {
        XLA_REMOTE_VIDEO_FROZEN_500MS = 0,

        XLA_REMOTE_VIDEO_FROZEN_200MS = 1,

        XLA_REMOTE_VIDEO_FROZEN_600MS = 2,

        XLA_REMOTE_VIDEO_FROZEN_TYPE_MAX = 3,
    }

    public enum XLA_REMOTE_AUDIO_FROZEN_TYPE
    {
        XLA_REMOTE_AUDIO_FROZEN_80MS = 0,

        XLA_REMOTE_AUDIO_FROZEN_200MS = 1,

        XLA_REMOTE_AUDIO_FROZEN_TYPE_MAX = 2,
    }

    /**
     * The reason for the remote video state change.
     */
    public enum REMOTE_VIDEO_STATE_REASON
    {
        /**0: The SDK reports this reason when the video state changes.*/
        REMOTE_VIDEO_STATE_REASON_INTERNAL = 0,

        /**1: Network congestion.*/
        REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION = 1,

        /**2: Network recovery.*/
        REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY = 2,

        /**
         * 3: The local user stops receiving the remote
         *  video stream or disables the video module.
         */
        REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED = 3,

        /**4: The local user resumes receiving the remote video stream or enables the video module.*/
        REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED = 4,

        /**5: The remote user stops sending the video stream or disables the video module.*/
        REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED = 5,

        /**6: The remote user resumes sending the video stream or enables the video module.*/
        REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED = 6,

        /**7: The remote user leaves the channel.*/
        REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE = 7,

        /**8: The remote audio-and-video stream falls back to the audio-only stream due to poor network conditions.*/
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK = 8,

        /**9: The remote audio-only stream switches back to the audio-and-video stream after the network conditions improve.*/
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY = 9
    }

    /**
     * Video frame rate.
     */
    public enum FRAME_RATE
    {
        /**1: 1 fps*/
        FRAME_RATE_FPS_1 = 1,

        /**7: 7 fps*/
        FRAME_RATE_FPS_7 = 7,

        /**10: 10 fps*/
        FRAME_RATE_FPS_10 = 10,

        /**15: 15 fps*/
        FRAME_RATE_FPS_15 = 15,

        /**24: 24 fps*/
        FRAME_RATE_FPS_24 = 24,

        /**30: 30 fps*/
        FRAME_RATE_FPS_30 = 30,

        /**
         * 60: 60 fps
         *  (For Windows and macOS only)
         */
        FRAME_RATE_FPS_60 = 60,
    }

    /**
     * Video output orientation modes.
     */
    public enum ORIENTATION_MODE
    {
        /**
         * 0: (Default) The output video always follows the orientation of the captured video. The receiver takes the rotational information passed on from the video encoder. This mode applies to scenarios where video orientation can be adjusted on the receiver. If the captured video is in landscape mode, the output video is in landscape mode.
         *  If the captured video is in portrait mode, the output video is in portrait mode. 
         */
        ORIENTATION_MODE_ADAPTIVE = 0,

        /**1: In this mode, the SDK always outputs videos in landscape (horizontal) mode. If the captured video is in portrait mode, the video encoder crops it to fit the output. Applies to situations where the receiving end cannot process the rotational information. For example, CDN live streaming.*/
        ORIENTATION_MODE_FIXED_LANDSCAPE = 1,

        /**2: In this mode, the SDK always outputs video in portrait (portrait) mode. If the captured video is in landscape mode, the video encoder crops it to fit the output. Applies to situations where the receiving end cannot process the rotational information. For example, CDN live streaming.*/
        ORIENTATION_MODE_FIXED_PORTRAIT = 2,
    }

    /**
     * Video degradation preferences when the bandwidth is a constraint.
     */
    public enum DEGRADATION_PREFERENCE
    {
        /**
         * 0: (Default) Prefers to reduce the video frame rate while maintaining video quality during video encoding under limited bandwidth. This degradation preference is suitable for scenarios where video quality is prioritized.
         *  In the COMMUNICATION channel profile, the resolution of the video sent may change, so remote users need to handle this issue. See OnVideoSizeChanged .
         */
        MAINTAIN_QUALITY = 0,

        /**1: Prefers to reduce the video quality while maintaining the video frame rate during video encoding under limited bandwidth. This degradation preference is suitable for scenarios where smoothness is prioritized and video quality is allowed to be reduced.*/
        MAINTAIN_FRAMERATE = 1,

        /**
         *  2: Reduces the video frame rate and video quality simultaneously during video encoding under limited bandwidth. MAINTAIN_BALANCED has a lower reduction than MAINTAIN_QUALITY and MAINTAIN_FRAMERATE, and this preference is suitable for scenarios where both smoothness and video quality are a priority.
         *  The resolution of the video sent may change, so remote users need to handle this issue. See OnVideoSizeChanged .
         *  
         */
        MAINTAIN_BALANCED = 2,
    }

    /**
     * Stream fallback options.
     */
    public enum STREAM_FALLBACK_OPTIONS
    {
        /**0: No fallback behavior for the local/remote video stream when the uplink/downlink network conditions are poor. The quality of the stream is not guaranteed.*/
        STREAM_FALLBACK_OPTION_DISABLED = 0,

        /**1: Under poor downlink network conditions, the remote video stream, to which you subscribe, falls back to the low-quality (low resolution and low bitrate) video stream. This option is only valid for SetRemoteSubscribeFallbackOption . This option is invalid for SetLocalPublishFallbackOption method.*/
        STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW = 1,

        /**2: Under poor uplink network conditions, the published video stream falls back to audio-only. Under poor downlink network conditions, the remote video stream, to which you subscribe, first falls back to the low-quality (low resolution and low bitrate) video stream; and then to an audio-only stream if the network conditions worsen.*/
        STREAM_FALLBACK_OPTION_AUDIO_ONLY = 2,
    }

    /**
     * Camera capture preference.
     */
    public enum CAPTURER_OUTPUT_PREFERENCE
    {
        /**0: (Default) Automatically adjust the camera capture preference. The SDK adjusts the camera output parameters according to the system performance and network conditions to balance CPU consumption and video preview quality.*/
        CAPTURER_OUTPUT_PREFERENCE_AUTO = 0,

        /**1: Prioritizes the system performance. The SDK chooses the dimension and frame rate of the local camera capture closest to those set by SetVideoEncoderConfiguration . In this case, the local preview quality depends on the encoder.*/
        CAPTURER_OUTPUT_PREFERENCE_PERFORMANCE = 1,

        /**2: Prioritizes the local preview quality. The SDK chooses higher camera output parameters to improve the local video preview quality. This option requires extra CPU and RAM usage for video pre-processing.*/
        CAPTURER_OUTPUT_PREFERENCE_PREVIEW = 2,

        /**
         *  3: Allows you to customize the width and height of the video image captured by the local camera.
         *  
         */
        CAPTURER_OUTPUT_PREFERENCE_MANUAL = 3,
    }

    /**
     * The priority of the remote user.
     */
    public enum PRIORITY_TYPE
    {
        /**The user's priority is high.*/
        PRIORITY_HIGH = 50,

        /**(Default) The user's priority is normal.*/
        PRIORITY_NORMAL = 100,
    }

    /**
     * Connection states.
     */
    public enum CONNECTION_STATE_TYPE
    {
        /**
         * 1: The SDK is disconnected from the Agora edge server. The state indicates the SDK is in one of the following phases:
         *  The initial state before calling the JoinChannel [2/2] method.
         *  The app calls the LeaveChannel method. 
         */
        CONNECTION_STATE_DISCONNECTED = 1,

        /**
         * 2: The SDK is connecting to the Agora edge server. This state indicates that the SDK is establishing a connection with the specified channel after the app calls JoinChannel [2/2].
         *  If the SDK successfully joins the channel, it triggers the OnConnectionStateChanged callback and the connection state switches to CONNECTION_STATE_CONNECTED.
         *  After the connection is established, the SDK also initializes the media and triggers OnJoinChannelSuccess when everything is ready. 
         */
        CONNECTION_STATE_CONNECTING = 2,

        /**3: The SDK is connected to the Agora edge server. This state also indicates that the user has joined a channel and can now publish or subscribe to a media stream in the channel. If the connection to the Agora edge server is lost because, for example, the network is down or switched, the SDK automatically tries to reconnect and triggers OnConnectionStateChanged that indicates the connection state switches to CONNECTION_STATE_RECONNECTING.*/
        CONNECTION_STATE_CONNECTED = 3,

        /**
         * 4: The SDK keeps reconnecting to the Agora edge server. The SDK keeps rejoining the channel after being disconnected from a joined channel because of network issues.
         *  If the SDK cannot rejoin the channel within 10 seconds, it triggers OnConnectionLost , stays in the CONNECTION_STATE_RECONNECTING state, and keeps rejoining the channel.
         *  If the SDK fails to rejoin the channel 20 minutes after being disconnected from the Agora edge server, the SDK triggers the OnConnectionStateChanged callback, switches to the CONNECTION_STATE_FAILED state, and stops rejoining the channel.
         *  
         */
        CONNECTION_STATE_RECONNECTING = 4,

        /**
         * 5: The SDK fails to connect to the Agora edge server or join the channel. This state indicates that the SDK stops trying to rejoin the channel. You must call LeaveChannel to leave the channel.
         *  You can call JoinChannel [2/2] to rejoin the channel.
         *  If the SDK is banned from joining the channel by the Agora edge server through the RESTful API, the SDK triggers the OnConnectionStateChanged callback.
         *  
         */
        CONNECTION_STATE_FAILED = 5,
    }

    /**
     * Reasons causing the change of the connection state.
     */
    public enum CONNECTION_CHANGED_REASON_TYPE
    {
        /**0: The SDK is connecting to the Agora edge server.*/
        CONNECTION_CHANGED_CONNECTING = 0,

        /**1: The SDK has joined the channel successfully.*/
        CONNECTION_CHANGED_JOIN_SUCCESS = 1,

        /**2: The connection between the SDK and the Agora edge server is interrupted.*/
        CONNECTION_CHANGED_INTERRUPTED = 2,

        /**3: The connection between the SDK and the Agora edge server is banned by the Agora edge server. This error occurs when the user is kicked out of the channel by the server.*/
        CONNECTION_CHANGED_BANNED_BY_SERVER = 3,

        /**4: The SDK fails to join the channel. When the SDK fails to join the channel for more than 20 minutes, this error occurs and the SDK stops reconnecting to the channel.*/
        CONNECTION_CHANGED_JOIN_FAILED = 4,

        /**5: The SDK has left the channel.*/
        CONNECTION_CHANGED_LEAVE_CHANNEL = 5,

        /**6: The connection failed because the App ID is not valid. Please rejoin the channel with a valid App ID.*/
        CONNECTION_CHANGED_INVALID_APP_ID = 6,

        /**7: The connection failed since channel name is not valid. Please rejoin the channel with a valid channel name.*/
        CONNECTION_CHANGED_INVALID_CHANNEL_NAME = 7,

        /**
         * 8: The connection failed because the token is not valid. Typical reasons include:
         *  The App Certificate for the project is enabled in Agora Console, but you do not use a token when joining the channel. If you enable the App Certificate, you must use a token to join the channel.
         *  The uid specified when calling JoinChannel [2/2] to join the channel is inconsistent with the uid passed in when generating the token.
         *  
         */
        CONNECTION_CHANGED_INVALID_TOKEN = 8,

        /**9: The connection failed since token is expired.*/
        CONNECTION_CHANGED_TOKEN_EXPIRED = 9,

        /**
         * 10: The connection is rejected by server. Typical reasons include:
         *  The user is already in the channel and still calls a method, for example, JoinChannel [2/2], to join the channel. Stop calling this method to clear this error.
         *  The user tries to join the channel when conducting a pre-call test. The user needs to call the channel after the call test ends. 
         */
        CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,

        /**11: The connection state changed to reconnecting because the SDK has set a proxy server.*/
        CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,

        /**12: The connection state changed because the token is renewed.*/
        CONNECTION_CHANGED_RENEW_TOKEN = 12,

        /**13: The IP address of the client has changed, possibly because the network type, IP address, or port has been changed.*/
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,

        /**14: Timeout for the keep-alive of the connection between the SDK and the Agora edge server. The connection state changes to CONNECTION_STATE_RECONNECTING.*/
        CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,

        /// @cond nodoc
        CONNECTION_CHANGED_SAME_UID_LOGIN = 19,
        CONNECTION_CHANGED_TOO_MANY_BROADCASTERS = 20,
        /// @endcond
    }

    /**
     * Network type.
     */
    public enum NETWORK_TYPE
    {
        /**-1: The network type is unknown.*/
        NETWORK_TYPE_UNKNOWN = -1,

        /**0: The SDK disconnects from the network.*/
        NETWORK_TYPE_DISCONNECTED = 0,

        /**1: The network type is LAN.*/
        NETWORK_TYPE_LAN = 1,

        /**2: The network type is Wi-Fi (including hotspots).*/
        NETWORK_TYPE_WIFI = 2,

        /**3: The network type is mobile 2G.*/
        NETWORK_TYPE_MOBILE_2G = 3,

        /**4: The network type is mobile 3G.*/
        NETWORK_TYPE_MOBILE_3G = 4,

        /**5: The network type is mobile 4G.*/
        NETWORK_TYPE_MOBILE_4G = 5,

        /**6: The network type is mobile 5G.*/
        NETWORK_TYPE_MOBILE_5G = 6
    }

    /// @cond
    /**
     * The reason for the upload failure.
     */
    public enum UPLOAD_ERROR_REASON
    {
        /**0: Successfully upload the log files.*/
        UPLOAD_SUCCESS = 0,

        /**1: Network error. Check the network connection and call UploadLogFile again to upload the log file.*/
        UPLOAD_NET_ERROR = 1,

        /**2: An error occurs in the Agora server. Try uploading the log files later.*/
        UPLOAD_SERVER_ERROR = 2,
    }

    /// @endcond
    /**
     * The status of the last-mile network tests.
     */
    public enum LASTMILE_PROBE_RESULT_STATE
    {
        /**1: The last-mile network probe test is complete.*/
        LASTMILE_PROBE_RESULT_COMPLETE = 1,

        /**2: The last-mile network probe test is incomplete because the bandwidth estimation is not available due to limited test resources.*/
        LASTMILE_PROBE_RESULT_INCOMPLETE_NO_BWE = 2,

        /**3: The last-mile network probe test is not carried out, probably due to poor network conditions.*/
        LASTMILE_PROBE_RESULT_UNAVAILABLE = 3
    }

    /**
     * The type of the audio route.
     */
    public enum AUDIO_ROUTE_TYPE
    {
        /**-1: The default audio route.*/
        AUDIO_ROUTE_DEFAULT = -1,

        /**0: The headset.*/
        AUDIO_ROUTE_HEADSET = 0,

        /**1: The earpiece.*/
        AUDIO_ROUTE_EARPIECE = 1,

        /**2: The headset with no microphone.*/
        AUDIO_ROUTE_HEADSET_NO_MIC = 2,

        /**3: The built-in speaker on a mobile device.*/
        AUDIO_ROUTE_SPEAKERPHONE = 3,

        /**4: The external speaker.*/
        AUDIO_ROUTE_LOUDSPEAKER = 4,

        /**5: The bluetooth headset.*/
        AUDIO_ROUTE_BLUETOOTH = 5,

        AUDIO_ROUTE_USB = 6,

        AUDIO_ROUTE_HDMI = 7,

        AUDIO_ROUTE_DISPLAYPORT = 8,

        AUDIO_ROUTE_AIRPLAY = 9,
    }

    /**
     * The cloud proxy type.
     */
    public enum CLOUD_PROXY_TYPE
    {
        /**0: The automatic mode. In this mode, the SDK attempts a direct connection to SD-RTN™ and automatically switches to TCP/TLS 443 if the attempt fails. As of v3.6.2, the SDK has this mode enabled by default.*/
        NONE_PROXY = 0,

        /**1: The cloud proxy for the UDP protocol, that is, the Force UDP cloud proxy mode. In this mode, the SDK always transmits data over UDP.*/
        UDP_PROXY = 1,

        /// @cond
        /**2: The cloud proxy for the TCP (encryption) protocol, that is, the Force TCP cloud proxy mode. In this mode, the SDK always transmits data over TCP/TLS 443.*/
        TCP_PROXY = 2,
        /// @endcond
    }

    /**
     * The operational permission of the SDK on the audio session.
     */
    [Flags]
    public enum AUDIO_SESSION_OPERATION_RESTRICTION
    {
        /**No restriction, the SDK has full control of the audio session operations.*/
        AUDIO_SESSION_OPERATION_RESTRICTION_NONE = 0,

        /**The SDK does not change the audio session category.*/
        AUDIO_SESSION_OPERATION_RESTRICTION_SET_CATEGORY = 1,

        /**The SDK does not change any setting of the audio session (category, mode, categoryOptions).*/
        AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION = 1 << 1,

        /**The SDK keeps the audio session active when leaving a channel.*/
        AUDIO_SESSION_OPERATION_RESTRICTION_DEACTIVATE_SESSION = 1 << 2,

        /**The SDK does not configure the audio session anymore.*/
        AUDIO_SESSION_OPERATION_RESTRICTION_ALL = 1 << 7,
    }

    /**
     * The camera direction.
     */
    public enum CAMERA_DIRECTION
    {
        /**The rear camera.*/
        CAMERA_REAR = 0,

        /**The front camera.*/
        CAMERA_FRONT = 1,
    }

    /**
     * Results of the uplink or downlink last-mile network test.
     */
    public class LastmileProbeOneWayResult
    {
        public LastmileProbeOneWayResult()
        {
        }

        public LastmileProbeOneWayResult(uint packetLossRate, uint jitter, uint availableBandwidth)
        {
            this.packetLossRate = packetLossRate;
            this.jitter = jitter;
            this.availableBandwidth = availableBandwidth;
        }

        /**The packet loss rate (%).*/
        public uint packetLossRate { set; get; }

        /**The network jitter (ms).*/
        public uint jitter { set; get; }

        /**The estimated available bandwidth (bps).*/
        public uint availableBandwidth { set; get; }
    }

    /**
     * Results of the uplink and downlink last-mile network tests.
     */
    public class LastmileProbeResult
    {
        public LastmileProbeResult()
        {
        }

        public LastmileProbeResult(LASTMILE_PROBE_RESULT_STATE state, LastmileProbeOneWayResult uplinkReport,
            LastmileProbeOneWayResult downlinkReport, uint rtt)
        {
            this.state = state;
            this.uplinkReport = uplinkReport;
            this.downlinkReport = downlinkReport;
            this.rtt = rtt;
        }

        /**
         * The status of the last-mile network tests. See LASTMILE_PROBE_RESULT_STATE .
         *  
         */
        public LASTMILE_PROBE_RESULT_STATE state { set; get; }

        /**Results of the uplink last-mile network test. */
        public LastmileProbeOneWayResult uplinkReport { set; get; }

        /**Results of the downlink last-mile network test. */
        public LastmileProbeOneWayResult downlinkReport { set; get; }

        /**The round-trip time (ms).*/
        public uint rtt { set; get; }
    }

    /**
     * Configurations of the last-mile network test.
     */
    public class LastmileProbeConfig
    {
        public LastmileProbeConfig()
        {
        }

        public LastmileProbeConfig(bool probeUplink, bool probeDownlink, uint expectedUplinkBitrate,
            uint expectedDownlinkBitrate)
        {
            this.probeUplink = probeUplink;
            this.probeDownlink = probeDownlink;
            this.expectedUplinkBitrate = expectedUplinkBitrate;
            this.expectedDownlinkBitrate = expectedDownlinkBitrate;
        }

        /**
         * Sets whether to test the uplink network. Some users, for example, the audience members in a LIVE_BROADCASTING channel, do not need such a test. true: Test.
         *  false: Not test. 
         */
        public bool probeUplink { set; get; }

        /**
         * Sets whether to test the downlink network: true: Test.
         *  false: Not test. 
         */
        public bool probeDownlink { set; get; }

        /**The expected maximum uplink bitrate (bps) of the local user. The value range is [100000, 5000000]. Agora recommends referring to SetVideoEncoderConfiguration to set the value.*/
        public uint expectedUplinkBitrate { set; get; }

        /**The expected maximum downlink bitrate (bps) of the local user. The value range is [100000,5000000].*/
        public uint expectedDownlinkBitrate { set; get; }
    }

    /**
     * The volume information of users.
     */
    public class AudioVolumeInfo
    {
        public AudioVolumeInfo()
        {
        }

        public AudioVolumeInfo(uint uid, uint volume, uint vad, string channelId)
        {
            this.uid = uid;
            this.volume = volume;
            this.vad = vad;
            this.channelId = channelId;
        }

        /**
         * The user ID. In the local user's callback, uid = 0.
         *  In the remote users' callback, uid is the user ID of a remote user whose instantaneous volume is one of the three highest. 
         */
        public uint uid { set; get; }

        /**The volume of the user. The value ranges between 0 (lowest volume) and 255 (highest volume). If the user calls StartAudioMixing [2/2] , the value of volume is the volume after audio mixing.*/
        public uint volume { set; get; }

        /**
         * The voice activity status of the local user. 0: The local user is not speaking.
         *  1: The local user is speaking. 
         *  The vad parameter does not report the voice activity status of remote users. In the remote users' callback, the value of vad is always 0.
         *  To use this parameter, you must set reportVad to true when calling EnableAudioVolumeIndication .
         *  
         */
        public uint vad { set; get; }


        /**The name of the channel that the user is in.*/
        public string channelId { set; get; }
    }

    /**
     * The detailed options of a user.
     */
    public class ClientRoleOptions
    {
        public ClientRoleOptions()
        {
            audienceLatencyLevel = AUDIENCE_LATENCY_LEVEL_TYPE.AUDIENCE_LATENCY_LEVEL_LOW_LATENCY;
        }

        public ClientRoleOptions(AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel)
        {
            this.audienceLatencyLevel = audienceLatencyLevel;
        }

        /**
         * The latency level of an audience member in interactive live streaming. See AUDIENCE_LATENCY_LEVEL_TYPE .
         *  
         */
        public AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel;
    }

    /**
     * Statistics of a call session.
     */
    public class RtcStats
    {
        public RtcStats()
        {
        }

        public RtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes, uint txVideoBytes,
            uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate, ushort rxAudioKBitRate,
            ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate, ushort lastmileDelay,
            ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount, double cpuAppUsage, double cpuTotalUsage,
            int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
        {
            this.duration = duration;
            this.txBytes = txBytes;
            this.rxBytes = rxBytes;
            this.txAudioBytes = txAudioBytes;
            this.txVideoBytes = txVideoBytes;
            this.rxAudioBytes = rxAudioBytes;
            this.rxVideoBytes = rxVideoBytes;
            this.txKBitRate = txKBitRate;
            this.rxKBitRate = rxKBitRate;
            this.rxAudioKBitRate = rxAudioKBitRate;
            this.txAudioKBitRate = txAudioKBitRate;
            this.rxVideoKBitRate = rxVideoKBitRate;
            this.txVideoKBitRate = txVideoKBitRate;
            this.lastmileDelay = lastmileDelay;
            this.txPacketLossRate = txPacketLossRate;
            this.rxPacketLossRate = rxPacketLossRate;
            this.userCount = userCount;
            this.cpuAppUsage = cpuAppUsage;
            this.cpuTotalUsage = cpuTotalUsage;
            this.gatewayRtt = gatewayRtt;
            this.memoryAppUsageRatio = memoryAppUsageRatio;
            this.memoryTotalUsageRatio = memoryTotalUsageRatio;
            this.memoryAppUsageInKbytes = memoryAppUsageInKbytes;
        }

        /**Call duration of the local user in seconds, represented by an aggregate value.*/
        public uint duration { set; get; }

        /**The number of bytes sent.*/
        public uint txBytes { set; get; }

        /**The number of bytes received.*/
        public uint rxBytes { set; get; }

        /**The total number of audio bytes sent, represented by an aggregate value.*/
        public uint txAudioBytes { set; get; }

        /**The total number of video bytes sent, represented by an aggregate value.*/
        public uint txVideoBytes { set; get; }

        /**The total number of audio bytes received, represented by an aggregate value.*/
        public uint rxAudioBytes { set; get; }

        /**The total number of video bytes received, represented by an aggregate value.*/
        public uint rxVideoBytes { set; get; }

        /**Video transmission bitrate (Kbps), represented by an instantaneous value.*/
        public ushort txKBitRate { set; get; }

        /**The receiving bitrate (Kbps), represented by an instantaneous value.*/
        public ushort rxKBitRate { set; get; }

        /**Audio receive bitrate (Kbps), represented by an instantaneous value.*/
        public ushort rxAudioKBitRate { set; get; }

        /**The bitrate (Kbps) of sending the audio packet.*/
        public ushort txAudioKBitRate { set; get; }

        /**Video receive bitrate (Kbps), represented by an instantaneous value.*/
        public ushort rxVideoKBitRate { set; get; }

        /**The bitrate (Kbps) of sending the video.*/
        public ushort txVideoKBitRate { set; get; }

        /**The client-to-server delay (milliseconds).*/
        public ushort lastmileDelay { set; get; }

        /**The packet loss rate (%) from the client to the Agora server before applying the anti-packet-loss algorithm.*/
        public ushort txPacketLossRate { set; get; }

        /**The packet loss rate (%) from the Agora server to the client before using the anti-packet-loss method.*/
        public ushort rxPacketLossRate { set; get; }

        /**The number of users in the channel.*/
        public uint userCount { set; get; }

        /**The CPU usage (%) of the app.*/
        public double cpuAppUsage { set; get; }

        /**
         * The system CPU usage (%).
         *  For Windows, in the multi-kernel environment, this member represents the average CPU usage. The value = 100 - System Idle Progress in Task Manager.
         *  The value of cpuTotalUsage is always reported as 0 in the OnLeaveChannel callback.
         */
        public double cpuTotalUsage { set; get; }

        /**
         * The round-trip time delay (ms) from the client to the local router.
         *  
         */
        public int gatewayRtt { set; get; }

        /**
         * The memory ratio occupied by the app (%).
         *  This value is for reference only. Due to system limitations, you may not get this value.
         *  
         */
        public double memoryAppUsageRatio { set; get; }

        /**
         * The memory occupied by the system (%).
         *  This value is for reference only. Due to system limitations, you may not get this value.
         *  
         */
        public double memoryTotalUsageRatio { set; get; }

        /**
         * The memory size occupied by the app (KB).
         *  This value is for reference only. Due to system limitations, you may not get this value.
         *  
         */
        public int memoryAppUsageInKbytes { set; get; }
    }

    /**
     * Quality change of the local video in terms of target frame rate and target bit rate since last count.
     */
    public enum QUALITY_ADAPT_INDICATION
    {
        /**0: The local video quality stays the same.*/
        ADAPT_NONE = 0,

        /**1: The local video quality improves because the network bandwidth increases.*/
        ADAPT_UP_BANDWIDTH = 1,

        /**2: The local video quality deteriorates because the network bandwidth decreases.*/
        ADAPT_DOWN_BANDWIDTH = 2,
    }

    /**
     * The Quality of Experience (QoE) of the local user when receiving a remote audio stream.
     */
    public enum EXPERIENCE_QUALITY_TYPE
    {
        /**0: The QoE of the local user is good.*/
        EXPERIENCE_QUALITY_GOOD = 0,

        /**1: The QoE of the local user is poor.*/
        EXPERIENCE_QUALITY_BAD = 1,
    }

    /**
     * Reasons why the QoE of the local user when receiving a remote audio stream is poor.
     */
    public enum EXPERIENCE_POOR_REASON
    {
        /**0: No reason, indicating a good QoE of the local user.*/
        EXPERIENCE_REASON_NONE = 0,

        /**1: The remote user's network quality is poor.*/
        REMOTE_NETWORK_QUALITY_POOR = 1,

        /**2: The local user's network quality is poor.*/
        LOCAL_NETWORK_QUALITY_POOR = 2,

        /**4: The local user's Wi-Fi or mobile network signal is weak.*/
        WIRELESS_SIGNAL_POOR = 4,

        /**8: The local user enables both Wi-Fi and bluetooth, and their signals interfere with each other. As a result, audio transmission quality is undermined.*/
        WIFI_BLUETOOTH_COEXIST = 8,
    }

    /**
     * The error code of the channel media replay.
     */
    public enum CHANNEL_MEDIA_RELAY_ERROR
    {
        /**0: No error.*/
        RELAY_OK = 0,

        /**1: An error occurs in the server response.*/
        RELAY_ERROR_SERVER_ERROR_RESPONSE = 1,

        /**
         * 2: No server response.
         *  You can call LeaveChannel to leave the channel.
         *  This error can also occur if your project has not enabled co-host token authentication. You can to enable the co-host token authentication service before starting a channel media relay.
         *  
         */
        RELAY_ERROR_SERVER_NO_RESPONSE = 2,

        /**3: The SDK fails to access the service, probably due to limited resources of the server.*/
        RELAY_ERROR_NO_RESOURCE_AVAILABLE = 3,

        /**4: Fails to send the relay request.*/
        RELAY_ERROR_FAILED_JOIN_SRC = 4,

        /**5: Fails to accept the relay request.*/
        RELAY_ERROR_FAILED_JOIN_DEST = 5,

        /**6: The server fails to receive the media stream.*/
        RELAY_ERROR_FAILED_PACKET_RECEIVED_FROM_SRC = 6,

        /**7: The server fails to send the media stream.*/
        RELAY_ERROR_FAILED_PACKET_SENT_TO_DEST = 7,

        /**8: The SDK disconnects from the server due to poor network connections. You can call the LeaveChannel method to leave the channel.*/
        RELAY_ERROR_SERVER_CONNECTION_LOST = 8,

        /**9: An internal error occurs in the server.*/
        RELAY_ERROR_INTERNAL_ERROR = 9,

        /**10: The token of the source channel has expired.*/
        RELAY_ERROR_SRC_TOKEN_EXPIRED = 10,

        /**11: The token of the destination channel has expired.*/
        RELAY_ERROR_DEST_TOKEN_EXPIRED = 11,
    }

    /**
     * The event code of channel media relay.
     */
    public enum CHANNEL_MEDIA_RELAY_EVENT
    {
        /**0: The user disconnects from the server due to a poor network connection.*/
        RELAY_EVENT_NETWORK_DISCONNECTED = 0,

        /**1: The user is connected to the server.*/
        RELAY_EVENT_NETWORK_CONNECTED = 1,

        /**2: The user joins the source channel.*/
        RELAY_EVENT_PACKET_JOINED_SRC_CHANNEL = 2,

        /**3: The user joins the destination channel.*/
        RELAY_EVENT_PACKET_JOINED_DEST_CHANNEL = 3,

        /**4: The SDK starts relaying the media stream to the destination channel.*/
        RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL = 4,

        /**5: The server receives the audio stream from the source channel.*/
        RELAY_EVENT_PACKET_RECEIVED_VIDEO_FROM_SRC = 5,

        /**6: The server receives the audio stream from the source channel.*/
        RELAY_EVENT_PACKET_RECEIVED_AUDIO_FROM_SRC = 6,

        /**7: The destination channel is updated.*/
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL = 7,

        /**8: The destination channel update fails due to internal reasons.*/
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_REFUSED = 8,

        /**9: The destination channel does not change, which means that the destination channel fails to be updated.*/
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_NOT_CHANGE = 9,

        /**10: The destination channel name is NULL.*/
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_IS_NULL = 10,

        /**11: The video profile is sent to the server.*/
        RELAY_EVENT_VIDEO_PROFILE_UPDATE = 11,

        /**12: The SDK successfully pauses relaying the media stream to destination channels.*/
        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 12,

        /**13: The SDK fails to pause relaying the media stream to destination channels.*/
        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 13,

        /**14: The SDK successfully resumes relaying the media stream to destination channels.*/
        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 14,

        /**15: The SDK fails to resume relaying the media stream to destination channels.*/
        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 15
    }

    /**
     * The state code of the channel media relay.
     */
    public enum CHANNEL_MEDIA_RELAY_STATE
    {
        /**0: The initial state. After you successfully stop the channel media relay by calling StopChannelMediaRelay , the OnChannelMediaRelayStateChanged callback returns this state.*/
        RELAY_STATE_IDLE = 0,

        /**1: The SDK tries to relay the media stream to the destination channel.*/
        RELAY_STATE_CONNECTING = 1,

        /**2: The SDK successfully relays the media stream to the destination channel.*/
        RELAY_STATE_RUNNING = 2,

        /**3: An error occurs. See code in OnChannelMediaRelayStateChanged for the error code.*/
        RELAY_STATE_FAILURE = 3,
    }

    /**
     * The statistics of the local video stream.
     */
    public class LocalVideoStats
    {
        public LocalVideoStats()
        {
        }

        public LocalVideoStats(int sentBitrate, int sentFrameRate, int encoderOutputFrameRate,
            int rendererOutputFrameRate, int targetBitrate, int targetFrameRate,
            QUALITY_ADAPT_INDICATION qualityAdaptIndication, int encodedBitrate, int encodedFrameWidth,
            int encodedFrameHeight, int encodedFrameCount, VIDEO_CODEC_TYPE codecType, ushort txPacketLossRate,
            int captureFrameRate)
        {
            this.sentBitrate = sentBitrate;
            this.sentFrameRate = sentFrameRate;
            this.encoderOutputFrameRate = encoderOutputFrameRate;
            this.rendererOutputFrameRate = rendererOutputFrameRate;
            this.targetBitrate = targetBitrate;
            this.targetFrameRate = targetFrameRate;
            this.qualityAdaptIndication = qualityAdaptIndication;
            this.encodedBitrate = encodedBitrate;
            this.encodedFrameWidth = encodedFrameWidth;
            this.encodedFrameHeight = encodedFrameHeight;
            this.encodedFrameCount = encodedFrameCount;
            this.codecType = codecType;
            this.txPacketLossRate = txPacketLossRate;
            this.captureFrameRate = captureFrameRate;
        }

        /**
         * The actual bitrate (Kbps) while sending the local video stream.This value does not include the bitrate for resending the video after packet loss.
         *  
         */
        public int sentBitrate { set; get; }

        /**The actual frame rate (fps) while sending the local video stream.This value does not include the frame rate for resending the video after packet loss.*/
        public int sentFrameRate { set; get; }

        /**The output frame rate (fps) of the local video encoder.*/
        public int encoderOutputFrameRate { set; get; }

        /**The output frame rate (fps) of the local video renderer.*/
        public int rendererOutputFrameRate { set; get; }

        /**The target bitrate (Kbps) of the current encoder. This is an estimate made by the SDK based on the current network conditions.*/
        public int targetBitrate { set; get; }

        /**The target frame rate (fps) of the current encoder.*/
        public int targetFrameRate { set; get; }

        /**Quality adaption of the local video stream in the reported interval (based on the target frame rate and target bitrate). For details, see QUALITY_ADAPT_INDICATION .*/
        public QUALITY_ADAPT_INDICATION qualityAdaptIndication { set; get; }

        /**
         * The bitrate (Kbps) while encoding the local video stream.This value does not include the bitrate for resending the video after packet loss.
         *  
         */
        public int encodedBitrate { set; get; }

        /**The width of the encoded video (px).*/
        public int encodedFrameWidth { set; get; }

        /**The height of the encoded video (px).*/
        public int encodedFrameHeight { set; get; }

        /**The number of the sent video frames, represented by an aggregate value.*/
        public int encodedFrameCount { set; get; }

        /**The codec type of the local video. For details, see VIDEO_CODEC_TYPE .*/
        public VIDEO_CODEC_TYPE codecType { set; get; }

        /**The video packet loss rate (%) from the local client to the Agora server before applying the anti-packet loss strategies.*/
        public ushort txPacketLossRate { set; get; }

        /**The frame rate (fps) for capturing the local video stream.*/
        public int captureFrameRate { set; get; }
    }

    /**
     * Statistics of the remote video stream.
     */
    public class RemoteVideoStats
    {
        public RemoteVideoStats()
        {
        }

        public RemoteVideoStats(uint uid, int delay, int width, int height, int receivedBitrate,
            int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
            REMOTE_VIDEO_STREAM_TYPE rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime,
            int publishDuration)
        {
            this.uid = uid;
            this.delay = delay;
            this.width = width;
            this.height = height;
            this.receivedBitrate = receivedBitrate;
            this.decoderOutputFrameRate = decoderOutputFrameRate;
            this.rendererOutputFrameRate = rendererOutputFrameRate;
            this.packetLossRate = packetLossRate;
            this.rxStreamType = rxStreamType;
            this.totalFrozenTime = totalFrozenTime;
            this.frozenRate = frozenRate;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
        }

        /**The user ID of the remote user sending the video stream.*/
        public uint uid { set; get; }

        /**
         *  Deprecated:
         *  In scenarios where audio and video are synchronized, you can get the video delay data from networkTransportDelay and jitterBufferDelay in RemoteAudioStats . The video delay (ms).
         *  
         */
        public int delay { set; get; }

        /**The width (pixels) of the video.*/
        public int width { set; get; }

        /**The height (pixels) of the video.*/
        public int height { set; get; }

        /**The bitrate (Kbps) of the remote video received since the last count.*/
        public int receivedBitrate { set; get; }

        /**The frame rate (fps) of decoding the remote video.*/
        public int decoderOutputFrameRate { set; get; }

        /**The frame rate (fps) of rendering the remote video.*/
        public int rendererOutputFrameRate { set; get; }

        /**The packet loss rate (%) of the remote video after using the anti-packet-loss technology.*/
        public int packetLossRate { set; get; }

        /**
         * The type of the video stream. See REMOTE_VIDEO_STREAM_TYPE .
         *  
         */
        public REMOTE_VIDEO_STREAM_TYPE rxStreamType { set; get; }

        /**
         * The total freeze time (ms) of the remote video stream after the remote user joins the channel. In a video session where the frame rate is set to 5 fps or higher, video freezing occurs when the time interval between two adjacent video frames is more than 500
         * ms.
         */
        public int totalFrozenTime { set; get; }

        /**The total video freeze time as a percentage (%) of the total time the video is available. The video is considered available as long as that the remote user neither stops sending the video stream nor disables the video module after joining the channel.*/
        public int frozenRate { set; get; }

        /**
         *  Since
         *  v3.0.1 The total active time (ms) of the video.
         *  As long as the remote user/host neither stops sending the video stream nor disables the video module after joining the channel, the video is available.
         */
        public int totalActiveTime { set; get; }

        /**
         *  Since
         *  v3.1.0 The total duration (ms) of the remote video stream.
         */
        public int publishDuration { set; get; }
    }

    /**
     * Local audio statistics.
     */
    public class LocalAudioStats
    {
        public LocalAudioStats()
        {
        }

        public LocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate, ushort txPacketLossRate)
        {
            this.numChannels = numChannels;
            this.sentSampleRate = sentSampleRate;
            this.sentBitrate = sentBitrate;
            this.txPacketLossRate = txPacketLossRate;
        }

        /**The number of audio channels.*/
        public int numChannels { set; get; }

        /**The sampling rate (Hz) of sending the local user's audio stream.*/
        public int sentSampleRate { set; get; }

        /**The average bitrate (Kbps) of sending the local user's audio stream.*/
        public int sentBitrate { set; get; }

        /**The packet loss rate (%) from the local client to the Agora server before applying the anti-packet loss strategies.*/
        public ushort txPacketLossRate { set; get; }
    }

    /**
     * Audio statistics of the remote user.
     */
    public class RemoteAudioStats
    {
        public RemoteAudioStats()
        {
        }

        public RemoteAudioStats(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay,
            int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime,
            int frozenRate, int totalActiveTime, int publishDuration, int qoeQuality, int qualityChangedReason,
            int mosValue)
        {
            this.uid = uid;
            this.quality = quality;
            this.networkTransportDelay = networkTransportDelay;
            this.jitterBufferDelay = jitterBufferDelay;
            this.audioLossRate = audioLossRate;
            this.numChannels = numChannels;
            this.receivedSampleRate = receivedSampleRate;
            this.receivedBitrate = receivedBitrate;
            this.totalFrozenTime = totalFrozenTime;
            this.frozenRate = frozenRate;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
            this.qoeQuality = qoeQuality;
            this.qualityChangedReason = qualityChangedReason;
            this.mosValue = mosValue;
        }

        /**The user ID of the remote user.*/
        public uint uid { set; get; }

        /**
         * The quality of the audio stream sent by the user. See QUALITY_TYPE .
         *  
         */
        public int quality { set; get; }

        /**The network delay (ms) from the sender to the receiver.*/
        public int networkTransportDelay { set; get; }

        /**
         * The network delay (ms) from the receiver to the jitter buffer.
         *  This parameter does not take effect if the receiver is an audience member and audienceLatencyLevel of ClientRoleOptions is 1.
         *  
         */
        public int jitterBufferDelay { set; get; }

        /**The frame loss rate (%) of the remote audio stream in the reported interval.*/
        public int audioLossRate { set; get; }

        /**The number of audio channels.*/
        public int numChannels { set; get; }

        /**The sampling rate of the received audio stream in the reported interval.*/
        public int receivedSampleRate { set; get; }

        /**The average bitrate (Kbps) of the received audio stream in the reported interval.*/
        public int receivedBitrate { set; get; }

        /**The total freeze time (ms) of the remote audio stream after the remote user joins the channel. In a session, audio freeze occurs when the audio frame loss rate reaches 4%.*/
        public int totalFrozenTime { set; get; }

        /**The total audio freeze time as a percentage (%) of the total time when the audio is available. The audio is considered available when the remote user neither stops sending the audio stream nor disables the audio module after joining the channel.*/
        public int frozenRate { set; get; }

        /**
         *  The total active time (ms) between the start of the audio call and the callback of the remote user.
         *  The active time refers to the total duration of the remote user without the mute state.
         *  
         */
        public int totalActiveTime { set; get; }

        /**
         *  The total duration (ms) of the remote audio stream.
         *  
         */
        public int publishDuration { set; get; }

        /**
         * Quality of experience (QoE) of the local user when receiving the remote audio stream. See EXPERIENCE_QUALITY_TYPE .
         *  
         */
        public int qoeQuality { set; get; }

        /**
         * The reason for poor QoE of the local user when receiving the remote audio stream. See EXPERIENCE_POOR_REASON .
         *  
         */
        public int qualityChangedReason { set; get; }

        /**
         *  The quality of the remote audio stream in the reported interval. The quality is determined by the Agora real-time audio MOS (Mean Opinion Score) measurement method. The return value range is [0, 500]. Dividing the return value by 100 gets the MOS score, which ranges from 0 to 5. The higher the score, the better the audio quality.
         *  The subjective perception of audio quality corresponding to the Agora real-time audio MOS scores is as follows: MOS score
         *  Perception of audio quality Greater than 4
         *  Excellent. The audio sounds clear and smooth. From 3.5 to 4
         *  Good. The audio has some perceptible impairment but still sounds clear. From 3 to 3.5
         *  Fair. The audio freezes occasionally and requires attentive listening. From 2.5 to 3
         *  Poor. The audio sounds choppy and requires considerable effort to understand. From 2 to 2.5
         *  Bad. The audio has occasional noise. Consecutive audio dropouts occur, resulting in some information loss. The users can communicate only with difficulty. Less than 2
         *  Very bad. The audio has persistent noise. Consecutive audio dropouts are frequent, resulting in severe information loss. Communication is nearly impossible. 
         */
        public int mosValue { set; get; }
    }

    /**
     * Video dimensions.
     */
    public class VideoDimensions
    {
        public VideoDimensions()
        {
            width = 640;
            height = 480;
        }

        public VideoDimensions(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /**
         * The width (pixels) of the video.
         *  
         */
        public int width { set; get; }

        /**The height (pixels) of the video.*/
        public int height { set; get; }
    }


    public enum BITRATE
    {
        STANDARD_BITRATE = 0,

        COMPATIBLE_BITRATE = -1,

        DEFAULT_MIN_BITRATE = -1
    }


    /**
     * Video encoder configurations.
     */
    public class VideoEncoderConfiguration
    {
        public VideoEncoderConfiguration()
        {
            dimensions = null;
            frameRate = FRAME_RATE.FRAME_RATE_FPS_15;
            minBitrate = -1;
            bitrate = (int)BITRATE.STANDARD_BITRATE;
            minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public VideoEncoderConfiguration(VideoDimensions dimensions,
            FRAME_RATE frameRate = FRAME_RATE.FRAME_RATE_FPS_15, int minFrameRate = -1,
            BITRATE bitrate = BITRATE.STANDARD_BITRATE, BITRATE minBitrate = BITRATE.DEFAULT_MIN_BITRATE,
            ORIENTATION_MODE orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE,
            DEGRADATION_PREFERENCE degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            this.dimensions = dimensions ?? new VideoDimensions();
            this.frameRate = frameRate;
            this.minFrameRate = minFrameRate;
            this.bitrate = (int)bitrate;
            this.minBitrate = (int)minBitrate;
            this.orientationMode = orientationMode;
            this.degradationPreference = degradationPreference;
            this.mirrorMode = mirrorMode;
        }

        public VideoEncoderConfiguration(int width, int height, FRAME_RATE frameRate = FRAME_RATE.FRAME_RATE_FPS_15,
            int minFrameRate = -1, BITRATE bitrate = BITRATE.STANDARD_BITRATE,
            BITRATE minBitrate = BITRATE.DEFAULT_MIN_BITRATE,
            ORIENTATION_MODE orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE,
            DEGRADATION_PREFERENCE degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            dimensions = new VideoDimensions(width, height);
            this.frameRate = frameRate;
            this.minFrameRate = minFrameRate;
            this.bitrate = (int)bitrate;
            this.minBitrate = (int)minBitrate;
            this.orientationMode = orientationMode;
            this.degradationPreference = degradationPreference;
            this.mirrorMode = mirrorMode;
        }

        /**
         * The dimensions of the encoded video (px). See VideoDimensions . This parameter measures the video encoding quality in the format of length × width. The default value is 640 × 360. You can set a custom value.
         *  
         */
        public VideoDimensions dimensions { set; get; }

        /**
         * The frame rate (fps) of the encoding video frame. The default value is 15. 
         *  
         */
        public FRAME_RATE frameRate { set; get; }

        /**The minimum encoding frame rate of the video. The default value is -1.*/
        public int minFrameRate { set; get; }

        /**
         * The encoding bitrate (Kbps) of the video.
         *  You can refer to the table below to set the bitrate according to your app scenario. If the bitrate you set is beyond the reasonable range, the SDK sets it within a reasonable range. You can also choose from the following options: : (Recommended)
         *  Standard bitrate mode. In this mode, the video bitrate of the interactive streaming profile is twice that of the communication profile.
         *  : Adaptive bitrate mode. In this mode, the bitrate differs between the interactive streaming and communication profiles. If you choose this mode in the interactive streaming profile, the video frame rate may be lower than the set value. Agora uses different video codecs for different profiles to optimize user experience. The communication profile prioritizes smoothness while the interactive streaming profile prioritizes video quality (a higher bitrate). Therefore, Agora recommends setting this parameter as
         *  . You can also set the bitrate value of the Live-broadcasting profile to twice the bitrate value of the communication profile.
         *  
         */
        public int bitrate { set; get; }

        /**
         * The minimum encoding bitrate (Kbps) of the video.
         *  The SDK automatically adjusts the encoding bitrate to adapt to the network conditions. Using a value greater than the default value forces the video encoder to output high-quality images but may cause more packet loss and sacrifice the smoothness of the video transmission. Unless you have special requirements for image quality, Agora does not recommend changing this value.
         *  This parameter only applies to the interactive streaming profile.
         *  
         */
        public int minBitrate { set; get; }

        /**The orientation mode of the encoded video. See ORIENTATION_MODE .*/
        public ORIENTATION_MODE orientationMode { set; get; }

        /**Video degradation preference under limited bandwidth. See DEGRADATION_PREFERENCE .*/
        public DEGRADATION_PREFERENCE degradationPreference { set; get; }

        /**By default, the video is not mirrored. */
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }
    }

    /**
     *  The configuration of audio recording on the app client. 
     */
    public class AudioRecordingConfiguration
    {
        public AudioRecordingConfiguration()
        {
            filePath = null;
            recordingQuality = AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_MEDIUM;
            recordingPosition = AUDIO_RECORDING_POSITION.AUDIO_RECORDING_POSITION_MIXED_RECORDING_AND_PLAYBACK;
            recordingSampleRate = 32000;
            recordingChannel = 1;
        }

        public AudioRecordingConfiguration(string filePath, AUDIO_RECORDING_QUALITY_TYPE recordingQuality,
            AUDIO_RECORDING_POSITION recordingPosition, int recordingSampleRate, int recordingChannel)
        {
            this.filePath = filePath;
            this.recordingQuality = recordingQuality;
            this.recordingPosition = recordingPosition;
            this.recordingSampleRate = recordingSampleRate;
            this.recordingChannel = recordingChannel;
        }

        /**
         * The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.aac . Ensure that the directory for the log files exists and is writable.
         *  
         */
        public string filePath { set; get; }

        /**
         * Recording quality. For details, see AUDIO_RECORDING_QUALITY_TYPE 
         *  . Note: This parameter applies to AAC files only.
         *  
         */
        public AUDIO_RECORDING_QUALITY_TYPE recordingQuality { set; get; }

        /**
         * The recording content. For details, see AUDIO_RECORDING_POSITION 
         *  .
         *  
         */
        public AUDIO_RECORDING_POSITION recordingPosition { set; get; }

        /**
         * Recording sample rate (Hz). 16000
         *  (Default) 32000
         *  44100
         *  48000 If you set this parameter as 44100 or 48000, Agora recommends recording WAV files or AAV files whose
         *  recordingQuality
         *  is
         *  AUDIO_RECORDING_QUALITY_MEDIUM
         *  or
         *  AUDIO_RECORDING_QUALITY_HIGH
         *  for better recording quality. 
         */
        public int recordingSampleRate { set; get; }
        /**
         * The recorded audio channel. The following values are supported: 1: (Default) Mono channel.
         *  Dual channel. The actual recorded audio channel is related to the audio channel that you capture. If the captured audio is mono and recordingChannel is 2, the recorded audio is the dual-channel data that is copied from mono data, not stereo. If the captured audio is dual channel and recordingChannel is 1, the recorded audio is the mono data that is mixed by dual-channel data. The integration scheme also affects the final recorded audio channel. Therefore, to record in stereo, contact technical support for assistance. 
         */
        public int recordingChannel { set; get; }
    }

    /**
     * Recording content. Set in StartAudioRecording [3/3] .
     */
    public enum AUDIO_RECORDING_POSITION
    {
        /**0: (Default) Records the mixed audio of the local and all remote users.*/
        AUDIO_RECORDING_POSITION_MIXED_RECORDING_AND_PLAYBACK = 0,

        /**1: Only records the audio of the local user.*/
        AUDIO_RECORDING_POSITION_RECORDING = 1,

        /**2: Only records the audio of all remote users.*/
        AUDIO_RECORDING_POSITION_MIXED_PLAYBACK = 2,
    }

    /**
     * Transcoding configurations of each host.
     */
    public class TranscodingUser
    {
        public TranscodingUser()
        {
            alpha = 1.0;
        }

        public TranscodingUser(uint uid, int x, int y, int width, int height, int zOrder, double alpha,
            int audioChannel)
        {
            this.uid = uid;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
            this.audioChannel = audioChannel;
        }

        /**
         * The user ID of the host.
         *  
         */
        public uint uid { set; get; }

        /**
         * The x coordinate (pixel) of the host's video on the output video frame (taking the upper left corner of the video frame as the origin). The value range is [0, width], where width is the LiveTranscoding width set in .
         *  
         */
        public int x { set; get; }

        /**The y coordinate (pixel) of the host's video on the output video frame (taking the upper left corner of the video frame as the origin). The value range is [0, height], where height is the LiveTranscoding height set in .*/
        public int y { set; get; }

        /**The width (pixel) of the host's video.*/
        public int width { set; get; }

        /**
         * The height (pixel) of the host's video.
         *  
         */
        public int height { set; get; }

        /**
         * The layer index number of the host's video. The value range is [0, 100]. 0: (Default) The host's video is the bottom layer.
         *  100: The host's video is the top layer. 
         *  If the value is beyond this range, the SDK reports the error code ERR_INVALID_ARGUMENT.
         *  As of v2.3, the SDK supports setting zOrder to 0.
         *  
         */
        public int zOrder { set; get; }

        /**
         * The transparency of the host's video. The value range is [0.0, 1.0]. 0.0: Completely transparent.
         *  1.0: (Default) Opaque. 
         */
        public double alpha { set; get; }

        /**
         * The audio channel used by the host's audio in the output audio. The default value is 0, and the value range is [0, 5]. 0: (Recommended) The defaut setting, which supports dual channels at most and depends on the upstream of the host.
         *  1: The host's audio uses the FL audio channel. If the host's upstream uses multiple audio channels, the Agora
         *  server mixes them into mono first.
         *  2: The host's audio uses the FC audio channel. If the host's upstream uses multiple audio channels, the Agora
         *  server mixes them into mono first.
         *  3: The host's audio uses the FR audio channel. If the host's upstream uses multiple audio channels, the Agora
         *  server mixes them into mono first.
         *  4: The host's audio uses the BL audio channel. If the host's upstream uses multiple audio channels, the Agora
         *  server mixes them into mono first.
         *  5: The host's audio uses the BR audio channel. If the host's upstream uses multiple audio channels, the Agora
         *  server mixes them into mono first.
         *  0xFF or a value greater than 5: The host's audio is muted, and the Agora
         *  server removes the host's audio. If the value is not 0, a special player is required.
         *  
         */
        public int audioChannel { set; get; }
    }

    /**
     * Image properties.
     * This class sets the properties of the watermark and background images in the live video.
     */
    public class RtcImage
    {
        public RtcImage()
        {
        }

        public RtcImage(string url, int x, int y, int width, int height, int zOrder, double alpha)
        {
            this.url = url;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
        }

        /**The HTTP/HTTPS URL address of the image in the live video. The maximum length of this parameter is 1024 bytes.*/
        public string url { set; get; }

        /**The x coordinate (pixel) of the image on the video frame (taking the upper left corner of the video frame as the origin).*/
        public int x { set; get; }

        /**The y coordinate (pixel) of the image on the video frame (taking the upper left corner of the video frame as the origin).*/
        public int y { set; get; }

        /**The width (pixel) of the image on the video frame.*/
        public int width { set; get; }

        /**The height (pixel) of the image on the video frame.*/
        public int height { set; get; }
        /**The layer index of the video frame. An integer. The value range is [0, 100]. 1 represents the lowest layer. 100 represents the top layer.*/
        public int zOrder { set; get; }
        /**
         * The transparency of the watermark or background image. The value ranges between 0.0 and 1.0:
         *  0.0: Completely transparent.
         *  1.0: (Default) Opaque.
         *  
         */
        public double alpha { set; get; }
    }


    public class LiveStreamAdvancedFeature
    {
        public LiveStreamAdvancedFeature()
        {
            LBHQ = "lbhq";
            VEO = "veo";
        }

        public LiveStreamAdvancedFeature(string featureName, bool opened = false)
        {
            LBHQ = "lbhq";
            VEO = "veo";
            this.featureName = featureName;
            this.opened = opened;
        }

        public string LBHQ { set; get; }

        public string VEO { set; get; }

        public string featureName { set; get; }

        public bool opened { set; get; }
    }


    /**
     * Transcoding configurations for Media Push.
     */
    public class LiveTranscoding
    {
        public LiveTranscoding()
        {
            width = 360;
            height = 640;
            videoBitrate = 400;
            videoFramerate = 15;
            lowLatency = false;
            videoGop = 30;
            videoCodecProfile = VIDEO_CODEC_PROFILE_TYPE.VIDEO_CODEC_PROFILE_HIGH;
            backgroundColor = 0x000000;
            videoCodecType = VIDEO_CODEC_TYPE_FOR_STREAM.VIDEO_CODEC_H264_FOR_STREAM;
            userCount = 0;
            transcodingUsers = new TranscodingUser[0];
            transcodingExtraInfo = null;
            metadata = null;
            watermark = null;
            backgroundImage = null;
            audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            audioBitrate = 48;
            audioChannels = 1;
            audioCodecProfile = AUDIO_CODEC_PROFILE_TYPE.AUDIO_CODEC_PROFILE_LC_AAC;
            advancedFeatures = new LiveStreamAdvancedFeature[0];
            advancedFeatureCount = 0;
        }

        public LiveTranscoding(int width, int height, int videoBitrate, int videoFramerate, bool lowLatency,
            int videoGop, VIDEO_CODEC_PROFILE_TYPE videoCodecProfile, uint backgroundColor,
            VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType, uint userCount, TranscodingUser[] transcodingUsers,
            string transcodingExtraInfo, string metadata, RtcImage[] watermark, uint watermarkCount, RtcImage[] backgroundImage, uint backgroundImageCount,
            AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels,
            AUDIO_CODEC_PROFILE_TYPE audioCodecProfile, LiveStreamAdvancedFeature[] advancedFeatures,
            uint advancedFeatureCount)
        {
            this.width = width;
            this.height = height;
            this.videoBitrate = videoBitrate;
            this.videoFramerate = videoFramerate;
            this.lowLatency = lowLatency;
            this.videoGop = videoGop;
            this.videoCodecProfile = videoCodecProfile;
            this.backgroundColor = backgroundColor;
            this.videoCodecType = videoCodecType;
            this.userCount = userCount;
            this.transcodingUsers = transcodingUsers;
            this.transcodingExtraInfo = transcodingExtraInfo;
            this.metadata = metadata;
            this.watermark = watermark;
            this.watermarkCount = watermarkCount;
            this.backgroundImage = backgroundImage;
            this.backgroundImageCount = backgroundImageCount;
            this.audioSampleRate = audioSampleRate;
            this.audioBitrate = audioBitrate;
            this.audioChannels = audioChannels;
            this.audioCodecProfile = audioCodecProfile;
            this.advancedFeatures = advancedFeatures;
            this.advancedFeatureCount = advancedFeatureCount;
        }

        /**
         * The width of the video in pixels. The default value is 360. When pushing video streams to the CDN, the value range of width is [64,1920]. If the value is less than 64, Agora server automatically adjusts it to 64; if the value is greater than 1920, Agora server automatically adjusts it to 1920.
         *  When pushing audio streams to the CDN, set width and height as 0.
         *  
         */
        public int width { set; get; }

        /**
         * The height of the video in pixels. The default value is 640. When pushing video streams to the CDN, the value range of height is [64,1080]. If the value is less than 64, Agora server automatically adjusts it to 64; if the value is greater than 1080, Agora server automatically adjusts it to 1080.
         *  When pushing audio streams to the CDN, set width and height as 0.
         *  
         */
        public int height { set; get; }

        /**
         * Bitrate of the output video stream for Media Push in Kbps. The default value is 400 Kbps.
         *  You can refer to Media Pushfor how to set this parameter.
         *  
         */
        public int videoBitrate { set; get; }

        /**
         * Frame rate (in fps) of the output video stream set for Media Push. The default value is 15 , and the value range is (0,30].
         *  The Agora server adjusts any value over 30 to 30.
         */
        public int videoFramerate { set; get; }

        /**
         *  Deprecated
         *  This parameter is deprecated. Latency mode: true: Low latency with unassured quality.
         *  false: (Default) High latency with assured quality.
         *  
         */
        public bool lowLatency { set; get; }

        /**GOP (Group of Pictures) in fps of the video frames for Media Push. The default value is 30.*/
        public int videoGop { set; get; }

        /**
         * Video codec profile type for Media Push. Set it as 66, 77, or 100 (default). See VIDEO_CODEC_PROFILE_TYPE for details.
         *  If you set this parameter to any other value, Agora adjusts it to the default value.
         */
        public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile { set; get; }

        /**
         * The background color in RGB hex value. Value only. Do not include a preceeding #. For example, 0xFFB6C1 (light pink). The default value is 0x000000 (black).
         *  
         */
        public uint backgroundColor { set; get; }

        /**Video codec profile types for Media Push. See VIDEO_CODEC_TYPE_FOR_STREAM for details.*/
        public VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType { set; get; }

        /**The number of users in the interactive live streaming. The value range is [0,17].*/
        public uint userCount { set; get; }

        /**
         * Manages the user layout configuration in the CDN live streaming. Agora supports a maximum of 17 transcoding users in a Media Push channel. See TranscodingUser for details.
         *  
         */
        public TranscodingUser[] transcodingUsers { set; get; }

        /**
         * Reserved property. Extra user-defined information to send SEI for the H.264/H.265 video stream to the CDN live client. Maximum length: 4096 bytes. For more information on SEI, see SEI-related questions.
         *  
         */
        public string transcodingExtraInfo { set; get; }

        /**
         *  Deprecated
         *  This parameter is deprecated. The metadata sent to the CDN client.
         */
        public string metadata { set; get; }

        /**
         * The watermark on the live video. Watermark images must be in the PNG format. See RtcImage for details.
         *  You can add one watermark, or add multiple watermarks using an array. This parameter is used with watermarkCount.
         *  
         */
        public RtcImage[] watermark { set; get; }

        /**
         * The array of watermarks on the live video. See RtcImage for details.
         *  The total number of watermarks and background images can range from 0 to 10. This parameter is used with watermark.
         *  
         */
        public uint watermarkCount { set; get; }

        /**The number of background images on the live video. See RtcImage for details. You can add a background image or use an array to add multiple background images. This parameter is used with backgroundImageCount.*/
        public RtcImage[] backgroundImage { set; get; }

        /**
         * The number of background images on the live video.
         *  The total number of watermarks and background images can range from 0 to 10. This parameter is used with backgroundImage.
         *  
         */
        public uint backgroundImageCount { set; get; }

        /**
         * Self-defined audio sample rate. See AUDIO_SAMPLE_RATE_TYPE for details.
         *  
         */
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        /**
         * Bitrate (Kbps) of the audio output stream for Media Push. The default value is 48, and the highest value is 128.
         *  
         */
        public int audioBitrate { set; get; }

        /**
         * The number of audio channels for Media Push. Agora recommends choosing 1 (mono), or 2 (stereo) audio channels. Special players are required if you choose 3, 4, or 5. 1: (Default) Mono
         *  2: Stereo.
         *  3: Three audio channels.
         *  4: Four audio channels.
         *  5: Five audio channels.
         *  
         */
        public int audioChannels { set; get; }

        /**
         * Audio codec profile type for Media Push. See AUDIO_CODEC_PROFILE_TYPE for details.
         *  
         */
        public AUDIO_CODEC_PROFILE_TYPE audioCodecProfile { set; get; }

        /**Advanced features of the Media Push with transcoding. */
        public LiveStreamAdvancedFeature[] advancedFeatures { set; get; }

        /**The number of enabled advanced features. The default value is 0.*/
        public uint advancedFeatureCount { set; get; }
    }

    /**
     * The camera capturer preference.
     */
    public class CameraCapturerConfiguration
    {
        public CameraCapturerConfiguration()
        {
            preference = CAPTURER_OUTPUT_PREFERENCE.CAPTURER_OUTPUT_PREFERENCE_AUTO;
            captureWidth = 640;
            captureHeight = 480;
            cameraDirection = null;
        }

        public CameraCapturerConfiguration(int captureWidth, int captureHeight,
            CAMERA_DIRECTION? cameraDirection = null)
        {
            preference = CAPTURER_OUTPUT_PREFERENCE.CAPTURER_OUTPUT_PREFERENCE_MANUAL;
            this.captureWidth = captureWidth;
            this.captureHeight = captureHeight;
            this.cameraDirection = cameraDirection;
        }

        public CameraCapturerConfiguration(CAPTURER_OUTPUT_PREFERENCE preference, int captureWidth, int captureHeight,
            CAMERA_DIRECTION? cameraDirection = null)
        {
            this.preference = preference;
            this.captureWidth = captureWidth;
            this.captureHeight = captureHeight;
            this.cameraDirection = cameraDirection;
        }

        /**The camera capture preference. For details, see CAPTURER_OUTPUT_PREFERENCE .*/
        public CAPTURER_OUTPUT_PREFERENCE preference { set; get; }

        /**
         *  The width (px) of the video image captured by the local camera. To customize the width of the video image, set preference as CAPTURER_OUTPUT_PREFERENCE_MANUAL(3) first, and then use captureWidth to set the video width.
         *  
         */
        public int captureWidth { set; get; }

        /**
         *  The height (px) of the video image captured by the local camera. To customize the height of the video image, set preference as CAPTURER_OUTPUT_PREFERENCE_MANUAL(3) first, and then use captureHeight.
         *  
         */
        public int captureHeight { set; get; }

        /**
         * This parameter applies to Android and iOS only.
         *  The camera direction. For details, see CAMERA_DIRECTION .
         *  
         */
        public CAMERA_DIRECTION? cameraDirection { set; get; }
    }

    /**
     * The configurations for the data stream.
     * The following table shows the SDK behaviors under different parameter settings:
     */
    public class DataStreamConfig
    {
        public DataStreamConfig()
        {
        }

        public DataStreamConfig(bool syncWithAudio, bool ordered)
        {
            this.syncWithAudio = syncWithAudio;
            this.ordered = ordered;
        }

        /**
         * Whether to synchronize the data packet with the published audio packet.
         *  true: Synchronize the data packet with the audio packet.
         *  false: Do not synchronize the data packet with the audio packet.
         *  When you set the data packet to synchronize with the audio, then if the data packet delay is within the audio delay, the SDK triggers the OnStreamMessage callback when the synchronized audio packet is played out. Do not set this parameter as true if you need the receiver to receive the data packet immediately. Agora recommends that you set this parameter to `true` only when you need to implement specific functions, for example lyric synchronization.
         *  
         */
        public bool syncWithAudio { set; get; }

        /**
         * Whether the SDK guarantees that the receiver receives the data in the sent order.
         *  true: Guarantee that the receiver receives the data in the sent order.
         *  false: Do not guarantee that the receiver receives the data in the sent order.
         *  Do not set this parameter as true if you need the receiver to receive the data packet immediately.
         *  
         */
        public bool ordered { set; get; }
    }

    /**
     * Configurations of injecting an external audio or video stream.
     * Agora will soon stop the service for injecting online media streams on the client. If you have not implemented this service, Agora recommends that you do not use it. 
     */
    public class InjectStreamConfig
    {
        public InjectStreamConfig()
        {
            width = 0;
            height = 0;
            videoGop = 30;
            videoFramerate = 15;
            videoBitrate = 400;
            audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            audioBitrate = 48;
            audioChannels = 1;
        }

        public InjectStreamConfig(int width, int height, int videoGop, int videoFramerate, int videoBitrate,
            AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels)
        {
            this.width = width;
            this.height = height;
            this.videoGop = videoGop;
            this.videoFramerate = videoFramerate;
            this.videoBitrate = videoBitrate;
            this.audioSampleRate = audioSampleRate;
            this.audioBitrate = audioBitrate;
            this.audioChannels = audioChannels;
        }

        /**The width of the external video stream after injecting. The default value is 0, which represents the same width as the original.*/
        public int width { set; get; }

        /**The height of the external video stream after injecting. The default value is 0, which represents the same height as the original.*/
        public int height { set; get; }

        /**The GOP (in frames) of injecting the external video stream. The default value is 30 frames.*/
        public int videoGop { set; get; }

        /**The frame rate (fps) of injecting the external video stream. The default rate is 15 fps.*/
        public int videoFramerate { set; get; }

        /**
         * The bitrate (Kbps) of injecting the external video stream. The default value is 400 Kbps.
         *  The bitrate setting is closely linked to the video resolution. If the bitrate you set is beyond a reasonable range, the SDK sets it within a reasonable range.
         *  
         */
        public int videoBitrate { set; get; }

        /**
         * The sampling rate (Hz) of injecting the external audio stream. The default value is 48000 Hz. See AUDIO_SAMPLE_RATE_TYPE .
         *  Agora recommends using the default value.
         *  
         */
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        /**
         * The bitrate (Kbps) of injecting the external audio stream. The default value is 48 Kbps.
         *  Agora recommends using the default value.
         *  
         */
        public int audioBitrate { set; get; }

        /**
         * The number of channels of the external audio stream after injecting.
         *  1: (Default) Mono.
         *  2: Stereo. Agora recommends using the default value.
         *  
         */
        public int audioChannels { set; get; }
    }

    /**
     * The definition of ChannelMediaInfo.
     */
    public class ChannelMediaInfo
    {
        public ChannelMediaInfo()
        {
        }

        public ChannelMediaInfo(string channelName, string token, uint uid)
        {
            this.channelName = channelName;
            this.token = token;
            this.uid = uid;
        }

        /**The name of the channel.*/
        public string channelName { set; get; }

        /**The token that enables the user to join the channel.*/
        public string token { set; get; }

        /**User ID.*/
        public uint uid { set; get; }
    }

    /**
     * The definition of ChannelMediaRelayConfiguration.
     */
    public class ChannelMediaRelayConfiguration
    {
        public ChannelMediaRelayConfiguration()
        {
            srcInfo = null;
            destInfos = new ChannelMediaInfo[0];
            destCount = 0;
        }

        public ChannelMediaRelayConfiguration(ChannelMediaInfo srcInfo, ChannelMediaInfo[] destInfos, int destCount)
        {
            this.srcInfo = srcInfo;
            this.destInfos = destInfos ?? new ChannelMediaInfo[0];
            this.destCount = destCount;
        }

        /**
         * The information of the source channel ChannelMediaInfo . It contains the following members:
         *  channelName: The name of the source channel. The default value is , which means the SDK applies the name of the current channel.NULL
         *  uid: The unique ID to identify the relay stream in the source channel. The default value is 0, which means the SDK generates a random UID. You must set it as 0.
         *  token: The token for joining the source channel. It is generated with the channelName and uid you set in srcInfo.
         *  If you have not enabled the App Certificate, set this parameter as the default value NULL , which means the SDK applies the App ID.
         *  If you have enabled the App Certificate, you must use the token generated with the channelName and uid, and the uid must be set as 0. 
         *  
         */
        public ChannelMediaInfo srcInfo { set; get; }

        /**
         * The information of the destination channel ChannelMediaInfo. It contains the following members:
         *  channelName: The name of the destination channel.
         *  uid: The unique ID to identify the relay stream in the destination channel. The value ranges from 0 to (232-1). To avoid UID conflicts, this `UID` must be different from any other `UID` in the destination channel. The default value is 0, which means the SDK generates a random `UID`. Do not set this parameter as the `UID` of the host in the destination channel, and ensure that this `UID` is different from any other `UID` in the channel.
         *  token: The token for joining the destination channel. It is generated with the channelName and uid you set in destInfos.
         *  If you have not enabled the App Certificate, set this parameter as the default value NULL , which means the SDK applies the App ID.
         *  If you have enabled the App Certificate, you must use the token generated with the channelName and uid. 
         *  
         */
        public ChannelMediaInfo[] destInfos { set; get; }

        /**The number of destination channels. The default value is 0, and the value range is from 0 to 4. Ensure that the value of this parameter corresponds to the number of ChannelMediaInfo structs you define in destInfo.*/
        public int destCount { set; get; }
    }

    /**
     * Lifecycle of the CDN live video stream.
     * Deprecated
     */
    public enum RTMP_STREAM_LIFE_CYCLE_TYPE
    {
        /**Bind to the channel lifecycle. If all hosts leave the channel, the CDN live streaming stops after 30 seconds.*/
        RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL = 1,

        /**Bind to the owner of the RTMP stream. If the owner leaves the channel, the CDN live streaming stops immediately.*/
        RTMP_STREAM_LIFE_CYCLE_BIND2OWNER = 2,
    }

    /**
     * The content hint for screen sharing.
     */
    public enum VideoContentHint
    {
        /**(Default) No content hint.*/
        CONTENT_HINT_NONE,

        /**Motion-intensive content. Choose this option if you prefer smoothness or when you are sharing a video clip, movie, or video game.*/
        CONTENT_HINT_MOTION,

        /**
         * Motionless content. Choose this option if you prefer sharpness or when you are sharing a
         *  picture, PowerPoint slides, or texts.
         */
        CONTENT_HINT_DETAILS
    }

    /**
     * The location of the target area relative to the screen or window. If you do not set this parameter, the SDK selects the whole screen or window.
     */
    public class Rectangle
    {
        public Rectangle()
        {
        }

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /**The horizontal offset from the top-left corner.*/
        public int x { set; get; }

        /**The vertical offset from the top-left corner.*/
        public int y { set; get; }

        /**The width of the target area.*/
        public int width { set; get; }

        /**The height of the target area.*/
        public int height { set; get; }
    }

    /**
     * The screen sharing region.
     * Deprecated:
     *  This class is deprecated. Please use the UpdateScreenCaptureRegion method to update the shared area.
     */
    [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, false)]
    public class Rect
    {
        public Rect()
        {
        }

        public Rect(int top, int left, int bottom, int right)
        {
            this.top = top;
            this.left = left;
            this.bottom = bottom;
            this.right = right;
        }

        /**The coordinate of the top side of the shared area on the vertical axis.*/
        public int top { set; get; }

        /**The coordinate of the left side of the shared area on the horizontal axis.*/
        public int left { set; get; }

        /**The coordinate of the bottom side of the shared area on the vertical axis.*/
        public int bottom { set; get; }

        /**The coordinate of the right side of the shared area on the horizontal axis.*/
        public int right { set; get; }
    }

    /**
     * Configurations of the watermark image.
     */
    public class WatermarkOptions
    {
        public WatermarkOptions()
        {
            visibleInPreview = true;
            positionInLandscapeMode = new Rectangle();
            positionInPortraitMode = new Rectangle();
        }

        public WatermarkOptions(bool visibleInPreview, Rectangle positionInLandscapeMode,
            Rectangle positionInPortraitMode)
        {
            this.visibleInPreview = visibleInPreview;
            this.positionInLandscapeMode = positionInLandscapeMode ?? new Rectangle();
            this.positionInPortraitMode = positionInPortraitMode ?? new Rectangle();
        }

        /**
         * Whether the watermark image is visible in the local video preview:
         *  true: (Default) The watermark image is visible in the local preview.
         *  false: The watermark image is not visible in the local preview. 
         */
        public bool visibleInPreview { set; get; }

        /**
         * The area to display the watermark image in landscape mode. 
         *  
         */
        public Rectangle positionInLandscapeMode { set; get; }

        /**
         * The area to display the watermark image in portrait mode. 
         *  
         */
        public Rectangle positionInPortraitMode { set; get; }
    }

    /**
     * Screen sharing configurations.
     */
    public class ScreenCaptureParameters
    {
        public ScreenCaptureParameters()
        {
            dimensions = new VideoDimensions(1920, 1080);
            frameRate = 5;
            bitrate = (int)BITRATE.STANDARD_BITRATE;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
        }

        public ScreenCaptureParameters(int width, int height, int frameRate, BITRATE bitrate, bool captureMouseCursor,
            bool windowFocus, view_t[] excludeWindowList = null, int excludeWindowCount = 0)
        {
            dimensions = new VideoDimensions(width, height);
            this.frameRate = frameRate;
            this.bitrate = (int)bitrate;
            this.captureMouseCursor = captureMouseCursor;
            this.windowFocus = windowFocus;
            this.excludeWindowList = excludeWindowList ?? new view_t[0];
            this.excludeWindowCount = excludeWindowCount;
        }

        public ScreenCaptureParameters(VideoDimensions dimensions, int frameRate, BITRATE bitrate,
            bool captureMouseCursor, bool windowFocus, view_t[] excludeWindowList = null, int excludeWindowCount = 0)
        {
            this.dimensions = dimensions;
            this.frameRate = frameRate;
            this.bitrate = (int)bitrate;
            this.captureMouseCursor = captureMouseCursor;
            this.windowFocus = windowFocus;
            this.excludeWindowList = excludeWindowList ?? new view_t[0];
            this.excludeWindowCount = excludeWindowCount;
        }

        /**
         * The maximum dimensions of encoding the shared region.  The default value is 1,920 × 1,080, that is,
         *  2,073,600 pixels. Agora uses the value of this parameter to calculate the charges.
         *  If the screen dimensions are different from the value of this parameter, Agora applies the following strategies for encoding. Suppose dimensions are set to 1,920 x 1,080: If the value of the screen dimensions is lower than that of dimensions, for example, 1,000 x 1,000 pixels, the SDK uses 1,000 x 1,000 pixels
         *  for encoding.
         *  If the value of the screen dimensions is larger than that of dimensions, for example, 2,000 × 1,500, the SDK uses
         *  the maximum value next to 1,920 × 1,080 with the aspect ratio of the screen dimension (4:3) for encoding, that is, 1,440 × 1,080. 
         */
        public VideoDimensions dimensions { set; get; }

        /**The frame rate (fps) of the shared region. The default value is 5. Agora does not recommend setting it to a value greater than 15.*/
        public int frameRate { set; get; }

        /**The bitrate (Kbps) of the shared region. The default value is 0, which represents that the SDK works out a bitrate according to the dimensions of the current screen.*/
        public int bitrate { set; get; }

        /**
         * Since
         *  v2.4.1 Whether to capture the mouse in screen sharing: true: (Default) Capture the mouse.
         *  false: Do not capture the mouse.
         *  
         */
        public bool captureMouseCursor { set; get; }

        /**
         * Since
         *  v3.1.0 Whether to bring the window to the front when calling the StartScreenCaptureByWindowId method to share it: true:Bring the window to the front.
         *  false: (Default) Do not bring the window to the front.
         *  
         */
        public bool windowFocus { set; get; }

        /**The ID list of the cpp to be blocked. When calling StartScreenCaptureByScreenRect to start screen sharing, you can use this parameter to block a specified window. When calling UpdateScreenCaptureParameters to update screen sharing configurations, you can use this parameter to dynamically block a specified window.*/
        public view_t[] excludeWindowList { set; get; }

        /**
         * The number of cpp to be blocked.
         *  
         */
        public int excludeWindowCount { set; get; }
    }

    /**
     *  Video display configurations. 
     */
    public class VideoCanvas
    {
        public VideoCanvas()
        {
            view = 0;
            renderMode = (int)RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
            channelId = "";
            uid = 0;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public VideoCanvas(view_t? view, RENDER_MODE_TYPE renderMode, string channelId = "", uint uid = 0,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            this.view = view ?? 0;
            this.renderMode = (int)renderMode;
            this.channelId = channelId;
            this.uid = uid;
            this.mirrorMode = mirrorMode;
        }

        /**
         * The view used to display the video. 
         *  
         */
        public view_t view { set; get; }

        /**
         * The rendering mode of the video. See 
         *  RENDER_MODE_TYPE 
         *  .
         *  
         */
        public int renderMode { set; get; }

        // TODO: Check if `VideoCanvas.channdlId` works when defined as a string type.
        /**
         *  Since
         *  v3.0.0 
         *  The unique channel name in the string format. Supported characters are (89 in total): The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  The 10 numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
         *  The default value is the empty string "". If the user joins the channel through the 
         *  JoinChannel [2/2] 
         *  method of the 
         *  IAgoraRtcEngine 
         *  class, set this parameter to the default value. In this case,
         *  VideoCanvas
         *  sets the user's view in the channel. If the user joins the channel using the
         *  JoinChannel [2/2]
         *  method of the 
         *  IAgoraRtcChannel 
         *  class, set this parameter to the
         *  channelId
         *  of the
         *  IAgoraRtcChannel
         *  object. In this case,
         *  VideoCanvas
         *  sets the user's view in the channel corresponding to the
         *  channelId
         *  . 
         */
        public string channelId { set; get; }

        /**User ID.*/
        public uint uid { set; get; }

        /**
         *  Since
         *  v3.0.0 
         *  The mirror mode of the view. See 
         *  VIDEO_MIRROR_MODE_TYPE 
         *  . 
         *  For the local user: If the user uses the front camera, the mirror mode is enabled by default.
         *  If the user uses the rear camera, the mirror mode is disabled by default. For the remote user: The SDK disables the mirror mode by default. 
         *  
         */
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }
    }

    /**
     * The contrast level.
     */
    public enum LIGHTENING_CONTRAST_LEVEL
    {
        /**Low contrast level.*/
        LIGHTENING_CONTRAST_LOW = 0,

        /**(Default) Normal contrast level.*/
        LIGHTENING_CONTRAST_NORMAL,

        /**High contrast level.*/
        LIGHTENING_CONTRAST_HIGH
    }

    /**
     * Image enhancement options.
     */
    public class BeautyOptions
    {
        public BeautyOptions()
        {
            lighteningContrastLevel = LIGHTENING_CONTRAST_LEVEL.LIGHTENING_CONTRAST_NORMAL;
        }

        public BeautyOptions(
            LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel, float lighteningLevel, float smoothnessLevel,
            float rednessLevel, float sharpnessLevel)
        {
            this.lighteningContrastLevel = lighteningContrastLevel;
            this.lighteningLevel = lighteningLevel;
            this.smoothnessLevel = smoothnessLevel;
            this.rednessLevel = rednessLevel;
            this.sharpnessLevel = sharpnessLevel;
        }

        /**
         * contrast, often with
         * lighteningLevel
         * . The larger the value, the greater the contrast between light and dark. For more details, see 
         *  LIGHTENING_CONTRAST_LEVEL .
         */
        public LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel { set; get; }

        /**
         * The brightness level. The value ranges from 0.0 (original) to 1.0. The default is
         * >
         */
        public float lighteningLevel { set; get; }

        /**The value ranges from 0.0 (original) to 1.0. The default value is 0.5. The greater the value, the greater the degree of skin grinding.*/
        public float smoothnessLevel { set; get; }

        /**The value ranges from 0.0 (original) to 1.0. The default value is 0.1. The larger the value, the greater the rosy degree.*/
        public float rednessLevel { set; get; }
        /**The sharpness level. The value ranges from 0.0 (original) to 1.0. The default value is 0.10.30.0. The larger the value, the greater the sharpening degree.*/
        public float sharpnessLevel { set; get; }
    }

    /**
     * The custom background image.
     */
    public class VirtualBackgroundSource
    {
        public VirtualBackgroundSource()
        {
            color = 0xFFFFFF;
            source = null;
            background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_COLOR;
        }

        /**The type of the custom background image. See BACKGROUND_SOURCE_TYPE .*/
        public BACKGROUND_SOURCE_TYPE background_source_type { set; get; }

        /** The type of the custom background image. The color of the custom background image. The format is a hexadecimal integer defined by RGB, without the # sign, such as 0xFFB6C1 for light pink. The default value is 0xFFFFFF, which signifies white. The value range is [0x000000, 0xffffff]. If the value is invalid, the SDK replaces the original background image with a white background image.This parameter takes effect only when the type of the custom background image is BACKGROUND_COLOR.*/
        public uint color { set; get; }

        /**The local absolute path of the custom background image. PNG and JPG formats are supported. If the path is invalid, the SDK replaces the original background image with a white background image.This parameter takes effect only when the type of the custom background image is BACKGROUND_IMG.*/
        public string source { set; get; }

        /**The degree of blurring applied to the custom background image. See BACKGROUND_BLUR_DEGREE .This parameter takes effect only when the type of the custom background image is BACKGROUND_BLUR.*/
        public BACKGROUND_BLUR_DEGREE blur_degree { set; get; }
    }

    /**
     * The type of the custom background image.
     */
    public enum BACKGROUND_SOURCE_TYPE
    {
        /**1: (Default) The background image is a solid color.*/
        BACKGROUND_COLOR = 1,

        /**The background image is a file in PNG or JPG format.*/
        BACKGROUND_IMG,

        /**The background image is the blurred background.*/
        BACKGROUND_BLUR
    }

    /**
     * The degree of blurring applied to the custom background image.
     */
    public enum BACKGROUND_BLUR_DEGREE
    {
        /**1: The degree of blurring applied to the custom background image is low. The user can almost see the background clearly.*/
        BLUR_DEGREE_LOW = 1,
        /**The degree of blurring applied to the custom background image is medium. It is difficult for the user to recognize details in the background.*/
        BLUR_DEGREE_MEDIUM,
        /**(Default) The degree of blurring applied to the custom background image is high. The user can barely see any distinguishing features in the background.*/
        BLUR_DEGREE_HIGH
    }

    /**
     * The information of the user.
     */
    public class UserInfo
    {
        public UserInfo()
        {
            userAccount = "";
        }

        public UserInfo(uint uid = 0, string userAccount = "")
        {
            this.uid = uid;
            this.userAccount = userAccount;
        }

        /**User ID*/
        public uint uid { set; get; }

        /**The user account. The maximum data length is MAX_USER_ACCOUNT_LENGTH_TYPE .*/
        public string userAccount { set; get; }
    }

    /**
     * The region for connection, which is the region where
     *  the server the SDK connects to is located.
     */
    [Flags]
    public enum AREA_CODE : uint
    {
        /**Mainland China.*/
        AREA_CODE_CN = 0x00000001,

        /**North America.*/
        AREA_CODE_NA = 0x00000002,

        /**Europe.*/
        AREA_CODE_EU = 0x00000004,

        /**Asia, excluding Mainland China.*/
        AREA_CODE_AS = 0x00000008,

        /**Japan.*/
        AREA_CODE_JP = 0x00000010,

        /**India.*/
        AREA_CODE_IN = 0x00000020,

        /**(Default) Global.*/
        AREA_CODE_GLOB = 0xFFFFFFFF
    }

    public enum ENCRYPTION_CONFIG
    {
        ENCRYPTION_FORCE_SETTING = (1 << 0),

        ENCRYPTION_FORCE_DISABLE_PACKET = (1 << 1)
    }

    internal enum AppType
    {
        APP_TYPE_NATIVE = 0,
        APP_TYPE_COCOS = 1,
        APP_TYPE_UNITY = 2,
        APP_TYPE_ELECTRON = 3,
        APP_TYPE_FLUTTER = 4,
        APP_TYPE_UNREAL = 5,
        APP_TYPE_XAMARIN = 6,
        APP_TYPE_API_CLOUD = 7,
        APP_TYPE_REACT_NATIVE = 8,
        APP_TYPE_PYTHON = 9,
        APP_TYPE_COCOS_CREATOR = 10,
        APP_TYPE_RUST = 11,
        APP_TYPE_C_SHARP = 12,
        APP_TYPE_CEF = 13,
        APP_TYPE_UNI_APP = 14,
    }

    /**
     * Audio frame type.
     */
    public enum AUDIO_FRAME_TYPE
    {
        /**0: PCM 16*/
        FRAME_TYPE_PCM16 = 0, // PCM 16bit little endian
    }

    /**
     * The video buffer type.
     */
    public enum VIDEO_BUFFER_TYPE
    {
        /***/
        VIDEO_BUFFER_RAW_DATA = 1,
    }

    /**
     * The video frame type.
     */
    public enum VIDEO_FRAME_TYPE
    {
        /**The video data format is YUV420.*/
        FRAME_TYPE_YUV420 = 0, // YUV 420 format

        /**1: YUV422.*/
        FRAME_TYPE_YUV422 = 1, // YUV 422 format

        /**2: RGBA.*/
        FRAME_TYPE_RGBA = 2, // RGBA format
    }

    /**
     * The frame position of the video observer.
     */
    [Flags]
    public enum VIDEO_OBSERVER_POSITION
    {
        /**1: The post-capturer position, which corresponds to the video data in the OnCaptureVideoFrame callback.*/
        POSITION_POST_CAPTURER = 1 << 0,

        /**2: The pre-renderer position, which corresponds to the video data in the OnRenderVideoFrame callback.*/
        POSITION_PRE_RENDERER = 1 << 1,

        /**4: The pre-encoder position, which corresponds to the video data in the OnPreEncodeVideoFrame callback.*/
        POSITION_PRE_ENCODER = 1 << 2,
    }

    /**
     * The video pixel format.
     */
    public enum VIDEO_PIXEL_FORMAT
    {
        /**0: The format is known.*/
        VIDEO_PIXEL_UNKNOWN = 0,

        /**1: The format is I420.*/
        VIDEO_PIXEL_I420 = 1,

        /**2: The format is BGRA.*/
        VIDEO_PIXEL_BGRA = 2,

        /**3: The format is NV21.*/
        VIDEO_PIXEL_NV21 = 3,

        /**4: The format is RGBA.*/
        VIDEO_PIXEL_RGBA = 4,

        /**5: The format is IMC2.*/
        VIDEO_PIXEL_IMC2 = 5,

        /**7: The format is ARGB.*/
        VIDEO_PIXEL_ARGB = 7,

        /**8: The format is NV12.*/
        VIDEO_PIXEL_NV12 = 8,

        /**16: The video pixel format is I422.*/
        VIDEO_PIXEL_I422 = 16,
        /**17: The video pixel format is GL_TEXTURE_2D.*/
        VIDEO_TEXTURE_2D = 17,
        /**18: The video pixel format is GL_TEXTURE_OES.*/
        VIDEO_TEXTURE_OES = 18,
    }

    /**
     * Media source type.
     */
    public enum MEDIA_SOURCE_TYPE
    {
        /**0: Audio playback device.*/
        AUDIO_PLAYOUT_SOURCE = 0,

        /**1: Audio capturing device.*/
        AUDIO_RECORDING_SOURCE = 1,
    }

    /**
     * The built-in encryption mode.
     * Agora recommends using AES_128_GCM2 or AES_256_GCM2 encrypted mode. These two modes support the use of salt for higher security.
     */
    public enum ENCRYPTION_MODE
    {
        /**1: (Default) 128-bit AES encryption, XTS mode.*/
        AES_128_XTS = 1,

        /**2: 128-bit AES encryption, ECB mode.*/
        AES_128_ECB = 2,

        /**3: 256-bit AES encryption, XTS mode.*/
        AES_256_XTS = 3,

        /// @cond
        /**4: 128-bit SM4 encryption, ECB mode.*/
        SM4_128_ECB = 4,

        /// @endcond
        /**5: 128-bit AES encryption, GCM mode.*/
        AES_128_GCM = 5,

        /**6: 256-bit AES encryption, GCM mode.*/
        AES_256_GCM = 6,

        /**7: 128-bit AES encryption, GCM mode. This encryption mode requires the setting of salt (encryptionKdfSalt).*/
        AES_128_GCM2 = 7,

        /**8: 256-bit AES encryption, GCM mode. This encryption mode requires the setting of salt (encryptionKdfSalt).*/
        AES_256_GCM2 = 8,

        /**Enumerator boundary.*/
        MODE_END,
    }

    /**
     * Metadata type of the observer. We only support video metadata for now.
     */
    public enum METADATA_TYPE
    {
        /**The type of metadata is unknown.*/
        UNKNOWN_METADATA = -1,

        /**The type of metadata is video.*/
        VIDEO_METADATA = 0,
    }

    /**
     *  Definition of AudioFrame.
     */
    public class AudioFrame
    {
        public AudioFrame()
        {
        }

        public AudioFrame(AUDIO_FRAME_TYPE type, int samples, int bytesPerSample, int channels, int samplesPerSec,
            byte[] buffer, long renderTimeMs, int avsync_type)
        {
            this.type = type;
            this.samples = samples;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.buffer = buffer;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
        }

        /**
         * The type of the audio frame. See AUDIO_FRAME_TYPE .
         *  
         */
        public AUDIO_FRAME_TYPE type { set; get; }

        /**The number of samples per channel in the audio frame.*/
        public int samples { set; get; } //number of samples for each channel in this frame

        /**The number of bytes per audio sample, which is usually 16-bit (2 bytes).*/
        public int bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

        public int channels { set; get; } //number of channels (data are interleaved if stereo)

        /**The number of samples per channel in the audio frame.*/
        public int samplesPerSec { set; get; } //sampling rate

        /**
         * The data buffer of the audio frame. When the audio frame uses a stereo channel, the data buffer is interleaved.
         *  Buffer data size: buffer = samples ×
         *  channels × bytesPerSample.
         *  
         */
        public byte[] buffer { set; get; } //data buffer

        /**Pointer to the data buffer.*/
        public IntPtr bufferPtr { set; get; }

        /**
         * The timestamp (ms) of the external audio frame.
         *  You can use this timestamp to restore the order of the captured audio frame, and synchronize audio and video frames in video scenarios, including scenarios where external video sources are used.
         *  
         */
        public long renderTimeMs { set; get; }

        /**A reserved parameter.*/
        public int avsync_type { set; get; }
    }

    internal class AudioFrameWithoutBuffer
    {
        public AudioFrameWithoutBuffer()
        {
        }

        public AudioFrameWithoutBuffer(AUDIO_FRAME_TYPE type, int samples, int bytesPerSample, int channels,
            int samplesPerSec, long renderTimeMs, int avsync_type)
        {
            this.type = type;
            this.samples = samples;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
        }

        public AUDIO_FRAME_TYPE type { set; get; }

        public int samples { set; get; } //number of samples for each channel in this frame

        public int bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

        public int channels { set; get; } //number of channels (data are interleaved if stereo)

        public int samplesPerSec { set; get; } //sampling rate

        public long renderTimeMs { set; get; }

        public int avsync_type { set; get; }
    }

    /**
     * The audio device information.
     */
    public struct DeviceInfo
    {
        /**The device name.*/
        public string deviceName { set; get; }
        /**The device ID.*/
        public string deviceId { set; get; }
    }

    /**
     * The external video frame.
     */
    public class ExternalVideoFrame
    {
        public ExternalVideoFrame()
        {
        }

        public ExternalVideoFrame(VIDEO_BUFFER_TYPE type, VIDEO_PIXEL_FORMAT format, byte[] buffer, int stride,
            int height, long timestamp, int cropLeft = 0, int cropTop = 0, int cropRight = 0, int cropBottom = 0,
            int rotation = 0)
        {
            this.type = type;
            this.format = format;
            this.buffer = buffer;
            this.stride = stride;
            this.height = height;
            this.cropLeft = cropLeft;
            this.cropTop = cropTop;
            this.cropRight = cropRight;
            this.cropBottom = cropBottom;
            this.rotation = rotation;
            this.timestamp = timestamp;
        }

        /**
         * The video buffer type. For details, see VIDEO_BUFFER_TYPE .
         *  
         */
        public VIDEO_BUFFER_TYPE type { set; get; }

        /**The pixel format. For details, see VIDEO_PIXEL_FORMAT .*/
        public VIDEO_PIXEL_FORMAT format { set; get; }

        /**The video buffer.*/
        public byte[] buffer { set; get; }

        /**Line spacing of the incoming video frame, which must be in pixels instead of bytes. For textures, it is the width of the texture.*/
        public int stride { set; get; }

        /**Height of the incoming video frame.*/
        public int height { set; get; }

        /**Raw data related parameter. The number of pixels trimmed from the left. The default value is 0.*/
        public int cropLeft { set; get; }

        /**Raw data related parameter. The number of pixels trimmed from the top. The default value is 0.*/
        public int cropTop { set; get; }

        /** Raw data related parameter. The number of pixels trimmed from the right. The default value is 0.*/
        public int cropRight { set; get; }

        /**Raw data related parameter. The number of pixels trimmed from the bottom. The default value is 0.*/
        public int cropBottom { set; get; }

        /**Raw data related parameter. The clockwise rotation of the video frame. You can set the rotation angle as 0, 90, 180, or 270. The default value is 0.*/
        public int rotation { set; get; }

        /**Timestamp (ms) of the incoming video frame. An incorrect timestamp results in frame loss or unsynchronized audio and video.*/
        public long timestamp { set; get; }
    }

    /**
     * Configurations of the video frame
     * The video data format is YUV420. Note that the buffer provides a pointer to a pointer. This interface cannot modify the pointer of the buffer but can modify the content of the buffer.
     */
    public class VideoFrame
    {
        /**The type of the video frame. See VIDEO_FRAME_TYPE .*/
        public VIDEO_FRAME_TYPE type;

        /**Width of the video in the number of pixels.*/
        public int width;

        /**Height of the video in the number of pixels.*/
        public int height;

        public int yStride; //stride of Y data buffer

        public int uStride; //stride of U data buffer

        public int vStride; //stride of V data buffer

        public byte[] yBuffer; //Y data buffer

        public IntPtr yBufferPtr;

        public byte[] uBuffer; //U data buffer

        public IntPtr uBufferPtr;

        public byte[] vBuffer; //V data buffer

        public IntPtr vBufferPtr;

        public int rotation; // rotation of this frame (0, 90, 180, 270)

        /**The timestamp (ms) of the external audio frame. It is mandatory. You can use it to restore the order of the captured audio frame, or synchronize audio and video frames in video-related scenarios (including scenarios where external video sources are used).*/
        public long renderTimeMs;

        /**A reserved parameter.*/
        public int avsync_type;
    }

    /**
     * The channel media options.
     */
    public class ChannelMediaOptions
    {
        public ChannelMediaOptions()
        {
            autoSubscribeAudio = true;
            autoSubscribeVideo = true;
            publishLocalAudio = true;
            publishLocalVideo = true;
        }

        public ChannelMediaOptions(bool autoSubscribeAudio, bool autoSubscribeVideo, bool publishLocalAudio,
            bool publishLocalVideo)
        {
            this.autoSubscribeAudio = autoSubscribeAudio;
            this.autoSubscribeVideo = autoSubscribeVideo;
            this.publishLocalAudio = publishLocalAudio;
            this.publishLocalVideo = publishLocalVideo;
        }

        /**
         * Whether to automatically subscribe to all remote audio streams when the user joins a channel: true: (Default) Subscribe.
         *  false: Do not subscribe.
         *  This member serves a similar function to the MuteAllRemoteAudioStreams method. After joining the channel, you can call the muteAllRemoteAudioStreams method to set whether to subscribe to audio streams in the channel.
         */
        public bool autoSubscribeAudio { set; get; }

        /**
         * Whether to subscribe to video streams when the user joins the channel: true: (Default) Subscribe.
         *  false: Do not subscribe.
         *  This member serves a similar function to the MuteAllRemoteVideoStreams method. After joining the channel, you can call the muteAllRemoteVideoStreams method to set whether to subscribe to video streams in the channel.
         */
        public bool autoSubscribeVideo { set; get; }

        /**
         *  whether to publish the local audio stream when the user joins a channel. true: (Default) Publish the local audio.
         *  false: Do not publish the local audio. This member serves a similar function to the muteLocalAudioStream method. After the user joins the channel, you can call the muteLocalAudioStream method to set whether to publish the local audio stream in the channel.
         *  
         */
        public bool publishLocalAudio { set; get; }

        /**
         *  whether to publish the local video stream when the user joins a channel. true: (Default) Publish the local video.
         *  false: Do not publish the local video. This member serves a similar function to the muteLocalVideoStream method. After the user joins the channel, you can call the muteLocalVideoStream method to set whether to publish the local audio stream in the channel.
         *  
         */
        public bool publishLocalVideo { set; get; }
    }


    /** Configurations of built-in encryption schemas. */
    public class EncryptionConfig
    {
        public EncryptionConfig()
        {
            encryptionMode = ENCRYPTION_MODE.AES_128_XTS;
            encryptionKey = "";
            encryptionKdfSalt = new byte[32];
        }

        public EncryptionConfig(ENCRYPTION_MODE encryptionMode, string encryptionKey, byte[] encryptionKdfSalt)
        {
            this.encryptionMode = encryptionMode;
            this.encryptionKey = encryptionKey;
            this.encryptionKdfSalt = encryptionKdfSalt;
        }

        /**
		 * Encryption mode. The default encryption mode is `AES_128_XTS`. See #ENCRYPTION_MODE.
		 */
        public ENCRYPTION_MODE encryptionMode { set; get; }

        /**
		 * Encryption key in string type.
		 *
		 * @note If you do not set an encryption key or set it as NULL, you cannot use the built-in encryption, and the SDK returns #ERR_INVALID_ARGUMENT (-2).
		 */
        public string encryptionKey { set; get; }

        public byte[] encryptionKdfSalt { set; get; }
    }

    /**
     * Media metadata
     */
    public class Metadata
    {
        public Metadata()
        {
            buffer = new byte[0];
        }

        public Metadata(uint uid, uint size, byte[] buffer, long timeStampMs)
        {
            this.uid = uid;
            this.size = size;
            this.buffer = buffer;
            this.timeStampMs = timeStampMs;
        }

        /**
         * User ID.
         *  For the receiver: The user ID of the user who sent the Metadata.
         *  For the sender: Ignore this value. 
         */
        public uint uid { set; get; }

        /**The buffer size of the sent or received Metadata.*/
        public uint size { set; get; }

        /**The buffer address of the sent or received Metadata.*/
        public byte[] buffer { set; get; }

        /**The timestamp (ms) of the Metadata.*/
        public long timeStampMs { set; get; }
    }

    /**
     *  Definition of Packet.
     */
    public class Packet
    {
        public Packet()
        {
            buffer = new byte[0];
        }

        public Packet(byte[] buffer, uint size)
        {
            this.buffer = buffer;
            this.size = size;
        }

        /**
         * The buffer address of the sent or received data.
         *  Agora recommends setting buffer to a value larger than 2048 bytes. Otherwise, you may encounter undefined behaviors (such as crashes).
         *  
         */
        public byte[] buffer { set; get; }

        /**The buffer size of the sent or received data.*/
        public uint size { set; get; }
    }

    /**
     * The configuration of the SDK log files.
     */
    public class LogConfig
    {
        public LogConfig()
        {
            filePath = null;
            fileSize = -1;
            level = LOG_LEVEL.LOG_LEVEL_INFO;
        }

        public LogConfig(string filePath, int fileSize = 1024, LOG_LEVEL level = LOG_LEVEL.LOG_LEVEL_INFO)
        {
            this.filePath = filePath;
            this.fileSize = fileSize;
            this.level = level;
        }

        /**
         * The absolute or relative path of the log file, which ends with \ or /. Ensure that the path for the log file exists and is writable. You can use this parameter to rename the log files.
         *  
         */
        public string filePath { set; get; }

        /**The size (KB) of a log file. The default value is 2014 KB. If you set fileSize to 1024 KB, the maximum aggregate size of the log files output by the SDK is 5 MB. If you set fileSize to less than 1024 KB, the setting is invalid, and the maximum size of a log file is still 1024 KB.*/
        public int fileSize { set; get; }

        /**The output level of the SDK log file. See LOG_LEVEL .*/
        public LOG_LEVEL level { set; get; }
    };


    /**
     * Configurations of initializing the SDK.
     */
    [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, false)]
    public class RtcEngineConfig
    {
        /**
         * The App ID issued by Agora for your app development project. Only users who use the same App ID can join the same channel and communicate with each other.
         *  
         */
        public string appId { get; set; }

        /**
         * The region for connection. This is an advanced feature and applies to scenarios that have regional restrictions. For details on supported regions, see AREA_CODE .
         *  After specifying the region, the SDK connects to the Agora servers within that region.
         */
        public AREA_CODE areaCode { get; set; }

        /**
         * The configuration of the log files. See LogConfig .
         *  By default, the SDK outputs five log files: agorasdk.log, agorasdk_1.log, agorasdk_2.log, agorasdk_3.log, and agorasdk_4.log.
         *  Each log file has a default size of 512 KB and is encoded in UTF-8 format. The SDK writes the latest log in agorasdk.log. When agorasdk.log is full, the SDK deletes the log file with the earliest modification time among the other four, renames agorasdk.log to the name of the deleted log file, and create a new agorasdk.log to record the latest log.
         */
        public LogConfig logConfig { get; set; }

        public RtcEngineConfig(string mAppId, LogConfig config, AREA_CODE mAreaCode = AREA_CODE.AREA_CODE_GLOB)
        {
            appId = mAppId;
            areaCode = mAreaCode;
            logConfig = config;
        }
    }

    /**
     * Configurations of initializing the SDK.
     */
    public class RtcEngineContext
    {
        public RtcEngineContext(string appId, AREA_CODE areaCode = AREA_CODE.AREA_CODE_GLOB,
            LogConfig logConfig = null)
        {
            this.appId = appId;
            _areaCode = (uint)areaCode;
            this.logConfig = logConfig ?? new LogConfig();
        }

        /**
         * The App ID issued by Agora for your app development project. Only users who use the same App ID can join the same channel and communicate with each other.
         *  
         */
        public string appId { set; get; }

        /**
         * The region for connection. This is an advanced feature and applies to scenarios that have regional restrictions. For details on supported regions, see AREA_CODE .
         *  After specifying the region, the SDK connects to the Agora servers within that region.
         */
        private uint _areaCode;

        /**
         * The configuration of the log files. See LogConfig .
         *  By default, the SDK outputs five log files: agorasdk.log, agorasdk_1.log, agorasdk_2.log, agorasdk_3.log, and agorasdk_4.log.
         *  Each log file has a default size of 512 KB and is encoded in UTF-8 format. The SDK writes the latest log in agorasdk.log. When agorasdk.log is full, the SDK deletes the log file with the earliest modification time among the other four, renames agorasdk.log to the name of the deleted log file, and create a new agorasdk.log to record the latest log.
         */
        public LogConfig logConfig { set; get; }

        /**
         * The region for connection. This is an advanced feature and applies to scenarios that have regional restrictions. For details on supported regions, see AREA_CODE .
         *  After specifying the region, the SDK connects to the Agora servers within that region.
         */
        public AREA_CODE areaCode
        {
            get { return (AREA_CODE)_areaCode; }
            set { _areaCode = (uint)areaCode; }
        }
    }

    /**
     * The channel mode. Set in SetAudioMixingDualMonoMode .
     */
    public enum AUDIO_MIXING_DUAL_MONO_MODE
    {
        /**0: Original mode.*/
        AUDIO_MIXING_DUAL_MONO_AUTO,
        /**1: Left channel mode. This mode replaces the audio of the right channel with the audio of the left channel, which means the user can only hear the audio of the left channel.*/
        AUDIO_MIXING_DUAL_MONO_L,
        /**2: Right channel mode. This mode replaces the audio of the left channel with the audio of the right channel, which means the user can only hear the audio of the right channel.*/
        AUDIO_MIXING_DUAL_MONO_R,
        /**3: Mixed channel mode. This mode mixes the audio of the left channel and the right channel, which means the user can hear the audio of the left channel and the right channel at the same time.*/
        AUDIO_MIXING_DUAL_MONO_MIX
    }

    /**
     * The information of an audio file. This struct is reported in OnRequestAudioFileInfo .
     */
    public struct AudioFileInfo
    {
        /**The file path.*/
        public string filePath;
        /**The file duration (ms).*/
        public int durationMs;
    }

    /**
     * The information acquisition state. This enum is reported in OnRequestAudioFileInfo .
     */
    public enum AUDIO_FILE_INFO_ERROR
    {
        /**0: Successfully get the information of an audio file.*/
        AUDIO_FILE_INFO_ERROR_OK = 0,

        /**1: Fail to get the information of an audio file.*/
        AUDIO_FILE_INFO_ERROR_FAILURE = 1
    }

    public enum CONTENT_INSPECT_RESULT
    {
        CONTENT_INSPECT_NEUTRAL = 1,
        CONTENT_INSPECT_SEXY = 2,
        CONTENT_INSPECT_PORN = 3
    }

    /**
     * The configuration of the audio and video call loop test.
     */
    public struct EchoTestConfiguration
    {
        /**The view used to render the local user's video. This parameter is only applicable to scenarios testing video devices, that is, when the enableVideo member is set to true.*/
        public IntPtr view;
        /**
         * Whether to enable the audio device for the call loop test: true: (Default) Enables the audio device. To test the audio device, set this parameter as true.
         *  false: Disables the audio device.
         *  
         */
        public bool enableAudio;
        /**
         * Whether to enable the video device for the call loop test: true: (Default) Enables the video device. To test the video device, set this parameter as true.
         *  false: Disables the video device.
         *  
         */
        public bool enableVideo;
        /**
         * The token used to secure the audio and video call loop test. If you do not enable App Certificate in Agora Console, 
         *  you do not need to pass a value in this parameter; if you have enabled App Certificate in Agora Console, you must 
         *  pass a token in this parameter. The uid used when you generate the token must be 0xFFFFFFFF, 
         *  and the channel name used must be the channel name that identifies each audio and video call loop test. For 
         *  server-side token generation, see .
         *  
         */
        public string token;
        /**
         * The channel name that identifies each audio and video call loop. To ensure proper loop test functionality, the channel 
         *  name passed in to identify each loop test cannot be the same when users of the same project (App ID) perform audio and video call loop tests on different devices.
         */
        public string channelId;
    }

    public struct ContentInspectModule
    {
        public int type;
        public int interval;
    }

    public struct ContentInspectConfig
    {
        public string extraInfo;
        public ContentInspectModule[] modules;
        public int moduleCount;
    }

    public enum AVDATA_TYPE
    {
        AVDATA_UNKNOWN = 0,
        AVDATA_VIDEO = 1,
        AVDATA_AUDIO = 2
    }

    public enum CODEC_VIDEO
    {
        CODEC_VIDEO_AVC = 0,
        CODEC_VIDEO_HEVC = 1,
        CODEC_VIDEO_VP8 = 2
    }

    public enum CODEC_AUDIO
    {
        CODEC_AUDIO_PCM = 0,
        CODEC_AUDIO_AAC = 1,
        CODEC_AUDIO_G722 = 2
    }

    public class VDataInfo
    {
        public uint codec;
        public uint width;
        public uint height;
        public int frameType;
        public int rotation;
        public bool equal(VDataInfo vinfo) { return codec == vinfo.codec && width == vinfo.width && height == vinfo.height && rotation == vinfo.rotation; }
    }

    public class ADataInfo
    {
        public uint codec;
        public uint bitwidth;
        public uint sample_rate;
        public uint channel;
        public uint sample_size;

        public bool equal(ADataInfo ainfo) { return codec == ainfo.codec && bitwidth == ainfo.bitwidth && sample_rate == ainfo.sample_rate && channel == ainfo.channel; }
    }

    public struct AVData
    {
        public uint uid;
        public AVDATA_TYPE type;
        public uint size;
        public byte[] buffer;
        public uint timestamp;
        public VDataInfo vinfo;
        public ADataInfo ainfo;
    }

    /**
     * The format of the recording file.
     */
    public enum MediaRecorderContainerFormat
    {
        /**1: (Default) MP4.*/
        FORMAT_MP4 = 1,
        /**Reserved parameter.*/
        FORMAT_FLV = 2
    }

    /**
     * The recording content.
     */
    public enum MediaRecorderStreamType
    {
        /**Only audio.*/
        STREAM_TYPE_AUDIO = 0x01,
        /**only video.*/
        STREAM_TYPE_VIDEO = 0x02,
        /**(Default) Audio and video.*/
        STREAM_TYPE_BOTH = STREAM_TYPE_AUDIO | STREAM_TYPE_VIDEO
    }

    /**
     * The current recording state.
     */
    public enum RecorderState
    {
        /**-1: An error occurs during the recording. See RecorderErrorCode for the reason.*/
        RECORDER_STATE_ERROR = -1,
        /**2: The audio and video recording starts.*/
        RECORDER_STATE_START = 2,
        /**3: The audio and video recording stops.*/
        RECORDER_STATE_STOP = 3
    }

    /**
     * The reason for the state change.
     */
    public enum RecorderErrorCode
    {
        /**0: No error occurs.*/
        RECORDER_ERROR_NONE = 0,
        /**1: The SDK fails to write the recorded data to a file.*/
        RECORDER_ERROR_WRITE_FAILED = 1,
        /**
         * 2: The SDK does not detect audio and video streams to be recorded,
         *  or audio and video streams are interrupted for more than five seconds during recording.
         */
        RECORDER_ERROR_NO_STREAM = 2,
        /**3: The recording duration exceeds the upper limit.*/
        RECORDER_ERROR_OVER_MAX_DURATION = 3,
        /**4: The recording configuration changes.*/
        RECORDER_ERROR_CONFIG_CHANGED = 4,
        /**
         * 5: The SDK detects audio and video streams from users using versions of the SDK earlier than v3.0.0 in the
         *  COMMUNICATION channel profile.
         */
        RECORDER_ERROR_CUSTOM_STREAM_DETECTED = 5
    }

    /**
     * Configurations for the local audio and video recording.
     */
    public struct MediaRecorderConfiguration
    {
        /**The absolute path (including the filename extensions) of the recording file. For example, C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.mp4 on Windows, /App Sandbox/Library/Caches/example.mp4 on iOS, /Library/Logs/example.mp4 on macOS, and /storage/emulated/0/Android/data/<package name>/files/example.mp4 on Android.*/
        public string storagePath;
        /**The format of the recording file. See MediaRecorderContainerFormat .*/
        public MediaRecorderContainerFormat containerFormat;
        /**The recording content. See MediaRecorderStreamType .*/
        public MediaRecorderStreamType streamType;
        /**The maximum recording duration, in milliseconds. The default value is 120,000.*/
        public int maxDurationMs;
        /**The interval (ms) of updating the recording information. The value range is [1000,10000]. The SDK triggers the OnRecorderInfoUpdated callback to report the updated recording information according to interval you set in this parameter.*/
        public int recorderInfoUpdateInterval;
    }

    /**
     * Information for the recording file.
     */
    public struct RecorderInfo
    {
        /**The absolute path of the recording file.*/
        public string fileName;
        /**The recording duration, in milliseconds.*/
        public uint durationMs;
        /**The size of the recording file, in bytes. */
        public uint fileSize;
    }

    /**
     * The low-light enhancement mode.
     */
    public enum LOW_LIGHT_ENHANCE_MODE
    {
        /**0: (Default) Automatic mode. The SDK automatically enables or disables the low-light enhancement feature according to the ambient light to compensate for the lighting level or prevent overexposure, as necessary.*/
        LOW_LIGHT_ENHANCE_AUTO = 0,
        /**Manual mode. Users need to enable or disable the low-light enhancement feature manually.*/
        LOW_LIGHT_ENHANCE_MANUAL
    }

    /**
     * The low-light enhancement level.
     */
    public enum LOW_LIGHT_ENHANCE_LEVEL
    {
        /**0: (Default) Promotes video quality during low-light enhancement. It processes the brightness, details, and noise of the video image. The performance consumption is moderate, the processing speed is moderate, and the overall video quality is optimal.*/
        LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY = 0,
        /**Promotes performance during low-light enhancement. It processes the brightness and details of the video image. The processing speed is faster.*/
        LOW_LIGHT_ENHANCE_LEVEL_FAST
    }


    /**
     * The low-light enhancement options.
     */
    public class LowLightEnhanceOptions
    {
        public LowLightEnhanceOptions()
        {
        }

        public LowLightEnhanceOptions(LOW_LIGHT_ENHANCE_MODE mode, LOW_LIGHT_ENHANCE_LEVEL level)
        {
            this.mode = mode;
            this.level = level;
        }

        /**The low-light enhancement mode. For details, see LOW_LIGHT_ENHANCE_MODE .*/
        public LOW_LIGHT_ENHANCE_MODE mode { set; get; }

        /**The low-light enhancement level. For details, see LOW_LIGHT_ENHANCE_LEVEL .*/
        public LOW_LIGHT_ENHANCE_LEVEL level { set; get; }
    }

    /**
     * Video noise reduction mode.
     */
    public enum VIDEO_DENOISER_MODE
    {
        /**0: (Default) Automatic mode. The SDK automatically enables or disables the video noise reduction feature according to the ambient light.*/
        VIDEO_DENOISER_AUTO = 0,
        /**Manual mode. Users need to enable or disable the video noise reduction feature manually.*/
        VIDEO_DENOISER_MANUAL
    }

    /**
     * The video noise reduction level.
     */
    public enum VIDEO_DENOISER_LEVEL
    {
        /**0: (Default) Promotes video quality during video noise reduction. VIDEO_DENOISER_LEVEL_HIGH_QUALITY balances performance consumption and video noise reduction quality. The performance consumption is moderate, the video noise reduction speed is moderate, and the overall video quality is optimal.*/
        VIDEO_DENOISER_LEVEL_HIGH_QUALITY = 0,
        /**Promotes reducing performance consumption during video noise reduction. VIDEO_DENOISER_LEVEL_FAST prioritizes reducing performance consumption over video noise reduction quality. The performance consumption is lower, and the video noise reduction speed is faster. To avoid a noticeable shadowing effect (shadows trailing behind moving objects) in the processed video, Agora recommends that you use VIDEO_DENOISER_LEVEL_FAST when the camera is fixed.*/
        VIDEO_DENOISER_LEVEL_FAST,
        /**Enhanced video noise reduction. VIDEO_DENOISER_LEVEL_STRENGTH prioritizes video noise reduction quality over reducing performance consumption. The performance consumption is higher, the video noise reduction speed is slower, and the video noise reduction quality is better. If VIDEO_DENOISER_LEVEL_STRENGTH is not enough for your video noise reduction needs, you can use VIDEO_DENOISER_LEVEL_STRENGTH.*/
        VIDEO_DENOISER_LEVEL_STRENGTH
    }

    /**
     * Video noise reduction options.
     */
    public class VideoDenoiserOptions
    {
        public VideoDenoiserOptions()
        {
        }

        public VideoDenoiserOptions(VIDEO_DENOISER_MODE mode, VIDEO_DENOISER_LEVEL level)
        {
            this.mode = mode;
            this.level = level;
        }
        /**Video noise reduction mode. For details, see VIDEO_DENOISER_MODE .*/
        public VIDEO_DENOISER_MODE mode { set; get; }

        /**Video noise reduction level. For details, see VIDEO_DENOISER_LEVEL .*/
        public VIDEO_DENOISER_LEVEL level { set; get; }
    }

    /**
     * The color enhancement options.
     */
    public class ColorEnhanceOptions
    {
        public ColorEnhanceOptions()
        {
        }

        public ColorEnhanceOptions(float strengthLevel, float skinProtectLevel)
        {
            this.strengthLevel = strengthLevel;
            this.skinProtectLevel = skinProtectLevel;
        }
        /**The level of color enhancement. The value range is [0.0, 1.0]. 0.0 is the default value, which means no color enhancement is applied to the video. The higher the value, the higher the level of color enhancement.*/
        public float strengthLevel { set; get; }

        /**The level of skin tone protection. The value range is [0.0, 1.0]. 0.0 means no skin tone protection. The higher the value, the higher the level of skin tone protection. The default value is 100.The default value is 1.0. When the level of color enhancement is higher, the portrait skin tone can be significantly distorted, so you need to set the level of skin tone protection; when the level of skin tone protection is higher, the color enhancement effect can be slightly reduced. Therefore, to get the best color enhancement effect, Agora recommends that you adjust strengthLevel and skinProtectLevel to get the most appropriate values.*/
        public float skinProtectLevel { set; get; }
    }

    /**
     * Screen sharing information.
     */
    public class ScreenCaptureInfo
    {
        public ScreenCaptureInfo()
        {
        }

        public ScreenCaptureInfo(string graphicsCardType, EXCLUDE_WINDOW_ERROR errCode)
        {
            this.graphicsCardType = graphicsCardType;
            this.errCode = errCode;
        }
        /**
         * Graphics card type, including model information for the graphics card.
         *  
         */
        public string graphicsCardType;
        /**
         * Error code that blocks the window when sharing the screen. See EXCLUDE_WINDOW_ERROR .
         *  
         */
        public EXCLUDE_WINDOW_ERROR errCode;
    }

    /**
     *  The error code of the window blocking during screen sharing. 
     */
    public enum EXCLUDE_WINDOW_ERROR
    {
        /**-1: Fails to block the window during screen sharing. The user's graphics card does not support window blocking.*/
        EXCLUDE_WINDOW_FAIL = -1,
        /**0: Reserved.*/
        EXCLUDE_WINDOW_NONE = 0
    }

    public enum LOCAL_PROXY_MODE
    {
        ConnectivityFirst = 0,
        LocalOnly = 1,
    }

    /**
     * The proxy type.
     */
    public enum PROXY_TYPE
    {
        /**0: Reserved for future use.*/
        NONE_PROXY_TYPE = 0,
        /**1: The cloud proxy for the UDP protocol, that is, the Force UDP cloud proxy mode. In this mode, the SDK always transmits data over UDP.*/
        UDP_PROXY_TYPE = 1,
        /**2: The cloud proxy for the TCP (encryption) protocol, that is, the Force TCP cloud proxy mode. In this mode, the SDK always transmits data over TLS 443.*/
        TCP_PROXY_TYPE = 2,
        /**3: Reserved for future use.*/
        LOCAL_PROXY_TYPE = 3,
        /**4: The automatic mode. In this mode, the SDK attempts a direct connection to SD-RTN™ and automatically switches to TLS 443 if the attempt fails.*/
        TCP_PROXY_AUTO_FALLBACK_TYPE = 4,
    }

    public enum CLIENT_ROLE_CHANGE_FAILED_REASON
    {
        CLIENT_ROLE_CHANGE_FAILED_BY_TOO_MANY_BROADCASTERS = 1,

        CLIENT_ROLE_CHANGE_FAILED_BY_NOT_AUTHORIZED = 2,

        CLIENT_ROLE_CHANGE_FAILED_BY_REQUEST_TIME_OUT = 3,

        CLIENT_ROLE_CHANGE_FAILED_BY_CONNECTION_FAILED = 4,
    }

    public enum WLACC_MESSAGE_REASON
    {
        WLACC_MESSAGE_REASON_WEAK_SIGNAL = 0,
        WLACC_MESSAGE_REASON_CHANNEL_CONGESTION = 1,
    }

    public enum WLACC_SUGGEST_ACTION
    {
        WLACC_SUGGEST_ACTION_CLOSE_TO_WIFI = 0,
        WLACC_SUGGEST_ACTION_CONNECT_SSID = 1,
        WLACC_SUGGEST_ACTION_CHECK_5G = 2,
        WLACC_SUGGEST_ACTION_MODIFY_SSID = 3,
    }

    public class WlAccStats
    {
        public WlAccStats()
        {
        }

        public WlAccStats(ushort e2eDelayPercent, ushort frozenRatioPercent, ushort lossRatePercent)
        {
            this.e2eDelayPercent = e2eDelayPercent;
            this.frozenRatioPercent = frozenRatioPercent;
            this.lossRatePercent = lossRatePercent;
        }
        public ushort e2eDelayPercent { set; get; }
        public ushort frozenRatioPercent { set; get; }
        public ushort lossRatePercent { set; get; }
    }


    /**
     * The volume type.
     */
    public enum AudioDeviceTestVolumeType
    {
        AudioTestRecordingVolume = 0,
        AudioTestPlaybackVolume = 1,
    }

    public struct LocalAccessPointConfiguration
    {
        public string[] ipList;
        public int ipListSize;
        public string[] domainList;
        public int domainListSize;
        public string[] verifyDomainName;
        public LOCAL_PROXY_MODE mode;
    }

    public enum AgoraEngineType
    {
        MainProcess,
        SubProcess
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}
