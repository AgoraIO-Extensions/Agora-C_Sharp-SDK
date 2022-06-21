using System;

namespace Agora.Rtc
{
    public class IVideoEncodedFrameObserver
    {
        public virtual bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBufferPtr, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}