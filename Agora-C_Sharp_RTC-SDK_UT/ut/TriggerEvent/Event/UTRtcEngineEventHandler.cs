using System;
using uid_t = System.UInt32;
namespace Agora.Rtc
{
    public class UTRtcEngineEventHandler : IRtcEngineEventHandler
    {

        #region IRtcEngineEventHandlerEx Start


        ///////////////////////////////////

        public bool OnJoinChannelSuccess_be_trigger = false;
        public RtcConnection OnJoinChannelSuccess_connection = null;
        public int OnJoinChannelSuccess_elapsed = 0;

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

            if (ParamsHelper.compareRtcConnection(OnJoinChannelSuccess_connection, connection) == false)
                return false;
            if (ParamsHelper.compareInt(OnJoinChannelSuccess_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRejoinChannelSuccess_be_trigger = false;
        public RtcConnection OnRejoinChannelSuccess_connection = null;
        public int OnRejoinChannelSuccess_elapsed = 0;

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

            if (ParamsHelper.compareRtcConnection(OnRejoinChannelSuccess_connection, connection) == false)
                return false;
            if (ParamsHelper.compareInt(OnRejoinChannelSuccess_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioQuality_be_trigger = false;
        public RtcConnection OnAudioQuality_connection = null;
        public uid_t OnAudioQuality_remoteUid = 0;
        public int OnAudioQuality_quality = 0;
        public UInt16 OnAudioQuality_delay = 0;
        public UInt16 OnAudioQuality_lost = 0;

        public override void OnAudioQuality(RtcConnection connection, uid_t remoteUid, int quality, UInt16 delay, UInt16 lost)
        {
            OnAudioQuality_be_trigger = true;
            OnAudioQuality_connection = connection;
            OnAudioQuality_remoteUid = remoteUid;
            OnAudioQuality_quality = quality;
            OnAudioQuality_delay = delay;
            OnAudioQuality_lost = lost;
        }

        public bool OnAudioQualityPassed(RtcConnection connection, uid_t remoteUid, int quality, UInt16 delay, UInt16 lost)
        {
            if (OnAudioQuality_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnAudioQuality_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnAudioQuality_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareInt(OnAudioQuality_quality, quality) == false)
                return false;
            if (ParamsHelper.compareUnsignedShort(OnAudioQuality_delay, delay) == false)
                return false;
            if (ParamsHelper.compareUnsignedShort(OnAudioQuality_lost, lost) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioVolumeIndication_be_trigger = false;
        public RtcConnection OnAudioVolumeIndication_connection = null;
        public AudioVolumeInfo[] OnAudioVolumeIndication_speakers = null;
        public uint OnAudioVolumeIndication_speakerNumber = 0;
        public int OnAudioVolumeIndication_totalVolume = 0;

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

            if (ParamsHelper.compareRtcConnection(OnAudioVolumeIndication_connection, connection) == false)
                return false;
            if (ParamsHelper.compareAudioVolumeInfoArray(OnAudioVolumeIndication_speakers, speakers) == false)
                return false;
            if (ParamsHelper.compareUint(OnAudioVolumeIndication_speakerNumber, speakerNumber) == false)
                return false;
            if (ParamsHelper.compareInt(OnAudioVolumeIndication_totalVolume, totalVolume) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLeaveChannel_be_trigger = false;
        public RtcConnection OnLeaveChannel_connection = null;
        public RtcStats OnLeaveChannel_stats = null;

        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            OnLeaveChannel_be_trigger = true;
            OnLeaveChannel_connection = connection;
            OnLeaveChannel_stats = stats;
        }

        public bool OnLeaveChannelPassed(RtcConnection connection, RtcStats stats)
        {
            if (OnLeaveChannel_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnLeaveChannel_connection, connection) == false)
                return false;
            if (ParamsHelper.compareRtcStats(OnLeaveChannel_stats, stats) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRtcStats_be_trigger = false;
        public RtcConnection OnRtcStats_connection = null;
        public RtcStats OnRtcStats_stats = null;

        public override void OnRtcStats(RtcConnection connection, RtcStats stats)
        {
            OnRtcStats_be_trigger = true;
            OnRtcStats_connection = connection;
            OnRtcStats_stats = stats;
        }

        public bool OnRtcStatsPassed(RtcConnection connection, RtcStats stats)
        {
            if (OnRtcStats_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnRtcStats_connection, connection) == false)
                return false;
            if (ParamsHelper.compareRtcStats(OnRtcStats_stats, stats) == false)
                return false;

            return true;
        }

        ///////////////////////////////////
       

        public bool OnAudioDeviceStateChanged_be_trigger = false;
        public string OnAudioDeviceStateChanged_deviceId = null;
        public MEDIA_DEVICE_TYPE OnAudioDeviceStateChanged_deviceType ;
        public MEDIA_DEVICE_STATE_TYPE OnAudioDeviceStateChanged_deviceState;

        public override void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            OnAudioDeviceStateChanged_be_trigger = true;
            OnAudioDeviceStateChanged_deviceId = deviceId;
            OnAudioDeviceStateChanged_deviceType = deviceType;
            OnAudioDeviceStateChanged_deviceState = deviceState;
        }

        public bool OnAudioDeviceStateChangedPassed(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            if (OnAudioDeviceStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnAudioDeviceStateChanged_deviceId, deviceId) == false)
                return false;
            if (ParamsHelper.compareMEDIA_DEVICE_TYPE(OnAudioDeviceStateChanged_deviceType, deviceType) == false)
                return false;
            if (ParamsHelper.compareMEDIA_DEVICE_STATE_TYPE(OnAudioDeviceStateChanged_deviceState, deviceState) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnNetworkQuality_be_trigger = false;
        public RtcConnection OnNetworkQuality_connection = null;
        public uid_t OnNetworkQuality_remoteUid = 0;
        public int OnNetworkQuality_txQuality = 0;
        public int OnNetworkQuality_rxQuality = 0;

        public override void OnNetworkQuality(RtcConnection connection, uid_t remoteUid, int txQuality, int rxQuality)
        {
            OnNetworkQuality_be_trigger = true;
            OnNetworkQuality_connection = connection;
            OnNetworkQuality_remoteUid = remoteUid;
            OnNetworkQuality_txQuality = txQuality;
            OnNetworkQuality_rxQuality = rxQuality;
        }

        public bool OnNetworkQualityPassed(RtcConnection connection, uid_t remoteUid, int txQuality, int rxQuality)
        {
            if (OnNetworkQuality_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnNetworkQuality_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnNetworkQuality_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareInt(OnNetworkQuality_txQuality, txQuality) == false)
                return false;
            if (ParamsHelper.compareInt(OnNetworkQuality_rxQuality, rxQuality) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnIntraRequestReceived_be_trigger = false;
        public RtcConnection OnIntraRequestReceived_connection = null;

        public override void OnIntraRequestReceived(RtcConnection connection)
        {
            OnIntraRequestReceived_be_trigger = true;
            OnIntraRequestReceived_connection = connection;
        }

        public bool OnIntraRequestReceivedPassed(RtcConnection connection)
        {
            if (OnIntraRequestReceived_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnIntraRequestReceived_connection, connection) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnFirstLocalVideoFrame_be_trigger = false;
        public RtcConnection OnFirstLocalVideoFrame_connection = null;
        public int OnFirstLocalVideoFrame_width = 0;
        public int OnFirstLocalVideoFrame_height = 0;
        public int OnFirstLocalVideoFrame_elapsed = 0;

        public override void OnFirstLocalVideoFrame(RtcConnection connection, int width, int height, int elapsed)
        {
            OnFirstLocalVideoFrame_be_trigger = true;
            OnFirstLocalVideoFrame_connection = connection;
            OnFirstLocalVideoFrame_width = width;
            OnFirstLocalVideoFrame_height = height;
            OnFirstLocalVideoFrame_elapsed = elapsed;
        }

        public bool OnFirstLocalVideoFramePassed(RtcConnection connection, int width, int height, int elapsed)
        {
            if (OnFirstLocalVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnFirstLocalVideoFrame_connection, connection) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstLocalVideoFrame_width, width) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstLocalVideoFrame_height, height) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstLocalVideoFrame_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnFirstLocalVideoFramePublished_be_trigger = false;
        public RtcConnection OnFirstLocalVideoFramePublished_connection = null;
        public int OnFirstLocalVideoFramePublished_elapsed = 0;

        public override void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)
        {
            OnFirstLocalVideoFramePublished_be_trigger = true;
            OnFirstLocalVideoFramePublished_connection = connection;
            OnFirstLocalVideoFramePublished_elapsed = elapsed;
        }

        public bool OnFirstLocalVideoFramePublishedPassed(RtcConnection connection, int elapsed)
        {
            if (OnFirstLocalVideoFramePublished_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnFirstLocalVideoFramePublished_connection, connection) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstLocalVideoFramePublished_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnFirstRemoteVideoDecoded_be_trigger = false;
        public RtcConnection OnFirstRemoteVideoDecoded_connection = null;
        public uid_t OnFirstRemoteVideoDecoded_remoteUid = 0;
        public int OnFirstRemoteVideoDecoded_width = 0;
        public int OnFirstRemoteVideoDecoded_height = 0;
        public int OnFirstRemoteVideoDecoded_elapsed = 0;

        public override void OnFirstRemoteVideoDecoded(RtcConnection connection, uid_t remoteUid, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoDecoded_be_trigger = true;
            OnFirstRemoteVideoDecoded_connection = connection;
            OnFirstRemoteVideoDecoded_remoteUid = remoteUid;
            OnFirstRemoteVideoDecoded_width = width;
            OnFirstRemoteVideoDecoded_height = height;
            OnFirstRemoteVideoDecoded_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoDecodedPassed(RtcConnection connection, uid_t remoteUid, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoDecoded_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnFirstRemoteVideoDecoded_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnFirstRemoteVideoDecoded_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstRemoteVideoDecoded_width, width) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstRemoteVideoDecoded_height, height) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstRemoteVideoDecoded_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnVideoSizeChanged_be_trigger = false;
        public RtcConnection OnVideoSizeChanged_connection = null;
        public VIDEO_SOURCE_TYPE OnVideoSizeChanged_sourceType;
        public uid_t OnVideoSizeChanged_uid = 0;
        public int OnVideoSizeChanged_width = 0;
        public int OnVideoSizeChanged_height = 0;
        public int OnVideoSizeChanged_rotation = 0;

        public override void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uid_t uid, int width, int height, int rotation)
        {
            OnVideoSizeChanged_be_trigger = true;
            OnVideoSizeChanged_connection = connection;
            OnVideoSizeChanged_sourceType = sourceType;
            OnVideoSizeChanged_uid = uid;
            OnVideoSizeChanged_width = width;
            OnVideoSizeChanged_height = height;
            OnVideoSizeChanged_rotation = rotation;
        }

        public bool OnVideoSizeChangedPassed(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uid_t uid, int width, int height, int rotation)
        {
            if (OnVideoSizeChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnVideoSizeChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.compareVIDEO_SOURCE_TYPE(OnVideoSizeChanged_sourceType, sourceType) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnVideoSizeChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.compareInt(OnVideoSizeChanged_width, width) == false)
                return false;
            if (ParamsHelper.compareInt(OnVideoSizeChanged_height, height) == false)
                return false;
            if (ParamsHelper.compareInt(OnVideoSizeChanged_rotation, rotation) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRemoteVideoStateChanged_be_trigger = false;
        public RtcConnection OnRemoteVideoStateChanged_connection = null;
        public uid_t OnRemoteVideoStateChanged_remoteUid = 0;
        public REMOTE_VIDEO_STATE OnRemoteVideoStateChanged_state;
        public REMOTE_VIDEO_STATE_REASON OnRemoteVideoStateChanged_reason;
        public int OnRemoteVideoStateChanged_elapsed = 0;

        public override void OnRemoteVideoStateChanged(RtcConnection connection, uid_t remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            OnRemoteVideoStateChanged_be_trigger = true;
            OnRemoteVideoStateChanged_connection = connection;
            OnRemoteVideoStateChanged_remoteUid = remoteUid;
            OnRemoteVideoStateChanged_state = state;
            OnRemoteVideoStateChanged_reason = reason;
            OnRemoteVideoStateChanged_elapsed = elapsed;
        }

        public bool OnRemoteVideoStateChangedPassed(RtcConnection connection, uid_t remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteVideoStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnRemoteVideoStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnRemoteVideoStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareREMOTE_VIDEO_STATE(OnRemoteVideoStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareREMOTE_VIDEO_STATE_REASON(OnRemoteVideoStateChanged_reason, reason) == false)
                return false;
            if (ParamsHelper.compareInt(OnRemoteVideoStateChanged_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnFirstRemoteVideoFrame_be_trigger = false;
        public RtcConnection OnFirstRemoteVideoFrame_connection = null;
        public uid_t OnFirstRemoteVideoFrame_remoteUid = 0;
        public int OnFirstRemoteVideoFrame_width = 0;
        public int OnFirstRemoteVideoFrame_height = 0;
        public int OnFirstRemoteVideoFrame_elapsed = 0;

        public override void OnFirstRemoteVideoFrame(RtcConnection connection, uid_t remoteUid, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoFrame_be_trigger = true;
            OnFirstRemoteVideoFrame_connection = connection;
            OnFirstRemoteVideoFrame_remoteUid = remoteUid;
            OnFirstRemoteVideoFrame_width = width;
            OnFirstRemoteVideoFrame_height = height;
            OnFirstRemoteVideoFrame_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoFramePassed(RtcConnection connection, uid_t remoteUid, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnFirstRemoteVideoFrame_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnFirstRemoteVideoFrame_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstRemoteVideoFrame_width, width) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstRemoteVideoFrame_height, height) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstRemoteVideoFrame_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserJoined_be_trigger = false;
        public RtcConnection OnUserJoined_connection = null;
        public uid_t OnUserJoined_remoteUid = 0;
        public int OnUserJoined_elapsed = 0;

        public override void OnUserJoined(RtcConnection connection, uid_t remoteUid, int elapsed)
        {
            OnUserJoined_be_trigger = true;
            OnUserJoined_connection = connection;
            OnUserJoined_remoteUid = remoteUid;
            OnUserJoined_elapsed = elapsed;
        }

        public bool OnUserJoinedPassed(RtcConnection connection, uid_t remoteUid, int elapsed)
        {
            if (OnUserJoined_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUserJoined_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnUserJoined_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareInt(OnUserJoined_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserOffline_be_trigger = false;
        public RtcConnection OnUserOffline_connection = null;
        public uid_t OnUserOffline_remoteUid = 0;
        public USER_OFFLINE_REASON_TYPE OnUserOffline_reason;

        public override void OnUserOffline(RtcConnection connection, uid_t remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            OnUserOffline_be_trigger = true;
            OnUserOffline_connection = connection;
            OnUserOffline_remoteUid = remoteUid;
            OnUserOffline_reason = reason;
        }

        public bool OnUserOfflinePassed(RtcConnection connection, uid_t remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            if (OnUserOffline_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUserOffline_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnUserOffline_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareUSER_OFFLINE_REASON_TYPE(OnUserOffline_reason, reason) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserMuteAudio_be_trigger = false;
        public RtcConnection OnUserMuteAudio_connection = null;
        public uid_t OnUserMuteAudio_remoteUid = 0;
        public bool OnUserMuteAudio_muted = false;

        public override void OnUserMuteAudio(RtcConnection connection, uid_t remoteUid, bool muted)
        {
            OnUserMuteAudio_be_trigger = true;
            OnUserMuteAudio_connection = connection;
            OnUserMuteAudio_remoteUid = remoteUid;
            OnUserMuteAudio_muted = muted;
        }

        public bool OnUserMuteAudioPassed(RtcConnection connection, uid_t remoteUid, bool muted)
        {
            if (OnUserMuteAudio_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUserMuteAudio_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnUserMuteAudio_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareBool(OnUserMuteAudio_muted, muted) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserMuteVideo_be_trigger = false;
        public RtcConnection OnUserMuteVideo_connection = null;
        public uid_t OnUserMuteVideo_remoteUid = 0;
        public bool OnUserMuteVideo_muted = false;

        public override void OnUserMuteVideo(RtcConnection connection, uid_t remoteUid, bool muted)
        {
            OnUserMuteVideo_be_trigger = true;
            OnUserMuteVideo_connection = connection;
            OnUserMuteVideo_remoteUid = remoteUid;
            OnUserMuteVideo_muted = muted;
        }

        public bool OnUserMuteVideoPassed(RtcConnection connection, uid_t remoteUid, bool muted)
        {
            if (OnUserMuteVideo_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUserMuteVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnUserMuteVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareBool(OnUserMuteVideo_muted, muted) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserEnableVideo_be_trigger = false;
        public RtcConnection OnUserEnableVideo_connection = null;
        public uid_t OnUserEnableVideo_remoteUid = 0;
        public bool OnUserEnableVideo_enabled = false;

        public override void OnUserEnableVideo(RtcConnection connection, uid_t remoteUid, bool enabled)
        {
            OnUserEnableVideo_be_trigger = true;
            OnUserEnableVideo_connection = connection;
            OnUserEnableVideo_remoteUid = remoteUid;
            OnUserEnableVideo_enabled = enabled;
        }

        public bool OnUserEnableVideoPassed(RtcConnection connection, uid_t remoteUid, bool enabled)
        {
            if (OnUserEnableVideo_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUserEnableVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnUserEnableVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareBool(OnUserEnableVideo_enabled, enabled) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserEnableLocalVideo_be_trigger = false;
        public RtcConnection OnUserEnableLocalVideo_connection = null;
        public uid_t OnUserEnableLocalVideo_remoteUid = 0;
        public bool OnUserEnableLocalVideo_enabled = false;

        public override void OnUserEnableLocalVideo(RtcConnection connection, uid_t remoteUid, bool enabled)
        {
            OnUserEnableLocalVideo_be_trigger = true;
            OnUserEnableLocalVideo_connection = connection;
            OnUserEnableLocalVideo_remoteUid = remoteUid;
            OnUserEnableLocalVideo_enabled = enabled;
        }

        public bool OnUserEnableLocalVideoPassed(RtcConnection connection, uid_t remoteUid, bool enabled)
        {
            if (OnUserEnableLocalVideo_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUserEnableLocalVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnUserEnableLocalVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareBool(OnUserEnableLocalVideo_enabled, enabled) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserStateChanged_be_trigger = false;
        public RtcConnection OnUserStateChanged_connection = null;
        public uid_t OnUserStateChanged_remoteUid = 0;
        public uint OnUserStateChanged_state = 0;

        public override void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
            OnUserStateChanged_be_trigger = true;
            OnUserStateChanged_connection = connection;
            OnUserStateChanged_remoteUid = remoteUid;
            OnUserStateChanged_state = state;
        }

        public bool OnUserStateChangedPassed(RtcConnection connection, uid_t remoteUid, uint state)
        {
            if (OnUserStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUserStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnUserStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareUint(OnUserStateChanged_state, state) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLocalAudioStats_be_trigger = false;
        public RtcConnection OnLocalAudioStats_connection = null;
        public LocalAudioStats OnLocalAudioStats_stats = null;

        public override void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)
        {
            OnLocalAudioStats_be_trigger = true;
            OnLocalAudioStats_connection = connection;
            OnLocalAudioStats_stats = stats;
        }

        public bool OnLocalAudioStatsPassed(RtcConnection connection, LocalAudioStats stats)
        {
            if (OnLocalAudioStats_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnLocalAudioStats_connection, connection) == false)
                return false;
            if (ParamsHelper.compareLocalAudioStats(OnLocalAudioStats_stats, stats) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRemoteAudioStats_be_trigger = false;
        public RtcConnection OnRemoteAudioStats_connection = null;
        public RemoteAudioStats OnRemoteAudioStats_stats = null;

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

            if (ParamsHelper.compareRtcConnection(OnRemoteAudioStats_connection, connection) == false)
                return false;
            if (ParamsHelper.compareRemoteAudioStats(OnRemoteAudioStats_stats, stats) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLocalVideoStats_be_trigger = false;
        public RtcConnection OnLocalVideoStats_connection = null;
        public LocalVideoStats OnLocalVideoStats_stats = null;

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

            if (ParamsHelper.compareRtcConnection(OnLocalVideoStats_connection, connection) == false)
                return false;
            if (ParamsHelper.compareLocalVideoStats(OnLocalVideoStats_stats, stats) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRemoteVideoStats_be_trigger = false;
        public RtcConnection OnRemoteVideoStats_connection = null;
        public RemoteVideoStats OnRemoteVideoStats_stats = null;

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

            if (ParamsHelper.compareRtcConnection(OnRemoteVideoStats_connection, connection) == false)
                return false;
            if (ParamsHelper.compareRemoteVideoStats(OnRemoteVideoStats_stats, stats) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnConnectionLost_be_trigger = false;
        public RtcConnection OnConnectionLost_connection = null;

        public override void OnConnectionLost(RtcConnection connection)
        {
            OnConnectionLost_be_trigger = true;
            OnConnectionLost_connection = connection;
        }

        public bool OnConnectionLostPassed(RtcConnection connection)
        {
            if (OnConnectionLost_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnConnectionLost_connection, connection) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnConnectionInterrupted_be_trigger = false;
        public RtcConnection OnConnectionInterrupted_connection = null;

        public override void OnConnectionInterrupted(RtcConnection connection)
        {
            OnConnectionInterrupted_be_trigger = true;
            OnConnectionInterrupted_connection = connection;
        }

        public bool OnConnectionInterruptedPassed(RtcConnection connection)
        {
            if (OnConnectionInterrupted_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnConnectionInterrupted_connection, connection) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnConnectionBanned_be_trigger = false;
        public RtcConnection OnConnectionBanned_connection = null;

        public override void OnConnectionBanned(RtcConnection connection)
        {
            OnConnectionBanned_be_trigger = true;
            OnConnectionBanned_connection = connection;
        }

        public bool OnConnectionBannedPassed(RtcConnection connection)
        {
            if (OnConnectionBanned_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnConnectionBanned_connection, connection) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnStreamMessage_be_trigger = false;
        public RtcConnection OnStreamMessage_connection = null;
        public uid_t OnStreamMessage_remoteUid = 0;
        public int OnStreamMessage_streamId = 0;
        public byte[] OnStreamMessage_data = null;
        public uint OnStreamMessage_length = 0;
        public ulong OnStreamMessage_sentTs = 0;

        public override void OnStreamMessage(RtcConnection connection, uid_t remoteUid, int streamId, byte[] data, uint length, ulong sentTs)
        {
            OnStreamMessage_be_trigger = true;
            OnStreamMessage_connection = connection;
            OnStreamMessage_remoteUid = remoteUid;
            OnStreamMessage_streamId = streamId;
            OnStreamMessage_data = data;
            OnStreamMessage_length = length;
            OnStreamMessage_sentTs = sentTs;
        }

        public bool OnStreamMessagePassed(RtcConnection connection, uid_t remoteUid, int streamId, byte[] data, uint length, ulong sentTs)
        {
            if (OnStreamMessage_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnStreamMessage_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnStreamMessage_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareInt(OnStreamMessage_streamId, streamId) == false)
                return false;
            //if (ParamsHelper.compareString(OnStreamMessage_data, data) == false)
            //    return false;
            if (ParamsHelper.compareUint(OnStreamMessage_length, length) == false)
                return false;
            if (ParamsHelper.compareUlong(OnStreamMessage_sentTs, sentTs) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnStreamMessageError_be_trigger = false;
        public RtcConnection OnStreamMessageError_connection = null;
        public uid_t OnStreamMessageError_remoteUid = 0;
        public int OnStreamMessageError_streamId = 0;
        public int OnStreamMessageError_code = 0;
        public int OnStreamMessageError_missed = 0;
        public int OnStreamMessageError_cached = 0;

        public override void OnStreamMessageError(RtcConnection connection, uid_t remoteUid, int streamId, int code, int missed, int cached)
        {
            OnStreamMessageError_be_trigger = true;
            OnStreamMessageError_connection = connection;
            OnStreamMessageError_remoteUid = remoteUid;
            OnStreamMessageError_streamId = streamId;
            OnStreamMessageError_code = code;
            OnStreamMessageError_missed = missed;
            OnStreamMessageError_cached = cached;
        }

        public bool OnStreamMessageErrorPassed(RtcConnection connection, uid_t remoteUid, int streamId, int code, int missed, int cached)
        {
            if (OnStreamMessageError_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnStreamMessageError_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnStreamMessageError_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareInt(OnStreamMessageError_streamId, streamId) == false)
                return false;
            if (ParamsHelper.compareInt(OnStreamMessageError_code, code) == false)
                return false;
            if (ParamsHelper.compareInt(OnStreamMessageError_missed, missed) == false)
                return false;
            if (ParamsHelper.compareInt(OnStreamMessageError_cached, cached) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRequestToken_be_trigger = false;
        public RtcConnection OnRequestToken_connection = null;

        public override void OnRequestToken(RtcConnection connection)
        {
            OnRequestToken_be_trigger = true;
            OnRequestToken_connection = connection;
        }

        public bool OnRequestTokenPassed(RtcConnection connection)
        {
            if (OnRequestToken_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnRequestToken_connection, connection) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLicenseValidationFailure_be_trigger = false;
        public RtcConnection OnLicenseValidationFailure_connection = null;
        public LICENSE_ERROR_TYPE OnLicenseValidationFailure_reason;

        public override void OnLicenseValidationFailure(RtcConnection connection, LICENSE_ERROR_TYPE reason)
        {
            OnLicenseValidationFailure_be_trigger = true;
            OnLicenseValidationFailure_connection = connection;
            OnLicenseValidationFailure_reason = reason;
        }

        public bool OnLicenseValidationFailurePassed(RtcConnection connection, LICENSE_ERROR_TYPE reason)
        {
            if (OnLicenseValidationFailure_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnLicenseValidationFailure_connection, connection) == false)
                return false;
            if (ParamsHelper.compareLICENSE_ERROR_TYPE(OnLicenseValidationFailure_reason, reason) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnTokenPrivilegeWillExpire_be_trigger = false;
        public RtcConnection OnTokenPrivilegeWillExpire_connection = null;
        public string OnTokenPrivilegeWillExpire_token = null;

        public override void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
        {
            OnTokenPrivilegeWillExpire_be_trigger = true;
            OnTokenPrivilegeWillExpire_connection = connection;
            OnTokenPrivilegeWillExpire_token = token;
        }

        public bool OnTokenPrivilegeWillExpirePassed(RtcConnection connection, string token)
        {
            if (OnTokenPrivilegeWillExpire_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnTokenPrivilegeWillExpire_connection, connection) == false)
                return false;
            if (ParamsHelper.compareString(OnTokenPrivilegeWillExpire_token, token) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnFirstLocalAudioFramePublished_be_trigger = false;
        public RtcConnection OnFirstLocalAudioFramePublished_connection = null;
        public int OnFirstLocalAudioFramePublished_elapsed = 0;

        public override void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)
        {
            OnFirstLocalAudioFramePublished_be_trigger = true;
            OnFirstLocalAudioFramePublished_connection = connection;
            OnFirstLocalAudioFramePublished_elapsed = elapsed;
        }

        public bool OnFirstLocalAudioFramePublishedPassed(RtcConnection connection, int elapsed)
        {
            if (OnFirstLocalAudioFramePublished_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnFirstLocalAudioFramePublished_connection, connection) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstLocalAudioFramePublished_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnFirstRemoteAudioFrame_be_trigger = false;
        public RtcConnection OnFirstRemoteAudioFrame_connection = null;
        public uid_t OnFirstRemoteAudioFrame_userId = 0;
        public int OnFirstRemoteAudioFrame_elapsed = 0;

        public override void OnFirstRemoteAudioFrame(RtcConnection connection, uid_t userId, int elapsed)
        {
            OnFirstRemoteAudioFrame_be_trigger = true;
            OnFirstRemoteAudioFrame_connection = connection;
            OnFirstRemoteAudioFrame_userId = userId;
            OnFirstRemoteAudioFrame_elapsed = elapsed;
        }

        public bool OnFirstRemoteAudioFramePassed(RtcConnection connection, uid_t userId, int elapsed)
        {
            if (OnFirstRemoteAudioFrame_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnFirstRemoteAudioFrame_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnFirstRemoteAudioFrame_userId, userId) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstRemoteAudioFrame_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnFirstRemoteAudioDecoded_be_trigger = false;
        public RtcConnection OnFirstRemoteAudioDecoded_connection = null;
        public uid_t OnFirstRemoteAudioDecoded_uid = 0;
        public int OnFirstRemoteAudioDecoded_elapsed = 0;

        public override void OnFirstRemoteAudioDecoded(RtcConnection connection, uid_t uid, int elapsed)
        {
            OnFirstRemoteAudioDecoded_be_trigger = true;
            OnFirstRemoteAudioDecoded_connection = connection;
            OnFirstRemoteAudioDecoded_uid = uid;
            OnFirstRemoteAudioDecoded_elapsed = elapsed;
        }

        public bool OnFirstRemoteAudioDecodedPassed(RtcConnection connection, uid_t uid, int elapsed)
        {
            if (OnFirstRemoteAudioDecoded_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnFirstRemoteAudioDecoded_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnFirstRemoteAudioDecoded_uid, uid) == false)
                return false;
            if (ParamsHelper.compareInt(OnFirstRemoteAudioDecoded_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLocalAudioStateChanged_be_trigger = false;
        public RtcConnection OnLocalAudioStateChanged_connection = null;
        public LOCAL_AUDIO_STREAM_STATE OnLocalAudioStateChanged_state;
        public LOCAL_AUDIO_STREAM_ERROR OnLocalAudioStateChanged_error;

        public override void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            OnLocalAudioStateChanged_be_trigger = true;
            OnLocalAudioStateChanged_connection = connection;
            OnLocalAudioStateChanged_state = state;
            OnLocalAudioStateChanged_error = error;
        }

        public bool OnLocalAudioStateChangedPassed(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            if (OnLocalAudioStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnLocalAudioStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.compareLOCAL_AUDIO_STREAM_STATE(OnLocalAudioStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareLOCAL_AUDIO_STREAM_ERROR(OnLocalAudioStateChanged_error, error) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRemoteAudioStateChanged_be_trigger = false;
        public RtcConnection OnRemoteAudioStateChanged_connection = null;
        public uid_t OnRemoteAudioStateChanged_remoteUid = 0;
        public REMOTE_AUDIO_STATE OnRemoteAudioStateChanged_state;
        public REMOTE_AUDIO_STATE_REASON OnRemoteAudioStateChanged_reason;
        public int OnRemoteAudioStateChanged_elapsed = 0;

        public override void OnRemoteAudioStateChanged(RtcConnection connection, uid_t remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            OnRemoteAudioStateChanged_be_trigger = true;
            OnRemoteAudioStateChanged_connection = connection;
            OnRemoteAudioStateChanged_remoteUid = remoteUid;
            OnRemoteAudioStateChanged_state = state;
            OnRemoteAudioStateChanged_reason = reason;
            OnRemoteAudioStateChanged_elapsed = elapsed;
        }

        public bool OnRemoteAudioStateChangedPassed(RtcConnection connection, uid_t remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteAudioStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnRemoteAudioStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnRemoteAudioStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareREMOTE_AUDIO_STATE(OnRemoteAudioStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareREMOTE_AUDIO_STATE_REASON(OnRemoteAudioStateChanged_reason, reason) == false)
                return false;
            if (ParamsHelper.compareInt(OnRemoteAudioStateChanged_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnActiveSpeaker_be_trigger = false;
        public RtcConnection OnActiveSpeaker_connection = null;
        public uid_t OnActiveSpeaker_uid = 0;

        public override void OnActiveSpeaker(RtcConnection connection, uid_t uid)
        {
            OnActiveSpeaker_be_trigger = true;
            OnActiveSpeaker_connection = connection;
            OnActiveSpeaker_uid = uid;
        }

        public bool OnActiveSpeakerPassed(RtcConnection connection, uid_t uid)
        {
            if (OnActiveSpeaker_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnActiveSpeaker_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnActiveSpeaker_uid, uid) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnClientRoleChanged_be_trigger = false;
        public RtcConnection OnClientRoleChanged_connection = null;
        public CLIENT_ROLE_TYPE OnClientRoleChanged_oldRole;
        public CLIENT_ROLE_TYPE OnClientRoleChanged_newRole;
        public ClientRoleOptions OnClientRoleChanged_newRoleOptions = null;

        public override void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            OnClientRoleChanged_be_trigger = true;
            OnClientRoleChanged_connection = connection;
            OnClientRoleChanged_oldRole = oldRole;
            OnClientRoleChanged_newRole = newRole;
            OnClientRoleChanged_newRoleOptions = newRoleOptions;
        }

        public bool OnClientRoleChangedPassed(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            if (OnClientRoleChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnClientRoleChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.compareCLIENT_ROLE_TYPE(OnClientRoleChanged_oldRole, oldRole) == false)
                return false;
            if (ParamsHelper.compareCLIENT_ROLE_TYPE(OnClientRoleChanged_newRole, newRole) == false)
                return false;
            if (ParamsHelper.compareClientRoleOptions(OnClientRoleChanged_newRoleOptions, newRoleOptions) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnClientRoleChangeFailed_be_trigger = false;
        public RtcConnection OnClientRoleChangeFailed_connection = null;
        public CLIENT_ROLE_CHANGE_FAILED_REASON OnClientRoleChangeFailed_reason;
        public CLIENT_ROLE_TYPE OnClientRoleChangeFailed_currentRole;

        public override void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            OnClientRoleChangeFailed_be_trigger = true;
            OnClientRoleChangeFailed_connection = connection;
            OnClientRoleChangeFailed_reason = reason;
            OnClientRoleChangeFailed_currentRole = currentRole;
        }

        public bool OnClientRoleChangeFailedPassed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            if (OnClientRoleChangeFailed_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnClientRoleChangeFailed_connection, connection) == false)
                return false;
            if (ParamsHelper.compareCLIENT_ROLE_CHANGE_FAILED_REASON(OnClientRoleChangeFailed_reason, reason) == false)
                return false;
            if (ParamsHelper.compareCLIENT_ROLE_TYPE(OnClientRoleChangeFailed_currentRole, currentRole) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRemoteAudioTransportStats_be_trigger = false;
        public RtcConnection OnRemoteAudioTransportStats_connection = null;
        public uid_t OnRemoteAudioTransportStats_remoteUid = 0;
        public UInt16 OnRemoteAudioTransportStats_delay = 0;
        public UInt16 OnRemoteAudioTransportStats_lost = 0;
        public UInt16 OnRemoteAudioTransportStats_rxKBitRate = 0;

        public override void OnRemoteAudioTransportStats(RtcConnection connection, uid_t remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate)
        {
            OnRemoteAudioTransportStats_be_trigger = true;
            OnRemoteAudioTransportStats_connection = connection;
            OnRemoteAudioTransportStats_remoteUid = remoteUid;
            OnRemoteAudioTransportStats_delay = delay;
            OnRemoteAudioTransportStats_lost = lost;
            OnRemoteAudioTransportStats_rxKBitRate = rxKBitRate;
        }

        public bool OnRemoteAudioTransportStatsPassed(RtcConnection connection, uid_t remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate)
        {
            if (OnRemoteAudioTransportStats_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnRemoteAudioTransportStats_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnRemoteAudioTransportStats_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareUnsignedShort(OnRemoteAudioTransportStats_delay, delay) == false)
                return false;
            if (ParamsHelper.compareUnsignedShort(OnRemoteAudioTransportStats_lost, lost) == false)
                return false;
            if (ParamsHelper.compareUnsignedShort(OnRemoteAudioTransportStats_rxKBitRate, rxKBitRate) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRemoteVideoTransportStats_be_trigger = false;
        public RtcConnection OnRemoteVideoTransportStats_connection = null;
        public uid_t OnRemoteVideoTransportStats_remoteUid = 0;
        public UInt16 OnRemoteVideoTransportStats_delay = 0;
        public UInt16 OnRemoteVideoTransportStats_lost = 0;
        public UInt16 OnRemoteVideoTransportStats_rxKBitRate = 0;

        public override void OnRemoteVideoTransportStats(RtcConnection connection, uid_t remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate)
        {
            OnRemoteVideoTransportStats_be_trigger = true;
            OnRemoteVideoTransportStats_connection = connection;
            OnRemoteVideoTransportStats_remoteUid = remoteUid;
            OnRemoteVideoTransportStats_delay = delay;
            OnRemoteVideoTransportStats_lost = lost;
            OnRemoteVideoTransportStats_rxKBitRate = rxKBitRate;
        }

        public bool OnRemoteVideoTransportStatsPassed(RtcConnection connection, uid_t remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate)
        {
            if (OnRemoteVideoTransportStats_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnRemoteVideoTransportStats_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnRemoteVideoTransportStats_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareUnsignedShort(OnRemoteVideoTransportStats_delay, delay) == false)
                return false;
            if (ParamsHelper.compareUnsignedShort(OnRemoteVideoTransportStats_lost, lost) == false)
                return false;
            if (ParamsHelper.compareUnsignedShort(OnRemoteVideoTransportStats_rxKBitRate, rxKBitRate) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnConnectionStateChanged_be_trigger = false;
        public RtcConnection OnConnectionStateChanged_connection = null;
        public CONNECTION_STATE_TYPE OnConnectionStateChanged_state;
        public CONNECTION_CHANGED_REASON_TYPE OnConnectionStateChanged_reason;

        public override void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            OnConnectionStateChanged_be_trigger = true;
            OnConnectionStateChanged_connection = connection;
            OnConnectionStateChanged_state = state;
            OnConnectionStateChanged_reason = reason;
        }

        public bool OnConnectionStateChangedPassed(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            if (OnConnectionStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnConnectionStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.compareCONNECTION_STATE_TYPE(OnConnectionStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareCONNECTION_CHANGED_REASON_TYPE(OnConnectionStateChanged_reason, reason) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnWlAccMessage_be_trigger = false;
        public RtcConnection OnWlAccMessage_connection = null;
        public WLACC_MESSAGE_REASON OnWlAccMessage_reason;
        public WLACC_SUGGEST_ACTION OnWlAccMessage_action;
        public string OnWlAccMessage_wlAccMsg = null;

        public override void OnWlAccMessage(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            OnWlAccMessage_be_trigger = true;
            OnWlAccMessage_connection = connection;
            OnWlAccMessage_reason = reason;
            OnWlAccMessage_action = action;
            OnWlAccMessage_wlAccMsg = wlAccMsg;
        }

        public bool OnWlAccMessagePassed(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            if (OnWlAccMessage_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnWlAccMessage_connection, connection) == false)
                return false;
            if (ParamsHelper.compareWLACC_MESSAGE_REASON(OnWlAccMessage_reason, reason) == false)
                return false;
            if (ParamsHelper.compareWLACC_SUGGEST_ACTION(OnWlAccMessage_action, action) == false)
                return false;
            if (ParamsHelper.compareString(OnWlAccMessage_wlAccMsg, wlAccMsg) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnWlAccStats_be_trigger = false;
        public RtcConnection OnWlAccStats_connection = null;
        public WlAccStats OnWlAccStats_currentStats = null;
        public WlAccStats OnWlAccStats_averageStats = null;

        public override void OnWlAccStats(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
            OnWlAccStats_be_trigger = true;
            OnWlAccStats_connection = connection;
            OnWlAccStats_currentStats = currentStats;
            OnWlAccStats_averageStats = averageStats;
        }

        public bool OnWlAccStatsPassed(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
            if (OnWlAccStats_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnWlAccStats_connection, connection) == false)
                return false;
            if (ParamsHelper.compareWlAccStats(OnWlAccStats_currentStats, currentStats) == false)
                return false;
            if (ParamsHelper.compareWlAccStats(OnWlAccStats_averageStats, averageStats) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnNetworkTypeChanged_be_trigger = false;
        public RtcConnection OnNetworkTypeChanged_connection = null;
        public NETWORK_TYPE OnNetworkTypeChanged_type;

        public override void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)
        {
            OnNetworkTypeChanged_be_trigger = true;
            OnNetworkTypeChanged_connection = connection;
            OnNetworkTypeChanged_type = type;
        }

        public bool OnNetworkTypeChangedPassed(RtcConnection connection, NETWORK_TYPE type)
        {
            if (OnNetworkTypeChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnNetworkTypeChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.compareNETWORK_TYPE(OnNetworkTypeChanged_type, type) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnEncryptionError_be_trigger = false;
        public RtcConnection OnEncryptionError_connection = null;
        public ENCRYPTION_ERROR_TYPE OnEncryptionError_errorType;

        public override void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
            OnEncryptionError_be_trigger = true;
            OnEncryptionError_connection = connection;
            OnEncryptionError_errorType = errorType;
        }

        public bool OnEncryptionErrorPassed(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
            if (OnEncryptionError_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnEncryptionError_connection, connection) == false)
                return false;
            if (ParamsHelper.compareENCRYPTION_ERROR_TYPE(OnEncryptionError_errorType, errorType) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUploadLogResult_be_trigger = false;
        public RtcConnection OnUploadLogResult_connection = null;
        public string OnUploadLogResult_requestId = null;
        public bool OnUploadLogResult_success = false;
        public UPLOAD_ERROR_REASON OnUploadLogResult_reason;

        public override void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            OnUploadLogResult_be_trigger = true;
            OnUploadLogResult_connection = connection;
            OnUploadLogResult_requestId = requestId;
            OnUploadLogResult_success = success;
            OnUploadLogResult_reason = reason;
        }

        public bool OnUploadLogResultPassed(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            if (OnUploadLogResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUploadLogResult_connection, connection) == false)
                return false;
            if (ParamsHelper.compareString(OnUploadLogResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.compareBool(OnUploadLogResult_success, success) == false)
                return false;
            if (ParamsHelper.compareUPLOAD_ERROR_REASON(OnUploadLogResult_reason, reason) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserAccountUpdated_be_trigger = false;
        public RtcConnection OnUserAccountUpdated_connection = null;
        public uid_t OnUserAccountUpdated_remoteUid = 0;
        public string OnUserAccountUpdated_userAccount = null;

        public override void OnUserAccountUpdated(RtcConnection connection, uid_t remoteUid, string userAccount)
        {
            OnUserAccountUpdated_be_trigger = true;
            OnUserAccountUpdated_connection = connection;
            OnUserAccountUpdated_remoteUid = remoteUid;
            OnUserAccountUpdated_userAccount = userAccount;
        }

        public bool OnUserAccountUpdatedPassed(RtcConnection connection, uid_t remoteUid, string userAccount)
        {
            if (OnUserAccountUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnUserAccountUpdated_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnUserAccountUpdated_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.compareString(OnUserAccountUpdated_userAccount, userAccount) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnSnapshotTaken_be_trigger = false;
        public RtcConnection OnSnapshotTaken_connection = null;
        public uid_t OnSnapshotTaken_uid = 0;
        public string OnSnapshotTaken_filePath = null;
        public int OnSnapshotTaken_width = 0;
        public int OnSnapshotTaken_height = 0;
        public int OnSnapshotTaken_errCode = 0;

        public override void OnSnapshotTaken(RtcConnection connection, uid_t uid, string filePath, int width, int height, int errCode)
        {
            OnSnapshotTaken_be_trigger = true;
            OnSnapshotTaken_connection = connection;
            OnSnapshotTaken_uid = uid;
            OnSnapshotTaken_filePath = filePath;
            OnSnapshotTaken_width = width;
            OnSnapshotTaken_height = height;
            OnSnapshotTaken_errCode = errCode;
        }

        public bool OnSnapshotTakenPassed(RtcConnection connection, uid_t uid, string filePath, int width, int height, int errCode)
        {
            if (OnSnapshotTaken_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnSnapshotTaken_connection, connection) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnSnapshotTaken_uid, uid) == false)
                return false;
            if (ParamsHelper.compareString(OnSnapshotTaken_filePath, filePath) == false)
                return false;
            if (ParamsHelper.compareInt(OnSnapshotTaken_width, width) == false)
                return false;
            if (ParamsHelper.compareInt(OnSnapshotTaken_height, height) == false)
                return false;
            if (ParamsHelper.compareInt(OnSnapshotTaken_errCode, errCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////
        #endregion

        #region IRtcEngineEventHandler Start


        ///////////////////////////////////


        public bool OnProxyConnected_be_trigger = false;
        public string OnProxyConnected_channel = null;
        public uid_t OnProxyConnected_uid = 0;
        public PROXY_TYPE OnProxyConnected_proxyType = 0;
        public string OnProxyConnected_localProxyIp = null;
        public int OnProxyConnected_elapsed = 0;

        public override void OnProxyConnected(string channel, uid_t uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            OnProxyConnected_be_trigger = true;
            OnProxyConnected_channel = channel;
            OnProxyConnected_uid = uid;
            OnProxyConnected_proxyType = proxyType;
            OnProxyConnected_localProxyIp = localProxyIp;
            OnProxyConnected_elapsed = elapsed;
        }

        public bool OnProxyConnectedPassed(string channel, uid_t uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            if (OnProxyConnected_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnProxyConnected_channel, channel) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnProxyConnected_uid, uid) == false)
                return false;
            if (ParamsHelper.comparePROXY_TYPE(OnProxyConnected_proxyType, proxyType) == false)
                return false;
            if (ParamsHelper.compareString(OnProxyConnected_localProxyIp, localProxyIp) == false)
                return false;
            if (ParamsHelper.compareInt(OnProxyConnected_elapsed, elapsed) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnError_be_trigger = false;
        public int OnError_err = 0;
        public string OnError_msg = null;

        public override void OnError(int err, string msg)
        {
            OnError_be_trigger = true;
            OnError_err = err;
            OnError_msg = msg;
        }

        public bool OnErrorPassed(int err, string msg)
        {
            if (OnError_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnError_err, err) == false)
                return false;
            if (ParamsHelper.compareString(OnError_msg, msg) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnLastmileProbeResult_be_trigger = false;
        public LastmileProbeResult OnLastmileProbeResult_result = null;

        public override void OnLastmileProbeResult(LastmileProbeResult result)
        {
            OnLastmileProbeResult_be_trigger = true;
            OnLastmileProbeResult_result = result;
        }

        public bool OnLastmileProbeResultPassed(LastmileProbeResult result)
        {
            if (OnLastmileProbeResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareLastmileProbeResult(OnLastmileProbeResult_result, result) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioMixingPositionChanged_be_trigger = false;
        public long OnAudioMixingPositionChanged_position = 0;

        public override void OnAudioMixingPositionChanged(long position)
        {
            OnAudioMixingPositionChanged_be_trigger = true;
            OnAudioMixingPositionChanged_position = position;
        }

        public bool OnAudioMixingPositionChangedPassed(long position)
        {
            if (OnAudioMixingPositionChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareLong(OnAudioMixingPositionChanged_position, position) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioMixingFinished_be_trigger = false;

        public override void OnAudioMixingFinished() { OnAudioMixingFinished_be_trigger = true; }

        public bool OnAudioMixingFinishedPassed()
        {
            if (OnAudioMixingFinished_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioEffectFinished_be_trigger = false;
        public int OnAudioEffectFinished_soundId = 0;

        public override void OnAudioEffectFinished(int soundId)
        {
            OnAudioEffectFinished_be_trigger = true;
            OnAudioEffectFinished_soundId = soundId;
        }

        public bool OnAudioEffectFinishedPassed(int soundId)
        {
            if (OnAudioEffectFinished_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnAudioEffectFinished_soundId, soundId) == false)
                return false;

            return true;
        }


        ///////////////////////////////////


        public bool OnVideoDeviceStateChanged_be_trigger = false;
        public string OnVideoDeviceStateChanged_deviceId = null;
        public MEDIA_DEVICE_TYPE OnVideoDeviceStateChanged_deviceType ;
        public MEDIA_DEVICE_STATE_TYPE OnVideoDeviceStateChanged_deviceState;

        public override void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            OnVideoDeviceStateChanged_be_trigger = true;
            OnVideoDeviceStateChanged_deviceId = deviceId;
            OnVideoDeviceStateChanged_deviceType = deviceType;
            OnVideoDeviceStateChanged_deviceState = deviceState;
        }

        public bool OnVideoDeviceStateChangedPassed(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            if (OnVideoDeviceStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnVideoDeviceStateChanged_deviceId, deviceId) == false)
                return false;
            if (ParamsHelper.compareMEDIA_DEVICE_TYPE(OnVideoDeviceStateChanged_deviceType, deviceType) == false)
                return false;
            if (ParamsHelper.compareMEDIA_DEVICE_STATE_TYPE(OnVideoDeviceStateChanged_deviceState, deviceState) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUplinkNetworkInfoUpdated_be_trigger = false;
        public UplinkNetworkInfo OnUplinkNetworkInfoUpdated_info = null;

        public override void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
            OnUplinkNetworkInfoUpdated_be_trigger = true;
            OnUplinkNetworkInfoUpdated_info = info;
        }

        public bool OnUplinkNetworkInfoUpdatedPassed(UplinkNetworkInfo info)
        {
            if (OnUplinkNetworkInfoUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.compareUplinkNetworkInfo(OnUplinkNetworkInfoUpdated_info, info) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnDownlinkNetworkInfoUpdated_be_trigger = false;
        public DownlinkNetworkInfo OnDownlinkNetworkInfoUpdated_info = null;

        public override void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
            OnDownlinkNetworkInfoUpdated_be_trigger = true;
            OnDownlinkNetworkInfoUpdated_info = info;
        }

        public bool OnDownlinkNetworkInfoUpdatedPassed(DownlinkNetworkInfo info)
        {
            if (OnDownlinkNetworkInfoUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.compareDownlinkNetworkInfo(OnDownlinkNetworkInfoUpdated_info, info) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLastmileQuality_be_trigger = false;
        public int OnLastmileQuality_quality = 0;

        public override void OnLastmileQuality(int quality)
        {
            OnLastmileQuality_be_trigger = true;
            OnLastmileQuality_quality = quality;
        }

        public bool OnLastmileQualityPassed(int quality)
        {
            if (OnLastmileQuality_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnLastmileQuality_quality, quality) == false)
                return false;

            return true;
        }

        ///////////////////////////////////



        public bool OnLocalVideoStateChanged_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnLocalVideoStateChanged_source;
        public LOCAL_VIDEO_STREAM_STATE OnLocalVideoStateChanged_state;
        public LOCAL_VIDEO_STREAM_ERROR OnLocalVideoStateChanged_error;

        public override void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR error)
        {
            OnLocalVideoStateChanged_be_trigger = true;
            OnLocalVideoStateChanged_source = source;
            OnLocalVideoStateChanged_state = state;
            OnLocalVideoStateChanged_error = error;
        }

        public bool OnLocalVideoStateChangedPassed(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR error)
        {
            if (OnLocalVideoStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareVIDEO_SOURCE_TYPE(OnLocalVideoStateChanged_source, source) == false)
                return false;
            if (ParamsHelper.compareLOCAL_VIDEO_STREAM_STATE(OnLocalVideoStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareLOCAL_VIDEO_STREAM_ERROR(OnLocalVideoStateChanged_error, error) == false)
                return false;

            return true;
        }
        ///////////////////////////////////

        public bool OnApiCallExecuted_be_trigger = false;
        public int OnApiCallExecuted_err = 0;
        public string OnApiCallExecuted_api = null;
        public string OnApiCallExecuted_result = null;

        public override void OnApiCallExecuted(int err, string api, string result)
        {
            OnApiCallExecuted_be_trigger = true;
            OnApiCallExecuted_err = err;
            OnApiCallExecuted_api = api;
            OnApiCallExecuted_result = result;
        }

        public bool OnApiCallExecutedPassed(int err, string api, string result)
        {
            if (OnApiCallExecuted_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnApiCallExecuted_err, err) == false)
                return false;
            if (ParamsHelper.compareString(OnApiCallExecuted_api, api) == false)
                return false;
            if (ParamsHelper.compareString(OnApiCallExecuted_result, result) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnCameraReady_be_trigger = false;

        public override void OnCameraReady() { OnCameraReady_be_trigger = true; }

        public bool OnCameraReadyPassed()
        {
            if (OnCameraReady_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnCameraFocusAreaChanged_be_trigger = false;
        public int OnCameraFocusAreaChanged_x = 0;
        public int OnCameraFocusAreaChanged_y = 0;
        public int OnCameraFocusAreaChanged_width = 0;
        public int OnCameraFocusAreaChanged_height = 0;

        public override void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
            OnCameraFocusAreaChanged_be_trigger = true;
            OnCameraFocusAreaChanged_x = x;
            OnCameraFocusAreaChanged_y = y;
            OnCameraFocusAreaChanged_width = width;
            OnCameraFocusAreaChanged_height = height;
        }

        public bool OnCameraFocusAreaChangedPassed(int x, int y, int width, int height)
        {
            if (OnCameraFocusAreaChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnCameraFocusAreaChanged_x, x) == false)
                return false;
            if (ParamsHelper.compareInt(OnCameraFocusAreaChanged_y, y) == false)
                return false;
            if (ParamsHelper.compareInt(OnCameraFocusAreaChanged_width, width) == false)
                return false;
            if (ParamsHelper.compareInt(OnCameraFocusAreaChanged_height, height) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnCameraExposureAreaChanged_be_trigger = false;
        public int OnCameraExposureAreaChanged_x = 0;
        public int OnCameraExposureAreaChanged_y = 0;
        public int OnCameraExposureAreaChanged_width = 0;
        public int OnCameraExposureAreaChanged_height = 0;

        public override void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
            OnCameraExposureAreaChanged_be_trigger = true;
            OnCameraExposureAreaChanged_x = x;
            OnCameraExposureAreaChanged_y = y;
            OnCameraExposureAreaChanged_width = width;
            OnCameraExposureAreaChanged_height = height;
        }

        public bool OnCameraExposureAreaChangedPassed(int x, int y, int width, int height)
        {
            if (OnCameraExposureAreaChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnCameraExposureAreaChanged_x, x) == false)
                return false;
            if (ParamsHelper.compareInt(OnCameraExposureAreaChanged_y, y) == false)
                return false;
            if (ParamsHelper.compareInt(OnCameraExposureAreaChanged_width, width) == false)
                return false;
            if (ParamsHelper.compareInt(OnCameraExposureAreaChanged_height, height) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnFacePositionChanged_be_trigger = false;
        public int OnFacePositionChanged_imageWidth = 0;
        public int OnFacePositionChanged_imageHeight = 0;
        public Rectangle OnFacePositionChanged_vecRectangle = null;
        public int[] OnFacePositionChanged_vecDistance = null;
        public int OnFacePositionChanged_numFaces = 0;

        public override void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle vecRectangle, int[] vecDistance, int numFaces)
        {
            OnFacePositionChanged_be_trigger = true;
            OnFacePositionChanged_imageWidth = imageWidth;
            OnFacePositionChanged_imageHeight = imageHeight;
            OnFacePositionChanged_vecRectangle = vecRectangle;
            OnFacePositionChanged_vecDistance = vecDistance;
            OnFacePositionChanged_numFaces = numFaces;
        }

        public bool OnFacePositionChangedPassed(int imageWidth, int imageHeight, Rectangle vecRectangle, int[] vecDistance, int numFaces)
        {
            if (OnFacePositionChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnFacePositionChanged_imageWidth, imageWidth) == false)
                return false;
            if (ParamsHelper.compareInt(OnFacePositionChanged_imageHeight, imageHeight) == false)
                return false;
            if (ParamsHelper.compareRectangle(OnFacePositionChanged_vecRectangle, vecRectangle) == false)
                return false;
            if (ParamsHelper.compareIntArray(OnFacePositionChanged_vecDistance, vecDistance) == false)
                return false;
            if (ParamsHelper.compareInt(OnFacePositionChanged_numFaces, numFaces) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnVideoStopped_be_trigger = false;

        public override void OnVideoStopped() { OnVideoStopped_be_trigger = true; }

        public bool OnVideoStoppedPassed()
        {
            if (OnVideoStopped_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioMixingStateChanged_be_trigger = false;
        public AUDIO_MIXING_STATE_TYPE OnAudioMixingStateChanged_state;
        public AUDIO_MIXING_REASON_TYPE OnAudioMixingStateChanged_reason;

        public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
            OnAudioMixingStateChanged_be_trigger = true;
            OnAudioMixingStateChanged_state = state;
            OnAudioMixingStateChanged_reason = reason;
        }

        public bool OnAudioMixingStateChangedPassed(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
            if (OnAudioMixingStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareAUDIO_MIXING_STATE_TYPE(OnAudioMixingStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareAUDIO_MIXING_REASON_TYPE(OnAudioMixingStateChanged_reason, reason) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRhythmPlayerStateChanged_be_trigger = false;
        public RHYTHM_PLAYER_STATE_TYPE OnRhythmPlayerStateChanged_state;
        public RHYTHM_PLAYER_ERROR_TYPE OnRhythmPlayerStateChanged_errorCode;

        public override void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
            OnRhythmPlayerStateChanged_be_trigger = true;
            OnRhythmPlayerStateChanged_state = state;
            OnRhythmPlayerStateChanged_errorCode = errorCode;
        }

        public bool OnRhythmPlayerStateChangedPassed(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
            if (OnRhythmPlayerStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRHYTHM_PLAYER_STATE_TYPE(OnRhythmPlayerStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareRHYTHM_PLAYER_ERROR_TYPE(OnRhythmPlayerStateChanged_errorCode, errorCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnContentInspectResult_be_trigger = false;
        public CONTENT_INSPECT_RESULT OnContentInspectResult_result;

        public override void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
            OnContentInspectResult_be_trigger = true;
            OnContentInspectResult_result = result;
        }

        public bool OnContentInspectResultPassed(CONTENT_INSPECT_RESULT result)
        {
            if (OnContentInspectResult_be_trigger == false)
                return false;

            if (ParamsHelper.compareCONTENT_INSPECT_RESULT(OnContentInspectResult_result, result) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnAudioDeviceVolumeChanged_be_trigger = false;
        public MEDIA_DEVICE_TYPE OnAudioDeviceVolumeChanged_deviceType;
        public int OnAudioDeviceVolumeChanged_volume = 0;
        public bool OnAudioDeviceVolumeChanged_muted = false;

        public override void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
            OnAudioDeviceVolumeChanged_be_trigger = true;
            OnAudioDeviceVolumeChanged_deviceType = deviceType;
            OnAudioDeviceVolumeChanged_volume = volume;
            OnAudioDeviceVolumeChanged_muted = muted;
        }

        public bool OnAudioDeviceVolumeChangedPassed(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
            if (OnAudioDeviceVolumeChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareMEDIA_DEVICE_TYPE(OnAudioDeviceVolumeChanged_deviceType, deviceType) == false)
                return false;
            if (ParamsHelper.compareInt(OnAudioDeviceVolumeChanged_volume, volume) == false)
                return false;
            if (ParamsHelper.compareBool(OnAudioDeviceVolumeChanged_muted, muted) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRtmpStreamingStateChanged_be_trigger = false;
        public string OnRtmpStreamingStateChanged_url = null;
        public RTMP_STREAM_PUBLISH_STATE OnRtmpStreamingStateChanged_state;
        public RTMP_STREAM_PUBLISH_ERROR_TYPE OnRtmpStreamingStateChanged_errCode;

        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
            OnRtmpStreamingStateChanged_be_trigger = true;
            OnRtmpStreamingStateChanged_url = url;
            OnRtmpStreamingStateChanged_state = state;
            OnRtmpStreamingStateChanged_errCode = errCode;
        }

        public bool OnRtmpStreamingStateChangedPassed(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
            if (OnRtmpStreamingStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnRtmpStreamingStateChanged_url, url) == false)
                return false;
            if (ParamsHelper.compareRTMP_STREAM_PUBLISH_STATE(OnRtmpStreamingStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareRTMP_STREAM_PUBLISH_ERROR_TYPE(OnRtmpStreamingStateChanged_errCode, errCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRtmpStreamingEvent_be_trigger = false;
        public string OnRtmpStreamingEvent_url = null;
        public RTMP_STREAMING_EVENT OnRtmpStreamingEvent_eventCode;

        public override void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
            OnRtmpStreamingEvent_be_trigger = true;
            OnRtmpStreamingEvent_url = url;
            OnRtmpStreamingEvent_eventCode = eventCode;
        }

        public bool OnRtmpStreamingEventPassed(string url, RTMP_STREAMING_EVENT eventCode)
        {
            if (OnRtmpStreamingEvent_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnRtmpStreamingEvent_url, url) == false)
                return false;
            if (ParamsHelper.compareRTMP_STREAMING_EVENT(OnRtmpStreamingEvent_eventCode, eventCode) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnTranscodingUpdated_be_trigger = false;

        public override void OnTranscodingUpdated() { OnTranscodingUpdated_be_trigger = true; }

        public bool OnTranscodingUpdatedPassed()
        {
            if (OnTranscodingUpdated_be_trigger == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioRoutingChanged_be_trigger = false;
        public int OnAudioRoutingChanged_routing = 0;

        public override void OnAudioRoutingChanged(int routing)
        {
            OnAudioRoutingChanged_be_trigger = true;
            OnAudioRoutingChanged_routing = routing;
        }

        public bool OnAudioRoutingChangedPassed(int routing)
        {
            if (OnAudioRoutingChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnAudioRoutingChanged_routing, routing) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnChannelMediaRelayStateChanged_be_trigger = false;
        public int OnChannelMediaRelayStateChanged_state = 0;
        public int OnChannelMediaRelayStateChanged_code = 0;

        public override void OnChannelMediaRelayStateChanged(int state, int code)
        {
            OnChannelMediaRelayStateChanged_be_trigger = true;
            OnChannelMediaRelayStateChanged_state = state;
            OnChannelMediaRelayStateChanged_code = code;
        }

        public bool OnChannelMediaRelayStateChangedPassed(int state, int code)
        {
            if (OnChannelMediaRelayStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnChannelMediaRelayStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareInt(OnChannelMediaRelayStateChanged_code, code) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnChannelMediaRelayEvent_be_trigger = false;
        public int OnChannelMediaRelayEvent_code = 0;

        public override void OnChannelMediaRelayEvent(int code)
        {
            OnChannelMediaRelayEvent_be_trigger = true;
            OnChannelMediaRelayEvent_code = code;
        }

        public bool OnChannelMediaRelayEventPassed(int code)
        {
            if (OnChannelMediaRelayEvent_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt(OnChannelMediaRelayEvent_code, code) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLocalPublishFallbackToAudioOnly_be_trigger = false;
        public bool OnLocalPublishFallbackToAudioOnly_isFallbackOrRecover = false;

        public override void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
            OnLocalPublishFallbackToAudioOnly_be_trigger = true;
            OnLocalPublishFallbackToAudioOnly_isFallbackOrRecover = isFallbackOrRecover;
        }

        public bool OnLocalPublishFallbackToAudioOnlyPassed(bool isFallbackOrRecover)
        {
            if (OnLocalPublishFallbackToAudioOnly_be_trigger == false)
                return false;

            if (ParamsHelper.compareBool(OnLocalPublishFallbackToAudioOnly_isFallbackOrRecover, isFallbackOrRecover) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRemoteSubscribeFallbackToAudioOnly_be_trigger = false;
        public uid_t OnRemoteSubscribeFallbackToAudioOnly_uid = 0;
        public bool OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover = false;

        public override void OnRemoteSubscribeFallbackToAudioOnly(uid_t uid, bool isFallbackOrRecover)
        {
            OnRemoteSubscribeFallbackToAudioOnly_be_trigger = true;
            OnRemoteSubscribeFallbackToAudioOnly_uid = uid;
            OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover = isFallbackOrRecover;
        }

        public bool OnRemoteSubscribeFallbackToAudioOnlyPassed(uid_t uid, bool isFallbackOrRecover)
        {
            if (OnRemoteSubscribeFallbackToAudioOnly_be_trigger == false)
                return false;

            if (ParamsHelper.compareUid_t(OnRemoteSubscribeFallbackToAudioOnly_uid, uid) == false)
                return false;
            if (ParamsHelper.compareBool(OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover, isFallbackOrRecover) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnPermissionError_be_trigger = false;
        public PERMISSION_TYPE OnPermissionError_permissionType;

        public override void OnPermissionError(PERMISSION_TYPE permissionType)
        {
            OnPermissionError_be_trigger = true;
            OnPermissionError_permissionType = permissionType;
        }

        public bool OnPermissionErrorPassed(PERMISSION_TYPE permissionType)
        {
            if (OnPermissionError_be_trigger == false)
                return false;

            if (ParamsHelper.comparePERMISSION_TYPE(OnPermissionError_permissionType, permissionType) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnLocalUserRegistered_be_trigger = false;
        public uid_t OnLocalUserRegistered_uid = 0;
        public string OnLocalUserRegistered_userAccount = null;

        public override void OnLocalUserRegistered(uid_t uid, string userAccount)
        {
            OnLocalUserRegistered_be_trigger = true;
            OnLocalUserRegistered_uid = uid;
            OnLocalUserRegistered_userAccount = userAccount;
        }

        public bool OnLocalUserRegisteredPassed(uid_t uid, string userAccount)
        {
            if (OnLocalUserRegistered_be_trigger == false)
                return false;

            if (ParamsHelper.compareUid_t(OnLocalUserRegistered_uid, uid) == false)
                return false;
            if (ParamsHelper.compareString(OnLocalUserRegistered_userAccount, userAccount) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnUserInfoUpdated_be_trigger = false;
        public uid_t OnUserInfoUpdated_uid = 0;
        public UserInfo OnUserInfoUpdated_info = null;

        public override void OnUserInfoUpdated(uid_t uid, UserInfo info)
        {
            OnUserInfoUpdated_be_trigger = true;
            OnUserInfoUpdated_uid = uid;
            OnUserInfoUpdated_info = info;
        }

        public bool OnUserInfoUpdatedPassed(uid_t uid, UserInfo info)
        {
            if (OnUserInfoUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.compareUid_t(OnUserInfoUpdated_uid, uid) == false)
                return false;
            if (ParamsHelper.compareUserInfo(OnUserInfoUpdated_info, info) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnAudioSubscribeStateChanged_be_trigger = false;
        public string OnAudioSubscribeStateChanged_channel = null;
        public uid_t OnAudioSubscribeStateChanged_uid = 0;
        public STREAM_SUBSCRIBE_STATE OnAudioSubscribeStateChanged_oldState;
        public STREAM_SUBSCRIBE_STATE OnAudioSubscribeStateChanged_newState;
        public int OnAudioSubscribeStateChanged_elapseSinceLastState = 0;

        public override void OnAudioSubscribeStateChanged(string channel, uid_t uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            OnAudioSubscribeStateChanged_be_trigger = true;
            OnAudioSubscribeStateChanged_channel = channel;
            OnAudioSubscribeStateChanged_uid = uid;
            OnAudioSubscribeStateChanged_oldState = oldState;
            OnAudioSubscribeStateChanged_newState = newState;
            OnAudioSubscribeStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnAudioSubscribeStateChangedPassed(string channel, uid_t uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (OnAudioSubscribeStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnAudioSubscribeStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnAudioSubscribeStateChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.compareSTREAM_SUBSCRIBE_STATE(OnAudioSubscribeStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.compareSTREAM_SUBSCRIBE_STATE(OnAudioSubscribeStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.compareInt(OnAudioSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnVideoSubscribeStateChanged_be_trigger = false;
        public string OnVideoSubscribeStateChanged_channel = null;
        public uid_t OnVideoSubscribeStateChanged_uid = 0;
        public STREAM_SUBSCRIBE_STATE OnVideoSubscribeStateChanged_oldState;
        public STREAM_SUBSCRIBE_STATE OnVideoSubscribeStateChanged_newState;
        public int OnVideoSubscribeStateChanged_elapseSinceLastState = 0;

        public override void OnVideoSubscribeStateChanged(string channel, uid_t uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            OnVideoSubscribeStateChanged_be_trigger = true;
            OnVideoSubscribeStateChanged_channel = channel;
            OnVideoSubscribeStateChanged_uid = uid;
            OnVideoSubscribeStateChanged_oldState = oldState;
            OnVideoSubscribeStateChanged_newState = newState;
            OnVideoSubscribeStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnVideoSubscribeStateChangedPassed(string channel, uid_t uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (OnVideoSubscribeStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnVideoSubscribeStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnVideoSubscribeStateChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.compareSTREAM_SUBSCRIBE_STATE(OnVideoSubscribeStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.compareSTREAM_SUBSCRIBE_STATE(OnVideoSubscribeStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.compareInt(OnVideoSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnAudioPublishStateChanged_be_trigger = false;
        public string OnAudioPublishStateChanged_channel = null;
        public STREAM_PUBLISH_STATE OnAudioPublishStateChanged_oldState;
        public STREAM_PUBLISH_STATE OnAudioPublishStateChanged_newState;
        public int OnAudioPublishStateChanged_elapseSinceLastState = 0;

        public override void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            OnAudioPublishStateChanged_be_trigger = true;
            OnAudioPublishStateChanged_channel = channel;
            OnAudioPublishStateChanged_oldState = oldState;
            OnAudioPublishStateChanged_newState = newState;
            OnAudioPublishStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnAudioPublishStateChangedPassed(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            if (OnAudioPublishStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnAudioPublishStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.compareSTREAM_PUBLISH_STATE(OnAudioPublishStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.compareSTREAM_PUBLISH_STATE(OnAudioPublishStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.compareInt(OnAudioPublishStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnVideoPublishStateChanged_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnVideoPublishStateChanged_source;
        public string OnVideoPublishStateChanged_channel = null;
        public STREAM_PUBLISH_STATE OnVideoPublishStateChanged_oldState;
        public STREAM_PUBLISH_STATE OnVideoPublishStateChanged_newState;
        public int OnVideoPublishStateChanged_elapseSinceLastState = 0;

        public override void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState,
                                                        int elapseSinceLastState)
        {
            OnVideoPublishStateChanged_be_trigger = true;
            OnVideoPublishStateChanged_source = source;
            OnVideoPublishStateChanged_channel = channel;
            OnVideoPublishStateChanged_oldState = oldState;
            OnVideoPublishStateChanged_newState = newState;
            OnVideoPublishStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnVideoPublishStateChangedPassed(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState,
                                                     int elapseSinceLastState)
        {
            if (OnVideoPublishStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareVIDEO_SOURCE_TYPE(OnVideoPublishStateChanged_source, source) == false)
                return false;
            if (ParamsHelper.compareString(OnVideoPublishStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.compareSTREAM_PUBLISH_STATE(OnVideoPublishStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.compareSTREAM_PUBLISH_STATE(OnVideoPublishStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.compareInt(OnVideoPublishStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnExtensionEvent_be_trigger = false;
        public string OnExtensionEvent_provider = null;
        public string OnExtensionEvent_extension = null;
        public string OnExtensionEvent_key = null;
        public string OnExtensionEvent_value = null;

        public override void OnExtensionEvent(string provider, string extension, string key, string value)
        {
            OnExtensionEvent_be_trigger = true;
            OnExtensionEvent_provider = provider;
            OnExtensionEvent_extension = extension;
            OnExtensionEvent_key = key;
            OnExtensionEvent_value = value;
        }

        public bool OnExtensionEventPassed(string provider, string extension, string key, string value)
        {
            if (OnExtensionEvent_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnExtensionEvent_provider, provider) == false)
                return false;
            if (ParamsHelper.compareString(OnExtensionEvent_extension, extension) == false)
                return false;
            if (ParamsHelper.compareString(OnExtensionEvent_key, key) == false)
                return false;
            if (ParamsHelper.compareString(OnExtensionEvent_value, value) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnExtensionStarted_be_trigger = false;
        public string OnExtensionStarted_provider = null;
        public string OnExtensionStarted_extension = null;

        public override void OnExtensionStarted(string provider, string extension)
        {
            OnExtensionStarted_be_trigger = true;
            OnExtensionStarted_provider = provider;
            OnExtensionStarted_extension = extension;
        }

        public bool OnExtensionStartedPassed(string provider, string extension)
        {
            if (OnExtensionStarted_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnExtensionStarted_provider, provider) == false)
                return false;
            if (ParamsHelper.compareString(OnExtensionStarted_extension, extension) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnExtensionStopped_be_trigger = false;
        public string OnExtensionStopped_provider = null;
        public string OnExtensionStopped_extension = null;

        public override void OnExtensionStopped(string provider, string extension)
        {
            OnExtensionStopped_be_trigger = true;
            OnExtensionStopped_provider = provider;
            OnExtensionStopped_extension = extension;
        }

        public bool OnExtensionStoppedPassed(string provider, string extension)
        {
            if (OnExtensionStopped_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnExtensionStopped_provider, provider) == false)
                return false;
            if (ParamsHelper.compareString(OnExtensionStopped_extension, extension) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnExtensionError_be_trigger = false;
        public string OnExtensionError_provider = null;
        public string OnExtensionError_extension = null;
        public int OnExtensionError_error = 0;
        public string OnExtensionError_message = null;

        public override void OnExtensionError(string provider, string extension, int error, string message)
        {
            OnExtensionError_be_trigger = true;
            OnExtensionError_provider = provider;
            OnExtensionError_extension = extension;
            OnExtensionError_error = error;
            OnExtensionError_message = message;
        }

        public bool OnExtensionErrorPassed(string provider, string extension, int error, string message)
        {
            if (OnExtensionError_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnExtensionError_provider, provider) == false)
                return false;
            if (ParamsHelper.compareString(OnExtensionError_extension, extension) == false)
                return false;
            if (ParamsHelper.compareInt(OnExtensionError_error, error) == false)
                return false;
            if (ParamsHelper.compareString(OnExtensionError_message, message) == false)
                return false;

            return true;
        }

        ///////////////////////////////////
        #endregion


    }
}
