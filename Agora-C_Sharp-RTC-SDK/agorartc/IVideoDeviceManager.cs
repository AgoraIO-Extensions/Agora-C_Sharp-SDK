using System;

namespace agora.rtc
{
    using view_t = IntPtr;

    public class IVideoDeviceManager
    {
        private static IVideoDeviceManager instance = null;
        private VideoDeviceManagerImpl _videoDeviecManagerImpl = null;

        private IVideoDeviceManager(VideoDeviceManagerImpl impl)
        {
            _videoDeviecManagerImpl = impl;
        }

        internal static IVideoDeviceManager GetInstance(VideoDeviceManagerImpl impl)
        {
            return instance ?? (instance = new IVideoDeviceManager(impl));
        }

        public DeviceInfo[] EnumerateVideoDevices()
        {
            return _videoDeviecManagerImpl.EnumerateVideoDevices();
        }

        public int SetDevice(string deviceIdUTF8)
        {
            return _videoDeviecManagerImpl.SetDevice(deviceIdUTF8);
        }

        public string GetDevice()
        {
            return _videoDeviecManagerImpl.GetDevice();
        }

        public int StartDeviceTest(view_t hwnd)
        {
            return _videoDeviecManagerImpl.StartDeviceTest(hwnd);
        }

        public int StopDeviceTest()
        {
            return _videoDeviecManagerImpl.StopDeviceTest();
        }
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}