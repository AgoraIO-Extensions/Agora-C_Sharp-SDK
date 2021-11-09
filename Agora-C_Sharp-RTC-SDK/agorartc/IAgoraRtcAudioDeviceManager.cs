//  IAgoraRtcAudioDeviceManager.cs
//
//  Created by YuGuo Chen on October 4, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    public abstract class IAgoraRtcAudioPlaybackDeviceManager
    {
        public abstract DeviceInfo[] EnumeratePlaybackDevices();

        public abstract int SetPlaybackDevice(string deviceId);

        public abstract string GetPlaybackDevice();

        public abstract DeviceInfo GetPlaybackDeviceInfo();

        public abstract int SetPlaybackDeviceVolume(int volume);

        public abstract int GetPlaybackDeviceVolume();

        public abstract int SetPlaybackDeviceMute(bool mute);

        public abstract bool GetPlaybackDeviceMute();

        public abstract int StartPlaybackDeviceTest(string testAudioFilePath);

        public abstract int StopPlaybackDeviceTest();

        public abstract int StartAudioDeviceLoopbackTest(int indicationInterval);

        public abstract int StopAudioDeviceLoopbackTest();
    }

    public abstract class IAgoraRtcAudioRecordingDeviceManager
    {
        public abstract DeviceInfo[] EnumerateRecordingDevices();

        public abstract int SetRecordingDevice(string deviceId);

        public abstract string GetRecordingDevice();

        public abstract DeviceInfo GetRecordingDeviceInfo();

        public abstract int SetRecordingDeviceVolume(int volume);

        public abstract int GetRecordingDeviceVolume();

        public abstract int SetRecordingDeviceMute(bool mute);

        public abstract bool GetRecordingDeviceMute();

        public abstract int StartRecordingDeviceTest(int indicationInterval);

        public abstract int StopRecordingDeviceTest();

        // public abstract int startAudioDeviceLoopbackTest(int indicationInterval);

        // public abstract int stopAudioDeviceLoopbackTest();
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}