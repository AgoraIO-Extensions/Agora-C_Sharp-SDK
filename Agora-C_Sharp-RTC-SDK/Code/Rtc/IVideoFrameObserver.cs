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
/// After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data captured by the local camera. You can then pre-process the data according to your scenarios.After pre-processing, you can send the processed video data back to the SDK through this callback.The video data that this callback gets has not been pre-processed, and is not watermarked, cropped, rotated or beautified.If the video data type you get is RGBA, Agora does not support processing the data of the alpha channel.
/// </summary>
///
/// <param name ="videoFrame">The video frame. See VideoFrame .</param>
/// <param name ="config">The configuration of the video frame. See VideoFrameBufferConfig .</param>
///
/// <returns>
/// true: Sets the SDK to receive the video frame.false: Sets the SDK to discard the video frame.
/// </returns>
///
        public virtual bool OnCaptureVideoFrame(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            return true;
        }

///
/// <summary>
/// Occurs each time the SDK receives a video frame before encoding.
/// After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data before encoding and then process the data according to your particular scenarios.After processing, you can send the processed video data back to the SDK in this callback.To get the video data captured from the second screen before encoding, you need to set POSITION_PRE_ENCODER (1 << 2) as a frame position through GetObservedFramePosition .The video data that this callback gets has been preprocessed, with its content cropped and rotated, and the image enhanced.
/// </summary>
///
/// <param name ="videoFrame">The video frame. See VideoFrame .</param>
/// <param name ="config">The configuration of the video frame. See VideoFrameBufferConfig .</param>
///
/// <returns>
/// true: Sets the SDK to receive the video frame.false: Sets the SDK to discard the video frame.
/// </returns>
///
        public virtual bool OnPreEncodeVideoFrame(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            return true;
        }
        
///
/// <summary>
/// Occurs each time the SDK receives a video frame sent by the remote user.
/// After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data before encoding. You can then process the data according to your particular scenarios.
/// </summary>
///
/// <param name ="channelId">The channel ID.</param>
/// <param name ="uid">The user ID of the remote user who sends the current video frame.</param>
/// <param name ="videoFrame">The video frame. See VideoFrame .</param>
///
/// <returns>
/// true: Sets the SDK to receive the video frame.false: Sets the SDK to discard the video frame.
/// </returns>
///
        public virtual bool OnRenderVideoFrame(string channelId, uint uid, VideoFrame videoFrame)
        {
            return true;
        }
        
///
/// <summary>
/// Destroys the specified video track.
/// </summary>
///
/// <returns>
/// 0: Success.< 0: Failure.
/// </returns>
///
        public virtual VIDEO_OBSERVER_FRAME_TYPE GetVideoFormatPreference()
        {
            return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
        }
        
///
/// <summary>
/// Destroys the specified video track.
/// </summary>
///
/// <returns>
/// 0: Success.< 0: Failure.
/// </returns>
///
        public virtual VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER;
        }
    }
}