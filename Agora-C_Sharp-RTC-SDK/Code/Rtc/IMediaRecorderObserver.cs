namespace Agora.Rtc
{
    /* class_imediarecorderobserver */
    public abstract class IMediaRecorderObserver
    {
        public virtual void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderErrorCode error) {}

        public virtual void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info) {}
    };
}