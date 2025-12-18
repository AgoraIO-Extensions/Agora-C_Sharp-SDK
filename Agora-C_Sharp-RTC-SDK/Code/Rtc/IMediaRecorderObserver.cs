namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMediaRecorderObserver
    {
        ///
        /// @ignore
        ///
        public virtual void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderErrorCode error) {}

        ///
        /// @ignore
        ///
        public virtual void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info) {}
    };
}