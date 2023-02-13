using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IRtcEventHandler
    {

        public IRtcEngineEx Engine;
        public UTRtcEngineEventHandler EventHandler;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngine();
            Engine = RtcEngine.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            ApiParam.AllocResult();

            EventHandler = new UTRtcEngineEventHandler();
            Engine.InitEventHandler(EventHandler);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
            ApiParam.FreeResult();
        }


        #region IRtcEngineEventHandlerEx

        [Test]
        public void Test_OnJoinChannelSuccess()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONJOINCHANNELSUCCESS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("elapsed", elapsed);


            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnJoinChannelSuccessPassed(connection, elapsed));
        }

        [Test]
        public void Test_OnRejoinChannelSuccess()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREJOINCHANNELSUCCESS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRejoinChannelSuccessPassed(connection, elapsed));
        }

        [Test]
        public void Test_OnAudioQuality()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOQUALITY;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            int quality;
            ParamsHelper.InitParam(out quality);

            UInt16 delay;
            ParamsHelper.InitParam(out delay);

            UInt16 lost;
            ParamsHelper.InitParam(out lost);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("quality", quality);
            jsonObj.Add("delay", delay);
            jsonObj.Add("lost", lost);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioQualityPassed(connection, remoteUid, quality, delay, lost));
        }

        [Test]
        public void Test_OnAudioVolumeIndication()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOVOLUMEINDICATION;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            AudioVolumeInfo[] speakers;
            ParamsHelper.InitParam(out speakers);

            uint speakerNumber;
            ParamsHelper.InitParam(out speakerNumber);

            int totalVolume;
            ParamsHelper.InitParam(out totalVolume);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("speakers", speakers);
            jsonObj.Add("speakerNumber", speakerNumber);
            jsonObj.Add("totalVolume", totalVolume);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioVolumeIndicationPassed(connection, speakers, speakerNumber, totalVolume));
        }

        [Test]
        public void Test_OnLeaveChannel()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLEAVECHANNEL;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            RtcStats stats;
            ParamsHelper.InitParam(out stats);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLeaveChannelPassed(connection, stats));
        }

        [Test]
        public void Test_OnRtcStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONRTCSTATS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            RtcStats stats;
            ParamsHelper.InitParam(out stats);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtcStatsPassed(connection, stats));
        }

        [Test]
        public void Test_OnNetworkQuality()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKQUALITY;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            int txQuality;
            ParamsHelper.InitParam(out txQuality);

            int rxQuality;
            ParamsHelper.InitParam(out rxQuality);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("txQuality", txQuality);
            jsonObj.Add("rxQuality", rxQuality);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnNetworkQualityPassed(connection, remoteUid, txQuality, rxQuality));
        }

        [Test]
        public void Test_OnIntraRequestReceived()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONINTRAREQUESTRECEIVED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnIntraRequestReceivedPassed(connection));
        }

        [Test]
        public void Test_OnFirstLocalVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALVIDEOFRAME;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            int width;
            ParamsHelper.InitParam(out width);

            int height;
            ParamsHelper.InitParam(out height);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("width", width);
            jsonObj.Add("height", height);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalVideoFramePassed(connection, width, height, elapsed));
        }

        [Test]
        public void Test_OnFirstLocalVideoFramePublished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALVIDEOFRAMEPUBLISHED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalVideoFramePublishedPassed(connection, elapsed));
        }

        [Test]
        public void Test_OnFirstRemoteVideoDecoded()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEODECODED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            int width;
            ParamsHelper.InitParam(out width);

            int height;
            ParamsHelper.InitParam(out height);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("width", width);
            jsonObj.Add("height", height);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteVideoDecodedPassed(connection, remoteUid, width, height, elapsed));
        }

        [Test]
        public void Test_OnVideoSizeChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEOSIZECHANGED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            VIDEO_SOURCE_TYPE sourceType;
            ParamsHelper.InitParam(out sourceType);

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            int width;
            ParamsHelper.InitParam(out width);

            int height;
            ParamsHelper.InitParam(out height);

            int rotation;
            ParamsHelper.InitParam(out rotation);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("sourceType", sourceType);
            jsonObj.Add("uid", uid);
            jsonObj.Add("width", width);
            jsonObj.Add("height", height);
            jsonObj.Add("rotation", rotation);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoSizeChangedPassed(connection, sourceType, uid, width, height, rotation));
        }

        [Test]
        public void Test_OnLocalVideoStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATECHANGED;

            VIDEO_SOURCE_TYPE source;
            ParamsHelper.InitParam(out source);

            LOCAL_VIDEO_STREAM_STATE state;
            ParamsHelper.InitParam(out state);

            LOCAL_VIDEO_STREAM_ERROR errorCode;
            ParamsHelper.InitParam(out errorCode);

            jsonObj.Clear();
            jsonObj.Add("source", source);
            jsonObj.Add("state", state);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoStateChangedPassed(source, state, errorCode));
        }

        [Test]
        public void Test_OnRemoteVideoStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATECHANGED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            REMOTE_VIDEO_STATE state;
            ParamsHelper.InitParam(out state);

            REMOTE_VIDEO_STATE_REASON reason;
            ParamsHelper.InitParam(out reason);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("state", state);
            jsonObj.Add("reason", reason);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteVideoStateChangedPassed(connection, remoteUid, state, reason, elapsed));
        }

        [Test]
        public void Test_OnFirstRemoteVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEOFRAME;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            int width;
            ParamsHelper.InitParam(out width);

            int height;
            ParamsHelper.InitParam(out height);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("width", width);
            jsonObj.Add("height", height);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteVideoFramePassed(connection, remoteUid, width, height, elapsed));
        }

        [Test]
        public void Test_OnUserJoined()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERJOINED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserJoinedPassed(connection, remoteUid, elapsed));
        }

        [Test]
        public void Test_OnUserOffline()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSEROFFLINE;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            USER_OFFLINE_REASON_TYPE reason;
            ParamsHelper.InitParam(out reason);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserOfflinePassed(connection, remoteUid, reason));
        }

        [Test]
        public void Test_OnUserMuteAudio()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEAUDIO;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            bool muted;
            ParamsHelper.InitParam(out muted);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("muted", muted);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserMuteAudioPassed(connection, remoteUid, muted));
        }

        [Test]
        public void Test_OnUserMuteVideo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEVIDEO;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            bool muted;
            ParamsHelper.InitParam(out muted);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("muted", muted);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserMuteVideoPassed(connection, remoteUid, muted));
        }

        [Test]
        public void Test_OnUserEnableVideo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLEVIDEO;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            bool enabled;
            ParamsHelper.InitParam(out enabled);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("enabled", enabled);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserEnableVideoPassed(connection, remoteUid, enabled));
        }

        [Test]
        public void Test_OnUserEnableLocalVideo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLELOCALVIDEO;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            bool enabled;
            ParamsHelper.InitParam(out enabled);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("enabled", enabled);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserEnableLocalVideoPassed(connection, remoteUid, enabled));
        }

        [Test]
        public void Test_OnUserStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERSTATECHANGED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            uint state;
            ParamsHelper.InitParam(out state);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("state", state);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserStateChangedPassed(connection, remoteUid, state));
        }

        [Test]
        public void Test_OnLocalAudioStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            LocalAudioStats stats;
            ParamsHelper.InitParam(out stats);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalAudioStatsPassed(connection, stats));
        }

        [Test]
        public void Test_OnRemoteAudioStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            RemoteAudioStats stats;
            ParamsHelper.InitParam(out stats);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioStatsPassed(connection, stats));
        }

        [Test]
        public void Test_OnLocalVideoStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            LocalVideoStats stats;
            ParamsHelper.InitParam(out stats);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoStatsPassed(connection, stats));
        }

        [Test]
        public void Test_OnRemoteVideoStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            RemoteVideoStats stats;
            ParamsHelper.InitParam(out stats);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteVideoStatsPassed(connection, stats));
        }

        [Test]
        public void Test_OnConnectionLost()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONLOST;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionLostPassed(connection));
        }

        [Test]
        public void Test_OnConnectionInterrupted()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONINTERRUPTED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionInterruptedPassed(connection));
        }

        [Test]
        public void Test_OnConnectionBanned()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONBANNED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionBannedPassed(connection));
        }

        [Test]
        public void Test_OnStreamMessage()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGE;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            int streamId;
            ParamsHelper.InitParam(out streamId);

            byte[] data;
            ParamsHelper.InitParam(out data);

            uint length;
            ParamsHelper.InitParam(out length);

            ulong sentTs;
            ParamsHelper.InitParam(out sentTs);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("streamId", streamId);
            jsonObj.Add("data", data);
            jsonObj.Add("length", length);
            jsonObj.Add("sentTs", sentTs);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStreamMessagePassed(connection, remoteUid, streamId, data, length, sentTs));
        }

        [Test]
        public void Test_OnStreamMessageError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGEERROR;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            int streamId;
            ParamsHelper.InitParam(out streamId);

            int code;
            ParamsHelper.InitParam(out code);

            int missed;
            ParamsHelper.InitParam(out missed);

            int cached;
            ParamsHelper.InitParam(out cached);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("streamId", streamId);
            jsonObj.Add("code", code);
            jsonObj.Add("missed", missed);
            jsonObj.Add("cached", cached);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStreamMessageErrorPassed(connection, remoteUid, streamId, code, missed, cached));
        }

        [Test]
        public void Test_OnRequestToken()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREQUESTTOKEN;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRequestTokenPassed(connection));
        }

        [Test]
        public void Test_OnLicenseValidationFailure()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLICENSEVALIDATIONFAILURE;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            LICENSE_ERROR_TYPE reason;
            ParamsHelper.InitParam(out reason);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLicenseValidationFailurePassed(connection, reason));
        }

        [Test]
        public void Test_OnTokenPrivilegeWillExpire()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONTOKENPRIVILEGEWILLEXPIRE;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            string token;
            ParamsHelper.InitParam(out token);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("token", token);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTokenPrivilegeWillExpirePassed(connection, token));
        }

        [Test]
        public void Test_OnFirstLocalAudioFramePublished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALAUDIOFRAMEPUBLISHED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalAudioFramePublishedPassed(connection, elapsed));
        }

        [Test]
        public void Test_OnFirstRemoteAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIOFRAME;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t userId;
            ParamsHelper.InitParam(out userId);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("userId", userId);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteAudioFramePassed(connection, userId, elapsed));
        }

        [Test]
        public void Test_OnFirstRemoteAudioDecoded()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIODECODED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("uid", uid);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteAudioDecodedPassed(connection, uid, elapsed));
        }

        [Test]
        public void Test_OnLocalAudioStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATECHANGED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            LOCAL_AUDIO_STREAM_STATE state;
            ParamsHelper.InitParam(out state);

            LOCAL_AUDIO_STREAM_ERROR error;
            ParamsHelper.InitParam(out error);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("state", state);
            jsonObj.Add("error", error);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalAudioStateChangedPassed(connection, state, error));
        }

        [Test]
        public void Test_OnRemoteAudioStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATECHANGED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            REMOTE_AUDIO_STATE state;
            ParamsHelper.InitParam(out state);

            REMOTE_AUDIO_STATE_REASON reason;
            ParamsHelper.InitParam(out reason);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("state", state);
            jsonObj.Add("reason", reason);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioStateChangedPassed(connection, remoteUid, state, reason, elapsed));
        }

        [Test]
        public void Test_OnActiveSpeaker()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONACTIVESPEAKER;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("uid", uid);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnActiveSpeakerPassed(connection, uid));
        }

        [Test]
        public void Test_OnClientRoleChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            CLIENT_ROLE_TYPE oldRole;
            ParamsHelper.InitParam(out oldRole);

            CLIENT_ROLE_TYPE newRole;
            ParamsHelper.InitParam(out newRole);

            ClientRoleOptions newRoleOptions;
            ParamsHelper.InitParam(out newRoleOptions);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("oldRole", oldRole);
            jsonObj.Add("newRole", newRole);
            jsonObj.Add("newRoleOptions", newRoleOptions);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnClientRoleChangedPassed(connection, oldRole, newRole, newRoleOptions));
        }

        [Test]
        public void Test_OnClientRoleChangeFailed()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGEFAILED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            CLIENT_ROLE_CHANGE_FAILED_REASON reason;
            ParamsHelper.InitParam(out reason);

            CLIENT_ROLE_TYPE currentRole;
            ParamsHelper.InitParam(out currentRole);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("reason", reason);
            jsonObj.Add("currentRole", currentRole);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnClientRoleChangeFailedPassed(connection, reason, currentRole));
        }

        [Test]
        public void Test_OnRemoteAudioTransportStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOTRANSPORTSTATS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            UInt16 delay;
            ParamsHelper.InitParam(out delay);

            UInt16 lost;
            ParamsHelper.InitParam(out lost);

            UInt16 rxKBitRate;
            ParamsHelper.InitParam(out rxKBitRate);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("delay", delay);
            jsonObj.Add("lost", lost);
            jsonObj.Add("rxKBitRate", rxKBitRate);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioTransportStatsPassed(connection, remoteUid, delay, lost, rxKBitRate));
        }

        [Test]
        public void Test_OnRemoteVideoTransportStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOTRANSPORTSTATS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            UInt16 delay;
            ParamsHelper.InitParam(out delay);

            UInt16 lost;
            ParamsHelper.InitParam(out lost);

            UInt16 rxKBitRate;
            ParamsHelper.InitParam(out rxKBitRate);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("delay", delay);
            jsonObj.Add("lost", lost);
            jsonObj.Add("rxKBitRate", rxKBitRate);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteVideoTransportStatsPassed(connection, remoteUid, delay, lost, rxKBitRate));
        }

        [Test]
        public void Test_OnConnectionStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONSTATECHANGED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            CONNECTION_STATE_TYPE state;
            ParamsHelper.InitParam(out state);

            CONNECTION_CHANGED_REASON_TYPE reason;
            ParamsHelper.InitParam(out reason);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("state", state);
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionStateChangedPassed(connection, state, reason));
        }

        [Test]
        public void Test_OnWlAccMessage()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCMESSAGE;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            WLACC_MESSAGE_REASON reason;
            ParamsHelper.InitParam(out reason);

            WLACC_SUGGEST_ACTION action;
            ParamsHelper.InitParam(out action);

            string wlAccMsg;
            ParamsHelper.InitParam(out wlAccMsg);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("reason", reason);
            jsonObj.Add("action", action);
            jsonObj.Add("wlAccMsg", wlAccMsg);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWlAccMessagePassed(connection, reason, action, wlAccMsg));
        }

        [Test]
        public void Test_OnWlAccStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCSTATS;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            WlAccStats currentStats;
            ParamsHelper.InitParam(out currentStats);

            WlAccStats averageStats;
            ParamsHelper.InitParam(out averageStats);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("currentStats", currentStats);
            jsonObj.Add("averageStats", averageStats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWlAccStatsPassed(connection, currentStats, averageStats));
        }

        [Test]
        public void Test_OnNetworkTypeChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKTYPECHANGED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            NETWORK_TYPE type;
            ParamsHelper.InitParam(out type);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("type", type);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnNetworkTypeChangedPassed(connection, type));
        }

        [Test]
        public void Test_OnEncryptionError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONENCRYPTIONERROR;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            ENCRYPTION_ERROR_TYPE errorType;
            ParamsHelper.InitParam(out errorType);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("errorType", errorType);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnEncryptionErrorPassed(connection, errorType));
        }

        [Test]
        public void Test_OnUploadLogResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUPLOADLOGRESULT;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            string requestId;
            ParamsHelper.InitParam(out requestId);

            bool success;
            ParamsHelper.InitParam(out success);

            UPLOAD_ERROR_REASON reason;
            ParamsHelper.InitParam(out reason);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("success", success);
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUploadLogResultPassed(connection, requestId, success, reason));
        }

        [Test]
        public void Test_OnUserAccountUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERACCOUNTUPDATED;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t remoteUid;
            ParamsHelper.InitParam(out remoteUid);

            string userAccount;
            ParamsHelper.InitParam(out userAccount);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("remoteUid", remoteUid);
            jsonObj.Add("userAccount", userAccount);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserAccountUpdatedPassed(connection, remoteUid, userAccount));
        }

        [Test]
        public void Test_OnSnapshotTaken()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSNAPSHOTTAKEN;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            string filePath;
            ParamsHelper.InitParam(out filePath);

            int width;
            ParamsHelper.InitParam(out width);

            int height;
            ParamsHelper.InitParam(out height);

            int errCode;
            ParamsHelper.InitParam(out errCode);

            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("uid", uid);
            jsonObj.Add("filePath", filePath);
            jsonObj.Add("width", width);
            jsonObj.Add("height", height);
            jsonObj.Add("errCode", errCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSnapshotTakenPassed(connection, uid, filePath, width, height, errCode));
        }

        #endregion

        #region IRtcEngineEventHandler

        [Test]
        public void Test_OnProxyConnected()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONPROXYCONNECTED;

            string channel;
            ParamsHelper.InitParam(out channel);

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            PROXY_TYPE proxyType;
            ParamsHelper.InitParam(out proxyType);

            string localProxyIp;
            ParamsHelper.InitParam(out localProxyIp);

            int elapsed;
            ParamsHelper.InitParam(out elapsed);

            jsonObj.Clear();
            jsonObj.Add("channel", channel);
            jsonObj.Add("uid", uid);
            jsonObj.Add("proxyType", proxyType);
            jsonObj.Add("localProxyIp", localProxyIp);
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnProxyConnectedPassed(channel, uid, proxyType, localProxyIp, elapsed));
        }

        [Test]
        public void Test_OnError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONERROR;

            int err;
            ParamsHelper.InitParam(out err);

            string msg;
            ParamsHelper.InitParam(out msg);

            jsonObj.Clear();
            jsonObj.Add("err", err);
            jsonObj.Add("msg", msg);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnErrorPassed(err, msg));
        }

        [Test]
        public void Test_OnLastmileProbeResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEPROBERESULT;

            LastmileProbeResult result;
            ParamsHelper.InitParam(out result);

            jsonObj.Clear();
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLastmileProbeResultPassed(result));
        }

        [Test]
        public void Test_OnAudioDeviceStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICESTATECHANGED;

            string deviceId;
            ParamsHelper.InitParam(out deviceId);

            MEDIA_DEVICE_TYPE deviceType;
            ParamsHelper.InitParam(out deviceType);

            MEDIA_DEVICE_STATE_TYPE deviceState;
            ParamsHelper.InitParam(out deviceState);

            jsonObj.Clear();
            jsonObj.Add("deviceId", deviceId);
            jsonObj.Add("deviceType", deviceType);
            jsonObj.Add("deviceState", deviceState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioDeviceStateChangedPassed(deviceId, deviceType, deviceState));
        }

        [Test]
        public void Test_OnAudioMixingPositionChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGPOSITIONCHANGED;

            long position;
            ParamsHelper.InitParam(out position);

            jsonObj.Clear();
            jsonObj.Add("position", position);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMixingPositionChangedPassed(position));
        }

        [Test]
        public void Test_OnAudioMixingFinished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGFINISHED;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMixingFinishedPassed());
        }

        [Test]
        public void Test_OnAudioEffectFinished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOEFFECTFINISHED;

            int soundId;
            ParamsHelper.InitParam(out soundId);

            jsonObj.Clear();
            jsonObj.Add("soundId", soundId);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioEffectFinishedPassed(soundId));
        }

        [Test]
        public void Test_OnVideoDeviceStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEODEVICESTATECHANGED;

            string deviceId;
            ParamsHelper.InitParam(out deviceId);

            MEDIA_DEVICE_TYPE deviceType;
            ParamsHelper.InitParam(out deviceType);

            MEDIA_DEVICE_STATE_TYPE deviceState;
            ParamsHelper.InitParam(out deviceState);

            jsonObj.Clear();
            jsonObj.Add("deviceId", deviceId);
            jsonObj.Add("deviceType", deviceType);
            jsonObj.Add("deviceState", deviceState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoDeviceStateChangedPassed(deviceId, deviceType, deviceState));
        }

        [Test]
        public void Test_OnUplinkNetworkInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONUPLINKNETWORKINFOUPDATED;

            UplinkNetworkInfo info;
            ParamsHelper.InitParam(out info);

            jsonObj.Clear();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUplinkNetworkInfoUpdatedPassed(info));
        }

        [Test]
        public void Test_OnDownlinkNetworkInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONDOWNLINKNETWORKINFOUPDATED;

            DownlinkNetworkInfo info;
            ParamsHelper.InitParam(out info);

            jsonObj.Clear();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDownlinkNetworkInfoUpdatedPassed(info));
        }

        [Test]
        public void Test_OnLastmileQuality()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEQUALITY;

            int quality;
            ParamsHelper.InitParam(out quality);

            jsonObj.Clear();
            jsonObj.Add("quality", quality);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLastmileQualityPassed(quality));
        }

        [Test]
        public void Test_OnApiCallExecuted()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAPICALLEXECUTED;

            int err;
            ParamsHelper.InitParam(out err);

            string api;
            ParamsHelper.InitParam(out api);

            string result;
            ParamsHelper.InitParam(out result);

            jsonObj.Clear();
            jsonObj.Add("err", err);
            jsonObj.Add("api", api);
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnApiCallExecutedPassed(err, api, result));
        }


        [Test]
        public void Test_OnCameraReady()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAREADY;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCameraReadyPassed());
        }

        [Test]
        public void Test_OnCameraFocusAreaChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAFOCUSAREACHANGED;

            int x;
            ParamsHelper.InitParam(out x);

            int y;
            ParamsHelper.InitParam(out y);

            int width;
            ParamsHelper.InitParam(out width);

            int height;
            ParamsHelper.InitParam(out height);

            jsonObj.Clear();
            jsonObj.Add("x", x);
            jsonObj.Add("y", y);
            jsonObj.Add("width", width);
            jsonObj.Add("height", height);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCameraFocusAreaChangedPassed(x, y, width, height));
        }

        [Test]
        public void Test_OnCameraExposureAreaChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAEXPOSUREAREACHANGED;

            int x;
            ParamsHelper.InitParam(out x);

            int y;
            ParamsHelper.InitParam(out y);

            int width;
            ParamsHelper.InitParam(out width);

            int height;
            ParamsHelper.InitParam(out height);

            jsonObj.Clear();
            jsonObj.Add("x", x);
            jsonObj.Add("y", y);
            jsonObj.Add("width", width);
            jsonObj.Add("height", height);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCameraExposureAreaChangedPassed(x, y, width, height));
        }

        [Test]
        public void Test_OnFacePositionChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONFACEPOSITIONCHANGED;

            int imageWidth;
            ParamsHelper.InitParam(out imageWidth);

            int imageHeight;
            ParamsHelper.InitParam(out imageHeight);

            Rectangle[] vecRectangle;
            ParamsHelper.InitParam(out vecRectangle);

            int[] vecDistance;
            ParamsHelper.InitParam(out vecDistance);

            int numFaces;
            ParamsHelper.InitParam(out numFaces);

            jsonObj.Clear();
            jsonObj.Add("imageWidth", imageWidth);
            jsonObj.Add("imageHeight", imageHeight);
            jsonObj.Add("vecRectangle", vecRectangle);
            jsonObj.Add("vecDistance", vecDistance);
            jsonObj.Add("numFaces", numFaces);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);

            //OnFacePositionChanged only in ios or android
            //Assert.AreEqual(true, EventHandler.OnFacePositionChangedPassed(imageWidth, imageHeight, vecRectangle, vecDistance, numFaces));
        }

        [Test]
        public void Test_OnVideoStopped()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSTOPPED;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoStoppedPassed());
        }

        [Test]
        public void Test_OnAudioMixingStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGSTATECHANGED;

            AUDIO_MIXING_STATE_TYPE state;
            ParamsHelper.InitParam(out state);

            AUDIO_MIXING_REASON_TYPE reason;
            ParamsHelper.InitParam(out reason);

            jsonObj.Clear();
            jsonObj.Add("state", state);
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMixingStateChangedPassed(state, reason));
        }

        [Test]
        public void Test_OnRhythmPlayerStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRHYTHMPLAYERSTATECHANGED;

            RHYTHM_PLAYER_STATE_TYPE state;
            ParamsHelper.InitParam(out state);

            RHYTHM_PLAYER_ERROR_TYPE errorCode;
            ParamsHelper.InitParam(out errorCode);

            jsonObj.Clear();
            jsonObj.Add("state", state);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRhythmPlayerStateChangedPassed(state, errorCode));
        }

        [Test]
        public void Test_OnContentInspectResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCONTENTINSPECTRESULT;

            CONTENT_INSPECT_RESULT result;
            ParamsHelper.InitParam(out result);

            jsonObj.Clear();
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnContentInspectResultPassed(result));
        }

        [Test]
        public void Test_OnAudioDeviceVolumeChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICEVOLUMECHANGED;

            MEDIA_DEVICE_TYPE deviceType;
            ParamsHelper.InitParam(out deviceType);

            int volume;
            ParamsHelper.InitParam(out volume);

            bool muted;
            ParamsHelper.InitParam(out muted);

            jsonObj.Clear();
            jsonObj.Add("deviceType", deviceType);
            jsonObj.Add("volume", volume);
            jsonObj.Add("muted", muted);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioDeviceVolumeChangedPassed(deviceType, volume, muted));
        }

        [Test]
        public void Test_OnRtmpStreamingStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGSTATECHANGED;

            string url;
            ParamsHelper.InitParam(out url);

            RTMP_STREAM_PUBLISH_STATE state;
            ParamsHelper.InitParam(out state);

            RTMP_STREAM_PUBLISH_ERROR_TYPE errCode;
            ParamsHelper.InitParam(out errCode);

            jsonObj.Clear();
            jsonObj.Add("url", url);
            jsonObj.Add("state", state);
            jsonObj.Add("errCode", errCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtmpStreamingStateChangedPassed(url, state, errCode));
        }

        [Test]
        public void Test_OnRtmpStreamingEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGEVENT;

            string url;
            ParamsHelper.InitParam(out url);

            RTMP_STREAMING_EVENT eventCode;
            ParamsHelper.InitParam(out eventCode);

            jsonObj.Clear();
            jsonObj.Add("url", url);
            jsonObj.Add("eventCode", eventCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtmpStreamingEventPassed(url, eventCode));
        }

        [Test]
        public void Test_OnTranscodingUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONTRANSCODINGUPDATED;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTranscodingUpdatedPassed());
        }

        [Test]
        public void Test_OnAudioRoutingChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOROUTINGCHANGED;

            int routing;
            ParamsHelper.InitParam(out routing);

            jsonObj.Clear();
            jsonObj.Add("routing", routing);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioRoutingChangedPassed(routing));
        }

        [Test]
        public void Test_OnChannelMediaRelayStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCHANNELMEDIARELAYSTATECHANGED;

            int state;
            ParamsHelper.InitParam(out state);

            int code;
            ParamsHelper.InitParam(out code);

            jsonObj.Clear();
            jsonObj.Add("state", state);
            jsonObj.Add("code", code);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnChannelMediaRelayStateChangedPassed(state, code));
        }

        [Test]
        public void Test_OnChannelMediaRelayEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCHANNELMEDIARELAYEVENT;

            int code;
            ParamsHelper.InitParam(out code);

            jsonObj.Clear();
            jsonObj.Add("code", code);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnChannelMediaRelayEventPassed(code));
        }

        [Test]
        public void Test_OnLocalPublishFallbackToAudioOnly()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALPUBLISHFALLBACKTOAUDIOONLY;

            bool isFallbackOrRecover;
            ParamsHelper.InitParam(out isFallbackOrRecover);

            jsonObj.Clear();
            jsonObj.Add("isFallbackOrRecover", isFallbackOrRecover);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalPublishFallbackToAudioOnlyPassed(isFallbackOrRecover));
        }

        [Test]
        public void Test_OnRemoteSubscribeFallbackToAudioOnly()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY;

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            bool isFallbackOrRecover;
            ParamsHelper.InitParam(out isFallbackOrRecover);

            jsonObj.Clear();
            jsonObj.Add("uid", uid);
            jsonObj.Add("isFallbackOrRecover", isFallbackOrRecover);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteSubscribeFallbackToAudioOnlyPassed(uid, isFallbackOrRecover));
        }

        [Test]
        public void Test_OnPermissionError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONPERMISSIONERROR;

            PERMISSION_TYPE permissionType;
            ParamsHelper.InitParam(out permissionType);

            jsonObj.Clear();
            jsonObj.Add("permissionType", permissionType);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPermissionErrorPassed(permissionType));
        }

        [Test]
        public void Test_OnLocalUserRegistered()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALUSERREGISTERED;

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            string userAccount;
            ParamsHelper.InitParam(out userAccount);

            jsonObj.Clear();
            jsonObj.Add("uid", uid);
            jsonObj.Add("userAccount", userAccount);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalUserRegisteredPassed(uid, userAccount));
        }

        [Test]
        public void Test_OnUserInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONUSERINFOUPDATED;

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            UserInfo info;
            ParamsHelper.InitParam(out info);

            jsonObj.Clear();
            jsonObj.Add("uid", uid);
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserInfoUpdatedPassed(uid, info));
        }


        [Test]
        public void Test_OnAudioSubscribeStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOSUBSCRIBESTATECHANGED;

            string channel;
            ParamsHelper.InitParam(out channel);

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            STREAM_SUBSCRIBE_STATE oldState;
            ParamsHelper.InitParam(out oldState);

            STREAM_SUBSCRIBE_STATE newState;
            ParamsHelper.InitParam(out newState);

            int elapseSinceLastState;
            ParamsHelper.InitParam(out elapseSinceLastState);

            jsonObj.Clear();
            jsonObj.Add("channel", channel);
            jsonObj.Add("uid", uid);
            jsonObj.Add("oldState", oldState);
            jsonObj.Add("newState", newState);
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioSubscribeStateChangedPassed(channel, uid, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_OnVideoSubscribeStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSUBSCRIBESTATECHANGED;

            string channel;
            ParamsHelper.InitParam(out channel);

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            STREAM_SUBSCRIBE_STATE oldState;
            ParamsHelper.InitParam(out oldState);

            STREAM_SUBSCRIBE_STATE newState;
            ParamsHelper.InitParam(out newState);

            int elapseSinceLastState;
            ParamsHelper.InitParam(out elapseSinceLastState);

            jsonObj.Clear();
            jsonObj.Add("channel", channel);
            jsonObj.Add("uid", uid);
            jsonObj.Add("oldState", oldState);
            jsonObj.Add("newState", newState);
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoSubscribeStateChangedPassed(channel, uid, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_OnAudioPublishStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOPUBLISHSTATECHANGED;

            string channel;
            ParamsHelper.InitParam(out channel);

            STREAM_PUBLISH_STATE oldState;
            ParamsHelper.InitParam(out oldState);

            STREAM_PUBLISH_STATE newState;
            ParamsHelper.InitParam(out newState);

            int elapseSinceLastState;
            ParamsHelper.InitParam(out elapseSinceLastState);

            jsonObj.Clear();
            jsonObj.Add("channel", channel);
            jsonObj.Add("oldState", oldState);
            jsonObj.Add("newState", newState);
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioPublishStateChangedPassed(channel, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_OnVideoPublishStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOPUBLISHSTATECHANGED;

            VIDEO_SOURCE_TYPE source;
            ParamsHelper.InitParam(out source);

            string channel;
            ParamsHelper.InitParam(out channel);

            STREAM_PUBLISH_STATE oldState;
            ParamsHelper.InitParam(out oldState);

            STREAM_PUBLISH_STATE newState;
            ParamsHelper.InitParam(out newState);

            int elapseSinceLastState;
            ParamsHelper.InitParam(out elapseSinceLastState);

            jsonObj.Clear();
            jsonObj.Add("source", source);
            jsonObj.Add("channel", channel);
            jsonObj.Add("oldState", oldState);
            jsonObj.Add("newState", newState);
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoPublishStateChangedPassed(source, channel, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_OnExtensionEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONEVENT;

            string provider;
            ParamsHelper.InitParam(out provider);

            string extension;
            ParamsHelper.InitParam(out extension);

            string key;
            ParamsHelper.InitParam(out key);

            string value;
            ParamsHelper.InitParam(out value);

            jsonObj.Clear();
            jsonObj.Add("provider", provider);
            jsonObj.Add("extension", extension);
            jsonObj.Add("key", key);
            jsonObj.Add("value", value);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionEventPassed(provider, extension, key, value));
        }

        [Test]
        public void Test_OnExtensionStarted()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTARTED;

            string provider;
            ParamsHelper.InitParam(out provider);

            string extension;
            ParamsHelper.InitParam(out extension);

            jsonObj.Clear();
            jsonObj.Add("provider", provider);
            jsonObj.Add("extension", extension);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionStartedPassed(provider, extension));
        }

        [Test]
        public void Test_OnExtensionStopped()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTOPPED;

            string provider;
            ParamsHelper.InitParam(out provider);

            string extension;
            ParamsHelper.InitParam(out extension);

            jsonObj.Clear();
            jsonObj.Add("provider", provider);
            jsonObj.Add("extension", extension);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionStoppedPassed(provider, extension));
        }

        [Test]
        public void Test_OnExtensionError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONERROR;

            string provider;
            ParamsHelper.InitParam(out provider);

            string extension;
            ParamsHelper.InitParam(out extension);

            int error;
            ParamsHelper.InitParam(out error);

            string message;
            ParamsHelper.InitParam(out message);

            jsonObj.Clear();
            jsonObj.Add("provider", provider);
            jsonObj.Add("extension", extension);
            jsonObj.Add("error", error);
            jsonObj.Add("message", message);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionErrorPassed(provider, extension, error, message));
        }

        [Test]
        public void Test_OnVideoRenderingTracingResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEORENDERINGTRACINGRESULT;

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);

            uid_t uid;
            ParamsHelper.InitParam(out uid);

            MEDIA_TRACE_EVENT currentEvent;
            ParamsHelper.InitParam(out currentEvent);

            VideoRenderingTracingInfo tracingInfo;
            ParamsHelper.InitParam(out tracingInfo);


            jsonObj.Clear();
            jsonObj.Add("connection", connection);
            jsonObj.Add("uid", uid);
            jsonObj.Add("currentEvent", currentEvent);
            jsonObj.Add("tracingInfo", tracingInfo);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoRenderingTracingResultPassed(connection, uid, currentEvent, tracingInfo));
        }

        #endregion



    }
}
