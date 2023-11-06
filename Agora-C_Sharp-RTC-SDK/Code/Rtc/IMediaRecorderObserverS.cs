namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMediaRecorderObserverS
    {
        #region terra IMediaRecorderObserverS
        public virtual void OnRecorderStateChanged(string channelId, string userId, RecorderState state, RecorderErrorCode error)
        {
        }

        public virtual void OnRecorderInfoUpdated(string channelId, string userId, RecorderInfo info)
        {
        }
        #endregion terra IMediaRecorderObserverS
    };
}