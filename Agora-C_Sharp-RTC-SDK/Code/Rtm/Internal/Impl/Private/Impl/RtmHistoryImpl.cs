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

    internal class RtmHistoryImpl
    {
        private bool _disposed = false;
        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisRtmApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();

        internal RtmHistoryImpl(IrisApiRtmEnginePtr irisApiRtmEngine)
        {
            _apiParam = new IrisRtmApiParam();
            _apiParam.AllocResult();
            this._irisApiRtmEngine = irisApiRtmEngine;
        }

        ~RtmHistoryImpl()
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

        public int GetMessages(string channelName, RTM_CHANNEL_TYPE channelType, GetHistoryMessagesOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("channelType", channelType);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_RTMHISTORY_GETMESSAGES, json, (UInt32)json.Length, IntPtr.Zero, 0, ref _apiParam);

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
