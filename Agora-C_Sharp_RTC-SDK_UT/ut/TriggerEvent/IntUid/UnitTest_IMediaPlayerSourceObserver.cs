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

        #region terra IMediaPlayerSourceObserver
        [Test]
        public void Test_OnPlayerSourceStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSOURCESTATECHANGED;

            jsonObj.Clear();

            MEDIA_PLAYER_STATE state = ParamsHelper.CreateParam<MEDIA_PLAYER_STATE>();
            jsonObj.Add("state", state);

            MEDIA_PLAYER_ERROR ec = ParamsHelper.CreateParam<MEDIA_PLAYER_ERROR>();
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

            jsonObj.Clear();

            long positionMs = ParamsHelper.CreateParam<long>();
            jsonObj.Add("positionMs", positionMs);

            long timestampMs = ParamsHelper.CreateParam<long>();
            jsonObj.Add("timestampMs", timestampMs);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPositionChangedPassed(positionMs, timestampMs));
        }

        [Test]
        public void Test_OnPlayerEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYEREVENT;

            jsonObj.Clear();

            MEDIA_PLAYER_EVENT eventCode = ParamsHelper.CreateParam<MEDIA_PLAYER_EVENT>();
            jsonObj.Add("eventCode", eventCode);

            long elapsedTime = ParamsHelper.CreateParam<long>();
            jsonObj.Add("elapsedTime", elapsedTime);

            string message = ParamsHelper.CreateParam<string>();
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

            jsonObj.Clear();

            byte[] data = ParamsHelper.CreateParam<byte[]>();
            jsonObj.Add("data", data);

            int length = ParamsHelper.CreateParam<int>();
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

            jsonObj.Clear();

            long playCachedBuffer = ParamsHelper.CreateParam<long>();
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

            jsonObj.Clear();

            string src = ParamsHelper.CreateParam<string>();
            jsonObj.Add("src", src);

            PLAYER_PRELOAD_EVENT @event = ParamsHelper.CreateParam<PLAYER_PRELOAD_EVENT>();
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

            jsonObj.Clear();

            SrcInfo from = ParamsHelper.CreateParam<SrcInfo>();
            jsonObj.Add("from", from);

            SrcInfo to = ParamsHelper.CreateParam<SrcInfo>();
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

            jsonObj.Clear();

            PlayerUpdatedInfo info = ParamsHelper.CreateParam<PlayerUpdatedInfo>();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlayerInfoUpdatedPassed(info));
        }

        [Test]
        public void Test_OnPlayerCacheStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERCACHESTATS;

            jsonObj.Clear();

            CacheStatistics stats = ParamsHelper.CreateParam<CacheStatistics>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlayerCacheStatsPassed(stats));
        }

        [Test]
        public void Test_OnPlayerPlaybackStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERPLAYBACKSTATS;

            jsonObj.Clear();

            PlayerPlaybackStats stats = ParamsHelper.CreateParam<PlayerPlaybackStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPlayerPlaybackStatsPassed(stats));
        }

        [Test]
        public void Test_OnAudioVolumeIndication()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAUDIOVOLUMEINDICATION;

            jsonObj.Clear();

            int volume = ParamsHelper.CreateParam<int>();
            jsonObj.Add("volume", volume);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioVolumeIndicationPassed(volume));
        }
        #endregion terra IMediaPlayerSourceObserver
    }
}