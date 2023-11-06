namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Audio device management methods.
    /// </summary>
    ///
    public abstract class IAudioDeviceManager
    {
        ///
        /// <summary>
        /// Enumerates the audio playback devices.
        /// 
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <returns>
        /// Success: Returns a DeviceInfo array, which includes the device ID and device name of all the audio playback devices.
        /// Failure: NULL.
        /// </returns>
        ///
        public abstract DeviceInfo[] EnumeratePlaybackDevices();

        ///
        /// <summary>
        /// Enumerates the audio capture devices.
        /// 
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <returns>
        /// Success: A DeviceInfo array, which includes the device ID and device name of all the audio capture devices.
        /// Failure: NULL.
        /// </returns>
        ///
        public abstract DeviceInfo[] EnumerateRecordingDevices();

        ///
        /// <summary>
        /// Gets the default audio playback device.
        /// 
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter, the device ID of the default audio playback device. </param>
        ///
        /// <param name="deviceName"> Output parameter, the device name of the default audio playback device. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceName);

        ///
        /// <summary>
        /// Gets the default audio capture device.
        /// 
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter, the device ID of the default audio capture device. </param>
        ///
        /// <param name="deviceName"> Output parameter, the device name of the default audio capture device. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName);

        #region terra IAudioDeviceManager

        public abstract int SetPlaybackDevice(string deviceId);


        public abstract int GetPlaybackDevice(ref string deviceId);


        public abstract int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName);


        public abstract int SetPlaybackDeviceVolume(int volume);


        public abstract int GetPlaybackDeviceVolume(ref int volume);


        public abstract int SetRecordingDevice(string deviceId);


        public abstract int GetRecordingDevice(ref string deviceId);


        public abstract int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName);


        public abstract int SetRecordingDeviceVolume(int volume);


        public abstract int GetRecordingDeviceVolume(ref int volume);


        public abstract int SetLoopbackDevice(string deviceId);


        public abstract int GetLoopbackDevice(ref string deviceId);


        public abstract int SetPlaybackDeviceMute(bool mute);


        public abstract int GetPlaybackDeviceMute(ref bool mute);


        public abstract int SetRecordingDeviceMute(bool mute);


        public abstract int GetRecordingDeviceMute(ref bool mute);


        public abstract int StartPlaybackDeviceTest(string testAudioFilePath);


        public abstract int StopPlaybackDeviceTest();


        public abstract int StartRecordingDeviceTest(int indicationInterval);


        public abstract int StopRecordingDeviceTest();


        public abstract int StartAudioDeviceLoopbackTest(int indicationInterval);


        public abstract int StopAudioDeviceLoopbackTest();


        public abstract int FollowSystemPlaybackDevice(bool enable);


        public abstract int FollowSystemRecordingDevice(bool enable);


        public abstract int FollowSystemLoopbackDevice(bool enable);


        #endregion terra IAudioDeviceManager
    }
}