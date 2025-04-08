using NUnit.Framework;
using Agora.Rtc;
using System;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IVideoDeviceManager
    {
        public IRtcEngine Engine;
        public IVideoDeviceManager @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.GetVideoDeviceManager();
            Assert.AreEqual(@interface != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        [Test]
        public void Test_EnumerateVideoDevices()
        {

            var nRet = @interface.EnumerateVideoDevices();

            Assert.AreEqual(0, nRet.Length);
        }

    }
}
