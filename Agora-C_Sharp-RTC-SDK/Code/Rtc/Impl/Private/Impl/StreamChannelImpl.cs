#define AGORA_RTC
#define AGORA_RTM
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif
using Agora.Rtc;


#if AGORA_RTM

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    internal class StreamChannelImpl : Rtm.IStreamChannelImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;

        private Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();

        internal StreamChannelImpl(IrisApiEnginePtr irisApiRtmEngine)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiRtmEngine;
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
            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Join(string channelName, Rtm.JoinChannelOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_JOIN,
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

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_RENEWTOKEN,
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
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_LEAVE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int JoinTopic(string channelName, string topic, Rtm.JoinTopicOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);
            _param.Add("options", options);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_JOINTOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PublishTopicMessage(string channelName, string topic, byte[] message, int length, Rtm.Internal.PublishOptions option)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);
            _param.Add("length", length);
            _param.Add("option", option);


            var json = AgoraJson.ToJson(_param);
            IntPtr bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(message, 0);
            IntPtr[] arrayPtr = new IntPtr[] { bufferPtr };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_PUBLISHTOPICMESSAGE,
                json, (UInt32)json.Length,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int LeaveTopic(string channelName, string topic, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_LEAVETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SubscribeTopic(string channelName, string topic, Rtm.TopicOptions options, ref UInt64 requestId)
        {
            _param.Clear();
            _param.Add("channelName", channelName);
            _param.Add("topic", topic);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_SUBSCRIBETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);


            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                requestId = (UInt64)AgoraJson.GetData<UInt64>(_apiParam.Result, "requestId");
            }

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnsubscribeTopic(string channelName, string topic, Rtm.TopicOptions options)
        {
            _param.Clear();
            _param.Add("channelName", channelName);

            _param.Add("topic", topic);
            _param.Add("options", options);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_UNSUBSCRIBETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetSubscribedUserList(string channelName, string topic, ref Rtm.UserList users)
        {
            _param.Clear();
            _param.Add("channelName", channelName);

            _param.Add("topic", topic);


            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_GETSUBSCRIBEDUSERLIST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {

                users = AgoraJson.JsonToStruct<Rtm.UserList>(_apiParam.Result, "users");
            }
            else
            {
                users = new Rtm.UserList();
            }
            return (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Release(string channelName)
        {
            _param.Clear();
            _param.Add("channelName", channelName);

            var json = AgoraJson.ToJson(_param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, Rtm.Internal.AgoraApiType.FUNC_STREAMCHANNEL_RELEASE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}

#endif