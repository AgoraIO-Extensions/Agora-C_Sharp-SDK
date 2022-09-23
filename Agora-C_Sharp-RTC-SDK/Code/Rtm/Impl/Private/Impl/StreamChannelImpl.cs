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

        public string CreateStreamChannel()
        {
            return "";
        }

        public int DestroyStreamChannel(string channelName)
        {
            return 0;
        }

        public int Join(JoinChannelOptions options)
        {
            var param = new
            {
                options
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_JOIN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Leave()
        {
            var param = new
            {
                
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_LEAVE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public string ChannelName()
        {
            var param = new
            {

            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_CHANNELNAME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? "" : (string)AgoraJson.GetData<string>(_apiParam.Result, "result");
        }

        public int CreateTopic(string topic, CreateTopicOptions options)
        {
            var param = new
            {
                topic,
                options
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_CREATETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int PublishTopic(string topic, string message, uint length)
        {
            var param = new
            {
                topic,
                message,
                length
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_PUBLISHTOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int DestroyTopic(string topic)
        {
            var param = new
            {
                topic
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_DESTROYTOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SubscribeTopic(string topic, TopicOptions options)
        {
            var param = new
            {
                topic,
                options
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_SUBSCRIBETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int UnsubscribeTopic(string topic, TopicOptions options)
        {
            var param = new
            {
                topic,
                options
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_UNSUBSCRIBETOPIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetSubscribedUserList(string topic, ref UserList[] users)
        {
            var param = new
            {
                topic,
            };

            var json = AgoraJson.ToJson(param);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiRtmEngine, AgoraApiType.FUNC_STREAMCHANNEL_GETSUBSCRIBEDUSERLIST,
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
    }
}