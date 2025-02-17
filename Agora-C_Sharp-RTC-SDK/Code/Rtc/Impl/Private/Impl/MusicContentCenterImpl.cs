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
        private IrisRtcCApiParam _apiParam;

        private RtcEventHandlerHandle _musicContentCenterHandlerHandle = new RtcEventHandlerHandle();
        private RtcEventHandlerHandle _scoreEventHandlerHandle = new RtcEventHandlerHandle();
        private RtcEventHandlerHandle _audioFrameHandlerHandle = new RtcEventHandlerHandle();

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        private AgoraCallbackObject _callbackObject;
        private AgoraCallbackObject _scoreCallbackObject;
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
                UnSetScoreEventHandler();
                UnSetIrisAudioFrameObserver();
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
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_REGISTEREVENTHANDLER,
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
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_UNREGISTEREVENTHANDLER,
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

        public void SetScoreEventHandler()
        {
            if (this._scoreEventHandlerHandle.handle != IntPtr.Zero)
                return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (_scoreCallbackObject == null)
            {
                _scoreCallbackObject = new AgoraCallbackObject("AgoraScore" + GetHashCode());
                ScoreEventHandlerNative.CallbackObject = _scoreCallbackObject;
            }
#endif

            AgoraRtcNative.AllocEventHandlerHandle(ref _scoreEventHandlerHandle, ScoreEventHandlerNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _scoreEventHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_REGISTERSCOREEVENTHANDLER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MUSICCONTENTCENTER_REGISTERSCOREEVENTHANDLER failed: " + nRet);
            }
            arrayPtrHandle.Free();
        }

        public void UnSetScoreEventHandler()
        {
            if (this._scoreEventHandlerHandle.handle == IntPtr.Zero)
                return;

            IntPtr[] arrayPtr = new IntPtr[] { _scoreEventHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_UNREGISTERSCOREEVENTHANDLER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MUSICCONTENTCENTER_UNREGISTEREVENTHANDLER failed: " + nRet);
            }
            AgoraRtcNative.FreeEventHandlerHandle(ref _scoreEventHandlerHandle);

            /// You must release callbackObject after you release eventhandler.
            /// Otherwise may be agcallback and unity main loop can will both access callback object. make crash
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            ScoreEventHandlerNative.CallbackObject = null;
            if (_scoreCallbackObject != null)
                _scoreCallbackObject.Release();
            _scoreCallbackObject = null;
#endif
            arrayPtrHandle.Free();
        }

        private int SetIrisAudioFrameObserver(AUDIO_FRAME_POSITION position)
        {
            if (_audioFrameHandlerHandle.handle != IntPtr.Zero)
                return 0;

            _param.Clear();
            _param.Add("position", position);
            var json = AgoraJson.ToJson(_param);

            AgoraRtcNative.AllocEventHandlerHandle(ref _audioFrameHandlerHandle, AudioFrameObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _audioFrameHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMUSICCONTENTCENTER_REGISTERAUDIOFRAMEOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("IMUSICCONTENTCENTER_REGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        private int UnSetIrisAudioFrameObserver()
        {
            if (_audioFrameHandlerHandle.handle == IntPtr.Zero)
                return 0;

            IntPtr[] arrayPtr = new IntPtr[] { _audioFrameHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMUSICCONTENTCENTER_UNREGISTERAUDIOFRAMEOBSERVER,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("IMUSICCONTENTCENTER_UNREGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _audioFrameHandlerHandle);
            arrayPtrHandle.Free();
            return nRet;
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

        public int RegisterScoreEventHandler(IScoreEventHandler scoreEventHandler)
        {
            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            ScoreEventHandlerNative.SetScoreEventHandler(scoreEventHandler);
            SetScoreEventHandler();
            return 0;
        }

        public int UnregisterScoreEventHandler()
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            UnSetScoreEventHandler();
            ScoreEventHandlerNative.SetScoreEventHandler(null);
            return 0;
        }

        public int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            // you must Set Observer first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            AudioFrameObserverNative.SetAudioFrameObserverAndMode(audioFrameObserver, mode);
            int ret = SetIrisAudioFrameObserver(position);

            return ret;
        }

        public int UnregisterAudioFrameObserver()
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int nRet = UnSetIrisAudioFrameObserver();
            AudioFrameObserverNative.SetAudioFrameObserverAndMode(null, OBSERVER_MODE.INTPTR);
            return nRet;
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
                _irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_DESTROYMUSICPLAYER,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        #region terra IMusicContentCenter
        public int Initialize(MusicContentCenterConfiguration configuration)
        {
            _param.Clear();
            _param.Add("configuration", configuration);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_INITIALIZE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int AddVendor(MusicContentCenterVendorID vendorId, string jsonVendorConfig)
        {
            _param.Clear();
            _param.Add("vendorId", vendorId);
            _param.Add("jsonVendorConfig", jsonVendorConfig);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_ADDVENDOR,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int RemoveVendor(MusicContentCenterVendorID vendorId)
        {
            _param.Clear();
            _param.Add("vendorId", vendorId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_REMOVEVENDOR,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int RenewToken(MusicContentCenterVendorID vendorID, string token)
        {
            _param.Clear();
            _param.Add("vendorID", vendorID);
            _param.Add("token", token);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_RENEWTOKEN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetMusicCharts(ref string requestId)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETMUSICCHARTS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            return result;
        }

        public int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "")
        {
            _param.Clear();
            _param.Add("musicChartId", musicChartId);
            _param.Add("page", page);
            _param.Add("pageSize", pageSize);
            _param.Add("jsonOption", jsonOption);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETMUSICCOLLECTIONBYMUSICCHARTID,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            return result;
        }

        public int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            _param.Clear();
            _param.Add("keyWord", keyWord);
            _param.Add("page", page);
            _param.Add("pageSize", pageSize);
            _param.Add("jsonOption", jsonOption);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_SEARCHMUSIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            return result;
        }

        public int Preload(ref string requestId, long internalSongCode)
        {
            _param.Clear();
            _param.Add("internalSongCode", internalSongCode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_PRELOAD,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            return result;
        }

        public int SetScoreLevel(ScoreLevel level)
        {
            _param.Clear();
            _param.Add("level", level);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_SETSCORELEVEL,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartScore(long internalSongCode)
        {
            _param.Clear();
            _param.Add("internalSongCode", internalSongCode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_STARTSCORE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopScore()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_STOPSCORE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PauseScore()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_PAUSESCORE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int ResumeScore()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_RESUMESCORE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetCumulativeScoreData(ref CumulativeScoreData cumulativeScoreData)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETCUMULATIVESCOREDATA,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                cumulativeScoreData = AgoraJson.JsonToStruct<CumulativeScoreData>(_apiParam.Result, "cumulativeScoreData");
            }
            return result;
        }

        public int RemoveCache(long internalSongCode)
        {
            _param.Clear();
            _param.Add("internalSongCode", internalSongCode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_REMOVECACHE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize)
        {
            _param.Clear();
            _param.Add("cacheInfoSize", cacheInfoSize);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETCACHES,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                cacheInfo = AgoraJson.JsonToStructArray<MusicCacheInfo>(_apiParam.Result, "cacheInfo");
                cacheInfoSize = (int)AgoraJson.GetData<int>(_apiParam.Result, "cacheInfoSize");
            }
            return result;
        }

        public int IsPreloaded(long internalSongCode)
        {
            _param.Clear();
            _param.Add("internalSongCode", internalSongCode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_ISPRELOADED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetLyric(ref string requestId, long internalSongCode, int lyricType = 0)
        {
            _param.Clear();
            _param.Add("internalSongCode", internalSongCode);
            _param.Add("lyricType", lyricType);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETLYRIC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            return result;
        }

        public int GetLyricInfo(ref string requestId, long internalSongCode)
        {
            _param.Clear();
            _param.Add("internalSongCode", internalSongCode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETLYRICINFO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            return result;
        }

        public int GetSongSimpleInfo(ref string requestId, long internalSongCode)
        {
            _param.Clear();
            _param.Add("internalSongCode", internalSongCode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETSONGSIMPLEINFO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                requestId = (string)AgoraJson.GetData<string>(_apiParam.Result, "requestId");
            }
            return result;
        }

        public int GetInternalSongCode(MusicContentCenterVendorID vendorId, string songCode, string jsonOption, ref long internalSongCode)
        {
            _param.Clear();
            _param.Add("vendorId", vendorId);
            _param.Add("songCode", songCode);
            _param.Add("jsonOption", jsonOption);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MUSICCONTENTCENTER_GETINTERNALSONGCODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                internalSongCode = (long)AgoraJson.GetData<long>(_apiParam.Result, "internalSongCode");
            }
            return result;
        }
        #endregion terra IMusicContentCenter
    }
}