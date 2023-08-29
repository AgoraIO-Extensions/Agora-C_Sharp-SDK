﻿using System;
using Agora.Rtc.LitJson;
using track_id_t = System.UInt64;
namespace Agora.Rtc
{
    using int64_t = Int64;
    using view_t = Int64;
    using uint64_t = UInt64;

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

    ///
    /// <summary>
    /// The information of the user.
    /// </summary>
    ///
    public class UserInfo
    {
        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// User account. The maximum data length is MAX_USER_ACCOUNT_LENGTH_TYPE.
        /// </summary>
        ///
        public string userAccount;

        public UserInfo()
        {
            uid = 0;
            userAccount = "";
        }
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
        /// (Recommended) Standard bitrate mode. In this mode, the bitrates of the live broadcasting profile is higher than that of the communication profile.
        /// </summary>
        ///
        STANDARD_BITRATE = 0,

        ///
        /// <summary>
        /// Adaptive bitrate mode. In this mode, the bitrates of the live broadcasting profile equals that of the communication profile. If this mode is selected, the video frame rate of live broadcasting scenarios may be lower than the set value.
        /// </summary>
        ///
        COMPATIBLE_BITRATE = -1,

        ///
        /// @ignore
        ///
        DEFAULT_MIN_BITRATE = -1,

        ///
        /// @ignore
        ///
        DEFAULT_MIN_BITRATE_EQUAL_TO_TARGET_BITRATE = -2,
    }

    public class DownlinkNetworkInfo
    {
        public int lastmile_buffer_delay_time_ms;

        public int bandwidth_estimation_bps;

        public int total_downscale_level_count;

        public PeerDownlinkInfo[] peer_downlink_info;

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

    public class EncryptionConfig
    {
        public ENCRYPTION_MODE encryptionMode;

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

    public class DeviceInfoMobile
    {
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

    ///
    /// <summary>
    /// The DeviceInfo class that contains the ID and device name of the video devices.
    /// </summary>
    ///
    public class DeviceInfo
    {
        ///
        /// <summary>
        /// The device name.
        /// </summary>
        ///
        public string deviceName;

        ///
        /// <summary>
        /// The device ID.
        /// </summary>
        ///
        public string deviceId;
    };

#region terra AgoraBase.h

    public enum CHANNEL_PROFILE_TYPE
    {
        CHANNEL_PROFILE_COMMUNICATION = 0,

        CHANNEL_PROFILE_LIVE_BROADCASTING = 1,

        CHANNEL_PROFILE_GAME = 2,

        CHANNEL_PROFILE_CLOUD_GAMING = 3,

        CHANNEL_PROFILE_COMMUNICATION_1v1 = 4,
    }

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
    }

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

        ERR_CONNECTION_INTERRUPTED = 111,

        ERR_CONNECTION_LOST = 112,

        ERR_NOT_IN_CHANNEL = 113,

        ERR_SIZE_TOO_LARGE = 114,

        ERR_BITRATE_LIMIT = 115,

        ERR_TOO_MANY_DATA_STREAMS = 116,

        ERR_STREAM_MESSAGE_TIMEOUT = 117,

        ERR_SET_CLIENT_ROLE_NOT_AUTHORIZED = 119,

        ERR_DECRYPTION_FAILED = 120,

        ERR_INVALID_USER_ID = 121,

        ERR_CLIENT_IS_BANNED_BY_SERVER = 123,

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

        ERR_PCMSEND_FORMAT = 200,

        ERR_PCMSEND_BUFFEROVERFLOW = 201,

        ERR_LOGIN_ALREADY_LOGIN = 428,

        ERR_LOAD_MEDIA_ENGINE = 1001,

        ERR_ADM_GENERAL_ERROR = 1005,

        ERR_ADM_INIT_PLAYOUT = 1008,

        ERR_ADM_START_PLAYOUT = 1009,

        ERR_ADM_STOP_PLAYOUT = 1010,

        ERR_ADM_INIT_RECORDING = 1011,

        ERR_ADM_START_RECORDING = 1012,

        ERR_ADM_STOP_RECORDING = 1013,

        ERR_VDM_CAMERA_NOT_AUTHORIZED = 1501,
    }

    public enum LICENSE_ERROR_TYPE
    {
        LICENSE_ERR_INVALID = 1,

        LICENSE_ERR_EXPIRE = 2,

        LICENSE_ERR_MINUTES_EXCEED = 3,

        LICENSE_ERR_LIMITED_PERIOD = 4,

        LICENSE_ERR_DIFF_DEVICES = 5,

        LICENSE_ERR_INTERNAL = 99,
    }

    public enum AUDIO_SESSION_OPERATION_RESTRICTION
    {
        AUDIO_SESSION_OPERATION_RESTRICTION_NONE = 0,

        AUDIO_SESSION_OPERATION_RESTRICTION_SET_CATEGORY = 1,

        AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION = 1 << 1,

        AUDIO_SESSION_OPERATION_RESTRICTION_DEACTIVATE_SESSION = 1 << 2,

        AUDIO_SESSION_OPERATION_RESTRICTION_ALL = 1 << 7,
    }

    public enum USER_OFFLINE_REASON_TYPE
    {
        USER_OFFLINE_QUIT = 0,

        USER_OFFLINE_DROPPED = 1,

        USER_OFFLINE_BECOME_AUDIENCE = 2,
    }

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

        AGORA_IID_STATE_SYNC = 13,

        AGORA_IID_METACHAT_SERVICE = 14,

        AGORA_IID_MUSIC_CONTENT_CENTER = 15,

        AGORA_IID_H265_TRANSCODER = 16,
    }

    public enum QUALITY_TYPE
    {
        QUALITY_UNKNOWN = 0,

        QUALITY_EXCELLENT = 1,

        QUALITY_GOOD = 2,

        QUALITY_POOR = 3,

        QUALITY_BAD = 4,

        QUALITY_VBAD = 5,

        QUALITY_DOWN = 6,

        QUALITY_UNSUPPORTED = 7,

        QUALITY_DETECTING = 8,
    }

    public enum FIT_MODE_TYPE
    {
        MODE_COVER = 1,

        MODE_CONTAIN = 2,
    }

    public enum VIDEO_ORIENTATION
    {
        VIDEO_ORIENTATION_0 = 0,

        VIDEO_ORIENTATION_90 = 90,

        VIDEO_ORIENTATION_180 = 180,

        VIDEO_ORIENTATION_270 = 270,
    }

    public enum FRAME_RATE
    {
        FRAME_RATE_FPS_1 = 1,

        FRAME_RATE_FPS_7 = 7,

        FRAME_RATE_FPS_10 = 10,

        FRAME_RATE_FPS_15 = 15,

        FRAME_RATE_FPS_24 = 24,

        FRAME_RATE_FPS_30 = 30,

        FRAME_RATE_FPS_60 = 60,
    }

    public enum FRAME_WIDTH
    {
        FRAME_WIDTH_960 = 960,
    }

    public enum FRAME_HEIGHT
    {
        FRAME_HEIGHT_540 = 540,
    }

    public enum VIDEO_FRAME_TYPE
    {
        VIDEO_FRAME_TYPE_BLANK_FRAME = 0,

        VIDEO_FRAME_TYPE_KEY_FRAME = 3,

        VIDEO_FRAME_TYPE_DELTA_FRAME = 4,

        VIDEO_FRAME_TYPE_B_FRAME = 5,

        VIDEO_FRAME_TYPE_DROPPABLE_FRAME = 6,

        VIDEO_FRAME_TYPE_UNKNOW,
    }

    public enum ORIENTATION_MODE
    {
        ORIENTATION_MODE_ADAPTIVE = 0,

        ORIENTATION_MODE_FIXED_LANDSCAPE = 1,

        ORIENTATION_MODE_FIXED_PORTRAIT = 2,
    }

    public enum DEGRADATION_PREFERENCE
    {
        MAINTAIN_QUALITY = 0,

        MAINTAIN_FRAMERATE = 1,

        MAINTAIN_BALANCED = 2,

        MAINTAIN_RESOLUTION = 3,

        DISABLED = 100,
    }

    public class VideoDimensions
    {
        public int width;

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

    public enum SCREEN_CAPTURE_FRAMERATE_CAPABILITY
    {
        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_15_FPS = 0,

        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_30_FPS = 1,

        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_60_FPS = 2,
    }

    public enum VIDEO_CODEC_CAPABILITY_LEVEL
    {
        CODEC_CAPABILITY_LEVEL_UNSPECIFIED = -1,

        CODEC_CAPABILITY_LEVEL_BASIC_SUPPORT = 5,

        CODEC_CAPABILITY_LEVEL_1080P30FPS = 10,

        CODEC_CAPABILITY_LEVEL_1080P60FPS = 20,

        CODEC_CAPABILITY_LEVEL_4K60FPS = 30,
    }

    public enum VIDEO_CODEC_TYPE
    {
        VIDEO_CODEC_NONE = 0,

        VIDEO_CODEC_VP8 = 1,

        VIDEO_CODEC_H264 = 2,

        VIDEO_CODEC_H265 = 3,

        VIDEO_CODEC_GENERIC = 6,

        VIDEO_CODEC_GENERIC_H264 = 7,

        VIDEO_CODEC_AV1 = 12,

        VIDEO_CODEC_VP9 = 13,

        VIDEO_CODEC_GENERIC_JPEG = 20,
    }

    public enum TCcMode
    {
        CC_ENABLED,

        CC_DISABLED,
    }

    public class SenderOptions
    {
        public TCcMode ccMode;

        public VIDEO_CODEC_TYPE codecType;

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

    public enum AUDIO_CODEC_TYPE
    {
        AUDIO_CODEC_OPUS = 1,

        AUDIO_CODEC_PCMA = 3,

        AUDIO_CODEC_PCMU = 4,

        AUDIO_CODEC_G722 = 5,

        AUDIO_CODEC_AACLC = 8,

        AUDIO_CODEC_HEAAC = 9,

        AUDIO_CODEC_JC1 = 10,

        AUDIO_CODEC_HEAAC2 = 11,

        AUDIO_CODEC_LPCNET = 12,
    }

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
    }

    public enum WATERMARK_FIT_MODE
    {
        FIT_MODE_COVER_POSITION,

        FIT_MODE_USE_IMAGE_RATIO,
    }

    public class EncodedAudioFrameAdvancedSettings
    {
        public bool speech;

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

    public class EncodedAudioFrameInfo
    {
        public AUDIO_CODEC_TYPE codec;

        public int sampleRateHz;

        public int samplesPerChannel;

        public int numberOfChannels;

        public EncodedAudioFrameAdvancedSettings advancedSettings;

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

    public class AudioPcmDataInfo
    {
        public ulong samplesPerChannel;

        public short channelNum;

        public ulong samplesOut;

        public long elapsedTimeMs;

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

    public enum H264PacketizeMode
    {
        NonInterleaved = 0,

        SingleNalUnit,
    }

    public enum VIDEO_STREAM_TYPE
    {
        VIDEO_STREAM_HIGH = 0,

        VIDEO_STREAM_LOW = 1,
    }

    public class VideoSubscriptionOptions : OptionalJsonParse
    {
        public Optional<VIDEO_STREAM_TYPE> type = new Optional<VIDEO_STREAM_TYPE>();

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

    public class EncodedVideoFrameInfo
    {
        public VIDEO_CODEC_TYPE codecType;

        public int width;

        public int height;

        public int framesPerSecond;

        public VIDEO_FRAME_TYPE frameType;

        public VIDEO_ORIENTATION rotation;

        public int trackId;

        public long captureTimeMs;

        public long decodeTimeMs;

        public uint uid;

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

    public enum COMPRESSION_PREFERENCE
    {
        PREFER_LOW_LATENCY,

        PREFER_QUALITY,
    }

    public enum ENCODING_PREFERENCE
    {
        PREFER_AUTO = -1,

        PREFER_SOFTWARE = 0,

        PREFER_HARDWARE = 1,
    }

    public class AdvanceOptions
    {
        public ENCODING_PREFERENCE encodingPreference;

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

    public enum VIDEO_MIRROR_MODE_TYPE
    {
        VIDEO_MIRROR_MODE_AUTO = 0,

        VIDEO_MIRROR_MODE_ENABLED = 1,

        VIDEO_MIRROR_MODE_DISABLED = 2,
    }

    public enum CODEC_CAP_MASK
    {
        CODEC_CAP_MASK_NONE = 0,

        CODEC_CAP_MASK_HW_DEC = 1 << 0,

        CODEC_CAP_MASK_HW_ENC = 1 << 1,

        CODEC_CAP_MASK_SW_DEC = 1 << 2,

        CODEC_CAP_MASK_SW_ENC = 1 << 3,
    }

    public class CodecCapLevels
    {
        public VIDEO_CODEC_CAPABILITY_LEVEL hwDecodingLevel;

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

    public class CodecCapInfo
    {
        public VIDEO_CODEC_TYPE codecType;

        public int codecCapMask;

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

    public class VideoEncoderConfiguration
    {
        public VIDEO_CODEC_TYPE codecType;

        public VideoDimensions dimensions;

        public int frameRate;

        public int bitrate;

        public int minBitrate;

        public ORIENTATION_MODE orientationMode;

        public DEGRADATION_PREFERENCE degradationPreference;

        public VIDEO_MIRROR_MODE_TYPE mirrorMode;

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

    public class DataStreamConfig
    {
        public bool syncWithAudio;

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

    public enum SIMULCAST_STREAM_MODE
    {
        AUTO_SIMULCAST_STREAM = -1,

        DISABLE_SIMULCAST_STREAM = 0,

        ENABLE_SIMULCAST_STREAM = 1,
    }

    public class SimulcastStreamConfig
    {
        public VideoDimensions dimensions;

        public int kBitrate;

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

    public class Rectangle
    {
        public int x;

        public int y;

        public int width;

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

    public class WatermarkRatio
    {
        public float xRatio;

        public float yRatio;

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

    public class WatermarkOptions
    {
        public bool visibleInPreview;

        public Rectangle positionInLandscapeMode;

        public Rectangle positionInPortraitMode;

        public WatermarkRatio watermarkRatio;

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

    public class RtcStats
    {
        public uint duration;

        public uint txBytes;

        public uint rxBytes;

        public uint txAudioBytes;

        public uint txVideoBytes;

        public uint rxAudioBytes;

        public uint rxVideoBytes;

        public ushort txKBitRate;

        public ushort rxKBitRate;

        public ushort rxAudioKBitRate;

        public ushort txAudioKBitRate;

        public ushort rxVideoKBitRate;

        public ushort txVideoKBitRate;

        public ushort lastmileDelay;

        public uint userCount;

        public double cpuAppUsage;

        public double cpuTotalUsage;

        public int gatewayRtt;

        public double memoryAppUsageRatio;

        public double memoryTotalUsageRatio;

        public int memoryAppUsageInKbytes;

        public int connectTimeMs;

        public int firstAudioPacketDuration;

        public int firstVideoPacketDuration;

        public int firstVideoKeyFramePacketDuration;

        public int packetsBeforeFirstKeyFramePacket;

        public int firstAudioPacketDurationAfterUnmute;

        public int firstVideoPacketDurationAfterUnmute;

        public int firstVideoKeyFramePacketDurationAfterUnmute;

        public int firstVideoKeyFrameDecodedDurationAfterUnmute;

        public int firstVideoKeyFrameRenderedDurationAfterUnmute;

        public int txPacketLossRate;

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

    public enum CLIENT_ROLE_TYPE
    {
        CLIENT_ROLE_BROADCASTER = 1,

        CLIENT_ROLE_AUDIENCE = 2,
    }

    public enum QUALITY_ADAPT_INDICATION
    {
        ADAPT_NONE = 0,

        ADAPT_UP_BANDWIDTH = 1,

        ADAPT_DOWN_BANDWIDTH = 2,
    }

    public enum AUDIENCE_LATENCY_LEVEL_TYPE
    {
        AUDIENCE_LATENCY_LEVEL_LOW_LATENCY = 1,

        AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY = 2,
    }

    public class ClientRoleOptions
    {
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

    public enum EXPERIENCE_QUALITY_TYPE
    {
        EXPERIENCE_QUALITY_GOOD = 0,

        EXPERIENCE_QUALITY_BAD = 1,
    }

    public enum EXPERIENCE_POOR_REASON
    {
        EXPERIENCE_REASON_NONE = 0,

        REMOTE_NETWORK_QUALITY_POOR = 1,

        LOCAL_NETWORK_QUALITY_POOR = 2,

        WIRELESS_SIGNAL_POOR = 4,

        WIFI_BLUETOOTH_COEXIST = 8,
    }

    public enum AUDIO_AINS_MODE
    {
        AINS_MODE_BALANCED = 0,

        AINS_MODE_AGGRESSIVE = 1,

        AINS_MODE_ULTRALOWLATENCY = 2,
    }

    public enum AUDIO_PROFILE_TYPE
    {
        AUDIO_PROFILE_DEFAULT = 0,

        AUDIO_PROFILE_SPEECH_STANDARD = 1,

        AUDIO_PROFILE_MUSIC_STANDARD = 2,

        AUDIO_PROFILE_MUSIC_STANDARD_STEREO = 3,

        AUDIO_PROFILE_MUSIC_HIGH_QUALITY = 4,

        AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO = 5,

        AUDIO_PROFILE_IOT = 6,

        AUDIO_PROFILE_NUM = 7,
    }

    public enum AUDIO_SCENARIO_TYPE
    {
        AUDIO_SCENARIO_DEFAULT = 0,

        AUDIO_SCENARIO_GAME_STREAMING = 3,

        AUDIO_SCENARIO_CHATROOM = 5,

        AUDIO_SCENARIO_CHORUS = 7,

        AUDIO_SCENARIO_MEETING = 8,

        AUDIO_SCENARIO_NUM = 9,
    }

    public class VideoFormat
    {
        public int width;

        public int height;

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

    public enum VIDEO_CONTENT_HINT
    {
        CONTENT_HINT_NONE,

        CONTENT_HINT_MOTION,

        CONTENT_HINT_DETAILS,
    }

    public enum SCREEN_SCENARIO_TYPE
    {
        SCREEN_SCENARIO_DOCUMENT = 1,

        SCREEN_SCENARIO_GAMING = 2,

        SCREEN_SCENARIO_VIDEO = 3,

        SCREEN_SCENARIO_RDC = 4,
    }

    public enum VIDEO_APPLICATION_SCENARIO_TYPE
    {
        APPLICATION_SCENARIO_GENERAL = 0,

        APPLICATION_SCENARIO_MEETING = 1,
    }

    public enum CAPTURE_BRIGHTNESS_LEVEL_TYPE
    {
        CAPTURE_BRIGHTNESS_LEVEL_INVALID = -1,

        CAPTURE_BRIGHTNESS_LEVEL_NORMAL = 0,

        CAPTURE_BRIGHTNESS_LEVEL_BRIGHT = 1,

        CAPTURE_BRIGHTNESS_LEVEL_DARK = 2,
    }

    public enum LOCAL_AUDIO_STREAM_STATE
    {
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        LOCAL_AUDIO_STREAM_STATE_RECORDING = 1,

        LOCAL_AUDIO_STREAM_STATE_ENCODING = 2,

        LOCAL_AUDIO_STREAM_STATE_FAILED = 3,
    }

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
    }

    public enum LOCAL_VIDEO_STREAM_STATE
    {
        LOCAL_VIDEO_STREAM_STATE_STOPPED = 0,

        LOCAL_VIDEO_STREAM_STATE_CAPTURING = 1,

        LOCAL_VIDEO_STREAM_STATE_ENCODING = 2,

        LOCAL_VIDEO_STREAM_STATE_FAILED = 3,
    }

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

        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_FAILURE = 21,

        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_NO_PERMISSION = 22,
    }

    public enum REMOTE_AUDIO_STATE
    {
        REMOTE_AUDIO_STATE_STOPPED = 0,

        REMOTE_AUDIO_STATE_STARTING = 1,

        REMOTE_AUDIO_STATE_DECODING = 2,

        REMOTE_AUDIO_STATE_FROZEN = 3,

        REMOTE_AUDIO_STATE_FAILED = 4,
    }

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
    }

    public enum REMOTE_VIDEO_STATE
    {
        REMOTE_VIDEO_STATE_STOPPED = 0,

        REMOTE_VIDEO_STATE_STARTING = 1,

        REMOTE_VIDEO_STATE_DECODING = 2,

        REMOTE_VIDEO_STATE_FROZEN = 3,

        REMOTE_VIDEO_STATE_FAILED = 4,
    }

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

        REMOTE_VIDEO_STATE_REASON_SDK_IN_BACKGROUND = 12,

        REMOTE_VIDEO_STATE_REASON_CODEC_NOT_SUPPORT = 13,
    }

    public enum REMOTE_USER_STATE
    {
        USER_STATE_MUTE_AUDIO = (1 << 0),

        USER_STATE_MUTE_VIDEO = (1 << 1),

        USER_STATE_ENABLE_VIDEO = (1 << 4),

        USER_STATE_ENABLE_LOCAL_VIDEO = (1 << 8),
    }

    public class VideoTrackInfo
    {
        public bool isLocal;

        public uint ownerUid;

        public track_id_t trackId;

        public string channelId;

        public VIDEO_STREAM_TYPE streamType;

        public VIDEO_CODEC_TYPE codecType;

        public bool encodedFrameOnly;

        public VIDEO_SOURCE_TYPE sourceType;

        public UInt32 observationPosition;

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

        public VideoTrackInfo(bool isLocal, uint ownerUid, track_id_t trackId, string channelId, VIDEO_STREAM_TYPE streamType, VIDEO_CODEC_TYPE codecType, bool encodedFrameOnly, VIDEO_SOURCE_TYPE sourceType, UInt32 observationPosition)
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

    public enum REMOTE_VIDEO_DOWNSCALE_LEVEL
    {
        REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_1,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_2,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_3,

        REMOTE_VIDEO_DOWNSCALE_LEVEL_4,
    }

    public class AudioVolumeInfo
    {
        public uint uid;

        public uint volume;

        public uint vad;

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

    public enum AUDIO_SAMPLE_RATE_TYPE
    {
        AUDIO_SAMPLE_RATE_32000 = 32000,

        AUDIO_SAMPLE_RATE_44100 = 44100,

        AUDIO_SAMPLE_RATE_48000 = 48000,
    }

    public enum VIDEO_CODEC_TYPE_FOR_STREAM
    {
        VIDEO_CODEC_H264_FOR_STREAM = 1,

        VIDEO_CODEC_H265_FOR_STREAM = 2,
    }

    public enum VIDEO_CODEC_PROFILE_TYPE
    {
        VIDEO_CODEC_PROFILE_BASELINE = 66,

        VIDEO_CODEC_PROFILE_MAIN = 77,

        VIDEO_CODEC_PROFILE_HIGH = 100,
    }

    public enum AUDIO_CODEC_PROFILE_TYPE
    {
        AUDIO_CODEC_PROFILE_LC_AAC = 0,

        AUDIO_CODEC_PROFILE_HE_AAC = 1,

        AUDIO_CODEC_PROFILE_HE_AAC_V2 = 2,
    }

    public class LocalAudioStats
    {
        public int numChannels;

        public int sentSampleRate;

        public int sentBitrate;

        public int internalCodec;

        public ushort txPacketLossRate;

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

    public enum RTMP_STREAM_PUBLISH_STATE
    {
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        RTMP_STREAM_PUBLISH_STATE_CONNECTING = 1,

        RTMP_STREAM_PUBLISH_STATE_RUNNING = 2,

        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,

        RTMP_STREAM_PUBLISH_STATE_DISCONNECTING = 5,
    }

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

        RTMP_STREAM_PUBLISH_ERROR_NOT_BROADCASTER = 11,

        RTMP_STREAM_PUBLISH_ERROR_TRANSCODING_NO_MIX_STREAM = 13,

        RTMP_STREAM_PUBLISH_ERROR_NET_DOWN = 14,

        RTMP_STREAM_PUBLISH_ERROR_INVALID_APPID = 15,

        RTMP_STREAM_PUBLISH_ERROR_INVALID_PRIVILEGE = 16,

        RTMP_STREAM_UNPUBLISH_ERROR_OK = 100,
    }

    public enum RTMP_STREAMING_EVENT
    {
        RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE = 1,

        RTMP_STREAMING_EVENT_URL_ALREADY_IN_USE = 2,

        RTMP_STREAMING_EVENT_ADVANCED_FEATURE_NOT_SUPPORT = 3,

        RTMP_STREAMING_EVENT_REQUEST_TOO_OFTEN = 4,
    }

    public class RtcImage
    {
        public string url;

        public int x;

        public int y;

        public int width;

        public int height;

        public int zOrder;

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

    public class LiveStreamAdvancedFeature
    {
        public string featureName;

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

    public enum CONNECTION_STATE_TYPE
    {
        CONNECTION_STATE_DISCONNECTED = 1,

        CONNECTION_STATE_CONNECTING = 2,

        CONNECTION_STATE_CONNECTED = 3,

        CONNECTION_STATE_RECONNECTING = 4,

        CONNECTION_STATE_FAILED = 5,
    }

    public class TranscodingUser
    {
        public uint uid;

        public int x;

        public int y;

        public int width;

        public int height;

        public int zOrder;

        public double alpha;

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

    public class LiveTranscoding
    {
        public int width;

        public int height;

        public int videoBitrate;

        public int videoFramerate;

        public bool lowLatency;

        public int videoGop;

        public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile;

        public uint backgroundColor;

        public VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType;

        public uint userCount;

        public TranscodingUser[] transcodingUsers;

        public string transcodingExtraInfo;

        public string metadata;

        public RtcImage[] watermark;

        public uint watermarkCount;

        public RtcImage[] backgroundImage;

        public uint backgroundImageCount;

        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate;

        public int audioBitrate;

        public int audioChannels;

        public AUDIO_CODEC_PROFILE_TYPE audioCodecProfile;

        public LiveStreamAdvancedFeature[] advancedFeatures;

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

    public class TranscodingVideoStream
    {
        public VIDEO_SOURCE_TYPE sourceType;

        public uint remoteUserUid;

        public string imageUrl;

        public int mediaPlayerId;

        public int x;

        public int y;

        public int width;

        public int height;

        public int zOrder;

        public double alpha;

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

    public class LocalTranscoderConfiguration
    {
        public uint streamCount;

        public TranscodingVideoStream[] videoInputStreams;

        public VideoEncoderConfiguration videoOutputConfiguration;

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

    public enum VIDEO_TRANSCODER_ERROR
    {
        VT_ERR_OK = 0,

        VT_ERR_VIDEO_SOURCE_NOT_READY = 1,

        VT_ERR_INVALID_VIDEO_SOURCE_TYPE = 2,

        VT_ERR_INVALID_IMAGE_PATH = 3,

        VT_ERR_UNSUPPORT_IMAGE_FORMAT = 4,

        VT_ERR_INVALID_LAYOUT = 5,

        VT_ERR_INTERNAL = 20,
    }

    public class LastmileProbeConfig
    {
        public bool probeUplink;

        public bool probeDownlink;

        public uint expectedUplinkBitrate;

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

    public enum LASTMILE_PROBE_RESULT_STATE
    {
        LASTMILE_PROBE_RESULT_COMPLETE = 1,

        LASTMILE_PROBE_RESULT_INCOMPLETE_NO_BWE = 2,

        LASTMILE_PROBE_RESULT_UNAVAILABLE = 3,
    }

    public class LastmileProbeOneWayResult
    {
        public uint packetLossRate;

        public uint jitter;

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

    public class LastmileProbeResult
    {
        public LASTMILE_PROBE_RESULT_STATE state;

        public LastmileProbeOneWayResult uplinkReport;

        public LastmileProbeOneWayResult downlinkReport;

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

        CONNECTION_CHANGED_LICENSE_VALIDATION_FAILURE = 21,
    }

    public enum CLIENT_ROLE_CHANGE_FAILED_REASON
    {
        CLIENT_ROLE_CHANGE_FAILED_TOO_MANY_BROADCASTERS = 1,

        CLIENT_ROLE_CHANGE_FAILED_NOT_AUTHORIZED = 2,

        CLIENT_ROLE_CHANGE_FAILED_REQUEST_TIME_OUT = 3,

        CLIENT_ROLE_CHANGE_FAILED_CONNECTION_FAILED = 4,
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
        public ushort e2eDelayPercent;

        public ushort frozenRatioPercent;

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

    public enum NETWORK_TYPE
    {
        NETWORK_TYPE_UNKNOWN = -1,

        NETWORK_TYPE_DISCONNECTED = 0,

        NETWORK_TYPE_LAN = 1,

        NETWORK_TYPE_WIFI = 2,

        NETWORK_TYPE_MOBILE_2G = 3,

        NETWORK_TYPE_MOBILE_3G = 4,

        NETWORK_TYPE_MOBILE_4G = 5,
    }

    public enum VIDEO_VIEW_SETUP_MODE
    {
        VIDEO_VIEW_SETUP_REPLACE = 0,

        VIDEO_VIEW_SETUP_ADD = 1,

        VIDEO_VIEW_SETUP_REMOVE = 2,
    }

    public class VideoCanvas
    {
        public view_t view;

        public uint uid;

        public UInt32 backgroundColor;

        public RENDER_MODE_TYPE renderMode;

        public VIDEO_MIRROR_MODE_TYPE mirrorMode;

        public VIDEO_VIEW_SETUP_MODE setupMode;

        public VIDEO_SOURCE_TYPE sourceType;

        public int mediaPlayerId;

        public Rectangle cropArea;

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

        public VideoCanvas(view_t view, uint uid, UInt32 backgroundColor, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, VIDEO_VIEW_SETUP_MODE setupMode, VIDEO_SOURCE_TYPE sourceType, int mediaPlayerId, Rectangle cropArea, bool enableAlphaMask)
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

    public class BeautyOptions
    {
        public LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel;

        public float lighteningLevel;

        public float smoothnessLevel;

        public float rednessLevel;

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

    public enum LIGHTENING_CONTRAST_LEVEL
    {
        LIGHTENING_CONTRAST_LOW = 0,

        LIGHTENING_CONTRAST_NORMAL = 1,

        LIGHTENING_CONTRAST_HIGH = 2,
    }

    public class LowlightEnhanceOptions
    {
        public LOW_LIGHT_ENHANCE_MODE mode;

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

    public enum LOW_LIGHT_ENHANCE_MODE
    {
        LOW_LIGHT_ENHANCE_AUTO = 0,

        LOW_LIGHT_ENHANCE_MANUAL = 1,
    }

    public enum LOW_LIGHT_ENHANCE_LEVEL
    {
        LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY = 0,

        LOW_LIGHT_ENHANCE_LEVEL_FAST = 1,
    }

    public class VideoDenoiserOptions
    {
        public VIDEO_DENOISER_MODE mode;

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

    public enum VIDEO_DENOISER_MODE
    {
        VIDEO_DENOISER_AUTO = 0,

        VIDEO_DENOISER_MANUAL = 1,
    }

    public enum VIDEO_DENOISER_LEVEL
    {
        VIDEO_DENOISER_LEVEL_HIGH_QUALITY = 0,

        VIDEO_DENOISER_LEVEL_FAST = 1,

        VIDEO_DENOISER_LEVEL_STRENGTH = 2,
    }

    public class ColorEnhanceOptions
    {
        public float strengthLevel;

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

    public class VirtualBackgroundSource
    {
        public BACKGROUND_SOURCE_TYPE background_source_type;

        public uint color;

        public string source;

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

    public enum BACKGROUND_SOURCE_TYPE
    {
        BACKGROUND_NONE = 0,

        BACKGROUND_COLOR = 1,

        BACKGROUND_IMG = 2,

        BACKGROUND_BLUR = 3,

        BACKGROUND_VIDEO = 4,
    }

    public enum BACKGROUND_BLUR_DEGREE
    {
        BLUR_DEGREE_LOW = 1,

        BLUR_DEGREE_MEDIUM = 2,

        BLUR_DEGREE_HIGH = 3,
    }

    public class SegmentationProperty
    {
        public SEG_MODEL_TYPE modelType;

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

    public enum SEG_MODEL_TYPE
    {
        SEG_MODEL_AI = 1,

        SEG_MODEL_GREEN = 2,
    }

    public enum AUDIO_TRACK_TYPE
    {
        AUDIO_TRACK_INVALID = -1,

        AUDIO_TRACK_MIXABLE = 0,

        AUDIO_TRACK_DIRECT = 1,
    }

    public class AudioTrackConfig
    {
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

        ULTRA_HIGH_QUALITY_VOICE = 0x01040100,
    }

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
    }

    public enum VOICE_CONVERSION_PRESET
    {
        VOICE_CONVERSION_OFF = 0x00000000,

        VOICE_CHANGER_NEUTRAL = 0x03010100,

        VOICE_CHANGER_SWEET = 0x03010200,

        VOICE_CHANGER_SOLID = 0x03010300,

        VOICE_CHANGER_BASS = 0x03010400,

        VOICE_CHANGER_CARTOON = 0x03010500,

        VOICE_CHANGER_CHILDLIKE = 0x03010600,

        VOICE_CHANGER_PHONE_OPERATOR = 0x03010700,

        VOICE_CHANGER_MONSTER = 0x03010800,

        VOICE_CHANGER_TRANSFORMERS = 0x03010900,

        VOICE_CHANGER_GROOT = 0x03010A00,

        VOICE_CHANGER_DARTH_VADER = 0x03010B00,

        VOICE_CHANGER_IRON_LADY = 0x03010C00,

        VOICE_CHANGER_SHIN_CHAN = 0x03010D00,

        VOICE_CHANGER_GIRLISH_MAN = 0x03010E00,

        VOICE_CHANGER_CHIPMUNK = 0x03010F00,
    }

    public enum HEADPHONE_EQUALIZER_PRESET
    {
        HEADPHONE_EQUALIZER_OFF = 0x00000000,

        HEADPHONE_EQUALIZER_OVEREAR = 0x04000001,

        HEADPHONE_EQUALIZER_INEAR = 0x04000002,
    }

    public class ScreenCaptureParameters
    {
        public VideoDimensions dimensions;

        public int frameRate;

        public int bitrate;

        public bool captureMouseCursor;

        public bool windowFocus;

        public view_t[] excludeWindowList;

        public int excludeWindowCount;

        public int highLightWidth;

        public uint highLightColor;

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

    public enum AUDIO_RECORDING_QUALITY_TYPE
    {
        AUDIO_RECORDING_QUALITY_LOW = 0,

        AUDIO_RECORDING_QUALITY_MEDIUM = 1,

        AUDIO_RECORDING_QUALITY_HIGH = 2,

        AUDIO_RECORDING_QUALITY_ULTRA_HIGH = 3,
    }

    public enum AUDIO_FILE_RECORDING_TYPE
    {
        AUDIO_FILE_RECORDING_MIC = 1,

        AUDIO_FILE_RECORDING_PLAYBACK = 2,

        AUDIO_FILE_RECORDING_MIXED = 3,
    }

    public enum AUDIO_ENCODED_FRAME_OBSERVER_POSITION
    {
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_RECORD = 1,

        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK = 2,

        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_MIXED = 3,
    }

    public class AudioRecordingConfiguration
    {
        public string filePath;

        public bool encode;

        public int sampleRate;

        public AUDIO_FILE_RECORDING_TYPE fileRecordingType;

        public AUDIO_RECORDING_QUALITY_TYPE quality;

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

    public class AudioEncodedFrameObserverConfig
    {
        public AUDIO_ENCODED_FRAME_OBSERVER_POSITION postionType;

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

    public enum AREA_CODE : uint
    {
        AREA_CODE_CN = 0x00000001,

        AREA_CODE_NA = 0x00000002,

        AREA_CODE_EU = 0x00000004,

        AREA_CODE_AS = 0x00000008,

        AREA_CODE_JP = 0x00000010,

        AREA_CODE_IN = 0x00000020,

        AREA_CODE_GLOB = (0xFFFFFFFF),
    }

    public enum AREA_CODE_EX : uint
    {
        AREA_CODE_OC = 0x00000040,

        AREA_CODE_SA = 0x00000080,

        AREA_CODE_AF = 0x00000100,

        AREA_CODE_KR = 0x00000200,

        AREA_CODE_HKMC = 0x00000400,

        AREA_CODE_US = 0x00000800,

        AREA_CODE_OVS = 0xFFFFFFFE,
    }

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
    }

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
    }

    public enum CHANNEL_MEDIA_RELAY_STATE
    {
        RELAY_STATE_IDLE = 0,

        RELAY_STATE_CONNECTING = 1,

        RELAY_STATE_RUNNING = 2,

        RELAY_STATE_FAILURE = 3,
    }

    public class ChannelMediaInfo
    {
        public string channelName;

        public string token;

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

    public class ChannelMediaRelayConfiguration
    {
        public ChannelMediaInfo[] srcInfo;

        public ChannelMediaInfo[] destInfos;

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

    public class UplinkNetworkInfo
    {
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

    public class PeerDownlinkInfo
    {
        public string uid;

        public VIDEO_STREAM_TYPE stream_type;

        public REMOTE_VIDEO_DOWNSCALE_LEVEL current_downscale_level;

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

        MODE_END,
    }

    public enum ENCRYPTION_ERROR_TYPE
    {
        ENCRYPTION_ERROR_INTERNAL_FAILURE = 0,

        ENCRYPTION_ERROR_DECRYPTION_FAILURE = 1,

        ENCRYPTION_ERROR_ENCRYPTION_FAILURE = 2,
    }

    public enum UPLOAD_ERROR_REASON
    {
        UPLOAD_SUCCESS = 0,

        UPLOAD_NET_ERROR = 1,

        UPLOAD_SERVER_ERROR = 2,
    }

    public enum PERMISSION_TYPE
    {
        RECORD_AUDIO = 0,

        CAMERA = 1,

        SCREEN_CAPTURE = 2,
    }

    public enum MAX_USER_ACCOUNT_LENGTH_TYPE
    {
        MAX_USER_ACCOUNT_LENGTH = 256,
    }

    public enum STREAM_SUBSCRIBE_STATE
    {
        SUB_STATE_IDLE = 0,

        SUB_STATE_NO_SUBSCRIBED = 1,

        SUB_STATE_SUBSCRIBING = 2,

        SUB_STATE_SUBSCRIBED = 3,
    }

    public enum STREAM_PUBLISH_STATE
    {
        PUB_STATE_IDLE = 0,

        PUB_STATE_NO_PUBLISHED = 1,

        PUB_STATE_PUBLISHING = 2,

        PUB_STATE_PUBLISHED = 3,
    }

    public class EchoTestConfiguration
    {
        public view_t view;

        public bool enableAudio;

        public bool enableVideo;

        public string token;

        public string channelId;

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

    public enum EAR_MONITORING_FILTER_TYPE
    {
        EAR_MONITORING_FILTER_NONE = (1 << 0),

        EAR_MONITORING_FILTER_BUILT_IN_AUDIO_FILTERS = (1 << 1),

        EAR_MONITORING_FILTER_NOISE_SUPPRESSION = (1 << 2),
    }

    public enum THREAD_PRIORITY_TYPE
    {
        LOWEST = 0,

        LOW = 1,

        NORMAL = 2,

        HIGH = 3,

        HIGHEST = 4,

        CRITICAL = 5,
    }

    public class ScreenVideoParameters
    {
        public VideoDimensions dimensions;

        public int frameRate;

        public int bitrate;

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

    public class ScreenAudioParameters
    {
        public int sampleRate;

        public int channels;

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

    public class ScreenCaptureParameters2
    {
        public bool captureAudio;

        public ScreenAudioParameters audioParams;

        public bool captureVideo;

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

    public enum MEDIA_TRACE_EVENT
    {
        MEDIA_TRACE_EVENT_VIDEO_RENDERED = 0,

        MEDIA_TRACE_EVENT_VIDEO_DECODED,
    }

    public class VideoRenderingTracingInfo
    {
        public int elapsedTime;

        public int start2JoinChannel;

        public int join2JoinSuccess;

        public int joinSuccess2RemoteJoined;

        public int remoteJoined2SetView;

        public int remoteJoined2UnmuteVideo;

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

    public enum CONFIG_FETCH_TYPE
    {
        CONFIG_FETCH_TYPE_INITIALIZE = 1,

        CONFIG_FETCH_TYPE_JOIN_CHANNEL = 2,
    }

    public class RecorderStreamInfo
    {
        public string channelId;

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

    public enum LOCAL_PROXY_MODE
    {
        ConnectivityFirst = 0,

        LocalOnly = 1,
    }

    public class LogUploadServerInfo
    {
        public string serverDomain;

        public string serverPath;

        public int serverPort;

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

    public class AdvancedConfigInfo
    {
        public LogUploadServerInfo logUploadServer;

        public AdvancedConfigInfo(LogUploadServerInfo logUploadServer)
        {
            this.logUploadServer = logUploadServer;
        }
        public AdvancedConfigInfo()
        {
        }
    }

    public class LocalAccessPointConfiguration
    {
        public string[] ipList;

        public int ipListSize;

        public string[] domainList;

        public int domainListSize;

        public string verifyDomainName;

        public LOCAL_PROXY_MODE mode;

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

    public class SpatialAudioParams : OptionalJsonParse
    {
        public Optional<double> speaker_azimuth = new Optional<double>();

        public Optional<double> speaker_elevation = new Optional<double>();

        public Optional<double> speaker_distance = new Optional<double>();

        public Optional<int> speaker_orientation = new Optional<int>();

        public Optional<bool> enable_blur = new Optional<bool>();

        public Optional<bool> enable_air_absorb = new Optional<bool>();

        public Optional<double> speaker_attenuation = new Optional<double>();

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