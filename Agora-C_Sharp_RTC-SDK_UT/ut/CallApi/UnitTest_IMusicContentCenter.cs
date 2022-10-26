using NUnit.Framework;
using Agora.Rtc;
namespace ut
{
    public class UnitTest_IMusicContentCenter
    {
        public IRtcEngine Engine;
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
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
        }

        #region custom
        [Test]
        public void Test_GetMusicCharts()
        {
            string requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = MusicContentCenter.GetMusicCharts(ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetMusicCollectionByMusicChartId()
        {
            string requestId;
            ParamsHelper.InitParam(out requestId);
            int musicChartId;
            ParamsHelper.InitParam(out musicChartId);
            int page;
            ParamsHelper.InitParam(out page);
            int pageSize;
            ParamsHelper.InitParam(out pageSize);
            string jsonOption;
            ParamsHelper.InitParam(out jsonOption);
            var nRet = MusicContentCenter.GetMusicCollectionByMusicChartId(ref requestId, musicChartId, page, pageSize, jsonOption);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SearchMusic()
        {
            string requestId;
            ParamsHelper.InitParam(out requestId);
            string keyWord;
            ParamsHelper.InitParam(out keyWord);
            int page;
            ParamsHelper.InitParam(out page);
            int pageSize;
            ParamsHelper.InitParam(out pageSize);
            string jsonOption;
            ParamsHelper.InitParam(out jsonOption);
            var nRet = MusicContentCenter.SearchMusic(ref requestId, keyWord, page, pageSize, jsonOption);

            Assert.AreEqual(0, nRet);
        }


        [Test]
        public void Test_GetLyric()
        {
            string requestId;
            ParamsHelper.InitParam(out requestId);
            long songCode;
            ParamsHelper.InitParam(out songCode);
            int LyricType;
            ParamsHelper.InitParam(out LyricType);
            var nRet = MusicContentCenter.GetLyric(ref requestId, songCode, LyricType);

            Assert.AreEqual(0, nRet);
        }
        #endregion

        #region terr
        [Test]
        public void Test_Initialize()
        {
            MusicContentCenterConfiguration configuration;
            ParamsHelper.InitParam(out configuration);
            var nRet = MusicContentCenter.Initialize(configuration);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RegisterEventHandler()
        {
            IMusicContentCenterEventHandler eventHandler;
            ParamsHelper.InitParam(out eventHandler);
            var nRet = MusicContentCenter.RegisterEventHandler(eventHandler);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterEventHandler()
        {

            var nRet = MusicContentCenter.UnregisterEventHandler();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Preload()
        {
            long songCode;
            ParamsHelper.InitParam(out songCode);
            string jsonOption;
            ParamsHelper.InitParam(out jsonOption);
            var nRet = MusicContentCenter.Preload(songCode, jsonOption);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsPreloaded()
        {
            long songCode;
            ParamsHelper.InitParam(out songCode);
            var nRet = MusicContentCenter.IsPreloaded(songCode);

            Assert.AreEqual(0, nRet);
        }



        #endregion
    }
}
