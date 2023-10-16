using System;
namespace Agora.Rtc
{
    public class UTVideoFrameObserver : IVideoFrameObserver
    {
        #region terra IVideoFrameObserver

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

            if (ParamsHelper.Compare<string>(OnRenderVideoFrame_channelId, channelId) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRenderVideoFrame_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<VideoFrame>(OnRenderVideoFrame_videoFrame, videoFrame) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IVideoFrameObserver
    }
}
