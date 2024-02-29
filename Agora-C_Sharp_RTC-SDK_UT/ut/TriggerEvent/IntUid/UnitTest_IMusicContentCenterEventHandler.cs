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
            int ret = MusicContentCenter.Initialize(new MusicContentCenterConfiguration("appid", "token", 120, 10));
            Assert.AreEqual(0, ret);
            MusicContentCenter.RegisterEventHandler(EventHandler);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnregisterMediaMetadataObserver();
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

            long songCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("songCode", songCode);

            string lyricUrl = ParamsHelper.CreateParam<string>();
            jsonObj.Add("lyricUrl", lyricUrl);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLyricResultPassed(requestId, songCode, lyricUrl, reason));
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

            long songCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("songCode", songCode);

            int percent = ParamsHelper.CreateParam<int>();
            jsonObj.Add("percent", percent);

            string lyricUrl = ParamsHelper.CreateParam<string>();
            jsonObj.Add("lyricUrl", lyricUrl);

            PreloadState state = ParamsHelper.CreateParam<PreloadState>();
            jsonObj.Add("state", state);

            MusicContentCenterStateReason reason = ParamsHelper.CreateParam<MusicContentCenterStateReason>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreLoadEventPassed(requestId, songCode, percent, lyricUrl, state, reason));
        }
        #endregion terra IMusicContentCenterEventHandler
    }
}