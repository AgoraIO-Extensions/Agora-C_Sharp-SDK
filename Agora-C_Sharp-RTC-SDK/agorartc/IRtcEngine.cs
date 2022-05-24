using System;

namespace agora.rtc
{
    public class IRtcEngine
    {
        private static IRtcEngine instance = null;
        private RtcEngineImpl _rtcEngineImpl = null;
        private IMediaPlayer _mediaPlayerInstance = null;
        private IAudioDeviceManager _audioDeviceManager = null;
        private IVideoDeviceManager _videoDeviceManager = null;
        private ICloudSpatialAudioEngine _cloudSpatialAudioEngine = null;
        private ILocalSpatialAudioEngine _localSpatialAudioEngine = null;

        private IRtcEngine()
        {
            _rtcEngineImpl = RtcEngineImpl.GetInstance();
            _mediaPlayerInstance = IMediaPlayer.GetInstance(_rtcEngineImpl.GetMediaPlayer());
            _audioDeviceManager = IAudioDeviceManager.GetInstance(_rtcEngineImpl.GetAudioDeviceManager());
            _videoDeviceManager = IVideoDeviceManager.GetInstance(_rtcEngineImpl.GetVideoDeviceManager());
            _cloudSpatialAudioEngine = ICloudSpatialAudioEngine.GetInstance(_rtcEngineImpl.GetCloudSpatialAudioEngine());
            _localSpatialAudioEngine = ILocalSpatialAudioEngine.GetInstance(_rtcEngineImpl.GetLocalSpatialAudioEngine());
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
            return _rtcEngineImpl.Initialize(context);
        }

        public void Dispose(bool sync = false)
        {
            _rtcEngineImpl.Dispose(sync);
            _rtcEngineImpl = null;
        }

        public RtcEngineEventHandler GetRtcEngineEventHandler()
        {
            return _rtcEngineImpl.GetRtcEngineEventHandler();
        }

        public void InitEventHandler(IRtcEngineEventHandler engineEventHandler)
        {
            _rtcEngineImpl.InitEventHandler(engineEventHandler);
        }

        public void RemoveEventHandler()
        {
            _rtcEngineImpl.RemoveEventHandler();
        }

        public void RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
             _rtcEngineImpl.RegisterAudioFrameObserver(audioFrameObserver, mode);
        }

        public void UnRegisterAudioFrameObserver()
        {
            _rtcEngineImpl.UnRegisterAudioFrameObserver();
        }

        public void RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineImpl.RegisterVideoFrameObserver(videoFrameObserver, mode);
        }

        public void UnRegisterVideoFrameObserver()
        {
            _rtcEngineImpl.UnRegisterVideoFrameObserver();
        }

        public void RegisterVideoEncodedImageReceiver(IVideoEncodedImageReceiver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineImpl.RegisterVideoEncodedImageReceiver(videoEncodedImageReceiver, mode);
        }

        public void UnRegisterVideoEncodedImageReceiver()
        {
            _rtcEngineImpl.UnRegisterVideoEncodedImageReceiver();
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
            return _rtcEngineImpl.GetVersion();
        }

        public string GetErrorDescription(int code)
        {
            return _rtcEngineImpl.GetErrorDescription(code);
        }

        public int JoinChannel(string token, string channelId, string info = "", uint uid = 0)
        {
            return _rtcEngineImpl.JoinChannel(token, channelId, info, uid);
        }

        public int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.JoinChannel(token, channelId, uid, options);
        }

        public int UpdateChannelMediaOptions(ChannelMediaOptions options)
        {
            return _rtcEngineImpl.UpdateChannelMediaOptions(options);
        }

        public int LeaveChannel()
        {
            return _rtcEngineImpl.LeaveChannel();
        }

        public int LeaveChannel(LeaveChannelOptions options)
        {
            return _rtcEngineImpl.LeaveChannel(options);
        }

        public int RenewToken(string token)
        {
            return _rtcEngineImpl.RenewToken(token);
        }

        public int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            return _rtcEngineImpl.SetChannelProfile(profile);
        }

        public int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            return _rtcEngineImpl.SetClientRole(role);
        }

        public int SetClientRole(CLIENT_ROLE_TYPE role, ref ClientRoleOptions options)
        {
            return _rtcEngineImpl.SetClientRole(role, ref options);
        }

        public int StartEchoTest()
        {
            return _rtcEngineImpl.StartEchoTest();
        }

        public int StartEchoTest(int intervalInSeconds)
        {
            return _rtcEngineImpl.StartEchoTest(intervalInSeconds);
        }

        public int StopEchoTest()
        {
            return _rtcEngineImpl.StopEchoTest();
        }

        public int EnableVideo()
        {
            return _rtcEngineImpl.EnableVideo();
        }

        public int DisableVideo()
        {
            return _rtcEngineImpl.DisableVideo();
        }

        public int StartPreview()
        {
            return _rtcEngineImpl.StartPreview();
        }

        public int StartPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineImpl.StartPreview();
        }

        public int StopPreview()
        {
            return _rtcEngineImpl.StopPreview();
        }

        public int StopPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineImpl.StopPreview(sourceType);
        }

        public int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            return _rtcEngineImpl.StartLastmileProbeTest(config);
        }

        public int StopLastmileProbeTest()
        {
            return _rtcEngineImpl.StopLastmileProbeTest();
        }

        public int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            return _rtcEngineImpl.SetVideoEncoderConfiguration(config);
        }

        public int SetBeautyEffectOptions(bool enabled, BeautyOptions options)
        {
            return _rtcEngineImpl.SetBeautyEffectOptions(enabled, options);
        }

        public int SetupRemoteVideo(VideoCanvas canvas)
        {
            return _rtcEngineImpl.SetupRemoteVideo(canvas);
        }

        public int SetupLocalVideo(VideoCanvas canvas)
        {
            return _rtcEngineImpl.SetupLocalVideo(canvas);
        }

        public int EnableAudio()
        {
            return _rtcEngineImpl.EnableAudio();
        }

        public int DisableAudio()
        {
            return _rtcEngineImpl.DisableAudio();
        }

        public int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            return _rtcEngineImpl.SetAudioProfile(profile, scenario);
        }

        public int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            return _rtcEngineImpl.SetAudioProfile(profile);
        }

        public int EnableLocalAudio(bool enabled)
        {
            return _rtcEngineImpl.EnableLocalAudio(enabled);
        }

        public int MuteLocalAudioStream(bool mute)
        {
            return _rtcEngineImpl.MuteLocalAudioStream(mute);
        }

        public int MuteAllRemoteAudioStreams(bool mute)
        {
            return _rtcEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            return _rtcEngineImpl.SetDefaultMuteAllRemoteAudioStreams(mute);
        }

        public int MuteRemoteAudioStream(uint uid, bool mute)
        {
            return _rtcEngineImpl.MuteRemoteAudioStream(uid, mute);
        }

        public int MuteLocalVideoStream(bool mute)
        {
            return _rtcEngineImpl.MuteLocalVideoStream(mute);
        }

        public int EnableLocalVideo(bool enabled)
        {
            return _rtcEngineImpl.EnableLocalVideo(enabled);
        }

        public int MuteAllRemoteVideoStreams(bool mute)
        {
            return _rtcEngineImpl.MuteAllRemoteVideoStreams(mute);
        }

        public int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            return _rtcEngineImpl.SetDefaultMuteAllRemoteVideoStreams(mute);
        }

        public int MuteRemoteVideoStream(uint uid, bool mute)
        {
            return _rtcEngineImpl.MuteRemoteVideoStream(uid, mute);
        }

        public int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            return _rtcEngineImpl.SetRemoteVideoStreamType(uid, streamType);
        }

        public int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            return _rtcEngineImpl.SetRemoteDefaultVideoStreamType(streamType);
        }

        public int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            return _rtcEngineImpl.EnableAudioVolumeIndication(interval, smooth, reportVad);
        }

        public int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return _rtcEngineImpl.StartAudioRecording(filePath, quality);
        }

        public int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return _rtcEngineImpl.StartAudioRecording(filePath, sampleRate, quality);
        }

        public int StartAudioRecording(AudioRecordingConfiguration config)
        {
            return _rtcEngineImpl.StartAudioRecording(config);
        }

        public void RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)
        {
            _rtcEngineImpl.RegisterAudioEncodedFrameObserver(config, observer);
        }

        public void UnRegisterAudioEncodedFrameObserver()
        {
            _rtcEngineImpl.UnRegisterAudioEncodedFrameObserver();
        }

        public int StopAudioRecording()
        {
            return _rtcEngineImpl.StopAudioRecording();
        }

        public int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle)
        {
            return _rtcEngineImpl.StartAudioMixing(filePath, loopback, replace, cycle);
        }

        public int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int startPos)
        {
            return _rtcEngineImpl.StartAudioMixing(filePath, loopback, replace, cycle, startPos);
        }

        public int StopAudioMixing()
        {
            return _rtcEngineImpl.StopAudioMixing();
        }

        public int PauseAudioMixing()
        {
            return _rtcEngineImpl.PauseAudioMixing();
        }

        public int ResumeAudioMixing()
        {
            return _rtcEngineImpl.ResumeAudioMixing();
        }

        public int AdjustAudioMixingVolume(int volume)
        {
            return _rtcEngineImpl.AdjustAudioMixingVolume(volume);
        }

        public int AdjustAudioMixingPublishVolume(int volume)
        {
            return _rtcEngineImpl.AdjustAudioMixingPublishVolume(volume);
        }

        public int GetAudioMixingPublishVolume()
        {
            return _rtcEngineImpl.GetAudioMixingPublishVolume();
        }

        public int AdjustAudioMixingPlayoutVolume(int volume)
        {
            return _rtcEngineImpl.AdjustAudioMixingPlayoutVolume(volume);
        }

        public int GetAudioMixingPlayoutVolume()
        {
            return _rtcEngineImpl.GetAudioMixingPlayoutVolume();
        }

        public int GetAudioMixingDuration()
        {
            return _rtcEngineImpl.GetAudioMixingDuration();
        }

        public int GetAudioMixingCurrentPosition()
        {
            return _rtcEngineImpl.GetAudioMixingCurrentPosition();
        }

        public int SetAudioMixingPosition(int pos)
        {
            return _rtcEngineImpl.SetAudioMixingPosition(pos);
        }

        public int SetAudioMixingPitch(int pitch)
        {
            return _rtcEngineImpl.SetAudioMixingPitch(pitch);
        }

        public int GetEffectsVolume()
        {
            return _rtcEngineImpl.GetEffectsVolume();
        }

        public int SetEffectsVolume(int volume)
        {
            return _rtcEngineImpl.SetEffectsVolume(volume);
        }

        public int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            return _rtcEngineImpl.PreloadEffect(soundId, filePath, startPos);
        }

        public int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)
        {
            return _rtcEngineImpl.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);
        }

        public int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false)
        {
            return _rtcEngineImpl.PlayAllEffects(loopCount, pitch, pan, gain, publish);
        }

        public int GetVolumeOfEffect(int soundId)
        {
            return _rtcEngineImpl.GetVolumeOfEffect(soundId);
        }

        public int SetVolumeOfEffect(int soundId, int volume)
        {
            return _rtcEngineImpl.SetVolumeOfEffect(soundId, volume);
        }

        public int PauseEffect(int soundId)
        {
            return _rtcEngineImpl.PauseEffect(soundId);
        }

        public int PauseAllEffects()
        {
            return _rtcEngineImpl.PauseAllEffects();
        }

        public int ResumeEffect(int soundId)
        {
            return _rtcEngineImpl.ResumeEffect(soundId);
        }

        public int ResumeAllEffects()
        {
            return _rtcEngineImpl.ResumeAllEffects();
        }

        public int StopEffect(int soundId)
        {
            return _rtcEngineImpl.StopEffect(soundId);
        }

        public int StopAllEffects()
        {
            return _rtcEngineImpl.StopAllEffects();
        }

        public int UnloadEffect(int soundId)
        {
            return _rtcEngineImpl.UnloadEffect(soundId);
        }

        public int UnloadAllEffects()
        {
            return _rtcEngineImpl.UnloadAllEffects();
        }

        public int EnableSoundPositionIndication(bool enabled)
        {
            return _rtcEngineImpl.EnableSoundPositionIndication(enabled);
        }

        public int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            return _rtcEngineImpl.SetRemoteVoicePosition(uid, pan, gain);
        }

        public int EnableSpatialAudio(bool enabled)
        {
            return _rtcEngineImpl.EnableSpatialAudio(enabled);
        }

        public int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param)
        {
            return _rtcEngineImpl.SetRemoteUserSpatialAudioParams(uid, param);
        }

        public int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            return _rtcEngineImpl.SetVoiceBeautifierPreset(preset);
        }

        public int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            return _rtcEngineImpl.SetAudioEffectPreset(preset);
        }

        public int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            return _rtcEngineImpl.SetVoiceConversionPreset(preset);
        }

        public int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            return _rtcEngineImpl.SetAudioEffectParameters(preset, param1, param2);
        }

        public int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2)
        {
            return _rtcEngineImpl.SetVoiceBeautifierParameters(preset, param1, param2);
        }

        public int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2)
        {
            return _rtcEngineImpl.SetVoiceConversionParameters(preset, param1, param2);
        }

        public int SetLocalVoicePitch(double pitch)
        {
            return _rtcEngineImpl.SetLocalVoicePitch(pitch);
        }

        public int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            return _rtcEngineImpl.SetLocalVoiceEqualization(bandFrequency, bandGain);
        }

        public int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            return _rtcEngineImpl.SetLocalVoiceReverb(reverbKey, value);
        }

        public int SetLogFile(string filePath)
        {
            return _rtcEngineImpl.SetLogFile(filePath);
        }

        public int SetLogFilter(uint filter)
        {
            return _rtcEngineImpl.SetLogFilter(filter);
        }

        public int SetLogLevel(LOG_LEVEL level)
        {
            return _rtcEngineImpl.SetLogLevel(level);
        }

        public int SetLogFileSize(uint fileSizeInKBytes)
        {
            return _rtcEngineImpl.SetLogFileSize(fileSizeInKBytes);
        }

        public int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineImpl.SetLocalRenderMode(renderMode, mirrorMode);
        }

        public int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineImpl.SetRemoteRenderMode(uid, renderMode, mirrorMode);
        }

        public int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            return _rtcEngineImpl.SetLocalRenderMode(renderMode);
        }

        public int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return _rtcEngineImpl.SetLocalVideoMirrorMode(mirrorMode);
        }

        public int EnableDualStreamMode(bool enabled)
        {
            return _rtcEngineImpl.EnableDualStreamMode(enabled);
        }

        public int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled)
        {
            return _rtcEngineImpl.EnableDualStreamMode(sourceType, enabled);
        }

        public int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig)
        {
            return _rtcEngineImpl.EnableDualStreamMode(sourceType, enabled, streamConfig);
        }

        public int SetExternalAudioSink(int sampleRate, int channels)
        {
            return _rtcEngineImpl.SetExternalAudioSink(sampleRate, channels);
        }

        public int StartPrimaryCustomAudioTrack(AudioTrackConfig config)
        {
            return _rtcEngineImpl.StartPrimaryCustomAudioTrack(config);
        }

        public int StopPrimaryCustomAudioTrack()
        {
            return _rtcEngineImpl.StopPrimaryCustomAudioTrack();
        }

        public int StartSecondaryCustomAudioTrack(AudioTrackConfig config)
        {
            return _rtcEngineImpl.StartSecondaryCustomAudioTrack(config);
        }

        public int StopSecondaryCustomAudioTrack()
        {
            return _rtcEngineImpl.StopSecondaryCustomAudioTrack();
        }

        public int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return _rtcEngineImpl.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
        }

        public int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return _rtcEngineImpl.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
        }

        public int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            return _rtcEngineImpl.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
        }

        public int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            return _rtcEngineImpl.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
        }

        public int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            return _rtcEngineImpl.EnableAudioSpectrumMonitor(intervalInMS);
        }

        public int DisableAudioSpectrumMonitor()
        {
            return _rtcEngineImpl.DisableAudioSpectrumMonitor();
        }

        public void RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            _rtcEngineImpl.RegisterAudioSpectrumObserver(observer);
        }

        public void UnregisterAudioSpectrumObserver()
        {
            _rtcEngineImpl.UnregisterAudioSpectrumObserver();
        }

        public int AdjustRecordingSignalVolume(int volume)
        {
            return _rtcEngineImpl.AdjustRecordingSignalVolume(volume);
        }

        public int MuteRecordingSignal(bool mute)
        {
            return _rtcEngineImpl.MuteRecordingSignal(mute);
        }

        public int AdjustPlaybackSignalVolume(int volume)
        {
            return _rtcEngineImpl.AdjustPlaybackSignalVolume(volume);
        }

        public int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            return _rtcEngineImpl.AdjustUserPlaybackSignalVolume(uid, volume);
        }

        public int EnableLoopbackRecording(bool enabled)
        {
            return _rtcEngineImpl.EnableLoopbackRecording(enabled);
        }

        public int AdjustLoopbackRecordingVolume(int volume)
        {
            return _rtcEngineImpl.AdjustLoopbackRecordingVolume(volume);
        }

        public int GetLoopbackRecordingVolume()
        {
            return _rtcEngineImpl.GetLoopbackRecordingVolume();
        }

        public int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            return _rtcEngineImpl.EnableInEarMonitoring(enabled, includeAudioFilters);
        }

        public int SetInEarMonitoringVolume(int volume)
        {
            return _rtcEngineImpl.SetInEarMonitoringVolume(volume);
        }

        public int LoadExtensionProvider(string extension_lib_path)
        {
            return _rtcEngineImpl.LoadExtensionProvider(extension_lib_path);
        }

        public int SetExtensionProviderProperty(string provider, string key, string value)
        {
            return _rtcEngineImpl.SetExtensionProviderProperty(provider, key, value);
        }

        public int EnableExtension(string provider, string extension, bool enable = true)
        {
            return _rtcEngineImpl.EnableExtension(provider, extension, enable);
        }

        public int SetExtensionProperty(string provider, string extension, string key, string value)
        {
            return _rtcEngineImpl.SetExtensionProperty(provider, extension, key, value);
        }

        public int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            return _rtcEngineImpl.GetExtensionProperty(provider, extension, key, ref value, buf_len, type);
        }

        public int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            return _rtcEngineImpl.SetCameraCapturerConfiguration(config);
        }

        public int SwitchCamera()
        {
            return _rtcEngineImpl.SwitchCamera();
        }

        public bool IsCameraZoomSupported()
        {
            return _rtcEngineImpl.IsCameraZoomSupported();
        }

        public bool IsCameraFaceDetectSupported()
        {
            return _rtcEngineImpl.IsCameraFaceDetectSupported();
        }

        public bool IsCameraTorchSupported()
        {
            return _rtcEngineImpl.IsCameraTorchSupported();
        }

        public bool IsCameraFocusSupported()
        {
            return _rtcEngineImpl.IsCameraFocusSupported();
        }

        public bool IsCameraAutoFocusFaceModeSupported()
        {
            return _rtcEngineImpl.IsCameraAutoFocusFaceModeSupported();
        }

        public int SetCameraZoomFactor(float factor)
        {
            return _rtcEngineImpl.SetCameraZoomFactor(factor);
        }

        public int EnableFaceDetection(bool enabled)
        {
            return _rtcEngineImpl.EnableFaceDetection(enabled);
        }

        public float GetCameraMaxZoomFactor()
        {
            return _rtcEngineImpl.GetCameraMaxZoomFactor();
        }

        public int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            return _rtcEngineImpl.SetCameraFocusPositionInPreview(positionX, positionY);
        }

        public int SetCameraTorchOn(bool isOn)
        {
            return _rtcEngineImpl.SetCameraTorchOn(isOn);
        }

        public int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            return _rtcEngineImpl.SetCameraAutoFocusFaceModeEnabled(enabled);
        }

        public bool IsCameraExposurePositionSupported()
        {
            return _rtcEngineImpl.IsCameraExposurePositionSupported();
        }

        public int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            return _rtcEngineImpl.SetCameraExposurePosition(positionXinView, positionYinView);
        }

        public bool IsCameraAutoExposureFaceModeSupported()
        {
            return _rtcEngineImpl.IsCameraAutoExposureFaceModeSupported();
        }

        public int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            return _rtcEngineImpl.SetCameraAutoExposureFaceModeEnabled(enabled);
        }

        public int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            return _rtcEngineImpl.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
        }

        public int SetEnableSpeakerphone(bool speakerOn)
        {
            return _rtcEngineImpl.SetEnableSpeakerphone(speakerOn);
        }

        public bool IsSpeakerphoneEnabled()
        {
            return _rtcEngineImpl.IsSpeakerphoneEnabled();
        }

        public int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
        }

        public int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
        }

        public int StartScreenCapture(byte[] mediaProjectionPermissionResultData, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.StartScreenCapture(mediaProjectionPermissionResultData, captureParams);
        }

        public int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
        }

        public int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            return _rtcEngineImpl.SetScreenCaptureContentHint(contentHint);
        }

        public int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            return _rtcEngineImpl.UpdateScreenCaptureRegion(regionRect);
        }

        public int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            return _rtcEngineImpl.UpdateScreenCaptureParameters(captureParams);
        }

        public int StopScreenCapture()
        {
            return _rtcEngineImpl.StopScreenCapture();
        }

        public string GetCallId()
        {
            return _rtcEngineImpl.GetCallId();
        }

        public int Rate(string callId, int rating, string description)
        {
            return _rtcEngineImpl.Rate(callId, rating, description);
        }

        public int Complain(string callId, string description)
        {
            return _rtcEngineImpl.Complain(callId, description);
        }

        public int AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            return _rtcEngineImpl.AddPublishStreamUrl(url, transcodingEnabled);
        }

        public int RemovePublishStreamUrl(string url)
        {
            return _rtcEngineImpl.RemovePublishStreamUrl(url);
        }

        public int SetLiveTranscoding(LiveTranscoding transcoding)
        {
            return _rtcEngineImpl.SetLiveTranscoding(transcoding);
        }

        public int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            return _rtcEngineImpl.StartLocalVideoTranscoder(config);
        }

        public int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            return _rtcEngineImpl.UpdateLocalTranscoderConfiguration(config);
        }

        public int StopLocalVideoTranscoder()
        {
            return _rtcEngineImpl.StopLocalVideoTranscoder();
        }

        public int StartPrimaryCameraCapture(CameraCapturerConfiguration config)
        {
            return _rtcEngineImpl.StartPrimaryCameraCapture(config);
        }

        public int StartSecondaryCameraCapture(CameraCapturerConfiguration config)
        {
            return _rtcEngineImpl.StartSecondaryCameraCapture(config);
        }

        public int StopPrimaryCameraCapture()
        {
            return _rtcEngineImpl.StopPrimaryCameraCapture();
        }

        public int StopSecondaryCameraCapture()
        {
            return _rtcEngineImpl.StopSecondaryCameraCapture();
        }

        public int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            return _rtcEngineImpl.SetCameraDeviceOrientation(type, orientation);
        }

        public int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            return _rtcEngineImpl.SetScreenCaptureOrientation(type, orientation);
        }

        public int StartPrimaryScreenCapture(ScreenCaptureConfiguration config)
        {
            return _rtcEngineImpl.StartPrimaryScreenCapture(config);
        }

        public int StartSecondaryScreenCapture(ScreenCaptureConfiguration config)
        {
            return _rtcEngineImpl.StartSecondaryScreenCapture(config);
        }

        public int StopPrimaryScreenCapture()
        {
            return _rtcEngineImpl.StopPrimaryScreenCapture();
        }

        public int StopSecondaryScreenCapture()
        {
            return _rtcEngineImpl.StopSecondaryScreenCapture();
        }

        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            return _rtcEngineImpl.GetConnectionState();
        }

        public int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            return _rtcEngineImpl.SetRemoteUserPriority(uid, userPriority);
        }

        //public int RegisterPacketObserver(IPacketObserver observer)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public int SetEncryptionMode(string encryptionMode)
        {
            return _rtcEngineImpl.SetEncryptionMode(encryptionMode);
        }

        public int SetEncryptionSecret(string secret)
        {
            return _rtcEngineImpl.SetEncryptionSecret(secret);
        }

        public int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            return _rtcEngineImpl.EnableEncryption(enabled, config);
        }

        public int CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            return _rtcEngineImpl.CreateDataStream(ref streamId, reliable, ordered);
        }

        public int CreateDataStream(ref int streamId, DataStreamConfig config)
        {
            return _rtcEngineImpl.CreateDataStream(ref streamId, config);
        }

        public int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            return _rtcEngineImpl.SendStreamMessage(streamId, data, length);
        }

        public int AddVideoWatermark(RtcImage watermark)
        {
            return _rtcEngineImpl.AddVideoWatermark(watermark);
        }

        public int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            return _rtcEngineImpl.AddVideoWatermark(watermarkUrl, options);
        }

        public int ClearVideoWatermark()
        {
            return _rtcEngineImpl.ClearVideoWatermark();
        }

        public int ClearVideoWatermarks()
        {
            return _rtcEngineImpl.ClearVideoWatermarks();
        }

        public int AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            return _rtcEngineImpl.AddInjectStreamUrl(url, config);
        }

        public int RemoveInjectStreamUrl(string url)
        {
            return _rtcEngineImpl.RemoveInjectStreamUrl(url);
        }

        public int PauseAudio()
        {
            return _rtcEngineImpl.PauseAudio();
        }

        public int ResumeAudio()
        {
            return _rtcEngineImpl.ResumeAudio();
        }

        public int EnableWebSdkInteroperability(bool enabled)
        {
            return _rtcEngineImpl.EnableWebSdkInteroperability(enabled);
        }

        public int SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            return _rtcEngineImpl.SendCustomReportMessage(id, category, @event, label, value);
        }

        public void RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            _rtcEngineImpl.RegisterMediaMetadataObserver(observer, type, mode);
        }

        public void UnregisterMediaMetadataObserver()
        {
            _rtcEngineImpl.UnregisterMediaMetadataObserver();
        }

        public int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            return _rtcEngineImpl.StartAudioFrameDump(channel_id, user_id, location, uuid, passwd, duration_ms, auto_upload);
        }

        public int StopAudioFrameDump(string channel_id, uint user_id, string location)
        {
            return _rtcEngineImpl.StopAudioFrameDump(channel_id, user_id, location);
        }

        public int RegisterLocalUserAccount(string appId, string userAccount)
        {
            return _rtcEngineImpl.RegisterLocalUserAccount(appId, userAccount);
        }

        public int JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            return _rtcEngineImpl.JoinChannelWithUserAccount(token, channelId, userAccount);
        }

        public int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.JoinChannelWithUserAccount(token, channelId, userAccount, options);
        }

        public int JoinChannelWithUserAccountEx(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.JoinChannelWithUserAccountEx(token, channelId, userAccount, options);
        }

        public int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo)
        {
            return _rtcEngineImpl.GetUserInfoByUserAccount(userAccount, out userInfo);
        }

        public int GetUserInfoByUid(uint uid, out UserInfo userInfo)
        {
            return _rtcEngineImpl.GetUserInfoByUid(uid, out userInfo);
        }

        public int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return _rtcEngineImpl.StartChannelMediaRelay(configuration);
        }

        public int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return _rtcEngineImpl.UpdateChannelMediaRelay(configuration);
        }

        public int StopChannelMediaRelay()
        {
            return _rtcEngineImpl.StopChannelMediaRelay();
        }

        public int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            return _rtcEngineImpl.SetDirectCdnStreamingAudioConfiguration(profile);
        }

        public int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            return _rtcEngineImpl.SetDirectCdnStreamingVideoConfiguration(config);
        }

        public int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            return _rtcEngineImpl.StartDirectCdnStreaming(publishUrl, options);
        }

        public int StopDirectCdnStreaming()
        {
            return _rtcEngineImpl.StopDirectCdnStreaming();
        }

        public int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        {
            return _rtcEngineImpl.UpdateDirectCdnStreamingMediaOptions(options);
        }

        public int PushDirectCdnStreamingCustomVideoFrame(ExternalVideoFrame frame)
        {
            return _rtcEngineImpl.PushDirectCdnStreamingCustomVideoFrame(frame);
        }

        public int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.JoinChannelEx(token, connection, options);
        }

        public int LeaveChannelEx(RtcConnection connection)
        {
            return _rtcEngineImpl.LeaveChannelEx(connection);
        }

        public int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            return _rtcEngineImpl.UpdateChannelMediaOptionsEx(options, connection);
        }

        public int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            return _rtcEngineImpl.SetVideoEncoderConfigurationEx(config, connection);
        }

        public int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            return _rtcEngineImpl.SetupRemoteVideoEx(canvas, connection);
        }

        public int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            return _rtcEngineImpl.MuteRemoteAudioStreamEx(uid, mute, connection);
        }

        public int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            return _rtcEngineImpl.MuteRemoteVideoStreamEx(uid, mute, connection);
        }

        public int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)
        {
            return _rtcEngineImpl.SetRemoteVoicePositionEx(uid, pan, gain, connection);
        }

        public int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection)
        {
            return _rtcEngineImpl.SetRemoteUserSpatialAudioParamsEx(uid, param, connection);
        }

        public int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)
        {
            return _rtcEngineImpl.SetRemoteRenderModeEx(uid, renderMode, mirrorMode, connection);
        }

        public int EnableLoopbackRecordingEx(bool enabled, RtcConnection connection)
        {
            return _rtcEngineImpl.EnableLoopbackRecordingEx(enabled, connection);
        }

        public CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            return _rtcEngineImpl.GetConnectionStateEx(connection);
        }

        public int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            return _rtcEngineImpl.EnableEncryptionEx(connection, enabled, config);
        }

        public int CreateDataStreamEx(bool reliable, bool ordered, RtcConnection connection)
        {
            return _rtcEngineImpl.CreateDataStreamEx(reliable, ordered, connection);
        }

        public int CreateDataStreamEx(DataStreamConfig config, RtcConnection connection)
        {
            return _rtcEngineImpl.CreateDataStreamEx(config, connection);
        }

        public int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            return _rtcEngineImpl.SendStreamMessageEx(streamId, data, length, connection);
        }

        public int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            return _rtcEngineImpl.AddVideoWatermarkEx(watermarkUrl, options, connection);
        }

        public int ClearVideoWatermarkEx(RtcConnection connection)
        {
            return _rtcEngineImpl.ClearVideoWatermarkEx(connection);
        }

        public int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection)
        {
            return _rtcEngineImpl.SendCustomReportMessageEx(id, category, @event, label, value, connection);
        }

        public int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap = false, int sourceId = 0)
        {
            return _rtcEngineImpl.PushAudioFrame(type, frame, wrap, sourceId);
        }

        public int PullAudioFrame(AudioFrame frame)
        {
            return _rtcEngineImpl.PullAudioFrame(frame);
        }

        public int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType)
        {
            return _rtcEngineImpl.SetExternalVideoSource(enabled, useTexture, sourceType);
        }

        public int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true)
        {
            return _rtcEngineImpl.SetExternalAudioSource(enabled, sampleRate, channels, sourceNumber, localPlayback, publish);
        }

        public int PushVideoFrame(ExternalVideoFrame frame)
        {
            return _rtcEngineImpl.PushVideoFrame(frame);
        }

        public int PushVideoFrame(ExternalVideoFrame frame, RtcConnection connection)
        {
            return _rtcEngineImpl.PushVideoFrame(frame, connection);
        }

        public int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return _rtcEngineImpl.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo);
        }

        public int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo, RtcConnection connection)
        {
            return _rtcEngineImpl.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo, connection);
        }

        //public int GetCertificateVerifyResult(string credential_buf, int credential_len, string certificate_buf, int certificate_len)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            return _rtcEngineImpl.SetAudioSessionOperationRestriction(restriction);
        }

        public int AdjustCustomAudioPublishVolume(int sourceId, int volume)
        {
            return _rtcEngineImpl.AdjustCustomAudioPublishVolume(sourceId, volume);
        }

        public int AdjustCustomAudioPlayoutVolume(int sourceId, int volume)
        {
            return _rtcEngineImpl.AdjustCustomAudioPlayoutVolume(sourceId, volume);
        }

        public int SetParameters(string parameters)
        {
            return _rtcEngineImpl.SetParameters(parameters);
        }

        public int GetAudioDeviceInfo(out DeviceInfo deviceInfo)
        {
            return _rtcEngineImpl.GetAudioDeviceInfo(out deviceInfo);
        }

        public int EnableCustomAudioLocalPlayback(int sourceId, bool enabled)
        {
            return _rtcEngineImpl.EnableCustomAudioLocalPlayback(sourceId, enabled);
        }

        public int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource)
        {
            return _rtcEngineImpl.EnableVirtualBackground(enabled, backgroundSource);
        }

        public int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return _rtcEngineImpl.SetLocalPublishFallbackOption(option);
        }

        public int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return _rtcEngineImpl.SetRemoteSubscribeFallbackOption(option);
        }

        public int PauseAllChannelMediaRelay()
        {
            return _rtcEngineImpl.PauseAllChannelMediaRelay();
        }

        public int ResumeAllChannelMediaRelay()
        {
            return _rtcEngineImpl.ResumeAllChannelMediaRelay();
        }

        public int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay)
        {
            return _rtcEngineImpl.EnableEchoCancellationExternal(enabled, audioSourceDelay);
        }

        public int TakeSnapshot(SnapShotConfig config)
        {
            return _rtcEngineImpl.TakeSnapshot(config);
        }

        //public int EnableContentInspect(bool enabled, ContentInspectConfig config)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public int SwitchChannel(string token, string channel)
        {
            return _rtcEngineImpl.SwitchChannel(token, channel);
        }

        public int SwitchChannel(string token, string channel, ChannelMediaOptions options)
        {
            return _rtcEngineImpl.SwitchChannel(token, channel, options);
        }

        public int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            return _rtcEngineImpl.StartRhythmPlayer(sound1, sound2, config);
        }

        public int StopRhythmPlayer()
        {
            return _rtcEngineImpl.StopRhythmPlayer();
        }

        public int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            return _rtcEngineImpl.ConfigRhythmPlayer(config);
        }

        //public int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        //public int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        //{
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public int SetDirectExternalAudioSource(bool enable, bool localPlayback)
        {
            return _rtcEngineImpl.SetDirectExternalAudioSource(enable, localPlayback);
        }

        public int PushDirectAudioFrame(AudioFrame frame)
        {
            return _rtcEngineImpl.PushDirectAudioFrame(frame);
        }

        public int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            return _rtcEngineImpl.SetCloudProxy(proxyType);
        }

        public int SetLocalAccessPoint(LocalAccessPointConfiguration config)
        {
            return _rtcEngineImpl.SetLocalAccessPoint(config);
        }

        public int EnableFishCorrection(bool enabled, FishCorrectionParams @params)
        {
            return _rtcEngineImpl.EnableFishCorrection(enabled , @params);
        }

        public int SetAdvancedAudioOptions(AdvancedAudioOptions options)
        {
            return _rtcEngineImpl.SetAdvancedAudioOptions(options);
        }

        public int SetAVSyncSource(string channelId, uint uid)
        {
            return _rtcEngineImpl.SetAVSyncSource(channelId, uid);
        }

        public int StartRtmpStreamWithoutTranscoding(string url)
        {
            return _rtcEngineImpl.StartRtmpStreamWithoutTranscoding(url);
        }

        public int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            return _rtcEngineImpl.StartRtmpStreamWithTranscoding(url, transcoding);
        }

        public int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            return _rtcEngineImpl.UpdateRtmpTranscoding(transcoding);
        }

        public int StopRtmpStream(string url)
        {
            return _rtcEngineImpl.StopRtmpStream(url);
        }

        public int GetUserInfoByUserAccountEx(string userAccount, out UserInfo userInfo, RtcConnection connection)
        {
            return _rtcEngineImpl.GetUserInfoByUserAccountEx(userAccount, out userInfo, connection);
        }

        public int GetUserInfoByUidEx(uint uid, out UserInfo userInfo, RtcConnection connection)
        {
            return _rtcEngineImpl.GetUserInfoByUidEx(uid, out userInfo, connection);
        }

        public int EnableRemoteSuperResolution(uint userId, bool enable)
        {
            return _rtcEngineImpl.EnableRemoteSuperResolution(userId, enable);
        }

        public int SetContentInspect(ContentInspectConfig config)
        {
            return _rtcEngineImpl.SetContentInspect(config);
        }

        public int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)
        {
            return _rtcEngineImpl.SetRemoteVideoStreamTypeEx(uid, streamType, connection);
        }

        public int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)
        {
            return _rtcEngineImpl.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connection);
        }

        public int SetVideoProfileEx(int width, int height, int frameRate, int bitrate)
        {
            return _rtcEngineImpl.SetVideoProfileEx(width, height, frameRate, bitrate);
        }

        public int EnableDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            return _rtcEngineImpl.EnableDualStreamModeEx(sourceType, enabled, streamConfig, connection);
        }

        public int AddPublishStreamUrlEx(string url, bool transcodingEnabled, RtcConnection connection)
        {
            return _rtcEngineImpl.AddPublishStreamUrlEx(url, transcodingEnabled, connection);
        }

        public int UploadLogFile(ref string requestId)
        {
            return _rtcEngineImpl.UploadLogFile(ref requestId);
        }

        public ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            return _rtcEngineImpl.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
        }
    };
}