using System;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
using Agora.Rtc;
#endif

namespace Agora.Rtm
{
    using IrisApiRtmEnginePtr = IntPtr;

    internal class StreamChannelImpl
    {
        private bool _disposed = false;
        private IrisApiRtmEnginePtr _irisApiRtmEngine;
        private IrisCApiParam _apiParam;

        internal StreamChannelImpl(IrisApiRtmEnginePtr irisApiRtmEngine)
        {
            _apiParam = new IrisCApiParam();
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
            _apiParam = new IrisCApiParam();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Join(string channelName, JoinChannelOptions options)
        {
            var param = new
            {
                channelName,
                options
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_JOIN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Leave(string channelName)
        {
            var param = new
            {
                channelName
            };

            var json = AgoraJson.ToJson(param);
            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_LEAVE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public string GetChannelName(string channelName)
        {
            var param = new
            {
                channelName
            };

            var json = AgoraJson.ToJson(param);
            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_GETCHANNELNAME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? "" : (string)AgoraJson.GetData<string>(_apiParam.Result, "result");
        }

        public int JoinTopic(string channelName, string topic, JoinTopicOptions options)
        {
            var param = new
            {
                channelName,
                topic,
                options
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_JOINTOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PublishTopicMessage(string channelName, string topic, string message, uint length)
        {
            var param = new
            {
                channelName,
                topic,
                message,
                length
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_PUBLISHTOPICMESSAGE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int LeaveTopic(string channelName, string topic)
        {
            var param = new
            {
                channelName,
                topic
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_LEAVETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SubscribeTopic(string channelName, string topic, TopicOptions options)
        {
            var param = new
            {
                channelName,
                topic,
                options
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_SUBSCRIBETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnsubscribeTopic(string channelName, string topic, TopicOptions options)
        {
            var param = new
            {
                channelName,
                topic,
                options
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_UNSUBSCRIBETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetSubscribedUserList(string channelName, string topic, ref UserList[] users)
        {
            var param = new
            {
                channelName,
                topic
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_GETSUBSCRIBEDUSERLIST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (nRet == 0 && (int)AgoraJson.GetData<int>(_apiParam.Result, "result") == 0)
            {
                users = AgoraJson.JsonToStructArray<UserList>(_apiParam.Result, "users");
            }
            else
            {
                users = new UserList[0];
            }
            return (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Release(string channelName)
        {
            var param = new
            {
                channelName
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtmNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_RELEASE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}