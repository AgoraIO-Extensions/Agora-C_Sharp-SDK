namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The IVideoFrameObserver class.
    /// </summary>
    ///
    public abstract class IVideoFrameObserver
    {
        #region terra IVideoFrameObserver
        ///
        /// <summary>
        /// Occurs each time the SDK receives a video frame captured by local devices.
        /// 
        /// You can get raw video data collected by the local device through this callback and preprocess it as needed. Once the preprocessing is complete, you can directly modify videoFrame in this callback, and set the return value to true to send the modified video data to the SDK.
        /// </summary>
        ///
        /// <param name="sourceType"> Video source types, including cameras, screens, or media player. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <param name="videoFrame"> The video frame. See VideoFrame. </param>
        ///
        /// <returns>
        /// true : Sets the SDK to receive the video frame. false : Sets the SDK to discard the video frame.
        /// </returns>
        ///
        public virtual bool OnCaptureVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Occurs each time the SDK receives a video frame before encoding.
        /// 
        /// After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data before encoding and then process the data according to your particular scenarios. After processing, you can send the processed video data back to the SDK in this callback.
        /// To get the video data captured from the second screen before encoding, you need to set POSITION_PRE_ENCODER (1 << 2) as a frame position through the position parameter of the RegisterVideoFrameObserver method.
        /// The video data that this callback gets has been preprocessed, with its content cropped and rotated, and the image enhanced.
        /// </summary>
        ///
        /// <param name="videoFrame"> The video frame. See VideoFrame. </param>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <returns>
        /// true : Sets the SDK to receive the video frame. false : Sets the SDK to discard the video frame.
        /// </returns>
        ///
        public virtual bool OnPreEncodeVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            return true;
        }

        ///
        /// @ignore
        ///
        public virtual bool OnMediaPlayerVideoFrame(VideoFrame videoFrame, int mediaPlayerId)
        {
            return true;
        }

        ///
        /// <summary>
        /// Occurs each time the SDK receives a video frame sent by the remote user.
        /// 
        /// After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data sent from the remote end before rendering, and then process it according to the particular scenarios. If you use Unity for development, Agora only supports sending video data in YUV format to SDK. Ensure that you set mode as INTPTR when you call the RegisterVideoFrameObserver method to register a video frame observer.
        /// </summary>
        ///
        /// <param name="videoFrame"> The video frame. See VideoFrame. </param>
        ///
        /// <param name="remoteUid"> The user ID of the remote user who sends the current video frame. </param>
        ///
        /// <param name="channelId"> The channel ID. </param>
        ///
        /// <returns>
        /// true : Sets the SDK to receive the video frame. false : Sets the SDK to discard the video frame.
        /// </returns>
        ///
        public virtual bool OnRenderVideoFrame(string channelId, uint remoteUid, VideoFrame videoFrame)
        {
            return true;
        }

        ///
        /// @ignore
        ///
        public virtual bool OnTranscodedVideoFrame(VideoFrame videoFrame)
        {
            return true;
        }

        #endregion terra IVideoFrameObserver
    }
}