using System;

namespace agora.rtc
{
    public sealed class VideoDeviceManager : IVideoDeviceManager
    {
        private static IVideoDeviceManager instance = null;
        private VideoDeviceManagerImpl _videoDeviecManagerImpl = null;

        private VideoDeviceManager(VideoDeviceManagerImpl impl)
        {
            _videoDeviecManagerImpl = impl;
        }

        internal static IVideoDeviceManager GetInstance(VideoDeviceManagerImpl impl)
        {
            return instance ?? (instance = new VideoDeviceManager(impl));
        }

        public override DeviceInfo[] EnumerateVideoDevices()
        {
            return _videoDeviecManagerImpl.EnumerateVideoDevices();
        }

        public override int SetDevice(string deviceIdUTF8)
        {
            return _videoDeviecManagerImpl.SetDevice(deviceIdUTF8);
        }

        public override string GetDevice()
        {
            return _videoDeviecManagerImpl.GetDevice();
        }

        public override int StartDeviceTest(IntPtr hwnd)
        {
            return _videoDeviecManagerImpl.StartDeviceTest(hwnd);
        }

        public override int StopDeviceTest()
        {
            return _videoDeviecManagerImpl.StopDeviceTest();
        }
    }
}