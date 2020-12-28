using System;

namespace agorartc
{
    using IAudioPlaybackDeviceManager_ptr = IntPtr;
    using IAudioRecordingDeviceManager_ptr = IntPtr;

    public class AgoraAudioPlaybackDeviceManager : IDisposable
    {
        private IAudioPlaybackDeviceManager_ptr _audioPlaybackHandler;
        private bool _disposed = false;

        internal AgoraAudioPlaybackDeviceManager(IAudioPlaybackDeviceManager_ptr handler)
        {
            _audioPlaybackHandler = handler;
        }

        /// <summary>
        /// Releases all IRtcAudioPlaybackDeviceManager resources.
        /// </summary>
        public void Dispose()
        {
            
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) {}

            ReleaseAudioPlaybackDeviceManager();
            _disposed = true;
        }
        
        /// <summary>
        /// Retrieves the total number of audio playback or audio recording devices.
        ///
        ///@note You must first call the \ref IAudioDeviceManager::enumeratePlaybackDevices "enumeratePlaybackDevices" method before calling this method to return the number of audio playback devices.
        /// </summary>
        /// 
        /// <returns>
        /// @return Number of audio playback devices.
        /// </returns>
        public int audio_device_getCount()
        {
            return AgorartcNative.audio_device_getCount(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE);
        }
        
        /// <summary>
        /// Retrieves a specified piece of information about an indexed audio device.
        /// </summary>
        /// 
        /// <param name="index">
        /// @param index The specified index that must be less than the return value of \ref IAudioDeviceCollection::getCount "getCount".
        /// </param>
        /// 
        /// <param name="deviceName">
        /// @param deviceName Pointer to the audio device name.
        /// </param>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Pointer to the audio device ID.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_getDevice(int index, string deviceName, string deviceId)
        {
            return AgorartcNative.audio_device_getDevice(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE, index,
                deviceName, deviceId);
        }

        /// <summary>
        /// Get the device id of the current device.
        /// </summary>
        /// 
        /// <param name="deviceId">
        /// OUT Attribute. Return the deviceId here.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_getCurrentDevice(string deviceId)
        {
            return AgorartcNative.audio_device_getCurrentDevice(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                deviceId);
        }
        
        public ERROR_CODE audio_device_getCurrentDeviceInfo(string deviceId, string deviceName)
        {
            return AgorartcNative.audio_device_getCurrentDeviceInfo(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                deviceId, deviceName);
        }
        
        /// <summary>
        /// Specifies a device with the device ID.
        /// </summary>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Pointer to the device ID of the device.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_setDevice(string deviceId)
        {
            return AgorartcNative.audio_device_setDevice(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE, deviceId);
        }

        /// <summary>
        /// Sets the volume of the device.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume Device volume. The value ranges between 0 (lowest volume) and 255 (highest volume).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_setDeviceVolume(int volume)
        {
            return AgorartcNative.audio_device_setDeviceVolume(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                volume);
        }

        /// <summary>
        /// Retrieves the volume of the device.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume Device volume. The value ranges between 0 (lowest volume) and 255 (highest volume).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_getDeviceVolume(IntPtr volume)
        {
            return AgorartcNative.audio_device_getDeviceVolume(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                volume);
        }

        /// <summary>
        /// Mutes the device.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to mute/unmute the application:
        ///- true: Mute the application.
        ///- false: Unmute the application.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_setDeviceMute(bool mute)
        {
            return AgorartcNative.audio_device_setDeviceMute(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                mute ? 1 : 0);
        }

        /// <summary>
        /// Gets the mute state of the application.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Pointer to whether the application is muted/unmuted.
        ///- true: The application is muted.
        ///- false: The application is not muted.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_getDeviceMute(IntPtr mute)
        {
            return AgorartcNative.audio_device_getDeviceMute(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE, mute);
        }

        /// <summary>
        /// Starts the audio device test.
        ///
        ///This method tests if the playback device works properly. In the test, the SDK plays an audio file specified by the user. If the user can hear the audio, the playback device works properly.
        /// </summary>
        /// 
        /// <param name="testAudioFilePath">
        /// @param testAudioFilePath Pointer to the path of the audio file for the audio playback device test in UTF-8:
        /// - Supported file formats: wav, mp3, m4a, and aac.
        /// - Supported file sample rates: 8000, 16000, 32000, 44100, and 48000 Hz.
        /// </param>
        /// 
        /// <param name="indicationInterval">
        /// 
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success, and you can hear the sound of the specified audio file.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_startDeviceTest(string testAudioFilePath, int indicationInterval)
        {
            return AgorartcNative.audio_device_startDeviceTest(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                testAudioFilePath,
                indicationInterval);
        }

        /// <summary>
        /// Stops the video-capture device test.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_stopDeviceTest()
        {
            return AgorartcNative.audio_device_stopDeviceTest(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE);
        }

        /// <summary>
        /// /// Starts the audio device loopback test.
        ///
        /// This method tests whether the local audio devices are working properly. After calling this method, the microphone captures the local audio and plays it through the speaker. The \ref IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback returns the local audio volume information at the set interval.
        ///
        /// @note This method tests the local audio devices and does not report the network conditions.
        /// </summary>
        /// 
        /// <param name="indicationInterval">
        /// @param indicationInterval The time interval (ms) at which the \ref IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback returns.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_startAudioDeviceLoopbackTest(int indicationInterval)
        {
            return AgorartcNative.audio_device_startAudioDeviceLoopbackTest(_audioPlaybackHandler,
                DEVICE_TYPE.PLAYBACK_DEVICE, indicationInterval);
        }

        /// <summary>
        /// Stops the audio device loopback test.
        ///
        ///@note Ensure that you call this method to stop the loopback test after calling the \ref IAudioDeviceManager::startAudioDeviceLoopbackTest "startAudioDeviceLoopbackTest" method.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_stopAudioDeviceLoopbackTest()
        {
            return AgorartcNative.audio_device_stopAudioDeviceLoopbackTest(_audioPlaybackHandler,
                DEVICE_TYPE.PLAYBACK_DEVICE);
        }

        private void ReleaseAudioPlaybackDeviceManager()
        {
            AgorartcNative.releaseAudioPlaybackDeviceManager(_audioPlaybackHandler);
            AgoraRtcEngine.CreateRtcEngine().ReleaseAudioPlaybackDeviceManager(this);
            _audioPlaybackHandler = IntPtr.Zero;
        }

        ~AgoraAudioPlaybackDeviceManager()
        {
            Dispose(false);
        }
    }

    public class AgoraAudioRecordingDeviceManager: IDisposable
    {
        private IAudioRecordingDeviceManager_ptr _audioRecordingHandler;
        private bool _disposed = false;

        public AgoraAudioRecordingDeviceManager(IAudioRecordingDeviceManager_ptr handler)
        {
            _audioRecordingHandler = handler;
        }
        
        /// <summary>
        /// Releases all IRtcAudioRecordingDeviceManager resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                
            }

            ReleaseAudioRecordingDeviceManager();
            _disposed = true;
        }

        /// <summary>
        /// Retrieves the total number of audio recording devices.
        ///
        ///@note You must first call the \ref IAudioDeviceManager::enumerateRecordingDevices "enumerateRecordingDevices" method before calling this method to return the number of  audio playback or audio recording devices.
        /// </summary>
        /// 
        /// <returns>
        /// @return Number of audio recording devices.
        /// </returns>
        public int audio_device_getCount()
        {
            return AgorartcNative.audio_device_getCount(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE);
        }

        /// <summary>
        /// Retrieves a specified piece of information about an indexed audio device.
        /// </summary>
        /// 
        /// <param name="index">
        /// @param index The specified index that must be less than the return value of \ref IAudioDeviceCollection::getCount "getCount".
        /// </param>
        /// 
        /// <param name="deviceName">
        /// @param deviceName Pointer to the audio device name.
        /// </param>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Pointer to the audio device ID.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_getDevice(int index, string deviceName, string deviceId)
        {
            return AgorartcNative.audio_device_getDevice(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE, index,
                deviceName, deviceId);
        }

        /// <summary>
        /// Get the device id of the current device.
        /// </summary>
        /// 
        /// <param name="deviceId">
        /// OUT Attribute. Return the deviceId here.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_getCurrentDevice(string deviceId)
        {
            return AgorartcNative.audio_device_getCurrentDevice(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                deviceId);
        }

        public ERROR_CODE audio_device_getCurrentDeviceInfo(string deviceId, string deviceName)
        {
            return AgorartcNative.audio_device_getCurrentDeviceInfo(_audioRecordingHandler,
                DEVICE_TYPE.RECORDING_DEVICE, deviceId, deviceName);
        }

        /// <summary>
        /// Specifies a device with the device ID.
        /// </summary>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Pointer to the device ID of the device.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_setDevice(string deviceId)
        {
            return AgorartcNative.audio_device_setDevice(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                deviceId);
        }

        /// <summary>
        /// Sets the volume of the device.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume Device volume. The value ranges between 0 (lowest volume) and 255 (highest volume).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_setDeviceVolume(int volume)
        {
            return AgorartcNative.audio_device_setDeviceVolume(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                volume);
        }

        /// <summary>
        /// Retrieves the volume of the device.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume Device volume. The value ranges between 0 (lowest volume) and 255 (highest volume).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_getDeviceVolume(IntPtr volume)
        {
            return AgorartcNative.audio_device_getDeviceVolume(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                volume);
        }

        /// <summary>
        /// Mutes the device.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to mute/unmute the application:
        ///- true: Mute the application.
        ///- false: Unmute the application.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_setDeviceMute(bool mute)
        {
            return AgorartcNative.audio_device_setDeviceMute(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                mute ? 1 : 0);
        }

        /// <summary>
        /// Gets the mute state of the application.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Pointer to whether the application is muted/unmuted.
        ///- true: The application is muted.
        ///- false: The application is not muted.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_getDeviceMute(IntPtr mute)
        {
            return AgorartcNative.audio_device_getDeviceMute(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                mute);
        }

        /// <summary>
        /// Starts the audio device test.
        ///
        ///This method tests if the recording device works properly. In the test, the SDK plays an audio file specified by the user.
        /// </summary>
        /// 
        /// <param name="testAudioFilePath">
        /// @param testAudioFilePath Pointer to the path of the audio file for the audio recording device test in UTF-8:
        /// - Supported file formats: wav, mp3, m4a, and aac.
        /// - Supported file sample rates: 8000, 16000, 32000, 44100, and 48000 Hz.
        /// </param>
        /// 
        /// <param name="indicationInterval">
        /// 
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_startDeviceTest(string testAudioFilePath,
            int indicationInterval)
        {
            return AgorartcNative.audio_device_startDeviceTest(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                testAudioFilePath, indicationInterval);
        }

        /// <summary>
        /// Stops the video-capture device test.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_stopDeviceTest()
        {
            return AgorartcNative.audio_device_stopDeviceTest(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE);
        }

        /// <summary>
        /// /// Starts the audio device loopback test.
        ///
        /// This method tests whether the local audio devices are working properly. After calling this method, the microphone captures the local audio and plays it through the speaker. The \ref IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback returns the local audio volume information at the set interval.
        ///
        /// @note This method tests the local audio devices and does not report the network conditions.
        /// </summary>
        /// 
        /// <param name="indicationInterval">
        /// @param indicationInterval The time interval (ms) at which the \ref IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback returns.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_startAudioDeviceLoopbackTest(int indicationInterval)
        {
            return AgorartcNative.audio_device_startAudioDeviceLoopbackTest(_audioRecordingHandler,
                DEVICE_TYPE.RECORDING_DEVICE, indicationInterval);
        }

        /// <summary>
        /// Stops the audio device loopback test.
        ///
        ///@note Ensure that you call this method to stop the loopback test after calling the \ref IAudioDeviceManager::startAudioDeviceLoopbackTest "startAudioDeviceLoopbackTest" method.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE audio_device_stopAudioDeviceLoopbackTest()
        {
            return AgorartcNative.audio_device_stopAudioDeviceLoopbackTest(_audioRecordingHandler,
                DEVICE_TYPE.RECORDING_DEVICE);
        }
        
        private void ReleaseAudioRecordingDeviceManager()
        {
            AgorartcNative.releaseAudioRecordingDeviceManager(_audioRecordingHandler);
            AgoraRtcEngine.CreateRtcEngine().ReleaseAudioRecordingDeviceManager(this);
            _audioRecordingHandler = IntPtr.Zero;
        }

        ~AgoraAudioRecordingDeviceManager()
        {
            Dispose(false);
        }
    }
}