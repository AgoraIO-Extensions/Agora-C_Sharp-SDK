using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class JoinMultipleChannel : IEngine
    {
        private string app_id_ = "";
        private readonly string JoinMultipleChannel_TAG = "[JoinMultipleChannel] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private IRtcEngine rtc_engine_ = null;
        private IRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_first_win_id_ = IntPtr.Zero;
        private IntPtr remote_second_win_id_ = IntPtr.Zero;
        private RtcConnection first_connection_ = new RtcConnection();
        private RtcConnection second_connection_ = new RtcConnection();

        public JoinMultipleChannel(IntPtr localWindowId, IntPtr remoteFirstWindowId, IntPtr remoteSecondWindowId)
        {
            local_win_id_ = localWindowId;
            remote_first_win_id_ = remoteFirstWindowId;
            remote_second_win_id_ = remoteSecondWindowId;
        }

        internal override int Init(string appId, string channelId)
        {
            int ret = -1;
            app_id_ = appId;

            var channels = channelId.Split(';');
            if (channels.Length < 2)
            {
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "Input two channel names like channel1;channel2", ret);
                return ret;
            }

            first_connection_.channelId = channelId.Split(';').GetValue(0).ToString();
            first_connection_.localUid = (uint)new Random().Next(0, 50000);

            second_connection_.channelId = channelId.Split(';').GetValue(1).ToString();
            second_connection_.localUid = (uint)new Random().Next(0, 50000);

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
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "Initialize", ret);

            // Register event handler
            event_handler_ = new JoinMultipleChannelEventHandler(this);
            ret = rtc_engine_.InitEventHandler(event_handler_);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "InitEventHandler", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "StartPreview", ret);

            // Setup local video
            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)local_win_id_;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

            ret = rtc_engine_.SetupLocalVideo(canvas);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "SetupLocalVideo", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;

            if (null != rtc_engine_)
            {
                IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

                // Leave channel
                ret = engine_ex.LeaveChannelEx(first_connection_);
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannelEx first connection", ret);

                // Leave channel
                ret = engine_ex.LeaveChannelEx(second_connection_);
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannelEx second connection", ret);

                // Stop preview
                ret = rtc_engine_.StopPreview();
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "DisableVideo", ret);

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
                IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);


                ret = engine_ex.JoinChannelEx("", first_connection_, options);
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "JoinChannelEx(ch1)", ret);

                ret = engine_ex.JoinChannelEx("", second_connection_, options);
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "JoinChannelEx(ch2)", ret);
            }

            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;

            if (null != rtc_engine_)
            {
                IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;
                ret = engine_ex.LeaveChannelEx(first_connection_);
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannelEx(ch1)", ret);

                ret = engine_ex.LeaveChannelEx(second_connection_);
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannelEx(ch2)", ret);
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

        internal string GetFistChannelId()
        {
            return first_connection_.channelId;
        }

        internal string GetSecondChannelId()
        {
            return second_connection_.channelId;
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
    }

    // override if need
    internal class JoinMultipleChannelEventHandler : IRtcEngineEventHandler
    {
        private JoinMultipleChannel joinMultipleChannel_inst = null;
        public JoinMultipleChannelEventHandler(JoinMultipleChannel _joinMultipleChannel)
        {
            joinMultipleChannel_inst = _joinMultipleChannel;
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
            Console.WriteLine("----->OnLeaveChannel, channel={0}, duration={1}", connection.channelId, stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined, channel={0}, uid={1}", connection.channelId, remoteUid);

            IntPtr win_id = IntPtr.Zero;

            if (connection.channelId == joinMultipleChannel_inst.GetFistChannelId())
            {
                win_id = joinMultipleChannel_inst.GetRemoteFirstWinId();
            }
            else if (connection.channelId == joinMultipleChannel_inst.GetSecondChannelId())
            {
                win_id = joinMultipleChannel_inst.GetRemoteSecondWinId();
            }
            else
            {
                Console.WriteLine("----->OnUserJoined, invalid channelId{0}  !!!", connection.channelId);
                return;
            }

            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)win_id;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
            canvas.uid = remoteUid;

            int ret = joinMultipleChannel_inst.GetEngine().SetupRemoteVideo(canvas);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, channel={0}, remoteUid={1}, reason={2}", connection.channelId, remoteUid, reason);
        }

        public override void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
            Console.WriteLine("----->OnRemoteVideoStats, channel={0}, stats={1}", connection.channelId, stats);
        }

        public override void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
            Console.WriteLine("----->OnRemoteAudioStats, channel={0}, stats={1}", connection.channelId, stats);
        }
    }
}
