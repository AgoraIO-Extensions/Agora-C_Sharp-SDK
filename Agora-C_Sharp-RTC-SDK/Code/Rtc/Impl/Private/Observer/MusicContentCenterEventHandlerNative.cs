using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtc
{
    public class MusicContentCenterEventHandlerNative
    {
        private static IMusicContentCenterEventHandler EventHandler = null;
        internal static void SetMusicContentCenterEventHandler(IMusicContentCenterEventHandler handler)
        {
            EventHandler = handler;
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            if (EventHandler == null) return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif

            IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));

            string @event = eventParam.@event;
            string data = eventParam.data;
            IntPtr buffer = eventParam.buffer;
            IntPtr length = eventParam.length;
            uint buffer_count = eventParam.buffer_count;

            LitJson.JsonData jsonData = null;
            if (data != null)
            {
                jsonData = AgoraJson.ToObject(data);
            }

            switch (@event)
            {

                case "MusicContentCenterEventHandler_onMusicChartsResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnMusicChartsResult(
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (MusicContentCenterStatusCode)AgoraJson.GetData<int>(jsonData, "status"),
                        AgoraJson.JsonToStructArray<MusicChartInfo>(jsonData, "result")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "MusicContentCenterEventHandler_onMusicCollectionResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnMusicCollectionResult(
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (MusicContentCenterStatusCode)AgoraJson.GetData<int>(jsonData, "status"),
                        (MusicCollection)AgoraJson.JsonToStruct<MusicCollection>(jsonData, "result")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "MusicContentCenterEventHandler_onLyricResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnLyricResult(
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (string)AgoraJson.GetData<string>(jsonData, "lyricUrl")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "MusicContentCenterEventHandler_onPreLoadEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnPreLoadEvent(
                        (Int64)AgoraJson.GetData<Int64>(jsonData, "songCode"),
                        (int)AgoraJson.GetData<int>(jsonData, "percent"),
                        (PreloadStatusCode)AgoraJson.GetData<int>(jsonData, "status"),
                        (string)AgoraJson.GetData<string>(jsonData, "msg"),
                        (string)AgoraJson.GetData<string>(jsonData, "lyricUrl")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;


            }
        }
    }
}