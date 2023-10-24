using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IMediaRecorderObserverS
    {

        public IRtcEngineExS Engine;
        public IMediaRecorderS MediaRecorder;
        public UTMediaRecorderObserverS EventHandler;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngineS();
            Engine = RtcEngineS.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContextS rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            ApiParam.AllocResult();

            EventHandler = new UTMediaRecorderObserverS();
            MediaRecorder = Engine.CreateMediaRecorder(new RecorderStreamInfoS("10", "10"));
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

        #region terra IMediaRecorderObserverS

        [Test]
        public void Test_OnRecorderStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIARECORDEROBSERVERS_ONRECORDERSTATECHANGED;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            string userId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userId", userId);

            RecorderState state = ParamsHelper.CreateParam<RecorderState>();
            jsonObj.Add("state", state);

            RecorderErrorCode error = ParamsHelper.CreateParam<RecorderErrorCode>();
            jsonObj.Add("error", error);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecorderStateChangedPassed(channelId, userId, state, error));
        }

        [Test]
        public void Test_OnRecorderInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIARECORDEROBSERVERS_ONRECORDERINFOUPDATED;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            string userId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userId", userId);

            RecorderInfo info = ParamsHelper.CreateParam<RecorderInfo>();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecorderInfoUpdatedPassed(channelId, userId, info));
        }
        #endregion terra IMediaRecorderObserverS
    }
}