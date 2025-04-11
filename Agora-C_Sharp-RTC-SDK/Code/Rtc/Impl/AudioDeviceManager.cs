namespace Agora.Rtc
{
    public partial class AudioDeviceManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private AudioDeviceManagerImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        private AudioDeviceManager(IRtcEngine rtcEngine, AudioDeviceManagerImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;
        }

        ~AudioDeviceManager()
        {
            _rtcEngineInstance = null;
            _impl = null;
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
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetPlaybackDefaultDevice(ref deviceId, ref deviceName);
        }

        public override int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetPlaybackDefaultDevice(ref deviceId, ref deviceTypeName, ref deviceName);
        }

        public override int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetRecordingDefaultDevice(ref deviceId, ref deviceName);
        }

        public override int GetRecordingDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetRecordingDefaultDevice(ref deviceId, ref deviceTypeName, ref deviceName);
        }

        public override DeviceInfo[] EnumeratePlaybackDevices()
        {
            if (_impl == null)
            {
                return null;
            }
            return _impl.EnumeratePlaybackDevices();
        }

        public override DeviceInfo[] EnumerateRecordingDevices()
        {
            if (_impl == null)
            {
                return null;
            }
            return _impl.EnumerateRecordingDevices();
        }
    }
}