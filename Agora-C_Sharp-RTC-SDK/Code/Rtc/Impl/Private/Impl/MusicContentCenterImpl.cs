using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
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
        private IrisCApiParam _apiParam;


        private EventHandlerHandle _musicContentCenterHandlerHandle = new EventHandlerHandle();
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
#endif

        internal MusicContentCenterImpl(IrisApiEnginePtr irisApiEngine, MediaPlayerImpl impl)
        {
            _apiParam = new IrisCApiParam();
            _apiParam.AllocResult();
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
            _apiParam.FreeResult();
            _disposed = true;
        }

        private void SetEventHandler()
        {
            if (this._musicContentCenterHandlerHandle.handle != IntPtr.Zero)
                return;

            AgoraUtil.AllocEventHandlerHandle(ref _musicContentCenterHandlerHandle, MusicContentCenterEventHandlerNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _musicContentCenterHandlerHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_REGISTEREVENTHANDLER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MUSICCONTENTCENTER_REGISTEREVENTHANDLER failed: " + nRet);
            }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                MusicContentCenterEventHandlerNative.CallbackObject = _callbackObject;
#endif
        }

        private void UnSetEventHandler()
        {
            if (this._musicContentCenterHandlerHandle.handle == IntPtr.Zero)
                return;

            IntPtr[] arrayPtr = new IntPtr[] { _musicContentCenterHandlerHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_UNREGISTEREVENTHANDLER,
                "{}", 2,
                Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MUSICCONTENTCENTER_UNREGISTEREVENTHANDLER failed: " + nRet);
            }
            AgoraUtil.FreeEventHandlerHandle(ref _musicContentCenterHandlerHandle);


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            MusicContentCenterEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
        }


        public IMusicPlayer CreateMusicPlayer()
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_CREATEMUSICPLAYER,
                "", 0,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (ret != 0)
            {
                return null;
            }
            else
            {
                int playId = (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
                var musicPlayer = new MusicPlayer(this._musicPlayerImpl, playId);
                return musicPlayer;
            }
        }

        public int DestroyMusicPlayer(IMusicPlayer player)
        {
            _param.Clear();
            _param.Add("playerId",player.GetId());

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_DESTROYMUSICPLAYER,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int GetLyric(ref string requestId, long songCode, int LyricType = 0)
        {
            _param.Clear();
            _param.Add("requestId", requestId);
            _param.Add("songCode", songCode);
            _param.Add("LyricType", LyricType);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETLYRIC,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);

            requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "")
        {
            _param.Clear();
            _param.Add("musicChartId", musicChartId);
            _param.Add("page", page);
            _param.Add("pageSize", pageSize);
            _param.Add("jsonOption", jsonOption);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETMUSICCOLLECTIONBYMUSICCHARTID,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);

            requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetMusicCharts(ref string requestId)
        {
            _param.Clear();
            _param.Add("requestId", requestId);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETMUSICCHARTS,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);

            requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Initialize(MusicContentCenterConfiguration configuration)
        {
            _param.Clear();
            _param.Add("configuration", configuration);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_INITIALIZE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int IsPreloaded(long songCode)
        {
            _param.Clear();
            _param.Add("songCode", songCode);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_ISPRELOADED,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int Preload(long songCode, string jsonOption)
        {
            _param.Clear();
            _param.Add("songCode", songCode);
            _param.Add("jsonOption", jsonOption);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_PRELOAD,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler)
        {
            SetEventHandler();
            MusicContentCenterEventHandlerNative.SetMusicContentCenterEventHandler(eventHandler);
            return 0;
        }

        public int UnregisterEventHandler()
        {
            UnSetEventHandler();
            MusicContentCenterEventHandlerNative.SetMusicContentCenterEventHandler(null);
            return 0;
        }

        public int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            _param.Clear();
            _param.Add("keyWord", keyWord);
            _param.Add("page", page);
            _param.Add("pageSize", pageSize);
            _param.Add("jsonOption", jsonOption);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_SEARCHMUSIC,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);

            requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int RenewToken(string token)
        {
            _param.Clear();
            _param.Add("token", token);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_RENEWTOKEN,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);



            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}