using NUnit.Framework;
using Agora.Rtc;
namespace Agora.Rtc.Ut
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
            MusicContentCenterConfiguration configuration = ParamsHelper.CreateParam<MusicContentCenterConfiguration>();

            nRet = MusicContentCenter.Initialize(configuration);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        #region terra IMusicContentCenter
        [Test]
        public void Test_AddVendor()
        {
            MusicContentCenterVendorID vendorId = ParamsHelper.CreateParam<MusicContentCenterVendorID>();
            string jsonVendorConfig = ParamsHelper.CreateParam<string>();

            var nRet = MusicContentCenter.AddVendor(vendorId, jsonVendorConfig);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveVendor()
        {
            MusicContentCenterVendorID vendorId = ParamsHelper.CreateParam<MusicContentCenterVendorID>();

            var nRet = MusicContentCenter.RemoveVendor(vendorId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewToken()
        {
            MusicContentCenterVendorID vendorID = ParamsHelper.CreateParam<MusicContentCenterVendorID>();
            string token = ParamsHelper.CreateParam<string>();

            var nRet = MusicContentCenter.RenewToken(vendorID, token);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterEventHandler()
        {


            var nRet = MusicContentCenter.UnregisterEventHandler();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetMusicCharts()
        {
            string requestId = ParamsHelper.CreateParam<string>();

            var nRet = MusicContentCenter.GetMusicCharts(ref requestId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetMusicCollectionByMusicChartId()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            int musicChartId = ParamsHelper.CreateParam<int>();
            int page = ParamsHelper.CreateParam<int>();
            int pageSize = ParamsHelper.CreateParam<int>();
            string jsonOption = ParamsHelper.CreateParam<string>();

            var nRet = MusicContentCenter.GetMusicCollectionByMusicChartId(ref requestId, musicChartId, page, pageSize, jsonOption);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SearchMusic()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            string keyWord = ParamsHelper.CreateParam<string>();
            int page = ParamsHelper.CreateParam<int>();
            int pageSize = ParamsHelper.CreateParam<int>();
            string jsonOption = ParamsHelper.CreateParam<string>();

            var nRet = MusicContentCenter.SearchMusic(ref requestId, keyWord, page, pageSize, jsonOption);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Preload()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            long internalSongCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.Preload(ref requestId, internalSongCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnregisterScoreEventHandler()
        {


            var nRet = MusicContentCenter.UnregisterScoreEventHandler();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetScoreLevel()
        {
            ScoreLevel level = ParamsHelper.CreateParam<ScoreLevel>();

            var nRet = MusicContentCenter.SetScoreLevel(level);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScore()
        {
            long internalSongCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.StartScore(internalSongCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopScore()
        {


            var nRet = MusicContentCenter.StopScore();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseScore()
        {


            var nRet = MusicContentCenter.PauseScore();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeScore()
        {


            var nRet = MusicContentCenter.ResumeScore();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCumulativeScoreData()
        {
            CumulativeScoreData cumulativeScoreData = ParamsHelper.CreateParam<CumulativeScoreData>();

            var nRet = MusicContentCenter.GetCumulativeScoreData(ref cumulativeScoreData);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveCache()
        {
            long internalSongCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.RemoveCache(internalSongCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCaches()
        {
            MusicCacheInfo[] cacheInfo = ParamsHelper.CreateParam<MusicCacheInfo[]>();
            int cacheInfoSize = ParamsHelper.CreateParam<int>();

            var nRet = MusicContentCenter.GetCaches(ref cacheInfo, ref cacheInfoSize);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IsPreloaded()
        {
            long internalSongCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.IsPreloaded(internalSongCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetLyric()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            long internalSongCode = ParamsHelper.CreateParam<long>();
            int lyricType = ParamsHelper.CreateParam<int>();

            var nRet = MusicContentCenter.GetLyric(ref requestId, internalSongCode, lyricType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetLyricInfo()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            long internalSongCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.GetLyricInfo(ref requestId, internalSongCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetSongSimpleInfo()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            long internalSongCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.GetSongSimpleInfo(ref requestId, internalSongCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetInternalSongCode()
        {
            MusicContentCenterVendorID vendorId = ParamsHelper.CreateParam<MusicContentCenterVendorID>();
            string songCode = ParamsHelper.CreateParam<string>();
            string jsonOption = ParamsHelper.CreateParam<string>();
            long internalSongCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.GetInternalSongCode(vendorId, songCode, jsonOption, ref internalSongCode);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IMusicContentCenter
    }
}
