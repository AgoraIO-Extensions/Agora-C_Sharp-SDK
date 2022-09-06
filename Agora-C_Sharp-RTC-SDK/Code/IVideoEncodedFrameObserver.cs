using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Receives encoded video images.
    /// </summary>
    ///
    public abstract class IVideoEncodedFrameObserver
    {
        ///
        /// <summary>
        /// Occurs each time the SDK receives an encoded video image.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="imageBufferPtr"> The encoded video image buffer.</param>
        ///
        /// <param name="length"> The data length of the video image.</param>
        ///
        /// <param name="videoEncodedFrameInfo"> For the information of the encoded video frame, see EncodedVideoFrameInfo .</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBufferPtr, UInt64 length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
    }
}