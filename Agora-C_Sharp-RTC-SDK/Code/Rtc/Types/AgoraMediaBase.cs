using System;
namespace Agora.Rtc
{
    using uint8_t = Byte;
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
        ///
        /// <summary>
        /// The pixel format. See VIDEO_PIXEL_FORMAT.
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
        /// For YUV data, the line span of the Y buffer; for RGBA data, the total data length. When dealing with video data, it is necessary to process the offset between each line of pixel data based on this parameter, otherwise it may result in image distortion.
        /// </summary>
        ///
        public int yStride;

        ///
        /// <summary>
        /// For YUV data, the line span of the U buffer; for RGBA data, the value is 0. When dealing with video data, it is necessary to process the offset between each line of pixel data based on this parameter, otherwise it may result in image distortion.
        /// </summary>
        ///
        public int uStride;

        ///
        /// <summary>
        /// For YUV data, the line span of the V buffer; for RGBA data, the value is 0. When dealing with video data, it is necessary to process the offset between each line of pixel data based on this parameter, otherwise it may result in image distortion.
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
        /// The Unix timestamp (ms) when the video frame is rendered. This timestamp can be used to guide the rendering of the video frame. This parameter is required.
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
        /// This parameter only applies to video data in Windows Texture format. It represents a pointer to an object of type ID3D11Texture2D, which is used by a video frame.
        /// </summary>
        ///
        public IntPtr d3d11Texture2d;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Incoming 4 × 4 transformational matrix. The typical value is a unit matrix.
        /// </summary>
        ///
        public float[] matrix;

        ///
        /// <summary>
        /// The alpha channel data output by using portrait segmentation algorithm. This data matches the size of the video frame, with each pixel value ranging from [0,255], where 0 represents the background and 255 represents the foreground (portrait). By setting this parameter, you can render the video background into various effects, such as transparent, solid color, image, video, etc.
        ///  In custom video rendering scenarios, ensure that both the video frame and alphaBuffer are of the Full Range type; other types may cause abnormal alpha data rendering.
        ///  Make sure that alphaBuffer is exactly the same size as the video frame (width × height), otherwise it may cause the app to crash.
        /// </summary>
        ///
        public byte[] alphaBuffer;

        ///
        /// @ignore
        ///
        public IntPtr alphaBufferPtr;

        ///
        /// <summary>
        /// When the video frame contains alpha channel data, it represents the relative position of alphaBuffer and the video frame. See ALPHA_STITCH_MODE.
        /// </summary>
        ///
        public ALPHA_STITCH_MODE alphaStitchMode;

        ///
        /// <summary>
        /// The meta information in the video frame. To use this parameter, contact.
        /// </summary>
        ///
        public IVideoFrameMetaInfo metaInfo;

        ///
        /// @ignore
        ///
        public Hdr10MetadataInfo hdr10MetadataInfo;

        ///
        /// <summary>
        /// By default, the color space properties of video frames will apply the Full Range and BT.709 standard configurations. You can configure the settings according your needs for custom video capturing and rendering.
        /// </summary>
        ///
        public ColorSpace colorSpace;
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
            this.alphaStitchMode = ALPHA_STITCH_MODE.NO_ALPHA_STITCH;
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
        ///
        /// <summary>
        /// The type of the audio frame. See AUDIO_FRAME_TYPE.
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
        /// The number of bytes per sample. For PCM, this parameter is generally set to 16 bits (2 bytes).
        /// </summary>
        ///
        public BYTES_PER_SAMPLE bytesPerSample;

        ///
        /// <summary>
        /// The number of audio channels (the data are interleaved if it is stereo).
        ///  1: Mono.
        ///  2: Stereo.
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
        /// The timestamp (ms) of the external audio frame. You can use this timestamp to restore the order of the captured audio frame, and synchronize audio and video frames in video scenarios, including scenarios where external video sources are used.
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
        /// @ignore
        ///
        public long presentationMs;

        ///
        /// @ignore
        ///
        public int audioTrackNumber;

        ///
        /// @ignore
        ///
        public uint rtpTimestamp;
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
            this.rtpTimestamp = 0;
            this.RawBuffer = new byte[0];
        }

        public AudioFrame(AUDIO_FRAME_TYPE type, int samplesPerChannel, BYTES_PER_SAMPLE bytesPerSample, int channels, int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type, long presentationMs, int audioTrackNumber, uint rtpTimestamp)
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
            this.rtpTimestamp = rtpTimestamp;
        }

        #endregion terra AudioFrame_Constructor
    }
}