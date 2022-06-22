using System;

namespace Agora.Rtc
{
    public abstract class IVideoEncodedImageReceiver
    {
        public virtual bool OnEncodedVideoImageReceived(IntPtr imageBufferPtr, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}