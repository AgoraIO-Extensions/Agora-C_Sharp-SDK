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

        #region



        [Test]
        public void Test_OnMusicChartsResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCHARTSRESULT;

            string requestId;
            ParamsHelper.InitParam(out requestId);

            MusicChartInfo[] result;
            ParamsHelper.InitParam(out result);

            MusicContentCenterStatusCode errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("result", result);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMusicChartsResultPassed(requestId, result, errorCode));
        }


        [Test]
        public void Test_OnMusicCollectionResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCOLLECTIONRESULT;

            string requestId;
            ParamsHelper.InitParam(out requestId);

            MusicCollection result;
            ParamsHelper.InitParam(out result);

            MusicContentCenterStatusCode errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("result", result);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMusicCollectionResultPassed(requestId, result, errorCode));
        }


        [Test]
        public void Test_OnLyricResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONLYRICRESULT;

            string requestId;
            ParamsHelper.InitParam(out requestId);

            long songCode;
            ParamsHelper.InitParam(out songCode);

            string lyricUrl;
            ParamsHelper.InitParam(out lyricUrl);

            MusicContentCenterStatusCode errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("songCode", songCode);
            jsonObj.Add("lyricUrl", lyricUrl);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLyricResultPassed(requestId, songCode, lyricUrl, errorCode));
        }


        [Test]
        public void Test_OnSongSimpleInfoResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONSONGSIMPLEINFORESULT;

            string requestId;
            ParamsHelper.InitParam(out requestId);

            long songCode;
            ParamsHelper.InitParam(out songCode);

            string simpleInfo;
            ParamsHelper.InitParam(out simpleInfo);

            MusicContentCenterStatusCode errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("songCode", songCode);
            jsonObj.Add("simpleInfo", simpleInfo);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSongSimpleInfoResultPassed(requestId, songCode, simpleInfo, errorCode));
        }


        [Test]
        public void Test_OnPreLoadEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONPRELOADEVENT;

            string requestId;
            ParamsHelper.InitParam(out requestId);

            long songCode;
            ParamsHelper.InitParam(out songCode);

            int percent;
            ParamsHelper.InitParam(out percent);

            string lyricUrl;
            ParamsHelper.InitParam(out lyricUrl);

            PreloadStatusCode status;
            ParamsHelper.InitParam(out status);

            MusicContentCenterStatusCode errorCode;
            ParamsHelper.InitParam(out errorCode);


            jsonObj.Clear();
            jsonObj.Add("requestId", requestId);
            jsonObj.Add("songCode", songCode);
            jsonObj.Add("percent", percent);
            jsonObj.Add("lyricUrl", lyricUrl);
            jsonObj.Add("status", status);
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPreLoadEventPassed(requestId, songCode, percent, lyricUrl, status, errorCode));
        }


        #endregion
    }
}