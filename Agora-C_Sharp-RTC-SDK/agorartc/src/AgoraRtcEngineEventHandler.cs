//  AgoraRtcEngine.cs
//
//  Created by YuGuo Chen on September 26, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    public delegate void OnJoinChannelSuccessHandler(RtcConnection connection, int elapsed);

    public delegate void OnWarningHandler(int warn, string msg);

    public delegate void OnErrorHandler(int err, string msg);

    public delegate void OnLeaveChannelHandler(RtcConnection connection, RtcStats stats);

    public delegate void OnRejoinChannelSuccessHandler(RtcConnection connection, int elapsed);

    public delegate void OnAudioQualityHandler(RtcConnection connection, uint remoteUid, int quality, UInt16 delay, UInt16 lost);

    public delegate void OnLastmileProbeResultHandler(LastmileProbeResult result);

    public delegate void OnAudioVolumeIndicationHandler(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume);

    public delegate void OnRtcStatsHandler(RtcConnection connection, RtcStats stats);

    public delegate void OnAudioDeviceStateChangedHandler(string deviceId, int deviceType, MEDIA_DEVICE_STATE_TYPE deviceState);

    public delegate void OnAudioMixingFinishedHandler();

    public delegate void OnAudioEffectFinishedHandler(int soundId);

    public delegate void OnVideoDeviceStateChangedHandler(string deviceId, int deviceType, MEDIA_DEVICE_STATE_TYPE deviceState);

    public delegate void OnMediaDeviceChangedHandler(int deviceType);

    public delegate void OnNetworkQualityHandler(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality);

    public delegate void OnIntraRequestReceivedHandler(RtcConnection connection);

    public delegate void OnUplinkNetworkInfoUpdatedHandler(UplinkNetworkInfo info);

    public delegate void OnDownlinkNetworkInfoUpdatedHandler(DownlinkNetworkInfo info);

    public delegate void OnLastmileQualityHandler(int quality);

    public delegate void OnFirstLocalVideoFrameHandler(RtcConnection connection, int width, int height, int elapsed);

    public delegate void OnFirstLocalVideoFramePublishedHandler(RtcConnection connection, int elapsed);

    public delegate void OnVideoSourceFrameSizeChangedHandler(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, int width, int height);

    public delegate void OnFirstRemoteVideoDecodedHandler(RtcConnection connection, uint remoteUid, int width, int height, int elapsed);

    public delegate void OnVideoSizeChangedHandler(RtcConnection connection, uint uid, int width, int height, int rotation);

    public delegate void OnLocalVideoStateChangedHandler(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode);

    public delegate void OnRemoteVideoStateChangedHandler(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed);

    public delegate void OnFirstRemoteVideoFrameHandler(RtcConnection connection, uint remoteUid, int width, int height, int elapsed);

    public delegate void OnUserJoinedHandler(RtcConnection connection, uint remoteUid, int elapsed);

    public delegate void OnUserOfflineHandler(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason);

    public delegate void OnUserMuteVideoHandler(RtcConnection connection, uint remoteUid, bool muted);

    public delegate void OnUserEnableVideoHandler(RtcConnection connection, uint remoteUid, bool enabled);

    public delegate void OnUserEnableLocalVideoHandler(RtcConnection connection, uint remoteUid, bool enabled);

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

    public delegate void OnAudioMixingStateChangedHandler(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_ERROR_TYPE errorCode);

    public delegate void OnConnectionLostHandler(RtcConnection connection);

    public delegate void OnConnectionInterruptedHandler(RtcConnection connection);

    public delegate void OnConnectionBannedHandler(RtcConnection connection);

    public delegate void OnStreamMessageHandler(RtcConnection connection, uint remoteUid, int streamId, byte[] data, uint length, UInt64 sentTs);

    public delegate void OnStreamMessageErrorHandler(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached);

    public delegate void OnRequestTokenHandler(RtcConnection connection);

    public delegate void OnTokenPrivilegeWillExpireHandler(RtcConnection connection, string token);

    public delegate void OnFirstLocalAudioFramePublishedHandler(RtcConnection connection, int elapsed);

    public delegate void OnLocalAudioStateChangedHandler(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error);

    public delegate void OnRemoteAudioStateChangedHandler(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed);

    public delegate void OnActiveSpeakerHandler(uint userId);

    public delegate void OnClientRoleChangedHandler(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole);

    public delegate void OnAudioDeviceVolumeChangedHandler(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted);

    public delegate void OnRtmpStreamingStateChangedHandler(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode);

    public delegate void OnStreamPublishedHandler(string url, int error);

    public delegate void OnStreamUnpublishedHandler(string url);

    public delegate void OnTranscodingUpdatedHandler();

    public delegate void OnAudioRoutingChangedHandler(int routing);

    public delegate void OnAudioSessionRestrictionResumeHandler();

    public delegate void OnChannelMediaRelayStateChangedHandler(int state, int code);

    public delegate void OnChannelMediaRelayEventHandler(int code);

    public delegate void OnLocalPublishFallbackToAudioOnlyHandler(bool isFallbackOrRecover);

    public delegate void OnRemoteSubscribeFallbackToAudioOnlyHandler(uint uid, bool isFallbackOrRecover);

    public delegate void OnRemoteAudioTransportStatsHandler(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate);

    public delegate void OnRemoteVideoTransportStatsHandler(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate);

    public delegate void OnConnectionStateChangedHandler(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason);

    public delegate void OnNetworkTypeChangedHandler(RtcConnection connection, NETWORK_TYPE type);

    public delegate void OnEncryptionErrorHandler(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType);

    public delegate void OnPermissionErrorHandler(PERMISSION_TYPE permissionType);

    public delegate void OnLocalUserRegisteredHandler(uint uid, string userAccount);

    public delegate void OnUserInfoUpdatedHandler(uint uid, UserInfo info);

    public delegate void OnAudioSubscribeStateChangedHandler(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState);

    public delegate void OnVideoSubscribeStateChangedHandler(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState);

    public delegate void OnAudioPublishStateChangedHandler(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState);

    public delegate void OnVideoPublishStateChangedHandler(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState);

    public delegate void OnExtensionEventHandler(string provider, string extension, string key, string value);

    public delegate void OnExtensionStartedHandler(string provider, string extension);

    public delegate void OnExtensionStoppedHandler(string provider, string extension);

    public delegate void OnUserAccountUpdatedHandler(RtcConnection connection, uint remoteUid, string userAccount);

    public delegate void OnRhythmPlayerStateChangedHandler(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode);

    public delegate void OnSnapshotTakenHandler(string channel, uint uid, string filePath, int width, int height, int errCode);
    
    public class AgoraRtcEngineEventHandler : IAgoraRtcEngineEventHandler
    {
        public event OnJoinChannelSuccessHandler EventOnJoinChannelSuccess;
        public event OnLeaveChannelHandler EventOnLeaveChannel;
        public event OnWarningHandler EventOnWarning;
        public event OnErrorHandler EventOnError;
        public event OnRejoinChannelSuccessHandler EventOnRejoinChannelSuccess;
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
        public event OnLocalVideoStateChangedHandler EventOnLocalVideoStateChanged;
        public event OnRemoteVideoStateChangedHandler EventOnRemoteVideoStateChanged;
        public event OnFirstRemoteVideoFrameHandler EventOnFirstRemoteVideoFrame;
        public event OnUserJoinedHandler EventOnUserJoined;
        public event OnUserOfflineHandler EventOnUserOffline;
        public event OnUserMuteVideoHandler EventOnUserMuteVideo;
        public event OnUserEnableVideoHandler EventOnUserEnableVideo;
        public event OnUserEnableLocalVideoHandler EventOnUserEnableLocalVideo;
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
        public event OnConnectionLostHandler EventOnConnectionLost;
        public event OnConnectionInterruptedHandler EventOnConnectionInterrupted;
        public event OnConnectionBannedHandler EventOnConnectionBanned;
        public event OnStreamMessageHandler EventOnStreamMessage;
        public event OnStreamMessageErrorHandler EventOnStreamMessageError;
        public event OnRequestTokenHandler EventOnRequestToken;
        public event OnTokenPrivilegeWillExpireHandler EventOnTokenPrivilegeWillExpire;
        public event OnFirstLocalAudioFramePublishedHandler EventOnFirstLocalAudioFramePublished;
        public event OnLocalAudioStateChangedHandler EventOnLocalAudioStateChanged;
        public event OnRemoteAudioStateChangedHandler EventOnRemoteAudioStateChanged;
        public event OnActiveSpeakerHandler EventOnActiveSpeaker;
        public event OnClientRoleChangedHandler EventOnClientRoleChanged;
        public event OnAudioDeviceVolumeChangedHandler EventOnAudioDeviceVolumeChanged;
        public event OnRtmpStreamingStateChangedHandler EventOnRtmpStreamingStateChanged;
        public event OnStreamPublishedHandler EventOnStreamPublished;
        public event OnStreamUnpublishedHandler EventOnStreamUnpublished;
        public event OnTranscodingUpdatedHandler EventOnTranscodingUpdated;
        public event OnAudioRoutingChangedHandler EventOnAudioRoutingChanged;
        public event OnAudioSessionRestrictionResumeHandler EventOnAudioSessionRestrictionResume;
        public event OnChannelMediaRelayStateChangedHandler EventOnChannelMediaRelayStateChanged;
        public event OnChannelMediaRelayEventHandler EventOnChannelMediaRelayEvent;
        public event OnLocalPublishFallbackToAudioOnlyHandler EventOnLocalPublishFallbackToAudioOnly;
        public event OnRemoteSubscribeFallbackToAudioOnlyHandler EventOnRemoteSubscribeFallbackToAudioOnly;
        public event OnRemoteAudioTransportStatsHandler EventOnRemoteAudioTransportStats;
        public event OnRemoteVideoTransportStatsHandler EventOnRemoteVideoTransportStats;
        public event OnConnectionStateChangedHandler EventOnConnectionStateChanged;
        public event OnNetworkTypeChangedHandler EventOnNetworkTypeChanged;
        public event OnEncryptionErrorHandler EventOnEncryptionError;
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
        public event OnUserAccountUpdatedHandler EventOnUserAccountUpdated;
        public event OnRhythmPlayerStateChangedHandler EventOnRhythmPlayerStateChanged;
        public event OnSnapshotTakenHandler EventOnSnapshotTaken;


        private static AgoraRtcEngineEventHandler eventInstance = null;

        public static AgoraRtcEngineEventHandler GetInstance()
        {
            return eventInstance ?? (eventInstance = new AgoraRtcEngineEventHandler());
        }

        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            EventOnJoinChannelSuccess?.Invoke(connection, elapsed);
        }

        public override void OnWarning(int warn, string msg)
        {
            EventOnWarning?.Invoke(warn, msg);
        }

        public override void OnError(int err, string msg)
        {
            EventOnError?.Invoke(err, msg);
        }

        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            EventOnLeaveChannel?.Invoke(connection, stats);
        }


        public override void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            EventOnRejoinChannelSuccess?.Invoke(connection, elapsed);
        }

        public override void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, UInt16 delay, UInt16 lost)
        {
            EventOnAudioQuality?.Invoke(connection, remoteUid, quality, delay, lost);
        }

        public override void OnLastmileProbeResult(LastmileProbeResult result)
        {
            EventOnLastmileProbeResult?.Invoke(result);
        }

        public override void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            EventOnAudioVolumeIndication?.Invoke(connection, speakers, speakerNumber, totalVolume);
        }

        public override void OnRtcStats(RtcConnection connection, RtcStats stats)
        {
            EventOnRtcStats?.Invoke(connection, stats);
        }

        public override void OnAudioDeviceStateChanged(string deviceId, int deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            EventOnAudioDeviceStateChanged?.Invoke(deviceId, deviceType, deviceState);
        }

        public override void OnAudioMixingFinished()
        {
            EventOnAudioMixingFinished?.Invoke();
        }

        public override void OnAudioEffectFinished(int soundId)
        {
            EventOnAudioEffectFinished?.Invoke(soundId);
        }

        public override void OnVideoDeviceStateChanged(string deviceId, int deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            EventOnVideoDeviceStateChanged?.Invoke(deviceId, deviceType, deviceState);
        }

        public override void OnMediaDeviceChanged(int deviceType)
        {
            EventOnMediaDeviceChanged?.Invoke(deviceType);
        }

        public override void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
            EventOnNetworkQuality?.Invoke(connection, remoteUid, txQuality, rxQuality);
        }

        public override void OnIntraRequestReceived(RtcConnection connection)
        {
            EventOnIntraRequestReceived?.Invoke(connection);
        }

        public override void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
            EventOnUplinkNetworkInfoUpdated?.Invoke(info);
        }

        public override void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
            EventOnDownlinkNetworkInfoUpdated?.Invoke(info);
        }

        public override void OnLastmileQuality(int quality)
        {
            EventOnLastmileQuality?.Invoke(quality);
        }

        public override void OnFirstLocalVideoFrame(RtcConnection connection, int width, int height, int elapsed)
        {
            EventOnFirstLocalVideoFrame?.Invoke(connection, width, height, elapsed);
        }

        public override void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)
        {
            EventOnFirstLocalVideoFramePublished?.Invoke(connection, elapsed);
        }

        public override void OnVideoSourceFrameSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, int width, int height)
        {
            EventOnVideoSourceFrameSizeChanged?.Invoke(connection, sourceType, width, height);
        }

        public override void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            EventOnFirstRemoteVideoDecoded?.Invoke(connection, remoteUid, width, height, elapsed);
        }

        public override void OnVideoSizeChanged(RtcConnection connection, uint uid, int width, int height, int rotation)
        {
            EventOnVideoSizeChanged?.Invoke(connection, uid, width, height, rotation);
        }

        public override void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            EventOnLocalVideoStateChanged?.Invoke(connection, state, errorCode);
        }

        public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            EventOnRemoteVideoStateChanged?.Invoke(connection, remoteUid, state, reason, elapsed);
        }

        public override void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            EventOnFirstRemoteVideoFrame?.Invoke(connection, remoteUid, width, height, elapsed);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            EventOnUserJoined?.Invoke(connection, remoteUid, elapsed);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            EventOnUserOffline?.Invoke(connection, remoteUid, reason);
        }

        public override void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
            EventOnUserMuteVideo?.Invoke(connection, remoteUid, muted);
        }

        public override void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            EventOnUserEnableVideo?.Invoke(connection, remoteUid, enabled);
        }

        public override void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            EventOnUserEnableLocalVideo?.Invoke(connection, remoteUid, enabled);
        }

        public override void OnApiCallExecuted(int err, string api, string result)
        {
            EventOnApiCallExecuted?.Invoke(err, api, result);
        }

        public override void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)
        {
            EventOnLocalAudioStats?.Invoke(connection, stats);
        }

        public override void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
            EventOnRemoteAudioStats?.Invoke(connection, stats);
        }

        public override void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
            EventOnLocalVideoStats?.Invoke(connection, stats);
        }

        public override void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
            EventOnRemoteVideoStats?.Invoke(connection, stats);
        }

        public override void OnCameraReady()
        {
            EventOnCameraReady?.Invoke();
        }

        public override void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
            EventOnCameraFocusAreaChanged?.Invoke(x, y, width, height);
        }

        public override void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
            EventOnCameraExposureAreaChanged?.Invoke(x, y, width, height);
        }

        public override void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle vecRectangle, int[] vecDistance, int numFaces)
        {
            EventOnFacePositionChanged?.Invoke(imageWidth, imageHeight, vecRectangle, vecDistance, numFaces);
        }

        public override void OnVideoStopped()
        {
            EventOnVideoStopped?.Invoke();
        }

        public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_ERROR_TYPE errorCode)
        {
            EventOnAudioMixingStateChanged?.Invoke(state, errorCode);
        }

        public override void OnConnectionLost(RtcConnection connection)
        {
            EventOnConnectionLost?.Invoke(connection);
        }

        public override void OnConnectionInterrupted(RtcConnection connection)
        {
            EventOnConnectionInterrupted?.Invoke(connection);
        }

        public override void OnConnectionBanned(RtcConnection connection)
        {
            EventOnConnectionBanned?.Invoke(connection);
        }

        public override void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, uint length, UInt64 sentTs)
        {
            EventOnStreamMessage?.Invoke(connection, remoteUid, streamId, data, length, sentTs);
        }

        public override void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
            EventOnStreamMessageError?.Invoke(connection, remoteUid, streamId, code, missed, cached);
        }

        public override void OnRequestToken(RtcConnection connection)
        {
            EventOnRequestToken?.Invoke(connection);
        }

        public override void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
        {
            EventOnTokenPrivilegeWillExpire?.Invoke(connection, token);
        }

        public override void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)
        {
            EventOnFirstLocalAudioFramePublished?.Invoke(connection, elapsed);
        }

        public override void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            EventOnLocalAudioStateChanged?.Invoke(connection, state, error);
        }

        public override void  OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            EventOnRemoteAudioStateChanged?.Invoke(connection, remoteUid, state, reason, elapsed);
        }

        public override void OnActiveSpeaker(uint userId)
        {
            EventOnActiveSpeaker?.Invoke(userId);
        }

        public override void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
            EventOnClientRoleChanged?.Invoke(connection, oldRole, newRole);
        }

        public override void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
            EventOnAudioDeviceVolumeChanged?.Invoke(deviceType, volume, muted);
        }

        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
            EventOnRtmpStreamingStateChanged?.Invoke(url, state, errCode);
        }

        public override void OnStreamPublished(string url, int error)
        {
            EventOnStreamPublished?.Invoke(url, error);
        }

        public override void OnStreamUnpublished(string url)
        {
            EventOnStreamUnpublished?.Invoke(url);
        }

        public override void OnTranscodingUpdated()
        {
            EventOnTranscodingUpdated?.Invoke();
        }

        public override void OnAudioRoutingChanged(int routing)
        {
            EventOnAudioRoutingChanged?.Invoke(routing);
        }

        public override void OnAudioSessionRestrictionResume()
        {
           EventOnAudioSessionRestrictionResume?.Invoke();
        }

        public override void OnChannelMediaRelayStateChanged(int state, int code)
        {
            EventOnChannelMediaRelayStateChanged?.Invoke(state, code);
        }

        public override void OnChannelMediaRelayEvent(int code)
        {
            EventOnChannelMediaRelayEvent?.Invoke(code);
        }

        public override void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
            EventOnLocalPublishFallbackToAudioOnly?.Invoke(isFallbackOrRecover);
        }

        public override void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
            EventOnRemoteSubscribeFallbackToAudioOnly?.Invoke(uid, isFallbackOrRecover);
        }

        public override void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate)
        {
            EventOnRemoteAudioTransportStats?.Invoke(connection, remoteUid, delay, lost, rxKBitRate);
        }

        public override void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate)
        {
            EventOnRemoteVideoTransportStats?.Invoke(connection, remoteUid, delay, lost, rxKBitRate);
        }

        public override void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            EventOnConnectionStateChanged?.Invoke(connection, state, reason);
        }

        public override void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)
        {
            EventOnNetworkTypeChanged?.Invoke(connection, type);
        }

        public override void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
            EventOnEncryptionError?.Invoke(connection, errorType);
        }

        public override void OnPermissionError(PERMISSION_TYPE permissionType)
        {
            EventOnPermissionError?.Invoke(permissionType);
        }

        public override void OnLocalUserRegistered(uint uid, string userAccount)
        {
            EventOnLocalUserRegistered?.Invoke(uid, userAccount);
        }

        public override void OnUserInfoUpdated(uint uid, UserInfo info)
        {
            EventOnUserInfoUpdated?.Invoke(uid, info);
        }

        public override void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            EventOnAudioSubscribeStateChanged?.Invoke(channel, uid, oldState, newState, elapseSinceLastState);
        }

        public override void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            EventOnVideoSubscribeStateChanged?.Invoke(channel, uid, oldState, newState, elapseSinceLastState);
        }

        public override void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            EventOnAudioPublishStateChanged?.Invoke(channel, oldState, newState, elapseSinceLastState);
        }

        public override void OnVideoPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            EventOnVideoPublishStateChanged?.Invoke(channel, oldState, newState, elapseSinceLastState);
        }

        public override void OnExtensionEvent(string provider, string extension, string key, string value)
        {
            EventOnExtensionEvent?.Invoke(provider, extension, key, value);
        }

        public override void OnExtensionStarted(string provider, string extension)
        {
            EventOnExtensionStarted?.Invoke(provider, extension);
        }

        public override void OnExtensionStopped(string provider, string extension)
        {
            EventOnExtensionStopped?.Invoke(provider, extension);
        }

        public override void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string userAccount)
        {
            EventOnUserAccountUpdated?.Invoke(connection, remoteUid, userAccount);
        }

        public override void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
            EventOnRhythmPlayerStateChanged?.Invoke(state, errorCode);
        }

        public override void OnSnapshotTaken(string channel, uint uid, string filePath, int width, int height, int errCode)
        {
            EventOnSnapshotTaken?.Invoke(channel, uid, filePath, width, height, errCode);
        }
    }
}