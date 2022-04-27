//  IAgoraRtcVideoDeviceManager.cs
//
//  Created by Yiqing Huang on June 7, 2021.
//  Modified by Yiqing Huang on June 7, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    using view_t = IntPtr;

    /**
     * Video device management methods.
     * IAgoraRtcVideoDeviceManager provides the methods related to testing video devices. You can get an IAgoraRtcVideoDeviceManager interface by instantiating the IAgoraRtcVideoDeviceManager class.
     */
    public abstract class IAgoraRtcVideoDeviceManager
    {
        /**
         * Enumerates the video devices.
         * @return
         * Success: Returns a DeviceInfo array that contains all the video devices.
         *  Failure: NULL.
         */
        public abstract DeviceInfo[] EnumerateVideoDevices();
        /**
         * Starts the video capture device test.
         * This method tests whether the video-capture device is working properly. Before calling this method, ensure that you have already called the EnableVideo method, and the window handle (hwnd) parameter is valid.
         * @param
         *  hwnd: The window handle used to display the screen.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartDeviceTest(view_t hwnd);
        /**
         * Stops the video capture device test.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopDeviceTest();
        /**
         * Specifies the video capture device with the device ID.
         * Plugging or unplugging a device does not change its device ID.
         * @param
         *  deviceId: The device ID. You can get the device ID by calling EnumerateVideoDevices .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetDevice(string deviceId);
        /**
         * Retrieves the current video capture device.
         * @return
         * The video capture device.
         */
        public abstract string GetDevice();
    }

    /**
     * Video device management methods.
     * IAgoraRtcVideoDeviceManager provides the methods related to testing video devices. You can get an IAgoraRtcVideoDeviceManager interface by instantiating the IAgoraRtcVideoDeviceManager class.
     */
    [Obsolete(ObsoleteMethodWarning.IVideoDeviceManagerWarning, false)]
    public abstract class IVideoDeviceManager
    {
        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public abstract bool CreateAVideoDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public abstract int ReleaseAVideoDeviceManager();

        /**
         * Starts the video capture device test.
         * This method tests whether the video-capture device is working properly. Before calling this method, ensure that you have already called the EnableVideo method, and the window handle (hwnd) parameter is valid.
         * @param
         *  hwnd: The window handle used to display the screen.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.StartVideoDeviceTestWarning, false)]
        public abstract int StartVideoDeviceTest(view_t hwnd);

        /**
         * Stops the video capture device test.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.StopVideoDeviceTestWarning, false)]
        public abstract int StopVideoDeviceTest();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetVideoDeviceCount();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetVideoDevice(int index, ref string deviceName, ref string deviceId);

        /**
         * Specifies the video capture device with the device ID.
         * Plugging or unplugging a device does not change its device ID.
         * @param
         *  deviceId: The device ID. You can get the device ID by calling EnumerateVideoDevices .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetVideoDeviceWarning, false)]
        public abstract int SetVideoDevice(string deviceId);

        /**
         * Retrieves the current video capture device.
         * @return
         * The video capture device.
         */
        [Obsolete(ObsoleteMethodWarning.GetCurrentVideoDeviceWarning, false)]
        public abstract int GetCurrentVideoDevice(ref string deviceId);
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}
