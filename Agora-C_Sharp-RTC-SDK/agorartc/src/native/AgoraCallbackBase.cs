using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_Bool_Native();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate uint Func_Uint32_t_Native();

    //event_handler
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_Event_Native(string @event, string data, IntPtr buffer, uint length);

    //audio_frame
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameLocal_Native(IntPtr audio_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameRemote_Native(uint uid, IntPtr audio_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameEx_Native(string channel_id, uint uid, IntPtr audio_frame);

    //audio_encoded_frame
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_RecordAudioEncodedFrame_Native(IntPtr frame_buffer, int length, IntPtr encoded_audio_frame_info);

    //video_frame
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoFrameLocal_Native(IntPtr video_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoCaptureLocal_Native(IntPtr video_frame, IntPtr config);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoFrameRemote_Native(uint uid, IntPtr video_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoFrameEx_Native(string channel_id, uint uid, IntPtr video_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_VideoFrame_Native(IntPtr video_frame, IntPtr config, bool resize);

    //encoded_video_image
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_EncodedVideoImageReceived_Native(IntPtr imageBuffer, UInt64 length, IntPtr videoEncodedFrameInfo);

    //media player
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioOnFrame_Native(IntPtr audio_frame, int mediaPlayerId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate Int64 Func_OnSeek_Native(Int64 offset, int whence, int playerId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate int Func_onReadData_Native(IntPtr buffer, int bufferSize, int playerId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_LocalAudioSpectrum_Native(IntPtr data);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_RemoteAudioSpectrum_Native(IntPtr audio_frame, uint spectrumNumber);

    //meta data
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate int Func_MaxMetadataSize_Native();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_ReadyToSendMetadata_Native(IntPtr metadata, VIDEO_SOURCE_TYPE source_type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_MetadataReceived_Native(IntPtr metadata);

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCMediaMetadataObserverNative {
        internal IntPtr getMaxMetadataSize;
        internal IntPtr onReadyToSendMetadata;
        internal IntPtr onMetadataReceived;
    }

    internal struct IrisCMediaMetadataObserver {
        internal Func_MaxMetadataSize_Native GetMaxMetadataSize;
        internal Func_ReadyToSendMetadata_Native OnReadyToSendMetadata;
        internal Func_MetadataReceived_Native OnMetadataReceived;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisMediaPlayerCAudioSpectrumObserverNative {
        internal IntPtr onLocalAudioSpectrum;
        internal IntPtr onRemoteAudioSpectrum;
    }

    internal struct IrisMediaPlayerCAudioSpectrumObserver {
        internal Func_LocalAudioSpectrum_Native OnLocalAudioSpectrum;
        internal Func_RemoteAudioSpectrum_Native OnRemoteAudioSpectrum;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisMediaPlayerCAudioFrameObserverNative {
        internal IntPtr onFrame;
    }

    internal struct IrisMediaPlayerCAudioFrameObserver {
        internal Func_AudioOnFrame_Native OnFrame;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisMediaPlayerCCustomProviderNative {
        internal IntPtr onSeek;
        internal IntPtr onReadData;
    }

    internal struct IrisMediaPlayerCCustomProvider {
        internal Func_OnSeek_Native OnSeek;
        internal Func_onReadData_Native OnReadData;
    }
 

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCVideoEncodedImageReceiverNative {
        internal IntPtr OnEncodedVideoImageReceived;
    }

    internal struct IrisRtcCVideoEncodedImageReceiver {
        internal Func_EncodedVideoImageReceived_Native OnEncodedVideoImageReceived;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventHandlerNative
    {
        internal IntPtr onEvent;
    }
    
    internal struct IrisCEventHandler
    {
        internal Func_Event_Native OnEvent;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCAudioFrameObserverNative
    {
        internal IntPtr OnRecordAudioFrame;
        internal IntPtr OnPlaybackAudioFrame;
        internal IntPtr OnMixedAudioFrame;
        internal IntPtr OnPlaybackAudioFrameBeforeMixing;
        internal IntPtr IsMultipleChannelFrameWanted;
        internal IntPtr OnPlaybackAudioFrameBeforeMixingEx;
    }

    internal struct IrisRtcCAudioFrameObserver
    {
        internal Func_AudioFrameLocal_Native OnRecordAudioFrame;
        internal Func_AudioFrameLocal_Native OnPlaybackAudioFrame;
        internal Func_AudioFrameLocal_Native OnMixedAudioFrame;
        internal Func_AudioFrameRemote_Native OnPlaybackAudioFrameBeforeMixing;
        internal Func_Bool_Native IsMultipleChannelFrameWanted;
        internal Func_AudioFrameEx_Native OnPlaybackAudioFrameBeforeMixingEx;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCAudioEncodedFrameObserverNative
    {
        internal IntPtr OnRecordAudioEncodedFrame;
        internal IntPtr OnPlaybackAudioEncodedFrame;
        internal IntPtr OnMixedAudioEncodedFrame;
    }

    internal struct IrisRtcCAudioEncodedFrameObserver
    {
        internal Func_RecordAudioEncodedFrame_Native OnRecordAudioEncodedFrame;
        internal Func_RecordAudioEncodedFrame_Native OnPlaybackAudioEncodedFrame;
        internal Func_RecordAudioEncodedFrame_Native OnMixedAudioEncodedFrame;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCVideoFrameObserverNative
    {
        internal IntPtr OnCaptureVideoFrame;
        internal IntPtr OnPreEncodeVideoFrame;
        internal IntPtr OnRenderVideoFrame;
        internal IntPtr GetObservedFramePosition;
        internal IntPtr IsMultipleChannelFrameWanted;
    }

    internal struct IrisRtcCVideoFrameObserver
    {
        internal Func_VideoCaptureLocal_Native OnCaptureVideoFrame;
        internal Func_VideoCaptureLocal_Native OnPreEncodeVideoFrame;
        internal Func_VideoFrameRemote_Native OnRenderVideoFrame;
        internal Func_Uint32_t_Native GetObservedFramePosition;
        internal Func_Bool_Native IsMultipleChannelFrameWanted;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCVideoFrameBufferNative
    {
        internal int type;
        internal IntPtr OnVideoFrameReceived;
        internal int resize_width;
        internal int resize_height;
    }
    
    internal struct IrisCVideoFrameBuffer
    {
        internal VIDEO_OBSERVER_FRAME_TYPE type;
        internal Func_VideoFrame_Native OnVideoFrameReceived;
        internal int resize_width;
        internal int resize_height;
    }
}