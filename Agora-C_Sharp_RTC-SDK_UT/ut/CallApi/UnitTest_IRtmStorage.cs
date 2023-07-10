using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtm
{
    public class UnitTest_IRtmStorage
    {
        public Internal.IRtmClient RtmClient;
        public Internal.IRtmStorage RtmStorage;

        [SetUp]
        public void Setup()
        {
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int ret = RtmClient.Initialize(config);
            Assert.AreEqual(0, ret);

            RtmStorage = RtmClient.GetStorage();
        }

        [TearDown]
        public void TearDown()
        {
            RtmClient.Dispose();
        }

        #region terr


        [Test]
        public void Test_SetChannelMetadata()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            RtmMetadata data;
            ParamsHelper.InitParam(out data);
            MetadataOptions options;
            ParamsHelper.InitParam(out options);
            string lockName;
            ParamsHelper.InitParam(out lockName);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.SetChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMetadata()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            RtmMetadata data;
            ParamsHelper.InitParam(out data);
            MetadataOptions options;
            ParamsHelper.InitParam(out options);
            string lockName;
            ParamsHelper.InitParam(out lockName);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.UpdateChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveChannelMetadata()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            RtmMetadata data;
            ParamsHelper.InitParam(out data);
            MetadataOptions options;
            ParamsHelper.InitParam(out options);
            string lockName;
            ParamsHelper.InitParam(out lockName);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.RemoveChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetChannelMetadata()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            RTM_CHANNEL_TYPE channelType;
            ParamsHelper.InitParam(out channelType);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.GetChannelMetadata(channelName, channelType, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetUserMetadata()
        {
            string userId;
            ParamsHelper.InitParam(out userId);
            RtmMetadata data;
            ParamsHelper.InitParam(out data);
            MetadataOptions options;
            ParamsHelper.InitParam(out options);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.SetUserMetadata(userId, data, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateUserMetadata()
        {
            string userId;
            ParamsHelper.InitParam(out userId);
            RtmMetadata data;
            ParamsHelper.InitParam(out data);
            MetadataOptions options;
            ParamsHelper.InitParam(out options);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.UpdateUserMetadata(userId, data, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveUserMetadata()
        {
            string userId;
            ParamsHelper.InitParam(out userId);
            RtmMetadata data;
            ParamsHelper.InitParam(out data);
            MetadataOptions options;
            ParamsHelper.InitParam(out options);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.RemoveUserMetadata(userId, data, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserMetadata()
        {
            string userId;
            ParamsHelper.InitParam(out userId);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.GetUserMetadata(userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SubscribeUserMetadata()
        {
            string userId;
            ParamsHelper.InitParam(out userId);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmStorage.SubscribeUserMetadata(userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnsubscribeUserMetadata()
        {
            string userId;
            ParamsHelper.InitParam(out userId);
            var nRet = RtmStorage.UnsubscribeUserMetadata(userId);

            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
