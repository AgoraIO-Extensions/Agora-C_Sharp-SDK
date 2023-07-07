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

    internal class StreamChannelImpl : IStreamChannelImpl
    {
        private bool _disposed = false;
        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisRtmApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();

        internal StreamChannelImpl(IrisApiRtmEnginePtr irisApiRtmEngine)
        {
            _apiParam = new IrisRtmApiParam();
            _apiParam.AllocResult();
            _irisApiRtmEngine = irisApiRtmEngine;
        }

        ~StreamChannelImpl()
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

        public int Join(string channelName, JoinChannelOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_JOIN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RenewToken(string channelName, string token)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("token", token);
          
            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_RENEWTOKEN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Leave(string channelName, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_LEAVE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int JoinTopic(string channelName, string topic, JoinTopicOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_JOINTOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam, (uint)options.meta.Length);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PublishTopicMessage(string channelName, string topic, byte[] message, int length, PublishOptions option)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);
            _param.Add("length", length);
            _param.Add("option", option);


            var json = AgoraJson.ToJson(_param);
            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(message, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_PUBLISHTOPICMESSAGE,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam, (uint)length);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int LeaveTopic(string channelName, string topic, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_LEAVETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SubscribeTopic(string channelName, string topic, TopicOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_SUBSCRIBETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);


            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                int result = (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnsubscribeTopic(string channelName, string topic, TopicOptions options)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_UNSUBSCRIBETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetSubscribedUserList(string channelName, string topic, ref UserList users)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_GETSUBSCRIBEDUSERLIST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {

                users = AgoraJson.JsonToStruct<UserList>(_apiParam.Result, "users");
            }
            else
            {
                users = new UserList();
            }
            return (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Release(string channelName)
        {
            _param.Clear();
            _param.Add("channelName", channelName);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtmNative.CallIrisRtmApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_RELEASE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}