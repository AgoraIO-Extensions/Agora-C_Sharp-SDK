using System;
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
                OnEvent = MusicContentCenterEventHandlerNative.OnEvent,
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
                MusicContentCenterEventHandlerNative.CallbackObject = _callbackObject;
#endif
        }

        private void UnSetEventHandler()
        {
            if (this._irisEventHandlerHandleNative == IntPtr.Zero)
                return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            MusicContentCenterEventHandlerNative.CallbackObject = null;
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
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_CREATEMUSICPLAYER,
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


        public int GetLyric(ref string requestId, long songCode, int LyricType = 0)
        {
            var param = new
            {
                requestId,
                songCode,
                LyricType
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETLYRIC,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);

            requestId = (string)AgoraJson.GetData<string>(_result.Result, "requestId");

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "")
        {
            var param = new
            {
                musicChartId,
                page,
                pageSize,
                jsonOption
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETMUSICCOLLECTIONBYMUSICCHARTID,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);

            requestId = (string)AgoraJson.GetData<string>(_result.Result, "requestId");

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetMusicCharts(ref string requestId)
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

            requestId = (string)AgoraJson.GetData<string>(_result.Result, "requestId");

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Initialize(MusicContentCenterConfiguration configuration)
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

        public int IsPreloaded(long songCode)
        {
            var param = new
            {
                songCode
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_ISPRELOADED,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Preload(long songCode, string jsonOption)
        {
            var param = new
            {
                songCode,
                jsonOption
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_PRELOAD,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler)
        {
            SetEventHandler();
            MusicContentCenterEventHandlerNative.EventHandler = eventHandler;
            return 0;
        }

        public int UnregisterEventHandler()
        {
            UnSetEventHandler();
            MusicContentCenterEventHandlerNative.EventHandler = null;
            return 0;
        }

        public int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            var param = new
            {
                keyWord,
                page,
                pageSize,
                jsonOption
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_SEARCHMUSIC,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);

            requestId = (string)AgoraJson.GetData<string>(_result.Result, "requestId");

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }


        public int RemoveCache(Int64 songCode)
        {
            var param = new
            {
                songCode
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_REMOVECACHE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);


            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetCaches(ref MusicCacheInfo[] cacheInfo, ref uint cacheInfoSize)
        {
            var param = new
            {

            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_REMOVECACHE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);

            if (ret == 0)
            {
                cacheInfo = AgoraJson.JsonToStructArray<MusicCacheInfo>(_result.Result, "cacheInfo");
                cacheInfoSize = (uint)AgoraJson.GetData<uint>(_result.Result, "cacheInfoSize");
            }
            else
            {
                cacheInfo = new MusicCacheInfo[0];
                cacheInfoSize = 0;
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }



        public int RenewToken(string token)
        {
            var param = new
            {
                token
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_RENEWTOKEN,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }
    }
}