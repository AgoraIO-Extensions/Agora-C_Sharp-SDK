//  AgoraMediaBase.cs
//
//  Created by YuGuo Chen on October 11, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
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
    
    public enum AUDIO_FRAME_TYPE
    {
        /** 0: PCM16. */
        FRAME_TYPE_PCM16 = 0, // PCM 16bit little endian
    }

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

    /** The video frame type. */
    public enum VIDEO_FRAME_TYPE
    {
        /** 0: YUV420. */
        FRAME_TYPE_YUV420 = 0, // YUV 420 format

        /** * 1: YUV422. */
        FRAME_TYPE_YUV422 = 1, // YUV 422 format

        /** * 2: RGBA */
        FRAME_TYPE_RGBA = 2, // RGBA format

        /** * 2: BGRA */
        FRAME_TYPE_BGRA = 3, // BGRA format
    }

    public enum IRIS_BYTES_PER_SAMPLE 
    {
        IRIS_TWO_BYTES_PER_SAMPLE = 2,
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisAudioFrame
    {
        internal AUDIO_FRAME_TYPE type;
        internal int samples;
        internal int bytes_per_sample;
        internal int channels;
        internal int samples_per_sec;
        internal IntPtr buffer;
        internal uint buffer_length;
        internal long render_time_ms;
        internal int av_sync_type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisVideoFrame
    {
        internal VIDEO_FRAME_TYPE type;
        internal int width;
        internal int height;
        internal int y_stride;
        internal int u_stride;
        internal int v_stride;
        internal IntPtr y_buffer;
        internal IntPtr u_buffer;
        internal IntPtr v_buffer;
        internal uint y_buffer_length;
        internal uint u_buffer_length;
        internal uint v_buffer_length;
        internal int rotation;
        internal long render_time_ms;
        internal int av_sync_type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisWindowCollection
    {
        internal IntPtr windows;
        internal uint length;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisDisplayCollection
    {
        internal IntPtr displays;
        internal int length;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisWindow
    {
        internal ulong id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string name;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string owner_name;

        internal IrisRect bounds;
        internal IrisRect work_area;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisDisplay
    {
        internal uint id;
        internal float scale;
        internal IrisRect bounds;
        internal IrisRect work_area;
        internal int rotation;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRect
    {
        internal double x;
        internal double y;
        internal double width;
        internal double height;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisEncodedVideoFrameInfo
    {
        internal int codecType;
        internal int width;
        internal int height;
        internal int framesPerSecond;
        internal int frameType;
        internal int rotation;
        internal int trackId;
        internal Int64 renderTimeMs;
        internal UInt64 internalSendTs;
        internal uint uid;
        internal int streamType;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisAudioPcmFrame {
        internal UInt32 capture_timestamp;
        internal UInt16 samples_per_channel_;
        internal int sample_rate_hz_;
        internal IRIS_BYTES_PER_SAMPLE bytes_per_sample;
        internal UInt16 num_channels_;
        internal Int16[] data_;
    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

    /**
    * Bytes per sample
    */
    public enum BYTES_PER_SAMPLE {
        /**
        * two bytes per sample
        */
        TWO_BYTES_PER_SAMPLE = 2,
    };

    public class AudioParameters {
        public AudioParameters() { }
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

    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE {
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

    /**
    * The maximum metadata size.
    */
    public enum MAX_METADATA_SIZE_TYPE {
        MAX_METADATA_SIZE_IN_BYTE = 1024
    };

    /**
    * Video pixel formats.
    */
    public enum VIDEO_PIXEL_FORMAT {
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
    public enum RENDER_MODE_TYPE {
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
    public enum EGL_CONTEXT_TYPE {
        /**
        * 0: When using the OpenGL interface (javax.microedition.khronos.egl.*) defined by Khronos
        */
        EGL_CONTEXT10 = 0,
        /**
        * 0: When using the OpenGL interface (android.opengl.*) defined by Android
        */
        EGL_CONTEXT14 = 1,
    };

    /** The external video frame.
	 */
    public class ExternalVideoFrame
    {
        public ExternalVideoFrame()
        {
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
    };

    /** Definition of AudioFrame */
    public class AudioFrame
    {
        public AudioFrame()
        {
        }

        public AudioFrame(AUDIO_FRAME_TYPE type, int samplesPerChannel, int bytesPerSample, int channels, int samplesPerSec,
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
        public int bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

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
   
    /**
    * The detailed information of the incoming audio frame in the PCM format.
    */
    public struct AudioPcmFrame {
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
}