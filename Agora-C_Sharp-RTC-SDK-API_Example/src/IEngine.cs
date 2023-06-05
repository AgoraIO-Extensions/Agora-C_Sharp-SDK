using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public abstract class IEngine : IRtcEngineEventHandler
    {
        protected IRtcEngine rtc_engine_ = null;

        internal IRtcEngine GetEngine()
        {
            return rtc_engine_;
        }

        internal abstract int Init(string appId);
        internal abstract int UnInit();
        internal abstract int JoinChannel(string channelId);
        internal abstract int LeaveChannel();

        // override common events
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
            Console.WriteLine("----->OnLeaveChannel channel={0} duration={1}", connection.channelId, stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined channel={0} uid={1}", connection.channelId, remoteUid);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline channel={0} remoteUid={1} reason={2}", connection.channelId, remoteUid, reason);
        }

        public override void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
            Console.WriteLine("----->OnRemoteVideoStats channel={0} stats={1}", connection.channelId, stats);
        }

        public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            Console.WriteLine("----->OnRemoteVideoStateChanged channel={0} remoteUid={1} state={2} reason={3}", connection.channelId, remoteUid, state, reason);
        }

        public override void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
            Console.WriteLine("----->OnRemoteAudioStats channel={0} remoteUid={1} stats={2}", connection.channelId, connection.localUid, stats);
        }

        public override void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            Console.WriteLine("----->OnRemoteAudioStateChanged channel={0} remoteUid={0} state={1} reason={2}", connection.channelId, remoteUid, state, reason);
        }
    }
}
