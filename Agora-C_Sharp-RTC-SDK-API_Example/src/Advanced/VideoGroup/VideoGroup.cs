/*
 * 【多人视频】关键步骤：
 * 1. 创建Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 * 
 * 2. 加入频道：（[EnableAudio]、EnableVideo、JoinChannel）
 * 用户从远端根据相同的AppId、ChannelId加入
 * 
 * 3. 离开频道：（LeaveChannel）
 * 
 * 4. 退出：（Dispose）
 */
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
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, 0, CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING, AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(VideoGroup_TAG + "Initialize", ret);
            ret = rtc_engine_.SetLogFile(log_file_path);
            CSharpForm.dump_handler_(VideoGroup_TAG + "SetLogFile", ret);
            event_handler_ = new VideoGroupEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
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
                CSharpForm.dump_handler_(VideoGroup_TAG + "EnableAudio", ret);
                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(VideoGroup_TAG + "EnableVideo", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "");
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
            VideoCanvas vs = new VideoCanvas((long)videoGroup_inst_.GetLocalWindowId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, 0);
            int ret = CSharpForm.usr_engine_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo, ret={0}", ret);
        }

        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel, duration={0}", stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined, uid={0}", remoteUid);
            VideoCanvas vc = null;

            // only consider two users here
            if (remoteWin_idx_++ % 2 == 0)
            {
                vc = new VideoCanvas((long)videoGroup_inst_.GetRemoteFirstWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, remoteUid);
            }
            else
            {
                vc = new VideoCanvas((long)videoGroup_inst_.GetRemoteSecondWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, remoteUid);
            }
            int ret = CSharpForm.usr_engine_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->OnUserJoined, ret={0}", ret);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, reason={0}", reason);
        }

        //public override void OnRemoteVideoStats(RemoteVideoStats stats)
        //{
        //    Console.WriteLine("----->OnRemoteVideoStats, stats={0}", stats);
        //}

        //public override void OnRemoteAudioStats(RemoteAudioStats stats)
        //{
        //    Console.WriteLine("----->OnRemoteAudioStats, stats={0}", stats);
        //}
    }
}
