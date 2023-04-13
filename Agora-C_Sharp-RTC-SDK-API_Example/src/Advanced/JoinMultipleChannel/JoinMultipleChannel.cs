/*
 * 【多频道】关键步骤：
 * 1. 创建Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]、SetChannelProfile）
 *    创建频道1：（CreateChannel、SetClientRole、InitEventHandler）
 *    创建频道2：（CreateChannel、SetClientRole、InitEventHandler）
 *    
 * 2. 加入频道
 *    Engine：（EnableAudio、EnableVideo、SetupLocalVideo）
 *    频道1：（JoinChannel、Publish）
 *    频道2：（JoinChannel）
 *    
 *    远端加入频道1观察效果。
 *    远端加入频道2观察效果。   
 *    
 * 3. 离开频道
 *    频道1：（LeaveChannel）
 *    频道2：（LeaveChannel）
 * 4. 退出
 *    频道1：（LeaveChannel、Dispose）
 *    频道2：（LeaveChannel、Dispose）
 *    Engine：（Dispose）
 *    
 *    注意：目前多频道的API_Example仅支持两个频道，用户可以根据需要扩展，流程都是一样的。
 */

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
            first_connection_.channelId = channelId.Split(';').GetValue(0).ToString();
            first_connection_.localUid = (uint)new Random().Next(0, 50000);

            second_connection_.channelId = channelId.Split(';').GetValue(1).ToString();
            second_connection_.localUid = (uint)new Random().Next(50000, 100000);

            if (null == rtc_engine_)
            {
                rtc_engine_ = RtcEngine.CreateAgoraRtcEngine();
            }
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, 0, CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING, AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "Initialize", ret);

            event_handler_ = new JoinMultipleChannelEventHandler(this);
            ret = rtc_engine_.InitEventHandler(event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;

            if (null != rtc_engine_)
            {
                IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;
                engine_ex.LeaveChannelEx(first_connection_);
                engine_ex.LeaveChannelEx(second_connection_);

                rtc_engine_.Dispose(true);
                rtc_engine_ = null;
            }

            return ret;
        }

        internal override int JoinChannel()
        {
            int ret = -1;

            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;

            ChannelMediaOptions options = new ChannelMediaOptions();
            options.publishCameraTrack.SetValue(true);
            options.publishMicrophoneTrack.SetValue(true);


            ret = engine_ex.JoinChannelEx("", first_connection_, options);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "JoinChannel(ch1)", ret);

            ret = engine_ex.JoinChannelEx("", second_connection_, options);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "JoinChannel(ch2)", ret);

            VideoCanvas vs = new VideoCanvas((long)local_win_id_, RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, 0);
            ret = rtc_engine_.SetupLocalVideo(vs);

            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;

            IRtcEngineEx engine_ex = (IRtcEngineEx)rtc_engine_;
            ret = engine_ex.LeaveChannelEx(first_connection_);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannel(ch1)", ret);

            ret = engine_ex.LeaveChannelEx(second_connection_);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannel(ch2)", ret);

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
            var vc = new VideoCanvas((long)win_id, RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, remoteUid);
            int ret = CSharpForm.usr_engine_.GetEngine().SetupRemoteVideo(vc);
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
