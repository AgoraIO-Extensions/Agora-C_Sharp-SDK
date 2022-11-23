using System;

namespace Agora.Rtc
{
    /* class_imusicplayer */
    public abstract class IMusicPlayer : IMediaPlayer
    {
        /* api_imusicplayer_open */
        public abstract int Open(Int64 songCode, Int64 startPos);
    }
}