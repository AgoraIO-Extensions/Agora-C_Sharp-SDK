namespace Agora.Rtc
{
    /* class_imediarecorderobserver */
    public abstract class IMediaRecorderObserver
    {
        /* callback_imediarecorderobserver_onrecorderstatechanged */
        public virtual void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderErrorCode error) {}

        /* callback_imediarecorderobserver_onrecorderinfoupdated */
        public virtual void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info) {}
    };
}