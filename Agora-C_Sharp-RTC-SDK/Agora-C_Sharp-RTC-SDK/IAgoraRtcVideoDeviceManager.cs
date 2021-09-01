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

    public abstract class IAgoraRtcVideoDeviceManager
    {
        public abstract DeviceInfo[] EnumerateVideoDevices();
        public abstract int StartDeviceTest(view_t hwnd);
        public abstract int StopDeviceTest();
        public abstract int SetDevice(string deviceId);
        public abstract string GetDevice();
    }

    [Obsolete(ObsoleteMethodWarning.IVideoDeviceManagerWarning, false)]
    public abstract class IVideoDeviceManager
    {
        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public abstract bool CreateAVideoDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public abstract int ReleaseAVideoDeviceManager();

        [Obsolete(ObsoleteMethodWarning.StartVideoDeviceTestWarning, false)]
        public abstract int StartVideoDeviceTest(view_t hwnd);

        [Obsolete(ObsoleteMethodWarning.StopVideoDeviceTestWarning, false)]
        public abstract int StopVideoDeviceTest();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetVideoDeviceCount();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetVideoDevice(int index, ref string deviceName, ref string deviceId);

        [Obsolete(ObsoleteMethodWarning.SetVideoDeviceWarning, false)]
        public abstract int SetVideoDevice(string deviceId);

        [Obsolete(ObsoleteMethodWarning.GetCurrentVideoDeviceWarning, false)]
        public abstract int GetCurrentVideoDevice(ref string deviceId);
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}