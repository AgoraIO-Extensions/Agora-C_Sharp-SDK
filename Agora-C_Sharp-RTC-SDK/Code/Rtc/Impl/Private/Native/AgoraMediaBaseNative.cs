using System;
using System.Runtime.InteropServices;

namespace Agora.Rtc
{
    using view_t = Int64;

    //use for raw data
    [StructLayout(LayoutKind.Sequential)]
    public struct IrisCVideoFrame
    {
        /// The agora::media::base::VideoFrame.type, but convert it to int type
        public int type;
        public int width;
        public int height;
        public int yStride;
        public int uStride;
        public int vStride;
        public IntPtr yBuffer;
        public IntPtr uBuffer;
        public IntPtr vBuffer;
        public int rotation;
        public Int64 renderTimeMs;
        public int avsync_type;
        public IntPtr metadata_buffer;
        public int metadata_size;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] matrix;
        public IntPtr alphaBuffer;
    }


    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisCVideoFrameBufferNative
    //{
    //    internal int type;
    //    internal IntPtr OnVideoFrameReceived;
    //    internal int bytes_per_row_alignment;
    //}

    //use for videoFrameObserver json parse
    //workaround, must be public, so can parse from a json string
    [StructLayout(LayoutKind.Sequential)]
    public struct IrisVideoFrame
    {
        public VIDEO_OBSERVER_FRAME_TYPE type;
        public int width;
        public int height;
        public int yStride;
        public int uStride;
        public int vStride;
        public IntPtr yBuffer;
        public IntPtr uBuffer;
        public IntPtr vBuffer;
        public uint y_buffer_length;
        public uint u_buffer_length;
        public uint v_buffer_length;
        public int rotation;
        public Int64 renderTimeMs;
        public int avsync_type;
        public IntPtr metadata_buffer;
        public int metadata_size;
        public IntPtr sharedContext;
        public int textureId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public float[] matrix;
        public IntPtr alphaBuffer;
        public uint alpha_buffer_length;
    }




    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcVideoFrameConfig
    {
        /// int value of agora::rtc::VIDEO_SOURCE_TYPE
        internal int video_source_type;

        /// int value of agora::media::base::VIDEO_PIXEL_FORMAT
        internal int video_frame_format;
        internal uint uid;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string channelId;

        internal int video_view_setup_mode;
    }




    internal class ThumbImageBufferInternal
    {
        public uint length;
        public uint width;
        public uint height;

        public UInt64 buffer;

        public ThumbImageBufferInternal()
        {
            buffer = 0;
            length = 0;
            width = 0;
            height = 0;
        }
    };

    internal class ScreenCaptureSourceInfoInternal
    {
        public ScreenCaptureSourceType type;
        public view_t sourceId;
#if  UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
#else
        public view_t sourceDisplayId;
#endif
        public string sourceName;
        public ThumbImageBufferInternal thumbImage;
        public ThumbImageBufferInternal iconImage;

        public string processPath;
        public string sourceTitle;
        public bool primaryMonitor;
        public bool isOccluded;

        public ScreenCaptureSourceInfoInternal()
        {
            type = ScreenCaptureSourceType.ScreenCaptureSourceType_Unknown;
            sourceId = 0;
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
#else
            sourceDisplayId = -2;
#endif

            sourceName = "";
            processPath = "";
            sourceTitle = "";
            primaryMonitor = false;
            isOccluded = false;
            thumbImage = new ThumbImageBufferInternal();
            iconImage = new ThumbImageBufferInternal();
        }
    };
}