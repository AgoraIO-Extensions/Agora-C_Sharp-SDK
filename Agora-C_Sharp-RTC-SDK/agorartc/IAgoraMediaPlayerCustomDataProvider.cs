using System;

namespace agora.rtc
{
    public class IAgoraMediaPlayerCustomDataProvider
    {
        public virtual Int64 OnSeek(Int64 offset, int whence, int playerId)
        {
            return 0;
        }

        public virtual int OnReadData(byte[] buffer, int bufferSize, int playerId)
        {
            return 0;
        }
    }
}