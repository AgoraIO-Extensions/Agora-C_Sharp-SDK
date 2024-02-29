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
        /// 
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
        ///
        /// <summary>
        /// Specifies the video capture device with the device ID.
        /// 
        /// Plugging or unplugging a device does not change its device ID.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceIdUTF8"> The device ID. You can get the device ID by calling EnumerateVideoDevices. </param>
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
        /// 
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceIdUTF8"> An output parameter. The device ID. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetDevice(ref string deviceIdUTF8);

        ///
        /// <summary>
        /// Gets the number of video formats supported by the specified video capture device.
        /// 
        /// This method is for Windows and macOS only. Video capture devices may support multiple video formats, and each format supports different combinations of video frame width, video frame height, and frame rate. You can call this method to get how many video formats the specified video capture device can support, and then call GetCapability to get the specific video frame information in the specified video format.
        /// </summary>
        ///
        /// <param name="deviceIdUTF8"> The ID of the video capture device. </param>
        ///
        /// <returns>
        /// &gt; 0: Success. Returns the number of video formats supported by this device. For example: If the specified camera supports 10 different video formats, the return value is 10.
        /// ≤ 0: Failure.
        /// </returns>
        ///
        public abstract int NumberOfCapabilities(string deviceIdUTF8);

        ///
        /// <summary>
        /// Gets the detailed video frame information of the video capture device in the specified video format.
        /// 
        /// This method is for Windows and macOS only. After calling NumberOfCapabilities to get the number of video formats supported by the video capture device, you can call this method to get the specific video frame information supported by the specified index number.
        /// </summary>
        ///
        /// <param name="deviceIdUTF8"> The ID of the video capture device. </param>
        ///
        /// <param name="deviceCapabilityNumber"> The index number of the video format. If the return value of NumberOfCapabilities is i, the value range of this parameter is [0,i). </param>
        ///
        /// <param name="capability"> An output parameter. Indicates the specific information of the specified video format, including width (px), height (px), and frame rate (fps). See VideoFormat. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, ref VideoFormat capability);

        ///
        /// @ignore
        ///
        public abstract int StartDeviceTest(IntPtr hwnd);

        ///
        /// @ignore
        ///
        public abstract int StopDeviceTest();

        #endregion terra IVideoDeviceManager
    }
}