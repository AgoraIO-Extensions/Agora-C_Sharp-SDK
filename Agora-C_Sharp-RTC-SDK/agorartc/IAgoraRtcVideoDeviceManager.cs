//  IAgoraRtcVideoDeviceManager.cs
//
//  Created by YuGuo Chen on October 4, 2021.
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

        public abstract int SetDevice(string deviceIdUTF8);

        public abstract string GetDevice();

        public abstract int StartDeviceTest(view_t hwnd);

        public abstract int StopDeviceTest();
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}