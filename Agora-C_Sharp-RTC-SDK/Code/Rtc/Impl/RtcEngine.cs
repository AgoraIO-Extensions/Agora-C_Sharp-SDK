using System;
using video_track_id_t = System.UInt32;
using track_id_t = System.UInt32;
using System.Collections.Generic;
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
        private IMusicContentCenter _musicContentCenter = null;
        private ILocalSpatialAudioEngine _localSpatialAudioEngine = null;
        private IMediaPlayerCacheManager _mediaPlayerCacheManager = null;
        private IMediaRecorder _mediaRecorder = null;
        private const int ErrorCode = -7;
        private static System.Object rtcLock = new System.Object();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private GameObject _agoraEngineObject;
#endif

        private RtcEngine(IntPtr nativePtr)
        {
            _rtcEngineImpl = RtcEngineImpl.GetInstance(nativePtr);
            _audioDeviceManager = AudioDeviceManager.GetInstance(this, _rtcEngineImpl.GetAudioDeviceManager());
            _videoDeviceManager = VideoDeviceManager.GetInstance(this, _rtcEngineImpl.GetVideoDeviceManager());
            _musicContentCenter = MusicContentCenter.GetInstance(this, _rtcEngineImpl.GetMusicContentCenter());
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
            _musicContentCenter = null;
            _localSpatialAudioEngine = null;
            _mediaPlayerCacheManager = null;
            _mediaRecorder = null;
        }

        private static IRtcEngine instance = null;
        public static IRtcEngine Instance
        {
            get
            {
                lock (rtcLock)
                {
                    return instance ?? (instance = new RtcEngine(IntPtr.Zero));
                }
            }
        }

        public static IRtcEngineEx InstanceEx
        {
            get
            {
                lock (rtcLock)
                {
                    return (IRtcEngineEx)(instance ?? (instance = new RtcEngine(IntPtr.Zero)));
                }
            }
        }

        public static IRtcEngine CreateAgoraRtcEngine()
        {
            lock (rtcLock)
            {
                return instance ?? (instance = new RtcEngine(IntPtr.Zero));
            }
        }
        public static IRtcEngine CreateAgoraRtcEngine(IntPtr nativePtr)
        {
            lock (rtcLock)
            {
                return instance ?? (instance = new RtcEngine(nativePtr));
            }
        }

        public static IRtcEngineEx CreateAgoraRtcEngineEx()
        {
            lock (rtcLock)
            {
                return (IRtcEngineEx)(instance ?? (instance = new RtcEngine(IntPtr.Zero)));
            }
        }
        public static IRtcEngineEx CreateAgoraRtcEngineEx(IntPtr nativePtr)
        {
            lock (rtcLock)
            {
                return (IRtcEngineEx)(instance ?? (instance = new RtcEngine(nativePtr)));
            }
        }

        public static IRtcEngine Get()
        {
            lock (rtcLock)
            {
                return instance;
            }
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
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.Initialize(context);
            }
        }

        public override void Dispose(bool sync = false)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return;
                }

                _rtcEngineImpl.Dispose(sync);
                _rtcEngineImpl = null;

                AudioDeviceManager.ReleaseInstance();
                VideoDeviceManager.ReleaseInstance();
                MusicContentCenter.ReleaseInstance();
                LocalSpatialAudioEngine.ReleaseInstance();
                MediaPlayerCacheManager.ReleaseInstance();
                MediaRecorder.ReleaseInstance();
                instance = null;
            }
        }

        public override int InitEventHandler(IRtcEngineEventHandler engineEventHandler, bool needExtensionContext = false)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.InitEventHandler(engineEventHandler, needExtensionContext);
            }
        }

        public override int PreDispose()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PreDispose();
            }
        }

        public override int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RegisterAudioFrameObserver(audioFrameObserver, mode);
            }
        }

        public override int UnRegisterAudioFrameObserver()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UnRegisterAudioFrameObserver();
            }
        }

        public override int RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RegisterVideoFrameObserver(videoFrameObserver, mode);
            }
        }

        public override int UnRegisterVideoFrameObserver()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UnRegisterVideoFrameObserver();
            }
        }

        public override int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RegisterVideoEncodedFrameObserver(videoEncodedImageReceiver, mode);
            }
        }

        public override int UnRegisterVideoEncodedFrameObserver()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UnRegisterVideoEncodedFrameObserver();
            }
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

        public override IMusicContentCenter GetMusicContentCenter()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _musicContentCenter;
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
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return null;
                }
                return new MediaPlayer(this, _rtcEngineImpl.GetMediaPlayer());
            }
        }

        public override int DestroyMediaPlayer(IMediaPlayer mediaPlayer)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null || mediaPlayer == null)
                {
                    return ErrorCode;
                }
                MediaPlayer player = (MediaPlayer)mediaPlayer;
                return player.Destroy();
            }
        }

        //public override ICloudSpatialAudioEngine GetCloudSpatialAudioEngine()
        //{
        //lock (rtcLock)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return null;
        //    }
        //    return _cloudSpatialAudioEngine;
        //}
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
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    build = 0;
                    return null;
                }
                return _rtcEngineImpl.GetVersion(ref build);
            }
        }

        public override string GetErrorDescription(int code)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return null;
                }
                return _rtcEngineImpl.GetErrorDescription(code);
            }
        }

        public override int QueryCodecCapability(ref CodecCapInfo[] codec_info, ref int size)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.QueryCodecCapability(ref codec_info, ref size);
            }
        }

        public override int QueryDeviceScore()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.QueryDeviceScore();
            }
        }

        public override int JoinChannel(string token, string channelId, string info = "", uint uid = 0)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.JoinChannel(token, channelId, info, uid);
            }
        }

        public override int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.JoinChannel(token, channelId, uid, options);
            }
        }

        public override int UpdateChannelMediaOptions(ChannelMediaOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateChannelMediaOptions(options);
            }
        }

        public override int LeaveChannel()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.LeaveChannel();
            }
        }

        public override int LeaveChannel(LeaveChannelOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.LeaveChannel(options);
            }
        }

        public override int RenewToken(string token)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RenewToken(token);
            }
        }

        public override int SetChannelProfile(CHANNEL_PROFILE_TYPE profile)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetChannelProfile(profile);
            }
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetClientRole(role);
            }
        }

        public override int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetClientRole(role, options);
            }
        }

        public override int StartEchoTest()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartEchoTest();
            }
        }

        public override int StartEchoTest(int intervalInSeconds)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartEchoTest(intervalInSeconds);
            }
        }

        public override int StartEchoTest(EchoTestConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartEchoTest(config);
            }
        }

        public override int StopEchoTest()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopEchoTest();
            }
        }

        public override int EnableVideo()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableVideo();
            }
        }

        public override int DisableVideo()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.DisableVideo();
            }
        }

        public override int StartPreview()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartPreview();
            }
        }

        public override int StartPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartPreview(sourceType);
            }
        }

        public override int StopPreview()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopPreview();
            }
        }

        public override int StopPreview(VIDEO_SOURCE_TYPE sourceType)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopPreview(sourceType);
            }
        }

        public override int StartLastmileProbeTest(LastmileProbeConfig config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartLastmileProbeTest(config);
            }
        }

        public override int StopLastmileProbeTest()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopLastmileProbeTest();
            }
        }

        public override int GetNetworkType()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetNetworkType();
            }
        }

        public override int SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVideoEncoderConfiguration(config);
            }
        }

        public override int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetBeautyEffectOptions(enabled, options, type);
            }
        }

        public override int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);
            }
        }

        public override int SetupRemoteVideo(VideoCanvas canvas)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetupRemoteVideo(canvas);
            }
        }

        public override int SetupLocalVideo(VideoCanvas canvas)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetupLocalVideo(canvas);
            }
        }

        public override int EnableAudio()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableAudio();
            }
        }

        public override int DisableAudio()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.DisableAudio();
            }
        }

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioProfile(profile, scenario);
            }
        }

        public override int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioScenario(scenario);
            }
        }

        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioProfile(profile);
            }
        }

        public override int EnableLocalAudio(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableLocalAudio(enabled);
            }
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteLocalAudioStream(mute);
            }
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteAllRemoteAudioStreams(mute);
            }
        }

        public override int SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetDefaultMuteAllRemoteAudioStreams(mute);
            }
        }

        public override int MuteRemoteAudioStream(uint uid, bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteRemoteAudioStream(uid, mute);
            }
        }

        public override int MuteLocalVideoStream(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteLocalVideoStream(mute);
            }
        }

        public override int EnableLocalVideo(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableLocalVideo(enabled);
            }
        }

        public override int MuteAllRemoteVideoStreams(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteAllRemoteVideoStreams(mute);
            }
        }

        public override int SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetDefaultMuteAllRemoteVideoStreams(mute);
            }
        }

        public override int EnableVideoImageSource(bool enable, ImageTrackOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableVideoImageSource(enable, options);
            }
        }

        public override int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetColorEnhanceOptions(enabled, options, type);
            }
        }

        public override int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLowlightEnhanceOptions(enabled, options, type);
            }
        }

        public override int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteVideoSubscriptionOptions(uid, options);
            }
        }

        public override int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVideoDenoiserOptions(enabled, options, type);
            }
        }


        public override int MuteRemoteVideoStream(uint uid, bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteRemoteVideoStream(uid, mute);
            }
        }

        public override int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteVideoStreamType(uid, streamType);
            }
        }

        public override int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteDefaultVideoStreamType(streamType);
            }
        }

        public override int SetDualStreamMode(SIMULCAST_STREAM_MODE mode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetDualStreamMode(mode);
            }
        }

        public override int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetDualStreamMode(mode, streamConfig);
            }
        }

        public override int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetDualStreamModeEx(mode, streamConfig, connection);
            }
        }

        public override int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.TakeSnapshotEx(connection, uid, filePath);
            }
        }

        public override int EnableContentInspectEx(bool enabled, ContentInspectConfig config, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableContentInspectEx(enabled, config, connection);
            }
        }

        public override int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableAudioVolumeIndication(interval, smooth, reportVad);
            }
        }

        public override int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartAudioRecording(filePath, quality);
            }
        }

        public override int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartAudioRecording(filePath, sampleRate, quality);
            }
        }

        public override int StartAudioRecording(AudioRecordingConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartAudioRecording(config);
            }
        }

        public override int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RegisterAudioEncodedFrameObserver(config, observer);
            }
        }

        public override int UnRegisterAudioEncodedFrameObserver()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UnRegisterAudioEncodedFrameObserver();
            }
        }

        public override int StopAudioRecording()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopAudioRecording();
            }
        }

        public override int StartAudioMixing(string filePath, bool loopback, int cycle)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartAudioMixing(filePath, loopback, cycle);
            }
        }

        public override int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartAudioMixing(filePath, loopback, cycle, startPos);
            }
        }

        public override int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioMixingDualMonoMode(mode);
            }
        }


        public override int StopAudioMixing()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopAudioMixing();
            }
        }

        public override int PauseAudioMixing()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PauseAudioMixing();
            }
        }

        public override int ResumeAudioMixing()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ResumeAudioMixing();
            }
        }

        public override int AdjustAudioMixingVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustAudioMixingVolume(volume);
            }
        }

        public override int AdjustAudioMixingPublishVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustAudioMixingPublishVolume(volume);
            }
        }

        public override int GetAudioMixingPublishVolume()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetAudioMixingPublishVolume();
            }
        }

        public override int AdjustAudioMixingPlayoutVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustAudioMixingPlayoutVolume(volume);
            }
        }

        public override int GetAudioMixingPlayoutVolume()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetAudioMixingPlayoutVolume();
            }
        }

        public override int GetAudioMixingDuration()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetAudioMixingDuration();
            }
        }

        public override int GetAudioMixingCurrentPosition()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetAudioMixingCurrentPosition();
            }
        }

        public override int SetAudioMixingPosition(int pos)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioMixingPosition(pos);
            }
        }

        public override int SetAudioMixingPitch(int pitch)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioMixingPitch(pitch);
            }
        }

        public override int GetEffectsVolume()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetEffectsVolume();
            }
        }

        public override int SetEffectsVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetEffectsVolume(volume);
            }
        }

        public override int PreloadEffect(int soundId, string filePath, int startPos = 0)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PreloadEffect(soundId, filePath, startPos);
            }
        }

        public override int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PlayEffect(soundId, filePath, loopCount, pitch, pan, gain, publish, startPos);
            }
        }

        public override int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PlayAllEffects(loopCount, pitch, pan, gain, publish);
            }
        }

        public override int GetVolumeOfEffect(int soundId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetVolumeOfEffect(soundId);
            }
        }

        public override int SetVolumeOfEffect(int soundId, int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVolumeOfEffect(soundId, volume);
            }
        }

        public override int PauseEffect(int soundId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PauseEffect(soundId);
            }
        }

        public override int PauseAllEffects()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PauseAllEffects();
            }
        }

        public override int ResumeEffect(int soundId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ResumeEffect(soundId);
            }
        }

        public override int ResumeAllEffects()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ResumeAllEffects();
            }
        }

        public override int StopEffect(int soundId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopEffect(soundId);
            }
        }

        public override int StopAllEffects()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopAllEffects();
            }
        }

        public override int UnloadEffect(int soundId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UnloadEffect(soundId);
            }
        }

        public override int UnloadAllEffects()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UnloadAllEffects();
            }
        }

        public override int GetEffectCurrentPosition(int soundId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetEffectCurrentPosition(soundId);
            }
        }

        public override int GetEffectDuration(string filePath)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetEffectDuration(filePath);
            }
        }

        public override int SetEffectPosition(int soundId, int pos)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetEffectPosition(soundId, pos);
            }
        }

        public override int EnableSoundPositionIndication(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableSoundPositionIndication(enabled);
            }
        }

        public override int SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteVoicePosition(uid, pan, gain);
            }
        }

        public override int EnableSpatialAudio(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableSpatialAudio(enabled);
            }
        }

        public override int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteUserSpatialAudioParams(uid, param);
            }
        }

        public override int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVoiceBeautifierPreset(preset);
            }
        }

        public override int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioEffectPreset(preset);
            }
        }

        public override int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVoiceConversionPreset(preset);
            }
        }

        public override int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioEffectParameters(preset, param1, param2);
            }
        }

        public override int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVoiceBeautifierParameters(preset, param1, param2);
            }
        }

        public override int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVoiceConversionParameters(preset, param1, param2);
            }
        }

        public override int SetLocalVoicePitch(double pitch)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLocalVoicePitch(pitch);
            }
        }

        public override int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLocalVoiceEqualization(bandFrequency, bandGain);
            }
        }

        public override int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLocalVoiceReverb(reverbKey, value);
            }
        }

        public override int SetHeadphoneEQParameters(int lowGain, int highGain)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetHeadphoneEQParameters(lowGain, highGain);
            }
        }

        public override int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetHeadphoneEQPreset(preset);
            }
        }

        public override int SetLogFile(string filePath)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLogFile(filePath);
            }
        }

        public override int SetLogFilter(uint filter)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLogFilter(filter);
            }
        }

        public override int SetLogLevel(LOG_LEVEL level)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLogLevel(level);
            }
        }

        public override int SetLogFileSize(uint fileSizeInKBytes)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLogFileSize(fileSizeInKBytes);
            }
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLocalRenderMode(renderMode, mirrorMode);
            }
        }

        public override int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteRenderMode(uid, renderMode, mirrorMode);
            }
        }

        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLocalRenderMode(renderMode);
            }
        }

        public override int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLocalVideoMirrorMode(mirrorMode);
            }
        }

        public override int EnableDualStreamMode(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableDualStreamMode(enabled);
            }
        }

        public override int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableDualStreamMode(enabled, streamConfig);
            }
        }


        public override int SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetExternalAudioSink(enabled, sampleRate, channels);
            }
        }

        public override int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableMultiCamera(enabled, config);
            }
        }

        public override int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRecordingAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            }
        }

        public override int SetPublishAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetPublishAudioFrameParameters(sampleRate, channel, samplesPerCall);
            }
        }

        public override int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetPlaybackAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            }
        }

        public override int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetMixedAudioFrameParameters(sampleRate, channel, samplesPerCall);
            }
        }

        public override int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetEarMonitoringAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
            }
        }


        public override int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetPlaybackAudioFrameBeforeMixingParameters(sampleRate, channel);
            }
        }

        public override int EnableAudioSpectrumMonitor(int intervalInMS = 100)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableAudioSpectrumMonitor(intervalInMS);
            }
        }

        public override int DisableAudioSpectrumMonitor()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.DisableAudioSpectrumMonitor();
            }
        }

        public override int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RegisterAudioSpectrumObserver(observer);
            }
        }

        public override int UnregisterAudioSpectrumObserver()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UnregisterAudioSpectrumObserver();
            }
        }

        public override int AdjustRecordingSignalVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustRecordingSignalVolume(volume);
            }
        }

        public override int MuteRecordingSignal(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteRecordingSignal(mute);
            }
        }

        public override int AdjustPlaybackSignalVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustPlaybackSignalVolume(volume);
            }
        }

        public override int AdjustLoopbackSignalVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustLoopbackSignalVolume(volume);
            }
        }


        public override int AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustUserPlaybackSignalVolume(uid, volume);
            }
        }

        public override int EnableLoopbackRecording(bool enabled, string deviceName = "")
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableLoopbackRecording(enabled, deviceName);
            }
        }

        public override int GetLoopbackRecordingVolume()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetLoopbackRecordingVolume();
            }
        }

        public override int EnableInEarMonitoring(bool enabled, int includeAudioFilters)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableInEarMonitoring(enabled, includeAudioFilters);
            }
        }

        public override int SetInEarMonitoringVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetInEarMonitoringVolume(volume);
            }
        }

        public override int LoadExtensionProvider(string path, bool unload_after_use = false)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.LoadExtensionProvider(path, unload_after_use);
            }
        }

        public override int SetExtensionProviderProperty(string provider, string key, string value)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetExtensionProviderProperty(provider, key, value);
            }
        }

        public override int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableExtension(provider, extension, enable, type);
            }
        }

        public override int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable = true)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableExtension(provider, extension, extensionInfo, enable);
            }
        }


        public override int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetExtensionProperty(provider, extension, key, value, type);
            }
        }


        public override int SetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, string value)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetExtensionProperty(provider, extension, extensionInfo, key, value);
            }
        }

        public override int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetExtensionProperty(provider, extension, key, ref value, buf_len, type);
            }
        }

        public override int GetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, ref string value, int buf_len)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetExtensionProperty(provider, extension, extensionInfo, key, ref value, buf_len);
            }
        }

        public override int SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraCapturerConfiguration(config);
            }
        }

        public override int SwitchCamera()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SwitchCamera();
            }
        }

        public override bool IsCameraZoomSupported()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsCameraZoomSupported();
            }
        }

        public override bool IsCameraFaceDetectSupported()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsCameraFaceDetectSupported();
            }
        }

        public override bool IsCameraTorchSupported()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsCameraTorchSupported();
            }
        }

        public override bool IsCameraFocusSupported()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsCameraFocusSupported();
            }
        }

        public override bool IsCameraAutoFocusFaceModeSupported()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsCameraAutoFocusFaceModeSupported();
            }
        }

        public override int SetCameraZoomFactor(float factor)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraZoomFactor(factor);
            }
        }

        public override int EnableFaceDetection(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableFaceDetection(enabled);
            }
        }

        public override float GetCameraMaxZoomFactor()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetCameraMaxZoomFactor();
            }
        }

        public override int SetCameraFocusPositionInPreview(float positionX, float positionY)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraFocusPositionInPreview(positionX, positionY);
            }
        }

        public override int SetCameraTorchOn(bool isOn)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraTorchOn(isOn);
            }
        }

        public override int SetCameraAutoFocusFaceModeEnabled(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraAutoFocusFaceModeEnabled(enabled);
            }
        }

        public override bool IsCameraExposurePositionSupported()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsCameraExposurePositionSupported();
            }
        }

        public override int SetCameraExposurePosition(float positionXinView, float positionYinView)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraExposurePosition(positionXinView, positionYinView);
            }
        }

        public override bool IsCameraExposureSupported()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsCameraExposureSupported();
            }
        }

        public override int SetCameraExposureFactor(float factor)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraExposureFactor(factor);
            }
        }

        public override bool IsCameraAutoExposureFaceModeSupported()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsCameraAutoExposureFaceModeSupported();
            }
        }

        public override int SetCameraAutoExposureFaceModeEnabled(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraAutoExposureFaceModeEnabled(enabled);
            }
        }

        public override int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetDefaultAudioRouteToSpeakerphone(defaultToSpeaker);
            }
        }

        public override int SetEnableSpeakerphone(bool speakerOn)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetEnableSpeakerphone(speakerOn);
            }
        }

        public override bool IsSpeakerphoneEnabled()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsSpeakerphoneEnabled();
            }
        }

        public override int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
            }
        }

        public override int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartScreenCaptureByScreenRect(screenRect, regionRect, captureParams);
            }
        }

        public override int StartScreenCapture(byte[] mediaProjectionPermissionResultData, ScreenCaptureParameters captureParams)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartScreenCapture(mediaProjectionPermissionResultData, captureParams);
            }
        }

        //only in android 
        public override int StartScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartScreenCapture(captureParams);
            }
        }

        //only in android 
        public override int UpdateScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateScreenCapture(captureParams);
            }
        }

        public override int QueryScreenCaptureCapability()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.QueryScreenCaptureCapability();
            }
        }

        public override int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartScreenCaptureByWindowId(windowId, regionRect, captureParams);
            }
        }

        public override int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetScreenCaptureContentHint(contentHint);
            }
        }

        public override int UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateScreenCaptureRegion(regionRect);
            }
        }

        public override int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateScreenCaptureParameters(captureParams);
            }
        }

        public override int StopScreenCapture()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopScreenCapture();
            }
        }

        public override int GetCallId(ref string callId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetCallId(ref callId);
            }
        }

        public override int GetCallIdEx(ref string callId, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetCallIdEx(ref callId, connection);
            }
        }

        public override int Rate(string callId, int rating, string description)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.Rate(callId, rating, description);
            }
        }

        public override int Complain(string callId, string description)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.Complain(callId, description);
            }
        }

        //public override int AddPublishStreamUrl(string url, bool transcodingEnabled)
        //{
        //lock (rtcLock)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.AddPublishStreamUrl(url, transcodingEnabled);
        //}
        //}

        //public override int RemovePublishStreamUrl(string url)
        //{
        // lock (rtcLock)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.RemovePublishStreamUrl(url);
        //}
        //}

        //public override int SetLiveTranscoding(LiveTranscoding transcoding)
        //{
        //lock (rtcLock)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.SetLiveTranscoding(transcoding);
        //}
        //}

        public override int StartLocalVideoTranscoder(LocalTranscoderConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartLocalVideoTranscoder(config);
            }
        }

        public override int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateLocalTranscoderConfiguration(config);
            }
        }

        public override int StopLocalVideoTranscoder()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopLocalVideoTranscoder();
            }
        }

        public override int StartCameraCapture(VIDEO_SOURCE_TYPE type, CameraCapturerConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartCameraCapture(type, config);
            }
        }

        public override int StopCameraCapture(VIDEO_SOURCE_TYPE type)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopCameraCapture(type);
            }
        }

        public override int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCameraDeviceOrientation(type, orientation);
            }
        }

        public override int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetScreenCaptureOrientation(type, orientation);
            }
        }

        public override int StartScreenCapture(VIDEO_SOURCE_TYPE type, ScreenCaptureConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartScreenCapture(type, config);
            }
        }

        public override int StopScreenCapture(VIDEO_SOURCE_TYPE type)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopScreenCapture(type);
            }
        }

        public override CONNECTION_STATE_TYPE GetConnectionState()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
                }
                return _rtcEngineImpl.GetConnectionState();
            }
        }

        public override int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteUserPriority(uid, userPriority);
            }
        }

        //public override int RegisterPacketObserver(IPacketObserver observer)
        //{
        //lock (rtcLock)
        //{
        // if (_rtcEngineImpl == null)
        // {
        //     AgoraLog.LogError(ErrorMsgLog);
        // }
        //    return _rtcEngineImpl.Initialize(context);
        //}
        //}

        public override int SetEncryptionMode(string encryptionMode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetEncryptionMode(encryptionMode);
            }
        }

        public override int SetEncryptionSecret(string secret)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetEncryptionSecret(secret);
            }
        }

        public override int EnableEncryption(bool enabled, EncryptionConfig config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableEncryption(enabled, config);
            }
        }

        public override int CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.CreateDataStream(ref streamId, reliable, ordered);
            }
        }

        public override int CreateDataStream(ref int streamId, DataStreamConfig config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.CreateDataStream(ref streamId, config);
            }
        }

        public override int SendStreamMessage(int streamId, byte[] data, uint length)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SendStreamMessage(streamId, data, length);
            }
        }

        public override int AddVideoWatermark(RtcImage watermark)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AddVideoWatermark(watermark);
            }
        }

        public override int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AddVideoWatermark(watermarkUrl, options);
            }
        }

        public override int ClearVideoWatermarks()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ClearVideoWatermarks();
            }
        }

        public override int PauseAudio()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PauseAudio();
            }
        }

        public override int ResumeAudio()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ResumeAudio();
            }
        }

        public override int EnableWebSdkInteroperability(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableWebSdkInteroperability(enabled);
            }
        }

        public override int SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SendCustomReportMessage(id, category, @event, label, value);
            }
        }

        public override int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RegisterMediaMetadataObserver(observer, type);
            }
        }

        public override int UnregisterMediaMetadataObserver()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UnregisterMediaMetadataObserver();
            }
        }

        public override int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartAudioFrameDump(channel_id, user_id, location, uuid, passwd, duration_ms, auto_upload);
            }
        }

        public override int StopAudioFrameDump(string channel_id, uint user_id, string location)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopAudioFrameDump(channel_id, user_id, location);
            }
        }

        public override int RegisterLocalUserAccount(string appId, string userAccount)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RegisterLocalUserAccount(appId, userAccount);
            }
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.JoinChannelWithUserAccount(token, channelId, userAccount);
            }
        }

        public override int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.JoinChannelWithUserAccount(token, channelId, userAccount, options);
            }
        }

        public override int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetUserInfoByUserAccount(userAccount, ref userInfo);
            }
        }

        public override int GetUserInfoByUid(uint uid, ref UserInfo userInfo)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetUserInfoByUid(uid, ref userInfo);
            }
        }

        public override int PreloadChannel(string token, string channelId, uint uid)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PreloadChannel(token, channelId, uid);
            }
        }

        public override int PreloadChannel(string token, string channelId, string userAccount)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PreloadChannel(token, channelId, userAccount);
            }
        }

        public override int UpdatePreloadChannelToken(string token)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdatePreloadChannelToken(token);
            }
        }

        public override int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartChannelMediaRelay(configuration);
            }
        }

        public override int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateChannelMediaRelay(configuration);
            }
        }

        public override int StopChannelMediaRelay()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopChannelMediaRelay();
            }
        }

        public override int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetDirectCdnStreamingAudioConfiguration(profile);
            }
        }

        public override int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetDirectCdnStreamingVideoConfiguration(config);
            }
        }

        public override int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartDirectCdnStreaming(publishUrl, options);
            }
        }

        public override int StopDirectCdnStreaming()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopDirectCdnStreaming();
            }
        }

        public override int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateDirectCdnStreamingMediaOptions(options);
            }
        }

        public override int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.JoinChannelEx(token, connection, options);
            }
        }

        public override int LeaveChannelEx(RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.LeaveChannelEx(connection);
            }
        }

        public override int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.LeaveChannelEx(connection, options);
            }
        }


        public override int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateChannelMediaOptionsEx(options, connection);
            }
        }

        public override int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVideoEncoderConfigurationEx(config, connection);
            }
        }

        public override int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetupRemoteVideoEx(canvas, connection);
            }
        }

        public override int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteRemoteAudioStreamEx(uid, mute, connection);
            }
        }

        public override int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteRemoteVideoStreamEx(uid, mute, connection);
            }
        }

        public override int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteVoicePositionEx(uid, pan, gain, connection);
            }
        }

        public override int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteUserSpatialAudioParamsEx(uid, param, connection);
            }
        }

        public override int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteRenderModeEx(uid, renderMode, mirrorMode, connection);
            }
        }

        public override int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableLoopbackRecordingEx(connection, enabled, deviceName);
            }
        }

        public override int AdjustRecordingSignalVolumeEx(int volume, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustRecordingSignalVolumeEx(volume, connection);
            }
        }

        public override int MuteRecordingSignalEx(bool mute, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteRecordingSignalEx(mute, connection);
            }
        }

        public override CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
                }
            }
            return _rtcEngineImpl.GetConnectionStateEx(connection);
        }

        public override int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableEncryptionEx(connection, enabled, config);
            }
        }

        public override int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.CreateDataStreamEx(ref streamId, reliable, ordered, connection);
            }
        }

        public override int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.CreateDataStreamEx(ref streamId, config, connection);
            }
        }

        public override int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SendStreamMessageEx(streamId, data, length, connection);
            }
        }

        public override int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AddVideoWatermarkEx(watermarkUrl, options, connection);
            }
        }

        public override int ClearVideoWatermarkEx(RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ClearVideoWatermarkEx(connection);
            }
        }

        public override int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SendCustomReportMessageEx(id, category, @event, label, value, connection);
            }
        }

        public override int PushAudioFrame(AudioFrame frame, track_id_t trackId = 0)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PushAudioFrame(frame, trackId);
            }
        }

        public override int PullAudioFrame(AudioFrame frame)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PullAudioFrame(frame);
            }
        }

        public override int PushCaptureAudioFrame(AudioFrame frame)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PushCaptureAudioFrame(frame);
            }
        }

        public override int PushReverseAudioFrame(AudioFrame frame)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PushReverseAudioFrame(frame);
            }
        }

        public override int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetExternalVideoSource(enabled, useTexture, sourceType, encodedVideoOption);
            }
        }

        public override int SetExternalAudioSource(bool enabled, int sampleRate, int channels, bool localPlayback = false, bool publish = true)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetExternalAudioSource(enabled, sampleRate, channels, localPlayback, publish);
            }
        }


        public override track_id_t CreateCustomAudioTrack(AUDIO_TRACK_TYPE trackType, AudioTrackConfig config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return 0;
                }
                return _rtcEngineImpl.CreateCustomAudioTrack(trackType, config);
            }
        }

        public override int DestroyCustomAudioTrack(track_id_t trackId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return 0;
                }
                return _rtcEngineImpl.DestroyCustomAudioTrack(trackId);
            }
        }

        public override int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PushVideoFrame(frame, videoTrackId);
            }
        }


        public override int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo, videoTrackId);
            }
        }

        public override video_track_id_t CreateCustomEncodedVideoTrack(SenderOptions sender_option)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return 0;
                }
                return _rtcEngineImpl.CreateCustomEncodedVideoTrack(sender_option);
            }
        }

        public override int DestroyCustomEncodedVideoTrack(video_track_id_t video_track_id)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.DestroyCustomEncodedVideoTrack(video_track_id);
            }
        }

        public override video_track_id_t CreateCustomVideoTrack()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return 0;
                }
                return _rtcEngineImpl.CreateCustomVideoTrack();
            }
        }

        public override int DestroyCustomVideoTrack(video_track_id_t video_track_id)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return 0;
                }
                return _rtcEngineImpl.DestroyCustomVideoTrack(video_track_id);
            }
        }


        //public override int GetCertificateVerifyResult(string credential_buf, int credential_len, string certificate_buf, int certificate_len)
        //{
        //lock (rtcLock)
        //{
        // if (_rtcEngineImpl == null)
        // {
        //     AgoraLog.LogError(ErrorMsgLog);
        // }
        //    return _rtcEngineImpl.Initialize(context);
        //}
        //}

        public override int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAudioSessionOperationRestriction(restriction);
            }
        }

        public override int AdjustCustomAudioPublishVolume(track_id_t trackId, int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustCustomAudioPublishVolume(trackId, volume);
            }
        }

        public override int AdjustCustomAudioPlayoutVolume(track_id_t trackId, int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustCustomAudioPlayoutVolume(trackId, volume);
            }
        }

        public override int SetParameters(string parameters)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetParameters(parameters);
            }
        }


        public override int SetParameters(string key, object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(key, value);
            string parameters = AgoraJson.ToJson<Dictionary<string, object>>(dic);
            return SetParameters(parameters);
        }

        public override int GetAudioDeviceInfo(ref DeviceInfo deviceInfo)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetAudioDeviceInfo(ref deviceInfo);
            }
        }

        public override int EnableCustomAudioLocalPlayback(track_id_t trackId, bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableCustomAudioLocalPlayback(trackId, enabled);
            }
        }

        public override int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLocalPublishFallbackOption(option);
            }
        }

        public override int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteSubscribeFallbackOption(option);
            }
        }

        public override int PauseAllChannelMediaRelay()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PauseAllChannelMediaRelay();
            }
        }

        public override int ResumeAllChannelMediaRelay()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ResumeAllChannelMediaRelay();
            }
        }

        public override int TakeSnapshot(uint uid, string filePath)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.TakeSnapshot(uid, filePath);
            }
        }

        public override int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartRhythmPlayer(sound1, sound2, config);
            }
        }

        public override int StopRhythmPlayer()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopRhythmPlayer();
            }
        }

        public override int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ConfigRhythmPlayer(config);
            }
        }

        //public override int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options)
        //{
        //lock (rtcLock)
        //{
        // if (_rtcEngineImpl == null)
        // {
        //     AgoraLog.LogError(ErrorMsgLog);
        // }
        //    return _rtcEngineImpl.Initialize(context);
        //}
        //}

        //public override int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        //{
        //lock (rtcLock)
        //{
        // if (_rtcEngineImpl == null)
        // {
        //     AgoraLog.LogError(ErrorMsgLog);
        // }
        //    return _rtcEngineImpl.Initialize(context);
        //}
        //}

        public override int SetCloudProxy(CLOUD_PROXY_TYPE proxyType)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetCloudProxy(proxyType);
            }
        }

        public override int SetLocalAccessPoint(LocalAccessPointConfiguration config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetLocalAccessPoint(config);
            }
        }

        //public override int EnableFishEyeCorrection(bool enabled, FishEyeCorrectionParams @params)
        //{
        //lock (rtcLock)
        //{
        //    if (_rtcEngineImpl == null)
        //    {
        //        AgoraLog.LogError(ErrorMsgLog);
        //        return ErrorCode;
        //    }
        //    return _rtcEngineImpl.EnableFishEyeCorrection(enabled, @params);
        //}
        //}

        public override int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType = 0)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAdvancedAudioOptions(options, sourceType);
            }
        }

        public override int SetAVSyncSource(string channelId, uint uid)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetAVSyncSource(channelId, uid);
            }
        }

        public override int StartRtmpStreamWithoutTranscoding(string url)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartRtmpStreamWithoutTranscoding(url);
            }
        }

        public override int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartRtmpStreamWithTranscoding(url, transcoding);
            }
        }

        public override int UpdateRtmpTranscoding(LiveTranscoding transcoding)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateRtmpTranscoding(transcoding);
            }
        }

        public override int StopRtmpStream(string url)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopRtmpStream(url);
            }
        }

        public override int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetUserInfoByUserAccountEx(userAccount, ref userInfo, connection);
            }
        }

        public override int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetUserInfoByUidEx(uid, ref userInfo, connection);
            }
        }

        public override int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteVideoSubscriptionOptionsEx(uid, options, connection);
            }
        }

        public override int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetSubscribeAudioBlocklistEx(uidList, uidNumber, connection);
            }
        }

        public override int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetSubscribeAudioAllowlistEx(uidList, uidNumber, connection);
            }
        }

        public override int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetSubscribeVideoBlocklistEx(uidList, uidNumber, connection);
            }
        }

        public override int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetSubscribeVideoAllowlistEx(uidList, uidNumber, connection);
            }
        }

        public override int EnableContentInspect(bool enabled, ContentInspectConfig config)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableContentInspect(enabled, config);
            }
        }

        public override int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetRemoteVideoStreamTypeEx(uid, streamType, connection);
            }
        }

        public override int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connection);
            }
        }

        public override int SetVideoProfileEx(int width, int height, int frameRate, int bitrate)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetVideoProfileEx(width, height, frameRate, bitrate);
            }
        }

        public override int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableDualStreamModeEx(enabled, streamConfig, connection);
            }
        }

        public override int UploadLogFile(ref string requestId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UploadLogFile(ref requestId);
            }
        }

        public override int WriteLog(LOG_LEVEL level, string fmt)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.WriteLog(level, fmt);
            }
        }

        public override int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetSubscribeAudioBlocklist(uidList, uidNumber);
            }
        }

        public override int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetSubscribeAudioAllowlist(uidList, uidNumber);
            }
        }

        public override int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetSubscribeVideoBlocklist(uidList, uidNumber);
            }
        }

        public override int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetSubscribeVideoAllowlist(uidList, uidNumber);
            }
        }

        public override ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return null;
                }
                return _rtcEngineImpl.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
            }
        }

        public override int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SetScreenCaptureScenario(screenScenario);
            }
        }


        public override bool StartDumpVideo(VIDEO_SOURCE_TYPE type, string dir)
        {
            lock (rtcLock)
            {
                return _rtcEngineImpl.StartDumpVideo(type, dir);
            }
        }

        public override bool StopDumpVideo()
        {
            lock (rtcLock)
            {
                return _rtcEngineImpl.StopDumpVideo();
            }
        }

        public override int EnableWirelessAccelerate(bool enabled)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableWirelessAccelerate(enabled);
            }
        }

        public override int GetAudioTrackCount()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetAudioTrackCount();
            }
        }

        public override int SelectAudioTrack(int index)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SelectAudioTrack(index);
            }
        }

        public override long GetCurrentMonotonicTimeInMs()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetCurrentMonotonicTimeInMs();
            }
        }

        public override int MuteLocalAudioStreamEx(bool mute, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteLocalAudioStreamEx(mute, connection);
            }
        }

        public override int MuteLocalVideoStreamEx(bool mute, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteLocalVideoStreamEx(mute, connection);
            }
        }

        public override int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteAllRemoteAudioStreamsEx(mute, connection);
            }
        }

        public override int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.MuteAllRemoteVideoStreamsEx(mute, connection);
            }
        }

        public override int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.AdjustUserPlaybackSignalVolumeEx(uid, volume, connection);
            }
        }

        public override int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartRtmpStreamWithoutTranscodingEx(url, connection);
            }
        }

        public override int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartRtmpStreamWithTranscodingEx(url, transcoding, connection);
            }
        }

        public override int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateRtmpTranscodingEx(transcoding, connection);
            }
        }

        public override int StopRtmpStreamEx(string url, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopRtmpStreamEx(url, connection);
            }
        }

        public override int StartChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartChannelMediaRelayEx(configuration, connection);
            }
        }

        public override int UpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.UpdateChannelMediaRelayEx(configuration, connection);
            }
        }

        public override int StopChannelMediaRelayEx(RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StopChannelMediaRelayEx(connection);
            }
        }

        public override int PauseAllChannelMediaRelayEx(RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.PauseAllChannelMediaRelayEx(connection);
            }
        }

        public override int ResumeAllChannelMediaRelayEx(RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.ResumeAllChannelMediaRelayEx(connection);
            }
        }

        public override int GetNativeHandler(ref IntPtr nativeHandler)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.GetNativeHandler(ref nativeHandler);
            }
        }

        public override int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.RegisterExtension(provider, extension, type);
            }
        }

        public override int StartMediaRenderingTracing()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartMediaRenderingTracing();
            }
        }

        public override int EnableInstantMediaRendering()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.EnableInstantMediaRendering();
            }
        }

        public override int StartMediaRenderingTracingEx(RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.StartMediaRenderingTracingEx(connection);
            }
        }

        public override UInt64 GetNtpWallTimeInMs()
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return 0;
                }
                return _rtcEngineImpl.GetNtpWallTimeInMs();
            }
        }

        public override bool IsFeatureAvailableOnDevice(FeatureType type)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return false;
                }
                return _rtcEngineImpl.IsFeatureAvailableOnDevice(type);
            }
        }

        public override int SendAudioMetadata(byte[] metadata, uint length)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SendAudioMetadata(metadata, length);
            }
        }

        public override int SendAudioMetadataEx(RtcConnection connection, byte[] metadata, uint length)
        {
            lock (rtcLock)
            {
                if (_rtcEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _rtcEngineImpl.SendAudioMetadataEx(connection, metadata, length);
            }
        }
    }
}