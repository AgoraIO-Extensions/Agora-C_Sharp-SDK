using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MediaPlayerSourceObserverNative
    {
        private static Dictionary<int, IMediaPlayerSourceObserver> mediaPlayerSourceObserverDic = new Dictionary<int, IMediaPlayerSourceObserver>();

        internal static void AddSourceObserver(int playerId, IMediaPlayerSourceObserver observer)
        {
            if (mediaPlayerSourceObserverDic.ContainsKey(playerId) == false)
                mediaPlayerSourceObserverDic.Add(playerId, observer);
        }

        internal static void RemoveSourceObserver(int playerId)
        {
            if (mediaPlayerSourceObserverDic.ContainsKey(playerId))
                mediaPlayerSourceObserverDic.Remove(playerId);
        }

        internal static void ClearSourceObserver()
        {
            mediaPlayerSourceObserverDic.Clear();
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (CallbackObject == null || CallbackObject._CallbackQueue == null)
                return;
#endif

            IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));
            var @event = eventParam.@event;
            var data = eventParam.data;

            var jsonData = AgoraJson.ToObject(data);
            int playerId = (int)AgoraJson.GetData<int>(jsonData, "playerId");
            switch (@event)
            {
                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONMETADATA:
                    {
                        var byteLength = (int)AgoraJson.GetData<int>(jsonData, "length");
                        var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "data");
                        var byteData = new byte[byteLength];
                        if (byteLength != 0)
                        {
                            Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                        }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                CallbackObject._CallbackQueue.EnQueue(() =>
                                                      {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId))
                            return;
                        mediaPlayerSourceObserverDic[playerId].OnMetaData(byteData, byteLength);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                                                      });
#endif
                        break;
                    }

                #region terra IMediaPlayerSourceObserver
                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSOURCESTATECHANGED:
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

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPOSITIONCHANGED:
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

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYEREVENT:
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

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYBUFFERUPDATED:
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

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPRELOADEVENT:
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

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONCOMPLETED:
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

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAGORACDNTOKENWILLEXPIRE:
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

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSRCINFOCHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerSrcInfoChanged(
                            AgoraJson.JsonToStruct<SrcInfo>(jsonData, "from"),
                            AgoraJson.JsonToStruct<SrcInfo>(jsonData, "to")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERINFOUPDATED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerInfoUpdated(
                            AgoraJson.JsonToStruct<PlayerUpdatedInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERCACHESTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerCacheStats(
                            AgoraJson.JsonToStruct<CacheStatistics>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERPLAYBACKSTATS:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                        mediaPlayerSourceObserverDic[playerId].OnPlayerPlaybackStats(
                            AgoraJson.JsonToStruct<PlayerPlaybackStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAUDIOVOLUMEINDICATION:
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
                    #endregion terra IMediaPlayerSourceObserver
            }
        }
    }

}
