using System;
using Agora.Rtc;
using NUnit.Framework;
namespace ut
{
    public class UnitTest_IMediaPlayerCacheManager
    {
        public IRtcEngine Engine;
        public IMediaPlayerCacheManager MediaPlayerCacheManager;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MediaPlayerCacheManager = Engine.GetMediaPlayerCacheManager();
            Assert.AreEqual(MediaPlayerCacheManager != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

#region custom
        [Test]
        public void Test_GetCacheDir()
        {
            string path;
            ParamsHelper.InitParam(out path);
            int length;
            ParamsHelper.InitParam(out length);
            var nRet = MediaPlayerCacheManager.GetCacheDir(out path, length);

            Assert.AreEqual(0, nRet);
        }
#endregion

#region terr
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
            string uri;
            ParamsHelper.InitParam(out uri);
            var nRet = MediaPlayerCacheManager.RemoveCacheByUri(uri);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetCacheDir()
        {
            string path;
            ParamsHelper.InitParam(out path);
            var nRet = MediaPlayerCacheManager.SetCacheDir(path);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetMaxCacheFileCount()
        {
            int count;
            ParamsHelper.InitParam(out count);
            var nRet = MediaPlayerCacheManager.SetMaxCacheFileCount(count);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetMaxCacheFileSize()
        {
            long cacheSize;
            ParamsHelper.InitParam(out cacheSize);
            var nRet = MediaPlayerCacheManager.SetMaxCacheFileSize(cacheSize);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAutoRemoveCache()
        {
            bool enable;
            ParamsHelper.InitParam(out enable);
            var nRet = MediaPlayerCacheManager.EnableAutoRemoveCache(enable);

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

#endregion
    }
}
