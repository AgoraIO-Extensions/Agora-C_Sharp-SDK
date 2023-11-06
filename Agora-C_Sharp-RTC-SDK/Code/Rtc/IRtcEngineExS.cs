#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.Int64;
using track_id_t = System.UInt32;
namespace Agora.Rtc
{

    public abstract class IRtcEngineExS : IRtcEngineS
    {

        #region terra IRtcEngineExS
        public abstract int JoinChannelEx(string token, RtcConnectionS connectionS, ChannelMediaOptions options);

        public abstract int LeaveChannelEx(RtcConnectionS connectionS);

        public abstract int LeaveChannelEx(RtcConnectionS connectionS, LeaveChannelOptions options);

        public abstract int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnectionS connectionS);

        public abstract int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnectionS connectionS);

        public abstract int SetupRemoteVideoEx(VideoCanvasS canvas, RtcConnectionS connectionS);

        public abstract int MuteRemoteAudioStreamEx(string userAccount, bool mute, RtcConnectionS connectionS);

        public abstract int MuteRemoteVideoStreamEx(string userAccount, bool mute, RtcConnectionS connectionS);

        public abstract int SetRemoteVideoStreamTypeEx(string userAccount, VIDEO_STREAM_TYPE streamType, RtcConnectionS connectionS);

        public abstract int MuteLocalAudioStreamEx(bool mute, RtcConnectionS connectionS);

        public abstract int MuteLocalVideoStreamEx(bool mute, RtcConnectionS connectionS);

        public abstract int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnectionS connectionS);

        public abstract int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnectionS connectionS);

        public abstract int SetSubscribeAudioBlocklistEx(string[] userAccountList, int userAccountNumber, RtcConnectionS connectionS);

        public abstract int SetSubscribeAudioAllowlistEx(string[] userAccountList, int userAccountNumber, RtcConnectionS connectionS);

        public abstract int SetSubscribeVideoBlocklistEx(string[] userAccountList, int userAccountNumber, RtcConnectionS connectionS);

        public abstract int SetSubscribeVideoAllowlistEx(string[] userAccountList, int userAccountNumber, RtcConnectionS connectionS);

        public abstract int SetRemoteVideoSubscriptionOptionsEx(string userAccount, VideoSubscriptionOptions options, RtcConnectionS connectionS);

        public abstract int SetRemoteVoicePositionEx(string userAccount, double pan, double gain, RtcConnectionS connectionS);

        public abstract int SetRemoteUserSpatialAudioParamsEx(string userAccount, SpatialAudioParams @params, RtcConnectionS connectionS);

        public abstract int SetRemoteRenderModeEx(string userAccount, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnectionS connectionS);

        public abstract int EnableLoopbackRecordingEx(RtcConnectionS connectionS, bool enabled, string deviceName = "");

        public abstract int AdjustRecordingSignalVolumeEx(int volume, RtcConnectionS connectionS);

        public abstract int MuteRecordingSignalEx(bool mute, RtcConnectionS connectionS);

        public abstract int AdjustUserPlaybackSignalVolumeEx(string userAccount, int volume, RtcConnectionS connectionS);

        public abstract CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnectionS connectionS);

        public abstract int EnableEncryptionEx(RtcConnectionS connectionS, bool enabled, EncryptionConfig config);

        public abstract int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnectionS connectionS);

        public abstract int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnectionS connectionS);

        public abstract int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnectionS connectionS);

        public abstract int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnectionS connectionS);

        public abstract int ClearVideoWatermarkEx(RtcConnectionS connectionS);

        public abstract int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnectionS connectionS);

        public abstract int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnectionS connectionS);

        public abstract int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnectionS connectionS);

        public abstract int StartRtmpStreamWithTranscodingEx(string url, LiveTranscodingS transcodingS, RtcConnectionS connectionS);

        public abstract int UpdateRtmpTranscodingEx(LiveTranscodingS transcodingS, RtcConnectionS connectionS);

        public abstract int StopRtmpStreamEx(string url, RtcConnectionS connectionS);

        public abstract int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfigurationS configurationS, RtcConnectionS connectionS);

        public abstract int StopChannelMediaRelayEx(RtcConnectionS connectionS);

        public abstract int PauseAllChannelMediaRelayEx(RtcConnectionS connectionS);

        public abstract int ResumeAllChannelMediaRelayEx(RtcConnectionS connectionS);

        public abstract int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnectionS connectionS);

        public abstract int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnectionS connectionS);

        public abstract int SetHighPriorityUserListEx(string[] userAccountList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnectionS connectionS);

        public abstract int TakeSnapshotEx(RtcConnectionS connectionS, string userAccount, string filePath);

        public abstract int StartMediaRenderingTracingEx(RtcConnectionS connectionS);

        public abstract int SetParametersEx(RtcConnectionS connectionS, string parameters);
        #endregion terra IRtcEngineExS

        public abstract int SetParametersEx(RtcConnectionS connection, string key, object value);
    };

}