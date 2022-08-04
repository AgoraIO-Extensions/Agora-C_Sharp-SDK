#if UNITY_WEBGL

using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtc
{
    using IrisApiEnginePtr = System.Int32;
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

        //private CharAssistant _result;

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
            //_result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
            //CreateEventHandler();
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
                //ReleaseEventHandler();
                //UnSetIrisAudioFrameObserver();
                //UnSetIrisAudioSpectrumObserver();
            }

            _irisApiEngine = 0;
            //_result = new CharAssistant();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //        private void CreateEventHandler()
        //        {
        //            if (_irisEngineEventHandlerHandleNative == IntPtr.Zero)
        //            {
        //                _irisCEventHandler = new IrisCEventHandler
        //                {
        //                    OnEvent = MediaPlayerSourceObserverNative.OnEvent
        //                };

        //                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
        //                {
        //                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent)
        //                };

        //                _irisCEngineEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
        //                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEngineEventHandlerNative, true);
        //                _irisEngineEventHandlerHandleNative =
        //                    AgoraRtcNative.SetIrisMediaPlayerEventHandler(_irisApiEngine, _irisCEngineEventHandlerNative);

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //                _callbackObject = new AgoraCallbackObject(identifier);
        //                MediaPlayerSourceObserverNative.CallbackObject = _callbackObject;
        //#endif
        //            }
        //        }

        //        private void ReleaseEventHandler()
        //        {
        //            MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.Clear();
        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //            MediaPlayerSourceObserverNative.CallbackObject = null;
        //            if (_callbackObject != null) _callbackObject.Release();
        //            _callbackObject = null;
        //#endif
        //            AgoraRtcNative.UnsetIrisMediaPlayerEventHandler(_irisApiEngine, _irisEngineEventHandlerHandleNative);
        //            Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
        //            _irisEngineEventHandlerHandleNative = IntPtr.Zero;
        //        }



        //private void SetIrisAudioFrameObserver()
        //{
        //    var param = new { };
        //    if (_irisMediaPlayerAudioFrameObserverHandleNative != IntPtr.Zero) return;

        //    _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver
        //    {
        //        OnFrame = MediaPlayerAudioFrameObserverNative.OnFrame
        //    };

        //    var irisMediaPlayerCAudioFrameObserverNativeLocal = new IrisMediaPlayerCAudioFrameObserverNative
        //    {
        //        onFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioFrameObserver.OnFrame)
        //    };

        //    _irisMediaPlayerCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioFrameObserverNativeLocal));
        //    Marshal.StructureToPtr(irisMediaPlayerCAudioFrameObserverNativeLocal, _irisMediaPlayerCAudioFrameObserverNative, true);
        //    _irisMediaPlayerAudioFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerAudioFrameObserver(
        //        _irisApiEngine,
        //        _irisMediaPlayerCAudioFrameObserverNative, AgoraJson.ToJson(param)
        //    );
        //}

        //private void SetIrisAudioFrameObserverWithMode(RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        //{
        //    var param = new { mode };
        //    if (_irisMediaPlayerAudioFrameObserverHandleNative != IntPtr.Zero) return;

        //    _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver
        //    {
        //        OnFrame = MediaPlayerAudioFrameObserverNative.OnFrame
        //    };

        //    var irisMediaPlayerCAudioFrameObserverNativeLocal = new IrisMediaPlayerCAudioFrameObserverNative
        //    {
        //        onFrame = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioFrameObserver.OnFrame)
        //    };

        //    _irisMediaPlayerCAudioFrameObserverNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioFrameObserverNativeLocal));
        //    Marshal.StructureToPtr(irisMediaPlayerCAudioFrameObserverNativeLocal, _irisMediaPlayerCAudioFrameObserverNative, true);
        //    _irisMediaPlayerAudioFrameObserverHandleNative = AgoraRtcNative.RegisterMediaPlayerAudioFrameObserver(
        //        _irisApiEngine,
        //        _irisMediaPlayerCAudioFrameObserverNative, AgoraJson.ToJson(param)
        //    );
        //}

        //private void UnSetIrisAudioFrameObserver()
        //{
        //    var param = new { };
        //    if (_irisMediaPlayerAudioFrameObserverHandleNative == IntPtr.Zero) return;

        //    AgoraRtcNative.UnRegisterMediaPlayerAudioFrameObserver(
        //        _irisApiEngine,
        //        _irisMediaPlayerAudioFrameObserverHandleNative, AgoraJson.ToJson(param)
        //    );
        //    _irisMediaPlayerAudioFrameObserverHandleNative = IntPtr.Zero;
        //    _irisMediaPlayerCAudioFrameObserver = new IrisMediaPlayerCAudioFrameObserver();
        //    Marshal.FreeHGlobal(_irisMediaPlayerCAudioFrameObserverNative);
        //}

        //private int SetCustomSourceProvider(int playerId, Int64 startPos)
        //{
        //    var param = new { playerId, startPos };
        //    if (_irisMediaPlayerCustomProviderHandleNative != IntPtr.Zero) return -1;

        //    _irisMediaPlayerCCustomProvider = new IrisMediaPlayerCCustomProvider
        //    {
        //        OnSeek = MediaPlayerCustomDataProviderNative.OnSeek,
        //        OnReadData = MediaPlayerCustomDataProviderNative.OnReadData
        //    };

        //    var irisMediaPlayerCCustomProviderNativeLocal = new IrisMediaPlayerCCustomProviderNative
        //    {
        //        onSeek = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCCustomProvider.OnSeek),
        //        onReadData = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCCustomProvider.OnReadData)
        //    };

        //    _irisMediaPlayerCCustomProviderNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCCustomProviderNativeLocal));
        //    Marshal.StructureToPtr(irisMediaPlayerCCustomProviderNativeLocal, _irisMediaPlayerCCustomProviderNative, true);
        //    var ret = AgoraRtcNative.MediaPlayerOpenWithSource(
        //        _irisApiEngine,
        //        _irisMediaPlayerCCustomProviderNative, AgoraJson.ToJson(param)
        //    );
        //    return 0;
        //}

        //private void SetIrisAudioSpectrumObserver(int intervalInMS)
        //{
        //    var param = new { intervalInMS };
        //    if (_irisMediaPlayerCAudioSpectrumObserverNative != IntPtr.Zero) return;

        //    _irisMediaPlayerCAudioSpectrumObserver = new IrisMediaPlayerCAudioSpectrumObserver
        //    {
        //        OnLocalAudioSpectrum = AudioSpectrumObserverNative.OnLocalAudioSpectrum,
        //        OnRemoteAudioSpectrum = AudioSpectrumObserverNative.OnRemoteAudioSpectrum
        //    };

        //    var irisMediaPlayerCAudioSpectrumObserverNativeLocal = new IrisMediaPlayerCAudioSpectrumObserverNative
        //    {
        //        onLocalAudioSpectrum = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioSpectrumObserver.OnLocalAudioSpectrum),
        //        onRemoteAudioSpectrum = Marshal.GetFunctionPointerForDelegate(_irisMediaPlayerCAudioSpectrumObserver.OnRemoteAudioSpectrum)
        //    };

        //    _irisMediaPlayerCAudioSpectrumObserverHandleNative = Marshal.AllocHGlobal(Marshal.SizeOf(irisMediaPlayerCAudioSpectrumObserverNativeLocal));
        //    Marshal.StructureToPtr(irisMediaPlayerCAudioSpectrumObserverNativeLocal, _irisMediaPlayerCAudioSpectrumObserverHandleNative, true);
        //    _irisMediaPlayerCAudioSpectrumObserverNative = AgoraRtcNative.RegisterMediaPlayerAudioSpectrumObserver(
        //        _irisApiEngine,
        //        _irisMediaPlayerCAudioSpectrumObserverHandleNative, AgoraJson.ToJson(param)
        //    );
        //}

        //private void UnSetIrisAudioSpectrumObserver()
        //{
        //    var param = new { };
        //    if (_irisMediaPlayerCAudioSpectrumObserverNative == IntPtr.Zero) return;

        //    AgoraRtcNative.UnRegisterMediaPlayerAudioSpectrumObserver(
        //        _irisApiEngine,
        //        _irisMediaPlayerCAudioSpectrumObserverHandleNative, AgoraJson.ToJson(param)
        //    );
        //    _irisMediaPlayerCAudioSpectrumObserverNative = IntPtr.Zero;
        //    AudioSpectrumObserverNative.AgoraRtcAudioSpectrumObserver = null;
        //    _irisMediaPlayerCAudioSpectrumObserver = new IrisMediaPlayerCAudioSpectrumObserver();
        //    Marshal.FreeHGlobal(_irisMediaPlayerCAudioSpectrumObserverHandleNative);
        //}

        public void InitEventHandler(int playerId, IMediaPlayerSourceObserver engineEventHandler)
        {
            AgoraLog.LogWarning("InitEventHandler not support in this platform");
            //if (!MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.ContainsKey(playerId))
            //{
            //    MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.Add(playerId, engineEventHandler);
            //}

            //if (engineEventHandler == null && MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.ContainsKey(playerId))
            //{
            //    MediaPlayerSourceObserverNative.RtcMediaPlayerEventHandlerDic.Remove(playerId);
            //}
        }

        public void RegisterAudioFrameObserver(int playerId, IMediaPlayerAudioFrameObserver observer)
        {

            AgoraLog.LogWarning("RegisterAudioFrameObserver not support in this platform");
            //SetIrisAudioFrameObserver();
            //if (!MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.ContainsKey(playerId))
            //{
            //    MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.Add(playerId, observer);
            //}
        }

        public void RegisterAudioFrameObserver(int playerId, IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            AgoraLog.LogWarning("RegisterAudioFrameObserver not support in this platform");
            //if (!MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.ContainsKey(playerId))
            //{
            //    MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.Add(playerId, observer);
            //}
        }

        public void UnregisterAudioFrameObserver(int playerId)
        {
            AgoraLog.LogWarning("UnregisterAudioFrameObserver not support in this platform");
            //if (MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.ContainsKey(playerId))
            //{
            //    MediaPlayerAudioFrameObserverNative.AudioFrameObserverDic.Remove(playerId);
            //}
            //UnSetIrisAudioFrameObserver();
        }

        public void RegisterMediaPlayerAudioSpectrumObserver(int playerId, IAudioSpectrumObserver observer, int intervalInMS)
        {
            AgoraLog.LogWarning("RegisterMediaPlayerAudioSpectrumObserver not support in this platform");
            //SetIrisAudioSpectrumObserver(intervalInMS);
            //if (!AudioSpectrumObserverNative.AgoraRtcAudioSpectrumObserverDic.ContainsKey(playerId))
            //{
            //    AudioSpectrumObserverNative.AgoraRtcAudioSpectrumObserverDic.Add(playerId, observer);
            //}
        }

        public void UnregisterMediaPlayerAudioSpectrumObserver()
        {
            AgoraLog.LogWarning("UnregisterMediaPlayerAudioSpectrumObserver not support in this platform");

            //UnSetIrisAudioSpectrumObserver();
        }

        public int CreateMediaPlayer()
        {
            AgoraLog.LogWarning("UnregisterMediaPlayerAudioSpectrumObserver not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_RTCENGINE_CREATEMEDIAPLAYER,
            //    "{}", 2, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int DestroyMediaPlayer(int playerId)
        {
            AgoraLog.LogWarning("DestroyMediaPlayer not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_RTCENGINE_DESTROYMEDIAPLAYER,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int Open(int playerId, string url, Int64 startPos)
        {
            AgoraLog.LogWarning("Open not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    url,
            //    startPos
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_OPEN,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int OpenWithCustomSource(int playerId, Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            //var ret = SetCustomSourceProvider(playerId, startPos);
            //MediaPlayerCustomDataProviderNative.CustomDataProvider = provider;
            AgoraLog.LogWarning("OpenWithCustomSource not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
        }

        public int Play(int playerId)
        {
            AgoraLog.LogWarning("Play not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_PLAY,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int Pause(int playerId)
        {
            AgoraLog.LogWarning("Pause not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_PAUSE,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int Stop(int playerId)
        {
            AgoraLog.LogWarning("Stop not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_STOP,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int Resume(int playerId)
        {
            AgoraLog.LogWarning("Resume not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_RESUME,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int Seek(int playerId, Int64 newPos)
        {
            AgoraLog.LogWarning("Seek not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    newPos
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SEEK,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetDuration(int playerId, ref Int64 duration)
        {
            AgoraLog.LogWarning("GetDuration not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETDURATION,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //duration = (Int64)AgoraJson.GetData<Int64>(result, "duration");
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetPlayPosition(int playerId, ref Int64 pos)
        {
            AgoraLog.LogWarning("GetPlayPosition not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYPOSITION,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //pos = (Int64)AgoraJson.GetData<Int64>(result, "pos");
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetStreamCount(int playerId, ref Int64 count)
        {
            AgoraLog.LogWarning("GetStreamCount not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;

            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETSTREAMCOUNT,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //count = (Int64)AgoraJson.GetData<Int64>(result, "count");
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetStreamInfo(int playerId, Int64 index, ref PlayerStreamInfo info)
        {
            AgoraLog.LogWarning("GetStreamInfo not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    index
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETSTREAMINFO,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //info = ret != 0 ? new PlayerStreamInfo() : AgoraJson.JsonToStruct<PlayerStreamInfo>(result, "info");
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetLoopCount(int playerId, int loopCount)
        {
            AgoraLog.LogWarning("SetLoopCount not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    loopCount
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETLOOPCOUNT,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int MuteAudio(int playerId, bool audio_mute)
        {
            AgoraLog.LogWarning("SetLoopCount not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    audio_mute
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_MUTEAUDIO,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public bool IsAudioMuted(int playerId)
        {
            AgoraLog.LogWarning("IsAudioMuted not support in this platform");
            return false;
            //TODO CHECK

            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_ISAUDIOMUTED,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (bool)AgoraJson.GetData<bool>(result, "result");
        }

        public int MuteVideo(int playerId, bool video_mute)
        {
            AgoraLog.LogWarning("MuteVideo not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    video_mute
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_MUTEVIDEO,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public bool IsVideoMuted(int playerId)
        {
            AgoraLog.LogWarning("IsVideoMuted not support in this platform");
            return false;
            //TODO CHECK
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_ISVIDEOMUTED,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (bool)AgoraJson.GetData<bool>(result, "result");
        }

        public int SetPlaybackSpeed(int playerId, int speed)
        {
            AgoraLog.LogWarning("SetPlaybackSpeed not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    speed
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYBACKSPEED,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SelectAudioTrack(int playerId, int index)
        {
            AgoraLog.LogWarning("SelectAudioTrack not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    index
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SELECTAUDIOTRACK,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetPlayerOption(int playerId, string key, int value)
        {
            AgoraLog.LogWarning("SetPlayerOption not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    key,
            //    value
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYEROPTION,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetPlayerOption(int playerId, string key, string value)
        {
            AgoraLog.LogWarning("SetPlayerOption not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    key,
            //    value
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETPLAYEROPTION2,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int TakeScreenshot(int playerId, string filename)
        {
            AgoraLog.LogWarning("TakeScreenshot not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    filename
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_TAKESCREENSHOT,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SelectInternalSubtitle(int playerId, int index)
        {
            AgoraLog.LogWarning("SelectInternalSubtitle not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    index
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SELECTINTERNALSUBTITLE,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetExternalSubtitle(int playerId, string url)
        {
            AgoraLog.LogWarning("SetExternalSubtitle not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    url
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETEXTERNALSUBTITLE,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public MEDIA_PLAYER_STATE GetState(int playerId)
        {
            AgoraLog.LogWarning("GetState not support in this platform");
            return MEDIA_PLAYER_STATE.PLAYER_STATE_FAILED;
            //TODO CHECK
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETSTATE,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (MEDIA_PLAYER_STATE)AgoraJson.GetData<int>(result, "result");
        }

        public int Mute(int playerId, bool mute)
        {
            AgoraLog.LogWarning("Mute not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    mute
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_MUTE,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetMute(int playerId, ref bool mute)
        {
            AgoraLog.LogWarning("GetMute not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETMUTE,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //mute = (bool)AgoraJson.GetData<bool>(result, "mute");
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int AdjustPlayoutVolume(int playerId, int volume)
        {
            AgoraLog.LogWarning("AdjustPlayoutVolume not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    volume
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_ADJUSTPLAYOUTVOLUME,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetPlayoutVolume(int playerId, ref int volume)
        {
            AgoraLog.LogWarning("GetPlayoutVolume not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYOUTVOLUME,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //volume = (int)AgoraJson.GetData<int>(result, "volume");
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int AdjustPublishSignalVolume(int playerId, int volume)
        {
            AgoraLog.LogWarning("AdjustPublishSignalVolume not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    volume
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_ADJUSTPUBLISHSIGNALVOLUME,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetPublishSignalVolume(int playerId, ref int volume)
        {
            AgoraLog.LogWarning("GetPublishSignalVolume not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    volume
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETPUBLISHSIGNALVOLUME,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //volume = (int)AgoraJson.GetData<int>(result, "volume");
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetView(int playerId)
        {
            AgoraLog.LogWarning("SetView not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETVIEW,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode)
        {
            AgoraLog.LogWarning("SetRenderMode not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    renderMode
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETRENDERMODE,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode)
        {
            AgoraLog.LogWarning("SetAudioDualMonoMode not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new
            //{
            //    playerId,
            //    mode
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETAUDIODUALMONOMODE,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public string GetPlayerSdkVersion(int playerId)
        {
            AgoraLog.LogWarning("GetPlayerSdkVersion not support in this platform");
            return "";
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYERSDKVERSION,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return ret != 0 ? ret.ToString() : (string)AgoraJson.GetData<string>(result, "result");
        }

        public string GetPlaySrc(int playerId)
        {
            AgoraLog.LogWarning("GetPlaySrc not support in this platform");
            return "";
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETPLAYSRC,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return ret != 0 ? ret.ToString() : (string)AgoraJson.GetData<string>(result, "result");
        }

        public int SetAudioPitch(int playerId, int pitch)
        {
            AgoraLog.LogWarning("SetAudioPitch not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, pitch };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETAUDIOPITCH,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params)
        {
            AgoraLog.LogWarning("SetSpatialAudioParams not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, spatial_audio_params };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SETSPATIALAUDIOPARAMS,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int OpenWithAgoraCDNSrc(int playerId, string src, Int64 startPos)
        {
            AgoraLog.LogWarning("OpenWithAgoraCDNSrc not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, src, startPos };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_OPENWITHAGORACDNSRC,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetAgoraCDNLineCount(int playerId)
        {
            AgoraLog.LogWarning("GetAgoraCDNLineCount not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETAGORACDNLINECOUNT,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SwitchAgoraCDNLineByIndex(int playerId, int index)
        {
            AgoraLog.LogWarning("SwitchAgoraCDNLineByIndex not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, index };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SWITCHAGORACDNLINEBYINDEX,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetCurrentAgoraCDNIndex(int playerId)
        {
            AgoraLog.LogWarning("GetCurrentAgoraCDNIndex not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId };
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_GETCURRENTAGORACDNINDEX,
            //    "", 0, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int EnableAutoSwitchAgoraCDN(int playerId, bool enable)
        {
            AgoraLog.LogWarning("EnableAutoSwitchAgoraCDN not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, enable };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_ENABLEAUTOSWITCHAGORACDN,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int RenewAgoraCDNSrcToken(int playerId, string token, Int64 ts)
        {
            AgoraLog.LogWarning("RenewAgoraCDNSrcToken not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, token, ts };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_RENEWAGORACDNSRCTOKEN,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SwitchAgoraCDNSrc(int playerId, string src, bool syncPts = false)
        {
            AgoraLog.LogWarning("SwitchAgoraCDNSrc not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, src, syncPts };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SWITCHAGORACDNSRC,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SwitchSrc(int playerId, string src, bool syncPts = true)
        {
            AgoraLog.LogWarning("SwitchSrc not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, src, syncPts };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_SWITCHSRC,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int PreloadSrc(int playerId, string src, Int64 startPos)
        {
            AgoraLog.LogWarning("PreloadSrc not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, src, startPos };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_PRELOADSRC,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int PlayPreloadedSrc(int playerId, string src)
        {
            AgoraLog.LogWarning("PlayPreloadedSrc not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, src };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_PLAYPRELOADEDSRC,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int UnloadSrc(int playerId, string src)
        {
            AgoraLog.LogWarning("UnloadSrc not support in this platform");
            return -(int)ERROR_CODE_TYPE.ERR_NOT_SUPPORTED;
            //var param = new { playerId, src };
            //string jsonParam = AgoraJson.ToJson(param);
            //var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
            //    AgoraApiType.FUNC_MEDIAPLAYER_UNLOADSRC,
            //    jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            //return (int)AgoraJson.GetData<int>(result, "result");
        }
    }
}

#endif