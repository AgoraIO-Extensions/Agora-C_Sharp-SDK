//  AgoraRtcVideoEncodedImageReceiver.cs
//
//  Created by YuGuo Chen on October 9, 2021.
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
    internal static class AgoraRtcVideoEncodedImageReceiver
    {
        internal static IAgoraRtcVideoEncodedImageReceiver VideoEncodedImageReceiver;
        private static class LocalVideoEncodedVideoFrameInfo
        {
            internal static readonly EncodedVideoFrameInfo info = new EncodedVideoFrameInfo();

        }


#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_EncodedVideoImageReceived_Native))]
#endif
        internal static bool OnEncodedVideoImageReceived(IntPtr imageBuffer, UInt64 length, IntPtr videoEncodedFrameInfoPtr)
        {
            var videoEncodedFrameInfo = (IrisEncodedVideoFrameInfo) (Marshal.PtrToStructure(videoEncodedFrameInfoPtr, typeof(IrisEncodedVideoFrameInfo)) ?? 
                new IrisEncodedVideoFrameInfo());
            
            var localVideoEncodedFrameInfo = new EncodedVideoFrameInfo();
            localVideoEncodedFrameInfo = LocalVideoEncodedVideoFrameInfo.info;

            localVideoEncodedFrameInfo.codecType = (VIDEO_CODEC_TYPE) videoEncodedFrameInfo.codecType;
            localVideoEncodedFrameInfo.width = videoEncodedFrameInfo.width;
            localVideoEncodedFrameInfo.height = videoEncodedFrameInfo.height;
            localVideoEncodedFrameInfo.framesPerSecond = videoEncodedFrameInfo.framesPerSecond;
            localVideoEncodedFrameInfo.frameType = (VIDEO_FRAME_TYPE_NATIVE) videoEncodedFrameInfo.frameType;
            localVideoEncodedFrameInfo.rotation = (VIDEO_ORIENTATION) videoEncodedFrameInfo.rotation;
            localVideoEncodedFrameInfo.trackId = videoEncodedFrameInfo.trackId;
            localVideoEncodedFrameInfo.renderTimeMs = videoEncodedFrameInfo.renderTimeMs;
            localVideoEncodedFrameInfo.internalSendTs = videoEncodedFrameInfo.internalSendTs;
            localVideoEncodedFrameInfo.uid = videoEncodedFrameInfo.uid;
            localVideoEncodedFrameInfo.streamType = (VIDEO_STREAM_TYPE) videoEncodedFrameInfo.streamType;

            byte[] Buffer = new byte[length];
            if (imageBuffer != IntPtr.Zero)
            {
                Marshal.Copy(imageBuffer, Buffer, 0, (int) length);
            }

            return VideoEncodedImageReceiver == null || 
                VideoEncodedImageReceiver.OnEncodedVideoImageReceived(Buffer, length, localVideoEncodedFrameInfo);
        }
    }
}