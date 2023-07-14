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
            JoinChannelOptions options;
            ParamsHelper.InitParam(out options);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = StreamChannel.Join(options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewToken()
        {
            string token;
            ParamsHelper.InitParam(out token);
            var nRet = StreamChannel.RenewToken(token);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Leave()
        {
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
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
            string topic;
            ParamsHelper.InitParam(out topic);
            JoinTopicOptions options;
            ParamsHelper.InitParam(out options);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = StreamChannel.JoinTopic(topic, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PublishTopicMessage()
        {
            string topic;
            ParamsHelper.InitParam(out topic);
            string message;
            ParamsHelper.InitParam(out message);
            int length;
            ParamsHelper.InitParam(out length);
            Internal.PublishOptions option;
            ParamsHelper.InitParam(out option);
            var nRet = StreamChannel.PublishTopicMessage(topic, message, length, option);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PublishTopicMessage2()
        {
            string topic;
            ParamsHelper.InitParam(out topic);
            byte[] message;
            ParamsHelper.InitParam(out message);
            int length;
            ParamsHelper.InitParam(out length);
            Internal.PublishOptions option;
            ParamsHelper.InitParam(out option);
            var nRet = StreamChannel.PublishTopicMessage(topic, message, length, option);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveTopic()
        {
            string topic;
            ParamsHelper.InitParam(out topic);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = StreamChannel.LeaveTopic(topic, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SubscribeTopic()
        {
            string topic;
            ParamsHelper.InitParam(out topic);
            TopicOptions options;
            ParamsHelper.InitParam(out options);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = StreamChannel.SubscribeTopic(topic, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UnsubscribeTopic()
        {
            string topic;
            ParamsHelper.InitParam(out topic);
            TopicOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = StreamChannel.UnsubscribeTopic(topic, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetSubscribedUserList()
       {
            string topic;
            ParamsHelper.InitParam(out topic);
            UserList users;
            ParamsHelper.InitParam(out users);
            var nRet = StreamChannel.GetSubscribedUserList(topic, ref users);

            Assert.AreEqual(0, nRet);
        }



        #endregion
    }
}
