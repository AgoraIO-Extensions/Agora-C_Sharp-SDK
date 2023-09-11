using System;
using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc
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
    }
}