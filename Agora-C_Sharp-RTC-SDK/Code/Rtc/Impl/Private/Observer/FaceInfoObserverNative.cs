using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class FaceInfoObserverNative
    {
        private static Object observerLock = new Object();
        private static IFaceInfoObserver faceInfoObserver = null;

        internal static void SetFaceInfoObserver(IFaceInfoObserver observer)
        {
            lock (observerLock)
            {
                faceInfoObserver = observer;
            }
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                if (faceInfoObserver == null) return;
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
                    case AgoraEventType.EVENT_FACEINFOOBSERVER_ONFACEINFO:
                        {
                            if (faceInfoObserver == null) return;
                            string outFaceInfo = (string)AgoraJson.GetData<string>(jsonData, "outFaceInfo");
                            bool result = faceInfoObserver.OnFaceInfo(outFaceInfo);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

