//  IAgoraRtcVideoFrameObserver.cs
//
//  Created by Yiqing Huang on June 9, 2021.
//  Modified by Yiqing Huang on June 11, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//


namespace agora.rtc
{
    public class IAgoraRtcVideoFrameObserver
    {
        public virtual bool OnCaptureVideoFrame(VideoFrame videoFrame)
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