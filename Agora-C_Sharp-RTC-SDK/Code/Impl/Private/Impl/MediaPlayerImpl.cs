using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;
    using IrisMediaPlayerCAudioFrameObserverNativeMarshal = IntPtr;
    using IrisMediaPlayerAudioFrameObserverHandleNative = IntPtr;
    using IrisMediaPlayerCCustomProviderNativeMarshal = IntPtr;
    using IrisMediaPlayerCustomProviderHandleNative = IntPtr;
    using IrisMediaPlayerCAudioSpectrumObserverNativeMarshal = IntPtr;
    using IrisMediaPlayerCAudioSpectrumObserverHandleNative = IntPtr;

    internal class MediaPlayerImpl
    {
        private bool _disposed = false;

        private IrisApiEnginePtr _irisApiEngine;

        private CharAssistant _result;

        private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;

        private IrisMediaPlayerCAudioFrameObserverNativeMarshal _irisMediaPlayerCAudioFrameObserverNative;
        private IrisMediaPlayerCAudioFrameObserver _irisMediaPlayerCAudioFrameObserver;
        private IrisMediaPlayerAudioFrameObserverHandleNative _irisMediaPlayerAudioFrameObserverHandleNative;

        private IrisMediaPlayerCCustomProviderNativeMarshal _irisMediaPlayerCCustomProviderNative;
        private IrisMediaPlayerCCustomProvider _irisMediaPlayerCCustomProvider;
        private IrisMediaPlayerCustomProviderHandleNative _irisMediaPlayerCustomProviderHandleNative;

        private IrisMediaPlayerCAudioSpectrumObserverNativeMarshal _irisMediaPlayerCAudioSpectrumObserverNative;
        private IrisMediaPlayerCAudioSpectrumObserver _irisMediaPlayerCAudioSpectrumObserver;
        private IrisMediaPlayerCAudioSpectrumObserverHandleNative _irisMediaPlayerCAudioSpectrumObserverHandleNative;
        
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        private AgoraCallbackObject _callbackObject;
        private static readonly string identifier = "AgoraMediaPlayer";
#endif

        internal MediaPlayerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
            CreateEventHandler();
        }

        ~MediaPlayerImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                ReleaseEventHandler();
                UnSetIrisAudioFrameObserver();
                UnSetIrisAudioSpectrumObserver();
            }

            _irisApiEngine = IntPtr.Zero;
            _result = new CharAssistant();
            
            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void CreateEventHandler()
        {
            if (_irisEngineEventHandlerHandleNative == IntPtr.Zero)
            {
                _irisCEventHandler = new IrisCEventHandler
                {
                    OnEvent = MediaPlayerSourceObserverNative.OnEvent
                };

                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
                {
                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent)
                };

                _irisCEngineEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEngineEventHandlerNative, true);
                _irisEngineEventHandlerHandleNative =
                    AgoraRtcNative.SetIrisMediaPlayerEventHandler(_irisApiEngine, _irisCEngineEventHandlerNative);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                _callbackObject = new AgoraCallbackObject(identifier);
                MediaPlayerSourceObserverNative.CallbackObject = _callbackObject;
#endif
            }
        }

        private void ReleaseEventHandler()
        {
            MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.Clear();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            MediaPlayerSourceObserverNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            AgoraRtcNative.UnsetIrisMediaPlayerEventHandler(_irisApiEngine, _irisEngineEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
            _irisEngineEventHandlerHandleNative = IntPtr.Zero;
        }

        

        private void SetIrisAudioFrameObserver()
        {
            var param = new { };
            if (_irisMediaPlayerAudioFrameObserverHandleNative != IntPtr.Zero) return;
            
            _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver
            {
                OnFrame = MediaPlayerAudioFrameObserverNative.OnFrame
            };
            
            var irisMediaPlayerCAudioFrameObserverNativeLocal = new IrisMediaPlayerCAudioFrameObserverNative
            {
                onFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioFrameObserver.OnFrame)
            };
            
            _irisMediaPlayerCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisMediaPlayerCAudioFrameObserverNativeLocal, _irisMediaPlayerCAudioFrameObserverNative, true);
            _irisMediaPlayerAudioFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerAudioFrameObserver(
                _irisApiEngine,
                _irisMediaPlayerCAudioFrameObserverNative, AgoraJson.ToJson(param)
            );
        }

        private void SetIrisAudioFrameObserverWithMode(RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            var param = new { mode };
            if (_irisMediaPlayerAudioFrameObserverHandleNative != IntPtr.Zero) return;
            
            _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver
            {
                OnFrame = MediaPlayerAudioFrameObserverNative.OnFrame
            };
            
            var irisMediaPlayerCAudioFrameObserverNativeLocal = new IrisMediaPlayerCAudioFrameObserverNative
            {
                onFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioFrameObserver.OnFrame)
            };
            
            _irisMediaPlayerCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisMediaPlayerCAudioFrameObserverNativeLocal, _irisMediaPlayerCAudioFrameObserverNative, true);
            _irisMediaPlayerAudioFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerAudioFrameObserver(
                _irisApiEngine,
                _irisMediaPlayerCAudioFrameObserverNative, AgoraJson.ToJson(param)
            );
        }

        private void UnSetIrisAudioFrameObserver()
        {
            var param = new { };
            if (_irisMediaPlayerAudioFrameObserverHandleNative == IntPtr.Zero) return;
            
            AgoraRtcNative.UnRegisterMediaPlayerAudioFrameObserver(
                _irisApiEngine,
                _irisMediaPlayerAudioFrameObserverHandleNative, AgoraJson.ToJson(param)
            );
            _irisMediaPlayerAudioFrameObserverHandleNative = IntPtr.Zero;
            _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver();
            Marshal.FreeHGlobal(_irisMediaPlayerCAudioFrameObserverNative);
        }

        private int SetCustomSourceProvider(int playerId, Int64 startPos)
        {
            var param = new { playerId, startPos };
            if (_irisMediaPlayerCustomProviderHandleNative != IntPtr.Zero) return -1;
            
            _irisMediaPlayerCCustomProvider = new IrisMediaPlayerCCustomProvider
            {
                OnSeek = MediaPlayerCustomDataProviderNative.OnSeek,
                OnReadData = MediaPlayerCustomDataProviderNative.OnReadData
            };

            var irisMediaPlayerCCustomProviderNativeLocal = new IrisMediaPlayerCCustomProviderNative
            {
                onSeek = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCCustomProvider.OnSeek),
                onReadData = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCCustomProvider.OnReadData)
            };

            _irisMediaPlayerCCustomProviderNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCCustomProviderNativeLocal));
            Marshal.StructureToPtr(irisMediaPlayerCCustomProviderNativeLocal, _irisMediaPlayerCCustomProviderNative, true);
            var ret = AgoraRtcNative.MediaPlayerOpenWithSource(
                _irisApiEngine,
                _irisMediaPlayerCCustomProviderNative, AgoraJson.ToJson(param)
            );
            return 0;
        }

        private void SetIrisAudioSpectrumObserver(int intervalInMS)
        {
            var param = new { intervalInMS };
            if (_irisMediaPlayerCAudioSpectrumObserverNative != IntPtr.Zero) return;
            
            _irisMediaPlayerCAudioSpectrumObserver = new IrisMediaPlayerCAudioSpectrumObserver
            {
                OnLocalAudioSpectrum = AudioSpectrumObserverNative.OnLocalAudioSpectrum,
                OnRemoteAudioSpectrum = AudioSpectrumObserverNative.OnRemoteAudioSpectrum
            };

            var irisMediaPlayerCAudioSpectrumObserverNativeLocal = new IrisMediaPlayerCAudioSpectrumObserverNative
            {
                onLocalAudioSpectrum = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioSpectrumObserver.OnLocalAudioSpectrum),
                onRemoteAudioSpectrum = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioSpectrumObserver.OnRemoteAudioSpectrum)
            };

            _irisMediaPlayerCAudioSpectrumObserverHandleNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioSpectrumObserverNativeLocal));
            Marshal.StructureToPtr(irisMediaPlayerCAudioSpectrumObserverNativeLocal, _irisMediaPlayerCAudioSpectrumObserverHandleNative, true);
            _irisMediaPlayerCAudioSpectrumObserverNative = AgoraRtcNative.RegisterMediaPlayerAudioSpectrumObserver(
                _irisApiEngine,
                _irisMediaPlayerCAudioSpectrumObserverHandleNative, AgoraJson.ToJson(param)
            );
        }

        private void UnSetIrisAudioSpectrumObserver()
        {
            var param = new { };
            if (_irisMediaPlayerCAudioSpectrumObserverNative == IntPtr.Zero) return;
            
            AgoraRtcNative.UnRegisterMediaPlayerAudioSpectrumObserver(
                _irisApiEngine,
                _irisMediaPlayerCAudioSpectrumObserverHandleNative, AgoraJson.ToJson(param)
            );
            _irisMediaPlayerCAudioSpectrumObserverNative = IntPtr.Zero;
            AudioSpectrumObserverNative.AgoraRtcAudioSpectrumObserver = null;
            _irisMediaPlayerCAudioSpectrumObserver = new IrisMediaPlayerCAudioSpectrumObserver();
            Marshal.FreeHGlobal(_irisMediaPlayerCAudioSpectrumObserverHandleNative);
        }

        public void InitEventHandler(int playerId, IMediaPlayerSourceObserver engineEventHandler)
        {
            if (!MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.ContainsKey(playerId))
            {
                MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.Add(playerId, engineEventHandler);
            }

            if (engineEventHandler == null && MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.ContainsKey(playerId))
            {
                MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.Remove(playerId);
            }
        }

        public void RegisterAudioFrameObserver(int playerId, IMediaPlayerAudioFrameObserver observer)
        {
            SetIrisAudioFrameObserver();
            if (!MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.ContainsKey(playerId))
            {
                MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.Add(playerId, observer);
            }
        }

        public void RegisterAudioFrameObserver(int playerId, IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            SetIrisAudioFrameObserverWithMode(mode);
            if (!MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.ContainsKey(playerId))
            {
                MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.Add(playerId, observer);
            }
        }

        public void UnregisterAudioFrameObserver(int playerId)
        {
            if (MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.ContainsKey(playerId))
            {
                MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.Remove(playerId);
            }
            UnSetIrisAudioFrameObserver();
        }

        public void RegisterMediaPlayerAudioSpectrumObserver(int playerId, IAudioSpectrumObserver observer, int intervalInMS)
        {
            SetIrisAudioSpectrumObserver(intervalInMS);
            if (!AudioSpectrumObserverNative.AgoraRtcAudioSpectrumObserverDic.ContainsKey(playerId))
            {
                AudioSpectrumObserverNative.AgoraRtcAudioSpectrumObserverDic.Add(playerId, observer);
            }
        }

        public void UnregisterMediaPlayerAudioSpectrumObserver()
        {
            UnSetIrisAudioSpectrumObserver();
        }

        public int CreateMediaPlayer()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_RTCENGINE_CREATEMEDIAPLAYER,
                "", 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int DestroyMediaPlayer(int playerId)
        {
            var param = new
            {
                playerId
            };
            string jsonParam = AgoraJson.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_RTCENGINE_DESTROYMEDIAPLAYER,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
        }

        public int Open(int playerId, string url, Int64 startPos)
        {
            var param = new
            {
                playerId,
                url,
                startPos
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_OPEN,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int OpenWithCustomSource(int playerId, Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            //var ret = SetCustomSourceProvider(playerId, startPos);
            //MediaPlayerCustomDataProviderNative.CustomDataProvider = provider;
            return -4;
        }

        public int Play(int playerId)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_PLAY,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Pause(int playerId)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_PAUSE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Stop(int playerId)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_STOP,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Resume(int playerId)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_RESUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Seek(int playerId, Int64 newPos)
        {
            var param = new
            {
                playerId,
                newPos
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SEEK,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetDuration(int playerId, ref Int64 duration)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETDURATION,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            duration = (Int64) AgoraJson.GetData<Int64>(_result.Result, "duration");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetPlayPosition(int playerId, ref Int64 pos)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYPOSITION,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            pos = (Int64) AgoraJson.GetData<Int64>(_result.Result, "pos");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetStreamCount(int playerId, ref Int64 count)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETSTREAMCOUNT,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            count = (Int64) AgoraJson.GetData<Int64>(_result.Result, "count");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetStreamInfo(int playerId, Int64 index, ref PlayerStreamInfo info)
        {
            var param = new
            {
                playerId,
                index
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETSTREAMINFO,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            info = ret != 0 ? new PlayerStreamInfo() : AgoraJson.JsonToStruct<PlayerStreamInfo>(_result.Result, "info");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetLoopCount(int playerId, int loopCount)
        {
            var param = new
            {
                playerId,
                loopCount
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETLOOPCOUNT,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int MuteAudio(int playerId, bool audio_mute)
        {
            var param = new
            {
                playerId,
                audio_mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_MUTEAUDIO,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public bool IsAudioMuted(int playerId)
        {
            //TODO CHECK
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ISAUDIOMUTED,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return (bool) AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public int MuteVideo(int playerId, bool video_mute)
        {
            var param = new
            {
                playerId,
                video_mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_MUTEVIDEO,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public bool IsVideoMuted(int playerId)
        {
            //TODO CHECK
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ISVIDEOMUTED,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return (bool) AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public int SetPlaybackSpeed(int playerId, int speed)
        {
            var param = new
            {
                playerId,
                speed
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYBACKSPEED,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SelectAudioTrack(int playerId, int index)
        {
            var param = new
            {
                playerId,
                index
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SELECTAUDIOTRACK,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetPlayerOption(int playerId, string key, int value)
        {
            var param = new
            {
                playerId,
                key,
                value
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYEROPTION,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetPlayerOption(int playerId, string key, string value)
        {
            var param = new
            {
                playerId,
                key,
                value
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYEROPTION2,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int TakeScreenshot(int playerId, string filename)
        {
            var param = new
            {
                playerId,
                filename
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_TAKESCREENSHOT,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SelectInternalSubtitle(int playerId, int index)
        {
            var param = new
            {
                playerId,
                index
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SELECTINTERNALSUBTITLE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetExternalSubtitle(int playerId, string url)
        {
            var param = new
            {
                playerId,
                url
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETEXTERNALSUBTITLE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public MEDIA_PLAYER_STATE GetState(int playerId)
        {
            //TODO CHECK
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETSTATE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return (MEDIA_PLAYER_STATE) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Mute(int playerId, bool mute)
        {
            var param = new
            {
                playerId,
                mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_MUTE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetMute(int playerId, ref bool mute)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETMUTE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            mute = (bool) AgoraJson.GetData<bool>(_result.Result, "mute");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int AdjustPlayoutVolume(int playerId, int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ADJUSTPLAYOUTVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetPlayoutVolume(int playerId, ref int volume)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYOUTVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            volume = (int) AgoraJson.GetData<int>(_result.Result, "volume");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int AdjustPublishSignalVolume(int playerId, int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ADJUSTPUBLISHSIGNALVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetPublishSignalVolume(int playerId, ref int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPUBLISHSIGNALVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            volume = (int) AgoraJson.GetData<int>(_result.Result, "volume");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetView(int playerId)
        {
            var param = new
            {
                playerId
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETVIEW,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode)
        {
            var param = new
            {
                playerId,
                renderMode
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETRENDERMODE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode)
        {
            var param = new
            {
                playerId,
                mode
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETAUDIODUALMONOMODE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public string GetPlayerSdkVersion(int playerId)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYERSDKVERSION,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret.ToString() : (string) AgoraJson.GetData<string>(_result.Result, "result");
        }

        public string GetPlaySrc(int playerId)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYSRC,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret.ToString() : (string) AgoraJson.GetData<string>(_result.Result, "result");
        }

        public int SetAudioPitch(int playerId, int pitch)
        {
            var param = new { playerId, pitch };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETAUDIOPITCH,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params)
        {
            var param = new { playerId, spatial_audio_params };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETSPATIALAUDIOPARAMS,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int OpenWithAgoraCDNSrc(int playerId, string src, Int64 startPos)
        {
            var param = new { playerId, src, startPos };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_OPENWITHAGORACDNSRC,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetAgoraCDNLineCount(int playerId)
        {
            var param = new { playerId };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETAGORACDNLINECOUNT,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SwitchAgoraCDNLineByIndex(int playerId, int index)
        {
            var param = new { playerId, index };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SWITCHAGORACDNLINEBYINDEX,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetCurrentAgoraCDNIndex(int playerId)
        {
            var param = new { playerId };
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETCURRENTAGORACDNINDEX,
                "", 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int EnableAutoSwitchAgoraCDN(int playerId, bool enable)
        {
            var param = new { playerId, enable };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ENABLEAUTOSWITCHAGORACDN,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int RenewAgoraCDNSrcToken(int playerId, string token, Int64 ts)
        {
            var param = new { playerId, token, ts };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_RENEWAGORACDNSRCTOKEN,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SwitchAgoraCDNSrc(int playerId, string src, bool syncPts = false)
        {
            var param = new { playerId, src, syncPts };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SWITCHAGORACDNSRC,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SwitchSrc(int playerId, string src, bool syncPts = true)
        {
            var param = new { playerId, src, syncPts };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SWITCHSRC,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int PreloadSrc(int playerId, string src, Int64 startPos)
        {
            var param = new { playerId, src, startPos };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_PRELOADSRC,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int PlayPreloadedSrc(int playerId, string src)
        {
            var param = new { playerId, src };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_PLAYPRELOADEDSRC,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int UnloadSrc(int playerId, string src)
        {
            var param = new { playerId, src };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_UNLOADSRC,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }
    }
}