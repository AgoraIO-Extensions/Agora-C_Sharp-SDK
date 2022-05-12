//  AgoraRtcMediaPlayer.cs
//
//  Created by YuGuo Chen on December 12, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    using LitJson;

    using IrisApiEnginePtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;
    using IrisMediaPlayerCAudioFrameObserverNativeMarshal = IntPtr;
    using IrisMediaPlayerAudioFrameObserverHandleNative = IntPtr;
    using IrisMediaPlayerCVideoFrameObserverNativeMarshal = IntPtr;
    using IrisMediaPlayerVideoFrameObserverHandleNative = IntPtr;
    using IrisMediaPlayerCCustomProviderNativeMarshal = IntPtr;
    using IrisMediaPlayerCustomProviderHandleNative = IntPtr;
    using IrisMediaPlayerCAudioSpectrumObserverNativeMarshal = IntPtr;
    using IrisMediaPlayerCAudioSpectrumObserverHandleNative = IntPtr;

    public sealed class AgoraRtcMediaPlayer : IAgoraRtcMediaPlayer
    {
        private bool _disposed = false;
        private static readonly string identifier = "AgoraRtcMediaPlayer";
        private int playerId;
        private static readonly int INVALID_RETURN = -99;

        private IrisApiEnginePtr _irisApiEngine;
        private AgoraRtcMediaPlayerEventHandler _mediaPlayerEventHandlerInstance;

        private CharAssistant _result;

        private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;

        private IrisMediaPlayerCAudioFrameObserverNativeMarshal _irisMediaPlayerCAudioFrameObserverNative;
        private IrisMediaPlayerCAudioFrameObserver _irisMediaPlayerCAudioFrameObserver;
        private IrisMediaPlayerAudioFrameObserverHandleNative _irisMediaPlayerAudioFrameObserverHandleNative;

        private IrisMediaPlayerCVideoFrameObserverNativeMarshal _irisMediaPlayerCVideoFrameObserverNative;
        private IrisRtcCVideoFrameObserver _irisMediaPlayerCVideoFrameObserver;
        private IrisMediaPlayerVideoFrameObserverHandleNative _irisMediaPlayerVideoFrameObserverHandleNative;

        private IrisMediaPlayerCCustomProviderNativeMarshal _irisMediaPlayerCCustomProviderNative;
        private IrisMediaPlayerCCustomProvider _irisMediaPlayerCCustomProvider;
        private IrisMediaPlayerCustomProviderHandleNative _irisMediaPlayerCustomProviderHandleNative;

        private IrisMediaPlayerCAudioSpectrumObserverNativeMarshal _irisMediaPlayerCAudioSpectrumObserverNative;
        private IrisMediaPlayerCAudioSpectrumObserver _irisMediaPlayerCAudioSpectrumObserver;
        private IrisMediaPlayerCAudioSpectrumObserverHandleNative _irisMediaPlayerCAudioSpectrumObserverHandleNative;
        
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        private AgoraCallbackObject _callbackObject;
#endif

        internal AgoraRtcMediaPlayer(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
            CreateEventHandler();
        }

        ~AgoraRtcMediaPlayer()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                ReleaseEventHandler();
            }

            _irisApiEngine = IntPtr.Zero;
            _result = new CharAssistant();
            
            _disposed = true;
        }
        
        public override void Dispose()
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
                    OnEvent = RtcMediaPlayerEventHandlerNative.OnEvent,
                    OnEventWithBuffer = RtcMediaPlayerEventHandlerNative.OnEventWithBuffer
                };

                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
                {
                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent),
                    onEventWithBuffer =
                        Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEventWithBuffer)
                };

                _irisCEngineEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEngineEventHandlerNative, true);
                _irisEngineEventHandlerHandleNative =
                    AgoraRtcNative.SetIrisMediaPlayerEventHandler(_irisApiEngine, _irisCEngineEventHandlerNative);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                _callbackObject = new AgoraCallbackObject("Agora MediaPlayer");
                RtcMediaPlayerEventHandlerNative.CallbackObject = _callbackObject;
#endif
            }
            _mediaPlayerEventHandlerInstance = AgoraRtcMediaPlayerEventHandler.GetInstance();
            RtcMediaPlayerEventHandlerNative.RtcMediaPlayerEventHandler = _mediaPlayerEventHandlerInstance;
        }

        private void ReleaseEventHandler()
        {
            RtcMediaPlayerEventHandlerNative.RtcMediaPlayerEventHandler = null;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            RtcMediaPlayerEventHandlerNative.CallbackObject = null;
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
                OnFrame = AgoraRtcMediaPlayerAudioFrameObserverNative.OnFrame
            };
            
            var irisMediaPlayerCAudioFrameObserverNativeLocal = new IrisMediaPlayerCAudioFrameObserverNative
            {
                onFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioFrameObserver.OnFrame)
            };
            
            _irisMediaPlayerCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisMediaPlayerCAudioFrameObserverNativeLocal, _irisMediaPlayerCAudioFrameObserverNative, true);
            _irisMediaPlayerAudioFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerAudioFrameObserver(
                _irisApiEngine,
                _irisMediaPlayerCAudioFrameObserverNative, JsonMapper.ToJson(param)
            );
        }

        private void SetIrisAudioFrameObserverWithMode(RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            var param = new { mode };
            if (_irisMediaPlayerAudioFrameObserverHandleNative != IntPtr.Zero) return;
            
            _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver
            {
                OnFrame = AgoraRtcMediaPlayerAudioFrameObserverNative.OnFrame
            };
            
            var irisMediaPlayerCAudioFrameObserverNativeLocal = new IrisMediaPlayerCAudioFrameObserverNative
            {
                onFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioFrameObserver.OnFrame)
            };
            
            _irisMediaPlayerCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioFrameObserverNativeLocal));
            Marshal.StructureToPtr(irisMediaPlayerCAudioFrameObserverNativeLocal, _irisMediaPlayerCAudioFrameObserverNative, true);
            _irisMediaPlayerAudioFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerAudioFrameObserver(
                _irisApiEngine,
                _irisMediaPlayerCAudioFrameObserverNative, JsonMapper.ToJson(param)
            );
        }

        private void UnSetIrisAudioFrameObserver()
        {
            var param = new { };
            if (_irisMediaPlayerAudioFrameObserverHandleNative == IntPtr.Zero) return;
            
            AgoraRtcNative.UnRegisterMediaPlayerAudioFrameObserver(
                _irisApiEngine,
                _irisMediaPlayerAudioFrameObserverHandleNative, JsonMapper.ToJson(param)
            );
            _irisMediaPlayerAudioFrameObserverHandleNative = IntPtr.Zero;
            AgoraRtcMediaPlayerAudioFrameObserverNative.AudioFrameObserver = null;
            _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver();
            Marshal.FreeHGlobal(_irisMediaPlayerCAudioFrameObserverNative);
        }

        private void SetIrisVideoFrameObserver()
        {
            // var param = new { };
            // if (_irisMediaPlayerVideoFrameObserverHandleNative != IntPtr.Zero) return;
            //
            // _irisMediaPlayerCVideoFrameObserver = new IrisRtcCVideoFrameObserver
            // {
            //     OnCaptureVideoFrame = AgoraRtcMediaPlayerVideoFrameObserverNative.OnFrame,
            // };
            //
            // var irisMediaPlayerCVideoFrameObserverNativeLocal = new IrisRtcCVideoFrameObserverNative
            // {
            //     OnCaptureVideoFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCVideoFrameObserver.OnCaptureVideoFrame)
            // };
            //
            // _irisMediaPlayerCVideoFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCVideoFrameObserverNativeLocal));
            // Marshal.StructureToPtr(irisMediaPlayerCVideoFrameObserverNativeLocal, _irisMediaPlayerCVideoFrameObserverNative, true);
            // _irisMediaPlayerVideoFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerVideoFrameObserver(
            //     _irisApiEngine,
            //     _irisMediaPlayerCVideoFrameObserverNative, JsonMapper.ToJson(param)
            // );
        }

        private void UnSetIrisVideoFrameObserver()
        {
            // var param = new { };
            // if (_irisMediaPlayerVideoFrameObserverHandleNative == IntPtr.Zero) return;
            //
            // AgoraRtcNative.UnRegisterMediaPlayerVideoFrameObserver(
            //     _irisApiEngine,
            //     _irisMediaPlayerVideoFrameObserverHandleNative, JsonMapper.ToJson(param)
            // );
            // _irisMediaPlayerVideoFrameObserverHandleNative = IntPtr.Zero;
            // AgoraRtcMediaPlayerVideoFrameObserverNative.VideoFrameObserver = null;
            // _irisMediaPlayerCVideoFrameObserver = new IrisRtcCVideoFrameObserver();
            // Marshal.FreeHGlobal(_irisMediaPlayerCVideoFrameObserverNative);
        }

        private int SetCustomSourceProvider(int playerId, Int64 startPos)
        {
            var param = new { playerId, startPos };
            if (_irisMediaPlayerCustomProviderHandleNative != IntPtr.Zero) return -1;
            
            _irisMediaPlayerCCustomProvider = new IrisMediaPlayerCCustomProvider
            {
                OnSeek = AgoraRtcMediaPlayerCustomDataProviderNative.OnSeek,
                OnReadData = AgoraRtcMediaPlayerCustomDataProviderNative.OnReadData
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
                _irisMediaPlayerCCustomProviderNative, JsonMapper.ToJson(param)
            );
            return ret;
        }

        private void SetIrisAudioSpectrumObserver(int intervalInMS)
        {
            var param = new { intervalInMS };
            if (_irisMediaPlayerCAudioSpectrumObserverNative != IntPtr.Zero) return -1;
            
            _irisMediaPlayerCAudioSpectrumObserver = new IrisMediaPlayerCAudioSpectrumObserver
            {
                OnLocalAudioSpectrum = AgoraRtcMediaPlayerAudioSpectrumObserverNative.OnLocalAudioSpectrum,
                OnRemoteAudioSpectrum = AgoraRtcMediaPlayerAudioSpectrumObserverNative.OnRemoteAudioSpectrum
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
                _irisMediaPlayerCAudioSpectrumObserverHandleNative, JsonMapper.ToJson(param)
            );
        }

        private void UnSetIrisAudioSpectrumObserver()
        {
            var param = new { };
            if (_irisMediaPlayerCAudioSpectrumObserverNative == IntPtr.Zero) return;
            
            AgoraRtcNative.UnRegisterMediaPlayerAudioSpectrumObserver(
                _irisApiEngine,
                _irisMediaPlayerCAudioSpectrumObserverHandleNative, JsonMapper.ToJson(param)
            );
            _irisMediaPlayerCAudioSpectrumObserverNative = IntPtr.Zero;
            _irisMediaPlayerCAudioSpectrumObserver = new IrisMediaPlayerCAudioFrameObserver();
            Marshal.FreeHGlobal(_irisMediaPlayerCAudioSpectrumObserverHandleNative);
        }

        public override AgoraRtcMediaPlayerEventHandler GetAgoraRtcMediaPlayerEventHandler()
        {
            return _mediaPlayerEventHandlerInstance;
        }

        public override void InitEventHandler(IAgoraRtcMediaPlayerEventHandler engineEventHandler)
        {
           RtcMediaPlayerEventHandlerNative.RtcMediaPlayerEventHandler = engineEventHandler;
        }

        public override void RemoveEventHandler(IAgoraRtcMediaPlayerEventHandler engineEventHandler)
        {
           RtcMediaPlayerEventHandlerNative.RtcMediaPlayerEventHandler = null;
        }

        public override void RegisterAudioFrameObserver(IAgoraRtcMediaPlayerAudioFrameObserver observer)
        {
            SetIrisAudioFrameObserver();
            AgoraRtcMediaPlayerAudioFrameObserverNative.AudioFrameObserver = observer;
        }

        public override void RegisterAudioFrameObserver(IAgoraRtcMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            SetIrisAudioFrameObserverWithMode(mode);
            AgoraRtcMediaPlayerAudioFrameObserverNative.AudioFrameObserver = observer;
        }

        public override void UnregisterAudioFrameObserver(IAgoraRtcMediaPlayerAudioFrameObserver observer)
        {
            UnSetIrisAudioFrameObserver();
        }

        public override void RegisterVideoFrameObserver(IAgoraRtcMediaPlayerVideoFrameObserver observer)
        {
            return;
            // SetIrisVideoFrameObserver();
            // AgoraRtcMediaPlayerVideoFrameObserverNative.VideoFrameObserver = observer;
        }

        public override void UnregisterVideoFrameObserver(IAgoraRtcMediaPlayerVideoFrameObserver observer)
        {
            return;
            //UnSetIrisVideoFrameObserver();
        }

        public override void RegisterMediaPlayerAudioSpectrumObserver(IAgoraRtcMediaPlayerAudioSpectrumObserver observer, int intervalInMS)
        {
            SetIrisAudioSpectrumObserver(intervalInMS);
            AgoraRtcMediaPlayerAudioSpectrumObserverNative.AudioSpectrumObserver = observer;
        }

        public override void UnregisterMediaPlayerAudioSpectrumObserver(IAgoraRtcMediaPlayerAudioSpectrumObserver observer)
        {
            UnSetIrisAudioSpectrumObserver();
            AgoraRtcMediaPlayerAudioSpectrumObserverNative.AudioSpectrumObserver = null;
        }

        public override int CreateMediaPlayer()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_RTCENGINE_CREATEMEDIAPLAYER,
                "", 0, null, 0, out _result);
        }

        public override int DestroyMediaPlayer(int playerId)
        {
            var param = new
            {
                playerId
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_RTCENGINE_DESTROYMEDIAPLAYER,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
        }

        public override int Open(int playerId, string url, Int64 startPos)
        {
            var param = new
            {
                playerId,
                url,
                startPos
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_OPEN,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int OpenWithCustomSource(int playerId, Int64 startPos, IAgoraRtcMediaPlayerCustomDataProvider provider)
        {
            var ret = SetCustomSourceProvider(playerId, startPos);
            AgoraRtcMediaPlayerCustomDataProviderNative.CustomDataProvider = provider;
            return ret;
        }

        public override int Play(int playerId)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_PLAY,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int Pause(int playerId)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_PAUSE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int Stop(int playerId)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_STOP,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int Resume(int playerId)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_RESUME,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int Seek(int playerId, Int64 newPos)
        {
            var param = new
            {
                playerId,
                newPos
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SEEK,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetDuration(int playerId, ref Int64 duration)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETDURATION,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            duration = (Int64) AgoraJson.GetData<Int64>(_result.Result, "duration");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetPlayPosition(int playerId, ref Int64 pos)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYPOSITION,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            pos = (Int64) AgoraJson.GetData<Int64>(_result.Result, "pos");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetStreamCount(int playerId, ref Int64 count)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETSTREAMCOUNT,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            count = (Int64) AgoraJson.GetData<Int64>(_result.Result, "count");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetStreamInfo(int playerId, Int64 index, out PlayerStreamInfo info)
        {
            var param = new
            {
                playerId,
                index
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETSTREAMINFO,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            info = _result.Result.Length == 0 ? new PlayerStreamInfo() : AgoraJson.JsonToStruct<PlayerStreamInfo>(_result.Result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetLoopCount(int playerId, int loopCount)
        {
            var param = new
            {
                playerId,
                loopCount
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETLOOPCOUNT,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteAudio(int playerId, bool audio_mute)
        {
            var param = new
            {
                playerId,
                audio_mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_MUTEAUDIO,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override bool IsAudioMuted(int playerId)
        {
            //TODO CHECK
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ISAUDIOMUTED,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return (bool) AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public override int MuteVideo(int playerId, bool video_mute)
        {
            var param = new
            {
                playerId,
                video_mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_MUTEVIDEO,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override bool IsVideoMuted(int playerId)
        {
            //TODO CHECK
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ISVIDEOMUTED,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return (bool) AgoraJson.GetData<bool>(_result.Result, "result");
        }

        public override int SetPlaybackSpeed(int playerId, MEDIA_PLAYER_PLAYBACK_SPEED speed)
        {
            var param = new
            {
                playerId,
                speed
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYBACKSPEED,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SelectAudioTrack(int playerId, int index)
        {
            var param = new
            {
                playerId,
                index
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SELECTAUDIOTRACK,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetPlayerOption(int playerId, string key, int value)
        {
            var param = new
            {
                playerId,
                key,
                value
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYEROPTION,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetPlayerOption(int playerId, string key, string value)
        {
            var param = new
            {
                playerId,
                key,
                value
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYEROPTION2,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int TakeScreenshot(int playerId, string filename)
        {
            var param = new
            {
                playerId,
                filename
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_TAKESCREENSHOT,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SelectInternalSubtitle(int playerId, int index)
        {
            var param = new
            {
                playerId,
                index
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SELECTINTERNALSUBTITLE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetExternalSubtitle(int playerId, string url)
        {
            var param = new
            {
                playerId,
                url
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETEXTERNALSUBTITLE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override MEDIA_PLAYER_STATE GetState(int playerId)
        {
            //TODO CHECK
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETSTATE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (MEDIA_PLAYER_STATE) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int Mute(int playerId, bool mute)
        {
            var param = new
            {
                playerId,
                mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_MUTE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetMute(int playerId, ref bool mute)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETMUTE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            mute = (bool) AgoraJson.GetData<bool>(_result.Result, "mute");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustPlayoutVolume(int playerId, int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ADJUSTPLAYOUTVOLUME,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetPlayoutVolume(int playerId, ref int volume)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYOUTVOLUME,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            volume = (int) AgoraJson.GetData<int>(_result.Result, "volume");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int AdjustPublishSignalVolume(int playerId, int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ADJUSTPUBLISHSIGNALVOLUME,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetPublishSignalVolume(int playerId, ref int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPUBLISHSIGNALVOLUME,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            volume = (int) AgoraJson.GetData<int>(_result.Result, "volume");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetView(int playerId)
        {
            var param = new
            {
                playerId
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETVIEW,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode)
        {
            var param = new
            {
                playerId,
                renderMode
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETRENDERMODE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode)
        {
            var param = new
            {
                playerId,
                mode
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETAUDIODUALMONOMODE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override string GetPlayerSdkVersion(int playerId)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYERSDKVERSION,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret.ToString() : (string) AgoraJson.GetData<string>(_result.Result, "result");
        }

        public override string GetPlaySrc(int playerId)
        {
            var param = new { playerId };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYSRC,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret.ToString() : (string) AgoraJson.GetData<string>(_result.Result, "result");
        }

        public override int SetAudioPitch(int pitch)
        {
            var param = new { pitch };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETAUDIOPITCH,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params)
        {
            var param = new { playerId, spatial_audio_params };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SETSPATIALAUDIOPARAMS,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int OpenWithAgoraCDNSrc(string src, Int64 startPos)
        {
            var param = new { src, startPos };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_OPENWITHAGORACDNSRC,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetAgoraCDNLineCount()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETAGORACDNLINECOUNT,
                "", 0, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SwitchAgoraCDNLineByIndex(int index)
        {
            var param = new { index };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SWITCHAGORACDNLINEBYINDEX,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetCurrentAgoraCDNIndex()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_GETCURRENTAGORACDNINDEX,
                "", 0, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableAutoSwitchAgoraCDN(bool enable)
        {
            var param = new { enable };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_ENABLEAUTOSWITCHAGORACDN,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int RenewAgoraCDNSrcToken(string token, Int64 ts)
        {
            var param = new { token, ts };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_RENEWAGORACDNSRCTOKEN,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            var param = new { src, syncPts };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SWITCHAGORACDNSRC,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SwitchSrc(string src, bool syncPts = true)
        {
            var param = new { src, syncPts };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_SWITCHSRC,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PreloadSrc(string src, Int64 startPos)
        {
            var param = new { src, startPos };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_PRELOADSRC,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int PlayPreloadedSrc(string src)
        {
            var param = new { src };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_PLAYPRELOADEDSRC,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UnloadSrc(string src)
        {
            var param = new { src };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_MEDIAPLAYER_UNLOADSRC,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }
    }


    internal static class RtcMediaPlayerEventHandlerNative
    {
        internal static IAgoraRtcMediaPlayerEventHandler RtcMediaPlayerEventHandler = null;
        internal static AgoraCallbackObject CallbackObject = null;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(string @event, string data)
        {
            if (RtcMediaPlayerEventHandler == null) return;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
            CallbackObject._CallbackQueue.EnQueue(() =>
            {
#endif
                switch(@event)
                {
                    case "onPlayerSourceStateChanged":
                        RtcMediaPlayerEventHandler.OnPlayerSourceStateChanged(
                            (int) AgoraJson.GetData<int>(data, "playerId"),
                            (MEDIA_PLAYER_STATE) AgoraJson.GetData<int>(data, "state"),
                            (MEDIA_PLAYER_ERROR) AgoraJson.GetData<int>(data, "ec")
                        );
                        break;
                    case "onPositionChanged":
                        RtcMediaPlayerEventHandler.OnPositionChanged(
                            (int) AgoraJson.GetData<int>(data, "playerId"),
                            (Int64) AgoraJson.GetData<Int64>(data, "position")
                        );
                        break;
                    case "onPlayerEvent":  
                        RtcMediaPlayerEventHandler.OnPlayerEvent(
                            (int) AgoraJson.GetData<int>(data, "playerId"),
                            (MEDIA_PLAYER_EVENT) AgoraJson.GetData<int>(data, "event"),
                            (Int64) AgoraJson.GetData<Int64>(data, "elapsedTime"),
                            (string) AgoraJson.GetData<string>(data, "message")
                        );
                        break;
                    case "onPlayBufferUpdated":
                        RtcMediaPlayerEventHandler.OnPlayBufferUpdated(
                            (int) AgoraJson.GetData<int>(data, "playerId"),
                            (Int64) AgoraJson.GetData<Int64>(data, "playCachedBuffer")
                        );
                        break;
                    case "onCompleted":
                        RtcMediaPlayerEventHandler.OnCompleted(
                            (int) AgoraJson.GetData<int>(data, "playerId")
                        );
                        break;
                    case "onAgoraCDNTokenWillExpire":   
                        RtcMediaPlayerEventHandler.OnAgoraCDNTokenWillExpire();
                        break;
                    case "onPlayerInfoUpdated":
                        RtcMediaPlayerEventHandler.OnPlayerInfoUpdated(
                            AgoraJson.JsonToStruct<PlayerUpdatedInfo>(data, "info")
                        );
                        break;
                    case "onPlayerSrcInfoChanged":
                        RtcMediaPlayerEventHandler.OnPlayerSrcInfoChanged(
                            AgoraJson.JsonToStruct<SrcInfo>(data, "from"),
                            AgoraJson.JsonToStruct<SrcInfo>(data, "to")
                        );
                        break;
                    case "onAudioVolumeIndication":
                        RtcMediaPlayerEventHandler.OnAudioVolumeIndication(
                            (int) AgoraJson.GetData<int>(data, "volume")
                        );
                        break;
                }   
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            });
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_EventWithBuffer_Native))]
#endif
        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer, uint length)
        {
            var byteData = new byte[length];
            if (buffer != IntPtr.Zero) Marshal.Copy(buffer, byteData, 0, (int) length);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
            CallbackObject._CallbackQueue.EnQueue(() =>
            {
#endif
                var playerId = (int) AgoraJson.GetData<int>(data, "playerId");
                switch (@event)
                {
                    case "onMetaData":
                        RtcMediaPlayerEventHandler.OnMetaData((int) AgoraJson.GetData<int>(data, "playerId"),
                            byteData, (int)length);
                        break;  
                }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            });
#endif
        }
    }
}