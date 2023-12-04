using System;
namespace Agora.Rtc
{
    public class UTVideoFrameObserver : IVideoFrameObserver
    {
        #region terra IVideoFrameObserver
        public bool OnCaptureVideoFrame_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnCaptureVideoFrame_sourceType;
        public VideoFrame OnCaptureVideoFrame_videoFrame;

        public override bool OnCaptureVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            OnCaptureVideoFrame_be_trigger = true;
            OnCaptureVideoFrame_sourceType = sourceType;
            OnCaptureVideoFrame_videoFrame = videoFrame;
            return true;

        }

        public bool OnCaptureVideoFramePassed(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {

            if (OnCaptureVideoFrame_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnCaptureVideoFrame_sourceType, sourceType) == false)
            //return false;
            // if (ParamsHelper.Compare<VideoFrame>(OnCaptureVideoFrame_videoFrame, videoFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnPreEncodeVideoFrame_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnPreEncodeVideoFrame_sourceType;
        public VideoFrame OnPreEncodeVideoFrame_videoFrame;

        public override bool OnPreEncodeVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            OnPreEncodeVideoFrame_be_trigger = true;
            OnPreEncodeVideoFrame_sourceType = sourceType;
            OnPreEncodeVideoFrame_videoFrame = videoFrame;
            return true;

        }

        public bool OnPreEncodeVideoFramePassed(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {

            if (OnPreEncodeVideoFrame_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnPreEncodeVideoFrame_sourceType, sourceType) == false)
            //return false;
            // if (ParamsHelper.Compare<VideoFrame>(OnPreEncodeVideoFrame_videoFrame, videoFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnMediaPlayerVideoFrame_be_trigger = false;
        public VideoFrame OnMediaPlayerVideoFrame_videoFrame;
        public int OnMediaPlayerVideoFrame_mediaPlayerId;

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

            // if (ParamsHelper.Compare<VideoFrame>(OnMediaPlayerVideoFrame_videoFrame, videoFrame) == false)
            //return false;
            // if (ParamsHelper.Compare<int>(OnMediaPlayerVideoFrame_mediaPlayerId, mediaPlayerId) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnRenderVideoFrame_be_trigger = false;
        public string OnRenderVideoFrame_channelId;
        public uint OnRenderVideoFrame_remoteUid;
        public VideoFrame OnRenderVideoFrame_videoFrame;

        public override bool OnRenderVideoFrame(string channelId, uint remoteUid, VideoFrame videoFrame)
        {
            OnRenderVideoFrame_be_trigger = true;
            OnRenderVideoFrame_channelId = channelId;
            OnRenderVideoFrame_remoteUid = remoteUid;
            OnRenderVideoFrame_videoFrame = videoFrame;
            return true;

        }

        public bool OnRenderVideoFramePassed(string channelId, uint remoteUid, VideoFrame videoFrame)
        {

            if (OnRenderVideoFrame_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnRenderVideoFrame_channelId, channelId) == false)
            //return false;
            // if (ParamsHelper.Compare<uint>(OnRenderVideoFrame_remoteUid, remoteUid) == false)
            //return false;
            // if (ParamsHelper.Compare<VideoFrame>(OnRenderVideoFrame_videoFrame, videoFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnTranscodedVideoFrame_be_trigger = false;
        public VideoFrame OnTranscodedVideoFrame_videoFrame;

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

            // if (ParamsHelper.Compare<VideoFrame>(OnTranscodedVideoFrame_videoFrame, videoFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////


        #endregion terra IVideoFrameObserver
    }
}
