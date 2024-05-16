using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
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

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            if (EventHandler == null)
                return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (CallbackObject == null || CallbackObject._CallbackQueue == null)
                return;
#endif

            IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

            string @event = eventParam.@event;
            string data = eventParam.data;

            LitJson.JsonData jsonData = null;
            if (data != null)
            {
                jsonData = AgoraJson.ToObject(data);
            }

            switch (@event)
            {
                #region terra IMusicContentCenterEventHandler
                case AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCHARTSRESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnMusicChartsResult(
                            (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                            AgoraJson.JsonToStructArray<MusicChartInfo>(jsonData, "result"),
                            (MusicContentCenterStateReason)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCOLLECTIONRESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnMusicCollectionResult(
                            (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                            AgoraJson.JsonToStruct<MusicCollection>(jsonData, "result"),
                            (MusicContentCenterStateReason)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONLYRICRESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnLyricResult(
                            (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                            (long)AgoraJson.GetData<long>(jsonData, "songCode"),
                            (string)AgoraJson.GetData<string>(jsonData, "lyricUrl"),
                            (MusicContentCenterStateReason)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONSONGSIMPLEINFORESULT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnSongSimpleInfoResult(
                            (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                            (long)AgoraJson.GetData<long>(jsonData, "songCode"),
                            (string)AgoraJson.GetData<string>(jsonData, "simpleInfo"),
                            (MusicContentCenterStateReason)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONPRELOADEVENT:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnPreLoadEvent(
                            (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                            (long)AgoraJson.GetData<long>(jsonData, "songCode"),
                            (int)AgoraJson.GetData<int>(jsonData, "percent"),
                            (string)AgoraJson.GetData<string>(jsonData, "lyricUrl"),
                            (PreloadState)AgoraJson.GetData<int>(jsonData, "state"),
                            (MusicContentCenterStateReason)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                        break;
                    }
                    #endregion terra IMusicContentCenterEventHandler
            }
        }
    }
}