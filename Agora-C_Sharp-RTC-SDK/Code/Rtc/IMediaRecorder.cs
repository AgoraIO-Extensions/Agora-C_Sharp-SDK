namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMediaRecorder
    {
        ///
        /// @ignore
        ///
        public abstract int SetMediaRecorderObserver(IMediaRecorderObserver callback);

        ///
        /// @ignore
        ///
        public abstract int StartRecording(MediaRecorderConfiguration config);

        ///
        /// @ignore
        ///
        public abstract int StopRecording();
    };
}