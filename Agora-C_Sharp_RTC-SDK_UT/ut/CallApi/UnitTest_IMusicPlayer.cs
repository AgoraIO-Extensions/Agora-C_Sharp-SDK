using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc
{
    public class UnitTest_IMusicPlayer
    {
        public IRtcEngine Engine;
        public IMusicPlayer MusicPlayer;
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
            MusicPlayer = MusicContentCenter.CreateMusicPlayer();

            Assert.AreEqual(MusicPlayer.GetId() > 0, true);
        }

        [TearDown]
        public void TearDown()
        {
            MusicContentCenter.DestroyMusicPlayer(MusicPlayer);
            Engine.Dispose();
        }

        #region terra IMusicPlayer

        [Test]
        public void Test_Open()
        {
            long songCode = ParamsHelper.CreateParam<long>();
            long startPos = ParamsHelper.CreateParam<long>();

            var nRet = MusicPlayer.Open(songCode, startPos);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IMusicPlayer
    }
}
