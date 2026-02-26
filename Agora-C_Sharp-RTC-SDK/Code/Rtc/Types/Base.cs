using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Raw data callback mode.
    /// </summary>
    ///
    public enum OBSERVER_MODE
    {
        ///
        /// <summary>
        /// Callback in raw data mode.
        /// </summary>
        ///
        RAW_DATA,

        INTPTR
    }

    public struct VideoFrameBufferConfig
    {
        public VIDEO_SOURCE_TYPE type;

        public uint id;

        public string key;
    }

    ///
    /// @ignore
    ///
    public class IrisVideoFrame
    {
        ///
        /// @ignore
        ///
        public VIDEO_OBSERVER_FRAME_TYPE type;
        ///
        /// @ignore
        ///
        public int width;
        ///
        /// @ignore
        ///
        public int height;
        ///
        /// @ignore
        ///
        public int yStride;
        ///
        /// @ignore
        ///
        public int uStride;
        ///
        /// @ignore
        ///
        public int vStride;
        ///
        /// @ignore
        ///
        public IntPtr yBuffer;
        ///
        /// @ignore
        ///
        public IntPtr uBuffer;
        ///
        /// @ignore
        ///
        public IntPtr vBuffer;
        ///
        /// @ignore
        ///
        public uint y_buffer_length;
        ///
        /// @ignore
        ///
        public uint u_buffer_length;
        ///
        /// @ignore
        ///
        public uint v_buffer_length;
        ///
        /// @ignore
        ///
        public int rotation;
        ///
        /// @ignore
        ///
        public Int64 renderTimeMs;
        ///
        /// @ignore
        ///
        public int avsync_type;
        ///
        /// @ignore
        ///
        public IntPtr metadata_buffer;
        ///
        /// @ignore
        ///
        public int metadata_size;
        ///
        /// @ignore
        ///
        public IntPtr sharedContext;
        ///
        /// @ignore
        ///
        public int textureId;
        ///
        /// @ignore
        ///
        public float[] matrix;
        ///
        /// @ignore
        ///
        public IntPtr alphaBuffer;
        ///
        /// @ignore
        ///
        public uint alpha_buffer_length;

        ///
        /// @ignore
        ///
        public ALPHA_STITCH_MODE alphaStitchMode;

        public Dictionary<string, string> metaInfo;

        ///
        /// @ignore
        ///
        public Hdr10MetadataInfo hdr10MetadataInfo;

        ///
        /// @ignore
        ///
        public ColorSpace colorSpace;
    }

    ///
    /// <summary>
    /// Raw video data types.
    /// </summary>
    ///
    public enum VIDEO_OBSERVER_FRAME_TYPE
    {
        ///
        /// <summary>
        /// Raw video pixel format.
        /// </summary>
        ///
        FRAME_TYPE_DEFAULT = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_DEFAULT,

        ///
        /// <summary>
        /// Video data in YUV420 format.
        /// </summary>
        ///
        FRAME_TYPE_YUV420 = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_I420,

        ///
        /// @ignore
        ///
        FRAME_TYPE_BGRA = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_BGRA,

        ///
        /// @ignore
        ///
        FRAME_TYPE_NV21 = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_NV21,

        ///
        /// <summary>
        /// Video data in RGBA format.
        /// </summary>
        ///
        FRAME_TYPE_RGBA = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_RGBA,

        ///
        /// @ignore
        ///
        FRAME_TYPE_NV12 = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_NV12,

        ///
        /// @ignore
        ///
        FRAME_TYPE_TEXTURE_2D = VIDEO_PIXEL_FORMAT.VIDEO_TEXTURE_2D,

        ///
        /// @ignore
        ///
        FRAME_TYPE_TEXTURE_OES = VIDEO_PIXEL_FORMAT.VIDEO_TEXTURE_OES,

        ///
        /// @ignore
        ///
        FRAME_TYPE_CVPIXEL_NV12 = VIDEO_PIXEL_FORMAT.VIDEO_CVPIXEL_NV12,

        ///
        /// @ignore
        ///
        FRAME_TYPE_CVPIXEL_I420 = VIDEO_PIXEL_FORMAT.VIDEO_CVPIXEL_I420,

        ///
        /// @ignore
        ///
        FRAME_TYPE_CVPIXEL_BGRA = VIDEO_PIXEL_FORMAT.VIDEO_CVPIXEL_BGRA,

        ///
        /// <summary>
        /// Video data in YUV422 format.
        /// </summary>
        ///
        FRAME_TYPE_YUV422 = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_I422,

        ///
        /// @ignore
        ///
        FRAME_TYPE_TEXTURE_ID3D11TEXTURE2D = VIDEO_PIXEL_FORMAT.VIDEO_TEXTURE_ID3D11TEXTURE2D,
    }

    internal class IrisAudioSpectrumData
    {
        public ulong audioSpectrumData;
        public int dataLength;

        public IrisAudioSpectrumData()
        {
            audioSpectrumData = 0;
            dataLength = 0;
        }

        public void GenerateAudioSpectrumData(ref AudioSpectrumData audioSpectrum)
        {
            audioSpectrum.audioSpectrumData = new float[this.dataLength];
            Marshal.Copy((IntPtr)this.audioSpectrumData, audioSpectrum.audioSpectrumData, 0, dataLength);
            audioSpectrum.dataLength = this.dataLength;
        }
    }

    internal class IrisUserAudioSpectrumInfo
    {
        public IrisUserAudioSpectrumInfo()
        {
            uid = 0;
            spectrumData = null;
        }

        public uint uid;
        public IrisAudioSpectrumData spectrumData;

        public void GenerateUserAudioSpectrumInfo(ref UserAudioSpectrumInfo info)
        {
            info.uid = this.uid;
            info.spectrumData = new AudioSpectrumData();
            this.spectrumData.GenerateAudioSpectrumData(ref info.spectrumData);
        }
    }
}