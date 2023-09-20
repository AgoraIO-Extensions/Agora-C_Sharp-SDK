using System;

namespace Agora.Rtc
{
    /* class_irtcengineeventhandler */
    public abstract class IRtcEngineEventHandler
    {

#region terra IRtcEngineEventHandler

        public virtual void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
        }

        public virtual void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
        }

        public virtual void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
        }

        public virtual void OnError(int err, string msg)
        {
        }

        public virtual void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
        }

        public virtual void OnLastmileProbeResult(LastmileProbeResult result)
        {
        }

        public virtual void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
        }

        public virtual void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
        }

        public virtual void OnRtcStats(RtcConnection connection, RtcStats stats)
        {
        }

        public virtual void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        public virtual void OnAudioMixingPositionChanged(long position)
        {
        }

        public virtual void OnAudioMixingFinished()
        {
        }

        public virtual void OnAudioEffectFinished(int soundId)
        {
        }

        public virtual void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        public virtual void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
        }

        public virtual void OnIntraRequestReceived(RtcConnection connection)
        {
        }

        public virtual void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
        }

        public virtual void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
        }

        public virtual void OnLastmileQuality(int quality)
        {
        }

        public virtual void OnFirstLocalVideoFrame(VIDEO_SOURCE_TYPE source, int width, int height, int elapsed)
        {
        }

        public virtual void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)
        {
        }

        public virtual void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
        }

        public virtual void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
        }

        public virtual void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR error)
        {
        }

        public virtual void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
        }

        public virtual void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
        }

        public virtual void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
        }

        public virtual void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        public virtual void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)
        {
        }

        public virtual void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
        }

        public virtual void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
        }

        public virtual void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
        }

        public virtual void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
        }

        public virtual void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)
        {
        }

        public virtual void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
        }

        public virtual void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
        }

        public virtual void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
        }

        public virtual void OnCameraReady()
        {
        }

        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
        }

        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
        }

        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle[] vecRectangle, int[] vecDistance, int numFaces)
        {
        }

        public virtual void OnVideoStopped()
        {
        }

        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
        }

        public virtual void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
        }

        public virtual void OnConnectionLost(RtcConnection connection)
        {
        }

        public virtual void OnConnectionInterrupted(RtcConnection connection)
        {
        }

        public virtual void OnConnectionBanned(RtcConnection connection)
        {
        }

        public virtual void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
        }

        public virtual void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
        }

        public virtual void OnRequestToken(RtcConnection connection)
        {
        }

        public virtual void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
        {
        }

        public virtual void OnLicenseValidationFailure(RtcConnection connection, LICENSE_ERROR_TYPE reason)
        {
        }

        public virtual void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)
        {
        }

        public virtual void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)
        {
        }

        public virtual void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)
        {
        }

        public virtual void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
        }

        public virtual void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnActiveSpeaker(RtcConnection connection, uint uid)
        {
        }

        public virtual void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
        }

        public virtual void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
        }

        public virtual void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
        }

        public virtual void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
        }

        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
        }

        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
        }

        public virtual void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        public virtual void OnTranscodingUpdated()
        {
        }

        public virtual void OnAudioRoutingChanged(int routing)
        {
        }

        public virtual void OnChannelMediaRelayStateChanged(int state, int code)
        {
        }

        public virtual void OnChannelMediaRelayEvent(int code)
        {
        }

        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
        }

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
        }

        public virtual void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        public virtual void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        public virtual void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        public virtual void OnWlAccMessage(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
        }

        public virtual void OnWlAccStats(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
        }

        public virtual void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)
        {
        }

        public virtual void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
        }

        public virtual void OnPermissionError(PERMISSION_TYPE permissionType)
        {
        }

        public virtual void OnLocalUserRegistered(uint uid, string userAccount)
        {
        }

        public virtual void OnUserInfoUpdated(uint uid, UserInfo info)
        {
        }

        public virtual void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
        }

        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnExtensionEvent(string provider, string extension, string key, string value)
        {
        }

        public virtual void OnExtensionStarted(string provider, string extension)
        {
        }

        public virtual void OnExtensionStopped(string provider, string extension)
        {
        }

        public virtual void OnExtensionError(string provider, string extension, int error, string message)
        {
        }

        public virtual void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string userAccount)
        {
        }

        public virtual void OnLocalVideoTranscoderError(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
        }

        public virtual void OnVideoRenderingTracingResult(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
        }
#endregion terra IRtcEngineEventHandler

#region terra IDirectCdnStreamingEventHandler

        public virtual void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
        {
        }

        public virtual void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
        {
        }
#endregion terra IDirectCdnStreamingEventHandler
    };
}