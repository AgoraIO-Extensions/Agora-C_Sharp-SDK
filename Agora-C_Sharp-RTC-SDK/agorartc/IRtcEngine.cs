using System;

namespace agora.rtc
{
    public class IRtcEngine
    {
        private static IRtcEngine instance = null;
        private RtcEngineImpl _rtcEngineNative = null;
        private IMediaPlayer _mediaPlayerInstance = null;
        private IAudioDeviceManager _audioDeviceManager = null;
        private IVideoDeviceManager _videoDeviceManager = null;
        private ICloudSpatialAudioEngine _cloudSpatialAudioEngine = null;
        private ILocalSpatialAudioEngine _localSpatialAudioEngine = null;

        private IRtcEngine()
        {
            _rtcEngineNative = RtcEngineImpl.CreateRtcEngineImpl();
            _mediaPlayerInstance = IMediaPlayer.GetInstance(_rtcEngineNative.GetMediaPlayer());
            _audioDeviceManager = IAudioDeviceManager.GetInstance(_rtcEngineNative.GetAudioDeviceManager());
            _videoDeviceManager = IVideoDeviceManager.GetInstance(_rtcEngineNative.GetVideoDeviceManager());
            _cloudSpatialAudioEngine = ICloudSpatialAudioEngine.GetInstance(_rtcEngineNative.GetCloudSpatialAudioEngine());
            _localSpatialAudioEngine = ILocalSpatialAudioEngine.GetInstance(_rtcEngineNative.GetLocalSpatialAudioEngine());
        }

        public static IRtcEngine CreateAgoraRtcEngine()
        {
            return instance ?? (instance = new IRtcEngine());
        }

        public static IRtcEngine Get()
        {
            return instance;
        }

        public int Initialize(RtcEngineContext context)
        {
            return _rtcEngineNative.Initialize(context);
        }

        public void Dispose(bool sync = false)
        {
            _rtcEngineNative.Dispose(sync);
            _rtcEngineNative = null;
        }

        public RtcEngineEventHandler GetRtcEngineEventHandler()
        {
            return _rtcEngineNative.GetRtcEngineEventHandler();
        }

        public void InitEventHandler(IRtcEngineEventHandler engineEventHandler)
        {
            _rtcEngineNative.InitEventHandler(engineEventHandler);
        }

        public void RemoveEventHandler()
        {
            _rtcEngineNative.RemoveEventHandler();
        }

        public void RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
             _rtcEngineNative.RegisterAudioFrameObserver(audioFrameObserver, mode);
        }

        public void UnRegisterAudioFrameObserver()
        {
            _rtcEngineNative.UnRegisterAudioFrameObserver();
        }

        public void RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineNative.RegisterVideoFrameObserver(videoFrameObserver, mode);
        }

        public void UnRegisterVideoFrameObserver()
        {
            _rtcEngineNative.UnRegisterVideoFrameObserver();
        }

        public void RegisterVideoEncodedImageReceiver(IVideoEncodedImageReceiver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineNative.RegisterVideoEncodedImageReceiver(videoEncodedImageReceiver, mode);
        }

        public void UnRegisterVideoEncodedImageReceiver()
        {
            _rtcEngineNative.UnRegisterVideoEncodedImageReceiver();
        }

        public IAudioDeviceManager GetAudioDeviceManager()
        {
            return _audioDeviceManager;
        }

        public IVideoDeviceManager GetVideoDeviceManager()
        {
            return _videoDeviceManager;
        }

        public IMediaPlayer GetMediaPlayer()
        {
            return _mediaPlayerInstance;
        }

        public ICloudSpatialAudioEngine GetCloudSpatialAudioEngine()
        {
            return _cloudSpatialAudioEngine;
        }

        public ILocalSpatialAudioEngine GetLocalSpatialAudioEngine()
        {
            return _localSpatialAudioEngine;
        }

        public string GetVersion()
        {
            return _rtcEngineNative.GetVersion();
        }

        public string GetErrorDescription(int code)
        {
            return _rtcEngineNative.GetErrorDescription(code);
        }

        public int JoinChannel(string token, string channelId, string info = "", uint uid = 0)
        {
            return _rtcEngineNative.JoinChannel(token, channelId, info, uid);
        }

        public int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options)
        {
            return _rtcEngineNative.JoinChannel(token, channelId, uid, options);
        }

        public int UpdateChannelMediaOptions(ChannelMediaOptions options)
        {
            return _rtcEngineNative.UpdateChannelMediaOptions(options);
        }

        public int LeaveChannel()
        {
            return _rtcEngineNative.LeaveChannel();
        }

        public int LeaveChannel(LeaveChannelOptions options)
        {
            return _rtcEngineNative.LeaveChannel(options);
        }

        public int RenewToken(string token)
        {
            return _rtcEngineNative.RenewToken(token);
        }

        public int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            return _rtcEngineNative.SetChannelProfile(profile);
        }

        public int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            return _rtcEngineNative.SetClientRole(role);
        }

        public int SetClientRole(CLIENT_ROLE_TYPE role, ref ClientRoleOptions options)
        {
            return _rtcEngineNative.SetClientRole(role, ref options);
        }

        public int StartEchoTest()
        {
            return _rtcEngineNative.StartEchoTest();
        }

        public int StartEchoTest(int intervalInSeconds)
        {
            return _rtcEngineNative.StartEchoTest(intervalInSeconds);
        }

        public int StopEchoTest()
        {
            return _rtcEngineNative.StopEchoTest();
        }

        public int EnableVideo()
        {
            return _rtcEngineNative.EnableVideo();
        }

        public int DisableVideo()
        {
            return _rtcEngineNative.DisableVideo();
        }

        public int StartPreview()
        {
            return _rtcEngineNative.StartPreview();
        }

        public int StartPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineNative.StartPreview();
        }

        public int StopPreview()
        {
            return _rtcEngineNative.StopPreview();
        }

        public int StopPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineNative.StopPreview(sourceType);
        }

        public int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            return _rtcEngineNative.StartLastmileProbeTest(config);
        }

        public int StopLastmileProbeTest()
        {
            return _rtcEngineNative.StopLastmileProbeTest();
        }

        public int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            return _rtcEngineNative.SetVideoEncoderConfiguration(config);
        }

        public int SetBeautyEffectOptions(bool enabled, BeautyOptions options)
        {
            return _rtcEngineNative.SetBeautyEffectOptions(enabled, options);
        }

        public int SetupRemoteVideo(VideoCanvas canvas)
        {
            return _rtcEngineNative.SetupRemoteVideo(canvas);
        }

        public int SetupLocalVideo(VideoCanvas canvas)
        {
            return _rtcEngineNative.SetupLocalVideo(canvas);
        }

        public int EnableAudio()
        {
            return _rtcEngineNative.EnableAudio();
        }

        public int DisableAudio()
        {
            return _rtcEngineNative.DisableAudio();
        }

        public int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            return _rtcEngineNative.SetAudioProfile(profile, scenario);
        }

        public int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            return _rtcEngineNative.SetAudioProfile(profile);
        }

        public int EnableLocalAudio(bool enabled)
        {
            return _rtcEngineNative.EnableLocalAudio(enabled);
        }

        public int MuteLocalAudioStream(bool mute)
        {
            return _rtcEngineNative.MuteLocalAudioStream(mute);
        }

        public int MuteAllRemoteAudioStreams(bool mute)
        {
            return _rtcEngineNative.MuteAllRemoteAudioStreams(mute);
        }

        public int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            return _rtcEngineNative.SetDefaultMuteAllRemoteAudioStreams(mute);
        }

        public int MuteRemoteAudioStream(uint uid, bool mute)
        {
            return _rtcEngineNative.MuteRemoteAudioStream(uid, mute);
        }

        public int MuteLocalVideoStream(bool mute)
        {
            return _rtcEngineNative.MuteLocalVideoStream(mute);
        }

        public int EnableLocalVideo(bool enabled)
        {
            return _rtcEngineNative.EnableLocalVideo(enabled);
        }

        public int MuteAllRemoteVideoStreams(bool mute)
        {
            return _rtcEngineNative.MuteAllRemoteVideoStreams(mute);
        }

        public int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            return _rtcEngineNative.SetDefaultMuteAllRemoteVideoStreams(mute);
        }

        public int MuteRemoteVideoStream(uint uid, bool mute)
        {
            return _rtcEngineNative.MuteRemoteVideoStream(uid, mute);
        }

        public int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            return _rtcEngineNative.SetRemoteVideoStreamType(uid, streamType);
        }

        public int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            return _rtcEngineNative.SetRemoteDefaultVideoStreamType(streamType);
        }

        public int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            return _rtcEngineNative.EnableAudioVolumeIndication(interval, smooth, reportVad);
        }

        public int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return _rtcEngineNative.StartAudioRecording(filePath, quality);
        }

        public int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return _rtcEngineNative.StartAudioRecording(filePath, sampleRate, quality);
        }

        public int StartAudioRecording(AudioRecordingConfiguration config)
        {
            return _rtcEngineNative.StartAudioRecording(config);
        }

        public void RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)
        {
            _rtcEngineNative.RegisterAudioEncodedFrameObserver(config, observer);
        }

        public void UnRegisterAudioEncodedFrameObserver()
        {
            _rtcEngineNative.UnRegisterAudioEncodedFrameObserver();
        }

        public int StopAudioRecording()
        {
            return _rtcEngineNative.StopAudioRecording();
        }

        public int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle)
        {
            return _rtcEngineNative.StartAudioMixing(filePath, loopback, replace, cycle);
        }

        public int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int startPos)
        {
            return _rtcEngineNative.StartAudioMixing(filePath, loopback, replace, cycle, startPos);
        }

        public int StopAudioMixing()
        {
            return _rtcEngineNative.StopAudioMixing();
        }

        public int PauseAudioMixing()
        {
            return _rtcEngineNative.PauseAudioMixing();
        }

        public int ResumeAudioMixing()
        {
            return _rtcEngineNative.ResumeAudioMixing();
        }

        public int AdjustAudioMixingVolume(int volume)
        {
            return _rtcEngineNative.AdjustAudioMixingVolume(volume);
        }

        public int AdjustAudioMixingPublishVolume(int volume)
        {
            return _rtcEngineNative.AdjustAudioMixingPublishVolume(volume);
        }

        public int GetAudioMixingPublishVolume()
        {
            return _rtcEngineNative.GetAudioMixingPublishVolume();
        }

        public int AdjustAudioMixingPlayoutVolume(int volume)
        {
            return _rtcEngineNative.AdjustAudioMixingPlayoutVolume(volume);
        }

        public int GetAudioMixingPlayoutVolume()
        {
            return _rtcEngineNative.GetAudioMixingPlayoutVolume();
        }

        public int GetAudioMixingDuration()
        {
            return _rtcEngineNative.GetAudioMixingDuration();
        }

        public int GetAudioMixingCurrentPosition()
        {
            return _rtcEngineNative.GetAudioMixingCurrentPosition();
        }

        public int SetAudioMixingPosition(int pos)
        {
            return _rtcEngineNative.SetAudioMixingPosition(pos);
        }

        public int SetAudioMixingPitch(int pitch)
        {
            return _rtcEngineNative.SetAudioMixingPitch(pitch);
        }

        public int GetEffectsVolume()
        {
            return _rtcEngineNative.GetEffectsVolume();
        }

        public int SetEffectsVolume(int volume)
        {
            return _rtcEngineNative.SetEffectsVolume(volume);
        }

        public int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            return _rtcEngineNative.PreloadEffect(soundId, filePath, startPos);
        }

        public int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)
        {
            return _rtcEngineNative.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);
        }

        public int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false)
        {
            return _rtcEngineNative.PlayAllEffects(loopCount, pitch, pan, gain, publish);
        }

        public int GetVolumeOfEffect(int soundId)
        {
            return _rtcEngineNative.GetVolumeOfEffect(soundId);
        }

        public int SetVolumeOfEffect(int soundId, int volume)
        {
            return _rtcEngineNative.SetVolumeOfEffect(soundId, volume);
        }

        public int PauseEffect(int soundId)
        {
            return _rtcEngineNative.PauseEffect(soundId);
        }

        public int PauseAllEffects()
        {
            return _rtcEngineNative.PauseAllEffects();
        }

        public int ResumeEffect(int soundId)
        {
            return _rtcEngineNative.ResumeEffect(soundId);
        }

        public int ResumeAllEffects()
        {
            return _rtcEngineNative.ResumeAllEffects();
        }

        public int StopEffect(int soundId)
        {
            return _rtcEngineNative.StopEffect(soundId);
        }

        public int StopAllEffects()
        {
            return _rtcEngineNative.StopAllEffects();
        }

        public int UnloadEffect(int soundId)
        {
            return _rtcEngineNative.UnloadEffect(soundId);
        }

        public int UnloadAllEffects()
        {
            return _rtcEngineNative.UnloadAllEffects();
        }

        public int EnableSoundPositionIndication(bool enabled)
        {
            return _rtcEngineNative.EnableSoundPositionIndication(enabled);
        }

        public int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            return _rtcEngineNative.SetRemoteVoicePosition(uid, pan, gain);
        }

        public int EnableSpatialAudio(bool enabled)
        {
            return _rtcEngineNative.EnableSpatialAudio(enabled);
        }

        public int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param)
        {
            return _rtcEngineNative.SetRemoteUserSpatialAudioParams(uid, param);
        }

        public int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            return _rtcEngineNative.SetVoiceBeautifierPreset(preset);
        }

        public int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            return _rtcEngineNative.SetAudioEffectPreset(preset);
        }

        public int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            return _rtcEngineNative.SetVoiceConversionPreset(preset);
        }

        public int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            return _rtcEngineNative.SetAudioEffectParameters(preset, param1, param2);
        }

        public int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2)
        {
            return _rtcEngineNative.SetVoiceBeautifierParameters(preset, param1, param2);
        }

        public int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2)
        {
            return _rtcEngineNative.SetVoiceConversionParameters(preset, param1, param2);
        }

        public int SetLocalVoicePitch(double pitch)
        {
            return _rtcEngineNative.SetLocalVoicePitch(pitch);
        }

        public int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            return _rtcEngineNative.SetLocalVoiceEqualization(bandFrequency, bandGain);
        }

        public int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            return _rtcEngineNative.SetLocalVoiceReverb(reverbKey, value);
        }

        public int SetLogFile(string filePath)
        {
            return _rtcEngineNative.SetLogFile(filePath);
        }

        public int SetLogFilter(uint filter)
        {
            return _rtcEngineNative.SetLogFilter(filter);
        }

        public int SetLogLevel(LOG_LEVEL level)
        {
            return _rtcEngineNative.SetLogLevel(level);
        }

        public int SetLogFileSize(uint fileSizeInKBytes)
        {
            return _rtcEngineNative.SetLogFileSize(fileSizeInKBytes);
        }

        public int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineNative.SetLocalRenderMode(renderMode, mirrorMode);
        }

        public int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineNative.SetRemoteRenderMode(uid, renderMode, mirrorMode);
        }

        public int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            return _rtcEngineNative.SetLocalRenderMode(renderMode);
        }

        public int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineNative.SetLocalVideoMirrorMode(mirrorMode);
        }

        public int EnableDualStreamMode(bool enabled)
        {
            return _rtcEngineNative.EnableDualStreamMode(enabled);
        }

        public int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled)
        {
            return _rtcEngineNative.EnableDualStreamMode(sourceType, enabled);
        }

        public int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig)
        {
            return _rtcEngineNative.EnableDualStreamMode(sourceType, enabled, streamConfig);
        }

        public int SetExternalAudioSink(int sampleRate, int channels)
        {
            return _rtcEngineNative.SetExternalAudioSink(sampleRate, channels);
        }

        public int StartPrimaryCustomAudioTrack(AudioTrackConfig config)
        {
            return _rtcEngineNative.StartPrimaryCustomAudioTrack(config);
        }

        public int StopPrimaryCustomAudioTrack()
        {
            return _rtcEngineNative.StopPrimaryCustomAudioTrack();
        }

        public int StartSecondaryCustomAudioTrack(AudioTrackConfig config)
        {
            return _rtcEngineNative.StartSecondaryCustomAudioTrack(config);
        }

        public int StopSecondaryCustomAudioTrack()
        {
            return _rtcEngineNative.StopSecondaryCustomAudioTrack();
        }

        public int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return _rtcEngineNative.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
        }

        public int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return _rtcEngineNative.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
        }

        public int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            return _rtcEngineNative.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
        }

        public int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            return _rtcEngineNative.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
        }

        public int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            return _rtcEngineNative.EnableAudioSpectrumMonitor(intervalInMS);
        }

        public int DisableAudioSpectrumMonitor()
        {
            return _rtcEngineNative.DisableAudioSpectrumMonitor();
        }

        public void RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            _rtcEngineNative.RegisterAudioSpectrumObserver(observer);
        }

        public void UnregisterAudioSpectrumObserver()
        {
            _rtcEngineNative.UnregisterAudioSpectrumObserver();
        }

        public int AdjustRecordingSignalVolume(int volume)
        {
            return _rtcEngineNative.AdjustRecordingSignalVolume(volume);
        }

        public int MuteRecordingSignal(bool mute)
        {
            return _rtcEngineNative.MuteRecordingSignal(mute);
        }

        public int AdjustPlaybackSignalVolume(int volume)
        {
            return _rtcEngineNative.AdjustPlaybackSignalVolume(volume);
        }

        public int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            return _rtcEngineNative.AdjustUserPlaybackSignalVolume(uid, volume);
        }

        public int EnableLoopbackRecording(bool enabled)
        {
            return _rtcEngineNative.EnableLoopbackRecording(enabled);
        }

        public int AdjustLoopbackRecordingVolume(int volume)
        {
            return _rtcEngineNative.AdjustLoopbackRecordingVolume(volume);
        }

        public int GetLoopbackRecordingVolume()
        {
            return _rtcEngineNative.GetLoopbackRecordingVolume();
        }

        public int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            return _rtcEngineNative.EnableInEarMonitoring(enabled, includeAudioFilters);
        }

        public int SetInEarMonitoringVolume(int volume)
        {
            return _rtcEngineNative.SetInEarMonitoringVolume(volume);
        }

        public int LoadExtensionProvider(string extension_lib_path)
        {
            return _rtcEngineNative.LoadExtensionProvider(extension_lib_path);
        }

        public int SetExtensionProviderProperty(string provider, string key, string value)
        {
            return _rtcEngineNative.SetExtensionProviderProperty(provider, key, value);
        }

        public int EnableExtension(string provider, string extension, bool enable = true)
        {
            return _rtcEngineNative.EnableExtension(provider, extension, enable);
        }

        public int SetExtensionProperty(string provider, string extension, string key, string value)
        {
            return _rtcEngineNative.SetExtensionProperty(provider, extension, key, value);
        }

        public int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            return _rtcEngineNative.GetExtensionProperty(provider, extension, key, ref value, buf_len, type);
        }

        public int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            return _rtcEngineNative.SetCameraCapturerConfiguration(config);
        }

        public int SwitchCamera()
        {
            return _rtcEngineNative.SwitchCamera();
        }

        public bool IsCameraZoomSupported()
        {
            return _rtcEngineNative.IsCameraZoomSupported();
        }

        public bool IsCameraFaceDetectSupported()
        {
            return _rtcEngineNative.IsCameraFaceDetectSupported();
        }

        public bool IsCameraTorchSupported()
        {
            return _rtcEngineNative.IsCameraTorchSupported();
        }

        public bool IsCameraFocusSupported()
        {
            return _rtcEngineNative.IsCameraFocusSupported();
        }

        public bool IsCameraAutoFocusFaceModeSupported()
        {
            return _rtcEngineNative.IsCameraAutoFocusFaceModeSupported();
        }

        public int SetCameraZoomFactor(float factor)
        {
            return _rtcEngineNative.SetCameraZoomFactor(factor);
        }

        public int EnableFaceDetection(bool enabled)
        {
            return _rtcEngineNative.EnableFaceDetection(enabled);
        }

        public float GetCameraMaxZoomFactor()
        {
            return _rtcEngineNative.GetCameraMaxZoomFactor();
        }

        public int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            return _rtcEngineNative.SetCameraFocusPositionInPreview(positionX, positionY);
        }

        public int SetCameraTorchOn(bool isOn)
        {
            return _rtcEngineNative.SetCameraTorchOn(isOn);
        }

        public int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            return _rtcEngineNative.SetCameraAutoFocusFaceModeEnabled(enabled);
        }

        public bool IsCameraExposurePositionSupported()
        {
            return _rtcEngineNative.IsCameraExposurePositionSupported();
        }

        public int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            return _rtcEngineNative.SetCameraExposurePosition(positionXinView, positionYinView);
        }

        public bool IsCameraAutoExposureFaceModeSupported()
        {
            return _rtcEngineNative.IsCameraAutoExposureFaceModeSupported();
        }

        public int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            return _rtcEngineNative.SetCameraAutoExposureFaceModeEnabled(enabled);
        }

        public int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            return _rtcEngineNative.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
        }

        public int SetEnableSpeakerphone(bool speakerOn)
        {
            return _rtcEngineNative.SetEnableSpeakerphone(speakerOn);
        }

        public bool IsSpeakerphoneEnabled()
        {
            return _rtcEngineNative.IsSpeakerphoneEnabled();
        }

        public int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineNative.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
        }

        public int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineNative.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
        }

        public int StartScreenCapture(byte[] mediaProjectionPermissionResultData, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineNative.StartScreenCapture(mediaProjectionPermissionResultData, captureParams);
        }

        public int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineNative.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
        }

        public int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            return _rtcEngineNative.SetScreenCaptureContentHint(contentHint);
        }

        public int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            return _rtcEngineNative.UpdateScreenCaptureRegion(regionRect);
        }

        public int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            return _rtcEngineNative.UpdateScreenCaptureParameters(captureParams);
        }

        public int StopScreenCapture()
        {
            return _rtcEngineNative.StopScreenCapture();
        }

        public string GetCallId()
        {
            return _rtcEngineNative.GetCallId();
        }

        public int Rate(string callId, int rating, string description)
        {
            return _rtcEngineNative.Rate(callId, rating, description);
        }

        public int Complain(string callId, string description)
        {
            return _rtcEngineNative.Complain(callId, description);
        }

        public int AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            return _rtcEngineNative.AddPublishStreamUrl(url, transcodingEnabled);
        }

        public int RemovePublishStreamUrl(string url)
        {
            return _rtcEngineNative.RemovePublishStreamUrl(url);
        }

        public int SetLiveTranscoding(LiveTranscoding transcoding)
        {
            return _rtcEngineNative.SetLiveTranscoding(transcoding);
        }

        public int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            return _rtcEngineNative.StartLocalVideoTranscoder(config);
        }

        public int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            return _rtcEngineNative.UpdateLocalTranscoderConfiguration(config);
        }

        public int StopLocalVideoTranscoder()
        {
            return _rtcEngineNative.StopLocalVideoTranscoder();
        }

        public int StartPrimaryCameraCapture(CameraCapturerConfiguration config)
        {
            return _rtcEngineNative.StartPrimaryCameraCapture(config);
        }

        public int StartSecondaryCameraCapture(CameraCapturerConfiguration config)
        {
            return _rtcEngineNative.StartSecondaryCameraCapture(config);
        }

        public int StopPrimaryCameraCapture()
        {
            return _rtcEngineNative.StopPrimaryCameraCapture();
        }

        public int StopSecondaryCameraCapture()
        {
            return _rtcEngineNative.StopSecondaryCameraCapture();
        }

        public int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            return _rtcEngineNative.SetCameraDeviceOrientation(type, orientation);
        }

        public int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            return _rtcEngineNative.SetScreenCaptureOrientation(type, orientation);
        }

        public int StartPrimaryScreenCapture(ScreenCaptureConfiguration config)
        {
            return _rtcEngineNative.StartPrimaryScreenCapture(config);
        }

        public int StartSecondaryScreenCapture(ScreenCaptureConfiguration config)
        {
            return _rtcEngineNative.StartSecondaryScreenCapture(config);
        }

        public int StopPrimaryScreenCapture()
        {
            return _rtcEngineNative.StopPrimaryScreenCapture();
        }

        public int StopSecondaryScreenCapture()
        {
            return _rtcEngineNative.StopSecondaryScreenCapture();
        }

        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            return _rtcEngineNative.GetConnectionState();
        }

        public int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            return _rtcEngineNative.SetRemoteUserPriority(uid, userPriority);
        }

        //public int RegisterPacketObserver(IPacketObserver observer)
        //{
        //    return _rtcEngineNative.Initialize(context);
        //}

        public int SetEncryptionMode(string encryptionMode)
        {
            return _rtcEngineNative.SetEncryptionMode(encryptionMode);
        }

        public int SetEncryptionSecret(string secret)
        {
            return _rtcEngineNative.SetEncryptionSecret(secret);
        }

        public int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            return _rtcEngineNative.EnableEncryption(enabled, config);
        }

        public int CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            return _rtcEngineNative.CreateDataStream(ref streamId, reliable, ordered);
        }

        public int CreateDataStream(ref int streamId, DataStreamConfig config)
        {
            return _rtcEngineNative.CreateDataStream(ref streamId, config);
        }

        public int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            return _rtcEngineNative.SendStreamMessage(streamId, data, length);
        }

        public int AddVideoWatermark(RtcImage watermark)
        {
            return _rtcEngineNative.AddVideoWatermark(watermark);
        }

        public int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            return _rtcEngineNative.AddVideoWatermark(watermarkUrl, options);
        }

        public int ClearVideoWatermark()
        {
            return _rtcEngineNative.ClearVideoWatermark();
        }

        public int ClearVideoWatermarks()
        {
            return _rtcEngineNative.ClearVideoWatermarks();
        }

        public int AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            return _rtcEngineNative.AddInjectStreamUrl(url, config);
        }

        public int RemoveInjectStreamUrl(string url)
        {
            return _rtcEngineNative.RemoveInjectStreamUrl(url);
        }

        public int PauseAudio()
        {
            return _rtcEngineNative.PauseAudio();
        }

        public int ResumeAudio()
        {
            return _rtcEngineNative.ResumeAudio();
        }

        public int EnableWebSdkInteroperability(bool enabled)
        {
            return _rtcEngineNative.EnableWebSdkInteroperability(enabled);
        }

        public int SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            return _rtcEngineNative.SendCustomReportMessage(id, category, @event, label, value);
        }

        public void RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineNative.RegisterMediaMetadataObserver(observer, type, mode);
        }

        public void UnregisterMediaMetadataObserver()
        {
            _rtcEngineNative.UnregisterMediaMetadataObserver();
        }

        public int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            return _rtcEngineNative.StartAudioFrameDump(channel_id, user_id, location, uuid, passwd, duration_ms, auto_upload);
        }

        public int StopAudioFrameDump(string channel_id, uint user_id, string location)
        {
            return _rtcEngineNative.StopAudioFrameDump(channel_id, user_id, location);
        }

        public int RegisterLocalUserAccount(string appId, string userAccount)
        {
            return _rtcEngineNative.RegisterLocalUserAccount(appId, userAccount);
        }

        public int JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            return _rtcEngineNative.JoinChannelWithUserAccount(token, channelId, userAccount);
        }

        public int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            return _rtcEngineNative.JoinChannelWithUserAccount(token, channelId, userAccount, options);
        }

        public int JoinChannelWithUserAccountEx(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            return _rtcEngineNative.JoinChannelWithUserAccountEx(token, channelId, userAccount, options);
        }

        public int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo)
        {
            return _rtcEngineNative.GetUserInfoByUserAccount(userAccount, out userInfo);
        }

        public int GetUserInfoByUid(uint uid, out UserInfo userInfo)
        {
            return _rtcEngineNative.GetUserInfoByUid(uid, out userInfo);
        }

        public int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return _rtcEngineNative.StartChannelMediaRelay(configuration);
        }

        public int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return _rtcEngineNative.UpdateChannelMediaRelay(configuration);
        }

        public int StopChannelMediaRelay()
        {
            return _rtcEngineNative.StopChannelMediaRelay();
        }

        public int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            return _rtcEngineNative.SetDirectCdnStreamingAudioConfiguration(profile);
        }

        public int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            return _rtcEngineNative.SetDirectCdnStreamingVideoConfiguration(config);
        }

        public int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            return _rtcEngineNative.StartDirectCdnStreaming(publishUrl, options);
        }

        public int StopDirectCdnStreaming()
        {
            return _rtcEngineNative.StopDirectCdnStreaming();
        }

        public int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        {
            return _rtcEngineNative.UpdateDirectCdnStreamingMediaOptions(options);
        }

        public int PushDirectCdnStreamingCustomVideoFrame(ExternalVideoFrame frame)
        {
            return _rtcEngineNative.PushDirectCdnStreamingCustomVideoFrame(frame);
        }

        public int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)
        {
            return _rtcEngineNative.JoinChannelEx(token, connection, options);
        }

        public int LeaveChannelEx(RtcConnection connection)
        {
            return _rtcEngineNative.LeaveChannelEx(connection);
        }

        public int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            return _rtcEngineNative.UpdateChannelMediaOptionsEx(options, connection);
        }

        public int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            return _rtcEngineNative.SetVideoEncoderConfigurationEx(config, connection);
        }

        public int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            return _rtcEngineNative.SetupRemoteVideoEx(canvas, connection);
        }

        public int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            return _rtcEngineNative.MuteRemoteAudioStreamEx(uid, mute, connection);
        }

        public int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            return _rtcEngineNative.MuteRemoteVideoStreamEx(uid, mute, connection);
        }

        public int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)
        {
            return _rtcEngineNative.SetRemoteVoicePositionEx(uid, pan, gain, connection);
        }

        public int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection)
        {
            return _rtcEngineNative.SetRemoteUserSpatialAudioParamsEx(uid, param, connection);
        }

        public int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)
        {
            return _rtcEngineNative.SetRemoteRenderModeEx(uid, renderMode, mirrorMode, connection);
        }

        public int EnableLoopbackRecordingEx(bool enabled, RtcConnection connection)
        {
            return _rtcEngineNative.EnableLoopbackRecordingEx(enabled, connection);
        }

        public CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            return _rtcEngineNative.GetConnectionStateEx(connection);
        }

        public int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            return _rtcEngineNative.EnableEncryptionEx(connection, enabled, config);
        }

        public int CreateDataStreamEx(bool reliable, bool ordered, RtcConnection connection)
        {
            return _rtcEngineNative.CreateDataStreamEx(reliable, ordered, connection);
        }

        public int CreateDataStreamEx(DataStreamConfig config, RtcConnection connection)
        {
            return _rtcEngineNative.CreateDataStreamEx(config, connection);
        }

        public int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            return _rtcEngineNative.SendStreamMessageEx(streamId, data, length, connection);
        }

        public int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            return _rtcEngineNative.AddVideoWatermarkEx(watermarkUrl, options, connection);
        }

        public int ClearVideoWatermarkEx(RtcConnection connection)
        {
            return _rtcEngineNative.ClearVideoWatermarkEx(connection);
        }

        public int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection)
        {
            return _rtcEngineNative.SendCustomReportMessageEx(id, category, @event, label, value, connection);
        }

        public int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap = false, int sourceId = 0)
        {
            return _rtcEngineNative.PushAudioFrame(type, frame, wrap, sourceId);
        }

        public int PullAudioFrame(AudioFrame frame)
        {
            return _rtcEngineNative.PullAudioFrame(frame);
        }

        public int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineNative.SetExternalVideoSource(enabled, useTexture, sourceType);
        }

        public int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true)
        {
            return _rtcEngineNative.SetExternalAudioSource(enabled, sampleRate, channels, sourceNumber, localPlayback, publish);
        }

        public int PushVideoFrame(ExternalVideoFrame frame)
        {
            return _rtcEngineNative.PushVideoFrame(frame);
        }

        public int PushVideoFrame(ExternalVideoFrame frame, RtcConnection connection)
        {
            return _rtcEngineNative.PushVideoFrame(frame, connection);
        }

        public int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return _rtcEngineNative.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo);
        }

        public int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo, RtcConnection connection)
        {
            return _rtcEngineNative.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo, connection);
        }

        //public int GetCertificateVerifyResult(string credential_buf, int credential_len, string certificate_buf, int certificate_len)
        //{
        //    return _rtcEngineNative.Initialize(context);
        //}

        public int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            return _rtcEngineNative.SetAudioSessionOperationRestriction(restriction);
        }

        public int AdjustCustomAudioPublishVolume(int sourceId, int volume)
        {
            return _rtcEngineNative.AdjustCustomAudioPublishVolume(sourceId, volume);
        }

        public int AdjustCustomAudioPlayoutVolume(int sourceId, int volume)
        {
            return _rtcEngineNative.AdjustCustomAudioPlayoutVolume(sourceId, volume);
        }

        public int SetParameters(string parameters)
        {
            return _rtcEngineNative.SetParameters(parameters);
        }

        public int GetAudioDeviceInfo(out DeviceInfo deviceInfo)
        {
            return _rtcEngineNative.GetAudioDeviceInfo(out deviceInfo);
        }

        public int EnableCustomAudioLocalPlayback(int sourceId, bool enabled)
        {
            return _rtcEngineNative.EnableCustomAudioLocalPlayback(sourceId, enabled);
        }

        public int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource)
        {
            return _rtcEngineNative.EnableVirtualBackground(enabled, backgroundSource);
        }

        public int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return _rtcEngineNative.SetLocalPublishFallbackOption(option);
        }

        public int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return _rtcEngineNative.SetRemoteSubscribeFallbackOption(option);
        }

        public int PauseAllChannelMediaRelay()
        {
            return _rtcEngineNative.PauseAllChannelMediaRelay();
        }

        public int ResumeAllChannelMediaRelay()
        {
            return _rtcEngineNative.ResumeAllChannelMediaRelay();
        }

        public int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay)
        {
            return _rtcEngineNative.EnableEchoCancellationExternal(enabled, audioSourceDelay);
        }

        public int TakeSnapshot(SnapShotConfig config)
        {
            return _rtcEngineNative.TakeSnapshot(config);
        }

        //public int EnableContentInspect(bool enabled, ContentInspectConfig config)
        //{
        //    return _rtcEngineNative.Initialize(context);
        //}

        public int SwitchChannel(string token, string channel)
        {
            return _rtcEngineNative.SwitchChannel(token, channel);
        }

        public int SwitchChannel(string token, string channel, ChannelMediaOptions options)
        {
            return _rtcEngineNative.SwitchChannel(token, channel, options);
        }

        public int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            return _rtcEngineNative.StartRhythmPlayer(sound1, sound2, config);
        }

        public int StopRhythmPlayer()
        {
            return _rtcEngineNative.StopRhythmPlayer();
        }

        public int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            return _rtcEngineNative.ConfigRhythmPlayer(config);
        }

        //public int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        //{
        //    return _rtcEngineNative.Initialize(context);
        //}

        //public int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        //{
        //    return _rtcEngineNative.Initialize(context);
        //}

        public int SetDirectExternalAudioSource(bool enable, bool localPlayback)
        {
            return _rtcEngineNative.SetDirectExternalAudioSource(enable, localPlayback);
        }

        public int PushDirectAudioFrame(AudioFrame frame)
        {
            return _rtcEngineNative.PushDirectAudioFrame(frame);
        }

        public int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            return _rtcEngineNative.SetCloudProxy(proxyType);
        }

        public int SetLocalAccessPoint(LocalAccessPointConfiguration config)
        {
            return _rtcEngineNative.SetLocalAccessPoint(config);
        }

        public int EnableFishCorrection(bool enabled, FishCorrectionParams @params)
        {
            return _rtcEngineNative.EnableFishCorrection(enabled , @params);
        }

        public int SetAdvancedAudioOptions(AdvancedAudioOptions options)
        {
            return _rtcEngineNative.SetAdvancedAudioOptions(options);
        }

        public int SetAVSyncSource(string channelId, uint uid)
        {
            return _rtcEngineNative.SetAVSyncSource(channelId, uid);
        }

        public int StartRtmpStreamWithoutTranscoding(string url)
        {
            return _rtcEngineNative.StartRtmpStreamWithoutTranscoding(url);
        }

        public int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            return _rtcEngineNative.StartRtmpStreamWithTranscoding(url, transcoding);
        }

        public int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            return _rtcEngineNative.UpdateRtmpTranscoding(transcoding);
        }

        public int StopRtmpStream(string url)
        {
            return _rtcEngineNative.StopRtmpStream(url);
        }

        public int GetUserInfoByUserAccountEx(string userAccount, out UserInfo userInfo, RtcConnection connection)
        {
            return _rtcEngineNative.GetUserInfoByUserAccountEx(userAccount, out userInfo, connection);
        }

        public int GetUserInfoByUidEx(uint uid, out UserInfo userInfo, RtcConnection connection)
        {
            return _rtcEngineNative.GetUserInfoByUidEx(uid, out userInfo, connection);
        }

        public int EnableRemoteSuperResolution(uint userId, bool enable)
        {
            return _rtcEngineNative.EnableRemoteSuperResolution(userId, enable);
        }

        public int SetContentInspect(ContentInspectConfig config)
        {
            return _rtcEngineNative.SetContentInspect(config);
        }

        public int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)
        {
            return _rtcEngineNative.SetRemoteVideoStreamTypeEx(uid, streamType, connection);
        }

        public int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)
        {
            return _rtcEngineNative.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connection);
        }

        public int SetVideoProfileEx(int width, int height, int frameRate, int bitrate)
        {
            return _rtcEngineNative.SetVideoProfileEx(width, height, frameRate, bitrate);
        }

        public int EnableDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            return _rtcEngineNative.EnableDualStreamModeEx(sourceType, enabled, streamConfig, connection);
        }

        public int AddPublishStreamUrlEx(string url, bool transcodingEnabled, RtcConnection connection)
        {
            return _rtcEngineNative.AddPublishStreamUrlEx(url, transcodingEnabled, connection);
        }

        public int UploadLogFile(ref string requestId)
        {
            return _rtcEngineNative.UploadLogFile(ref requestId);
        }

        public ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            return _rtcEngineNative.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
        }
    };
}