namespace Agora.Rtc
{
    public delegate void OnRecorderStateChangedHandler(RecorderState state, RecorderErrorCode error);

    public delegate void OnRecorderInfoUpdatedHandler(RecorderInfo info);
    
    public class MediaRecorderObserver : IMediaRecorderObserver
    {
        public event OnRecorderStateChangedHandler EventOnRecorderStateChanged;

        public event OnRecorderInfoUpdatedHandler EventOnRecorderInfoUpdated;

        private static MediaRecorderObserver eventInstance = null;

        public static MediaRecorderObserver GetInstance()
        {
            return eventInstance ?? (eventInstance = new MediaRecorderObserver());
        }

        public override void OnRecorderStateChanged(RecorderState state, RecorderErrorCode error)
        {
            if (EventOnRecorderStateChanged == null) return;
            EventOnRecorderStateChanged.Invoke(state, error);
        }

        public override void OnRecorderInfoUpdated(RecorderInfo info)
        {
            if (EventOnRecorderInfoUpdated == null) return;
            EventOnRecorderInfoUpdated.Invoke(info);
        }
    }
}