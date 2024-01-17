using System;
using NUnit.Framework;
using Agora.Rtc;
using Agora.Rtm;

namespace Agora.Rtc.Ut
{
    public class UnitTest_ParamHelper
    {
        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }


        [Test]
        public void Test_Create()
        {
            RtcEngineContext context = ParamsHelper.CreateParam<RtcEngineContext>();
            Metadata metadata = ParamsHelper.CreateParam<Metadata>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

        }

        [Test]
        public void Test_Compare()
        {
            var context1 = ParamsHelper.CreateParam<ChannelMediaOptions>();
            var context2 = ParamsHelper.CreateParam<ChannelMediaOptions>();
            context2.autoSubscribeVideo.SetEmpty();
            Assert.AreEqual(false, ParamsHelper.Compare<ChannelMediaOptions>(context1, context2));

        }

        [Test]
        public void Test_RtmEncryptionConfig()
        {
            RtmEncryptionConfig rtmEncryptionConfig = new RtmEncryptionConfig();
            var random = new Random();

            //length is 32
            var dest = new byte[32];
            for (int i = 0; i < dest.Length; i++)
            {
                dest[i] = (byte)random.Next(0, 127);
            }

            rtmEncryptionConfig.encryptionSalt = dest;
            var salt = rtmEncryptionConfig.encryptionSalt;
            for (int i = 0; i < salt.Length; i++)
            {
                Assert.AreEqual(salt[i], dest[i]);
            }

            // length < 32
            dest = new byte[random.Next(1, 31)];
            for (int i = 0; i < dest.Length; i++)
            {
                dest[i] = (byte)random.Next(0, 127);
            }
            rtmEncryptionConfig.encryptionSalt = dest;
            salt = rtmEncryptionConfig.encryptionSalt;
            for (int i = 0; i < dest.Length; i++)
            {
                Assert.AreEqual(salt[i], dest[i]);
            }

            for (int i = dest.Length; i < 32; i++)
            {
                Assert.AreEqual(0, salt[i]);
            }

            // length > 33
            dest = new byte[random.Next(33, 100)];
            for (int i = 0; i < dest.Length; i++)
            {
                dest[i] = (byte)random.Next(0, 127);
            }
            try
            {
                rtmEncryptionConfig.encryptionSalt = dest;
            }
            catch (RTMException e)
            {
                Assert.AreEqual((int)RTM_ERROR_CODE.INVALID_ENCRYPTION_PARAMETER, e.Status.ErrorCode);
            }
        }
    }
}