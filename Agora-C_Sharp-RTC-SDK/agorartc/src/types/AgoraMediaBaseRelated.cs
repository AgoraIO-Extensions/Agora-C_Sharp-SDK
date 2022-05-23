using System;

namespace agora.rtc
{
    using int64_t = Int64;
    using view_t = UInt64;
    using uint64_t = UInt64;

    #region AgoraMediaBase.h

    /**
  * Audio routes.
  */
    public enum AudioRoute
    {
        /**
         * -1: The default audio route.
         */
        ROUTE_DEFAULT = -1,
        /**
         * The headset.
         */
        ROUTE_HEADSET,
        /**
         * The earpiece.
         */
        ROUTE_EARPIECE,
        /**
         * The headset with no microphone.
         */
        ROUTE_HEADSETNOMIC,
        /**
         * The speakerphone.
         */
        ROUTE_SPEAKERPHONE,
        /**
         * The loudspeaker.
         */
        ROUTE_LOUDSPEAKER,
        /**
         * The Bluetooth headset.
         */
        ROUTE_HEADSETBLUETOOTH,
        /**
         * The HDMI
         */
        ROUTE_HDMI,
        /**
         * The USB
         */
        ROUTE_USB
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


    /**
   * Bytes per sample
   */
    public enum BYTES_PER_SAMPLE
    {
        /**
        * two bytes per sample
        */
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
    }


    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        /** 0: Read-only mode: Users only read the
            agora::media::IAudioFrameObserver::AudioFrame data without modifying
            anything. For example, when users acquire data with the Agora SDK then push
            the RTMP streams. */
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        /** 2: Read and write mode: Users read the data from AudioFrame, modify it,
            and then play it. For example, when users have their own sound-effect
            processing module and do some voice pre-processing such as a voice change.
        */
        RAW_AUDIO_FRAME_OP_MODE_READ_WRITE = 2,
    };


    public enum MEDIA_SOURCE_TYPE
    {
        /** 
        * 0: The audio playback device.
        */
        AUDIO_PLAYOUT_SOURCE = 0,
        /** 
        * 1: Microphone.
        */
        AUDIO_RECORDING_SOURCE = 1,
        /**
        * 2: Video captured by primary camera.
        */
        PRIMARY_CAMERA_SOURCE = 2,
        /**
        * 3: Video captured by secondary camera.
        */
        SECONDARY_CAMERA_SOURCE = 3,
        /**
        * 4: Video captured by primary screen capturer.
        */
        PRIMARY_SCREEN_SOURCE = 4,
        /**
        * 5: Video captured by secondary screen capturer.
        */
        SECONDARY_SCREEN_SOURCE = 5,
        /**
        * 6: Video captured by custom video source.
        */
        CUSTOM_VIDEO_SOURCE = 6,
        /**
        * 7: Video for media player sharing.
        */
        MEDIA_PLAYER_SOURCE = 7,
        /**
        * 8: Video for png image.
        */
        RTC_IMAGE_PNG_SOURCE = 8,
        /**
        * 9: Video for jpeg image.
        */
        RTC_IMAGE_JPEG_SOURCE = 9,
        /**
        * 10: Video for gif image.
        */
        RTC_IMAGE_GIF_SOURCE = 10,
        /**
        * 11: Remote video received from network.
        */
        REMOTE_VIDEO_SOURCE = 11,
        /**
        * 12: Video for transcoded.
        */
        TRANSCODED_VIDEO_SOURCE = 12,
        /**
        * 100: unknown media source.
        */
        UNKNOWN_MEDIA_SOURCE = 100
    }

    //same in iagoraBase
    /**
  * The maximum metadata size.
  */
    //enum MAX_METADATA_SIZE_TYPE
    //{
    //    MAX_METADATA_SIZE_IN_BYTE = 1024
    //};

    /**
 * The definition of the PacketOptions struct, which contains infomation of the packet
 * in the RTP (Real-time Transport Protocal) header.
 */
    public class PacketOptions
    {
        /**
         * The timestamp of the packet.
         */
        public uint timestamp { set; get; }
        // Audio level indication.
        public byte audioLevelIndication { set; get; }


        public PacketOptions()
        {
            timestamp = 0;
            audioLevelIndication = 127;
        }

    };

    public enum AUDIO_PROCESSING_CHANNELS
    {
        AUDIO_PROCESSING_MONO = 1,
        AUDIO_PROCESSING_STEREO = 2,
    };

    public class AdvancedAudioOptions
    {
        public AUDIO_PROCESSING_CHANNELS audioProcessingChannels { set; get; }
        public AdvancedAudioOptions()
        {
            audioProcessingChannels = AUDIO_PROCESSING_CHANNELS.AUDIO_PROCESSING_MONO;
        }
    };

    /**
    * The detailed information of the incoming audio encoded frame.
    */
    public class AudioEncodedFrameInfo
    {
        /**
        * The send time of the packet.
        */
        public uint64_t sendTs;
        /**
        * The codec of the packet.
        */
        public Byte codec;

        public AudioEncodedFrameInfo()
        {
            sendTs = 0;
            codec = 0;
        }

    };

    /**
 * The detailed information of the incoming audio frame in the PCM format.
 */
    public struct AudioPcmFrame
    {
        /** The timestamp (ms) of the audio frame.
        */
        public UInt32 capture_timestamp;
        /** The number of samples per channel.
        */
        public UInt64 samples_per_channel_;
        /** The sample rate (Hz) of the audio data.
        */
        public int sample_rate_hz_;
        /** The channel number.
        */
        public UInt64 num_channels_;
        /** The number of bytes per sample.
        */
        public BYTES_PER_SAMPLE bytes_per_sample;
        /** The audio frame data. */
        public Int16[] data_;
    };

    /** Audio dual-mono output mode
    */
    public enum AUDIO_DUAL_MONO_MODE
    {
        /**< ChanLOut=ChanLin, ChanRout=ChanRin */
        AUDIO_DUAL_MONO_STEREO = 0,
        /**< ChanLOut=ChanRout=ChanLin */
        AUDIO_DUAL_MONO_L = 1,
        /**< ChanLOut=ChanRout=ChanRin */
        AUDIO_DUAL_MONO_R = 2,
        /**< ChanLout=ChanRout=(ChanLin+ChanRin)/2 */
        AUDIO_DUAL_MONO_MIX = 3
    };


    /**
    * Video pixel formats.
    */
    public enum VIDEO_PIXEL_FORMAT
    {
        /**
        * 0: Unknown format.
        */
        VIDEO_PIXEL_UNKNOWN = 0,
        /**
        * 1: I420.
        */
        VIDEO_PIXEL_I420 = 1,
        /**
        * 2: BGRA.
        */
        VIDEO_PIXEL_BGRA = 2,
        /**
        * 3: NV21.
        */
        VIDEO_PIXEL_NV21 = 3,
        /**
        * 4: RGBA.
        */
        VIDEO_PIXEL_RGBA = 4,
        /**
        * 8: NV12.
        */
        VIDEO_PIXEL_NV12 = 8,
        /** 
        * 10: GL_TEXTURE_2D
        */
        VIDEO_TEXTURE_2D = 10,
        /**
        * 11: GL_TEXTURE_OES
        */
        VIDEO_TEXTURE_OES = 11,
        /**
        * 16: I422.
        */
        VIDEO_PIXEL_I422 = 16,
    };

    /**
 * The video display mode.
 */
    public enum RENDER_MODE_TYPE
    {
        /**
        * 1: Uniformly scale the video until it fills the visible boundaries
        * (cropped). One dimension of the video may have clipped contents.
        */
        RENDER_MODE_HIDDEN = 1,
        /**
        * 2: Uniformly scale the video until one of its dimension fits the boundary
        * (zoomed to fit). Areas that are not filled due to the disparity in the
        * aspect ratio will be filled with black.
        */
        RENDER_MODE_FIT = 2,
        /**
        * @deprecated
        * 3: This mode is deprecated.
        */
        RENDER_MODE_ADAPTIVE = 3,
    };


    /**
   * The EGL context type.
   */
    public enum EGL_CONTEXT_TYPE
    {
        /**
        * 0: When using the OpenGL interface (javax.microedition.khronos.egl.*) defined by Khronos
        */
        EGL_CONTEXT10 = 0,
        /**
        * 0: When using the OpenGL interface (android.opengl.*) defined by Android
        */
        EGL_CONTEXT14 = 1,
    };

    /** The video buffer type. */
    public enum VIDEO_BUFFER_TYPE
    {
        /** 1: The video buffer in the format of raw data. */
        VIDEO_BUFFER_RAW_DATA = 1,
        /**
        * 2: The same as VIDEO_BUFFER_RAW_DATA.
        */
        VIDEO_BUFFER_ARRAY = 2,
        /**
        * 3: The video buffer in the format of texture.
        */
        VIDEO_BUFFER_TEXTURE = 3,
    }

    /** The external video frame.
   */
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

        /** The buffer type. See #VIDEO_BUFFER_TYPE
		 */
        public VIDEO_BUFFER_TYPE type { set; get; }

        /** The pixel format. See #VIDEO_PIXEL_FORMAT
		 */
        public VIDEO_PIXEL_FORMAT format { set; get; }

        /** The video buffer.
		 */
        public byte[] buffer { set; get; }

        /** Line spacing of the incoming video frame, which must be in pixels instead of bytes. For textures, it is the width of the texture.
		 */
        public int stride { set; get; }

        /** Height of the incoming video frame.
		 */
        public int height { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the left. The default value is 0.
		 */
        public int cropLeft { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the top. The default value is 0.
		 */
        public int cropTop { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the right. The default value is 0.
		 */
        public int cropRight { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the bottom. The default value is 0.
		 */
        public int cropBottom { set; get; }

        /** [Raw data related parameter] The clockwise rotation of the video frame. You can set the rotation angle as 0, 90, 180, or 270. The default value is 0.
		 */
        public int rotation { set; get; }

        /** Timestamp of the incoming video frame (ms). An incorrect timestamp results in frame loss or unsynchronized audio and video.
		 */
        public long timestamp { set; get; }

        /** 
        * [Texture-related parameter]
        * When using the OpenGL interface (javax.microedition.khronos.egl.*) defined by Khronos, set EGLContext to this field.
        * When using the OpenGL interface (android.opengl.*) defined by Android, set EGLContext to this field.
        */
        public byte[] eglContext { set; get; }
        /** 
        * [Texture related parameter] Texture ID used by the video frame.
        */
        public EGL_CONTEXT_TYPE eglType { set; get; }
        /** 
        * [Texture related parameter] Incoming 4 &times; 4 transformational matrix. The typical value is a unit matrix.
        */
        public int textureId { set; get; }
        /**
        * [Texture related parameter] The MetaData buffer.
        *  The default value is NULL
        */
        public byte[] metadata_buffer { set; get; }
        /**
        * [Texture related parameter] The MetaData size.
        *  The default value is 0
        */
        public int metadata_size { set; get; }
    }

    /** Video frame containing the Agora RTC SDK's encoded video data. */
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
            metadata_buffer = null;
            metadata_size = 0;
            sharedContext = IntPtr.Zero;
            textureId = 0;
            matrix = new float[16];
        }


        /** The video frame type: #VIDEO_PIXEL_FORMAT. */
        public VIDEO_PIXEL_FORMAT type;

        /** Width (pixel) of the video frame.*/
        public int width;

        /** Height (pixel) of the video frame. */
        public int height;

        /** Line span of the Y buffer within the YUV data. */
        public int yStride; //stride of Y data buffer

        /** Line span of the U buffer within the YUV data. */
        public int uStride; //stride of U data buffer

        /** Line span of the V buffer within the YUV data. */
        public int vStride; //stride of V data buffer

        /** Pointer to the Y buffer pointer within the YUV data. */
        public byte[] yBuffer; //Y data buffer

        public IntPtr yBufferPtr;

        /** Pointer to the U buffer pointer within the YUV data. */
        public byte[] uBuffer; //U data buffer

        public IntPtr uBufferPtr;

        /** Pointer to the V buffer pointer within the YUV data. */
        public byte[] vBuffer; //V data buffer

        public IntPtr vBufferPtr;

        /** Set the rotation of this frame before rendering the video. Supports 0, 90, 180, 270 degrees clockwise. */
        /** Set the rotation of this frame before rendering the video. Supports 0, 90, 180, 270 degrees clockwise. */
        public int rotation; // rotation of this frame (0, 90, 180, 270)

        /** The timestamp of the external audio frame. It is mandatory. You can use this parameter for the following purposes:
         * - Restore the order of the captured audio frame.
         * - Synchronize audio and video frames in video-related scenarios, including scenarios where external video sources are used.
         * @note This timestamp is for rendering the video stream, and not for capturing the video stream.
         */
        public long renderTimeMs;

        /** Reserved for future use. */
        public int avsync_type;

        /**
        * [Texture related parameter] The MetaData buffer.
        *  The default value is NULL
        */
        public byte[] metadata_buffer;
        /**
        * [Texture related parameter] The MetaData size.
        *  The default value is 0
        */
        public int metadata_size;

        /**
        * [Texture related parameter], egl context.
        */
        public IntPtr sharedContext;
        /**
         * [Texture related parameter], Texture ID used by the video frame.
         */
        public int textureId;
        /**
         * [Texture related parameter], Incoming 4 &times; 4 transformational matrix.
         */
        public float[] matrix;

    };

    public enum MEDIA_PLAYER_SOURCE_TYPE
    {
        /**
         * The real type of media player when use MEDIA_PLAYER_SOURCE_DEFAULT is decided by the
         * type of SDK package. It is full feature media player in full-featured SDK, or simple
         * media player in others.
         */
        MEDIA_PLAYER_SOURCE_DEFAULT,
        /**
         * Full featured media player is designed to support more codecs and media format, which
         * requires more package size than simple player. If you need this player enabled, you
         * might need to download a full-featured SDK.
         */
        MEDIA_PLAYER_SOURCE_FULL_FEATURED,
        /**
         * Simple media player with limit codec supported, which requires minimal package size
         * requirement and is enabled by default
         */
        MEDIA_PLAYER_SOURCE_SIMPLE,
    };

    [Flags]
    public enum VIDEO_MODULE_POSITION
    {
        POSITION_POST_CAPTURER = 1 << 0,
        POSITION_PRE_RENDERER = 1 << 1,
        POSITION_PRE_ENCODER = 1 << 2,
        POSITION_POST_FILTERS = 1 << 3,
    };

    public enum AUDIO_FRAME_TYPE
    {
        /** 0: PCM16. */
        FRAME_TYPE_PCM16 = 0, // PCM 16bit little endian
    }

    /** Definition of AudioFrame */
    public class AudioFrame
    {
        public AudioFrame()
        {
            type = AUDIO_FRAME_TYPE.FRAME_TYPE_PCM16;
            samplesPerChannel = 0;
            bytesPerSample = BYTES_PER_SAMPLE.TWO_BYTES_PER_SAMPLE;
            channels = 0;
            samplesPerSec = 0;
            buffer = new byte[0];
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
            this.buffer = buffer;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
        }

        /** The type of the audio frame. See #AUDIO_FRAME_TYPE
		 */
        public AUDIO_FRAME_TYPE type { set; get; }

        /** The number of samples per channel in the audio frame.
		 */
        public int samplesPerChannel { set; get; } //number of samples for each channel in this frame

        /**The number of bytes per audio sample, which is usually 16-bit (2-byte).
		 */
        public BYTES_PER_SAMPLE bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

        /** The number of audio channels.
		 - 1: Mono
		 - 2: Stereo (the data is interleaved)
		 */
        public int channels { set; get; } //number of channels (data are interleaved if stereo)

        /** The sample rate.
		 */
        public int samplesPerSec { set; get; } //sampling rate

        /** The data buffer of the audio frame. When the audio frame uses a stereo channel, the data buffer is interleaved.
		 The size of the data buffer is as follows: `buffer` = `samples` × `channels` × `bytesPerSample`.
		 */
        public byte[] buffer { set; get; } //data buffer

        public IntPtr bufferPtr { set; get; }

        /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
		 - Restore the order of the captured audio frame.
		 - Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
		 */
        public long renderTimeMs { set; get; }

        /** Reserved parameter.
		 */
        public int avsync_type { set; get; }
    }


    public struct AudioSpectrumData
    {

        public float[] audioSpectrumData;
        /**
        * The data length of audio spectrum data.
        */
        public int dataLength;
    };



    public struct UserAudioSpectrumInfo
    {
        /**
        * User ID of the speaker.
        */
        public uint uid;
        /**
        * The audio spectrum data of audio.
        */
        public AudioSpectrumData spectrumData;
    };


    /**
   * The frame position of the video observer.
   */
    [Flags]
    public enum VIDEO_OBSERVER_POSITION
    {
        /**USER_OFFLINE_REASON_TYPE
     * 1: The post-capturer position, which corresponds to the video data in the onCaptureVideoFrame callback.
     */
        POSITION_POST_CAPTURER = 1 << 0,

        /**
     * 2: The pre-renderer position, which corresponds to the video data in the onRenderVideoFrame callback.
     */
        POSITION_PRE_RENDERER = 1 << 1,

        /**
     * 4: The pre-encoder position, which corresponds to the video data in the onPreEncodeVideoFrame callback.
     */
        POSITION_PRE_ENCODER = 1 << 2,
    };



    /** Definition of contentinspect
*/
    //#define MAX_CONTENT_INSPECT_MODULE_COUNT 32
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
        /**
        * (Default) content inspect type invalid
        */
        CONTENT_INSPECT_INVALIDE = 0,
        /**
        * Content inspect type moderation
        */
        CONTENT_INSPECT_MODERATION = 1,
        /**
        * Content inspect type supervise
        */
        CONTENT_INSPECT_SUPERVISE = 2
    };

    public class ContentInspectModule
    {
        /**
        * The content inspect module type.
        */
        public CONTENT_INSPECT_TYPE type;
        /**The content inspect frequency, default is 0 second.
        * the frequency <= 0 is invalid.
        */
        public uint frequency;
    };

    /** Definition of ContentInspectConfig.
*/
    public class ContentInspectConfig
    {
        public ContentInspectConfig()
        {
            enable = false;
            DeviceWork = false;
            CloudWork = true;
            DeviceworkType = CONTENT_INSPECT_DEVICE_TYPE.CONTENT_INSPECT_DEVICE_INVALID;
            extraInfo = null;
            moduleCount = 0;
        }

        /** enable content isnpect function*/
        public bool enable { set; get; }

        /** jh on device.*/
        public bool DeviceWork { set; get; }

        /** jh on cloud.*/
        public bool CloudWork { set; get; }

        /**the type of jh on device.*/
        public CONTENT_INSPECT_DEVICE_TYPE DeviceworkType { set; get; }

        public string extraInfo { set; get; }

        /**The content inspect modules, max length of modules is 32.
        * the content(snapshot of send video stream, image) can be used to max of 32 types functions.
        */
        public ContentInspectModule[] modules { set; get; }

        /**The content inspect module count.
        */
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

        public string channel;
        public uint uid;
        public string filePath;
    }


    /**
    * The external video source type.
    */
    public enum EXTERNAL_VIDEO_SOURCE_TYPE
    {
        /**
        * 0: non-encoded video frame.
        */
        VIDEO_FRAME = 0,
        /**
        * 1: encoded video frame.
        */
        ENCODED_VIDEO_FRAME,
    };

    #endregion
}
