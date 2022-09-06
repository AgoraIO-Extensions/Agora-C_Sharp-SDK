namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The IMediaRecorderObserver class.
    /// </summary>
    ///
    public abstract class IMediaRecorderObserver
    {
        ///
        /// <summary>
        /// Occurs when the recording state changes.
        /// When the local audio or video recording state changes, the SDK triggers this callback to report the current recording state and the reason for the change.
        /// </summary>
        ///
        /// <param name="state"> The current recording state. See RecorderState .</param>
        ///
        /// <param name="error"> The reason for the state change. See RecorderErrorCode .</param>
        ///
        public virtual void OnRecorderStateChanged(RecorderState state, RecorderErrorCode error) {}

        ///
        /// <summary>
        /// Occurs when the recording information is updated.
        /// After you successfully enable the local audio and video recording, the SDK periodically triggers this callback based on the value of recorderInfoUpdateInterval set in MediaRecorderConfiguration . This callback reports the file name, duration, and size of the current recording file.
        /// </summary>
        ///
        /// <param name="info"> The information about the file that is recorded. See RecorderInfo .</param>
        ///
        public virtual void OnRecorderInfoUpdated(RecorderInfo info) {}
    };
}