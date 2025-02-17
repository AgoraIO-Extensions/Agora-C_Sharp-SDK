using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public class UnitTest_IMusicContentCenterEventHandler
    {

        public IRtcEngineEx Engine;
        public IMediaRecorder MediaRecorder;
        public IMusicContentCenter MusicContentCenter;
        public UTMusicContentCenterEventHandler EventHandler;
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

            EventHandler = new UTMusicContentCenterEventHandler();
            MusicContentCenter = Engine.GetMusicContentCenter();
            int ret = MusicContentCenter.Initialize(new MusicContentCenterConfiguration(10));
            Assert.AreEqual(0, ret);
            MusicContentCenter.RegisterEventHandler(EventHandler);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = MusicContentCenter.UnregisterEventHandler();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IMusicContentCenterEventHandler
        [Test]
        public void Test_IMusicContentCenterEventHandler_OnMusicChartsResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCHARTSRESULT;

            jsonObj.Clear();

            string requestId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("requestId", requestId);

            MusicChartInfo[] result = ParamsHelper.CreateParam<MusicChartInfo[]>();
            jsonObj.Add("result", result);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMusicChartsResultPassed(requestId, result, reason));
        }

        [Test]
        public void Test_IMusicContentCenterEventHandler_OnMusicCollectionResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCOLLECTIONRESULT;

            jsonObj.Clear();

            string requestId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("requestId", requestId);

            MusicCollection result = ParamsHelper.CreateParam<MusicCollection>();
            jsonObj.Add("result", result);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMusicCollectionResultPassed(requestId, result, reason));
        }

        [Test]
        public void Test_IMusicContentCenterEventHandler_OnLyricResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONLYRICRESULT;

            jsonObj.Clear();

            string requestId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("requestId", requestId);

            long internalSongCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("internalSongCode", internalSongCode);

            string payload = ParamsHelper.CreateParam<string>();
            jsonObj.Add("payload", payload);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLyricResultPassed(requestId, internalSongCode, payload, reason));
        }

        [Test]
        public void Test_IMusicContentCenterEventHandler_OnLyricInfoResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONLYRICINFORESULT;

            jsonObj.Clear();

            string requestId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("requestId", requestId);

            long songCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("songCode", songCode);

            ILyricInfo lyricInfo = ParamsHelper.CreateParam<ILyricInfo>();
            jsonObj.Add("lyricInfo", lyricInfo);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLyricInfoResultPassed(requestId, songCode, lyricInfo, reason));
        }

        [Test]
        public void Test_IMusicContentCenterEventHandler_OnSongSimpleInfoResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONSONGSIMPLEINFORESULT;

            jsonObj.Clear();

            string requestId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("requestId", requestId);

            long songCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("songCode", songCode);

            string simpleInfo = ParamsHelper.CreateParam<string>();
            jsonObj.Add("simpleInfo", simpleInfo);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSongSimpleInfoResultPassed(requestId, songCode, simpleInfo, reason));
        }

        [Test]
        public void Test_IMusicContentCenterEventHandler_OnPreLoadEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONPRELOADEVENT;

            jsonObj.Clear();

            string requestId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("requestId", requestId);

            long internalSongCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("internalSongCode", internalSongCode);

            int percent = ParamsHelper.CreateParam<int>();
            jsonObj.Add("percent", percent);

            string payload = ParamsHelper.CreateParam<string>();
            jsonObj.Add("payload", payload);

            MusicContentCenterState status = ParamsHelper.CreateParam<MusicContentCenterState>();
            jsonObj.Add("status", status);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreLoadEventPassed(requestId, internalSongCode, percent, payload, status, reason));
        }

        [Test]
        public void Test_IMusicContentCenterEventHandler_OnStartScoreResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONSTARTSCORERESULT;

            jsonObj.Clear();

            long internalSongCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("internalSongCode", internalSongCode);

            MusicContentCenterState status = ParamsHelper.CreateParam<MusicContentCenterState>();
            jsonObj.Add("status", status);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStartScoreResultPassed(internalSongCode, status, reason));
        }
        #endregion terra IMusicContentCenterEventHandler
    }
}