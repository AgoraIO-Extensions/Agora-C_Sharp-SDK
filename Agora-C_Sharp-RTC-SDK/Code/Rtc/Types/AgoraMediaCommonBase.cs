using System;

namespace Agora.Rtc
{
    using int64_t = Int64;
    using view_t = Int64;
    using uint64_t = UInt64;
    using uint8_t = Byte;
    using uint32_t = UInt32;
    using int16_t = Int16;

    ///
    /// <summary>
    /// Configurations of the video frame.
    /// 
    /// Note that the buffer provides a pointer to a pointer. This interface cannot modify the pointer of the buffer, but it can modify the content of the buffer.
    /// </summary>
    ///
    public class VideoFrame
    {
        #region terra VideoFrame_Member_List

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

        public IntPtr d3d11Texture2d;

        public float[] matrix;

        public byte[] alphaBuffer;

        public IntPtr alphaBufferPtr;



        public IVideoFrameMetaInfo metaInfo;
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
            this.d3d11Texture2d = IntPtr.Zero;
            this.alphaBuffer = new byte[0];
            this.alphaBufferPtr = IntPtr.Zero;
            this.metaInfo = null;
            this.matrix = new float[16];
        }


        #endregion terra VideoFrame_Constructor
    }

    ///
    /// <summary>
    /// Raw audio data.
    /// </summary>
    ///
    public class AudioFrame
    {
        #region terra AudioFrame_Member_List

        public AUDIO_FRAME_TYPE type;

        public int samplesPerChannel;

        public BYTES_PER_SAMPLE bytesPerSample;

        public int channels;

        public int samplesPerSec;

        public IntPtr buffer;

        public long renderTimeMs;

        public int avsync_type;

        public long presentationMs;

        public int audioTrackNumber;
        #endregion terra AudioFrame_Member_List

        ///
        /// <summary>
        /// The data buffer of the audio frame. When the audio frame uses a stereo channel, the data buffer is interleaved. The size of the data buffer is as follows: buffer = samples × channels × bytesPerSample.
        /// </summary>
        ///
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
            this.audioTrackNumber = 0;
            this.RawBuffer = new byte[0];
        }


        public AudioFrame(AUDIO_FRAME_TYPE type, int samplesPerChannel, BYTES_PER_SAMPLE bytesPerSample, int channels, int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type, long presentationMs, int audioTrackNumber)
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
            this.audioTrackNumber = audioTrackNumber;
        }




        #endregion terra AudioFrame_Constructor
    }

    #region terra AgoraMediaCommonBase.h

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

        CONTENT_INSPECT_IMAGE_MODERATION = 3,
    }


    public class ContentInspectModule
    {
        public CONTENT_INSPECT_TYPE type;

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



    public class ContentInspectConfig
    {
        public string extraInfo;

        public ContentInspectModule[] modules;

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



    public class PacketOptions
    {
        public uint timestamp;

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



    public class AudioEncodedFrameInfo
    {
        public ulong sendTs;

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



    public class AudioPcmFrame
    {
        public long capture_timestamp;

        public ulong samples_per_channel_;

        public int sample_rate_hz_;

        public ulong num_channels_;

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

        VIDEO_TEXTURE_ID3D11TEXTURE2D = 17,
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


    public enum META_INFO_KEY
    {
        KEY_FACE_CAPTURE = 0,
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

        public IntPtr eglContext;

        public EGL_CONTEXT_TYPE eglType;

        public int textureId;

        public float[] matrix;

        public byte[] metadata_buffer;

        public int metadata_size;

        public byte[] alphaBuffer;

        public IntPtr d3d11_texture_2d;

        public int texture_slice_index;

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
            this.d3d11_texture_2d = IntPtr.Zero;
            this.texture_slice_index = 0;
        }

        public ExternalVideoFrame(VIDEO_BUFFER_TYPE type, VIDEO_PIXEL_FORMAT format, byte[] buffer, int stride, int height, int cropLeft, int cropTop, int cropRight, int cropBottom, int rotation, long timestamp, IntPtr eglContext, EGL_CONTEXT_TYPE eglType, int textureId, float[] matrix, byte[] metadata_buffer, int metadata_size, byte[] alphaBuffer, IntPtr d3d11_texture_2d, int texture_slice_index)
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
            this.d3d11_texture_2d = d3d11_texture_2d;
            this.texture_slice_index = texture_slice_index;
        }
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


    public enum MEDIA_PLAYER_SOURCE_TYPE
    {
        MEDIA_PLAYER_SOURCE_DEFAULT,

        MEDIA_PLAYER_SOURCE_FULL_FEATURED,

        MEDIA_PLAYER_SOURCE_SIMPLE,
    }


    [Flags]
    public enum VIDEO_MODULE_POSITION
    {
        POSITION_POST_CAPTURER = 1 << 0,

        POSITION_PRE_RENDERER = 1 << 1,

        POSITION_PRE_ENCODER = 1 << 2,

        POSITION_POST_CAPTURER_ORIGIN = 1 << 3,
    }


    public enum AUDIO_FRAME_TYPE
    {
        FRAME_TYPE_PCM16 = 0,
    }


    [Flags]
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



    public class AudioSpectrumData
    {
        public float[] audioSpectrumData;

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



    public class UserAudioSpectrumInfoBase
    {
        public AudioSpectrumData spectrumData;

        public UserAudioSpectrumInfoBase()
        {
        }

        public UserAudioSpectrumInfoBase(float[] data, int length)
        {
            this.spectrumData = new AudioSpectrumData(data, length);
        }

        public UserAudioSpectrumInfoBase(AudioSpectrumData spectrumData)
        {
            this.spectrumData = spectrumData;
        }
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



    public class RecorderInfo
    {
        public string fileName;

        public uint durationMs;

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




    #endregion terra AgoraMediaCommonBase.h
}