namespace Agora.Rtc
{
    public abstract class IMediaRecorderObserver
    {
        public virtual void OnRecorderStateChanged(RecorderState state, RecorderErrorCode error) {}

        public virtual void OnRecorderInfoUpdated(RecorderInfo info) {}
    };
}