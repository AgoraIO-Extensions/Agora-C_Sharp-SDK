using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtm
{
    using IrisApiRtmEnginePtr = IntPtr;
    internal class RtmPresenceImpl
    {
        private bool _disposed = false;
        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();

        internal RtmPresenceImpl(IrisApiRtmEnginePtr irisApiRtmEngine)
        {
            _apiParam = new IrisApiParam();
            _apiParam.AllocResult();
            this._irisApiRtmEngine = irisApiRtmEngine;
        }

        ~RtmPresenceImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
            }

            _irisApiRtmEngine = IntPtr.Zero;
            _apiParam.FreeResult();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public int WhoNow(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("options", options);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMPRESENCE_WHONOW, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int WhereNow(string userId, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("userId", userId);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMPRESENCE_WHERENOW, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetState(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items, int count, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("items", items);
            _param.Add("count", count);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMPRESENCE_SETSTATE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RemoveState(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys, int count, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("keys", keys);
            _param.Add("count", count);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMPRESENCE_REMOVESTATE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetState(string channelName, RTM_CHANNEL_TYPE channelType, string userId, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("userId", userId);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);
            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMPRESENCE_GETSTATE, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}
