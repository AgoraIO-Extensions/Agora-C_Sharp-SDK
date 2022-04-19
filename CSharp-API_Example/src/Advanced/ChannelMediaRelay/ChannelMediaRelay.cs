/*
 * 【一对一视频】关键步骤：
 * 1. 创建Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 * 
 * 2. 加入频道：（[EnableAudio]、EnableVideo、JoinChannel）
 * 
 * 3. startChannelMediaRelay
 * 
 * 4. stopChannelMediaRelay
 * 
 * 5. 离开频道：（LeaveChannel）
 * 
 * 6. 退出：（Dispose）
 */

using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class ChannelMediaRelay : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string ChannelMediaRelay_TAG = "[ChannelMediaRelay] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;
        uint uid = 0;
        public ChannelMediaRelay(IntPtr localWindowId, IntPtr remoteWindowId)
        {
            local_win_id_ = localWindowId;
            remote_win_id_ = remoteWindowId;
        }

        internal override int Init(string appId, string channelId)
        {
            int ret = -1;
            app_id_ = appId;
            channel_id_ = channelId.Split(';').GetValue(0).ToString();
            Random rd = new Random();
            uid = (uint)rd.Next(1, 999999);
            if (null == rtc_engine_)
            {
                rtc_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine();
            }

            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(ChannelMediaRelay_TAG + "Initialize", ret);
            event_handler_ = new ChannelMediaRelayEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            return ret;
        }
        internal override int UnInit()
        {
            uid = 0;
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(ChannelMediaRelay_TAG + "LeaveChannel", ret);

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
                CSharpForm.dump_handler_(ChannelMediaRelay_TAG + "EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(ChannelMediaRelay_TAG + "EnableVideo", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info", uid);
                CSharpForm.dump_handler_(ChannelMediaRelay_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(ChannelMediaRelay_TAG + "LeaveChannel", ret);
            }
            return ret;
        }

        internal override string GetSDKVersion()
        {
            if (null == rtc_engine_)
                return "-" + (ERROR_CODE_TYPE.ERR_NOT_INITIALIZED).ToString();

            return rtc_engine_.GetVersion();
        }

        internal override IAgoraRtcEngine GetEngine()
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

        public override int StartMediaRelay(string channelName)
        {
            if (null == rtc_engine_)
                return 0;
            ChannelMediaRelayConfiguration configuration = new ChannelMediaRelayConfiguration();
            configuration.srcInfo = new ChannelMediaInfo();
         
            configuration.srcInfo.channelName = channel_id_;
            configuration.srcInfo.uid = uid;
            configuration.destCount = 1;
            configuration.destInfos = new ChannelMediaInfo[1];
            configuration.destInfos[0] = new ChannelMediaInfo();
            configuration.destInfos[0].uid = uid;
            configuration.destInfos[0].channelName = channelName;
            int ret = rtc_engine_.StartChannelMediaRelay(configuration);
            CSharpForm.dump_handler_(ChannelMediaRelay_TAG + "StartChannelMediaRelay", ret);

            return ret;
        }
        public override int StopMediaRelay()
        {
            if (null == rtc_engine_)
                return 0;
            int ret = rtc_engine_.StopChannelMediaRelay();
            CSharpForm.dump_handler_(ChannelMediaRelay_TAG + "StopChannelMediaRelay", ret);

            return ret;
        }
    }

    // override if need
    internal class ChannelMediaRelayEventHandler : IAgoraRtcEngineEventHandler
    {
        private ChannelMediaRelay ChannelMediaRelay_inst_ = null;
   
        public ChannelMediaRelayEventHandler(ChannelMediaRelay _ChannelMediaRelay) {
            ChannelMediaRelay_inst_ = _ChannelMediaRelay;
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
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", channel, uid);
            VideoCanvas vs = new VideoCanvas((ulong)ChannelMediaRelay_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = ChannelMediaRelay_inst_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo ret={0}", ret);
        }

        public override void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnRejoinChannelSuccess");
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0}", uid);
            if (ChannelMediaRelay_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)ChannelMediaRelay_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, ChannelMediaRelay_inst_.GetChannelId(), uid);
            int ret = ChannelMediaRelay_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }
    }
}
