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
                         AgoraJson.JsonToStructArray<MusicChartInfo>(jsonData, "result"),
                        (MusicContentCenterStatusCode)AgoraJson.GetData<int>(jsonData, "errorCode")

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
                        (MusicCollection)AgoraJson.JsonToStruct<MusicCollection>(jsonData, "result"),
                        (MusicContentCenterStatusCode)AgoraJson.GetData<int>(jsonData, "errorCode")

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
                        (Int64)AgoraJson.GetData<Int64>(jsonData, "songCode"),
                        (string)AgoraJson.GetData<string>(jsonData, "lyricUrl"),
                        (MusicContentCenterStatusCode)AgoraJson.GetData<int>(jsonData, "errorCode")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "MusicContentCenterEventHandler_onSongSimpleInfoResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnSongSimpleInfoResult(
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (Int64)AgoraJson.GetData<Int64>(jsonData, "songCode"),
                        (string)AgoraJson.GetData<string>(jsonData, "simpleInfo"),
                        (MusicContentCenterStatusCode)AgoraJson.GetData<int>(jsonData, "errorCode")
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
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (Int64)AgoraJson.GetData<Int64>(jsonData, "songCode"),
                        (int)AgoraJson.GetData<int>(jsonData, "percent"),
                        (string)AgoraJson.GetData<string>(jsonData, "lyricUrl"),
                        (PreloadStatusCode)AgoraJson.GetData<int>(jsonData, "status"),
                        (MusicContentCenterStatusCode)AgoraJson.GetData<int>(jsonData, "errorCode")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;


            }
        }
    }
}