using System;

namespace Agora.Rtc
{
    public partial class MediaRecorderObserver
    {

        private static MediaRecorderObserver eventInstance = null;

        public static MediaRecorderObserver GetInstance()
        {
            return eventInstance ?? (eventInstance = new MediaRecorderObserver());
        }
    }
}