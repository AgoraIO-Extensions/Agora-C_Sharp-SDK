﻿using System;
using System.Runtime.InteropServices;

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    using IrisMusicCenterEventHandlerHandle = IntPtr;
    using IrisMusicCenterEventHandlerMarsh = IntPtr;

    public class MusicContentCenterImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private MediaPlayerImpl _mediaPlayerImpl;
        private MusicPlayerImpl _musicPlayerImpl;
        private CharAssistant _result;


        private IrisMusicCenterEventHandlerHandle _irisEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisMusicCenterEventHandlerMarsh _irisCEventHandlerNative;


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
#endif

        internal MusicContentCenterImpl(IrisApiEnginePtr irisApiEngine, MediaPlayerImpl impl)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
            _mediaPlayerImpl = impl;
            _musicPlayerImpl = new MusicPlayerImpl(irisApiEngine, _mediaPlayerImpl);
        }

        ~MusicContentCenterImpl()
        {
            Dispose(false);
        }

        internal void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                UnSetEventHandler();
            }

            _irisApiEngine = IntPtr.Zero;
            _result = new CharAssistant();
            _disposed = true;
        }

        private void SetEventHandler()
        {
            if (this._irisEventHandlerHandleNative != IntPtr.Zero)
                return;

            _irisCEventHandler = new IrisCEventHandler
            {
                OnEvent = AgoraMusicContentCenterEventHandlerNative.OnEvent,
            };

            var cEventHandlerNativeLocal = new IrisCEventHandlerNative
            {
                onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent)
            };

            _irisCEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
            Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEventHandlerNative, true);

            _irisEventHandlerHandleNative = AgoraRtcNative.SetMusicCenterEventHandler(this._irisApiEngine, _irisCEventHandlerNative);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                AgoraMusicContentCenterEventHandlerNative.CallbackObject = _callbackObject;
#endif
        }

        private void UnSetEventHandler()
        {
            if (this._irisEventHandlerHandleNative == IntPtr.Zero)
                return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            RtcEngineEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            AgoraRtcNative.UnsetMusicCenterEventHandler(_irisApiEngine, _irisEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCEventHandlerNative);
            _irisEventHandlerHandleNative = IntPtr.Zero;
        }


        public IMusicPlayer CreateMusicPlayer()
        {
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine,AgoraApiType.FUNC_MUSICCONTENTCENTER_CREATEMUSICPLAYER,
                "", 0,
                IntPtr.Zero, 0,
                out _result);

            if (ret != 0)
            {

                return null;
            }
            else
            {
                int playId = (int)AgoraJson.GetData<int>(_result.Result, "result");
                var musicPlayer = new MusicPlayer(this._musicPlayerImpl, playId);
                return musicPlayer;
            }
        }

        public int DestroyMusicPlayer(IMusicPlayer player)
        {
            var param = new
            {
                playerId = player.GetId()
              
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_DESTROYMUSICPLAYER,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public int GetLyric(string requestId, long songCode, int LyricType = 0)
        {
            var param = new {
                requestId,
                songCode,
                LyricType
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine,AgoraApiType.FUNC_MUSICCONTENTCENTER_GETLYRIC,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetMusicChart(string requestId, int musicChartType, int page, int pageSize, string jsonOption = "")
        {
            var param = new
            {
                requestId,
                musicChartType,
                page,
                pageSize,
                jsonOption
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETMUSICCHART,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetMusicCharts(string requestId)
        {
            var param = new
            {
                requestId,
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETMUSICCHARTS,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Initialize(AgoraMusicContentCenterConfiguration configuration)
        {
            var param = new
            {
                configuration,
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_INITIALIZE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int IsPreloaded(long songCode, AgoraMediaType type, string resolution)
        {
            var param = new
            {
                songCode,
                type,
                resolution
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_ISPRELOADED,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Preload(long songCode, AgoraMediaType type, string resolution)
        {
            var param = new
            {
                songCode,
                type,
                resolution
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_PRELOAD,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int RegisterEventHandler(IAgoraMusicContentCenterEventHandler eventHandler)
        {
            SetEventHandler();
            AgoraMusicContentCenterEventHandlerNative.EventHandler = eventHandler;
            return 0;
        }

        public int UnregisterEventHandler()
        {
            UnSetEventHandler();
            AgoraMusicContentCenterEventHandlerNative.EventHandler = null;
            return 0;
        }

        public int SearchSong(string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            var param = new
            {
                requestId,
                keyWord,
                page,
                pageSize,
                jsonOption
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_SEARCHSONG,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

      
    }
}
