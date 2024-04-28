using System;
using Agora.Rtc.Ut;
using NUnit.Framework;
namespace Agora.Rtm.Ut
{
    public class UnitTest_IRtmStorage
    {
        public Internal.IRtmClient RtmClient;
        public Internal.IRtmStorage RtmStorage;

        [SetUp]
        public void Setup()
        {
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int errorCode = 0;
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Assert.AreEqual(0, errorCode);

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
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            Metadata data = ParamsHelper.CreateParam<Metadata>();
            MetadataOptions options = ParamsHelper.CreateParam<MetadataOptions>();
            string lockName = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.SetChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMetadata()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            Metadata data = ParamsHelper.CreateParam<Metadata>();
            MetadataOptions options = ParamsHelper.CreateParam<MetadataOptions>();
            string lockName = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.UpdateChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveChannelMetadata()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            Metadata data = ParamsHelper.CreateParam<Metadata>();
            MetadataOptions options = ParamsHelper.CreateParam<MetadataOptions>();
            string lockName = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.RemoveChannelMetadata(channelName, channelType, data, options, lockName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetChannelMetadata()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.GetChannelMetadata(channelName, channelType, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetUserMetadata()
        {
            string userId = ParamsHelper.CreateParam<string>();
            Metadata data = ParamsHelper.CreateParam<Metadata>();
            MetadataOptions options = ParamsHelper.CreateParam<MetadataOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.SetUserMetadata(userId, data, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateUserMetadata()
        {
            string userId = ParamsHelper.CreateParam<string>();
            Metadata data = ParamsHelper.CreateParam<Metadata>();
            MetadataOptions options = ParamsHelper.CreateParam<MetadataOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.UpdateUserMetadata(userId, data, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveUserMetadata()
        {
            string userId = ParamsHelper.CreateParam<string>();
            Metadata data = ParamsHelper.CreateParam<Metadata>();
            MetadataOptions options = ParamsHelper.CreateParam<MetadataOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.RemoveUserMetadata(userId, data, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserMetadata()
        {
            string userId = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.GetUserMetadata(userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SubscribeUserMetadata()
        {
            string userId = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.SubscribeUserMetadata(userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnsubscribeUserMetadata()
        {
            string userId = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmStorage.UnsubscribeUserMetadata(userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
