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


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif

            IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));
            var @event = eventParam.@event;
            var data = eventParam.data;
            var buffer = eventParam.buffer;
            var length = eventParam.length;
            var buffer_count = eventParam.buffer_count;


            var jsonData = AgoraJson.ToObject(data);
            int playerId = (int)AgoraJson.GetData<int>(jsonData, "playerId");
            switch (@event)
            {
                case "MediaPlayerSourceObserver_onPlayerSourceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnPlayerSourceStateChanged(
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
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnPositionChanged(
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
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnPlayerEvent(
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
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnPlayBufferUpdated(
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
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnPreloadEvent(
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
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnCompleted();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onAgoraCDNTokenWillExpire":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnAgoraCDNTokenWillExpire();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onPlayerInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;

                    PlayerUpdatedInfo playerUpdatedInfo = new PlayerUpdatedInfo();
                    LitJson.JsonData info = jsonData["info"];
                    if (info.ContainsKey("deviceId"))
                    {
                        playerUpdatedInfo.deviceId.SetValue((string)AgoraJson.GetData<string>(info, "deviceId"));
                    }
                    if (info.ContainsKey("playerId"))
                    {
                        playerUpdatedInfo.playerId.SetValue((string)AgoraJson.GetData<string>(info, "playerId"));
                    }
                    if (info.ContainsKey("cacheStatistics"))
                    {
                        playerUpdatedInfo.cacheStatistics.SetValue((CacheStatistics)AgoraJson.JsonToStruct<CacheStatistics>(info, "cacheStatistics"));
                    }

                    mediaPlayerSourceObserverDic[playerId].OnPlayerInfoUpdated(
                           playerUpdatedInfo
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
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnPlayerSrcInfoChanged(
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
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnAudioVolumeIndication(
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
                    if (!mediaPlayerSourceObserverDic.ContainsKey(playerId)) return;
                    mediaPlayerSourceObserverDic[playerId].OnMetaData(byteData, byteLength);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
            }


        }

    }





}
