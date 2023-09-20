using System;

namespace Agora.Rtc
{
    /* class_imusicplayer */
    public abstract class IMusicPlayer : IMediaPlayer
    {
#region terra IMusicPlayer

        /* api_imusicplayer_open */
        public abstract int Open(long songCode, long startPos = 0);
#endregion terra IMusicPlayer
    }
}