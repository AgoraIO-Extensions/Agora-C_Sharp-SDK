namespace agora.rtc
{
    public class IAudioDeviceManager
    {
        private static IAudioDeviceManager instance = null;
        private AudioDeviceManagerImpl _audioDeviecManagerImpl = null;

        private IAudioDeviceManager(AudioDeviceManagerImpl impl)
        {
            _audioDeviecManagerImpl = impl;
        }

        internal static IAudioDeviceManager GetInstance(AudioDeviceManagerImpl impl)
        {
            return instance ?? (instance = new IAudioDeviceManager(impl));
        }

        public DeviceInfo[] EnumeratePlaybackDevices()
        {
            return _audioDeviecManagerImpl.EnumeratePlaybackDevices();
        }

        public int SetPlaybackDevice(string deviceId)
        {
            return _audioDeviecManagerImpl.SetPlaybackDevice(deviceId);
        }

        public string GetPlaybackDevice()
        {
            return _audioDeviecManagerImpl.GetPlaybackDevice();
        }

        public DeviceInfo GetPlaybackDeviceInfo()
        {
            return _audioDeviecManagerImpl.GetPlaybackDeviceInfo();
        }

        public int SetPlaybackDeviceVolume(int volume)
        {
            return _audioDeviecManagerImpl.SetPlaybackDeviceVolume(volume);
        }

        public int GetPlaybackDeviceVolume()
        {
            return _audioDeviecManagerImpl.GetPlaybackDeviceVolume();
        }

        public int SetPlaybackDeviceMute(bool mute)
        {
            return _audioDeviecManagerImpl.SetPlaybackDeviceMute(mute);
        }

        public bool GetPlaybackDeviceMute()
        {
            return _audioDeviecManagerImpl.GetPlaybackDeviceMute();
        }

        public int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            return _audioDeviecManagerImpl.StartPlaybackDeviceTest(testAudioFilePath);
        }

        public int StopPlaybackDeviceTest()
        {
            return _audioDeviecManagerImpl.StopPlaybackDeviceTest();
        }

        public DeviceInfo[] EnumerateRecordingDevices()
        {
            return _audioDeviecManagerImpl.EnumerateRecordingDevices();
        }

        public int SetRecordingDevice(string deviceId)
        {
            return _audioDeviecManagerImpl.SetRecordingDevice(deviceId);
        }

        public string GetRecordingDevice()
        {
            return _audioDeviecManagerImpl.GetRecordingDevice();
        }

        public DeviceInfo GetRecordingDeviceInfo()
        {
            return _audioDeviecManagerImpl.GetRecordingDeviceInfo();
        }

        public int SetRecordingDeviceVolume(int volume)
        {
            return _audioDeviecManagerImpl.SetRecordingDeviceVolume(volume);
        }

        public int GetRecordingDeviceVolume()
        {
            return _audioDeviecManagerImpl.GetRecordingDeviceVolume();
        }

        public int SetRecordingDeviceMute(bool mute)
        {
            return _audioDeviecManagerImpl.SetRecordingDeviceMute(mute);
        }

        public bool GetRecordingDeviceMute()
        {
            return _audioDeviecManagerImpl.GetRecordingDeviceMute();
        }

        public int StartRecordingDeviceTest(int indicationInterval)
        {
            return _audioDeviecManagerImpl.StartRecordingDeviceTest(indicationInterval);
        }

        public int StopRecordingDeviceTest()
        {
            return _audioDeviecManagerImpl.StopRecordingDeviceTest();
        }

        public int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            return _audioDeviecManagerImpl.StartAudioDeviceLoopbackTest(indicationInterval);
        }

        public int StopAudioDeviceLoopbackTest()
        {
            return _audioDeviecManagerImpl.StopAudioDeviceLoopbackTest();
        }
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}