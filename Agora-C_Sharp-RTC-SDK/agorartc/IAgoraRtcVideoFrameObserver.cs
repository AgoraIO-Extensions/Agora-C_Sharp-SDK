//  IAgoraRtcVideoFrameObserver.cs
//
//  Created by YuGuo Chen on October 6, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    public class IAgoraRtcVideoFrameObserver
    {
        public virtual bool OnCaptureVideoFrame(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            return true;
        }

        public virtual bool OnPreEncodeVideoFrame(VideoFrame videoFrame)
        {
            return true;
        }
        
        public virtual bool OnRenderVideoFrame(uint uid, VideoFrame videoFrame)
        {
            return true;
        }
        
        public virtual VIDEO_FRAME_TYPE GetVideoFormatPreference()
        {
            return VIDEO_FRAME_TYPE.FRAME_TYPE_RGBA;
        }
        
        public virtual VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER;
        }

        public virtual bool IsMultipleChannelFrameWanted()
        {
            return true;
        }

        public virtual bool OnRenderVideoFrameEx(string channelId, uint uid, VideoFrame videoFrame)
        {
            return true;
        }
    }
}