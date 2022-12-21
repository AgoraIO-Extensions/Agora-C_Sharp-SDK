using System;
using System.Runtime.InteropServices;

namespace Agora.Rtc
{
    using view_t = UInt64;

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisAudioFrame
    //{
    //    internal AUDIO_FRAME_TYPE type;
    //    internal int samples;
    //    internal int bytes_per_sample;
    //    internal int channels;
    //    internal int samples_per_sec;
    //    internal IntPtr buffer;
    //    internal Int64 buffer_length;
    //    internal long render_time_ms;
    //    internal int av_sync_type;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisEncodedAudioFrameInfo
    //{
    //    //internal AUDIO_FRAME_TYPE type;
    //    internal AUDIO_CODEC_TYPE codec;
    //    internal int sampleRateHz;
    //    internal int samplesPerChannel;
    //    internal int numberOfChannels;
    //    internal IrisEncodedAudioFrameAdvancedSettings advancedSettings;
    //    internal Int64 captureTimeMs;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisEncodedAudioFrameAdvancedSettings
    //{
    //    internal bool speech;
    //    internal bool sendEvenIfEmpty;
    //}

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
    }

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisWindowCollection
    //{
    //    internal IntPtr windows;
    //    internal uint length;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisDisplayCollection
    //{
    //    internal IntPtr displays;
    //    internal int length;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisWindow
    //{
    //    internal ulong id;

    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //    internal string name;

    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    //    internal string owner_name;

    //    internal IrisRect bounds;
    //    internal IrisRect work_area;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisDisplay
    //{
    //    internal uint id;
    //    internal float scale;
    //    internal IrisRect bounds;
    //    internal IrisRect work_area;
    //    internal int rotation;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisRect
    //{
    //    internal double x;
    //    internal double y;
    //    internal double width;
    //    internal double height;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisEncodedVideoFrameInfo
    //{
    //    internal int codecType;
    //    internal int width;
    //    internal int height;
    //    internal int framesPerSecond;
    //    internal int frameType;
    //    internal int rotation;
    //    internal int trackId;
    //    internal Int64 captureTimeMs;
    //    internal uint uid;
    //    internal int streamType;
    //}

    //public enum IRIS_BYTES_PER_SAMPLE
    //{
    //    IRIS_TWO_BYTES_PER_SAMPLE = 2,
    //};

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisAudioPcmFrame
    //{
    //    internal UInt32 capture_timestamp;
    //    internal UInt64 samples_per_channel_;
    //    internal int sample_rate_hz_;
    //    internal IRIS_BYTES_PER_SAMPLE bytes_per_sample;
    //    internal UInt64 num_channels_;

    //    [MarshalAs(UnmanagedType.LPArray, SizeConst = 3840)]
    //    internal Int16[] data_;
    //}


    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisVideoFrameBufferConfig
    {
        internal int type;
        internal uint id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string key;
    }


    // internal class AudioFrameWithoutBuffer
    // {
    //     public AudioFrameWithoutBuffer()
    //     {
    //     }

    //     public AudioFrameWithoutBuffer(AUDIO_FRAME_TYPE type, int samplesPerChannel, BYTES_PER_SAMPLE bytesPerSample, int channels,
    //         int samplesPerSec, long renderTimeMs, int avsync_type)
    //     {
    //         this.type = type;
    //         this.samplesPerChannel = samplesPerChannel;
    //         this.bytesPerSample = bytesPerSample;
    //         this.channels = channels;
    //         this.samplesPerSec = samplesPerSec;
    //         this.renderTimeMs = renderTimeMs;
    //         this.avsync_type = avsync_type;
    //     }

    //     /** The type of the audio frame. See #AUDIO_FRAME_TYPE
    //*/
    //     public AUDIO_FRAME_TYPE type ;

    //     /** The number of samples per channel in the audio frame.
    //*/
    //     public int samplesPerChannel ; //number of samples for each channel in this frame

    //     /**The number of bytes per audio sample, which is usually 16-bit (2-byte).
    //*/
    //     public BYTES_PER_SAMPLE bytesPerSample ; //number of bytes per sample: 2 for PCM16

    //     public UInt64 bufferPtr ;

    //     /** The number of audio channels.
    //- 1: Mono
    //- 2: Stereo (the data is interleaved)
    //*/
    //     public int channels ; //number of channels (data are interleaved if stereo)

    //     /** The sample rate.
    //*/
    //     public int samplesPerSec ; //sampling rate

    //     /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
    //- Restore the order of the captured audio frame.
    //- Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
    //*/
    //     public long renderTimeMs ;

    //     /** Reserved parameter.
    //*/
    //     public int avsync_type ;
    // }

    internal class ThumbImageBufferInternal
    {
        public uint length;
        public uint width;
        public uint height;

        public Int64 buffer;

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
        /** in Mac: pointer to NSNumber */
        public view_t sourceId;
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