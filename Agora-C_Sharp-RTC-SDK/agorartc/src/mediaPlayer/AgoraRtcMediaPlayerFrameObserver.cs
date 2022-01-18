//  AgoraRtcMediaPlayerFrameObserver.cs
//
//  Created by YuGuo Chen on December 14, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

#define __UNITY__

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if __UNITY__
using AOT;
#endif

namespace agora.rtc
{
    internal static class AgoraRtcMediaPlayerAudioFrameObserverNative
    {
        internal static IAgoraRtcMediaPlayerAudioFrameObserver AudioFrameObserver;
        private static class LocalAudioPcmFrames
        {
            internal static readonly AudioPcmFrame AudioPcmFrame = new AudioPcmFrame();
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_AudioOnFrame_Native))]
#endif
        internal static bool OnFrame(IntPtr audioFramePtr, int mediaPlayerId)
        {
            var audioPcmFrame = (IrisAudioPcmFrame) (Marshal.PtrToStructure(audioFramePtr, typeof(IrisAudioPcmFrame)) ??
                                                    new IrisAudioPcmFrame());
            var localAudioPcmFrame = new AudioPcmFrame();

            localAudioPcmFrame = LocalAudioPcmFrames.AudioPcmFrame;

            if (localAudioPcmFrame.num_channels_ != audioPcmFrame.num_channels_ ||
                localAudioPcmFrame.samples_per_channel_ != audioPcmFrame.samples_per_channel_)
            {
                localAudioPcmFrame.data_ = new Int16[3840];
            }
            // if (audioFrame.buffer != IntPtr.Zero)
            //     Marshal.Copy(audioFrame.buffer, localAudioFrame.buffer, 0, (int) audioFrame.buffer_length);
            localAudioPcmFrame.data_ = audioPcmFrame.data_;
            localAudioPcmFrame.num_channels_ = audioPcmFrame.num_channels_;
            localAudioPcmFrame.capture_timestamp = audioPcmFrame.capture_timestamp;
            localAudioPcmFrame.sample_rate_hz_ = audioPcmFrame.sample_rate_hz_;
            localAudioPcmFrame.samples_per_channel_ = audioPcmFrame.samples_per_channel_;

            return AudioFrameObserver == null || 
                AudioFrameObserver.OnFrame(localAudioPcmFrame, mediaPlayerId);
        }
    }

    internal static class AgoraRtcMediaPlayerVideoFrameObserverNative
    {
        internal static IAgoraRtcMediaPlayerVideoFrameObserver VideoFrameObserver;
        private static class LocalVideoFrames
        {
            internal static readonly VideoFrame VideoFrame = new VideoFrame();
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_VideoCaptureLocal_Native))]
#endif
        internal static bool OnFrame(IntPtr videoFramePtr, IntPtr configPtr)
        {
            var videoFrame = (IrisVideoFrame) (Marshal.PtrToStructure(videoFramePtr, typeof(IrisVideoFrame)) ?? 
                new IrisVideoFrame());
            
            var localVideoFrame = new VideoFrame();

            // var ifConverted = VideoFrameObserver.GetVideoFormatPreference() != VIDEO_FRAME_TYPE.FRAME_TYPE_YUV420;
            // var videoFrameConverted = ifConverted
            //     ? AgoraRtcNative.ConvertVideoFrame(ref videoFrame, VideoFrameObserver.GetVideoFormatPreference())
            //     : videoFrame;
            
            localVideoFrame = LocalVideoFrames.VideoFrame;

            if (videoFrame.y_buffer != IntPtr.Zero)
                Marshal.Copy(videoFrame.y_buffer, localVideoFrame.yBuffer, 0,
                    (int) videoFrame.y_buffer_length);
            if (videoFrame.u_buffer != IntPtr.Zero)
                Marshal.Copy(videoFrame.u_buffer, localVideoFrame.uBuffer, 0,
                    (int) videoFrame.u_buffer_length);
            if (videoFrame.v_buffer != IntPtr.Zero)
                Marshal.Copy(videoFrame.v_buffer, localVideoFrame.vBuffer, 0,
                    (int) videoFrame.v_buffer_length);
            localVideoFrame.width = videoFrame.width;
            localVideoFrame.height = videoFrame.height;
            localVideoFrame.yBufferPtr = videoFrame.y_buffer;
            localVideoFrame.yStride = videoFrame.y_stride;
            localVideoFrame.uBufferPtr = videoFrame.u_buffer;
            localVideoFrame.uStride = videoFrame.u_stride;
            localVideoFrame.vBufferPtr = videoFrame.v_buffer;
            localVideoFrame.vStride = videoFrame.v_stride;
            localVideoFrame.rotation = videoFrame.rotation;
            localVideoFrame.renderTimeMs = videoFrame.render_time_ms;
            localVideoFrame.avsync_type = videoFrame.av_sync_type;

            //if (ifConverted) AgoraRtcNative.ClearVideoFrame(ref videoFrameConverted);
            
            
            var videobufferConfig = (IrisVideoFrameBufferConfig) (Marshal.PtrToStructure(configPtr, typeof(IrisVideoFrameBufferConfig)) ?? 
                                                                 new IrisVideoFrameBufferConfig());
            var config = new VideoFrameBufferConfig();
            config.type = (VIDEO_SOURCE_TYPE) videobufferConfig.type;
            config.id = videobufferConfig.id;
            config.key = videobufferConfig.key;
            
            return VideoFrameObserver == null || VideoFrameObserver.OnFrame(localVideoFrame, config);
        }
    }

    internal static class AgoraRtcMediaPlayerCustomDataProviderNative
    {
        internal static IAgoraRtcMediaPlayerCustomDataProvider CustomDataProvider;

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_OnSeek_Native))]
#endif
        internal static Int64 OnSeek(Int64 offset, int whence, int playerId)
        {
            return CustomDataProvider == null ? -1 : 
                CustomDataProvider.OnSeek(offset, whence, playerId);
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_onReadData_Native))]
#endif
        internal static int OnReadData(IntPtr buffer, int bufferSize, int playerId)
        {
            byte[] Buffer = new byte[bufferSize];
            if (buffer != IntPtr.Zero)
            {
                Marshal.Copy(buffer, Buffer, 0, (int) bufferSize);
            }
            return CustomDataProvider == null ? -1 :
                CustomDataProvider.OnReadData(Buffer, bufferSize, playerId);
        }
    }
}