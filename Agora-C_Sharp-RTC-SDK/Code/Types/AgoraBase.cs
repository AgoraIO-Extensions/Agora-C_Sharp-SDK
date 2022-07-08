using System;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    using int64_t = Int64;
    using uint64_t = UInt64;
    using view_t = UInt64;

    #region AgoraBase

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
        APP_TYPE_UNI_APP = 14
    };

    ///
    /// <summary>
    /// The channel profile.
    /// </summary>
    ///
    public enum CHANNEL_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 0: Communication. Use this profile when there are only two users in the channel.
        /// </summary>
        ///
        CHANNEL_PROFILE_COMMUNICATION = 0,

        ///
        /// <summary>
        /// 1: Live streaming. Live streaming. Use this profile when there are more than two users in the channel.
        /// </summary>
        ///
        CHANNEL_PROFILE_LIVE_BROADCASTING = 1,

        ///
        /// <summary>
        /// 2: Gaming. This profile is deprecated.
        /// </summary>
        ///
        [Obsolete("This profile is deprecated")]
        CHANNEL_PROFILE_GAME = 2,

        ///
        /// <summary>
        /// Cloud gaming. The scenario is optimized for latency. Use this profile if the use case requires frequent interactions between users.
        /// </summary>
        ///
        CHANNEL_PROFILE_CLOUD_GAMING = 3,

        CHANNEL_PROFILE_COMMUNICATION_1v1 = 4,

        CHANNEL_PROFILE_LIVE_BROADCASTING_2 = 5,
    };

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

        WARN_ADM_IOS_CATEGORY_NOT_PLAYANDRECORD = 1029,

        WARN_ADM_IOS_SAMPLERATE_CHANGE = 1030,

        WARN_ADM_RECORD_AUDIO_LOWLEVEL = 1031,

        WARN_ADM_PLAYOUT_AUDIO_LOWLEVEL = 1032,

        WARN_ADM_WINDOWS_NO_DATA_READY_EVENT = 1040,

        WARN_APM_HOWLING = 1051,

        WARN_ADM_GLITCH_STATE = 1052,

        WARN_ADM_IMPROPER_SETTINGS = 1053,

        WARN_ADM_WIN_CORE_NO_RECORDING_DEVICE = 1322,

        WARN_ADM_WIN_CORE_NO_PLAYOUT_DEVICE = 1323,

        WARN_ADM_WIN_CORE_IMPROPER_CAPTURE_RELEASE = 1324,
    };

    public enum ERROR_CODE_TYPE
    {
        ERR_OK = 0,

        ERR_FAILED = 1,

        ERR_INVALID_ARGUMENT = 2,

        ERR_NOT_READY = 3,

        ERR_NOT_SUPPORTED = 4,

        ERR_REFUSED = 5,

        ERR_BUFFER_TOO_SMALL = 6,

        ERR_NOT_INITIALIZED = 7,

        ERR_INVALID_STATE = 8,

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

        ERR_CONNECTION_INTERRUPTED = 111,  // only used in web sdk

        ERR_CONNECTION_LOST = 112,  // only used in web sdk

        ERR_NOT_IN_CHANNEL = 113,

        ERR_SIZE_TOO_LARGE = 114,

        ERR_BITRATE_LIMIT = 115,

        ERR_TOO_MANY_DATA_STREAMS = 116,

        ERR_STREAM_MESSAGE_TIMEOUT = 117,

        ERR_SET_CLIENT_ROLE_NOT_AUTHORIZED = 119,

        ERR_DECRYPTION_FAILED = 120,

        ERR_INVALID_USER_ID = 121,

        ERR_CLIENT_IS_BANNED_BY_SERVER = 123,

        ERR_WATERMARK_PARAM = 124,

        ERR_WATERMARK_PATH = 125,

        ERR_WATERMARK_PNG = 126,

        ERR_WATERMARKR_INFO = 127,

        ERR_WATERMARK_ARGB = 128,

        ERR_WATERMARK_READ = 129,

        ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH = 130,

        ERR_LICENSE_CREDENTIAL_INVALID = 131,

        ERR_INVALID_USER_ACCOUNT = 134,

        ERR_CERT_RAW = 157,

        ERR_CERT_JSON_PART = 158,

        ERR_CERT_JSON_INVAL = 159,

        ERR_CERT_JSON_NOMEM = 160,

        ERR_CERT_CUSTOM = 161,

        ERR_CERT_CREDENTIAL = 162,

        ERR_CERT_SIGN = 163,

        ERR_CERT_FAIL = 164,

        ERR_CERT_BUF = 165,

        ERR_CERT_NULL = 166,

        ERR_CERT_DUEDATE = 167,

        ERR_CERT_REQUEST = 168,

        ERR_PCMSEND_FORMAT = 200,           // unsupport pcm format

        ERR_PCMSEND_BUFFEROVERFLOW = 201,  // buffer overflow, the pcm send rate too quickly

        ERR_LOGOUT_OTHER = 400,          //

        ERR_LOGOUT_USER = 401,           // logout by user

        ERR_LOGOUT_NET = 402,            // network failure

        ERR_LOGOUT_KICKED = 403,         // login in other device

        ERR_LOGOUT_PACKET = 404,         //

        ERR_LOGOUT_TOKEN_EXPIRED = 405,  // token expired

        ERR_LOGOUT_OLDVERSION = 406,     //

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
        [Obsolete]
        ERR_ADM_ANDROID_OPENSL_CREATE_ENGINE = 1151,
        [Obsolete]
        ERR_ADM_ANDROID_OPENSL_CREATE_AUDIO_RECORDER = 1153,
        [Obsolete]
        ERR_ADM_ANDROID_OPENSL_START_RECORDER_THREAD = 1156,
        [Obsolete]
        ERR_ADM_ANDROID_OPENSL_CREATE_AUDIO_PLAYER = 1157,
        [Obsolete]
        ERR_ADM_ANDROID_OPENSL_START_PLAYER_THREAD = 1160,

        ERR_ADM_IOS_INPUT_NOT_AVAILABLE = 1201,

        ERR_ADM_IOS_ACTIVATE_SESSION_FAIL = 1206,

        ERR_ADM_IOS_VPIO_INIT_FAIL = 1210,

        ERR_ADM_IOS_VPIO_REINIT_FAIL = 1213,

        ERR_ADM_IOS_VPIO_RESTART_FAIL = 1214,

        ERR_ADM_IOS_SET_RENDER_CALLBACK_FAIL = 1219,
        [Obsolete]
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

        ERR_VDM_CAMERA_NOT_AUTHORIZED = 1501,

        ERR_VDM_WIN_DEVICE_IN_USE = 1502,

        ERR_VCM_UNKNOWN_ERROR = 1600,

        ERR_VCM_ENCODER_INIT_ERROR = 1601,

        ERR_VCM_ENCODER_ENCODE_ERROR = 1602,

        ERR_VCM_ENCODER_SET_ERROR = 1603,
    };

    ///
    /// <summary>
    /// The operation permissions of the SDK on the audio session.
    /// </summary>
    ///
    public enum AUDIO_SESSION_OPERATION_RESTRICTION
    {
        ///
        /// <summary>
        /// No restriction, the SDK can change the audio session.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_NONE = 0,

        ///
        /// <summary>
        /// The SDK cannot change the audio session category.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_SET_CATEGORY = 1,

        ///
        /// <summary>
        /// The SDK cannot change the audio session category, mode, or categoryOptions.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION = 1 << 1,

        ///
        /// <summary>
        /// The SDK keeps the audio session active when the user leaves the channel, for example, to play an audio file in the background.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_DEACTIVATE_SESSION = 1 << 2,

        ///
        /// <summary>
        /// Completely restricts the operation permissions of the SDK on the audio session; the SDK cannot change the audio session.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_ALL = 1 << 7,
    };

    ///
    /// <summary>
    /// Reasons for a user being offline.
    /// </summary>
    ///
    public enum USER_OFFLINE_REASON_TYPE
    {
        ///
        /// <summary>
        /// 0: The user quits the call.
        /// </summary>
        ///
        USER_OFFLINE_QUIT = 0,

        ///
        /// <summary>
        /// 1: The SDK times out and the user drops offline because no data packet is received within a certain period of time. If the user quits the call and the message is not passed to the SDK (due to an unreliable channel), the SDK assumes the user dropped offline.
        /// </summary>
        ///
        USER_OFFLINE_DROPPED = 1,

        ///
        /// <summary>
        /// 2: The user switches the client role from the host to the audience.
        /// </summary>
        ///
        USER_OFFLINE_BECOME_AUDIENCE = 2,
    };

    ///
    /// <summary>
    /// The interface class.
    /// </summary>
    ///
    public enum INTERFACE_ID_TYPE
    {
        ///
        /// <summary>
        /// The IAudioDeviceManager interface class.
        /// </summary>
        ///
        AGORA_IID_AUDIO_DEVICE_MANAGER = 1,

        ///
        /// <summary>
        /// The IVideoDeviceManager interface class.
        /// </summary>
        ///
        AGORA_IID_VIDEO_DEVICE_MANAGER = 2,

        AGORA_IID_PARAMETER_ENGINE = 3,

        AGORA_IID_MEDIA_ENGINE = 4,

        AGORA_IID_AUDIO_ENGINE = 5,

        AGORA_IID_VIDEO_ENGINE = 6,

        AGORA_IID_RTC_CONNECTION = 7,

        ///
        /// <summary>
        /// This interface class is deprecated.
        /// </summary>
        ///
        AGORA_IID_SIGNALING_ENGINE = 8,

        AGORA_IID_MEDIA_ENGINE_REGULATOR = 9,

        AGORA_IID_CLOUD_SPATIAL_AUDIO = 10,

        AGORA_IID_LOCAL_SPATIAL_AUDIO = 11,
    };

    ///
    /// <summary>
    /// Network quality types.
    /// </summary>
    ///
    public enum QUALITY_TYPE
    {
        [Obsolete("This member is deprecated")]
        QUALITY_UNKNOWN = 0,

        ///
        /// <summary>
        /// 1: The network quality is excellent.
        /// </summary>
        ///
        QUALITY_EXCELLENT = 1,

        ///
        /// <summary>
        /// 2: The network quality is quite good, but the bitrate may be slightly lower than excellent.
        /// </summary>
        ///
        QUALITY_GOOD = 2,

        ///
        /// <summary>
        /// 3: Users can feel the communication is slightly impaired.
        /// </summary>
        ///
        QUALITY_POOR = 3,

        ///
        /// <summary>
        /// 4: Users cannot communicate smoothly.
        /// </summary>
        ///
        QUALITY_BAD = 4,

        ///
        /// <summary>
        /// 5: The quality is so bad that users can barely communicate.
        /// </summary>
        ///
        QUALITY_VBAD = 5,

        ///
        /// <summary>
        /// 6: The network is down and users cannot communicate at all.
        /// </summary>
        ///
        QUALITY_DOWN = 6,

        ///
        /// <summary>
        /// 7: Users cannot detect the network quality. (Not in use.)
        /// </summary>
        ///
        QUALITY_UNSUPPORTED = 7,

        ///
        /// <summary>
        /// 8: Detecting the network quality.
        /// </summary>
        ///
        QUALITY_DETECTING = 8
    };

    public enum FIT_MODE_TYPE
    {
        MODE_COVER = 1,

        MODE_CONTAIN = 2,
    };

    ///
    /// <summary>
    /// The clockwise rotation of the video.
    /// </summary>
    ///
    public enum VIDEO_ORIENTATION
    {
        ///
        /// <summary>
        /// 0: (Default) No rotation.
        /// </summary>
        ///
        VIDEO_ORIENTATION_0 = 0,

        ///
        /// <summary>
        /// 90: 90 degrees.
        /// </summary>
        ///
        VIDEO_ORIENTATION_90 = 90,

        ///
        /// <summary>
        /// 180: 180 degrees.
        /// </summary>
        ///
        VIDEO_ORIENTATION_180 = 180,

        ///
        /// <summary>
        /// 270: 270 degrees.
        /// </summary>
        ///
        VIDEO_ORIENTATION_270 = 270
    };

    ///
    /// <summary>
    /// Video frame rate.
    /// </summary>
    ///
    public enum FRAME_RATE
    {
        ///
        /// <summary>
        /// 1:1 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_1 = 1,

        ///
        /// <summary>
        /// 7:7fps
        /// </summary>
        ///
        FRAME_RATE_FPS_7 = 7,

        ///
        /// <summary>
        /// 10: 10fps
        /// </summary>
        ///
        FRAME_RATE_FPS_10 = 10,

        ///
        /// <summary>
        /// 15: 15fps
        /// </summary>
        ///
        FRAME_RATE_FPS_15 = 15,

        ///
        /// <summary>
        /// 24: 24fps
        /// </summary>
        ///
        FRAME_RATE_FPS_24 = 24,

        ///
        /// <summary>
        /// 30: 30fps
        /// </summary>
        ///
        FRAME_RATE_FPS_30 = 30,

        ///
        /// <summary>
        /// 60: 60fps
        /// For Windows and macOS only.
        /// </summary>
        ///
        FRAME_RATE_FPS_60 = 60,
    };

    public enum FRAME_WIDTH
    {
        FRAME_WIDTH_640 = 640,
    };

    public enum FRAME_HEIGHT
    {
        FRAME_HEIGHT_360 = 360,
    };

    ///
    /// <summary>
    /// The video frame type.
    /// </summary>
    ///
    public enum VIDEO_FRAME_TYPE
    {
        ///
        /// <summary>
        /// 0: A black frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_BLANK_FRAME = 0,

        ///
        /// <summary>
        /// 3: Keyframe.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_KEY_FRAME = 3,

        ///
        /// <summary>
        /// 4: Delta frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_DELTA_FRAME = 4,

        ///
        /// <summary>
        /// 5:The B frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_B_FRAME = 5,

        ///
        /// <summary>
        /// 6: A discarded frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_DROPPABLE_FRAME = 6,

        ///
        /// <summary>
        /// Unknown frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_UNKNOW = 7,
    };

    public enum VIDEO_FRAME_TYPE_NATIVE
    {
        VIDEO_FRAME_TYPE_BLANK_FRAME = 0,

        VIDEO_FRAME_TYPE_KEY_FRAME = 3,

        VIDEO_FRAME_TYPE_DELTA_FRAME = 4,

        VIDEO_FRAME_TYPE_B_FRAME = 5,

        VIDEO_FRAME_TYPE_DROPPABLE_FRAME = 6,

        VIDEO_FRAME_TYPE_UNKNOW
    };

    ///
    /// <summary>
    /// Video output orientation mode.
    /// </summary>
    ///
    public enum ORIENTATION_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) The output video always follows the orientation of the captured video.
        /// The receiver takes the rotational information passed on from the video encoder. This mode applies to scenarios where video orientation can be adjusted on the receiver. If the captured video is in landscape mode, the output video is in landscape mode.
        /// If the captured video is in portrait mode, the output video is in portrait mode.
        /// </summary>
        ///
        ORIENTATION_MODE_ADAPTIVE = 0,

        ///
        /// <summary>
        /// 1: In this mode, the SDK always outputs videos in landscape (horizontal) mode. If the captured video is in portrait mode, the video encoder crops it to fit the output. Applies to situations where the receiving end cannot process the rotational information. For example, CDN live streaming.
        /// </summary>
        ///
        ORIENTATION_MODE_FIXED_LANDSCAPE = 1,

        ///
        /// <summary>
        /// 2: In this mode, the SDK always outputs video in portrait (portrait) mode. If the captured video is in landscape mode, the video encoder crops it to fit the output.\nApplies to situations where the receiving end cannot process the rotational information. For example, CDN live streaming.
        /// </summary>
        ///
        ORIENTATION_MODE_FIXED_PORTRAIT = 2,
    };

    ///
    /// <summary>
    /// Video degradation preferences when the bandwidth is a constraint.
    /// </summary>
    ///
    public enum DEGRADATION_PREFERENCE
    {
        ///
        /// <summary>
        /// 0: (Default) Prefers to reduce the video frame rate while maintaining video quality during video encoding under limited bandwidth. This degradation preference is suitable for scenarios where video quality is prioritized.
        /// In the COMMUNICATION channel profile, the resolution of the video sent may change, so remote users need to handle this issue. See OnVideoSizeChanged .
        /// </summary>
        ///
        MAINTAIN_QUALITY = 0,

        ///
        /// <summary>
        /// 1: Prefers to reduce the video quality while maintaining the video frame rate during video encoding under limited bandwidth. This degradation preference is suitable for scenarios where smoothness is prioritized and video quality is allowed to be reduced.
        /// </summary>
        ///
        MAINTAIN_FRAMERATE = 1,

        ///
        /// <summary>
        /// 2: Reduces the video frame rate and video quality simultaneously during video encoding under limited bandwidth. The MAINTAIN_BALANCED has a lower reduction than MAINTAIN_QUALITY and MAINTAIN_FRAMERATE, and this preference is suitable for scenarios where both smoothness and video quality are a priority.
        /// </summary>
        ///
        MAINTAIN_BALANCED = 2,

        ///
        /// <summary>
        /// 3: When the bandwidth is limited, the video frame rate is preferentially reduced during video encoding.
        /// </summary>
        ///
        MAINTAIN_RESOLUTION = 3,

        DISABLED = 100,
    };

    ///
    /// <summary>
    /// The video dimension.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// The width (pixels) of the video.
        /// </summary>
        ///
        public int width { set; get; }
        ///
        /// <summary>
        /// The height (pixels) of the video.
        /// </summary>
        ///
        public int height { set; get; }
    }

    ///
    /// <summary>
    /// The encoding bitrate of the video.
    /// </summary>
    ///
    public enum BITRATE
    {
        ///
        /// <summary>
        /// (Recommended) Standard bitrate mode. In this mode, the video bitrate is twice the base bitrate.
        /// </summary>
        ///
        STANDARD_BITRATE = 0,

        ///
        /// <summary>
        /// Adaptive bitrate mode In this mode, the video bitrate is the same as the base bitrate. If you choose this mode in the interactive streaming profile, the video frame rate may be lower than the set value.
        /// </summary>
        ///
        COMPATIBLE_BITRATE = -1,

        DEFAULT_MIN_BITRATE = -1,

        DEFAULT_MIN_BITRATE_EQUAL_TO_TARGET_BITRATE = -2,
    }

    ///
    /// <summary>
    /// Video codec types.
    /// </summary>
    ///
    public enum VIDEO_CODEC_TYPE
    {
        VIDEO_CODEC_NONE = 0,

        ///
        /// <summary>
        /// 1: Standard VP8.
        /// </summary>
        ///
        VIDEO_CODEC_VP8 = 1,

        ///
        /// <summary>
        /// 2: Standard H.264.
        /// </summary>
        ///
        VIDEO_CODEC_H264 = 2,

        ///
        /// <summary>
        /// 3: Standard H.265.
        /// </summary>
        ///
        VIDEO_CODEC_H265 = 3,

        VIDEO_CODEC_VP9 = 5,

        ///
        /// <summary>
        /// 6: Generic.
        /// This type is used for transmitting raw video data, such as encrypted video frames. The SDK returns this type of video frames in callbacks, and you need to decode and render the frames yourself.
        /// </summary>
        ///
        VIDEO_CODEC_GENERIC = 6,

        VIDEO_CODEC_GENERIC_H264 = 7,

        VIDEO_CODEC_AV1 = 12,

        ///
        /// <summary>
        /// 20: Generic JPEG.This type consumes minimum computing resources and applies to IoT devices.
        /// </summary>
        ///
        VIDEO_CODEC_GENERIC_JPEG = 20,
    };

    ///
    /// <summary>
    /// The codec type of audio.
    /// </summary>
    ///
    public enum AUDIO_CODEC_TYPE
    {
        ///
        /// <summary>
        /// 1: OPUS.
        /// </summary>
        ///
        AUDIO_CODEC_OPUS = 1,

        ///
        /// <summary>
        /// 3: PCMA.
        /// </summary>
        ///
        AUDIO_CODEC_PCMA = 3,

        ///
        /// <summary>
        /// 4: PCMU.
        /// </summary>
        ///
        AUDIO_CODEC_PCMU = 4,

        ///
        /// <summary>
        /// 5: G722.
        /// </summary>
        ///
        AUDIO_CODEC_G722 = 5,

        ///
        /// <summary>
        /// 8: LC-AAC.
        /// </summary>
        ///
        AUDIO_CODEC_AACLC = 8,

        ///
        /// <summary>
        /// 9: HE-AAC.
        /// </summary>
        ///
        AUDIO_CODEC_HEAAC = 9,

        ///
        /// <summary>
        /// 10: JC1.
        /// </summary>
        ///
        AUDIO_CODEC_JC1 = 10,

        ///
        /// <summary>
        /// 11: HE-AAC v2.
        /// </summary>
        ///
        AUDIO_CODEC_HEAAC2 = 11,

        AUDIO_CODEC_LPCNET = 12,
    };

    ///
    /// <summary>
    /// Audio encoding type.
    /// </summary>
    ///
    [Flags]
    public enum AUDIO_ENCODING_TYPE
    {
        ///
        /// <summary>
        /// AAC encoding format, 16000 Hz sampling rate, bass quality. A file with an audio duration of 10 minutes is approximately 1.2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_16000_LOW = 0x010101,

        ///
        /// <summary>
        /// AAC encoding format, 16000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_16000_MEDIUM = 0x010102,

        ///
        /// <summary>
        /// AAC encoding format, 32000 Hz sampling rate, bass quality. A file with an audio duration of 10 minutes is approximately 1.2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_32000_LOW = 0x010201,

        ///
        /// <summary>
        /// AAC encoding format, 32000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_32000_MEDIUM = 0x010202,

        ///
        /// <summary>
        /// AAC encoding format, 32000 Hz sampling rate, high sound quality. A file with an audio duration of 10 minutes is approximately 3.5 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_32000_HIGH = 0x010203,

        ///
        /// <summary>
        /// AAC encoding format, 48000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_48000_MEDIUM = 0x010302,

        ///
        /// <summary>
        /// AAC encoding format, 48000 Hz sampling rate, high sound quality. A file with an audio duration of 10 minutes is approximately 3.5 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_48000_HIGH = 0x010303,

        ///
        /// <summary>
        /// OPUS encoding format, 16000 Hz sampling rate, bass quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_OPUS_16000_LOW = 0x020101,

        ///
        /// <summary>
        /// OPUS encoding format, 16000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_OPUS_16000_MEDIUM = 0x020102,

        ///
        /// <summary>
        /// OPUS encoding format, 48000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_OPUS_48000_MEDIUM = 0x020302,

        ///
        /// <summary>
        /// OPUS encoding format, 48000 Hz sampling rate, high sound quality. A file with an audio duration of 10 minutes is approximately 3.5 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_OPUS_48000_HIGH = 0x020303,
    };

    ///
    /// <summary>
    /// The adaptation mode of the watermark.
    /// </summary>
    ///
    public enum WATERMARK_FIT_MODE
    {
        FIT_MODE_COVER_POSITION,
        FIT_MODE_USE_IMAGE_RATIO
    };

    public class EncodedAudioFrameAdvancedSettings
    {
        public EncodedAudioFrameAdvancedSettings()
        {
            speech = true;
            sendEvenIfEmpty = true;
        }

        public bool speech { set; get; }

        public bool sendEvenIfEmpty { set; get; }
    };

    ///
    /// <summary>
    /// Audio information after encoding.
    /// </summary>
    ///
    public class EncodedAudioFrameInfo
    {
        public EncodedAudioFrameInfo()
        {
            codec = AUDIO_CODEC_TYPE.AUDIO_CODEC_AACLC;
            sampleRateHz = 0;
            samplesPerChannel = 0;
            numberOfChannels = 0;
        }

        public EncodedAudioFrameInfo(ref EncodedAudioFrameInfo rhs)
        {
            codec = rhs.codec;
            sampleRateHz = rhs.sampleRateHz;
            samplesPerChannel = rhs.samplesPerChannel;
            numberOfChannels = rhs.numberOfChannels;
            advancedSettings = rhs.advancedSettings;
        }

        ///
        /// <summary>
        /// Audio Codec type: AUDIO_CODEC_TYPE .
        /// </summary>
        ///
        public AUDIO_CODEC_TYPE codec { set; get; }

        ///
        /// <summary>
        /// Audio sample rate (Hz).
        /// </summary>
        ///
        public int sampleRateHz { set; get; }

        ///
        /// <summary>
        /// The number of audio samples per channel.
        /// </summary>
        ///
        public int samplesPerChannel { set; get; }

        ///
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        ///
        public int numberOfChannels { set; get; }

        ///
        /// <summary>
        /// This function is not currently supported.
        /// </summary>
        ///
        public EncodedAudioFrameAdvancedSettings advancedSettings { set; get; }
    };

    public class AudioPcmDataInfo
    {
        public AudioPcmDataInfo()
        {
            samplesPerChannel = 0;
            channelNum = 0;
            samplesOut = 0;
            elapsedTimeMs = 0;
            ntpTimeMs = 0;
        }

        public AudioPcmDataInfo(ref AudioPcmDataInfo rhs)
        {
            samplesPerChannel = rhs.samplesPerChannel;
            channelNum = rhs.channelNum;
            samplesOut = rhs.samplesOut;
            elapsedTimeMs = rhs.elapsedTimeMs;
            ntpTimeMs = rhs.ntpTimeMs;
        }

        public uint samplesPerChannel { set; get; }

        public short channelNum { set; get; }

        public uint samplesOut { set; get; }

        public int64_t elapsedTimeMs { set; get; }

        public int64_t ntpTimeMs { set; get; }
    };

    public enum H264PacketizeMode
    {
        NonInterleaved = 0,

        SingleNalUnit = 1,
    };

    ///
    /// <summary>
    /// The type of video streams.
    /// </summary>
    ///
    public enum VIDEO_STREAM_TYPE
    {
        ///
        /// <summary>
        /// 0: High-quality video stream.
        /// </summary>
        ///
        VIDEO_STREAM_HIGH = 0,

        ///
        /// <summary>
        /// 1: Low-quality video stream.
        /// </summary>
        ///
        VIDEO_STREAM_LOW = 1,
    };

    ///
    /// <summary>
    /// The information about the external encoded video frame.
    /// </summary>
    ///
    public class EncodedVideoFrameInfo
    {
        public EncodedVideoFrameInfo()
        {
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            width = 0;
            height = 0;
            framesPerSecond = 0;
            frameType = VIDEO_FRAME_TYPE_NATIVE.VIDEO_FRAME_TYPE_BLANK_FRAME;
            rotation = VIDEO_ORIENTATION.VIDEO_ORIENTATION_0;
            trackId = 0;
            renderTimeMs = 0;
            internalSendTs = 0;
            uid = 0;
            streamType = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;

        }

        public EncodedVideoFrameInfo(ref EncodedVideoFrameInfo rhs)
        {
            codecType = rhs.codecType;
            width = rhs.width;
            height = rhs.width;
            framesPerSecond = rhs.framesPerSecond;
            frameType = rhs.frameType;
            rotation = rhs.rotation;
            trackId = rhs.trackId; ;
            renderTimeMs = rhs.renderTimeMs;
            internalSendTs = rhs.internalSendTs;
            uid = rhs.uid;
            streamType = rhs.streamType;
        }

        ///
        /// <summary>
        /// The codec type of the local video stream. See VIDEO_CODEC_TYPE . The default value is VIDEO_CODEC_H264(2).
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType { set; get; }

        ///
        /// <summary>
        /// The width (pixel) of the video frame.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// The height (pixel) of the video frame.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// The number of video frames per second.
        /// When this parameter is not 0, you can use it to calculate the Unix timestamp of the external encoded video frames.
        /// </summary>
        ///
        public int framesPerSecond { set; get; }

        ///
        /// <summary>
        /// The video frame type, see VIDEO_FRAME_TYPE .
        /// </summary>
        ///
        public VIDEO_FRAME_TYPE_NATIVE frameType { set; get; }

        ///
        /// <summary>
        /// The rotation information of the video frame, see VIDEO_ORIENTATION .
        /// </summary>
        ///
        public VIDEO_ORIENTATION rotation { set; get; }

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public int trackId { set; get; }

        ///
        /// <summary>
        /// The Unix timestamp (ms) when the video frame is rendered. This timestamp can be used to guide the rendering of the video frame. It is required.
        /// </summary>
        ///
        public int64_t renderTimeMs { set; get; }

        public uint64_t internalSendTs { set; get; }

        ///
        /// <summary>
        /// The user ID to push the the external encoded video frame.
        /// </summary>
        ///
        public uint uid { set; get; }

        ///
        /// <summary>
        /// The type of video streams.
        /// </summary>
        ///
        public VIDEO_STREAM_TYPE streamType { set; get; }
    };
    
    ///
    /// <summary>
    /// Video mirror mode.
    /// </summary>
    ///
    public enum VIDEO_MIRROR_MODE_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) The SDK determines the mirror mode.
        /// </summary>
        ///
        VIDEO_MIRROR_MODE_AUTO = 0,

        ///
        /// <summary>
        /// 1: Enable mirror mode.
        /// </summary>
        ///
        VIDEO_MIRROR_MODE_ENABLED = 1,

        ///
        /// <summary>
        /// 2: Disable mirror mode.
        /// </summary>
        ///
        VIDEO_MIRROR_MODE_DISABLED = 2,
    };

    ///
    /// <summary>
    /// Video encoder configurations.
    /// </summary>
    ///
    public class VideoEncoderConfiguration
    {
        public VideoEncoderConfiguration(ref VideoDimensions d, int f, int b, ORIENTATION_MODE m, VIDEO_MIRROR_MODE_TYPE mirror = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED)
        {
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            dimensions = d;
            frameRate = f;
            bitrate = b;
            minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = m;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = mirror;
        }

        public VideoEncoderConfiguration(int width, int height, int f, int b, ORIENTATION_MODE m, VIDEO_MIRROR_MODE_TYPE mirror = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED)
        {
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = m;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = mirror;
        }

        public VideoEncoderConfiguration(ref VideoEncoderConfiguration config)
        {
            codecType = config.codecType;
            dimensions = config.dimensions;
            frameRate = config.frameRate;
            bitrate = config.bitrate;
            minBitrate = config.minBitrate;
            orientationMode = config.orientationMode;
            degradationPreference = config.degradationPreference;
            mirrorMode = config.mirrorMode;
        }

        public VideoEncoderConfiguration()
        {
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            dimensions = new VideoDimensions((int)FRAME_WIDTH.FRAME_WIDTH_640, (int)FRAME_HEIGHT.FRAME_HEIGHT_360);
            frameRate = (int)FRAME_RATE.FRAME_RATE_FPS_15;
            bitrate = (int)BITRATE.STANDARD_BITRATE;
            minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED;
        }

        ///
        /// <summary>
        /// The codec type of the local video stream. See VIDEO_CODEC_TYPE .
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType { set; get; }

        ///
        /// <summary>
        /// The dimensions of the encoded video (px). See VideoDimensions . This parameter measures the video encoding quality in the format of length × width. The default value is 640 × 360. You can set a custom value.
        /// </summary>
        ///
        public VideoDimensions dimensions { set; get; }

        ///
        /// <summary>
        /// The frame rate (fps) of the encoding video frame. The default value is 15. See FRAME_RATE .
        /// </summary>
        ///
        public int frameRate { set; get; }

        ///
        /// <summary>
        /// The encoding bitrate (Kbps) of the video.  BITRATE 
        /// </summary>
        ///
        public int bitrate { set; get; }

        ///
        /// <summary>
        /// The minimum encoding bitrate (Kbps) of the video.
        /// The SDK automatically adjusts the encoding bitrate to adapt to the network conditions. Using a value greater than the default value forces the video encoder to output high-quality images but may cause more packet loss and sacrifice the smoothness of the video transmission. Unless you have special requirements for image quality, Agora does not recommend changing this value.
        /// This parameter only applies to the interactive streaming profile. 
        /// </summary>
        ///
        public int minBitrate { set; get; }

        ///
        /// <summary>
        /// The orientation mode of the encoded video. See ORIENTATION_MODE .
        /// </summary>
        ///
        public ORIENTATION_MODE orientationMode { set; get; }

        ///
        /// <summary>
        /// Video degradation preference under limited bandwidth. For more details, see DEGRADATION_PREFERENCE .
        /// </summary>
        ///
        public DEGRADATION_PREFERENCE degradationPreference { set; get; }

        ///
        /// <summary>
        /// Whether to enable mirroring mode when sending encoded video, only affects the video images seen by remote users. See VIDEO_MIRROR_MODE_TYPE .
        /// By default, the video is not mirrored. 
        /// </summary>
        ///
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }
    };

    ///
    /// <summary>
    /// The configurations for the data stream.
    /// The following table shows the SDK behaviors under different parameter settings:
    /// </summary>
    ///
    public class DataStreamConfig
    {
        ///
        /// <summary>
        /// Whether to synchronize the data packet with the published audio packet.
        /// true: Synchronize the data packet with the audio packet.
        /// false: Do not synchronize the data packet with the audio packet.
        /// When you set the data packet to synchronize with the audio, then if the data packet delay is within the audio delay, the SDK triggers the OnStreamMessage callback when the synchronized audio packet is played out. Do not set this parameter as true if you need the receiver to receive the data packet immediately. Agora recommends that you set this parameter to `true` only when you need to implement specific functions, for example, lyric synchronization.
        /// </summary>
        ///
        public bool syncWithAudio { set; get; }

        ///
        /// <summary>
        /// Whether the SDK guarantees that the receiver receives the data in the sent order.
        /// true: Guarantee that the receiver receives the data in the sent order.
        /// false: Do not guarantee that the receiver receives the data in the sent order.
        /// Do not set this parameter as true if you need the receiver to receive the data packet immediately.
        /// </summary>
        ///
        public bool ordered { set; get; }
    };

    ///
    /// <summary>
    /// The configuration of the low-quality video stream.
    /// </summary>
    ///
    public class SimulcastStreamConfig
    {
        public SimulcastStreamConfig()
        {
            dimensions = new VideoDimensions(160, 120);
            bitrate = 65;
            framerate = 5;
        }

        public SimulcastStreamConfig(VideoDimensions dimensions, int bitrate, int framerate)
        {
            this.dimensions = dimensions;
            this.bitrate = bitrate;
            this.framerate = framerate;
        }

        ///
        /// <summary>
        /// The video dimension.  The default value is 160 × 120. VideoDimensions 
        /// </summary>
        ///
        public VideoDimensions dimensions { set; get; }

        ///
        /// <summary>
        /// Video receive bitrate (Kbps). The default value is 65.
        /// </summary>
        ///
        public int bitrate { set; get; }

        ///
        /// <summary>
        /// The capture frame rate (fps) of the local video. The default value is 5.
        /// </summary>
        ///
        public int framerate { set; get; }
    };

    ///
    /// <summary>
    /// The location of the target area relative to the screen or window. If you do not set this parameter, the SDK selects the whole screen or window.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// x: The horizontal offset from the top-left corner.
        /// </summary>
        ///
        public int x { set; get; }

        ///
        /// <summary>
        /// y: The vertical offset from the top-left corner.
        /// </summary>
        ///
        public int y { set; get; }

        ///
        /// <summary>
        /// The width of the target area.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// The height of the target area.
        /// </summary>
        ///
        public int height { set; get; }
    };

    ///
    /// <summary>
    /// The position and size of the watermark on the screen.
    /// The position and size of the watermark on the screen are determined by xRatio, yRatio, and widthRatio:
    /// (xRatio, yRatio) refers to the coordinates of the upper left corner of the watermark, which determines the distance from the upper left corner of the watermark to the upper left corner of the screen.
    /// The widthRatio determines the width of the watermark.
    /// </summary>
    ///
    public class WatermarkRatio
    {
        public WatermarkRatio()
        {
            xRatio = 0.0f;
            yRatio = 0.0f;
            widthRatio = 0.0f;
        }

        public WatermarkRatio(float x, float y, float width)
        {
            xRatio = x;
            yRatio = y;
            widthRatio = width;
        }

        ///
        /// <summary>
        /// The x-coordinate of the upper left corner of the watermark. The x-coordinate of the upper left corner of the watermark. The horizontal position relative to the origin, where the upper left corner of the screen is the origin, and the x-coordinate is the upper left corner of the watermark. The value range is [0.0,1.0], and the default value is 0.
        /// </summary>
        ///
        public float xRatio { set; get; }

        ///
        /// <summary>
        /// The y-coordinate of the upper left corner of the watermark. The vertical position relative to the origin, where the upper left corner of the screen is the origin, and the y-coordinate is the upper left corner of the screen. The value range is [0.0,1.0], and the default value is 0.
        /// </summary>
        ///
        public float yRatio { set; get; }

        ///
        /// <summary>
        /// The width of the watermark. The SDK calculates the height of the watermark proportionally according to this parameter value to ensure that the enlarged or reduced watermark image is not distorted. The value range is [0,1], and the default value is 0, which means no watermark is displayed.
        /// </summary>
        ///
        public float widthRatio { set; get; }
    };

    ///
    /// <summary>
    /// Configurations of the watermark image.
    /// </summary>
    ///
    public class WatermarkOptions
    {
        public WatermarkOptions()
        {
            visibleInPreview = false;
            positionInLandscapeMode = new Rectangle(0, 0, 0, 0);
            positionInPortraitMode = new Rectangle(0, 0, 0, 0);
            watermarkRatio = new WatermarkRatio();
            mode = WATERMARK_FIT_MODE.FIT_MODE_COVER_POSITION;
        }

        public WatermarkOptions(bool visibleInPreview, Rectangle positionInLandscapeMode,
            Rectangle positionInPortraitMode, WatermarkRatio ratio, WATERMARK_FIT_MODE mode)
        {
            this.visibleInPreview = visibleInPreview;
            this.positionInLandscapeMode = positionInLandscapeMode ?? new Rectangle();
            this.positionInPortraitMode = positionInPortraitMode ?? new Rectangle();
            this.watermarkRatio = ratio ?? new WatermarkRatio();
            this.mode = mode;
        }

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public bool visibleInPreview { set; get; }

        ///
        /// <summary>
        /// When the adaptation mode of the watermark isFIT_MODE_COVER_POSITION, it is used to set the area of the watermark image in landscape mode. See Rectangle .
        /// </summary>
        ///
        public Rectangle positionInLandscapeMode { set; get; }

        ///
        /// <summary>
        /// When the adaptation mode of the watermark isFIT_MODE_COVER_POSITION , it is used to set the area of the watermark image in portrait mode. See Rectangle .
        /// </summary>
        ///
        public Rectangle positionInPortraitMode { set; get; }

        ///
        /// <summary>
        /// When the watermark adaptation mode is FIT_MODE_USE_IMAGE_RATIO, this parameter is used to set the watermark coordinates. See WatermarkRatio .
        /// </summary>
        ///
        public WatermarkRatio watermarkRatio { set; get; }

        ///
        /// <summary>
        /// The adaptation mode of the watermark. See WATERMARK_FIT_MODE .
        /// </summary>
        ///
        public WATERMARK_FIT_MODE mode { set; get; }
    };

    ///
    /// <summary>
    /// Statistics of the channel.
    /// </summary>
    ///
    public class RtcStats
    {
        public RtcStats()
        {
        }

        public RtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes, uint txVideoBytes,
            uint rxAudioBytes, uint rxVideoBytes, UInt16 txKBitRate, UInt16 rxKBitRate, UInt16 rxAudioKBitRate,
            UInt16 txAudioKBitRate, UInt16 rxVideoKBitRate, UInt16 txVideoKBitRate, UInt16 lastmileDelay,
            uint userCount, double cpuAppUsage, double cpuTotalUsage, int gatewayRtt,
            double memoryAppUsageRatio, double memoryTotalUsageRatio, int memoryAppUsageInKbytes, int connectTimeMs,
            int firstAudioPacketDuration, int firstVideoPacketDuration, int firstVideoKeyFramePacketDuration,
            int packetsBeforeFirstKeyFramePacket, int firstAudioPacketDurationAfterUnmute, int firstVideoPacketDurationAfterUnmute,
            int firstVideoKeyFramePacketDurationAfterUnmute, int firstVideoKeyFrameDecodedDurationAfterUnmute,
            int firstVideoKeyFrameRenderedDurationAfterUnmute, int txPacketLossRate, int rxPacketLossRate)
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
            this.userCount = userCount;
            this.cpuAppUsage = cpuAppUsage;
            this.cpuTotalUsage = cpuTotalUsage;
            this.gatewayRtt = gatewayRtt;
            this.memoryAppUsageRatio = memoryAppUsageRatio;
            this.memoryTotalUsageRatio = memoryTotalUsageRatio;
            this.memoryAppUsageInKbytes = memoryAppUsageInKbytes;
            this.connectTimeMs = connectTimeMs;
            this.firstAudioPacketDuration = firstAudioPacketDuration;
            this.firstVideoPacketDuration = firstVideoPacketDuration;
            this.firstVideoKeyFramePacketDuration = firstVideoKeyFramePacketDuration;
            this.packetsBeforeFirstKeyFramePacket = packetsBeforeFirstKeyFramePacket;
            this.firstAudioPacketDurationAfterUnmute = firstAudioPacketDurationAfterUnmute;
            this.firstVideoPacketDurationAfterUnmute = firstVideoPacketDurationAfterUnmute;
            this.firstVideoKeyFramePacketDurationAfterUnmute = firstVideoKeyFramePacketDurationAfterUnmute;
            this.firstVideoKeyFrameDecodedDurationAfterUnmute = firstVideoKeyFrameDecodedDurationAfterUnmute;
            this.firstVideoKeyFrameRenderedDurationAfterUnmute = firstVideoKeyFrameRenderedDurationAfterUnmute;
            this.txPacketLossRate = txPacketLossRate;
            this.rxPacketLossRate = rxPacketLossRate;
        }

        ///
        /// <summary>
        /// Call duration of the local user in seconds, represented by an aggregate value.
        /// </summary>
        ///
        public uint duration { set; get; }

        ///
        /// <summary>
        /// Total number of bytes transmitted, represented by an aggregate value.
        /// </summary>
        ///
        public uint txBytes { set; get; }

        ///
        /// <summary>
        /// Total number of bytes received, represented by an aggregate value.
        /// </summary>
        ///
        public uint rxBytes { set; get; }

        ///
        /// <summary>
        /// Total number of audio bytes sent, represented by an aggregate value.
        /// </summary>
        ///
        public uint txAudioBytes { set; get; }

        ///
        /// <summary>
        /// The total number of video bytes sent, represented by an aggregate value.
        /// </summary>
        ///
        public uint txVideoBytes { set; get; }

        ///
        /// <summary>
        /// The total number of audio bytes received, represented by an aggregate value.
        /// </summary>
        ///
        public uint rxAudioBytes { set; get; }

        ///
        /// <summary>
        /// The total number of video bytes received, represented by an aggregate value.
        /// </summary>
        ///
        public uint rxVideoBytes { set; get; }

        ///
        /// <summary>
        /// Video transmission bitrate (Kbps), represented by an instantaneous value.
        /// </summary>
        ///
        public ushort txKBitRate { set; get; }

        ///
        /// <summary>
        /// The receiving bitrate (Kbps), represented by an instantaneous value.
        /// </summary>
        ///
        public ushort rxKBitRate { set; get; }

        ///
        /// <summary>
        /// Audio receive bitrate (Kbps), represented by an instantaneous value.
        /// </summary>
        ///
        public ushort rxAudioKBitRate { set; get; }

        ///
        /// <summary>
        /// The bitrate (Kbps) of sending the audio packet.
        /// </summary>
        ///
        public ushort txAudioKBitRate { set; get; }

        ///
        /// <summary>
        /// Video receive bitrate (Kbps), represented by an instantaneous value.
        /// </summary>
        ///
        public ushort rxVideoKBitRate { set; get; }

        ///
        /// <summary>
        /// The bitrate (Kbps) of sending the video.
        /// </summary>
        ///
        public ushort txVideoKBitRate { set; get; }

        ///
        /// <summary>
        /// The client-to-server delay (ms).
        /// </summary>
        ///
        public ushort lastmileDelay { set; get; }

        ///
        /// <summary>
        /// The number of users in the channel.
        /// </summary>
        ///
        public uint userCount { set; get; }

        ///
        /// <summary>
        /// Application CPU usage (%). The value of cpuTotalUsage is always reported as 0 in the OnLeaveChannel callback.
        /// As of Android 8.1, you cannot get the CPU usage from this attribute due to system limitations.
        /// </summary>
        ///
        public double cpuAppUsage { set; get; }

        ///
        /// <summary>
        /// The system CPU usage (%).
        /// For Windows, in the multi-kernel environment, this member represents the average CPU usage. The value = (100 - System Idle Progress in Task Manager)/100. The value of cpuTotalUsage is always reported as 0 in the OnLeaveChannel callback.
        /// As of Android 8.1, you cannot get the CPU usage from this attribute due to system limitations.
        /// </summary>
        ///
        public double cpuTotalUsage { set; get; }

        ///
        /// <summary>
        /// The round-trip time delay (ms) from the client to the local router.On Android, to get gatewayRtt, ensure that you add the android.permission.ACCESS_WIFI_STATE permission after </application> in the AndroidManifest.xml file in your project.
        /// </summary>
        ///
        public int gatewayRtt { set; get; }

        ///
        /// <summary>
        /// The memory ratio occupied by the app (%).
        /// This value is for reference only. Due to system limitations, you may not get this value. 
        /// </summary>
        ///
        public double memoryAppUsageRatio { set; get; }

        ///
        /// <summary>
        /// The memory occupied by the system (%).
        /// This value is for reference only. Due to system limitations, you may not get this value. 
        /// </summary>
        ///
        public double memoryTotalUsageRatio { set; get; }

        ///
        /// <summary>
        /// The memory size occupied by the app (KB).
        /// This value is for reference only. Due to system limitations, you may not get this value. 
        /// </summary>
        ///
        public int memoryAppUsageInKbytes { set; get; }

        ///
        /// <summary>
        /// The duration (ms) between the SDK starts connecting and the connection is established. If the value reported is 0, it means invalid.
        /// </summary>
        ///
        public int connectTimeMs { set; get; }

        public int firstAudioPacketDuration { set; get; }

        public int firstVideoPacketDuration { set; get; }

        public int firstVideoKeyFramePacketDuration { set; get; }

        public int packetsBeforeFirstKeyFramePacket { set; get; }

        public int firstAudioPacketDurationAfterUnmute { set; get; }

        public int firstVideoPacketDurationAfterUnmute { set; get; }

        public int firstVideoKeyFramePacketDurationAfterUnmute { set; get; }

        public int firstVideoKeyFrameDecodedDurationAfterUnmute { set; get; }

        public int firstVideoKeyFrameRenderedDurationAfterUnmute { set; get; }

        ///
        /// <summary>
        /// The packet loss rate (%) from the client to the Agora server before applying the anti-packet-loss algorithm.
        /// </summary>
        ///
        public int txPacketLossRate { set; get; }

        ///
        /// <summary>
        /// The packet loss rate (%) from the Agora server to the client before using the anti-packet-loss method.
        /// </summary>
        ///
        public int rxPacketLossRate { set; get; }
    };

    ///
    /// <summary>
    /// The capture type of the custom video source.
    /// </summary>
    ///
    public enum VIDEO_SOURCE_TYPE
    {
        ///
        /// @ignore
        ///
        VIDEO_SOURCE_CAMERA_PRIMARY,
        ///
        /// <summary>
        /// The camera.
        /// </summary>
        ///
        VIDEO_SOURCE_CAMERA = VIDEO_SOURCE_CAMERA_PRIMARY,
        ///
        /// <summary>
        /// The secondary camera.
        /// </summary>
        ///
        VIDEO_SOURCE_CAMERA_SECONDARY,
        ///
        /// <summary>
        /// The primary screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN_PRIMARY,
        ///
        /// <summary>
        /// The screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN = VIDEO_SOURCE_SCREEN_PRIMARY,
        ///
        /// <summary>
        /// The secondary screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN_SECONDARY,
        ///
        /// <summary>
        /// The custom video source.
        /// </summary>
        ///
        VIDEO_SOURCE_CUSTOM,
        ///
        /// <summary>
        /// The video source from the media player.
        /// </summary>
        ///
        VIDEO_SOURCE_MEDIA_PLAYER,
        ///
        /// <summary>
        /// The video source is a PNG image.
        /// </summary>
        ///
        VIDEO_SOURCE_RTC_IMAGE_PNG,
        ///
        /// <summary>
        /// The video source is a JPEG image.
        /// </summary>
        ///
        VIDEO_SOURCE_RTC_IMAGE_JPEG,
        ///
        /// <summary>
        /// The video source is a GIF image.
        /// </summary>
        ///
        VIDEO_SOURCE_RTC_IMAGE_GIF,
        ///
        /// <summary>
        /// The video source is remote video acquired by the network.
        /// </summary>
        ///
        VIDEO_SOURCE_REMOTE,
        ///
        /// <summary>
        /// A transcoded video source.
        /// </summary>
        ///
        VIDEO_SOURCE_TRANSCODED,
        ///
        /// <summary>
        /// An unknown video source.
        /// </summary>
        ///
        VIDEO_SOURCE_UNKNOWN = 100
    };

    ///
    /// <summary>
    /// The user role in the interactive live streaming.
    /// </summary>
    ///
    public enum CLIENT_ROLE_TYPE
    {
        ///
        /// <summary>
        /// 1: Host. A host can both send and receive streams.
        /// </summary>
        ///
        CLIENT_ROLE_BROADCASTER = 1,

        ///
        /// <summary>
        /// 2: (Default) Audience. An audience member can only receive streams.
        /// </summary>
        ///
        CLIENT_ROLE_AUDIENCE = 2,
    };

    ///
    /// <summary>
    /// Quality change of the local video in terms of target frame rate and target bit rate since last count.
    /// </summary>
    ///
    public enum QUALITY_ADAPT_INDICATION
    {
        ///
        /// <summary>
        /// 0: The local video quality stays the same.
        /// </summary>
        ///
        ADAPT_NONE = 0,

        ///
        /// <summary>
        /// 1: The local video quality improves because the network bandwidth increases.
        /// </summary>
        ///
        ADAPT_UP_BANDWIDTH = 1,

        ///
        /// <summary>
        /// 2: The local video quality deteriorates because the network bandwidth decreases.
        /// </summary>
        ///
        ADAPT_DOWN_BANDWIDTH = 2,
    };

    ///
    /// <summary>
    /// The latency level of an audience member in interactive live streaming. This enum takes effect only when the user role is set to CLIENT_ROLE_AUDIENCE .
    /// </summary>
    ///
    public enum AUDIENCE_LATENCY_LEVEL_TYPE
    {
        ///
        /// <summary>
        /// 1: Low latency.
        /// </summary>
        ///
        AUDIENCE_LATENCY_LEVEL_LOW_LATENCY = 1,

        ///
        /// <summary>
        /// 2: (Default) Ultra low latency.
        /// </summary>
        ///
        AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY = 2,

        AUDIENCE_LATENCY_LEVEL_HIGH_LATENCY = 3,
    };

    ///
    /// <summary>
    /// The detailed options of a user.
    /// </summary>
    ///
    public class ClientRoleOptions
    {
        public ClientRoleOptions()
        {
            audienceLatencyLevel = AUDIENCE_LATENCY_LEVEL_TYPE.AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY;
        }

        public ClientRoleOptions(AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel)
        {
            this.audienceLatencyLevel = audienceLatencyLevel;
        }

        ///
        /// <summary>
        /// The latency level of an audience member in interactive live streaming. See AUDIENCE_LATENCY_LEVEL_TYPE .
        /// </summary>
        ///
        public AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel { set; get; }
    };

    ///
    /// <summary>
    /// The Quality of Experience (QoE) of the local user when receiving a remote audio stream.
    /// </summary>
    ///
    public enum EXPERIENCE_QUALITY_TYPE
    {
        ///
        /// <summary>
        /// 0: The QoE of the local user is good.
        /// </summary>
        ///
        EXPERIENCE_QUALITY_GOOD = 0,

        ///
        /// <summary>
        /// 1: The QoE of the local user is poor
        /// </summary>
        ///
        EXPERIENCE_QUALITY_BAD = 1,
    };

    ///
    /// <summary>
    /// Audio statistics of the remote user.
    /// </summary>
    ///
    public class RemoteAudioStats
    {
        public RemoteAudioStats()
        {
        }

        public RemoteAudioStats(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay,
            int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime,
            int frozenRate, int mosValue, int totalActiveTime, int publishDuration, int qoeQuality)
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
            this.mosValue = mosValue;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
            this.qoeQuality = qoeQuality;
        }

        ///
        /// <summary>
        /// The user ID of the remote user.
        /// </summary>
        ///
        public uint uid { set; get; }

        ///
        /// <summary>
        /// The quality of the audio stream sent by the user.  QUALITY_TYPE 
        /// </summary>
        ///
        public int quality { set; get; }

        ///
        /// <summary>
        /// The network delay (ms) from the sender to the receiver.
        /// </summary>
        ///
        public int networkTransportDelay { set; get; }

        ///
        /// <summary>
        /// The network delay (ms) from the audio receiver to the jitter buffer. When the receiving end is an audience member andaudienceLatencyLevel of ClientRoleOptions is 1, this parameter does not take effect.
        /// </summary>
        ///
        public int jitterBufferDelay { set; get; }

        ///
        /// <summary>
        /// The frame loss rate (%) of the remote audio stream in the reported interval.
        /// </summary>
        ///
        public int audioLossRate { set; get; }

        ///
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        ///
        public int numChannels { set; get; }

        ///
        /// <summary>
        /// The sampling rate of the received audio stream in the reported interval.
        /// </summary>
        ///
        public int receivedSampleRate { set; get; }

        ///
        /// <summary>
        /// The average bitrate (Kbps) of the received audio stream in the reported interval.
        /// </summary>
        ///
        public int receivedBitrate { set; get; }

        ///
        /// <summary>
        /// The total freeze time (ms) of the remote audio stream after the remote user joins the channel. In a session, audio freeze occurs when the audio frame loss rate reaches 4%.
        /// </summary>
        ///
        public int totalFrozenTime { set; get; }

        ///
        /// <summary>
        /// The total audio freeze time as a percentage (%) of the total time when the audio is available. The audio is considered available when the remote user neither stops sending the audio stream nor disables the audio module after joining the channel.
        /// </summary>
        ///
        public int frozenRate { set; get; }

        ///
        /// <summary>
        /// The quality of the remote audio stream in the reported interval. The quality is determined by the Agora real-time audio MOS (Mean Opinion Score) measurement method. The return value range is [0, 500]. Dividing the return value by 100 gets the MOS score, which ranges from 0 to 5. The higher the score, the better the audio quality.
        /// The subjective perception of audio quality corresponding to the Agora real-time audio MOS scores is as follows: MOS score
        /// Perception of audio quality Greater than 4
        /// Excellent. The audio sounds clear and smooth. From 3.5 to 4
        /// Good. The audio has some perceptible impairment but still sounds clear. From 3 to 3.5
        /// Fair. The audio freezes occasionally and requires attentive listening. From 2.5 to 3
        /// Poor. The audio sounds choppy and requires considerable effort to understand. From 2 to 2.5
        /// Bad. The audio has occasional noise. Consecutive audio dropouts occur, resulting in some information loss. The users can communicate only with difficulty. Less than 2
        /// Very bad. The audio has persistent noise. Consecutive audio dropouts are frequent, resulting in severe information loss. Communication is nearly impossible. 
        /// </summary>
        ///
        public int mosValue { set; get; }

        ///
        /// <summary>
        /// The total active time (ms) between the start of the audio call and the callback of the remote user.
        /// The active time refers to the total duration of the remote user without the mute state.
        /// </summary>
        ///
        public int totalActiveTime { set; get; }

        ///
        /// <summary>
        /// The total duration (ms) of the remote audio stream.
        /// </summary>
        ///
        public int publishDuration { set; get; }

        ///
        /// <summary>
        /// The Quality of Experience (QoE) of the local user when receiving a remote audio stream. 
        /// </summary>
        ///
        public int qoeQuality { set; get; }
    };

    ///
    /// <summary>
    /// The audio profile.
    /// </summary>
    ///
    public enum AUDIO_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 0: The default audio profile.
        /// For the interactive streaming profile: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 64 Kbps.
        /// For the communication profile: 
        /// Windows: A sample rate of 16 kHz, audio encoding, mono, and a bitrate of up to 16 Kbps.
        /// Android/macOS/iOS: 
        /// </summary>
        ///
        AUDIO_PROFILE_DEFAULT = 0,

        ///
        /// <summary>
        /// 1: A sample rate of 32 kHz, audio encoding, mono, and a bitrate of up to 18 Kbps.
        /// </summary>
        ///
        AUDIO_PROFILE_SPEECH_STANDARD = 1,

        ///
        /// <summary>
        /// 2: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 64 Kbps.
        /// </summary>
        ///
        AUDIO_PROFILE_MUSIC_STANDARD = 2,

        ///
        /// <summary>
        /// 3: A sample rate of 48 kHz, music encoding, stereo, and a bitrate of up to 80 Kbps.To implement stereo audio, you also need to call SetAdvancedAudioOptions and set audioProcessingChannels to AdvancedAudioOptions in AUDIO_PROCESSING_STEREO.
        /// </summary>
        ///
        AUDIO_PROFILE_MUSIC_STANDARD_STEREO = 3,

        ///
        /// <summary>
        /// 4: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 96 Kbps.
        /// </summary>
        ///
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY = 4,

        ///
        /// <summary>
        /// 5: A sample rate of 48 kHz, music encoding, stereo, and a bitrate of up to 128 Kbps.To implement stereo audio, you also need to call SetAdvancedAudioOptions and set audioProcessingChannels to AdvancedAudioOptions in AUDIO_PROCESSING_STEREO.
        /// </summary>
        ///
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO = 5,

        ///
        /// <summary>
        /// 6: A sample rate of 16 kHz, audio encoding, mono, and Acoustic Echo Cancellation (AES) enabled.
        /// </summary>
        ///
        AUDIO_PROFILE_IOT = 6,

        ///
        /// <summary>
        /// Enumeration boundary.
        /// </summary>
        ///
        AUDIO_PROFILE_NUM = 7
    };

    ///
    /// <summary>
    /// The audio scenario.
    /// </summary>
    ///
    public enum AUDIO_SCENARIO_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) Automatic scenario, where the SDK chooses the appropriate audio quality according to the user role and audio route.
        /// </summary>
        ///
        AUDIO_SCENARIO_DEFAULT = 0,

        ///
        /// <summary>
        /// 3: High-quality audio scenario, where users mainly play music.
        /// </summary>
        ///
        AUDIO_SCENARIO_GAME_STREAMING = 3,

        ///
        /// <summary>
        /// 5: Chatroom scenario, where users need to frequently switch the user role or mute and unmute the microphone. In this scenario, audience members receive a pop-up window to request permission of using microphones.
        /// </summary>
        ///
        AUDIO_SCENARIO_CHATROOM = 5,

        ///
        /// <summary>
        /// 6: High-quality audio scenario, where users mainly play music.
        /// </summary>
        ///
        AUDIO_SCENARIO_HIGH_DEFINITION = 6,

        ///
        /// <summary>
        /// 7: Real-time chorus scenario, where users have good network conditions and require ultra-low latency.
        /// </summary>
        ///
        AUDIO_SCENARIO_CHORUS = 7,

        ///
        /// <summary>
        /// The number of enumerations.
        /// </summary>
        ///
        AUDIO_SCENARIO_NUM = 8,
    };

    ///
    /// <summary>
    /// The format of the video frame.
    /// </summary>
    ///
    public class VideoFormat
    {
        public enum OPTIONAL_ENUM_SIZE_T
        {
            kMaxWidthInPixels = 3840,
            kMaxHeightInPixels = 2160,
            kMaxFps = 60,
        }

        public VideoFormat()
        {
            width = (int)FRAME_WIDTH.FRAME_WIDTH_640;
            height = (int)FRAME_HEIGHT.FRAME_HEIGHT_360;
            fps = (int)FRAME_RATE.FRAME_RATE_FPS_15;
        }

        public VideoFormat(int w, int h, int f)
        {
            this.width = w;
            this.height = h;
            this.fps = f;
        }

        ///
        /// <summary>
        /// The width (px) of the video frame.
        /// </summary>
        ///
        public int width { set; get; }   // Number of pixels.

        ///
        /// <summary>
        /// The height (px) of the video frame.
        /// </summary>
        ///
        public int height { set; get; } // Number of pixels.

        ///
        /// <summary>
        /// The video frame rate (fps).
        /// </summary>
        ///
        public int fps { set; get; }
    };

    ///
    /// <summary>
    /// The content hint for screen sharing.
    /// </summary>
    ///
    public enum VIDEO_CONTENT_HINT
    {
        ///
        /// <summary>
        /// (Default) No content hint.
        /// </summary>
        ///
        CONTENT_HINT_NONE = 0,

        ///
        /// <summary>
        /// Motion-intensive content. Choose this option if you prefer smoothness or when you are sharing a video clip, movie, or video game.
        /// </summary>
        ///
        CONTENT_HINT_MOTION = 1,

        ///
        /// <summary>
        /// Motionless content. Choose this option if you prefer sharpness or when you are sharing a picture, PowerPoint slides, or texts.
        /// </summary>
        ///
        CONTENT_HINT_DETAILS = 2
    };

    ///
    /// <summary>
    /// The state of the local audio.
    /// </summary>
    ///
    public enum LOCAL_AUDIO_STREAM_STATE
    {
        ///
        /// <summary>
        /// 0: The local audo is in the initial state.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The local audo capturing device starts successfully.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_RECORDING = 1,

        ///
        /// <summary>
        /// 2: The first audo frame encodes successfully.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_ENCODING = 2,

        ///
        /// <summary>
        /// 3: The local audio fails to start.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_FAILED = 3
    };

    ///
    /// <summary>
    /// Local audio state error codes.
    /// </summary>
    ///
    public enum LOCAL_AUDIO_STREAM_ERROR
    {
        LOCAL_AUDIO_STREAM_ERROR_OK = 0,

        LOCAL_AUDIO_STREAM_ERROR_FAILURE = 1,

        LOCAL_AUDIO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        LOCAL_AUDIO_STREAM_ERROR_DEVICE_BUSY = 3,

        LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE = 4,

        LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE = 5
    };

    ///
    /// <summary>
    /// Local video state types.
    /// </summary>
    ///
    public enum LOCAL_VIDEO_STREAM_STATE
    {
        ///
        /// <summary>
        /// 0: The local video is in the initial state.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The local video capturing device starts successfully. The SDK also reports this state when you call StartScreenCaptureByWindowId to share a maximized window.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_STATE_CAPTURING = 1,

        ///
        /// <summary>
        /// 2: The first video frame is successfully encoded.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_STATE_ENCODING = 2,

        ///
        /// <summary>
        /// 3: Fails to start the local video.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_STATE_FAILED = 3
    };

    ///
    /// <summary>
    /// Local video state error code.
    /// </summary>
    ///
    public enum LOCAL_VIDEO_STREAM_ERROR
    {
        ///
        /// <summary>
        /// 0: The local video is normal.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_OK = 0,

        ///
        /// <summary>
        /// 1: No specified reason for the local video failure.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_FAILURE = 1,

        ///
        /// <summary>
        /// 2: No permission to use the local video capturing device.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        ///
        /// <summary>
        /// 3: The local video capturing device is in use.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY = 3,

        ///
        /// <summary>
        /// 4: The local video capture fails. Check whether the capturing device is working properly.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE = 4,

        ///
        /// <summary>
        /// 5: The local video encoding fails.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_ENCODE_FAILURE = 5,

        ///
        /// <summary>
        /// 6: The local video capturing device not available due to app did enter background.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_INBACKGROUND = 6,

        ///
        /// <summary>
        /// 7: The local video capturing device not available because the app is running in a multi-app layout (generally on the pad).
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_MULTIPLE_FOREGROUND_APPS = 7,

        ///
        /// <summary>
        /// 8: Fails to find a local video capture device.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NOT_FOUND = 8,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_DISCONNECTED = 9,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_INVALID_ID = 10,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_SYSTEM_PRESSURE = 101,

        ///
        /// <summary>
        /// 11: When calling StartScreenCaptureByWindowId to share the window, the shared window is in a minimized state.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED = 11,

        ///
        /// <summary>
        /// 12: The error code indicates that a window shared by the window ID has been closed, or a full-screen window shared by the window ID has exited full-screen mode. After exiting full-screen mode, remote users cannot see the shared window. To prevent remote users from seeing a black screen, Agora recommends that you immediately stop screen sharing.
        /// Common scenarios for reporting this error code:
        /// When the local user closes the shared window, the SDK reports this error code.
        /// The local user shows some slides in full-screen mode first, and then shares the windows of the slides. After the user exits full-screen mode, the SDK reports this error code.
        /// The local user watches a web video or reads a web document in full-screen mode first, and then shares the window of the web video or document. After the user exits full-screen mode, the SDK reports this error code. 
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_CLOSED = 12,

        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_OCCLUDED = 13,

        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_NOT_SUPPORTED = 20,
    };

    ///
    /// <summary>
    /// Remote audio states.
    /// </summary>
    ///
    public enum REMOTE_AUDIO_STATE
    {
        ///
        /// <summary>
        /// 0: The remote audo is in the initial state. The SDK reports this state in the case of REMOTE_AUDIO_STATE_REASON_LOCAL_MUTED, REMOTE_AUDIO_STATE_REASON_REMOTE_MUTED, or REMOTE_AUDIO_STATE_REASON_REMOTE_OFFLINE.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_STOPPED = 0,  // Default state, audio is started or remote user disabled/muted audio stream

        ///
        /// <summary>
        /// 1: The first remote audio packet is received.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_STARTING = 1,  // The first audio frame packet has been received

        ///
        /// <summary>
        /// 2: The remote audio stream is decoded and plays normally. The SDK reports this state in the case of REMOTE_AUDIO_STATE_REASON_NETWORK_RECOVERY, REMOTE_AUDIO_STATE_REASON_LOCAL_UNMUTED, or REMOTE_AUDIO_STATE_REASON_REMOTE_UNMUTED.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_DECODING = 2,  // The first remote audio frame has been decoded or fronzen state ends

        ///
        /// <summary>
        /// 3: The remote audio is frozen. The SDK reports this state in the case of REMOTE_AUDIO_STATE_REASON_NETWORK_CONGESTION.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_FROZEN = 3,    // Remote audio is frozen, probably due to network issue

        ///
        /// <summary>
        /// 4: The remote audio fails to start. The SDK reports this state in the case of REMOTE_AUDIO_STATE_REASON_INTERNAL.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_FAILED = 4,    // Remote audio play failed
    };

    ///
    /// <summary>
    /// The reason for the remote audio state change.
    /// </summary>
    ///
    public enum REMOTE_AUDIO_STATE_REASON
    {
        ///
        /// <summary>
        /// 0: The SDK reports this reason when the audio state changes.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_INTERNAL = 0,

        ///
        /// <summary>
        /// 1: Network congestion.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_NETWORK_CONGESTION = 1,

        ///
        /// <summary>
        /// 2: Network recovery.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_NETWORK_RECOVERY = 2,

        ///
        /// <summary>
        /// 3: The local user stops receiving the remote audio stream or disables the audio module.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_LOCAL_MUTED = 3,

        ///
        /// <summary>
        /// 4: The local user resumes receiving the remote audio stream or enables the audio module.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_LOCAL_UNMUTED = 4,

        ///
        /// <summary>
        /// 5: The remote user stops sending the audio stream or disables the audio module.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_REMOTE_MUTED = 5,

        ///
        /// <summary>
        /// 6: The remote user resumes sending the audio stream or enables the audio module.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_REMOTE_UNMUTED = 6,

        ///
        /// <summary>
        /// 7: The remote user leaves the channel.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_REMOTE_OFFLINE = 7,
    };

    ///
    /// <summary>
    /// The state of the remote video.
    /// </summary>
    ///
    public enum REMOTE_VIDEO_STATE
    {
        ///
        /// <summary>
        /// 0: The remote audo is in the initial state. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED, REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED, or REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The first remote audio packet is received.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_STARTING = 1,

        ///
        /// <summary>
        /// 2: The remote audio stream is decoded and plays normally. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY, ,REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED,REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED or REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_DECODING = 2,

        ///
        /// <summary>
        /// 3: The remote video is frozen. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION or REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_FROZEN = 3,

        ///
        /// <summary>
        /// 4: The remote video fails to start. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_INTERNAL.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_FAILED = 4,
    };

    ///
    /// <summary>
    /// The reason for the remote audio state change.
    /// </summary>
    ///
    public enum REMOTE_VIDEO_STATE_REASON
    {
        ///
        /// <summary>
        /// 0: The SDK reports this reason when the audio state changes.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_INTERNAL = 0,

        ///
        /// <summary>
        /// 1: Network congestion.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION = 1,

        ///
        /// <summary>
        /// 2: Network recovery.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY = 2,

        ///
        /// <summary>
        /// 3: The local user stops receiving the remote video stream or disables the video module.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED = 3,

        ///
        /// <summary>
        /// 4: The local user resumes receiving the remote video stream or enables the video module.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED = 4,

        ///
        /// <summary>
        /// 5: The remote user stops sending the video stream or disables the video module.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED = 5,

        ///
        /// <summary>
        /// 6: The remote user resumes sending the video stream or enables the video module.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED = 6,

        ///
        /// <summary>
        /// 7: The remote user leaves the channel.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE = 7,

        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK = 8,

        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY = 9,

        REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_LOW = 10,

        REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_HIGH = 11,
    };

    [Flags]
    public enum REMOTE_USER_STATE
    {
        USER_STATE_MUTE_AUDIO = (1 << 0),

        USER_STATE_MUTE_VIDEO = (1 << 1),

        USER_STATE_ENABLE_VIDEO = (1 << 4),

        USER_STATE_ENABLE_LOCAL_VIDEO = (1 << 8),
    };

    public class VideoTrackInfo
    {
        public VideoTrackInfo()
        {
            isLocal = false;
            ownerUid = 0;
            trackId = 0;
            channelId = null;
            streamType = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            encodedFrameOnly = false;
            sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            observationPosition = (uint)VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER;
        }

        public VideoTrackInfo(bool isLocal, uint ownerUid, uint trackId,
                              string channelId, VIDEO_STREAM_TYPE streamType,
                              VIDEO_CODEC_TYPE codecType, bool encodedFrameOnly,
                              VIDEO_SOURCE_TYPE sourceType, uint observationPosition)
        {
            this.isLocal = isLocal;
            this.ownerUid = ownerUid;
            this.trackId = trackId;
            this.channelId = channelId;
            this.streamType = streamType;
            this.codecType = codecType;
            this.encodedFrameOnly = encodedFrameOnly;
            this.sourceType = sourceType;
            this.observationPosition = observationPosition;
        }

        public bool isLocal { set; get; }

        public uint ownerUid { set; get; }

        public uint trackId { set; get; }

        public string channelId { set; get; }

        public VIDEO_STREAM_TYPE streamType { set; get; }

        public VIDEO_CODEC_TYPE codecType { set; get; }

        public bool encodedFrameOnly { set; get; }

        public VIDEO_SOURCE_TYPE sourceType { set; get; }

        public uint observationPosition { set; get; }
    };

    public enum REMOTE_VIDEO_DOWNSCALE_LEVEL
    {
        REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_1,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_2,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_3,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_4,
    };

    ///
    /// <summary>
    /// The volume information of users.
    /// </summary>
    ///
    public class AudioVolumeInfo
    {
        public AudioVolumeInfo()
        {
            uid = 0;
            volume = 0;
            vad = 0;
            voicePitch = 0.0;
        }

        public AudioVolumeInfo(uint uid, uint volume, uint vad, double voicePitch)
        {
            this.uid = uid;
            this.volume = volume;
            this.vad = vad;
            this.voicePitch = voicePitch;
        }

        ///
        /// <summary>
        /// The user ID. In the local user's callback, uid = 0.
        /// In the remote users' callback, uid is the user ID of a remote user whose instantaneous volume is one of the three highest. 
        /// </summary>
        ///
        public uint uid { set; get; }

        ///
        /// <summary>
        /// The volume of the user. The value ranges between 0 (the lowest volume) and 255 (the highest volume). 
        /// </summary>
        ///
        public uint volume { set; get; }

        ///
        /// <summary>
        /// Voice activity status of the local user. 0: The local user is not speaking.
        /// 1: The local user is speaking. 
        /// The vad parameter does not report the voice activity status of remote users. In a remote user's callback, the value of vad is always 1.
        /// To use this parameter, you must set reportVad to true when calling EnableAudioVolumeIndication .
        /// </summary>
        ///
        public uint vad { set; get; }

        ///
        /// <summary>
        /// The voice pitch (Hz) of the local user. The value ranges between 0.0 and 4000.0.
        /// The voicePitch parameter does not report the voice pitch of remote users. In the remote users' callback, the value of voicePitch is always 0.0.
        /// </summary>
        ///
        public double voicePitch { set; get; }
    };

    ///
    /// <summary>
    /// The audio device information.
    /// </summary>
    ///
    public class DeviceInfo
    {
        public string deviceName;

        public string deviceId;
    };

    ///
    /// <summary>
    /// The audio sampling rate of the stream to be pushed to the CDN.
    /// </summary>
    ///
    public enum AUDIO_SAMPLE_RATE_TYPE
    {
        ///
        /// <summary>
        /// 32000: 32 kHz
        /// </summary>
        ///
        AUDIO_SAMPLE_RATE_32000 = 32000,

        ///
        /// <summary>
        /// 44100: 44.1 kHz
        /// </summary>
        ///
        AUDIO_SAMPLE_RATE_44100 = 44100,

        ///
        /// <summary>
        /// 48000: (Default) 48 kHz
        /// </summary>
        ///
        AUDIO_SAMPLE_RATE_48000 = 48000,
    };
    ///
    /// <summary>
    /// The codec type of the output video.
    /// </summary>
    ///
    public enum VIDEO_CODEC_TYPE_FOR_STREAM
    {
        ///
        /// <summary>
        /// 1: (Default) H.264.
        /// </summary>
        ///
        VIDEO_CODEC_H264_FOR_STREAM = 1,

        ///
        /// <summary>
        /// 2: H.265.
        /// </summary>
        ///
        VIDEO_CODEC_H265_FOR_STREAM = 2,
    };

    ///
    /// <summary>
    /// Video codec profile types.
    /// </summary>
    ///
    public enum VIDEO_CODEC_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 66: Baseline video codec profile. Generally used for video calls on mobile phones.
        /// </summary>
        ///
        VIDEO_CODEC_PROFILE_BASELINE = 66,

        ///
        /// <summary>
        /// 77: Main video codec profile. Generally used in mainstream electronics such as MP4 players, portable video players, PSP, and iPads.
        /// </summary>
        ///
        VIDEO_CODEC_PROFILE_MAIN = 77,

        ///
        /// <summary>
        /// 100: (Default) High video codec profile. Generally used in high-resolution live streaming or television.
        /// </summary>
        ///
        VIDEO_CODEC_PROFILE_HIGH = 100,
    };

    ///
    /// <summary>
    /// Self-defined audio codec profile.
    /// </summary>
    ///
    public enum AUDIO_CODEC_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) LC-AAC.
        /// </summary>
        ///
        AUDIO_CODEC_PROFILE_LC_AAC = 0,

        ///
        /// <summary>
        /// 1: HE-AAC.
        /// </summary>
        ///
        AUDIO_CODEC_PROFILE_HE_AAC = 1,

        ///
        /// <summary>
        /// 2: HE-AAC v2.
        /// </summary>
        ///
        AUDIO_CODEC_PROFILE_HE_AAC_V2 = 2,
    };

    ///
    /// <summary>
    /// Local audio statistics.
    /// </summary>
    ///
    public class LocalAudioStats
    {
        public LocalAudioStats()
        {
        }

        public LocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate, int internalCodec, ushort txPacketLossRate)
        {
            this.numChannels = numChannels;
            this.sentSampleRate = sentSampleRate;
            this.sentBitrate = sentBitrate;
            this.internalCodec = internalCodec;
            this.txPacketLossRate = txPacketLossRate;
        }

        ///
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        ///
        public int numChannels { set; get; }

        ///
        /// <summary>
        /// The sampling rate (Hz) of sending the local user's audio stream.
        /// </summary>
        ///
        public int sentSampleRate { set; get; }

        ///
        /// <summary>
        /// The average bitrate (Kbps) of sending the local user's audio stream.
        /// </summary>
        ///
        public int sentBitrate { set; get; }

        ///
        /// <summary>
        /// The internal payload codec.
        /// </summary>
        ///
        public int internalCodec { set; get; }

        ///
        /// <summary>
        /// The packet loss rate (%) from the local client to the Agora server before applying the anti-packet loss strategies.
        /// </summary>
        ///
        public ushort txPacketLossRate { set; get; }
    };

    ///
    /// <summary>
    /// States of the Media Push.
    /// </summary>
    ///
    public enum RTMP_STREAM_PUBLISH_STATE
    {
        ///
        /// <summary>
        /// 0: The Media Push has not started or has ended.
        /// This state is also triggered after you remove a RTMP or RTMPS stream from the CDN by calling RemovePublishStreamUrl .
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: The SDK is connecting to Agora's streaming server and the CDN server.
        /// This state is triggered after you call the AddPublishStreamUrl method.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_CONNECTING = 1,

        ///
        /// <summary>
        /// 2: The RTMP or RTMPS streaming publishes. The SDK successfully publishes the RTMP or RTMPS streaming and returns this state.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_RUNNING = 2,

        ///
        /// <summary>
        /// 3: The RTMP or RTMPS streaming is recovering.
        /// When exceptions occur to the CDN, or the streaming is interrupted, the SDK tries to resume RTMP or RTMPS streaming and returns this state. If the SDK successfully resumes the streaming, RTMP_STREAM_PUBLISH_STATE_RUNNING(2) returns. If the streaming does not resume within 60 seconds or server errors occur, RTMP_STREAM_PUBLISH_STATE_FAILURE(4) returns.
        /// You can also reconnect to the server by calling the RemovePublishStreamUrl and AddPublishStreamUrl methods.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        ///
        /// <summary>
        /// 3: Fails to push streams to the CDN.
        /// See the errCode parameter for the detailed error information.You can also call the AddPublishStreamUrl method to publish the RTMP or RTMPS streaming again.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,

        ///
        /// <summary>
        /// 5: The SDK is disconnecting from the Agora streaming server and CDN. When you call RemovePublishStreamUrl or StopRtmpStream to stop the streaming normally, the SDK reports the streaming state as RTMP_STREAM_PUBLISH_STATE_DISCONNECTING and RTMP_STREAM_PUBLISH_STATE_IDLE in sequence.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_DISCONNECTING = 5,
    };

    ///
    /// <summary>
    /// Error codes of the RTMP or RTMPS streaming.
    /// </summary>
    ///
    public enum RTMP_STREAM_PUBLISH_ERROR_TYPE
    {
        ///
        /// <summary>
        /// 0: The RTMP or RTMPS streaming publishes successfully.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_OK = 0,

        ///
        /// <summary>
        /// 1: Invalid argument used. Check the parameter setting. For example, if you do not call SetLiveTranscoding to set the transcoding parameters before calling AddPublishStreamUrl , the SDK returns this error.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_INVALID_ARGUMENT = 1,

        ///
        /// <summary>
        /// 2: The RTMP or RTMPS streaming is encrypted and cannot be published.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_ENCRYPTED_STREAM_NOT_ALLOWED = 2,

        ///
        /// <summary>
        /// 3: Timeout for the RTMP or RTMPS streaming. Call the AddPublishStreamUrl method to publish the streaming again.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT = 3,

        ///
        /// <summary>
        /// 4: An error occurs in Agora's streaming server. Call the AddPublishStreamUrl method to publish the streaming again.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_INTERNAL_SERVER_ERROR = 4,

        ///
        /// <summary>
        /// 5: An error occurs in the CDN server.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_RTMP_SERVER_ERROR = 5,

        ///
        /// <summary>
        /// 6: Reserved parameter
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_TOO_OFTEN = 6,

        ///
        /// <summary>
        /// 7: The host publishes more than 10 URLs. Delete the unnecessary URLs before adding new ones.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_REACH_LIMIT = 7,

        ///
        /// <summary>
        /// 8: The host manipulates other hosts' URLs. For example, the host updates or stops other hosts' streams. Check your app logic.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_NOT_AUTHORIZED = 8,

        ///
        /// <summary>
        /// 9: Agora's server fails to find the RTMP or RTMPS streaming.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_STREAM_NOT_FOUND = 9,

        ///
        /// <summary>
        /// 10: The format of the RTMP or RTMPS streaming URL is not supported. Check whether the URL format is correct.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_FORMAT_NOT_SUPPORTED = 10,

        ///
        /// <summary>
        /// 11: The user role is not host, so the user cannot use the CDN live streaming function. Check your app code logic.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_NOT_BROADCASTER = 11,  // Note: match to ERR_PUBLISH_STREAM_NOT_BROADCASTER in AgoraBase.h

        ///
        /// <summary>
        /// 13: The UpdateRtmpTranscoding or SetLiveTranscoding method is called to update the transcoding configuration in a scenario where there is streaming without transcoding. Check your app code logic.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_TRANSCODING_NO_MIX_STREAM = 13,  // Note: match to ERR_PUBLISH_STREAM_TRANSCODING_NO_MIX_STREAM in AgoraBase.h

        ///
        /// <summary>
        /// 14: Errors occurred in the host's network.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_NET_DOWN = 14,  // Note: match to ERR_NET_DOWN in AgoraBase.h

        ///
        /// <summary>
        /// 15: Your App ID does not have permission to use the CDN live streaming function. 
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_INVALID_APPID = 15,  // Note: match to ERR_PUBLISH_STREAM_APPID_INVALID in AgoraBase.h

        ///
        /// <summary>
        /// 100: The streaming has been stopped normally. After you call RemovePublishStreamUrl to stop streaming, the SDK returns this value.
        /// </summary>
        ///
        RTMP_STREAM_UNPUBLISH_ERROR_OK = 100,
    };

    ///
    /// <summary>
    /// Events during the media push.
    /// </summary>
    ///
    public enum RTMP_STREAMING_EVENT
    {
        ///
        /// <summary>
        /// 1: An error occurs when you add a background image or a watermark image in the media push.
        /// </summary>
        ///
        RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE = 1,

        ///
        /// <summary>
        /// 2: The streaming URL is already being used for CDN live streaming.
        /// If you want to start new streaming, use a new streaming URL.
        /// </summary>
        ///
        RTMP_STREAMING_EVENT_URL_ALREADY_IN_USE = 2,

        ///
        /// <summary>
        /// 3: The feature is not supported.
        /// </summary>
        ///
        RTMP_STREAMING_EVENT_ADVANCED_FEATURE_NOT_SUPPORT = 3,

        ///
        /// <summary>
        /// 4: Reserved.
        /// </summary>
        ///
        RTMP_STREAMING_EVENT_REQUEST_TOO_OFTEN = 4,
    };

    ///
    /// <summary>
    /// Image properties.
    /// This class sets the properties of the watermark and background images in the live video.
    /// </summary>
    ///
    public class RtcImage
    {
        public RtcImage()
        {
            url = null;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            zOrder = 0;
            alpha = 1.0;
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

        ///
        /// <summary>
        /// The HTTP/HTTPS URL address of the image in the live video. The maximum length of this parameter is 1024 bytes.
        /// </summary>
        ///
        public string url { set; get; }

        ///
        /// <summary>
        /// The x coordinate (pixel) of the image on the video frame (taking the upper left corner of the video frame as the origin).
        /// </summary>
        ///
        public int x { set; get; }

        ///
        /// <summary>
        /// The y coordinate (pixel) of the image on the video frame (taking the upper left corner of the video frame as the origin).
        /// </summary>
        ///
        public int y { set; get; }

        ///
        /// <summary>
        /// The width (pixel) of the image on the video frame.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// The height (pixel) of the image on the video frame.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// The layer index of the watermark or background image. When you use the watermark array to add a watermark or multiple watermarks, you must pass a value to zOrder in the range [1,255]; otherwise, the SDK reports an error. In other cases, zOrder can optionally be passed in the range [0,255], with 0 being the default value. 0 means the bottom layer and 255 means the top layer.
        /// </summary>
        ///
        public int zOrder { set; get; }

        ///
        /// <summary>
        /// The transparency of the watermark or background image. The value ranges between 0.0 and 1.0:
        /// 0.0: Completely transparent.
        /// 1.0: (Default) Opaque.
        /// </summary>
        ///
        public double alpha { set; get; }
    };

    ///
    /// <summary>
    /// The configuration for advanced features of the RTMP or RTMPS streaming with transcoding.
    /// If you want to enable the advanced features of streaming with transcoding, contact .
    /// </summary>
    ///
    public class LiveStreamAdvancedFeature
    {
        public LiveStreamAdvancedFeature()
        {
            featureName = null;
            opened = false;
        }

        public LiveStreamAdvancedFeature(string feat_name, bool open)
        {
            featureName = feat_name;
            opened = open;
        }

        ///
        /// <summary>
        /// The feature names, including LBHQ (high-quality video with a lower bitrate) and VEO (optimized video encoder).
        /// </summary>
        ///
        public string featureName { set; get; }

        ///
        /// <summary>
        /// Whether to enable the advanced features of streaming with transcoding:
        /// true: Enable the advanced features.
        /// false: (Default) Do not enable the advanced features.
        /// </summary>
        ///
        public bool opened { set; get; }
    };

    ///
    /// <summary>
    /// Connection states.
    /// </summary>
    ///
    public enum CONNECTION_STATE_TYPE
    {
        ///
        /// <summary>
        /// 1: The SDK is disconnected from the Agora edge server. The state indicates the SDK is in one of the following phases:
        /// Theinitial state before calling the JoinChannel [2/2] method.
        /// The app calls the LeaveChannel [1/2] 
        /// </summary>
        ///
        CONNECTION_STATE_DISCONNECTED = 1,

        ///
        /// <summary>
        /// 2: The SDK is connecting to the Agora edge server. This state indicates that the SDK is establishing a connection with the specified channel after the app calls JoinChannel [2/2].
        /// If the SDK successfully joins the channel, it triggers the OnConnectionStateChanged callback and the connection state switches to CONNECTION_STATE_CONNECTED.
        /// After the connection is established, the SDK also initializes the media and triggers OnJoinChannelSuccess when everything is ready. 
        /// </summary>
        ///
        CONNECTION_STATE_CONNECTING = 2,

        ///
        /// <summary>
        /// 3: The SDK is connected to the Agora edge server. This state also indicates that the user has joined a channel and can now publish or subscribe to a media stream in the channel. If the connection to the channel is lost because, for example, if the network is down or switched, the SDK automatically tries to reconnect and triggers: 
        /// OnConnectionStateChanged callback, notifying that the current network state becomes CONNECTION_STATE_RECONNECTING.
        /// </summary>
        ///
        CONNECTION_STATE_CONNECTED = 3,

        ///
        /// <summary>
        /// 4: The SDK keeps reconnecting to the Agora edge server. The SDK keeps rejoining the channel after being disconnected from a joined channel because of network issues.
        /// If the SDK cannot rejoin the channel within 10 seconds, it triggers OnConnectionLost , stays in the CONNECTION_STATE_RECONNECTING state, and keeps rejoining the channel.
        /// If the SDK fails to rejoin the channel 20 minutes after being disconnected from the Agora edge server, the SDK triggers the OnConnectionStateChanged callback, switches to the CONNECTION_STATE_FAILED state, and stops rejoining the channel. 
        /// </summary>
        ///
        CONNECTION_STATE_RECONNECTING = 4,

        ///
        /// <summary>
        /// 5: The SDK fails to connect to the Agora edge server or join the channel. This state indicates that the SDK stops trying to rejoin the channel. You must call LeaveChannel [1/2] 
        /// You can call JoinChannel [2/2] to rejoin the channel.
        /// If the SDK is banned from joining the channel by the Agora edge server through the RESTful API, the SDK triggers the OnConnectionStateChanged callback. 
        /// </summary>
        ///
        CONNECTION_STATE_FAILED = 5,
    };

    ///
    /// <summary>
    /// Transcoding configurations of each host.
    /// </summary>
    ///
    public class TranscodingUser
    {
        public TranscodingUser()
        {
            uid = 0;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            zOrder = 0;
            alpha = 1.0;
            audioChannel = 0;
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

        ///
        /// <summary>
        /// The user ID of the host.
        /// </summary>
        ///
        public uint uid { set; get; }

        ///
        /// <summary>
        /// The x coordinate (pixel) of the host's video on the output video frame (taking the upper left corner of the video frame as the origin). The value range is [0, width], where width is thewidth set in LiveTranscoding .
        /// </summary>
        ///
        public int x { set; get; }

        ///
        /// <summary>
        /// The y coordinate (pixel) of the host's video on the output video frame (taking the upper left corner of the video frame as the origin). The value range is [0, height], where height is the height set in LiveTranscoding .
        /// </summary>
        ///
        public int y { set; get; }

        ///
        /// <summary>
        /// The width (pixel) of the host's video.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// The height (pixel) of the host's video.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// The number of the layer to which the video for the video mixing on the local client belongs. The value range is [0,100].
        /// 0: (Default) The layer is at the bottom.
        /// 100: The layer is at the top. 
        /// If the value is less than 0 or greater than 100, the error ERR_INVALID_ARGUMENT is returned.
        /// Starting from v2.3, setting zOrder to 0 is supported.
        /// </summary>
        ///
        public int zOrder { set; get; }

        ///
        /// <summary>
        /// The transparency of the video for the video mixing on the local client. The value range is [0.0,1.0].
        /// 0.0: Completely transparent.
        /// 1.0: (Default) Opaque. 
        /// </summary>
        ///
        public double alpha { set; get; }

        ///
        /// <summary>
        /// The audio channel used by the host's audio in the output audio. The default value is 0, and the value range is [0, 5].
        /// 0: (Recommended) The defaut setting, which supports dual channels at most and depends on the upstream of the host.
        /// 1: The host's audio uses the FL audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.
        /// 2: The host's audio uses the FC audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.
        /// 3: The host's audio uses the FR audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.
        /// 4: The host's audio uses the BL audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.
        /// 5: The host's audio uses the BR audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.
        /// 0xFF or a value greater than 5: The host's audio is muted, and the Agora server removes the host's audio. If the value is not 0, a special player is required.
        /// </summary>
        ///
        public int audioChannel { set; get; }
    };


    ///
    /// <summary>
    /// Transcoding configurations for Media Push.
    /// </summary>
    ///
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
            watermark = new RtcImage[0];
            watermarkCount = 0;
            backgroundImage = new RtcImage[0];
            backgroundImageCount = 0;
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
            string transcodingExtraInfo, string metadata, RtcImage[] watermark, uint watermarkCount,
            RtcImage[] backgroundImage, uint backgroundImageCount,
            AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels,
            AUDIO_CODEC_PROFILE_TYPE audioCodecProfile, LiveStreamAdvancedFeature[] advancedFeatures, uint advancedFeatureCount)
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

        ///
        /// <summary>
        /// The width of the video in pixels. The default value is 360. When pushing video streams to the CDN, the value range of width is [64,1920]. If the value is less than 64, Agora server automatically adjusts it to 64; if the value is greater than 1920, Agora server automatically adjusts it to 1920.
        /// When pushing audio streams to the CDN, set width and height as 0.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// The height of the video in pixels. The default value is 640. When pushing video streams to the CDN, the value range of height is [64,1080]. If the value is less than 64, Agora server automatically adjusts it to 64; if the value is greater than 1080, Agora server automatically adjusts it to 1080.
        /// When pushing audio streams to the CDN, set width and height as 0.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// Bitrate of the output video stream for Media Push in Kbps. The default value is 400 Kbps.
        /// </summary>
        ///
        public int videoBitrate { set; get; }

        public int videoFramerate { set; get; }

        ///
        /// <summary>
        ///  Deprecated
        /// This parameter is deprecated. Latency mode: true: Low latency with unassured quality.
        /// false: (Default) High latency with assured quality.
        /// </summary>
        ///
        public bool lowLatency { set; get; }

        ///
        /// <summary>
        /// GOP (Group of Pictures) in fps of the video frames for Media Push. The default value is 30.
        /// </summary>
        ///
        public int videoGop { set; get; }

        ///
        /// <summary>
        /// Video codec profile type for Media Push. Set it as 66, 77, or 100 (default). See VIDEO_CODEC_PROFILE_TYPE for details.
        /// If you set this parameter to any other value, Agora adjusts it to the default value.
        /// </summary>
        ///
        public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile { set; get; }

        ///
        /// <summary>
        /// The background color in RGB hex value. Value only. Do not include a preceeding #. For example, 0xFFB6C1 (light pink). The default value is 0x000000 (black).
        /// </summary>
        ///
        public uint backgroundColor { set; get; }

        ///
        /// <summary>
        /// Video codec profile types for Media Push. See VIDEO_CODEC_TYPE_FOR_STREAM .
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType { set; get; }

        ///
        /// <summary>
        /// The number of users in the video mixing. The value range is [0,17].
        /// </summary>
        ///
        public uint userCount { set; get; }

        ///
        /// <summary>
        /// Manages the user layout configuration in the Media Push. Agora supports a maximum of 17 transcoding users in a Media Push channel. See TranscodingUser .
        /// </summary>
        ///
        public TranscodingUser[] transcodingUsers { set; get; }

        ///
        /// <summary>
        /// Reserved property. Extra user-defined information to send SEI for the H.264/H.265 video stream to the CDN client. Maximum length: 4096 bytes. For more information on SEI, see SEI-related questions.
        /// </summary>
        ///
        public string transcodingExtraInfo { set; get; }

        ///
        /// <summary>
        ///  Deprecated
        /// This parameter is deprecated. The metadata sent to the CDN client.
        /// </summary>
        ///
        public string metadata { set; get; }

        ///
        /// <summary>
        /// The watermark on the live video. The image format needs to be PNG. See RtcImage .
        /// You can add one watermark, or add multiple watermarks using an array. This parameter is used with watermarkCount.
        /// </summary>
        ///
        public RtcImage[] watermark { set; get; }

        ///
        /// <summary>
        /// The number of watermarks on the live video. The total number of watermarks and background images can range from 0 to 10. This parameter is used with watermark.
        /// </summary>
        ///
        public uint watermarkCount { set; get; }

        ///
        /// <summary>
        /// The number of background images on the live video. The image format needs to be PNG. See RtcImage .
        /// You can add a background image or use an array to add multiple background images. This parameter is used with backgroundImageCount.
        /// </summary>
        ///
        public RtcImage[] backgroundImage { set; get; }

        ///
        /// <summary>
        /// The number of background images on the live video. The total number of watermarks and background images can range from 0 to 10. This parameter is used with backgroundImage.
        /// </summary>
        ///
        public uint backgroundImageCount { set; get; }

        ///
        /// <summary>
        /// The audio sampling rate (Hz) of the output media stream. See AUDIO_SAMPLE_RATE_TYPE .
        /// </summary>
        ///
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        ///
        /// <summary>
        /// Bitrate (Kbps) of the audio output stream for Media Push. The default value is 48, and the highest value is 128.
        /// </summary>
        ///
        public int audioBitrate { set; get; }

        ///
        /// <summary>
        /// The number of audio channels for Media Push. Agora recommends choosing 1 (mono), or 2 (stereo) audio channels. Special players are required if you choose 3, 4, or 5. 1: (Default) Mono.
        /// 2: Stereo.
        /// 3: Three audio channels.
        /// 4: Four audio channels.
        /// 5: Five audio channels.
        /// </summary>
        ///
        public int audioChannels { set; get; }

        ///
        /// <summary>
        /// Audio codec profile type for Media Push. See AUDIO_CODEC_PROFILE_TYPE .
        /// </summary>
        ///
        public AUDIO_CODEC_PROFILE_TYPE audioCodecProfile { set; get; }

        ///
        /// <summary>
        /// Advanced features of the Media Push with transcoding. See LiveStreamAdvancedFeature .
        /// </summary>
        ///
        public LiveStreamAdvancedFeature[] advancedFeatures { set; get; }

        ///
        /// <summary>
        /// The number of enabled advanced features. The default value is 0.
        /// </summary>
        ///
        public uint advancedFeatureCount { set; get; }
    };

    ///
    /// <summary>
    /// The video streams for the video mixing on the local client.
    /// </summary>
    ///
    public class TranscodingVideoStream
    {
        public TranscodingVideoStream()
        {
            this.sourceType = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE;
            remoteUserUid = 0;
            imageUrl = null;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            zOrder = 0;
            alpha = 1.0;
            mirror = false;
        }

        public TranscodingVideoStream(MEDIA_SOURCE_TYPE sourceType, uint remoteUserUid,
            string imageUrl, int x, int y, int width, int height, int zOrder, double alpha,
            bool mirror)
        {
            this.sourceType = sourceType;
            this.remoteUserUid = remoteUserUid;
            this.imageUrl = imageUrl;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
            this.mirror = mirror;
        }

        ///
        /// <summary>
        /// The source type of video for the video mixing on the local client. See VIDEO_SOURCE_TYPE .
        /// </summary>
        ///
        public MEDIA_SOURCE_TYPE sourceType { set; get; }

        ///
        /// <summary>
        /// The ID of the remote user.Use this parameter only when the source type of the video for the video mixingonthe local client is VIDEO_SOURCE_REMOTE.
        /// </summary>
        ///
        public uint remoteUserUid { set; get; }

        ///
        /// <summary>
        /// The URL of the image.Use this parameter only when the source type of the video for the video mixing on the local client is 
        /// </summary>
        ///
        public string imageUrl { set; get; }

        ///
        /// <summary>
        /// The horizontal displacement of the top-left corner of the video for the video mixing on the client relative to the top-left corner (origin) of the canvas for this video mixing.
        /// </summary>
        ///
        public int x { set; get; }

        ///
        /// <summary>
        /// The vertical displacement of the top-left corner of the video for the video mixing on the client relative to the top-left corner (origin) of the canvas for this video mixing.
        /// </summary>
        ///
        public int y { set; get; }

        ///
        /// <summary>
        /// The width (px) of the video for the video mixing on the local client.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// The height (px) of the video for the video mixing on the local client.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// The number of the layer to which the video for the video mixing on the local client belongs. The value range is [0,100].
        /// 0: (Default) The layer is at the bottom.
        /// 100: The layer is at the top.
        /// </summary>
        ///
        public int zOrder { set; get; }

        ///
        /// <summary>
        /// The transparency of the video for the video mixing on the local client. The value range is [0.0,1.0]. 0.0 means the transparency is completely transparent. 1.0 means the transparency is opaque.
        /// </summary>
        ///
        public double alpha { set; get; }

        ///
        /// <summary>
        /// Whether to mirror the video for the video mixing on the local client.
        /// true: Mirror the captured video.
        /// false: (Default) Do not mirror the captured video. The paramter only works for videos with the source type CAMERA
        /// </summary>
        ///
        public bool mirror { set; get; }
    };

    ///
    /// <summary>
    /// The configuration of the video mixing on the local client.
    /// </summary>
    ///
    public class LocalTranscoderConfiguration
    {
        public LocalTranscoderConfiguration()
        {
            streamCount = 0;
            VideoInputStreams = null;
            videoOutputConfiguration = new VideoEncoderConfiguration();
        }

        public LocalTranscoderConfiguration(uint streamCount, TranscodingVideoStream[] VideoInputStreams,
                                            VideoEncoderConfiguration videoOutputConfiguration)
        {
            this.streamCount = streamCount;
            this.VideoInputStreams = VideoInputStreams;
            this.videoOutputConfiguration = videoOutputConfiguration;
        }

        ///
        /// <summary>
        /// The number of the video streams for the video mixing on the local client.
        /// </summary>
        ///
        public uint streamCount { set; get; }

        ///
        /// <summary>
        /// The video streams for the video mixing on the local client. See TranscodingVideoStream .
        /// </summary>
        ///
        public TranscodingVideoStream[] VideoInputStreams { set; get; }

        ///
        /// <summary>
        /// The encoding configuration of the mixed video stream after the video mixing on the local client. See VideoEncoderConfiguration .
        /// </summary>
        ///
        public VideoEncoderConfiguration videoOutputConfiguration { set; get; }
    };

    ///
    /// <summary>
    /// Configurations of the last-mile network test.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// Sets whether to test the uplink network. Some users, for example, the audience members in a LIVE_BROADCASTING channel, do not need such a test.
        /// true: Test.
        /// false: Not test. 
        /// </summary>
        ///
        public bool probeUplink { set; get; }

        ///
        /// <summary>
        /// Sets whether to test the downlink network:
        /// true: Test.
        /// false: Not test. 
        /// </summary>
        ///
        public bool probeDownlink { set; get; }

        ///
        /// <summary>
        /// The expected maximum uplink bitrate (bps) of the local user. The value range is [100000, 5000000]. Agora recommends SetVideoEncoderConfiguration referring to to set the value.
        /// </summary>
        ///
        public uint expectedUplinkBitrate { set; get; }

        ///
        /// <summary>
        /// The expected maximum downlink bitrate (bps) of the local user. The value range is [100000,5000000].
        /// </summary>
        ///
        public uint expectedDownlinkBitrate { set; get; }
    };

    ///
    /// <summary>
    /// The status of the last-mile probe test.
    /// </summary>
    ///
    public enum LASTMILE_PROBE_RESULT_STATE
    {
        ///
        /// <summary>
        /// 1: The last-mile network probe test is complete.
        /// </summary>
        ///
        LASTMILE_PROBE_RESULT_COMPLETE = 1,

        ///
        /// <summary>
        /// 2: The last-mile network probe test is incomplete because the bandwidth estimation is not available due to limited test resources. One possible reason is that testing resources are temporarily limited.
        /// </summary>
        ///
        LASTMILE_PROBE_RESULT_INCOMPLETE_NO_BWE = 2,

        ///
        /// <summary>
        /// 3: The last-mile network probe test is not carried out. Probably due to poor network conditions.
        /// </summary>
        ///
        LASTMILE_PROBE_RESULT_UNAVAILABLE = 3
    };

    ///
    /// <summary>
    /// Results of the uplink or downlink last-mile network test.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// The packet loss rate (%).
        /// </summary>
        ///
        public uint packetLossRate { set; get; }

        ///
        /// <summary>
        /// The network jitter (ms).
        /// </summary>
        ///
        public uint jitter { set; get; }

        ///
        /// <summary>
        /// The estimated available bandwidth (bps).
        /// </summary>
        ///
        public uint availableBandwidth { set; get; }
    };

    ///
    /// <summary>
    /// Results of the uplink and downlink last-mile network tests.
    /// </summary>
    ///
    public class LastmileProbeResult
    {
        public LastmileProbeResult()
        {
            state = LASTMILE_PROBE_RESULT_STATE.LASTMILE_PROBE_RESULT_UNAVAILABLE;
            rtt = 0;
        }

        public LastmileProbeResult(LASTMILE_PROBE_RESULT_STATE state, LastmileProbeOneWayResult uplinkReport,
            LastmileProbeOneWayResult downlinkReport, uint rtt)
        {
            this.state = state;
            this.uplinkReport = uplinkReport;
            this.downlinkReport = downlinkReport;
            this.rtt = rtt;
        }

        ///
        /// <summary>
        /// The status of the last-mile probe test. See LASTMILE_PROBE_RESULT_STATE .
        /// </summary>
        ///
        public LASTMILE_PROBE_RESULT_STATE state { set; get; }

        ///
        /// <summary>
        /// Results of the uplink last-mile network test. See LastmileProbeOneWayResult .
        /// </summary>
        ///
        public LastmileProbeOneWayResult uplinkReport { set; get; }

        ///
        /// <summary>
        /// Results of the downlink last-mile network test. See LastmileProbeOneWayResult .
        /// </summary>
        ///
        public LastmileProbeOneWayResult downlinkReport { set; get; }

        ///
        /// <summary>
        /// The round-trip time (ms).
        /// </summary>
        ///
        public uint rtt { set; get; }
    };

    ///
    /// <summary>
    /// Reasons causing the change of the connection state.
    /// </summary>
    ///
    public enum CONNECTION_CHANGED_REASON_TYPE
    {
        ///
        /// <summary>
        /// 0: The SDK is connecting to the Agora edge server.
        /// </summary>
        ///
        CONNECTION_CHANGED_CONNECTING = 0,

        ///
        /// <summary>
        /// 1: The SDK has joined the channel successfully.
        /// </summary>
        ///
        CONNECTION_CHANGED_JOIN_SUCCESS = 1,

        ///
        /// <summary>
        /// 2: The connection between the SDK and the Agora edge server is interrupted.
        /// </summary>
        ///
        CONNECTION_CHANGED_INTERRUPTED = 2,

        ///
        /// <summary>
        /// 3: The connection between the SDK and the Agora edge server is banned by the Agora edge server. This error occurs when the user is kicked out of the channel by the server.
        /// </summary>
        ///
        CONNECTION_CHANGED_BANNED_BY_SERVER = 3,

        ///
        /// <summary>
        /// 4: The SDK fails to join the channel. When the SDK fails to join the channel for more than 20 minutes, this error occurs and the SDK stops reconnecting to the channel.
        /// </summary>
        ///
        CONNECTION_CHANGED_JOIN_FAILED = 4,

        ///
        /// <summary>
        /// 5: The SDK has left the channel.
        /// </summary>
        ///
        CONNECTION_CHANGED_LEAVE_CHANNEL = 5,

        ///
        /// <summary>
        /// 6: The connection failed because the App ID is not valid. Please rejoin the channel with a valid App ID.
        /// </summary>
        ///
        CONNECTION_CHANGED_INVALID_APP_ID = 6,

        ///
        /// <summary>
        /// 7: The connection failed since channel name is not valid. Please rejoin the channel with a valid channel name.
        /// </summary>
        ///
        CONNECTION_CHANGED_INVALID_CHANNEL_NAME = 7,

        ///
        /// <summary>
        /// 8: The connection failed because the token is not valid. Typical reasons include:
        /// The App Certificate for the project is enabled in Agora Console, but you do not use a token when joining the channel. If you enable the App Certificate, you must use a token to join the channel.
        /// Theuid specified when calling JoinChannel [2/2] to join the channel is inconsistent with the uid passed in when generating the token. 
        /// </summary>
        ///
        CONNECTION_CHANGED_INVALID_TOKEN = 8,

        ///
        /// <summary>
        /// 9: The connection failed since token is expired.
        /// </summary>
        ///
        CONNECTION_CHANGED_TOKEN_EXPIRED = 9,

        ///
        /// <summary>
        /// 10: The connection is rejected by server. Typical reasons include:
        /// The user is already in the channel and still calls a method, for example,JoinChannel [2/2], to join the channel. Stop calling this method to clear this error.
        /// The user tries to join the channel when calling for a call test. The user needs to call the channel after the call test ends. 
        /// </summary>
        ///
        CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,

        ///
        /// <summary>
        /// 11: The connection state changed to reconnecting because the SDK has set a proxy server.
        /// </summary>
        ///
        CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,

        ///
        /// <summary>
        /// 12: The connection state changed because the token is renewed.
        /// </summary>
        ///
        CONNECTION_CHANGED_RENEW_TOKEN = 12,

        ///
        /// <summary>
        /// 13: The IP address of the client has changed, possibly because the network type, IP address, or port has been changed.
        /// </summary>
        ///
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,

        ///
        /// <summary>
        /// 14: Timeout for the keep-alive of the connection between the SDK and the Agora edge server. The connection state changes to .
        /// </summary>
        ///
        CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,

        ///
        /// <summary>
        /// 14: Timeout for the keep-alive of the connection between the SDK and the Agora edge server. The connection state changes to .
        /// </summary>
        ///
        CONNECTION_CHANGED_REJOIN_SUCCESS = 15,

        ///
        /// <summary>
        /// 14: Timeout for the keep-alive of the connection between the SDK and the Agora edge server. The connection state changes to .
        /// </summary>
        ///
        CONNECTION_CHANGED_LOST = 16,

        ///
        /// <summary>
        /// (15): The SDK has rejoined the channel successfully.
        /// </summary>
        ///
        CONNECTION_CHANGED_ECHO_TEST = 17,

        ///
        /// <summary>
        /// (16): The connection between the SDK and the server is lost.
        /// </summary>
        ///
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,

        ///
        /// <summary>
        /// (17): The connection state changes due to the echo test.
        /// </summary>
        ///
        CONNECTION_CHANGED_SAME_UID_LOGIN = 19,

        CONNECTION_CHANGED_TOO_MANY_BROADCASTERS = 20,
    };

    public enum CLIENT_ROLE_CHANGE_FAILED_REASON
    {
        CLIENT_ROLE_CHANGE_FAILED_TOO_MANY_BROADCASTERS = 1,

        CLIENT_ROLE_CHANGE_FAILED_NOT_AUTHORIZED = 2,

        CLIENT_ROLE_CHANGE_FAILED_REQUEST_TIME_OUT = 3,

        CLIENT_ROLE_CHANGE_FAILED_CONNECTION_FAILED = 4,
    };

    ///
    /// <summary>
    /// Network types.
    /// </summary>
    ///
    public enum NETWORK_TYPE
    {
        ///
        /// <summary>
        /// -1: The network type is unknown.</pd>
        /// </summary>
        ///
        NETWORK_TYPE_UNKNOWN = -1,

        ///
        /// <summary>
        /// 0: The SDK disconnects from the network.
        /// </summary>
        ///
        NETWORK_TYPE_DISCONNECTED = 0,

        ///
        /// <summary>
        /// 1: The network type is LAN.
        /// </summary>
        ///
        NETWORK_TYPE_LAN = 1,

        ///
        /// <summary>
        /// 2: The network type is Wi-Fi (including hotspots).
        /// </summary>
        ///
        NETWORK_TYPE_WIFI = 2,

        ///
        /// <summary>
        /// 3: The network type is mobile 2G.
        /// </summary>
        ///
        NETWORK_TYPE_MOBILE_2G = 3,

        ///
        /// <summary>
        /// 4: The network type is mobile 3G.
        /// </summary>
        ///
        NETWORK_TYPE_MOBILE_3G = 4,

        ///
        /// <summary>
        /// 5: The network type is mobile 4G.
        /// </summary>
        ///
        NETWORK_TYPE_MOBILE_4G = 5,
    };

    public enum VIDEO_VIEW_SETUP_MODE
    {
        VIDEO_VIEW_SETUP_REPLACE = 0,

        VIDEO_VIEW_SETUP_ADD = 1,

        VIDEO_VIEW_SETUP_REMOVE = 2,
    };

    ///
    /// <summary>
    /// Attributes of video canvas object.
    /// </summary>
    ///
    public class VideoCanvas
    {
        public VideoCanvas()
        {
            view = 0;
            renderMode = RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
            uid = 0;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
            isScreenView = false;
            priv = null;
            priv_size = 0;
            sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            cropArea = new Rectangle();
            setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt, uint u)
        {
            this.view = v;
            this.renderMode = m;
            this.mirrorMode = mt;
            this.uid = u;
            this.isScreenView = false;
            this.priv = null;
            this.priv_size = 0; ;
            this.sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            cropArea = new Rectangle();
            this.setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt, string u)
        {
            this.view = v;
            this.renderMode = m;
            this.mirrorMode = mt;
            this.uid = 0;
            this.isScreenView = false;
            this.priv = null;
            this.priv_size = 0; ;
            this.sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            cropArea = new Rectangle();
            this.setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
        }

        ///
        /// <summary>
        /// Video display window.
        /// </summary>
        ///
        public view_t view { set; get; }

        ///
        /// <summary>
        /// The rendering mode of the video. See RENDER_MODE_TYPE .
        /// </summary>
        ///
        public RENDER_MODE_TYPE renderMode { set; get; }

        ///
        /// <summary>
        /// The mirror mode of the view. See VIDEO_MIRROR_MODE_TYPE . For the mirror mode of the local video view: If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.
        /// For the remote user: The mirror mode is disabled by default.
        /// </summary>
        ///
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }

        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint uid { set; get; }

        public bool isScreenView { set; get; }

        public byte[] priv { set; get; }

        public uint priv_size { set; get; }

        ///
        /// <summary>
        /// The type of the video source, see VIDEO_SOURCE_TYPE .
        /// </summary>
        ///
        public VIDEO_SOURCE_TYPE sourceType { set; get; }

        public Rectangle cropArea { set; get; }

        public VIDEO_VIEW_SETUP_MODE setupMode { set; get; }

    };

    ///
    /// <summary>
    /// The contrast level.
    /// </summary>
    ///
    public enum LIGHTENING_CONTRAST_LEVEL
    {
        ///
        /// <summary>
        /// Low contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_LOW = 0,
        ///
        /// <summary>
        /// Normal contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_NORMAL,
        ///
        /// <summary>
        /// High contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_HIGH
    };

    ///
    /// <summary>
    /// Image enhancement options.
    /// </summary>
    ///
    public class BeautyOptions
    {
        public BeautyOptions()
        {
            lighteningContrastLevel = LIGHTENING_CONTRAST_LEVEL.LIGHTENING_CONTRAST_NORMAL;
            this.lighteningLevel = 0;
            this.smoothnessLevel = 0;
            this.rednessLevel = 0;
            this.sharpnessLevel = 0;
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

        ///
        /// <summary>
        /// The contrast level, used with the lighteningLevel parameter. The larger the value, the greater the contrast between light and dark. See LIGHTENING_CONTRAST_LEVEL .
        /// </summary>
        ///
        public LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel { set; get; }

        ///
        /// <summary>
        /// The brightness level. The value ranges from 0.0 (original) to 1.0. The default value is 0.0. The greater the value, the greater the degree of whitening.
        /// </summary>
        ///
        public float lighteningLevel { set; get; }

        ///
        /// <summary>
        /// The value ranges from 0.0 (original) to 1.0. The default value is 0.0. The greater the value, the greater the degree of skin grinding.
        /// </summary>
        ///
        public float smoothnessLevel { set; get; }

        ///
        /// <summary>
        /// The redness level. The value ranges from 0.0 (original) to 1.0. The default value is 0.0. The larger the value, the greater the rosy degree.
        /// </summary>
        ///
        public float rednessLevel { set; get; }

        ///
        /// <summary>
        /// The sharpness level. The value ranges from 0.0 (original) to 1.0. The default value is 0.0. The larger the value, the greater the sharpening degree.
        /// </summary>
        ///
        public float sharpnessLevel { set; get; }
    };

    ///
    /// <summary>
    /// The type of the custom background image.
    /// </summary>
    ///
    public enum BACKGROUND_SOURCE_TYPE
    {
        ///
        /// <summary>
        /// 1: (Default) The background image is a solid color.
        /// </summary>
        ///
        BACKGROUND_COLOR = 1,

        ///
        /// <summary>
        /// The background image is a file in PNG or JPG format.
        /// </summary>
        ///
        BACKGROUND_IMG = 2,

        ///
        /// <summary>
        /// The background image is the blurred background.
        /// </summary>
        ///
        BACKGROUND_BLUR = 3,
    };

    ///
    /// <summary>
    /// The degree of blurring applied to the custom background image.
    /// </summary>
    ///
    public enum BACKGROUND_BLUR_DEGREE
    {
        ///
        /// <summary>
        /// 1: The degree of blurring applied to the custom background image is low. The user can almost see the background clearly.
        /// </summary>
        ///
        BLUR_DEGREE_LOW = 1,

        ///
        /// <summary>
        /// The degree of blurring applied to the custom background image is medium. It is difficult for the user to recognize details in the background.
        /// </summary>
        ///
        BLUR_DEGREE_MEDIUM = 2,

        ///
        /// <summary>
        /// (Default) The degree of blurring applied to the custom background image is high. The user can barely see any distinguishing features in the background.
        /// </summary>
        ///
        BLUR_DEGREE_HIGH = 3,
    };

    ///
    /// <summary>
    /// The custom background image.
    /// </summary>
    ///
    public class VirtualBackgroundSource
    {
        public VirtualBackgroundSource()
        {
            background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_COLOR;
            color = 0xffffff;
            source = "";
            blur_degree = BACKGROUND_BLUR_DEGREE.BLUR_DEGREE_HIGH;
        }

        ///
        /// <summary>
        /// The type of the custom background image. See BACKGROUND_SOURCE_TYPE .
        /// </summary>
        ///
        public BACKGROUND_SOURCE_TYPE background_source_type { set; get; }

        ///
        /// <summary>
        /// The color of the custom background image. The format is a hexadecimal integer defined by RGB, without the # sign, such as 0xFFB6C1 for light pink. The default value is 0xFFFFFF, which signifies white. The value range is [0x000000, 0xffffff]. If the value is invalid, the SDK replaces the original background image with a white background image.This parameter takes effect only when the type of the custom background image is BACKGROUND_COLOR.
        /// </summary>
        ///
        public uint color { set; get; }

        ///
        /// <summary>
        /// The local absolute path of the custom background image. PNG and JPG formats are supported. If the path is invalid, the SDK replaces the original background image with a white background image.This parameter takes effect only when the type of the custom background image is BACKGROUND_IMG.
        /// </summary>
        ///
        public string source { set; get; }

        ///
        /// <summary>
        /// The degree of blurring applied to the custom background image. See BACKGROUND_BLUR_DEGREE .This parameter takes effect only when the type of the custom background image is BACKGROUND_BLUR.
        /// </summary>
        ///
        public BACKGROUND_BLUR_DEGREE blur_degree { set; get; }
    };

    public class FishCorrectionParams
    {
        public FishCorrectionParams()
        {
            _x_center = 0.49f;
            _y_center = 0.48f;
            _scale_factor = 4.5f;
            _focal_length = 31;
            _pol_focal_length = 31;
            _split_height = 1.0f;

            _ss[0] = 0.9375f;
            _ss[1] = 0.0f;
            _ss[2] = -2.9440f;
            _ss[3] = 5.7344f;
            _ss[4] = -4.4564f;
        }

        public FishCorrectionParams(float x_center, float y_center, float scale_factor, float focal_length, float pol_focal_length, float split_height, float[] ss)
        {
            this._x_center = x_center;
            this._y_center = y_center;
            this._scale_factor = scale_factor;
            this._focal_length = focal_length;
            this._pol_focal_length = pol_focal_length;
            this._split_height = split_height;
            for (int i = 0; i < ss.Length; i++)
            {
                this._ss[i] = ss[i];
            }
        }

        public float _x_center { set; get; }

        public float _y_center { set; get; }

        public float _scale_factor { set; get; }

        public float _focal_length { set; get; }

        public float _pol_focal_length { set; get; }

        public float _split_height { set; get; }

        public float[] _ss = new float[5];
    };

    ///
    /// <summary>
    /// The options for SDK preset voice beautifier effects.
    /// </summary>
    ///
    [Flags]
    public enum VOICE_BEAUTIFIER_PRESET
    {
        ///
        /// <summary>
        /// Turn off voice beautifier effects and use the original voice.
        /// </summary>
        ///
        VOICE_BEAUTIFIER_OFF = 0x00000000,

        ///
        /// <summary>
        /// A more magnetic voice.
        /// Agora recommends using this enumerator to process a male-sounding voice; otherwise, you may experience vocal distortion.
        /// </summary>
        ///
        CHAT_BEAUTIFIER_MAGNETIC = 0x01010100,

        ///
        /// <summary>
        /// A fresher voice.
        /// Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion. 
        /// </summary>
        ///
        CHAT_BEAUTIFIER_FRESH = 0x01010200,

        ///
        /// <summary>
        /// A more vital voice.
        /// Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion. 
        /// </summary>
        ///
        CHAT_BEAUTIFIER_VITALITY = 0x01010300,

        ///
        /// <summary>
        /// Singing beautifier effect. If you call SetVoiceBeautifierPreset (SINGING_BEAUTIFIER), you can beautify a male-sounding voice and add a reverberation effect that sounds like singing in a small room. Agora recommends using this enumerator to process a male-sounding voice; otherwise, you might experience vocal distortion.
        /// If you call SetVoiceBeautifierParameters (SINGING_BEAUTIFIER, param1, param2), you can beautify a male- or female-sounding voice and add a reverberation effect.
        /// </summary>
        ///
        SINGING_BEAUTIFIER = 0x01020100,

        ///
        /// <summary>
        /// A more vigorous voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_VIGOROUS = 0x01030100,

        ///
        /// <summary>
        /// A deep voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_DEEP = 0x01030200,

        ///
        /// <summary>
        /// A mellower voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_MELLOW = 0x01030300,

        ///
        /// <summary>
        /// Falsetto.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_FALSETTO = 0x01030400,

        ///
        /// <summary>
        /// A fuller voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_FULL = 0x01030500,

        ///
        /// <summary>
        /// A clearer voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_CLEAR = 0x01030600,

        ///
        /// <summary>
        /// A more resounding voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_RESOUNDING = 0x01030700,

        ///
        /// <summary>
        /// A more ringing voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_RINGING = 0x01030800,

        ULTRA_HIGH_QUALITY_VOICE = 0x01040100
    };

    ///
    /// <summary>
    /// Preset voice effects.
    /// For better voice effects, Agora recommends settingthe profile parameter of SetAudioProfile [1/2] to AUDIO_PROFILE_MUSIC_HIGH_QUALITY or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO before using the following presets: ROOM_ACOUSTICS_KTV
    /// ROOM_ACOUSTICS_VOCAL_CONCERT
    /// ROOM_ACOUSTICS_STUDIO
    /// ROOM_ACOUSTICS_PHONOGRAPH
    /// ROOM_ACOUSTICS_SPACIAL
    /// ROOM_ACOUSTICS_ETHEREAL
    /// VOICE_CHANGER_EFFECT_UNCLE
    /// VOICE_CHANGER_EFFECT_OLDMAN
    /// VOICE_CHANGER_EFFECT_BOY
    /// VOICE_CHANGER_EFFECT_SISTER
    /// VOICE_CHANGER_EFFECT_GIRL
    /// VOICE_CHANGER_EFFECT_PIGKING
    /// VOICE_CHANGER_EFFECT_HULK
    /// PITCH_CORRECTION
    /// </summary>
    ///
    [Flags]
    public enum AUDIO_EFFECT_PRESET
    {
        ///
        /// <summary>
        /// Turn off voice effects, that is, use the original voice.
        /// </summary>
        ///
        AUDIO_EFFECT_OFF = 0x00000000,

        ///
        /// <summary>
        /// The voice effect typical of a KTV venue.
        /// </summary>
        ///
        ROOM_ACOUSTICS_KTV = 0x02010100,

        ///
        /// <summary>
        /// The voice effect typical of a concert hall.
        /// </summary>
        ///
        ROOM_ACOUSTICS_VOCAL_CONCERT = 0x02010200,

        ///
        /// <summary>
        /// The voice effect typical of a recording studio.
        /// </summary>
        ///
        ROOM_ACOUSTICS_STUDIO = 0x02010300,

        ///
        /// <summary>
        /// The voice effect typical of a vintage phonograph.
        /// </summary>
        ///
        ROOM_ACOUSTICS_PHONOGRAPH = 0x02010400,

        ///
        /// <summary>
        /// The virtual stereo effect, which renders monophonic audio as stereo audio.
        /// Before using this preset, set the profile parameter of SetAudioProfile [1/2] to AUDIO_PROFILE_MUSIC_HIGH_QUALITY or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO; otherwise, the preset setting is invalid. 
        /// </summary>
        ///
        ROOM_ACOUSTICS_VIRTUAL_STEREO = 0x02010500,

        ///
        /// <summary>
        /// A more spatial voice effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_SPACIAL = 0x02010600,

        ///
        /// <summary>
        /// A more ethereal voice effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_ETHEREAL = 0x02010700,

        ///
        /// <summary>
        /// A 3D voice effect that makes the voice appear to be moving around the user. The default movement cycle is 10 seconds. After setting this effect, you can call to SetAudioEffectParameters modify the movement period. Before using this preset, set the profile parameter of SetAudioProfile [1/2] to AUDIO_PROFILE_MUSIC_STANDARD_STEREO or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO; otherwise, the preset setting is invalid.
        /// If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_3D_VOICE = 0x02010800,

        ///
        /// <summary>
        /// A middle-aged man's voice.
        /// Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect. 
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_UNCLE = 0x02020100,

        ///
        /// <summary>
        /// A senior man's voice.
        /// Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect. 
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_OLDMAN = 0x02020200,

        ///
        /// <summary>
        /// A boy's voice.
        /// Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect. 
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_BOY = 0x02020300,

        ///
        /// <summary>
        /// A young woman's voice.
        /// Agora recommends using this preset to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect. 
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_SISTER = 0x02020400,

        ///
        /// <summary>
        /// A girl's voice.
        /// Agora recommends using this preset to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect. 
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_GIRL = 0x02020500,

        ///
        /// <summary>
        /// The voice of Pig King, a character in Journey to the West who has a voice like a growling bear.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_PIGKING = 0x02020600,

        ///
        /// <summary>
        /// The Hulk's voice.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_HULK = 0x02020700,

        ///
        /// <summary>
        /// The voice effect typical of R&B music.
        /// Before using this preset, set the profile parameter of SetAudioProfile [1/2] to AUDIO_PROFILE_MUSIC_HIGH_QUALITY or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO; otherwise, the preset setting is invalid. 
        /// </summary>
        ///
        STYLE_TRANSFORMATION_RNB = 0x02030100,

        ///
        /// <summary>
        /// The voice effect typical of popular music.
        /// Before using this preset, set the profile parameter of SetAudioProfile [1/2] to AUDIO_PROFILE_MUSIC_HIGH_QUALITY or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO; otherwise, the preset setting is invalid. 
        /// </summary>
        ///
        STYLE_TRANSFORMATION_POPULAR = 0x02030200,

        ///
        /// <summary>
        /// A pitch correction effect that corrects the user's pitch based on the pitch of the natural C major scale. After setting this voice effect, you can call SetAudioEffectParameters to adjust the basic mode of tuning and the pitch of the main tone.
        /// </summary>
        ///
        PITCH_CORRECTION = 0x02040100
    };

    ///
    /// <summary>
    /// The options for SDK preset voice conversion effects.
    /// </summary>
    ///
    [Flags]
    public enum VOICE_CONVERSION_PRESET
    {
        ///
        /// <summary>
        /// Turn off voice conversion effects and use the original voice.
        /// </summary>
        ///
        VOICE_CONVERSION_OFF = 0x00000000,

        ///
        /// <summary>
        /// A gender-neutral voice. To avoid audio distortion, ensure that you use this enumerator to process a female-sounding voice.
        /// </summary>
        ///
        VOICE_CHANGER_NEUTRAL = 0x03010100,

        ///
        /// <summary>
        /// A sweet voice. To avoid audio distortion, ensure that you use this enumerator to process a female-sounding voice.
        /// </summary>
        ///
        VOICE_CHANGER_SWEET = 0x03010200,

        ///
        /// <summary>
        /// A steady voice. To avoid audio distortion, ensure that you use this enumerator to process a male-sounding voice.
        /// </summary>
        ///
        VOICE_CHANGER_SOLID = 0x03010300,

        ///
        /// <summary>
        /// A deep voice. To avoid audio distortion, ensure that you use this enumerator to process a male-sounding voice.
        /// </summary>
        ///
        VOICE_CHANGER_BASS = 0x03010400
    };

    ///
    /// <summary>
    /// Screen sharing configurations.
    /// </summary>
    ///
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

        public ScreenCaptureParameters(ref VideoDimensions d, int f, int b)
        {
            dimensions = new VideoDimensions(d.width, d.height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, bool cur, bool fcs)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = cur;
            windowFocus = fcs;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, view_t[] ex, int cnt)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = ex;
            excludeWindowCount = cnt;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, bool cur, bool fcs, view_t[] ex, int cnt)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = cur;
            windowFocus = fcs;
            excludeWindowList = ex;
            excludeWindowCount = cnt;
        }

        ///
        /// <summary>
        /// The maximum dimensions of encoding the shared region.  The default value is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. VideoDimensions 
        /// If the aspect ratio is different between the encoding dimensions and screen dimensions, Agora applies the following algorithms for encoding. Suppose dimensions are 1920 x 1080:
        /// If the value of the screen dimensions is lower than that of dimensions, for example, 1000 x 1000 pixels, the SDK uses 1000 x 1000 pixels for encoding.
        /// If the value of the screen dimensions is higher than that of dimensions, for example, 2000 x 1500, the SDK uses the maximum value under dimensions with the aspect ratio of the screen dimension (4:3) for encoding, that is, 1440 x 1080. 
        /// </summary>
        ///
        public VideoDimensions dimensions { set; get; }

        ///
        /// <summary>
        /// On Windows and macOS, it represents the video encoding frame rate (fps) of the shared screen stream. The frame rate (fps) of the shared region. The default value is 5. We do not recommend setting this to a value greater than 15.
        /// </summary>
        ///
        public int frameRate { set; get; }

        ///
        /// <summary>
        /// On Windows and macOS, it represents the video encoding bitrate of the shared screen stream. The bitrate (Kbps) of the shared region. The default value is 0 (the SDK works out a bitrate according to the dimensions of the current screen).
        /// </summary>
        ///
        public int bitrate { set; get; }

        ///
        /// <summary>
        /// Whether to capture the mouse in screen sharing:
        /// true: (Default) Capture the mouse.
        /// false: Do not capture the mouse. 
        /// </summary>
        ///
        public bool captureMouseCursor { set; get; }

        ///
        /// <summary>
        ///  StartScreenCaptureByWindowId Whether to bring the window to the front when calling the method to share it:
        /// true:Bring the window to the front.
        /// false: (Default) Do not bring the window to the front. 
        /// </summary>
        ///
        public bool windowFocus { set; get; }

        ///
        /// <summary>
        /// A list of IDs of windows to be blocked. When calling StartScreenCaptureByScreenRect to start screen sharing, you can use this parameter to block a specified window. When calling to UpdateScreenCaptureParameters update screen sharing configurations, you can use this parameter to dynamically block the specified windows during screen sharing.
        /// </summary>
        ///
        public view_t[] excludeWindowList { set; get; }

        ///
        /// <summary>
        /// The number of windows to be blocked.
        /// </summary>
        ///
        public int excludeWindowCount { set; get; }
    };

    ///
    /// <summary>
    /// Recording quality.
    /// </summary>
    ///
    public enum AUDIO_RECORDING_QUALITY_TYPE
    {
        AUDIO_RECORDING_QUALITY_LOW = 0,

        AUDIO_RECORDING_QUALITY_MEDIUM = 1,

        AUDIO_RECORDING_QUALITY_HIGH = 2,
    };

    ///
    /// <summary>
    /// Recording content. Set in StartAudioRecording [3/3] .
    /// </summary>
    ///
    public enum AUDIO_FILE_RECORDING_TYPE
    {
        ///
        /// <summary>
        /// 1: Only records the audio of the local user.
        /// </summary>
        ///
        AUDIO_FILE_RECORDING_MIC = 1,

        ///
        /// <summary>
        /// 2: Only records the audio of all remote users.
        /// </summary>
        ///
        AUDIO_FILE_RECORDING_PLAYBACK = 2,

        ///
        /// <summary>
        /// 3: Records the mixed audio of the local and all remote users.
        /// </summary>
        ///
        AUDIO_FILE_RECORDING_MIXED = 3,
    };

    ///
    /// <summary>
    /// Audio profile.
    /// </summary>
    ///
    public enum AUDIO_ENCODED_FRAME_OBSERVER_POSITION
    {
        ///
        /// <summary>
        /// 1: Only records the audio of the local user.
        /// </summary>
        ///
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_RECORD = 1,

        ///
        /// <summary>
        /// 2: Only records the audio of all remote users.
        /// </summary>
        ///
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK = 2,

        ///
        /// <summary>
        /// 3: Records the mixed audio of the local and all remote users.
        /// </summary>
        ///
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_MIXED = 3,
    };

    ///
    /// <summary>
    /// Recording configuration.
    /// </summary>
    ///
    public class AudioRecordingConfiguration
    {
        public AudioRecordingConfiguration()
        {
            filePath = null;
            encode = false;
            sampleRate = 32000;
            fileRecordingType = AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIXED;
            quality = AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_LOW;
        }

        public AudioRecordingConfiguration(string file_path, int sample_rate, AUDIO_RECORDING_QUALITY_TYPE quality_type)
        {
            this.filePath = file_path;
            this.encode = false;
            this.sampleRate = sample_rate;
            this.fileRecordingType = AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIXED;
            this.quality = quality_type;
        }

        public AudioRecordingConfiguration(string file_path, bool enc, int sample_rate,
                                        AUDIO_FILE_RECORDING_TYPE type, AUDIO_RECORDING_QUALITY_TYPE quality_type)
        {
            this.filePath = file_path;
            this.encode = enc;
            this.sampleRate = sample_rate;
            this.fileRecordingType = type;
            this.quality = quality_type;
        }

        ///
        /// <summary>
        /// The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.mp4. Ensure that the path for the recording file exists and is writable.
        /// </summary>
        ///
        public string filePath { set; get; }

        ///
        /// <summary>
        /// Whether to encode the audio data: true
        /// : Encode audio data in AAC.
        /// false
        /// : (Default) Do not encode audio data, but save the recorded audio data directly.
        /// </summary>
        ///
        public bool encode { set; get; }

        ///
        /// <summary>
        /// Recording sample rate (Hz). 16000
        /// (Default) 32000
        /// 44100
        /// 48000 If you set this parameter to 44100 or 48000, Agora recommends recording WAV files, or AAC files with quality to be AgoraAudioRecordingQualityMedium or AgoraAudioRecordingQualityHigh for better recording quality. 
        /// </summary>
        ///
        public int sampleRate { set; get; }

        ///
        /// <summary>
        /// Recording content. See AUDIO_FILE_RECORDING_TYPE .
        /// </summary>
        ///
        public AUDIO_FILE_RECORDING_TYPE fileRecordingType { set; get; }

        ///
        /// <summary>
        /// Recording quality. See AUDIO_RECORDING_QUALITY_TYPE . This parameter applies to AAC files only.
        /// </summary>
        ///
        public AUDIO_RECORDING_QUALITY_TYPE quality { set; get; }
    };

    ///
    /// <summary>
    /// Observer settings for encoded audio.
    /// </summary>
    ///
    public class AudioEncodedFrameObserverConfig
    {
        public AudioEncodedFrameObserverConfig()
        {
            postionType = AUDIO_ENCODED_FRAME_OBSERVER_POSITION.AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK;
            encodingType = AUDIO_ENCODING_TYPE.AUDIO_ENCODING_TYPE_OPUS_48000_MEDIUM;
        }

        public AudioEncodedFrameObserverConfig(AUDIO_ENCODED_FRAME_OBSERVER_POSITION postionType,
                                                AUDIO_ENCODING_TYPE encodingType)
        {
            this.encodingType = encodingType;
            this.postionType = postionType;
        }

        ///
        /// <summary>
        /// Audio profile. See AUDIO_ENCODED_FRAME_OBSERVER_POSITION .
        /// </summary>
        ///
        public AUDIO_ENCODED_FRAME_OBSERVER_POSITION postionType { set; get; }

        ///
        /// <summary>
        /// Audio encoding type. See AUDIO_ENCODING_TYPE .
        /// </summary>
        ///
        public AUDIO_ENCODING_TYPE encodingType { set; get; }
    };

    ///
    /// <summary>
    /// The region for connection, i.e., the region where the server the SDK connects to is located.
    /// </summary>
    ///
    public enum AREA_CODE : uint
    {
        ///
        /// <summary>
        /// Mainland China.
        /// </summary>
        ///
        AREA_CODE_CN = 0x00000001,

        ///
        /// <summary>
        /// North America.
        /// </summary>
        ///
        AREA_CODE_NA = 0x00000002,

        ///
        /// <summary>
        /// Europe.
        /// </summary>
        ///
        AREA_CODE_EU = 0x00000004,

        ///
        /// <summary>
        /// Asia, excluding Mainland China.
        /// </summary>
        ///
        AREA_CODE_AS = 0x00000008,

        ///
        /// <summary>
        /// Japan.
        /// </summary>
        ///
        AREA_CODE_JP = 0x00000010,

        ///
        /// <summary>
        /// India.
        /// </summary>
        ///
        AREA_CODE_IN = 0x00000020,

        ///
        /// <summary>
        /// Global.
        /// </summary>
        ///
        AREA_CODE_GLOB = 0xFFFFFFFF
    };

    public enum AREA_CODE_EX : uint
    {
        AREA_CODE_OC = 0x00000040,

        AREA_CODE_SA = 0x00000080,

        AREA_CODE_AF = 0x00000100,

        AREA_CODE_KR = 0x00000200,

        AREA_CODE_OVS = 0xFFFFFFFE
    };

    ///
    /// <summary>
    /// The error code of the channel media relay.
    /// </summary>
    ///
    public enum CHANNEL_MEDIA_RELAY_ERROR
    {
        ///
        /// <summary>
        /// 0: No error.
        /// </summary>
        ///
        RELAY_OK = 0,

        ///
        /// <summary>
        /// 1: An error occurs in the server response.
        /// </summary>
        ///
        RELAY_ERROR_SERVER_ERROR_RESPONSE = 1,

        ///
        /// <summary>
        /// 2: No server response.
        /// You can call LeaveChannel [1/2] 
        /// This error can also occur if your project has not enabled co-host token authentication. You can to enable the service for cohosting across channels before starting a channel media relay.
        /// </summary>
        ///
        RELAY_ERROR_SERVER_NO_RESPONSE = 2,

        ///
        /// <summary>
        /// 3: The SDK fails to access the service, probably due to limited resources of the server.
        /// </summary>
        ///
        RELAY_ERROR_NO_RESOURCE_AVAILABLE = 3,

        ///
        /// <summary>
        /// 4: Fails to send the relay request.
        /// </summary>
        ///
        RELAY_ERROR_FAILED_JOIN_SRC = 4,

        ///
        /// <summary>
        /// 5: Fails to accept the relay request.
        /// </summary>
        ///
        RELAY_ERROR_FAILED_JOIN_DEST = 5,

        ///
        /// <summary>
        /// 6: The server fails to receive the media stream.
        /// </summary>
        ///
        RELAY_ERROR_FAILED_PACKET_RECEIVED_FROM_SRC = 6,

        ///
        /// <summary>
        /// 7: The server fails to send the media stream.
        /// </summary>
        ///
        RELAY_ERROR_FAILED_PACKET_SENT_TO_DEST = 7,

        ///
        /// <summary>
        /// 8: The SDK disconnects from the server due to poor network connections. You can call LeaveChannel [1/2] 
        /// </summary>
        ///
        RELAY_ERROR_SERVER_CONNECTION_LOST = 8,

        ///
        /// <summary>
        /// 9: An internal error occurs in the server.
        /// </summary>
        ///
        RELAY_ERROR_INTERNAL_ERROR = 9,

        ///
        /// <summary>
        /// 10: The token of the source channel has expired.
        /// </summary>
        ///
        RELAY_ERROR_SRC_TOKEN_EXPIRED = 10,

        ///
        /// <summary>
        /// 11: The token of the destination channel has expired.
        /// </summary>
        ///
        RELAY_ERROR_DEST_TOKEN_EXPIRED = 11,
    };

    //callback event
    ///
    /// <summary>
    /// The event code of channel media relay.
    /// </summary>
    ///
    public enum CHANNEL_MEDIA_RELAY_EVENT
    {
        ///
        /// <summary>
        /// 0: The user disconnects from the server due to a poor network connection.
        /// </summary>
        ///
        RELAY_EVENT_NETWORK_DISCONNECTED = 0,

        ///
        /// <summary>
        /// 1: The user is connected to the server.
        /// </summary>
        ///
        RELAY_EVENT_NETWORK_CONNECTED = 1,

        ///
        /// <summary>
        /// 2: The user joins the source channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_JOINED_SRC_CHANNEL = 2,

        ///
        /// <summary>
        /// 3: The user joins the destination channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_JOINED_DEST_CHANNEL = 3,

        ///
        /// <summary>
        /// 4: The SDK starts relaying the media stream to the destination channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL = 4,

        ///
        /// <summary>
        /// 5: The server receives the audio stream from the source channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_RECEIVED_VIDEO_FROM_SRC = 5,

        ///
        /// <summary>
        /// 6: The server receives the audio stream from the source channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_RECEIVED_AUDIO_FROM_SRC = 6,

        ///
        /// <summary>
        /// 7: The destination channel is updated.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL = 7,

        ///
        /// <summary>
        /// 8: The destination channel update fails due to internal reasons.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_REFUSED = 8,

        ///
        /// <summary>
        /// 9: The destination channel does not change, which means that the destination channel fails to be updated.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_NOT_CHANGE = 9,

        ///
        /// <summary>
        /// 10: The destination channel name is NULL.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_IS_NULL = 10,

        ///
        /// <summary>
        /// 11: The video profile is sent to the server.
        /// </summary>
        ///
        RELAY_EVENT_VIDEO_PROFILE_UPDATE = 11,

        ///
        /// <summary>
        /// 12: The SDK successfully pauses relaying the media stream to destination channels.
        /// </summary>
        ///
        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 12,

        ///
        /// <summary>
        /// 13: The SDK fails to pause relaying the media stream to destination channels.
        /// </summary>
        ///
        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 13,

        ///
        /// <summary>
        /// 14: The SDK successfully resumes relaying the media stream to destination channels.
        /// </summary>
        ///
        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 14,

        ///
        /// <summary>
        /// 15: The SDK fails to resume relaying the media stream to destination channels.
        /// </summary>
        ///
        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 15,
    };

    ///
    /// <summary>
    /// The state code of the channel media relay.
    /// </summary>
    ///
    public enum CHANNEL_MEDIA_RELAY_STATE
    {
        ///
        /// <summary>
        /// 0: The initial state. After you successfullystop the channel media relay by calling StopChannelMediaRelay , the OnChannelMediaRelayStateChanged callback returns this state.
        /// </summary>
        ///
        RELAY_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: The SDK tries to relay the media stream to the destination channel.
        /// </summary>
        ///
        RELAY_STATE_CONNECTING = 1,

        ///
        /// <summary>
        /// 2: The SDK successfully relays the media stream to the destination channel.
        /// </summary>
        ///
        RELAY_STATE_RUNNING = 2,

        ///
        /// <summary>
        /// 3: An error occurs. See code in OnChannelMediaRelayStateChanged for the error code.
        /// </summary>
        ///
        RELAY_STATE_FAILURE = 3,
    };

    ///
    /// <summary>
    /// The definition of ChannelMediaInfo.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// The channel name.
        /// </summary>
        ///
        public string channelName { set; get; }

        ///
        /// <summary>
        /// The token that enables the user to join the channel.
        /// </summary>
        ///
        public string token { set; get; }

        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint uid { set; get; }
    }

    ///
    /// <summary>
    /// The definition of ChannelMediaRelayConfiguration.
    /// </summary>
    ///
    public class ChannelMediaRelayConfiguration
    {
        public ChannelMediaRelayConfiguration()
        {
            srcInfo = null;
            destInfos = new ChannelMediaInfo[0];
            destCount = 0;
        }

        public ChannelMediaRelayConfiguration(ChannelMediaInfo srcInfo, ChannelMediaInfo[]destInfos, int destCount)
        {
            this.srcInfo = srcInfo;
            this.destInfos = destInfos ?? new ChannelMediaInfo[0];
            this.destCount = destCount;
        }

        ///
        /// <summary>
        /// The information of the source channel ChannelMediaInfo . It contains the following members:
        /// channelName: The name of the source channel. The default value is NULL, which means the SDK applies the name of the current channel.
        /// uid: The unique ID to identify the relay stream in the source channel. The default value is 0, which means the SDK generates a random uid. You must set it as 0.
        /// token: The token for joining the source channel. It is generated with the channelName and uid you set in srcInfo.
        /// If you have not enabled the App Certificate, set this parameter as the default value NULL, which means the SDK applies the App ID.
        /// If you have enabled the App Certificate, you must use the token generated with the channelName and uid, and the uid must be set as 0. 
        /// </summary>
        ///
        public ChannelMediaInfo srcInfo { set; get; }

        ///
        /// <summary>
        /// The information of the destination channel ChannelMediaInfo. It contains the following members:
        /// channelName : The name of the destination channel.
        /// uid: The unique ID to identify the relay stream in the destination channel. The value ranges from 0 to (232-1). To avoid UID conflicts, this UID must be different from any other UID in the destination channel. The default value is 0, which means the SDK generates a random UID. Do not set this parameter as the UID of the host in the destination channel, and ensure that this UID is different from any other UID in the channel.
        /// token: The token for joining the destination channel. It is generated with the channelName and uid you set in destInfos.
        /// If you have not enabled the App Certificate, set this parameter as the default value NULL, which means the SDK applies the App ID.
        /// If you have enabled the App Certificate, you must use the token generated with the channelName and uid. 
        /// </summary>
        ///
        public ChannelMediaInfo[] destInfos { set; get; }

        ///
        /// <summary>
        /// The number of destination channels. The default value is 0, and the value range is from 0 to 4. Ensure that the value of this parameter corresponds to the number of ChannelMediaInfo structs you define in destInfo.
        /// </summary>
        ///
        public int destCount { set; get; }
    };

    ///
    /// <summary>
    /// The uplink network information.
    /// </summary>
    ///
    public class UplinkNetworkInfo
    {
        public UplinkNetworkInfo()
        {
            video_encoder_target_bitrate_bps = 0;
        }

        public UplinkNetworkInfo(int video_encoder_target_bitrate_bps)
        {
            this.video_encoder_target_bitrate_bps = video_encoder_target_bitrate_bps;
        }

        public int video_encoder_target_bitrate_bps;
    };

    public class PeerDownlinkInfo
    {
        public PeerDownlinkInfo()
        {
            uid = null;
            stream_type = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
            current_downscale_level = REMOTE_VIDEO_DOWNSCALE_LEVEL.REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE;
            expected_bitrate_bps = -1;
        }

        public PeerDownlinkInfo(string uid, VIDEO_STREAM_TYPE stream_type,
                                REMOTE_VIDEO_DOWNSCALE_LEVEL current_downscale_level, int expected_bitrate_bps)
        {
            this.uid = uid;
            this.stream_type = stream_type;
            this.current_downscale_level = current_downscale_level;
            this.expected_bitrate_bps = expected_bitrate_bps;
        }

        public string uid { set; get; }

        public VIDEO_STREAM_TYPE stream_type { set; get; }

        public REMOTE_VIDEO_DOWNSCALE_LEVEL current_downscale_level { set; get; }

        public int expected_bitrate_bps { set; get; }
    };

    public class DownlinkNetworkInfo
    {
        public DownlinkNetworkInfo()
        {
            lastmile_buffer_delay_time_ms = -1;
            bandwidth_estimation_bps = -1;
            total_downscale_level_count = -1;
            peer_downlink_info = null;
            total_received_video_count = -1;
        }

        public DownlinkNetworkInfo(ref DownlinkNetworkInfo info)
        {
            lastmile_buffer_delay_time_ms = info.lastmile_buffer_delay_time_ms;
            bandwidth_estimation_bps = info.bandwidth_estimation_bps;
            total_downscale_level_count = info.total_downscale_level_count;
            peer_downlink_info = null;
            total_received_video_count = info.total_received_video_count;

            if (total_received_video_count <= 0) return;
            peer_downlink_info = new PeerDownlinkInfo[total_received_video_count];
            for (int i = 0; i < total_received_video_count; i++)
            {
                peer_downlink_info[i] = info.peer_downlink_info[i];
            }
        }

        public DownlinkNetworkInfo(int lastmile_buffer_delay_time_ms, int bandwidth_estimation_bps,
                                int total_downscale_level_count, PeerDownlinkInfo[] peer_downlink_info,
                                int total_received_video_count)
        {
            this.lastmile_buffer_delay_time_ms = lastmile_buffer_delay_time_ms;
            this.bandwidth_estimation_bps = bandwidth_estimation_bps;
            this.total_downscale_level_count = total_downscale_level_count;
            this.peer_downlink_info = peer_downlink_info;
            this.total_received_video_count = total_received_video_count;
        }

        public int lastmile_buffer_delay_time_ms { set; get; }

        public int bandwidth_estimation_bps { set; get; }

        public int total_downscale_level_count { set; get; }

        public PeerDownlinkInfo[] peer_downlink_info { set; get; }

        public int total_received_video_count { set; get; }
    };

    ///
    /// <summary>
    /// The built-in encryption mode.
    /// Agora recommends using AES_128_GCM2 or AES_256_GCM2 encrypted mode. These two modes support the use of salt for higher security.
    /// </summary>
    ///
    public enum ENCRYPTION_MODE
    {
        ///
        /// <summary>
        /// 1: 128-bit AES encryption, XTS mode.
        /// </summary>
        ///
        AES_128_XTS = 1,

        ///
        /// <summary>
        /// 2: 128-bit AES encryption, ECB mode.
        /// </summary>
        ///
        AES_128_ECB = 2,

        ///
        /// <summary>
        /// 3: 256-bit AES encryption, XTS mode.
        /// </summary>
        ///
        AES_256_XTS = 3,

        ///
        /// <summary>
        /// 4: 128-bit SM4 encryption, ECB mode.
        /// </summary>
        ///
        SM4_128_ECB = 4,

        ///
        /// <summary>
        /// 5: 128-bit AES encryption, GCM mode.
        /// </summary>
        ///
        AES_128_GCM = 5,

        ///
        /// <summary>
        /// 6: 256-bit AES encryption, GCM mode.
        /// </summary>
        ///
        AES_256_GCM = 6,

        ///
        /// <summary>
        /// 7: (Default) 128-bit AES encryption, GCM mode. This encryption mode requires the setting of salt (encryptionKdfSalt).
        /// </summary>
        ///
        AES_128_GCM2 = 7,

        ///
        /// <summary>
        /// 8: 256-bit AES encryption, GCM mode. This encryption mode requires the setting of salt (encryptionKdfSalt).
        /// </summary>
        ///
        AES_256_GCM2 = 8,

        ///
        /// <summary>
        /// Enumeration boundary.
        /// </summary>
        ///
        MODE_END = 9,
    };

    ///
    /// <summary>
    /// Built-in encryption configurations.
    /// </summary>
    ///
    public class EncryptionConfig
    {
        public EncryptionConfig()
        {
            encryptionMode = ENCRYPTION_MODE.MODE_END;
            encryptionKey = "";
            encryptionKdfSalt = new byte[32];
        }

        public EncryptionConfig(ENCRYPTION_MODE encryptionMode, string encryptionKey, byte[] encryptionKdfSalt)
        {
            this.encryptionMode = encryptionMode;
            this.encryptionKey = encryptionKey;
            this.encryptionKdfSalt = encryptionKdfSalt;
        }

        public string getEncryptionString()
        {
            switch (encryptionMode)
            {
                case ENCRYPTION_MODE.AES_128_XTS:
                    return "aes-128-xts";
                case ENCRYPTION_MODE.AES_128_ECB:
                    return "aes-128-ecb";
                case ENCRYPTION_MODE.AES_256_XTS:
                    return "aes-256-xts";
                case ENCRYPTION_MODE.SM4_128_ECB:
                    return "sm4-128-ecb";
                case ENCRYPTION_MODE.AES_128_GCM:
                    return "aes-128-gcm";
                case ENCRYPTION_MODE.AES_256_GCM:
                    return "aes-256-gcm";
                case ENCRYPTION_MODE.AES_128_GCM2:
                    return "aes-128-gcm-2";
                case ENCRYPTION_MODE.AES_256_GCM2:
                    return "aes-256-gcm-2";
                default:
                    return "aes-128-gcm-2";
            }
            return "aes-128-gcm-2";
        }

        ///
        /// <summary>
        /// The built-in encryption mode. See ENCRYPTION_MODE . Agora recommends using AES_128_GCM2 or AES_256_GCM2 encrypted mode. These two modes support the use of salt for higher security.
        /// </summary>
        ///
        public ENCRYPTION_MODE encryptionMode { set; get; }

        ///
        /// <summary>
        /// Encryption key in string type with unlimited length. Agora recommends using a 32-byte key.
        /// If you do not set an encryption key or set it as NULL, you cannot use the built-in encryption, and the SDK returns -2. 
        /// </summary>
        ///
        public string encryptionKey { set; get; }

        private byte[] encryptionKdfSalt32 = new byte[32];

        public byte[] encryptionKdfSalt
        {
            set { Buffer.BlockCopy(value, 0, encryptionKdfSalt32, 0, 32); }

            get { return encryptionKdfSalt32; }
        }
    };

    ///
    /// <summary>
    /// Encryption error type.
    /// </summary>
    ///
    public enum ENCRYPTION_ERROR_TYPE
    {
        ///
        /// <summary>
        /// 0: Internal reason.
        /// </summary>
        ///
        ENCRYPTION_ERROR_INTERNAL_FAILURE = 0,

        ///
        /// <summary>
        /// 1: Decryption errors.
        /// Ensure that the receiver and the sender use the same encryption mode and key.
        /// </summary>
        ///
        ENCRYPTION_ERROR_DECRYPTION_FAILURE = 1,

        ///
        /// <summary>
        /// 2: Encryption errors.
        /// </summary>
        ///
        ENCRYPTION_ERROR_ENCRYPTION_FAILURE = 2,
    };

    public enum UPLOAD_ERROR_REASON
    {
        UPLOAD_SUCCESS = 0,

        UPLOAD_NET_ERROR = 1,

        UPLOAD_SERVER_ERROR = 2,
    };

    ///
    /// <summary>
    /// The type of the device permission.
    /// </summary>
    ///
    public enum PERMISSION_TYPE
    {
        ///
        /// <summary>
        /// 0: Permission for the audio capture device.
        /// </summary>
        ///
        RECORD_AUDIO = 0,

        ///
        /// <summary>
        /// 1: Permission for the camera.
        /// </summary>
        ///
        CAMERA = 1,
    };

    ///
    /// <summary>
    /// The maximum length of the user account.
    /// </summary>
    ///
    public enum MAX_USER_ACCOUNT_LENGTH_TYPE
    {
        ///
        /// <summary>
        /// The maximum length of the user account is 256 bytes.
        /// </summary>
        ///
        MAX_USER_ACCOUNT_LENGTH = 256
    };

    ///
    /// <summary>
    /// The subscribing state.
    /// </summary>
    ///
    public enum STREAM_SUBSCRIBE_STATE
    {
        ///
        /// <summary>
        /// 0: The initial publishing state after joining the channel.
        /// </summary>
        ///
        SUB_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: Fails to subscribe to the remote stream. Possible reasons:
        /// Remote users:
        /// Calls MuteLocalAudioStream (true) or MuteLocalVideoStream (true) to stop sending local media streams.
        /// Calls DisableAudio or DisableVideo to disable the local audio or video module.
        /// Calls EnableLocalAudio (false) or EnableLocalVideo (false) to disable local audio or video capture.
        /// The role of the local user is audience. The local user calls the following method to stop receiving the remote media stream:
        /// Call MuteRemoteAudioStream (true), MuteAllRemoteAudioStreams (true) or SetDefaultMuteAllRemoteAudioStreams (true) to stop receiving the remote audio stream.
        /// Call MuteRemoteVideoStream (true), MuteAllRemoteVideoStreams (true) or SetDefaultMuteAllRemoteVideoStreams (true) to stop receiving the remote video stream. 
        /// </summary>
        ///
        SUB_STATE_NO_SUBSCRIBED = 1,

        ///
        /// <summary>
        /// 2: Publishing.
        /// </summary>
        ///
        SUB_STATE_SUBSCRIBING = 2,

        ///
        /// <summary>
        /// 3: The remote stream is received, and the subscription is successful.
        /// </summary>
        ///
        SUB_STATE_SUBSCRIBED = 3
    };

    ///
    /// <summary>
    /// The publishing state.
    /// </summary>
    ///
    public enum STREAM_PUBLISH_STATE
    {
        ///
        /// <summary>
        /// 0: The initial publishing state after joining the channel.
        /// </summary>
        ///
        PUB_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: Fails to publish the local stream. Possible reasons:
        /// Local user calls MuteLocalAudioStream (true) or MuteLocalVideoStream (true) to stop sending local media streams.
        /// The local user calls DisableAudio or DisableVideo to disable the local audio or video module.
        /// The local user calls EnableLocalAudio (false) or EnableLocalVideo (false) to disable the local audio or video capture.
        /// The role of the local user is audience. 
        /// </summary>
        ///
        PUB_STATE_NO_PUBLISHED = 1,

        ///
        /// <summary>
        /// 2: Publishing.
        /// </summary>
        ///
        PUB_STATE_PUBLISHING = 2,

        ///
        /// <summary>
        /// 3: Publishes successfully.
        /// </summary>
        ///
        PUB_STATE_PUBLISHED = 3
    };

    ///
    /// <summary>
    /// The information of the user.
    /// </summary>
    ///
    public class UserInfo
    {
        public uint uid;

        public string userAccount;

        public UserInfo()
        {
            uid = 0;
            userAccount = "";
        }
    }

    ///
    /// <summary>
    /// The audio filter of in-ear monitoring.
    /// </summary>
    ///
    [Flags]
    public enum EAR_MONITORING_FILTER_TYPE
    {
        ///
        /// <summary>
        /// 1: Do not add an audio filter to the in-ear monitor.
        /// </summary>
        ///
        EAR_MONITORING_FILTER_NONE = (1 << 0),

        ///
        /// <summary>
        /// 2: Add an audio filter to the in-ear monitor.
        /// If you implement functions such as voice beautifier and audio effect, users can hear the voice after adding these effects.
        /// </summary>
        ///
        EAR_MONITORING_FILTER_BUILT_IN_AUDIO_FILTERS = (1 << 1),

        ///
        /// <summary>
        /// 4: Enable noise suppression to the in-ear monitor.
        /// </summary>
        ///
        EAR_MONITORING_FILTER_NOISE_SUPPRESSION = (1 << 2)
    };

    public enum THREAD_PRIORITY_TYPE
    {
        LOWEST = 0,

        LOW = 1,

        NORMAL = 2,

        HIGH = 3,

        HIGHEST = 4,

        CRITICAL = 5,
    };

    public class SpatialAudioParams : OptionalJsonParse
    {
        public Optional<double> speaker_azimuth = new Optional<double>();
        public Optional<double> speaker_elevation = new Optional<double>();
        public Optional<double> speaker_distance = new Optional<double>();
        public Optional<int> speaker_orientation = new Optional<int>();
        public Optional<bool> enable_blur = new Optional<bool>();
        public Optional<bool> enable_air_absorb = new Optional<bool>();

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.speaker_azimuth.HasValue())
            {
                writer.WritePropertyName("speaker_azimuth");
                writer.Write(this.speaker_azimuth.GetValue());
            }

            if (this.speaker_elevation.HasValue())
            {
                writer.WritePropertyName("speaker_elevation");
                writer.Write(this.speaker_elevation.GetValue());
            }

            if (this.speaker_distance.HasValue())
            {
                writer.WritePropertyName("speaker_distance");
                writer.Write(this.speaker_distance.GetValue());
            }

            if (this.speaker_orientation.HasValue())
            {
                writer.WritePropertyName("speaker_orientation");
                writer.Write(this.speaker_orientation.GetValue());
            }

            if (this.enable_blur.HasValue())
            {
                writer.WritePropertyName("enable_blur");
                writer.Write(this.enable_blur.GetValue());

            }

            if (this.enable_air_absorb.HasValue())
            {
                writer.WritePropertyName("enable_air_absorb");
                writer.Write(this.enable_air_absorb.GetValue());
            }

            writer.WriteObjectEnd();
        }
    };

    public enum TCcMode
    {
        CC_ENABLED = 0,

        CC_DISABLED = 1,
    };

    public class SenderOptions
    {
        public TCcMode ccMode { set; get; }

        public VIDEO_CODEC_TYPE codecType { set; get; }

        public int targetBitrate { set; get; }

        public SenderOptions()
        {
            ccMode = TCcMode.CC_ENABLED;
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            targetBitrate = 6500;
        }
    };

    #endregion
}