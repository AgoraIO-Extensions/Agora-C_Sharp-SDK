using System;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMusicPlayer : IMediaPlayer
    {
        #region terra IMusicPlayer
        ///
        /// @ignore
        ///
        public abstract int Open(long songCode, long startPos = 0);

        ///
        /// @ignore
        ///
        public abstract int SetPlayMode(MusicPlayMode mode);
        #endregion terra IMusicPlayer
    }
}