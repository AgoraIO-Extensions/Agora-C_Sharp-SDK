using NUnit.Framework;
using Agora.Rtc;
using System;
namespace Agora.Rtc
{
    public class UnitTest_IVideoDeviceManager
    {
        public IRtcEngine Engine;
        public IVideoDeviceManager VideoDeviceManager;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            VideoDeviceManager = Engine.GetVideoDeviceManager();
            Assert.AreEqual(VideoDeviceManager != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

#region

        [Test]
        public void Test_GetCapability()
        {
            string deviceIdUTF8;
            ParamsHelper.InitParam(out deviceIdUTF8);
            uint deviceCapabilityNumber;
            ParamsHelper.InitParam(out deviceCapabilityNumber);
            VideoFormat capability;
            ParamsHelper.InitParam(out capability);
            var nRet = VideoDeviceManager.GetCapability(deviceIdUTF8, deviceCapabilityNumber, out capability);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnumerateVideoDevices()
        {

            var nRet = VideoDeviceManager.EnumerateVideoDevices();

            Assert.AreEqual(0, nRet.Length);
        }
#endregion

#region terr
        [Test]
        public void Test_SetDevice()
        {
            string deviceIdUTF8;
            ParamsHelper.InitParam(out deviceIdUTF8);
            var nRet = VideoDeviceManager.SetDevice(deviceIdUTF8);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetDevice()
        {
            string deviceIdUTF8;
            ParamsHelper.InitParam(out deviceIdUTF8);
            var nRet = VideoDeviceManager.GetDevice(ref deviceIdUTF8);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_NumberOfCapabilities()
        {
            string deviceIdUTF8;
            ParamsHelper.InitParam(out deviceIdUTF8);
            var nRet = VideoDeviceManager.NumberOfCapabilities(deviceIdUTF8);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartDeviceTest()
        {
            IntPtr hwnd;
            ParamsHelper.InitParam(out hwnd);
            var nRet = VideoDeviceManager.StartDeviceTest(hwnd);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopDeviceTest()
        {

            var nRet = VideoDeviceManager.StopDeviceTest();

            Assert.AreEqual(0, nRet);
        }

#endregion
    }
}
