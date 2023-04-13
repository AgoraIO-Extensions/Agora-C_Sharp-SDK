using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class JoinChannelAudio : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string JoinChannelAudio_TAG = "[JoinChannelAudio] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private IRtcEngine rtc_engine_ = null;
        private IRtcEngineEventHandler event_handler_ = null;

        internal override int Init(string appId, string channelId)
        {
            int ret = -1;

            app_id_ = appId;
            channel_id_ = channelId.Split(';').GetValue(0).ToString();

            if (null == rtc_engine_)
            {
                rtc_engine_ = RtcEngine.CreateAgoraRtcEngine();
            }

            // Prepare engine context
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext();
            rtc_engine_ctx.appId = app_id_;
            rtc_engine_ctx.logConfig.filePath = log_file_path;

            // Initialize engine
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(JoinChannelAudio_TAG + "Initialize", ret);

            // Register event handler
            event_handler_ = new JoinChannelAudioEventHandler();
            ret = rtc_engine_.InitEventHandler(event_handler_);
            CSharpForm.dump_handler_(JoinChannelAudio_TAG + "InitEventHandler", ret);

            // No need to call EnableAudio, Coz the audio module is enabled by default

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                // Leave channel
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(JoinChannelAudio_TAG + "LeaveChannel", ret);

                // Dispose engine
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
                // Join channel
                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

                ret = rtc_engine_.JoinChannel("", channel_id_, 0, options);
                CSharpForm.dump_handler_(JoinChannelAudio_TAG + "JoinChannel", ret);

                // Enable audio volume indication
                ret = rtc_engine_.EnableAudioVolumeIndication(300, 3, false);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(JoinChannelAudio_TAG + "LeaveChannel", ret);
            }
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
    }

    // override if need
    internal class JoinChannelAudioEventHandler : IRtcEngineEventHandler
    {
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
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0} elapsed={1}", remoteUid, elapsed);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, channel={0}, remoteUid={1}, reason={2}", connection.channelId, remoteUid, reason);
        }

        public override void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            if (0 == speakerNumber) return;

            foreach (var speaker in speakers)
            {
                Console.WriteLine("----->OnAudioVolumeIndication uid={0} volume={1}", speaker.uid, speaker.volume);
            }

        }

        public override void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            Console.WriteLine("----->OnRemoteAudioStateChanged remoteUid={0} state={1} reason={2}", remoteUid, state, reason);
        }
    }
}
