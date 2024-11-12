namespace Agora.Rtc
{
    public sealed class AudioDeviceManager : IAudioDeviceManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private AudioDeviceManagerImpl _audioDeviecManagerImpl = null;
        private const int ErrorCode = -7;
        private static System.Object rtcLock = new System.Object();

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
                lock (rtcLock)
                {
                    return instance;
                }
            }
        }

        #region PlaybackDevices
        public override DeviceInfo[] EnumeratePlaybackDevices()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return null;
                }
                return _audioDeviecManagerImpl.EnumeratePlaybackDevices();
            }
        }

        public override int SetPlaybackDevice(string deviceId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.SetPlaybackDevice(deviceId);
            }
        }

        public override int GetPlaybackDevice(ref string deviceId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetPlaybackDevice(ref deviceId);
            }
        }

        public override int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetPlaybackDeviceInfo(ref deviceId, ref deviceName);
            }
        }

        public override int SetPlaybackDeviceVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.SetPlaybackDeviceVolume(volume);
            }
        }

        public override int GetPlaybackDeviceVolume(ref int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetPlaybackDeviceVolume(ref volume);
            }
        }

        public override int SetPlaybackDeviceMute(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.SetPlaybackDeviceMute(mute);
            }
        }

        public override int GetPlaybackDeviceMute(ref bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetPlaybackDeviceMute(ref mute);
            }
        }

        public override int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.StartPlaybackDeviceTest(testAudioFilePath);
            }
        }

        public override int StopPlaybackDeviceTest()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.StopPlaybackDeviceTest();
            }
        }

        public override int FollowSystemPlaybackDevice(bool enable)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.FollowSystemPlaybackDevice(enable);
            }
        }
        #endregion

        #region RecordingDevices
        public override DeviceInfo[] EnumerateRecordingDevices()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return null;
                }
                return _audioDeviecManagerImpl.EnumerateRecordingDevices();
            }
        }

        public override int SetRecordingDevice(string deviceId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.SetRecordingDevice(deviceId);
            }
        }

        public override int GetRecordingDevice(ref string deviceId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetRecordingDevice(ref deviceId);
            }
        }

        public override int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetRecordingDeviceInfo(ref deviceId, ref deviceName);
            }
        }

        public override int SetRecordingDeviceVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.SetRecordingDeviceVolume(volume);
            }
        }

        public override int GetRecordingDeviceVolume(ref int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetRecordingDeviceVolume(ref volume);
            }
        }

        public override int SetRecordingDeviceMute(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.SetRecordingDeviceMute(mute);
            }
        }

        public override int GetRecordingDeviceMute(ref bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetRecordingDeviceMute(ref mute);
            }
        }

        public override int StartRecordingDeviceTest(int indicationInterval)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.StartRecordingDeviceTest(indicationInterval);
            }
        }

        public override int StopRecordingDeviceTest()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.StopRecordingDeviceTest();
            }
        }

        public override int FollowSystemRecordingDevice(bool enable)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.FollowSystemRecordingDevice(enable);
            }
        }
        #endregion

        #region AudioDevice
        public override int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.StartAudioDeviceLoopbackTest(indicationInterval);
            }
        }

        public override int StopAudioDeviceLoopbackTest()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.StopAudioDeviceLoopbackTest();
            }
        }

        public override int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceName)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetPlaybackDefaultDevice(ref deviceId, ref deviceName);
            }
        }

        public override int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetRecordingDefaultDevice(ref deviceId, ref deviceName);
            }
        }

        public override int SetLoopbackDevice(string deviceId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.SetLoopbackDevice(deviceId);
            }
        }

        public override int GetLoopbackDevice(ref string deviceId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.GetLoopbackDevice(ref deviceId);
            }
        }

        public override int FollowSystemLoopbackDevice(bool enable)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _audioDeviecManagerImpl.FollowSystemLoopbackDevice(enable);
            }
        }

        #endregion

        internal static IAudioDeviceManager GetInstance(IRtcEngine rtcEngine, AudioDeviceManagerImpl impl)
        {
            lock (rtcLock)
            {
                return instance ?? (instance = new AudioDeviceManager(rtcEngine, impl));
            }
        }

        internal static void ReleaseInstance()
        {
            lock (rtcLock)
            {
                instance = null;
            }
        }


    }
}