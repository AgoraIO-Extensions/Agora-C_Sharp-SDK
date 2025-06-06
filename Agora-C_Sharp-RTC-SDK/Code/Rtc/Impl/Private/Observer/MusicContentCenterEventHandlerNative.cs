using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static partial class MusicContentCenterEventHandlerNative
    {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        private static Object observerLock = new Object();
#endif
        private static IMusicContentCenterEventHandler EventHandler = null;
        internal static void SetMusicContentCenterEventHandler(IMusicContentCenterEventHandler handler)
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
                    default:
                        {
                            OnEventGen(ref eventParam, jsonData, @event);
                            break;
                        }
                }
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }
    }
}