using NUnit.Framework;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IAudioDeviceManager
    {
        public IRtcEngine Engine;
        public IAudioDeviceManager @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.GetAudioDeviceManager();
            Assert.AreEqual(@interface != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        [Test]
        public void Test_GetRecordingDefaultDevice()
        {
            string deviceId = "";
            string deviceName = "";
            var nRet = @interface.GetRecordingDefaultDevice(ref deviceId, ref deviceName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetRecordingDefaultDevice2()
        {
            string deviceId = "";
            string deviceTypeName = "";
            string deviceName = "";
            var nRet = @interface.GetRecordingDefaultDevice(ref deviceId, ref deviceTypeName, ref deviceName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlaybackDefaultDevice()
        {
            string deviceId = "";
            string deviceName = "";
            var nRet = @interface.GetPlaybackDefaultDevice(ref deviceId, ref deviceName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlaybackDefaultDevice2()
        {
            string deviceId = "";
            string deviceTypeName = "";
            string deviceName = "";
            var nRet = @interface.GetPlaybackDefaultDevice(ref deviceId, ref deviceTypeName, ref deviceName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnumeratePlaybackDevices()
        {

            var nRet = @interface.EnumeratePlaybackDevices();

            Assert.AreEqual(0, nRet.Length);
        }

        [Test]
        public void Test_EnumerateRecordingDevices()
        {

            var nRet = @interface.EnumerateRecordingDevices();

            Assert.AreEqual(0, nRet.Length);
        }
    }
}
