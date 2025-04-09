using NUnit.Framework;
using Agora.Rtc;
using uid_t = System.UInt32;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IH265Transcoder
    {
        public IRtcEngine Engine;
        public IH265Transcoder @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            rtcEngineContext.logConfig.level = LOG_LEVEL.LOG_LEVEL_API_CALL;
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.GetH265Transcoder();
            Assert.AreEqual(@interface != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

    }
}
