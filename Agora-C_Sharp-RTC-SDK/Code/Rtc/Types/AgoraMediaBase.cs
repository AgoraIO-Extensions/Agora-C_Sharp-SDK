using System;

namespace Agora.Rtc
{
    using int64_t = Int64;
    using view_t = Int64;
    using uint64_t = UInt64;
    using uint8_t = Byte;
    using uint32_t = UInt32;
    using int16_t = Int16;

    /* class_videoframe */
    public class VideoFrame
    {
#region terra VideoFrame_Member_List

        /* class_videoframe_type */
        public VIDEO_PIXEL_FORMAT type;

        /* class_videoframe_width */
        public int width;

        /* class_videoframe_height */
        public int height;

        /* class_videoframe_yStride */
        public int yStride;

        /* class_videoframe_uStride */
        public int uStride;

        /* class_videoframe_vStride */
        public int vStride;

        public byte[] yBuffer;

        /* class_videoframe_yBufferPtr */
        public IntPtr yBufferPtr;

        public byte[] uBuffer;

        /* class_videoframe_uBufferPtr */
        public IntPtr uBufferPtr;

        public byte[] vBuffer;

        /* class_videoframe_vBufferPtr */
        public IntPtr vBufferPtr;

        /* class_videoframe_rotation */
        public int rotation;

        /* class_videoframe_renderTimeMs */
        public long renderTimeMs;

        /* class_videoframe_avsync_type */
        public int avsync_type;

        /* class_videoframe_metadata_buffer */
        public IntPtr metadata_buffer;

        /* class_videoframe_metadata_size */
        public int metadata_size;

        /* class_videoframe_sharedContext */
        public IntPtr sharedContext;

        /* class_videoframe_textureId */
        public int textureId;

        public float[] matrix;

        public byte[] alphaBuffer;

        /* class_videoframe_alphaBufferPtr */
        public IntPtr alphaBufferPtr;

#endregion terra VideoFrame_Member_List

#region terra VideoFrame_Constructor

        public VideoFrame()
        {
            this.type = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_DEFAULT;
            this.width = 0;
            this.height = 0;
            this.yStride = 0;
            this.uStride = 0;
            this.vStride = 0;
            this.yBuffer = new byte[0];
            this.yBufferPtr = IntPtr.Zero;
            this.uBuffer = new byte[0];
            this.uBufferPtr = IntPtr.Zero;
            this.vBuffer = new byte[0];
            this.vBufferPtr = IntPtr.Zero;
            this.rotation = 0;
            this.renderTimeMs = 0;
            this.avsync_type = 0;
            this.metadata_buffer = IntPtr.Zero;
            this.metadata_size = 0;
            this.sharedContext = IntPtr.Zero;
            this.textureId = 0;
            this.alphaBuffer = new byte[0];
            this.alphaBufferPtr = IntPtr.Zero;
            this.matrix = new float[16];
        }

#endregion terra VideoFrame_Constructor
    }

    /* class_audioframe */
    public class AudioFrame
    {
#region terra AudioFrame_Member_List

        /* class_audioframe_type */
        public AUDIO_FRAME_TYPE type;

        /* class_audioframe_samplesPerChannel */
        public int samplesPerChannel;

        /* class_audioframe_bytesPerSample */
        public BYTES_PER_SAMPLE bytesPerSample;

        /* class_audioframe_channels */
        public int channels;

        /* class_audioframe_samplesPerSec */
        public int samplesPerSec;

        /* class_audioframe_buffer */
        public IntPtr buffer;

        /* class_audioframe_renderTimeMs */
        public long renderTimeMs;

        /* class_audioframe_avsync_type */
        public int avsync_type;

        /* class_audioframe_presentationMs */
        public long presentationMs;
#endregion terra AudioFrame_Member_List

        public byte[] RawBuffer;

#region terra AudioFrame_Constructor

        public AudioFrame()
        {
            this.type = AUDIO_FRAME_TYPE.FRAME_TYPE_PCM16;
            this.samplesPerChannel = 0;
            this.bytesPerSample = BYTES_PER_SAMPLE.TWO_BYTES_PER_SAMPLE;
            this.channels = 0;
            this.samplesPerSec = 0;
            this.buffer = IntPtr.Zero;
            this.renderTimeMs = 0;
            this.avsync_type = 0;
            this.presentationMs = 0;
            this.RawBuffer = new byte[0];
        }

        public AudioFrame(AUDIO_FRAME_TYPE type, int samplesPerChannel, BYTES_PER_SAMPLE bytesPerSample, int channels, int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type, long presentationMs)
        {
            this.type = type;
            this.samplesPerChannel = samplesPerChannel;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.buffer = buffer;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
            this.presentationMs = presentationMs;
        }

#endregion terra AudioFrame_Constructor
    }

#region terra AgoraMediaBase.h

    /* enum_videosourcetype */
    public enum VIDEO_SOURCE_TYPE
    {
        /* enum_videosourcetype_VIDEO_SOURCE_CAMERA_PRIMARY */
        VIDEO_SOURCE_CAMERA_PRIMARY = 0,

        /* enum_videosourcetype_VIDEO_SOURCE_CAMERA */
        VIDEO_SOURCE_CAMERA = VIDEO_SOURCE_CAMERA_PRIMARY,

        /* enum_videosourcetype_VIDEO_SOURCE_CAMERA_SECONDARY */
        VIDEO_SOURCE_CAMERA_SECONDARY = 1,

        /* enum_videosourcetype_VIDEO_SOURCE_SCREEN_PRIMARY */
        VIDEO_SOURCE_SCREEN_PRIMARY = 2,

        /* enum_videosourcetype_VIDEO_SOURCE_SCREEN */
        VIDEO_SOURCE_SCREEN = VIDEO_SOURCE_SCREEN_PRIMARY,

        /* enum_videosourcetype_VIDEO_SOURCE_SCREEN_SECONDARY */
        VIDEO_SOURCE_SCREEN_SECONDARY = 3,

        /* enum_videosourcetype_VIDEO_SOURCE_CUSTOM */
        VIDEO_SOURCE_CUSTOM = 4,

        /* enum_videosourcetype_VIDEO_SOURCE_MEDIA_PLAYER */
        VIDEO_SOURCE_MEDIA_PLAYER = 5,

        /* enum_videosourcetype_VIDEO_SOURCE_RTC_IMAGE_PNG */
        VIDEO_SOURCE_RTC_IMAGE_PNG = 6,

        /* enum_videosourcetype_VIDEO_SOURCE_RTC_IMAGE_JPEG */
        VIDEO_SOURCE_RTC_IMAGE_JPEG = 7,

        /* enum_videosourcetype_VIDEO_SOURCE_RTC_IMAGE_GIF */
        VIDEO_SOURCE_RTC_IMAGE_GIF = 8,

        /* enum_videosourcetype_VIDEO_SOURCE_REMOTE */
        VIDEO_SOURCE_REMOTE = 9,

        /* enum_videosourcetype_VIDEO_SOURCE_TRANSCODED */
        VIDEO_SOURCE_TRANSCODED = 10,

        /* enum_videosourcetype_VIDEO_SOURCE_CAMERA_THIRD */
        VIDEO_SOURCE_CAMERA_THIRD = 11,

        /* enum_videosourcetype_VIDEO_SOURCE_CAMERA_FOURTH */
        VIDEO_SOURCE_CAMERA_FOURTH = 12,

        /* enum_videosourcetype_VIDEO_SOURCE_SCREEN_THIRD */
        VIDEO_SOURCE_SCREEN_THIRD = 13,

        /* enum_videosourcetype_VIDEO_SOURCE_SCREEN_FOURTH */
        VIDEO_SOURCE_SCREEN_FOURTH = 14,

        /* enum_videosourcetype_VIDEO_SOURCE_UNKNOWN */
        VIDEO_SOURCE_UNKNOWN = 100,
    }

    /* enum_audioroute */
    public enum AudioRoute
    {
        /* enum_audioroute_ROUTE_DEFAULT */
        ROUTE_DEFAULT = -1,

        /* enum_audioroute_ROUTE_HEADSET */
        ROUTE_HEADSET = 0,

        /* enum_audioroute_ROUTE_EARPIECE */
        ROUTE_EARPIECE = 1,

        /* enum_audioroute_ROUTE_HEADSETNOMIC */
        ROUTE_HEADSETNOMIC = 2,

        /* enum_audioroute_ROUTE_SPEAKERPHONE */
        ROUTE_SPEAKERPHONE = 3,

        /* enum_audioroute_ROUTE_LOUDSPEAKER */
        ROUTE_LOUDSPEAKER = 4,

        /* enum_audioroute_ROUTE_HEADSETBLUETOOTH */
        ROUTE_HEADSETBLUETOOTH = 5,

        /* enum_audioroute_ROUTE_USB */
        ROUTE_USB = 6,

        /* enum_audioroute_ROUTE_HDMI */
        ROUTE_HDMI = 7,

        /* enum_audioroute_ROUTE_DISPLAYPORT */
        ROUTE_DISPLAYPORT = 8,

        /* enum_audioroute_ROUTE_AIRPLAY */
        ROUTE_AIRPLAY = 9,
    }

    /* enum_bytespersample */
    public enum BYTES_PER_SAMPLE
    {
        /* enum_bytespersample_TWO_BYTES_PER_SAMPLE */
        TWO_BYTES_PER_SAMPLE = 2,
    }

    /* class_audioparameters */
    public class AudioParameters
    {
        /* class_audioparameters_sample_rate */
        public int sample_rate;

        /* class_audioparameters_channels */
        public ulong channels;

        /* class_audioparameters_frames_per_buffer */
        public ulong frames_per_buffer;

        public AudioParameters()
        {
            this.sample_rate = 0;
            this.channels = 0;
            this.frames_per_buffer = 0;
        }

        public AudioParameters(int sample_rate, ulong channels, ulong frames_per_buffer)
        {
            this.sample_rate = sample_rate;
            this.channels = channels;
            this.frames_per_buffer = frames_per_buffer;
        }
    }

    /* enum_rawaudioframeopmodetype */
    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        /* enum_rawaudioframeopmodetype_RAW_AUDIO_FRAME_OP_MODE_READ_ONLY */
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        /* enum_rawaudioframeopmodetype_RAW_AUDIO_FRAME_OP_MODE_READ_WRITE */
        RAW_AUDIO_FRAME_OP_MODE_READ_WRITE = 2,
    }

    /* enum_mediasourcetype */
    public enum MEDIA_SOURCE_TYPE
    {
        /* enum_mediasourcetype_AUDIO_PLAYOUT_SOURCE */
        AUDIO_PLAYOUT_SOURCE = 0,

        /* enum_mediasourcetype_AUDIO_RECORDING_SOURCE */
        AUDIO_RECORDING_SOURCE = 1,

        /* enum_mediasourcetype_PRIMARY_CAMERA_SOURCE */
        PRIMARY_CAMERA_SOURCE = 2,

        /* enum_mediasourcetype_SECONDARY_CAMERA_SOURCE */
        SECONDARY_CAMERA_SOURCE = 3,

        /* enum_mediasourcetype_PRIMARY_SCREEN_SOURCE */
        PRIMARY_SCREEN_SOURCE = 4,

        /* enum_mediasourcetype_SECONDARY_SCREEN_SOURCE */
        SECONDARY_SCREEN_SOURCE = 5,

        /* enum_mediasourcetype_CUSTOM_VIDEO_SOURCE */
        CUSTOM_VIDEO_SOURCE = 6,

        /* enum_mediasourcetype_MEDIA_PLAYER_SOURCE */
        MEDIA_PLAYER_SOURCE = 7,

        /* enum_mediasourcetype_RTC_IMAGE_PNG_SOURCE */
        RTC_IMAGE_PNG_SOURCE = 8,

        /* enum_mediasourcetype_RTC_IMAGE_JPEG_SOURCE */
        RTC_IMAGE_JPEG_SOURCE = 9,

        /* enum_mediasourcetype_RTC_IMAGE_GIF_SOURCE */
        RTC_IMAGE_GIF_SOURCE = 10,

        /* enum_mediasourcetype_REMOTE_VIDEO_SOURCE */
        REMOTE_VIDEO_SOURCE = 11,

        /* enum_mediasourcetype_TRANSCODED_VIDEO_SOURCE */
        TRANSCODED_VIDEO_SOURCE = 12,

        /* enum_mediasourcetype_UNKNOWN_MEDIA_SOURCE */
        UNKNOWN_MEDIA_SOURCE = 100,
    }

    /* enum_contentinspectresult */
    public enum CONTENT_INSPECT_RESULT
    {
        /* enum_contentinspectresult_CONTENT_INSPECT_NEUTRAL */
        CONTENT_INSPECT_NEUTRAL = 1,

        /* enum_contentinspectresult_CONTENT_INSPECT_SEXY */
        CONTENT_INSPECT_SEXY = 2,

        /* enum_contentinspectresult_CONTENT_INSPECT_PORN */
        CONTENT_INSPECT_PORN = 3,
    }

    /* enum_contentinspecttype */
    public enum CONTENT_INSPECT_TYPE
    {
        /* enum_contentinspecttype_CONTENT_INSPECT_INVALID */
        CONTENT_INSPECT_INVALID = 0,

        /* enum_contentinspecttype_CONTENT_INSPECT_MODERATION */
        CONTENT_INSPECT_MODERATION = 1,

        /* enum_contentinspecttype_CONTENT_INSPECT_SUPERVISION */
        CONTENT_INSPECT_SUPERVISION = 2,
    }

    /* class_contentinspectmodule */
    public class ContentInspectModule
    {
        /* class_contentinspectmodule_type */
        public CONTENT_INSPECT_TYPE type;

        /* class_contentinspectmodule_interval */
        public uint interval;

        public ContentInspectModule()
        {
        }

        public ContentInspectModule(CONTENT_INSPECT_TYPE type, uint interval)
        {
            this.type = type;
            this.interval = interval;
        }
    }

    /* class_contentinspectconfig */
    public class ContentInspectConfig
    {
        /* class_contentinspectconfig_extraInfo */
        public string extraInfo;

        public ContentInspectModule[] modules;

        /* class_contentinspectconfig_moduleCount */
        public int moduleCount;

        public ContentInspectConfig()
        {
            this.extraInfo = "";
            this.moduleCount = 0;
        }

        public ContentInspectConfig(string extraInfo, ContentInspectModule[] modules, int moduleCount)
        {
            this.extraInfo = extraInfo;
            this.modules = modules;
            this.moduleCount = moduleCount;
        }
    }

    /* class_packetoptions */
    public class PacketOptions
    {
        /* class_packetoptions_timestamp */
        public uint timestamp;

        /* class_packetoptions_audioLevelIndication */
        public uint8_t audioLevelIndication;

        public PacketOptions()
        {
            this.timestamp = 0;
            this.audioLevelIndication = 127;
        }

        public PacketOptions(uint timestamp, uint8_t audioLevelIndication)
        {
            this.timestamp = timestamp;
            this.audioLevelIndication = audioLevelIndication;
        }
    }

    /* class_audioencodedframeinfo */
    public class AudioEncodedFrameInfo
    {
        /* class_audioencodedframeinfo_sendTs */
        public ulong sendTs;

        /* class_audioencodedframeinfo_codec */
        public uint8_t codec;

        public AudioEncodedFrameInfo()
        {
            this.sendTs = 0;
            this.codec = 0;
        }

        public AudioEncodedFrameInfo(ulong sendTs, uint8_t codec)
        {
            this.sendTs = sendTs;
            this.codec = codec;
        }
    }

    /* class_audiopcmframe */
    public class AudioPcmFrame
    {
        /* class_audiopcmframe_capture_timestamp */
        public long capture_timestamp;

        /* class_audiopcmframe_samples_per_channel_ */
        public ulong samples_per_channel_;

        /* class_audiopcmframe_sample_rate_hz_ */
        public int sample_rate_hz_;

        /* class_audiopcmframe_num_channels_ */
        public ulong num_channels_;

        /* class_audiopcmframe_bytes_per_sample */
        public BYTES_PER_SAMPLE bytes_per_sample;

        public int16_t[] data_;

        public AudioPcmFrame()
        {
            this.capture_timestamp = 0;
            this.samples_per_channel_ = 0;
            this.sample_rate_hz_ = 0;
            this.num_channels_ = 0;
            this.bytes_per_sample = BYTES_PER_SAMPLE.TWO_BYTES_PER_SAMPLE;
        }

        public AudioPcmFrame(AudioPcmFrame src)
        {
            this.capture_timestamp = src.capture_timestamp;
            this.samples_per_channel_ = src.samples_per_channel_;
            this.sample_rate_hz_ = src.sample_rate_hz_;
            this.num_channels_ = src.num_channels_;
            this.bytes_per_sample = src.bytes_per_sample;
        }

        public AudioPcmFrame(long capture_timestamp, ulong samples_per_channel_, int sample_rate_hz_, ulong num_channels_, BYTES_PER_SAMPLE bytes_per_sample, int16_t[] data_)
        {
            this.capture_timestamp = capture_timestamp;
            this.samples_per_channel_ = samples_per_channel_;
            this.sample_rate_hz_ = sample_rate_hz_;
            this.num_channels_ = num_channels_;
            this.bytes_per_sample = bytes_per_sample;
            this.data_ = data_;
        }
    }

    /* enum_audiodualmonomode */
    public enum AUDIO_DUAL_MONO_MODE
    {
        /* enum_audiodualmonomode_AUDIO_DUAL_MONO_STEREO */
        AUDIO_DUAL_MONO_STEREO = 0,

        /* enum_audiodualmonomode_AUDIO_DUAL_MONO_L */
        AUDIO_DUAL_MONO_L = 1,

        /* enum_audiodualmonomode_AUDIO_DUAL_MONO_R */
        AUDIO_DUAL_MONO_R = 2,

        /* enum_audiodualmonomode_AUDIO_DUAL_MONO_MIX */
        AUDIO_DUAL_MONO_MIX = 3,
    }

    /* enum_videopixelformat */
    public enum VIDEO_PIXEL_FORMAT
    {
        /* enum_videopixelformat_VIDEO_PIXEL_DEFAULT */
        VIDEO_PIXEL_DEFAULT = 0,

        /* enum_videopixelformat_VIDEO_PIXEL_I420 */
        VIDEO_PIXEL_I420 = 1,

        /* enum_videopixelformat_VIDEO_PIXEL_BGRA */
        VIDEO_PIXEL_BGRA = 2,

        /* enum_videopixelformat_VIDEO_PIXEL_NV21 */
        VIDEO_PIXEL_NV21 = 3,

        /* enum_videopixelformat_VIDEO_PIXEL_RGBA */
        VIDEO_PIXEL_RGBA = 4,

        /* enum_videopixelformat_VIDEO_PIXEL_NV12 */
        VIDEO_PIXEL_NV12 = 8,

        /* enum_videopixelformat_VIDEO_TEXTURE_2D */
        VIDEO_TEXTURE_2D = 10,

        /* enum_videopixelformat_VIDEO_TEXTURE_OES */
        VIDEO_TEXTURE_OES = 11,

        /* enum_videopixelformat_VIDEO_CVPIXEL_NV12 */
        VIDEO_CVPIXEL_NV12 = 12,

        /* enum_videopixelformat_VIDEO_CVPIXEL_I420 */
        VIDEO_CVPIXEL_I420 = 13,

        /* enum_videopixelformat_VIDEO_CVPIXEL_BGRA */
        VIDEO_CVPIXEL_BGRA = 14,

        /* enum_videopixelformat_VIDEO_PIXEL_I422 */
        VIDEO_PIXEL_I422 = 16,
    }

    /* enum_rendermodetype */
    public enum RENDER_MODE_TYPE
    {
        /* enum_rendermodetype_RENDER_MODE_HIDDEN */
        RENDER_MODE_HIDDEN = 1,

        /* enum_rendermodetype_RENDER_MODE_FIT */
        RENDER_MODE_FIT = 2,

        /* enum_rendermodetype_RENDER_MODE_ADAPTIVE */
        RENDER_MODE_ADAPTIVE = 3,
    }

    /* enum_cameravideosourcetype */
    public enum CAMERA_VIDEO_SOURCE_TYPE
    {
        /* enum_cameravideosourcetype_CAMERA_SOURCE_FRONT */
        CAMERA_SOURCE_FRONT = 0,

        /* enum_cameravideosourcetype_CAMERA_SOURCE_BACK */
        CAMERA_SOURCE_BACK = 1,

        /* enum_cameravideosourcetype_VIDEO_SOURCE_UNSPECIFIED */
        VIDEO_SOURCE_UNSPECIFIED = 2,
    }

    /* class_externalvideoframe */
    public class ExternalVideoFrame
    {
        /* class_externalvideoframe_type */
        public VIDEO_BUFFER_TYPE type;

        /* class_externalvideoframe_format */
        public VIDEO_PIXEL_FORMAT format;

        public byte[] buffer;

        /* class_externalvideoframe_stride */
        public int stride;

        /* class_externalvideoframe_height */
        public int height;

        /* class_externalvideoframe_cropLeft */
        public int cropLeft;

        /* class_externalvideoframe_cropTop */
        public int cropTop;

        /* class_externalvideoframe_cropRight */
        public int cropRight;

        /* class_externalvideoframe_cropBottom */
        public int cropBottom;

        /* class_externalvideoframe_rotation */
        public int rotation;

        /* class_externalvideoframe_timestamp */
        public long timestamp;

        /* class_externalvideoframe_eglContext */
        public IntPtr eglContext;

        /* class_externalvideoframe_eglType */
        public EGL_CONTEXT_TYPE eglType;

        /* class_externalvideoframe_textureId */
        public int textureId;

        public float[] matrix;

        public byte[] metadata_buffer;

        /* class_externalvideoframe_metadata_size */
        public int metadata_size;

        public byte[] alphaBuffer;

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
            this.eglContext = IntPtr.Zero;
            this.eglType = EGL_CONTEXT_TYPE.EGL_CONTEXT10;
            this.textureId = 0;
            this.metadata_buffer = null;
            this.metadata_size = 0;
            this.alphaBuffer = null;
        }

        public ExternalVideoFrame(VIDEO_BUFFER_TYPE type, VIDEO_PIXEL_FORMAT format, byte[] buffer, int stride, int height, int cropLeft, int cropTop, int cropRight, int cropBottom, int rotation, long timestamp, IntPtr eglContext, EGL_CONTEXT_TYPE eglType, int textureId, float[] matrix, byte[] metadata_buffer, int metadata_size, byte[] alphaBuffer)
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
            this.matrix = matrix;
            this.metadata_buffer = metadata_buffer;
            this.metadata_size = metadata_size;
            this.alphaBuffer = alphaBuffer;
        }
    }

    /* enum_eglcontexttype */
    public enum EGL_CONTEXT_TYPE
    {
        /* enum_eglcontexttype_EGL_CONTEXT10 */
        EGL_CONTEXT10 = 0,

        /* enum_eglcontexttype_EGL_CONTEXT14 */
        EGL_CONTEXT14 = 1,
    }

    /* enum_videobuffertype */
    public enum VIDEO_BUFFER_TYPE
    {
        /* enum_videobuffertype_VIDEO_BUFFER_RAW_DATA */
        VIDEO_BUFFER_RAW_DATA = 1,

        /* enum_videobuffertype_VIDEO_BUFFER_ARRAY */
        VIDEO_BUFFER_ARRAY = 2,

        /* enum_videobuffertype_VIDEO_BUFFER_TEXTURE */
        VIDEO_BUFFER_TEXTURE = 3,
    }

    /* enum_mediaplayersourcetype */
    public enum MEDIA_PLAYER_SOURCE_TYPE
    {
        /* enum_mediaplayersourcetype_MEDIA_PLAYER_SOURCE_DEFAULT */
        MEDIA_PLAYER_SOURCE_DEFAULT,

        /* enum_mediaplayersourcetype_MEDIA_PLAYER_SOURCE_FULL_FEATURED */
        MEDIA_PLAYER_SOURCE_FULL_FEATURED,

        /* enum_mediaplayersourcetype_MEDIA_PLAYER_SOURCE_SIMPLE */
        MEDIA_PLAYER_SOURCE_SIMPLE,
    }

    [Flags]
    /* enum_videomoduleposition */
    public enum VIDEO_MODULE_POSITION
    {
        /* enum_videomoduleposition_POSITION_POST_CAPTURER */
        POSITION_POST_CAPTURER = 1 << 0,

        /* enum_videomoduleposition_POSITION_PRE_RENDERER */
        POSITION_PRE_RENDERER = 1 << 1,

        /* enum_videomoduleposition_POSITION_PRE_ENCODER */
        POSITION_PRE_ENCODER = 1 << 2,
    }

    /* enum_audioframetype */
    public enum AUDIO_FRAME_TYPE
    {
        /* enum_audioframetype_FRAME_TYPE_PCM16 */
        FRAME_TYPE_PCM16 = 0,
    }

    [Flags]
    /* enum_audioframeposition */
    public enum AUDIO_FRAME_POSITION
    {
        /* enum_audioframeposition_AUDIO_FRAME_POSITION_NONE */
        AUDIO_FRAME_POSITION_NONE = 0x0000,

        /* enum_audioframeposition_AUDIO_FRAME_POSITION_PLAYBACK */
        AUDIO_FRAME_POSITION_PLAYBACK = 0x0001,

        /* enum_audioframeposition_AUDIO_FRAME_POSITION_RECORD */
        AUDIO_FRAME_POSITION_RECORD = 0x0002,

        /* enum_audioframeposition_AUDIO_FRAME_POSITION_MIXED */
        AUDIO_FRAME_POSITION_MIXED = 0x0004,

        /* enum_audioframeposition_AUDIO_FRAME_POSITION_BEFORE_MIXING */
        AUDIO_FRAME_POSITION_BEFORE_MIXING = 0x0008,

        /* enum_audioframeposition_AUDIO_FRAME_POSITION_EAR_MONITORING */
        AUDIO_FRAME_POSITION_EAR_MONITORING = 0x0010,
    }

    /* class_audioparams */
    public class AudioParams
    {
        /* class_audioparams_sample_rate */
        public int sample_rate;

        /* class_audioparams_channels */
        public int channels;

        /* class_audioparams_mode */
        public RAW_AUDIO_FRAME_OP_MODE_TYPE mode;

        /* class_audioparams_samples_per_call */
        public int samples_per_call;

        public AudioParams()
        {
            this.sample_rate = 0;
            this.channels = 0;
            this.mode = RAW_AUDIO_FRAME_OP_MODE_TYPE.RAW_AUDIO_FRAME_OP_MODE_READ_ONLY;
            this.samples_per_call = 0;
        }

        public AudioParams(int samplerate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE type, int samplesPerCall)
        {
            this.sample_rate = samplerate;
            this.channels = channel;
            this.mode = type;
            this.samples_per_call = samplesPerCall;
        }
    }

    /* class_audiospectrumdata */
    public class AudioSpectrumData
    {
        public float[] audioSpectrumData;

        /* class_audiospectrumdata_dataLength */
        public int dataLength;

        public AudioSpectrumData()
        {
            this.audioSpectrumData = null;
            this.dataLength = 0;
        }

        public AudioSpectrumData(float[] data, int length)
        {
            this.audioSpectrumData = data;
            this.dataLength = length;
        }
    }

    /* class_useraudiospectruminfo */
    public class UserAudioSpectrumInfo
    {
        /* class_useraudiospectruminfo_uid */
        public uint uid;

        /* class_useraudiospectruminfo_spectrumData */
        public AudioSpectrumData spectrumData;
    }

    /* enum_videoframeprocessmode */
    public enum VIDEO_FRAME_PROCESS_MODE
    {
        /* enum_videoframeprocessmode_PROCESS_MODE_READ_ONLY */
        PROCESS_MODE_READ_ONLY,

        /* enum_videoframeprocessmode_PROCESS_MODE_READ_WRITE */
        PROCESS_MODE_READ_WRITE,
    }

    /* enum_externalvideosourcetype */
    public enum EXTERNAL_VIDEO_SOURCE_TYPE
    {
        /* enum_externalvideosourcetype_VIDEO_FRAME */
        VIDEO_FRAME = 0,

        /* enum_externalvideosourcetype_ENCODED_VIDEO_FRAME */
        ENCODED_VIDEO_FRAME,
    }

    /* enum_mediarecordercontainerformat */
    public enum MediaRecorderContainerFormat
    {
        /* enum_mediarecordercontainerformat_FORMAT_MP4 */
        FORMAT_MP4 = 1,
    }

    /* enum_mediarecorderstreamtype */
    public enum MediaRecorderStreamType
    {
        /* enum_mediarecorderstreamtype_STREAM_TYPE_AUDIO */
        STREAM_TYPE_AUDIO = 0x01,

        /* enum_mediarecorderstreamtype_STREAM_TYPE_VIDEO */
        STREAM_TYPE_VIDEO = 0x02,

        /* enum_mediarecorderstreamtype_STREAM_TYPE_BOTH */
        STREAM_TYPE_BOTH = STREAM_TYPE_AUDIO | STREAM_TYPE_VIDEO,
    }

    /* enum_recorderstate */
    public enum RecorderState
    {
        /* enum_recorderstate_RECORDER_STATE_ERROR */
        RECORDER_STATE_ERROR = -1,

        /* enum_recorderstate_RECORDER_STATE_START */
        RECORDER_STATE_START = 2,

        /* enum_recorderstate_RECORDER_STATE_STOP */
        RECORDER_STATE_STOP = 3,
    }

    /* enum_recordererrorcode */
    public enum RecorderErrorCode
    {
        /* enum_recordererrorcode_RECORDER_ERROR_NONE */
        RECORDER_ERROR_NONE = 0,

        /* enum_recordererrorcode_RECORDER_ERROR_WRITE_FAILED */
        RECORDER_ERROR_WRITE_FAILED = 1,

        /* enum_recordererrorcode_RECORDER_ERROR_NO_STREAM */
        RECORDER_ERROR_NO_STREAM = 2,

        /* enum_recordererrorcode_RECORDER_ERROR_OVER_MAX_DURATION */
        RECORDER_ERROR_OVER_MAX_DURATION = 3,

        /* enum_recordererrorcode_RECORDER_ERROR_CONFIG_CHANGED */
        RECORDER_ERROR_CONFIG_CHANGED = 4,
    }

    /* class_mediarecorderconfiguration */
    public class MediaRecorderConfiguration
    {
        /* class_mediarecorderconfiguration_storagePath */
        public string storagePath;

        /* class_mediarecorderconfiguration_containerFormat */
        public MediaRecorderContainerFormat containerFormat;

        /* class_mediarecorderconfiguration_streamType */
        public MediaRecorderStreamType streamType;

        /* class_mediarecorderconfiguration_maxDurationMs */
        public int maxDurationMs;

        /* class_mediarecorderconfiguration_recorderInfoUpdateInterval */
        public int recorderInfoUpdateInterval;

        public MediaRecorderConfiguration()
        {
            this.storagePath = "";
            this.containerFormat = MediaRecorderContainerFormat.FORMAT_MP4;
            this.streamType = MediaRecorderStreamType.STREAM_TYPE_BOTH;
            this.maxDurationMs = 120000;
            this.recorderInfoUpdateInterval = 0;
        }

        public MediaRecorderConfiguration(string path, MediaRecorderContainerFormat format, MediaRecorderStreamType type, int duration, int interval)
        {
            this.storagePath = path;
            this.containerFormat = format;
            this.streamType = type;
            this.maxDurationMs = duration;
            this.recorderInfoUpdateInterval = interval;
        }
    }

    /* class_recorderinfo */
    public class RecorderInfo
    {
        /* class_recorderinfo_fileName */
        public string fileName;

        /* class_recorderinfo_durationMs */
        public uint durationMs;

        /* class_recorderinfo_fileSize */
        public uint fileSize;

        public RecorderInfo()
        {
            this.fileName = "";
            this.durationMs = 0;
            this.fileSize = 0;
        }

        public RecorderInfo(string name, uint dur, uint size)
        {
            this.fileName = name;
            this.durationMs = dur;
            this.fileSize = size;
        }
    }

#endregion terra AgoraMediaBase.h
}