using System;

namespace agora.rtc
{
    public abstract class IAgoraRtcEngineEventHandler
    {
        public virtual void OnJoinChannelSuccess(RtcConnection connection, int elapsed) { } //exDone

        public virtual void OnRejoinChannelSuccess(RtcConnection connection, int elapsed) { } //exDone

        public virtual void OnWarning(int warn, string msg) { } //handleDone

        public virtual void OnError(int err, string msg) { } //handleDone

        public virtual void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, UInt16 delay, UInt16 lost) { } //exDone

        public virtual void OnLastmileProbeResult(LastmileProbeResult result) { }//handleDone

        public virtual void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume) { }//exDone

        public virtual void OnLeaveChannel(RtcConnection connection, RtcStats stats) { } //exDone

        public virtual void OnRtcStats(RtcConnection connection, RtcStats stats) { }//exDone

        //todo fix with dcg
        public virtual void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState) { } //handleDone

        [Obsolete("__deprecated")]
        public virtual void OnAudioMixingFinished() { } //handleDone

        public virtual void OnAudioEffectFinished(int soundId) { }//handleDone

        //todo fix with dcg
        public virtual void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState) { }//handleDone

        //todo fix with dcg
        public virtual void OnMediaDeviceChanged(MEDIA_DEVICE_TYPE deviceType) { }//handleDone

        public virtual void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality) { } //exDone

        public virtual void OnIntraRequestReceived(RtcConnection connection) { }//exDone

        public virtual void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info) { }//handleDone

        public virtual void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info) { }//handleDonew

        public virtual void OnLastmileQuality(int quality) { }//handleDone

        public virtual void OnFirstLocalVideoFrame(RtcConnection connection, int width, int height, int elapsed) { }//exDone

        public virtual void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed) { }//exDone

        public virtual void OnVideoSourceFrameSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, int width, int height) { }//exDone

        public virtual void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed) { }//exDone

        public virtual void OnVideoSizeChanged(RtcConnection connection, uint uid, int width, int height, int rotation) { }//exDone

        //todo new add in dcg
        public virtual void OnContentInspectResult(media::CONTENT_INSPECT_RESULT result) { }//exDone

        //todo fix with dcg
        public virtual void OnSnapshotTaken(RtcConnection connection, string filePath, int width, int height, int errCode) { }//exDone

        public virtual void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode) { }//exDone

        public virtual void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed) { }//exDone

        public virtual void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed) { }//exDone

        public virtual void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed) { }//exDone

        public virtual void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason) { }//exDone

        //todo new add in dcg
        public virtual void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed) { }//handleDone

        [Obsolete("__deprecated")]
        public virtual void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted) { } //exDone

        [Obsolete("__deprecated")]
        public virtual void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted) { }//exDone

        [Obsolete("__deprecated")]
        public virtual void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled) { }//exDone

        [Obsolete("__deprecated")]
        public virtual void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled) { }//exDone

        //todo new add in dcg
        public virtual void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state) { } //exDone

        public virtual void OnApiCallExecuted(int err, string api, string result) { }//handleDone

        public virtual void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats) { }//exDone

        public virtual void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats) { }//exDone

        public virtual void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats) { }//exDone

        public virtual void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats) { }//exDone

        public virtual void OnCameraReady() { }//handleDone

        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height) { }//handleDone

        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height) { }//handleDone

        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle vecRectangle, int[] vecDistance, int numFaces) { }//handleDone

        public virtual void OnVideoStopped() { }//handleDone

        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_ERROR_TYPE errorCode) { }//handleDone

        //todo new add in dcg
        public virtual void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode) { }//handleDone

        public virtual void OnConnectionLost(RtcConnection connection) { } //exDone

        public virtual void OnConnectionInterrupted(RtcConnection connection) { }//exDone

        public virtual void OnConnectionBanned(RtcConnection connection) { }//exDone

        public virtual void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, uint length, UInt64 sentTs) { }//exDone

        public virtual void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached) { }//exDone

        public virtual void OnRequestToken(RtcConnection connection) { }//exDone

        public virtual void OnTokenPrivilegeWillExpire(RtcConnection connection, string token) { }//exDone

        public virtual void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed) { }//exDone

        //todo new add in dcg
        public virtual void OnFirstRemoteAudioFrame(RtcConnection connection, int userId, int elapsed) { }//exDone

        //todo new add in dcg
        public virtual void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed) { }//exDone

        public virtual void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error) { }//exDone

        public virtual void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed) { }//exDone

        //todo fix with dcg
        public virtual void OnActiveSpeaker(RtcConnection connection, uint userId) { }//exDone

        public virtual void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole) { }//exDone

        //todo new add in dcg
        public virtual void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole) { } //exDone

        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted) { }//handleDone

        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode) { }//handleDone

        //todo new add in dcg
        public virtual void onRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode) { }//handleDone


        public virtual void OnStreamPublished(string url, int error) { }//handleDone

        [Obsolete("__deprecated")]
        public virtual void OnStreamUnpublished(string url) { }//handleDone

        public virtual void OnTranscodingUpdated() { }//handleDone

        public virtual void OnAudioRoutingChanged(int routing) { }//handleDone

        //todo delete with dcg
        //public virtual void OnAudioSessionRestrictionResume() { }

        public virtual void OnChannelMediaRelayStateChanged(int state, int code) { }//handleDone

        public virtual void OnChannelMediaRelayEvent(int code) { }//handleDone

        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover) { }//handleDone

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover) { }//handleDone

        public virtual void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate) { }//exDone

        public virtual void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate) { }//exDone

        public virtual void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason) { }//exDone

        public virtual void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type) { }//exDone

        public virtual void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType) { }//exDone

        //todo new add in dcg
        public virtual void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason) { } //exDone

        //todo new add in dcg
        public virtual void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string userAccount) { }//exDone

        public virtual void OnPermissionError(PERMISSION_TYPE permissionType) { }//handleDone

        public virtual void OnLocalUserRegistered(uint uid, string userAccount) { }//handleDone

        public virtual void OnUserInfoUpdated(uint uid, UserInfo info) { }//handleDone

        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState) { }//handleDone

        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState) { }//handleDone

        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState) { }//handleDone

        public virtual void OnVideoPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState) { }//handleDone

        public virtual void OnExtensionEvent(string provider, string extension, string key, string value) { }//handleDone

        public virtual void OnExtensionStarted(string provider, string extension) { }//handleDone

        public virtual void OnExtensionStopped(string provider, string extension) { }//handleDone

        //todo new add in dcg
        public virtual void OnExtensionErrored(string provider, string extension, int error, string msg) { }//handleDone
    };

}
