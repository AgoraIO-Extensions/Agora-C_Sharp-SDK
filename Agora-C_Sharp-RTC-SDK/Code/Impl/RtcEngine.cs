using System;
using video_track_id_t = System.UInt32;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using UnityEngine;
#endif

namespace Agora.Rtc
{
    public sealed class RtcEngine : IRtcEngineEx
    {
        private RtcEngineImpl _rtcEngineImpl = null;
        private IAudioDeviceManager _audioDeviceManager = null;
        private IVideoDeviceManager _videoDeviceManager = null;
        //private ICloudSpatialAudioEngine _cloudSpatialAudioEngine = null;
        private ILocalSpatialAudioEngine _localSpatialAudioEngine = null;
        private IMediaPlayerCacheManager _mediaPlayerCacheManager = null;
        private IMediaRecorder _mediaRecorder = null;
        private const int ErrorCode = -7;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private GameObject _agoraEngineObject;
#endif

        private RtcEngine()
        {
            _rtcEngineImpl = RtcEngineImpl.GetInstance();
            _audioDeviceManager = AudioDeviceManager.GetInstance(this, _rtcEngineImpl.GetAudioDeviceManager());
            _videoDeviceManager = VideoDeviceManager.GetInstance(this, _rtcEngineImpl.GetVideoDeviceManager());
            //_cloudSpatialAudioEngine = CloudSpatialAudioEngine.GetInstance(this, _rtcEngineImpl.GetCloudSpatialAudioEngine());
            _localSpatialAudioEngine = LocalSpatialAudioEngine.GetInstance(this, _rtcEngineImpl.GetLocalSpatialAudioEngine());
            _mediaPlayerCacheManager = MediaPlayerCacheManager.GetInstance(this, _rtcEngineImpl.GetMediaPlayerCacheManager());

            _mediaRecorder = MediaRecorder.GetInstance(this, _rtcEngineImpl.GetMediaRecorder());
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            InitAgoraEngineObject();
#endif
        }

        ~RtcEngine()
        {
            _audioDeviceManager = null;
            _videoDeviceManager = null;
            //_cloudSpatialAudioEngine = null;
            _localSpatialAudioEngine = null;
            _mediaPlayerCacheManager = null;
            _mediaRecorder = null;
        }

        private static IRtcEngine instance = null;
        public static IRtcEngine Instance
        {
            get
            {
                return instance ?? (instance = new RtcEngine());
            }
        }

        public static IRtcEngineEx InstanceEx
        {
            get
            {
                return (IRtcEngineEx)(instance ?? (instance = new RtcEngine()));
            }
        }

        public static IRtcEngine CreateAgoraRtcEngine()
        {
            return instance ?? (instance = new RtcEngine());
        }

        public static IRtcEngineEx CreateAgoraRtcEngineEx()
        {
            return (IRtcEngineEx)(instance ?? (instance = new RtcEngine()));
        }

        public static IRtcEngine Get()
        {
            return instance;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private void InitAgoraEngineObject()
        {
            _agoraEngineObject = GameObject.Find("AgoraRtcEngineObj");
            if (_agoraEngineObject == null)
            {
                _agoraEngineObject = new GameObject("AgoraRtcEngineObj");
                UnityEngine.Object.DontDestroyOnLoad(_agoraEngineObject);
                _agoraEngineObject.hideFlags = HideFlags.HideInHierarchy;
                _agoraEngineObject.AddComponent<AgoraGameObject>();
            }
        }
#endif

        public override int Initialize(RtcEngineContext context)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.Initialize(context);
        }

        public override void Dispose(bool sync = false)
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
           
            _rtcEngineImpl.Dispose(sync);
            _rtcEngineImpl = null;

            AudioDeviceManager.ReleaseInstance();
            VideoDeviceManager.ReleaseInstance();
            //CloudSpatialAudioEngine.ReleaseInstance();
            LocalSpatialAudioEngine.ReleaseInstance();
            MediaPlayerCacheManager.ReleaseInstance();
            MediaRecorder.ReleaseInstance();
            instance = null;
        }

        public override void InitEventHandler(IRtcEngineEventHandler engineEventHandler)
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.InitEventHandler(engineEventHandler);
        }

        public override void RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.RegisterAudioFrameObserver(audioFrameObserver, mode);
        }

        public override void UnRegisterAudioFrameObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.UnRegisterAudioFrameObserver();
        }

        public override void RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.RegisterVideoFrameObserver(videoFrameObserver, mode);
        }

        public override void UnRegisterVideoFrameObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.UnRegisterVideoFrameObserver();
        }

        public override void RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.RegisterVideoEncodedFrameObserver(videoEncodedImageReceiver, mode);
        }

        public override void UnRegisterVideoEncodedFrameObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.UnRegisterVideoEncodedFrameObserver();
        }

        public override IAudioDeviceManager GetAudioDeviceManager()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _audioDeviceManager;
        }

        public override IVideoDeviceManager GetVideoDeviceManager()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _videoDeviceManager;
        }

        public override IMediaPlayerCacheManager GetMediaPlayerCacheManager()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _mediaPlayerCacheManager;
        }

        public override IMediaRecorder GetMediaRecorder()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _mediaRecorder;
        }

        public override IMediaPlayer CreateMediaPlayer()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return new MediaPlayer(this, _rtcEngineImpl.GetMediaPlayer());
        }

        public override void DestroyMediaPlayer(IMediaPlayer mediaPlayer)
        {
            if (_rtcEngineImpl == null || mediaPlayer == null)
            {
            }
            mediaPlayer.Dispose();
        }

        //public override ICloudSpatialAudioEngine GetCloudSpatialAudioEngine()
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return null;
        //    }
        //    return _cloudSpatialAudioEngine;
        //}

        public override ILocalSpatialAudioEngine GetLocalSpatialAudioEngine()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _localSpatialAudioEngine;
        }

        public override string GetVersion(ref int build)
        {
            if (_rtcEngineImpl == null)
            {
                build = 0;
                return null;
            }
            return _rtcEngineImpl.GetVersion(ref build);
        }

        public override string GetErrorDescription(int code)
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _rtcEngineImpl.GetErrorDescription(code);
        }

        public override int JoinChannel(string token, string channelId, string info = "", uint uid = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.JoinChannel(token, channelId, info, uid);
        }

        public override int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.JoinChannel(token, channelId, uid, options);
        }

        public override int UpdateChannelMediaOptions(ChannelMediaOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateChannelMediaOptions(options);
        }

        public override int LeaveChannel()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.LeaveChannel();
        }

        public override int LeaveChannel(LeaveChannelOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.LeaveChannel(options);
        }

        public override int RenewToken(string token)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RenewToken(token);
        }

        public override int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetChannelProfile(profile);
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetClientRole(role);
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetClientRole(role, options);
        }

        public override int StartEchoTest()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartEchoTest();
        }

        public override int StartEchoTest(int intervalInSeconds)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartEchoTest(intervalInSeconds);
        }

        public override int StartEchoTest(EchoTestConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartEchoTest(config);
        }

        public override int StopEchoTest()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopEchoTest();
        }

        public override int EnableVideo()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableVideo();
        }

        public override int DisableVideo()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.DisableVideo();
        }

        public override int StartPreview()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartPreview();
        }

        public override int StartPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartPreview();
        }

        public override int StopPreview()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopPreview();
        }

        public override int StopPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopPreview(sourceType);
        }

        public override int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartLastmileProbeTest(config);
        }

        public override int StopLastmileProbeTest()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopLastmileProbeTest();
        }

        public override int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVideoEncoderConfiguration(config);
        }

        public override int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetBeautyEffectOptions(enabled, options, type);
        }

        public override int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);
        }

        public override int SetupRemoteVideo(VideoCanvas canvas)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetupRemoteVideo(canvas);
        }

        public override int SetupLocalVideo(VideoCanvas canvas)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetupLocalVideo(canvas);
        }

        public override int EnableAudio()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableAudio();
        }

        public override int DisableAudio()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.DisableAudio();
        }

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioProfile(profile, scenario);
        }

        public override int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioScenario(scenario);
        }

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioProfile(profile);
        }

        public override int EnableLocalAudio(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableLocalAudio(enabled);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteLocalAudioStream(mute);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public override int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDefaultMuteAllRemoteAudioStreams(mute);
        }

        public override int MuteRemoteAudioStream(uint uid, bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRemoteAudioStream(uid, mute);
        }

        public override int MuteLocalVideoStream(bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteLocalVideoStream(mute);
        }

        public override int EnableLocalVideo(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableLocalVideo(enabled);
        }

        public override int MuteAllRemoteVideoStreams(bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteAllRemoteVideoStreams(mute);
        }

        public override int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDefaultMuteAllRemoteVideoStreams(mute);
        }

        public override int EnableVideoImageSource(bool enable, ImageTrackOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableVideoImageSource(enable, options);
        }

        public override int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetColorEnhanceOptions(enabled, options, type);
        }

        public override int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLowlightEnhanceOptions(enabled, options, type);
        }

        public override int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVideoSubscriptionOptions(uid, options);
        }

        public override int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVideoDenoiserOptions(enabled, options, type);
        }


        public override int MuteRemoteVideoStream(uint uid, bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRemoteVideoStream(uid, mute);
        }

        public override int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVideoStreamType(uid, streamType);
        }

        public override int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteDefaultVideoStreamType(streamType);
        }

        public override int SetDualStreamMode(SIMULCAST_STREAM_MODE mode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDualStreamMode(mode);
        }

        public override int SetDualStreamMode(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDualStreamMode(sourceType, mode);
        }

        public override int SetDualStreamMode(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDualStreamMode(sourceType, mode, streamConfig);
        }

        public override int SetDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDualStreamModeEx(sourceType, mode, streamConfig, connection);
        }

        public override int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.TakeSnapshotEx(connection, uid, filePath);
        }

        public override int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableAudioVolumeIndication(interval, smooth, reportVad);
        }

        public override int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartAudioRecording(filePath, quality);
        }

        public override int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartAudioRecording(filePath, sampleRate, quality);
        }

        public override int StartAudioRecording(AudioRecordingConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartAudioRecording(config);
        }

        public override void RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.RegisterAudioEncodedFrameObserver(config, observer);
        }

        public override void UnRegisterAudioEncodedFrameObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.UnRegisterAudioEncodedFrameObserver();
        }

        public override int StopAudioRecording()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopAudioRecording();
        }

        public override int StartAudioMixing(string filePath, bool loopback, int cycle)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartAudioMixing(filePath, loopback, cycle);
        }

        public override int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartAudioMixing(filePath, loopback, cycle, startPos);
        }

        public override int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioMixingDualMonoMode(mode);
        }


        public override int StopAudioMixing()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopAudioMixing();
        }

        public override int PauseAudioMixing()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PauseAudioMixing();
        }

        public override int ResumeAudioMixing()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ResumeAudioMixing();
        }

        public override int AdjustAudioMixingVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustAudioMixingVolume(volume);
        }

        public override int AdjustAudioMixingPublishVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustAudioMixingPublishVolume(volume);
        }

        public override int GetAudioMixingPublishVolume()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetAudioMixingPublishVolume();
        }

        public override int AdjustAudioMixingPlayoutVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustAudioMixingPlayoutVolume(volume);
        }

        public override int GetAudioMixingPlayoutVolume()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetAudioMixingPlayoutVolume();
        }

        public override int GetAudioMixingDuration()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetAudioMixingDuration();
        }

        public override int GetAudioMixingCurrentPosition()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetAudioMixingCurrentPosition();
        }

        public override int SetAudioMixingPosition(int pos)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioMixingPosition(pos);
        }

        public override int SetAudioMixingPitch(int pitch)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioMixingPitch(pitch);
        }

        public override int GetEffectsVolume()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetEffectsVolume();
        }

        public override int SetEffectsVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetEffectsVolume(volume);
        }

        public override int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PreloadEffect(soundId, filePath, startPos);
        }

        public override int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);
        }

        public override int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PlayAllEffects(loopCount, pitch, pan, gain, publish);
        }

        public override int GetVolumeOfEffect(int soundId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetVolumeOfEffect(soundId);
        }

        public override int SetVolumeOfEffect(int soundId, int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVolumeOfEffect(soundId, volume);
        }

        public override int PauseEffect(int soundId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PauseEffect(soundId);
        }

        public override int PauseAllEffects()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PauseAllEffects();
        }

        public override int ResumeEffect(int soundId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ResumeEffect(soundId);
        }

        public override int ResumeAllEffects()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ResumeAllEffects();
        }

        public override int StopEffect(int soundId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopEffect(soundId);
        }

        public override int StopAllEffects()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopAllEffects();
        }

        public override int UnloadEffect(int soundId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UnloadEffect(soundId);
        }

        public override int UnloadAllEffects()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UnloadAllEffects();
        }

        public override int GetEffectCurrentPosition(int soundId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetEffectCurrentPosition(soundId);
        }

        public override int GetEffectDuration(string filePath)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetEffectDuration(filePath);
        }

        public override int SetEffectPosition(int soundId, int pos)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetEffectPosition(soundId, pos);
        }

        public override int EnableSoundPositionIndication(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableSoundPositionIndication(enabled);
        }

        public override int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVoicePosition(uid, pan, gain);
        }

        public override int EnableSpatialAudio(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableSpatialAudio(enabled);
        }

        public override int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteUserSpatialAudioParams(uid, param);
        }

        public override int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVoiceBeautifierPreset(preset);
        }

        public override int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioEffectPreset(preset);
        }

        public override int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVoiceConversionPreset(preset);
        }

        public override int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioEffectParameters(preset, param1, param2);
        }

        public override int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVoiceBeautifierParameters(preset, param1, param2);
        }

        public override int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVoiceConversionParameters(preset, param1, param2);
        }

        public override int SetLocalVoicePitch(double pitch)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalVoicePitch(pitch);
        }

        public override int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalVoiceEqualization(bandFrequency, bandGain);
        }

        public override int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalVoiceReverb(reverbKey, value);
        }

        public override int SetLogFile(string filePath)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLogFile(filePath);
        }

        public override int SetLogFilter(uint filter)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLogFilter(filter);
        }

        public override int SetLogLevel(LOG_LEVEL level)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLogLevel(level);
        }

        public override int SetLogFileSize(uint fileSizeInKBytes)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLogFileSize(fileSizeInKBytes);
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalRenderMode(renderMode, mirrorMode);
        }

        public override int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteRenderMode(uid, renderMode, mirrorMode);
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalRenderMode(renderMode);
        }

        public override int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalVideoMirrorMode(mirrorMode);
        }

        public override int EnableDualStreamMode(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableDualStreamMode(enabled);
        }

        public override int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableDualStreamMode(sourceType, enabled);
        }

        public override int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableDualStreamMode(sourceType, enabled, streamConfig);
        }

        public override int SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetExternalAudioSink(enabled, sampleRate, channels);
        }

        public override int StartPrimaryCustomAudioTrack(AudioTrackConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartPrimaryCustomAudioTrack(config);
        }

        public override int StopPrimaryCustomAudioTrack()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopPrimaryCustomAudioTrack();
        }

        public override int StartSecondaryCustomAudioTrack(AudioTrackConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartSecondaryCustomAudioTrack(config);
        }

        public override int StopSecondaryCustomAudioTrack()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopSecondaryCustomAudioTrack();
        }

        public override int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
        }

        public override int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
        }

        public override int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
        }

        public override int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
        }

        public override int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableAudioSpectrumMonitor(intervalInMS);
        }

        public override int DisableAudioSpectrumMonitor()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.DisableAudioSpectrumMonitor();
        }

        public override void RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.RegisterAudioSpectrumObserver(observer);
        }

        public override void UnregisterAudioSpectrumObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.UnregisterAudioSpectrumObserver();
        }

        public override int AdjustRecordingSignalVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustRecordingSignalVolume(volume);
        }

        public override int MuteRecordingSignal(bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRecordingSignal(mute);
        }

        public override int AdjustPlaybackSignalVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustPlaybackSignalVolume(volume);
        }

        public override int AdjustLoopbackSignalVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustLoopbackSignalVolume(volume);
        }


        public override int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustUserPlaybackSignalVolume(uid, volume);
        }

        public override int EnableLoopbackRecording(bool enabled, string deviceName = "")
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableLoopbackRecording(enabled, deviceName);
        }

        public override int GetLoopbackRecordingVolume()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetLoopbackRecordingVolume();
        }

        public override int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableInEarMonitoring(enabled, includeAudioFilters);
        }

        public override int SetInEarMonitoringVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetInEarMonitoringVolume(volume);
        }

        public override int LoadExtensionProvider(string path, bool unload_after_use = false)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.LoadExtensionProvider(path, unload_after_use);
        }

        public override int SetExtensionProviderProperty(string provider, string key, string value)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetExtensionProviderProperty(provider, key, value);
        }

        public override int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableExtension(provider, extension, enable, type);
        }

        public override int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetExtensionProperty(provider, extension, key, value, type);
        }

        public override int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetExtensionProperty(provider, extension, key, ref value, buf_len, type);
        }

        public override int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraCapturerConfiguration(config);
        }

        public override int SwitchCamera()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SwitchCamera();
        }

        public override bool IsCameraZoomSupported()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsCameraZoomSupported();
        }

        public override bool IsCameraFaceDetectSupported()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsCameraFaceDetectSupported();
        }

        public override bool IsCameraTorchSupported()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsCameraTorchSupported();
        }

        public override bool IsCameraFocusSupported()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsCameraFocusSupported();
        }

        public override bool IsCameraAutoFocusFaceModeSupported()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsCameraAutoFocusFaceModeSupported();
        }

        public override int SetCameraZoomFactor(float factor)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraZoomFactor(factor);
        }

        public override int EnableFaceDetection(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableFaceDetection(enabled);
        }

        public override float GetCameraMaxZoomFactor()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetCameraMaxZoomFactor();
        }

        public override int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraFocusPositionInPreview(positionX, positionY);
        }

        public override int SetCameraTorchOn(bool isOn)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraTorchOn(isOn);
        }

        public override int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraAutoFocusFaceModeEnabled(enabled);
        }

        public override bool IsCameraExposurePositionSupported()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsCameraExposurePositionSupported();
        }

        public override int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraExposurePosition(positionXinView, positionYinView);
        }

        public override bool IsCameraAutoExposureFaceModeSupported()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsCameraAutoExposureFaceModeSupported();
        }

        public override int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraAutoExposureFaceModeEnabled(enabled);
        }

        public override int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
        }

        public override int SetEnableSpeakerphone(bool speakerOn)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetEnableSpeakerphone(speakerOn);
        }

        public override bool IsSpeakerphoneEnabled()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsSpeakerphoneEnabled();
        }

        public override int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
        }

        public override int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
        }

        public override int StartScreenCapture(byte[] mediaProjectionPermissionResultData, ScreenCaptureParameters captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartScreenCapture(mediaProjectionPermissionResultData, captureParams);
        }

        //only in android 
        public override int StartScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartScreenCapture(captureParams);
        }

        //only in android 
        public override int UpdateScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateScreenCapture(captureParams);
        }


        public override int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
        }

        public override int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetScreenCaptureContentHint(contentHint);
        }

        public override int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateScreenCaptureRegion(regionRect);
        }

        public override int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateScreenCaptureParameters(captureParams);
        }

        public override int StopScreenCapture()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopScreenCapture();
        }

        public override string GetCallId()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _rtcEngineImpl.GetCallId();
        }

        public override int Rate(string callId, int rating, string description)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.Rate(callId, rating, description);
        }

        public override int Complain(string callId, string description)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.Complain(callId, description);
        }

        //public override int AddPublishStreamUrl(string url, bool transcodingEnabled)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.AddPublishStreamUrl(url, transcodingEnabled);
        //}

        //public override int RemovePublishStreamUrl(string url)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.RemovePublishStreamUrl(url);
        //}

        //public override int SetLiveTranscoding(LiveTranscoding transcoding)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.SetLiveTranscoding(transcoding);
        //}

        public override int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartLocalVideoTranscoder(config);
        }

        public override int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateLocalTranscoderConfiguration(config);
        }

        public override int StopLocalVideoTranscoder()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopLocalVideoTranscoder();
        }

        public override int StartPrimaryCameraCapture(CameraCapturerConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartPrimaryCameraCapture(config);
        }

        public override int StartSecondaryCameraCapture(CameraCapturerConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartSecondaryCameraCapture(config);
        }

        public override int StopPrimaryCameraCapture()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopPrimaryCameraCapture();
        }

        public override int StopSecondaryCameraCapture()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopSecondaryCameraCapture();
        }

        public override int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraDeviceOrientation(type, orientation);
        }

        public override int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetScreenCaptureOrientation(type, orientation);
        }

        public override int StartPrimaryScreenCapture(ScreenCaptureConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartPrimaryScreenCapture(config);
        }

        public override int StartSecondaryScreenCapture(ScreenCaptureConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartSecondaryScreenCapture(config);
        }

        public override int StopPrimaryScreenCapture()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopPrimaryScreenCapture();
        }

        public override int StopSecondaryScreenCapture()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopSecondaryScreenCapture();
        }

        public override CONNECTION_STATE_TYPE GetConnectionState()
        {
            if (_rtcEngineImpl == null)
            {
                return CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
            }
            return _rtcEngineImpl.GetConnectionState();
        }

        public override int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteUserPriority(uid, userPriority);
        }

        //public override int RegisterPacketObserver(IPacketObserver observer)
        //{
        // if (_rtcEngineImpl == null)
        // {
        //     AgoraLog.LogError(ErrorMsgLog);
        // }
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public override int SetEncryptionMode(string encryptionMode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetEncryptionMode(encryptionMode);
        }

        public override int SetEncryptionSecret(string secret)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetEncryptionSecret(secret);
        }

        public override int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableEncryption(enabled, config);
        }

        public override int CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.CreateDataStream(ref streamId, reliable, ordered);
        }

        public override int CreateDataStream(ref int streamId, DataStreamConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.CreateDataStream(ref streamId, config);
        }

        public override int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SendStreamMessage(streamId, data, length);
        }

        public override int AddVideoWatermark(RtcImage watermark)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AddVideoWatermark(watermark);
        }

        public override int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AddVideoWatermark(watermarkUrl, options);
        }

        public override int ClearVideoWatermark()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ClearVideoWatermark();
        }

        public override int ClearVideoWatermarks()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ClearVideoWatermarks();
        }

        public override int AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AddInjectStreamUrl(url, config);
        }

        public override int RemoveInjectStreamUrl(string url)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RemoveInjectStreamUrl(url);
        }

        public override int PauseAudio()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PauseAudio();
        }

        public override int ResumeAudio()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ResumeAudio();
        }

        public override int EnableWebSdkInteroperability(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableWebSdkInteroperability(enabled);
        }

        public override int SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SendCustomReportMessage(id, category, @event, label, value);
        }

        public override void RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type)
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.RegisterMediaMetadataObserver(observer, type);
        }

        public override void UnregisterMediaMetadataObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return;
            }
            _rtcEngineImpl.UnregisterMediaMetadataObserver();
        }

        public override int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartAudioFrameDump(channel_id, user_id, location, uuid, passwd, duration_ms, auto_upload);
        }

        public override int StopAudioFrameDump(string channel_id, uint user_id, string location)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopAudioFrameDump(channel_id, user_id, location);
        }

        public override int RegisterLocalUserAccount(string appId, string userAccount)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RegisterLocalUserAccount(appId, userAccount);
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.JoinChannelWithUserAccount(token, channelId, userAccount);
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.JoinChannelWithUserAccount(token, channelId, userAccount, options);
        }

        public override int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetUserInfoByUserAccount(userAccount, ref userInfo);
        }

        public override int GetUserInfoByUid(uint uid, ref UserInfo userInfo)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetUserInfoByUid(uid, ref userInfo);
        }

        public override int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartChannelMediaRelay(configuration);
        }

        public override int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateChannelMediaRelay(configuration);
        }

        public override int StopChannelMediaRelay()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopChannelMediaRelay();
        }

        public override int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDirectCdnStreamingAudioConfiguration(profile);
        }

        public override int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDirectCdnStreamingVideoConfiguration(config);
        }

        public override int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartDirectCdnStreaming(publishUrl, options);
        }

        public override int StopDirectCdnStreaming()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopDirectCdnStreaming();
        }

        public override int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateDirectCdnStreamingMediaOptions(options);
        }

        public override int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.JoinChannelEx(token, connection, options);
        }

        public override int LeaveChannelEx(RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.LeaveChannelEx(connection);
        }

        public override int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateChannelMediaOptionsEx(options, connection);
        }

        public override int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVideoEncoderConfigurationEx(config, connection);
        }

        public override int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetupRemoteVideoEx(canvas, connection);
        }

        public override int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRemoteAudioStreamEx(uid, mute, connection);
        }

        public override int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRemoteVideoStreamEx(uid, mute, connection);
        }

        public override int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVoicePositionEx(uid, pan, gain, connection);
        }

        public override int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteUserSpatialAudioParamsEx(uid, param, connection);
        }

        public override int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteRenderModeEx(uid, renderMode, mirrorMode, connection);
        }

        public override int EnableLoopbackRecordingEx(bool enabled, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableLoopbackRecordingEx(enabled, connection);
        }

        public override CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
            }
            return _rtcEngineImpl.GetConnectionStateEx(connection);
        }

        public override int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableEncryptionEx(connection, enabled, config);
        }

        public override int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.CreateDataStreamEx(ref streamId, reliable, ordered, connection);
        }

        public override int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.CreateDataStreamEx(ref streamId, config, connection);
        }

        public override int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SendStreamMessageEx(streamId, data, length, connection);
        }

        public override int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AddVideoWatermarkEx(watermarkUrl, options, connection);
        }

        public override int ClearVideoWatermarkEx(RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ClearVideoWatermarkEx(connection);
        }

        public override int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SendCustomReportMessageEx(id, category, @event, label, value, connection);
        }

        public override int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap = false, int sourceId = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PushAudioFrame(type, frame, wrap, sourceId);
        }

        public override int PullAudioFrame(AudioFrame frame)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PullAudioFrame(frame);
        }

        public override int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetExternalVideoSource(enabled, useTexture, sourceType, encodedVideoOption);
        }

        public override int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetExternalAudioSource(enabled, sampleRate, channels, sourceNumber, localPlayback, publish);
        }

        public override int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PushVideoFrame(frame, videoTrackId);
        }


        public override int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo, videoTrackId);
        }

        public override video_track_id_t CreateCustomEncodedVideoTrack(SenderOptions sender_option)
        {
            if (_rtcEngineImpl == null)
            {
                return 0;
            }
            return _rtcEngineImpl.CreateCustomEncodedVideoTrack(sender_option);
        }

        public override int DestroyCustomEncodedVideoTrack(video_track_id_t video_track_id)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.DestroyCustomEncodedVideoTrack(video_track_id);
        }

        public override video_track_id_t CreateCustomVideoTrack()
        {
            if (_rtcEngineImpl == null)
            {
                return 0;
            }
            return _rtcEngineImpl.CreateCustomVideoTrack();
        }

        public override int DestroyCustomVideoTrack(video_track_id_t video_track_id)
        {
            if (_rtcEngineImpl == null)
            {
                return 0;
            }
            return _rtcEngineImpl.DestroyCustomVideoTrack(video_track_id);
        }


        //public override int GetCertificateVerifyResult(string credential_buf, int credential_len, string certificate_buf, int certificate_len)
        //{
        // if (_rtcEngineImpl == null)
        // {
        //     AgoraLog.LogError(ErrorMsgLog);
        // }
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public override int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioSessionOperationRestriction(restriction);
        }

        public override int AdjustCustomAudioPublishVolume(int sourceId, int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustCustomAudioPublishVolume(sourceId, volume);
        }

        public override int AdjustCustomAudioPlayoutVolume(int sourceId, int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustCustomAudioPlayoutVolume(sourceId, volume);
        }

        public override int SetParameters(string parameters)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetParameters(parameters);
        }

        public override int GetAudioDeviceInfo(ref DeviceInfo deviceInfo)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetAudioDeviceInfo(ref deviceInfo);
        }

        public override int EnableCustomAudioLocalPlayback(int sourceId, bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableCustomAudioLocalPlayback(sourceId, enabled);
        }

        public override int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalPublishFallbackOption(option);
        }

        public override int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteSubscribeFallbackOption(option);
        }

        public override int PauseAllChannelMediaRelay()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PauseAllChannelMediaRelay();
        }

        public override int ResumeAllChannelMediaRelay()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ResumeAllChannelMediaRelay();
        }

        public override int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableEchoCancellationExternal(enabled, audioSourceDelay);
        }

        public override int TakeSnapshot(uint uid, string filePath)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.TakeSnapshot(uid, filePath);
        }

        public override int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartRhythmPlayer(sound1, sound2, config);
        }

        public override int StopRhythmPlayer()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopRhythmPlayer();
        }

        public override int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ConfigRhythmPlayer(config);
        }

        //public override int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        //{
        // if (_rtcEngineImpl == null)
        // {
        //     AgoraLog.LogError(ErrorMsgLog);
        // }
        //    return _rtcEngineImpl.Initialize(context);
        //}

        //public override int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        //{
        // if (_rtcEngineImpl == null)
        // {
        //     AgoraLog.LogError(ErrorMsgLog);
        // }
        //    return _rtcEngineImpl.Initialize(context);
        //}

        public override int SetDirectExternalAudioSource(bool enable, bool localPlayback)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDirectExternalAudioSource(enable, localPlayback);
        }

        public override int PushDirectAudioFrame(AudioFrame frame)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PushDirectAudioFrame(frame);
        }

        public override int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCloudProxy(proxyType);
        }

        public override int SetLocalAccessPoint(LocalAccessPointConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalAccessPoint(config);
        }

        //public override int EnableFishEyeCorrection(bool enabled, FishEyeCorrectionParams @params)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.EnableFishEyeCorrection(enabled, @params);
        //}

        public override int SetAdvancedAudioOptions(AdvancedAudioOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAdvancedAudioOptions(options);
        }

        public override int SetAVSyncSource(string channelId, uint uid)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAVSyncSource(channelId, uid);
        }

        public override int StartRtmpStreamWithoutTranscoding(string url)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartRtmpStreamWithoutTranscoding(url);
        }

        public override int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartRtmpStreamWithTranscoding(url, transcoding);
        }

        public override int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateRtmpTranscoding(transcoding);
        }

        public override int StopRtmpStream(string url)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopRtmpStream(url);
        }

        public override int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetUserInfoByUserAccountEx(userAccount, ref userInfo, connection);
        }

        public override int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetUserInfoByUidEx(uid, ref userInfo, connection);
        }

        public override int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVideoSubscriptionOptionsEx(uid, options, connection);
        }

        public override int SetSubscribeAudioBlacklistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeAudioBlacklistEx(uidList, uidNumber, connection);
        }

        public override int SetSubscribeAudioWhitelistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeAudioWhitelistEx(uidList, uidNumber, connection);
        }

        public override int SetSubscribeVideoBlacklistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeVideoBlacklistEx(uidList, uidNumber, connection);
        }

        public override int SetSubscribeVideoWhitelistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeVideoWhitelistEx(uidList, uidNumber, connection);
        }

        public override int EnableRemoteSuperResolution(uint userId, bool enable)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableRemoteSuperResolution(userId, enable);
        }

        public override int EnableContentInspect(bool enabled, ContentInspectConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableContentInspect(enabled, config);
        }

        public override int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVideoStreamTypeEx(uid, streamType, connection);
        }

        public override int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connection);
        }

        public override int SetVideoProfileEx(int width, int height, int frameRate, int bitrate)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVideoProfileEx(width, height, frameRate, bitrate);
        }

        public override int EnableDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableDualStreamModeEx(sourceType, enabled, streamConfig, connection);
        }

        //public override int AddPublishStreamUrlEx(string url, bool transcodingEnabled, RtcConnection connection)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.AddPublishStreamUrlEx(url, transcodingEnabled, connection);
        //}

        public override int UploadLogFile(ref string requestId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UploadLogFile(ref requestId);
        }

        public override int SetSubscribeAudioBlacklist(uint[] uidList, int uidNumber)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeAudioBlacklist(uidList, uidNumber);
        }

        public override int SetSubscribeAudioWhitelist(uint[] uidList, int uidNumber)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeAudioWhitelist(uidList, uidNumber);
        }

        public override int SetSubscribeVideoBlacklist(uint[] uidList, int uidNumber)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeVideoBlacklist(uidList, uidNumber);
        }

        public override int SetSubscribeVideoWhitelist(uint[] uidList, int uidNumber)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeVideoWhitelist(uidList, uidNumber);
        }

        public override ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _rtcEngineImpl.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
        }

        public override int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetScreenCaptureScenario(screenScenario);
        }


        public override bool StartDumpVideo(VIDEO_SOURCE_TYPE type, string dir)
        {
            return _rtcEngineImpl.StartDumpVideo(type, dir);
        }

        public override bool StopDumpVideo()
        {
            return _rtcEngineImpl.StopDumpVideo();
        }

        public override int EnableWirelessAccelerate(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableWirelessAccelerate(enabled);
        }

        public override int GetAudioTrackCount()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetAudioTrackCount();
        }

        public override int SelectAudioTrack(int index)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SelectAudioTrack(index);
        }
    }
}