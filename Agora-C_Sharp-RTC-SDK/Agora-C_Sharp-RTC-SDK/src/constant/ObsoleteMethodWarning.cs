//  IAgoraRtcEngine.cs
//
//  Created by Yiqing Huang on June 3, 2021.
//  Modified by Yiqing Huang on June 6, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

namespace agora.rtc
{
    internal static partial class ObsoleteMethodWarning
    {
        internal const string GeneralWarning = "This method is deprecated.";

        internal const string GetAudioEffectManagerWarning =
            "This method is deprecated. IAudioEffectManagerWarning is deprecated. All the methods can be called directly in AgoraRtcEngine.";

        internal const string GetAudioRecordingDeviceManagerWarning =
            "This method is deprecated. Please call GetAgoraRtcAudioRecordingDeviceManager instead.";

        internal const string GetAudioPlaybackDeviceManagerWarning =
            "This method is deprecated. Please call GetAgoraRtcAudioPlaybackDeviceManager instead.";

        internal const string GetVideoDeviceManagerWarning =
            "This method is deprecated. Please call GetAgoraRtcVideoDeviceManager instead.";

        internal const string JoinChannelByKeyWarning = "This method is deprecated. Please call JoinChannel instead.";

        internal const string SetLocalVoiceReverbPresetWarning =
            "This method is deprecated. Please call SetAudioEffectPresent or SetVoiceBeautifierPresent instead.";

        internal const string SetLogFileWarning =
            "This method is deprecated. Please use logConfig in the initialize method instead.";

        internal const string SetLogFilterWarning =
            "This method is deprecated. Please use logConfig in the initialize method instead.";

        internal const string SetLogFileSizeWarning =
            "This method is deprecated. Please use logConfig in the Initialize method instead.";

        internal const string SetLocalVideoMirrorModeWarning =
            "This method is deprecated. Please call SetupLocalVideo or SetLocalRenderMode instead.";

        internal const string SetEncryptionSecretWarning =
            "This method is deprecated. Please call EnableEncryption instead.";

        internal const string SetEncryptionModeWarning =
            "This method is deprecated. Please call EnableEncryption instead.";

        internal const string DestroyWarning = "This method is deprecated. Please call Dispose instead.";

        internal const string GeneralStructureWarning = "This structure is deprecated";

        internal const string ReleaseChannelWarning = "This method is deprecated. Please call Dispose instead";

        internal const string PublishWarning =
            "This method is deprecated. Please call muteLocalAudioStream(false) and muteLocalVideoStream(false) instead";

        internal const string UnpublishWarning =
            "This method is deprecated. Please call muteLocalAudioStream(true) and muteLocalVideoStream(true) instead";

        internal const string CreateChannelWarning =
            "This method is deprecated. Please call AgoraRtcEngine.CreateChannel instead";

        internal const string IVideoDeviceManagerWarning =
            "This class is deprecated. Please use IAgoraRtcVideoDeviceManager instead.";

        internal const string StartVideoDeviceTestWarning =
            "This method is deprecated. Please call IAgoraRtcVideoDeviceManager.StartDeviceTest instead.";

        internal const string StopVideoDeviceTestWarning =
            "This method is deprecated. Please call IAgoraRtcVideoDeviceManager.StopDeviceTest instead.";

        internal const string SetVideoDeviceWarning =
            "This method is deprecated. Please call IAgoraRtcVideoDeviceManager.SetDevice instead.";

        internal const string GetCurrentVideoDeviceWarning =
            "This method is deprecated. Please call IAgoraRtcVideoDeviceManager.GetDevice instead.";

        internal const string IAudioPlaybackDeviceManagerWarning =
            "This class is deprecated. Please use IAgoraRtcAudioPlaybackDeviceManager instead.";

        internal const string SetAudioPlaybackDeviceWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.SetPlaybackDevice instead.";

        internal const string SetAudioPlaybackDeviceVolumeWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.SetPlaybackDeviceVolume instead.";

        internal const string GetAudioPlaybackDeviceVolumeWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.GetPlaybackDeviceVolume instead.";

        internal const string SetAudioPlaybackDeviceMuteWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.SetPlaybackDeviceMute instead.";

        internal const string IsAudioPlaybackDeviceMuteWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.GetPlaybackDeviceMute instead.";

        internal const string StartAudioPlaybackDeviceTestWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.StartPlaybackDeviceTest instead.";

        internal const string StopAudioPlaybackDeviceTestWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.StopPlaybackDeviceTest instead.";

        internal const string GetCurrentPlaybackDeviceWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.GetPlaybackDevice instead.";

        internal const string GetCurrentPlaybackDeviceInfoWarning =
            "This method is deprecated. Please call IAgoraRtcAudioPlaybackDeviceManager.GetPlaybackDeviceInfo instead.";

        internal const string IAudioRecordingDeviceManagerWarning =
            "This class is deprecated. Please use IAgoraRtcAudioRecordingDeviceManager instead.";

        internal const string SetAudioRecordingDeviceWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.SetRecordingDevice instead.";

        internal const string StartAudioRecordingDeviceTestWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.StartRecordingDeviceTest instead.";

        internal const string StopAudioRecordingDeviceTestWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.StopRecordingDeviceTest instead.";

        internal const string GetCurrentRecordingDeviceWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.GetRecordingDevice instead.";

        internal const string SetAudioRecordingDeviceVolumeWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.SetRecordingDeviceVolume instead.";

        internal const string GetAudioRecordingDeviceVolumeWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.GetRecordingDeviceVolume instead.";

        internal const string SetAudioRecordingDeviceMuteWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.SetRecordingDeviceMute instead.";

        internal const string IsAudioRecordingDeviceMuteWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.GetRecordingDeviceMute instead.";

        internal const string GetCurrentRecordingDeviceInfoWarning =
            "This method is deprecated. Please call IAgoraRtcAudioRecordingDeviceManager.GetRecordingDeviceInfo instead.";

        internal const string IAudioEffectManagerWarning =
            "This class is deprecated. All the methods can be called directly in AgoraRtcEngine.";

        internal const string GetEffectsVolumeWarning =
            "This method is deprecated. Please AgoraRtcEngine.GetEffectsVolume instead.";

        internal const string SetEffectsVolumeWarning =
            "This method is deprecated. Please AgoraRtcEngine.SetEffectsVolume instead.";

        internal const string PlayEffectWarning =
            "This method is deprecated. Please AgoraRtcEngine.PlayEffect instead.";

        internal const string GetEffectDurationWarning =
            "This method is deprecated. Please AgoraRtcEngine.GetEffectDuration instead.";

        internal const string SetEffectPositionWarning =
            "This method is deprecated. Please AgoraRtcEngine.SetEffectPosition instead.";

        internal const string GetEffectCurrentPositionWarning =
            "This method is deprecated. Please AgoraRtcEngine.GetEffectCurrentPosition instead.";

        internal const string StopEffectWarning =
            "This method is deprecated. Please AgoraRtcEngine.StopEffect instead.";

        internal const string StopAllEffectsWarning =
            "This method is deprecated. Please AgoraRtcEngine.StopAllEffects instead.";

        internal const string PreloadEffectWarning =
            "This method is deprecated. Please AgoraRtcEngine.PreloadEffect instead.";

        internal const string UnloadEffectWarning =
            "This method is deprecated. Please AgoraRtcEngine.UnloadEffect instead.";

        internal const string PauseEffectWarning =
            "This method is deprecated. Please AgoraRtcEngine.PauseEffect instead.";

        internal const string PauseAllEffectsWarning =
            "This method is deprecated. Please AgoraRtcEngine.PauseAllEffects instead.";

        internal const string ResumeEffectWarning =
            "This method is deprecated. Please AgoraRtcEngine.ResumeEffect instead.";

        internal const string ResumeAllEffectsWarning =
            "This method is deprecated. Please AgoraRtcEngine.ResumeAllEffects instead.";

        internal const string SetRemoteVoicePositionWarning =
            "This method is deprecated. Please AgoraRtcEngine.SetRemoteVoicePosition instead.";

        internal const string SetLocalVoicePitchWarning =
            "This method is deprecated. Please AgoraRtcEngine.SetLocalVoicePitch instead.";
    }
}