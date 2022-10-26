using NUnit.Framework;
using Agora.Rtc;
namespace ut
{
    public class UnitTest_IAudioDeviceManager
    {
        public IRtcEngine Engine;
        public IAudioDeviceManager AudioDeviceManager;


        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine();
            AudioDeviceManager = Engine.GetAudioDeviceManager();
            Assert.AreEqual(AudioDeviceManager != null, true);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
        }


        #region custom
        [Test]
        public void Test_GetRecordingDefaultDevice()
        {
            string deviceId = "";
            string deviceName = "";
            var nRet = AudioDeviceManager.GetRecordingDefaultDevice(ref deviceId, ref deviceName);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlaybackDefaultDevice()
        {
            string deviceId = "";
            string deviceName = "";
            var nRet = AudioDeviceManager.GetPlaybackDefaultDevice(ref deviceId, ref deviceName);

            Assert.AreEqual(nRet, 0);
        }
        #endregion

        #region terr

        [Test]
        public void Test_EnumeratePlaybackDevices()
        {

            var nRet = AudioDeviceManager.EnumeratePlaybackDevices();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_EnumerateRecordingDevices()
        {

            var nRet = AudioDeviceManager.EnumerateRecordingDevices();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlaybackDevice()
        {
            string deviceId;
            ParamsHelper.InitParam(out deviceId);
            var nRet = AudioDeviceManager.SetPlaybackDevice(deviceId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlaybackDevice()
        {
            string deviceId;
            ParamsHelper.InitParam(out deviceId);
            var nRet = AudioDeviceManager.GetPlaybackDevice(ref deviceId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlaybackDeviceInfo()
        {
            string deviceId;
            ParamsHelper.InitParam(out deviceId);
            string deviceName;
            ParamsHelper.InitParam(out deviceName);
            var nRet = AudioDeviceManager.GetPlaybackDeviceInfo(ref deviceId, ref deviceName);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlaybackDeviceVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = AudioDeviceManager.SetPlaybackDeviceVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlaybackDeviceVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = AudioDeviceManager.GetPlaybackDeviceVolume(ref volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRecordingDevice()
        {
            string deviceId;
            ParamsHelper.InitParam(out deviceId);
            var nRet = AudioDeviceManager.SetRecordingDevice(deviceId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetRecordingDevice()
        {
            string deviceId;
            ParamsHelper.InitParam(out deviceId);
            var nRet = AudioDeviceManager.GetRecordingDevice(ref deviceId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetRecordingDeviceInfo()
        {
            string deviceId;
            ParamsHelper.InitParam(out deviceId);
            string deviceName;
            ParamsHelper.InitParam(out deviceName);
            var nRet = AudioDeviceManager.GetRecordingDeviceInfo(ref deviceId, ref deviceName);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRecordingDeviceVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = AudioDeviceManager.SetRecordingDeviceVolume(volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetRecordingDeviceVolume()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            var nRet = AudioDeviceManager.GetRecordingDeviceVolume(ref volume);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetLoopbackDevice()
        {
            string deviceId;
            ParamsHelper.InitParam(out deviceId);
            var nRet = AudioDeviceManager.SetLoopbackDevice(deviceId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetLoopbackDevice()
        {
            string deviceId;
            ParamsHelper.InitParam(out deviceId);
            var nRet = AudioDeviceManager.GetLoopbackDevice(ref deviceId);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetPlaybackDeviceMute()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = AudioDeviceManager.SetPlaybackDeviceMute(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetPlaybackDeviceMute()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = AudioDeviceManager.GetPlaybackDeviceMute(ref mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_SetRecordingDeviceMute()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = AudioDeviceManager.SetRecordingDeviceMute(mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_GetRecordingDeviceMute()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = AudioDeviceManager.GetRecordingDeviceMute(ref mute);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartPlaybackDeviceTest()
        {
            string testAudioFilePath;
            ParamsHelper.InitParam(out testAudioFilePath);
            var nRet = AudioDeviceManager.StartPlaybackDeviceTest(testAudioFilePath);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopPlaybackDeviceTest()
        {

            var nRet = AudioDeviceManager.StopPlaybackDeviceTest();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartRecordingDeviceTest()
        {
            int indicationInterval;
            ParamsHelper.InitParam(out indicationInterval);
            var nRet = AudioDeviceManager.StartRecordingDeviceTest(indicationInterval);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopRecordingDeviceTest()
        {

            var nRet = AudioDeviceManager.StopRecordingDeviceTest();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StartAudioDeviceLoopbackTest()
        {
            int indicationInterval;
            ParamsHelper.InitParam(out indicationInterval);
            var nRet = AudioDeviceManager.StartAudioDeviceLoopbackTest(indicationInterval);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_StopAudioDeviceLoopbackTest()
        {

            var nRet = AudioDeviceManager.StopAudioDeviceLoopbackTest();

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_FollowSystemPlaybackDevice()
        {
            bool enable;
            ParamsHelper.InitParam(out enable);
            var nRet = AudioDeviceManager.FollowSystemPlaybackDevice(enable);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_FollowSystemRecordingDevice()
        {
            bool enable;
            ParamsHelper.InitParam(out enable);
            var nRet = AudioDeviceManager.FollowSystemRecordingDevice(enable);

            Assert.AreEqual(nRet, 0);
        }

        [Test]
        public void Test_FollowSystemLoopbackDevice()
        {
            bool enable;
            ParamsHelper.InitParam(out enable);
            var nRet = AudioDeviceManager.FollowSystemLoopbackDevice(enable);

            Assert.AreEqual(nRet, 0);
        }



        #endregion
    }
}
