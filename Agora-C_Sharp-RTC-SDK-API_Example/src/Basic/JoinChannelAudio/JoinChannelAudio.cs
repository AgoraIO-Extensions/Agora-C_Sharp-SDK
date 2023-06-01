using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class JoinChannelAudio : IEngine
    {
        private readonly string JoinChannelAudio_TAG = "[JoinChannelAudio] ";
        private readonly string log_file_path = ".\\logs\\agora.log";

        private bool joined_ = false;

        internal override int Init(string appId)
        {
            int ret = -1;

            if (null == rtc_engine_)
            {
                rtc_engine_ = RtcEngine.CreateAgoraRtcEngine();
            }

            // Prepare engine context
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext();
            rtc_engine_ctx.appId = appId;
            rtc_engine_ctx.logConfig.filePath = log_file_path;

            // Initialize engine
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            MainForm.dump_handler_(JoinChannelAudio_TAG + "Initialize", ret);

            // Register event handler
            ret = rtc_engine_.InitEventHandler(this);
            MainForm.dump_handler_(JoinChannelAudio_TAG + "InitEventHandler", ret);

            // No need to call EnableAudio, Coz the audio module is enabled by default

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                // Dispose engine
                rtc_engine_.Dispose();
                rtc_engine_ = null;
            }
            return ret;
        }

        internal override int JoinChannel(string channelId)
        {
            int ret = -1;
            if (null != rtc_engine_ && joined_ != true)
            {
                // Join channel
                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

                ret = rtc_engine_.JoinChannel("", channelId.Split(';').GetValue(0).ToString(), 0, options);
                MainForm.dump_handler_(JoinChannelAudio_TAG + "JoinChannel", ret);

                // Enable audio volume indication
                ret = rtc_engine_.EnableAudioVolumeIndication(300, 3, false);

                joined_ = true;
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            
            if (null != rtc_engine_ && joined_ == true)
            {
                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(JoinChannelAudio_TAG + "LeaveChannel", ret);

                joined_ = false;
            }

            return ret;
        }

        // override IRtcEngineEventHandler
        public override void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            if (0 == speakerNumber) return;

            foreach (var speaker in speakers)
            {
                Console.WriteLine("----->OnAudioVolumeIndication uid={0} volume={1}", speaker.uid, speaker.volume);
            }

        }
    }
}
