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
        #region terra IVideoEncodedFrameObserver
        ///
        /// <summary>
        /// Reports that the receiver has received the to-be-decoded video frame sent by the remote end.
        /// 
        /// If you call the SetRemoteVideoSubscriptionOptions method and set encodedFrameOnly to true, the SDK triggers this callback locally to report the received encoded video frame information.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="imageBufferPtr"> The encoded video image buffer. </param>
        ///
        /// <param name="length"> The data length of the video image. </param>
        ///
        /// <param name="videoEncodedFrameInfo"> For the information of the encoded video frame, see EncodedVideoFrameInfo. </param>
        ///
        /// <returns>
        /// Without practical meaning.
        /// </returns>
        ///
        public virtual bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            return true;
        }
        #endregion terra IVideoEncodedFrameObserver
    }
}