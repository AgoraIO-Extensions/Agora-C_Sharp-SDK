/*
 * [Multiple Channel] Key Step ：
 * 1. Create Engine and Initialize ：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]、SetChannelProfile）
 *    Create Channel1：（CreateChannel、SetClientRole、InitEventHandler）
 *    Create Channel2：（CreateChannel、SetClientRole、InitEventHandler）
 *    
 * 2. Join Channel
 *    Engine：（EnableAudio、EnableVideo、SetupLocalVideo）
 *    Channel1：（JoinChannel、Publish）
 *    Channel2：（JoinChannel）
 *    
 *    Remote user join Channel1
 *    Remote user join Channel2
 *    
 * 3. Leave Channel
 *    Channel1：（LeaveChannel）
 *    Channel2：（LeaveChannel）
 * 4. Exit
 *    Channel1：（LeaveChannel、Dispose）
 *    Chann3l2：（LeaveChannel、Dispose）
 *    Engine：（Dispose）
 *    
 *    Note：This case only show how to join tow channels. If you want to join multiple channels, the flow is similar.
 */

using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class JoinMultipleChannel : IEngine
    {
        private string app_id_ = "";
        private string first_channel_id_ = "";
        private string second_channel_id_ = "";
        private readonly string JoinMultipleChannel_TAG = "[JoinMultipleChannel] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        //private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IAgoraRtcChannel first_channel_ = null;
        private IAgoraRtcChannelEventHandler first_channel_event_handler_ = null;
        private IAgoraRtcChannel second_channel_ = null;
        private IAgoraRtcChannelEventHandler second_channel_event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_first_win_id_ = IntPtr.Zero;
        private IntPtr remote_second_win_id_ = IntPtr.Zero;

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
            var channels = channelId.Split(';');
            if (channels.Length < 2)
                return -1;
            first_channel_id_ = channelId.Split(';').GetValue(0).ToString();
            second_channel_id_ = channelId.Split(';').GetValue(1).ToString();

            if (null == rtc_engine_)
            {
                rtc_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine();
            }
            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "Initialize", ret);
            //event_handler_ = new JoinMultipleChannelEventHandler(this);
            //rtc_engine_.InitEventHandler(event_handler_);
            rtc_engine_.SetChannelProfile(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);

            first_channel_ = rtc_engine_.CreateChannel(first_channel_id_);
            ret = first_channel_.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "SetClientRole(ch1)", ret);
            first_channel_event_handler_ = new JoinMultipleChannelChannelEventHandler(this);
            first_channel_.InitEventHandler(first_channel_event_handler_);

            second_channel_ = rtc_engine_.CreateChannel(second_channel_id_);
            ret = second_channel_.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE);
            CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "SetClientRole(ch2)", ret);
            second_channel_event_handler_ = new JoinMultipleChannelChannelEventHandler(this);
            second_channel_.InitEventHandler(second_channel_event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;

            if (null != first_channel_)
            {
                first_channel_.Unpublish();
                ret = first_channel_.LeaveChannel();
                first_channel_.Dispose();
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannel", ret);
            }

            if (null != second_channel_)
            {
                second_channel_.Unpublish();
                ret = second_channel_.LeaveChannel();
                second_channel_.Dispose();
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannel", ret);
            }

            if (null != rtc_engine_)
            {
                rtc_engine_.Dispose(true);
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
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "EnableAudio", ret);
                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "EnableVideo", ret);

                VideoCanvas vs = new VideoCanvas((ulong)local_win_id_, RENDER_MODE_TYPE.RENDER_MODE_FIT);
                ret = rtc_engine_.SetupLocalVideo(vs);
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "SetupLocalVideo", ret);
            }

            if (null != first_channel_)
            {
                ret = first_channel_.JoinChannel("", "", 0, new ChannelMediaOptions(true, true, true, true));
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "JoinChannel(ch1)", ret);
                ret = first_channel_.Publish();
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "Publish(ch1)", ret);
            }

            if (null != second_channel_)
            {
                ret = second_channel_.JoinChannel("", "", 0, new ChannelMediaOptions(true, true, false, false));
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "JoinChannel(ch2)", ret);
                // 同一时刻只能发布一路流
                //ret = second_channel_.Publish();
                //CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "Publish(ch2)", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;

            if (null != first_channel_)
            {
                ret = first_channel_.LeaveChannel();
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannel(ch1)", ret);
            }

            if (null != second_channel_)
            {
                ret = second_channel_.LeaveChannel();
                CSharpForm.dump_handler_(JoinMultipleChannel_TAG + "LeaveChannel(ch2)", ret);
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
 
        internal string GetFistChannelId()
        {
            return first_channel_id_;
        }

        internal string GetSecondChannelId()
        {
            return second_channel_id_;
        }

        internal IAgoraRtcChannel GetFirstChannel()
        {
            return first_channel_;
        }

        internal IAgoraRtcChannel GetSecondChannel()
        {
            return second_channel_;
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
    internal class JoinMultipleChannelChannelEventHandler : IAgoraRtcChannelEventHandler
    {
        private JoinMultipleChannel joinMultipleChannelChannel_inst_ = null;
        public JoinMultipleChannelChannelEventHandler(JoinMultipleChannel _joinMultipleChannelChannel)
        {
            joinMultipleChannelChannel_inst_ = _joinMultipleChannelChannel;
        }

        public override void OnChannelError(string channelId, int err, string msg)
        {
            Console.WriteLine("=====>OnChannelError {0} {1} {2}", channelId, err, msg);
        }

        public override void OnChannelWarning(string channelId, int warn, string msg)
        {
            Console.WriteLine("=====>OnChannelError {0} {1} {2}", channelId, warn, msg);
        }

        public override void OnAudioPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            Console.WriteLine("----->OnAudioPublishStateChanged, channelId={0}", channelId);
        }

        public override void OnAudioSubscribeStateChanged(string channelId, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            Console.WriteLine("----->OnAudioSubscribeStateChanged, channelId={0}", channelId);
        }

        public override void OnClientRoleChanged(string channelId, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
            Console.WriteLine("----->OnClientRoleChanged, channelId={0}", channelId);
        }

        public override void OnJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess, channelId={0} uid={1}", channelId, uid);
        }

        public override void OnLeaveChannel(string channelId, RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel, channelId={0}", channelId);
        }

        public override void OnRejoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnRejoinChannelSuccess, channelId={0}", channelId);
        }

        public override void OnRemoteAudioStateChanged(string channelId, uint uid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            Console.WriteLine("----->OnRemoteAudioStateChanged, channelId={0}", channelId);
        }

        public override void OnRemoteVideoStateChanged(string channelId, uint uid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            Console.WriteLine("----->OnRemoteVideoStateChanged, channelId={0} state={1} reason={2}", channelId, state, reason);
        }

        public override void OnUserJoined(string channelId, uint uid, int elapsed)
        {
            IntPtr win_id = IntPtr.Zero;

            if (channelId == joinMultipleChannelChannel_inst_.GetFistChannelId())
            {
                win_id = joinMultipleChannelChannel_inst_.GetRemoteFirstWinId();
            }
            else if(channelId == joinMultipleChannelChannel_inst_.GetSecondChannelId())
            {
                win_id = joinMultipleChannelChannel_inst_.GetRemoteSecondWinId();
            }
            else
            {
                Console.WriteLine("----->OnUserJoined, invalid channelId{0}  !!!", channelId);
                return;
            }
            var vc = new VideoCanvas((ulong)win_id, RENDER_MODE_TYPE.RENDER_MODE_FIT, channelId, uid);
            int ret = CSharpForm.usr_engine_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->OnUserJoined, channelId={0} uid={1} ret ={2}", channelId, uid, ret);
        }

        public override void OnUserOffline(string channelId, uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, channelId={0}", channelId);
        }

        public override void OnVideoPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            Console.WriteLine("----->OnVideoPublishStateChanged, channelId={0}", channelId);
        }

        public override void OnVideoSubscribeStateChanged(string channelId, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            Console.WriteLine("----->OnVideoSubscribeStateChanged, channelId={0}", channelId);
        }
    }

    // override if need
    internal class JoinMultipleChannelEventHandler : IAgoraRtcEngineEventHandler
    {
        private JoinMultipleChannel joinMultipleChannel_inst = null;
        public JoinMultipleChannelEventHandler(JoinMultipleChannel _joinMultipleChannel)
        {
            joinMultipleChannel_inst = _joinMultipleChannel;
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
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, reason={0}", reason);
        }

        //public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        //{
        //    Console.WriteLine("----->OnAudioMixingStateChanged, state={0} reason={1}", state, reason);
        //}

        public override void OnRemoteVideoStats(RemoteVideoStats stats)
        {
            Console.WriteLine("----->OnRemoteVideoStats, stats={0}", stats);
        }

        public override void OnRemoteAudioStats(RemoteAudioStats stats)
        {
            Console.WriteLine("----->OnRemoteAudioStats, stats={0}", stats);
        }
    }
}
