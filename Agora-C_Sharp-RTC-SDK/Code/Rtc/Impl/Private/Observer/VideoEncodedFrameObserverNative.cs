using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class VideoEncodedFrameObserverNative
    {
        private static object observerLock = new Object();
        private static IVideoEncodedFrameObserver videoEncodedFrameObserver;

        internal static void SetVideoEncodedFrameObserver(IVideoEncodedFrameObserver observer)
        {
            lock (observerLock)
            {
                videoEncodedFrameObserver = observer;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

                if (videoEncodedFrameObserver == null)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var @event = eventParam.@event;
                var data = eventParam.data;

                switch (@event)
                {

                    case AgoraApiType.IVIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED_6922697:
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            uint uid = (uint)AgoraJson.GetData<uint>(jsonData, "uid");
                            IntPtr imageBuffer = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "imageBuffer");
                            UInt64 imageBufferLength = (UInt64)AgoraJson.GetData<UInt64>(jsonData, "length");
                            EncodedVideoFrameInfo videoEncodedFrameInfo = AgoraJson.JsonToStruct<EncodedVideoFrameInfo>(jsonData, "videoEncodedFrameInfo");
                            bool result = videoEncodedFrameObserver.OnEncodedVideoFrameReceived(uid, imageBuffer, imageBufferLength, videoEncodedFrameInfo);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                            break;
                        }

                    default:
                        AgoraLog.LogError("unexpected event: " + @event);
                        break;
                }
            }
        }

        private static void CreateDefaultReturn(ref IrisRtcCEventParam eventParam, IntPtr param)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
                case AgoraApiType.IVIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED_6922697:
                    {
                        bool result = true;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        break;
                    }
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }
    }
}