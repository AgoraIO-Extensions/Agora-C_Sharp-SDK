using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IVideoEncodedFrameObserverS
    {
        public IRtcEngineExS Engine;
        public UTVideoEncodedFrameObserverS EventHandler;
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

            EventHandler = new UTVideoEncodedFrameObserverS();
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

        #region terra IVideoEncodedFrameObserverS
        [Test]
        public void Test_OnEncodedVideoFrameReceived()
        {
            ApiParam.@event = AgoraEventType.EVENT_VIDEOENCODEDFRAMEOBSERVERS_ONENCODEDVIDEOFRAMERECEIVED;

            jsonObj.Clear();

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            IntPtr imageBuffer = ParamsHelper.CreateParam<IntPtr>();
            jsonObj.Add("imageBuffer", imageBuffer);

            ulong length = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("length", length);

            EncodedVideoFrameInfoS videoEncodedFrameInfoS = ParamsHelper.CreateParam<EncodedVideoFrameInfoS>();
            jsonObj.Add("videoEncodedFrameInfoS", videoEncodedFrameInfoS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnEncodedVideoFrameReceivedPassed(userAccount, imageBuffer, length, videoEncodedFrameInfoS));
        }
        #endregion terra IVideoEncodedFrameObserverS
    }
}
