#define AGORA_RTC
#define AGORA_RTM

using System;
using view_t = System.UInt64;
using track_id_t = System.UInt32;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using UnityEngine;
#endif

namespace Agora.Rtc
{
    public partial class RtcEngine : IRtcEngineEx
    {
        private RtcEngineImpl _impl = null;
        private IAudioDeviceManager _audioDeviceManager = null;
        private IVideoDeviceManager _videoDeviceManager = null;
        private IMusicContentCenter _musicContentCenter = null;
        private ILocalSpatialAudioEngine _localSpatialAudioEngine = null;
        private IH265Transcoder _h265Transcoder = null;
        private IMediaPlayerCacheManager _mediaPlayerCacheManager = null;

        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        private GameObject _agoraEngineObject;
#endif

        private RtcEngine(IntPtr nativePtr)
        {
            _impl = RtcEngineImpl.GetInstance(nativePtr);
            _audioDeviceManager = AudioDeviceManager.GetInstance(this, _impl.GetAudioDeviceManager());
            _videoDeviceManager = VideoDeviceManager.GetInstance(this, _impl.GetVideoDeviceManager());
            _musicContentCenter = MusicContentCenter.GetInstance(this, _impl.GetMusicContentCenter());
            _localSpatialAudioEngine = LocalSpatialAudioEngine.GetInstance(this, _impl.GetLocalSpatialAudioEngine());
            _h265Transcoder = H265Transcoder.GetInstance(this, _impl.GetH265Transcoder());
            _mediaPlayerCacheManager = MediaPlayerCacheManager.GetInstance(this, _impl.GetMediaPlayerCacheManager());

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            InitAgoraEngineObject();
#endif
        }

        ~RtcEngine()
        {
            _audioDeviceManager = null;
            _videoDeviceManager = null;
            _musicContentCenter = null;
            _localSpatialAudioEngine = null;
            _h265Transcoder = null;
            _mediaPlayerCacheManager = null;
        }

        public override void Dispose(bool sync = false)
        {
            if (_impl == null)
            {
                return;
            }

            _impl.Dispose(sync);
            _impl = null;

            AudioDeviceManager.ReleaseInstance();
            VideoDeviceManager.ReleaseInstance();
            MusicContentCenter.ReleaseInstance();
            H265Transcoder.ReleaseInstance();
            LocalSpatialAudioEngine.ReleaseInstance();
            MediaPlayerCacheManager.ReleaseInstance();

            instance = null;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            VideoStreamManager.position = VIDEO_MODULE_POSITION.POSITION_PRE_ENCODER;
#endif
        }

        private static IRtcEngine instance = null;
        public static IRtcEngine Instance
        {
            get
            {
                return instance ?? (instance = new RtcEngine(IntPtr.Zero));
            }
        }

        public static IRtcEngineEx InstanceEx
        {
            get
            {
                return (IRtcEngineEx)(instance ?? (instance = new RtcEngine(IntPtr.Zero)));
            }
        }

        public static IRtcEngine CreateAgoraRtcEngine()
        {
            return instance ?? (instance = new RtcEngine(IntPtr.Zero));
        }
        public static IRtcEngine CreateAgoraRtcEngine(IntPtr nativePtr)
        {
            return instance ?? (instance = new RtcEngine(nativePtr));
        }

        public static IRtcEngineEx CreateAgoraRtcEngineEx()
        {
            return (IRtcEngineEx)(instance ?? (instance = new RtcEngine(IntPtr.Zero)));
        }
        public static IRtcEngineEx CreateAgoraRtcEngineEx(IntPtr nativePtr)
        {
            return (IRtcEngineEx)(instance ?? (instance = new RtcEngine(nativePtr)));
        }

        public static IRtcEngine Get()
        {
            return instance;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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

        public override int InitEventHandler(IRtcEngineEventHandler engineEventHandler)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.InitEventHandler(engineEventHandler);
        }

        public override IAudioDeviceManager GetAudioDeviceManager()
        {
            if (_impl == null)
            {
                return null;
            }
            return _audioDeviceManager;
        }

        public override IVideoDeviceManager GetVideoDeviceManager()
        {
            if (_impl == null)
            {
                return null;
            }
            return _videoDeviceManager;
        }

        public override IMusicContentCenter GetMusicContentCenter()
        {
            if (_impl == null)
            {
                return null;
            }
            return _musicContentCenter;
        }

        public override IMediaPlayerCacheManager GetMediaPlayerCacheManager()
        {
            if (_impl == null)
            {
                return null;
            }
            return _mediaPlayerCacheManager;
        }

        public override IMediaRecorder CreateMediaRecorder(RecorderStreamInfo info)
        {
            MediaRecorderImpl impl = this._impl.GetMediaRecorder();
            string nativeHande = impl.CreateMediaRecorder(info);
            if (nativeHande != null && nativeHande != "")
            {
                return new MediaRecorder(impl, nativeHande);
            }
            else
            {
                return null;
            }
        }

        public override int DestroyMediaRecorder(IMediaRecorder mediaRecorder)
        {
            MediaRecorder recorder = (MediaRecorder)mediaRecorder;
            MediaRecorderImpl impl = this._impl.GetMediaRecorder();
            int nRet = impl.DestroyMediaRecorder(recorder.GetNativeHandle());
            if (nRet == 0)
            {
                recorder.SetNativeHandle(null);
            }
            return nRet;
        }

        public override IMediaPlayer CreateMediaPlayer()
        {
            if (_impl == null)
            {
                return null;
            }
            return new MediaPlayer(this, _impl.GetMediaPlayer());
        }

        public override int DestroyMediaPlayer(IMediaPlayer mediaPlayer)
        {
            if (_impl == null || mediaPlayer == null)
            {
                return ErrorCode;
            }
            MediaPlayer player = (MediaPlayer)mediaPlayer;
            return player.Destroy();
        }

        public override ILocalSpatialAudioEngine GetLocalSpatialAudioEngine()
        {
            if (_impl == null)
            {
                return null;
            }
            return _localSpatialAudioEngine;
        }

        public override IH265Transcoder GetH265Transcoder()
        {
            if (_impl == null)
            {
                return null;
            }
            return _h265Transcoder;
        }

        public override int GetNativeHandler(ref IntPtr nativeHandler)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetNativeHandler(ref nativeHandler);
        }

        public override int SetParameters(string key, object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(key, value);
            string parameters = AgoraJson.ToJson<Dictionary<string, object>>(dic);
            return SetParameters(parameters);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        public override int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.SendMetadata(metadata, source_type);
        }

        public override int SetMaxMetadataSize(int size)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.SetMaxMetadataSize(size);
        }
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        public override int SetLocalVideoDataSourcePosition(VIDEO_MODULE_POSITION position)
        {
            if (position != VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER && position != VIDEO_MODULE_POSITION.POSITION_PRE_ENCODER)
            {
                return -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            }

            VideoStreamManager.position = position;
            return 0;
        }
#endif


        public override int SetParametersEx(RtcConnection connection, string key, object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(key, value);
            string parameters = AgoraJson.ToJson<Dictionary<string, object>>(dic);
            return SetParametersEx(connection, parameters);
        }

        public override int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RegisterAudioFrameObserver(audioFrameObserver, position, mode);
        }

        public override int RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RegisterVideoFrameObserver(videoFrameObserver, formatPreference, position, mode);
        }

        public override int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RegisterVideoEncodedFrameObserver(videoEncodedImageReceiver, mode);
        }

        public override int UnRegisterAudioFrameObserver()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.UnRegisterAudioFrameObserver();
        }

        public override int UnRegisterVideoFrameObserver()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.UnRegisterVideoFrameObserver();
        }

        public override int UnRegisterAudioEncodedFrameObserver()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.UnRegisterAudioEncodedFrameObserver();
        }

        public override int UnRegisterVideoEncodedFrameObserver()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.UnRegisterVideoEncodedFrameObserver();
        }

        public override int UnRegisterFaceInfoObserver()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.UnRegisterFaceInfoObserver();
        }
    }
}