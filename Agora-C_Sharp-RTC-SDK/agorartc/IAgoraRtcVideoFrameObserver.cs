//  IAgoraRtcVideoFrameObserver.cs
//
//  Created by Yiqing Huang on June 9, 2021.
//  Modified by Yiqing Huang on June 11, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//


namespace agora.rtc
{
    /**
     * The IVideoFrameObserver class.
     */
    public abstract class IAgoraRtcVideoFrameObserver
    {
        /**
         * Occurs each time the SDK receives a video frame captured by the local camera.
         * After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data captured by the local camera. You can then pre-process the data according to your scenarios.
         *  After pre-processing, you can send the processed video data back to the SDK by this callback. This callback does not support sending processed RGBA video data back to the SDK.
         *  The video data that this callback gets has not been pre-processed, without the watermark, the cropped content, the rotation, and the image enhancement.
         * @param
         *  VideoFrame: Video frame data. See VideoFrame for details.
         * @return
         * Whether to ignore the current video frame if the processing fails:
         *  true: Do not ignore.
         *  false: Ignore the current video frame, and do not send it back to the SDK.
         */
        public virtual bool OnCaptureVideoFrame(VideoFrame videoFrame)
        {
            return true;
        }
        
        /**
         * Occurs each time the SDK receives a video frame before encoding.
         * After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data before encoding and then process the data according to your particular scenarios.
         *  After processing, you can send the processed video data back to the SDK in this callback. To get the video data captured from the second screen before encoding, you need to set GetObservedFramePosition .
         *  The video data that this callback gets has been preprocessed, with its content cropped and rotated, and the image enhanced.
         *  This callback does not support sending processed RGBA video data back to the SDK.
         * @param
         *  VideoFrame: Video frame data. See VideoFrame for details.
         * @return
         * Whether to ignore the current video frame if the processing fails:
         *  true: Do not ignore.
         *  false: Ignore the current video frame, and do not send it back to the SDK.
         */
        public virtual bool OnPreEncodeVideoFrame(VideoFrame videoFrame)
        {
            return true;
        }
        
        /**
         * Occurs each time the SDK receives a video frame sent by the remote user.
         * Since
         *  v3.0.0 After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. In this callback, you can get the video data before encoding. You can then process the data according to your particular scenarios.
         *  After processing, you can send the processed video data back to the SDK in this callback.
         *  This callback does not support sending processed RGBA video data back to the SDK.
         * @param
         *  VideoFrame: Video frame data. See VideoFrame for details.
         *  uid: The ID of the remote user who sends the current video frame.
         * @return
         * Whether to ignore the current video frame if the processing fails:
         *  true: Do not ignore.
         *  false: Ignore the current video frame, and do not send it back to the SDK.
         */
        public virtual bool OnRenderVideoFrame(uint uid, VideoFrame videoFrame)
        {
            return true;
        }
        
        /**
         * Occurs each time the SDK receives a video frame and prompts you to set the video format.
         * If you want to receive other video formats than YUV420, register this callback when calling RegisterVideoFrameObserver . After you successfully register the video frame observer, the SDK triggers this callback each time it receives a video frame. You need to set your preferred video data in the return value of this callback.
         * @return
         * Sets the video format VIDEO_FRAME_TYPE :
         *  FRAME_TYPE_YUV420 (0): (Default) YUV420.
         *  FRAME_TYPE_RGBA (2): RGBA.
         */
        public virtual VIDEO_FRAME_TYPE GetVideoFormatPreference()
        {
            return VIDEO_FRAME_TYPE.FRAME_TYPE_RGBA;
        }
        
        /**
         * Sets the frame position for the video observer.
         * After successfully registering the video data observer, the SDK uses this callback to determine whether to trigger OnCaptureVideoFrame , OnRenderVideoFrame and OnPreEncodeVideoFrame callback at each specific video frame processing position, so that you can observe the locally collected video data, the video data sent by the remote end, and the video data before encoding. You can set one or more positions you need to observe by modifying the return value according to your scenario: OnCaptureVideoFrame callback.
         *  OnRenderVideoFrame callback.
         *  OnPreEncodeVideoFrame callback. 
         *  Use '|' (the OR operator) to observe multiple frame positions.
         *  This callback observes 
         *  To conserve the system consumption, you can reduce the number of frame positions that you want to observe.
         */
        public virtual VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER;
        }

        /**
         * Sets whether to get video data from multiple channels in the multi-channel scenario.
         * Since
         *  v3.0.1 After you register the video frame observer, the SDK triggers this callback every time it captures a video frame.
         *  In the multi-channel scenario, if you want to get video data from multiple channels, you need to set the return value of this callback as true. After that, the SDK triggers the OnRenderVideoFrameEx callback to send you the received remote video frame and report which channel the video frame comes from. If you set the return value of this callback as true, the SDK triggers OnRenderVideoFrameEx to send the before-mixing video data. OnRenderVideoFrame will not be triggered. In the multi-channel scenario, Agora recommends setting the return value as true.
         *  If you set the return value of this callback as false, the SDK triggers OnRenderVideoFrame to send you the received video data.
         * @return
         * true: Receive video data from multiple channels.
         *  false: Do not receive video data from multiple channels.
         */
        public virtual bool IsMultipleChannelFrameWanted()
        {
            return true;
        }

        /**
         * Gets the video frame from multiple channels.
         * After you successfully register the video frame observer, if you set the return value of IsMultipleChannelFrameWanted as true, the SDK triggers this callback each time it receives a video frame from any of the channel.
         *  You can process the video data retrieved from this callback according to your scenario, and send the processed data back to the SDK using the videoFrame parameter in this callback.
         *  This callback does not support sending RGBA video data back to the SDK.
         * @param
         *  channelId: The channel ID of this video frame.
         *  VideoFrame: Video frame data. See VideoFrame for details.
         *  uid: The ID of the user sending this video frame.
         * @return
         * Whether to send this video frame to the SDK if post-processing fails:
         *  true: Send the video frame.
         *  false: Do not send the video frame.
         */
        public virtual bool OnRenderVideoFrameEx(string channelId, uint uid, VideoFrame videoFrame)
        {
            return true;
        }
    }
}
