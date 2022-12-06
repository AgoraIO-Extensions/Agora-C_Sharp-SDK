using System;

namespace Agora.Rtc
{
    using int64_t = Int64;
    using view_t = UInt64;
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
        /// -1: The default audio route.
        /// </summary>
        ///
        ROUTE_DEFAULT = -1,

        ///
        /// <summary>
        /// 0: Audio output routing is a headset with microphone.
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
        /// 6: The audio route is an HDMI peripheral device. (For macOS only)
        /// </summary>
        ///
        ROUTE_HDMI = 6,

        ///
        /// <summary>
        /// 7: The audio route is a USB peripheral device. (For macOS only)
        /// </summary>
        ///
        ROUTE_USB = 7,

        ///
        /// <summary>
        /// 8: The audio route is a DisplayPort peripheral device. (For macOS only)
        /// </summary>
        ///
        ROUTE_DISPLAYPORT = 8,

        ///
        /// <summary>
        /// 9: The audio route is Apple AirPlay. (For macOS only)
        /// </summary>
        ///
        ROUTE_AIRPLAY = 9
    };

    ///
    /// @ignore
    ///
    public enum BYTES_PER_SAMPLE
    {
        ///
        /// @ignore
        ///
        TWO_BYTES_PER_SAMPLE = 2,
    };

    ///
    /// @ignore
    ///
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

        ///
        /// @ignore
        ///
        public int sample_rate;

        ///
        /// @ignore
        ///
        public uint channels;

        ///
        /// @ignore
        ///
        public uint frames_per_buffer;
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
        /// 0: Read-only mode, 
        /// </summary>
        ///
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        ///
        /// <summary>
        /// 2: Read and write mode, 
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

        ///
        /// <summary>
        /// 2: The primary camera.
        /// </summary>
        ///
        PRIMARY_CAMERA_SOURCE = 2,

        ///
        /// <summary>
        /// 3: The secondary camera.
        /// </summary>
        ///
        SECONDARY_CAMERA_SOURCE = 3,

        ///
        /// @ignore
        ///
        PRIMARY_SCREEN_SOURCE = 4,

        ///
        /// @ignore
        ///
        SECONDARY_SCREEN_SOURCE = 5,

        ///
        /// @ignore
        ///
        CUSTOM_VIDEO_SOURCE = 6,

        ///
        /// @ignore
        ///
        MEDIA_PLAYER_SOURCE = 7,

        ///
        /// @ignore
        ///
        RTC_IMAGE_PNG_SOURCE = 8,

        ///
        /// @ignore
        ///
        RTC_IMAGE_JPEG_SOURCE = 9,

        ///
        /// @ignore
        ///
        RTC_IMAGE_GIF_SOURCE = 10,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_SOURCE = 11,

        ///
        /// @ignore
        ///
        TRANSCODED_VIDEO_SOURCE = 12,

        ///
        /// <summary>
        /// 100: Unknown media source.
        /// </summary>
        ///
        UNKNOWN_MEDIA_SOURCE = 100
    };

    ///
    /// @ignore
    ///
    public class PacketOptions
    {
        ///
        /// @ignore
        ///
        public uint timestamp;

        ///
        /// @ignore
        ///
        public byte audioLevelIndication;

        public PacketOptions()
        {
            timestamp = 0;
            audioLevelIndication = 127;
        }
    };

    ///
    /// @ignore
    ///
    public class AudioEncodedFrameInfo
    {
        ///
        /// @ignore
        ///
        public uint64_t sendTs;

        ///
        /// @ignore
        ///
        public Byte codec;

        public AudioEncodedFrameInfo()
        {
            sendTs = 0;
            codec = 0;
        }
    };

    ///
    /// <summary>
    /// The parameters of the audio frame in PCM format.
    /// </summary>
    ///
    public class AudioPcmFrame
    {
        ///
        /// <summary>
        /// The timestamp (ms) of the audio frame.
        /// </summary>
        ///
        public Int64 capture_timestamp;

        ///
        /// <summary>
        /// The number of samples per channel in the audio frame.
        /// </summary>
        ///
        public UInt64 samples_per_channel_;

        ///
        /// <summary>
        /// Audio sample rate (Hz).
        /// </summary>
        ///
        public int sample_rate_hz_;

        ///
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        ///
        public UInt64 num_channels_;

        ///
        /// <summary>
        /// The number of bytes per sample.
        /// </summary>
        ///
        public BYTES_PER_SAMPLE bytes_per_sample;

        ///
        /// <summary>
        /// The video frame.
        /// </summary>
        ///
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
        /// 0: Raw video pixel format.
        /// </summary>
        ///
        VIDEO_PIXEL_DEFAULT = 0,

        ///
        /// <summary>
        /// 1: The format is I420.
        /// </summary>
        ///
        VIDEO_PIXEL_I420 = 1,

        ///
        /// @ignore
        ///
        VIDEO_PIXEL_BGRA = 2,

        ///
        /// @ignore
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

        ///
        /// @ignore
        ///
        VIDEO_TEXTURE_2D = 10,

        ///
        /// @ignore
        ///
        VIDEO_TEXTURE_OES = 11,

        ///
        /// @ignore
        ///
        VIDEO_CVPIXEL_NV12 = 12,

        ///
        /// @ignore
        ///
        VIDEO_CVPIXEL_I420 = 13,

        ///
        /// @ignore
        ///
        VIDEO_CVPIXEL_BGRA = 14,

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
        /// 1: Hidden mode. Uniformly scale the video until one of its dimension fits the boundary (zoomed to fit). One dimension of the video may have clipped contents.
        /// </summary>
        ///
        RENDER_MODE_HIDDEN = 1,

        ///
        /// <summary>
        /// 2: Fit mode. Uniformly scale the video until one of its dimension fits the boundary (zoomed to fit). Areas that are not filled due to disparity in the aspect ratio are filled with black.
        /// </summary>
        ///
        RENDER_MODE_FIT = 2,

        [Obsolete]
        ///
        /// <summary>
        /// Deprecated:3: This mode is deprecated.
        /// </summary>
        ///
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

    ///
    /// @ignore
    ///
    public enum EGL_CONTEXT_TYPE
    {
        ///
        /// @ignore
        ///
        EGL_CONTEXT10 = 0,

        ///
        /// @ignore
        ///
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

        ///
        /// <summary>
        /// The video type. See VIDEO_BUFFER_TYPE .
        /// </summary>
        ///
        public VIDEO_BUFFER_TYPE type;

        ///
        /// <summary>
        /// The pixel format. See VIDEO_PIXEL_FORMAT .
        /// </summary>
        ///
        public VIDEO_PIXEL_FORMAT format;

        ///
        /// <summary>
        /// Video frame buffer.
        /// </summary>
        ///
        public byte[] buffer;

        ///
        /// <summary>
        /// Line spacing of the incoming video frame, which must be in pixels instead of bytes. For textures, it is the width of the texture.
        /// </summary>
        ///
        public int stride;

        ///
        /// <summary>
        /// Height of the incoming video frame.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the left. The default value is 0.
        /// </summary>
        ///
        public int cropLeft;

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the top. The default value is 0.
        /// </summary>
        ///
        public int cropTop;

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the right. The default value is 0.
        /// </summary>
        ///
        public int cropRight;

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the bottom. The default value is 0.
        /// </summary>
        ///
        public int cropBottom;

        ///
        /// <summary>
        /// Raw data related parameter. The clockwise rotation of the video frame. You can set the rotation angle as 0, 90, 180, or 270. The default value is 0.
        /// </summary>
        ///
        public int rotation;

        ///
        /// <summary>
        /// Timestamp (ms) of the incoming video frame. An incorrect timestamp results in frame loss or unsynchronized audio and video.
        /// </summary>
        ///
        public long timestamp;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format.When using the OpenGL interface (javax.microedition.khronos.egl.*) defined by Khronos, set eglContext to this field.When using the OpenGL interface (android.opengl.*) defined by Android, set eglContext to this field.
        /// </summary>
        ///
        public byte[] eglContext;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Texture ID of the frame.
        /// </summary>
        ///
        public EGL_CONTEXT_TYPE eglType;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Incoming 4 x 4 transformational matrix. The typical value is a unit matrix.
        /// </summary>
        ///
        public int textureId;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData buffer. The default value is NULL.
        /// </summary>
        ///
        public byte[] metadata_buffer;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData size. The default value is 0.
        /// </summary>
        ///
        public int metadata_size;
    };

    ///
    /// <summary>
    /// Configurations of the video frame.
    /// The video data format is YUV420. Note that the buffer provides a pointer to a pointer. This interface cannot modify the pointer of the buffer, but it can modify the content of the buffer.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// The pixel format. See VIDEO_PIXEL_FORMAT .
        /// </summary>
        ///
        public VIDEO_PIXEL_FORMAT type;

        ///
        /// <summary>
        /// The width of the video, in pixels.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height of the video, in pixels.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// For YUV data, the line span of the Y buffer; for RGBA data, the total data length.
        /// </summary>
        ///
        public int yStride;

        ///
        /// <summary>
        /// For YUV data, the line span of the U buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public int uStride;

        ///
        /// <summary>
        /// For YUV data, the line span of the V buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public int vStride;

        ///
        /// <summary>
        /// For YUV data, the pointer to the Y buffer; for RGBA data, the data buffer.
        /// </summary>
        ///
        public byte[] yBuffer;

        ///
        /// @ignore
        ///
        public IntPtr yBufferPtr;

        ///
        /// <summary>
        /// For YUV data, the pointer to the U buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public byte[] uBuffer;

        ///
        /// @ignore
        ///
        public IntPtr uBufferPtr;

        ///
        /// <summary>
        /// For YUV data, the pointer to the V buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public byte[] vBuffer;

        ///
        /// @ignore
        ///
        public IntPtr vBufferPtr;

        ///
        /// <summary>
        /// The clockwise rotation of the video frame before rendering. Supported values include 0, 90, 180, and 270 degrees.
        /// </summary>
        ///
        public int rotation;

        ///
        /// <summary>
        /// The Unix timestamp (ms) when the video frame is rendered. This timestamp can be used to guide the rendering of the video frame. It is required.
        /// </summary>
        ///
        public long renderTimeMs;

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public int avsync_type;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData buffer. The default value is NULL.
        /// </summary>
        ///
        public IntPtr metadata_buffer;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData size. The default value is 0.
        /// </summary>
        ///
        public int metadata_size;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. EGL Context.
        /// </summary>
        ///
        public IntPtr sharedContext;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Texture ID.
        /// </summary>
        ///
        public int textureId;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Incoming 4 × 4 transformational matrix. The typical value is a unit matrix.
        /// </summary>
        ///
        public float[] matrix;

        ///
        /// @ignore
        ///
        public byte[] alphaBuffer;

        ///
        /// @ignore
        ///
        public IntPtr alphaBufferPtr;
    };

    ///
    /// @ignore
    ///
    public enum MEDIA_PLAYER_SOURCE_TYPE
    {
        ///
        /// @ignore
        ///
        MEDIA_PLAYER_SOURCE_DEFAULT = 0,

        ///
        /// @ignore
        ///
        MEDIA_PLAYER_SOURCE_FULL_FEATURED = 1,

        ///
        /// @ignore
        ///
        MEDIA_PLAYER_SOURCE_SIMPLE = 2,
    };

    [Flags]
    ///
    /// <summary>
    /// The frame position of the video observer.
    /// </summary>
    ///
    public enum VIDEO_MODULE_POSITION
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
        FRAME_TYPE_PCM16 = 0,
    };

    ///
    /// @ignore
    ///
    public enum MAX_HANDLE_TIME_CNT
    {
        ///
        /// @ignore
        ///
        MAX_HANDLE_TIME_CNT = 10
    };

    ///
    /// <summary>
    /// Raw audio data.
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

        ///
        /// <summary>
        /// The type of the audio frame. See AUDIO_FRAME_TYPE .
        /// </summary>
        ///
        public AUDIO_FRAME_TYPE type;

        ///
        /// <summary>
        /// The number of samples per channel in the audio frame.
        /// </summary>
        ///
        public int samplesPerChannel;

        ///
        /// <summary>
        /// The number of bytes per audio sample, which is usually 16-bit (2 bytes).
        /// </summary>
        ///
        public BYTES_PER_SAMPLE bytesPerSample;

        ///
        /// <summary>
        /// The number of audio channels (the data are interleaved if it is stereo).1: Mono.2: Stereo.
        /// </summary>
        ///
        public int channels;

        ///
        /// <summary>
        /// The number of samples per channel in the audio frame.
        /// </summary>
        ///
        public int samplesPerSec;


        ///
        /// @ignore
        ///
        public IntPtr buffer;

        ///
        /// <summary>
        /// The data buffer of the audio frame. When the audio frame uses a stereo channel, the data buffer is interleaved.The size of the data buffer is as follows: buffer = samples ×channels × bytesPerSample.
        /// </summary>
        ///
        public byte[] RawBuffer;

        ///
        /// <summary>
        /// The timestamp (ms) of the external audio frame.You can use this timestamp to restore the order of the captured audio frame, and synchronize audio and video frames in video scenarios, including scenarios where external video sources are used.
        /// </summary>
        ///
        public long renderTimeMs;

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public int avsync_type;
    };

    [Flags]
    ///
    /// @ignore
    ///
    public enum AUDIO_FRAME_POSITION
    {
        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_NONE = 0x0000,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_PLAYBACK = 0x0001,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_RECORD = 0x0002,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_MIXED = 0x0004,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_BEFORE_MIXING = 0x0008,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_EAR_MONITORING = 0x0010
    };

    ///
    /// <summary>
    /// Audio data format.
    /// You can pass the AudioParams object in the return value of the following callbacksto set the audio data format for the corresponding callback: GetRecordAudioParams : Sets the audio data format for the OnRecordAudioFrame callback. GetPlaybackAudioParams : Sets the audio data format for the OnPlaybackAudioFrame callback. GetMixedAudioParams : Sets the audio data format for the OnMixedAudioFrame callback. GetEarMonitoringAudioParams : Sets the audio data format for the OnEarMonitoringAudioFrame callback.The SDK calculates the sampling interval through the samplesPerCall, sampleRate, and channel parameters in AudioParams, and triggers the OnRecordAudioFrame, OnPlaybackAudioFrame, OnMixedAudioFrame, and OnEarMonitoringAudioFrame callbacks according to the sampling interval.Sample interval (sec) = samplePerCall/(sampleRate × channel).Ensure that the sample interval ≥ 0.01 (s).
    /// </summary>
    ///
    public class AudioParams
    {
        ///
        /// <summary>
        /// The audio sample rate (Hz), which can be set as one of the following values:8000.(Default) 16000.32000.4410048000
        /// </summary>
        ///
        public int sample_rate;

        ///
        /// <summary>
        /// The number of audio channels, which can be set as either of the following values:1: (Default) Mono.2: Stereo.
        /// </summary>
        ///
        public int channels;

        ///
        /// <summary>
        /// The use mode of the audio data. See RAW_AUDIO_FRAME_OP_MODE_TYPE .
        /// </summary>
        ///
        public RAW_AUDIO_FRAME_OP_MODE_TYPE mode;

        ///
        /// <summary>
        /// The number of samples, such as 1024 for the media push.
        /// </summary>
        ///
        public int samples_per_call;

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

    ///
    /// <summary>
    /// The audio spectrum data.
    /// </summary>
    ///
    public class AudioSpectrumData
    {
        ///
        /// <summary>
        /// The audio spectrum data. Agora divides the audio frequency into 256 frequency domains, and reports the energy value of each frequency domain through this parameter. The value range of each energy type is [-300, 1] and the unit is dBFS.
        /// </summary>
        ///
        public float[] audioSpectrumData;

        ///
        /// <summary>
        /// The audio spectrum data length is 256.
        /// </summary>
        ///
        public int dataLength;
    };

    ///
    /// <summary>
    /// Audio spectrum information of the remote user.
    /// </summary>
    ///
    public class UserAudioSpectrumInfo
    {
        ///
        /// <summary>
        /// The user ID of the remote user.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// Audio spectrum information of the remote user.See AudioSpectrumData .
        /// </summary>
        ///
        public AudioSpectrumData spectrumData;
    };

    [Flags]
    ///
    /// @ignore
    ///
    public enum VIDEO_OBSERVER_POSITION
    {
        ///
        /// @ignore
        ///
        POSITION_POST_CAPTURER = 1 << 0,

        ///
        /// @ignore
        ///
        POSITION_PRE_RENDERER = 1 << 1,

        ///
        /// @ignore
        ///
        POSITION_PRE_ENCODER = 1 << 2,
    };

    ///
    /// @ignore
    ///
    public enum CONTENT_INSPECT_RESULT
    {
        ///
        /// @ignore
        ///
        CONTENT_INSPECT_NEUTRAL = 1,

        ///
        /// @ignore
        ///
        CONTENT_INSPECT_SEXY = 2,

        ///
        /// @ignore
        ///
        CONTENT_INSPECT_PORN = 3,

        ///
        /// @ignore
        ///
        MAX_CONTENT_INSPECT_MODULE_COUNT = 32
    };

    ///
    /// @ignore
    ///
    public enum CONTENT_INSPECT_VENDOR
    {
        ///
        /// @ignore
        ///
        CONTENT_INSPECT_VENDOR_AGORA = 1,

        ///
        /// @ignore
        ///
        CONTENT_INSPECT_VENDOR_TUPU = 2,

        ///
        /// @ignore
        ///
        ONTENT_INSPECT_VENDOR_HIVE = 3
    };

    ///
    /// @ignore
    ///
    public enum CONTENT_INSPECT_DEVICE_TYPE
    {
        ///
        /// @ignore
        ///
        CONTENT_INSPECT_DEVICE_INVALID = 0,

        ///
        /// @ignore
        ///
        CONTENT_INSPECT_DEVICE_AGORA = 1
    };

    ///
    /// <summary>
    /// The type of video content moderation module.
    /// </summary>
    ///
    public enum CONTENT_INSPECT_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) This module has no actual function. Do not set type to this value.
        /// </summary>
        ///
        CONTENT_INSPECT_INVALID = 0,

        ///
        /// <summary>
        /// 1: Video content moderation. SDK takes screenshots, inspects video content of the video stream in the channel, and uploads the screenshots and moderation results.
        /// </summary>
        ///
        CONTENT_INSPECT_MODERATION = 1,

        ///
        /// <summary>
        /// 2: Screenshot capture. SDK takes screenshots of the video stream in the channel and uploads them.
        /// </summary>
        ///
        CONTENT_INSPECT_SUPERVISION = 2
    };

    ///
    /// @ignore
    ///
    public enum CONTENT_INSPECT_WORK_TYPE
    {
        ///
        /// @ignore
        ///
        CONTENT_INSPECT_WORK_DEVICE = 0,

        ///
        /// @ignore
        ///
        CONTENT_INSPECT_WORK_CLOUD = 1,

        ///
        /// @ignore
        ///
        CONTENT_INSPECT_WORK_DEVICE_CLOUD = 2
    };

    ///
    /// <summary>
    /// A structure used to configure the frequency of video screenshot and upload.ContentInspectModule
    /// </summary>
    ///
    public class ContentInspectModule
    {
        ///
        /// <summary>
        /// Types of functional module. See CONTENT_INSPECT_TYPE .
        /// </summary>
        ///
        public CONTENT_INSPECT_TYPE type;

        ///
        /// <summary>
        /// The frequency (s) of video screenshot and upload. The value should be set as larger than 0. The default value is 0, the SDK does not take screenshots. Agora recommends that you set the value as 10; you can also adjust it according to your business needs.
        /// </summary>
        ///
        public uint interval;

        public ContentInspectModule()
        {
            type = CONTENT_INSPECT_TYPE.CONTENT_INSPECT_INVALID;
            interval = 0;
        }
    };

    ///
    /// <summary>
    /// Configuration of video screenshot and upload.
    /// </summary>
    ///
    public class ContentInspectConfig
    {
        ///
        /// <summary>
        /// Functional module. See ContentInspectModule .A maximum of 32 ContentInspectModule instances can be configured, and the value range of MAX_CONTENT_INSPECT_MODULE_COUNT is an integer in [1,32].A function module can only be configured with one instance at most. Currently only the video screenshot and upload function is supported.
        /// </summary>
        ///
        public ContentInspectModule[] modules;

        ///
        /// <summary>
        /// The number of functional modules, that is,the number of configured ContentInspectModule instances, must be the same as the number of instances configured in modules. The maximum number is 32.
        /// </summary>
        ///
        public int moduleCount;

        public ContentInspectConfig()
        {
            modules = null;
            moduleCount = 0;
        }
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

    ///
    /// <summary>
    /// The format of the recording file.
    /// </summary>
    ///
    public enum MediaRecorderContainerFormat
    {
        ///
        /// <summary>
        /// 1: (Default) MP4.
        /// </summary>
        ///
        FORMAT_MP4 = 1,
    };

    ///
    /// <summary>
    /// The recording content.
    /// </summary>
    ///
    public enum MediaRecorderStreamType
    {
        ///
        /// <summary>
        /// Only audio.
        /// </summary>
        ///
        STREAM_TYPE_AUDIO = 0x01,

        ///
        /// <summary>
        /// Only video.
        /// </summary>
        ///
        STREAM_TYPE_VIDEO = 0x02,

        ///
        /// <summary>
        /// (Default) Audio and video.
        /// </summary>
        ///
        STREAM_TYPE_BOTH = STREAM_TYPE_AUDIO | STREAM_TYPE_VIDEO,
    };

    ///
    /// <summary>
    /// The current recording state.
    /// </summary>
    ///
    public enum RecorderState
    {
        ///
        /// <summary>
        /// -1: An error occurs during the recording. See RecorderErrorCode for the reason.
        /// </summary>
        ///
        RECORDER_STATE_ERROR = -1,

        ///
        /// <summary>
        /// 2: The audio and video recording starts.
        /// </summary>
        ///
        RECORDER_STATE_START = 2,

        ///
        /// <summary>
        /// 3: The audio and video recording stops.
        /// </summary>
        ///
        RECORDER_STATE_STOP = 3,
    };

    ///
    /// <summary>
    /// The reason for the state change.
    /// </summary>
    ///
    public enum RecorderErrorCode
    {
        ///
        /// <summary>
        /// 0: No error.
        /// </summary>
        ///
        RECORDER_ERROR_NONE = 0,

        ///
        /// <summary>
        /// 1: The SDK fails to write the recorded data to a file.
        /// </summary>
        ///
        RECORDER_ERROR_WRITE_FAILED = 1,

        ///
        /// <summary>
        /// 2: The SDK does not detect any audio and video streams, or audio and video streams are interrupted for more than five seconds during recording.
        /// </summary>
        ///
        RECORDER_ERROR_NO_STREAM = 2,

        ///
        /// <summary>
        /// 3: The recording duration exceeds the upper limit.
        /// </summary>
        ///
        RECORDER_ERROR_OVER_MAX_DURATION = 3,

        ///
        /// <summary>
        /// 4: The recording configuration changes.
        /// </summary>
        ///
        RECORDER_ERROR_CONFIG_CHANGED = 4,
    };

    ///
    /// <summary>
    /// Configurations for the local audio and video recording.
    /// </summary>
    ///
    public class MediaRecorderConfiguration
    {
        ///
        /// <summary>
        /// The absolute path (including the filename extensions) of the recording file. For example:Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.mp4iOS: /App Sandbox/Library/Caches/example.mp4macOS: /Library/Logs/example.mp4Android: /storage/emulated/0/Android/data/<package name>/files/example.mp4Ensure that the directory for the log files exists and is writable.
        /// </summary>
        ///
        public string storagePath;

        ///
        /// <summary>
        /// The format of the recording file. See MediaRecorderContainerFormat .
        /// </summary>
        ///
        public MediaRecorderContainerFormat containerFormat;

        ///
        /// <summary>
        /// The recording content. See MediaRecorderStreamType .
        /// </summary>
        ///
        public MediaRecorderStreamType streamType;

        ///
        /// <summary>
        /// The maximum recording duration, in milliseconds. The default value is 120000.
        /// </summary>
        ///
        public int maxDurationMs;

        ///
        /// <summary>
        /// The interval (ms) of updating the recording information. The value range is [1000,10000]. Based on the value you set in this parameter, the SDK triggers the OnRecorderInfoUpdated callback to report the updated recording information.
        /// </summary>
        ///
        public int recorderInfoUpdateInterval;

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

    ///
    /// <summary>
    /// The information about the file that is recorded.
    /// </summary>
    ///
    public class RecorderInfo
    {
        ///
        /// <summary>
        /// The absolute path of the recording file.
        /// </summary>
        ///
        public string fileName;

        ///
        /// <summary>
        /// The recording duration (ms).
        /// </summary>
        ///
        public uint durationMs;

        ///
        /// <summary>
        /// The size (bytes) of the recording file.
        /// </summary>
        ///
        public uint fileSize;

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