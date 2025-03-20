#define AGORA_RTC
#define AGORA_RTM

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    using track_id_t = System.UInt32;
    using IrisRtcEnginePtr = IntPtr;
    using RtcEngineHandler = IntPtr;
    using IrisRtcRenderingHandle = IntPtr;
    using view_t = System.UInt64;

    public partial class RtcEngineImpl
    {
        private bool _disposed = false;
        private static RtcEngineImpl engineInstance = null;

        private IrisRtcEnginePtr _irisApiEngine;
        //IRtcEngine * 
        private RtcEngineHandler _rtcEngine;
        private IrisRtcCApiParam _apiParam;

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
        //faceInfoObserver
        private RtcEventHandlerHandle _faceInfoObserverHandle = new RtcEventHandlerHandle();

        private IrisRtcRenderingHandle _rtcRenderingHandle;

        private VideoDeviceManagerImpl _videoDeviceManagerInstance;
        private AudioDeviceManagerImpl _audioDeviceManagerInstance;
        private MediaPlayerImpl _mediaPlayerInstance;
        private MusicContentCenterImpl _musicContentCenterImpl;
        private LocalSpatialAudioEngineImpl _spatialAudioEngineInstance;
        private H265TranscoderImpl _h265TranscoderImpl;
        private MediaPlayerCacheManagerImpl _mediaPlayerCacheManager;
        private MediaRecorderImpl _mediaRecorderInstance;

        public event Action<RtcEngineImpl> OnRtcEngineImpleWillDispose;

        private RtcEngineImpl(IntPtr nativePtr)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();

            // AgoraRtcNative.CreateApiParamsPtr();
            _irisApiEngine = AgoraRtcNative.CreateIrisApiEngine(nativePtr);
            var ret = this.GetNativeHandler(ref _rtcEngine);
            if (ret != 0)
            {
                AgoraLog.LogError("GetNativeHandler failed: " + ret);
            }
            _videoDeviceManagerInstance = new VideoDeviceManagerImpl(_irisApiEngine);
            _audioDeviceManagerInstance = new AudioDeviceManagerImpl(_irisApiEngine);
            _mediaPlayerInstance = new MediaPlayerImpl(_irisApiEngine);
            _musicContentCenterImpl = new MusicContentCenterImpl(_irisApiEngine, _mediaPlayerInstance);
            _spatialAudioEngineInstance = new LocalSpatialAudioEngineImpl(_irisApiEngine, _rtcEngine);
            _h265TranscoderImpl = new H265TranscoderImpl(_irisApiEngine);
            _mediaPlayerCacheManager = new MediaPlayerCacheManagerImpl(_irisApiEngine);
            _mediaRecorderInstance = new MediaRecorderImpl(_irisApiEngine);

            _rtcRenderingHandle = AgoraRtcNative.CreateIrisRtcRendering(_irisApiEngine);
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
                UnSetIrisFaceInfoObserver();

                _videoDeviceManagerInstance.Dispose();
                _videoDeviceManagerInstance = null;

                _audioDeviceManagerInstance.Dispose();
                _audioDeviceManagerInstance = null;

                _mediaPlayerInstance.Dispose();
                _mediaPlayerInstance = null;

                _musicContentCenterImpl.Dispose();
                _musicContentCenterImpl = null;

                _spatialAudioEngineInstance.Dispose();
                _spatialAudioEngineInstance = null;

                _h265TranscoderImpl.Dispose();
                _h265TranscoderImpl = null;

                _mediaPlayerCacheManager.Dispose();
                _mediaPlayerCacheManager = null;

                _mediaRecorderInstance.Dispose();
                _mediaRecorderInstance = null;
            }

            AgoraRtcNative.FreeIrisRtcRendering(_rtcRenderingHandle);
            Release(sync);

            ReleaseEventHandler();
            /// You must free cdn event handle after you release engine.
            /// Because when engine releasing. will call some Cdn event function.We need keep cdn event function ptr alive
            ReleaseDirectCdnStreamingEventHandle();

            /// You must release callbackObject after you release eventhandler.
            /// Otherwise may be agcallback and unity main loop can will both access callback object. make crash

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
                _irisApiEngine, AgoraApiType.IRTCENGINE_RELEASE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            AgoraRtcNative.DestroyIrisApiEngine(_irisApiEngine);
            _irisApiEngine = IntPtr.Zero;
            // AgoraRtcNative.DestroyApiParamsPtr();

            _apiParam.FreeResult();

            engineInstance = null;
        }

        private int CreateEventHandler()
        {
            if (_rtcEventHandlerHandle.handle != IntPtr.Zero)
                return 0;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (_callbackObject == null)
            {
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                RtcEngineEventHandlerNative.CallbackObject = _callbackObject;
            }
#endif

            AgoraRtcNative.AllocEventHandlerHandle(ref _rtcEventHandlerHandle, RtcEngineEventHandlerNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcEventHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_REGISTEREVENTHANDLER_5fc0465,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_REGISTEREVENTHANDLER failed: " + nRet);
            }
            arrayPtrHandle.Free();
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

        internal IrisRtcEnginePtr GetIrisHandler()
        {
            return _irisApiEngine;
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
                _irisApiEngine, AgoraApiType.IRTCENGINE_INITIALIZE_0320339,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var ret = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (ret == 0)
            {
                SetAppType(AppType.APP_TYPE_UNITY);
                Dictionary<string, object> dic = new Dictionary<string, object>
                {
                { "rtc.capture_disable_metal_comp", true }
                };
                string parameters = AgoraJson.ToJson<Dictionary<string, object>>(dic);
                SetParameters(parameters);
            }
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

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_SETAPPTYPE,
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAENGINE_REGISTERAUDIOFRAMEOBSERVER_d873a64,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_REGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        private int UnSetIrisAudioFrameObserver()
        {
            if (_rtcAudioFrameObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioFrameObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAENGINE_UNREGISTERAUDIOFRAMEOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcAudioFrameObserverHandle);
            arrayPtrHandle.Free();
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAENGINE_REGISTERVIDEOFRAMEOBSERVER_2cc0ef1,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_REGISTERVIDEOFRAMEOBSERVER failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        private int UnSetIrisVideoFrameObserver()
        {
            if (_rtcVideoFrameObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoFrameObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAENGINE_UNREGISTERVIDEOFRAMEOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERVIDEOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcVideoFrameObserverHandle);
            arrayPtrHandle.Free();
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            int ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_REGISTERAUDIOENCODEDFRAMEOBSERVER_ed4a177,
                                                         json, (uint)json.Length,
                                                         Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                         ref _apiParam);
            arrayPtrHandle.Free();
            return ret;
        }

        private int UnSetIrisAudioEncodedFrameObserver()
        {
            if (_rtcAudioEncodedFrameObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioEncodedFrameObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERAUDIOENCODEDFRAMEOBSERVER,
                                                         "{}", 2,
                                                         Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                         ref _apiParam);

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcAudioEncodedFrameObserverHandle);
            arrayPtrHandle.Free();
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_REGISTERAUDIOSPECTRUMOBSERVER_0406ea7,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            arrayPtrHandle.Free();
            return ret;
        }

        private int UnSetIrisAudioSpectrumObserver()
        {
            if (_rtcAudioSpectrumObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioSpectrumObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERAUDIOSPECTRUMOBSERVER_0406ea7,
                                                         "{}", 2,
                                                         Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                         ref _apiParam);

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcAudioSpectrumObserverHandle);
            arrayPtrHandle.Free();
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAENGINE_REGISTERVIDEOENCODEDFRAMEOBSERVER_d45d579,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_REGISTERVIDEOENCODEDFRAMEOBSERVER failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        private int UnSetIrisVideoEncodedFrameObserver()
        {
            if (_rtcVideoEncodedFrameObserverHandle.handle == IntPtr.Zero)
                return 0;
            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoEncodedFrameObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcVideoEncodedFrameObserverHandle);
            arrayPtrHandle.Free();
            return nRet;
        }

        public int RegisterFaceInfoObserver(IFaceInfoObserver observer)
        {
            FaceInfoObserverNative.SetFaceInfoObserver(observer);
            return SetIrisFaceInfoObserver();
        }

        public int UnRegisterFaceInfoObserver()
        {
            int ret = UnSetIrisFaceInfoObserver();
            FaceInfoObserverNative.SetFaceInfoObserver(null);
            return ret;
        }

        public int SetIrisFaceInfoObserver()
        {
            if (_faceInfoObserverHandle.handle != IntPtr.Zero) return 0;

            AgoraRtcNative.AllocEventHandlerHandle(ref _faceInfoObserverHandle, FaceInfoObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _faceInfoObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAENGINE_REGISTERFACEINFOOBSERVER_0303ed6,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_REGISTERFACEINFOOBSERVER failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        public int UnSetIrisFaceInfoObserver()
        {
            if (_faceInfoObserverHandle.handle == IntPtr.Zero) return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _faceInfoObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAENGINE_UNREGISTERFACEINFOOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERFACEINFOOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _faceInfoObserverHandle);
            arrayPtrHandle.Free();
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_REGISTERMEDIAMETADATAOBSERVER_8701fec,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_REGISTERMEDIAMETADATAOBSERVER failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        private int UnSetIrisMetaDataObserver()
        {
            if (_rtcMetaDataObserverHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcMetaDataObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERMEDIAMETADATAOBSERVER_8701fec,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_UNREGISTERMEDIAMETADATAOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _rtcMetaDataObserverHandle);
            arrayPtrHandle.Free();
            return nRet;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        public int SetMaxMetadataSize(int size)
        {
            _param.Clear();
            _param.Add("size", size);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.IRTCENGINE_SETMAXMETADATASIZE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        public int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            _param.Clear();
            _param.Add("metadata", metadata);
            _param.Add("source_type", source_type);

            var json = AgoraJson.ToJson(_param);

            IntPtr[] arrayPtr = new IntPtr[] { metadata.buffer };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.IRTCENGINE_SENDMETADATA,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            arrayPtrHandle.Free();
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
#endif

        public int GetNativeHandler(ref IntPtr nativeHandler)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_GETNATIVEHANDLE,
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

        public H265TranscoderImpl GetH265Transcoder()
        {
            return _h265TranscoderImpl;
        }

        public MediaPlayerCacheManagerImpl GetMediaPlayerCacheManager()
        {
            return _mediaPlayerCacheManager;
        }

        public MediaRecorderImpl GetMediaRecorder()
        {
            return _mediaRecorderInstance;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal IVideoStreamManager GetVideoStreamManager()
        {
            return new VideoStreamManager(this);
        }
#endif

        public ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            _param.Clear();
            _param.Add("thumbSize", thumbSize);
            _param.Add("iconSize", iconSize);
            _param.Add("includeScreen", includeScreen);

            var json = AgoraJson.ToJson(_param);

            int ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_GETSCREENCAPTURESOURCES_f3e02cb,
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_RELEASESCREENCAPTURESOURCES,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);
            arrayPtrHandle.Free();
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            CreateDirectCdnStreamingEventHandle();

            _param.Clear();
            _param.Add("publishUrl", publishUrl);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcDirectCdnStreamingEventHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_STARTDIRECTCDNSTREAMING_ed8d77b,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            arrayPtrHandle.Free();
            return result;
        }

        public int PushAudioFrame(AudioFrame frame, uint trackId)
        {
            IrisAudioFrame irisFrame = new IrisAudioFrame(frame);
            GCHandle RawBufferHandle = GCHandle.Alloc(frame.RawBuffer, GCHandleType.Pinned);
            irisFrame.buffer = Marshal.UnsafeAddrOfPinnedArrayElement(frame.RawBuffer, 0);
            var result = AgoraRtcNative.IMediaEngine_PushAudioFrame(_rtcEngine, ref irisFrame, trackId);
            RawBufferHandle.Free();
            return result;
        }

        public int PullAudioFrame(AudioFrame frame)
        {
            IrisAudioFrame irisFrame = new IrisAudioFrame(frame);
            return AgoraRtcNative.IMediaEngine_PullAudioFrame(_rtcEngine, ref irisFrame);
        }

        public int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId)
        {
            GCHandle bufferHandle = frame.buffer == null ? GCHandle.Alloc(new byte[1], GCHandleType.Pinned) : GCHandle.Alloc(frame.buffer, GCHandleType.Pinned);
            GCHandle metadata_bufferHandle = frame.metadataBuffer == null ? GCHandle.Alloc(new byte[1], GCHandleType.Pinned) : GCHandle.Alloc(frame.metadataBuffer, GCHandleType.Pinned);
            GCHandle alphaBufferHandle = frame.alphaBuffer == null ? GCHandle.Alloc(new byte[1], GCHandleType.Pinned) : GCHandle.Alloc(frame.alphaBuffer, GCHandleType.Pinned);
            IrisExternalVideoFrame irisFrame = new IrisExternalVideoFrame(frame);
            var result = AgoraRtcNative.IMediaEngine_PushVideoFrame(_rtcEngine, ref irisFrame, videoTrackId);
            bufferHandle.Free();
            metadata_bufferHandle.Free();
            alphaBufferHandle.Free();
            return result;
        }

        public int PushEncodedVideoImage(byte[] imageBuffer, ulong length,
                                         EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId)
        {
            GCHandle imageBufferHandle = GCHandle.Alloc(imageBuffer, GCHandleType.Pinned);
            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(imageBuffer, 0);
            IrisEncodedVideoFrameInfo irisFrameInfo = new IrisEncodedVideoFrameInfo(videoEncodedFrameInfo);
            var result = AgoraRtcNative.IMediaEngine_PushEncodedVideoImage(_rtcEngine, bufferPtr, length, ref irisFrameInfo, videoTrackId);
            imageBufferHandle.Free();
            return result;
        }
    }
}
