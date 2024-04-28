using System;
using Agora.Rtc.Ut;
using NUnit.Framework;
namespace Agora.Rtm.Ut
{
    public class UnitTest_IStreamChannel
    {
        public Internal.IRtmClient RtmClient;
        public Internal.IStreamChannel StreamChannel;

        [SetUp]
        public void Setup()
        {
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int errorCode = 0;
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Assert.AreEqual(0, errorCode);

            errorCode = 0;
            StreamChannel = RtmClient.CreateStreamChannel("test", ref errorCode);
            Assert.AreEqual(0, errorCode);
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
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.RenewToken(token, ref requestId);

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
            Internal.TopicMessageOptions option = ParamsHelper.CreateParam<Internal.TopicMessageOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.PublishTopicMessage(topic, message, length, option, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PublishTopicMessage2()
        {
            string topic = ParamsHelper.CreateParam<string>();
            byte[] message = ParamsHelper.CreateParam<byte[]>();
            int length = ParamsHelper.CreateParam<int>();
            Internal.TopicMessageOptions option = ParamsHelper.CreateParam<Internal.TopicMessageOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.PublishTopicMessage(topic, message, length, option, ref requestId);

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
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.UnsubscribeTopic(topic, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetSubscribedUserList()
        {
            string topic = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = StreamChannel.GetSubscribedUserList(topic, ref requestId);

            Assert.AreEqual(0, nRet);
        }



        #endregion
    }
}
