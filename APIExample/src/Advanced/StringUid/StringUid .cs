/// <summary>
/// [String uid]Key Step：
/// 1. Create Engine and Initialize：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
/// 
/// 2. Join Channel：（[EnableAudio]、EnableVideo、JoinChannelWithUserAccount）
/// 
/// 3. Leave Channel：（LeaveChannel）
/// 
/// 4. Exit：（Dispose）
/// <summary>

using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class StringUid : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string StringUid_TAG = "[StringUid] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;
        private string str_uid_ = "123agora";
        public StringUid(IntPtr localWindowId, IntPtr remoteWindowId)
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
            uint uid = (uint)rd.Next(1, 999999);
            str_uid_ = uid.ToString() + "agora";

            if (null == rtc_engine_)
            {
                rtc_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine();
            }
            event_handler_ = new StringUidEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(StringUid_TAG + "Initialize", ret);
            // second way to set logfile
            //ret = rtc_engine_.SetLogFile(log_file_path);
            //CSharpForm.dump_handler_(StringUid_TAG + "SetLogFile", ret);

      
            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(StringUid_TAG + "LeaveChannel", ret);

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
                CSharpForm.dump_handler_(StringUid_TAG + "EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(StringUid_TAG + "EnableVideo", ret);
                ChannelMediaOptions option = new ChannelMediaOptions();
                ret = rtc_engine_.JoinChannelWithUserAccount("", channel_id_, str_uid_, option);
                CSharpForm.dump_handler_(StringUid_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(StringUid_TAG + "LeaveChannel", ret);
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
    internal class StringUidEventHandler : IAgoraRtcEngineEventHandler
    {
        private StringUid StringUid_inst_ = null;

        public StringUidEventHandler(StringUid _StringUid) {
            StringUid_inst_ = _StringUid;
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
            VideoCanvas vs = new VideoCanvas((ulong)StringUid_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = StringUid_inst_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo ret={0}", ret);

            UserInfo userInfo = new UserInfo();
            StringUid_inst_.GetEngine().GetUserInfoByUid(uid, out userInfo);
            Console.WriteLine("----->joinchannelSuccess GetUserInfoByUid, uid={0}, userAccount={1}", uid, userInfo.userAccount);
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
            UserInfo userInfo = new UserInfo();
            StringUid_inst_.GetEngine().GetUserInfoByUid(uid, out userInfo);
            Console.WriteLine("----->userjoined GetUserInfoByUid, uid={0}, userAccount={1}", uid, userInfo.userAccount);

            if (StringUid_inst_.GetLocalWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)StringUid_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, StringUid_inst_.GetChannelId(), uid);
            int ret = StringUid_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", 0);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }

        public override void OnLocalUserRegistered(uint uid, string userAccount)
        {
            Console.WriteLine("----->OnLocalUserRegistered uid={0}, userAccount={1}", uid, userAccount);
        }

        public override void OnUserInfoUpdated(uint uid, UserInfo info)
        {
            Console.WriteLine("----->OnUserInfoUpdated uid={0}, userAccount={1}", uid, info.userAccount);
        }

        public override void OnRemoteVideoStateChanged(uint uid, REMOTE_VIDEO_STATE state,
           REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            Console.WriteLine("----->OnRemoteVideoStateChanged reason={0}, state = {1}", reason, state);
         
            UserInfo userInfo = new UserInfo();
            StringUid_inst_.GetEngine().GetUserInfoByUid(uid, out userInfo);
            Console.WriteLine("----->userjoined GetUserInfoByUid, uid={0}, userAccount={1}", uid, userInfo.userAccount);
        }
    }
}
