using NUnit.Framework;
using Agora.Rtc.Ut;
namespace Agora.Rtm.Ut
{
    public class UnitTest_IRtmClient
    {
        public Internal.IRtmClient RtmClient;

        [SetUp]
        public void Setup()
        {
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int errorCode = 0;
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Assert.AreEqual(0, errorCode);
        }

        [TearDown]
        public void TearDown()
        {
            RtmClient.Dispose();
        }

        #region terra IRtmClient
        [Test]
        public void Test_Login()
        {
            string token = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmClient.Login(token, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Logout()
        {
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmClient.Logout(ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewToken()
        {
            string token = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmClient.RenewToken(token, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Publish()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            string message = ParamsHelper.CreateParam<string>();
            int length = ParamsHelper.CreateParam<int>();
            Internal.PublishOptions option = ParamsHelper.CreateParam<Internal.PublishOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmClient.Publish(channelName, message, length, option, ref requestId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Publish2()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            byte[] message = ParamsHelper.CreateParam<byte[]>();
            int length = ParamsHelper.CreateParam<int>();
            Internal.PublishOptions option = ParamsHelper.CreateParam<Internal.PublishOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmClient.Publish(channelName, message, length, option, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Subscribe()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            SubscribeOptions options = ParamsHelper.CreateParam<SubscribeOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmClient.Subscribe(channelName, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Unsubscribe()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmClient.Unsubscribe(channelName, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParameters()
        {
            string parameters = ParamsHelper.CreateParam<string>();
            var nRet = RtmClient.SetParameters(parameters);

            Assert.AreEqual(0, nRet);
        }

        #endregion terra IRtmClient


    }
}
