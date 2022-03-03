/*
 *  RrmpStreaming：
 * 1. 创建Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 * 
 * 2. 加入频道：（[EnableAudio]、EnableVideo、JoinChannel）
 * 
 * 3. 离开频道：（LeaveChannel）
 * 
 * 4. 退出：（Dispose）
 */

using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class RtmpStreaming : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string RtmpStreaming_TAG = "[RtmpStreaming] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private int data_stream_id_ = -1;
        public RtmpStreaming(IntPtr localWindowId)
        {
            local_win_id_ = localWindowId;
            data_stream_id_ = -1;
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
            CSharpForm.dump_handler_(RtmpStreaming_TAG + "Initialize", ret);
            // second way to set logfile
            //ret = rtc_engine_.SetLogFile(log_file_path);
            //CSharpForm.dump_handler_(RtmpStreaming_TAG + "SetLogFile", ret);

            event_handler_ = new RtmpStreamingEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            data_stream_id_ = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "LeaveChannel", ret);

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
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "EnableVideo", ret);

                VideoEncoderConfiguration config = new VideoEncoderConfiguration(960, 540, FRAME_RATE.FRAME_RATE_FPS_30, 5, BITRATE.STANDARD_BITRATE, BITRATE.COMPATIBLE_BITRATE);
                ret = rtc_engine_.SetVideoEncoderConfiguration(config);
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "SetVideoEncoderConfiguration", ret);
                ret = rtc_engine_.JoinChannel("", channel_id_, "info", 0, new ChannelMediaOptions(false, false, true, true));
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "LeaveChannel", ret);
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

        public override int AddPublishStreamUrl(string url) 
        {
            if (null != rtc_engine_)
            {
                int ret = rtc_engine_.AddPublishStreamUrl(url, false);
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "AddPublishStreamUrl", ret);
                return ret;
            }
            else
            {
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "rtc engine is null", -1);
                return -1;
            }
        }

        public override int RemovePublishStreamUrl(string url)
        {
            if (null != rtc_engine_)
            {
                int ret = rtc_engine_.RemovePublishStreamUrl(url);
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "RemovePublishStreamUrl", ret);
                return ret;
            }
            else
            {
                CSharpForm.dump_handler_(RtmpStreaming_TAG + "rtc engine is null", -1);
                return -1;
            }
        }
    }

    // override if need
    internal class RtmpStreamingEventHandler : IAgoraRtcEngineEventHandler
    {
        private RtmpStreaming RtmpStreaming_inst_ = null;
        public RtmpStreamingEventHandler(RtmpStreaming _RtmpStreaming) {
            RtmpStreaming_inst_ = _RtmpStreaming;
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
            VideoCanvas vs = new VideoCanvas((ulong)RtmpStreaming_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = RtmpStreaming_inst_.GetEngine().SetupLocalVideo(vs);
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
           
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }

        public override void OnStreamMessage(uint uid, int streamId, byte[] data, uint length)
        {
          
        }

        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state,
            RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
            Console.WriteLine("----->OnRtmpStreamingStateChanged ret={0} {1}", url, state);
        }
    }
}
