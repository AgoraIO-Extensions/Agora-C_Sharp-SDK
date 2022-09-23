using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
using Agora.Rtc;
#endif

namespace Agora.Rtm
{
    internal static class RtmEventHandlerNative
    {
        private static IRtmEventHandler rtmEventHandler = null;

        internal static void SetEventHandler(IRtmEventHandler handler)
        {
            rtmEventHandler = handler;
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
            var jsonData = AgoraJson.ToObject(data);

            switch (@event)
            {
                case "RtmEventHandler_onMessageEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnMessageEvent(
                            (MessageEvent)AgoraJson.GetData<int>(jsonData, "event")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onPresenceEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnPresenceEvent(
                            (PresenceEvent)AgoraJson.GetData<int>(jsonData, "event")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
                case "RtmEventHandler_onStatusEvent":
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    CallbackObject._CallbackQueue.EnQueue(() =>
                    {
#endif
                        if (rtmEventHandler == null) return;
                        rtmEventHandler.OnStatusEvent(
                            (StatusEvent)AgoraJson.GetData<int>(jsonData, "event")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                    });
#endif
                    break;
            }
        }
    }
}
