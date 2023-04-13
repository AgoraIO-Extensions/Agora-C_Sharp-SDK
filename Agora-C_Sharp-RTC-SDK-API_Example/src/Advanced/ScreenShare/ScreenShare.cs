/*
 * 双进程【摄像头 + 屏幕共享】关键步骤：
 * 1. 创建共享摄像头的Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 *    创建共享屏幕的Engine并初始化：（CreateAgoraRtcEngine(AgoraEngineType.SubProcess)、Initialize、[InitEventHandler]）
 *    
 * 2. 加入频道
 *     摄像头：（[EnableAudio]、[EnableVideo]、[MuteAllRemoteAudioStreams]、JoinChannel）
 *     共享屏幕：（StartScreenCaptureByDisplayId、EnableVideo、JoinChannel）
 *     
 * 3. 离开频道：（LeaveChannel）
 *    共享屏幕：（StopScreenCapture、LeaveChannel）
 *    摄像头：（LeaveChannel）
 *    
 * 4. 退出
 *    共享屏幕：（LeaveChannel、Dispose）
 *    摄像头：（LeaveChannel、Dispose）
 */

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

            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, 0, CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING, AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_("Initialize", ret);

            event_handler_ = new ScreenShareEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            CSharpForm.dump_handler_(ScreenShare_TAG + "Initialize", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;

            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_("LeaveChannel", ret);

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
                ret = rtc_engine_.EnableAudio();
                CSharpForm.dump_handler_("EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_("EnableVideo", ret);

                // disable echo if need
                //ret = rtc_engine.MuteAllRemoteAudioStreams(true);
                //CSharpForm.dump_handler("MuteAllRemoteAudioStreams", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_("JoinChannel", ret);
            }

            ret = startScreenShare();
            CSharpForm.dump_handler_(ScreenShare_TAG + "startScreenShare", ret);

            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            ret = stopScreenShare();
            CSharpForm.dump_handler_(ScreenShare_TAG + "stopScreenShare", ret);

            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_("LeaveChannel", ret);
            }
            return ret;
        }

        private int startScreenShare()
        {
            int ret = -1;
            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

            Rectangle rectangle = new Rectangle();
            ScreenCaptureParameters capture_params = new ScreenCaptureParameters();
            capture_params.bitrate = 0;
            capture_params.frameRate = 15;
            capture_params.enableHighLight = true;
            capture_params.dimensions.width = 1920;
            capture_params.dimensions.height = 1080;
            ret = engine_ex.StartScreenCaptureByDisplayId(0, rectangle, capture_params);

            if (ret != 0) return ret;

            ChannelMediaOptions options = new ChannelMediaOptions();
            options.publishCameraTrack.SetValue(false);
            options.autoSubscribeAudio.SetValue(false);
            options.autoSubscribeVideo.SetValue(false);
            options.publishScreenTrack.SetValue(true);

            screenshare_connection_.channelId = channel_id_;
            screenshare_connection_.localUid = (uint)new Random().Next(0, 50000);
            ret = engine_ex.JoinChannelEx("", screenshare_connection_, options);

            return ret;
        }

        private int stopScreenShare()
        {
            int ret = -1;
            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

            ret = engine_ex.StopScreenCapture();
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
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", connection.channelId, connection.localUid);
            VideoCanvas vs = new VideoCanvas((long)screenShare_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, 0);
            int ret = screenShare_inst_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo, ret={0}", ret);
        }


        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel, duration={0}", stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined, uid={0}", remoteUid);
            if (screenShare_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((long)screenShare_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, remoteUid);
            int ret = screenShare_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->OnUserJoined, ret={0}", ret);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, channel={0}, remoteUid={1}, reason={2}", connection.channelId, remoteUid, reason);
        }
    }
}
