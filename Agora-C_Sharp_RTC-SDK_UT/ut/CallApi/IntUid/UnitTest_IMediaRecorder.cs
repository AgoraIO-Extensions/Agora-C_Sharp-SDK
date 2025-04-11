using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IMediaRecorder
    {
        public IRtcEngine Engine;
        public IMediaRecorder @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.CreateMediaRecorder(new RecorderStreamInfo("10", 10));
        }

        [TearDown]
        public void TearDown()
        {
            Engine.DestroyMediaRecorder(@interface);
            Engine.Dispose();
        }
    }
}
