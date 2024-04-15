#define AGORA_RTC
#define AGORA_RTM

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

#if AGORA_RTC
using Agora.Rtc;
#elif AGORA_RTM
using Agora.Rtm;
#endif

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
        private IrisRtmApiParam _apiParam;
        private RtmEventHandlerHandle _rtcEventHandlerHandle = new RtmEventHandlerHandle();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
#endif

        private StreamChannelImpl _streamChannelImpl;
        private RtmLockImpl _rtmLockImpl;
        private RtmPresenceImpl _rtmPresenceImpl;
        private RtmStorageImpl _rtmStorageImpl;

        public event Action<RtmClientImpl> OnRtmClientImpleWillDispose;

        private RtmClientImpl(IntPtr engine_ptr)
        {
            _apiParam = new IrisRtmApiParam();
            _apiParam.AllocResult();

            _irisApiRtmEngine = AgoraRtmNative.CreateIrisRtmEngine(engine_ptr);

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
            if (_disposed)
                return;

            if (disposing)
            {
                if (this.OnRtmClientImpleWillDispose != null)
                {
                    this.OnRtmClientImpleWillDispose.Invoke(this);
                }

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
            // must call free event handler after rtm release
            ReleaseEventHandler();

            AgoraRtmNative.DestroyIrisRtmEngine(_irisApiRtmEngine);
            _irisApiRtmEngine = IntPtr.Zero;
            clientInstance = null;
            _apiParam.FreeResult();
            _disposed = true;
        }

        private void Release()
        {
            AgoraRtmNative.CallIrisRtmApiWithArgs(
                _irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_RELEASE,
                "{}", 2,
                IntPtr.Zero, 0,
                ref _apiParam);
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
            if (_rtcEventHandlerHandle.handle != IntPtr.Zero)
                return;

            AgoraRtmNative.AllocEventHandlerHandle(ref _rtcEventHandlerHandle, RtmEventHandlerNative.OnEvent);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
            RtmEventHandlerNative.CallbackObject = _callbackObject;
#endif
        }

        private void ReleaseEventHandler()
        {
            if (_rtcEventHandlerHandle.handle == IntPtr.Zero)
                return;

            AgoraRtmNative.FreeEventHandlerHandle(ref _rtcEventHandlerHandle);

            RtmEventHandlerNative.SetEventHandler(null);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            RtmEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null)
                _callbackObject.Release();
            _callbackObject = null;
#endif
        }

        internal IrisApiRtmEnginePtr GetNativeHandler()
        {
            return _irisApiRtmEngine;
        }

        public static RtmClientImpl GetInstance(IntPtr engine_ptr)
        {
            return clientInstance ?? (clientInstance = new RtmClientImpl(engine_ptr));
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

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_INITIALIZE,
                                                             json, (UInt32)json.Length,
                                                             Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                             ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public string GetVersion()
        {
            IntPtr versionPtr = AgoraRtmNative.GetIrisRtmVersion();
            string version = Marshal.PtrToStringAnsi(versionPtr);
            return version;
        }

        public int CreateStreamChannel(string channelName, ref int errorCode)
        {
            _param.Clear();
            _param.Add("channelName", channelName);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_CREATESTREAMCHANNEL,
                                                             json, (UInt32)json.Length,
                                                             IntPtr.Zero, 0,
                                                             ref _apiParam);

            if (nRet == 0)
            {
                errorCode = (int)AgoraJson.GetData<UInt64>(_apiParam.Result, "errorCode");
            }
            return nRet;
        }

        public int Login(string token, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("token", token);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_LOGIN, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            if (nRet == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }
            else
            {
                requestId = 0;
            }

            return nRet;
        }

        public int Logout(ref UInt64 requestId)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_LOGOUT, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            if (nRet == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }
            else
            {
                requestId = 0;
            }

            return nRet;
        }

        public int RenewToken(string token, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("token", token);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_RENEWTOKEN, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            if (nRet == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }
            else
            {
                requestId = 0;
            }

            return nRet;
        }

        public int Publish(string channelName, byte[] message, int length, PublishOptions option, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("length", length);
            _param.Add("option", option);

            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(message, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_PUBLISH,
                                                             json, (UInt32)json.Length,
                                                             Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                             ref _apiParam, (uint)length);

            if (nRet == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }
            else
            {
                requestId = 0;
            }

            return nRet;
        }

        public int Subscribe(string channelName, SubscribeOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SUBSCRIBE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }
            else
            {
                requestId = 0;
            }

            return nRet;
        }

        public int Unsubscribe(string channelName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_UNSUBSCRIBE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            if (nRet == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }
            else
            {
                requestId = 0;
            }

            return nRet;
        }

        public int SetParameters(string parameters)
        {
            _param.Clear();
            _param.Add("parameters", parameters);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SETPARAMETERS, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLogFile(string filePath)
        {
            _param.Clear();
            _param.Add("filePath", filePath);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SETLOGFILE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLogLevel(LOG_LEVEL level)
        {
            _param.Clear();
            _param.Add("level", level);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SETLOGLEVEL, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetLogFileSize(uint fileSizeInKBytes)
        {
            _param.Clear();
            _param.Add("fileSizeInKBytes", fileSizeInKBytes);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_SETLOGFILESIZE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}