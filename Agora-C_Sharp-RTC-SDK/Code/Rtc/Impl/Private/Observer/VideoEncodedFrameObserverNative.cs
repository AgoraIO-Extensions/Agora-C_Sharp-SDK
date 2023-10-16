#define AGORA_STRING_UID
#define AGORA_NUMBER_UID
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class VideoEncodedFrameObserverNative
    {
        private static object observerLock = new Object();
        private static object videoEncodedFrameObserver;

        internal static void SetVideoEncodedFrameObserver(object observer)
        {
            lock (observerLock)
            {
                videoEncodedFrameObserver = observer;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
#if AGORA_NUMBER_UID
                    case "VideoEncodedFrameObserver_onEncodedVideoFrameReceived":
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            uint uid = (uint)AgoraJson.GetData<uint>(jsonData, "uid");
                            IntPtr imageBuffer = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "imageBuffer");
                            UInt64 imageBufferLength = (UInt64)AgoraJson.GetData<UInt64>(jsonData, "length");
                            EncodedVideoFrameInfo videoEncodedFrameInfo = AgoraJson.JsonToStruct<EncodedVideoFrameInfo>(jsonData, "videoEncodedFrameInfo");
                            bool result = ((IVideoEncodedFrameObserver)videoEncodedFrameObserver).OnEncodedVideoFrameReceived(uid, imageBuffer, imageBufferLength, videoEncodedFrameInfo);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                            break;
                        }
#endif
#if AGORA_STRING_UID
                    case "VideoEncodedFrameObserverS_onEncodedVideoFrameReceived":
                        {
                            var jsonData = AgoraJson.ToObject(data);
                            string userAccount = (string)AgoraJson.GetData<string>(jsonData, "userAccount");
                            IntPtr imageBuffer = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "imageBuffer");
                            UInt64 imageBufferLength = (UInt64)AgoraJson.GetData<UInt64>(jsonData, "length");
                            EncodedVideoFrameInfoS videoEncodedFrameInfoS = AgoraJson.JsonToStruct<EncodedVideoFrameInfoS>(jsonData, "videoEncodedFrameInfoS");
                            bool result = ((IVideoEncodedFrameObserverS)videoEncodedFrameObserver).OnEncodedVideoFrameReceived(userAccount, imageBuffer, imageBufferLength, videoEncodedFrameInfoS);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                            break;
                        }
#endif

                    #region terra IVideoEncodedFrameObserver

                    #endregion terra IVideoEncodedFrameObserver

                    #region terra IVideoEncodedFrameObserverS

                    #endregion terra IVideoEncodedFrameObserverS
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
#if AGORA_NUMBER_UID
                case "VideoEncodedFrameObserver_OnEncodedVideoFrameReceived":
#endif
#if AGORA_STRING_UID
                case "VideoEncodedFrameObserverS_OnEncodedVideoFrameReceived":
#endif
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

                #region terra IVideoEncodedFrameObserver_CreateDefaultReturn

                #endregion terra IVideoEncodedFrameObserver_CreateDefaultReturn

                #region terra IVideoEncodedFrameObserverS_CreateDefaultReturn

                #endregion terra IVideoEncodedFrameObserverS_CreateDefaultReturn

                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_EncodedVideoFrameObserver_Native))]
        //#endif
        //        internal static bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBuffer, UInt64 length, IntPtr videoEncodedFrameInfoPtr)
        //        {
        //            if (videoEncodedFrameObserver == null)
        //                return true;

        //            var videoEncodedFrameInfo = (IrisEncodedVideoFrameInfo)(Marshal.PtrToStructure(videoEncodedFrameInfoPtr, typeof(IrisEncodedVideoFrameInfo)) ??
        //                new IrisEncodedVideoFrameInfo());

        //            var localVideoEncodedFrameInfo = LocalVideoEncodedVideoFrameInfo.info;

        //            localVideoEncodedFrameInfo.codecType = (VIDEO_CODEC_TYPE)videoEncodedFrameInfo.codecType;
        //            localVideoEncodedFrameInfo.width = videoEncodedFrameInfo.width;
        //            localVideoEncodedFrameInfo.height = videoEncodedFrameInfo.height;
        //            localVideoEncodedFrameInfo.framesPerSecond = videoEncodedFrameInfo.framesPerSecond;
        //            localVideoEncodedFrameInfo.frameType = (VIDEO_FRAME_TYPE_NATIVE)videoEncodedFrameInfo.frameType;
        //            localVideoEncodedFrameInfo.rotation = (VIDEO_ORIENTATION)videoEncodedFrameInfo.rotation;
        //            localVideoEncodedFrameInfo.trackId = videoEncodedFrameInfo.trackId;
        //            localVideoEncodedFrameInfo.captureTimeMs = videoEncodedFrameInfo.captureTimeMs;
        //            localVideoEncodedFrameInfo.uid = videoEncodedFrameInfo.uid;
        //            localVideoEncodedFrameInfo.streamType = (VIDEO_STREAM_TYPE)videoEncodedFrameInfo.streamType;

        //            try
        //            {
        //                return videoEncodedFrameObserver.OnEncodedVideoFrameReceived(uid, imageBuffer, length, localVideoEncodedFrameInfo);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IVideoEncodedFrameObserver.OnEncodedVideoFrameReceived: " + e);
        //                return false;
        //            }
        //        }
    }
}