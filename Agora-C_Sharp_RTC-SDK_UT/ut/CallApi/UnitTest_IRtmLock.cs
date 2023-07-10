using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtm
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
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            string lockName;
            ParamsHelper.InitParam(out lockName);
            int ttl;
            ParamsHelper.InitParam(out ttl);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmLock.SetLock(channelName, channelType, lockName, ttl, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetLocks()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmLock.GetLocks(channelName, channelType,ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveLock()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            string lockName;
            ParamsHelper.InitParam(out lockName);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmLock.RemoveLock(channelName, channelType, lockName,ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AcquireLock()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            string lockName;
            ParamsHelper.InitParam(out lockName);
            bool retry;
            ParamsHelper.InitParam(out retry);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmLock.AcquireLock(channelName, channelType, lockName, retry,ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ReleaseLock()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            string lockName;
            ParamsHelper.InitParam(out lockName);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmLock.ReleaseLock(channelName, channelType, lockName,ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RevokeLock()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            string lockName;
            ParamsHelper.InitParam(out lockName);
            string owner;
            ParamsHelper.InitParam(out owner);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmLock.RevokeLock(channelName, channelType, lockName, owner,ref requestId);

            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
