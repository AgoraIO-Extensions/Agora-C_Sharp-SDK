using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using IrisMusicCenterEventHandlerHandle = IntPtr;
    using IrisMusicCenterEventHandlerMarsh = IntPtr;

    public partial class MusicContentCenterImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private MediaPlayerImpl _mediaPlayerImpl;
        private MusicPlayerImpl _musicPlayerImpl;
        private IrisRtcCApiParam _apiParam;

        private RtcEventHandlerHandle _musicContentCenterHandlerHandle = new RtcEventHandlerHandle();
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        private AgoraCallbackObject _callbackObject;
#endif

        internal MusicContentCenterImpl(IrisApiEnginePtr irisApiEngine, MediaPlayerImpl impl)
        {
            _apiParam = new IrisRtcCApiParam();
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
            if (_disposed)
                return;

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

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (_callbackObject == null)
            {
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                MusicContentCenterEventHandlerNative.CallbackObject = _callbackObject;
            }
#endif

            AgoraRtcNative.AllocEventHandlerHandle(ref _musicContentCenterHandlerHandle, MusicContentCenterEventHandlerNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _musicContentCenterHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMUSICCONTENTCENTER_REGISTEREVENTHANDLER_ae49451,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MUSICCONTENTCENTER_REGISTEREVENTHANDLER failed: " + nRet);
            }
            arrayPtrHandle.Free();

        }

        private void UnSetEventHandler()
        {
            if (this._musicContentCenterHandlerHandle.handle == IntPtr.Zero)
                return;

            IntPtr[] arrayPtr = new IntPtr[] { _musicContentCenterHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMUSICCONTENTCENTER_UNREGISTEREVENTHANDLER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MUSICCONTENTCENTER_UNREGISTEREVENTHANDLER failed: " + nRet);
            }
            AgoraRtcNative.FreeEventHandlerHandle(ref _musicContentCenterHandlerHandle);

            /// You must release callbackObject after you release eventhandler.
            /// Otherwise may be agcallback and unity main loop can will both access callback object. make crash
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            MusicContentCenterEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null)
                _callbackObject.Release();
            _callbackObject = null;
#endif
            arrayPtrHandle.Free();
        }

        public int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler)
        {
            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger

            MusicContentCenterEventHandlerNative.SetMusicContentCenterEventHandler(eventHandler);
            SetEventHandler();
            return 0;
        }

        public int UnregisterEventHandler()
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            UnSetEventHandler();
            MusicContentCenterEventHandlerNative.SetMusicContentCenterEventHandler(null);
            return 0;
        }

        public IMusicPlayer CreateMusicPlayer()
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.IMUSICCONTENTCENTER_CREATEMUSICPLAYER,
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
                if (playId < 0)
                {
                    return null;
                }
                var musicPlayer = new MusicPlayer(this._musicPlayerImpl, playId);
                return musicPlayer;
            }
        }

        public int DestroyMusicPlayer(IMusicPlayer player)
        {
            _param.Clear();
            _param.Add("playerId", player.GetId());

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(
                _irisApiEngine, AgoraApiType.IMUSICCONTENTCENTER_DESTROYMUSICPLAYER_876d086,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize)
        {
            _param.Clear();
            _param.Add("cacheInfoSize", cacheInfoSize);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMUSICCONTENTCENTER_GETCACHES_c4f9978,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            if (nRet == 0)
            {
                cacheInfo = (MusicCacheInfo[])AgoraJson.JsonToStructArray<MusicCacheInfo>(_apiParam.Result, "cacheInfo");
                cacheInfoSize = (int)AgoraJson.GetData<int>(_apiParam.Result, "cacheInfoSize");
            }

            return result;
        }
    }
}