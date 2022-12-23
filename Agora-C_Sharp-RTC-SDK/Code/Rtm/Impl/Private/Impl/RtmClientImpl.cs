using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif
using Agora.Rtc;

namespace Agora.Rtm
{
    using IrisApiRtmEnginePtr = IntPtr;

    internal class RtmClientImpl
    {
        private bool _disposed = false;
        private static RtmClientImpl clientInstance = null;
        private static readonly string identifier = "AgoraRtmClient";

        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisCApiParam _apiParam;
        private EventHandlerHandle _rtcEventHandlerHandle = new EventHandlerHandle();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
#endif

        private StreamChannelImpl _streamChannelInstance;


        public event Action<RtmClientImpl> OnRtmClientImpleWillDispose;

        private RtmClientImpl()
        {
            _apiParam = new IrisCApiParam();

            _irisApiRtmEngine = AgoraRtmNative.CreateIrisRtmEngine(IntPtr.Zero);

            _streamChannelInstance = new StreamChannelImpl(_irisApiRtmEngine);
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

                ReleaseEventHandler();
                _streamChannelInstance.Dispose();
                _streamChannelInstance = null;
            }

            Release();
            _disposed = true;
        }

        private void Release()
        {
            AgoraRtmNative.CallIrisApiWithArgs(
                _irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_RELEASE,
                "", 0,
                IntPtr.Zero, 0,
                ref _apiParam);

            AgoraRtmNative.DestroyIrisRtmEngine(_irisApiRtmEngine);

            _irisApiRtmEngine = IntPtr.Zero;
            _apiParam = new IrisCApiParam();
            clientInstance = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void CreateEventHandler()
        {
            if (_rtcEventHandlerHandle.handle != IntPtr.Zero) return;

            AgoraUtil.AllocEventHandlerHandle(ref _rtcEventHandlerHandle, RtmEventHandlerNative.OnEvent);

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

            AgoraUtil.FreeEventHandlerHandle(ref _rtcEventHandlerHandle);

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
            RtmEventHandlerNative.SetEventHandler(config.eventHandler);

            var param = new
            {
                config
            };

            var json = AgoraJson.ToJson(param);


            IntPtr[] arrayPtr = new IntPtr[] { _rtcEventHandlerHandle.handle };

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_INITIALIZE,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int CreateStreamChannel(string channelName)
        {
            var param = new
            {
                channelName
            };

            var json = AgoraJson.ToJson(param);
            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMCLIENT_CREATESTREAMCHANNEL,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        internal StreamChannelImpl GetStreamChannel()
        {
            return _streamChannelInstance;
        }
    }
}