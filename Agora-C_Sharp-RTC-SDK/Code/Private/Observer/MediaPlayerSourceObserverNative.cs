﻿using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace agora.rtc
{
    internal static class MediaPlayerSourceObserverNative
    {
        internal static IMediaPlayerSourceObserver RtcMediaPlayerEventHandler = null;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(string @event, string data, IntPtr buffer, IntPtr length, uint buffer_count)
        {
            if (RtcMediaPlayerEventHandler == null) return;

            int[] len = new int[buffer_count];
            if (length != IntPtr.Zero)
            {
                Marshal.Copy(length, len, 0, (int)buffer_count);
            }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            switch (@event)
            {
                case "MediaPlayerSourceObserver_onPlayerSourceStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnPlayerSourceStateChanged(
                            (int)AgoraJson.GetData<int>(data, "playerId"),
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
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnPositionChanged(
                            (int)AgoraJson.GetData<int>(data, "playerId"),
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
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnPlayerEvent(
                            (int)AgoraJson.GetData<int>(data, "playerId"),
                            (MEDIA_PLAYER_EVENT)AgoraJson.GetData<int>(data, "event"),
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
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnPlayBufferUpdated(
                            (int)AgoraJson.GetData<int>(data, "playerId"),
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
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnCompleted(
                            (int)AgoraJson.GetData<int>(data, "playerId")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onAgoraCDNTokenWillExpire":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnAgoraCDNTokenWillExpire(
                            (int)AgoraJson.GetData<int>(data, "playerId")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onPlayerInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnPlayerInfoUpdated(
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
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnPlayerSrcInfoChanged(
                            (int)AgoraJson.GetData<int>(data, "playerId"),
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
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnAudioVolumeIndication(
                            (int)AgoraJson.GetData<int>(data, "playerId"),
                            (int)AgoraJson.GetData<int>(data, "volume")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "MediaPlayerSourceObserver_onMetaData":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (RtcMediaPlayerEventHandler == null) return;
                        RtcMediaPlayerEventHandler.OnMetaData((int)AgoraJson.GetData<int>(data, "playerId"),
                            buffer, len[0]);
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
            }
        }
    }
}