using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public class UnitTest_IScoreEventHandler
    {

        public IRtcEngineEx Engine;
        public IMediaRecorder MediaRecorder;
        public IMusicContentCenter MusicContentCenter;
        public UTScoreEventHandler EventHandler;
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

            EventHandler = new UTScoreEventHandler();
            MusicContentCenter = Engine.GetMusicContentCenter();
            int ret = MusicContentCenter.Initialize(new MusicContentCenterConfiguration(10));
            Assert.AreEqual(0, ret);
            MusicContentCenter.RegisterScoreEventHandler(EventHandler);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = MusicContentCenter.UnregisterScoreEventHandler();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IScoreEventHandler
        [Test]
        public void Test_IScoreEventHandler_OnPitch()
        {
            ApiParam.@event = AgoraEventType.EVENT_SCOREEVENTHANDLER_ONPITCH;

            jsonObj.Clear();

            long songCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("songCode", songCode);

            RawScoreData rawScoreData = ParamsHelper.CreateParam<RawScoreData>();
            jsonObj.Add("rawScoreData", rawScoreData);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPitchPassed(songCode, rawScoreData));
        }

        [Test]
        public void Test_IScoreEventHandler_OnLineScore()
        {
            ApiParam.@event = AgoraEventType.EVENT_SCOREEVENTHANDLER_ONLINESCORE;

            jsonObj.Clear();

            long songCode = ParamsHelper.CreateParam<long>();
            jsonObj.Add("songCode", songCode);

            LineScoreData lineScoreData = ParamsHelper.CreateParam<LineScoreData>();
            jsonObj.Add("lineScoreData", lineScoreData);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLineScorePassed(songCode, lineScoreData));
        }
        #endregion terra IScoreEventHandler
    }
}