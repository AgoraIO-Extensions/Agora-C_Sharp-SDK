using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
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
    internal struct IrisEncodedAudioFrameInfo
    { 
        internal AUDIO_CODEC_TYPE codec;
        internal int sampleRateHz;
        internal int samplesPerChannel;
        internal int numberOfChannels;
        internal IrisEncodedAudioFrameAdvancedSettings advancedSettings;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisEncodedAudioFrameAdvancedSettings
    {
        internal bool speech;
        internal bool sendEvenIfEmpty;
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
    internal struct IrisAudioPcmFrame
    {
        internal UInt32 capture_timestamp;
        internal UInt16 samples_per_channel_;
        internal int sample_rate_hz_;
        internal IRIS_BYTES_PER_SAMPLE bytes_per_sample;
        internal UInt16 num_channels_;

        [MarshalAs(UnmanagedType.LPArray)]
        internal Int16[] data_;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisAudioSpectrumData
    {
        [MarshalAs(UnmanagedType.LPArray)]
        internal float[] audioSpectrumData;
        internal int dataLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisUserAudioSpectrumInfo
    {
        internal uint uid;
        internal IrisAudioSpectrumData spectrumData;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisVideoFrameBufferConfig
    {
        internal int type;
        internal uint id;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string key;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisMetadata {
        internal uint uid;

        internal uint size;

        internal IntPtr buffer;

        internal Int64 timeStampMs;
    }
}