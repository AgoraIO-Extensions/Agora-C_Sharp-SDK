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
        /// This method is for Windows and macOS only.
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
        /// This method is for Windows and macOS only.You can call this method to change the audio route currently being used, but this does not change the default audio route. For example, if the default audio route is speaker 1, you call this method to set the audio route as speaker 2 before joinging a channel and then start a device test, the SDK conducts device test on speaker 2. After the device test is completed and you join a channel, the SDK still uses speaker 1, the default audio route.
        /// </summary>
        ///
        /// <param name="deviceId"> The ID of the specified audio playback device. You can get the device ID by calling EnumeratePlaybackDevices . Connecting or disconnecting the audio device does not change the value of deviceId.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlaybackDevice(string deviceId);

        ///
        /// <summary>
        /// Retrieves the audio playback device associated with the device ID.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter. The device ID of the audio playback device.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPlaybackDevice(ref string deviceId);

        ///
        /// <summary>
        /// Retrieves the audio playback device associated with the device ID.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> The device ID of the playback device.</param>
        ///
        /// <param name="deviceName"> The device name of the playback device.</param>
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
        /// This method tests whether the audio playback device works properly. Once a user starts the test, the SDK plays an audio file specified by the user. If the user can hear the audio, the playback device works properly.After calling this method, the SDK triggers the OnAudioVolumeIndication callback every 100 ms, reporting uid = 1 and the volume information of the playback device.Ensure that you call this method before joining a channel.This method is for Windows and macOS only.
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
        /// This method stops the audio playback device test. You must call this method to stop the test after calling the StartPlaybackDeviceTest method.This method is for Windows and macOS only.Ensure that you call this method before joining a channel.
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
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="enable"> Whether to follow the system default audio playback device:true: Follow the system default audio playback device. The SDK immediately switches the audio playback device when the system default audio playback device changes.false: Do not follow the system default audio playback device. The SDK switches the audio playback device to the system default audio playback device only when the currently used audio playback device is disconnected.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int FollowSystemPlaybackDevice(bool enable);


        ///
        /// <summary>
        /// Gets the default audio playback device.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter, the device ID of the default audio playback device.</param>
        ///
        /// <param name="deviceName"> Output parameter, the device name of the default audio playback device.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceName);
        #endregion

        #region RecordingDevices
        ///
        /// <summary>
        /// Enumerates the audio capture devices.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <returns>
        /// Success: A DeviceInfo array, which includes the device ID and device name of all the audio capture devices.Failure: NULL.
        /// </returns>
        ///
        public abstract DeviceInfo[] EnumerateRecordingDevices();

        ///
        /// <summary>
        /// Sets the audio capture device.
        /// This method is for Windows and macOS only.You can call this method to change the audio route currently being used, but this does not change the default audio route. For example, if the default audio route is microphone, you call this method to set the audio route as bluetooth earphones before joinging a channel and then start a device test, the SDK conducts device test on the bluetooth earphones. After the device test is completed and you join a channel, the SDK still uses the microphone for audio capturing.
        /// </summary>
        ///
        /// <param name="deviceId"> The ID of the audio capture device. You can get the Device ID by calling EnumerateRecordingDevices . Connecting or disconnecting the audio device does not change the value of deviceId.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRecordingDevice(string deviceId);

        ///
        /// <summary>
        /// Gets the current audio recording device.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter. The device ID of the recording device.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetRecordingDevice(ref string deviceId);

        ///
        /// <summary>
        /// Retrieves the volume of the audio recording device.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> The device ID of the playback device.</param>
        ///
        /// <param name="deviceName"> The device name of the playback device.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName);

        ///
        /// <summary>
        /// Sets the volume of the audio capture device.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="volume"> The volume of the audio recording device. The value range is [0,255]. 0 means no sound, 255 means maximum volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
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
        /// This method tests whether the audio capture device works properly. After calling this method, the SDK triggers the OnAudioVolumeIndication callback at the time interval set in this method, which reports uid = 0 and the volume information of the capturing device.This method is for Windows and macOS only.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="indicationInterval"> The time interval (ms) at which the SDK triggers the OnAudioVolumeIndication callback. Agora recommends setting a value greater than 200 ms. This value must not be less than 10 ms; otherwise, you can not receive the OnAudioVolumeIndication callback.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartRecordingDeviceTest(int indicationInterval);

        ///
        /// <summary>
        /// Stops the audio capture device test.
        /// This method stops the audio capture device test. You must call this method to stop the test after calling the StartRecordingDeviceTest method.This method is for Windows and macOS only.Ensure that you call this method before joining a channel.
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
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="enable"> Whether to follow the system default audio recording device:true: Follow the system default audio playback device. The SDK immediately switches the audio recording device when the system default audio recording device changes.false: Do not follow the system default audio playback device. The SDK switches the audio recording device to the system default audio recording device only when the currently used audio recording device is disconnected.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int FollowSystemRecordingDevice(bool enable);

        ///
        /// <summary>
        /// Gets the default audio capture device.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter, the device ID of the default audio capture device.</param>
        ///
        /// <param name="deviceName"> Output parameter, the device name of the default audio capture device.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName);
        #endregion

        #region AudioDevice
        ///
        /// <summary>
        /// Starts an audio device loopback test.
        /// This method tests whether the local audio capture device and playback device are working properly. After starting the test, the audio capture device records the local audio, and the audio playback device plays the captured audio. The SDK triggers two independent OnAudioVolumeIndication callbacks at the time interval set in this method, which reports the volume information of the capture device (uid = 0) and the volume information of the playback device (uid = 1) respectively.This method is for Windows and macOS only.Ensure that you call this method before joining a channel.This method tests local audio devices and does not report the network conditions.
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
        /// This method is for Windows and macOS only.Ensure that you call this method before joining a channel.Ensure that you call this method to stop the loopback test after calling the StartAudioDeviceLoopbackTest method.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopAudioDeviceLoopbackTest();

        ///
        /// <summary>
        /// Sets the loopback device.
        /// The SDK uses the current playback device as the loopback device by default. If you want to specify another audio device as the loopback device, call this method, and set deviceId to the loopback device you want to specify.You can call this method to change the audio route currently being used, but this does not change the default audio route. For example, if the default audio route is microphone, you call this method to set the audio route as a sound card before joinging a channel and then start a device test, the SDK conducts device test on the sound card. After the device test is completed and you join a channel, the SDK still uses the microphone for audio capturing.This method is for Windows and macOS only.The scenarios where this method is applicable are as follows:Use app A to play music through a Bluetooth headset; when using app B for a video conference, play through the speakers.If the loopback device is set as the Bluetooth headset, the SDK publishes the music in app A to the remote end.If the loopback device is set as the speaker, the SDK does not publish the music in app A to the remote end.If you set the loopback device as the Bluetooth headset, and then use a wired headset to play the music in app A, you need to call this method again, set the loopback device as the wired headset, and the SDK continues to publish the music in app A to remote end.
        /// </summary>
        ///
        /// <param name="deviceId"> Specifies the loopback device of the SDK. You can get the device ID by calling EnumeratePlaybackDevices . Connecting or disconnecting the audio device does not change the value of deviceId.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLoopbackDevice(string deviceId);
        ///
        /// <summary>
        /// Gets the current loopback device.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> Output parameter, the ID of the current loopback device.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetLoopbackDevice(ref string deviceId);
        ///
        /// <summary>
        /// Sets whether the loopback device follows the system default playback device.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="enable"> Whether to follow the system default audio playback device:true: Follow the system default audio playback device. When the default playback device of the system is changed, the SDK immediately switches to the loopback device.false: Do not follow the system default audio playback device. The SDK switches the audio loopback device to the system default audio playback device only when the current audio playback device is disconnected.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int FollowSystemLoopbackDevice(bool enable);
        #endregion



    }
}