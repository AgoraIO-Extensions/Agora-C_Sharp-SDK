using System;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MediaRecorderObserverNative
    {
        internal static Dictionary<string, IMediaRecorderObserver> MediaRecorderObserverDic = new Dictionary<string, IMediaRecorderObserver>();
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
            RtcConnection connection = AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection");
            string key = connection.localUid.ToString() + connection.channelId;
            switch (@event)
            {
                case "MediaRecorderObserver_onRecorderStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!MediaRecorderObserverDic.ContainsKey(key)) return;
                        MediaRecorderObserverDic[key].OnRecorderStateChanged(
                            (RecorderState)AgoraJson.GetData<int>(jsonData, "state"),
                            (RecorderErrorCode)AgoraJson.GetData<int>(jsonData, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                
                case "MediaRecorderObserver_onRecorderInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (!MediaRecorderObserverDic.ContainsKey(key)) return;
                        MediaRecorderObserverDic[key].OnRecorderInfoUpdated(
                            AgoraJson.JsonToStruct<RecorderInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
            }
        }
    }
}