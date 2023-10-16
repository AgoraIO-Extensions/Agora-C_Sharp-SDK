namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMediaRecorder : IMediaRecorderBase
    {
        #region terra IMediaRecorder


        public abstract int SetMediaRecorderObserver(IMediaRecorderObserver callback);
        #endregion terra IMediaRecorder
    };
}