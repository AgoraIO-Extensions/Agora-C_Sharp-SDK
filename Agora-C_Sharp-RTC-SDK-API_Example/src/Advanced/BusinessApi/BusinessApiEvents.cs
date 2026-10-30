using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    // Drives only the small demo sequence: source-ready -> correct connection joined -> play once.
    internal sealed class BusinessLeadStart
    {
        private readonly int epoch;
        private readonly string channel;
        private readonly uint uid;
        private int stage = 1;
        internal int PlayerId { get; }
        internal RtcConnection Connection => new RtcConnection(channel, uid);
        internal BusinessLeadStart(int epoch, int playerId, RtcConnection connection)
        { this.epoch = epoch; PlayerId = playerId; channel = connection.channelId; uid = connection.localUid; }
        internal bool Opened(int currentEpoch, int playerId, bool ready, bool failed)
        {
            if (currentEpoch != epoch) { Cancel(); return false; }
            if (playerId != PlayerId || stage != 1) return false;
            if (failed) { Cancel(); return false; }
            if (!ready) return false;
            stage = 2; return true;
        }
        internal bool Joined(int currentEpoch, RtcConnection connection)
        {
            if (currentEpoch != epoch) { Cancel(); return false; }
            if (stage != 2 || connection.channelId != channel || connection.localUid != uid) return false;
            stage = 3; return true;
        }
        internal void Cancel() { stage = 0; }
    }

    internal sealed class BusinessRtcEvents : IRtcEngineEventHandler
    {
        private readonly Action<string, object> log;
        internal BusinessRtcEvents(Action<string, object> log) { this.log = log; }
        public override void OnError(int err, string msg) => log(nameof(OnError), new { err, msg });
        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed) => log(nameof(OnJoinChannelSuccess), new { connection, elapsed, joined = true });
        public override void OnRejoinChannelSuccess(RtcConnection connection, int elapsed) => log(nameof(OnRejoinChannelSuccess), new { connection, elapsed });
        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats) => log(nameof(OnLeaveChannel), new { connection, stats, joined = false });
        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed) => log(nameof(OnUserJoined), new { connection, remoteUid, elapsed });
        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason) => log(nameof(OnUserOffline), new { connection, remoteUid, reason });
        public override void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason) => log(nameof(OnConnectionStateChanged), new { connection, state, reason });
        public override void OnRequestToken(RtcConnection connection) => log(nameof(OnRequestToken), new { connection, message = "请向业务服务获取有效Token并续期" });
        public override void OnTokenPrivilegeWillExpire(RtcConnection connection, string token) => log(nameof(OnTokenPrivilegeWillExpire), new { connection, message = "Token即将过期；请续期（不输出Token）" });
        public override void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume) => log(nameof(OnAudioVolumeIndication), new { connection, speakers, speakerNumber, totalVolume });
        public override void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats) => log(nameof(OnLocalAudioStats), new { connection, stats });
        public override void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats) => log(nameof(OnRemoteAudioStats), new { connection, stats });
        public override void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_REASON reason) => log(nameof(OnLocalAudioStateChanged), new { connection, state, reason });
        public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason) => log(nameof(OnAudioMixingStateChanged), new { state, reason });
        public override void OnChannelMediaRelayStateChanged(int state, int code) => log(nameof(OnChannelMediaRelayStateChanged), new { state, code });
        public override void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState) => log(nameof(OnAudioPublishStateChanged), new { channel, oldState, newState, elapseSinceLastState });
        public override void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs) => log(nameof(OnStreamMessage), new { connection, remoteUid, streamId, payload = Payload(data, length), sentTs });
        public override void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached) => log(nameof(OnStreamMessageError), new { connection, remoteUid, streamId, code, missed, cached });
        public override void OnAudioMetadataReceived(RtcConnection connection, uint uid, byte[] metadata, ulong length) => log(nameof(OnAudioMetadataReceived), new { connection, uid, payload = Payload(metadata, length) });
        private static object Payload(byte[] bytes, ulong length)
        {
            bytes ??= Array.Empty<byte>();
            int displayed = (int)Math.Min(Math.Min((ulong)bytes.Length, length), 1024UL);
            return new { reportedLength = length, arrayLength = bytes.Length, truncated = length > (ulong)displayed,
                hex = Convert.ToHexString(bytes, 0, displayed), utf8 = Encoding.UTF8.GetString(bytes, 0, displayed) };
        }
    }

    internal sealed class BusinessPlayerEvents : IMediaPlayerSourceObserver
    {
        private readonly Action<string, object> log;
        private readonly int playerId;
        internal BusinessPlayerEvents(Action<string, object> log, int playerId) { this.log = log; this.playerId = playerId; }
        public override void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_REASON reason) => log(nameof(OnPlayerSourceStateChanged), new { playerId, state, reason });
        public override void OnPositionChanged(long positionMs, long timestampMs) => log(nameof(OnPositionChanged), new { playerId, positionMs, timestampMs });
        public override void OnPlayerEvent(MEDIA_PLAYER_EVENT eventCode, long elapsedTime, string message) => log(nameof(OnPlayerEvent), new { playerId, eventCode, elapsedTime, message });
        public override void OnCompleted() => log(nameof(OnCompleted), new { playerId });
    }

    internal sealed class BusinessMusicEvents : IMusicContentCenterEventHandler
    {
        private readonly Action<string, object> log;
        internal BusinessMusicEvents(Action<string, object> log) { this.log = log; }
        public override void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStateReason reason) => log(nameof(OnMusicChartsResult), new { requestId, result, reason });
        public override void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStateReason reason) => log(nameof(OnMusicCollectionResult), new { requestId, result, reason });
        public override void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStateReason reason) => log(nameof(OnLyricResult), new { requestId, songCode, lyricUrl, reason });
        public override void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStateReason reason) => log(nameof(OnSongSimpleInfoResult), new { requestId, songCode, info = BusinessApiJson.DiagnosticInfo(simpleInfo), reason });
        public override void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadState state, MusicContentCenterStateReason reason) => log(nameof(OnPreLoadEvent), new { requestId, songCode, percent, state, reason });
    }

    internal sealed class BusinessAudioFrames : IAudioFrameObserver
    {
        private readonly Action<string, object> log;
        private readonly ConcurrentDictionary<string, int> counts = new ConcurrentDictionary<string, int>();
        internal BusinessAudioFrames(Action<string, object> log) { this.log = log; }
        private bool Frame(string name, string channelId, uint uid, AudioFrame frame)
        {
            int count = counts.AddOrUpdate(name, 1, (_, n) => n + 1);
            if (count == 1 || count % 100 == 0)
                log(name, new { channelId, uid, count, frame.samplesPerSec, frame.samplesPerChannel, frame.channels, frame.bytesPerSample });
            return true;
        }
        public override bool OnRecordAudioFrame(string channelId, AudioFrame frame) => Frame(nameof(OnRecordAudioFrame), channelId, 0, frame);
        public override bool OnPlaybackAudioFrame(string channelId, AudioFrame frame) => Frame(nameof(OnPlaybackAudioFrame), channelId, 0, frame);
        public override bool OnEarMonitoringAudioFrame(AudioFrame frame) => Frame(nameof(OnEarMonitoringAudioFrame), "", 0, frame);
        public override bool OnMixedAudioFrame(string channelId, AudioFrame frame) => Frame(nameof(OnMixedAudioFrame), channelId, 0, frame);
        public override bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame frame) => Frame(nameof(OnPlaybackAudioFrameBeforeMixing), channelId, uid, frame);
    }
}
