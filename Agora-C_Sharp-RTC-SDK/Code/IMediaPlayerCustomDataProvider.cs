﻿using System;

namespace Agora.Rtc
{
    public abstract class IMediaPlayerCustomDataProvider
    {
        public virtual Int64 OnSeek(Int64 offset, int whence, int playerId)
        {
            return 0;
        }

        public virtual int OnReadData(IntPtr bufferPtr, int bufferSize, int playerId)
        {
            return 0;
        }
    }
}