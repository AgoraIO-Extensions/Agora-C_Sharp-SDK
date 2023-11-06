namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The IVideoFrameObserver class.
    /// </summary>
    ///
    public abstract class IVideoFrameObserverS : IVideoFrameObserverBase
    {
        #region terra IVideoFrameObserverS
        public virtual bool OnRenderVideoFrame(string channelId, string remoteUserId, VideoFrame videoFrame)
        {
            return true;
        }
        #endregion terra IVideoFrameObserverS
    }
}