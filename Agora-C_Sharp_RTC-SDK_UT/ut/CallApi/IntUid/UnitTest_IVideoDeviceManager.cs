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

        [Test]
        public void Test_EnumerateVideoDevices()
        {

            var nRet = VideoDeviceManager.EnumerateVideoDevices();

            Assert.AreEqual(0, nRet.Length);
        }

        #region terra IVideoDeviceManager
        [Test]
        public void Test_SetDevice()
        {
            string deviceIdUTF8 = ParamsHelper.CreateParam<string>();

            var nRet = VideoDeviceManager.SetDevice(deviceIdUTF8);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetDevice()
        {
            string deviceIdUTF8 = ParamsHelper.CreateParam<string>();

            var nRet = VideoDeviceManager.GetDevice(ref deviceIdUTF8);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_NumberOfCapabilities()
        {
            string deviceIdUTF8 = ParamsHelper.CreateParam<string>();

            var nRet = VideoDeviceManager.NumberOfCapabilities(deviceIdUTF8);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetCapability()
        {
            string deviceIdUTF8 = ParamsHelper.CreateParam<string>();
            uint deviceCapabilityNumber = ParamsHelper.CreateParam<uint>();
            VideoFormat capability = ParamsHelper.CreateParam<VideoFormat>();

            var nRet = VideoDeviceManager.GetCapability(deviceIdUTF8, deviceCapabilityNumber, ref capability);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartDeviceTest()
        {
            IntPtr hwnd = ParamsHelper.CreateParam<IntPtr>();

            var nRet = VideoDeviceManager.StartDeviceTest(hwnd);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopDeviceTest()
        {


            var nRet = VideoDeviceManager.StopDeviceTest();
            Assert.AreEqual(0, nRet);
        }


        #endregion terra IVideoDeviceManager
    }
}
