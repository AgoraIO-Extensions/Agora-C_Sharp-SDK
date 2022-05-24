using System;

namespace agora.rtc
{
    public sealed class RtcEngine : IRtcEngine
    {
        private static IRtcEngine instance = null;
        private RtcEngineImpl _rtcEngineImpl = null;
        private IMediaPlayer _mediaPlayerInstance = null;
        private IAudioDeviceManager _audioDeviceManager = null;
        private IVideoDeviceManager _videoDeviceManager = null;
        private ICloudSpatialAudioEngine _cloudSpatialAudioEngine = null;
        private ILocalSpatialAudioEngine _localSpatialAudioEngine = null;

        private RtcEngine()
        {
            _rtcEngineImpl = RtcEngineImpl.GetInstance();
            _mediaPlayerInstance = MediaPlayer.GetInstance(_rtcEngineImpl.GetMediaPlayer());
            _audioDeviceManager = AudioDeviceManager.GetInstance(_rtcEngineImpl.GetAudioDeviceManager());
            _videoDeviceManager = VideoDeviceManager.GetInstance(_rtcEngineImpl.GetVideoDeviceManager());
            _cloudSpatialAudioEngine = CloudSpatialAudioEngine.GetInstance(_rtcEngineImpl.GetCloudSpatialAudioEngine());
            _localSpatialAudioEngine = LocalSpatialAudioEngine.GetInstance(_rtcEngineImpl.GetLocalSpatialAudioEngine());
        }

        public static IRtcEngine CreateAgoraRtcEngine()
        {
            return instance ?? (instance = new RtcEngine());
        }

        public static IRtcEngine Get()
        {
            return instance;
        }

        public override int Initialize(RtcEngineContext context)
        {
            return _rtcEngineImpl.Initialize(context);
        }

        public override void Dispose(bool sync = false)
        {
            _rtcEngineImpl.Dispose(sync);
            _rtcEngineImpl = null;
        }

        public override RtcEngineEventHandler GetRtcEngineEventHandler()
        {
            return _rtcEngineImpl.GetRtcEngineEventHandler();
        }

        public override void InitEventHandler(IRtcEngineEventHandler engineEventHandler)
        {
            _rtcEngineImpl.InitEventHandler(engineEventHandler);
        }

        public override void RemoveEventHandler()
        {
            _rtcEngineImpl.RemoveEventHandler();
        }

        public override void RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
             _rtcEngineImpl.RegisterAudioFrameObserver(audioFrameObserver, mode);
        }

        public override void UnRegisterAudioFrameObserver()
        {
            _rtcEngineImpl.UnRegisterAudioFrameObserver();
        }

        public override void RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineImpl.RegisterVideoFrameObserver(videoFrameObserver, mode);
        }

        public override void UnRegisterVideoFrameObserver()
        {
            _rtcEngineImpl.UnRegisterVideoFrameObserver();
        }

        public override void RegisterVideoEncodedImageReceiver(IVideoEncodedImageReceiver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineImpl.RegisterVideoEncodedImageReceiver(videoEncodedImageReceiver, mode);
        }

        public override void UnRegisterVideoEncodedImageReceiver()
        {
            _rtcEngineImpl.UnRegisterVideoEncodedImageReceiver();
        }

        public override IAudioDeviceManager GetAudioDeviceManager()
        {
            return _audioDeviceManager;
        }

        public override IVideoDeviceManager GetVideoDeviceManager()
        {
            return _videoDeviceManager;
        }

        public override IMediaPlayer GetMediaPlayer()
        {
            return _mediaPlayerInstance;
        }

        public override ICloudSpatialAudioEngine GetCloudSpatialAudioEngine()
        {
            return _cloudSpatialAudioEngine;
        }

        public override ILocalSpatialAudioEngine GetLocalSpatialAudioEngine()
        {
            return _localSpatialAudioEngine;
        }

        public override string GetVersion()
        {
            return _rtcEngineImpl.GetVersion();
        }

        public override string GetErrorDescription(int code)
        {
            return _rtcEngineImpl.GetErrorDescription(code);
        }

        public override int JoinChannel(string token, string channelId, string info = "", uint uid = 0)
        {
            return _rtcEngineImpl.JoinChannel(token, channelId, info, uid);
        }

        public override int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.JoinChannel(token, channelId, uid, options);
        }

        public override int UpdateChannelMediaOptions(ChannelMediaOptions options)
        {
            return _rtcEngineImpl.UpdateChannelMediaOptions(options);
        }

        public override int LeaveChannel()
        {
            return _rtcEngineImpl.LeaveChannel();
        }

        public override int LeaveChannel(LeaveChannelOptions options)
        {
            return _rtcEngineImpl.LeaveChannel(options);
        }

        public override int RenewToken(string token)
        {
            return _rtcEngineImpl.RenewToken(token);
        }

        public override int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            return _rtcEngineImpl.SetChannelProfile(profile);
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            return _rtcEngineImpl.SetClientRole(role);
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role, ref ClientRoleOptions options)
        {
            return _rtcEngineImpl.SetClientRole(role, ref options);
        }

        public override int StartEchoTest()
        {
            return _rtcEngineImpl.StartEchoTest();
        }

        public override int StartEchoTest(int intervalInSeconds)
        {
            return _rtcEngineImpl.StartEchoTest(intervalInSeconds);
        }

        public override int StopEchoTest()
        {
            return _rtcEngineImpl.StopEchoTest();
        }

        public override int EnableVideo()
        {
            return _rtcEngineImpl.EnableVideo();
        }

        public override int DisableVideo()
        {
            return _rtcEngineImpl.DisableVideo();
        }

        public override int StartPreview()
        {
            return _rtcEngineImpl.StartPreview();
        }

        public override int StartPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineImpl.StartPreview();
        }

        public override int StopPreview()
        {
            return _rtcEngineImpl.StopPreview();
        }

        public override int StopPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineImpl.StopPreview(sourceType);
        }

        public override int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            return _rtcEngineImpl.StartLastmileProbeTest(config);
        }

        public override int StopLastmileProbeTest()
        {
            return _rtcEngineImpl.StopLastmileProbeTest();
        }

        public override int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            return _rtcEngineImpl.SetVideoEncoderConfiguration(config);
        }

        public override int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            return _rtcEngineImpl.SetBeautyEffectOptions(enabled, options, type);
        }

        public override int SetupRemoteVideo(VideoCanvas canvas)
        {
            return _rtcEngineImpl.SetupRemoteVideo(canvas);
        }

        public override int SetupLocalVideo(VideoCanvas canvas)
        {
            return _rtcEngineImpl.SetupLocalVideo(canvas);
        }

        public override int EnableAudio()
        {
            return _rtcEngineImpl.EnableAudio();
        }

        public override int DisableAudio()
        {
            return _rtcEngineImpl.DisableAudio();
        }

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            return _rtcEngineImpl.SetAudioProfile(profile, scenario);
        }

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            return _rtcEngineImpl.SetAudioProfile(profile);
        }

        public override int EnableLocalAudio(bool enabled)
        {
            return _rtcEngineImpl.EnableLocalAudio(enabled);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            return _rtcEngineImpl.MuteLocalAudioStream(mute);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            return _rtcEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public override int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            return _rtcEngineImpl.SetDefaultMuteAllRemoteAudioStreams(mute);
        }

        public override int MuteRemoteAudioStream(uint uid, bool mute)
        {
            return _rtcEngineImpl.MuteRemoteAudioStream(uid, mute);
        }

        public override int MuteLocalVideoStream(bool mute)
        {
            return _rtcEngineImpl.MuteLocalVideoStream(mute);
        }

        public override int EnableLocalVideo(bool enabled)
        {
            return _rtcEngineImpl.EnableLocalVideo(enabled);
        }

        public override int MuteAllRemoteVideoStreams(bool mute)
        {
            return _rtcEngineImpl.MuteAllRemoteVideoStreams(mute);
        }

        public override int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            return _rtcEngineImpl.SetDefaultMuteAllRemoteVideoStreams(mute);
        }

        public override int MuteRemoteVideoStream(uint uid, bool mute)
        {
            return _rtcEngineImpl.MuteRemoteVideoStream(uid, mute);
        }

        public override int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            return _rtcEngineImpl.SetRemoteVideoStreamType(uid, streamType);
        }

        public override int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            return _rtcEngineImpl.SetRemoteDefaultVideoStreamType(streamType);
        }

        public override int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            return _rtcEngineImpl.EnableAudioVolumeIndication(interval, smooth, reportVad);
        }

        public override int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return _rtcEngineImpl.StartAudioRecording(filePath, quality);
        }

        public override int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return _rtcEngineImpl.StartAudioRecording(filePath, sampleRate, quality);
        }

        public override int StartAudioRecording(AudioRecordingConfiguration config)
        {
            return _rtcEngineImpl.StartAudioRecording(config);
        }

        public override void RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)
        {
            _rtcEngineImpl.RegisterAudioEncodedFrameObserver(config, observer);
        }

        public override void UnRegisterAudioEncodedFrameObserver()
        {
            _rtcEngineImpl.UnRegisterAudioEncodedFrameObserver();
        }

        public override int StopAudioRecording()
        {
            return _rtcEngineImpl.StopAudioRecording();
        }

        public override int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle)
        {
            return _rtcEngineImpl.StartAudioMixing(filePath, loopback, replace, cycle);
        }

        public override int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int startPos)
        {
            return _rtcEngineImpl.StartAudioMixing(filePath, loopback, replace, cycle, startPos);
        }

        public override int StopAudioMixing()
        {
            return _rtcEngineImpl.StopAudioMixing();
        }

        public override int PauseAudioMixing()
        {
            return _rtcEngineImpl.PauseAudioMixing();
        }

        public override int ResumeAudioMixing()
        {
            return _rtcEngineImpl.ResumeAudioMixing();
        }

        public override int AdjustAudioMixingVolume(int volume)
        {
            return _rtcEngineImpl.AdjustAudioMixingVolume(volume);
        }

        public override int AdjustAudioMixingPublishVolume(int volume)
        {
            return _rtcEngineImpl.AdjustAudioMixingPublishVolume(volume);
        }

        public override int GetAudioMixingPublishVolume()
        {
            return _rtcEngineImpl.GetAudioMixingPublishVolume();
        }

        public override int AdjustAudioMixingPlayoutVolume(int volume)
        {
            return _rtcEngineImpl.AdjustAudioMixingPlayoutVolume(volume);
        }

        public override int GetAudioMixingPlayoutVolume()
        {
            return _rtcEngineImpl.GetAudioMixingPlayoutVolume();
        }

        public override int GetAudioMixingDuration()
        {
            return _rtcEngineImpl.GetAudioMixingDuration();
        }

        public override int GetAudioMixingCurrentPosition()
        {
            return _rtcEngineImpl.GetAudioMixingCurrentPosition();
        }

        public override int SetAudioMixingPosition(int pos)
        {
            return _rtcEngineImpl.SetAudioMixingPosition(pos);
        }

        public override int SetAudioMixingPitch(int pitch)
        {
            return _rtcEngineImpl.SetAudioMixingPitch(pitch);
        }

        public override int GetEffectsVolume()
        {
            return _rtcEngineImpl.GetEffectsVolume();
        }

        public override int SetEffectsVolume(int volume)
        {
            return _rtcEngineImpl.SetEffectsVolume(volume);
        }

        public override int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            return _rtcEngineImpl.PreloadEffect(soundId, filePath, startPos);
        }

        public override int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)
        {
            return _rtcEngineImpl.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);
        }

        public override int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false)
        {
            return _rtcEngineImpl.PlayAllEffects(loopCount, pitch, pan, gain, publish);
        }

        public override int GetVolumeOfEffect(int soundId)
        {
            return _rtcEngineImpl.GetVolumeOfEffect(soundId);
        }

        public override int SetVolumeOfEffect(int soundId, int volume)
        {
            return _rtcEngineImpl.SetVolumeOfEffect(soundId, volume);
        }

        public override int PauseEffect(int soundId)
        {
            return _rtcEngineImpl.PauseEffect(soundId);
        }

        public override int PauseAllEffects()
        {
            return _rtcEngineImpl.PauseAllEffects();
        }

        public override int ResumeEffect(int soundId)
        {
            return _rtcEngineImpl.ResumeEffect(soundId);
        }

        public override int ResumeAllEffects()
        {
            return _rtcEngineImpl.ResumeAllEffects();
        }

        public override int StopEffect(int soundId)
        {
            return _rtcEngineImpl.StopEffect(soundId);
        }

        public override int StopAllEffects()
        {
            return _rtcEngineImpl.StopAllEffects();
        }

        public override int UnloadEffect(int soundId)
        {
            return _rtcEngineImpl.UnloadEffect(soundId);
        }

        public override int UnloadAllEffects()
        {
            return _rtcEngineImpl.UnloadAllEffects();
        }

        public override int EnableSoundPositionIndication(bool enabled)
        {
            return _rtcEngineImpl.EnableSoundPositionIndication(enabled);
        }

        public override int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            return _rtcEngineImpl.SetRemoteVoicePosition(uid, pan, gain);
        }

        public override int EnableSpatialAudio(bool enabled)
        {
            return _rtcEngineImpl.EnableSpatialAudio(enabled);
        }

        public override int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param)
        {
            return _rtcEngineImpl.SetRemoteUserSpatialAudioParams(uid, param);
        }

        public override int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            return _rtcEngineImpl.SetVoiceBeautifierPreset(preset);
        }

        public override int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            return _rtcEngineImpl.SetAudioEffectPreset(preset);
        }

        public override int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            return _rtcEngineImpl.SetVoiceConversionPreset(preset);
        }

        public override int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            return _rtcEngineImpl.SetAudioEffectParameters(preset, param1, param2);
        }

        public override int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2)
        {
            return _rtcEngineImpl.SetVoiceBeautifierParameters(preset, param1, param2);
        }

        public override int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2)
        {
            return _rtcEngineImpl.SetVoiceConversionParameters(preset, param1, param2);
        }

        public override int SetLocalVoicePitch(double pitch)
        {
            return _rtcEngineImpl.SetLocalVoicePitch(pitch);
        }

        public override int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            return _rtcEngineImpl.SetLocalVoiceEqualization(bandFrequency, bandGain);
        }

        public override int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            return _rtcEngineImpl.SetLocalVoiceReverb(reverbKey, value);
        }

        public override int SetLogFile(string filePath)
        {
            return _rtcEngineImpl.SetLogFile(filePath);
        }

        public override int SetLogFilter(uint filter)
        {
            return _rtcEngineImpl.SetLogFilter(filter);
        }

        public override int SetLogLevel(LOG_LEVEL level)
        {
            return _rtcEngineImpl.SetLogLevel(level);
        }

        public override int SetLogFileSize(uint fileSizeInKBytes)
        {
            return _rtcEngineImpl.SetLogFileSize(fileSizeInKBytes);
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineImpl.SetLocalRenderMode(renderMode, mirrorMode);
        }

        public override int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineImpl.SetRemoteRenderMode(uid, renderMode, mirrorMode);
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            return _rtcEngineImpl.SetLocalRenderMode(renderMode);
        }

        public override int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineImpl.SetLocalVideoMirrorMode(mirrorMode);
        }

        public override int EnableDualStreamMode(bool enabled)
        {
            return _rtcEngineImpl.EnableDualStreamMode(enabled);
        }

        public override int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled)
        {
            return _rtcEngineImpl.EnableDualStreamMode(sourceType, enabled);
        }

        public override int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig)
        {
            return _rtcEngineImpl.EnableDualStreamMode(sourceType, enabled, streamConfig);
        }

        public override int SetExternalAudioSink(int sampleRate, int channels)
        {
            return _rtcEngineImpl.SetExternalAudioSink(sampleRate, channels);
        }

        public override int StartPrimaryCustomAudioTrack(AudioTrackConfig config)
        {
            return _rtcEngineImpl.StartPrimaryCustomAudioTrack(config);
        }

        public override int StopPrimaryCustomAudioTrack()
        {
            return _rtcEngineImpl.StopPrimaryCustomAudioTrack();
        }

        public override int StartSecondaryCustomAudioTrack(AudioTrackConfig config)
        {
            return _rtcEngineImpl.StartSecondaryCustomAudioTrack(config);
        }

        public override int StopSecondaryCustomAudioTrack()
        {
            return _rtcEngineImpl.StopSecondaryCustomAudioTrack();
        }

        public override int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return _rtcEngineImpl.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
        }

        public override int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return _rtcEngineImpl.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
        }

        public override int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            return _rtcEngineImpl.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
        }

        public override int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            return _rtcEngineImpl.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
        }

        public override int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            return _rtcEngineImpl.EnableAudioSpectrumMonitor(intervalInMS);
        }

        public override int DisableAudioSpectrumMonitor()
        {
            return _rtcEngineImpl.DisableAudioSpectrumMonitor();
        }

        public override void RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            _rtcEngineImpl.RegisterAudioSpectrumObserver(observer);
        }

        public override void UnregisterAudioSpectrumObserver()
        {
            _rtcEngineImpl.UnregisterAudioSpectrumObserver();
        }

        public override int AdjustRecordingSignalVolume(int volume)
        {
            return _rtcEngineImpl.AdjustRecordingSignalVolume(volume);
        }

        public override int MuteRecordingSignal(bool mute)
        {
            return _rtcEngineImpl.MuteRecordingSignal(mute);
        }

        public override int AdjustPlaybackSignalVolume(int volume)
        {
            return _rtcEngineImpl.AdjustPlaybackSignalVolume(volume);
        }

        public override int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            return _rtcEngineImpl.AdjustUserPlaybackSignalVolume(uid, volume);
        }

        public override int EnableLoopbackRecording(bool enabled, string deviceName = "")
        {
            return _rtcEngineImpl.EnableLoopbackRecording(enabled, deviceName);
        }

        public override int AdjustLoopbackRecordingVolume(int volume)
        {
            return _rtcEngineImpl.AdjustLoopbackRecordingVolume(volume);
        }

        public override int GetLoopbackRecordingVolume()
        {
            return _rtcEngineImpl.GetLoopbackRecordingVolume();
        }

        public override int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            return _rtcEngineImpl.EnableInEarMonitoring(enabled, includeAudioFilters);
        }

        public override int SetInEarMonitoringVolume(int volume)
        {
            return _rtcEngineImpl.SetInEarMonitoringVolume(volume);
        }

        public override int LoadExtensionProvider(string extension_lib_path)
        {
            return _rtcEngineImpl.LoadExtensionProvider(extension_lib_path);
        }

        public override int SetExtensionProviderProperty(string provider, string key, string value)
        {
            return _rtcEngineImpl.SetExtensionProviderProperty(provider, key, value);
        }

        public override int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            return _rtcEngineImpl.EnableExtension(provider, extension, enable, type);
        }

        public override int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            return _rtcEngineImpl.SetExtensionProperty(provider, extension, key, value, type);
        }

        public override int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            return _rtcEngineImpl.GetExtensionProperty(provider, extension, key, ref value, buf_len, type);
        }

        public override int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            return _rtcEngineImpl.SetCameraCapturerConfiguration(config);
        }

        public override int SwitchCamera()
        {
            return _rtcEngineImpl.SwitchCamera();
        }

        public override bool IsCameraZoomSupported()
        {
            return _rtcEngineImpl.IsCameraZoomSupported();
        }

        public override bool IsCameraFaceDetectSupported()
        {
            return _rtcEngineImpl.IsCameraFaceDetectSupported();
        }

        public override bool IsCameraTorchSupported()
        {
            return _rtcEngineImpl.IsCameraTorchSupported();
        }

        public override bool IsCameraFocusSupported()
        {
            return _rtcEngineImpl.IsCameraFocusSupported();
        }

        public override bool IsCameraAutoFocusFaceModeSupported()
        {
            return _rtcEngineImpl.IsCameraAutoFocusFaceModeSupported();
        }

        public override int SetCameraZoomFactor(float factor)
        {
            return _rtcEngineImpl.SetCameraZoomFactor(factor);
        }

        public override int EnableFaceDetection(bool enabled)
        {
            return _rtcEngineImpl.EnableFaceDetection(enabled);
        }

        public override float GetCameraMaxZoomFactor()
        {
            return _rtcEngineImpl.GetCameraMaxZoomFactor();
        }

        public override int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            return _rtcEngineImpl.SetCameraFocusPositionInPreview(positionX, positionY);
        }

        public override int SetCameraTorchOn(bool isOn)
        {
            return _rtcEngineImpl.SetCameraTorchOn(isOn);
        }

        public override int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            return _rtcEngineImpl.SetCameraAutoFocusFaceModeEnabled(enabled);
        }

        public override bool IsCameraExposurePositionSupported()
        {
            return _rtcEngineImpl.IsCameraExposurePositionSupported();
        }

        public override int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            return _rtcEngineImpl.SetCameraExposurePosition(positionXinView, positionYinView);
        }

        public override bool IsCameraAutoExposureFaceModeSupported()
        {
            return _rtcEngineImpl.IsCameraAutoExposureFaceModeSupported();
        }

        public override int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            return _rtcEngineImpl.SetCameraAutoExposureFaceModeEnabled(enabled);
        }

        public override int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            return _rtcEngineImpl.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
        }

        public override int SetEnableSpeakerphone(bool speakerOn)
        {
            return _rtcEngineImpl.SetEnableSpeakerphone(speakerOn);
        }

        public override bool IsSpeakerphoneEnabled()
        {
            return _rtcEngineImpl.IsSpeakerphoneEnabled();
        }

        public override int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
        }

        public override int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
        }

        public override int StartScreenCapture(byte[] mediaProjectionPermissionResultData, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.StartScreenCapture(mediaProjectionPermissionResultData, captureParams);
        }

        public override int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
        }

        public override int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            return _rtcEngineImpl.SetScreenCaptureContentHint(contentHint);
        }

        public override int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            return _rtcEngineImpl.UpdateScreenCaptureRegion(regionRect);
        }

        public override int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.UpdateScreenCaptureParameters(captureParams);
        }

        public override int StopScreenCapture()
        {
            return _rtcEngineImpl.StopScreenCapture();
        }

        public override string GetCallId()
        {
            return _rtcEngineImpl.GetCallId();
        }

        public override int Rate(string callId, int rating, string description)
        {
            return _rtcEngineImpl.Rate(callId, rating, description);
        }

        public override int Complain(string callId, string description)
        {
            return _rtcEngineImpl.Complain(callId, description);
        }

        public override int AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            return _rtcEngineImpl.AddPublishStreamUrl(url, transcodingEnabled);
        }

        public override int RemovePublishStreamUrl(string url)
        {
            return _rtcEngineImpl.RemovePublishStreamUrl(url);
        }

        public override int SetLiveTranscoding(LiveTranscoding transcoding)
        {
            return _rtcEngineImpl.SetLiveTranscoding(transcoding);
        }

        public override int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            return _rtcEngineImpl.StartLocalVideoTranscoder(config);
        }

        public override int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            return _rtcEngineImpl.UpdateLocalTranscoderConfiguration(config);
        }

        public override int StopLocalVideoTranscoder()
        {
            return _rtcEngineImpl.StopLocalVideoTranscoder();
        }

        public override int StartPrimaryCameraCapture(CameraCapturerConfiguration config)
        {
            return _rtcEngineImpl.StartPrimaryCameraCapture(config);
        }

        public override int StartSecondaryCameraCapture(CameraCapturerConfiguration config)
        {
            return _rtcEngineImpl.StartSecondaryCameraCapture(config);
        }

        public override int StopPrimaryCameraCapture()
        {
            return _rtcEngineImpl.StopPrimaryCameraCapture();
        }

        public override int StopSecondaryCameraCapture()
        {
            return _rtcEngineImpl.StopSecondaryCameraCapture();
        }

        public override int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            return _rtcEngineImpl.SetCameraDeviceOrientation(type, orientation);
        }

        public override int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            return _rtcEngineImpl.SetScreenCaptureOrientation(type, orientation);
        }

        public override int StartPrimaryScreenCapture(ScreenCaptureConfiguration config)
        {
            return _rtcEngineImpl.StartPrimaryScreenCapture(config);
        }

        public override int StartSecondaryScreenCapture(ScreenCaptureConfiguration config)
        {
            return _rtcEngineImpl.StartSecondaryScreenCapture(config);
        }

        public override int StopPrimaryScreenCapture()
        {
            return _rtcEngineImpl.StopPrimaryScreenCapture();
        }

        public override int StopSecondaryScreenCapture()
        {
            return _rtcEngineImpl.StopSecondaryScreenCapture();
        }

        public override CONNECTION_STATE_TYPE GetConnectionState()
        {
            return _rtcEngineImpl.GetConnectionState();
        }

        public override int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            return _rtcEngineImpl.SetRemoteUserPriority(uid, userPriority);
        }

        //public override int RegisterPacketObserver(IPacketObserver observer)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public override int SetEncryptionMode(string encryptionMode)
        {
            return _rtcEngineImpl.SetEncryptionMode(encryptionMode);
        }

        public override int SetEncryptionSecret(string secret)
        {
            return _rtcEngineImpl.SetEncryptionSecret(secret);
        }

        public override int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            return _rtcEngineImpl.EnableEncryption(enabled, config);
        }

        public override int CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            return _rtcEngineImpl.CreateDataStream(ref streamId, reliable, ordered);
        }

        public override int CreateDataStream(ref int streamId, DataStreamConfig config)
        {
            return _rtcEngineImpl.CreateDataStream(ref streamId, config);
        }

        public override int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            return _rtcEngineImpl.SendStreamMessage(streamId, data, length);
        }

        public override int AddVideoWatermark(RtcImage watermark)
        {
            return _rtcEngineImpl.AddVideoWatermark(watermark);
        }

        public override int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            return _rtcEngineImpl.AddVideoWatermark(watermarkUrl, options);
        }

        public override int ClearVideoWatermark()
        {
            return _rtcEngineImpl.ClearVideoWatermark();
        }

        public override int ClearVideoWatermarks()
        {
            return _rtcEngineImpl.ClearVideoWatermarks();
        }

        public override int AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            return _rtcEngineImpl.AddInjectStreamUrl(url, config);
        }

        public override int RemoveInjectStreamUrl(string url)
        {
            return _rtcEngineImpl.RemoveInjectStreamUrl(url);
        }

        public override int PauseAudio()
        {
            return _rtcEngineImpl.PauseAudio();
        }

        public override int ResumeAudio()
        {
            return _rtcEngineImpl.ResumeAudio();
        }

        public override int EnableWebSdkInteroperability(bool enabled)
        {
            return _rtcEngineImpl.EnableWebSdkInteroperability(enabled);
        }

        public override int SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            return _rtcEngineImpl.SendCustomReportMessage(id, category, @event, label, value);
        }

        public override void RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineImpl.RegisterMediaMetadataObserver(observer, type, mode);
        }

        public override void UnregisterMediaMetadataObserver()
        {
            _rtcEngineImpl.UnregisterMediaMetadataObserver();
        }

        public override int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            return _rtcEngineImpl.StartAudioFrameDump(channel_id, user_id, location, uuid, passwd, duration_ms, auto_upload);
        }

        public override int StopAudioFrameDump(string channel_id, uint user_id, string location)
        {
            return _rtcEngineImpl.StopAudioFrameDump(channel_id, user_id, location);
        }

        public override int RegisterLocalUserAccount(string appId, string userAccount)
        {
            return _rtcEngineImpl.RegisterLocalUserAccount(appId, userAccount);
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            return _rtcEngineImpl.JoinChannelWithUserAccount(token, channelId, userAccount);
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.JoinChannelWithUserAccount(token, channelId, userAccount, options);
        }

        public override int JoinChannelWithUserAccountEx(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.JoinChannelWithUserAccountEx(token, channelId, userAccount, options);
        }

        public override int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo)
        {
            return _rtcEngineImpl.GetUserInfoByUserAccount(userAccount, out userInfo);
        }

        public override int GetUserInfoByUid(uint uid, out UserInfo userInfo)
        {
            return _rtcEngineImpl.GetUserInfoByUid(uid, out userInfo);
        }

        public override int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return _rtcEngineImpl.StartChannelMediaRelay(configuration);
        }

        public override int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return _rtcEngineImpl.UpdateChannelMediaRelay(configuration);
        }

        public override int StopChannelMediaRelay()
        {
            return _rtcEngineImpl.StopChannelMediaRelay();
        }

        public override int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            return _rtcEngineImpl.SetDirectCdnStreamingAudioConfiguration(profile);
        }

        public override int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            return _rtcEngineImpl.SetDirectCdnStreamingVideoConfiguration(config);
        }

        public override int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            return _rtcEngineImpl.StartDirectCdnStreaming(publishUrl, options);
        }

        public override int StopDirectCdnStreaming()
        {
            return _rtcEngineImpl.StopDirectCdnStreaming();
        }

        public override int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        {
            return _rtcEngineImpl.UpdateDirectCdnStreamingMediaOptions(options);
        }

        public override int PushDirectCdnStreamingCustomVideoFrame(ExternalVideoFrame frame)
        {
            return _rtcEngineImpl.PushDirectCdnStreamingCustomVideoFrame(frame);
        }

        public override int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.JoinChannelEx(token, connection, options);
        }

        public override int LeaveChannelEx(RtcConnection connection)
        {
            return _rtcEngineImpl.LeaveChannelEx(connection);
        }

        public override int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            return _rtcEngineImpl.UpdateChannelMediaOptionsEx(options, connection);
        }

        public override int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            return _rtcEngineImpl.SetVideoEncoderConfigurationEx(config, connection);
        }

        public override int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            return _rtcEngineImpl.SetupRemoteVideoEx(canvas, connection);
        }

        public override int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            return _rtcEngineImpl.MuteRemoteAudioStreamEx(uid, mute, connection);
        }

        public override int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            return _rtcEngineImpl.MuteRemoteVideoStreamEx(uid, mute, connection);
        }

        public override int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)
        {
            return _rtcEngineImpl.SetRemoteVoicePositionEx(uid, pan, gain, connection);
        }

        public override int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection)
        {
            return _rtcEngineImpl.SetRemoteUserSpatialAudioParamsEx(uid, param, connection);
        }

        public override int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)
        {
            return _rtcEngineImpl.SetRemoteRenderModeEx(uid, renderMode, mirrorMode, connection);
        }

        public override int EnableLoopbackRecordingEx(bool enabled, RtcConnection connection)
        {
            return _rtcEngineImpl.EnableLoopbackRecordingEx(enabled, connection);
        }

        public override CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            return _rtcEngineImpl.GetConnectionStateEx(connection);
        }

        public override int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            return _rtcEngineImpl.EnableEncryptionEx(connection, enabled, config);
        }

        public override int CreateDataStreamEx(bool reliable, bool ordered, RtcConnection connection)
        {
            return _rtcEngineImpl.CreateDataStreamEx(reliable, ordered, connection);
        }

        public override int CreateDataStreamEx(DataStreamConfig config, RtcConnection connection)
        {
            return _rtcEngineImpl.CreateDataStreamEx(config, connection);
        }

        public override int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            return _rtcEngineImpl.SendStreamMessageEx(streamId, data, length, connection);
        }

        public override int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            return _rtcEngineImpl.AddVideoWatermarkEx(watermarkUrl, options, connection);
        }

        public override int ClearVideoWatermarkEx(RtcConnection connection)
        {
            return _rtcEngineImpl.ClearVideoWatermarkEx(connection);
        }

        public override int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection)
        {
            return _rtcEngineImpl.SendCustomReportMessageEx(id, category, @event, label, value, connection);
        }

        public override int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap = false, int sourceId = 0)
        {
            return _rtcEngineImpl.PushAudioFrame(type, frame, wrap, sourceId);
        }

        public override int PullAudioFrame(AudioFrame frame)
        {
            return _rtcEngineImpl.PullAudioFrame(frame);
        }

        public override int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineImpl.SetExternalVideoSource(enabled, useTexture, sourceType);
        }

        public override int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true)
        {
            return _rtcEngineImpl.SetExternalAudioSource(enabled, sampleRate, channels, sourceNumber, localPlayback, publish);
        }

        public override int PushVideoFrame(ExternalVideoFrame frame)
        {
            return _rtcEngineImpl.PushVideoFrame(frame);
        }

        public override int PushVideoFrame(ExternalVideoFrame frame, RtcConnection connection)
        {
            return _rtcEngineImpl.PushVideoFrame(frame, connection);
        }

        public override int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return _rtcEngineImpl.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo);
        }

        public override int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo, RtcConnection connection)
        {
            return _rtcEngineImpl.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo, connection);
        }

        //public override int GetCertificateVerifyResult(string credential_buf, int credential_len, string certificate_buf, int certificate_len)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public override int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            return _rtcEngineImpl.SetAudioSessionOperationRestriction(restriction);
        }

        public override int AdjustCustomAudioPublishVolume(int sourceId, int volume)
        {
            return _rtcEngineImpl.AdjustCustomAudioPublishVolume(sourceId, volume);
        }

        public override int AdjustCustomAudioPlayoutVolume(int sourceId, int volume)
        {
            return _rtcEngineImpl.AdjustCustomAudioPlayoutVolume(sourceId, volume);
        }

        public override int SetParameters(string parameters)
        {
            return _rtcEngineImpl.SetParameters(parameters);
        }

        public override int GetAudioDeviceInfo(out DeviceInfo deviceInfo)
        {
            return _rtcEngineImpl.GetAudioDeviceInfo(out deviceInfo);
        }

        public override int EnableCustomAudioLocalPlayback(int sourceId, bool enabled)
        {
            return _rtcEngineImpl.EnableCustomAudioLocalPlayback(sourceId, enabled);
        }

        public override int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource)
        {
            return _rtcEngineImpl.EnableVirtualBackground(enabled, backgroundSource);
        }

        public override int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return _rtcEngineImpl.SetLocalPublishFallbackOption(option);
        }

        public override int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return _rtcEngineImpl.SetRemoteSubscribeFallbackOption(option);
        }

        public override int PauseAllChannelMediaRelay()
        {
            return _rtcEngineImpl.PauseAllChannelMediaRelay();
        }

        public override int ResumeAllChannelMediaRelay()
        {
            return _rtcEngineImpl.ResumeAllChannelMediaRelay();
        }

        public override int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay)
        {
            return _rtcEngineImpl.EnableEchoCancellationExternal(enabled, audioSourceDelay);
        }

        public override int TakeSnapshot(SnapShotConfig config)
        {
            return _rtcEngineImpl.TakeSnapshot(config);
        }

        //public override int EnableContentInspect(bool enabled, ContentInspectConfig config)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public override int SwitchChannel(string token, string channel)
        {
            return _rtcEngineImpl.SwitchChannel(token, channel);
        }

        public override int SwitchChannel(string token, string channel, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.SwitchChannel(token, channel, options);
        }

        public override int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            return _rtcEngineImpl.StartRhythmPlayer(sound1, sound2, config);
        }

        public override int StopRhythmPlayer()
        {
            return _rtcEngineImpl.StopRhythmPlayer();
        }

        public override int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            return _rtcEngineImpl.ConfigRhythmPlayer(config);
        }

        //public override int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        //public override int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public override int SetDirectExternalAudioSource(bool enable, bool localPlayback)
        {
            return _rtcEngineImpl.SetDirectExternalAudioSource(enable, localPlayback);
        }

        public override int PushDirectAudioFrame(AudioFrame frame)
        {
            return _rtcEngineImpl.PushDirectAudioFrame(frame);
        }

        public override int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            return _rtcEngineImpl.SetCloudProxy(proxyType);
        }

        public override int SetLocalAccessPoint(LocalAccessPointConfiguration config)
        {
            return _rtcEngineImpl.SetLocalAccessPoint(config);
        }

        public override int EnableFishCorrection(bool enabled, FishCorrectionParams @params)
        {
            return _rtcEngineImpl.EnableFishCorrection(enabled , @params);
        }

        public override int SetAdvancedAudioOptions(AdvancedAudioOptions options)
        {
            return _rtcEngineImpl.SetAdvancedAudioOptions(options);
        }

        public override int SetAVSyncSource(string channelId, uint uid)
        {
            return _rtcEngineImpl.SetAVSyncSource(channelId, uid);
        }

        public override int StartRtmpStreamWithoutTranscoding(string url)
        {
            return _rtcEngineImpl.StartRtmpStreamWithoutTranscoding(url);
        }

        public override int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            return _rtcEngineImpl.StartRtmpStreamWithTranscoding(url, transcoding);
        }

        public override int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            return _rtcEngineImpl.UpdateRtmpTranscoding(transcoding);
        }

        public override int StopRtmpStream(string url)
        {
            return _rtcEngineImpl.StopRtmpStream(url);
        }

        public override int GetUserInfoByUserAccountEx(string userAccount, out UserInfo userInfo, RtcConnection connection)
        {
            return _rtcEngineImpl.GetUserInfoByUserAccountEx(userAccount, out userInfo, connection);
        }

        public override int GetUserInfoByUidEx(uint uid, out UserInfo userInfo, RtcConnection connection)
        {
            return _rtcEngineImpl.GetUserInfoByUidEx(uid, out userInfo, connection);
        }

        public override int EnableRemoteSuperResolution(uint userId, bool enable)
        {
            return _rtcEngineImpl.EnableRemoteSuperResolution(userId, enable);
        }

        public override int SetContentInspect(ContentInspectConfig config)
        {
            return _rtcEngineImpl.SetContentInspect(config);
        }

        public override int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)
        {
            return _rtcEngineImpl.SetRemoteVideoStreamTypeEx(uid, streamType, connection);
        }

        public override int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)
        {
            return _rtcEngineImpl.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connection);
        }

        public override int SetVideoProfileEx(int width, int height, int frameRate, int bitrate)
        {
            return _rtcEngineImpl.SetVideoProfileEx(width, height, frameRate, bitrate);
        }

        public override int EnableDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            return _rtcEngineImpl.EnableDualStreamModeEx(sourceType, enabled, streamConfig, connection);
        }

        public override int AddPublishStreamUrlEx(string url, bool transcodingEnabled, RtcConnection connection)
        {
            return _rtcEngineImpl.AddPublishStreamUrlEx(url, transcodingEnabled, connection);
        }

        public override int UploadLogFile(ref string requestId)
        {
            return _rtcEngineImpl.UploadLogFile(ref requestId);
        }

        public override ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            return _rtcEngineImpl.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
        }
    };
}