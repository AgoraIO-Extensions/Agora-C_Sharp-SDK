using System;
using video_track_id_t = System.UInt32;
using view_t = System.Int64;
namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The basic interface of the Agora SDK that implements the core functions of real-time communication.
    /// IRtcEngine provides the main methods that your app can call.Before calling other APIs, you must call CreateAgoraRtcEngine to create an IRtcEngine object.
    /// </summary>
    ///
    public abstract class IRtcEngine
    {
        #region Channel management
        ///
        /// <summary>
        /// Initializes IRtcEngine.
        /// All called methods provided by the IRtcEngine class are executed asynchronously. Agora recommends calling these methods in the same thread.The SDK supports creating only one IRtcEngine instance for an app.
        /// </summary>
        ///
        /// <param name="context"> Configurations for the IRtcEngine instance. See RtcEngineContext .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-7: The SDK is not initialized.-22: The resource request failed. The SDK fails to allocate resources because your app consumes too much system resource or the system resources are insufficient.-101: The App ID is invalid.
        /// </returns>
        ///
        public abstract int Initialize(RtcEngineContext context);

        ///
        /// <summary>
        /// Releases the IRtcEngine instance.
        /// This method releases all resources used by the Agora SDK. Use this method for apps in which users occasionally make voice or video calls. When users do not make calls, you can free up resources for other operations.After a successful method call, you can no longer use any method or callback in the SDK anymore. If you want to use the real-time communication functions again, you must call CreateAgoraRtcEngine and Initialize to create a new IRtcEngine instance.If you want to create a new IRtcEngine instance after destroyingthe current one, ensure that you wait till the Dispose method execution to complete.
        /// </summary>
        ///
        /// <param name="sync"> Whether the method is called synchronously:true: Synchronous call. Agora suggests calling this method in a sub-thread to avoid congestion in the main thread because the synchronous call and the app cannot move on to another task until the resources used by IRtcEngine are released. Besides, you cannot call Dispose in any method or callback of the SDK. Otherwise, the SDK cannot release the resources until the callbacks return results, which may result in a deadlock.false: Asynchronous call. Currently this method only supports synchronous calls, do not set this parameter to this value.</param>
        ///
        public abstract void Dispose(bool sync = false);

        ///
        /// <summary>
        /// Sets the channel profile.
        /// After initializing the SDK, the default channel profile is the live streaming profile. You can call this method to set the usage scenario of the channel. For example, it prioritizes smoothness and low latency for a video call, and prioritizes video quality for the interactive live video streaming.To ensure the quality of real-time communication, Agora recommends that all users in a channel use the same channel profile.This method must be called and set before JoinChannel [2/2], and cannot be set again after joining the channel.
        /// </summary>
        ///
        /// <param name="profile"> The channel profile. See CHANNEL_PROFILE_TYPE .</param>
        ///
        /// <returns>
        /// 0(ERR_OK): Success.&lt; 0: Failure.-2: The parameter is invalid.-7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int SetChannelProfile(CHANNEL_PROFILE_TYPE profile);

        ///
        /// <summary>
        /// Sets the client role.
        /// You can call this method either before or after joining the channel to set the user role as audience or host.If you call this method to switch the user role after joining the channel, the SDK triggers the following callbacks:The local client: OnClientRoleChanged .The remote client: OnUserJoined or OnUserOffline (USER_OFFLINE_BECOME_AUDIENCE).
        /// </summary>
        ///
        /// <param name="role"> The user role. See CLIENT_ROLE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);

        ///
        /// <summary>
        /// Sets the user role and level in an interactive live streaming channel.
        /// In the interactive live streaming profile, the SDK sets the user role as audience by default. You can call this method to set the user role as host.You can call this method either before or after joining a channel.If you call this method to switch the user role after joining a channel, the SDK automatically does the following:Calls MuteLocalAudioStream and MuteLocalVideoStream to change the publishing state.Triggers OnClientRoleChanged on the local client.Triggers OnUserJoined or OnUserOffline on the remote client.The difference between this method and SetClientRole [1/2] is that this method can set the user level in addition to the user role.The user role (role) determines the permissions that the SDK grants to a user, such as permission to send local streams, receive remote streams, and push streams to a CDN address.The user level (level) determines the level of services that a user can enjoy within the permissions of the user's role. For example, an audience member can choose to receive remote streams with low latency or ultra-low latency. User level affects the pricing of services.This method applies to the interactive live streaming profile (the profile parameter of SetChannelProfile is CHANNEL_PROFILE_LIVE_BROADCASTING) only.
        /// </summary>
        ///
        /// <param name="role"> The user role in the interactive live streaming. See CLIENT_ROLE_TYPE .</param>
        ///
        /// <param name="options"> The detailed options of a user, including the user level. See ClientRoleOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-5: The request is rejected.-7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options);

        ///
        /// <summary>
        /// Joins a channel.
        /// When the connection between the client and Agora's server is interrupted due to poor network conditions, the SDK tries reconnecting to the server. When the local client successfully rejoins the channel, the SDK triggers the OnRejoinChannelSuccess callback on the local client.
        /// A successful call of this method triggers the following callbacks:
        /// The local client: The OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
        /// The remote client: OnUserJoined , if the user joining the channel is in the Communication profile or is a host in the Live-broadcasting profile. This method enables users to join a channel. Users in the same channel can talk to each other, and multiple users in the same channel can start a group chat. Users with different App IDs cannot call each other.
        /// Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.
        /// </summary>
        ///
        /// <param name="channelId"> The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters:
        ///  All lowercase English letters: a to z.
        ///  All uppercase English letters: A to Z.
        ///  All numeric characters: 0 to 9.
        ///  Space
        ///  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "= ", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <param name="token"> The token generated on your server for authentication. </param>
        ///
        /// <param name="info"> (Optional) Reserved for future use.</param>
        ///
        /// <param name="uid"> The user ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to 232-1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and returns it in the OnJoinChannelSuccess callback. Your application must record and maintain the returned user ID, because the SDK does not do so.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in ChannelMediaOptions is invalid. You need to pass in a valid parameter and join the channel again.
        /// -3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: The internal state of the IRtcEngine object is wrong. The typical cause is that you call this method to join the channel without calling StartEchoTest [3/3] to stop the test after calling StopEchoTest to start a call loop test. You need to call StopEchoTest before calling this method.
        /// -17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.
        /// -102: The channel name is invalid. You need to pass in a valid channelname in channelId to rejoin the channel.
        /// -121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannel(string token, string channelId, string info = "", uint uid = 0);

        ///
        /// <summary>
        /// Joins a channel with media options.
        /// This method enables users to join a channel. Users in the same channel can talk to each other, and multiple users in the same channel can start a group chat. Users with different App IDs cannot call each other.A successful call of this method triggers the following callbacks:The local client: The OnJoinChannelSuccess and OnConnectionStateChanged callbacks.The remote client: OnUserJoined , if the user joining the channel is in the Communication profile or is a host in the Live-broadcasting profile.When the connection between the client and Agora's server is interrupted due to poor network conditions, the SDK tries reconnecting to the server. When the local client successfully rejoins the channel, the SDK triggers the OnRejoinChannelSuccess callback on the local client.Compared to JoinChannel [1/2] , this method adds the options parameter to configure whether to automatically subscribe to all remote audio and video streams in the channel when the user joins the channel. By default, the user subscribes to the audio and video streams of all the other users in the channel, giving rise to usage and billings. To unsubscribe, set the options parameter or call the mute methods accordingly.This method allows users to join only one channel at a time.Ensure that the app ID you use to generate the token is the same app ID that you pass in the Initialize method; otherwise, you may fail to join the channel by token.
        /// </summary>
        ///
        /// <param name="token"> The token generated on your server for authentication. </param>
        ///
        /// <param name="channelId"> The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters:All lowercase English letters: a to z.All uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "= ", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <param name="uid"> The user ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to 232-1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and returns it in the OnJoinChannelSuccess callback. Your application must record and maintain the returned user ID, because the SDK does not do so.</param>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in ChannelMediaOptions is invalid. You need to pass in a valid parameter and join the channel again.-3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.-7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.-8: The internal state of the IRtcEngine object is wrong. The typical cause is that you call this method to join the channel without calling StartEchoTest [3/3] to stop the test after calling StopEchoTest to start a call loop test. You need to call StopEchoTest before calling this method.-17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.-102: The channel name is invalid. You need to pass in a valid channelname in channelId to rejoin the channel.-121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options);

        ///
        /// <summary>
        /// Updates the channel media options after joining the channel.
        /// </summary>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The value of a member in the ChannelMediaOptions structure is invalid. For example, the token or the user ID is invalid. You need to fill in a valid parameter.-7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.-8: The internal state of the IRtcEngine object is wrong. The possible reason is that the user is not in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. If you receive the CONNECTION_STATE_DISCONNECTED (1) or CONNECTION_STATE_FAILED (5) state, the user is not in the channel. You need to call JoinChannel [2/2] to join a channel before calling this method.
        /// </returns>
        ///
        public abstract int UpdateChannelMediaOptions(ChannelMediaOptions options);

        ///
        /// <summary>
        /// Leaves a channel.
        /// This method releases all resources related to the session.This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel.After joining the channel, you must call this method or LeaveChannel [2/2] to end the call, otherwise, the next call cannot be started.If you successfully call this method and leave the channel, the following callbacks are triggered:The local client: OnLeaveChannel .The remote client: OnUserOffline , if the user joining the channel is in the Communication profile, or is a host in the Live-broadcasting profile.If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.If you have called JoinChannelEx to join multiple channels, calling this method will leave the channels when calling JoinChannel [2/2] and JoinChannelEx at the same time.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int LeaveChannel();

        ///
        /// <summary>
        /// Sets channel options and leaves the channel.
        /// If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.
        /// If you have called JoinChannelEx to join multiple channels, calling this method will leave the channels when calling JoinChannel [2/2] and JoinChannelEx at the same time.
        /// This method will release all resources related to the session, leave the channel, that is, hang up or exit the call. This method can be called whether or not a call is currently in progress.After joining the channel, you must call this method or to end the call, otherwise, the next call cannot be started.This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel. After actually leaving the channel, the local user triggers the OnLeaveChannel callback; after the user in the communication scenario and the host in the live streaming scenario leave the channel, the remote user triggers the OnUserOffline callback.
        /// </summary>
        ///
        /// <param name="options"> The options for leaving the channel. See LeaveChannelOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LeaveChannel(LeaveChannelOptions options);

        ///
        /// <summary>
        /// Renews the token.
        /// The SDK triggers the OnTokenPrivilegeWillExpire callback.The OnConnectionStateChanged callback reports CONNECTION_CHANGED_TOKEN_EXPIRED(9).
        /// </summary>
        ///
        /// <param name="token"> The new token.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid. For example, the token is invalid. You need to fill in a valid parameter.-7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// </returns>
        ///
        public abstract int RenewToken(string token);

        ///
        /// <summary>
        /// Joins a channel with a User Account and Token.
        /// This method allows a user to join the channel with the user account and a token. After the user successfully joins the channel, the SDK triggers the following callbacks:The local client: OnLocalUserRegistered , OnJoinChannelSuccess and OnConnectionStateChanged callbacks.The remote client: OnUserJoined and OnUserInfoUpdated callbacks, if the user joining the channel is in the communication profile or is a host in the live streaming profile.Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="userAccount"> The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are (89 in total):The 26 lowercase English letters: a to z.The 26 uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "= ", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <param name="token"> The token generated on your server for authentication. </param>
        ///
        /// <param name="channelId"> The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters:All lowercase English letters: a to z.All uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "= ", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid.-3: The initialization of the SDK fails. You can try to initialize the SDK again.-5: The request is rejected.-17: The request to join the channel is rejected. Since the SDK only supports users to join one IRtcEngine channel at a time; this error code will be returned when the user who has joined the IRtcEngine channel calls the join channel method in the IRtcEngine class again with a valid channel name.
        /// </returns>
        ///
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        ///
        /// <summary>
        /// Joins the channel with a user account, and configures whether to automatically subscribe to audio or video streams after joining the channel.
        /// This method allows a user to join the channel with the user account. After the user successfully joins the channel, the SDK triggers the following callbacks:The local client: OnLocalUserRegistered , OnJoinChannelSuccess and OnConnectionStateChanged callbacks.The remote client: The OnUserJoined callback, if the user is in the COMMUNICATION profile, and the OnUserInfoUpdated callback if the user is a host in the LIVE_BROADCASTING profile.Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions .</param>
        ///
        /// <param name="token"> The token generated on your server for authentication. </param>
        ///
        /// <param name="channelId"> The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters:
        ///  All lowercase English letters: a to z.
        ///  All uppercase English letters: A to Z.
        ///  All numeric characters: 0 to 9.
        ///  Space
        ///  "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "= ", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <param name="userAccount"> The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are (89 in total):The 26 lowercase English letters: a to z.The 26 uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "= ", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in ChannelMediaOptions is invalid. You need to pass in a valid parameter and join the channel again.
        /// -3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: The internal state of the IRtcEngine object is wrong. The typical cause is that you call this method to join the channel without calling StartEchoTest [3/3] to stop the test after calling StopEchoTest to start a call loop test. You need to call StopEchoTest before calling this method.
        /// -17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.
        /// -102: The channel name is invalid. You need to pass in a valid channelname in channelId to rejoin the channel.
        /// -121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options);

        ///
        /// <summary>
        /// Gets the user information by passing in the user account.
        /// After a remote user joins the channel, the SDK gets the user ID and account of the remote user, caches them in a mapping table object, and triggers the OnUserInfoUpdated callback on the local client. After receiving the callback, you can call this method to get the user account of the remote user from the UserInfo object by passing in the user ID.
        /// </summary>
        ///
        /// <param name="userInfo"> Input and output parameter. The UserInfo object that identifies the user information.
        ///  Input: A UserInfo object.
        ///  Output: A UserInfo object that contains the user account and user ID of the user.</param>
        ///
        /// <param name="userAccount"> The user account.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo);

        ///
        /// <summary>
        /// Gets the user information by passing in the user ID.
        /// After a remote user joins the channel, the SDK gets the user ID and account of the remote user, caches them in a mapping table object, and triggers the OnUserInfoUpdated callback on the local client. After receiving the callback, you can call this method to get the user account of the remote user from the UserInfo object by passing in the user ID.
        /// </summary>
        ///
        /// <param name="uid"> The user ID.</param>
        ///
        /// <param name="userInfo"> Input and output parameter. The UserInfo object that identifies the user information.Input: A UserInfo object.Output: A UserInfo object that contains the user account and user ID of the user.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetUserInfoByUid(uint uid, ref UserInfo userInfo);
        #endregion

        #region Event handler
        ///
        /// <summary>
        /// Adds event handlers
        /// The SDK uses the IRtcEngineEventHandler class to send callbacks to the app. The app inherits the methods of this class to receive these callbacks. All methods in this class have default (empty) implementations. Therefore, apps only need to inherits callbacks according to the scenarios. In the callbacks, avoid time-consuming tasks or calling APIs that can block the thread, such as the SendStreamMessage method.
        /// Otherwise, the SDK may not work properly.
        /// </summary>
        ///
        /// <param name="engineEventHandler"> Callback events to be added. See IRtcEngineEventHandler .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int InitEventHandler(IRtcEngineEventHandler engineEventHandler);
        #endregion

        #region Audio management
        ///
        /// <summary>
        /// Enables the audio module.
        /// The audio mode is enabled by default.This method enables the internal engine and can be called anytime after initialization. It is still valid after one leaves channel.This method enables the whole audio module and thus might take a while to take effect. Agora recommends using the following APIs to control the audio module separately: EnableLocalAudio : Whether to enable the microphone to create the local audio stream. MuteLocalAudioStream : Whether to publish the local audio stream. MuteRemoteAudioStream : Whether to subscribe and play the remote audio stream. MuteAllRemoteAudioStreams : Whether to subscribe to and play all remote audio streams.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableAudio();

        ///
        /// <summary>
        /// Disables the audio module.
        /// This method disables the internal engine and can be called anytime after initialization. It is still valid after one leaves channel.This method resets the internal engine and takes some time to take effect. Agora recommends using the following API methods to control the audio modules separately: EnableLocalAudio : Whether to enable the microphone to create the local audio stream. MuteLocalAudioStream : Whether to publish the local audio stream. MuteRemoteAudioStream : Whether to subscribe and play the remote audio stream. MuteAllRemoteAudioStreams : Whether to subscribe to and play all remote audio streams.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DisableAudio();

        ///
        /// <summary>
        /// Sets the audio profile and audio scenario.
        /// Deprecated:This method is deprecated. If you need to set the audio profile, use SetAudioProfile [2/2] ; if you need to set the audio scenario, use SetAudioScenario .You can call this method either before or after joining a channel.In scenarios requiring high-quality audio, such as online music tutoring, Agora recommends you set profile as AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)and scenario as AUDIO_SCENARIO_GAME_STREAMING(3).
        /// </summary>
        ///
        /// <param name="profile"> The audio profile, including the sampling rate, bitrate, encoding mode, and the number of channels. See AUDIO_PROFILE_TYPE .</param>
        ///
        /// <param name="scenario"> The audio scenarios. See AUDIO_SCENARIO_TYPE . Under different audio scenarios, the device uses different volume types.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);

        ///
        /// <summary>
        /// Sets the audio parameters and application scenarios.
        /// You can call this method either before or after joining a channel.In scenarios requiring high-quality audio, such as online music tutoring, Agora recommends you set profile as AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4).If you need to set the audio scenario, you can either call SetAudioScenario , or Initialize and set the audioScenario in RtcEngineContext .
        /// </summary>
        ///
        /// <param name="profile"> The audio profile, including the sampling rate, bitrate, encoding mode, and the number of channels. See AUDIO_PROFILE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile);

        ///
        /// <summary>
        /// Sets audio scenarios.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="scenario"> The audio scenarios. See AUDIO_SCENARIO_TYPE . Under different audio scenarios, the device uses different volume types.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario);

        ///
        /// <summary>
        /// Adjusts the capturing signal volume.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="volume"> The volume of the user. The value range is [0,400].0: Mute.If you only need to mute the audio signal, Agora recommends that you use MuteRecordingSignal instead.100: (Default) The original volume.400: Four times the original volume (amplifying the audio signals by four times).</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustRecordingSignalVolume(int volume);

        ///
        /// <summary>
        /// Whether to mute the recording signal.
        /// </summary>
        ///
        /// <param name="mute"> true: The media file is muted.false: (Default) Do not mute the recording signal.If you have already called AdjustRecordingSignalVolume to adjust the volume, then when you call this method and set it to true, the SDK will record the current volume and mute it. To restore the previous volume, call this method again and set it to false.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRecordingSignal(bool mute);

        ///
        /// <summary>
        /// Adjusts the playback signal volume of all remote users.
        /// This method adjusts the playback volume that is the mixed volume of all remote users.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="volume"> The volume of the user. The value range is [0,400].
        ///  0: Mute.If you only need to mute the audio signal, Agora recommends that you use MuteRecordingSignal instead.
        ///  100: (Default) The original volume.
        ///  400: Four times the original volume (amplifying the audio signals by four times).</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustPlaybackSignalVolume(int volume);

        ///
        /// <summary>
        /// Adjusts the volume of the signal captured by the sound card.
        /// After calling EnableLoopbackRecording to enable loopback audio capturing, you can call this method to adjust the volume of the signal captured by the sound card.
        /// </summary>
        ///
        /// <param name="volume"> Audio mixing volume. The value ranges between 0 and 100. The default value is 100, which means the original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustLoopbackSignalVolume(int volume);

        ///
        /// <summary>
        /// Adjusts the playback signal volume of a specified remote user.
        /// You can call this method to adjust the playback volume of a specified remote user. To adjust the playback volume of different remote users, call the method as many times, once for each remote user.Call this method after joining a channel.The playback volume here refers to the mixed volume of a specified remote user.
        /// </summary>
        ///
        /// <param name="volume"> Audio mixing volume. The value ranges between 0 and 100. The default value is 100, which means the original volume.</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);

        ///
        /// <summary>
        /// Enables or disables the local audio capture.
        /// The audio function is enabled by default when users joining a channel. This method disables or re-enables the local audio function to stop or restart local audio capturing.This method does not affect receiving or playing the remote audio streams, and EnableLocalAudio (false) is applicable to scenarios where the user wants to receive remote audio streams without sending any audio stream to other users in the channel.Once the local audio function is disabled or re-enabled, the SDK triggers the OnLocalAudioStateChanged callback, which reports LOCAL_AUDIO_STREAM_STATE_STOPPED(0) or LOCAL_AUDIO_STREAM_STATE_RECORDING(1).The difference between this method and MuteLocalAudioStream are as follow:EnableLocalAudio: Disables or re-enables the local audio capturing and processing. If you disable or re-enable local audio capturing using the EnableLocalAudio method, the local user might hear a pause in the remote audio playback.MuteLocalAudioStream: Sends or stops sending the local audio streams.You can call this method either before or after joining a channel. Calling it before joining a channel only sets the device state, and it takes effect immediately after you join the channel.
        /// </summary>
        ///
        /// <param name="enabled"> true: (Default) Re-enable the local audio function, that is, to start the local audio capturing device (for example, the microphone).false: Disable the local audio function, that is, to stop local audio capturing.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLocalAudio(bool enabled);

        ///
        /// <summary>
        /// Stops or resumes publishing the local audio stream.
        /// This method does not affect any ongoing audio recording, because it does not disable the audio capture device.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop publishing the local audio stream:true: Stops publishing the local audio stream.false: (Default) Resumes publishing the local audio stream.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalAudioStream(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio streams of all remote users.
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users.Call this method after joining a channel.If you do not want to subscribe the audio streams of remote users before joining a channel, you can set autoSubscribeAudio as false when calling JoinChannel [2/2] .
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users:true: Stops subscribing to the audio streams of all remote users.false: (Default) Subscribes to the audio streams of all remote users by default.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        ///
        /// @ignore
        ///
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio stream of a specified user.
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the specified user.</param>
        ///
        /// <param name="mute"> Whether to subscribe to the specified remote user's audio stream.true: Stop subscribing to the audio stream of the specified user.false: (Default) Subscribe to the audio stream of the specified user.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteAudioStream(uint uid, bool mute);
        #endregion

        #region Video management
        ///
        /// <summary>
        /// Enables the video module.
        /// Call this method either before joining a channel or during a call. If this method is called before joining a channel, the call starts in the video mode; if called during a call, the audio call switches to a video call. Call DisableVideo to disable the video mode.A successful call of this method triggers the OnRemoteVideoStateChanged callback on the remote client.This method enables the internal engine and is valid after leaving the channel.This method resets the internal engine and thus might takes some time to take effect. Agora recommends using the following APIs to control the video modules separately: EnableLocalVideo : Whether to enable the camera to create the local video stream. MuteLocalVideoStream : Whether to publish the local video stream. MuteRemoteVideoStream : Whether to subscribe to and play the remote video stream. MuteAllRemoteVideoStreams : Whether to subscribe to and play all remote video streams.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableVideo();

        ///
        /// <summary>
        /// Disables the video module.
        /// This method can be called before joining a channel or during a call to disable the video module. If it is called before joining a channel, an audio call starts when you join the channel; if called during a call, a video call switches to an audio call. Call EnableVideo to enable the video module.A successful call of this method triggers the OnUserEnableVideo (false) callback on the remote client.This method affects the internal engine and can be called after leaving the channel.This method resets the internal engine and thus might takes some time to take effect. Agora recommends using the following APIs to control the video modules separately: EnableLocalVideo : Whether to enable the camera to create the local video stream. MuteLocalVideoStream : Whether to publish the local video stream. MuteRemoteVideoStream : Whether to subscribe to and play the remote video stream. MuteAllRemoteVideoStreams : Whether to subscribe to and play all remote video streams.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DisableVideo();

        ///
        /// <summary>
        /// Enables the local video preview.
        /// You can call this method to enable local video preview. Before calling this method, ensure that you do the following:Call EnableVideo to enable the video.The local preview enables the mirror mode by default.After the local video preview is enabled, if you call LeaveChannel [1/2] to exit the channel, the local preview remains until you call StopPreview [1/2] to disable it.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartPreview();

        ///
        /// <summary>
        /// Enables the local video preview and specifies the video source for the preview.
        /// You can call this method to enable local video preview. Before calling this method, ensure that you do the following:Call EnableVideo to enable the video.The local preview enables the mirror mode by default.After the local video preview is enabled, if you call LeaveChannel [1/2] StopPreview [2/2] to disable it.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartPreview(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Stops the local video preview.
        /// After calling StartPreview [1/2] to start the preview, if you want to close the local video preview, call this method.Call this method before joining a channel or after leaving a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopPreview();

        ///
        /// <summary>
        /// Stops the local video preview.
        /// After calling StartPreview [2/2] to start the preview, if you want to close the local video preview, call this method.Call this method before joining a channel or after leaving a channel.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopPreview(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Sets the video encoder configuration.
        /// Sets the encoder configuration for the local video.You can call this method either before or after joining a channel. If the user does not need to reset the video encoding properties after joining the channel, Agora recommends calling this method before EnableVideo to reduce the time to render the first video frame.
        /// </summary>
        ///
        /// <param name="config"> Video profile. See VideoEncoderConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVideoEncoderConfiguration(VideoEncoderConfiguration config);

        ///
        /// <summary>
        /// Initializes the video view of a remote user.
        /// This method initializes the video view of a remote stream on the local device. It affects only the video view that the local user sees. Call this method to bind the remote video stream to a video view and to set the rendering and mirror modes of the video view.You need to specify the ID of the remote user in this method. If the remote user ID is unknown to the application, set it after the app receives the OnUserJoined callback.To unbind the remote user from the view, set the view parameter to NULL.Once the remote user leaves the channel, the SDK unbinds the remote user.If you need to implement native window rendering, use this method; if you only need to render video images in your Unity project, use the methods in the VideoSurface class instead.To update the rendering or mirror mode of the remote video view during a call, use the SetRemoteRenderMode method.If you use the Agora recording function, the recording client joins the channel as a placeholder client, triggering the OnUserJoined callback. Do not bind the placeholder client to the app view because the placeholder client does not send any video streams. If your app does not recognize the placeholder client, bind the remote user to the view when the SDK triggers the OnFirstRemoteVideoDecoded callback.
        /// </summary>
        ///
        /// <param name="canvas"> The remote video view and settings. See VideoCanvas .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetupRemoteVideo(VideoCanvas canvas);

        ///
        /// <summary>
        /// Initializes the local video view.
        /// This method initializes the video view of a local stream on the local device. It affects only the video view that the local user sees, not the published local video stream. Call this method to bind the local video stream to a video view and to set the rendering and mirror modes of the video view.After initialization, call this method to set the local video and then join the channel. The local video still binds to the view after you leave the channel. To unbind the local video from the view, set the view parameter as NULL.If you need to implement native window rendering, use this method; if you only need to render video images in your Unity project, use the methods in the VideoSurface class instead.You can call this method either before or after joining a channel.To update the rendering or mirror mode of the local video view during a call, use the SetLocalRenderMode [2/2] method.
        /// </summary>
        ///
        /// <param name="canvas"> The local video view and settings. See VideoCanvas .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetupLocalVideo(VideoCanvas canvas);


        ///
        /// <summary>
        /// Sets video application scenarios.
        /// After successfully calling this method, the SDK will automatically enable the best practice strategies and adjust key performance metrics based on the specified scenario, to optimize the video experience.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="scenarioType"> The type of video application scenario. See VIDEO_APPLICATION_SCENARIO_TYPE .If set to APPLICATION_SCENARIO_MEETING (1), the SDK automatically enables the following strategies:In meeting scenarios where low-quality video streams are required to have a high bitrate, the SDK automatically enables multiple technologies used to deal with network congestions, to enhance the performance of the low-quality streams and to ensure the smooth reception by subscribers.The SDK monitors the number of subscribers to the high-quality video stream in real time and dynamically adjusts its configuration based on the number of subscribers.If nobody subscribers to the high-quality stream, the SDK automatically reduces its bitrate and frame rate to save upstream bandwidth.If someone subscribes to the high-quality stream, the SDK resets the high-quality stream to the VideoEncoderConfiguration configuration used in the most recent calling of SetVideoEncoderConfiguration . If no configuration has been set by the user previously, the following values are used:Resolution: (Windows and macOS) 1280 × 720; (Android and iOS) 960 × 540Frame rate: 15 fpsBitrate: (Windows and macOS) 1600 Kbps; (Android and iOS) 1000 KbpsThe SDK monitors the number of subscribers to the low-quality video stream in real time and dynamically enables or disables it based on the number of subscribers.If the user has called SetDualStreamMode [2/2] to set that never send low-quality video stream (DISABLE_SIMULCAST_STREAM), the dynamic adjustment of the low-quality stream in meeting scenarios will not take effect.If nobody subscribes to the low-quality stream, the SDK automatically disables it to save upstream bandwidth.If someone subscribes to the low-quality stream, the SDK enables the low-quality stream and resets it to the SimulcastStreamConfig configuration used in the most recent calling of SetDualStreamMode [2/2]. If no configuration has been set by the user previously, the following values are used:Resolution: 480 × 272Frame rate: 15 fpsBitrate: 500 Kbps</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVideoScenario(VIDEO_APPLICATION_SCENARIO_TYPE scenarioType);
        ///
        /// <summary>
        /// Sets the local video display mode.
        /// Deprecated:This method is deprecated. Use SetLocalRenderMode [2/2] instead.Call this method to set the local video display mode. This method can be called multiple times during a call to change the display mode.
        /// </summary>
        ///
        /// <param name="renderMode"> The local video display mode. See RENDER_MODE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode);

        ///
        /// <summary>
        /// Updates the display mode of the local video view.
        /// After initializing the local video view, you can call this method to update its rendering and mirror modes. It affects only the video view that the local user sees, not the published local video stream.Ensure that you have called the SetupLocalVideo method to initialize the local video view before calling this method.During a call, you can call this method as many times as necessary to update the display mode of the local video view.
        /// </summary>
        ///
        /// <param name="renderMode"> The local video display mode. See RENDER_MODE_TYPE .</param>
        ///
        /// <param name="mirrorMode"> The mirror mode of the local video view. See VIDEO_MIRROR_MODE_TYPE .This parameter is only effective when rendering custom videos. If you want to mirror the video view, set the scaleX of the GameObject attached to the video view as -1 or +1.If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        ///
        /// <summary>
        /// Updates the display mode of the video view of a remote user.
        /// After initializing the video view of a remote user, you can call this method to update its rendering and mirror modes. This method affects only the video view that the local user sees.During a call, you can call this method as many times as necessary to update the display mode of the video view of a remote user.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="renderMode"> The rendering mode of the remote user view. For details, see RENDER_MODE_TYPE .</param>
        ///
        /// <param name="mirrorMode"> The mirror mode of the remote user view. See VIDEO_MIRROR_MODE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        ///
        /// <summary>
        /// Sets the local video mirror mode.
        /// Deprecated:This method is deprecated.Use SetLocalRenderMode [2/2] instead.
        /// </summary>
        ///
        /// <param name="mirrorMode"> The local video mirror mode. See VIDEO_MIRROR_MODE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode);

        ///
        /// <summary>
        /// Stops or resumes publishing the local video stream.
        /// A successful call of this method triggers the OnUserMuteVideo callback on the remote client.This method executes faster than the EnableLocalVideo (false) method, which controls the sending of the local video stream.This method does not affect any ongoing video recording, because it does not disable the camera.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop publishing the local video stream.true: Stop publishing the local video stream.false: (Default) Publish the local video stream.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalVideoStream(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the video stream of a specified user.
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the specified user.</param>
        ///
        /// <param name="mute"> Whether to subscribe to the specified remote user's video stream.true: Stop subscribing to the video streams of the specified user.false: (Default) Subscribe to the video stream of the specified user.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteVideoStream(uint uid, bool mute);

        ///
        /// <summary>
        /// Enables/Disables the local video capture.
        /// This method disables or re-enables the local video capture, and does not affect receiving the remote video stream.After calling EnableVideo , the local video capture is enabled by default. You can call EnableLocalVideo (false) to disable the local video capture. If you want to re-enable the local video capture, call EnableLocalVideo(true).After the local video capturer is successfully disabled or re-enabled, the SDK triggers the OnRemoteVideoStateChanged callback on the remote client.You can call this method either before or after joining a channel.This method enables the internal engine and is valid after leaving the channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the local video capture.true: (Default) Enable the local video capture.false: Disable the local video capture. Once the local video is disabled, the remote users cannot receive the video stream of the local user, while the local user can still receive the video streams of remote users. When set to false, this method does not require a local camera.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLocalVideo(bool enabled);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the video streams of all remote users.
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users.Call this method after joining a channel.If you do not want to subscribe the video streams of remote users before joining a channel, you can call JoinChannel [2/2] and set autoSubscribeVideo as false.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the video streams of all remote users.true: Stop subscribing to the video streams of all remote users.false: (Default) Subscribe to the audio streams of all remote users by default.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteVideoStreams(bool mute);

        ///
        /// @ignore
        ///
        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        ///
        /// <summary>
        /// Sets whether to replace the current video feeds with images when publishing video streams.
        /// Agora recommends that you call this method after joining a channel.When publishing video streams, you can call this method to replace the current video feeds with custom images.Once you enable this function, you can select images to replace the video feeds through the ImageTrackOptions parameter. If you disable this function, the remote users see the video feeds that you publish.
        /// </summary>
        ///
        /// <param name="enable"> Whether to replace the current video feeds with custom images:true: Replace the current video feeds with custom images.false: (Default) Do not replace the current video feeds with custom images.</param>
        ///
        /// <param name="options"> Image configurations. See ImageTrackOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableVideoImageSource(bool enable, ImageTrackOptions options);

        ///
        /// <summary>
        /// Sets color enhancement.
        /// The video images captured by the camera can have color distortion. The color enhancement feature intelligently adjusts video characteristics such as saturation and contrast to enhance the video color richness and color reproduction, making the video more vivid.You can call this method to enable the color enhancement feature and set the options of the color enhancement effect.Call this method after calling EnableVideo .The color enhancement feature has certain performance requirements on devices. With color enhancement turned on, Agora recommends that you change the color enhancement level to one that consumes less performance or turn off color enhancement if your device is experiencing severe heat problems.Both this method and SetExtensionProperty can enable color enhancement:When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.This method relies on the video enhancement dynamic library libagora_clear_vision_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE .</param>
        ///
        /// <param name="enabled"> Whether to enable color enhancement:true Enable color enhancement.false: (Default) Disable color enhancement.</param>
        ///
        /// <param name="options"> The color enhancement options. See ColorEnhanceOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Sets low-light enhancement.
        /// The low-light enhancement feature can adaptively adjust the brightness value of the video captured in situations with low or uneven lighting, such as backlit, cloudy, or dark scenes. It restores or highlights the image details and improves the overall visual effect of the video.You can call this method to enable the color enhancement feature and set the options of the color enhancement effect.Call this method after calling EnableVideo .Dark light enhancement has certain requirements for equipment performance. The low-light enhancement feature has certain performance requirements on devices. If your device overheats after you enable low-light enhancement, Agora recommends modifying the low-light enhancement options to a less performance-consuming level or disabling low-light enhancement entirely.Both this method and SetExtensionProperty can turn on low-light enhancement:When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.This method relies on the video enhancement dynamic library libagora_clear_vision_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable low-light enhancement function:true: Enable low-light enhancement function.false: (Default) Disable low-light enhancement function.</param>
        ///
        /// <param name="options"> The low-light enhancement options. See LowlightEnhanceOptions .</param>
        ///
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Options for subscribing to remote video streams.
        /// When a remote user has enabled dual-stream mode, you can call this method to choose the option for subscribing to the video streams sent by the remote user.If you only register one IVideoFrameObserver object, the SDK subscribes to the raw video data and encoded video data by default (the effect is equivalent to setting encodedFrameOnly to false).If you only register one IVideoEncodedFrameObserver object, the SDK only subscribes to the encoded video data by default (the effect is equivalent to setting encodedFrameOnly to true).If you register one IVideoFrameObserver object and one IVideoEncodedFrameObserver object successively, the SDK subscribes to the encoded video data by default (the effect is equivalent to setting encodedFrameOnly to false).If you call this method first with the options parameter set, and then register one IVideoFrameObserver or IVideoEncodedFrameObserver object, you need to call this method again and set the options parameter as described in the above two items to get the desired results.Agora recommends the following steps:Set autoSubscribeVideo to false when calling JoinChannel [2/2] to join a channel.Call this method after receiving the OnUserJoined callback to set the subscription options for the specified remote user's video stream.Call the MuteRemoteVideoStream method to resume subscribing to the video stream of the specified remote user. If you set encodedFrameOnly to true in the previous step, the SDK triggers the OnEncodedVideoFrameReceived callback locally to report the received encoded video frame information.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="options"> The video subscription options. See VideoSubscriptionOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options);

        ///
        /// <summary>
        /// Sets video noise reduction.
        /// Underlit environments and low-end video capture devices can cause video images to contain significant noise, which affects video quality. In real-time interactive scenarios, video noise also consumes bitstream resources and reduces encoding efficiency during encoding.You can call this method to enable the video noise reduction feature and set the options of the video noise reduction effect.Call this method after calling EnableVideo .Video noise reduction has certain requirements for equipment performance. If your device overheats after you enable video noise reduction, Agora recommends modifying the video noise reduction options to a less performance-consuming level or disabling video noise reduction entirely.Both this method and SetExtensionProperty can turn on video noise reduction function:When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.This method relies on the video enhancement dynamic library libagora_clear_vision_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE .</param>
        ///
        /// <param name="enabled"> Whether to enable video noise reduction:true: Enable video noise reduction.false: (Default) Disable video noise reduction.</param>
        ///
        /// <param name="options"> The video noise reduction options. See VideoDenoiserOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);
        #endregion

        #region Capture screenshots
        ///
        /// <summary>
        /// Takes a snapshot of a video stream.
        /// This method takes a snapshot of a video stream from the specified user, generates a JPG image, and saves it to the specified path.The method is asynchronous, and the SDK has not taken the snapshot when the method call returns. After a successful method call, the SDK triggers the OnSnapshotTaken callback to report whether the snapshot is successfully taken, as well as the details for that snapshot.Call this method after joining a channel.This method takes a snapshot of the published video stream specified in ChannelMediaOptions .If the user's video has been preprocessed, for example, watermarked or beautified, the resulting snapshot includes the pre-processing effect.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. Set uid as 0 if you want to take a snapshot of the local user's video.</param>
        ///
        /// <param name="filePath"> The local path (including filename extensions) of the snapshot. For example:Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.jpgiOS: /App Sandbox/Library/Caches/example.jpgmacOS: ～/Library/Logs/example.jpgAndroid: /storage/emulated/0/Android/data/<package name>/files/example.jpgEnsure that the path you specify exists and is writable.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int TakeSnapshot(uint uid, string filePath);
        #endregion

        #region Multi-device capture

        ///
        /// <summary>
        /// Enables or disables multi-camera capture.
        /// In scenarios where there are existing cameras to capture video, Agora recommends that you use the following steps to capture and publish video with multiple cameras:Call this method to enable multi-channel camera capture.Call StartPreview [1/2] to start the local video preview.Call StartCameraCapture , and set sourceType to start video capture with the second camera.Call JoinChannelEx , and set publishSecondaryCameraTrack to true to publish the video stream captured by the second camera in the channel.If you want to disable multi-channel camera capture, use the following steps:Call StopCameraCapture .Call this method with enabled set to false.You can call this method before and after StartPreview [1/2] to enable multi-camera capture:If it is enabled before StartPreview [1/2], the local video preview shows the image captured by the two cameras at the same time.If it is enabled after StartPreview [1/2], the SDK stops the current camera capture first, and then enables the primary camera and the second camera. The local video preview appears black for a short time, and then automatically returns to normal.When using this function, ensure that the system version is 13.0 or later.The minimum iOS device types that support multi-camera capture are as follows:iPhone XRiPhone XSiPhone XS MaxiPad Pro 3rd generation and later
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable multi-camera video capture mode:true: Enable multi-camera capture mode; the SDK uses multiple cameras to capture video.false: Disable multi-camera capture mode; the SDK uses a single camera to capture video.</param>
        ///
        /// <param name="config"> Capture configuration for the second camera. See CameraCapturerConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config);

        ///
        /// <summary>
        /// Starts camera capture.
        /// You can call this method to start capturing video from one or more cameras by specifying sourceType.On the iOS platform, if you want to disable multi-camera capture, you need to call EnableMultiCamera and set enabled to true before calling this method.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE .On the mobile platforms, you can capture video from up to 2 cameras, provided the device has dual cameras or supports an external camera.On the desktop platforms, you can capture video from up to 4 cameras.</param>
        ///
        /// <param name="config"> The configuration of the video capture. See CameraCapturerConfiguration .On the iOS platform, this parameter has no practical function. Use the config parameter in EnableMultiCamera instead to set the video capture configuration.</param>
        ///
        public abstract int StartCameraCapture(VIDEO_SOURCE_TYPE sourceType, CameraCapturerConfiguration config);

        ///
        /// <summary>
        /// Stops camera capture.
        /// After calling StartCameraCapture to start capturing video through one or more cameras, you can call this method and set the sourceType parameter to stop the capture from the specified cameras.On the iOS platform, if you want to disable multi-camera capture, you need to call EnableMultiCamera after calling this method and set enabled to false.If you are using the local video mixing function, calling this method can cause the local video mixing to be interrupted.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopCameraCapture(VIDEO_SOURCE_TYPE sourceType);



        #endregion

        #region Media player
        ///
        /// <summary>
        /// Creates a media player instance.
        /// </summary>
        ///
        /// <returns>
        /// The IMediaPlayer instance, if the method call succeeds.An empty pointer, if the method call fails.
        /// </returns>
        ///
        public abstract IMediaPlayer CreateMediaPlayer();

        ///
        /// <summary>
        /// Destroys the media player instance.
        /// </summary>
        ///
        /// <param name="mediaPlayer"> One IMediaPlayer object.</param>
        ///
        /// <returns>
        /// ≥ 0: Success. Returns the ID of media player instance.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DestroyMediaPlayer(IMediaPlayer mediaPlayer);
        #endregion

        #region Audio pre-process and post-process
        ///
        /// <summary>
        /// Sets audio advanced options.
        /// If you have advanced audio processing requirements, such as capturing and sending stereo audio, you can call this method to set advanced audio options.Call this method after calling JoinChannel [2/2] , EnableAudio and EnableLocalAudio .
        /// </summary>
        ///
        /// <param name="options"> The advanced options for audio. See AdvancedAudioOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType = 0);
        #endregion

        #region Video pre-process and post-process
        ///
        /// <summary>
        /// Sets the image enhancement options.
        /// Enables or disables image enhancement, and sets the options.Call this method before calling EnableVideo or StartPreview [1/2] .This method relies on the video enhancement dynamic library libagora_clear_vision_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="type"> The type of the video source, see MEDIA_SOURCE_TYPE .</param>
        ///
        /// <param name="enabled"> Whether to enable the image enhancement function:true: Enable the image enhancement function.false: (Default) Disable the image enhancement function.</param>
        ///
        /// <param name="options"> The image enhancement options. See BeautyOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.ERR_NOT_SUPPORTED(4): The current device version is below Android 5.0, and this operation is not supported.
        /// </returns>
        ///
        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Enables/Disables the virtual background.
        /// The virtual background feature enables the local user to replace their original background with a static image, dynamic video, blurred background, or portrait-background segmentation to achieve picture-in-picture effect. Once the virtual background feature is enabled, all users in the channel can see the custom background.Call this method before calling EnableVideo or StartPreview [1/2] .This feature requires high performance devices. Agora recommends that you implement it on devices equipped with the following chips:Snapdragon 700 series 750G and laterSnapdragon 800 series 835 and laterDimensity 700 series 720 and laterKirin 800 series 810 and laterKirin 900 series 980 and laterDevices with an i5 CPU and betterDevices with an A9 chip and better, as follows:iPhone 6S and lateriPad Air 3rd generation and lateriPad 5th generation and lateriPad Pro 1st generation and lateriPad mini 5th generation and laterAgora recommends that you use this feature in scenarios that meet the following conditions:A high-definition camera device is used, and the environment is uniformly lit.There are few objects in the captured video. Portraits are half-length and unobstructed. Ensure that the background is a solid color that is different from the color of the user's clothing.This method relies on the virtual background dynamic library libagora_segmentation_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable virtual background:true: Enable virtual background.false: Disable virtual background.</param>
        ///
        /// <param name="backgroundSource"> The custom background. See VirtualBackgroundSource . To adapt the resolution of the custom background image to that of the video captured by the SDK, the SDK scales and crops the custom background image while ensuring that the content of the custom background image is not distorted.</param>
        ///
        /// <param name="segproperty"> Processing properties for background images. See SegmentationProperty .</param>
        ///
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE .In this method, this parameter supports only the following two settings:The default value is PRIMARY_CAMERA_SOURCE.If you want to use the second camera to capture video, set this parameter to SECONDARY_CAMERA_SOURCE.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: The custom background image does not exist. Check the value of source in VirtualBackgroundSource .-2: The color format of the custom background image is invalid. Check the value of color in VirtualBackgroundSource .-3: The device does not support virtual background.
        /// </returns>
        ///
        public abstract int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);


        #endregion

        #region Face detection
        ///
        /// <summary>
        /// Enables or disables face detection for the local user.
        /// You can call this method either before or after joining a channel.This method is for Android and iOS only.Once face detection is enabled, the SDK triggers the OnFacePositionChanged callback to report the face information of the local user, which includes the following:The width and height of the local video.The position of the human face in the local view.The distance between the human face and the screen.This method needs to be called after the camera is started (for example, by calling StartPreview [1/2]JoinChannel [2/2]).
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable face detection for the local user:true: Enable face detection.false: (Default) Disable face detection.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableFaceDetection(bool enabled);
        #endregion

        #region In-ear monitoring
        ///
        /// <summary>
        /// Enables in-ear monitoring.
        /// This method enables or disables in-ear monitoring.Users must use earphones (wired or Bluetooth) to hear the in-ear monitoring effect.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Enables or disables in-ear monitoring.true: Enables in-ear monitoring.false: (Default) Disables in-ear monitoring.</param>
        ///
        /// <param name="includeAudioFilters"> The audio filter of in-ear monitoring: See EAR_MONITORING_FILTER_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.- 8: Make sure the current audio routing is Bluetooth or headset.
        /// </returns>
        ///
        public abstract int EnableInEarMonitoring(bool enabled, int includeAudioFilters);

        ///
        /// <summary>
        /// Sets the volume of the in-ear monitor.
        /// This method applies to Android and iOS only.Users must use wired earphones to hear their own voices.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="volume"> The volume of the in-ear monitor. The value ranges between 0 and 100. The default value is 100.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetInEarMonitoringVolume(int volume);
        #endregion

        #region Music file playback and mixing
        ///
        /// <summary>
        /// Starts playing the music file.
        /// This method mixes the specified local or online audio file with the audio from the microphone, or replaces the microphone's audio with the specified local or remote audio file. A successful method call triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback. When the audio mixing file playback finishes, the SDK triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_STOPPED) callback on the local client.You can call this method either before or after joining a channel. If you need to call StartAudioMixing [1/2] multiple times, ensure that the time interval between calling this method is more than 500 ms.If the local music file does not exist, the SDK does not support the file format, or the the SDK cannot access the music file URL, the SDK reports 701.On Android, there are following considerations:To use this method, ensure that the Android device is v4.2 or later, and the API version is v16 or later.If you need to play an online music file, Agora does not recommend using the redirected URL address. Some Android devices may fail to open a redirected URL address.If you call this method on an emulator, ensure that the music file is in the /sdcard/ directory and the format is MP3.
        /// </summary>
        ///
        /// <param name="filePath"> If you have preloaded an audio effect into memory by calling PreloadEffect , ensure that the value of this parameter is the same as that of filePath in PreloadEffect.</param>
        ///
        /// <param name="loopback"> Whether to only play music files on the local client:true: Only play music files on the local client so that only the local user can hear the music.false: Publish music files to remote clients so that both the local user and remote users can hear the music.</param>
        ///
        /// <param name="cycle"> The number of times the music file plays.≥ 0: The number of playback times. For example, 0 means that the SDK does not play the music file while 1 means that the SDK plays once.-1: Play the audio file in an infinite loop.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle);

        ///
        /// <summary>
        /// Starts playing the music file.
        /// This method mixes the specified local or online audio file with the audio from the microphone, or replaces the microphone's audio with the specified local or remote audio file. A successful method call triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback. When the audio mixing file playback finishes, the SDK triggers the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_STOPPED) callback on the local client.On Android, there are following considerations:
        /// To use this method, ensure that the Android device is v4.2 or later, and the API version is v16 or later.
        /// If you need to play an online music file, Agora does not recommend using the redirected URL address. Some Android devices may fail to open a redirected URL address.
        /// If you call this method on an emulator, ensure that the music file is in the /sdcard/ directory and the format is MP3. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.
        /// You can call this method either before or after joining a channel. If you need to call StartAudioMixing [2/2] multiple times, ensure that the time interval between calling this method is more than 500 ms.If the local music file does not exist, the SDK does not support the file format, or the the SDK cannot access the music file URL, the SDK reports 701.
        /// </summary>
        ///
        /// <param name="filePath"> File path:
        ///  Android: The file path, which needs to be accurate to the file name and suffix. Agora supports URL addresses, absolute paths, or file paths that start with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example: content://com.android.providers.media.documents/document/audio%3A14441
        ///  Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4.
        ///  iOS or macOS: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: /var/mobile/Containers/Data/audio.mp4.</param>
        ///
        /// <param name="loopback"> Whether to only play music files on the local client:true: Only play music files on the local client so that only the local user can hear the music.false: Publish music files to remote clients so that both the local user and remote users can hear the music.</param>
        ///
        /// <param name="cycle"> The number of times the music file plays.≥ 0: The number of playback times. For example, 0 means that the SDK does not play the music file while 1 means that the SDK plays once.-1: Play the audio file in an infinite loop.</param>
        ///
        /// <param name="startPos"> The playback position (ms) of the music file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-3: The SDK is not ready.The audio module is disabled.The program is not complete.The initialization of IRtcEngine fails. Reinitialize the IRtcEngine.
        /// </returns>
        ///
        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos);

        ///
        /// <summary>
        /// Sets the channel mode of the current audio file.
        /// In a stereo music file, the left and right channels can store different audio data. According to your needs, you can set the channel mode to original mode, left channel mode, right channel mode, or mixed channel mode. For example, in the KTV scenario, the left channel of the music file stores the musical accompaniment, and the right channel stores the singing voice. If you only need to listen to the accompaniment, call this method to set the channel mode of the music file to left channel mode; if you need to listen to the accompaniment and the singing voice at the same time, call this method to set the channel mode to mixed channel mode.Call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.This method only applies to stereo audio files.
        /// </summary>
        ///
        /// <param name="mode"> The channel mode. See AUDIO_MIXING_DUAL_MONO_MODE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode);

        ///
        /// <summary>
        /// Stops playing and mixing the music file.
        /// This method stops the audio mixing. Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopAudioMixing();

        ///
        /// <summary>
        /// Pauses playing and mixing the music file.
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAudioMixing();

        ///
        /// <summary>
        /// Resumes playing and mixing the music file.
        /// This method resumes playing and mixing the music file. Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeAudioMixing();

        ///
        /// <summary>
        /// Adjusts the volume during audio mixing.
        /// This method adjusts the audio mixing volume on both the local client and remote clients.Call this method after StartAudioMixing [2/2] .
        /// </summary>
        ///
        /// <param name="volume"> Audio mixing volume. The value ranges between 0 and 100. The default value is 100, which means the original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustAudioMixingVolume(int volume);

        ///
        /// <summary>
        /// Adjusts the volume of audio mixing for publishing.
        /// This method adjusts the volume of audio mixing for publishing (sending to other users).Call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="volume"> The volume of audio mixing for local playback. The value ranges between 0 and 100 (default). 100 represents the original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustAudioMixingPublishVolume(int volume);

        ///
        /// <summary>
        /// Retrieves the audio mixing volume for publishing.
        /// This method helps troubleshoot audio volume‑related issues.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The audio mixing volume, if this method call succeeds. The value range is [0,100].&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingPublishVolume();

        ///
        /// <summary>
        /// Adjusts the volume of audio mixing for local playback.
        /// Call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="volume"> The volume of audio mixing for local playback. The value ranges between 0 and 100 (default). 100 represents the original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustAudioMixingPlayoutVolume(int volume);

        ///
        /// <summary>
        /// Retrieves the audio mixing volume for local playback.
        /// This method helps troubleshoot audio volume‑related issues.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The audio mixing volume, if this method call succeeds. The value range is [0,100].&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingPlayoutVolume();

        ///
        /// <summary>
        /// Retrieves the duration (ms) of the music file.
        /// Retrieves the total duration (ms) of the audio.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The audio mixing duration, if this method call succeeds.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingDuration();

        ///
        /// <summary>
        /// Retrieves the playback position (ms) of the music file.
        /// Retrieves the playback position (ms) of the audio.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.If you need to call GetAudioMixingCurrentPosition multiple times, ensure that the time interval between calling this method is more than 500 ms.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The current playback position (ms) of the audio mixing, if this method call succeeds. 0 represents that the current music file does not start playing.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingCurrentPosition();

        ///
        /// <summary>
        /// Sets the audio mixing position.
        /// Call this method to set the playback position of the music file to a different starting position (the default plays from the beginning).You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="pos"> Integer. The playback position (ms).</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioMixingPosition(int pos);

        ///
        /// <summary>
        /// Sets the pitch of the local music file.
        /// When a local music file is mixed with a local human voice, call this method to set the pitch of the local music file only.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="pitch"> Sets the pitch of the local music file by the chromatic scale. The default value is 0, which means keeping the original pitch. The value ranges from -12 to 12, and the pitch value between consecutive values is a chromatic value. The greater the absolute value of this parameter, the higher or lower the pitch of the local music file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioMixingPitch(int pitch);
        #endregion

        #region Audio effect file playback
        ///
        /// <summary>
        /// Retrieves the volume of the audio effects.
        /// The volume is an integer ranging from 0 to 100. The default value is 100, which means the original volume.Call this method after PlayEffect .
        /// </summary>
        ///
        /// <returns>
        /// Volume of the audio effects, if this method call succeeds.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetEffectsVolume();

        ///
        /// <summary>
        /// Sets the volume of the audio effects.
        /// Call this method after PlayEffect .
        /// </summary>
        ///
        /// <param name="volume"> The playback volume. The value range is [0, 100]. The default value is 100, which represents the original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEffectsVolume(int volume);

        ///
        /// <summary>
        /// Preloads a specified audio effect file into the memory.
        /// To ensure smooth communication, It is recommended that you limit the size of the audio effect file. You can call this method to preload the audio effect before calling JoinChannel [2/2].This method does not support online audio effect files.For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
        ///
        /// <param name="filePath"> File path:Android: The file path, which needs to be accurate to the file name and suffix. Agora supports URL addresses, absolute paths, or file paths that start with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example: content://com.android.providers.media.documents/document/audio%3A14441Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4.iOS or macOS: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: /var/mobile/Containers/Data/audio.mp4.</param>
        ///
        /// <param name="startPos"> The playback position (ms) of the audio effect file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PreloadEffect(int soundId, string filePath, int startPos = 0);

        ///
        /// <summary>
        /// Plays the specified local or online audio effect file.
        /// If you use this method to play an online audio effect file, Agora recommends that you cache the online audio effect file to your local device, call PreloadEffect to preload the cached audio effect file into memory, and then call this method to play the audio effect. Otherwise, you might encounter playback failures or no sound during playback due to loading timeouts or failures.To play multiple audio effect files at the same time, call this method multiple times with different soundId and filePath. To achieve the optimal user experience, Agora recommends that do not playing more than three audio files at the same time. After the playback of an audio effect file completes, the SDK triggers the OnAudioEffectFinished callback.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.If you have preloaded an audio effect into memory by calling PreloadEffect , ensure that the value of this parameter is the same as that of soundId in PreloadEffect.</param>
        ///
        /// <param name="filePath"> The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example, C:\music\audio.mp4. Supported audio formats include MP3, AAC, M4A, MP4, WAV, and 3GP. See supported audio formats.If you have preloaded an audio effect into memory by calling PreloadEffect , ensure that the value of this parameter is the same as that of filePath in PreloadEffect.</param>
        ///
        /// <param name="loopCount"> The number of times the audio effect loops.≥ 0: The number of playback times. For example, 1 means looping one time, which means playing the audio effect two times in total.-1: Play the audio file in an infinite loop.</param>
        ///
        /// <param name="pitch"> The pitch of the audio effect. The value range is 0.5 to 2.0. The default value is 1.0, which means the original pitch. The lower the value, the lower the pitch.</param>
        ///
        /// <param name="pan"> The spatial position of the audio effect. The value ranges between -1.0 and 1.0:-1.0: The audio effect is heard on the left of the user.0.0: The audio effect is heard in front of the user.1.0: The audio effect is heard on the right of the user.</param>
        ///
        /// <param name="gain"> The volume of the audio effect. The value range is 0.0 to 100.0. The default value is 100.0, which means the original volume. The smaller the value, the lower the volume.</param>
        ///
        /// <param name="publish"> Whether to publish the audio effect to the remote users:true: Publish the audio effect to the remote users. Both the local user and remote users can hear the audio effect.false: Do not publish the audio effect to the remote users. Only the local user can hear the audio effect.</param>
        ///
        /// <param name="startPos"> The playback position (ms) of the audio effect file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0);

        ///
        /// <summary>
        /// Plays all audio effect files.
        /// After calling PreloadEffect multiple times to preload multiple audio effects into the memory, you can call this method to play all the specified audio effects for all users in the channel.
        /// </summary>
        ///
        /// <param name="loopCount"> The number of times the audio effect loops:-1: Play the audio effect files in an indefinite loop until you call StopEffect or StopAllEffects .0: Play the audio effect once.1: Play the audio effect twice.</param>
        ///
        /// <param name="pitch"> The pitch of the audio effect. The value ranges between 0.5 and 2.0. The default value is 1.0 (original pitch). The lower the value, the lower the pitch.</param>
        ///
        /// <param name="pan"> The spatial position of the audio effect. The value ranges between -1.0 and 1.0:-1.0: The audio effect shows on the left.0: The audio effect shows ahead.1.0: The audio effect shows on the right.</param>
        ///
        /// <param name="gain"> The volume of the audio effect. The value range is [0, 100]. The default value is 100 (original volume). The smaller the value, the lower the volume.</param>
        ///
        /// <param name="publish"> Whether to publish the audio effect to the remote users:true: Publish the audio effect to the remote users. Both the local user and remote users can hear the audio effect.false: (Default) Do not publish the audio effect to the remote users. Only the local user can hear the audio effect.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false);

        ///
        /// <summary>
        /// Gets the volume of a specified audio effect file.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect file.</param>
        ///
        /// <returns>
        /// ≥ 0: Returns the volume of the specified audio effect, if the method call is successful. The value ranges between 0 and 100. 100 represents the original volume. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetVolumeOfEffect(int soundId);

        ///
        /// <summary>
        /// Sets the volume of a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect. The ID of each audio effect file is unique.</param>
        ///
        /// <param name="volume"> The playback volume. The value range is [0, 100]. The default value is 100, which represents the original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVolumeOfEffect(int soundId, int volume);

        ///
        /// <summary>
        /// Pauses a specified audio effect file.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseEffect(int soundId);

        ///
        /// <summary>
        /// Pauses all audio effects.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAllEffects();

        ///
        /// <summary>
        /// Resumes playing a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeEffect(int soundId);

        ///
        /// <summary>
        /// Resumes playing all audio effect files.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeAllEffects();

        ///
        /// <summary>
        /// Stops playing a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect. Each audio effect has a unique ID.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopEffect(int soundId);

        ///
        /// <summary>
        /// Stops playing all audio effects.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopAllEffects();

        ///
        /// <summary>
        /// Releases a specified preloaded audio effect from the memory.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect. Each audio effect has a unique ID.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnloadEffect(int soundId);

        ///
        /// <summary>
        /// Releases a specified preloaded audio effect from the memory.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnloadAllEffects();

        ///
        /// <summary>
        /// Retrieves the playback position of the audio effect file.
        /// Call this method after the PlayEffect method.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
        ///
        /// <returns>
        /// The playback position (ms) of the specified audio effect file, if the method call succeeds.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetEffectCurrentPosition(int soundId);

        ///
        /// <summary>
        /// Retrieves the duration of the audio effect file.
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="filePath"> File path:
        ///  Android: The file path, which needs to be accurate to the file name and suffix. Agora supports URL addresses, absolute paths, or file paths that start with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example: content://com.android.providers.media.documents/document/audio%3A14441
        ///  Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4.
        ///  iOS or macOS: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: /var/mobile/Containers/Data/audio.mp4.</param>
        ///
        /// <returns>
        /// The total duration (ms) of the specified audio effect file, if the method call succeeds.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetEffectDuration(string filePath);

        ///
        /// <summary>
        /// Sets the playback position of an audio effect file.
        /// After a successful setting, the local audio effect file starts playing at the specified position.Call this method after playEffect.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
        ///
        /// <param name="pos"> The playback position (ms) of the audio effect file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEffectPosition(int soundId, int pos);

        #endregion

        #region Virtual metronome
        ///
        /// <summary>
        /// Enables the virtual metronome.
        /// In music education, physical education and other scenarios, teachers usually need to use a metronome so that students can practice with the correct beat. The meter is composed of a downbeat and upbeats. The first beat of each measure is called a downbeat, and the rest are called upbeats.In this method, you need to set the file path of the upbeat and downbeat, the number of beats per measure, the beat speed, and whether to send the sound of the metronome to remote users.After successfully calling this method, the SDK triggers the OnRhythmPlayerStateChanged callback locally to report the status of the virtual metronome.This method is for Android and iOS only.After enabling the virtual metronome, the SDK plays the specified audio effect file from the beginning, and controls the playback duration of each file according to beatsPerMinute you set in AgoraRhythmPlayerConfig . For example, if you set beatsPerMinute as 60, the SDK plays one beat every second. If the file duration exceeds the beat duration, the SDK only plays the audio within the beat duration.By default, the sound of the virtual metronome is published in the channel. If you do not want the sound to be heard by the remote users, you can set publishRhythmPlayerTrack in ChannelMediaOptions as false.
        /// </summary>
        ///
        /// <param name="sound1"> The absolute path or URL address (including the filename extensions) of the file for the downbeat. For example, C:\music\audio.mp4. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.</param>
        ///
        /// <param name="sound2"> The absolute path or URL address (including the filename extensions) of the file for the upbeats. For example, C:\music\audio.mp4. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.</param>
        ///
        /// <param name="config"> The metronome configuration. See AgoraRhythmPlayerConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-22: Cannot find audio effect files. Please set the correct paths for sound1 and sound2.
        /// </returns>
        ///
        public abstract int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config);

        ///
        /// <summary>
        /// Disables the virtual metronome.
        /// After calling StartRhythmPlayer , you can call this method to disable the virtual metronome.This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopRhythmPlayer();

        ///
        /// <summary>
        /// Configures the virtual metronome.
        /// This method is for Android and iOS only.After enabling the virtual metronome, the SDK plays the specified audio effect file from the beginning, and controls the playback duration of each file according to beatsPerMinute you set in AgoraRhythmPlayerConfig . For example, if you set beatsPerMinute as 60, the SDK plays one beat every second. If the file duration exceeds the beat duration, the SDK only plays the audio within the beat duration.By default, the sound of the virtual metronome is published in the channel. If you do not want the sound to be heard by the remote users, you can set publishRhythmPlayerTrack in ChannelMediaOptions as false.After calling StartRhythmPlayer , you can call this method to reconfigure the virtual metronome.After successfully calling this method, the SDK triggers the OnRhythmPlayerStateChanged callback locally to report the status of the virtual metronome.
        /// </summary>
        ///
        /// <param name="config"> The metronome configuration. See AgoraRhythmPlayerConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config);
        #endregion

        #region Voice changer and reverberation
        ///
        /// <summary>
        /// Sets a preset voice beautifier effect.
        /// Call this method to set a preset voice beautifier effect for the local user who sends an audio stream. After setting a voice beautifier effect, all users in the channel can hear the effect. You can set different voice beautifier effects for different scenarios. For better voice effects, Agora recommends that you call SetAudioProfile [1/2] and set scenario to AUDIO_SCENARIO_GAME_STREAMING(3) and profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before calling this method.You can call this method either before or after joining a channel.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1)This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.After calling SetVoiceBeautifierPreset, Agora does not recommend calling the following methods, otherwise the effect set by SetVoiceBeautifierPreset will be overwritten: SetAudioEffectPreset SetAudioEffectParameters SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset This method relies on the voice beautifier dynamic library libagora_audio_beauty_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="preset"> The preset voice beautifier effect options: VOICE_BEAUTIFIER_PRESET .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset);

        ///
        /// <summary>
        /// Sets an SDK preset audio effect.
        /// Call this method to set an SDK preset audio effect for the local user who sends an audio stream. This audio effect does not change the gender characteristics of the original voice. After setting an audio effect, all users in the channel can hear the effect.To get better audio effect quality, Agora recommends setting the scenario parameter of SetAudioProfile [1/2] as AUDIO_SCENARIO_GAME_STREAMING(3) before calling this method.You can call this method either before or after joining a channel.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1), or the method does not take effect.This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.If you call SetAudioEffectPreset and set enumerators except for ROOM_ACOUSTICS_3D_VOICE or PITCH_CORRECTION, do not call SetAudioEffectParameters ; otherwise, SetAudioEffectPreset is overridden.After calling SetAudioEffectPreset, Agora does not recommend you to call the following methods, otherwise the effect set by SetAudioEffectPreset will be overwritten: SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset This method relies on the voice beautifier dynamic library libagora_audio_beauty_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="preset"> The options for SDK preset audio effects. See AUDIO_EFFECT_PRESET .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset);

        ///
        /// <summary>
        /// Sets a preset voice beautifier effect.
        /// Call this method to set a preset voice beautifier effect for the local user who sends an audio stream. After setting an audio effect, all users in the channel can hear the effect. You can set different voice beautifier effects for different scenarios. To achieve better audio effect quality, Agora recommends that you call SetAudioProfile [1/2] and set the profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) and scenario to AUDIO_SCENARIO_GAME_STREAMING(3) before calling this method.You can call this method either before or after joining a channel.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1)This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.After calling SetVoiceConversionPreset, Agora does not recommend you to call the following methods, otherwise the effect set by SetVoiceConversionPreset will be overwritten: SetAudioEffectPreset SetAudioEffectParameters SetVoiceBeautifierPreset SetVoiceBeautifierParameters SetLocalVoicePitch SetLocalVoiceFormant SetLocalVoiceEqualization SetLocalVoiceReverb This method relies on the voice beautifier dynamic library libagora_audio_beauty_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="preset"> The options for the preset voice beautifier effects: VOICE_CONVERSION_PRESET .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset);

        ///
        /// <summary>
        /// Sets parameters for SDK preset audio effects.
        /// Call this method to set the following parameters for the local user who sends an audio stream:3D voice effect: Sets the cycle period of the 3D voice effect.Pitch correction effect: Sets the basic mode and tonic pitch of the pitch correction effect. Different songs have different modes and tonic pitches. Agora recommends bounding this method with interface elements to enable users to adjust the pitch correction interactively.After setting the audio parameters, all users in the channel can hear the effect.You can call this method either before or after joining a channel.To get better audio effect quality, Agora recommends setting the scenario parameter of SetAudioProfile [1/2] as AUDIO_SCENARIO_GAME_STREAMING(3) before calling this method.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1), or the method does not take effect.This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.After calling SetAudioEffectParameters, Agora does not recommend you to call the following methods, otherwise the effect set by SetAudioEffectParameters will be overwritten: SetAudioEffectPreset SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset
        /// </summary>
        ///
        /// <param name="preset"> The options for SDK preset audio effects:ROOM_ACOUSTICS_3D_VOICE, 3D voice effect:Call SetAudioProfile [1/2] and set the profile parameter in to AUDIO_PROFILE_MUSIC_STANDARD_STEREO(3) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before setting this enumerator; otherwise, the enumerator setting does not take effect.If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect.PITCH_CORRECTION, Pitch correction effect: To achieve better audio effect quality, Agora recommends setting the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before setting this enumerator.</param>
        ///
        /// <param name="param1"> If you set preset to ROOM_ACOUSTICS_3D_VOICE, param1 sets the cycle period of the 3D voice effect. The value range is [1,60] and the unit is seconds. The default value is 10, indicating that the voice moves around you every 10 seconds.If you set preset to PITCH_CORRECTION, param1 indicates the basic mode of the pitch correction effect:1: (Default) Natural major scale.2: Natural minor scale.3: Japanese pentatonic scale.</param>
        ///
        /// <param name="param2"> If you set preset to ROOM_ACOUSTICS_3D_VOICE , you need to set param2 to 0.If you set preset to PITCH_CORRECTION, param2 indicates the tonic pitch of the pitch correction effect:1: A2: A#3: B4: (Default) C5: C#6: D7: D#8: E9: F10: F#11: G12: G#</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);

        ///
        /// <summary>
        /// Sets parameters for the preset voice beautifier effects.
        /// Call this method to set a gender characteristic and a reverberation effect for the singing beautifier effect. This method sets parameters for the local user who sends an audio stream. After setting the audio parameters, all users in the channel can hear the effect.For better voice effects, Agora recommends that you call SetAudioProfile [1/2] and set scenario to AUDIO_SCENARIO_GAME_STREAMING(3) and profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before calling this method.You can call this method either before or after joining a channel.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1) or AUDIO_PROFILE_IOT(6), or the method does not take effect.This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.After calling SetVoiceBeautifierParameters, Agora does not recommend calling the following methods, otherwise the effect set by SetVoiceBeautifierParameters will be overwritten: SetAudioEffectPreset SetAudioEffectParameters SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceConversionPreset
        /// </summary>
        ///
        /// <param name="preset"> The option for the preset audio effect:SINGING_BEAUTIFIER: The singing beautifier effect.</param>
        ///
        /// <param name="param1"> The gender characteristics options for the singing voice:1: A male-sounding voice.2: A female-sounding voice.</param>
        ///
        /// <param name="param2"> The reverberation effect options for the singing voice:1: The reverberation effect sounds like singing in a small room.2: The reverberation effect sounds like singing in a large room.3: The reverberation effect sounds like singing in a hall.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVoiceBeautifierParameters(VOICE_BEAUTIFIER_PRESET preset, int param1, int param2);

        ///
        /// @ignore
        ///
        public abstract int SetVoiceConversionParameters(VOICE_CONVERSION_PRESET preset, int param1, int param2);

        ///
        /// <summary>
        /// Changes the voice pitch of the local speaker.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="pitch"> The local voice pitch. The value range is [0.5,2.0]. The lower the value, the lower the pitch. The default value is 1.0 (no change to the pitch).</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoicePitch(double pitch);

        ///
        /// <summary>
        /// Set the formant ratio to change the timbre of human voice.
        /// Formant ratio affects the timbre of voice. The smaller the value, the deeper the sound will be, and the larger, the sharper.You can call this method to set the formant ratio of local audio to change the timbre of human voice. After you set the formant ratio, all users in the channel can hear the changed voice. If you want to change the timbre and pitch of voice at the same time, Agora recommends using this method together with SetLocalVoicePitch .You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="formantRatio"> The formant ratio. The value range is [-1.0, 1.0]. The default value is 0.0, which means do not change the timbre of the voice.Agora recommends setting this value within the range of [-0.4, 0.6]. Otherwise, the voice may be seriously distorted.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoiceFormant(double formantRatio);
        ///
        /// <summary>
        /// Sets the local voice equalization effect.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="bandFrequency"> The band frequency. The value ranges between 0 and 9; representing the respective 10-band center frequencies of the voice effects, including 31, 62, 125, 250, 500, 1k, 2k, 4k, 8k, and 16k Hz. See AUDIO_EQUALIZATION_BAND_FREQUENCY .</param>
        ///
        /// <param name="bandGain"> The gain of each band in dB. The value ranges between -15 and 15. The default value is 0.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);

        ///
        /// <summary>
        /// Sets the local voice reverberation.
        /// The SDK provides an easier-to-use method, SetAudioEffectPreset , to directly implement preset reverb effects for such as pop, R&B, and KTV.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="reverbKey"> The reverberation key. Agora provides five reverberation keys, see AUDIO_REVERB_TYPE .</param>
        ///
        /// <param name="value"> The value of the reverberation key.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);

        ///
        /// <summary>
        /// Sets the low- and high-frequency parameters of the headphone equalizer.
        /// In a spatial audio effect scenario, if the preset headphone equalization effect is not achieved after calling the SetHeadphoneEQPreset method, you can further adjust the headphone equalization effect by calling this method.
        /// </summary>
        ///
        /// <param name="lowGain"> The low-frequency parameters of the headphone equalizer. The value range is [-10,10]. The larger the value, the deeper the sound.</param>
        ///
        /// <param name="highGain"> The high-frequency parameters of the headphone equalizer. The value range is [-10,10]. The larger the value, the sharper the sound.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).
        /// </returns>
        ///
        public abstract int SetHeadphoneEQParameters(int lowGain, int highGain);

        ///
        /// <summary>
        /// Sets the preset headphone equalization effect.
        /// This method is mainly used in spatial audio effect scenarios. You can select the preset headphone equalizer to listen to the audio to achieve the expected audio experience.If the headphones you use already have a good equalization effect, you may not get a significant improvement when you call this method, and could even diminish the experience.
        /// </summary>
        ///
        /// <param name="preset"> The preset headphone equalization effect. See HEADPHONE_EQUALIZER_PRESET .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).
        /// </returns>
        ///
        public abstract int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset);
        #endregion

        #region Pre-call network test
        ///
        /// <summary>
        /// Starts an audio call test.
        /// Deprecated:This method is deprecated, use StartEchoTest [2/3] instead.This method starts an audio call test to determine whether the audio devices (for example, headset and speaker) and the network connection are working properly. To conduct the test, the user speaks, and the recording is played back within 10 seconds. If the user can hear the recording within the interval, the audio devices and network connection are working properly.Call this method before joining a channel.After calling StartEchoTest [1/3], you must call StopEchoTest to end the test. Otherwise, the app cannot perform the next echo test, and you cannot join the channel.In the live streaming channels, only a host can call this method.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartEchoTest();

        ///
        /// <summary>
        /// Starts an audio call test.
        /// Deprecated:This method is deprecated as of v4.0.1. Use StartEchoTest [3/3] instead.This method starts an audio call test to determine whether the audio devices (for example, headset and speaker) and the network connection are working properly. To conduct the test, let the user speak for a while, and the recording is played back within the set interval. If the user can hear the recording within the interval, the audio devices and network connection are working properly.Call this method before joining a channel.After calling StartEchoTest [2/3], you must call StopEchoTest to end the test. Otherwise, the app cannot perform the next echo test, and you cannot join the channel.In the live streaming channels, only a host can call this method.
        /// </summary>
        ///
        /// <param name="intervalInSeconds"> The time interval (s) between when you speak and when the recording plays back. The value range is [2, 10].</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartEchoTest(int intervalInSeconds);

        ///
        /// <summary>
        /// Starts an audio device loopback test.
        /// To test whether the user's local sending and receiving streams are normal, you can call this method to perform an audio and video call loop test, which tests whether the audio and video devices and the user's upstream and downstream networks are working properly.After starting the test, the user needs to make a sound or face the camera. The audio or video is output after about two seconds. If the audio playback is normal, the audio device and the user's upstream and downstream networks are working properly; if the video playback is normal, the video device and the user's upstream and downstream networks are working properly.You can call this method either before or after joining a channel.After calling this method, call StopEchoTest to end the test; otherwise, the user cannot perform the next audio and video call loop test and cannot join the channel.In live streaming scenarios, this method only applies to hosts.
        /// </summary>
        ///
        /// <param name="config"> The configuration of the audio and video call loop test. See EchoTestConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartEchoTest(EchoTestConfiguration config);

        ///
        /// <summary>
        /// Stops the audio call test.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.-5(ERR_REFUSED): Failed to stop the echo test. The echo test may not be running.
        /// </returns>
        ///
        public abstract int StopEchoTest();

        ///
        /// <summary>
        /// Starts the last mile network probe test.
        /// This method starts the last-mile network probe test before joining a channel to get the uplink and downlink last mile network statistics, including the bandwidth, packet loss, jitter, and round-trip time (RTT).Once this method is enabled, the SDK returns the following callbacks: OnLastmileQuality : The SDK triggers this callback within two seconds depending on the network conditions. This callback rates the network conditions and is more closely linked to the user experience. OnLastmileProbeResult : The SDK triggers this callback within 30 seconds depending on the network conditions. This callback returns the real-time statistics of the network conditions and is more objective.This method applies to the following scenarios:Before a user joins a channel, call this method to check the uplink network quality.In a live streaming channel, call this method to check the uplink network quality before an audience member switches to a host.Do not call other methods before receiving the OnLastmileQuality and OnLastmileProbeResult callbacks. Otherwise, the callbacks may be interrupted.A host should not call this method after joining a channel (when in a call).
        /// </summary>
        ///
        /// <param name="config"> The configurations of the last-mile network probe test. See LastmileProbeConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartLastmileProbeTest(LastmileProbeConfig config);

        ///
        /// <summary>
        /// Stops the last mile network probe test.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopLastmileProbeTest();


        ///
        /// <summary>
        /// Gets the type of the local network connection.
        /// You can use this method to get the type of network in use at any stage.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The method call is successful, and the local network connection type is returned.0: The SDK disconnects from the network.1: The network type is LAN.2: The network type is Wi-Fi (including hotspots).3: The network type is mobile 2G.4: The network type is mobile 3G.5: The network type is mobile 4G.6: The network type is mobile 5G.&lt; 0: The method call failed with an error code.-1: The network type is unknown.
        /// </returns>
        ///
        public abstract int GetNetworkType();
        #endregion

        #region Screen sharing
        ///
        /// <summary>
        /// Gets a list of shareable screens and windows.
        /// You can call this method before sharing a screen or window to get a list of shareable screens and windows, which enables a user to use thumbnails in the list to easily choose a particular screen or window to share. This list also contains important information such as window ID and screen ID, with which you can call StartScreenCaptureByWindowId or StartScreenCaptureByDisplayId to start the sharing.This method applies to macOS and Windows only.
        /// </summary>
        ///
        /// <param name="thumbSize"> The target size of the screen or window thumbnail (the width and height are in pixels). The SDK scales the original image to make the length of the longest side of the image the same as that of the target size without distorting the original image. For example, if the original image is 400 × 300 and thumbSize is 100 × 100, the actual size of the thumbnail is 100 × 75. If the target size is larger than the original size, the thumbnail is the original image and the SDK does not scale it.</param>
        ///
        /// <param name="iconSize"> The target size of the icon corresponding to the application program (the width and height are in pixels). The SDK scales the original image to make the length of the longest side of the image the same as that of the target size without distorting the original image. For example, if the original image is 400 × 300 and iconSize is 100 × 100, the actual size of the icon is 100 × 75. If the target size is larger than the original size, the icon is the original image and the SDK does not scale it.</param>
        ///
        /// <param name="includeScreen"> Whether the SDK returns the screen information in addition to the window information:true: The SDK returns screen and window information.false: The SDK returns window information only.</param>
        ///
        /// <returns>
        /// The ScreenCaptureSourceInfo array.
        /// </returns>
        ///
        public abstract ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen);

        ///
        /// <summary>
        /// Sets the screen sharing scenario.
        /// When you start screen sharing or window sharing, you can call this method to set the screen sharing scenario. The SDK adjusts the video quality and experience of the sharing according to the scenario.Agora recommends that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="screenScenario"> The screen sharing scenario. See SCREEN_SCENARIO_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario);


        ///
        /// <summary>
        /// Captures the screen by specifying the display ID.
        /// This method shares a screen or part of the screen.There are two ways to start screen sharing, you can choose one according to your needs:Call this method before joining a channel, and then call JoinChannel [2/2] to join a channel and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.Call this method after joining a channel, and then call UpdateChannelMediaOptions and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="displayId"> The display ID of the screen to be shared.</param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle .</param>
        ///
        /// <param name="captureParams"> Screen sharing configurations. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid.-8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        [Obsolete("his method is deprecated, `startScreenCaptureByDisplayId` or `startScreenCaptureByDisplayId` instead.")]
        ///
        /// <summary>
        /// Captures the whole or part of a screen by specifying the screen rect.
        /// There are two ways to start screen sharing, you can choose one according to your needs:Call this method before joining a channel, and then call JoinChannel [2/2] to join a channel and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.Call this method after joining a channel, and then call UpdateChannelMediaOptions and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.Deprecated:This method is deprecated. Use StartScreenCaptureByDisplayId instead. Agora strongly recommends using StartScreenCaptureByDisplayId if you need to start screen sharing on a device connected to another display.This method shares a screen or part of the screen. You need to specify the area of the screen to be shared.This method applies to Windows only.
        /// </summary>
        ///
        /// <param name="screenRect"> Sets the relative location of the screen to the virtual screen.</param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle . If the specified region overruns the screen, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen.</param>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video resolution is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid.-8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams);


        ///
        /// @ignore
        ///
        public abstract int StartScreenCapture(VIDEO_SOURCE_TYPE sourceType, ScreenCaptureConfiguration config);

        ///
        /// <summary>
        /// Stops screen capture.
        /// After calling StartScreenCapture [2/2] to start capturing video from one or more screens, you can call this method and set the sourceType parameter to stop capturing from the specified screens.This method applies to the macOS and Windows only.If you call StartScreenCapture [1/2] , StartScreenCaptureByWindowId , or StartScreenCaptureByDisplayId to start screen capure, Agora recommends that you call StopScreenCapture [1/2] instead to stop the capture.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopScreenCapture(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Starts screen capture.
        /// There are two ways to start screen sharing, you can choose one according to your needs:Call this method before joining a channel, then call JoinChannel [2/2] to join channel and set publishScreenCaptureVideo to true to start screen sharing.Call this method after joining a channel, then call UpdateChannelMediaOptions and set publishScreenCaptureVideo to true to start screen sharing.This method applies to Android and iOS only.On the iOS platform, screen sharing is only available on iOS 12.0 and later.The billing for the screen sharing stream is based on the dimensions in ScreenVideoParameters. When you do not pass in a value, Agora bills you at 1280 × 720; when you pass a value in, Agora bills you at that value. If you are using the custom audio source instead of the SDK to capture audio, Agora recommends you add the keep-alive processing logic to your application to avoid screen sharing stopping when the application goes to the background.This feature requires high-performance device, and Agora recommends that you use it on iPhone X and later models.This method relies on the iOS screen sharing dynamic library AgoraReplayKitExtension.xcframework. If the dynamic library is deleted, screen sharing cannot be enabled normally.On the Android platform, make sure the user has granted the app screen capture permission.On Android 9 and later, to avoid the application being killed by the system after going to the background, Agora recommends you add the foreground service android.permission.FOREGROUND_SERVICE to the /app/Manifests/AndroidManifest.xml file.Due to performance limitations, screen sharing is not supported on Android TV.Due to system limitations, if you are using Huawei phones, do not adjust the video encoding resolution of the screen sharing stream during the screen sharing, or you could experience crashes.Due to system limitations, some Xiaomi devices do not support capturing system audio during screen sharing.To avoid system audio capture failure when screen sharing, Agora recommends that you set the audio application scenario to AUDIO_SCENARIO_GAME_STREAMING by using the SetAudioScenario method before joining the channel.
        /// </summary>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters2 .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is null.
        /// </returns>
        ///
        public abstract int StartScreenCapture(ScreenCaptureParameters2 captureParams);

        ///
        /// <summary>
        /// Updates the screen capturing parameters.
        /// If the system audio is not captured when screen sharing is enabled, and then you want to update the parameter configuration and publish the system audio, you can refer to the following steps:Call this method, and set captureAudio to true.Call UpdateChannelMediaOptions , and set publishScreenCaptureAudio to true to publish the audio captured by the screen.This method applies to Android and iOS only.On the iOS platform, screen sharing is only available on iOS 12.0 and later.
        /// </summary>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video resolution is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters2 .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int UpdateScreenCapture(ScreenCaptureParameters2 captureParams);

        ///
        /// <summary>
        /// Queries the highest frame rate supported by the device during screen sharing.
        /// </summary>
        ///
        /// <returns>
        /// The highest frame rate supported by the device, if the method is called successfully. See SCREEN_CAPTURE_FRAMERATE_CAPABILITY .&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int QueryScreenCaptureCapability();
        ///
        /// <summary>
        /// Captures the whole or part of a window by specifying the window ID.
        /// There are two ways to start screen sharing, you can choose one according to your needs:Call this method before joining a channel, and then call JoinChannel [2/2] to join a channel and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.Call this method after joining a channel, and then call UpdateChannelMediaOptions and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.This method captures a window or part of the window. You need to specify the ID of the window to be captured.This method applies to the macOS and Windows only.The window sharing feature of the Agora SDK relies on WGC (Windows Graphics Capture) or GDI (Graphics Device Interface) capture, and WGC cannot be set to disable mouse capture on systems earlier than Windows 10 2004. Therefore, captureMouseCursor(false) might not work when you start window sharing on a device with a system earlier than Windows 10 2004. See ScreenCaptureParameters .This method supports window sharing of UWP (Universal Windows Platform) applications. Agora tests the mainstream UWP applications by using the lastest SDK, see details as follows:
        /// </summary>
        ///
        /// <param name="windowId"> The ID of the window to be shared.</param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle . If the specified region overruns the window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole window.</param>
        ///
        /// <param name="captureParams"> Screen sharing configurations. The default video resolution is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid.-8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Sets the content hint for screen sharing.
        /// A content hint suggests the type of the content being shared, so that the SDK applies different optimization algorithms to different types of content. If you don't call this method, the default content hint is CONTENT_HINT_NONE.You can call this method either before or after you start screen sharing.
        /// </summary>
        ///
        /// <param name="contentHint"> The content hint for screen sharing. See VIDEO_CONTENT_HINT .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid.-8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint);

        ///
        /// <summary>
        /// Updates the screen capturing region.
        /// Call this method after starting screen sharing or window sharing.
        /// </summary>
        ///
        /// <param name="regionRect"> The relative location of the screen-share area to the screen or window. If you do not set this parameter, the SDK shares the whole screen or window. See Rectangle . If the specified region overruns the screen or window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen or window.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid.-8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);

        ///
        /// <summary>
        /// Updates the screen capturing parameters.
        /// This method is for Windows and macOS only.Call this method after starting screen sharing or window sharing.
        /// </summary>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video resolution is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Stops screen capture.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopScreenCapture();
        #endregion

        #region Video dual stream
        ///
        /// <summary>
        /// Enables or disables dual-stream mode on the sender side.
        /// This method is applicable to all types of streams from the sender, including but not limited to video streams collected from cameras, screen sharing streams, and custom-collected video streams.If you need to enable dual video streams in a multi-channel scenario, you can call the EnableDualStreamModeEx method.You can call this method either before or after joining a channel.Deprecated:This method is deprecated as of v4.2.0. Use SetDualStreamMode [1/2] instead.Dual streams are a pairing of a high-quality video stream and a low-quality video stream:High-quality video stream: High bitrate, high resolution.Low-quality video stream: Low bitrate, low resolution.After you enable dual-stream mode, you can call SetRemoteVideoStreamType to choose to receive either the high-quality video stream or the low-quality video stream on the subscriber side.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode:true: Enable dual-stream mode.false: (Default) Disable dual-stream mode.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableDualStreamMode(bool enabled);



        ///
        /// <summary>
        /// Enables or disables the dual-stream mode on the sender and sets the low-quality video stream.
        /// Deprecated:This method is deprecated as of v4.2.0. Use SetDualStreamMode [2/2] instead.You can call this method to enable or disable the dual-stream mode on the publisher side. Dual streams are a pairing of a high-quality video stream and a low-quality video stream:High-quality video stream: High bitrate, high resolution.Low-quality video stream: Low bitrate, low resolution.After you enable dual-stream mode, you can call SetRemoteVideoStreamType to choose to receive either the high-quality video stream or the low-quality video stream on the subscriber side.This method is applicable to all types of streams from the sender, including but not limited to video streams collected from cameras, screen sharing streams, and custom-collected video streams.If you need to enable dual video streams in a multi-channel scenario, you can call the EnableDualStreamModeEx method.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode:true: Enable dual-stream mode.false: (Default) Disable dual-stream mode.</param>
        ///
        /// <param name="streamConfig"> The configuration of the low-quality video stream. See SimulcastStreamConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig);

        ///
        /// <summary>
        /// Sets the stream type of the remote video.
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using EnableDualStreamMode [2/2] (false), the receiver can choose to receive either the high-quality video stream or the low-quality video stream. The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate.By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream.The SDK enables the low-quality video stream auto mode on the sender by default (not actively sending low-quality video streams). The host at the receiving end can call this method to initiate a low-quality video stream stream request on the receiving end, and the sender automatically switches to the low-quality video stream mode after receiving the request.You can call this method either before or after joining a channel. If you call both SetRemoteVideoStreamType and SetRemoteDefaultVideoStreamType , the setting of SetRemoteVideoStreamType takes effect.
        /// </summary>
        ///
        /// <param name="uid"> The user ID.</param>
        ///
        /// <param name="streamType"> The video stream type: VIDEO_STREAM_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType);

        ///
        /// <summary>
        /// Sets the default stream type of subscrption for remote video streams.
        /// The SDK enables the low-quality video stream auto mode on the sender by default (not actively sending low-quality video streams). The host at the receiving end can call this method to initiate a low-quality video stream stream request on the receiving end, and the sender automatically switches to the low-quality video stream mode after receiving the request.
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using EnableDualStreamMode [2/2] (false), the receiver can choose to receive either the high-quality video stream or the low-quality video stream. The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate.By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream.Call this method before joining a channel. The SDK does not support changing the default subscribed video stream type after joining a channel.If you call both this method and SetRemoteVideoStreamType , the SDK applies the settings in the SetRemoteVideoStreamType method.
        /// </summary>
        ///
        /// <param name="streamType"> The default video-stream type. See VIDEO_STREAM_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType);

        ///
        /// <summary>
        /// Sets the dual-stream mode on the sender side.
        /// The SDK enables the low-quality video stream auto mode on the sender side by default (not actively sending low-quality video streams). The host at the receiving end can call SetRemoteVideoStreamType to initiate a low-quality video stream request on the receiving end, and the sender automatically switches to the low-quality video stream mode after receiving the request.If you want to modify this behavior, you can call this method and modify the mode to DISABLE_SIMULCAST_STREAM (never send low-quality video streams) or ENABLE_SIMULCAST_STREAM (always send low-quality video streams).If you want to restore the default behavior after making changes, you can call this method again with mode set to AUTO_SIMULCAST_STREAM.The difference and connection between this method and EnableDualStreamMode [1/2] is as follows:When calling this method and setting mode to DISABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamMode [1/2](false).When calling this method and setting mode to ENABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamMode [1/2](true).Both methods can be called before and after joining a channel. If both methods are used, the settings in the method called later takes precedence.
        /// </summary>
        ///
        /// <param name="mode"> The mode in which the video stream is sent. See SIMULCAST_STREAM_MODE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode);



        ///
        /// <summary>
        /// Sets dual-stream mode configuration on the sender, and sets the low-quality video stream.
        /// The difference and connection between this method and EnableDualStreamMode [1/2] is as follows:When calling this method and setting mode to DISABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamMode [1/2](false).When calling this method and setting mode to ENABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamMode [1/2](true).Both methods can be called before and after joining a channel. If both methods are used, the settings in the method called later takes precedence.The SDK enables the low-quality video stream auto mode on the sender by default, which is equivalent to calling this method and setting the mode to AUTO_SIMULCAST_STREAM. If you want to modify this behavior, you can call this method and modify the mode to DISABLE_SIMULCAST_STREAM (never send low-quality video streams) or ENABLE_SIMULCAST_STREAM (always send low-quality video streams).The difference between this method and SetDualStreamMode [1/2] is that this method can also configure the low-quality video stream, and the SDK sends the stream according to the configuration in streamConfig.
        /// </summary>
        ///
        /// <param name="mode"> The mode in which the video stream is sent. See SIMULCAST_STREAM_MODE .</param>
        ///
        /// <param name="streamConfig"> The configuration of the low-quality video stream. See SimulcastStreamConfig .When setting mode to DISABLE_SIMULCAST_STREAM, setting streamConfig will not take effect.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig);
        #endregion

        #region Watermark
        ///
        /// <summary>
        /// Adds a watermark image to the local video.
        /// Deprecated:This method is deprecated.
        /// Use AddVideoWatermark [2/2] instead.This method adds a PNG watermark image to the local video stream in a live streaming session. Once the watermark image is added, all the users in the channel (CDN audience included) and the video capturing device can see and capture it. If you only want to add a watermark to the CDN live streaming, see descriptions in .The URL descriptions are different for the local video and CDN live streaming: In a local video stream, URL refers to the absolute path of the added watermark image file in the local video stream. In a CDN live stream, URL refers to the URL address of the added watermark image in the CDN live streaming.The source file of the watermark image must be in the PNG file format. If the width and height of the PNG file differ from your settings in this method, the PNG file will be cropped to conform to your settings.The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one.
        /// </summary>
        ///
        /// <param name="watermark"> The watermark image to be added to the local live streaming: RtcImage .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AddVideoWatermark(RtcImage watermark);

        ///
        /// <summary>
        /// Adds a watermark image to the local video.
        /// This method adds a PNG watermark image to the local video in the live streaming. Once the watermark image is added, all the audience in the channel (CDN audience included), and the capturing device can see and capture it. The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one.The watermark coordinates are dependent on the settings in the SetVideoEncoderConfiguration method:If the orientation mode of the encoding video ( ORIENTATION_MODE ) is fixed landscape mode or the adaptive landscape mode, the watermark uses the landscape orientation.If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed portrait mode or the adaptive portrait mode, the watermark uses the portrait orientation.When setting the watermark position, the region must be less than the dimensions set in the SetVideoEncoderConfiguration method; otherwise, the watermark image will be cropped.Ensure that calling this method after EnableVideo .If you only want to add a watermark to the media push, you can call this method or the method.This method supports adding a watermark image in the PNG file format only. Supported pixel formats of the PNG image are RGBA, RGB, Palette, Gray, and Alpha_gray.If the dimensions of the PNG image differ from your settings in this method, the image will be cropped or zoomed to conform to your settings.If you have enabled the local video preview by calling the StartPreview [1/2] visibleInPreview member to set whether or not the watermark is visible in the preview.If you have enabled the mirror mode for the local video, the watermark on the local video is also mirrored. To avoid mirroring the watermark, Agora recommends that you do not use the mirror and watermark functions for the local video at the same time. You can implement the watermark function in your application layer.
        /// </summary>
        ///
        /// <param name="watermarkUrl"> The local file path of the watermark image to be added. This method supports adding a watermark image from the local absolute or relative file path.</param>
        ///
        /// <param name="options"> The options of the watermark image to be added. See WatermarkOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);


        ///
        /// <summary>
        /// Removes the watermark image from the video stream.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ClearVideoWatermarks();
        #endregion

        #region Encryption
        ///
        /// <summary>
        /// Sets the built-in encryption mode.
        /// Deprecated:Use EnableEncryption instead.The SDK supports built-in encryption schemes, AES-128-GCM is supported by default. Call this method to use other encryption modes. All users in the same channel must use the same encryption mode and secret. Refer to the information related to the AES encryption algorithm on the differences between the encryption modes.Before calling this method, please call SetEncryptionSecret to enable the built-in encryption function.
        /// </summary>
        ///
        /// <param name="encryptionMode"> The following encryption modes:"aes-128-xts": 128-bit AES encryption, XTS mode."aes-128-ecb": 128-bit AES encryption, ECB mode."aes-256-xts": 256-bit AES encryption, XTS mode."sm4-128-ecb": 128-bit SM4 encryption, ECB mode."aes-128-gcm": 128-bit AES encryption, GCM mode."aes-256-gcm": 256-bit AES encryption, GCM mode."": When this parameter is set as null, the encryption mode is set as "aes-128-gcm" by default.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEncryptionMode(string encryptionMode);

        ///
        /// <summary>
        /// Enables built-in encryption with an encryption password before users join a channel.
        /// Deprecated:Use EnableEncryption instead.Before joining the channel, you need to call this method to set the secret parameter to enable the built-in encryption. All users in the same channel should use the same secret. The secret is automatically cleared once a user leaves the channel. If you do not specify the secret or secret is set as null, the built-in encryption is disabled.Do not use this method for Media Push.For optimal transmission, ensure that the encrypted data size does not exceed the original data size + 16 bytes. 16 bytes is the maximum padding size for AES encryption.
        /// </summary>
        ///
        /// <param name="secret"> The encryption password.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEncryptionSecret(string secret);

        ///
        /// <summary>
        /// Enables or disables the built-in encryption.
        /// In scenarios requiring high security, Agora recommends calling this method to enable the built-in encryption before joining a channel.All users in the same channel must use the same encryption mode and encryption key. After the user leaves the channel, the SDK automatically disables the built-in encryption. To enable the built-in encryption, call this method before the user joins the channel again.If you enable the built-in encryption, you cannot use the Media Push function.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable built-in encryption:true: Enable the built-in encryption.false: Disable the built-in encryption.</param>
        ///
        /// <param name="config"> Built-in encryption configurations. See EncryptionConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: An invalid parameter is used. Set the parameter with a valid value.-4: The built-in encryption mode is incorrect or the SDK fails to load the external encryption library. Check the enumeration or reload the external encryption library.-7: The SDK is not initialized. Initialize the IRtcEngine instance before calling this method.
        /// </returns>
        ///
        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);
        #endregion

        #region Sound localization
        ///
        /// <summary>
        /// Enables or disables stereo panning for remote users.
        /// Ensure that you call this method before joining a channel to enable stereo panning for remote users so that the local user can track the position of a remote user by calling SetRemoteVoicePosition.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable stereo panning for remote users:true: Enable stereo panning.false: Disable stereo panning.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableSoundPositionIndication(bool enabled);
        #endregion

        #region Media push
        ///
        /// <summary>
        /// Starts the local video mixing.
        /// After calling this method, you can merge multiple video streams into one video stream locally. For example, you can merge the video streams captured by the camera, screen sharing, media player, remote video, video files, images, etc. into one video stream, and then publish the mixed video stream to the channel.Local video mixing requires more CPU resources. Therefore, Agora recommends enabling this function on devices with higher performance.If you need to mix locally captured video streams, the SDK supports the following capture combinations:On the Windows platform, it supports up to 4 video streams captured by cameras + 4 screen sharing streams.On the macOS platform, it supports up to 4 video streams captured by cameras + 1 screen sharing stream.On Android and iOS platforms, it supports video streams captured by up to 2 cameras (the device itself needs to support dual cameras or supports external cameras) + 1 screen sharing stream.If you need to mix the locally collected video streams, you need to call this method after StartCameraCapture or StartScreenCapture [2/2] If you want to publish the mixed video stream to the channel, you need to set publishTranscodedVideoTrack in ChannelMediaOptions to true when calling JoinChannel [2/2] or UpdateChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="config"> Configuration of the local video mixing, see LocalTranscoderConfiguration .The maximum resolution of each video stream participating in the local video mixing is 4096 × 2160. If this limit is exceeded, video mixing does not take effect.The maximum resolution of the mixed video stream is 4096 × 2160.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfiguration config);

        ///
        /// <summary>
        /// Updates the local video mixing configuration.
        /// After calling StartLocalVideoTranscoder , call this method if you want to update the local video mixing configuration.If you want to update the video source type used for local video mixing, such as adding a second camera or screen to capture video, you need to call this method after StartCameraCapture or StartScreenCapture [2/2]
        /// </summary>
        ///
        /// <param name="config"> Configuration of the local video mixing, see LocalTranscoderConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config);

        ///
        /// <summary>
        /// Stops the local video mixing.
        /// After calling StartLocalVideoTranscoder , call this method if you want to stop the local video mixing.
        /// </summary>
        ///
        public abstract int StopLocalVideoTranscoder();
        #endregion

        #region Channel media stream relay

        ///
        /// <summary>
        /// Starts relaying media streams across channels or updates channels for media relay.
        /// The first successful call to this method starts relaying media streams from the source channel to the destination channels. To relay the media stream to other channels, or exit one of the current media relays, you can call this method again to update the destination channels.After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback, and this callback returns the state of the media stream relay. Common states are as follows:If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), it means that the SDK starts relaying media streams from the source channel to the destination channel.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_FAILURE (3), an exception occurs during the media stream relay.Call this method after joining the channel.This method takes effect only when you are a host in a live streaming channel.The relaying media streams across channels function needs to be enabled by contacting .Agora does not support string user accounts in this API.
        /// </summary>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. See ChannelMediaRelayConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-7: The method call was rejected. It may be because the SDK has not been initialized successfully, or the user role is not an host.-8: Internal state error. Probably because the user is not an audience member.
        /// </returns>
        ///
        public abstract int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        [Obsolete("Use `startOrUpdateChannelMediaRelay` instead.")]
        ///
        /// <summary>
        /// Starts relaying media streams across channels. This method can be used to implement scenarios such as co-host across channels.
        /// Deprecated:This method is deprecated. Use StartOrUpdateChannelMediaRelay instead.After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged and OnChannelMediaRelayEvent callbacks, and these callbacks return the state and events of the media stream relay.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), and the OnChannelMediaRelayEvent callback returns RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4), it means that the SDK starts relaying media streams between the source channel and the target channel.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_FAILURE (3), an exception occurs during the media stream relay.Call this method after joining the channel.This method takes effect only when you are a host in a live streaming channel.After a successful method call, if you want to call this method again, ensure that you call the StopChannelMediaRelay method to quit the current relay.The relaying media streams across channels function needs to be enabled by contacting .Agora does not support string user accounts in this API.
        /// </summary>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. See ChannelMediaRelayConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-7: The method call was rejected. It may be because the SDK has not been initialized successfully, or the user role is not an host.-8: Internal state error. Probably because the user is not an audience member.
        /// </returns>
        ///
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        [Obsolete("Use `startOrUpdateChannelMediaRelay` instead.")]
        ///
        /// <summary>
        /// Updates the channels for media stream relay.
        /// Deprecated:This method is deprecated. Use StartOrUpdateChannelMediaRelay instead.After the media relay starts, if you want to relay the media stream to more channels, or leave the current relay channel, you can call this method.After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback with the RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL (7) state code.Call the method after successfully calling the StartChannelMediaRelay method and receiving OnChannelMediaRelayStateChanged (RELAY_STATE_RUNNING, RELAY_OK); otherwise, the method call fails.
        /// </summary>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. See ChannelMediaRelayConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);


        ///
        /// <summary>
        /// Stops the media stream relay. Once the relay stops, the host quits all the target channels.
        /// After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback. If the callback reports RELAY_STATE_IDLE (0) and RELAY_OK (0), the host successfully stops the relay.If the method call fails, the SDK triggers the OnChannelMediaRelayStateChanged callback with the RELAY_ERROR_SERVER_NO_RESPONSE (2) or RELAY_ERROR_SERVER_CONNECTION_LOST (8) status code. You can call the LeaveChannel [1/2]
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopChannelMediaRelay();

        ///
        /// <summary>
        /// Pauses the media stream relay to all target channels.
        /// After the cross-channel media stream relay starts, you can call this method to pause relaying media streams to all target channels; after the pause, if you want to resume the relay, call ResumeAllChannelMediaRelay .Call this method after StartOrUpdateChannelMediaRelay .
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAllChannelMediaRelay();

        ///
        /// <summary>
        /// Resumes the media stream relay to all target channels.
        /// After calling the PauseAllChannelMediaRelay method, you can call this method to resume relaying media streams to all destination channels.Call this method after PauseAllChannelMediaRelay .
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeAllChannelMediaRelay();
        #endregion

        #region Custom audio source
        ///
        /// <summary>
        /// Pushes the external audio frame.
        /// </summary>
        ///
        /// <param name="frame"> The external audio frame. See AudioFrame .</param>
        ///
        /// <param name="trackId"> The audio track ID. If you want to publish a custom external audio source, set this parameter to the ID of the corresponding custom audio track you want to publish.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PushAudioFrame(AudioFrame frame, uint trackId = 0);



        [Obsolete]
        ///
        /// <summary>
        /// Sets the external audio source parameters.
        /// Call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the external audio source:true: Enable the external audio source.false: (Default) Disable the external audio source.</param>
        ///
        /// <param name="sampleRate"> The sample rate (Hz) of the external audio source which can be set as 8000, 16000, 32000, 44100, or 48000.</param>
        ///
        /// <param name="channels"> The number of channels of the external audio source, which can be set as 1 (Mono) or 2 (Stereo).</param>
        ///
        /// <param name="sourceNumber"> The number of external audio sources. The value of this parameter should be larger than 0. The SDK creates a corresponding number of custom audio tracks based on this parameter value and names the audio tracks starting from 0. In ChannelMediaOptions , you can set publishCustomAudioSourceId to the audio track ID you want to publish.</param>
        ///
        /// <param name="localPlayback"> Whether to play the external audio source:true: Play the external audio source.false: (Default) Do not play the external source.</param>
        ///
        /// <param name="publish"> Whether to publish audio to the remote users:true: (Default) Publish audio to the remote users.false: Do not publish audio to the remote users.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels, bool localPlayback = false, bool publish = true);

        ///
        /// <summary>
        /// Creates a customized audio track.
        /// When you need to publish multiple custom captured audios in the channel, you can refer to the following steps:Call this method to create a custom audio track and get the audio track ID.In ChannelMediaOptions of each channel, set publishCustomAduioTrackId to the audio track ID that you want to publish, and set publishCustomAudioTrack to true.If you call PushAudioFrame trackId as the audio track ID set in step 2, you can publish the corresponding custom audio source in multiple channels.
        /// </summary>
        ///
        /// <param name="trackType"> The type of the custom audio track. See AUDIO_TRACK_TYPE .</param>
        ///
        /// <param name="config"> The configuration of the custom audio track. See AudioTrackConfig .</param>
        ///
        /// <returns>
        /// If the method call is successful, the audio track ID is returned as the unique identifier of the audio track.If the method call fails, a negative value is returned.
        /// </returns>
        ///
        public abstract uint CreateCustomAudioTrack(AUDIO_TRACK_TYPE trackType, AudioTrackConfig config);

        ///
        /// <summary>
        /// Destroys the specified audio track.
        /// </summary>
        ///
        /// <param name="trackId"> The custom audio track ID returned in CreateCustomAudioTrack .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DestroyCustomAudioTrack(uint trackId);

        ///
        /// <summary>
        /// Adjusts the volume of the custom external audio source when it is published in the channel.
        /// Ensure you have called the CreateCustomAudioTrack method to create an external audio track before calling this method.If you want to change the volume of the audio to be published, you need to call this method again.
        /// </summary>
        ///
        /// <param name="trackId"> The audio track ID. Set this parameter to the custom audio track ID returned in CreateCustomAudioTrack.</param>
        ///
        /// <param name="volume"> The volume of the audio source. The value can range from 0 to 100. 0 means mute; 100 means the original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustCustomAudioPublishVolume(uint trackId, int volume);

        ///
        /// @ignore
        ///
        public abstract int AdjustCustomAudioPlayoutVolume(uint trackId, int volume);
        #endregion

        #region Custom audio renderer
        ///
        /// <summary>
        /// Sets the external audio sink.
        /// This method applies to scenarios where you want to use external audio data for playback. After you set the external audio sink, you can call PullAudioFrame to pull remote audio frames. The app can process the remote audio and play it with the audio effects that you want.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable or disable the external audio sink:true: Enables the external audio sink.false: (Default) Disables the external audio sink.</param>
        ///
        /// <param name="sampleRate"> The sample rate (Hz) of the external audio sink, which can be set as 16000, 32000, 44100, or 48000.</param>
        ///
        /// <param name="channels"> The number of audio channels of the external audio sink:1: Mono.2: Stereo.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExternalAudioSink(bool enabled, int sampleRate, int channels);


        ///
        /// @ignore
        ///
        public abstract int EnableCustomAudioLocalPlayback(uint trackId, bool enabled);

        ///
        /// <summary>
        /// Pulls the remote audio data.
        /// Before calling this method, you need to call SetExternalAudioSink to notify the app to enable and set the external rendering.After a successful method call, the app pulls the decoded and mixed audio data for playback.This method only supports pulling data from custom audio source. If you need to pull the data captured by the SDK, do not call this method.Call this method after joining a channel.Once you enable the external audio sink, the app will not retrieve any audio data from the OnPlaybackAudioFrame callback.The difference between this method and the OnPlaybackAudioFrame callback is as follows:The SDK sends the audio data to the app through the OnPlaybackAudioFrame callback. Any delay in processing the audio frames may result in audio jitter.After a successful method call, the app automatically pulls the audio data from the SDK. After setting the audio data parameters, the SDK adjusts the frame buffer and avoids problems caused by jitter in the external audio playback.
        /// </summary>
        ///
        /// <param name="frame"> Pointers to AudioFrame .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PullAudioFrame(AudioFrame frame);
        #endregion

        #region Raw audio data
        ///
        /// <summary>
        /// Registers an audio frame observer object.
        /// Call this method to register an audio frame observer object (register a callback). When you need the SDK to trigger OnMixedAudioFrame , OnRecordAudioFrame , OnPlaybackAudioFrame or OnEarMonitoringAudioFrame callback, you need to use this method to register the callbacks.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="audioFrameObserver"> The observer object instance. See IAudioFrameObserver . Set the value as NULL to release the instance. Agora recommends calling this method after receiving OnLeaveChannel to release the audio observer object.</param>
        ///
        /// <param name="mode"> The video data callback mode. See OBSERVER_MODE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters an audio frame observer.
        /// </summary>
        ///
        public abstract int UnRegisterAudioFrameObserver();

        ///
        /// <summary>
        /// Sets the format of the captured raw audio data.
        /// Sets the audio format for the OnRecordAudioFrame callback.Ensure that you call this method before joining a channel.The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method.Sample interval (sec) = samplePerCall/(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnRecordAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate returned in the OnRecordAudioFrame callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.</param>
        ///
        /// <param name="channel"> The number of channels returned in the OnRecordAudioFrame callback:1: Mono.2: Stereo.</param>
        ///
        /// <param name="mode"> The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE .</param>
        ///
        /// <param name="samplesPerCall"> The number of data samples returned in the OnRecordAudioFrame callback, such as 1024 for the Media Push.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        ///
        /// <summary>
        /// Sets the audio data format for playback.
        /// Sets the data format for the OnPlaybackAudioFrame callback.Ensure that you call this method before joining a channel.The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method.Sample interval (sec) = samplePerCall/(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the callback according to the sampling interval.OnPlaybackAudioFrame
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate returned in the OnPlaybackAudioFrame callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.</param>
        ///
        /// <param name="channel"> The number of channels returned in the OnPlaybackAudioFrame callback:1: Mono.2: Stereo.</param>
        ///
        /// <param name="mode"> The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE .</param>
        ///
        /// <param name="samplesPerCall"> The number of data samples returned in the OnPlaybackAudioFrame callback, such as 1024 for the Media Push.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        ///
        /// <summary>
        /// Sets the audio data format reported by OnMixedAudioFrame .
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate (Hz) of the audio data, which can be set as 8000, 16000, 32000, 44100, or 48000.</param>
        ///
        /// <param name="channel"> The number of channels of the audio data, which can be set as 1(Mono) or 2(Stereo).</param>
        ///
        /// <param name="samplesPerCall"> Sets the number of samples. In Media Push scenarios, set it as 1024.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall);


        ///
        /// <summary>
        /// Sets the format of the in-ear monitoring raw audio data.
        /// This method is used to set the in-ear monitoring audio data format reported by the OnEarMonitoringAudioFrame callback.Before calling this method, you need to call EnableInEarMonitoring , and set includeAudioFilters to EAR_MONITORING_FILTER_BUILT_IN_AUDIO_FILTERS or EAR_MONITORING_FILTER_NOISE_SUPPRESSION.The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method.Sample interval (sec) = samplePerCall/(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnEarMonitoringAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate of the audio data reported in the OnEarMonitoringAudioFrame callback, which can be set as 8,000, 16,000, 32,000, 44,100, or 48,000 Hz.</param>
        ///
        /// <param name="channel"> The number of audio channels reported in the OnEarMonitoringAudioFrame callback.1: Mono.2: Stereo.</param>
        ///
        /// <param name="mode"> The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE .</param>
        ///
        /// <param name="samplesPerCall"> The number of data samples reported in the OnEarMonitoringAudioFrame callback, such as 1,024 for the Media Push.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);
        ///
        /// <summary>
        /// Sets the audio data format reported by OnPlaybackAudioFrameBeforeMixing .
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate (Hz) of the audio data, which can be set as 8000, 16000, 32000, 44100, or 48000.</param>
        ///
        /// <param name="channel"> The number of channels of the external audio source, which can be set as 1(Mono) or 2(Stereo).</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel);
        #endregion

        #region Encoded audio data
        ///
        /// <summary>
        /// Registers an encoded audio observer.
        /// Call this method after joining a channel.You can call this method or StartAudioRecording [3/3] to set the recording type and quality of audio files, but Agora does not recommend using this method and StartAudioRecording [3/3] at the same time. Only the method called later will take effect.
        /// </summary>
        ///
        /// <param name="config"> Observer settings for the encoded audio. See AudioEncodedFrameObserverConfig .</param>
        ///
        /// <param name="observer"> The encoded audio observer. See IAudioEncodedFrameObserver .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer);

        ///
        /// <summary>
        /// Unregisters the encoded audio frame observer.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnRegisterAudioEncodedFrameObserver();
        #endregion

        #region Audio spectrum
        ///
        /// <summary>
        /// Turns on audio spectrum monitoring.
        /// If you want to obtain the audio spectrum data of local or remote users, you can register the audio spectrum observer and enable audio spectrum monitoring.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="intervalInMS"> The interval (in milliseconds) at which the SDK triggers the OnLocalAudioSpectrum and OnRemoteAudioSpectrum callbacks. The default value is 100. Do not set this parameter to a value less than 10, otherwise calling this method would fail.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: Invalid parameters.
        /// </returns>
        ///
        public abstract int EnableAudioSpectrumMonitor(int intervalInMS = 100);

        ///
        /// <summary>
        /// Disables audio spectrum monitoring.
        /// After calling EnableAudioSpectrumMonitor , if you want to disable audio spectrum monitoring, you can call this method.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DisableAudioSpectrumMonitor();

        ///
        /// <summary>
        /// Register an audio spectrum observer.
        /// After successfully registering the audio spectrum observer and calling 
        /// EnableAudioSpectrumMonitor to enable the audio spectrum monitoring, the SDK reports the callback that you implement in the IAudioSpectrumObserver class according to the time interval you set.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="observer"> The audio spectrum observer. See IAudioSpectrumObserver .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        ///
        /// <summary>
        /// Unregisters the audio spectrum observer.
        /// After calling RegisterAudioSpectrumObserver , if you want to disable audio spectrum monitoring, you can call this method.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnregisterAudioSpectrumObserver();
        #endregion

        #region External video source
        ///
        /// <summary>
        /// Configures the external video source.
        /// Call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to use the external video source:true: Use the external video source. The SDK prepares to accept the external video frame.false: (Default) Do not use the external video source.</param>
        ///
        /// <param name="useTexture"> Whether to use the external video frame in the Texture format.true: Use the external video frame in the Texture format.false: (Default) Do not use the external video frame in the Texture format.</param>
        ///
        /// <param name="sourceType"> Whether the external video frame is encoded. See EXTERNAL_VIDEO_SOURCE_TYPE .</param>
        ///
        /// <param name="encodedVideoOption"> Video encoding options. This parameter needs to be set if sourceType is ENCODED_VIDEO_FRAME. To set this parameter, contact .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption);

        ///
        /// <summary>
        /// Pushes the external raw video frame to the SDK.
        /// If you call CreateCustomVideoTrack method to get the video track ID, set the customVideoTrackId parameter to the video track ID you want to publish in the ChannelMediaOptions of each channel, and set the publishCustomVideoTrack parameter to true, you can call this method to push the unencoded external video frame to the SDK.
        /// </summary>
        ///
        /// <param name="frame"> The external raw video frame to be pushed. See ExternalVideoFrame .</param>
        ///
        /// <param name="videoTrackId"> The video track ID returned by calling the CreateCustomVideoTrack method. The default value is 0.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0);

        ///
        /// @ignore
        ///
        public abstract int PushEncodedVideoImage(byte[] imageBuffer, uint length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0);

        ///
        /// @ignore
        ///
        public abstract video_track_id_t CreateCustomEncodedVideoTrack(SenderOptions sender_option);

        ///
        /// @ignore
        ///
        public abstract int DestroyCustomEncodedVideoTrack(video_track_id_t video_track_id);

        ///
        /// <summary>
        /// Creates a customized video track.
        /// When you need to publish multiple custom captured videos in the channel, you can refer to the following steps:Call this method to create a video track and get the video track ID.In each channel's ChannelMediaOptions , set the customVideoTrackId parameter to the ID of the video track you want to publish, and set publishCustomVideoTrack to true.If you call PushVideoFrame , and specify customVideoTrackId as the videoTrackId set in step 2, you can publish the corresponding custom video source in multiple channels.
        /// </summary>
        ///
        /// <returns>
        /// If the method call is successful, the video track ID is returned as the unique identifier of the video track.If the method call fails, a negative value is returned.
        /// </returns>
        ///
        public abstract video_track_id_t CreateCustomVideoTrack();

        ///
        /// <summary>
        /// Destroys the specified video track.
        /// </summary>
        ///
        /// <param name="video_track_id"> The video track ID returned by calling the CreateCustomVideoTrack method.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DestroyCustomVideoTrack(video_track_id_t video_track_id);

        #endregion

        #region Raw video data
        ///
        /// <summary>
        /// Registers a raw video frame observer object.
        /// If you want to obtain the original video data of some remote users (referred to as group A) and the encoded video data of other remote users (referred to as group B), you can refer to the following steps:
        /// Call RegisterVideoFrameObserver to register the raw video frame observer before joining the channel.
        /// Call RegisterVideoEncodedFrameObserver to register the encoded video frame observer before joining the channel.
        /// After joining the channel, get the user IDs of group B users through OnUserJoined , and then call SetRemoteVideoSubscriptionOptions to set the encodedFrameOnly of this group of users to true.
        /// Call MuteAllRemoteVideoStreams (false) to start receiving the video streams of all remote users. Then:
        /// The raw video data of group A users can be obtained through the callback in IVideoFrameObserver , and the SDK renders the data by default.
        /// The encoded video data of group B users can be obtained through the callback in IVideoEncodedFrameObserver . If you want to observe raw video frames (such as YUV or RGBA format), Agora recommends that you implement one IVideoFrameObserver class with this method.When calling this method to register a video observer, you can register callbacks in the IVideoFrameObserver class as needed. After you successfully register the video frame observer, the SDK triggers the registered callbacks each time a video frame is received.Ensure that you call this method before joining a channel.When handling the video data returned in the callbacks, pay attention to the changes in the width and height parameters, which may be adapted under the following circumstances:When network conditions deteriorate, the video resolution decreases incrementally.If the user adjusts the video profile, the resolution of the video returned in the callbacks also changes.After registering the raw video observer, you can use the obtained raw video data in various video pre-processing scenarios, such as implementing virtual backgrounds and image enhacement scenarios by yourself, Agora provides some open source sample projects on GitHub for your reference.
        /// </summary>
        ///
        /// <param name="videoFrameObserver"> The observer object instance. See IVideoFrameObserver . To release the instance, set the value as NULL.</param>
        ///
        /// <param name="mode"> The video data callback mode. See OBSERVER_MODE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters the video frame observer.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnRegisterVideoFrameObserver();

        ///
        /// <summary>
        /// Registers a receiver object for the encoded video image.
        /// If you only want to observe encoded video frames (such as h.264 format) without decoding and rendering the video, Agora recommends that you implement one IVideoEncodedFrameObserver class through this method.If you want to obtain the original video data of some remote users (referred to as group A) and the encoded video data of other remote users (referred to as group B), you can refer to the following steps:Call RegisterVideoFrameObserver to register the raw video frame observer before joining the channel.Call RegisterVideoEncodedFrameObserver to register the encoded video frame observer before joining the channel.After joining the channel, get the user IDs of group B users through OnUserJoined , and then call SetRemoteVideoSubscriptionOptions to set the encodedFrameOnly of this group of users to true.Call MuteAllRemoteVideoStreams (false) to start receiving the video streams of all remote users. Then:The raw video data of group A users can be obtained through the callback in IVideoFrameObserver , and the SDK renders the data by default.The encoded video data of group B users can be obtained through the callback in IVideoEncodedFrameObserver .Call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="videoEncodedImageReceiver"> The video frame observer object. See IVideoEncodedFrameObserver .</param>
        ///
        /// <param name="mode"> The video data callback mode. See OBSERVER_MODE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters a receiver object for the encoded video image.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnRegisterVideoEncodedFrameObserver();
        #endregion

        #region Extension
        ///
        /// <summary>
        /// Adds an extension to the SDK.
        /// (For Windows and Android only)
        /// </summary>
        ///
        /// <param name="path"> The extension library path and name. For example: /library/libagora_segmentation_extension.dll.</param>
        ///
        /// <param name="unload_after_use"> Whether to uninstall the current extension when you no longer using it:true: Uninstall the extension when the IRtcEngine is destroyed.false: (Rcommended) Do not uninstall the extension until the process terminates.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LoadExtensionProvider(string path, bool unload_after_use = false);

        ///
        /// <summary>
        /// Sets the properties of the extension provider.
        /// You can call this method to set the attributes of the extension provider and initialize the relevant parameters according to the type of the provider.Call this method after EnableExtension , and before enabling the audio ( EnableAudio / EnableLocalAudio ) or the video ( EnableVideo / EnableLocalVideo ).
        /// </summary>
        ///
        /// <param name="value"> The value of the extension key.</param>
        ///
        /// <param name="key"> The key of the extension.</param>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExtensionProviderProperty(string provider, string key, string value);
        ///
        /// <summary>
        /// Registers an extension.
        /// After the extension is loaded, you can call this method to register the extension.This method applies to Windows only.
        /// </summary>
        ///
        /// <param name="type"> Type of media source. See MEDIA_SOURCE_TYPE .In this method, this parameter supports only the following two settings:The default value is UNKNOWN_MEDIA_SOURCE.If you want to use the second camera to capture video, set this parameter to SECONDARY_CAMERA_SOURCE.</param>
        ///
        /// <param name="extension"> The name of the extension.</param>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);
        ///
        /// <summary>
        /// Enables or disables extensions.
        /// To call this method, call it immediately after initializing the IRtcEngine object.If you want to enable multiple extensions, you need to call this method multiple times.The data processing order of different extensions in the SDK is determined by the order in which the extensions are enabled. That is, the extension that is enabled first will process the data first.
        /// </summary>
        ///
        /// <param name="extension"> The name of the extension.</param>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <param name="enable"> Whether to enable the extension:true: Enable the extension.false: Disable the extension.</param>
        ///
        /// <param name="type"> Type of media source. See MEDIA_SOURCE_TYPE .In this method, this parameter supports only the following two settings:The default value is UNKNOWN_MEDIA_SOURCE.If you want to use the second camera to capture video, set this parameter to SECONDARY_CAMERA_SOURCE.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-3: The extension library is not loaded. Agora recommends that you check the storage location or the name of the dynamic library.
        /// </returns>
        ///
        public abstract int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);


        ///
        /// @ignore
        ///
        public abstract int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable = true);


        ///
        /// <summary>
        /// Sets the properties of the extension.
        /// After enabling the extension, you can call this method to set the properties of the extension.
        /// </summary>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <param name="extension"> The name of the extension.</param>
        ///
        /// <param name="key"> The key of the extension.</param>
        ///
        /// <param name="value"> The value of the extension key.</param>
        ///
        /// <param name="type"> The type of the video source, see MEDIA_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);


        ///
        /// @ignore
        ///
        public abstract int SetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, string value);


        ///
        /// <summary>
        /// Gets detailed information on the extensions.
        /// </summary>
        ///
        /// <param name="provider"> Output parameter. The name of the extension provider.</param>
        ///
        /// <param name="extension"> Output parameter. The name of the extension.</param>
        ///
        /// <param name="key"> Output parameter. The key of the extension.</param>
        ///
        /// <param name="value"> Output parameter. The value of the extension key.</param>
        ///
        /// <param name="type"> Source type of the extension. See MEDIA_SOURCE_TYPE .</param>
        ///
        /// <param name="buf_len"> Maximum length of the JSON string indicating the extension property. The maximum value is 512 bytes.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        ///
        /// @ignore
        ///
        public abstract int GetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, ref string value, int buf_len);

        #endregion

        #region Media metadata
        ///
        /// <summary>
        /// Registers the metadata observer.
        /// You need to implement the IMetadataObserver class and specify the metadata type in this method. This method enables you to add synchronized metadata in the video stream for more diversified
        /// live interactive streaming, such as sending shopping links, digital coupons, and online quizzes.A successful call of this method triggers the GetMaxMetadataSize callback.Call this method before JoinChannel [2/2].
        /// </summary>
        ///
        /// <param name="observer"> The metadata observer. See IMetadataObserver .</param>
        ///
        /// <param name="type"> The metadata type. The SDK currently only supports VIDEO_METADATA. See METADATA_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type);

        ///
        /// <summary>
        /// Unregisters the specified metadata observer.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnregisterMediaMetadataObserver();
        #endregion

        #region Audio recording
        ///
        /// <summary>
        /// Starts audio recording on the client.
        /// The sample rate of recording is 32 kHz by default and cannot be modified.The Agora SDK allows recording during a call. This method records the audio of all the users in the channel and generates an audio recording file. Supported formats of the recording file are as follows:.wav: Large file size with high fidelity..aac: Small file size with low fidelity.Ensure that the directory for the recording file exists and is writable. This method should be called after the JoinChannel [1/2] LeaveChannel [1/2]
        /// </summary>
        ///
        /// <param name="filePath"> The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.mp4.
        ///  Ensure that the directory for the log files exists and is writable.</param>
        ///
        /// <param name="quality"> Audio recording quality. See AUDIO_RECORDING_QUALITY_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality);

        ///
        /// <summary>
        /// Starts audio recording on the client and sets the sample rate of recording.
        /// The Agora SDK allows recording during a call. After successfully calling this method, you can record the audio of all the users in the channel and get an audio recording file. Supported formats of the recording file are as follows:.wav: Large file size with high fidelity..aac: Small file size with low fidelity.Ensure that the directory you use to save the recording file exists and is writable.This method should be called after the JoinChannel [2/2] method. The recording automatically stops when you call the LeaveChannel [1/2] For better recording effects, set quality to AUDIO_RECORDING_QUALITY_MEDIUM or AUDIO_RECORDING_QUALITY_HIGH when sampleRate is 44.1 kHz or 48 kHz.
        /// </summary>
        ///
        /// <param name="filePath"> The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.mp4.Ensure that the directory for the log files exists and is writable.</param>
        ///
        /// <param name="sampleRate"> The sample rate (kHz) of the recording file. Supported values are as follows:16000(Default) 320004410048000</param>
        ///
        /// <param name="quality"> Recording quality. See AUDIO_RECORDING_QUALITY_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        ///
        /// <summary>
        /// Starts audio recording on the client and sets recording configurations.
        /// The Agora SDK allows recording during a call. After successfully calling this method, you can record the audio of users in the channel and get an audio recording file. Supported formats of the recording file are as follows:WAV: High-fidelity files with typically larger file sizes. For example, if the sample rate is 32,000 Hz, the file size for 10-minute recording is approximately 73 MB.AAC: Low-fidelity files with typically smaller file sizes. For example, if the sample rate is 32,000 Hz and the recording quality is AUDIO_RECORDING_QUALITY_MEDIUM, the file size for 10-minute recording is approximately 2 MB.Once the user leaves the channel, the recording automatically stops.Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="config"> Recording configurations. See AudioFileRecordingConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioRecording(AudioRecordingConfiguration config);

        ///
        /// <summary>
        /// Stops the audio recording on the client.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopAudioRecording();
        #endregion

        #region Camera management
        ///
        /// <summary>
        /// Sets the camera capture configuration.
        /// This method is for Android and iOS only.Call this method before calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
        /// </summary>
        ///
        /// <param name="config"> The camera capture configuration. See CameraCapturerConfiguration .In this method, you do not need to set the deviceId parameter.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraCapturerConfiguration(CameraCapturerConfiguration config);

        ///
        /// <summary>
        /// Switches between front and rear cameras.
        /// This method needs to be called after the camera is started (for example, by calling StartPreview [1/2] JoinChannel [2/2] ).This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SwitchCamera();

        ///
        /// <summary>
        /// Checks whether the device supports camera zoom.
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true: The device supports camera zoom.false: The device does not support camera zoom.
        /// </returns>
        ///
        public abstract bool IsCameraZoomSupported();

        ///
        /// <summary>
        /// Checks whether the device camera supports face detection.
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true: The device camera supports face detection.false: The device camera does not support face detection.
        /// </returns>
        ///
        public abstract bool IsCameraFaceDetectSupported();

        ///
        /// <summary>
        /// Checks whether the device supports camera flash.
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.This method is for Android and iOS only.The app enables the front camera by default. If your front camera does not support enabling the flash, this method returns false. If you want to check whether the rear camera supports the flash function, call SwitchCamera before this method.On iPads with system version 15, even if IsCameraTorchSupported returns true, you might fail to successfully enable the flash by calling SetCameraTorchOn due to system issues.
        /// </summary>
        ///
        /// <returns>
        /// true: The device supports camera flash.false: The device does not support camera flash.
        /// </returns>
        ///
        public abstract bool IsCameraTorchSupported();

        ///
        /// <summary>
        /// Check whether the device supports the manual focus function.
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true: The device supports the manual focus function.false: The device does not support the manual focus function.
        /// </returns>
        ///
        public abstract bool IsCameraFocusSupported();

        ///
        /// <summary>
        /// Checks whether the device supports the face auto-focus function.
        /// This method is for Android and iOS only.Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
        /// </summary>
        ///
        /// <returns>
        /// true: The device supports the face auto-focus function.false: The device does not support the face auto-focus function.
        /// </returns>
        ///
        public abstract bool IsCameraAutoFocusFaceModeSupported();

        ///
        /// <summary>
        /// Sets the camera zoom ratio.
        /// This method is for Android and iOS only.Call this method before calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
        /// </summary>
        ///
        /// <param name="factor"> The camera zoom ratio. The value ranges between 1.0 and the maximum zoom supported by the device. You can get the maximum zoom ratio supported by the device by calling the GetCameraMaxZoomFactor method.</param>
        ///
        /// <returns>
        /// The camera zoom factor value, if successful.&lt; 0: if the method if failed.
        /// </returns>
        ///
        public abstract int SetCameraZoomFactor(float factor);

        ///
        /// <summary>
        /// Gets the maximum zoom ratio supported by the camera.
        /// This method is for Android and iOS only.Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
        /// </summary>
        ///
        /// <returns>
        /// The maximum zoom factor.
        /// </returns>
        ///
        public abstract float GetCameraMaxZoomFactor();

        ///
        /// <summary>
        /// Sets the camera manual focus position.
        /// This method needs to be called after the camera is started (for example, by calling StartPreview [1/2] JoinChannel [2/2] ). After a successful method call, the SDK triggers the OnCameraFocusAreaChanged callback.This method is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="positionX"> The horizontal coordinate of the touchpoint in the view.</param>
        ///
        /// <param name="positionY"> The vertical coordinate of the touchpoint in the view.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraFocusPositionInPreview(float positionX, float positionY);

        ///
        /// <summary>
        /// Enables the camera flash.
        /// This method is for Android and iOS only.Call this method before calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
        /// </summary>
        ///
        /// <param name="isOn"> Whether to turn on the camera flash:true: Turn on the flash.false: (Default) Turn off the flash.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraTorchOn(bool isOn);

        ///
        /// <summary>
        /// Enables the camera auto-face focus function.
        /// This method is for Android and iOS only.Call this method after the camera is started, such as after JoinChannel [2/2] , EnableVideo or EnableLocalVideo .
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable face autofocus:true: Enable the camera auto-face focus function.false: Disable face autofocus.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraAutoFocusFaceModeEnabled(bool enabled);

        ///
        /// <summary>
        /// Checks whether the device supports manual exposure.
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true: The device supports manual exposure.false: The device does not support manual exposure.
        /// </returns>
        ///
        public abstract bool IsCameraExposurePositionSupported();

        ///
        /// <summary>
        /// Sets the camera exposure position.
        /// This method needs to be called after the camera is started (for example, by calling StartPreview [1/2] JoinChannel [2/2] ).After a successful method call, the SDK triggers the OnCameraExposureAreaChanged callback.This method is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="positionXinView"> The horizontal coordinate of the touchpoint in the view.</param>
        ///
        /// <param name="positionYinView"> The vertical coordinate of the touchpoint in the view.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraExposurePosition(float positionXinView, float positionYinView);

        ///
        /// <summary>
        /// Checks whether the device supports auto exposure.
        /// This method applies to iOS only.Call this method before calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
        /// </summary>
        ///
        /// <returns>
        /// true: The device supports auto exposure.false: The device does not support auto exposure.
        /// </returns>
        ///
        public abstract bool IsCameraAutoExposureFaceModeSupported();

        ///
        /// <summary>
        /// Sets whether to enable auto exposure.
        /// This method applies to iOS only.Call this method before calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo , depending on which method you use to turn on your local camera.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable auto exposure:true: Enable auto exposure.false: Disable auto exposure.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraAutoExposureFaceModeEnabled(bool enabled);
        #endregion

        #region Audio route : This group of methods are for Android and iOS only.
        ///
        /// <summary>
        /// Sets the default audio playback route.
        /// This method applies to Android and iOS only.Ensure that you call this method before joining a channel. If you need to change the audio route after joining a channel, call SetEnableSpeakerphone .Most mobile phones have two audio routes: an earpiece at the top, and a speakerphone at the bottom. The earpiece plays at a lower volume, and the speakerphone at a higher volume. When setting the default audio route, you determine whether audio playback comes through the earpiece or speakerphone when no external audio device is connected.
        /// </summary>
        ///
        /// <param name="defaultToSpeaker"> Whether to set the speakerphone as the default audio route:true: Set the speakerphone as the default audio route.false: Set the earpiece as the default audio route.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker);

        ///
        /// <summary>
        /// Enables/Disables the audio route to the speakerphone.
        /// If the default audio route of the SDK (see Set the Audio Route) or the setting in SetDefaultAudioRouteToSpeakerphone cannot meet your requirements, you can call SetEnableSpeakerphone to switch the current audio route. After a successful method call, the SDK triggers the OnAudioRoutingChanged callback.This method only sets the audio route in the current channel and does not influence the default audio route. If the user leaves the current channel and joins another channel, the default audio route is used.This method applies to Android and iOS only.Call this method after joining a channel.If the user uses an external audio playback device such as a Bluetooth or wired headset, this method does not take effect, and the SDK plays audio through the external device. When the user uses multiple external devices, the SDK plays audio through the last connected device.
        /// </summary>
        ///
        /// <param name="speakerOn"> Sets whether to enable the speakerphone or earpiece:true: Enable device state monitoring. The audio route is the speakerphone.false: Disable device state monitoring. The audio route is the earpiece.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEnableSpeakerphone(bool speakerOn);

        ///
        /// <summary>
        /// Checks whether the speakerphone is enabled.
        /// This method is for Android and iOS only.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// true: The speakerphone is enabled, and the audio plays from the speakerphone.false: The speakerphone is not enabled, and the audio plays from devices other than the speakerphone. For example, the headset or earpiece.
        /// </returns>
        ///
        public abstract bool IsSpeakerphoneEnabled();
        #endregion

        #region Volume indication
        ///
        /// <summary>
        /// Enables the reporting of users' volume indication.
        /// This method enables the SDK to regularly report the volume information to the app of the local user who sends a stream and remote users (three users at most) whose instantaneous volumes are the highest. Once you call this method and users send streams in the channel, the SDK triggers the OnAudioVolumeIndication callback at the time interval set in this method.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="interval"> Sets the time interval between two consecutive volume indications:≤ 0: Disables the volume indication.> 0: Time interval (ms) between two consecutive volume indications. The lowest value is 50.</param>
        ///
        /// <param name="smooth"> The smoothing factor that sets the sensitivity of the audio volume indicator. The value ranges between 0 and 10. The recommended value is 3. The greater the value, the more sensitive the indicator.</param>
        ///
        /// <param name="reportVad"> true: Enables the voice activity detection of the local user. Once it is enabled, the vad parameter of the OnAudioVolumeIndication callback reports the voice activity status of the local user.false: (Default) Disables the voice activity detection of the local user. Once it is disabled, the vad parameter of the OnAudioVolumeIndication callback does not report the voice activity status of the local user, except for the scenario where the engine automatically detects the voice activity of the local user.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad);
        #endregion

        #region Data stream
        ///
        /// <summary>
        /// Creates a data stream.
        /// Each user can create up to five data streams during the lifecycle of IRtcEngine . The data stream will be destroyed when leaving the channel, and the data stream needs to be recreated if needed.Call this method after joining a channel.Agora does not support setting reliable as true and ordered as false.
        /// </summary>
        ///
        /// <param name="streamId"> An output parameter; the ID of the data stream created.</param>
        ///
        /// <param name="reliable"> Whether or not the data stream is reliable:true: The recipients receive the data from the sender within five seconds. If the recipient does not receive the data within five seconds, the SDK triggers the OnStreamMessageError callback and returns an error code.false: There is no guarantee that the recipients receive the data stream within five seconds and no error message is reported for any delay or missing data stream.</param>
        ///
        /// <param name="ordered"> Whether or not the recipients receive the data stream in the sent order: true: The recipients receive the data in the sent order.false: The recipients do not receive the data in the sent order.</param>
        ///
        /// <returns>
        /// 0: The data stream is successfully created.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int CreateDataStream(ref int streamId, bool reliable, bool ordered);

        ///
        /// <summary>
        /// Creates a data stream.
        /// Creates a data stream. Each user can create up to five data streams in a single channel.Compared with CreateDataStream [1/2] , this method does not support data reliability. If a data packet is not received five seconds after it was sent, the SDK directly discards the data.
        /// </summary>
        ///
        /// <param name="streamId"> An output parameter; the ID of the data stream created.</param>
        ///
        /// <param name="config"> The configurations for the data stream. See DataStreamConfig .</param>
        ///
        /// <returns>
        /// 0: The data stream is successfully created.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int CreateDataStream(ref int streamId, DataStreamConfig config);

        ///
        /// <summary>
        /// Sends data stream messages.
        /// Sends data stream messages to all users in a channel. The SDK has the following restrictions on this method:Up to 30 packets can be sent per second in a channel with each packet having a maximum size of 1 KB.Each client can send up to 6 KB of data per second.Each user can have up to five data streams simultaneously.A successful method call triggers the OnStreamMessage callback on the remote client, from which the remote user gets the stream message.
        /// A failed method call triggers the OnStreamMessageError callback on the remote client.Ensure that you call CreateDataStream [2/2] to create a data channel before calling this method.In live streaming scenarios, this method only applies to hosts.
        /// </summary>
        ///
        /// <param name="streamId"> The data stream ID. You can get the data stream ID by calling CreateDataStream [2/2].</param>
        ///
        /// <param name="data"> The message to be sent.</param>
        ///
        /// <param name="length"> The length of the data.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SendStreamMessage(int streamId, byte[] data, uint length);
        #endregion

        #region Miscellaneous audio control
        ///
        /// <summary>
        /// Enables loopback audio capturing.
        /// If you enable loopback audio capturing, the output of the sound card is mixed into the audio stream sent to the other end.This method applies to the macOS and Windows only.macOS does not support loopback audio capture of the default sound card. If you need to use this function, use a virtual sound card and pass its name to the deviceName parameter. Agora recommends using AgoraALD as the virtual sound card for audio capturing.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable loopback audio capturing.true: Enable loopback audio capturing.false: (Default) Disable loopback audio capturing.</param>
        ///
        /// <param name="deviceName"> macOS: The device name of the virtual sound card. The default value is set to NULL, which means using AgoraALD for loopback audio capturing.Windows: The device name of the sound card. The default is set to NULL, which means the SDK uses the sound card of your device for loopback audio capturing.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLoopbackRecording(bool enabled, string deviceName = "");

        ///
        /// @ignore
        ///
        public abstract int GetLoopbackRecordingVolume();
        #endregion

        #region Miscellaneous methods
        ///
        /// <summary>
        /// Sets up cloud proxy service.
        /// When users' network access is restricted by a firewall, configure the firewall to allow specific IP addresses and ports provided by Agora; then, call this method to enable the cloud proxyType and set the cloud proxy type with the proxyType parameter.After successfully connecting to the cloud proxy, the SDK triggers the OnConnectionStateChanged (CONNECTION_STATE_CONNECTING, CONNECTION_CHANGED_SETTING_PROXY_SERVER) callback.To disable the cloud proxy that has been set, call the SetCloudProxy (NONE_PROXY).To change the cloud proxy type that has been set, call the SetCloudProxy (NONE_PROXY) first, and then call the SetCloudProxy to set the proxyType you want.Agora recommends that you call this method after joining a channel.When a user is behind a firewall and uses the Force UDP cloud proxy, the services for Media Push and cohosting across channels are not available.When you use the Force TCP cloud proxy, note that an error would occur when calling the StartAudioMixing [2/2] method to play online music files in the HTTP protocol. The services for Media Push and cohosting across channels use the cloud proxy with the TCP protocol.
        /// </summary>
        ///
        /// <param name="proxyType"> The type of the cloud proxy. See CLOUD_PROXY_TYPE .This parameter is mandatory. The SDK reports an error if you do not pass in a value.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.-2: The parameter is invalid.-7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int SetCloudProxy(CLOUD_PROXY_TYPE proxyType);

        ///
        /// <summary>
        /// Retrieves the call ID.
        /// When a user joins a channel on a client, a callId is generated to identify the call from the client. Some methods, such as Rate and Complain , must be called after the call ends to submit feedback to the SDK. These methods require the callId parameter.Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="callId"> Output parameter, the current call ID.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetCallId(ref string callId);

        ///
        /// <summary>
        /// Allows a user to rate a call after the call ends.
        /// Ensure that you call this method after leaving a channel.
        /// </summary>
        ///
        /// <param name="callId"> The current call ID. You can get the call ID by calling GetCallId .</param>
        ///
        /// <param name="rating"> The rating of the call. The value is between 1 (the lowest score) and 5 (the highest score). If you set a value out of this range, the SDK returns the -2 (ERR_INVALID_ARGUMENT) error.</param>
        ///
        /// <param name="description"> (Optional) A description of the call. The string length should be less than 800 bytes.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2 (ERR_INVALID_ARGUMENT).-3 (ERR_NOT_READY).
        /// </returns>
        ///
        public abstract int Rate(string callId, int rating, string description);

        ///
        /// <summary>
        /// Allows a user to complain about the call quality after a call ends.
        /// This method allows users to complain about the quality of the call. Call this method after the user leaves the channel.
        /// </summary>
        ///
        /// <param name="callId"> The current call ID. You can get the call ID by calling GetCallId .</param>
        ///
        /// <param name="description"> (Optional) A description of the call. The string length should be less than 800 bytes.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid.- 3: The SDK is not ready. Possible reasons include the following:The initialization of IRtcEngine fails. Reinitialize the IRtcEngine.No user has joined the channel when the method is called. Please check your code logic.The user has not left the channel when the Rate or Complain method is called. Please check your code logic.The audio module is disabled. The program is not complete.
        /// </returns>
        ///
        public abstract int Complain(string callId, string description);

        ///
        /// <summary>
        /// Gets the SDK version.
        /// </summary>
        ///
        /// <param name="build"> The SDK build index.</param>
        ///
        /// <returns>
        /// The SDK version number. The format is a string.
        /// </returns>
        ///
        public abstract string GetVersion(ref int build);

        ///
        /// <summary>
        /// Gets the warning or error description.
        /// </summary>
        ///
        /// <param name="code"> The error code or warning code reported by the SDK.</param>
        ///
        /// <returns>
        /// The specific error or warning description.
        /// </returns>
        ///
        public abstract string GetErrorDescription(int code);

        ///
        /// <summary>
        /// Queries the current device's supported video codec capabilities.
        /// </summary>
        ///
        /// <param name="codecInfo"> Input and output parameter. An array representing the video codec capabilities of the device. See CodecCapInfo .Input value: One CodecCapInfo defined by the user when executing this method, representing the video codec capability to be queried.Output value: The CodecCapInfo after the method is executed, representing the actual video codec capabilities supported by the device.</param>
        ///
        /// <param name="size"> Input and output parameter, represent the size of the CodecCapInfo array.Input value: Size of the CodecCapInfo defined by the user when executing the method.Output value: Size of the output CodecCapInfo after this method is executed.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int QueryCodecCapability(ref CodecCapInfo[] codecInfo, ref int size);

        #endregion

        #region DeviceManager
        ///
        /// <summary>
        /// Gets the IAudioDeviceManager object to manage audio devices.
        /// </summary>
        ///
        /// <returns>
        /// One IAudioDeviceManager object.
        /// </returns>
        ///
        public abstract IAudioDeviceManager GetAudioDeviceManager();

        ///
        /// <summary>
        /// Gets the IVideoDeviceManager object to manage video devices.
        /// </summary>
        ///
        /// <returns>
        /// One IVideoDeviceManager object.
        /// </returns>
        ///
        public abstract IVideoDeviceManager GetVideoDeviceManager();
        #endregion

        ///
        /// <summary>
        /// Gets one IMediaPlayerCacheManager instance.
        /// When you successfully call this method, the SDK returns a media player cache manager instance. The cache manager is a singleton pattern. Therefore, multiple calls to this method returns the same instance.Make sure the IRtcEngine is initialized before you call this method.
        /// </summary>
        ///
        /// <returns>
        /// The IMediaPlayerCacheManager instance.
        /// </returns>
        ///
        public abstract IMediaPlayerCacheManager GetMediaPlayerCacheManager();

        ///
        /// <summary>
        /// Gets IMusicContentCenter .
        /// </summary>
        ///
        /// <returns>
        /// One IMusicContentCenter object.
        /// </returns>
        ///
        public abstract IMusicContentCenter GetMusicContentCenter();

        #region SpatialAudio
        ///
        /// <summary>
        /// Gets one ILocalSpatialAudioEngine object.
        /// Make sure the IRtcEngine is initialized before you call this method.
        /// </summary>
        ///
        /// <returns>
        /// One ILocalSpatialAudioEngine object.
        /// </returns>
        ///
        public abstract ILocalSpatialAudioEngine GetLocalSpatialAudioEngine();

        ///
        /// <summary>
        /// Sets the 2D position (the position on the horizontal plane) of the remote user's voice.
        /// This method sets the 2D position and volume of a remote user, so that the local user can easily hear and identify the remote user's position.When the local user calls this method to set the voice position of a remote user, the voice difference between the left and right channels allows the local user to track the real-time position of the remote user, creating a sense of space. This method applies to massive multiplayer online games, such as Battle Royale games.For this method to work, enable stereo panning for remote users by calling the EnableSoundPositionIndication method before joining a channel.For the best voice positioning, Agora recommends using a wired headset.Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="pan"> The voice position of the remote user. The value ranges from -1.0 to 1.0:0.0: (Default) The remote voice comes from the front.-1.0: The remote voice comes from the left.1.0: The remote voice comes from the right.</param>
        ///
        /// <param name="gain"> The volume of the remote user. The value ranges from 0.0 to 100.0. The default value is 100.0 (the original volume of the remote user). The smaller the value, the lower the volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        ///
        /// <summary>
        /// Enables or disables the spatial audio effect.
        /// After enabling the spatial audio effect, you can call SetRemoteUserSpatialAudioParams to set the spatial audio effect parameters of the remote user.You can call this method either before or after joining a channel.This method relies on the spatial audio dynamic library libagora_spatial_audio_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the spatial audio effect:true: Enable the spatial audio effect.false: Disable the spatial audio effect.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableSpatialAudio(bool enabled);

        ///
        /// <summary>
        /// Sets the spatial audio effect parameters of the remote user.
        /// Call this method after EnableSpatialAudio . After successfully setting the spatial audio effect parameters of the remote user, the local user can hear the remote user with a sense of space.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel.</param>
        ///
        /// <param name="param"> The spatial audio parameters. See SpatialAudioParams .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param);
        #endregion

        #region RtmpStreaming
        ///
        /// <summary>
        /// Sets the audio profile of the audio streams directly pushed to the CDN by the host.
        /// </summary>
        ///
        /// <param name="profile"> The audio profile, including the sampling rate, bitrate, encoding mode, and the number of channels. See AUDIO_PROFILE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile);

        ///
        /// <summary>
        /// Sets the video profile of the media streams directly pushed to the CDN by the host.
        /// This method only affects video streams captured by cameras or screens, or from custom video capture sources. That is, when you set publishCameraTrack or publishCustomVideoTrack in DirectCdnStreamingMediaOptions as true to capture videos, you can call this method to set the video profiles.If your local camera does not support the video resolution you set,the SDK automatically adjusts the video resolution to a value that is closest to your settings for capture, encoding or streaming, with the same aspect ratio as the resolution you set. You can get the actual resolution of the video streams through the OnDirectCdnStreamingStats callback.
        /// </summary>
        ///
        /// <param name="config"> Video profile. See VideoEncoderConfiguration .During CDN live streaming, Agora only supports setting ORIENTATION_MODE as ORIENTATION_MODE_FIXED_LANDSCAPE or ORIENTATION_MODE_FIXED_PORTRAIT.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config);

        ///
        /// <summary>
        /// Starts pushing media streams to the CDN directly.
        /// Aogra does not support pushing media streams to one URL repeatedly.Media optionsAgora does not support setting the value of publishCameraTrack and publishCustomVideoTrack as true, or the value of publishMicrophoneTrack and publishCustomAudioTrack as true at the same time. When choosing media setting options ( DirectCdnStreamingMediaOptions ), you can refer to the following examples:If you want to push audio and video streams published by the host to the CDN, the media setting options should be set as follows:publishCustomAudioTrack is set as true and call the PushAudioFrame methodpublishCustomVideoTrack is set as true and call the PushVideoFrame methodpublishCameraTrack is set as false (the default value)publishMicrophoneTrack is set as false (the default value)As of v4.2.0, Agora SDK supports audio-only live streaming. You can set publishCustomAudioTrack or publishMicrophoneTrack in DirectCdnStreamingMediaOptions as true and call PushAudioFrame to push audio streams. Agora only supports pushing one audio and video streams or one audio streams to CDN.
        /// </summary>
        ///
        /// <param name="publishUrl"> The CDN live streaming URL.</param>
        ///
        /// <param name="options"> The media setting options for the host. See DirectCdnStreamingMediaOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options);

        ///
        /// <summary>
        /// Stops pushing media streams to the CDN directly.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopDirectCdnStreaming();

        ///
        /// @ignore
        ///
        public abstract int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options);

        ///
        /// <summary>
        /// Starts pushing media streams to a CDN without transcoding.
        /// Ensure that you enable the Media Push service before using this function. See Enable Media Push.
        /// Call this method after joining a channel.
        /// Only hosts in the LIVE_BROADCASTING profile can call this method.
        /// If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
        /// Agora recommends that you use the server-side Media Push function. You can call this method to push an audio or video stream to the specified CDN address. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// </summary>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The URL is null or the string length is 0.
        /// -7: The SDK is not initialized before calling this method.
        /// -19: The Media Push URL is already in use, use another URL instead.
        /// </returns>
        ///
        public abstract int StartRtmpStreamWithoutTranscoding(string url);

        ///
        /// <summary>
        /// Starts Media Push and sets the transcoding configuration.
        /// Agora recommends that you use the server-side Media Push function. You can call this method to push a live audio-and-video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.Ensure that you enable the Media Push service before using this function. See Enable Media Push.Call this method after joining a channel.Only hosts in the LIVE_BROADCASTING profile can call this method.If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
        /// </summary>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
        ///
        /// <param name="transcoding"> The transcoding configuration for Media Push. See LiveTranscoding .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The URL is null or the string length is 0.-7: The SDK is not initialized before calling this method.-19: The Media Push URL is already in use, use another URL instead.
        /// </returns>
        ///
        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);

        ///
        /// <summary>
        /// Updates the transcoding configuration.
        /// Agora recommends that you use the server-side Media Push function. After you start pushing media streams to CDN with transcoding, you can dynamically update the transcoding configuration according to the scenario. The SDK triggers the OnTranscodingUpdated callback after the transcoding configuration is updated.
        /// </summary>
        ///
        /// <param name="transcoding"> The transcoding configuration for Media Push. See LiveTranscoding .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);

        ///
        /// <summary>
        /// Stops pushing media streams to a CDN.
        /// Agora recommends that you use the server-side Media Push function. You can call this method to stop the live stream on the specified CDN address. This method can stop pushing media streams to only one CDN address at a time, so if you need to stop pushing streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// </summary>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopRtmpStream(string url);
        #endregion

        #region Log
        ///
        /// <summary>
        /// Sets the log file.
        /// Deprecated:Use the mLogConfig parameter in Initialize method instead.Specifies an SDK output log file. The log file records all log data for the SDK’s operation. Ensure that the directory for the log file exists and is writable.Ensure that you call Initialize immediately after calling the IRtcEngine method, or the output log may not be complete.
        /// </summary>
        ///
        /// <param name="filePath"> The complete path of the log files. These log files are encoded in UTF-8.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLogFile(string filePath);

        ///
        /// <summary>
        /// Sets the log output level of the SDK.
        /// Deprecated:Use logConfig in Initialize instead.
        /// </summary>
        ///
        /// <param name="filter"> The output log level of the SDK.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLogFilter(uint filter);

        ///
        /// <summary>
        /// Sets the output log level of the SDK.
        /// Deprecated:This method is deprecated. Use RtcEngineContext instead to set the log output level.Choose a level to see the logs preceding that level.
        /// </summary>
        ///
        /// <param name="level"> The log level: LOG_LEVEL .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLogLevel(LOG_LEVEL level);

        ///
        /// <summary>
        /// Sets the log file size.
        /// Deprecated:Use the logConfig parameter in Initialize instead.By default, the SDK generates five SDK log files and five API call log files with the following rules:The SDK log files are: agorasdk.log, agorasdk.1.log, agorasdk.2.log, agorasdk.3.log, and agorasdk.4.log.The API call log files are: agoraapi.log, agoraapi.1.log, agoraapi.2.log, agoraapi.3.log, and agoraapi.4.log.The default size for each SDK log file is 1,024 KB; the default size for each API call log file is 2,048 KB. These log files are encoded in UTF-8.The SDK writes the latest logs in agorasdk.log or agoraapi.log.When agorasdk.log is full, the SDK processes the log files in the following order:Delete the agorasdk.4.log file (if any).Rename agorasdk.3.log to agorasdk.4.log.Rename agorasdk.2.log to agorasdk.3.log.Rename agorasdk.1.log to agorasdk.2.log.Create a new agorasdk.log file.The overwrite rules for the agoraapi.log file are the same as for agorasdk.log.This method is used to set the size of the agorasdk.log file only and does not effect the agoraapi.log file.
        /// </summary>
        ///
        /// <param name="fileSizeInKBytes"> The size (KB) of an agorasdk.log file. The value range is [128,20480]. The default value is 1,024 KB. If you set fileSizeInKByte smaller than 128 KB, the SDK automatically adjusts it to 128 KB; if you set fileSizeInKByte greater than 20,480 KB, the SDK automatically adjusts it to 20,480 KB.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLogFileSize(uint fileSizeInKBytes);

        ///
        /// @ignore
        ///
        public abstract int UploadLogFile(ref string requestId);
        #endregion

        #region black list and white list
        ///
        /// <summary>
        /// Set the blocklist of subscriptions for audio streams.
        /// You can call this method to specify the audio streams of a user that you do not want to subscribe to.You can call this method either before or after joining a channel.The blocklist is not affected by the setting in MuteRemoteAudioStream , MuteAllRemoteAudioStreams , and autoSubscribeAudio in ChannelMediaOptions .Once the blocklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.
        /// </summary>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to.If you want to specify the audio streams of a user that you do not want to subscribe to, add the user ID in this list. If you want to remove a user from the blocklist, you need to call the SetSubscribeAudioBlocklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list.</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Sets the allowlist of subscriptions for audio streams.
        /// You can call this method to specify the audio streams of a user that you want to subscribe to.If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.
        /// You can call this method either before or after joining a channel.
        /// The allowlist is not affected by the setting in MuteRemoteAudioStream , MuteAllRemoteAudioStreams and autoSubscribeAudio in ChannelMediaOptions .Once the allowlist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// </summary>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to.If you want to specify the audio streams of a user for subscription, add the user ID in this list. If you want to remove a user from the allowlist, you need to call the SetSubscribeAudioAllowlist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list.</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Set the blocklist of subscriptions for video streams.
        /// You can call this method to specify the video streams of a user that you do not want to subscribe to.If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.
        /// Once the blocklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// You can call this method either before or after joining a channel.
        /// The blocklist is not affected by the setting in MuteRemoteVideoStream , MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to.If you want to specify the video streams of a user that you do not want to subscribe to, add the user ID of that user in this list. If you want to remove a user from the blocklist, you need to call the SetSubscribeVideoBlocklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Set the allowlist of subscriptions for video streams.
        /// You can call this method to specify the video streams of a user that you want to subscribe to.If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.Once the allowlist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.You can call this method either before or after joining a channel.The allowlist is not affected by the setting in MuteRemoteVideoStream , MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to.If you want to specify the video streams of a user for subscription, add the user ID of that user in this list. If you want to remove a user from the allowlist, you need to call the SetSubscribeVideoAllowlist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber);
        #endregion


        #region DualStream
        #endregion

        ///
        /// <summary>
        /// Sets the rotation angle of the captured video.
        /// This method applies to Windows only.When the video capture device does not have the gravity sensing function, you can call this method to manually adjust the rotation angle of the captured video.
        /// </summary>
        ///
        /// <param name="type"> The video source type. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <param name="orientation"> The clockwise rotation angle. See VIDEO_ORIENTATION .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        ///
        /// @ignore
        ///
        public abstract int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        ///
        /// <summary>
        /// Gets the current connection state of the SDK.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// The current connection state. See CONNECTION_STATE_TYPE .
        /// </returns>
        ///
        public abstract CONNECTION_STATE_TYPE GetConnectionState();

        ///
        /// @ignore
        ///
        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);

        ///
        /// @ignore
        ///
        public abstract int PauseAudio();

        ///
        /// @ignore
        ///
        public abstract int ResumeAudio();

        ///
        /// <summary>
        /// Enables interoperability with the Agora Web SDK (applicable only in the live streaming scenarios).
        /// Deprecated:The SDK automatically enables interoperability with the Web SDK, so you no longer need to call this method.You can call this method to enable or disable interoperability with the Agora Web SDK. If a channel has Web SDK users, ensure that you call this method, or the video of the Native user will be a black screen for the Web user.This method is only applicable in live streaming scenarios, and interoperability is enabled by default in communication scenarios.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable interoperability:true: Enable interoperability.false: (Default) Disable interoperability.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableWebSdkInteroperability(bool enabled);

        ///
        /// <summary>
        /// Reports customized messages.
        /// Agora supports reporting and analyzing customized messages. This function is in the beta stage with a free trial. The ability provided in its beta test version is reporting a maximum of 10 message pieces within 6 seconds, with each message piece not exceeding 256 bytes and each string not exceeding 100 bytes. To try out this function, contact and discuss the format of customized messages with us.
        /// </summary>
        ///
        public abstract int SendCustomReportMessage(string id, string category, string @event, string label, int value);

        ///
        /// @ignore
        ///
        public abstract int StartAudioFrameDump(string channel_id, uint user_id, string location, string uuid, string passwd, long duration_ms, bool auto_upload);

        ///
        /// @ignore
        ///
        public abstract int StopAudioFrameDump(string channel_id, uint user_id, string location);


        ///
        /// <summary>
        /// Sets whether to enable the AI ​​noise reduction function and set the noise reduction mode.
        /// You can call this method to enable AI noise reduction function. Once enabled, the SDK automatically detects and reduces stationary and non-stationary noise from your audio on the premise of ensuring the quality of human voice. Stationary noise refers to noise signal with constant average statistical properties and negligibly small fluctuations of level within the period of observation. Common sources of stationary noises are:Television;Air conditioner;Machinery, etc.Non-stationary noise refers to noise signal with huge fluctuations of level within the period of observation. Common sources of non-stationary noises are:Thunder;Explosion;Cracking, etc.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the AI noise reduction function:true: Enable the AI noise reduction.false: (Default) Disable the AI noise reduction.</param>
        ///
        /// <param name="mode"> The AI noise reduction modes. See AUDIO_AINS_MODE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAINSMode(bool enabled, AUDIO_AINS_MODE mode);
        ///
        /// <summary>
        /// Registers a user account.
        /// Once registered, the user account can be used to identify the local user when the user joins the channel. After the registration is successful, the user account can identify the identity of the local user, and the user can use it to join the channel.After the user successfully registers a user account, the SDK triggers the OnLocalUserRegistered callback on the local client, reporting the user ID and account of the local user.This method is optional. To join a channel with a user account, you can choose either of the following ways:Call RegisterLocalUserAccount to create a user account, and then call JoinChannelWithUserAccount [2/2] to join the channel.Call the JoinChannelWithUserAccount [2/2] method to join the channel.The difference between the two ways is that the time elapsed between calling the RegisterLocalUserAccount method and joining the channel is shorter than directly calling JoinChannelWithUserAccount [2/2].Ensure that you set the userAccount parameter; otherwise, this method does not take effect.Ensure that the userAccount is unique in the channel.To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="appId"> The App ID of your project on Agora Console.</param>
        ///
        /// <param name="userAccount"> The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are as follow(89 in total):The 26 lowercase English letters: a to z.The 26 uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "= ", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterLocalUserAccount(string appId, string userAccount);

        ///
        /// <summary>
        /// Sets the operational permission of the SDK on the audio session.
        /// The SDK and the app can both configure the audio session by default. If you need to only use the app to configure the audio session, this method restricts the operational permission of the SDK on the audio session.You can call this method either before or after joining a channel. Once you call this method to restrict the operational permission of the SDK on the audio session, the restriction takes effect when the SDK needs to change the audio session.This method is only available for iOS platforms.This method does not restrict the operational permission of the app on the audio session.
        /// </summary>
        ///
        /// <param name="restriction"> The operational permission of the SDK on the audio session. See AUDIO_SESSION_OPERATION_RESTRICTION . This parameter is in bit mask format, and each bit corresponds to a permission.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);

        ///
        /// <summary>
        /// Provides the technical preview functionalities or special customizations by configuring the SDK with JSON options.
        /// Contact to get the JSON configuration method.
        /// </summary>
        ///
        /// <param name="parameters"> Pointer to the set parameters in a JSON string.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetParameters(string parameters);


        ///
        /// @ignore
        ///
        public abstract int SetParameters(string key, object value);


        ///
        /// <summary>
        /// Enables tracing the video frame rendering process.
        /// The SDK starts tracing the rendering status of the video frames in the channel from the moment this method is successfully called and reports information about the event through the OnVideoRenderingTracingResult callback.By default, the SDK starts tracing the video rendering event automatically when the local user successfully joins the channel. You can call this method at an appropriate time according to the actual application scenario to customize the tracing process.After the local user leaves the current channel, the SDK automatically resets the time point to the next time when the user successfully joins the channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-7: The method is called before IRtcEngine is initialized.
        /// </returns>
        ///
        public abstract int StartMediaRenderingTracing();



        ///
        /// <summary>
        /// Enables audio and video frame instant rendering.
        /// After successfully calling this method, the SDK enables the instant frame rendering mode, which can speed up the first frame rendering speed after the user joins the channel.Once the instant rendering function is enabled, it can only be canceled by calling the Dispose method to destroy the IRtcEngine object.In this mode, the SDK uses Agora's custom encryption algorithm to shorten the time required to establish transmission links, and the security is reduced compared to the standard DTLS (Datagram Transport Layer Security). If the application scenario requires higher security standards, Agora recommends that you do not use this method.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-7: The method is called before IRtcEngine is initialized.
        /// </returns>
        ///
        public abstract int EnableInstantMediaRendering();

        ///
        /// <summary>
        /// Gets the audio device information.
        /// After calling this method, you can get whether the audio device supports ultra-low-latency capture and playback.This method is for Android only.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="deviceInfo"> Audio frame information. See DeviceInfoMobile .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioDeviceInfo(ref DeviceInfoMobile deviceInfo);

        ///
        /// @ignore
        ///
        public abstract int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option);

        ///
        /// @ignore
        ///
        public abstract int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option);

        ///
        /// @ignore
        ///
        public abstract int SetHighPriorityUserList(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option);

        ///
        /// @ignore
        ///
        public abstract int SetLocalAccessPoint(LocalAccessPointConfiguration config);

        ///
        /// @ignore
        ///
        public abstract int SetAVSyncSource(string channelId, uint uid);

        ///
        /// <summary>
        /// Enables or disables video screenshot and upload. 
        /// When video screenshot and upload function is enabled, the SDK takes screenshots and upload videos sent by local users based on the type and frequency of the module you set in ContentInspectConfig . After video screenshot and upload, the Agora server sends the callback notification to your app server in HTTPS requests and sends all screenshots to the third-party cloud storage service.Before calling this method, ensure that the video screenshot upload service has been activated. This method relies on the video screenshot and upload dynamic library libagora_content_inspect_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable video screenshot and uploadtrue: Enables video screenshot and upload. false: Disables video screenshot and upload.</param>
        ///
        /// <param name="config"> Configuration of video screenshot and upload. See ContentInspectConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableContentInspect(bool enabled, ContentInspectConfig config);

        ///
        /// @ignore
        ///
        public abstract bool StartDumpVideo(VIDEO_SOURCE_TYPE type, string dir);

        ///
        /// @ignore
        ///
        public abstract bool StopDumpVideo();

        ///
        /// @ignore
        ///
        public abstract int SetHighPriorityUserListEx(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnection connection);




        ///
        /// <summary>
        /// Selects the audio track used during playback.
        /// After getting the track index of the audio file, you can call this method to specify any track to play. For example, if different tracks of a multi-track file store songs in different languages, you can call this method to set the playback language.For the supported formats of audio files, see .You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="index"> The audio track you want to specify. The value range is [0, GetAudioTrackCount ()].</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SelectAudioTrack(int index);

        ///
        /// <summary>
        /// Gets the index of audio tracks of the current music file.
        /// You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// The SDK returns the index of the audio tracks if the method call succeeds.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioTrackCount();


        ///
        /// @ignore
        ///
        public abstract IMediaRecorder CreateMediaRecorder(RecorderStreamInfo info);

       
        ///
        /// @ignore
        ///
        public abstract int DestroyMediaRecorder(IMediaRecorder mediaRecorder);

        ///
        /// <summary>
        /// Gets the current Monotonic Time of the SDK.
        /// Monotonic Time refers to a monotonically increasing time series whose value increases over time. The unit is milliseconds.In custom video capture and custom audio capture scenarios, in order to ensure audio and video synchronization, Agora recommends that you call this method to obtain the current Monotonic Time of the SDK, and then pass this value into the timestamp parameter in the captured video frame ( VideoFrame ) and audio frame ( AudioFrame ).
        /// </summary>
        ///
        /// <returns>
        /// ≥0: The method call is successful, and returns the current Monotonic Time of the SDK (in milliseconds).&lt; 0: Failure.
        /// </returns>
        ///
        public abstract long GetCurrentMonotonicTimeInMs();


        ///
        /// @ignore
        ///
        public abstract int EnableWirelessAccelerate(bool enabled);


        ///
        /// <summary>
        /// Gets the current NTP (Network Time Protocol) time.
        /// In the real-time chorus scenario, especially when the downlink connections are inconsistent due to network issues among multiple receiving ends, you can call this method to obtain the current NTP time as the reference time, in order to align the lyrics and music of multiple receiving ends and achieve chorus synchronization.
        /// </summary>
        ///
        /// <returns>
        /// The Unix timestamp (ms) of the current NTP time.
        /// </returns>
        ///
        public abstract UInt64 GetNtpWallTimeInMs();
        ///
        /// <summary>
        /// Gets the C++ handle of the Native SDK.
        /// This method retrieves the C++ handle of the SDK, which is used for registering the audio and video frame observer.
        /// </summary>
        ///
        /// <param name="nativeHandler"> Output parameter, the native handle of the SDK.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetNativeHandler(ref IntPtr nativeHandler);
    };

    ///
    /// <summary>
    /// This interface class contains multi-channel methods.
    /// Inherited from IRtcEngine .
    /// </summary>
    ///
    public abstract class IRtcEngineEx : IRtcEngine
    {
        #region Multiple channels
        ///
        /// <summary>
        /// Joins a channel with the connection ID.
        /// You can call this method multiple times to join more than one channel.If you are already in a channel, you cannot rejoin it with the same user ID.If you want to join the same channel from different devices, ensure that the user IDs are different for all devices.Ensure that the app ID you use to generate the token is the same as the app ID used when creating the IRtcEngine instance.
        /// </summary>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions .</param>
        ///
        /// <param name="token"> The token generated on your server for authentication. </param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in ChannelMediaOptions is invalid. You need to pass in a valid parameter and join the channel again.
        /// -3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: The internal state of the IRtcEngine object is wrong. The typical cause is that you call this method to join the channel without calling StartEchoTest [3/3] to stop the test after calling StopEchoTest to start a call loop test. You need to call StopEchoTest before calling this method.
        /// -17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.
        /// -102: The channel name is invalid. You need to pass in a valid channelname in channelId to rejoin the channel.
        /// -121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options);

        ///
        /// <summary>
        /// Leaves a channel.
        /// This method lets the user leave the channel, for example, by hanging up or exiting the call.After calling JoinChannelEx to join the channel, this method must be called to end the call before starting the next call.This method can be called whether or not a call is currently in progress. This method releases all resources related to the session.This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel. After you leave the channel, the SDK triggers the OnLeaveChannel callback.After actually leaving the channel, the local user triggers the OnLeaveChannel callback; after the user in the communication scenario and the host in the live streaming scenario leave the channel, the remote user triggers the OnUserOffline callback.If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.Calling LeaveChannel [1/2] will leave the channels when calling JoinChannel [2/2] and JoinChannelEx at the same time.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LeaveChannelEx(RtcConnection connection);

        ///
        /// <summary>
        /// Sets channel options and leaves the channel.
        /// This method lets the user leave the channel, for example, by hanging up or exiting the call.After calling JoinChannelEx to join the channel, this method must be called to end the call before starting the next call.This method can be called whether or not a call is currently in progress. This method releases all resources related to the session.This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel. After you leave the channel, the SDK triggers the OnLeaveChannel callback.After actually leaving the channel, the local user triggers the OnLeaveChannel callback; after the user in the communication scenario and the host in the live streaming scenario leave the channel, the remote user triggers the OnUserOffline callback.If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.Calling LeaveChannel [2/2] will leave the channels when calling JoinChannel [2/2] and JoinChannelEx at the same time.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="options"> The options for leaving the channel. See LeaveChannelOptions .This parameter only supports the stopMicrophoneRecording member in the LeaveChannelOptions settings; setting other members does not take effect.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options);
        #endregion

        ///
        /// <summary>
        /// Updates the channel media options after joining the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions .</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The value of a member in the ChannelMediaOptions structure is invalid. For example, the token or the user ID is invalid. You need to fill in a valid parameter.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: The internal state of the IRtcEngine object is wrong. The possible reason is that the user is not in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. If you receive the CONNECTION_STATE_DISCONNECTED (1) or CONNECTION_STATE_FAILED (5) state, the user is not in the channel. You need to call JoinChannel [2/2] to join a channel before calling this method.
        /// </returns>
        ///
        public abstract int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the encoder configuration for the local video.
        /// Each configuration profile corresponds to a set of video parameters, including the resolution, frame rate, and bitrate.The config specified in this method is the maximum value under ideal network conditions. If the video engine cannot render the video using the specified config due to unreliable network conditions, the parameters further down the list are considered until a successful configuration is found.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="config"> Video profile. See VideoEncoderConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection);

        ///
        /// <summary>
        /// Initializes the video view of a remote user.
        /// This method initializes the video view of a remote stream on the local device. It affects only the video view that the local user sees. Call this method to bind the remote video stream to a video view and to set the rendering and mirror modes of the video view.The application specifies the uid of the remote video in the VideoCanvas method before the remote user joins the channel.If the remote uid is unknown to the application, set it after the application receives the OnUserJoined callback. If the Video Recording function is enabled, the Video Recording Service joins the channel as a dummy client, causing other clients to also receive the onUserJoined callback. Do not bind the dummy client to the application view because the dummy client does not send any video streams.To unbind the remote user from the view, set the view parameter to NULL.Once the remote user leaves the channel, the SDK unbinds the remote user.To update the rendering or mirror mode of the remote video view during a call, use the SetRemoteRenderModeEx method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="canvas"> The remote video view settings. See VideoCanvas .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes receiving the audio stream of a specified user.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The ID of the specified user.</param>
        ///
        /// <param name="mute"> Whether to stop receiving the audio stream of the specified user:true: Stop receiving the audio stream of the specified user.false: (Default) Resume receiving the audio stream of the specified user.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes receiving the video stream of a specified user.
        /// This method is used to stop or resume receiving the video stream of a specified user. You can call this method before or after joining a channel. If a user leaves a channel, the settings in this method become invalid.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="mute"> Whether to stop receiving the video stream of the specified user:true: Stop receiving the video stream of the specified user.false: (Default) Resume receiving the video stream of the specified user.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the 2D position (the position on the horizontal plane) of the remote user's voice.
        /// This method sets the voice position and volume of a remote user.When the local user calls this method to set the voice position of a remote user, the voice difference between the left and right channels allows the local user to track the real-time position of the remote user, creating a sense of space. This method applies to massive multiplayer online games, such as Battle Royale games.For the best voice positioning, Agora recommends using a wired headset.Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="pan"> The voice position of the remote user. The value ranges from -1.0 to 1.0:-1.0: The remote voice comes from the left.0.0: (Default) The remote voice comes from the front.1.0: The remote voice comes from the right.</param>
        ///
        /// <param name="gain"> The volume of the remote user. The value ranges from 0.0 to 100.0. The default value is 100.0 (the original volume of the remote user). The smaller the value, the lower the volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams param, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the video display mode of a specified remote user.
        /// After initializing the video view of a remote user, you can call this method to update its rendering and mirror modes. This method affects only the video view that the local user sees.During a call, you can call this method as many times as necessary to update the display mode of the video view of a remote user.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="renderMode"> The video display mode of the remote user. See RENDER_MODE_TYPE .</param>
        ///
        /// <param name="mirrorMode"> The mirror mode of the remote user view. See VIDEO_MIRROR_MODE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection);

        ///
        /// <summary>
        /// Enables loopback audio capturing.
        /// If you enable loopback audio capturing, the output of the sound card is mixed into the audio stream sent to the other end.This method applies to the macOS and Windows only.macOS does not support loopback audio capture of the default sound card. If you need to use this function, use a virtual sound card and pass its name to the deviceName parameter. Agora recommends using AgoraALD as the virtual sound card for audio capturing.This method only supports using one sound card for audio capturing.
        /// </summary>
        ///
        /// <param name="deviceName"> macOS: The device name of the virtual sound card. The default value is set to NULL, which means using AgoraALD for loopback audio capturing.
        ///  Windows: The device name of the sound card. The default is set to NULL, which means the SDK uses the sound card of your device for loopback audio capturing.</param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="enabled"> Sets whether to enable loopback audio capture:true: Enable loopback audio capturing.false: (Default) Disable loopback audio capturing.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName);


        ///
        /// @ignore
        ///
        public abstract int AdjustRecordingSignalVolumeEx(int volume, RtcConnection connection);


        ///
        /// @ignore
        ///
        public abstract int MuteRecordingSignalEx(bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Gets the current connection state of the SDK.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// The current connection state. See CONNECTION_STATE_TYPE .
        /// </returns>
        ///
        public abstract CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config);

        ///
        /// <summary>
        /// Creates a data stream.
        /// Deprecated:This method is deprecated. Use CreateDataStreamEx [2/2] instead.You can call this method to create a data stream and improve the reliability and ordering of data transmission.Ensure that you set the same value for reliable and ordered.Each user can create up to five data streams during the lifecycle of IRtcEngine .The data channel allows a data delay of up to 5 seconds. If the receiver does not receive the data stream within 5 seconds, the data channel reports an error.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="streamId"> An output parameter; the ID of the data stream created.</param>
        ///
        /// <param name="reliable"> Sets whether the recipients are guaranteed to receive the data stream from the sender within five seconds:true: The recipients receive the data stream from the sender within five seconds. If the recipient does not receive the data stream within five seconds, an error is reported to the application.false: There is no guarantee that the recipients receive the data stream from the sender within five seconds. The SDK does not report errors if reception is delayed or data is lost.</param>
        ///
        /// <param name="ordered"> Sets whether the recipients receive the data stream in the sent order:true: The recipients receive the data stream in the sent order.false: There is no guarantee that the recipients receive the data stream in the sent order.</param>
        ///
        /// <returns>
        /// 0: The data stream is successfully created.&lt; 0: Fails to create the data stream.
        /// </returns>
        ///
        public abstract int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection);

        ///
        /// <summary>
        /// Creates a data stream.
        /// Creates a data stream. Each user can create up to five data streams in a single channel.Compared with CreateDataStreamEx [1/2]
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="streamId"> An output parameter; the ID of the data stream created.</param>
        ///
        /// <param name="config"> The configurations for the data stream. See DataStreamConfig .</param>
        ///
        /// <returns>
        /// 0: The data stream is successfully created.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection);

        ///
        /// <summary>
        /// Sends data stream messages.
        /// After calling CreateDataStreamEx [2/2] , you can call this method to send data stream messages to all users in the channel.The SDK has the following restrictions on this method:Up to 60 packets can be sent per second in a channel with each packet having a maximum size of 1 KB.Each client can send up to 30 KB of data per second.Each user can have up to five data streams simultaneously.A successful method call triggers the OnStreamMessage callback on the remote client, from which the remote user gets the stream message.
        /// A failed method call triggers the OnStreamMessageError callback on the remote client.Ensure that you call CreateDataStreamEx [2/2] to create a data channel before calling this method.This method applies only to the COMMUNICATION profile or to the hosts in the LIVE_BROADCASTING profile. If an audience in the LIVE_BROADCASTING profile calls this method, the audience may be switched to a host.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="streamId"> The data stream ID. You can get the data stream ID by calling CreateDataStreamEx [2/2].</param>
        ///
        /// <param name="data"> The message to be sent.</param>
        ///
        /// <param name="length"> The length of the data.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection);

        ///
        /// <summary>
        /// Adds a watermark image to the local video.
        /// This method adds a PNG watermark image to the local video in the live streaming. Once the watermark image is added, all the audience in the channel (CDN audience included), and the capturing device can see and capture it. The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one.
        /// The watermark coordinates are dependent on the settings in the SetVideoEncoderConfigurationEx method:If the orientation mode of the encoding video ( ORIENTATION_MODE ) is fixed landscape mode or the adaptive landscape mode, the watermark uses the landscape orientation.If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed portrait mode or the adaptive portrait mode, the watermark uses the portrait orientation.When setting the watermark position, the region must be less than the dimensions set in the SetVideoEncoderConfigurationEx method; otherwise, the watermark image will be cropped.Ensure that you have called EnableVideo before calling this method.This method supports adding a watermark image in the PNG file format only. Supported pixel formats of the PNG image are RGBA, RGB, Palette, Gray, and Alpha_gray.If the dimensions of the PNG image differ from your settings in this method, the image will be cropped or zoomed to conform to your settings.If you have enabled the local video preview by calling the StartPreview [1/2] visibleInPreview member to set whether or not the watermark is visible in the preview.If you have enabled the mirror mode for the local video, the watermark on the local video is also mirrored. To avoid mirroring the watermark, Agora recommends that you do not use the mirror and watermark functions for the local video at the same time. You can implement the watermark function in your application layer.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="options"> The options of the watermark image to be added. See WatermarkOptions .</param>
        ///
        /// <param name="watermarkUrl"> The local file path of the watermark image to be added. This method supports adding a watermark image from the local absolute or relative file path.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection);

        ///
        /// <summary>
        /// Removes the watermark image from the video stream.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ClearVideoWatermarkEx(RtcConnection connection);

        ///
        /// <summary>
        /// Agora supports reporting and analyzing customized messages.
        /// Agora supports reporting and analyzing customized messages. This function is in the beta stage with a free trial. The ability provided in its beta test version is reporting a maximum of 10 message pieces within 6 seconds, with each message piece not exceeding 256 bytes and each string not exceeding 100 bytes. To try out this function, contact and discuss the format of customized messages with us.
        /// </summary>
        ///
        public abstract int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the stream type of the remote video.
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using EnableDualStreamModeEx (false), the receiver can choose to receive either the high-quality video stream or the low-quality video stream. The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate.By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream.The SDK enables the low-quality video stream auto mode on the sender by default (not actively sending low-quality video streams). The host at the receiving end can call this method to initiate a low-quality video stream stream request on the receiving end, and the sender automatically switches to the low-quality video stream mode after receiving the request.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The user ID.</param>
        ///
        /// <param name="streamType"> The video stream type: VIDEO_STREAM_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection);

        ///
        /// <summary>
        /// Enables the reporting of users' volume indication.
        /// This method enables the SDK to regularly report the volume information to the app of the local user who sends a stream and remote users (three users at most) whose instantaneous volumes are the highest. Once you call this method and users send streams in the channel, the SDK triggers the OnAudioVolumeIndication callback at the time interval set in this method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="reportVad"> true: Enables the voice activity detection of the local user. Once it is enabled, the vad parameter of the OnAudioVolumeIndication callback reports the voice activity status of the local user.false: (Default) Disables the voice activity detection of the local user. Once it is disabled, the vad parameter of the OnAudioVolumeIndication callback does not report the voice activity status of the local user, except for the scenario where the engine automatically detects the voice activity of the local user.</param>
        ///
        /// <param name="smooth"> The smoothing factor that sets the sensitivity of the audio volume indicator. The value ranges between 0 and 10. The recommended value is 3. The greater the value, the more sensitive the indicator.</param>
        ///
        /// <param name="interval"> Sets the time interval between two consecutive volume indications:≤ 0: Disables the volume indication.> 0: Time interval (ms) between two consecutive volume indications. The lowest value is 50.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection);

       
        ///
        /// <summary>
        /// Enables or disables dual-stream mode on the sender side.
        /// After you enable dual-stream mode, you can call SetRemoteVideoStreamType to choose to receive either the high-quality video stream or the low-quality video stream on the subscriber side.You can call this method to enable or disable the dual-stream mode on the publisher side. Dual streams are a pairing of a high-quality video stream and a low-quality video stream:High-quality video stream: High bitrate, high resolution.Low-quality video stream: Low bitrate, low resolution.This method is applicable to all types of streams from the sender, including but not limited to video streams collected from cameras, screen sharing streams, and custom-collected video streams.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="streamConfig"> The configuration of the low-quality video stream. See SimulcastStreamConfig .</param>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode:
        ///  true: Enable dual-stream mode.
        ///  false: (Default) Disable dual-stream mode.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection);

        ///
        /// <summary>
        /// Options for subscribing to remote video streams.
        /// When a remote user has enabled dual-stream mode, you can call this method to choose the option for subscribing to the video streams sent by the remote user.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="options"> The video subscription options. See VideoSubscriptionOptions .</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection);

        ///
        /// <summary>
        /// Set the blocklist of subscriptions for audio streams.
        /// You can call this method to specify the audio streams of a user that you do not want to subscribe to.You can call this method either before or after joining a channel.The blocklist is not affected by the setting in MuteRemoteAudioStream , MuteAllRemoteAudioStreams , and autoSubscribeAudio in ChannelMediaOptions .Once the blocklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to.If you want to specify the audio streams of a user that you do not want to subscribe to, add the user ID in this list. If you want to remove a user from the blocklist, you need to call the SetSubscribeAudioBlocklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the allowlist of subscriptions for audio streams.
        /// You can call this method to specify the audio streams of a user that you want to subscribe to.If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.You can call this method either before or after joining a channel.The allowlist is not affected by the setting in MuteRemoteAudioStream , MuteAllRemoteAudioStreams and autoSubscribeAudio in ChannelMediaOptions .Once the allowlist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to.If you want to specify the audio streams of a user for subscription, add the user ID in this list. If you want to remove a user from the allowlist, you need to call the SetSubscribeAudioAllowlist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// <summary>
        /// Set the blocklist of subscriptions for video streams.
        /// You can call this method to specify the video streams of a user that you do not want to subscribe to.If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.Once the blocklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.You can call this method either before or after joining a channel.The blocklist is not affected by the setting in MuteRemoteVideoStream , MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to.If you want to specify the video streams of a user that you do not want to subscribe to, add the user ID of that user in this list. If you want to remove a user from the blocklist, you need to call the SetSubscribeVideoBlocklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// <summary>
        /// Set the allowlist of subscriptions for video streams.
        /// You can call this method to specify the video streams of a user that you want to subscribe to.If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.Once the allowlist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.You can call this method either before or after joining a channel.The allowlist is not affected by the setting in MuteRemoteVideoStream , MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to.If you want to specify the video streams of a user for subscription, add the user ID of that user in this list. If you want to remove a user from the allowlist, you need to call the SetSubscribeVideoAllowlist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the dual-stream mode on the sender side.
        /// The SDK enables the low-quality video stream auto mode on the sender by default, which is equivalent to calling this method and setting the mode to AUTO_SIMULCAST_STREAM. If you want to modify this behavior, you can call this method and modify the mode to DISABLE_SIMULCAST_STREAM (never send low-quality video streams) or ENABLE_SIMULCAST_STREAM (always send low-quality video streams).The difference and connection between this method and EnableDualStreamModeEx is as follows:When calling this method and setting mode to DISABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamModeEx(false).When calling this method and setting mode to ENABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamModeEx(true).Both methods can be called before and after joining a channel. If both methods are used, the settings in the method called later takes precedence.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="streamConfig"> The configuration of the low-quality video stream. See SimulcastStreamConfig .</param>
        ///
        /// <param name="mode"> The mode in which the video stream is sent. See SIMULCAST_STREAM_MODE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection);

        ///
        /// <summary>
        /// Takes a snapshot of a video stream.
        /// The method is asynchronous, and the SDK has not taken the snapshot when the method call returns. After a successful method call, the SDK triggers the OnSnapshotTaken callback to report whether the snapshot is successfully taken, as well as the details for that snapshot.This method takes a snapshot of a video stream from the specified user, generates a JPG image, and saves it to the specified path.Call this method after the JoinChannelEx method.This method takes a snapshot of the published video stream specified in ChannelMediaOptions .If the user's video has been preprocessed, for example, watermarked or beautified, the resulting snapshot includes the pre-processing effect.
        /// </summary>
        ///
        /// <param name="filePath"> The local path (including filename extensions) of the snapshot. For example:Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.jpgiOS: /App Sandbox/Library/Caches/example.jpgmacOS: ～/Library/Logs/example.jpgAndroid: /storage/emulated/0/Android/data/<package name>/files/example.jpgEnsure that the path you specify exists and is writable.</param>
        ///
        /// <param name="uid"> The user ID. Set uid as 0 if you want to take a snapshot of the local user's video.</param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath);

        ///
        /// <summary>
        /// Stops or resumes publishing the local audio stream.
        /// This method does not affect any ongoing audio recording, because it does not disable the audio capture device.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="mute"> Whether to stop publishing the local audio stream:true: Stops publishing the local audio stream.false: (Default) Resumes publishing the local audio stream.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalAudioStreamEx(bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes publishing the local video stream.
        /// A successful call of this method triggers the OnUserMuteVideo callback on the remote client.This method does not affect any ongoing video recording, because it does not disable the camera.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="mute"> Whether to stop publishing the local video stream.true: Stop publishing the local video stream.false: (Default) Publish the local video stream.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalVideoStreamEx(bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio streams of all remote users.
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including the ones join the channel subsequent to this call.Call this method after joining a channel.If you do not want to subscribe the audio streams of remote users before joining a channel, you can set autoSubscribeAudio as false when calling JoinChannel [2/2] .
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users:true: Stops subscribing to the audio streams of all remote users.false: (Default) Subscribes to the audio streams of all remote users by default.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the video streams of all remote users.
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="mute"> Whether to stop subscribing to the video streams of all remote users.true: Stop subscribing to the video streams of all remote users.false: (Default) Subscribe to the audio streams of all remote users by default.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Adjusts the playback signal volume of a specified remote user.
        /// You can call this method to adjust the playback volume of a specified remote user. To adjust the playback volume of different remote users, call the method as many times, once for each remote user.Call this method after joining a channel.The playback volume here refers to the mixed volume of a specified remote user.
        /// </summary>
        ///
        /// <param name="volume"> Audio mixing volume. The value ranges between 0 and 100. The default value is 100, which means the original volume.</param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection);

        ///
        /// <summary>
        /// Starts pushing media streams to a CDN without transcoding.
        /// Ensure that you enable the Media Push service before using this function. See Enable Media Push.
        /// Call this method after joining a channel.
        /// Only hosts in the LIVE_BROADCASTING profile can call this method.
        /// If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
        /// Agora recommends that you use the server-side Media Push function. You can call this method to push an audio or video stream to the specified CDN address. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The URL is null or the string length is 0.
        /// -7: The SDK is not initialized before calling this method.
        /// -19: The Media Push URL is already in use, use another URL instead.
        /// </returns>
        ///
        public abstract int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection);

        ///
        /// <summary>
        /// Starts Media Push and sets the transcoding configuration.
        /// Agora recommends that you use the server-side Media Push function. You can call this method to push a live audio-and-video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.Ensure that you enable the Media Push service before using this function. Call this method after joining a channel.Only hosts in the LIVE_BROADCASTING profile can call this method.If you want to retry pushing streams after a failed push, make sure to call StopRtmpStreamEx first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="transcoding"> The transcoding configuration for Media Push. See LiveTranscoding .</param>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The URL is null or the string length is 0.-7: The SDK is not initialized before calling this method.-19: The Media Push URL is already in use, use another URL instead.
        /// </returns>
        ///
        public abstract int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection);

        ///
        /// <summary>
        /// Updates the transcoding configuration.
        /// Agora recommends that you use the server-side Media Push function. After you start pushing media streams to CDN with transcoding, you can dynamically update the transcoding configuration according to the scenario. The SDK triggers the OnTranscodingUpdated callback after the transcoding configuration is updated.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="transcoding"> The transcoding configuration for Media Push. See LiveTranscoding .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection);

        ///
        /// <summary>
        /// Stops pushing media streams to a CDN.
        /// Agora recommends that you use the server-side Media Push function. You can call this method to stop the live stream on the specified CDN address. This method can stop pushing media streams to only one CDN address at a time, so if you need to stop pushing streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// </summary>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopRtmpStreamEx(string url, RtcConnection connection);


        ///
        /// <summary>
        /// Starts relaying media streams across channels or updates channels for media relay.
        /// The first successful call to this method starts relaying media streams from the source channel to the destination channels. To relay the media stream to other channels, or exit one of the current media relays, you can call this method again to update the destination channels.After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback, and this callback returns the state of the media stream relay. Common states are as follows:If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), it means that the SDK starts relaying media streams from the source channel to the destination channel.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_FAILURE (3), an exception occurs during the media stream relay.Call this method after joining the channel.This method takes effect only when you are a host in a live streaming channel.The relaying media streams across channels function needs to be enabled by contacting .Agora does not support string user accounts in this API.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. See ChannelMediaRelayConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-7: The method call was rejected. It may be because the SDK has not been initialized successfully, or the user role is not an host.-8: Internal state error. Probably because the user is not an audience member.
        /// </returns>
        ///
        public abstract int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        [Obsolete("Use `startOrUpdateChannelMediaRelayEx` instead.")]
        ///
        /// <summary>
        /// Starts relaying media streams across channels. This method can be used to implement scenarios such as co-host across channels.
        /// Deprecated:This method is deprecated. Use StartOrUpdateChannelMediaRelayEx instead.After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged and OnChannelMediaRelayEvent callbacks, and these callbacks return the state and events of the media stream relay.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), and the OnChannelMediaRelayEvent callback returns RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4), it means that the SDK starts relaying media streams between the source channel and the target channel.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_FAILURE (3), an exception occurs during the media stream relay.Call this method after joining the channel.This method takes effect only when you are a host in a live streaming channel.After a successful method call, if you want to call this method again, ensure that you call the StopChannelMediaRelayEx method to quit the current relay.The relaying media streams across channels function needs to be enabled by contacting .Agora does not support string user accounts in this API.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. See ChannelMediaRelayConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-7: The method call was rejected. It may be because the SDK has not been initialized successfully, or the user role is not an host.-8: Internal state error. Probably because the user is not an audience member.
        /// </returns>
        ///
        public abstract int StartChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        [Obsolete("Use `startOrUpdateChannelMediaRelayEx` instead.")]
        ///
        /// <summary>
        /// Updates the channels for media stream relay.
        /// Deprecated:This method is deprecated. Use StartOrUpdateChannelMediaRelayEx instead.After the media relay starts, if you want to relay the media stream to more channels, or leave the current relay channel, you can call this method.After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback with the RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL (7) state code.Call the method after successfully calling the StartChannelMediaRelayEx method and receiving OnChannelMediaRelayStateChanged (RELAY_STATE_RUNNING, RELAY_OK); otherwise, the method call fails.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. See ChannelMediaRelayConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        ///
        /// <summary>
        /// Stops the media stream relay. Once the relay stops, the host quits all the target channels.
        /// After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback. If the callback reports RELAY_STATE_IDLE (0) and RELAY_OK (0), the host successfully stops the relay.If the method call fails, the SDK triggers the OnChannelMediaRelayStateChanged callback with the RELAY_ERROR_SERVER_NO_RESPONSE (2) or RELAY_ERROR_SERVER_CONNECTION_LOST (8) status code. You can call the LeaveChannel [1/2]
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopChannelMediaRelayEx(RtcConnection connection);

        ///
        /// <summary>
        /// Pauses the media stream relay to all target channels.
        /// After the cross-channel media stream relay starts, you can call this method to pause relaying media streams to all target channels; after the pause, if you want to resume the relay, call ResumeAllChannelMediaRelay .Call this method after StartOrUpdateChannelMediaRelayEx .
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAllChannelMediaRelayEx(RtcConnection connection);

        ///
        /// <summary>
        /// Resumes the media stream relay to all target channels.
        /// After calling the PauseAllChannelMediaRelayEx method, you can call this method to resume relaying media streams to all destination channels.Call this method after PauseAllChannelMediaRelayEx .
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeAllChannelMediaRelayEx(RtcConnection connection);


        ///
        /// <summary>
        /// Enables tracing the video frame rendering process.
        /// By default, the SDK starts tracing the video rendering event automatically when the local user successfully joins the channel. You can call this method at an appropriate time according to the actual application scenario to customize the tracing process.
        /// After the local user leaves the current channel, the SDK automatically resets the time point to the next time when the user successfully joins the channel.
        /// The SDK starts tracing the rendering status of the video frames in the channel from the moment this method is successfully called and reports information about the event through the OnVideoRenderingTracingResult callback.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartMediaRenderingTracingEx(RtcConnection connection);
    }
}