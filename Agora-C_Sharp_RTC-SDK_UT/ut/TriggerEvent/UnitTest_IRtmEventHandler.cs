using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
using Agora.Rtc;

namespace Agora.Rtm.Event
{
    [TestFixture]
    public class UnitTest_IRtmEventHandler
    {

        public Internal.IRtmClient Client;
        public UTInternalRtmEventHandler EventHandler;
        public IntPtr FakeRtmEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            Client = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmEngine());
            Internal.RtmConfig config = new Internal.RtmConfig();
            EventHandler = new UTInternalRtmEventHandler();
            config.setEventHandler(EventHandler);
            int nRet = Client.Initialize(config);
            Assert.AreEqual(0, nRet);
            ApiParam.AllocResult();
        }

        [TearDown]
        public void TearDown()
        {
            Client.Dispose();
            ApiParam.FreeResult();
        }


        [Test]
        public void Test_OnMessageEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONMESSAGEEVENT;

            MessageEvent @event;
            ParamsHelper.InitParam(out @event);


            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMessageEventPassed(@event));
        }


        [Test]
        public void Test_OnPresenceEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONPRESENCEEVENT;

            PresenceEvent @event;
            ParamsHelper.InitParam(out @event);


            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPresenceEventPassed(@event));
        }


        [Test]
        public void Test_OnTopicEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONTOPICEVENT;

            TopicEvent @event;
            ParamsHelper.InitParam(out @event);


            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTopicEventPassed(@event));
        }


        [Test]
        public void Test_OnLockEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONLOCKEVENT;

            LockEvent @event;
            ParamsHelper.InitParam(out @event);


            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLockEventPassed(@event));
        }


        [Test]
        public void Test_OnStorageEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONSTORAGEEVENT;

            StorageEvent @event;
            ParamsHelper.InitParam(out @event);


            jsonObj.Clear();
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStorageEventPassed(@event));
        }


        [Test]
        public void Test_OnJoinResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONJOINRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            string userId;
            ParamsHelper.InitParam(out userId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnJoinResultPassed(requestId, channelName, userId, errorCode));
        }


        [Test]
        public void Test_OnLeaveResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONLEAVERESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            string userId;
            ParamsHelper.InitParam(out userId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLeaveResultPassed(requestId, channelName, userId, errorCode));
        }


        [Test]
        public void Test_OnJoinTopicResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONJOINTOPICRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            string userId;
            ParamsHelper.InitParam(out userId);

            string topic;
            ParamsHelper.InitParam(out topic);

            string meta;
            ParamsHelper.InitParam(out meta);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


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

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnJoinTopicResultPassed(requestId, channelName, userId, topic, meta, errorCode));
        }


        [Test]
        public void Test_OnLeaveTopicResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONLEAVETOPICRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            string userId;
            ParamsHelper.InitParam(out userId);

            string topic;
            ParamsHelper.InitParam(out topic);

            string meta;
            ParamsHelper.InitParam(out meta);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


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

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLeaveTopicResultPassed(requestId, channelName, userId, topic, meta, errorCode));
        }


        [Test]
        public void Test_OnSubscribeTopicResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONSUBSCRIBETOPICRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            string userId;
            ParamsHelper.InitParam(out userId);

            string topic;
            ParamsHelper.InitParam(out topic);

            UserList succeedUsers;
            ParamsHelper.InitParam(out succeedUsers);

            UserList failedUsers;
            ParamsHelper.InitParam(out failedUsers);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


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

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSubscribeTopicResultPassed(requestId, channelName, userId, topic, succeedUsers, failedUsers, errorCode));
        }


        [Test]
        public void Test_OnConnectionStateChange()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONCONNECTIONSTATECHANGE;

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CONNECTION_STATE state;
            ParamsHelper.InitParam(out state);

            RTM_CONNECTION_CHANGE_REASON reason;
            ParamsHelper.InitParam(out reason);


            jsonObj.Clear();
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("state", state);
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionStateChangePassed(channelName, state, reason));
        }


        [Test]
        public void Test_OnTokenPrivilegeWillExpire()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONTOKENPRIVILEGEWILLEXPIRE;

            string channelName;
            ParamsHelper.InitParam(out channelName);


            jsonObj.Clear();
            jsonObj.Add("channelName", channelName);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTokenPrivilegeWillExpirePassed(channelName));
        }


        [Test]
        public void Test_OnSubscribeResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONSUBSCRIBERESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSubscribeResultPassed(requestId, channelName, errorCode));
        }


        [Test]
        public void Test_OnPublishResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONPUBLISHRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPublishResultPassed(requestId, errorCode));
        }


        [Test]
        public void Test_OnLoginResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONLOGINRESULT;

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLoginResultPassed(errorCode));
        }


        [Test]
        public void Test_OnSetChannelMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONSETCHANNELMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSetChannelMetadataResultPassed(requestId, channelName, channelType, errorCode));
        }


        [Test]
        public void Test_OnUpdateChannelMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONUPDATECHANNELMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUpdateChannelMetadataResultPassed(requestId, channelName, channelType, errorCode));
        }


        [Test]
        public void Test_OnRemoveChannelMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONREMOVECHANNELMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoveChannelMetadataResultPassed(requestId, channelName, channelType, errorCode));
        }


        [Test]
        public void Test_OnGetChannelMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONGETCHANNELMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            RtmMetadata data;
            ParamsHelper.InitParam(out data);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("data", data);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetChannelMetadataResultPassed(requestId, channelName, channelType, data, errorCode));
        }


        [Test]
        public void Test_OnSetUserMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONSETUSERMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string userId;
            ParamsHelper.InitParam(out userId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSetUserMetadataResultPassed(requestId, userId, errorCode));
        }


        [Test]
        public void Test_OnUpdateUserMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONUPDATEUSERMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string userId;
            ParamsHelper.InitParam(out userId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUpdateUserMetadataResultPassed(requestId, userId, errorCode));
        }


        [Test]
        public void Test_OnRemoveUserMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONREMOVEUSERMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string userId;
            ParamsHelper.InitParam(out userId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoveUserMetadataResultPassed(requestId, userId, errorCode));
        }


        [Test]
        public void Test_OnGetUserMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONGETUSERMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string userId;
            ParamsHelper.InitParam(out userId);

            RtmMetadata data;
            ParamsHelper.InitParam(out data);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("data", data);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetUserMetadataResultPassed(requestId, userId, data, errorCode));
        }


        [Test]
        public void Test_OnSubscribeUserMetadataResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONSUBSCRIBEUSERMETADATARESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string userId;
            ParamsHelper.InitParam(out userId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userId", userId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSubscribeUserMetadataResultPassed(requestId, userId, errorCode));
        }


        [Test]
        public void Test_OnSetLockResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONSETLOCKRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            string lockName;
            ParamsHelper.InitParam(out lockName);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSetLockResultPassed(requestId, channelName, channelType, lockName, errorCode));
        }


        [Test]
        public void Test_OnRemoveLockResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONREMOVELOCKRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            string lockName;
            ParamsHelper.InitParam(out lockName);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoveLockResultPassed(requestId, channelName, channelType, lockName, errorCode));
        }


        [Test]
        public void Test_OnReleaseLockResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONRELEASELOCKRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            string lockName;
            ParamsHelper.InitParam(out lockName);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnReleaseLockResultPassed(requestId, channelName, channelType, lockName, errorCode));
        }


        [Test]
        public void Test_OnAcquireLockResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONACQUIRELOCKRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            string lockName;
            ParamsHelper.InitParam(out lockName);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);

            string errorDetails;
            ParamsHelper.InitParam(out errorDetails);


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

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAcquireLockResultPassed(requestId, channelName, channelType, lockName, errorCode, errorDetails));
        }


        [Test]
        public void Test_OnRevokeLockResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONREVOKELOCKRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            string lockName;
            ParamsHelper.InitParam(out lockName);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channelName", channelName);
            jsonObj.Add("channelType", channelType);
            jsonObj.Add("lockName", lockName);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRevokeLockResultPassed(requestId, channelName, channelType, lockName, errorCode));
        }


        [Test]
        public void Test_OnGetLocksResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONGETLOCKSRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            string channelName;
            ParamsHelper.InitParam(out channelName);

            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);

            LockDetail[] lockDetailList;
            ParamsHelper.InitParam(out lockDetailList);

            ulong count;
            ParamsHelper.InitParam(out count);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


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

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnGetLocksResultPassed(requestId, channelName, channelType, lockDetailList, count, errorCode));
        }


        [Test]
        public void Test_OnWhoNowResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONWHONOWRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            UserState[] userStateList;
            ParamsHelper.InitParam(out userStateList);

            ulong count;
            ParamsHelper.InitParam(out count);

            string nextPage;
            ParamsHelper.InitParam(out nextPage);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("userStateList", userStateList);
            jsonObj.Add("count", count);
            jsonObj.Add("nextPage", nextPage);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWhoNowResultPassed(requestId, userStateList, count, nextPage, errorCode));
        }


        [Test]
        public void Test_OnWhereNowResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONWHERENOWRESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            ChannelInfo[] channels;
            ParamsHelper.InitParam(out channels);

            ulong count;
            ParamsHelper.InitParam(out count);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("channels", channels);
            jsonObj.Add("count", count);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWhereNowResultPassed(requestId, channels, count, errorCode));
        }


        [Test]
        public void Test_OnPresenceSetStateResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONPRESENCESETSTATERESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPresenceSetStateResultPassed(requestId, errorCode));
        }


        [Test]
        public void Test_OnPresenceRemoveStateResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONPRESENCEREMOVESTATERESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPresenceRemoveStateResultPassed(requestId, errorCode));
        }


        [Test]
        public void Test_OnPresenceGetStateResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTMEVENTHANDLER_ONPRESENCEGETSTATERESULT;

            ulong requestId;
            ParamsHelper.InitParam(out requestId);

            UserState state;
            ParamsHelper.InitParam(out state);

            RTM_ERROR_CODE errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("state", state);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtmEngine(FakeRtmEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPresenceGetStateResultPassed(requestId, state, errorCode));
        }
    }
}