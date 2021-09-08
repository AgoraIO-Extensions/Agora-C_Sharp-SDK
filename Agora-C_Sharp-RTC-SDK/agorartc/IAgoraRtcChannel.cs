//  IAgoraRtcChannel.cs
//
//  Created by Yiqing Huang on June 1, 2021.
//  Modified by Yiqing Huang on June 9, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    public abstract class IAgoraRtcChannel : AgoraChannel
    {
    }

    public abstract class AgoraChannel
    {
        public abstract void InitEventHandler(IAgoraRtcChannelEventHandler channelEventHandler);
        public abstract void Dispose();

        [Obsolete(ObsoleteMethodWarning.ReleaseChannelWarning, false)]
        public abstract int ReleaseChannel();

        public abstract int JoinChannel(string token, string info, uint uid, ChannelMediaOptions options);
        public abstract int JoinChannelWithUserAccount(string token, string userAccount, ChannelMediaOptions options);
        public abstract int LeaveChannel();

        [Obsolete(ObsoleteMethodWarning.PublishWarning, false)]
        public abstract int Publish();

        [Obsolete(ObsoleteMethodWarning.UnpublishWarning, false)]
        public abstract int Unpublish();

        public abstract string ChannelId();
        public abstract string GetCallId();
        public abstract int RenewToken(string token);

        [Obsolete(ObsoleteMethodWarning.SetEncryptionSecretWarning, false)]
        public abstract int SetEncryptionSecret(string secret);

        [Obsolete(ObsoleteMethodWarning.SetEncryptionModeWarning, false)]
        public abstract int SetEncryptionMode(string encryptionMode);

        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);
        public abstract int RegisterPacketObserver(IPacketObserver observer);
        public abstract int RegisterMediaMetadataObserver(METADATA_TYPE type);
        public abstract int UnRegisterMediaMetadataObserver(METADATA_TYPE type);
        public abstract int SetMaxMetadataSize(int size);
        public abstract int SendMetadata(Metadata metadata);
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options);
        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);
        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        public abstract int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        public abstract int MuteLocalAudioStream(bool mute);
        public abstract int MuteLocalVideoStream(bool mute);
        public abstract int MuteAllRemoteAudioStreams(bool mute);
        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);
        public abstract int MuteRemoteAudioStream(uint userId, bool mute);
        public abstract int MuteAllRemoteVideoStreams(bool mute);
        public abstract int MuteRemoteVideoStream(uint userId, bool mute);
        public abstract int SetRemoteVideoStreamType(uint userId, REMOTE_VIDEO_STREAM_TYPE streamType);
        public abstract int SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int CreateDataStream(bool reliable, bool ordered);

        public abstract int CreateDataStream(DataStreamConfig config);
        public abstract int SendStreamMessage(int streamId, byte[] data);
        public abstract int AddPublishStreamUrl(string url, bool transcodingEnabled);
        public abstract int RemovePublishStreamUrl(string url);
        public abstract int SetLiveTranscoding(LiveTranscoding transcoding);
        public abstract int AddInjectStreamUrl(string url, InjectStreamConfig config);
        public abstract int RemoveInjectStreamUrl(string url);
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);
        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);
        public abstract int StopChannelMediaRelay();
        public abstract CONNECTION_STATE_TYPE GetConnectionState();
        public abstract int EnableRemoteSuperResolution(uint userId, bool enable);
    }

    public abstract class IAgoraRtcChannelEventHandler
    {
        public virtual void OnChannelWarning(string channelId, int warn, string msg)
        {
        }

        public virtual void OnChannelError(string channelId, int err, string msg)
        {
        }

        public virtual void OnJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
        }

        public virtual void OnRejoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
        }

        public virtual void OnLeaveChannel(string channelId, RtcStats stats)
        {
        }

        public virtual void OnClientRoleChanged(string channelId, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
        }

        public virtual void OnUserJoined(string channelId, uint uid, int elapsed)
        {
        }

        public virtual void OnUserOffline(string channelId, uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        public virtual void OnConnectionLost(string channelId)
        {
        }

        public virtual void OnRequestToken(string channelId)
        {
        }

        public virtual void OnTokenPrivilegeWillExpire(string channelId, string token)
        {
        }

        public virtual void OnRtcStats(string channelId, RtcStats stats)
        {
        }

        public virtual void OnNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
        {
        }

        public virtual void OnRemoteVideoStats(string channelId, RemoteVideoStats stats)
        {
        }

        public virtual void OnRemoteAudioStats(string channelId, RemoteAudioStats stats)
        {
        }

        public virtual void OnRemoteAudioStateChanged(string channelId, uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnAudioPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnAudioSubscribeStateChanged(string channelId, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoSubscribeStateChanged(string channelId, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnUserSuperResolutionEnabled(string channelId, uint uid, bool enabled,
            SUPER_RESOLUTION_STATE_REASON reason)
        {
        }

        public virtual void OnActiveSpeaker(string channelId, uint uid)
        {
        }

        public virtual void OnVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
        {
        }

        public virtual void OnRemoteVideoStateChanged(string channelId, uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnStreamMessage(string channelId, uint uid, int streamId, byte[] data, uint length)
        {
        }

        public virtual void OnStreamMessageError(string channelId, uint uid, int streamId, int code, int missed,
            int cached)
        {
        }

        public virtual void OnChannelMediaRelayStateChanged(string channelId, CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
        }

        public virtual void OnChannelMediaRelayEvent(string channelId, CHANNEL_MEDIA_RELAY_EVENT code)
        {
        }

        public virtual void OnRtmpStreamingStateChanged(string channelId, string url, RTMP_STREAM_PUBLISH_STATE state,
            RTMP_STREAM_PUBLISH_ERROR errCode)
        {
        }

        public virtual void OnRtmpStreamingEvent(string channelId, string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        public virtual void OnTranscodingUpdated(string channelId)
        {
        }

        public virtual void OnStreamInjectedStatus(string channelId, string url, uint uid, int status)
        {
        }

        public virtual void OnLocalPublishFallbackToAudioOnly(string channelId, bool isFallbackOrRecover)
        {
        }

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid, bool isFallbackOrRecover)
        {
        }

        public virtual void OnConnectionStateChanged(string channelId, CONNECTION_STATE_TYPE state,
            CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        public virtual bool OnReadyToSendMetadata(Metadata metadata)
        {
            return true;
        }

        public virtual void OnMetadataReceived(Metadata metadata)
        {
        }
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}