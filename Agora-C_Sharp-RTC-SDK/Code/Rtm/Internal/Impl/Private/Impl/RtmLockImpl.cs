#define AGORA_RTC
#define AGORA_RTM

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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

    internal class RtmLockImpl
    {
        private bool _disposed = false;
        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisRtmApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();

        internal RtmLockImpl(IrisApiRtmEnginePtr irisApiRtmEngine)
        {
            _apiParam = new IrisRtmApiParam();
            _apiParam.AllocResult();
            this._irisApiRtmEngine = irisApiRtmEngine;
        }

        ~RtmLockImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

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

        public int SetLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, int ttl, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);
            _param.Add("ttl", ttl);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_SETLOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

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

        public int GetLocks(string channelName, RTM_CHANNEL_TYPE channelType, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_GETLOCKS, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

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

        public int RemoveLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_REMOVELOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

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

        public int AcquireLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, bool retry, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);
            _param.Add("retry", retry);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_ACQUIRELOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

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

        public int ReleaseLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_RELEASELOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

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

        public int RevokeLock(string channelName, RTM_CHANNEL_TYPE channelType, string lockName, string owner, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("lockName", lockName);
            _param.Add("owner", owner);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMLOCK_REVOKELOCK, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

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
    }
}
