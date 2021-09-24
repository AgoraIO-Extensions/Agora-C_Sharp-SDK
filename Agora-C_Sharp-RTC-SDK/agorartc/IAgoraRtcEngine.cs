//  IAgoraRtcEngine.cs
//
//  Created by Yiqing Huang on June 1, 2021.
//  Modified by Yiqing Huang on July 21, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    using view_t = UInt64;

    public abstract class IAgoraRtcEngine : IRtcEngine
    {
    }

    public abstract class IRtcEngine
    {
        public abstract int Initialize(RtcEngineContext context);
        public abstract void InitEventHandler(IAgoraRtcEngineEventHandler engineEventHandler);
        public abstract void RegisterAudioFrameObserver(IAgoraRtcAudioFrameObserver audioFrameObserver);
        public abstract void UnRegisterAudioFrameObserver();
        public abstract void RegisterVideoFrameObserver(IAgoraRtcVideoFrameObserver videoFrameObserver);
        public abstract void UnRegisterVideoFrameObserver();
        public abstract void Dispose(bool sync = false);

        [Obsolete(ObsoleteMethodWarning.GetAudioEffectManagerWarning, false)]
        public abstract IAudioEffectManager GetAudioEffectManager();

        [Obsolete(ObsoleteMethodWarning.GetAudioRecordingDeviceManagerWarning, false)]
        public abstract IAudioRecordingDeviceManager GetAudioRecordingDeviceManager();

        public abstract IAgoraRtcAudioRecordingDeviceManager GetAgoraRtcAudioRecordingDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GetAudioPlaybackDeviceManagerWarning, false)]
        public abstract IAudioPlaybackDeviceManager GetAudioPlaybackDeviceManager();

        public abstract IAgoraRtcAudioPlaybackDeviceManager GetAgoraRtcAudioPlaybackDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GetVideoDeviceManagerWarning, false)]
        public abstract IVideoDeviceManager GetVideoDeviceManager();

        public abstract IAgoraRtcVideoDeviceManager GetAgoraRtcVideoDeviceManager();
        public abstract IAgoraRtcChannel CreateChannel(string channelId);
        public abstract int SetChannelProfile(CHANNEL_PROFILE_TYPE profile);
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options);
        public abstract int JoinChannel(string token, string channelId, string info = "", uint uid = 0);

        public abstract int JoinChannel(string token, string channelId, string info, uint uid,
            ChannelMediaOptions options);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int JoinChannel(string channelId, string info = "", uint uid = 0);

        [Obsolete(ObsoleteMethodWarning.JoinChannelByKeyWarning, false)]
        public abstract int JoinChannelByKey(string token, string channelId, string info = "", uint uid = 0);

        public abstract int SwitchChannel(string token, string channelId);
        public abstract int SwitchChannel(string token, string channelId, ChannelMediaOptions options);
        public abstract int LeaveChannel();
        public abstract int RenewToken(string token);
        public abstract int RegisterLocalUserAccount(string appId, string userAccount);
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount,
            ChannelMediaOptions options);

        public abstract int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract UserInfo GetUserInfoByUserAccount(string userAccount);

        public abstract int GetUserInfoByUid(uint uid, out UserInfo userInfo);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract UserInfo GetUserInfoByUid(uint uid);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int StartEchoTest();

        public abstract int StartEchoTest(int intervalInSeconds);
        public abstract int StopEchoTest();
        public abstract int SetCloudProxy(CLOUD_PROXY_TYPE proxyType);
        public abstract int EnableVideo();
        public abstract int DisableVideo();
        public abstract int EnableVideoObserver();
        public abstract int DisableVideoObserver();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetVideoProfile(VIDEO_PROFILE_TYPE profile, bool swapWidthAndHeight = false);

        public abstract int SetVideoEncoderConfiguration(VideoEncoderConfiguration config);
        public abstract int SetCameraCapturerConfiguration(CameraCapturerConfiguration config);
        public abstract int SetupLocalVideo(VideoCanvas canvas);
        public abstract int SetupRemoteVideo(VideoCanvas canvas);
        public abstract int StartPreview();
        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);
        public abstract int StopPreview();
        public abstract int EnableAudio();
        public abstract int EnableLocalAudio(bool enabled);
        public abstract int DisableAudio();
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);
        public abstract int MuteLocalAudioStream(bool mute);
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);
        public abstract int MuteRemoteAudioStream(uint userId, bool mute);
        public abstract int MuteLocalVideoStream(bool mute);
        public abstract int EnableLocalVideo(bool enabled);
        public abstract int MuteAllRemoteVideoStreams(bool mute);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        public abstract int MuteRemoteVideoStream(uint userId, bool mute);
        public abstract int SetRemoteVideoStreamType(uint userId, REMOTE_VIDEO_STREAM_TYPE streamType);
        public abstract int SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType);
        public abstract int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        public abstract int StartAudioRecording(AudioRecordingConfiguration config);

        public abstract int StopAudioRecording();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle);

        public abstract int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int startPos);
        public abstract int StopAudioMixing();
        public abstract int PauseAudioMixing();
        public abstract int ResumeAudioMixing();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetHighQualityAudioParameters(bool fullband, bool stereo, bool fullBitrate);

        public abstract int AdjustAudioMixingVolume(int volume);
        public abstract int AdjustAudioMixingPlayoutVolume(int volume);
        public abstract int GetAudioMixingPlayoutVolume();
        public abstract int AdjustAudioMixingPublishVolume(int volume);
        public abstract int GetAudioMixingPublishVolume();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetAudioMixingDuration();

        public abstract int GetAudioMixingDuration(string filePath);

        public abstract int GetAudioMixingCurrentPosition();
        public abstract int SetAudioMixingPosition(int pos);
        public abstract int SetAudioMixingPitch(int pitch);
        public abstract int GetEffectsVolume();
        public abstract int SetEffectsVolume(int volume);
        public abstract int SetVolumeOfEffect(int soundId, int volume);
        public abstract int EnableFaceDetection(bool enable);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int PlayEffect(int soundId, string filePath, int loopCount, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false);

        public abstract int PlayEffect(int soundId, string filePath, int loopCount, int startPos, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false);

        public abstract int StopEffect(int soundId);
        public abstract int StopAllEffects();
        public abstract int PreloadEffect(int soundId, string filePath);
        public abstract int UnloadEffect(int soundId);
        public abstract int PauseEffect(int soundId);
        public abstract int PauseAllEffects();
        public abstract int ResumeEffect(int soundId);
        public abstract int ResumeAllEffects();
        public abstract int GetEffectDuration();
        public abstract int SetEffectPosition(int soundId, int pos);
        public abstract int GetEffectCurrentPosition(int soundId);
        public abstract int EnableDeepLearningDenoise(bool enable);
        public abstract int EnableSoundPositionIndication(bool enabled);
        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);
        public abstract int SetLocalVoicePitch(double pitch);
        public abstract int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);
        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger);

        [Obsolete(ObsoleteMethodWarning.SetLocalVoiceReverbPresetWarning, false)]
        public abstract int SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset);

        public abstract int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset);
        public abstract int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset);
        public abstract int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset);
        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);
        public abstract int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2);

        [Obsolete(ObsoleteMethodWarning.SetLogFileWarning, false)]
        public abstract int SetLogFile(string filePath);

        [Obsolete(ObsoleteMethodWarning.SetLogFilterWarning, false)]
        public abstract int SetLogFilter(uint filter);

        [Obsolete(ObsoleteMethodWarning.SetLogFileSizeWarning, false)]
        public abstract int SetLogFileSize(uint fileSizeInKBytes);

        public abstract string UploadLogFile();

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode);

        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode);

        public abstract int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode);

        [Obsolete(ObsoleteMethodWarning.SetLocalVideoMirrorModeWarning, false)]
        public abstract int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int EnableDualStreamMode(bool enabled);
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels);
        public abstract int SetExternalAudioSink(bool enabled, int sampleRate, int channels);

        public abstract int SetRecordingAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetPlaybackAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetMixedAudioFrameParameters(int sampleRate, int samplesPerCall);
        public abstract int AdjustRecordingSignalVolume(int volume);
        public abstract int AdjustPlaybackSignalVolume(int volume);
        public abstract int AdjustLoopbackRecordingSignalVolume(int volume);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int EnableWebSdkInteroperability(bool enabled);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetVideoQualityParameters(bool preferFrameRateOverImageQuality);

        public abstract int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option);
        public abstract int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option);
        public abstract int SwitchCamera();
        public abstract int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker);
        public abstract int SetEnableSpeakerphone(bool speakerOn);
        public abstract int EnableInEarMonitoring(bool enabled);
        public abstract int SetInEarMonitoringVolume(int volume);
        public abstract bool IsSpeakerphoneEnabled();
        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);
        public abstract int EnableLoopbackRecording(bool enabled, string deviceName);

        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect,
            ScreenCaptureParameters captureParams);

        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect,
            ScreenCaptureParameters captureParams);

        public abstract int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect,
            ScreenCaptureParameters captureParams);

        public abstract int SetScreenCaptureContentHint(VideoContentHint contentHint);
        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);
        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);
        public abstract int StopScreenCapture();
        public abstract string GetCallId();
        public abstract int Rate(string callId, int rating, string description = "");
        public abstract int Complain(string callId, string description = "");
        public abstract string GetVersion();
        public abstract int EnableLastmileTest();
        public abstract int DisableLastmileTest();
        public abstract int StartLastmileProbeTest(LastmileProbeConfig config);
        public abstract int StopLastmileProbeTest();
        public abstract string GetErrorDescription(int code);

        [Obsolete(ObsoleteMethodWarning.SetEncryptionSecretWarning, false)]
        public abstract int SetEncryptionSecret(string secret);

        [Obsolete(ObsoleteMethodWarning.SetEncryptionModeWarning, false)]
        public abstract int SetEncryptionMode(string encryptionMode);

        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);
        public abstract int RegisterPacketObserver(IPacketObserver observer);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int CreateDataStream(bool reliable, bool ordered);

        public abstract int CreateDataStream(DataStreamConfig config);
        public abstract int SendStreamMessage(int streamId, byte[] data);
        public abstract int AddPublishStreamUrl(string url, bool transcodingEnabled);
        public abstract int RemovePublishStreamUrl(string url);
        public abstract int SetLiveTranscoding(LiveTranscoding transcoding);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int AddVideoWatermark(RtcImage watermark);

        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);
        public abstract int ClearVideoWatermarks();
        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options);
        public abstract int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource);
        public abstract int AddInjectStreamUrl(string url, InjectStreamConfig config);
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);
        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);
        public abstract int StopChannelMediaRelay();
        public abstract int RemoveInjectStreamUrl(string url);
        public abstract int SendCustomReportMessage(string id, string category, string events, string label, int value);
        public abstract CONNECTION_STATE_TYPE GetConnectionState();
        public abstract int RegisterMediaMetadataObserver(METADATA_TYPE type);
        public abstract int UnRegisterMediaMetadataObserver(METADATA_TYPE type);
        public abstract int EnableRemoteSuperResolution(uint userId, bool enable);
        public abstract int SetParameters(string parameters);
        public abstract int SetMaxMetadataSize(int size);
        public abstract int SendMetadata(Metadata metadata);
        public abstract int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap);
        public abstract int PushAudioFrame(AudioFrame frame);
        public abstract int PullAudioFrame(AudioFrame frame);
        public abstract int SetExternalVideoSource(bool enable, bool useTexture = false);
        public abstract int PushVideoFrame(ExternalVideoFrame frame);
    }

    public abstract class IAgoraRtcEngineEventHandler
    {
        public virtual void OnWarning(int warn, string msg)
        {
        }

        public virtual void OnError(int err, string msg)
        {
        }

        public virtual void OnJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
        }

        public virtual void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
        }

        public virtual void OnLeaveChannel(RtcStats stats)
        {
        }

        public virtual void OnClientRoleChanged(CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
        }

        public virtual void OnUserJoined(uint uid, int elapsed)
        {
        }

        public virtual void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        public virtual void OnLastmileQuality(int quality)
        {
        }

        public virtual void OnLastmileProbeResult(LastmileProbeResult result)
        {
        }

        [Obsolete(
            "Deprecated since v2.3.2. Replaced by the onConnectionStateChanged(CONNECTION_STATE_RECONNECTING, CONNECTION_CHANGED_INTERRUPTED) callback",
            false)]
        public virtual void OnConnectionInterrupted()
        {
        }

        public virtual void OnConnectionLost()
        {
        }

        [Obsolete(
            "Deprecated since v2.3.2. Replaced by the onConnectionStateChanged(CONNECTION_STATE_FAILED, CONNECTION_CHANGED_BANNED_BY_SERVER) callback",
            false)]
        public virtual void OnConnectionBanned()
        {
        }

        public virtual void OnApiCallExecuted(int err, string api, string result)
        {
        }

        public virtual void OnRequestToken()
        {
        }

        public virtual void OnTokenPrivilegeWillExpire(string token)
        {
        }

        [Obsolete("Deprecated since v2.3.2. Use the onRemoteAudioStats callback instead",
            false)]
        public virtual void OnAudioQuality(uint uid, int quality, ushort delay, ushort lost)
        {
        }

        public virtual void OnRtcStats(RtcStats stats)
        {
        }

        public virtual void OnNetworkQuality(uint uid, int txQuality, int rxQuality)
        {
        }

        public virtual void OnLocalVideoStats(LocalVideoStats stats)
        {
        }

        public virtual void OnRemoteVideoStats(RemoteVideoStats stats)
        {
        }

        public virtual void OnLocalAudioStats(LocalAudioStats stats)
        {
        }

        public virtual void OnRemoteAudioStats(RemoteAudioStats stats)
        {
        }

        public virtual void OnLocalAudioStateChanged(LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
        }

        public virtual void OnRemoteAudioStateChanged(uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnAudioVolumeIndication(AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
        }

        public virtual void OnActiveSpeaker(uint uid)
        {
        }

        [Obsolete("Deprecated since v2.4.1. Use LOCAL_VIDEO_STREAM_STATE_STOPPED(0) in the onLocalVideoStateChanged callback instead",
            false)]
        public virtual void OnVideoStopped()
        {
        }

        public virtual void OnFirstLocalVideoFrame(int width, int height, int elapsed)
        {
        }

        public virtual void OnFirstLocalVideoFramePublished(int elapsed)
        {
        }

        public virtual void OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed)
        {
        }

        public virtual void OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed)
        {
        }

        public virtual void OnUserMuteAudio(uint uid, bool muted)
        {
        }

        public virtual void OnUserMuteVideo(uint uid, bool muted)
        {
        }

        public virtual void OnUserEnableVideo(uint uid, bool enabled)
        {
        }

        public virtual void OnAudioDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
        }

        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
        }

        [Obsolete("Deprecated since v2.4.1. Use LOCAL_VIDEO_STREAM_STATE_CAPTURING (1) in the onLocalVideoStateChanged callback instead",
            false)]
        public virtual void OnCameraReady()
        {
        }

        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
        }

        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle vecRectangle,
            int[] vecDistance, int numFaces)
        {
        }

        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
        }

        [Obsolete("This method is deprecated, use onAudioMixingStateChanged instead",
            false)]
        public virtual void OnAudioMixingFinished()
        {
        }

        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
        }

        public virtual void OnRemoteAudioMixingBegin()
        {
        }

        public virtual void OnRemoteAudioMixingEnd()
        {
        }

        public virtual void OnAudioEffectFinished(int soundId)
        {
        }

        [Obsolete(
            "Deprecated since v3.0.0. Use onRemoteAudioStateChanged instead",
            false)]
        public virtual void OnFirstRemoteAudioDecoded(uint uid, int elapsed)
        {
        }

        public virtual void OnVideoDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
        }

        public virtual void OnLocalVideoStateChanged(LOCAL_VIDEO_STREAM_STATE localVideoState,
            LOCAL_VIDEO_STREAM_ERROR error)
        {
        }

        public virtual void OnVideoSizeChanged(uint uid, int width, int height, int rotation)
        {
        }

        public virtual void OnRemoteVideoStateChanged(uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnUserEnableLocalVideo(uint uid, bool enabled)
        {
        }

        public virtual void OnStreamMessage(uint uid, int streamId, byte[] data, uint length)
        {
        }

        public virtual void OnStreamMessageError(uint uid, int streamId, int code, int missed, int cached)
        {
        }

        public virtual void OnMediaEngineLoadSuccess()
        {
        }

        public virtual void OnMediaEngineStartCallSuccess()
        {
        }

        public virtual void OnVirtualBackgroundSourceEnabled(bool enabled,
            VIRTUAL_BACKGROUND_SOURCE_STATE_REASON reason)
        {
        }

        public virtual void OnUserSuperResolutionEnabled(uint uid, bool enabled, SUPER_RESOLUTION_STATE_REASON reason)
        {
        }

        public virtual void OnChannelMediaRelayStateChanged(CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
        }

        public virtual void OnChannelMediaRelayEvent(CHANNEL_MEDIA_RELAY_EVENT code)
        {
        }

        [Obsolete("Deprecated since v3.1.0. Use the onFirstLocalAudioFramePublished callback instead",
            false)]
        public virtual void OnFirstLocalAudioFrame(int elapsed)
        {
        }

        public virtual void OnFirstLocalAudioFramePublished(int elapsed)
        {
        }

        [Obsolete(
            "Deprecated since v3.0.0. Use onRemoteAudioStateChanged instead",
            false)]
        public virtual void OnFirstRemoteAudioFrame(uint uid, int elapsed)
        {
        }

        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state,
            RTMP_STREAM_PUBLISH_ERROR errCode)
        {
        }

        public virtual void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        [Obsolete("This method is deprecated, use the onRtmpStreamingStateChanged callback instead",
            false)]
        public virtual void OnStreamPublished(string url, int error)
        {
        }

        [Obsolete("This method is deprecated, use the onRtmpStreamingStateChanged callback instead",
            false)]
        public virtual void OnStreamUnpublished(string url)
        {
        }

        public virtual void OnTranscodingUpdated()
        {
        }

        public virtual void OnStreamInjectedStatus(string url, uint uid, int status)
        {
        }

        public virtual void OnAudioRouteChanged(AUDIO_ROUTE_TYPE routing)
        {
        }

        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
        }

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
        }

        [Obsolete("This callback is deprecated and replaced by the onRemoteAudioStats callback",
            false)]
        public virtual void OnRemoteAudioTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        [Obsolete("This callback is deprecated and replaced by the onRemoteVideoStats callback",
            false)]
        public virtual void OnRemoteVideoTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        [Obsolete("Deprecated since v2.9.0. Use Use LOCAL_AUDIO_STREAM_STATE_STOPPED (0) or LOCAL_AUDIO_STREAM_STATE_RECORDING (1) in the onLocalAudioStateChanged callback instead",
            false)]
        public virtual void OnMicrophoneEnabled(bool enabled)
        {
        }

        public virtual void OnConnectionStateChanged(CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        public virtual void OnNetworkTypeChanged(NETWORK_TYPE type)
        {
        }

        public virtual void OnLocalUserRegistered(uint uid, string userAccount)
        {
        }

        public virtual void OnUserInfoUpdated(uint uid, UserInfo info)
        {
        }

        public virtual void OnUploadLogResult(string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
        }

        public virtual bool OnReadyToSendMetadata(Metadata metadata)
        {
            return true;
        }

        public virtual void OnMetadataReceived(Metadata metadata)
        {
        }
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}