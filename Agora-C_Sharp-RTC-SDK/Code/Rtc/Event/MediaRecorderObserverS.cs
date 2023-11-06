using System;

namespace Agora.Rtc
{
    public class MediaRecorderObserverS : IMediaRecorderObserverS
    {

        private static MediaRecorderObserverS eventInstance = null;

        public static MediaRecorderObserverS GetInstance()
        {
            return eventInstance ?? (eventInstance = new MediaRecorderObserverS());
        }

        #region terra IMediaRecorderObserverS
        public event Action<string, string, RecorderState, RecorderErrorCode> EventOnRecorderStateChanged;

        public override void OnRecorderStateChanged(string channelId, string userId, RecorderState state, RecorderErrorCode error)
        {
            if (EventOnRecorderStateChanged == null) return;
            EventOnRecorderStateChanged.Invoke(channelId, userId, state, error);
        }

        public event Action<string, string, RecorderInfo> EventOnRecorderInfoUpdated;

        public override void OnRecorderInfoUpdated(string channelId, string userId, RecorderInfo info)
        {
            if (EventOnRecorderInfoUpdated == null) return;
            EventOnRecorderInfoUpdated.Invoke(channelId, userId, info);
        }

        #endregion terra IMediaRecorderObserverS
    }
}