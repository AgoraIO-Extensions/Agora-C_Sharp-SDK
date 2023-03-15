using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif
using Agora.Rtc;

namespace Agora.Rtm.Internal
{
    using IrisApiRtmEnginePtr = IntPtr;

    internal class RtmClientImpl
    {
        private bool _disposed = false;
        private static RtmClientImpl clientInstance = null;
        private static readonly string identifier = "AgoraRtmClient";
        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();

        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisApiParam _apiParam;
        private EventHandlerHandle _rtcEventHandlerHandle = new EventHandlerHandle();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
#endif

        private StreamChannelImpl _streamChannelImpl;
        private RtmLockImpl _rtmLockImpl;
        private RtmPresenceImpl _rtmPresenceImpl;
        private RtmStorageImpl _rtmStorageImpl;

        public event Action<RtmClientImpl> OnRtmClientImpleWillDispose;

        private RtmClientImpl()
        {
            _apiParam = new IrisApiParam();
            _apiParam.AllocResult();

            _irisApiRtmEngine = AgoraRtmNative.CreateIrisRtmEngine(IntPtr.Zero);

            _streamChannelImpl = new StreamChannelImpl(_irisApiRtmEngine);
            _rtmLockImpl = new RtmLockImpl(_irisApiRtmEngine);
            _rtmPresenceImpl = new RtmPresenceImpl(_irisApiRtmEngine);
            _rtmStorageImpl = new RtmStorageImpl(_irisApiRtmEngine);
        }

        ~RtmClientImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (this.OnRtmClientImpleWillDispose != null)
                {
                    this.OnRtmClientImpleWillDispose.Invoke(this);
                }

                int ret = UnregisterEventHandler();
                if (ret != 0)
                {
                    AgoraLog.LogError("rtmClient UnregisterEventHandler failed: " + ret);
                }
                ReleaseEventHandler();

                _streamChannelImpl.Dispose();
                _streamChannelImpl = null;

                _rtmLockImpl.Dispose();
                _rtmLockImpl = null;

                _rtmPresenceImpl.Dispose();
                _rtmPresenceImpl = null;

                _rtmStorageImpl.Dispose();
                _rtmStorageImpl = null;
            }

            Release();

            _apiParam.FreeResult();
            _disposed = true;
        }

        private int UnregisterEventHandler()
        {
            if (_rtcEventHandlerHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _rtcEventHandlerHandle.handle };

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_UNREGISTEREVENTHANDLER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        private void Release()
        {
            AgoraRtmNative.CallIrisApiWithArgs(
                _irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_RELEASE,
                "{}", 2,
                IntPtr.Zero, 0,
                ref _apiParam);

            AgoraRtmNative.DestroyIrisRtmEngine(_irisApiRtmEngine);

            _irisApiRtmEngine = IntPtr.Zero;
            clientInstance = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        internal StreamChannelImpl GetStreamChannelImpl()
        {
            return _streamChannelImpl;
        }

        internal RtmLockImpl GetRtmLockImpl()
        {
            return _rtmLockImpl;
        }

        internal RtmPresenceImpl GetRtmPresenceImpl()
        {
            return _rtmPresenceImpl;
        }

        internal RtmStorageImpl GetRtmStorageImpl()
        {
            return _rtmStorageImpl;
        }


        private void CreateEventHandler()
        {
            if (_rtcEventHandlerHandle.handle != IntPtr.Zero) return;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcEventHandlerHandle, RtmEventHandlerNative.OnEvent, this._irisApiRtmEngine);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
            RtmEventHandlerNative.CallbackObject = _callbackObject;
#endif
        }

        private void ReleaseEventHandler()
        {
            if (_rtcEventHandlerHandle.handle == IntPtr.Zero) return;


            RtmEventHandlerNative.SetEventHandler(null);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            RtmEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif

            AgoraUtil.FreeEventHandlerHandle(ref _rtcEventHandlerHandle, this._irisApiRtmEngine);

        }

        internal IrisApiRtmEnginePtr GetNativeHandler()
        {
            return _irisApiRtmEngine;
        }

        public static RtmClientImpl GetInstance()
        {
            return clientInstance ?? (clientInstance = new RtmClientImpl());
        }

        public static RtmClientImpl Get()
        {
            return clientInstance;
        }

        public int Initialize(RtmConfig config)
        {
            CreateEventHandler();
            RtmEventHandlerNative.SetEventHandler(config.getEventHandler());

            _param.Clear();
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);


            IntPtr[] arrayPtr = new IntPtr[] { _rtcEventHandlerHandle.handle };

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_INITIALIZE,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int CreateStreamChannel(string channelName)
        {
            _param.Clear();
            _param.Add("channelName", channelName);


            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_CREATESTREAMCHANNEL,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int Login(string token)
        {
            _param.Clear();
            _param.Add("token", token);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_LOGIN, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Logout()
        {
            _param.Clear();

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_LOGOUT, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        //public  IRtmStorage* GetStorage()
        //{
        //    _param.Clear();

        //    var json = Agora.Rtc.AgoraJson.ToJson(_param);

        //    var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_GETSTORAGE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
        //    return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        //}

        //public  IRtmLock* GetLock()
        //{
        //    _param.Clear();

        //    var json = Agora.Rtc.AgoraJson.ToJson(_param);

        //    var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_GETLOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
        //    return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        //}

        //public  IRtmPresence* GetPresence()
        //{
        //    _param.Clear();

        //    var json = Agora.Rtc.AgoraJson.ToJson(_param);

        //    var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_GETPRESENCE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
        //    return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        //}

        public int RenewToken(string token)
        {
            _param.Clear();
            _param.Add("token", token);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_RENEWTOKEN, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Publish(string channelName, byte[] message, int length, PublishOptions option, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("length", length);
            _param.Add("option", option);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(message, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var json = Agora.Rtc.AgoraJson.ToJson(_param);
            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_PUBLISH,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, (uint)length);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Subscribe(string channelName, SubscribeOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("options", options);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SUBSCRIBE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Unsubscribe(string channelName)
        {
            _param.Clear();
            _param.Add("channelName", channelName);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_UNSUBSCRIBE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetParameters(string parameters)
        {
            _param.Clear();
            _param.Add("parameters", parameters);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SETPARAMETERS, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetLogFile(string filePath)
        {
            _param.Clear();
            _param.Add("filePath", filePath);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SETLOGFILE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLogLevel(LOG_LEVEL level)
        {
            _param.Clear();
            _param.Add("level", level);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SETLOGLEVEL, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLogFileSize(uint fileSizeInKBytes)
        {
            _param.Clear();
            _param.Add("fileSizeInKBytes", fileSizeInKBytes);

            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SETLOGFILESIZE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}