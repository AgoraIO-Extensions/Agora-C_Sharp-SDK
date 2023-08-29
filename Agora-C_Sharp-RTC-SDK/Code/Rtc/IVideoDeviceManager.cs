using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Video device management methods.
    /// </summary>
    ///
    public abstract class IVideoDeviceManager
    {
        ///
        /// <summary>
        /// Enumerates the video devices.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <returns>
        /// Success: A DeviceInfo array including all video devices in the system.
        /// Failure: An empty array.
        /// </returns>
        ///
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