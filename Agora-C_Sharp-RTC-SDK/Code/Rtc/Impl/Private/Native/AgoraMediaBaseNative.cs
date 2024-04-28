using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using view_t = System.UInt64;
namespace Agora.Rtc
{

    // use for raw data
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
    // internal struct IrisCVideoFrameBufferNative
    //{
    //    internal int type;
    //    internal IntPtr OnVideoFrameReceived;
    //    internal int bytes_per_row_alignment;
    //}

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

        internal uint observed_frame_position;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcVideoFrameConfigS
    {
        /// int value of agora::rtc::VIDEO_SOURCE_TYPE
        internal int video_source_type;

        /// int value of agora::media::base::VIDEO_PIXEL_FORMAT
        internal int video_frame_format;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string userAccount;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string channelId;

        internal int video_view_setup_mode;

        internal uint observed_frame_position;
    }

    internal class ThumbImageBufferInternal
    {
        #region terra ThumbImageBufferInternal_List
        public IntPtr buffer;
        public uint length;
        public uint width;
        public uint height;
        #endregion terra ThumbImageBufferInternal_List

        public ThumbImageBufferInternal()
        {
        }

        public ThumbImageBuffer GenerateThumbImageBuffer()
        {
            ThumbImageBuffer imageBuffer = new ThumbImageBuffer();
            #region terra ThumbImageBufferInternal_Generate
            byte[] thumbBuffer = new byte[length];
            if (length > 0)
            {
                Marshal.Copy((this.buffer), thumbBuffer, 0, (int)length);
            }
            imageBuffer.buffer = thumbBuffer;
            imageBuffer.length = this.length;
            imageBuffer.width = this.width;
            imageBuffer.height = this.height;
            #endregion terra ThumbImageBufferInternal_Generate
            return imageBuffer;
        }
    };

    internal class ScreenCaptureSourceInfoInternal
    {
        #region terra ScreenCaptureSourceInfoInternal_List
        public ScreenCaptureSourceType type;
        public view_t sourceId;
        public string sourceName;
        public ThumbImageBufferInternal thumbImage;
        public ThumbImageBufferInternal iconImage;
        public string processPath;
        public string sourceTitle;
        public bool primaryMonitor;
        public bool isOccluded;
        public Rectangle position;
        public bool minimizeWindow;
        public view_t sourceDisplayId;
        #endregion terra ScreenCaptureSourceInfoInternal_List

        public ScreenCaptureSourceInfoInternal()
        {
        }

        public ScreenCaptureSourceInfo GenerateScreenCaptureSourceInfo()
        {
            var screenCaptureSourceInfo = new ScreenCaptureSourceInfo();

            #region terra ScreenCaptureSourceInfoInternal_Generate
            screenCaptureSourceInfo.type = this.type;
            screenCaptureSourceInfo.sourceId = this.sourceId;
            screenCaptureSourceInfo.sourceName = this.sourceName;
            if (this.thumbImage != null)
            {
                screenCaptureSourceInfo.thumbImage = this.thumbImage.GenerateThumbImageBuffer();
            }
            else
            {
                screenCaptureSourceInfo.thumbImage = new ThumbImageBuffer(new byte[0], 0, 0, 0);
            }
            if (this.iconImage != null)
            {
                screenCaptureSourceInfo.iconImage = this.iconImage.GenerateThumbImageBuffer();
            }
            else
            {
                screenCaptureSourceInfo.iconImage = new ThumbImageBuffer(new byte[0], 0, 0, 0);
            }
            screenCaptureSourceInfo.processPath = this.processPath;
            screenCaptureSourceInfo.sourceTitle = this.sourceTitle;
            screenCaptureSourceInfo.primaryMonitor = this.primaryMonitor;
            screenCaptureSourceInfo.isOccluded = this.isOccluded;
            screenCaptureSourceInfo.position = this.position;
            screenCaptureSourceInfo.minimizeWindow = this.minimizeWindow;
            screenCaptureSourceInfo.sourceDisplayId = this.sourceDisplayId;
            #endregion terra ScreenCaptureSourceInfoInternal_Generate
            return screenCaptureSourceInfo;
        }
    };
}