using System;
namespace Agora.Rtc
{
    public class UTVideoFrameObserver : IVideoFrameObserver
    {


        public bool OnCaptureVideoFrame_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnCaptureVideoFrame_SourceType;
        public VideoFrame OnCaptureVideoFrame_videoFrame = null;

        public override bool OnCaptureVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            OnCaptureVideoFrame_be_trigger = true;
            OnCaptureVideoFrame_SourceType = sourceType;
            OnCaptureVideoFrame_videoFrame = videoFrame;
            return true;
        }

        public bool OnCaptureVideoFramePassed(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            if (OnCaptureVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareVIDEO_SOURCE_TYPE(OnCaptureVideoFrame_SourceType, sourceType) == false)
                return false;
            if (ParamsHelper.compareVideoFrame(OnCaptureVideoFrame_videoFrame, videoFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPreEncodeVideoFrame_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnPreEncodeVideoFrame_SourceType;
        public VideoFrame OnPreEncodeVideoFrame_videoFrame = null;

        public override bool OnPreEncodeVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            OnPreEncodeVideoFrame_be_trigger = true;
            OnPreEncodeVideoFrame_SourceType = sourceType;
            OnPreEncodeVideoFrame_videoFrame = videoFrame;
            return true;
        }

        public bool OnPreEncodeVideoFramePassed(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            if (OnPreEncodeVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareVIDEO_SOURCE_TYPE(OnPreEncodeVideoFrame_SourceType, sourceType) == false)
                return false;
            if (ParamsHelper.compareVideoFrame(OnPreEncodeVideoFrame_videoFrame, videoFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnMediaPlayerVideoFrame_be_trigger = false;
        public VideoFrame OnMediaPlayerVideoFrame_videoFrame = null;
        public int OnMediaPlayerVideoFrame_mediaPlayerId = 0;

        public override bool OnMediaPlayerVideoFrame(VideoFrame videoFrame, int mediaPlayerId)
        {
            OnMediaPlayerVideoFrame_be_trigger = true;
            OnMediaPlayerVideoFrame_videoFrame = videoFrame;
            OnMediaPlayerVideoFrame_mediaPlayerId = mediaPlayerId;
            return true;
        }

        public bool OnMediaPlayerVideoFramePassed(VideoFrame videoFrame, int mediaPlayerId)
        {
            if (OnMediaPlayerVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareVideoFrame(OnMediaPlayerVideoFrame_videoFrame, videoFrame) == false)
                return false;
            if (ParamsHelper.compareInt(OnMediaPlayerVideoFrame_mediaPlayerId, mediaPlayerId) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRenderVideoFrame_be_trigger = false;
        public string OnRenderVideoFrame_channelId = null;
        public  uint OnRenderVideoFrame_remoteUid = 0;
        public VideoFrame OnRenderVideoFrame_videoFrame = null;

        public override bool OnRenderVideoFrame(string channelId,  uint remoteUid, VideoFrame videoFrame)
        {
            OnRenderVideoFrame_be_trigger = true;
            OnRenderVideoFrame_channelId = channelId;
            OnRenderVideoFrame_remoteUid = remoteUid;
            OnRenderVideoFrame_videoFrame = videoFrame;
            return true;
        }

        public bool OnRenderVideoFramePassed(string channelId,  uint remoteUid, VideoFrame videoFrame)
        {
            if (OnRenderVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnRenderVideoFrame_channelId, channelId) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnRenderVideoFrame_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareVideoFrame(OnRenderVideoFrame_videoFrame, videoFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnTranscodedVideoFrame_be_trigger = false;
        public VideoFrame OnTranscodedVideoFrame_videoFrame = null;

        public override bool OnTranscodedVideoFrame(VideoFrame videoFrame)
        {
            OnTranscodedVideoFrame_be_trigger = true;
            OnTranscodedVideoFrame_videoFrame = videoFrame;
            return true;
        }

        public bool OnTranscodedVideoFramePassed(VideoFrame videoFrame)
        {
            if (OnTranscodedVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareVideoFrame(OnTranscodedVideoFrame_videoFrame, videoFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
