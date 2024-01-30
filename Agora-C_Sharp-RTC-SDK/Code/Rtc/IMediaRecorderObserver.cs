namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMediaRecorderObserver
    {
        #region terra IMediaRecorderObserver
        ///
        /// @ignore
        ///
        public virtual void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderReasonCode reason)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info)
        {
        }
        #endregion terra IMediaRecorderObserver
    };
}