namespace Agora.Rtc
{
    /* class_ivideoframeobserver */
    public abstract class IVideoFrameObserver
    {
#region terra IVideoFrameObserver

        /* callback_ivideoframeobserver_oncapturevideoframe */
        public virtual bool OnCaptureVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            return true;
        }

        /* callback_ivideoframeobserver_onpreencodevideoframe */
        public virtual bool OnPreEncodeVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            return true;
        }

        /* callback_ivideoframeobserver_onmediaplayervideoframe */
        public virtual bool OnMediaPlayerVideoFrame(VideoFrame videoFrame, int mediaPlayerId)
        {
            return true;
        }

        /* callback_ivideoframeobserver_onrendervideoframe */
        public virtual bool OnRenderVideoFrame(string channelId, uint remoteUid, VideoFrame videoFrame)
        {
            return true;
        }

        /* callback_ivideoframeobserver_ontranscodedvideoframe */
        public virtual bool OnTranscodedVideoFrame(VideoFrame videoFrame)
        {
            return true;
        }

#endregion terra IVideoFrameObserver
    }
}