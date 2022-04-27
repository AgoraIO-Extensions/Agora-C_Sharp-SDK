//  IAgoraRtcEngine.cs
//
//  Created by Yiqing Huang on June 1, 2021.
//  Modified by Yiqing Huang on July 21, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    using view_t = UInt64;

    /**
     * The basic interface of the Agora SDK that implements the core functions of real-time communication.
     * IAgoraRtcEngine provides the main methods that your app can call.
     */
    public abstract class IAgoraRtcEngine : IRtcEngine
    {
    }

    /**
     * The basic interface of the Agora SDK that implements the core functions of real-time communication.
     * IAgoraRtcEngine provides the main methods that your app can call.
     */
    public abstract class IRtcEngine
    {
        /**
         * All called methods provided by the IAgoraRtcEngine class are executed asynchronously. Agora recommends calling these methods in the same thread. Before calling other APIs, you must call this method to create the IAgoraRtcEngine object.
         *  The SDK supports creating only one IAgoraRtcEngine instance for an app.
         * @param
         *  context: Configurations for the IAgoraRtcEngine instance. See RtcEngineContext .
         *  
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure.
         *  -1(ERR_FAILED): A general error occurs (no specified reason).
         *  -2(ERR_INVALID_ARGUMENT): An invalid parameter is used.
         *  -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
         *  -22(ERR_RESOURCE_LIMITED): The resource is limited. The SDK fails to allocate resources because your app consumes too much system resource or the system resources are insufficient.
         *  -101(ERR_INVALID_APP_ID): The App ID is invalid.
         */
        public abstract int Initialize(RtcEngineContext context);
        public abstract void InitEventHandler(IAgoraRtcEngineEventHandler engineEventHandler);
        /**
         * Registers an audio frame observer object.
         * Call this method to register an audio frame observer object (register a callback). When you need the SDK to trigger OnRecordAudioFrame or OnPlaybackAudioFrame callback, you need to use this method to register the callbacks.
         *  Ensure that you call this method before joining a channel.
         * @param
         *  audioFrameObserver: The observer object instance.  Set the value as NULL to release the observer object. Agora recommends releasing the observer object after receiving the OnLeaveChannel callback.
         *  
         */
        public abstract void RegisterAudioFrameObserver(IAgoraRtcAudioFrameObserver audioFrameObserver);
        /**
         * Unregisters an audio observer.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract void UnRegisterAudioFrameObserver();
        /**
         * Registers a video frame observer object.
         * You need to implement the class in this method IAgoraRtcVideoFrameObserver and register callbacks according to your scenarios. After you successfully register the video frame observer, the SDK triggers the registered callbacks each time a video frame is received. When handling the video data returned in the callbacks, pay attention to the changes in the width and height parameters, which may be adapted under the following circumstances:
         *  When the network condition deteriorates, the video resolution decreases incrementally.
         *  If the user adjusts the video profile, the resolution of the video returned in the callbacks also changes. Ensure that you call this method before joining a channel.
         * @param
         *  videoFrameObserver: The observer object instance. To release the instance, set the value as NULL. 
         *  
         */
        public abstract void RegisterVideoFrameObserver(IAgoraRtcVideoFrameObserver videoFrameObserver);
        /**
         * Unregisters the video frame observer.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract void UnRegisterVideoFrameObserver();
        public abstract void Dispose(bool sync = false);

        [Obsolete(ObsoleteMethodWarning.GetAudioEffectManagerWarning, false)]
        public abstract IAudioEffectManager GetAudioEffectManager();

        [Obsolete(ObsoleteMethodWarning.GetAudioRecordingDeviceManagerWarning, false)]
        public abstract IAudioRecordingDeviceManager GetAudioRecordingDeviceManager();

        public abstract IAgoraRtcAudioRecordingDeviceManager GetAgoraRtcAudioRecordingDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GetAudioPlaybackDeviceManagerWarning, false)]
        public abstract IAudioPlaybackDeviceManager GetAudioPlaybackDeviceManager();

        public abstract IAgoraRtcAudioPlaybackDeviceManager GetAgoraRtcAudioPlaybackDeviceManager();

        [Obsolete(ObsoleteMethodWarning.GetVideoDeviceManagerWarning, false)]
        public abstract IVideoDeviceManager GetVideoDeviceManager();

        public abstract IAgoraRtcVideoDeviceManager GetAgoraRtcVideoDeviceManager();
        /**
         * Creates and gets an IAgoraRtcChannel object.
         * You can call this method multiple times to create multiple IAgoraRtcChannel objects, and then call the JoinChannel methods in of each IAgoraRtcChannel to join multiple channels at the same time.
         *  After joining multiple channels, you can simultaneously subscribe to the the audio and video streams of all the channels, but publish a stream in only one channel at one time.
         * @param
         *  channelId: The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters: 
         *  The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  The 10 numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
         *  The parameter does not have a default value. You must set it.
         *  Do not set this parameter as the empty string "". Otherwise, the SDK returns ERR_REFUSED(5).
         *  
         * @return
         * A pointer to the IAgoraRtcChannel instance, if the method call succeeds.
         *  If the call fails, returns NULL.
         */
        public abstract IAgoraRtcChannel CreateChannel(string channelId);
        /**
         * Sets the channel profile.
         * After initializing the SDK, the default channel profile is the communication profile. To ensure the quality of real-time communication, Agora recommends that all users in a channel use the same channel profile.
         *  This method must be called and set before JoinChannel [2/2], and cannot be set again after joining the channel.
         * @param
         *  profile: The channel profile. See CHANNEL_PROFILE_TYPE for details.
         *  
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure.
         *  -2(ERR_INVALID_ARGUMENT): The parameter is invalid.
         *  -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
         */
        public abstract int SetChannelProfile(CHANNEL_PROFILE_TYPE profile);
        /**
         * Sets the client role.
         * If you call this method to set the user's role as the host before joining the channel and set the local video property through the SetupLocalVideo method, the local video preview is automatically enabled when the user joins the channel.
         *  You can call this method either before or after joining the channel to set the user role as audience or host.
         *  If you call this method to switch the user role after joining the channel, the SDK triggers the following callbacks:
         *  The local client: OnClientRoleChanged .
         *  The remote client: OnUserJoined or OnUserOffline (USER_OFFLINE_BECOME_AUDIENCE). This method only takes effect when the channel profile is live interactive streaming (when the profile parameter in SetChannelProfile set as CHANNEL_PROFILE_LIVE_BROADCASTING).
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
         * In the interactive live streaming profile, the SDK sets the user role as audience by default. You can call this method to set the user role as host.
         *  You can call this method either before or after joining a channel.
         *  If you call this method to set the user's role as the host before joining the channel and set the local video property through the SetupLocalVideo method, the local video preview is automatically enabled when the user joins the channel.
         *  If you call this method to switch the user role after joining a channel, the SDK automatically does the following:
         *  Calls MuteLocalAudioStream and MuteLocalVideoStream to change the publishing state.
         *  Triggers OnClientRoleChanged on the local client.
         *  Triggers OnUserJoined or OnUserOffline on the remote client. This method applies to the interactive live streaming profile (the profile parameter of SetChannelProfile is CHANNEL_PROFILE_LIVE_BROADCASTING) only.
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
         * Joins a channel.
         * When the connection between the client and Agora's server is interrupted due to poor network conditions, the SDK tries reconnecting to the server. When the local client successfully rejoins the channel, the SDK triggers the OnRejoinChannelSuccess callback on the local client.
         *  A successful call of this method triggers the following callbacks: 
         *  The local client: The OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
         *  The remote client: OnUserJoined , if the user joining the channel is in the Communication profile or is a host in the Live-broadcasting profile. This method enables the local user to join a real-time audio and video interaction channel. With the same App ID, users in the same channel can talk to each other, and multiple users in the same channel can start a group chat.
         *  Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.
         * @param
         *  channelId: The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters: 
         *  The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  The 10 numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
         *  token: The token generated on your server for authentication. See Authenticate Your Users with Token.
         *  Ensure that the App ID used for creating the token is the same App ID used by the Initialize method for initializing the RTC engine. 
         *  uid: User ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to 232-1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and returns it in the OnJoinChannelSuccess callback. Your app must maintain the returned user ID, because the SDK does not do so.
         *  info: (Optional) Reserved for future use.
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
        public abstract int JoinChannel(string token, string channelId, string info = "", uint uid = 0);

        /**
         * Joins a channel with the user ID, and configures whether to automatically subscribe to the audio or video streams.
         * This method enables the local user to join a real-time audio and video interaction channel. With the same App ID, users in the same channel can talk to each other, and multiple users in the same channel can start a group chat.
         *  A successful call of this method triggers the following callbacks: 
         *  The local client: The OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
         *  The remote client: OnUserJoined , if the user joining the channel is in the Communication profile or is a host in the Live-broadcasting profile. When the connection between the client and Agora's server is interrupted due to poor network conditions, the SDK tries reconnecting to the server. When the local client successfully rejoins the channel, the SDK triggers the OnRejoinChannelSuccess callback on the local client.
         * @param
         *  token: The token generated on your server for authentication. See Authenticate Your Users with Token.
         *  Ensure that the App ID used for creating the token is the same App ID used by the Initialize method for initializing the RTC engine. 
         *  channelId: The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters: 
         *  The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  The 10 numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
         *  options: The channel media options. 
         *  
         *  uid: User ID This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to
         *  232-1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and returns it in the OnJoinChannelSuccess callback. Your app must maintain the returned user ID, because the SDK
         *  does not do so.
         *  info: Reserved for future use.
         *  
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
        public abstract int JoinChannel(string token, string channelId, string info, uint uid,
            ChannelMediaOptions options);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int JoinChannel(string channelId, string info = "", uint uid = 0);

        [Obsolete(ObsoleteMethodWarning.JoinChannelByKeyWarning, false)]
        public abstract int JoinChannelByKey(string token, string channelId, string info = "", uint uid = 0);

        /**
         * Switches to a different channel.
         * This method allows the audience of an interactive live streaming channel to switch to a different channel.
         *  After the user successfully switches to another channel, the OnLeaveChannel and OnJoinChannelSuccess callbacks are triggered to indicate that the user has left the original channel and joined a new one.
         *  Once the user switches to another channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.
         * @param
         *  token: The token generated at your server.
         *  In scenarios with low security requirements, token is optional and can be set as NULL.
         *  In scenarios with high security requirements, set the value to the token generated from your server. If you enable the App Certificate, you must use a token to join the channel. Ensure that the App ID used for creating the token is the same App ID used by the Initialize method for initializing the RTC engine.
         *  
         *  channelId: The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported character scopes are:
         *  All lowercase English letters: a to z.
         *  All uppercase English letters: A to Z.
         *  All numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "= ", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -1: A general error occurs (no specified reason).
         *  -2: The parameter is invalid.
         *  -5: The request is rejected. Probably because the user is not an audience member.
         *  -7: The SDK is not initialized.
         *  -102: The channel name is invalid. Please use a valid channel name.
         *  -113: The user is not in the channel.
         */
        public abstract int SwitchChannel(string token, string channelId);
        /**
         * Switches to a different channel, and configures whether to automatically subscribe to audio or video streams in the target channel.
         * This method allows the audience of a LIVE_BROADCASTING channel to switch to a different channel.
         *  After the user successfully switches to another channel, the OnLeaveChannel and OnJoinChannelSuccess callbacks are triggered to indicate that the user has left the original channel and joined a new one.
         *  Once the user switches to another channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. If you do not want to subscribe to a specified stream or all remote streams, call the mute methods accordingly.
         * @param
         *  token: The token generated at your server.
         *  In scenarios with low security requirements, token is optional and can be set as NULL.
         *  In scenarios with high security requirements, set the value to the token generated from your server. If you enable the App Certificate, you must use a token to join the channel. Ensure that the App ID used for creating the token is the same App ID used by the Initialize method for initializing the RTC engine.
         *  
         *  channelId: The name of the channel. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channelId enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters:
         *  All lowercase English letters: a to z.
         *  All uppercase English letters: A to Z.
         *  All numeric characters: 0 to 9.
         *  Space
         *  "!"、"#"、"$"、"%"、"&"、"("、")"、"+"、"-"、":"、";"、"<"、"="、"."、">"、"?"、"@"、"["、"]"、"^"、"_"、"{"、"}"、"|"、"~"、"," 
         *  options: The channel media options. See ChannelMediaOptions.
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure.
         *  -1(ERR_FAILED): A general error occurs (no specified reason).
         *  -2 (ERR_INVALID_ARGUMENT): The parameter is invalid.
         *  -5(ERR_REFUSED): The request is rejected. The role of the remote user is not AUDIENCE.
         *  -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
         *  -102(ERR_INVALID CHANNEL_NAME): The channel name is invalid. Please use a valid channel name.
         *  -113(ERR_NOT_IN_CHANNEL): The user is not in the channel.
         */
        public abstract int SwitchChannel(string token, string channelId, ChannelMediaOptions options);
        /**
         * Leaves a channel.
         * This method releases all resources related to the session. This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel.
         *  After joining the channel, you must call this method to end the call; otherwise, you cannot join the next call.
         *  A successful call of this method triggers the following callbacks:
         *  The local client: OnLeaveChannel .
         *  The remote client: OnUserOffline , if the user joining the channel is in the Communication profile, or is a host in the Live-broadcasting profile. 
         *  If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.
         *  If you call this method during a CDN live streaming, the SDK automatically calls the RemovePublishStreamUrl method.
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure.
         *  -1(ERR_FAILED): A general error occurs (no specified reason).
         *  -2 (ERR_INVALID_ARGUMENT): The parameter is invalid.
         *  -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
         */
        public abstract int LeaveChannel();
        /**
         * Gets a new token when the current token expires after a period of time.
         * Passes a new token to the SDK. A token expires after a certain period of time. In the following two cases, the app should call this method to pass in a new token. Failure to do so will result in the SDK disconnecting from the server.
         *  The SDK triggers the OnTokenPrivilegeWillExpire callback.
         *  The OnConnectionStateChanged callback reports CONNECTION_CHANGED_TOKEN_EXPIRED(9).
         * @param
         *  token: The new token.
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure.
         *  -1(ERR_FAILED): A general error occurs (no specified reason).
         *  -2 (ERR_INVALID_ARGUMENT): The parameter is invalid.
         *  -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
         */
        public abstract int RenewToken(string token);
        /**
         * Registers a user account.
         * Once registered, the user account can be used to identify the local user when the user joins the channel. After the registration is successful, the user account can identify the identity of the local user, and the user can use it to join the channel.
         *  After the user successfully registers a user account, the SDK triggers the OnLocalUserRegistered callback on the local client, reporting the user ID and user account of the local user.
         *  This method is optional. To join a channel with a user account, you can choose either of the following ways:
         *  Call RegisterLocalUserAccount to to create a user account, and then call JoinChannelWithUserAccount [2/2] to join the channel.
         *  Call the JoinChannelWithUserAccount [2/2] method to join the channel. The difference between the two ways is that the time elapsed between calling the RegisterLocalUserAccount method and joining the channel is shorter than directly calling JoinChannelWithUserAccount [2/2]. Ensure that you set the userAccount parameter; otherwise, this method does not take effect.
         *  Ensure that the userAccount is unique in the channel.
         *  To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
         * @param
         *  appId: The App ID of your project on Agora Console.
         *  userAccount: The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are (89 in total):
         *  The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  All numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int RegisterLocalUserAccount(string appId, string userAccount);
        /**
         * Joins the channel with a user account.
         * Since
         *  v2.8.0 This method allows a user to join the channel with the user account. After the user successfully joins the channel, the SDK triggers the following callbacks: The local client: OnLocalUserRegistered , OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
         *  The remote client: OnUserJoined and OnUserInfoUpdated , if the user joining the channel is in the communication profile or is a host in the live streaming profile. Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.
         *  To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
         * @param
         *  userAccount: The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are (89 in total): The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  All numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
         *  token: The token generated on your server for authentication. See Authenticate Your Users with Token.
         *  Ensure that the App ID used for creating the token is the same App ID used by the Initialize method for initializing the RTC engine. 
         *  channelId: The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters: 
         *  The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  The 10 numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
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
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        /**
         * Joins the channel with a user account, and configures whether to automatically subscribe to audio or video streams after joining the channel.
         * This method allows a user to join the channel with the user account. After the user successfully joins the channel, the SDK triggers the following callbacks: The local client: OnLocalUserRegistered , OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
         *  The remote client: The OnUserJoined callback if the user is in the COMMUNICATION profile, and the OnUserInfoUpdated callback if the user is a host in the LIVE_BROADCASTING profile. Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.
         *  To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
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
         *  channelId: The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters: 
         *  The 26 lowercase English letters: a to z.
         *  The 26 uppercase English letters: A to Z.
         *  The 10 numeric characters: 0 to 9.
         *  Space
         *  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," 
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
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount,
            ChannelMediaOptions options);

        /**
         * Gets the user information by passing in the user account.
         * After a remote user joins the channel, the SDK gets the UID and user account of the remote user, caches them in a mapping table object, and triggers the OnUserInfoUpdated callback on the local client. After receiving the callback, you can call this method to get the user account of the remote user from the UserInfo object by passing in the user ID.
         * @param
         *  userInfo: The UserInfo object that identifies the user information.
         *  
         *  userAccount: The user account.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int GetUserInfoByUserAccount(string userAccount, out UserInfo userInfo);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract UserInfo GetUserInfoByUserAccount(string userAccount);

        /**
         * Gets the user information by passing in the user ID.
         * After a remote user joins the channel, the SDK gets the UID and user account of the remote user, caches them in a mapping table object, and triggers the OnUserInfoUpdated callback on the local client. After receiving the callback, you can call this method to get the user account of the remote user from the UserInfo object by passing in the user ID.
         * @param
         *  uid: User ID.
         *  userInfo: The UserInfo object that identifies the user information.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int GetUserInfoByUid(uint uid, out UserInfo userInfo);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract UserInfo GetUserInfoByUid(uint uid);

        /**
         * Starts an audio call test.
         * Deprecated:
         *  This method is deprecated as of v2.4.0. Use StartEchoTest [2/3] instead. This method starts an audio call test to determine whether the audio devices (for example, headset and speaker) and the network connection are working properly. To conduct the test, the user speaks, and the recording is played back within 10 seconds. If the user can hear the recording within the interval, the audio devices and network connection are working properly. Call this method before joining a channel.
         *  After calling StopEchoTest , you must call StartEchoTest [1/3] to end the test. Otherwise, the app cannot perform the next echo test, and you cannot join the channel.
         *  In the live streaming channels, only a host can call this method.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int StartEchoTest();

        /**
         * Starts an audio call test.
         * This method starts an audio call test to determine whether the audio devices (for example, headset and speaker) and the network connection are working properly. To conduct the test, let the user speak for a while, and the recording is played back within the set interval. If the user can hear the recording within the interval, the audio devices and network connection are working properly. Call this method before joining a channel.
         *  After calling StopEchoTest , you must call StartEchoTest [2/3] to end the test. Otherwise, the app cannot perform the next echo test, and you cannot join the channel.
         *  In the live streaming channels, only a host can call this method.
         * @param
         *  intervalInSeconds: The time interval (s) between when you speak and when the recording plays back.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartEchoTest(int intervalInSeconds);
        /**
         * Stops the audio call test.
         * @return
         * 0: Success. < 0: Failure.
         *  -5(ERR_REFUSED): Failed to stop the echo test. The echo test may not be running.
         */
        public abstract int StopEchoTest();
        /**
         * Sets the Agora cloud proxy service.
         * When users' network access is restricted by a firewall, configure the firewall to allow specific IP addresses and ports provided by Agora; then, call this method to enable the cloud proxy and set the cloud proxy type with the proxyType parameter.
         *  After successfully connecting to the cloud proxy, the SDK triggers the OnConnectionStateChanged (CONNECTION_STATE_CONNECTING, CONNECTION_CHANGED_SETTING_PROXY_SERVER) callback.
         *  As of v3.6.2, when a user calls this method and then joins a channel successfully, the SDK triggers the OnProxyConnected callback to report the user ID, the proxy type connected, and the time calculated from when the user calling the JoinChannel [1/2] method to the callback is triggered.
         *  To disable the cloud proxy that has been set, call the SetCloudProxy(NONE_PROXY). 
         *  To change the cloud proxy type that has been set, call the SetCloudProxy(NONE_PROXY) first, and then call the SetCloudProxy to set the proxyType you want. Agora recommends that you call this method before joining the channel or after leaving the channel.
         *  For the SDK v3.3.x, when users use the Force UDP cloud proxy, the services for Media Push and cohosting across channels are not available; for the SDK v3.4.0 or later, when users behind a firewall use the Force UDP cloud proxy, the services for Media Push and cohosting across channels are not available.
         *  When you use the Force UDP cloud proxy, note that an error would occur when calling the StartAudioMixing [2/2] method to play online music files in the HTTP protocol. The services for Media Push and cohosting across channels use the cloud proxy with the TCP protocol.
         * @param
         *  proxyType: The type of the cloud proxy. See CLOUD_PROXY_TYPE .
         *  This parameter is mandatory. The SDK reports an error if you do not pass in a value.
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -2: The parameter is invalid.
         *  -7: The SDK is not initialized.
         */
        public abstract int SetCloudProxy(CLOUD_PROXY_TYPE proxyType);
        /**
         * Enables the video module.
         * Call this method either before joining a channel or during a call. If this method is called before joining a channel, the call starts in the video mode. Call DisableVideo to disable the video mode.A successful call of this method triggers the OnRemoteVideoStateChanged callback on the remote client. This method enables the internal engine and is valid after leaving the channel.
         *  This method resets the internal engine and takes some time to take effect. Agora recommends using the following API methods to control the video engine modules separately: 
         *  EnableLocalVideo : Whether to enable the camera to create the local video stream. 
         *  MuteLocalVideoStream : Whether to publish the local video stream. 
         *  MuteRemoteVideoStream : Whether to subscribe to and play the remote video stream. 
         *  MuteAllRemoteVideoStreams : Whether to subscribe to and play all remote video streams.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableVideo();
        /**
         * Disables the video module.
         * This method disables video. You can call this method either before or after joining a channel. If you call it before joining a channel, an audio call starts when you join the channel. If you call it after joining a channel, a video call switches to an audio call. Call EnableVideo to enable video.A successful call of this method triggers the OnUserEnableVideo (false) callback on the remote client. This method affects the internal engine and can be called after leaving the channel.
         *  This method resets the internal engine and takes some time to take effect. Agora recommends using the following API methods to control the video engine modules separately: 
         *  EnableLocalVideo : Whether to enable the camera to create the local video stream. 
         *  MuteLocalVideoStream : Whether to publish the local video stream. 
         *  MuteRemoteVideoStream : Whether to subscribe to and play the remote video stream. 
         *  MuteAllRemoteVideoStreams : Whether to subscribe to and play all remote video streams.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int DisableVideo();
        public abstract int EnableVideoObserver();
        public abstract int DisableVideoObserver();

        /**
         * Sets the video encoder configuration.
         * Deprecated:
         *  This method is deprecated as of v2.3. Please use SetVideoEncoderConfiguration instead. This method sets the video encoder configuration. You can call this method either before or after joining a channel. If the user does not need to reset the video encoding properties after joining the channel, Agora recommends calling this method before EnableVideo to reduce the time to render the first video frame.
         * @param
         *  profile: Video profile. For details, see VIDEO_PROFILE_TYPE .
         *  swapWidthAndHeight: The SDK outputs video with a fixed width and height according to the video profile (profile) you selected. This parameter sets whether to swap width and height of the video: true: Swap the width and height.
         *  false: (Default) Do not swap the width and height. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetVideoProfile(VIDEO_PROFILE_TYPE profile, bool swapWidthAndHeight = false);

        /**
         * Sets the video encoder configuration.
         * Sets the encoder configuration for the local video.
         *  You can call this method either before or after joining a channel. If you don't need to set the video encoder configuration after joining a channel,
         *  Agora recommends you calling this method before the EnableVideo method to reduce the rendering time of the first video frame.
         * @param
         *  config: Video profile. See VideoEncoderConfiguration .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetVideoEncoderConfiguration(VideoEncoderConfiguration config);
        /**
         * Sets the camera capture configuration.
         * For a video call or the interactive live video streaming, generally the SDK controls the camera output parameters. When the default camera capturer settings do not meet special requirements or cause performance problems, we recommend using this method to set the camera capturer configuration:
         *  If the resolution or frame rate of the captured raw video data are higher than those set by SetVideoEncoderConfiguration , processing video frames requires extra CPU and RAM usage and degrades performance. Agora recommends setting the camera capture configuration to CAPTURER_OUTPUT_PREFERENCE_PERFORMANCE(1) to avoid such problems.
         *  If you do not need a local video preview or are willing to sacrifice preview quality, we recommend setting the preference as CAPTURER_OUTPUT_PREFERENCE_PERFORMANCE(1) to optimize CPU and RAM usage.
         *  If you want better quality for the local video preview, we recommend setting config as CAPTURER_OUTPUT_PREFERENCE_PREVIEW(2).
         *  To customize the width and height of the video image captured by the local camera, set the camera capture configuration as CAPTURER_OUTPUT_PREFERENCE_MANUAL(3). 
         *  Call this method before calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
         * @param
         *  config: The camera capturer configuration. See CameraCapturerConfiguration .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetCameraCapturerConfiguration(CameraCapturerConfiguration config);
        /**
         * Initializes the local video view.
         * This method initializes the video view of a local stream on the local device. It affects only the video view that the local user sees, not the published local video stream. Call this method to bind the local video stream to a video view and to set the rendering and mirror modes of the video view.
         *  After initialization, call this method to set the local video and then join the channel. The local video still binds to the view after you leave the channel. To unbind the local video from the view, set the view parameter as NULL. You can call this method either before or after joining a channel.
         *  To update the rendering or mirror mode of the local video view during a call, use the SetLocalRenderMode [2/2] method.
         * @param
         *  canvas: The local video view and settings. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetupLocalVideo(VideoCanvas canvas);
        /**
         * Initializes the video view of a remote user.
         * This method initializes the video view of a remote stream on the local device. It affects only the video view that the local user sees. Call this method to bind the remote video stream to a video view and to set the rendering and mirror modes of the video view.
         *  You need to specify the ID of the remote user in this method. If the remote user ID is unknown to the application, set it after the app receives the OnUserJoined callback.
         *  To unbind the remote user from the view, set the view parameter to NULL.
         *  Once the remote user leaves the channel, the SDK unbinds the remote user. To update the rendering or mirror mode of the remote video view during a call, use the SetRemoteRenderMode [2/2] method.
         *  If you use the Agora recording feature, the recording client joins the channel as a dummy client, triggering the OnUserJoined callback. Do not bind the dummy client to the app view because the dummy client does not send any video streams. If your app does not recognize the dummy client, bind the remote user to the view when the SDK triggers the OnFirstRemoteVideoDecoded callback.
         * @param
         *  canvas: The remote video view and settings. 
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetupRemoteVideo(VideoCanvas canvas);
        /**
         * Enables the local video preview.
         * This method starts the local video preview before joining the channel. Before calling this method, ensure that you do the following: Call EnableVideo to enable the video. 
         *  The local preview enables the mirror mode by default.
         *  After the local video preview is enabled, if you call LeaveChannel to exit the channel, the local preview remains until you call StopPreview to disable it.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartPreview();
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
         * Stops the local video preview.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopPreview();
        /**
         * Enables the audio module.
         * The audio mode is enabled by default. This method enables the internal engine and can be called anytime after initialization. It is still valid after one leaves channel.
         *  This method enables the audio module and takes some time to take effect. Agora recommends using the following API methods to control the audio module separately: 
         *  EnableLocalAudio : Whether to enable the microphone to create the local audio stream. 
         *  MuteLocalAudioStream : Whether to publish the local audio stream. 
         *  MuteRemoteAudioStream : Whether to subscribe and play the remote audio stream. 
         *  MuteAllRemoteAudioStreams : Whether to subscribe to and play all remote audio streams.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableAudio();
        /**
         * Enables/Disables the local audio capture.
         * The audio function is enabled by default. This method disables or re-enables the local audio function to stop or restart local audio capturing.
         *  This method does not affect receiving or playing the remote audio streams, and EnableLocalAudio (false) applies to scenarios where the user wants to receive remote audio streams without sending any audio stream to other users in the channel.
         *  Once the local audio function is disabled or re-enabled, the SDK triggers the OnLocalAudioStateChanged callback, which reports LOCAL_AUDIO_STREAM_STATE_STOPPED(0) or LOCAL_AUDIO_STREAM_STATE_RECORDING(1).
         *  This method is different from the MuteLocalAudioStream method:
         *  EnableLocalVideo: Disables/Re-enables the local audio capturing and processing. If you disable or re-enable local audio capturing using the enableLocalAudio method, the local user might hear a pause in the remote audio playback.
         *  MuteLocalAudioStream: Sends/Stops sending the local audio streams. You can call this method either before or after joining a channel.
         * @param
         *  enabled: true: (Default) Re-enable the local audio function, that is, to start the local audio capturing device (for example, the microphone).
         *  false: Disable the local audio function, that is, to stop local audio capturing. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableLocalAudio(bool enabled);
        /**
         * Disables the audio module.
         * This method disables the internal engine and can be called anytime after initialization. It is still valid after one leaves channel.
         *  This method resets the internal engine and takes some time to take effect. Agora recommends using the following API methods to control the audio modules separately: 
         *  EnableLocalAudio : Whether to enable the microphone to create the local audio stream. 
         *  MuteLocalAudioStream : Whether to publish the local audio stream. 
         *  MuteRemoteAudioStream : Whether to subscribe and play the remote audio stream. 
         *  MuteAllRemoteAudioStreams : Whether to subscribe to and play all remote audio streams.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int DisableAudio();
        /**
         * Sets the audio profile and audio scenario.
         * Ensure that you call this method before joining a channel.
         *  In scenarios requiring high-quality audio, such as online music tutoring, Agora recommends you set profile as AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4), and scenario as AUDIO_SCENARIO_GAME_STREAMING (3)
         * @param
         *  profile: The audio profile, including the sampling rate, bitrate, encoding mode, and the number of channels. See AUDIO_PROFILE_TYPE .
         *  
         *  scenario: The audio scenario. See AUDIO_SCENARIO_TYPE . Under different audio scenarios, the device uses different volume types.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);
        /**
         * Stops or resumes publishing the local audio stream.
         * A successful call of this method triggers the OnUserMuteAudio callback on the remote client. This method does not affect any ongoing audio recording, because it does not disable the microphone.
         *  You can call this method either before or after joining a channel. If you call the SetChannelProfile method after this method, the SDK resets whether or not to stop publishing the local audio according to the channel profile and user role. Therefore, Agora recommends calling this method after the SetChannelProfile method.
         * @param
         *  mute: Whether to stop publishing the local audio stream. true: Stop publishing the local audio stream.
         *  false: (Default) Resumes publishing the local audio stream. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int MuteLocalAudioStream(bool mute);
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
         * Stops or resumes subscribing to the audio streams of all remote users by default.
         * Call this method after joining a channel. After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all subsequent users. If you need to resume subscribing to the audio streams of remote users in the channel after calling this method, do the following:
         *  To resume subscribing to the audio stream of a specified user, call MuteRemoteAudioStream (false), and specify the user ID.
         *  To resume subscribing to the audio streams of multiple remote users, call MuteRemoteAudioStream (false)multiple times.
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
         * Adjusts the playback signal volume of a specified remote user.
         * You can call this method to adjust the playback volume of a specified remote user. To adjust the playback volume of different remote users, call the method as many times, once for each remote user. Call this method after joining a channel.
         *  The playback volume here refers to the mixed volume of a specified remote user.
         * @param
         *  uid: The ID of the remote user.
         *  volume: The playback signal volume of a specified remote user.
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
         * Stops or resumes publishing the local video stream.
         * A successful call of this method triggers the OnUserMuteVideo callback on the remote client. This method executes faster than the EnableLocalVideo (false) method, which controls the sending of the local video stream.
         *  This method does not affect any ongoing video recording, because it does not disable the camera.
         *  You can call this method either before or after joining a channel. If you call SetChannelProfile after this method, the SDK resets whether or not to stop publishing the local video according to the channel profile and user role. Therefore, Agora recommends calling this method after the SetChannelProfile method.
         * @param
         *  mute: Whether to stop publishing the local video stream.
         *  true: Stop publishing the local video stream.
         *  false: (Default) Publish the local video stream. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int MuteLocalVideoStream(bool mute);
        /**
         * Enables/Disables the local video capture.
         * This method disables or re-enables the local video capturer, and does not affect receiving the remote video stream.
         *  After calling EnableVideo , the local video capturer is enabled by default. You can call EnableLocalVideo (false) to disable the local video capturer. If you want to re-enable the local video, call EnableLocalVideo(true).
         *  After the local video capturer is successfully disabled or re-enabled, the SDK triggers the callback on the remote client OnRemoteVideoStateChanged . You can call this method either before or after joining a channel.
         *  This method enables the internal engine and is valid after .
         * @param
         *  enabled: Whether to enable the local video capture. true: (Default) Enable the local video capture.
         *  false: Disables the local video capture. Once the local video is disabled, the remote users can no longer receive the video stream of this user, while this user can still receive the video streams of the other remote users. When set to false, this method does not require a local camera. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableLocalVideo(bool enabled);
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
         * Stops or resumes subscribing to the video streams of all remote users by default.
         * Call this method after joining a channel. After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all subsequent users.
         *  If you need to resume subscribing to the audio streams of remote users in the channel after calling this method, do the following:To resume subscribing to the audio stream of a specified user, call MuteRemoteVideoStream (false), and specify the user ID.
         *  To resume subscribing to the audio streams of multiple remote users, call MuteRemoteVideoStream(false)multiple times.
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
         * Under limited network conditions, if the publisher has not disabled the dual-stream mode using EnableDualStreamMode (false), the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or the low-quality video stream (the low resolution, and low bitrate video stream). The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate.
         *  By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream. The method result returns in the OnApiCallExecuted callback. You can call this method either before or after joining a channel. If you call both SetRemoteVideoStreamType and SetRemoteDefaultVideoStreamType , the setting of SetRemoteVideoStreamType takes effect.
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
         * Under limited network conditions, if the publisher has not disabled the dual-stream mode using (),the receiver can choose to receive either the high-quality video stream or the low-quality video stream. The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate. EnableDualStreamMode false
         *  By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream.
         *  The result of this method returns in the OnApiCallExecuted callback.
         *  You can call this method either before or after joining a channel. If you call both SetRemoteVideoStreamType and SetRemoteDefaultVideoStreamType , the settings in SetRemoteVideoStreamType take effect.
         * @param
         *  streamType: The default stream type of the remote video, see REMOTE_VIDEO_STREAM_TYPE .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType);
        /**
         * Enables the reporting of users' volume indication.
         * This method enables the SDK to regularly report the volume information of the local user who sends a stream and remote users (up to three) whose instantaneous volumes are the highest to the app. Once you call this method and users send streams in the channel, the SDK triggers the OnAudioVolumeIndication callback at the time interval set in this method.
         *  You can call this method either before or after joining a channel.
         * @param
         *  interval: Sets the time interval between two consecutive volume indications:
         *  ≤ 0: Disables the volume indication.
         *  > 0: Time interval (ms) between two consecutive volume indications. We recommend a setting greater than 200 ms. Do not set this parameter to less than 10 milliseconds, otherwise the OnAudioVolumeIndication callback will not be triggered.
         *  
         *  smooth: The smoothing factor sets the sensitivity of the audio volume indicator. The value ranges between 0 and 10. The recommended value is 3. The greater the value, the more sensitive the indicator.
         *  reportVad: true: Enable the voice activity detection of the local user. Once it is enabled, the vad parameter of the OnAudioVolumeIndication callback reports the voice activity status of the local user.
         *  false: (Default) Disable the voice activity detection of the local user. Once it is disabled, the vad parameter of the OnAudioVolumeIndication callback does not report the voice activity status of the local user, except for the scenario where the engine automatically detects the voice activity of the local user. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad);

        /**
         * Starts audio recording on the client.
         * Deprecated:
         *  This method is deprecated as of v2.9.1. It has a fixed recording sample rate of 32 kHz. Please use the StartAudioRecording [3/3] method instead. The Agora SDK allows recording during a call. This method records the audio of all the users in the channel and generates an audio recording file. Supported formats of the recording file are as follows:
         *  .wav: Large file size with high fidelity.
         *  .aac: Small file size with low fidelity. Ensure that the directory for the recording file exists and is writable. This method should be called after the JoinChannel [1/2] method. The recording automatically stops when you call the LeaveChannel method.
         * @param
         *  filePath: The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.aac . Ensure that the directory for the log files exists and is writable.
         *  
         *  quality: Audio recording quality. See 
         *  AUDIO_RECORDING_QUALITY_TYPE .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality);

        /**
         * Starts audio recording on the client.
         * Deprecated:
         *  This method is deprecated as of v3.4.0. Please use StartAudioRecording [3/3] instead. The Agora SDK allows recording during a call. After successfully calling this method, you can record the audio of all the users in the channel and get an audio recording file. Supported formats of the recording file are as follows:
         *  .wav: Large file size with high fidelity.
         *  .aac: Small file size with low fidelity. Ensure that the directory you use to save the recording file exists and is writable.
         *  This method should be called after the JoinChannel [2/2] method. The recording automatically stops when you call the LeaveChannel method.
         *  For better recording effects, set quality to AUDIO_RECORDING_QUALITY_MEDIUM or AUDIO_RECORDING_QUALITY_HIGH when sampleRate is 44.1 kHz or 48 kHz.
         * @param
         *  filePath: The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.aac . Ensure that the directory for the log files exists and is writable.
         *  
         *  sampleRate: The sample rate (kHz) of the recording file. Supported values are as follows:
         *  16000
         *  (Default) 32000
         *  44100
         *  48000 
         *  quality: Recording quality. For more details, see 
         *  AUDIO_RECORDING_QUALITY_TYPE .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        /**
         * Starts audio recording on the client.
         * The Agora SDK allows recording during a call. After successfully calling this method, you can record the audio of users in the channel and get an audio recording file. Supported formats of the recording file are as follows:
         *  WAV: Large file size with high fidelity. For example, if the sample rate is 32,000 Hz, the file size for a recording duration of 10 minutes is around 73 M.
         *  AAC: Small file size with low fidelity. For example, if the sample rate is 32,000 Hz and the recording quality is AUDIO_RECORDING_QUALITY_MEDIUM, the file size for a recording duration of 10 minutes is around 2 M. Once the user leaves the channel, the recording automatically stops.
         *  Call this method after joining a channel.
         * @param
         *  config: Recording configuration. See 
         *  AudioRecordingConfiguration .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartAudioRecording(AudioRecordingConfiguration config);

        /**
         * Stops the audio recording on the client.
         * If you call StartAudioRecording [3/3] to start recording, you can call this method to stop the recording.
         *  Once the user leaves the channel, the recording automatically stops.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopAudioRecording();

        /**
         * Starts playing the music file.
         * Deprecated:
         *  Please use StartAudioMixing [2/2] instead. 
         *  This method mixes the specified local or online audio file with the audio from the microphone, or replaces the microphone's audio with the specified local or remote audio file. A successful method call triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback. When the audio mixing file playback finishes, the SDK triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_STOPPED) callback on the local client. Call this method after joining a channel. If you need to call StartAudioMixing [1/2] multiple times, ensure that the time interval between calling this method is more than 500 ms.
         *  If the local audio mixing file does not exist, or if the SDK does not support the file format or cannot access the music file URL, the SDK returns WARN_AUDIO_MIXING_OPEN_ERROR (701).
         * @param
         *  loopback: Whether to only play music files on the local client:
         *  true: Only play music files on the local client so that only the local user can hear the music.
         *  false: Publish music files to remote clients so that both the local user and remote users can hear the music. 
         *  filePath: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4. Supported audio formats include MP3, AAC, M4A, MP4, WAV, and 3GP. See supported audio formats.
         *  
         *  replace: Whether to replace the audio captured by the microphone with a music file: 
         *  true: Replace the audio captured by the microphone with a music file. Users can only hear the music.
         *  false: Do not replace the audio captured by the microphone with a music file. Users can hear both music and audio captured by the microphone. 
         *  cycle: The number of times the music file plays.
         *  ≥ 0: The number of playback times. For example, 0 means that the SDK does not play the music file while 1 means that the SDK plays once.
         *  -1: Play the audio effect in an infinite loop. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle);

        /**
         * Starts playing the music file.
         * This method mixes the specified local or online audio file with the audio from the microphone, or replaces the microphone's audio with the specified local or remote audio file. A successful method call triggers the OnAudioMixingStateChanged (PLAY) callback. When the audio mixing file playback finishes, the SDK triggers the OnAudioMixingStateChanged (STOPPED) callback on the local client. Call this method after joining a channel. If you need to call StartAudioMixing [2/2] multiple times, ensure that the time interval between calling this method is more than 500 ms.
         *  If the local audio mixing file does not exist, or if the SDK does not support the file format or cannot access the music file URL, the SDK returns WARN_AUDIO_MIXING_OPEN_ERROR (701).
         * @param
         *  loopback: Whether to only play music files on the local client:
         *  true: Only play music files on the local client so that only the local user can hear the music.
         *  false: Publish music files to remote clients so that both the local user and remote users can hear the music.
         *  
         *  filePath: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4. Supported audio formats include MP3, AAC, M4A, MP4, WAV, and 3GP. See supported audio formats.
         *  replace: Whether to replace the audio captured by the microphone with a music file:
         *  true: Replace the audio captured by the microphone with a music file. Users can only hear the music.
         *  false: Do not replace the audio captured by the microphone with a music file. Users can hear both music and audio captured by the microphone.
         *  
         *  cycle: The number of times the music file plays.
         *  ≥ 0: The number of playback times. For example, 0 means that the SDK does not play the music file while 1 means that the SDK plays once.
         *  -1: Play the music effect in an infinite loop.
         *  
         *  startPos: The playback position (ms) of the music file.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int startPos);
        /**
         * Stops playing and mixing the music file.
         * This method stops the audio mixing. Call this method when you are in a channel.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopAudioMixing();
        /**
         * Pauses playing and mixing the music file.
         * Call this method when you are in a channel.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int PauseAudioMixing();
        /**
         * Resumes playing and mixing the music file.
         * This method resumes playing and mixing the music file. Call this method when you are in a channel.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int ResumeAudioMixing();

        /**
         * Set audio high quality options.
         * Deprecated:
         *  This method is deprecated. Agora does not recommend using this method. If you want to set the audio high-quality options, use the SetAudioProfile method instead.
         * @param
         *  fullband: Whether to enable full-band codec (48-kHz sample rate). Not compatible with SDK versions before v1.7.4. true: Enable full-band codec.
         *  false: Disable full-band codec. 
         *  fullBitrate: High bitrate mode. Recommended in voice-only mode. true: Enable high-bitrate mode.
         *  false: Disable high-bitrate mode. 
         *  stereo: Whether to enable stereo codec. Not compatible with SDK versions before v1.7.4. true: Enable stereo codec.
         *  false: Disable stereo codec. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetHighQualityAudioParameters(bool fullband, bool stereo, bool fullBitrate);

        /**
         * Adjusts the volume during audio mixing.
         * This method adjusts the audio mixing volume on both the local client and remote clients. Call this method after StartAudioMixing [2/2] .
         *  Calling this method does not affect the volume of audio effect file playback invoked by the PlayEffect [2/2] method.
         * @param
         *  volume: Audio mixing volume. The value ranges between 0 and 100. The default value is 100, the original volume.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int AdjustAudioMixingVolume(int volume);
        /**
         * Adjusts the volume of audio mixing for local playback.
         * You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(PLAY) callback.
         * @param
         *  volume: Audio mixing volume for local playback. The value range is [0,100]. The default value is 100, the original volume.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int AdjustAudioMixingPlayoutVolume(int volume);
        /**
         * Retrieves the audio mixing volume for local playback.
         * This method helps troubleshoot audio volume‑related issues.
         *  You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(PLAY) callback.
         * @return
         * ≥ 0: The audio mixing volume, if this method call succeeds. The value range is [0,100].
         *  < 0: Failure.
         */
        public abstract int GetAudioMixingPlayoutVolume();
        /**
         * Adjusts the volume of audio mixing for publishing.
         * This method adjusts the volume of audio mixing for publishing (sending to other users).
         *  You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(PLAY) callback.
         * @param
         *  volume: Audio mixing volume. The value range is [0,100]. The default value is 100, the original volume.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int AdjustAudioMixingPublishVolume(int volume);
        /**
         * Retrieves the audio mixing volume for publishing.
         * This method helps troubleshoot audio volume‑related issues.
         *  You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(PLAY) callback.
         * @return
         * ≥ 0: The audio mixing volume, if this method call succeeds. The value range is [0,100].
         *  < 0: Failure.
         */
        public abstract int GetAudioMixingPublishVolume();

        /**
         * Retrieves the duration (ms) of the music file.
         * Deprecated:
         *  Deprecated as of v3.4.0. Please use GetAudioFileInfo instead. 
         *  Retrieves the total duration (ms) of the audio.
         *  You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
         * @return
         * ≥ 0: The audio mixing duration, if this method call succeeds.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetAudioMixingDuration();

        /**
         * Retrieves the duration (ms) of the music file.
         * Call this method after joining a channel.
         * @param
         *  filePath: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4. Supported audio formats include MP3, AAC, M4A, MP4, WAV, and 3GP. See supported audio formats.
         * @return
         * ≥ 0: A successful method call. Returns the total duration (ms) of the specified music file.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int GetAudioMixingDuration(string filePath);

        /**
         * Retrieves the playback position (ms) of the music file.
         * Retrieves the playback position (ms) of the audio.
         *  You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(PLAY) callback.
         * @return
         * ≥ 0: The current playback position of the audio mixing, if this method call succeeds.
         *  < 0: Failure.
         */
        public abstract int GetAudioMixingCurrentPosition();
        /**
         * Sets the audio mixing position.
         * Call this method to set the playback position of the music file to a different starting position (the default plays from the beginning).
         *  You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(PLAY) callback.
         * @param
         *  pos: Integer. The playback position (ms).
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetAudioMixingPosition(int pos);
        /**
         * Sets the pitch of the local music file.
         * When a local music file is mixed with a local human voice, call this method to set the pitch of the local music file only.
         *  You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
         * @param
         *  pitch: Sets the pitch of the local music file by the chromatic scale. The default value is 0, which means keeping the original pitch. The value ranges from -12 to 12, and the pitch value between consecutive values is a chromatic value. The greater the absolute value of this parameter, the higher or lower the pitch of the local music file.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetAudioMixingPitch(int pitch);
        /**
         * Retrieves the volume of the audio effects.
         * The volume is an integer ranging from 0 to 100. The default value is 100, the original volume.
         *  Call this method after PlayEffect [2/2] .
         * @return
         * Volume of the audio effects, if this method call succeeds.
         *  < 0: Failure.
         */
        public abstract int GetEffectsVolume();
        /**
         * Sets the volume of the audio effects.
         * Call this method after PlayEffect [2/2] .
         * @param
         *  volume: The playback volume. The value ranges from 0 to 100. The default value is 100, which represents the original volume.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetEffectsVolume(int volume);
        /**
         * Sets the volume of a specified audio effect.
         * Call this method after PlayEffect [2/2] .
         * @param
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         *  volume: The playback volume. The value ranges from 0 to 100. The default value is 100, which represents the original volume.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetVolumeOfEffect(int soundId, int volume);
        /**
         * Enables/Disables face detection for the local user.
         * You can call this method either before or after joining a channel.
         *  Once face detection is enabled, the SDK triggers the OnFacePositionChanged callback to report the face information of the local user:
         *  The width and height of the local video.
         *  The position of the human face in the local video.
         *  The distance between the human face and the screen. This method needs to be called after the camera is started (for example, by calling StartPreview or JoinChannel [2/2]).
         * @param
         *  enable: Whether to enable face detection:
         *  true: Enable face detection.
         *  false: (Default) Disable face detection.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableFaceDetection(bool enable);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int PlayEffect(int soundId, string filePath, int loopCount, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false);

        /**
         * Plays the specified local or online audio effect file.
         * Deprecated:
         *  This method is deprecated as of v3.4.0. Please use PlayEffect [2/2] instead. To play multiple audio effect files at the same time, call this method multiple times with different soundId and filePath. For the best user experience, Agora recommends playing no more than three audio effect files at the same time. After the playback of an audio effect file completes, the SDK triggers the OnAudioEffectFinished callback. Call this method after joining a channel.
         *  Supported audio formats include MP3, AAC, M4A, MP4, WAV, and 3GP. See supported audio formats.
         * @param
         *  pitch: The pitch of the audio effect. The value range is 0.5 to 2.0. The default value is 1.0, which means the original pitch. The smaller the value, the lower the pitch.
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.If you have preloaded an audio effect into memory by calling PreloadEffect , ensure that this parameter is set to the same value as soundId in PreloadEffect.
         *  pan: The spatial position of the audio effect. The value ranges between -1.0 and 1.0, where:
         *  -1.0: The audio effect displays to the left.
         *  0.0: The audio effect displays ahead.
         *  1.0: The audio effect displays to the right. 
         *  filePath: If you have preloaded an audio effect into memory by calling PreloadEffect , ensure that this parameter is set to the same value as filePath in PreloadEffect.
         *  
         *  loopCount: The number of times the audio effect loops:
         *  ≥ 0: The number of playback times. For example, 1 means loop one time, which means play the audio effect two times in total.
         *  -1: Play the audio effect in an infinite loop. 
         *  gain: The volume of the audio effect. The value range is 0.0 to 100.0. The default value is 100.0, which means the original volume. The smaller the value, the lower the volume.
         *  publish: Whether to publish the audio effect to the remote users.
         *  true: Publish the audio effect to the remote users. Both the local user and remote users can hear the audio effect.
         *  false: Do not publish the audio effect to the remote users. Only the local user can hear the audio effect. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int PlayEffect(int soundId, string filePath, int loopCount, int startPos, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false);

        /**
         * Stops playing a specified audio effect.
         * @param
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopEffect(int soundId);
        /**
         * Stops playing all audio effects.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopAllEffects();
        /**
         * Preloads a specified audio effect file into the memory.
         * To ensure smooth communication, limit the size of the audio effect file. We recommend using this method to preload the audio effect before calling JoinChannel [2/2]. This method does not support online audio effect files.
         *  For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.
         * @param
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         *  filePath: File path:
         *  Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int PreloadEffect(int soundId, string filePath);
        /**
         * Releases a specified preloaded audio effect from the memory.
         * @param
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int UnloadEffect(int soundId);
        /**
         * Pauses a specified audio effect.
         * @param
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int PauseEffect(int soundId);
        /**
         * Pauses all audio effects.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int PauseAllEffects();
        /**
         * Resumes playing a specified audio effect.
         * @param
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int ResumeEffect(int soundId);
        /**
         * Resumes playing all audio effects.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int ResumeAllEffects();
        /**
         * Retrieves the duration of the audio effect file.
         * Call this method after joining a channel.
         * @param
         *  filePath: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4. Supported audio formats include MP3, AAC, M4A, MP4, WAV, and 3GP. See supported audio formats.
         *  
         * @return
         * ≥ 0: A successful method call. Returns the total duration (ms) of the specified audio effect file.
         *  < 0: Failure.
         */
        public abstract int GetEffectDuration(string filePath);
        /**
         * Sets the playback position of an audio effect file.
         * After a successful setting, the local audio effect file starts playing at the specified position.
         *  Call this method after playEffect.
         * @param
         *  pos: The playback position (ms) of the audio effect file.
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetEffectPosition(int soundId, int pos);
        /**
         * Retrieves the playback position of the audio effect file.
         * Call this method after PlayEffect [2/2].
         * @param
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         * @return
         * ≥ 0: A successful method call. Returns the playback position (ms) of the specified audio effect file.
         *  < 0: Failure.
         */
        public abstract int GetEffectCurrentPosition(int soundId);
        /**
         * Enables/Disables deep-learning noise reduction.
         * The SDK enables traditional noise reduction mode by default to reduce most of the stationary background noise. If you need to reduce most of the non-stationary background noise, Agora recommends enabling deep-learning noise reduction as follows: Ensure that the dynamic library is integrated in your project: libagora_ai_denoise_extension.dll
         *  Call enableDeepLearningDenoise(true). Deep-learning noise reduction requires high-performance devices. The deep-learning noise reduction is enabled only when the device supports this function. 
         *  After successfully enabling deep-learning noise reduction, if the SDK detects that the device performance is not sufficient, it automatically disables deep-learning noise reduction and enables traditional noise reduction.
         *  If you call enableDeepLearningDenoise(true) or the SDK automatically disables deep-learning noise reduction in the channel, when you need to re-enable deep-learning noise reduction, you need to call LeaveChannel first, and then call enableDeepLearningDenoise(true). This method dynamically loads the library, so Agora recommends calling this method before joining a channel.
         *  This method works best with the human voice. Agora does not recommend using this method for audio containing music.
         * @param
         *  enable: Whether to enable deep-learning noise reduction. true: (Default) Enable deep-learning noise reduction.
         *  false: Disable deep-learning noise reduction. 
         * @return
         * 0: Success.
         *  < 0: Failure. -157 (ERR_MODULE_NOT_FOUND): The dynamic library for enabling deep-learning noise reduction is not integrated.
         */
        public abstract int EnableDeepLearningDenoise(bool enable);
        /**
         * Enables/Disables stereo panning for remote users.
         * Ensure that you call this method before joining a channel to enable stereo panning for remote users so that the local user can track the position of a remote user by calling SetRemoteVoicePosition.
         * @param
         *  enabled: Whether to enable stereo panning for remote users:
         *  true: Enable stereo panning.
         *  false: Disable stereo panning. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableSoundPositionIndication(bool enabled);
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
         * Changes the voice pitch of the local speaker.
         * You can call this method either before or after joining a channel.
         * @param
         *  pitch: The local voice pitch. The value range is [0.5,2.0]. The lower the value, the lower the pitch. The default value is 1 (no change to the pitch).
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetLocalVoicePitch(double pitch);
        /**
         * Sets the local voice equalization effect.
         * You can call this method either before or after joining a channel.
         * @param
         *  bandFrequency: The band frequency. The value ranges between 0 and 9; representing the respective 10-band center frequencies of the voice effects, including 31, 62, 125, 250, 500, 1k, 2k, 4k, 8k, and 16k Hz. For more details, see AUDIO_EQUALIZATION_BAND_FREQUENCY .
         *  bandGain: The gain of each band in dB. The value ranges between -15 and 15. The default value is 0.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);
        /**
         * Sets the local voice reverberation.
         * You can call this method either before or after joining a channel.
         * @param
         *  reverbKey: The reverberation key. Agora provides 5 reverberation keys: AUDIO_REVERB_TYPE .
         *  value: The value of the reverberation key.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);

        /**
         * Sets the local voice changer option.
         * Deprecated:
         *  Deprecated from v3.2.0. Use the following methods instead: 
         *  SetAudioEffectPreset : Audio effects. 
         *  SetVoiceBeautifierPreset : Voice beautifier effects. 
         *  SetVoiceConversionPreset : Voice conversion effects. This method can be used to set the local voice effect for users in a COMMUNICATION channel or hosts in a LIVE_BROADCASTING channel. After successfully calling this method, all users in the channel can hear the voice with reverberation.
         *  VOICE_CHANGER_XXX: Changes the local voice to an old man, a little boy, or the Hulk. Applies to the voice talk scenario.
         *  VOICE_BEAUTY_XXX: Beautifies the local voice by making it sound more vigorous, resounding, or adding spacial resonance. Applies to the voice talk and singing scenario.
         *  GENERAL_VOICE_BEAUTY_XXX: Adds gender-based beautification effect to the local voice. Applies to the voice talk scenario. For a male voice: Adds magnetism to the voice. For a male voice: Adds magnetism to the voice. For a female voice: Adds freshness or vitality to the voice. To achieve better voice effect quality, Agora recommends setting the SetAudioProfile profile parameter in asAUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) orAUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5).
         *  This method works best with the human voice, and Agora does not recommend using it for audio containing music and a human voice.
         *  Do not use this method with SetLocalVoiceReverbPreset , because the method called later overrides the one called earlier. For detailed considerations, see the advanced guide Set the Voice Effect.
         *  You can call this method either before or after joining a channel.
         * @param
         *  voiceChanger: The local voice changer option. The default value is VOICE_CHANGER_OFF , which means the original voice. For more details, see VOICE_CHANGER_PRESET . The gender-based beatification effect works best only when assigned a proper gender. Use GENERAL_BEAUTY_VOICE_MALE_MAGNETIC for male and use GENERAL_BEAUTY_VOICE_FEMALE_FRESH and GENERAL_BEAUTY_VOICE_FEMALE_VITALITY for female. Failure to do so can lead to voice distortion.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger);

        /**
         * Sets the local voice reverberation option, including the virtual stereo.
         * This method sets the local voice reverberation for users in a COMMUNICATION channel or hosts in a LIVE_BROADCASTING channel. After successfully calling this method, all users in the channel can hear the voice with reverberation. When using the enumeration value prefixed with AUDIO_REVERB_FX, ensure that you set the profile parameter in SetAudioProfile toAUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before calling this method. Otherwise, the method setting is invalid.
         *  When calling the AUDIO_VIRTUAL_STEREO method, Agora recommends setting the profile parameter in SetAudioProfile as AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5).
         *  This method works best with the human voice, and Agora does not recommend using it for audio containing music and a human voice.
         *  Do not use this method with SetLocalVoiceChanger , because the method called later overrides the one called earlier. For detailed considerations, see the advanced guide Set the Voice Effect.
         *  You can call this method either before or after joining a channel.
         * @param
         *  reverbPreset: The local voice reverberation option. The default value is AUDIO_REVERB_OFF, which means the original voice. For more details, see AUDIO_REVERB_PRESET . To achieve better voice effects, Agora recommends the enumeration whose name begins with AUDIO_REVERB_FX.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetLocalVoiceReverbPresetWarning, false)]
        public abstract int SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset);

        /**
         * Sets a preset voice beautifier effect.
         * Call this method to set a preset voice beautifier effect for the local user who sends an audio stream. After setting a voice beautifier effect, all users in the channel can hear the effect. You can set different voice beautifier effects for different scenarios. 
         *  For better voice effects, Agora recommends that you call SetAudioProfile and set scenario to AUDIO_SCENARIO_GAME_STREAMING (3) and profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5) before calling this method. You can call this method either before or after joining a channel.
         *  Do not set the profile parameter in SetAudioProfile to AUDIO_PROFILE_SPEECH_STANDARD(1), or the method does not take effect.
         *  This method works best with the human voice. Agora does not recommend using this method for audio containing music.
         *  After calling SetVoiceBeautifierPreset, Agora recommends not calling the following methods, because they can override SetVoiceBeautifierPreset: 
         *  SetAudioEffectPreset 
         *  SetAudioEffectParameters 
         *  SetLocalVoiceReverbPreset 
         *  SetLocalVoiceChanger 
         *  SetLocalVoicePitch 
         *  SetLocalVoiceEqualization 
         *  SetLocalVoiceReverb 
         *  SetVoiceBeautifierParameters 
         *  SetVoiceConversionPreset
         * @param
         *  preset: The preset voice beautifier effect options: VOICE_BEAUTIFIER_PRESET .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset);
        /**
         * Sets an SDK preset audio effect.
         * Call this method to set an SDK preset audio effect for the local user who sends an audio stream. This audio effect does not change the gender characteristics of the original voice. After setting an audio effect, all users in the channel can hear the effect.
         *  You can set different audio effects for different scenarios. See Set the Voice Beautifier and Audio Effects.
         *  To get better audio effect quality, Agora recommends calling SetAudioProfile and setting the scenario parameter as AUDIO_SCENARIO_GAME_STREAMING (3) before calling this method. You can call this method either before or after joining a channel.
         *  Do not set the profile parameter in SetAudioProfile to AUDIO_PROFILE_SPEECH_STANDARD (1), or the method does not take effect.
         *  This method works best with the human voice. Agora does not recommend using this method for audio containing music.
         *  If you call SetAudioEffectPreset and set enumerators except for ROOM_ACOUSTICS_3D_VOICE or PITCH_CORRECTION, do not call SetAudioEffectParameters ; otherwise, SetAudioEffectPreset is overridden.
         *  After calling SetAudioEffectPreset, Agora recommends not calling the following methods, because they can override SetAudioEffectPreset: 
         *  SetVoiceBeautifierPreset 
         *  SetLocalVoiceReverbPreset 
         *  SetLocalVoiceChanger 
         *  SetLocalVoicePitch 
         *  SetLocalVoiceEqualization 
         *  SetLocalVoiceReverb 
         *  SetVoiceBeautifierParameters 
         *  SetVoiceConversionPreset
         * @param
         *  preset: The options for SDK preset audio effects. See AUDIO_EFFECT_PRESET .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset);
        /**
         * Sets a preset voice beautifier effect.
         * Call this method to set a preset voice beautifier effect for the local user who sends an audio stream. After setting an audio effect, all users in the channel can hear the effect. You can set different audio effects for different scenarios. See Set the Voice Beautifier and Audio Effects.
         *  To achieve better audio effect quality, Agora recommends that you call SetAudioProfile and set the profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) and scenario to AUDIO_SCENARIO_GAME_STREAMING(3) before calling this method. You can call this method either before or after joining a channel.
         *  Do not setSetAudioProfile the profile parameter in to AUDIO_PROFILE_SPEECH_STANDARD(1)
         *  This method works best with the human voice. Agora does not recommend using this method for audio containing music.
         *  After calling SetVoiceConversionPreset, Agora recommends not calling the following methods, or the settings in SetVoiceConversionPreset are overridden : 
         *  SetAudioEffectPreset 
         *  SetAudioEffectParameters 
         *  SetVoiceBeautifierPreset 
         *  SetVoiceBeautifierParameters 
         *  SetLocalVoiceReverbPreset 
         *  SetLocalVoiceChanger 
         *  SetLocalVoicePitch 
         *  SetLocalVoiceEqualization 
         *  SetLocalVoiceReverb
         * @param
         *  preset: The options for the preset voice beautifier effects: VOICE_CONVERSION_PRESET .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset);
        /**
         * Sets parameters for SDK preset audio effects.
         * Since
         *  v3.2.0 Call this method to set the following parameters for the local user who sends an audio stream:
         *  3D voice effect: Sets the cycle period of the 3D voice effect.
         *  Pitch correction effect: Sets the basic mode and tonic pitch of the pitch correction effect. Different songs have different modes and tonic pitches. Agora recommends bounding this method with interface elements to enable users to adjust the pitch correction interactively. After setting the audio parameters, all users in the channel can hear the effect. You can call this method either before or after joining a channel.
         *  To get better audio effect quality, Agora recommends calling and setting scenario in SetAudioProfile as AUDIO_SCENARIO_GAME_STREAMING(3) before calling this method.
         *  Do not set the profile parameter in SetAudioProfile to AUDIO_PROFILE_SPEECH_STANDARD (1) or AUDIO_PROFILE_IOT(6), or the method does not take effect.
         *  This method works best with the human voice. Agora does not recommend using this method for audio containing music.
         *  After calling SetAudioEffectParameters, Agora recommends not calling the following methods, or the settings in SetAudioEffectParameters are overridden : 
         *  SetAudioEffectPreset 
         *  SetVoiceBeautifierPreset 
         *  SetLocalVoiceReverbPreset 
         *  SetLocalVoiceChanger 
         *  SetLocalVoicePitch 
         *  SetLocalVoiceEqualization 
         *  SetLocalVoiceReverb 
         *  SetVoiceBeautifierParameters 
         *  SetVoiceConversionPreset
         * @param
         *  preset: The options for SDK preset audio effects:
         *  ROOM_ACOUSTICS_3D_VOICE, 3D voice effect:
         *  Call and set the profile parameter in SetAudioProfile to AUDIO_PROFILE_MUSIC_STANDARD_STEREO (3) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before setting this enumerator; otherwise, the enumerator setting does not take effect.
         *  If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect. PITCH_CORRECTION, Pitch correction effect: To achieve better audio effect quality, Agora recommends calling SetAudioProfile and setting the profile parameter to AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before setting this enumerator. 
         *  param1: If you set preset to ROOM_ACOUSTICS_3D_VOICE , param1 sets the cycle period of the 3D voice effect. The value range is [1,60] and the unit is seconds. The default value is 10, indicating that the voice moves around you every 10 seconds.
         *  If you set preset to PITCH_CORRECTION , param1 sets the basic mode of the pitch correction effect:
         * 1: (Default) Natural major scale.
         * 2: Natural minor scale.
         * 3: Japanese pentatonic scale. 
         *  
         *  param2: If you set preset to ROOM_ACOUSTICS_3D_VOICE, you need to set param2 to 0.
         *  If you set preset to PITCH_CORRECTION, param2 sets the tonic pitch of the pitch correction effect:
         * 1: A
         * 2: A#
         * 3: B
         * 4: (Default) C
         * 5: C#
         * 6: D
         * 7: D#
         * 8: E
         * 9: F
         * 10: F#
         * 11: G
         * 12: G# 
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);
        /**
         * Sets parameters for the preset voice beautifier effects.
         * Since
         *  v3.3.0 Call this method to set a gender characteristic and a reverberation effect for the singing beautifier effect. This method sets parameters for the local user who sends an audio stream. After setting the audio parameters, all users in the channel can hear the effect.
         *  For better voice effects, Agora recommends that you call SetAudioProfile and setscenario to AUDIO_SCENARIO_GAME_STREAMING(3) and profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before calling this method. You can call this method either before or after joining a channel.
         *  Do not set the profile parameter of SetAudioProfile to AUDIO_PROFILE_SPEECH_STANDARD(1) or AUDIO_PROFILE_IOT(6). Otherwise, the method does not take effect.
         *  This method works best with the human voice. Agora does not recommend using this method for audio containing music.
         *  After calling SetVoiceBeautifierParameters, Agora recommends not calling the following methods, because they can override settings in SetVoiceBeautifierParameters: 
         *  SetAudioEffectPreset 
         *  SetAudioEffectParameters 
         *  SetVoiceBeautifierPreset 
         *  SetLocalVoiceReverbPreset 
         *  SetLocalVoiceChanger 
         *  SetLocalVoicePitch 
         *  SetLocalVoiceEqualization 
         *  SetLocalVoiceReverb 
         *  SetVoiceConversionPreset
         * @param
         *  preset: The option for the preset audio effect:
         *  SINGING_BEAUTIFIER: The singing beautifier effect. 
         *  param1: The gender characteristics options for the singing voice:
         *  1: A male-sounding voice.
         *  2: A female-sounding voice. 
         *  param2: The reverberation effect options for the singing voice:
         *  1: The reverberation effect sounds like singing in a small room.
         *  2: The reverberation effect sounds like singing in a large room.
         *  3: The reverberation effect sounds like singing in a hall. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2);

        /**
         * Sets the log files that the SDK outputs.
         * By default, the SDK outputs five log files: agorasdk.log, agorasdk_1.log, agorasdk_2.log, agorasdk_3.log, and agorasdk_4.log. Each log file has a default size of 512 KB. These log files are encoded in UTF-8. The SDK writes the latest log in agorasdk.log. When agorasdk.log is full, the SDK deletes the log file with the earliest modification time among the other four, renames agorasdk.log to the name of the deleted log file, and create a new agorasdk.log to record the latest logs.
         *  Ensure that you call this method immediately after initializing IAgoraRtcEngine , otherwise, the output log may not be complete.
         * @param
         *  filePath: The absolute path of the log files. The default file path is C: \Users\<user_name>\AppData\Local\Agora\<process_name>\agorasdk.log. Ensure that the directory for the log files exists and is writable. You can use this parameter to rename the log files.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetLogFileWarning, false)]
        public abstract int SetLogFile(string filePath);

        /**
         * Sets the log output level of the SDK.
         * This method sets the output log level of the SDK. You can use one or a combination of the log filter levels. The log level follows the sequence of OFF, CRITICAL, ERROR, WARNING, INFO, and DEBUG. Choose a level to see the logs preceding that level.
         *  If, for example, you set the log level to WARNING, you see the logs within levels CRITICAL, ERROR, and WARNING.
         * @param
         *  filter: The output log level of the SDK. For details, see LOG_FILTER_TYPE .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetLogFilterWarning, false)]
        public abstract int SetLogFilter(uint filter);

        /**
         * Sets the size of a log file that the SDK outputs.
         * By default, the SDK outputs five log files: agorasdk.log, agorasdk_1.log, agorasdk_2.log, agorasdk_3.log, and agorasdk_4.log. Each log file has a default size of 512 KB. These log files are encoded in UTF-8. The SDK writes the latest log in agorasdk.log. When agorasdk.log is full, the SDK deletes the log file with the earliest modification time among the other four, renames agorasdk.log to the name of the deleted log file, and create a new agorasdk.log to record the latest logs.
         *  If you want to set the size of the log file, you need to call this method before SetLogFile , otherwise, the log will be cleared.
         * @param
         *  fileSizeInKBytes: The size (KB) of a log file. The default value is 1024 KB. If you set fileSizeInKByte to 1024 KB, the maximum aggregate size of the log files output by the SDK is 5 MB. if you set fileSizeInKByte to less than 1024 KB, the setting is invalid, and the maximum size of a log file is still 1024 KB.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetLogFileSizeWarning, false)]
        public abstract int SetLogFileSize(uint fileSizeInKBytes);

        /**
         * Uploads all SDK log files.
         * Since
         *  v3.3.0 Uploads all SDK log files from the client to the Agora server. After calling this method successfully, the SDK triggers the OnUploadLogResult callback to report whether the log file is successfully uploaded to the Agora server.
         *  For easier debugging, Agora recommends that you bind the uploadLogFile method to the UI element of your app, to instruct the user to upload a log file when a quality issue occurs.
         */
        public abstract string UploadLogFile();

        /**
         * Sets the local video display mode.
         * Deprecated:
         *  This method is deprecated. Use SetLocalRenderMode [2/2] instead. 
         *  Call this method to set the local video display mode. This method can be called multiple times during a call to change the display mode.
         * @param
         *  renderMode: The local video display mode. For details, see RENDER_MODE_TYPE .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode);

        /**
         * Updates the display mode of the local video view.
         * Since
         *  v3.3.0 After initializing the local video view, you can call this method to update its rendering and mirror modes. It affects only the video view that the local user sees, not the published local video stream. Ensure that you have called the SetupLocalVideo method to initialize the local video view before calling this method.
         *  During a call, you can call this method as many times as necessary to update the display mode of the local video view.
         * @param
         *  renderMode: The local video display mode. For details, see RENDER_MODE_TYPE .
         *  
         *  mirrorMode: The rendering mode of the local video view. See VIDEO_MIRROR_MODE_TYPE .
         *  If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        /**
         * Sets the video display mode of a specified remote user.
         * Deprecated:
         *  This method is deprecated. Use SetRemoteRenderMode [2/2] instead. Call this method to set the video display mode of a specified remote user. This method can be called multiple times during a call to change the display mode.
         * @param
         *  userId: The ID of the remote user.
         *  renderMode: The rendering mode of the remote user view. For details, see RENDER_MODE_TYPE .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode);

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
         * Sets the local video mirror mode.
         * Deprecated:
         *  Deprecated as of v3.0.0.
         * @param
         *  mirrorMode: The local video mirror mode. For details, see VIDEO_MIRROR_MODE_TYPE .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.SetLocalVideoMirrorModeWarning, false)]
        public abstract int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode);

        /**
         * Enables/Disables dual-stream mode.
         * You can call this method to enable or disable the dual-stream mode on the publisher side. Dual streams are a hybrid of a high-quality video stream and a low-quality video stream:
         *  High-quality video stream: High bitrate, high resolution.
         *  Low-quality video stream: Low bitrate, low resolution.
         *  After you enable the dual-stream mode, you can call SetRemoteVideoStreamType to choose to receive the high-quality video stream or low-quality video stream on the subscriber side.
         * @param
         *  enabled: Whether to enable dual-stream mode.
         *  true: Enable dual-stream mode.
         *  false: Disable dual-stream mode. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableDualStreamMode(bool enabled);
        /**
         * Sets the external audio source.
         * Call this method before calling JoinChannel [1/2] and StartPreview .
         * @param
         *  enabled: true: Enable the external audio source.
         *  false: (Default) Disable the external audio source. 
         *  channels: The number of audio channels of the external audio source:
         *  1: Mono.
         *  2: Stereo. 
         *  sampleRate: The sample rate (Hz) of the external audio source, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels);
        /**
         * Sets the external audio sink.
         * This method applies to scenarios where you want to use external audio data for playback. After enabling the external audio sink, you can call the PullAudioFrame method to pull the remote audio data, process it, and play it with the audio effects that you want. Once you enable the external audio sink, the app will not retrieve any audio data from the OnPlaybackAudioFrame callback.
         *  Ensure that you call this method before joining a channel.
         * @param
         *  enabled: true: Enables the external audio sink.
         *  false: (Default) Disables the external audio sink. 
         *  channels: The number of audio channels of the external audio sink:
         *  1: Mono.
         *  2: Stereo.
         *  
         *  sampleRate: The sample rate (Hz) of the external audio sink, which can be set as 16000, 32000, 44100, or 48000.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetExternalAudioSink(bool enabled, int sampleRate, int channels);

        /**
         * Sets the format of the captured raw audio data.
         * Ensure that you call this method before joining a channel.
         *  The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method.Sample interval (sec) = samplePerCall/(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s).
         * @param
         *  sampleRate: The sample rate returned in the OnRecordAudioFrame callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.
         *  channel: The number of channels returned in the OnRecordAudioFrame callback:
         *  1: Mono.
         *  2: Stereo. 
         *  mode: The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE .
         *  
         *  samplesPerCall: The number of data samples returned in the OnRecordAudioFrame callback, such as 1024 for the media push.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRecordingAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        /**
         * Sets the audio data format for playback.
         * Sets the data format for the OnPlaybackAudioFrame callback. Ensure that you call this method before joining a channel.
         *  The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method.Sample interval (sec) = samplePerCall/(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnPlaybackAudioFrame callback according to the sampling interval.
         * @param
         *  sampleRate: The sample rate returned in the OnPlaybackAudioFrame callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.
         *  channel: The number of channels returned in the OnPlaybackAudioFrame callback:
         *  1: Mono.
         *  2: Stereo. 
         *  mode: The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE .
         *  
         *  samplesPerCall: The number of data samples returned in the OnPlaybackAudioFrame callback, such as 1024 for the media push.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetPlaybackAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        /**
         * Sets the format of mixed audio.
         * Sets the data format for the OnMixedAudioFrame callback. Ensure that you call this method before joining a channel.
         *  The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method.Sample interval (sec) = samplePerCall/(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnMixedAudioFrame callback according to the sampling interval.
         * @param
         *  sampleRate: The sample rate returned in the OnMixedAudioFrame callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.
         *  samplesPerCall: The number of data samples returned in the OnMixedAudioFrame callback, such as 1024 for the media push.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetMixedAudioFrameParameters(int sampleRate, int samplesPerCall);
        /**
         * Adjusts the capturing signal volume.
         * You can call this method either before or after joining a channel.
         * @param
         *  volume: The playback signal volume of all remote users. Integer only. The value range is [0,400].
         *  0: Mute.
         *  100: (Default) The original volume.
         *  400: Four times the original volume (amplifying the audio signals by four times). 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int AdjustRecordingSignalVolume(int volume);
        /**
         * Adjusts the playback signal volume of all remote users.
         * This method adjusts the playback volume that is the mixed volume of all remote users.
         *  As of v2.3.2, to mute the local audio, you need to call the AdjustPlaybackSignalVolume and AdjustAudioMixingPlayoutVolume methods at the same time, and set volume to 0.
         *  You can call this method either before or after joining a channel.
         * @param
         *  volume: The playback signal volume of all remote users. Integer only. The value range is [0,400].
         *  0: Mute.
         *  100: (Default) The original volume.
         *  400: Four times the original volume (amplifying the audio signals by four times). 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int AdjustPlaybackSignalVolume(int volume);
        /**
         * Adjusts the volume of the signal captured by the sound card.
         * After calling EnableLoopbackRecording to enable loopback audio capturing, you can call this method to adjust the volume of the signal captured by the sound card.
         * @param
         *  volume: Audio mixing volume. The value ranges between 0 and 100. The default value is 100, the original volume.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int AdjustLoopbackRecordingSignalVolume(int volume);

        /**
         * Enables interoperability with the Agora Web SDK (applicable only in the live streaming scenarios).
         * Deprecated:
         *  The SDK automatically enables interoperability with the Web SDK, so you no longer need to call this method. This method enables or disables interoperability with the Agora Web SDK. If the channel has Web SDK users, ensure that you call this method, or the video of the Native user will be a black screen for the Web user.
         *  This method is only applicable in live streaming scenarios, and interoperability is enabled by default in communication scenarios.
         * @param
         *  enabled: Whether to enable interoperability with the Agora Web SDK.
         *  true: Enable interoperability.
         *  false: (Default) Disable interoperability.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int EnableWebSdkInteroperability(bool enabled);

        /**
         * Sets the preferences for high-quality video. (LIVE_BROADCASTING only).
         * Deprecated:
         *  Deprecated as of v2.4.0. Agora recommends using the degradationPreference parameter in the VideoEncoderConfiguration class to set the video quality preference.
         * @param
         *  preferFrameRateOverImageQuality: Whether to prioritize smoothness or image quality.
         *  true: Prioritizes smoothness.
         *  false: (Default) Prioritizes the image quality. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int SetVideoQualityParameters(bool preferFrameRateOverImageQuality);

        /**
         * Sets the fallback option for the published video stream based on the network conditions.
         * An unstable network affects the audio and video quality in a video call or interactive live video streaming. If option is set as STREAM_FALLBACK_OPTION_AUDIO_ONLY(2), the SDK disables the upstream video but enables audio only when the network conditions deteriorate and cannot support both video and audio. The SDK monitors the network quality and restores the video stream when the network conditions improve. When the published video stream falls back to audio-only or when the audio-only stream switches back to the video, the SDK triggers the OnLocalPublishFallbackToAudioOnly callback. Agora does not recommend using this method for CDN live streaming, because the remote CDN live user will have a noticeable lag when the published video stream falls back to STREAM_FALLBACK_OPTION_AUDIO_ONLY(2).
         *  Ensure that you call this method before joining a channel.
         * @param
         *  option: The stream fallback option. For details, see STREAM_FALLBACK_OPTIONS .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option);
        /**
         * Sets the fallback option for the remotely subscribed video stream based on the network conditions.
         * Unreliable network conditions affect the overall quality of the interactive live streaming. If option is set as STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW(1) or STREAM_FALLBACK_OPTION_AUDIO_ONLY(2), the SDK automatically switches the video from a high-quality stream to a low-quality stream or disables the video when the downlink network conditions cannot support both audio and video to guarantee the quality of the audio. The SDK monitors the network quality and restores the video stream when the network conditions improve. When the remote video stream falls back to audio-only or when the audio-only stream switches back to the video, the SDK triggers the OnRemoteSubscribeFallbackToAudioOnly callback.
         *  Ensure that you call this method before joining a channel.
         * @param
         *  option: The fallback option for the remotely subscribed video stream. The default value is STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW(1). See STREAM_FALLBACK_OPTIONS .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option);
        /**
         * Switches between front and rear cameras.
         * This method needs to be called after the camera is started (for example, by calling StartPreview or JoinChannel [2/2] ).
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SwitchCamera();
        /**
         * Sets the default audio playback route.
         * This method sets whether the received audio is routed to the earpiece or speakerphone by default before joining a channel. If a user does not call this method, the audio is routed to the earpiece by default.
         *  The default settings for each profile:
         *  For the communication profile:
         *  In a voice call, the default audio route is the earpiece.
         *  In a video call, the default audio route is the speakerphone. If a user calls the DisableVideo , MuteLocalVideoStream , or MuteAllRemoteVideoStreams method, the default audio route switches back to the earpiece automatically. For the live broadcasting profile: Speakerphone. This method needs to be set before , otherwise, it will not take effect.
         * @param
         *  defaultToSpeaker: The default audio playback route.
         *  true: The audio routing is speakerphone. If the device connects to the earpiece or Bluetooth, the audio cannot be routed to the speakerphone.
         *  false: (Default) Route the audio to the earpiece. If a headset is plugged in, the audio is routed to the headset. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker);
        /**
         * Enables/Disables the audio playback route to the speakerphone.
         * This method sets whether the audio is routed to the speakerphone or earpiece. After a successful method call, the SDK triggers the OnAudioRouteChanged callback. Ensure that you have joined a channel before calling this method.
         * @param
         *  speakerOn: Whether the audio is routed to the speakerphone or earpiece.
         *  true: Route the audio to the speakerphone. If the device connects to the earpiece or Bluetooth, the audio cannot be routed to the speakerphone.
         *  false: Route the audio to the earpiece. If a headset is plugged in, the audio is routed to the headset. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetEnableSpeakerphone(bool speakerOn);
        /**
         * Enables in-ear monitoring.
         * This method enables or disables in-ear monitoring. 
         *  Users must use wired earphones to hear their own voices.
         *  You can call this method either before or after joining a channel.
         * @param
         *  enabled: Enables in-ear monitoring.
         *  true: Enables in-ear monitoring.
         *  false: (Default) Disables in-ear monitoring. 
         */
        public abstract int EnableInEarMonitoring(bool enabled);
        /**
         * Sets the volume of the in-ear monitor.
         * This method is for Android and iOS only.
         *  Users must use wired earphones to hear their own voices.
         *  You can call this method either before or after joining a channel.
         * @param
         *  volume: The volume of the in-ear monitor. The value ranges between 0 and 100. The default value is 100.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetInEarMonitoringVolume(int volume);
        /**
         * Checks whether the speakerphone is enabled.
         * This method is for Android and iOS only.
         * @return
         * true: The speakerphone is enabled, and the audio plays from the speakerphone.
         *  false: The speakerphone is not enabled, and the audio plays from devices other than the speakerphone. For example, the headset or earpiece.
         */
        public abstract bool IsSpeakerphoneEnabled();
        /**
         * Sets the operational permission of the SDK on the audio session.
         * The SDK and the app can both configure the audio session by default. If you need to only use the app to configure the audio session, this method restricts the operational permission of the SDK on the audio session.
         *  You can call this method either before or after joining a channel. Once you call this method to restrict the operational permission of the SDK on the audio session, the restriction takes effect when the SDK needs to change the audio session. This method does not restrict the operational permission of the app on the audio session.
         * @param
         *  restriction: The operational permission of the SDK on the audio session. See AUDIO_SESSION_OPERATION_RESTRICTION . This parameter is in bit mask format, and each bit corresponds to a permission.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);
        /**
         * Enables loopback audio capturing.
         * If you enable loopback audio capturing, the output of the sound card is mixed into the audio stream sent to the other end. You can call this method either before or after joining a channel.
         * @param
         *  enabled: Sets whether to enable loopback capturing.
         *  true: Enable loopback audio capturing.
         *  false: (Default) Disable loopback capturing.
         *  
         *  deviceName: The device name of the sound card. The default value is NULL (the default sound card). If you use a virtual sound card like "Soundflower", set this parameter as the name of the sound card, "Soundflower". The SDK will find the corresponding sound card and start capturing.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableLoopbackRecording(bool enabled, string deviceName);

        /**
         * Shares the screen by specifying the display ID.
         * This method shares a screen or part of the screen. You need to specify the ID of the screen to be shared in this method.
         * @param
         *  displayId: The display ID of the screen to be shared. This parameter specifies which screen you want to share.
         *  captureParams: Screen sharing configurations. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters for details.
         *  regionRect: (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle for details. If the specified region overruns the screen, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect,
            ScreenCaptureParameters captureParams);

        /**
         * Shares the whole or part of a screen by specifying the screen rect.
         * This method shares a screen or part of the screen. You need to specify the area of the screen to be shared.
         *  This method applies to the Windows platform only.Call this method after joining a channel.
         * @param
         *  screenRect: Sets the relative location of the screen to the virtual screen.
         *  captureParams: The screen sharing encoding parameters. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters .
         *  regionRect: (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle . If the specified region overruns the screen, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect,
            ScreenCaptureParameters captureParams);

        /**
         * Shares the whole or part of a window by specifying the window ID.
         * This method shares a window or part of the window. You need to specify the ID of the window to be shared. Call this method after joining a channel.
         *  This method applies to macOS and Windows only.
         * @param
         *  windowId: The ID of the window to be shared.
         *  captureParams: Screen sharing configurations. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. 
         *  regionRect: (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen.  If the specified region overruns the window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole window.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect,
            ScreenCaptureParameters captureParams);

        /**
         * Sets the content hint for screen sharing.
         * A content hint suggests the type of the content being shared, so that the SDK applies different optimization algorithms to different types of content. If you don't call this method, the default content hint is CONTENT_HINT_NONE.
         *  You can call this method either before or after you start screen sharing.
         * @param
         *  contentHint: The content hint for screen sharing. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetScreenCaptureContentHint(VideoContentHint contentHint);
        /**
         * Updates the screen sharing parameters.
         * @param
         *  captureParams: The screen sharing encoding parameters. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -3: If no screen or window is being shared, the SDK returns this error code.
         */
        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);
        /**
         * Updates the screen sharing region.
         * @param
         *  regionRect: The relative location of the screen-shared area to the screen or window. If you do not set this parameter, the SDK shares the whole screen or window. See Rectangle . If the specified region overruns the screen or window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen or window.
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -3(ERR_NOT_READY): No screen or window is being shared.
         */
        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);
        /**
         * Stops screen sharing.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopScreenCapture();
        /**
         * Retrieves the call ID.
         * When a user joins a channel on a client, a callId is generated to identify the call from the client. Some methods, such as Rate and Complain , must be called after the call ends to submit feedback to the SDK. These methods require the callId parameter.
         *  Call this method after joining a channel.
         * @return
         * The current call ID.
         */
        public abstract string GetCallId();
        /**
         * Allows a user to rate a call after the call ends.
         * Ensure that you call this method after leaving a channel.
         * @param
         *  callId: The current call ID. You can get the call ID by calling GetCallId .
         *  rating: The rating of the call. The value is between 1 (lowest score) and 5 (highest score). If you set a value out of this range, the SDK returns the -2 (ERR_INVALID_ARGUMENT) error.
         *  description: (Optional) A description of the call. The string length should be less than 800 bytes.
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -2 (ERR_INVALID_ARGUMENT).
         *  -3 (ERR_NOT_READY)。
         */
        public abstract int Rate(string callId, int rating, string description = "");
        /**
         * Allows a user to complain about the call quality after a call ends.
         * This method allows users to complain about the quality of the call. Call this method after the user leaves the channel.
         * @param
         *  callId: The current call ID. You can get the call ID by calling GetCallId .
         *  description: (Optional) A description of the call. The string length should be less than 800 bytes.
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  -2 (ERR_INVALID_ARGUMENT).
         *  -3 (ERR_NOT_READY)。
         */
        public abstract int Complain(string callId, string description = "");
        /**
         * Gets the SDK version.
         * @return
         * The SDK version number. The format is a string.
         */
        public abstract string GetVersion();
        /**
         * Enables the network connection quality test.
         * This method tests the quality of the users' network connections. By default, this function is disabled. This method applies to the following scenarios:
         *  Before a user joins a channel, call this method to check the uplink network quality.
         *  Before an audience switches to a host, call this method to check the uplink network quality. Regardless of the scenario, enabling this method consumes extra network traffic and affects the call quality. After receiving the OnLastmileQuality callback, call DisableLastmileTest to stop the test, and then join the channel or switch to the host. Do not use this method together with StartLastmileProbeTest .
         *  Do not call any other methods before receiving the OnLastmileQuality callback. Otherwise, the callback may be interrupted by other methods, and hence may not be triggered.
         *  A host should not call this method after joining a channel (when in a call).
         *  If you call this method to test the last mile network quality, the SDK consumes the bandwidth of a video stream, whose bitrate corresponds to the bitrate you set in SetVideoEncoderConfiguration . After joining a channel, whether you have called DisableLastmileTest or not, the SDK automatically stops consuming the bandwidth.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableLastmileTest();
        /**
         * Disables the network connection quality test.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int DisableLastmileTest();
        /**
         * Starts the last mile network probe test.
         * This method starts the last-mile network probe test before joining a channel to get the uplink and downlink last mile network statistics, including the bandwidth, packet loss, jitter, and round-trip time (RTT).
         *  Once this method is enabled, the SDK returns the following callbacks: 
         *  OnLastmileQuality : The SDK triggers this callback within two seconds depending on the network conditions. This callback rates the network conditions and is more closely linked to the user experience. 
         *  OnLastmileProbeResult : The SDK triggers this callback within 30 seconds depending on the network conditions. This callback returns the real-time statistics of the network conditions and is more objective. This method applies to the following scenarios:
         *  Before a user joins a channel, call this method to check the uplink network quality.
         *  In a live streaming channel, call this method to check the uplink network quality before an audience member switches to a host. This method consumes extra network traffic and may affect communication quality. We do not recommend calling this method and EnableLastmileTest at the same time.
         *  Do not call other methods before receiving the OnLastmileQuality and OnLastmileProbeResult callbacks. Otherwise, the callbacks may be interrupted.
         *  A host should not call this method after joining a channel (when in a call).
         * @param
         *  config: The configurations of the last-mile network probe test. See LastmileProbeConfig .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartLastmileProbeTest(LastmileProbeConfig config);
        /**
         * Stops the last mile network probe test.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopLastmileProbeTest();
        /**
         * Gets the warning or error description.
         * @param
         *  code: The error code or warning code reported by the SDK.
         * @return
         * The specific error or warning description.
         */
        public abstract string GetErrorDescription(int code);

        /**
         * Enables built-in encryption with an encryption password before users join a channel.
         * Deprecated:
         *  This method is deprecated from v3.2.0. Please use EnableEncryption instead. Before joining the channel, you need to call this method to set the secret parameter to enable the built-in encryption. All users in the same channel should use the same secret. The secret is automatically cleared once a user leaves the channel. If you do not specify the secret or secret is set as null, the built-in encryption is disabled. Do not use this method for CDN live streaming.
         *  For optimal transmission, ensure that the encrypted data size does not exceed the original data size + 16 bytes. 16 bytes is the maximum padding size for AES encryption.
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
         * Deprecated:
         *  Use EnableEncryption instead. The Agora SDK supports built-in encryption, which is set to the AES-128-XTS mode by default. Call this method to use other encryption modes. All users in the same channel must use the same encryption mode and secret. Refer to the information related to the AES encryption algorithm on the differences between the encryption modes.
         *  Before calling this method, please call SetEncryptionSecret to enable the built-in encryption function.
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
         * Creates a data stream.
         * Each user can create up to five data streams during the lifecycle of IAgoraRtcEngine . Call this method after joining a channel.
         *  Agora does not support setting reliable as true and ordered as true.
         * @param
         *  reliable: Whether or not the data stream is reliable:
         *  true: The recipients receive the data from the sender within five seconds. If the recipient does not receive the data within five seconds, the SDK triggers the OnStreamMessageError callback and returns an error code.
         *  false: There is no guarantee that the recipients receive the data stream within five seconds and no error message is reported for any delay or missing data stream.
         *  
         *  ordered: Whether or not the recipients receive the data stream in the sent order:
         *  true: The recipients receive the data in the sent order.
         *  false: The recipients do not receive the data in the sent order.
         *  
         * @return
         * ID of the created data stream, if the method call succeeds.
         *  < 0: Failure. You can refer to Error Codes and Warning Codes for troubleshooting.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int CreateDataStream(bool reliable, bool ordered);

        /**
         * Creates a data stream.
         * Creates a data stream. Each user can create up to five data streams in a single channel.
         *  Compared with CreateDataStream [1/2] [1/2], this method does not support data reliability. If a data packet is not received five seconds after it was sent, the SDK directly discards the data.
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
         * Deprecated: This method is deprecated. After calling this method, you can push media streams in RTMP or RTMPS protocol to the CDN. The SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of adding a local stream to the CDN. Call this method after joining a channel.
         *  Ensure that the media push function is enabled. 
         *  This method takes effect only when you are a host in live interactive streaming.
         *  This method adds only one streaming URL to the CDN each time it is called. To push multiple URLs, call this method multiple times.
         *  Agora only supports pushing media streams to the CDN in RTMPS protocol when you enable transcoding.
         * @param
         *  url: The media push URL in the RTMP or RTMPS format. The maximum length of this parameter is 1024 bytes. The URL address must not contain special characters, such as Chinese language characters.
         *  transcodingEnabled: Whether to enable transcoding. Transcoding in a CDN live streaming converts the audio and video streams before pushing them to the CDN server. It applies to scenarios where a channel has multiple broadcasters and composite layout is needed.
         *  true: Enable transcoding.
         *  false: Disable transcoding. If you set this parameter as true, ensure that you call the SetLiveTranscoding method before calling this method.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         *  ERR_INVALID_ARGUMENT (-2): Invalid argument, usually because the URL address is null or the string length is 0.
         *  ERR_NOT_INITIALIZED (-7): You have not initialized the RTC engine when publishing the stream.
         */
        public abstract int AddPublishStreamUrl(string url, bool transcodingEnabled);
        /**
         *  Removes an RTMP or RTMPS stream from the CDN. 
         * Deprecated: This method is deprecated. After a successful method call, the SDK triggers OnRtmpStreamingStateChanged on the local client to report the result of deleting the URL. Before calling this method, make sure that the media push function has been enabled. 
         *  This method takes effect only when you are a host in live interactive streaming.
         *  Call this method after joining a channel.
         *  This method removes only one media push URL each time it is called. To remove multiple URLs, call this method multiple times.
         * @param
         *  url: The media push URL to be removed. The maximum length of this parameter is 1024 bytes. The media push URL must not contain special characters, such as Chinese characters.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int RemovePublishStreamUrl(string url);
        /**
         * Sets the transcoding configurations for media push.
         * Deprecated: This method is deprecated. This method sets the video layout and audio settings for media push. The SDK triggers the OnTranscodingUpdated callback when you call this method to update the transcoding settings. This method takes effect only when you are a host in live interactive streaming.
         *  Ensure that you enable the Media Push service before using this function. See Prerequisites in the advanced guide Media Push.
         *  If you call this method to set the transcoding configuration for the first time, the SDK does not trigger the OnTranscodingUpdated callback.
         *  Call this method after joining a channel.
         *  Agora only supports pushing media streams to the CDN in RTMPS protocol when you enable transcoding.
         * @param
         *  transcoding: The transcoding configurations for the media push. See LiveTranscoding for details.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetLiveTranscoding(LiveTranscoding transcoding);

        /**
         * Adds a watermark image to the local video.
         * Deprecated:
         *  This method is deprecated. Use AddVideoWatermark [2/2] instead. This method adds a PNG watermark image to the local video stream in a live streaming session. Once the watermark image is added, all the users in the channel (CDN audience included) and the video capturing device can see and capture it. If you only want to add a watermark to the CDN live streaming, see descriptions in SetLiveTranscoding . The URL descriptions are different for the local video and CDN live streaming: In a local video stream, URL refers to the absolute path of the added watermark image file in the local video stream. In a CDN live stream, URL refers to the URL address of the added watermark image in the CDN live streaming.
         *  The source file of the watermark image must be in the PNG file format. If the width and height of the PNG file differ from your settings in this method, the PNG file will be cropped to conform to your settings.
         *  The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one.
         * @param
         *  watermark: The watermark image to be added to the local live streaming: RtcImage .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int AddVideoWatermark(RtcImage watermark);

        /**
         * Adds a watermark image to the local video.
         * This method adds a PNG watermark image to the local video in the live streaming. Once the watermark image is added, all the audience in the channel (CDN audience included), and the capturing device can see and capture it. Agora supports adding only one watermark image onto the local video, and the newly watermark image replaces the previous one.
         *  The watermark coordinates are dependent on the settings in the SetVideoEncoderConfiguration method:
         *  If the orientation mode of the encoding video ( ORIENTATION_MODE ) is fixed landscape mode or the adaptive landscape mode, the watermark uses the landscape orientation.
         *  If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed portrait mode or the adaptive portrait mode, the watermark uses the portrait orientation.
         *  When setting the watermark position, the region must be less than the dimensions set in the SetVideoEncoderConfiguration method; otherwise, the watermark image will be cropped. Ensure that call this method after EnableVideo .
         *  If you only want to add a watermark to the media push, you can call this method or the SetLiveTranscoding method.
         *  This method supports adding a watermark image in the PNG file format only. Supported pixel formats of the PNG image are RGBA, RGB, Palette, Gray, and Alpha_gray.
         *  If the dimensions of the PNG image differ from your settings in this method, the image will be cropped or zoomed to conform to your settings.
         *  If you have enabled the local video preview by calling the StartPreview method, you can use the visibleInPreview member to set whether or not the watermark is visible in the preview.
         *  If you have enabled the mirror mode for the local video, the watermark on the local video is also mirrored. To avoid mirroring the watermark, Agora recommends that you do not use the mirror and watermark functions for the local video at the same time. You can implement the watermark function in your application layer.
         * @param
         *  watermarkUrl: The local file path of the watermark image to be added. This method supports adding a watermark image from the local absolute or relative file path.
         *  options: The options of the watermark image to be added. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);
        /**
         * Removes the watermark image from the video stream.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int ClearVideoWatermarks();
        /**
         * Sets the image enhancement options.
         * Enables or disables image enhancement, and sets the options. Call this method after EnableVideo .
         * @param
         *  enabled: Whether to enable the image enhancement function:
         *  true: Enable the image enhancement function.
         *  false: (Default) Disable the image enhancement function.
         *  
         *  options: The image enhancement options. See BeautyOptions .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options);
        /**
         * Enables/Disables the virtual background. (beta feature)
         * The virtual background function allows you to replace the original background image of the local user or to blur the background. After successfully enabling the virtual background function, all users in the channel can see the customized background.
         *  You can find out from the OnVirtualBackgroundSourceEnabled callback whether the virtual background is successfully enabled or the cause of any errors. Call this method after EnableVideo .
         *  This function requires a high-performance device. Agora recommends that you use this function on devices with the following chips:
         *  Devices with an i5 CPU and better Agora recommends that you use this function in scenarios that meet the following conditions:
         *  A high-definition camera device is used, and the environment is uniformly lit.
         *  There are few objects in the captured video. Portraits are half-length and unobstructed. Ensure that the background is a solid color that is different from the color of the user's clothing.
         * @param
         *  enabled: Whether to enable virtual background:
         *  true: Enable virtual background.
         *  false: Disable virtual background.
         *  
         *  backgroundSource: The custom background image. See VirtualBackgroundSource for details. To adapt the resolution of the custom background image to that of the video captured by the SDK, the SDK scales and crops the custom background image while ensuring that the content of the custom background image is not distorted.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource);
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
         * Starts relaying media streams across channels. This method can be used to implement scenarios such as co-host across channels.
         * After a successful method call, the SDK triggers OnChannelMediaRelayStateChanged the and OnChannelMediaRelayEvent callbacks, and these callbacks return the state and events of the media stream relay.
         *  If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), and the OnChannelMediaRelayEvent callback returns RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4), it means that the SDK starts relaying media streams between the source channel and the destination channel.
         *  If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_FAILURE (3), an exception occurs during the media stream relay. 
         *  Call this method after joining the channel.
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
         *  After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback with the RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL (7) state code.
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
         * After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback. If the callback reports RELAY_STATE_IDLE (0) and RELAY_OK (0), the host successfully stops the relay.
         *  If the method call fails, the SDK triggers the OnChannelMediaRelayStateChanged callback with the RELAY_ERROR_SERVER_NO_RESPONSE (2) or RELAY_ERROR_SERVER_CONNECTION_LOST (8) status code. You can call the LeaveChannel method to leave the channel, and the media stream relay automatically stops.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopChannelMediaRelay();
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
         * Reports customized messages.
         * Agora supports reporting and analyzing customized messages. This function is in the beta stage with a free trial. The ability provided in its beta test version is reporting a maximum of 10 message pieces within 6 seconds, with each message piece not exceeding 256 bytes and each string not exceeding 100 bytes. To try out this function, contact and discuss the format of customized messages with us.
         */
        public abstract int SendCustomReportMessage(string id, string category, string events, string label, int value);
        /**
         * Gets the current connection state of the SDK.
         * You can call this method either before or after joining a channel.
         * @return
         * The current connection state. For details, see CONNECTION_STATE_TYPE .
         */
        public abstract CONNECTION_STATE_TYPE GetConnectionState();
        /**
         * Registers the metadata observer.
         * Call this method before JoinChannel [2/2].
         *  This method applies only to interactive live streaming.
         * @param
         *  type: The metadata type. The SDK currently only supports VIDEO_METADATA. See METADATA_TYPE .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int RegisterMediaMetadataObserver(METADATA_TYPE type);
        /**
         * Unregisters the specified metadata observer.
         * @param
         *  type: The metadata type. The SDK currently only supports VIDEO_METADATA. For details, see METADATA_TYPE .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int UnRegisterMediaMetadataObserver(METADATA_TYPE type);
        /**
         * Enables/Disables the super resolution algorithm for a remote user's video stream.
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
        public abstract int SetParameters(string parameters);
        public abstract int SetLocalAccessPoint(LocalAccessPointConfiguration config);
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
         *  metadata: Media metadata See Metadata .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SendMetadata(Metadata metadata);
        /**
         * Pushes the external audio frame.
         * @param
         *  frame: The audio frame. 
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap);

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public abstract int PushAudioFrame(AudioFrame frame);
        /**
         * Pulls the remote audio data.
         * Before calling this method, you need to call SetExternalAudioSink to notify the app to enable and set the external rendering.
         *  After a successful method call, the app pulls the decoded and mixed audio data for playback. Call this method after joining a channel.
         *  Once you enable the external audio sink, the app will not retrieve any audio data from the OnPlaybackAudioFrame callback.
         *  The difference between this method and the OnPlaybackAudioFrame callback is as follows:The SDK sends the audio data to the app through the OnPlaybackAudioFrame callback. Any delay in processing the audio frames may result in audio jitter.
         *  After a successful method call, the app automatically pulls the audio data from the SDK. After setting the audio data parameters, the SDK adjusts the frame buffer and avoids problems caused by jitter in the external audio playback.
         * @param
         *  frame: The audio frame: AudioFrame .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int PullAudioFrame(AudioFrame frame);
        /**
         * Configures the external video source.
         * Ensure that you call this method before joining a channel.
         * @param
         *  enable: Whether to use the external video source:
         *  true: Use the external video source.
         *  false: (Default) Do not use the external video source. 
         *  useTexture: Whether to use texture as an input:
         *  true: Use texture as an input.
         *  false: (Default) Do not use texture as an input.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetExternalVideoSource(bool enable, bool useTexture = false);
        /**
         * Pushes the external raw video frame to the SDK.
         * If you call SetExternalVideoSource and set the enabled parameter as true and the encodedFrame parameter as false, you can call this method to push the external raw video frame to the SDK.
         *  Video data in Texture format is not supported in the communication scenario.
         * @param
         *  frame: The external raw video frame to be pushed. See ExternalVideoFrame for details.
         *  
         */
        public abstract int PushVideoFrame(ExternalVideoFrame frame);
        public abstract int PushAudioFrame(int sourcePos, AudioFrame frame);
        /**
         * Sets the channel mode of the current music file.
         * Call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
         * @param
         *  speed: The playback speed. Agora recommends that you limit this value to between 50 and 400, defined as follows:
         *  50: Half the original speed.
         *  100: The original speed.
         *  400: 4 times the original speed.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetAudioMixingPlaybackSpeed(int speed);
        /**
         * Specified the playback track of the current music file.
         * After getting the number of audio tracks of the current music file, call this method to specify any audio track to play. For example, if different tracks of a multitrack file store songs in different languages, you can call this method to set the language of the music file to play. This method is for Android, iOS, and Windows only.
         *  Call this method after calling StartAudioMixing [2/2] and receive the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING)
         *  callback.
         *  For the audio file formats supported by this method, see .
         * @param
         *  index: The specified playback track. The value range is [0, GetAudioTrackCount ()].
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SelectAudioTrack(int index);
        /**
         * Gets the audio track index of the current music file.
         * For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.
         *  Call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING)
         *  callback.
         * @return
         * ≥ 0: The audio track index of the current music file, if this method call
         *  succeeds.
         *  < 0: Failure.
         */
        public abstract int GetAudioTrackCount();
        /**
         * Sets the channel mode of the current music file.
         * In a stereo music file, the left and right channels can store different audio data. According to your needs, you can set the channel mode to original mode, left channel mode, right channel mode, or mixed channel mode. For example, in the KTV scenario, the left channel of the music file stores the musical accompaniment, and the right channel stores the singing voice. If you only need to listen to the accompaniment, call this method to set the channel mode of the music file to left channel mode; if you need to listen to the accompaniment and the singing voice at the same time, call this method to set the channel mode to mixed channel mode. Call this method after calling StartAudioMixing [2/2] and receive the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
         *  This method only applies to stereo audio files.
         * @param
         *  mode: The channel mode. See AUDIO_MIXING_DUAL_MONO_MODE .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode);
        /**
         * Pauses the media stream relay to all destination channels.
         * After the cross-channel media stream relay starts, you can call this method to pause relaying media streams to all destination channels; after the pause, if you want to resume the relay, call ResumeAllChannelMediaRelay .
         *  After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback to report whether the media stream relay is successfully paused.
         *  Call this method after StartChannelMediaRelay .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int PauseAllChannelMediaRelay();
        /**
         * Resumes the media stream relay to all destination channels.
         * After calling the PauseAllChannelMediaRelay method, you can call this method to resume relaying media streams to all destination channels.
         *  After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback to report whether the media stream relay is successfully resumed.
         *  Call this method after the PauseAllChannelMediaRelay method.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int ResumeAllChannelMediaRelay();
        /**
         * Gets the information of a specified audio file.
         * After calling this method successfully, the SDK triggers the OnRequestAudioFileInfo callback to report the information of an audio file, such as audio duration. You can call this method multiple times to get the information of multiple audio files. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.
         *  Call this method after joining a channel.
         * @param
         *  filePath: The file path: Windows: The absolute path or URL address (including the filename extensions) of the audio file.
         *  For example: C:\music\audio.mp4.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int GetAudioFileInfo(string filePath);
        /**
         * Enables the camera flash.
         * Call this method before calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
         * @param
         *  isOn: Whether to turn on the camera flash:
         *  true: Turn on the flash.
         *  false: (Default) Turn off the flash.
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int SetCameraTorchOn(bool isOn);
        /**
         * Checks whether the device supports camera flash.
         * This method needs to be called after the camera is started (for example, by calling StartPreview or JoinChannel [2/2] ). The app enables the front camera by default. If your front camera does not support flash, this method returns false.
         *  If you want to check whether the rear camera supports flash, call SwitchCamera before this method.
         * @return
         * true: The device supports camera flash.
         *  false: The device does not support camera flash.
         */
        public abstract int IsCameraTorchSupported();
        /**
         * Sets the volume of the external audio frame in the specified position.
         * You can call this method multiple times to set the volume of external audio frames in different positions. The volume setting takes effect for all external audio frames that are pushed to the specified position.
         *  Call this method after joining a channel
         * @param
         *  sourcePos: The push position of the external audio frame. 
         *  0: The position before local playback. If you need to play the external audio frame on the local client, set this position.
         *  1: The position after audio capture and before audio pre-processing. If you need the audio module of the SDK to process the external audio frame, set this position.
         *  2: The position after audio pre-processing and before audio encoding. If you do not need the audio module of the SDK to process the external audio frame, set this position.
         *  
         *  volume: The volume of the external audio frame. The value range is [0,100]. The default value is 100, which represents the original value.
         * @return
         * 0: Success.
         *  < 0: Failure. -2(ERR_INVALID_ARGUMENT): The parameter is invalid.
         */
        public abstract int SetExternalAudioSourceVolume(int sourcePos, int volume);
        /**
         * Takes a snapshot of a video stream.
         * This method takes a snapshot of a video stream from the specified user, generates a JPG image, and saves it to the specified path.
         *  The method is asynchronous, and the SDK has not taken the snapshot when the method call returns. After a successful method call, the SDK triggers OnSnapshotTaken callback to report whether the snapshot is successfully taken as well as the details for the snapshot taken. Call this method after joining a channel.
         *  If the video of the specified user is pre-processed, for example, added with watermarks or image enhancement effects, the generated snapshot also includes the pre-processing effects.
         * @param
         *  filePath: The local path (including the filename extensions) of the snapshot. For example, Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.jpg
         *  Ensure that the path you specify exists and is writable.
         *  
         *  channel: The channel name.
         *  uid: The user ID. Set uid as 0 if you want to take a snapshot of the local user's video.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int TakeSnapshot(string channel, uint uid, string filePath);
        public abstract int EnableContentInspect(bool enabled, ContentInspectConfig config);
        /**
         * Starts an audio and video call loop test.
         * Before joining a channel, to test whether the user's local sending and receiving streams are normal, you can call this method to perform an audio and video call loop test, which tests whether the audio and video devices and the user's upstream and downstream networks are working properly.
         *  After starting the test, the user needs to make a sound or face the camera. The audio or video is output after about two seconds. If the audio playback is normal, the audio device and the user's upstream and downstream networks are working properly; if the video playback is normal, the video device and the user's upstream and downstream networks are working properly. Call his method before joining a channel.
         *  After calling this method, call StopEchoTest to end the test; otherwise, the user cannot perform the next audio and video call loop test and cannot join the channel.
         *  In the LIVE_BROADCASTING profile, only a host can call this method.
         * @param
         *  config: The configuration of the audio and video call loop test. See EchoTestConfiguration .
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartEchoTest(EchoTestConfiguration config);

        public abstract int SetAVSyncSource(string channelId, uint uid);
        /**
         * Starts pushing media streams to a CDN without transcoding.
         * You can call this method to push a live audio-and-video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.
         *  After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming. Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in Push Streams to CDN.
         *  Call this method after joining a channel.
         *  Only hosts in the LIVE_BROADCASTING profile can call this method.
         *  If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
         * @param
         *  url: The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartRtmpStreamWithoutTranscoding(string url);
        /**
         * Starts Media Push and sets the transcoding configuration.
         * You can call this method to push a live audio-and-video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.
         *  After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming. Ensure that you enable the RTMP Converter service before using this function. See Prerequisites in Push Streams to CDN.
         *  Call this method after joining a channel.
         *  Only hosts in the LIVE_BROADCASTING profile can call this method.
         *  If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
         * @param
         *  url: The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.
         *  transcoding: The transcoding configuration for Media Push. See LiveTranscoding .
         *  
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);
        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);
        /**
         * Stops pushing media streams to a CDN.
         * You can call this method to stop the live stream on the specified CDN address. This method can stop pushing media streams to only one CDN address at a time, so if you need to stop pushing streams to multiple addresses, call this method multiple times.
         *  After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
         * @param
         *  url: The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.
         * @return
         * 0: Success.
         *  < 0: Failure.
         */
        public abstract int StopRtmpStream(string url);
        /**
         * Sets low-light enhancement.
         * The low-light enhancement feature can adaptively adjust the brightness value of the video captured in situations with low or uneven lighting, such as backlit, cloudy, or dark scenes. It restores or highlights the image details and improves the overall visual effect of the video.
         *  You can call this method to enable the color enhancement feature and set the options of the color enhancement effect.You can call this method to enable the low-light enhancement feature and set the options of the low-light enhancement effect. Call this method after calling EnableVideo .
         *  Dark light enhancement has certain requirements for equipment performance. The low-light enhancement feature has certain performance requirements on devices. If your device overheats after you enable low-light enhancement, Agora recommends modifying the low-light enhancement options to a less performance-consuming level or disabling low-light enhancement entirely.
         * @param
         *  enabled: Sets whether to enable low-light enhancement:
         *  true: Enable.
         *  false: (Default) Disable.
         *  
         *  options: The low-light enhancement options. 
         */
        public abstract int SetLowlightEnhanceOptions(bool enabled, LowLightEnhanceOptions options);
        /**
         * Sets video noise reduction.
         * Underlit environments and low-end video capture devices can cause video images to contain significant noise, which affects video quality. In real-time interactive scenarios, video noise also consumes bitstream resources and reduces encoding efficiency during encoding.
         *  You can call this method to enable the video noise reduction feature and set the options of the video noise reduction effect. Call this method after calling EnableVideo .
         *  Video noise reduction has certain requirements for equipment performance. If your device overheats after you enable video noise reduction, Agora recommends modifying the video noise reduction options to a less performance-consuming level or disabling video noise reduction entirely.
         * @param
         *  enabled: Sets whether to enable video noise reduction:
         *  true: Enable.
         *  false: (Default) Disable.
         *  
         *  options: The video noise reduction options. 
         */
        public abstract int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options);
        /**
         * Sets color enhancement.
         * The video images captured by the camera can have color distortion. The color enhancement feature intelligently adjusts video characteristics such as saturation and contrast to enhance the video color richness and color reproduction, making the video more vivid.
         *  You can call this method to enable the color enhancement feature and set the options of the color enhancement effect. Call this method after calling EnableVideo .
         *  The color enhancement feature has certain performance requirements on devices. With Color Enhancement turned on, Agora recommends that you change the Color Enhancement Level to one that consumes less performance or turn off Color Enhancement if your device is experiencing severe heat problems.
         * @param
         *  enabled: Whether to turn on color enhancement:
         *  true: Enable.
         *  false: (Default) Disable.
         *  
         *  options: The color enhancement options. 
         */
        public abstract int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options);
        public abstract int EnableWirelessAccelerate(bool enabled);
        /**
         * Starts recording the local audio and video.
         * After successfully getting the object, you can all this method to enable the recoridng of the local audio and video.
         *  This method can record the following content: The audio captured by the local microphone and encoded in AAC format.
         *  The video captured by the local camera and encoded by the SDK. The SDK can generate a recording file only when it detects the recordable audio and video streams; when there are no audio 
         *  and video streams to be recorded or the audio and video streams are interrupted for more than five seconds, the SDK stops 
         *  recording and triggers the OnRecorderStateChanged (RECORDER_STATE_ERROR, RECORDER_ERROR_NO_STREAM) callback.
         *  Call this method after joining the channel.
         * @param
         *  config: The recording configuration. See MediaRecorderConfiguration .
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure. -2(ERR_INVALID_ARGUMANT): The parameter is invalid. Ensure the following: The specified path of the recording file exists and is writable.
         *  The specified format of the recording file is supported.
         *  The maximum recording duration is correctly set. -4(ERR_NOT_SUPPORTED): IAgoraRtcEngine does not support the request due to one of the following reasons: The recording is ongoing.
         *  The recording stops because an error occurs. -7(ERR_NOT_INITIALIZED): This method is called before the initialization of IAgoraRtcEngine .
         */
        public abstract int StartRecording(MediaRecorderConfiguration config);
        /**
         * Stops recording the local audio and video
         * After calling StartRecording , if you want to stop the recording, you must call this method;
         *  otherwise, the generated recording files may not be playable.
         * @return
         * 0(ERR_OK): Success.
         *  < 0: Failure: -7(ERR_NOT_INITIALIZED): This method is called before the initialization of IAgoraRtcEngine .
         */
        public abstract int StopRecording();
    }

    /**
     *  The SDK uses the IAgoraRtcEngineEventHandler interface to send event notifications to your app. Your app can get those notifications through methods that inherit this interface.
     */
    public abstract class IAgoraRtcEngineEventHandler
    {
        /**
         * Reports a warning during SDK runtime.
         * Occurs when a warning occurs during SDK runtime. In most cases, the app can ignore the warnings reported by the SDK because the SDK can usually fix the issue and resume running. For example, when losing connection with the server, the SDK may report WARN_LOOKUP_CHANNEL_TIMEOUT and automatically try to reconnect.
         * @param
         *  warn: Warning codes. 
         *  msg: Warning description.
         */
        public virtual void OnWarning(int warn, string msg)
        {
        }

        /**
         * Reports an error during SDK runtime.
         * This callback indicates that an error (concerning network or media) occurs during SDK runtime. In most cases, the SDK cannot fix the issue and resume running. The SDK requires the application to take action or informs the user about the issue. For example, the SDK reports an ERR_START_CALL error when failing to initialize a call. The app informs the user that the call initialization failed and calls LeaveChannel to leave the channel.
         * @param
         *  err: The error code. 
         *  msg: The error message.
         */
        public virtual void OnError(int err, string msg)
        {
        }

        /**
         * Occurs when a user joins a channel.
         * This callback notifies the application that a user joins a specified channel.
         * @param
         *  channel: The name of the channel.
         *  uid: The ID of the user who joins the channel.
         *  elapsed: The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.
         */
        public virtual void OnJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
        }

        /**
         * Occurs when a user rejoins the channel.
         * When a user loses connection with the server because of network problems, the SDK automatically tries to reconnect and triggers this callback upon reconnection.
         * @param
         *  channel: The name of the channel.
         *  uid: The ID of the user who rejoins the channel.
         *  elapsed: Time elapsed (ms) from starting to reconnect until the SDK triggers this
         *  callback.
         */
        public virtual void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
        }

        /**
         * Occurs when a user leaves a channel.
         * This callback notifies the app that the user leaves the channel by calling LeaveChannel . From this callback, the app can get information such as the call duration and quality statistics.
         * @param
         *  stats: The statistics of the call, see RtcStats .
         */
        public virtual void OnLeaveChannel(RtcStats stats)
        {
        }

        /**
         * Occurs when the user role switches in the interactive live streaming.
         * The SDK triggers this callback when the local user switches the user role after joining the channel.
         * @param
         *  oldRole: Role that the user switches from: 
         *  CLIENT_ROLE_BROADCASTER(1): Broadcaster.
         *  CLIENT_ROLE_AUDIENCE(2): Audience. 
         *  CLIENT_ROLE_TYPE .
         *  newRole: Role that the user switches to: 
         *  CLIENT_ROLE_BROADCASTER(1): Broadcaster.
         *  CLIENT_ROLE_AUDIENCE(2): Audience. 
         *  CLIENT_ROLE_TYPE .
         */
        public virtual void OnClientRoleChanged(CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
        }

        /**
         * Occurs when a remote user (COMMUNICATION)/ host (LIVE_BROADCASTING) joins the channel.
         * In a communication channel, this callback indicates that a remote user joins the channel. The SDK also triggers this callback to report the existing users in the channel when a user joins the channel.
         *  In a live-broadcast channel, this callback indicates that a host joins the channel. The SDK also triggers this callback to report the existing hosts in the channel when a host joins the channel. Agora recommends limiting the number of hosts to 17. The SDK triggers this callback under one of the following circumstances:
         *  A remote user/host joins the channel by calling the JoinChannel [2/2] method.
         *  A remote user switches the user role to the host after joining the channel.
         *  A remote user/host rejoins the channel after a network interruption.
         * @param
         *  uid: The ID of the user or host who joins the channel.
         *  elapsed: Time delay (ms) from the local user calling JoinChannel [2/2]
         *  until this callback is triggered.
         */
        public virtual void OnUserJoined(uint uid, int elapsed)
        {
        }

        /**
         * Occurs when a remote user (COMMUNICATION)/ host (LIVE_BROADCASTING) leaves the channel.
         * There are two reasons for users to become offline:
         *  Leave the channel: When a user/host leaves the channel, the user/host sends a goodbye message. When this message is received, the SDK determines that the user/host leaves the channel.
         *  Drop offline: When no data packet of the user or host is received for a certain period of time (20 seconds for the communication profile, and more for the live broadcast profile), the SDK assumes that the user/host drops offline. A poor network connection may lead to false detections. It's recommended to use the Agora RTM SDK for reliable offline detection.
         * @param
         *  uid: The ID of the user who leaves the channel or goes offline.
         *  reason: Reasons why the user goes offline: USER_OFFLINE_REASON_TYPE . 
         */
        public virtual void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        /**
         * Reports the last-mile network quality of the local user once every two seconds.
         * This callback reports the last-mile network conditions of the local user before the user joins the channel. Last mile refers to the connection between the local device and Agora's edge server.
         *  Before the user joins the channel, this callback is triggered by the SDK once StartLastmileProbeTest is called and reports the last-mile network conditions of the local user.
         * @param
         *  quality: The last mile network quality.
         *  QUALITY_UNKNOWN (0): The quality is unknown.
         *  QUALITY_EXCELLENT (1): The quality is excellent.
         *  QUALITY_GOOD (2): The network quality seems excellent, but the bitrate can be slightly lower than excellent.
         *  QUALITY_POOR (3): Users can feel the communication is slightly impaired.
         *  QUALITY_BAD (4): Users cannot communicate smoothly.
         *  QUALITY_VBAD (5): The quality is so bad that users can barely communicate.
         *  QUALITY_DOWN (6): The network is down, and users cannot communicate at all.
         *  
         */
        public virtual void OnLastmileQuality(int quality)
        {
        }

        /**
         * Reports the last mile network probe result.
         * The SDK triggers this callback within 30 seconds after the app calls StartLastmileProbeTest .
         * @param
         *  result: The uplink and downlink last-mile network probe test result. 
         */
        public virtual void OnLastmileProbeResult(LastmileProbeResult result)
        {
        }

        /**
         * Occurs when the connection between the SDK and the server is interrupted.
         * Deprecated:
         *  Please use OnConnectionStateChanged instead. The SDK triggers this callback when it loses connection with the server for more than four seconds after the connection is established. After triggering this callback, the SDK tries to reconnect to the server. You can use this callback to implement pop-up reminders. The difference between this callback and OnConnectionLost is:
         *  The SDK triggers the OnConnectionInterrupted callback when it loses connection with the server for more than four seconds after it successfully joins the channel.
         *  The SDK triggers the OnConnectionLost callback when it loses connection with the server for more than 10 seconds, whether or not it joins the channel.
         *  If the SDK fails to rejoin the channel 20 minutes after being disconnected from Agora's edge server, the SDK stops rejoining the channel.
         */
        [Obsolete(
            "Deprecated since v2.3.2. Replaced by the onConnectionStateChanged(CONNECTION_STATE_RECONNECTING, CONNECTION_CHANGED_INTERRUPTED) callback",
            false)]
        public virtual void OnConnectionInterrupted()
        {
        }

        /**
         * Occurs when the SDK cannot reconnect to Agora's edge server 10 seconds after its connection to the server is interrupted.
         * The SDK triggers this callback when it cannot connect to the server 10 seconds after
         *  calling the JoinChannel [2/2] method, regardless of whether it is in
         *  the channel. If the SDK fails to rejoin the channel 20 minutes after being
         *  disconnected from Agora's edge server, the SDK stops rejoining the channel.
         */
        public virtual void OnConnectionLost()
        {
        }

        /**
         * Occurs when the connection is banned by the Agora server.
         * Deprecated:
         *  Please use OnConnectionStateChanged instead.
         */
        [Obsolete(
            "Deprecated since v2.3.2. Replaced by the onConnectionStateChanged(CONNECTION_STATE_FAILED, CONNECTION_CHANGED_BANNED_BY_SERVER) callback",
            false)]
        public virtual void OnConnectionBanned()
        {
        }

        /**
         * Occurs when a method is executed by the SDK.
         * @param
         *  result: The result of the method call.
         *  err: The error code returned by the SDK when the method call fails. For detailed error information and troubleshooting methods, see Error Code and Warning Code.If the SDK returns 0, then the method call is successful.
         *  api: The method executed by the SDK.
         */
        public virtual void OnApiCallExecuted(int err, string api, string result)
        {
        }

        /**
         * Occurs when the token expires.
         * When the token expires during a call, the SDK triggers this callback to
         *  remind the app to renew the token.
         *  Once you receive this callback, generate a new token on your app server, and call 
         *  JoinChannel [2/2] to rejoin the channel.
         */
        public virtual void OnRequestToken()
        {
        }

        /**
         * Occurs when the token expires in 30 seconds.
         * When the token is about to expire in 30 seconds, the SDK triggers this callback to remind the app to renew the token.
         *  Upon receiving this callback, generate a new token on your server, and call RenewToken to pass the new token to the SDK.
         * @param
         *  token: The token that expires in 30 seconds.
         */
        public virtual void OnTokenPrivilegeWillExpire(string token)
        {
        }

        /**
         * Reports the statistics of the audio stream from each remote user.
         * Deprecated: 
         *  OnRemoteAudioStats instead. 
         *  The SDK triggers this callback once every two seconds to report the audio quality of each remote user/host sending an audio stream. If a channel has multiple users/hosts sending audio streams, the SDK triggers this callback as many times.
         * @param
         *  uid: The user ID of the remote user sending the audio stream.
         *  quality: Audio quality of the user. 
         *  QUALITY_UNKNOWN (0): The quality is unknown.
         *  QUALITY_EXCELLENT (1): The quality is excellent.
         *  QUALITY_GOOD (2): The network quality seems excellent, but the bitrate can be slightly lower than excellent.
         *  QUALITY_POOR (3): Users can feel the communication is slightly impaired.
         *  QUALITY_BAD (4): Users cannot communicate smoothly.
         *  QUALITY_VBAD (5): The quality is so bad that users can barely communicate.
         *  QUALITY_DOWN (6): The network is down, and users cannot communicate at all.
         *  For details,
         *  see QUALITY_TYPE .
         *  delay: The network delay (ms) from the sender to the receiver, including the delay
         *  caused by audio sampling pre-processing, network transmission, and network
         *  jitter buffering.
         *  lost: Packet loss rate (%) of the audio packet sent from the sender to the
         *  receiver.
         */
        [Obsolete("Deprecated since v2.3.2. Use the onRemoteAudioStats callback instead",
            false)]
        public virtual void OnAudioQuality(uint uid, int quality, ushort delay, ushort lost)
        {
        }

        /**
         * Reports the statistics of the current call.
         * The SDK triggers this callback once every two seconds after the user joins the channel.
         * @param
         *  stats: Statistics of the RTC engine, see RtcStats for
         *  details.
         *  
         */
        public virtual void OnRtcStats(RtcStats stats)
        {
        }

        /**
         * Reports the last mile network quality of each user in the channel.
         * This callback reports the last mile network conditions of each user in the channel. Last mile refers to the connection between the local device and Agora's edge server.
         *  The SDK triggers this callback once every two seconds. If a channel includes multiple users, the SDK triggers this callback as many times.
         * @param
         *  uid: User ID. The network quality of the user with this user ID is
         *  reported.
         *  If the uid is 0, the local network quality is reported.
         *  
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
         */
        public virtual void OnNetworkQuality(uint uid, int txQuality, int rxQuality)
        {
        }

        /**
         * Reports the statistics of the local video stream.
         * The SDK triggers this callback once every two seconds to report the statistics of the local video stream.
         * @param
         *  stats: The statistics of the local video stream. 
         */
        public virtual void OnLocalVideoStats(LocalVideoStats stats)
        {
        }

        /**
         * Reports the transport-layer statistics of each remote video stream.
         * Reports the statistics of the video stream from the remote users. The SDK triggers this callback once every two seconds for each remote user. If a channel has multiple users/hosts sending video streams, the SDK triggers this callback as many times.
         * @param
         *  stats: Statistics of the remote video stream. 
         */
        public virtual void OnRemoteVideoStats(RemoteVideoStats stats)
        {
        }

        /**
         * Reports the statistics of the local audio stream.
         * The SDK triggers this callback once every two seconds.
         * @param
         *  stats: Local audio statistics. 
         */
        public virtual void OnLocalAudioStats(LocalAudioStats stats)
        {
        }

        /**
         * Reports the transport-layer statistics of each remote audio stream.
         * The SDK triggers this callback once every two seconds for each remote user who is sending audio streams. If a channel includes multiple remote users, the SDK triggers this callback as many times.
         * @param
         *  stats: The statistics of the received remote audio streams. See RemoteAudioStats .
         */
        public virtual void OnRemoteAudioStats(RemoteAudioStats stats)
        {
        }

        /**
         * Occurs when the local audio stream state changes.
         * When the state of the local audio stream changes (including the state of the audio capture and encoding), the SDK triggers this callback to report the current state. This callback indicates the state of the local audio stream, and allows you to troubleshoot issues when audio exceptions occur.
         *  When the state isLOCAL_AUDIO_STREAM_STATE_FAILED (3), you can view the error information in the error parameter.
         * @param
         *  state: The state of the local audio. For details, see LOCAL_AUDIO_STREAM_STATE .
         *  error: Local audio state error codes. For details, see LOCAL_AUDIO_STREAM_ERROR .
         */
        public virtual void OnLocalAudioStateChanged(LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
        }

        /**
         * Occurs when the remote audio state changes.
         * When the audio state of a remote user (in the voice/video call channel) or host (in the live streaming channel) changes, the SDK triggers this callback to report the current state of the remote audio stream.
         *  This callback does not work properly when the number of users (in the voice/video call channel) or hosts (in the live streaming channel) in the channel exceeds 17.
         * @param
         *  uid: The ID of the remote user whose audio state changes.
         *  state: The state of the remote audio, see REMOTE_AUDIO_STATE .
         *  reason: The reason of the remote audio state change, see REMOTE_AUDIO_STATE_REASON .
         *  elapsed: Time elapsed (ms) from the local user calling the JoinChannel [2/2] method until the SDK triggers this callback.
         */
        public virtual void OnRemoteAudioStateChanged(uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        /**
         * Occurs when the audio publishing state changes.
         * @param
         *  channel: The name of the channel.
         *  oldState: For the previous publishing state, see STREAM_PUBLISH_STATE .
         *  elapseSinceLastState: The time elapsed (ms) from the previous state to the current state.
         *  newState: For the current publishing state, see STREAM_PUBLISH_STATE.
         */
        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        /**
         * Occurs when the video publishing state changes.
         * @param
         *  channel: The name of the channel.
         *  oldState: For the previous publishing state, see STREAM_PUBLISH_STATE .
         *  elapseSinceLastState: The time elapsed (ms) from the previous state to the current state.
         *  newState: For the current publishing state, see STREAM_PUBLISH_STATE.
         */
        public virtual void OnVideoPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        /**
         * Occurs when the audio subscribing state changes.
         * @param
         *  channel: The name of the channel.
         *  uid: The ID of the remote user.
         *  oldState: The previous subscribing status, see STREAM_SUBSCRIBE_STATE 
         *  for details.
         *  elapseSinceLastState: The time elapsed (ms) from the previous state to the current state.
         *  newState: The current subscribing status, see STREAM_SUBSCRIBE_STATE for details.
         */
        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        /**
         * Occurs when the video subscribing state changes.
         * @param
         *  channel: The name of the channel.
         *  uid: The ID of the remote user.
         *  oldState: The previous subscribing status, see STREAM_SUBSCRIBE_STATE 
         *  for details.
         *  elapseSinceLastState: The time elapsed (ms) from the previous state to the current state.
         *  newState: The current subscribing status, see STREAM_SUBSCRIBE_STATE for details.
         */
        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        /**
         * Reports the volume information of users.
         * By default, this callback is disabled. You can enable it by calling EnableAudioVolumeIndication . Once this callback is enabled and users send streams in the channel, the SDK triggers the EnableAudioVolumeIndication callback at the time interval set in OnAudioVolumeIndication. The SDK triggers two independent OnAudioVolumeIndication callbacks simultaneously, which separately report the volume information of the local user who sends a stream and the remote users (up to three) whose instantaneous volumes are the highest.
         *  After you enable this callback, calling MuteLocalAudioStream affects the SDK's behavior as follows:
         *  If the local user stops publishing the audio stream, the SDK stops triggering the local user's callback.
         *  20 seconds after a remote user whose volume is one of the three highest stops publishing the audio stream, the callback excludes this user's information; 20 seconds after all remote users stop publishing audio streams, the SDK stops triggering the callback for remote users.
         * @param
         *  speakers: The volume information of the users, see AudioVolumeInfo . An empty speakers array in the callback indicates that no remote user is in the channel or sending a stream at the moment.
         *  totalVolume: The volume of the speaker. The value range is [0,255].
         *  In the callback for the local user, totalVolume is the volume of the local user who sends a stream.
         *  In the callback for remote users, totalVolume is the sum of the volume of all remote users (up to three) whose instantaneous volumes are the highest. If the user calls StartAudioMixing [2/2] , then totalVolume is the volume after audio mixing. 
         *  speakerNumber: The total number of users.
         *  In the callback for the local user, if the local user is sending streams, the value of speakerNumber is 1.
         *  In the callback for remote users, the value range of speakerNumber is [0,3]. If the number of remote users who send streams is greater than or equal to three, the value of speakerNumber is 3. 
         */
        public virtual void OnAudioVolumeIndication(AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
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
         */
        public virtual void OnActiveSpeaker(uint uid)
        {
        }

        /**
         * Occurs when the video stops playing.
         * Deprecated:
         *  Please use LOCAL_VIDEO_STREAM_STATE_STOPPED(0) in the OnLocalVideoStateChanged callback instead. The application can use this callback to change the configuration of the
         *  view (for example, displaying other pictures in the view) after
         *  the video stops playing.
         */
        [Obsolete("Deprecated since v2.4.1. Use LOCAL_VIDEO_STREAM_STATE_STOPPED(0) in the onLocalVideoStateChanged callback instead",
            false)]
        public virtual void OnVideoStopped()
        {
        }

        /**
         * Occurs when the first local video frame is rendered.
         * The SDK triggers this callback when the first local video frame is displayed/rendered on the local video view.
         * @param
         *  width: The width (px) of the first local video frame.
         *  height: The height (px) of the first local video frame.
         *  elapsed: The time elapsed (ms) from the local user calling JoinChannel [2/2]until the SDK triggers this callback. If you
         *  call StartPreview before calling JoinChannel [2/2], then this parameter is the time elapsed from
         *  calling the StartPreview method until the SDK
         *  triggers this callback.
         */
        public virtual void OnFirstLocalVideoFrame(int width, int height, int elapsed)
        {
        }

        /**
         * Occurs when the first video frame is published.
         * The SDK triggers this callback under one of the following circumstances:
         *  The local client enables the video module and calls JoinChannel [2/2] successfully.
         *  The local client calls MuteLocalVideoStream (true) and MuteLocalVideoStream(false) in sequence.
         *  The local client calls DisableVideo and EnableVideo in sequence.
         * @param
         *  elapsed: The time elapsed(ms) from the local client calling JoinChannel [2/2] until the SDK triggers this callback.
         */
        public virtual void OnFirstLocalVideoFramePublished(int elapsed)
        {
        }

        /**
         * Occurs when the first remote video frame is received and decoded.
         * Deprecated:
         *  Please use the OnRemoteVideoStateChanged callback with the following parameters:
         *  REMOTE_VIDEO_STATE_STARTING (1).
         *  REMOTE_VIDEO_STATE_DECODING (2). The SDK triggers this callback under one of the following circumstances:
         *  The remote user joins the channel and sends the video stream.
         *  The remote user stops sending the video stream and re-sends it after 15 seconds. Reasons for such an interruption include:
         *  The remote user leaves the channel.
         *  The remote user drops offline.
         *  The remote user calls MuteLocalVideoStream to stop sending the video stream.
         *  The remote user calls DisableVideo to disable video.
         * @param
         *  uid: The user ID of the remote user sending the video stream.
         *  width: The width (px) of the video stream.
         *  height: The height (px) of the video stream.
         *  elapsed: The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.
         */
        public virtual void OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed)
        {
        }

        /**
         *  Occurs when the first remote video frame is rendered.
         * The SDK triggers this callback when the first local video frame is displayed/rendered on the local video view. The application can retrieve the time elapsed (the elapsed parameter) from a user joining the channel until the first video frame is displayed.
         * @param
         *  uid: The user ID of the remote user sending the video stream.
         *  width: The width (px) of the video stream.
         *  height: The height (px) of the video stream.
         *  elapsed: Time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.
         */
        public virtual void OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed)
        {
        }

        /**
         * Occurs when a remote user (in the communication profile)/ host (in the live streaming profile) joins the channel.
         * The SDK triggers this callback when the remote user stops or resumes sending the audio stream by calling the MuteLocalAudioStream method.
         *  This callback does not work properly when the number of users (in the communication profile) or hosts (in the live streaming profile) in the channel exceeds 17.
         * @param
         *  uid: User ID.
         *  muted: Whether the remote user's audio stream is muted/unmuted:
         *  true: Muted.
         *  false: Unmuted. 
         */
        public virtual void OnUserMuteAudio(uint uid, bool muted)
        {
        }

        /**
         * Occurs when a remote user's video stream playback pauses/resumes.
         * The SDK triggers this callback when the remote user stops or resumes sending the video stream by calling the MuteLocalVideoStream method.
         *  This callback does not work properly when the number of users (in the COMMUNICATION profile) or hosts (in the LIVE_BROADCASTING profile) in the channel exceeds 17.
         * @param
         *  uid: The ID of the remote user.
         *  muted: Whether the remote user's video stream playback is paused/resumed:
         *  true: Paused.
         *  false: Resumed.
         *  
         */
        public virtual void OnUserMuteVideo(uint uid, bool muted)
        {
        }

        /**
         * Occurs when a remote user enables/disables the video module.
         * Once the video module is disabled, the user can only use a voice call. The user cannot send or receive any video.
         *  The SDK triggers this callback when a remote user enables or disables the video module by calling the EnableVideo or DisableVideo method.
         * @param
         *  uid: The user ID of the remote user.
         *  enabled: true: Enable.
         *  false: Disable. 
         */
        public virtual void OnUserEnableVideo(uint uid, bool enabled)
        {
        }

        /**
         * Occurs when the audio device state changes.
         * This callback notifies the application that the system's audio device state is changed. For example, a headset is unplugged from the device.
         *  This method is for Windows and macOS only.
         * @param
         *  deviceId: The device ID.
         *  deviceType: The device type. For details, see MEDIA_DEVICE_TYPE .
         *  deviceState: The device state.
         *  on macOS: 
         *  0: The device is ready for use.
         *  8: The device is not connected. On Windows: MEDIA_DEVICE_STATE_TYPE .
         *  
         */
        public virtual void OnAudioDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
        }

        /**
         * Occurs when the volume on the playback or audio capture device, or the volume in the application changes.
         * @param
         *  deviceType: The device type. For details, see MEDIA_DEVICE_TYPE .
         *  volume: The volume value. The range is [0, 255].
         *  muted: Whether the audio device is muted:
         *  true: The audio device is muted.
         *  false: The audio device is not muted.
         *  
         */
        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
        }

        /**
         * Occurs when the camera turns on and is ready to capture the video.
         * Deprecated: Please use LOCAL_VIDEO_STREAM_STATE_CAPTURING(1) in OnLocalVideoStateChanged instead. 
         *  This callback indicates that the camera has been successfully turned on and
         *  you can start to capture video.
         */
        [Obsolete("Deprecated since v2.4.1. Use LOCAL_VIDEO_STREAM_STATE_CAPTURING (1) in the onLocalVideoStateChanged callback instead",
            false)]
        public virtual void OnCameraReady()
        {
        }

        /**
         * Occurs when the camera focus area changes.
         * @param
         *  width: The width of the changed camera focus area.
         *  x: The x coordinate of the changed camera focus area.
         *  y: The y coordinate of the changed camera focus area.
         *  height: The height of the changed camera focus area.
         */
        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
        }

        /**
         * Reports the face detection result of the local user.
         * Once you enable face detection by calling EnableFaceDetection (true), you can get the following information on the local user in real-time:
         *  The width and height of the local video.
         *  The position of the human face in the local video.
         *  The distance between the human face and the screen. The distance between the human face and the screen is based on the fitting calculation of the local video size and the position of the human face captured by the camera. This callback is for Android and iOS only.
         *  When it is detected that the face in front of the camera disappears, the callback will be triggered immediately. In the state of no face, the trigger frequency of the callback will be reduced to save power consumption on the local device.
         *  The SDK stops triggering this callback when a human face is in close proximity to the screen.
         * @param
         *  vecRectangle: The information of the detected human face:
         *  x: The x-coordinate (px) of the human face in the local video. The horizontal position relative to the origin, where the upper left corner of the captured video is the origin, and the x-coordinate is the upper left corner of the watermark.
         *  y: The y-coordinate (px) of the human face in the local video. Taking the top left corner of the captured video as the origin, the y coordinate represents the relative longitudinal displacement of the top left corner of the human face to the origin.
         *  width: The width (px) of the human face in the local view.
         *  height: The height (px) of the human face in the local view. 
         *  vecDistance: The distance between the human face and the device screen (cm).
         *  numFaces: The number of faces detected. If the value is 0, it means that no human face is detected.
         */
        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle vecRectangle,
            int[] vecDistance, int numFaces)
        {
        }

        /**
         * Occurs when the camera exposure area changes.
         * @param
         *  width: The width of the changed camera exposure area.
         *  x: The x coordinate of the changed camera exposure area.
         *  y: The y coordinate of the changed camera exposure area.
         *  height: The height of the changed exposure area.
         */
        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
        }

        /**
         * Occurs when the playback of the local music file finishes.
         * Deprecated:
         *  This method is deprecated as of v2.4.0. Use OnAudioMixingStateChanged instead. After you call StartAudioMixing [2/2] to play a local music
         *  file, this callback occurs when the playback finishes. If the call of StartAudioMixing [2/2] fails, the callback returns the error code
         *  WARN_AUDIO_MIXING_OPEN_ERROR.
         */
        [Obsolete("This method is deprecated, use onAudioMixingStateChanged instead",
            false)]
        public virtual void OnAudioMixingFinished()
        {
        }

        /**
         * Occurs when the playback state of the music file changes.
         * This callback occurs when the playback state of the music file changes, and reports the current state and error code.
         * @param
         *  state: The playback state of the music file. For details, see AUDIO_MIXING_STATE_TYPE .
         *  reason: The reason why the playback state of the music file changes. For details, see 
         *  AUDIO_MIXING_REASON_TYPE .
         */
        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
        }

        /**
         * Occurs when a remote user starts audio mixing.
         * When a remote user calls StartAudioMixing [2/2] to play the background music, the SDK reports this callback.
         */
        public virtual void OnRemoteAudioMixingBegin()
        {
        }

        /**
         * Occurs when a remote user finishes audio mixing.
         * The SDK triggers this callback when a remote user finishes audio mixing.
         */
        public virtual void OnRemoteAudioMixingEnd()
        {
        }

        /**
         * Occurs when the playback of the local audio effect file finishes.
         * This callback occurs when the local audio effect file finishes playing.
         * @param
         *  soundId: The audio effect ID. The ID of each audio effect file is unique.
         */
        public virtual void OnAudioEffectFinished(int soundId)
        {
        }

        /**
         * Occurs when the SDK decodes the first remote audio frame for playback.
         * Deprecated:
         *  Please use OnRemoteAudioStateChanged instead. The SDK triggers this callback under one of the following circumstances: 
         *  The remote user joins the channel and sends the audio stream for the first time.
         *  The remote user's audio is offline and then goes online to re-send audio. It means the local user cannot receive audio in 15 seconds. Reasons for such an interruption include:
         *  The remote user leaves channel.
         *  The remote user drops offline.
         *  The remote user calls MuteLocalAudioStream to stop sending the audio stream.
         *  The remote user calls DisableAudio to disable audio.
         * @param
         *  uid: The ID of the remote user.
         *  elapsed: The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.
         */
        [Obsolete(
            "Deprecated since v3.0.0. Use onRemoteAudioStateChanged instead",
            false)]
        public virtual void OnFirstRemoteAudioDecoded(uint uid, int elapsed)
        {
        }

        /**
         * Occurs when the video device state changes.
         * This callback reports the change of system video devices, such as being unplugged or removed. On a Windows device with an external camera for video capturing, the video disables once the external camera is unplugged.
         * @param
         *  deviceId: The device ID.
         *  deviceType: Media device types. For details, see MEDIA_DEVICE_TYPE .
         *  deviceState: Media device states. For details, see MEDIA_DEVICE_STATE_TYPE .
         */
        public virtual void OnVideoDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
        }

        /**
         * Occurs when the local video stream state changes.
         * When the state of the local video stream changes (including the state of the video capture and encoding), the SDK triggers this callback to report the current state. This callback indicates the state of the local video stream, including camera capturing and video encoding, and allows you to troubleshoot issues when exceptions occur.
         *  The SDK triggers the OnLocalVideoStateChanged callback with the state code of LOCAL_VIDEO_STREAM_STATE_FAILED and error code of LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE in the following situations:
         *  The app switches to the background, and the system gets the camera resource.
         *  The camera starts normally, but does not output video for four consecutive seconds. When the camera outputs the captured video frames, if the video frames are the same for 15 consecutive frames, the SDK triggers the OnLocalVideoStateChanged callback with the state code of LOCAL_VIDEO_STREAM_STATE_CAPTURING and error code of LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE. Note that the video frame duplication detection is only available for video frames with a resolution greater than 200 × 200, a frame rate greater than or equal to 10 fps, and a bitrate less than 20 Kbps.
         *  For some device models, the SDK does not trigger this callback when the state of the local video changes while the local video capturing device is in use, so you have to make your own timeout judgment.
         * @param
         *  localVideoState: The state of the local video, see LOCAL_VIDEO_STREAM_STATE .
         *  
         *  error: The detailed error information, see LOCAL_VIDEO_STREAM_ERROR .
         *  
         */
        public virtual void OnLocalVideoStateChanged(LOCAL_VIDEO_STREAM_STATE localVideoState,
            LOCAL_VIDEO_STREAM_ERROR error)
        {
        }

        /**
         * Occurs when the video size or rotation of a specified user changes.
         * @param
         *  uid: The ID of the user whose video size or rotation changes.
         *  uid is 0 for the local user.
         *  rotation: The rotation information. The value range is [0,360).
         *  width: The width (pixels) of the video stream.
         *  height: The height (pixels) of the video stream.
         */
        public virtual void OnVideoSizeChanged(uint uid, int width, int height, int rotation)
        {
        }

        /**
         * Occurs when the remote video state changes.
         * This callback does not work properly when the number of users (in the voice/video call channel) or hosts (in the live streaming channel) in the channel exceeds 17.
         * @param
         *  uid: The ID of the remote user whose video state changes.
         *  state:  The state of the remote video, see 
         *  REMOTE_VIDEO_STATE . 
         *  reason:  The reason for the remote video state
         *  change, see REMOTE_VIDEO_STATE_REASON . 
         *  elapsed: Time elapsed (ms) from the local user calling the JoinChannel [2/2] method until the SDK triggers this
         *  callback.
         */
        public virtual void OnRemoteVideoStateChanged(uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        /**
         * Occurs when a specific remote user enables/disables the local video capturing function.
         * The SDK triggers this callback when the remote user resumes or stops capturing the video stream by calling the EnableLocalVideo method.
         * @param
         *  uid: The user ID of the remote user.
         *  enabled: Whether the specified remote user enables/disables the local video
         *  capturing function:
         *  true: Enable. Other users in the
         *  channel can see the video of this remote user.
         *  false: Disable. Other users in the
         *  channel can no longer receive the video stream from this remote
         *  user, while this remote user can still receive the video streams
         *  from other users. 
         */
        public virtual void OnUserEnableLocalVideo(uint uid, bool enabled)
        {
        }

        /**
         * Occurs when the local user receives the data stream from the remote user.
         * The SDK triggers this callback when the local user receives the stream message that the remote user sends by calling the SendStreamMessage method.
         * @param
         *  length: The data length (byte).
         *  data: The data received.
         *  uid: The ID of the remote user sending the message.
         *  streamId: The stream ID of the received message.
         */
        public virtual void OnStreamMessage(uint uid, int streamId, byte[] data, uint length)
        {
        }

        /**
         * Occurs when the local user does not receive the data stream from the remote user.
         * The SDK triggers this callback when the local user fails to receive the stream message that the remote user sends by calling the SendStreamMessage method.
         * @param
         *  uid: The ID of the remote user sending the message.
         *  missed: The number of lost messages.
         *  streamId: The stream ID of the received message.
         *  code: The error code.
         *  cached: Number of incoming cached messages when the data stream is interrupted.
         */
        public virtual void OnStreamMessageError(uint uid, int streamId, int code, int missed, int cached)
        {
        }

        /**
         * Occurs when the media engine loads.
         */
        public virtual void OnMediaEngineLoadSuccess()
        {
        }

        /**
         * Occurs when the media engine call starts.
         */
        public virtual void OnMediaEngineStartCallSuccess()
        {
        }

        /**
         * Reports whether virtual background is successfully enabled. (beta feature)
         * Since
         *  v3.5.0 After you call EnableVirtualBackground , the SDK triggers this callback to report whether virtual background is successfully enabled.
         *  If the background image customized in the virtual background is in the PNG or JPG format, this callback is triggered after the image is read.
         * @param
         *  enabled: Whether virtual background is successfully enabled:
         *  true: Virtual background is successfully enabled.
         *  false: Virtual background is not successfully enabled.
         *  
         *  reason: The reason why virtual background is not successfully enabled. See VIRTUAL_BACKGROUND_SOURCE_STATE_REASON .
         */
        public virtual void OnVirtualBackgroundSourceEnabled(bool enabled,
            VIRTUAL_BACKGROUND_SOURCE_STATE_REASON reason)
        {
        }

        /**
         * Reports whether the super resolution feature is successfully enabled.
         * After calling EnableRemoteSuperResolution , the SDK triggers the callback to report whether super resolution is successfully enabled. If it is not successfully enabled, use reason for troubleshooting.
         * @param
         *  uid: The ID of the remote user.
         *  enabled: Whether super resolution is successfully enabled:
         *  true: Super resolution is successfully enabled.
         *  false: Super resolution is not successfully enabled.
         *  
         *  reason: The reason why super resolution algorithm is not successfully enabled. For details, see SUPER_RESOLUTION_STATE_REASON .
         */
        public virtual void OnUserSuperResolutionEnabled(uint uid, bool enabled, SUPER_RESOLUTION_STATE_REASON reason)
        {
        }

        /**
         * Occurs when the state of the media stream relay changes.
         * The SDK returns the state of the current media relay with any error message.
         * @param
         *  state:  The state code. For details, see CHANNEL_MEDIA_RELAY_STATE . 
         *  code:  The error code of the channel media
         *  replay. For details, see CHANNEL_MEDIA_RELAY_ERROR . 
         */
        public virtual void OnChannelMediaRelayStateChanged(CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
        }

        /**
         * Reports events during the media stream relay.
         * @param
         *  code: The event code of channel media relay. See CHANNEL_MEDIA_RELAY_EVENT .
         *  
         */
        public virtual void OnChannelMediaRelayEvent(CHANNEL_MEDIA_RELAY_EVENT code)
        {
        }

        /**
         * Occurs when the engine sends the first local audio frame.
         * Deprecated:
         *  Please use OnFirstLocalAudioFramePublished instead.
         * @param
         *  elapsed: The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.
         */
        [Obsolete("Deprecated since v3.1.0. Use the onFirstLocalAudioFramePublished callback instead",
            false)]
        public virtual void OnFirstLocalAudioFrame(int elapsed)
        {
        }

        /**
         *  Occurs when the first audio frame is published.
         * The SDK triggers this callback under one of the following circumstances: 
         *  The local client enables the audio module and calls JoinChannel [2/2] successfully.
         *  The local client calls MuteLocalAudioStream (true) and MuteLocalAudioStream(false) in sequence.
         *  The local client calls DisableAudio and EnableAudio in sequence.
         * @param
         *  elapsed: The time elapsed (ms) from the local client calling JoinChannel [2/2] until the SDK triggers this callback.
         */
        public virtual void OnFirstLocalAudioFramePublished(int elapsed)
        {
        }

        /**
         * Occurs when the SDK receives the first audio frame from a specific remote user.
         * Deprecated:
         *  Please use OnRemoteAudioStateChanged instead.
         * @param
         *  uid: The user ID of the remote user.
         *  elapsed: The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.
         */
        [Obsolete(
            "Deprecated since v3.0.0. Use onRemoteAudioStateChanged instead",
            false)]
        public virtual void OnFirstRemoteAudioFrame(uint uid, int elapsed)
        {
        }

        /**
         * Occurs when the media push state changes.
         * When the media push state changes, the SDK triggers this callback to report the current state and the reason why the state has changed. When exceptions occur, you can troubleshoot issues by referring to the detailed error descriptions in the error code parameter.
         * @param
         *  state: The current state of the media push. See RTMP_STREAM_PUBLISH_STATE . When the streaming state is RTMP_STREAM_PUBLISH_STATE_FAILURE (4), you can view the error information in the errorCode parameter.
         *  url: The URL address where the state of the media push changes.
         *  errCode: The detailed error information for the media push. See RTMP_STREAM_PUBLISH_ERROR_TYPE .
         */
        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state,
            RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
        }

        /**
         * Reports events during the media push.
         * @param
         *  eventCode: The event code of media push. See RTMP_STREAMING_EVENT for details.
         *  url: The URL for media push.
         */
        public virtual void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        /**
         * Occurs when an RTMP or RTMPS stream is published.
         * Deprecated:
         *  Please use OnRtmpStreamingStateChanged instead. Reports the result of publishing an RTMP or RTMPS stream.
         * @param
         *  url: The CDN streaming URL.
         *  error: Error codes of the RTMP or RTMPS streaming.
         *  ERR_OK (0): The publishing succeeds.
         *  ERR_FAILED (1): The publishing fails.
         *  ERR_INVALID_ARGUMENT (-2): Invalid argument used.
         *  If you do not call SetLiveTranscoding to configure 
         *  LiveTranscoding before calling AddPublishStreamUrl , the SDK reports
         *  ERR_INVALID_ARGUMENT.
         *  ERR_TIMEDOUT (10): The publishing timed out.
         *  ERR_ALREADY_IN_USE (19): The chosen URL address is
         *  already in use for CDN live streaming.
         *  ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH (130): You
         *  cannot publish an encrypted stream.
         *  ERR_PUBLISH_STREAM_CDN_ERROR (151): CDN related
         *  error. Remove the original URL address and add a new one by calling
         *  the RemovePublishStreamUrl and AddPublishStreamUrl methods.
         *  ERR_PUBLISH_STREAM_NUM_REACH_LIMIT (152): The host
         *  manipulates more than 10 URLs. Delete the unnecessary URLs before
         *  adding new ones.
         *  ERR_PUBLISH_STREAM_NOT_AUTHORIZED (153): The host
         *  manipulates other hosts' URLs. Please check your app logic.
         *  ERR_PUBLISH_STREAM_INTERNAL_SERVER_ERROR (154): An
         *  error occurs in Agora's streaming server. Call the RemovePublishStreamUrl method to publish the streaming
         *  again.
         *  ERR_PUBLISH_STREAM_FORMAT_NOT_SUPPORTED (156): The
         *  format of the CDN streaming URL is not supported. Check whether the
         *  URL format is correct. 
         */
        [Obsolete("This method is deprecated, use the onRtmpStreamingStateChanged callback instead",
            false)]
        public virtual void OnStreamPublished(string url, int error)
        {
        }

        /**
         * Occurs when the media push stops.
         * Deprecated:
         *  Please use OnRtmpStreamingStateChanged instead.
         * @param
         *  url: Removes an RTMP or RTMPS URL of the media push.
         */
        [Obsolete("This method is deprecated, use the onRtmpStreamingStateChanged callback instead",
            false)]
        public virtual void OnStreamUnpublished(string url)
        {
        }

        /**
         * Occurs when the publisher's transcoding is updated.
         * When the LiveTranscoding class in the SetLiveTranscoding method updates, the SDK triggers the OnTranscodingUpdated callback to report the update information.
         *  If you call the SetLiveTranscoding
         *  method to set the LiveTranscoding class for the first time, the
         *  SDK does not trigger this callback.
         */
        public virtual void OnTranscodingUpdated()
        {
        }

        /**
         * Occurs when a media stream URL address is added to the interactive live streaming.
         * Agora will soon stop the service for injecting online media streams on the client. If you have not implemented this service, Agora recommends that you do not use it. 
         * @param
         *  url: The URL address of the externally injected stream.
         *  uid: User ID.
         *  status: State of the externally injected stream: INJECT_STREAM_STATUS .
         */
        public virtual void OnStreamInjectedStatus(string url, uint uid, int status)
        {
        }

        /**
         * Occurs when the local audio route changes.
         * @param
         *  routing: The current audio routing. For details, see 
         *  AUDIO_ROUTE_TYPE .
         *  
         */
        public virtual void OnAudioRouteChanged(AUDIO_ROUTE_TYPE routing)
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
         */
        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
        }

        /**
         * Occurs when the remote media stream falls back to the audio-only stream due to poor network conditions or switches back to the video stream after the network conditions improve.
         * If you call SetRemoteSubscribeFallbackOption and set option as STREAM_FALLBACK_OPTION_AUDIO_ONLY, the SDK triggers this callback when the remote media stream falls back to audio-only mode due to poor uplink conditions, or when the remote media stream switches back to the video after the downlink network condition improves.
         *  Once the remote media stream switches to the low-quality stream due to poor network conditions, you can monitor the stream switch between a high-quality and low-quality stream in the OnRemoteVideoStats callback.
         * @param
         *  uid: The user ID of the remote user.
         *  isFallbackOrRecover: true: The remotely subscribed media stream falls back to audio-only due to poor network conditions.
         *  false: The remotely subscribed media stream switches back to the video stream after the network conditions improved. 
         */
        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
        }

        /**
         * Reports the transport-layer statistics of each remote audio stream.
         * Deprecated:
         *  Please use OnRemoteAudioStats instead. 
         *  This callback reports the transport-layer statistics, such as the packet loss rate and network time delay, once every two seconds after the local user receives an audio packet from a remote user. During a call, when the user receives the audio packet sent by the remote user/host, the callback is triggered every 2 seconds.
         * @param
         *  rxKBitrate: Bitrate of the received audio (Kbps).
         *  uid: The ID of the remote user sending the audio streams.
         *  delay: The network delay (ms) from the sender to the receiver.
         *  lost: Packet loss rate (%) of the audio packet sent from the sender to the
         *  receiver.
         */
        [Obsolete("This callback is deprecated and replaced by the onRemoteAudioStats callback",
            false)]
        public virtual void OnRemoteAudioTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        /**
         * Reports the transport-layer statistics of each remote video stream.
         * Deprecated:
         *  Please use OnRemoteVideoStats instead. This callback reports the transport-layer statistics, such as the packet loss rate and network time delay, once every two seconds after the local user receives a video packet from a remote user.
         *  During a call, when the user receives the video packet sent by the remote user/host, the callback is triggered every 2 seconds.
         * @param
         *  rxKBitRate: The bitrate of the received video (Kbps).
         *  uid: The ID of the remote user sending the video packets.
         *  delay: The network delay (ms) from the sender to the receiver.
         *  lost: The packet loss rate (%) of the video packet sent from the remote user.
         */
        [Obsolete("This callback is deprecated and replaced by the onRemoteVideoStats callback",
            false)]
        public virtual void OnRemoteVideoTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        /**
         * Occurs when the microphone is enabled/disabled.
         * Deprecated: Please use the OnLocalAudioStateChanged callback:
         *  LOCAL_AUDIO_STREAM_STATE_STOPPED(0).
         *  LOCAL_AUDIO_STREAM_STATE_RECORDING(1). The SDK triggers this callback when the local user EnableLocalAudio resumes or stops capturing the local audio stream by calling the method.
         * @param
         *  enabled: Whether the microphone is enabled/disabled:
         *  true: The microphone is enabled.
         *  false: The microphone is disabled. 
         */
        [Obsolete("Deprecated since v2.9.0. Use Use LOCAL_AUDIO_STREAM_STATE_STOPPED (0) or LOCAL_AUDIO_STREAM_STATE_RECORDING (1) in the onLocalAudioStateChanged callback instead",
            false)]
        public virtual void OnMicrophoneEnabled(bool enabled)
        {
        }

        /**
         * Occurs when the network connection state changes.
         * When the network connection state changes, the SDK triggers this callback and reports the current connection state and the reason for the change.
         * @param
         *  state: The current connection state. For details, see CONNECTION_STATE_TYPE .
         *  
         *  reason: The reason for a connection state change. For details, see CONNECTION_CHANGED_REASON_TYPE . 
         */
        public virtual void OnConnectionStateChanged(CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        /**
         * Occurs when the local network type changes.
         * This callback occurs when the connection state of the local user changes. You can get the connection state and reason for the state change in this callback. When the network connection is interrupted, this callback indicates whether the interruption is caused by a network type change or poor network conditions.
         * @param
         *  type: The type of the local network connection.
         *  For details, see NETWORK_TYPE . 
         */
        public virtual void OnNetworkTypeChanged(NETWORK_TYPE type)
        {
        }

        /**
         * Occurs when the local user registers a user account.
         * After the local user successfully calls RegisterLocalUserAccount to register the user account or calls JoinChannelWithUserAccount [2/2] to join a channel, the SDK triggers the callback and informs the local user's UID and User Account.
         * @param
         *  userAccount: The user account of the local user.
         *  uid: The ID of the local user.
         */
        public virtual void OnLocalUserRegistered(uint uid, string userAccount)
        {
        }

        /**
         * Occurs when the SDK gets the user ID and user account of the remote user.
         * After a remote user joins the channel, the SDK gets the UID and user account of the remote user, caches them in a mapping table object, and triggers this callback on the local client.
         * @param
         *  info: The UserInfo object that contains the user ID and user account of the remote user. See UserInfo for details.
         *  uid: The ID of the remote user.
         */
        public virtual void OnUserInfoUpdated(uint uid, UserInfo info)
        {
        }

        /**
         * Reports the result of uploading the SDK log files.
         * Since
         *  v3.3.0 After UploadLogFile is called, the SDK triggers the callback to report the result of uploading the SDK log files. If the upload fails, refer to the reason parameter to troubleshoot.
         * @param
         *  requestId: The request ID. The request ID is the same as the requestId returned in UploadLogFile. You can use the requestId to match a specific upload with a callback.
         *  success: Whether the log file is uploaded successfully:
         *  true: Successfully upload the log files.
         *  false: Fails to upload the log files. 
         *  
         *  reason: The reason for the upload failure. For details, see UPLOAD_ERROR_REASON .
         */
        public virtual void OnUploadLogResult(string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
        }

        /**
         * Occurs when the SDK is ready to send metadata.
         * This callback is triggered when the SDK is ready to send metadata.
         *  After receiving this callback, you can call SendMetadata to send the media metadata.
         * @param
         *  metadata: The metadata that the user wants to send. 
         * @return
         * true: Send the metadata.
         *  false: Do not send the metadata.
         */
        public virtual bool OnReadyToSendMetadata(Metadata metadata)
        {
            return true;
        }

        /**
         * Occurs when the local user receives the metadata.
         * @param
         *  metadata: The metadata received.
         */
        public virtual void OnMetadataReceived(Metadata metadata)
        {
        }

        /**
         * Reports the information of an audio file.
         * After successfully calling GetAudioFileInfo , the SDK triggers this callback to report the information of the audio file, such as the file path and duration.
         * @param
         *  info: The information of an audio file. See AudioFileInfo .
         *  error: The information acquisition state. See AUDIO_FILE_INFO_ERROR .
         */
        public virtual void OnRequestAudioFileInfo(AudioFileInfo info, AUDIO_FILE_INFO_ERROR error)
        {
        }

        public virtual void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
        }

        /**
         * Reports the result of taking a video snapshot.
         * After a successful TakeSnapshot method call, the SDK triggers this callback to report whether the snapshot is successfully taken as well as the details for the snapshot taken.
         * @param
         *  filePath: The local path of the snapshot.
         *  channel: The channel name.
         *  uid: The user ID. A uid of 0 indicates the local user.
         *  width: The width (px) of the snapshot.
         *  height: The height (px) of the snapshot.
         *  errCode: The message that confirms success or the reason why the snapshot is not successfully taken:
         *  0: Success.
         *  < 0: Failure:
         *  -1: The SDK fails to write data to a file or encode a JPEG image.
         *  -2: The SDK does not find the video stream of the specified user within one second after the TakeSnapshot method call succeeds. 
         */
        public virtual void OnSnapshotTaken(string channel, uint uid, string filePath, int width, int height, int errCode)
        {
        }

        /**
         * Occurs when the screen sharing information is updated.
         * When you call StartScreenCaptureByDisplayId or StartScreenCaptureByScreenRect to start screen sharing and use the excludeWindowList attribute to block the specified window, the SDK triggers this callback if the window blocking fails.
         * @param
         *  info: Screen sharing information. See ScreenCaptureInfo .
         */
        public virtual void OnScreenCaptureInfoUpdated(ScreenCaptureInfo info) 
        {
        }
        
        public virtual void OnClientRoleChangeFailed(CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole) 
        {
        }

        public virtual void OnWlAccMessage(WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
        }

        public virtual void OnWlAccStats(WlAccStats currentStats, WlAccStats averageStats)
        { 
        }

        /**
         * Reports the proxy connection state.
         * You can use this callback to listen for the state of the SDK connecting to a proxy. For example, when a user calls SetCloudProxy and joins a channel successfully, the SDK triggers this callback to report the user ID, the proxy type connected, and the time elapsed from the user calling JoinChannel [1/2] until this callback is triggered.
         * @param
         *  channel: The channel name.
         *  uid: The user ID.
         *  elapsed: The time elapsed (ms) from the user calling JoinChannel [1/2] until this callback is triggered.
         *  proxyType: The proxy type connected. See CLOUD_PROXY_TYPE .
         *  localProxyIp: Reserved for future use.
         */
        public virtual void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
        }

        /**
         * Reports the result of an audio device test.
         * After successfully calling StartRecordingDeviceTest , StartPlaybackDeviceTest , or StartAudioDeviceLoopbackTest to start an audio device test, the SDK triggers the OnAudioDeviceTestVolumeIndication callback at the set time interval to report the volume information of the audio device tested.
         * @param
         *  volume: Volume level in the range [0,255].
         *  
         *  volumeType: The volume type. See AudioDeviceTestVolumeType .
         *  
         */
        public virtual void OnAudioDeviceTestVolumeIndication(AudioDeviceTestVolumeType volumeType, int volume)
        {
        }

        /**
         * Occurs when the local audio and video recording state changes.
         * When the local audio and video recording state changes, the SDK triggers this callback to report the current recording state and the reason for the change.
         * @param
         *  state: The current recording state. See RecorderState .
         *  error: The reason for the state change. See RecorderErrorCode .
         */
        public virtual void OnRecorderStateChanged(RecorderState state, RecorderErrorCode error)
        {
        }

        /**
         * Occurs when the recording information is updated.
         * After you successfully register this callback and enable the local audio and video recording, the SDK periodically triggers this callback according to the value of recorderInfoUpdateInterval you set in MediaRecorderConfiguration . This callback reports the filename, duration, and size of the current recording file.
         * @param
         *  info: Information of the recording file. See RecorderInfo .
         */
        public virtual void OnRecorderInfoUpdated(RecorderInfo info)
        {
        }
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}
