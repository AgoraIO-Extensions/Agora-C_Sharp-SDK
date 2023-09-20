using System;

namespace Agora.Rtc
{
    /* class_ivideoencodedframeobserver */
    public abstract class IVideoEncodedFrameObserver
    {
#region terra IVideoEncodedFrameObserver

        /* callback_ivideoencodedframeobserver_onencodedvideoframereceived */
        public virtual bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
#endregion terra IVideoEncodedFrameObserver
    }
}