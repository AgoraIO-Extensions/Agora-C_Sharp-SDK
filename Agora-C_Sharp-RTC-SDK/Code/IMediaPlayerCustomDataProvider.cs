using System;

namespace Agora.Rtc
{
    public class IMediaPlayerCustomDataProvider
    {
        public virtual Int64 OnSeek(Int64 offset, int whence)
        {
            return 0;
        }

        public virtual int OnReadData(IntPtr bufferPtr, int bufferSize)
        {
            return 0;
        }
    }
}