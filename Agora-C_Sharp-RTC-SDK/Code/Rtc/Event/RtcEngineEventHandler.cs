using System;

namespace Agora.Rtc
{
    public delegate void OnJoinChannelSuccessHandler(RtcConnection connection, int elapsed);

    public delegate void OnErrorHandler(int err, string msg);

    public delegate void OnLeaveChannelHandler(RtcConnection connection, RtcStats stats);

    public delegate void OnRejoinChannelSuccessHandler(RtcConnection connection, int elapsed);

    public delegate void OnProxyConnectedHandler(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed);

    public delegate void OnAudioQualityHandler(RtcConnection connection, uint remoteUid, int quality, UInt16 delay, UInt16 lost);

    public delegate void OnLastmileProbeResultHandler(LastmileProbeResult result);

    public delegate void OnAudioVolumeIndicationHandler(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume);

    public delegate void OnRtcStatsHandler(RtcConnection connection, RtcStats stats);

    public delegate void OnAudioDeviceStateChangedHandler(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState);

    public delegate void OnAudioMixingFinishedHandler();

    public delegate void OnAudioEffectFinishedHandler(int soundId);

    public delegate void OnVideoDeviceStateChangedHandler(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState);

    public delegate void OnMediaDeviceChangedHandler(MEDIA_DEVICE_TYPE deviceType);

    public delegate void OnNetworkQualityHandler(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality);

    public delegate void OnIntraRequestReceivedHandler(RtcConnection connection);

    public delegate void OnUplinkNetworkInfoUpdatedHandler(UplinkNetworkInfo info);

    public delegate void OnDownlinkNetworkInfoUpdatedHandler(DownlinkNetworkInfo info);

    public delegate void OnLastmileQualityHandler(int quality);

    public delegate void OnFirstLocalVideoFrameHandler(RtcConnection connection, int width, int height, int elapsed);

    public delegate void OnFirstLocalVideoFramePublishedHandler(RtcConnection connection, int elapsed);

    public delegate void OnVideoSourceFrameSizeChangedHandler(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, int width, int height);

    public delegate void OnFirstRemoteVideoDecodedHandler(RtcConnection connection, uint remoteUid, int width, int height, int elapsed);

    public delegate void OnVideoSizeChangedHandler(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation);

    public delegate void OnContentInspectResultHandler(CONTENT_INSPECT_RESULT result);

    public delegate void OnSnapshotTakenHandlerEx(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode);

    public delegate void OnLocalVideoStateChangedHandler(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode);

    public delegate void OnLocalVideoStateChangedHandlerEx(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode);

    public delegate void OnRemoteVideoStateChangedHandler(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed);

    public delegate void OnFirstRemoteVideoFrameHandler(RtcConnection connection, uint remoteUid, int width, int height, int elapsed);

    public delegate void OnUserJoinedHandler(RtcConnection connection, uint remoteUid, int elapsed);

    public delegate void OnUserOfflineHandler(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason);

    public delegate void OnUserMuteAudioHandler(RtcConnection connection, uint remoteUid, bool muted);

    public delegate void OnUserMuteVideoHandler(RtcConnection connection, uint remoteUid, bool muted);

    public delegate void OnUserEnableVideoHandler(RtcConnection connection, uint remoteUid, bool enabled);

    public delegate void OnUserEnableLocalVideoHandler(RtcConnection connection, uint remoteUid, bool enabled);

    public delegate void OnUserStateChangedHandler(RtcConnection connection, uint remoteUid, uint state);

    public delegate void OnApiCallExecutedHandler(int err, string api, string result);

    public delegate void OnLocalAudioStatsHandler(RtcConnection connection, LocalAudioStats stats);

    public delegate void OnRemoteAudioStatsHandler(RtcConnection connection, RemoteAudioStats stats);

    public delegate void OnLocalVideoStatsHandler(RtcConnection connection, LocalVideoStats stats);

    public delegate void OnRemoteVideoStatsHandler(RtcConnection connection, RemoteVideoStats stats);

    public delegate void OnCameraReadyHandler();

    public delegate void OnCameraFocusAreaChangedHandler(int x, int y, int width, int height);

    public delegate void OnCameraExposureAreaChangedHandler(int x, int y, int width, int height);

    public delegate void OnFacePositionChangedHandler(int imageWidth, int imageHeight, Rectangle vecRectangle, int[] vecDistance, int numFaces);

    public delegate void OnVideoStoppedHandler();

    public delegate void OnAudioMixingStateChangedHandler(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason);

    public delegate void OnRhythmPlayerStateChangedHandler(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode);

    public delegate void OnConnectionLostHandler(RtcConnection connection);

    public delegate void OnConnectionInterruptedHandler(RtcConnection connection);

    public delegate void OnConnectionBannedHandler(RtcConnection connection);

    public delegate void OnStreamMessageHandler(RtcConnection connection, uint remoteUid, int streamId, byte[] data, uint length, UInt64 sentTs);

    public delegate void OnStreamMessageErrorHandler(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached);

    public delegate void OnRequestTokenHandler(RtcConnection connection);

    public delegate void OnTokenPrivilegeWillExpireHandler(RtcConnection connection, string token);

    public delegate void OnFirstLocalAudioFramePublishedHandler(RtcConnection connection, int elapsed);

    public delegate void OnFirstRemoteAudioFrameHandler(RtcConnection connection, uint userId, int elapsed);

    public delegate void OnFirstRemoteAudioDecodedHandler(RtcConnection connection, uint uid, int elapsed);

    public delegate void OnLocalAudioStateChangedHandler(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error);

    public delegate void OnRemoteAudioStateChangedHandler(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed);

    public delegate void OnActiveSpeakerHandler(RtcConnection connection, uint uid);

    public delegate void OnClientRoleChangedHandler(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole);

    public delegate void OnClientRoleChangeFailedHandler(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole);

    public delegate void OnAudioDeviceVolumeChangedHandler(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted);

    public delegate void OnRtmpStreamingStateChangedHandler(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode);

    public delegate void OnRtmpStreamingEventHandler(string url, RTMP_STREAMING_EVENT eventCode);

    //public delegate void OnStreamPublishedHandler(string url, int error);

    //public delegate void OnStreamUnpublishedHandler(string url);

    public delegate void OnTranscodingUpdatedHandler();

    public delegate void OnAudioRoutingChangedHandler(int routing);

    public delegate void OnChannelMediaRelayStateChangedHandler(int state, int code);

    public delegate void OnChannelMediaRelayEventHandler(int code);

    public delegate void OnLocalPublishFallbackToAudioOnlyHandler(bool isFallbackOrRecover);

    public delegate void OnRemoteSubscribeFallbackToAudioOnlyHandler(uint uid, bool isFallbackOrRecover);

    public delegate void OnRemoteAudioTransportStatsHandler(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate);

    public delegate void OnRemoteVideoTransportStatsHandler(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate);

    public delegate void OnConnectionStateChangedHandler(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason);

    public delegate void OnWlAccMessageHandler(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg);

    public delegate void OnWlAccStatsHandler(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats);

    public delegate void OnNetworkTypeChangedHandler(RtcConnection connection, NETWORK_TYPE type);

    public delegate void OnEncryptionErrorHandler(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType);

    public delegate void OnUploadLogResultHandler(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason);

    public delegate void OnUserAccountUpdatedHandler(RtcConnection connection, uint remoteUid, string userAccount);

    public delegate void OnPermissionErrorHandler(PERMISSION_TYPE permissionType);

    public delegate void OnLocalUserRegisteredHandler(uint uid, string userAccount);

    public delegate void OnUserInfoUpdatedHandler(uint uid, UserInfo info);

    public delegate void OnAudioSubscribeStateChangedHandler(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState);

    public delegate void OnVideoSubscribeStateChangedHandler(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState);

    public delegate void OnAudioPublishStateChangedHandler(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState);

    public delegate void OnVideoPublishStateChangedHandler(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState);

    public delegate void OnExtensionEventHandler(string provider, string extension, string key, string value);

    public delegate void OnExtensionStartedHandler(string provider, string extension);

    public delegate void OnExtensionStoppedHandler(string provider, string extension);

    public delegate void OnExtensionErrorHandler(string provider, string extension, int error, string message);

    public delegate void OnDirectCdnStreamingStateChangedHandler(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message);

    public delegate void OnDirectCdnStreamingStatsHandler(DirectCdnStreamingStats stats);

    public class RtcEngineEventHandler : IRtcEngineEventHandler
    {
        public event OnJoinChannelSuccessHandler EventOnJoinChannelSuccess;
        public event OnLeaveChannelHandler EventOnLeaveChannel;
        public event OnErrorHandler EventOnError;
        public event OnRejoinChannelSuccessHandler EventOnRejoinChannelSuccess;
        public event OnProxyConnectedHandler EventOnProxyConnected;
        public event OnAudioQualityHandler EventOnAudioQuality;
        public event OnLastmileProbeResultHandler EventOnLastmileProbeResult;
        public event OnAudioVolumeIndicationHandler EventOnAudioVolumeIndication;
        public event OnRtcStatsHandler EventOnRtcStats;
        public event OnAudioDeviceStateChangedHandler EventOnAudioDeviceStateChanged;
        public event OnAudioMixingFinishedHandler EventOnAudioMixingFinished;
        public event OnAudioEffectFinishedHandler EventOnAudioEffectFinished;
        public event OnVideoDeviceStateChangedHandler EventOnVideoDeviceStateChanged;
        public event OnMediaDeviceChangedHandler EventOnMediaDeviceChanged;
        public event OnNetworkQualityHandler EventOnNetworkQuality;
        public event OnIntraRequestReceivedHandler EventOnIntraRequestReceived;
        public event OnUplinkNetworkInfoUpdatedHandler EventOnUplinkNetworkInfoUpdated;
        public event OnDownlinkNetworkInfoUpdatedHandler EventOnDownlinkNetworkInfoUpdated;
        public event OnLastmileQualityHandler EventOnLastmileQuality;
        public event OnFirstLocalVideoFrameHandler EventOnFirstLocalVideoFrame;
        public event OnFirstLocalVideoFramePublishedHandler EventOnFirstLocalVideoFramePublished;
        public event OnVideoSourceFrameSizeChangedHandler EventOnVideoSourceFrameSizeChanged;
        public event OnFirstRemoteVideoDecodedHandler EventOnFirstRemoteVideoDecoded;
        public event OnVideoSizeChangedHandler EventOnVideoSizeChanged;
        public event OnContentInspectResultHandler EventOnContentInspectResult;
        public event OnSnapshotTakenHandlerEx EventOnSnapshotTakenEx;
        public event OnLocalVideoStateChangedHandler EventOnLocalVideoStateChanged;
        public event OnLocalVideoStateChangedHandlerEx EventOnLocalVideoStateChangedEx;
        public event OnRemoteVideoStateChangedHandler EventOnRemoteVideoStateChanged;
        public event OnFirstRemoteVideoFrameHandler EventOnFirstRemoteVideoFrame;
        public event OnUserJoinedHandler EventOnUserJoined;
        public event OnUserOfflineHandler EventOnUserOffline;
        public event OnUserMuteAudioHandler EventOnUserMuteAudio;
        public event OnUserMuteVideoHandler EventOnUserMuteVideo;
        public event OnUserEnableVideoHandler EventOnUserEnableVideo;
        public event OnUserEnableLocalVideoHandler EventOnUserEnableLocalVideo;
        public event OnUserStateChangedHandler EventOnUserStateChanged;
        public event OnApiCallExecutedHandler EventOnApiCallExecuted;
        public event OnLocalAudioStatsHandler EventOnLocalAudioStats;
        public event OnRemoteAudioStatsHandler EventOnRemoteAudioStats;
        public event OnLocalVideoStatsHandler EventOnLocalVideoStats;
        public event OnRemoteVideoStatsHandler EventOnRemoteVideoStats;
        public event OnCameraReadyHandler EventOnCameraReady;
        public event OnCameraFocusAreaChangedHandler EventOnCameraFocusAreaChanged;
        public event OnCameraExposureAreaChangedHandler EventOnCameraExposureAreaChanged;
        public event OnFacePositionChangedHandler EventOnFacePositionChanged;
        public event OnVideoStoppedHandler EventOnVideoStopped;
        public event OnAudioMixingStateChangedHandler EventOnAudioMixingStateChanged;
        public event OnRhythmPlayerStateChangedHandler EventOnRhythmPlayerStateChanged;
        public event OnConnectionLostHandler EventOnConnectionLost;
        public event OnConnectionInterruptedHandler EventOnConnectionInterrupted;
        public event OnConnectionBannedHandler EventOnConnectionBanned;
        public event OnStreamMessageHandler EventOnStreamMessage;
        public event OnStreamMessageErrorHandler EventOnStreamMessageError;
        public event OnRequestTokenHandler EventOnRequestToken;
        public event OnTokenPrivilegeWillExpireHandler EventOnTokenPrivilegeWillExpire;
        public event OnFirstLocalAudioFramePublishedHandler EventOnFirstLocalAudioFramePublished;
        public event OnFirstRemoteAudioFrameHandler EventOnFirstRemoteAudioFrame;
        public event OnFirstRemoteAudioDecodedHandler EventOnFirstRemoteAudioDecoded;
        public event OnLocalAudioStateChangedHandler EventOnLocalAudioStateChanged;
        public event OnRemoteAudioStateChangedHandler EventOnRemoteAudioStateChanged;
        public event OnActiveSpeakerHandler EventOnActiveSpeaker;
        public event OnClientRoleChangedHandler EventOnClientRoleChanged;
        public event OnClientRoleChangeFailedHandler EventOnClientRoleChangeFailed;
        public event OnAudioDeviceVolumeChangedHandler EventOnAudioDeviceVolumeChanged;
        public event OnRtmpStreamingStateChangedHandler EventOnRtmpStreamingStateChanged;
        public event OnRtmpStreamingEventHandler EventOnRtmpStreamingEvent;
        //public event OnStreamPublishedHandler EventOnStreamPublished;
        //public event OnStreamUnpublishedHandler EventOnStreamUnpublished;
        public event OnTranscodingUpdatedHandler EventOnTranscodingUpdated;
        public event OnAudioRoutingChangedHandler EventOnAudioRoutingChanged;
        public event OnChannelMediaRelayStateChangedHandler EventOnChannelMediaRelayStateChanged;
        public event OnChannelMediaRelayEventHandler EventOnChannelMediaRelayEvent;
        public event OnLocalPublishFallbackToAudioOnlyHandler EventOnLocalPublishFallbackToAudioOnly;
        public event OnRemoteSubscribeFallbackToAudioOnlyHandler EventOnRemoteSubscribeFallbackToAudioOnly;
        public event OnRemoteAudioTransportStatsHandler EventOnRemoteAudioTransportStats;
        public event OnRemoteVideoTransportStatsHandler EventOnRemoteVideoTransportStats;
        public event OnConnectionStateChangedHandler EventOnConnectionStateChanged;
        public event OnWlAccMessageHandler EventOnWlAccMessage;
        public event OnWlAccStatsHandler EventOnWlAccStats;
        public event OnNetworkTypeChangedHandler EventOnNetworkTypeChanged;
        public event OnEncryptionErrorHandler EventOnEncryptionError;
        public event OnUploadLogResultHandler EventOnUploadLogResult;
        public event OnUserAccountUpdatedHandler EventOnUserAccountUpdated;
        public event OnPermissionErrorHandler EventOnPermissionError;
        public event OnLocalUserRegisteredHandler EventOnLocalUserRegistered;
        public event OnUserInfoUpdatedHandler EventOnUserInfoUpdated;
        public event OnAudioSubscribeStateChangedHandler EventOnAudioSubscribeStateChanged;
        public event OnVideoSubscribeStateChangedHandler EventOnVideoSubscribeStateChanged;
        public event OnAudioPublishStateChangedHandler EventOnAudioPublishStateChanged;
        public event OnVideoPublishStateChangedHandler EventOnVideoPublishStateChanged;
        public event OnExtensionEventHandler EventOnExtensionEvent;
        public event OnExtensionStartedHandler EventOnExtensionStarted;
        public event OnExtensionStoppedHandler EventOnExtensionStopped;
        public event OnExtensionErrorHandler EventOnExtensionErrored;
        public event OnDirectCdnStreamingStateChangedHandler EventOnDirectCdnStreamingStateChanged;
        public event OnDirectCdnStreamingStatsHandler EventOnDirectCdnStreamingStats;

        private static RtcEngineEventHandler eventInstance = null;

        public static RtcEngineEventHandler GetInstance()
        {
            if (eventInstance == null)
            {
                eventInstance = new RtcEngineEventHandler();
            }

            return eventInstance;
        }

        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            if (EventOnJoinChannelSuccess == null) return;
            EventOnJoinChannelSuccess.Invoke(connection, elapsed);
        }

        public override void OnError(int err, string msg)
        {
            if (EventOnError == null) return;
            EventOnError.Invoke(err, msg);
        }

        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            if (EventOnLeaveChannel == null) return;
            EventOnLeaveChannel.Invoke(connection, stats);
        }

        public override void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            if (EventOnRejoinChannelSuccess == null) return;
            EventOnRejoinChannelSuccess.Invoke(connection, elapsed);
        }

        public override void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            if (EventOnProxyConnected == null) return;
            EventOnProxyConnected.Invoke(channel, uid, proxyType, localProxyIp, elapsed);
        }

        public override void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, UInt16 delay, UInt16 lost)
        {
            if (EventOnAudioQuality == null) return;
            EventOnAudioQuality.Invoke(connection, remoteUid, quality, delay, lost);
        }

        public override void OnLastmileProbeResult(LastmileProbeResult result)
        {
            if (EventOnLastmileProbeResult == null) return;
            EventOnLastmileProbeResult.Invoke(result);
        }

        public override void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            if (EventOnAudioVolumeIndication == null) return;
            EventOnAudioVolumeIndication.Invoke(connection, speakers, speakerNumber, totalVolume);
        }

        public override void OnRtcStats(RtcConnection connection, RtcStats stats)
        {
            if (EventOnRtcStats == null) return;
            EventOnRtcStats.Invoke(connection, stats);
        }

        public override void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            if (EventOnAudioDeviceStateChanged == null) return;
            EventOnAudioDeviceStateChanged.Invoke(deviceId, deviceType, deviceState);
        }

        [Obsolete]
        public override void OnAudioMixingFinished()
        {
            if (EventOnAudioMixingFinished == null) return;
            EventOnAudioMixingFinished.Invoke();
        }

        public override void OnAudioEffectFinished(int soundId)
        {
            if (EventOnAudioEffectFinished == null) return;
            EventOnAudioEffectFinished.Invoke(soundId);
        }

        public override void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            if (EventOnVideoDeviceStateChanged == null) return;
            EventOnVideoDeviceStateChanged.Invoke(deviceId, deviceType, deviceState);
        }

        public override void OnMediaDeviceChanged(MEDIA_DEVICE_TYPE deviceType)
        {
            if (EventOnMediaDeviceChanged == null) return;
            EventOnMediaDeviceChanged.Invoke(deviceType);
        }

        public override void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
            if (EventOnNetworkQuality == null) return;
            EventOnNetworkQuality.Invoke(connection, remoteUid, txQuality, rxQuality);
        }

        public override void OnIntraRequestReceived(RtcConnection connection)
        {
            if (EventOnIntraRequestReceived == null) return;
            EventOnIntraRequestReceived.Invoke(connection);
        }

        public override void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
            if (EventOnUplinkNetworkInfoUpdated == null) return;
            EventOnUplinkNetworkInfoUpdated.Invoke(info);
        }

        public override void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
            if (EventOnDownlinkNetworkInfoUpdated == null) return;
            EventOnDownlinkNetworkInfoUpdated.Invoke(info);
        }

        public override void OnLastmileQuality(int quality)
        {
            if (EventOnLastmileQuality == null) return;
            EventOnLastmileQuality.Invoke(quality);
        }

        public override void OnFirstLocalVideoFrame(RtcConnection connection, int width, int height, int elapsed)
        {
            if (EventOnFirstLocalVideoFrame == null) return;
            EventOnFirstLocalVideoFrame.Invoke(connection, width, height, elapsed);
        }

        public override void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)
        {
            if (EventOnFirstLocalVideoFramePublished == null) return;
            EventOnFirstLocalVideoFramePublished.Invoke(connection, elapsed);
        }

        public override void OnVideoSourceFrameSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, int width, int height)
        {
            if (EventOnVideoSourceFrameSizeChanged == null) return;
            EventOnVideoSourceFrameSizeChanged.Invoke(connection, sourceType, width, height);
        }

        public override void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            if (EventOnFirstRemoteVideoDecoded == null) return;
            EventOnFirstRemoteVideoDecoded.Invoke(connection, remoteUid, width, height, elapsed);
        }

        public override void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
            if (EventOnVideoSizeChanged == null) return;
            EventOnVideoSizeChanged.Invoke(connection, sourceType, uid, width, height, rotation);
        }

        public override void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
            if (EventOnContentInspectResult == null) return;
            EventOnContentInspectResult.Invoke(result);
        }

        public override void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
            if (EventOnSnapshotTakenEx == null) return;
            EventOnSnapshotTakenEx.Invoke(connection, uid, filePath, width, height, errCode);
        }

        public override void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            if (EventOnLocalVideoStateChanged == null) return;
            EventOnLocalVideoStateChanged.Invoke(source, state, errorCode);
        }

        public override void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            if (EventOnLocalVideoStateChangedEx == null) return;
            EventOnLocalVideoStateChangedEx.Invoke(connection, state, errorCode);
        }

        public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (EventOnRemoteVideoStateChanged == null) return;
            EventOnRemoteVideoStateChanged.Invoke(connection, remoteUid, state, reason, elapsed);
        }

        public override void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            if (EventOnFirstRemoteVideoFrame == null) return;
            EventOnFirstRemoteVideoFrame.Invoke(connection, remoteUid, width, height, elapsed);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            if (EventOnUserJoined == null) return;
            EventOnUserJoined.Invoke(connection, remoteUid, elapsed);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            if (EventOnUserOffline == null) return;
            EventOnUserOffline.Invoke(connection, remoteUid, reason);
        }

        [Obsolete]
        public override void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)
        {
            if (EventOnUserMuteAudio == null) return;
            EventOnUserMuteAudio.Invoke(connection, remoteUid, muted);
        }

        [Obsolete]
        public override void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
            if (EventOnUserMuteVideo == null) return;
            EventOnUserMuteVideo.Invoke(connection, remoteUid, muted);
        }

        [Obsolete]
        public override void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            if (EventOnUserEnableVideo == null) return;
            EventOnUserEnableVideo.Invoke(connection, remoteUid, enabled);
        }

        [Obsolete]
        public override void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            if (EventOnUserEnableLocalVideo == null) return;
            EventOnUserEnableLocalVideo.Invoke(connection, remoteUid, enabled);
        }

        public override void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
            if (EventOnUserStateChanged == null) return;
            EventOnUserStateChanged.Invoke(connection, remoteUid, state);
        }

        public override void OnApiCallExecuted(int err, string api, string result)
        {
            if (EventOnApiCallExecuted == null) return;
            EventOnApiCallExecuted.Invoke(err, api, result);
        }

        public override void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)
        {
            if (EventOnLocalAudioStats == null) return;
            EventOnLocalAudioStats.Invoke(connection, stats);
        }

        public override void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
            if (EventOnRemoteAudioStats == null) return;
            EventOnRemoteAudioStats.Invoke(connection, stats);
        }

        public override void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
            if (EventOnLocalVideoStats == null) return;
            EventOnLocalVideoStats.Invoke(connection, stats);
        }

        public override void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
            if (EventOnRemoteVideoStats == null) return;
            EventOnRemoteVideoStats.Invoke(connection, stats);
        }

        public override void OnCameraReady()
        {
            if (EventOnCameraReady == null) return;
            EventOnCameraReady.Invoke();
        }

        public override void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
            if (EventOnCameraFocusAreaChanged == null) return;
            EventOnCameraFocusAreaChanged.Invoke(x, y, width, height);
        }

        public override void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
            if (EventOnCameraExposureAreaChanged == null) return;
            EventOnCameraExposureAreaChanged.Invoke(x, y, width, height);
        }

        public override void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle vecRectangle, int[] vecDistance, int numFaces)
        {
            if (EventOnFacePositionChanged == null) return;
            EventOnFacePositionChanged.Invoke(imageWidth, imageHeight, vecRectangle, vecDistance, numFaces);
        }

        public override void OnVideoStopped()
        {
            if (EventOnVideoStopped == null) return;
            EventOnVideoStopped.Invoke();
        }

        public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
            if (EventOnAudioMixingStateChanged == null) return;
            EventOnAudioMixingStateChanged.Invoke(state, reason);
        }

        public override void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
            if (EventOnRhythmPlayerStateChanged == null) return;
            EventOnRhythmPlayerStateChanged.Invoke(state, errorCode);
        }

        public override void OnConnectionLost(RtcConnection connection)
        {
            if (EventOnConnectionLost == null) return;
            EventOnConnectionLost.Invoke(connection);
        }

        public override void OnConnectionInterrupted(RtcConnection connection)
        {
            if (EventOnConnectionInterrupted == null) return;
            EventOnConnectionInterrupted.Invoke(connection);
        }

        public override void OnConnectionBanned(RtcConnection connection)
        {
            if (EventOnConnectionBanned == null) return;
            EventOnConnectionBanned.Invoke(connection);
        }

        public override void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, uint length, UInt64 sentTs)
        {
            if (EventOnStreamMessage == null) return;
            EventOnStreamMessage.Invoke(connection, remoteUid, streamId, data, length, sentTs);
        }

        public override void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
            if (EventOnStreamMessageError == null) return;
            EventOnStreamMessageError.Invoke(connection, remoteUid, streamId, code, missed, cached);
        }

        public override void OnRequestToken(RtcConnection connection)
        {
            if (EventOnRequestToken == null) return;
            EventOnRequestToken.Invoke(connection);
        }

        public override void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
        {
            if (EventOnTokenPrivilegeWillExpire == null) return;
            EventOnTokenPrivilegeWillExpire.Invoke(connection, token);
        }

        public override void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)
        {
            if (EventOnFirstLocalAudioFramePublished == null) return;
            EventOnFirstLocalAudioFramePublished.Invoke(connection, elapsed);
        }

        public override void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)
        {
            if (EventOnFirstRemoteAudioFrame == null) return;
            EventOnFirstRemoteAudioFrame.Invoke(connection, userId, elapsed);
        }

        public override void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)
        {
            if (EventOnFirstRemoteAudioDecoded == null) return;
            EventOnFirstRemoteAudioDecoded.Invoke(connection, uid, elapsed);
        }

        public override void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            if (EventOnLocalAudioStateChanged == null) return;
            EventOnLocalAudioStateChanged.Invoke(connection, state, error);
        }

        public override void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            if (EventOnRemoteAudioStateChanged == null) return;
            EventOnRemoteAudioStateChanged.Invoke(connection, remoteUid, state, reason, elapsed);
        }

        public override void OnActiveSpeaker(RtcConnection connection, uint uid)
        {
            if (EventOnActiveSpeaker == null) return;
            EventOnActiveSpeaker.Invoke(connection, uid);
        }

        public override void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
            if (EventOnClientRoleChanged == null) return;
            EventOnClientRoleChanged.Invoke(connection, oldRole, newRole);
        }

        public override void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            if (EventOnClientRoleChangeFailed == null) return;
            EventOnClientRoleChangeFailed.Invoke(connection, reason, currentRole);
        }

        public override void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
            if (EventOnAudioDeviceVolumeChanged == null) return;
            EventOnAudioDeviceVolumeChanged.Invoke(deviceType, volume, muted);
        }

        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
            if (EventOnRtmpStreamingStateChanged == null) return;
            EventOnRtmpStreamingStateChanged.Invoke(url, state, errCode);
        }

        public override void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
            if (EventOnRtmpStreamingEvent == null) return;
            EventOnRtmpStreamingEvent.Invoke(url, eventCode);
        }

        //public override void OnStreamPublished(string url, int error)
        //{
        //    if (EventOnStreamPublished == null) return;
        //    EventOnStreamPublished.Invoke(url, error);
        //}

        //[Obsolete]
        //public override void OnStreamUnpublished(string url)
        //{
        //    if (EventOnStreamUnpublished == null) return;
        //    EventOnStreamUnpublished.Invoke(url);
        //}

        public override void OnTranscodingUpdated()
        {
            if (EventOnTranscodingUpdated == null) return;
            EventOnTranscodingUpdated.Invoke();
        }

        public override void OnAudioRoutingChanged(int routing)
        {
            if (EventOnAudioRoutingChanged == null) return;
            EventOnAudioRoutingChanged.Invoke(routing);
        }

        //public override void OnAudioSessionRestrictionResume()
        //{
        //    if (EventOnAudioSessionRestrictionResume == null) return;
        //    EventOnAudioSessionRestrictionResume.Invoke();
        //}

        public override void OnChannelMediaRelayStateChanged(int state, int code)
        {
            if (EventOnChannelMediaRelayStateChanged == null) return;
            EventOnChannelMediaRelayStateChanged.Invoke(state, code);
        }

        public override void OnChannelMediaRelayEvent(int code)
        {
            if (EventOnChannelMediaRelayEvent == null) return;
            EventOnChannelMediaRelayEvent.Invoke(code);
        }

        public override void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
            if (EventOnLocalPublishFallbackToAudioOnly == null) return;
            EventOnLocalPublishFallbackToAudioOnly.Invoke(isFallbackOrRecover);
        }

        public override void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
            if (EventOnRemoteSubscribeFallbackToAudioOnly == null) return;
            EventOnRemoteSubscribeFallbackToAudioOnly.Invoke(uid, isFallbackOrRecover);
        }

        public override void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate)
        {
            if (EventOnRemoteAudioTransportStats == null) return;
            EventOnRemoteAudioTransportStats.Invoke(connection, remoteUid, delay, lost, rxKBitRate);
        }

        public override void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate)
        {
            if (EventOnRemoteVideoTransportStats == null) return;
            EventOnRemoteVideoTransportStats.Invoke(connection, remoteUid, delay, lost, rxKBitRate);
        }

        public override void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            if (EventOnConnectionStateChanged == null) return;
            EventOnConnectionStateChanged.Invoke(connection, state, reason);
        }

        public override void OnWlAccMessage(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            if (EventOnWlAccMessage == null) return;
            EventOnWlAccMessage.Invoke(connection, reason, action, wlAccMsg);
        }

        public override void OnWlAccStats(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
            if (EventOnWlAccStats == null) return;
            EventOnWlAccStats.Invoke(connection, currentStats, averageStats);
        }

        public override void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)
        {
            if (EventOnNetworkTypeChanged == null) return;
            EventOnNetworkTypeChanged.Invoke(connection, type);
        }

        public override void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
            if (EventOnEncryptionError == null) return;
            EventOnEncryptionError.Invoke(connection, errorType);
        }

        public override void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            if (EventOnUploadLogResult == null) return;
            EventOnUploadLogResult.Invoke(connection, requestId, success, reason);
        }

        public override void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string userAccount)
        {
            if (EventOnUserAccountUpdated == null) return;
            EventOnUserAccountUpdated.Invoke(connection, remoteUid, userAccount);
        }

        public override void OnPermissionError(PERMISSION_TYPE permissionType)
        {
            if (EventOnPermissionError == null) return;
            EventOnPermissionError.Invoke(permissionType);
        }

        public override void OnLocalUserRegistered(uint uid, string userAccount)
        {
            if (EventOnLocalUserRegistered == null) return;
            EventOnLocalUserRegistered.Invoke(uid, userAccount);
        }

        public override void OnUserInfoUpdated(uint uid, UserInfo info)
        {
            if (EventOnUserInfoUpdated == null) return;
            EventOnUserInfoUpdated.Invoke(uid, info);
        }

        public override void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (EventOnAudioSubscribeStateChanged == null) return;
            EventOnAudioSubscribeStateChanged.Invoke(channel, uid, oldState, newState, elapseSinceLastState);
        }

        public override void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (EventOnVideoSubscribeStateChanged == null) return;
            EventOnVideoSubscribeStateChanged.Invoke(channel, uid, oldState, newState, elapseSinceLastState);
        }

        public override void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            if (EventOnAudioPublishStateChanged == null) return;
            EventOnAudioPublishStateChanged.Invoke(channel, oldState, newState, elapseSinceLastState);
        }

        public override void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            if (EventOnVideoPublishStateChanged == null) return;
            EventOnVideoPublishStateChanged.Invoke(source, channel, oldState, newState, elapseSinceLastState);
        }

        public override void OnExtensionEvent(string provider, string extension, string key, string value)
        {
            if (EventOnExtensionEvent == null) return;
            EventOnExtensionEvent.Invoke(provider, extension, key, value);
        }

        public override void OnExtensionStarted(string provider, string extension)
        {
            if (EventOnExtensionStarted == null) return;
            EventOnExtensionStarted.Invoke(provider, extension);
        }

        public override void OnExtensionStopped(string provider, string extension)
        {
            if (EventOnExtensionStopped == null) return;
            EventOnExtensionStopped.Invoke(provider, extension);
        }

        public override void OnExtensionError(string provider, string extension, int error, string message)
        {
            if (EventOnExtensionErrored == null) return;
            EventOnExtensionErrored.Invoke(provider, extension, error, message);
        }

        public override void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
        {
            if (EventOnExtensionErrored == null) return;
            EventOnDirectCdnStreamingStateChanged.Invoke(state, error, message);
        }

        public override void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
        {
            if (EventOnExtensionErrored == null) return;
            EventOnDirectCdnStreamingStats.Invoke(stats);
        }
    }
}