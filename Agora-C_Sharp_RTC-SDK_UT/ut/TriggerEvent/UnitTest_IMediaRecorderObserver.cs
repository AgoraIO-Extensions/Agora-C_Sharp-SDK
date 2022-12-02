using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IMediaRecorderObserver
    {

        public IRtcEngineEx Engine;
        public IMediaRecorder  MediaRecorder;
        public UTMediaRecorderObserver EventHandler;
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

         
            EventHandler = new UTMediaRecorderObserver();
            MediaRecorder = Engine.GetMediaRecorder();
            int ret = MediaRecorder.SetMediaRecorderObserver(new RtcConnection("10", 10), EventHandler);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = MediaRecorder.SetMediaRecorderObserver(new RtcConnection("10", 10), null);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region

        [Test]
        public void Test_OnRecorderStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIARECORDEROBSERVER_ONRECORDERSTATECHANGED;

            RecorderState state;
            ParamsHelper.InitParam(out state);

            RecorderErrorCode error;
            ParamsHelper.InitParam(out error);

            jsonObj.Clear();
            jsonObj.Add("state", state);
            jsonObj.Add("error", error);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecorderStateChangedPassed(state, error));
        }

        [Test]
        public void Test_OnRecorderInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIARECORDEROBSERVER_ONRECORDERINFOUPDATED;

            RecorderInfo info;
            ParamsHelper.InitParam(out info);

            jsonObj.Clear();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecorderInfoUpdatedPassed(info));
        }

        #endregion
    }
}