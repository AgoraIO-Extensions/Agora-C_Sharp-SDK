using System;

namespace Agora.Rtc
{
    public partial class VideoDeviceManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private VideoDeviceManagerImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        private VideoDeviceManager(IRtcEngine rtcEngine, VideoDeviceManagerImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;
        }

        ~VideoDeviceManager()
        {
            _rtcEngineInstance = null;
            _impl = null;
        }

        private static IVideoDeviceManager instance = null;
        public static IVideoDeviceManager Instance
        {
            get
            {
                return instance;
            }
        }

        internal static IVideoDeviceManager GetInstance(IRtcEngine rtcEngine, VideoDeviceManagerImpl impl)
        {
            return instance ?? (instance = new VideoDeviceManager(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override DeviceInfo[] EnumerateVideoDevices()
        {
            if (_impl == null)
            {
                return null;
            }
            return _impl.EnumerateVideoDevices();
        }
    }
}