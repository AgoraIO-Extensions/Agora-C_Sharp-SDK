using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Receives encoded video images.
    /// </summary>
    ///
    public abstract class IVideoEncodedImageReceiver
    {
        ///
        /// TODO(doc)
        ///
        public virtual bool OnEncodedVideoImageReceived(IntPtr imageBufferPtr, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}