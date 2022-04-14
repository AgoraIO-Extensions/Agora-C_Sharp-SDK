//  AgoraRtcApiNative.cs
//
//  Created by YuGuo Chen on September 26, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
    using IrisRtcEnginePtr = IntPtr;
    using IrisRtcDeviceManagerPtr = IntPtr;
    using IrisRtcRawDataPtr = IntPtr;
    using IrisRtcRawDataPluginManagerPtr = IntPtr;
    using IrisRtcRendererPtr = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
    using IrisRtcAudioFrameObserverHandle = IntPtr;
    using IrisRtcVideoFrameObserverHandle = IntPtr;
    using IrisRtcRendererCacheConfigHandle = IntPtr;
    using IrisVideoFrameBufferManagerPtr = IntPtr;
    using IrisVideoFrameBufferDelegateHandle = IntPtr;
    using IrisRtcVideoEncodedImageReceiverHandle = IntPtr;
    using IrisMediaPlayerPtr = IntPtr;
    using IrisMediaPlayerAudioFrameObserverHandle = IntPtr;
    using IrisCloudSpatialAudioEnginePtr = IntPtr;
    using IrisLocalSpatialAudioEnginePtr = IntPtr;
    using IrisMediaPlayerVideoFrameObserverHandle = IntPtr;

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
        internal static extern IrisRtcEnginePtr CreateIrisRtcEngine();

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisRtcEngine(IrisRtcEnginePtr engine_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle SetIrisRtcEngineEventHandler(IrisRtcEnginePtr engine_ptr,
            IntPtr event_handler);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnsetIrisRtcEngineEventHandler(IrisRtcEnginePtr engine_ptr,
            IrisEventHandlerHandle handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtcEngineApi(IrisRtcEnginePtr engine_ptr, ApiTypeEngine api_type,
            string @params, out CharAssistant result);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtcEngineApiWithBuffer(IrisRtcEnginePtr engine_ptr, ApiTypeEngine api_type,
            string @params, byte[] buffer, out CharAssistant result);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcDeviceManagerPtr GetIrisRtcDeviceManager(IrisRtcEnginePtr engine_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcRawDataPtr GetIrisRtcRawData(IrisRtcEnginePtr engine_ptr);

// IrisRtcDeviceManager
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtcAudioDeviceManagerApi(IrisRtcDeviceManagerPtr device_manager_ptr,
            ApiTypeAudioDeviceManager api_type, string @params, out CharAssistant result);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtcVideoDeviceManagerApi(IrisRtcDeviceManagerPtr device_manager_ptr,
            ApiTypeVideoDeviceManager api_type, string @params, out CharAssistant result);


// IrisRtcRawData
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcAudioFrameObserverHandle RegisterAudioFrameObserver(
            IrisRtcRawDataPtr raw_data_ptr, IntPtr observerNative, int order, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterAudioFrameObserver(IrisRtcRawDataPtr raw_data_ptr,
            IrisRtcAudioFrameObserverHandle handle, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcVideoFrameObserverHandle RegisterVideoFrameObserver(
            IrisRtcRawDataPtr raw_data_ptr, IntPtr observerNative, int order, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterVideoFrameObserver(IrisRtcRawDataPtr raw_data_ptr,
            IrisRtcVideoFrameObserverHandle handle, string identifier);


        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcRawDataPluginManagerPtr GetIrisRtcRawDataPluginManager(
            IrisRtcRawDataPtr raw_data_ptr);

 // Iris Video Encoded Image Receiver
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisRtcVideoEncodedImageReceiverHandle RegisterVideoEncodedImageReceiver(IrisRtcRawDataPtr raw_data_ptr,
                                  IntPtr receiverNative,
                                  int order, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnRegisterVideoEncodedImageReceiver(IrisRtcRawDataPtr raw_data_ptr,
                                IrisRtcVideoEncodedImageReceiverHandle handle, string identifier);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Attach(IrisRtcRawDataPtr raw_data_ptr, IrisVideoFrameBufferManagerPtr manager_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Detach(IrisRtcRawDataPtr raw_data_ptr, IrisVideoFrameBufferManagerPtr manager_ptr);

// IrisRtcRawDataPluginManager
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtcRawDataPluginManagerApi(IrisRtcRawDataPluginManagerPtr plugin_manager_ptr,
            ApiTypeRawDataPluginManager api_type, string @params, out CharAssistant result);

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
        internal static extern bool GetVideoFrame(IrisVideoFrameBufferManagerPtr manager_ptr,
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
        internal static extern bool GetVideoFrameByConfig(IrisVideoFrameBufferManagerPtr manager_ptr,
                                    ref IrisVideoFrame video_frame, out bool is_new_frame,
                                    ref IrisVideoFrameBufferConfig config);

// Iris Media Base
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisVideoFrame ConvertVideoFrame(ref IrisVideoFrame src, VIDEO_FRAME_TYPE format);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ClearVideoFrame(ref IrisVideoFrame video_frame);

// Iris ScreenCapture
#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_EDITOR_OSX || UNITY_EDITOR_WIN || NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr EnumerateDisplays();

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FreeIrisDisplayCollection(IntPtr collection);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr EnumerateWindows();

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void FreeIrisWindowCollection(IntPtr collection);
#endif

// IrisMediaPlayerPtr
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisMediaPlayerPtr GetIrisMediaPlayer(IrisRtcEnginePtr engine_ptr);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle SetIrisMediaPlayerEventHandler(IrisMediaPlayerPtr player_ptr, IntPtr event_handler);
        
        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnsetIrisMediaPlayerEventHandler(IrisMediaPlayerPtr player_ptr,
            IrisEventHandlerHandle handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisMediaPlayerApi(IrisMediaPlayerPtr player_ptr, ApiTypeMediaPlayer api_type,
                                   string @params, out CharAssistant result);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisMediaPlayerApiWithBuffer(IrisMediaPlayerPtr player_ptr, ApiTypeMediaPlayer api_type,
                                             string @params, byte[] buffer, out CharAssistant result);

// // media player video frame observer 
//         [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
//         internal static extern IrisMediaPlayerVideoFrameObserverHandle RegisterMediaPlayerVideoFrameObserver(
//             IrisMediaPlayerPtr player_ptr,
//             IntPtr observer, string @params);
//
//         [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
//         internal static extern void UnRegisterMediaPlayerVideoFrameObserver(
//             IrisMediaPlayerPtr player_ptr,
//             IrisMediaPlayerVideoFrameObserverHandle handle, string @params);
//
//
// // media player audio frame observer 
//         [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
//         internal static extern IrisMediaPlayerAudioFrameObserverHandle
//         RegisterMediaPlayerAudioFrameObserver(
//             IrisMediaPlayerPtr player_ptr, IntPtr observer, string @params);
//
//         [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
//         internal static extern void UnRegisterMediaPlayerAudioFrameObserver(
//             IrisMediaPlayerPtr player_ptr,
//             IrisMediaPlayerAudioFrameObserverHandle handle, string @params);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MediaPlayerOpenWithSource(IrisMediaPlayerPtr player_ptr,
                                    IntPtr provider, string @params);

//IrisCloudSpatialAudioEnginePtr
       [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
       internal static extern IrisCloudSpatialAudioEnginePtr GetIrisCloudSpatialAudioEngine(IrisRtcEnginePtr engine_ptr);

       [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
       internal static extern int CallIrisCloudSpatialAudioApi(IrisCloudSpatialAudioEnginePtr engine_ptr,
                                   ApiTypeCloudSpatialAudio api_type,
                                   string @params, out CharAssistant result);

       [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
       internal static extern int CallIrisCloudSpatialAudioApiWithBuffer(IrisCloudSpatialAudioEnginePtr engine_ptr,
                           ApiTypeCloudSpatialAudio api_type, string @params, byte[] buffer, out CharAssistant result);

       [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
       internal static extern IrisEventHandlerHandle SetIrisCloudAudioEngineEventHandler(IrisCloudSpatialAudioEnginePtr engine_ptr,
                                   IntPtr event_handler);

       [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
       internal static extern void UnsetIrisCloudAudioEngineEventHandler(IrisCloudSpatialAudioEnginePtr engine_ptr,
                                     IrisEventHandlerHandle handle);

// IrisLocalSpatialAudioEnginePtr
       [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
       internal static extern IrisLocalSpatialAudioEnginePtr GetIrisLocalSpatialAudioEngine(IrisRtcEnginePtr engine_ptr);
        
       [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
       internal static extern int CallIrisLocalSpatialAudioApi(IrisLocalSpatialAudioEnginePtr engine_ptr,
                            ApiTypeLocalSpatialAudio api_type, string @params, out CharAssistant result);

       [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
       internal static extern int CallIrisLocalSpatialAudioApiWithBuffer(IrisLocalSpatialAudioEnginePtr engine_ptr,
                               ApiTypeLocalSpatialAudio api_type, string @params, byte[] buffer, out CharAssistant result);
        #endregion

    }
}