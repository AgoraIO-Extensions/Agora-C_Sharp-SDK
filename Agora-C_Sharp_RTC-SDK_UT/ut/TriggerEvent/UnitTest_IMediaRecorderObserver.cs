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
            MediaRecorder = Engine.CreateLocalMediaRecorder(new RtcConnection("10", 10));
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

        #region


        [Test]
        public void Test_OnRecorderStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIARECORDEROBSERVER_ONRECORDERSTATECHANGED;

            string channelId;
            ParamsHelper.InitParam(out channelId);

            uint uid;
            ParamsHelper.InitParam(out uid);

            RecorderState state;
            ParamsHelper.InitParam(out state);

            RecorderErrorCode error;
            ParamsHelper.InitParam(out error);


            jsonObj.Clear();
            jsonObj.Add("channelId", channelId);
            jsonObj.Add("uid", uid);
            jsonObj.Add("state", state);
            jsonObj.Add("error", error);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecorderStateChangedPassed(channelId, uid, state, error));
        }


        [Test]
        public void Test_OnRecorderInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIARECORDEROBSERVER_ONRECORDERINFOUPDATED;

            string channelId;
            ParamsHelper.InitParam(out channelId);

            uint uid;
            ParamsHelper.InitParam(out uid);

            RecorderInfo info;
            ParamsHelper.InitParam(out info);


            jsonObj.Clear();
            jsonObj.Add("channelId", channelId);
            jsonObj.Add("uid", uid);
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRecorderInfoUpdatedPassed(channelId, uid, info));
        }


        #endregion
    }
}