﻿namespace Agora.Rtc
{
    public sealed class AudioDeviceManager : IAudioDeviceManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private AudioDeviceManagerImpl _audioDeviecManagerImpl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

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

        internal static IAudioDeviceManager GetInstance(IRtcEngine rtcEngine, AudioDeviceManagerImpl impl)
        {
            return instance ?? (instance = new AudioDeviceManager(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceName)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetPlaybackDefaultDevice(ref deviceId, ref deviceName);
        }

        public override int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetPlaybackDefaultDevice(ref deviceId, ref deviceTypeName, ref deviceName);
        }

        public override int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetRecordingDefaultDevice(ref deviceId, ref deviceName);
        }

        public override int GetRecordingDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetRecordingDefaultDevice(ref deviceId, ref deviceTypeName, ref deviceName);
        }

        public override DeviceInfo[] EnumeratePlaybackDevices()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return null;
            }
            return _audioDeviecManagerImpl.EnumeratePlaybackDevices();
        }

        public override DeviceInfo[] EnumerateRecordingDevices()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return null;
            }
            return _audioDeviecManagerImpl.EnumerateRecordingDevices();
        }

        #region terra IAudioDeviceManager
        public override int SetPlaybackDevice(string deviceId)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetPlaybackDevice(deviceId);
        }

        public override int GetPlaybackDevice(ref string deviceId)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetPlaybackDevice(ref deviceId);
        }

        public override int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetPlaybackDeviceInfo(ref deviceId, ref deviceName);
        }

        public override int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName, ref string deviceTypeName)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetPlaybackDeviceInfo(ref deviceId, ref deviceName, ref deviceTypeName);
        }

        public override int SetPlaybackDeviceVolume(int volume)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetPlaybackDeviceVolume(volume);
        }

        public override int GetPlaybackDeviceVolume(ref int volume)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetPlaybackDeviceVolume(ref volume);
        }

        public override int SetRecordingDevice(string deviceId)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetRecordingDevice(deviceId);
        }

        public override int GetRecordingDevice(ref string deviceId)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetRecordingDevice(ref deviceId);
        }

        public override int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetRecordingDeviceInfo(ref deviceId, ref deviceName);
        }

        public override int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName, ref string deviceTypeName)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetRecordingDeviceInfo(ref deviceId, ref deviceName, ref deviceTypeName);
        }

        public override int SetRecordingDeviceVolume(int volume)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetRecordingDeviceVolume(volume);
        }

        public override int GetRecordingDeviceVolume(ref int volume)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetRecordingDeviceVolume(ref volume);
        }

        public override int SetLoopbackDevice(string deviceId)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetLoopbackDevice(deviceId);
        }

        public override int GetLoopbackDevice(ref string deviceId)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetLoopbackDevice(ref deviceId);
        }

        public override int SetPlaybackDeviceMute(bool mute)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetPlaybackDeviceMute(mute);
        }

        public override int GetPlaybackDeviceMute(ref bool mute)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetPlaybackDeviceMute(ref mute);
        }

        public override int SetRecordingDeviceMute(bool mute)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.SetRecordingDeviceMute(mute);
        }

        public override int GetRecordingDeviceMute(ref bool mute)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.GetRecordingDeviceMute(ref mute);
        }

        public override int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StartPlaybackDeviceTest(testAudioFilePath);
        }

        public override int StopPlaybackDeviceTest()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StopPlaybackDeviceTest();
        }

        public override int StartRecordingDeviceTest(int indicationInterval)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StartRecordingDeviceTest(indicationInterval);
        }

        public override int StopRecordingDeviceTest()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StopRecordingDeviceTest();
        }

        public override int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StartAudioDeviceLoopbackTest(indicationInterval);
        }

        public override int StopAudioDeviceLoopbackTest()
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.StopAudioDeviceLoopbackTest();
        }

        public override int FollowSystemPlaybackDevice(bool enable)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.FollowSystemPlaybackDevice(enable);
        }

        public override int FollowSystemRecordingDevice(bool enable)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.FollowSystemRecordingDevice(enable);
        }

        public override int FollowSystemLoopbackDevice(bool enable)
        {
            if (_rtcEngineInstance == null || _audioDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _audioDeviecManagerImpl.FollowSystemLoopbackDevice(enable);
        }


        #endregion terra IAudioDeviceManager
    }
}