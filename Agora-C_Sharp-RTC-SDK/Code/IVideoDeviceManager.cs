using System;

namespace Agora.Rtc
{
    public abstract class IVideoDeviceManager
    {
        public abstract DeviceInfo[] EnumerateVideoDevices();

        public abstract int SetDevice(string deviceIdUTF8);

        public abstract string GetDevice();

        public abstract int StartDeviceTest(IntPtr hwnd);

        public abstract int StopDeviceTest();

        public abstract int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, out VideoFormat capability);

        public abstract int NumberOfCapabilities(string deviceIdUTF8);
    }
}