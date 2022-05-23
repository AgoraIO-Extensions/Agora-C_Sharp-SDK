namespace agora.rtc
{
    public class IVideoFrameObserver
    {
        public virtual bool OnCaptureVideoFrame(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            return true;
        }

        public virtual bool OnPreEncodeVideoFrame(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            return true;
        }
        
        public virtual bool OnRenderVideoFrame(uint uid, VideoFrame videoFrame)
        {
            return true;
        }
        
        public virtual VIDEO_OBSERVER_FRAME_TYPE GetVideoFormatPreference()
        {
            return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
        }
        
        public virtual VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER;
        }

        public virtual bool IsMultipleChannelFrameWanted()
        {
            return true;
        }
    }
}