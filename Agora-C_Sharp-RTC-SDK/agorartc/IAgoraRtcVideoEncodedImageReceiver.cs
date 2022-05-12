using System;

namespace agora.rtc
{
    public class IAgoraRtcVideoEncodedImageReceiver
    {
        public virtual bool OnEncodedVideoImageReceived(byte[] imageBuffer, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}