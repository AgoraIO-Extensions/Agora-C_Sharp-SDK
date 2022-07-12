using System;
using video_track_id_t = System.UInt32;

namespace Agora.Rtc
{
    public abstract class IRtcEngine
    {
        #region Channel management
        public abstract int Initialize(RtcEngineContext context);

        public abstract void Dispose(bool sync = false);

        public abstract int SetChannelProfile(CHANNEL_PROFILE_TYPE profile);

        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);

        public abstract int SetClientRole(CLIENT_ROLE_TYPE role, ref ClientRoleOptions options);

        public abstract int JoinChannel(string token, string channelId, string info = "", uint uid = 0);

        public abstract int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options);

        public abstract int UpdateChannelMediaOptions(ChannelMediaOptions options);

        public abstract int LeaveChannel();

        public abstract int LeaveChannel(LeaveChannelOptions options);

        public abstract int RenewToken(string token);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options);

        public abstract int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo);

        public abstract int GetUserInfoByUid(uint uid, ref UserInfo userInfo);
        #endregion

        #region Event handler
        public abstract RtcEngineEventHandler GetRtcEngineEventHandler();

        public abstract void InitEventHandler(IRtcEngineEventHandler engineEventHandler);
        #endregion

        #region Audio management
        public abstract int EnableAudio();

        public abstract int DisableAudio();

        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);

        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile);

        public abstract int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario);

        public abstract int AdjustRecordingSignalVolume(int volume);

        public abstract int MuteRecordingSignal(bool mute);

        public abstract int AdjustPlaybackSignalVolume(int volume);

        public abstract int AdjustLoopbackSignalVolume(int volume);

        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);

        public abstract int EnableLocalAudio(bool enabled);

        public abstract int MuteLocalAudioStream(bool mute);

        public abstract int MuteAllRemoteAudioStreams(bool mute);

        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        public abstract int MuteRemoteAudioStream(uint uid, bool mute);
        #endregion

        #region Video management
        public abstract int EnableVideo();

        public abstract int DisableVideo();

        public abstract int StartPreview();

        public abstract int StartPreview(VIDEO_SOURCE_TYPE sourceType);

        public abstract int StopPreview();

        public abstract int StopPreview(VIDEO_SOURCE_TYPE sourceType);

        public abstract int SetVideoEncoderConfiguration(VideoEncoderConfiguration config);

        public abstract int SetupRemoteVideo(VideoCanvas canvas);

        public abstract int SetupLocalVideo(VideoCanvas canvas);

        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode);

        public abstract int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int MuteLocalVideoStream(bool mute);

        public abstract int MuteRemoteVideoStream(uint uid, bool mute);

        public abstract int EnableLocalVideo(bool enabled);

        public abstract int MuteAllRemoteVideoStreams(bool mute);

        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        public abstract int EnableVideoImageSource(bool enable, ImageTrackOptions options);

        public abstract int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options);

        public abstract int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);
        #endregion

        #region Capture screenshots
        public abstract int TakeSnapshot(uint uid, string filePath);
        #endregion

        #region Multi-device capture
        public abstract int StartPrimaryCameraCapture(CameraCapturerConfiguration config);

        public abstract int StartSecondaryCameraCapture(CameraCapturerConfiguration config);

        public abstract int StopPrimaryCameraCapture();

        public abstract int StopSecondaryCameraCapture();

        public abstract int StartPrimaryScreenCapture(ScreenCaptureConfiguration config);

        public abstract int StartSecondaryScreenCapture(ScreenCaptureConfiguration config);

        public abstract int StopPrimaryScreenCapture();

        public abstract int StopSecondaryScreenCapture();
        #endregion

        #region Media player
        public abstract IMediaPlayer CreateMediaPlayer();

        public abstract void DestroyMediaPlayer(IMediaPlayer mediaPlayer);
        #endregion

        #region Audio pre-process and post-process
        public abstract int SetAdvancedAudioOptions(AdvancedAudioOptions options);
        #endregion

        #region Video pre-process and post-process
        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int EnableRemoteSuperResolution(uint userId, bool enable);
        #endregion

        #region Face detection
        public abstract int EnableFaceDetection(bool enabled);
        #endregion

        #region In-ear monitoring
        public abstract int EnableInEarMonitoring(bool enabled, int includeAudioFilters);

        public abstract int SetInEarMonitoringVolume(int volume);
        #endregion

        #region Music file playback and mixing
        public abstract int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle);

        public abstract int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int startPos);

        public abstract int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode);

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
        #endregion

        #region Audio effect file playback
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

        public abstract int GetEffectCurrentPosition(int soundId);

        public abstract int GetEffectDuration(string filePath);

        public abstract int SetEffectPosition(int soundId, int pos);

        #endregion

        #region Virtual metronome
        public abstract int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config);

        public abstract int StopRhythmPlayer();

        public abstract int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config);
        #endregion

        #region Voice changer and reverberation
        public abstract int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset);

        public abstract int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset);

        public abstract int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset);

        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);

        public abstract int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2);

        public abstract int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2);

        public abstract int SetLocalVoicePitch(double pitch);

        public abstract int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);

        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);
        #endregion

        #region Pre-call network test
        public abstract int StartEchoTest();

        public abstract int StartEchoTest(int intervalInSeconds);

        public abstract int StartEchoTest(EchoTestConfiguration config);

        public abstract int StopEchoTest();

        public abstract int StartLastmileProbeTest(LastmileProbeConfig config);

        public abstract int StopLastmileProbeTest();
        #endregion

        #region Screen sharing
        public abstract ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen);

        public abstract int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario);

        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams);

        public abstract int StartScreenCapture(byte[] mediaProjectionPermissionResultData, ScreenCaptureParameters captureParams);

        //only in android 
        public abstract int StartScreenCapture(ScreenCaptureParameters2 captureParams);

        //only in android 
        public abstract int UpdateScreenCapture(ScreenCaptureParameters2 captureParams);

        public abstract int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        public abstract int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint);

        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);

        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);

        public abstract int StopScreenCapture();
        #endregion

        #region Video dual stream
        public abstract int EnableDualStreamMode(bool enabled);

        public abstract int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled);

        public abstract int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig);

        public abstract int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType);

        public abstract int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType);

        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode);

        public abstract int SetDualStreamMode(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode);

        public abstract int SetDualStreamMode(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig);
        #endregion

        #region Watermark
        public abstract int AddVideoWatermark(RtcImage watermark);

        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);

        public abstract int ClearVideoWatermark();

        public abstract int ClearVideoWatermarks();
        #endregion

        #region Encryption
        //public abstract int RegisterPacketObserver(IPacketObserver observer);

        public abstract int SetEncryptionMode(string encryptionMode);

        public abstract int SetEncryptionSecret(string secret);

        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);
        #endregion

        #region Sound localization
        public abstract int EnableSoundPositionIndication(bool enabled);
        #endregion

        #region Media push
        //public abstract int AddPublishStreamUrl(string url, bool transcodingEnabled);

        //public abstract int RemovePublishStreamUrl(string url);

        //public abstract int SetLiveTranscoding(LiveTranscoding transcoding);

        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfiguration config);

        public abstract int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config);

        public abstract int StopLocalVideoTranscoder();
        #endregion

        #region Channel media stream relay
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        public abstract int StopChannelMediaRelay();

        public abstract int PauseAllChannelMediaRelay();

        public abstract int ResumeAllChannelMediaRelay();
        #endregion

        #region Custom audio source
        public abstract int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap = false, int sourceId = 0);

        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true);

        public abstract int AdjustCustomAudioPublishVolume(int sourceId, int volume);

        public abstract int AdjustCustomAudioPlayoutVolume(int sourceId, int volume);
        #endregion

        #region Custom audio renderer
        public abstract int SetExternalAudioSink(bool enabled, int sampleRate, int channels);

        public abstract int PullAudioFrame(AudioFrame frame);
        #endregion

        #region Raw audio data
        public abstract void RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract void UnRegisterAudioFrameObserver();

        public abstract int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall);

        public abstract int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel);
        #endregion

        #region Encoded audio data
        public abstract void RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer);

        public abstract void UnRegisterAudioEncodedFrameObserver();
        #endregion

        #region Audio spectrum
        public abstract int EnableAudioSpectrumMonitor(int intervalInMS = 100);

        public abstract int DisableAudioSpectrumMonitor();

        public abstract void RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        public abstract void UnregisterAudioSpectrumObserver();
        #endregion

        #region External video source
        public abstract int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption);

        public abstract int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0);

        public abstract int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0);

        public abstract video_track_id_t CreateCustomEncodedVideoTrack(SenderOptions sender_option);

        public abstract int DestroyCustomEncodedVideoTrack(video_track_id_t video_track_id);

        public abstract video_track_id_t CreateCustomVideoTrack();

        public abstract int DestroyCustomVideoTrack(video_track_id_t video_track_id);

        #endregion

        #region Raw video data
        public abstract void RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract void UnRegisterVideoFrameObserver();

        public abstract void RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract void UnRegisterVideoEncodedFrameObserver();
        #endregion

        #region Extension
        public abstract int LoadExtensionProvider(string path);

        public abstract int SetExtensionProviderProperty(string provider, string key, string value);

        public abstract int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        public abstract int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        public abstract int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);
        #endregion

        #region Media metadata
        public abstract void RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type);

        public abstract void UnregisterMediaMetadataObserver();

        //public abstract int SetMaxMetadataSize(int size);

        //public abstract int SendMetaData(Metadata metadata, VIDEO_SOURCE_TYPE source_type);
        #endregion

        #region Audio recording
        public abstract int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality);

        public abstract int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        public abstract int StartAudioRecording(AudioRecordingConfiguration config);

        public abstract int StopAudioRecording();
        #endregion

        #region Camera management
        public abstract int SetCameraCapturerConfiguration(CameraCapturerConfiguration config);

        public abstract int SwitchCamera();

        public abstract bool IsCameraZoomSupported();

        public abstract bool IsCameraFaceDetectSupported();

        public abstract bool IsCameraTorchSupported();

        public abstract bool IsCameraFocusSupported();

        public abstract bool IsCameraAutoFocusFaceModeSupported();

        public abstract int SetCameraZoomFactor(float factor);

        public abstract float GetCameraMaxZoomFactor();

        public abstract int SetCameraFocusPositionInPreview(float positionX, float positionY);

        public abstract int SetCameraTorchOn(bool isOn);

        public abstract int SetCameraAutoFocusFaceModeEnabled(bool enabled);

        public abstract bool IsCameraExposurePositionSupported();

        public abstract int SetCameraExposurePosition(float positionXinView, float positionYinView);

        public abstract bool IsCameraAutoExposureFaceModeSupported();

        public abstract int SetCameraAutoExposureFaceModeEnabled(bool enabled);
        #endregion

        #region Audio route : This group of methods are for Android and iOS only.
        public abstract int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker);

        public abstract int SetEnableSpeakerphone(bool speakerOn);

        public abstract bool IsSpeakerphoneEnabled();
        #endregion

        #region Volume indication
        public abstract int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad);
        #endregion

        #region Data stream
        public abstract int CreateDataStream(ref int streamId, bool reliable, bool ordered);

        public abstract int CreateDataStream(ref int streamId, DataStreamConfig config);

        public abstract int SendStreamMessage(int streamId, byte[] data, uint length);
        #endregion

        #region Miscellaneous audio control
        public abstract int EnableLoopbackRecording(bool enabled, string deviceName = "");

        public abstract int GetLoopbackRecordingVolume();
        #endregion

        #region Miscellaneous methods
        public abstract int SetCloudProxy(CLOUD_PROXY_TYPE proxyType);

        public abstract string GetCallId();

        public abstract int Rate(string callId, int rating, string description);

        public abstract int Complain(string callId, string description);

        public abstract string GetVersion();

        public abstract string GetErrorDescription(int code);
        #endregion

        #region DeviceManager
        public abstract IAudioDeviceManager GetAudioDeviceManager();

        public abstract IVideoDeviceManager GetVideoDeviceManager();
        #endregion

        public abstract IMediaPlayerCacheManager GetMediaPlayerCacheManager();

        #region SpatialAudio
        //public abstract ICloudSpatialAudioEngine GetCloudSpatialAudioEngine();

        public abstract ILocalSpatialAudioEngine GetLocalSpatialAudioEngine();

        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        public abstract int EnableSpatialAudio(bool enabled);

        public abstract int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param);
        #endregion

        #region RtmpStreaming
        public abstract int AddInjectStreamUrl(string url, InjectStreamConfig config);

        public abstract int RemoveInjectStreamUrl(string url);

        public abstract int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile);

        public abstract int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config);

        public abstract int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options);

        public abstract int StopDirectCdnStreaming();

        public abstract int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options);

        public abstract int StartRtmpStreamWithoutTranscoding(string url);

        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);

        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);

        public abstract int StopRtmpStream(string url);
        #endregion

        #region Log
        public abstract int SetLogFile(string filePath);

        public abstract int SetLogFilter(uint filter);

        public abstract int SetLogLevel(LOG_LEVEL level);

        public abstract int SetLogFileSize(uint fileSizeInKBytes);

        public abstract int UploadLogFile(ref string requestId);
        #endregion

        #region black list and white list
        public abstract int SetSubscribeAudioBlacklist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeAudioWhitelist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeVideoBlacklist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeVideoWhitelist(uint[] uidList, int uidNumber);
        #endregion


        #region DualStream
        #endregion


        public abstract int StartPrimaryCustomAudioTrack(AudioTrackConfig config);

        public abstract int StopPrimaryCustomAudioTrack();

        public abstract int StartSecondaryCustomAudioTrack(AudioTrackConfig config);

        public abstract int StopSecondaryCustomAudioTrack();

        public abstract int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        public abstract int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        public abstract CONNECTION_STATE_TYPE GetConnectionState();

        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);

        public abstract int PauseAudio();

        public abstract int ResumeAudio();

        public abstract int EnableWebSdkInteroperability(bool enabled);

        public abstract int SendCustomReportMessage(string id, string category, string @event, string label, int value);

        public abstract int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload);

        public abstract int StopAudioFrameDump(string channel_id, uint user_id, string location);

        public abstract int RegisterLocalUserAccount(string appId, string userAccount);

        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);

        public abstract int SetParameters(string parameters);

        public abstract int GetAudioDeviceInfo(ref DeviceInfo deviceInfo);

        public abstract int EnableCustomAudioLocalPlayback(int sourceId, bool enabled);

        public abstract int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option);

        public abstract int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option);

        public abstract int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay);

        public abstract int SetDirectExternalAudioSource(bool enable, bool localPlayback);

        public abstract int PushDirectAudioFrame(AudioFrame frame);

        public abstract int SetLocalAccessPoint(LocalAccessPointConfiguration config);

        //public abstract int EnableFishEyeCorrection(bool enabled, FishEyeCorrectionParams @params);

        public abstract int SetAVSyncSource(string channelId, uint uid);

        public abstract int EnableContentInspect(bool enabled, ContentInspectConfig config);

        public abstract bool StartDumpVideo(VIDEO_SOURCE_TYPE type, string dir);

        public abstract bool StopDumpVideo();

        public abstract int EnableWirelessAccelerate(bool enabled);

        public abstract int GetAudioTrackCount();

        public abstract int SelectAudioTrack(int index);

        #region IMediaRecorder
        //public abstract int SetMediaRecorderObserver(RtcConnection connection);

        public abstract int StartRecording(RtcConnection connection, MediaRecorderConfiguration config);

        public abstract int StopRecording(RtcConnection connection);
        #endregion

    };

    public abstract class IRtcEngineEx : IRtcEngine
    {
        #region Multiple channels
        public abstract int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options);

        public abstract int LeaveChannelEx(RtcConnection connection);
        #endregion

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

        public abstract int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection);

        public abstract int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection);

        public abstract int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection);

        public abstract int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection);

        public abstract int ClearVideoWatermarkEx(RtcConnection connection);

        public abstract int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection);

        public abstract int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection);

        public abstract int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection);

        public abstract int SetVideoProfileEx(int width, int height, int frameRate, int bitrate);

        public abstract int EnableDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection);

        //public abstract int AddPublishStreamUrlEx(string url, bool transcodingEnabled, RtcConnection connection);

        public abstract int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection);

        public abstract int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection);

        public abstract int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection);

        public abstract int SetSubscribeAudioBlacklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        public abstract int SetSubscribeAudioWhitelistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        public abstract int SetSubscribeVideoBlacklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        public abstract int SetSubscribeVideoWhitelistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        public abstract int SetDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection);

        public abstract int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath);

    }
}