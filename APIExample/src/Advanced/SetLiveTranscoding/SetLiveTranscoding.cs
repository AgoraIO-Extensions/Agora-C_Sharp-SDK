/// <summary>
///  SetLiveTranscoding：
/// 1. Create Engine and Initialize ：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
/// 
/// 2. AddPublishStreamUrl with transcoding, SetLiveTranscoding
/// 
/// 3. Join Channel：（[EnableAudio]、EnableVideo、JoinChannel）
/// 
/// 4. SetLiveTranscoding(when user joined or offline)
/// 
/// 5. RemovePublishStreamUrl
/// 
/// 6. Leave Channel：（LeaveChannel）
/// 
/// 7. Exit：（Dispose）
/// <summary>

using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class SetLiveTranscoding : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string SetLiveTranscoding_TAG = "[SetLiveTranscoding] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;

        private uint local_uid_ = 123;
        public uint remote_uid_ = 0;
        public SetLiveTranscoding(IntPtr localWindowId, IntPtr remoteWindowId)
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
            event_handler_ = new SetLiveTranscodingEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "Initialize", ret);
            // second way to set logfile
            //ret = rtc_engine_.SetLogFile(log_file_path);
            //CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "SetLogFile", ret);
            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "LeaveChannel", ret);

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
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "EnableVideo", ret);

                VideoEncoderConfiguration config = new VideoEncoderConfiguration(960, 540, FRAME_RATE.FRAME_RATE_FPS_30, 5, BITRATE.STANDARD_BITRATE, BITRATE.COMPATIBLE_BITRATE);
                ret = rtc_engine_.SetVideoEncoderConfiguration(config);
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "SetVideoEncoderConfiguration", ret);
                ret = rtc_engine_.JoinChannel("", channel_id_, "info", local_uid_, new ChannelMediaOptions(true, true, true, true));
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "LeaveChannel", ret);
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
        public override int AddPublishStreamUrl(string url) 
        {
            if (null != rtc_engine_)
            {
                setLiveTranscoding();
                int ret = rtc_engine_.AddPublishStreamUrl(url, true);
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "AddPublishStreamUrl", ret);
                return ret;
            }
            else
            {
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "rtc engine is null", -1);
                return -1;
            }
        }

        public override int RemovePublishStreamUrl(string url)
        {
            if (null != rtc_engine_)
            {
                int ret = rtc_engine_.RemovePublishStreamUrl(url);
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "RemovePublishStreamUrl", ret);
                return ret;
            }
            else
            {
                CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "rtc engine is null", -1);
                return -1;
            }
        }

        public int setLiveTranscoding() 
        {
            if (null != rtc_engine_)
            {
                LiveTranscoding transcoding = new LiveTranscoding();
                transcoding.width = 1280;
                transcoding.height = 720;
                if (remote_uid_ > 0)
                {
                    transcoding.userCount = 2;
                    transcoding.transcodingUsers = new TranscodingUser[2];
                    transcoding.transcodingUsers[0] = new TranscodingUser();
                    transcoding.transcodingUsers[1] = new TranscodingUser();
                    transcoding.transcodingUsers[1].uid = remote_uid_;
                    transcoding.transcodingUsers[1].x = 0;
                    transcoding.transcodingUsers[1].y = 0;
                    transcoding.transcodingUsers[1].width = transcoding.width;
                    transcoding.transcodingUsers[1].height = transcoding.height;
                    transcoding.transcodingUsers[1].zOrder = 1;

                    transcoding.transcodingUsers[0].uid = local_uid_;
                    transcoding.transcodingUsers[0].x = 0;
                    transcoding.transcodingUsers[0].y = 0;
                    transcoding.transcodingUsers[0].width = 320;
                    transcoding.transcodingUsers[0].height = 180;
                    transcoding.transcodingUsers[0].zOrder = 2;
                }
                else
                {
                    transcoding.userCount = 1;
                    transcoding.transcodingUsers = new TranscodingUser[1];
                    transcoding.transcodingUsers[0] = new TranscodingUser();
                    transcoding.transcodingUsers[0].uid = local_uid_;
                    transcoding.transcodingUsers[0].x = 0;
                    transcoding.transcodingUsers[0].y = 0;
                    transcoding.transcodingUsers[0].width = transcoding.width;
                    transcoding.transcodingUsers[0].height = transcoding.height;
                    transcoding.transcodingUsers[0].zOrder = 1;
                }
                int ret = rtc_engine_.SetLiveTranscoding(transcoding);
               // CSharpForm.dump_handler_(SetLiveTranscoding_TAG + "SetLiveTranscoding", ret);
            }
            return -1; 
        }
    }

    // override if need
    internal class SetLiveTranscodingEventHandler : IAgoraRtcEngineEventHandler
    {
        private SetLiveTranscoding SetLiveTranscoding_inst_ = null;
        public SetLiveTranscodingEventHandler(SetLiveTranscoding _SetLiveTranscoding) {
            SetLiveTranscoding_inst_ = _SetLiveTranscoding;
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
            VideoCanvas vs = new VideoCanvas((ulong)SetLiveTranscoding_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = SetLiveTranscoding_inst_.GetEngine().SetupLocalVideo(vs);
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
            if (SetLiveTranscoding_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)SetLiveTranscoding_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, SetLiveTranscoding_inst_.GetChannelId(), uid);
            int ret = SetLiveTranscoding_inst_.GetEngine().SetupRemoteVideo(vc);
            SetLiveTranscoding_inst_.remote_uid_ = uid;
            SetLiveTranscoding_inst_.setLiveTranscoding();
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
            SetLiveTranscoding_inst_.setLiveTranscoding();
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            SetLiveTranscoding_inst_.remote_uid_ = 0;
            SetLiveTranscoding_inst_.setLiveTranscoding();
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
