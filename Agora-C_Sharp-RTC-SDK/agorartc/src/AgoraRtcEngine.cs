//  AgoraRtcEngine.cs
//
//  Created by YuGuo Chen on September 26, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    using LitJson;

    using IrisRtcEnginePtr = IntPtr;
    using IrisRtcDeviceManagerPtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;
    using IrisRtcCAudioFrameObserverNativeMarshal = IntPtr;
    using IrisRtcAudioFrameObserverHandleNative = IntPtr;
    using IrisRtcCVideoFrameObserverNativeMarshal = IntPtr;
    using IrisRtcVideoFrameObserverHandleNative = IntPtr;
    using IrisRtcCVideoEncodedImageReceiverNativeMarshal = IntPtr;
    using IrisRtcVideoEncodedImageReceiverHandleNative = IntPtr;
    using IrisVideoFrameBufferManagerPtr = IntPtr;
    using IrisRtcMediaPlayerPtr = IntPtr;
    using IrisCloudSpatialAudioEnginePtr = IntPtr;
    using IrisLocalSpatialAudioEnginePtr = IntPtr;

    public sealed class AgoraRtcEngine : IAgoraRtcEngine
    {
        private bool _disposed = false;
        private static AgoraRtcEngine engineInstance = null;
        private static readonly string identifier = "AgoraRtcEngine";


        private IrisRtcEnginePtr _irisRtcEngine;
        private IrisRtcDeviceManagerPtr _irisRtcDeviceManager;
        private IrisRtcMediaPlayerPtr _irisRtcMediaPlayer;
        private IrisCloudSpatialAudioEnginePtr _irisCloudSpatialAudioEngine;
        private IrisLocalSpatialAudioEnginePtr _irisLocalSpatialAudioEngine;
        private CharAssistant _result;

        private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;
        
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        private AgoraCallbackObject _callbackObject;
#endif

        private AgoraRtcVideoDeviceManager _videoDeviceManagerInstance;
        private AgoraRtcAudioPlaybackDeviceManager _audioPlaybackDeviceManagerInstance;
        private AgoraRtcAudioRecordingDeviceManager _audioRecordingDeviceManagerInstance;

        private IrisRtcCAudioFrameObserverNativeMarshal _irisRtcCAudioFrameObserverNative;
        private IrisRtcCAudioFrameObserver _irisRtcCAudioFrameObserver;
        private IrisRtcAudioFrameObserverHandleNative _irisRtcAudioFrameObserverHandleNative;

        private IrisRtcCVideoFrameObserverNativeMarshal _irisRtcCVideoFrameObserverNative;
        private IrisRtcCVideoFrameObserver _irisRtcCVideoFrameObserver;
        private IrisRtcVideoFrameObserverHandleNative _irisRtcVideoFrameObserverHandleNative;

        private IrisRtcCVideoEncodedImageReceiverNativeMarshal _irisRtcCVideoEncodedImageReceiverNative;
        private IrisRtcCVideoEncodedImageReceiver _irisRtcCVideoEncodedImageReceiver;
        private IrisRtcVideoEncodedImageReceiverHandleNative _irisRtcVideoEncodedImageReceiverHandleNative;

        private IrisVideoFrameBufferManagerPtr _videoFrameBufferManagerPtr;

        private AgoraRtcMediaPlayer _mediaPlayerInstance;
        private AgoraRtcCloudSpatialAudioEngine _cloudSpatialAudioEngineInstance;
        private AgoraRtcSpatialAudioEngine _spatialAudioEngineInstance;

        private AgoraRtcEngine()
        {
            _result = new CharAssistant();
            _irisRtcEngine = AgoraRtcNative.CreateIrisRtcEngine();
            _irisRtcDeviceManager = AgoraRtcNative.GetIrisRtcDeviceManager(_irisRtcEngine);
            _irisRtcMediaPlayer = AgoraRtcNative.GetIrisMediaPlayer(_irisRtcEngine);
            _irisCloudSpatialAudioEngine = AgoraRtcNative.GetIrisCloudSpatialAudioEngine(_irisRtcEngine);
            _irisLocalSpatialAudioEngine = AgoraRtcNative.GetIrisLocalSpatialAudioEngine(_irisRtcEngine);

            _videoDeviceManagerInstance = new AgoraRtcVideoDeviceManager(_irisRtcDeviceManager);
            _audioPlaybackDeviceManagerInstance = new AgoraRtcAudioPlaybackDeviceManager(_irisRtcDeviceManager);
            _audioRecordingDeviceManagerInstance = new AgoraRtcAudioRecordingDeviceManager(_irisRtcDeviceManager);
            _mediaPlayerInstance = new AgoraRtcMediaPlayer(_irisRtcMediaPlayer);
            _cloudSpatialAudioEngineInstance = new AgoraRtcCloudSpatialAudioEngine(_irisCloudSpatialAudioEngine);
            _spatialAudioEngineInstance = new AgoraRtcSpatialAudioEngine(_irisLocalSpatialAudioEngine);
            _videoFrameBufferManagerPtr = AgoraRtcNative.CreateIrisVideoFrameBufferManager();
            AgoraRtcNative.Attach(AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine), _videoFrameBufferManagerPtr);
        }

        private void Dispose(bool disposing, bool sync)
        {
            if (_disposed) return;

            if (disposing)
            {
                ReleaseEventHandler();
                // TODO: Unmanaged resources.
                UnSetIrisAudioFrameObserver();
                UnSetIrisVideoFrameObserver();

                _videoDeviceManagerInstance.Dispose();
                _videoDeviceManagerInstance = null;

                _audioPlaybackDeviceManagerInstance.Dispose();
                _audioPlaybackDeviceManagerInstance = null;

                _audioRecordingDeviceManagerInstance.Dispose();
                _audioRecordingDeviceManagerInstance = null;

                _mediaPlayerInstance.Dispose();
                _mediaPlayerInstance = null;

                _cloudSpatialAudioEngineInstance.Dispose();
                _cloudSpatialAudioEngineInstance = null;
                _spatialAudioEngineInstance = null;

                _irisRtcDeviceManager = IntPtr.Zero;
                _irisRtcMediaPlayer = IntPtr.Zero;
                _irisCloudSpatialAudioEngine = IntPtr.Zero;
                _irisLocalSpatialAudioEngine = IntPtr.Zero;

                AgoraRtcNative.FreeIrisVideoFrameBufferManager(_videoFrameBufferManagerPtr);
            }
            
            Release(sync);
            
            _disposed = true;
        }

        private void Release(bool sync = false)
        {
            var param = new
            {
                sync
            };

            AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
            ApiTypeEngine.kEngineRelease,
            JsonMapper.ToJson(param), out _result);

            AgoraRtcNative.DestroyIrisRtcEngine(_irisRtcEngine);
            _irisRtcEngine = IntPtr.Zero;
            _result = new CharAssistant();
            
            engineInstance = null;
        }

        internal IrisRtcEnginePtr GetNativeHandler()
        {
            return _irisRtcEngine;
        }

        internal IrisVideoFrameBufferManagerPtr GetVideoFrameBufferManager()
        {
            return _videoFrameBufferManagerPtr;
        }

        public static IAgoraRtcEngine CreateAgoraRtcEngine()
        {
            return engineInstance ?? (engineInstance = new AgoraRtcEngine());
        }

        public static IAgoraRtcEngine Get()
        {
            return engineInstance;
        }

        public override int Initialize(RtcEngineContext context)
        {
            var param = new
            {
                context
            };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineInitialize,
            JsonMapper.ToJson(param), out _result);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (ret == 0) SetAppType(AppType.APP_TYPE_UNITY);
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            if (ret == 0) SetAppType(AppType.APP_TYPE_C_SHARP);
#endif

            return ret;
        }

        public override void Dispose(bool sync = false)
        {
            Dispose(true, sync);
            GC.SuppressFinalize(this);
        }

        public override void InitEventHandler(IAgoraRtcEngineEventHandler engineEventHandler)
        {
            if (_irisEngineEventHandlerHandleNative == IntPtr.Zero)
            {
                _irisCEventHandler = new IrisCEventHandler
                {
                    OnEvent = RtcEngineEventHandlerNative.OnEvent,
                    OnEventWithBuffer = RtcEngineEventHandlerNative.OnEventWithBuffer
                };

                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
                {
                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent),
                    onEventWithBuffer =
                        Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEventWithBuffer)
                };

                _irisCEngineEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEngineEventHandlerNative, true);
                _irisEngineEventHandlerHandleNative =
                    AgoraRtcNative.SetIrisRtcEngineEventHandler(_irisRtcEngine, _irisCEngineEventHandlerNative);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                RtcEngineEventHandlerNative.CallbackObject = _callbackObject;
#endif
            }

            RtcEngineEventHandlerNative.EngineEventHandler = engineEventHandler;
        }

        private void ReleaseEventHandler()
        {
            RtcEngineEventHandlerNative.EngineEventHandler = null;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            RtcEngineEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            AgoraRtcNative.UnsetIrisRtcEngineEventHandler(_irisRtcEngine, _irisEngineEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
            _irisEngineEventHandlerHandleNative = IntPtr.Zero;
        }

        public override void RegisterAudioFrameObserver(IAgoraRtcAudioFrameObserver audioFrameObserver)
        {
            SetIrisAudioFrameObserver();
            AgoraRtcAudioFrameObserverNative.AudioFrameObserver = audioFrameObserver;
        }

        public override void UnRegisterAudioFrameObserver()
        {
            UnSetIrisAudioFrameObserver();
        }

        private void SetIrisAudioFrameObserver()
        {
            if (_irisRtcAudioFrameObserverHandleNative != IntPtr.Zero) return;
            
            _irisRtcCAudioFrameObserver = new IrisRtcCAudioFrameObserver
            {
                OnRecordAudioFrame = AgoraRtcAudioFrameObserverNative.OnRecordAudioFrame,
                OnPlaybackAudioFrame = AgoraRtcAudioFrameObserverNative.OnPlaybackAudioFrame,
                OnMixedAudioFrame = AgoraRtcAudioFrameObserverNative.OnMixedAudioFrame,
                OnPlaybackAudioFrameBeforeMixing = AgoraRtcAudioFrameObserverNative.OnPlaybackAudioFrameBeforeMixing,
                IsMultipleChannelFrameWanted = AgoraRtcAudioFrameObserverNative.IsMultipleChannelFrameWanted,
                OnPlaybackAudioFrameBeforeMixingEx = AgoraRtcAudioFrameObserverNative.OnPlaybackAudioFrameBeforeMixingEx
            };

            var irisRtcCAudioFrameObserverNativeLocal = new IrisRtcCAudioFrameObserverNative
            {
                OnRecordAudioFrame = 
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.OnRecordAudioFrame),
                OnPlaybackAudioFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.OnPlaybackAudioFrame),
                OnMixedAudioFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.OnMixedAudioFrame),
                OnPlaybackAudioFrameBeforeMixing =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.OnPlaybackAudioFrameBeforeMixing),
                IsMultipleChannelFrameWanted =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioFrameObserver.IsMultipleChannelFrameWanted),
                OnPlaybackAudioFrameBeforeMixingEx =
                    Marshal.GetFunctionPointerForDelegate(
                        _irisRtcCAudioFrameObserver.OnPlaybackAudioFrameBeforeMixingEx)
            };

            _irisRtcCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisRtcCAudioFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisRtcCAudioFrameObserverNativeLocal, _irisRtcCAudioFrameObserverNative, true);
            _irisRtcAudioFrameObserverHandleNative = AgoraRtcNative.RegisterAudioFrameObserver(
                AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine),
                _irisRtcCAudioFrameObserverNative, 0, identifier
            );
        }

        private void UnSetIrisAudioFrameObserver()
        {
            if (_irisRtcAudioFrameObserverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterAudioFrameObserver(
                AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine),
                _irisRtcAudioFrameObserverHandleNative, identifier
            );
            _irisRtcAudioFrameObserverHandleNative = IntPtr.Zero;
            AgoraRtcAudioFrameObserverNative.AudioFrameObserver = null;
            _irisRtcCAudioFrameObserver = new IrisRtcCAudioFrameObserver();
            Marshal.FreeHGlobal(_irisRtcCAudioFrameObserverNative);
        }

        public override void RegisterVideoFrameObserver(IAgoraRtcVideoFrameObserver videoFrameObserver)
        {
            SetIrisVideoFrameObserver();
            AgoraRtcVideoFrameObserverNative.VideoFrameObserver = videoFrameObserver;
        }

        public override void UnRegisterVideoFrameObserver()
        {
            UnSetIrisVideoFrameObserver();
        }

        private void SetIrisVideoFrameObserver()
        {
            if (_irisRtcVideoFrameObserverHandleNative != IntPtr.Zero) return;

            _irisRtcCVideoFrameObserver = new IrisRtcCVideoFrameObserver
            {
                OnCaptureVideoFrame = AgoraRtcVideoFrameObserverNative.OnCaptureVideoFrame,
                OnPreEncodeVideoFrame = AgoraRtcVideoFrameObserverNative.OnPreEncodeVideoFrame,
                OnRenderVideoFrame = AgoraRtcVideoFrameObserverNative.OnRenderVideoFrame,
                GetObservedFramePosition = AgoraRtcVideoFrameObserverNative.GetObservedFramePosition,
                IsMultipleChannelFrameWanted = AgoraRtcVideoFrameObserverNative.IsMultipleChannelFrameWanted,
                OnRenderVideoFrameEx = AgoraRtcVideoFrameObserverNative.OnRenderVideoFrameEx
            };

            var irisRtcCVideoFrameObserverNativeLocal = new IrisRtcCVideoFrameObserverNative
            {
                OnCaptureVideoFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.OnCaptureVideoFrame),
                OnPreEncodeVideoFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.OnPreEncodeVideoFrame),
                OnRenderVideoFrame =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.OnRenderVideoFrame),
                GetObservedFramePosition =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.GetObservedFramePosition),
                IsMultipleChannelFrameWanted =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.IsMultipleChannelFrameWanted),
                OnRenderVideoFrameEx =
                    Marshal.GetFunctionPointerForDelegate(
                        _irisRtcCVideoFrameObserver.OnRenderVideoFrameEx)
            };

            _irisRtcCVideoFrameObserverNative =
                Marshal.AllocHGlobal(Marshal.SizeOf(irisRtcCVideoFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisRtcCVideoFrameObserverNativeLocal, _irisRtcCVideoFrameObserverNative, true);

            _irisRtcVideoFrameObserverHandleNative = AgoraRtcNative.RegisterVideoFrameObserver(
                AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine), _irisRtcCVideoFrameObserverNative, 0,
                identifier);
        }

        private void UnSetIrisVideoFrameObserver()
        {
            if (_irisRtcVideoFrameObserverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterVideoFrameObserver(AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine),
                _irisRtcVideoFrameObserverHandleNative, identifier);
            _irisRtcVideoFrameObserverHandleNative = IntPtr.Zero;
            AgoraRtcVideoFrameObserverNative.VideoFrameObserver = null;
            _irisRtcCVideoFrameObserver = new IrisRtcCVideoFrameObserver();
            Marshal.FreeHGlobal(_irisRtcCVideoFrameObserverNative);
        }

        public override void RegisterVideoEncodedImageReceiver(IAgoraRtcVideoEncodedImageReceiver videoEncodedImageReceiver)
        {
            SetIrisVideoEncodedImageReceiver();
            AgoraRtcVideoEncodedImageReceiver.VideoEncodedImageReceiver = videoEncodedImageReceiver;
        }

        public override void UnRegisterVideoEncodedImageReceiver()
        {
            UnSetIrisVideoEncodedImageReceiver();
        }

        private void SetIrisVideoEncodedImageReceiver()
        {
            if (_irisRtcVideoEncodedImageReceiverHandleNative != IntPtr.Zero) return;

            _irisRtcCVideoEncodedImageReceiver = new IrisRtcCVideoEncodedImageReceiver
            {
                OnEncodedVideoImageReceived = AgoraRtcVideoEncodedImageReceiver.OnEncodedVideoImageReceived
            };

            var irisRtcCVideoEncodedImageReceiverNativeLocal = new IrisRtcCVideoEncodedImageReceiverNative
            {
                OnEncodedVideoImageReceived =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoEncodedImageReceiver.OnEncodedVideoImageReceived),

            };

            _irisRtcCVideoEncodedImageReceiverNative =
                Marshal.AllocHGlobal(Marshal.SizeOf(irisRtcCVideoEncodedImageReceiverNativeLocal));
            Marshal.StructureToPtr(irisRtcCVideoEncodedImageReceiverNativeLocal, _irisRtcCVideoEncodedImageReceiverNative, true);

            _irisRtcVideoEncodedImageReceiverHandleNative = AgoraRtcNative.RegisterVideoEncodedImageReceiver(
                AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine), _irisRtcCVideoEncodedImageReceiverNative, 0,
                identifier);
        }

        private void UnSetIrisVideoEncodedImageReceiver()
        {
            if (_irisRtcVideoEncodedImageReceiverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterVideoEncodedImageReceiver(AgoraRtcNative.GetIrisRtcRawData(_irisRtcEngine),
                _irisRtcVideoEncodedImageReceiverHandleNative, identifier);
            _irisRtcVideoEncodedImageReceiverHandleNative = IntPtr.Zero;
            AgoraRtcVideoEncodedImageReceiver.VideoEncodedImageReceiver = null;
            _irisRtcCVideoEncodedImageReceiver = new IrisRtcCVideoEncodedImageReceiver();
            Marshal.FreeHGlobal(_irisRtcCVideoEncodedImageReceiverNative);
        }

        public override IAgoraRtcAudioRecordingDeviceManager GetAgoraRtcAudioRecordingDeviceManager()
        {
            return _audioRecordingDeviceManagerInstance;
        }

        public override IAgoraRtcAudioPlaybackDeviceManager GetAgoraRtcAudioPlaybackDeviceManager()
        {
            return _audioPlaybackDeviceManagerInstance;
        }

        public override IAgoraRtcVideoDeviceManager GetAgoraRtcVideoDeviceManager()
        {
            return _videoDeviceManagerInstance;
        }

        public override IAgoraRtcMediaPlayer GetAgoraRtcMediaPlayer()
        {
            return _mediaPlayerInstance;
        }

        public override IAgoraRtcCloudSpatialAudioEngine GetAgoraRtcCloudSpatialAudioEngine()
        {
           return _cloudSpatialAudioEngineInstance;
        }

        public override IAgoraRtcSpatialAudioEngine GetAgoraRtcSpatialAudioEngine()
        {
           return _spatialAudioEngineInstance;
        }

        internal IVideoStreamManager GetVideoStreamManager()
        {
            return new VideoStreamManager(this);
        }

        public override string GetVersion() 
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetVersion,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : _result.Result;
        }

        public override string GetErrorDescription(int code) 
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetErrorDescription,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : _result.Result;
        }

        public override int JoinChannel(string token, string channelId, string info = "",
                                uint uid = 0)
        {
            var param = new
            {
                token,
                channelId,
                info,
                uid
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineJoinChannel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int JoinChannel(string token, string channelId, uint uid,
                                ChannelMediaOptions options)
        {
            var param = new
            {
                token,
                channelId,
                uid,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineJoinChannel,
                JsonMapper.ToJson(param), out _result);
        }
      
        public override int UpdateChannelMediaOptions(ChannelMediaOptions options) 
        {
            var param = new
            {
                options
            };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineUpdateChannelMediaOptions,
            JsonMapper.ToJson(param), out _result);
            return ret;
        }

        public override int LeaveChannel()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineLeaveChannel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int LeaveChannel(LeaveChannelOptions options)
        {
            var param = new
            {
                options
            };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineLeaveChannel,
            JsonMapper.ToJson(param), out _result);
            return ret;
        }

        public override int RenewToken(string token)
        {
            var param = new
            {
                token
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineRenewToken,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            var param = new
            {
                profile
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetChannelProfile,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role) 
        {
            var param = new
            {
                role
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetClientRole,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StartEchoTest()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStartEchoTest,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StartEchoTest(int intervalInSeconds)
        {
            var param = new
            {
                intervalInSeconds
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStartEchoTest,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopEchoTest()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStopEchoTest,
            JsonMapper.ToJson(param), out _result);
        }

        public override int EnableVideo()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineEnableVideo,
            JsonMapper.ToJson(param), out _result);
        }

        public override int DisableVideo()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineDisableVideo,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StartPreview()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStartPreview,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopPreview()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStopPreview,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStartLastMileProbeTest,
            JsonMapper.ToJson(param), out _result);
        }
      
        public override int StopLastmileProbeTest()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStopLastMileProbeTest,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetVideoEncoderConfiguration,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetBeautyEffectOptions(bool enabled, BeautyOptions options)
        {
            var param = new
            {
                enabled,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetBeautyEffectOptions,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetupRemoteVideo(VideoCanvas canvas)
        {
            var param = new
            {
                canvas = new
                {
                    view = (ulong) canvas.view,
                    canvas.renderMode,
                    canvas.uid,
                    canvas.mirrorMode,
                    canvas.isScreenView,
                    canvas.priv_size,
                    canvas.sourceType
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetupRemoteVideo,
            JsonMapper.ToJson(param), canvas.priv, out _result);
        }

        public override int SetupLocalVideo(VideoCanvas canvas)
        {
            var param = new
            {
                canvas = new
                {
                    view = (ulong) canvas.view,
                    canvas.renderMode,
                    canvas.uid,
                    canvas.mirrorMode,
                    canvas.isScreenView,
                    canvas.priv_size,
                    canvas.sourceType
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetupLocalVideo,
            JsonMapper.ToJson(param), canvas.priv, out _result);
        }

        public override int EnableAudio()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineEnableAudio,
            JsonMapper.ToJson(param), out _result);
        }
      

        public override int DisableAudio()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineDisableAudio,
            JsonMapper.ToJson(param), out _result);
        }
      

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            var param = new
            {
                profile,
                scenario
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetAudioProfile,
            JsonMapper.ToJson(param), out _result);
        }
      

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            var param = new
            {
                profile
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetAudioProfile,
            JsonMapper.ToJson(param), out _result);
        }

        public override int EnableLocalAudio(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineEnableLocalAudio,
            JsonMapper.ToJson(param), out _result);
        }
      
        public override int MuteLocalAudioStream(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineMuteLocalAudioStream,
            JsonMapper.ToJson(param), out _result);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineMuteAllRemoteAudioStreams,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetDefaultMuteAllRemoteAudioStreams,
            JsonMapper.ToJson(param), out _result);
        }

        public override int MuteRemoteAudioStream(uint uid, bool mute)
        {
            var param = new
            {
                uid,
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineMuteRemoteAudioStream,
            JsonMapper.ToJson(param), out _result);
        }

        public override int MuteLocalVideoStream(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineMuteLocalVideoStream,
            JsonMapper.ToJson(param), out _result);
        }

        public override int EnableLocalVideo(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineEnableLocalVideo,
            JsonMapper.ToJson(param), out _result);
        }

        public override int MuteAllRemoteVideoStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineMuteAllRemoteVideoStreams,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetDefaultMuteAllRemoteVideoStreams,
            JsonMapper.ToJson(param), out _result);
        }

        public override int MuteRemoteVideoStream(uint uid, bool mute)
        {
            var param = new
            {
                uid,
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineMuteRemoteVideoStream,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            var param = new
            {
                uid,
                streamType
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetRemoteVideoStreamType,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            var param = new
            {
                streamType
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetRemoteDefaultVideoStreamType,
            JsonMapper.ToJson(param), out _result);
        }

        public override int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            var param = new
            {
                interval,
                smooth,
                reportVad
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineEnableAudioVolumeIndication,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StartAudioRecording(string filePath,
                                        AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            var param = new
            {
                filePath,
                quality
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStartAudioRecording,
            JsonMapper.ToJson(param), out _result);
        }
                            

        public override int StartAudioRecording(string filePath,
                                        int sampleRate,
                                        AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            var param = new
            {
                filePath,
                sampleRate,
                quality
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStartAudioRecording,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StartAudioRecording(AudioFileRecordingConfig config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStartAudioRecording,
            JsonMapper.ToJson(param), out _result);
        }
    
        public override int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config,  IAgoraRtcAudioEncodedFrameObserver observer)
        {
            var param = new
            {
                config,
                observer
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineRegisterAudioEncodedFrameObserver,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopAudioRecording()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStopAudioRecording,
            JsonMapper.ToJson(param), out _result);
        }

        //CreateMediaPlayer

        //DestroyMediaPlayer

        public override int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle)
        {
            var param = new
            {
                filePath,
                loopback,
                replace,
                cycle
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStartAudioMixing,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopAudioMixing()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStopAudioMixing,
            JsonMapper.ToJson(param), out _result);
        }

        public override int PauseAudioMixing()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEnginePauseAudioMixing,
            JsonMapper.ToJson(param), out _result);
        }

        public override int ResumeAudioMixing()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineResumeAudioMixing,
            JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustAudioMixingVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineAdjustAudioMixingVolume,
            JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustAudioMixingPublishVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineAdjustAudioMixingPublishVolume,
            JsonMapper.ToJson(param), out _result);
        }

        public override int GetAudioMixingPublishVolume()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineGetAudioMixingPublishVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustAudioMixingPlayoutVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineAdjustAudioMixingPlayoutVolume,
            JsonMapper.ToJson(param), out _result);
        }

        public override int GetAudioMixingPlayoutVolume()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineGetAudioMixingPlayoutVolume,
            JsonMapper.ToJson(param), out _result);
        }

        public override int GetAudioMixingDuration()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineGetAudioMixingDuration,
            JsonMapper.ToJson(param), out _result);
        }

        public override int GetAudioMixingCurrentPosition()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineGetAudioMixingCurrentPosition,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioMixingPosition(int pos /*in ms*/)
        {
            var param = new
            {
                pos
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetAudioMixingPosition,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioMixingPitch(int pitch)
        {
            var param = new
            {
                pitch
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetAudioMixingPitch,
            JsonMapper.ToJson(param), out _result);
        }

        public override int GetEffectsVolume()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineGetEffectsVolume,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetEffectsVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetEffectsVolume,
            JsonMapper.ToJson(param), out _result);
        }

        public override int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            var param = new
            {
                soundId,
                filePath,
                startPos
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEnginePreloadEffect,
            JsonMapper.ToJson(param), out _result);
        }

        public override int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)
        {
            var param = new
            {
                soundId,
                filePath,
                loopCount,
                pitch,
                pan,
                gain,
                publish,
                startPos
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEnginePlayEffect,
            JsonMapper.ToJson(param), out _result);
        }

        public override int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false)
        {
            var param = new
            {
                loopCount,
                pitch,
                pan,
                gain,
                publish
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEnginePlayAllEffects,
            JsonMapper.ToJson(param), out _result);
        }

        public override int GetVolumeOfEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineGetVolumeOfEffect,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetVolumeOfEffect(int soundId, int volume)
        {
            var param = new
            {
                soundId,
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetVolumeOfEffect,
            JsonMapper.ToJson(param), out _result);
        }

        public override int PauseEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEnginePauseEffect,
            JsonMapper.ToJson(param), out _result);
        }

        public override int PauseAllEffects()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEnginePauseAllEffects,
            JsonMapper.ToJson(param), out _result);
        }

        public override int ResumeEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineResumeEffect,
            JsonMapper.ToJson(param), out _result);
        }

        public override int ResumeAllEffects()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineResumeAllEffects,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStopEffect,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopAllEffects()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineStopAllEffects,
            JsonMapper.ToJson(param), out _result);
        }

        public override int UnloadEffect(int soundId)
        {
            var param = new
            {
                soundId
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineUnloadEffect,
            JsonMapper.ToJson(param), out _result);
        }

        public override int UnloadAllEffects()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineUnloadAllEffects,
            JsonMapper.ToJson(param), out _result);
        }

        public override int EnableSoundPositionIndication(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineEnableSoundPositionIndication,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            var param = new
            {
                uid,
                pan,
                gain
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetRemoteVoicePosition,
            JsonMapper.ToJson(param), out _result);
        }

        public override int EnableSpatialAudio(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineEnableSpatialAudio,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            var param = new
            {
                preset
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetVoiceBeautifierPreset,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            var param = new
            {
                preset
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetAudioEffectPreset,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            var param = new
            {
                preset
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetVoiceConversionPreset,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            var param = new
            {
                preset,
                param1,
                param2
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetAudioEffectParameters,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset,
                                                  int param1, int param2)
        {
            var param = new
            {
                preset,
                param1,
                param2
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetVoiceBeautifierParameters,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset,
                                                  int param1, int param2)
        {
            var param = new
            {
                preset,
                param1,
                param2
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetVoiceConversionParameters,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalVoicePitch(double pitch)
        {
            var param = new
            {
                pitch
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetLocalVoicePitch,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency,
                                              int bandGain)
        {
            var param = new
            {
                bandFrequency,
                bandGain
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
            ApiTypeEngine.kEngineSetLocalVoiceEqualization,
            JsonMapper.ToJson(param), out _result);
        }
      
        public override int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            var param = new
            {
                reverbKey,
                value
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVoiceReverb,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset)
        {
            var param = new
            {
                reverbPreset
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVoiceReverbPreset,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger)
        {
            var param = new
            {
                voiceChanger
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
            ApiTypeEngine.kEngineSetLocalVoiceChanger,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetLogFile(string filePath)
        {
            var param = new
            {
                filePath
            };

            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
            ApiTypeEngine.kEngineSetLogFile,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetLogFilter(uint filter)
        {
            var param = new
            {
                filter
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
            ApiTypeEngine.kEngineSetLogFilter,
            JsonMapper.ToJson(param), out _result);
        }

        public override int SetLogLevel(LOG_LEVEL level)
        {
            var param = new
            {
                level
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLogLevel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLogFileSize(uint fileSizeInKBytes)
        {
            var param = new
            {
                fileSizeInKBytes
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLogFileSize,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                renderMode,
                mirrorMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                userId,
                renderMode,
                mirrorMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            var param = new
            {
                renderMode,
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                mirrorMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLocalVideoMirrorMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableDualStreamMode(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableDualStreamMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled)
        {
            var param = new
            {
                sourceType,
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableDualStreamMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig)
        {
            var param = new
            {
                sourceType,
                enabled,
                streamConfig
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableDualStreamMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetExternalAudioSink(int sampleRate, int channels)
        {
            var param = new
            {
                sampleRate,
                channels
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetExternalAudioSink,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartPrimaryCustomAudioTrack(AudioTrackConfig config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartPrimaryCustomAudioTrack,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopPrimaryCustomAudioTrack()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopPrimaryCustomAudioTrack,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartSecondaryCustomAudioTrack(AudioTrackConfig config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartSecondaryCustomAudioTrack,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopSecondaryCustomAudioTrack()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopSecondaryCustomAudioTrack,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRecordingAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode,
            int samplesPerCall)
        {
            var param = new
            {
                sampleRate,
                channel,
                mode,
                samplesPerCall
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRecordingAudioFrameParameters,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetPlaybackAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            var param = new
            {
                sampleRate,
                channel,
                mode,
                samplesPerCall
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetPlaybackAudioFrameParameters,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            var param = new
            {
                sampleRate,
                channel,
                samplesPerCall
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetMixedAudioFrameParameters,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            var param = new
            {
                sampleRate,
                channel
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetPlaybackAudioFrameBeforeMixingParameters,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            var param = new
            {
                intervalInMS
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableAudioSpectrumMonitor,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int DisableAudioSpectrumMonitor()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineDisableAudioSpectrumMonitor,
                JsonMapper.ToJson(param),
                out _result);
        }

        // public override int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        // {
        //     var param = new
        //     {
        //         observer
        //     };
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //         ApiTypeEngine.kEngineRegisterAudioSpectrumObserver,
        //         JsonMapper.ToJson(param),
        //         out _result);
        // }

        // public override int UnregisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        // {
        //     var param = new
        //     {
        //         observer
        //     };
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //         ApiTypeEngine.kEngineUnregisterAudioSpectrumObserver,
        //         JsonMapper.ToJson(param),
        //         out _result);
        // }

        public override int AdjustRecordingSignalVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustRecordingSignalVolume,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int MuteRecordingSignal(bool mute)
        {
            var param = new
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineMuteRecordingSignal,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int AdjustPlaybackSignalVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustPlaybackSignalVolume,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            var param = new
            {
                uid,
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustUserPlaybackSignalVolume,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableLoopbackRecording(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableLoopBackRecording,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int AdjustLoopbackRecordingVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAdjustLoopbackRecordingVolume,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int GetLoopbackRecordingVolume()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetLoopbackRecordingVolume,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            var param = new
            {
                enabled,
                includeAudioFilters
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableInEarMonitoring,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetInEarMonitoringVolume(int volume)
        {
            var param = new
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetInEarMonitoringVolume,
                JsonMapper.ToJson(param),
                out _result);
        }
    
        public override int LoadExtensionProvider(string extension_lib_path)
        {
            var param = new
            {
                extension_lib_path
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineLoadExtensionProvider,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetExtensionProviderProperty(string provider, string key, string value)
        {
            var param = new
            {
                provider,
                key,
                value
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetExtensionProviderProperty,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableExtension(
          string provider, string extension, bool enable=true)
        {
            var param = new
            {
                provider,
                extension,
                enable
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableExtension,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetExtensionProperty(
          string provider, string extension,
          string key, string value)
        {
            var param = new
            {
                provider,
                extension,
                key,
                value
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetExtensionProperty,
                JsonMapper.ToJson(param),
                out _result);
        }  

        public override int GetExtensionProperty(
          string provider, string extension,
          string key, string value, int buf_len)
        {
            var param = new
            {
                provider,
                extension,
                key,
                value,
                buf_len
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetExtensionProperty,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraCapturerConfiguration,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SwitchCamera()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSwitchCamera,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override bool IsCameraZoomSupported()
        {
            var param = new {};
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsCameraZoomSupported,
                JsonMapper.ToJson(param),
                out _result);
            return ret == 0 ? true : false;
        }

        public override bool IsCameraFaceDetectSupported()
        {
            var param = new {};
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsCameraFaceDetectSupported,
                JsonMapper.ToJson(param),
                out _result);
            return ret == 0 ? true : false;
        }

        public override bool IsCameraTorchSupported()
        {
            var param = new {};
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsCameraTorchSupported,
                JsonMapper.ToJson(param),
                out _result);
            return ret == 0 ? true : false;
        }

        public override bool IsCameraFocusSupported()
        {
            var param = new {};
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsCameraFocusSupported,
                JsonMapper.ToJson(param),
                out _result);
            return ret == 0 ? true : false;
        }

        public override bool IsCameraAutoFocusFaceModeSupported()
        {
            var param = new {};
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsCameraAutoFocusFaceModeSupported,
                JsonMapper.ToJson(param),
                out _result);
            return ret == 0 ? true : false;
        }

        public override int SetCameraZoomFactor(float factor)
        {
            var param = new 
            {
                factor
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraZoomFactor,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableFaceDetection(bool enabled)
        {
            var param = new 
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableFaceDetection,
                JsonMapper.ToJson(param),
                out _result);
        }
  
        public override float GetCameraMaxZoomFactor()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetCameraMaxZoomFactor,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            var param = new
            {
                positionX,
                positionY
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraFocusPositionInPreview,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetCameraTorchOn(bool isOn)
        {
            var param = new
            {
                isOn
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraTorchOn,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraAutoFocusFaceModeEnabled,
                JsonMapper.ToJson(param),
                out _result);
        }
      

        public override bool IsCameraExposurePositionSupported()
        {
            var param = new {};
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsCameraExposurePositionSupported,
                JsonMapper.ToJson(param),
                out _result);
            return ret == 0 ? true : false;
        }
      

        public override int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            var param = new
            {
                positionXinView,
                positionYinView
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraExposurePosition,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override bool IsCameraAutoExposureFaceModeSupported()
        {
            var param = new {};
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsCameraAutoExposureFaceModeSupported,
                JsonMapper.ToJson(param),
                out _result);
            return ret == 0 ? true : false;
        }
      
        public override int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraAutoExposureFaceModeEnabled,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            var param = new
            {
                defaultToSpeaker
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetDefaultAudioRouteToSpeakerphone,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetEnableSpeakerphone(bool speakerOn)
        {
            var param = new
            {
                speakerOn
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetEnableSpeakerphone,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override bool IsSpeakerphoneEnabled()
        {
            var param = new {};
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineIsSpeakerphoneEnabled,
                JsonMapper.ToJson(param),
                out _result);
            return ret == 0 ? true : false;
        }
    
        public override int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect,
                                                ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                displayId,
                regionRect,
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartScreenCaptureByDisplayId,
                JsonMapper.ToJson(param),
                out _result);
        }
    
        public override int StartScreenCaptureByScreenRect(Rectangle screenRect,
                                                 Rectangle regionRect,
                                                 ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                screenRect,
                regionRect,
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartScreenCaptureByScreenRect,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StartScreenCapture(byte[] mediaProjectionPermissionResultData,
                                    ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kEngineStartScreenCapture,
                JsonMapper.ToJson(param), mediaProjectionPermissionResultData,
                out _result);
        }

        public override int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect,
                                               ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                windowId,
                regionRect,
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartScreenCaptureByWindowId,
                JsonMapper.ToJson(param),
                out _result);
        }
    
        public override int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            var param = new
            {
                contentHint
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetScreenCaptureContentHint,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            var param = new
            {
                regionRect
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUpdateScreenCaptureRegion,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                captureParams
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUpdateScreenCaptureParameters,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StopScreenCapture()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopScreenCapture,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override string GetCallId()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineGetCallId,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : _result.Result;
        }

        public override int Rate(string callId, int rating,
                        string description)
        {
            var param = new
            {
                callId,
                rating,
                description
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRate,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int Complain(string callId, string description)
        {
            var param = new
            {
                callId,
                description
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineComplain,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            var param = new
            {
                url,
                transcodingEnabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAddPublishStreamUrl,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int RemovePublishStreamUrl(string url)
        {
            var param = new
            {
                url
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRemovePublishStreamUrl,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetLiveTranscoding(LiveTranscoding transcoding)
        {
            var param = new
            {
                transcoding
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetLiveTranscoding,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartLocalVideoTranscoder,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUpdateLocalTranscoderConfiguration,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StopLocalVideoTranscoder()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopLocalVideoTranscoder,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int StartPrimaryCameraCapture(CameraCapturerConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartPrimaryCameraCapture,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StartSecondaryCameraCapture(CameraCapturerConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartSecondaryCameraCapture,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StopPrimaryCameraCapture()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopPrimaryCameraCapture,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StopSecondaryCameraCapture()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopSecondaryCameraCapture,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            var param = new
            {
                type,
                orientation
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetCameraDeviceOrientation,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            var param = new
            {
                type,
                orientation
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetScreenCaptureOrientation,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int StartPrimaryScreenCapture(ScreenCaptureConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartPrimaryScreenCapture,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StartSecondaryScreenCapture(ScreenCaptureConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartSecondaryScreenCapture,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StopPrimaryScreenCapture()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopPrimaryScreenCapture,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int StopSecondaryScreenCapture()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopSecondaryScreenCapture,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override CONNECTION_STATE_TYPE GetConnectionState()
        {
            var param = new {};
            return (CONNECTION_STATE_TYPE) AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetConnectionState,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int RegisterEventHandler(IAgoraRtcEngineEventHandler eventHandler)
        {
            var param = new
            {
                eventHandler
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRegisterEventHandler,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int UnregisterEventHandler(IAgoraRtcEngineEventHandler eventHandler)
        {
            var param = new
            {
                eventHandler
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUnregisterEventHandler,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            var param = new
            {
                uid,
                userPriority
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetRemoteUserPriority,
                JsonMapper.ToJson(param),
                out _result);
        }

        // public override int RegisterPacketObserver(IPacketObserver observer)
        // {
        //     var param = new
        //     {
        //         observer
        //     };
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //         ApiTypeEngine.kEngineRegisterPacketObserver,
        //         JsonMapper.ToJson(param),
        //         out _result);
        // }

        public override int SetEncryptionMode(string encryptionMode)
        {
            var param = new
            {
                encryptionMode
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetEncryptionMode,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SetEncryptionSecret(string secret)
        {
            var param = new
            {
                secret
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetEncryptionSecret,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            var param = new
            {
                enabled,
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableEncryption,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int CreateDataStream(bool reliable, bool ordered)
        {
            var param = new
            {
                reliable,
                ordered
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineCreateDataStream,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int CreateDataStream(DataStreamConfig config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineCreateDataStream,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            var param = new
            {
                streamId,
                length
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kEngineSendStreamMessage,
                JsonMapper.ToJson(param), data,
                out _result);
        } 

        public override int AddVideoWatermark(RtcImage watermark)
        {
            var param = new
            {
                watermark
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAddVideoWaterMark,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            var param = new
            {
                watermarkUrl,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAddVideoWaterMark,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int ClearVideoWatermark()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineClearVideoWatermark,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int ClearVideoWatermarks()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineClearVideoWatermark,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            var param = new
            {
                url,
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineAddInjectStreamUrl,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int RemoveInjectStreamUrl(string url)
        {
            var param = new
            {
                url
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRemoveInjectStreamUrl,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int PauseAudio()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEnginePauseAudio,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int ResumeAudio()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineResumeAudio,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int EnableWebSdkInteroperability(bool enabled)
        {
            var param = new
            {
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableWebSdkInteroperability,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            var param = new
            {
                id,
                category,
                @event,
                label,
                value
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineEnableWebSdkInteroperability,
                JsonMapper.ToJson(param),
                out _result);
        }

        // public override int RegisterMediaMetadataObserver(IMetadataObserver observer, IMetadataObserver::METADATA_TYPE type)
        // {
        //     var param = new
        //     {
        //         observer,
        //         type
        //     };
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //         ApiTypeEngine.kEngineRegisterMediaMetadataObserver,
        //         JsonMapper.ToJson(param),
        //         out _result);
        // }

        // public override int UnregisterMediaMetadataObserver(IMetadataObserver observer, IMetadataObserver::METADATA_TYPE type)
        // {
        //     var param = new
        //     {
        //         observer,
        //         type
        //     };
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //         ApiTypeEngine.kEngineUnRegisterMediaMetadataObserver,
        //         JsonMapper.ToJson(param),
        //         out _result);
        // }

        public override int StartAudioFrameDump(string channel_id, uint user_id, string location,
            string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            var param = new
            {
                channel_id,
                user_id,
                location,
                uuid,
                passwd,
                duration_ms,
                auto_upload
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartAudioFrameDump,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int StopAudioFrameDump(string channel_id, uint user_id, string location)
        {
            var param = new
            {
                channel_id,
                user_id,
                location
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopAudioFrameDump,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int RegisterLocalUserAccount(string appId, string userAccount)
        {
            var param = new
            {
                appId,
                userAccount
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineRegisterLocalUserAccount,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int JoinChannelWithUserAccount(string token, string channelId,
                                              string userAccount)
        {
            var param = new
            {
                token,
                channelId,
                userAccount
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineJoinChannelWithUserAccount,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, 
                                                string userAccount, ChannelMediaOptions options)
        {
            var param = new
            {
                token,
                channelId,
                userAccount,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineJoinChannelWithUserAccount,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int JoinChannelWithUserAccountEx(string token, string channelId,
                                                string userAccount, ChannelMediaOptions options,
                                                IAgoraRtcEngineEventHandler eventHandler)
        {
            var param = new
            {
                token,
                channelId,
                userAccount,
                options,
                eventHandler
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineJoinChannelWithUserAccountEx,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo, string channelId = null, string localUserAccount = null)
        {
            var param = new
            {
                userAccount,
                channelId,
                localUserAccount
            };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetUserInfoByUserAccount,
                JsonMapper.ToJson(param), out _result);
            userInfo = _result.Result.Length == 0 ? new UserInfo() : AgoraJson.JsonToStruct<UserInfo>(_result.Result);
            return ret;
        }
      
        public override int GetUserInfoByUid(uint uid, out UserInfo userInfo, string channelId = null, string localUserAccount = null)
        {
            var param = new
            {
                uid,
                channelId,
                localUserAccount
            };
            var ret = AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineGetUserInfoByUid,
                JsonMapper.ToJson(param), out _result);
            userInfo = _result.Result.Length == 0 ? new UserInfo() : AgoraJson.JsonToStruct<UserInfo>(_result.Result);
            return ret;
        }

        public override int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var param = new
            {
                configuration
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStartChannelMediaRelay,
                JsonMapper.ToJson(param),
                out _result);
        }

        public override int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var param = new
            {
                configuration
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineUpdateChannelMediaRelay,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int StopChannelMediaRelay()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineStopChannelMediaRelay,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        public override int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            var param = new
            {
                profile
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetDirectCdnStreamingAudioConfiguration,
                JsonMapper.ToJson(param),
                out _result);
        }
        
        public override int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            var param = new
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
                ApiTypeEngine.kEngineSetDirectCdnStreamingVideoConfiguration,
                JsonMapper.ToJson(param),
                out _result);
        }
      
        // public override int StartDirectCdnStreaming(IDirectCdnStreamingEventHandler eventHandler,
        //                                     string publishUrl, DirectCdnStreamingMediaOptions options)
        // {
        //     var param = new
        //     {
        //         eventHandler,
        //         options
        //     };
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //         ApiTypeEngine.kEngineStartDirectCdnStreaming,
        //         JsonMapper.ToJson(param),
        //         out _result);
        // }

        // public override int StopDirectCdnStreaming()
        // {
        //     var param = new {};
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //         ApiTypeEngine.kEngineStopDirectCdnStreaming,
        //         JsonMapper.ToJson(param),
        //         out _result);
        // }
      
        // public override int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        // {
        //     var param = new
        //     {
        //         options
        //     };
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //         ApiTypeEngine.kEngineUpdateDirectCdnStreamingMediaOptions,
        //         JsonMapper.ToJson(param),
        //         out _result);
        // }
      
        public override int PushDirectCdnStreamingCustomVideoFrame(ExternalVideoFrame frame)
        {
            var param = new
            {
                frame = new
                {
                    frame.type,
                    frame.format,
                    frame.stride,
                    frame.height,
                    frame.cropLeft,
                    frame.cropTop,
                    frame.cropRight,
                    frame.cropBottom,
                    frame.rotation,
                    frame.timestamp
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kEnginePushDirectCdnStreamingCustomVideoFrame,
                JsonMapper.ToJson(param), frame.buffer,
                out _result);
        }

        public override int JoinChannelEx(string token, RtcConnection connection,
                              ChannelMediaOptions options,
                              IAgoraRtcEngineEventHandler eventHandler)
        {
            var param = new
            {
                token,
                connection,
                options,
                eventHandler
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineJoinChannelEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int LeaveChannelEx(RtcConnection connection)
        {
            var param = new
            {
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineLeaveChannelEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            var param = new
            {
                options,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineUpdateChannelMediaOptionsEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            var param = new
            {
                config,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetVideoEncoderConfigurationEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            var param = new
            {
                canvas = new
                {
                    view = (ulong) canvas.view,
                    canvas.renderMode,
                    canvas.uid,
                    canvas.mirrorMode,
                    canvas.isScreenView,
                    canvas.priv_size,
                    canvas.sourceType
                },
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, ApiTypeEngine.kEngineSetupRemoteVideoEx,
                JsonMapper.ToJson(param), canvas.priv, out _result);
        }

        public override int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            var param = new
            {
                uid,
                mute,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineMuteRemoteAudioStreamEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            var param = new
            {
                uid,
                mute,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineMuteRemoteVideoStreamEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)
        {
            var param = new
            {
                uid,
                pan,
                gain,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetRemoteVoicePositionEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection)
        {
            var param1 = new
            {
                uid,
                param,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetRemoteUserSpatialAudioParamsEx,
                JsonMapper.ToJson(param1), out _result);
        }

        public override int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode,
                                          VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)
        {
            var param = new
            {
                uid,
                renderMode,
                mirrorMode,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetRemoteRenderModeEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableLoopbackRecordingEx(bool enabled, RtcConnection connection)
        {
            var param = new
            {
                enabled,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineEnableLoopBackRecordingEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            var param = new
            {
                connection
            };
            return (CONNECTION_STATE_TYPE) AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetConnectionStateEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            var param = new
            {
                connection,
                enabled,
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineEnableEncryptionEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int CreateDataStreamEx(bool reliable, bool ordered, RtcConnection connection)
        {
            var param = new
            {
                reliable,
                ordered,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineCreateDataStreamEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int CreateDataStreamEx(DataStreamConfig config, RtcConnection connection)
        {
            var param = new
            {
                config,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineCreateDataStreamEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            var param = new
            {
                streamId,
                length,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, ApiTypeEngine.kEngineSendStreamMessageEx,
                JsonMapper.ToJson(param), data, out _result);
        }

        public override int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            var param = new
            {
                watermarkUrl,
                options,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineAddVideoWaterMarkEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int ClearVideoWatermarkEx(RtcConnection connection)
        {
            var param = new
            {
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineClearVideoWatermarkEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection)
        {
            var param = new
            {
                id,
                category,
                @event,
                label,
                value,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSendCustomReportMessageEx,
                JsonMapper.ToJson(param), out _result);
        }

        private int SetAppType(AppType appType)
        {
            var param = new
            {
                appType
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetAppType,
                JsonMapper.ToJson(param), out _result);
        }

        public override int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame,
                             bool wrap = false, int sourceId = 0)
        {
            var param = new
            {
                type,
                frame = new
                {
                    frame.type,
                    frame.samplesPerChannel,
                    frame.bytesPerSample,
                    frame.channels,
                    frame.samplesPerSec,
                    frame.renderTimeMs,
                    frame.avsync_type
                },
                wrap,
                sourceId
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, ApiTypeEngine.kMediaPushAudioFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
        }


        public override int PullAudioFrame(AudioFrame frame)
        {
            var param = new { };
            var ret = AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine,
                ApiTypeEngine.kMediaPullAudioFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
            var f = _result.Result.Length == 0
                ? new AudioFrameWithoutBuffer()
                : AgoraJson.JsonToStruct<AudioFrameWithoutBuffer>(_result.Result);
            frame.avsync_type = f.avsync_type;
            frame.channels = f.channels;
            //frame.samplesPerChannel = f.samplesPerChannel;
            frame.type = f.type;
            frame.bytesPerSample = f.bytesPerSample;
            frame.renderTimeMs = f.renderTimeMs;
            frame.samplesPerSec = f.samplesPerSec;
            return 0;
        }

        
        public override int SetExternalVideoSource(bool enabled, bool useTexture, bool encodedFrame, EncodedVideoTrackOptions encodedVideoOption)
        {
            var param = new
            {
                enabled,
                useTexture,
                encodedFrame,
                encodedVideoOption
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kMediaSetExternalVideoSource,
                JsonMapper.ToJson(param), out _result);
        }
       
        public override int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true)
        {
            var param = new
            {
                enabled,
                sampleRate,
                channels,
                sourceNumber,
                localPlayback,
                publish
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kMediaSetExternalAudioSource,
                JsonMapper.ToJson(param), out _result);
        }

        
        public override int PushVideoFrame(ExternalVideoFrame frame)
        {
            var param = new
            {
                frame = new
                {
                    frame.type,
                    frame.format,
                    frame.stride,
                    frame.height,
                    frame.cropLeft,
                    frame.cropTop,
                    frame.cropRight,
                    frame.cropBottom,
                    frame.rotation,
                    frame.timestamp
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, ApiTypeEngine.kMediaPushVideoFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
        }

        public override int PushVideoFrame(ExternalVideoFrame frame, RtcConnection connection)
        {
            var param = new
            {
                frame = new
                {
                    frame.type,
                    frame.format,
                    frame.stride,
                    frame.height,
                    frame.cropLeft,
                    frame.cropTop,
                    frame.cropRight,
                    frame.cropBottom,
                    frame.rotation,
                    frame.timestamp
                },
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, ApiTypeEngine.kMediaPushVideoFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
        }

        public override int PushEncodedVideoImage(byte[] imageBuffer, uint length,
                                          EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            var param = new
            {
                length,
                videoEncodedFrameInfo
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, ApiTypeEngine.kMediaPushEncodedVideoImage,
                JsonMapper.ToJson(param), imageBuffer, out _result);
        }

        public override int PushEncodedVideoImage(byte[] imageBuffer, uint length,
                                          EncodedVideoFrameInfo videoEncodedFrameInfo,
                                          RtcConnection connection)
        {
            var param = new
            {
                length,
                videoEncodedFrameInfo,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, ApiTypeEngine.kMediaPushEncodedVideoImage,
                JsonMapper.ToJson(param), imageBuffer, out _result);
        }

        public override int GetCertificateVerifyResult(string credential_buf, int credential_len, string certificate_buf, int certificate_len)
        {
            var param = new
            {
                credential_buf,
                credential_len,
                certificate_buf,
                certificate_len
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetCertificateVerifyResult,
                JsonMapper.ToJson(param), out _result);
        }
        
        public override int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            var param = new
            {
                restriction
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetAudioSessionOperationRestriction,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustCustomAudioPublishVolume(int sourceId, int volume)
        {
            var param = new
            {
                sourceId,
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineAdjustCustomAudioPublishVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int AdjustCustomAudioPlayoutVolume(int sourceId, int volume)
        {
            var param = new
            {
                sourceId,
                volume
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineAdjustCustomAudioPlayoutVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetParameters(string parameters)
        {
            var param = new
            {
                parameters
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineSetParameters,
                JsonMapper.ToJson(param), out _result);
        }

        // public override DeviceInfo GetAudioDeviceInfo()
        // {
        //     var param = new {};
        //     return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcDeviceManager,
        //     ApiTypeEngine.kEngineGetAudioDeviceInfo,
        //     JsonMapper.ToJson(param), out _result) != 0
        //     ? new DeviceInfo()
        //     : AgoraJson.JsonToStruct<DeviceInfo>(_result.Result);
        // }

        public override int EnableCustomAudioLocalPlayback(int sourceId, bool enabled)
        {
            var param = new
            {
                sourceId,
                enabled
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kMediaEnableCustomAudioLocalPlayback,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type)
        {
            var param = new
            {
                enabled,
                backgroundSource,
                segproperty,
                type
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineEnableVirtualBackground,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            var param = new
            {
                option
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineSetLocalPublishFallbackOption,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            var param = new
            {
                option
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineSetRemoteSubscribeFallbackOption,
                JsonMapper.ToJson(param), out _result);
        }

        public override int PauseAllChannelMediaRelay()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEnginePauseAllChannelMediaRelay,
                JsonMapper.ToJson(param), out _result);
        }

        public override int ResumeAllChannelMediaRelay()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineResumeAllChannelMediaRelay,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay)
        {
            var param = new 
            {
                enabled,
                audioSourceDelay
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kMediaEnableEchoCancellationExternal,
                JsonMapper.ToJson(param), out _result);
        }

        public override int TakeSnapshot(string channel, uint uid, string filePath)
        {
            var param = new 
            {
                channel,
                uid,
                filePath
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineTakeSnapshot,
                JsonMapper.ToJson(param), out _result);
        }

        public override int EnableContentInspect(bool enabled, ContentInspectConfig config)
        {
            var param = new 
            {
                enabled,
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineEnableContentInspect,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SwitchChannel(string token, string channel)
        {
            var param = new 
            {
                token,
                channel
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineSwitchChannel,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            var param = new 
            {
                sound1,
                sound2,
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineStartRhythmPlayer,
                JsonMapper.ToJson(param), out _result);
        }

        public override int StopRhythmPlayer()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineStopRhythmPlayer,
                JsonMapper.ToJson(param), out _result);
        }

        public override int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            var param = new 
            {
                config
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineConfigRhythmPlayer,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param)
        {
            var param1 = new 
            {
                uid,
                param
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineSetRemoteUserSpatialAudioParams,
                JsonMapper.ToJson(param1), out _result);
        }

        public override int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        {
            var param = new 
            {
                uid,
                options
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineSetRemoteVideoSubscriptionOptions,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        {
            var param = new 
            {
                uid,
                options,
                connection
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kEngineSetRemoteVideoSubscriptionOptionsEx,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetDirectExternalAudioSource(bool enable, bool localPlayback)
        {
            var param = new 
            {
                enable,
                localPlayback
            };
            return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, 
                ApiTypeEngine.kMediaSetDirectExternalAudioSource,
                JsonMapper.ToJson(param), out _result);
        }

        public override int PushDirectAudioFrame(AudioFrame frame)
        {
            var param = new
            {
                frame = new
                {
                    frame.type,
                    frame.samplesPerChannel,
                    frame.bytesPerSample,
                    frame.channels,
                    frame.samplesPerSec,
                    frame.renderTimeMs,
                    frame.avsync_type
                }
            };
            return AgoraRtcNative.CallIrisRtcEngineApiWithBuffer(_irisRtcEngine, ApiTypeEngine.kMediaPushDirectAudioFrame,
                JsonMapper.ToJson(param), frame.buffer, out _result);
        }

        ~AgoraRtcEngine()
        {
            Dispose(false, false);
        }
    }

    internal static class RtcEngineEventHandlerNative
    {
        internal static IAgoraRtcEngineEventHandler EngineEventHandler = null;
        internal static AgoraCallbackObject CallbackObject = null;

        [MonoPInvokeCallback(typeof(Func_Event_Native))]
        internal static void OnEvent(string @event, string data)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            switch(@event)
            {
                case "onWarning":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnWarning(
                                (int) AgoraJson.GetData<int>(data, "warn"),
                                (string) AgoraJson.GetData<string>(data, "msg")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnError(
                                (int) AgoraJson.GetData<int>(data, "err"),
                                (string) AgoraJson.GetData<string>(data, "msg")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onJoinChannelSuccess":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnJoinChannelSuccess(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (int) AgoraJson.GetData<int>(data, "elapsed")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRejoinChannelSuccess":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRejoinChannelSuccess(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (int) AgoraJson.GetData<int>(data, "elapsed")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioQuality":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioQuality(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"),
                                (UInt16) AgoraJson.GetData<UInt16>(data, "delay"),
                                (UInt16) AgoraJson.GetData<UInt16>(data, "lost")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLeaveChannel":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLeaveChannel(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                AgoraJson.JsonToStruct<RtcStats>(data, "stats")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onClientRoleChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnClientRoleChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "oldRole"),
                                (CLIENT_ROLE_TYPE) AgoraJson.GetData<int>(data, "newRole")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserJoined":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnUserJoined(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (int) AgoraJson.GetData<int>(data, "elapsed")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserOffline":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnUserOffline(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (USER_OFFLINE_REASON_TYPE) AgoraJson.GetData<int>(data, "reason")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLastmileQuality":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLastmileQuality(
                                (int) AgoraJson.GetData<int>(data, "quality")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLastmileProbeResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLastmileProbeResult(
                                AgoraJson.JsonToStruct<LastmileProbeResult>(data, "result")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onConnectionInterrupted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(
                        () =>
                        {
#endif
                    if (EngineEventHandler != null)
                            {
                                EngineEventHandler.OnConnectionInterrupted(
                                    AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                                );
                            }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onConnectionLost":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnConnectionLost(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onConnectionBanned":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnConnectionBanned(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onApiCallExecuted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnApiCallExecuted(
                                (int) AgoraJson.GetData<int>(data, "err"),
                                (string) AgoraJson.GetData<string>(data, "api"),
                                (string) AgoraJson.GetData<string>(data, "result")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRequestToken":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRequestToken(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onTokenPrivilegeWillExpire":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnTokenPrivilegeWillExpire(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (string) AgoraJson.GetData<string>(data, "token")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRtcStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRtcStats(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                AgoraJson.JsonToStruct<RtcStats>(data, "stats")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onNetworkQuality":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnNetworkQuality(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (int) AgoraJson.GetData<int>(data, "txQuality"),
                                (int) AgoraJson.GetData<int>(data, "rxQuality")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLocalVideoStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLocalVideoStats(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                AgoraJson.JsonToStruct<LocalVideoStats>(data, "stats")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteVideoStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRemoteVideoStats(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                AgoraJson.JsonToStruct<RemoteVideoStats>(data, "stats")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLocalAudioStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLocalAudioStats(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                AgoraJson.JsonToStruct<LocalAudioStats>(data, "stats")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteAudioStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRemoteAudioStats(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                AgoraJson.JsonToStruct<RemoteAudioStats>(data, "stats")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLocalAudioStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLocalAudioStateChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (LOCAL_AUDIO_STREAM_STATE) AgoraJson.GetData<int>(data, "state"),
                                (LOCAL_AUDIO_STREAM_ERROR) AgoraJson.GetData<int>(data, "error")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteAudioStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRemoteAudioStateChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (REMOTE_AUDIO_STATE) AgoraJson.GetData<int>(data, "state"),
                                (REMOTE_AUDIO_STATE_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (int) AgoraJson.GetData<int>(data, "elapsed")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioPublishStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioPublishStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoPublishStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnVideoPublishStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioSubscribeStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioSubscribeStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoSubscribeStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnVideoSubscribeStateChanged(
                                (string) AgoraJson.GetData<string>(data, "channel"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "oldState"),
                                (STREAM_SUBSCRIBE_STATE) AgoraJson.GetData<int>(data, "newState"),
                                (int) AgoraJson.GetData<int>(data, "elapseSinceLastState")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioVolumeIndication":
                    var speakerNumber = (uint) AgoraJson.GetData<uint>(data, "speakerNumber");
                    var speakers = AgoraJson.JsonToStructArray<AudioVolumeInfo>(data, "speakers", speakerNumber);
                    var totalVolume = (int) AgoraJson.GetData<int>(data, "totalVolume");
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioVolumeIndication(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                speakers,
                                speakerNumber,
                                totalVolume
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onActiveSpeaker":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnActiveSpeaker((uint) AgoraJson.GetData<uint>(data, "userId"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoStopped":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnVideoStopped();
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onFirstLocalVideoFrame":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        // if (EngineEventHandler != null)
                        // {
                        //     EngineEventHandler.OnFirstLocalVideoFrame(
                        //         AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                        //         (int) AgoraJson.GetData<int>(data, "width"),
                        //         (int) AgoraJson.GetData<int>(data, "height"),
                        //         (int) AgoraJson.GetData<int>(data, "elapsed")
                        //     );
                        // }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onFirstLocalVideoFramePublished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnFirstLocalVideoFramePublished(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (int) AgoraJson.GetData<int>(data, "elapsed"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onFirstRemoteVideoDecoded":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnFirstRemoteVideoDecoded(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "elapsed")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onFirstRemoteVideoFrame":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            // EngineEventHandler.OnFirstRemoteVideoFrame(
                            //     AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                            //     (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                            //     (int) AgoraJson.GetData<int>(data, "width"),
                            //     (int) AgoraJson.GetData<int>(data, "height"),
                            //     (int) AgoraJson.GetData<int>(data, "elapsed")
                            // );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserMuteVideo":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnUserMuteVideo(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (bool) AgoraJson.GetData<bool>(data, "muted")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserEnableVideo":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnUserEnableVideo(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioDeviceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioDeviceStateChanged(
                                (string) AgoraJson.GetData<string>(data, "deviceId"),
                                (int) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "deviceState")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioDeviceVolumeChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioDeviceVolumeChanged(
                                (MEDIA_DEVICE_TYPE) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "volume"),
                                (bool) AgoraJson.GetData<bool>(data, "muted")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onCameraReady":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnCameraReady();
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onCameraFocusAreaChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnCameraFocusAreaChanged(
                                (int) AgoraJson.GetData<int>(data, "x"),
                                (int) AgoraJson.GetData<int>(data, "y"), 
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onFacePositionChanged":
                    var numFaces = (int) AgoraJson.GetData<int>(data, "numFaces");
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnFacePositionChanged(
                                (int) AgoraJson.GetData<int>(data, "imageWidth"),
                                (int) AgoraJson.GetData<int>(data, "imageHeight"),
                                AgoraJson.JsonToStruct<Rectangle>(
                                    (string) AgoraJson.GetData<string>(data, "vecRectangle")),
                                AgoraJson.JsonToStructArray<int>(data, "vecDistance", (uint) numFaces), numFaces);
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onCameraExposureAreaChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnCameraExposureAreaChanged(
                                (int) AgoraJson.GetData<int>(data, "x"),
                                (int) AgoraJson.GetData<int>(data, "y"), 
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioMixingFinished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioMixingFinished();
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioMixingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioMixingStateChanged(
                                (AUDIO_MIXING_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                                (AUDIO_MIXING_ERROR_TYPE) AgoraJson.GetData<int>(data, "errorCode")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioEffectFinished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioEffectFinished(
                                (int) AgoraJson.GetData<int>(data, "soundId")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoDeviceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnVideoDeviceStateChanged(
                                (string) AgoraJson.GetData<string>(data, "deviceId"),
                                (int) AgoraJson.GetData<int>(data, "deviceType"),
                                (int) AgoraJson.GetData<int>(data, "deviceState")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLocalVideoStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLocalVideoStateChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (LOCAL_VIDEO_STREAM_STATE) AgoraJson.GetData<int>(data, "state"),
                                (LOCAL_VIDEO_STREAM_ERROR) AgoraJson.GetData<int>(data, "errorCode")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoSizeChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnVideoSizeChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height"),
                                (int) AgoraJson.GetData<int>(data, "rotation")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteVideoStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRemoteVideoStateChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (REMOTE_VIDEO_STATE) AgoraJson.GetData<int>(data, "state"),
                                (REMOTE_VIDEO_STATE_REASON) AgoraJson.GetData<int>(data, "reason"),
                                (int) AgoraJson.GetData<int>(data, "elapsed")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserEnableLocalVideo":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnUserEnableLocalVideo(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (bool) AgoraJson.GetData<bool>(data, "enabled")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onStreamMessageError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnStreamMessageError(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (int) AgoraJson.GetData<int>(data, "streamId"),
                                (int) AgoraJson.GetData<int>(data, "code"),
                                (int) AgoraJson.GetData<int>(data, "missed"),
                                (int) AgoraJson.GetData<int>(data, "cached")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onChannelMediaRelayStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnChannelMediaRelayStateChanged(
                                (int) AgoraJson.GetData<int>(data, "state"),
                                (int) AgoraJson.GetData<int>(data, "code")  // int ?
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onChannelMediaRelayEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnChannelMediaRelayEvent(
                                (int) AgoraJson.GetData<int>(data, "code") // int ?
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onFirstLocalAudioFramePublished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnFirstLocalAudioFramePublished(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (int) AgoraJson.GetData<int>(data, "elapsed")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRtmpStreamingStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRtmpStreamingStateChanged(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (RTMP_STREAM_PUBLISH_STATE) AgoraJson.GetData<int>(data, "state"),
                                (RTMP_STREAM_PUBLISH_ERROR) AgoraJson.GetData<int>(data, "errCode")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onStreamPublished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnStreamPublished(
                                (string) AgoraJson.GetData<string>(data, "url"),
                                (int) AgoraJson.GetData<int>(data, "error")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onStreamUnpublished":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnStreamUnpublished(
                                (string) AgoraJson.GetData<string>(data, "url")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onTranscodingUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnTranscodingUpdated();
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;

                case "onLocalPublishFallbackToAudioOnly":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLocalPublishFallbackToAudioOnly(
                                (bool) AgoraJson.GetData<bool>(data, "isFallbackOrRecover")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRemoteSubscribeFallbackToAudioOnly(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (bool) AgoraJson.GetData<bool>(data, "isFallbackOrRecover")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteAudioTransportStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRemoteAudioTransportStats(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (UInt16) AgoraJson.GetData<UInt16>(data, "delay"),
                                (UInt16) AgoraJson.GetData<UInt16>(data, "lost"),
                                (UInt16) AgoraJson.GetData<UInt16>(data, "rxKBitRate")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRemoteVideoTransportStats":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRemoteVideoTransportStats(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (UInt16) AgoraJson.GetData<UInt16>(data, "delay"),
                                (UInt16) AgoraJson.GetData<UInt16>(data, "lost"),
                                (UInt16) AgoraJson.GetData<UInt16>(data, "rxKBitRate")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onConnectionStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnConnectionStateChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (CONNECTION_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                                (CONNECTION_CHANGED_REASON_TYPE) AgoraJson.GetData<int>(data, "reason")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onNetworkTypeChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnNetworkTypeChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (NETWORK_TYPE) AgoraJson.GetData<int>(data, "type")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onLocalUserRegistered":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnLocalUserRegistered(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                (string) AgoraJson.GetData<string>(data, "userAccount")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUserInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnUserInfoUpdated(
                                (uint) AgoraJson.GetData<uint>(data, "uid"),
                                AgoraJson.JsonToStruct<UserInfo>(data, "info")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onMediaDeviceChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnMediaDeviceChanged(
                                (int) AgoraJson.GetData<int>(data, "deviceType")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onIntraRequestReceived":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnIntraRequestReceived(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onUplinkNetworkInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnUplinkNetworkInfoUpdated(
                                AgoraJson.JsonToStruct<UplinkNetworkInfo>(data, "info")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onDownlinkNetworkInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnDownlinkNetworkInfoUpdated(
                                AgoraJson.JsonToStruct<DownlinkNetworkInfo>(data, "info")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onVideoSourceFrameSizeChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnVideoSourceFrameSizeChanged(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (VIDEO_SOURCE_TYPE) AgoraJson.GetData<int>(data, "sourceType"),
                                (int) AgoraJson.GetData<int>(data, "width"),
                                (int) AgoraJson.GetData<int>(data, "height")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onEncryptionError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnEncryptionError(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (ENCRYPTION_ERROR_TYPE) AgoraJson.GetData<int>(data, "info")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioRoutingChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioRoutingChanged(
                                (int) AgoraJson.GetData<int>(data, "routing")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioSessionRestrictionResume":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnAudioSessionRestrictionResume();
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onPermissionError":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnPermissionError(
                                (PERMISSION_TYPE) AgoraJson.GetData<int>(data, "permissionType")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onExtensionEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnExtensionEvent(
                                (string) AgoraJson.GetData<string>(data, "provider"),
                                (string) AgoraJson.GetData<string>(data, "extension"),
                                (string) AgoraJson.GetData<string>(data, "key"),
                                (string) AgoraJson.GetData<string>(data, "value")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onExtensionStarted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnExtensionStarted(
                                (string) AgoraJson.GetData<string>(data, "provider"),
                                (string) AgoraJson.GetData<string>(data, "extension")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onExtensionStopped":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnExtensionStopped(
                                (string) AgoraJson.GetData<string>(data, "provider"),
                                (string) AgoraJson.GetData<string>(data, "extension")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
//                 case "onExtensionErrored":
// #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
//                     CallbackObject._CallbackQueue.EnQueue(() =>
//                     {
// #endif
//                         if (EngineEventHandler != null)
//                         {
//                             EngineEventHandler.OnExtensionErrored(
//                                 (string) AgoraJson.GetData<int>(data, "provider"),
//                                 (string) AgoraJson.GetData<int>(data, "extension"),
//                                 (int) AgoraJson.GetData<int>(data, "error"),
//                                 (string) AgoraJson.GetData<int>(data, "msg")
//                             );
//                         }
// #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
//                     });
// #endif
//                     break;
                case "onUserAccountUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnUserAccountUpdated(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (string) AgoraJson.GetData<string>(data, "userAccount")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onRhythmPlayerStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnRhythmPlayerStateChanged(
                                (RHYTHM_PLAYER_STATE_TYPE) AgoraJson.GetData<uint>(data, "state"),
                                (RHYTHM_PLAYER_ERROR_TYPE) AgoraJson.GetData<uint>(data, "errorCode")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
//                 case "onUserMuteAudio":
// #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
//                     CallbackObject._CallbackQueue.EnQueue(() =>
//                     {
// #endif
//                         if (EngineEventHandler != null)
//                         {
//                             EngineEventHandler.OnUserMuteAudio(
//                                 (uint) AgoraJson.GetData<uint>(data, "connId"),
//                                 (uint) AgoraJson.GetData<uint>(data, "uid"),
//                                 (bool) AgoraJson.GetData<bool>(data, "muted")
//                             );
//                         }
// #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
//                     });
// #endif
//                     break;
//                 case "onFirstRemoteAudioFrame":
// #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
//                     CallbackObject._CallbackQueue.EnQueue(() =>
//                     {
// #endif
//                         if (EngineEventHandler != null)
//                         {
//                             EngineEventHandler.OnFirstRemoteAudioFrame(
//                                 AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
//                                 (uint) AgoraJson.GetData<uint>(data, "userId"),
//                                 (int) AgoraJson.GetData<int>(data, "elapsed")
//                             );
//                         }
// #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
//                     });
// #endif
//                     break;
//                 case "onFirstRemoteAudioDecoded":
// #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
//                     CallbackObject._CallbackQueue.EnQueue(() =>
//                     {
// #endif
//                         if (EngineEventHandler != null)
//                         {
//                             EngineEventHandler.OnFirstRemoteAudioDecoded(
//                                 AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
//                                 (uint) AgoraJson.GetData<uint>(data, "uid"),
//                                 (int) AgoraJson.GetData<int>(data, "elapsed")
//                             );
//                         }
// #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
//                     });
// #endif
//                     break;
                 
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_EventWithBuffer_Native))]
#endif
        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer, uint length)
        {
            var byteData = new byte[length];
            if (buffer != IntPtr.Zero) Marshal.Copy(buffer, byteData, 0, (int) length);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            switch (@event)
            {
                case "onStreamMessage":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (EngineEventHandler != null)
                        {
                            EngineEventHandler.OnStreamMessage(
                                AgoraJson.JsonToStruct<RtcConnection>(data, "connection"),
                                (uint) AgoraJson.GetData<uint>(data, "remoteUid"),
                                (int) AgoraJson.GetData<int>(data, "streamId"), byteData, length, 
                                (uint) AgoraJson.GetData<uint>(data, "sentTs"));
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;       
            }
        }

    }
}