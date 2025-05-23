#region Generated by `terra/node/src/rtc/impl/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

#define AGORA_RTC
#define AGORA_RTM
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static partial class MediaPlayerSourceObserverNative
    {

        internal static void OnEventGen(ref IrisRtcCEventParam eventParam, LitJson.JsonData jsonData, string @event)
        {
            var playerId = (int)AgoraJson.GetData<int>(jsonData, "playerId");
            switch (@event)
            {
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPLAYERSOURCESTATECHANGED_7fb38f1:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerSourceStateChanged(
                        (MEDIA_PLAYER_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (MEDIA_PLAYER_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPOSITIONCHANGED_303b92e:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPositionChanged(
                        (long)AgoraJson.GetData<long>(jsonData, "positionMs"),
                        (long)AgoraJson.GetData<long>(jsonData, "timestampMs")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPLAYEREVENT_50f16fa:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerEvent(
                        (MEDIA_PLAYER_EVENT)AgoraJson.GetData<int>(jsonData, "eventCode"),
                        (long)AgoraJson.GetData<long>(jsonData, "elapsedTime"),
                        (string)AgoraJson.GetData<string>(jsonData, "message")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPLAYBUFFERUPDATED_f631116:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayBufferUpdated(
                        (long)AgoraJson.GetData<long>(jsonData, "playCachedBuffer")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPRELOADEVENT_a1e3596:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPreloadEvent(
                        (string)AgoraJson.GetData<string>(jsonData, "src"),
                        (PLAYER_PRELOAD_EVENT)AgoraJson.GetData<int>(jsonData, "event")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONCOMPLETED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnCompleted(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONAGORACDNTOKENWILLEXPIRE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnAgoraCDNTokenWillExpire(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPLAYERSRCINFOCHANGED_54f3e5a:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerSrcInfoChanged(
                        (SrcInfo)AgoraJson.JsonToStruct<SrcInfo>(jsonData, "from"),
                        (SrcInfo)AgoraJson.JsonToStruct<SrcInfo>(jsonData, "to")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPLAYERINFOUPDATED_0e902a8:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerInfoUpdated(
                        (PlayerUpdatedInfo)AgoraJson.JsonToStruct<PlayerUpdatedInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPLAYERCACHESTATS_0145940:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerCacheStats(
                        (CacheStatistics)AgoraJson.JsonToStruct<CacheStatistics>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONPLAYERPLAYBACKSTATS_ffa466f:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerPlaybackStats(
                        (PlayerPlaybackStats)AgoraJson.JsonToStruct<PlayerPlaybackStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                case AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONAUDIOVOLUMEINDICATION_46f8ab7:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnAudioVolumeIndication(
                        (int)AgoraJson.GetData<int>(jsonData, "volume")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
                default:
                    {
                        AgoraLog.LogWarning("unknow event: " + @event);
                        break;
                    }
            }
        }
    }
}