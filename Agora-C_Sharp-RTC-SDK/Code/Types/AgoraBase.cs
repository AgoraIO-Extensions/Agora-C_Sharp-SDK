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

        [Obsolete]
        ///
        /// <summary>
        /// 2: Gaming. This profile is deprecated.
        /// </summary>
        ///
        CHANNEL_PROFILE_GAME = 2,

        [Obsolete]
        ///
        /// <summary>
        /// Cloud gaming. The scenario is optimized for latency. Use this profile if the use case requires frequent interactions between users.
        /// </summary>
        ///
        CHANNEL_PROFILE_CLOUD_GAMING = 3,

        [Obsolete]
        ///
        /// @ignore
        ///
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
        /// 1: The SDK times out and the user drops offline because no data packet is received within a certain period of time.
        /// If the user quits the call and the message is not passed to the SDK (due to an unreliable channel), the SDK assumes the user dropped offline.
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

        ///
        /// @ignore
        ///
        AGORA_IID_PARAMETER_ENGINE = 3,

        ///
        /// @ignore
        ///
        AGORA_IID_MEDIA_ENGINE = 4,

        ///
        /// @ignore
        ///
        AGORA_IID_AUDIO_ENGINE = 5,

        ///
        /// @ignore
        ///
        AGORA_IID_VIDEO_ENGINE = 6,

        ///
        /// @ignore
        ///
        AGORA_IID_RTC_CONNECTION = 7,

        ///
        /// <summary>
        /// 
        /// </summary>
        ///
        AGORA_IID_SIGNALING_ENGINE = 8,

        ///
        /// @ignore
        ///
        AGORA_IID_MEDIA_ENGINE_REGULATOR = 9,

        ///
        /// @ignore
        ///
        AGORA_IID_CLOUD_SPATIAL_AUDIO = 10,

        ///
        /// @ignore
        ///
        AGORA_IID_LOCAL_SPATIAL_AUDIO = 11,

        ///
        /// <summary>
        /// The IMediaRecorder interface class.
        /// </summary>
        ///
        AGORA_IID_MEDIA_RECORDER = 12,
    };

    ///
    /// <summary>
    /// Network quality types.
    /// </summary>
    ///
    public enum QUALITY_TYPE
    {
        [Obsolete("This member is deprecated")]
        ///
        /// <summary>
        /// 0: The network quality is unknown.
        /// </summary>
        ///
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

    ///
    /// @ignore
    ///
    public enum FIT_MODE_TYPE
    {
        ///
        /// @ignore
        ///
        MODE_COVER = 1,

        ///
        /// @ignore
        ///
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
        /// 1: 1 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_1 = 1,

        ///
        /// <summary>
        /// 7: 7 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_7 = 7,

        ///
        /// <summary>
        /// 10: 10 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_10 = 10,

        ///
        /// <summary>
        /// 15: 15 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_15 = 15,

        ///
        /// <summary>
        /// 24: 24 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_24 = 24,

        ///
        /// <summary>
        /// 30: 30 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_30 = 30,

        ///
        /// <summary>
        /// 60: 60 fpsFor Windows and macOS only.
        /// </summary>
        ///
        FRAME_RATE_FPS_60 = 60,
    };

    ///
    /// @ignore
    ///
    public enum FRAME_WIDTH
    {
        ///
        /// @ignore
        ///
        FRAME_WIDTH_640 = 640,
    };

    ///
    /// @ignore
    ///
    public enum FRAME_HEIGHT
    {
        ///
        /// @ignore
        ///
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
        /// 3: Key frame.
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
        /// 5: The B frame.
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
        VIDEO_FRAME_TYPE_UNKNOW = 7
    };

    ///
    /// @ignore
    ///
    public enum VIDEO_FRAME_TYPE_NATIVE
    {
        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_BLANK_FRAME = 0,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_KEY_FRAME = 3,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_DELTA_FRAME = 4,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_B_FRAME = 5,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_DROPPABLE_FRAME = 6,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_UNKNOW = 7
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
        /// 0: (Default) The output video always follows the orientation of the captured video. The receiver takes the rotational information passed on from the video encoder. This mode applies to scenarios where video orientation can be adjusted on the receiver.If the captured video is in landscape mode, the output video is in landscape mode.If the captured video is in portrait mode, the output video is in portrait mode.
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
        /// 2: In this mode, the SDK always outputs video in portrait (portrait) mode. If the captured video is in landscape mode, the video encoder crops it to fit the output. Applies to situations where the receiving end cannot process the rotational information. For example, CDN live streaming.
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
        /// 0: (Default) Prefers to reduce the video frame rate while maintaining video quality during video encoding under limited bandwidth. This degradation preference is suitable for scenarios where video quality is prioritized.In the COMMUNICATION channel profile, the resolution of the video sent may change, so remote users need to handle this issue. See OnVideoSizeChanged .
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
        /// 2: Reduces the video frame rate and video quality simultaneously during video encoding under limited bandwidth. The MAINTAIN_BALANCED has a lower reduction than MAINTAIN_QUALITY and MAINTAIN_FRAMERATE, and this preference is suitable for scenarios where both smoothness and video quality are a priority.The resolution of the video sent may change, so remote users need to handle this issue. See OnVideoSizeChanged .
        /// </summary>
        ///
        MAINTAIN_BALANCED = 2,

        ///
        /// <summary>
        /// 3: When the bandwidth is limited, the video frame rate is preferentially reduced during video encoding.
        /// </summary>
        ///
        MAINTAIN_RESOLUTION = 3,

        ///
        /// @ignore
        ///
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
    };

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

        ///
        /// @ignore
        ///
        DEFAULT_MIN_BITRATE = -1,

        ///
        /// @ignore
        ///
        DEFAULT_MIN_BITRATE_EQUAL_TO_TARGET_BITRATE = -2,
    };

    ///
    /// <summary>
    /// Video codec types.
    /// </summary>
    ///
    public enum VIDEO_CODEC_TYPE
    {
        ///
        /// @ignore
        ///
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

        ///
        /// @ignore
        ///
        VIDEO_CODEC_VP9 = 5,

        ///
        /// <summary>
        /// 6: Generic.This type is used for transmitting raw video data, such as encrypted video frames. The SDK returns this type of video frames in callbacks, and you need to decode and render the frames yourself.
        /// </summary>
        ///
        VIDEO_CODEC_GENERIC = 6,

        ///
        /// @ignore
        ///
        VIDEO_CODEC_GENERIC_H264 = 7,

        ///
        /// @ignore
        ///
        VIDEO_CODEC_AV1 = 12,

        ///
        /// <summary>
        /// 20: Generic JPEG.This type consumes minimum computing resources and applies to IoT devices.
        /// </summary>
        ///
        VIDEO_CODEC_GENERIC_JPEG = 20,
    };

    ///
    /// @ignore
    ///
    public enum TCcMode
    {
        ///
        /// @ignore
        ///
        CC_ENABLED = 0,

        ///
        /// @ignore
        ///
        CC_DISABLED = 1,
    };

    ///
    /// @ignore
    ///
    public class SenderOptions
    {
        ///
        /// @ignore
        ///
        public TCcMode ccMode { set; get; }

        ///
        /// @ignore
        ///
        public VIDEO_CODEC_TYPE codecType { set; get; }

        ///
        /// @ignore
        ///
        public int targetBitrate { set; get; }

        public SenderOptions()
        {
            ccMode = TCcMode.CC_ENABLED;
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_GENERIC_H264;
            targetBitrate = 6500;
        }
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

        ///
        /// @ignore
        ///
        AUDIO_CODEC_LPCNET = 12,
    };

    [Flags]
    ///
    /// <summary>
    /// Audio encoding type.
    /// </summary>
    ///
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
        ///
        /// <summary>
        /// Use the positionInLandscapeMode and positionInPortraitMode values you set in WatermarkOptions . The settings in WatermarkRatio are invalid.
        /// </summary>
        ///
        FIT_MODE_COVER_POSITION = 0,

        ///
        /// <summary>
        /// Use the value you set in WatermarkRatio . The settings in positionInLandscapeMode and positionInPortraitMode in WatermarkOptions are invalid.
        /// </summary>
        ///
        FIT_MODE_USE_IMAGE_RATIO = 1
    };

    ///
    /// @ignore
    ///
    public class EncodedAudioFrameAdvancedSettings
    {
        public EncodedAudioFrameAdvancedSettings()
        {
            speech = true;
            sendEvenIfEmpty = true;
        }

        ///
        /// @ignore
        ///
        public bool speech { set; get; }

        ///
        /// @ignore
        ///
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

        ///
        /// <summary>
        /// Audio Codec type: AUDIO_CODEC_TYPE 
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
        /// This function is currently not supported.
        /// </summary>
        ///
        public EncodedAudioFrameAdvancedSettings advancedSettings { set; get; }

        ///
        /// <summary>
        /// The Unix timestamp (ms) for capturing the external encoded video frames.
        /// </summary>
        ///
        public int64_t captureTimeMs { set; get; }
    };

    ///
    /// @ignore
    ///
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

        ///
        /// @ignore
        ///
        public uint samplesPerChannel { set; get; }

        ///
        /// @ignore
        ///
        public short channelNum { set; get; }

        ///
        /// @ignore
        ///
        public uint samplesOut { set; get; }

        ///
        /// @ignore
        ///
        public int64_t elapsedTimeMs { set; get; }

        ///
        /// @ignore
        ///
        public int64_t ntpTimeMs { set; get; }
    };

    ///
    /// @ignore
    ///
    public enum H264PacketizeMode
    {
        ///
        /// @ignore
        ///
        NonInterleaved = 0,

        ///
        /// @ignore
        ///
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
    /// Video subscription options.
    /// </summary>
    ///
    public class VideoSubscriptionOptions : OptionalJsonParse
    {
        ///
        /// <summary>
        /// The video stream type that you want to subscribe to. The default value is VIDEO_STREAM_HIGH, meaning the high-quality video streams. See VIDEO_STREAM_TYPE .
        /// </summary>
        ///
        public Optional<VIDEO_STREAM_TYPE> type = new Optional<VIDEO_STREAM_TYPE>();

        ///
        /// <summary>
        /// Whether to subscribe to encoded video frames only:true: Subscribe to encoded video frames only (structured data).false: (Default) Subscribe to raw video frames.
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// Information about externally encoded video frames.
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

        ///
        /// <summary>
        /// The codec type of the local video stream. See VIDEO_CODEC_TYPE . The default value is VIDEO_CODEC_H264(2).
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType { set; get; }

        ///
        /// <summary>
        /// Width (pixel) of the video frame.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// Height (pixel) of the video frame.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// The number of video frames per second.When this parameter is not 0, you can use it to calculate the Unix timestamp of externally encoded video frames.
        /// </summary>
        ///
        public int framesPerSecond { set; get; }

        ///
        /// <summary>
        /// The video frame type. See VIDEO_FRAME_TYPE .
        /// </summary>
        ///
        public VIDEO_FRAME_TYPE_NATIVE frameType { set; get; }

        ///
        /// <summary>
        /// The rotation information of the video frame. See VIDEO_ORIENTATION .
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
        /// The Unix timestamp (ms) for capturing the external encoded video frames.
        /// </summary>
        ///
        public int64_t captureTimeMs { set; get; }

        ///
        /// <summary>
        /// The user ID to push the externally encoded video frame.
        /// </summary>
        ///
        public uint uid { set; get; }

        ///
        /// <summary>
        /// The type of video streams. See VIDEO_STREAM_TYPE .
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
        ///
        /// <summary>
        /// The codec type of the local video stream. See VIDEO_CODEC_TYPE .
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType { set; get; }

        ///
        /// <summary>
        /// The dimensions of the encoded video (px). This parameter measures the video encoding quality in the format of length × width. VideoDimensions 
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
        /// The minimum encoding bitrate (Kbps) of the video.The SDK automatically adjusts the encoding bitrate to adapt to the network conditions. Using a value greater than the default value forces the video encoder to output high-quality images but may cause more packet loss and sacrifice the smoothness of the video transmission. Unless you have special requirements for image quality, Agora does not recommend changing this value.This parameter only applies to the interactive streaming profile.
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
        /// Video degradation preference under limited bandwidth. See DEGRADATION_PREFERENCE .
        /// </summary>
        ///
        public DEGRADATION_PREFERENCE degradationPreference { set; get; }

        ///
        /// <summary>
        /// Sets the mirror mode of the published local video stream. It only affects the video that the remote user sees. See VIDEO_MIRROR_MODE_TYPE .By default, the video is not mirrored.
        /// </summary>
        ///
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
        /// Whether to synchronize the data packet with the published audio packet.true: Synchronize the data packet with the audio packet.false: Do not synchronize the data packet with the audio packet.When you set the data packet to synchronize with the audio, then if the data packet delay is within the audio delay, the SDK triggers the OnStreamMessage callback when the synchronized audio packet is played out. Do not set this parameter as true if you need the receiver to receive the data packet immediately. Agora recommends that you set this parameter to true only when you need to implement specific functions, for example, lyric synchronization.
        /// </summary>
        ///
        public bool syncWithAudio;

        ///
        /// <summary>
        /// Whether the SDK guarantees that the receiver receives the data in the sent order.true: Guarantee that the receiver receives the data in the sent order.false: Do not guarantee that the receiver receives the data in the sent order.Do not set this parameter as true if you need the receiver to receive the data packet immediately.
        /// </summary>
        ///
        public bool ordered;
    };

    ///
    /// @ignore
    ///
    public enum SIMULCAST_STREAM_MODE
    {
        ///
        /// @ignore
        ///
        AUTO_SIMULCAST_STREAM = -1,

        ///
        /// @ignore
        ///
        DISABLE_SIMULCAST_STREM = 0,

        ///
        /// @ignore
        ///
        ENABLE_SIMULCAST_STREAM = 1,
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
        /// The video dimension. See VideoDimensions . The default value is 160 × 120.
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
        /// The horizontal offset from the top-left corner.
        /// </summary>
        ///
        public int x { set; get; }

        ///
        /// <summary>
        /// The vertical offset from the top-left corner.
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
    /// The position and size of the watermark on the screen are determined by xRatio, yRatio, and widthRatio:(xRatio, yRatio) refers to the coordinates of the upper left corner of the watermark, which determines the distance from the upper left corner of the watermark to the upper left corner of the screen.The widthRatio determines the width of the watermark.
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
        /// The x-coordinate of the upper left corner of the watermark. The horizontal position relative to the origin, where the upper left corner of the screen is the origin, and the x-coordinate is the upper left corner of the watermark. The value range is [0.0,1.0], and the default value is 0.
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
        /// When the adaptation mode of the watermark is FIT_MODE_COVER_POSITION, it is used to set the area of the watermark image in landscape mode. See FIT_MODE_COVER_POSITION for details.
        /// </summary>
        ///
        public Rectangle positionInLandscapeMode { set; get; }

        ///
        /// <summary>
        /// When the adaptation mode of the watermark is FIT_MODE_COVER_POSITION, it is used to set the area of the watermark image in portrait mode. See FIT_MODE_COVER_POSITION for details.
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
        /// Application CPU usage (%).The value of cpuTotalUsage is always reported as 0 in the OnLeaveChannel callback.As of Android 8.1, you cannot get the CPU usage from this attribute due to system limitations.
        /// </summary>
        ///
        public double cpuAppUsage { set; get; }

        ///
        /// <summary>
        /// The system CPU usage (%).For Windows, in the multi-kernel environment, this member represents the average CPU usage. The value = (100 - System Idle Progress in Task Manager)/100.The value of cpuTotalUsage is always reported as 0 in the OnLeaveChannel callback.As of Android 8.1, you cannot get the CPU usage from this attribute due to system limitations.
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
        /// The memory ratio occupied by the app (%).This value is for reference only. Due to system limitations, you may not get this value.
        /// </summary>
        ///
        public double memoryAppUsageRatio { set; get; }

        ///
        /// <summary>
        /// The memory occupied by the system (%).This value is for reference only. Due to system limitations, you may not get this value.
        /// </summary>
        ///
        public double memoryTotalUsageRatio { set; get; }

        ///
        /// <summary>
        /// The memory size occupied by the app (KB).This value is for reference only. Due to system limitations, you may not get this value.
        /// </summary>
        ///
        public int memoryAppUsageInKbytes { set; get; }

        ///
        /// <summary>
        /// The duration (ms) between the SDK starts connecting and the connection is established. If the value reported is 0, it means invalid.
        /// </summary>
        ///
        public int connectTimeMs { set; get; }

        ///
        /// @ignore
        ///
        public int firstAudioPacketDuration { set; get; }

        ///
        /// @ignore
        ///
        public int firstVideoPacketDuration { set; get; }

        ///
        /// @ignore
        ///
        public int firstVideoKeyFramePacketDuration { set; get; }

        ///
        /// @ignore
        ///
        public int packetsBeforeFirstKeyFramePacket { set; get; }

        ///
        /// @ignore
        ///
        public int firstAudioPacketDurationAfterUnmute { set; get; }

        ///
        /// @ignore
        ///
        public int firstVideoPacketDurationAfterUnmute { set; get; }

        ///
        /// @ignore
        ///
        public int firstVideoKeyFramePacketDurationAfterUnmute { set; get; }

        ///
        /// @ignore
        ///
        public int firstVideoKeyFrameDecodedDurationAfterUnmute { set; get; }

        ///
        /// @ignore
        ///
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
        VIDEO_SOURCE_CAMERA_PRIMARY,
        ///
        /// <summary>
        /// The camera.
        /// </summary>
        ///
        VIDEO_SOURCE_CAMERA = VIDEO_SOURCE_CAMERA_PRIMARY,
        VIDEO_SOURCE_CAMERA_SECONDARY,
        VIDEO_SOURCE_SCREEN_PRIMARY,
        ///
        /// <summary>
        /// The screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN = VIDEO_SOURCE_SCREEN_PRIMARY,
        VIDEO_SOURCE_SCREEN_SECONDARY,
        VIDEO_SOURCE_CUSTOM,
        VIDEO_SOURCE_MEDIA_PLAYER,
        VIDEO_SOURCE_RTC_IMAGE_PNG,
        VIDEO_SOURCE_RTC_IMAGE_JPEG,
        VIDEO_SOURCE_RTC_IMAGE_GIF,
        VIDEO_SOURCE_REMOTE,
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

        public AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel;
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
        /// 1: The QoE of the local user is poor.
        /// </summary>
        ///
        EXPERIENCE_QUALITY_BAD = 1,
    };

    ///
    /// <summary>
    /// Reasons why the QoE of the local user when receiving a remote audio stream is poor.
    /// </summary>
    ///
    public enum EXPERIENCE_POOR_REASON
    {
        ///
        /// <summary>
        /// 0: No reason, indicating a good QoE of the local user.
        /// </summary>
        ///
        EXPERIENCE_REASON_NONE = 0,

        ///
        /// <summary>
        /// 1: The remote user's network quality is poor.
        /// </summary>
        ///
        REMOTE_NETWORK_QUALITY_POOR = 1,

        ///
        /// <summary>
        /// 2: The local user's network quality is poor.
        /// </summary>
        ///
        LOCAL_NETWORK_QUALITY_POOR = 2,

        ///
        /// <summary>
        /// 4: The local user's Wi-Fi or mobile network signal is weak.
        /// </summary>
        ///
        WIRELESS_SIGNAL_POOR = 4,

        ///
        /// <summary>
        /// 8: The local user enables both Wi-Fi and bluetooth, and their signals interfere with each other. As a result, audio transmission quality is undermined.
        /// </summary>
        ///
        WIFI_BLUETOOTH_COEXIST = 8,
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

        ///
        /// <summary>
        /// The user ID of the remote user.
        /// </summary>
        ///
        public uint uid { set; get; }

        ///
        /// <summary>
        /// The quality of the audio stream sent by the user. See QUALITY_TYPE .
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
        /// The network delay (ms) from the audio receiver to the jitter buffer.When the receiving end is an audience member and audienceLatencyLevel of ClientRoleOptions is 1, this parameter does not take effect.
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
        /// The quality of the remote audio stream in the reported interval. The quality is determined by the Agora real-time audio MOS (Mean Opinion Score) measurement method. The return value range is [0, 500]. Dividing the return value by 100 gets the MOS score, which ranges from 0 to 5. The higher the score, the better the audio quality.The subjective perception of audio quality corresponding to the Agora real-time audio MOS scores is as follows:MOS scorePerception of audio qualityGreater than 4Excellent. The audio sounds clear and smooth.From 3.5 to 4Good. The audio has some perceptible impairment but still sounds clear.From 3 to 3.5Fair. The audio freezes occasionally and requires attentive listening.From 2.5 to 3Poor. The audio sounds choppy and requires considerable effort to understand.From 2 to 2.5Bad. The audio has occasional noise. Consecutive audio dropouts occur, resulting in some information loss. The users can communicate only with difficulty.Less than 2Very bad. The audio has persistent noise. Consecutive audio dropouts are frequent, resulting in severe information loss. Communication is nearly impossible.
        /// </summary>
        ///
        public int mosValue { set; get; }

        ///
        /// <summary>
        /// The total active time (ms) between the start of the audio call and the callback of the remote user.The active time refers to the total duration of the remote user without the mute state.
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
        /// The Quality of Experience (QoE) of the local user when receiving a remote audio stream. See EXPERIENCE_QUALITY_TYPE .
        /// </summary>
        ///
        public int qoeQuality { set; get; }

        ///
        /// <summary>
        /// Reasons why the QoE of the local user when receiving a remote audio stream is poor. See EXPERIENCE_POOR_REASON .
        /// </summary>
        ///
        public int qualityChangedReason { set; get; }
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
        /// 0: The default audio profile.For the interactive streaming profile: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 64 Kbps.For the communication profile: Windows: A sample rate of 16 kHz, audio encoding, mono, and a bitrate of up to 16 Kbps.Android/macOS/iOS:
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
        /// 3: A sample rate of 48 kHz, music encoding, stereo, and a bitrate of up to 80 Kbps.To implement stereo audio, you also need to call SetAdvancedAudioOptions and set audioProcessingChannels to AUDIO_PROCESSING_STEREO in AdvancedAudioOptions.
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
        /// 5: A sample rate of 48 kHz, music encoding, stereo, and a bitrate of up to 128 Kbps.To implement stereo audio, you also need to call SetAdvancedAudioOptions and set audioProcessingChannels to AUDIO_PROCESSING_STEREO in AdvancedAudioOptions.
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
        /// Enumerator boundary.
        /// </summary>
        ///
        AUDIO_PROFILE_NUM = 7
    };

    ///
    /// <summary>
    /// The audio scenarios.
    /// </summary>
    ///
    public enum AUDIO_SCENARIO_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) Automatic scenario match, where the SDK chooses the appropriate audio quality according to the user role and audio route.
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
        /// 7: Real-time chorus scenario, where users have good network conditions and require ultra-low latency.
        /// </summary>
        ///
        AUDIO_SCENARIO_CHORUS = 7,

        ///
        /// <summary>
        /// 8: Meeting scenario that mainly contains the human voice.
        /// </summary>
        ///
        AUDIO_SCENARIO_MEETING = 8,
        
        ///
        /// <summary>
        /// The number of enumerations.
        /// </summary>
        ///
        AUDIO_SCENARIO_NUM = 9,
    };

    ///
    /// <summary>
    /// The format of the video frame.
    /// </summary>
    ///
    public class VideoFormat
    {
        ///
        /// @ignore
        ///
        public enum OPTIONAL_ENUM_SIZE_T
        {
        /* enum_optionalenumsizet_    kMaxWidthInPixels */
            kMaxWidthInPixels = 3840,
        /* enum_optionalenumsizet_    kMaxHeightInPixels */
            kMaxHeightInPixels = 2160,
        /* enum_optionalenumsizet_    kMaxFps */
            kMaxFps = 60,
        }

        public VideoFormat()
        {
        /* enum_optionalenumsizet_    width */
            width = (int)FRAME_WIDTH.FRAME_WIDTH_640;
        /* enum_optionalenumsizet_    height */
            height = (int)FRAME_HEIGHT.FRAME_HEIGHT_360;
        /* enum_optionalenumsizet_    fps */
            fps = (int)FRAME_RATE.FRAME_RATE_FPS_15;
        }

        public VideoFormat(int w, int h, int f)
        {
        /* enum_optionalenumsizet_    this.width */
            this.width = w;
        /* enum_optionalenumsizet_    this.height */
            this.height = h;
        /* enum_optionalenumsizet_    this.fps */
            this.fps = f;
        }

        ///
        /// <summary>
        /// The width (px) of the video frame.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// The height (px) of the video frame.
        /// </summary>
        ///
        public int height { set; get; }

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
    /// The screen sharing scenario.
    /// </summary>
    ///
    public enum SCREEN_SCENARIO_TYPE
    {
        ///
        /// <summary>
        /// 1: (Default) Document. This scenario prioritizes the video quality of screen sharing and reduces the latency of the shared video for the receiver. If you share documents, slides, and tables, you can set this scenario.
        /// </summary>
        ///
        SCREEN_SCENARIO_DOCUMENT = 1,

        ///
        /// <summary>
        /// 2: Game. This scenario prioritizes the smoothness of screen sharing. If you share games, you can set this scenario.
        /// </summary>
        ///
        SCREEN_SCENARIO_GAMING = 2,

        ///
        /// <summary>
        /// 3: Video. This scenario prioritizes the smoothness of screen sharing. If you share movies or live videos, you can set this scenario.
        /// </summary>
        ///
        SCREEN_SCENARIO_VIDEO = 3,

        ///
        /// <summary>
        /// 4: Remote control. This scenario prioritizes the video quality of screen sharing and reduces the latency of the shared video for the receiver. If you share the device desktop being remotely controlled, you can set this scenario.
        /// </summary>
        ///
        SCREEN_SCENARIO_RDC = 4,
    };

    ///
    /// <summary>
    /// The brightness level of the video image captured by the local camera.
    /// </summary>
    ///
    public enum CAPTURE_BRIGHTNESS_LEVEL_TYPE
    {
        ///
        /// <summary>
        /// -1: The SDK does not detect the brightness level of the video image. Wait a few seconds to get the brightness level from captureBrightnessLevel in the next callback.
        /// </summary>
        ///
        CAPTURE_BRIGHTNESS_LEVEL_INVALID = -1,

        ///
        /// <summary>
        /// 0: The brightness level of the video image is normal.
        /// </summary>
        ///
        CAPTURE_BRIGHTNESS_LEVEL_NORMAL = 0,

        ///
        /// <summary>
        /// 1: The brightness level of the video image is too bright.
        /// </summary>
        ///
        CAPTURE_BRIGHTNESS_LEVEL_BRIGHT = 1,

        ///
        /// <summary>
        /// 2: The brightness level of the video image is too dark.
        /// </summary>
        ///
        CAPTURE_BRIGHTNESS_LEVEL_DARK = 2,
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
        /// 0: The local audio is in the initial state.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The local audio capturing device starts successfully.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_RECORDING = 1,

        ///
        /// <summary>
        /// 2: The first audio frame encodes successfully.
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
        ///
        /// <summary>
        /// 0: The local audio is normal.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_OK = 0,
        
        ///
        /// <summary>
        /// 1: No specified reason for the local audio failure. Remind your users to try to rejoin the channel.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_FAILURE = 1,

        ///
        /// <summary>
        /// 2: No permission to use the local audio capturing device. Remind your users to grant permission.Deprecated:This enumerator is deprecated. Please use RECORD_AUDIO in the OnPermissionError callback instead.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        ///
        /// <summary>
        /// 3: (Android and iOS only) The local audio capture device is used. Remind your users to check whether another application occupies the microphone. Local audio capture automatically resumes after the microphone is idle for about five seconds. You can also try to rejoin the channel after the microphone is idle.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_BUSY = 3,

        ///
        /// <summary>
        /// 4: The local audio capture fails.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE = 4,

        ///
        /// <summary>
        /// 5: The local audio encoding fails.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE = 5,

        ///
        /// <summary>
        /// 6: (Windows only) The application cannot find the local audio capture device. Remind your users to check whether the microphone is connected to the device properly in the control plane of the device or if the microphone is working properly.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_NO_RECORDING_DEVICE = 6,

        ///
        /// <summary>
        /// 7: (Windows only) The application cannot find the local audio playback device. Remind your users to check whether the speaker is connected to the device properly in the control plane of the device or if the speaker is working properly.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_NO_PLAYOUT_DEVICE = 7,

        ///
        /// <summary>
        /// 8: (Android and iOS only) The local audio capture is interrupted by a system call, Siri, or alarm clock. Remind your users to end the phone call, Siri, or alarm clock if the local audio capture is required.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_INTERRUPTED = 8,

        ///
        /// <summary>
        /// 9: (Windows only) The ID of the local audio-capture device is invalid. Check the audio capture device ID.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_RECORD_INVALID_ID = 9,

        ///
        /// <summary>
        /// 10: (Windows only) The ID of the local audio-playback device is invalid. Check the audio playback device ID.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_PLAYOUT_INVALID_ID = 10,
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
    /// Local video state error codes.
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
        /// 2: No permission to use the local video capturing device. Remind the user to grant permissions and rejoin the channel.Deprecated:This enumerator is deprecated. Please use CAMERA in the OnPermissionError callback instead.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        ///
        /// <summary>
        /// 3: The local video capturing device is in use. Remind the user to check whether another application occupies the camera.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY = 3,

        ///
        /// <summary>
        /// 4: The local video capture fails. Remind your user to check whether the video capture device is working properly, whether the camera is occupied by another application, or try to rejoin the channel.
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
        /// 6:(For iOS only)The app is in the background. Remind the user that video capture cannot be performed normally when the app is in the background.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_INBACKGROUND = 6,

        ///
        /// <summary>
        /// 7:(For iOS only)The current application window is running in Slide Over, Split View, or Picture in Picture mode, and another app is occupying the camera. Remind the user that the application cannot capture video properly when the app is running in Slide Over, Split View, or Picture in Picture mode and another app is occupying the camera.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_MULTIPLE_FOREGROUND_APPS = 7,

        ///
        /// <summary>
        /// 8: Fails to find a local video capture device. Remind the user to check whether the camera is connected to the device properly or the camera is working properly, and then to rejoin the channel.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NOT_FOUND = 8,

        ///
        /// <summary>
        /// 9: (macOS only) The video capture device currently in use is disconnected (such as being unplugged).
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_DISCONNECTED = 9,

        ///
        /// <summary>
        /// 10:(macOS and Windows only) The SDK cannot find the video device in the video device list. Check whether the ID of the video device is valid.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_INVALID_ID = 10,

        ///
        /// <summary>
        /// 101: The current video capture device is unavailable due to excessive system pressure.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_SYSTEM_PRESSURE = 101,

        ///
        /// <summary>
        /// 11:(macOS only) The shared window is minimized when you call StartScreenCaptureByWindowId to share a window. The SDK cannot share a minimized window. You can cancel the minimization of this window at the application layer, for example by maximizing this window.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED = 11,

        ///
        /// <summary>
        /// 12:(macOS and Windows only) The error code indicates that a window shared by the window ID has been closed or a full-screen window shared by the window ID has exited full-screen mode. After exiting full-screen mode, remote users cannot see the shared window. To prevent remote users from seeing a black screen, Agora recommends that you immediately stop screen sharing.Common scenarios for reporting this error code:When the local user closes the shared window, the SDK reports this error code.The local user shows some slides in full-screen mode first, and then shares the windows of the slides. After the user exits full-screen mode, the SDK reports this error code.The local user watches a web video or reads a web document in full-screen mode first, and then shares the window of the web video or document. After the user exits full-screen mode, the SDK reports this error code.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_CLOSED = 12,

        ///
        /// <summary>
        /// 13: (Windows only) The window being shared is overlapped by another window, so the overlapped area is blacked out by the SDK during window sharing.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_OCCLUDED = 13,

        ///
        /// @ignore
        ///
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
        /// 0: The local audio is in the initial state. The SDK reports this state in the case of REMOTE_AUDIO_REASON_LOCAL_MUTED, REMOTE_AUDIO_REASON_REMOTE_MUTED or REMOTE_AUDIO_REASON_REMOTE_OFFLINE.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The first remote audio packet is received.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_STARTING = 1,

        ///
        /// <summary>
        /// 2: The remote audio stream is decoded and plays normally. The SDK reports this state in the case of REMOTE_AUDIO_REASON_NETWORK_RECOVERY, REMOTE_AUDIO_REASON_LOCAL_UNMUTED or REMOTE_AUDIO_REASON_REMOTE_UNMUTED.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_DECODING = 2,

        ///
        /// <summary>
        /// 3: The remote audio is frozen. The SDK reports this state in the case of REMOTE_AUDIO_REASON_NETWORK_CONGESTION.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_FROZEN = 3,

        ///
        /// <summary>
        /// 4: The remote audio fails to start. The SDK reports this state in the case of REMOTE_AUDIO_REASON_INTERNAL.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_FAILED = 4,
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
        /// 0: The remote video is in the initial state. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED, REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED, or REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The first remote video packet is received.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_STARTING = 1,

        ///
        /// <summary>
        /// 2: The remote video stream is decoded and plays normally. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY, REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED, REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED or REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY.
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
    /// The reason for the remote video state change.
    /// </summary>
    ///
    public enum REMOTE_VIDEO_STATE_REASON
    {
        ///
        /// <summary>
        /// 0: The SDK reports this reason when the video state changes.
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

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK = 8,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY = 9,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_LOW = 10,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_HIGH = 11,
    };

    [Flags]
    ///
    /// @ignore
    ///
    public enum REMOTE_USER_STATE
    {
        ///
        /// @ignore
        ///
        USER_STATE_MUTE_AUDIO = (1 << 0),

        ///
        /// @ignore
        ///
        USER_STATE_MUTE_VIDEO = (1 << 1),

        ///
        /// @ignore
        ///
        USER_STATE_ENABLE_VIDEO = (1 << 4),

        ///
        /// @ignore
        ///
        USER_STATE_ENABLE_LOCAL_VIDEO = (1 << 8),
    };

    ///
    /// @ignore
    ///
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

        ///
        /// @ignore
        ///
        public bool isLocal { set; get; }

        ///
        /// @ignore
        ///
        public uint ownerUid { set; get; }

        ///
        /// @ignore
        ///
        public uint trackId { set; get; }

        ///
        /// @ignore
        ///
        public string channelId { set; get; }

        ///
        /// @ignore
        ///
        public VIDEO_STREAM_TYPE streamType { set; get; }

        ///
        /// @ignore
        ///
        public VIDEO_CODEC_TYPE codecType { set; get; }

        ///
        /// @ignore
        ///
        public bool encodedFrameOnly { set; get; }

        ///
        /// @ignore
        ///
        public VIDEO_SOURCE_TYPE sourceType { set; get; }

        ///
        /// @ignore
        ///
        public uint observationPosition { set; get; }
    };

    ///
    /// @ignore
    ///
    public enum REMOTE_VIDEO_DOWNSCALE_LEVEL
    {
        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE = 0,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_1 = 1,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_2 = 2,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_3 = 3,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_4 = 4,
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
        /// The user ID.In the local user's callback, uid = 0.In the remote users' callback, uid is the user ID of a remote user whose instantaneous volume is one of the three highest.
        /// </summary>
        ///
        public uint uid { set; get; }

        ///
        /// <summary>
        /// The volume of the user. The value ranges between 0 (lowest volume) and 255 (highest volume). 
        /// </summary>
        ///
        public uint volume { set; get; }

        ///
        /// <summary>
        /// Voice activity status of the local user.0: The local user is not speaking.1: The local user is speaking.The vad parameter does not report the voice activity status of remote users. In a remote user's callback, the value of vad is always 1.To use this parameter, you must set reportVad to true when calling EnableAudioVolumeIndication .
        /// </summary>
        ///
        public uint vad { set; get; }

        ///
        /// <summary>
        /// The voice pitch of the local user. The value ranges between 0.0 and 4000.0.The voicePitch parameter does not report the voice pitch of remote users. In the remote users' callback, the value of voicePitch is always 0.0.
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
        /// 66: Baseline video codec profile; generally used for video calls on mobile phones.
        /// </summary>
        ///
        VIDEO_CODEC_PROFILE_BASELINE = 66,

        ///
        /// <summary>
        /// 77: Main video codec profile; generally used in mainstream electronics such as MP4 players, portable video players, PSP, and iPads.
        /// </summary>
        ///
        VIDEO_CODEC_PROFILE_MAIN = 77,

        ///
        /// <summary>
        /// 100: (Default) High video codec profile; generally used in high-resolution live streaming or television.
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

        public LocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate, int internalCodec, ushort txPacketLossRate, int audioDeviceDelay)
        {
            this.numChannels = numChannels;
            this.sentSampleRate = sentSampleRate;
            this.sentBitrate = sentBitrate;
            this.internalCodec = internalCodec;
            this.txPacketLossRate = txPacketLossRate;
            this.audioDeviceDelay = audioDeviceDelay;
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

        ///
        /// <summary>
        /// The delay of the audio device module when playing or recording audio.
        /// </summary>
        ///
        public int audioDeviceDelay { set; get; }
    }

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
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: The SDK is connecting to Agora's streaming server and the CDN server.
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
        /// 3: The RTMP or RTMPS streaming is recovering. When exceptions occur to the CDN, or the streaming is interrupted, the SDK tries to resume RTMP or RTMPS streaming and returns this state.If the SDK successfully resumes the streaming, RTMP_STREAM_PUBLISH_STATE_RUNNING(2) returns.
        /// If the streaming does not resume within 60 seconds or server errors occur, RTMP_STREAM_PUBLISH_STATE_FAILURE(4) returns. You can also reconnect to the server by calling the StopRtmpStream method.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        ///
        /// <summary>
        /// 4: The RTMP or RTMPS streaming fails. See the errCode parameter for the detailed error information.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,

        ///
        /// <summary>
        /// 5: The SDK is disconnecting from the Agora streaming server and CDN. When you call StopRtmpStream to stop the streaming normally, the SDK reports the streaming state as RTMP_STREAM_PUBLISH_STATE_DISCONNECTING and RTMP_STREAM_PUBLISH_STATE_IDLE in sequence.
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
        /// 1: Invalid argument used. Check the parameter setting. 
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
        /// 3: Timeout for the RTMP or RTMPS streaming. Try to publish the streaming again.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT = 3,

        ///
        /// <summary>
        /// 4: An error occurs in Agora's streaming server. Try to publish the streaming again.
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
        /// 6: The RTMP or RTMPS streaming publishing requests are too frequent.
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
        RTMP_STREAM_PUBLISH_ERROR_NOT_BROADCASTER = 11,

        ///
        /// <summary>
        /// 13: The UpdateRtmpTranscoding or setLiveTranscoding method is called to update the transcoding configuration in a scenario where there is streaming without transcoding. Check your application code logic.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_TRANSCODING_NO_MIX_STREAM = 13,

        ///
        /// <summary>
        /// 14: Errors occurred in the host's network.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_NET_DOWN = 14,

        ///
        /// <summary>
        /// 15: Your App ID does not have permission to use the CDN live streaming function. 
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_INVALID_APPID = 15,

        ///
        /// @ignore
        ///
        RTMP_STREAM_PUBLISH_ERROR_INVALID_PRIVILEGE = 16,

        ///
        /// <summary>
        /// 100: The streaming has been stopped normally. After you call StopRtmpStream to stop streaming, the SDK returns this value.
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
        /// 2: The streaming URL is already being used for CDN live streaming. If you want to start new streaming, use a new streaming URL.
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
        /// The transparency of the watermark or background image. The value ranges between 0.0 and 1.0:0.0: Completely transparent.1.0: (Default) Opaque.
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
        /// Whether to enable the advanced features of streaming with transcoding:true: Enable the advanced features.false: (Default) Do not enable the advanced features.
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
        /// 1: The SDK is disconnected from the Agora edge server. The state indicates the SDK is in one of the following phases:Theinitial state before calling the JoinChannel [2/2] method.The app calls the LeaveChannel [1/2] 
        /// </summary>
        ///
        CONNECTION_STATE_DISCONNECTED = 1,

        ///
        /// <summary>
        /// 2: The SDK is connecting to the Agora edge server. This state indicates that the SDK is establishing a connection with the specified channel after the app calls JoinChannel [2/2].If the SDK successfully joins the channel, it triggers the OnConnectionStateChanged callback and the connection state switches to CONNECTION_STATE_CONNECTED.After the connection is established, the SDK also initializes the media and triggers OnJoinChannelSuccess when everything is ready.
        /// </summary>
        ///
        CONNECTION_STATE_CONNECTING = 2,

        ///
        /// <summary>
        /// 3: The SDK is connected to the Agora edge server. This state also indicates that the user has joined a channel and can now publish or subscribe to a media stream in the channel. If the connection to the channel is lost because, for example, if the network is down or switched, the SDK automatically tries to reconnect and triggers OnConnectionStateChanged callback, notifying that the current network state becomes CONNECTION_STATE_RECONNECTING.
        /// </summary>
        ///
        CONNECTION_STATE_CONNECTED = 3,

        ///
        /// <summary>
        /// 4: The SDK keeps reconnecting to the Agora edge server. The SDK keeps rejoining the channel after being disconnected from a joined channel because of network issues.If the SDK cannot rejoin the channel within 10 seconds, it triggers OnConnectionLost , stays in the CONNECTION_STATE_RECONNECTING state, and keeps rejoining the channel.If the SDK fails to rejoin the channel 20 minutes after being disconnected from the Agora edge server, the SDK triggers the OnConnectionStateChanged callback, switches to the CONNECTION_STATE_FAILED state, and stops rejoining the channel.
        /// </summary>
        ///
        CONNECTION_STATE_RECONNECTING = 4,

        ///
        /// <summary>
        /// 5: The SDK fails to connect to the Agora edge server or join the channel. This state indicates that the SDK stops trying to rejoin the channel. You must call LeaveChannel [1/2] You can call JoinChannel [2/2] to rejoin the channel.If the SDK is banned from joining the channel by the Agora edge server through the RESTful API, the SDK triggers the OnConnectionStateChanged callback.
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
        /// The layer index number of the host's video. The value range is [0,100].
        /// 0: (Default) The host's video is the bottom layer.100: The host's video is the top layer.If the value is less than 0 or greater than 100, the error ERR_INVALID_ARGUMENT is returned.Starting from v2.3, setting zOrder to 0 is supported.
        /// </summary>
        ///
        public int zOrder { set; get; }

        ///
        /// <summary>
        /// The transparency of the host's video. The value range is [0.0,1.0].
        /// 0.0: Completely transparent.1.0: (Default) Opaque.
        /// </summary>
        ///
        public double alpha { set; get; }

        ///
        /// <summary>
        /// The audio channel used by the host's audio in the output audio. The default value is 0, and the value range is [0, 5].0: (Recommended) The defaut setting, which supports dual channels at most and depends on the upstream of the host.1: The host's audio uses the FL audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.2: The host's audio uses the FC audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.3: The host's audio uses the FR audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.4: The host's audio uses the BL audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.5: The host's audio uses the BR audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.0xFF or a value greater than 5: The host's audio is muted, and the Agora server removes the host's audio.If the value is not 0, a special player is required.
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
        /// The width of the video in pixels. The default value is 360.When pushing video streams to the CDN, the value range of width is [64,1920]. If the value is less than 64, Agora server automatically adjusts it to 64; if the value is greater than 1920, Agora server automatically adjusts it to 1920.When pushing audio streams to the CDN, set width and height as 0.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// The height of the video in pixels. The default value is 640.When pushing video streams to the CDN, the value range of height is [64,1080]. If the value is less than 64, Agora server automatically adjusts it to 64; if the value is greater than 1080, Agora server automatically adjusts it to 1080.When pushing audio streams to the CDN, set width and height as 0.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// Bitrate of the output video stream for Media Push in Kbps. The default value is 400 Kbps.
        /// </summary>
        ///
        public int videoBitrate { set; get; }

        ///
        /// <summary>
        /// Frame rate (in fps) of the output video stream set for Media Push. The default value is 15 , and the value range is (0,30].The Agora server adjusts any value over 30 to 30.
        /// </summary>
        ///
        public int videoFramerate { set; get; }

        ///
        /// <summary>
        /// DeprecatedThis parameter is deprecated.Latency mode:true: Low latency with unassured quality.false: (Default) High latency with assured quality.
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
        /// Video codec profile type for Media Push. Set it as 66, 77, or 100 (default). See VIDEO_CODEC_PROFILE_TYPE for details.If you set this parameter to any other value, Agora adjusts it to the default value.
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
        /// DeprecatedThis parameter is deprecated.The metadata sent to the CDN client.
        /// </summary>
        ///
        public string metadata { set; get; }

        ///
        /// <summary>
        /// The watermark on the live video. The image format needs to be PNG. See RtcImage .You can add one watermark, or add multiple watermarks using an array. This parameter is used with watermarkCount.
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
        /// The number of background images on the live video. The image format needs to be PNG. See RtcImage .You can add a background image or use an array to add multiple background images. This parameter is used with backgroundImageCount.
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
        /// The number of audio channels for Media Push. Agora recommends choosing 1 (mono), or 2 (stereo) audio channels. Special players are required if you choose 3, 4, or 5.1: (Default) Mono.2: Stereo.3: Three audio channels.4: Four audio channels.5: Five audio channels.
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
        /// The ID of the remote user.Use this parameter only when the source type of the video for the video mixing on the local client is VIDEO_SOURCE_REMOTE.
        /// </summary>
        ///
        public uint remoteUserUid { set; get; }

        ///
        /// <summary>
        /// The URL of the image.
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
        /// The number of the layer to which the video for the video mixing on the local client belongs. The value range is [0,100].0: (Default) The layer is at the bottom.100: The layer is at the top.
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
        /// Whether to mirror the video for the video mixing on the local client.true: Mirror the captured video.false: (Default) Do not mirror the captured video.The paramter only works for videos with the source type CAMERA
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
        /// Sets whether to test the uplink network. Some users, for example, the audience members in a LIVE_BROADCASTING channel, do not need such a test.true: Test.false: Not test.
        /// </summary>
        ///
        public bool probeUplink { set; get; }

        ///
        /// <summary>
        /// Sets whether to test the downlink network:true: Test.false: Not test.
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
        /// 8: The connection failed because the token is not valid. Typical reasons include:The App Certificate for the project is enabled in Agora Console, but you do not use a token when joining the channel. If you enable the App Certificate, you must use a token to join the channel.The uid specified when calling JoinChannel [2/2] to join the channel is inconsistent with the uid passed in when generating the token.
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
        /// 10: The connection is rejected by server. Typical reasons include:The user is already in the channel and still calls a method, for example, JoinChannel [2/2], to join the channel. Stop calling this method to clear this error.The user tries to join the channel when conducting a pre-call test. The user needs to call the channel after the call test ends.
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
        /// 15: The SDK has rejoined the channel successfully.
        /// </summary>
        ///
        CONNECTION_CHANGED_REJOIN_SUCCESS = 15,

        ///
        /// <summary>
        /// 16: The connection between the SDK and the server is lost.
        /// </summary>
        ///
        CONNECTION_CHANGED_LOST = 16,

        ///
        /// <summary>
        /// 17: The connection state changes due to the echo test.
        /// </summary>
        ///
        CONNECTION_CHANGED_ECHO_TEST = 17,

        ///
        /// @ignore
        ///
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,

        ///
        /// @ignore
        ///
        CONNECTION_CHANGED_SAME_UID_LOGIN = 19,

        ///
        /// @ignore
        ///
        CONNECTION_CHANGED_TOO_MANY_BROADCASTERS = 20,
    };

    ///
    /// <summary>
    /// The reason for a user role switch failure.
    /// </summary>
    ///
    public enum CLIENT_ROLE_CHANGE_FAILED_REASON
    {
        ///
        /// <summary>
        /// 1: The number of hosts in the channel is already at the upper limit.This enumerator is reported only when the support for 128 users is enabled. The maximum number of hosts is based on the actual number of hosts configured when you enable the 128-user feature.
        /// </summary>
        ///
        CLIENT_ROLE_CHANGE_FAILED_TOO_MANY_BROADCASTERS = 1,

        ///
        /// <summary>
        /// 2: The request is rejected by the Agora server. Agora recommends you prompt the user to try to switch their user role again.
        /// </summary>
        ///
        CLIENT_ROLE_CHANGE_FAILED_NOT_AUTHORIZED = 2,

        ///
        /// <summary>
        /// 3: The request is timed out. Agora recommends you prompt the user to check the network connection and try to switch their user role again.
        /// </summary>
        ///
        CLIENT_ROLE_CHANGE_FAILED_REQUEST_TIME_OUT = 3,

        ///
        /// <summary>
        /// 4: The SDK connection fails. You can use reason reported in the OnConnectionStateChanged callback to troubleshoot the failure.
        /// </summary>
        ///
        CLIENT_ROLE_CHANGE_FAILED_CONNECTION_FAILED = 4,
    };

    ///
    /// @ignore
    ///
    public enum WLACC_MESSAGE_REASON
    {
        ///
        /// @ignore
        ///
        WLACC_MESSAGE_REASON_WEAK_SIGNAL = 0,

        ///
        /// @ignore
        ///
        WLACC_MESSAGE_REASON_CHANNEL_CONGESTION = 1,
    };

    ///
    /// @ignore
    ///
    public enum WLACC_SUGGEST_ACTION
    {
        ///
        /// @ignore
        ///
        WLACC_SUGGEST_ACTION_CLOSE_TO_WIFI = 0,

        ///
        /// @ignore
        ///
        WLACC_SUGGEST_ACTION_CONNECT_SSID = 1,

        ///
        /// @ignore
        ///
        WLACC_SUGGEST_ACTION_CHECK_5G = 2,

        ///
        /// @ignore
        ///
        WLACC_SUGGEST_ACTION_MODIFY_SSID = 3,
    };

    ///
    /// @ignore
    ///
    public class WlAccStats
    {
        ///
        /// @ignore
        ///
        public ushort e2eDelayPercent { set; get; }

        ///
        /// @ignore
        ///
        public ushort frozenRatioPercent { set; get; }

        ///
        /// @ignore
        ///
        public ushort lossRatePercent { set; get; }
    };

    ///
    /// <summary>
    /// Network type.
    /// </summary>
    ///
    public enum NETWORK_TYPE
    {
        ///
        /// <summary>
        /// -1: The network type is unknown.
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

    ///
    /// @ignore
    ///
    public enum VIDEO_VIEW_SETUP_MODE
    {
        ///
        /// @ignore
        ///
        VIDEO_VIEW_SETUP_REPLACE = 0,

        ///
        /// @ignore
        ///
        VIDEO_VIEW_SETUP_ADD = 1,

        ///
        /// @ignore
        ///
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
        /// The mirror mode of the view. See VIDEO_MIRROR_MODE_TYPE .For the mirror mode of the local video view: If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.For the remote user: The mirror mode is disabled by default.
        /// </summary>
        ///
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }

        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint uid { set; get; }

        ///
        /// @ignore
        ///
        public bool isScreenView { set; get; }

        ///
        /// @ignore
        ///
        public byte[] priv { set; get; }

        ///
        /// @ignore
        ///
        public uint priv_size { set; get; }

        ///
        /// <summary>
        /// The type of the video source, see VIDEO_SOURCE_TYPE .
        /// </summary>
        ///
        public VIDEO_SOURCE_TYPE sourceType { set; get; }

        ///
        /// @ignore
        ///
        public Rectangle cropArea { set; get; }

        ///
        /// @ignore
        ///
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
        /// 0: Low contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_LOW = 0,

        ///
        /// <summary>
        /// 1: (Default) Normal contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_NORMAL = 1,

        ///
        /// <summary>
        /// 2: High contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_HIGH = 2
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
        /// The brightening level, in the range [0.0,1.0], where 0.0 means the original brightening. The default value is 0.0. The higher the value, the greater the degree of brightening.
        /// </summary>
        ///
        public float lighteningLevel { set; get; }

        ///
        /// <summary>
        /// The smoothness level, in the range [0.0,1.0], where 0.0 means the original smoothness. The default value is 0.0. The higher the value, the greater the smoothness level.
        /// </summary>
        ///
        public float smoothnessLevel { set; get; }

        ///
        /// <summary>
        /// The redness level, in the range [0.0,1.0], where 0.0 means the original redness. The default value is 0.0. The higher the value, the greater the redness level.
        /// </summary>
        ///
        public float rednessLevel { set; get; }

        ///
        /// <summary>
        /// The sharpness level, in the range [0.0,1.0], where 0.0 means the original sharpness. The default value is 0.0. The larger the value, the greater the sharpness level.
        /// </summary>
        ///
        public float sharpnessLevel { set; get; }
    };

    ///
    /// <summary>
    /// The low-light enhancement mode.
    /// </summary>
    ///
    public enum LOW_LIGHT_ENHANCE_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) Automatic mode. The SDK automatically enables or disables the low-light enhancement feature according to the ambient light to compensate for the lighting level or prevent overexposure, as necessary.
        /// </summary>
        ///
        LOW_LIGHT_ENHANCE_AUTO = 0,

        ///
        /// <summary>
        /// 1: Manual mode. Users need to enable or disable the low-light enhancement feature manually.
        /// </summary>
        ///
        LOW_LIGHT_ENHANCE_MANUAL = 1
    };

    ///
    /// <summary>
    /// The low-light enhancement level.
    /// </summary>
    ///
    public enum LOW_LIGHT_ENHANCE_LEVEL
    {
        ///
        /// <summary>
        /// 0: (Default) Promotes video quality during low-light enhancement. It processes the brightness, details, and noise of the video image. The performance consumption is moderate, the processing speed is moderate, and the overall video quality is optimal.
        /// </summary>
        ///
        LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY = 0,

        ///
        /// <summary>
        /// 1: Promotes performance during low-light enhancement. It processes the brightness and details of the video image. The processing speed is faster.
        /// </summary>
        ///
        LOW_LIGHT_ENHANCE_LEVEL_FAST = 1
    };

    ///
    /// <summary>
    /// The low-light enhancement options.
    /// </summary>
    ///
    public class LowlightEnhanceOptions
    {
        ///
        /// <summary>
        /// The low-light enhancement mode. See LOW_LIGHT_ENHANCE_MODE .
        /// </summary>
        ///
        public LOW_LIGHT_ENHANCE_MODE mode { set; get; }

        ///
        /// <summary>
        /// The low-light enhancement level. See LOW_LIGHT_ENHANCE_LEVEL .
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// Video noise reduction mode.
    /// </summary>
    ///
    public enum VIDEO_DENOISER_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) Automatic mode. The SDK automatically enables or disables the video noise reduction feature according to the ambient light.
        /// </summary>
        ///
        VIDEO_DENOISER_AUTO = 0,

        ///
        /// <summary>
        /// 1: Manual mode. Users need to enable or disable the video noise reduction feature manually.
        /// </summary>
        ///
        VIDEO_DENOISER_MANUAL = 1
    };

    ///
    /// <summary>
    /// The video noise reduction level.
    /// </summary>
    ///
    public enum VIDEO_DENOISER_LEVEL
    {
        ///
        /// <summary>
        /// 0: (Default) Promotes video quality during video noise reduction. balances performance consumption and video noise reduction quality. The performance consumption is moderate, the video noise reduction speed is moderate, and the overall video quality is optimal.
        /// </summary>
        ///
        VIDEO_DENOISER_LEVEL_HIGH_QUALITY = 0,

        ///
        /// <summary>
        /// 1: Promotes reducing performance consumption during video noise reduction. It prioritizes reducing performance consumption over video noise reduction quality. The performance consumption is lower, and the video noise reduction speed is faster. To avoid a noticeable shadowing effect (shadows trailing behind moving objects) in the processed video, Agora recommends that you use FAST when the camera is fixed.
        /// </summary>
        ///
        VIDEO_DENOISER_LEVEL_FAST = 1,

        ///
        /// <summary>
        /// 2: Enhanced video noise reduction. It prioritizes video noise reduction quality over reducing performance consumption. The performance consumption is higher, the video noise reduction speed is slower, and the video noise reduction quality is better. If is not enough for your video noise reduction needs, you can use this enumerator.VIDEO_DENOISER_LEVEL_HIGH_QUALITY
        /// </summary>
        ///
        VIDEO_DENOISER_LEVEL_STRENGTH = 2
    };

    ///
    /// <summary>
    /// Video noise reduction options.
    /// </summary>
    ///
    public class VideoDenoiserOptions
    {
        ///
        /// <summary>
        /// Video noise reduction mode. 
        /// </summary>
        ///
        public VIDEO_DENOISER_MODE mode { set; get; }

        ///
        /// <summary>
        /// Video noise reduction level. 
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// The color enhancement options.
    /// </summary>
    ///
    public class ColorEnhanceOptions
    {
        ///
        /// <summary>
        /// The level of color enhancement. The value range is [0.0, 1.0]. 0.0 is the default value, which means no color enhancement is applied to the video. The higher the value, the higher the level of color enhancement. The default value is 0.5.
        /// </summary>
        ///
        public float strengthLevel { set; get; }

        ///
        /// <summary>
        /// The level of skin tone protection. The value range is [0.0, 1.0]. 0.0 means no skin tone protection. The higher the value, the higher the level of skin tone protection. The default value is 1.0.When the level of color enhancement is higher, the portrait skin tone can be significantly distorted, so you need to set the level of skin tone protection.When the level of skin tone protection is higher, the color enhancement effect can be slightly reduced.Therefore, to get the best color enhancement effect, Agora recommends that you adjust strengthLevel and skinProtectLevel to get the most appropriate values.
        /// </summary>
        ///
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

        public BACKGROUND_SOURCE_TYPE background_source_type;

        public uint color;

        public string source;

        public BACKGROUND_BLUR_DEGREE blur_degree;
    };

    ///
    /// <summary>
    /// The type of algorithms to user for background processing.
    /// </summary>
    ///
    public enum SEG_MODEL_TYPE
    {
        ///
        /// <summary>
        /// 1: (Default) Use the algorithm suitable for all scenarios.
        /// </summary>
        ///
        SEG_MODEL_AI = 1,

        ///
        /// <summary>
        /// 2: Use the algorithm designed specifically for scenarios with a green screen background.
        /// </summary>
        ///
        SEG_MODEL_GREEN = 2
    };

    ///
    /// <summary>
    /// Processing properties for background images.
    /// </summary>
    ///
    public class SegmentationProperty
    {
        ///
        /// <summary>
        /// The type of algorithms to user for background processing. See SEG_MODEL_TYPE .
        /// </summary>
        ///
        public SEG_MODEL_TYPE modelType { set; get; }
        ///
        /// <summary>
        /// The range of accuracy for identifying green colors (different shades of green) in the view. The value range is [0,1], and the default value is 0.5. The larger the value, the wider the range of identifiable shades of green. When the value of this parameter is too large, the edge of the portrait and the green color in the portrait range are also detected. Agora recommends that you dynamically adjust the value of this parameter according to the actual effect.This parameter only takes effect when modelType is set to SEG_MODEL_GREEN.
        /// </summary>
        ///
        public float greenCapacity { set; get; }

        public SegmentationProperty()
        {
            modelType = SEG_MODEL_TYPE.SEG_MODEL_AI;
            greenCapacity = 0.5f;
        }
    };

    [Flags]
    ///
    /// <summary>
    /// The options for SDK preset voice beautifier effects.
    /// </summary>
    ///
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
        /// A more magnetic voice.Agora recommends using this enumerator to process a male-sounding voice; otherwise, you may experience vocal distortion.
        /// </summary>
        ///
        CHAT_BEAUTIFIER_MAGNETIC = 0x01010100,

        ///
        /// <summary>
        /// A fresher voice.Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion.
        /// </summary>
        ///
        CHAT_BEAUTIFIER_FRESH = 0x01010200,

        ///
        /// <summary>
        /// A more vital voice.Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion.
        /// </summary>
        ///
        CHAT_BEAUTIFIER_VITALITY = 0x01010300,

        ///
        /// <summary>
        /// Singing beautifier effect.If you call SetVoiceBeautifierPreset (SINGING_BEAUTIFIER), you can beautify a male-sounding voice and add a reverberation effect that sounds like singing in a small room. Agora recommends using this enumerator to process a male-sounding voice; otherwise, you might experience vocal distortion.If you call SetVoiceBeautifierParameters (SINGING_BEAUTIFIER, param1, param2), you can beautify a male or female-sounding voice and add a reverberation effect.
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

        ///
        /// <summary>
        /// A ultra-high quality voice, which makes the audio clearer and restores more details.To achieve better audio effect quality, Agora recommends that you set the profile of SetAudioProfile [2/2] to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) and scenario to AUDIO_SCENARIO_GAME_STREAMING(3) before calling SetVoiceBeautifierPreset .If you have an audio capturing device that can already restore audio details to a high degree, Agora recommends that you do not enable ultra-high quality; otherwise, the SDK may over-restore audio details, and you may not hear the anticipated voice effect.
        /// </summary>
        ///
        ULTRA_HIGH_QUALITY_VOICE = 0x01040100
    };

    [Flags]
    ///
    /// <summary>
    /// Preset audio effects.
    /// To get better audio effects, Agora recommends calling SetAudioProfile [1/2] and setting the profile parameter as recommended below before using the preset audio effects.
    /// </summary>
    ///
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
        /// A 3D voice effect that makes the voice appear to be moving around the user. The default cycle period is 10 seconds. After setting this effect, you can call SetAudioEffectParameters to modify the movement period.If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_3D_VOICE = 0x02010800,

        ///
        /// <summary>
        /// Virtual surround sound, that is, the SDK generates a simulated surround sound field on the basis of stereo channels, thereby creating a surround sound effect.If the virtual surround sound is enabled, users need to use stereo audio playback devices to hear the anticipated audio effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_VIRTUAL_SURROUND_SOUND = 0x02010900,

        ///
        /// <summary>
        /// A middle-aged man's voice.Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_UNCLE = 0x02020100,

        ///
        /// <summary>
        /// An older man's voice.Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_OLDMAN = 0x02020200,

        ///
        /// <summary>
        /// A boy's voice.Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_BOY = 0x02020300,

        ///
        /// <summary>
        /// A young woman's voice.Agora recommends using this preset to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_SISTER = 0x02020400,

        ///
        /// <summary>
        /// A girl's voice.Agora recommends using this preset to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect.
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
        /// </summary>
        ///
        STYLE_TRANSFORMATION_RNB = 0x02030100,

        ///
        /// <summary>
        /// The voice effect typical of popular music.
        /// </summary>
        ///
        STYLE_TRANSFORMATION_POPULAR = 0x02030200,

        ///
        /// <summary>
        /// A pitch correction effect that corrects the user's pitch based on the pitch of the natural C major scale. After setting this voice effect, you can call SetAudioEffectParameters to adjust the basic mode of tuning and the pitch of the main tone.
        /// </summary>
        ///
        PITCH_CORRECTION = 0x02040100,
    };

    [Flags]
    ///
    /// <summary>
    /// The options for SDK preset voice conversion effects.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// On Windows and macOS, it represents the video encoding resolution of the shared screen stream. If the screen dimensions are different from the value of this parameter, Agora applies the following strategies for encoding. Suppose dimensions is set to 1920 x 1080:If the value of the screen dimensions is lower than that of dimensions, for example, 1000 x 1000 pixels, the SDK uses 1000 x 1000 pixels for encoding.If the value of the screen dimensions is higher than that of dimensions, for example, 2000 x 1500, the SDK uses the maximum value under dimensions with the aspect ratio of the screen dimension (4:3) for encoding, that is, 1440 x 1080.
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
        /// The bitrate of the shared region. On Windows and macOS, it represents the video encoding bitrate of the shared screen stream. The bitrate (Kbps) of the shared region. The default value is 0 (the SDK works out a bitrate according to the dimensions of the current screen).
        /// </summary>
        ///
        public int bitrate { set; get; }

        ///
        /// <summary>
        /// Whether to capture the mouse in screen sharing:true: (Default) Capture the mouse.false: Do not capture the mouse.
        /// </summary>
        ///
        public bool captureMouseCursor { set; get; }

        ///
        /// <summary>
        /// Whether to bring the window to the front when calling the StartScreenCaptureByWindowId method to share it:true:Bring the window to the front.false: (Default) Do not bring the window to the front.
        /// </summary>
        ///
        public bool windowFocus { set; get; }

        ///
        /// <summary>
        /// The ID list of the windows to be blocked. When calling StartScreenCaptureByDisplayId to start screen sharing, you can use this parameter to block a specified window. When calling UpdateScreenCaptureParameters to update screen sharing configurations, you can use this parameter to dynamically block a specified window.
        /// </summary>
        ///
        public view_t[] excludeWindowList { set; get; }

        ///
        /// <summary>
        /// The number of windows to be blocked.
        /// </summary>
        ///
        public int excludeWindowCount { set; get; }

        ///
        /// <summary>
        /// (For macOS only) The width (px) of the border. The default value is 5, and the value range is (0, 50].This parameter only takes effect when highLighted is set to true.
        /// </summary>
        ///
        public int highLightWidth { set; get; }

        ///
        /// <summary>
        /// (For macOS only) The color of the border in RGBA format. The default value is 0xFF8CBF26.On macOS, COLOR_CLASS refers to NSColor.
        /// </summary>
        ///
        public uint highLightColor { set; get; }

        ///
        /// <summary>
        /// (For macOS only)Whether to place a border around the shared window or screen:true: Place a border.false: (Default) Do not place a border.When you share a part of a window or screen, the SDK places a border around the entire window or screen if you set this parameter to true.
        /// </summary>
        ///
        public bool enableHighLight { set; get; }
    };

    ///
    /// <summary>
    /// Recording quality.
    /// </summary>
    ///
    public enum AUDIO_RECORDING_QUALITY_TYPE
    {
        ///
        /// <summary>
        /// 0: Low quality. The sample rate is 32 kHz, and the file size is around 1.2 MB after 10 minutes of recording.
        /// </summary>
        ///
        AUDIO_RECORDING_QUALITY_LOW = 0,

        ///
        /// <summary>
        /// 1: Medium quality. The sample rate is 32 kHz, and the file size is around 2 MB after 10 minutes of recording.
        /// </summary>
        ///
        AUDIO_RECORDING_QUALITY_MEDIUM = 1,

        ///
        /// <summary>
        /// 2: High quality. The sample rate is 32 kHz, and the file size is around 3.75 MB after 10 minutes of recording.
        /// </summary>
        ///
        AUDIO_RECORDING_QUALITY_HIGH = 2,

        ///
        /// <summary>
        /// 3: Ultra high quality. The sample rate is 32 kHz, and the file size is around 7.5 MB after 10 minutes of recording.
        /// </summary>
        ///
        AUDIO_RECORDING_QUALITY_ULTRA_HIGH = 3,
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

        ///
        /// <summary>
        /// The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.mp4.
        /// Ensure that the path for the recording file exists and is writable.
        /// </summary>
        ///
        public string filePath { set; get; }

        ///
        /// <summary>
        /// Whether to encode the audio data:
        /// true: Encode audio data in AAC.false: (Default) Do not encode audio data, but save the recorded audio data directly.
        /// </summary>
        ///
        public bool encode { set; get; }

        ///
        /// <summary>
        /// Recording sample rate (Hz).
        /// 16000(Default) 320004410048000If you set this parameter to 44100 or 48000, Agora recommends recording WAV files, or AAC files with quality to be AgoraAudioRecordingQualityMedium or AgoraAudioRecordingQualityHigh for better recording quality.
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
        /// Recording quality. See AUDIO_RECORDING_QUALITY_TYPE .Note: This parameter applies to AAC files only.
        /// </summary>
        ///
        public AUDIO_RECORDING_QUALITY_TYPE quality { set; get; }

        ///
        /// <summary>
        /// The audio channel of recording: The parameter supports the following values:1: (Default) Mono.2: Stereo.The actual recorded audio channel is related to the audio channel that you capture.If the captured audio is mono and recordingChannel is 2, the recorded audio is the dual-channel data that is copied from mono data, not stereo.If the captured audio is dual channel and recordingChannel is 1, the recorded audio is the mono data that is mixed by dual-channel data.The integration scheme also affects the final recorded audio channel. Therefore, to record in stereo, technical support for assistance.
        /// </summary>
        ///
        public int recordingChannel { set; get; }
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

    /* enum_areacode : uint */
    public enum AREA_CODE : uint
    {
        /* enum_areacode : uint_AREA_CODE_CN */
        AREA_CODE_CN = 0x00000001,

        /* enum_areacode : uint_AREA_CODE_NA */
        AREA_CODE_NA = 0x00000002,

        /* enum_areacode : uint_AREA_CODE_EU */
        AREA_CODE_EU = 0x00000004,

        /* enum_areacode : uint_AREA_CODE_AS */
        AREA_CODE_AS = 0x00000008,

        /* enum_areacode : uint_AREA_CODE_JP */
        AREA_CODE_JP = 0x00000010,

        /* enum_areacode : uint_AREA_CODE_IN */
        AREA_CODE_IN = 0x00000020,

        /* enum_areacode : uint_AREA_CODE_GLOB */
        AREA_CODE_GLOB = 0xFFFFFFFF
    };

    /* enum_areacodeex : uint */
    public enum AREA_CODE_EX : uint
    {
        /* enum_areacodeex : uint_AREA_CODE_OC */
        AREA_CODE_OC = 0x00000040,

        /* enum_areacodeex : uint_AREA_CODE_SA */
        AREA_CODE_SA = 0x00000080,

        /* enum_areacodeex : uint_AREA_CODE_AF */
        AREA_CODE_AF = 0x00000100,

        /* enum_areacodeex : uint_AREA_CODE_KR */
        AREA_CODE_KR = 0x00000200,

        /* enum_areacodeex : uint_AREA_CODE_HKMC */
        AREA_CODE_HKMC = 0x00000400,

        /* enum_areacodeex : uint_AREA_CODE_US */
        AREA_CODE_US = 0x00000800,

        /* enum_areacodeex : uint_AREA_CODE_OVS */
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
        /// 2: No server response.You can call LeaveChannel [1/2] This error can also occur if your project has not enabled co-host token authentication. You can to enable the service for cohosting across channels before starting a channel media relay.
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
        /// 0: The initial state. After you successfully stop the channel media relay by calling StopChannelMediaRelay , the OnChannelMediaRelayStateChanged callback returns this state.
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
    };

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

        public ChannelMediaRelayConfiguration(ChannelMediaInfo srcInfo, ChannelMediaInfo[] destInfos, int destCount)
        {
            this.srcInfo = srcInfo;
            this.destInfos = destInfos ?? new ChannelMediaInfo[0];
            this.destCount = destCount;
        }

        ///
        /// <summary>
        /// The information of the source channel ChannelMediaInfo . It contains the following members:channelName: The name of the source channel. The default value is NULL, which means the SDK applies the name of the current channel.uid: The unique ID to identify the relay stream in the source channel. The default value is 0, which means the SDK generates a random uid. You must set it as 0.token: The token for joining the source channel. It is generated with the channelName and uid you set in srcInfo.If you have not enabled the App Certificate, set this parameter as the default value NULL, which means the SDK applies the App ID.If you have enabled the App Certificate, you must use the token generated with the channelName and uid, and the uid must be set as 0.
        /// </summary>
        ///
        public ChannelMediaInfo srcInfo { set; get; }

        ///
        /// <summary>
        /// The information of the destination channel ChannelMediaInfo. It contains the following members:channelName: The name of the destination channel.uid: The unique ID to identify the relay stream in the destination channel. The value ranges from 0 to (232-1). To avoid UID conflicts, this UID must be different from any other UID in the destination channel. The default value is 0, which means the SDK generates a random UID. Do not set this parameter as the UID of the host in the destination channel, and ensure that this UID is different from any other UID in the channel.token: The token for joining the destination channel. It is generated with the channelName and uid you set in destInfos.If you have not enabled the App Certificate, set this parameter as the default value NULL, which means the SDK applies the App ID.If you have enabled the App Certificate, you must use the token generated with the channelName and uid.
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

    ///
    /// @ignore
    ///
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
        ///
        /// @ignore
        ///
        public string uid { set; get; }

        ///
        /// @ignore
        ///
        public VIDEO_STREAM_TYPE stream_type { set; get; }

        ///
        /// @ignore
        ///
        public REMOTE_VIDEO_DOWNSCALE_LEVEL current_downscale_level { set; get; }

        ///
        /// @ignore
        ///
        public int expected_bitrate_bps { set; get; }
    };

    ///
    /// @ignore
    ///
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

        ///
        /// @ignore
        ///
        public int lastmile_buffer_delay_time_ms { set; get; }

        ///
        /// @ignore
        ///
        public int bandwidth_estimation_bps { set; get; }

        ///
        /// @ignore
        ///
        public int total_downscale_level_count { set; get; }

        ///
        /// @ignore
        ///
        public PeerDownlinkInfo[] peer_downlink_info { set; get; }

        ///
        /// @ignore
        ///
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
        /// Enumerator boundary.
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
        /// Encryption key in string type with unlimited length. Agora recommends using a 32-byte key.If you do not set an encryption key or set it as NULL, you cannot use the built-in encryption, and the SDK returns -2.
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
        /// 1: Decryption errors. Ensure that the receiver and the sender use the same encryption mode and key.
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

    ///
    /// @ignore
    ///
    public enum UPLOAD_ERROR_REASON
    {
        ///
        /// @ignore
        ///
        UPLOAD_SUCCESS = 0,

        ///
        /// @ignore
        ///
        UPLOAD_NET_ERROR = 1,

        ///
        /// @ignore
        ///
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

        ///
        /// @ignore
        ///
        SCREEN_CAPTURE = 2,
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
        /// 1: Fails to subscribe to the remote stream. Possible reasons:The remote user:Calls MuteLocalAudioStream (true) or MuteLocalVideoStream (true) to stop sending local media stream.Calls DisableAudio or DisableVideo to disable the local audio or video module.Calls EnableLocalAudio (false) or EnableLocalVideo (false) to disable local audio or video capture.The role of the remote user is audience.The local user calls the following methods to stop receiving remote streams:Call MuteRemoteAudioStream (true) or MuteAllRemoteAudioStreams (true) to stop receiving the remote audio stream.Call MuteRemoteVideoStream (true) or MuteAllRemoteVideoStreams (true) to stop receiving the remote video stream.
        /// </summary>
        ///
        SUB_STATE_NO_SUBSCRIBED = 1,

        ///
        /// <summary>
        /// 2: Subscribing.
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
        /// 1: Fails to publish the local stream. Possible reasons:The local user calls MuteLocalAudioStream (true) or MuteLocalVideoStream (true) to stop sending local media streams.The local user calls DisableAudio or DisableVideo to disable the local audio or video module.The local user calls EnableLocalAudio (false) or EnableLocalVideo (false) to disable the local audio or video capture.The role of the local user is audience.
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
    /// The configuration of the audio and video call loop test.
    /// </summary>
    ///
    public class EchoTestConfiguration
    {
        ///
        /// <summary>
        /// The view used to render the local user's video. This parameter is only applicable to scenarios testing video devices, that is, when enableVideo is true.
        /// </summary>
        ///
        public view_t view { set; get; }

        ///
        /// <summary>
        /// Whether to enable the audio device for the loop test:true: (Default) Enable the audio device. To test the audio device, set this parameter as true.false: Disable the audio device.
        /// </summary>
        ///
        public bool enableAudio { set; get; }

        ///
        /// <summary>
        /// Whether to enable the video device for the loop test:true: (Default) Enable the video device. To test the video device, set this parameter as true.false: Disable the video device.
        /// </summary>
        ///
        public bool enableVideo { set; get; }

        ///
        /// <summary>
        /// The token used to secure the audio and video call loop test. If you do not enable App Certificate in Agora Console, you do not need to pass a value in this parameter; if you have enabled App Certificate in Agora Console, you must pass a token in this parameter; the uid used when you generate the token must be 0xFFFFFFFF, and the channel name used must be the channel name that identifies each audio and video call loop tested. For server-side token generation, see Authenticate Your Users with Tokens.
        /// </summary>
        ///
        public string token { set; get; }

        ///
        /// <summary>
        /// The channel name that identifies each audio and video call loop. To ensure proper loop test functionality, the channel name passed in to identify each loop test cannot be the same when users of the same project (App ID) perform audio and video call loop tests on different devices.
        /// </summary>
        ///
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
        /// User account. The maximum data length is MAX_USER_ACCOUNT_LENGTH_TYPE .
        /// </summary>
        ///
        public string userAccount;

        public UserInfo()
        {
            uid = 0;
            userAccount = "";
        }
    };

    [Flags]
    ///
    /// <summary>
    /// The audio filter of in-ear monitoring.
    /// </summary>
    ///
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
        /// 2: Add an audio filter to the in-ear monitor. If you implement functions such as voice beautifier and audio effect, users can hear the voice after adding these effects.
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

    ///
    /// @ignore
    ///
    public enum THREAD_PRIORITY_TYPE
    {
        ///
        /// @ignore
        ///
        LOWEST = 0,

        ///
        /// @ignore
        ///
        LOW = 1,

        ///
        /// @ignore
        ///
        NORMAL = 2,

        ///
        /// @ignore
        ///
        HIGH = 3,

        ///
        /// @ignore
        ///
        HIGHEST = 4,

        ///
        /// @ignore
        ///
        CRITICAL = 5,
    };

    ///
    /// <summary>
    /// The video configuration for the shared screen stream.
    /// </summary>
    ///
    public class ScreenVideoParameters
    {
        ///
        /// <summary>
        /// The video encoding dimension. The default value is 1280 × 720.
        /// </summary>
        ///
        public VideoDimensions dimensions { set; get; }

        ///
        /// <summary>
        /// The video encoding frame rate (fps). The default value is 15.
        /// </summary>
        ///
        public int frameRate { set; get; }

        ///
        /// <summary>
        /// The video encoding bitrate (Kbps).
        /// </summary>
        ///
        public int bitrate { set; get; }

        public VIDEO_CONTENT_HINT contentHint = VIDEO_CONTENT_HINT.CONTENT_HINT_MOTION;

        public ScreenVideoParameters()
        {
            dimensions = new VideoDimensions(1280, 720);
            frameRate = 15;
        }
    };

    ///
    /// <summary>
    /// The audio configuration for the shared screen stream.
    /// Only available where captureAudio is true.
    /// </summary>
    ///
    public class ScreenAudioParameters
    {
        ///
        /// <summary>
        /// Audio sample rate (Hz). The default value is 16000.
        /// </summary>
        ///
        public int sampleRate { set; get; }

        ///
        /// <summary>
        /// The number of audio channels. The default value is 2, which means stereo.
        /// </summary>
        ///
        public int channels { set; get; }

        ///
        /// <summary>
        /// The volume of the captured system audio. The value range is [0, 100]. The default value is 100.
        /// </summary>
        ///
        public int captureSignalVolume { set; get; }

        public ScreenAudioParameters()
        {
            sampleRate = 16000;
            channels = 2;
            captureSignalVolume = 100;
        }
    };

    ///
    /// <summary>
    /// Screen sharing configurations.
    /// </summary>
    ///
    public class ScreenCaptureParameters2
    {
        ///
        /// <summary>
        /// Determines whether to capture system audio during screen sharing:true: Capture system audio.false: (Default) Do not capture system audio.Due to system limitations, capturing system audio is only applicable to Android API level 29 and later (that is, Android 10 and later).
        /// </summary>
        ///
        public bool captureAudio { set; get; }

        ///
        /// <summary>
        /// The audio configuration for the shared screen stream. See ScreenAudioParameters .This parameter only takes effect when captureAudio is true.
        /// </summary>
        ///
        public ScreenAudioParameters audioParams { set; get; }

        ///
        /// <summary>
        /// Whether to capture the screen when screen sharing:true: (Default) Capture the screen.false: Do not capture the screen.Due to system limitations, the capture screen is only applicable to Android API level 21 and above, that is, Android 5 and above.
        /// </summary>
        ///
        public bool captureVideo { set; get; }

        ///
        /// <summary>
        /// The video configuration for the shared screen stream. See ScreenVideoParameters .This parameter only takes effect when captureVideo is true.
        /// </summary>
        ///
        public ScreenVideoParameters videoParams { set; get; }

        public ScreenCaptureParameters2()
        {
            captureAudio = false;
            audioParams = new ScreenAudioParameters();
            captureAudio = true;
            videoParams = new ScreenVideoParameters();
        }
    };

    ///
    /// @ignore
    ///
    public class SpatialAudioParams : OptionalJsonParse
    {
        ///
        /// @ignore
        ///
        public Optional<double> speaker_azimuth = new Optional<double>();

        ///
        /// @ignore
        ///
        public Optional<double> speaker_elevation = new Optional<double>();

        ///
        /// @ignore
        ///
        public Optional<double> speaker_distance = new Optional<double>();

        ///
        /// @ignore
        ///
        public Optional<int> speaker_orientation = new Optional<int>();

        ///
        /// @ignore
        ///
        public Optional<bool> enable_blur = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> enable_air_absorb = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<double> speaker_attenuation = new Optional<double>();

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