namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Provides callback events for audio and video recording.
    /// </summary>
    ///
    public abstract class IMediaRecorderObserver
    {
        ///
        /// <summary>
        /// Occurs when the recording state changes.
        /// When the recording state changes, the SDK triggers this callback to report the current recording state and the reason for the change.
        /// </summary>
        ///
        /// <param name="channelId"> The channel name.</param>
        ///
        /// <param name="uid"> The user ID.</param>
        ///
        /// <param name="state"> The current recording state. See RecorderState .</param>
        ///
        /// <param name="error"> The reason for the state change. See RecorderErrorCode .</param>
        ///
        public virtual void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderErrorCode error) {}

        ///
        /// <summary>
        /// Occurs when the recording information is updated.
        /// After you successfully enable the audio and video recording, the SDK periodically triggers this callback based on the value of recorderInfoUpdateInterval set in MediaRecorderConfiguration . This callback reports the file name, duration, and size of the current recording file.
        /// </summary>
        ///
        /// <param name="uid"> The user ID.</param>
        ///
        /// <param name="channelId"> The channel name.</param>
        ///
        /// <param name="info"> The information about the file that is recorded. See RecorderInfo .</param>
        ///
        public virtual void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info) {}
    };
}