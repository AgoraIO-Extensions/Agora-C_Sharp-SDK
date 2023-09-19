using System;
using Agora.Rtc.LitJson;
namespace Agora.Rtc
{
    using view_t = Int64;

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
    }

    /* class_userinfo */
    public class UserInfo
    {
        /* class_userinfo_uid */
        public uint uid;

        /* class_userinfo_userAccount */
        public string userAccount;

        public UserInfo()
        {
            uid = 0;
            userAccount = "";
        }
    }

    /* enum_bitrate */
    public enum BITRATE
    {
        /* enum_bitrate_STANDARD_BITRATE */
        STANDARD_BITRATE = 0,

        /* enum_bitrate_COMPATIBLE_BITRATE */
        COMPATIBLE_BITRATE = -1,

        /* enum_bitrate_DEFAULT_MIN_BITRATE */
        DEFAULT_MIN_BITRATE = -1,

        /* enum_bitrate_DEFAULT_MIN_BITRATE_EQUAL_TO_TARGET_BITRATE */
        DEFAULT_MIN_BITRATE_EQUAL_TO_TARGET_BITRATE = -2,
    }

    /* class_downlinknetworkinfo */
    public class DownlinkNetworkInfo
    {
        /* class_downlinknetworkinfo_lastmile_buffer_delay_time_ms */
        public int lastmile_buffer_delay_time_ms;

        /* class_downlinknetworkinfo_bandwidth_estimation_bps */
        public int bandwidth_estimation_bps;

        /* class_downlinknetworkinfo_total_downscale_level_count */
        public int total_downscale_level_count;

        public PeerDownlinkInfo[] peer_downlink_info;

        /* class_downlinknetworkinfo_total_received_video_count */
        public int total_received_video_count;

        public DownlinkNetworkInfo()
        {
            this.lastmile_buffer_delay_time_ms = -1;
            this.bandwidth_estimation_bps = -1;
            this.total_downscale_level_count = -1;
            this.peer_downlink_info = new PeerDownlinkInfo[0];
            this.total_received_video_count = -1;
        }

        public DownlinkNetworkInfo(ref DownlinkNetworkInfo info)
        {
            this.lastmile_buffer_delay_time_ms = info.lastmile_buffer_delay_time_ms;
            this.bandwidth_estimation_bps = info.bandwidth_estimation_bps;
            this.total_downscale_level_count = info.total_downscale_level_count;
            this.total_received_video_count = info.total_received_video_count;

            if (total_received_video_count <= 0)
                return;
            peer_downlink_info = new PeerDownlinkInfo[total_received_video_count];
            for (int i = 0; i < total_received_video_count; i++)
            {
                peer_downlink_info[i] = info.peer_downlink_info[i];
            }
        }

        public DownlinkNetworkInfo(int lastmile_buffer_delay_time_ms, int bandwidth_estimation_bps, int total_downscale_level_count, PeerDownlinkInfo[] peer_downlink_info, int total_received_video_count)
        {
            this.lastmile_buffer_delay_time_ms = lastmile_buffer_delay_time_ms;
            this.bandwidth_estimation_bps = bandwidth_estimation_bps;
            this.total_downscale_level_count = total_downscale_level_count;
            this.peer_downlink_info = peer_downlink_info;
            this.total_received_video_count = total_received_video_count;
        }
    }

    /* class_encryptionconfig */
    public class EncryptionConfig
    {
        /* class_encryptionconfig_encryptionMode */
        public ENCRYPTION_MODE encryptionMode;

        /* class_encryptionconfig_encryptionKey */
        public string encryptionKey;

        public byte[] encryptionKdfSalt;

        public EncryptionConfig()
        {
            this.encryptionMode = ENCRYPTION_MODE.AES_128_GCM2;
            this.encryptionKey = "";
            this.encryptionKdfSalt = new byte[32];
        }

        public EncryptionConfig(ENCRYPTION_MODE encryptionMode, string encryptionKey, byte[] encryptionKdfSalt)
        {
            this.encryptionMode = encryptionMode;
            this.encryptionKey = encryptionKey;
            this.encryptionKdfSalt = encryptionKdfSalt;
        }

        public string GetEncryptionString()
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
        }
    }

    /* class_deviceinfomobile */
    public class DeviceInfoMobile
    {
        /* class_deviceinfomobile_isLowLatencyAudioSupported */
        public bool isLowLatencyAudioSupported;

        public DeviceInfoMobile()
        {
            this.isLowLatencyAudioSupported = false;
        }

        public DeviceInfoMobile(bool isLowLatencyAudioSupported)
        {
            this.isLowLatencyAudioSupported = isLowLatencyAudioSupported;
        }
    }

    /* class_deviceinfo */
    public class DeviceInfo
    {
        /* class_deviceinfo_deviceName */
        public string deviceName;

        /* class_deviceinfo_deviceId */
        public string deviceId;
    };

#region terra AgoraBase.h

    /* enum_channelprofiletype */
    public enum CHANNEL_PROFILE_TYPE
    {
        /* enum_channelprofiletype_CHANNEL_PROFILE_COMMUNICATION */
        CHANNEL_PROFILE_COMMUNICATION = 0,

        /* enum_channelprofiletype_CHANNEL_PROFILE_LIVE_BROADCASTING */
        CHANNEL_PROFILE_LIVE_BROADCASTING = 1,

        /* enum_channelprofiletype_CHANNEL_PROFILE_GAME */
        CHANNEL_PROFILE_GAME = 2,

        /* enum_channelprofiletype_CHANNEL_PROFILE_CLOUD_GAMING */
        CHANNEL_PROFILE_CLOUD_GAMING = 3,

        /* enum_channelprofiletype_CHANNEL_PROFILE_COMMUNICATION_1v1 */
        CHANNEL_PROFILE_COMMUNICATION_1v1 = 4,
    }

    /* enum_warncodetype */
    public enum WARN_CODE_TYPE
    {
        /* enum_warncodetype_WARN_INVALID_VIEW */
        WARN_INVALID_VIEW = 8,

        /* enum_warncodetype_WARN_INIT_VIDEO */
        WARN_INIT_VIDEO = 16,

        /* enum_warncodetype_WARN_PENDING */
        WARN_PENDING = 20,

        /* enum_warncodetype_WARN_NO_AVAILABLE_CHANNEL */
        WARN_NO_AVAILABLE_CHANNEL = 103,

        /* enum_warncodetype_WARN_LOOKUP_CHANNEL_TIMEOUT */
        WARN_LOOKUP_CHANNEL_TIMEOUT = 104,

        /* enum_warncodetype_WARN_LOOKUP_CHANNEL_REJECTED */
        WARN_LOOKUP_CHANNEL_REJECTED = 105,

        /* enum_warncodetype_WARN_OPEN_CHANNEL_TIMEOUT */
        WARN_OPEN_CHANNEL_TIMEOUT = 106,

        /* enum_warncodetype_WARN_OPEN_CHANNEL_REJECTED */
        WARN_OPEN_CHANNEL_REJECTED = 107,

        /* enum_warncodetype_WARN_SWITCH_LIVE_VIDEO_TIMEOUT */
        WARN_SWITCH_LIVE_VIDEO_TIMEOUT = 111,

        /* enum_warncodetype_WARN_SET_CLIENT_ROLE_TIMEOUT */
        WARN_SET_CLIENT_ROLE_TIMEOUT = 118,

        /* enum_warncodetype_WARN_OPEN_CHANNEL_INVALID_TICKET */
        WARN_OPEN_CHANNEL_INVALID_TICKET = 121,

        /* enum_warncodetype_WARN_OPEN_CHANNEL_TRY_NEXT_VOS */
        WARN_OPEN_CHANNEL_TRY_NEXT_VOS = 122,

        /* enum_warncodetype_WARN_CHANNEL_CONNECTION_UNRECOVERABLE */
        WARN_CHANNEL_CONNECTION_UNRECOVERABLE = 131,

        /* enum_warncodetype_WARN_CHANNEL_CONNECTION_IP_CHANGED */
        WARN_CHANNEL_CONNECTION_IP_CHANGED = 132,

        /* enum_warncodetype_WARN_CHANNEL_CONNECTION_PORT_CHANGED */
        WARN_CHANNEL_CONNECTION_PORT_CHANGED = 133,

        /* enum_warncodetype_WARN_CHANNEL_SOCKET_ERROR */
        WARN_CHANNEL_SOCKET_ERROR = 134,

        /* enum_warncodetype_WARN_AUDIO_MIXING_OPEN_ERROR */
        WARN_AUDIO_MIXING_OPEN_ERROR = 701,

        /* enum_warncodetype_WARN_ADM_RUNTIME_PLAYOUT_WARNING */
        WARN_ADM_RUNTIME_PLAYOUT_WARNING = 1014,

        /* enum_warncodetype_WARN_ADM_RUNTIME_RECORDING_WARNING */
        WARN_ADM_RUNTIME_RECORDING_WARNING = 1016,

        /* enum_warncodetype_WARN_ADM_RECORD_AUDIO_SILENCE */
        WARN_ADM_RECORD_AUDIO_SILENCE = 1019,

        /* enum_warncodetype_WARN_ADM_PLAYOUT_MALFUNCTION */
        WARN_ADM_PLAYOUT_MALFUNCTION = 1020,

        /* enum_warncodetype_WARN_ADM_RECORD_MALFUNCTION */
        WARN_ADM_RECORD_MALFUNCTION = 1021,

        /* enum_warncodetype_WARN_ADM_RECORD_AUDIO_LOWLEVEL */
        WARN_ADM_RECORD_AUDIO_LOWLEVEL = 1031,

        /* enum_warncodetype_WARN_ADM_PLAYOUT_AUDIO_LOWLEVEL */
        WARN_ADM_PLAYOUT_AUDIO_LOWLEVEL = 1032,

        /* enum_warncodetype_WARN_ADM_WINDOWS_NO_DATA_READY_EVENT */
        WARN_ADM_WINDOWS_NO_DATA_READY_EVENT = 1040,

        /* enum_warncodetype_WARN_APM_HOWLING */
        WARN_APM_HOWLING = 1051,

        /* enum_warncodetype_WARN_ADM_GLITCH_STATE */
        WARN_ADM_GLITCH_STATE = 1052,

        /* enum_warncodetype_WARN_ADM_IMPROPER_SETTINGS */
        WARN_ADM_IMPROPER_SETTINGS = 1053,

        /* enum_warncodetype_WARN_ADM_WIN_CORE_NO_RECORDING_DEVICE */
        WARN_ADM_WIN_CORE_NO_RECORDING_DEVICE = 1322,

        /* enum_warncodetype_WARN_ADM_WIN_CORE_NO_PLAYOUT_DEVICE */
        WARN_ADM_WIN_CORE_NO_PLAYOUT_DEVICE = 1323,

        /* enum_warncodetype_WARN_ADM_WIN_CORE_IMPROPER_CAPTURE_RELEASE */
        WARN_ADM_WIN_CORE_IMPROPER_CAPTURE_RELEASE = 1324,
    }

    /* enum_errorcodetype */
    public enum ERROR_CODE_TYPE
    {
        /* enum_errorcodetype_ERR_OK */
        ERR_OK = 0,

        /* enum_errorcodetype_ERR_FAILED */
        ERR_FAILED = 1,

        /* enum_errorcodetype_ERR_INVALID_ARGUMENT */
        ERR_INVALID_ARGUMENT = 2,

        /* enum_errorcodetype_ERR_NOT_READY */
        ERR_NOT_READY = 3,

        /* enum_errorcodetype_ERR_NOT_SUPPORTED */
        ERR_NOT_SUPPORTED = 4,

        /* enum_errorcodetype_ERR_REFUSED */
        ERR_REFUSED = 5,

        /* enum_errorcodetype_ERR_BUFFER_TOO_SMALL */
        ERR_BUFFER_TOO_SMALL = 6,

        /* enum_errorcodetype_ERR_NOT_INITIALIZED */
        ERR_NOT_INITIALIZED = 7,

        /* enum_errorcodetype_ERR_INVALID_STATE */
        ERR_INVALID_STATE = 8,

        /* enum_errorcodetype_ERR_NO_PERMISSION */
        ERR_NO_PERMISSION = 9,

        /* enum_errorcodetype_ERR_TIMEDOUT */
        ERR_TIMEDOUT = 10,

        /* enum_errorcodetype_ERR_CANCELED */
        ERR_CANCELED = 11,

        /* enum_errorcodetype_ERR_TOO_OFTEN */
        ERR_TOO_OFTEN = 12,

        /* enum_errorcodetype_ERR_BIND_SOCKET */
        ERR_BIND_SOCKET = 13,

        /* enum_errorcodetype_ERR_NET_DOWN */
        ERR_NET_DOWN = 14,

        /* enum_errorcodetype_ERR_JOIN_CHANNEL_REJECTED */
        ERR_JOIN_CHANNEL_REJECTED = 17,

        /* enum_errorcodetype_ERR_LEAVE_CHANNEL_REJECTED */
        ERR_LEAVE_CHANNEL_REJECTED = 18,

        /* enum_errorcodetype_ERR_ALREADY_IN_USE */
        ERR_ALREADY_IN_USE = 19,

        /* enum_errorcodetype_ERR_ABORTED */
        ERR_ABORTED = 20,

        /* enum_errorcodetype_ERR_INIT_NET_ENGINE */
        ERR_INIT_NET_ENGINE = 21,

        /* enum_errorcodetype_ERR_RESOURCE_LIMITED */
        ERR_RESOURCE_LIMITED = 22,

        /* enum_errorcodetype_ERR_INVALID_APP_ID */
        ERR_INVALID_APP_ID = 101,

        /* enum_errorcodetype_ERR_INVALID_CHANNEL_NAME */
        ERR_INVALID_CHANNEL_NAME = 102,

        /* enum_errorcodetype_ERR_NO_SERVER_RESOURCES */
        ERR_NO_SERVER_RESOURCES = 103,

        /* enum_errorcodetype_ERR_TOKEN_EXPIRED */
        ERR_TOKEN_EXPIRED = 109,

        /* enum_errorcodetype_ERR_INVALID_TOKEN */
        ERR_INVALID_TOKEN = 110,

        /* enum_errorcodetype_ERR_CONNECTION_INTERRUPTED */
        ERR_CONNECTION_INTERRUPTED = 111,

        /* enum_errorcodetype_ERR_CONNECTION_LOST */
        ERR_CONNECTION_LOST = 112,

        /* enum_errorcodetype_ERR_NOT_IN_CHANNEL */
        ERR_NOT_IN_CHANNEL = 113,

        /* enum_errorcodetype_ERR_SIZE_TOO_LARGE */
        ERR_SIZE_TOO_LARGE = 114,

        /* enum_errorcodetype_ERR_BITRATE_LIMIT */
        ERR_BITRATE_LIMIT = 115,

        /* enum_errorcodetype_ERR_TOO_MANY_DATA_STREAMS */
        ERR_TOO_MANY_DATA_STREAMS = 116,

        /* enum_errorcodetype_ERR_STREAM_MESSAGE_TIMEOUT */
        ERR_STREAM_MESSAGE_TIMEOUT = 117,

        /* enum_errorcodetype_ERR_SET_CLIENT_ROLE_NOT_AUTHORIZED */
        ERR_SET_CLIENT_ROLE_NOT_AUTHORIZED = 119,

        /* enum_errorcodetype_ERR_DECRYPTION_FAILED */
        ERR_DECRYPTION_FAILED = 120,

        /* enum_errorcodetype_ERR_INVALID_USER_ID */
        ERR_INVALID_USER_ID = 121,

        /* enum_errorcodetype_ERR_CLIENT_IS_BANNED_BY_SERVER */
        ERR_CLIENT_IS_BANNED_BY_SERVER = 123,

        /* enum_errorcodetype_ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH */
        ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH = 130,

        /* enum_errorcodetype_ERR_LICENSE_CREDENTIAL_INVALID */
        ERR_LICENSE_CREDENTIAL_INVALID = 131,

        /* enum_errorcodetype_ERR_INVALID_USER_ACCOUNT */
        ERR_INVALID_USER_ACCOUNT = 134,

        /* enum_errorcodetype_ERR_MODULE_NOT_FOUND */
        ERR_MODULE_NOT_FOUND = 157,

        /* enum_errorcodetype_ERR_CERT_RAW */
        ERR_CERT_RAW = 157,

        /* enum_errorcodetype_ERR_CERT_JSON_PART */
        ERR_CERT_JSON_PART = 158,

        /* enum_errorcodetype_ERR_CERT_JSON_INVAL */
        ERR_CERT_JSON_INVAL = 159,

        /* enum_errorcodetype_ERR_CERT_JSON_NOMEM */
        ERR_CERT_JSON_NOMEM = 160,

        /* enum_errorcodetype_ERR_CERT_CUSTOM */
        ERR_CERT_CUSTOM = 161,

        /* enum_errorcodetype_ERR_CERT_CREDENTIAL */
        ERR_CERT_CREDENTIAL = 162,

        /* enum_errorcodetype_ERR_CERT_SIGN */
        ERR_CERT_SIGN = 163,

        /* enum_errorcodetype_ERR_CERT_FAIL */
        ERR_CERT_FAIL = 164,

        /* enum_errorcodetype_ERR_CERT_BUF */
        ERR_CERT_BUF = 165,

        /* enum_errorcodetype_ERR_CERT_NULL */
        ERR_CERT_NULL = 166,

        /* enum_errorcodetype_ERR_CERT_DUEDATE */
        ERR_CERT_DUEDATE = 167,

        /* enum_errorcodetype_ERR_CERT_REQUEST */
        ERR_CERT_REQUEST = 168,

        /* enum_errorcodetype_ERR_PCMSEND_FORMAT */
        ERR_PCMSEND_FORMAT = 200,

        /* enum_errorcodetype_ERR_PCMSEND_BUFFEROVERFLOW */
        ERR_PCMSEND_BUFFEROVERFLOW = 201,

        /* enum_errorcodetype_ERR_LOGIN_ALREADY_LOGIN */
        ERR_LOGIN_ALREADY_LOGIN = 428,

        /* enum_errorcodetype_ERR_LOAD_MEDIA_ENGINE */
        ERR_LOAD_MEDIA_ENGINE = 1001,

        /* enum_errorcodetype_ERR_ADM_GENERAL_ERROR */
        ERR_ADM_GENERAL_ERROR = 1005,

        /* enum_errorcodetype_ERR_ADM_INIT_PLAYOUT */
        ERR_ADM_INIT_PLAYOUT = 1008,

        /* enum_errorcodetype_ERR_ADM_START_PLAYOUT */
        ERR_ADM_START_PLAYOUT = 1009,

        /* enum_errorcodetype_ERR_ADM_STOP_PLAYOUT */
        ERR_ADM_STOP_PLAYOUT = 1010,

        /* enum_errorcodetype_ERR_ADM_INIT_RECORDING */
        ERR_ADM_INIT_RECORDING = 1011,

        /* enum_errorcodetype_ERR_ADM_START_RECORDING */
        ERR_ADM_START_RECORDING = 1012,

        /* enum_errorcodetype_ERR_ADM_STOP_RECORDING */
        ERR_ADM_STOP_RECORDING = 1013,

        /* enum_errorcodetype_ERR_VDM_CAMERA_NOT_AUTHORIZED */
        ERR_VDM_CAMERA_NOT_AUTHORIZED = 1501,
    }

    /* enum_licenseerrortype */
    public enum LICENSE_ERROR_TYPE
    {
        /* enum_licenseerrortype_LICENSE_ERR_INVALID */
        LICENSE_ERR_INVALID = 1,

        /* enum_licenseerrortype_LICENSE_ERR_EXPIRE */
        LICENSE_ERR_EXPIRE = 2,

        /* enum_licenseerrortype_LICENSE_ERR_MINUTES_EXCEED */
        LICENSE_ERR_MINUTES_EXCEED = 3,

        /* enum_licenseerrortype_LICENSE_ERR_LIMITED_PERIOD */
        LICENSE_ERR_LIMITED_PERIOD = 4,

        /* enum_licenseerrortype_LICENSE_ERR_DIFF_DEVICES */
        LICENSE_ERR_DIFF_DEVICES = 5,

        /* enum_licenseerrortype_LICENSE_ERR_INTERNAL */
        LICENSE_ERR_INTERNAL = 99,
    }

    /* enum_audiosessionoperationrestriction */
    public enum AUDIO_SESSION_OPERATION_RESTRICTION
    {
        /* enum_audiosessionoperationrestriction_AUDIO_SESSION_OPERATION_RESTRICTION_NONE */
        AUDIO_SESSION_OPERATION_RESTRICTION_NONE = 0,

        /* enum_audiosessionoperationrestriction_AUDIO_SESSION_OPERATION_RESTRICTION_SET_CATEGORY */
        AUDIO_SESSION_OPERATION_RESTRICTION_SET_CATEGORY = 1,

        /* enum_audiosessionoperationrestriction_AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION */
        AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION = 1 << 1,

        /* enum_audiosessionoperationrestriction_AUDIO_SESSION_OPERATION_RESTRICTION_DEACTIVATE_SESSION */
        AUDIO_SESSION_OPERATION_RESTRICTION_DEACTIVATE_SESSION = 1 << 2,

        /* enum_audiosessionoperationrestriction_AUDIO_SESSION_OPERATION_RESTRICTION_ALL */
        AUDIO_SESSION_OPERATION_RESTRICTION_ALL = 1 << 7,
    }

    /* enum_userofflinereasontype */
    public enum USER_OFFLINE_REASON_TYPE
    {
        /* enum_userofflinereasontype_USER_OFFLINE_QUIT */
        USER_OFFLINE_QUIT = 0,

        /* enum_userofflinereasontype_USER_OFFLINE_DROPPED */
        USER_OFFLINE_DROPPED = 1,

        /* enum_userofflinereasontype_USER_OFFLINE_BECOME_AUDIENCE */
        USER_OFFLINE_BECOME_AUDIENCE = 2,
    }

    /* enum_interfaceidtype */
    public enum INTERFACE_ID_TYPE
    {
        /* enum_interfaceidtype_AGORA_IID_AUDIO_DEVICE_MANAGER */
        AGORA_IID_AUDIO_DEVICE_MANAGER = 1,

        /* enum_interfaceidtype_AGORA_IID_VIDEO_DEVICE_MANAGER */
        AGORA_IID_VIDEO_DEVICE_MANAGER = 2,

        /* enum_interfaceidtype_AGORA_IID_PARAMETER_ENGINE */
        AGORA_IID_PARAMETER_ENGINE = 3,

        /* enum_interfaceidtype_AGORA_IID_MEDIA_ENGINE */
        AGORA_IID_MEDIA_ENGINE = 4,

        /* enum_interfaceidtype_AGORA_IID_AUDIO_ENGINE */
        AGORA_IID_AUDIO_ENGINE = 5,

        /* enum_interfaceidtype_AGORA_IID_VIDEO_ENGINE */
        AGORA_IID_VIDEO_ENGINE = 6,

        /* enum_interfaceidtype_AGORA_IID_RTC_CONNECTION */
        AGORA_IID_RTC_CONNECTION = 7,

        /* enum_interfaceidtype_AGORA_IID_SIGNALING_ENGINE */
        AGORA_IID_SIGNALING_ENGINE = 8,

        /* enum_interfaceidtype_AGORA_IID_MEDIA_ENGINE_REGULATOR */
        AGORA_IID_MEDIA_ENGINE_REGULATOR = 9,

        /* enum_interfaceidtype_AGORA_IID_CLOUD_SPATIAL_AUDIO */
        AGORA_IID_CLOUD_SPATIAL_AUDIO = 10,

        /* enum_interfaceidtype_AGORA_IID_LOCAL_SPATIAL_AUDIO */
        AGORA_IID_LOCAL_SPATIAL_AUDIO = 11,

        /* enum_interfaceidtype_AGORA_IID_STATE_SYNC */
        AGORA_IID_STATE_SYNC = 13,

        /* enum_interfaceidtype_AGORA_IID_METACHAT_SERVICE */
        AGORA_IID_METACHAT_SERVICE = 14,

        /* enum_interfaceidtype_AGORA_IID_MUSIC_CONTENT_CENTER */
        AGORA_IID_MUSIC_CONTENT_CENTER = 15,

        /* enum_interfaceidtype_AGORA_IID_H265_TRANSCODER */
        AGORA_IID_H265_TRANSCODER = 16,
    }

    /* enum_qualitytype */
    public enum QUALITY_TYPE
    {
        /* enum_qualitytype_QUALITY_UNKNOWN */
        QUALITY_UNKNOWN = 0,

        /* enum_qualitytype_QUALITY_EXCELLENT */
        QUALITY_EXCELLENT = 1,

        /* enum_qualitytype_QUALITY_GOOD */
        QUALITY_GOOD = 2,

        /* enum_qualitytype_QUALITY_POOR */
        QUALITY_POOR = 3,

        /* enum_qualitytype_QUALITY_BAD */
        QUALITY_BAD = 4,

        /* enum_qualitytype_QUALITY_VBAD */
        QUALITY_VBAD = 5,

        /* enum_qualitytype_QUALITY_DOWN */
        QUALITY_DOWN = 6,

        /* enum_qualitytype_QUALITY_UNSUPPORTED */
        QUALITY_UNSUPPORTED = 7,

        /* enum_qualitytype_QUALITY_DETECTING */
        QUALITY_DETECTING = 8,
    }

    /* enum_fitmodetype */
    public enum FIT_MODE_TYPE
    {
        /* enum_fitmodetype_MODE_COVER */
        MODE_COVER = 1,

        /* enum_fitmodetype_MODE_CONTAIN */
        MODE_CONTAIN = 2,
    }

    /* enum_videoorientation */
    public enum VIDEO_ORIENTATION
    {
        /* enum_videoorientation_VIDEO_ORIENTATION_0 */
        VIDEO_ORIENTATION_0 = 0,

        /* enum_videoorientation_VIDEO_ORIENTATION_90 */
        VIDEO_ORIENTATION_90 = 90,

        /* enum_videoorientation_VIDEO_ORIENTATION_180 */
        VIDEO_ORIENTATION_180 = 180,

        /* enum_videoorientation_VIDEO_ORIENTATION_270 */
        VIDEO_ORIENTATION_270 = 270,
    }

    /* enum_framerate */
    public enum FRAME_RATE
    {
        /* enum_framerate_FRAME_RATE_FPS_1 */
        FRAME_RATE_FPS_1 = 1,

        /* enum_framerate_FRAME_RATE_FPS_7 */
        FRAME_RATE_FPS_7 = 7,

        /* enum_framerate_FRAME_RATE_FPS_10 */
        FRAME_RATE_FPS_10 = 10,

        /* enum_framerate_FRAME_RATE_FPS_15 */
        FRAME_RATE_FPS_15 = 15,

        /* enum_framerate_FRAME_RATE_FPS_24 */
        FRAME_RATE_FPS_24 = 24,

        /* enum_framerate_FRAME_RATE_FPS_30 */
        FRAME_RATE_FPS_30 = 30,

        /* enum_framerate_FRAME_RATE_FPS_60 */
        FRAME_RATE_FPS_60 = 60,
    }

    /* enum_framewidth */
    public enum FRAME_WIDTH
    {
        /* enum_framewidth_FRAME_WIDTH_960 */
        FRAME_WIDTH_960 = 960,
    }

    /* enum_frameheight */
    public enum FRAME_HEIGHT
    {
        /* enum_frameheight_FRAME_HEIGHT_540 */
        FRAME_HEIGHT_540 = 540,
    }

    /* enum_videoframetype */
    public enum VIDEO_FRAME_TYPE
    {
        /* enum_videoframetype_VIDEO_FRAME_TYPE_BLANK_FRAME */
        VIDEO_FRAME_TYPE_BLANK_FRAME = 0,

        /* enum_videoframetype_VIDEO_FRAME_TYPE_KEY_FRAME */
        VIDEO_FRAME_TYPE_KEY_FRAME = 3,

        /* enum_videoframetype_VIDEO_FRAME_TYPE_DELTA_FRAME */
        VIDEO_FRAME_TYPE_DELTA_FRAME = 4,

        /* enum_videoframetype_VIDEO_FRAME_TYPE_B_FRAME */
        VIDEO_FRAME_TYPE_B_FRAME = 5,

        /* enum_videoframetype_VIDEO_FRAME_TYPE_DROPPABLE_FRAME */
        VIDEO_FRAME_TYPE_DROPPABLE_FRAME = 6,

        /* enum_videoframetype_VIDEO_FRAME_TYPE_UNKNOW */
        VIDEO_FRAME_TYPE_UNKNOW,
    }

    /* enum_orientationmode */
    public enum ORIENTATION_MODE
    {
        /* enum_orientationmode_ORIENTATION_MODE_ADAPTIVE */
        ORIENTATION_MODE_ADAPTIVE = 0,

        /* enum_orientationmode_ORIENTATION_MODE_FIXED_LANDSCAPE */
        ORIENTATION_MODE_FIXED_LANDSCAPE = 1,

        /* enum_orientationmode_ORIENTATION_MODE_FIXED_PORTRAIT */
        ORIENTATION_MODE_FIXED_PORTRAIT = 2,
    }

    /* enum_degradationpreference */
    public enum DEGRADATION_PREFERENCE
    {
        /* enum_degradationpreference_MAINTAIN_QUALITY */
        MAINTAIN_QUALITY = 0,

        /* enum_degradationpreference_MAINTAIN_FRAMERATE */
        MAINTAIN_FRAMERATE = 1,

        /* enum_degradationpreference_MAINTAIN_BALANCED */
        MAINTAIN_BALANCED = 2,

        /* enum_degradationpreference_MAINTAIN_RESOLUTION */
        MAINTAIN_RESOLUTION = 3,

        /* enum_degradationpreference_DISABLED */
        DISABLED = 100,
    }

    /* class_videodimensions */
    public class VideoDimensions
    {
        /* class_videodimensions_width */
        public int width;

        /* class_videodimensions_height */
        public int height;

        public VideoDimensions()
        {
            this.width = 640;
            this.height = 480;
        }

        public VideoDimensions(int w, int h)
        {
            this.width = w;
            this.height = h;
        }
    }

    /* enum_screencaptureframeratecapability */
    public enum SCREEN_CAPTURE_FRAMERATE_CAPABILITY
    {
        /* enum_screencaptureframeratecapability_SCREEN_CAPTURE_FRAMERATE_CAPABILITY_15_FPS */
        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_15_FPS = 0,

        /* enum_screencaptureframeratecapability_SCREEN_CAPTURE_FRAMERATE_CAPABILITY_30_FPS */
        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_30_FPS = 1,

        /* enum_screencaptureframeratecapability_SCREEN_CAPTURE_FRAMERATE_CAPABILITY_60_FPS */
        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_60_FPS = 2,
    }

    /* enum_videocodeccapabilitylevel */
    public enum VIDEO_CODEC_CAPABILITY_LEVEL
    {
        /* enum_videocodeccapabilitylevel_CODEC_CAPABILITY_LEVEL_UNSPECIFIED */
        CODEC_CAPABILITY_LEVEL_UNSPECIFIED = -1,

        /* enum_videocodeccapabilitylevel_CODEC_CAPABILITY_LEVEL_BASIC_SUPPORT */
        CODEC_CAPABILITY_LEVEL_BASIC_SUPPORT = 5,

        /* enum_videocodeccapabilitylevel_CODEC_CAPABILITY_LEVEL_1080P30FPS */
        CODEC_CAPABILITY_LEVEL_1080P30FPS = 10,

        /* enum_videocodeccapabilitylevel_CODEC_CAPABILITY_LEVEL_1080P60FPS */
        CODEC_CAPABILITY_LEVEL_1080P60FPS = 20,

        /* enum_videocodeccapabilitylevel_CODEC_CAPABILITY_LEVEL_4K60FPS */
        CODEC_CAPABILITY_LEVEL_4K60FPS = 30,
    }

    /* enum_videocodectype */
    public enum VIDEO_CODEC_TYPE
    {
        /* enum_videocodectype_VIDEO_CODEC_NONE */
        VIDEO_CODEC_NONE = 0,

        /* enum_videocodectype_VIDEO_CODEC_VP8 */
        VIDEO_CODEC_VP8 = 1,

        /* enum_videocodectype_VIDEO_CODEC_H264 */
        VIDEO_CODEC_H264 = 2,

        /* enum_videocodectype_VIDEO_CODEC_H265 */
        VIDEO_CODEC_H265 = 3,

        /* enum_videocodectype_VIDEO_CODEC_GENERIC */
        VIDEO_CODEC_GENERIC = 6,

        /* enum_videocodectype_VIDEO_CODEC_GENERIC_H264 */
        VIDEO_CODEC_GENERIC_H264 = 7,

        /* enum_videocodectype_VIDEO_CODEC_AV1 */
        VIDEO_CODEC_AV1 = 12,

        /* enum_videocodectype_VIDEO_CODEC_VP9 */
        VIDEO_CODEC_VP9 = 13,

        /* enum_videocodectype_VIDEO_CODEC_GENERIC_JPEG */
        VIDEO_CODEC_GENERIC_JPEG = 20,
    }

    /* enum_tccmode */
    public enum TCcMode
    {
        /* enum_tccmode_CC_ENABLED */
        CC_ENABLED,

        /* enum_tccmode_CC_DISABLED */
        CC_DISABLED,
    }

    /* class_senderoptions */
    public class SenderOptions
    {
        /* class_senderoptions_ccMode */
        public TCcMode ccMode;

        /* class_senderoptions_codecType */
        public VIDEO_CODEC_TYPE codecType;

        /* class_senderoptions_targetBitrate */
        public int targetBitrate;

        public SenderOptions()
        {
            this.ccMode = TCcMode.CC_ENABLED;
            this.codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            this.targetBitrate = 6500;
        }

        public SenderOptions(TCcMode ccMode, VIDEO_CODEC_TYPE codecType, int targetBitrate)
        {
            this.ccMode = ccMode;
            this.codecType = codecType;
            this.targetBitrate = targetBitrate;
        }
    }

    /* enum_audiocodectype */
    public enum AUDIO_CODEC_TYPE
    {
        /* enum_audiocodectype_AUDIO_CODEC_OPUS */
        AUDIO_CODEC_OPUS = 1,

        /* enum_audiocodectype_AUDIO_CODEC_PCMA */
        AUDIO_CODEC_PCMA = 3,

        /* enum_audiocodectype_AUDIO_CODEC_PCMU */
        AUDIO_CODEC_PCMU = 4,

        /* enum_audiocodectype_AUDIO_CODEC_G722 */
        AUDIO_CODEC_G722 = 5,

        /* enum_audiocodectype_AUDIO_CODEC_AACLC */
        AUDIO_CODEC_AACLC = 8,

        /* enum_audiocodectype_AUDIO_CODEC_HEAAC */
        AUDIO_CODEC_HEAAC = 9,

        /* enum_audiocodectype_AUDIO_CODEC_JC1 */
        AUDIO_CODEC_JC1 = 10,

        /* enum_audiocodectype_AUDIO_CODEC_HEAAC2 */
        AUDIO_CODEC_HEAAC2 = 11,

        /* enum_audiocodectype_AUDIO_CODEC_LPCNET */
        AUDIO_CODEC_LPCNET = 12,
    }

    /* enum_audioencodingtype */
    public enum AUDIO_ENCODING_TYPE
    {
        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_AAC_16000_LOW */
        AUDIO_ENCODING_TYPE_AAC_16000_LOW = 0x010101,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_AAC_16000_MEDIUM */
        AUDIO_ENCODING_TYPE_AAC_16000_MEDIUM = 0x010102,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_AAC_32000_LOW */
        AUDIO_ENCODING_TYPE_AAC_32000_LOW = 0x010201,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_AAC_32000_MEDIUM */
        AUDIO_ENCODING_TYPE_AAC_32000_MEDIUM = 0x010202,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_AAC_32000_HIGH */
        AUDIO_ENCODING_TYPE_AAC_32000_HIGH = 0x010203,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_AAC_48000_MEDIUM */
        AUDIO_ENCODING_TYPE_AAC_48000_MEDIUM = 0x010302,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_AAC_48000_HIGH */
        AUDIO_ENCODING_TYPE_AAC_48000_HIGH = 0x010303,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_OPUS_16000_LOW */
        AUDIO_ENCODING_TYPE_OPUS_16000_LOW = 0x020101,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_OPUS_16000_MEDIUM */
        AUDIO_ENCODING_TYPE_OPUS_16000_MEDIUM = 0x020102,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_OPUS_48000_MEDIUM */
        AUDIO_ENCODING_TYPE_OPUS_48000_MEDIUM = 0x020302,

        /* enum_audioencodingtype_AUDIO_ENCODING_TYPE_OPUS_48000_HIGH */
        AUDIO_ENCODING_TYPE_OPUS_48000_HIGH = 0x020303,
    }

    /* enum_watermarkfitmode */
    public enum WATERMARK_FIT_MODE
    {
        /* enum_watermarkfitmode_FIT_MODE_COVER_POSITION */
        FIT_MODE_COVER_POSITION,

        /* enum_watermarkfitmode_FIT_MODE_USE_IMAGE_RATIO */
        FIT_MODE_USE_IMAGE_RATIO,
    }

    /* class_encodedaudioframeadvancedsettings */
    public class EncodedAudioFrameAdvancedSettings
    {
        /* class_encodedaudioframeadvancedsettings_speech */
        public bool speech;

        /* class_encodedaudioframeadvancedsettings_sendEvenIfEmpty */
        public bool sendEvenIfEmpty;

        public EncodedAudioFrameAdvancedSettings()
        {
            this.speech = true;
            this.sendEvenIfEmpty = true;
        }

        public EncodedAudioFrameAdvancedSettings(bool speech, bool sendEvenIfEmpty)
        {
            this.speech = speech;
            this.sendEvenIfEmpty = sendEvenIfEmpty;
        }
    }

    /* class_encodedaudioframeinfo */
    public class EncodedAudioFrameInfo
    {
        /* class_encodedaudioframeinfo_codec */
        public AUDIO_CODEC_TYPE codec;

        /* class_encodedaudioframeinfo_sampleRateHz */
        public int sampleRateHz;

        /* class_encodedaudioframeinfo_samplesPerChannel */
        public int samplesPerChannel;

        /* class_encodedaudioframeinfo_numberOfChannels */
        public int numberOfChannels;

        /* class_encodedaudioframeinfo_advancedSettings */
        public EncodedAudioFrameAdvancedSettings advancedSettings;

        /* class_encodedaudioframeinfo_captureTimeMs */
        public long captureTimeMs;

        public EncodedAudioFrameInfo()
        {
            this.codec = AUDIO_CODEC_TYPE.AUDIO_CODEC_AACLC;
            this.sampleRateHz = 0;
            this.samplesPerChannel = 0;
            this.numberOfChannels = 0;
            this.captureTimeMs = 0;
        }

        public EncodedAudioFrameInfo(EncodedAudioFrameInfo rhs)
        {
            this.codec = rhs.codec;
            this.sampleRateHz = rhs.sampleRateHz;
            this.samplesPerChannel = rhs.samplesPerChannel;
            this.numberOfChannels = rhs.numberOfChannels;
            this.advancedSettings = rhs.advancedSettings;
            this.captureTimeMs = rhs.captureTimeMs;
        }

        public EncodedAudioFrameInfo(AUDIO_CODEC_TYPE codec, int sampleRateHz, int samplesPerChannel, int numberOfChannels, EncodedAudioFrameAdvancedSettings advancedSettings, long captureTimeMs)
        {
            this.codec = codec;
            this.sampleRateHz = sampleRateHz;
            this.samplesPerChannel = samplesPerChannel;
            this.numberOfChannels = numberOfChannels;
            this.advancedSettings = advancedSettings;
            this.captureTimeMs = captureTimeMs;
        }
    }

    /* class_audiopcmdatainfo */
    public class AudioPcmDataInfo
    {
        /* class_audiopcmdatainfo_samplesPerChannel */
        public ulong samplesPerChannel;

        /* class_audiopcmdatainfo_channelNum */
        public short channelNum;

        /* class_audiopcmdatainfo_samplesOut */
        public ulong samplesOut;

        /* class_audiopcmdatainfo_elapsedTimeMs */
        public long elapsedTimeMs;

        /* class_audiopcmdatainfo_ntpTimeMs */
        public long ntpTimeMs;

        public AudioPcmDataInfo()
        {
            this.samplesPerChannel = 0;
            this.channelNum = 0;
            this.samplesOut = 0;
            this.elapsedTimeMs = 0;
            this.ntpTimeMs = 0;
        }

        public AudioPcmDataInfo(AudioPcmDataInfo rhs)
        {
            this.samplesPerChannel = rhs.samplesPerChannel;
            this.channelNum = rhs.channelNum;
            this.samplesOut = rhs.samplesOut;
            this.elapsedTimeMs = rhs.elapsedTimeMs;
            this.ntpTimeMs = rhs.ntpTimeMs;
        }

        public AudioPcmDataInfo(ulong samplesPerChannel, short channelNum, ulong samplesOut, long elapsedTimeMs, long ntpTimeMs)
        {
            this.samplesPerChannel = samplesPerChannel;
            this.channelNum = channelNum;
            this.samplesOut = samplesOut;
            this.elapsedTimeMs = elapsedTimeMs;
            this.ntpTimeMs = ntpTimeMs;
        }
    }

    /* enum_h264packetizemode */
    public enum H264PacketizeMode
    {
        /* enum_h264packetizemode_NonInterleaved */
        NonInterleaved = 0,

        /* enum_h264packetizemode_SingleNalUnit */
        SingleNalUnit,
    }

    /* enum_videostreamtype */
    public enum VIDEO_STREAM_TYPE
    {
        /* enum_videostreamtype_VIDEO_STREAM_HIGH */
        VIDEO_STREAM_HIGH = 0,

        /* enum_videostreamtype_VIDEO_STREAM_LOW */
        VIDEO_STREAM_LOW = 1,
    }

    /* class_videosubscriptionoptions */
    public class VideoSubscriptionOptions : OptionalJsonParse
    {
        /* class_videosubscriptionoptions_type */
        public Optional<VIDEO_STREAM_TYPE> type = new Optional<VIDEO_STREAM_TYPE>();

        /* class_videosubscriptionoptions_encodedFrameOnly */
        public Optional<bool> encodedFrameOnly = new Optional<bool>();

        public VideoSubscriptionOptions()
        {
        }

        public VideoSubscriptionOptions(Optional<VIDEO_STREAM_TYPE> type, Optional<bool> encodedFrameOnly)
        {
            this.type = type;
            this.encodedFrameOnly = encodedFrameOnly;
        }

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.type.HasValue())
            {
                writer.WritePropertyName("type");
                this.WriteEnum(writer, this.type.GetValue());
            }

            if (this.encodedFrameOnly.HasValue())
            {
                writer.WritePropertyName("encodedFrameOnly");
                writer.Write(this.encodedFrameOnly.GetValue());
            }

            writer.WriteObjectEnd();
        }
    }

    /* class_encodedvideoframeinfo */
    public class EncodedVideoFrameInfo
    {
        /* class_encodedvideoframeinfo_codecType */
        public VIDEO_CODEC_TYPE codecType;

        /* class_encodedvideoframeinfo_width */
        public int width;

        /* class_encodedvideoframeinfo_height */
        public int height;

        /* class_encodedvideoframeinfo_framesPerSecond */
        public int framesPerSecond;

        /* class_encodedvideoframeinfo_frameType */
        public VIDEO_FRAME_TYPE frameType;

        /* class_encodedvideoframeinfo_rotation */
        public VIDEO_ORIENTATION rotation;

        /* class_encodedvideoframeinfo_trackId */
        public int trackId;

        /* class_encodedvideoframeinfo_captureTimeMs */
        public long captureTimeMs;

        /* class_encodedvideoframeinfo_decodeTimeMs */
        public long decodeTimeMs;

        /* class_encodedvideoframeinfo_uid */
        public uint uid;

        /* class_encodedvideoframeinfo_streamType */
        public VIDEO_STREAM_TYPE streamType;

        public EncodedVideoFrameInfo()
        {
            this.codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            this.width = 0;
            this.height = 0;
            this.framesPerSecond = 0;
            this.frameType = VIDEO_FRAME_TYPE.VIDEO_FRAME_TYPE_BLANK_FRAME;
            this.rotation = VIDEO_ORIENTATION.VIDEO_ORIENTATION_0;
            this.trackId = 0;
            this.captureTimeMs = 0;
            this.decodeTimeMs = 0;
            this.uid = 0;
            this.streamType = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
        }

        public EncodedVideoFrameInfo(EncodedVideoFrameInfo rhs)
        {
            this.codecType = rhs.codecType;
            this.width = rhs.width;
            this.height = rhs.height;
            this.framesPerSecond = rhs.framesPerSecond;
            this.frameType = rhs.frameType;
            this.rotation = rhs.rotation;
            this.trackId = rhs.trackId;
            this.captureTimeMs = rhs.captureTimeMs;
            this.decodeTimeMs = rhs.decodeTimeMs;
            this.uid = rhs.uid;
            this.streamType = rhs.streamType;
        }

        public EncodedVideoFrameInfo(VIDEO_CODEC_TYPE codecType, int width, int height, int framesPerSecond, VIDEO_FRAME_TYPE frameType, VIDEO_ORIENTATION rotation, int trackId, long captureTimeMs, long decodeTimeMs, uint uid, VIDEO_STREAM_TYPE streamType)
        {
            this.codecType = codecType;
            this.width = width;
            this.height = height;
            this.framesPerSecond = framesPerSecond;
            this.frameType = frameType;
            this.rotation = rotation;
            this.trackId = trackId;
            this.captureTimeMs = captureTimeMs;
            this.decodeTimeMs = decodeTimeMs;
            this.uid = uid;
            this.streamType = streamType;
        }
    }

    /* enum_compressionpreference */
    public enum COMPRESSION_PREFERENCE
    {
        /* enum_compressionpreference_PREFER_LOW_LATENCY */
        PREFER_LOW_LATENCY,

        /* enum_compressionpreference_PREFER_QUALITY */
        PREFER_QUALITY,
    }

    /* enum_encodingpreference */
    public enum ENCODING_PREFERENCE
    {
        /* enum_encodingpreference_PREFER_AUTO */
        PREFER_AUTO = -1,

        /* enum_encodingpreference_PREFER_SOFTWARE */
        PREFER_SOFTWARE = 0,

        /* enum_encodingpreference_PREFER_HARDWARE */
        PREFER_HARDWARE = 1,
    }

    /* class_advanceoptions */
    public class AdvanceOptions
    {
        /* class_advanceoptions_encodingPreference */
        public ENCODING_PREFERENCE encodingPreference;

        /* class_advanceoptions_compressionPreference */
        public COMPRESSION_PREFERENCE compressionPreference;

        public AdvanceOptions()
        {
            this.encodingPreference = ENCODING_PREFERENCE.PREFER_AUTO;
            this.compressionPreference = COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY;
        }

        public AdvanceOptions(ENCODING_PREFERENCE encoding_preference, COMPRESSION_PREFERENCE compression_preference)
        {
            this.encodingPreference = encoding_preference;
            this.compressionPreference = compression_preference;
        }
    }

    /* enum_videomirrormodetype */
    public enum VIDEO_MIRROR_MODE_TYPE
    {
        /* enum_videomirrormodetype_VIDEO_MIRROR_MODE_AUTO */
        VIDEO_MIRROR_MODE_AUTO = 0,

        /* enum_videomirrormodetype_VIDEO_MIRROR_MODE_ENABLED */
        VIDEO_MIRROR_MODE_ENABLED = 1,

        /* enum_videomirrormodetype_VIDEO_MIRROR_MODE_DISABLED */
        VIDEO_MIRROR_MODE_DISABLED = 2,
    }

    /* enum_codeccapmask */
    public enum CODEC_CAP_MASK
    {
        /* enum_codeccapmask_CODEC_CAP_MASK_NONE */
        CODEC_CAP_MASK_NONE = 0,

        /* enum_codeccapmask_CODEC_CAP_MASK_HW_DEC */
        CODEC_CAP_MASK_HW_DEC = 1 << 0,

        /* enum_codeccapmask_CODEC_CAP_MASK_HW_ENC */
        CODEC_CAP_MASK_HW_ENC = 1 << 1,

        /* enum_codeccapmask_CODEC_CAP_MASK_SW_DEC */
        CODEC_CAP_MASK_SW_DEC = 1 << 2,

        /* enum_codeccapmask_CODEC_CAP_MASK_SW_ENC */
        CODEC_CAP_MASK_SW_ENC = 1 << 3,
    }

    /* class_codeccaplevels */
    public class CodecCapLevels
    {
        /* class_codeccaplevels_hwDecodingLevel */
        public VIDEO_CODEC_CAPABILITY_LEVEL hwDecodingLevel;

        /* class_codeccaplevels_swDecodingLevel */
        public VIDEO_CODEC_CAPABILITY_LEVEL swDecodingLevel;

        public CodecCapLevels()
        {
            this.hwDecodingLevel = VIDEO_CODEC_CAPABILITY_LEVEL.CODEC_CAPABILITY_LEVEL_UNSPECIFIED;
            this.swDecodingLevel = VIDEO_CODEC_CAPABILITY_LEVEL.CODEC_CAPABILITY_LEVEL_UNSPECIFIED;
        }

        public CodecCapLevels(VIDEO_CODEC_CAPABILITY_LEVEL hwDecodingLevel, VIDEO_CODEC_CAPABILITY_LEVEL swDecodingLevel)
        {
            this.hwDecodingLevel = hwDecodingLevel;
            this.swDecodingLevel = swDecodingLevel;
        }
    }

    /* class_codeccapinfo */
    public class CodecCapInfo
    {
        /* class_codeccapinfo_codecType */
        public VIDEO_CODEC_TYPE codecType;

        /* class_codeccapinfo_codecCapMask */
        public int codecCapMask;

        /* class_codeccapinfo_codecLevels */
        public CodecCapLevels codecLevels;

        public CodecCapInfo(VIDEO_CODEC_TYPE codecType, int codecCapMask, CodecCapLevels codecLevels)
        {
            this.codecType = codecType;
            this.codecCapMask = codecCapMask;
            this.codecLevels = codecLevels;
        }
        public CodecCapInfo()
        {
        }
    }

    /* class_videoencoderconfiguration */
    public class VideoEncoderConfiguration
    {
        /* class_videoencoderconfiguration_codecType */
        public VIDEO_CODEC_TYPE codecType;

        /* class_videoencoderconfiguration_dimensions */
        public VideoDimensions dimensions;

        /* class_videoencoderconfiguration_frameRate */
        public int frameRate;

        /* class_videoencoderconfiguration_bitrate */
        public int bitrate;

        /* class_videoencoderconfiguration_minBitrate */
        public int minBitrate;

        /* class_videoencoderconfiguration_orientationMode */
        public ORIENTATION_MODE orientationMode;

        /* class_videoencoderconfiguration_degradationPreference */
        public DEGRADATION_PREFERENCE degradationPreference;

        /* class_videoencoderconfiguration_mirrorMode */
        public VIDEO_MIRROR_MODE_TYPE mirrorMode;

        /* class_videoencoderconfiguration_advanceOptions */
        public AdvanceOptions advanceOptions;

        public VideoEncoderConfiguration(VideoDimensions d, int f, int b, ORIENTATION_MODE m, VIDEO_MIRROR_MODE_TYPE mirror = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED)
        {
            this.codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            this.dimensions = d;
            this.frameRate = f;
            this.bitrate = b;
            this.minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            this.orientationMode = m;
            this.degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            this.mirrorMode = mirror;
            this.advanceOptions = new AdvanceOptions(ENCODING_PREFERENCE.PREFER_AUTO, COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY);
        }

        public VideoEncoderConfiguration(int width, int height, int f, int b, ORIENTATION_MODE m, VIDEO_MIRROR_MODE_TYPE mirror = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED)
        {
            this.codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            this.dimensions = new VideoDimensions(width, height);
            this.frameRate = f;
            this.bitrate = b;
            this.minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            this.orientationMode = m;
            this.degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            this.mirrorMode = mirror;
            this.advanceOptions = new AdvanceOptions(ENCODING_PREFERENCE.PREFER_AUTO, COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY);
        }

        public VideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            this.codecType = config.codecType;
            this.dimensions = config.dimensions;
            this.frameRate = config.frameRate;
            this.bitrate = config.bitrate;
            this.minBitrate = config.minBitrate;
            this.orientationMode = config.orientationMode;
            this.degradationPreference = config.degradationPreference;
            this.mirrorMode = config.mirrorMode;
            this.advanceOptions = config.advanceOptions;
        }

        public VideoEncoderConfiguration()
        {
            this.codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            this.dimensions = new VideoDimensions((int)FRAME_WIDTH.FRAME_WIDTH_960, (int)FRAME_HEIGHT.FRAME_HEIGHT_540);
            this.frameRate = (int)FRAME_RATE.FRAME_RATE_FPS_15;
            this.bitrate = (int)BITRATE.STANDARD_BITRATE;
            this.minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            this.orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE;
            this.degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            this.mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED;
            this.advanceOptions = new AdvanceOptions(ENCODING_PREFERENCE.PREFER_AUTO, COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY);
        }

        public VideoEncoderConfiguration(VIDEO_CODEC_TYPE codecType, VideoDimensions dimensions, int frameRate, int bitrate, int minBitrate, ORIENTATION_MODE orientationMode, DEGRADATION_PREFERENCE degradationPreference, VIDEO_MIRROR_MODE_TYPE mirrorMode, AdvanceOptions advanceOptions)
        {
            this.codecType = codecType;
            this.dimensions = dimensions;
            this.frameRate = frameRate;
            this.bitrate = bitrate;
            this.minBitrate = minBitrate;
            this.orientationMode = orientationMode;
            this.degradationPreference = degradationPreference;
            this.mirrorMode = mirrorMode;
            this.advanceOptions = advanceOptions;
        }
    }

    /* class_datastreamconfig */
    public class DataStreamConfig
    {
        /* class_datastreamconfig_syncWithAudio */
        public bool syncWithAudio;

        /* class_datastreamconfig_ordered */
        public bool ordered;

        public DataStreamConfig(bool syncWithAudio, bool ordered)
        {
            this.syncWithAudio = syncWithAudio;
            this.ordered = ordered;
        }
        public DataStreamConfig()
        {
        }
    }

    /* enum_simulcaststreammode */
    public enum SIMULCAST_STREAM_MODE
    {
        /* enum_simulcaststreammode_AUTO_SIMULCAST_STREAM */
        AUTO_SIMULCAST_STREAM = -1,

        /* enum_simulcaststreammode_DISABLE_SIMULCAST_STREAM */
        DISABLE_SIMULCAST_STREAM = 0,

        /* enum_simulcaststreammode_ENABLE_SIMULCAST_STREAM */
        ENABLE_SIMULCAST_STREAM = 1,
    }

    /* class_simulcaststreamconfig */
    public class SimulcastStreamConfig
    {
        /* class_simulcaststreamconfig_dimensions */
        public VideoDimensions dimensions;

        /* class_simulcaststreamconfig_kBitrate */
        public int kBitrate;

        /* class_simulcaststreamconfig_framerate */
        public int framerate;

        public SimulcastStreamConfig()
        {
            this.dimensions = new VideoDimensions(160, 120);
            this.kBitrate = 65;
            this.framerate = 5;
        }

        public SimulcastStreamConfig(VideoDimensions dimensions, int kBitrate, int framerate)
        {
            this.dimensions = dimensions;
            this.kBitrate = kBitrate;
            this.framerate = framerate;
        }
    }

    /* class_rectangle */
    public class Rectangle
    {
        /* class_rectangle_x */
        public int x;

        /* class_rectangle_y */
        public int y;

        /* class_rectangle_width */
        public int width;

        /* class_rectangle_height */
        public int height;

        public Rectangle()
        {
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
        }

        public Rectangle(int xx, int yy, int ww, int hh)
        {
            this.x = xx;
            this.y = yy;
            this.width = ww;
            this.height = hh;
        }
    }

    /* class_watermarkratio */
    public class WatermarkRatio
    {
        /* class_watermarkratio_xRatio */
        public float xRatio;

        /* class_watermarkratio_yRatio */
        public float yRatio;

        /* class_watermarkratio_widthRatio */
        public float widthRatio;

        public WatermarkRatio()
        {
            this.xRatio = 0.0f;
            this.yRatio = 0.0f;
            this.widthRatio = 0.0f;
        }

        public WatermarkRatio(float x, float y, float width)
        {
            this.xRatio = x;
            this.yRatio = y;
            this.widthRatio = width;
        }
    }

    /* class_watermarkoptions */
    public class WatermarkOptions
    {
        /* class_watermarkoptions_visibleInPreview */
        public bool visibleInPreview;

        /* class_watermarkoptions_positionInLandscapeMode */
        public Rectangle positionInLandscapeMode;

        /* class_watermarkoptions_positionInPortraitMode */
        public Rectangle positionInPortraitMode;

        /* class_watermarkoptions_watermarkRatio */
        public WatermarkRatio watermarkRatio;

        /* class_watermarkoptions_mode */
        public WATERMARK_FIT_MODE mode;

        public WatermarkOptions()
        {
            this.visibleInPreview = true;
            this.positionInLandscapeMode = new Rectangle(0, 0, 0, 0);
            this.positionInPortraitMode = new Rectangle(0, 0, 0, 0);
            this.mode = WATERMARK_FIT_MODE.FIT_MODE_COVER_POSITION;
        }

        public WatermarkOptions(bool visibleInPreview, Rectangle positionInLandscapeMode, Rectangle positionInPortraitMode, WatermarkRatio watermarkRatio, WATERMARK_FIT_MODE mode)
        {
            this.visibleInPreview = visibleInPreview;
            this.positionInLandscapeMode = positionInLandscapeMode;
            this.positionInPortraitMode = positionInPortraitMode;
            this.watermarkRatio = watermarkRatio;
            this.mode = mode;
        }
    }

    /* class_rtcstats */
    public class RtcStats
    {
        /* class_rtcstats_duration */
        public uint duration;

        /* class_rtcstats_txBytes */
        public uint txBytes;

        /* class_rtcstats_rxBytes */
        public uint rxBytes;

        /* class_rtcstats_txAudioBytes */
        public uint txAudioBytes;

        /* class_rtcstats_txVideoBytes */
        public uint txVideoBytes;

        /* class_rtcstats_rxAudioBytes */
        public uint rxAudioBytes;

        /* class_rtcstats_rxVideoBytes */
        public uint rxVideoBytes;

        /* class_rtcstats_txKBitRate */
        public ushort txKBitRate;

        /* class_rtcstats_rxKBitRate */
        public ushort rxKBitRate;

        /* class_rtcstats_rxAudioKBitRate */
        public ushort rxAudioKBitRate;

        /* class_rtcstats_txAudioKBitRate */
        public ushort txAudioKBitRate;

        /* class_rtcstats_rxVideoKBitRate */
        public ushort rxVideoKBitRate;

        /* class_rtcstats_txVideoKBitRate */
        public ushort txVideoKBitRate;

        /* class_rtcstats_lastmileDelay */
        public ushort lastmileDelay;

        /* class_rtcstats_userCount */
        public uint userCount;

        /* class_rtcstats_cpuAppUsage */
        public double cpuAppUsage;

        /* class_rtcstats_cpuTotalUsage */
        public double cpuTotalUsage;

        /* class_rtcstats_gatewayRtt */
        public int gatewayRtt;

        /* class_rtcstats_memoryAppUsageRatio */
        public double memoryAppUsageRatio;

        /* class_rtcstats_memoryTotalUsageRatio */
        public double memoryTotalUsageRatio;

        /* class_rtcstats_memoryAppUsageInKbytes */
        public int memoryAppUsageInKbytes;

        /* class_rtcstats_connectTimeMs */
        public int connectTimeMs;

        /* class_rtcstats_firstAudioPacketDuration */
        public int firstAudioPacketDuration;

        /* class_rtcstats_firstVideoPacketDuration */
        public int firstVideoPacketDuration;

        /* class_rtcstats_firstVideoKeyFramePacketDuration */
        public int firstVideoKeyFramePacketDuration;

        /* class_rtcstats_packetsBeforeFirstKeyFramePacket */
        public int packetsBeforeFirstKeyFramePacket;

        /* class_rtcstats_firstAudioPacketDurationAfterUnmute */
        public int firstAudioPacketDurationAfterUnmute;

        /* class_rtcstats_firstVideoPacketDurationAfterUnmute */
        public int firstVideoPacketDurationAfterUnmute;

        /* class_rtcstats_firstVideoKeyFramePacketDurationAfterUnmute */
        public int firstVideoKeyFramePacketDurationAfterUnmute;

        /* class_rtcstats_firstVideoKeyFrameDecodedDurationAfterUnmute */
        public int firstVideoKeyFrameDecodedDurationAfterUnmute;

        /* class_rtcstats_firstVideoKeyFrameRenderedDurationAfterUnmute */
        public int firstVideoKeyFrameRenderedDurationAfterUnmute;

        /* class_rtcstats_txPacketLossRate */
        public int txPacketLossRate;

        /* class_rtcstats_rxPacketLossRate */
        public int rxPacketLossRate;

        public RtcStats()
        {
            this.duration = 0;
            this.txBytes = 0;
            this.rxBytes = 0;
            this.txAudioBytes = 0;
            this.txVideoBytes = 0;
            this.rxAudioBytes = 0;
            this.rxVideoBytes = 0;
            this.txKBitRate = 0;
            this.rxKBitRate = 0;
            this.rxAudioKBitRate = 0;
            this.txAudioKBitRate = 0;
            this.rxVideoKBitRate = 0;
            this.txVideoKBitRate = 0;
            this.lastmileDelay = 0;
            this.userCount = 0;
            this.cpuAppUsage = 0.0f;
            this.cpuTotalUsage = 0.0f;
            this.gatewayRtt = 0;
            this.memoryAppUsageRatio = 0.0f;
            this.memoryTotalUsageRatio = 0.0f;
            this.memoryAppUsageInKbytes = 0;
            this.connectTimeMs = 0;
            this.firstAudioPacketDuration = 0;
            this.firstVideoPacketDuration = 0;
            this.firstVideoKeyFramePacketDuration = 0;
            this.packetsBeforeFirstKeyFramePacket = 0;
            this.firstAudioPacketDurationAfterUnmute = 0;
            this.firstVideoPacketDurationAfterUnmute = 0;
            this.firstVideoKeyFramePacketDurationAfterUnmute = 0;
            this.firstVideoKeyFrameDecodedDurationAfterUnmute = 0;
            this.firstVideoKeyFrameRenderedDurationAfterUnmute = 0;
            this.txPacketLossRate = 0;
            this.rxPacketLossRate = 0;
        }

        public RtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate, ushort lastmileDelay, uint userCount, double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio, int memoryAppUsageInKbytes, int connectTimeMs, int firstAudioPacketDuration, int firstVideoPacketDuration, int firstVideoKeyFramePacketDuration, int packetsBeforeFirstKeyFramePacket, int firstAudioPacketDurationAfterUnmute, int firstVideoPacketDurationAfterUnmute, int firstVideoKeyFramePacketDurationAfterUnmute, int firstVideoKeyFrameDecodedDurationAfterUnmute, int firstVideoKeyFrameRenderedDurationAfterUnmute, int txPacketLossRate, int rxPacketLossRate)
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
    }

    /* enum_clientroletype */
    public enum CLIENT_ROLE_TYPE
    {
        /* enum_clientroletype_CLIENT_ROLE_BROADCASTER */
        CLIENT_ROLE_BROADCASTER = 1,

        /* enum_clientroletype_CLIENT_ROLE_AUDIENCE */
        CLIENT_ROLE_AUDIENCE = 2,
    }

    /* enum_qualityadaptindication */
    public enum QUALITY_ADAPT_INDICATION
    {
        /* enum_qualityadaptindication_ADAPT_NONE */
        ADAPT_NONE = 0,

        /* enum_qualityadaptindication_ADAPT_UP_BANDWIDTH */
        ADAPT_UP_BANDWIDTH = 1,

        /* enum_qualityadaptindication_ADAPT_DOWN_BANDWIDTH */
        ADAPT_DOWN_BANDWIDTH = 2,
    }

    /* enum_audiencelatencyleveltype */
    public enum AUDIENCE_LATENCY_LEVEL_TYPE
    {
        /* enum_audiencelatencyleveltype_AUDIENCE_LATENCY_LEVEL_LOW_LATENCY */
        AUDIENCE_LATENCY_LEVEL_LOW_LATENCY = 1,

        /* enum_audiencelatencyleveltype_AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY */
        AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY = 2,
    }

    /* class_clientroleoptions */
    public class ClientRoleOptions
    {
        /* class_clientroleoptions_audienceLatencyLevel */
        public AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel;

        public ClientRoleOptions()
        {
            this.audienceLatencyLevel = AUDIENCE_LATENCY_LEVEL_TYPE.AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY;
        }

        public ClientRoleOptions(AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel)
        {
            this.audienceLatencyLevel = audienceLatencyLevel;
        }
    }

    /* enum_experiencequalitytype */
    public enum EXPERIENCE_QUALITY_TYPE
    {
        /* enum_experiencequalitytype_EXPERIENCE_QUALITY_GOOD */
        EXPERIENCE_QUALITY_GOOD = 0,

        /* enum_experiencequalitytype_EXPERIENCE_QUALITY_BAD */
        EXPERIENCE_QUALITY_BAD = 1,
    }

    /* enum_experiencepoorreason */
    public enum EXPERIENCE_POOR_REASON
    {
        /* enum_experiencepoorreason_EXPERIENCE_REASON_NONE */
        EXPERIENCE_REASON_NONE = 0,

        /* enum_experiencepoorreason_REMOTE_NETWORK_QUALITY_POOR */
        REMOTE_NETWORK_QUALITY_POOR = 1,

        /* enum_experiencepoorreason_LOCAL_NETWORK_QUALITY_POOR */
        LOCAL_NETWORK_QUALITY_POOR = 2,

        /* enum_experiencepoorreason_WIRELESS_SIGNAL_POOR */
        WIRELESS_SIGNAL_POOR = 4,

        /* enum_experiencepoorreason_WIFI_BLUETOOTH_COEXIST */
        WIFI_BLUETOOTH_COEXIST = 8,
    }

    /* enum_audioainsmode */
    public enum AUDIO_AINS_MODE
    {
        /* enum_audioainsmode_AINS_MODE_BALANCED */
        AINS_MODE_BALANCED = 0,

        /* enum_audioainsmode_AINS_MODE_AGGRESSIVE */
        AINS_MODE_AGGRESSIVE = 1,

        /* enum_audioainsmode_AINS_MODE_ULTRALOWLATENCY */
        AINS_MODE_ULTRALOWLATENCY = 2,
    }

    /* enum_audioprofiletype */
    public enum AUDIO_PROFILE_TYPE
    {
        /* enum_audioprofiletype_AUDIO_PROFILE_DEFAULT */
        AUDIO_PROFILE_DEFAULT = 0,

        /* enum_audioprofiletype_AUDIO_PROFILE_SPEECH_STANDARD */
        AUDIO_PROFILE_SPEECH_STANDARD = 1,

        /* enum_audioprofiletype_AUDIO_PROFILE_MUSIC_STANDARD */
        AUDIO_PROFILE_MUSIC_STANDARD = 2,

        /* enum_audioprofiletype_AUDIO_PROFILE_MUSIC_STANDARD_STEREO */
        AUDIO_PROFILE_MUSIC_STANDARD_STEREO = 3,

        /* enum_audioprofiletype_AUDIO_PROFILE_MUSIC_HIGH_QUALITY */
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY = 4,

        /* enum_audioprofiletype_AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO */
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO = 5,

        /* enum_audioprofiletype_AUDIO_PROFILE_IOT */
        AUDIO_PROFILE_IOT = 6,

        /* enum_audioprofiletype_AUDIO_PROFILE_NUM */
        AUDIO_PROFILE_NUM = 7,
    }

    /* enum_audioscenariotype */
    public enum AUDIO_SCENARIO_TYPE
    {
        /* enum_audioscenariotype_AUDIO_SCENARIO_DEFAULT */
        AUDIO_SCENARIO_DEFAULT = 0,

        /* enum_audioscenariotype_AUDIO_SCENARIO_GAME_STREAMING */
        AUDIO_SCENARIO_GAME_STREAMING = 3,

        /* enum_audioscenariotype_AUDIO_SCENARIO_CHATROOM */
        AUDIO_SCENARIO_CHATROOM = 5,

        /* enum_audioscenariotype_AUDIO_SCENARIO_CHORUS */
        AUDIO_SCENARIO_CHORUS = 7,

        /* enum_audioscenariotype_AUDIO_SCENARIO_MEETING */
        AUDIO_SCENARIO_MEETING = 8,

        /* enum_audioscenariotype_AUDIO_SCENARIO_NUM */
        AUDIO_SCENARIO_NUM = 9,
    }

    /* class_videoformat */
    public class VideoFormat
    {
        /* class_videoformat_width */
        public int width;

        /* class_videoformat_height */
        public int height;

        /* class_videoformat_fps */
        public int fps;

        public VideoFormat()
        {
            this.width = (int)FRAME_WIDTH.FRAME_WIDTH_960;
            this.height = (int)FRAME_HEIGHT.FRAME_HEIGHT_540;
            this.fps = (int)FRAME_RATE.FRAME_RATE_FPS_15;
        }

        public VideoFormat(int w, int h, int f)
        {
            this.width = w;
            this.height = h;
            this.fps = f;
        }
    }

    /* enum_videocontenthint */
    public enum VIDEO_CONTENT_HINT
    {
        /* enum_videocontenthint_CONTENT_HINT_NONE */
        CONTENT_HINT_NONE,

        /* enum_videocontenthint_CONTENT_HINT_MOTION */
        CONTENT_HINT_MOTION,

        /* enum_videocontenthint_CONTENT_HINT_DETAILS */
        CONTENT_HINT_DETAILS,
    }

    /* enum_screenscenariotype */
    public enum SCREEN_SCENARIO_TYPE
    {
        /* enum_screenscenariotype_SCREEN_SCENARIO_DOCUMENT */
        SCREEN_SCENARIO_DOCUMENT = 1,

        /* enum_screenscenariotype_SCREEN_SCENARIO_GAMING */
        SCREEN_SCENARIO_GAMING = 2,

        /* enum_screenscenariotype_SCREEN_SCENARIO_VIDEO */
        SCREEN_SCENARIO_VIDEO = 3,

        /* enum_screenscenariotype_SCREEN_SCENARIO_RDC */
        SCREEN_SCENARIO_RDC = 4,
    }

    /* enum_videoapplicationscenariotype */
    public enum VIDEO_APPLICATION_SCENARIO_TYPE
    {
        /* enum_videoapplicationscenariotype_APPLICATION_SCENARIO_GENERAL */
        APPLICATION_SCENARIO_GENERAL = 0,

        /* enum_videoapplicationscenariotype_APPLICATION_SCENARIO_MEETING */
        APPLICATION_SCENARIO_MEETING = 1,
    }

    /* enum_capturebrightnessleveltype */
    public enum CAPTURE_BRIGHTNESS_LEVEL_TYPE
    {
        /* enum_capturebrightnessleveltype_CAPTURE_BRIGHTNESS_LEVEL_INVALID */
        CAPTURE_BRIGHTNESS_LEVEL_INVALID = -1,

        /* enum_capturebrightnessleveltype_CAPTURE_BRIGHTNESS_LEVEL_NORMAL */
        CAPTURE_BRIGHTNESS_LEVEL_NORMAL = 0,

        /* enum_capturebrightnessleveltype_CAPTURE_BRIGHTNESS_LEVEL_BRIGHT */
        CAPTURE_BRIGHTNESS_LEVEL_BRIGHT = 1,

        /* enum_capturebrightnessleveltype_CAPTURE_BRIGHTNESS_LEVEL_DARK */
        CAPTURE_BRIGHTNESS_LEVEL_DARK = 2,
    }

    /* enum_localaudiostreamstate */
    public enum LOCAL_AUDIO_STREAM_STATE
    {
        /* enum_localaudiostreamstate_LOCAL_AUDIO_STREAM_STATE_STOPPED */
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        /* enum_localaudiostreamstate_LOCAL_AUDIO_STREAM_STATE_RECORDING */
        LOCAL_AUDIO_STREAM_STATE_RECORDING = 1,

        /* enum_localaudiostreamstate_LOCAL_AUDIO_STREAM_STATE_ENCODING */
        LOCAL_AUDIO_STREAM_STATE_ENCODING = 2,

        /* enum_localaudiostreamstate_LOCAL_AUDIO_STREAM_STATE_FAILED */
        LOCAL_AUDIO_STREAM_STATE_FAILED = 3,
    }

    /* enum_localaudiostreamerror */
    public enum LOCAL_AUDIO_STREAM_ERROR
    {
        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_OK */
        LOCAL_AUDIO_STREAM_ERROR_OK = 0,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_FAILURE */
        LOCAL_AUDIO_STREAM_ERROR_FAILURE = 1,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_DEVICE_NO_PERMISSION */
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_DEVICE_BUSY */
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_BUSY = 3,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE */
        LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE = 4,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE */
        LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE = 5,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_NO_RECORDING_DEVICE */
        LOCAL_AUDIO_STREAM_ERROR_NO_RECORDING_DEVICE = 6,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_NO_PLAYOUT_DEVICE */
        LOCAL_AUDIO_STREAM_ERROR_NO_PLAYOUT_DEVICE = 7,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_INTERRUPTED */
        LOCAL_AUDIO_STREAM_ERROR_INTERRUPTED = 8,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_RECORD_INVALID_ID */
        LOCAL_AUDIO_STREAM_ERROR_RECORD_INVALID_ID = 9,

        /* enum_localaudiostreamerror_LOCAL_AUDIO_STREAM_ERROR_PLAYOUT_INVALID_ID */
        LOCAL_AUDIO_STREAM_ERROR_PLAYOUT_INVALID_ID = 10,
    }

    /* enum_localvideostreamstate */
    public enum LOCAL_VIDEO_STREAM_STATE
    {
        /* enum_localvideostreamstate_LOCAL_VIDEO_STREAM_STATE_STOPPED */
        LOCAL_VIDEO_STREAM_STATE_STOPPED = 0,

        /* enum_localvideostreamstate_LOCAL_VIDEO_STREAM_STATE_CAPTURING */
        LOCAL_VIDEO_STREAM_STATE_CAPTURING = 1,

        /* enum_localvideostreamstate_LOCAL_VIDEO_STREAM_STATE_ENCODING */
        LOCAL_VIDEO_STREAM_STATE_ENCODING = 2,

        /* enum_localvideostreamstate_LOCAL_VIDEO_STREAM_STATE_FAILED */
        LOCAL_VIDEO_STREAM_STATE_FAILED = 3,
    }

    /* enum_localvideostreamerror */
    public enum LOCAL_VIDEO_STREAM_ERROR
    {
        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_OK */
        LOCAL_VIDEO_STREAM_ERROR_OK = 0,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_FAILURE */
        LOCAL_VIDEO_STREAM_ERROR_FAILURE = 1,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_DEVICE_NO_PERMISSION */
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY */
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY = 3,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE */
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE = 4,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_ENCODE_FAILURE */
        LOCAL_VIDEO_STREAM_ERROR_ENCODE_FAILURE = 5,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_CAPTURE_INBACKGROUND */
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_INBACKGROUND = 6,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_CAPTURE_MULTIPLE_FOREGROUND_APPS */
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_MULTIPLE_FOREGROUND_APPS = 7,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_DEVICE_NOT_FOUND */
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NOT_FOUND = 8,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_DEVICE_DISCONNECTED */
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_DISCONNECTED = 9,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_DEVICE_INVALID_ID */
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_INVALID_ID = 10,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_DEVICE_SYSTEM_PRESSURE */
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_SYSTEM_PRESSURE = 101,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED = 11,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_CLOSED */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_CLOSED = 12,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_OCCLUDED */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_OCCLUDED = 13,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_NOT_SUPPORTED */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_NOT_SUPPORTED = 20,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_FAILURE */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_FAILURE = 21,

        /* enum_localvideostreamerror_LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_NO_PERMISSION */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_NO_PERMISSION = 22,
    }

    /* enum_remoteaudiostate */
    public enum REMOTE_AUDIO_STATE
    {
        /* enum_remoteaudiostate_REMOTE_AUDIO_STATE_STOPPED */
        REMOTE_AUDIO_STATE_STOPPED = 0,

        /* enum_remoteaudiostate_REMOTE_AUDIO_STATE_STARTING */
        REMOTE_AUDIO_STATE_STARTING = 1,

        /* enum_remoteaudiostate_REMOTE_AUDIO_STATE_DECODING */
        REMOTE_AUDIO_STATE_DECODING = 2,

        /* enum_remoteaudiostate_REMOTE_AUDIO_STATE_FROZEN */
        REMOTE_AUDIO_STATE_FROZEN = 3,

        /* enum_remoteaudiostate_REMOTE_AUDIO_STATE_FAILED */
        REMOTE_AUDIO_STATE_FAILED = 4,
    }

    /* enum_remoteaudiostatereason */
    public enum REMOTE_AUDIO_STATE_REASON
    {
        /* enum_remoteaudiostatereason_REMOTE_AUDIO_REASON_INTERNAL */
        REMOTE_AUDIO_REASON_INTERNAL = 0,

        /* enum_remoteaudiostatereason_REMOTE_AUDIO_REASON_NETWORK_CONGESTION */
        REMOTE_AUDIO_REASON_NETWORK_CONGESTION = 1,

        /* enum_remoteaudiostatereason_REMOTE_AUDIO_REASON_NETWORK_RECOVERY */
        REMOTE_AUDIO_REASON_NETWORK_RECOVERY = 2,

        /* enum_remoteaudiostatereason_REMOTE_AUDIO_REASON_LOCAL_MUTED */
        REMOTE_AUDIO_REASON_LOCAL_MUTED = 3,

        /* enum_remoteaudiostatereason_REMOTE_AUDIO_REASON_LOCAL_UNMUTED */
        REMOTE_AUDIO_REASON_LOCAL_UNMUTED = 4,

        /* enum_remoteaudiostatereason_REMOTE_AUDIO_REASON_REMOTE_MUTED */
        REMOTE_AUDIO_REASON_REMOTE_MUTED = 5,

        /* enum_remoteaudiostatereason_REMOTE_AUDIO_REASON_REMOTE_UNMUTED */
        REMOTE_AUDIO_REASON_REMOTE_UNMUTED = 6,

        /* enum_remoteaudiostatereason_REMOTE_AUDIO_REASON_REMOTE_OFFLINE */
        REMOTE_AUDIO_REASON_REMOTE_OFFLINE = 7,
    }

    /* enum_remotevideostate */
    public enum REMOTE_VIDEO_STATE
    {
        /* enum_remotevideostate_REMOTE_VIDEO_STATE_STOPPED */
        REMOTE_VIDEO_STATE_STOPPED = 0,

        /* enum_remotevideostate_REMOTE_VIDEO_STATE_STARTING */
        REMOTE_VIDEO_STATE_STARTING = 1,

        /* enum_remotevideostate_REMOTE_VIDEO_STATE_DECODING */
        REMOTE_VIDEO_STATE_DECODING = 2,

        /* enum_remotevideostate_REMOTE_VIDEO_STATE_FROZEN */
        REMOTE_VIDEO_STATE_FROZEN = 3,

        /* enum_remotevideostate_REMOTE_VIDEO_STATE_FAILED */
        REMOTE_VIDEO_STATE_FAILED = 4,
    }

    /* enum_remotevideostatereason */
    public enum REMOTE_VIDEO_STATE_REASON
    {
        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_INTERNAL */
        REMOTE_VIDEO_STATE_REASON_INTERNAL = 0,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION */
        REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION = 1,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY */
        REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY = 2,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED */
        REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED = 3,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED */
        REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED = 4,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED */
        REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED = 5,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED */
        REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED = 6,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE */
        REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE = 7,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK */
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK = 8,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY */
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY = 9,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_LOW */
        REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_LOW = 10,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_HIGH */
        REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_HIGH = 11,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_SDK_IN_BACKGROUND */
        REMOTE_VIDEO_STATE_REASON_SDK_IN_BACKGROUND = 12,

        /* enum_remotevideostatereason_REMOTE_VIDEO_STATE_REASON_CODEC_NOT_SUPPORT */
        REMOTE_VIDEO_STATE_REASON_CODEC_NOT_SUPPORT = 13,
    }

    /* enum_remoteuserstate */
    public enum REMOTE_USER_STATE
    {
        /* enum_remoteuserstate_USER_STATE_MUTE_AUDIO */
        USER_STATE_MUTE_AUDIO = (1 << 0),

        /* enum_remoteuserstate_USER_STATE_MUTE_VIDEO */
        USER_STATE_MUTE_VIDEO = (1 << 1),

        /* enum_remoteuserstate_USER_STATE_ENABLE_VIDEO */
        USER_STATE_ENABLE_VIDEO = (1 << 4),

        /* enum_remoteuserstate_USER_STATE_ENABLE_LOCAL_VIDEO */
        USER_STATE_ENABLE_LOCAL_VIDEO = (1 << 8),
    }

    /* class_videotrackinfo */
    public class VideoTrackInfo
    {
        /* class_videotrackinfo_isLocal */
        public bool isLocal;

        /* class_videotrackinfo_ownerUid */
        public uint ownerUid;

        /* class_videotrackinfo_trackId */
        public uint trackId;

        /* class_videotrackinfo_channelId */
        public string channelId;

        /* class_videotrackinfo_streamType */
        public VIDEO_STREAM_TYPE streamType;

        /* class_videotrackinfo_codecType */
        public VIDEO_CODEC_TYPE codecType;

        /* class_videotrackinfo_encodedFrameOnly */
        public bool encodedFrameOnly;

        /* class_videotrackinfo_sourceType */
        public VIDEO_SOURCE_TYPE sourceType;

        /* class_videotrackinfo_observationPosition */
        public uint observationPosition;

        public VideoTrackInfo()
        {
            this.isLocal = false;
            this.ownerUid = 0;
            this.trackId = 0;
            this.channelId = "";
            this.streamType = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
            this.codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            this.encodedFrameOnly = false;
            this.sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            this.observationPosition = (uint)VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER;
        }

        public VideoTrackInfo(bool isLocal, uint ownerUid, uint trackId, string channelId, VIDEO_STREAM_TYPE streamType, VIDEO_CODEC_TYPE codecType, bool encodedFrameOnly, VIDEO_SOURCE_TYPE sourceType, uint observationPosition)
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
    }

    /* enum_remotevideodownscalelevel */
    public enum REMOTE_VIDEO_DOWNSCALE_LEVEL
    {
        /* enum_remotevideodownscalelevel_REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE */
        REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE,

        /* enum_remotevideodownscalelevel_REMOTE_VIDEO_DOWNSCALE_LEVEL_1 */
        REMOTE_VIDEO_DOWNSCALE_LEVEL_1,

        /* enum_remotevideodownscalelevel_REMOTE_VIDEO_DOWNSCALE_LEVEL_2 */
        REMOTE_VIDEO_DOWNSCALE_LEVEL_2,

        /* enum_remotevideodownscalelevel_REMOTE_VIDEO_DOWNSCALE_LEVEL_3 */
        REMOTE_VIDEO_DOWNSCALE_LEVEL_3,

        /* enum_remotevideodownscalelevel_REMOTE_VIDEO_DOWNSCALE_LEVEL_4 */
        REMOTE_VIDEO_DOWNSCALE_LEVEL_4,
    }

    /* class_audiovolumeinfo */
    public class AudioVolumeInfo
    {
        /* class_audiovolumeinfo_uid */
        public uint uid;

        /* class_audiovolumeinfo_volume */
        public uint volume;

        /* class_audiovolumeinfo_vad */
        public uint vad;

        /* class_audiovolumeinfo_voicePitch */
        public double voicePitch;

        public AudioVolumeInfo()
        {
            this.uid = 0;
            this.volume = 0;
            this.vad = 0;
            this.voicePitch = 0.0f;
        }

        public AudioVolumeInfo(uint uid, uint volume, uint vad, double voicePitch)
        {
            this.uid = uid;
            this.volume = volume;
            this.vad = vad;
            this.voicePitch = voicePitch;
        }
    }

    /* enum_audiosampleratetype */
    public enum AUDIO_SAMPLE_RATE_TYPE
    {
        /* enum_audiosampleratetype_AUDIO_SAMPLE_RATE_32000 */
        AUDIO_SAMPLE_RATE_32000 = 32000,

        /* enum_audiosampleratetype_AUDIO_SAMPLE_RATE_44100 */
        AUDIO_SAMPLE_RATE_44100 = 44100,

        /* enum_audiosampleratetype_AUDIO_SAMPLE_RATE_48000 */
        AUDIO_SAMPLE_RATE_48000 = 48000,
    }

    /* enum_videocodectypeforstream */
    public enum VIDEO_CODEC_TYPE_FOR_STREAM
    {
        /* enum_videocodectypeforstream_VIDEO_CODEC_H264_FOR_STREAM */
        VIDEO_CODEC_H264_FOR_STREAM = 1,

        /* enum_videocodectypeforstream_VIDEO_CODEC_H265_FOR_STREAM */
        VIDEO_CODEC_H265_FOR_STREAM = 2,
    }

    /* enum_videocodecprofiletype */
    public enum VIDEO_CODEC_PROFILE_TYPE
    {
        /* enum_videocodecprofiletype_VIDEO_CODEC_PROFILE_BASELINE */
        VIDEO_CODEC_PROFILE_BASELINE = 66,

        /* enum_videocodecprofiletype_VIDEO_CODEC_PROFILE_MAIN */
        VIDEO_CODEC_PROFILE_MAIN = 77,

        /* enum_videocodecprofiletype_VIDEO_CODEC_PROFILE_HIGH */
        VIDEO_CODEC_PROFILE_HIGH = 100,
    }

    /* enum_audiocodecprofiletype */
    public enum AUDIO_CODEC_PROFILE_TYPE
    {
        /* enum_audiocodecprofiletype_AUDIO_CODEC_PROFILE_LC_AAC */
        AUDIO_CODEC_PROFILE_LC_AAC = 0,

        /* enum_audiocodecprofiletype_AUDIO_CODEC_PROFILE_HE_AAC */
        AUDIO_CODEC_PROFILE_HE_AAC = 1,

        /* enum_audiocodecprofiletype_AUDIO_CODEC_PROFILE_HE_AAC_V2 */
        AUDIO_CODEC_PROFILE_HE_AAC_V2 = 2,
    }

    /* class_localaudiostats */
    public class LocalAudioStats
    {
        /* class_localaudiostats_numChannels */
        public int numChannels;

        /* class_localaudiostats_sentSampleRate */
        public int sentSampleRate;

        /* class_localaudiostats_sentBitrate */
        public int sentBitrate;

        /* class_localaudiostats_internalCodec */
        public int internalCodec;

        /* class_localaudiostats_txPacketLossRate */
        public ushort txPacketLossRate;

        /* class_localaudiostats_audioDeviceDelay */
        public int audioDeviceDelay;

        public LocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate, int internalCodec, ushort txPacketLossRate, int audioDeviceDelay)
        {
            this.numChannels = numChannels;
            this.sentSampleRate = sentSampleRate;
            this.sentBitrate = sentBitrate;
            this.internalCodec = internalCodec;
            this.txPacketLossRate = txPacketLossRate;
            this.audioDeviceDelay = audioDeviceDelay;
        }
        public LocalAudioStats()
        {
        }
    }

    /* enum_rtmpstreampublishstate */
    public enum RTMP_STREAM_PUBLISH_STATE
    {
        /* enum_rtmpstreampublishstate_RTMP_STREAM_PUBLISH_STATE_IDLE */
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        /* enum_rtmpstreampublishstate_RTMP_STREAM_PUBLISH_STATE_CONNECTING */
        RTMP_STREAM_PUBLISH_STATE_CONNECTING = 1,

        /* enum_rtmpstreampublishstate_RTMP_STREAM_PUBLISH_STATE_RUNNING */
        RTMP_STREAM_PUBLISH_STATE_RUNNING = 2,

        /* enum_rtmpstreampublishstate_RTMP_STREAM_PUBLISH_STATE_RECOVERING */
        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        /* enum_rtmpstreampublishstate_RTMP_STREAM_PUBLISH_STATE_FAILURE */
        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,

        /* enum_rtmpstreampublishstate_RTMP_STREAM_PUBLISH_STATE_DISCONNECTING */
        RTMP_STREAM_PUBLISH_STATE_DISCONNECTING = 5,
    }

    /* enum_rtmpstreampublisherrortype */
    public enum RTMP_STREAM_PUBLISH_ERROR_TYPE
    {
        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_OK */
        RTMP_STREAM_PUBLISH_ERROR_OK = 0,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_INVALID_ARGUMENT */
        RTMP_STREAM_PUBLISH_ERROR_INVALID_ARGUMENT = 1,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_ENCRYPTED_STREAM_NOT_ALLOWED */
        RTMP_STREAM_PUBLISH_ERROR_ENCRYPTED_STREAM_NOT_ALLOWED = 2,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT */
        RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT = 3,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_INTERNAL_SERVER_ERROR */
        RTMP_STREAM_PUBLISH_ERROR_INTERNAL_SERVER_ERROR = 4,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_RTMP_SERVER_ERROR */
        RTMP_STREAM_PUBLISH_ERROR_RTMP_SERVER_ERROR = 5,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_TOO_OFTEN */
        RTMP_STREAM_PUBLISH_ERROR_TOO_OFTEN = 6,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_REACH_LIMIT */
        RTMP_STREAM_PUBLISH_ERROR_REACH_LIMIT = 7,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_NOT_AUTHORIZED */
        RTMP_STREAM_PUBLISH_ERROR_NOT_AUTHORIZED = 8,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_STREAM_NOT_FOUND */
        RTMP_STREAM_PUBLISH_ERROR_STREAM_NOT_FOUND = 9,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_FORMAT_NOT_SUPPORTED */
        RTMP_STREAM_PUBLISH_ERROR_FORMAT_NOT_SUPPORTED = 10,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_NOT_BROADCASTER */
        RTMP_STREAM_PUBLISH_ERROR_NOT_BROADCASTER = 11,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_TRANSCODING_NO_MIX_STREAM */
        RTMP_STREAM_PUBLISH_ERROR_TRANSCODING_NO_MIX_STREAM = 13,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_NET_DOWN */
        RTMP_STREAM_PUBLISH_ERROR_NET_DOWN = 14,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_INVALID_APPID */
        RTMP_STREAM_PUBLISH_ERROR_INVALID_APPID = 15,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_PUBLISH_ERROR_INVALID_PRIVILEGE */
        RTMP_STREAM_PUBLISH_ERROR_INVALID_PRIVILEGE = 16,

        /* enum_rtmpstreampublisherrortype_RTMP_STREAM_UNPUBLISH_ERROR_OK */
        RTMP_STREAM_UNPUBLISH_ERROR_OK = 100,
    }

    /* enum_rtmpstreamingevent */
    public enum RTMP_STREAMING_EVENT
    {
        /* enum_rtmpstreamingevent_RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE */
        RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE = 1,

        /* enum_rtmpstreamingevent_RTMP_STREAMING_EVENT_URL_ALREADY_IN_USE */
        RTMP_STREAMING_EVENT_URL_ALREADY_IN_USE = 2,

        /* enum_rtmpstreamingevent_RTMP_STREAMING_EVENT_ADVANCED_FEATURE_NOT_SUPPORT */
        RTMP_STREAMING_EVENT_ADVANCED_FEATURE_NOT_SUPPORT = 3,

        /* enum_rtmpstreamingevent_RTMP_STREAMING_EVENT_REQUEST_TOO_OFTEN */
        RTMP_STREAMING_EVENT_REQUEST_TOO_OFTEN = 4,
    }

    /* class_rtcimage */
    public class RtcImage
    {
        /* class_rtcimage_url */
        public string url;

        /* class_rtcimage_x */
        public int x;

        /* class_rtcimage_y */
        public int y;

        /* class_rtcimage_width */
        public int width;

        /* class_rtcimage_height */
        public int height;

        /* class_rtcimage_zOrder */
        public int zOrder;

        /* class_rtcimage_alpha */
        public double alpha;

        public RtcImage()
        {
            this.url = "";
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
            this.zOrder = 0;
            this.alpha = 1.0;
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
    }

    /* class_livestreamadvancedfeature */
    public class LiveStreamAdvancedFeature
    {
        /* class_livestreamadvancedfeature_featureName */
        public string featureName;

        /* class_livestreamadvancedfeature_opened */
        public bool opened;

        public LiveStreamAdvancedFeature()
        {
            this.featureName = "";
            this.opened = false;
        }

        public LiveStreamAdvancedFeature(string feat_name, bool open)
        {
            this.featureName = feat_name;
            this.opened = open;
        }
    }

    /* enum_connectionstatetype */
    public enum CONNECTION_STATE_TYPE
    {
        /* enum_connectionstatetype_CONNECTION_STATE_DISCONNECTED */
        CONNECTION_STATE_DISCONNECTED = 1,

        /* enum_connectionstatetype_CONNECTION_STATE_CONNECTING */
        CONNECTION_STATE_CONNECTING = 2,

        /* enum_connectionstatetype_CONNECTION_STATE_CONNECTED */
        CONNECTION_STATE_CONNECTED = 3,

        /* enum_connectionstatetype_CONNECTION_STATE_RECONNECTING */
        CONNECTION_STATE_RECONNECTING = 4,

        /* enum_connectionstatetype_CONNECTION_STATE_FAILED */
        CONNECTION_STATE_FAILED = 5,
    }

    /* class_transcodinguser */
    public class TranscodingUser
    {
        /* class_transcodinguser_uid */
        public uint uid;

        /* class_transcodinguser_x */
        public int x;

        /* class_transcodinguser_y */
        public int y;

        /* class_transcodinguser_width */
        public int width;

        /* class_transcodinguser_height */
        public int height;

        /* class_transcodinguser_zOrder */
        public int zOrder;

        /* class_transcodinguser_alpha */
        public double alpha;

        /* class_transcodinguser_audioChannel */
        public int audioChannel;

        public TranscodingUser()
        {
            this.uid = 0;
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
            this.zOrder = 0;
            this.alpha = 1.0;
            this.audioChannel = 0;
        }

        public TranscodingUser(uint uid, int x, int y, int width, int height, int zOrder, double alpha, int audioChannel)
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
    }

    /* class_livetranscoding */
    public class LiveTranscoding
    {
        /* class_livetranscoding_width */
        public int width;

        /* class_livetranscoding_height */
        public int height;

        /* class_livetranscoding_videoBitrate */
        public int videoBitrate;

        /* class_livetranscoding_videoFramerate */
        public int videoFramerate;

        /* class_livetranscoding_lowLatency */
        public bool lowLatency;

        /* class_livetranscoding_videoGop */
        public int videoGop;

        /* class_livetranscoding_videoCodecProfile */
        public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile;

        /* class_livetranscoding_backgroundColor */
        public uint backgroundColor;

        /* class_livetranscoding_videoCodecType */
        public VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType;

        /* class_livetranscoding_userCount */
        public uint userCount;

        public TranscodingUser[] transcodingUsers;

        /* class_livetranscoding_transcodingExtraInfo */
        public string transcodingExtraInfo;

        /* class_livetranscoding_metadata */
        public string metadata;

        public RtcImage[] watermark;

        /* class_livetranscoding_watermarkCount */
        public uint watermarkCount;

        public RtcImage[] backgroundImage;

        /* class_livetranscoding_backgroundImageCount */
        public uint backgroundImageCount;

        /* class_livetranscoding_audioSampleRate */
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate;

        /* class_livetranscoding_audioBitrate */
        public int audioBitrate;

        /* class_livetranscoding_audioChannels */
        public int audioChannels;

        /* class_livetranscoding_audioCodecProfile */
        public AUDIO_CODEC_PROFILE_TYPE audioCodecProfile;

        public LiveStreamAdvancedFeature[] advancedFeatures;

        /* class_livetranscoding_advancedFeatureCount */
        public uint advancedFeatureCount;

        public LiveTranscoding()
        {
            this.width = 360;
            this.height = 640;
            this.videoBitrate = 400;
            this.videoFramerate = 15;
            this.lowLatency = false;
            this.videoGop = 30;
            this.videoCodecProfile = VIDEO_CODEC_PROFILE_TYPE.VIDEO_CODEC_PROFILE_HIGH;
            this.backgroundColor = 0x000000;
            this.videoCodecType = VIDEO_CODEC_TYPE_FOR_STREAM.VIDEO_CODEC_H264_FOR_STREAM;
            this.userCount = 0;
            this.transcodingUsers = new TranscodingUser[0];
            this.transcodingExtraInfo = "";
            this.metadata = "";
            this.watermark = new RtcImage[0];
            this.watermarkCount = 0;
            this.backgroundImage = new RtcImage[0];
            this.backgroundImageCount = 0;
            this.audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            this.audioBitrate = 48;
            this.audioChannels = 1;
            this.audioCodecProfile = AUDIO_CODEC_PROFILE_TYPE.AUDIO_CODEC_PROFILE_LC_AAC;
            this.advancedFeatures = new LiveStreamAdvancedFeature[0];
            this.advancedFeatureCount = 0;
        }

        public LiveTranscoding(int width, int height, int videoBitrate, int videoFramerate, bool lowLatency, int videoGop, VIDEO_CODEC_PROFILE_TYPE videoCodecProfile, uint backgroundColor, VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType, uint userCount, TranscodingUser[] transcodingUsers, string transcodingExtraInfo, string metadata, RtcImage[] watermark, uint watermarkCount, RtcImage[] backgroundImage, uint backgroundImageCount, AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels, AUDIO_CODEC_PROFILE_TYPE audioCodecProfile, LiveStreamAdvancedFeature[] advancedFeatures, uint advancedFeatureCount)
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
    }

    /* class_transcodingvideostream */
    public class TranscodingVideoStream
    {
        /* class_transcodingvideostream_sourceType */
        public VIDEO_SOURCE_TYPE sourceType;

        /* class_transcodingvideostream_remoteUserUid */
        public uint remoteUserUid;

        /* class_transcodingvideostream_imageUrl */
        public string imageUrl;

        /* class_transcodingvideostream_mediaPlayerId */
        public int mediaPlayerId;

        /* class_transcodingvideostream_x */
        public int x;

        /* class_transcodingvideostream_y */
        public int y;

        /* class_transcodingvideostream_width */
        public int width;

        /* class_transcodingvideostream_height */
        public int height;

        /* class_transcodingvideostream_zOrder */
        public int zOrder;

        /* class_transcodingvideostream_alpha */
        public double alpha;

        /* class_transcodingvideostream_mirror */
        public bool mirror;

        public TranscodingVideoStream()
        {
            this.sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            this.remoteUserUid = 0;
            this.imageUrl = "";
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
            this.zOrder = 0;
            this.alpha = 1.0;
            this.mirror = false;
        }

        public TranscodingVideoStream(VIDEO_SOURCE_TYPE sourceType, uint remoteUserUid, string imageUrl, int mediaPlayerId, int x, int y, int width, int height, int zOrder, double alpha, bool mirror)
        {
            this.sourceType = sourceType;
            this.remoteUserUid = remoteUserUid;
            this.imageUrl = imageUrl;
            this.mediaPlayerId = mediaPlayerId;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
            this.mirror = mirror;
        }
    }

    /* class_localtranscoderconfiguration */
    public class LocalTranscoderConfiguration
    {
        /* class_localtranscoderconfiguration_streamCount */
        public uint streamCount;

        public TranscodingVideoStream[] videoInputStreams;

        /* class_localtranscoderconfiguration_videoOutputConfiguration */
        public VideoEncoderConfiguration videoOutputConfiguration;

        /* class_localtranscoderconfiguration_syncWithPrimaryCamera */
        public bool syncWithPrimaryCamera;

        public LocalTranscoderConfiguration()
        {
            this.streamCount = 0;
            this.videoInputStreams = new TranscodingVideoStream[0];
            this.videoOutputConfiguration = new VideoEncoderConfiguration();
            this.syncWithPrimaryCamera = true;
        }

        public LocalTranscoderConfiguration(uint streamCount, TranscodingVideoStream[] videoInputStreams, VideoEncoderConfiguration videoOutputConfiguration, bool syncWithPrimaryCamera)
        {
            this.streamCount = streamCount;
            this.videoInputStreams = videoInputStreams;
            this.videoOutputConfiguration = videoOutputConfiguration;
            this.syncWithPrimaryCamera = syncWithPrimaryCamera;
        }
    }

    /* enum_videotranscodererror */
    public enum VIDEO_TRANSCODER_ERROR
    {
        /* enum_videotranscodererror_VT_ERR_OK */
        VT_ERR_OK = 0,

        /* enum_videotranscodererror_VT_ERR_VIDEO_SOURCE_NOT_READY */
        VT_ERR_VIDEO_SOURCE_NOT_READY = 1,

        /* enum_videotranscodererror_VT_ERR_INVALID_VIDEO_SOURCE_TYPE */
        VT_ERR_INVALID_VIDEO_SOURCE_TYPE = 2,

        /* enum_videotranscodererror_VT_ERR_INVALID_IMAGE_PATH */
        VT_ERR_INVALID_IMAGE_PATH = 3,

        /* enum_videotranscodererror_VT_ERR_UNSUPPORT_IMAGE_FORMAT */
        VT_ERR_UNSUPPORT_IMAGE_FORMAT = 4,

        /* enum_videotranscodererror_VT_ERR_INVALID_LAYOUT */
        VT_ERR_INVALID_LAYOUT = 5,

        /* enum_videotranscodererror_VT_ERR_INTERNAL */
        VT_ERR_INTERNAL = 20,
    }

    /* class_lastmileprobeconfig */
    public class LastmileProbeConfig
    {
        /* class_lastmileprobeconfig_probeUplink */
        public bool probeUplink;

        /* class_lastmileprobeconfig_probeDownlink */
        public bool probeDownlink;

        /* class_lastmileprobeconfig_expectedUplinkBitrate */
        public uint expectedUplinkBitrate;

        /* class_lastmileprobeconfig_expectedDownlinkBitrate */
        public uint expectedDownlinkBitrate;

        public LastmileProbeConfig(bool probeUplink, bool probeDownlink, uint expectedUplinkBitrate, uint expectedDownlinkBitrate)
        {
            this.probeUplink = probeUplink;
            this.probeDownlink = probeDownlink;
            this.expectedUplinkBitrate = expectedUplinkBitrate;
            this.expectedDownlinkBitrate = expectedDownlinkBitrate;
        }
        public LastmileProbeConfig()
        {
        }
    }

    /* enum_lastmileproberesultstate */
    public enum LASTMILE_PROBE_RESULT_STATE
    {
        /* enum_lastmileproberesultstate_LASTMILE_PROBE_RESULT_COMPLETE */
        LASTMILE_PROBE_RESULT_COMPLETE = 1,

        /* enum_lastmileproberesultstate_LASTMILE_PROBE_RESULT_INCOMPLETE_NO_BWE */
        LASTMILE_PROBE_RESULT_INCOMPLETE_NO_BWE = 2,

        /* enum_lastmileproberesultstate_LASTMILE_PROBE_RESULT_UNAVAILABLE */
        LASTMILE_PROBE_RESULT_UNAVAILABLE = 3,
    }

    /* class_lastmileprobeonewayresult */
    public class LastmileProbeOneWayResult
    {
        /* class_lastmileprobeonewayresult_packetLossRate */
        public uint packetLossRate;

        /* class_lastmileprobeonewayresult_jitter */
        public uint jitter;

        /* class_lastmileprobeonewayresult_availableBandwidth */
        public uint availableBandwidth;

        public LastmileProbeOneWayResult()
        {
            this.packetLossRate = 0;
            this.jitter = 0;
            this.availableBandwidth = 0;
        }

        public LastmileProbeOneWayResult(uint packetLossRate, uint jitter, uint availableBandwidth)
        {
            this.packetLossRate = packetLossRate;
            this.jitter = jitter;
            this.availableBandwidth = availableBandwidth;
        }
    }

    /* class_lastmileproberesult */
    public class LastmileProbeResult
    {
        /* class_lastmileproberesult_state */
        public LASTMILE_PROBE_RESULT_STATE state;

        /* class_lastmileproberesult_uplinkReport */
        public LastmileProbeOneWayResult uplinkReport;

        /* class_lastmileproberesult_downlinkReport */
        public LastmileProbeOneWayResult downlinkReport;

        /* class_lastmileproberesult_rtt */
        public uint rtt;

        public LastmileProbeResult()
        {
            this.state = LASTMILE_PROBE_RESULT_STATE.LASTMILE_PROBE_RESULT_UNAVAILABLE;
            this.rtt = 0;
        }

        public LastmileProbeResult(LASTMILE_PROBE_RESULT_STATE state, LastmileProbeOneWayResult uplinkReport, LastmileProbeOneWayResult downlinkReport, uint rtt)
        {
            this.state = state;
            this.uplinkReport = uplinkReport;
            this.downlinkReport = downlinkReport;
            this.rtt = rtt;
        }
    }

    /* enum_connectionchangedreasontype */
    public enum CONNECTION_CHANGED_REASON_TYPE
    {
        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_CONNECTING */
        CONNECTION_CHANGED_CONNECTING = 0,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_JOIN_SUCCESS */
        CONNECTION_CHANGED_JOIN_SUCCESS = 1,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_INTERRUPTED */
        CONNECTION_CHANGED_INTERRUPTED = 2,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_BANNED_BY_SERVER */
        CONNECTION_CHANGED_BANNED_BY_SERVER = 3,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_JOIN_FAILED */
        CONNECTION_CHANGED_JOIN_FAILED = 4,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_LEAVE_CHANNEL */
        CONNECTION_CHANGED_LEAVE_CHANNEL = 5,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_INVALID_APP_ID */
        CONNECTION_CHANGED_INVALID_APP_ID = 6,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_INVALID_CHANNEL_NAME */
        CONNECTION_CHANGED_INVALID_CHANNEL_NAME = 7,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_INVALID_TOKEN */
        CONNECTION_CHANGED_INVALID_TOKEN = 8,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_TOKEN_EXPIRED */
        CONNECTION_CHANGED_TOKEN_EXPIRED = 9,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_REJECTED_BY_SERVER */
        CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_SETTING_PROXY_SERVER */
        CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_RENEW_TOKEN */
        CONNECTION_CHANGED_RENEW_TOKEN = 12,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED */
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT */
        CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_REJOIN_SUCCESS */
        CONNECTION_CHANGED_REJOIN_SUCCESS = 15,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_LOST */
        CONNECTION_CHANGED_LOST = 16,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_ECHO_TEST */
        CONNECTION_CHANGED_ECHO_TEST = 17,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED_BY_USER */
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_SAME_UID_LOGIN */
        CONNECTION_CHANGED_SAME_UID_LOGIN = 19,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_TOO_MANY_BROADCASTERS */
        CONNECTION_CHANGED_TOO_MANY_BROADCASTERS = 20,

        /* enum_connectionchangedreasontype_CONNECTION_CHANGED_LICENSE_VALIDATION_FAILURE */
        CONNECTION_CHANGED_LICENSE_VALIDATION_FAILURE = 21,
    }

    /* enum_clientrolechangefailedreason */
    public enum CLIENT_ROLE_CHANGE_FAILED_REASON
    {
        /* enum_clientrolechangefailedreason_CLIENT_ROLE_CHANGE_FAILED_TOO_MANY_BROADCASTERS */
        CLIENT_ROLE_CHANGE_FAILED_TOO_MANY_BROADCASTERS = 1,

        /* enum_clientrolechangefailedreason_CLIENT_ROLE_CHANGE_FAILED_NOT_AUTHORIZED */
        CLIENT_ROLE_CHANGE_FAILED_NOT_AUTHORIZED = 2,

        /* enum_clientrolechangefailedreason_CLIENT_ROLE_CHANGE_FAILED_REQUEST_TIME_OUT */
        CLIENT_ROLE_CHANGE_FAILED_REQUEST_TIME_OUT = 3,

        /* enum_clientrolechangefailedreason_CLIENT_ROLE_CHANGE_FAILED_CONNECTION_FAILED */
        CLIENT_ROLE_CHANGE_FAILED_CONNECTION_FAILED = 4,
    }

    /* enum_wlaccmessagereason */
    public enum WLACC_MESSAGE_REASON
    {
        /* enum_wlaccmessagereason_WLACC_MESSAGE_REASON_WEAK_SIGNAL */
        WLACC_MESSAGE_REASON_WEAK_SIGNAL = 0,

        /* enum_wlaccmessagereason_WLACC_MESSAGE_REASON_CHANNEL_CONGESTION */
        WLACC_MESSAGE_REASON_CHANNEL_CONGESTION = 1,
    }

    /* enum_wlaccsuggestaction */
    public enum WLACC_SUGGEST_ACTION
    {
        /* enum_wlaccsuggestaction_WLACC_SUGGEST_ACTION_CLOSE_TO_WIFI */
        WLACC_SUGGEST_ACTION_CLOSE_TO_WIFI = 0,

        /* enum_wlaccsuggestaction_WLACC_SUGGEST_ACTION_CONNECT_SSID */
        WLACC_SUGGEST_ACTION_CONNECT_SSID = 1,

        /* enum_wlaccsuggestaction_WLACC_SUGGEST_ACTION_CHECK_5G */
        WLACC_SUGGEST_ACTION_CHECK_5G = 2,

        /* enum_wlaccsuggestaction_WLACC_SUGGEST_ACTION_MODIFY_SSID */
        WLACC_SUGGEST_ACTION_MODIFY_SSID = 3,
    }

    /* class_wlaccstats */
    public class WlAccStats
    {
        /* class_wlaccstats_e2eDelayPercent */
        public ushort e2eDelayPercent;

        /* class_wlaccstats_frozenRatioPercent */
        public ushort frozenRatioPercent;

        /* class_wlaccstats_lossRatePercent */
        public ushort lossRatePercent;

        public WlAccStats(ushort e2eDelayPercent, ushort frozenRatioPercent, ushort lossRatePercent)
        {
            this.e2eDelayPercent = e2eDelayPercent;
            this.frozenRatioPercent = frozenRatioPercent;
            this.lossRatePercent = lossRatePercent;
        }
        public WlAccStats()
        {
        }
    }

    /* enum_networktype */
    public enum NETWORK_TYPE
    {
        /* enum_networktype_NETWORK_TYPE_UNKNOWN */
        NETWORK_TYPE_UNKNOWN = -1,

        /* enum_networktype_NETWORK_TYPE_DISCONNECTED */
        NETWORK_TYPE_DISCONNECTED = 0,

        /* enum_networktype_NETWORK_TYPE_LAN */
        NETWORK_TYPE_LAN = 1,

        /* enum_networktype_NETWORK_TYPE_WIFI */
        NETWORK_TYPE_WIFI = 2,

        /* enum_networktype_NETWORK_TYPE_MOBILE_2G */
        NETWORK_TYPE_MOBILE_2G = 3,

        /* enum_networktype_NETWORK_TYPE_MOBILE_3G */
        NETWORK_TYPE_MOBILE_3G = 4,

        /* enum_networktype_NETWORK_TYPE_MOBILE_4G */
        NETWORK_TYPE_MOBILE_4G = 5,
    }

    /* enum_videoviewsetupmode */
    public enum VIDEO_VIEW_SETUP_MODE
    {
        /* enum_videoviewsetupmode_VIDEO_VIEW_SETUP_REPLACE */
        VIDEO_VIEW_SETUP_REPLACE = 0,

        /* enum_videoviewsetupmode_VIDEO_VIEW_SETUP_ADD */
        VIDEO_VIEW_SETUP_ADD = 1,

        /* enum_videoviewsetupmode_VIDEO_VIEW_SETUP_REMOVE */
        VIDEO_VIEW_SETUP_REMOVE = 2,
    }

    /* class_videocanvas */
    public class VideoCanvas
    {
        /* class_videocanvas_view */
        public view_t view;

        /* class_videocanvas_uid */
        public uint uid;

        /* class_videocanvas_backgroundColor */
        public uint backgroundColor;

        /* class_videocanvas_renderMode */
        public RENDER_MODE_TYPE renderMode;

        /* class_videocanvas_mirrorMode */
        public VIDEO_MIRROR_MODE_TYPE mirrorMode;

        /* class_videocanvas_setupMode */
        public VIDEO_VIEW_SETUP_MODE setupMode;

        /* class_videocanvas_sourceType */
        public VIDEO_SOURCE_TYPE sourceType;

        /* class_videocanvas_mediaPlayerId */
        public int mediaPlayerId;

        /* class_videocanvas_cropArea */
        public Rectangle cropArea;

        /* class_videocanvas_enableAlphaMask */
        public bool enableAlphaMask;

        public VideoCanvas()
        {
            this.view = 0;
            this.uid = 0;
            this.backgroundColor = 0x00000000;
            this.renderMode = RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
            this.mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
            this.setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
            this.sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            this.mediaPlayerId = -(int)ERROR_CODE_TYPE.ERR_NOT_READY;
            this.cropArea = new Rectangle(0, 0, 0, 0);
            this.enableAlphaMask = false;
        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt, uint u)
        {
            this.view = v;
            this.uid = u;
            this.backgroundColor = 0x00000000;
            this.renderMode = m;
            this.mirrorMode = mt;
            this.setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
            this.sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            this.mediaPlayerId = -(int)ERROR_CODE_TYPE.ERR_NOT_READY;
            this.cropArea = new Rectangle(0, 0, 0, 0);
            this.enableAlphaMask = false;
        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt)
        {
            this.view = v;
            this.uid = 0;
            this.backgroundColor = 0x00000000;
            this.renderMode = m;
            this.mirrorMode = mt;
            this.setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
            this.sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            this.mediaPlayerId = -(int)ERROR_CODE_TYPE.ERR_NOT_READY;
            this.cropArea = new Rectangle(0, 0, 0, 0);
            this.enableAlphaMask = false;
        }

        public VideoCanvas(view_t view, uint uid, uint backgroundColor, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, VIDEO_VIEW_SETUP_MODE setupMode, VIDEO_SOURCE_TYPE sourceType, int mediaPlayerId, Rectangle cropArea, bool enableAlphaMask)
        {
            this.view = view;
            this.uid = uid;
            this.backgroundColor = backgroundColor;
            this.renderMode = renderMode;
            this.mirrorMode = mirrorMode;
            this.setupMode = setupMode;
            this.sourceType = sourceType;
            this.mediaPlayerId = mediaPlayerId;
            this.cropArea = cropArea;
            this.enableAlphaMask = enableAlphaMask;
        }
    }

    /* class_beautyoptions */
    public class BeautyOptions
    {
        /* class_beautyoptions_lighteningContrastLevel */
        public LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel;

        /* class_beautyoptions_lighteningLevel */
        public float lighteningLevel;

        /* class_beautyoptions_smoothnessLevel */
        public float smoothnessLevel;

        /* class_beautyoptions_rednessLevel */
        public float rednessLevel;

        /* class_beautyoptions_sharpnessLevel */
        public float sharpnessLevel;

        public BeautyOptions(LIGHTENING_CONTRAST_LEVEL contrastLevel, float lightening, float smoothness, float redness, float sharpness)
        {
            this.lighteningContrastLevel = contrastLevel;
            this.lighteningLevel = lightening;
            this.smoothnessLevel = smoothness;
            this.rednessLevel = redness;
            this.sharpnessLevel = sharpness;
        }

        public BeautyOptions()
        {
            this.lighteningContrastLevel = LIGHTENING_CONTRAST_LEVEL.LIGHTENING_CONTRAST_NORMAL;
            this.lighteningLevel = 0;
            this.smoothnessLevel = 0;
            this.rednessLevel = 0;
            this.sharpnessLevel = 0;
        }
    }

    /* enum_lighteningcontrastlevel */
    public enum LIGHTENING_CONTRAST_LEVEL
    {
        /* enum_lighteningcontrastlevel_LIGHTENING_CONTRAST_LOW */
        LIGHTENING_CONTRAST_LOW = 0,

        /* enum_lighteningcontrastlevel_LIGHTENING_CONTRAST_NORMAL */
        LIGHTENING_CONTRAST_NORMAL = 1,

        /* enum_lighteningcontrastlevel_LIGHTENING_CONTRAST_HIGH */
        LIGHTENING_CONTRAST_HIGH = 2,
    }

    /* class_lowlightenhanceoptions */
    public class LowlightEnhanceOptions
    {
        /* class_lowlightenhanceoptions_mode */
        public LOW_LIGHT_ENHANCE_MODE mode;

        /* class_lowlightenhanceoptions_level */
        public LOW_LIGHT_ENHANCE_LEVEL level;

        public LowlightEnhanceOptions(LOW_LIGHT_ENHANCE_MODE lowlightMode, LOW_LIGHT_ENHANCE_LEVEL lowlightLevel)
        {
            this.mode = lowlightMode;
            this.level = lowlightLevel;
        }

        public LowlightEnhanceOptions()
        {
            this.mode = LOW_LIGHT_ENHANCE_MODE.LOW_LIGHT_ENHANCE_AUTO;
            this.level = LOW_LIGHT_ENHANCE_LEVEL.LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY;
        }
    }

    /* enum_lowlightenhancemode */
    public enum LOW_LIGHT_ENHANCE_MODE
    {
        /* enum_lowlightenhancemode_LOW_LIGHT_ENHANCE_AUTO */
        LOW_LIGHT_ENHANCE_AUTO = 0,

        /* enum_lowlightenhancemode_LOW_LIGHT_ENHANCE_MANUAL */
        LOW_LIGHT_ENHANCE_MANUAL = 1,
    }

    /* enum_lowlightenhancelevel */
    public enum LOW_LIGHT_ENHANCE_LEVEL
    {
        /* enum_lowlightenhancelevel_LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY */
        LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY = 0,

        /* enum_lowlightenhancelevel_LOW_LIGHT_ENHANCE_LEVEL_FAST */
        LOW_LIGHT_ENHANCE_LEVEL_FAST = 1,
    }

    /* class_videodenoiseroptions */
    public class VideoDenoiserOptions
    {
        /* class_videodenoiseroptions_mode */
        public VIDEO_DENOISER_MODE mode;

        /* class_videodenoiseroptions_level */
        public VIDEO_DENOISER_LEVEL level;

        public VideoDenoiserOptions(VIDEO_DENOISER_MODE denoiserMode, VIDEO_DENOISER_LEVEL denoiserLevel)
        {
            this.mode = denoiserMode;
            this.level = denoiserLevel;
        }

        public VideoDenoiserOptions()
        {
            this.mode = VIDEO_DENOISER_MODE.VIDEO_DENOISER_AUTO;
            this.level = VIDEO_DENOISER_LEVEL.VIDEO_DENOISER_LEVEL_HIGH_QUALITY;
        }
    }

    /* enum_videodenoisermode */
    public enum VIDEO_DENOISER_MODE
    {
        /* enum_videodenoisermode_VIDEO_DENOISER_AUTO */
        VIDEO_DENOISER_AUTO = 0,

        /* enum_videodenoisermode_VIDEO_DENOISER_MANUAL */
        VIDEO_DENOISER_MANUAL = 1,
    }

    /* enum_videodenoiserlevel */
    public enum VIDEO_DENOISER_LEVEL
    {
        /* enum_videodenoiserlevel_VIDEO_DENOISER_LEVEL_HIGH_QUALITY */
        VIDEO_DENOISER_LEVEL_HIGH_QUALITY = 0,

        /* enum_videodenoiserlevel_VIDEO_DENOISER_LEVEL_FAST */
        VIDEO_DENOISER_LEVEL_FAST = 1,

        /* enum_videodenoiserlevel_VIDEO_DENOISER_LEVEL_STRENGTH */
        VIDEO_DENOISER_LEVEL_STRENGTH = 2,
    }

    /* class_colorenhanceoptions */
    public class ColorEnhanceOptions
    {
        /* class_colorenhanceoptions_strengthLevel */
        public float strengthLevel;

        /* class_colorenhanceoptions_skinProtectLevel */
        public float skinProtectLevel;

        public ColorEnhanceOptions(float stength, float skinProtect)
        {
            this.strengthLevel = stength;
            this.skinProtectLevel = skinProtect;
        }

        public ColorEnhanceOptions()
        {
            this.strengthLevel = 0;
            this.skinProtectLevel = 1;
        }
    }

    /* class_virtualbackgroundsource */
    public class VirtualBackgroundSource
    {
        /* class_virtualbackgroundsource_background_source_type */
        public BACKGROUND_SOURCE_TYPE background_source_type;

        /* class_virtualbackgroundsource_color */
        public uint color;

        /* class_virtualbackgroundsource_source */
        public string source;

        /* class_virtualbackgroundsource_blur_degree */
        public BACKGROUND_BLUR_DEGREE blur_degree;

        public VirtualBackgroundSource()
        {
            this.background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_COLOR;
            this.color = 0xffffff;
            this.source = "";
            this.blur_degree = BACKGROUND_BLUR_DEGREE.BLUR_DEGREE_HIGH;
        }

        public VirtualBackgroundSource(BACKGROUND_SOURCE_TYPE background_source_type, uint color, string source, BACKGROUND_BLUR_DEGREE blur_degree)
        {
            this.background_source_type = background_source_type;
            this.color = color;
            this.source = source;
            this.blur_degree = blur_degree;
        }
    }

    /* enum_backgroundsourcetype */
    public enum BACKGROUND_SOURCE_TYPE
    {
        /* enum_backgroundsourcetype_BACKGROUND_NONE */
        BACKGROUND_NONE = 0,

        /* enum_backgroundsourcetype_BACKGROUND_COLOR */
        BACKGROUND_COLOR = 1,

        /* enum_backgroundsourcetype_BACKGROUND_IMG */
        BACKGROUND_IMG = 2,

        /* enum_backgroundsourcetype_BACKGROUND_BLUR */
        BACKGROUND_BLUR = 3,

        /* enum_backgroundsourcetype_BACKGROUND_VIDEO */
        BACKGROUND_VIDEO = 4,
    }

    /* enum_backgroundblurdegree */
    public enum BACKGROUND_BLUR_DEGREE
    {
        /* enum_backgroundblurdegree_BLUR_DEGREE_LOW */
        BLUR_DEGREE_LOW = 1,

        /* enum_backgroundblurdegree_BLUR_DEGREE_MEDIUM */
        BLUR_DEGREE_MEDIUM = 2,

        /* enum_backgroundblurdegree_BLUR_DEGREE_HIGH */
        BLUR_DEGREE_HIGH = 3,
    }

    /* class_segmentationproperty */
    public class SegmentationProperty
    {
        /* class_segmentationproperty_modelType */
        public SEG_MODEL_TYPE modelType;

        /* class_segmentationproperty_greenCapacity */
        public float greenCapacity;

        public SegmentationProperty()
        {
            this.modelType = SEG_MODEL_TYPE.SEG_MODEL_AI;
            this.greenCapacity = 0.5f;
        }

        public SegmentationProperty(SEG_MODEL_TYPE modelType, float greenCapacity)
        {
            this.modelType = modelType;
            this.greenCapacity = greenCapacity;
        }
    }

    /* enum_segmodeltype */
    public enum SEG_MODEL_TYPE
    {
        /* enum_segmodeltype_SEG_MODEL_AI */
        SEG_MODEL_AI = 1,

        /* enum_segmodeltype_SEG_MODEL_GREEN */
        SEG_MODEL_GREEN = 2,
    }

    /* enum_audiotracktype */
    public enum AUDIO_TRACK_TYPE
    {
        /* enum_audiotracktype_AUDIO_TRACK_INVALID */
        AUDIO_TRACK_INVALID = -1,

        /* enum_audiotracktype_AUDIO_TRACK_MIXABLE */
        AUDIO_TRACK_MIXABLE = 0,

        /* enum_audiotracktype_AUDIO_TRACK_DIRECT */
        AUDIO_TRACK_DIRECT = 1,
    }

    /* class_audiotrackconfig */
    public class AudioTrackConfig
    {
        /* class_audiotrackconfig_enableLocalPlayback */
        public bool enableLocalPlayback;

        public AudioTrackConfig()
        {
            this.enableLocalPlayback = true;
        }

        public AudioTrackConfig(bool enableLocalPlayback)
        {
            this.enableLocalPlayback = enableLocalPlayback;
        }
    }

    /* enum_voicebeautifierpreset */
    public enum VOICE_BEAUTIFIER_PRESET
    {
        /* enum_voicebeautifierpreset_VOICE_BEAUTIFIER_OFF */
        VOICE_BEAUTIFIER_OFF = 0x00000000,

        /* enum_voicebeautifierpreset_CHAT_BEAUTIFIER_MAGNETIC */
        CHAT_BEAUTIFIER_MAGNETIC = 0x01010100,

        /* enum_voicebeautifierpreset_CHAT_BEAUTIFIER_FRESH */
        CHAT_BEAUTIFIER_FRESH = 0x01010200,

        /* enum_voicebeautifierpreset_CHAT_BEAUTIFIER_VITALITY */
        CHAT_BEAUTIFIER_VITALITY = 0x01010300,

        /* enum_voicebeautifierpreset_SINGING_BEAUTIFIER */
        SINGING_BEAUTIFIER = 0x01020100,

        /* enum_voicebeautifierpreset_TIMBRE_TRANSFORMATION_VIGOROUS */
        TIMBRE_TRANSFORMATION_VIGOROUS = 0x01030100,

        /* enum_voicebeautifierpreset_TIMBRE_TRANSFORMATION_DEEP */
        TIMBRE_TRANSFORMATION_DEEP = 0x01030200,

        /* enum_voicebeautifierpreset_TIMBRE_TRANSFORMATION_MELLOW */
        TIMBRE_TRANSFORMATION_MELLOW = 0x01030300,

        /* enum_voicebeautifierpreset_TIMBRE_TRANSFORMATION_FALSETTO */
        TIMBRE_TRANSFORMATION_FALSETTO = 0x01030400,

        /* enum_voicebeautifierpreset_TIMBRE_TRANSFORMATION_FULL */
        TIMBRE_TRANSFORMATION_FULL = 0x01030500,

        /* enum_voicebeautifierpreset_TIMBRE_TRANSFORMATION_CLEAR */
        TIMBRE_TRANSFORMATION_CLEAR = 0x01030600,

        /* enum_voicebeautifierpreset_TIMBRE_TRANSFORMATION_RESOUNDING */
        TIMBRE_TRANSFORMATION_RESOUNDING = 0x01030700,

        /* enum_voicebeautifierpreset_TIMBRE_TRANSFORMATION_RINGING */
        TIMBRE_TRANSFORMATION_RINGING = 0x01030800,

        /* enum_voicebeautifierpreset_ULTRA_HIGH_QUALITY_VOICE */
        ULTRA_HIGH_QUALITY_VOICE = 0x01040100,
    }

    /* enum_audioeffectpreset */
    public enum AUDIO_EFFECT_PRESET
    {
        /* enum_audioeffectpreset_AUDIO_EFFECT_OFF */
        AUDIO_EFFECT_OFF = 0x00000000,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_KTV */
        ROOM_ACOUSTICS_KTV = 0x02010100,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_VOCAL_CONCERT */
        ROOM_ACOUSTICS_VOCAL_CONCERT = 0x02010200,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_STUDIO */
        ROOM_ACOUSTICS_STUDIO = 0x02010300,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_PHONOGRAPH */
        ROOM_ACOUSTICS_PHONOGRAPH = 0x02010400,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_VIRTUAL_STEREO */
        ROOM_ACOUSTICS_VIRTUAL_STEREO = 0x02010500,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_SPACIAL */
        ROOM_ACOUSTICS_SPACIAL = 0x02010600,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_ETHEREAL */
        ROOM_ACOUSTICS_ETHEREAL = 0x02010700,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_3D_VOICE */
        ROOM_ACOUSTICS_3D_VOICE = 0x02010800,

        /* enum_audioeffectpreset_ROOM_ACOUSTICS_VIRTUAL_SURROUND_SOUND */
        ROOM_ACOUSTICS_VIRTUAL_SURROUND_SOUND = 0x02010900,

        /* enum_audioeffectpreset_VOICE_CHANGER_EFFECT_UNCLE */
        VOICE_CHANGER_EFFECT_UNCLE = 0x02020100,

        /* enum_audioeffectpreset_VOICE_CHANGER_EFFECT_OLDMAN */
        VOICE_CHANGER_EFFECT_OLDMAN = 0x02020200,

        /* enum_audioeffectpreset_VOICE_CHANGER_EFFECT_BOY */
        VOICE_CHANGER_EFFECT_BOY = 0x02020300,

        /* enum_audioeffectpreset_VOICE_CHANGER_EFFECT_SISTER */
        VOICE_CHANGER_EFFECT_SISTER = 0x02020400,

        /* enum_audioeffectpreset_VOICE_CHANGER_EFFECT_GIRL */
        VOICE_CHANGER_EFFECT_GIRL = 0x02020500,

        /* enum_audioeffectpreset_VOICE_CHANGER_EFFECT_PIGKING */
        VOICE_CHANGER_EFFECT_PIGKING = 0x02020600,

        /* enum_audioeffectpreset_VOICE_CHANGER_EFFECT_HULK */
        VOICE_CHANGER_EFFECT_HULK = 0x02020700,

        /* enum_audioeffectpreset_STYLE_TRANSFORMATION_RNB */
        STYLE_TRANSFORMATION_RNB = 0x02030100,

        /* enum_audioeffectpreset_STYLE_TRANSFORMATION_POPULAR */
        STYLE_TRANSFORMATION_POPULAR = 0x02030200,

        /* enum_audioeffectpreset_PITCH_CORRECTION */
        PITCH_CORRECTION = 0x02040100,
    }

    /* enum_voiceconversionpreset */
    public enum VOICE_CONVERSION_PRESET
    {
        /* enum_voiceconversionpreset_VOICE_CONVERSION_OFF */
        VOICE_CONVERSION_OFF = 0x00000000,

        /* enum_voiceconversionpreset_VOICE_CHANGER_NEUTRAL */
        VOICE_CHANGER_NEUTRAL = 0x03010100,

        /* enum_voiceconversionpreset_VOICE_CHANGER_SWEET */
        VOICE_CHANGER_SWEET = 0x03010200,

        /* enum_voiceconversionpreset_VOICE_CHANGER_SOLID */
        VOICE_CHANGER_SOLID = 0x03010300,

        /* enum_voiceconversionpreset_VOICE_CHANGER_BASS */
        VOICE_CHANGER_BASS = 0x03010400,

        /* enum_voiceconversionpreset_VOICE_CHANGER_CARTOON */
        VOICE_CHANGER_CARTOON = 0x03010500,

        /* enum_voiceconversionpreset_VOICE_CHANGER_CHILDLIKE */
        VOICE_CHANGER_CHILDLIKE = 0x03010600,

        /* enum_voiceconversionpreset_VOICE_CHANGER_PHONE_OPERATOR */
        VOICE_CHANGER_PHONE_OPERATOR = 0x03010700,

        /* enum_voiceconversionpreset_VOICE_CHANGER_MONSTER */
        VOICE_CHANGER_MONSTER = 0x03010800,

        /* enum_voiceconversionpreset_VOICE_CHANGER_TRANSFORMERS */
        VOICE_CHANGER_TRANSFORMERS = 0x03010900,

        /* enum_voiceconversionpreset_VOICE_CHANGER_GROOT */
        VOICE_CHANGER_GROOT = 0x03010A00,

        /* enum_voiceconversionpreset_VOICE_CHANGER_DARTH_VADER */
        VOICE_CHANGER_DARTH_VADER = 0x03010B00,

        /* enum_voiceconversionpreset_VOICE_CHANGER_IRON_LADY */
        VOICE_CHANGER_IRON_LADY = 0x03010C00,

        /* enum_voiceconversionpreset_VOICE_CHANGER_SHIN_CHAN */
        VOICE_CHANGER_SHIN_CHAN = 0x03010D00,

        /* enum_voiceconversionpreset_VOICE_CHANGER_GIRLISH_MAN */
        VOICE_CHANGER_GIRLISH_MAN = 0x03010E00,

        /* enum_voiceconversionpreset_VOICE_CHANGER_CHIPMUNK */
        VOICE_CHANGER_CHIPMUNK = 0x03010F00,
    }

    /* enum_headphoneequalizerpreset */
    public enum HEADPHONE_EQUALIZER_PRESET
    {
        /* enum_headphoneequalizerpreset_HEADPHONE_EQUALIZER_OFF */
        HEADPHONE_EQUALIZER_OFF = 0x00000000,

        /* enum_headphoneequalizerpreset_HEADPHONE_EQUALIZER_OVEREAR */
        HEADPHONE_EQUALIZER_OVEREAR = 0x04000001,

        /* enum_headphoneequalizerpreset_HEADPHONE_EQUALIZER_INEAR */
        HEADPHONE_EQUALIZER_INEAR = 0x04000002,
    }

    /* class_screencaptureparameters */
    public class ScreenCaptureParameters
    {
        /* class_screencaptureparameters_dimensions */
        public VideoDimensions dimensions;

        /* class_screencaptureparameters_frameRate */
        public int frameRate;

        /* class_screencaptureparameters_bitrate */
        public int bitrate;

        /* class_screencaptureparameters_captureMouseCursor */
        public bool captureMouseCursor;

        /* class_screencaptureparameters_windowFocus */
        public bool windowFocus;

        public view_t[] excludeWindowList;

        /* class_screencaptureparameters_excludeWindowCount */
        public int excludeWindowCount;

        /* class_screencaptureparameters_highLightWidth */
        public int highLightWidth;

        /* class_screencaptureparameters_highLightColor */
        public uint highLightColor;

        /* class_screencaptureparameters_enableHighLight */
        public bool enableHighLight;

        public ScreenCaptureParameters()
        {
            this.dimensions = new VideoDimensions(1920, 1080);
            this.frameRate = 5;
            this.bitrate = (int)BITRATE.STANDARD_BITRATE;
            this.captureMouseCursor = true;
            this.windowFocus = false;
            this.excludeWindowList = new view_t[0];
            this.excludeWindowCount = 0;
            this.highLightWidth = 0;
            this.highLightColor = 0;
            this.enableHighLight = false;
        }

        public ScreenCaptureParameters(VideoDimensions d, int f, int b)
        {
            this.dimensions = d;
            this.frameRate = f;
            this.bitrate = b;
            this.captureMouseCursor = true;
            this.windowFocus = false;
            this.excludeWindowList = new view_t[0];
            this.excludeWindowCount = 0;
            this.highLightWidth = 0;
            this.highLightColor = 0;
            this.enableHighLight = false;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b)
        {
            this.dimensions = new VideoDimensions(width, height);
            this.frameRate = f;
            this.bitrate = b;
            this.captureMouseCursor = true;
            this.windowFocus = false;
            this.excludeWindowList = new view_t[0];
            this.excludeWindowCount = 0;
            this.highLightWidth = 0;
            this.highLightColor = 0;
            this.enableHighLight = false;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, bool cur, bool fcs)
        {
            this.dimensions = new VideoDimensions(width, height);
            this.frameRate = f;
            this.bitrate = b;
            this.captureMouseCursor = cur;
            this.windowFocus = fcs;
            this.excludeWindowList = new view_t[0];
            this.excludeWindowCount = 0;
            this.highLightWidth = 0;
            this.highLightColor = 0;
            this.enableHighLight = false;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, view_t[] ex, int cnt)
        {
            this.dimensions = new VideoDimensions(width, height);
            this.frameRate = f;
            this.bitrate = b;
            this.captureMouseCursor = true;
            this.windowFocus = false;
            this.excludeWindowList = ex;
            this.excludeWindowCount = cnt;
            this.highLightWidth = 0;
            this.highLightColor = 0;
            this.enableHighLight = false;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, bool cur, bool fcs, view_t[] ex, int cnt)
        {
            this.dimensions = new VideoDimensions(width, height);
            this.frameRate = f;
            this.bitrate = b;
            this.captureMouseCursor = cur;
            this.windowFocus = fcs;
            this.excludeWindowList = ex;
            this.excludeWindowCount = cnt;
            this.highLightWidth = 0;
            this.highLightColor = 0;
            this.enableHighLight = false;
        }

        public ScreenCaptureParameters(VideoDimensions dimensions, int frameRate, int bitrate, bool captureMouseCursor, bool windowFocus, view_t[] excludeWindowList, int excludeWindowCount, int highLightWidth, uint highLightColor, bool enableHighLight)
        {
            this.dimensions = dimensions;
            this.frameRate = frameRate;
            this.bitrate = bitrate;
            this.captureMouseCursor = captureMouseCursor;
            this.windowFocus = windowFocus;
            this.excludeWindowList = excludeWindowList;
            this.excludeWindowCount = excludeWindowCount;
            this.highLightWidth = highLightWidth;
            this.highLightColor = highLightColor;
            this.enableHighLight = enableHighLight;
        }
    }

    /* enum_audiorecordingqualitytype */
    public enum AUDIO_RECORDING_QUALITY_TYPE
    {
        /* enum_audiorecordingqualitytype_AUDIO_RECORDING_QUALITY_LOW */
        AUDIO_RECORDING_QUALITY_LOW = 0,

        /* enum_audiorecordingqualitytype_AUDIO_RECORDING_QUALITY_MEDIUM */
        AUDIO_RECORDING_QUALITY_MEDIUM = 1,

        /* enum_audiorecordingqualitytype_AUDIO_RECORDING_QUALITY_HIGH */
        AUDIO_RECORDING_QUALITY_HIGH = 2,

        /* enum_audiorecordingqualitytype_AUDIO_RECORDING_QUALITY_ULTRA_HIGH */
        AUDIO_RECORDING_QUALITY_ULTRA_HIGH = 3,
    }

    /* enum_audiofilerecordingtype */
    public enum AUDIO_FILE_RECORDING_TYPE
    {
        /* enum_audiofilerecordingtype_AUDIO_FILE_RECORDING_MIC */
        AUDIO_FILE_RECORDING_MIC = 1,

        /* enum_audiofilerecordingtype_AUDIO_FILE_RECORDING_PLAYBACK */
        AUDIO_FILE_RECORDING_PLAYBACK = 2,

        /* enum_audiofilerecordingtype_AUDIO_FILE_RECORDING_MIXED */
        AUDIO_FILE_RECORDING_MIXED = 3,
    }

    /* enum_audioencodedframeobserverposition */
    public enum AUDIO_ENCODED_FRAME_OBSERVER_POSITION
    {
        /* enum_audioencodedframeobserverposition_AUDIO_ENCODED_FRAME_OBSERVER_POSITION_RECORD */
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_RECORD = 1,

        /* enum_audioencodedframeobserverposition_AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK */
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK = 2,

        /* enum_audioencodedframeobserverposition_AUDIO_ENCODED_FRAME_OBSERVER_POSITION_MIXED */
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_MIXED = 3,
    }

    /* class_audiorecordingconfiguration */
    public class AudioRecordingConfiguration
    {
        /* class_audiorecordingconfiguration_filePath */
        public string filePath;

        /* class_audiorecordingconfiguration_encode */
        public bool encode;

        /* class_audiorecordingconfiguration_sampleRate */
        public int sampleRate;

        /* class_audiorecordingconfiguration_fileRecordingType */
        public AUDIO_FILE_RECORDING_TYPE fileRecordingType;

        /* class_audiorecordingconfiguration_quality */
        public AUDIO_RECORDING_QUALITY_TYPE quality;

        /* class_audiorecordingconfiguration_recordingChannel */
        public int recordingChannel;

        public AudioRecordingConfiguration()
        {
            this.filePath = "";
            this.encode = false;
            this.sampleRate = 32000;
            this.fileRecordingType = AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIXED;
            this.quality = AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_LOW;
            this.recordingChannel = 1;
        }

        public AudioRecordingConfiguration(string file_path, int sample_rate, AUDIO_RECORDING_QUALITY_TYPE quality_type, int channel)
        {
            this.filePath = file_path;
            this.encode = false;
            this.sampleRate = sample_rate;
            this.fileRecordingType = AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIXED;
            this.quality = quality_type;
            this.recordingChannel = channel;
        }

        public AudioRecordingConfiguration(string file_path, bool enc, int sample_rate, AUDIO_FILE_RECORDING_TYPE type, AUDIO_RECORDING_QUALITY_TYPE quality_type, int channel)
        {
            this.filePath = file_path;
            this.encode = enc;
            this.sampleRate = sample_rate;
            this.fileRecordingType = type;
            this.quality = quality_type;
            this.recordingChannel = channel;
        }

        public AudioRecordingConfiguration(AudioRecordingConfiguration rhs)
        {
            this.filePath = rhs.filePath;
            this.encode = rhs.encode;
            this.sampleRate = rhs.sampleRate;
            this.fileRecordingType = rhs.fileRecordingType;
            this.quality = rhs.quality;
            this.recordingChannel = rhs.recordingChannel;
        }
    }

    /* class_audioencodedframeobserverconfig */
    public class AudioEncodedFrameObserverConfig
    {
        /* class_audioencodedframeobserverconfig_postionType */
        public AUDIO_ENCODED_FRAME_OBSERVER_POSITION postionType;

        /* class_audioencodedframeobserverconfig_encodingType */
        public AUDIO_ENCODING_TYPE encodingType;

        public AudioEncodedFrameObserverConfig()
        {
            this.postionType = AUDIO_ENCODED_FRAME_OBSERVER_POSITION.AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK;
            this.encodingType = AUDIO_ENCODING_TYPE.AUDIO_ENCODING_TYPE_OPUS_48000_MEDIUM;
        }

        public AudioEncodedFrameObserverConfig(AUDIO_ENCODED_FRAME_OBSERVER_POSITION postionType, AUDIO_ENCODING_TYPE encodingType)
        {
            this.postionType = postionType;
            this.encodingType = encodingType;
        }
    }

    /* enum_areacode */
    public enum AREA_CODE : uint
    {
        /* enum_areacode_AREA_CODE_CN */
        AREA_CODE_CN = 0x00000001,

        /* enum_areacode_AREA_CODE_NA */
        AREA_CODE_NA = 0x00000002,

        /* enum_areacode_AREA_CODE_EU */
        AREA_CODE_EU = 0x00000004,

        /* enum_areacode_AREA_CODE_AS */
        AREA_CODE_AS = 0x00000008,

        /* enum_areacode_AREA_CODE_JP */
        AREA_CODE_JP = 0x00000010,

        /* enum_areacode_AREA_CODE_IN */
        AREA_CODE_IN = 0x00000020,

        /* enum_areacode_AREA_CODE_GLOB */
        AREA_CODE_GLOB = (0xFFFFFFFF),
    }

    /* enum_areacodeex */
    public enum AREA_CODE_EX : uint
    {
        /* enum_areacodeex_AREA_CODE_OC */
        AREA_CODE_OC = 0x00000040,

        /* enum_areacodeex_AREA_CODE_SA */
        AREA_CODE_SA = 0x00000080,

        /* enum_areacodeex_AREA_CODE_AF */
        AREA_CODE_AF = 0x00000100,

        /* enum_areacodeex_AREA_CODE_KR */
        AREA_CODE_KR = 0x00000200,

        /* enum_areacodeex_AREA_CODE_HKMC */
        AREA_CODE_HKMC = 0x00000400,

        /* enum_areacodeex_AREA_CODE_US */
        AREA_CODE_US = 0x00000800,

        /* enum_areacodeex_AREA_CODE_OVS */
        AREA_CODE_OVS = 0xFFFFFFFE,
    }

    /* enum_channelmediarelayerror */
    public enum CHANNEL_MEDIA_RELAY_ERROR
    {
        /* enum_channelmediarelayerror_RELAY_OK */
        RELAY_OK = 0,

        /* enum_channelmediarelayerror_RELAY_ERROR_SERVER_ERROR_RESPONSE */
        RELAY_ERROR_SERVER_ERROR_RESPONSE = 1,

        /* enum_channelmediarelayerror_RELAY_ERROR_SERVER_NO_RESPONSE */
        RELAY_ERROR_SERVER_NO_RESPONSE = 2,

        /* enum_channelmediarelayerror_RELAY_ERROR_NO_RESOURCE_AVAILABLE */
        RELAY_ERROR_NO_RESOURCE_AVAILABLE = 3,

        /* enum_channelmediarelayerror_RELAY_ERROR_FAILED_JOIN_SRC */
        RELAY_ERROR_FAILED_JOIN_SRC = 4,

        /* enum_channelmediarelayerror_RELAY_ERROR_FAILED_JOIN_DEST */
        RELAY_ERROR_FAILED_JOIN_DEST = 5,

        /* enum_channelmediarelayerror_RELAY_ERROR_FAILED_PACKET_RECEIVED_FROM_SRC */
        RELAY_ERROR_FAILED_PACKET_RECEIVED_FROM_SRC = 6,

        /* enum_channelmediarelayerror_RELAY_ERROR_FAILED_PACKET_SENT_TO_DEST */
        RELAY_ERROR_FAILED_PACKET_SENT_TO_DEST = 7,

        /* enum_channelmediarelayerror_RELAY_ERROR_SERVER_CONNECTION_LOST */
        RELAY_ERROR_SERVER_CONNECTION_LOST = 8,

        /* enum_channelmediarelayerror_RELAY_ERROR_INTERNAL_ERROR */
        RELAY_ERROR_INTERNAL_ERROR = 9,

        /* enum_channelmediarelayerror_RELAY_ERROR_SRC_TOKEN_EXPIRED */
        RELAY_ERROR_SRC_TOKEN_EXPIRED = 10,

        /* enum_channelmediarelayerror_RELAY_ERROR_DEST_TOKEN_EXPIRED */
        RELAY_ERROR_DEST_TOKEN_EXPIRED = 11,
    }

    /* enum_channelmediarelayevent */
    public enum CHANNEL_MEDIA_RELAY_EVENT
    {
        /* enum_channelmediarelayevent_RELAY_EVENT_NETWORK_DISCONNECTED */
        RELAY_EVENT_NETWORK_DISCONNECTED = 0,

        /* enum_channelmediarelayevent_RELAY_EVENT_NETWORK_CONNECTED */
        RELAY_EVENT_NETWORK_CONNECTED = 1,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_JOINED_SRC_CHANNEL */
        RELAY_EVENT_PACKET_JOINED_SRC_CHANNEL = 2,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_JOINED_DEST_CHANNEL */
        RELAY_EVENT_PACKET_JOINED_DEST_CHANNEL = 3,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL */
        RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL = 4,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_RECEIVED_VIDEO_FROM_SRC */
        RELAY_EVENT_PACKET_RECEIVED_VIDEO_FROM_SRC = 5,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_RECEIVED_AUDIO_FROM_SRC */
        RELAY_EVENT_PACKET_RECEIVED_AUDIO_FROM_SRC = 6,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL */
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL = 7,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_REFUSED */
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_REFUSED = 8,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_NOT_CHANGE */
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_NOT_CHANGE = 9,

        /* enum_channelmediarelayevent_RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_IS_NULL */
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_IS_NULL = 10,

        /* enum_channelmediarelayevent_RELAY_EVENT_VIDEO_PROFILE_UPDATE */
        RELAY_EVENT_VIDEO_PROFILE_UPDATE = 11,

        /* enum_channelmediarelayevent_RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS */
        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 12,

        /* enum_channelmediarelayevent_RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_FAILED */
        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 13,

        /* enum_channelmediarelayevent_RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS */
        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 14,

        /* enum_channelmediarelayevent_RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_FAILED */
        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 15,
    }

    /* enum_channelmediarelaystate */
    public enum CHANNEL_MEDIA_RELAY_STATE
    {
        /* enum_channelmediarelaystate_RELAY_STATE_IDLE */
        RELAY_STATE_IDLE = 0,

        /* enum_channelmediarelaystate_RELAY_STATE_CONNECTING */
        RELAY_STATE_CONNECTING = 1,

        /* enum_channelmediarelaystate_RELAY_STATE_RUNNING */
        RELAY_STATE_RUNNING = 2,

        /* enum_channelmediarelaystate_RELAY_STATE_FAILURE */
        RELAY_STATE_FAILURE = 3,
    }

    /* class_channelmediainfo */
    public class ChannelMediaInfo
    {
        /* class_channelmediainfo_channelName */
        public string channelName;

        /* class_channelmediainfo_token */
        public string token;

        /* class_channelmediainfo_uid */
        public uint uid;

        public ChannelMediaInfo(string channelName, string token, uint uid)
        {
            this.channelName = channelName;
            this.token = token;
            this.uid = uid;
        }
        public ChannelMediaInfo()
        {
        }
    }

    /* class_channelmediarelayconfiguration */
    public class ChannelMediaRelayConfiguration
    {
        public ChannelMediaInfo[] srcInfo;

        public ChannelMediaInfo[] destInfos;

        /* class_channelmediarelayconfiguration_destCount */
        public int destCount;

        public ChannelMediaRelayConfiguration()
        {
            this.srcInfo = new ChannelMediaInfo[0];
            this.destInfos = new ChannelMediaInfo[0];
            this.destCount = 0;
        }

        public ChannelMediaRelayConfiguration(ChannelMediaInfo[] srcInfo, ChannelMediaInfo[] destInfos, int destCount)
        {
            this.srcInfo = srcInfo;
            this.destInfos = destInfos;
            this.destCount = destCount;
        }
    }

    /* class_uplinknetworkinfo */
    public class UplinkNetworkInfo
    {
        /* class_uplinknetworkinfo_video_encoder_target_bitrate_bps */
        public int video_encoder_target_bitrate_bps;

        public UplinkNetworkInfo()
        {
            this.video_encoder_target_bitrate_bps = 0;
        }

        public UplinkNetworkInfo(int video_encoder_target_bitrate_bps)
        {
            this.video_encoder_target_bitrate_bps = video_encoder_target_bitrate_bps;
        }
    }

    /* class_peerdownlinkinfo */
    public class PeerDownlinkInfo
    {
        /* class_peerdownlinkinfo_uid */
        public string uid;

        /* class_peerdownlinkinfo_stream_type */
        public VIDEO_STREAM_TYPE stream_type;

        /* class_peerdownlinkinfo_current_downscale_level */
        public REMOTE_VIDEO_DOWNSCALE_LEVEL current_downscale_level;

        /* class_peerdownlinkinfo_expected_bitrate_bps */
        public int expected_bitrate_bps;

        public PeerDownlinkInfo()
        {
            this.uid = "";
            this.stream_type = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
            this.current_downscale_level = REMOTE_VIDEO_DOWNSCALE_LEVEL.REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE;
            this.expected_bitrate_bps = -1;
        }

        public PeerDownlinkInfo(string uid, VIDEO_STREAM_TYPE stream_type, REMOTE_VIDEO_DOWNSCALE_LEVEL current_downscale_level, int expected_bitrate_bps)
        {
            this.uid = uid;
            this.stream_type = stream_type;
            this.current_downscale_level = current_downscale_level;
            this.expected_bitrate_bps = expected_bitrate_bps;
        }
    }

    /* enum_encryptionmode */
    public enum ENCRYPTION_MODE
    {
        /* enum_encryptionmode_AES_128_XTS */
        AES_128_XTS = 1,

        /* enum_encryptionmode_AES_128_ECB */
        AES_128_ECB = 2,

        /* enum_encryptionmode_AES_256_XTS */
        AES_256_XTS = 3,

        /* enum_encryptionmode_SM4_128_ECB */
        SM4_128_ECB = 4,

        /* enum_encryptionmode_AES_128_GCM */
        AES_128_GCM = 5,

        /* enum_encryptionmode_AES_256_GCM */
        AES_256_GCM = 6,

        /* enum_encryptionmode_AES_128_GCM2 */
        AES_128_GCM2 = 7,

        /* enum_encryptionmode_AES_256_GCM2 */
        AES_256_GCM2 = 8,

        /* enum_encryptionmode_MODE_END */
        MODE_END,
    }

    /* enum_encryptionerrortype */
    public enum ENCRYPTION_ERROR_TYPE
    {
        /* enum_encryptionerrortype_ENCRYPTION_ERROR_INTERNAL_FAILURE */
        ENCRYPTION_ERROR_INTERNAL_FAILURE = 0,

        /* enum_encryptionerrortype_ENCRYPTION_ERROR_DECRYPTION_FAILURE */
        ENCRYPTION_ERROR_DECRYPTION_FAILURE = 1,

        /* enum_encryptionerrortype_ENCRYPTION_ERROR_ENCRYPTION_FAILURE */
        ENCRYPTION_ERROR_ENCRYPTION_FAILURE = 2,
    }

    /* enum_uploaderrorreason */
    public enum UPLOAD_ERROR_REASON
    {
        /* enum_uploaderrorreason_UPLOAD_SUCCESS */
        UPLOAD_SUCCESS = 0,

        /* enum_uploaderrorreason_UPLOAD_NET_ERROR */
        UPLOAD_NET_ERROR = 1,

        /* enum_uploaderrorreason_UPLOAD_SERVER_ERROR */
        UPLOAD_SERVER_ERROR = 2,
    }

    /* enum_permissiontype */
    public enum PERMISSION_TYPE
    {
        /* enum_permissiontype_RECORD_AUDIO */
        RECORD_AUDIO = 0,

        /* enum_permissiontype_CAMERA */
        CAMERA = 1,

        /* enum_permissiontype_SCREEN_CAPTURE */
        SCREEN_CAPTURE = 2,
    }

    /* enum_maxuseraccountlengthtype */
    public enum MAX_USER_ACCOUNT_LENGTH_TYPE
    {
        /* enum_maxuseraccountlengthtype_MAX_USER_ACCOUNT_LENGTH */
        MAX_USER_ACCOUNT_LENGTH = 256,
    }

    /* enum_streamsubscribestate */
    public enum STREAM_SUBSCRIBE_STATE
    {
        /* enum_streamsubscribestate_SUB_STATE_IDLE */
        SUB_STATE_IDLE = 0,

        /* enum_streamsubscribestate_SUB_STATE_NO_SUBSCRIBED */
        SUB_STATE_NO_SUBSCRIBED = 1,

        /* enum_streamsubscribestate_SUB_STATE_SUBSCRIBING */
        SUB_STATE_SUBSCRIBING = 2,

        /* enum_streamsubscribestate_SUB_STATE_SUBSCRIBED */
        SUB_STATE_SUBSCRIBED = 3,
    }

    /* enum_streampublishstate */
    public enum STREAM_PUBLISH_STATE
    {
        /* enum_streampublishstate_PUB_STATE_IDLE */
        PUB_STATE_IDLE = 0,

        /* enum_streampublishstate_PUB_STATE_NO_PUBLISHED */
        PUB_STATE_NO_PUBLISHED = 1,

        /* enum_streampublishstate_PUB_STATE_PUBLISHING */
        PUB_STATE_PUBLISHING = 2,

        /* enum_streampublishstate_PUB_STATE_PUBLISHED */
        PUB_STATE_PUBLISHED = 3,
    }

    /* class_echotestconfiguration */
    public class EchoTestConfiguration
    {
        /* class_echotestconfiguration_view */
        public view_t view;

        /* class_echotestconfiguration_enableAudio */
        public bool enableAudio;

        /* class_echotestconfiguration_enableVideo */
        public bool enableVideo;

        /* class_echotestconfiguration_token */
        public string token;

        /* class_echotestconfiguration_channelId */
        public string channelId;

        /* class_echotestconfiguration_intervalInSeconds */
        public int intervalInSeconds;

        public EchoTestConfiguration(view_t v, bool ea, bool ev, string t, string c, int @is)
        {
            this.view = v;
            this.enableAudio = ea;
            this.enableVideo = ev;
            this.token = t;
            this.channelId = c;
            this.intervalInSeconds = @is;
        }

        public EchoTestConfiguration()
        {
            this.view = 0;
            this.enableAudio = true;
            this.enableVideo = true;
            this.token = "";
            this.channelId = "";
            this.intervalInSeconds = 2;
        }
    }

    /* enum_earmonitoringfiltertype */
    public enum EAR_MONITORING_FILTER_TYPE
    {
        /* enum_earmonitoringfiltertype_EAR_MONITORING_FILTER_NONE */
        EAR_MONITORING_FILTER_NONE = (1 << 0),

        /* enum_earmonitoringfiltertype_EAR_MONITORING_FILTER_BUILT_IN_AUDIO_FILTERS */
        EAR_MONITORING_FILTER_BUILT_IN_AUDIO_FILTERS = (1 << 1),

        /* enum_earmonitoringfiltertype_EAR_MONITORING_FILTER_NOISE_SUPPRESSION */
        EAR_MONITORING_FILTER_NOISE_SUPPRESSION = (1 << 2),
    }

    /* enum_threadprioritytype */
    public enum THREAD_PRIORITY_TYPE
    {
        /* enum_threadprioritytype_LOWEST */
        LOWEST = 0,

        /* enum_threadprioritytype_LOW */
        LOW = 1,

        /* enum_threadprioritytype_NORMAL */
        NORMAL = 2,

        /* enum_threadprioritytype_HIGH */
        HIGH = 3,

        /* enum_threadprioritytype_HIGHEST */
        HIGHEST = 4,

        /* enum_threadprioritytype_CRITICAL */
        CRITICAL = 5,
    }

    /* class_screenvideoparameters */
    public class ScreenVideoParameters
    {
        /* class_screenvideoparameters_dimensions */
        public VideoDimensions dimensions;

        /* class_screenvideoparameters_frameRate */
        public int frameRate;

        /* class_screenvideoparameters_bitrate */
        public int bitrate;

        /* class_screenvideoparameters_contentHint */
        public VIDEO_CONTENT_HINT contentHint;

        public ScreenVideoParameters()
        {
            this.dimensions = new VideoDimensions(1280, 720);
        }

        public ScreenVideoParameters(VideoDimensions dimensions, int frameRate, int bitrate, VIDEO_CONTENT_HINT contentHint)
        {
            this.dimensions = dimensions;
            this.frameRate = frameRate;
            this.bitrate = bitrate;
            this.contentHint = contentHint;
        }
    }

    /* class_screenaudioparameters */
    public class ScreenAudioParameters
    {
        /* class_screenaudioparameters_sampleRate */
        public int sampleRate;

        /* class_screenaudioparameters_channels */
        public int channels;

        /* class_screenaudioparameters_captureSignalVolume */
        public int captureSignalVolume;

        public ScreenAudioParameters(int sampleRate, int channels, int captureSignalVolume)
        {
            this.sampleRate = sampleRate;
            this.channels = channels;
            this.captureSignalVolume = captureSignalVolume;
        }
        public ScreenAudioParameters()
        {
        }
    }

    /* class_screencaptureparameters2 */
    public class ScreenCaptureParameters2
    {
        /* class_screencaptureparameters2_captureAudio */
        public bool captureAudio;

        /* class_screencaptureparameters2_audioParams */
        public ScreenAudioParameters audioParams;

        /* class_screencaptureparameters2_captureVideo */
        public bool captureVideo;

        /* class_screencaptureparameters2_videoParams */
        public ScreenVideoParameters videoParams;

        public ScreenCaptureParameters2(bool captureAudio, ScreenAudioParameters audioParams, bool captureVideo, ScreenVideoParameters videoParams)
        {
            this.captureAudio = captureAudio;
            this.audioParams = audioParams;
            this.captureVideo = captureVideo;
            this.videoParams = videoParams;
        }
        public ScreenCaptureParameters2()
        {
        }
    }

    /* enum_mediatraceevent */
    public enum MEDIA_TRACE_EVENT
    {
        /* enum_mediatraceevent_MEDIA_TRACE_EVENT_VIDEO_RENDERED */
        MEDIA_TRACE_EVENT_VIDEO_RENDERED = 0,

        /* enum_mediatraceevent_MEDIA_TRACE_EVENT_VIDEO_DECODED */
        MEDIA_TRACE_EVENT_VIDEO_DECODED,
    }

    /* class_videorenderingtracinginfo */
    public class VideoRenderingTracingInfo
    {
        /* class_videorenderingtracinginfo_elapsedTime */
        public int elapsedTime;

        /* class_videorenderingtracinginfo_start2JoinChannel */
        public int start2JoinChannel;

        /* class_videorenderingtracinginfo_join2JoinSuccess */
        public int join2JoinSuccess;

        /* class_videorenderingtracinginfo_joinSuccess2RemoteJoined */
        public int joinSuccess2RemoteJoined;

        /* class_videorenderingtracinginfo_remoteJoined2SetView */
        public int remoteJoined2SetView;

        /* class_videorenderingtracinginfo_remoteJoined2UnmuteVideo */
        public int remoteJoined2UnmuteVideo;

        /* class_videorenderingtracinginfo_remoteJoined2PacketReceived */
        public int remoteJoined2PacketReceived;

        public VideoRenderingTracingInfo(int elapsedTime, int start2JoinChannel, int join2JoinSuccess, int joinSuccess2RemoteJoined, int remoteJoined2SetView, int remoteJoined2UnmuteVideo, int remoteJoined2PacketReceived)
        {
            this.elapsedTime = elapsedTime;
            this.start2JoinChannel = start2JoinChannel;
            this.join2JoinSuccess = join2JoinSuccess;
            this.joinSuccess2RemoteJoined = joinSuccess2RemoteJoined;
            this.remoteJoined2SetView = remoteJoined2SetView;
            this.remoteJoined2UnmuteVideo = remoteJoined2UnmuteVideo;
            this.remoteJoined2PacketReceived = remoteJoined2PacketReceived;
        }
        public VideoRenderingTracingInfo()
        {
        }
    }

    /* enum_configfetchtype */
    public enum CONFIG_FETCH_TYPE
    {
        /* enum_configfetchtype_CONFIG_FETCH_TYPE_INITIALIZE */
        CONFIG_FETCH_TYPE_INITIALIZE = 1,

        /* enum_configfetchtype_CONFIG_FETCH_TYPE_JOIN_CHANNEL */
        CONFIG_FETCH_TYPE_JOIN_CHANNEL = 2,
    }

    /* class_recorderstreaminfo */
    public class RecorderStreamInfo
    {
        /* class_recorderstreaminfo_channelId */
        public string channelId;

        /* class_recorderstreaminfo_uid */
        public uint uid;

        public RecorderStreamInfo()
        {
            this.channelId = "";
            this.uid = 0;
        }

        public RecorderStreamInfo(string channelId, uint uid)
        {
            this.channelId = channelId;
            this.uid = uid;
        }
    }

    /* enum_localproxymode */
    public enum LOCAL_PROXY_MODE
    {
        /* enum_localproxymode_ConnectivityFirst */
        ConnectivityFirst = 0,

        /* enum_localproxymode_LocalOnly */
        LocalOnly = 1,
    }

    /* class_loguploadserverinfo */
    public class LogUploadServerInfo
    {
        /* class_loguploadserverinfo_serverDomain */
        public string serverDomain;

        /* class_loguploadserverinfo_serverPath */
        public string serverPath;

        /* class_loguploadserverinfo_serverPort */
        public int serverPort;

        /* class_loguploadserverinfo_serverHttps */
        public bool serverHttps;

        public LogUploadServerInfo()
        {
            this.serverDomain = "";
            this.serverPath = "";
            this.serverPort = 0;
            this.serverHttps = true;
        }

        public LogUploadServerInfo(string domain, string path, int port, bool https)
        {
            this.serverDomain = domain;
            this.serverPath = path;
            this.serverPort = port;
            this.serverHttps = https;
        }
    }

    /* class_advancedconfiginfo */
    public class AdvancedConfigInfo
    {
        /* class_advancedconfiginfo_logUploadServer */
        public LogUploadServerInfo logUploadServer;

        public AdvancedConfigInfo(LogUploadServerInfo logUploadServer)
        {
            this.logUploadServer = logUploadServer;
        }
        public AdvancedConfigInfo()
        {
        }
    }

    /* class_localaccesspointconfiguration */
    public class LocalAccessPointConfiguration
    {
        public string[] ipList;

        /* class_localaccesspointconfiguration_ipListSize */
        public int ipListSize;

        public string[] domainList;

        /* class_localaccesspointconfiguration_domainListSize */
        public int domainListSize;

        /* class_localaccesspointconfiguration_verifyDomainName */
        public string verifyDomainName;

        /* class_localaccesspointconfiguration_mode */
        public LOCAL_PROXY_MODE mode;

        /* class_localaccesspointconfiguration_advancedConfig */
        public AdvancedConfigInfo advancedConfig;

        public LocalAccessPointConfiguration()
        {
            this.ipList = new string[0];
            this.ipListSize = 0;
            this.domainList = new string[0];
            this.domainListSize = 0;
            this.verifyDomainName = "";
            this.mode = LOCAL_PROXY_MODE.ConnectivityFirst;
        }

        public LocalAccessPointConfiguration(string[] ipList, int ipListSize, string[] domainList, int domainListSize, string verifyDomainName, LOCAL_PROXY_MODE mode, AdvancedConfigInfo advancedConfig)
        {
            this.ipList = ipList;
            this.ipListSize = ipListSize;
            this.domainList = domainList;
            this.domainListSize = domainListSize;
            this.verifyDomainName = verifyDomainName;
            this.mode = mode;
            this.advancedConfig = advancedConfig;
        }
    }

    /* class_spatialaudioparams */
    public class SpatialAudioParams : OptionalJsonParse
    {
        /* class_spatialaudioparams_speaker_azimuth */
        public Optional<double> speaker_azimuth = new Optional<double>();

        /* class_spatialaudioparams_speaker_elevation */
        public Optional<double> speaker_elevation = new Optional<double>();

        /* class_spatialaudioparams_speaker_distance */
        public Optional<double> speaker_distance = new Optional<double>();

        /* class_spatialaudioparams_speaker_orientation */
        public Optional<int> speaker_orientation = new Optional<int>();

        /* class_spatialaudioparams_enable_blur */
        public Optional<bool> enable_blur = new Optional<bool>();

        /* class_spatialaudioparams_enable_air_absorb */
        public Optional<bool> enable_air_absorb = new Optional<bool>();

        /* class_spatialaudioparams_speaker_attenuation */
        public Optional<double> speaker_attenuation = new Optional<double>();

        /* class_spatialaudioparams_enable_doppler */
        public Optional<bool> enable_doppler = new Optional<bool>();

        public SpatialAudioParams(Optional<double> speaker_azimuth, Optional<double> speaker_elevation, Optional<double> speaker_distance, Optional<int> speaker_orientation, Optional<bool> enable_blur, Optional<bool> enable_air_absorb, Optional<double> speaker_attenuation, Optional<bool> enable_doppler)
        {
            this.speaker_azimuth = speaker_azimuth;
            this.speaker_elevation = speaker_elevation;
            this.speaker_distance = speaker_distance;
            this.speaker_orientation = speaker_orientation;
            this.enable_blur = enable_blur;
            this.enable_air_absorb = enable_air_absorb;
            this.speaker_attenuation = speaker_attenuation;
            this.enable_doppler = enable_doppler;
        }
        public SpatialAudioParams()
        {
        }

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

            if (this.speaker_attenuation.HasValue())
            {
                writer.WritePropertyName("speaker_attenuation");
                writer.Write(this.speaker_attenuation.GetValue());
            }

            if (this.enable_doppler.HasValue())
            {
                writer.WritePropertyName("enable_doppler");
                writer.Write(this.enable_doppler.GetValue());
            }

            writer.WriteObjectEnd();
        }
    }

#endregion terra AgoraBase.h
}