namespace Agora.Rtc
{
    public delegate void OnRecorderStateChangedHandler(string channelId, uint uid, RecorderState state, RecorderErrorCode error);

    public delegate void OnRecorderInfoUpdatedHandler(string channelId, uint uid, RecorderInfo info);

    public class MediaRecorderObserver : IMediaRecorderObserver
    {
        public event OnRecorderStateChangedHandler EventOnRecorderStateChanged;

        public event OnRecorderInfoUpdatedHandler EventOnRecorderInfoUpdated;

        private static MediaRecorderObserver eventInstance = null;

        public static MediaRecorderObserver GetInstance()
        {
            return eventInstance ?? (eventInstance = new MediaRecorderObserver());
        }

        public override void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderErrorCode error)
        {
            if (EventOnRecorderStateChanged == null) return;
            EventOnRecorderStateChanged.Invoke(channelId, uid, state, error);
        }

        public override void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info)
        {
            if (EventOnRecorderInfoUpdated == null) return;
            EventOnRecorderInfoUpdated.Invoke(channelId, uid, info);
        }
    }
}