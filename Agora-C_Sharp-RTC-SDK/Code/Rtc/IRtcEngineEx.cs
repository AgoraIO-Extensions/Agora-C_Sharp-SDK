#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.Int64;
using track_id_t = System.UInt32;
namespace Agora.Rtc
{

    public abstract class IRtcEngineEx : IRtcEngine
    {

        #region terra IRtcEngineEx


        public abstract int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options);


        public abstract int LeaveChannelEx(RtcConnection connection);


        public abstract int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options);


        public abstract int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection);


        public abstract int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection);


        public abstract int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection);


        public abstract int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection);


        public abstract int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection);


        public abstract int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection);


        public abstract int MuteLocalAudioStreamEx(bool mute, RtcConnection connection);


        public abstract int MuteLocalVideoStreamEx(bool mute, RtcConnection connection);


        public abstract int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection);


        public abstract int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection);


        public abstract int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);


        public abstract int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);


        public abstract int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);


        public abstract int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);


        public abstract int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection);


        public abstract int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection);


        public abstract int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams @params, RtcConnection connection);


        public abstract int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection);


        public abstract int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName = "");


        public abstract int AdjustRecordingSignalVolumeEx(int volume, RtcConnection connection);


        public abstract int MuteRecordingSignalEx(bool mute, RtcConnection connection);


        public abstract int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection);


        public abstract CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection);


        public abstract int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config);


        public abstract int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection);


        public abstract int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection);


        public abstract int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection);


        public abstract int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection);


        public abstract int ClearVideoWatermarkEx(RtcConnection connection);


        public abstract int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection);


        public abstract int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection);


        public abstract int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection);


        public abstract int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection);


        public abstract int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection);


        public abstract int StopRtmpStreamEx(string url, RtcConnection connection);


        public abstract int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelayEx` instead.")]
        public abstract int StartChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        [Obsolete("v4.2.0 Use `startOrUpdateChannelMediaRelayEx` instead.")]
        public abstract int UpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);


        public abstract int StopChannelMediaRelayEx(RtcConnection connection);


        public abstract int PauseAllChannelMediaRelayEx(RtcConnection connection);


        public abstract int ResumeAllChannelMediaRelayEx(RtcConnection connection);


        public abstract int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection);


        public abstract int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection);

        [Obsolete("v4.2.0. This method is deprecated. Use setDualStreamModeEx instead")]
        public abstract int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection);


        public abstract int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection);


        public abstract int SetHighPriorityUserListEx(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnection connection);


        public abstract int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath);


        public abstract int EnableContentInspectEx(bool enabled, ContentInspectConfig config, RtcConnection connection);


        public abstract int StartMediaRenderingTracingEx(RtcConnection connection);


        public abstract int SetParametersEx(RtcConnection connection, string parameters);
        #endregion terra IRtcEngineEx

        public abstract int SetParametersEx(RtcConnection connection, string key, object value);
    };

}