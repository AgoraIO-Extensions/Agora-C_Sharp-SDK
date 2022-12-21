using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MediaRecorderObserverNative
    {
        private static Dictionary<string, IMediaRecorderObserver> mediaRecorderObserverDic = new Dictionary<string, IMediaRecorderObserver>();


        private static string generateKey(RtcConnection connection)
        {
            return connection.localUid.ToString() + "_" + connection.channelId;
        }

        internal static void AddMediaRecorderObserver(RtcConnection connection, IMediaRecorderObserver observer)
        {
            var key = generateKey(connection);
            if (mediaRecorderObserverDic.ContainsKey(key))
                mediaRecorderObserverDic.Remove(key);

            mediaRecorderObserverDic.Add(key, observer);
        }

        internal static bool ContainsMediaRecorderObserver(RtcConnection connection)
        {
            var key = generateKey(connection);
            return mediaRecorderObserverDic.ContainsKey(key);
        }

        internal static void RemoveMediaRecorderObserver(RtcConnection connection)
        {
            var key = generateKey(connection);
            if (mediaRecorderObserverDic.ContainsKey(key))
                mediaRecorderObserverDic.Remove(key);
        }

        internal static void ClearMediaRecorderObserver()
        {
            mediaRecorderObserverDic.Clear();
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

            LitJson.JsonData jsonData = null;
            if (data != null)
            {
                jsonData = AgoraJson.ToObject(data);
            }
            RtcConnection connection = AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection");
            string key = generateKey(connection);
            switch (@event)
            {
                case "MediaRecorderObserver_onRecorderStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!mediaRecorderObserverDic.ContainsKey(key)) return;
                    mediaRecorderObserverDic[key].OnRecorderStateChanged(
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
                    if (!mediaRecorderObserverDic.ContainsKey(key)) return;
                    mediaRecorderObserverDic[key].OnRecorderInfoUpdated(
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