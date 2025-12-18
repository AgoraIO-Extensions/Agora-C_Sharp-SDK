using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc.Ut
{
    [TestFixture]
    public partial class UnitTest_IVideoEffectObject
    {
        public IVideoEffectObject @interface;
        public IRtcEngine rtcEngine;

        [SetUp]
        public void Setup()
        {
            rtcEngine = Rtc.RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            rtcEngine.Initialize(rtcEngineContext);
            @interface = rtcEngine.CreateVideoEffectObject("");
        }

        [TearDown]
        public void TearDown()
        {
            if (@interface != null)
            {
                rtcEngine.DestroyVideoEffectObject(@interface);
                @interface = null;
            }
            if (rtcEngine != null)
            {
                rtcEngine.Dispose();
                rtcEngine = null;
            }
        }
    }
}

