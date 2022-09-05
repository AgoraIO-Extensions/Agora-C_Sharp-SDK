namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Audio device management methods.
    /// </summary>
    ///
    public abstract class IAudioDeviceManager
    {
        #region PlaybackDevices
        ///
        /// <summary>
        /// Enumerates the audio playback devices.
        /// </summary>
        ///
        /// <returns>
        /// Success: Returns a DeviceInfo array, which includes the device ID and device name of all the audio playback devices.Failure: NULL.
        /// </returns>
        ///
        public abstract DeviceInfo[] EnumeratePlaybackDevices();

        ///
        /// <summary>
        /// Sets the audio playback device.
        /// </summary>
        ///
        /// <param name="deviceId"> The ID of the specified audio playback device. You can get the device ID by calling EnumeratePlaybackDevices . Plugging or unplugging the audio device does not change the value of deviceId.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlaybackDevice(string deviceId);

        ///
        /// <summary>
        /// Retrieves the audio playback device associated with the device ID.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter. The device ID of the audio playback device. </param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPlaybackDevice(ref string deviceId);

        ///
        /// <summary>
        /// Retrieves the audio playback device associated with the device ID.
        /// </summary>
        ///
        /// <param name="deviceId"> The device ID of the recording device. </param>
        ///
        /// <param name="deviceName"> The device name of the recording device. </param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName);

        ///
        /// @ignore
        ///
        public abstract int SetPlaybackDeviceVolume(int volume);

        ///
        /// @ignore
        ///
        public abstract int GetPlaybackDeviceVolume(ref int volume);

        ///
        /// @ignore
        ///
        public abstract int SetPlaybackDeviceMute(bool mute);

        ///
        /// @ignore
        ///
        public abstract int GetPlaybackDeviceMute(ref bool mute);

        ///
        /// <summary>
        /// Starts the audio playback device test.
        /// This method tests whether the audio playback device works properly. Once a user starts the test, the SDK plays an audio file specified by the user. If the user can hear the audio, the playback device works properly.After calling this method, the SDK triggers the OnAudioVolumeIndication callback every 100 ms, reporting uid = 1 and the volume information of the playback device.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="testAudioFilePath"> The path of the audio file. The data format is string in UTF-8.Supported file formats: wav, mp3, m4a, and aac.Supported file sample rates: 8000, 16000, 32000, 44100, and 48000 Hz.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartPlaybackDeviceTest(string testAudioFilePath);

        ///
        /// <summary>
        /// Stops the audio playback device test.
        /// This method stops the audio playback device test. You must call this method to stop the test after calling the StartPlaybackDeviceTest method.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopPlaybackDeviceTest();

        ///
        /// <summary>
        /// Sets the audio playback device used by the SDK to follow the system default audio playback device.
        /// </summary>
        ///
        /// <param name="enable"> Whether to follow the system default audio playback device:true: Follow. The SDK immediately switches the audio playback device when the system default audio playback device changes.false: Do not follow. The SDK switches the audio playback device to the system default audio playback device only when the currently used audio playback device is disconnected.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int FollowSystemPlaybackDevice(bool enable);
        #endregion

        #region RecordingDevices
        ///
        /// <summary>
        /// Enumerates the audio capture devices.
        /// </summary>
        ///
        /// <returns>
        /// Success: A DeviceInfo array, which includes the device ID and device name of all the audio capture devices.Failure: NULL.
        /// </returns>
        ///
        public abstract DeviceInfo[] EnumerateRecordingDevices();

        ///
        /// <summary>
        /// Sets the audio recording device.
        /// </summary>
        ///
        /// <param name="deviceId"> The ID of the audio recording device. You can get the device ID by calling EnumerateRecordingDevices . Plugging or unplugging the audio device does not change the value of deviceId.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRecordingDevice(string deviceId);

        ///
        /// <summary>
        /// Gets the current audio recording device.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter. The device ID of the recording device. </param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetRecordingDevice(ref string deviceId);

        ///
        /// <summary>
        /// Retrieves the volume of the audio recording device.
        /// </summary>
        ///
        /// <param name="deviceId"> The device ID of the recording device. </param>
        ///
        /// <param name="deviceName"> The device name of the recording device. </param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName);

        ///
        /// @ignore
        ///
        public abstract int SetRecordingDeviceVolume(int volume);

        ///
        /// @ignore
        ///
        public abstract int GetRecordingDeviceVolume(ref int volume);

        ///
        /// @ignore
        ///
        public abstract int SetRecordingDeviceMute(bool mute);

        ///
        /// @ignore
        ///
        public abstract int GetRecordingDeviceMute(ref bool mute);

        ///
        /// <summary>
        /// Starts the audio capture device test.
        /// This method tests whether the audio capture device works properly. After calling this method, the SDK triggers the OnAudioVolumeIndication callback at the time interval set in this method, which reports uid = 0 and the volume information of the capturing device.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="indicationInterval"> The time interval (ms) at which the SDK triggers the OnAudioVolumeIndication callback. Agora recommends a setting greater than 200 ms. This value must not be less than 10 ms; otherwise, you can not receive the OnAudioVolumeIndication callback.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartRecordingDeviceTest(int indicationInterval);

        ///
        /// <summary>
        /// Stops the audio capture device test.
        /// This method stops the audio capture device test. You must call this method to stop the test after calling the StartRecordingDeviceTest method.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopRecordingDeviceTest();

        ///
        /// <summary>
        /// Sets the audio recording device used by the SDK to follow the system default audio recording device.
        /// </summary>
        ///
        /// <param name="enable"> Whether to follow the system default audio recording device:true: Follow. The SDK immediately switches the audio recording device when the system default audio recording device changes.false: Do not follow. The SDK switches the audio recording device to the system default audio recording device only when the currently used audio recording device is disconnected.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int FollowSystemRecordingDevice(bool enable);
        #endregion

        #region AudioDevice
        ///
        /// <summary>
        /// Starts an audio device loopback test.
        /// This method tests whether the local audio capture device and playback device are working properly. Once the test starts, the audio recording device records the local audio, and the audio playback device plays the captured audio. The SDK triggers two independent OnAudioVolumeIndication callbacks at the time interval set in this method, which reports the volume information of the capture device (uid = 0) and the volume information of the playback device (uid = 1) respectively.Ensure that you call this method before joining a channel.This method tests local audio devices and does not report the network conditions.
        /// </summary>
        ///
        /// <param name="indicationInterval"> The time interval (ms) at which the SDK triggers the OnAudioVolumeIndication callback. Agora recommends setting a value greater than 200 ms. This value must not be less than 10 ms; otherwise, you can not receive the OnAudioVolumeIndication callback.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioDeviceLoopbackTest(int indicationInterval);

        ///
        /// <summary>
        /// Stops the audio device loopback test.
        /// Ensure that you call this method before joining a channel.Ensure that you call this method to stop the loopback test after calling the StartAudioDeviceLoopbackTest method.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopAudioDeviceLoopbackTest();
        #endregion
    }
}