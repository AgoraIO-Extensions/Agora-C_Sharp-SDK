/// <summary>
/// [Multiple People]Key Step：
/// 1. Create Engine and Initialize：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
/// 
/// 2. Join Channel：（[EnableAudio]、EnableVideo、JoinChannel）
///    Remote user initialize with the same appid and join the same channel
/// 
/// 3. Leave Channel：（LeaveChannel）
/// 
/// 4. Exit：（Dispose）
/// <summary>
using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class VideoGroup : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string VideoGroup_TAG = "[VideoGroup] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
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
                rtc_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine();
            }
            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(VideoGroup_TAG + "Initialize", ret);
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
            //createEngine();
            return rtc_engine_.GetVersion();
        }

        internal override IAgoraRtcEngine GetEngine()
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
    internal class VideoGroupEventHandler : IAgoraRtcEngineEventHandler
    {
        private VideoGroup videoGroup_inst_ = null;
        private int remoteWin_idx_ = 0;
        public VideoGroupEventHandler(VideoGroup _videoGroup)
        {
            videoGroup_inst_ = _videoGroup;
        }
        
        public override void OnWarning(int warn, string msg)
        {
            Console.WriteLine("=====>OnWarning {0} {1}", warn, msg);
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("=====>OnError {0} {1}", error, msg);
        }

        public override void OnJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess, channel={0}, uid={1}", channel, uid);
            VideoCanvas vs = new VideoCanvas((ulong)videoGroup_inst_.GetLocalWindowId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = CSharpForm.usr_engine_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo, ret={0}", ret);
        }

        public override void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnRejoinChannelSuccess");
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel, duration={0}", stats.duration);
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined, uid={0}", uid);
            VideoCanvas vc = null;

            // only consider two users here
            if (remoteWin_idx_++ % 2 == 0)
            {
                vc = new VideoCanvas((ulong)videoGroup_inst_.GetRemoteFirstWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, videoGroup_inst_.GetChannelId(), uid);
            }
            else
            {
                vc = new VideoCanvas((ulong)videoGroup_inst_.GetRemoteSecondWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, videoGroup_inst_.GetChannelId(), uid);
            }
                int ret = CSharpForm.usr_engine_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->OnUserJoined, ret={0}", ret);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
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
