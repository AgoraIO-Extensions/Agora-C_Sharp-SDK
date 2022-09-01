namespace Agora.Rtc
{
    public abstract class IMediaRecorder
    {
        public abstract int SetMediaRecorderObserver(RtcConnection connection, IMediaRecorderObserver callback);

        public abstract int StartRecording(RtcConnection connection, MediaRecorderConfiguration config);

        public abstract int StopRecording(RtcConnection connection);
    };
}