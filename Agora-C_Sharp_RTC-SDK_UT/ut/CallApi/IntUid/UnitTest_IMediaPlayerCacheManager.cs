using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IMediaPlayerCacheManager
    {
        public IRtcEngine Engine;
        public IMediaPlayerCacheManager @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.GetMediaPlayerCacheManager();
            Assert.AreEqual(@interface != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

    }
}
