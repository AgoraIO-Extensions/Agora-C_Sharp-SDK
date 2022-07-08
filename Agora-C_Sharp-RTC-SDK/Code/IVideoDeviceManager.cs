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
        /// </summary>
        ///
        /// <returns>
        /// Success: A DeviceInfo array including all video devices in the system.
        /// Failure: NULL.
        /// </returns>
        ///
        public abstract DeviceInfo[] EnumerateVideoDevices();

        ///
        /// <summary>
        /// Specifies the video capture device with the device ID.
        /// Plugging or unplugging a device does not change its device ID.
        /// </summary>
        ///
        /// <param name="deviceIdUTF8"> The device ID. You can get the device ID by calling EnumerateVideoDevices .</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDevice(string deviceIdUTF8);

        ///
        /// <summary>
        /// Retrieves the current video capture device.
        /// </summary>
        ///
        /// <returns>
        /// The video capture device.
        /// </returns>
        ///
        public abstract string GetDevice();

        public abstract int StartDeviceTest(IntPtr hwnd);

        public abstract int StopDeviceTest();
    }
}