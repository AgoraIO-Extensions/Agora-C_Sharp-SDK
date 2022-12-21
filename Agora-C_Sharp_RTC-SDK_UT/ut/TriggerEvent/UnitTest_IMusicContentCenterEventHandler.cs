using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
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
            int ret = MusicContentCenter.Initialize(new MusicContentCenterConfiguration("appid","token", 120));
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

        #region

        [Test]
        public void Test_OnMusicChartsResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCHARTSRESULT;

            string requestId;
            ParamsHelper.InitParam(out requestId);

            MusicContentCenterStatusCode status;
            ParamsHelper.InitParam(out status);

            MusicChartInfo[] result;
            ParamsHelper.InitParam(out result);

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("status", status);
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMusicChartsResultPassed(requestId, status, result));
        }

        [Test]
        public void Test_OnMusicCollectionResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCOLLECTIONRESULT;

            string requestId;
            ParamsHelper.InitParam(out requestId);

            MusicContentCenterStatusCode status;
            ParamsHelper.InitParam(out status);

            MusicCollection result;
            ParamsHelper.InitParam(out result);

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("status", status);
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMusicCollectionResultPassed(requestId, status, result));
        }

        [Test]
        public void Test_OnLyricResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONLYRICRESULT;

            string requestId;
            ParamsHelper.InitParam(out requestId);

            string lyricUrl;
            ParamsHelper.InitParam(out lyricUrl);

            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("lyricUrl", lyricUrl);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLyricResultPassed(requestId, lyricUrl));
        }

        [Test]
        public void Test_OnPreLoadEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONPRELOADEVENT;

            long songCode;
            ParamsHelper.InitParam(out songCode);

            int percent;
            ParamsHelper.InitParam(out percent);

            PreloadStatusCode status;
            ParamsHelper.InitParam(out status);

            string msg;
            ParamsHelper.InitParam(out msg);

            string lyricUrl;
            ParamsHelper.InitParam(out lyricUrl);

            jsonObj.Clear();
            jsonObj.Add("songCode", songCode);
            jsonObj.Add("percent", percent);
            jsonObj.Add("status", status);
            jsonObj.Add("msg", msg);
            jsonObj.Add("lyricUrl", lyricUrl);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreLoadEventPassed(songCode, percent, status, msg, lyricUrl));
        }


        #endregion
    }
}