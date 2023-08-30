using System;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMusicPlayer : IMediaPlayer
    {
#region terra IMusicPlayer

        public abstract int Open(long songCode, long startPos = 0);
#endregion terra IMusicPlayer
    }
}