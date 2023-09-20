using System;

namespace Agora.Rtc
{
    /* class_ivideodevicemanager */
    public abstract class IVideoDeviceManager
    {
        /* api_ivideodevicemanager_enumeratevideodevices */
        public abstract DeviceInfo[] EnumerateVideoDevices();

#region terra IVideoDeviceManager

        /* api_ivideodevicemanager_setdevice */
        public abstract int SetDevice(string deviceIdUTF8);

        /* api_ivideodevicemanager_getdevice */
        public abstract int GetDevice(ref string deviceIdUTF8);

        /* api_ivideodevicemanager_numberofcapabilities */
        public abstract int NumberOfCapabilities(string deviceIdUTF8);

        /* api_ivideodevicemanager_getcapability */
        public abstract int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, ref VideoFormat capability);

        /* api_ivideodevicemanager_startdevicetest */
        public abstract int StartDeviceTest(IntPtr hwnd);

        /* api_ivideodevicemanager_stopdevicetest */
        public abstract int StopDeviceTest();

#endregion terra IVideoDeviceManager
    }
}