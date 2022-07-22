using System;
namespace Agora.Rtc
{
    public abstract class IMusicPlayer:IMediaPlayer
    {
        public abstract int Open(Int64 songCode, AgoraMediaType type, string resolution, uint startPos);
    }
}
