using System;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif
namespace Agora.Rtc
{
    public class AgoraMusicContentCenterEventHandlerNative
    {
        internal static IAgoraMusicContentCenterEventHandler EventHandler = null;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(string @event, string data, IntPtr buffer, IntPtr length, uint buffer_count)
        {
            if (EventHandler == null) return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif

            switch (@event)
            {

                case "AgoraMusicContentCenterEventHandler_onMusicChartsTypeResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnMusicChartsTypeResult(
                        (string)AgoraJson.GetData<string>(data, "requestId"),
                        (CopyRightMusicStatusCode)AgoraJson.GetData<int>(data, "status"),
                        (MusicChartsResult)AgoraJson.JsonToStruct<MusicChartsResult>(data, "result")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "AgoraMusicContentCenterEventHandler_onSongListResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnSongListResult(
                        (string)AgoraJson.GetData<string>(data, "requestId"),
                        (CopyRightMusicStatusCode)AgoraJson.GetData<int>(data, "status"),
                        (MusicListResult)AgoraJson.JsonToStruct<MusicListResult>(data, "result")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "AgoraMusicContentCenterEventHandler_onLyricResult":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnLyricResult(
                        (string)AgoraJson.GetData<string>(data, "requestId"),
                        (string)AgoraJson.GetData<string>(data, "lyricUrl")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;

                case "AgoraMusicContentCenterEventHandler_onPreLoadEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                    if (EventHandler == null) return;
                    EventHandler.OnPreLoadEvent(
                        (Int64)AgoraJson.GetData<Int64>(data, "songCode"),
                        (int)AgoraJson.GetData<int>(data, "percent"),
                        (PreloadStatusCode)AgoraJson.GetData<int>(data, "status"),
                        (string)AgoraJson.GetData<string>(data, "msg"),
                        (string)AgoraJson.GetData<string>(data, "lyricUrl")
                    );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;


            }

        }




    }
}