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

    using IrisRtcMediaPlayerPtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;
    using IrisMediaPlayerCAudioFrameObserverNativeMarshal = IntPtr;
    using IrisMediaPlayerAudioFrameObserverHandleNative = IntPtr;
    using IrisMediaPlayerCVideoFrameObserverNativeMarshal = IntPtr;
    using IrisMediaPlayerVideoFrameObserverHandleNative = IntPtr;
    using IrisMediaPlayerCCustomProviderNativeMarshal = IntPtr;
    using IrisMediaPlayerCustomProviderHandleNative = IntPtr;

    public sealed class AgoraRtcMediaPlayer : IAgoraRtcMediaPlayer
    {
        private bool _disposed = false;
        private static readonly string identifier = "AgoraRtcMediaPlayer";
        private int playerId;


        private IrisRtcMediaPlayerPtr _irisRtcMediaPlayer;

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
        
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        private AgoraCallbackObject _callbackObject;
#endif

        internal AgoraRtcMediaPlayer(IrisRtcMediaPlayerPtr irisRtcMediaPlayer)
        {
            _result = new CharAssistant();
            _irisRtcMediaPlayer = irisRtcMediaPlayer;
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

            _irisRtcMediaPlayer = IntPtr.Zero;
            _result = new CharAssistant();
            
            _disposed = true;
        }
        
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override void InitEventHandler(IAgoraRtcMediaPlayerEventHandler engineEventHandler)
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
                    AgoraRtcNative.SetIrisMediaPlayerEventHandler(_irisRtcMediaPlayer, _irisCEngineEventHandlerNative);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                _callbackObject = new AgoraCallbackObject("Agora MediaPlayer");
                RtcMediaPlayerEventHandlerNative.CallbackObject = _callbackObject;
#endif
           }

           RtcMediaPlayerEventHandlerNative.RtcMediaPlayerEventHandler = engineEventHandler;
        }

        private void ReleaseEventHandler()
        {
            RtcMediaPlayerEventHandlerNative.RtcMediaPlayerEventHandler = null;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            RtcMediaPlayerEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            AgoraRtcNative.UnsetIrisMediaPlayerEventHandler(_irisRtcMediaPlayer, _irisEngineEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
            _irisEngineEventHandlerHandleNative = IntPtr.Zero;
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

        private void SetIrisAudioFrameObserver()
        {
            // var param = new { };
            // if (_irisMediaPlayerAudioFrameObserverHandleNative != IntPtr.Zero) return;
            //
            // _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver
            // {
            //     OnFrame = AgoraRtcMediaPlayerAudioFrameObserverNative.OnFrame
            // };
            //
            // var irisMediaPlayerCAudioFrameObserverNativeLocal = new IrisMediaPlayerCAudioFrameObserverNative
            // {
            //     onFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioFrameObserver.OnFrame)
            // };
            //
            // _irisMediaPlayerCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioFrameObserverNativeLocal));
            // Marshal.StructureToPtr(irisMediaPlayerCAudioFrameObserverNativeLocal, _irisMediaPlayerCAudioFrameObserverNative, true);
            // _irisMediaPlayerAudioFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerAudioFrameObserver(
            //     _irisRtcMediaPlayer,
            //     _irisMediaPlayerCAudioFrameObserverNative, JsonMapper.ToJson(param)
            // );
        }

        private void SetIrisAudioFrameObserverWithMode(RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            // var param = new { mode };
            // if (_irisMediaPlayerAudioFrameObserverHandleNative != IntPtr.Zero) return;
            //
            // _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver
            // {
            //     OnFrame = AgoraRtcMediaPlayerAudioFrameObserverNative.OnFrame
            // };
            //
            // var irisMediaPlayerCAudioFrameObserverNativeLocal = new IrisMediaPlayerCAudioFrameObserverNative
            // {
            //     onFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioFrameObserver.OnFrame)
            // };
            //
            // _irisMediaPlayerCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioFrameObserverNativeLocal));
            // Marshal.StructureToPtr(irisMediaPlayerCAudioFrameObserverNativeLocal, _irisMediaPlayerCAudioFrameObserverNative, true);
            // _irisMediaPlayerAudioFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerAudioFrameObserver(
            //     _irisRtcMediaPlayer,
            //     _irisMediaPlayerCAudioFrameObserverNative, JsonMapper.ToJson(param)
            // );
        }

        private void UnSetIrisAudioFrameObserver()
        {
            // var param = new { };
            // if (_irisMediaPlayerAudioFrameObserverHandleNative == IntPtr.Zero) return;
            //
            // AgoraRtcNative.UnRegisterMediaPlayerAudioFrameObserver(
            //     _irisRtcMediaPlayer,
            //     _irisMediaPlayerAudioFrameObserverHandleNative, JsonMapper.ToJson(param)
            // );
            // _irisMediaPlayerAudioFrameObserverHandleNative = IntPtr.Zero;
            // AgoraRtcMediaPlayerAudioFrameObserverNative.AudioFrameObserver = null;
            // _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver();
            // Marshal.FreeHGlobal(_irisMediaPlayerCAudioFrameObserverNative);
        }

        public override void RegisterVideoFrameObserver(IAgoraRtcMediaPlayerVideoFrameObserver observer)
        {
            SetIrisVideoFrameObserver();
            AgoraRtcMediaPlayerVideoFrameObserverNative.VideoFrameObserver = observer;
        }

        public override void UnregisterVideoFrameObserver(IAgoraRtcMediaPlayerVideoFrameObserver observer)
        {
            UnSetIrisVideoFrameObserver();
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
            //     _irisRtcMediaPlayer,
            //     _irisMediaPlayerCVideoFrameObserverNative, JsonMapper.ToJson(param)
            // );
        }

        private void UnSetIrisVideoFrameObserver()
        {
            // var param = new { };
            // if (_irisMediaPlayerVideoFrameObserverHandleNative == IntPtr.Zero) return;
            //
            // AgoraRtcNative.UnRegisterMediaPlayerVideoFrameObserver(
            //     _irisRtcMediaPlayer,
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
                _irisRtcMediaPlayer,
                _irisMediaPlayerCCustomProviderNative, JsonMapper.ToJson(param)
            );
            return ret;
        }

        public override int CreateMediaPlayer()
        {
            var param = new { };
            var playerId =  AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerCreate,
                JsonMapper.ToJson(param), out _result);
            UnityEngine.Debug.Log("playerId is: " + this.playerId);
            return playerId;
        }

        public override int DestroyMediaPlayer(int playerId)
        {
            var param = new
            {
                playerId
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerDestroyMediaPlayer,
                JsonMapper.ToJson(param), out _result);
        }

        public override int Open(int playerId, string url, Int64 startPos)
        {
            var param = new
            {
                playerId,
                url,
                startPos
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerOpen,
                JsonMapper.ToJson(param), out _result);
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
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerPlay,
                JsonMapper.ToJson(param), out _result);
        }

        public override int Pause(int playerId)
        {
            var param = new { playerId };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerPause,
                JsonMapper.ToJson(param), out _result);
        }

        public override int Stop(int playerId)
        {
            var param = new { playerId };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerStop,
                JsonMapper.ToJson(param), out _result);
        }

        public override int Resume(int playerId)
        {
            var param = new { playerId };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerResume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int Seek(int playerId, Int64 newPos)
        {
            var param = new
            {
                playerId,
                newPos
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSeek,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetDuration(int playerId, ref Int64 duration)
        {
            var param = new { playerId };
            var ret =  AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetDuration,
                JsonMapper.ToJson(param), out _result);
            if (_result.Result == null) return -99;
            duration = (long) AgoraJson.GetData<long>(_result.Result, "duration");
            return ret;
        }

        public override int GetPlayPosition(int playerId, ref Int64 pos)
        {
            var param = new { playerId };
            var ret = AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetPlayPosition,
                JsonMapper.ToJson(param), out _result);
            if (_result.Result == null) return -99;
            pos = (long) AgoraJson.GetData<long>(_result.Result, "pos");
            return ret;
        }

        public override int GetStreamCount(int playerId, ref Int64 count)
        {
            var param = new { playerId };
            var ret = AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetStreamCount,
                JsonMapper.ToJson(param), out _result);
            if (_result.Result == null) return -99;
            count = (long) AgoraJson.GetData<long>(_result.Result, "count");
            return ret;
        }

        public override int GetStreamInfo(int playerId, Int64 index, out PlayerStreamInfo info)
        {
            var param = new
            {
                playerId,
                index
            };
            var ret = AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetStreamInfo,
                JsonMapper.ToJson(param), out _result);
            info = _result.Result.Length == 0 ? new PlayerStreamInfo() : AgoraJson.JsonToStruct<PlayerStreamInfo>(_result.Result);
            return ret;
        }

        public override int SetLoopCount(int playerId, int loopCount)
        {
            var param = new
            {
                playerId,
                loopCount
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetLoopCount,
                JsonMapper.ToJson(param), out _result);
        }

        public override int MuteAudio(int playerId, bool audio_mute)
        {
            var param = new
            {
                playerId,
                audio_mute
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerMuteAudio,
                JsonMapper.ToJson(param), out _result);
        }

        public override bool IsAudioMuted(int playerId)
        {
            var param = new { playerId };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerIsAudioMuted,
                JsonMapper.ToJson(param), out _result) == 0 ? false : true;
        }

        public override int MuteVideo(int playerId, bool video_mute)
        {
            var param = new
            {
                playerId,
                video_mute
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerMuteVideo,
                JsonMapper.ToJson(param), out _result);
        }

        public override bool IsVideoMuted(int playerId)
        {
            var param = new { playerId };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerIsVideoMuted,
                JsonMapper.ToJson(param), out _result) == 0 ? false : true;
        }

        public override int SetPlaybackSpeed(int playerId, MEDIA_PLAYER_PLAYBACK_SPEED speed)
        {
            var param = new
            {
                playerId,
                speed
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetPlaybackSpeed,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SelectAudioTrack(int playerId, int index)
        {
            var param = new
            {
                playerId,
                index
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSelectAudioTrack,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetPlayerOption(int playerId, string key, int value)
        {
            var param = new
            {
                playerId,
                key,
                value
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetPlayerOption,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetPlayerOption(int playerId, string key, string value)
        {
            var param = new
            {
                playerId,
                key,
                value
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetPlayerOption,
                JsonMapper.ToJson(param), out _result);
        }

        public override int TakeScreenshot(int playerId, string filename)
        {
            var param = new
            {
                playerId,
                filename
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerTakeScreenshot,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SelectInternalSubtitle(int playerId, int index)
        {
            var param = new
            {
                playerId,
                index
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSelectInternalSubtitle,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetExternalSubtitle(int playerId, string url)
        {
            var param = new
            {
                playerId,
                url
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetExternalSubtitle,
                JsonMapper.ToJson(param), out _result);
        }

        public override MEDIA_PLAYER_STATE GetState(int playerId)
        {
            var param = new { playerId };
            return (MEDIA_PLAYER_STATE) AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetState,
                JsonMapper.ToJson(param), out _result);
        }

        public override int Mute(int playerId, bool mute)
        {
            var param = new
            {
                playerId,
                mute
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerMute,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetMute(int playerId, ref bool mute)
        {
            var param = new { playerId };
            var ret = AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetMute,
                JsonMapper.ToJson(param), out _result);
            if (_result.Result == null) return -99;
            mute = (bool) AgoraJson.GetData<bool>(_result.Result, "mute");
            return ret;
            
        }

        public override int AdjustPlayoutVolume(int playerId, int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerAdjustPlayoutVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetPlayoutVolume(int playerId, ref int volume)
        {
            var param = new { playerId };
            var ret = AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetPlayoutVolume,
                JsonMapper.ToJson(param), out _result);
            if (_result.Result == null) return -99;
            volume = (int) AgoraJson.GetData<int>(_result.Result, "volume");
            return ret;
        }

        public override int AdjustPublishSignalVolume(int playerId, int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerAdjustPublishSignalVolume,
                JsonMapper.ToJson(param), out _result);
        }

        public override int GetPublishSignalVolume(int playerId, ref int volume)
        {
            var param = new
            {
                playerId,
                volume
            };
            var ret = AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetPublishSignalVolume,
                JsonMapper.ToJson(param), out _result);
            if (_result.Result == null) return -99;
            volume = (int) AgoraJson.GetData<int>(_result.Result, "volume");
            return ret;
        }

        public override int SetView(int playerId)
        {
            var param = new
            {
                playerId
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetView,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode)
        {
            var param = new
            {
                playerId,
                renderMode
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetRenderMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode)
        {
            var param = new
            {
                playerId,
                mode
            };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetAudioDualMonoMode,
                JsonMapper.ToJson(param), out _result);
        }

        public override string GetPlayerSdkVersion(int playerId)
        {
            var param = new { playerId };
            AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetPlayerSdkVersion,
                JsonMapper.ToJson(param), out _result);
            return _result.Result;
        }

        public override string GetPlaySrc(int playerId)
        {
            var param = new { playerId };
            AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetPlaySrc,
                JsonMapper.ToJson(param), out _result);
            return _result.Result;
        }

        public override int SetAudioPitch(int pitch)
        {
            var param = new { pitch };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetAudioPitch,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params)
        {
            var param = new { playerId, spatial_audio_params };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSetSpatialAudioParams,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int OpenWithAgoraCDNSrc(string src, Int64 startPos)
        {
            var param = new { src, startPos };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerOpenWithAgoraCDNSrc,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int GetAgoraCDNLineCount()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetAgoraCDNLineCount,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int SwitchAgoraCDNLineByIndex(int index)
        {
            var param = new { index };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSwitchAgoraCDNLineByIndex,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int GetCurrentAgoraCDNIndex()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerGetCurrentAgoraCDNIndex,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int EnableAutoSwitchAgoraCDN(bool enable)
        {
            var param = new { enable };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerEnableAutoSwitchAgoraCDN,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int RenewAgoraCDNSrcToken(string token, Int64 ts)
        {
            var param = new { token, ts };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerRenewAgoraCDNSrcToken,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            var param = new { src, syncPts };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSwitchAgoraCDNSrc,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int SwitchSrc(string src, bool syncPts = true)
        {
            var param = new { src, syncPts };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerSwitchSrc,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int PreloadSrc(string src, Int64 startPos)
        {
            var param = new { src, startPos };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerPreloadSrc,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int PlayPreloadedSrc(string src)
        {
            var param = new { src };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerPlayPreloadedSrc,
                JsonMapper.ToJson(param), out _result); 
        }

        public override int UnloadSrc(string src)
        {
            var param = new { src };
            return AgoraRtcNative.CallIrisMediaPlayerApi(_irisRtcMediaPlayer, 
                ApiTypeMediaPlayer.kMediaPlayerUnloadSrc,
                JsonMapper.ToJson(param), out _result); 
        }
    }


    internal static class RtcMediaPlayerEventHandlerNative
    {
        internal static IAgoraRtcMediaPlayerEventHandler RtcMediaPlayerEventHandler = null;
        internal static AgoraCallbackObject CallbackObject = null;

        [MonoPInvokeCallback(typeof(Func_Event_Native))]
        internal static void OnEvent(string @event, string data)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            switch(@event)
            {
                case "onPlayerSourceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnPlayerSourceStateChanged(
                                (int) AgoraJson.GetData<int>(data, "playerId"),
                                (MEDIA_PLAYER_STATE) AgoraJson.GetData<int>(data, "state"),
                                (MEDIA_PLAYER_ERROR) AgoraJson.GetData<int>(data, "ec")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onPositionChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnPositionChanged(
                                (int) AgoraJson.GetData<int>(data, "playerId"),
                                (Int64) AgoraJson.GetData<Int64>(data, "position")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onPlayerEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnPlayerEvent(
                                (int) AgoraJson.GetData<int>(data, "playerId"),
                                (MEDIA_PLAYER_EVENT) AgoraJson.GetData<int>(data, "event"),
                                (Int64) AgoraJson.GetData<Int64>(data, "elapsedTime"),
                                (string) AgoraJson.GetData<string>(data, "message")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onPlayBufferUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null != null)
                        {
                            RtcMediaPlayerEventHandler.OnPlayBufferUpdated(
                                (int) AgoraJson.GetData<int>(data, "playerId"),
                                (Int64) AgoraJson.GetData<Int64>(data, "playCachedBuffer")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onCompleted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnCompleted(
                                (int) AgoraJson.GetData<int>(data, "playerId")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAgoraCDNTokenWillExpire":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnAgoraCDNTokenWillExpire();
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onPlayerInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnPlayerInfoUpdated(
                                AgoraJson.JsonToStruct<PlayerUpdatedInfo>(data, "info")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onPlayerSrcInfoChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnPlayerSrcInfoChanged(
                                AgoraJson.JsonToStruct<SrcInfo>(data, "from"),
                                AgoraJson.JsonToStruct<SrcInfo>(data, "to")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;
                case "onAudioVolumeIndication":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnAudioVolumeIndication(
                                (int) AgoraJson.GetData<int>(data, "volume")
                            );
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;

            }
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
#endif
            var playerId = (int) AgoraJson.GetData<int>(data, "playerId");
            switch (@event)
            {
                case "onMetaData":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler != null)
                        {
                            RtcMediaPlayerEventHandler.OnMetaData((int) AgoraJson.GetData<int>(data, "playerId"),
                                byteData, (int)length);
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                    });
#endif
                    break;  
            }
        }
    }
}