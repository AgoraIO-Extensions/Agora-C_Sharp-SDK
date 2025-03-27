using NUnit.Framework;
using Agora.Rtc;
using System;
namespace Agora.Rtc.Ut
{
    using uid_t = System.UInt32;
    using view_t = System.UInt64;
    [TestFixture]
    public partial class UnitTest_IRtcEngine
    {
        public IRtcEngine @interface;
        public IRtcEngine MediaEngine;
        public IRtcEngine MediaEngineBase;
        [SetUp]
        public void Setup()
        {
            @interface = Rtc.RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            MediaEngine = @interface;
            MediaEngineBase = MediaEngine;
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = @interface.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { @interface.Dispose(); }

        [Test]
        public void Test_SetParameters1()
        {
            string parameters = ParamsHelper.CreateParam<string>();
            var nRet = @interface.SetParameters(parameters);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParameters2()
        {
            string key = ParamsHelper.CreateParam<string>();
            string value = ParamsHelper.CreateParam<string>();
            var nRet = @interface.SetParameters(key, value);
            Assert.AreEqual(0, nRet);

            float value2 = ParamsHelper.CreateParam<float>();
            nRet = @interface.SetParameters(key, value2);
            Assert.AreEqual(0, nRet);

            bool value3 = ParamsHelper.CreateParam<bool>();
            nRet = @interface.SetParameters(key, value3);
            Assert.AreEqual(0, nRet);

            int value4 = ParamsHelper.CreateParam<int>();
            nRet = @interface.SetParameters(key, value4);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartScreenCapture_270da41()
        {
            ScreenCaptureParameters2 captureParams = ParamsHelper.CreateParam<ScreenCaptureParameters2>();

            var nRet = @interface.StartScreenCapture(captureParams);
            Assert.AreEqual(-4, nRet);
        }

        [Test]
        public void Test_StartScreenCapture_9ebb320()
        {
            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            ScreenCaptureConfiguration config = ParamsHelper.CreateParam<ScreenCaptureConfiguration>();

            var nRet = @interface.StartScreenCapture(sourceType, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLogFile_3a2037f()
        {
            string filePath = "/Users/xiayangqun/Documents/agoraSpace/ut2.log";

            var nRet = @interface.SetLogFile(filePath);
            Assert.AreEqual(0, nRet);
        }
    }

}