using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    public class ScoreEventHandlerNative
    {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        private static Object observerLock = new Object();
#endif
        private static IScoreEventHandler EventHandler = null;
        internal static void SetScoreEventHandler(IScoreEventHandler handler)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
                EventHandler = handler;
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
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
                    #region terra IScoreEventHandler
                    case AgoraEventType.EVENT_SCOREEVENTHANDLER_ONPITCH:
                        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                            if (EventHandler == null) return;
                            EventHandler.OnPitch(
                                (long)AgoraJson.GetData<long>(jsonData, "songCode"),
                                AgoraJson.JsonToStruct<RawScoreData>(jsonData, "rawScoreData")
                            );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                            break;
                        }

                    case AgoraEventType.EVENT_SCOREEVENTHANDLER_ONLINESCORE:
                        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                            if (EventHandler == null) return;
                            EventHandler.OnLineScore(
                                (long)AgoraJson.GetData<long>(jsonData, "songCode"),
                                AgoraJson.JsonToStruct<LineScoreData>(jsonData, "lineScoreData")
                            );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                            break;
                        }
                        #endregion terra IScoreEventHandler
                }
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }
    }
}