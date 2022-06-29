using System;

namespace Agora.Rtc
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
        ROUTE_USB,
        /**
         * The DISPLAYPORT
         */
        ROUTE_DISPLAYPORT,
        /**
         * The AIRPLAY
         */
        ROUTE_AIRPLAY
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
        * 0: Default format.
        */
        VIDEO_PIXEL_DEFAULT = 0,
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
        /*
        12: pixel format for iOS CVPixelBuffer NV12
        */
        VIDEO_CVPIXEL_NV12 = 12,
        /*
        13: pixel format for iOS CVPixelBuffer I420
        */
        VIDEO_CVPIXEL_I420 = 13,
        /*
        14: pixel format for iOS CVPixelBuffer BGRA
        */
        VIDEO_CVPIXEL_BGRA = 14,
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
        [Obsolete]
        RENDER_MODE_ADAPTIVE = 3,
    };


    /**
 * The video source type
 */
    namespace Media.Base
    {
        enum VIDEO_SOURCE_TYPE
        {
            /**
             * 0: the video frame comes from the front camera
             */
            CAMERA_SOURCE_FRONT = 0,
            /**
             * 1: the video frame comes from the back camera
             */
            CAMERA_SOURCE_BACK = 1,
            /**
             * 1: the video frame source is unsepcified
             */
            VIDEO_SOURCE_UNSPECIFIED = 2,
        };
    }

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
        public IntPtr metadata_buffer;
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


        /**
        *  Portrait Segmentation meta buffer, dimension of which is the same as VideoFrame.
        *  Pixl value is between 0-255, 0 represents totally background, 255 represents totally foreground.
        *  The default value is NULL
        */
        public byte[] alphaBuffer;
        public IntPtr alphaBufferPtr;
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

    public enum MAX_HANDLE_TIME_CNT
    {
        MAX_HANDLE_TIME_CNT = 10
    };

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
        public UInt64 buffer { set; get; } //data buffer

        public IntPtr bufferPtr { set; get; }

        public byte[] RawBuffer { set; get; }

        /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
		 - Restore the order of the captured audio frame.
		 - Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
		 */
        public long renderTimeMs { set; get; }

        /** Reserved parameter.
		 */
        public int avsync_type { set; get; }
    }

    [Flags]
    public enum AUDIO_FRAME_POSITION
    {
        AUDIO_FRAME_POSITION_NONE = 0x0000,
        /** The position for observing the playback audio of all remote users after mixing
         */
        AUDIO_FRAME_POSITION_PLAYBACK = 0x0001,
        /** The position for observing the recorded audio of the local user
         */
        AUDIO_FRAME_POSITION_RECORD = 0x0002,
        /** The position for observing the mixed audio of the local user and all remote users
         */
        AUDIO_FRAME_POSITION_MIXED = 0x0004,
        /** The position for observing the audio of a single remote user before mixing
         */
        AUDIO_FRAME_POSITION_BEFORE_MIXING = 0x0008,
    };


    public class AudioParams
    {
        /** The audio sample rate (Hz), which can be set as one of the following values:

         - `8000`
         - `16000` (Default)
         - `32000`
         - `44100 `
         - `48000`
         */
        public int sample_rate { set; get; }

        /* The number of audio channels, which can be set as either of the following values:

         - `1`: Mono (Default)
         - `2`: Stereo
         */
        public int channels { set; get; }

        /* The use mode of the audio data. See AgoraAudioRawFrameOperationMode.
         */
        public RAW_AUDIO_FRAME_OP_MODE_TYPE mode { set; get; }

        /** The number of samples. For example, set it as 1024 for RTMP or RTMPS
         streaming.
         */
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
        /**
        * (Default) content inspect type invalid
        */
        CONTENT_INSPECT_INVALID = 0,
        /**
         * Content inspect type moderation
         */
        CONTENT_INSPECT_MODERATION = 1,
        /**
         * Content inspect type supervise
         */
        CONTENT_INSPECT_SUPERVISION = 2
    };

    public enum CONTENT_INSPECT_WORK_TYPE
    {
        /**
         * video moderation on device
         */
        CONTENT_INSPECT_WORK_DEVICE = 0,
        /**
         * video moderation on cloud
         */
        CONTENT_INSPECT_WORK_CLOUD = 1,
        /**
         * video moderation on cloud and device
         */
        CONTENT_INSPECT_WORK_DEVICE_CLOUD = 2
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
        public uint interval;

        public ContentInspectModule()
        {
            type = CONTENT_INSPECT_TYPE.CONTENT_INSPECT_INVALID;
            interval = 0;
        }

    };

    /** Definition of ContentInspectConfig.
*/
    public class ContentInspectConfig
    {
        /**The content inspect modules, max length of modules is 32.
         * the content(snapshot of send video stream, image) can be used to max of 32 types functions.
         */
        public ContentInspectModule[] modules { set; get; }
        /**The content inspect module count.
         */
        public int moduleCount { set; get; }

        public ContentInspectConfig()
        {
            modules = null;
            moduleCount = 0;
        }

    };


    //public class SnapShotConfig
    //{
    //    public SnapShotConfig()
    //    {
    //        channel = null;
    //        uid = 0;
    //        filePath = null;
    //    }

    //    public string channel;
    //    public uint uid;
    //    public string filePath;
    //}


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

    /**
    * The format of the recording file.
    *
    * @since v3.5.2
    */
    public enum MediaRecorderContainerFormat
    {
        /**
         * 1: (Default) MP4.
         */
        FORMAT_MP4 = 1,
    };

    /**
    * The recording content.
    *
    * @since v3.5.2
    */
    public enum MediaRecorderStreamType
    {
        /**
         * Only audio.
         */
        STREAM_TYPE_AUDIO = 0x01,
        /**
         * Only video.
         */
        STREAM_TYPE_VIDEO = 0x02,
        /**
         * (Default) Audio and video.
         */
        STREAM_TYPE_BOTH = STREAM_TYPE_AUDIO | STREAM_TYPE_VIDEO,
    };

    /**
 * The current recording state.
 *
 * @since v3.5.2
 */
    public enum RecorderState
    {
        /**
         * -1: An error occurs during the recording. See RecorderErrorCode for the reason.
         */
        RECORDER_STATE_ERROR = -1,
        /**
         * 2: The audio and video recording is started.
         */
        RECORDER_STATE_START = 2,
        /**
         * 3: The audio and video recording is stopped.
         */
        RECORDER_STATE_STOP = 3,
    };

    /**
    * The reason for the state change
    *
    * @since v3.5.2
    */
    public enum RecorderErrorCode
    {
        /**
         * 0: No error occurs.
         */
        RECORDER_ERROR_NONE = 0,
        /**
         * 1: The SDK fails to write the recorded data to a file.
         */
        RECORDER_ERROR_WRITE_FAILED = 1,
        /**
         * 2: The SDK does not detect audio and video streams to be recorded, or audio and video streams are interrupted for more than five seconds during recording.
         */
        RECORDER_ERROR_NO_STREAM = 2,
        /**
         * 3: The recording duration exceeds the upper limit.
         */
        RECORDER_ERROR_OVER_MAX_DURATION = 3,
        /**
         * 4: The recording configuration changes.
         */
        RECORDER_ERROR_CONFIG_CHANGED = 4,
    };

    /**
    * Configurations for the local audio and video recording.
    *
    * @since v3.5.2
    */
    public class MediaRecorderConfiguration
    {
        /**
         * The absolute path (including the filename extensions) of the recording file.
         * For example, `C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.mp4` on Windows,
         * `/App Sandbox/Library/Caches/example.mp4` on iOS, `/Library/Logs/example.mp4` on macOS, and
         * `/storage/emulated/0/Android/data/<package name>/files/example.mp4` on Android.
         *
         * @note Ensure that the specified path exists and is writable.
         */
        public string storagePath { set; get; }
        /**
         * The format of the recording file. See \ref agora::rtc::MediaRecorderContainerFormat "MediaRecorderContainerFormat".
         */
        public MediaRecorderContainerFormat containerFormat { set; get; }
        /**
         * The recording content. See \ref agora::rtc::MediaRecorderStreamType "MediaRecorderStreamType".
         */
        public MediaRecorderStreamType streamType { set; get; }
        /**
         * The maximum recording duration, in milliseconds. The default value is 120000.
         */
        public int maxDurationMs { set; get; }
        /**
         * The interval (ms) of updating the recording information. The value range is
         * [1000,10000]. Based on the set value of `recorderInfoUpdateInterval`, the
         * SDK triggers the \ref IMediaRecorderObserver::onRecorderInfoUpdated "onRecorderInfoUpdated"
         * callback to report the updated recording information.
         */
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
        /**
         * The absolute path of the recording file.
         */
        public string fileName { set; get; }
        /**
         * The recording duration, in milliseconds.
         */
        public uint durationMs { set; get; }
        /**
         * The size in bytes of the recording file.
         */
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
