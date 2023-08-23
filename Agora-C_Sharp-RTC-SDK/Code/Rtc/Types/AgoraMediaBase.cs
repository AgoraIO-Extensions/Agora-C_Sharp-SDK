using System;

namespace Agora.Rtc
{
    using int64_t = Int64;
    using view_t = Int64;
    using uint64_t = UInt64;
    using uint8_t = Byte;
    using uint32_t = UInt32;
    using int16_t = Int16;

#region terra AgoraMediaBase.h

    public enum VIDEO_SOURCE_TYPE
    {
        VIDEO_SOURCE_CAMERA_PRIMARY = 0,

        VIDEO_SOURCE_CAMERA = VIDEO_SOURCE_CAMERA_PRIMARY,

        VIDEO_SOURCE_CAMERA_SECONDARY = 1,

        VIDEO_SOURCE_SCREEN_PRIMARY = 2,

        VIDEO_SOURCE_SCREEN = VIDEO_SOURCE_SCREEN_PRIMARY,

        VIDEO_SOURCE_SCREEN_SECONDARY = 3,

        VIDEO_SOURCE_CUSTOM = 4,

        VIDEO_SOURCE_MEDIA_PLAYER = 5,

        VIDEO_SOURCE_RTC_IMAGE_PNG = 6,

        VIDEO_SOURCE_RTC_IMAGE_JPEG = 7,

        VIDEO_SOURCE_RTC_IMAGE_GIF = 8,

        VIDEO_SOURCE_REMOTE = 9,

        VIDEO_SOURCE_TRANSCODED = 10,

        VIDEO_SOURCE_CAMERA_THIRD = 11,

        VIDEO_SOURCE_CAMERA_FOURTH = 12,

        VIDEO_SOURCE_SCREEN_THIRD = 13,

        VIDEO_SOURCE_SCREEN_FOURTH = 14,

        VIDEO_SOURCE_UNKNOWN = 100,
    }

    public enum AudioRoute
    {
        ROUTE_DEFAULT = -1,

        ROUTE_HEADSET = 0,

        ROUTE_EARPIECE = 1,

        ROUTE_HEADSETNOMIC = 2,

        ROUTE_SPEAKERPHONE = 3,

        ROUTE_LOUDSPEAKER = 4,

        ROUTE_HEADSETBLUETOOTH = 5,

        ROUTE_USB = 6,

        ROUTE_HDMI = 7,

        ROUTE_DISPLAYPORT = 8,

        ROUTE_AIRPLAY = 9,
    }

    public enum BYTES_PER_SAMPLE
    {
        TWO_BYTES_PER_SAMPLE = 2,
    }

    public class AudioParameters
    {
        public int sample_rate;

        public ulong channels;

        public ulong frames_per_buffer;
    }

    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        RAW_AUDIO_FRAME_OP_MODE_READ_WRITE = 2,
    }

    public enum MEDIA_SOURCE_TYPE
    {
        AUDIO_PLAYOUT_SOURCE = 0,

        AUDIO_RECORDING_SOURCE = 1,

        PRIMARY_CAMERA_SOURCE = 2,

        SECONDARY_CAMERA_SOURCE = 3,

        PRIMARY_SCREEN_SOURCE = 4,

        SECONDARY_SCREEN_SOURCE = 5,

        CUSTOM_VIDEO_SOURCE = 6,

        MEDIA_PLAYER_SOURCE = 7,

        RTC_IMAGE_PNG_SOURCE = 8,

        RTC_IMAGE_JPEG_SOURCE = 9,

        RTC_IMAGE_GIF_SOURCE = 10,

        REMOTE_VIDEO_SOURCE = 11,

        TRANSCODED_VIDEO_SOURCE = 12,

        UNKNOWN_MEDIA_SOURCE = 100,
    }

    public enum CONTENT_INSPECT_RESULT
    {
        CONTENT_INSPECT_NEUTRAL = 1,

        CONTENT_INSPECT_SEXY = 2,

        CONTENT_INSPECT_PORN = 3,
    }

    public enum CONTENT_INSPECT_TYPE
    {
        CONTENT_INSPECT_INVALID = 0,

        CONTENT_INSPECT_MODERATION = 1,

        CONTENT_INSPECT_SUPERVISION = 2,
    }

    public class ContentInspectModule
    {
        public CONTENT_INSPECT_TYPE type;

        public uint interval;
    }

    public class ContentInspectConfig
    {
        public string extraInfo;

        public ContentInspectModule[] modules;

        public int moduleCount;
    }

    public class PacketOptions
    {
        public uint32_t timestamp;

        public uint8_t audioLevelIndication;
    }

    public class AudioEncodedFrameInfo
    {
        public ulong sendTs;

        public uint8_t codec;
    }

    public class AudioPcmFrame
    {
        public long capture_timestamp;

        public ulong samples_per_channel_;

        public int sample_rate_hz_;

        public ulong num_channels_;

        public BYTES_PER_SAMPLE bytes_per_sample;

        public int16_t[] data_;
    }

    public enum AUDIO_DUAL_MONO_MODE
    {
        AUDIO_DUAL_MONO_STEREO = 0,

        AUDIO_DUAL_MONO_L = 1,

        AUDIO_DUAL_MONO_R = 2,

        AUDIO_DUAL_MONO_MIX = 3,
    }

    public enum VIDEO_PIXEL_FORMAT
    {
        VIDEO_PIXEL_DEFAULT = 0,

        VIDEO_PIXEL_I420 = 1,

        VIDEO_PIXEL_BGRA = 2,

        VIDEO_PIXEL_NV21 = 3,

        VIDEO_PIXEL_RGBA = 4,

        VIDEO_PIXEL_NV12 = 8,

        VIDEO_TEXTURE_2D = 10,

        VIDEO_TEXTURE_OES = 11,

        VIDEO_CVPIXEL_NV12 = 12,

        VIDEO_CVPIXEL_I420 = 13,

        VIDEO_CVPIXEL_BGRA = 14,

        VIDEO_PIXEL_I422 = 16,
    }

    public enum RENDER_MODE_TYPE
    {
        RENDER_MODE_HIDDEN = 1,

        RENDER_MODE_FIT = 2,

        RENDER_MODE_ADAPTIVE = 3,
    }

    public enum CAMERA_VIDEO_SOURCE_TYPE
    {
        CAMERA_SOURCE_FRONT = 0,

        CAMERA_SOURCE_BACK = 1,

        VIDEO_SOURCE_UNSPECIFIED = 2,
    }

    public class ExternalVideoFrame
    {
        public VIDEO_BUFFER_TYPE type;

        public VIDEO_PIXEL_FORMAT format;

        public byte[] buffer;

        public int stride;

        public int height;

        public int cropLeft;

        public int cropTop;

        public int cropRight;

        public int cropBottom;

        public int rotation;

        public long timestamp;

        public byte[] eglContext;

        public EGL_CONTEXT_TYPE eglType;

        public int textureId;

        public float[] matrix;

        public byte[] metadata_buffer;

        public int metadata_size;

        public byte[] alphaBuffer;
    }

    public enum EGL_CONTEXT_TYPE
    {
        EGL_CONTEXT10 = 0,

        EGL_CONTEXT14 = 1,
    }

    public enum VIDEO_BUFFER_TYPE
    {
        VIDEO_BUFFER_RAW_DATA = 1,

        VIDEO_BUFFER_ARRAY = 2,

        VIDEO_BUFFER_TEXTURE = 3,
    }

    public class VideoFrame
    {
        public VIDEO_PIXEL_FORMAT type;

        public int width;

        public int height;

        public int yStride;

        public int uStride;

        public int vStride;

        public uint8_t* yBuffer;

        public uint8_t* uBuffer;

        public uint8_t* vBuffer;

        public int rotation;

        public long renderTimeMs;

        public int avsync_type;

        public uint8_t* metadata_buffer;

        public int metadata_size;

        public IntPtr sharedContext;

        public int textureId;

        public float[] matrix;

        public uint8_t* alphaBuffer;

        public IntPtr pixelBuffer;
    }

    public enum MEDIA_PLAYER_SOURCE_TYPE
    {
        MEDIA_PLAYER_SOURCE_DEFAULT,

        MEDIA_PLAYER_SOURCE_FULL_FEATURED,

        MEDIA_PLAYER_SOURCE_SIMPLE,
    }

    public enum VIDEO_MODULE_POSITION
    {
        POSITION_POST_CAPTURER = 1 << 0,

        POSITION_PRE_RENDERER = 1 << 1,

        POSITION_PRE_ENCODER = 1 << 2,
    }

    public enum AUDIO_FRAME_TYPE
    {
        FRAME_TYPE_PCM16 = 0,
    }

    public class AudioFrame
    {
        public AUDIO_FRAME_TYPE type;

        public int samplesPerChannel;

        public BYTES_PER_SAMPLE bytesPerSample;

        public int channels;

        public int samplesPerSec;

        public IntPtr buffer;

        public long renderTimeMs;

        public int avsync_type;

        public long presentationMs;
    }

    public enum AUDIO_FRAME_POSITION
    {
        AUDIO_FRAME_POSITION_NONE = 0x0000,

        AUDIO_FRAME_POSITION_PLAYBACK = 0x0001,

        AUDIO_FRAME_POSITION_RECORD = 0x0002,

        AUDIO_FRAME_POSITION_MIXED = 0x0004,

        AUDIO_FRAME_POSITION_BEFORE_MIXING = 0x0008,

        AUDIO_FRAME_POSITION_EAR_MONITORING = 0x0010,
    }

    public class AudioParams
    {
        public int sample_rate;

        public int channels;

        public RAW_AUDIO_FRAME_OP_MODE_TYPE mode;

        public int samples_per_call;
    }

    public class AudioSpectrumData
    {
        public float audioSpectrumData;

        public int dataLength;
    }

    public class UserAudioSpectrumInfo
    {
        public uint uid;

        public AudioSpectrumData spectrumData;
    }

    public enum VIDEO_FRAME_PROCESS_MODE
    {
        PROCESS_MODE_READ_ONLY,

        PROCESS_MODE_READ_WRITE,
    }

    public enum EXTERNAL_VIDEO_SOURCE_TYPE
    {
        VIDEO_FRAME = 0,

        ENCODED_VIDEO_FRAME,
    }

    public enum MediaRecorderContainerFormat
    {
        FORMAT_MP4 = 1,
    }

    public enum MediaRecorderStreamType
    {
        STREAM_TYPE_AUDIO = 0x01,

        STREAM_TYPE_VIDEO = 0x02,

        STREAM_TYPE_BOTH = STREAM_TYPE_AUDIO | STREAM_TYPE_VIDEO,
    }

    public enum RecorderState
    {
        RECORDER_STATE_ERROR = -1,

        RECORDER_STATE_START = 2,

        RECORDER_STATE_STOP = 3,
    }

    public enum RecorderErrorCode
    {
        RECORDER_ERROR_NONE = 0,

        RECORDER_ERROR_WRITE_FAILED = 1,

        RECORDER_ERROR_NO_STREAM = 2,

        RECORDER_ERROR_OVER_MAX_DURATION = 3,

        RECORDER_ERROR_CONFIG_CHANGED = 4,
    }

    public class MediaRecorderConfiguration
    {
        public string storagePath;

        public MediaRecorderContainerFormat containerFormat;

        public MediaRecorderStreamType streamType;

        public int maxDurationMs;

        public int recorderInfoUpdateInterval;
    }

    public class RecorderInfo
    {
        public string fileName;

        public uint durationMs;

        public uint fileSize;
    }

#endregion terra AgoraMediaBase.h
}