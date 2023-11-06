using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IVideoEncodedFrameObserver
    {
        public IRtcEngineEx Engine;
        public UTVideoEncodedFrameObserver EventHandler;
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

            EventHandler = new UTVideoEncodedFrameObserver();
            int ret = Engine.RegisterVideoEncodedFrameObserver(EventHandler, OBSERVER_MODE.INTPTR);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnRegisterVideoEncodedFrameObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IVideoEncodedFrameObserver

        [Test]
        public void Test_OnEncodedVideoFrameReceived()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED;

            jsonObj.Clear();

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            IntPtr imageBuffer = ParamsHelper.CreateParam<IntPtr>();
            jsonObj.Add("imageBuffer", imageBuffer);

            ulong length = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("length", length);

            EncodedVideoFrameInfo videoEncodedFrameInfo = ParamsHelper.CreateParam<EncodedVideoFrameInfo>();
            jsonObj.Add("videoEncodedFrameInfo", videoEncodedFrameInfo);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnEncodedVideoFrameReceivedPassed(uid, imageBuffer, length, videoEncodedFrameInfo));
        }
        #endregion terra IVideoEncodedFrameObserver
    }
}
