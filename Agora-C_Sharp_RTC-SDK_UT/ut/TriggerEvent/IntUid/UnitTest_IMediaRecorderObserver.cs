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
        public IMediaRecorder MediaRecorder;
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
            MediaRecorder = Engine.CreateMediaRecorder(new RecorderStreamInfo("10", 10));
            int ret = MediaRecorder.SetMediaRecorderObserver(EventHandler);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = MediaRecorder.SetMediaRecorderObserver(null);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IMediaRecorderObserver
        [Test]
        public void Test_IMediaRecorderObserver_OnRecorderStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIARECORDEROBSERVER_ONRECORDERSTATECHANGED;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            RecorderState state = ParamsHelper.CreateParam<RecorderState>();
            jsonObj.Add("state", state);

            RecorderReasonCode reason = ParamsHelper.CreateParam<RecorderReasonCode>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecorderStateChangedPassed(channelId, uid, state, reason));
        }

        [Test]
        public void Test_IMediaRecorderObserver_OnRecorderInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIARECORDEROBSERVER_ONRECORDERINFOUPDATED;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            RecorderInfo info = ParamsHelper.CreateParam<RecorderInfo>();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecorderInfoUpdatedPassed(channelId, uid, info));
        }
        #endregion terra IMediaRecorderObserver
    }
}