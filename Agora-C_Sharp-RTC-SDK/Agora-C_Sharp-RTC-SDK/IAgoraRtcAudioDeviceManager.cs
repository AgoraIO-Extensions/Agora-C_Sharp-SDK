//  IAgoraRtcAudioDeviceManager.cs
//
//  Created by Yiqing Huang on June 7, 2021.
//  Modified by Yiqing Huang on June 8, 2021.
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
        public abstract int StartPlaybackDeviceTest(string testAudioFilePath);
        public abstract int StopPlaybackDeviceTest();
        public abstract int SetPlaybackDeviceVolume(int volume);
        public abstract int GetPlaybackDeviceVolume();
        public abstract int SetPlaybackDeviceMute(bool mute);
        public abstract bool GetPlaybackDeviceMute();
        public abstract string GetPlaybackDevice();
        public abstract DeviceInfo GetPlaybackDeviceInfo();
        public abstract int StartAudioDeviceLoopbackTest(int indicationInterval);
        public abstract int StopAudioDeviceLoopbackTest();
    }

    public abstract class IAgoraRtcAudioRecordingDeviceManager
    {
        public abstract DeviceInfo[] EnumerateRecordingDevices();
        public abstract int SetRecordingDevice(string deviceId);
        public abstract int SetRecordingDeviceVolume(int volume);
        public abstract int GetRecordingDeviceVolume();
        public abstract int SetRecordingDeviceMute(bool mute);
        public abstract bool GetRecordingDeviceMute();
        public abstract int StartRecordingDeviceTest(int indicationInterval);
        public abstract int StopRecordingDeviceTest();
        public abstract string GetRecordingDevice();
        public abstract DeviceInfo GetRecordingDeviceInfo();
    }

    [Obsolete(ObsoleteMethodWarning.IAudioPlaybackDeviceManagerWarning, false)]
    public abstract class IAudioPlaybackDeviceManager
    {
        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public abstract bool CreateAAudioPlaybackDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public abstract int ReleaseAAudioPlaybackDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetAudioPlaybackDeviceCount();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetAudioPlaybackDevice(int index, ref string deviceName, ref string deviceId);

        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceWarning, false)]
        public abstract int SetAudioPlaybackDevice(string deviceId);

        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceVolumeWarning, false)]
        public abstract int SetAudioPlaybackDeviceVolume(int volume);

        [Obsolete(ObsoleteMethodWarning.GetAudioPlaybackDeviceVolumeWarning, false)]
        public abstract int GetAudioPlaybackDeviceVolume();

        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceMuteWarning, false)]
        public abstract int SetAudioPlaybackDeviceMute(bool mute);

        [Obsolete(ObsoleteMethodWarning.IsAudioPlaybackDeviceMuteWarning, false)]
        public abstract bool IsAudioPlaybackDeviceMute();

        [Obsolete(ObsoleteMethodWarning.StartAudioPlaybackDeviceTestWarning, false)]
        public abstract int StartAudioPlaybackDeviceTest(string testAudioFilePath);

        [Obsolete(ObsoleteMethodWarning.StopAudioPlaybackDeviceTestWarning, false)]
        public abstract int StopAudioPlaybackDeviceTest();

        [Obsolete(ObsoleteMethodWarning.GetCurrentPlaybackDeviceWarning, false)]
        public abstract int GetCurrentPlaybackDevice(ref string deviceId);

        [Obsolete(ObsoleteMethodWarning.GetCurrentPlaybackDeviceInfoWarning, false)]
        public abstract int GetCurrentPlaybackDeviceInfo(ref string deviceName, ref string deviceId);
    }

    [Obsolete(ObsoleteMethodWarning.IAudioRecordingDeviceManagerWarning, false)]
    public abstract class IAudioRecordingDeviceManager
    {
        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public abstract bool CreateAAudioRecordingDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public abstract int ReleaseAAudioRecordingDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetAudioRecordingDeviceCount();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetAudioRecordingDevice(int index, ref string audioRecordingDeviceName,
            ref string audioRecordingDeviceId);

        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceWarning, false)]
        public abstract int SetAudioRecordingDevice(string deviceId);

        [Obsolete(ObsoleteMethodWarning.StartAudioRecordingDeviceTestWarning, false)]
        public abstract int StartAudioRecordingDeviceTest(int indicationInterval);

        [Obsolete(ObsoleteMethodWarning.StopAudioRecordingDeviceTestWarning, false)]
        public abstract int StopAudioRecordingDeviceTest();

        [Obsolete(ObsoleteMethodWarning.GetCurrentRecordingDeviceWarning, false)]
        public abstract int GetCurrentRecordingDevice(ref string deviceId);

        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceVolumeWarning, false)]
        public abstract int SetAudioRecordingDeviceVolume(int volume);

        [Obsolete(ObsoleteMethodWarning.GetAudioRecordingDeviceVolumeWarning, false)]
        public abstract int GetAudioRecordingDeviceVolume();

        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceMuteWarning, false)]
        public abstract int SetAudioRecordingDeviceMute(bool mute);

        [Obsolete(ObsoleteMethodWarning.IsAudioRecordingDeviceMuteWarning, false)]
        public abstract bool IsAudioRecordingDeviceMute();

        [Obsolete(ObsoleteMethodWarning.GetCurrentRecordingDeviceInfoWarning, false)]
        public abstract int GetCurrentRecordingDeviceInfo(ref string deviceName, ref string deviceId);
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}