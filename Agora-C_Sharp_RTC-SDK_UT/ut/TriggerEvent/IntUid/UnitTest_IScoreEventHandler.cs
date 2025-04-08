using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public partial class UnitTest_IScoreEventHandler
    {

        public IRtcEngineEx Engine;
        public IMediaRecorder MediaRecorder;
        public IMusicContentCenter MusicContentCenter;
        public UTScoreEventHandler callback;
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

            callback = new UTScoreEventHandler();
            MusicContentCenter = Engine.GetMusicContentCenter();
            int ret = MusicContentCenter.Initialize(new MusicContentCenterConfiguration(10));
            Assert.AreEqual(0, ret);
            MusicContentCenter.RegisterScoreEventHandler(callback);
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

    }
}