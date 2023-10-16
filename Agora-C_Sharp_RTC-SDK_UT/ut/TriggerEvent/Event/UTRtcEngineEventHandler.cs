using System;
using uid_t = System.UInt32;
namespace Agora.Rtc
{
    public class UTRtcEngineEventHandler : IRtcEngineEventHandler
    {

        #region terra IRtcEngineEventHandler

        public bool OnJoinChannelSuccess_be_trigger = false;
        public RtcConnection OnJoinChannelSuccess_connection;
        public int OnJoinChannelSuccess_elapsed;
        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            OnJoinChannelSuccess_be_trigger = true;
            OnJoinChannelSuccess_connection = connection;
            OnJoinChannelSuccess_elapsed = elapsed;
        }

        public bool OnJoinChannelSuccessPassed(RtcConnection connection, int elapsed)
        {
            if (OnJoinChannelSuccess_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnJoinChannelSuccess_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnJoinChannelSuccess_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRejoinChannelSuccess_be_trigger = false;
        public RtcConnection OnRejoinChannelSuccess_connection;
        public int OnRejoinChannelSuccess_elapsed;
        public override void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            OnRejoinChannelSuccess_be_trigger = true;
            OnRejoinChannelSuccess_connection = connection;
            OnRejoinChannelSuccess_elapsed = elapsed;
        }

        public bool OnRejoinChannelSuccessPassed(RtcConnection connection, int elapsed)
        {
            if (OnRejoinChannelSuccess_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnRejoinChannelSuccess_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRejoinChannelSuccess_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnProxyConnected_be_trigger = false;
        public string OnProxyConnected_channel;
        public uint OnProxyConnected_uid;
        public PROXY_TYPE OnProxyConnected_proxyType;
        public string OnProxyConnected_localProxyIp;
        public int OnProxyConnected_elapsed;
        public override void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            OnProxyConnected_be_trigger = true;
            OnProxyConnected_channel = channel;
            OnProxyConnected_uid = uid;
            OnProxyConnected_proxyType = proxyType;
            OnProxyConnected_localProxyIp = localProxyIp;
            OnProxyConnected_elapsed = elapsed;
        }

        public bool OnProxyConnectedPassed(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            if (OnProxyConnected_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<string>(OnProxyConnected_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnProxyConnected_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<PROXY_TYPE>(OnProxyConnected_proxyType, proxyType) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnProxyConnected_localProxyIp, localProxyIp) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnProxyConnected_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnAudioQuality_be_trigger = false;
        public RtcConnection OnAudioQuality_connection;
        public uint OnAudioQuality_remoteUid;
        public int OnAudioQuality_quality;
        public ushort OnAudioQuality_delay;
        public ushort OnAudioQuality_lost;
        public override void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
            OnAudioQuality_be_trigger = true;
            OnAudioQuality_connection = connection;
            OnAudioQuality_remoteUid = remoteUid;
            OnAudioQuality_quality = quality;
            OnAudioQuality_delay = delay;
            OnAudioQuality_lost = lost;
        }

        public bool OnAudioQualityPassed(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
            if (OnAudioQuality_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnAudioQuality_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnAudioQuality_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioQuality_quality, quality) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnAudioQuality_delay, delay) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnAudioQuality_lost, lost) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnAudioVolumeIndication_be_trigger = false;
        public RtcConnection OnAudioVolumeIndication_connection;
        public AudioVolumeInfo[] OnAudioVolumeIndication_speakers;
        public uint OnAudioVolumeIndication_speakerNumber;
        public int OnAudioVolumeIndication_totalVolume;
        public override void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            OnAudioVolumeIndication_be_trigger = true;
            OnAudioVolumeIndication_connection = connection;
            OnAudioVolumeIndication_speakers = speakers;
            OnAudioVolumeIndication_speakerNumber = speakerNumber;
            OnAudioVolumeIndication_totalVolume = totalVolume;
        }

        public bool OnAudioVolumeIndicationPassed(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            if (OnAudioVolumeIndication_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnAudioVolumeIndication_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<AudioVolumeInfo[]>(OnAudioVolumeIndication_speakers, speakers) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnAudioVolumeIndication_speakerNumber, speakerNumber) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioVolumeIndication_totalVolume, totalVolume) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnAudioMixingFinished_be_trigger = false;
        public override void OnAudioMixingFinished()
        {
            OnAudioMixingFinished_be_trigger = true;
        }

        public bool OnAudioMixingFinishedPassed()
        {
            if (OnAudioMixingFinished_be_trigger == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnNetworkQuality_be_trigger = false;
        public RtcConnection OnNetworkQuality_connection;
        public uint OnNetworkQuality_remoteUid;
        public int OnNetworkQuality_txQuality;
        public int OnNetworkQuality_rxQuality;
        public override void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
            OnNetworkQuality_be_trigger = true;
            OnNetworkQuality_connection = connection;
            OnNetworkQuality_remoteUid = remoteUid;
            OnNetworkQuality_txQuality = txQuality;
            OnNetworkQuality_rxQuality = rxQuality;
        }

        public bool OnNetworkQualityPassed(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
            if (OnNetworkQuality_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnNetworkQuality_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnNetworkQuality_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnNetworkQuality_txQuality, txQuality) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnNetworkQuality_rxQuality, rxQuality) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnFirstRemoteVideoDecoded_be_trigger = false;
        public RtcConnection OnFirstRemoteVideoDecoded_connection;
        public uint OnFirstRemoteVideoDecoded_remoteUid;
        public int OnFirstRemoteVideoDecoded_width;
        public int OnFirstRemoteVideoDecoded_height;
        public int OnFirstRemoteVideoDecoded_elapsed;
        public override void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoDecoded_be_trigger = true;
            OnFirstRemoteVideoDecoded_connection = connection;
            OnFirstRemoteVideoDecoded_remoteUid = remoteUid;
            OnFirstRemoteVideoDecoded_width = width;
            OnFirstRemoteVideoDecoded_height = height;
            OnFirstRemoteVideoDecoded_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoDecodedPassed(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoDecoded_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteVideoDecoded_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnFirstRemoteVideoDecoded_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteVideoStateChanged_be_trigger = false;
        public RtcConnection OnRemoteVideoStateChanged_connection;
        public uint OnRemoteVideoStateChanged_remoteUid;
        public REMOTE_VIDEO_STATE OnRemoteVideoStateChanged_state;
        public REMOTE_VIDEO_STATE_REASON OnRemoteVideoStateChanged_reason;
        public int OnRemoteVideoStateChanged_elapsed;
        public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            OnRemoteVideoStateChanged_be_trigger = true;
            OnRemoteVideoStateChanged_connection = connection;
            OnRemoteVideoStateChanged_remoteUid = remoteUid;
            OnRemoteVideoStateChanged_state = state;
            OnRemoteVideoStateChanged_reason = reason;
            OnRemoteVideoStateChanged_elapsed = elapsed;
        }

        public bool OnRemoteVideoStateChangedPassed(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteVideoStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteVideoStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_VIDEO_STATE>(OnRemoteVideoStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_VIDEO_STATE_REASON>(OnRemoteVideoStateChanged_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRemoteVideoStateChanged_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoSizeChanged_be_trigger = false;
        public RtcConnection OnVideoSizeChanged_connection;
        public VIDEO_SOURCE_TYPE OnVideoSizeChanged_sourceType;
        public uint OnVideoSizeChanged_uid;
        public int OnVideoSizeChanged_width;
        public int OnVideoSizeChanged_height;
        public int OnVideoSizeChanged_rotation;
        public override void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
            OnVideoSizeChanged_be_trigger = true;
            OnVideoSizeChanged_connection = connection;
            OnVideoSizeChanged_sourceType = sourceType;
            OnVideoSizeChanged_uid = uid;
            OnVideoSizeChanged_width = width;
            OnVideoSizeChanged_height = height;
            OnVideoSizeChanged_rotation = rotation;
        }

        public bool OnVideoSizeChangedPassed(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
            if (OnVideoSizeChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnVideoSizeChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnVideoSizeChanged_sourceType, sourceType) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnVideoSizeChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged_rotation, rotation) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnFirstRemoteVideoFrame_be_trigger = false;
        public RtcConnection OnFirstRemoteVideoFrame_connection;
        public uint OnFirstRemoteVideoFrame_remoteUid;
        public int OnFirstRemoteVideoFrame_width;
        public int OnFirstRemoteVideoFrame_height;
        public int OnFirstRemoteVideoFrame_elapsed;
        public override void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoFrame_be_trigger = true;
            OnFirstRemoteVideoFrame_connection = connection;
            OnFirstRemoteVideoFrame_remoteUid = remoteUid;
            OnFirstRemoteVideoFrame_width = width;
            OnFirstRemoteVideoFrame_height = height;
            OnFirstRemoteVideoFrame_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoFramePassed(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoFrame_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteVideoFrame_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnFirstRemoteVideoFrame_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserJoined_be_trigger = false;
        public RtcConnection OnUserJoined_connection;
        public uint OnUserJoined_remoteUid;
        public int OnUserJoined_elapsed;
        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            OnUserJoined_be_trigger = true;
            OnUserJoined_connection = connection;
            OnUserJoined_remoteUid = remoteUid;
            OnUserJoined_elapsed = elapsed;
        }

        public bool OnUserJoinedPassed(RtcConnection connection, uint remoteUid, int elapsed)
        {
            if (OnUserJoined_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnUserJoined_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserJoined_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnUserJoined_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserOffline_be_trigger = false;
        public RtcConnection OnUserOffline_connection;
        public uint OnUserOffline_remoteUid;
        public USER_OFFLINE_REASON_TYPE OnUserOffline_reason;
        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            OnUserOffline_be_trigger = true;
            OnUserOffline_connection = connection;
            OnUserOffline_remoteUid = remoteUid;
            OnUserOffline_reason = reason;
        }

        public bool OnUserOfflinePassed(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            if (OnUserOffline_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnUserOffline_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserOffline_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<USER_OFFLINE_REASON_TYPE>(OnUserOffline_reason, reason) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserMuteAudio_be_trigger = false;
        public RtcConnection OnUserMuteAudio_connection;
        public uint OnUserMuteAudio_remoteUid;
        public bool OnUserMuteAudio_muted;
        public override void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)
        {
            OnUserMuteAudio_be_trigger = true;
            OnUserMuteAudio_connection = connection;
            OnUserMuteAudio_remoteUid = remoteUid;
            OnUserMuteAudio_muted = muted;
        }

        public bool OnUserMuteAudioPassed(RtcConnection connection, uint remoteUid, bool muted)
        {
            if (OnUserMuteAudio_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnUserMuteAudio_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserMuteAudio_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserMuteAudio_muted, muted) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserMuteVideo_be_trigger = false;
        public RtcConnection OnUserMuteVideo_connection;
        public uint OnUserMuteVideo_remoteUid;
        public bool OnUserMuteVideo_muted;
        public override void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
            OnUserMuteVideo_be_trigger = true;
            OnUserMuteVideo_connection = connection;
            OnUserMuteVideo_remoteUid = remoteUid;
            OnUserMuteVideo_muted = muted;
        }

        public bool OnUserMuteVideoPassed(RtcConnection connection, uint remoteUid, bool muted)
        {
            if (OnUserMuteVideo_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnUserMuteVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserMuteVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserMuteVideo_muted, muted) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserEnableVideo_be_trigger = false;
        public RtcConnection OnUserEnableVideo_connection;
        public uint OnUserEnableVideo_remoteUid;
        public bool OnUserEnableVideo_enabled;
        public override void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            OnUserEnableVideo_be_trigger = true;
            OnUserEnableVideo_connection = connection;
            OnUserEnableVideo_remoteUid = remoteUid;
            OnUserEnableVideo_enabled = enabled;
        }

        public bool OnUserEnableVideoPassed(RtcConnection connection, uint remoteUid, bool enabled)
        {
            if (OnUserEnableVideo_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnUserEnableVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserEnableVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserEnableVideo_enabled, enabled) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserStateChanged_be_trigger = false;
        public RtcConnection OnUserStateChanged_connection;
        public uint OnUserStateChanged_remoteUid;
        public uint OnUserStateChanged_state;
        public override void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
            OnUserStateChanged_be_trigger = true;
            OnUserStateChanged_connection = connection;
            OnUserStateChanged_remoteUid = remoteUid;
            OnUserStateChanged_state = state;
        }

        public bool OnUserStateChangedPassed(RtcConnection connection, uint remoteUid, uint state)
        {
            if (OnUserStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnUserStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserStateChanged_state, state) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserEnableLocalVideo_be_trigger = false;
        public RtcConnection OnUserEnableLocalVideo_connection;
        public uint OnUserEnableLocalVideo_remoteUid;
        public bool OnUserEnableLocalVideo_enabled;
        public override void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            OnUserEnableLocalVideo_be_trigger = true;
            OnUserEnableLocalVideo_connection = connection;
            OnUserEnableLocalVideo_remoteUid = remoteUid;
            OnUserEnableLocalVideo_enabled = enabled;
        }

        public bool OnUserEnableLocalVideoPassed(RtcConnection connection, uint remoteUid, bool enabled)
        {
            if (OnUserEnableLocalVideo_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnUserEnableLocalVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserEnableLocalVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserEnableLocalVideo_enabled, enabled) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteAudioStats_be_trigger = false;
        public RtcConnection OnRemoteAudioStats_connection;
        public RemoteAudioStats OnRemoteAudioStats_stats;
        public override void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
            OnRemoteAudioStats_be_trigger = true;
            OnRemoteAudioStats_connection = connection;
            OnRemoteAudioStats_stats = stats;
        }

        public bool OnRemoteAudioStatsPassed(RtcConnection connection, RemoteAudioStats stats)
        {
            if (OnRemoteAudioStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<RemoteAudioStats>(OnRemoteAudioStats_stats, stats) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalVideoStats_be_trigger = false;
        public RtcConnection OnLocalVideoStats_connection;
        public LocalVideoStats OnLocalVideoStats_stats;
        public override void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
            OnLocalVideoStats_be_trigger = true;
            OnLocalVideoStats_connection = connection;
            OnLocalVideoStats_stats = stats;
        }

        public bool OnLocalVideoStatsPassed(RtcConnection connection, LocalVideoStats stats)
        {
            if (OnLocalVideoStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnLocalVideoStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<LocalVideoStats>(OnLocalVideoStats_stats, stats) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteVideoStats_be_trigger = false;
        public RtcConnection OnRemoteVideoStats_connection;
        public RemoteVideoStats OnRemoteVideoStats_stats;
        public override void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
            OnRemoteVideoStats_be_trigger = true;
            OnRemoteVideoStats_connection = connection;
            OnRemoteVideoStats_stats = stats;
        }

        public bool OnRemoteVideoStatsPassed(RtcConnection connection, RemoteVideoStats stats)
        {
            if (OnRemoteVideoStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<RemoteVideoStats>(OnRemoteVideoStats_stats, stats) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnCameraReady_be_trigger = false;
        public override void OnCameraReady()
        {
            OnCameraReady_be_trigger = true;
        }

        public bool OnCameraReadyPassed()
        {
            if (OnCameraReady_be_trigger == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoStopped_be_trigger = false;
        public override void OnVideoStopped()
        {
            OnVideoStopped_be_trigger = true;
        }

        public bool OnVideoStoppedPassed()
        {
            if (OnVideoStopped_be_trigger == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnConnectionInterrupted_be_trigger = false;
        public RtcConnection OnConnectionInterrupted_connection;
        public override void OnConnectionInterrupted(RtcConnection connection)
        {
            OnConnectionInterrupted_be_trigger = true;
            OnConnectionInterrupted_connection = connection;
        }

        public bool OnConnectionInterruptedPassed(RtcConnection connection)
        {
            if (OnConnectionInterrupted_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnConnectionInterrupted_connection, connection) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnConnectionBanned_be_trigger = false;
        public RtcConnection OnConnectionBanned_connection;
        public override void OnConnectionBanned(RtcConnection connection)
        {
            OnConnectionBanned_be_trigger = true;
            OnConnectionBanned_connection = connection;
        }

        public bool OnConnectionBannedPassed(RtcConnection connection)
        {
            if (OnConnectionBanned_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnConnectionBanned_connection, connection) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnStreamMessage_be_trigger = false;
        public RtcConnection OnStreamMessage_connection;
        public uint OnStreamMessage_remoteUid;
        public int OnStreamMessage_streamId;
        public byte[] OnStreamMessage_data;
        public ulong OnStreamMessage_length;
        public ulong OnStreamMessage_sentTs;
        public override void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            OnStreamMessage_be_trigger = true;
            OnStreamMessage_connection = connection;
            OnStreamMessage_remoteUid = remoteUid;
            OnStreamMessage_streamId = streamId;
            OnStreamMessage_data = data;
            OnStreamMessage_length = length;
            OnStreamMessage_sentTs = sentTs;
        }

        public bool OnStreamMessagePassed(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            if (OnStreamMessage_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnStreamMessage_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnStreamMessage_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessage_streamId, streamId) == false)
                return false;
            if (ParamsHelper.Compare<byte[]>(OnStreamMessage_data, data) == false)
                return false;
            if (ParamsHelper.Compare<ulong>(OnStreamMessage_length, length) == false)
                return false;
            if (ParamsHelper.Compare<ulong>(OnStreamMessage_sentTs, sentTs) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnStreamMessageError_be_trigger = false;
        public RtcConnection OnStreamMessageError_connection;
        public uint OnStreamMessageError_remoteUid;
        public int OnStreamMessageError_streamId;
        public int OnStreamMessageError_code;
        public int OnStreamMessageError_missed;
        public int OnStreamMessageError_cached;
        public override void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
            OnStreamMessageError_be_trigger = true;
            OnStreamMessageError_connection = connection;
            OnStreamMessageError_remoteUid = remoteUid;
            OnStreamMessageError_streamId = streamId;
            OnStreamMessageError_code = code;
            OnStreamMessageError_missed = missed;
            OnStreamMessageError_cached = cached;
        }

        public bool OnStreamMessageErrorPassed(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
            if (OnStreamMessageError_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnStreamMessageError_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnStreamMessageError_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError_streamId, streamId) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError_code, code) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError_missed, missed) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError_cached, cached) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnFirstRemoteAudioFrame_be_trigger = false;
        public RtcConnection OnFirstRemoteAudioFrame_connection;
        public uint OnFirstRemoteAudioFrame_userId;
        public int OnFirstRemoteAudioFrame_elapsed;
        public override void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)
        {
            OnFirstRemoteAudioFrame_be_trigger = true;
            OnFirstRemoteAudioFrame_connection = connection;
            OnFirstRemoteAudioFrame_userId = userId;
            OnFirstRemoteAudioFrame_elapsed = elapsed;
        }

        public bool OnFirstRemoteAudioFramePassed(RtcConnection connection, uint userId, int elapsed)
        {
            if (OnFirstRemoteAudioFrame_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteAudioFrame_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnFirstRemoteAudioFrame_userId, userId) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteAudioFrame_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnFirstRemoteAudioDecoded_be_trigger = false;
        public RtcConnection OnFirstRemoteAudioDecoded_connection;
        public uint OnFirstRemoteAudioDecoded_uid;
        public int OnFirstRemoteAudioDecoded_elapsed;
        public override void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)
        {
            OnFirstRemoteAudioDecoded_be_trigger = true;
            OnFirstRemoteAudioDecoded_connection = connection;
            OnFirstRemoteAudioDecoded_uid = uid;
            OnFirstRemoteAudioDecoded_elapsed = elapsed;
        }

        public bool OnFirstRemoteAudioDecodedPassed(RtcConnection connection, uint uid, int elapsed)
        {
            if (OnFirstRemoteAudioDecoded_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteAudioDecoded_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnFirstRemoteAudioDecoded_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteAudioDecoded_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteAudioStateChanged_be_trigger = false;
        public RtcConnection OnRemoteAudioStateChanged_connection;
        public uint OnRemoteAudioStateChanged_remoteUid;
        public REMOTE_AUDIO_STATE OnRemoteAudioStateChanged_state;
        public REMOTE_AUDIO_STATE_REASON OnRemoteAudioStateChanged_reason;
        public int OnRemoteAudioStateChanged_elapsed;
        public override void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            OnRemoteAudioStateChanged_be_trigger = true;
            OnRemoteAudioStateChanged_connection = connection;
            OnRemoteAudioStateChanged_remoteUid = remoteUid;
            OnRemoteAudioStateChanged_state = state;
            OnRemoteAudioStateChanged_reason = reason;
            OnRemoteAudioStateChanged_elapsed = elapsed;
        }

        public bool OnRemoteAudioStateChangedPassed(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteAudioStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteAudioStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_AUDIO_STATE>(OnRemoteAudioStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_AUDIO_STATE_REASON>(OnRemoteAudioStateChanged_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRemoteAudioStateChanged_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnActiveSpeaker_be_trigger = false;
        public RtcConnection OnActiveSpeaker_connection;
        public uint OnActiveSpeaker_uid;
        public override void OnActiveSpeaker(RtcConnection connection, uint uid)
        {
            OnActiveSpeaker_be_trigger = true;
            OnActiveSpeaker_connection = connection;
            OnActiveSpeaker_uid = uid;
        }

        public bool OnActiveSpeakerPassed(RtcConnection connection, uint uid)
        {
            if (OnActiveSpeaker_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnActiveSpeaker_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnActiveSpeaker_uid, uid) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnSnapshotTaken_be_trigger = false;
        public RtcConnection OnSnapshotTaken_connection;
        public uint OnSnapshotTaken_uid;
        public string OnSnapshotTaken_filePath;
        public int OnSnapshotTaken_width;
        public int OnSnapshotTaken_height;
        public int OnSnapshotTaken_errCode;
        public override void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
            OnSnapshotTaken_be_trigger = true;
            OnSnapshotTaken_connection = connection;
            OnSnapshotTaken_uid = uid;
            OnSnapshotTaken_filePath = filePath;
            OnSnapshotTaken_width = width;
            OnSnapshotTaken_height = height;
            OnSnapshotTaken_errCode = errCode;
        }

        public bool OnSnapshotTakenPassed(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
            if (OnSnapshotTaken_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnSnapshotTaken_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnSnapshotTaken_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnSnapshotTaken_filePath, filePath) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken_errCode, errCode) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteSubscribeFallbackToAudioOnly_be_trigger = false;
        public uint OnRemoteSubscribeFallbackToAudioOnly_uid;
        public bool OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover;
        public override void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
            OnRemoteSubscribeFallbackToAudioOnly_be_trigger = true;
            OnRemoteSubscribeFallbackToAudioOnly_uid = uid;
            OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover = isFallbackOrRecover;
        }

        public bool OnRemoteSubscribeFallbackToAudioOnlyPassed(uint uid, bool isFallbackOrRecover)
        {
            if (OnRemoteSubscribeFallbackToAudioOnly_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteSubscribeFallbackToAudioOnly_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover, isFallbackOrRecover) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteAudioTransportStats_be_trigger = false;
        public RtcConnection OnRemoteAudioTransportStats_connection;
        public uint OnRemoteAudioTransportStats_remoteUid;
        public ushort OnRemoteAudioTransportStats_delay;
        public ushort OnRemoteAudioTransportStats_lost;
        public ushort OnRemoteAudioTransportStats_rxKBitRate;
        public override void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            OnRemoteAudioTransportStats_be_trigger = true;
            OnRemoteAudioTransportStats_connection = connection;
            OnRemoteAudioTransportStats_remoteUid = remoteUid;
            OnRemoteAudioTransportStats_delay = delay;
            OnRemoteAudioTransportStats_lost = lost;
            OnRemoteAudioTransportStats_rxKBitRate = rxKBitRate;
        }

        public bool OnRemoteAudioTransportStatsPassed(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            if (OnRemoteAudioTransportStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioTransportStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteAudioTransportStats_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_delay, delay) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_lost, lost) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_rxKBitRate, rxKBitRate) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteVideoTransportStats_be_trigger = false;
        public RtcConnection OnRemoteVideoTransportStats_connection;
        public uint OnRemoteVideoTransportStats_remoteUid;
        public ushort OnRemoteVideoTransportStats_delay;
        public ushort OnRemoteVideoTransportStats_lost;
        public ushort OnRemoteVideoTransportStats_rxKBitRate;
        public override void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            OnRemoteVideoTransportStats_be_trigger = true;
            OnRemoteVideoTransportStats_connection = connection;
            OnRemoteVideoTransportStats_remoteUid = remoteUid;
            OnRemoteVideoTransportStats_delay = delay;
            OnRemoteVideoTransportStats_lost = lost;
            OnRemoteVideoTransportStats_rxKBitRate = rxKBitRate;
        }

        public bool OnRemoteVideoTransportStatsPassed(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            if (OnRemoteVideoTransportStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoTransportStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteVideoTransportStats_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_delay, delay) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_lost, lost) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_rxKBitRate, rxKBitRate) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalUserRegistered_be_trigger = false;
        public uint OnLocalUserRegistered_uid;
        public string OnLocalUserRegistered_userAccount;
        public override void OnLocalUserRegistered(uint uid, string userAccount)
        {
            OnLocalUserRegistered_be_trigger = true;
            OnLocalUserRegistered_uid = uid;
            OnLocalUserRegistered_userAccount = userAccount;
        }

        public bool OnLocalUserRegisteredPassed(uint uid, string userAccount)
        {
            if (OnLocalUserRegistered_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnLocalUserRegistered_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnLocalUserRegistered_userAccount, userAccount) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserInfoUpdated_be_trigger = false;
        public uint OnUserInfoUpdated_uid;
        public UserInfo OnUserInfoUpdated_info;
        public override void OnUserInfoUpdated(uint uid, UserInfo info)
        {
            OnUserInfoUpdated_be_trigger = true;
            OnUserInfoUpdated_uid = uid;
            OnUserInfoUpdated_info = info;
        }

        public bool OnUserInfoUpdatedPassed(uint uid, UserInfo info)
        {
            if (OnUserInfoUpdated_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserInfoUpdated_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<UserInfo>(OnUserInfoUpdated_info, info) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserAccountUpdated_be_trigger = false;
        public RtcConnection OnUserAccountUpdated_connection;
        public uint OnUserAccountUpdated_remoteUid;
        public string OnUserAccountUpdated_remoteUserAccount;
        public override void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string remoteUserAccount)
        {
            OnUserAccountUpdated_be_trigger = true;
            OnUserAccountUpdated_connection = connection;
            OnUserAccountUpdated_remoteUid = remoteUid;
            OnUserAccountUpdated_remoteUserAccount = remoteUserAccount;
        }

        public bool OnUserAccountUpdatedPassed(RtcConnection connection, uint remoteUid, string remoteUserAccount)
        {
            if (OnUserAccountUpdated_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnUserAccountUpdated_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserAccountUpdated_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserAccountUpdated_remoteUserAccount, remoteUserAccount) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnAudioSubscribeStateChanged_be_trigger = false;
        public string OnAudioSubscribeStateChanged_channel;
        public uint OnAudioSubscribeStateChanged_uid;
        public STREAM_SUBSCRIBE_STATE OnAudioSubscribeStateChanged_oldState;
        public STREAM_SUBSCRIBE_STATE OnAudioSubscribeStateChanged_newState;
        public int OnAudioSubscribeStateChanged_elapseSinceLastState;
        public override void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            OnAudioSubscribeStateChanged_be_trigger = true;
            OnAudioSubscribeStateChanged_channel = channel;
            OnAudioSubscribeStateChanged_uid = uid;
            OnAudioSubscribeStateChanged_oldState = oldState;
            OnAudioSubscribeStateChanged_newState = newState;
            OnAudioSubscribeStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnAudioSubscribeStateChangedPassed(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (OnAudioSubscribeStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<string>(OnAudioSubscribeStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnAudioSubscribeStateChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnAudioSubscribeStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnAudioSubscribeStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoSubscribeStateChanged_be_trigger = false;
        public string OnVideoSubscribeStateChanged_channel;
        public uint OnVideoSubscribeStateChanged_uid;
        public STREAM_SUBSCRIBE_STATE OnVideoSubscribeStateChanged_oldState;
        public STREAM_SUBSCRIBE_STATE OnVideoSubscribeStateChanged_newState;
        public int OnVideoSubscribeStateChanged_elapseSinceLastState;
        public override void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            OnVideoSubscribeStateChanged_be_trigger = true;
            OnVideoSubscribeStateChanged_channel = channel;
            OnVideoSubscribeStateChanged_uid = uid;
            OnVideoSubscribeStateChanged_oldState = oldState;
            OnVideoSubscribeStateChanged_newState = newState;
            OnVideoSubscribeStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnVideoSubscribeStateChangedPassed(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (OnVideoSubscribeStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<string>(OnVideoSubscribeStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnVideoSubscribeStateChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnVideoSubscribeStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnVideoSubscribeStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoRenderingTracingResult_be_trigger = false;
        public RtcConnection OnVideoRenderingTracingResult_connection;
        public uint OnVideoRenderingTracingResult_uid;
        public MEDIA_TRACE_EVENT OnVideoRenderingTracingResult_currentEvent;
        public VideoRenderingTracingInfo OnVideoRenderingTracingResult_tracingInfo;
        public override void OnVideoRenderingTracingResult(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            OnVideoRenderingTracingResult_be_trigger = true;
            OnVideoRenderingTracingResult_connection = connection;
            OnVideoRenderingTracingResult_uid = uid;
            OnVideoRenderingTracingResult_currentEvent = currentEvent;
            OnVideoRenderingTracingResult_tracingInfo = tracingInfo;
        }

        public bool OnVideoRenderingTracingResultPassed(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            if (OnVideoRenderingTracingResult_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnVideoRenderingTracingResult_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnVideoRenderingTracingResult_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<MEDIA_TRACE_EVENT>(OnVideoRenderingTracingResult_currentEvent, currentEvent) == false)
                return false;
            if (ParamsHelper.Compare<VideoRenderingTracingInfo>(OnVideoRenderingTracingResult_tracingInfo, tracingInfo) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalVideoTranscoderError_be_trigger = false;
        public TranscodingVideoStream OnLocalVideoTranscoderError_stream;
        public VIDEO_TRANSCODER_ERROR OnLocalVideoTranscoderError_error;
        public override void OnLocalVideoTranscoderError(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
            OnLocalVideoTranscoderError_be_trigger = true;
            OnLocalVideoTranscoderError_stream = stream;
            OnLocalVideoTranscoderError_error = error;
        }

        public bool OnLocalVideoTranscoderErrorPassed(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
            if (OnLocalVideoTranscoderError_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<TranscodingVideoStream>(OnLocalVideoTranscoderError_stream, stream) == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_TRANSCODER_ERROR>(OnLocalVideoTranscoderError_error, error) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoLayoutInfo_be_trigger = false;
        public RtcConnection OnVideoLayoutInfo_connection;
        public uint OnVideoLayoutInfo_uid;
        public int OnVideoLayoutInfo_width;
        public int OnVideoLayoutInfo_height;
        public int OnVideoLayoutInfo_layoutNumber;
        public VideoLayout const* OnVideoLayoutInfo_layoutlist;
        public override void OnVideoLayoutInfo(RtcConnection connection, uint uid, int width, int height, int layoutNumber, VideoLayout const* layoutlist)
{
OnVideoLayoutInfo_be_trigger = true;
OnVideoLayoutInfo_connection=connection;
OnVideoLayoutInfo_uid=uid;
OnVideoLayoutInfo_width=width;
OnVideoLayoutInfo_height=height;
OnVideoLayoutInfo_layoutNumber=layoutNumber;
OnVideoLayoutInfo_layoutlist=layoutlist;
}

    public bool OnVideoLayoutInfoPassed(RtcConnection connection, uint uid, int width, int height, int layoutNumber, VideoLayout const* layoutlist)
    {
        if (OnVideoLayoutInfo_be_trigger == false)
            return false;
        if (ParamsHelper.Compare<RtcConnection>(OnVideoLayoutInfo_connection, connection) == false)
            return false;
        if (ParamsHelper.Compare<uint>(OnVideoLayoutInfo_uid, uid) == false)
            return false;
        if (ParamsHelper.Compare<int>(OnVideoLayoutInfo_width, width) == false)
            return false;
        if (ParamsHelper.Compare<int>(OnVideoLayoutInfo_height, height) == false)
            return false;
        if (ParamsHelper.Compare<int>(OnVideoLayoutInfo_layoutNumber, layoutNumber) == false)
            return false;
        if (ParamsHelper.Compare < VideoLayout const*> (OnVideoLayoutInfo_layoutlist, layoutlist) == false)
return false;
        return true;
    }

    //////////////////
    #endregion terra IRtcEngineEventHandler
}
}
