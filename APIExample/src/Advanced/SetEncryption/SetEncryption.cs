/*
 * 【加密】关键步骤：
 * 1. 创建Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 * 
 * 2. 加入频道：（[EnableAudio], EnableVideo, EnableEncryptionMode, JoinChannel）
 * 
 * 3. 离开频道：（LeaveChannel）
 * 
 * 4. 退出：（Dispose）
 */

using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class SetEncryption : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string SetEncryption_TAG = "[SetEncryption] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;
        ENCRYPTION_MODE encrypt_mode_ = ENCRYPTION_MODE.AES_128_ECB;
         public SetEncryption(IntPtr localWindowId, IntPtr remoteWindowId)
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
            CSharpForm.dump_handler_(SetEncryption_TAG + "Initialize", ret);
            // second way to set logfile
            //ret = rtc_engine_.SetLogFile(log_file_path);
            //CSharpForm.dump_handler_(SetEncryption_TAG + "SetLogFile", ret);

            event_handler_ = new SetEncryptionEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(SetEncryption_TAG + "LeaveChannel", ret);

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
                CSharpForm.dump_handler_(SetEncryption_TAG + "EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(SetEncryption_TAG + "EnableVideo", ret);

                string encryptionKey = "01234567890123456789012345678912";
                byte[] salt = { 0,1,2,3, 4,5,6,7,8,9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2 };
                ret = rtc_engine_.EnableEncryption(true, new EncryptionConfig(encrypt_mode_, encryptionKey, salt));
                CSharpForm.dump_handler_(SetEncryption_TAG + "EnableEncryption", ret);
                CSharpForm.dump_handler_(SetEncryption_TAG + "key:" + encryptionKey, ret);
                CSharpForm.dump_handler_(SetEncryption_TAG + "salt:" + encryptionKey, ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_(SetEncryption_TAG + "JoinChannel", ret);     
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(SetEncryption_TAG + "LeaveChannel", ret);
            }
            return ret;
        }
        public override int EnableEncryption(ENCRYPTION_MODE mode)
        {
            if(rtc_engine_ == null)
            {
                encrypt_mode_ = mode;
            }
            else
            {
                CSharpForm.dump_handler_(SetEncryption_TAG + "EnableEncryption before joinChannel", 0);
            }
            return 0;
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
    internal class SetEncryptionEventHandler : IAgoraRtcEngineEventHandler
    {
        private SetEncryption SetEncryption_inst_ = null;
        public SetEncryptionEventHandler(SetEncryption _SetEncryption) {
            SetEncryption_inst_ = _SetEncryption;
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
            VideoCanvas vs = new VideoCanvas((ulong)SetEncryption_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = SetEncryption_inst_.GetEngine().SetupLocalVideo(vs);
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
            if (SetEncryption_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)SetEncryption_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, SetEncryption_inst_.GetChannelId(), uid);
            int ret = SetEncryption_inst_.GetEngine().SetupRemoteVideo(vc);
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
