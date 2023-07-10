using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtm
{
    public class UnitTest_IRtmPresence
    {
        public Internal.IRtmClient RtmClient;
        public Internal.IRtmPresence RtmPresence;

        [SetUp]
        public void Setup()
        {
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int ret = RtmClient.Initialize(config);
            Assert.AreEqual(0, ret);

            RtmPresence = RtmClient.GetPresence();
        }

        [TearDown]
        public void TearDown()
        {
            RtmClient.Dispose();
        }

        #region terr
        [Test]
        public void Test_WhoNow()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            PresenceOptions options;
            ParamsHelper.InitParam(out options);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmPresence.WhoNow(channelName, channelType, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_WhereNow()
        {
            string userId;
            ParamsHelper.InitParam(out userId);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmPresence.WhereNow(userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetState()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            StateItem[] items;
            ParamsHelper.InitParam(out items);
            int count;
            ParamsHelper.InitParam(out count);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmPresence.SetState(channelName, channelType, items, count, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveState()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            string[] keys;
            ParamsHelper.InitParam(out keys);
            int count;
            ParamsHelper.InitParam(out count);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmPresence.RemoveState(channelName, channelType, keys, count, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetState()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            string userId;
            ParamsHelper.InitParam(out userId);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmPresence.GetState(channelName, channelType, userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
