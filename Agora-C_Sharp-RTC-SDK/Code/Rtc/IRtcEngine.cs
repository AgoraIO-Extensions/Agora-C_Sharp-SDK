#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.Int64;
using track_id_t = System.UInt32;
namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The basic interface of the Agora SDK that implements the core functions of real-time communication.
    /// IRtcEngine provides the main methods that your app can call. Before calling other APIs, you must call CreateAgoraRtcEngine to create an IRtcEngine object.
    /// </summary>
    ///
    public abstract class IRtcEngine
    {
        public abstract void Dispose(bool sync = false);

        public abstract int InitEventHandler(IRtcEngineEventHandler engineEventHandler);

        public abstract IAudioDeviceManager GetAudioDeviceManager();

        public abstract IVideoDeviceManager GetVideoDeviceManager();

        public abstract IMusicContentCenter GetMusicContentCenter();

        public abstract IMediaPlayerCacheManager GetMediaPlayerCacheManager();

        public abstract ILocalSpatialAudioEngine GetLocalSpatialAudioEngine();

        public abstract int SetParameters(string key, object value);

#if AGORA_RTM
        public abstract Rtm.IStreamChannel GetStreamChannel(string channelId);
#endif

        public abstract int GetNativeHandler(ref IntPtr nativeHandler);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID

        public abstract int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type);

        public abstract int SetMaxMetadataSize(int size);
#endif

#region terra IRtcEngine

        public abstract int Initialize(RtcEngineContext context);

        public abstract string GetVersion(ref int build);

        public abstract string GetErrorDescription(int code);

        public abstract int QueryCodecCapability(ref CodecCapInfo[] codecInfo, ref int size);

        public abstract int PreloadChannel(string token, string channelId, uint uid);

        public abstract int PreloadChannel(string token, string channelId, string userAccount);

        public abstract int UpdatePreloadChannelToken(string token);

        public abstract int JoinChannel(string token, string channelId, string info, uint uid);

        public abstract int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options);

        public abstract int UpdateChannelMediaOptions(ChannelMediaOptions options);

        public abstract int LeaveChannel();

        public abstract int LeaveChannel(LeaveChannelOptions options);

        public abstract int RenewToken(string token);

        public abstract int SetChannelProfile(CHANNEL_PROFILE_TYPE profile);

        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);

        public abstract int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options);

        public abstract int StartEchoTest();

        public abstract int StartEchoTest(int intervalInSeconds);

        public abstract int StartEchoTest(EchoTestConfiguration config);

        public abstract int StopEchoTest();

        public abstract int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config);

        public abstract int EnableVideo();

        public abstract int DisableVideo();

        public abstract int StartPreview();

        public abstract int StartPreview(VIDEO_SOURCE_TYPE sourceType);

        public abstract int StopPreview();

        public abstract int StopPreview(VIDEO_SOURCE_TYPE sourceType);

        public abstract int StartLastmileProbeTest(LastmileProbeConfig config);

        public abstract int StopLastmileProbeTest();

        public abstract int SetVideoEncoderConfiguration(VideoEncoderConfiguration config);

        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        public abstract int SetupRemoteVideo(VideoCanvas canvas);

        public abstract int SetupLocalVideo(VideoCanvas canvas);

        public abstract int SetVideoScenario(VIDEO_APPLICATION_SCENARIO_TYPE scenarioType);

        public abstract int EnableAudio();

        public abstract int DisableAudio();

        [Obsolete("This method is deprecated. You can use the")]
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);

        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile);

        public abstract int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario);

        public abstract int EnableLocalAudio(bool enabled);

        public abstract int MuteLocalAudioStream(bool mute);

        public abstract int MuteAllRemoteAudioStreams(bool mute);

        [Obsolete("This method is deprecated. To set whether to receive remote")]
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        public abstract int MuteLocalVideoStream(bool mute);

        public abstract int EnableLocalVideo(bool enabled);

        public abstract int MuteAllRemoteVideoStreams(bool mute);

        [Obsolete("This method is deprecated. To set whether to receive remote")]
        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        public abstract int MuteRemoteVideoStream(uint uid, bool mute);

        public abstract int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType);

        public abstract int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options);

        public abstract int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType);

        public abstract int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber);

        public abstract int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber);

        public abstract int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad);

        public abstract int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality);

        public abstract int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        public abstract int StartAudioRecording(AudioRecordingConfiguration config);

        public abstract int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer);

        public abstract int StopAudioRecording();

        public abstract IMediaPlayer CreateMediaPlayer();

        public abstract int DestroyMediaPlayer(IMediaPlayer media_player);

        public abstract IMediaRecorder CreateMediaRecorder(RecorderStreamInfo info);

        public abstract int DestroyMediaRecorder(IMediaRecorder mediaRecorder);

        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle);

        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos);

        public abstract int StopAudioMixing();

        public abstract int PauseAudioMixing();

        public abstract int ResumeAudioMixing();

        public abstract int SelectAudioTrack(int index);

        public abstract int GetAudioTrackCount();

        public abstract int AdjustAudioMixingVolume(int volume);

        public abstract int AdjustAudioMixingPublishVolume(int volume);

        public abstract int GetAudioMixingPublishVolume();

        public abstract int AdjustAudioMixingPlayoutVolume(int volume);

        public abstract int GetAudioMixingPlayoutVolume();

        public abstract int GetAudioMixingDuration();

        public abstract int GetAudioMixingCurrentPosition();

        public abstract int SetAudioMixingPosition(int pos);

        public abstract int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode);

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

        public abstract int GetEffectDuration(string filePath);

        public abstract int SetEffectPosition(int soundId, int pos);

        public abstract int GetEffectCurrentPosition(int soundId);

        public abstract int EnableSoundPositionIndication(bool enabled);

        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        public abstract int EnableSpatialAudio(bool enabled);

        public abstract int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams @params);

        public abstract int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset);

        public abstract int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset);

        public abstract int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset);

        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);

        public abstract int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2);

        public abstract int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2);

        public abstract int SetLocalVoicePitch(double pitch);

        public abstract int SetLocalVoiceFormant(double formantRatio);

        public abstract int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);

        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);

        public abstract int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset);

        public abstract int SetHeadphoneEQParameters(int lowGain, int highGain);

        public abstract int SetLogFile(string filePath);

        public abstract int SetLogFilter(uint filter);

        public abstract int SetLogLevel(LOG_LEVEL level);

        public abstract int SetLogFileSize(uint fileSizeInKBytes);

        public abstract int UploadLogFile(ref string requestId);

        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode);

        public abstract int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode);

        [Obsolete("v4.2.0. This method is deprecated. Use setDualStreamMode instead.")]
        public abstract int EnableDualStreamMode(bool enabled);

        [Obsolete("v4.2.0. This method is deprecated. Use setDualStreamMode instead.")]
        public abstract int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig);

        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode);

        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig);

        public abstract int EnableCustomAudioLocalPlayback(uint trackId, bool enabled);

        public abstract int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall);

        public abstract int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        public abstract int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel);

        public abstract int EnableAudioSpectrumMonitor(int intervalInMS = 100);

        public abstract int DisableAudioSpectrumMonitor();

        public abstract int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        public abstract int UnregisterAudioSpectrumObserver();

        public abstract int AdjustRecordingSignalVolume(int volume);

        public abstract int MuteRecordingSignal(bool mute);

        public abstract int AdjustPlaybackSignalVolume(int volume);

        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);

        public abstract int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option);

        public abstract int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option);

        public abstract int SetHighPriorityUserList(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option);

        public abstract int EnableLoopbackRecording(bool enabled, string deviceName = "");

        public abstract int AdjustLoopbackSignalVolume(int volume);

        public abstract int GetLoopbackRecordingVolume();

        public abstract int EnableInEarMonitoring(bool enabled, int includeAudioFilters);

        public abstract int SetInEarMonitoringVolume(int volume);

        public abstract int LoadExtensionProvider(string path, bool unload_after_use = false);

        public abstract int SetExtensionProviderProperty(string provider, string key, string value);

        public abstract int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        public abstract int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        public abstract int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable = true);

        public abstract int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        public abstract int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        public abstract int SetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, string value);

        public abstract int GetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, ref string value, int buf_len);

        public abstract int SetCameraCapturerConfiguration(CameraCapturerConfiguration config);

        public abstract uint CreateCustomVideoTrack();

        public abstract uint CreateCustomEncodedVideoTrack(SenderOptions sender_option);

        public abstract int DestroyCustomVideoTrack(uint video_track_id);

        public abstract int DestroyCustomEncodedVideoTrack(uint video_track_id);

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

        public abstract bool IsCameraExposureSupported();

        public abstract int SetCameraExposureFactor(float value);

        public abstract bool IsCameraAutoExposureFaceModeSupported();

        public abstract int SetCameraAutoExposureFaceModeEnabled(bool enabled);

        public abstract int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker);

        public abstract int SetEnableSpeakerphone(bool speakerOn);

        public abstract bool IsSpeakerphoneEnabled();

        public abstract int SetRouteInCommunicationMode(int route);

        public abstract ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen);

        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);

        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams);

        public abstract int GetAudioDeviceInfo(ref DeviceInfoMobile deviceInfo);

        public abstract int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        public abstract int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint);

        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);

        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);

        public abstract int StartScreenCapture(ScreenCaptureParameters2 captureParams);

        public abstract int UpdateScreenCapture(ScreenCaptureParameters2 captureParams);

        public abstract int QueryScreenCaptureCapability();

        public abstract int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario);

        public abstract int StopScreenCapture();

        public abstract int GetCallId(ref string callId);

        public abstract int Rate(string callId, int rating, string description);

        public abstract int Complain(string callId, string description);

        public abstract int StartRtmpStreamWithoutTranscoding(string url);

        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);

        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);

        public abstract int StopRtmpStream(string url);

        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfiguration config);

        public abstract int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config);

        public abstract int StopLocalVideoTranscoder();

        public abstract int StartCameraCapture(VIDEO_SOURCE_TYPE sourceType, CameraCapturerConfiguration config);

        public abstract int StopCameraCapture(VIDEO_SOURCE_TYPE sourceType);

        public abstract int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        public abstract int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        public abstract int StartScreenCapture(VIDEO_SOURCE_TYPE sourceType, ScreenCaptureConfiguration config);

        public abstract int StopScreenCapture(VIDEO_SOURCE_TYPE sourceType);

        public abstract CONNECTION_STATE_TYPE GetConnectionState();

        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);

        [Obsolete("This method is deprecated. Use enableEncryption(bool enabled, const EncryptionConfig&) instead.")]
        public abstract int SetEncryptionMode(string encryptionMode);

        [Obsolete("This method is deprecated. Use enableEncryption(bool enabled, const EncryptionConfig&) instead.")]
        public abstract int SetEncryptionSecret(string secret);

        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);

        public abstract int CreateDataStream(ref int streamId, bool reliable, bool ordered);

        public abstract int CreateDataStream(ref int streamId, DataStreamConfig config);

        public abstract int SendStreamMessage(int streamId, byte[] data, uint length);

        public abstract int AddVideoWatermark(RtcImage watermark);

        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);

        public abstract int ClearVideoWatermarks();

        [Obsolete("Use disableAudio() instead.")]
        public abstract int PauseAudio();

        [Obsolete("Use enableAudio() instead.")]
        public abstract int ResumeAudio();

        [Obsolete("The Agora NG SDK enables the interoperablity with the Web SDK.")]
        public abstract int EnableWebSdkInteroperability(bool enabled);

        public abstract int SendCustomReportMessage(string id, string category, string @event, string label, int value);

        public abstract int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type);

        public abstract int UnregisterMediaMetadataObserver();

        public abstract int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload);

        public abstract int StopAudioFrameDump(string channel_id, uint user_id, string location);

        public abstract int SetAINSMode(bool enabled, AUDIO_AINS_MODE mode);

        public abstract int RegisterLocalUserAccount(string appId, string userAccount);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options);

        public abstract int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo);

        public abstract int GetUserInfoByUid(uint uid, ref UserInfo userInfo);

        public abstract int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelay` instead.")]
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelay` instead.")]
        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        public abstract int StopChannelMediaRelay();

        public abstract int PauseAllChannelMediaRelay();

        public abstract int ResumeAllChannelMediaRelay();

        public abstract int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile);

        public abstract int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config);

        public abstract int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options);

        public abstract int StopDirectCdnStreaming();

        public abstract int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options);

        public abstract int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config);

        public abstract int StopRhythmPlayer();

        public abstract int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config);

        public abstract int TakeSnapshot(uint uid, string filePath);

        public abstract int EnableContentInspect(bool enabled, ContentInspectConfig config);

        public abstract int AdjustCustomAudioPublishVolume(uint trackId, int volume);

        public abstract int AdjustCustomAudioPlayoutVolume(uint trackId, int volume);

        public abstract int SetCloudProxy(CLOUD_PROXY_TYPE proxyType);

        public abstract int SetLocalAccessPoint(LocalAccessPointConfiguration config);

        public abstract int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType = 0);

        public abstract int SetAVSyncSource(string channelId, uint uid);

        public abstract int EnableVideoImageSource(bool enable, ImageTrackOptions options);

        public abstract long GetCurrentMonotonicTimeInMs();

        public abstract int EnableWirelessAccelerate(bool enabled);

        public abstract int GetNetworkType();

        public abstract int SetParameters(string parameters);

        public abstract int StartMediaRenderingTracing();

        public abstract int EnableInstantMediaRendering();

        public abstract ulong GetNtpWallTimeInMs();
#endregion terra IRtcEngine

        public abstract int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int RegisterVideoFrameObserver(IVideoFrameObserver observer, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver observer, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        public abstract int UnRegisterAudioFrameObserver();

        public abstract int UnRegisterVideoFrameObserver();

        public abstract int UnRegisterAudioEncodedFrameObserver();

        public abstract int UnRegisterVideoEncodedFrameObserver();

#region terra IMediaEngine

        public abstract int PushAudioFrame(AudioFrame frame, uint trackId = 0);

        public abstract int PullAudioFrame(AudioFrame frame);

        public abstract int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption);

        [Obsolete("This method is deprecated. Use createCustomAudioTrack(rtc::AUDIO_TRACK_TYPE trackType, const rtc::AudioTrackConfig& config) instead.")]
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels, bool localPlayback = false, bool publish = true);

        public abstract uint CreateCustomAudioTrack(AUDIO_TRACK_TYPE trackType, AudioTrackConfig config);

        public abstract int DestroyCustomAudioTrack(uint trackId);

        public abstract int SetExternalAudioSink(bool enabled, int sampleRate, int channels);

        public abstract int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0);

        public abstract int PushEncodedVideoImage(byte[] imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0);

#endregion terra IMediaEngine
    };

    ///
    /// <summary>
    /// This interface class contains multi-channel methods.
    /// Inherited from IRtcEngine.
    /// </summary>
    ///
    public abstract class IRtcEngineEx : IRtcEngine
    {

#region terra IRtcEngineEx

        public abstract int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options);

        public abstract int LeaveChannelEx(RtcConnection connection);

        public abstract int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options);

        public abstract int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection);

        public abstract int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection);

        public abstract int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection);

        public abstract int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection);

        public abstract int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection);

        public abstract int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection);

        public abstract int MuteLocalAudioStreamEx(bool mute, RtcConnection connection);

        public abstract int MuteLocalVideoStreamEx(bool mute, RtcConnection connection);

        public abstract int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection);

        public abstract int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection);

        public abstract int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        public abstract int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        public abstract int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        public abstract int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        public abstract int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection);

        public abstract int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection);

        public abstract int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams @params, RtcConnection connection);

        public abstract int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection);

        public abstract int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName = "");

        public abstract int AdjustRecordingSignalVolumeEx(int volume, RtcConnection connection);

        public abstract int MuteRecordingSignalEx(bool mute, RtcConnection connection);

        public abstract int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection);

        public abstract CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection);

        public abstract int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config);

        public abstract int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection);

        public abstract int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection);

        public abstract int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection);

        public abstract int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection);

        public abstract int ClearVideoWatermarkEx(RtcConnection connection);

        public abstract int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection);

        public abstract int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection);

        public abstract int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection);

        public abstract int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection);

        public abstract int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection);

        public abstract int StopRtmpStreamEx(string url, RtcConnection connection);

        public abstract int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelayEx` instead.")]
        public abstract int StartChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelayEx` instead.")]
        public abstract int UpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        public abstract int StopChannelMediaRelayEx(RtcConnection connection);

        public abstract int PauseAllChannelMediaRelayEx(RtcConnection connection);

        public abstract int ResumeAllChannelMediaRelayEx(RtcConnection connection);

        public abstract int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection);

        public abstract int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection);

        [Obsolete("v4.2.0. This method is deprecated. Use setDualStreamModeEx instead")]
        public abstract int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection);

        public abstract int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection);

        public abstract int SetHighPriorityUserListEx(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnection connection);

        public abstract int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath);

        public abstract int StartMediaRenderingTracingEx(RtcConnection connection);
#endregion terra IRtcEngineEx
    }
}