using NUnit.Framework;
using Agora.Rtc;
namespace Agora.Rtc
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
        public void Test_RenewToken()
        {
            string token = ParamsHelper.CreateParam<string>();

            var nRet = MusicContentCenter.RenewToken(token);
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
            long songCode = ParamsHelper.CreateParam<long>();
            string jsonOption = ParamsHelper.CreateParam<string>();

            var nRet = MusicContentCenter.Preload(songCode, jsonOption);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Preload2()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            long songCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.Preload(ref requestId, songCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveCache()
        {
            long songCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.RemoveCache(songCode);
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
            long songCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.IsPreloaded(songCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetLyric()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            long songCode = ParamsHelper.CreateParam<long>();
            int LyricType = ParamsHelper.CreateParam<int>();

            var nRet = MusicContentCenter.GetLyric(ref requestId, songCode, LyricType);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetSongSimpleInfo()
        {
            string requestId = ParamsHelper.CreateParam<string>();
            long songCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.GetSongSimpleInfo(ref requestId, songCode);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetInternalSongCode()
        {
            long songCode = ParamsHelper.CreateParam<long>();
            string jsonOption = ParamsHelper.CreateParam<string>();
            long internalSongCode = ParamsHelper.CreateParam<long>();

            var nRet = MusicContentCenter.GetInternalSongCode(songCode, jsonOption, ref internalSongCode);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IMusicContentCenter
    }
}
