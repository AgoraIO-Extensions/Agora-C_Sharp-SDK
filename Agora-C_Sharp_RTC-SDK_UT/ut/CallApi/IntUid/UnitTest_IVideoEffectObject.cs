using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IVideoEffectObject
    {
        public IRtcEngine Engine;
        public IVideoEffectObject @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.CreateVideoEffectObject("");
        }

        [TearDown]
        public void TearDown()
        {
            Engine.DestroyVideoEffectObject(@interface);
            Engine.Dispose();
        }

    }
}
