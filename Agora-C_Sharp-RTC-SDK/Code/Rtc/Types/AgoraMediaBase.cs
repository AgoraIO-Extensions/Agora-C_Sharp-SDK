using System;

namespace Agora.Rtc
{
    using int64_t = Int64;
    using view_t = UInt64;
    using uint64_t = UInt64;

    #region AgoraMediaBase.h

    public enum AudioRoute
    {
        ROUTE_DEFAULT = -1,

        ROUTE_HEADSET = 0,

        ROUTE_EARPIECE = 1,

        ROUTE_HEADSETNOMIC = 2,

        ROUTE_SPEAKERPHONE = 3,

        ROUTE_LOUDSPEAKER = 4,

        ROUTE_HEADSETBLUETOOTH = 5,

        ROUTE_HDMI = 6,

        ROUTE_USB = 7,

        ROUTE_DISPLAYPORT = 8,

        ROUTE_AIRPLAY = 9
    };

    public enum BYTES_PER_SAMPLE
    {
        TWO_BYTES_PER_SAMPLE = 2,
    };

    public class AudioParameters
    {
        public AudioParameters()
        {
            sample_rate = 0;
            channels = 0;
            frames_per_buffer = 0;
        }
        public AudioParameters(int sample_rate, uint channels, uint frames_per_buffer)
        {
            this.sample_rate = sample_rate;
            this.channels = channels;
            this.frames_per_buffer = frames_per_buffer;
        }

        public int sample_rate { set; get; }

        public uint channels { set; get; }

        public uint frames_per_buffer { set; get; }
    };

    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        RAW_AUDIO_FRAME_OP_MODE_READ_WRITE = 2,
    };

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

        UNKNOWN_MEDIA_SOURCE = 100
    };

    public class PacketOptions
    {
        public uint timestamp { set; get; }

        public byte audioLevelIndication { set; get; }

        public PacketOptions()
        {
            timestamp = 0;
            audioLevelIndication = 127;
        }
    };

    public class AudioEncodedFrameInfo
    {
        public uint64_t sendTs;

        public Byte codec;

        public AudioEncodedFrameInfo()
        {
            sendTs = 0;
            codec = 0;
        }
    };

    public class AudioPcmFrame
    {
        public Int64 capture_timestamp;

        public UInt64 samples_per_channel_;

        public int sample_rate_hz_;

        public UInt64 num_channels_;

        public BYTES_PER_SAMPLE bytes_per_sample;

        public Int16[] data_;
    };

    public enum AUDIO_DUAL_MONO_MODE
    {
        AUDIO_DUAL_MONO_STEREO = 0,

        AUDIO_DUAL_MONO_L = 1,

        AUDIO_DUAL_MONO_R = 2,

        AUDIO_DUAL_MONO_MIX = 3
    };

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
    };

    public enum RENDER_MODE_TYPE
    {
        RENDER_MODE_HIDDEN = 1,

        RENDER_MODE_FIT = 2,

        [Obsolete]
        RENDER_MODE_ADAPTIVE = 3,
    };

    namespace Media.Base
    {
        enum VIDEO_SOURCE_TYPE
        {
            CAMERA_SOURCE_FRONT = 0,

            CAMERA_SOURCE_BACK = 1,

            VIDEO_SOURCE_UNSPECIFIED = 2,
        };
    };

    public enum EGL_CONTEXT_TYPE
    {
        EGL_CONTEXT10 = 0,

        EGL_CONTEXT14 = 1,
    };

    public enum VIDEO_BUFFER_TYPE
    {
        VIDEO_BUFFER_RAW_DATA = 1,

        VIDEO_BUFFER_ARRAY = 2,

        VIDEO_BUFFER_TEXTURE = 3,
    };

    public class ExternalVideoFrame
    {
        public ExternalVideoFrame()
        {
            this.type = VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA;
            this.format = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_DEFAULT;
            this.buffer = null;
            this.stride = 0;
            this.height = 0;
            this.cropLeft = 0;
            this.cropTop = 0;
            this.cropRight = 0;
            this.cropBottom = 0;
            this.rotation = 0;
            this.timestamp = 0;
            this.eglContext = null;
            this.eglType = EGL_CONTEXT_TYPE.EGL_CONTEXT10;
            this.textureId = 0;
            this.metadata_buffer = null;
            this.metadata_size = 0;
        }

        public ExternalVideoFrame(VIDEO_BUFFER_TYPE type, VIDEO_PIXEL_FORMAT format, byte[] buffer, int stride,
            int height, long timestamp, byte[] eglContext, EGL_CONTEXT_TYPE eglType, int textureId, byte[] metadata_buffer,
            int metadata_size, int cropLeft = 0, int cropTop = 0, int cropRight = 0, int cropBottom = 0,
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
            this.eglContext = eglContext;
            this.eglType = eglType;
            this.textureId = textureId;
            this.metadata_buffer = metadata_buffer;
            this.metadata_size = metadata_size;
        }

        public VIDEO_BUFFER_TYPE type { set; get; }

        public VIDEO_PIXEL_FORMAT format { set; get; }

        public byte[] buffer { set; get; }

        public int stride { set; get; }

        public int height { set; get; }

        public int cropLeft { set; get; }

        public int cropTop { set; get; }

        public int cropRight { set; get; }

        public int cropBottom { set; get; }

        public int rotation { set; get; }

        public long timestamp { set; get; }

        public byte[] eglContext { set; get; }

        public EGL_CONTEXT_TYPE eglType { set; get; }

        public int textureId { set; get; }

        public byte[] metadata_buffer { set; get; }

        public int metadata_size { set; get; }
    };

    public class VideoFrame
    {
        public VideoFrame()
        {
            type = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_DEFAULT;
            width = 0;
            height = 0;
            yStride = 0;
            uStride = 0;
            vStride = 0;
            yBuffer = new byte[0];
            uBuffer = new byte[0];
            vBuffer = new byte[0];
            yBufferPtr = IntPtr.Zero;
            uBufferPtr = IntPtr.Zero;
            vBufferPtr = IntPtr.Zero;
            rotation = 0;
            renderTimeMs = 0;
            avsync_type = 0;
            metadata_buffer = IntPtr.Zero;
            metadata_size = 0;
            sharedContext = IntPtr.Zero;
            textureId = 0;
            matrix = new float[16];
        }

        public VIDEO_PIXEL_FORMAT type;

        public int width;

        public int height;

        public int yStride;

        public int uStride;

        public int vStride;

        public byte[] yBuffer;

        public IntPtr yBufferPtr;

        public byte[] uBuffer;

        public IntPtr uBufferPtr;

        public byte[] vBuffer;

        public IntPtr vBufferPtr;

        public int rotation;

        public long renderTimeMs;

        public int avsync_type;

        public IntPtr metadata_buffer;

        public int metadata_size;

        public IntPtr sharedContext;

        public int textureId;

        public float[] matrix;

        public byte[] alphaBuffer;

        public IntPtr alphaBufferPtr;
    };

    public enum MEDIA_PLAYER_SOURCE_TYPE
    {
        MEDIA_PLAYER_SOURCE_DEFAULT = 0,

        MEDIA_PLAYER_SOURCE_FULL_FEATURED = 1,

        MEDIA_PLAYER_SOURCE_SIMPLE = 2,
    };

    [Flags]
    public enum VIDEO_MODULE_POSITION
    {
        POSITION_POST_CAPTURER = 1 << 0,

        POSITION_PRE_RENDERER = 1 << 1,

        POSITION_PRE_ENCODER = 1 << 2,
    };

    public enum AUDIO_FRAME_TYPE
    {
        FRAME_TYPE_PCM16 = 0,
    };

    public enum MAX_HANDLE_TIME_CNT
    {
        MAX_HANDLE_TIME_CNT = 10
    };

    public class AudioFrame
    {
        public AudioFrame()
        {
            type = AUDIO_FRAME_TYPE.FRAME_TYPE_PCM16;
            samplesPerChannel = 0;
            bytesPerSample = BYTES_PER_SAMPLE.TWO_BYTES_PER_SAMPLE;
            channels = 0;
            samplesPerSec = 0;
            RawBuffer = new byte[0];
            renderTimeMs = 0;
            avsync_type = 0;
        }

        public AudioFrame(AUDIO_FRAME_TYPE type, int samplesPerChannel, BYTES_PER_SAMPLE bytesPerSample, int channels, int samplesPerSec,
            byte[] buffer, long renderTimeMs, int avsync_type)
        {
            this.type = type;
            this.samplesPerChannel = samplesPerChannel;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.RawBuffer = buffer;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
        }

        public AUDIO_FRAME_TYPE type { set; get; }

        public int samplesPerChannel { set; get; }

        public BYTES_PER_SAMPLE bytesPerSample { set; get; }

        public int channels { set; get; }

        public int samplesPerSec { set; get; }

      
        public IntPtr buffer { set; get; }

        public byte[] RawBuffer { set; get; }

        public long renderTimeMs { set; get; }

        public int avsync_type { set; get; }
    };

    [Flags]
    public enum AUDIO_FRAME_POSITION
    {
        AUDIO_FRAME_POSITION_NONE = 0x0000,

        AUDIO_FRAME_POSITION_PLAYBACK = 0x0001,

        AUDIO_FRAME_POSITION_RECORD = 0x0002,

        AUDIO_FRAME_POSITION_MIXED = 0x0004,

        AUDIO_FRAME_POSITION_BEFORE_MIXING = 0x0008,

        AUDIO_FRAME_POSITION_EAR_MONITORING = 0x0010
    };

    public class AudioParams
    {
        public int sample_rate { set; get; }

        public int channels { set; get; }

        public RAW_AUDIO_FRAME_OP_MODE_TYPE mode { set; get; }

        public int samples_per_call { set; get; }

        public AudioParams()
        {
            sample_rate = 0;
            channels = 0;
            mode = RAW_AUDIO_FRAME_OP_MODE_TYPE.RAW_AUDIO_FRAME_OP_MODE_READ_ONLY;
            samples_per_call = 0;
        }

        public AudioParams(int samplerate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE type, int samplesPerCall)
        {
            sample_rate = samplerate;
            channels = channel;
            mode = type;
            samples_per_call = samplesPerCall;
        }
    };

    public class AudioSpectrumData
    {
        public float[] audioSpectrumData;

        public int dataLength;
    };

    public class UserAudioSpectrumInfo
    {
        public uint uid;

        public AudioSpectrumData spectrumData;
    };

    [Flags]
    public enum VIDEO_OBSERVER_POSITION
    {
        POSITION_POST_CAPTURER = 1 << 0,

        POSITION_PRE_RENDERER = 1 << 1,

        POSITION_PRE_ENCODER = 1 << 2,
    };

    public enum CONTENT_INSPECT_RESULT
    {
        CONTENT_INSPECT_NEUTRAL = 1,

        CONTENT_INSPECT_SEXY = 2,

        CONTENT_INSPECT_PORN = 3,

        MAX_CONTENT_INSPECT_MODULE_COUNT = 32
    };

    public enum CONTENT_INSPECT_VENDOR
    {
        CONTENT_INSPECT_VENDOR_AGORA = 1,

        CONTENT_INSPECT_VENDOR_TUPU = 2,

        ONTENT_INSPECT_VENDOR_HIVE = 3
    };

    public enum CONTENT_INSPECT_DEVICE_TYPE
    {
        CONTENT_INSPECT_DEVICE_INVALID = 0,

        CONTENT_INSPECT_DEVICE_AGORA = 1
    };

    public enum CONTENT_INSPECT_TYPE
    {
        CONTENT_INSPECT_INVALID = 0,

        CONTENT_INSPECT_MODERATION = 1,

        CONTENT_INSPECT_SUPERVISION = 2
    };

    public enum CONTENT_INSPECT_WORK_TYPE
    {
        CONTENT_INSPECT_WORK_DEVICE = 0,

        CONTENT_INSPECT_WORK_CLOUD = 1,

        CONTENT_INSPECT_WORK_DEVICE_CLOUD = 2
    };

    public class ContentInspectModule
    {
        public CONTENT_INSPECT_TYPE type;

        public uint interval;

        public ContentInspectModule()
        {
            type = CONTENT_INSPECT_TYPE.CONTENT_INSPECT_INVALID;
            interval = 0;
        }
    };

    public class ContentInspectConfig
    {
        public ContentInspectModule[] modules { set; get; }

        public int moduleCount { set; get; }

        public ContentInspectConfig()
        {
            modules = null;
            moduleCount = 0;
        }
    };

    public enum EXTERNAL_VIDEO_SOURCE_TYPE
    {
        VIDEO_FRAME = 0,

        ENCODED_VIDEO_FRAME = 1,
    };

    public enum MediaRecorderContainerFormat
    {
        FORMAT_MP4 = 1,
    };

    public enum MediaRecorderStreamType
    {
        STREAM_TYPE_AUDIO = 0x01,

        STREAM_TYPE_VIDEO = 0x02,

        STREAM_TYPE_BOTH = STREAM_TYPE_AUDIO | STREAM_TYPE_VIDEO,
    };

    public enum RecorderState
    {
        RECORDER_STATE_ERROR = -1,

        RECORDER_STATE_START = 2,

        RECORDER_STATE_STOP = 3,
    };

    public enum RecorderErrorCode
    {
        RECORDER_ERROR_NONE = 0,

        RECORDER_ERROR_WRITE_FAILED = 1,

        RECORDER_ERROR_NO_STREAM = 2,

        RECORDER_ERROR_OVER_MAX_DURATION = 3,

        RECORDER_ERROR_CONFIG_CHANGED = 4,
    };

    public class MediaRecorderConfiguration
    {
        public string storagePath { set; get; }

        public MediaRecorderContainerFormat containerFormat { set; get; }

        public MediaRecorderStreamType streamType { set; get; }

        public int maxDurationMs { set; get; }

        public int recorderInfoUpdateInterval { set; get; }

        public MediaRecorderConfiguration()
        {
            storagePath = "";
            containerFormat = MediaRecorderContainerFormat.FORMAT_MP4;
            streamType = MediaRecorderStreamType.STREAM_TYPE_BOTH;
            maxDurationMs = 120000;
            recorderInfoUpdateInterval = 0;
        }

        public MediaRecorderConfiguration(string path, MediaRecorderContainerFormat format, MediaRecorderStreamType type, int duration, int interval)
        {
            storagePath = path;
            containerFormat = format;
            streamType = type;
            maxDurationMs = duration;
            recorderInfoUpdateInterval = interval;
        }
    };

    public class RecorderInfo
    {
        public string fileName { set; get; }

        public uint durationMs { set; get; }

        public uint fileSize { set; get; }

        public RecorderInfo()
        {
            fileName = "";
            durationMs = 0;
            fileSize = 0;
        }

        public RecorderInfo(string name, uint dur, uint size)
        {
            fileName = name;
            durationMs = dur;
            fileSize = size;
        }
    };

    #endregion
}