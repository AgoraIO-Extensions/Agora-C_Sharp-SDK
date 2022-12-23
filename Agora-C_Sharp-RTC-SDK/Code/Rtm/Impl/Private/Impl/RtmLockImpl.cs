using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif


namespace Agora.Rtm
{
    using IrisApiRtmEnginePtr = IntPtr;

    internal class RtmLockImpl
    {
        private bool _disposed = false;
        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();


        internal RtmLockImpl(IrisApiRtmEnginePtr irisApiRtmEngine)
        {
            _apiParam = new IrisCApiParam();
            this._irisApiRtmEngine = irisApiRtmEngine;
        }

        ~RtmLockImpl()
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
            _apiParam = new IrisCApiParam();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public int SetLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);
            _param.Add("ttl", ttl);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_SETLOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetLocks(string channelName, RTM_CHANNEL_TYPE channelType, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_GETLOCKS, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RemoveLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_REMOVELOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int AcquireLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);
            _param.Add("retry", retry);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_ACQUIRELOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int ReleaseLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_RELEASELOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RevokeLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);
            _param.Add("owner", owner);


            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_REVOKELOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

            if (nRet == 0 && (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)Agora.Rtc.AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

    }
}
