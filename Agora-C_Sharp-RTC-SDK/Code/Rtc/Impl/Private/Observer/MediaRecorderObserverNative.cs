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
        private static Dictionary<string, object> mediaRecorderObserverDic = new Dictionary<string, object>();

        internal static void AddMediaRecorderObserver(string nativeHandle, object observer)
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


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
            IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));
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
                case AgoraEventType.EVENT_MEDIARECORDEROBSERVER_ONRECORDERSTATECHANGED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() =>{
#endif
                        if (!mediaRecorderObserverDic.ContainsKey(nativeHandle)) return;
                        ((IMediaRecorderObserver)mediaRecorderObserverDic[nativeHandle]).OnRecorderStateChanged(
                            (string)AgoraJson.GetData<string>(jsonData, "channelId"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                            (RecorderState)AgoraJson.GetData<int>(jsonData, "state"),
                            (RecorderReasonCode)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MEDIARECORDEROBSERVER_ONRECORDERINFOUPDATED:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() =>{
#endif
                        if (!mediaRecorderObserverDic.ContainsKey(nativeHandle)) return;
                        ((IMediaRecorderObserver)mediaRecorderObserverDic[nativeHandle]).OnRecorderInfoUpdated(
                            (string)AgoraJson.GetData<string>(jsonData, "channelId"),
                            (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                            AgoraJson.JsonToStruct<RecorderInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
});
#endif
                        break;
                    }
            }


        }

    }
}