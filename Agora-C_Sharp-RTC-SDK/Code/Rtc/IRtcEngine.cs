#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.Int64;
using track_id_t = System.UInt32;
namespace Agora.Rtc
{
    /* class_irtcengine */
    public abstract class IRtcEngine
    {
        /* api_irtcengine_dispose */
        public abstract void Dispose(bool sync = false);

        /* api_irtcengine_initeventhandler */
        public abstract int InitEventHandler(IRtcEngineEventHandler engineEventHandler);

        /* api_irtcengine_getaudiodevicemanager */
        public abstract IAudioDeviceManager GetAudioDeviceManager();

        /* api_irtcengine_getvideodevicemanager */
        public abstract IVideoDeviceManager GetVideoDeviceManager();

        /* api_irtcengine_getmusiccontentcenter */
        public abstract IMusicContentCenter GetMusicContentCenter();

        /* api_irtcengine_getmediaplayercachemanager */
        public abstract IMediaPlayerCacheManager GetMediaPlayerCacheManager();

        /* api_irtcengine_getlocalspatialaudioengine */
        public abstract ILocalSpatialAudioEngine GetLocalSpatialAudioEngine();

        /* api_irtcengine_setparameters */
        public abstract int SetParameters(string key, object value);

#if AGORA_RTM
        /* api_irtcengine_getstreamchannel */
        public abstract Rtm.IStreamChannel GetStreamChannel(string channelId);
#endif

        /* api_irtcengine_getnativehandler */
        public abstract int GetNativeHandler(ref IntPtr nativeHandler);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID

        /* api_irtcengine_sendmetadata */
        public abstract int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type);

        /* api_irtcengine_setmaxmetadatasize */
        public abstract int SetMaxMetadataSize(int size);
#endif

#region terra IRtcEngine

        /* api_irtcengine_initialize */
        public abstract int Initialize(RtcEngineContext context);

        /* api_irtcengine_getversion */
        public abstract string GetVersion(ref int build);

        /* api_irtcengine_geterrordescription */
        public abstract string GetErrorDescription(int code);

        /* api_irtcengine_querycodeccapability */
        public abstract int QueryCodecCapability(ref CodecCapInfo[] codecInfo, ref int size);

        /* api_irtcengine_preloadchannel */
        public abstract int PreloadChannel(string token, string channelId, uint uid);

        /* api_irtcengine_preloadchannel2 */
        public abstract int PreloadChannel(string token, string channelId, string userAccount);

        /* api_irtcengine_updatepreloadchanneltoken */
        public abstract int UpdatePreloadChannelToken(string token);

        /* api_irtcengine_joinchannel */
        public abstract int JoinChannel(string token, string channelId, string info, uint uid);

        /* api_irtcengine_joinchannel2 */
        public abstract int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options);

        /* api_irtcengine_updatechannelmediaoptions */
        public abstract int UpdateChannelMediaOptions(ChannelMediaOptions options);

        /* api_irtcengine_leavechannel */
        public abstract int LeaveChannel();

        /* api_irtcengine_leavechannel2 */
        public abstract int LeaveChannel(LeaveChannelOptions options);

        /* api_irtcengine_renewtoken */
        public abstract int RenewToken(string token);

        /* api_irtcengine_setchannelprofile */
        public abstract int SetChannelProfile(CHANNEL_PROFILE_TYPE profile);

        /* api_irtcengine_setclientrole */
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);

        /* api_irtcengine_setclientrole2 */
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options);

        /* api_irtcengine_startechotest */
        public abstract int StartEchoTest();

        /* api_irtcengine_startechotest2 */
        public abstract int StartEchoTest(int intervalInSeconds);

        /* api_irtcengine_startechotest3 */
        public abstract int StartEchoTest(EchoTestConfiguration config);

        /* api_irtcengine_stopechotest */
        public abstract int StopEchoTest();

        /* api_irtcengine_enablemulticamera */
        public abstract int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config);

        /* api_irtcengine_enablevideo */
        public abstract int EnableVideo();

        /* api_irtcengine_disablevideo */
        public abstract int DisableVideo();

        /* api_irtcengine_startpreview */
        public abstract int StartPreview();

        /* api_irtcengine_startpreview2 */
        public abstract int StartPreview(VIDEO_SOURCE_TYPE sourceType);

        /* api_irtcengine_stoppreview */
        public abstract int StopPreview();

        /* api_irtcengine_stoppreview2 */
        public abstract int StopPreview(VIDEO_SOURCE_TYPE sourceType);

        /* api_irtcengine_startlastmileprobetest */
        public abstract int StartLastmileProbeTest(LastmileProbeConfig config);

        /* api_irtcengine_stoplastmileprobetest */
        public abstract int StopLastmileProbeTest();

        /* api_irtcengine_setvideoencoderconfiguration */
        public abstract int SetVideoEncoderConfiguration(VideoEncoderConfiguration config);

        /* api_irtcengine_setbeautyeffectoptions */
        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        /* api_irtcengine_setlowlightenhanceoptions */
        public abstract int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        /* api_irtcengine_setvideodenoiseroptions */
        public abstract int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        /* api_irtcengine_setcolorenhanceoptions */
        public abstract int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        /* api_irtcengine_enablevirtualbackground */
        public abstract int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        /* api_irtcengine_setupremotevideo */
        public abstract int SetupRemoteVideo(VideoCanvas canvas);

        /* api_irtcengine_setuplocalvideo */
        public abstract int SetupLocalVideo(VideoCanvas canvas);

        /* api_irtcengine_setvideoscenario */
        public abstract int SetVideoScenario(VIDEO_APPLICATION_SCENARIO_TYPE scenarioType);

        /* api_irtcengine_enableaudio */
        public abstract int EnableAudio();

        /* api_irtcengine_disableaudio */
        public abstract int DisableAudio();

        /* api_irtcengine_setaudioprofile */
        [Obsolete("This method is deprecated. You can use the")]
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);

        /* api_irtcengine_setaudioprofile2 */
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile);

        /* api_irtcengine_setaudioscenario */
        public abstract int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario);

        /* api_irtcengine_enablelocalaudio */
        public abstract int EnableLocalAudio(bool enabled);

        /* api_irtcengine_mutelocalaudiostream */
        public abstract int MuteLocalAudioStream(bool mute);

        /* api_irtcengine_muteallremoteaudiostreams */
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        /* api_irtcengine_setdefaultmuteallremoteaudiostreams */
        [Obsolete("This method is deprecated. To set whether to receive remote")]
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        /* api_irtcengine_muteremoteaudiostream */
        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        /* api_irtcengine_mutelocalvideostream */
        public abstract int MuteLocalVideoStream(bool mute);

        /* api_irtcengine_enablelocalvideo */
        public abstract int EnableLocalVideo(bool enabled);

        /* api_irtcengine_muteallremotevideostreams */
        public abstract int MuteAllRemoteVideoStreams(bool mute);

        /* api_irtcengine_setdefaultmuteallremotevideostreams */
        [Obsolete("This method is deprecated. To set whether to receive remote")]
        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        /* api_irtcengine_muteremotevideostream */
        public abstract int MuteRemoteVideoStream(uint uid, bool mute);

        /* api_irtcengine_setremotevideostreamtype */
        public abstract int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType);

        /* api_irtcengine_setremotevideosubscriptionoptions */
        public abstract int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options);

        /* api_irtcengine_setremotedefaultvideostreamtype */
        public abstract int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType);

        /* api_irtcengine_setsubscribeaudioblocklist */
        public abstract int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber);

        /* api_irtcengine_setsubscribeaudioallowlist */
        public abstract int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber);

        /* api_irtcengine_setsubscribevideoblocklist */
        public abstract int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber);

        /* api_irtcengine_setsubscribevideoallowlist */
        public abstract int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber);

        /* api_irtcengine_enableaudiovolumeindication */
        public abstract int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad);

        /* api_irtcengine_startaudiorecording */
        public abstract int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality);

        /* api_irtcengine_startaudiorecording2 */
        public abstract int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        /* api_irtcengine_startaudiorecording3 */
        public abstract int StartAudioRecording(AudioRecordingConfiguration config);

        /* api_irtcengine_registeraudioencodedframeobserver */
        public abstract int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer);

        /* api_irtcengine_stopaudiorecording */
        public abstract int StopAudioRecording();

        /* api_irtcengine_createmediaplayer */
        public abstract IMediaPlayer CreateMediaPlayer();

        /* api_irtcengine_destroymediaplayer */
        public abstract int DestroyMediaPlayer(IMediaPlayer media_player);

        /* api_irtcengine_createmediarecorder */
        public abstract IMediaRecorder CreateMediaRecorder(RecorderStreamInfo info);

        /* api_irtcengine_destroymediarecorder */
        public abstract int DestroyMediaRecorder(IMediaRecorder mediaRecorder);

        /* api_irtcengine_startaudiomixing */
        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle);

        /* api_irtcengine_startaudiomixing2 */
        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos);

        /* api_irtcengine_stopaudiomixing */
        public abstract int StopAudioMixing();

        /* api_irtcengine_pauseaudiomixing */
        public abstract int PauseAudioMixing();

        /* api_irtcengine_resumeaudiomixing */
        public abstract int ResumeAudioMixing();

        /* api_irtcengine_selectaudiotrack */
        public abstract int SelectAudioTrack(int index);

        /* api_irtcengine_getaudiotrackcount */
        public abstract int GetAudioTrackCount();

        /* api_irtcengine_adjustaudiomixingvolume */
        public abstract int AdjustAudioMixingVolume(int volume);

        /* api_irtcengine_adjustaudiomixingpublishvolume */
        public abstract int AdjustAudioMixingPublishVolume(int volume);

        /* api_irtcengine_getaudiomixingpublishvolume */
        public abstract int GetAudioMixingPublishVolume();

        /* api_irtcengine_adjustaudiomixingplayoutvolume */
        public abstract int AdjustAudioMixingPlayoutVolume(int volume);

        /* api_irtcengine_getaudiomixingplayoutvolume */
        public abstract int GetAudioMixingPlayoutVolume();

        /* api_irtcengine_getaudiomixingduration */
        public abstract int GetAudioMixingDuration();

        /* api_irtcengine_getaudiomixingcurrentposition */
        public abstract int GetAudioMixingCurrentPosition();

        /* api_irtcengine_setaudiomixingposition */
        public abstract int SetAudioMixingPosition(int pos);

        /* api_irtcengine_setaudiomixingdualmonomode */
        public abstract int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode);

        /* api_irtcengine_setaudiomixingpitch */
        public abstract int SetAudioMixingPitch(int pitch);

        /* api_irtcengine_geteffectsvolume */
        public abstract int GetEffectsVolume();

        /* api_irtcengine_seteffectsvolume */
        public abstract int SetEffectsVolume(int volume);

        /* api_irtcengine_preloadeffect */
        public abstract int PreloadEffect(int soundId, string filePath, int startPos = 0);

        /* api_irtcengine_playeffect */
        public abstract int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0);

        /* api_irtcengine_playalleffects */
        public abstract int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false);

        /* api_irtcengine_getvolumeofeffect */
        public abstract int GetVolumeOfEffect(int soundId);

        /* api_irtcengine_setvolumeofeffect */
        public abstract int SetVolumeOfEffect(int soundId, int volume);

        /* api_irtcengine_pauseeffect */
        public abstract int PauseEffect(int soundId);

        /* api_irtcengine_pausealleffects */
        public abstract int PauseAllEffects();

        /* api_irtcengine_resumeeffect */
        public abstract int ResumeEffect(int soundId);

        /* api_irtcengine_resumealleffects */
        public abstract int ResumeAllEffects();

        /* api_irtcengine_stopeffect */
        public abstract int StopEffect(int soundId);

        /* api_irtcengine_stopalleffects */
        public abstract int StopAllEffects();

        /* api_irtcengine_unloadeffect */
        public abstract int UnloadEffect(int soundId);

        /* api_irtcengine_unloadalleffects */
        public abstract int UnloadAllEffects();

        /* api_irtcengine_geteffectduration */
        public abstract int GetEffectDuration(string filePath);

        /* api_irtcengine_seteffectposition */
        public abstract int SetEffectPosition(int soundId, int pos);

        /* api_irtcengine_geteffectcurrentposition */
        public abstract int GetEffectCurrentPosition(int soundId);

        /* api_irtcengine_enablesoundpositionindication */
        public abstract int EnableSoundPositionIndication(bool enabled);

        /* api_irtcengine_setremotevoiceposition */
        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        /* api_irtcengine_enablespatialaudio */
        public abstract int EnableSpatialAudio(bool enabled);

        /* api_irtcengine_setremoteuserspatialaudioparams */
        public abstract int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams @params);

        /* api_irtcengine_setvoicebeautifierpreset */
        public abstract int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset);

        /* api_irtcengine_setaudioeffectpreset */
        public abstract int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset);

        /* api_irtcengine_setvoiceconversionpreset */
        public abstract int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset);

        /* api_irtcengine_setaudioeffectparameters */
        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);

        /* api_irtcengine_setvoicebeautifierparameters */
        public abstract int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2);

        /* api_irtcengine_setvoiceconversionparameters */
        public abstract int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2);

        /* api_irtcengine_setlocalvoicepitch */
        public abstract int SetLocalVoicePitch(double pitch);

        /* api_irtcengine_setlocalvoiceformant */
        public abstract int SetLocalVoiceFormant(double formantRatio);

        /* api_irtcengine_setlocalvoiceequalization */
        public abstract int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);

        /* api_irtcengine_setlocalvoicereverb */
        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);

        /* api_irtcengine_setheadphoneeqpreset */
        public abstract int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset);

        /* api_irtcengine_setheadphoneeqparameters */
        public abstract int SetHeadphoneEQParameters(int lowGain, int highGain);

        /* api_irtcengine_setlogfile */
        public abstract int SetLogFile(string filePath);

        /* api_irtcengine_setlogfilter */
        public abstract int SetLogFilter(uint filter);

        /* api_irtcengine_setloglevel */
        public abstract int SetLogLevel(LOG_LEVEL level);

        /* api_irtcengine_setlogfilesize */
        public abstract int SetLogFileSize(uint fileSizeInKBytes);

        /* api_irtcengine_uploadlogfile */
        public abstract int UploadLogFile(ref string requestId);

        /* api_irtcengine_setlocalrendermode */
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        /* api_irtcengine_setremoterendermode */
        public abstract int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        /* api_irtcengine_setlocalrendermode2 */
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode);

        /* api_irtcengine_setlocalvideomirrormode */
        public abstract int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode);

        /* api_irtcengine_enabledualstreammode */
        [Obsolete("v4.2.0. This method is deprecated. Use setDualStreamMode instead.")]
        public abstract int EnableDualStreamMode(bool enabled);

        /* api_irtcengine_enabledualstreammode2 */
        [Obsolete("v4.2.0. This method is deprecated. Use setDualStreamMode instead.")]
        public abstract int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig);

        /* api_irtcengine_setdualstreammode */
        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode);

        /* api_irtcengine_setdualstreammode2 */
        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig);

        /* api_irtcengine_enablecustomaudiolocalplayback */
        public abstract int EnableCustomAudioLocalPlayback(uint trackId, bool enabled);

        /* api_irtcengine_setrecordingaudioframeparameters */
        public abstract int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        /* api_irtcengine_setplaybackaudioframeparameters */
        public abstract int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        /* api_irtcengine_setmixedaudioframeparameters */
        public abstract int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall);

        /* api_irtcengine_setearmonitoringaudioframeparameters */
        public abstract int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        /* api_irtcengine_setplaybackaudioframebeforemixingparameters */
        public abstract int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel);

        /* api_irtcengine_enableaudiospectrummonitor */
        public abstract int EnableAudioSpectrumMonitor(int intervalInMS = 100);

        /* api_irtcengine_disableaudiospectrummonitor */
        public abstract int DisableAudioSpectrumMonitor();

        /* api_irtcengine_registeraudiospectrumobserver */
        public abstract int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        /* api_irtcengine_unregisteraudiospectrumobserver */
        public abstract int UnregisterAudioSpectrumObserver();

        /* api_irtcengine_adjustrecordingsignalvolume */
        public abstract int AdjustRecordingSignalVolume(int volume);

        /* api_irtcengine_muterecordingsignal */
        public abstract int MuteRecordingSignal(bool mute);

        /* api_irtcengine_adjustplaybacksignalvolume */
        public abstract int AdjustPlaybackSignalVolume(int volume);

        /* api_irtcengine_adjustuserplaybacksignalvolume */
        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);

        /* api_irtcengine_setlocalpublishfallbackoption */
        public abstract int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option);

        /* api_irtcengine_setremotesubscribefallbackoption */
        public abstract int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option);

        /* api_irtcengine_sethighpriorityuserlist */
        public abstract int SetHighPriorityUserList(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option);

        /* api_irtcengine_enableloopbackrecording */
        public abstract int EnableLoopbackRecording(bool enabled, string deviceName = "");

        /* api_irtcengine_adjustloopbacksignalvolume */
        public abstract int AdjustLoopbackSignalVolume(int volume);

        /* api_irtcengine_getloopbackrecordingvolume */
        public abstract int GetLoopbackRecordingVolume();

        /* api_irtcengine_enableinearmonitoring */
        public abstract int EnableInEarMonitoring(bool enabled, int includeAudioFilters);

        /* api_irtcengine_setinearmonitoringvolume */
        public abstract int SetInEarMonitoringVolume(int volume);

        /* api_irtcengine_loadextensionprovider */
        public abstract int LoadExtensionProvider(string path, bool unload_after_use = false);

        /* api_irtcengine_setextensionproviderproperty */
        public abstract int SetExtensionProviderProperty(string provider, string key, string value);

        /* api_irtcengine_registerextension */
        public abstract int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        /* api_irtcengine_enableextension */
        public abstract int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        /* api_irtcengine_enableextension2 */
        public abstract int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable = true);

        /* api_irtcengine_setextensionproperty */
        public abstract int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        /* api_irtcengine_getextensionproperty */
        public abstract int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        /* api_irtcengine_setextensionproperty2 */
        public abstract int SetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, string value);

        /* api_irtcengine_getextensionproperty2 */
        public abstract int GetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, ref string value, int buf_len);

        /* api_irtcengine_setcameracapturerconfiguration */
        public abstract int SetCameraCapturerConfiguration(CameraCapturerConfiguration config);

        /* api_irtcengine_createcustomvideotrack */
        public abstract uint CreateCustomVideoTrack();

        /* api_irtcengine_createcustomencodedvideotrack */
        public abstract uint CreateCustomEncodedVideoTrack(SenderOptions sender_option);

        /* api_irtcengine_destroycustomvideotrack */
        public abstract int DestroyCustomVideoTrack(uint video_track_id);

        /* api_irtcengine_destroycustomencodedvideotrack */
        public abstract int DestroyCustomEncodedVideoTrack(uint video_track_id);

        /* api_irtcengine_switchcamera */
        public abstract int SwitchCamera();

        /* api_irtcengine_iscamerazoomsupported */
        public abstract bool IsCameraZoomSupported();

        /* api_irtcengine_iscamerafacedetectsupported */
        public abstract bool IsCameraFaceDetectSupported();

        /* api_irtcengine_iscameratorchsupported */
        public abstract bool IsCameraTorchSupported();

        /* api_irtcengine_iscamerafocussupported */
        public abstract bool IsCameraFocusSupported();

        /* api_irtcengine_iscameraautofocusfacemodesupported */
        public abstract bool IsCameraAutoFocusFaceModeSupported();

        /* api_irtcengine_setcamerazoomfactor */
        public abstract int SetCameraZoomFactor(float factor);

        /* api_irtcengine_enablefacedetection */
        public abstract int EnableFaceDetection(bool enabled);

        /* api_irtcengine_getcameramaxzoomfactor */
        public abstract float GetCameraMaxZoomFactor();

        /* api_irtcengine_setcamerafocuspositioninpreview */
        public abstract int SetCameraFocusPositionInPreview(float positionX, float positionY);

        /* api_irtcengine_setcameratorchon */
        public abstract int SetCameraTorchOn(bool isOn);

        /* api_irtcengine_setcameraautofocusfacemodeenabled */
        public abstract int SetCameraAutoFocusFaceModeEnabled(bool enabled);

        /* api_irtcengine_iscameraexposurepositionsupported */
        public abstract bool IsCameraExposurePositionSupported();

        /* api_irtcengine_setcameraexposureposition */
        public abstract int SetCameraExposurePosition(float positionXinView, float positionYinView);

        /* api_irtcengine_iscameraexposuresupported */
        public abstract bool IsCameraExposureSupported();

        /* api_irtcengine_setcameraexposurefactor */
        public abstract int SetCameraExposureFactor(float value);

        /* api_irtcengine_iscameraautoexposurefacemodesupported */
        public abstract bool IsCameraAutoExposureFaceModeSupported();

        /* api_irtcengine_setcameraautoexposurefacemodeenabled */
        public abstract int SetCameraAutoExposureFaceModeEnabled(bool enabled);

        /* api_irtcengine_setdefaultaudioroutetospeakerphone */
        public abstract int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker);

        /* api_irtcengine_setenablespeakerphone */
        public abstract int SetEnableSpeakerphone(bool speakerOn);

        /* api_irtcengine_isspeakerphoneenabled */
        public abstract bool IsSpeakerphoneEnabled();

        /* api_irtcengine_setrouteincommunicationmode */
        public abstract int SetRouteInCommunicationMode(int route);

        /* api_irtcengine_getscreencapturesources */
        public abstract ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen);

        /* api_irtcengine_setaudiosessionoperationrestriction */
        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);

        /* api_irtcengine_startscreencapturebydisplayid */
        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        /* api_irtcengine_startscreencapturebyscreenrect */
        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams);

        /* api_irtcengine_getaudiodeviceinfo */
        public abstract int GetAudioDeviceInfo(ref DeviceInfoMobile deviceInfo);

        /* api_irtcengine_startscreencapturebywindowid */
        public abstract int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        /* api_irtcengine_setscreencapturecontenthint */
        public abstract int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint);

        /* api_irtcengine_updatescreencaptureregion */
        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);

        /* api_irtcengine_updatescreencaptureparameters */
        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);

        /* api_irtcengine_startscreencapture */
        public abstract int StartScreenCapture(ScreenCaptureParameters2 captureParams);

        /* api_irtcengine_updatescreencapture */
        public abstract int UpdateScreenCapture(ScreenCaptureParameters2 captureParams);

        /* api_irtcengine_queryscreencapturecapability */
        public abstract int QueryScreenCaptureCapability();

        /* api_irtcengine_setscreencapturescenario */
        public abstract int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario);

        /* api_irtcengine_stopscreencapture */
        public abstract int StopScreenCapture();

        /* api_irtcengine_getcallid */
        public abstract int GetCallId(ref string callId);

        /* api_irtcengine_rate */
        public abstract int Rate(string callId, int rating, string description);

        /* api_irtcengine_complain */
        public abstract int Complain(string callId, string description);

        /* api_irtcengine_startrtmpstreamwithouttranscoding */
        public abstract int StartRtmpStreamWithoutTranscoding(string url);

        /* api_irtcengine_startrtmpstreamwithtranscoding */
        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);

        /* api_irtcengine_updatertmptranscoding */
        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);

        /* api_irtcengine_stoprtmpstream */
        public abstract int StopRtmpStream(string url);

        /* api_irtcengine_startlocalvideotranscoder */
        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfiguration config);

        /* api_irtcengine_updatelocaltranscoderconfiguration */
        public abstract int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config);

        /* api_irtcengine_stoplocalvideotranscoder */
        public abstract int StopLocalVideoTranscoder();

        /* api_irtcengine_startcameracapture */
        public abstract int StartCameraCapture(VIDEO_SOURCE_TYPE sourceType, CameraCapturerConfiguration config);

        /* api_irtcengine_stopcameracapture */
        public abstract int StopCameraCapture(VIDEO_SOURCE_TYPE sourceType);

        /* api_irtcengine_setcameradeviceorientation */
        public abstract int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        /* api_irtcengine_setscreencaptureorientation */
        public abstract int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        /* api_irtcengine_startscreencapture2 */
        public abstract int StartScreenCapture(VIDEO_SOURCE_TYPE sourceType, ScreenCaptureConfiguration config);

        /* api_irtcengine_stopscreencapture2 */
        public abstract int StopScreenCapture(VIDEO_SOURCE_TYPE sourceType);

        /* api_irtcengine_getconnectionstate */
        public abstract CONNECTION_STATE_TYPE GetConnectionState();

        /* api_irtcengine_setremoteuserpriority */
        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);

        /* api_irtcengine_setencryptionmode */
        [Obsolete("This method is deprecated. Use enableEncryption(bool enabled, const EncryptionConfig&) instead.")]
        public abstract int SetEncryptionMode(string encryptionMode);

        /* api_irtcengine_setencryptionsecret */
        [Obsolete("This method is deprecated. Use enableEncryption(bool enabled, const EncryptionConfig&) instead.")]
        public abstract int SetEncryptionSecret(string secret);

        /* api_irtcengine_enableencryption */
        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);

        /* api_irtcengine_createdatastream */
        public abstract int CreateDataStream(ref int streamId, bool reliable, bool ordered);

        /* api_irtcengine_createdatastream2 */
        public abstract int CreateDataStream(ref int streamId, DataStreamConfig config);

        /* api_irtcengine_sendstreammessage */
        public abstract int SendStreamMessage(int streamId, byte[] data, uint length);

        /* api_irtcengine_addvideowatermark */
        public abstract int AddVideoWatermark(RtcImage watermark);

        /* api_irtcengine_addvideowatermark2 */
        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);

        /* api_irtcengine_clearvideowatermarks */
        public abstract int ClearVideoWatermarks();

        /* api_irtcengine_pauseaudio */
        [Obsolete("Use disableAudio() instead.")]
        public abstract int PauseAudio();

        /* api_irtcengine_resumeaudio */
        [Obsolete("Use enableAudio() instead.")]
        public abstract int ResumeAudio();

        /* api_irtcengine_enablewebsdkinteroperability */
        [Obsolete("The Agora NG SDK enables the interoperablity with the Web SDK.")]
        public abstract int EnableWebSdkInteroperability(bool enabled);

        /* api_irtcengine_sendcustomreportmessage */
        public abstract int SendCustomReportMessage(string id, string category, string @event, string label, int value);

        /* api_irtcengine_registermediametadataobserver */
        public abstract int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type);

        /* api_irtcengine_unregistermediametadataobserver */
        public abstract int UnregisterMediaMetadataObserver();

        /* api_irtcengine_startaudioframedump */
        public abstract int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload);

        /* api_irtcengine_stopaudioframedump */
        public abstract int StopAudioFrameDump(string channel_id, uint user_id, string location);

        /* api_irtcengine_setainsmode */
        public abstract int SetAINSMode(bool enabled, AUDIO_AINS_MODE mode);

        /* api_irtcengine_registerlocaluseraccount */
        public abstract int RegisterLocalUserAccount(string appId, string userAccount);

        /* api_irtcengine_joinchannelwithuseraccount */
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        /* api_irtcengine_joinchannelwithuseraccount2 */
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options);

        /* api_irtcengine_getuserinfobyuseraccount */
        public abstract int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo);

        /* api_irtcengine_getuserinfobyuid */
        public abstract int GetUserInfoByUid(uint uid, ref UserInfo userInfo);

        /* api_irtcengine_startorupdatechannelmediarelay */
        public abstract int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        /* api_irtcengine_startchannelmediarelay */
        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelay` instead.")]
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        /* api_irtcengine_updatechannelmediarelay */
        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelay` instead.")]
        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        /* api_irtcengine_stopchannelmediarelay */
        public abstract int StopChannelMediaRelay();

        /* api_irtcengine_pauseallchannelmediarelay */
        public abstract int PauseAllChannelMediaRelay();

        /* api_irtcengine_resumeallchannelmediarelay */
        public abstract int ResumeAllChannelMediaRelay();

        /* api_irtcengine_setdirectcdnstreamingaudioconfiguration */
        public abstract int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile);

        /* api_irtcengine_setdirectcdnstreamingvideoconfiguration */
        public abstract int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config);

        /* api_irtcengine_startdirectcdnstreaming */
        public abstract int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options);

        /* api_irtcengine_stopdirectcdnstreaming */
        public abstract int StopDirectCdnStreaming();

        /* api_irtcengine_updatedirectcdnstreamingmediaoptions */
        public abstract int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options);

        /* api_irtcengine_startrhythmplayer */
        public abstract int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config);

        /* api_irtcengine_stoprhythmplayer */
        public abstract int StopRhythmPlayer();

        /* api_irtcengine_configrhythmplayer */
        public abstract int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config);

        /* api_irtcengine_takesnapshot */
        public abstract int TakeSnapshot(uint uid, string filePath);

        /* api_irtcengine_enablecontentinspect */
        public abstract int EnableContentInspect(bool enabled, ContentInspectConfig config);

        /* api_irtcengine_adjustcustomaudiopublishvolume */
        public abstract int AdjustCustomAudioPublishVolume(uint trackId, int volume);

        /* api_irtcengine_adjustcustomaudioplayoutvolume */
        public abstract int AdjustCustomAudioPlayoutVolume(uint trackId, int volume);

        /* api_irtcengine_setcloudproxy */
        public abstract int SetCloudProxy(CLOUD_PROXY_TYPE proxyType);

        /* api_irtcengine_setlocalaccesspoint */
        public abstract int SetLocalAccessPoint(LocalAccessPointConfiguration config);

        /* api_irtcengine_setadvancedaudiooptions */
        public abstract int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType = 0);

        /* api_irtcengine_setavsyncsource */
        public abstract int SetAVSyncSource(string channelId, uint uid);

        /* api_irtcengine_enablevideoimagesource */
        public abstract int EnableVideoImageSource(bool enable, ImageTrackOptions options);

        /* api_irtcengine_getcurrentmonotonictimeinms */
        public abstract long GetCurrentMonotonicTimeInMs();

        /* api_irtcengine_enablewirelessaccelerate */
        public abstract int EnableWirelessAccelerate(bool enabled);

        /* api_irtcengine_getnetworktype */
        public abstract int GetNetworkType();

        /* api_irtcengine_setparameters2 */
        public abstract int SetParameters(string parameters);

        /* api_irtcengine_startmediarenderingtracing */
        public abstract int StartMediaRenderingTracing();

        /* api_irtcengine_enableinstantmediarendering */
        public abstract int EnableInstantMediaRendering();

        /* api_irtcengine_getntpwalltimeinms */
        public abstract ulong GetNtpWallTimeInMs();
#endregion terra IRtcEngine

        /* api_irtcengine_registeraudioframeobserver */
        public abstract int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        /* api_irtcengine_registervideoframeobserver */
        public abstract int RegisterVideoFrameObserver(IVideoFrameObserver observer, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        /* api_irtcengine_registervideoencodedframeobserver */
        public abstract int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver observer, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        /* api_irtcengine_unregisteraudioframeobserver */
        public abstract int UnRegisterAudioFrameObserver();

        /* api_irtcengine_unregistervideoframeobserver */
        public abstract int UnRegisterVideoFrameObserver();

        /* api_irtcengine_unregisteraudioencodedframeobserver */
        public abstract int UnRegisterAudioEncodedFrameObserver();

        /* api_irtcengine_unregistervideoencodedframeobserver */
        public abstract int UnRegisterVideoEncodedFrameObserver();

#region terra IMediaEngine

        /* api_irtcengine_pushaudioframe */
        public abstract int PushAudioFrame(AudioFrame frame, uint trackId = 0);

        /* api_irtcengine_pullaudioframe */
        public abstract int PullAudioFrame(AudioFrame frame);

        /* api_irtcengine_setexternalvideosource */
        public abstract int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption);

        /* api_irtcengine_setexternalaudiosource */
        [Obsolete("This method is deprecated. Use createCustomAudioTrack(rtc::AUDIO_TRACK_TYPE trackType, const rtc::AudioTrackConfig& config) instead.")]
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels, bool localPlayback = false, bool publish = true);

        /* api_irtcengine_createcustomaudiotrack */
        public abstract uint CreateCustomAudioTrack(AUDIO_TRACK_TYPE trackType, AudioTrackConfig config);

        /* api_irtcengine_destroycustomaudiotrack */
        public abstract int DestroyCustomAudioTrack(uint trackId);

        /* api_irtcengine_setexternalaudiosink */
        public abstract int SetExternalAudioSink(bool enabled, int sampleRate, int channels);

        /* api_irtcengine_pushvideoframe */
        public abstract int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0);

        /* api_irtcengine_pushencodedvideoimage */
        public abstract int PushEncodedVideoImage(byte[] imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0);

#endregion terra IMediaEngine
    };

    /* class_irtcengineex */
    public abstract class IRtcEngineEx : IRtcEngine
    {

#region terra IRtcEngineEx

        /* api_irtcengineex_joinchannelex */
        public abstract int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options);

        /* api_irtcengineex_leavechannelex */
        public abstract int LeaveChannelEx(RtcConnection connection);

        /* api_irtcengineex_leavechannelex2 */
        public abstract int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options);

        /* api_irtcengineex_updatechannelmediaoptionsex */
        public abstract int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection);

        /* api_irtcengineex_setvideoencoderconfigurationex */
        public abstract int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection);

        /* api_irtcengineex_setupremotevideoex */
        public abstract int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection);

        /* api_irtcengineex_muteremoteaudiostreamex */
        public abstract int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection);

        /* api_irtcengineex_muteremotevideostreamex */
        public abstract int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection);

        /* api_irtcengineex_setremotevideostreamtypeex */
        public abstract int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection);

        /* api_irtcengineex_mutelocalaudiostreamex */
        public abstract int MuteLocalAudioStreamEx(bool mute, RtcConnection connection);

        /* api_irtcengineex_mutelocalvideostreamex */
        public abstract int MuteLocalVideoStreamEx(bool mute, RtcConnection connection);

        /* api_irtcengineex_muteallremoteaudiostreamsex */
        public abstract int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection);

        /* api_irtcengineex_muteallremotevideostreamsex */
        public abstract int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection);

        /* api_irtcengineex_setsubscribeaudioblocklistex */
        public abstract int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        /* api_irtcengineex_setsubscribeaudioallowlistex */
        public abstract int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        /* api_irtcengineex_setsubscribevideoblocklistex */
        public abstract int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        /* api_irtcengineex_setsubscribevideoallowlistex */
        public abstract int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        /* api_irtcengineex_setremotevideosubscriptionoptionsex */
        public abstract int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection);

        /* api_irtcengineex_setremotevoicepositionex */
        public abstract int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection);

        /* api_irtcengineex_setremoteuserspatialaudioparamsex */
        public abstract int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams @params, RtcConnection connection);

        /* api_irtcengineex_setremoterendermodeex */
        public abstract int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection);

        /* api_irtcengineex_enableloopbackrecordingex */
        public abstract int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName = "");

        /* api_irtcengineex_adjustrecordingsignalvolumeex */
        public abstract int AdjustRecordingSignalVolumeEx(int volume, RtcConnection connection);

        /* api_irtcengineex_muterecordingsignalex */
        public abstract int MuteRecordingSignalEx(bool mute, RtcConnection connection);

        /* api_irtcengineex_adjustuserplaybacksignalvolumeex */
        public abstract int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection);

        /* api_irtcengineex_getconnectionstateex */
        public abstract CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection);

        /* api_irtcengineex_enableencryptionex */
        public abstract int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config);

        /* api_irtcengineex_createdatastreamex */
        public abstract int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection);

        /* api_irtcengineex_createdatastreamex2 */
        public abstract int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection);

        /* api_irtcengineex_sendstreammessageex */
        public abstract int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection);

        /* api_irtcengineex_addvideowatermarkex */
        public abstract int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection);

        /* api_irtcengineex_clearvideowatermarkex */
        public abstract int ClearVideoWatermarkEx(RtcConnection connection);

        /* api_irtcengineex_sendcustomreportmessageex */
        public abstract int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection);

        /* api_irtcengineex_enableaudiovolumeindicationex */
        public abstract int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection);

        /* api_irtcengineex_startrtmpstreamwithouttranscodingex */
        public abstract int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection);

        /* api_irtcengineex_startrtmpstreamwithtranscodingex */
        public abstract int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection);

        /* api_irtcengineex_updatertmptranscodingex */
        public abstract int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection);

        /* api_irtcengineex_stoprtmpstreamex */
        public abstract int StopRtmpStreamEx(string url, RtcConnection connection);

        /* api_irtcengineex_startorupdatechannelmediarelayex */
        public abstract int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        /* api_irtcengineex_startchannelmediarelayex */
        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelayEx` instead.")]
        public abstract int StartChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        /* api_irtcengineex_updatechannelmediarelayex */
        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelayEx` instead.")]
        public abstract int UpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        /* api_irtcengineex_stopchannelmediarelayex */
        public abstract int StopChannelMediaRelayEx(RtcConnection connection);

        /* api_irtcengineex_pauseallchannelmediarelayex */
        public abstract int PauseAllChannelMediaRelayEx(RtcConnection connection);

        /* api_irtcengineex_resumeallchannelmediarelayex */
        public abstract int ResumeAllChannelMediaRelayEx(RtcConnection connection);

        /* api_irtcengineex_getuserinfobyuseraccountex */
        public abstract int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection);

        /* api_irtcengineex_getuserinfobyuidex */
        public abstract int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection);

        /* api_irtcengineex_enabledualstreammodeex */
        [Obsolete("v4.2.0. This method is deprecated. Use setDualStreamModeEx instead")]
        public abstract int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection);

        /* api_irtcengineex_setdualstreammodeex */
        public abstract int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection);

        /* api_irtcengineex_sethighpriorityuserlistex */
        public abstract int SetHighPriorityUserListEx(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnection connection);

        /* api_irtcengineex_takesnapshotex */
        public abstract int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath);

        /* api_irtcengineex_startmediarenderingtracingex */
        public abstract int StartMediaRenderingTracingEx(RtcConnection connection);
#endregion terra IRtcEngineEx
    }
}