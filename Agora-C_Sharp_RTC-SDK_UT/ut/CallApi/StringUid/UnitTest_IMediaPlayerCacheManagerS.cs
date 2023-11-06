using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtc
{
    public class UnitTest_IMediaPlayerCacheManagerS
    {
        public IRtcEngineS Engine;
        public IMediaPlayerCacheManager MediaPlayerCacheManager;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngineS.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngineS());
            RtcEngineContextS rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MediaPlayerCacheManager = Engine.GetMediaPlayerCacheManager();
            Assert.AreEqual(MediaPlayerCacheManager != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        #region terra IMediaPlayerCacheManager

        [Test]
        public void Test_RemoveAllCaches()
        {


            var nRet = MediaPlayerCacheManager.RemoveAllCaches();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveOldCache()
        {


            var nRet = MediaPlayerCacheManager.RemoveOldCache();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveCacheByUri()
        {
            string uri = ParamsHelper.CreateParam<string>();

            var nRet = MediaPlayerCacheManager.RemoveCacheByUri(uri);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCacheDir()
        {
            string path = ParamsHelper.CreateParam<string>();

            var nRet = MediaPlayerCacheManager.SetCacheDir(path);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetMaxCacheFileCount()
        {
            int count = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayerCacheManager.SetMaxCacheFileCount(count);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetMaxCacheFileSize()
        {
            long cacheSize = ParamsHelper.CreateParam<long>();

            var nRet = MediaPlayerCacheManager.SetMaxCacheFileSize(cacheSize);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAutoRemoveCache()
        {
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = MediaPlayerCacheManager.EnableAutoRemoveCache(enable);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCacheDir()
        {
            string path = ParamsHelper.CreateParam<string>();
            int length = ParamsHelper.CreateParam<int>();

            var nRet = MediaPlayerCacheManager.GetCacheDir(ref path, length);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetMaxCacheFileCount()
        {


            var nRet = MediaPlayerCacheManager.GetMaxCacheFileCount();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetMaxCacheFileSize()
        {


            var nRet = MediaPlayerCacheManager.GetMaxCacheFileSize();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCacheFileCount()
        {


            var nRet = MediaPlayerCacheManager.GetCacheFileCount();
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IMediaPlayerCacheManager
    }
}
