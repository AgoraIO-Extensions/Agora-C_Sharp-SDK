using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    public class H265TranscoderObserverNative
    {
        private static IH265TranscoderObserver EventHandler = null;
        internal static void SetH265TranscoderObserver(IH265TranscoderObserver handler)
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
                #region terra IH265TranscoderObserver
                case AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONENABLETRANSCODE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnEnableTranscode(
                            (H265_TRANSCODE_RESULT)AgoraJson.GetData<int>(jsonData, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONQUERYCHANNEL:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnQueryChannel(
                            (H265_TRANSCODE_RESULT)AgoraJson.GetData<int>(jsonData, "result"),
                            (string)AgoraJson.GetData<string>(jsonData, "originChannel"),
                            (string)AgoraJson.GetData<string>(jsonData, "transcodeChannel")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                        break;
                    }

                case AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONTRIGGERTRANSCODE:
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (EventHandler == null) return;
                        EventHandler.OnTriggerTranscode(
                            (H265_TRANSCODE_RESULT)AgoraJson.GetData<int>(jsonData, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
 }); 
#endif
                        break;
                    }
                    #endregion terra IH265TranscoderObserver
            }
        }
    }
}