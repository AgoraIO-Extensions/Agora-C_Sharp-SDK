﻿using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtc
{
    // get from alloc, need to free
    using IrisEventHandlerMarshal = IntPtr;
    // get from C++, no need to free
    using IrisEventHandlerHandle = IntPtr;

    using IrisApiEnginePtr = IntPtr;
    using view_t = Int64;

    internal class H265TranscoderImplS
    {
        private bool _disposed = false;

        private IrisApiEnginePtr _irisApiEngine;

        private IrisRtcCApiParam _apiParam;

        private RtcEventHandlerHandle _h265TranscoderObserverHandle = new RtcEventHandlerHandle();

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
        private static readonly string identifier = "AgoraH265Transoder";
#endif

        internal H265TranscoderImplS(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
        }

        ~H265TranscoderImplS()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                ReleaseEventHandler();
            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private int CreateEventHandler()
        {
            if (_h265TranscoderObserverHandle.handle != IntPtr.Zero)
                return 0;

            AgoraRtcNative.AllocEventHandlerHandle(ref _h265TranscoderObserverHandle, H265TranscoderObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _h265TranscoderObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgsS(_irisApiEngine, AgoraApiType.FUNC_H265TRANSCODERS_REGISTERTRANSCODEROBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_H265TRANSCODER_REGISTERTRANSCODEROBSERVER failed: " + nRet);
            }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            _callbackObject = new AgoraCallbackObject(identifier);
            H265TranscoderObserverNative.CallbackObject = _callbackObject;
#endif

            return nRet;
        }

        private int ReleaseEventHandler()
        {
            if (_h265TranscoderObserverHandle.handle == IntPtr.Zero)
                return -1;

            IntPtr[] arrayPtr = new IntPtr[] { _h265TranscoderObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgsS(_irisApiEngine, AgoraApiType.FUNC_H265TRANSCODERS_UNREGISTERTRANSCODEROBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_H265TRANSCODER_UNREGISTERTRANSCODEROBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _h265TranscoderObserverHandle);

            /// You must release callbackObject after you release eventhandler.
            /// Otherwise may be agcallback and unity main loop can will both access callback object. make crash
            H265TranscoderObserverNative.SetH265TranscoderObserver(null);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            H265TranscoderObserverNative.CallbackObject = null;
            if (_callbackObject != null)
                _callbackObject.Release();
            _callbackObject = null;
#endif
            return nRet;
        }

        public int RegisterTranscoderObserver(IH265TranscoderObserver observer)
        {
            H265TranscoderObserverNative.SetH265TranscoderObserver(observer);
            int nRet = CreateEventHandler();
            return nRet;
        }

        public int UnregisterTranscoderObserver()
        {
            int nRet = ReleaseEventHandler();
            H265TranscoderObserverNative.SetH265TranscoderObserver(null);
            return nRet;
        }

        #region terra IH265TranscoderS

        public int EnableTranscode(string token, string channel, string userAccount)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channel", channel);
            _param.Add("userAccount", userAccount);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgsS(_irisApiEngine, "H265TranscoderS_enableTranscode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int QueryChannel(string token, string channel, string userAccount)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channel", channel);
            _param.Add("userAccount", userAccount);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgsS(_irisApiEngine, "H265TranscoderS_queryChannel",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int TriggerTranscode(string token, string channel, string userAccount)
        {
            _param.Clear();
            _param.Add("token", token);
            _param.Add("channel", channel);
            _param.Add("userAccount", userAccount);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgsS(_irisApiEngine, "H265TranscoderS_triggerTranscode",
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }
        #endregion terra IH265TranscoderS

    }
}