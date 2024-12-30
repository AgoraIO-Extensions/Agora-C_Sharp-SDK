using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
using AOT;
#endif

namespace Agora.Rtc
{
    public class H265TranscoderObserverNative
    {

#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        private static Object observerLock = new Object();
#endif
        private static IH265TranscoderObserver EventHandler = null;
        internal static void SetH265TranscoderObserver(IH265TranscoderObserver handler)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
lock (observerLock){
#endif
            EventHandler = handler;
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
}
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
lock (observerLock){
#endif
            if (EventHandler == null)
                return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
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
                #region terra IH265TranscoderObserver
                case AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONENABLETRANSCODE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnEnableTranscode(
                            (H265_TRANSCODE_RESULT)AgoraJson.GetData<int>(jsonData, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
 }); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONQUERYCHANNEL:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnQueryChannel(
                            (H265_TRANSCODE_RESULT)AgoraJson.GetData<int>(jsonData, "result"),
                            (string)AgoraJson.GetData<string>(jsonData, "originChannel"),
                            (string)AgoraJson.GetData<string>(jsonData, "transcodeChannel")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
 }); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONTRIGGERTRANSCODE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnTriggerTranscode(
                            (H265_TRANSCODE_RESULT)AgoraJson.GetData<int>(jsonData, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS || UNITY_OPENHARMONY
 }); 
#endif
                        break;
                    }
                    #endregion terra IH265TranscoderObserver
            }
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
}
#endif
        }
    }
}