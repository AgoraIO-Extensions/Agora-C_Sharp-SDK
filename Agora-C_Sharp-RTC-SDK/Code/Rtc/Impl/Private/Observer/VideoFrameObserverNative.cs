﻿using System;
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
            internal static readonly VideoFrame MediaPlayerVideoFrame = new VideoFrame();
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
                        localVideoFrame = LocalVideoFrames.PreEncodeVideoFrame;
                        break;
                    case 2:
                        localVideoFrame = LocalVideoFrames.MediaPlayerVideoFrame;
                        break;
                    case 3:
                        localVideoFrame = LocalVideoFrames.RenderVideoFrame;
                        break;
                    case 4:
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
            CalculationYUVLength(ref videoFrameConverted);

            if (mode == OBSERVER_MODE.RAW_DATA)
            {
                if (localVideoFrame.height != videoFrameConverted.height ||
                localVideoFrame.yStride != videoFrameConverted.yStride ||
                localVideoFrame.uStride != videoFrameConverted.uStride ||
                localVideoFrame.vStride != videoFrameConverted.vStride
                )
                {
                    localVideoFrame.yBuffer = new byte[videoFrameConverted.y_buffer_length];
                    localVideoFrame.uBuffer = new byte[videoFrameConverted.u_buffer_length];
                    localVideoFrame.vBuffer = new byte[videoFrameConverted.v_buffer_length];
                    localVideoFrame.alphaBuffer = new byte[videoFrameConverted.alpha_buffer_length];
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
                if (videoFrameConverted.alphaBuffer != IntPtr.Zero)
                    Marshal.Copy(videoFrameConverted.alphaBuffer, localVideoFrame.alphaBuffer, 0,
                       (int)videoFrameConverted.alpha_buffer_length);
            }

            localVideoFrame.type = (VIDEO_PIXEL_FORMAT)videoFrameConverted.type;
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
            localVideoFrame.alphaBufferPtr = videoFrameConverted.alphaBuffer;
        }


        private static void CalculationYUVLength(ref IrisVideoFrame videoFrame)
        {
            if (videoFrame.type == VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420)
            {
                videoFrame.y_buffer_length = (uint)(videoFrame.yStride * videoFrame.height);
                videoFrame.u_buffer_length = (uint)(videoFrame.uStride * videoFrame.height / 2);
                videoFrame.v_buffer_length = (uint)(videoFrame.vStride * videoFrame.height / 2);
                videoFrame.alpha_buffer_length = videoFrame.y_buffer_length;
            }
            else if (videoFrame.type == VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV422)
            {
                videoFrame.y_buffer_length = (uint)(videoFrame.yStride * videoFrame.height);
                videoFrame.u_buffer_length = (uint)(videoFrame.uStride * videoFrame.height);
                videoFrame.v_buffer_length = (uint)(videoFrame.vStride * videoFrame.height);
                videoFrame.alpha_buffer_length = videoFrame.y_buffer_length;
            }
            else
            {
                videoFrame.y_buffer_length = (uint)(videoFrame.width * videoFrame.height * 4);
                videoFrame.u_buffer_length = 0;
                videoFrame.v_buffer_length = 0;
                videoFrame.alpha_buffer_length = videoFrame.y_buffer_length;
            }
        }


        //private static bool ProcessVideoFrameReceived(ref IrisVideoFrame videoFrame, ref VideoFrame localVideoFrame)
        //{
        //    //var videoFrame = (IrisVideoFrame)(Marshal.PtrToStructure(videoFramePtr, typeof(IrisVideoFrame)) ??
        //    //    new IrisVideoFrame());
        //    CalculationYUVLength(ref videoFrame);

        //    var ifConverted = false;// videoFrameObserver.GetVideoFormatPreference() != videoFrame.type;

        //    if (ifConverted)
        //    {
        //        IrisVideoFrame videoFrameConverted = new IrisVideoFrame();
        //        videoFrameConverted.type = videoFrameObserver.GetVideoFormatPreference();
        //        AgoraRtcNative.AlignAndConvertVideoFrame(ref videoFrameConverted, ref videoFrame);
        //        ConvertIrisVideoFrameToVideoFrame(ref videoFrameConverted, ref localVideoFrame);
        //        videoFrame = videoFrameConverted;
        //        return true;
        //    }
        //    else
        //    {
        //        ConvertIrisVideoFrameToVideoFrame(ref videoFrame, ref localVideoFrame);
        //    }

        //    return false;
        //}


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
             
                switch (@event)
                {
                    case "VideoFrameObserver_onCaptureVideoFrame":
                        {
                            LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "videoFrame");
                            VIDEO_SOURCE_TYPE sourceType = (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "sourceType");
                            VideoFrame videoFrame1 = GetVideoFrame("", 0);
                            ConvertIrisVideoFrameToVideoFrame(ref videoFrame,ref videoFrame1);
                            bool result = videoFrameObserver.OnCaptureVideoFrame(sourceType, videoFrame1);
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
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "videoFrame");
                            VIDEO_SOURCE_TYPE sourceType = (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "sourceType");
                            VideoFrame videoFrame1 = GetVideoFrame("", 1);
                            ConvertIrisVideoFrameToVideoFrame(ref videoFrame, ref videoFrame1);
                            bool result = videoFrameObserver.OnPreEncodeVideoFrame(sourceType, videoFrame1);
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
                            IrisVideoFrame videoFrame = AgoraJson.JsonToStruct<IrisVideoFrame>(jsonData, "videoFrame");
                            string channelId = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            uint remoteUid = (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid");
                            VideoFrame videoFrame1 = GetVideoFrame("", 3);
                            ConvertIrisVideoFrameToVideoFrame(ref videoFrame, ref videoFrame1);
                            bool result = videoFrameObserver.OnRenderVideoFrame(channelId, remoteUid, videoFrame1);
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

                            VideoFrame videoFrame1 = GetVideoFrame("", 4);
                            ConvertIrisVideoFrameToVideoFrame(ref videoFrame, ref videoFrame1);
                            bool result = videoFrameObserver.OnTranscodedVideoFrame(videoFrame1);
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
                case "VideoFrameObserver_onMediaPlayerVideoFrame":
                case "VideoFrameObserver_onRenderVideoFrame":
                case "VideoFrameObserver_onTranscodedVideoFrame":
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

    }
}