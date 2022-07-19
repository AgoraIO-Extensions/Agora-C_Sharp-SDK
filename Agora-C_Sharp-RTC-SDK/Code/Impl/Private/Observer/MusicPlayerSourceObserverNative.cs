using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Agora.Rtc
{

    internal static class MusicPlayerSourceObserverNative
    {

        internal static Dictionary<int, IMediaPlayerSourceObserver> RtcMusicPlayerEventHandlerDic = new Dictionary<int, IMediaPlayerSourceObserver>();
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
            int playerId = (int)AgoraJson.GetData<int>(data, "playerId");
            switch (@event)
            {
                case "MediaPlayerSourceObserver_onPlayerSourceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnPlayerSourceStateChanged(
                        (MEDIA_PLAYER_STATE)AgoraJson.GetData<int>(data, "state"),
                        (MEDIA_PLAYER_ERROR)AgoraJson.GetData<int>(data, "ec")
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
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnPositionChanged(
                        (Int64)AgoraJson.GetData<Int64>(data, "position")
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
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnPlayerEvent(
                        (MEDIA_PLAYER_EVENT)AgoraJson.GetData<int>(data, "eventCode"),
                        (Int64)AgoraJson.GetData<Int64>(data, "elapsedTime"),
                        (string)AgoraJson.GetData<string>(data, "message")
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
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnPlayBufferUpdated(
                        (Int64)AgoraJson.GetData<Int64>(data, "playCachedBuffer")
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
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnCompleted();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onAgoraCDNTokenWillExpire":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnAgoraCDNTokenWillExpire();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onPlayerInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnPlayerInfoUpdated(
                        AgoraJson.JsonToStruct<PlayerUpdatedInfo>(data, "info")
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
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnPlayerSrcInfoChanged(
                        AgoraJson.JsonToStruct<SrcInfo>(data, "from"),
                        AgoraJson.JsonToStruct<SrcInfo>(data, "to")
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
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnAudioVolumeIndication(
                        (int)AgoraJson.GetData<int>(data, "volume")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onMetaData":
                    var byteLength = (int)AgoraJson.GetData<int>(data, "length");
                    var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(data, "data");
                    var byteData = new byte[byteLength];
                    if (byteLength != 0)
                    {
                        Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                    }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!RtcMusicPlayerEventHandlerDic.ContainsKey(playerId)) return;
                    RtcMusicPlayerEventHandlerDic[playerId].OnMetaData(byteData, byteLength);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
            }
        }



    }

}
