using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc.Ut
{
    using view_t = System.UInt64;
    public partial class UnitTest_IMusicPlayer
    {
        public IRtcEngine Engine;
        public IMusicPlayer @interface;
        public IMusicContentCenter MusicContentCenter;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MusicContentCenter = Engine.GetMusicContentCenter();
            @interface = MusicContentCenter.CreateMusicPlayer();

            Assert.AreEqual(@interface.GetId() > 0, true);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = MusicContentCenter.DestroyMusicPlayer(@interface);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
        }
    }
}
