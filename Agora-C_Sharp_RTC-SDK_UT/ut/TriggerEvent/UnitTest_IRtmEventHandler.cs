using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
using Agora.Rtc.Ut;
using Agora.Rtc;
namespace Agora.Rtm.Ut
{
    [TestFixture]
    public class UnitTest_IRtmEventHandler
    {

        public Internal.IRtmClient Client;
        public UTInternalRtmEventHandler EventHandler;
        public IntPtr FakeRtmClientPtr;
        public Agora.Rtc.Ut.IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            EventHandler = new UTInternalRtmEventHandler();
            config.setEventHandler(EventHandler);
            int errorCode = 0;
            FakeRtmClientPtr = DLLHelper.CreateFakeRtmClient();
            Client = Internal.RtmClient.CreateAgoraRtmClient(IntPtr.Zero);
            Client.Create(config);
            Assert.AreEqual(0, errorCode);
            ApiParam.AllocResult();
        }

        [TearDown]
        public void TearDown()
        {
            Client.Dispose();
            ApiParam.FreeResult();
        }

        [Test]
        public void Test_OnLinkStateEvent()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONLINKSTATEEVENT;


            LinkStateEvent @event = ParamsHelper.CreateParam<LinkStateEvent>();

            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLinkStateEventPassed(@event));
        }



        [Test]
        public void Test_OnMessageEvent()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONMESSAGEEVENT;

            Rtm.Internal.MessageEvent @event;
            ParamsHelper.InitParam(out @event);

            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = Agora.Rtc.LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMessageEventPassed(new Rtm.MessageEvent()));
        }


        [Test]
        public void Test_OnPresenceEvent()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONPRESENCEEVENT;

            Internal.PresenceEvent @event = ParamsHelper.CreateParam<Internal.PresenceEvent>();

            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPresenceEventPassed(@event));
        }


        [Test]
        public void Test_OnTopicEvent()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONTOPICEVENT;

            TopicEvent @event = ParamsHelper.CreateParam<TopicEvent>();

            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTopicEventPassed(@event));
        }


        [Test]
        public void Test_OnLockEvent()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONLOCKEVENT;

            LockEvent @event = ParamsHelper.CreateParam<LockEvent>();

            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLockEventPassed(@event));
        }


        [Test]
        public void Test_OnStorageEvent()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONSTORAGEEVENT;

            StorageEvent @event = ParamsHelper.CreateParam<StorageEvent>();

            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStorageEventPassed(@event));
        }


        [Test]
        public void Test_OnJoinResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONJOINRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            string userId = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnJoinResultPassed(requestId, channelName, userId, errorCode));
        }


        [Test]
        public void Test_OnLeaveResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONLEAVERESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            string userId = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLeaveResultPassed(requestId, channelName, userId, errorCode));
        }


        [Test]
        public void Test_OnPublishTopicMessageResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONPUBLISHTOPICMESSAGERESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            string topic = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("topic", topic);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPublishTopicMessageResultPassed(requestId, channelName, topic, errorCode));
        }



        [Test]
        public void Test_OnJoinTopicResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONJOINTOPICRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            string userId = ParamsHelper.CreateParam<string>();

            string topic = ParamsHelper.CreateParam<string>();

            string meta = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("userId", userId);
            jsonObj.Add("topic", topic);
            jsonObj.Add("meta", meta);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnJoinTopicResultPassed(requestId, channelName, userId, topic, meta, errorCode));
        }


        [Test]
        public void Test_OnLeaveTopicResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONLEAVETOPICRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            string userId = ParamsHelper.CreateParam<string>();

            string topic = ParamsHelper.CreateParam<string>();

            string meta = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("userId", userId);
            jsonObj.Add("topic", topic);
            jsonObj.Add("meta", meta);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLeaveTopicResultPassed(requestId, channelName, userId, topic, meta, errorCode));
        }


        [Test]
        public void Test_OnSubscribeTopicResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONSUBSCRIBETOPICRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            string userId = ParamsHelper.CreateParam<string>();

            string topic = ParamsHelper.CreateParam<string>();

            Internal.UserList succeedUsers = ParamsHelper.CreateParam<Internal.UserList>();

            Internal.UserList failedUsers = ParamsHelper.CreateParam<Internal.UserList>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("userId", userId);
            jsonObj.Add("topic", topic);
            jsonObj.Add("succeedUsers", succeedUsers);
            jsonObj.Add("failedUsers", failedUsers);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSubscribeTopicResultPassed(requestId, channelName, userId, topic, succeedUsers, failedUsers, errorCode));
        }

        [Test]
        public void Test_OnUnsubscribeTopicResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONUNSUBSCRIBETOPICRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            string topic = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("topic", topic);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUnsubscribeTopicResultPassed(requestId, channelName, topic, errorCode));
        }


        [Test]
        public void Test_OnGetSubscribedUserListResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETSUBSCRIBEDUSERLISTRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            string topic = ParamsHelper.CreateParam<string>();

            Internal.UserList users = ParamsHelper.CreateParam<Internal.UserList>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("topic", topic);
            jsonObj.Add("users", users);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetSubscribedUserListResultPassed(requestId, channelName, topic, users, errorCode));
        }


        [Test]
        public void Test_OnConnectionStateChange()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONCONNECTIONSTATECHANGED;

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CONNECTION_STATE state = ParamsHelper.CreateParam<RTM_CONNECTION_STATE>();

            RTM_CONNECTION_CHANGE_REASON reason = ParamsHelper.CreateParam<RTM_CONNECTION_CHANGE_REASON>();

            jsonObj.Clear();
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("state", state);
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionStateChangePassed(channelName, state, reason));
        }


        [Test]
        public void Test_OnTokenPrivilegeWillExpire()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONTOKENPRIVILEGEWILLEXPIRE;

            string channelName = ParamsHelper.CreateParam<string>();

            jsonObj.Clear();
            jsonObj.Add("channelName", channelName);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTokenPrivilegeWillExpirePassed(channelName));
        }


        [Test]
        public void Test_OnSubscribeResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONSUBSCRIBERESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSubscribeResultPassed(requestId, channelName, errorCode));
        }

        [Test]
        public void Test_OnUnsubscribeResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONUNSUBSCRIBERESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUnsubscribeResultPassed(requestId, channelName, errorCode));
        }


        [Test]
        public void Test_OnPublishResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONPUBLISHRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPublishResultPassed(requestId, errorCode));
        }


        [Test]
        public void Test_OnLoginResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONLOGINRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();
            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();

            jsonObj.Add("requestId", requestId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLoginResultPassed(requestId, errorCode));
        }

        [Test]
        public void Test_OnLogoutResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONLOGOUTRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();
            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();

            jsonObj.Add("requestId", requestId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLogoutResultPassed(requestId, errorCode));
        }


        [Test]
        public void Test_OnRenewTokenResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONRENEWTOKENRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();
            RTM_SERVICE_TYPE serverType = ParamsHelper.CreateParam<RTM_SERVICE_TYPE>();
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();

            jsonObj.Add("requestId", requestId);
            jsonObj.Add("serverType", serverType);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRenewTokenResultPassed(requestId, serverType, channelName, errorCode));
        }

        [Test]
        public void Test_OnSetChannelMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONSETCHANNELMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSetChannelMetadataResultPassed(requestId, channelName, channelType, errorCode));
        }


        [Test]
        public void Test_OnUpdateChannelMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONUPDATECHANNELMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUpdateChannelMetadataResultPassed(requestId, channelName, channelType, errorCode));
        }


        [Test]
        public void Test_OnRemoveChannelMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONREMOVECHANNELMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoveChannelMetadataResultPassed(requestId, channelName, channelType, errorCode));
        }


        [Test]
        public void Test_OnGetChannelMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETCHANNELMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            Metadata data = ParamsHelper.CreateParam<Metadata>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("data", data);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetChannelMetadataResultPassed(requestId, channelName, channelType, data, errorCode));
        }


        [Test]
        public void Test_OnSetUserMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONSETUSERMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string userId = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSetUserMetadataResultPassed(requestId, userId, errorCode));
        }


        [Test]
        public void Test_OnUpdateUserMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONUPDATEUSERMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();
            string userId = ParamsHelper.CreateParam<string>();
            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUpdateUserMetadataResultPassed(requestId, userId, errorCode));
        }


        [Test]
        public void Test_OnRemoveUserMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONREMOVEUSERMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string userId = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoveUserMetadataResultPassed(requestId, userId, errorCode));
        }


        [Test]
        public void Test_OnGetUserMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETUSERMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string userId = ParamsHelper.CreateParam<string>();

            Metadata data = ParamsHelper.CreateParam<Metadata>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("data", data);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetUserMetadataResultPassed(requestId, userId, data, errorCode));
        }


        [Test]
        public void Test_OnSubscribeUserMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONSUBSCRIBEUSERMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string userId = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSubscribeUserMetadataResultPassed(requestId, userId, errorCode));
        }

        [Test]
        public void Test_OnUnsubscribeUserMetadataResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONUNSUBSCRIBEUSERMETADATARESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string userId = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUnsubscribeUserMetadataResultPassed(requestId, userId, errorCode));
        }


        [Test]
        public void Test_OnSetLockResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONSETLOCKRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            string lockName = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSetLockResultPassed(requestId, channelName, channelType, lockName, errorCode));
        }


        [Test]
        public void Test_OnRemoveLockResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONREMOVELOCKRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            string lockName = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoveLockResultPassed(requestId, channelName, channelType, lockName, errorCode));
        }


        [Test]
        public void Test_OnReleaseLockResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONRELEASELOCKRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            string lockName = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnReleaseLockResultPassed(requestId, channelName, channelType, lockName, errorCode));
        }


        [Test]
        public void Test_OnAcquireLockResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONACQUIRELOCKRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            string lockName = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            string errorDetails = ParamsHelper.CreateParam<string>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);
            jsonObj.Add("errorDetails", errorDetails);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAcquireLockResultPassed(requestId, channelName, channelType, lockName, errorCode, errorDetails));
        }


        [Test]
        public void Test_OnRevokeLockResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONREVOKELOCKRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            string lockName = ParamsHelper.CreateParam<string>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRevokeLockResultPassed(requestId, channelName, channelType, lockName, errorCode));
        }


        [Test]
        public void Test_OnGetLocksResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETLOCKSRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            string channelName = ParamsHelper.CreateParam<string>();

            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();

            LockDetail[] lockDetailList = ParamsHelper.CreateParam<LockDetail[]>();

            ulong count = ParamsHelper.CreateParam<ulong>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockDetailList", lockDetailList);
            jsonObj.Add("count", count);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetLocksResultPassed(requestId, channelName, channelType, lockDetailList, count, errorCode));
        }


        [Test]
        public void Test_OnWhoNowResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONWHONOWRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            UserState[] userStateList = ParamsHelper.CreateParam<UserState[]>();

            ulong count = ParamsHelper.CreateParam<ulong>();

            string nextPage = ParamsHelper.CreateParam<string>();


            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();



            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userStateList", userStateList);
            jsonObj.Add("count", count);
            jsonObj.Add("nextPage", nextPage);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWhoNowResultPassed(requestId, userStateList, count, nextPage, errorCode));
        }

        [Test]
        public void Test_OnGetOnlineUsersResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETONLINEUSERSRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            UserState[] userStateList = ParamsHelper.CreateParam<UserState[]>();

            ulong count = ParamsHelper.CreateParam<ulong>();

            string nextPage = ParamsHelper.CreateParam<string>();


            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();



            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userStateList", userStateList);
            jsonObj.Add("count", count);
            jsonObj.Add("nextPage", nextPage);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetOnlineUsersResultPassed(requestId, userStateList, count, nextPage, errorCode));
        }


        [Test]
        public void Test_OnWhereNowResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONWHERENOWRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            ChannelInfo[] channels = ParamsHelper.CreateParam<ChannelInfo[]>();

            ulong count = ParamsHelper.CreateParam<ulong>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channels", channels);
            jsonObj.Add("count", count);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWhereNowResultPassed(requestId, channels, count, errorCode));
        }


        [Test]
        public void Test_OnGetUserChannelsResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETUSERCHANNELSRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            ChannelInfo[] channels = ParamsHelper.CreateParam<ChannelInfo[]>();

            ulong count = ParamsHelper.CreateParam<ulong>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channels", channels);
            jsonObj.Add("count", count);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetUserChannelsResultPassed(requestId, channels, count, errorCode));
        }


        [Test]
        public void Test_OnPresenceSetStateResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONPRESENCESETSTATERESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPresenceSetStateResultPassed(requestId, errorCode));
        }


        [Test]
        public void Test_OnPresenceRemoveStateResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONPRESENCEREMOVESTATERESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPresenceRemoveStateResultPassed(requestId, errorCode));
        }


        [Test]
        public void Test_OnPresenceGetStateResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONPRESENCEGETSTATERESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();

            UserState state = ParamsHelper.CreateParam<UserState>();

            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("state", state);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPresenceGetStateResultPassed(requestId, state, errorCode));
        }

        [Test]
        public void Test_OnGetHistoryMessagesResult()
        {
            ApiParam.@event = Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETHISTORYMESSAGESRESULT;

            ulong requestId = ParamsHelper.CreateParam<ulong>();
            Internal.HistoryMessage[] messageList = null;
            ParamsHelper.InitParam(out messageList);
            UInt64 count = ParamsHelper.CreateParam<UInt64>();
            UInt64 newStart = ParamsHelper.CreateParam<UInt64>();
            RTM_ERROR_CODE errorCode = ParamsHelper.CreateParam<RTM_ERROR_CODE>();


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("message", messageList);
            jsonObj.Add("count", count);
            jsonObj.Add("newStart", newStart);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = Agora.Rtc.LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmClient(FakeRtmClientPtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetHistoryMessagesResultPassed(requestId, null, count, newStart, errorCode));
        }
    }
}