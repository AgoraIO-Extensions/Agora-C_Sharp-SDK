using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class VirtualBackground : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string VirtualBackground_TAG = "[VirtualBackground] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private IRtcEngine rtc_engine_ = null;
        private IRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;

        public VirtualBackground(IntPtr localWindowId, IntPtr remoteWindowId)
        {
            local_win_id_ = localWindowId;
            remote_win_id_ = remoteWindowId;
        }

        internal override int Init(string appId, string channelId)
        {
            int ret = -1;
            app_id_ = appId;
            channel_id_ = channelId.Split(';').GetValue(0).ToString();

            if (null == rtc_engine_)
            {
                rtc_engine_ = RtcEngine.CreateAgoraRtcEngine();
            }

            // Prepare engine context
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext();
            rtc_engine_ctx.appId = app_id_;
            rtc_engine_ctx.logConfig.filePath = log_file_path;

            // Initialize engine
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(VirtualBackground_TAG + "Initialize", ret);

            // Register event handler
            event_handler_ = new VirtualBackgroundEventHandler(this);
            ret = rtc_engine_.InitEventHandler(event_handler_);
            CSharpForm.dump_handler_(VirtualBackground_TAG + "InitEventHandler", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            CSharpForm.dump_handler_(VirtualBackground_TAG + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            CSharpForm.dump_handler_(VirtualBackground_TAG + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            CSharpForm.dump_handler_(VirtualBackground_TAG + "StartPreview", ret);

            // Enable virtula background, must call this after enableVideo or startPreview
            VirtualBackgroundSource virtual_background_source = new VirtualBackgroundSource
            {
                background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_IMG,
                source = ".\\src\\Advanced\\VirtualBackground\\virtual_back_ground.jpg"  // path to background image
            };

            ret = rtc_engine_.EnableVirtualBackground(true, virtual_background_source, new SegmentationProperty());
            CSharpForm.dump_handler_(VirtualBackground_TAG + "EnableVirtualBackground", ret);

            // Setup local video
            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)local_win_id_;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

            ret = rtc_engine_.SetupLocalVideo(canvas);
            CSharpForm.dump_handler_(VirtualBackground_TAG + "SetupLocalVideo", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                // Leave channel
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(VirtualBackground_TAG + "LeaveChannel", ret);

                // Stop preview
                ret = rtc_engine_.StopPreview();
                CSharpForm.dump_handler_(VirtualBackground_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                CSharpForm.dump_handler_(VirtualBackground_TAG + "DisableVideo", ret);

                // Dispose engine
                rtc_engine_.Dispose();
                rtc_engine_ = null;
            }
            return ret;
        }

        internal override int JoinChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

                ret = rtc_engine_.JoinChannel("", channel_id_, 0, options);
                CSharpForm.dump_handler_(VirtualBackground_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(VirtualBackground_TAG + "LeaveChannel", ret);
            }
            return ret;
        }

        internal override string GetSDKVersion()
        {
            if (null == rtc_engine_)
                return "-" + (ERROR_CODE_TYPE.ERR_NOT_INITIALIZED).ToString();
            int build = 0;
            return rtc_engine_.GetVersion(ref build);
        }

        internal override IRtcEngine GetEngine()
        {
            return rtc_engine_;
        }

        internal string GetChannelId()
        {
            return channel_id_;
        }

        internal IntPtr GetLocalWinId()
        {
            return local_win_id_;
        }

        internal IntPtr GetRemoteWinId()
        {
            return remote_win_id_;
        }
    }

    // override if need
    internal class VirtualBackgroundEventHandler : IRtcEngineEventHandler
    {
        private VirtualBackground virtualBackground_inst_ = null;

        public VirtualBackgroundEventHandler(VirtualBackground _virtualBackground)
        {
            virtualBackground_inst_ = _virtualBackground;
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("=====>OnError {0} {1}", error, msg);
        }

        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", connection.channelId, connection.localUid);
            VideoCanvas vs = new VideoCanvas((long)virtualBackground_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, 0);
            int ret = virtualBackground_inst_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo ret={0}", ret);
        }

        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0}", remoteUid);

            if (virtualBackground_inst_.GetRemoteWinId() == IntPtr.Zero) return;

            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)virtualBackground_inst_.GetRemoteWinId();
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
            canvas.uid = remoteUid;

            int ret = virtualBackground_inst_.GetEngine().SetupRemoteVideo(canvas);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, channel={0}, remoteUid={1}, reason={2}", connection.channelId, remoteUid, reason);
        }
    }
}
