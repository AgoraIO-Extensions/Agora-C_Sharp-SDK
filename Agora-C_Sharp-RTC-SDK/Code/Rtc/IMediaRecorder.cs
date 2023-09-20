namespace Agora.Rtc
{
    /* class_imediarecorder */
    public abstract class IMediaRecorder
    {
#region terra IMediaRecorder

        /* api_imediarecorder_setmediarecorderobserver */
        public abstract int SetMediaRecorderObserver(IMediaRecorderObserver callback);

        /* api_imediarecorder_startrecording */
        public abstract int StartRecording(MediaRecorderConfiguration config);

        /* api_imediarecorder_stoprecording */
        public abstract int StopRecording();
#endregion terra IMediaRecorder
    };
}