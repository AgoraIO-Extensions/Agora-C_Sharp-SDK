using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public partial class UnitTest_IAudioEncodedFrameObserver
    {

        public IRtcEngineEx Engine;
        public UTAudioEncodedFrameObserver callback;
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

            AudioEncodedFrameObserverConfig config = new AudioEncodedFrameObserverConfig();
            callback = new UTAudioEncodedFrameObserver();
            Engine.RegisterAudioEncodedFrameObserver(config, callback);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnRegisterAudioEncodedFrameObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }
    }
}