using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class ScreenShare : IEngine
    {
        private readonly string ScreenShare_TAG = "[ScreenShare] ";
        private readonly string log_file_path = ".\\logs\\agora.log";

        private ScreenShareView view_ = null;
        private bool joined_ = false;
        private bool inited_ = false;

        private string channel_id_ = "";
        private RtcConnection screenshare_connection_ = new RtcConnection();
        private ScreenShareView.ScreenCaptureParams preview_params_;

        public ScreenShare(System.Windows.Forms.UserControl view)
        {
            view_ = (ScreenShareView)view;
            view_.onRefreshClicked = new ScreenShareView.OnRefreshClicked(OnRefreshClicked);
            view_.onStartClicked = new ScreenShareView.OnStartClicked(OnStartClicked);
            view_.onStopClicked = new ScreenShareView.OnStopClicked(OnStopClicked);
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
            MainForm.dump_handler_(ScreenShare_TAG + "Initialize", ret);

            // Register event handler
            ret = rtc_engine_.InitEventHandler(this);
            MainForm.dump_handler_(ScreenShare_TAG + "InitEventHandler", ret);

            inited_ = (ret == 0);

            return ret;
        }

        internal override int UnInit()
        {
            if (null != rtc_engine_)
            {
                // Dispose engine
                rtc_engine_.Dispose();
                rtc_engine_ = null;

                inited_ = false;
            }

            return 0;
        }

        internal override int JoinChannel(string channelId)
        {
            int ret = -1;
            if (null != rtc_engine_ && joined_ != true)
            {
                // Enable video
                ret = rtc_engine_.EnableVideo();
                MainForm.dump_handler_(ScreenShare_TAG + "EnableVideo", ret);

                // Start preview
                ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
                MainForm.dump_handler_(ScreenShare_TAG + "StartPreview", ret);

                // Setup local video
                VideoCanvas canvas = new VideoCanvas();
                canvas.view = (long)view_.localVideoView.Handle;
                canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

                ret = rtc_engine_.SetupLocalVideo(canvas);
                MainForm.dump_handler_(ScreenShare_TAG + "SetupLocalVideo", ret);

                // Join channel
                channel_id_ = channelId.Split(';').GetValue(0).ToString();

                // Join channel for camera
                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

                ret = rtc_engine_.JoinChannel("", channel_id_, 0, options);
                MainForm.dump_handler_(ScreenShare_TAG + "JoinChannel", ret);

                view_.AutoRefresh(OnRefreshClicked());

                joined_ = true;
            }

            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;

            if (null != rtc_engine_ && joined_ == true)
            {
                // Stop screenshare
                ret = stopScreenShare();
                MainForm.dump_handler_(ScreenShare_TAG + "stopScreenShare", ret);

                // Stop preview
                ret = rtc_engine_.StopPreview();
                MainForm.dump_handler_(ScreenShare_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                MainForm.dump_handler_(ScreenShare_TAG + "DisableVideo", ret);


                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(ScreenShare_TAG + "LeaveChannel", ret);

                joined_ = false;
            }

            return ret;
        }

        protected Agora.Rtc.ScreenCaptureSourceInfo[] OnRefreshClicked()
        {
            if (!inited_)
            {
                MainForm.dump_handler_(ScreenShare_TAG + "Must init engine first", 0);
                return new ScreenCaptureSourceInfo[0];
            }


            return rtc_engine_.GetScreenCaptureSources(new SIZE(300, 300), new SIZE(30, 30), true);
        }

        void OnStartClicked(ScreenShareView.ScreenCaptureParams parameters)
        {
            if (!inited_)
            {
                MainForm.dump_handler_(ScreenShare_TAG + "Must init engine first", 0);
                return;
            }

            int ret = -1;
            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

            preview_params_ = parameters;

            if (preview_params_.source.type == ScreenCaptureSourceType.ScreenCaptureSourceType_Screen)
            {
                ret = engine_ex.StartScreenCaptureByDisplayId((uint)preview_params_.source.sourceId,
                    new Rectangle(),
                    preview_params_.parameters);
                MainForm.dump_handler_(ScreenShare_TAG + "StartScreenCaptureByDisplayId", ret);
            }
            else if (preview_params_.source.type == ScreenCaptureSourceType.ScreenCaptureSourceType_Window)
            {
                ret = engine_ex.StartScreenCaptureByWindowId(preview_params_.source.sourceId,
                    new Rectangle(),
                    preview_params_.parameters);
                MainForm.dump_handler_(ScreenShare_TAG + "StartScreenCaptureByWindowId", ret);
            }
            else
            {
                MainForm.dump_handler_(ScreenShare_TAG + "StartScreenCapture with unspport source type", (int)preview_params_.source.type);
                return;
            }


            if (ret != 0) return;


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
            MainForm.dump_handler_(ScreenShare_TAG + "JoinChannelEx", ret);

            // Enable loopback recording
            if (preview_params_.loopback)
            {
                engine_ex.EnableLoopbackRecordingEx(screenshare_connection_, true, "");
            }
        }

        void OnStopClicked()
        {
            if (!inited_)
            {
                MainForm.dump_handler_(ScreenShare_TAG + "Must init engine first", 0);
                return;
            }

            stopScreenShare();
        }

        private int stopScreenShare()
        {
            int ret = -1;
            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

            // Disable loopback recording
            if (preview_params_.loopback)
            {
                engine_ex.EnableLoopbackRecordingEx(screenshare_connection_, false, "");
            }

            // Stop screen capture
            ret = engine_ex.StopScreenCapture();

            // Leave channel with specified connection
            ret = engine_ex.LeaveChannelEx(screenshare_connection_);

            return ret;
        }

        // override IRtcEngineEventHandler
        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            // ScreenShare connection event
            if (screenshare_connection_.localUid == connection.localUid)
            {
                view_.OnScreenShareState(true);
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
            if (screenshare_connection_.localUid == connection.localUid)
            {
                view_.OnScreenShareState(false);
                Console.WriteLine("----->OnLeaveChannel uid={0}", connection.localUid);
            }
            else // Primary connection event
            {
                Console.WriteLine("----->OnLeaveChannel uid={0}", connection.localUid);
            }
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            // ScreenShare connection event
            if (screenshare_connection_.localUid == connection.localUid)
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

                if (screenshare_connection_.localUid == remoteUid)
                {
                    return;
                }

                VideoCanvas canvas = new VideoCanvas();
                canvas.view = (long)view_.remoteVideoView.Handle;
                canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
                canvas.uid = remoteUid;

                int ret = rtc_engine_.SetupRemoteVideo(canvas);

                Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
            }
        }
    }
}
