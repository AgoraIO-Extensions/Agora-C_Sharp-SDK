using System;
namespace Agora.Rtc
{
    public class UTVideoFrameObserver : IVideoFrameObserver
    {



        public bool OnCaptureVideoFrame_be_trigger = false;
        public VideoFrame OnCaptureVideoFrame_videoFrame = null;
        public VideoFrameBufferConfig OnCaptureVideoFrame_VideoFrameBufferConfig;
        public override bool OnCaptureVideoFrame(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            OnCaptureVideoFrame_be_trigger = true;
            OnCaptureVideoFrame_videoFrame = videoFrame;
            OnCaptureVideoFrame_VideoFrameBufferConfig = config;

            return true;
        }

        public bool OnCaptureVideoFramePassed(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            if (OnCaptureVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareVideoFrame(OnCaptureVideoFrame_videoFrame, videoFrame) == false)
                return false;

            if (ParamsHelper.compareVideoFrameBufferConfig(OnCaptureVideoFrame_VideoFrameBufferConfig, config) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPreEncodeVideoFrame_be_trigger = false;
        public VideoFrame OnPreEncodeVideoFrame_videoFrame = null;
        public VideoFrameBufferConfig OnPreEncodeVideoFrame_config;

        public override bool OnPreEncodeVideoFrame(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            OnPreEncodeVideoFrame_be_trigger = true;
            OnPreEncodeVideoFrame_videoFrame = videoFrame;
            OnPreEncodeVideoFrame_config = config;
            return true;
        }

        public bool OnPreEncodeVideoFramePassed(VideoFrame videoFrame, VideoFrameBufferConfig config)
        {
            if (OnPreEncodeVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareVideoFrame(OnPreEncodeVideoFrame_videoFrame, videoFrame) == false)
                return false;

            if (ParamsHelper.compareVideoFrameBufferConfig(OnPreEncodeVideoFrame_config, config) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRenderVideoFrame_be_trigger = false;
        public string OnRenderVideoFrame_channelId = null;
        public uint OnRenderVideoFrame_uid = 0;
        public VideoFrame OnRenderVideoFrame_videoFrame = null;

        public override bool OnRenderVideoFrame(string channelId, uint uid, VideoFrame videoFrame)
        {
            OnRenderVideoFrame_be_trigger = true;
            OnRenderVideoFrame_channelId = channelId;
            OnRenderVideoFrame_uid = uid;
            OnRenderVideoFrame_videoFrame = videoFrame;
            return true;
        }

        public bool OnRenderVideoFramePassed(string channelId, uint uid, VideoFrame videoFrame)
        {
            if (OnRenderVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnRenderVideoFrame_channelId, channelId) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnRenderVideoFrame_uid, uid) == false)
                return false;
            if (ParamsHelper.compareVideoFrame(OnRenderVideoFrame_videoFrame, videoFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool GetVideoFormatPreference_be_trigger = false;

        public override VIDEO_OBSERVER_FRAME_TYPE GetVideoFormatPreference()
        {
            GetVideoFormatPreference_be_trigger = true;
            return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
        }

        public bool GetVideoFormatPreferencePassed()
        {
            if (GetVideoFormatPreference_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool GetObservedFramePosition_be_trigger = false;

        public override VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            GetObservedFramePosition_be_trigger = true;
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER;
        }

        public bool GetObservedFramePositionPassed()
        {
            if (GetObservedFramePosition_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
