using System;
using System.Threading;
using Agora.Rtc;

using C_Sharp_API_Example.src.Advanced.CustomRender;

namespace C_Sharp_API_Example
{
    class CustomRender : IEngine
    {
        private readonly string tag_ = "[CustomRender] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private IVideoFrameObserver video_frame_observer = null;
        private CustomRenderView view_ = null;

        public CustomRender(System.Windows.Forms.UserControl view)
        {
            view_ = (CustomRenderView)view;
        }

        internal override int Init(string appId)
        {
            int ret = -1;

            if (null == rtc_engine_)
            {
                rtc_engine_ = RtcEngine.CreateAgoraRtcEngine();
            }

            // Prepare engine context
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext();
            rtc_engine_ctx.appId = appId;
            rtc_engine_ctx.logConfig.filePath = log_file_path;

            // Initialize engine
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            MainForm.dump_handler_(tag_ + "Initialize", ret);

            // Register event handler
            ret = rtc_engine_.InitEventHandler(this);
            MainForm.dump_handler_(tag_ + "InitEventHandler", ret);

            // Register video frame observer
            video_frame_observer = new CustomRenderVideoFrameObserver(view_);
            ret = rtc_engine_.RegisterVideoFrameObserver(video_frame_observer);
            MainForm.dump_handler_(tag_ + "RegisterVideoFrameObserver", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            MainForm.dump_handler_(tag_ + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            MainForm.dump_handler_(tag_ + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            MainForm.dump_handler_(tag_ + "StartPreview", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                // Stop preview
                ret = rtc_engine_.StopPreview();
                MainForm.dump_handler_(tag_ + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                MainForm.dump_handler_(tag_ + "DisableVideo", ret);

                // Leave channel
                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(tag_ + "LeaveChannel", ret);

                // Dispose engine
                rtc_engine_.Dispose();
                rtc_engine_ = null;
            }
            return ret;
        }

        internal override int JoinChannel(string channelId)
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

                ret = rtc_engine_.JoinChannel("", channelId.Split(';').GetValue(0).ToString(), 0, options);

                MainForm.dump_handler_(tag_ + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(tag_ + "LeaveChannel", ret);
            }
            return ret;
        }
    }

    // override if need
    internal class CustomRenderVideoFrameObserver : IVideoFrameObserver
    {
        CustomRenderView view_;

        public CustomRenderVideoFrameObserver(CustomRenderView view)
        {
            view_ = view;
        }

        public override bool OnPreEncodeVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            view_.remoteVideoView.DeliverFrame(videoFrame);
            return true;
        }

        public override bool OnRenderVideoFrame(string channelId, uint remoteUid, VideoFrame videoFrame)
        {
            view_.localVideoView.DeliverFrame(videoFrame);
            return true;
        }

        public override VIDEO_OBSERVER_FRAME_TYPE GetVideoFormatPreference()
        {
            switch (view_.type_)
            {
                case BaseRender.CustomVideoBoxRenderType.kBufferedGraphics:
                    return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_BGRA;
                case BaseRender.CustomVideoBoxRenderType.kSharpDX_BGRA:
                    return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_BGRA;
                case BaseRender.CustomVideoBoxRenderType.kSharpDX_YUV420:
                    return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;
                default:
                    return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_BGRA;
            }
        }

        public override VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER | VIDEO_OBSERVER_POSITION.POSITION_PRE_ENCODER;
        }
    }
}
