using NUnit.Framework;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    using view_t = System.UInt64;
    public partial class UnitTest_IMediaPlayer
    {
        public IRtcEngine Engine;
        public IMediaPlayer @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.CreateMediaPlayer();
            Assert.AreEqual(@interface.GetId() > 0, true);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.DestroyMediaPlayer(@interface);
            Engine.Dispose();
        }

        [Test]
        public void Test_OpenWithMediaSource()
        {
            MediaSource source = new MediaSource();
            source.provider = new UTMediaPlayerCustomDataProvider();

            var nRet = @interface.OpenWithMediaSource(source);
            Assert.AreEqual(0, nRet);
        }
    }
}
