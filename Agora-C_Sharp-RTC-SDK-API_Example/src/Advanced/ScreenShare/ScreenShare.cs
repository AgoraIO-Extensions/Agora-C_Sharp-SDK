using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class ScreenShare : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string ScreenShare_TAG = "[ScreenShare] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private IRtcEngine rtc_engine_ = null;
        private IRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;
        private RtcConnection screenshare_connection_ = new RtcConnection();

        public ScreenShare(IntPtr localWindowId, IntPtr remoteWindowId)
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
            CSharpForm.dump_handler_(ScreenShare_TAG + "Initialize", ret);

            // Register event handler
            event_handler_ = new ScreenShareEventHandler(this);
            ret = rtc_engine_.InitEventHandler(event_handler_);
            CSharpForm.dump_handler_(ScreenShare_TAG + "InitEventHandler", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            CSharpForm.dump_handler_(ScreenShare_TAG + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            CSharpForm.dump_handler_(ScreenShare_TAG + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            CSharpForm.dump_handler_(ScreenShare_TAG + "StartPreview", ret);

            // Setup local video
            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)local_win_id_;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

            ret = rtc_engine_.SetupLocalVideo(canvas);
            CSharpForm.dump_handler_(ScreenShare_TAG + "SetupLocalVideo", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;

            if (null != rtc_engine_)
            {
                // Leave channel
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(ScreenShare_TAG + "LeaveChannel", ret);

                // Stop preview
                ret = rtc_engine_.StopPreview();
                CSharpForm.dump_handler_(ScreenShare_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                CSharpForm.dump_handler_(ScreenShare_TAG + "DisableVideo", ret);

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
                // Join channel for camera
                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

                ret = rtc_engine_.JoinChannel("", channel_id_, 0, options);

                CSharpForm.dump_handler_(ScreenShare_TAG + "JoinChannel", ret);


                // Start screenshare
                ret = startScreenShare();
                CSharpForm.dump_handler_(ScreenShare_TAG + "startScreenShare", ret);
            }

            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;

            if (null != rtc_engine_)
            {
                // Stop screenshare
                ret = stopScreenShare();
                CSharpForm.dump_handler_(ScreenShare_TAG + "stopScreenShare", ret);


                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(ScreenShare_TAG + "LeaveChannel", ret);
            }
            return ret;
        }

        private int startScreenShare()
        {
            int ret = -1;
            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

            // Start screen capture with primary display which is always 0 for Windows
            Rectangle rectangle = new Rectangle();
            ScreenCaptureParameters capture_params = new ScreenCaptureParameters();
            capture_params.bitrate = 0;
            capture_params.frameRate = 15;
            capture_params.enableHighLight = true;
            capture_params.dimensions.width = 1920;
            capture_params.dimensions.height = 1080;
            ret = engine_ex.StartScreenCaptureByDisplayId(0, rectangle, capture_params);
            CSharpForm.dump_handler_(ScreenShare_TAG + "StartScreenCaptureByDisplayId", ret);

            if (ret != 0) return ret;


            // Set connection for screenshare
            screenshare_connection_.channelId = channel_id_;
            screenshare_connection_.localUid = (uint)new Random().Next(0, 50000);

            // Mute video stream of screenshare connection coz we do not need to recv again
            ret = engine_ex.MuteRemoteVideoStream(screenshare_connection_.localUid, true);

            // Mute audio stream of screenshare connection coz we do not need to recv again
            ret = engine_ex.MuteRemoteAudioStream(screenshare_connection_.localUid, true);

            // Join channel with a new connection and disable auto subscribe remote streams
            ChannelMediaOptions options = new ChannelMediaOptions();
            options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
            options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
            options.publishCameraTrack.SetValue(false);
            options.publishMicrophoneTrack.SetValue(false);
            options.autoSubscribeAudio.SetValue(false);
            options.autoSubscribeVideo.SetValue(false);
            options.publishScreenTrack.SetValue(true);

            ret = engine_ex.JoinChannelEx("", screenshare_connection_, options);
            CSharpForm.dump_handler_(ScreenShare_TAG + "JoinChannelEx", ret);

            return ret;
        }

        private int stopScreenShare()
        {
            int ret = -1;
            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

            // Stop screen capture
            ret = engine_ex.StopScreenCapture();

            // Leave channel with specified connection
            ret = engine_ex.LeaveChannelEx(screenshare_connection_);

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

        internal uint GetScrenShareUid()
        {
            return screenshare_connection_.localUid;
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
    internal class ScreenShareEventHandler : IRtcEngineEventHandler
    {
        private ScreenShare screenShare_inst_ = null;

        public ScreenShareEventHandler(ScreenShare _screenShare)
        {
            screenShare_inst_ = _screenShare;
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("=====>OnError {0} {1}", error, msg);
        }

        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            // ScreenShare connection event
            if (screenShare_inst_.GetScrenShareUid() == connection.localUid)
            {
                Console.WriteLine("----->OnJoinChannelSuccessEx uid={0}", connection.localUid);
            }
            else // Primary connection event
            {
                Console.WriteLine("----->OnJoinChannelSuccess uid={0}", connection.localUid);
            }
        }


        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            // ScreenShare connection event
            if (screenShare_inst_.GetScrenShareUid() == connection.localUid)
            {
                Console.WriteLine("----->OnLeaveChannelEx, duration={0}", stats.duration);
            }
            else // Primary connection event
            {
                Console.WriteLine("----->OnLeaveChannel, duration={0}", stats.duration);
            }
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            // ScreenShare connection event
            if (screenShare_inst_.GetScrenShareUid() == connection.localUid)
            {
                Console.WriteLine("----->OnUserJoinedEx, uid={0}", remoteUid);
            }
            else // Primary connection event
            {
                Console.WriteLine("----->OnUserJoined, uid={0}", remoteUid);

                // We do not set canvas in this way for local screenshare
                // We can use functions below to preview screenshare after startScreenCapture
                //{
                //    engine_ex.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_SCREEN_PRIMARY);
                //    VideoCanvas canvas = new VideoCanvas();
                //    canvas.view = (long)GetRemoteWinId();
                //    canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
                //    canvas.uid = screenshare_connection_.localUid;
                //    engine_ex.SetupLocalVideo(canvas);
                //}

                if (screenShare_inst_.GetScrenShareUid() == remoteUid)
                {
                    return;
                }

                VideoCanvas canvas = new VideoCanvas();
                canvas.view = (long)screenShare_inst_.GetRemoteWinId();
                canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
                canvas.uid = remoteUid;

                int ret = screenShare_inst_.GetEngine().SetupRemoteVideo(canvas);

                Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
            }
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            // ScreenShare connection event
            if (screenShare_inst_.GetScrenShareUid() == connection.localUid)
            {
                Console.WriteLine("----->OnUserOfflineEx, remoteUid={1}, reason={2}", remoteUid, reason);
            }
            else // Primary connection event
            {
                Console.WriteLine("----->OnUserOffline, remoteUid={1}, reason={2}", remoteUid, reason);
            }


        }
    }
}
