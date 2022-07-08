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
        /// <summary>
        /// Occurs each time the SDK receives an encoded video frame.
        /// </summary>
        ///
        /// <param name="imageBufferPtr"> The encoded video image buffer.</param>
        ///
        /// <param name="length"> The data length of the video image.</param>
        ///
        /// <param name="videoEncodedFrameInfo"> The information of the encoded video frame, see EncodedVideoFrameInfo .</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnEncodedVideoImageReceived(IntPtr imageBufferPtr, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}