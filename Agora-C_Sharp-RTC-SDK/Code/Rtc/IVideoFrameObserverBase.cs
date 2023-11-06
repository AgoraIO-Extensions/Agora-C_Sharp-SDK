namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The IVideoFrameObserver class.
    /// </summary>
    ///
    public abstract class IVideoFrameObserverBase
    {
        #region terra IVideoFrameObserverBase
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

        public virtual bool OnTranscodedVideoFrame(VideoFrame videoFrame)
        {
            return true;
        }


        #endregion terra IVideoFrameObserverBase
    }
}