using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The mode for receiving data.
    /// </summary>
    ///
    public enum OBSERVER_MODE
    {
        RAW_DATA,

        INTPTR
    }

    public struct VideoFrameBufferConfig
    {
        public VIDEO_SOURCE_TYPE type;

        public uint id;

        public string key;
    }

    internal class AudioFrameInternal
    {
        internal AudioFrameInternal(AudioFrame audioFrame)
        {
            this.type = audioFrame.type;
            this.samplesPerChannel = audioFrame.samplesPerChannel;
            this.bytesPerSample = audioFrame.bytesPerSample;
            this.channels = audioFrame.channels;
            this.samplesPerSec = audioFrame.samplesPerSec;
            this.buffer = audioFrame.buffer;
            this.renderTimeMs = audioFrame.renderTimeMs;
            this.avsync_type = audioFrame.avsync_type;
        }

        public AUDIO_FRAME_TYPE type;
        public int samplesPerChannel;
        public BYTES_PER_SAMPLE bytesPerSample;
        public int channels;
        public int samplesPerSec;
        public IntPtr buffer;
        public long renderTimeMs;
        public int avsync_type;
    }

    internal class ExternalVideoFrameInternal
    {

        internal ExternalVideoFrameInternal(ExternalVideoFrame frame)
        {
            this.type = frame.type;
            this.format = frame.format;
            this.stride = frame.stride;
            this.height = frame.height;
            this.cropLeft = frame.cropLeft;
            this.cropTop = frame.cropTop;
            this.cropRight = frame.cropRight;
            this.cropBottom = frame.cropBottom;
            this.rotation = frame.rotation;
            this.timestamp = frame.timestamp;
            this.eglType = frame.eglType;
            this.textureId = frame.textureId;
            this.metadata_size = frame.metadata_size;
        }


        public VIDEO_BUFFER_TYPE type;
        public VIDEO_PIXEL_FORMAT format;

        public int stride;
        public int height;
        public int cropLeft;
        public int cropTop;
        public int cropRight;
        public int cropBottom;
        public int rotation;
        public long timestamp;
        public EGL_CONTEXT_TYPE eglType;
        public int textureId;
        public int metadata_size;
    }

    ///
    /// <summary>
    /// Video frame formats.
    /// </summary>
    ///
    public enum VIDEO_OBSERVER_FRAME_TYPE
    {
        ///
        /// @ignore
        ///
        FRAME_TYPE_YUV420 = 0,

        ///
        /// @ignore
        ///
        FRAME_TYPE_YUV422 = 1,

        ///
        /// <summary>
        /// 2: The format of the video frame is RGBA.
        /// </summary>
        ///
        FRAME_TYPE_RGBA = 2,

        ///
        /// @ignore
        ///
        FRAME_TYPE_BGRA = 3,
    };
}