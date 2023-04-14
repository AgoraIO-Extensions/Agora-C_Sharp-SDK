using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class VideoGroup : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string VideoGroup_TAG = "[VideoGroup] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private IRtcEngine rtc_engine_ = null;
        private IRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_first_win_id_ = IntPtr.Zero;
        private IntPtr remote_second_win_id_ = IntPtr.Zero;

        public VideoGroup(IntPtr localWindowId, IntPtr remoteFirstWindowId, IntPtr remoteSecondWindowId)
        {
            local_win_id_ = localWindowId;
            remote_first_win_id_ = remoteFirstWindowId;
            remote_second_win_id_ = remoteSecondWindowId;
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
            CSharpForm.dump_handler_(VideoGroup_TAG + "Initialize", ret);

            // Register event handler
            event_handler_ = new VideoGroupEventHandler(this);
            ret = rtc_engine_.InitEventHandler(event_handler_);
            CSharpForm.dump_handler_(VideoGroup_TAG + "InitEventHandler", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            CSharpForm.dump_handler_(VideoGroup_TAG + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            CSharpForm.dump_handler_(VideoGroup_TAG + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            CSharpForm.dump_handler_(VideoGroup_TAG + "StartPreview", ret);

            // Setup local video
            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)local_win_id_;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

            ret = rtc_engine_.SetupLocalVideo(canvas);
            CSharpForm.dump_handler_(VideoGroup_TAG + "SetupLocalVideo", ret);


            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                // Leave channel
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(VideoGroup_TAG + "LeaveChannel", ret);

                // Stop preview
                ret = rtc_engine_.StopPreview();
                CSharpForm.dump_handler_(VideoGroup_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                CSharpForm.dump_handler_(VideoGroup_TAG + "DisableVideo", ret);

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

                CSharpForm.dump_handler_(VideoGroup_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;

            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(VideoGroup_TAG + "LeaveChannel", ret);
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
        internal IntPtr GetLocalWindowId()
        {
            return local_win_id_;
        }

        internal IntPtr GetRemoteFirstWinId()
        {
            return remote_first_win_id_;
        }

        internal IntPtr GetRemoteSecondWinId()
        {
            return remote_second_win_id_;
        }

        internal string GetChannelId()
        {
            return channel_id_;
        }
    }

    // override if need
    internal class VideoGroupEventHandler : IRtcEngineEventHandler
    {
        private VideoGroup videoGroup_inst_ = null;
        private int remoteWin_idx_ = 0;
        public VideoGroupEventHandler(VideoGroup _videoGroup)
        {
            videoGroup_inst_ = _videoGroup;
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("=====>OnError {0} {1}", error, msg);
        }

        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", connection.channelId, connection.localUid);
        }

        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel, duration={0}", stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0}", remoteUid);

            VideoCanvas canvas = new VideoCanvas();
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
            canvas.uid = remoteUid;

            // only consider two users here
            if (remoteWin_idx_++ % 2 == 0)
            {
                canvas.view = (long)videoGroup_inst_.GetRemoteFirstWinId();
            }
            else
            {
                canvas.view = (long)videoGroup_inst_.GetRemoteSecondWinId();
            }

            int ret = CSharpForm.usr_engine_.GetEngine().SetupRemoteVideo(canvas);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, channel={0}, remoteUid={1}, reason={2}", connection.channelId, remoteUid, reason);
        }

        public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            Console.WriteLine("----->OnRemoteVideoStateChanged, channel={0}, remoteUid={1}, state={2}, reason={3}", connection.channelId, remoteUid, state, reason);
        }
    }
}
