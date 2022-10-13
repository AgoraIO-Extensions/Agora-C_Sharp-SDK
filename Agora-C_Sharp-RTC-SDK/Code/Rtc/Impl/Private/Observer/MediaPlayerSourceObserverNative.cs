using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MediaPlayerSourceObserverNative
    {
        internal static Dictionary<int, IMediaPlayerSourceObserver> RtcMediaPlayerEventHandlerDic = new Dictionary<int, IMediaPlayerSourceObserver>();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(string @event, string data, IntPtr buffer, IntPtr length, uint buffer_count)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            var jsonData = AgoraJson.ToObject(data);
            int playerId = (int)AgoraJson.GetData<int>(jsonData, "playerId");
            switch (@event)
            {
                case "MediaPlayerSourceObserver_onPlayerSourceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnPlayerSourceStateChanged(
                            (MEDIA_PLAYER_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                            (MEDIA_PLAYER_ERROR)AgoraJson.GetData<int>(jsonData, "ec")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onPositionChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnPositionChanged(
                            (Int64)AgoraJson.GetData<Int64>(jsonData, "position_ms")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onPlayerEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnPlayerEvent(
                            (MEDIA_PLAYER_EVENT)AgoraJson.GetData<int>(jsonData, "eventCode"),
                            (Int64)AgoraJson.GetData<Int64>(jsonData, "elapsedTime"),
                            (string)AgoraJson.GetData<string>(jsonData, "message")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onPlayBufferUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnPlayBufferUpdated(
                            (Int64)AgoraJson.GetData<Int64>(jsonData, "playCachedBuffer")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "MediaPlayerSourceObserver_onPreloadEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMediaPlayerEventHandlerDic[playerId].OnPreloadEvent(
                        (string)AgoraJson.GetData<string>(jsonData, "src"),
                        (PLAYER_PRELOAD_EVENT)AgoraJson.GetData<int>(jsonData, "event")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "MediaPlayerSourceObserver_onCompleted":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnCompleted();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onAgoraCDNTokenWillExpire":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnAgoraCDNTokenWillExpire();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onPlayerInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnPlayerInfoUpdated(
                            AgoraJson.JsonToStruct<PlayerUpdatedInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onPlayerSrcInfoChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnPlayerSrcInfoChanged(
                            AgoraJson.JsonToStruct<SrcInfo>(jsonData, "from"),
                            AgoraJson.JsonToStruct<SrcInfo>(jsonData, "to")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onAudioVolumeIndication":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnAudioVolumeIndication(
                            (int)AgoraJson.GetData<int>(jsonData, "volume")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onMetaData":
                    var byteLength = (int)AgoraJson.GetData<int>(jsonData, "length");
                    var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "data");
                    var byteData = new byte[byteLength];
                    if (byteLength != 0)
                    {
                        Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                    }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!RtcMediaPlayerEventHandlerDic.ContainsKey(playerId)) return;
                        RtcMediaPlayerEventHandlerDic[playerId].OnMetaData(byteData, byteLength);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
            }
        }
    }
}
