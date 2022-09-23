using System;
using video_track_id_t = System.UInt32;

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
        /// 0: Success.&lt; 0: Failure.-1: A general error occurs (no specified reason).-2: An invalid parameter is used.-7: The SDK is not initialized.-22: The resource request failed. The SDK fails to allocate resources because your app consumes too many system resources or the system resources are insufficient.-101: The App ID is invalid.
        /// </returns>
        ///
        public abstract int Initialize(RtcEngineContext context);

        ///
        /// <summary>
        /// Releases the IRtcEngine instance.
        /// This method releases all resources used by the Agora SDK. Use this method for apps in which users occasionally make voice or video calls. When users do not make calls, you can free up resources for other operations.After a successful method call, you can no longer use any method or callback in the SDK anymore. If you want to use the real-time communication functions again, you must call CreateAgoraRtcEngine and Initialize to create a new IRtcEngine instance.If you want to create a new IRtcEngine instance after destroying the current one, ensure that you wait till the Dispose method execution to complete.
        /// </summary>
        ///
        /// <param name="sync"> true: Synchronous call. Agora suggests calling this method in a sub-thread to avoid congestion in the main thread because the synchronous call and the app cannot move on to another task until the resources used by IRtcEngine are released. Besides, you cannot call Dispose in any method or callback of the SDK. Otherwise, the SDK cannot release the resources until the callbacks return results, which may result in a deadlock. The SDK automatically detects the deadlock and converts this method into an asynchronous call, causing the test to take additional time.false: Asynchronous call. The app can move on to another task, no matter the resources used by IRtcEngine are released or not. Do not immediately uninstall the SDK's dynamic library after the call; otherwise, it may cause a crash due to the SDK clean-up thread not quitting.</param>
        ///
        public abstract void Dispose(bool sync = false);

        ///
        /// <summary>
        /// Sets the channel profile.
        /// After initializing the SDK, the default channel profile is the live streaming profile. You can call this method to set the usage scenario of Agora channel. The Agora SDK differentiates channel profiles and applies optimization algorithms accordingly. For example, it prioritizes smoothness and low latency for a video call and prioritizes video quality for interactive live video streaming.To ensure the quality of real-time communication, Agora recommends that all users in a channel use the same channel profile.This method must be called and set before JoinChannel [2/2], and cannot be set again after joining the channel.
        /// </summary>
        ///
        /// <param name="profile"> The channel profile. See CHANNEL_PROFILE_TYPE .</param>
        ///
        /// <returns>
        /// 0(ERR_OK): Success.&lt; 0: Failure.-2(ERR_INVALID_ARGUMENT): The parameter is invalid.-7(ERR_NOT_INITIALIZED): The SDK is not initialized.
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
        ///  "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "= ", ".", "&gt;", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," </param>
        ///
        /// <param name="token"> The token generated on your server for authentication. See </param>
        ///
        /// <param name="info"> (Optional) Reserved for future use.</param>
        ///
        /// <param name="uid"> The user ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to 232-1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and returns it in the OnJoinChannelSuccess callback. Your application must record and maintain the returned user ID, because the SDK does not do so.</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in the ChannelMediaOptions structure is invalid. You need to pass in a valid parameter and join the channel again.
        /// -3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: IRtcEngineThe internal state of the object is wrong. The typical cause is that you call this method to join the channel without calling StopEchoTest to stop the test after calling StartEchoTest [2/2] to start a call loop test. You need to call StopEchoTest before calling this method.
        /// -17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends using the OnConnectionStateChanged callback to get whether the user is in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.
        /// -102: The channel name is invalid. You need to pass in a valid channel name inchannelId to rejoin the channel.
        /// -121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannel(string token, string channelId, string info = "", uint uid = 0);

        ///
        /// <summary>
        /// Joins a channel with media options.
        /// This method enables users to join a channel. Users in the same channel can talk to each other, and multiple users in the same channel can start a group chat. Users with different App IDs cannot call each other.A successful call of this method triggers the following callbacks: The local client: The OnJoinChannelSuccess and OnConnectionStateChanged callbacks.The remote client: OnUserJoined , if the user joining the channel is in the Communication profile or is a host in the Live-broadcasting profile.When the connection between the client and Agora's server is interrupted due to poor network conditions, the SDK tries reconnecting to the server. When the local client successfully rejoins the channel, the SDK triggers the OnRejoinChannelSuccess callback on the local client.Compared to JoinChannel [1/2] , this method adds the options parameter to configure whether to automatically subscribe to all remote audio and video streams in the channel when the user joins the channel. By default, the user subscribes to the audio and video streams of all the other users in the channel, giving rise to usage and billings. To unsubscribe, set the options parameter or call the mute methods accordingly.This method allows users to join only one channel at a time.Ensure that the app ID you use to generate the token is the same app ID that you pass in the Initialize method; otherwise, you may fail to join the channel by token.
        /// </summary>
        ///
        /// <param name="token"> The token generated on your server for authentication. See </param>
        ///
        /// <param name="channelId"> The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters:All lowercase English letters: a to z.All uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "= ", ".", "&gt;", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <param name="uid"> The user ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to 232-1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and returns it in the OnJoinChannelSuccess callback. Your application must record and maintain the returned user ID, because the SDK does not do so.</param>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in the ChannelMediaOptions structure is invalid. You need to pass in a valid parameter and join the channel again.-3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.-7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.-8: IRtcEngineThe internal state of the object is wrong. The typical cause is that you call this method to join the channel without calling StopEchoTest to stop the test after calling StartEchoTest [2/2] to start a call loop test. You need to call StopEchoTest before calling this method.-17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends using the OnConnectionStateChanged callback to get whether the user is in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.-102: The channel name is invalid. You need to pass in a valid channel name inchannelId to rejoin the channel.-121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
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
        /// 0: Success.&lt; 0: Failure.-2: The value of a member in the ChannelMediaOptions structure is invalid. For example, the token or the user ID is invalid. You need to fill in a valid parameter.-7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.-8: The internal state of the IRtcEngine object is wrong. The possible reason is that the user is not in the channel. Agora recommends using the OnConnectionStateChanged callback to get whether the user is in the channel. If you receive the CONNECTION_STATE_DISCONNECTED (1) or CONNECTION_STATE_FAILED (5) state, the user is not in the channel. You need to call JoinChannel [2/2] to join a channel before calling this method.
        /// </returns>
        ///
        public abstract int UpdateChannelMediaOptions(ChannelMediaOptions options);

        ///
        /// <summary>
        /// Leaves a channel.
        /// This method releases all resources related to the session. This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel.After joining the channel, you must call this method or LeaveChannel [2/2] to end the call, otherwise, the next call cannot be started.If you successfully call this method and leave the channel, the following callbacks are triggered:The local client: OnLeaveChannel .The remote client: OnUserOffline , if the user joining the channel is in the Communication profile, or is a host in the Live-broadcasting profile.If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1(ERR_FAILED): A general error occurs (no specified reason).-2 (ERR_INVALID_ARGUMENT): The parameter is invalid.-7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        ///
        public abstract int LeaveChannel();

        ///
        /// <summary>
        /// Leaves a channel.
        /// If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.This method lets the user leave the channel, for example, by hanging up or exiting the call.After joining the channel, you must call this method or LeaveChannel [1/2] No matter whether you are currently in a call or not, you can call this method without side effects. This method releases all resources related to the session.This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel. After you leave the channel, the SDK triggers the OnLeaveChannel callback. A successful call of this method triggers the following callbacks: The local client: OnLeaveChannel
        /// The remote client: OnUserOffline , if the user joining the channel is in the COMMUNICATION profile, or is a host in the LIVE_BROADCASTING profile.
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
        /// Gets a new token when the current token expires after a period of time.
        /// You can use this method to pass a new token to the SDK. A token expires after a certain period of time. In the following two cases, the app should call this method to pass in a new token. Failure to do so will result in the SDK disconnecting from the server.The SDK triggers the OnTokenPrivilegeWillExpire callback.The OnConnectionStateChanged callback reports CONNECTION_CHANGED_TOKEN_EXPIRED(9).
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
        /// This method allows a user to join the channel with the user account and a token. After the user successfully joins the channel, the SDK triggers the following callbacks:The local client: OnLocalUserRegistered , OnJoinChannelSuccess and OnConnectionStateChanged callbacks.The remote client: OnUserJoined and OnUserInfoUpdated , if the user joining the channel is in the communication profile or is a host in the live streaming profile.Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="userAccount"> The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are (89 in total):
        ///  The 26 lowercase English letters: a to z.
        ///  The 26 uppercase English letters: A to Z.
        ///  All numeric characters: 0 to 9.
        ///  Space
        ///  "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "= ", ".", "&gt;", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," </param>
        ///
        /// <param name="token"> The token generated on your server for authentication. See </param>
        ///
        /// <param name="channelId"> The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters:
        ///  All lowercase English letters: a to z.
        ///  All uppercase English letters: A to Z.
        ///  All numeric characters: 0 to 9.
        ///  Space
        ///  "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "= ", ".", "&gt;", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", "," </param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.2: The parameter is invalid.3: The initialization of the SDK fails. You can try to initialize the SDK again.5: The request is rejected.17: The request to join the channel is rejected. Since the SDK only supports users to join one IRtcEngine channel at a time; this error code will be returned when the user who has joined the IRtcEngine channel calls the join channel method in the IRtcEngine class again with a valid channel name.
        /// </returns>
        ///
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        ///
        /// <summary>
        /// Joins the channel with a user account, and configures whether to automatically subscribe to audio or video streams after joining the channel.
        /// This method allows a user to join the channel with the user account. After the user successfully joins the channel, the SDK triggers the following callbacks:The local client: OnLocalUserRegistered , OnJoinChannelSuccess and OnConnectionStateChanged callbacks.The remote client: The OnUserJoined callback if the user is in the COMMUNICATION profile, and the OnUserInfoUpdated callback if the user is a host in the LIVE_BROADCASTING profile.Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions .</param>
        ///
        /// <param name="token"> The token generated on your server for authentication. See </param>
        ///
        /// <param name="channelId"> The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters:All lowercase English letters: a to z.All uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "= ", ".", "&gt;", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <param name="userAccount"> The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are (89 in total):The 26 lowercase English letters: a to z.The 26 uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "= ", ".", "&gt;", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in the ChannelMediaOptions structure is invalid. You need to pass in a valid parameter and join the channel again.-3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.-7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.-8: IRtcEngineThe internal state of the object is wrong. The typical cause is that you call this method to join the channel without calling StopEchoTest to stop the test after calling StartEchoTest [2/2] to start a call loop test. You need to call StopEchoTest before calling this method.-17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends using the OnConnectionStateChanged callback to get whether the user is in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.-102: The channel name is invalid. You need to pass in a valid channel name inchannelId to rejoin the channel.-121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options);

        ///
        /// <summary>
        /// Gets the user information by passing in the user account.
        /// After a remote user joins the channel, the SDK gets the UID and user account of the remote user, caches them in a mapping table object, and triggers the OnUserInfoUpdated callback on the local client. After receiving the callback, you can call this method to get the user account of the remote user from the UserInfo object by passing in the user ID.
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
        /// After a remote user joins the channel, the SDK gets the UID and user account of the remote user, caches them in a mapping table object, and triggers the OnUserInfoUpdated callback on the local client. After receiving the callback, you can call this method to get the user account of the remote user from the UserInfo object by passing in the user ID.
        /// </summary>
        ///
        /// <param name="uid"> The user ID.</param>
        ///
        /// <param name="userInfo"> Input and output parameter. The object that identifies the user information UserInfo .
        ///  Input: A UserInfo object.Output: A UserInfo object that contains the user account and user ID of the user.</param>
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
        /// Adds event handlers.
        /// The SDK uses the IRtcEngineEventHandler class to send callbacks to the app. The app inherits the methods of this class to receive these callbacks. All methods in this interface class have default (empty) implementations. Therefore, the application can only inherit some required events. In the callbacks, avoid time-consuming tasks or calling APIs that can block the thread, such as the SendStreamMessage method.
        /// Otherwise, the SDK may not work properly.
        /// </summary>
        ///
        /// <param name="engineEventHandler"> Callback events to be added. </param>
        ///
        public abstract void InitEventHandler(IRtcEngineEventHandler engineEventHandler);
        #endregion

        #region Audio management
        ///
        /// <summary>
        /// Enables the audio module.
        /// The audio mode is enabled by default.This method enables the internal engine and can be called anytime after initialization. It is still valid after one leaves channel.This method enables the audio module and takes some time to take effect. Agora recommends using the following API methods to control the audio module separately: EnableLocalAudio : Whether to enable the microphone to create the local audio stream. MuteLocalAudioStream : Whether to publish the local audio stream. MuteRemoteAudioStream : Whether to subscribe and play the remote audio stream. MuteAllRemoteAudioStreams : Whether to subscribe to and play all remote audio streams.
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
        /// You can call this method either before or after joining a channel.In scenarios requiring high-quality audio, such as online music tutoring, Agora recommends you set profile as AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4).If you want to set the audio scenario, call Initialize and set RtcEngineContext struct.
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
        /// <param name="volume"> The volume of the user. The value range is [0,400].0: Mute.100: (Default) The original volume.400: Four times the original volume (amplifying the audio signals by four times).</param>
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
        /// <param name="mute"> true: Mute the recording signal.false: (Default) Do not mute the recording signal.</param>
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
        ///  0: Mute.
        ///  100: (Default) The original volume.
        ///  400: Four times the original volume (amplifying the audio signals by four times). </param>
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
        /// Enables/Disables the local audio capture.
        /// The audio function is enabled by default. This method disables or re-enables the local audio function to stop or restart local audio capturing.This method does not affect receiving or playing the remote audio streams, and EnableLocalAudio (false) is applicable to scenarios where the user wants to receive remote audio streams without sending any audio stream to other users in the channel.Once the local audio function is disabled or re-enabled, the SDK triggers the OnLocalAudioStateChanged callback, which reports LOCAL_AUDIO_STREAM_STATE_STOPPED (0) or LOCAL_AUDIO_STREAM_STATE_RECORDING (1).This method is different from the MuteLocalAudioStream method:EnableLocalAudio: Disables/Re-enables the local audio capturing and processing. If you disable or re-enable local audio capturing using the EnableLocalAudio method, the local user might hear a pause in the remote audio playback.MuteLocalAudioStream: Sends/Stops sending the local audio streams.You can call this method either before or after joining a channel. Calling it before joining a channel only sets the device state, and it takes effect immediately after you join the channel.
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
        /// <param name="mute"> Whether to stop publishing the local audio stream.true: Stop publishing the local audio stream.false: (Default) Resumes publishing the local audio stream.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalAudioStream(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio streams of all remote users.
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users.Call this method after joining a channel.If you do not want to subscribe the audio streams of remote users before joining a channel, you can call JoinChannel [2/2] and set autoSubscribeAudio as false.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users:true: Stop subscribing to the audio streams of all remote users.false: (Default) Subscribe to the audio streams of all remote users by default.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio streams of all remote users by default.
        /// Call this method after joining a channel. After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all subsequent users.If you need to resume subscribing to the audio streams of remote users in the channel after calling this method, do the following:To resume subscribing to the audio stream of a specified user, call MuteRemoteAudioStream (false), and specify the user ID.To resume subscribing to the audio streams of multiple remote users, call MuteRemoteAudioStream(false) multiple times.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users by default.true: Stop subscribing to the audio streams of all remote users by default.false: (Default) Subscribe to the audio streams of all remote users by default.</param>
        ///
        /// <returns>
        /// 0: Success. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        ///
        /// <summary>
        /// Cancels or resumes subscribing to the specified remote user's audio stream.
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the specified user.</param>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio stream of the specified user.
        ///  true: Unsubscribe from the specified user's audio stream.false: (Default) Subscribes to the specified user's audio stream.</param>
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
        /// Call this method either before joining a channel or during a call. If this method is called before joining a channel, the call starts in the video mode. Call DisableVideo to disable the video mode.A successful call of this method triggers the OnRemoteVideoStateChanged callback on the remote client.This method enables the internal engine and is valid after leaving the channel.This method resets the internal engine and takes some time to take effect. Agora recommends using the following API methods to control the video engine modules separately: EnableLocalVideo : Whether to enable the camera to create the local video stream. MuteLocalVideoStream : Whether to publish the local video stream. MuteRemoteVideoStream : Whether to subscribe to and play the remote video stream. MuteAllRemoteVideoStreams : Whether to subscribe to and play all remote video streams.
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
        /// This method disables video. You can call this method either before or after joining a channel. If you call it before joining a channel, an audio call starts when you join the channel. If you call it after joining a channel, a video call switches to an audio call. Call EnableVideo to enable video.A successful call of this method triggers the OnUserEnableVideo (false) callback on the remote client.This method affects the internal engine and can be called after leaving the channel.This method resets the internal engine and takes some time to take effect. Agora recommends using the following API methods to control the video engine modules separately: EnableLocalVideo : Whether to enable the camera to create the local video stream. MuteLocalVideoStream : Whether to publish the local video stream. MuteRemoteVideoStream : Whether to subscribe to and play the remote video stream. MuteAllRemoteVideoStreams : Whether to subscribe to and play all remote video streams.
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
        /// This method starts the local video preview before joining the channel. Before calling this method, ensure that you do the following:Call EnableVideo to enable the video.The local preview enables the mirror mode by default.After the local video preview is enabled, if you call LeaveChannel [1/2] to exit the channel, the local preview remains until you call StopPreview [1/2] to disable it.
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
        /// This method starts the local video preview before joining the channel. Before calling this method, ensure that you do the following:
        /// Call EnableVideo to enable the video. The local preview enables the mirror mode by default.After the local video preview is enabled, if you call LeaveChannel [1/2] StopPreview [2/2] to disable it.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source, see VIDEO_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartPreview(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Stops the local video preview.
        /// After calling StartPreview [1/2] to start the preview, if you want to close the local video preview, please call this method.Please call this method before joining a channel or after leaving a channel.
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
        /// After calling StartPreview [2/2] to start the preview, if you want to close the local video preview, please call this method.Please call this method before joining a channel or after leaving a channel.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source, see VIDEO_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopPreview(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Sets the video encoder configuration.
        /// Sets the encoder configuration for the local video.You can call this method either before or after joining a channel. If you don't need to set the video encoder configuration after joining a channel,
        /// Agora recommends you calling this method before the EnableVideo method to reduce the rendering time of the first video frame.
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
        /// @ignore
        ///
        public abstract int SetupRemoteVideo(VideoCanvas canvas);

        ///
        /// @ignore
        ///
        public abstract int SetupLocalVideo(VideoCanvas canvas);

        ///
        /// <summary>
        /// Updates the display mode of the local video view.
        /// After initializing the local video view, you can call this method to update its rendering and mirror modes. It affects only the video view that the local user sees, not the published local video stream.During a call, you can call this method as many times as necessary to update the display mode of the local video view.
        /// </summary>
        ///
        /// <param name="renderMode"> The local video display mode. See RENDER_MODE_TYPE .</param>
        ///
        /// <param name="mirrorMode"> The rendering mode of the local video view. See VIDEO_MIRROR_MODE_TYPE .If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.</param>
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
        /// <param name="mirrorMode"> The mirror mode of the remote user view. For details, see VIDEO_MIRROR_MODE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

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
        /// Cancels or resumes subscribing to the specified remote user's video stream.
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the specified user.</param>
        ///
        /// <param name="mute"> Whether to subscribe to the specified remote user's video stream.true: Unsubscribe from the specified user's video stream.false: (Default) Subscribes to the specified user's video stream.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteVideoStream(uint uid, bool mute);

        ///
        /// <summary>
        /// Enables/Disables the local video capture.
        /// This method disables or re-enables the local video capturer, and does not affect receiving the remote video stream.After calling EnableVideo , the local video capturer is enabled by default. You can call EnableLocalVideo (false) to disable the local video capturer. If you want to re-enable the local video, call EnableLocalVideo(true).After the local video capturer is successfully disabled or re-enabled, the SDK triggers the OnRemoteVideoStateChanged callback on the remote client.You can call this method either before or after joining a channel.This method enables the internal engine and is valid after leaving the channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the local video capture.true: (Default) Enable the local video capture.false: Disables the local video capture. Once the local video is disabled, the remote users can no longer receive the video stream of this user, while this user can still receive the video streams of the other remote users. When set to false, this method does not require a local camera.</param>
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
        /// <summary>
        /// Stops or resumes subscribing to the video streams of all remote users by default.
        /// Call this method after joining a channel. After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all subsequent users.If you need to resume subscribing to the audio streams of remote users in the channel after calling this method, do the following:To resume subscribing to the audio stream of a specified user, call MuteRemoteVideoStream (false), and specify the user ID.To resume subscribing to the audio streams of multiple remote users, call MuteRemoteVideoStream(false) multiple times.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users by default.true: Stop subscribing to the audio streams of all remote users by default.false: (Default) Resume subscribing to the audio streams of all remote users by default.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
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
        /// The video images captured by the camera can have color distortion. The color enhancement feature intelligently adjusts video characteristics such as saturation and contrast to enhance the video color richness and color reproduction, making the video more vivid.You can call this method to enable the color enhancement feature and set the options of the color enhancement effect.Call this method after calling EnableVideo .The color enhancement feature has certain performance requirements on devices. With color enhancement turned on, Agora recommends that you change the color enhancement level to one that consumes less performance or turn off color enhancement if your device is experiencing severe heat problems.Both this method and SetExtensionProperty can turn on color enhancement:When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.
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
        /// The low-light enhancement feature can adaptively adjust the brightness value of the video captured in situations with low or uneven lighting, such as backlit, cloudy, or dark scenes. It restores or highlights the image details and improves the overall visual effect of the video.You can call this method to enable the color enhancement feature and set the options of the color enhancement effect.Call this method after calling EnableVideo .Dark light enhancement has certain requirements for equipment performance. The low-light enhancement feature has certain performance requirements on devices. If your device overheats after you enable low-light enhancement, Agora recommends modifying the low-light enhancement options to a less performance-consuming level or disabling low-light enhancement entirely.Both this method and SetExtensionProperty can turn on low-light enhancement:When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.
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
        /// @ignore
        ///
        public abstract int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options);

        ///
        /// <summary>
        /// Sets video noise reduction.
        /// Underlit environments and low-end video capture devices can cause video images to contain significant noise, which affects video quality. In real-time interactive scenarios, video noise also consumes bitstream resources and reduces encoding efficiency during encoding.You can call this method to enable the video noise reduction feature and set the options of the video noise reduction effect.Call this method after calling EnableVideo .Video noise reduction has certain requirements for equipment performance. If your device overheats after you enable video noise reduction, Agora recommends modifying the video noise reduction options to a less performance-consuming level or disabling video noise reduction entirely.Both this method and SetExtensionProperty can turn on video noise reduction function:When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.
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
        /// Starts video capture with a primary camera.
        /// </summary>
        ///
        /// <param name="config"> The configuration of the video capture with a primary camera. See CameraCapturerConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartPrimaryCameraCapture(CameraCapturerConfiguration config);

        ///
        /// <summary>
        /// Starts video capture with a secondary camera.
        /// </summary>
        ///
        /// <param name="config"> The configuration of the video capture with a primary camera. See CameraCapturerConfiguration .</param>
        ///
        public abstract int StartSecondaryCameraCapture(CameraCapturerConfiguration config);

        ///
        /// <summary>
        /// Stops capturing video through a primary camera.
        /// You can call this method to stop capturing video through the primary camera after calling the StartPrimaryCameraCapture .
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopPrimaryCameraCapture();

        ///
        /// <summary>
        /// Stops capturing video through the secondary camera.
        /// You can call this method to stop capturing video through the secondary camera after calling the StartSecondaryCameraCapture .
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopSecondaryCameraCapture();

        ///
        /// <summary>
        /// Starts sharing the primary screen.
        /// </summary>
        ///
        /// <param name="config"> The configuration of the captured screen. See ScreenCaptureConfiguration .</param>
        ///
        public abstract int StartPrimaryScreenCapture(ScreenCaptureConfiguration config);

        ///
        /// <summary>
        /// Starts sharing a secondary screen.
        /// </summary>
        ///
        /// <param name="config"> The configuration of the captured screen. See ScreenCaptureConfiguration .</param>
        ///
        public abstract int StartSecondaryScreenCapture(ScreenCaptureConfiguration config);

        ///
        /// <summary>
        /// Stop sharing the first screen.
        /// After calling StartPrimaryScreenCapture , you can call this method to stop sharing the first screen.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopPrimaryScreenCapture();

        ///
        /// <summary>
        /// Stops sharing the secondary screen.
        /// After calling StartSecondaryScreenCapture , you can call this method to stop sharing the secondary screen.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopSecondaryScreenCapture();
        #endregion

        #region Media player
        ///
        /// <summary>
        /// Creates a media player instance. 
        /// </summary>
        ///
        /// <returns>
        /// The IMediaPlayer instance, if the method call succeeds.An empty pointer , if the method call fails.
        /// </returns>
        ///
        public abstract IMediaPlayer CreateMediaPlayer();

        ///
        /// <summary>
        /// Destroys the media player instance.
        /// </summary>
        ///
        /// <param name="mediaPlayer">  IMediaPlayer object.</param>
        ///
        public abstract void DestroyMediaPlayer(IMediaPlayer mediaPlayer);
        #endregion

        #region Audio pre-process and post-process
        ///
        /// <summary>
        /// Sets audio advanced options.
        /// If you have advanced audio processing requirements, such as capturing and sending stereo audio, you can call this method to set advanced audio options.This method is for Android and iOS only.Call this method after calling JoinChannel [2/2] , EnableAudio and EnableLocalAudio .
        /// </summary>
        ///
        /// <param name="options"> The advanced options for audio. See AdvancedAudioOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAdvancedAudioOptions(AdvancedAudioOptions options);
        #endregion

        #region Video pre-process and post-process
        ///
        /// <summary>
        /// Sets the image enhancement options.
        /// Enables or disables image enhancement, and sets the options.Call this method before calling EnableVideo or StartPreview [1/2] .
        /// </summary>
        ///
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE .</param>
        ///
        /// <param name="enabled"> Whether to enable the image enhancement function:true: Enable the image enhancement function.false: (Default) Disable the image enhancement function.</param>
        ///
        /// <param name="options"> The image enhancement options. See BeautyOptions .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Enables/Disables the virtual background.
        /// The virtual background function allows you to replace the original background image of the local user or to blur the background. After successfully enabling the virtual background function, all users in the channel can see the customized background.Call this method before calling EnableVideo or StartPreview [1/2] .This function requires a high-performance device. Agora recommends that you use this function on devices with the following chips:Snapdragon 700 series 750G and laterSnapdragon 800 series 835 and laterDimensity 700 series 720 and laterKirin 800 series 810 and laterKirin 900 series 980 and laterDevices with an i5 CPU and betterDevices with an A9 chip and better, as follows:iPhone 6S and lateriPad Air 3rd generation and lateriPad 5th generation and lateriPad Pro 1st generation and lateriPad mini 5th generation and laterAgora recommends that you use this function in scenarios that meet the following conditions:A high-definition camera device is used, and the environment is uniformly lit.The captured video image is uncluttered, the user's portrait is half-length and largely unobstructed, and the background is a single color that differs from the color of the user's clothing.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable virtual background:true: Enable virtual background.false: Disable virtual background.</param>
        ///
        /// <param name="backgroundSource"> The custom background image. See VirtualBackgroundSource . To adapt the resolution of the custom background image to that of the video captured by the SDK, the SDK scales and crops the custom background image while ensuring that the content of the custom background image is not distorted.</param>
        ///
        /// <param name="segproperty"> Processing properties for background images. See SegmentationProperty .</param>
        ///
        /// <param name="type"> Type of the video source. See MEDIA_SOURCE_TYPE .In this method, this parameter supports only the following two settings:The default value is PRIMARY_CAMERA_SOURCE.If you want to use the second camera to capture video, set this parameter to SECONDARY_CAMERA_SOURCE.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-1: The custom background image does not exist. Check the value of source in VirtualBackgroundSource .-2: The color format of the custom background image is invalid. Check the value of color in VirtualBackgroundSource .-3: The device does not support virtual background.
        /// </returns>
        ///
        public abstract int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Enables/Disables the super resolution algorithm for a remote user's video stream.
        /// This function can effectively improve the resolution of the remote video picture seen by the local user, that is, the width and height (pixels) of the video received by the specified remote user are enlarged to 2 times original size.After calling this method, you can confirm whether super resolution is successfully enabled through the remote video stream statistics ( RemoteVideoStats ) in the OnRemoteVideoStats callback:If the parameter superResolutionType >0: Super resolution is enabled.If parameter superResolutionType =0: Super resolution is not enabled.The super resolution feature requires extra system resources. To balance the visual experience and system resource consumption, this feature can only be enabled for a single remote user. If the local user uses super resolution on Android, the original resolution of the remote user's video cannot exceed 640 × 360 pixels; if the local user uses super resolution on iOS, the original resolution of the remote user's video cannot exceed 640 × 480 pixels.This method is for Android and iOS only.Before calling this method, ensure that you have integrated the following dynamic libraries:Android: libagora_super_resolution_extension.soiOS: AgoraSuperResolutionExtension.xcframeworkBecause this method has certain system performance requirements, Agora recommends that you use the following devices or better:Android:VIVO: V1821A, NEX S, 1914A, 1916A, 1962A, 1824BA, X60, X60 ProOPPO: PCCM00, Find X3OnePlus: A6000Xiaomi: Mi 8, Mi 9, Mi 10, Mi 11, MIX3, Redmi K20 ProSAMSUNG: SM-G9600, SM-G9650, SM-N9600, SM-G9708, SM-G960U, SM-G9750, S20, S21HUAWEI: SEA-AL00, ELE-AL00, VOG-AL00, YAL-AL10, HMA-AL00, EVR-AN00, nova 4, nova 5 Pro, nova 6 5G, nova 7 5G, Mate 30, Mate 30 Pro, Mate 40, Mate 40 Pro, P40, P40 Pro, Huawei M6, MatePad 10.8iOS:iPhone XRiPhone XSiPhone XS MaxiPhone 11iPhone 11 ProiPhone 11 Pro MaxiPhone 12iPhone 12 miniiPhone 12 ProiPhone 12 Pro MaxiPhone 12 SE (2nd generation)iPad Pro 11-inch (3rd generation)iPad Pro 12.9-inch (3rd generation)iPad Air 3 (3rd generation)iPad Air 3 (4th generation)
        /// </summary>
        ///
        /// <param name="userId"> The user ID of the remote user.</param>
        ///
        /// <param name="enable"> Whether to enable super resolution for the remote user’s video:true: Enable super resolution.false: Disable super resolution.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableRemoteSuperResolution(uint userId, bool enable);
        #endregion

        #region Face detection
        ///
        /// <summary>
        /// Enables/Disables face detection for the local user.
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
        /// This method enables or disables in-ear monitoring.This method is for Android and iOS only.Users must use wired earphones to hear their own voices.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Enables in-ear monitoring.true: Enables in-ear monitoring.false: (Default) Disables in-ear monitoring.</param>
        ///
        /// <param name="includeAudioFilters"> The audio filter of in-ear monitoring: See EAR_MONITORING_FILTER_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableInEarMonitoring(bool enabled, int includeAudioFilters);

        ///
        /// <summary>
        /// Sets the volume of the in-ear monitor.
        /// This method is for Android and iOS only.Users must use wired earphones to hear their own voices.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="volume"> Sets the volume of the in-ear monitor. The value ranges between 0 and 100. The default value is 100.</param>
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
        /// This method mixes the specified local or online audio file with the audio from the microphone, or replaces the microphone's audio with the specified local or remote audio file. A successful method call triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback. When the audio mixing file playback finishes, the SDK triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_STOPPED) callback on the local client.You can call this method either before or after joining a channel. If you need to call StartAudioMixing [1/2] multiple times, ensure that the time interval between calling this method is more than 500 ms.If the local music file does not exist, the SDK does not support the file format, or the the SDK cannot access the music file URL, the SDK reports the warn code 701.On Android, there are following considerations:To use this method, ensure that the Android device is v4.2 or later, and the API version is v16 or later.If you need to play an online music file, Agora does not recommend using the redirected URL address. Some Android devices may fail to open a redirected URL address.If you call this method on an emulator, ensure that the music file is in the /sdcard/ directory and the format is MP3.
        /// </summary>
        ///
        /// <param name="filePath"> If you have loaded the audio effect into memory via PreloadEffect , make sure this parameter is the same as the filePath set in PreloadEffect. </param>
        ///
        /// <param name="loopback"> Whether to play music files only on the local client:true: Only play music files on the local client so that only the local user can hear the music.false: Publish music files to remote clients so that both the local user and remote users can hear the music.</param>
        ///
        /// <param name="cycle"> The number of times the music file plays.>= 0: The number of playback times. For example, 0 means that the SDK does not play the music file while 1 means that the SDK plays once.-1: Play the audio file in an infinite loop.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle);

        ///
        /// <summary>
        /// Starts playing the music file.
        /// This method mixes the specified local or online audio file with the audio from the microphone, or replaces the microphone's audio with the specified local or remote audio file. A successful method call triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback. When the audio mixing file playback finishes, the SDK triggers the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_STOPPED) callback on the local client.On Android, there are following considerations:To use this method, ensure that the Android device is v4.2 or later, and the API version is v16 or later.If you need to play an online music file, Agora does not recommend using the redirected URL address. Some Android devices may fail to open a redirected URL address.If you call this method on an emulator, ensure that the music file is in the /sdcard/ directory and the format is MP3.For the audio file formats supported by this method, see What formats of audio files the Agora RTC SDK support.You can call this method either before or after joining a channel. If you need to call StartAudioMixing [2/2] multiple times, ensure that the time interval between calling this method is more than 500 ms.If the local music file does not exist, the SDK does not support the file format, or the the SDK cannot access the music file URL, the SDK reports the warn code 701.
        /// </summary>
        ///
        /// <param name="filePath"> File path:Android: The file path, which needs to be accurate to the file name and suffix. Agora supports using a URI address, an absolute path, or a path that starts with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example: content://com.android.providers.media.documents/document/audio%3A14441.Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4.iOS or macOS: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: /var/mobile/Containers/Data/audio.mp4.</param>
        ///
        /// <param name="loopback"> Whether to only play music files on the local client:true: Only play music files on the local client so that only the local user can hear the music.false: Publish music files to remote clients so that both the local user and remote users can hear the music.</param>
        ///
        /// <param name="cycle"> The number of times the music file plays.>= 0: The number of playback times. For example, 0 means that the SDK does not play the music file while 1 means that the SDK plays once.-1: Play the audio file in an infinite loop.</param>
        ///
        /// <param name="startPos"> The playback position (ms) of the music file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
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
        /// Pauses playing the music file.
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
        /// This method adjusts the audio mixing volume on both the local client and remote clients.Call this method after the StartAudioMixing [2/2] method.
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
        /// This method adjusts the audio mixing volume on the remote clients.Call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
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
        /// This method helps to troubleshoot audio volume‑related issues.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// The audio mixing volume, if this method call succeeds. The value range is [0,100].&lt; 0: Failure.
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
        /// This method retrieves the audio mixing volume for local playback. You can use it to troubleshoot audio volume related issues.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// The audio mixing volume, if this method call succeeds. The value range is [0,100].&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingPlayoutVolume();

        ///
        /// <summary>
        /// Retrieves the duration (ms) of the music file.
        /// Retrieves the total duration (ms) of the audio file.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// >= 0: The audio mixing duration, if this method call succeeds.&lt; 0: Failure.
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
        /// >= 0: The current playback position (ms) of the audio mixing, if this method call succeeds. 0 represents that the current music file does not start playing.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingCurrentPosition();

        ///
        /// <summary>
        /// Sets the audio mixing position.
        /// Call this method to set the playback position of the music file to a different starting position, rather than playing the file from the beginning.You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged(AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="pos"> Integer. The playback position (ms).</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioMixingPosition(int pos /*in ms*/);

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
        /// The volume range is [0,100]. The default value is 100, the original volume.Call this method after the PlayEffect method.
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
        /// Call this method after the PlayEffect method.
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
        /// To ensure smooth communication, limit the size of the audio effect file. Agora recommends using this method to preload the audio effect before calling JoinChannel [2/2].This method does not support online audio effect files.For the audio file formats supported by this method, see What formats of audio files the Agora RTC SDK support.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
        ///
        /// <param name="filePath"> File path:Android: The file path, which needs to be accurate to the file name and suffix. Agora supports using a URI address, an absolute path, or a path that starts with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example: content://com.android.providers.media.documents/document/audio%3A14441.Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4.iOS or macOS: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: /var/mobile/Containers/Data/audio.mp4.</param>
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
        /// Plays the specified local or online sound effect file.
        /// To play multiple audio effect files at the same time, call this method multiple times with different soundId and filePath. For the best user experience, Agora recommends playing no more than three audio effect files at the same time. After the playback of an audio effect file completes, the SDK triggers the OnAudioEffectFinished callback.Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique. If you have loaded the audio effect into memory via PreloadEffect , make sure this parameter is the same as the soundId set in PreloadEffect.</param>
        ///
        /// <param name="filePath"> Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: C:\music\audio.mp4. Supported audio formats include MP3, AAC, M4A, MP4, WAV, and 3GP. See supported audio formats.If you have loaded the audio effect into memory via PreloadEffect , make sure this parameter is the same as the filePath set in PreloadEffect.</param>
        ///
        /// <param name="loopCount"> The number of times the audio effect loops.>= 0: The number of playback times. For example, 1 means loop one time, which means playing the audio effect two times in total.-1: Play the music file in an infinite loop.</param>
        ///
        /// <param name="pitch"> The pitch of the audio effect. The value range is 0.5 to 2.0. The default value is 1.0, which means the original pitch. The lower the value, the lower the pitch.</param>
        ///
        /// <param name="pan"> The spatial position of the audio effect. The value ranges between -1.0 and 1.0, where:-1.0: The audio effect displays to the left.0.0: The audio effect displays ahead.1.0: The audio effect displays to the right.</param>
        ///
        /// <param name="gain"> The volume of the audio effect. The value range is 0.0 to 100.0. The default value is 100.0, which means the original volume. The smaller the value, the lower the volume.</param>
        ///
        /// <param name="publish"> Whether to publish the audio effect to the remote users.true: Publish the audio effect to the remote users. Both the local user and remote users can hear the audio effect.false: Do not publish the audio effect to the remote users. Only the local user can hear the audio effect.</param>
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
        /// Plays all audio effects.
        /// After calling PreloadEffect multiple times to preload multiple audio effects into the memory, you can call this method to play all the specified audio effects for all users in the channel.
        /// </summary>
        ///
        /// <param name="loopCount"> The number of times the audio effect loops:-1: Play the audio effect in an indefinite loop until you call StopEffect or StopAllEffects .0: Play the audio effect once.1: Play the audio effect twice.</param>
        ///
        /// <param name="pitch"> The pitch of the audio effect. The value ranges between 0.5 and 2.0. The default value is 1.0 (original pitch). The lower the value, the lower the pitch.</param>
        ///
        /// <param name="pan"> The spatial position of the audio effect. The value ranges between -1.0 and 1.0:-1.0: The audio effect shows on the left.0: The audio effect shows ahead.1.0: The audio effect shows on the right.</param>
        ///
        /// <param name="gain"> The volume of the audio effect. The value range is [0, 100]. The default value is 100 (original volume). The smaller the value, the lower the volume.</param>
        ///
        /// <param name="publish"> Whether to publish the audio effect to the remote users:true: Publish the audio effect to the remote users. Both the local user and remote users can hear the audio effect.false: Do not publish the audio effect to the remote users. Only the local user can hear the audio effect.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false);

        ///
        /// <summary>
        /// Gets the volume of a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect.</param>
        ///
        /// <returns>
        /// The volume of the specified audio effect, if the method call succeeds. The value range is [0,100]. 100 represents the original volume. &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetVolumeOfEffect(int soundId);

        ///
        /// <summary>
        /// Sets the volume of a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
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
        /// Pauses playing a specified audio effect file.
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
        /// Pauses playing all audio effect files.
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
        /// Resumes playing all audio effects.
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
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
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
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
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
        ///  Android: The file path, which needs to be accurate to the file name and suffix. Agora supports using a URI address, an absolute path, or a path that starts with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example: content://com.android.providers.media.documents/document/audio%3A14441.
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
        /// In music education, physical education, and other scenarios, teachers might need to use a metronome so that students can practice with the correct beat. The meter is composed of a downbeat and upbeats. The first beat of each measure is called a downbeat, and the rest are called upbeats.In this method, you need to set the paths of the upbeat and downbeat files, the number of beats per measure, the tempo, and whether to send the sound of the metronome to remote users.This method is for Android and iOS only.After enabling the virtual metronome, the SDK plays the specified audio effect file from the beginning and controls the playback duration of each file according to beatsPerMinuteyou set in AgoraRhythmPlayerConfig . For example, if you set beatsPerMinute as 60, the SDK plays one beat every second. If the file duration exceeds the beat duration, the SDK only plays the audio within the beat duration.By default, the sound of the virtual metronome is published in the channel. If you do not want the sound to be heard by the remote users, you can set publishRhythmPlayerTrack in ChannelMediaOptions as false.
        /// </summary>
        ///
        /// <param name="sound1"> The absolute path or URL address (including the filename extensions) of the file for the downbeat. For example: C:\music\audio.mp4. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK v4.0.0 support.</param>
        ///
        /// <param name="sound2"> The absolute path or URL address (including the filename extensions) of the file for the upbeats. For example: C:\music\audio.mp4. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK v4.0.0 support.</param>
        ///
        /// <param name="config"> The metronome configuration. See AgoraRhythmPlayerConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.-22: Cannot find audio effect files. You need to set the correct paths for sound1 and sound2.
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
        /// This method is for Android and iOS only.After enabling the virtual metronome, the SDK plays the specified audio effect file from the beginning and controls the playback duration of each file according to beatsPerMinuteyou set in AgoraRhythmPlayerConfig . For example, if you set beatsPerMinute as 60, the SDK plays one beat every second. If the file duration exceeds the beat duration, the SDK only plays the audio within the beat duration.By default, the sound of the virtual metronome is published in the channel. If you do not want the sound to be heard by the remote users, you can set publishRhythmPlayerTrack in ChannelMediaOptions as false.After calling StartRhythmPlayer , you can call this method to reconfigure the virtual metronome.
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
        /// Call this method to set a preset voice beautifier effect for the local user who sends an audio stream. After setting a voice beautifier effect, all users in the channel can hear the effect. You can set different voice beautifier effects for different scenarios. For better voice effects, Agora recommends that you call SetAudioProfile [1/2] and set scenario to AUDIO_SCENARIO_GAME_STREAMING(3) and profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before calling this method.You can call this method either before or after joining a channel.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1)This method works best with the human voice. Agora does not recommend using this method for audio containing music.After calling SetVoiceBeautifierPreset, Agora recommends not calling the following methods, because they can override settings in SetVoiceBeautifierPreset: SetAudioEffectPreset SetAudioEffectParameters SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset
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
        /// Call this method to set an SDK preset audio effect for the local user who sends an audio stream. This audio effect does not change the gender characteristics of the original voice. After setting an audio effect, all users in the channel can hear the effect.To get better audio effect quality, Agora recommends calling and setting scenario in SetAudioProfile [1/2] as AUDIO_SCENARIO_GAME_STREAMING(3) before calling this method.You can call this method either before or after joining a channel.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1), or the method does not take effect.This method works best with the human voice. Agora does not recommend using this method for audio containing music.If you call SetAudioEffectPreset and set enumerators except for ROOM_ACOUSTICS_3D_VOICE or PITCH_CORRECTION, do not call SetAudioEffectParameters ; otherwise, SetAudioEffectPreset is overridden.After calling SetAudioEffectPreset, Agora recommends not calling the following methods, or the settings in SetAudioEffectPreset are overridden: SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset
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
        /// Call this method to set a preset voice beautifier effect for the local user who sends an audio stream. After setting an audio effect, all users in the channel can hear the effect. You can set different voice beautifier effects for different scenarios. To achieve better audio effect quality, Agora recommends that you call SetAudioProfile [1/2] and set the profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) and scenario to AUDIO_SCENARIO_GAME_STREAMING(3) before calling this method.You can call this method either before or after joining a channel.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1)This method works best with the human voice. Agora does not recommend using this method for audio containing music.After calling SetVoiceConversionPreset, Agora recommends not calling the following methods, or the settings in SetVoiceConversionPreset are overridden: SetAudioEffectPreset SetAudioEffectParameters SetVoiceBeautifierPreset SetVoiceBeautifierParameters SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb
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
        /// Call this method to set the following parameters for the local user who sends an audio stream:3D voice effect: Sets the cycle period of the 3D voice effect.Pitch correction effect: Sets the basic mode and tonic pitch of the pitch correction effect. Different songs have different modes and tonic pitches. Agora recommends bounding this method with interface elements to enable users to adjust the pitch correction interactively.After setting the audio parameters, all users in the channel can hear the effect.You can call this method either before or after joining a channel.To get better audio effect quality, Agora recommends calling and setting scenario in SetAudioProfile [1/2] as AUDIO_SCENARIO_GAME_STREAMING(3) before calling this method.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1), or the method does not take effect.This method works best with the human voice. Agora does not recommend using this method for audio containing music.After calling SetAudioEffectParameters, Agora recommends not calling the following methods, or the settings in SetAudioEffectParameters are overridden: SetAudioEffectPreset SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset
        /// </summary>
        ///
        /// <param name="preset"> The options for SDK preset audio effects:ROOM_ACOUSTICS_3D_VOICE, 3D voice effect:You need to set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_MUSIC_STANDARD_STEREO(3) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before setting this enumerator; otherwise, the enumerator setting does not take effect.If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect.PITCH_CORRECTION; pitch correction effect: To achieve better audio effect quality, Agora recommends setting the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before setting this enumerator.</param>
        ///
        /// <param name="param1"> If you set preset to ROOM_ACOUSTICS_3D_VOICE, param1 indicates the cycle period of the 3D voice effect. The value range is [1,60], in seconds. The default value is 10, indicating that the voice moves around you every 10 seconds. If you set preset to PITCH_CORRECTION, param1 indicates the basic mode of the pitch correction effect:1: (Default) Natural major scale.2: Natural minor scale.3: Japanese pentatonic scale.</param>
        ///
        /// <param name="param2"> If you set preset to ROOM_ACOUSTICS_3D_VOICE, you need to set param2 to 0. If you set preset to PITCH_CORRECTION, param2 indicates the tonic pitch of the pitch correction effect:1: A2: A#3: B4: (Default) C5: C#6: D7: D#8: E9: F10: F#11: G12: G#</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);

        ///
        /// <summary>
        /// Sets parameters for the preset voice beautifier effects.
        /// Call this method to set a gender characteristic and a reverberation effect for the singing beautifier effect. This method sets parameters for the local user who sends an audio stream. After setting the audio parameters, all users in the channel can hear the effect.For better voice effects, Agora recommends that you call SetAudioProfile [1/2] and set scenario to AUDIO_SCENARIO_GAME_STREAMING(3) and profile to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) before calling this method.You can call this method either before or after joining a channel.Do not set the profile parameter in SetAudioProfile [1/2] to AUDIO_PROFILE_SPEECH_STANDARD(1)This method works best with the human voice. Agora does not recommend using this method for audio containing music.After calling SetVoiceBeautifierParameters, Agora recommends not calling the following methods, because they can override settings in SetVoiceBeautifierParameters: SetAudioEffectPreset SetAudioEffectParameters SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceConversionPreset
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
        /// <param name="pitch"> The local voice pitch. The value range is [0.5,2.0]. The lower the value, the lower the pitch. The default value is 1 (no change to the pitch).</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoicePitch(double pitch);

        ///
        /// <summary>
        /// Sets the local voice equalization effect.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="bandFrequency"> The band frequency. The value ranges between 0 and 9; representing the respective 10-band center frequencies of the voice effects, including 31, 62, 125, 250, 500, 1k, 2k, 4k, 8k, and 16k Hz. For more details, see AUDIO_EQUALIZATION_BAND_FREQUENCY .</param>
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
        /// The SDK also provides the SetAudioEffectPreset method, which allows you to directly implement preset reverb effects for such as pop, R&B, and KTV.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="reverbKey"> The reverberation key. Agora provides five reverberation keys; see AUDIO_REVERB_TYPE for details.</param>
        ///
        /// <param name="value"> The value of the reverberation key.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);
        #endregion

        #region Pre-call network test
        ///
        /// <summary>
        /// Starts an audio call test.
        /// Deprecated:This method is deprecated, use StartEchoTest [2/2] instead.This method starts an audio call test to determine whether the audio devices (for example, headset and speaker) and the network connection are working properly. To conduct the test, the user speaks, and the recording is played back within 10 seconds. If the user can hear the recording within the interval, the audio devices and network connection are working properly.Call this method before joining a channel.After calling StartEchoTest [1/2], you must call StopEchoTest to end the test. Otherwise, the app cannot perform the next echo test, and you cannot join the channel.In the live streaming channels, only a host can call this method.
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
        /// This method starts an audio call test to determine whether the audio devices (for example, headset and speaker) and the network connection are working properly. To conduct the test, let the user speak for a while, and the recording is played back within the set interval. If the user can hear the recording within the interval, the audio devices and network connection are working properly.Call this method before joining a channel.After calling StartEchoTest [2/2], you must call StopEchoTest to end the test. Otherwise, the app cannot perform the next echo test, and you cannot join the channel.In the live streaming channels, only a host can call this method.
        /// </summary>
        ///
        /// <param name="intervalInSeconds"> The time interval (s) between when you speak and when the recording plays back. The value range is [2, 10], and the default value is 10.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartEchoTest(int intervalInSeconds);

        ///
        /// <summary>
        /// Starts an audio and video call loop test.
        /// Before joining a channel, to test whether the user's local sending and receiving streams are normal, you can call this method to perform an audio and video call loop test, which tests whether the audio and video devices and the user's upstream and downstream networks are working properly.After starting the test, the user needs to make a sound or face the camera. The audio or video is output after about two seconds. If the audio playback is normal, the audio device and the user's upstream and downstream networks are working properly; if the video playback is normal, the video device and the user's upstream and downstream networks are working properly.Call this method before joining a channel.After calling this method, call StopEchoTest to end the test; otherwise, the user cannot perform the next audio and video call loop test and cannot join the channel.In live streaming scenarios, this method only applies to hosts.
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
        #endregion

        #region Screen sharing
        ///
        /// <summary>
        /// Gets a list of shareable screens and windows.
        /// You can call this method before sharing a screen or window to get a list of shareable screens and windows, which enables a user to use thumbnails in the list to choose a particular screen or window to share. This list also contains important information such as window ID and screen ID, with which you can call StartScreenCaptureByWindowId or StartScreenCaptureByDisplayId to start the sharing.
        /// </summary>
        ///
        /// <param name="thumbSize"> The target size of the screen or window thumbnail (the width and height are in pixels). The SDK scales the original image to make the length of the longest side of the image the same as that of the target size without distorting the original image. For example, if the original image is 400 × 300 and thumbSize is 100 × 100, the actual size of the thumbnail is 100 × 75. If the target size is larger than the original size, the thumbnail is the original image and the SDK does not scale it.</param>
        ///
        /// <param name="iconSize"> The target size of the icon corresponding to the application program (the width and height are in pixels). The SDK scales the original image to make the length of the longest side of the image the same as that of the target size without distorting the original image. For example, if the original image is 400 × 300 and iconSize is 100 × 100, the actual size of the icon is 100 × 75. If the target size is larger than the original size, the icon is the original image and the SDK does not scale it.</param>
        ///
        /// <param name="includeScreen"> Whether the SDK returns the screen information in addition to the window information:true: The SDK returns screen and window information.false: The SDK returns the window information only.</param>
        ///
        /// <returns>
        /// The ScreenCaptureSourceInfo array.
        /// </returns>
        ///
        public abstract ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen);

        ///
        /// <summary>
        /// Sets the screen sharing scenario.
        /// When you start screen sharing or window sharing, you can call this method to set the screen sharing scenario. The SDK adjusts the video quality and experience of the sharing according to the scenario.This method applies to macOS and Windows only.
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
        /// Shares the screen by specifying the display ID.
        /// This method shares a screen or part of the screen.There are two ways to start screen sharing, you can choose one according to the actual needs:Call this method before joining a channel, and then call JoinChannel [2/2] to join a channel and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.Call this method after joining a channel, and then call UpdateChannelMediaOptions and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="displayId"> The display ID of the screen to be shared.</param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle . If the specified region overruns the screen, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen.</param>
        ///
        /// <param name="captureParams"> Screen sharing configurations. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.ERR_INVALID_STATE: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture to stop the current sharing and start sharing the screen again.ERR_INVALID_ARGUMENT: The parameter is invalid.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Shares the whole or part of a screen by specifying the screen rect.
        /// There are two ways to start screen sharing, you can choose one according to the actual needs:
        /// Call this method before joining a channel, and then call JoinChannel [2/2] to join a channel and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.
        /// Call this method after joining a channel, and then call UpdateChannelMediaOptions and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing. Deprecated:This method is deprecated. Use StartScreenCaptureByDisplayId instead. Agora strongly recommends using StartScreenCaptureByDisplayId if you need to start screen sharing on a device connected to another display.This method shares a screen or part of the screen. You need to specify the area of the screen to be shared.This method applies to Windows only.
        /// </summary>
        ///
        /// <param name="screenRect"> Sets the relative location of the screen to the virtual screen.</param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle . If the specified region overruns the screen, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen.</param>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// ERR_INVALID_STATE: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture to stop the current sharing and start sharing the screen again.
        /// ERR_INVALID_ARGUMENT: The parameter is invalid.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams);

        ///
        /// @ignore
        ///
        public abstract int StartScreenCapture(byte[] mediaProjectionPermissionResultData, ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Starts screen sharing.
        /// There are two ways to start screen sharing, you can choose one according to the actual needs:Call this method before joining a channel, and then call JoinChannel [2/2] to join a channel and set publishScreenCaptureVideo or publishSecondaryScreenTrack to true to start screen sharing.Call this method after joining a channel, and then call UpdateChannelMediaOptions and set publishScreenCaptureVideo or publishSecondaryScreenTrack to true to start screen sharing.This method is for Android only.The billing for the screen sharing stream is based on the dimensions in ScreenVideoParameters. When you do not pass in a value, Agora bills you at 1280 × 720; when you pass a value in, Agora bills you at that value. See for details.
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
        /// Updates the screen sharing parameters.
        /// </summary>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters2 .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// ERR_INVALID_STATE: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture to stop the current sharing and start sharing the screen again.
        /// ERR_INVALID_ARGUMENT: The parameter is invalid.
        /// </returns>
        ///
        public abstract int UpdateScreenCapture(ScreenCaptureParameters2 captureParams);

        ///
        /// <summary>
        /// Shares the whole or part of a window by specifying the window ID.
        /// There are two ways to start screen sharing, you can choose one according to the actual needs:
        /// Call this method before joining a channel, and then call JoinChannel [2/2] to join a channel and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.
        /// Call this method after joining a channel, and then call UpdateChannelMediaOptions and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing. This method shares a window or part of the window. You need to specify the ID of the window to be shared.Applies to the macOS and Windows platforms only.The window sharing feature of the Agora SDK relies on WGC (Windows Graphics Capture) or GDI (Graphics Device Interface) capture, and WGC cannot be set to disable mouse capture on systems earlier than Windows 10 2004. Therefore, captureMouseCursor(false) might not work when you start window sharing on a device with a system earlier than Windows 10 2004. See ScreenCaptureParameters .
        /// </summary>
        ///
        /// <param name="windowId"> The ID of the window to be shared.</param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle . If the specified region overruns the window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole window.</param>
        ///
        /// <param name="captureParams"> Screen sharing configurations. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// ERR_INVALID_STATE: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture to stop the current sharing and start sharing the screen again.
        /// ERR_INVALID_ARGUMENT: The parameter is invalid.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByWindowId(UInt64 windowId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Sets the content hint for screen sharing.
        /// A content hint suggests the type of the content being shared, so that the SDK applies different optimization algorithms to different types of content. If you don't call this method, the default content hint is CONTENT_HINT_NONE.You can call this method either before or after you start screen sharing.
        /// </summary>
        ///
        /// <param name="contentHint"> The content hint for screen sharing. See VIDEO_CONTENT_HINT .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// ERR_INVALID_STATE: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture to stop the current sharing and start sharing the screen again.
        /// ERR_INVALID_ARGUMENT: The parameter is invalid.
        /// </returns>
        ///
        public abstract int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint);

        ///
        /// <summary>
        /// Updates the screen sharing region.
        /// Call this method after starting screen sharing or window sharing.
        /// </summary>
        ///
        /// <param name="regionRect"> The relative location of the screen-share area to the screen or window. If you do not set this parameter, the SDK shares the whole screen or window. See Rectangle . If the specified region overruns the screen or window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen or window.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.ERR_INVALID_STATE: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture to stop the current sharing and start sharing the screen again.ERR_INVALID_ARGUMENT: The parameter is invalid.
        /// </returns>
        ///
        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);

        ///
        /// <summary>
        /// Updates the screen sharing parameters.
        /// Call this method after starting screen sharing or window sharing.
        /// </summary>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters </param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// ERR_INVALID_STATE: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture to stop the current sharing and start sharing the screen again.
        /// ERR_INVALID_ARGUMENT: The parameter is invalid.
        /// </returns>
        ///
        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Stops screen sharing.
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
        /// Enables/Disables dual-stream mode.
        /// Sets the stream mode to the single-stream (default) or dual-stream mode. (LIVE_BROADCASTING only.) You can call this method to enable or disable the dual-stream mode on the publisher side.Dual streams are a hybrid of a high-quality video stream and a low-quality video stream:High-quality video stream: High bitrate, high resolution.Low-quality video stream: Low bitrate, low resolution.After you enable the dual-stream mode, you can call SetRemoteVideoStreamType to choose toreceive the high-quality video stream or low-quality video stream on the subscriber side.This method only takes effect for the video stream captured by the SDK through the camera. If you use video streams from the custom video source or captured by the SDK through the screen, you need to call EnableDualStreamMode [2/3] or EnableDualStreamMode [3/3] to enable dual-stream mode.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode.true: Enable dual-stream mode.false: Disable dual-stream mode.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableDualStreamMode(bool enabled);

        ///
        /// <summary>
        /// Enables/Disables dual-stream mode.
        /// You can call this method to enable or disable the dual-stream mode on the publisher side. Dual streams are a hybrid of a high-quality video stream and a low-quality video stream:High-quality video stream: High bitrate, high resolution.Low-quality video stream: Low bitrate, low resolution.After you enable the dual-stream mode, you can call SetRemoteVideoStreamType to choose toreceive the high-quality video stream or low-quality video stream on the subscriber side.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="sourceType"> The capture type of the custom video source. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode.true: Enable dual-stream mode.false: Disable dual-stream mode.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled);

        ///
        /// <summary>
        /// Enables/Disables dual-stream mode.
        /// You can call this method to enable or disable the dual-stream mode on the publisher side. Dual streams are a hybrid of a high-quality video stream and a low-quality video stream:
        /// High-quality video stream: High bitrate, high resolution.
        /// Low-quality video stream: Low bitrate, low resolution. After you enable the dual-stream mode, you can call SetRemoteVideoStreamType to choose toreceive the high-quality video stream or low-quality video stream on the subscriber side. You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode.
        ///  true: Enable dual-stream mode.
        ///  false: Disable dual-stream mode. </param>
        ///
        /// <param name="sourceType"> The capture type of the custom video source. See VIDEO_SOURCE_TYPE .</param>
        ///
        /// <param name="streamConfig"> The configuration of the low-quality video stream. See SimulcastStreamConfig .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableDualStreamMode(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig);

        ///
        /// <summary>
        /// Sets the stream type of the remote video.
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using EnableDualStreamMode [3/3] (false), the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or the low-quality video stream (the low resolution, and low bitrate video stream). The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate.By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream.The method result returns in the OnApiCallExecuted callback.You can call this method either before or after joining a channel. If you call both SetRemoteVideoStreamType and SetRemoteDefaultVideoStreamType , the setting of SetRemoteVideoStreamType takes effect.
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
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using EnableDualStreamMode [3/3] (false), the receiver can choose to receive either the high-quality video stream or the low-quality video stream. The high-quality video stream has a higher resolution and bitrate, and the low-quality video stream has a lower resolution and bitrate.By default, users receive the high-quality video stream. Call this method if you want to switch to the low-quality video stream. This method allows the app to adjust the corresponding video stream type based on the size of the video window to reduce the bandwidth and resources. The aspect ratio of the low-quality video stream is the same as the high-quality video stream. Once the resolution of the high-quality video stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-quality video stream.The result of this method is returned in the OnApiCallExecuted callback.Call this method before joining a channel. Agora does not support changing the default subscribed video stream type after joining a channel.If you call both this method and SetRemoteVideoStreamType , the SDK applies the settings in the SetRemoteVideoStreamType method.
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
        /// @ignore
        ///
        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode);

        ///
        /// @ignore
        ///
        public abstract int SetDualStreamMode(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode);

        ///
        /// @ignore
        ///
        public abstract int SetDualStreamMode(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig);
        #endregion

        #region Watermark
        ///
        /// <summary>
        /// Adds a watermark image to the local video.
        /// Deprecated:This method is deprecated.
        /// Use AddVideoWatermark [2/2] instead.This method adds a PNG watermark image to the local video stream in a live streaming session. Once the watermark image is added, all the users in the channel (CDN audience included) and the video capturing device can see and capture it. If you only want to add a watermark to the CDN live streaming, see descriptions in setLiveTranscoding .The URL descriptions are different for the local video and CDN live streaming: In a local video stream, URL refers to the absolute path of the added watermark image file in the local video stream. In a CDN live stream, URL refers to the URL address of the added watermark image in the CDN live streaming.The source file of the watermark image must be in the PNG file format. If the width and height of the PNG file differ from your settings in this method, the PNG file will be cropped to conform to your settings.The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one.
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
        /// This method adds a PNG watermark image to the local video in the live streaming. Once the watermark image is added, all the audience in the channel (CDN audience included), and the capturing device can see and capture it. Agora supports adding only one watermark image onto the local video, and the newly watermark image replaces the previous one.The watermark coordinatesare dependent on the settings in the SetVideoEncoderConfiguration method:If the orientation mode of the encoding video ( ORIENTATION_MODE ) is fixed landscape mode or the adaptive landscape mode, the watermark uses the landscape orientation.If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed portrait mode or the adaptive portrait mode, the watermark uses the portrait orientation.When setting the watermark position, the region must be less than theSetVideoEncoderConfiguration dimensions set in the method; otherwise, the watermark image will be cropped.Ensure that call this method after EnableVideo .If you only want to add a watermark to the Media Push, you can call this method or the setLiveTranscoding method.This method supports adding a watermark image in the PNG file format only. Supported pixel formats of the PNG image are RGBA, RGB, Palette, Gray, and Alpha_gray.If the dimensions of the PNG image differ from your settings in this method, the image will be cropped or zoomed to conform to your settings.If you have enabledthe local video preview by calling the StartPreview [1/2] visibleInPreview member to set whether or not the watermark is visible in the preview.If you have enabled the mirror mode for the local video, the watermark on the local video is also mirrored. To avoid mirroring the watermark, Agora recommends that you do not use the mirror and watermark functions for the local video at the same time. You can implement the watermark function in your application layer.
        /// </summary>
        ///
        /// <param name="watermarkUrl"> The local file path of the watermark image to be added. This method supports adding a watermark image from the local absolute or relative file path.</param>
        ///
        /// <param name="options"> The options of the watermark image to be added. </param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);

        ///
        /// @ignore
        ///
        public abstract int ClearVideoWatermark();

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
        /// Deprecated:Use EnableEncryption instead.The Agora SDK supports built-in encryption, which is set to the AES-128-GCM mode by default. Call this method to use other encryption modes. All users in the same channel must use the same encryption mode and secret. Refer to the information related to the AES encryption algorithm on the differences between the encryption modes.Before calling this method, please call SetEncryptionSecret to enable the built-in encryption function.
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
        /// Deprecated:This method is deprecated. Use EnableEncryption instead.Before joining the channel, you need to call this method to set the secret parameter to enable the built-in encryption. All users in the same channel should use the same secret. The secret is automatically cleared once a user leaves the channel. If you do not specify the secret or secret is set as null, the built-in encryption is disabled.Do not use this method for CDN live streaming.For optimal transmission, ensure that the encrypted data size does not exceed the original data size + 16 bytes. 16 bytes is the maximum padding size for AES encryption.
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
        /// Enables/Disables the built-in encryption.
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
        /// Enables/Disables stereo panning for remote users.
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
        /// After calling this method, you can merge multiple video streams into one video stream locally. Common scenarios include the following:In a live streaming scenario with cohosts or when using the Media Push function, you can locally mix the videos of multiple hosts into one.In scenarios where you capture multiple local video streams (for example, video captured by cameras, screen sharing streams, video files, or pictures), you can merge them into one video stream and then publish the mixed video stream after joining the channel.
        /// </summary>
        ///
        /// <param name="config"> Configuration of the local video mixing. See LocalTranscoderConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfiguration config);

        ///
        /// <summary>
        /// Update the local video mixing configuration.
        /// After calling StartLocalVideoTranscoder , call this method if you want to update the local video mixing configuration.
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
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopLocalVideoTranscoder();
        #endregion

        #region Channel media stream relay
        ///
        /// <summary>
        /// Starts relaying media streams across channels. This method can be used to implement scenarios such as co-host across channels.
        /// After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged and OnChannelMediaRelayEvent callbacks, and these callbacks return the state and events of the media stream relay.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), and the OnChannelMediaRelayEvent callback returns RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4); it means that the SDK starts relaying media streams between the source channel and the destination channel.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_FAILURE (3), an exception occurs during the media stream relay.Call this method after joining the channel.This method takes effect only when you are a host in a live streaming channel.After a successful method call, if you want to call this method again, ensure that you call the StopChannelMediaRelay method to quit the current relay.You need to before implementing this function.We do not support string type of UID in this API.
        /// </summary>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. See ChannelMediaRelayConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        ///
        /// <summary>
        /// Updates the channels for media stream relay.
        /// After the media relay starts, if you want to relay the media stream to more channels, or leave the current relay channel, you can call this method.After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback with the RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL (7) state code.Call the method after successfully calling the StartChannelMediaRelay method and receiving OnChannelMediaRelayStateChanged (RELAY_STATE_RUNNING, RELAY_OK); otherwise, the method call fails.
        /// </summary>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. </param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        ///
        /// <summary>
        /// Stops the media stream relay. Once the relay stops, the host quits all the destination channels.
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
        /// Pauses the media stream relay to all destination channels.
        /// After the cross-channel media stream relay starts, you can call this method to pause relaying media streams to all destination channels; after the pause, if you want to resume the relay, call ResumeAllChannelMediaRelay .After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback to report whether the media stream relay is successfully paused.Call this method after the StartChannelMediaRelay method.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAllChannelMediaRelay();

        ///
        /// <summary>
        /// Resumes the media stream relay to all destination channels.
        /// After calling the PauseAllChannelMediaRelay method, you can call this method to resume relaying media streams to all destination channels.After a successful method call, the SDK triggers the OnChannelMediaRelayEvent callback to report whether the media stream relay is successfully resumed.Call this method after the PauseAllChannelMediaRelay method.
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
        /// <param name="type"> The type of the audio recording device. See MEDIA_SOURCE_TYPE .</param>
        ///
        /// <param name="frame"> The external audio frame. See AudioFrame .</param>
        ///
        /// <param name="wrap"> Whether to use the placeholder. Agora recommends using the default value.true: Use the placeholder.false: (Default) Do not use the placeholder.</param>
        ///
        /// <param name="sourceId"> The ID of external audio source. If you want to publish a custom external audio source, set this parameter to the ID of the corresponding custom audio track you want to publish.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PushAudioFrame(MEDIA_SOURCE_TYPE type, AudioFrame frame, bool wrap = false, int sourceId = 0);

        ///
        /// <summary>
        /// Sets the external audio source parameters.
        /// Call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the external audio source:true: Enable the external audio source.false: (Default) Disable the external audio source.</param>
        ///
        /// <param name="sampleRate"> The sample rate (Hz) of the external audio source, which can be set as 8000, 16000, 32000, 44100, or 48000.</param>
        ///
        /// <param name="channels"> The number of channels of the external audio source, which can be set as 1 (Mono) or 2 (Stereo).</param>
        ///
        /// <param name="sourceNumber"> The number of external audio sources. The value of this parameter should be larger than 0. The SDK creates a corresponding number of custom audio tracks based on this parameter value and names the audio tracks starting from 0. In ChannelMediaOptions , you can set publishCustomAudioSourceId to the ID of the audio track you want to publish.</param>
        ///
        /// <param name="localPlayback"> Whether to play the external audio source:true: Play the external audio source.false: (Default) Do not play the external source.</param>
        ///
        /// <param name="publish"> Whether to publish audio to the remote users:true: (Default) Publish audio to the remote users.false: Do not publish audio to the remote users</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels, int sourceNumber, bool localPlayback = false, bool publish = true);

        ///
        /// <summary>
        /// Adjusts the volume of the custom external audio source when it is published in the channel.
        /// Ensure you have called the SetExternalAudioSource method to create an external audio track before calling this method.If you want to change the volume of the audio to be published, you need to call this method again.
        /// </summary>
        ///
        /// <param name="sourceId"> The ID of external audio source. If you want to publish a custom external audio source, set this parameter to the ID of the corresponding custom audio track you want to publish.</param>
        ///
        /// <param name="volume"> The volume of the audio source. The value can range from 0 to 100. 0 means mute; 100 means the original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustCustomAudioPublishVolume(int sourceId, int volume);

        ///
        /// @ignore
        ///
        public abstract int AdjustCustomAudioPlayoutVolume(int sourceId, int volume);
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
        /// Call this method to register an audio frame observer object (register a callback). When you need the SDK to trigger OnRecordAudioFrame or OnPlaybackAudioFrame callback, you need to use this method to register the callbacks.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="audioFrameObserver"> The observer object instance. See IAudioFrameObserver . Set the value as NULL to release the instance. Agora recommends calling after receiving OnLeaveChannel to release the audio observer object.</param>
        ///
        /// <param name="mode"> The video data callback mode. See OBSERVER_MODE .</param>
        ///
        public abstract void RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters an audio frame observer.
        /// </summary>
        ///
        public abstract void UnRegisterAudioFrameObserver();

        ///
        /// <summary>
        /// Sets the format of the captured raw audio data.
        /// Sets the audio format for the OnRecordAudioFrame callback.Ensure that you call this method before joining a channel.The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method.Sample interval = samplePerCall/(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnRecordAudioFrame callback according to the sampling interval.
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
        /// Sets the data format for the OnPlaybackAudioFrame callback.Ensure that you call this method before joining a channel.The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method.Sample interval = samplePerCall/(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnPlaybackAudioFrame callback according to the sampling interval.
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
        /// <param name="channel"> The number of channels of the audio data, which can be set as 1 (Mono) or 2 (Stereo).</param>
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
        /// Sets the audio data format reported by OnPlaybackAudioFrameBeforeMixing [1/2] .
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
        /// Call this method after joining a channel.You can call this method or the StartAudioRecording [3/3] method to set the audio content and audio quality. Agora recommends not using this method and StartAudioRecording [3/3] at the same time; otherwise, only the method called later takes effect.
        /// </summary>
        ///
        /// <param name="config"> Observer settings for the encoded audio. See AudioEncodedFrameObserverConfig .</param>
        ///
        /// <param name="observer"> The encoded audio observer. See IAudioEncodedFrameObserver .</param>
        ///
        public abstract void RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer);

        ///
        /// <summary>
        /// Unregisters the encoded audio frame observer.
        /// </summary>
        ///
        public abstract void UnRegisterAudioEncodedFrameObserver();
        #endregion

        #region Audio spectrum
        ///
        /// <summary>
        /// Turns on audio spectrum monitoring.
        /// If you want to obtain the audio spectrum data of local or remote users, you can register the audio spectrum observer and enable audio spectrum monitoring.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="intervalInMS"> The interval (in milliseconds) at which the SDK triggers the OnLocalAudioSpectrum and OnRemoteAudioSpectrum callbacks. The default value is 100. Do not set this parameter to less than 10 milliseconds, otherwise the calling of this method fails.</param>
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
        /// Registers an audio spectrum observer.
        /// After successfully registering the audio spectrum observer and calling 
        /// EnableAudioSpectrumMonitor to enable the audio spectrum monitoring, the SDK reports the callback that you implement in the IAudioSpectrumObserver class at the time interval you set.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="observer"> The Audio spectrum observer. See IAudioSpectrumObserver .</param>
        ///
        public abstract void RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        ///
        /// <summary>
        /// Unregisters the audio spectrum observer.
        /// After calling RegisterAudioSpectrumObserver , if you want to disable audio spectrum monitoring, you can call this method.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        public abstract void UnregisterAudioSpectrumObserver();
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
        /// <param name="sourceType"> Whether to encode the external video frame, see EXTERNAL_VIDEO_SOURCE_TYPE .</param>
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
        /// To push the unencoded external raw video frame to the SDK, call SetExternalVideoSource , set enabled as true, and set encodedFrame as false.
        /// </summary>
        ///
        /// <param name="frame"> The external raw video frame to be pushed. See ExternalVideoFrame .</param>
        ///
        /// <param name="videoTrackId"> The video track ID returned by calling the createCustomVideoTrack method. The default value is 0.</param>
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
        /// When you need to publish multiple custom captured videos in the channel, you can refer to the following steps:Call this method to create a video track and get the video track ID.In each channel's ChannelMediaOptions , set the customVideoTrackId parameter to the ID of the video track you want to publish, and set publishCustomVideoTrack to true.
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
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DestroyCustomVideoTrack(video_track_id_t video_track_id);

        #endregion

        #region Raw video data
        ///
        /// <summary>
        /// Registers a video frame observer object.
        /// You need to implement the IVideoFrameObserver class in this method and register callbacks according to your scenarios. After you successfully register the video frame observer, the SDK triggers the registered callbacks each time a video frame is received.When handling the video data returned in the callbacks, pay attention to the changes in the width and height parameters, which may be adapted under the following circumstances:When the network condition deteriorates, the video resolution decreases incrementally.If the user adjusts the video profile, the resolution of the video returned in the callbacks also changes.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="videoFrameObserver"> The observer object instance. See IVideoFrameObserver . To release the instance, set the value as NULL.</param>
        ///
        /// <param name="mode"> The video data callback mode. See OBSERVER_MODE .</param>
        ///
        public abstract void RegisterVideoFrameObserver(IVideoFrameObserver videoFrameObserver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters the video frame observer.
        /// </summary>
        ///
        public abstract void UnRegisterVideoFrameObserver();

        ///
        /// <summary>
        /// Registers a receiver object for the encoded video image.
        /// Call this method after joining a channel.If you register an IVideoEncodedFrameObserver object, you cannot register an IVideoFrameObserver object.
        /// </summary>
        ///
        /// <param name="videoEncodedImageReceiver"> The video frame observer object. See IVideoEncodedFrameObserver .</param>
        ///
        /// <param name="mode"> The video data callback mode. See OBSERVER_MODE .</param>
        ///
        public abstract void RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver videoEncodedImageReceiver, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters a receiver object for the encoded video image.
        /// </summary>
        ///
        public abstract void UnRegisterVideoEncodedFrameObserver();
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
        /// Enables/Disables extensions.
        /// Ensure that you call this method before joining a channel.If you want to enable multiple extensions, you need to call this method multiple times.The data processing order of different extensions in the SDK is determined by the order in which the extensions are enabled. That is, the extension that is enabled first will process the data first.
        /// </summary>
        ///
        /// <param name="extension"> The name of the extension.</param>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <param name="enable"> Whether to enable the extension:true: Enable the extension.false: Disable the extension.</param>
        ///
        /// <param name="type"> Type of media source. See MEDIA_SOURCE_TYPE . In this method, this parameter supports only the following two settings:The default value is UNKNOWN_MEDIA_SOURCE.If you want to use the second camera to capture video, set this parameter to SECONDARY_CAMERA_SOURCE.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

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
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        ///
        /// <summary>
        /// Gets detailed information of the extension.
        /// </summary>
        ///
        /// <param name="key"> The key of the extension.</param>
        ///
        /// <param name="extension"> The name of the extension.</param>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <param name="sourceType"> Source type of the extension. See MEDIA_SOURCE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);
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
        public abstract void RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type);

        ///
        /// <summary>
        /// Unregisters the specified metadata observer.
        /// </summary>
        ///
        public abstract void UnregisterMediaMetadataObserver();
        #endregion

        #region Audio recording
        ///
        /// <summary>
        /// Starts the audio recording on the client.
        /// Deprecated:This method is deprecated as of v2.9.1. It has a fixed recording sample rate of 32 kHz. Use StartAudioRecording [3/3] instead.The Agora SDK allows recording during a call. This method records the audio of all the users in the channel and generates an audio recording file. Supported formats of the recording file are as follows:.wav: Large file size with high fidelity..aac: Small file size with low fidelity.Ensure that the directory for the recording file exists and is writable. This method should be called after the JoinChannel [1/2] LeaveChannel [1/2]
        /// </summary>
        ///
        /// <param name="filePath"> The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.mp4.
        ///  Ensure that the path for the recording file exists and is writable.</param>
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
        /// Starts the audio recording on the client.
        /// Deprecated:This method is deprecated. Use StartAudioRecording [3/3] instead.The Agora SDK allows recording during a call. After successfully calling this method, you can record the audio of all the users in the channel and get an audio recording file. Supported formats of the recording file are as follows:.wav: Large file size with high fidelity..aac: Small file size with low fidelity.Ensure that the directory you use to save the recording file exists and is writable.This method should be called after the JoinChannel [2/2] method. The recording automatically stops when you call the LeaveChannel [1/2] For better recording effects, set quality to AUDIO_RECORDING_QUALITY_MEDIUM or AUDIO_RECORDING_QUALITY_HIGH when sampleRate is 44.1 kHz or 48 kHz.
        /// </summary>
        ///
        /// <param name="filePath"> The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.mp4.
        ///  Ensure that the path for the recording file exists and is writable.</param>
        ///
        /// <param name="sampleRate"> The sample rate (kHz) of the recording file. Supported values are as follows:16000(Default) 320004410048000</param>
        ///
        /// <param name="quality"> Recording quality. For more details, see AUDIO_RECORDING_QUALITY_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        ///
        /// <summary>
        /// Starts the audio recording on the client.
        /// The Agora SDK allows recording during a call. After successfully calling this method, you can record the audio of all the users in the channel and get an audio recording file. Supported formats of the recording file are as follows:WAV: High-fidelity files with typically larger file sizes. For example, the size of a WAV file with a sample rate of 32,000 Hz and a recording duration of 10 minutes is around 73 MB.AAC: Low-fidelity files with typically smaller file sizes. For example, if the sample rate is 32,000 Hz and the recording quality is AUDIO_RECORDING_QUALITY_MEDIUM, the file size for a 10-minute recording is approximately 2 MB.Once the user leaves the channel, the recording automatically stops.Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="config"> Recording configuration. See AudioFileRecordingConfig .</param>
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
        /// <param name="config"> The camera capturer configuration. See CameraCapturerConfiguration .</param>
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
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo ,depending on which method you use to turn on your local camera.This method is for Android and iOS only.
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
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo ,depending on which method you use to turn on your local camera.This method is for Android only.
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
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo ,depending on which method you use to turn on your local camera.
        /// This method is for Android and iOS only.The app enables the front camera by default. If your front camera does not support enabling the flash, this method returns false. If you want to check whether the rear camera supports the flash function, call SwitchCamera before this method.On iPads with system version 15, even if IsCameraTorchSupported returns true, you might fail to successfully enable the flash by calling SetCameraTorchOn due to system issues.
        /// </summary>
        ///
        /// <returns>
        /// true: The device supports enabling the flash.false: The device does not support enabling the flash.
        /// </returns>
        ///
        public abstract bool IsCameraTorchSupported();

        ///
        /// <summary>
        /// Check whether the device supports the manual focus function.
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo ,depending on which method you use to turn on your local camera.This method is for Android and iOS only.
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
        /// This method is for Android and iOS only.Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo ,depending on which method you use to turn on your local camera.
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
        /// The camera zoom factor value, if successful.&lt; 0: Failure.
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
        /// Sets whether to enable face autofocus.
        /// This method is for Android and iOS only.Call this method after the camera is started, such as after JoinChannel [2/2] , EnableVideo , or EnableLocalVideo .
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable face autofocus:true: Enable face autofocus.false: Disable face autofocus.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraAutoFocusFaceModeEnabled(bool enabled);

        ///
        /// <summary>
        /// Checks whether the device supports manual exposure.
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo ,depending on which method you use to turn on your local camera.
        /// This method is for Android and iOS only.
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
        /// Call this method after enabling the local camera, for example, by calling JoinChannel [2/2] , EnableVideo , or EnableLocalVideo ,depending on which method you use to turn on your local camera.This method applies to iOS only.
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
        /// <param name="enabled"> Whether to enable auto exposure:
        ///  true: Enable auto exposure.false: Disable auto exposure.</param>
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
        /// This method is for Android and iOS only.After a successful method call, the SDK triggers the OnAudioRoutingChanged callback.You can call this method before joining a channel, when in a channel, or after leaving a channel. However, Agora recommends calling this method only when you are in a channel to change the audio route temporarily.If you do not have a clear requirement for transient settings, Agora recommends calling SetDefaultAudioRouteToSpeakerphone to set the audio route.Any user behavior or audio-related API call might change the transient setting of SetEnableSpeakerphone. Due to system limitations, if the user uses an external audio playback device such as a Bluetooth or wired headset on an iOS device, this method does not take effect.
        /// </summary>
        ///
        /// <param name="speakerOn"> Whether to set the speakerphone as the default audio route:true: Set the speakerphone as the audio route temporarily.false: Do not set the speakerphone as the audio route.</param>
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
        /// This method enables the SDK to regularly report the volume information of the local user who sends a stream and remote users (up to three) whose instantaneous volumes are the highest to the app. Once you call this method and users send streams in the channel, the SDK triggers the OnAudioVolumeIndication callback at the time interval set in this method.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="interval"> Sets the time interval between two consecutive volume indications:≤ 0: Disables the volume indication.> 0: Time interval (ms) between two consecutive volume indications. You need to set this parameter to an integer multiple of 200. If the value is lower than 200, the SDK automatically adjusts the value to 200.</param>
        ///
        /// <param name="smooth"> The smoothing factor sets the sensitivity of the audio volume indicator. The value ranges between 0 and 10. The recommended value is 3. The greater the value, the more sensitive the indicator.</param>
        ///
        /// <param name="reportVad"> true: Enable the voice activity detection of the local user. Once it is enabled,the vad parameter of the OnAudioVolumeIndication callback reports the voice activity status of the local user.false: (Default) Disable the voice activity detection of the local user. Once it is disabled, the vad parameter of the OnAudioVolumeIndication callback does not report the voice activity status of the local user, except for the scenario where the engine automatically detects the voice activity of the local user.</param>
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
        /// Each user can create up to five data streams during the lifecycle of IRtcEngine .Call this method after joining a channel.Agora does not support setting reliable as true and ordered as true.
        /// </summary>
        ///
        /// <param name="streamId"> Output parameter. Pointer to the ID of the created data stream.</param>
        ///
        /// <param name="reliable"> Whether or not the data stream is reliable:true: The recipients receive the data from the sender within five seconds. If the recipient does not receive the data within five seconds, the SDK triggers the OnStreamMessageError callback and returns an error code.false: There is no guarantee that the recipients receive the data stream within five seconds and no error message is reported for any delay or missing data stream.</param>
        ///
        /// <param name="ordered"> Whether or not the recipients receive the data stream in the sent order:true: The recipients receive the data in the sent order.false: The recipients do not receive the data in the sent order.</param>
        ///
        /// <returns>
        /// ID of the created data stream, if the method call succeeds.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int CreateDataStream(ref int streamId, bool reliable, bool ordered);

        ///
        /// <summary>
        /// Creates a data stream.
        /// Creates a data stream. Each user can create up to five data streams in a single channel.Compared with CreateDataStream [1/2] , this method does not support data reliability. If a data packet is not received five seconds after it was sent, the SDK directly discards the data.
        /// </summary>
        ///
        /// <param name="streamId"> Output parameter. Pointer to the ID of the created data stream.</param>
        ///
        /// <param name="config"> The configurations for the data stream. See DataStreamConfig .</param>
        ///
        /// <returns>
        /// ID of the created data stream, if the method call succeeds.&lt; 0: Failure.
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
        /// <param name="data"> The data to be sent.</param>
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
        /// Enables loopback audio capture.
        /// If you enable loopback audio capture, the output of the sound card is mixed into the audio stream sent to the other end.Applies to the macOS and Windows platforms only.macOS does not support loopback audio capture of the default sound card. If you need to use this method, use a virtual sound card and pass its name to the deviceName parameter. Agora recommends that you use Soundflower for loopback audio capture.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable loopback audio capture.true: Enable loopback audio capture.false: (Default) Disable loopback audio capture.</param>
        ///
        /// <param name="deviceName"> macOS: The device name of the virtual sound card. The default is set to null, which means the SDK uses Soundflower for loopback audio capture.Windows: The device name of the sound card. The default is set to null, which means the SDK uses the sound card of your device for loopback audio capture.</param>
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
        /// Sets the Agora cloud proxy service.
        /// When users' network access is restricted by a firewall, configure the firewall to allow specific IP addresses and ports provided by Agora; then, call this method to enable the cloud proxy and set the cloud proxy type with the proxyType parameter.After successfully connecting to the cloud proxy, the SDK triggers the OnConnectionStateChanged (CONNECTION_STATE_CONNECTING, CONNECTION_CHANGED_SETTING_PROXY_SERVER) callback.To disable the cloud proxy that has been set, call the SetCloudProxy (NONE_PROXY).To change the cloud proxy type that has been set, call the SetCloudProxy (NONE_PROXY) first, and then call the SetCloudProxy to set the proxyType you want.Agora recommends that you call this method before joining the channel or after leaving the channel.When a user is behind a firewall and uses the Force UDP cloud proxy, the services for the Media Push and cohosting across channels are not available.When you use the Force TCP cloud proxy, note that an error would occur when calling the StartAudioMixing [2/2] method to play online music files in the HTTP protocol. The services for the Media Push and cohosting across channels use the cloud proxy with the TCP protocol.
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
        /// <returns>
        /// The current call ID, if the method succeeds.An empty string, if the method call fails.
        /// </returns>
        ///
        public abstract string GetCallId();

        ///
        /// <summary>
        /// Allows a user to rate a call after the call ends.
        /// Ensure that you call this method after leaving a channel.
        /// </summary>
        ///
        /// <param name="callId"> The current call ID. You can get the call ID by calling GetCallId .</param>
        ///
        /// <param name="rating"> The rating of the call. The value is between 1 (lowest score) and 5 (highest score). If you set a value out of this range, the SDK returns the -2 (ERR_INVALID_ARGUMENT) error.</param>
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
        /// 0: Success.&lt; 0: Failure.-2: The parameter is invalid.3: The SDK is not ready. Possible reasons include the following:The initialization of IRtcEngine fails. Reinitialize the IRtcEngine.No user has joined the channel when the method is called. Please check your code logic.The user has not left the channel when the Rate or Complain method is called. Please check your code logic.The audio module is disabled. The program is not complete.
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
        /// @ignore
        ///
        public abstract IMediaPlayerCacheManager GetMediaPlayerCacheManager();

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
        /// @ignore
        ///
        public abstract int EnableSpatialAudio(bool enabled);

        ///
        /// @ignore
        ///
        public abstract int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams param);
        #endregion

        #region RtmpStreaming
        ///
        /// @ignore
        ///
        public abstract int AddInjectStreamUrl(string url, InjectStreamConfig config);

        ///
        /// @ignore
        ///
        public abstract int RemoveInjectStreamUrl(string url);

        ///
        /// @ignore
        ///
        public abstract int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile);

        ///
        /// @ignore
        ///
        public abstract int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config);

        ///
        /// @ignore
        ///
        public abstract int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options);

        ///
        /// @ignore
        ///
        public abstract int StopDirectCdnStreaming();

        ///
        /// @ignore
        ///
        public abstract int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options);

        ///
        /// <summary>
        /// Starts Media Push without transcoding.
        /// Ensure that you enable the media push service before using this function.Call this method after joining a channel.Only hosts in the LIVE_BROADCASTING profile can call this method.If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.You can call this method to push an audio or video stream to the specified CDN address. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the Media Push.
        /// </summary>
        ///
        /// <param name="url"> The address of media push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartRtmpStreamWithoutTranscoding(string url);

        ///
        /// <summary>
        /// Starts Media Push and sets the transcoding configuration.
        /// You can call this method to push an audio or video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the Media Push.Ensure that you enable the media push service before using this function.Call this method after joining a channel.Only hosts in the LIVE_BROADCASTING profile can call this method.If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
        /// </summary>
        ///
        /// <param name="url"> The address of media push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
        ///
        /// <param name="transcoding"> The transcoding configuration for media push. See LiveTranscoding .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);

        ///
        /// <summary>
        /// Updates the transcoding configuration.
        /// After you start pushing media streams to CDN with transcoding, you can dynamically update the transcoding configuration according to the scenario. The SDK triggers the OnTranscodingUpdated callback after the transcoding configuration is updated.
        /// </summary>
        ///
        /// <param name="transcoding"> The transcoding configuration for media push. See LiveTranscoding .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);

        ///
        /// <summary>
        /// Stops pushing media streams to a CDN.
        /// You can call this method to stop the live stream on the specified CDN address. This method can stop pushing media streams to only one CDN address at a time, so if you need to stop pushing streams to multiple addresses, call this method multiple times.After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// </summary>
        ///
        /// <param name="url"> The address of media push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported.</param>
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
        /// Deprecated:Use the mLogConfig parameter in Initialize method instead.Specifies an SDK output log file. The log file records all log data for the SDK’s operation. Ensure that the directory for the log file exists and is writable.Ensure that you call this method immediately after calling the Initialize method to initialize the IRtcEngine , or the output log may not be complete.
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
        /// <param name="filter"> The output log level of the SDK. </param>
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
        /// Set the blacklist of subscriptions for audio streams.
        /// You can call this method to specify the audio streams of a user that you do not want to subscribe to.You can call this method either before or after joining a channel.The blacklist is not affected by the setting in MuteRemoteAudioStream , MuteAllRemoteAudioStreams and autoSubscribeAudio in ChannelMediaOptions .Once the blacklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.If a user is added in the whitelist and blacklist at the same time, only the blacklist takes effect.
        /// </summary>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to.If you want to specify the audio streams of a user that you do not want to subscribe to, add the user ID in this list. If you want to remove a user from the blacklist, you need to call the SetSubscribeAudioBlacklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list.</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioBlacklist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Sets the whitelist of subscriptions for audio streams.
        /// You can call this method to specify the audio streams of a user that you want to subscribe to.If a user is added in the whitelist and blacklist at the same time, only the blacklist takes effect.You can call this method either before or after joining a channel.The whitelist is not affected by the setting in MuteRemoteAudioStream , MuteAllRemoteAudioStreams and autoSubscribeAudio in ChannelMediaOptions .Once the whitelist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// </summary>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to.If you want to specify the audio streams of a user for subscription, add the user ID in this list. If you want to remove a user from the whitelist, you need to call the SetSubscribeAudioWhitelist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list.</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioWhitelist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Set the blacklist of subscriptions for video streams.
        /// You can call this method to specify the video streams of a user that you do not want to subscribe to.If a user is added in the whitelist and blacklist at the same time, only the blacklist takes effect.Once the blacklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.You can call this method either before or after joining a channel.The blacklist is not affected by the setting in MuteRemoteVideoStream , MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to.If you want to specify the video streams of a user that you do not want to subscribe to, add the user ID of that user in this list. If you want to remove a user from the blacklist, you need to call the SetSubscribeVideoBlacklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoBlacklist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Set the whitelist of subscriptions for video streams.
        /// You can call this method to specify the video streams of a user that you want to subscribe to.If a user is added in the whitelist and blacklist at the same time, only the blacklist takes effect.Once the whitelist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// You can call this method either before or after joining a channel.The whitelist is not affected by the setting in MuteRemoteVideoStream , MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to.If you want to specify the video streams of a user for subscription, add the user ID of that user in this list. If you want to remove a user from the whitelist, you need to call the SetSubscribeVideoWhitelist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoWhitelist(uint[] uidList, int uidNumber);
        #endregion


        #region DualStream
        #endregion


        ///
        /// @ignore
        ///
        public abstract int StartPrimaryCustomAudioTrack(AudioTrackConfig config);

        ///
        /// @ignore
        ///
        public abstract int StopPrimaryCustomAudioTrack();

        ///
        /// @ignore
        ///
        public abstract int StartSecondaryCustomAudioTrack(AudioTrackConfig config);

        ///
        /// @ignore
        ///
        public abstract int StopSecondaryCustomAudioTrack();

        ///
        /// <summary>
        /// Sets the rotation angle of the captured video.
        /// When the video capture device does not have the gravity sensing function, you can call this method to manually adjust the rotation angle of the captured video.
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
        /// The current connection state. For details, see CONNECTION_STATE_TYPE .
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
        /// Deprecated:The SDK automatically enables interoperability with the Web SDK, so you no longer need to call this method.This method enables or disables interoperability with the Agora Web SDK. If the channel has Web SDK users, ensure that you call this method, or the video of the Native user will be a black screen for the Web user.This method is only applicable in live streaming scenarios, and interoperability is enabled by default in communication scenarios.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable interoperability with the Agora Web SDK.true: Enable interoperability.false: (Default) Disable interoperability.</param>
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
        /// Registers a user account.
        /// Once registered, the user account can be used to identify the local user when the user joins the channel. After the registration is successful, the user account can identify the identity of the local user, and the user can use it to join the channel.After the user successfully registers a user account, the SDK triggers the OnLocalUserRegistered callback on the local client, reporting the user ID and user account of the local user.This method is optional. To join a channel with a user account, you can choose either of the following ways:Call RegisterLocalUserAccount to create a user account, and then call JoinChannelWithUserAccount [2/2] to join the channel.Call the JoinChannelWithUserAccount [2/2] method to join the channel.The difference between the two ways is that the time elapsed between calling the RegisterLocalUserAccount method and joining the channel is shorter than directly calling JoinChannelWithUserAccount [2/2].Ensure that you set the userAccount parameter; otherwise, this method does not take effect.Ensure that the userAccount is unique in the channel.To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="appId"> The App ID of your project on Agora Console.</param>
        ///
        /// <param name="userAccount"> The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are (89 in total):The 26 lowercase English letters: a to z.The 26 uppercase English letters: A to Z.All numeric characters: 0 to 9.Space"!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "= ", ".", "&gt;", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterLocalUserAccount(string appId, string userAccount);

        ///
        /// <summary>
        /// Sets the operation permissions of the SDK on the Audio Session.
        /// By default, both the SDK and the app have permission to operate the Audio Session. If you only need to use the app to operate the Audio Session, you can call this method to restrict the SDK's operation permissions to the Audio Session.You can call this method either before or after joining a channel. Once this method is called to restrict the SDK's operation permissions to the Audio Session, the restriction taks effect when the SDK needs to change the Audio Session.This method applies to iOS only.This method does not affect the operation permissions of the app on the Audio Session.
        /// </summary>
        ///
        /// <param name="restriction"> The operation permissions of the SDK on the audio session. See AUDIO_SESSION_OPERATION_RESTRICTION . This parameter is in bit mask format, and each bit corresponds to a permission.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);

        ///
        /// <summary>
        /// Provides the technical preview functionalities or special customizations by configuring the SDK with JSON options.
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
        /// <summary>
        /// Gets the audio device information.
        /// After calling this method, you can get whether the audio device supports ultra-low-latency capture and playback.This method is for Android only.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="deviceInfo"> Input and output parameter. A DeviceInfo object that identifies the audio device information.Input value: A DeviceInfo object.Output value: A DeviceInfo object containing audio device information.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioDeviceInfo(ref DeviceInfo deviceInfo);

        ///
        /// @ignore
        ///
        public abstract int EnableCustomAudioLocalPlayback(int sourceId, bool enabled);

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
        public abstract int EnableEchoCancellationExternal(bool enabled, int audioSourceDelay);

        ///
        /// @ignore
        ///
        public abstract int SetDirectExternalAudioSource(bool enable, bool localPlayback);

        ///
        /// @ignore
        ///
        public abstract int PushDirectAudioFrame(AudioFrame frame);

        ///
        /// <summary>
        /// Configure the connection with the native access module of the Agora network private media server.
        /// After successfully deploying the Agora private media server and integrating Agora Native SDK v4.0.0 on the intranet terminal, you can call this method to specify the Local Access Point and assign the Native access module to the SDK.This method takes effect only after the Agora hybrid cloud solution is deployed. You can contact to get to know more about the Agora hybrid cloud solution.Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="config"> The configurations of the Local Access Point. See LocalAccessPointConfiguration .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalAccessPoint(LocalAccessPointConfiguration config);

        ///
        /// <summary>
        /// Sets the pitch of the local music file.
        /// The same user may use two devices to send audio streams and video streams respectively. To ensure the time synchronization of the audio and video heard and seen by the receiver, you can call this method on the video sender and pass in the channel of the audio sender. name, user ID. The SDK will automatically adjust the sent video stream based on the timestamp of the sent audio stream to ensure that even when the upstream network conditions of the two senders are inconsistent (such as using Wi-Fi and 4G networks respectively), the The received audio and video have time synchronization.Agora recommends calling this method before .
        /// </summary>
        ///
        /// <param name="channelId"> Identifies the channel name of the channel where the audio sender is located.</param>
        ///
        /// <param name="uid"> User ID of the audio sender.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAVSyncSource(string channelId, uint uid);

        ///
        /// <summary>
        /// Enables/Disables video content moderation.
        /// When video content moderation is enabled, the SDK takes screenshots, reviews the content, and uploads videos sent by local users based on the type and frequency of the content moderation module you set in ContentInspectConfig . After content moderation, the Agora content moderation server sends the results to your app server in HTTPS requests and sends all screenshots to the third-party cloud storage service.If you set the type in ContentInspectModule to CONTENT_INSPECT_MODERATION, after the content moderation is completed, the SDK triggers the onContentInspectResult callback and reports the moderation result.Before calling this method, ensure that the Agora content moderation service has been enabled.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable video content moderation:true: Enable video content moderation.false: Disable video content moderation.</param>
        ///
        /// <param name="config"> Configuration of content moderation. See ContentInspectConfig .</param>
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
        public abstract int EnableWirelessAccelerate(bool enabled);

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
        /// Gets one IMediaRecorder object. 
        /// Make sure the IRtcEngine is initialized before you call this method.
        /// </summary>
        ///
        /// <returns>
        /// One IMediaRecorder object.
        /// </returns>
        ///
        public abstract IMediaRecorder GetMediaRecorder();
    };

    /* class_irtcengineex : irtcengine */
    public abstract class IRtcEngineEx : IRtcEngine
    {
        #region Multiple channels
        ///
        /// <summary>
        /// Joins a channel with the connection ID.
        /// You can call this method multiple times to join more than one channels.If you are already in a channel, you cannot rejoin it with the same user ID.If you want to join the same channel from different devices, ensure that the user IDs in all devices are different.Ensure that the app ID you use to generate the token is the same with the app ID used when creating the IRtcEngine instance.
        /// </summary>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions .</param>
        ///
        /// <param name="token"> The token generated on your server for authentication.</param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in the ChannelMediaOptions structure is invalid. You need to pass in a valid parameter and join the channel again.
        /// -3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: IRtcEngineThe internal state of the object is wrong. The typical cause is that you call this method to join the channel without calling StopEchoTest to stop the test after calling StartEchoTest [2/2] to start a call loop test. You need to call StopEchoTest before calling this method.
        /// -17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends using the OnConnectionStateChanged callback to get whether the user is in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.
        /// -102: The channel name is invalid. You need to pass in a valid channel name inchannelId to rejoin the channel.
        /// -121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options);

        ///
        /// <summary>
        /// Leaves a channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LeaveChannelEx(RtcConnection connection);
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
        /// -8: The internal state of the IRtcEngine object is wrong. The possible reason is that the user is not in the channel. Agora recommends using the OnConnectionStateChanged callback to get whether the user is in the channel. If you receive the CONNECTION_STATE_DISCONNECTED (1) or CONNECTION_STATE_FAILED (5) state, the user is not in the channel. You need to call JoinChannel [2/2] to join a channel before calling this method.
        /// </returns>
        ///
        public abstract int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the encoder configuration for the local video.
        /// Each configuration profile corresponds to a set of video parameters, including the resolution, frame rate, and bitrate.The config specified in this method is the maximum values under ideal network conditions. If the network condition is not good, the video engine cannot use the config renders local video, which automatically reduces to an appropriate video parameter setting.
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
        /// This method initializes the video view of a remote stream on the local device. It affects only the video view that the local user sees. Call this method to bind the remote video stream to a video view and to set the rendering and mirror modes of the video view.The application specifies the uid of the remote video in the VideoCanvas method before the remote user joins the channel.If the remote uid is unknown to the application, set it after the application receives the OnUserJoined callback. If the Video Recording function is enabled, the Video Recording Service joins the channel as a dummy client, causing other clients to also receive the onUserJoined callback. Do not bind the dummy client to the application view because the dummy client does not send any video streams.To unbind the remote user from the view, set the view parameter to NULL.Once the remote user leaves the channel, the SDK unbinds the remote user.
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
        /// This method is used to stops or resumes receiving the audio stream of a specified user. You can call this method before or after joining a channel. If a user leaves a channel, the settings in this method become invalid.
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
        /// This method is used to stops or resumes receiving the video stream of a specified user. You can call this method before or after joining a channel. If a user leaves a channel, the settings in this method become invalid.
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
        /// <param name="renderMode"> The video display mode of the remote user. For details, see RENDER_MODE_TYPE .</param>
        ///
        /// <param name="mirrorMode"> The mirror mode of the remote user view. For details, see VIDEO_MIRROR_MODE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection);

        ///
        /// <summary>
        /// Enables loopback audio capture.
        /// If you enable loopback audio capture, the output of the sound card is mixed into the audio stream sent to the other end.Applies to the macOS and Windows platforms only.macOS does not support loopback audio capture of the default sound card. If you need to use this method, use a virtual sound card and pass its name to the deviceName parameter. Agora recommends that you use Soundflower for loopback audio capture.You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="deviceName"> macOS: The device name of the virtual sound card. The default is set to null, which means the SDK uses Soundflower for loopback audio capture.
        ///  Windows: The device name of the sound card. The default is set to null, which means the SDK uses the sound card of your device for loopback audio capture.</param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="enabled"> Sets whether to enable loopback audio capture:
        ///  true: Enable loopback audio capture.false: (Default) Disable loopback audio capture.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLoopbackRecordingEx(bool enabled, RtcConnection connection);

        ///
        /// <summary>
        /// Gets the current connection state of the SDK.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <returns>
        /// The current connection state. For details, see CONNECTION_STATE_TYPE .
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
        /// <param name="streamId"> Output parameter. Pointer to the ID of the created data stream.</param>
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
        /// <param name="streamId"> Output parameter. Pointer to the ID of the created data stream.</param>
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
        /// After calling CreateDataStreamEx [2/2] , you can call this method to send data stream messages to all users in the channel.The SDK has the following restrictions on this method:Up to 30 packets can be sent per second in a channel with each packet having a maximum size of 1 kB.Each client can send up to 6 KB of data per second.Each user can have up to five data streams simultaneously.A successful method call triggers the OnStreamMessage callback on the remote client, from which the remote user gets the stream message. 
        /// A failed method call triggers the OnStreamMessageError callback on the remote client.Ensure that you call CreateDataStreamEx [2/2] to create a data channel before calling this method.This method applies only to the COMMUNICATION profile or to the hosts in the LIVE_BROADCASTING profile. If an audience in the LIVE_BROADCASTING profile calls this method, the audience may be switched to a host.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="streamId"> The data stream ID. You can get the data stream ID by calling CreateDataStreamEx [2/2].</param>
        ///
        /// <param name="data"> The data to be sent.</param>
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
        /// This method adds a PNG watermark image to the local video in the live streaming. Once the watermark image is added, all the audience in the channel (CDN audience included), and the capturing device can see and capture it. Agora supports adding only one watermark image onto the local video, and the newly watermark image replaces the previous one.The watermark coordinatesare dependent on the settings in the SetVideoEncoderConfigurationEx method:If the orientation mode of the encoding video ( ORIENTATION_MODE ) is fixed landscape mode or the adaptive landscape mode, the watermark uses the landscape orientation.If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed portrait mode or the adaptive portrait mode, the watermark uses the portrait orientation.When setting the watermark position, the region must be less than the SetVideoEncoderConfigurationEx dimensions set in the method; otherwise, the watermark image will be cropped.Ensure that you have called EnableVideo before calling this method.This method supports adding a watermark image in the PNG file format only. Supported pixel formats of the PNG image are RGBA, RGB, Palette, Gray, and Alpha_gray.If the dimensions of the PNG image differ from your settings in this method, the image will be cropped or zoomed to conform to your settings.If you have enabled the local video preview by calling the StartPreview [1/2] visibleInPreview member to set whether or not the watermark is visible in the preview.If you have enabled the mirror mode for the local video, the watermark on the local video is also mirrored. To avoid mirroring the watermark, Agora recommends that you do not use the mirror and watermark functions for the local video at the same time. You can implement the watermark function in your application layer.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="options"> The options of the watermark image to be added. </param>
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
        /// @ignore
        ///
        public abstract int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SetVideoProfileEx(int width, int height, int frameRate, int bitrate);

        ///
        /// @ignore
        ///
        public abstract int EnableDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int GetUserInfoByUserAccountEx(string userAccount, ref UserInfo userInfo, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int GetUserInfoByUidEx(uint uid, ref UserInfo userInfo, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection);

        ///
        /// <summary>
        /// Set the blacklist of subscriptions for audio streams.
        /// You can call this method to specify the audio streams of a user that you do not want to subscribe to.You can call this method either before or after joining a channel.The blacklist is not affected by the setting in MuteRemoteAudioStream , MuteAllRemoteAudioStreams and autoSubscribeAudio in ChannelMediaOptions .Once the blacklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.If a user is added in the whitelist and blacklist at the same time, only the blacklist takes effect.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to.If you want to specify the audio streams of a user that you do not want to subscribe to, add the user ID in this list. If you want to remove a user from the blacklist, you need to call the SetSubscribeAudioBlacklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioBlacklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the whitelist of subscriptions for audio streams.
        /// You can call this method to specify the audio streams of a user that you want to subscribe to. If a user is added in the whitelist and blacklist at the same time, only the blacklist takes effect.You can call this method either before or after joining a channel.The whitelist is not affected by the setting in MuteRemoteAudioStream , MuteAllRemoteAudioStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// Once the whitelist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to.
        ///  If you want to specify the audio streams of a user for subscription, add the user ID in this list. If you want to remove a user from the whitelist, you need to call the SetSubscribeAudioWhitelist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioWhitelistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// <summary>
        /// Set the blacklist of subscriptions for video streams.
        /// You can call this method to specify the video streams of a user that you do not want to subscribe to. If a user is added in the whitelist and blacklist at the same time, only the blacklist takes effect.Once the blacklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.You can call this method either before or after joining a channel.The blacklist is not affected by the setting in MuteRemoteVideoStream , MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to.
        ///  If you want to specify the video streams of a user that you do not want to subscribe to, add the user ID of that user in this list. If you want to remove a user from the blacklist, you need to call the SetSubscribeVideoBlacklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoBlacklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// <summary>
        /// Set the whitelist of subscriptions for video streams.
        /// You can call this method to specify the video streams of a user that you want to subscribe to. If a user is added in the whitelist and blacklist at the same time, only the blacklist takes effect.Once the whitelist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// You can call this method either before or after joining a channel.The whitelist is not affected by the setting in MuteRemoteVideoStream , MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions .
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list.</param>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to.
        ///  If you want to specify the video streams of a user for subscription, add the user ID of that user in this list. If you want to remove a user from the whitelist, you need to call the SetSubscribeVideoWhitelist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoWhitelistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SetDualStreamModeEx(VIDEO_SOURCE_TYPE sourceType, SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection);

        ///
        /// <summary>
        /// Takes a snapshot of a video stream.
        /// The method is asynchronous, and the SDK has not taken the snapshot when the method call returns. After a successful method call, the SDK triggers the OnSnapshotTaken callback to report whether the snapshot is successfully taken, as well as the details for that snapshot.
        /// This method takes a snapshot of a video stream from the specified user, generates a JPG image, and saves it to the specified path.
        /// Call this method after the JoinChannelEx method.This method takes a snapshot of the published video stream specified in ChannelMediaOptions .If the user's video has been preprocessed, for example, watermarked or beautified, the resulting snapshot includes the pre-processing effect.
        /// </summary>
        ///
        /// <param name="filePath"> The local path (including filename extensions) of the snapshot. For example:
        ///  Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.jpg
        ///  iOS: /App Sandbox/Library/Caches/example.jpg
        ///  macOS: ～/Library/Logs/example.jpg
        ///  Android: /storage/emulated/0/Android/data/<package name>/files/example.jpg
        ///  Ensure that the path you specify exists and is writable.</param>
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
    }
}