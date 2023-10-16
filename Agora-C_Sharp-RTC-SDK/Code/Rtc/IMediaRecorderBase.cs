namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMediaRecorderBase
    {
        #region terra IMediaRecorderBase


        public abstract int StartRecording(MediaRecorderConfiguration config);


        public abstract int StopRecording();
        #endregion terra IMediaRecorderBase
    };
}