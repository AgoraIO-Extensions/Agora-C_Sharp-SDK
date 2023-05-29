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

        internal static void AddMediaRecorderObserver(string nativeHandle, IMediaRecorderObserver observer)
        {

            if (mediaRecorderObserverDic.ContainsKey(nativeHandle))
                mediaRecorderObserverDic.Remove(nativeHandle);

            mediaRecorderObserverDic.Add(nativeHandle, observer);
        }

        internal static bool ContainsMediaRecorderObserver(string nativeHandle)
        {
            return mediaRecorderObserverDic.ContainsKey(nativeHandle);
        }

        internal static void RemoveMediaRecorderObserver(string nativeHandle)
        {
            if (mediaRecorderObserverDic.ContainsKey(nativeHandle))
                mediaRecorderObserverDic.Remove(nativeHandle);
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

            LitJson.JsonData jsonData = null;
            if (data != null)
            {
                jsonData = AgoraJson.ToObject(data);
            }

            string nativeHandle = (string)AgoraJson.GetData<string>(jsonData, "nativeHandle");
            switch (@event)
            {
                case "MediaRecorderObserver_onRecorderStateChanged":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!mediaRecorderObserverDic.ContainsKey(nativeHandle)) return;
                    mediaRecorderObserverDic[nativeHandle].OnRecorderStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channelId"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
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
                    if (!mediaRecorderObserverDic.ContainsKey(nativeHandle)) return;
                    mediaRecorderObserverDic[nativeHandle].OnRecorderInfoUpdated(
                        (string)AgoraJson.GetData<string>(jsonData, "channelId"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
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