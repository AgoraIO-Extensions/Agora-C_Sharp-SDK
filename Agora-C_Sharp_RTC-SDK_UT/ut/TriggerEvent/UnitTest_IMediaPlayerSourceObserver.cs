using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IMediaPlayerSourceObserver
    {

        public IRtcEngineEx Engine;
        public IMediaPlayer MediaPlayer;
        public UTMediaPlayerSourceObserver EventHandler;
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

            MediaPlayer = Engine.CreateMediaPlayer();
            EventHandler = new UTMediaPlayerSourceObserver();
            int ret = MediaPlayer.InitEventHandler(EventHandler);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.InitEventHandler(null);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region


        [Test]
        public void Test_OnPlayerSourceStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSOURCESTATECHANGED;

            MEDIA_PLAYER_STATE state;
            ParamsHelper.InitParam(out state);

            MEDIA_PLAYER_ERROR ec;
            ParamsHelper.InitParam(out ec);

            jsonObj.Clear();
            jsonObj.Add("state", state);
            jsonObj.Add("ec", ec);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlayerSourceStateChangedPassed(state, ec));
        }

        [Test]
        public void Test_OnPositionChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPOSITIONCHANGED;

            long position_ms;
            ParamsHelper.InitParam(out position_ms);

            long timestamp_ms;
            ParamsHelper.InitParam(out timestamp_ms);


            jsonObj.Clear();
            jsonObj.Add("position_ms", position_ms);
            jsonObj.Add("timestamp_ms", timestamp_ms);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPositionChangedPassed(position_ms, timestamp_ms));
        }

        [Test]
        public void Test_OnPlayerEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYEREVENT;

            MEDIA_PLAYER_EVENT eventCode;
            ParamsHelper.InitParam(out eventCode);

            long elapsedTime;
            ParamsHelper.InitParam(out elapsedTime);

            string message;
            ParamsHelper.InitParam(out message);

            jsonObj.Clear();
            jsonObj.Add("eventCode", eventCode);
            jsonObj.Add("elapsedTime", elapsedTime);
            jsonObj.Add("message", message);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlayerEventPassed(eventCode, elapsedTime, message));
        }

        [Test]
        public void Test_OnMetaData()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONMETADATA;

            byte[]  data;
            ParamsHelper.InitParam(out data);

            int length;
            ParamsHelper.InitParam(out length);

            jsonObj.Clear();
            jsonObj.Add("data", data);
            jsonObj.Add("length", length);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMetaDataPassed(data, length));
        }

        [Test]
        public void Test_OnPlayBufferUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYBUFFERUPDATED;

            long playCachedBuffer;
            ParamsHelper.InitParam(out playCachedBuffer);

            jsonObj.Clear();
            jsonObj.Add("playCachedBuffer", playCachedBuffer);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlayBufferUpdatedPassed(playCachedBuffer));
        }

        [Test]
        public void Test_OnPreloadEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPRELOADEVENT;

            string src;
            ParamsHelper.InitParam(out src);

            PLAYER_PRELOAD_EVENT @event;
            ParamsHelper.InitParam(out @event);

            jsonObj.Clear();
            jsonObj.Add("src", src);
            jsonObj.Add("@event", @event);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreloadEventPassed(src, @event));
        }

        [Test]
        public void Test_OnCompleted()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONCOMPLETED;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCompletedPassed());
        }

        [Test]
        public void Test_OnAgoraCDNTokenWillExpire()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAGORACDNTOKENWILLEXPIRE;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAgoraCDNTokenWillExpirePassed());
        }

        [Test]
        public void Test_OnPlayerSrcInfoChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSRCINFOCHANGED;

            SrcInfo from;
            ParamsHelper.InitParam(out from);

            SrcInfo to;
            ParamsHelper.InitParam(out to);

            jsonObj.Clear();
            jsonObj.Add("from", from);
            jsonObj.Add("to", to);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlayerSrcInfoChangedPassed(from, to));
        }

        [Test]
        public void Test_OnPlayerInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERINFOUPDATED;

            PlayerUpdatedInfo info;
            ParamsHelper.InitParam(out info);

            jsonObj.Clear();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlayerInfoUpdatedPassed(info));
        }

        [Test]
        public void Test_OnAudioVolumeIndication()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAUDIOVOLUMEINDICATION;

            int volume;
            ParamsHelper.InitParam(out volume);

            jsonObj.Clear();
            jsonObj.Add("volume", volume);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioVolumeIndicationPassed(volume));
        }


        #endregion
    }
}