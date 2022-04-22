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
        public abstract int SetAVSyncSource(string channelId, uint uid);
        public abstract int StartRtmpStreamWithoutTranscoding(string url);
        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);
        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);
        public abstract int StopRtmpStream(string url);
    }

    /*
     * The SDK uses IAgoraRtcChannelEventHandler to send IAgoraRtcChannel event notifications to your app.
     */
    public abstract class IAgoraRtcChannelEventHandler
    {
        /*
         * Reports the warning code of IAgoraRtcChannel .
         * @param
         *  warn: Warning codes. 
         *  channelId: The channel ID.
         *  msg: The warning message.
         */
        public virtual void OnChannelWarning(string channelId, int warn, string msg)
        {
        }

        /*
         * The error code IAgoraRtcChannel reported.
         * @param
         *  channelId: The channel ID.
         *  err: The error code. 
         *  msg: The error message.
         */
        public virtual void OnChannelError(string channelId, int err, string msg)
        {
        }

        /*
         * Occurs when a user joins a channel.
         * This callback notifies the application that a user joins a specified channel.
         * @param
         *  channelId: The channel ID.
         *  uid: User ID. If you have specified a user ID in JoinChannel , the ID will be returned here; otherwise, the SDK returns an ID automatically assigned by the Agora server.
         *  elapsed: The time elapsed (in milliseconds) from the local user calling JoinChannel till this event.
         */
        public virtual void OnJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
        }

        /*
         * Occurs when a user rejoins the channel.
         * When a user loses connection with the server because of network problems, the SDK automatically tries to reconnect and triggers this callback upon reconnection.
         * @param
         *  elapsed: Time elapsed (ms) from starting to reconnect until the SDK triggers this
         *  callback.
         *  uid: The ID of the user who rejoins the channel.
         *  channelId: The channel ID.
         */
        public virtual void OnRejoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
        }

        /*
         * Occurs when a user leaves a channel.
         * When a user leaves the channel by using the LeaveChannel method, the SDK uses this callback to notify the app when the user leaves the channel. With this callback, the app gets the channel information, such as the call duration and quality statistics.
         * @param
         *  stats: The statistics of the call, see RtcStats .
         *  channelId: The channel ID.
         */
        public virtual void OnLeaveChannel(string channelId, RtcStats stats)
        {
        }

        /*
         * Occurs when the user role switches in the interactive live streaming.
         * The SDK triggers this callback when the local user changes the user role after joining the channel.
         * @param
         *  newRole: Role that the user switches to: 
         *  CLIENT_ROLE_BROADCASTER (1): Broadcaster.
         *  CLIENT_ROLE_AUDIENCE (2): Audience. CLIENT_ROLE_TYPE .
         *  oldRole: Role that the user switches from: 
         *  CLIENT_ROLE_BROADCASTER (1): Broadcaster.
         *  CLIENT_ROLE_AUDIENCE (2): Audience. CLIENT_ROLE_TYPE .
         *  channelId: The channel ID.
         */
        public virtual void OnClientRoleChanged(string channelId, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
        }

        /*
         * Occurs when a remote user (COMMUNICATION)/ host (LIVE_BROADCASTING) joins the channel.
         * In a communication channel, this callback indicates that a remote user joins the channel. The SDK also triggers this callback to report the existing users in the channel when a user joins the channel.
         *  In a live-broadcast channel, this callback indicates that a host joins the channel. The SDK also triggers this callback to report the existing hosts in the channel when a host joins the channel. Agora recommends limiting the number of hosts to 17. The SDK triggers this callback under one of the following circumstances:
         *  A remote user/host joins the channel by calling the JoinChannel method.
         *  A remote user switches the user role to the host after joining the channel.
         *  A remote user/host rejoins the channel after a network interruption.
         *  The host injects an online media stream into the channel by calling the AddInjectStreamUrl method.
         * @param
         *  uid: The ID of the user or host who joins the channel.
         *  channelId: The channel ID.
         *  elapsed: Time delay (ms) fromthe local user calling JoinChannel until this callback is triggered.
         */
        public virtual void OnUserJoined(string channelId, uint uid, int elapsed)
        {
        }

        /*
         * Occurs when a remote user (COMMUNICATION)/ host (LIVE_BROADCASTING) leaves the channel.
         * There are two reasons for users to become offline:
         *  Leave the channel: When a user/host leaves the channel, the user/host sends a goodbye message. When this message is received, the SDK determines that the user/host leaves the channel.
         *  Drop offline: When no data packet of the user or host is received for a certain period of time (20 seconds for the communication profile, and more for the live broadcast profile), the SDK assumes that the user/host drops offline. A poor network connection may lead to false detections. It's recommended to use the Agora RTM SDK for reliable offline detection.
         * @param
         *  channelId: The channel ID.
         *  reason: Reasons why the user goes offline: USER_OFFLINE_REASON_TYPE . 
         *  uid: The ID of the user who leaves the channel or goes offline.
         */
        public virtual void OnUserOffline(string channelId, uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        /*
         * Occurs when the SDK cannot reconnect to Agora's edge server 10 seconds after its connection to the server is interrupted.
         * The SDK triggers this callback when it cannot connect to the server 10 seconds after calling the JoinChannel method, regardless of whether it is in the channel.
         * @param
         *  channelId: The channel ID.
         */
        public virtual void OnConnectionLost(string channelId)
        {
        }

        /*
         * Occurs when the token expires.
         * When the token expires during a call, the SDK triggers this callback to remind the app to renew the token.
         *  Once you receive this callback, generate a new token on your app server, and call JoinChannel to rejoin the channel.
         * @param
         *  channelId: The channel ID.
         */
        public virtual void OnRequestToken(string channelId)
        {
        }

        /*
         * Occurs when the token expires in 30 seconds.
         * When the token is about to expire in 30 seconds, the SDK triggers this callback to remind the app to renew the token. Upon receiving this callback, generate a new token on your server, and call RenewToken to pass the new token to the SDK.
         * @param
         *  token: The token that expires in 30 seconds.
         *  channelId: The channel ID.
         */
        public virtual void OnTokenPrivilegeWillExpire(string channelId, string token)
        {
        }

        /*
         * Reports the statistics of the current call.
         * The SDK triggers this callback once every two seconds after the user joins the channel.
         * @param
         *  stats: Statistics of the RTC engine, see RtcStats for
         *  details.
         *  
         *  channelId: The channel ID.
         */
        public virtual void OnRtcStats(string channelId, RtcStats stats)
        {
        }

        /*
         * Reports the last mile network quality of each user in the channel.
         * This callback reports the last mile network conditions of each user in the channel. Last mile refers to the connection between the local device and Agora's edge server.
         *  The SDK triggers this callback once every two seconds. If a channel includes multiple users, the SDK triggers this callback as many times.
         * @param
         *  rxQuality: Downlink network quality rating of the user in terms of packet loss rate,
         *  average RTT, and jitter of the downlink network.
         *  QUALITY_UNKNOWN (0): The quality is unknown.
         *  QUALITY_EXCELLENT (1): The quality is excellent.
         *  QUALITY_GOOD (2): The network quality seems excellent, but the bitrate can be slightly lower than excellent.
         *  QUALITY_POOR (3): Users can feel the communication is slightly impaired.
         *  QUALITY_BAD (4): Users cannot communicate smoothly.
         *  QUALITY_VBAD (5): The quality is so bad that users can barely communicate.
         *  QUALITY_DOWN (6): The network is down, and users cannot communicate at all.
         *  For details, see QUALITY_TYPE . 
         *  txQuality: Uplink network quality rating of the user in terms of the transmission bit
         *  rate, packet loss rate, average RTT (Round-Trip Time) and jitter of the
         *  uplink network. This parameter is a quality rating helping you understand
         *  how well the current uplink network conditions can support the selected
         *  video encoder configuration. For example, a 1000 Kbps uplink network may be
         *  adequate for video frames with a resolution of 640 × 480 and a frame rate of
         *  15 fps in the LIVE_BROADCASTING profile, but might be inadequate for
         *  resolutions higher than 1280 × 720.
         *  QUALITY_UNKNOWN (0): The quality is unknown.
         *  QUALITY_EXCELLENT (1): The quality is excellent.
         *  QUALITY_GOOD (2): The network quality seems excellent, but the bitrate can be slightly lower than excellent.
         *  QUALITY_POOR (3): Users can feel the communication is slightly impaired.
         *  QUALITY_BAD (4): Users cannot communicate smoothly.
         *  QUALITY_VBAD (5): The quality is so bad that users can barely communicate.
         *  QUALITY_DOWN (6): The network is down, and users cannot communicate at all.
         *  For details, see QUALITY_TYPE . 
         *  uid: User ID. The network quality of the user with this user ID is
         *  reported.
         *  If the uid is 0, the local network quality is reported.
         *  
         *  channelId: The channel ID.
         */
        public virtual void OnNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
        {
        }

        /*
         * Reports the transport-layer statistics of each remote video stream.
         * Reports the statistics of the video stream from the remote users. The SDK triggers this callback once every two seconds for each remote user. If a channel has multiple users/hosts sending video streams, the SDK triggers this callback as many times.
         * @param
         *  stats: Statistics of the remote video stream. 
         *  channelId: The channel ID.
         */
        public virtual void OnRemoteVideoStats(string channelId, RemoteVideoStats stats)
        {
        }

        /*
         * Reports the transport-layer statistics of each remote audio stream.
         * The SDK triggers this callback once every two seconds for each remote user who is sending audio streams. If a channel includes multiple remote users, the SDK triggers this callback as many times.
         * @param
         *  stats: The statistics of the received remote audio streams. See RemoteAudioStats .
         *  channelId: The channel ID.
         */
        public virtual void OnRemoteAudioStats(string channelId, RemoteAudioStats stats)
        {
        }

        /*
         * Occurs when the remote audio state changes.
         * When the audio state of a remote user (in the voice/video call channel) or host (in the live streaming channel) changes, the SDK triggers this callback to report the current state of the remote audio stream.
         *  This callback does not work properly when the number of users (in the voice/video call channel) or hosts (in the live streaming channel) in the channel exceeds 17.
         * @param
         *  channelId: The channel ID.
         *  reason: The reason of the remote audio state change, see REMOTE_AUDIO_STATE_REASON .
         *  state: The state of the remote audio, see REMOTE_AUDIO_STATE .
         *  uid: The ID of the remote user whose audio state changes.
         *  elapsed: Time elapsed (ms) from the local user calling the JoinChannel method until the SDK triggers this callback.
         */
        public virtual void OnRemoteAudioStateChanged(string channelId, uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        /*
         * Occurs when the audio publishing state changes.
         * @param
         *  newState: For the current publishing state, see STREAM_PUBLISH_STATE.
         *  elapseSinceLastState: The time elapsed (ms) from the previous state to the current state.
         *  oldState: For the previous publishing state, see STREAM_PUBLISH_STATE .
         *  channelId: The channel ID.
         */
        public virtual void OnAudioPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        /*
         * Occurs when the video publishing state changes.
         * @param
         *  newState: For the current publishing state, see STREAM_PUBLISH_STATE.
         *  elapseSinceLastState: The time elapsed (ms) from the previous state to the current state.
         *  oldState: For the previous publishing state, see STREAM_PUBLISH_STATE .
         *  channelId: The channel ID.
         */
        public virtual void OnVideoPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        /*
         * Occurs when the audio subscribing state changes.
         * @param
         *  newState: The current subscribing status, see STREAM_SUBSCRIBE_STATE for details.
         *  elapseSinceLastState: The time elapsed (ms) from the previous state to the current state.
         *  oldState: The previous subscribing status, see STREAM_SUBSCRIBE_STATE 
         *  for details.
         *  uid: The ID of the remote user.
         *  channelId: The channel ID.
         */
        public virtual void OnAudioSubscribeStateChanged(string channelId, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        /*
         * Occurs when the video subscribing state changes.
         * @param
         *  newState: The current subscribing status, see STREAM_SUBSCRIBE_STATE for details.
         *  elapseSinceLastState: The time elapsed (ms) from the previous state to the current state.
         *  oldState: The previous subscribing status, see STREAM_SUBSCRIBE_STATE 
         *  for details.
         *  uid: The ID of the remote user.
         *  channelId: The channel ID.
         */
        public virtual void OnVideoSubscribeStateChanged(string channelId, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        /*
         * Reports whether the super resolution feature is successfully enabled.
         * After calling EnableRemoteSuperResolution , the SDK triggers the callback to report whether super resolution is successfully enabled. If it is not successfully enabled, use reason for troubleshooting.
         * @param
         *  channelId: The channel ID.
         *  reason: The reason why super resolution algorithm is not successfully enabled. For details, see SUPER_RESOLUTION_STATE_REASON .
         *  enabled: Whether super resolution is successfully enabled:
         *  true: Super resolution is successfully enabled.
         *  false: Super resolution is not successfully enabled.
         *  
         *  uid: The ID of the remote user.
         */
        public virtual void OnUserSuperResolutionEnabled(string channelId, uint uid, bool enabled,
            SUPER_RESOLUTION_STATE_REASON reason)
        {
        }

        /*
         * Occurs when the most active speaker is detected.
         * After a successful call of EnableAudioVolumeIndication , the SDK continuously detects which remote user has the loudest volume. During the current period, the remote user, who is detected as the loudest for the most times, is the most active user.
         *  When the number of users exceeds two (included) and an active speaker is detected, the SDK triggers this callback and reports the uid of the most active speaker.
         *  If the most active speaker remains the same, the SDK triggers the OnActiveSpeaker callback only once.
         *  If the most active speaker changes to another user, the SDK triggers this callback again and reports the uid of the new active speaker.
         * @param
         *  uid: The user ID of the most active speaker.
         *  channelId: The channel ID.
         */
        public virtual void OnActiveSpeaker(string channelId, uint uid)
        {
        }

        /*
         * Occurs when the video size or rotation of a specified user changes.
         * @param
         *  width: The width (pixels) of the video stream.
         *  rotation: The rotation information. The value range is [0,360).
         *  height: The height (pixels) of the video stream.
         *  uid: The ID of the user whose video size or rotation changes.
         *  uid is 0 for the local user.
         *  channelId: The channel ID.
         */
        public virtual void OnVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
        {
        }

        /*
         * Occurs when the remote video state changes.
         * This callback does not work properly when the number of users (in the voice/video call channel) or hosts (in the live streaming channel) in the channel exceeds 17.
         * @param
         *  channelId: The channel ID.
         *  reason:  The reason for the remote video state
         *  change, see REMOTE_VIDEO_STATE_REASON . 
         *  state:  The state of the remote video, see 
         *  REMOTE_VIDEO_STATE . 
         *  uid: The ID of the remote user whose video state changes.
         *  elapsed: Time elapsed (ms) from the local user calling the JoinChannel method until the SDK triggers this callback.
         */
        public virtual void OnRemoteVideoStateChanged(string channelId, uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        /*
         * Occurs when the local user receives the data stream from the remote user.
         * The SDK triggers this callback when the local user receives the stream message that the remote user sends by calling the SendStreamMessage method.
         * @param
         *  uid: The ID of the remote user sending the message.
         *  data: The data received.
         *  length: The data length (byte).
         *  streamId: The stream ID of the received message.
         *  channelId: The channel ID.
         */
        public virtual void OnStreamMessage(string channelId, uint uid, int streamId, byte[] data, uint length)
        {
        }

        /*
         * Occurs when the local user does not receive the data stream from the remote user.
         * The SDK triggers this callback when the local user fails to receive the stream message that the remote user sends by calling the SendStreamMessage method.
         * @param
         *  cached: Number of incoming cached messages when the data stream is interrupted.
         *  streamId: The stream ID of the received message.
         *  missed: The number of lost messages.
         *  code: The error code.
         *  uid: The ID of the remote user sending the message.
         *  channelId: The channel ID.
         */
        public virtual void OnStreamMessageError(string channelId, uint uid, int streamId, int code, int missed,
            int cached)
        {
        }

        /*
         * Occurs when the state of the media stream relay changes.
         * The SDK returns the state of the current media relay with any error message.
         * @param
         *  code:  The error code of the channel media
         *  replay. For details, see CHANNEL_MEDIA_RELAY_ERROR . 
         *  state:  The state code. For details, see CHANNEL_MEDIA_RELAY_STATE . 
         *  channelId: The channel ID.
         */
        public virtual void OnChannelMediaRelayStateChanged(string channelId, CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
        }

        /*
         * Reports events during the media stream relay.
         * @param
         *  code: The event code of channel media relay. See CHANNEL_MEDIA_RELAY_EVENT .
         *  
         *  channelId: The channel ID.
         */
        public virtual void OnChannelMediaRelayEvent(string channelId, CHANNEL_MEDIA_RELAY_EVENT code)
        {
        }

        /*
         * Occurs when the media push state changes.
         * When the CDN live streaming state changes, the SDK triggers this callback to report the current state and the reason why the state has changed. When exceptions occur, you can troubleshoot issues by referring to the detailed error descriptions in the error code parameter.
         * @param
         *  channelId: The channel ID.
         *  errCode: The detailed error information for the media push. See RTMP_STREAM_PUBLISH_ERROR_TYPE .
         *  url: The URL address where the state of the media push changes.
         *  state: The current state of the media push. See RTMP_STREAM_PUBLISH_STATE . When the streaming state is RTMP_STREAM_PUBLISH_STATE_FAILURE (4), you can view the error information in the errorCode parameter.
         */
        public virtual void OnRtmpStreamingStateChanged(string channelId, string url, RTMP_STREAM_PUBLISH_STATE state,
            RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
        }

        /*
         * Reports events during the media push.
         * @param
         *  url: The URL for media push.
         *  eventCode: The event code of media push. See RTMP_STREAMING_EVENT for details.
         *  channelId: The channel ID.
         */
        public virtual void OnRtmpStreamingEvent(string channelId, string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        /*
         * Occurs when the publisher's transcoding is updated.
         * If you call the SetLiveTranscoding
         *  method to set the LiveTranscoding class for the first time, the
         *  SDK does not trigger this callback.
         *  When the LiveTranscoding class in the SetLiveTranscoding method updates, the SDK triggers the OnTranscodingUpdated callback to report the update information.
         * @param
         *  channelId: The channel ID.
         */
        public virtual void OnTranscodingUpdated(string channelId)
        {
        }

        /*
         * Occurs when a media stream URL address is added to the interactive live streaming.
         * @param
         *  status: State of the externally injected stream: INJECT_STREAM_STATUS .
         *  uid: User ID.
         *  url: The URL address of the externally injected stream.
         *  channelId: The channel ID.
         */
        public virtual void OnStreamInjectedStatus(string channelId, string url, uint uid, int status)
        {
        }

        /*
         * Occurs when the published media stream falls back to an audio-only stream.
         * If you call SetLocalPublishFallbackOption and set option as STREAM_FALLBACK_OPTION_AUDIO_ONLY, the SDK triggers this callback when the remote media stream falls back to audio-only mode due to poor uplink conditions, or when the remote media stream switches back to the video after the uplink network condition improves.
         *  If the local stream falls back to the audio-only stream, the remote user receives the OnUserMuteVideo callback.
         * @param
         *  isFallbackOrRecover: true: The published stream falls
         *  back to audio-only due to poor network conditions.
         *  false: The published stream switches
         *  back to the video after the network conditions improve. 
         *  channelId: The channel ID.
         */
        public virtual void OnLocalPublishFallbackToAudioOnly(string channelId, bool isFallbackOrRecover)
        {
        }

        /*
         * Occurs when the remote media stream falls back to the audio-only stream due to poor network conditions or switches back to the video stream after the network conditions improve.
         * If you call SetRemoteSubscribeFallbackOption and set option as STREAM_FALLBACK_OPTION_AUDIO_ONLY, the SDK triggers this callback when the remote media stream falls back to audio-only mode due to poor uplink conditions, or when the remote media stream switches back to the video after the downlink network condition improves.
         *  Once the remote media stream switches to the low-quality stream due to poor network conditions, you can monitor the stream switch between a high-quality and low-quality stream in the OnRemoteVideoStats callback.
         * @param
         *  isFallbackOrRecover: true: The remotely subscribed media stream falls back to audio-only due to poor network conditions.
         *  false: The remotely subscribed media stream switches back to the video stream after the network conditions improved. 
         *  uid: The user ID of the remote user.
         *  channelId: The channel ID.
         */
        public virtual void OnRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid, bool isFallbackOrRecover)
        {
        }

        /*
         * Occurs when the network connection state changes.
         * When the network connection state changes, the SDK triggers this callback and reports the current connection state and the reason for the change.
         * @param
         *  channelId: The channel ID.
         *  reason: The reason for a connection state change. For details, see CONNECTION_CHANGED_REASON_TYPE . 
         *  state: The current connection state. For details, see CONNECTION_STATE_TYPE .
         *  
         */
        public virtual void OnConnectionStateChanged(string channelId, CONNECTION_STATE_TYPE state,
            CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        /*
         * Occurs when the SDK is ready to send Metadata .
         * This callback is triggered when the SDK is ready to receive and send Metadata. After receiving this callback, you can call SendMetadata to send the media metadata.
         * @param
         *  metadata: Media metadata See Metadata .
         */
        public virtual bool OnReadyToSendMetadata(Metadata metadata)
        {
            return true;
        }

        /*
         * Occurs when the local user receives Metadata .
         * @param
         *  metadata: The received metadata. See Metadata .
         */
        public virtual void OnMetadataReceived(Metadata metadata)
        {
        }

        public virtual void OnClientRoleChangeFailed(string channelId, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole) 
        {
        }

        /*
         * Reports the proxy connection state.
         * You can use this callback to listen for the state of the SDK connecting to a proxy. For example, when a user calls SetCloudProxy and joins a channel successfully, the SDK triggers this callback to report the user ID, the proxy type connected, and the time elapsed from the user calling JoinChannel until this callback is triggered.
         * @param
         *  proxyType: The proxy type connected. See CLOUD_PROXY_TYPE .
         *  elapsed: The time elapsed (ms) from the user calling JoinChannel [1/2] until this callback is triggered.
         *  channelId: The channel ID.
         *  localProxyIp: Reserved for future use.
         *  uid: The user ID.
         */
        public virtual void OnProxyConnected(string channelId, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
        }
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}
