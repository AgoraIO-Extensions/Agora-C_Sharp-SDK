using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class VideoEncodedFrameObserverNative
    {
        internal static Object observerLock = new Object();
        internal static IVideoEncodedFrameObserver videoEncodedFrameObserver;

        private static class LocalVideoEncodedVideoFrameInfo
        {
            internal static readonly EncodedVideoFrameInfo info = new EncodedVideoFrameInfo();
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));

                if (videoEncodedFrameObserver == null)
                {
                    CreateDefaultReturn(ref eventParam);
                    return;
                }

                var @event = eventParam.@event;
                var data = eventParam.data;
                var buffer = eventParam.buffer;
                var length = eventParam.length;
                var buffer_count = eventParam.buffer_count;

                IntPtr[] bufferArray = null;
                Int64[] lengthArray = null;

                if (buffer_count > 0)
                {
                    bufferArray = new IntPtr[buffer_count];
                    Marshal.Copy(buffer, bufferArray, 0, (int)buffer_count);
                    lengthArray = new Int64[buffer_count];
                    Marshal.Copy(length, lengthArray, 0, (int)buffer_count);
                }

                var jsonData = AgoraJson.ToObject(data);

                switch (@event)
                {
                    case "VideoEncodedFrameObserver_OnEncodedVideoFrameReceived":
                        {
                            //uint uid, IntPtr imageBufferPtr, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo
                            uint uid = (uint)AgoraJson.GetData<uint>(jsonData, "uid");
                            IntPtr imageBufferPtr = bufferArray[0];
                            UInt64 length2 = (UInt64)lengthArray[0];
                            EncodedVideoFrameInfo videoEncodedFrameInfo = AgoraJson.JsonToStruct<EncodedVideoFrameInfo>(jsonData, "videoEncodedFrameInfo");
                            bool result = videoEncodedFrameObserver.OnEncodedVideoFrameReceived(uid, imageBufferPtr, length2, videoEncodedFrameInfo);
                            var p = new { result };
                            string json = AgoraJson.ToJson(p);
                            Buffer.BlockCopy(json.ToCharArray(), 0, eventParam.result, 0, json.Length);
                        }
                        break;
                    default:
                        AgoraLog.LogError("unexpected event: " + @event);
                        break;
                }
            }

        }


        private static void CreateDefaultReturn(ref IrisCEventParam eventParam)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
                case "VideoEncodedFrameObserver_OnEncodedVideoFrameReceived":
                    {
                        bool result = true;
                        var p = new { result };
                        string json = AgoraJson.ToJson(p);
                        Buffer.BlockCopy(json.ToCharArray(), 0, eventParam.result, 0, json.Length);
                    }
                    break;
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_EncodedVideoFrameObserver_Native))]
#endif
        internal static bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBuffer, UInt64 length, IntPtr videoEncodedFrameInfoPtr)
        {
            if (videoEncodedFrameObserver == null)
                return true;

            var videoEncodedFrameInfo = (IrisEncodedVideoFrameInfo)(Marshal.PtrToStructure(videoEncodedFrameInfoPtr, typeof(IrisEncodedVideoFrameInfo)) ??
                new IrisEncodedVideoFrameInfo());

            var localVideoEncodedFrameInfo = LocalVideoEncodedVideoFrameInfo.info;

            localVideoEncodedFrameInfo.codecType = (VIDEO_CODEC_TYPE)videoEncodedFrameInfo.codecType;
            localVideoEncodedFrameInfo.width = videoEncodedFrameInfo.width;
            localVideoEncodedFrameInfo.height = videoEncodedFrameInfo.height;
            localVideoEncodedFrameInfo.framesPerSecond = videoEncodedFrameInfo.framesPerSecond;
            localVideoEncodedFrameInfo.frameType = (VIDEO_FRAME_TYPE_NATIVE)videoEncodedFrameInfo.frameType;
            localVideoEncodedFrameInfo.rotation = (VIDEO_ORIENTATION)videoEncodedFrameInfo.rotation;
            localVideoEncodedFrameInfo.trackId = videoEncodedFrameInfo.trackId;
            localVideoEncodedFrameInfo.captureTimeMs = videoEncodedFrameInfo.captureTimeMs;
            localVideoEncodedFrameInfo.uid = videoEncodedFrameInfo.uid;
            localVideoEncodedFrameInfo.streamType = (VIDEO_STREAM_TYPE)videoEncodedFrameInfo.streamType;

            try
            {
                return videoEncodedFrameObserver.OnEncodedVideoFrameReceived(uid, imageBuffer, length, localVideoEncodedFrameInfo);
            }
            catch (Exception e)
            {
                AgoraLog.LogError("[Exception] IVideoEncodedFrameObserver.OnEncodedVideoFrameReceived: " + e);
                return false;
            }
        }
    }
}