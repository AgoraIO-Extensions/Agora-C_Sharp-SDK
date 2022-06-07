using System;

namespace agora.rtc
{
    public abstract class IVideoDeviceManager
    {
        public abstract DeviceInfo[] EnumerateVideoDevices();

        public abstract int SetDevice(string deviceIdUTF8);

        public abstract string GetDevice();

        public abstract int StartDeviceTest(IntPtr hwnd);

        public abstract int StopDeviceTest();
    }
}