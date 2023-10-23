using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtm
{
    public class UnitTest_IStreamChannel
    {
        public Internal.IRtmClient RtmClient;
        public Internal.IStreamChannel StreamChannel;

        [SetUp]
        public void Setup()
        {
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int ret = RtmClient.Initialize(config);
            Assert.AreEqual(0, ret);

            StreamChannel = RtmClient.CreateStreamChannel("test");
        }

        [TearDown]
        public void TearDown()
        {
            RtmClient.Dispose();
        }


        #region terr
        [Test]
        public void Test_Join()
        {
            JoinChannelOptions options = ParamsHelper.CreateParam<JoinChannelOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.Join(options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewToken()
        {
            string token = ParamsHelper.CreateParam<string>();
            var nRet = StreamChannel.RenewToken(token);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Leave()
        {
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.Leave(ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetChannelName()
        {

            var nRet = StreamChannel.GetChannelName();

            Assert.AreEqual("test", nRet);
        }

        [Test]
        public void Test_JoinTopic()
        {
            string topic = ParamsHelper.CreateParam<string>();
            JoinTopicOptions options = ParamsHelper.CreateParam<JoinTopicOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.JoinTopic(topic, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PublishTopicMessage()
        {
            string topic = ParamsHelper.CreateParam<string>();
            string message = ParamsHelper.CreateParam<string>();
            int length = ParamsHelper.CreateParam<int>();
            Internal.PublishOptions option = ParamsHelper.CreateParam<Internal.PublishOptions>();

            var nRet = StreamChannel.PublishTopicMessage(topic, message, length, option);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PublishTopicMessage2()
        {
            string topic = ParamsHelper.CreateParam<string>();
            byte[] message = ParamsHelper.CreateParam<byte[]>();
            int length = ParamsHelper.CreateParam<int>();
            Internal.PublishOptions option = ParamsHelper.CreateParam<Internal.PublishOptions>();
            var nRet = StreamChannel.PublishTopicMessage(topic, message, length, option);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveTopic()
        {
            string topic = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.LeaveTopic(topic, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SubscribeTopic()
        {
            string topic = ParamsHelper.CreateParam<string>();
            Internal.TopicOptions options = ParamsHelper.CreateParam<Internal.TopicOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.SubscribeTopic(topic, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnsubscribeTopic()
        {
            string topic = ParamsHelper.CreateParam<string>();
            Internal.TopicOptions options = ParamsHelper.CreateParam<Internal.TopicOptions>();
            var nRet = StreamChannel.UnsubscribeTopic(topic, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetSubscribedUserList()
        {
            string topic = ParamsHelper.CreateParam<string>();
            Internal.UserList users = ParamsHelper.CreateParam<Internal.UserList>();
            var nRet = StreamChannel.GetSubscribedUserList(topic, ref users);

            Assert.AreEqual(0, nRet);
        }



        #endregion
    }
}
