using System;

namespace Agora.Rtc
{
    using uint64_t = UInt64;

    #region AgoraMediaBase.h

    ///
    /// <summary>
    /// The type of the audio route.
    /// </summary>
    ///
    public enum AudioRoute
    {
        ///
        /// <summary>
        /// -1: Default audio route.
        /// </summary>
        ///
        ROUTE_DEFAULT = -1,

        ///
        /// <summary>
        /// Audio output routing is a headset with microphone.
        /// </summary>
        ///
        ROUTE_HEADSET = 0,

        ///
        /// <summary>
        /// 1: The audio route is an earpiece.
        /// </summary>
        ///
        ROUTE_EARPIECE = 1,

        ///
        /// <summary>
        /// 2: The audio route is a headset without a microphone.
        /// </summary>
        ///
        ROUTE_HEADSETNOMIC = 2,

        ///
        /// <summary>
        /// 3: The audio route is the speaker that comes with the device.
        /// </summary>
        ///
        ROUTE_SPEAKERPHONE = 3,

        ///
        /// <summary>
        /// 4: The audio route is an external speaker. (iOS and macOS only)
        /// </summary>
        ///
        ROUTE_LOUDSPEAKER = 4,

        ///
        /// <summary>
        /// 5: The audio route is a bluetooth headset.
        /// </summary>
        ///
        ROUTE_HEADSETBLUETOOTH = 5,

        ///
        /// <summary>
        /// 7: (macOS only) The audio route is an HDMI peripheral device.
        /// </summary>
        ///
        ROUTE_HDMI = 6,

        ///
        /// <summary>
        /// 6: (macOS only) The audio route is a USB peripheral device.
        /// </summary>
        ///
        ROUTE_USB = 7
    };

    public enum NLP_AGGRESSIVENESS
    {
        NLP_NOT_SPECIFIED = 0,

        NLP_MILD = 1,

        NLP_NORMAL = 2,

        NLP_AGGRESSIVE = 3,

        NLP_SUPER_AGGRESSIVE = 4,

        NLP_EXTREME = 5,
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

    ///
    /// <summary>
    /// The use mode of the audio data.
    /// </summary>
    ///
    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        ///
        /// <summary>
        /// 0: Read-only mode: 
        /// </summary>
        ///
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        ///
        /// <summary>
        /// 2: Read and write mode: 
        /// </summary>
        ///
        RAW_AUDIO_FRAME_OP_MODE_READ_WRITE = 2,
    };

    ///
    /// <summary>
    /// Media source type.
    /// </summary>
    ///
    public enum MEDIA_SOURCE_TYPE
    {
        ///
        /// <summary>
        /// 0: Audio playback device.
        /// </summary>
        ///
        AUDIO_PLAYOUT_SOURCE = 0,

        ///
        /// <summary>
        /// 1: Audio capturing device.
        /// </summary>
        ///
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
    }

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

    ///
    /// <summary>
    /// The number of channels for audio preprocessing.
    /// In scenarios that require enhanced realism, such as concerts, local users might need to capture stereo audio and send stereo signals to remote users. For example, the singer, guitarist, and drummer are standing in different positions on the stage. The audio capture device captures their stereo audio and sends stereo signals to remote users. Remote users can hear the song, guitar, and drum from different directions as if they were at the auditorium.
    /// You can set the dual-channel processing to implement stereo audio in this class. Agora recommends the following settings:
    /// Preprocessing: call SetAdvancedAudioOptions and set audioProcessingChannels to AdvancedAudioOptions (2) in AUDIO_PROCESSING_STEREO.
    /// Post-processing: call SetAudioProfile [2/2] profile to AUDIO_PROFILE_MUSIC_STANDARD_STEREO (3) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5). 
    /// The stereo setting only takes effect when the SDK uses the media volume. See and .
    /// On iOS, stereo audio requires high device performance. Stereo audio is only supported on the following devices using iOS 14.0 and later:
    /// iPhone XS
    /// iPhone XS Max
    /// iPhone XR
    /// iPhone 11
    /// iPhone 11 Pro
    /// iPhone 11 Pro Max
    /// iPhone SE (2020)
    /// iPad Pro 11" and 12.9" (3rd generation)
    /// iPad Pro 11" and 12.9" (4th generation)
    /// </summary>
    ///
    public enum AUDIO_PROCESSING_CHANNELS
    {
        ///
        /// <summary>
        /// 1: (Default) Mono.
        /// </summary>
        ///
        AUDIO_PROCESSING_MONO = 1,

        ///
        /// <summary>
        /// 2: Stereo (two channels).
        /// </summary>
        ///
        AUDIO_PROCESSING_STEREO = 2
    };

    ///
    /// <summary>
    /// The advanced options for audio.
    /// </summary>
    ///
    public class AdvancedAudioOptions
    {
        ///
        /// <summary>
        /// The number of channels for audio preprocessing. See AUDIO_PROCESSING_CHANNELS .
        /// </summary>
        ///
        public AUDIO_PROCESSING_CHANNELS audioProcessingChannels { set; get; }

        public AdvancedAudioOptions()
        {
            audioProcessingChannels = AUDIO_PROCESSING_CHANNELS.AUDIO_PROCESSING_MONO;
        }
    };

    public class AudioEncodedFrameInfo
    {
        public uint64_t sendTs { set; get; }

        public Byte codec { set; get; }

        public AudioEncodedFrameInfo()
        {
            sendTs = 0;
            codec = 0;
        }
    };

    public struct AudioPcmFrame
    {
        public UInt32 capture_timestamp;

        public UInt64 samples_per_channel_;

        public int sample_rate_hz_;

        public UInt64 num_channels_;

        public BYTES_PER_SAMPLE bytes_per_sample;

        public Int16[] data_;
    };

    ///
    /// <summary>
    /// The channel mode.
    /// </summary>
    ///
    public enum AUDIO_DUAL_MONO_MODE
    {
        ///
        /// <summary>
        /// 0: Original mode.
        /// </summary>
        ///
        AUDIO_DUAL_MONO_STEREO = 0,

        ///
        /// <summary>
        /// 1: Left channel mode. This mode replaces the audio of the right channel with the audio of the left channel, which means the user can only hear the audio of the left channel.
        /// </summary>
        ///
        AUDIO_DUAL_MONO_L = 1,

        ///
        /// <summary>
        /// 2: Right channel mode. This mode replaces the audio of the left channel with the audio of the right channel, which means the user can only hear the audio of the right channel.
        /// </summary>
        ///
        AUDIO_DUAL_MONO_R = 2,

        ///
        /// <summary>
        /// 3: Mixed channel mode. This mode mixes the audio of the left channel and the right channel, which means the user can hear the audio of the left channel and the right channel at the same time.
        /// </summary>
        ///
        AUDIO_DUAL_MONO_MIX = 3
    };

    ///
    /// <summary>
    /// The video pixel format.
    /// </summary>
    ///
    public enum VIDEO_PIXEL_FORMAT
    {
        ///
        /// <summary>
        /// 0: The format is known.
        /// </summary>
        ///
        VIDEO_PIXEL_UNKNOWN = 0,

        ///
        /// <summary>
        /// 1: The format is I420.
        /// </summary>
        ///
        VIDEO_PIXEL_I420 = 1,

        ///
        /// <summary>
        /// 2: The format is BGRA.
        /// </summary>
        ///
        VIDEO_PIXEL_BGRA = 2,

        ///
        /// <summary>
        /// 3: The format is NV21.
        /// </summary>
        ///
        VIDEO_PIXEL_NV21 = 3,

        ///
        /// <summary>
        /// 4: The format is RGBA.
        /// </summary>
        ///
        VIDEO_PIXEL_RGBA = 4,

        ///
        /// <summary>
        /// 8: The format is NV12.
        /// </summary>
        ///
        VIDEO_PIXEL_NV12 = 8,

        VIDEO_TEXTURE_2D = 10,

        VIDEO_TEXTURE_OES = 11,

        ///
        /// <summary>
        /// 16: The format is I422.
        /// </summary>
        ///
        VIDEO_PIXEL_I422 = 16,
    };

    ///
    /// <summary>
    /// Video display modes.
    /// </summary>
    ///
    public enum RENDER_MODE_TYPE
    {
        ///
        /// <summary>
        /// 1: Uniformly scale the video until one of its dimension fits the boundary (zoomed to fit). The window is filled. One dimension of the video might have clipped contents.
        /// </summary>
        ///
        RENDER_MODE_HIDDEN = 1,

        ///
        /// <summary>
        /// 2: Uniformly scale the video until one of its dimension fits the boundary (zoomed to fit). Priority is to ensuring that all video content is displayed. Areas that are not filled due to disparity in the aspect ratio are filled with black.
        /// </summary>
        ///
        RENDER_MODE_FIT = 2,

        RENDER_MODE_ADAPTIVE = 3,
    };

    public enum EGL_CONTEXT_TYPE
    {
        EGL_CONTEXT10 = 0,

        EGL_CONTEXT14 = 1,
    };

    ///
    /// <summary>
    /// The video buffer type.
    /// </summary>
    ///
    public enum VIDEO_BUFFER_TYPE
    {
        ///
        /// <summary>
        /// 1: The video buffer in the format of raw data.
        /// </summary>
        ///
        VIDEO_BUFFER_RAW_DATA = 1,

        ///
        /// <summary>
        /// 2: The video buffer in the format of raw data.
        /// </summary>
        ///
        VIDEO_BUFFER_ARRAY = 2,

        ///
        /// <summary>
        /// 3: The video buffer in the format of Texture.
        /// </summary>
        ///
        VIDEO_BUFFER_TEXTURE = 3,
    };

    ///
    /// <summary>
    /// The external video frame.
    /// </summary>
    ///
    public class ExternalVideoFrame
    {
        public ExternalVideoFrame()
        {
            this.type = VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA;
            this.format = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_UNKNOWN;
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

        ///
        /// <summary>
        /// The buffer type. See VIDEO_BUFFER_TYPE .
        /// </summary>
        ///
        public VIDEO_BUFFER_TYPE type { set; get; }

        ///
        /// <summary>
        /// The pixel format. See VIDEO_PIXEL_FORMAT .
        /// </summary>
        ///
        public VIDEO_PIXEL_FORMAT format { set; get; }

        ///
        /// <summary>
        /// Video frame buffer.
        /// </summary>
        ///
        public byte[] buffer { set; get; }

        ///
        /// <summary>
        /// Line spacing of the incoming video frame, which must be in pixels instead of bytes. For textures, it is the width of the texture.
        /// </summary>
        ///
        public int stride { set; get; }

        ///
        /// <summary>
        /// Height of the incoming video frame.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the left. The default value is 0.
        /// </summary>
        ///
        public int cropLeft { set; get; }

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the top. The default value is 0.
        /// </summary>
        ///
        public int cropTop { set; get; }

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the right. The default value is 0.
        /// </summary>
        ///
        public int cropRight { set; get; }

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the bottom. The default value is 0.
        /// </summary>
        ///
        public int cropBottom { set; get; }

        ///
        /// <summary>
        /// Raw data related parameter. The clockwise rotation of the video frame. You can set the rotation angle as 0, 90, 180, or 270. The default value is 0.
        /// </summary>
        ///
        public int rotation { set; get; }

        ///
        /// <summary>
        /// Timestamp (ms) of the incoming video frame. An incorrect timestamp results in frame loss or unsynchronized audio and video.
        /// </summary>
        ///
        public long timestamp { set; get; }

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format.
        /// When using the OpenGL interface (javax.microedition.khronos.egl.*) defined by Khronos, set eglContext to this field.
        /// When using the OpenGL interface (android.opengl.*) defined by Android, set eglContext to this field.
        /// </summary>
        ///
        public byte[] eglContext { set; get; }

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Texture ID of the frame.
        /// </summary>
        ///
        public EGL_CONTEXT_TYPE eglType { set; get; }

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Incoming 4 x 4 transformational matrix. The typical value is a unit matrix.
        /// </summary>
        ///
        public int textureId { set; get; }

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData buffer. The default value is NULL.
        /// </summary>
        ///
        public byte[] metadata_buffer { set; get; }

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData size. The default value is 0.
        /// </summary>
        ///
        public int metadata_size { set; get; }
    };

    ///
    /// <summary>
    /// Video frame information.
    /// The video data format is YUV420. The buffer provides a pointer to a pointer. This interface cannot modify the pointer of the buffer but can modify the content of the buffer.
    /// </summary>
    ///
    public class VideoFrame
    {
        public VideoFrame()
        {
            type = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_UNKNOWN;
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

        ///
        /// <summary>
        /// The pixel format. See VIDEO_PIXEL_FORMAT .
        /// </summary>
        ///
        public VIDEO_PIXEL_FORMAT type { set; get; }

        ///
        /// <summary>
        /// Video pixel width.
        /// </summary>
        ///
        public int width { set; get; }

        ///
        /// <summary>
        /// Video pixel height.
        /// </summary>
        ///
        public int height { set; get; }

        ///
        /// <summary>
        /// For YUV data, the line span of the Y buffer; for RGBA data, the total data length.
        /// </summary>
        ///
        public int yStride { set; get; }

        ///
        /// <summary>
        /// For YUV data, the line span of the U buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public int uStride { set; get; }

        ///
        /// <summary>
        /// For YUV data, the line span of the V buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public int vStride { set; get; }

        ///
        /// <summary>
        /// For YUV data, the pointer to the Y buffer; for RGBA data, the data buffer.
        /// </summary>
        ///
        public byte[] yBuffer { set; get; }

        public IntPtr yBufferPtr { set; get; }

        ///
        /// <summary>
        /// For YUV data, the pointer to the U buffer; for RGBA data, the value is NULL.
        /// </summary>
        ///
        public byte[] uBuffer { set; get; }

        public IntPtr uBufferPtr { set; get; }

        ///
        /// <summary>
        /// For YUV data, the pointer to the V buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public byte[] vBuffer { set; get; }

        public IntPtr vBufferPtr { set; get; }

        ///
        /// <summary>
        /// The clockwise rotation angle of the video frame before rendering. The supported values are 0, 90, 180, or 270 degrees.
        /// </summary>
        ///
        public int rotation { set; get; }

        ///
        /// <summary>
        /// The Unix timestamp (ms) when the video frame is rendered. This timestamp can be used to guide the rendering of the video frame. It is required.
        /// </summary>
        ///
        public Int64 renderTimeMs { set; get; }

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public int avsync_type { set; get; }

        public IntPtr metadata_buffer { set; get; }

        public int metadata_size { set; get; }

        public IntPtr sharedContext { set; get; }

        public int textureId { set; get; }

        public float[] matrix { set; get; }
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

        POSITION_POST_FILTERS = 1 << 3,
    };

    ///
    /// <summary>
    /// Audio frame type.
    /// </summary>
    ///
    public enum AUDIO_FRAME_TYPE
    {
        ///
        /// <summary>
        /// 0: PCM 16
        /// </summary>
        ///
        FRAME_TYPE_PCM16 = 0, // PCM 16bit little endian
    };

    ///
    /// <summary>
    ///  AudioFrame 
    /// </summary>
    ///
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
            byte[] buffer, Int64 renderTimeMs, int avsync_type)
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

        ///
        /// <summary>
        /// The type of the audio frame. See AUDIO_FRAME_TYPE .
        /// </summary>
        ///
        public AUDIO_FRAME_TYPE type { set; get; }

        ///
        /// <summary>
        /// The number of samples per channel in the audio frame.
        /// </summary>
        ///
        public int samplesPerChannel { set; get; }

        ///
        /// <summary>
        /// The number of bytes per audio sample, which is usually 16-bit (2 bytes).
        /// </summary>
        ///
        public BYTES_PER_SAMPLE bytesPerSample { set; get; }

        ///
        /// <summary>
        /// The number of audio channels (the data are interleaved if it is stereo).
        /// 1: Mono.
        /// 2: Stereo. 
        /// </summary>
        ///
        public int channels { set; get; }

        ///
        /// <summary>
        /// The number of samples per channel in the audio frame.
        /// </summary>
        ///
        public int samplesPerSec { set; get; }

        public UInt64 buffer { set; get; }

        public IntPtr bufferPtr { set; get; }

        ///
        /// <summary>
        /// The data buffer of the audio frame. When the audio frame uses a stereo channel, the data buffer is interleaved.
        /// The size of the data buffer is as follows: buffer = samples × channels × bytesPerSample.
        /// </summary>
        ///
        public byte[] RawBuffer { set; get; }

        ///
        /// <summary>
        /// The timestamp (ms) of the external audio frame.
        /// You can use this timestamp to restore the order of the captured audio frame, and synchronize audio and video frames in video scenarios, including scenarios where external video sources are used.
        /// </summary>
        ///
        public Int64 renderTimeMs { set; get; }

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public int avsync_type { set; get; }
    };

    ///
    /// <summary>
    /// The audio spectrum data.
    /// </summary>
    ///
    public struct AudioSpectrumData
    {
        ///
        /// <summary>
        /// The audio spectrum data. Agora divides the audio frequency into 160 frequency domains, and reports the energy value of each frequency domain through this parameter. The value range of each energy type is [0, 1].
        /// </summary>
        ///
        public float[] audioSpectrumData;

        ///
        /// <summary>
        /// The length of the audio spectrum data in byte.
        /// </summary>
        ///
        public int dataLength;
    };

    public struct UserAudioSpectrumInfo
    {
        public uint uid;

        public AudioSpectrumData spectrumData;
    };

    ///
    /// <summary>
    /// The frame position of the video observer.
    /// </summary>
    ///
    [Flags]
    public enum VIDEO_OBSERVER_POSITION
    {
        ///
        /// <summary>
        /// 1: The post-capturer position, which corresponds to the video data in the OnCaptureVideoFrame callback.
        /// </summary>
        ///
        POSITION_POST_CAPTURER = 1 << 0,

        ///
        /// <summary>
        /// 2: The pre-renderer position, which corresponds to the video data in the OnRenderVideoFrame callback.
        /// </summary>
        ///
        POSITION_PRE_RENDERER = 1 << 1,

        ///
        /// <summary>
        /// 4: The pre-encoder position, which corresponds to the video data in the OnPreEncodeVideoFrame callback.
        /// </summary>
        ///
        POSITION_PRE_ENCODER = 1 << 2,
    };

    public enum CONTENT_INSPECT_RESULT
    {
        CONTENT_INSPECT_NEUTRAL = 1,

        CONTENT_INSPECT_SEXY = 2,

        CONTENT_INSPECT_PORN = 3,

        MAX_CONTENT_INSPECT_MODULE_COUNT = 32
    };

    public enum CONTENT_INSPECT_DEVICE_TYPE
    {
        CONTENT_INSPECT_DEVICE_INVALID = 0,

        CONTENT_INSPECT_DEVICE_AGORA = 1,

        CONTENT_INSPECT_DEVICE_HIVE = 2,

        CONTENT_INSPECT_DEVICE_TUPU = 3
    };

    public enum CONTENT_INSPECT_TYPE
    {
        CONTENT_INSPECT_INVALIDE = 0,

        CONTENT_INSPECT_MODERATION = 1,

        CONTENT_INSPECT_SUPERVISE = 2
    };

    public class ContentInspectModule
    {
        public CONTENT_INSPECT_TYPE type { set; get; }

        public uint frequency { set; get; }
    };

    public class ContentInspectConfig
    {
        public ContentInspectConfig()
        {
            enable = false;
            DeviceWork = false;
            CloudWork = true;
            DeviceworkType = CONTENT_INSPECT_DEVICE_TYPE.CONTENT_INSPECT_DEVICE_INVALID;
            extraInfo = "";
            moduleCount = 0;
        }

        public bool enable { set; get; }

        public bool DeviceWork { set; get; }

        public bool CloudWork { set; get; }

        public CONTENT_INSPECT_DEVICE_TYPE DeviceworkType { set; get; }

        public string extraInfo { set; get; }

        public ContentInspectModule[] modules { set; get; }

        public int moduleCount { set; get; }
    };

    public class SnapShotConfig
    {
        public SnapShotConfig()
        {
            channel = null;
            uid = 0;
            filePath = null;
        }

        public string channel { set; get; }

        public uint uid { set; get; }

        public string filePath { set; get; }
    };

    ///
    /// <summary>
    /// The external video frame encoding type.
    /// </summary>
    ///
    public enum EXTERNAL_VIDEO_SOURCE_TYPE
    {
        ///
        /// <summary>
        /// 0: The video frame is not encoded.
        /// </summary>
        ///
        VIDEO_FRAME = 0,

        ///
        /// <summary>
        /// 1: The video frame is encoded.
        /// </summary>
        ///
        ENCODED_VIDEO_FRAME = 1,
    };

    #endregion
}