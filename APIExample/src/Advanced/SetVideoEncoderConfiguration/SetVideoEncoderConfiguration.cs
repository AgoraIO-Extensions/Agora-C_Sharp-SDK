/// <summary>
/// [SetVideoEncoderConfiguration]Key Step：
/// 1. Create Engine and Initialize：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
/// 
/// 2. Join Channel：（[EnableAudio]、EnableVideo、 SetVideoEncoderConfiguration JoinChannel）
/// 
/// 3. Leave Channel：（LeaveChannel）
/// 
/// 4. Exit：（Dispose）
/// <summary>

using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class SetVideoEncoderConfiguration : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string SetVideoEncoderConfiguration_TAG = "[SetVideoEncoderConfiguration] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;
         public SetVideoEncoderConfiguration(IntPtr localWindowId, IntPtr remoteWindowId)
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
                rtc_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine();
            }

            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "Initialize", ret);
            // second way to set logfile
            //ret = rtc_engine_.SetLogFile(log_file_path);
            //CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "SetLogFile", ret);

            event_handler_ = new SetVideoEncoderConfigurationEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "LeaveChannel", ret);

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
                CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "EnableVideo", ret);

                VideoEncoderConfiguration config = new VideoEncoderConfiguration(960, 540, FRAME_RATE.FRAME_RATE_FPS_30, 5, BITRATE.STANDARD_BITRATE, BITRATE.COMPATIBLE_BITRATE);
                ret = rtc_engine_.SetVideoEncoderConfiguration(config);
                CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "SetVideoEncoderConfiguration", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info", 0, new ChannelMediaOptions(true, true, true, true));
                CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "JoinChannel", ret);
                /// <summary>string[] ipList = { "127.0.0.1", "127.0.0.2" };
                ///string[] domainList = { "255.0.0.0", "255.255.0.0" };
                ///LocalAccessPointConfiguration config = new LocalAccessPointConfiguration(ipList, 2, domainList, 2, "dnstest", LOCAL_PROXY_MODE.ConnectivityFirst);
                ///ret = rtc_engine_.SetLocalAccessPoint(config);
                ///CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "SetLocalAccessPoint", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "LeaveChannel", ret);
            }
            return ret;
        }

        public override int setVideoEncoderConfiguration(agora.rtc.VideoDimensions dimension, agora.rtc.FRAME_RATE fps)
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.SetVideoEncoderConfiguration(new VideoEncoderConfiguration(dimension, fps, 5, BITRATE.STANDARD_BITRATE, BITRATE.COMPATIBLE_BITRATE));
                CSharpForm.dump_handler_(SetVideoEncoderConfiguration_TAG + "setVideoEncoderConfiguration", ret);
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
    }

    // override if need
    internal class SetVideoEncoderConfigurationEventHandler : IAgoraRtcEngineEventHandler
    {
        private SetVideoEncoderConfiguration SetVideoEncoderConfiguration_inst_ = null;
        public SetVideoEncoderConfigurationEventHandler(SetVideoEncoderConfiguration _SetVideoEncoderConfiguration) {
            SetVideoEncoderConfiguration_inst_ = _SetVideoEncoderConfiguration;
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
            VideoCanvas vs = new VideoCanvas((ulong)SetVideoEncoderConfiguration_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = SetVideoEncoderConfiguration_inst_.GetEngine().SetupLocalVideo(vs);
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
            if (SetVideoEncoderConfiguration_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)SetVideoEncoderConfiguration_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, SetVideoEncoderConfiguration_inst_.GetChannelId(), uid);
            int ret = SetVideoEncoderConfiguration_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }

        public override void OnStreamMessage(uint uid, int streamId, byte[] data, uint length)
        {
          
        }
    }
}
