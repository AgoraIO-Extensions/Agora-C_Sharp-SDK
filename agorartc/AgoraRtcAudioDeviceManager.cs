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

        public int audio_device_getCount()
        {
            return AgorartcNative.audio_device_getCount(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE);
        }

        public ERROR_CODE audio_device_getDevice(int index, string deviceName, string deviceId)
        {
            return AgorartcNative.audio_device_getDevice(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE, index,
                deviceName, deviceId);
        }

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

        public ERROR_CODE audio_device_setDevice(string deviceId)
        {
            return AgorartcNative.audio_device_setDevice(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE, deviceId);
        }

        public ERROR_CODE audio_device_setDeviceVolume(int volume)
        {
            return AgorartcNative.audio_device_setDeviceVolume(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                volume);
        }

        public ERROR_CODE audio_device_getDeviceVolume(IntPtr volume)
        {
            return AgorartcNative.audio_device_getDeviceVolume(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                volume);
        }

        public ERROR_CODE audio_device_setDeviceMute(bool mute)
        {
            return AgorartcNative.audio_device_setDeviceMute(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                mute ? 1 : 0);
        }

        public ERROR_CODE audio_device_getDeviceMute(IntPtr mute)
        {
            return AgorartcNative.audio_device_getDeviceMute(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE, mute);
        }

        public ERROR_CODE audio_device_startDeviceTest(string testAudioFilePath, int indicationInterval)
        {
            return AgorartcNative.audio_device_startDeviceTest(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE,
                testAudioFilePath,
                indicationInterval);
        }

        public ERROR_CODE audio_device_stopDeviceTest()
        {
            return AgorartcNative.audio_device_stopDeviceTest(_audioPlaybackHandler, DEVICE_TYPE.PLAYBACK_DEVICE);
        }

        public ERROR_CODE audio_device_startAudioDeviceLoopbackTest(int indicationInterval)
        {
            return AgorartcNative.audio_device_startAudioDeviceLoopbackTest(_audioPlaybackHandler,
                DEVICE_TYPE.PLAYBACK_DEVICE, indicationInterval);
        }

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

        public int audio_device_getCount()
        {
            return AgorartcNative.audio_device_getCount(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE);
        }

        public ERROR_CODE audio_device_getDevice(int index, string deviceName, string deviceId)
        {
            return AgorartcNative.audio_device_getDevice(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE, index,
                deviceName, deviceId);
        }

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

        public ERROR_CODE audio_device_setDevice(string deviceId)
        {
            return AgorartcNative.audio_device_setDevice(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                deviceId);
        }

        public ERROR_CODE audio_device_setDeviceVolume(int volume)
        {
            return AgorartcNative.audio_device_setDeviceVolume(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                volume);
        }

        public ERROR_CODE audio_device_getDeviceVolume(IntPtr volume)
        {
            return AgorartcNative.audio_device_getDeviceVolume(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                volume);
        }

        public ERROR_CODE audio_device_setDeviceMute(bool mute)
        {
            return AgorartcNative.audio_device_setDeviceMute(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                mute ? 1 : 0);
        }

        public ERROR_CODE audio_device_getDeviceMute(IntPtr mute)
        {
            return AgorartcNative.audio_device_getDeviceMute(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                mute);
        }

        public ERROR_CODE audio_device_startDeviceTest(string testAudioFilePath,
            int indicationInterval)
        {
            return AgorartcNative.audio_device_startDeviceTest(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE,
                testAudioFilePath, indicationInterval);
        }

        public ERROR_CODE audio_device_stopDeviceTest()
        {
            return AgorartcNative.audio_device_stopDeviceTest(_audioRecordingHandler, DEVICE_TYPE.RECORDING_DEVICE);
        }

        public ERROR_CODE audio_device_startAudioDeviceLoopbackTest(int indicationInterval)
        {
            return AgorartcNative.audio_device_startAudioDeviceLoopbackTest(_audioRecordingHandler,
                DEVICE_TYPE.RECORDING_DEVICE, indicationInterval);
        }

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