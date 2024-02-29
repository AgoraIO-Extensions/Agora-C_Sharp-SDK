using NUnit.Framework;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public class UnitTest_IAudioDeviceManager
    {
        public IRtcEngine Engine;
        public IAudioDeviceManager AudioDeviceManager;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            AudioDeviceManager = Engine.GetAudioDeviceManager();
            Assert.AreEqual(AudioDeviceManager != null, true);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        [Test]
        public void Test_GetRecordingDefaultDevice()
        {
            string deviceId = "";
            string deviceName = "";
            var nRet = AudioDeviceManager.GetRecordingDefaultDevice(ref deviceId, ref deviceName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlaybackDefaultDevice()
        {
            string deviceId = "";
            string deviceName = "";
            var nRet = AudioDeviceManager.GetPlaybackDefaultDevice(ref deviceId, ref deviceName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnumeratePlaybackDevices()
        {

            var nRet = AudioDeviceManager.EnumeratePlaybackDevices();

            Assert.AreEqual(0, nRet.Length);
        }

        [Test]
        public void Test_EnumerateRecordingDevices()
        {

            var nRet = AudioDeviceManager.EnumerateRecordingDevices();

            Assert.AreEqual(0, nRet.Length);
        }

        #region terra IAudioDeviceManager
        [Test]
        public void Test_SetPlaybackDevice()
        {
            string deviceId = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.SetPlaybackDevice(deviceId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlaybackDevice()
        {
            string deviceId = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.GetPlaybackDevice(ref deviceId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlaybackDeviceInfo()
        {
            string deviceId = ParamsHelper.CreateParam<string>();
            string deviceName = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.GetPlaybackDeviceInfo(ref deviceId, ref deviceName);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlaybackDeviceVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = AudioDeviceManager.SetPlaybackDeviceVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlaybackDeviceVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = AudioDeviceManager.GetPlaybackDeviceVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRecordingDevice()
        {
            string deviceId = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.SetRecordingDevice(deviceId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetRecordingDevice()
        {
            string deviceId = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.GetRecordingDevice(ref deviceId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetRecordingDeviceInfo()
        {
            string deviceId = ParamsHelper.CreateParam<string>();
            string deviceName = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.GetRecordingDeviceInfo(ref deviceId, ref deviceName);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRecordingDeviceVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = AudioDeviceManager.SetRecordingDeviceVolume(volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetRecordingDeviceVolume()
        {
            int volume = ParamsHelper.CreateParam<int>();

            var nRet = AudioDeviceManager.GetRecordingDeviceVolume(ref volume);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetLoopbackDevice()
        {
            string deviceId = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.SetLoopbackDevice(deviceId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetLoopbackDevice()
        {
            string deviceId = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.GetLoopbackDevice(ref deviceId);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlaybackDeviceMute()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = AudioDeviceManager.SetPlaybackDeviceMute(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetPlaybackDeviceMute()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = AudioDeviceManager.GetPlaybackDeviceMute(ref mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRecordingDeviceMute()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = AudioDeviceManager.SetRecordingDeviceMute(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetRecordingDeviceMute()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = AudioDeviceManager.GetRecordingDeviceMute(ref mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartPlaybackDeviceTest()
        {
            string testAudioFilePath = ParamsHelper.CreateParam<string>();

            var nRet = AudioDeviceManager.StartPlaybackDeviceTest(testAudioFilePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopPlaybackDeviceTest()
        {


            var nRet = AudioDeviceManager.StopPlaybackDeviceTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRecordingDeviceTest()
        {
            int indicationInterval = ParamsHelper.CreateParam<int>();

            var nRet = AudioDeviceManager.StartRecordingDeviceTest(indicationInterval);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRecordingDeviceTest()
        {


            var nRet = AudioDeviceManager.StopRecordingDeviceTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartAudioDeviceLoopbackTest()
        {
            int indicationInterval = ParamsHelper.CreateParam<int>();

            var nRet = AudioDeviceManager.StartAudioDeviceLoopbackTest(indicationInterval);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopAudioDeviceLoopbackTest()
        {


            var nRet = AudioDeviceManager.StopAudioDeviceLoopbackTest();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_FollowSystemPlaybackDevice()
        {
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = AudioDeviceManager.FollowSystemPlaybackDevice(enable);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_FollowSystemRecordingDevice()
        {
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = AudioDeviceManager.FollowSystemRecordingDevice(enable);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_FollowSystemLoopbackDevice()
        {
            bool enable = ParamsHelper.CreateParam<bool>();

            var nRet = AudioDeviceManager.FollowSystemLoopbackDevice(enable);
            Assert.AreEqual(0, nRet);
        }


        #endregion terra IAudioDeviceManager
    }
}
