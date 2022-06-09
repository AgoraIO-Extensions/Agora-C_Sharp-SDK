using System;

namespace agora.rtc
{
    public class IVideoEncodedFrameObserver
    {
        public virtual bool OnEncodedVideoFrame(uint uid, IntPtr imageBufferPtr, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}