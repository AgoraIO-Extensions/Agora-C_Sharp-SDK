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

    /**
     * Provides methods that enable real-time communications in an channel.
     * Call CreateChannel to create an IAgoraRtcChannel object.
     */
    public abstract class AgoraChannel
    {
        public abstract void InitEventHandler(IAgoraRtcChannelEventHandler channelEventHandler);
        public abstract void Dispose();

        [Obsolete(ObsoleteMethodWarning.ReleaseChannelWarning, false)]
        public abstract int ReleaseChannel();

        /**
         * Joins the channel with a user ID.
         * Once the user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. If you do not want to subscribe to a specified stream or all remote streams, call the mute methods accordingly. If you are already in a channel, you cannot rejoin it with the user ID.
         *  We recommend using different UIDs for different channels.
         *  If you want to join the same channel from different devices, ensure that the user IDs in all devices are different.
         * @param
         *  uid: User ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer with a value ranging from 1 to 232 -1. If the user ID is not assigned (or set as 0), the SDK assigns a user ID and reports it in the OnJoinChannelSuccess callback. Your app must maintain this user ID.
         *  info: Reserved for future use.
         *  
         *  options: The channel media options. 
         *  
         *  token: The token generated on your server for authentication. See Authenticate Your Users with Token.
         *  Ensure that the App ID used for creating the token is the same App ID used by the Initialize method for initializing the RTC engine. 
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure. 
         *  -2 (ERR_INVALID_ARGUMENT): The parameter is invalid.
         *  -3(ERR_NOT_READY): The SDK fails to be initialized. You can try re-initializing the SDK.
         *  -5(ERR_REFUSED): The request is rejected. This may be caused by the following: 
         *  You have created an IAgoraRtcChannel object with the same channel name.
         *  You have joined a channel by using IAgoraRtcChannel and published a stream in the IAgoraRtcChannel channel. -7(ERR_NOT_INITIALIZED): The SDK is not initialized before calling this method. Initialize the IAgoraRtcEngine instance before calling this method.
         *  -17(ERR_JOIN_CHANNEL_REJECTED): The request to join the channel is rejected. The SDK supports joining only one IAgoraRtcEngine channel at a time. Therefore, the SDK returns this error code when a user who has already joined an IAgoraRtcEngine channel calls the joining channel method of the IAgoraRtcEngine class with a valid channel name.
         */
        public abstract int JoinChannel(string token, string info, uint uid, ChannelMediaOptions options);
        /**
         * Joins the channel with a user account.
         * Once the user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. If you do not want to subscribe to a specified stream or all remote streams, call the mute methods accordingly. If you are already in a channel, you cannot rejoin it with the user ID.
         *  We recommend using different user accounts for different channels.
         *  If you want to join the same channel from different devices, ensure that the user accounts in all devices are different.
         * @param
         *  userAccount: The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are (89 in total): The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  All numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
         *  options: The channel media options. 
         *  
         *  token: The token generated on your server for authentication. See Authenticate Your Users with Token.
         *  Ensure that the App ID used for creating the token is the same App ID used by the Initialize method for initializing the RTC engine. 
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure. 
         *  -2 (ERR_INVALID_ARGUMENT): The parameter is invalid.
         *  -3(ERR_NOT_READY): The SDK fails to be initialized. You can try re-initializing the SDK.
         *  -5(ERR_REFUSED): The request is rejected. This may be caused by the following: 
         *  You have created an IAgoraRtcChannel object with the same channel name.
         *  You have joined a channel by using IAgoraRtcChannel and published a stream in the IAgoraRtcChannel channel. -7(ERR_NOT_INITIALIZED): The SDK is not initialized before calling this method. Initialize the IAgoraRtcEngine instance before calling this method.
         *  -17(ERR_JOIN_CHANNEL_REJECTED): The request to join the channel is rejected. The SDK supports joining only one IAgoraRtcEngine channel at a time. Therefore, the SDK returns this error code when a user who has already joined an IAgoraRtcEngine channel calls the joining channel method of the IAgoraRtcEngine class with a valid channel name.
         */
        public abstract int JoinChannelWithUserAccount(string token, string userAccount, ChannelMediaOptions options);
        /**
         * Leaves a channel.
         * This method lets the user leave the channel, for example, by hanging up or exiting the call. This method releases all resources related to the session. This method call is asynchronous, and the user has not left the channel when the method call returns.
         *  After calling JoinChannel , you must call LeaveChannel to end the call, otherwise the next call cannot be started.
         *  No matter whether you are currently in a call or not, you can call LeaveChannel without side effects.
         *  A successful call of this method triggers the following callbacks: 
         *  The local client: OnLeaveChannel .
         *  The remote client: OnUserOffline , if the user
         *  joining the channel is in the COMMUNICATION profile, or is a host in the
         *  LIVE_BROADCASTING profile. 
         *  If you call the LeaveChannel method immediately after calling Dispose , the SDK will not be able to trigger the OnLeaveChannel callback.
         *  If you call the LeaveChannel method during a CDN live streaming, the SDK automatically calls the RemovePublishStreamUrl method.
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure.
         *  -1(ERR_FAILED): A general error occurs (no specified reason).
         *  -2 (ERR_INVALID_ARGUMENT): The parameter is invalid.
         *  -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
         */
        public abstract int LeaveChannel();

        /**
         * Publish local audio and video streams to the channel.
         * The call of this method must meet the following requirements, otherwise the SDK returns -5(ERR_REFUSED):
         *  This method only supports publishing audio and video streams to the channel corresponding to the current IAgoraRtcChannel object.
         *  In the interactive live streaming channel, only a host can call this method. To switch the client role, call SetClientRole [2/2] of the current IAgoraRtcChannel object.
         *  You can publish a stream to only one channel at a time. For details on joining multiple channels, see the advanced guide Join Multiple Channels.
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -5 (ERR_REFUSED): The request is rejected.
         */
        [Obsolete(ObsoleteMethodWarning.PublishWarning, false)]
        public abstract int Publish();

        /**
         * Stops publishing a stream to the channel.
         * If you call this method in a channel where you are not publishing streams, the SDK returns
         *  -5 (ERR_REFUSED).
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -5 (ERR_REFUSED): The request is rejected.
         */
        [Obsolete(ObsoleteMethodWarning.UnpublishWarning, false)]
        public abstract int Unpublish();

        /**
         * Gets the current channel ID.
         * @return
         * The current channel ID, if the method call succeeds.
         *  The empty string "", if the method call fails.
         */
        public abstract string ChannelId();
        /**
         * Retrieves the call ID.
         * When a user joins a channel on a client, a callId is generated to identify the call from the client. Some methods, such as Rate and Complain , must be called after the call ends to submit feedback to the SDK. These methods require the callId parameter.
         *  Call this method after joining a channel.
         * @return
         * The current call ID.
         */
        public abstract string GetCallId();
        /**
         * Gets a new token when the current token expires after a period of time.
         * Passes a new token to the SDK. A token expires after a certain period of time. The app should get a new token and call this method to pass the token to the SDK. Failure to do so results in the SDK disconnecting from the server.
         *  The SDK triggers the OnTokenPrivilegeWillExpire callback.
         *  The OnConnectionStateChanged callback reports CONNECTION_CHANGED_TOKEN_EXPIRED(9).
         * @param
         *  token: The new token.
         */
        public abstract int RenewToken(string token);

        /**
         * Enables built-in encryption with an encryption password before users join a channel.
         * Do not use this method for CDN live streaming.
         *  For optimal transmission, ensure that the encrypted data size does not exceed the original data size + 16 bytes. 16 bytes is the maximum padding size for AES encryption. Before joining the channel, you need to call this method to set the secret parameter to enable the built-in encryption. All users in the same channel should use the same secret. The secret is automatically cleared once a user leaves the channel. If you do not specify the secret or secret is set as null, the built-in encryption is disabled. Deprecated:
         *  Please use the EnableEncryption method instead.
         * @param
         *  secret: The encryption password.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetEncryptionSecretWarning, false)]
        public abstract int SetEncryptionSecret(string secret);

        /**
         * Sets the built-in encryption mode.
         * The Agora SDK supports built-in encryption, which is set to the AES-128-XTS mode by default. Call this method to use other encryption modes. All users in the same channel must use the same encryption mode and secret. Refer to the information related to the AES encryption algorithm on the differences between the encryption modes. Deprecated:
         *  Please use the EnableEncryption method instead. Before calling this method, please call SetEncryptionSecret to enable the built-in encryption function.
         * @param
         *  encryptionMode: Encryption mode.
         *  "aes-128-xts": 128-bit AES encryption, XTS mode.
         *  "aes-128-ecb": 128-bit AES encryption, ECB mode.
         *  "aes-256-xts": 256-bit AES encryption, XTS mode.
         *  "sm4-128-ecb": 128-bit SM4 encryption, ECB mode.
         *  "aes-128-gcm": 128-bit AES encryption, GCM mode.
         *  "aes-256-gcm": 256-bit AES encryption, GCM mode.
         *  "": When setting as NULL, the encryption mode is set as "aes-128-xts" by default. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetEncryptionModeWarning, false)]
        public abstract int SetEncryptionMode(string encryptionMode);

        /**
         * Enables/Disables the built-in encryption.
         * In scenarios requiring high security, Agora recommends calling this method to enable the built-in encryption before joining a channel.
         *  All users in the same channel must use the same encryption mode and encryption key. After the user leaves the channel, the SDK automatically disables the built-in encryption. To enable the built-in encryption, call this method before the user joins the channel again.
         *  If you enable the built-in encryption, you cannot use the media push function.
         * @param
         *  enabled: Whether to enable built-in encryption:
         *  true: Enable the built-in encryption.
         *  false: Disable the built-in encryption. 
         *  config: Built-in encryption configurations. See EncryptionConfig for details.
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -2: An invalid parameter is used. Set the parameter with a valid value.
         *  -4: The encryption mode is incorrect or the SDK fails to load the external encryption library. Check the enumeration or reload the external encryption library.
         *  -7: The SDK is not initialized. Initialize the IAgoraRtcEngine instance before calling this method.
         */
        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);
        /**
         * Registers a packet observer.
         * Call this method registers a packet observer. When the Agora SDK triggers callbacks registered by IPacketObserver for voice or video packet transmission, you can call this method to process the packets, such as encryption and decryption. The size of the packet sent to the network after processing should not exceed 1200 bytes, otherwise, the SDK may fail to send the packet.
         *  Ensure that both receivers and senders call this method; otherwise, you may meet undefined behaviors such as no voice and black screen.
         *  When you use media push, recording, or storage functions, Agora doesn't recommend calling this method.
         *  Call this method before joining a channel.
         * @param
         *  observer:  IPacketObserver .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int RegisterPacketObserver(IPacketObserver observer);
        /**
         * Registers the metadata observer.
         * Call this method before JoinChannel .
         *  This method applies only to interactive live streaming.
         * @param
         *  type: The metadata type. The SDK currently only supports VIDEO_METADATA. See METADATA_TYPE .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int RegisterMediaMetadataObserver(METADATA_TYPE type);
        /**
         * Unregisters the media metadata observer.
         * @param
         *  type: The metadata type. The SDK currently only supports VIDEO_METADATA. For details, see METADATA_TYPE .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int UnRegisterMediaMetadataObserver(METADATA_TYPE type);
        /**
         * Sets the maximum size of the media metadata.
         * After calling RegisterMediaMetadataObserver , you can call this method to set the maximum size of the media metadata.
         * @param
         *  size: The maximum size of media metadata.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetMaxMetadataSize(int size);
        /**
         * Sends media metadata.
         * After a successful method call of RegisterMediaMetadataObserver , the SDK triggers the OnReadyToSendMetadata callback, and then you can call this method to send media metadata.
         *  If the metadata is sent successfully, the SDK triggers the OnMetadataReceived callback on the receiver.
         * @param
         *  metadata: Media metadata. See Metadata .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SendMetadata(Metadata metadata);
        /**
         * Sets the client role.
         * You can call this method either before or after joining the channel to set the user role as audience or host.
         *  If you call this method to switch the user role after joining the channel, the SDK triggers the following callbacks:The local client: OnClientRoleChanged .The remote client: OnUserJoined or OnUserOffline (USER_OFFLINE_BECOME_AUDIENCE).
         *  This method applies only to interactive live streaming.
         * @param
         *  role: The user role. See CLIENT_ROLE_TYPE for details.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -1: A general error occurs (no specified reason).
         *  -2: The parameter is invalid.
         *  -7: The SDK is not initialized.
         */
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);
        /**
         * Sets the user role and level in an interactive live streaming channel.
         * You can call this method either before or after joining the channel to set the user role as audience or host.
         *  If you call this method to switch the user role after joining the channel, the SDK triggers the following callbacks:
         *  The local client: OnClientRoleChanged .
         *  The remote client: OnUserJoined or OnUserOffline . 
         *  This method only takes effect when the channel profile is live interactive streaming (when the profile parameter in SetChannelProfile set as CHANNEL_PROFILE_LIVE_BROADCASTING).
         * @param
         *  role: The user role in the interactive live streaming. For details, see CLIENT_ROLE_TYPE .
         *  options: The detailed options of a user, including the user level. See ClientRoleOptions for details.
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -1: A general error occurs (no specified reason).
         *  -2: The parameter is invalid.
         *  -5: The request is rejected.
         *  -7: The SDK is not initialized.
         */
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options);
        /**
         * Prioritizes a remote user's stream.
         * Prioritizes a remote user's stream. The SDK ensures the high-priority user gets the best possible stream quality. The SDK ensures the high-priority user gets the best possible stream quality. The SDK supports setting only one user as high priority.
         *  Ensure that you call this method before joining a channel.
         * @param
         *  uid: The ID of the remote user.
         *  userPriority: The priority of the remote user. See PRIORITY_TYPE .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);
        /**
         * Sets the 2D position (the position on the horizontal plane) of the remote user's voice.
         * This method sets the 2D position and volume of a remote user, so that the local user can easily hear and identify the remote user's position.
         *  When the local user calls this method to set the voice position of a remote user, the voice difference between the left and right channels allows the local user to track the real-time position of the remote user, creating a sense of space. This method applies to massive multiplayer online games, such as Battle Royale games. For this method to work, enable stereo panning for remote users by calling the EnableSoundPositionIndication method before joining a channel.
         *  For the best voice positioning, Agora recommends using a wired headset.
         *  Call this method after joining a channel.
         * @param
         *  uid: The user ID of the remote user.
         *  pan: The voice position of the remote user. The value ranges from -1.0 to 1.0:
         *  0.0: (Default) The remote voice comes from the front.
         *  -1.0: The remote voice comes from the left.
         *  1.0: The remote voice comes from the right. 
         *  gain: The volume of the remote user. The value ranges from 0.0 to 100.0. The default value is 100.0 (the original volume of the remote user). The smaller the value, the lower the volume.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        /**
         * Updates the display mode of the video view of a remote user.
         * Since
         *  v3.0.0 After initializing the video view of a remote user, you can call this method to update its rendering and mirror modes. This method affects only the video view that the local user sees. Please call this method after initializing the remote view by calling the SetupRemoteVideo method.
         *  During a call, you can call this method as many times as necessary to update the display mode of the video view of a remote user.
         * @param
         *  userId: The ID of the remote user.
         *  
         *  renderMode: The rendering mode of the remote user view. For details, see RENDER_MODE_TYPE .
         *  
         *  mirrorMode: The mirror mode of the remote user view. For details, see VIDEO_MIRROR_MODE_TYPE .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode);

        /**
         * Stops or resumes subscribing to the audio streams of all remote users by default.
         * Call this method after joining a channel. After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all subsequent users. Deprecated:
         *  This method is deprecated. 
         *  If you need to resume subscribing to the audio streams of remote users in the channel after calling this method, do the following: If you need to resume subscribing to the audio stream of a specified user, call MuteRemoteAudioStream (false), and specify the user ID.
         *  If you need to resume subscribing to the audio streams of multiple remote users, call MuteRemoteAudioStream (false) multiple times.
         * @param
         *  mute: Whether to stop subscribing to the audio streams of all remote users by default.
         *  true: Stop subscribing to the audio streams of all remote users by default.
         *  false: (Default) Subscribe to the audio streams of all remote users by default. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        /**
         * Stops or resumes subscribing to the video streams of all remote users by default.
         * Call this method after joining a channel. After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all subsequent users. Deprecated:
         *  This method is deprecated. 
         *  If you need to resume subscribing to the video streams of remote users in the channel, do the following: If you need to resume subscribing to a single user, call MuteRemoteVideoStream (false) and specify the ID of the remote user you want to subscribe to.
         *  If you want to resume subscribing to multiple users, call MuteRemoteVideoStream(false) multiple times.
         * @param
         *  mute: Whether to stop subscribing to the audio streams of all remote users by default.
         *  true: Stop subscribing to the audio streams of all remote users by default.
         *  false: (Default) Resume subscribing to the audio streams of all remote users by default. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        public abstract int MuteLocalAudioStream(bool mute);
        public abstract int MuteLocalVideoStream(bool mute);
        /**
         * Stops or resumes subscribing to the audio streams of all remote users.
         * As of v3.3.0, after successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users. Call this method after joining a channel.
         * @param
         *  mute: Whether to subscribe to the audio streams of all remote users:
         *  true: Do not subscribe to the audio streams of all remote users.
         *  false: (Default) Subscribe to the audio streams of all remote users by default. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int MuteAllRemoteAudioStreams(bool mute);
        /**
         * Adjusts the playback signal volume of a specified remote user.
         * You can call this method to adjust the playback volume of a specified remote user. To adjust the playback volume of different remote users, call the method as many times, once for each remote user. Call this method after joining a channel.
         *  The playback volume here refers to the mixed volume of a specified remote user.
         * @param
         *  volume: Audio mixing volume. The value ranges between 0 and 100. The default value is 100, the original volume.
         *  uid: The ID of the remote user.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);
        /**
         * Stops or resumes subscribing to the audio stream of a specified user.
         * Call this method after joining a channel.
         *  See recommended settings in Set the Subscribing State.
         * @param
         *  userId: The user ID of the specified user.
         *  mute: Whether to stop subscribing to the audio stream of the specified user. true: Stop subscribing to the audio stream of the specified user.
         *  false: (Default) Subscribe to the audio stream of the specified user. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int MuteRemoteAudioStream(uint userId, bool mute);
        /**
         * Stops or resumes subscribing to the video streams of all remote users.
         * As of v3.3.0, after successfully calling this method, the local user stops or resumes subscribing to the video streams of all remote users, including all subsequent users. Call this method after joining a channel.
         *  See recommended settings in Set the Subscribing State.
         * @param
         *  mute: Whether to stop subscribing to the video streams of all remote users.
         *  true: Stop subscribing to the video streams of all remote users.
         *  false: (Default) Subscribe to the audio streams of all remote users by default. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int MuteAllRemoteVideoStreams(bool mute);
        /**
         * Stops or resumes subscribing to the video stream of a specified user.
         * Call this method after joining a channel.
         *  See recommended settings in Set the Subscribing State.
         * @param
         *  userId: The ID of the specified user.
         *  mute: Whether to stop subscribing to the video stream of the specified user.
         *  true: Stop subscribing to the video streams of the specified user.
         *  false: (Default) Subscribe to the video stream of the specified user. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int MuteRemoteVideoStream(uint userId, bool mute);
        /**
         *  Sets the stream type of the remote video.
         * The method result returns in the OnApiCallExecuted callback.
         *  By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream. Under limited network conditions, if the publisher has not disabled the dual-stream mode using EnableDualStreamMode (false), the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or the low-quality video stream (the low resolution, and low bitrate video stream). The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate.
         *  Call this method after joining a channel. If you call both SetRemoteVideoStreamType and SetRemoteDefaultVideoStreamType , the setting of SetRemoteVideoStreamType takes effect.
         * @param
         *  userId: User ID.
         *  streamType: The video stream type: REMOTE_VIDEO_STREAM_TYPE .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRemoteVideoStreamType(uint userId, REMOTE_VIDEO_STREAM_TYPE streamType);
        /**
         * Sets the default stream type of remote video streams.
         * The result of this method returns in the OnApiCallExecuted callback.
         *  By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream.
         *  Under limited network conditions, if the publisher has not disabled the dual-stream mode using (),the receiver can choose to receive either the high-quality video stream or the low-quality video stream. The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate. EnableDualStreamMode false
         *  Call this method after joining a channel. If you call both SetRemoteVideoStreamType and SetRemoteDefaultVideoStreamType, the setting of SetRemoteVideoStreamType takes effect.
         * @param
         *  streamType: The default stream type of the remote video, see REMOTE_VIDEO_STREAM_TYPE .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType);

        /**
         * Creates a data stream.
         * Call this method after joining a channel.
         *  Agora does not support setting reliable as true and ordered as true. Each user can create up to five data streams during the lifecycle of IAgoraRtcEngine . Deprecated:
         *  Please use CreateDataStream [2/2] instead.
         * @param
         *  ordered: Whether or not the recipients receive the data stream in the sent order:
         *  true: The recipients receive the data in the sent order.
         *  false: The recipients do not receive the data in the sent order.
         *  
         *  reliable: Whether or not the data stream is reliable:
         *  true: The recipients receive the
         *  data from the sender within five seconds. If the recipient does not
         *  receive the data within five seconds, the SDK triggers the OnStreamMessageError callback and returns an
         *  error code.
         *  false: There is no guarantee that
         *  the recipients receive the data stream within five seconds and no
         *  error message is reported for any delay or missing data stream. 
         * @return
         * ID of the created data stream, if the method call succeeds.
         *  < 0: Failure. You can refer to Error Codes and Warning Codes for troubleshooting.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int CreateDataStream(bool reliable, bool ordered);

        /**
         * Creates a data stream.
         * Compared with CreateDataStream [1/2] [1/2], this method does not support data reliability. If a data packet is not received five seconds after it was sent, the SDK directly discards the data.
         *  Creates a data stream. Each user can create up to five data streams in a single channel.
         * @param
         *  config: The configurations for the data stream. 
         * @return
         * ID of the created data stream, if the method call succeeds.
         *  < 0: Failure. You can refer to Error Codes and Warning Codes for troubleshooting.
         */
        public abstract int CreateDataStream(DataStreamConfig config);
        /**
         * Sends data stream messages.
         * Sends data stream messages to all users in a channel. The SDK has the following restrictions on this method:Up to 30 packets can be sent per second in a channel with each packet having a maximum size of 1 KB.Each client can send up to 6 KB of data per second.Each user can have up to five data streams simultaneously.
         *  A successful method call triggers the OnStreamMessage callback on the remote client, from which the remote user gets the stream message. A failed method call triggers the OnStreamMessageError callback on the remote client. Ensure that you call CreateDataStream [2/2] to create a data channel before calling this method.
         *  In live streaming scenarios, this method only applies to hosts.
         * @param
         *  streamId: The data stream ID. You can get the data stream ID by calling CreateDataStream [2/2].
         *  data: The message to be sent.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SendStreamMessage(int streamId, byte[] data);
        /**
         *  Publishes the local stream to a specified CDN live streaming URL. 
         * Call this method after joining a channel.
         *  Ensure that the media push function is enabled. 
         *  This method takes effect only when you are a host in live interactive streaming.
         *  This method adds only one streaming URL to the CDN each time it is called. To push multiple URLs, call this method multiple times.
         *  Agora only supports pushing media streams to the CDN in RTMPS protocol when you enable transcoding. Deprecated: This method is deprecated. 
         *  After calling this method, you can push media streams in RTMP or RTMPS protocol to the CDN. The SDK triggers the 
         *  OnRtmpStreamingStateChanged 
         *  callback on the local client to report the state of adding a local stream to the CDN.
         * @param
         *  url: The media push URL in the RTMP or RTMPS format. The maximum length of this parameter is 1024 bytes. The URL address must not contain special characters, such as Chinese language characters.
         *  transcodingEnabled: Whether to enable transcoding. Transcoding in a CDN live streaming converts the audio and video streams before pushing them to the CDN server. It applies to scenarios where a channel has multiple broadcasters and composite layout is needed.
         *  true: Enable transcoding.
         *  false: Disable transcoding. If you set this parameter as true , ensure that you call the 
         *  SetLiveTranscoding 
         *  method before this method. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  ERR_INVALID_ARGUMENT (-2): Invalid argument, usually because the URL address is null or the string length is 0.
         *  ERR_NOT_INITIALIZED (-7): You have not initialized the RTC engine when publishing the stream.
         */
        public abstract int AddPublishStreamUrl(string url, bool transcodingEnabled);
        /**
         *  Removes an RTMP or RTMPS stream from the CDN. 
         * Before calling this method, make sure that the media push function has been enabled. 
         *  This method takes effect only when you are a host in live interactive streaming.
         *  Call this method after joining a channel.
         *  This method removes only one media push URL each time it is called. To remove multiple URLs, call this method multiple times. Deprecated: This method is deprecated. 
         *  After a successful method call, the SDK triggers 
         *  OnRtmpStreamingStateChanged 
         *  on the local client to report the result of deleting the address.
         * @param
         *  url: The media push URL to be removed. The maximum length of this parameter is 1024 bytes. The media push URL must not contain special characters, such as Chinese characters.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int RemovePublishStreamUrl(string url);
        /**
         * Sets the transcoding configurations for media push.
         * This method takes effect only when you are a host in live interactive streaming.
         *  Ensure that you enable the Media Push service before using this function. See Prerequisites in the advanced guide Media Push.
         *  If you call this method to set the transcoding configuration for the first time, the SDK does not trigger the OnTranscodingUpdated callback.
         *  Call this method after joining a channel.
         *  Agora only supports pushing media streams to the CDN in RTMPS protocol when you enable transcoding. Deprecated: This method is deprecated. 
         *  This method sets the video layout and audio settings for CDN live streaming. The SDK triggers the 
         *  OnTranscodingUpdated 
         *  callback when you call this method to update the transcoding setting.
         * @param
         *  transcoding: The transcoding configurations for the media push. See LiveTranscoding for details.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetLiveTranscoding(LiveTranscoding transcoding);
        /**
         * Injects an online media stream to a live streaming channel.
         * Agora will soon stop the service for injecting online media streams on the client. If you have not implemented this service, Agora recommends that you do not use it.  Ensure that you enable the Media Push service before using this function. See Prerequisites in Media Push.
         *  This method takes effect only when you are a host in a live streaming channel.
         *  Only one online media stream can be injected into the same channel at the same time.
         *  Call this method after joining a channel. This method injects the currently playing audio and video as audio and video sources into the ongoing live broadcast. This applies to scenarios where all users in the channel can watch a live show and interact with each other. After calling this method, the SDK triggers the OnStreamInjectedStatus callback on the local client to report the state of injecting the online media stream; after successfully injecting the media stream, the stream joins the channel, and all users in the channel receive the OnUserJoined callback, where uid is 666.
         * @param
         *  url: The URL address to be added to the ongoing streaming. Valid protocols are RTMP, HLS, and HTTP-FLV.
         *  Supported audio codec type: AAC.
         *  Supported video codec type: H264 (AVC). 
         *  config: The configuration information for the added video stream: InjectStreamConfig .
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  ERR_INVALID_ARGUMENT (-2): The injected URL does not exist. Call this method again to inject the stream and ensure that the URL is valid.
         *  ERR_NOT_READY (-3): The user is not in the channel.
         *  ERR_NOT_SUPPORTED (-4): The channel profile is not live broadcasting. Call SetChannelProfile and set the channel profile live broadcasting before calling this method.
         *  ERR_NOT_INITIALIZED (-7): The SDK is not initialized. Ensure that the IAgoraRtcEngine object is initialized before using this method.
         */
        public abstract int AddInjectStreamUrl(string url, InjectStreamConfig config);
        /**
         * Removes the voice or video stream URL address from the live streaming.
         * Agora will soon stop the service for injecting online media streams on the client. If you have not implemented this service, Agora recommends that you do not use it. 
         *  After a successful method, the SDK triggers the OnUserOffline callback
         *  with the uid of 666.
         * @param
         *  url: The URL address of the injected stream to be removed.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int RemoveInjectStreamUrl(string url);
        /**
         * Starts relaying media streams across channels. This method can be used to implement scenarios such as co-host across channels.
         * After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged and OnChannelMediaRelayEvent callbacks, and these callbacks return the state and events of the media stream relay.
         *  If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), and the OnChannelMediaRelayEvent callback returns RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4), it means that the SDK starts relaying media streams between the source channel and the destination channel.
         *  If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_FAILURE (3), an exception occurs during the media stream relay. Call this method after joining the channel.
         *  This method takes effect only when you are a host in a live streaming channel.
         *  After a successful method call, if you want to call this method again, ensure that you call the StopChannelMediaRelay method to quit the current relay.
         *  You need to before implementing this function.
         *  We do not support string user accounts in this API.
         * @param
         *  configuration: The configuration of the media stream relay. See ChannelMediaRelayConfiguration for details.
         * @return
         * Success.
         *  <Failure.
         */
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);
        /**
         * Updates the channels for media stream relay.
         * After the media relay starts, if you want to relay the media stream to more channels, or leave the current relay channel, you can call the updateChannelMediaRelay method.
         *  After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback with the RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL(7) state code.
         *  Call this method after the StartChannelMediaRelay method to update the destination channel.
         * @param
         *  configuration: The configuration of the media stream relay. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);
        /**
         * Stops the media stream relay. Once the relay stops, the host quits all the destination channels.
         * After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback. If the callback reports RELAY_STATE_IDLE(0) and RELAY_OK(0), the host successfully stops the relay.
         *  If the method call fails, the SDK triggers the OnChannelMediaRelayStateChanged callback with the RELAY_ERROR_SERVER_NO_RESPONSE(2) or RELAY_ERROR_SERVER_CONNECTION_LOST(8) status code. You can call the LeaveChannel method to leave the channel, and the media stream relay automatically stops.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopChannelMediaRelay();
        /**
         * Gets the current connection state of the SDK.
         * You can call this method either before or after joining a channel.
         * @return
         * The current connection state. For details, see CONNECTION_STATE_TYPE .
         */
        public abstract CONNECTION_STATE_TYPE GetConnectionState();
        /**
         * Enables/Disables the super-resolution algorithm for a remote user's video stream.
         * This feature effectively boosts the resolution of a remote user's video seen by the local user. If the original resolution of a remote user's video is a × b, the local user's device can render the remote video at a resolution of 2a × 2b
         * after you enable this feature.
         *  After you call this method, the SDK triggers the OnUserSuperResolutionEnabled callback to report whether you have successfully enabled super resolution. The super resolution feature requires extra system resources. To balance the visual experience and system consumption, this feature can only be enabled for a single remote user. If the local user uses super resolution on Android, the original resolution of the remote user's video cannot exceed 640 × 360 pixels; if the local user uses super resolution on iOS, the original resolution of the remote user's video cannot exceed 640 × 480 pixels.
         *  If you exceed these limitations, the SDK triggers the OnWarning callback and returns all corresponding warning codes:
         *  WARN_SUPER_RESOLUTION_STREAM_OVER_LIMITATION: 1610. The origin resolution of the remote video is beyond the range where super resolution can be applied.
         *  WARN_SUPER_RESOLUTION_USER_COUNT_OVER_LIMITATION: 1611. Super resolution is already being used on another remote user's video.
         *  WARN_SUPER_RESOLUTION_DEVICE_NOT_SUPPORTED: 1612. The device does not support using super resolution. Before calling this method, ensure that you have integrated the following dynamic libraries: Because this method has certain system performance requirements, Agora recommends that you use the following devices or better:
         * @param
         *  userId: The user ID of the remote user.
         *  enable: Whether to enable super resolution for the remote user’s video:
         *  true: Enable super resolution.
         *  false: Disable super resolution.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -157: The dynamic library for super resolution is not integrated.
         */
        public abstract int EnableRemoteSuperResolution(uint userId, bool enable);
        public abstract int SetAVSyncSource(string channelId, uint uid);
        /**
         * Starts pushing media streams to a CDN without transcoding.
         * Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in Push Streams to CDN.
         *  Call this method after joining a channel.
         *  Only hosts in the LIVE_BROADCASTING profile can call this method.
         *  If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
         *  You can call this method to push a live audio-and-video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.
         *  After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
         * @param
         *  url: The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.
         */
        public abstract int StartRtmpStreamWithoutTranscoding(string url);
        /**
         * Starts Media Push and sets the transcoding configuration.
         * Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in Push Streams to CDN.
         *  Call this method after joining a channel.
         *  Only hosts in the LIVE_BROADCASTING profile can call this method.
         *  If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
         *  You can call this method to push a live audio-and-video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.
         *  After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
         * @param
         *  transcoding: The transcoding configuration for Media Push. See LiveTranscoding .
         *  
         *  url: The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);
        /**
         * Updates the transcoding configuration.
         * After you start pushing media streams to CDN with transcoding, you can dynamically update the transcoding configuration according to the scenario. The SDK triggers the OnTranscodingUpdated callback after the transcoding configuration is updated.
         * @param
         *  transcoding: The transcoding configuration for Media Push. See LiveTranscoding .
         *  
         */
        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);
        /**
         * Stops pushing media streams to a CDN.
         * You can call this method to stop the live stream on the specified CDN address. This method can stop pushing media streams to only one CDN address at a time, so if you need to stop pushing streams to multiple addresses, call this method multiple times.
         *  After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
         * @param
         *  url: The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.
         */
        public abstract int StopRtmpStream(string url);
    }

    /**
     * The SDK uses IAgoraRtcChannelEventHandler to send IAgoraRtcChannel event notifications to your app.
     */
    public abstract class IAgoraRtcChannelEventHandler
    {
        /**
         * Reports the warning code of IAgoraRtcChannel .
         * @param
         *  warn: Warning codes. 
         *  channelId: The channel ID.
         *  msg: The warning message.
         */
        public virtual void OnChannelWarning(string channelId, int warn, string msg)
        {
        }

        /**
         * The error code IAgoraRtcChannel reported.
         * @param
         *  channelId: The channel ID.
         *  err: The error code. 
         *  msg: The error message.
         */
        public virtual void OnChannelError(string channelId, int err, string msg)
        {
        }

        /**
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

        /**
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

        /**
         * Occurs when a user leaves a channel.
         * When a user leaves the channel by using the LeaveChannel method, the SDK uses this callback to notify the app when the user leaves the channel. With this callback, the app gets the channel information, such as the call duration and quality statistics.
         * @param
         *  stats: The statistics of the call, see RtcStats .
         *  channelId: The channel ID.
         */
        public virtual void OnLeaveChannel(string channelId, RtcStats stats)
        {
        }

        /**
         * Occurs when the user role switches in the interactive live streaming.
         * The SDK triggers this callback when the local user changes the user role after joining the channel.
         * @param
         *  newRole: Role that the user switches to: 
         *  CLIENT_ROLE_BROADCASTER(1): Broadcaster.
         *  CLIENT_ROLE_AUDIENCE(2): Audience. 
         *  CLIENT_ROLE_TYPE .
         *  oldRole: Role that the user switches from: 
         *  CLIENT_ROLE_BROADCASTER(1): Broadcaster.
         *  CLIENT_ROLE_AUDIENCE(2): Audience. 
         *  CLIENT_ROLE_TYPE .
         *  channelId: The channel ID.
         */
        public virtual void OnClientRoleChanged(string channelId, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
        }

        /**
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

        /**
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

        /**
         * Occurs when the SDK cannot reconnect to Agora's edge server 10 seconds after its connection to the server is interrupted.
         * The SDK triggers this callback when it cannot connect to the server 10 seconds after calling the JoinChannel method, regardless of whether it is in the channel.
         * @param
         *  channelId: The channel ID.
         */
        public virtual void OnConnectionLost(string channelId)
        {
        }

        /**
         * Occurs when the token expires.
         * When the token expires during a call, the SDK triggers this callback to remind the app to renew the token.
         *  Once you receive this callback, generate a new token on your app server, and call JoinChannel to rejoin the channel.
         * @param
         *  channelId: The channel ID.
         */
        public virtual void OnRequestToken(string channelId)
        {
        }

        /**
         * Occurs when the token expires in 30 seconds.
         * When the token is about to expire in 30 seconds, the SDK triggers this callback to remind the app to renew the token. Upon receiving this callback, generate a new token on your server, and call RenewToken to pass the new token to the SDK.
         * @param
         *  token: The token that expires in 30 seconds.
         *  channelId: The channel ID.
         */
        public virtual void OnTokenPrivilegeWillExpire(string channelId, string token)
        {
        }

        /**
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

        /**
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

        /**
         * Reports the transport-layer statistics of each remote video stream.
         * Reports the statistics of the video stream from the remote users. The SDK triggers this callback once every two seconds for each remote user. If a channel has multiple users/hosts sending video streams, the SDK triggers this callback as many times.
         * @param
         *  stats: Statistics of the remote video stream. 
         *  channelId: The channel ID.
         */
        public virtual void OnRemoteVideoStats(string channelId, RemoteVideoStats stats)
        {
        }

        /**
         * Reports the transport-layer statistics of each remote audio stream.
         * The SDK triggers this callback once every two seconds for each remote user who is sending audio streams. If a channel includes multiple remote users, the SDK triggers this callback as many times.
         * @param
         *  stats: The statistics of the received remote audio streams. See RemoteAudioStats .
         *  channelId: The channel ID.
         */
        public virtual void OnRemoteAudioStats(string channelId, RemoteAudioStats stats)
        {
        }

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
         * Reports events during the media stream relay.
         * @param
         *  code: The event code of channel media relay. See CHANNEL_MEDIA_RELAY_EVENT .
         *  
         *  channelId: The channel ID.
         */
        public virtual void OnChannelMediaRelayEvent(string channelId, CHANNEL_MEDIA_RELAY_EVENT code)
        {
        }

        /**
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

        /**
         * Reports events during the media push.
         * @param
         *  url: The URL for media push.
         *  eventCode: The event code of media push. See RTMP_STREAMING_EVENT for details.
         *  channelId: The channel ID.
         */
        public virtual void OnRtmpStreamingEvent(string channelId, string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        /**
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

        /**
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

        /**
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

        /**
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

        /**
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

        /**
         * Occurs when the SDK is ready to send Metadata .
         * This callback is triggered when the SDK is ready to receive and send Metadata. After receiving this callback, you can call SendMetadata to send the media metadata.
         * @param
         *  metadata: Media metadata See Metadata .
         */
        public virtual bool OnReadyToSendMetadata(Metadata metadata)
        {
            return true;
        }

        /**
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

        /**
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
