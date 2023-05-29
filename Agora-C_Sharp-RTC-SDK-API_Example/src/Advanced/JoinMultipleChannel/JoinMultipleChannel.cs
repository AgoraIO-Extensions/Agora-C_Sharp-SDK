using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class JoinMultipleChannel : IEngine
    {
        private readonly string JoinMultipleChannel_TAG = "[JoinMultipleChannel] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private RtcConnection first_connection_ = new RtcConnection();
        private RtcConnection second_connection_ = new RtcConnection();
        private JoinMultipleChannelView view_ = null;

        public JoinMultipleChannel(System.Windows.Forms.UserControl view)
        {
            view_ = (JoinMultipleChannelView)view;
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
            MainForm.dump_handler_(JoinMultipleChannel_TAG + "Initialize", ret);

            // Register event handler
            ret = rtc_engine_.InitEventHandler(this);
            MainForm.dump_handler_(JoinMultipleChannel_TAG + "InitEventHandler", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            MainForm.dump_handler_(JoinMultipleChannel_TAG + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            MainForm.dump_handler_(JoinMultipleChannel_TAG + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            MainForm.dump_handler_(JoinMultipleChannel_TAG + "StartPreview", ret);

            // Setup local video
            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)view_.localVideoView.Handle;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

            ret = rtc_engine_.SetupLocalVideo(canvas);
            MainForm.dump_handler_(JoinMultipleChannel_TAG + "SetupLocalVideo", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;

            if (null != rtc_engine_)
            {
                IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

                // Stop preview
                ret = rtc_engine_.StopPreview();
                MainForm.dump_handler_(JoinMultipleChannel_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                MainForm.dump_handler_(JoinMultipleChannel_TAG + "DisableVideo", ret);

                // Leave channel
                ret = engine_ex.LeaveChannelEx(first_connection_);
                MainForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannelEx first connection", ret);

                // Leave channel
                ret = engine_ex.LeaveChannelEx(second_connection_);
                MainForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannelEx second connection", ret);

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
                IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

                var channels = channelId.Split(';');
                if (channels.Length < 2)
                {
                    MainForm.dump_handler_(JoinMultipleChannel_TAG + "Input two channel names like channel1;channel2", ret);
                    return ret;
                }

                first_connection_.channelId = channelId.Split(';').GetValue(0).ToString();
                first_connection_.localUid = (uint)new Random().Next(0, 50000);

                second_connection_.channelId = channelId.Split(';').GetValue(1).ToString();
                second_connection_.localUid = (uint)new Random().Next(0, 50000);

                ChannelMediaOptions options_ch1 = new ChannelMediaOptions();
                options_ch1.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options_ch1.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
                options_ch1.publishCameraTrack.SetValue(true);
                options_ch1.publishMicrophoneTrack.SetValue(true);


                ret = engine_ex.JoinChannelEx("", first_connection_, options_ch1);
                MainForm.dump_handler_(JoinMultipleChannel_TAG + "JoinChannelEx(ch1)", ret);

                ChannelMediaOptions options_ch2 = new ChannelMediaOptions();
                options_ch2.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options_ch2.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
                // coz video can only pub to one channel at the same time
                options_ch2.publishCameraTrack.SetValue(false);
                options_ch2.publishMicrophoneTrack.SetValue(true);

                ret = engine_ex.JoinChannelEx("", second_connection_, options_ch2);
                MainForm.dump_handler_(JoinMultipleChannel_TAG + "JoinChannelEx(ch2)", ret);
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
                MainForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannelEx(ch1)", ret);

                ret = engine_ex.LeaveChannelEx(second_connection_);
                MainForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannelEx(ch2)", ret);
            }

            return ret;
        }

        // override IRtcEngineEventHandler
        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined, channel={0}, uid={1}", connection.channelId, remoteUid);

            IntPtr win_id = IntPtr.Zero;

            if (connection.channelId == first_connection_.channelId)
            {
                win_id = view_.firstChannelVideoView.Handle;
            }
            else if (connection.channelId == second_connection_.channelId)
            {
                win_id = view_.secondChannelVideoView.Handle;
            }
            else
            {
                Console.WriteLine("----->OnUserJoined, invalid channelId {0}  !!!", connection.channelId);
                return;
            }

            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)win_id;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
            canvas.uid = remoteUid;



            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;
            int ret = engine_ex.SetupRemoteVideoEx(canvas, connection);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }
    }

}
