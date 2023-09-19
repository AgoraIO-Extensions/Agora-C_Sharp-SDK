using System;

namespace Agora.Rtc
{
    public abstract class IVideoEncodedFrameObserver
    {
#region terra IVideoEncodedFrameObserver

        public virtual bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
#endregion terra IVideoEncodedFrameObserver
    }
}