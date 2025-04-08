using NUnit.Framework;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IMusicContentCenter
    {
        public IRtcEngine Engine;
        public IMusicContentCenter @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.GetMusicContentCenter();
            MusicContentCenterConfiguration configuration = ParamsHelper.CreateParam<MusicContentCenterConfiguration>();

            nRet = @interface.Initialize(configuration);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

    }
}
