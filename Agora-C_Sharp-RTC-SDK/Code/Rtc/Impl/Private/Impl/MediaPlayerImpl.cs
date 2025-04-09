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

    public partial class MediaPlayerImpl
    {
        private bool _disposed = false;

        private IrisApiEnginePtr _irisApiEngine;

        private IrisRtcCApiParam _apiParam;

        private Dictionary<int, RtcEventHandlerHandle> _mediaPlayerEventHandlerHandles = new Dictionary<int, RtcEventHandlerHandle>();

        // audioFrameObserver
        private Dictionary<int, RtcEventHandlerHandle> _mediaPlayerAudioFrameObserverHandles = new Dictionary<int, RtcEventHandlerHandle>();

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

            //move this code from ReleaseEventHandler because:
            //If there are multiple mediaPlayers, one of the InitEventHandler (null) will cause the _callbackObject to be destroyed,
            //and then all remaining mediaPlayer callbacks cannot be triggered
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            MediaPlayerSourceObserverNative.CallbackObject = null;
            if (_callbackObject != null)
                _callbackObject.Release();
            _callbackObject = null;
#endif

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
            if (_callbackObject == null)
            {
                _callbackObject = new AgoraCallbackObject(identifier);
                MediaPlayerSourceObserverNative.CallbackObject = _callbackObject;
            }
#endif
            _param.Clear();
            _param.Add("playerId", playerId);
            var json = AgoraJson.ToJson(_param);
            var _mediaPlayerEventHandlerHandle = new RtcEventHandlerHandle();

            AgoraRtcNative.AllocEventHandlerHandle(ref _mediaPlayerEventHandlerHandle, MediaPlayerSourceObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _mediaPlayerEventHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_REGISTERPLAYERSOURCEOBSERVER_15621d7,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("IMEDIAPLAYER_REGISTERPLAYERSOURCEOBSERVER_15621d7 failed: " + nRet);
            }
            _mediaPlayerEventHandlerHandles.Add(playerId, _mediaPlayerEventHandlerHandle);
            arrayPtrHandle.Free();
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_UNREGISTERPLAYERSOURCEOBSERVER_15621d7,
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

            arrayPtrHandle.Free();
            return nRet;
        }

        private int SetIrisAudioFrameObserver(int playerId)
        {
            if (_mediaPlayerAudioFrameObserverHandles.ContainsKey(playerId) == true)
                return 0;

            var mediaPlayerAudioFrameObserverHandle = new RtcEventHandlerHandle();
            AgoraRtcNative.AllocEventHandlerHandle(ref mediaPlayerAudioFrameObserverHandle, AudioPcmFrameSinkNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { mediaPlayerAudioFrameObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER_89ab9b5,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);
            ;

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            _mediaPlayerAudioFrameObserverHandles.Add(playerId, mediaPlayerAudioFrameObserverHandle);
            arrayPtrHandle.Free();
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
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER_a5b510b,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }
            _mediaPlayerAudioFrameObserverHandles.Add(playerId, mediaPlayerAudioFrameObserverHandle);
            arrayPtrHandle.Free();
            return nRet;
        }

        private int UnSetIrisAudioFrameObserver(int playerId)
        {
            if (_mediaPlayerAudioFrameObserverHandles.ContainsKey(playerId) == false)
                return 0;

            var mediaPlayerAudioFrameObserverHandle = _mediaPlayerAudioFrameObserverHandles[playerId];
            IntPtr[] arrayPtr = new IntPtr[] { mediaPlayerAudioFrameObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_UNREGISTERAUDIOFRAMEOBSERVER_89ab9b5,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_UNREGISTERAUDIOFRAMEOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref mediaPlayerAudioFrameObserverHandle);
            _mediaPlayerAudioFrameObserverHandles.Remove(playerId);
            arrayPtrHandle.Free();
            return nRet;
        }

        private int SetMediaPlayerOpenWithMediaSource(int playerId, MediaSource source, bool hadProvider)
        {
            IntPtr[] arrayPtr = new IntPtr[1] { IntPtr.Zero };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
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
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_OPENWITHMEDIASOURCE_3c11499,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_OPENWITHMEDIASOURCE failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        private int UnsetMediaPlayerOpenWithMediaSource(int playerId)
        {
            if (_mediaPlayerMediaProviderHandles.ContainsKey(playerId) == false)
                return 0;

            var eventHandlerHandle = _mediaPlayerMediaProviderHandles[playerId];
            IntPtr[] arrayPtr = new IntPtr[1] { eventHandlerHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_UNOPENWITHMEDIASOURCE,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            AgoraRtcNative.FreeEventHandlerHandle(ref eventHandlerHandle);
            this._mediaPlayerMediaProviderHandles.Remove(playerId);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_UNOPENWITHMEDIASOURCE failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        private int SetIrisAudioSpectrumObserver(int playerId, int intervalInMS)
        {
            if (_mediaPlayerAudioSpectrumObserverHandles.ContainsKey(playerId) == true)
                return 0;

            var mediaPlayerAudioSpectrumObserverHandle = new RtcEventHandlerHandle();
            AgoraRtcNative.AllocEventHandlerHandle(ref mediaPlayerAudioSpectrumObserverHandle, MediaPlayerAudioSpectrumObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { mediaPlayerAudioSpectrumObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("intervalInMS", intervalInMS);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_REGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER_226bb48,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_REGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER failed: " + nRet);
            }
            _mediaPlayerAudioSpectrumObserverHandles.Add(playerId, mediaPlayerAudioSpectrumObserverHandle);
            arrayPtrHandle.Free();
            return nRet;
        }

        private int UnSetIrisAudioSpectrumObserver(int playerId)
        {
            if (_mediaPlayerAudioSpectrumObserverHandles.ContainsKey(playerId) == false)
                return 0;

            var _mediaPlayerAudioSpectrumObserverHandle = _mediaPlayerAudioSpectrumObserverHandles[playerId];
            IntPtr[] arrayPtr = new IntPtr[] { _mediaPlayerAudioSpectrumObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            _param.Clear();
            _param.Add("playerId", playerId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IMEDIAPLAYER_UNREGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER_09064ce,
                                                          json, (uint)json.Length,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("FUNC_MEDIAPLAYER_UNREGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _mediaPlayerAudioSpectrumObserverHandle);
            _mediaPlayerAudioSpectrumObserverHandles.Remove(playerId);
            arrayPtrHandle.Free();
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
                                                         AgoraApiType.IRTCENGINE_CREATEMEDIAPLAYER,
                                                         "", 0, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int DestroyMediaPlayer(int playerId)
        {
            _param.Clear();
            _param.Add("playerId", playerId);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                                                         AgoraApiType.IRTCENGINE_DESTROYMEDIAPLAYER_328a49b,
                                                         jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int OpenWithMediaSource(int playerId, MediaSource source)
        {
            UnsetMediaPlayerOpenWithMediaSource(playerId);
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
    }
}