/*
 * 【一对一语音】关键步骤：
 * 1. 创建Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 * 
 * 2. 加入频道：（[EnableAudio]、JoinChannel）
 * 
 * 3. 离开频道：（LeaveChannel）
 * 
 * 4. 退出：（Dispose）
 */

using System;
using agora.rtc;

namespace APIExample
{
    public class JoinChannelAudio : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string JoinChannelAudio_TAG = "[JoinChannelAudio] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;

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
            MainWindow.dump_handler_(JoinChannelAudio_TAG + "Initialize", ret);

            event_handler_ = new JoinChannelAudioEventHandler();
            rtc_engine_.InitEventHandler(event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                MainWindow.dump_handler_(JoinChannelAudio_TAG + "LeaveChannel", ret);

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
                MainWindow.dump_handler_(JoinChannelAudio_TAG + "EnableAudio", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                MainWindow.dump_handler_(JoinChannelAudio_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                MainWindow.dump_handler_(JoinChannelAudio_TAG + "LeaveChannel", ret);
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
    }

    // override if need
    internal class JoinChannelAudioEventHandler : IAgoraRtcEngineEventHandler
    {
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
            Console.WriteLine("----->OnUserJoined uid={0} elapsed={1}", uid, elapsed);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }
    }
}
