using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    // get from alloc, need to free
    using IrisEventHandlerMarshal = IntPtr;
    // get from C++, no need to free
    using IrisEventHandlerHandle = IntPtr;

    using IrisApiEnginePtr = IntPtr;
    using view_t = UInt64;

    internal class MediaPlayerImpl
    {
        private bool _disposed = false;

        private IrisApiEnginePtr _irisApiEngine;

        private IrisRtcCApiParam _apiParam;

        private Dictionary<int, RtcEventHandlerHandle> _mediaPlayerEventHandlerHandles = new Dictionary<int, RtcEventHandlerHandle>();

        // audioFrameObserver
        private Dictionary<int, RtcEventHandlerHandle> _mediaPlayerAudioFrameObserverHandles = new Dictionary<int, RtcEventHandlerHandle>();

        // openWithCustomSource
        private Dictionary<int, RtcEventHandlerHandle> _mediaPlayerCustomProviderHandles = new Dictionary<int, RtcEventHandlerHandle>();

        // openWithMediaSource
        private Dictionary<int, RtcEventHandlerHandle> _mediaPlayerMediaProviderHandles = new Dictionary<int, RtcEventHandlerHandle>();

        // AudioSpectrumObserver
        private Dictionary<int, RtcEventHandlerHandle> _mediaPlayerAudioSpectrumObserverHandles = new Dictionary<int, RtcEventHandlerHandle>();

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        private AgoraCallbackObject _callbackObject;
        private static readonly string identifier = "AgoraMediaPlayer";
#endif

        internal MediaPlayerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
        }

        ~MediaPlayerImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // must unset and then free. If you only free. When callback trigger. Your eventHandler will be bed address

                var keys = AgoraUtil.GetDicKeys<int, RtcEventHandlerHandle>(_mediaPlayerEventHandlerHandles);
                foreach (var playerId in keys)
                {
                    ReleaseEventHandler(playerId);
                }
                _mediaPlayerEventHandlerHandles.Clear();

                keys = AgoraUtil.GetDicKeys<int, RtcEventHandlerHandle>(_mediaPlayerAudioFrameObserverHandles);
                foreach (var playerId in keys)
                {
                    this.UnSetIrisAudioFrameObserver(playerId);
                }
                _mediaPlayerAudioFrameObserverHandles.Clear();

                keys = AgoraUtil.GetDicKeys<int, RtcEventHandlerHandle>(_mediaPlayerCustomProviderHandles);
                foreach (var playerId in keys)
                {
                    this.UnSetMediaPlayerOpenWithCustomSource(playerId);
                }
                _mediaPlayerCustomProviderHandles.Clear();

                keys = AgoraUtil.GetDicKeys<int, RtcEventHandlerHandle>(this._mediaPlayerMediaProviderHandles);
                foreach (var playerId in keys)
                {
                    this.UnsetMediaPlayerOpenWithMediaSource(playerId);
                }
                _mediaPlayerMediaProviderHandles.Clear();

                keys = AgoraUtil.GetDicKeys<int, RtcEventHandlerHandle>(this._mediaPlayerAudioSpectrumObserverHandles);
                foreach (var playerId in keys)
                {
                    this.UnSetIrisAudioSpectrumObserver(playerId);
                }
                _mediaPlayerAudioSpectrumObserverHandles.Clear();
            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private int CreateEventHandler(int playerId)
        {
            if (_mediaPlayerEventHandlerHandles.ContainsKey(playerId) == true) return 0;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            _callbackObject = new AgoraCallbackObject(identifier);
            MediaPlayerSourceObserverNative.CallbackObject = _callbackObject;
#endif
            _param.Clear();
            _param.Add("playerId", playerId);
            var json = AgoraJson.ToJson(_param);
            var _mediaPlayerEventHandlerHandle = new RtcEventHandlerHandle();

            AgoraRtcNative.AllocEventHandlerHandle(ref _mediaPlayerEventHandlerHandle, MediaPlayerSourceObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _mediaPlayerEventHandlerHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_REGISTERPLAYERSOURCEOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_REGISTERPLAYERSOURCEOBSERVER failed: " + nRet);
            }
            _mediaPlayerEventHandlerHandles.Add(playerId, _mediaPlayerEventHandlerHandle);

            return nRet;
        }

        private int ReleaseEventHandler(int playerId)
        {
            if (_mediaPlayerEventHandlerHandles.ContainsKey(playerId) == false) return 0;

            _param.Clear();
            _param.Add("playerId", playerId);
            var json = AgoraJson.ToJson(_param);

            var _mediaPlayerEventHandlerHandle = _mediaPlayerEventHandlerHandles[playerId];

            IntPtr[] arrayPtr = new IntPtr[] { _mediaPlayerEventHandlerHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_UNREGISTERPLAYERSOURCEOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_UNREGISTERPLAYERSOURCEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _mediaPlayerEventHandlerHandle);
            _mediaPlayerEventHandlerHandles.Remove(playerId);

            /// You must release callbackObject after you release eventhandler.
            /// Otherwise may be agcallback and unity main loop can will both access callback object. make crash
            MediaPlayerSourceObserverNative.RemoveSourceObserver(playerId);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            MediaPlayerSourceObserverNative.CallbackObject = null;
            if (_callbackObject != null)
                _callbackObject.Release();
            _callbackObject = null;
#endif
            return nRet;
        }

        private int SetIrisAudioFrameObserver(int playerId)
        {
            if (_mediaPlayerAudioFrameObserverHandles.ContainsKey(playerId) == true)
                return 0;

            var mediaPlayerAudioFrameObserverHandle = new RtcEventHandlerHandle();
            AgoraRtcNative.AllocEventHandlerHandle(ref mediaPlayerAudioFrameObserverHandle, AudioPcmFrameSinkNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { mediaPlayerAudioFrameObserverHandle.handle };
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);
            ;

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            _mediaPlayerAudioFrameObserverHandles.Add(playerId, mediaPlayerAudioFrameObserverHandle);
            return nRet;
        }

        private int SetIrisAudioFrameObserverWithMode(int playerId, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            if (_mediaPlayerAudioFrameObserverHandles.ContainsKey(playerId) == true)
                return 0;

            var mediaPlayerAudioFrameObserverHandle = new RtcEventHandlerHandle();
            AgoraRtcNative.AllocEventHandlerHandle(ref mediaPlayerAudioFrameObserverHandle, AudioPcmFrameSinkNative.OnEvent);

            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("mode", mode);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { mediaPlayerAudioFrameObserverHandle.handle };
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }
            _mediaPlayerAudioFrameObserverHandles.Add(playerId, mediaPlayerAudioFrameObserverHandle);
            return nRet;
        }

        private int UnSetIrisAudioFrameObserver(int playerId)
        {
            if (_mediaPlayerAudioFrameObserverHandles.ContainsKey(playerId) == false)
                return 0;

            var mediaPlayerAudioFrameObserverHandle = _mediaPlayerAudioFrameObserverHandles[playerId];
            IntPtr[] arrayPtr = new IntPtr[] { mediaPlayerAudioFrameObserverHandle.handle };
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_UNREGISTERAUDIOFRAMEOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_UNREGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref mediaPlayerAudioFrameObserverHandle);
            _mediaPlayerAudioFrameObserverHandles.Remove(playerId);
            return nRet;
        }

        private int SetMediaPlayerOpenWithCustomSource(int playerId, Int64 startPos)
        {
            if (_mediaPlayerCustomProviderHandles.ContainsKey(playerId))
                return -(int)ERROR_CODE_TYPE.ERR_ALREADY_IN_USE;

            RtcEventHandlerHandle eventHandlerHandle = new RtcEventHandlerHandle();
            AgoraRtcNative.AllocEventHandlerHandle(ref eventHandlerHandle, MediaPlayerCustomDataProviderNative.OnEvent);

            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("startPos", startPos);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { eventHandlerHandle.handle };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_OPENWITHCUSTOMSOURCE,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_OPENWITHCUSTOMSOURCE failed: " + nRet);
            }

            this._mediaPlayerCustomProviderHandles.Add(playerId, eventHandlerHandle);

            return 0;
        }

        private int UnSetMediaPlayerOpenWithCustomSource(int playerId)
        {
            if (_mediaPlayerCustomProviderHandles.ContainsKey(playerId) == false)
                return 0;

            var eventHandlerHandle = _mediaPlayerCustomProviderHandles[playerId];
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { eventHandlerHandle.handle };

            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_UNOPENWITHCUSTOMSOURCE,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            AgoraRtcNative.FreeEventHandlerHandle(ref eventHandlerHandle);
            this._mediaPlayerCustomProviderHandles.Remove(playerId);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_UNOPENWITHCUSTOMSOURCE failed: " + nRet);
            }

            return nRet;
        }

        private int SetMediaPlayerOpenWithMediaSource(int playerId, MediaSource source, bool hadProvider)
        {

            IntPtr[] arrayPtr = new IntPtr[1] { IntPtr.Zero };
            if (hadProvider)
            {
                RtcEventHandlerHandle eventHandlerHandle = new RtcEventHandlerHandle();
                AgoraRtcNative.AllocEventHandlerHandle(ref eventHandlerHandle, MediaPlayerCustomDataProviderNative.OnEvent);
                arrayPtr[0] = eventHandlerHandle.handle;
                this._mediaPlayerMediaProviderHandles.Add(playerId, eventHandlerHandle);
            }
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("source", source);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_OPENWITHMEDIASOURCE,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_OPENWITHMEDIASOURCE failed: " + nRet);
            }

            return nRet;
        }

        private int UnsetMediaPlayerOpenWithMediaSource(int playerId)
        {
            if (_mediaPlayerMediaProviderHandles.ContainsKey(playerId) == false)
                return 0;

            var eventHandlerHandle = _mediaPlayerMediaProviderHandles[playerId];
            IntPtr[] arrayPtr = new IntPtr[1] { eventHandlerHandle.handle };

            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_UNOPENWITHMEDIASOURCE,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            AgoraRtcNative.FreeEventHandlerHandle(ref eventHandlerHandle);
            this._mediaPlayerMediaProviderHandles.Remove(playerId);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_UNOPENWITHMEDIASOURCE failed: " + nRet);
            }

            return nRet;
        }

        private int SetIrisAudioSpectrumObserver(int playerId, int intervalInMS)
        {
            if (_mediaPlayerAudioSpectrumObserverHandles.ContainsKey(playerId) == true)
                return 0;

            var mediaPlayerAudioSpectrumObserverHandle = new RtcEventHandlerHandle();
            AgoraRtcNative.AllocEventHandlerHandle(ref mediaPlayerAudioSpectrumObserverHandle, MediaPlayerAudioSpectrumObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { mediaPlayerAudioSpectrumObserverHandle.handle };
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("intervalInMS", intervalInMS);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_REGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_REGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER failed: " + nRet);
            }
            _mediaPlayerAudioSpectrumObserverHandles.Add(playerId, mediaPlayerAudioSpectrumObserverHandle);

            return nRet;
        }

        private int UnSetIrisAudioSpectrumObserver(int playerId)
        {
            if (_mediaPlayerAudioSpectrumObserverHandles.ContainsKey(playerId) == false)
                return 0;

            var _mediaPlayerAudioSpectrumObserverHandle = _mediaPlayerAudioSpectrumObserverHandles[playerId];
            IntPtr[] arrayPtr = new IntPtr[] { _mediaPlayerAudioSpectrumObserverHandle.handle };
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_UNREGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_UNREGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _mediaPlayerAudioSpectrumObserverHandle);
            _mediaPlayerAudioSpectrumObserverHandles.Remove(playerId);
            return nRet;
        }

        public int InitEventHandler(int playerId, IMediaPlayerSourceObserver engineEventHandler)
        {
            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            int ret = 0;
            if (engineEventHandler == null)
            {
                MediaPlayerSourceObserverNative.RemoveSourceObserver(playerId);
                ret = ReleaseEventHandler(playerId);
            }
            else
            {
                MediaPlayerSourceObserverNative.AddSourceObserver(playerId, engineEventHandler);
                ret = CreateEventHandler(playerId);
            }
            return ret;
        }

        public int RegisterAudioFrameObserver(int playerId, IAudioPcmFrameSink observer)
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int ret = UnSetIrisAudioFrameObserver(playerId);
            AudioPcmFrameSinkNative.RemoveAudioFrameObserver(playerId);

            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            AudioPcmFrameSinkNative.AddAudioFrameObserver(playerId, observer);
            ret = SetIrisAudioFrameObserver(playerId);

            return ret;
        }

        public int RegisterAudioFrameObserver(int playerId, IAudioPcmFrameSink observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int ret = UnSetIrisAudioFrameObserver(playerId);
            AudioPcmFrameSinkNative.RemoveAudioFrameObserver(playerId);

            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            AudioPcmFrameSinkNative.AddAudioFrameObserver(playerId, observer);
            ret = SetIrisAudioFrameObserverWithMode(playerId, mode);

            return ret;
        }

        public int UnregisterAudioFrameObserver(int playerId)
        {
            int ret = UnSetIrisAudioFrameObserver(playerId);
            AudioPcmFrameSinkNative.RemoveAudioFrameObserver(playerId);
            return ret;
        }

        public int RegisterMediaPlayerAudioSpectrumObserver(int playerId, IAudioSpectrumObserver observer, int intervalInMS)
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int ret = UnSetIrisAudioSpectrumObserver(playerId);
            MediaPlayerAudioSpectrumObserverNative.RemoveAudioSpectrumObserver(playerId);

            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            MediaPlayerAudioSpectrumObserverNative.AddAudioSpectrumObserver(playerId, observer);
            ret = SetIrisAudioSpectrumObserver(playerId, intervalInMS);

            return ret;
        }

        public int UnregisterMediaPlayerAudioSpectrumObserver(int playerId)
        {
            // you must Set(null) lately. because maybe some callback will trigger when unregister,
            // you set null first, some callback will never triggered
            int ret = UnSetIrisAudioSpectrumObserver(playerId);
            MediaPlayerAudioSpectrumObserverNative.RemoveAudioSpectrumObserver(playerId);
            return ret;
        }

        public int CreateMediaPlayer()
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                                                         AgoraApiType.FUNC_RTCENGINE_CREATEMEDIAPLAYER,
                                                         "", 0, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int DestroyMediaPlayer(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                                                         AgoraApiType.FUNC_RTCENGINE_DESTROYMEDIAPLAYER,
                                                         jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int OpenWithCustomSource(int playerId, Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            if (provider == null)
            {
                AgoraLog.LogError("provide can not set as null");
                return -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            }

            UnsetMediaPlayerOpenWithMediaSource(playerId);
            UnSetMediaPlayerOpenWithCustomSource(playerId);

            // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
            // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
            // and this time you dont have observer be trigger
            MediaPlayerCustomDataProviderNative.RemoveCustomDataProvider(playerId);
            MediaPlayerCustomDataProviderNative.AddCustomDataProvider(playerId, provider);
            SetMediaPlayerOpenWithCustomSource(playerId, startPos);

            return 0;
        }

        public int OpenWithMediaSource(int playerId, MediaSource source)
        {
            UnsetMediaPlayerOpenWithMediaSource(playerId);
            UnSetMediaPlayerOpenWithCustomSource(playerId);

            var provider = source.provider;
            if (provider != null)
            {
                MediaPlayerCustomDataProviderNative.RemoveCustomDataProvider(playerId);
                MediaPlayerCustomDataProviderNative.AddCustomDataProvider(playerId, provider);
            }
            else
            {
                MediaPlayerCustomDataProviderNative.RemoveCustomDataProvider(playerId);
            }

            SetMediaPlayerOpenWithMediaSource(playerId, source, source.provider != null);

            return 0;
        }

        #region terra IMediaPlayer
        public int Open(int playerId, string url, long startPos)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("url", url);
            _param.Add("startPos", startPos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_OPEN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int Play(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_PLAY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int Pause(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_PAUSE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int Stop(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_STOP,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int Resume(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_RESUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int Seek(int playerId, long newPos)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("newPos", newPos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SEEK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioPitch(int playerId, int pitch)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("pitch", pitch);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETAUDIOPITCH,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetDuration(int playerId, ref long duration)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETDURATION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                duration = (long)AgoraJson.GetData<long>(_apiParam.Result, "duration");
            }
            return result;
        }

        public int GetPlayPosition(int playerId, ref long pos)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYPOSITION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                pos = (long)AgoraJson.GetData<long>(_apiParam.Result, "pos");
            }
            return result;
        }

        public int GetStreamCount(int playerId, ref long count)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETSTREAMCOUNT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                count = (long)AgoraJson.GetData<long>(_apiParam.Result, "count");
            }
            return result;
        }

        public int GetStreamInfo(int playerId, long index, ref PlayerStreamInfo info)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("index", index);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETSTREAMINFO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                info = AgoraJson.JsonToStruct<PlayerStreamInfo>(_apiParam.Result, "info");
            }
            return result;
        }

        public int SetLoopCount(int playerId, int loopCount)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("loopCount", loopCount);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETLOOPCOUNT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetPlaybackSpeed(int playerId, int speed)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("speed", speed);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYBACKSPEED,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SelectAudioTrack(int playerId, int index)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("index", index);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SELECTAUDIOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SelectMultiAudioTrack(int playerId, int playoutTrackIndex, int publishTrackIndex)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("playoutTrackIndex", playoutTrackIndex);
            _param.Add("publishTrackIndex", publishTrackIndex);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SELECTMULTIAUDIOTRACK,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetPlayerOption(int playerId, string key, int value)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("key", key);
            _param.Add("value", value);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYEROPTION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetPlayerOption(int playerId, string key, string value)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("key", key);
            _param.Add("value", value);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYEROPTION2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int TakeScreenshot(int playerId, string filename)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("filename", filename);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_TAKESCREENSHOT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SelectInternalSubtitle(int playerId, int index)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("index", index);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SELECTINTERNALSUBTITLE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetExternalSubtitle(int playerId, string url)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("url", url);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETEXTERNALSUBTITLE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public MEDIA_PLAYER_STATE GetState(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETSTATE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? MEDIA_PLAYER_STATE.PLAYER_STATE_FAILED : (MEDIA_PLAYER_STATE)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int Mute(int playerId, bool muted)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("muted", muted);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_MUTE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetMute(int playerId, ref bool muted)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETMUTE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                muted = (bool)AgoraJson.GetData<bool>(_apiParam.Result, "muted");
            }
            return result;
        }

        public int AdjustPlayoutVolume(int playerId, int volume)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_ADJUSTPLAYOUTVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetPlayoutVolume(int playerId, ref int volume)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYOUTVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                volume = (int)AgoraJson.GetData<int>(_apiParam.Result, "volume");
            }
            return result;
        }

        public int AdjustPublishSignalVolume(int playerId, int volume)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_ADJUSTPUBLISHSIGNALVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetPublishSignalVolume(int playerId, ref int volume)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETPUBLISHSIGNALVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                volume = (int)AgoraJson.GetData<int>(_apiParam.Result, "volume");
            }
            return result;
        }

        public int SetView(int playerId, view_t view)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("view", view);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETVIEW,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("renderMode", renderMode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETRENDERMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("mode", mode);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETAUDIODUALMONOMODE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public string GetPlayerSdkVersion(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYERSDKVERSION,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? "" : (string)AgoraJson.GetData<string>(_apiParam.Result, "result");

            return result;
        }

        public string GetPlaySrc(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYSRC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? "" : (string)AgoraJson.GetData<string>(_apiParam.Result, "result");

            return result;
        }

        public int OpenWithAgoraCDNSrc(int playerId, string src, long startPos)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("src", src);
            _param.Add("startPos", startPos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_OPENWITHAGORACDNSRC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetAgoraCDNLineCount(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETAGORACDNLINECOUNT,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SwitchAgoraCDNLineByIndex(int playerId, int index)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("index", index);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SWITCHAGORACDNLINEBYINDEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetCurrentAgoraCDNIndex(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_GETCURRENTAGORACDNINDEX,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int EnableAutoSwitchAgoraCDN(int playerId, bool enable)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("enable", enable);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_ENABLEAUTOSWITCHAGORACDN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int RenewAgoraCDNSrcToken(int playerId, string token, long ts)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("token", token);
            _param.Add("ts", ts);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_RENEWAGORACDNSRCTOKEN,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SwitchAgoraCDNSrc(int playerId, string src, bool syncPts = false)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("src", src);
            _param.Add("syncPts", syncPts);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SWITCHAGORACDNSRC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SwitchSrc(int playerId, string src, bool syncPts = true)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("src", src);
            _param.Add("syncPts", syncPts);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SWITCHSRC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PreloadSrc(int playerId, string src, long startPos)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("src", src);
            _param.Add("startPos", startPos);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_PRELOADSRC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int PlayPreloadedSrc(int playerId, string src)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("src", src);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_PLAYPRELOADEDSRC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int UnloadSrc(int playerId, string src)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("src", src);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_UNLOADSRC,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSpatialAudioParams(int playerId, SpatialAudioParams @params)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("params", @params);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETSPATIALAUDIOPARAMS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int SetSoundPositionParams(int playerId, float pan, float gain)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("pan", pan);
            _param.Add("gain", gain);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYER_SETSOUNDPOSITIONPARAMS,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }
        #endregion terra IMediaPlayer
    }
}