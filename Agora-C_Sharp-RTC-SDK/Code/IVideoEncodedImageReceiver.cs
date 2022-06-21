using System;

namespace Agora.Rtc
{
    public class IVideoEncodedImageReceiver
    {
        public virtual bool OnEncodedVideoImageReceived(IntPtr imageBufferPtr, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}