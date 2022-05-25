namespace agora.rtc
{
    public abstract class IAudioDeviceManager
    {
        public abstract DeviceInfo[] EnumeratePlaybackDevices();

        public abstract int SetPlaybackDevice(string deviceId);

        public abstract string GetPlaybackDevice();

        public abstract DeviceInfo GetPlaybackDeviceInfo();

        public abstract int SetPlaybackDeviceVolume(int volume);

        public abstract int GetPlaybackDeviceVolume();

        public abstract int SetPlaybackDeviceMute(bool mute);

        public abstract bool GetPlaybackDeviceMute();

        public abstract int StartPlaybackDeviceTest(string testAudioFilePath);

        public abstract int StopPlaybackDeviceTest();

        public abstract DeviceInfo[] EnumerateRecordingDevices();

        public abstract int SetRecordingDevice(string deviceId);

        public abstract string GetRecordingDevice();

        public abstract DeviceInfo GetRecordingDeviceInfo();

        public abstract int SetRecordingDeviceVolume(int volume);

        public abstract int GetRecordingDeviceVolume();

        public abstract int SetRecordingDeviceMute(bool mute);

        public abstract bool GetRecordingDeviceMute();

        public abstract int StartRecordingDeviceTest(int indicationInterval);

        public abstract int StopRecordingDeviceTest();

        public abstract int StartAudioDeviceLoopbackTest(int indicationInterval);

        public abstract int StopAudioDeviceLoopbackTest();
    }
}