namespace Agora.Rtc
{
    /* class_iaudiodevicemanager */
    public abstract class IAudioDeviceManager
    {
        /* api_iaudiodevicemanager_enumerateplaybackdevices */
        public abstract DeviceInfo[] EnumeratePlaybackDevices();

        /* api_iaudiodevicemanager_enumeraterecordingdevices */
        public abstract DeviceInfo[] EnumerateRecordingDevices();

        /* api_iaudiodevicemanager_getplaybackdefaultdevice */
        public abstract int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceName);

        /* api_iaudiodevicemanager_getrecordingdefaultdevice */
        public abstract int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName);

#region terra IAudioDeviceManager

        /* api_iaudiodevicemanager_setplaybackdevice */
        public abstract int SetPlaybackDevice(string deviceId);

        /* api_iaudiodevicemanager_getplaybackdevice */
        public abstract int GetPlaybackDevice(ref string deviceId);

        /* api_iaudiodevicemanager_getplaybackdeviceinfo */
        public abstract int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName);

        /* api_iaudiodevicemanager_setplaybackdevicevolume */
        public abstract int SetPlaybackDeviceVolume(int volume);

        /* api_iaudiodevicemanager_getplaybackdevicevolume */
        public abstract int GetPlaybackDeviceVolume(ref int volume);

        /* api_iaudiodevicemanager_setrecordingdevice */
        public abstract int SetRecordingDevice(string deviceId);

        /* api_iaudiodevicemanager_getrecordingdevice */
        public abstract int GetRecordingDevice(ref string deviceId);

        /* api_iaudiodevicemanager_getrecordingdeviceinfo */
        public abstract int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName);

        /* api_iaudiodevicemanager_setrecordingdevicevolume */
        public abstract int SetRecordingDeviceVolume(int volume);

        /* api_iaudiodevicemanager_getrecordingdevicevolume */
        public abstract int GetRecordingDeviceVolume(ref int volume);

        /* api_iaudiodevicemanager_setloopbackdevice */
        public abstract int SetLoopbackDevice(string deviceId);

        /* api_iaudiodevicemanager_getloopbackdevice */
        public abstract int GetLoopbackDevice(ref string deviceId);

        /* api_iaudiodevicemanager_setplaybackdevicemute */
        public abstract int SetPlaybackDeviceMute(bool mute);

        /* api_iaudiodevicemanager_getplaybackdevicemute */
        public abstract int GetPlaybackDeviceMute(ref bool mute);

        /* api_iaudiodevicemanager_setrecordingdevicemute */
        public abstract int SetRecordingDeviceMute(bool mute);

        /* api_iaudiodevicemanager_getrecordingdevicemute */
        public abstract int GetRecordingDeviceMute(ref bool mute);

        /* api_iaudiodevicemanager_startplaybackdevicetest */
        public abstract int StartPlaybackDeviceTest(string testAudioFilePath);

        /* api_iaudiodevicemanager_stopplaybackdevicetest */
        public abstract int StopPlaybackDeviceTest();

        /* api_iaudiodevicemanager_startrecordingdevicetest */
        public abstract int StartRecordingDeviceTest(int indicationInterval);

        /* api_iaudiodevicemanager_stoprecordingdevicetest */
        public abstract int StopRecordingDeviceTest();

        /* api_iaudiodevicemanager_startaudiodeviceloopbacktest */
        public abstract int StartAudioDeviceLoopbackTest(int indicationInterval);

        /* api_iaudiodevicemanager_stopaudiodeviceloopbacktest */
        public abstract int StopAudioDeviceLoopbackTest();

        /* api_iaudiodevicemanager_followsystemplaybackdevice */
        public abstract int FollowSystemPlaybackDevice(bool enable);

        /* api_iaudiodevicemanager_followsystemrecordingdevice */
        public abstract int FollowSystemRecordingDevice(bool enable);

        /* api_iaudiodevicemanager_followsystemloopbackdevice */
        public abstract int FollowSystemLoopbackDevice(bool enable);

#endregion terra IAudioDeviceManager
    }
}