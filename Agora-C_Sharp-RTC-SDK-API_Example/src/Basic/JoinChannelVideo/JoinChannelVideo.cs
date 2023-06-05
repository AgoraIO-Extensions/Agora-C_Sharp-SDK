using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class JoinChannelVideo : IEngine
    {
        private readonly string JoinChannelVideo_TAG = "[JoinChannelVideo] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        
        private JoinChannelVideoView view_ = null;
        private bool joined_ = false;

        public JoinChannelVideo(System.Windows.Forms.UserControl view)
        {
            view_ = (JoinChannelVideoView)view;
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
            MainForm.dump_handler_(JoinChannelVideo_TAG + "Initialize", ret);

            // Register event handler
            ret = rtc_engine_.InitEventHandler(this);
            MainForm.dump_handler_(JoinChannelVideo_TAG + "InitEventHandler", ret);

            return ret;
        }

        internal override int UnInit()
        {
            if (null != rtc_engine_)
            {
                // Dispose engine
                rtc_engine_.Dispose();
                rtc_engine_ = null;
            }

            return 0;
        }

        internal override int JoinChannel(string channelId)
        {
            int ret = -1;

            if (null != rtc_engine_ && joined_ != true)
            {
                // Enable video module
                ret = rtc_engine_.EnableVideo();
                MainForm.dump_handler_(JoinChannelVideo_TAG + "EnableVideo", ret);

                // Start preview
                ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
                MainForm.dump_handler_(JoinChannelVideo_TAG + "StartPreview", ret);

                // Setup local video
                VideoCanvas canvas = new VideoCanvas();
                canvas.view = (long)view_.localVideoView.Handle;
                canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

                ret = rtc_engine_.SetupLocalVideo(canvas);
                MainForm.dump_handler_(JoinChannelVideo_TAG + "SetupLocalVideo", ret);

                // Join channel
                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

                ret = rtc_engine_.JoinChannel("", channelId.Split(';').GetValue(0).ToString(), 0, options);

                MainForm.dump_handler_(JoinChannelVideo_TAG + "JoinChannel", ret);

                joined_ = true;
            }

            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;

            if (null != rtc_engine_ && joined_ == true)
            {
                // Stop preview
                ret = rtc_engine_.StopPreview();
                MainForm.dump_handler_(JoinChannelVideo_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                MainForm.dump_handler_(JoinChannelVideo_TAG + "DisableVideo", ret);

                // Leave channel
                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(JoinChannelVideo_TAG + "LeaveChannel", ret);

                joined_ = false;
            }

            return ret;
        }

        // override IRtcEngineEventHandler
        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0}", remoteUid);

            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)view_.remoteVideoView.Handle;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
            canvas.uid = remoteUid;

            int ret = rtc_engine_.SetupRemoteVideo(canvas);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }
    }
}
