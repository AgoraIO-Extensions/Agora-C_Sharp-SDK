using System;

namespace Agora.Rtc
{
    public class RtcEngineEventHandlerS : IRtcEngineEventHandlerS
    {

        #region terra IRtcEngineEventHandlerS
        public event Action<int, string> EventOnError;

        public override void OnError(int err, string msg)
        {
            if (EventOnError == null) return;
            EventOnError.Invoke(err, msg);
        }

        public event Action<LastmileProbeResult> EventOnLastmileProbeResult;

        public override void OnLastmileProbeResult(LastmileProbeResult result)
        {
            if (EventOnLastmileProbeResult == null) return;
            EventOnLastmileProbeResult.Invoke(result);
        }

        public event Action<string, MEDIA_DEVICE_TYPE, MEDIA_DEVICE_STATE_TYPE> EventOnAudioDeviceStateChanged;

        public override void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            if (EventOnAudioDeviceStateChanged == null) return;
            EventOnAudioDeviceStateChanged.Invoke(deviceId, deviceType, deviceState);
        }

        public event Action<long> EventOnAudioMixingPositionChanged;

        public override void OnAudioMixingPositionChanged(long position)
        {
            if (EventOnAudioMixingPositionChanged == null) return;
            EventOnAudioMixingPositionChanged.Invoke(position);
        }

        public event Action<int> EventOnAudioEffectFinished;

        public override void OnAudioEffectFinished(int soundId)
        {
            if (EventOnAudioEffectFinished == null) return;
            EventOnAudioEffectFinished.Invoke(soundId);
        }

        public event Action<string, MEDIA_DEVICE_TYPE, MEDIA_DEVICE_STATE_TYPE> EventOnVideoDeviceStateChanged;

        public override void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            if (EventOnVideoDeviceStateChanged == null) return;
            EventOnVideoDeviceStateChanged.Invoke(deviceId, deviceType, deviceState);
        }

        public event Action<UplinkNetworkInfo> EventOnUplinkNetworkInfoUpdated;

        public override void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
            if (EventOnUplinkNetworkInfoUpdated == null) return;
            EventOnUplinkNetworkInfoUpdated.Invoke(info);
        }

        public event Action<DownlinkNetworkInfo> EventOnDownlinkNetworkInfoUpdated;

        public override void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
            if (EventOnDownlinkNetworkInfoUpdated == null) return;
            EventOnDownlinkNetworkInfoUpdated.Invoke(info);
        }

        public event Action<int> EventOnLastmileQuality;

        public override void OnLastmileQuality(int quality)
        {
            if (EventOnLastmileQuality == null) return;
            EventOnLastmileQuality.Invoke(quality);
        }

        public event Action<VIDEO_SOURCE_TYPE, int, int, int> EventOnFirstLocalVideoFrame;

        public override void OnFirstLocalVideoFrame(VIDEO_SOURCE_TYPE source, int width, int height, int elapsed)
        {
            if (EventOnFirstLocalVideoFrame == null) return;
            EventOnFirstLocalVideoFrame.Invoke(source, width, height, elapsed);
        }

        public event Action<VIDEO_SOURCE_TYPE, LOCAL_VIDEO_STREAM_STATE, LOCAL_VIDEO_STREAM_ERROR> EventOnLocalVideoStateChanged;

        public override void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR error)
        {
            if (EventOnLocalVideoStateChanged == null) return;
            EventOnLocalVideoStateChanged.Invoke(source, state, error);
        }

        public event Action<int, int, int, int> EventOnCameraFocusAreaChanged;

        public override void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
            if (EventOnCameraFocusAreaChanged == null) return;
            EventOnCameraFocusAreaChanged.Invoke(x, y, width, height);
        }

        public event Action<int, int, int, int> EventOnCameraExposureAreaChanged;

        public override void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
            if (EventOnCameraExposureAreaChanged == null) return;
            EventOnCameraExposureAreaChanged.Invoke(x, y, width, height);
        }

        public event Action<int, int, Rectangle[], int[], int> EventOnFacePositionChanged;

        public override void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle[] vecRectangle, int[] vecDistance, int numFaces)
        {
            if (EventOnFacePositionChanged == null) return;
            EventOnFacePositionChanged.Invoke(imageWidth, imageHeight, vecRectangle, vecDistance, numFaces);
        }

        public event Action<AUDIO_MIXING_STATE_TYPE, AUDIO_MIXING_REASON_TYPE> EventOnAudioMixingStateChanged;

        public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
            if (EventOnAudioMixingStateChanged == null) return;
            EventOnAudioMixingStateChanged.Invoke(state, reason);
        }

        public event Action<RHYTHM_PLAYER_STATE_TYPE, RHYTHM_PLAYER_ERROR_TYPE> EventOnRhythmPlayerStateChanged;

        public override void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
            if (EventOnRhythmPlayerStateChanged == null) return;
            EventOnRhythmPlayerStateChanged.Invoke(state, errorCode);
        }

        public event Action<CONTENT_INSPECT_RESULT> EventOnContentInspectResult;

        public override void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
            if (EventOnContentInspectResult == null) return;
            EventOnContentInspectResult.Invoke(result);
        }

        public event Action<MEDIA_DEVICE_TYPE, int, bool> EventOnAudioDeviceVolumeChanged;

        public override void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
            if (EventOnAudioDeviceVolumeChanged == null) return;
            EventOnAudioDeviceVolumeChanged.Invoke(deviceType, volume, muted);
        }

        public event Action<string, RTMP_STREAM_PUBLISH_STATE, RTMP_STREAM_PUBLISH_ERROR_TYPE> EventOnRtmpStreamingStateChanged;

        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
            if (EventOnRtmpStreamingStateChanged == null) return;
            EventOnRtmpStreamingStateChanged.Invoke(url, state, errCode);
        }

        public event Action<string, RTMP_STREAMING_EVENT> EventOnRtmpStreamingEvent;

        public override void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
            if (EventOnRtmpStreamingEvent == null) return;
            EventOnRtmpStreamingEvent.Invoke(url, eventCode);
        }

        public event Action EventOnTranscodingUpdated;

        public override void OnTranscodingUpdated()
        {
            if (EventOnTranscodingUpdated == null) return;
            EventOnTranscodingUpdated.Invoke();
        }

        public event Action<int> EventOnAudioRoutingChanged;

        public override void OnAudioRoutingChanged(int routing)
        {
            if (EventOnAudioRoutingChanged == null) return;
            EventOnAudioRoutingChanged.Invoke(routing);
        }

        public event Action<int, int> EventOnChannelMediaRelayStateChanged;

        public override void OnChannelMediaRelayStateChanged(int state, int code)
        {
            if (EventOnChannelMediaRelayStateChanged == null) return;
            EventOnChannelMediaRelayStateChanged.Invoke(state, code);
        }

        public event Action<bool> EventOnLocalPublishFallbackToAudioOnly;

        public override void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
            if (EventOnLocalPublishFallbackToAudioOnly == null) return;
            EventOnLocalPublishFallbackToAudioOnly.Invoke(isFallbackOrRecover);
        }

        public event Action<PERMISSION_TYPE> EventOnPermissionError;

        public override void OnPermissionError(PERMISSION_TYPE permissionType)
        {
            if (EventOnPermissionError == null) return;
            EventOnPermissionError.Invoke(permissionType);
        }

        public event Action<string, STREAM_PUBLISH_STATE, STREAM_PUBLISH_STATE, int> EventOnAudioPublishStateChanged;

        public override void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            if (EventOnAudioPublishStateChanged == null) return;
            EventOnAudioPublishStateChanged.Invoke(channel, oldState, newState, elapseSinceLastState);
        }

        public event Action<VIDEO_SOURCE_TYPE, string, STREAM_PUBLISH_STATE, STREAM_PUBLISH_STATE, int> EventOnVideoPublishStateChanged;

        public override void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            if (EventOnVideoPublishStateChanged == null) return;
            EventOnVideoPublishStateChanged.Invoke(source, channel, oldState, newState, elapseSinceLastState);
        }

        public event Action<string, string, string, string> EventOnExtensionEvent;

        public override void OnExtensionEvent(string provider, string extension, string key, string value)
        {
            if (EventOnExtensionEvent == null) return;
            EventOnExtensionEvent.Invoke(provider, extension, key, value);
        }

        public event Action<string, string> EventOnExtensionStarted;

        public override void OnExtensionStarted(string provider, string extension)
        {
            if (EventOnExtensionStarted == null) return;
            EventOnExtensionStarted.Invoke(provider, extension);
        }

        public event Action<string, string> EventOnExtensionStopped;

        public override void OnExtensionStopped(string provider, string extension)
        {
            if (EventOnExtensionStopped == null) return;
            EventOnExtensionStopped.Invoke(provider, extension);
        }

        public event Action<string, string, int, string> EventOnExtensionError;

        public override void OnExtensionError(string provider, string extension, int error, string message)
        {
            if (EventOnExtensionError == null) return;
            EventOnExtensionError.Invoke(provider, extension, error, message);
        }

        public event Action<string, string, PROXY_TYPE, string, int> EventOnProxyConnected;

        public override void OnProxyConnected(string channel, string userAccount, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            if (EventOnProxyConnected == null) return;
            EventOnProxyConnected.Invoke(channel, userAccount, proxyType, localProxyIp, elapsed);
        }

        public event Action<string, bool> EventOnRemoteSubscribeFallbackToAudioOnly;

        public override void OnRemoteSubscribeFallbackToAudioOnly(string userAccount, bool isFallbackOrRecover)
        {
            if (EventOnRemoteSubscribeFallbackToAudioOnly == null) return;
            EventOnRemoteSubscribeFallbackToAudioOnly.Invoke(userAccount, isFallbackOrRecover);
        }

        public event Action<string, string, STREAM_SUBSCRIBE_STATE, STREAM_SUBSCRIBE_STATE, int> EventOnAudioSubscribeStateChanged;

        public override void OnAudioSubscribeStateChanged(string channel, string userAccount, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (EventOnAudioSubscribeStateChanged == null) return;
            EventOnAudioSubscribeStateChanged.Invoke(channel, userAccount, oldState, newState, elapseSinceLastState);
        }

        public event Action<string, string, STREAM_SUBSCRIBE_STATE, STREAM_SUBSCRIBE_STATE, int> EventOnVideoSubscribeStateChanged;

        public override void OnVideoSubscribeStateChanged(string channel, string userAccount, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (EventOnVideoSubscribeStateChanged == null) return;
            EventOnVideoSubscribeStateChanged.Invoke(channel, userAccount, oldState, newState, elapseSinceLastState);
        }

        public event Action<TranscodingVideoStreamS, VIDEO_TRANSCODER_ERROR> EventOnLocalVideoTranscoderError;

        public override void OnLocalVideoTranscoderError(TranscodingVideoStreamS streamS, VIDEO_TRANSCODER_ERROR error)
        {
            if (EventOnLocalVideoTranscoderError == null) return;
            EventOnLocalVideoTranscoderError.Invoke(streamS, error);
        }

        public event Action<RtcConnectionS, int> EventOnJoinChannelSuccess;

        public override void OnJoinChannelSuccess(RtcConnectionS connectionS, int elapsed)
        {
            if (EventOnJoinChannelSuccess == null) return;
            EventOnJoinChannelSuccess.Invoke(connectionS, elapsed);
        }

        public event Action<RtcConnectionS, int> EventOnRejoinChannelSuccess;

        public override void OnRejoinChannelSuccess(RtcConnectionS connectionS, int elapsed)
        {
            if (EventOnRejoinChannelSuccess == null) return;
            EventOnRejoinChannelSuccess.Invoke(connectionS, elapsed);
        }

        public event Action<RtcConnectionS, AudioVolumeInfoS[], uint, int> EventOnAudioVolumeIndication;

        public override void OnAudioVolumeIndication(RtcConnectionS connectionS, AudioVolumeInfoS[] speakersS, uint speakerNumber, int totalVolume)
        {
            if (EventOnAudioVolumeIndication == null) return;
            EventOnAudioVolumeIndication.Invoke(connectionS, speakersS, speakerNumber, totalVolume);
        }

        public event Action<RtcConnectionS, RtcStats> EventOnLeaveChannel;

        public override void OnLeaveChannel(RtcConnectionS connectionS, RtcStats stats)
        {
            if (EventOnLeaveChannel == null) return;
            EventOnLeaveChannel.Invoke(connectionS, stats);
        }

        public event Action<RtcConnectionS, RtcStats> EventOnRtcStats;

        public override void OnRtcStats(RtcConnectionS connectionS, RtcStats stats)
        {
            if (EventOnRtcStats == null) return;
            EventOnRtcStats.Invoke(connectionS, stats);
        }

        public event Action<RtcConnectionS, string, int, int> EventOnNetworkQuality;

        public override void OnNetworkQuality(RtcConnectionS connectionS, string remoteUserAccount, int txQuality, int rxQuality)
        {
            if (EventOnNetworkQuality == null) return;
            EventOnNetworkQuality.Invoke(connectionS, remoteUserAccount, txQuality, rxQuality);
        }

        public event Action<RtcConnectionS> EventOnIntraRequestReceived;

        public override void OnIntraRequestReceived(RtcConnectionS connectionS)
        {
            if (EventOnIntraRequestReceived == null) return;
            EventOnIntraRequestReceived.Invoke(connectionS);
        }

        public event Action<RtcConnectionS, int> EventOnFirstLocalVideoFramePublished;

        public override void OnFirstLocalVideoFramePublished(RtcConnectionS connectionS, int elapsed)
        {
            if (EventOnFirstLocalVideoFramePublished == null) return;
            EventOnFirstLocalVideoFramePublished.Invoke(connectionS, elapsed);
        }

        public event Action<RtcConnectionS, string, int, int, int> EventOnFirstRemoteVideoDecoded;

        public override void OnFirstRemoteVideoDecoded(RtcConnectionS connectionS, string remoteUserAccount, int width, int height, int elapsed)
        {
            if (EventOnFirstRemoteVideoDecoded == null) return;
            EventOnFirstRemoteVideoDecoded.Invoke(connectionS, remoteUserAccount, width, height, elapsed);
        }

        public event Action<RtcConnectionS, VIDEO_SOURCE_TYPE, string, int, int, int> EventOnVideoSizeChanged;

        public override void OnVideoSizeChanged(RtcConnectionS connectionS, VIDEO_SOURCE_TYPE sourceType, string userAccount, int width, int height, int rotation)
        {
            if (EventOnVideoSizeChanged == null) return;
            EventOnVideoSizeChanged.Invoke(connectionS, sourceType, userAccount, width, height, rotation);
        }

        public event Action<RtcConnectionS, LOCAL_VIDEO_STREAM_STATE, LOCAL_VIDEO_STREAM_ERROR> EventOnLocalVideoStateChanged2;

        public override void OnLocalVideoStateChanged(RtcConnectionS connectionS, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            if (EventOnLocalVideoStateChanged2 == null) return;
            EventOnLocalVideoStateChanged2.Invoke(connectionS, state, errorCode);
        }

        public event Action<RtcConnectionS, string, REMOTE_VIDEO_STATE, REMOTE_VIDEO_STATE_REASON, int> EventOnRemoteVideoStateChanged;

        public override void OnRemoteVideoStateChanged(RtcConnectionS connectionS, string userAccount, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (EventOnRemoteVideoStateChanged == null) return;
            EventOnRemoteVideoStateChanged.Invoke(connectionS, userAccount, state, reason, elapsed);
        }

        public event Action<RtcConnectionS, string, int, int, int> EventOnFirstRemoteVideoFrame;

        public override void OnFirstRemoteVideoFrame(RtcConnectionS connectionS, string userAccount, int width, int height, int elapsed)
        {
            if (EventOnFirstRemoteVideoFrame == null) return;
            EventOnFirstRemoteVideoFrame.Invoke(connectionS, userAccount, width, height, elapsed);
        }

        public event Action<RtcConnectionS, string, int> EventOnUserJoined;

        public override void OnUserJoined(RtcConnectionS connectionS, string userAccount, int elapsed)
        {
            if (EventOnUserJoined == null) return;
            EventOnUserJoined.Invoke(connectionS, userAccount, elapsed);
        }

        public event Action<RtcConnectionS, string, USER_OFFLINE_REASON_TYPE> EventOnUserOffline;

        public override void OnUserOffline(RtcConnectionS connectionS, string userAccount, USER_OFFLINE_REASON_TYPE reason)
        {
            if (EventOnUserOffline == null) return;
            EventOnUserOffline.Invoke(connectionS, userAccount, reason);
        }

        public event Action<RtcConnectionS, string, bool> EventOnUserMuteAudio;

        public override void OnUserMuteAudio(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            if (EventOnUserMuteAudio == null) return;
            EventOnUserMuteAudio.Invoke(connectionS, remoteUserAccount, muted);
        }

        public event Action<RtcConnectionS, string, bool> EventOnUserMuteVideo;

        public override void OnUserMuteVideo(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            if (EventOnUserMuteVideo == null) return;
            EventOnUserMuteVideo.Invoke(connectionS, remoteUserAccount, muted);
        }

        public event Action<RtcConnectionS, string, bool> EventOnUserEnableVideo;

        public override void OnUserEnableVideo(RtcConnectionS connectionS, string remoteUserAccount, bool enabled)
        {
            if (EventOnUserEnableVideo == null) return;
            EventOnUserEnableVideo.Invoke(connectionS, remoteUserAccount, enabled);
        }

        public event Action<RtcConnectionS, string, uint> EventOnUserStateChanged;

        public override void OnUserStateChanged(RtcConnectionS connectionS, string remoteUserAccount, uint state)
        {
            if (EventOnUserStateChanged == null) return;
            EventOnUserStateChanged.Invoke(connectionS, remoteUserAccount, state);
        }

        public event Action<RtcConnectionS, LocalAudioStats> EventOnLocalAudioStats;

        public override void OnLocalAudioStats(RtcConnectionS connectionS, LocalAudioStats stats)
        {
            if (EventOnLocalAudioStats == null) return;
            EventOnLocalAudioStats.Invoke(connectionS, stats);
        }

        public event Action<RtcConnectionS, RemoteAudioStatsS> EventOnRemoteAudioStats;

        public override void OnRemoteAudioStats(RtcConnectionS connectionS, RemoteAudioStatsS statsS)
        {
            if (EventOnRemoteAudioStats == null) return;
            EventOnRemoteAudioStats.Invoke(connectionS, statsS);
        }

        public event Action<RtcConnectionS, LocalVideoStatsS> EventOnLocalVideoStats;

        public override void OnLocalVideoStats(RtcConnectionS connectionS, LocalVideoStatsS statsS)
        {
            if (EventOnLocalVideoStats == null) return;
            EventOnLocalVideoStats.Invoke(connectionS, statsS);
        }

        public event Action<RtcConnectionS, RemoteVideoStatsS> EventOnRemoteVideoStats;

        public override void OnRemoteVideoStats(RtcConnectionS connectionS, RemoteVideoStatsS statsS)
        {
            if (EventOnRemoteVideoStats == null) return;
            EventOnRemoteVideoStats.Invoke(connectionS, statsS);
        }

        public event Action<RtcConnectionS> EventOnConnectionLost;

        public override void OnConnectionLost(RtcConnectionS connectionS)
        {
            if (EventOnConnectionLost == null) return;
            EventOnConnectionLost.Invoke(connectionS);
        }

        public event Action<RtcConnectionS> EventOnConnectionBanned;

        public override void OnConnectionBanned(RtcConnectionS connectionS)
        {
            if (EventOnConnectionBanned == null) return;
            EventOnConnectionBanned.Invoke(connectionS);
        }

        public event Action<RtcConnectionS, string, int, byte[], ulong, ulong> EventOnStreamMessage;

        public override void OnStreamMessage(RtcConnectionS connectionS, string remoteUserAccount, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            if (EventOnStreamMessage == null) return;
            EventOnStreamMessage.Invoke(connectionS, remoteUserAccount, streamId, data, length, sentTs);
        }

        public event Action<RtcConnectionS, string, int, int, int, int> EventOnStreamMessageError;

        public override void OnStreamMessageError(RtcConnectionS connectionS, string remoteUserAccount, int streamId, int code, int missed, int cached)
        {
            if (EventOnStreamMessageError == null) return;
            EventOnStreamMessageError.Invoke(connectionS, remoteUserAccount, streamId, code, missed, cached);
        }

        public event Action<RtcConnectionS> EventOnRequestToken;

        public override void OnRequestToken(RtcConnectionS connectionS)
        {
            if (EventOnRequestToken == null) return;
            EventOnRequestToken.Invoke(connectionS);
        }

        public event Action<RtcConnectionS, LICENSE_ERROR_TYPE> EventOnLicenseValidationFailure;

        public override void OnLicenseValidationFailure(RtcConnectionS connectionS, LICENSE_ERROR_TYPE reason)
        {
            if (EventOnLicenseValidationFailure == null) return;
            EventOnLicenseValidationFailure.Invoke(connectionS, reason);
        }

        public event Action<RtcConnectionS, string> EventOnTokenPrivilegeWillExpire;

        public override void OnTokenPrivilegeWillExpire(RtcConnectionS connectionS, string token)
        {
            if (EventOnTokenPrivilegeWillExpire == null) return;
            EventOnTokenPrivilegeWillExpire.Invoke(connectionS, token);
        }

        public event Action<RtcConnectionS, int> EventOnFirstLocalAudioFramePublished;

        public override void OnFirstLocalAudioFramePublished(RtcConnectionS connectionS, int elapsed)
        {
            if (EventOnFirstLocalAudioFramePublished == null) return;
            EventOnFirstLocalAudioFramePublished.Invoke(connectionS, elapsed);
        }

        public event Action<RtcConnectionS, LOCAL_AUDIO_STREAM_STATE, LOCAL_AUDIO_STREAM_ERROR> EventOnLocalAudioStateChanged;

        public override void OnLocalAudioStateChanged(RtcConnectionS connectionS, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            if (EventOnLocalAudioStateChanged == null) return;
            EventOnLocalAudioStateChanged.Invoke(connectionS, state, error);
        }

        public event Action<RtcConnectionS, string, REMOTE_AUDIO_STATE, REMOTE_AUDIO_STATE_REASON, int> EventOnRemoteAudioStateChanged;

        public override void OnRemoteAudioStateChanged(RtcConnectionS connectionS, string remoteUserAccount, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            if (EventOnRemoteAudioStateChanged == null) return;
            EventOnRemoteAudioStateChanged.Invoke(connectionS, remoteUserAccount, state, reason, elapsed);
        }

        public event Action<RtcConnectionS, string> EventOnActiveSpeaker;

        public override void OnActiveSpeaker(RtcConnectionS connectionS, string userAccount)
        {
            if (EventOnActiveSpeaker == null) return;
            EventOnActiveSpeaker.Invoke(connectionS, userAccount);
        }

        public event Action<RtcConnectionS, CLIENT_ROLE_TYPE, CLIENT_ROLE_TYPE, ClientRoleOptions> EventOnClientRoleChanged;

        public override void OnClientRoleChanged(RtcConnectionS connectionS, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            if (EventOnClientRoleChanged == null) return;
            EventOnClientRoleChanged.Invoke(connectionS, oldRole, newRole, newRoleOptions);
        }

        public event Action<RtcConnectionS, CLIENT_ROLE_CHANGE_FAILED_REASON, CLIENT_ROLE_TYPE> EventOnClientRoleChangeFailed;

        public override void OnClientRoleChangeFailed(RtcConnectionS connectionS, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            if (EventOnClientRoleChangeFailed == null) return;
            EventOnClientRoleChangeFailed.Invoke(connectionS, reason, currentRole);
        }

        public event Action<RtcConnectionS, CONNECTION_STATE_TYPE, CONNECTION_CHANGED_REASON_TYPE> EventOnConnectionStateChanged;

        public override void OnConnectionStateChanged(RtcConnectionS connectionS, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            if (EventOnConnectionStateChanged == null) return;
            EventOnConnectionStateChanged.Invoke(connectionS, state, reason);
        }

        public event Action<RtcConnectionS, WLACC_MESSAGE_REASON, WLACC_SUGGEST_ACTION, string> EventOnWlAccMessage;

        public override void OnWlAccMessage(RtcConnectionS connectionS, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            if (EventOnWlAccMessage == null) return;
            EventOnWlAccMessage.Invoke(connectionS, reason, action, wlAccMsg);
        }

        public event Action<RtcConnectionS, WlAccStats, WlAccStats> EventOnWlAccStats;

        public override void OnWlAccStats(RtcConnectionS connectionS, WlAccStats currentStats, WlAccStats averageStats)
        {
            if (EventOnWlAccStats == null) return;
            EventOnWlAccStats.Invoke(connectionS, currentStats, averageStats);
        }

        public event Action<RtcConnectionS, NETWORK_TYPE> EventOnNetworkTypeChanged;

        public override void OnNetworkTypeChanged(RtcConnectionS connectionS, NETWORK_TYPE type)
        {
            if (EventOnNetworkTypeChanged == null) return;
            EventOnNetworkTypeChanged.Invoke(connectionS, type);
        }

        public event Action<RtcConnectionS, ENCRYPTION_ERROR_TYPE> EventOnEncryptionError;

        public override void OnEncryptionError(RtcConnectionS connectionS, ENCRYPTION_ERROR_TYPE errorType)
        {
            if (EventOnEncryptionError == null) return;
            EventOnEncryptionError.Invoke(connectionS, errorType);
        }

        public event Action<RtcConnectionS, string, bool, UPLOAD_ERROR_REASON> EventOnUploadLogResult;

        public override void OnUploadLogResult(RtcConnectionS connectionS, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            if (EventOnUploadLogResult == null) return;
            EventOnUploadLogResult.Invoke(connectionS, requestId, success, reason);
        }

        public event Action<RtcConnectionS, string, string, int, int, int> EventOnSnapshotTaken;

        public override void OnSnapshotTaken(RtcConnectionS connectionS, string userAccount, string filePath, int width, int height, int errCode)
        {
            if (EventOnSnapshotTaken == null) return;
            EventOnSnapshotTaken.Invoke(connectionS, userAccount, filePath, width, height, errCode);
        }

        public event Action<RtcConnectionS, string, MEDIA_TRACE_EVENT, VideoRenderingTracingInfo> EventOnVideoRenderingTracingResult;

        public override void OnVideoRenderingTracingResult(RtcConnectionS connectionS, string userAccount, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            if (EventOnVideoRenderingTracingResult == null) return;
            EventOnVideoRenderingTracingResult.Invoke(connectionS, userAccount, currentEvent, tracingInfo);
        }

        public event Action<RtcConnectionS, int> EventOnSetRtmFlagResult;

        public override void OnSetRtmFlagResult(RtcConnectionS connectionS, int code)
        {
            if (EventOnSetRtmFlagResult == null) return;
            EventOnSetRtmFlagResult.Invoke(connectionS, code);
        }

        #endregion terra IRtcEngineEventHandlerS

        #region terra IDirectCdnStreamingEventHandler
        public event Action<DIRECT_CDN_STREAMING_STATE, DIRECT_CDN_STREAMING_ERROR, string> EventOnDirectCdnStreamingStateChanged;

        public override void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
        {
            if (EventOnDirectCdnStreamingStateChanged == null) return;
            EventOnDirectCdnStreamingStateChanged.Invoke(state, error, message);
        }

        public event Action<DirectCdnStreamingStats> EventOnDirectCdnStreamingStats;

        public override void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
        {
            if (EventOnDirectCdnStreamingStats == null) return;
            EventOnDirectCdnStreamingStats.Invoke(stats);
        }

        #endregion terra IDirectCdnStreamingEventHandler

    }
}