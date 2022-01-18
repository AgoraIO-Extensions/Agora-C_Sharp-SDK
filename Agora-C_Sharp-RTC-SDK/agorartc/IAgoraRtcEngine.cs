//  IAgoraRtcEngine.cs
//
//  Created by YuGuo Chen on September 26, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{

    public abstract class IAgoraRtcEngine : IRtcEngine
    {
    }
    public abstract class IRtcEngine
    {
        public abstract int Initialize(RtcEngineContext context);

        public abstract void Dispose(bool sync = false);

        public abstract void InitEventHandler(IAgoraRtcEngineEventHandler engineEventHandler);

        public abstract void RegisterAudioFrameObserver(IAgoraRtcAudioFrameObserver audioFrameObserver);

        public abstract void UnRegisterAudioFrameObserver();

        public abstract void RegisterVideoFrameObserver(IAgoraRtcVideoFrameObserver videoFrameObserver);

        public abstract void UnRegisterVideoFrameObserver();

        public abstract void RegisterVideoEncodedImageReceiver(IAgoraRtcVideoEncodedImageReceiver videoEncodedImageReceiver);

        public abstract void UnRegisterVideoEncodedImageReceiver();

        public abstract IAgoraRtcAudioRecordingDeviceManager GetAgoraRtcAudioRecordingDeviceManager();

        public abstract IAgoraRtcAudioPlaybackDeviceManager GetAgoraRtcAudioPlaybackDeviceManager();

        public abstract IAgoraRtcVideoDeviceManager GetAgoraRtcVideoDeviceManager();

        public abstract IAgoraRtcMediaPlayer GetAgoraRtcMediaPlayer();

        //public abstract IAgoraRtcCloudSpatialAudioEngine GetAgoraRtcCloudSpatialAudioEngine();

        //public abstract IAgoraRtcSpatialAudioEngine GetAgoraRtcSpatialAudioEngine();

        public abstract string GetVersion();

        public abstract string GetErrorDescription(int code);

        public abstract int JoinChannel(string token, string channelId, string info = "",
                                uint uid = 0);

        public abstract int JoinChannel(string token, string channelId, uint uid,
                                ChannelMediaOptions options);
      
        public abstract int UpdateChannelMediaOptions(ChannelMediaOptions options);

        public abstract int LeaveChannel();

        public abstract int LeaveChannel(LeaveChannelOptions options);

        public abstract int RenewToken(string token);

        public abstract int SetChannelProfile(CHANNEL_PROFILE_TYPE profile);

        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);

        public abstract int StartEchoTest();

        public abstract int StartEchoTest(int intervalInSeconds);

        public abstract int StopEchoTest();

        public abstract int EnableVideo();

        public abstract int DisableVideo();

        public abstract int StartPreview();

        public abstract int StopPreview();

        public abstract int StartLastmileProbeTest(LastmileProbeConfig config);
      
        public abstract int StopLastmileProbeTest();

        public abstract int SetVideoEncoderConfiguration(VideoEncoderConfiguration config);

        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options);

        public abstract int SetupRemoteVideo(VideoCanvas canvas);

        public abstract int SetupLocalVideo(VideoCanvas canvas);

        public abstract int EnableAudio();
      
        public abstract int DisableAudio();
      
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);

        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile);

        public abstract int EnableLocalAudio(bool enabled);
      
        public abstract int MuteLocalAudioStream(bool mute);

        public abstract int MuteAllRemoteAudioStreams(bool mute);

        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        public abstract int MuteLocalVideoStream(bool mute);

        public abstract int EnableLocalVideo(bool enabled);

        public abstract int MuteAllRemoteVideoStreams(bool mute);

        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        public abstract int MuteRemoteVideoStream(uint uid, bool mute);

        public abstract int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType);

        public abstract int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType);

        public abstract int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad);

        public abstract int StartAudioRecording(string filePath,
                                        AUDIO_RECORDING_QUALITY_TYPE quality);

        public abstract int StartAudioRecording(string filePath,
                                        int sampleRate,
                                        AUDIO_RECORDING_QUALITY_TYPE quality);

        public abstract int StartAudioRecording(AudioFileRecordingConfig config);
    
        public abstract int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config,  IAgoraRtcAudioEncodedFrameObserver observer); //TODO

        public abstract int StopAudioRecording();

        public abstract int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle);

        public abstract int StopAudioMixing();

        public abstract int PauseAudioMixing();

        public abstract int ResumeAudioMixing();

        public abstract int AdjustAudioMixingVolume(int volume);

        public abstract int AdjustAudioMixingPublishVolume(int volume);

        public abstract int GetAudioMixingPublishVolume();

        public abstract int AdjustAudioMixingPlayoutVolume(int volume);

        public abstract int GetAudioMixingPlayoutVolume();

        public abstract int GetAudioMixingDuration();

        public abstract int GetAudioMixingCurrentPosition();

        public abstract int SetAudioMixingPosition(int pos /*in ms*/);

        public abstract int SetAudioMixingPitch(int pitch);

        public abstract int GetEffectsVolume();

        public abstract int SetEffectsVolume(int volume);

        public abstract int PreloadEffect(int soundId, string filePath, int startPos = 0);

        public abstract int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0);

        public abstract int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false);

        public abstract int GetVolumeOfEffect(int soundId);

        public abstract int SetVolumeOfEffect(int soundId, int volume);

        public abstract int PauseEffect(int soundId);

        public abstract int PauseAllEffects();

        public abstract int ResumeEffect(int soundId);

        public abstract int ResumeAllEffects();

        public abstract int StopEffect(int soundId);

        public abstract int StopAllEffects();

        public abstract int UnloadEffect(int soundId);

        public abstract int UnloadAllEffects();

        public abstract int EnableSoundPositionIndication(bool enabled);

        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        public abstract int EnableSpatialAudio(bool enabled);

        public abstract int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param);

        public abstract int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset);

        public abstract int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset);

        public abstract int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset);

        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);

        public abstract int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2);

        public abstract int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2);

        public abstract int SetLocalVoicePitch(double pitch);

        public abstract int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);
      
        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);

        public abstract int SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset);

        public abstract int SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger);

        public abstract int SetLogFile(string filePath);

        public abstract int SetLogFilter(uint filter);

        public abstract int SetLogLevel(LOG_LEVEL level);

        public abstract int SetLogFileSize(uint fileSizeInKBytes);

        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode);

        public abstract int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int EnableDualStreamMode(bool enabled);

        public abstract int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled);

        public abstract int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig);

        //public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels,
        //                                  int sourceNumber = 1, bool localPlayback = false, bool publish = true);

        public abstract int SetExternalAudioSink(int sampleRate, int channels);

        //public abstract int PullAudioFrame(AudioFrame frame);

        public abstract int StartPrimaryCustomAudioTrack(AudioTrackConfig config);

        public abstract int StopPrimaryCustomAudioTrack();

        public abstract int StartSecondaryCustomAudioTrack(AudioTrackConfig config);

        public abstract int StopSecondaryCustomAudioTrack();

        public abstract int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall);

        public abstract int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel);

        public abstract int EnableAudioSpectrumMonitor(int intervalInMS = 100);

        public abstract int DisableAudioSpectrumMonitor();

        // public abstract int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        // public abstract int UnregisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        public abstract int AdjustRecordingSignalVolume(int volume);

        public abstract int MuteRecordingSignal(bool mute);

        public abstract int AdjustPlaybackSignalVolume(int volume);

        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);

        public abstract int EnableLoopbackRecording(bool enabled);

        public abstract int AdjustLoopbackRecordingVolume(int volume);

        public abstract int GetLoopbackRecordingVolume();

        public abstract int EnableInEarMonitoring(bool enabled, int includeAudioFilters);

        public abstract int SetInEarMonitoringVolume(int volume);
    
        public abstract int LoadExtensionProvider(string extension_lib_path);

        public abstract int SetExtensionProviderProperty(string provider, string key, string value);

        public abstract int EnableExtension(string provider, string extension, bool enable=true);

        public abstract int SetExtensionProperty(string provider, string extension, string key, string value);

        public abstract int GetExtensionProperty(string provider, string extension, string key, string value, int buf_len);

        public abstract int SetCameraCapturerConfiguration(CameraCapturerConfiguration config);

        public abstract int SwitchCamera();

        public abstract bool IsCameraZoomSupported();

        public abstract bool IsCameraFaceDetectSupported();

        public abstract bool IsCameraTorchSupported();

        public abstract bool IsCameraFocusSupported();

        public abstract bool IsCameraAutoFocusFaceModeSupported();

        public abstract int SetCameraZoomFactor(float factor);

        public abstract int EnableFaceDetection(bool enabled);
  
        public abstract float GetCameraMaxZoomFactor();

        public abstract int SetCameraFocusPositionInPreview(float positionX, float positionY);

        public abstract int SetCameraTorchOn(bool isOn);

        public abstract int SetCameraAutoFocusFaceModeEnabled(bool enabled);
      
        public abstract bool IsCameraExposurePositionSupported();
      
        public abstract int SetCameraExposurePosition(float positionXinView, float positionYinView);

        public abstract bool IsCameraAutoExposureFaceModeSupported();
      
        public abstract int SetCameraAutoExposureFaceModeEnabled(bool enabled);  

        public abstract int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker);

        public abstract int SetEnableSpeakerphone(bool speakerOn);
      
        public abstract bool IsSpeakerphoneEnabled();
    
        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams);
    
        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams);

        public abstract int StartScreenCapture(byte[] mediaProjectionPermissionResultData, ScreenCaptureParameters captureParams);

        public abstract int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect, ScreenCaptureParameters captureParams);
    
        public abstract int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint);
      
        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);

        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);

        public abstract int StopScreenCapture();

        public abstract string GetCallId();

        public abstract int Rate(string callId, int rating, string description);

        public abstract int Complain(string callId, string description);

        public abstract int AddPublishStreamUrl(string url, bool transcodingEnabled);

        public abstract int RemovePublishStreamUrl(string url);

        public abstract int SetLiveTranscoding(LiveTranscoding transcoding);
      
        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfiguration config);

        public abstract int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config);

        public abstract int StopLocalVideoTranscoder();
      
        public abstract int StartPrimaryCameraCapture(CameraCapturerConfiguration config);

        public abstract int StartSecondaryCameraCapture(CameraCapturerConfiguration config);

        public abstract int StopPrimaryCameraCapture();

        public abstract int StopSecondaryCameraCapture();
      
        public abstract int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        public abstract int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);
      
        public abstract int StartPrimaryScreenCapture(ScreenCaptureConfiguration config);

        public abstract int StartSecondaryScreenCapture(ScreenCaptureConfiguration config);

        public abstract int StopPrimaryScreenCapture();

        public abstract int StopSecondaryScreenCapture();
      
        public abstract CONNECTION_STATE_TYPE GetConnectionState();
      
        public abstract int RegisterEventHandler(IAgoraRtcEngineEventHandler eventHandler);

        public abstract int UnregisterEventHandler(IAgoraRtcEngineEventHandler eventHandler);
        
        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);

        //public abstract int RegisterPacketObserver(IPacketObserver observer);

        public abstract int SetEncryptionMode(string encryptionMode);

        public abstract int SetEncryptionSecret(string secret);

        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);

        public abstract int CreateDataStream(bool reliable, bool ordered);

        public abstract int CreateDataStream(DataStreamConfig config);

        public abstract int SendStreamMessage(int streamId, string data, uint length);

        public abstract int AddVideoWatermark(RtcImage watermark);

        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);

        public abstract int ClearVideoWatermark();

        public abstract int ClearVideoWatermarks();

        public abstract int AddInjectStreamUrl(string url, InjectStreamConfig config);

        public abstract int RemoveInjectStreamUrl(string url);

        public abstract int PauseAudio();

        public abstract int ResumeAudio();

        public abstract int EnableWebSdkInteroperability(bool enabled);

        public abstract int SendCustomReportMessage(string id, string category, string @event, string label, int value);

        // public abstract int RegisterMediaMetadataObserver(IMetadataObserver observer, IMetadataObserver::METADATA_TYPE type);

        // public abstract int UnregisterMediaMetadataObserver(IMetadataObserver observer, IMetadataObserver::METADATA_TYPE type);

        public abstract int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload);
      
        public abstract int StopAudioFrameDump(string channel_id, uint user_id, string location);

        public abstract int RegisterLocalUserAccount(string appId, string userAccount);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options);

        public abstract int JoinChannelWithUserAccountEx(string token, string channelId, string userAccount, ChannelMediaOptions options, IAgoraRtcEngineEventHandler eventHandler);

        public abstract int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo, string channelId = null, string localUserAccount = null);
      
        public abstract int GetUserInfoByUid(uint uid, out UserInfo userInfo, string channelId = null, string localUserAccount = null);

        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);
      
        public abstract int StopChannelMediaRelay();
      
        public abstract int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile);
        
        public abstract int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config);
      
        // public abstract int StartDirectCdnStreaming(IDirectCdnStreamingEventHandler eventHandler, string publishUrl, DirectCdnStreamingMediaOptions options);
        
        // public abstract int StopDirectCdnStreaming();
      
        // public abstract int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options);
      
        public abstract int PushDirectCdnStreamingCustomVideoFrame(ExternalVideoFrame frame);

        public abstract int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options, IAgoraRtcEngineEventHandler eventHandler);

        public abstract int LeaveChannelEx(RtcConnection connection);

        public abstract int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection);

        public abstract int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection);

        public abstract int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection);

        public abstract int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection);

        public abstract int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection);

        public abstract int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection);

        public abstract int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection);

        public abstract int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection);

        public abstract int EnableLoopbackRecordingEx(bool enabled, RtcConnection connection);

        public abstract CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection);

        public abstract int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config);

        public abstract int CreateDataStreamEx(bool reliable, bool ordered, RtcConnection connection);

        public abstract int CreateDataStreamEx(DataStreamConfig config, RtcConnection connection);

        public abstract int SendStreamMessageEx(int streamId, string data, uint length, RtcConnection connection);

        public abstract int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection);

        public abstract int ClearVideoWatermarkEx(RtcConnection connection);

        public abstract int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection);

        public abstract int AddPublishStreamUrlEx(string url, bool transcodingEnabled, RtcConnection connection);

        public abstract int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap = false, int sourceId = 0);

        public abstract int PullAudioFrame(AudioFrame frame);

        public abstract int SetExternalVideoSource(bool enabled, bool useTexture, bool encodedFrame, EncodedVideoTrackOptions encodedVideoOption);
       
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true);

        public abstract int PushVideoFrame(ExternalVideoFrame frame);

        public abstract int PushVideoFrame(ExternalVideoFrame frame, RtcConnection connection);

        public abstract int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo);

        public abstract int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo, RtcConnection connection);
        
        public abstract int GetCertificateVerifyResult(string credential_buf, int credential_len, string certificate_buf, int certificate_len);
        
        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);

        public abstract int AdjustCustomAudioPublishVolume(int sourceId, int volume);

        public abstract int AdjustCustomAudioPlayoutVolume(int sourceId, int volume);

        public abstract int SetParameters(string parameters);

        public abstract int EnableDirectExternalAudioSource(bool enabled);

        public abstract int PushDirectSendAudioFrame(AudioFrame frame);

        //public abstract DeviceInfo GetAudioDeviceInfo();

        public abstract int EnableCustomAudioLocalPlayback(int sourceId, bool enabled);
    };

    public abstract class IAgoraRtcEngineEventHandler
    {
        public virtual void OnJoinChannelSuccess(RtcConnection connection, int elapsed) {}

        public virtual void OnRejoinChannelSuccess(RtcConnection connection, int elapsed) {}

        public virtual void OnWarning(int warn, string msg) {}

        public virtual void OnError(int err, string msg) {}

        public virtual void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, UInt16 delay, UInt16 lost) {}

        public virtual void OnLastmileProbeResult(LastmileProbeResult result) {}

        public virtual void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume) {}

        public virtual void OnLeaveChannel(RtcConnection connection, RtcStats stats) {}

        public virtual void OnRtcStats(RtcConnection connection, RtcStats stats) {}

        public virtual void OnAudioDeviceStateChanged(string deviceId, int deviceType, int deviceState) {}

        public virtual void OnAudioMixingFinished() {}

        public virtual void OnAudioEffectFinished(int soundId) {}

        public virtual void OnVideoDeviceStateChanged(string deviceId, int deviceType, int deviceState) {}

        public virtual void OnMediaDeviceChanged(int deviceType) {}

        public virtual void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality) {}

        public virtual void OnIntraRequestReceived(RtcConnection connection) {}

        public virtual void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info) {}

        public virtual void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info) {}

        public virtual void OnLastmileQuality(int quality) {}

        public virtual void OnFirstLocalVideoFrame(RtcConnection connection, int width, int height, int elapsed) {}

        public virtual void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed) {}

        public virtual void OnVideoSourceFrameSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, int width, int height) {}

        public virtual void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed) {}

        public virtual void OnVideoSizeChanged(RtcConnection connection, uint uid, int width, int height, int rotation) {}

        public virtual void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode) {}

        public virtual void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed) {}

        public virtual void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed) {}

        public virtual void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed) {}

        public virtual void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason) {}

        public virtual void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted) {}

        public virtual void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled) {}

        public virtual void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled) {}

        public virtual void OnApiCallExecuted(int err, string api, string result) {}

        public virtual void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats) {}

        public virtual void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats) {}

        public virtual void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats) {}

        public virtual void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats) {}

        public virtual void OnCameraReady() {}

        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height) {}

        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height) {}

        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle vecRectangle, int[] vecDistance, int numFaces) {}

        public virtual void OnVideoStopped() {}

        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_ERROR_TYPE errorCode) {}

        public virtual void OnConnectionLost(RtcConnection connection) {}

        public virtual void OnConnectionInterrupted(RtcConnection connection) {}

        public virtual void OnConnectionBanned(RtcConnection connection) {}

        public virtual void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, uint length, UInt64 sentTs) {}

        public virtual void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached) {}

        public virtual void OnRequestToken(RtcConnection connection) {}

        public virtual void OnTokenPrivilegeWillExpire(RtcConnection connection, string token) {}

        public virtual void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed) {}

        public virtual void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error) {}

        public virtual void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed) {}

        public virtual void OnActiveSpeaker(uint userId) {}

        public virtual void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole) {}

        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted) {}

        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR errCode) {}

        public virtual void OnStreamPublished(string url, int error) {}

        public virtual void OnStreamUnpublished(string url) {}

        public virtual void OnTranscodingUpdated() {}

        public virtual void OnAudioRoutingChanged(int routing) {}

        public virtual void OnAudioSessionRestrictionResume() {}

        public virtual void OnChannelMediaRelayStateChanged(int state, int code) {}

        public virtual void OnChannelMediaRelayEvent(int code) {}

        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover) {}

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover) {}

        public virtual void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate) {}

        public virtual void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate) {}

        public virtual void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason) {}

        public virtual void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type) {}

        public virtual void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType) {}

        public virtual void OnPermissionError(PERMISSION_TYPE permissionType) {}

        public virtual void OnLocalUserRegistered(uint uid, string userAccount) {}

        public virtual void OnUserInfoUpdated(uint uid, UserInfo info) {}

        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState) {}

        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState) {}

        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState) {}

        public virtual void OnVideoPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState) {}

        public virtual void OnExtensionEvent(string provider, string extension, string key, string value) {}

        public virtual void OnExtensionStarted(string provider, string extension) {}

        public virtual void OnExtensionStopped(string provider, string extension) {}

        public virtual void OnExtensionErrored(string provider, string extension, int error, string msg) {}

        public virtual void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string userAccount) {}

        public virtual void OnUserMuteAudio(uint connId, uint uid, bool muted) {}

        public virtual void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed) {}

        public virtual void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed) {}
    };

    internal static partial class ObsoleteMethodWarning
    {
    }
}