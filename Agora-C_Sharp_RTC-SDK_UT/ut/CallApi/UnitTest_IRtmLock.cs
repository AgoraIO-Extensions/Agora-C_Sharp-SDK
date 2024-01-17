using System;
using Agora.Rtc.Ut;
using NUnit.Framework;
namespace Agora.Rtm.Ut
{
    public class UnitTest_IRtmLock
    {
        public Internal.IRtmClient RtmClient;
        public Internal.IRtmLock RtmLock;

        [SetUp]
        public void Setup()
        {
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int ret = RtmClient.Initialize(config);
            Assert.AreEqual(0, ret);

            RtmLock = RtmClient.GetLock();
        }

        [TearDown]
        public void TearDown()
        {
            RtmClient.Dispose();
        }

        #region terr
        [Test]
        public void Test_SetLock()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            string lockName = ParamsHelper.CreateParam<string>();
            int ttl = ParamsHelper.CreateParam<int>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmLock.SetLock(channelName, channelType, lockName, ttl, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetLocks()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmLock.GetLocks(channelName, channelType, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveLock()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            string lockName = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmLock.RemoveLock(channelName, channelType, lockName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AcquireLock()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            string lockName = ParamsHelper.CreateParam<string>();
            bool retry = ParamsHelper.CreateParam<bool>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmLock.AcquireLock(channelName, channelType, lockName, retry, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ReleaseLock()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            string lockName = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmLock.ReleaseLock(channelName, channelType, lockName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RevokeLock()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            string lockName = ParamsHelper.CreateParam<string>();
            string owner = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmLock.RevokeLock(channelName, channelType, lockName, owner, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
