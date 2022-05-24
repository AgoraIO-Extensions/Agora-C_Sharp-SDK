namespace agora.rtc
{
    public sealed class AudioDeviceManager : IAudioDeviceManager
    {
        private static IAudioDeviceManager instance = null;
        private AudioDeviceManagerImpl _audioDeviecManagerImpl = null;

        private AudioDeviceManager(AudioDeviceManagerImpl impl)
        {
            _audioDeviecManagerImpl = impl;
        }

        internal static IAudioDeviceManager GetInstance(AudioDeviceManagerImpl impl)
        {
            return instance ?? (instance = new AudioDeviceManager(impl));
        }

        public override DeviceInfo[] EnumeratePlaybackDevices()
        {
            return _audioDeviecManagerImpl.EnumeratePlaybackDevices();
        }

        public override int SetPlaybackDevice(string deviceId)
        {
            return _audioDeviecManagerImpl.SetPlaybackDevice(deviceId);
        }

        public override string GetPlaybackDevice()
        {
            return _audioDeviecManagerImpl.GetPlaybackDevice();
        }

        public override DeviceInfo GetPlaybackDeviceInfo()
        {
            return _audioDeviecManagerImpl.GetPlaybackDeviceInfo();
        }

        public override int SetPlaybackDeviceVolume(int volume)
        {
            return _audioDeviecManagerImpl.SetPlaybackDeviceVolume(volume);
        }

        public override int GetPlaybackDeviceVolume()
        {
            return _audioDeviecManagerImpl.GetPlaybackDeviceVolume();
        }

        public override int SetPlaybackDeviceMute(bool mute)
        {
            return _audioDeviecManagerImpl.SetPlaybackDeviceMute(mute);
        }

        public override bool GetPlaybackDeviceMute()
        {
            return _audioDeviecManagerImpl.GetPlaybackDeviceMute();
        }

        public override int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            return _audioDeviecManagerImpl.StartPlaybackDeviceTest(testAudioFilePath);
        }

        public override int StopPlaybackDeviceTest()
        {
            return _audioDeviecManagerImpl.StopPlaybackDeviceTest();
        }

        public override DeviceInfo[] EnumerateRecordingDevices()
        {
            return _audioDeviecManagerImpl.EnumerateRecordingDevices();
        }

        public override int SetRecordingDevice(string deviceId)
        {
            return _audioDeviecManagerImpl.SetRecordingDevice(deviceId);
        }

        public override string GetRecordingDevice()
        {
            return _audioDeviecManagerImpl.GetRecordingDevice();
        }

        public override DeviceInfo GetRecordingDeviceInfo()
        {
            return _audioDeviecManagerImpl.GetRecordingDeviceInfo();
        }

        public override int SetRecordingDeviceVolume(int volume)
        {
            return _audioDeviecManagerImpl.SetRecordingDeviceVolume(volume);
        }

        public override int GetRecordingDeviceVolume()
        {
            return _audioDeviecManagerImpl.GetRecordingDeviceVolume();
        }

        public override int SetRecordingDeviceMute(bool mute)
        {
            return _audioDeviecManagerImpl.SetRecordingDeviceMute(mute);
        }

        public override bool GetRecordingDeviceMute()
        {
            return _audioDeviecManagerImpl.GetRecordingDeviceMute();
        }

        public override int StartRecordingDeviceTest(int indicationInterval)
        {
            return _audioDeviecManagerImpl.StartRecordingDeviceTest(indicationInterval);
        }

        public override int StopRecordingDeviceTest()
        {
            return _audioDeviecManagerImpl.StopRecordingDeviceTest();
        }

        public override int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            return _audioDeviecManagerImpl.StartAudioDeviceLoopbackTest(indicationInterval);
        }

        public override int StopAudioDeviceLoopbackTest()
        {
            return _audioDeviecManagerImpl.StopAudioDeviceLoopbackTest();
        }
    }
}