using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The SDK uses the IRtcEngineEventHandler interface to send event notifications to your app. Your app can get those notifications through methods that inherit this interface.
    /// </summary>
    ///
    public abstract class IRtcEngineEventHandlerS : IRtcEngineEventHandlerBase
    {

        #region terra IRtcEngineEventHandlerS
        public virtual void OnProxyConnected(string channel, string userAccount, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
        }

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(string userAccount, bool isFallbackOrRecover)
        {
        }

        public virtual void OnAudioSubscribeStateChanged(string channel, string userAccount, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoSubscribeStateChanged(string channel, string userAccount, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnLocalVideoTranscoderError(TranscodingVideoStreamS streamS, VIDEO_TRANSCODER_ERROR error)
        {
        }

        public virtual void OnJoinChannelSuccess(RtcConnectionS connectionS, int elapsed)
        {
        }

        public virtual void OnRejoinChannelSuccess(RtcConnectionS connectionS, int elapsed)
        {
        }

        public virtual void OnAudioVolumeIndication(RtcConnectionS connectionS, AudioVolumeInfoS[] speakersS, uint speakerNumber, int totalVolume)
        {
        }

        public virtual void OnLeaveChannel(RtcConnectionS connectionS, RtcStats stats)
        {
        }

        public virtual void OnRtcStats(RtcConnectionS connectionS, RtcStats stats)
        {
        }

        public virtual void OnNetworkQuality(RtcConnectionS connectionS, string remoteUserAccount, int txQuality, int rxQuality)
        {
        }

        public virtual void OnIntraRequestReceived(RtcConnectionS connectionS)
        {
        }

        public virtual void OnFirstLocalVideoFramePublished(RtcConnectionS connectionS, int elapsed)
        {
        }

        public virtual void OnFirstRemoteVideoDecoded(RtcConnectionS connectionS, string remoteUserAccount, int width, int height, int elapsed)
        {
        }

        public virtual void OnVideoSizeChanged(RtcConnectionS connectionS, VIDEO_SOURCE_TYPE sourceType, string userAccount, int width, int height, int rotation)
        {
        }

        public virtual void OnLocalVideoStateChanged(RtcConnectionS connectionS, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
        }

        public virtual void OnRemoteVideoStateChanged(RtcConnectionS connectionS, string userAccount, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnFirstRemoteVideoFrame(RtcConnectionS connectionS, string userAccount, int width, int height, int elapsed)
        {
        }

        public virtual void OnUserJoined(RtcConnectionS connectionS, string userAccount, int elapsed)
        {
        }

        public virtual void OnUserOffline(RtcConnectionS connectionS, string userAccount, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        public virtual void OnUserMuteAudio(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
        }

        public virtual void OnUserMuteVideo(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
        }

        public virtual void OnUserEnableVideo(RtcConnectionS connectionS, string remoteUserAccount, bool enabled)
        {
        }

        public virtual void OnUserStateChanged(RtcConnectionS connectionS, string remoteUserAccount, uint state)
        {
        }

        public virtual void OnLocalAudioStats(RtcConnectionS connectionS, LocalAudioStats stats)
        {
        }

        public virtual void OnRemoteAudioStats(RtcConnectionS connectionS, RemoteAudioStatsS statsS)
        {
        }

        public virtual void OnLocalVideoStats(RtcConnectionS connectionS, LocalVideoStatsS statsS)
        {
        }

        public virtual void OnRemoteVideoStats(RtcConnectionS connectionS, RemoteVideoStatsS statsS)
        {
        }

        public virtual void OnConnectionLost(RtcConnectionS connectionS)
        {
        }

        public virtual void OnConnectionBanned(RtcConnectionS connectionS)
        {
        }

        public virtual void OnStreamMessage(RtcConnectionS connectionS, string remoteUserAccount, int streamId, byte[] data, ulong length, ulong sentTs)
        {
        }

        public virtual void OnStreamMessageError(RtcConnectionS connectionS, string remoteUserAccount, int streamId, int code, int missed, int cached)
        {
        }

        public virtual void OnRequestToken(RtcConnectionS connectionS)
        {
        }

        public virtual void OnLicenseValidationFailure(RtcConnectionS connectionS, LICENSE_ERROR_TYPE reason)
        {
        }

        public virtual void OnTokenPrivilegeWillExpire(RtcConnectionS connectionS, string token)
        {
        }

        public virtual void OnFirstLocalAudioFramePublished(RtcConnectionS connectionS, int elapsed)
        {
        }

        public virtual void OnLocalAudioStateChanged(RtcConnectionS connectionS, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
        }

        public virtual void OnRemoteAudioStateChanged(RtcConnectionS connectionS, string remoteUserAccount, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnActiveSpeaker(RtcConnectionS connectionS, string userAccount)
        {
        }

        public virtual void OnClientRoleChanged(RtcConnectionS connectionS, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
        }

        public virtual void OnClientRoleChangeFailed(RtcConnectionS connectionS, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
        }

        public virtual void OnConnectionStateChanged(RtcConnectionS connectionS, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        public virtual void OnWlAccMessage(RtcConnectionS connectionS, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
        }

        public virtual void OnWlAccStats(RtcConnectionS connectionS, WlAccStats currentStats, WlAccStats averageStats)
        {
        }

        public virtual void OnNetworkTypeChanged(RtcConnectionS connectionS, NETWORK_TYPE type)
        {
        }

        public virtual void OnEncryptionError(RtcConnectionS connectionS, ENCRYPTION_ERROR_TYPE errorType)
        {
        }

        public virtual void OnUploadLogResult(RtcConnectionS connectionS, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
        }

        public virtual void OnSnapshotTaken(RtcConnectionS connectionS, string userAccount, string filePath, int width, int height, int errCode)
        {
        }

        public virtual void OnVideoRenderingTracingResult(RtcConnectionS connectionS, string userAccount, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
        }

        public virtual void OnSetRtmFlagResult(RtcConnectionS connectionS, int code)
        {
        }
        #endregion terra IRtcEngineEventHandlerS

    };
}