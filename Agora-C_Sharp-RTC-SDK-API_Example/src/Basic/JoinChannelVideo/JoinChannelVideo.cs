/*
 * 【一对一视频】关键步骤：
 * 1. 创建Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 * 
 * 2. 加入频道：（[EnableAudio]、EnableVideo、JoinChannel）
 * 
 * 3. 离开频道：（LeaveChannel）
 * 
 * 4. 退出：（Dispose）
 */

using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class JoinChannelVideo : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string JoinChannelVideo_TAG = "[JoinChannelVideo] ";
        private readonly string log_file_path = "logs";
        private IRtcEngine rtc_engine_ = null;
        private IRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;

        public JoinChannelVideo(IntPtr localWindowId, IntPtr remoteWindowId)
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
            CSharpForm.dump_handler_(JoinChannelVideo_TAG + "Initialize", ret);

            // Register event handler
            event_handler_ = new JoinChannelVideoEventHandler(this);
            ret = rtc_engine_.InitEventHandler(event_handler_);
            CSharpForm.dump_handler_(JoinChannelVideo_TAG + "InitEventHandler", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            CSharpForm.dump_handler_(JoinChannelVideo_TAG + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            CSharpForm.dump_handler_(JoinChannelVideo_TAG + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            CSharpForm.dump_handler_(JoinChannelVideo_TAG + "StartPreview", ret);

            // Setup local video
            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)local_win_id_;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

            ret = rtc_engine_.SetupLocalVideo(canvas);
            CSharpForm.dump_handler_(JoinChannelVideo_TAG + "SetupLocalVideo", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(JoinChannelVideo_TAG + "LeaveChannel", ret);

                ret = rtc_engine_.StopPreview();
                CSharpForm.dump_handler_(JoinChannelVideo_TAG + "StopPreview", ret);

                ret = rtc_engine_.DisableVideo();
                CSharpForm.dump_handler_(JoinChannelVideo_TAG + "DisableVideo", ret);

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

                CSharpForm.dump_handler_(JoinChannelVideo_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(JoinChannelVideo_TAG + "LeaveChannel", ret);
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
    internal class JoinChannelVideoEventHandler : IRtcEngineEventHandler
    {
        private JoinChannelVideo joinChannelVideo_inst_ = null;

        public JoinChannelVideoEventHandler(JoinChannelVideo _joinChannelVideo)
        {
            joinChannelVideo_inst_ = _joinChannelVideo;
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
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0}", remoteUid);
            if (joinChannelVideo_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((long)joinChannelVideo_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, remoteUid);
            int ret = joinChannelVideo_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }
    }
}
