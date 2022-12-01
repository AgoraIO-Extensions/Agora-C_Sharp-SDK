using System;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IMusicPlayer : IMediaPlayer
    {
        ///
        /// @ignore
        ///
        public abstract int Open(Int64 songCode, Int64 startPos);
    }
}