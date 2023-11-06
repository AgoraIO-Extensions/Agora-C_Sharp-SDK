namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The IVideoFrameObserver class.
    /// </summary>
    ///
    public abstract class IVideoFrameObserver : IVideoFrameObserverBase
    {
        #region terra IVideoFrameObserver
        public virtual bool OnRenderVideoFrame(string channelId, uint remoteUid, VideoFrame videoFrame)
        {
            return true;
        }
        #endregion terra IVideoFrameObserver
    }
}