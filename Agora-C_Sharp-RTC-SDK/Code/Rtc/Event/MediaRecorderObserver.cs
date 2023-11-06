using System;

namespace Agora.Rtc
{
    public class MediaRecorderObserver : IMediaRecorderObserver
    {

        private static MediaRecorderObserver eventInstance = null;

        public static MediaRecorderObserver GetInstance()
        {
            return eventInstance ?? (eventInstance = new MediaRecorderObserver());
        }

        #region terra IMediaRecorderObserver
        public event Action<string, uint, RecorderState, RecorderErrorCode> EventOnRecorderStateChanged;

        public override void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderErrorCode error)
        {
            if (EventOnRecorderStateChanged == null) return;
            EventOnRecorderStateChanged.Invoke(channelId, uid, state, error);
        }

        public event Action<string, uint, RecorderInfo> EventOnRecorderInfoUpdated;

        public override void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info)
        {
            if (EventOnRecorderInfoUpdated == null) return;
            EventOnRecorderInfoUpdated.Invoke(channelId, uid, info);
        }

        #endregion terra IMediaRecorderObserver
    }
}