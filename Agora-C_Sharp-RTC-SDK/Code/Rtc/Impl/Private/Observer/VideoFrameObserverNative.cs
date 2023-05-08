using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class VideoFrameObserverNative
    {
        private static Object observerLock = new Object();
        private static OBSERVER_MODE mode = OBSERVER_MODE.INTPTR;
        private static IVideoFrameObserver videoFrameObserver;

        internal static void SetVideoFrameObserverAndMode(IVideoFrameObserver observer, OBSERVER_MODE md)
        {
            lock (observerLock)
            {
                videoFrameObserver = observer;
                mode = md;
            }
        }


        private static class LocalVideoFrames
        {
            internal static readonly VideoFrame CaptureVideoFrame = new VideoFrame();
            internal static readonly VideoFrame PreEncodedVideoFrame = new VideoFrame();
            internal static readonly VideoFrame RenderVideoFrame = new VideoFrame();
            internal static readonly VideoFrame TranscodedVideoFrame = new VideoFrame();
            internal static readonly Dictionary<string, Dictionary<uint, VideoFrame>> RenderVideoFrameEx =
                new Dictionary<string, Dictionary<uint, VideoFrame>>();
        }

        private static VideoFrame GetVideoFrame(string channelId, uint uid)
        {
            VideoFrame localVideoFrame = null;
            if (channelId == "")
            {
                switch (uid)
                {
                    case 0:
                        localVideoFrame = LocalVideoFrames.CaptureVideoFrame;
                        break;
                    case 1:
                        localVideoFrame = LocalVideoFrames.PreEncodedVideoFrame;
                        break;
                    case 2:
                        localVideoFrame = LocalVideoFrames.RenderVideoFrame;
                        break;
                    case 3:
                        localVideoFrame = LocalVideoFrames.TranscodedVideoFrame;
                        break;
                }
            }
            else
            {
                if (!LocalVideoFrames.RenderVideoFrameEx.ContainsKey(channelId))
                {
                    LocalVideoFrames.RenderVideoFrameEx[channelId] = new Dictionary<uint, VideoFrame>();
                    LocalVideoFrames.RenderVideoFrameEx[channelId][uid] = new VideoFrame();
                }
                else if (!LocalVideoFrames.RenderVideoFrameEx[channelId].ContainsKey(uid))
                {
                    LocalVideoFrames.RenderVideoFrameEx[channelId][uid] = new VideoFrame();
                }

                localVideoFrame = LocalVideoFrames.RenderVideoFrameEx[channelId][uid];
            }
            return localVideoFrame;
        }

        private static void ConvertIrisVideoFrameToVideoFrame(ref IrisVideoFrame videoFrameConverted, ref VideoFrame localVideoFrame)
        {
            if (mode == OBSERVER_MODE.RAW_DATA)
            {
                if (localVideoFrame.height != videoFrameConverted.height ||
                localVideoFrame.yStride != videoFrameConverted.yStride ||
                localVideoFrame.uStride != videoFrameConverted.uStride ||
                localVideoFrame.vStride != videoFrameConverted.vStride)
                {
                    localVideoFrame.yBuffer = new byte[videoFrameConverted.y_buffer_length];
                    localVideoFrame.uBuffer = new byte[videoFrameConverted.u_buffer_length];
                    localVideoFrame.vBuffer = new byte[videoFrameConverted.v_buffer_length];
                }

                if (videoFrameConverted.yBuffer != IntPtr.Zero)
                    Marshal.Copy(videoFrameConverted.yBuffer, localVideoFrame.yBuffer, 0,
                        (int)videoFrameConverted.y_buffer_length);
                if (videoFrameConverted.uBuffer != IntPtr.Zero)
                    Marshal.Copy(videoFrameConverted.uBuffer, localVideoFrame.uBuffer, 0,
                        (int)videoFrameConverted.u_buffer_length);
                if (videoFrameConverted.vBuffer != IntPtr.Zero)
                    Marshal.Copy(videoFrameConverted.vBuffer, localVideoFrame.vBuffer, 0,
                        (int)videoFrameConverted.v_buffer_length);
            }

            localVideoFrame.width = videoFrameConverted.width;
            localVideoFrame.height = videoFrameConverted.height;
            localVideoFrame.yBufferPtr = videoFrameConverted.yBuffer;
            localVideoFrame.yStride = videoFrameConverted.yStride;
            localVideoFrame.uBufferPtr = videoFrameConverted.uBuffer;
            localVideoFrame.uStride = videoFrameConverted.uStride;
            localVideoFrame.vBufferPtr = videoFrameConverted.vBuffer;
            localVideoFrame.vStride = videoFrameConverted.vStride;
            localVideoFrame.rotation = videoFrameConverted.rotation;
            localVideoFrame.renderTimeMs = videoFrameConverted.renderTimeMs;
            localVideoFrame.avsync_type = videoFrameConverted.avsync_type;
            localVideoFrame.metadata_size = videoFrameConverted.metadata_size;
            localVideoFrame.metadata_buffer = videoFrameConverted.metadata_buffer;
            localVideoFrame.sharedContext = videoFrameConverted.sharedContext;
            localVideoFrame.matrix = videoFrameConverted.matrix;
            localVideoFrame.textureId = videoFrameConverted.textureId;
        }

        private static bool ProcessVideoFrameReceived(ref IrisVideoFrame videoFrame, ref VideoFrame localVideoFrame)
        {
            //var videoFrame = (IrisVideoFrame)(Marshal.PtrToStructure(videoFramePtr, typeof(IrisVideoFrame)) ??
            //    new IrisVideoFrame());
            videoFrame.type = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;
            videoFrame.y_buffer_length = (uint)(videoFrame.yStride * videoFrame.height);
            videoFrame.u_buffer_length = (uint)(videoFrame.uStride * videoFrame.height / 2);
            videoFrame.v_buffer_length = (uint)(videoFrame.vStride * videoFrame.height / 2);

            var ifConverted = videoFrameObserver.GetVideoFormatPreference() != VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;


            if (ifConverted)
            {
                IrisVideoFrame videoFrameConverted = new IrisVideoFrame();
                videoFrameConverted.type = videoFrameObserver.GetVideoFormatPreference();
                AgoraRtcNative.AlignAndConvertVideoFrame(ref videoFrameConverted, ref videoFrame);
                ConvertIrisVideoFrameToVideoFrame(ref videoFrameConverted, ref localVideoFrame);
                videoFrame = videoFrameConverted;
                return true;
            }
            else
            {
                ConvertIrisVideoFrameToVideoFrame(ref videoFrame, ref localVideoFrame);
            }

            return false;
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));

                if (videoFrameObserver == null)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var @event = eventParam.@event;
                var data = eventParam.data;
                var buffer = eventParam.buffer;
                var length = eventParam.length;
                var buffer_count = eventParam.buffer_count;


                switch (@event)
                {
                    case "VideoFrameObserver_onCaptureVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            VIDEO_SOURCE_TYPE type = (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "type");
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "videoFrame");
                            VideoFrame videoFrame1 = GetVideoFrame("", 0);
                            bool needClear = ProcessVideoFrameReceived(ref videoFrame, ref videoFrame1);
                            bool result = videoFrameObserver.OnCaptureVideoFrame(type, videoFrame1);
                            if (needClear) AgoraRtcNative.ClearVideoFrame(ref videoFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_onPreEncodeVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            VIDEO_SOURCE_TYPE type = (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "type");
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "videoFrame");
                            VideoFrame videoFrame1 = GetVideoFrame("", 1);
                            bool needClear = ProcessVideoFrameReceived(ref videoFrame, ref videoFrame1);
                            bool result = videoFrameObserver.OnPreEncodedVideoFrame(type, videoFrame1);
                            if (needClear) AgoraRtcNative.ClearVideoFrame(ref videoFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_onMediaPlayerVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "videoFrame");
                            int mediaPlayerId = (int)AgoraJson.GetData<int>(jsonData, "mediaPlayerId");
                            VideoFrame videoFrame1 = GetVideoFrame("", 2);
                            ConvertIrisVideoFrameToVideoFrame(ref videoFrame, ref videoFrame1);
                            bool result = videoFrameObserver.OnMediaPlayerVideoFrame(videoFrame1, mediaPlayerId);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_onRenderVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            string channelId = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            uint remoteUid = (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid");
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "videoFrame");
                            VideoFrame videoFrame1 = GetVideoFrame("", 2);
                            bool needClear = ProcessVideoFrameReceived(ref videoFrame, ref videoFrame1);
                            bool result = videoFrameObserver.OnRenderVideoFrame(channelId, remoteUid, videoFrame1);
                            if (needClear) AgoraRtcNative.ClearVideoFrame(ref videoFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_onTranscodedVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "videoFrame");
                            VideoFrame videoFrame1 = GetVideoFrame("", 2);
                            bool needClear = ProcessVideoFrameReceived(ref videoFrame, ref videoFrame1);
                            bool result = videoFrameObserver.OnTranscodedVideoFrame(videoFrame1);
                            if (needClear) AgoraRtcNative.ClearVideoFrame(ref videoFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;

                    case "VideoFrameObserver_getVideoFormatPreference":
                        {
                            VIDEO_OBSERVER_FRAME_TYPE result = videoFrameObserver.GetVideoFormatPreference();
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_getObservedFramePosition":
                        {
                            VIDEO_OBSERVER_POSITION result = videoFrameObserver.GetObservedFramePosition();
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    default:
                        AgoraLog.LogError("unexpected event: " + @event);
                        break;
                }

            }
        }

        private static void CreateDefaultReturn(ref IrisCEventParam eventParam, IntPtr param)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
                case "VideoFrameObserver_onCaptureVideoFrame":
                case "VideoFrameObserver_onPreEncodeVideoFrame":
                    {
                        bool result = true;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                case "VideoFrameObserver_getVideoFormatPreference":
                    {
                        VIDEO_OBSERVER_FRAME_TYPE result = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                case "VideoFrameObserver_getObservedFramePosition":
                    {
                        VIDEO_OBSERVER_POSITION result = VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER
                                                         | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        //        [MonoPInvokeCallback(typeof(Func_VideoCaptureLocal_Native))]
        //#endif
        //        internal static bool OnCaptureVideoFrame(IntPtr videoFramePtr, IntPtr videoFrameConfig)
        //        {
        //            var videoFrameBufferConfig = (IrisVideoFrameBufferConfig)(Marshal.PtrToStructure(videoFrameConfig, typeof(IrisVideoFrameBufferConfig)) ??
        //                                                                   new IrisVideoFrameBufferConfig());
        //            var config = new VideoFrameBufferConfig();
        //            config.type = (VIDEO_SOURCE_TYPE)videoFrameBufferConfig.type;
        //            config.id = videoFrameBufferConfig.id;
        //            config.key = videoFrameBufferConfig.key;

        //            try
        //            {
        //                return VideoFrameObserver == null ||
        //                    VideoFrameObserver.OnCaptureVideoFrame(ProcessVideoFrameReceived(videoFramePtr, "", 0), config);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IVideoFrameObserver.OnCaptureVideoFrame: " + e);
        //                return true;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        //        [MonoPInvokeCallback(typeof(Func_VideoCaptureLocal_Native))]
        //#endif
        //        internal static bool OnPreEncodeVideoFrame(IntPtr videoFramePtr, IntPtr videoFrameConfig)
        //        {
        //            var videoFrameBufferConfig = (IrisVideoFrameBufferConfig)(Marshal.PtrToStructure(videoFrameConfig, typeof(IrisVideoFrameBufferConfig)) ??
        //                                                                   new IrisVideoFrameBufferConfig());
        //            var config = new VideoFrameBufferConfig();
        //            config.type = (VIDEO_SOURCE_TYPE)videoFrameBufferConfig.type;
        //            config.id = videoFrameBufferConfig.id;
        //            config.key = videoFrameBufferConfig.key;

        //            try
        //            {
        //                return VideoFrameObserver == null ||
        //                    VideoFrameObserver.OnPreEncodeVideoFrame(ProcessVideoFrameReceived(videoFramePtr, "", 1), config);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IVideoFrameObserver.OnPreEncodeVideoFrame: " + e);
        //                return true;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        //        [MonoPInvokeCallback(typeof(Func_VideoFrameRemote_Native))]
        //#endif
        //        internal static bool OnRenderVideoFrame(string channel_id, uint uid, IntPtr videoFramePtr)
        //        {
        //            try
        //            {
        //                return VideoFrameObserver == null ||
        //                    VideoFrameObserver.OnRenderVideoFrame(channel_id, uid, ProcessVideoFrameReceived(videoFramePtr, "", 2));
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IVideoFrameObserver.OnRenderVideoFrame: " + e);
        //                return true;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        //        [MonoPInvokeCallback(typeof(Func_Uint32_t_Native))]
        //#endif
        //        internal static uint GetObservedFramePosition()
        //        {
        //            if (VideoFrameObserver == null)
        //                return (uint)(VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER |
        //                               VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER);

        //            try
        //            {
        //                return (uint)VideoFrameObserver.GetObservedFramePosition();
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IVideoFrameObserver.GetObservedFramePosition: " + e);
        //                return 0;
        //            }
        //        }
    }
}