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
    using IrisEventHandlerHandleNative = IntPtr;

    //AudioFrameObserver
    using IrisRtcCAudioFrameObserverNativeMarshal = IntPtr;
    using IrisRtcAudioFrameObserverHandleNative = IntPtr;

    //AudioEncodeFrameObserver
    using IrisRtcCAudioEncodeFrameObserverNativeMarshal = IntPtr;
    using IrisRtcAudioEncodeFrameObserverHandleNative = IntPtr;

    //VideoFrameObserver
    using IrisRtcCVideoFrameObserverNativeMarshal = IntPtr;
    using IrisRtcVideoFrameObserverHandleNative = IntPtr;

    //VideoEncodedImageReceiver
    using IrisRtcCVideoEncodedImageReceiverNativeMarshal = IntPtr;
    using IrisRtcVideoEncodedImageReceiverHandleNative = IntPtr;

    using IrisVideoFrameBufferManagerPtr = IntPtr;

    //MetadataObserver
    using IrisRtcCMetaDataObserverNativeMarshal = IntPtr;
    using IrisRtcMetaDataObserverHandleNative = IntPtr;


    public sealed class AgoraRtcEngine : IAgoraRtcEngine
    {
        private bool _disposed = false;
        private static AgoraRtcEngine engineInstance = null;
        private static readonly string identifier = "AgoraRtcEngine";


        private IrisRtcEnginePtr _irisRtcEngine;
        private CharAssistant _result;

        private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
#endif

        private AgoraRtcEngineEventHandler _engineEventHandlerInstance;
        private AgoraRtcVideoDeviceManager _videoDeviceManagerInstance;
        private AgoraRtcAudioPlaybackDeviceManager _audioPlaybackDeviceManagerInstance;
        private AgoraRtcAudioRecordingDeviceManager _audioRecordingDeviceManagerInstance;

        private IrisRtcCAudioFrameObserverNativeMarshal _irisRtcCAudioFrameObserverNative;
        private IrisRtcCAudioFrameObserver _irisRtcCAudioFrameObserver;
        private IrisRtcAudioFrameObserverHandleNative _irisRtcAudioFrameObserverHandleNative;

        //audioEncodedFrameObserver
        private IrisRtcCAudioEncodeFrameObserverNativeMarshal _irisRtcCAudioEncodedFrameObserverNative;
        private IrisRtcCAudioEncodedFrameObserver _irisRtcCAudioEncodedFrameObserver;
        private IrisRtcAudioEncodeFrameObserverHandleNative _irisRtcAudioEncodedFrameObserverHandleNative;

        private IrisRtcCVideoFrameObserverNativeMarshal _irisRtcCVideoFrameObserverNative;
        private IrisRtcCVideoFrameObserver _irisRtcCVideoFrameObserver;
        private IrisRtcVideoFrameObserverHandleNative _irisRtcVideoFrameObserverHandleNative;

        private IrisRtcCVideoEncodedImageReceiverNativeMarshal _irisRtcCVideoEncodedImageReceiverNative;
        private IrisRtcCVideoEncodedImageReceiver _irisRtcCVideoEncodedImageReceiver;
        private IrisRtcVideoEncodedImageReceiverHandleNative _irisRtcVideoEncodedImageReceiverHandleNative;

        private IrisRtcCMetaDataObserverNativeMarshal _irisRtcCMetaDataObserverNative;
        private IrisCMediaMetadataObserver _irisRtcCMetaDataObserver;
        private IrisRtcMetaDataObserverHandleNative _irisRtcMetaDataObserverHandleNative;

        private IrisVideoFrameBufferManagerPtr _videoFrameBufferManagerPtr;

        private AgoraRtcMediaPlayer _mediaPlayerInstance;
        private AgoraRtcCloudSpatialAudioEngine _cloudSpatialAudioEngineInstance;
        private AgoraRtcSpatialAudioEngine _spatialAudioEngineInstance;

        private AgoraRtcEngine()
        {
            _result = new CharAssistant();

            _irisRtcEngine = AgoraRtcNative.CreateIrisApiEngine();

            _videoDeviceManagerInstance = new AgoraRtcVideoDeviceManager(_irisRtcEngine);
            _audioPlaybackDeviceManagerInstance = new AgoraRtcAudioPlaybackDeviceManager(_irisRtcEngine);
            _audioRecordingDeviceManagerInstance = new AgoraRtcAudioRecordingDeviceManager(_irisRtcEngine);
            _mediaPlayerInstance = new AgoraRtcMediaPlayer(_irisRtcEngine);
            //_cloudSpatialAudioEngineInstance = new AgoraRtcCloudSpatialAudioEngine(_irisRtcEngine);
            //_spatialAudioEngineInstance = new AgoraRtcSpatialAudioEngine(_irisRtcEngine);

            _videoFrameBufferManagerPtr = AgoraRtcNative.CreateIrisVideoFrameBufferManager();
            AgoraRtcNative.Attach(_irisRtcEngine, _videoFrameBufferManagerPtr);

            CreateEventHandler();
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
                UnSetIrisMetaDataObserver();
                UnSetIrisAudioEncodedFrameObserver();

                _videoDeviceManagerInstance.Dispose();
                _videoDeviceManagerInstance = null;

                _audioPlaybackDeviceManagerInstance.Dispose();
                _audioPlaybackDeviceManagerInstance = null;

                _audioRecordingDeviceManagerInstance.Dispose();
                _audioRecordingDeviceManagerInstance = null;

                _mediaPlayerInstance.Dispose();
                _mediaPlayerInstance = null;

                //_cloudSpatialAudioEngineInstance.Dispose();
                _cloudSpatialAudioEngineInstance = null;
                _spatialAudioEngineInstance = null;

                AgoraRtcNative.Detach(_irisRtcEngine, _videoFrameBufferManagerPtr);
            }

            Release(sync);
            AgoraRtcNative.FreeIrisVideoFrameBufferManager(_videoFrameBufferManagerPtr);
            _disposed = true;
        }

        private void Release(bool sync = false)
        {
            var param = new
            {
                sync
            };

            string json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            AgoraRtcNative.CallIrisApi(
                _irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RELEASE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            AgoraRtcNative.DestroyIrisApiEngine(_irisRtcEngine);
            _irisRtcEngine = IntPtr.Zero;
            _result = new CharAssistant();

            engineInstance = null;
        }

        private void CreateEventHandler()
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
            _engineEventHandlerInstance = AgoraRtcEngineEventHandler.GetInstance();
            RtcEngineEventHandlerNative.EngineEventHandler = _engineEventHandlerInstance;
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
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_INITIALIZE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

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

        public override AgoraRtcEngineEventHandler GetAgoraRtcEngineEventHandler()
        {
            return _engineEventHandlerInstance;
        }

        public override void InitEventHandler(IAgoraRtcEngineEventHandler engineEventHandler)
        {
            RtcEngineEventHandlerNative.EngineEventHandler = engineEventHandler;
        }

        public override void RemoveEventHandler(IAgoraRtcEngineEventHandler engineEventHandler)
        {
            RtcEngineEventHandlerNative.EngineEventHandler = null;
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
                _irisRtcEngine,
                _irisRtcCAudioFrameObserverNative, 0, identifier
            );
        }

        private void UnSetIrisAudioFrameObserver()
        {
            if (_irisRtcAudioFrameObserverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterAudioFrameObserver(
                _irisRtcEngine,
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
                IsMultipleChannelFrameWanted = AgoraRtcVideoFrameObserverNative.IsMultipleChannelFrameWanted
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
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCVideoFrameObserver.IsMultipleChannelFrameWanted)
            };

            _irisRtcCVideoFrameObserverNative =
                Marshal.AllocHGlobal(Marshal.SizeOf(irisRtcCVideoFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisRtcCVideoFrameObserverNativeLocal, _irisRtcCVideoFrameObserverNative, true);

            _irisRtcVideoFrameObserverHandleNative = AgoraRtcNative.RegisterVideoFrameObserver(
                _irisRtcEngine, _irisRtcCVideoFrameObserverNative, 0,
                identifier);
        }

        private void UnSetIrisVideoFrameObserver()
        {
            if (_irisRtcVideoFrameObserverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterVideoFrameObserver(_irisRtcEngine,
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
                _irisRtcEngine, _irisRtcCVideoEncodedImageReceiverNative, 0,
                identifier);
        }

        private void UnSetIrisVideoEncodedImageReceiver()
        {
            if (_irisRtcVideoEncodedImageReceiverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterVideoEncodedImageReceiver(_irisRtcEngine,
                _irisRtcVideoEncodedImageReceiverHandleNative, identifier);
            _irisRtcVideoEncodedImageReceiverHandleNative = IntPtr.Zero;
            AgoraRtcVideoEncodedImageReceiver.VideoEncodedImageReceiver = null;
            _irisRtcCVideoEncodedImageReceiver = new IrisRtcCVideoEncodedImageReceiver();
            Marshal.FreeHGlobal(_irisRtcCVideoEncodedImageReceiverNative);
        }

        private void SetIrisMetaDataObserver(METADATA_TYPE type)
        {
            if (_irisRtcMetaDataObserverHandleNative != IntPtr.Zero) return;

            _irisRtcCMetaDataObserver = new IrisCMediaMetadataObserver
            {
                GetMaxMetadataSize = MetadataObserver.GetMaxMetadataSize,
                OnReadyToSendMetadata = MetadataObserver.OnReadyToSendMetadata,
                OnMetadataReceived = MetadataObserver.OnMetadataReceived
            };

            var irisRtcCMetaDataObserverNativeLocal = new IrisCMediaMetadataObserverNative
            {
                getMaxMetadataSize =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCMetaDataObserver.GetMaxMetadataSize),
                onReadyToSendMetadata =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCMetaDataObserver.OnReadyToSendMetadata),
                onMetadataReceived =
                    Marshal.GetFunctionPointerForDelegate(_irisRtcCMetaDataObserver.OnMetadataReceived)
            };

            _irisRtcCMetaDataObserverNative =
                Marshal.AllocHGlobal(Marshal.SizeOf(irisRtcCMetaDataObserverNativeLocal));
            Marshal.StructureToPtr(irisRtcCMetaDataObserverNativeLocal, _irisRtcCMetaDataObserverNative, true);

            var param = new
            {
                type
            };
            var json = JsonMapper.ToJson(param);
            _irisRtcMetaDataObserverHandleNative = AgoraRtcNative.RegisterMediaMetadataObserver(_irisRtcEngine,
                _irisRtcCMetaDataObserverNative, json);
        }

        private void UnSetIrisMetaDataObserver()
        {
            if (_irisRtcMetaDataObserverHandleNative == IntPtr.Zero) return;

            AgoraRtcNative.UnRegisterMediaMetadataObserver(_irisRtcEngine, _irisRtcMetaDataObserverHandleNative);
            _irisRtcMetaDataObserverHandleNative = IntPtr.Zero;
            MetadataObserver.Observer = null;
            _irisRtcCMetaDataObserver = new IrisCMediaMetadataObserver();
            Marshal.FreeHGlobal(_irisRtcCMetaDataObserverNative);
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

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        internal IVideoStreamManager GetVideoStreamManager()
        {
           return new VideoStreamManager(this);
        }
#endif

        public override string GetVersion()
        {
            var param = new { };
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETVERSION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? null : (string)AgoraJson.GetData<string>(_result.Result, "result");
        }

        public override string GetErrorDescription(int code)
        {
            var param = new { };
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETERRORDESCRIPTION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? null : (string)AgoraJson.GetData<string>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNEL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNEL2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateChannelMediaOptions(ChannelMediaOptions options)
        {
            var param = new
            {
                options
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATECHANNELMEDIAOPTIONS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int LeaveChannel()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_LEAVECHANNEL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int LeaveChannel(LeaveChannelOptions options)
        {
            var param = new
            {
                options
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_LEAVECHANNEL2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int RenewToken(string token)
        {
            var param = new
            {
                token
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RENEWTOKEN,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            var param = new
            {
                profile
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCHANNELPROFILE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            var param = new
            {
                role
            };
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCLIENTROLE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role, ref ClientRoleOptions options)
        {
            var param = new
            {
                role,
                options
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCLIENTROLE2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public override int StartEchoTest()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTECHOTEST,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartEchoTest(int intervalInSeconds)
        {
            var param = new
            {
                intervalInSeconds
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTECHOTEST2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");

        }

        public override int StopEchoTest()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPECHOTEST,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableVideo()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEVIDEO,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int DisableVideo()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_DISABLEVIDEO,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartPreview()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPREVIEW,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            var param = new
            {
                sourceType
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPREVIEW2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopPreview()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPREVIEW,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            var param = new
            {
                sourceType
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPREVIEW2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public override int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTLASTMILEPROBETEST,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopLastmileProbeTest()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPLASTMILEPROBETEST,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVIDEOENCODERCONFIGURATION,
              json, jsonLength,
              IntPtr.Zero, 0,
              out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetBeautyEffectOptions(bool enabled, BeautyOptions options)
        {
            var param = new
            {
                enabled,
                options
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETBEAUTYEFFECTOPTIONS,
              json, jsonLength,
              IntPtr.Zero, 0,
              out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableAudio()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEAUDIO,
              json, jsonLength,
              IntPtr.Zero, 0,
              out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public override int DisableAudio()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_DISABLEAUDIO,
              json, jsonLength,
              IntPtr.Zero, 0,
              out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            var param = new
            {
                profile,
                scenario
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOPROFILE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            var param = new
            {
                profile
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOPROFILE2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableLocalAudio(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLELOCALAUDIO,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            var param = new
            {
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTELOCALAUDIOSTREAM,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTEALLREMOTEAUDIOSTREAMS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEAUDIOSTREAMS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteRemoteAudioStream(uint uid, bool mute)
        {
            var param = new
            {
                uid,
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTEREMOTEAUDIOSTREAM,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteLocalVideoStream(bool mute)
        {
            var param = new
            {
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTELOCALVIDEOSTREAM,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableLocalVideo(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLELOCALVIDEO,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteAllRemoteVideoStreams(bool mute)
        {
            var param = new
            {
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTEALLREMOTEVIDEOSTREAMS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            var param = new
            {
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEVIDEOSTREAMS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteRemoteVideoStream(uint uid, bool mute)
        {
            var param = new
            {
                uid,
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTEREMOTEVIDEOSTREAM,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            var param = new
            {
                uid,
                streamType
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEVIDEOSTREAMTYPE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            var param = new
            {
                streamType
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEDEFAULTVIDEOSTREAMTYPE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            var param = new
            {
                interval,
                smooth,
                reportVad
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEAUDIOVOLUMEINDICATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartAudioRecording(string filePath,
                                        AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            var param = new
            {
                filePath,
                quality
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIORECORDING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIORECORDING2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartAudioRecording(AudioRecordingConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIORECORDING3,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override void RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAgoraRtcAudioEncodedFrameObserver observer)
        {
            SetIrisAudioEncodedFrameObserver(config);
            AgoraRtcAudioEncodedFrameObserverNative.AudioEncodedFrameObserver = observer;
        }

        public override void UnRegisterAudioEncodedFrameObserver()
        {
            UnSetIrisAudioEncodedFrameObserver();
        }

        private void SetIrisAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config)
        {
            if (_irisRtcAudioEncodedFrameObserverHandleNative != IntPtr.Zero) return;

            _irisRtcCAudioEncodedFrameObserver = new IrisRtcCAudioEncodedFrameObserver
            {
                OnRecordAudioEncodedFrame = AgoraRtcAudioEncodedFrameObserverNative.OnRecordAudioEncodedFrame,
                OnPlaybackAudioEncodedFrame = AgoraRtcAudioEncodedFrameObserverNative.OnPlaybackAudioEncodedFrame,
                OnMixedAudioEncodedFrame = AgoraRtcAudioEncodedFrameObserverNative.OnMixedAudioEncodedFrame
            };

            var _irisRtcCAudioEncodeFrameObserverNativeLocal = new IrisRtcCAudioEncodedFrameObserverNative
            {
                OnRecordAudioEncodedFrame = Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioEncodedFrameObserver.OnRecordAudioEncodedFrame),
                OnPlaybackAudioEncodedFrame = Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioEncodedFrameObserver.OnPlaybackAudioEncodedFrame),
                OnMixedAudioEncodedFrame = Marshal.GetFunctionPointerForDelegate(_irisRtcCAudioEncodedFrameObserver.OnMixedAudioEncodedFrame),
            };

            _irisRtcCAudioEncodedFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(_irisRtcCAudioEncodeFrameObserverNativeLocal));
            Marshal.StructureToPtr(_irisRtcCAudioEncodeFrameObserverNativeLocal, _irisRtcCAudioEncodedFrameObserverNative, true);

            var param = LitJson.JsonMapper.ToJson(config);
            _irisRtcAudioEncodedFrameObserverHandleNative = AgoraRtcNative.RegisterAudioEncodedFrameObserver(
                _irisRtcEngine,
                _irisRtcCAudioEncodedFrameObserverNative,
                param
             );
        }

        private void UnSetIrisAudioEncodedFrameObserver()
        {
            if (_irisRtcCAudioEncodedFrameObserverNative == null) return;

            AgoraRtcNative.UnRegisterAudioEncodedFrameObserver(
                 _irisRtcEngine,
                 _irisRtcAudioEncodedFrameObserverHandleNative,
                 identifier
            );
            _irisRtcAudioEncodedFrameObserverHandleNative = IntPtr.Zero;
            AgoraRtcAudioEncodedFrameObserverNative.AudioEncodedFrameObserver = null;
            Marshal.FreeHGlobal(_irisRtcCAudioEncodedFrameObserverNative);
            _irisRtcCAudioEncodedFrameObserverNative = IntPtr.Zero;
            _irisRtcCAudioEncodedFrameObserver = new IrisRtcCAudioEncodedFrameObserver();
        }


        public override int StopAudioRecording()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPAUDIORECORDING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIOMIXING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int startPos)
        {
            var param = new
            {
                filePath,
                loopback,
                replace,
                cycle,
                startPos
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIOMIXING2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public override int StopAudioMixing()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPAUDIOMIXING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PauseAudioMixing()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEAUDIOMIXING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ResumeAudioMixing()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEAUDIOMIXING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustAudioMixingVolume(int volume)
        {
            var param = new
            {
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTAUDIOMIXINGVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustAudioMixingPublishVolume(int volume)
        {
            var param = new
            {
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTAUDIOMIXINGPUBLISHVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetAudioMixingPublishVolume()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOMIXINGPUBLISHVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustAudioMixingPlayoutVolume(int volume)
        {
            var param = new
            {
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTAUDIOMIXINGPLAYOUTVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetAudioMixingPlayoutVolume()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOMIXINGPLAYOUTVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetAudioMixingDuration()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOMIXINGDURATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetAudioMixingCurrentPosition()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOMIXINGCURRENTPOSITION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAudioMixingPosition(int pos /*in ms*/)
        {
            var param = new
            {
                pos
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOMIXINGPOSITION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAudioMixingPitch(int pitch)
        {
            var param = new
            {
                pitch
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOMIXINGPITCH,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetEffectsVolume()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETEFFECTSVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetEffectsVolume(int volume)
        {
            var param = new
            {
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEFFECTSVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            var param = new
            {
                soundId,
                filePath,
                startPos
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PRELOADEFFECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PLAYEFFECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PLAYALLEFFECTS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetVolumeOfEffect(int soundId)
        {
            var param = new
            {
                soundId
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETVOLUMEOFEFFECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetVolumeOfEffect(int soundId, int volume)
        {
            var param = new
            {
                soundId,
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOLUMEOFEFFECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PauseEffect(int soundId)
        {
            var param = new
            {
                soundId
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEEFFECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PauseAllEffects()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEALLEFFECTS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ResumeEffect(int soundId)
        {
            var param = new
            {
                soundId
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEEFFECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ResumeAllEffects()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEALLEFFECTS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopEffect(int soundId)
        {
            var param = new
            {
                soundId
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPEFFECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopAllEffects()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPALLEFFECTS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UnloadEffect(int soundId)
        {
            var param = new
            {
                soundId
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNLOADEFFECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UnloadAllEffects()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNLOADALLEFFECTS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableSoundPositionIndication(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLESOUNDPOSITIONINDICATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            var param = new
            {
                uid,
                pan,
                gain
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEVOICEPOSITION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableSpatialAudio(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLESPATIALAUDIO,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            var param = new
            {
                preset
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOICEBEAUTIFIERPRESET,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            var param = new
            {
                preset
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOEFFECTPRESET,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            var param = new
            {
                preset
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOICECONVERSIONPRESET,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            var param = new
            {
                preset,
                param1,
                param2
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOEFFECTPARAMETERS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOICEBEAUTIFIERPARAMETERS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOICECONVERSIONPARAMETERS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLocalVoicePitch(double pitch)
        {
            var param = new
            {
                pitch
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVOICEPITCH,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency,
                                              int bandGain)
        {
            var param = new
            {
                bandFrequency,
                bandGain
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVOICEEQUALIZATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            var param = new
            {
                reverbKey,
                value
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVOICEREVERB,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        //todo not found in dcg
        //public override int SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset)
        //{
        //    var param = new
        //    {
        //        reverbPreset
        //    };

        //    var json = JsonMapper.ToJson(param);
        //    var jsonLength = Convert.ToUInt64(json.Length);
        //    return AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVOICEREVERB,
        //        json, jsonLength,
        //        IntPtr.Zero, 0,
        //        out _result);
        //}

        //todo not found in dcg
        //public override int SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger)
        //{
        //    var param = new
        //    {
        //        voiceChanger
        //    };

        //    var json = JsonMapper.ToJson(param);
        //    var jsonLength = Convert.ToUInt64(json.Length);
        //    return AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVOICEREVERB,
        //        json, jsonLength,
        //        IntPtr.Zero, 0,
        //        out _result);
        //}

        public override int SetLogFile(string filePath)
        {
            var param = new
            {
                filePath
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOGFILE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");

        }

        public override int SetLogFilter(uint filter)
        {
            var param = new
            {
                filter
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOGFILTER,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLogLevel(LOG_LEVEL level)
        {
            var param = new
            {
                level
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOGLEVEL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLogFileSize(uint fileSizeInKBytes)
        {
            var param = new
            {
                fileSizeInKBytes
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOGFILESIZE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                renderMode,
                mirrorMode
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALRENDERMODE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTERENDERMODE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            var param = new
            {
                renderMode,
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALRENDERMODE2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var param = new
            {
                mirrorMode
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVIDEOMIRRORMODE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableDualStreamMode(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEDUALSTREAMMODE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled)
        {
            var param = new
            {
                sourceType,
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEDUALSTREAMMODE2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig)
        {
            var param = new
            {
                sourceType,
                enabled,
                streamConfig
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEDUALSTREAMMODE3,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetExternalAudioSink(int sampleRate, int channels)
        {
            var param = new
            {
                sampleRate,
                channels
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_SETEXTERNALAUDIOSINK,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartPrimaryCustomAudioTrack(AudioTrackConfig config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPRIMARYCUSTOMAUDIOTRACK,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopPrimaryCustomAudioTrack()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPRIMARYCUSTOMAUDIOTRACK,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartSecondaryCustomAudioTrack(AudioTrackConfig config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSECONDARYCUSTOMAUDIOTRACK,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopSecondaryCustomAudioTrack()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPSECONDARYCUSTOMAUDIOTRACK,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETRECORDINGAUDIOFRAMEPARAMETERS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETPLAYBACKAUDIOFRAMEPARAMETERS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            var param = new
            {
                sampleRate,
                channel,
                samplesPerCall
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETMIXEDAUDIOFRAMEPARAMETERS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            var param = new
            {
                sampleRate,
                channel
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETPLAYBACKAUDIOFRAMEBEFOREMIXINGPARAMETERS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            var param = new
            {
                intervalInMS
            };


            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEAUDIOSPECTRUMMONITOR,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int DisableAudioSpectrumMonitor()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_DISABLEAUDIOSPECTRUMMONITOR,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override void RegisterAudioSpectrumObserver(IAgoraRtcAudioSpectrumObserver observer)
        {
            //todo wait for capi
            AgoraRtcAudioSpectrumObserverNative.AgoraRtcAudioSpectrumObserver = observer;
        }

        public override void UnregisterAudioSpectrumObserver(IAgoraRtcAudioSpectrumObserver observer)
        {
            //todo wait for capi
            AgoraRtcAudioSpectrumObserverNative.AgoraRtcAudioSpectrumObserver = null;
        }

        public override int AdjustRecordingSignalVolume(int volume)
        {
            var param = new
            {
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTRECORDINGSIGNALVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteRecordingSignal(bool mute)
        {
            var param = new
            {
                mute
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTERECORDINGSIGNAL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustPlaybackSignalVolume(int volume)
        {
            var param = new
            {
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTPLAYBACKSIGNALVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            var param = new
            {
                uid,
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTUSERPLAYBACKSIGNALVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableLoopbackRecording(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLELOOPBACKRECORDING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustLoopbackRecordingVolume(int volume)
        {
            var param = new
            {
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTLOOPBACKRECORDINGVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetLoopbackRecordingVolume()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETLOOPBACKRECORDINGVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            var param = new
            {
                enabled,
                includeAudioFilters
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEINEARMONITORING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetInEarMonitoringVolume(int volume)
        {
            var param = new
            {
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETINEARMONITORINGVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int LoadExtensionProvider(string extension_lib_path)
        {
            var param = new
            {
                extension_lib_path
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_LOADEXTENSIONPROVIDER,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetExtensionProviderProperty(string provider, string key, string value)
        {
            var param = new
            {
                provider,
                key,
                value
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEXTENSIONPROVIDERPROPERTY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableExtension(
          string provider, string extension, bool enable = true)
        {
            var param = new
            {
                provider,
                extension,
                enable
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEEXTENSION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEXTENSIONPROPERTY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetExtensionProperty(
          string provider, string extension,
          string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            var param = new
            {
                provider,
                extension,
                key,
                value,
                buf_len,
                type
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETEXTENSIONPROPERTY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            if (nRet == 0)
            {

                value = (string)AgoraJson.GetData<string>(_result.Result, "value");
            }
            else
            {
                value = "";
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERACAPTURERCONFIGURATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SwitchCamera()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SWITCHCAMERA,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override bool IsCameraZoomSupported()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAZOOMSUPPORTED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public override bool IsCameraFaceDetectSupported()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAFACEDETECTSUPPORTED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public override bool IsCameraTorchSupported()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERATORCHSUPPORTED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public override bool IsCameraFocusSupported()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAFOCUSSUPPORTED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public override bool IsCameraAutoFocusFaceModeSupported()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAAUTOFOCUSFACEMODESUPPORTED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public override int SetCameraZoomFactor(float factor)
        {
            var param = new
            {
                factor
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAZOOMFACTOR,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableFaceDetection(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEFACEDETECTION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override float GetCameraMaxZoomFactor()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETCAMERAMAXZOOMFACTOR,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            var param = new
            {
                positionX,
                positionY
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAFOCUSPOSITIONINPREVIEW,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetCameraTorchOn(bool isOn)
        {
            var param = new
            {
                isOn
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERATORCHON,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAAUTOFOCUSFACEMODEENABLED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public override bool IsCameraExposurePositionSupported()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAEXPOSUREPOSITIONSUPPORTED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_result.Result, "result");
        }


        public override int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            var param = new
            {
                positionXinView,
                positionYinView
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAEXPOSUREPOSITION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override bool IsCameraAutoExposureFaceModeSupported()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAAUTOEXPOSUREFACEMODESUPPORTED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public override int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAAUTOEXPOSUREFACEMODEENABLED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            var param = new
            {
                defaultToSpeaker
            };


            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDEFAULTAUDIOROUTETOSPEAKERPHONE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetEnableSpeakerphone(bool speakerOn)
        {
            var param = new
            {
                speakerOn
            };


            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETENABLESPEAKERPHONE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override bool IsSpeakerphoneEnabled()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISSPEAKERPHONEENABLED,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_result.Result, "result");
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


            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTUREBYDISPLAYID,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTUREBYSCREENRECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTUREBYWINDOWID,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            var param = new
            {
                contentHint
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSCREENCAPTURECONTENTHINT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            var param = new
            {
                regionRect
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATESCREENCAPTUREREGION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                captureParams
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATESCREENCAPTUREPARAMETERS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopScreenCapture()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPSCREENCAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override string GetCallId()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETCALLID,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? null : (string)AgoraJson.GetData<string>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RATE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int Complain(string callId, string description)
        {
            var param = new
            {
                callId,
                description
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_COMPLAIN,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            var param = new
            {
                url,
                transcodingEnabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADDPUBLISHSTREAMURL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int RemovePublishStreamUrl(string url)
        {
            var param = new
            {
                url
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REMOVEPUBLISHSTREAMURL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLiveTranscoding(LiveTranscoding transcoding)
        {
            var param = new
            {
                transcoding
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLIVETRANSCODING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            var param = new
            {
                config
            };


            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTLOCALVIDEOTRANSCODER,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATELOCALTRANSCODERCONFIGURATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopLocalVideoTranscoder()
        {
            var param = new { };


            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPLOCALVIDEOTRANSCODER,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartPrimaryCameraCapture(CameraCapturerConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPRIMARYCAMERACAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartSecondaryCameraCapture(CameraCapturerConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSECONDARYCAMERACAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopPrimaryCameraCapture()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPRIMARYCAMERACAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopSecondaryCameraCapture()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPSECONDARYCAMERACAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            var param = new
            {
                type,
                orientation
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERADEVICEORIENTATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            var param = new
            {
                type,
                orientation
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSCREENCAPTUREORIENTATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartPrimaryScreenCapture(ScreenCaptureConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPRIMARYSCREENCAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartSecondaryScreenCapture(ScreenCaptureConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSECONDARYSCREENCAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopPrimaryScreenCapture()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPRIMARYSCREENCAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopSecondaryScreenCapture()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPSECONDARYSCREENCAPTURE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override CONNECTION_STATE_TYPE GetConnectionState()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETCONNECTIONSTATE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            CONNECTION_STATE_TYPE type = (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(_result.Result, "result");
            return type;
        }

        public override int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            var param = new
            {
                uid,
                userPriority
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEUSERPRIORITY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        // public override int RegisterPacketObserver(IPacketObserver observer)
        // {
        //     //todo 
        //     //var param = new
        //     //{
        //     //    observer
        //     //};
        //     //return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //     //    ApiTypeEngine.kEngineRegisterPacketObserver,
        //     //    JsonMapper.ToJson(param),
        //     //    out _result);
        // }


        public override int SetEncryptionMode(string encryptionMode)
        {
            var param = new
            {
                encryptionMode
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETENCRYPTIONMODE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetEncryptionSecret(string secret)
        {
            var param = new
            {
                secret
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETENCRYPTIONSECRET,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            var param = new
            {
                enabled,
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEENCRYPTION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            var param = new
            {
                reliable,
                ordered
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CREATEDATASTREAM,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_result.Result, "streamId");
            }
            else
            {
                streamId = 0;
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int CreateDataStream(ref int streamId, DataStreamConfig config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CREATEDATASTREAM2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_result.Result, "streamId");
            }
            else
            {
                streamId = 0;
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AddVideoWatermark(RtcImage watermark)
        {
            var param = new
            {
                watermark
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADDVIDEOWATERMARK,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");

        }

        public override int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            var param = new
            {
                watermarkUrl,
                options
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADDVIDEOWATERMARK2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ClearVideoWatermark()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CLEARVIDEOWATERMARK,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ClearVideoWatermarks()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CLEARVIDEOWATERMARKS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            var param = new
            {
                url,
                config
            };
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADDINJECTSTREAMURL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int RemoveInjectStreamUrl(string url)
        {
            var param = new
            {
                url
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REMOVEINJECTSTREAMURL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PauseAudio()
        {
            var param = new { };


            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEAUDIO,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ResumeAudio()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEAUDIO,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableWebSdkInteroperability(bool enabled)
        {
            var param = new
            {
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEWEBSDKINTEROPERABILITY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SENDCUSTOMREPORTMESSAGE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override void RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type)
        {
            SetIrisMetaDataObserver(type);
            MetadataObserver.Observer = observer;
        }

        public override void UnregisterMediaMetadataObserver(IMetadataObserver observer)
        {
            UnSetIrisMetaDataObserver();
        }

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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIOFRAMEDUMP,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopAudioFrameDump(string channel_id, uint user_id, string location)
        {
            var param = new
            {
                channel_id,
                user_id,
                location
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPAUDIOFRAMEDUMP,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int RegisterLocalUserAccount(string appId, string userAccount)
        {
            var param = new
            {
                appId,
                userAccount
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTERLOCALUSERACCOUNT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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


            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNT2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNTEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo)
        {
            var param = new
            {
                userAccount,
                //userInfo,
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETUSERINFOBYUSERACCOUNT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_result.Result, "userInfo");
            }
            else
            {
                userInfo = new UserInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetUserInfoByUid(uint uid, out UserInfo userInfo)
        {
            var param = new
            {
                uid,
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETUSERINFOBYUID,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_result.Result, "userInfo");
            }
            else
            {
                userInfo = new UserInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var param = new
            {
                configuration
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTCHANNELMEDIARELAY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var param = new
            {
                configuration
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATECHANNELMEDIARELAY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopChannelMediaRelay()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPCHANNELMEDIARELAY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            var param = new
            {
                profile
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDIRECTCDNSTREAMINGAUDIOCONFIGURATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDIRECTCDNSTREAMINGVIDEOCONFIGURATION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            var param = new
            {
               options
            };
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTDIRECTCDNSTREAMING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopDirectCdnStreaming()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPDIRECTCDNSTREAMING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        {
            var param = new
            {
               options
            };
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATEDIRECTCDNSTREAMINGMEDIAOPTIONS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)
        {
            var param = new
            {
                token,
                connection,
                options
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_JOINCHANNELEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int LeaveChannelEx(RtcConnection connection)
        {
            var param = new
            {
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_LEAVECHANNELEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            var param = new
            {
                options,
                connection
            };
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_UPDATECHANNELMEDIAOPTIONSEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            var param = new
            {
                config,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETVIDEOENCODERCONFIGURATIONEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            var param = new
            {
                uid,
                mute,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_MUTEREMOTEAUDIOSTREAMEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            var param = new
            {
                uid,
                mute,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_MUTEREMOTEVIDEOSTREAMEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTEVOICEPOSITIONEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection)
        {
            var param1 = new
            {
                uid,
                param,
                connection
            };
            var json = JsonMapper.ToJson(param1);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTEUSERSPATIALAUDIOPARAMSEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTERENDERMODEEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableLoopbackRecordingEx(bool enabled, RtcConnection connection)
        {
            var param = new
            {
                enabled,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ENABLELOOPBACKRECORDINGEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            var param = new
            {
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_GETCONNECTIONSTATEEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            CONNECTION_STATE_TYPE type = (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(_result.Result, "result");
            return type;
        }

        public override int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            var param = new
            {
                connection,
                enabled,
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ENABLEENCRYPTIONEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int CreateDataStreamEx(bool reliable, bool ordered, RtcConnection connection)
        {
            var param = new
            {
                reliable,
                ordered,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_CREATEDATASTREAMEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int CreateDataStreamEx(DataStreamConfig config, RtcConnection connection)
        {
            var param = new
            {
                config,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_CREATEDATASTREAMEX2,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            var param = new
            {
                streamId,
                length,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SENDSTREAMMESSAGEEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            var param = new
            {
                watermarkUrl,
                options,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ADDVIDEOWATERMARKEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ClearVideoWatermarkEx(RtcConnection connection)
        {
            var param = new
            {
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_CLEARVIDEOWATERMARKEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SENDCUSTOMREPORTMESSAGEEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        private int SetAppType(AppType appType)
        {
            var param = new
            {
                appType
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAPPTYPE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType)
        {
            var param = new
            {
                enabled,
                useTexture,
                sourceType
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_SETEXTERNALVIDEOSOURCE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_SETEXTERNALAUDIOSOURCE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        //todo not found in dcg
        //public override int GetCertificateVerifyResult(string credential_buf, int credential_len, string certificate_buf, int certificate_len)
        //{
        //    var param = new
        //    {
        //        credential_buf,
        //        credential_len,
        //        certificate_buf,
        //        certificate_len
        //    };

        //    return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine, ApiTypeEngine.kEngineGetCertificateVerifyResult,
        //        JsonMapper.ToJson(param), out _result);
        //}

        public override int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {

            var param = new
            {
                restriction
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_KEY_ERROR, //todo no key
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustCustomAudioPublishVolume(int sourceId, int volume)
        {
            var param = new
            {
                sourceId,
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTCUSTOMAUDIOPUBLISHVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustCustomAudioPlayoutVolume(int sourceId, int volume)
        {
            var param = new
            {
                sourceId,
                volume
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTCUSTOMAUDIOPLAYOUTVOLUME,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetParameters(string parameters)
        {
            var param = new
            {
                parameters
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_KEY_ERROR,//todo no key
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetAudioDeviceInfo(out DeviceInfo deviceInfo)
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIODEVICEINFO,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            if (nRet == 0)
            {
                deviceInfo = AgoraJson.JsonToStruct<DeviceInfo>(_result.Result, "deviceInfo");
            }
            else
            {
                deviceInfo = new DeviceInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableCustomAudioLocalPlayback(int sourceId, bool enabled)
        {
            var param = new
            {
                sourceId,
                enabled
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLECUSTOMAUDIOLOCALPLAYBACK,//todo two key found.
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource)
        {
            var param = new
            {
                enabled,
                backgroundSource,
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEVIRTUALBACKGROUND,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            var param = new
            {
                option
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALPUBLISHFALLBACKOPTION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            var param = new
            {
                option
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTESUBSCRIBEFALLBACKOPTION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PauseAllChannelMediaRelay()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEALLCHANNELMEDIARELAY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ResumeAllChannelMediaRelay()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEALLCHANNELMEDIARELAY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay)
        {
            var param = new
            {
                enabled,
                audioSourceDelay
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEECHOCANCELLATIONEXTERNAL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int TakeSnapshot(SnapShotConfig config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_TAKESNAPSHOT,
               json, jsonLength,
               IntPtr.Zero, 0,
               out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        //todo  not found in dcg
        //public override int EnableContentInspect(bool enabled, ContentInspectConfig config)
        //{
        //    var param = new
        //    {
        //        enabled,
        //        config
        //    };

        //    var json = JsonMapper.ToJson(param);
        //    var jsonLength = Convert.ToUInt64(json.Length);
        //    var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.ENABLECONTEN,
        //        json, jsonLength,
        //        IntPtr.Zero, 0,
        //        out _result);

        //    return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        //}

        public override int SwitchChannel(string token, string channel)
        {
            var param = new
            {
                token,
                channel
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SWITCHCHANNEL,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SwitchChannel(string token, string channel, ChannelMediaOptions options)
        {
            var param = new
            {
                token,
                channel,
                options
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_KEY_ERROR,//todo no key
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            var param = new
            {
                sound1,
                sound2,
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTRHYTHMPLAYER,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopRhythmPlayer()
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPRHYTHMPLAYER,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CONFIGRHYTHMPLAYER,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param)
        {
            var param1 = new
            {
                uid,
                param
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEUSERSPATIALAUDIOPARAMS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        //todo not found in dcg
        //public override int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        //{
        //    var param = new
        //    {
        //        uid,
        //        options
        //    };

        //    var json = JsonMapper.ToJson(param);
        //    var jsonLength = Convert.ToUInt64(json.Length);
        //    var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.SETREMOTEVIDEOSUB,
        //        json, jsonLength,
        //        IntPtr.Zero, 0,
        //        out _result);

        //    return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        //}

        //todo not found in dcg
        //public override int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        //{
        //    var param = new
        //    {
        //        uid,
        //        options,
        //        connection
        //    };
        //    return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //        ApiTypeEngine.kEngineSetRemoteVideoSubscriptionOptionsEx,
        //        JsonMapper.ToJson(param), out _result);
        //}

        public override int SetDirectExternalAudioSource(bool enable, bool localPlayback)
        {
            var param = new
            {
                enable,
                localPlayback
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_SETDIRECTEXTERNALAUDIOSOURCE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            var param = new
            {
                proxyType
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCLOUDPROXY,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLocalAccessPoint(LocalAccessPointConfiguration config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALACCESSPOINT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableFishCorrection(bool enabled, FishCorrectionParams @params)
        {
            var param = new
            {
                enabled,
                @params
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEFISHCORRECTION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAdvancedAudioOptions(AdvancedAudioOptions options)
        {
            var param = new
            {
                options
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETADVANCEDAUDIOOPTIONS,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAVSyncSource(string channelId, uint uid)
        {
            var param = new
            {
                channelId,
                uid
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAVSYNCSOURCE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartRtmpStreamWithoutTranscoding(string url)
        {
            var param = new
            {
                url
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTRTMPSTREAMWITHOUTTRANSCODING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            var param = new
            {
                url,
                transcoding
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTRTMPSTREAMWITHTRANSCODING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            var param = new
            {
                transcoding
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATERTMPTRANSCODING,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StopRtmpStream(string url)
        {
            var param = new
            {
                url
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPRTMPSTREAM,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetUserInfoByUserAccountEx(string userAccount, out UserInfo userInfo, RtcConnection connection)
        {
            var param = new
            {
                userAccount,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_GETUSERINFOBYUSERACCOUNTEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_result.Result, "userInfo");
            }
            else
            {
                userInfo = new UserInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetUserInfoByUidEx(uint uid, out UserInfo userInfo, RtcConnection connection)
        {
            var param = new
            {
                uid,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_GETUSERINFOBYUIDEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_result.Result, "userInfo");
            }
            else
            {
                userInfo = new UserInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableRemoteSuperResolution(uint userId, bool enable)
        {
            var param = new
            {
                userId,
                enable
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEREMOTESUPERRESOLUTION,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetContentInspect(ContentInspectConfig config)
        {
            var param = new
            {
                config
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCONTENTINSPECT,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)
        {
            var param = new
            {
                uid,
                streamType,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTEVIDEOSTREAMTYPEEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)
        {
            var param = new
            {
                interval,
                smooth,
                reportVad,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ENABLEAUDIOVOLUMEINDICATIONEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetVideoProfileEx(int width, int height, int frameRate, int bitrate)
        {
            var param = new
            {
                width,
                height,
                frameRate,
                bitrate
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETVIDEOPROFILEEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            var param = new
            {
                sourceType,
                enabled,
                streamConfig,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ENABLEDUALSTREAMMODEEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AddPublishStreamUrlEx(string url, bool transcodingEnabled, RtcConnection connection)
        {
            var param = new
            {
                url,
                transcodingEnabled,
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ADDPUBLISHSTREAMURLEX,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UploadLogFile(ref string requestId)
        {
            var param = new { };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPLOADLOGFILE,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result);
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_result.Result, "requestId");
            }
            else
            {
                requestId = "";
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            var param = new
            {
                thumbSize,
                iconSize,
                includeScreen
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            return AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETSCREENCAPTURESOURCES,
                json, jsonLength,
                IntPtr.Zero, 0,
                out _result) != null ?
                new ScreenCaptureSourceInfo[0]
                : AgoraJson.JsonToStructArray<ScreenCaptureSourceInfo>(_result.Result, "result");
        }

        #region CallIrisApiWithBuffer

        public override int SetupRemoteVideo(VideoCanvas canvas)
        {
            var param = new
            {
                canvas = new
                {
                    view = (ulong)canvas.view,
                    canvas.renderMode,
                    canvas.uid,
                    canvas.mirrorMode,
                    canvas.isScreenView,
                    canvas.priv_size,
                    canvas.sourceType
                }
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETUPREMOTEVIDEO,
               json, jsonLength,
               Marshal.UnsafeAddrOfPinnedArrayElement(canvas.priv, 0), 1,
               out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetupLocalVideo(VideoCanvas canvas)
        {
            var param = new
            {
                canvas = new
                {
                    view = (ulong)canvas.view,
                    canvas.renderMode,
                    canvas.uid,
                    canvas.mirrorMode,
                    canvas.isScreenView,
                    canvas.priv_size,
                    canvas.sourceType
                }
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETUPLOCALVIDEO,
               json, jsonLength,
               Marshal.UnsafeAddrOfPinnedArrayElement(canvas.priv, 0), 1,
               out _result);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int StartScreenCapture(byte[] mediaProjectionPermissionResultData,
                                    ScreenCaptureParameters captureParams)
        {
            var param = new
            {
                captureParams
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTURE,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(mediaProjectionPermissionResultData, 0), 1,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            var param = new
            {
                streamId,
                length
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SENDSTREAMMESSAGE,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), 1,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

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
                    frame.timestamp,
                    frame.textureId,
                    frame.metadata_size
                }
            };
            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.buffer, 0);
            IntPtr eglContextPtr = IntPtr.Zero;
            IntPtr metadataPtr = IntPtr.Zero;
            IntPtr[] arrayPtr = new IntPtr[] {bufferPtr, eglContextPtr, metadataPtr};

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PUSHDIRECTCDNSTREAMINGCUSTOMVIDEOFRAME,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 3,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            var param = new
            {
                canvas = new
                {
                    view = (ulong)canvas.view,
                    canvas.renderMode,
                    canvas.uid,
                    canvas.mirrorMode,
                    canvas.isScreenView,
                    canvas.priv_size,
                    canvas.sourceType
                },
                connection
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETUPREMOTEVIDEOEX,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(canvas.priv, 0), 1,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHAUDIOFRAME,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(frame.buffer, 0), 1,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.buffer, 0);
            IntPtr eglContextPtr = IntPtr.Zero;
            IntPtr metadataPtr = IntPtr.Zero;
            IntPtr[] arrayPtr = new IntPtr[] {bufferPtr, eglContextPtr, metadataPtr};

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);

            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHVIDEOFRAME,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 3,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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
            
            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.buffer, 0);
            IntPtr eglContextPtr = IntPtr.Zero;
            IntPtr metadataPtr = IntPtr.Zero;
            IntPtr[] arrayPtr = new IntPtr[] {bufferPtr, eglContextPtr, metadataPtr};

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHVIDEOFRAME2,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 3,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PushEncodedVideoImage(byte[] imageBuffer, uint length,
                                          EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            var param = new
            {
                length,
                videoEncodedFrameInfo
            };

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHENCODEDVIDEOIMAGE,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(imageBuffer, 0), 1,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHENCODEDVIDEOIMAGE2,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(imageBuffer, 0), 1,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
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

            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);
            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHDIRECTAUDIOFRAME,
                json, jsonLength,
                Marshal.UnsafeAddrOfPinnedArrayElement(frame.buffer, 0), 1,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PullAudioFrame(AudioFrame frame)
        {
            var param = new { };
            var json = JsonMapper.ToJson(param);
            var jsonLength = Convert.ToUInt64(json.Length);

            var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PULLAUDIOFRAME,
                json, jsonLength,
                frame.bufferPtr, 1,
                out _result);

            var f = _result.Result.Length == 0
               ? new AudioFrameWithoutBuffer()
               : AgoraJson.JsonToStruct<AudioFrameWithoutBuffer>(_result.Result);
            frame.avsync_type = f.avsync_type;
            frame.channels = f.channels;
            frame.samplesPerChannel = f.samples;
            frame.type = f.type;
            frame.bytesPerSample = f.bytesPerSample;
            frame.renderTimeMs = f.renderTimeMs;
            frame.samplesPerSec = f.samplesPerSec;

            int length = frame.channels * frame.samplesPerChannel * (int)frame.bytesPerSample;
            frame.buffer = new byte[length];
            if (frame.bufferPtr != IntPtr.Zero)
            {
                Marshal.Copy(frame.bufferPtr, frame.buffer, 0, length);
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        #endregion CallIrisApiWithBuffer end

        ~AgoraRtcEngine()
        {
            Dispose(false, false);
        }
    }
}