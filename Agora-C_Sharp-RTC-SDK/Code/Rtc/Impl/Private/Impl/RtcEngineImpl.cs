using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    using video_track_id_t = System.UInt32;
    using IrisRtcEnginePtr = IntPtr;
    using IrisVideoFrameBufferManagerPtr = IntPtr;

    internal class RtcEngineImpl
    {
        private bool _disposed = false;
        private static RtcEngineImpl engineInstance = null;
        private static readonly string identifier = "AgoraRtcEngine";


        private IrisRtcEnginePtr _irisRtcEngine;
        private IrisCApiParam _apiParam;


        private EventHandlerHandle _rtcEventHandlerHandle = new EventHandlerHandle();
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
#endif

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


        private IrisVideoFrameBufferManagerPtr _videoFrameBufferManagerPtr;

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
            _irisRtcEngine = AgoraRtcNative.CreateIrisApiEngine(nativePtr);

            _videoDeviceManagerInstance = new VideoDeviceManagerImpl(_irisRtcEngine);
            _audioDeviceManagerInstance = new AudioDeviceManagerImpl(_irisRtcEngine);
            _mediaPlayerInstance = new MediaPlayerImpl(_irisRtcEngine);
            _musicContentCenterImpl = new MusicContentCenterImpl(_irisRtcEngine, _mediaPlayerInstance);
            _spatialAudioEngineInstance = new LocalSpatialAudioEngineImpl(_irisRtcEngine);
            _mediaPlayerCacheManager = new MediaPlayerCacheManagerImpl(_irisRtcEngine);
            _mediaRecorderInstance = new MediaRecorderImpl(_irisRtcEngine);

            _videoFrameBufferManagerPtr = AgoraRtcNative.CreateIrisVideoFrameBufferManager();
            AgoraRtcNative.Attach(_irisRtcEngine, _videoFrameBufferManagerPtr);


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

                ReleaseEventHandler();
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

                AgoraRtcNative.Detach(_irisRtcEngine, _videoFrameBufferManagerPtr);
            }

            Release(sync);
            AgoraRtcNative.FreeIrisVideoFrameBufferManager(_videoFrameBufferManagerPtr);
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
            //AgoraRtcNative.DestroyApiParamsPtr();

            _apiParam.FreeResult();

            engineInstance = null;
        }

        private int CreateEventHandler()
        {
            if (_rtcEventHandlerHandle.handle != IntPtr.Zero) return 0;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcEventHandlerHandle, RtcEngineEventHandlerNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcEventHandlerHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTEREVENTHANDLER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_REGISTEREVENTHANDLER failed: " + nRet);
            }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
            RtcEngineEventHandlerNative.CallbackObject = _callbackObject;
#endif

            return nRet;

        }

        private void ReleaseEventHandler()
        {
            if (_rtcEventHandlerHandle.handle == IntPtr.Zero) return;


            RtcEngineEventHandlerNative.SetEventHandler(null);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            RtcEngineEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            IntPtr[] arrayPtr = new IntPtr[] { _rtcEventHandlerHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNREGISTEREVENTHANDLER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_UNREGISTEREVENTHANDLER failed: " + nRet);
            }

            AgoraUtil.FreeEventHandlerHandle(ref _rtcEventHandlerHandle);

        }

        internal IrisRtcEnginePtr GetNativeHandler()
        {
            return _irisRtcEngine;
        }

        internal IrisVideoFrameBufferManagerPtr GetVideoFrameBufferManager()
        {
            return _videoFrameBufferManagerPtr;
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
            if (ret == 0) SetAppType(AppType.APP_TYPE_UNITY);
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            if (ret == 0) SetAppType(AppType.APP_TYPE_C_SHARP);
#endif
            return ret;
        }

        public void Dispose(bool sync = false)
        {
            Dispose(true, sync);
            GC.SuppressFinalize(this);
        }

        public int InitEventHandler(IRtcEngineEventHandler engineEventHandler)
        {
            int ret = CreateEventHandler();
            RtcEngineEventHandlerNative.SetEventHandler(engineEventHandler);
            return ret;
        }

        public int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            int ret = SetIrisAudioFrameObserver();
            AudioFrameObserverNative.SetAudioFrameObserverAndMode(audioFrameObserver, mode);
            return ret;
        }

        public int UnRegisterAudioFrameObserver()
        {
            AudioFrameObserverNative.SetAudioFrameObserverAndMode(null, OBSERVER_MODE.INTPTR);
            return UnSetIrisAudioFrameObserver();
        }

        private int SetIrisAudioFrameObserver()
        {
            if (_rtcAudioFrameObserverHandle.handle != IntPtr.Zero) return 0;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcAudioFrameObserverHandle, AudioFrameObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_REGISTERAUDIOFRAMEOBSERVER,
                "{}", 2,
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
            if (_rtcAudioFrameObserverHandle.handle == IntPtr.Zero) return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_UNREGISTERAUDIOFRAMEOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraUtil.FreeEventHandlerHandle(ref _rtcAudioFrameObserverHandle);
            return nRet;
        }

        public int RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            int ret = SetIrisVideoFrameObserver();
            VideoFrameObserverNative.SetVideoFrameObserverAndMode(videoFrameObserver, mode);
            return ret;
        }

        public int UnRegisterVideoFrameObserver()
        {
            VideoFrameObserverNative.SetVideoFrameObserverAndMode(null, OBSERVER_MODE.INTPTR);
            return UnSetIrisVideoFrameObserver();
        }

        private int SetIrisVideoFrameObserver()
        {
            if (_rtcVideoFrameObserverHandle.handle != IntPtr.Zero) return 0;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcVideoFrameObserverHandle, VideoFrameObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoFrameObserverHandle.handle };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_REGISTERVIDEOFRAMEOBSERVER,
                "{}", 2,
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
            if (_rtcVideoFrameObserverHandle.handle == IntPtr.Zero) return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_UNREGISTERVIDEOFRAMEOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERVIDEOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraUtil.FreeEventHandlerHandle(ref _rtcVideoFrameObserverHandle);

            return nRet;
        }

        public int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver VideoEncodedFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            int ret = SetIrisVideoEncodedFrameObserver();
            VideoEncodedFrameObserverNative.SetVideoEncodedFrameObserver(VideoEncodedFrameObserver);
            return ret;
        }

        public int UnRegisterVideoEncodedFrameObserver()
        {
            VideoEncodedFrameObserverNative.SetVideoEncodedFrameObserver(null);
            return UnSetIrisVideoEncodedFrameObserver();
        }

        private int SetIrisVideoEncodedFrameObserver()
        {
            if (_rtcVideoEncodedFrameObserverHandle.handle != IntPtr.Zero) return 0;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcVideoEncodedFrameObserverHandle, VideoEncodedFrameObserverNative.OnEvent);
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
            if (_rtcVideoEncodedFrameObserverHandle.handle == IntPtr.Zero) return 0;
            IntPtr[] arrayPtr = new IntPtr[] { _rtcVideoEncodedFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER failed: " + nRet);
            }

            AgoraUtil.FreeEventHandlerHandle(ref _rtcVideoEncodedFrameObserverHandle);

            return nRet;
        }

        private int SetIrisMetaDataObserver(METADATA_TYPE type)
        {
            if (_rtcMetaDataObserverHandle.handle != IntPtr.Zero) return 0;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcMetaDataObserverHandle, MetadataObserverNative.OnEvent);
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
            if (_rtcMetaDataObserverHandle.handle == IntPtr.Zero) return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcMetaDataObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNREGISTERMEDIAMETADATAOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_RTCENGINE_UNREGISTERMEDIAMETADATAOBSERVER failed: " + nRet);
            }

            AgoraUtil.FreeEventHandlerHandle(ref _rtcMetaDataObserverHandle);

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



#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal IVideoStreamManager GetVideoStreamManager()
        {
            return new VideoStreamManager(this);
        }
#endif

        public string GetVersion(ref int build)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETVERSION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                build = (int)AgoraJson.GetData<int>(_apiParam.Result, "build");
            }
            else
            {
                build = 0;
            }
            return nRet != 0 ? null : (string)AgoraJson.GetData<string>(_apiParam.Result, "result");
        }

        public string GetErrorDescription(int code)
        {
            _param.Clear();
            _param.Add("code", code);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETERRORDESCRIPTION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? null : (string)AgoraJson.GetData<string>(_apiParam.Result, "result");
        }

        public int JoinChannel(string token, string channelId, string info = "",
                                uint uid = 0)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("info", info);
            _param.Add("uid", uid);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNEL,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int JoinChannel(string token, string channelId, uint uid,
                                ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("uid", uid);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNEL2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateChannelMediaOptions(ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATECHANNELMEDIAOPTIONS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int LeaveChannel()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_LEAVECHANNEL,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int LeaveChannel(LeaveChannelOptions options)
        {
            _param.Clear();
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_LEAVECHANNEL2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RenewToken(string token)
        {
            _param.Clear();
            _param.Add("token", token);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RENEWTOKEN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            _param.Clear();
            _param.Add("profile", profile);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCHANNELPROFILE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            _param.Clear();
            _param.Add("role", role);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCLIENTROLE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options)
        {
            _param.Clear();
            _param.Add("role", role);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCLIENTROLE2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int StartEchoTest()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTECHOTEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartEchoTest(int intervalInSeconds)
        {
            _param.Clear();
            _param.Add("intervalInSeconds", intervalInSeconds);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTECHOTEST2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

        }

        public int StartEchoTest(EchoTestConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTECHOTEST3,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopEchoTest()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPECHOTEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableVideo()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEVIDEO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int DisableVideo()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_DISABLEVIDEO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartPreview()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPREVIEW,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            _param.Clear();
            _param.Add("sourceType", sourceType);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPREVIEW2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopPreview()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPREVIEW,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            _param.Clear();
            _param.Add("sourceType", sourceType);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPREVIEW2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTLASTMILEPROBETEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopLastmileProbeTest()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPLASTMILEPROBETEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int GetNetworkType()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETNETWORKTYPE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }



        public int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVIDEOENCODERCONFIGURATION,
              json, (UInt32)json.Length,
              IntPtr.Zero, 0,
              ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("options", options);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETBEAUTYEFFECTOPTIONS,
              json, (UInt32)json.Length,
              IntPtr.Zero, 0,
              ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableAudio()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEAUDIO,
              json, (UInt32)json.Length,
              IntPtr.Zero, 0,
              ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int DisableAudio()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_DISABLEAUDIO,
              json, (UInt32)json.Length,
              IntPtr.Zero, 0,
              ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            _param.Clear();
            _param.Add("profile", profile);
            _param.Add("scenario", scenario);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOPROFILE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            _param.Clear();
            _param.Add("profile", profile);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOPROFILE2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableLocalAudio(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLELOCALAUDIO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteLocalAudioStream(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTELOCALAUDIOSTREAM,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteAllRemoteAudioStreams(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTEALLREMOTEAUDIOSTREAMS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEAUDIOSTREAMS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteRemoteAudioStream(uint uid, bool mute)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTEREMOTEAUDIOSTREAM,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteLocalVideoStream(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTELOCALVIDEOSTREAM,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableLocalVideo(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLELOCALVIDEO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteAllRemoteVideoStreams(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTEALLREMOTEVIDEOSTREAMS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEVIDEOSTREAMS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteRemoteVideoStream(uint uid, bool mute)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTEREMOTEVIDEOSTREAM,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("streamType", streamType);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEVIDEOSTREAMTYPE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            _param.Clear();
            _param.Add("streamType", streamType);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEDEFAULTVIDEOSTREAMTYPE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetDualStreamMode(SIMULCAST_STREAM_MODE mode)
        {
            _param.Clear();
            _param.Add("mode", mode);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDUALSTREAMMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig)
        {
            _param.Clear();
            _param.Add("mode", mode);
            _param.Add("streamConfig", streamConfig);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDUALSTREAMMODE2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mode", mode);
            _param.Add("streamConfig", streamConfig);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETDUALSTREAMMODEEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("uid", uid);
            _param.Add("filePath", filePath);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_TAKESNAPSHOTEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            _param.Clear();
            _param.Add("interval", interval);
            _param.Add("smooth", smooth);
            _param.Add("reportVad", reportVad);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEAUDIOVOLUMEINDICATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartAudioRecording(string filePath,
                                        AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            _param.Clear();
            _param.Add("filePath", filePath);
            _param.Add("quality", quality);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIORECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int StartAudioRecording(string filePath,
                                        int sampleRate,
                                        AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            _param.Clear();
            _param.Add("filePath", filePath);
            _param.Add("sampleRate", sampleRate);
            _param.Add("quality", quality);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIORECORDING2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartAudioRecording(AudioRecordingConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIORECORDING3,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)
        {
            int ret = SetIrisAudioEncodedFrameObserver(config);
            AudioEncodedFrameObserverNative.SetAudioEncodedFrameObserver(observer);
            return ret;
        }

        public int UnRegisterAudioEncodedFrameObserver()
        {
            AudioEncodedFrameObserverNative.SetAudioEncodedFrameObserver(null);
            return UnSetIrisAudioEncodedFrameObserver();
        }

        private int SetIrisAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config)
        {
            if (_rtcAudioEncodedFrameObserverHandle.handle != IntPtr.Zero) return 0;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcAudioEncodedFrameObserverHandle, AudioEncodedFrameObserverNative.OnEvent);
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
            if (_rtcAudioEncodedFrameObserverHandle.handle == IntPtr.Zero) return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioEncodedFrameObserverHandle.handle };
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNREGISTERAUDIOENCODEDFRAMEOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            AgoraUtil.FreeEventHandlerHandle(ref _rtcAudioEncodedFrameObserverHandle);
            return ret;
        }


        public int StopAudioRecording()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPAUDIORECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        //CreateMediaPlayer

        //DestroyMediaPlayer
        public int StartAudioMixing(string filePath, bool loopback, int cycle)
        {
            _param.Clear();
            _param.Add("filePath", filePath);
            _param.Add("loopback", loopback);
            _param.Add("cycle", cycle);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIOMIXING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos)
        {
            _param.Clear();
            _param.Add("filePath", filePath);
            _param.Add("loopback", loopback);
            _param.Add("cycle", cycle);
            _param.Add("startPos", startPos);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIOMIXING2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopAudioMixing()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPAUDIOMIXING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PauseAudioMixing()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEAUDIOMIXING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ResumeAudioMixing()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEAUDIOMIXING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AdjustAudioMixingVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTAUDIOMIXINGVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AdjustAudioMixingPublishVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTAUDIOMIXINGPUBLISHVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetAudioMixingPublishVolume()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOMIXINGPUBLISHVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AdjustAudioMixingPlayoutVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTAUDIOMIXINGPLAYOUTVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetAudioMixingPlayoutVolume()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOMIXINGPLAYOUTVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetAudioMixingDuration()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOMIXINGDURATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetAudioMixingCurrentPosition()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOMIXINGCURRENTPOSITION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetAudioMixingPosition(int pos /*in ms*/)
        {
            _param.Clear();
            _param.Add("pos", pos);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOMIXINGPOSITION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetAudioMixingPitch(int pitch)
        {
            _param.Clear();
            _param.Add("pitch", pitch);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOMIXINGPITCH,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetEffectsVolume()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETEFFECTSVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetEffectsVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEFFECTSVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            _param.Clear();
            _param.Add("soundId", soundId);
            _param.Add("filePath", filePath);
            _param.Add("startPos", startPos);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PRELOADEFFECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
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

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PLAYEFFECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
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

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PLAYALLEFFECTS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetVolumeOfEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETVOLUMEOFEFFECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetVolumeOfEffect(int soundId, int volume)
        {
            _param.Clear();
            _param.Add("soundId", soundId);
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOLUMEOFEFFECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PauseEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEEFFECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PauseAllEffects()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEALLEFFECTS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ResumeEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEEFFECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ResumeAllEffects()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEALLEFFECTS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPEFFECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopAllEffects()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPALLEFFECTS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnloadEffect(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNLOADEFFECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnloadAllEffects()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNLOADALLEFFECTS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int GetEffectCurrentPosition(int soundId)
        {
            _param.Clear();
            _param.Add("soundId", soundId);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETEFFECTCURRENTPOSITION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetEffectDuration(string filePath)
        {
            _param.Clear();
            _param.Add("filePath", filePath);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETEFFECTDURATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetEffectPosition(int soundId, int pos)
        {
            _param.Clear();
            _param.Add("soundId", soundId);
            _param.Add("pos", pos);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEFFECTPOSITION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableSoundPositionIndication(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLESOUNDPOSITIONINDICATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("pan", pan);
            _param.Add("gain", gain);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEVOICEPOSITION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableSpatialAudio(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLESPATIALAUDIO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            _param.Clear();
            _param.Add("preset", preset);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOICEBEAUTIFIERPRESET,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            _param.Clear();
            _param.Add("preset", preset);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOEFFECTPRESET,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            _param.Clear();
            _param.Add("preset", preset);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOICECONVERSIONPRESET,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            _param.Clear();
            _param.Add("preset", preset);
            _param.Add("param1", param1);
            _param.Add("param2", param2);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOEFFECTPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset,
                                                  int param1, int param2)
        {
            _param.Clear();
            _param.Add("preset", preset);
            _param.Add("param1", param1);
            _param.Add("param2", param2);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOICEBEAUTIFIERPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset,
                                                  int param1, int param2)
        {
            _param.Clear();
            _param.Add("preset", preset);
            _param.Add("param1", param1);
            _param.Add("param2", param2);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVOICECONVERSIONPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLocalVoicePitch(double pitch)
        {
            _param.Clear();
            _param.Add("pitch", pitch);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVOICEPITCH,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency,
                                              int bandGain)
        {
            _param.Clear();
            _param.Add("bandFrequency", bandFrequency);
            _param.Add("bandGain", bandGain);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVOICEEQUALIZATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            _param.Clear();
            _param.Add("reverbKey", reverbKey);
            _param.Add("value", value);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVOICEREVERB,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetHeadphoneEQParameters(int lowGain, int highGain)
        {
            _param.Clear();
            _param.Add("lowGain", lowGain);
            _param.Add("highGain", highGain);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETHEADPHONEEQPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset)
        {
            _param.Clear();
            _param.Add("preset", preset);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETHEADPHONEEQPRESET,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetLogFile(string filePath)
        {
            _param.Clear();
            _param.Add("filePath", filePath);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOGFILE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

        }

        public int SetLogFilter(uint filter)
        {
            _param.Clear();
            _param.Add("filter", filter);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOGFILTER,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLogLevel(LOG_LEVEL level)
        {
            _param.Clear();
            _param.Add("level", level);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOGLEVEL,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLogFileSize(uint fileSizeInKBytes)
        {
            _param.Clear();
            _param.Add("fileSizeInKBytes", fileSizeInKBytes);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOGFILESIZE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            _param.Clear();
            _param.Add("renderMode", renderMode);
            _param.Add("mirrorMode", mirrorMode);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALRENDERMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("renderMode", renderMode);
            _param.Add("mirrorMode", mirrorMode);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTERENDERMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            _param.Clear();
            _param.Add("renderMode", renderMode);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALRENDERMODE2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            _param.Clear();
            _param.Add("mirrorMode", mirrorMode);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALVIDEOMIRRORMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableDualStreamMode(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEDUALSTREAMMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("streamConfig", streamConfig);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEDUALSTREAMMODE2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("sampleRate", sampleRate);
            _param.Add("channels", channels);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_SETEXTERNALAUDIOSINK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartPrimaryCustomAudioTrack(AudioTrackConfig config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPRIMARYCUSTOMAUDIOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopPrimaryCustomAudioTrack()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPRIMARYCUSTOMAUDIOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartSecondaryCustomAudioTrack(AudioTrackConfig config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSECONDARYCUSTOMAUDIOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopSecondaryCustomAudioTrack()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPSECONDARYCUSTOMAUDIOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRecordingAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode,
            int samplesPerCall)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);
            _param.Add("mode", mode);
            _param.Add("samplesPerCall", samplesPerCall);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETRECORDINGAUDIOFRAMEPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetPlaybackAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);
            _param.Add("mode", mode);
            _param.Add("samplesPerCall", samplesPerCall);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETPLAYBACKAUDIOFRAMEPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);
            _param.Add("samplesPerCall", samplesPerCall);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETMIXEDAUDIOFRAMEPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);
            _param.Add("mode", mode);
            _param.Add("samplesPerCall", samplesPerCall);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEARMONITORINGAUDIOFRAMEPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            _param.Clear();
            _param.Add("sampleRate", sampleRate);
            _param.Add("channel", channel);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETPLAYBACKAUDIOFRAMEBEFOREMIXINGPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            _param.Clear();
            _param.Add("intervalInMS", intervalInMS);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEAUDIOSPECTRUMMONITOR,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int DisableAudioSpectrumMonitor()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_DISABLEAUDIOSPECTRUMMONITOR,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        private int SetIrisAudioSpectrumObserver()
        {
            if (_rtcAudioSpectrumObserverHandle.handle != IntPtr.Zero) return 0;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcAudioSpectrumObserverHandle, AudioSpectrumObserverNative.OnEvent);

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioSpectrumObserverHandle.handle };
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTERAUDIOSPECTRUMOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            return ret;
        }

        private int UnSetIrisAudioSpectrumObserver()
        {
            if (_rtcAudioSpectrumObserverHandle.handle == IntPtr.Zero) return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcAudioSpectrumObserverHandle.handle };
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UNREGISTERAUDIOSPECTRUMOBSERVER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            AgoraUtil.FreeEventHandlerHandle(ref _rtcAudioSpectrumObserverHandle);
            return ret;
        }

        public int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            int ret = SetIrisAudioSpectrumObserver();
            AudioSpectrumObserverNative.SetAudioSpectrumObserver(observer);
            return ret;
        }

        public int UnregisterAudioSpectrumObserver()
        {
            AudioSpectrumObserverNative.SetAudioSpectrumObserver(null);
            return UnSetIrisAudioSpectrumObserver();
        }

        public int AdjustRecordingSignalVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTRECORDINGSIGNALVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteRecordingSignal(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_MUTERECORDINGSIGNAL,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AdjustPlaybackSignalVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTPLAYBACKSIGNALVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTUSERPLAYBACKSIGNALVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableLoopbackRecording(bool enabled, string deviceName = "")
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("deviceName", deviceName);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLELOOPBACKRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetLoopbackRecordingVolume()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETLOOPBACKRECORDINGVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("includeAudioFilters", includeAudioFilters);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEINEARMONITORING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetInEarMonitoringVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETINEARMONITORINGVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int LoadExtensionProvider(string path, bool unload_after_use = false)
        {
            _param.Clear();
            _param.Add("path", path);
            _param.Add("unload_after_use", unload_after_use);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_LOADEXTENSIONPROVIDER,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetExtensionProviderProperty(string provider, string key, string value)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("key", key);
            _param.Add("value", value);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEXTENSIONPROVIDERPROPERTY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableExtension(string provider, string extension, bool enable, MEDIA_SOURCE_TYPE type)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("enable", enable);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEEXTENSION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("extensionInfo", extensionInfo);
            _param.Add("enable", enable);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEEXTENSION2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetExtensionProperty(
          string provider, string extension,
          string key, string value, MEDIA_SOURCE_TYPE type)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("key", key);
            _param.Add("value", value);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEXTENSIONPROPERTY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetExtensionProperty(
            string provider, string extension,
            ExtensionInfo extensionInfo, string key, string value)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("extensionInfo", extensionInfo);
            _param.Add("key", key);
            _param.Add("value", value);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETEXTENSIONPROPERTY2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int GetExtensionProperty(
          string provider, string extension,
          string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("key", key);
            _param.Add("value", value);
            _param.Add("buf_len", buf_len);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETEXTENSIONPROPERTY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {

                value = (string)AgoraJson.GetData<string>(_apiParam.Result, "value");
            }
            else
            {
                value = "";
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetExtensionProperty(
            string provider, string extension,
            ExtensionInfo extensionInfo, string key, ref string value, int buf_len)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("extensionInfo", extensionInfo);
            _param.Add("key", key);
            _param.Add("value", value);
            _param.Add("buf_len", buf_len);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETEXTENSIONPROPERTY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                value = (string)AgoraJson.GetData<string>(_apiParam.Result, "value");
            }
            else
            {
                value = "";
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERACAPTURERCONFIGURATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SwitchCamera()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SWITCHCAMERA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public bool IsCameraZoomSupported()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAZOOMSUPPORTED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
        }

        public bool IsCameraFaceDetectSupported()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAFACEDETECTSUPPORTED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
        }

        public bool IsCameraTorchSupported()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERATORCHSUPPORTED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
        }

        public bool IsCameraFocusSupported()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAFOCUSSUPPORTED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
        }

        public bool IsCameraAutoFocusFaceModeSupported()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAAUTOFOCUSFACEMODESUPPORTED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
        }

        public int SetCameraZoomFactor(float factor)
        {
            _param.Clear();
            _param.Add("factor", factor);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAZOOMFACTOR,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableFaceDetection(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEFACEDETECTION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public float GetCameraMaxZoomFactor()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETCAMERAMAXZOOMFACTOR,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (float)(double)AgoraJson.GetData<double>(_apiParam.Result, "result");
        }

        public int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            _param.Clear();
            _param.Add("positionX", positionX);
            _param.Add("positionY", positionY);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAFOCUSPOSITIONINPREVIEW,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetCameraTorchOn(bool isOn)
        {
            _param.Clear();
            _param.Add("isOn", isOn);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERATORCHON,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAAUTOFOCUSFACEMODEENABLED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public bool IsCameraExposurePositionSupported()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAEXPOSUREPOSITIONSUPPORTED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
        }


        public int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            _param.Clear();
            _param.Add("positionXinView", positionXinView);
            _param.Add("positionYinView", positionYinView);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAEXPOSUREPOSITION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public bool IsCameraAutoExposureFaceModeSupported()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISCAMERAAUTOEXPOSUREFACEMODESUPPORTED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
        }

        public int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERAAUTOEXPOSUREFACEMODEENABLED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            _param.Clear();
            _param.Add("defaultToSpeaker", defaultToSpeaker);



            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDEFAULTAUDIOROUTETOSPEAKERPHONE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetEnableSpeakerphone(bool speakerOn)
        {
            _param.Clear();
            _param.Add("speakerOn", speakerOn);



            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETENABLESPEAKERPHONE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public bool IsSpeakerphoneEnabled()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ISSPEAKERPHONEENABLED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? false : (bool)AgoraJson.GetData<bool>(_apiParam.Result, "result");
        }

        public int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect,
                                                ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("displayId", displayId);
            _param.Add("regionRect", regionRect);
            _param.Add("captureParams", captureParams);



            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTUREBYDISPLAYID,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartScreenCaptureByScreenRect(Rectangle screenRect,
                                                 Rectangle regionRect,
                                                 ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("screenRect", screenRect);
            _param.Add("regionRect", regionRect);
            _param.Add("captureParams", captureParams);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTUREBYSCREENRECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect,
                                               ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("windowId", windowId);
            _param.Add("regionRect", regionRect);
            _param.Add("captureParams", captureParams);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTUREBYWINDOWID,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            _param.Clear();
            _param.Add("contentHint", contentHint);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSCREENCAPTURECONTENTHINT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            _param.Clear();
            _param.Add("regionRect", regionRect);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATESCREENCAPTUREREGION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("captureParams", captureParams);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATESCREENCAPTUREPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopScreenCapture()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPSCREENCAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetCallId(ref string callId)
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETCALLID,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            callId = nRet != 0 ? "" : (string)AgoraJson.GetData<string>(_apiParam.Result, "callId");

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Rate(string callId, int rating,
                        string description)
        {
            _param.Clear();
            _param.Add("callId", callId);
            _param.Add("rating", rating);
            _param.Add("description", description);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RATE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Complain(string callId, string description)
        {
            _param.Clear();
            _param.Add("callId", callId);
            _param.Add("description", description);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_COMPLAIN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);



            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTLOCALVIDEOTRANSCODER,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATELOCALTRANSCODERCONFIGURATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopLocalVideoTranscoder()
        {
            _param.Clear();



            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPLOCALVIDEOTRANSCODER,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("config", config);



            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEMULTICAMERA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int StartPrimaryCameraCapture(CameraCapturerConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPRIMARYCAMERACAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartSecondaryCameraCapture(CameraCapturerConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSECONDARYCAMERACAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopPrimaryCameraCapture()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPRIMARYCAMERACAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopSecondaryCameraCapture()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPSECONDARYCAMERACAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            _param.Clear();
            _param.Add("type", type);
            _param.Add("orientation", orientation);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCAMERADEVICEORIENTATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            _param.Clear();
            _param.Add("type", type);
            _param.Add("orientation", orientation);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSCREENCAPTUREORIENTATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartPrimaryScreenCapture(ScreenCaptureConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTPRIMARYSCREENCAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartSecondaryScreenCapture(ScreenCaptureConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSECONDARYSCREENCAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopPrimaryScreenCapture()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPPRIMARYSCREENCAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopSecondaryScreenCapture()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPSECONDARYSCREENCAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETCONNECTIONSTATE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            CONNECTION_STATE_TYPE type = (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(_apiParam.Result, "result");
            return type;
        }

        public int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("userPriority", userPriority);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEUSERPRIORITY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        // public int RegisterPacketObserver(IPacketObserver observer)
        // {
        //     //todo 
        //     //var param = new
        //     //{
        //     //    observer
        //     //};
        //     //return AgoraRtcNative.CallIrisRtcEngineApi(_irisRtcEngine,
        //     //    ApiTypeEngine.kEngineRegisterPacketObserver,
        //     //    AgoraJson.ToJson(param),
        //     //    out _result);
        // }


        public int SetEncryptionMode(string encryptionMode)
        {
            _param.Clear();
            _param.Add("encryptionMode", encryptionMode);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETENCRYPTIONMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetEncryptionSecret(string secret)
        {
            _param.Clear();
            _param.Add("secret", secret);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETENCRYPTIONSECRET,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEENCRYPTION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            _param.Clear();
            _param.Add("reliable", reliable);
            _param.Add("ordered", ordered);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CREATEDATASTREAM,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_apiParam.Result, "streamId");
            }
            else
            {
                streamId = 0;
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int CreateDataStream(ref int streamId, DataStreamConfig config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CREATEDATASTREAM2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_apiParam.Result, "streamId");
            }
            else
            {
                streamId = 0;
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AddVideoWatermark(RtcImage watermark)
        {
            _param.Clear();
            _param.Add("watermark", watermark);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADDVIDEOWATERMARK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

        }

        public int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            _param.Clear();
            _param.Add("watermarkUrl", watermarkUrl);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADDVIDEOWATERMARK2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ClearVideoWatermarks()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CLEARVIDEOWATERMARKS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PauseAudio()
        {
            _param.Clear();



            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEAUDIO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ResumeAudio()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEAUDIO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableWebSdkInteroperability(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEWEBSDKINTEROPERABILITY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
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

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SENDCUSTOMREPORTMESSAGE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type)
        {
            var ret = SetIrisMetaDataObserver(type);
            MetadataObserverNative.SetMetadataObserver(observer);
            return ret;
        }

        public int UnregisterMediaMetadataObserver()
        {
            MetadataObserverNative.SetMetadataObserver(null);
            return UnSetIrisMetaDataObserver();
        }

        public int StartAudioFrameDump(string channel_id, uint user_id, string location,
            string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            _param.Clear();
            _param.Add("channel_id", channel_id);
            _param.Add("user_id", user_id);
            _param.Add("location", location);
            _param.Add("uuid", uuid);
            _param.Add("passwd", passwd);
            _param.Add("duration_ms", duration_ms);
            _param.Add("auto_upload", auto_upload);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTAUDIOFRAMEDUMP,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopAudioFrameDump(string channel_id, uint user_id, string location)
        {
            _param.Clear();
            _param.Add("channel_id", channel_id);
            _param.Add("user_id", user_id);
            _param.Add("location", location);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPAUDIOFRAMEDUMP,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RegisterLocalUserAccount(string appId, string userAccount)
        {
            _param.Clear();
            _param.Add("appId", appId);
            _param.Add("userAccount", userAccount);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTERLOCALUSERACCOUNT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int JoinChannelWithUserAccount(string token, string channelId,
                                              string userAccount)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("userAccount", userAccount);



            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int JoinChannelWithUserAccount(string token, string channelId,
                                                string userAccount, ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("userAccount", userAccount);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNT2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int JoinChannelWithUserAccountEx(string token, string channelId,
                                                string userAccount, ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channelId", channelId);
            _param.Add("userAccount", userAccount);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNTEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo)
        {
            _param.Clear();
            _param.Add("userAccount", userAccount);
            //_param.Add("userInfo", userInfo);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETUSERINFOBYUSERACCOUNT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_apiParam.Result, "userInfo");
            }
            else
            {
                userInfo = new UserInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetUserInfoByUid(uint uid, ref UserInfo userInfo)
        {
            _param.Clear();
            _param.Add("uid", uid);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETUSERINFOBYUID,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_apiParam.Result, "userInfo");
            }
            else
            {
                userInfo = new UserInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            _param.Clear();
            _param.Add("configuration", configuration);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTCHANNELMEDIARELAY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            _param.Clear();
            _param.Add("configuration", configuration);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATECHANNELMEDIARELAY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopChannelMediaRelay()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPCHANNELMEDIARELAY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            _param.Clear();
            _param.Add("profile", profile);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDIRECTCDNSTREAMINGAUDIOCONFIGURATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETDIRECTCDNSTREAMINGVIDEOCONFIGURATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            var nRet = CreateEventHandler();
            if (nRet != 0) return nRet;

            _param.Clear();
            _param.Add("publishUrl", publishUrl);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { _rtcEventHandlerHandle.handle };
            nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTDIRECTCDNSTREAMING,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopDirectCdnStreaming()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPDIRECTCDNSTREAMING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        {
            _param.Clear();
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATEDIRECTCDNSTREAMINGMEDIAOPTIONS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("connection", connection);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_JOINCHANNELEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int LeaveChannelEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_LEAVECHANNELEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_LEAVECHANNELEX2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("options", options);
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_UPDATECHANNELMEDIAOPTIONSEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("config", config);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETVIDEOENCODERCONFIGURATIONEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("mute", mute);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_MUTEREMOTEAUDIOSTREAMEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("mute", mute);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_MUTEREMOTEVIDEOSTREAMEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("pan", pan);
            _param.Add("gain", gain);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTEVOICEPOSITIONEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams @params, RtcConnection connection)
        {
            var param1 = new
            {
                uid,
                @params,
                connection
            };
            var json = AgoraJson.ToJson(param1);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTEUSERSPATIALAUDIOPARAMSEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode,
                                          VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("renderMode", renderMode);
            _param.Add("mirrorMode", mirrorMode);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTERENDERMODEEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("enabled", enabled);
            _param.Add("deviceName", deviceName);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ENABLELOOPBACKRECORDINGEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_GETCONNECTIONSTATEEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            CONNECTION_STATE_TYPE type = (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(_apiParam.Result, "result");
            return type;
        }

        public int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("enabled", enabled);
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ENABLEENCRYPTIONEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("reliable", reliable);
            _param.Add("ordered", ordered);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_CREATEDATASTREAMEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_apiParam.Result, "streamId");
            }
            else
            {
                streamId = 0;
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("config", config);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_CREATEDATASTREAMEX2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            if (nRet == 0)
            {
                streamId = (int)AgoraJson.GetData<int>(_apiParam.Result, "streamId");
            }
            else
            {
                streamId = 0;
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("watermarkUrl", watermarkUrl);
            _param.Add("options", options);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ADDVIDEOWATERMARKEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ClearVideoWatermarkEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_CLEARVIDEOWATERMARKEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
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

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SENDCUSTOMREPORTMESSAGEEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
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

        public int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("useTexture", useTexture);
            _param.Add("sourceType", sourceType);
            _param.Add("encodedVideoOption", encodedVideoOption);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_SETEXTERNALVIDEOSOURCE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("sampleRate", sampleRate);
            _param.Add("channels", channels);
            _param.Add("sourceNumber", sourceNumber);
            _param.Add("localPlayback", localPlayback);
            _param.Add("publish", publish);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_SETEXTERNALAUDIOSOURCE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {

            _param.Clear();
            _param.Add("restriction", restriction);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOSESSIONOPERATIONRESTRICTION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AdjustCustomAudioPublishVolume(int sourceId, int volume)
        {
            _param.Clear();
            _param.Add("sourceId", sourceId);
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTCUSTOMAUDIOPUBLISHVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AdjustCustomAudioPlayoutVolume(int sourceId, int volume)
        {
            _param.Clear();
            _param.Add("sourceId", sourceId);
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTCUSTOMAUDIOPLAYOUTVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetParameters(string parameters)
        {
            _param.Clear();
            _param.Add("parameters", parameters);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETPARAMETERS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetAudioDeviceInfo(ref DeviceInfo deviceInfo)
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIODEVICEINFO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                deviceInfo = AgoraJson.JsonToStruct<DeviceInfo>(_apiParam.Result, "deviceInfo");
            }
            else
            {
                deviceInfo = new DeviceInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableCustomAudioLocalPlayback(int sourceId, bool enabled)
        {
            _param.Clear();
            _param.Add("sourceId", sourceId);
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLECUSTOMAUDIOLOCALPLAYBACK,//todo two key found.
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("backgroundSource", backgroundSource);
            _param.Add("segproperty", segproperty);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEVIRTUALBACKGROUND,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            _param.Clear();
            _param.Add("option", option);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALPUBLISHFALLBACKOPTION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            _param.Clear();
            _param.Add("option", option);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTESUBSCRIBEFALLBACKOPTION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PauseAllChannelMediaRelay()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_PAUSEALLCHANNELMEDIARELAY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ResumeAllChannelMediaRelay()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_RESUMEALLCHANNELMEDIARELAY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("audioSourceDelay", audioSourceDelay);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEECHOCANCELLATIONEXTERNAL,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            _param.Clear();
            _param.Add("sound1", sound1);
            _param.Add("sound2", sound2);
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTRHYTHMPLAYER,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopRhythmPlayer()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPRHYTHMPLAYER,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CONFIGRHYTHMPLAYER,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams @params)
        {
            var param1 = new
            {
                uid,
                @params
            };

            var json = AgoraJson.ToJson(param1);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEUSERSPATIALAUDIOPARAMS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetDirectExternalAudioSource(bool enable, bool localPlayback)
        {
            _param.Clear();
            _param.Add("enable", enable);
            _param.Add("localPlayback", localPlayback);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_SETDIRECTEXTERNALAUDIOSOURCE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            _param.Clear();
            _param.Add("proxyType", proxyType);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCLOUDPROXY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLocalAccessPoint(LocalAccessPointConfiguration config)
        {
            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOCALACCESSPOINT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        //public int EnableFishEyeCorrection(bool enabled, FishEyeCorrectionParams @params)
        //{
        //    var param = new
        //    {
        //        enabled,
        //        @params
        //    };

        //    var json = AgoraJson.ToJson(param);

        //    var nRet = AgoraRtcNative.CallIrisApi(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEFISHEYECORRECTION,
        //        json, (UInt32)json.Length,
        //        IntPtr.Zero, 0,
        //        out _result);

        //    return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        //}

        public int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType)
        {
            _param.Clear();
            _param.Add("options", options);
            _param.Add("sourceType", sourceType);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETADVANCEDAUDIOOPTIONS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetAVSyncSource(string channelId, uint uid)
        {
            _param.Clear();
            _param.Add("channelId", channelId);
            _param.Add("uid", uid);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAVSYNCSOURCE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartRtmpStreamWithoutTranscoding(string url)
        {
            _param.Clear();
            _param.Add("url", url);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTRTMPSTREAMWITHOUTTRANSCODING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            _param.Clear();
            _param.Add("url", url);
            _param.Add("transcoding", transcoding);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTRTMPSTREAMWITHTRANSCODING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            _param.Clear();
            _param.Add("transcoding", transcoding);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATERTMPTRANSCODING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopRtmpStream(string url)
        {
            _param.Clear();
            _param.Add("url", url);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STOPRTMPSTREAM,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("userAccount", userAccount);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_GETUSERINFOBYUSERACCOUNTEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_apiParam.Result, "userInfo");
            }
            else
            {
                userInfo = new UserInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_GETUSERINFOBYUIDEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0)
            {
                userInfo = AgoraJson.JsonToStruct<UserInfo>(_apiParam.Result, "userInfo");
            }
            else
            {
                userInfo = new UserInfo();
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableRemoteSuperResolution(uint userId, bool enable)
        {
            _param.Clear();
            _param.Add("userId", userId);
            _param.Add("enable", enable);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEREMOTESUPERRESOLUTION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("streamType", streamType);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTEVIDEOSTREAMTYPEEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("interval", interval);
            _param.Add("smooth", smooth);
            _param.Add("reportVad", reportVad);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ENABLEAUDIOVOLUMEINDICATIONEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetVideoProfileEx(int width, int height, int frameRate, int bitrate)
        {
            _param.Clear();
            _param.Add("width", width);
            _param.Add("height", height);
            _param.Add("frameRate", frameRate);
            _param.Add("bitrate", bitrate);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETVIDEOPROFILEEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("streamConfig", streamConfig);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ENABLEDUALSTREAMMODEEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int UploadLogFile(ref string requestId)
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPLOADLOGFILE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            else
            {
                requestId = "";
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

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
                    var screenCaptureSourceInfo = new ScreenCaptureSourceInfo();
                    screenCaptureSourceInfo.type = infoInternal[i].type;
                    screenCaptureSourceInfo.isOccluded = infoInternal[i].isOccluded;
                    screenCaptureSourceInfo.primaryMonitor = infoInternal[i].primaryMonitor;
                    screenCaptureSourceInfo.processPath = infoInternal[i].processPath;
                    screenCaptureSourceInfo.sourceId = infoInternal[i].sourceId;
                    screenCaptureSourceInfo.sourceName = infoInternal[i].sourceName;
                    screenCaptureSourceInfo.sourceTitle = infoInternal[i].sourceTitle;
                    ThumbImageBuffer imageBuffer = new ThumbImageBuffer();
                    imageBuffer.height = infoInternal[i].thumbImage.height;
                    imageBuffer.width = infoInternal[i].thumbImage.width;
                    imageBuffer.length = infoInternal[i].thumbImage.length;
                    byte[] thumbBuffer = new byte[imageBuffer.length];
                    if (imageBuffer.length > 0)
                    {
                        Marshal.Copy((IntPtr)(infoInternal[i].thumbImage.buffer), thumbBuffer, 0, (int)imageBuffer.length);
                    }
                    imageBuffer.buffer = thumbBuffer;
                    screenCaptureSourceInfo.thumbImage = imageBuffer;

                    ThumbImageBuffer imageBuffer2 = new ThumbImageBuffer();
                    imageBuffer2.height = infoInternal[i].iconImage.height;
                    imageBuffer2.width = infoInternal[i].iconImage.width;
                    imageBuffer2.length = infoInternal[i].iconImage.length;
                    byte[] iconbBuffer = new byte[imageBuffer2.length];
                    if (imageBuffer2.length > 0)
                    {
                        Marshal.Copy((IntPtr)(infoInternal[i].iconImage.buffer), iconbBuffer, 0, (int)imageBuffer2.length);
                    }
                    imageBuffer2.buffer = iconbBuffer;
                    screenCaptureSourceInfo.iconImage = imageBuffer2;
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

        public int AdjustLoopbackSignalVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);


            var json = AgoraJson.ToJson(_param);

            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ADJUSTLOOPBACKSIGNALVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public video_track_id_t CreateCustomEncodedVideoTrack(SenderOptions sender_option)
        {
            _param.Clear();
            _param.Add("sender_option", sender_option);


            var json = AgoraJson.ToJson(_param);

            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CREATECUSTOMENCODEDVIDEOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogWarning("CreateCustomEncodedVideoTrack: IrisError:" + nRet);
            }

            return nRet != 0 ? 0 : (uint)AgoraJson.GetData<uint>(_apiParam.Result, "result");
        }

        public video_track_id_t CreateCustomVideoTrack()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);

            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_CREATECUSTOMVIDEOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogWarning("createCustomVideoTrack: IrisError:" + nRet);
            }

            return nRet != 0 ? 0 : (uint)AgoraJson.GetData<uint>(_apiParam.Result, "result");
        }

        public int DestroyCustomEncodedVideoTrack(video_track_id_t video_track_id)
        {
            _param.Clear();
            _param.Add("video_track_id", video_track_id);


            var json = AgoraJson.ToJson(_param);

            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_DESTROYCUSTOMENCODEDVIDEOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int DestroyCustomVideoTrack(video_track_id_t video_track_id)
        {
            _param.Clear();
            _param.Add("video_track_id", video_track_id);


            var json = AgoraJson.ToJson(_param);

            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_DESTROYCUSTOMVIDEOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableContentInspect(bool enabled, ContentInspectConfig config)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);

            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLECONTENTINSPECT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableVideoImageSource(bool enable, ImageTrackOptions options)
        {
            _param.Clear();
            _param.Add("enable", enable);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEVIDEOIMAGESOURCE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableWirelessAccelerate(bool enabled)
        {
            _param.Clear();
            _param.Add("enabled", enabled);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_ENABLEWIRELESSACCELERATE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetAudioTrackCount()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETAUDIOTRACKCOUNT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SelectAudioTrack(int index)
        {
            _param.Clear();
            _param.Add("index", index);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SELECTAUDIOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode)
        {
            _param.Clear();
            _param.Add("mode", mode);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOMIXINGDUALMONOMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario)
        {
            _param.Clear();
            _param.Add("scenario", scenario);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETAUDIOSCENARIO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("options", options);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETCOLORENHANCEOPTIONS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("options", options);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETLOWLIGHTENHANCEOPTIONS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETREMOTEVIDEOSUBSCRIPTIONOPTIONS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario)
        {
            _param.Clear();
            _param.Add("screenScenario", screenScenario);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSCREENCAPTURESCENARIO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSUBSCRIBEAUDIOBLOCKLIST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSUBSCRIBEAUDIOALLOWLIST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSUBSCRIBEVIDEOBLOCKLIST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETSUBSCRIBEVIDEOALLOWLIST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type)
        {
            _param.Clear();
            _param.Add("enabled", enabled);
            _param.Add("options", options);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETVIDEODENOISEROPTIONS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int StartScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            _param.Clear();
            _param.Add("captureParams", captureParams);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            _param.Clear();
            _param.Add("captureParams", captureParams);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_UPDATESCREENCAPTURE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int TakeSnapshot(uint uid, string filePath)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("filePath", filePath);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_TAKESNAPSHOT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public long GetCurrentMonotonicTimeInMs()
        {
            _param.Clear();


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_GETCURRENTMONOTONICTIMEINMS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (long)AgoraJson.GetData<long>(_apiParam.Result, "result");
        }


        public int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("options", options);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETREMOTEVIDEOSUBSCRIPTIONOPTIONSEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETSUBSCRIBEAUDIOBLOCKLISTEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETSUBSCRIBEAUDIOALLOWLISTEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETSUBSCRIBEVIDEOBLOCKLISTEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uidList", uidList);
            _param.Add("uidNumber", uidNumber);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETSUBSCRIBEVIDEOALLOWLISTEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteLocalAudioStreamEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_MUTELOCALAUDIOSTREAMEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteLocalVideoStreamEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_MUTELOCALVIDEOSTREAMEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_MUTEALLREMOTEAUDIOSTREAMSEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("mute", mute);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_MUTEALLREMOTEVIDEOSTREAMSEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("uid", uid);
            _param.Add("volume", volume);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_ADJUSTUSERPLAYBACKSIGNALVOLUMEEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("url", url);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_STARTRTMPSTREAMWITHOUTTRANSCODINGEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("url", url);
            _param.Add("transcoding", transcoding);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_STARTRTMPSTREAMWITHTRANSCODINGEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("transcoding", transcoding);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_UPDATERTMPTRANSCODINGEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopRtmpStreamEx(string url, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("url", url);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_STOPRTMPSTREAMEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("configuration", configuration);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_STARTCHANNELMEDIARELAYEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("configuration", configuration);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_UPDATECHANNELMEDIARELAYEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopChannelMediaRelayEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_STOPCHANNELMEDIARELAYEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PauseAllChannelMediaRelayEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_PAUSEALLCHANNELMEDIARELAYEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ResumeAllChannelMediaRelayEx(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_RESUMEALLCHANNELMEDIARELAYEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

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

        public int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type)
        {
            _param.Clear();
            _param.Add("provider", provider);
            _param.Add("extension", extension);
            _param.Add("type", type);


            var json = AgoraJson.ToJson(_param);

            var nRet =
                AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_REGISTEREXTENSION, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        #region CallIrisApiWithBuffer

        public int SetupRemoteVideo(VideoCanvas canvas)
        {
            _param.Clear();
            _param.Add("canvas", canvas);


            var json = AgoraJson.ToJson(_param);


            IntPtr[] arrayPtr = new IntPtr[] { (IntPtr)canvas.view };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETUPREMOTEVIDEO,
               json, (UInt32)json.Length,
               Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
               ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetupLocalVideo(VideoCanvas canvas)
        {
            _param.Clear();
            _param.Add("canvas", canvas);


            var json = AgoraJson.ToJson(_param);


            IntPtr[] arrayPtr = new IntPtr[] { (IntPtr)canvas.view };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SETUPLOCALVIDEO,
               json, (UInt32)json.Length,
               Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
               ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartScreenCapture(byte[] mediaProjectionPermissionResultData,
                                    ScreenCaptureParameters captureParams)
        {
            _param.Clear();
            _param.Add("captureParams", captureParams);


            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(mediaProjectionPermissionResultData, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_STARTSCREENCAPTURE,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, (uint)mediaProjectionPermissionResultData.Length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            _param.Clear();
            _param.Add("streamId", streamId);
            _param.Add("length", length);


            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINE_SENDSTREAMMESSAGE,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("streamId", streamId);
            _param.Add("length", length);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SENDSTREAMMESSAGEEX,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            _param.Clear();
            _param.Add("canvas", canvas);
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);


            IntPtr[] arrayPtr = new IntPtr[] { (IntPtr)canvas.view };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_RTCENGINEEX_SETUPREMOTEVIDEOEX,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame,
                             bool wrap = false, int sourceId = 0)
        {
            _param.Clear();
            _param.Add("type", type);
            _param.Add("frame", new AudioFrameInternal(frame));
            _param.Add("wrap", wrap);
            _param.Add("sourceId", sourceId);


            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.RawBuffer, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHAUDIOFRAME,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, (uint)frame.RawBuffer.Length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int PushCaptureAudioFrame(AudioFrame frame)
        {
            _param.Clear();
            _param.Add("frame", new AudioFrameInternal(frame));


            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.RawBuffer, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHCAPTUREAUDIOFRAME,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, (uint)frame.RawBuffer.Length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PushReverseAudioFrame(AudioFrame frame)
        {
            _param.Clear();
            _param.Add("frame", new AudioFrameInternal(frame));


            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.RawBuffer, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHREVERSEAUDIOFRAME,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, (uint)frame.RawBuffer.Length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

        }

        public int PushDirectAudioFrame(AudioFrame frame)
        {
            _param.Clear();
            _param.Add("frame", new AudioFrameInternal(frame));

            var json = AgoraJson.ToJson(_param);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.RawBuffer, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHDIRECTAUDIOFRAME,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, (uint)frame.RawBuffer.Length);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

        }


        public int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId)
        {
            _param.Clear();
            _param.Add("frame", new ExternalVideoFrameInternal(frame));
            _param.Add("videoTrackId", videoTrackId);


            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(frame.buffer, 0);
            IntPtr eglContextPtr = IntPtr.Zero;
            IntPtr metadataPtr = IntPtr.Zero;
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr, eglContextPtr, metadataPtr };

            var json = AgoraJson.ToJson(_param);


            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisRtcEngine, AgoraApiType.FUNC_MEDIAENGINE_PUSHVIDEOFRAME,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 3,
                ref _apiParam, (uint)frame.buffer.Length, 0, 0);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int PushEncodedVideoImage(byte[] imageBuffer, uint length,
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
                ref _apiParam, length);

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
                frame.avsync_type = f.avsync_type;
                frame.channels = f.channels;
                frame.samplesPerChannel = f.samplesPerChannel;
                frame.type = f.type;
                frame.bytesPerSample = f.bytesPerSample;
                frame.renderTimeMs = f.renderTimeMs;
                frame.samplesPerSec = f.samplesPerSec;
            }
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }



        #endregion CallIrisApiWithBuffer end

        public bool StartDumpVideo(VIDEO_SOURCE_TYPE type, string dir)
        {
            return AgoraRtcNative.StartDumpVideo(_videoFrameBufferManagerPtr, type, dir);
        }

        public bool StopDumpVideo()
        {
            return AgoraRtcNative.StopDumpVideo(_videoFrameBufferManagerPtr);
        }


        ~RtcEngineImpl()
        {
            Dispose(false, false);
        }
    }
}
