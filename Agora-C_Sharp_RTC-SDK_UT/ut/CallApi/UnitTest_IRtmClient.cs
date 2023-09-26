﻿using NUnit.Framework;
using Agora.Rtc;
namespace Agora.Rtm
{
    public class UnitTest_IRtmClient
    {
        public Internal.IRtmClient RtmClient;

        [SetUp]
        public void Setup()
        {
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);

            int ret = RtmClient.Initialize(config);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            RtmClient.Dispose();
        }

        #region terr
        [Test]
        public void Test_Login()
        {
            string token;
            ParamsHelper.InitParam(out token);
            var nRet = RtmClient.Login(token);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Logout()
        {

            var nRet = RtmClient.Logout();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RenewToken()
        {
            string token;
            ParamsHelper.InitParam(out token);
            var nRet = RtmClient.RenewToken(token);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Publish()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            string message;
            ParamsHelper.InitParam(out message);
            int length;
            ParamsHelper.InitParam(out length);
            Internal.PublishOptions option;
            ParamsHelper.InitParam(out option);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmClient.Publish(channelName, message, length, option, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Publish2()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            byte[] message;
            ParamsHelper.InitParam(out message);
            int length;
            ParamsHelper.InitParam(out length);
            Internal.PublishOptions option;
            ParamsHelper.InitParam(out option);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmClient.Publish(channelName, message, length, option, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Subscribe()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            SubscribeOptions options;
            ParamsHelper.InitParam(out options);
            ulong requestId;
            ParamsHelper.InitParam(out requestId);
            var nRet = RtmClient.Subscribe(channelName, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_Unsubscribe()
        {
            string channelName;
            ParamsHelper.InitParam(out channelName);
            var nRet = RtmClient.Unsubscribe(channelName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParameters()
        {
            string parameters;
            ParamsHelper.InitParam(out parameters);
            var nRet = RtmClient.SetParameters(parameters);

            Assert.AreEqual(0, nRet);
        }

        #endregion


    }
}
