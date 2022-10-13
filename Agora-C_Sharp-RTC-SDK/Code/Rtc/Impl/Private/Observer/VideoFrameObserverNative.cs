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
        internal static OBSERVER_MODE mode = OBSERVER_MODE.INTPTR;
        internal static IVideoFrameObserver VideoFrameObserver;

        private static class LocalVideoFrames
        {
            internal static readonly VideoFrame CaptureVideoFrame = new VideoFrame();
            internal static readonly VideoFrame PreEncodeVideoFrame = new VideoFrame();
            internal static readonly VideoFrame RenderVideoFrame = new VideoFrame();
            internal static readonly Dictionary<string, Dictionary<uint, VideoFrame>> RenderVideoFrameEx = 
                new Dictionary<string, Dictionary<uint, VideoFrame>>();
        }

        private static VideoFrame ProcessVideoFrameReceived(IntPtr videoFramePtr, string channelId, uint uid)
        {
            var videoFrame = (IrisVideoFrame)(Marshal.PtrToStructure(videoFramePtr, typeof(IrisVideoFrame)) ??
                new IrisVideoFrame());

            var localVideoFrame = new VideoFrame();

            var ifConverted = VideoFrameObserver.GetVideoFormatPreference() != VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;
            var videoFrameConverted = new IrisVideoFrame();
            videoFrameConverted.type = VideoFrameObserver.GetVideoFormatPreference();

            if (ifConverted)
            {
                AgoraRtcNative.ConvertVideoFrame(ref videoFrameConverted, ref videoFrame);
            }

            if (channelId == "")
            {
                switch(uid)
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

            if (ifConverted) AgoraRtcNative.ClearVideoFrame(ref videoFrameConverted);

            return localVideoFrame;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_VideoCaptureLocal_Native))]
#endif
        internal static bool OnCaptureVideoFrame(IntPtr videoFramePtr, IntPtr videoFrameConfig)
        {
            var videoFrameBufferConfig = (IrisVideoFrameBufferConfig) (Marshal.PtrToStructure(videoFrameConfig, typeof(IrisVideoFrameBufferConfig)) ?? 
                                                                   new IrisVideoFrameBufferConfig());
            var config = new VideoFrameBufferConfig();
            config.type = (VIDEO_SOURCE_TYPE) videoFrameBufferConfig.type;
            config.id = videoFrameBufferConfig.id;
            config.key = videoFrameBufferConfig.key;
            
            try
            {
                return VideoFrameObserver == null || 
                    VideoFrameObserver.OnCaptureVideoFrame(ProcessVideoFrameReceived(videoFramePtr, "", 0), config);
            }
            catch(Exception e)
            {
                AgoraLog.LogError("[Exception] IVideoFrameObserver.OnCaptureVideoFrame: " + e);
                return true;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_VideoCaptureLocal_Native))]
#endif
        internal static bool OnPreEncodeVideoFrame(IntPtr videoFramePtr, IntPtr videoFrameConfig)
        {
            var videoFrameBufferConfig = (IrisVideoFrameBufferConfig) (Marshal.PtrToStructure(videoFrameConfig, typeof(IrisVideoFrameBufferConfig)) ?? 
                                                                   new IrisVideoFrameBufferConfig());
            var config = new VideoFrameBufferConfig();
            config.type = (VIDEO_SOURCE_TYPE) videoFrameBufferConfig.type;
            config.id = videoFrameBufferConfig.id;
            config.key = videoFrameBufferConfig.key;

            try
            {
                return VideoFrameObserver == null ||
                    VideoFrameObserver.OnPreEncodeVideoFrame(ProcessVideoFrameReceived(videoFramePtr, "", 1), config);
            }
            catch(Exception e)
            {
                AgoraLog.LogError("[Exception] IVideoFrameObserver.OnPreEncodeVideoFrame: " + e);
                return true;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_VideoFrameRemote_Native))]
#endif
        internal static bool OnRenderVideoFrame(string channel_id, uint uid, IntPtr videoFramePtr)
        {
            try
            {
                return VideoFrameObserver == null ||
                    VideoFrameObserver.OnRenderVideoFrame(channel_id, uid, ProcessVideoFrameReceived(videoFramePtr, "", 2));
            }
            catch(Exception e)
            {
                AgoraLog.LogError("[Exception] IVideoFrameObserver.OnRenderVideoFrame: " + e);
                return true;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_Uint32_t_Native))]
#endif
        internal static uint GetObservedFramePosition()
        {
            if (VideoFrameObserver == null)
                return (uint) (VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER |
                               VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER);

            try
            {
                return (uint) VideoFrameObserver.GetObservedFramePosition();
            }
            catch(Exception e)
            {
                AgoraLog.LogError("[Exception] IVideoFrameObserver.GetObservedFramePosition: " + e);
                return 0;
            }
        }
    }
}