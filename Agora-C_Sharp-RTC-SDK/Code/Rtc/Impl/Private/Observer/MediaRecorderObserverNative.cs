using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MediaRecorderObserverNative
    {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        private static Object observerLock = new Object();
#endif
        private static Dictionary<string, IMediaRecorderObserver> mediaRecorderObserverDic = new Dictionary<string, IMediaRecorderObserver>();

        internal static void AddMediaRecorderObserver(string nativeHandle, IMediaRecorderObserver observer)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
lock (observerLock){
#endif
            if (mediaRecorderObserverDic.ContainsKey(nativeHandle))
                mediaRecorderObserverDic.Remove(nativeHandle);

            mediaRecorderObserverDic.Add(nativeHandle, observer);
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
}
#endif
        }

        internal static bool ContainsMediaRecorderObserver(string nativeHandle)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
lock (observerLock){
#endif
            return mediaRecorderObserverDic.ContainsKey(nativeHandle);
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
}
#endif
        }

        internal static void RemoveMediaRecorderObserver(string nativeHandle)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
lock (observerLock){
#endif
            if (mediaRecorderObserverDic.ContainsKey(nativeHandle))
                mediaRecorderObserverDic.Remove(nativeHandle);
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
}
#endif
        }

        internal static void ClearMediaRecorderObserver()
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
lock (observerLock){
#endif
            mediaRecorderObserverDic.Clear();
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
}
#endif
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
lock (observerLock){
#endif
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    });
#endif
                    break;

                case "MediaRecorderObserver_onRecorderInfoUpdated":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (!mediaRecorderObserverDic.ContainsKey(nativeHandle)) return;
                    mediaRecorderObserverDic[nativeHandle].OnRecorderInfoUpdated(
                        (string)AgoraJson.GetData<string>(jsonData, "channelId"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        AgoraJson.JsonToStruct<RecorderInfo>(jsonData, "info")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                    });
#endif
                    break;
            }
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
}
#endif
        }

    }



}