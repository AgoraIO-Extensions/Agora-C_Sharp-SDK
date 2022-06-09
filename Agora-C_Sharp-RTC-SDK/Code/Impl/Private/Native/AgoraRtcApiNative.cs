using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
    using IrisRtcEnginePtr = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
    using IrisRtcAudioFrameObserverHandle = IntPtr;
    using IrisAudioEncodedFrameObserverHandle = IntPtr;
    using IrisRtcVideoFrameObserverHandle = IntPtr;
    using IrisVideoFrameBufferManagerPtr = IntPtr;
    using IrisVideoFrameBufferDelegateHandle = IntPtr;
    using IrisRtcVideoEncodedImageReceiverHandle = IntPtr;
    using IrisMediaPlayerAudioFrameObserverHandle = IntPtr;
    using IrisMediaPlayerAudioSpectrumObserverHandle = IntPtr;
    using IrisMetaDataObserverHandle = IntPtr;
    using IrisMediaPlayerCustomDataProviderHandle = IntPtr;


    internal enum IRIS_VIDEO_PROCESS_ERR
    {
        ERR_OK = 0,
        ERR_NULL_POINTER = 1,
        ERR_SIZE_NOT_MATCHING = 2,
        ERR_BUFFER_EMPTY = 5,
    };


    internal static class AgoraRtcNative
    {
        #region DllImport

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private const string AgoraRtcLibName = "AgoraRtcWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AgoraRtcLibName = "AgoraRtcWrapperUnity";
#elif UNITY_IPHONE
		private const string AgoraRtcLibName = "__Internal";
#else
        private const string AgoraRtcLibName = "AgoraRtcWrapper";
#endif

// IrisRtcEngine
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcEnginePtr CreateIrisApiEngine();

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void InitLogger(IrisRtcEnginePtr engine_ptr, string dir, int maxSize);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisApiEngine(IrisRtcEnginePtr engine_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle SetIrisRtcEngineEventHandler(IrisRtcEnginePtr engine_ptr,
            IntPtr event_handler);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnsetIrisRtcEngineEventHandler(IrisRtcEnginePtr engine_ptr,
            IrisEventHandlerHandle handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisApi(IrisRtcEnginePtr engine_ptr, string func_name, 
            string @params, UInt32 paramLength, IntPtr bufferPtr, UInt32 bufferLength, out CharAssistant result);

// IrisRtcRawData
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcAudioFrameObserverHandle RegisterAudioFrameObserver(
            IrisRtcEnginePtr engine_ptr, IntPtr observerNative, int order, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterAudioFrameObserver(IrisRtcEnginePtr engine_ptr,
            IrisRtcAudioFrameObserverHandle handle, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcVideoFrameObserverHandle RegisterVideoFrameObserver(
            IrisRtcEnginePtr engine_ptr, IntPtr observerNative, int order, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterVideoFrameObserver(IrisRtcEnginePtr engine_ptr,
            IrisRtcVideoFrameObserverHandle handle, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisAudioEncodedFrameObserverHandle RegisterAudioEncodedFrameObserver(
           IrisRtcEnginePtr engine_ptr, IntPtr observerNative, string @params);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterAudioEncodedFrameObserver(IrisRtcEnginePtr engine_ptr,
            IrisRtcAudioFrameObserverHandle handle, string identifier);


 // Iris Video Encoded Image Receiver
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcVideoEncodedImageReceiverHandle RegisterVideoEncodedImageReceiver(IrisRtcEnginePtr engine_ptr,
                                  IntPtr receiverNative,
                                  int order, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterVideoEncodedImageReceiver(IrisRtcEnginePtr engine_ptr,
                                IrisRtcVideoEncodedImageReceiverHandle handle, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Attach(IrisRtcEnginePtr engine_ptr, IrisVideoFrameBufferManagerPtr manager_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Detach(IrisRtcEnginePtr engine_ptr, IrisVideoFrameBufferManagerPtr manager_ptr);

// IrisRtcRawDataPluginManager
        // [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        // internal static extern int CallIrisRtcRawDataPluginManagerApi(IrisRtcEnginePtr engine_ptr,
        //     ApiTypeRawDataPluginManager api_type, string @params, out CharAssistant result);

// IrisVideoFrameBufferManager
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisVideoFrameBufferManagerPtr CreateIrisVideoFrameBufferManager();

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void
        FreeIrisVideoFrameBufferManager(IrisVideoFrameBufferManagerPtr manager_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle SetIrisVideoFrameBufferManagerEventHandler(
            IrisVideoFrameBufferManagerPtr manager_ptr,
            IrisCEventHandler event_handler);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnsetIrisVideoFrameBufferManagerEventHandler(
            IrisVideoFrameBufferManagerPtr manager_ptr, IrisEventHandlerHandle handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisVideoFrameBufferDelegateHandle EnableVideoFrameBuffer(
            IrisVideoFrameBufferManagerPtr manager_ptr, ref IrisCVideoFrameBufferNative buffer,
            uint uid = 0, string channel_id = "");

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void
        DisableVideoFrameBufferByUid(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    uint uid = 0, string channel_id = "");

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IRIS_VIDEO_PROCESS_ERR GetVideoFrame(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    ref IrisVideoFrame video_frame, out bool is_new_frame,
                                    uint uid, string channel_id = "");

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisVideoFrameBufferDelegateHandle EnableVideoFrameBufferByConfig(
            IrisVideoFrameBufferManagerPtr manager_ptr, ref IrisCVideoFrameBufferNative buffer,
            ref IrisVideoFrameBufferConfig config);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DisableVideoFrameBufferByDelegate(
            IrisVideoFrameBufferManagerPtr manager_ptr,
            IrisVideoFrameBufferDelegateHandle handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void
        DisableVideoFrameBufferByConfig(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    ref IrisVideoFrameBufferConfig config);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void
        DisableAllVideoFrameBuffer(IrisVideoFrameBufferManagerPtr manager_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IRIS_VIDEO_PROCESS_ERR GetVideoFrameByConfig(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    ref IrisVideoFrame video_frame, out bool is_new_frame,
                                    ref IrisVideoFrameBufferConfig config);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool StartDumpVideo(IrisVideoFrameBufferManagerPtr manager_ptr, VIDEO_SOURCE_TYPE type, string dir);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool StopDumpVideo(IrisVideoFrameBufferManagerPtr manager_ptr);

        // Iris Media Base
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisVideoFrame ConvertVideoFrame(ref IrisVideoFrame src, VIDEO_OBSERVER_FRAME_TYPE format);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ClearVideoFrame(ref IrisVideoFrame video_frame);

// IrisMediaPlayerPtr
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle SetIrisMediaPlayerEventHandler(IrisRtcEnginePtr engine_ptr, IntPtr event_handler);
        
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnsetIrisMediaPlayerEventHandler(IrisRtcEnginePtr engine_ptr, IrisEventHandlerHandle handle);

// media player audio frame observer 
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisMediaPlayerAudioFrameObserverHandle
            RegisterMediaPlayerAudioFrameObserver(IrisRtcEnginePtr engine_ptr, IntPtr observer, string @params);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterMediaPlayerAudioFrameObserver(
            IrisRtcEnginePtr engine_ptr, IrisMediaPlayerAudioFrameObserverHandle handle, string @params);
        
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisMediaPlayerAudioSpectrumObserverHandle
            RegisterMediaPlayerAudioSpectrumObserver(IrisRtcEnginePtr engine_ptr, IntPtr observer, string @params);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterMediaPlayerAudioSpectrumObserver(
            IrisRtcEnginePtr engine_ptr, IrisMediaPlayerAudioSpectrumObserverHandle handle, string @params);


        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisMediaPlayerCustomDataProviderHandle MediaPlayerOpenWithSource(IrisRtcEnginePtr engine_ptr, IntPtr provider, string @params);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MediaPlayerUnOpenWithSource(IrisRtcEnginePtr engine_ptr,
                            IrisMediaPlayerCustomDataProviderHandle handle);


        //IrisCloudSpatialAudioEnginePtr
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle SetIrisCloudAudioEngineEventHandler(IrisRtcEnginePtr engine_ptr, IntPtr event_handler);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnsetIrisCloudAudioEngineEventHandler(IrisRtcEnginePtr engine_ptr, IrisEventHandlerHandle handle);

//IrisMetaDataObserver
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisMetaDataObserverHandle RegisterMediaMetadataObserver(IrisRtcEnginePtr engine_ptr, IntPtr observer, string @params);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterMediaMetadataObserver(IrisRtcEnginePtr engine_ptr, IrisMetaDataObserverHandle handle, string @params);

        #endregion

    }

    #region callback native

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_Bool_Native();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate uint Func_Uint32_t_Native();

    //event_handler
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_Event_Native(string @event, string data, IntPtr buffer, IntPtr length, uint buffer_count);

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventHandlerNative
    {
        internal IntPtr onEvent;
    }

    internal struct IrisCEventHandler
    {
        internal Func_Event_Native OnEvent;
    }

    //audio_frame
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameLocal_Native(IntPtr audio_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameRemote_Native(uint uid, IntPtr audio_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameEx_Native(string channel_id, uint uid, IntPtr audio_frame);

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

    //audio_encoded_frame
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_RecordAudioEncodedFrame_Native(IntPtr frame_buffer, int length, IntPtr encoded_audio_frame_info);

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
        internal int bytes_per_row_alignment;
    }

    internal struct IrisCVideoFrameBuffer
    {
        internal VIDEO_OBSERVER_FRAME_TYPE type;
        internal Func_VideoFrame_Native OnVideoFrameReceived;
        internal int bytes_per_row_alignment;
    }

    //encoded_video_image
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_EncodedVideoFrameObserver_Native(uint uid, IntPtr imageBuffer, UInt64 length, IntPtr videoEncodedFrameInfo);

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCVideoEncodedFrameObserverNative
    {
        internal IntPtr OnEncodedVideoFrameObserver;
    }

    internal struct IrisRtcCVideoEncodedFrameObserver
    {
        internal Func_EncodedVideoFrameObserver_Native OnEncodedVideoFrameObserver;
    }

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

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisMediaPlayerCAudioSpectrumObserverNative
    {
        internal IntPtr onLocalAudioSpectrum;
        internal IntPtr onRemoteAudioSpectrum;
    }

    internal struct IrisMediaPlayerCAudioSpectrumObserver
    {
        internal Func_LocalAudioSpectrum_Native OnLocalAudioSpectrum;
        internal Func_RemoteAudioSpectrum_Native OnRemoteAudioSpectrum;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisMediaPlayerCAudioFrameObserverNative
    {
        internal IntPtr onFrame;
    }

    internal struct IrisMediaPlayerCAudioFrameObserver
    {
        internal Func_AudioOnFrame_Native OnFrame;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisMediaPlayerCCustomProviderNative
    {
        internal IntPtr onSeek;
        internal IntPtr onReadData;
    }

    internal struct IrisMediaPlayerCCustomProvider
    {
        internal Func_OnSeek_Native OnSeek;
        internal Func_onReadData_Native OnReadData;
    }

    //meta data
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate int Func_MaxMetadataSize_Native();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_ReadyToSendMetadata_Native(ref IrisMetadata metaData, VIDEO_SOURCE_TYPE source_type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_MetadataReceived_Native(IntPtr metadata);

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCMediaMetadataObserverNative
    {
        internal IntPtr getMaxMetadataSize;
        internal IntPtr onReadyToSendMetadata;
        internal IntPtr onMetadataReceived;
    }

    internal struct IrisCMediaMetadataObserver
    {
        internal Func_MaxMetadataSize_Native GetMaxMetadataSize;
        internal Func_ReadyToSendMetadata_Native OnReadyToSendMetadata;
        internal Func_MetadataReceived_Native OnMetadataReceived;
    }

    #endregion
}