using System;

namespace Agora.Rtc
{
    public abstract class IVideoDeviceManager
    {
        public abstract DeviceInfo[] EnumerateVideoDevices();

#region terra IVideoDeviceManager

        public abstract int SetDevice(string deviceIdUTF8);

        public abstract int GetDevice(ref string deviceIdUTF8);

        public abstract int NumberOfCapabilities(string deviceIdUTF8);

        public abstract int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, ref VideoFormat capability);

        public abstract int StartDeviceTest(IntPtr hwnd);

        public abstract int StopDeviceTest();

#endregion terra IVideoDeviceManager
    }
}