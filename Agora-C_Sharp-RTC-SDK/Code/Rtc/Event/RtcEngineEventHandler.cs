using System;

namespace Agora.Rtc
{
    public class RtcEngineEventHandler : IRtcEngineEventHandler
    {

        #region terra IRtcEngineEventHandler
        public event Action<string, uint, PROXY_TYPE, string, int> EventOnProxyConnected;

        public override void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            if (EventOnProxyConnected == null) return;
            EventOnProxyConnected.Invoke(channel, uid, proxyType, localProxyIp, elapsed);
        }

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

        public event Action EventOnAudioMixingFinished;

        public override void OnAudioMixingFinished()
        {
            if (EventOnAudioMixingFinished == null) return;
            EventOnAudioMixingFinished.Invoke();
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

        public event Action<VIDEO_SOURCE_TYPE, LOCAL_VIDEO_STREAM_STATE, LOCAL_VIDEO_STREAM_REASON> EventOnLocalVideoStateChanged;

        public override void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
        {
            if (EventOnLocalVideoStateChanged == null) return;
            EventOnLocalVideoStateChanged.Invoke(source, state, reason);
        }

        public event Action EventOnCameraReady;

        public override void OnCameraReady()
        {
            if (EventOnCameraReady == null) return;
            EventOnCameraReady.Invoke();
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

        public event Action EventOnVideoStopped;

        public override void OnVideoStopped()
        {
            if (EventOnVideoStopped == null) return;
            EventOnVideoStopped.Invoke();
        }

        public event Action<AUDIO_MIXING_STATE_TYPE, AUDIO_MIXING_REASON_TYPE> EventOnAudioMixingStateChanged;

        public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
            if (EventOnAudioMixingStateChanged == null) return;
            EventOnAudioMixingStateChanged.Invoke(state, reason);
        }

        public event Action<RHYTHM_PLAYER_STATE_TYPE, RHYTHM_PLAYER_REASON> EventOnRhythmPlayerStateChanged;

        public override void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_REASON reason)
        {
            if (EventOnRhythmPlayerStateChanged == null) return;
            EventOnRhythmPlayerStateChanged.Invoke(state, reason);
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

        public event Action<string, RTMP_STREAM_PUBLISH_STATE, RTMP_STREAM_PUBLISH_REASON> EventOnRtmpStreamingStateChanged;

        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_REASON reason)
        {
            if (EventOnRtmpStreamingStateChanged == null) return;
            EventOnRtmpStreamingStateChanged.Invoke(url, state, reason);
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

        public event Action<uint, bool> EventOnRemoteSubscribeFallbackToAudioOnly;

        public override void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
            if (EventOnRemoteSubscribeFallbackToAudioOnly == null) return;
            EventOnRemoteSubscribeFallbackToAudioOnly.Invoke(uid, isFallbackOrRecover);
        }

        public event Action<PERMISSION_TYPE> EventOnPermissionError;

        public override void OnPermissionError(PERMISSION_TYPE permissionType)
        {
            if (EventOnPermissionError == null) return;
            EventOnPermissionError.Invoke(permissionType);
        }

        public event Action<uint, string> EventOnLocalUserRegistered;

        public override void OnLocalUserRegistered(uint uid, string userAccount)
        {
            if (EventOnLocalUserRegistered == null) return;
            EventOnLocalUserRegistered.Invoke(uid, userAccount);
        }

        public event Action<uint, UserInfo> EventOnUserInfoUpdated;

        public override void OnUserInfoUpdated(uint uid, UserInfo info)
        {
            if (EventOnUserInfoUpdated == null) return;
            EventOnUserInfoUpdated.Invoke(uid, info);
        }

        public event Action<TranscodingVideoStream, VIDEO_TRANSCODER_ERROR> EventOnLocalVideoTranscoderError;

        public override void OnLocalVideoTranscoderError(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
            if (EventOnLocalVideoTranscoderError == null) return;
            EventOnLocalVideoTranscoderError.Invoke(stream, error);
        }

        public event Action<string, uint, STREAM_SUBSCRIBE_STATE, STREAM_SUBSCRIBE_STATE, int> EventOnAudioSubscribeStateChanged;

        public override void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (EventOnAudioSubscribeStateChanged == null) return;
            EventOnAudioSubscribeStateChanged.Invoke(channel, uid, oldState, newState, elapseSinceLastState);
        }

        public event Action<string, uint, STREAM_SUBSCRIBE_STATE, STREAM_SUBSCRIBE_STATE, int> EventOnVideoSubscribeStateChanged;

        public override void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (EventOnVideoSubscribeStateChanged == null) return;
            EventOnVideoSubscribeStateChanged.Invoke(channel, uid, oldState, newState, elapseSinceLastState);
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

        public event Action<RtcConnection, int> EventOnJoinChannelSuccess;

        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            if (EventOnJoinChannelSuccess == null) return;
            EventOnJoinChannelSuccess.Invoke(connection, elapsed);
        }

        public event Action<RtcConnection, int> EventOnRejoinChannelSuccess;

        public override void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            if (EventOnRejoinChannelSuccess == null) return;
            EventOnRejoinChannelSuccess.Invoke(connection, elapsed);
        }

        public event Action<RtcConnection, uint, int, ushort, ushort> EventOnAudioQuality;

        public override void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
            if (EventOnAudioQuality == null) return;
            EventOnAudioQuality.Invoke(connection, remoteUid, quality, delay, lost);
        }

        public event Action<RtcConnection, AudioVolumeInfo[], uint, int> EventOnAudioVolumeIndication;

        public override void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            if (EventOnAudioVolumeIndication == null) return;
            EventOnAudioVolumeIndication.Invoke(connection, speakers, speakerNumber, totalVolume);
        }

        public event Action<RtcConnection, RtcStats> EventOnLeaveChannel;

        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            if (EventOnLeaveChannel == null) return;
            EventOnLeaveChannel.Invoke(connection, stats);
        }

        public event Action<RtcConnection, RtcStats> EventOnRtcStats;

        public override void OnRtcStats(RtcConnection connection, RtcStats stats)
        {
            if (EventOnRtcStats == null) return;
            EventOnRtcStats.Invoke(connection, stats);
        }

        public event Action<RtcConnection, uint, int, int> EventOnNetworkQuality;

        public override void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
            if (EventOnNetworkQuality == null) return;
            EventOnNetworkQuality.Invoke(connection, remoteUid, txQuality, rxQuality);
        }

        public event Action<RtcConnection> EventOnIntraRequestReceived;

        public override void OnIntraRequestReceived(RtcConnection connection)
        {
            if (EventOnIntraRequestReceived == null) return;
            EventOnIntraRequestReceived.Invoke(connection);
        }

        public event Action<RtcConnection, int> EventOnFirstLocalVideoFramePublished;

        public override void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)
        {
            if (EventOnFirstLocalVideoFramePublished == null) return;
            EventOnFirstLocalVideoFramePublished.Invoke(connection, elapsed);
        }

        public event Action<RtcConnection, uint, int, int, int> EventOnFirstRemoteVideoDecoded;

        public override void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            if (EventOnFirstRemoteVideoDecoded == null) return;
            EventOnFirstRemoteVideoDecoded.Invoke(connection, remoteUid, width, height, elapsed);
        }

        public event Action<RtcConnection, VIDEO_SOURCE_TYPE, uint, int, int, int> EventOnVideoSizeChanged;

        public override void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
            if (EventOnVideoSizeChanged == null) return;
            EventOnVideoSizeChanged.Invoke(connection, sourceType, uid, width, height, rotation);
        }

        public event Action<RtcConnection, LOCAL_VIDEO_STREAM_STATE, LOCAL_VIDEO_STREAM_REASON> EventOnLocalVideoStateChanged2;

        public override void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
        {
            if (EventOnLocalVideoStateChanged2 == null) return;
            EventOnLocalVideoStateChanged2.Invoke(connection, state, reason);
        }

        public event Action<RtcConnection, uint, REMOTE_VIDEO_STATE, REMOTE_VIDEO_STATE_REASON, int> EventOnRemoteVideoStateChanged;

        public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (EventOnRemoteVideoStateChanged == null) return;
            EventOnRemoteVideoStateChanged.Invoke(connection, remoteUid, state, reason, elapsed);
        }

        public event Action<RtcConnection, uint, int, int, int> EventOnFirstRemoteVideoFrame;

        public override void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            if (EventOnFirstRemoteVideoFrame == null) return;
            EventOnFirstRemoteVideoFrame.Invoke(connection, remoteUid, width, height, elapsed);
        }

        public event Action<RtcConnection, uint, int> EventOnUserJoined;

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            if (EventOnUserJoined == null) return;
            EventOnUserJoined.Invoke(connection, remoteUid, elapsed);
        }

        public event Action<RtcConnection, uint, USER_OFFLINE_REASON_TYPE> EventOnUserOffline;

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            if (EventOnUserOffline == null) return;
            EventOnUserOffline.Invoke(connection, remoteUid, reason);
        }

        public event Action<RtcConnection, uint, bool> EventOnUserMuteAudio;

        public override void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)
        {
            if (EventOnUserMuteAudio == null) return;
            EventOnUserMuteAudio.Invoke(connection, remoteUid, muted);
        }

        public event Action<RtcConnection, uint, bool> EventOnUserMuteVideo;

        public override void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
            if (EventOnUserMuteVideo == null) return;
            EventOnUserMuteVideo.Invoke(connection, remoteUid, muted);
        }

        public event Action<RtcConnection, uint, bool> EventOnUserEnableVideo;

        public override void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            if (EventOnUserEnableVideo == null) return;
            EventOnUserEnableVideo.Invoke(connection, remoteUid, enabled);
        }

        public event Action<RtcConnection, uint, bool> EventOnUserEnableLocalVideo;

        public override void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            if (EventOnUserEnableLocalVideo == null) return;
            EventOnUserEnableLocalVideo.Invoke(connection, remoteUid, enabled);
        }

        public event Action<RtcConnection, uint, uint> EventOnUserStateChanged;

        public override void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
            if (EventOnUserStateChanged == null) return;
            EventOnUserStateChanged.Invoke(connection, remoteUid, state);
        }

        public event Action<RtcConnection, LocalAudioStats> EventOnLocalAudioStats;

        public override void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)
        {
            if (EventOnLocalAudioStats == null) return;
            EventOnLocalAudioStats.Invoke(connection, stats);
        }

        public event Action<RtcConnection, RemoteAudioStats> EventOnRemoteAudioStats;

        public override void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
            if (EventOnRemoteAudioStats == null) return;
            EventOnRemoteAudioStats.Invoke(connection, stats);
        }

        public event Action<RtcConnection, LocalVideoStats> EventOnLocalVideoStats;

        public override void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
            if (EventOnLocalVideoStats == null) return;
            EventOnLocalVideoStats.Invoke(connection, stats);
        }

        public event Action<RtcConnection, RemoteVideoStats> EventOnRemoteVideoStats;

        public override void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
            if (EventOnRemoteVideoStats == null) return;
            EventOnRemoteVideoStats.Invoke(connection, stats);
        }

        public event Action<RtcConnection> EventOnConnectionLost;

        public override void OnConnectionLost(RtcConnection connection)
        {
            if (EventOnConnectionLost == null) return;
            EventOnConnectionLost.Invoke(connection);
        }

        public event Action<RtcConnection> EventOnConnectionInterrupted;

        public override void OnConnectionInterrupted(RtcConnection connection)
        {
            if (EventOnConnectionInterrupted == null) return;
            EventOnConnectionInterrupted.Invoke(connection);
        }

        public event Action<RtcConnection> EventOnConnectionBanned;

        public override void OnConnectionBanned(RtcConnection connection)
        {
            if (EventOnConnectionBanned == null) return;
            EventOnConnectionBanned.Invoke(connection);
        }

        public event Action<RtcConnection, uint, int, byte[], ulong, ulong> EventOnStreamMessage;

        public override void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            if (EventOnStreamMessage == null) return;
            EventOnStreamMessage.Invoke(connection, remoteUid, streamId, data, length, sentTs);
        }

        public event Action<RtcConnection, uint, int, int, int, int> EventOnStreamMessageError;

        public override void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
            if (EventOnStreamMessageError == null) return;
            EventOnStreamMessageError.Invoke(connection, remoteUid, streamId, code, missed, cached);
        }

        public event Action<RtcConnection> EventOnRequestToken;

        public override void OnRequestToken(RtcConnection connection)
        {
            if (EventOnRequestToken == null) return;
            EventOnRequestToken.Invoke(connection);
        }

        public event Action<RtcConnection, LICENSE_ERROR_TYPE> EventOnLicenseValidationFailure;

        public override void OnLicenseValidationFailure(RtcConnection connection, LICENSE_ERROR_TYPE reason)
        {
            if (EventOnLicenseValidationFailure == null) return;
            EventOnLicenseValidationFailure.Invoke(connection, reason);
        }

        public event Action<RtcConnection, string> EventOnTokenPrivilegeWillExpire;

        public override void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
        {
            if (EventOnTokenPrivilegeWillExpire == null) return;
            EventOnTokenPrivilegeWillExpire.Invoke(connection, token);
        }

        public event Action<RtcConnection, int> EventOnFirstLocalAudioFramePublished;

        public override void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)
        {
            if (EventOnFirstLocalAudioFramePublished == null) return;
            EventOnFirstLocalAudioFramePublished.Invoke(connection, elapsed);
        }

        public event Action<RtcConnection, uint, int> EventOnFirstRemoteAudioFrame;

        public override void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)
        {
            if (EventOnFirstRemoteAudioFrame == null) return;
            EventOnFirstRemoteAudioFrame.Invoke(connection, userId, elapsed);
        }

        public event Action<RtcConnection, uint, int> EventOnFirstRemoteAudioDecoded;

        public override void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)
        {
            if (EventOnFirstRemoteAudioDecoded == null) return;
            EventOnFirstRemoteAudioDecoded.Invoke(connection, uid, elapsed);
        }

        public event Action<RtcConnection, LOCAL_AUDIO_STREAM_STATE, LOCAL_AUDIO_STREAM_REASON> EventOnLocalAudioStateChanged;

        public override void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_REASON reason)
        {
            if (EventOnLocalAudioStateChanged == null) return;
            EventOnLocalAudioStateChanged.Invoke(connection, state, reason);
        }

        public event Action<RtcConnection, uint, REMOTE_AUDIO_STATE, REMOTE_AUDIO_STATE_REASON, int> EventOnRemoteAudioStateChanged;

        public override void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            if (EventOnRemoteAudioStateChanged == null) return;
            EventOnRemoteAudioStateChanged.Invoke(connection, remoteUid, state, reason, elapsed);
        }

        public event Action<RtcConnection, uint> EventOnActiveSpeaker;

        public override void OnActiveSpeaker(RtcConnection connection, uint uid)
        {
            if (EventOnActiveSpeaker == null) return;
            EventOnActiveSpeaker.Invoke(connection, uid);
        }

        public event Action<RtcConnection, CLIENT_ROLE_TYPE, CLIENT_ROLE_TYPE, ClientRoleOptions> EventOnClientRoleChanged;

        public override void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            if (EventOnClientRoleChanged == null) return;
            EventOnClientRoleChanged.Invoke(connection, oldRole, newRole, newRoleOptions);
        }

        public event Action<RtcConnection, CLIENT_ROLE_CHANGE_FAILED_REASON, CLIENT_ROLE_TYPE> EventOnClientRoleChangeFailed;

        public override void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            if (EventOnClientRoleChangeFailed == null) return;
            EventOnClientRoleChangeFailed.Invoke(connection, reason, currentRole);
        }

        public event Action<RtcConnection, uint, ushort, ushort, ushort> EventOnRemoteAudioTransportStats;

        public override void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            if (EventOnRemoteAudioTransportStats == null) return;
            EventOnRemoteAudioTransportStats.Invoke(connection, remoteUid, delay, lost, rxKBitRate);
        }

        public event Action<RtcConnection, uint, ushort, ushort, ushort> EventOnRemoteVideoTransportStats;

        public override void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            if (EventOnRemoteVideoTransportStats == null) return;
            EventOnRemoteVideoTransportStats.Invoke(connection, remoteUid, delay, lost, rxKBitRate);
        }

        public event Action<RtcConnection, CONNECTION_STATE_TYPE, CONNECTION_CHANGED_REASON_TYPE> EventOnConnectionStateChanged;

        public override void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            if (EventOnConnectionStateChanged == null) return;
            EventOnConnectionStateChanged.Invoke(connection, state, reason);
        }

        public event Action<RtcConnection, WLACC_MESSAGE_REASON, WLACC_SUGGEST_ACTION, string> EventOnWlAccMessage;

        public override void OnWlAccMessage(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            if (EventOnWlAccMessage == null) return;
            EventOnWlAccMessage.Invoke(connection, reason, action, wlAccMsg);
        }

        public event Action<RtcConnection, WlAccStats, WlAccStats> EventOnWlAccStats;

        public override void OnWlAccStats(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
            if (EventOnWlAccStats == null) return;
            EventOnWlAccStats.Invoke(connection, currentStats, averageStats);
        }

        public event Action<RtcConnection, NETWORK_TYPE> EventOnNetworkTypeChanged;

        public override void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)
        {
            if (EventOnNetworkTypeChanged == null) return;
            EventOnNetworkTypeChanged.Invoke(connection, type);
        }

        public event Action<RtcConnection, ENCRYPTION_ERROR_TYPE> EventOnEncryptionError;

        public override void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
            if (EventOnEncryptionError == null) return;
            EventOnEncryptionError.Invoke(connection, errorType);
        }

        public event Action<RtcConnection, string, bool, UPLOAD_ERROR_REASON> EventOnUploadLogResult;

        public override void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            if (EventOnUploadLogResult == null) return;
            EventOnUploadLogResult.Invoke(connection, requestId, success, reason);
        }

        public event Action<RtcConnection, uint, string> EventOnUserAccountUpdated;

        public override void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string remoteUserAccount)
        {
            if (EventOnUserAccountUpdated == null) return;
            EventOnUserAccountUpdated.Invoke(connection, remoteUid, remoteUserAccount);
        }

        public event Action<RtcConnection, uint, string, int, int, int> EventOnSnapshotTaken;

        public override void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
            if (EventOnSnapshotTaken == null) return;
            EventOnSnapshotTaken.Invoke(connection, uid, filePath, width, height, errCode);
        }

        public event Action<RtcConnection, uint, MEDIA_TRACE_EVENT, VideoRenderingTracingInfo> EventOnVideoRenderingTracingResult;

        public override void OnVideoRenderingTracingResult(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            if (EventOnVideoRenderingTracingResult == null) return;
            EventOnVideoRenderingTracingResult.Invoke(connection, uid, currentEvent, tracingInfo);
        }

        public event Action<RtcConnection, int> EventOnSetRtmFlagResult;

        public override void OnSetRtmFlagResult(RtcConnection connection, int code)
        {
            if (EventOnSetRtmFlagResult == null) return;
            EventOnSetRtmFlagResult.Invoke(connection, code);
        }

        public event Action<RtcConnection, uint, int, int, int, VideoLayout[]> EventOnTranscodedStreamLayoutInfo;

        public override void OnTranscodedStreamLayoutInfo(RtcConnection connection, uint uid, int width, int height, int layoutCount, VideoLayout[] layoutlist)
        {
            if (EventOnTranscodedStreamLayoutInfo == null) return;
            EventOnTranscodedStreamLayoutInfo.Invoke(connection, uid, width, height, layoutCount, layoutlist);
        }

        public event Action<RtcConnection, uint, byte[], ulong> EventOnAudioMetadataReceived;

        public override void OnAudioMetadataReceived(RtcConnection connection, uint uid, byte[] metadata, ulong length)
        {
            if (EventOnAudioMetadataReceived == null) return;
            EventOnAudioMetadataReceived.Invoke(connection, uid, metadata, length);
        }

        #endregion terra IRtcEngineEventHandler

        #region terra IDirectCdnStreamingEventHandler
        public event Action<DIRECT_CDN_STREAMING_STATE, DIRECT_CDN_STREAMING_REASON, string> EventOnDirectCdnStreamingStateChanged;

        public override void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_REASON reason, string message)
        {
            if (EventOnDirectCdnStreamingStateChanged == null) return;
            EventOnDirectCdnStreamingStateChanged.Invoke(state, reason, message);
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