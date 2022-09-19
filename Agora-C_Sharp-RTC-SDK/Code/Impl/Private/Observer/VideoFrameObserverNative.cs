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
            internal static readonly VideoFrame PreEncodeVideoFrame = new VideoFrame();
            internal static readonly VideoFrame RenderVideoFrame = new VideoFrame();
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
                        localVideoFrame = LocalVideoFrames.PreEncodeVideoFrame;
                        break;
                    case 2:
                        localVideoFrame = LocalVideoFrames.RenderVideoFrame;
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
                localVideoFrame.yStride != videoFrameConverted.y_stride ||
                localVideoFrame.uStride != videoFrameConverted.u_stride ||
                localVideoFrame.vStride != videoFrameConverted.v_stride)
                {
                    localVideoFrame.yBuffer = new byte[videoFrameConverted.y_buffer_length];
                    localVideoFrame.uBuffer = new byte[videoFrameConverted.u_buffer_length];
                    localVideoFrame.vBuffer = new byte[videoFrameConverted.v_buffer_length];
                }

                if (videoFrameConverted.y_buffer != IntPtr.Zero)
                    Marshal.Copy(videoFrameConverted.y_buffer, localVideoFrame.yBuffer, 0,
                        (int)videoFrameConverted.y_buffer_length);
                if (videoFrameConverted.u_buffer != IntPtr.Zero)
                    Marshal.Copy(videoFrameConverted.u_buffer, localVideoFrame.uBuffer, 0,
                        (int)videoFrameConverted.u_buffer_length);
                if (videoFrameConverted.v_buffer != IntPtr.Zero)
                    Marshal.Copy(videoFrameConverted.v_buffer, localVideoFrame.vBuffer, 0,
                        (int)videoFrameConverted.v_buffer_length);
            }

            localVideoFrame.width = videoFrameConverted.width;
            localVideoFrame.height = videoFrameConverted.height;
            localVideoFrame.yBufferPtr = videoFrameConverted.y_buffer;
            localVideoFrame.yStride = videoFrameConverted.y_stride;
            localVideoFrame.uBufferPtr = videoFrameConverted.u_buffer;
            localVideoFrame.uStride = videoFrameConverted.u_stride;
            localVideoFrame.vBufferPtr = videoFrameConverted.v_buffer;
            localVideoFrame.vStride = videoFrameConverted.v_stride;
            localVideoFrame.rotation = videoFrameConverted.rotation;
            localVideoFrame.renderTimeMs = videoFrameConverted.render_time_ms;
            localVideoFrame.avsync_type = videoFrameConverted.av_sync_type;
            localVideoFrame.metadata_size = videoFrameConverted.metadata_size;
            localVideoFrame.metadata_buffer = videoFrameConverted.metadata_buffer;
            localVideoFrame.sharedContext = videoFrameConverted.sharedContext;
            localVideoFrame.matrix = videoFrameConverted.matrix;
            localVideoFrame.textureId = videoFrameConverted.textureId;
        }

        private static VideoFrame ProcessVideoFrameReceived(IrisVideoFrame videoFrame, string channelId, uint uid)
        {
            //var videoFrame = (IrisVideoFrame)(Marshal.PtrToStructure(videoFramePtr, typeof(IrisVideoFrame)) ??
            //    new IrisVideoFrame());

            var ifConverted = videoFrameObserver.GetVideoFormatPreference() != VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;
            var localVideoFrame = GetVideoFrame(channelId, uid);

            if (ifConverted)
            {
                IrisVideoFrame videoFrameConverted = new IrisVideoFrame();
                videoFrameConverted.type = videoFrameObserver.GetVideoFormatPreference();
                AgoraRtcNative.ConvertVideoFrame(ref videoFrameConverted, ref videoFrame);
                ConvertIrisVideoFrameToVideoFrame(ref videoFrameConverted, ref localVideoFrame);
                AgoraRtcNative.ClearVideoFrame(ref videoFrameConverted);
            }
            else
            {
                ConvertIrisVideoFrameToVideoFrame(ref videoFrame, ref localVideoFrame);
            }

            return localVideoFrame;
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

                IntPtr[] bufferArray = null;
                int[] lengthArray = null;

                if (buffer_count > 0)
                {
                    bufferArray = new IntPtr[buffer_count];
                    Marshal.Copy(buffer, bufferArray, 0, (int)buffer_count);
                    lengthArray = new int[buffer_count];
                    Marshal.Copy(length, lengthArray, 0, (int)buffer_count);
                }



                switch (@event)
                {
                    case "VideoFrameObserver_onCaptureVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "video_frame");
                            VideoFrameBufferConfig config = AgoraJson.JsonToStruct<VideoFrameBufferConfig>(jsonData, "config");
                            VideoFrame videoFrame1 = ProcessVideoFrameReceived(videoFrame, "", 0);
                            bool result = videoFrameObserver.OnCaptureVideoFrame(videoFrame1, config);
                            var p = new { result };
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_OnPreEncodeVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "video_frame");
                            VideoFrameBufferConfig config = AgoraJson.JsonToStruct<VideoFrameBufferConfig>(jsonData, "config");
                            VideoFrame videoFrame1 = ProcessVideoFrameReceived(videoFrame, "", 1);
                            bool result = videoFrameObserver.OnPreEncodeVideoFrame(videoFrame1, config);
                            var p = new { result };
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_onRenderVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "video_frame");
                            VideoFrame videoFrame1 = ProcessVideoFrameReceived(videoFrame, "", 2);
                            string channel_id = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            uint uid = (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid");

                            bool result = videoFrameObserver.OnRenderVideoFrame(channel_id, uid, videoFrame1);
                            var p = new { result };
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_getVideoFormatPreference":
                        {
                            VIDEO_OBSERVER_FRAME_TYPE result = videoFrameObserver.GetVideoFormatPreference();
                            var p = new { result };
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "VideoFrameObserver_getObservedFramePosition":
                        {
                            VIDEO_OBSERVER_POSITION result = videoFrameObserver.GetObservedFramePosition();
                            var p = new { result };
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
                case "VideoFrameObserver_OnPreEncodeVideoFrame":
                case "VideoFrameObserver_onRenderVideoFrame":
                    {
                        bool result = true;
                        var p = new { result };
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                case "VideoFrameObserver_getVideoFormatPreference":
                    {
                        VIDEO_OBSERVER_FRAME_TYPE result = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
                        var p = new { result };
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
                        var p = new { result };
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