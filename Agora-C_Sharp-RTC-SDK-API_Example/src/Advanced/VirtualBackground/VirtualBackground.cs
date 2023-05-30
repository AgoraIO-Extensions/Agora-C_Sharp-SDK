using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class VirtualBackground : IEngine
    {
        private readonly string VirtualBackground_TAG = "[VirtualBackground] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private VirtualBackgroundView view_ = null;

        public VirtualBackground(System.Windows.Forms.UserControl view)
        {
            view_ = (VirtualBackgroundView)view;
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
            MainForm.dump_handler_(VirtualBackground_TAG + "Initialize", ret);

            // Register event handler
            ret = rtc_engine_.InitEventHandler(this);
            MainForm.dump_handler_(VirtualBackground_TAG + "InitEventHandler", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            MainForm.dump_handler_(VirtualBackground_TAG + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            MainForm.dump_handler_(VirtualBackground_TAG + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            MainForm.dump_handler_(VirtualBackground_TAG + "StartPreview", ret);

            // Setup local video
            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)view_.localVideoView.Handle;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

            ret = rtc_engine_.SetupLocalVideo(canvas);
            MainForm.dump_handler_(VirtualBackground_TAG + "SetupLocalVideo", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                // Stop preview
                ret = rtc_engine_.StopPreview();
                MainForm.dump_handler_(VirtualBackground_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                MainForm.dump_handler_(VirtualBackground_TAG + "DisableVideo", ret);

                // Leave channel
                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(VirtualBackground_TAG + "LeaveChannel", ret);

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
                MainForm.dump_handler_(VirtualBackground_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(VirtualBackground_TAG + "LeaveChannel", ret);
            }
            return ret;
        }

        // override IRtcEngineEventHandler
        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", connection.channelId, connection.localUid);
            VideoCanvas vs = new VideoCanvas((long)view_.localVideoView.Handle, RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, 0);
            int ret = rtc_engine_.SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo ret={0}", ret);
        }

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

        public override void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            if(source == VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA && state == LOCAL_VIDEO_STREAM_STATE.LOCAL_VIDEO_STREAM_STATE_CAPTURING)
            {
                // Enable virtula background, must call this after enableVideo or startPreview
                VirtualBackgroundSource virtual_background_source = new VirtualBackgroundSource
                {
                    background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_IMG,
                    source = ".\\src\\Advanced\\VirtualBackground\\virtual_back_ground.jpg"  // path to background image
                };

                int ret = rtc_engine_.EnableVirtualBackground(true, virtual_background_source, new SegmentationProperty());
                MainForm.dump_handler_(VirtualBackground_TAG + "EnableVirtualBackground", ret);
            }
            base.OnLocalVideoStateChanged(source, state, errorCode);
        }
    }
}
