namespace Agora.Rtc
{
    public sealed class AudioDeviceManager : IAudioDeviceManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private AudioDeviceManagerImpl _audioDeviecManagerImpl = null;
        private const string ErrorMsgLog = "[AudioDeviceManager]:IRtcEngine has not been created yet!";
        private const int ErrorCode = -1;

        private AudioDeviceManager(IRtcEngine rtcEngine, AudioDeviceManagerImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _audioDeviecManagerImpl = impl;
        }

        ~AudioDeviceManager()
        {
            _rtcEngineInstance = null;
        }

        private static IAudioDeviceManager instance = null;
        public static IAudioDeviceManager Instance
        {
            get
            {
                return instance;
            }
        }

        public override DeviceInfo[] EnumeratePlaybackDevices()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _audioDeviecManagerImpl.EnumeratePlaybackDevices();
        }

        public override int SetPlaybackDevice(string deviceId)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetPlaybackDevice(deviceId);
        }

        public override string GetPlaybackDevice()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _audioDeviecManagerImpl.GetPlaybackDevice();
        }

        public override DeviceInfo GetPlaybackDeviceInfo()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _audioDeviecManagerImpl.GetPlaybackDeviceInfo();
        }

        public override int SetPlaybackDeviceVolume(int volume)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetPlaybackDeviceVolume(volume);
        }

        public override int GetPlaybackDeviceVolume()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetPlaybackDeviceVolume();
        }

        public override int SetPlaybackDeviceMute(bool mute)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetPlaybackDeviceMute(mute);
        }

        public override bool GetPlaybackDeviceMute()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return false;
            }
            return _audioDeviecManagerImpl.GetPlaybackDeviceMute();
        }

        public override int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StartPlaybackDeviceTest(testAudioFilePath);
        }

        public override int StopPlaybackDeviceTest()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StopPlaybackDeviceTest();
        }

        public override DeviceInfo[] EnumerateRecordingDevices()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _audioDeviecManagerImpl.EnumerateRecordingDevices();
        }

        public override int SetRecordingDevice(string deviceId)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetRecordingDevice(deviceId);
        }

        public override string GetRecordingDevice()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _audioDeviecManagerImpl.GetRecordingDevice();
        }

        public override DeviceInfo GetRecordingDeviceInfo()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _audioDeviecManagerImpl.GetRecordingDeviceInfo();
        }

        public override int SetRecordingDeviceVolume(int volume)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetRecordingDeviceVolume(volume);
        }

        public override int GetRecordingDeviceVolume()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetRecordingDeviceVolume();
        }

        public override int SetRecordingDeviceMute(bool mute)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetRecordingDeviceMute(mute);
        }

        public override bool GetRecordingDeviceMute()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return false;
            }
            return _audioDeviecManagerImpl.GetRecordingDeviceMute();
        }

        public override int StartRecordingDeviceTest(int indicationInterval)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StartRecordingDeviceTest(indicationInterval);
        }

        public override int StopRecordingDeviceTest()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StopRecordingDeviceTest();
        }

        public override int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StartAudioDeviceLoopbackTest(indicationInterval);
        }

        public override int StopAudioDeviceLoopbackTest()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StopAudioDeviceLoopbackTest();
        }

        internal static IAudioDeviceManager GetInstance(IRtcEngine rtcEngine, AudioDeviceManagerImpl impl)
        {
            return instance ?? (instance = new AudioDeviceManager(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }
    }
}