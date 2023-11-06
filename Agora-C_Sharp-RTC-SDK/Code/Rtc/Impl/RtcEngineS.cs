#define AGORA_RTC
#define AGORA_RTM

using System;
using view_t = System.Int64;
using track_id_t = System.UInt32;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using UnityEngine;
#endif

namespace Agora.Rtc
{
    public sealed class RtcEngineS : IRtcEngineExS
    {
        private RtcEngineImplS _rtcEngineImpl = null;
        private IAudioDeviceManager _audioDeviceManager = null;
        private IVideoDeviceManager _videoDeviceManager = null;
        private IMusicContentCenter _musicContentCenter = null;
        private ILocalSpatialAudioEngineS _localSpatialAudioEngine = null;
        private IH265TranscoderS _h265Transcoder = null;
        private IMediaPlayerCacheManager _mediaPlayerCacheManager = null;

        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private GameObject _agoraEngineObject;
#endif

        private RtcEngineS(IntPtr nativePtr)
        {
            _rtcEngineImpl = RtcEngineImplS.GetInstance(nativePtr);
            _audioDeviceManager = AudioDeviceManager.GetInstance(this, _rtcEngineImpl.GetAudioDeviceManager());
            _videoDeviceManager = VideoDeviceManager.GetInstance(this, _rtcEngineImpl.GetVideoDeviceManager());
            _musicContentCenter = MusicContentCenter.GetInstance(this, _rtcEngineImpl.GetMusicContentCenter());
            _localSpatialAudioEngine = LocalSpatialAudioEngineS.GetInstance(this, _rtcEngineImpl.GetLocalSpatialAudioEngine());
            _h265Transcoder = H265TranscoderS.GetInstance(this, _rtcEngineImpl.GetH265Transcoder());
            _mediaPlayerCacheManager = MediaPlayerCacheManager.GetInstance(this, _rtcEngineImpl.GetMediaPlayerCacheManager());

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            InitAgoraEngineObject();
#endif
        }

        ~RtcEngineS()
        {
            _audioDeviceManager = null;
            _videoDeviceManager = null;
            _musicContentCenter = null;
            _localSpatialAudioEngine = null;
            _h265Transcoder = null;
            _mediaPlayerCacheManager = null;
        }

        private static IRtcEngineS instance = null;
        public static IRtcEngineS Instance
        {
            get
            {
                return instance ?? (instance = new RtcEngineS(IntPtr.Zero));
            }
        }

        public static IRtcEngineExS InstanceEx
        {
            get
            {
                return (IRtcEngineExS)(instance ?? (instance = new RtcEngineS(IntPtr.Zero)));
            }
        }

        public static IRtcEngineS CreateAgoraRtcEngine()
        {
            return instance ?? (instance = new RtcEngineS(IntPtr.Zero));
        }
        public static IRtcEngineS CreateAgoraRtcEngine(IntPtr nativePtr)
        {
            return instance ?? (instance = new RtcEngineS(nativePtr));
        }

        public static IRtcEngineExS CreateAgoraRtcEngineEx()
        {
            return (IRtcEngineExS)(instance ?? (instance = new RtcEngineS(IntPtr.Zero)));
        }
        public static IRtcEngineExS CreateAgoraRtcEngineEx(IntPtr nativePtr)
        {
            return (IRtcEngineExS)(instance ?? (instance = new RtcEngineS(nativePtr)));
        }

        public static IRtcEngineS Get()
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
            MusicContentCenter.ReleaseInstance();
            LocalSpatialAudioEngineS.ReleaseInstance();
            MediaPlayerCacheManager.ReleaseInstance();

            instance = null;
        }

        public override int InitEventHandler(IRtcEngineEventHandlerS engineEventHandler)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.InitEventHandler(engineEventHandler);
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

        public override IMediaRecorderS CreateMediaRecorder(RecorderStreamInfoS info)
        {
            MediaRecorderImplS impl = this._rtcEngineImpl.GetMediaRecorder();
            string nativeHande = impl.CreateMediaRecorder(info);
            if (nativeHande != null && nativeHande != "")
            {
                return new MediaRecorderS(impl, nativeHande);
            }
            else
            {
                return null;
            }
        }

        public override int DestroyMediaRecorder(IMediaRecorderS mediaRecorder)
        {
            MediaRecorderS recorder = (MediaRecorderS)mediaRecorder;
            MediaRecorderImplS impl = this._rtcEngineImpl.GetMediaRecorder();
            int nRet = impl.DestroyMediaRecorder(recorder.GetNativeHandle());
            if (nRet == 0)
            {
                recorder.SetNativeHandle(null);
            }
            return nRet;
        }

        public override IMediaPlayer CreateMediaPlayer()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return new MediaPlayer(this, _rtcEngineImpl.GetMediaPlayer());
        }

        public override int DestroyMediaPlayer(IMediaPlayer mediaPlayer)
        {
            if (_rtcEngineImpl == null || mediaPlayer == null)
            {
                return ErrorCode;
            }
            MediaPlayer player = (MediaPlayer)mediaPlayer;
            return player.Destroy();
        }

        public override ILocalSpatialAudioEngineS GetLocalSpatialAudioEngine()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _localSpatialAudioEngine;
        }

        public override IH265TranscoderS GetH265Transcoder()
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _h265Transcoder;
        }

        public override int GetNativeHandler(ref IntPtr nativeHandler)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetNativeHandler(ref nativeHandler);
        }

        public override int SetParameters(string key, object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(key, value);
            string parameters = AgoraJson.ToJson<Dictionary<string, object>>(dic);
            return SetParameters(parameters);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        public override int SendMetadata(MetadataS metadata, VIDEO_SOURCE_TYPE source_type)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SendMetadata(metadata, source_type);
        }

        public override int SetMaxMetadataSize(int size)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetMaxMetadataSize(size);
        }
#endif

        #region terra IRtcEngineBase
        public override string GetVersion(ref int build)
        {
            if (_rtcEngineImpl == null)
            {
                return "";
            }
            return _rtcEngineImpl.GetVersion(ref build);
        }
        public override string GetErrorDescription(int code)
        {
            if (_rtcEngineImpl == null)
            {
                return "";
            }
            return _rtcEngineImpl.GetErrorDescription(code);
        }
        public override int QueryCodecCapability(ref CodecCapInfo[] codecInfo, ref int size)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.QueryCodecCapability(ref codecInfo, ref size);
        }
        public override int QueryDeviceScore()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.QueryDeviceScore();
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
        public override int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableMultiCamera(enabled, config);
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
            return _rtcEngineImpl.StartPreview(sourceType);
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
        public override int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLowlightEnhanceOptions(enabled, options, type);
        }
        public override int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVideoDenoiserOptions(enabled, options, type);
        }
        public override int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetColorEnhanceOptions(enabled, options, type);
        }
        public override int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableVirtualBackground(enabled, backgroundSource, segproperty, type);
        }
        public override int SetVideoScenario(VIDEO_APPLICATION_SCENARIO_TYPE scenarioType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVideoScenario(scenarioType);
        }
        public override int SetVideoQoEPreference(VIDEO_QOE_PREFERENCE_TYPE qoePreference)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVideoQoEPreference(qoePreference);
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
        public override int SetAudioProfile(AUDIO_PROFILE_TYPE profile)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioProfile(profile);
        }
        public override int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioScenario(scenario);
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
        public override int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteDefaultVideoStreamType(streamType);
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
        public override int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RegisterAudioEncodedFrameObserver(config, observer);
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
        public override int SelectAudioTrack(int index)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SelectAudioTrack(index);
        }
        public override int GetAudioTrackCount()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetAudioTrackCount();
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
        public override int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioMixingDualMonoMode(mode);
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
        public override int GetEffectCurrentPosition(int soundId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetEffectCurrentPosition(soundId);
        }
        public override int EnableSoundPositionIndication(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableSoundPositionIndication(enabled);
        }
        public override int EnableSpatialAudio(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableSpatialAudio(enabled);
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
        public override int SetLocalVoiceFormant(double formantRatio)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalVoiceFormant(formantRatio);
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
        public override int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetHeadphoneEQPreset(preset);
        }
        public override int SetHeadphoneEQParameters(int lowGain, int highGain)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetHeadphoneEQParameters(lowGain, highGain);
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
        public override int UploadLogFile(ref string requestId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UploadLogFile(ref requestId);
        }
        public override int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetLocalRenderMode(renderMode, mirrorMode);
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
        public override int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableDualStreamMode(enabled, streamConfig);
        }
        public override int SetDualStreamMode(SIMULCAST_STREAM_MODE mode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDualStreamMode(mode);
        }
        public override int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDualStreamMode(mode, streamConfig);
        }
        public override int EnableCustomAudioLocalPlayback(uint trackId, bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableCustomAudioLocalPlayback(trackId, enabled);
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
        public override int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetEarMonitoringAudioFrameParameters(sampleRate, channel, mode, samplesPerCall);
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
        public override int EnableLoopbackRecording(bool enabled, string deviceName = "")
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableLoopbackRecording(enabled, deviceName);
        }
        public override int AdjustLoopbackSignalVolume(int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustLoopbackSignalVolume(volume);
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
        public override int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RegisterExtension(provider, extension, type);
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
        public override uint CreateCustomVideoTrack()
        {
            if (_rtcEngineImpl == null)
            {
                return 0;
            }
            return _rtcEngineImpl.CreateCustomVideoTrack();
        }
        public override uint CreateCustomEncodedVideoTrack(SenderOptions sender_option)
        {
            if (_rtcEngineImpl == null)
            {
                return 0;
            }
            return _rtcEngineImpl.CreateCustomEncodedVideoTrack(sender_option);
        }
        public override int DestroyCustomVideoTrack(uint video_track_id)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.DestroyCustomVideoTrack(video_track_id);
        }
        public override int DestroyCustomEncodedVideoTrack(uint video_track_id)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.DestroyCustomEncodedVideoTrack(video_track_id);
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
        public override bool IsCameraExposureSupported()
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsCameraExposureSupported();
        }
        public override int SetCameraExposureFactor(float factor)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetCameraExposureFactor(factor);
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
        public override int SetRouteInCommunicationMode(int route)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRouteInCommunicationMode(route);
        }
        public override ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen)
        {
            if (_rtcEngineImpl == null)
            {
                return null;
            }
            return _rtcEngineImpl.GetScreenCaptureSources(thumbSize, iconSize, includeScreen);
        }
        public override int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAudioSessionOperationRestriction(restriction);
        }
        public override int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartScreenCaptureByDisplayId(displayId, regionRect, captureParams);
        }
        public override int GetAudioDeviceInfo(ref DeviceInfoMobile deviceInfo)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetAudioDeviceInfo(ref deviceInfo);
        }
        public override int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect, ScreenCaptureParameters captureParams)
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
        public override int StartScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartScreenCapture(captureParams);
        }
        public override int UpdateScreenCapture(ScreenCaptureParameters2 captureParams)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateScreenCapture(captureParams);
        }
        public override int QueryScreenCaptureCapability()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.QueryScreenCaptureCapability();
        }
        public override int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetScreenCaptureScenario(screenScenario);
        }
        public override int StopScreenCapture()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopScreenCapture();
        }
        public override int GetCallId(ref string callId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetCallId(ref callId);
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
        public override int StartRtmpStreamWithoutTranscoding(string url)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartRtmpStreamWithoutTranscoding(url);
        }
        public override int StopRtmpStream(string url)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopRtmpStream(url);
        }
        public override int StopLocalVideoTranscoder()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopLocalVideoTranscoder();
        }
        public override int StartCameraCapture(VIDEO_SOURCE_TYPE sourceType, CameraCapturerConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartCameraCapture(sourceType, config);
        }
        public override int StopCameraCapture(VIDEO_SOURCE_TYPE sourceType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopCameraCapture(sourceType);
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
        public override int StartScreenCapture(VIDEO_SOURCE_TYPE sourceType, ScreenCaptureConfiguration config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartScreenCapture(sourceType, config);
        }
        public override int StopScreenCapture(VIDEO_SOURCE_TYPE sourceType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopScreenCapture(sourceType);
        }
        public override CONNECTION_STATE_TYPE GetConnectionState()
        {
            if (_rtcEngineImpl == null)
            {
                return CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
            }
            return _rtcEngineImpl.GetConnectionState();
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
        public override int AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AddVideoWatermark(watermarkUrl, options);
        }
        public override int ClearVideoWatermarks()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ClearVideoWatermarks();
        }
        public override int SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SendCustomReportMessage(id, category, @event, label, value);
        }
        public override int SetAINSMode(bool enabled, AUDIO_AINS_MODE mode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAINSMode(enabled, mode);
        }
        public override int StopChannelMediaRelay()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopChannelMediaRelay();
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
        public override int EnableContentInspect(bool enabled, ContentInspectConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableContentInspect(enabled, config);
        }
        public override int AdjustCustomAudioPublishVolume(uint trackId, int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustCustomAudioPublishVolume(trackId, volume);
        }
        public override int AdjustCustomAudioPlayoutVolume(uint trackId, int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustCustomAudioPlayoutVolume(trackId, volume);
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
        public override int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAdvancedAudioOptions(options, sourceType);
        }
        public override int EnableVideoImageSource(bool enable, ImageTrackOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableVideoImageSource(enable, options);
        }
        public override long GetCurrentMonotonicTimeInMs()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetCurrentMonotonicTimeInMs();
        }
        public override int EnableWirelessAccelerate(bool enabled)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableWirelessAccelerate(enabled);
        }
        public override int GetNetworkType()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetNetworkType();
        }
        public override int SetParameters(string parameters)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetParameters(parameters);
        }
        public override int StartMediaRenderingTracing()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartMediaRenderingTracing();
        }
        public override int EnableInstantMediaRendering()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableInstantMediaRendering();
        }
        public override ulong GetNtpWallTimeInMs()
        {
            if (_rtcEngineImpl == null)
            {
                return 0;
            }
            return _rtcEngineImpl.GetNtpWallTimeInMs();
        }
        public override bool IsFeatureAvailableOnDevice(FeatureType type)
        {
            if (_rtcEngineImpl == null)
            {
                return false;
            }
            return _rtcEngineImpl.IsFeatureAvailableOnDevice(type);
        }
        #endregion terra IRtcEngineBase

        #region terra IRtcEngineS
        public override int PrepareUserAccount(string userAccount, uint uid)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PrepareUserAccount(userAccount, uid);
        }
        public override int Initialize(RtcEngineContextS contextS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.Initialize(contextS);
        }
        public override int JoinChannel(string token, string channelId, string info, string userAccount)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.JoinChannel(token, channelId, info, userAccount);
        }
        public override int JoinChannel(string token, string channelId, string userAccount, ChannelMediaOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.JoinChannel(token, channelId, userAccount, options);
        }
        public override int SetupRemoteVideo(VideoCanvasS canvas)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetupRemoteVideo(canvas);
        }
        public override int SetupLocalVideo(VideoCanvasBase canvas)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetupLocalVideo(canvas);
        }
        public override int MuteRemoteAudioStream(string userAccount, bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRemoteAudioStream(userAccount, mute);
        }
        public override int MuteRemoteVideoStream(string userAccount, bool mute)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRemoteVideoStream(userAccount, mute);
        }
        public override int SetRemoteVideoStreamType(string userAccount, VIDEO_STREAM_TYPE streamType)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVideoStreamType(userAccount, streamType);
        }
        public override int SetRemoteVideoSubscriptionOptions(string userAccount, VideoSubscriptionOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVideoSubscriptionOptions(userAccount, options);
        }
        public override int SetSubscribeAudioBlocklist(string[] userAccountList, int userAccountNumber)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeAudioBlocklist(userAccountList, userAccountNumber);
        }
        public override int SetSubscribeAudioAllowlist(string[] userAccountList, int userAccountNumber)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeAudioAllowlist(userAccountList, userAccountNumber);
        }
        public override int SetSubscribeVideoBlocklist(string[] userAccountList, int userAccountNumber)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeVideoBlocklist(userAccountList, userAccountNumber);
        }
        public override int SetSubscribeVideoAllowlist(string[] userAccountList, int userAccountNumber)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeVideoAllowlist(userAccountList, userAccountNumber);
        }
        public override int SetRemoteVoicePosition(string userAccount, double pan, double gain)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVoicePosition(userAccount, pan, gain);
        }
        public override int SetRemoteUserSpatialAudioParams(string userAccount, SpatialAudioParams @params)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteUserSpatialAudioParams(userAccount, @params);
        }
        public override int SetRemoteRenderMode(string userAccount, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteRenderMode(userAccount, renderMode, mirrorMode);
        }
        public override int RegisterAudioSpectrumObserver(IAudioSpectrumObserverS observerS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RegisterAudioSpectrumObserver(observerS);
        }
        public override int UnregisterAudioSpectrumObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UnregisterAudioSpectrumObserver();
        }
        public override int AdjustUserPlaybackSignalVolume(string userAccount, int volume)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustUserPlaybackSignalVolume(userAccount, volume);
        }
        public override int SetHighPriorityUserList(string[] userAccountList, int userAccountNum, STREAM_FALLBACK_OPTIONS option)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetHighPriorityUserList(userAccountList, userAccountNum, option);
        }
        public override int EnableExtension(string provider, string extension, ExtensionInfoS extensionInfoS, bool enable = true)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableExtension(provider, extension, extensionInfoS, enable);
        }
        public override int SetExtensionProperty(string provider, string extension, ExtensionInfoS extensionInfoS, string key, string value)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetExtensionProperty(provider, extension, extensionInfoS, key, value);
        }
        public override int GetExtensionProperty(string provider, string extension, ExtensionInfoS extensionInfoS, string key, ref string value, int buf_len)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.GetExtensionProperty(provider, extension, extensionInfoS, key, ref value, buf_len);
        }
        public override int StartRtmpStreamWithTranscoding(string url, LiveTranscodingS transcodingS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartRtmpStreamWithTranscoding(url, transcodingS);
        }
        public override int UpdateRtmpTranscoding(LiveTranscodingS transcodingS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateRtmpTranscoding(transcodingS);
        }
        public override int StartLocalVideoTranscoder(LocalTranscoderConfigurationS configS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartLocalVideoTranscoder(configS);
        }
        public override int UpdateLocalTranscoderConfiguration(LocalTranscoderConfigurationS configS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateLocalTranscoderConfiguration(configS);
        }
        public override int SetRemoteUserPriority(string userAccount, PRIORITY_TYPE userPriority)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteUserPriority(userAccount, userPriority);
        }
        public override int RegisterMediaMetadataObserver(IMetadataObserverS observerS, METADATA_TYPE type)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RegisterMediaMetadataObserver(observerS, type);
        }
        public override int UnregisterMediaMetadataObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UnregisterMediaMetadataObserver();
        }
        public override int StartAudioFrameDump(string channel_id, string userAccount, string location, string uuid, string passwd, long duration_ms, bool auto_upload)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartAudioFrameDump(channel_id, userAccount, location, uuid, passwd, duration_ms, auto_upload);
        }
        public override int StopAudioFrameDump(string channel_id, string userAccount, string location)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopAudioFrameDump(channel_id, userAccount, location);
        }
        public override int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfigurationS configuration)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartOrUpdateChannelMediaRelay(configuration);
        }
        public override int TakeSnapshot(string userAccount, string filePath)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.TakeSnapshot(userAccount, filePath);
        }
        public override int SetAVSyncSource(string channelId, string userAccount)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetAVSyncSource(channelId, userAccount);
        }
        #endregion terra IRtcEngineS

        public override int SetParametersEx(RtcConnectionS connection, string key, object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(key, value);
            string parameters = AgoraJson.ToJson<Dictionary<string, object>>(dic);
            return SetParametersEx(connection, parameters);
        }

        #region terra IRtcEngineExS
        public override int JoinChannelEx(string token, RtcConnectionS connectionS, ChannelMediaOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.JoinChannelEx(token, connectionS, options);
        }
        public override int LeaveChannelEx(RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.LeaveChannelEx(connectionS);
        }
        public override int LeaveChannelEx(RtcConnectionS connectionS, LeaveChannelOptions options)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.LeaveChannelEx(connectionS, options);
        }
        public override int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateChannelMediaOptionsEx(options, connectionS);
        }
        public override int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetVideoEncoderConfigurationEx(config, connectionS);
        }
        public override int SetupRemoteVideoEx(VideoCanvasS canvas, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetupRemoteVideoEx(canvas, connectionS);
        }
        public override int MuteRemoteAudioStreamEx(string userAccount, bool mute, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRemoteAudioStreamEx(userAccount, mute, connectionS);
        }
        public override int MuteRemoteVideoStreamEx(string userAccount, bool mute, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRemoteVideoStreamEx(userAccount, mute, connectionS);
        }
        public override int SetRemoteVideoStreamTypeEx(string userAccount, VIDEO_STREAM_TYPE streamType, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVideoStreamTypeEx(userAccount, streamType, connectionS);
        }
        public override int MuteLocalAudioStreamEx(bool mute, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteLocalAudioStreamEx(mute, connectionS);
        }
        public override int MuteLocalVideoStreamEx(bool mute, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteLocalVideoStreamEx(mute, connectionS);
        }
        public override int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteAllRemoteAudioStreamsEx(mute, connectionS);
        }
        public override int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteAllRemoteVideoStreamsEx(mute, connectionS);
        }
        public override int SetSubscribeAudioBlocklistEx(string[] userAccountList, int userAccountNumber, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeAudioBlocklistEx(userAccountList, userAccountNumber, connectionS);
        }
        public override int SetSubscribeAudioAllowlistEx(string[] userAccountList, int userAccountNumber, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeAudioAllowlistEx(userAccountList, userAccountNumber, connectionS);
        }
        public override int SetSubscribeVideoBlocklistEx(string[] userAccountList, int userAccountNumber, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeVideoBlocklistEx(userAccountList, userAccountNumber, connectionS);
        }
        public override int SetSubscribeVideoAllowlistEx(string[] userAccountList, int userAccountNumber, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetSubscribeVideoAllowlistEx(userAccountList, userAccountNumber, connectionS);
        }
        public override int SetRemoteVideoSubscriptionOptionsEx(string userAccount, VideoSubscriptionOptions options, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVideoSubscriptionOptionsEx(userAccount, options, connectionS);
        }
        public override int SetRemoteVoicePositionEx(string userAccount, double pan, double gain, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteVoicePositionEx(userAccount, pan, gain, connectionS);
        }
        public override int SetRemoteUserSpatialAudioParamsEx(string userAccount, SpatialAudioParams @params, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteUserSpatialAudioParamsEx(userAccount, @params, connectionS);
        }
        public override int SetRemoteRenderModeEx(string userAccount, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetRemoteRenderModeEx(userAccount, renderMode, mirrorMode, connectionS);
        }
        public override int EnableLoopbackRecordingEx(RtcConnectionS connectionS, bool enabled, string deviceName = "")
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableLoopbackRecordingEx(connectionS, enabled, deviceName);
        }
        public override int AdjustRecordingSignalVolumeEx(int volume, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustRecordingSignalVolumeEx(volume, connectionS);
        }
        public override int MuteRecordingSignalEx(bool mute, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.MuteRecordingSignalEx(mute, connectionS);
        }
        public override int AdjustUserPlaybackSignalVolumeEx(string userAccount, int volume, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AdjustUserPlaybackSignalVolumeEx(userAccount, volume, connectionS);
        }
        public override CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
            }
            return _rtcEngineImpl.GetConnectionStateEx(connectionS);
        }
        public override int EnableEncryptionEx(RtcConnectionS connectionS, bool enabled, EncryptionConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableEncryptionEx(connectionS, enabled, config);
        }
        public override int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.CreateDataStreamEx(ref streamId, reliable, ordered, connectionS);
        }
        public override int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.CreateDataStreamEx(ref streamId, config, connectionS);
        }
        public override int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SendStreamMessageEx(streamId, data, length, connectionS);
        }
        public override int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.AddVideoWatermarkEx(watermarkUrl, options, connectionS);
        }
        public override int ClearVideoWatermarkEx(RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ClearVideoWatermarkEx(connectionS);
        }
        public override int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SendCustomReportMessageEx(id, category, @event, label, value, connectionS);
        }
        public override int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connectionS);
        }
        public override int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartRtmpStreamWithoutTranscodingEx(url, connectionS);
        }
        public override int StartRtmpStreamWithTranscodingEx(string url, LiveTranscodingS transcodingS, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartRtmpStreamWithTranscodingEx(url, transcodingS, connectionS);
        }
        public override int UpdateRtmpTranscodingEx(LiveTranscodingS transcodingS, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UpdateRtmpTranscodingEx(transcodingS, connectionS);
        }
        public override int StopRtmpStreamEx(string url, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopRtmpStreamEx(url, connectionS);
        }
        public override int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfigurationS configurationS, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartOrUpdateChannelMediaRelayEx(configurationS, connectionS);
        }
        public override int StopChannelMediaRelayEx(RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StopChannelMediaRelayEx(connectionS);
        }
        public override int PauseAllChannelMediaRelayEx(RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PauseAllChannelMediaRelayEx(connectionS);
        }
        public override int ResumeAllChannelMediaRelayEx(RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.ResumeAllChannelMediaRelayEx(connectionS);
        }
        public override int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.EnableDualStreamModeEx(enabled, streamConfig, connectionS);
        }
        public override int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetDualStreamModeEx(mode, streamConfig, connectionS);
        }
        public override int SetHighPriorityUserListEx(string[] userAccountList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetHighPriorityUserListEx(userAccountList, uidNum, option, connectionS);
        }
        public override int TakeSnapshotEx(RtcConnectionS connectionS, string userAccount, string filePath)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.TakeSnapshotEx(connectionS, userAccount, filePath);
        }
        public override int StartMediaRenderingTracingEx(RtcConnectionS connectionS)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.StartMediaRenderingTracingEx(connectionS);
        }
        public override int SetParametersEx(RtcConnectionS connectionS, string parameters)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetParametersEx(connectionS, parameters);
        }
        #endregion terra IRtcEngineExS

        public override int RegisterAudioFrameObserver(IAudioFrameObserverBase audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RegisterAudioFrameObserver(audioFrameObserver, position, mode);
        }

        public override int RegisterVideoFrameObserver(IVideoFrameObserverS videoFrameObserver, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RegisterVideoFrameObserver(videoFrameObserver, formatPreference, position, mode);
        }

        public override int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserverS videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.RegisterVideoEncodedFrameObserver(videoEncodedImageReceiver, mode);
        }

        public override int UnRegisterAudioFrameObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UnRegisterAudioFrameObserver();
        }

        public override int UnRegisterVideoFrameObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UnRegisterVideoFrameObserver();
        }

        public override int UnRegisterAudioEncodedFrameObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UnRegisterAudioEncodedFrameObserver();
        }

        public override int UnRegisterVideoEncodedFrameObserver()
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.UnRegisterVideoEncodedFrameObserver();
        }

        #region terra IMediaEngineBase
        public override int PushAudioFrame(AudioFrame frame, uint trackId = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PushAudioFrame(frame, trackId);
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
        [Obsolete("This method is deprecated. Use createCustomAudioTrack(rtc::AUDIO_TRACK_TYPE trackType, const rtc::AudioTrackConfig& config) instead.")]
        public override int SetExternalAudioSource(bool enabled, int sampleRate, int channels, bool localPlayback = false, bool publish = true)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetExternalAudioSource(enabled, sampleRate, channels, localPlayback, publish);
        }
        public override uint CreateCustomAudioTrack(AUDIO_TRACK_TYPE trackType, AudioTrackConfig config)
        {
            if (_rtcEngineImpl == null)
            {
                return 0;
            }
            return _rtcEngineImpl.CreateCustomAudioTrack(trackType, config);
        }
        public override int DestroyCustomAudioTrack(uint trackId)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.DestroyCustomAudioTrack(trackId);
        }
        public override int SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.SetExternalAudioSink(enabled, sampleRate, channels);
        }
        public override int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PushVideoFrame(frame, videoTrackId);
        }

        #endregion terra IMediaEngineBase

        #region terra IMediaEngineS
        public override int PushEncodedVideoImage(byte[] imageBuffer, ulong length, EncodedVideoFrameInfoS videoEncodedFrameInfo, uint videoTrackId = 0)
        {
            if (_rtcEngineImpl == null)
            {
                return ErrorCode;
            }
            return _rtcEngineImpl.PushEncodedVideoImage(imageBuffer, length, videoEncodedFrameInfo, videoTrackId);
        }

        #endregion terra IMediaEngineS
    }
}