namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The IVideoFrameObserver class.
    /// </summary>
    ///
    public abstract class IVideoFrameObserver
    {
        ///
        /// <summary>
        /// Occurs each time the SDK receives a video frame captured by the local camera.
        /// After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data captured by the local camera. You can then pre-process the data according to your scenarios.Once the pre-processing is complete, you can directly modify videoFrame in this callback, and set the return value to true to send the modified video data to the SDK.The video data that this callback gets has not been pre-processed, and is not watermarked, cropped, rotated or beautified.If the video data type you get is RGBA, the SDK does not support processing the data of the alpha channel.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <param name="videoFrame"> The video frame. See VideoFrame .The default value of the video frame data format obtained through this callback is as follows:Android: textureiOS: cvPixelBuffermacOS: YUV 420Windows: YUV 420</param>
        ///
        /// <returns>
        /// true: Sets the SDK to receive the video frame.false: Sets the SDK to discard the video frame.
        /// </returns>
        ///
        public virtual bool OnCaptureVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Occurs each time the SDK receives a video frame before encoding.
        /// After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data before encoding and then process the data according to your particular scenarios.After processing, you can send the processed video data back to the SDK in this callback.To get the video data captured from the second screen before encoding, you need to set POSITION_PRE_ENCODER (1 << 2) as a frame position through GetObservedFramePosition .The video data that this callback gets has been preprocessed, with its content cropped and rotated, and the image enhanced.
        /// </summary>
        ///
        /// <param name="videoFrame"> The video frame. See VideoFrame .The default value of the video frame data format obtained through this callback is as follows:
        ///  Android: texture
        ///  iOS: cvPixelBuffer
        ///  macOS: YUV 420
        ///  Windows: YUV 420</param>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <returns>
        ///  true: Sets the SDK to receive the video frame.
        /// false: Sets the SDK to discard the video frame.
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
        /// After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data sent from the remote end before rendering, and then process it according to the particular scenarios.If you use Unity for development, Agora only supports sending video data in YUV format to SDK. Ensure that you set mode as INTPTR when you call the RegisterVideoFrameObserver method to register a video frame observer.
        /// </summary>
        ///
        /// <param name="videoFrame"> The video frame. See VideoFrame .The default value of the video frame data format obtained through this callback is as follows:Android: textureiOS: cvPixelBuffermacOS: YUV 420Windows: YUV 420</param>
        ///
        /// <param name="remoteUid"> The user ID of the remote user who sends the current video frame.</param>
        ///
        /// <param name="channelId"> The channel ID.</param>
        ///
        /// <returns>
        /// true: Sets the SDK to receive the video frame.false: Sets the SDK to discard the video frame.
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

        ///
        /// <summary>
        /// Sets the format of the raw video data output by the SDK.
        /// If you want to get raw video data in a color encoding format other than YUV 420, register this callback when calling RegisterVideoFrameObserver . After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. You need to set your preferred video data in the return value of this callback.
        /// </summary>
        ///
        /// <returns>
        /// Sets the video format. See VIDEO_OBSERVER_FRAME_TYPE .
        /// </returns>
        ///
        public virtual VIDEO_OBSERVER_FRAME_TYPE GetVideoFormatPreference()
        {
            return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
        }

        ///
        /// <summary>
        /// Sets the frame position for the video observer.
        /// After successfully registering the video data observer, the SDK uses this callback to determine whether to trigger OnCaptureVideoFrame , OnRenderVideoFrame and OnPreEncodeVideoFrame callback at each specific video frame processing position, so that you can observe the locally collected video data, the video data sent by the remote end, and the video data before encoding. You can set one or more positions you need to observe by modifying the return value according to your scenario:POSITION_POST_CAPTURER(1 << 0): The position after capturing the video data, which corresponds to the OnCaptureVideoFrame callback.POSITION_PRE_RENDERER(1 << 1): The position of the received remote video data before rendering, which corresponds to the OnRenderVideoFrame callback.POSITION_PRE_ENCODER(1 << 2): The position before encoding the video data, which corresponds to the OnPreEncodeVideoFrame callback.Use '|' (the OR operator) to observe multiple frame positions.This callback observes POSITION_POST_CAPTURER(1 << 0) and POSITION_PRE_RENDERER(1 << 1) by default.To conserve system resources, you can reduce the number of frame positions that you want to observe.
        /// </summary>
        ///
        /// <returns>
        /// A bit mask that controls the frame position of the video observer. See VIDEO_MODULE_POSITION .
        /// </returns>
        ///
        public virtual VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER;
        }
    }
}