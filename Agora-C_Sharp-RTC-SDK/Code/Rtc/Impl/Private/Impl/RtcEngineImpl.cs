using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS 
using AOT;
#endif

namespace Agora.Rtc
{
    using video_track_id_t = System.UInt32;
    using IrisRtcEnginePtr = IntPtr;
    using IrisRtcRenderingHandle = IntPtr;
    using view_t = System.UInt64;

    public partial class RtcEngineImpl
    {
        private bool _disposed = false;
        private static RtcEngineImpl engineInstance = null;

        private IrisRtcEnginePtr _irisApiEngine;
        private IrisCApiParam _apiParam;

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        private AgoraCallbackObject _callbackObject;
#endif
        //DirectCdnStreamingEventHandler
        private EventHandlerHandle _rtcDirectCdnStreamingEventHandle = new EventHandlerHandle();
        //rtcEventHandler
        private EventHandlerHandle _rtcEventHandlerHandle = new EventHandlerHandle();
        //audioFrameObserver
        private EventHandlerHandle _rtcAudioFrameObserverHandle = new EventHandlerHandle();
        //videoFrameObserver
        private EventHandlerHandle _rtcVideoFrameObserverHandle = new EventHandlerHandle();
        //audioEncodedFrameObserver
        private EventHandlerHandle _rtcAudioEncodedFrameObserverHandle = new EventHandlerHandle();
        //videoEncodedFrameObserver
        private EventHandlerHandle _rtcVideoEncodedFrameObserverHandle = new EventHandlerHandle();
        //metaData
        private EventHandlerHandle _rtcMetaDataObserverHandle = new EventHandlerHandle();
        //audioSpectrumOberver
        private EventHandlerHandle _rtcAudioSpectrumObserverHandle = new EventHandlerHandle();
        //faceInfoObserver
        private EventHandlerHandle _faceInfoObserverHandle = new EventHandlerHandle();

        private IrisRtcRenderingHandle _rtcRenderingHandle;

        private VideoDeviceManagerImpl _videoDeviceManagerInstance;
        private AudioDeviceManagerImpl _audioDeviceManagerInstance;
        private MediaPlayerImpl _mediaPlayerInstance;
        private MusicContentCenterImpl _musicContentCenterImpl;
        private LocalSpatialAudioEngineImpl _spatialAudioEngineInstance;
        private MediaPlayerCacheManagerImpl _mediaPlayerCacheManager;
        private MediaRecorderImpl _mediaRecorderInstance;

        public event Action<RtcEngineImpl> OnRtcEngineImpleWillDispose;

        private RtcEngineImpl(IntPtr nativePtr)
        {
            _apiParam = new IrisCApiParam();
            _apiParam.AllocResult();

            //AgoraRtcNative.CreateApiParamsPtr();
            _irisApiEngine = AgoraRtcNative.CreateIrisApiEngine(nativePtr);

            _videoDeviceManagerInstance = new VideoDeviceManagerImpl(_irisApiEngine);
            _audioDeviceManagerInstance = new AudioDeviceManagerImpl(_irisApiEngine);
            _mediaPlayerInstance = new MediaPlayerImpl(_irisApiEngine);
            _musicContentCenterImpl = new MusicContentCenterImpl(_irisApiEngine, _mediaPlayerInstance);
            _spatialAudioEngineInstance = new LocalSpatialAudioEngineImpl(_irisApiEngine);
            _mediaPlayerCacheManager = new MediaPlayerCacheManagerImpl(_irisApiEngine);
            _mediaRecorderInstance = new MediaRecorderImpl(_irisApiEngine);

            _rtcRenderingHandle = AgoraRtcNative.CreateIrisRtcRendering(_irisApiEngine);

        }

        private void Dispose(bool disposing, bool sync)
        {
            if (_disposed) return;

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

                if (_videoDeviceManagerInstance != null)
                {
                    _videoDeviceManagerInstance.Dispose();
                    _videoDeviceManagerInstance = null;
                }
                if (_audioDeviceManagerInstance != null)
                {
                    _audioDeviceManagerInstance.Dispose();
                    _audioDeviceManagerInstance = null;
                }
                if (_mediaPlayerInstance != null)
                {
                    _mediaPlayerInstance.Dispose();
                    _mediaPlayerInstance = null;
                }
                if (_musicContentCenterImpl != null)
                {
                    _musicContentCenterImpl.Dispose();
                    _musicContentCenterImpl = null;
                }
                if (_spatialAudioEngineInstance != null)
                {
                    _spatialAudioEngineInstance.Dispose();
                    _spatialAudioEngineInstance = null;
                }
                if (_mediaPlayerCacheManager != null)
                {
                    _mediaPlayerCacheManager.Dispose();
                    _mediaPlayerCacheManager = null;
                }
                if (_mediaRecorderInstance != null)
                {
                    _mediaRecorderInstance.Dispose();
                    _mediaRecorderInstance = null;
                }

                _rtcDirectCdnStreamingEventHandle.Dispose();
                _rtcEventHandlerHandle.Dispose();
                _rtcAudioFrameObserverHandle.Dispose();
                _rtcVideoFrameObserverHandle.Dispose();
                _rtcAudioEncodedFrameObserverHandle.Dispose();
                _rtcVideoEncodedFrameObserverHandle.Dispose();
                _rtcMetaDataObserverHandle.Dispose();
                _rtcAudioSpectrumObserverHandle.Dispose();
                _faceInfoObserverHandle.Dispose();

            }

            AgoraRtcNative.FreeIrisRtcRendering(_rtcRenderingHandle);
            _rtcRenderingHandle = IntPtr.Zero;

            AgoraRtcNative.DestroyIrisApiEngine(_irisApiEngine);
            _irisApiEngine = IntPtr.Zero;

            _apiParam.FreeResult();

            _disposed = true;
        }

        public void Dispose(bool sync = false)
        {
            Dispose(true, sync);
            GC.SuppressFinalize(this);
        }

        public static RtcEngineImpl GetInstance(IntPtr nativePtr)
        {
            return engineInstance ?? (engineInstance = new RtcEngineImpl(nativePtr));
        }

        public static RtcEngineImpl Get()
        {
            return engineInstance;
        }

        public IrisRtcEnginePtr GetNativeHandler()
        {
            return _irisApiEngine;
        }

        public int GetNativeHandler(ref IntPtr nativeHandler)
        {
            nativeHandler = _irisApiEngine;
            return 0;
        }

        public VideoDeviceManagerImpl GetVideoDeviceManager()
        {
            return _videoDeviceManagerInstance;
        }

        public AudioDeviceManagerImpl GetAudioDeviceManager()
        {
            return _audioDeviceManagerInstance;
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

        public int Initialize(RtcEngineContext context)
        {
            _param.Clear();
            _param.Add("context", context);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_INITIALIZE_0320f26,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int InitEventHandler(IRtcEngineEventHandler engineEventHandler)
        {
            if (_rtcEventHandlerHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.UnregisterEventHandler(_irisApiEngine, _rtcEventHandlerHandle.handle);
                _rtcEventHandlerHandle.handle = IntPtr.Zero;
            }

            _rtcEventHandlerHandle.handle = AgoraRtcNative.CreateIrisEventHandler(_rtcEventHandlerHandle.c_handle);
            AgoraRtcNative.RegisterEventHandler(_irisApiEngine, _rtcEventHandlerHandle.handle);

            RtcEngineEventHandlerNative.SetEventHandler(engineEventHandler);
            return 0;
        }

        public int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode)
        {
            if (_rtcAudioFrameObserverHandle.handle != IntPtr.Zero)
            {
                UnSetIrisAudioFrameObserver();
            }

            _rtcAudioFrameObserverHandle.handle = AgoraRtcNative.CreateIrisAudioFrameObserver(_rtcAudioFrameObserverHandle.c_handle);
            _param.Clear();
            _param.Add("observer", (ulong)_rtcAudioFrameObserverHandle.handle);
            _param.Add("mode", mode);
            var json = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_REGISTERAUDIOFRAMEOBSERVER_89dd888, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (ret == 0)
            {
                AudioFrameObserverNative.SetAudioFrameObserver(audioFrameObserver);
            }
            else
            {
                UnSetIrisAudioFrameObserver();
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnRegisterAudioFrameObserver()
        {
            UnSetIrisAudioFrameObserver();
            return 0;
        }

        private void UnSetIrisAudioFrameObserver()
        {
            if (_rtcAudioFrameObserverHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERAUDIOFRAMEOBSERVER, "", 0, IntPtr.Zero, 0, ref _apiParam);
                AgoraRtcNative.DestroyIrisAudioFrameObserver(_rtcAudioFrameObserverHandle.handle);
                _rtcAudioFrameObserverHandle.handle = IntPtr.Zero;
                AudioFrameObserverNative.SetAudioFrameObserver(null);
            }
        }

        public int RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode)
        {
            if (_rtcVideoFrameObserverHandle.handle != IntPtr.Zero)
            {
                UnSetIrisVideoFrameObserver();
            }

            _rtcVideoFrameObserverHandle.handle = AgoraRtcNative.CreateIrisVideoFrameObserver(_rtcVideoFrameObserverHandle.c_handle);

            _param.Clear();
            _param.Add("observer", (ulong)_rtcVideoFrameObserverHandle.handle);
            _param.Add("mode", mode);
            var json = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_REGISTERVIDEOFRAMEOBSERVER_C08D649, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (ret == 0)
            {
                VideoFrameObserverNative.SetVideoFrameObserver(videoFrameObserver);
            }
            else
            {
                UnSetIrisVideoFrameObserver();
            }
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnRegisterVideoFrameObserver()
        {
            UnSetIrisVideoFrameObserver();
            return 0;
        }

        private void UnSetIrisVideoFrameObserver()
        {
            if (_rtcVideoFrameObserverHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERVIDEOFRAMEOBSERVER, "", 0, IntPtr.Zero, 0, ref _apiParam);
                AgoraRtcNative.DestroyIrisVideoFrameObserver(_rtcVideoFrameObserverHandle.handle);
                _rtcVideoFrameObserverHandle.handle = IntPtr.Zero;
                VideoFrameObserverNative.SetVideoFrameObserver(null);
            }
        }

        public int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver videoEncodedImageReceiver, OBSERVER_MODE mode)
        {
            if (_rtcVideoEncodedFrameObserverHandle.handle != IntPtr.Zero)
            {
                UnSetIrisVideoEncodedFrameObserver();
            }

            _rtcVideoEncodedFrameObserverHandle.handle = AgoraRtcNative.CreateIrisVideoEncodedFrameObserver(_rtcVideoEncodedFrameObserverHandle.c_handle);

            _param.Clear();
            _param.Add("observer", (ulong)_rtcVideoEncodedFrameObserverHandle.handle);
            _param.Add("mode", mode);
            var json = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_REGISTERVIDEOENCODEDFRAMEOBSERVER_4A1521C, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (ret == 0)
            {
                VideoEncodedFrameObserverNative.SetVideoEncodedFrameObserver(videoEncodedImageReceiver);
            }
            else
            {
                UnSetIrisVideoEncodedFrameObserver();
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnRegisterVideoEncodedFrameObserver()
        {
            UnSetIrisVideoEncodedFrameObserver();
            return 0;
        }

        private void UnSetIrisVideoEncodedFrameObserver()
        {
            if (_rtcVideoEncodedFrameObserverHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER, "", 0, IntPtr.Zero, 0, ref _apiParam);
                AgoraRtcNative.DestroyIrisVideoEncodedFrameObserver(_rtcVideoEncodedFrameObserverHandle.handle);
                _rtcVideoEncodedFrameObserverHandle.handle = IntPtr.Zero;
                VideoEncodedFrameObserverNative.SetVideoEncodedFrameObserver(null);
            }
        }

        public int RegisterFaceInfoObserver(IFaceInfoObserver observer)
        {
            if (_faceInfoObserverHandle.handle != IntPtr.Zero)
            {
                UnSetIrisFaceInfoObserver();
            }

            _faceInfoObserverHandle.handle = AgoraRtcNative.CreateIrisFaceInfoObserver(_faceInfoObserverHandle.c_handle);

            _param.Clear();
            _param.Add("observer", (ulong)_faceInfoObserverHandle.handle);
            var json = AgoraJson.ToJson(_param);

            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_REGISTERFACEINFOOBSERVER_741366E, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (ret == 0)
            {
                FaceInfoObserverNative.SetFaceInfoObserver(observer);
            }
            else
            {
                UnSetIrisFaceInfoObserver();
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnRegisterFaceInfoObserver()
        {
            UnSetIrisFaceInfoObserver();
            return 0;
        }

        private void UnSetIrisFaceInfoObserver()
        {
            if (_faceInfoObserverHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERFACEINFOOBSERVER, "", 0, IntPtr.Zero, 0, ref _apiParam);
                AgoraRtcNative.DestroyIrisFaceInfoObserver(_faceInfoObserverHandle.handle);
                _faceInfoObserverHandle.handle = IntPtr.Zero;
                FaceInfoObserverNative.SetFaceInfoObserver(null);
            }
        }

        private void UnSetIrisMetaDataObserver()
        {
            if (_rtcMetaDataObserverHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERMEDIAMETADATAOBSERVER, "", 0, IntPtr.Zero, 0, ref _apiParam);
                AgoraRtcNative.DestroyIrisMediaMetadataObserver(_rtcMetaDataObserverHandle.handle);
                _rtcMetaDataObserverHandle.handle = IntPtr.Zero;
                MetadataObserverNative.SetMetadataObserver(null);
            }
        }

        private void UnSetIrisAudioEncodedFrameObserver()
        {
            if (_rtcAudioEncodedFrameObserverHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERAUDIOENCODEDFRAMEOBSERVER, "", 0, IntPtr.Zero, 0, ref _apiParam);
                AgoraRtcNative.DestroyIrisAudioEncodedFrameObserver(_rtcAudioEncodedFrameObserverHandle.handle);
                _rtcAudioEncodedFrameObserverHandle.handle = IntPtr.Zero;
                AudioEncodedFrameObserverNative.SetAudioEncodedFrameObserver(null);
            }
        }

        private void UnSetIrisAudioSpectrumObserver()
        {
            if (_rtcAudioSpectrumObserverHandle.handle != IntPtr.Zero)
            {
                AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IRTCENGINE_UNREGISTERAUDIOSPECTRUMOBSERVER, "", 0, IntPtr.Zero, 0, ref _apiParam);
                AgoraRtcNative.DestroyIrisAudioSpectrumObserver(_rtcAudioSpectrumObserverHandle.handle);
                _rtcAudioSpectrumObserverHandle.handle = IntPtr.Zero;
                AudioSpectrumObserverNative.SetAudioSpectrumObserver(null);
            }
        }

        public int SetParametersEx(RtcConnection connection, string parameters)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("parameters", parameters);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, "RtcEngine_setParametersEx",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            return result;
        }
        
    }
}
