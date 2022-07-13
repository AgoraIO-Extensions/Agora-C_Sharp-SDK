using System;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    using int64_t = Int64;
    using view_t = UInt64;
    using uint64_t = UInt64;

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

    public enum CHANNEL_PROFILE_TYPE
    {
        CHANNEL_PROFILE_COMMUNICATION = 0,

        CHANNEL_PROFILE_LIVE_BROADCASTING = 1,

        [Obsolete]
        CHANNEL_PROFILE_GAME = 2,

        [Obsolete]
        CHANNEL_PROFILE_CLOUD_GAMING = 3,

        [Obsolete]
        CHANNEL_PROFILE_COMMUNICATION_1v1 = 4,
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

    enum ERROR_CODE_TYPE
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
        ERR_MODULE_NOT_FOUND = 157,
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
        [Obsolete]
        ERR_ADM_IOS_SESSION_SAMPLERATR_ZERO  = 1221,
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

    public enum AUDIO_SESSION_OPERATION_RESTRICTION
    {
        AUDIO_SESSION_OPERATION_RESTRICTION_NONE = 0,

        AUDIO_SESSION_OPERATION_RESTRICTION_SET_CATEGORY = 1,

        AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION = 1 << 1,

        AUDIO_SESSION_OPERATION_RESTRICTION_DEACTIVATE_SESSION = 1 << 2,

        AUDIO_SESSION_OPERATION_RESTRICTION_ALL = 1 << 7,
    };

    public enum USER_OFFLINE_REASON_TYPE
    {
        USER_OFFLINE_QUIT = 0,

        USER_OFFLINE_DROPPED = 1,

        USER_OFFLINE_BECOME_AUDIENCE = 2,
    };

    public enum INTERFACE_ID_TYPE
    {
        AGORA_IID_AUDIO_DEVICE_MANAGER = 1,

        AGORA_IID_VIDEO_DEVICE_MANAGER = 2,

        AGORA_IID_PARAMETER_ENGINE = 3,

        AGORA_IID_MEDIA_ENGINE = 4,

        AGORA_IID_AUDIO_ENGINE = 5,

        AGORA_IID_VIDEO_ENGINE = 6,

        AGORA_IID_RTC_CONNECTION = 7,

        AGORA_IID_SIGNALING_ENGINE = 8,

        AGORA_IID_MEDIA_ENGINE_REGULATOR = 9,

        AGORA_IID_CLOUD_SPATIAL_AUDIO = 10,

        AGORA_IID_LOCAL_SPATIAL_AUDIO = 11,

        AGORA_IID_MEDIA_RECORDER = 12,
    };

    public enum QUALITY_TYPE
    {
        [Obsolete("This member is deprecated")]
        QUALITY_UNKNOWN = 0,

        QUALITY_EXCELLENT = 1,

        QUALITY_GOOD = 2,

        QUALITY_POOR = 3,

        QUALITY_BAD = 4,

        QUALITY_VBAD = 5,

        QUALITY_DOWN = 6,

        QUALITY_UNSUPPORTED = 7,

        QUALITY_DETECTING = 8
    };

    public enum FIT_MODE_TYPE
    {
        MODE_COVER = 1,

        MODE_CONTAIN = 2,
    };

    public enum VIDEO_ORIENTATION
    {
        VIDEO_ORIENTATION_0 = 0,

        VIDEO_ORIENTATION_90 = 90,

        VIDEO_ORIENTATION_180 = 180,

        VIDEO_ORIENTATION_270 = 270
    };

    public enum FRAME_RATE
    {
        FRAME_RATE_FPS_1 = 1,

        FRAME_RATE_FPS_7 = 7,

        FRAME_RATE_FPS_10 = 10,

        FRAME_RATE_FPS_15 = 15,

        FRAME_RATE_FPS_24 = 24,

        FRAME_RATE_FPS_30 = 30,

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

    public enum VIDEO_FRAME_TYPE
    {
        VIDEO_FRAME_TYPE_BLANK_FRAME = 0,

        VIDEO_FRAME_TYPE_KEY_FRAME = 3,

        VIDEO_FRAME_TYPE_DELTA_FRAME = 4,

        VIDEO_FRAME_TYPE_B_FRAME = 5,

        VIDEO_FRAME_TYPE_DROPPABLE_FRAME = 6,

        VIDEO_FRAME_TYPE_UNKNOW = 7
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

    public enum ORIENTATION_MODE
    {
        ORIENTATION_MODE_ADAPTIVE = 0,

        ORIENTATION_MODE_FIXED_LANDSCAPE = 1,

        ORIENTATION_MODE_FIXED_PORTRAIT = 2,
    };

    public enum DEGRADATION_PREFERENCE
    {
        MAINTAIN_QUALITY = 0,

        MAINTAIN_FRAMERATE = 1,

        MAINTAIN_BALANCED = 2,

        MAINTAIN_RESOLUTION = 3,

        DISABLED = 100,
    };

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

        public int width { set; get; }

        public int height { set; get; }
    };

    public enum BITRATE
    {
        STANDARD_BITRATE = 0,
    
        COMPATIBLE_BITRATE = -1,

        DEFAULT_MIN_BITRATE = -1,

        DEFAULT_MIN_BITRATE_EQUAL_TO_TARGET_BITRATE = -2,
    };

    public enum VIDEO_CODEC_TYPE
    {
        VIDEO_CODEC_NONE = 0,

        VIDEO_CODEC_VP8 = 1,

        VIDEO_CODEC_H264 = 2,

        VIDEO_CODEC_H265 = 3,

        VIDEO_CODEC_VP9 = 5,

        VIDEO_CODEC_GENERIC = 6,

        VIDEO_CODEC_GENERIC_H264 = 7,

        VIDEO_CODEC_AV1 = 12,

        VIDEO_CODEC_GENERIC_JPEG = 20,
    };

    public enum TCcMode
    {
        CC_ENABLED,

        CC_DISABLED,
    };


    public class SenderOptions
    {
        public TCcMode ccMode { set; get; }

        public VIDEO_CODEC_TYPE codecType { set; get; }
        
        public int targetBitrate { set; get; }

        public SenderOptions()
        {
            ccMode = TCcMode.CC_ENABLED;
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_GENERIC_H264;
            targetBitrate = 6500;
        }
    };

    public enum AUDIO_CODEC_TYPE
    {
        AUDIO_CODEC_OPUS = 1,

        // kIsac = 2,
        AUDIO_CODEC_PCMA = 3,

        AUDIO_CODEC_PCMU = 4,

        AUDIO_CODEC_G722 = 5,
        // kIlbc = 6,
        // AUDIO_CODEC_AAC = 7,
        AUDIO_CODEC_AACLC = 8,

        AUDIO_CODEC_HEAAC = 9,

        AUDIO_CODEC_JC1 = 10,

        AUDIO_CODEC_HEAAC2 = 11,

        AUDIO_CODEC_LPCNET = 12,
    };

    [Flags]
    public enum AUDIO_ENCODING_TYPE
    {
        AUDIO_ENCODING_TYPE_AAC_16000_LOW = 0x010101,

        AUDIO_ENCODING_TYPE_AAC_16000_MEDIUM = 0x010102,

        AUDIO_ENCODING_TYPE_AAC_32000_LOW = 0x010201,

        AUDIO_ENCODING_TYPE_AAC_32000_MEDIUM = 0x010202,

        AUDIO_ENCODING_TYPE_AAC_32000_HIGH = 0x010203,

        AUDIO_ENCODING_TYPE_AAC_48000_MEDIUM = 0x010302,

        AUDIO_ENCODING_TYPE_AAC_48000_HIGH = 0x010303,

        AUDIO_ENCODING_TYPE_OPUS_16000_LOW = 0x020101,

        AUDIO_ENCODING_TYPE_OPUS_16000_MEDIUM = 0x020102,

        AUDIO_ENCODING_TYPE_OPUS_48000_MEDIUM = 0x020302,

        AUDIO_ENCODING_TYPE_OPUS_48000_HIGH = 0x020303,
    };

    public enum WATERMARK_FIT_MODE
    {
        FIT_MODE_COVER_POSITION = 0,

        FIT_MODE_USE_IMAGE_RATIO = 1
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

    public class EncodedAudioFrameInfo
    {
        public EncodedAudioFrameInfo()
        {
            codec = AUDIO_CODEC_TYPE.AUDIO_CODEC_AACLC;
            sampleRateHz = 0;
            samplesPerChannel = 0;
            numberOfChannels = 0;
            captureTimeMs = 0;
        }

        public EncodedAudioFrameInfo(ref EncodedAudioFrameInfo rhs)
        {
            codec = rhs.codec;
            sampleRateHz = rhs.sampleRateHz;
            samplesPerChannel = rhs.samplesPerChannel;
            numberOfChannels = rhs.numberOfChannels;
            advancedSettings = rhs.advancedSettings;
            captureTimeMs = rhs.captureTimeMs;
        }

        public AUDIO_CODEC_TYPE codec { set; get; }

        public int sampleRateHz { set; get; }

        public int samplesPerChannel { set; get; }

        public int numberOfChannels { set; get; }

        public EncodedAudioFrameAdvancedSettings advancedSettings { set; get; }

        public int64_t captureTimeMs { set; get; }
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
        NonInterleaved = 0,  // Mode 1 - STAP-A, FU-A is allowed

        SingleNalUnit = 1,       // Mode 0 - only single NALU allowed
    };

    public enum VIDEO_STREAM_TYPE
    {
        VIDEO_STREAM_HIGH = 0,

        VIDEO_STREAM_LOW = 1,
    };


    public class VideoSubscriptionOptions:OptionalJsonParse
    {
        public Optional<VIDEO_STREAM_TYPE> type = new Optional<VIDEO_STREAM_TYPE>();

        public Optional<bool> encodedFrameOnly = new Optional<bool>();

        public VideoSubscriptionOptions()
        {
           
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
    };

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
            captureTimeMs = 0;
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
            trackId = rhs.trackId;
            captureTimeMs = rhs.captureTimeMs;
            uid = rhs.uid;
            streamType = rhs.streamType;
        }

        public VIDEO_CODEC_TYPE codecType { set; get; }

        public int width { set; get; }

        public int height { set; get; }

        public int framesPerSecond { set; get; }

        public VIDEO_FRAME_TYPE_NATIVE frameType { set; get; }

        public VIDEO_ORIENTATION rotation { set; get; }

        public int trackId { set; get; }

        public int64_t captureTimeMs { set; get; }

        public uint uid { set; get; }

        public VIDEO_STREAM_TYPE streamType { set; get; }
    };

    public enum VIDEO_MIRROR_MODE_TYPE
    {
        VIDEO_MIRROR_MODE_AUTO = 0,

        VIDEO_MIRROR_MODE_ENABLED = 1,

        VIDEO_MIRROR_MODE_DISABLED = 2,
    };

    public class VideoEncoderConfiguration
    {
        public VIDEO_CODEC_TYPE codecType { set; get; }

        public VideoDimensions dimensions { set; get; }

        public int frameRate { set; get; }

        public int bitrate { set; get; }

        public int minBitrate { set; get; }

        public ORIENTATION_MODE orientationMode { set; get; }

        public DEGRADATION_PREFERENCE degradationPreference { set; get; }

        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }

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
    };

    public class DataStreamConfig
    {
        public bool syncWithAudio;

        public bool ordered;
    };

    public enum SIMULCAST_STREAM_MODE
    {
        AUTO_SIMULCAST_STREAM = -1,

        DISABLE_SIMULCAST_STREM = 0,

        ENABLE_SIMULCAST_STREAM = 1,
    };

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

        public VideoDimensions dimensions { set; get; }

        public int bitrate { set; get; }

        public int framerate { set; get; }
    };

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

        public int x { set; get; }

        public int y { set; get; }

        public int width { set; get; }

        public int height { set; get; }
    };

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

        public float xRatio { set; get; }

        public float yRatio { set; get; }

        public float widthRatio { set; get; }
    };

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

        public bool visibleInPreview { set; get; }

        public Rectangle positionInLandscapeMode { set; get; }

        public Rectangle positionInPortraitMode { set; get; }

        public WatermarkRatio watermarkRatio { set; get; }

        public WATERMARK_FIT_MODE mode { set; get; }
    };

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

        public uint duration { set; get; }

        public uint txBytes { set; get; }

        public uint rxBytes { set; get; }

        public uint txAudioBytes { set; get; }

        public uint txVideoBytes { set; get; }

        public uint rxAudioBytes { set; get; }

        public uint rxVideoBytes { set; get; }

        public ushort txKBitRate { set; get; }

        public ushort rxKBitRate { set; get; }

        public ushort rxAudioKBitRate { set; get; }

        public ushort txAudioKBitRate { set; get; }

        public ushort rxVideoKBitRate { set; get; }

        public ushort txVideoKBitRate { set; get; }

        public ushort lastmileDelay { set; get; }

        public uint userCount { set; get; }

        public double cpuAppUsage { set; get; }

        public double cpuTotalUsage { set; get; }

        public int gatewayRtt { set; get; }

        public double memoryAppUsageRatio { set; get; }

        public double memoryTotalUsageRatio { set; get; }

        public int memoryAppUsageInKbytes { set; get; }

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

        public int txPacketLossRate { set; get; }

        public int rxPacketLossRate { set; get; }
    };

    public enum VIDEO_SOURCE_TYPE
    {
        VIDEO_SOURCE_CAMERA_PRIMARY,
        VIDEO_SOURCE_CAMERA = VIDEO_SOURCE_CAMERA_PRIMARY,
        VIDEO_SOURCE_CAMERA_SECONDARY,
        VIDEO_SOURCE_SCREEN_PRIMARY,
        VIDEO_SOURCE_SCREEN = VIDEO_SOURCE_SCREEN_PRIMARY,
        VIDEO_SOURCE_SCREEN_SECONDARY,
        VIDEO_SOURCE_CUSTOM,
        VIDEO_SOURCE_MEDIA_PLAYER,
        VIDEO_SOURCE_RTC_IMAGE_PNG,
        VIDEO_SOURCE_RTC_IMAGE_JPEG,
        VIDEO_SOURCE_RTC_IMAGE_GIF,
        VIDEO_SOURCE_REMOTE,
        VIDEO_SOURCE_TRANSCODED,
        VIDEO_SOURCE_UNKNOWN = 100
    };

    public enum CLIENT_ROLE_TYPE
    {
        CLIENT_ROLE_BROADCASTER = 1,

        CLIENT_ROLE_AUDIENCE = 2,
    };

    public enum QUALITY_ADAPT_INDICATION
    {
        ADAPT_NONE = 0,

        ADAPT_UP_BANDWIDTH = 1,

        ADAPT_DOWN_BANDWIDTH = 2,
    };


    public enum AUDIENCE_LATENCY_LEVEL_TYPE
    {
        AUDIENCE_LATENCY_LEVEL_LOW_LATENCY = 1,

        AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY = 2,
    };

    public class ClientRoleOptions
    {
        public ClientRoleOptions()
        {
            audienceLatencyLevel = AUDIENCE_LATENCY_LEVEL_TYPE.AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY;
            stopMicrophoneRecording = true;
            stopPreview = false;
        }

        public AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel;

        public bool stopMicrophoneRecording;

        public bool stopPreview;
    };

    public enum EXPERIENCE_QUALITY_TYPE
    {
        EXPERIENCE_QUALITY_GOOD = 0,

        EXPERIENCE_QUALITY_BAD = 1,
    };

    public enum EXPERIENCE_POOR_REASON
    {
        EXPERIENCE_REASON_NONE = 0,

        REMOTE_NETWORK_QUALITY_POOR = 1,

        LOCAL_NETWORK_QUALITY_POOR = 2,

        WIRELESS_SIGNAL_POOR = 4,

        WIFI_BLUETOOTH_COEXIST = 8,
    };

    public class RemoteAudioStats
    {
        public RemoteAudioStats()
        {
            uid = 0;
            quality = 0;
            networkTransportDelay = 0;
            jitterBufferDelay = 0;
            audioLossRate = 0;
            numChannels = 0;
            receivedSampleRate = 0;
            receivedBitrate = 0;
            totalFrozenTime = 0;
            frozenRate = 0;
            mosValue = 0;
            totalActiveTime = 0;
            publishDuration = 0;
            qoeQuality = 0;
            qualityChangedReason = 0;
        }

        public RemoteAudioStats(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay,
            int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime,
            int frozenRate, int mosValue, int totalActiveTime, int publishDuration, int qoeQuality, int qualityChangedReason)
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
            this.qualityChangedReason = qualityChangedReason;
        }

        public uint uid { set; get; }

        public int quality { set; get; }

        public int networkTransportDelay { set; get; }

        public int jitterBufferDelay { set; get; }

        public int audioLossRate { set; get; }

        public int numChannels { set; get; }

        public int receivedSampleRate { set; get; }

        public int receivedBitrate { set; get; }

        public int totalFrozenTime { set; get; }

        public int frozenRate { set; get; }

        public int mosValue { set; get; }

        public int totalActiveTime { set; get; }

        public int publishDuration { set; get; }

        public int qoeQuality { set; get; }

        public int qualityChangedReason { set; get; }
    };

    public enum AUDIO_PROFILE_TYPE
    {
        AUDIO_PROFILE_DEFAULT = 0,

        AUDIO_PROFILE_SPEECH_STANDARD = 1,

        AUDIO_PROFILE_MUSIC_STANDARD = 2,

        AUDIO_PROFILE_MUSIC_STANDARD_STEREO = 3,

        AUDIO_PROFILE_MUSIC_HIGH_QUALITY = 4,

        AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO = 5,

        AUDIO_PROFILE_IOT = 6,

        AUDIO_PROFILE_NUM = 7
    };

    public enum AUDIO_SCENARIO_TYPE
    {
        AUDIO_SCENARIO_DEFAULT = 0,

        AUDIO_SCENARIO_GAME_STREAMING = 3,

        AUDIO_SCENARIO_CHATROOM = 5,

        AUDIO_SCENARIO_CHORUS = 7,

        AUDIO_SCENARIO_MEETING = 8,

        AUDIO_SCENARIO_NUM = 9,
    };


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

        public int width { set; get; }   // Number of pixels.

        public int height { set; get; } // Number of pixels.

        public int fps { set; get; }
    };

    public enum VIDEO_CONTENT_HINT
    {
        CONTENT_HINT_NONE = 0,

        CONTENT_HINT_MOTION = 1,

        CONTENT_HINT_DETAILS = 2
    };

    public enum SCREEN_SCENARIO_TYPE
    {
        SCREEN_SCENARIO_DOCUMENT = 1,

        SCREEN_SCENARIO_GAMING = 2,

        SCREEN_SCENARIO_VIDEO = 3,

        SCREEN_SCENARIO_RDC = 4,
    };

    public enum CAPTURE_BRIGHTNESS_LEVEL_TYPE
    {
        CAPTURE_BRIGHTNESS_LEVEL_INVALID = -1,

        CAPTURE_BRIGHTNESS_LEVEL_NORMAL = 0,

        CAPTURE_BRIGHTNESS_LEVEL_BRIGHT = 1,

        CAPTURE_BRIGHTNESS_LEVEL_DARK = 2,
    };

    public enum LOCAL_AUDIO_STREAM_STATE
    {
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        LOCAL_AUDIO_STREAM_STATE_RECORDING = 1,

        LOCAL_AUDIO_STREAM_STATE_ENCODING = 2,

        LOCAL_AUDIO_STREAM_STATE_FAILED = 3
    };

    public enum LOCAL_AUDIO_STREAM_ERROR
    {
        LOCAL_AUDIO_STREAM_ERROR_OK = 0,

        LOCAL_AUDIO_STREAM_ERROR_FAILURE = 1,

        LOCAL_AUDIO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        LOCAL_AUDIO_STREAM_ERROR_DEVICE_BUSY = 3,

        LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE = 4,

        LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE = 5,

        LOCAL_AUDIO_STREAM_ERROR_NO_RECORDING_DEVICE = 6,

        LOCAL_AUDIO_STREAM_ERROR_NO_PLAYOUT_DEVICE = 7,

        LOCAL_AUDIO_STREAM_ERROR_INTERRUPTED = 8,

        LOCAL_AUDIO_STREAM_ERROR_RECORD_INVALID_ID = 9,

        LOCAL_AUDIO_STREAM_ERROR_PLAYOUT_INVALID_ID = 10,
    };

    public enum LOCAL_VIDEO_STREAM_STATE
    {
        LOCAL_VIDEO_STREAM_STATE_STOPPED = 0,

        LOCAL_VIDEO_STREAM_STATE_CAPTURING = 1,

        LOCAL_VIDEO_STREAM_STATE_ENCODING = 2,

        LOCAL_VIDEO_STREAM_STATE_FAILED = 3
    };

    public enum LOCAL_VIDEO_STREAM_ERROR
    {
        LOCAL_VIDEO_STREAM_ERROR_OK = 0,

        LOCAL_VIDEO_STREAM_ERROR_FAILURE = 1,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY = 3,

        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE = 4,

        LOCAL_VIDEO_STREAM_ERROR_ENCODE_FAILURE = 5,

        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_INBACKGROUND = 6,

        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_MULTIPLE_FOREGROUND_APPS = 7,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NOT_FOUND = 8,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_DISCONNECTED = 9,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_INVALID_ID = 10,

        LOCAL_VIDEO_STREAM_ERROR_DEVICE_SYSTEM_PRESSURE = 101,

        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED = 11,

        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_CLOSED = 12,

        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_OCCLUDED = 13,

        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_NOT_SUPPORTED = 20,
    };

    public enum REMOTE_AUDIO_STATE
    {
        REMOTE_AUDIO_STATE_STOPPED = 0,  // Default state, audio is started or remote user disabled/muted audio stream

        REMOTE_AUDIO_STATE_STARTING = 1,  // The first audio frame packet has been received

        REMOTE_AUDIO_STATE_DECODING = 2,  // The first remote audio frame has been decoded or fronzen state ends

        REMOTE_AUDIO_STATE_FROZEN = 3,    // Remote audio is frozen, probably due to network issue

        REMOTE_AUDIO_STATE_FAILED = 4,    // Remote audio play failed
    };

    public enum REMOTE_AUDIO_STATE_REASON
    {
        REMOTE_AUDIO_REASON_INTERNAL = 0,

        REMOTE_AUDIO_REASON_NETWORK_CONGESTION = 1,

        REMOTE_AUDIO_REASON_NETWORK_RECOVERY = 2,

        REMOTE_AUDIO_REASON_LOCAL_MUTED = 3,

        REMOTE_AUDIO_REASON_LOCAL_UNMUTED = 4,

        REMOTE_AUDIO_REASON_REMOTE_MUTED = 5,

        REMOTE_AUDIO_REASON_REMOTE_UNMUTED = 6,

        REMOTE_AUDIO_REASON_REMOTE_OFFLINE = 7,
    };

    public enum REMOTE_VIDEO_STATE
    {
        REMOTE_VIDEO_STATE_STOPPED = 0,

        REMOTE_VIDEO_STATE_STARTING = 1,

        REMOTE_VIDEO_STATE_DECODING = 2,

        REMOTE_VIDEO_STATE_FROZEN = 3,
        
        REMOTE_VIDEO_STATE_FAILED = 4,
    };

    public enum REMOTE_VIDEO_STATE_REASON
    {
        REMOTE_VIDEO_STATE_REASON_INTERNAL = 0,

        REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION = 1,

        REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY = 2,

        REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED = 3,

        REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED = 4,

        REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED = 5,

        REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED = 6,

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
        REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE = 0,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_1 = 1,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_2 = 2,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_3 = 3,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_4 = 4,
    };

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

        public uint uid { set; get; }

        public uint volume { set; get; }

        public uint vad { set; get; }

        public double voicePitch { set; get; }
    };

    public class DeviceInfo
    {
        public string deviceName;

        public string deviceId;
    };

    public enum AUDIO_SAMPLE_RATE_TYPE
    {
        AUDIO_SAMPLE_RATE_32000 = 32000,

        AUDIO_SAMPLE_RATE_44100 = 44100,

        AUDIO_SAMPLE_RATE_48000 = 48000,
    };

    public enum VIDEO_CODEC_TYPE_FOR_STREAM
    {
        VIDEO_CODEC_H264_FOR_STREAM = 1,

        VIDEO_CODEC_H265_FOR_STREAM = 2,
    };

    public enum VIDEO_CODEC_PROFILE_TYPE
    {
        VIDEO_CODEC_PROFILE_BASELINE = 66,

        VIDEO_CODEC_PROFILE_MAIN = 77,

        VIDEO_CODEC_PROFILE_HIGH = 100,
    };

    public enum AUDIO_CODEC_PROFILE_TYPE
    {
        AUDIO_CODEC_PROFILE_LC_AAC = 0,

        AUDIO_CODEC_PROFILE_HE_AAC = 1,

        AUDIO_CODEC_PROFILE_HE_AAC_V2 = 2,
    };

    public class LocalAudioStats
    {
        public LocalAudioStats()
        {
        }

        public LocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate, int internalCodec, ushort txPacketLossRate, int audioDeviceDelay)
        {
            this.numChannels = numChannels;
            this.sentSampleRate = sentSampleRate;
            this.sentBitrate = sentBitrate;
            this.internalCodec = internalCodec;
            this.txPacketLossRate = txPacketLossRate;
            this.audioDeviceDelay = audioDeviceDelay;
        }

        public int numChannels { set; get; }

        public int sentSampleRate { set; get; }

        public int sentBitrate { set; get; }

        public int internalCodec { set; get; }

        public ushort txPacketLossRate { set; get; }

        public int audioDeviceDelay { set; get; }
    };

    public enum RTMP_STREAM_PUBLISH_STATE
    {
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        RTMP_STREAM_PUBLISH_STATE_CONNECTING = 1,

        RTMP_STREAM_PUBLISH_STATE_RUNNING = 2,

        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,

        RTMP_STREAM_PUBLISH_STATE_DISCONNECTING = 5,
    };

    public enum RTMP_STREAM_PUBLISH_ERROR_TYPE
    {
        RTMP_STREAM_PUBLISH_ERROR_OK = 0,

        RTMP_STREAM_PUBLISH_ERROR_INVALID_ARGUMENT = 1,

        RTMP_STREAM_PUBLISH_ERROR_ENCRYPTED_STREAM_NOT_ALLOWED = 2,

        RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT = 3,

        RTMP_STREAM_PUBLISH_ERROR_INTERNAL_SERVER_ERROR = 4,

        RTMP_STREAM_PUBLISH_ERROR_RTMP_SERVER_ERROR = 5,

        RTMP_STREAM_PUBLISH_ERROR_TOO_OFTEN = 6,

        RTMP_STREAM_PUBLISH_ERROR_REACH_LIMIT = 7,

        RTMP_STREAM_PUBLISH_ERROR_NOT_AUTHORIZED = 8,

        RTMP_STREAM_PUBLISH_ERROR_STREAM_NOT_FOUND = 9,

        RTMP_STREAM_PUBLISH_ERROR_FORMAT_NOT_SUPPORTED = 10,

        RTMP_STREAM_PUBLISH_ERROR_NOT_BROADCASTER = 11,  // Note: match to ERR_PUBLISH_STREAM_NOT_BROADCASTER in AgoraBase.h

        RTMP_STREAM_PUBLISH_ERROR_TRANSCODING_NO_MIX_STREAM = 13,  // Note: match to ERR_PUBLISH_STREAM_TRANSCODING_NO_MIX_STREAM in AgoraBase.h

        RTMP_STREAM_PUBLISH_ERROR_NET_DOWN = 14,  // Note: match to ERR_NET_DOWN in AgoraBase.h

        RTMP_STREAM_PUBLISH_ERROR_INVALID_APPID = 15,  // Note: match to ERR_PUBLISH_STREAM_APPID_INVALID in AgoraBase.h

        RTMP_STREAM_PUBLISH_ERROR_INVALID_PRIVILEGE = 16,

        RTMP_STREAM_UNPUBLISH_ERROR_OK = 100,
    };

    public enum RTMP_STREAMING_EVENT
    {
        RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE = 1,

        RTMP_STREAMING_EVENT_URL_ALREADY_IN_USE = 2,

        RTMP_STREAMING_EVENT_ADVANCED_FEATURE_NOT_SUPPORT = 3,

        RTMP_STREAMING_EVENT_REQUEST_TOO_OFTEN = 4,
    };

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

        public string url { set; get; }

        public int x { set; get; }

        public int y { set; get; }

        public int width { set; get; }

        public int height { set; get; }

        public int zOrder { set; get; }

        public double alpha { set; get; }
    };

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

        public string featureName { set; get; }

        public bool opened { set; get; }
    };

    public enum CONNECTION_STATE_TYPE
    {
        CONNECTION_STATE_DISCONNECTED = 1,

        CONNECTION_STATE_CONNECTING = 2,

        CONNECTION_STATE_CONNECTED = 3,

        CONNECTION_STATE_RECONNECTING = 4,

        CONNECTION_STATE_FAILED = 5,
    };

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

        public uint uid { set; get; }

        public int x { set; get; }

        public int y { set; get; }

        public int width { set; get; }

        public int height { set; get; }

        public int zOrder { set; get; }

        public double alpha { set; get; }

        public int audioChannel { set; get; }
    };

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

        public int width { set; get; }

        public int height { set; get; }

        public int videoBitrate { set; get; }

        public int videoFramerate { set; get; }

        public bool lowLatency { set; get; }

        public int videoGop { set; get; }

        public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile { set; get; }

        public uint backgroundColor { set; get; }

        public VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType { set; get; }

        public uint userCount { set; get; }

        public TranscodingUser[] transcodingUsers { set; get; }

        public string transcodingExtraInfo { set; get; }

        public string metadata { set; get; }

        public RtcImage[] watermark { set; get; }

        public uint watermarkCount { set; get; }

        public RtcImage[] backgroundImage { set; get; }

        public uint backgroundImageCount { set; get; }

        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        public int audioBitrate { set; get; }

        public int audioChannels { set; get; }

        public AUDIO_CODEC_PROFILE_TYPE audioCodecProfile { set; get; }

        public LiveStreamAdvancedFeature[] advancedFeatures { set; get; }

        public uint advancedFeatureCount { set; get; }
    };

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

        public MEDIA_SOURCE_TYPE sourceType { set; get; }

        public uint remoteUserUid { set; get; }

        public string imageUrl { set; get; }

        public int x { set; get; }

        public int y { set; get; }

        public int width { set; get; }

        public int height { set; get; }

        public int zOrder { set; get; }

        public double alpha { set; get; }

        public bool mirror { set; get; }
    };

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

        public uint streamCount { set; get; }

        public TranscodingVideoStream[] VideoInputStreams { set; get; }

        public VideoEncoderConfiguration videoOutputConfiguration { set; get; }
    };

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

        public bool probeUplink { set; get; }

        public bool probeDownlink { set; get; }

        public uint expectedUplinkBitrate { set; get; }

        public uint expectedDownlinkBitrate { set; get; }
    };

    public enum LASTMILE_PROBE_RESULT_STATE
    {
        LASTMILE_PROBE_RESULT_COMPLETE = 1,

        LASTMILE_PROBE_RESULT_INCOMPLETE_NO_BWE = 2,

        LASTMILE_PROBE_RESULT_UNAVAILABLE = 3
    };

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

        public uint packetLossRate { set; get; }

        public uint jitter { set; get; }

        public uint availableBandwidth { set; get; }
    };

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

        public LASTMILE_PROBE_RESULT_STATE state { set; get; }

        public LastmileProbeOneWayResult uplinkReport { set; get; }

        public LastmileProbeOneWayResult downlinkReport { set; get; }

        public uint rtt { set; get; }
    };

    public enum CONNECTION_CHANGED_REASON_TYPE
    {
        CONNECTION_CHANGED_CONNECTING = 0,

        CONNECTION_CHANGED_JOIN_SUCCESS = 1,

        CONNECTION_CHANGED_INTERRUPTED = 2,

        CONNECTION_CHANGED_BANNED_BY_SERVER = 3,

        CONNECTION_CHANGED_JOIN_FAILED = 4,

        CONNECTION_CHANGED_LEAVE_CHANNEL = 5,

        CONNECTION_CHANGED_INVALID_APP_ID = 6,

        CONNECTION_CHANGED_INVALID_CHANNEL_NAME = 7,

        CONNECTION_CHANGED_INVALID_TOKEN = 8,

        CONNECTION_CHANGED_TOKEN_EXPIRED = 9,

        CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,

        CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,

        CONNECTION_CHANGED_RENEW_TOKEN = 12,

        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,

        CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,

        CONNECTION_CHANGED_REJOIN_SUCCESS = 15,

        CONNECTION_CHANGED_LOST = 16,

        CONNECTION_CHANGED_ECHO_TEST = 17,

        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,

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

    public enum WLACC_MESSAGE_REASON
    {
        WLACC_MESSAGE_REASON_WEAK_SIGNAL = 0,

        WLACC_MESSAGE_REASON_CHANNEL_CONGESTION = 1,
    };

    public enum WLACC_SUGGEST_ACTION
    {
        WLACC_SUGGEST_ACTION_CLOSE_TO_WIFI = 0,

        WLACC_SUGGEST_ACTION_CONNECT_SSID = 1,

        WLACC_SUGGEST_ACTION_CHECK_5G = 2,
        
        WLACC_SUGGEST_ACTION_MODIFY_SSID = 3,
    };

    public class WlAccStats
    {
        public ushort e2eDelayPercent { set; get; }

        public ushort frozenRatioPercent { set; get; }

        public ushort lossRatePercent { set; get; }
    };

    public enum NETWORK_TYPE
    {
        NETWORK_TYPE_UNKNOWN = -1,

        NETWORK_TYPE_DISCONNECTED = 0,

        NETWORK_TYPE_LAN = 1,

        NETWORK_TYPE_WIFI = 2,

        NETWORK_TYPE_MOBILE_2G = 3,

        NETWORK_TYPE_MOBILE_3G = 4,

        NETWORK_TYPE_MOBILE_4G = 5,
    };

    public enum VIDEO_VIEW_SETUP_MODE
    {
        VIDEO_VIEW_SETUP_REPLACE = 0,

        VIDEO_VIEW_SETUP_ADD = 1,

        VIDEO_VIEW_SETUP_REMOVE = 2,
    };

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

        public view_t view { set; get; }

        public RENDER_MODE_TYPE renderMode { set; get; }

        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }

        public uint uid { set; get; }

        public bool isScreenView { set; get; }

        public byte[] priv { set; get; }  // private data (underlying video engine denotes it)

        public uint priv_size { set; get; }

        public VIDEO_SOURCE_TYPE sourceType { set; get; }

        public Rectangle cropArea { set; get; }

        public VIDEO_VIEW_SETUP_MODE setupMode { set; get; }
    };

    public enum LIGHTENING_CONTRAST_LEVEL
    {
        LIGHTENING_CONTRAST_LOW = 0,

        LIGHTENING_CONTRAST_NORMAL = 1,

        LIGHTENING_CONTRAST_HIGH = 2,
    };

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

        public LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel { set; get; }

        public float lighteningLevel { set; get; }

        public float smoothnessLevel { set; get; }

        public float rednessLevel { set; get; }

        public float sharpnessLevel { set; get; }
    };

    public enum LOW_LIGHT_ENHANCE_MODE
    {
        LOW_LIGHT_ENHANCE_AUTO = 0,

        LOW_LIGHT_ENHANCE_MANUAL = 1
    };

    public enum LOW_LIGHT_ENHANCE_LEVEL
    {
        LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY = 0,

        LOW_LIGHT_ENHANCE_LEVEL_FAST = 1
    };

    public class LowlightEnhanceOptions
    {
        public LOW_LIGHT_ENHANCE_MODE mode { set; get; }

        public LOW_LIGHT_ENHANCE_LEVEL level { set; get; }

        public LowlightEnhanceOptions(LOW_LIGHT_ENHANCE_MODE lowlightMode, LOW_LIGHT_ENHANCE_LEVEL lowlightLevel)
        {
            mode = lowlightMode;
            level = lowlightLevel;
        }

        public LowlightEnhanceOptions()
        {
            mode = LOW_LIGHT_ENHANCE_MODE.LOW_LIGHT_ENHANCE_AUTO;
            level = LOW_LIGHT_ENHANCE_LEVEL.LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY;
        }
    };


    public enum VIDEO_DENOISER_MODE
    {
        VIDEO_DENOISER_AUTO = 0,

        VIDEO_DENOISER_MANUAL = 1
    };

    public enum VIDEO_DENOISER_LEVEL
    {
        VIDEO_DENOISER_LEVEL_HIGH_QUALITY = 0,
        VIDEO_DENOISER_LEVEL_FAST = 1,
        VIDEO_DENOISER_LEVEL_STRENGTH = 2
    };

    public class VideoDenoiserOptions
    {
        public VIDEO_DENOISER_MODE mode { set; get; }

        public VIDEO_DENOISER_LEVEL level { set; get; }

        public VideoDenoiserOptions(VIDEO_DENOISER_MODE denoiserMode, VIDEO_DENOISER_LEVEL denoiserLevel)
        {
            mode = denoiserMode;
            level = denoiserLevel;
        }

        public VideoDenoiserOptions()
        {
            mode = VIDEO_DENOISER_MODE.VIDEO_DENOISER_AUTO;
            level = VIDEO_DENOISER_LEVEL.VIDEO_DENOISER_LEVEL_HIGH_QUALITY;
        }
    };

    public class ColorEnhanceOptions
    {
        public float strengthLevel { set; get; }

        public float skinProtectLevel { set; get; }

        public ColorEnhanceOptions(float stength, float skinProtect)
        {
            strengthLevel = stength;
            skinProtectLevel = skinProtect;
        }

        public ColorEnhanceOptions()
        {
            strengthLevel = 0;
            skinProtectLevel = 1;
        }
    };

    public enum BACKGROUND_SOURCE_TYPE
    {
        BACKGROUND_COLOR = 1,

        BACKGROUND_IMG = 2,

        BACKGROUND_BLUR = 3,
    };

    public enum BACKGROUND_BLUR_DEGREE
    {
        BLUR_DEGREE_LOW = 1,

        BLUR_DEGREE_MEDIUM = 2,

        BLUR_DEGREE_HIGH = 3,
    };

    public class VirtualBackgroundSource
    {
        public VirtualBackgroundSource()
        {
            background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_COLOR;
            color = 0xffffff;
            source = "";
            blur_degree = BACKGROUND_BLUR_DEGREE.BLUR_DEGREE_HIGH;
        }

        public BACKGROUND_SOURCE_TYPE background_source_type;

        public uint color;

        public string source;

        public BACKGROUND_BLUR_DEGREE blur_degree;
    };

    public class FishCorrectionParams
    {
        public FishCorrectionParams()
        {
            xCenter = 0.49f;
            yCenter = 0.48f;
            scaleFactor = 4.5f;
            focalLength = 31;
            polFocalLength = 31;
            splitHeight = 1.0f;

            ss[0] = 0.9375f;
            ss[1] = 0.0f;
            ss[2] = -2.9440f;
            ss[3] = 5.7344f;
            ss[4] = -4.4564f;

            mirror = false;
            rotation = VIDEO_ORIENTATION.VIDEO_ORIENTATION_0;
        }

        public float xCenter { set; get; }

        public float yCenter { set; get; }

        public float scaleFactor { set; get; }

        public float focalLength { set; get; }

        public float polFocalLength { set; get; }

        public float splitHeight { set; get; }

        public float[] ss = new float[5];

        bool mirror;

        VIDEO_ORIENTATION rotation;
    };

    public enum SEG_MODEL_TYPE
    {
        SEG_MODEL_AI = 1,

        SEG_MODEL_GREEN = 2
    };

    public class SegmentationProperty
    {
        public SEG_MODEL_TYPE modelType { set; get; }

        public float greenCapacity { set; get; }

        public SegmentationProperty()
        {
            modelType = SEG_MODEL_TYPE.SEG_MODEL_AI;
            greenCapacity = 0.5f;
        }
    };

    [Flags]
    public enum VOICE_BEAUTIFIER_PRESET
    {
        VOICE_BEAUTIFIER_OFF = 0x00000000,

        CHAT_BEAUTIFIER_MAGNETIC = 0x01010100,

        CHAT_BEAUTIFIER_FRESH = 0x01010200,

        CHAT_BEAUTIFIER_VITALITY = 0x01010300,

        SINGING_BEAUTIFIER = 0x01020100,

        TIMBRE_TRANSFORMATION_VIGOROUS = 0x01030100,

        TIMBRE_TRANSFORMATION_DEEP = 0x01030200,

        TIMBRE_TRANSFORMATION_MELLOW = 0x01030300,

        TIMBRE_TRANSFORMATION_FALSETTO = 0x01030400,

        TIMBRE_TRANSFORMATION_FULL = 0x01030500,

        TIMBRE_TRANSFORMATION_CLEAR = 0x01030600,

        TIMBRE_TRANSFORMATION_RESOUNDING = 0x01030700,

        TIMBRE_TRANSFORMATION_RINGING = 0x01030800,

        ULTRA_HIGH_QUALITY_VOICE = 0x01040100
    };

    [Flags]
    public enum AUDIO_EFFECT_PRESET
    {
        AUDIO_EFFECT_OFF = 0x00000000,

        ROOM_ACOUSTICS_KTV = 0x02010100,

        ROOM_ACOUSTICS_VOCAL_CONCERT = 0x02010200,

        ROOM_ACOUSTICS_STUDIO = 0x02010300,

        ROOM_ACOUSTICS_PHONOGRAPH = 0x02010400,

        ROOM_ACOUSTICS_VIRTUAL_STEREO = 0x02010500,

        ROOM_ACOUSTICS_SPACIAL = 0x02010600,

        ROOM_ACOUSTICS_ETHEREAL = 0x02010700,

        ROOM_ACOUSTICS_3D_VOICE = 0x02010800,

        ROOM_ACOUSTICS_VIRTUAL_SURROUND_SOUND = 0x02010900,

        VOICE_CHANGER_EFFECT_UNCLE = 0x02020100,

        VOICE_CHANGER_EFFECT_OLDMAN = 0x02020200,

        VOICE_CHANGER_EFFECT_BOY = 0x02020300,

        VOICE_CHANGER_EFFECT_SISTER = 0x02020400,

        VOICE_CHANGER_EFFECT_GIRL = 0x02020500,

        VOICE_CHANGER_EFFECT_PIGKING = 0x02020600,

        VOICE_CHANGER_EFFECT_HULK = 0x02020700,

        STYLE_TRANSFORMATION_RNB = 0x02030100,

        STYLE_TRANSFORMATION_POPULAR = 0x02030200,

        PITCH_CORRECTION = 0x02040100,
    };

    [Flags]
    public enum VOICE_CONVERSION_PRESET
    {
        VOICE_CONVERSION_OFF = 0x00000000,

        VOICE_CHANGER_NEUTRAL = 0x03010100,

        VOICE_CHANGER_SWEET = 0x03010200,

        VOICE_CHANGER_SOLID = 0x03010300,

        VOICE_CHANGER_BASS = 0x03010400
    };

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
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
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
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
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
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
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
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
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
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
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
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
        }

        public VideoDimensions dimensions { set; get; }

        public int frameRate { set; get; }

        public int bitrate { set; get; }

        public bool captureMouseCursor { set; get; }

        public bool windowFocus { set; get; }

        public view_t[] excludeWindowList { set; get; }

        public int excludeWindowCount { set; get; }

        public int highLightWidth { set; get; }

        public uint highLightColor { set; get; }

        public bool enableHighLight { set; get; }
    };

    public enum AUDIO_RECORDING_QUALITY_TYPE
    {
        AUDIO_RECORDING_QUALITY_LOW = 0,

        AUDIO_RECORDING_QUALITY_MEDIUM = 1,

        AUDIO_RECORDING_QUALITY_HIGH = 2,

        AUDIO_RECORDING_QUALITY_ULTRA_HIGH = 3,
    };

    public enum AUDIO_FILE_RECORDING_TYPE
    {
        AUDIO_FILE_RECORDING_MIC = 1,

        AUDIO_FILE_RECORDING_PLAYBACK = 2,

        AUDIO_FILE_RECORDING_MIXED = 3,
    };

    public enum AUDIO_ENCODED_FRAME_OBSERVER_POSITION
    {
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_RECORD = 1,

        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK = 2,

        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_MIXED = 3,
    };

    public class AudioRecordingConfiguration
    {
        public AudioRecordingConfiguration()
        {
            filePath = "";
            encode = false;
            sampleRate = 32000;
            fileRecordingType = AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIXED;
            quality = AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_LOW;
            recordingChannel = 1;
        }

        public AudioRecordingConfiguration(string file_path, int sample_rate, AUDIO_RECORDING_QUALITY_TYPE quality_type, int channel)
        {
            this.filePath = file_path;
            this.encode = false;
            this.sampleRate = sample_rate;
            this.fileRecordingType = AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIXED;
            this.quality = quality_type;
            recordingChannel = channel;
        }

        public AudioRecordingConfiguration(string file_path, bool enc, int sample_rate,
                                        AUDIO_FILE_RECORDING_TYPE type, AUDIO_RECORDING_QUALITY_TYPE quality_type, int channel)
        {
            this.filePath = file_path;
            this.encode = enc;
            this.sampleRate = sample_rate;
            this.fileRecordingType = type;
            this.quality = quality_type;
            this.recordingChannel = channel;
        }

        public string filePath { set; get; }

        public bool encode { set; get; }

        public int sampleRate { set; get; }

        public AUDIO_FILE_RECORDING_TYPE fileRecordingType { set; get; }

        public AUDIO_RECORDING_QUALITY_TYPE quality { set; get; }

        public int recordingChannel { set; get; }
    };

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

        public AUDIO_ENCODED_FRAME_OBSERVER_POSITION postionType { set; get; }

        public AUDIO_ENCODING_TYPE encodingType { set; get; }
    };

    public enum AREA_CODE : uint
    {
        AREA_CODE_CN = 0x00000001,

        AREA_CODE_NA = 0x00000002,

        AREA_CODE_EU = 0x00000004,

        AREA_CODE_AS = 0x00000008,

        AREA_CODE_JP = 0x00000010,

        AREA_CODE_IN = 0x00000020,

        AREA_CODE_GLOB = 0xFFFFFFFF
    };

    public enum AREA_CODE_EX : uint
    {
        AREA_CODE_OC = 0x00000040,

        AREA_CODE_SA = 0x00000080,

        AREA_CODE_AF = 0x00000100,

        AREA_CODE_KR = 0x00000200,

        AREA_CODE_HKMC = 0x00000400,

        AREA_CODE_US = 0x00000800,

        AREA_CODE_OVS = 0xFFFFFFFE
    };

    public enum CHANNEL_MEDIA_RELAY_ERROR
    {
        RELAY_OK = 0,

        RELAY_ERROR_SERVER_ERROR_RESPONSE = 1,

        RELAY_ERROR_SERVER_NO_RESPONSE = 2,

        RELAY_ERROR_NO_RESOURCE_AVAILABLE = 3,

        RELAY_ERROR_FAILED_JOIN_SRC = 4,

        RELAY_ERROR_FAILED_JOIN_DEST = 5,

        RELAY_ERROR_FAILED_PACKET_RECEIVED_FROM_SRC = 6,

        RELAY_ERROR_FAILED_PACKET_SENT_TO_DEST = 7,

        RELAY_ERROR_SERVER_CONNECTION_LOST = 8,

        RELAY_ERROR_INTERNAL_ERROR = 9,

        RELAY_ERROR_SRC_TOKEN_EXPIRED = 10,

        RELAY_ERROR_DEST_TOKEN_EXPIRED = 11,
    };

    public enum CHANNEL_MEDIA_RELAY_EVENT
    {
        RELAY_EVENT_NETWORK_DISCONNECTED = 0,

        RELAY_EVENT_NETWORK_CONNECTED = 1,

        RELAY_EVENT_PACKET_JOINED_SRC_CHANNEL = 2,

        RELAY_EVENT_PACKET_JOINED_DEST_CHANNEL = 3,

        RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL = 4,

        RELAY_EVENT_PACKET_RECEIVED_VIDEO_FROM_SRC = 5,

        RELAY_EVENT_PACKET_RECEIVED_AUDIO_FROM_SRC = 6,

        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL = 7,

        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_REFUSED = 8,

        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_NOT_CHANGE = 9,

        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_IS_NULL = 10,

        RELAY_EVENT_VIDEO_PROFILE_UPDATE = 11,

        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 12,

        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 13,

        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 14,

        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 15,
    };

    public enum CHANNEL_MEDIA_RELAY_STATE
    {
        RELAY_STATE_IDLE = 0,

        RELAY_STATE_CONNECTING = 1,

        RELAY_STATE_RUNNING = 2,

        RELAY_STATE_FAILURE = 3,
    };

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

        public string channelName { set; get; }

        public string token { set; get; }

        public uint uid { set; get; }
    };

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

        public ChannelMediaInfo srcInfo { set; get; }

        public ChannelMediaInfo[] destInfos { set; get; }

        public int destCount { set; get; }
    };

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

        public int video_encoder_target_bitrate_bps { set; get; }
    };

    public class PeerDownlinkInfo
    {
        public PeerDownlinkInfo()
        {
            uid = "";
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

    public enum ENCRYPTION_MODE
    {
        AES_128_XTS = 1,

        AES_128_ECB = 2,

        AES_256_XTS = 3,

        SM4_128_ECB = 4,

        AES_128_GCM = 5,

        AES_256_GCM = 6,

        AES_128_GCM2 = 7,

        AES_256_GCM2 = 8,

        MODE_END = 9,
    };

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

        /// @cond
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
        /// @endcond

        public ENCRYPTION_MODE encryptionMode { set; get; }

        public string encryptionKey { set; get; }

        private byte[] encryptionKdfSalt32 = new byte[32];

        public byte[] encryptionKdfSalt
        {
            set { Buffer.BlockCopy(value, 0, encryptionKdfSalt32, 0, 32); }

            get { return encryptionKdfSalt32; }
        }
    };

    public enum ENCRYPTION_ERROR_TYPE
    {
        ENCRYPTION_ERROR_INTERNAL_FAILURE = 0,

        ENCRYPTION_ERROR_DECRYPTION_FAILURE = 1,

        ENCRYPTION_ERROR_ENCRYPTION_FAILURE = 2,
    };

    public enum UPLOAD_ERROR_REASON
    {
        UPLOAD_SUCCESS = 0,

        UPLOAD_NET_ERROR = 1,

        UPLOAD_SERVER_ERROR = 2,
    };

    public enum PERMISSION_TYPE
    {
        RECORD_AUDIO = 0,

        CAMERA = 1,

        SCREEN_CAPTURE = 2,
    };

    public enum MAX_USER_ACCOUNT_LENGTH_TYPE
    {
        MAX_USER_ACCOUNT_LENGTH = 256
    };

    public enum STREAM_SUBSCRIBE_STATE
    {
        SUB_STATE_IDLE = 0,

        SUB_STATE_NO_SUBSCRIBED = 1,

        SUB_STATE_SUBSCRIBING = 2,

        SUB_STATE_SUBSCRIBED = 3
    };

    public enum STREAM_PUBLISH_STATE
    {
        PUB_STATE_IDLE = 0,

        PUB_STATE_NO_PUBLISHED = 1,

        PUB_STATE_PUBLISHING = 2,

        PUB_STATE_PUBLISHED = 3
    };


    public class EchoTestConfiguration
    {
        public view_t view { set; get; }

        public bool enableAudio { set; get; }

        public bool enableVideo { set; get; }

        public string token { set; get; }

        public string channelId { set; get; }

        public EchoTestConfiguration(view_t v, bool ea, bool ev, string t, string c)
        {
            view = v;
            enableAudio = ea;
            enableVideo = ev;
            token = t;
            channelId = c;
        }

        public EchoTestConfiguration()
        {
            view = 0;
            enableAudio = true;
            enableVideo = true;
            token = "";
            channelId = "";
        }
    };

    public class UserInfo
    {
        public uint uid;

        public string userAccount;

        public UserInfo()
        {
            uid = 0;
            userAccount = "";
        }
    };

    [Flags]
    public enum EAR_MONITORING_FILTER_TYPE
    {
        EAR_MONITORING_FILTER_NONE = (1 << 0),

        EAR_MONITORING_FILTER_BUILT_IN_AUDIO_FILTERS = (1 << 1),

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


    public class ScreenVideoParameters
    {
        public VideoDimensions dimensions { set; get; }

        public int frameRate { set; get; }

        public int bitrate { set; get; }

        public VIDEO_CONTENT_HINT contentHint = VIDEO_CONTENT_HINT.CONTENT_HINT_MOTION;

        public ScreenVideoParameters()
        {
            dimensions = new VideoDimensions(1280, 720);
            frameRate = 15;
        }
    };

    public class ScreenAudioParameters
    {
        public int sampleRate { set; get; }

        public int channels { set; get; }

        public int captureSignalVolume { set; get; }

        public ScreenAudioParameters()
        {
            sampleRate = 16000;
            channels = 2;
            captureSignalVolume = 100;
        }
    };

    public class ScreenCaptureParameters2
    {
        public bool captureAudio { set; get; }

        public ScreenAudioParameters audioParams { set; get; }

        public bool captureVideo { set; get; }

        public ScreenVideoParameters videoParams { set; get; }

        public ScreenCaptureParameters2()
        {
            captureAudio = false;
            audioParams = new ScreenAudioParameters();
            captureAudio = true;
            videoParams = new ScreenVideoParameters();
        }
    };

    public class SpatialAudioParams : OptionalJsonParse
    {
        public Optional<double> speaker_azimuth = new Optional<double>();

        public Optional<double> speaker_elevation = new Optional<double>();

        public Optional<double> speaker_distance = new Optional<double>();

        public Optional<int> speaker_orientation = new Optional<int>();

        public Optional<bool> enable_blur = new Optional<bool>();

        public Optional<bool> enable_air_absorb = new Optional<bool>();

        Optional<double> speaker_attenuation = new Optional<double>();

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

            writer.WriteObjectEnd();
        }
    };

    #endregion
}
