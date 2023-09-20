namespace Agora.Rtc
{
    /* class_ivideoframeobserver */
    public abstract class IVideoFrameObserver
    {
#region terra IVideoFrameObserver

        public virtual bool OnCaptureVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            return true;
        }

        public virtual bool OnPreEncodeVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            return true;
        }

        public virtual bool OnMediaPlayerVideoFrame(VideoFrame videoFrame, int mediaPlayerId)
        {
            return true;
        }

        public virtual bool OnRenderVideoFrame(string channelId, uint remoteUid, VideoFrame videoFrame)
        {
            return true;
        }

        public virtual bool OnTranscodedVideoFrame(VideoFrame videoFrame)
        {
            return true;
        }

#endregion terra IVideoFrameObserver
    }
}