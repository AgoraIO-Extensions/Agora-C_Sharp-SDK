namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMediaRecorder
    {
#region terra IMediaRecorder

        public abstract int SetMediaRecorderObserver(IMediaRecorderObserver callback);

        public abstract int StartRecording(MediaRecorderConfiguration config);

        public abstract int StopRecording();
#endregion terra IMediaRecorder
    };
}