#define AGORA_RTC
#define AGORA_RTM

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtc
{
    using track_id_t = System.UInt32;
    using IrisRtcEnginePtr = IntPtr;
    using IrisRtcRenderingHandle = IntPtr;
    using view_t = System.Int64;

    internal class RtcEngineImpl
    {
        private bool _disposed = false;
        private static RtcEngineImpl engineInstance = null;

        private IrisRtcEnginePtr _irisRtcEngine;
        private IrisRtcCApiParam _apiParam;

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
#endif
        // DirectCdnStreamingEventHandler
        private RtcEventHandlerHandle _rtcDirectCdnStreamingEventHandle = new RtcEventHandlerHandle();
        // rtcEventHandler
        private RtcEventHandlerHandle _rtcEventHandlerHandle = new RtcEventHandlerHandle();
        // audioFrameObserver
        private RtcEventHandlerHandle _rtcAudioFrameObserverHandle = new RtcEventHandlerHandle();
        // videoFrameObserver
        private RtcEventHandlerHandle _rtcVideoFrameObserverHandle = new RtcEventHandlerHandle();
        // audioEncodedFrameObserver
        private RtcEventHandlerHandle _rtcAudioEncodedFrameObserverHandle = new RtcEventHandlerHandle();
        // videoEncodedFrameObserver
        private RtcEventHandlerHandle _rtcVideoEncodedFrameObserverHandle = new RtcEventHandlerHandle();
        // metaData
        private RtcEventHandlerHandle _rtcMetaDataObserverHandle = new RtcEventHandlerHandle();
        // audioSpectrumOberver
        private RtcEventHandlerHandle _rtcAudioSpectrumObserverHandle = new RtcEventHandlerHandle();

        private IrisRtcRenderingHandle _rtcRenderingHandle;

        private VideoDeviceManagerImpl _videoDeviceManagerInstance;
        private AudioDeviceManagerImpl _audioDeviceManagerInstance;
        private MediaPlayerImpl _mediaPlayerInstance;
        private MusicContentCenterImpl _musicContentCenterImpl;
        private LocalSpatialAudioEngineImpl _spatialAudioEngineInstance;
        private MediaPlayerCacheManagerImpl _mediaPlayerCacheManager;
        private MediaRecorderImpl _mediaRecorderInstance;

#if AGORA_RTM
        private Rtc.StreamChannelImpl _streamChannelInstance;
#endif

        public event Action<RtcEngineImpl> OnRtcEngineImpleWillDispose;

        private RtcEngineImpl(IntPtr nativePtr)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();

            // AgoraRtcNative.CreateApiParamsPtr();
            _irisRtcEngine = AgoraRtcNative.CreateIrisApiEngine(nativePtr);

            _videoDeviceManagerInstance = new VideoDeviceManagerImpl(_irisRtcEngine);
            _audioDeviceManagerInstance = new AudioDeviceManagerImpl(_irisRtcEngine);
            _mediaPlayerInstance = new MediaPlayerImpl(_irisRtcEngine);
            _musicContentCenterImpl = new MusicContentCenterImpl(_irisRtcEngine, _mediaPlayerInstance);
            _spatialAudioEngineInstance = new LocalSpatialAudioEngineImpl(_irisRtcEngine);
            _mediaPlayerCacheManager = new MediaPlayerCacheManagerImpl(_irisRtcEngine);
            _mediaRecorderInstance = new MediaRecorderImpl(_irisRtcEngine);
#if AGORA_RTM
            _streamChannelInstance = new Rtc.StreamChannelImpl(_irisRtcEngine);
#endif

            _rtcRenderingHandle = AgoraRtcNative.CreateIrisRtcRendering(_irisRtcEngine);
        }

        ~RtcEngineImpl()
        {
            Dispose(false, false);
        }

        private void Dispose(bool disposing, bool sync)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (this.OnRtcEngineImpleWillDispose != null)
                {
                    this.OnRtcEngineImpleWillDispose.Invoke(this);
                }

                // TODO: Unmanaged resources.
                UnSetIrisAudioFrameObserver();
                UnSetIrisVideoFrameObserver();
                UnSetIrisVideoEncodedFrameObserver();
                UnSetIrisMetaDataObserver();
                UnSetIrisAudioEncodedFrameObserver();
                UnSetIrisAudioSpectrumObserver();

                _videoDeviceManagerInstance.Dispose();
                _videoDeviceManagerInstance = null;

                _audioDeviceManagerInstance.Dispose();
                _audioDeviceManagerInstance = null;

                _mediaPlayerInstance.Dispose();
                _mediaPlayerInstance = null;

                _musicContentCenterImpl.Dispose();
                _musicContentCenterImpl = null;

                _spatialAudioEngineInstance = null;

                _mediaPlayerCacheManager.Dispose();
                _mediaPlayerCacheManager = null;

                _mediaRecorderInstance.Dispose();
                _mediaRecorderInstance = null;
#if AGORA_RTM
                _streamChannelInstance.Dispose();
                _streamChannelInstance = null;
#endif
            }

            AgoraRtcNative.FreeIrisRtcRendering(_rtcRenderingHandle);
            Release(sync);

            ReleaseEventHandler();
            /// You must free cdn event handle after you release engine.
            /// Because when engine releasing. will call some Cdn event function.We need keep cdn event function ptr alive
            ReleaseDirectCdnStreamingEventHandle();

            /// You must release callbackObject after you release eventhandler.
            /// Otherwise may be agcallback and unity main loop can will both access callback object. make crash

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (_callbackObject != null)
            {
                _callbackObject.Release();
                _callbackObject = null;
                RtcEngineEventHandlerNative.CallbackObject = null;
            }
#endif
            _disposed = true;
        }

        private void Release(bool sync = false)
        {
            _param.Clear();
            _param.Add("sync", sync);

            string json = AgoraJson.ToJson(_param);

            AgoraRtcNative.CallIrisApiWithArgs(
                _irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RELEASE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            AgoraRtcNative.DestroyIrisApiEngine(_irisRtcEngine);
            _irisRtcEngine = IntPtr.Zero;
            // AgoraRtcNative.DestroyApiParamsPtr();

            _apiParam.FreeResult();

            engineInstance = null;
        }

        private int CreateEventHandler()
        {
            if (_rtcEventHandlerHandle.handle != IntPtr.Zero)
                return 0;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (_callbackObject == null)
            {
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                RtcEngineEventHandlerNative.CallbackObject = _callbackObject;
            }
#endif

            AgoraRtcNative.AllocEventHandlerHandle(ref _rtcEventHandlerHandle, RtcEngineEventHandlerNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcEventHandlerHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTEREVENTHANDLER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_REGISTEREVENTHANDLER failed: " + nRet);
            }

            return nRet;
        }

        private void ReleaseEventHandler()
        {
            if (_rtcEventHandlerHandle.handle == IntPtr.Zero)
                return;

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcEventHandlerHandle);

            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            RtcEngineEventHandlerNative.SetEventHandler(null);
        }

        private void CreateDirectCdnStreamingEventHandle()
        {
            if (_rtcDirectCdnStreamingEventHandle.handle == IntPtr.Zero)
            {
                AgoraRtcNative.AllocEventHandlerHandle(ref _rtcDirectCdnStreamingEventHandle, RtcEngineEventHandlerNative.OnEventForDirectCdnStreaming);
            }
        }

        private void ReleaseDirectCdnStreamingEventHandle()
        {
            if (_rtcDirectCdnStreamingEventHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.FreeEventHandlerHandle(ref _rtcDirectCdnStreamingEventHandle);
            }
        }

        internal IrisRtcEnginePtr GetNativeHandler()
        {
            return _irisRtcEngine;
        }

        internal IrisRtcRenderingHandle GetRtcRenderingHandle()
        {
            return _rtcRenderingHandle;
        }

        public static RtcEngineImpl GetInstance(IntPtr nativePtr)
        {
            return engineInstance ?? (engineInstance = new RtcEngineImpl(nativePtr));
        }

        public static RtcEngineImpl Get()
        {
            return engineInstance;
        }

        public int Initialize(RtcEngineContext context)
        {
            _param.Clear();
            _param.Add("context", context);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(
                _irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_INITIALIZE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var ret = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (ret == 0)
                SetAppType(AppType.APP_TYPE_UNITY);
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            if (ret == 0)
                SetAppType(AppType.APP_TYPE_C_SHARP);
#endif
            return ret;
        }

        private int SetAppType(AppType appType)
        {
            _param.Clear();
            _param.Add("appType", appType);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAPPTYPE,
                                                          json, (UInt32)json.Length,
                                                          IntPtr.Zero, 0,
                                                          ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public void Dispose(bool sync = false)
        {
            Dispose(true, sync);
            GC.SuppressFinalize(this);
        }

        public int InitEventHandler(IRtcEngineEventHandler engineEventHandler)
        {
            // you must Set Observer first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            RtcEngineEventHandlerNative.SetEventHandler(engineEventHandler);
            int ret = CreateEventHandler();
            return ret;
        }

        public int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            // you must Set Observer first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            AudioFrameObserverNative.SetAudioFrameObserverAndMode(audioFrameObserver, mode);
            int ret = SetIrisAudioFrameObserver(position);

            return ret;
        }

        public int UnRegisterAudioFrameObserver()
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int nRet = UnSetIrisAudioFrameObserver();
            AudioFrameObserverNative.SetAudioFrameObserverAndMode(null, OBSERVER_MODE.INTPTR);
            return nRet;
        }

        private int SetIrisAudioFrameObserver(AUDIO_FRAME_POSITION position)
        {
            if (_rtcAudioFrameObserverHandle.handle != IntPtr.Zero)
                return 0;

            _param.Clear();
            _param.Add("position", position);
            var json = AgoraJson.ToJson(_param);

            AgoraRtcNative.AllocEventHandlerHandle(ref _rtcAudioFrameObserverHandle, AudioFrameObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_REGISTERAUDIOFRAMEOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_REGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            return nRet;
        }

        private int UnSetIrisAudioFrameObserver()
        {
            if (_rtcAudioFrameObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_UNREGISTERAUDIOFRAMEOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcAudioFrameObserverHandle);
            return nRet;
        }

        public int RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            VideoFrameObserverNative.SetVideoFrameObserverAndMode(videoFrameObserver, mode);
            int ret = SetIrisVideoFrameObserver(formatPreference, position);
            return ret;
        }

        public int UnRegisterVideoFrameObserver()
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int nRet = UnSetIrisVideoFrameObserver();
            VideoFrameObserverNative.SetVideoFrameObserverAndMode(null, OBSERVER_MODE.INTPTR);
            return nRet;
        }

        private int SetIrisVideoFrameObserver(VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position)
        {
            if (_rtcVideoFrameObserverHandle.handle != IntPtr.Zero)
                return 0;

            _param.Clear();
            _param.Add("formatPreference", formatPreference);
            _param.Add("position", position);
            var json = AgoraJson.ToJson(_param);
            AgoraRtcNative.AllocEventHandlerHandle(ref _rtcVideoFrameObserverHandle, VideoFrameObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoFrameObserverHandle.handle };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_REGISTERVIDEOFRAMEOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_REGISTERVIDEOFRAMEOBSERVER failed: " + nRet);
            }

            return nRet;
        }

        private int UnSetIrisVideoFrameObserver()
        {
            if (_rtcVideoFrameObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_UNREGISTERVIDEOFRAMEOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERVIDEOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcVideoFrameObserverHandle);

            return nRet;
        }

        public int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)
        {
            //you must SetAudioEncodedFrameObserver first and then SetIrisAudioEncodedFrameObserver second
            //because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            //and this time you dont have observer be trigger
            AudioEncodedFrameObserverNative.SetAudioEncodedFrameObserver(observer);
            int ret = SetIrisAudioEncodedFrameObserver(config);
            return ret;
        }

        public int UnRegisterAudioEncodedFrameObserver()
        {
            // you must SetAudioEncodedFrameObserver(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int nRet = UnSetIrisAudioEncodedFrameObserver();
            AudioEncodedFrameObserverNative.SetAudioEncodedFrameObserver(null);
            return nRet;
        }

        private int SetIrisAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config)
        {
            if (_rtcAudioEncodedFrameObserverHandle.handle != IntPtr.Zero)
                return 0;

            AgoraRtcNative.AllocEventHandlerHandle(ref _rtcAudioEncodedFrameObserverHandle, AudioEncodedFrameObserverNative.OnEvent);
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioEncodedFrameObserverHandle.handle };
            int ret = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTERAUDIOENCODEDFRAMEOBSERVER,
                                                         json, (uint)json.Length,
                                                         Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                         ref _apiParam);
            return ret;
        }

        private int UnSetIrisAudioEncodedFrameObserver()
        {
            if (_rtcAudioEncodedFrameObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioEncodedFrameObserverHandle.handle };
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNREGISTERAUDIOENCODEDFRAMEOBSERVER,
                                                         "{}", 2,
                                                         Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                         ref _apiParam);

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcAudioEncodedFrameObserverHandle);
            return ret;
        }

        public int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            //you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            //because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            //and this time you dont have observer be trigger
            AudioSpectrumObserverNative.SetAudioSpectrumObserver(observer);
            int ret = SetIrisAudioSpectrumObserver();

            return ret;
        }

        public int UnregisterAudioSpectrumObserver()
        {
            //you must Set(null) lately. because maybe some callback will trigger when unregister,
            //you set null first, some callback will never triggered 
            int nRet = UnSetIrisAudioSpectrumObserver();
            AudioSpectrumObserverNative.SetAudioSpectrumObserver(null);
            return nRet;
        }

        private int SetIrisAudioSpectrumObserver()
        {
            if (_rtcAudioSpectrumObserverHandle.handle != IntPtr.Zero) return 0;

            AgoraRtcNative.AllocEventHandlerHandle(ref _rtcAudioSpectrumObserverHandle, AudioSpectrumObserverNative.OnEvent);

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioSpectrumObserverHandle.handle };
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTERAUDIOSPECTRUMOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            return ret;
        }

        private int UnSetIrisAudioSpectrumObserver()
        {
            if (_rtcAudioSpectrumObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioSpectrumObserverHandle.handle };
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNREGISTERAUDIOSPECTRUMOBSERVER,
                                                         "{}", 2,
                                                         Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                         ref _apiParam);

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcAudioSpectrumObserverHandle);
            return ret;
        }

        public int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver VideoEncodedFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            VideoEncodedFrameObserverNative.SetVideoEncodedFrameObserver(VideoEncodedFrameObserver);
            int ret = SetIrisVideoEncodedFrameObserver();

            return ret;
        }

        public int UnRegisterVideoEncodedFrameObserver()
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int nRet = UnSetIrisVideoEncodedFrameObserver();
            VideoEncodedFrameObserverNative.SetVideoEncodedFrameObserver(null);
            return nRet;
        }

        private int SetIrisVideoEncodedFrameObserver()
        {
            if (_rtcVideoEncodedFrameObserverHandle.handle != IntPtr.Zero)
                return 0;

            AgoraRtcNative.AllocEventHandlerHandle(ref _rtcVideoEncodedFrameObserverHandle, VideoEncodedFrameObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoEncodedFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_REGISTERVIDEOENCODEDFRAMEOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_REGISTERVIDEOENCODEDFRAMEOBSERVER failed: " + nRet);
            }

            return nRet;
        }

        private int UnSetIrisVideoEncodedFrameObserver()
        {
            if (_rtcVideoEncodedFrameObserverHandle.handle == IntPtr.Zero)
                return 0;
            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoEncodedFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcVideoEncodedFrameObserverHandle);

            return nRet;
        }

        public int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type)
        {
            //you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            //because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            //and this time you dont have observer be trigger

            MetadataObserverNative.SetMetadataObserver(observer);
            var ret = SetIrisMetaDataObserver(type);
            return ret;
        }

        public int UnregisterMediaMetadataObserver()
        {
            //you must Set(null) lately. because maybe some callback will trigger when unregister,
            //you set null first, some callback will never triggered 
            int nRet = UnSetIrisMetaDataObserver();
            MetadataObserverNative.SetMetadataObserver(null);
            return nRet;
        }

        private int SetIrisMetaDataObserver(METADATA_TYPE type)
        {
            if (_rtcMetaDataObserverHandle.handle != IntPtr.Zero)
                return 0;

            AgoraRtcNative.AllocEventHandlerHandle(ref _rtcMetaDataObserverHandle, MetadataObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcMetaDataObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTERMEDIAMETADATAOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_REGISTERMEDIAMETADATAOBSERVER failed: " + nRet);
            }
            return nRet;
        }

        private int UnSetIrisMetaDataObserver()
        {
            if (_rtcMetaDataObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcMetaDataObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNREGISTERMEDIAMETADATAOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_UNREGISTERMEDIAMETADATAOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcMetaDataObserverHandle);

            return nRet;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        public int SetMaxMetadataSize(int size)
        {
            _param.Clear();
            _param.Add("size", size);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETMAXMETADATASIZE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        public int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            _param.Clear();
            _param.Add("metadata", metadata);
            _param.Add("source_type", source_type);

            var json = AgoraJson.ToJson(_param);

            IntPtr[] arrayPtr = new IntPtr[] { metadata.buffer };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SENDMETADATA,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
#endif

        public int GetNativeHandler(ref IntPtr nativeHandler)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETNATIVEHANDLE,
                                                          json, (UInt32)json.Length,
                                                          IntPtr.Zero, 0,
                                                          ref _apiParam);

            nativeHandler = nRet == 0 ? (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "result") : IntPtr.Zero;

            return nRet;
        }

        public AudioDeviceManagerImpl GetAudioDeviceManager()
        {
            return _audioDeviceManagerInstance;
        }

        public VideoDeviceManagerImpl GetVideoDeviceManager()
        {
            return _videoDeviceManagerInstance;
        }

        public MediaPlayerImpl GetMediaPlayer()
        {
            return _mediaPlayerInstance;
        }

        public MusicContentCenterImpl GetMusicContentCenter()
        {
            return _musicContentCenterImpl;
        }

        public LocalSpatialAudioEngineImpl GetLocalSpatialAudioEngine()
        {
            return _spatialAudioEngineInstance;
        }

        public MediaPlayerCacheManagerImpl GetMediaPlayerCacheManager()
        {
            return _mediaPlayerCacheManager;
        }

        public MediaRecorderImpl GetMediaRecorder()
        {
            return _mediaRecorderInstance;
        }
#if AGORA_RTM
        public Rtc.StreamChannelImpl GetStreamChannel()
        {
            return _streamChannelInstance;
        }
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal IVideoStreamManager GetVideoStreamManager()
        {
            return new VideoStreamManager(this);
        }
#endif

#if AGORA_RTM
        public int GetStreamChannel(string channelId)
        {
            _param.Clear();
            _param.Add("channelId", channelId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETSTREAMCHANNEL,
                                                          json, (UInt32)json.Length,
                                                          IntPtr.Zero, 0,
                                                          ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
#endif

        public ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            _param.Clear();
            _param.Add("thumbSize", thumbSize);
            _param.Add("iconSize", iconSize);
            _param.Add("includeScreen", includeScreen);

            var json = AgoraJson.ToJson(_param);

            int ret = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETSCREENCAPTURESOURCES,
                                                         json, (UInt32)json.Length,
                                                         IntPtr.Zero, 0,
                                                         ref _apiParam);

            if (ret == 0)
            {
                ScreenCaptureSourceInfoInternal[] infoInternal = AgoraJson.JsonToStructArray<ScreenCaptureSourceInfoInternal>(_apiParam.Result, "result");
                var info = new ScreenCaptureSourceInfo[infoInternal.Length];
                for (int i = 0; i < infoInternal.Length; i++)
                {
                    var screenCaptureSourceInfo = infoInternal[i].GenerateScreenCaptureSourceInfo();
                    info[i] = screenCaptureSourceInfo;
                }
                IntPtr sources = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "sources");
                ReleaseScreenCaptureSources(sources);
                return info;
            }
            else
            {
                return new ScreenCaptureSourceInfo[0];
            }
        }

        public int ReleaseScreenCaptureSources(IntPtr sources)
        {
            IntPtr[] arrayPtr = new IntPtr[] { sources };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RELEASESCREENCAPTURESOURCES,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        #region terra IRtcEngineBase

        public string GetVersion(ref int build)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getVersion",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? "" : (string)AgoraJson.GetData<string>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                build = (int)AgoraJson.GetData<int>(_apiParam.Result, "build");
            }
            return result;
        }

        public string GetErrorDescription(int code)
        {
            _param.Clear();
            _param.Add("code", code);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getErrorDescription",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? "" : (string)AgoraJson.GetData<string>(_apiParam.Result, "result");

            return result;
        }

        public int QueryCodecCapability(ref CodecCapInfo[] codecInfo, ref int size)
        {
            _param.Clear();

            _param.Add("size", size);
            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_queryCodecCapability",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                codecInfo = AgoraJson.JsonToStructArray<CodecCapInfo>(_apiParam.Result, "codecInfo");
                size = (int)AgoraJson.GetData<int>(_apiParam.Result, "size");
            }
            return result;
        }

        public int QueryDeviceScore()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_queryDeviceScore",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateChannelMediaOptions(ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_updateChannelMediaOptions",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int LeaveChannel()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_leaveChannel",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int LeaveChannel(LeaveChannelOptions options)
        {
            _param.Clear();
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_leaveChannel2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int RenewToken(string token)
        {
            _param.Clear();
            _param.Add("token", token);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_renewToken",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            _param.Clear();
            _param.Add("profile", profile);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setChannelProfile",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            _param.Clear();
            _param.Add("role", role);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setClientRole",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options)
        {
            _param.Clear();
            _param.Add("role", role);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setClientRole2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartEchoTest()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startEchoTest",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartEchoTest(int intervalInSeconds)
        {
            _param.Clear();
            _param.Add("intervalInSeconds", intervalInSeconds);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startEchoTest2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartEchoTest(EchoTestConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startEchoTest3",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopEchoTest()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopEchoTest",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableMultiCamera",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableVideo()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableVideo",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int DisableVideo()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_disableVideo",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartPreview()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startPreview",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            _param.Clear();
            _param.Add("sourceType", sourceType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startPreview2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopPreview()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopPreview",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            _param.Clear();
            _param.Add("sourceType", sourceType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopPreview2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startLastmileProbeTest",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopLastmileProbeTest()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopLastmileProbeTest",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVideoEncoderConfiguration",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("options", options);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setBeautyEffectOptions",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("options", options);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLowlightEnhanceOptions",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("options", options);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVideoDenoiserOptions",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("options", options);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setColorEnhanceOptions",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("backgroundSource", backgroundSource);
            _param.Add("segproperty", segproperty);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableVirtualBackground",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVideoScenario(VIDEO_APPLICATION_SCENARIO_TYPE scenarioType)
        {
            _param.Clear();
            _param.Add("scenarioType", scenarioType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVideoScenario",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVideoQoEPreference(VIDEO_QOE_PREFERENCE_TYPE qoePreference)
        {
            _param.Clear();
            _param.Add("qoePreference", qoePreference);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVideoQoEPreference",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableAudio()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableAudio",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int DisableAudio()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_disableAudio",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            _param.Clear();
            _param.Add("profile", profile);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAudioProfile",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario)
        {
            _param.Clear();
            _param.Add("scenario", scenario);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAudioScenario",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableLocalAudio(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableLocalAudio",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteLocalAudioStream(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_muteLocalAudioStream",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteAllRemoteAudioStreams(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_muteAllRemoteAudioStreams",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteLocalVideoStream(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_muteLocalVideoStream",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableLocalVideo(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableLocalVideo",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteAllRemoteVideoStreams(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_muteAllRemoteVideoStreams",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            _param.Clear();
            _param.Add("streamType", streamType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setRemoteDefaultVideoStreamType",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            _param.Clear();
            _param.Add("interval", interval);
            _param.Add("smooth", smooth);
            _param.Add("reportVad", reportVad);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableAudioVolumeIndication",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            _param.Clear();
            _param.Add("filePath", filePath);
            _param.Add("quality", quality);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startAudioRecording",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            _param.Clear();
            _param.Add("filePath", filePath);
            _param.Add("sampleRate", sampleRate);
            _param.Add("quality", quality);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startAudioRecording2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartAudioRecording(AudioRecordingConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startAudioRecording3",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopAudioRecording()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopAudioRecording",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartAudioMixing(string filePath, bool loopback, int cycle)
        {
            _param.Clear();
            _param.Add("filePath", filePath);
            _param.Add("loopback", loopback);
            _param.Add("cycle", cycle);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startAudioMixing",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos)
        {
            _param.Clear();
            _param.Add("filePath", filePath);
            _param.Add("loopback", loopback);
            _param.Add("cycle", cycle);
            _param.Add("startPos", startPos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startAudioMixing2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopAudioMixing()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopAudioMixing",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PauseAudioMixing()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_pauseAudioMixing",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ResumeAudioMixing()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_resumeAudioMixing",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SelectAudioTrack(int index)
        {
            _param.Clear();
            _param.Add("index", index);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_selectAudioTrack",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetAudioTrackCount()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getAudioTrackCount",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustAudioMixingVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_adjustAudioMixingVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustAudioMixingPublishVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_adjustAudioMixingPublishVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetAudioMixingPublishVolume()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getAudioMixingPublishVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustAudioMixingPlayoutVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_adjustAudioMixingPlayoutVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetAudioMixingPlayoutVolume()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getAudioMixingPlayoutVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetAudioMixingDuration()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getAudioMixingDuration",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetAudioMixingCurrentPosition()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getAudioMixingCurrentPosition",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioMixingPosition(int pos)
        {
            _param.Clear();
            _param.Add("pos", pos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAudioMixingPosition",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode)
        {
            _param.Clear();
            _param.Add("mode", mode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAudioMixingDualMonoMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioMixingPitch(int pitch)
        {
            _param.Clear();
            _param.Add("pitch", pitch);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAudioMixingPitch",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetEffectsVolume()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getEffectsVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetEffectsVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setEffectsVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            _param.Clear();
            _param.Add("soundId", soundId);
            _param.Add("filePath", filePath);
            _param.Add("startPos", startPos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_preloadEffect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)
        {
            _param.Clear();
            _param.Add("soundId", soundId);
            _param.Add("filePath", filePath);
            _param.Add("loopCount", loopCount);
            _param.Add("pitch", pitch);
            _param.Add("pan", pan);
            _param.Add("gain", gain);
            _param.Add("publish", publish);
            _param.Add("startPos", startPos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_playEffect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false)
        {
            _param.Clear();
            _param.Add("loopCount", loopCount);
            _param.Add("pitch", pitch);
            _param.Add("pan", pan);
            _param.Add("gain", gain);
            _param.Add("publish", publish);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_playAllEffects",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetVolumeOfEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getVolumeOfEffect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVolumeOfEffect(int soundId, int volume)
        {
            _param.Clear();
            _param.Add("soundId", soundId);
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVolumeOfEffect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PauseEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_pauseEffect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PauseAllEffects()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_pauseAllEffects",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ResumeEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_resumeEffect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ResumeAllEffects()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_resumeAllEffects",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopEffect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopAllEffects()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopAllEffects",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UnloadEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_unloadEffect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UnloadAllEffects()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_unloadAllEffects",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetEffectDuration(string filePath)
        {
            _param.Clear();
            _param.Add("filePath", filePath);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getEffectDuration",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetEffectPosition(int soundId, int pos)
        {
            _param.Clear();
            _param.Add("soundId", soundId);
            _param.Add("pos", pos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setEffectPosition",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetEffectCurrentPosition(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getEffectCurrentPosition",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableSoundPositionIndication(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableSoundPositionIndication",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableSpatialAudio(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableSpatialAudio",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            _param.Clear();
            _param.Add("preset", preset);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVoiceBeautifierPreset",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            _param.Clear();
            _param.Add("preset", preset);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAudioEffectPreset",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            _param.Clear();
            _param.Add("preset", preset);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVoiceConversionPreset",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            _param.Clear();
            _param.Add("preset", preset);
            _param.Add("param1", param1);
            _param.Add("param2", param2);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAudioEffectParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2)
        {
            _param.Clear();
            _param.Add("preset", preset);
            _param.Add("param1", param1);
            _param.Add("param2", param2);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVoiceBeautifierParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2)
        {
            _param.Clear();
            _param.Add("preset", preset);
            _param.Add("param1", param1);
            _param.Add("param2", param2);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setVoiceConversionParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLocalVoicePitch(double pitch)
        {
            _param.Clear();
            _param.Add("pitch", pitch);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalVoicePitch",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLocalVoiceFormant(double formantRatio)
        {
            _param.Clear();
            _param.Add("formantRatio", formantRatio);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalVoiceFormant",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            _param.Clear();
            _param.Add("bandFrequency", bandFrequency);
            _param.Add("bandGain", bandGain);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalVoiceEqualization",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            _param.Clear();
            _param.Add("reverbKey", reverbKey);
            _param.Add("value", value);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalVoiceReverb",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset)
        {
            _param.Clear();
            _param.Add("preset", preset);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setHeadphoneEQPreset",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetHeadphoneEQParameters(int lowGain, int highGain)
        {
            _param.Clear();
            _param.Add("lowGain", lowGain);
            _param.Add("highGain", highGain);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setHeadphoneEQParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLogFile(string filePath)
        {
            _param.Clear();
            _param.Add("filePath", filePath);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLogFile",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLogFilter(uint filter)
        {
            _param.Clear();
            _param.Add("filter", filter);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLogFilter",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLogLevel(LOG_LEVEL level)
        {
            _param.Clear();
            _param.Add("level", level);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLogLevel",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLogFileSize(uint fileSizeInKBytes)
        {
            _param.Clear();
            _param.Add("fileSizeInKBytes", fileSizeInKBytes);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLogFileSize",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UploadLogFile(ref string requestId)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_uploadLogFile",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            return result;
        }

        public int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            _param.Clear();
            _param.Add("renderMode", renderMode);
            _param.Add("mirrorMode", mirrorMode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalRenderMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            _param.Clear();
            _param.Add("renderMode", renderMode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalRenderMode2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            _param.Clear();
            _param.Add("mirrorMode", mirrorMode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalVideoMirrorMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableDualStreamMode(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableDualStreamMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("streamConfig", streamConfig);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableDualStreamMode2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetDualStreamMode(SIMULCAST_STREAM_MODE mode)
        {
            _param.Clear();
            _param.Add("mode", mode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setDualStreamMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig)
        {
            _param.Clear();
            _param.Add("mode", mode);
            _param.Add("streamConfig", streamConfig);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setDualStreamMode2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableCustomAudioLocalPlayback(uint trackId, bool enabled)
        {
            _param.Clear();
            _param.Add("trackId", trackId);
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableCustomAudioLocalPlayback",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);
            _param.Add("mode", mode);
            _param.Add("samplesPerCall", samplesPerCall);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setRecordingAudioFrameParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);
            _param.Add("mode", mode);
            _param.Add("samplesPerCall", samplesPerCall);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setPlaybackAudioFrameParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);
            _param.Add("samplesPerCall", samplesPerCall);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setMixedAudioFrameParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);
            _param.Add("mode", mode);
            _param.Add("samplesPerCall", samplesPerCall);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setEarMonitoringAudioFrameParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setPlaybackAudioFrameBeforeMixingParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            _param.Clear();
            _param.Add("intervalInMS", intervalInMS);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableAudioSpectrumMonitor",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int DisableAudioSpectrumMonitor()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_disableAudioSpectrumMonitor",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustRecordingSignalVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_adjustRecordingSignalVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteRecordingSignal(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_muteRecordingSignal",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustPlaybackSignalVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_adjustPlaybackSignalVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            _param.Clear();
            _param.Add("option", option);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalPublishFallbackOption",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            _param.Clear();
            _param.Add("option", option);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setRemoteSubscribeFallbackOption",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableLoopbackRecording(bool enabled, string deviceName = "")
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("deviceName", deviceName);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableLoopbackRecording",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustLoopbackSignalVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_adjustLoopbackSignalVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetLoopbackRecordingVolume()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getLoopbackRecordingVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("includeAudioFilters", includeAudioFilters);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableInEarMonitoring",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetInEarMonitoringVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setInEarMonitoringVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int LoadExtensionProvider(string path, bool unload_after_use = false)
        {
            _param.Clear();
            _param.Add("path", path);
            _param.Add("unload_after_use", unload_after_use);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_loadExtensionProvider",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetExtensionProviderProperty(string provider, string key, string value)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("key", key);
            _param.Add("value", value);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setExtensionProviderProperty",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_registerExtension",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("enable", enable);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableExtension",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("key", key);
            _param.Add("value", value);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setExtensionProperty",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("key", key);
            _param.Add("buf_len", buf_len);
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getExtensionProperty",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                value = (string)AgoraJson.GetData<string>(_apiParam.Result, "value");
            }
            return result;
        }

        public int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraCapturerConfiguration",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public uint CreateCustomVideoTrack()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_createCustomVideoTrack",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? 0 : (uint)AgoraJson.GetData<uint>(_apiParam.Result, "result");

            return result;
        }

        public uint CreateCustomEncodedVideoTrack(SenderOptions sender_option)
        {
            _param.Clear();
            _param.Add("sender_option", sender_option);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_createCustomEncodedVideoTrack",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? 0 : (uint)AgoraJson.GetData<uint>(_apiParam.Result, "result");

            return result;
        }

        public int DestroyCustomVideoTrack(uint video_track_id)
        {
            _param.Clear();
            _param.Add("video_track_id", video_track_id);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_destroyCustomVideoTrack",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int DestroyCustomEncodedVideoTrack(uint video_track_id)
        {
            _param.Clear();
            _param.Add("video_track_id", video_track_id);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_destroyCustomEncodedVideoTrack",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SwitchCamera()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_switchCamera",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public bool IsCameraZoomSupported()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isCameraZoomSupported",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public bool IsCameraFaceDetectSupported()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isCameraFaceDetectSupported",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public bool IsCameraTorchSupported()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isCameraTorchSupported",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public bool IsCameraFocusSupported()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isCameraFocusSupported",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public bool IsCameraAutoFocusFaceModeSupported()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isCameraAutoFocusFaceModeSupported",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public int SetCameraZoomFactor(float factor)
        {
            _param.Clear();
            _param.Add("factor", factor);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraZoomFactor",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableFaceDetection(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableFaceDetection",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public float GetCameraMaxZoomFactor()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getCameraMaxZoomFactor",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? 0 : (float)AgoraJson.GetData<float>(_apiParam.Result, "result");

            return result;
        }

        public int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            _param.Clear();
            _param.Add("positionX", positionX);
            _param.Add("positionY", positionY);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraFocusPositionInPreview",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetCameraTorchOn(bool isOn)
        {
            _param.Clear();
            _param.Add("isOn", isOn);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraTorchOn",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraAutoFocusFaceModeEnabled",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public bool IsCameraExposurePositionSupported()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isCameraExposurePositionSupported",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            _param.Clear();
            _param.Add("positionXinView", positionXinView);
            _param.Add("positionYinView", positionYinView);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraExposurePosition",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public bool IsCameraExposureSupported()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isCameraExposureSupported",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public int SetCameraExposureFactor(float factor)
        {
            _param.Clear();
            _param.Add("factor", factor);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraExposureFactor",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public bool IsCameraAutoExposureFaceModeSupported()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isCameraAutoExposureFaceModeSupported",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraAutoExposureFaceModeEnabled",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            _param.Clear();
            _param.Add("defaultToSpeaker", defaultToSpeaker);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setDefaultAudioRouteToSpeakerphone",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetEnableSpeakerphone(bool speakerOn)
        {
            _param.Clear();
            _param.Add("speakerOn", speakerOn);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setEnableSpeakerphone",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public bool IsSpeakerphoneEnabled()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isSpeakerphoneEnabled",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }

        public int SetRouteInCommunicationMode(int route)
        {
            _param.Clear();
            _param.Add("route", route);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setRouteInCommunicationMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            _param.Clear();
            _param.Add("restriction", restriction);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAudioSessionOperationRestriction",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("displayId", displayId);
            _param.Add("regionRect", regionRect);
            _param.Add("captureParams", captureParams);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startScreenCaptureByDisplayId",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetAudioDeviceInfo(ref DeviceInfoMobile deviceInfo)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getAudioDeviceInfo",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceInfo = AgoraJson.JsonToStruct<DeviceInfoMobile>(_apiParam.Result, "deviceInfo");
            }
            return result;
        }

        public int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("windowId", windowId);
            _param.Add("regionRect", regionRect);
            _param.Add("captureParams", captureParams);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startScreenCaptureByWindowId",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            _param.Clear();
            _param.Add("contentHint", contentHint);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setScreenCaptureContentHint",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            _param.Clear();
            _param.Add("regionRect", regionRect);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_updateScreenCaptureRegion",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("captureParams", captureParams);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_updateScreenCaptureParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            _param.Clear();
            _param.Add("captureParams", captureParams);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startScreenCapture",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            _param.Clear();
            _param.Add("captureParams", captureParams);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_updateScreenCapture",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int QueryScreenCaptureCapability()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_queryScreenCaptureCapability",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario)
        {
            _param.Clear();
            _param.Add("screenScenario", screenScenario);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setScreenCaptureScenario",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopScreenCapture()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopScreenCapture",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetCallId(ref string callId)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getCallId",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                callId = (string)AgoraJson.GetData<string>(_apiParam.Result, "callId");
            }
            return result;
        }

        public int Rate(string callId, int rating, string description)
        {
            _param.Clear();
            _param.Add("callId", callId);
            _param.Add("rating", rating);
            _param.Add("description", description);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_rate",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int Complain(string callId, string description)
        {
            _param.Clear();
            _param.Add("callId", callId);
            _param.Add("description", description);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_complain",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartRtmpStreamWithoutTranscoding(string url)
        {
            _param.Clear();
            _param.Add("url", url);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startRtmpStreamWithoutTranscoding",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopRtmpStream(string url)
        {
            _param.Clear();
            _param.Add("url", url);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopRtmpStream",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopLocalVideoTranscoder()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopLocalVideoTranscoder",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartCameraCapture(VIDEO_SOURCE_TYPE sourceType, CameraCapturerConfiguration config)
        {
            _param.Clear();
            _param.Add("sourceType", sourceType);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startCameraCapture",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopCameraCapture(VIDEO_SOURCE_TYPE sourceType)
        {
            _param.Clear();
            _param.Add("sourceType", sourceType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopCameraCapture",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            _param.Clear();
            _param.Add("type", type);
            _param.Add("orientation", orientation);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCameraDeviceOrientation",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            _param.Clear();
            _param.Add("type", type);
            _param.Add("orientation", orientation);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setScreenCaptureOrientation",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartScreenCapture(VIDEO_SOURCE_TYPE sourceType, ScreenCaptureConfiguration config)
        {
            _param.Clear();
            _param.Add("sourceType", sourceType);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startScreenCapture2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopScreenCapture(VIDEO_SOURCE_TYPE sourceType)
        {
            _param.Clear();
            _param.Add("sourceType", sourceType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopScreenCapture2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getConnectionState",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED : (CONNECTION_STATE_TYPE)AgoraJson.JsonToStruct<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableEncryption",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            _param.Clear();
            _param.Add("reliable", reliable);
            _param.Add("ordered", ordered);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_createDataStream",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_apiParam.Result, "streamId");
            }
            return result;
        }

        public int CreateDataStream(ref int streamId, DataStreamConfig config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_createDataStream2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_apiParam.Result, "streamId");
            }
            return result;
        }

        public int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            _param.Clear();
            _param.Add("streamId", streamId);
            _param.Add("length", length);

            var json = AgoraJson.ToJson(_param); IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_sendStreamMessage",
                json, (UInt32)json.Length,
            Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            _param.Clear();
            _param.Add("watermarkUrl", watermarkUrl);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_addVideoWatermark",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ClearVideoWatermarks()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_clearVideoWatermarks",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            _param.Clear();
            _param.Add("id", id);
            _param.Add("category", category);
            _param.Add("event", @event);
            _param.Add("label", label);
            _param.Add("value", value);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_sendCustomReportMessage",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAINSMode(bool enabled, AUDIO_AINS_MODE mode)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("mode", mode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAINSMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopChannelMediaRelay()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopChannelMediaRelay",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PauseAllChannelMediaRelay()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_pauseAllChannelMediaRelay",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ResumeAllChannelMediaRelay()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_resumeAllChannelMediaRelay",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            _param.Clear();
            _param.Add("profile", profile);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setDirectCdnStreamingAudioConfiguration",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setDirectCdnStreamingVideoConfiguration",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            CreateDirectCdnStreamingEventHandle();

            _param.Clear();
            _param.Add("publishUrl", publishUrl);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startDirectCdnStreaming",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopDirectCdnStreaming()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopDirectCdnStreaming",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        {
            _param.Clear();
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_updateDirectCdnStreamingMediaOptions",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            _param.Clear();
            _param.Add("sound1", sound1);
            _param.Add("sound2", sound2);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startRhythmPlayer",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopRhythmPlayer()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_stopRhythmPlayer",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_configRhythmPlayer",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableContentInspect(bool enabled, ContentInspectConfig config)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableContentInspect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustCustomAudioPublishVolume(uint trackId, int volume)
        {
            _param.Clear();
            _param.Add("trackId", trackId);
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_adjustCustomAudioPublishVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustCustomAudioPlayoutVolume(uint trackId, int volume)
        {
            _param.Clear();
            _param.Add("trackId", trackId);
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_adjustCustomAudioPlayoutVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            _param.Clear();
            _param.Add("proxyType", proxyType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setCloudProxy",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetLocalAccessPoint(LocalAccessPointConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setLocalAccessPoint",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType = 0)
        {
            _param.Clear();
            _param.Add("options", options);
            _param.Add("sourceType", sourceType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setAdvancedAudioOptions",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableVideoImageSource(bool enable, ImageTrackOptions options)
        {
            _param.Clear();
            _param.Add("enable", enable);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableVideoImageSource",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public long GetCurrentMonotonicTimeInMs()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getCurrentMonotonicTimeInMs",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (long)AgoraJson.GetData<long>(_apiParam.Result, "result");

            return result;
        }

        public int EnableWirelessAccelerate(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableWirelessAccelerate",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetNetworkType()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getNetworkType",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetParameters(string parameters)
        {
            _param.Clear();
            _param.Add("parameters", parameters);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_setParameters",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartMediaRenderingTracing()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_startMediaRenderingTracing",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableInstantMediaRendering()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_enableInstantMediaRendering",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public ulong GetNtpWallTimeInMs()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_getNtpWallTimeInMs",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? 0 : (ulong)AgoraJson.GetData<ulong>(_apiParam.Result, "result");

            return result;
        }

        public bool IsFeatureAvailableOnDevice(FeatureType type)
        {
            _param.Clear();
            _param.Add("type", type);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineBase_isFeatureAvailableOnDevice",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");

            return result;
        }
        #endregion terra IRtcEngineBase

        #region terra IRtcEngine

        public int PreloadChannel(string token, string channelId, uint uid)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("uid", uid);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_preloadChannel",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PreloadChannel(string token, string channelId, string userAccount)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("userAccount", userAccount);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_preloadChannel2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdatePreloadChannelToken(string token)
        {
            _param.Clear();
            _param.Add("token", token);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_updatePreloadChannelToken",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int JoinChannel(string token, string channelId, string info, uint uid)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("info", info);
            _param.Add("uid", uid);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_joinChannel",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("uid", uid);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_joinChannel2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetupRemoteVideo(VideoCanvas canvas)
        {
            _param.Clear();
            _param.Add("canvas", canvas);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { (IntPtr)canvas.view };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setupRemoteVideo",
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetupLocalVideo(VideoCanvas canvas)
        {
            _param.Clear();
            _param.Add("canvas", canvas);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { (IntPtr)canvas.view };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setupLocalVideo",
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            _param.Clear();
            _param.Add("profile", profile);
            _param.Add("scenario", scenario);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setAudioProfile",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setDefaultMuteAllRemoteAudioStreams",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteRemoteAudioStream(uint uid, bool mute)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_muteRemoteAudioStream",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setDefaultMuteAllRemoteVideoStreams",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteRemoteVideoStream(uint uid, bool mute)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_muteRemoteVideoStream",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("streamType", streamType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setRemoteVideoStreamType",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setRemoteVideoSubscriptionOptions",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setSubscribeAudioBlocklist",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setSubscribeAudioAllowlist",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setSubscribeVideoBlocklist",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setSubscribeVideoAllowlist",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("pan", pan);
            _param.Add("gain", gain);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setRemoteVoicePosition",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams @params)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("params", @params);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setRemoteUserSpatialAudioParams",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("renderMode", renderMode);
            _param.Add("mirrorMode", mirrorMode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setRemoteRenderMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_adjustUserPlaybackSignalVolume",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetHighPriorityUserList(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNum", uidNum);
            _param.Add("option", option);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setHighPriorityUserList",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable = true)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("extensionInfo", extensionInfo);
            _param.Add("enable", enable);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_enableExtension",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, string value)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("extensionInfo", extensionInfo);
            _param.Add("key", key);
            _param.Add("value", value);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setExtensionProperty",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, ref string value, int buf_len)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("extensionInfo", extensionInfo);
            _param.Add("key", key);
            _param.Add("buf_len", buf_len);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_getExtensionProperty",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                value = (string)AgoraJson.GetData<string>(_apiParam.Result, "value");
            }
            return result;
        }

        public int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            _param.Clear();
            _param.Add("url", url);
            _param.Add("transcoding", transcoding);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_startRtmpStreamWithTranscoding",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            _param.Clear();
            _param.Add("transcoding", transcoding);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_updateRtmpTranscoding",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_startLocalVideoTranscoder",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_updateLocalTranscoderConfiguration",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("userPriority", userPriority);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setRemoteUserPriority",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetEncryptionMode(string encryptionMode)
        {
            _param.Clear();
            _param.Add("encryptionMode", encryptionMode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setEncryptionMode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetEncryptionSecret(string secret)
        {
            _param.Clear();
            _param.Add("secret", secret);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setEncryptionSecret",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AddVideoWatermark(RtcImage watermark)
        {
            _param.Clear();
            _param.Add("watermark", watermark);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_addVideoWatermark",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PauseAudio()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_pauseAudio",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ResumeAudio()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_resumeAudio",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableWebSdkInteroperability(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_enableWebSdkInteroperability",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartAudioFrameDump(string channel_id, uint uid, string location, string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            _param.Clear();
            _param.Add("channel_id", channel_id);
            _param.Add("uid", uid);
            _param.Add("location", location);
            _param.Add("uuid", uuid);
            _param.Add("passwd", passwd);
            _param.Add("duration_ms", duration_ms);
            _param.Add("auto_upload", auto_upload);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_startAudioFrameDump",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopAudioFrameDump(string channel_id, uint uid, string location)
        {
            _param.Clear();
            _param.Add("channel_id", channel_id);
            _param.Add("uid", uid);
            _param.Add("location", location);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_stopAudioFrameDump",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int RegisterLocalUserAccount(string appId, string userAccount)
        {
            _param.Clear();
            _param.Add("appId", appId);
            _param.Add("userAccount", userAccount);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_registerLocalUserAccount",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("userAccount", userAccount);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_joinChannelWithUserAccount",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("userAccount", userAccount);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_joinChannelWithUserAccount2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo)
        {
            _param.Clear();
            _param.Add("userAccount", userAccount);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_getUserInfoByUserAccount",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_apiParam.Result, "userInfo");
            }
            return result;
        }

        public int GetUserInfoByUid(uint uid, ref UserInfo userInfo)
        {
            _param.Clear();
            _param.Add("uid", uid);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_getUserInfoByUid",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_apiParam.Result, "userInfo");
            }
            return result;
        }

        public int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            _param.Clear();
            _param.Add("configuration", configuration);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_startOrUpdateChannelMediaRelay",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            _param.Clear();
            _param.Add("configuration", configuration);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_startChannelMediaRelay",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            _param.Clear();
            _param.Add("configuration", configuration);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_updateChannelMediaRelay",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int TakeSnapshot(uint uid, string filePath)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("filePath", filePath);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_takeSnapshot",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAVSyncSource(string channelId, uint uid)
        {
            _param.Clear();
            _param.Add("channelId", channelId);
            _param.Add("uid", uid);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_setAVSyncSource",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("screenRect", screenRect);
            _param.Add("regionRect", regionRect);
            _param.Add("captureParams", captureParams);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngine_startScreenCaptureByScreenRect",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }
        #endregion terra IRtcEngine

        #region terra IRtcEngineEx

        public int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("connection", connection);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_joinChannelEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int LeaveChannelEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_leaveChannelEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_leaveChannelEx2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("options", options);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_updateChannelMediaOptionsEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("config", config);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setVideoEncoderConfigurationEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("canvas", canvas);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { (IntPtr)canvas.view };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setupRemoteVideoEx",
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("mute", mute);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_muteRemoteAudioStreamEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("mute", mute);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_muteRemoteVideoStreamEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("streamType", streamType);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setRemoteVideoStreamTypeEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteLocalAudioStreamEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_muteLocalAudioStreamEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteLocalVideoStreamEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_muteLocalVideoStreamEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_muteAllRemoteAudioStreamsEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_muteAllRemoteVideoStreamsEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setSubscribeAudioBlocklistEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setSubscribeAudioAllowlistEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setSubscribeVideoBlocklistEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setSubscribeVideoAllowlistEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("options", options);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setRemoteVideoSubscriptionOptionsEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("pan", pan);
            _param.Add("gain", gain);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setRemoteVoicePositionEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams @params, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("params", @params);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setRemoteUserSpatialAudioParamsEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("renderMode", renderMode);
            _param.Add("mirrorMode", mirrorMode);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setRemoteRenderModeEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName = "")
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("enabled", enabled);
            _param.Add("deviceName", deviceName);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_enableLoopbackRecordingEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustRecordingSignalVolumeEx(int volume, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("volume", volume);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_adjustRecordingSignalVolumeEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int MuteRecordingSignalEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_muteRecordingSignalEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("volume", volume);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_adjustUserPlaybackSignalVolumeEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_getConnectionStateEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED : (CONNECTION_STATE_TYPE)AgoraJson.JsonToStruct<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("enabled", enabled);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_enableEncryptionEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("reliable", reliable);
            _param.Add("ordered", ordered);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_createDataStreamEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_apiParam.Result, "streamId");
            }
            return result;
        }

        public int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("config", config);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_createDataStreamEx2",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_apiParam.Result, "streamId");
            }
            return result;
        }

        public int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("streamId", streamId);
            _param.Add("length", length);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param); IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_sendStreamMessageEx",
                json, (UInt32)json.Length,
            Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("watermarkUrl", watermarkUrl);
            _param.Add("options", options);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_addVideoWatermarkEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ClearVideoWatermarkEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_clearVideoWatermarkEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("id", id);
            _param.Add("category", category);
            _param.Add("event", @event);
            _param.Add("label", label);
            _param.Add("value", value);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_sendCustomReportMessageEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("interval", interval);
            _param.Add("smooth", smooth);
            _param.Add("reportVad", reportVad);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_enableAudioVolumeIndicationEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("url", url);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_startRtmpStreamWithoutTranscodingEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("url", url);
            _param.Add("transcoding", transcoding);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_startRtmpStreamWithTranscodingEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("transcoding", transcoding);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_updateRtmpTranscodingEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopRtmpStreamEx(string url, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("url", url);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_stopRtmpStreamEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("configuration", configuration);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_startOrUpdateChannelMediaRelayEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("configuration", configuration);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_startChannelMediaRelayEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("configuration", configuration);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_updateChannelMediaRelayEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopChannelMediaRelayEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_stopChannelMediaRelayEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PauseAllChannelMediaRelayEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_pauseAllChannelMediaRelayEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ResumeAllChannelMediaRelayEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_resumeAllChannelMediaRelayEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("userAccount", userAccount);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_getUserInfoByUserAccountEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_apiParam.Result, "userInfo");
            }
            return result;
        }

        public int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_getUserInfoByUidEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_apiParam.Result, "userInfo");
            }
            return result;
        }

        public int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("streamConfig", streamConfig);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_enableDualStreamModeEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mode", mode);
            _param.Add("streamConfig", streamConfig);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setDualStreamModeEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetHighPriorityUserListEx(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNum", uidNum);
            _param.Add("option", option);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setHighPriorityUserListEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("uid", uid);
            _param.Add("filePath", filePath);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_takeSnapshotEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableContentInspectEx(bool enabled, ContentInspectConfig config, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("config", config);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_enableContentInspectEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartMediaRenderingTracingEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_startMediaRenderingTracingEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetParametersEx(RtcConnection connection, string parameters)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("parameters", parameters);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "RtcEngineEx_setParametersEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }
        #endregion terra IRtcEngineEx

        public int PushAudioFrame(AudioFrame frame, uint trackId)
        {
            _param.Clear();
            _param.Add("frame", new AudioFrameInternal(frame));
            _param.Add("trackId", trackId);

            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.RawBuffer, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHAUDIOFRAME,
                                                          json, (UInt32)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam, (uint)frame.RawBuffer.Length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PullAudioFrame(AudioFrame frame)
        {
            _param.Clear();
            _param.Add("frame", new AudioFrameInternal(frame));

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PULLAUDIOFRAME,
                                                          json, (UInt32)json.Length,
                                                          IntPtr.Zero, 0,
                                                          ref _apiParam);

            if (nRet == 0)
            {
                var f = AgoraJson.JsonToStruct<AudioFrame>(_apiParam.Result, "frame");
                #region terra PullAudioFrame_Assignment

                frame.type = f.type;
                frame.samplesPerChannel = f.samplesPerChannel;
                frame.bytesPerSample = f.bytesPerSample;
                frame.channels = f.channels;
                frame.samplesPerSec = f.samplesPerSec;

                frame.renderTimeMs = f.renderTimeMs;
                frame.avsync_type = f.avsync_type;
                frame.presentationMs = f.presentationMs;
                frame.audioTrackNumber = f.audioTrackNumber;
                #endregion terra PullAudioFrame_Assignment
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId)
        {
            _param.Clear();
            _param.Add("frame", new ExternalVideoFrameInternal(frame));
            _param.Add("videoTrackId", videoTrackId);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.buffer, 0);
            IntPtr eglContextPtr = frame.eglContext;
            IntPtr metadataPtr = IntPtr.Zero;
            IntPtr alphaBuffer = frame.alphaBuffer == null ? IntPtr.Zero : Marshal.UnsafeAddrOfPinnedArrayElement(frame.alphaBuffer, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr, eglContextPtr, metadataPtr, alphaBuffer };
            int alphaLength = frame.alphaBuffer == null ? 0 : frame.alphaBuffer.Length;
            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHVIDEOFRAME,
                                                          json, (UInt32)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 4,
                                                          ref _apiParam, (uint)frame.buffer.Length, 0, 0, (uint)alphaLength);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PushEncodedVideoImage(byte[] imageBuffer, ulong length,
                                         EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId)
        {
            _param.Clear();
            _param.Add("length", length);
            _param.Add("videoEncodedFrameInfo", videoEncodedFrameInfo);
            _param.Add("videoTrackId", videoTrackId);

            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(imageBuffer, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHENCODEDVIDEOIMAGE,
                                                          json, (UInt32)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam, (uint)length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        #region terra IMediaEngineBase

        public int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("useTexture", useTexture);
            _param.Add("sourceType", sourceType);
            _param.Add("encodedVideoOption", encodedVideoOption);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "MediaEngineBase_setExternalVideoSource",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetExternalAudioSource(bool enabled, int sampleRate, int channels, bool localPlayback = false, bool publish = true)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("sampleRate", sampleRate);
            _param.Add("channels", channels);
            _param.Add("localPlayback", localPlayback);
            _param.Add("publish", publish);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "MediaEngineBase_setExternalAudioSource",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public uint CreateCustomAudioTrack(AUDIO_TRACK_TYPE trackType, AudioTrackConfig config)
        {
            _param.Clear();
            _param.Add("trackType", trackType);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "MediaEngineBase_createCustomAudioTrack",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? 0 : (uint)AgoraJson.GetData<uint>(_apiParam.Result, "result");

            return result;
        }

        public int DestroyCustomAudioTrack(uint trackId)
        {
            _param.Clear();
            _param.Add("trackId", trackId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "MediaEngineBase_destroyCustomAudioTrack",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("sampleRate", sampleRate);
            _param.Add("channels", channels);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, "MediaEngineBase_setExternalAudioSink",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }


        #endregion terra IMediaEngineBase

        #region terra IMediaEngine

        #endregion terra IMediaEngine
    }
}
