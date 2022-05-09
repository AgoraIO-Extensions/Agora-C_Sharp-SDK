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
    /**
     * Audio device management methods.
     * IAudioDeviceManager provides methods for audio device testing. You can get an IAudioDeviceManager interface by instantiating the IAudioDeviceManager class.
     */
    public abstract class IAgoraRtcAudioPlaybackDeviceManager
    {
        /**
         * Enumerates the audio playback devices.
         * @return
         * Success: Returns a DeviceInfo array that contains the device ID and device name of all the audio plauback devices.
         *  Failure: NULL.
         */
        public abstract DeviceInfo[] EnumeratePlaybackDevices();
        /**
         * Sets the audio playback device.
         * @param
         *  deviceId: The ID of the audio playback device. You can get the device ID by calling EnumeratePlaybackDevices . Plugging or unplugging the audio device does not change the device ID.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetPlaybackDevice(string deviceId);
        /**
         * Starts the audio playback device test.
         * @param
         *  testAudioFilePath: The path of the audio file for the audio playback device test in UTF-8. 
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartPlaybackDeviceTest(string testAudioFilePath);
        /**
         * Stops the audio playback device test.
         * This method stops the audio playback device test. You must call this method to stop the test after calling the StartPlaybackDeviceTest method.
         *  Ensure that you call this method before joining a channel.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopPlaybackDeviceTest();
        /**
         * Sets the volume of the audio playback device.
         * @param
         *  volume: The volume of the audio playback device. The value ranges between 0 (lowest volume) and 255 (highest volume).
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetPlaybackDeviceVolume(int volume);
        /**
         * Retrieves the volume of the audio playback device.
         * @return
         * The volume of the audio playback device. The value ranges between 0 (lowest volume) and 255 (highest volume).
         */
        public abstract int GetPlaybackDeviceVolume();
        /**
         * Mutes the audio playback device.
         * @param
         *  mute: Whether to mute the audio playback device:
         *  true: Mute the audio playback device.
         *  false: Unmute the audio playback device.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetPlaybackDeviceMute(bool mute);
        /**
         * Retrieves whether the audio playback device is muted.
         * @return
         * true: The audio playback device is muted.
         * false: The audio playback device is unmuted.
         */
        public abstract bool GetPlaybackDeviceMute();
        /**
         * Retrieves the audio playback device associated with the device ID.
         * @return
         * The current audio playback device.
         */
        public abstract string GetPlaybackDevice();
        /**
         * Retrieves the audio playback device information associated with the device ID and device name.
         * @return
         * The information of the audio playback device, which includes the device ID and the device name.
         */
        public abstract DeviceInfo GetPlaybackDeviceInfo();
        /**
         * Starts an audio device loopback test.
         * @param
         *  indicationInterval: The time interval (ms) at which the SDK triggers the OnAudioVolumeIndication or OnAudioDeviceTestVolumeIndication callback. Agora recommends a setting greater than 200 ms. This value must not be less than 10 ms; otherwise, you can not receive these callbacks.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartAudioDeviceLoopbackTest(int indicationInterval);
        /**
         * Stops the audio device loopback test.
         * Ensure that you call this method before joining a channel.
         *  Ensure that you call this method to stop the loopback test after calling the StartAudioDeviceLoopbackTest method.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopAudioDeviceLoopbackTest();
        /**
         * Sets the audio playback device used by the SDK to follow the system default audio playback device.
         * @param
         *  enable: Whether to follow the system default audio playback device: 
         *  true: Follow. The SDK immediately switches the audio playback device when the system default audio playback device changes.
         *  false: Do not follow. The SDK switches the audio playback device to the system default audio playback device only when the currently used audio playback device is disconnected.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int FollowSystemPlaybackDevice(bool enable);
    }

    /**
     * Audio device management methods.
     * IAudioDeviceManager provides methods for audio device testing. You can get an IAudioDeviceManager interface by instantiating the IAudioDeviceManager class.
     */
    public abstract class IAgoraRtcAudioRecordingDeviceManager
    {
        /**
         * Enumerates the audio capture devices.
         * @return
         * Success: Returns a DeviceInfo array that contains the device ID and device name of all the audio recording devices.
         *  Failure: NULL.
         */
        public abstract DeviceInfo[] EnumerateRecordingDevices();
        /**
         * Sets the audio capture device.
         * @param
         *  deviceId: The ID of the audio capture device. You can get the device ID by calling EnumerateRecordingDevices . Plugging or unplugging the audio device does not change the device ID.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRecordingDevice(string deviceId);
        /**
         * Sets the volume of the audio capture device.
         * @param
         *  volume: The volume of the audio recording device. The value ranges between 0 (lowest volume) and 255 (highest volume).
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRecordingDeviceVolume(int volume);
        /**
         * Retrieves the volume of the audio recording device.
         * @return
         * The volume of the audio recording device. The value ranges between 0 (lowest volume) and 255 (highest volume).
         */
        public abstract int GetRecordingDeviceVolume();
        /**
         * Sets the mute status of the audio capture device.
         * @param
         *  mute: Whether to mute the audio capture device:
         *  true: Mute the audio capture device.
         *  false: Unmute the audio capture device.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRecordingDeviceMute(bool mute);
        /**
         * Gets the microphone's mute status.
         * @return
         * true: The microphone is muted.
         *  false: The microphone is unmuted.
         */
        public abstract bool GetRecordingDeviceMute();
        /**
         * Starts the audio capture device test.
         * @param
         *  indicationInterval: The time interval (ms) at which the SDK triggers the OnAudioVolumeIndication or OnAudioDeviceTestVolumeIndication callback. Agora recommends a setting greater than 200 ms. This value must not be less than 10 ms; otherwise, you can not receive the OnAudioVolumeIndication or OnAudioDeviceTestVolumeIndication callback.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartRecordingDeviceTest(int indicationInterval);
        /**
         * Stops the audio capture device test.
         * This method stops the audio capture device test. You must call this method to stop the test after calling the StartRecordingDeviceTest method.
         *  Ensure that you call this method before joining a channel.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopRecordingDeviceTest();
        /**
         * Gets the current audio recording device.
         * @return
         * The current audio recording device.
         */
        public abstract string GetRecordingDevice();
        /**
         * Retrieves the audio capture device information associated with the device ID and device name.
         * @return
         * A DeviceInfo array that contains the device ID and device name of all the audio recording devices.
         */
        public abstract DeviceInfo GetRecordingDeviceInfo();
        /**
         * Sets the audio recording device used by the SDK to follow the system default audio recording device.
         * @param
         *  enable: Whether to follow the system default audio recording device: true: Follow. The SDK immediately switches the audio recording device when the system default audio recording device changes.
         *  false: Do not follow. The SDK switches the audio recording device to the system default audio recording device only when the currently used audio recording device is disconnected.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int FollowSystemRecordingDevice(bool enable);
    }

    /**
     * Audio device management methods.
     * IAudioDeviceManager provides methods for audio device testing. You can get an IAudioDeviceManager interface by instantiating the IAudioDeviceManager class.
     */
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

        /**
         * Sets the audio playback device.
         * @param
         *  deviceId: The ID of the audio playback device. You can get the device ID by calling EnumeratePlaybackDevices . Plugging or unplugging the audio device does not change the device ID.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceWarning, false)]
        public abstract int SetAudioPlaybackDevice(string deviceId);

        /**
         * Sets the volume of the audio playback device.
         * @param
         *  volume: The volume of the audio playback device. The value ranges between 0 (lowest volume) and 255 (highest volume).
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceVolumeWarning, false)]
        public abstract int SetAudioPlaybackDeviceVolume(int volume);

        /**
         * Retrieves the volume of the audio playback device.
         * @return
         * The volume of the audio playback device. The value ranges between 0 (lowest volume) and 255 (highest volume).
         */
        [Obsolete(ObsoleteMethodWarning.GetAudioPlaybackDeviceVolumeWarning, false)]
        public abstract int GetAudioPlaybackDeviceVolume();

        /**
         * Mutes the audio playback device.
         * @param
         *  mute: Whether to mute the audio playback device:
         *  true: Mute the audio playback device.
         *  false: Unmute the audio playback device.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceMuteWarning, false)]
        public abstract int SetAudioPlaybackDeviceMute(bool mute);

        /**
         * Retrieves whether the audio playback device is muted.
         * @return
         * true: The audio playback device is muted.
         * false: The audio playback device is unmuted.
         */
        [Obsolete(ObsoleteMethodWarning.IsAudioPlaybackDeviceMuteWarning, false)]
        public abstract bool IsAudioPlaybackDeviceMute();

        /**
         * Starts the audio playback device test.
         * @param
         *  testAudioFilePath: The path of the audio file for the audio playback device test in UTF-8. 
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.StartAudioPlaybackDeviceTestWarning, false)]
        public abstract int StartAudioPlaybackDeviceTest(string testAudioFilePath);

        /**
         * Stops the audio playback device test.
         * This method stops the audio playback device test. You must call this method to stop the test after calling the StartPlaybackDeviceTest method.
         *  Ensure that you call this method before joining a channel.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.StopAudioPlaybackDeviceTestWarning, false)]
        public abstract int StopAudioPlaybackDeviceTest();

        /**
         * Retrieves the audio playback device associated with the device ID.
         * @return
         * The current audio playback device.
         */
        [Obsolete(ObsoleteMethodWarning.GetCurrentPlaybackDeviceWarning, false)]
        public abstract int GetCurrentPlaybackDevice(ref string deviceId);

        [Obsolete(ObsoleteMethodWarning.GetCurrentPlaybackDeviceInfoWarning, false)]
        public abstract int GetCurrentPlaybackDeviceInfo(ref string deviceName, ref string deviceId);
    }

    /**
     * Audio device management methods.
     * IAudioDeviceManager provides methods for audio device testing. You can get an IAudioDeviceManager interface by instantiating the IAudioDeviceManager class.
     */
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

        /**
         * Sets the audio capture device.
         * @param
         *  deviceId: The ID of the audio capture device. You can get the device ID by calling EnumerateRecordingDevices . Plugging or unplugging the audio device does not change the device ID.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceWarning, false)]
        public abstract int SetAudioRecordingDevice(string deviceId);

        /**
         * Starts the audio capture device test.
         * @param
         *  indicationInterval: The time interval (ms) at which the SDK triggers the OnAudioVolumeIndication or OnAudioDeviceTestVolumeIndication callback. Agora recommends a setting greater than 200 ms. This value must not be less than 10 ms; otherwise, you can not receive the OnAudioVolumeIndication or OnAudioDeviceTestVolumeIndication callback.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.StartAudioRecordingDeviceTestWarning, false)]
        public abstract int StartAudioRecordingDeviceTest(int indicationInterval);

        /**
         * Stops the audio capture device test.
         * This method stops the audio capture device test. You must call this method to stop the test after calling the StartRecordingDeviceTest method.
         *  Ensure that you call this method before joining a channel.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.StopAudioRecordingDeviceTestWarning, false)]
        public abstract int StopAudioRecordingDeviceTest();

        /**
         * Gets the current audio recording device.
         * @return
         * The current audio recording device.
         */
        [Obsolete(ObsoleteMethodWarning.GetCurrentRecordingDeviceWarning, false)]
        public abstract int GetCurrentRecordingDevice(ref string deviceId);

        /**
         * Sets the volume of the audio capture device.
         * @param
         *  volume: The volume of the audio recording device. The value ranges between 0 (lowest volume) and 255 (highest volume).
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceVolumeWarning, false)]
        public abstract int SetAudioRecordingDeviceVolume(int volume);

        /**
         * Retrieves the volume of the audio recording device.
         * @return
         * The volume of the audio recording device. The value ranges between 0 (lowest volume) and 255 (highest volume).
         */
        [Obsolete(ObsoleteMethodWarning.GetAudioRecordingDeviceVolumeWarning, false)]
        public abstract int GetAudioRecordingDeviceVolume();

        /**
         * Sets the mute status of the audio capture device.
         * @param
         *  mute: Whether to mute the audio capture device:
         *  true: Mute the audio capture device.
         *  false: Unmute the audio capture device.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceMuteWarning, false)]
        public abstract int SetAudioRecordingDeviceMute(bool mute);

        /**
         * Gets the microphone's mute status.
         * @return
         * true: The microphone is muted.
         *  false: The microphone is unmuted.
         */
        [Obsolete(ObsoleteMethodWarning.IsAudioRecordingDeviceMuteWarning, false)]
        public abstract bool IsAudioRecordingDeviceMute();

        [Obsolete(ObsoleteMethodWarning.GetCurrentRecordingDeviceInfoWarning, false)]
        public abstract int GetCurrentRecordingDeviceInfo(ref string deviceName, ref string deviceId);
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}
