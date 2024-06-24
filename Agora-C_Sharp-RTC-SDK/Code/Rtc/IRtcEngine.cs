#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.UInt64;
namespace Agora.Rtc
{

    ///
    /// <summary>
    /// The basic interface of the Agora SDK that implements the core functions of real-time communication.
    /// 
    /// IRtcEngine provides the main methods that your app can call. Before calling other APIs, you must call CreateAgoraRtcEngine to create an IRtcEngine object.
    /// </summary>
    ///
    public abstract class IRtcEngine
    {
        ///
        /// @ignore
        ///
        public abstract void Dispose(bool sync = false);

        ///
        /// <summary>
        /// Provides technical preview functionalities or special customizations by configuring the SDK with JSON options.
        /// </summary>
        ///
        /// <param name="key"> The key of the option. </param>
        ///
        /// <param name="value"> The value of the key. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetParameters(string key, object value);

        ///
        /// <summary>
        /// Gets the C++ handle of the Native SDK.
        /// 
        /// This method retrieves the C++ handle of the SDK, which is used for registering the audio and video frame observer.
        /// </summary>
        ///
        /// <param name="nativeHandler"> Output parameter, the native handle of the SDK. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetNativeHandler(ref IntPtr nativeHandler);

        ///
        /// <summary>
        /// Unregisters the encoded audio frame observer.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnRegisterAudioEncodedFrameObserver();

        ///
        /// <summary>
        /// Adds event handlers
        /// 
        /// The SDK uses the IRtcEngineEventHandler class to send callbacks to the app. The app inherits the methods of this class to receive these callbacks. All methods in this class have default (empty) implementations. Therefore, apps only need to inherits callbacks according to the scenarios. In the callbacks, avoid time-consuming tasks or calling APIs that can block the thread, such as the SendStreamMessage method. Otherwise, the SDK may not work properly.
        /// </summary>
        ///
        /// <param name="engineEventHandler"> Callback events to be added. See IRtcEngineEventHandler. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int InitEventHandler(IRtcEngineEventHandler engineEventHandler);

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

        ///
        /// @ignore
        ///
        public abstract IMusicContentCenter GetMusicContentCenter();

        ///
        /// <summary>
        /// Gets one IMediaPlayerCacheManager instance.
        /// 
        /// When you successfully call this method, the SDK returns a media player cache manager instance. The cache manager is a singleton pattern. Therefore, multiple calls to this method returns the same instance. Make sure the IRtcEngine is initialized before you call this method.
        /// </summary>
        ///
        /// <returns>
        /// The IMediaPlayerCacheManager instance.
        /// </returns>
        ///
        public abstract IMediaPlayerCacheManager GetMediaPlayerCacheManager();

        ///
        /// <summary>
        /// Gets one ILocalSpatialAudioEngine object.
        /// 
        /// Make sure the IRtcEngine is initialized before you call this method.
        /// </summary>
        ///
        /// <returns>
        /// One ILocalSpatialAudioEngine object.
        /// </returns>
        ///
        public abstract ILocalSpatialAudioEngine GetLocalSpatialAudioEngine();

        ///
        /// @ignore
        ///
        public abstract IH265Transcoder GetH265Transcoder();

        ///
        /// <summary>
        /// Sets the maximum size of the media metadata.
        /// 
        /// After calling RegisterMediaMetadataObserver, you can call this method to set the maximum size of the media metadata.
        /// </summary>
        ///
        /// <param name="size"> The maximum size of media metadata. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        public abstract int SetMaxMetadataSize(int size);
#endif

        ///
        /// <summary>
        /// Sends media metadata.
        /// 
        /// If the metadata is sent successfully, the SDK triggers the OnMetadataReceived callback on the receiver.
        /// </summary>
        ///
        /// <param name="metadata"> Media metadata. See Metadata. </param>
        ///
        /// <param name="source_type"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        public abstract int SendMetadata(Metadata metadata, VIDEO_SOURCE_TYPE source_type);
#endif

        ///
        /// @ignore
        ///
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        public abstract int SetLocalVideoDataSourcePosition(VIDEO_MODULE_POSITION position);
#endif

        #region terra IRtcEngine
        ///
        /// <summary>
        /// Initializes IRtcEngine.
        /// 
        /// All called methods provided by the IRtcEngine class are executed asynchronously. Agora recommends calling these methods in the same thread.
        /// The SDK supports creating only one IRtcEngine instance for an app.
        /// </summary>
        ///
        /// <param name="context"> Configurations for the IRtcEngine instance. See RtcEngineContext. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// -7: The SDK is not initialized.
        /// -22: The resource request failed. The SDK fails to allocate resources because your app consumes too much system resource or the system resources are insufficient.
        /// -101: The App ID is invalid.
        /// </returns>
        ///
        public abstract int Initialize(RtcEngineContext context);

        ///
        /// <summary>
        /// Gets the SDK version.
        /// </summary>
        ///
        /// <param name="build"> The SDK build index. </param>
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
        /// <param name="code"> The error code or warning code reported by the SDK. </param>
        ///
        /// <returns>
        /// The specific error or warning description.
        /// </returns>
        ///
        public abstract string GetErrorDescription(int code);

        ///
        /// <summary>
        /// Queries the video codec capabilities of the SDK.
        /// </summary>
        ///
        /// <param name="codecInfo">
        /// Input and output parameter. An array representing the video codec capabilities of the SDK. See CodecCapInfo.
        /// Input value: One CodecCapInfo defined by the user when executing this method, representing the video codec capability to be queried.
        /// Output value: The CodecCapInfo after the method is executed, representing the actual video codec capabilities of the SDK.
        /// </param>
        ///
        /// <param name="size">
        /// Input and output parameter, represent the size of the CodecCapInfo array.
        /// Input value: Size of the CodecCapInfo defined by the user when executing the method.
        /// Output value: Size of the output CodecCapInfo after this method is executed.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int QueryCodecCapability(ref CodecCapInfo[] codecInfo, ref int size);

        ///
        /// <summary>
        /// Queries device score.
        /// </summary>
        ///
        /// <returns>
        /// &gt;0: The method call succeeeds, the value is the current device's score, the range is [0,100], the larger the value, the stronger the device capability. Most devices are rated between 60 and 100.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int QueryDeviceScore();

        ///
        /// <summary>
        /// Preloads a channel with token, channelId, and uid.
        /// 
        /// When audience members need to switch between different channels frequently, calling the method can help shortening the time of joining a channel, thus reducing the time it takes for audience members to hear and see the host. If you join a preloaded channel, leave it and want to rejoin the same channel, you do not need to call this method unless the token for preloading the channel expires. Failing to preload a channel does not mean that you can't join a channel, nor will it increase the time of joining a channel.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to 2 32 -1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and OnJoinChannelSuccess returns it in the callback. Your application must record and maintain the returned user ID, because the SDK does not do so. </param>
        ///
        /// <param name="token">
        /// The token generated on your server for authentication. When the token for preloading channels expires, you can update the token based on the number of channels you preload.
        /// When preloading one channel, calling this method to pass in the new token.
        /// When preloading more than one channels:
        /// If you use a wildcard token for all preloaded channels, call UpdatePreloadChannelToken to update the token. When generating a wildcard token, ensure the user ID is not set as 0.
        /// If you use different tokens to preload different channels, call this method to pass in your user ID, channel name and the new token.
        /// </param>
        ///
        /// <param name="channelId">
        /// The channel name that you want to preload. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters (89 characters in total):
        /// All lowercase English letters: a to z.
        /// All uppercase English letters: A to Z.
        /// All numeric characters: 0 to 9.
        /// Space
        /// "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -102: The channel name is invalid. You need to pass in a valid channel name and join the channel again.
        /// </returns>
        ///
        public abstract int PreloadChannel(string token, string channelId, uint uid);

        ///
        /// @ignore
        ///
        public abstract int PreloadChannelWithUserAccount(string token, string channelId, string userAccount);

        ///
        /// <summary>
        /// Updates the wildcard token for preloading channels.
        /// 
        /// You need to maintain the life cycle of the wildcard token by yourself. When the token expires, you need to generate a new wildcard token and then call this method to pass in the new token.
        /// </summary>
        ///
        /// <param name="token"> The new token. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid. You need to pass in a valid parameter and join the channel again.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// </returns>
        ///
        public abstract int UpdatePreloadChannelToken(string token);

        ///
        /// <summary>
        /// Joins a channel.
        /// 
        /// When the connection between the client and Agora's server is interrupted due to poor network conditions, the SDK tries reconnecting to the server. When the local client successfully rejoins the channel, the SDK triggers the OnRejoinChannelSuccess callback on the local client. A successful call of this method triggers the following callbacks:
        /// The local client: The OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
        /// The remote client: OnUserJoined, if the user joining the channel is in the Communication profile or is a host in the Live-broadcasting profile. This method enables users to join a channel. Users in the same channel can talk to each other, and multiple users in the same channel can start a group chat. Users with different App IDs cannot call each other.
        /// Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.
        /// If you choose the Testing Mode (using an App ID for authentication) for your project and call this method to join a channel, you will automatically exit the channel after 24 hours.
        /// </summary>
        ///
        /// <param name="channelId">
        /// The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters (89 characters in total):
        /// All lowercase English letters: a to z.
        /// All uppercase English letters: A to Z.
        /// All numeric characters: 0 to 9.
        /// Space
        /// "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
        /// </param>
        ///
        /// <param name="token"> The token generated on your server for authentication. If you need to join different channels at the same time or switch between channels, Agora recommends using a wildcard token so that you don't need to apply for a new token every time joining a channel. </param>
        ///
        /// <param name="info"> (Optional) Reserved for future use. </param>
        ///
        /// <param name="uid"> The user ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to 2 32 -1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and OnJoinChannelSuccess returns it in the callback. Your application must record and maintain the returned user ID, because the SDK does not do so. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in ChannelMediaOptions is invalid. You need to pass in a valid parameter and join the channel again.
        /// -3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: The internal state of the IRtcEngine object is wrong. The typical cause is that you call this method to join the channel without calling StartEchoTest [3/3] to stop the test after calling StopEchoTest to start a call loop test. You need to call StopEchoTest before calling this method.
        /// -17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED (1) state.
        /// -102: The channel name is invalid. You need to pass in a valid channelname in channelId to rejoin the channel.
        /// -121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannel(string token, string channelId, string info, uint uid);

        ///
        /// <summary>
        /// Joins a channel with media options.
        /// 
        /// This method enables users to join a channel. Users in the same channel can talk to each other, and multiple users in the same channel can start a group chat. Users with different App IDs cannot call each other. A successful call of this method triggers the following callbacks:
        /// The local client: The OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
        /// The remote client: OnUserJoined, if the user joining the channel is in the Communication profile or is a host in the Live-broadcasting profile. When the connection between the client and Agora's server is interrupted due to poor network conditions, the SDK tries reconnecting to the server. When the local client successfully rejoins the channel, the SDK triggers the OnRejoinChannelSuccess callback on the local client. Compared to JoinChannel [1/2], this method adds the options parameter to configure whether to automatically subscribe to all remote audio and video streams in the channel when the user joins the channel. By default, the user subscribes to the audio and video streams of all the other users in the channel, giving rise to usage and billings. To unsubscribe, set the options parameter or call the mute methods accordingly.
        /// This method allows users to join only one channel at a time.
        /// Ensure that the app ID you use to generate the token is the same app ID that you pass in the Initialize method; otherwise, you may fail to join the channel by token.
        /// If you choose the Testing Mode (using an App ID for authentication) for your project and call this method to join a channel, you will automatically exit the channel after 24 hours.
        /// </summary>
        ///
        /// <param name="token"> The token generated on your server for authentication. If you need to join different channels at the same time or switch between channels, Agora recommends using a wildcard token so that you don't need to apply for a new token every time joining a channel. </param>
        ///
        /// <param name="channelId">
        /// The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters (89 characters in total):
        /// All lowercase English letters: a to z.
        /// All uppercase English letters: A to Z.
        /// All numeric characters: 0 to 9.
        /// Space
        /// "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
        /// </param>
        ///
        /// <param name="uid"> The user ID. This parameter is used to identify the user in the channel for real-time audio and video interaction. You need to set and manage user IDs yourself, and ensure that each user ID in the same channel is unique. This parameter is a 32-bit unsigned integer. The value range is 1 to 2 32 -1. If the user ID is not assigned (or set to 0), the SDK assigns a random user ID and OnJoinChannelSuccess returns it in the callback. Your application must record and maintain the returned user ID, because the SDK does not do so. </param>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in ChannelMediaOptions is invalid. You need to pass in a valid parameter and join the channel again.
        /// -3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: The internal state of the IRtcEngine object is wrong. The typical cause is that you call this method to join the channel without calling StartEchoTest [3/3] to stop the test after calling StopEchoTest to start a call loop test. You need to call StopEchoTest before calling this method.
        /// -17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED (1) state.
        /// -102: The channel name is invalid. You need to pass in a valid channelname in channelId to rejoin the channel.
        /// -121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannel(string token, string channelId, uint uid, ChannelMediaOptions options);

        ///
        /// <summary>
        /// Updates the channel media options after joining the channel.
        /// </summary>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The value of a member in the ChannelMediaOptions structure is invalid. For example, the token or the user ID is invalid. You need to fill in a valid parameter.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: The internal state of the IRtcEngine object is wrong. The possible reason is that the user is not in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. If you receive the CONNECTION_STATE_DISCONNECTED (1) or CONNECTION_STATE_FAILED (5) state, the user is not in the channel. You need to call JoinChannel [2/2] to join a channel before calling this method.
        /// </returns>
        ///
        public abstract int UpdateChannelMediaOptions(ChannelMediaOptions options);

        ///
        /// <summary>
        /// Leaves a channel.
        /// 
        /// This method releases all resources related to the session. This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel. After joining the channel, you must call this method or LeaveChannel [2/2] to end the call, otherwise, the next call cannot be started. If you successfully call this method and leave the channel, the following callbacks are triggered:
        /// The local client: OnLeaveChannel.
        /// The remote client: OnUserOffline, if the user joining the channel is in the Communication profile, or is a host in the Live-broadcasting profile.
        /// If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.
        /// If you have called JoinChannelEx to join multiple channels, calling this method will leave the channels when calling JoinChannel [2/2] and JoinChannelEx at the same time.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// -7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int LeaveChannel();

        ///
        /// <summary>
        /// Sets channel options and leaves the channel.
        /// 
        /// If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.
        /// If you have called JoinChannelEx to join multiple channels, calling this method will leave the channels when calling JoinChannel [2/2] and JoinChannelEx at the same time. This method will release all resources related to the session, leave the channel, that is, hang up or exit the call. This method can be called whether or not a call is currently in progress. After joining the channel, you must call this method or to end the call, otherwise, the next call cannot be started. This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel. After actually leaving the channel, the local user triggers the OnLeaveChannel callback; after the user in the communication scenario and the host in the live streaming scenario leave the channel, the remote user triggers the OnUserOffline callback.
        /// </summary>
        ///
        /// <param name="options"> The options for leaving the channel. See LeaveChannelOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LeaveChannel(LeaveChannelOptions options);

        ///
        /// <summary>
        /// Renews the token.
        /// 
        /// You can call this method to pass a new token to the SDK. A token will expire after a certain period of time, at which point the SDK will be unable to establish a connection with the server.
        /// </summary>
        ///
        /// <param name="token"> The new token. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is empty.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// 110: Invalid token. Ensure the following:
        /// The user ID specified when generating the token is consistent with the user ID used when joining the channel.
        /// The generated token is the same as the token passed in to join the channel.
        /// </returns>
        ///
        public abstract int RenewToken(string token);

        ///
        /// <summary>
        /// Sets the channel profile.
        /// 
        /// After initializing the SDK, the default channel profile is the live streaming profile. You can call this method to set the channel profile. The Agora SDK differentiates channel profiles and applies optimization algorithms accordingly. For example, it prioritizes smoothness and low latency for a video call and prioritizes video quality for interactive live video streaming.
        /// To ensure the quality of real-time communication, Agora recommends that all users in a channel use the same channel profile.
        /// This method must be called and set before JoinChannel [2/2], and cannot be set again after joining the channel.
        /// </summary>
        ///
        /// <param name="profile"> The channel profile. See CHANNEL_PROFILE_TYPE. </param>
        ///
        /// <returns>
        /// 0(ERR_OK): Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int SetChannelProfile(CHANNEL_PROFILE_TYPE profile);

        ///
        /// <summary>
        /// Sets the client role.
        /// 
        /// In the interactive live streaming profile, the SDK sets the user role as audience by default. You can call this method to set the user role as host. You can call this method either before or after joining a channel. If you call this method to switch the user role after joining a channel, the SDK automatically does the following:
        /// Calls MuteLocalAudioStream and MuteLocalVideoStream to change the publishing state.
        /// Triggers OnClientRoleChanged on the local client.
        /// Triggers OnUserJoined or OnUserOffline on the remote client.
        /// </summary>
        ///
        /// <param name="role"> The user role. See CLIENT_ROLE_TYPE. If you set the user role as an audience member, you cannot publish audio and video streams in the channel. If you want to publish media streams in a channel during live streaming, ensure you set the user role as broadcaster. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// -7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role);

        ///
        /// <summary>
        /// Sets the user role and level in an interactive live streaming channel.
        /// 
        /// In the interactive live streaming profile, the SDK sets the user role as audience by default. You can call this method to set the user role as host. You can call this method either before or after joining a channel. If you call this method to switch the user role after joining a channel, the SDK automatically does the following:
        /// Calls MuteLocalAudioStream and MuteLocalVideoStream to change the publishing state.
        /// Triggers OnClientRoleChanged on the local client.
        /// Triggers OnUserJoined or OnUserOffline on the remote client. The difference between this method and SetClientRole [1/2] is that this method can set the user level in addition to the user role.
        /// The user role (role) determines the permissions that the SDK grants to a user, such as permission to send local streams, receive remote streams, and push streams to a CDN address.
        /// The user level (level) determines the level of services that a user can enjoy within the permissions of the user's role. For example, an audience member can choose to receive remote streams with low latency or ultra-low latency. User level affects the pricing of services. This method applies to the interactive live streaming profile (the profile parameter of SetChannelProfile is set as CHANNEL_PROFILE_LIVE_BROADCASTING) only.
        /// </summary>
        ///
        /// <param name="role"> The user role in the interactive live streaming. See CLIENT_ROLE_TYPE. </param>
        ///
        /// <param name="options"> The detailed options of a user, including the user level. See ClientRoleOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// -5: The request is rejected.
        /// -7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int SetClientRole(CLIENT_ROLE_TYPE role, ClientRoleOptions options);

        ///
        /// <summary>
        /// Starts an audio call test.
        /// 
        /// Deprecated: This method is deprecated, use StartEchoTest [2/3] instead. This method starts an audio call test to determine whether the audio devices (for example, headset and speaker) and the network connection are working properly. To conduct the test, the user speaks, and the recording is played back within 10 seconds. If the user can hear the recording within the interval, the audio devices and network connection are working properly.
        /// Call this method before joining a channel.
        /// After calling StartEchoTest [1/3], you must call StopEchoTest to end the test. Otherwise, the app cannot perform the next echo test, and you cannot join the channel.
        /// In the live streaming channels, only a host can call this method.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
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
        /// &lt; 0: Failure.
        /// -5(ERR_REFUSED): Failed to stop the echo test. The echo test may not be running.
        /// </returns>
        ///
        public abstract int StopEchoTest();

        ///
        /// <summary>
        /// Enables or disables multi-camera capture.
        /// 
        /// In scenarios where there are existing cameras to capture video, Agora recommends that you use the following steps to capture and publish video with multiple cameras:
        /// Call this method to enable multi-channel camera capture.
        /// Call StartPreview [2/2] to start the local video preview.
        /// Call StartCameraCapture, and set sourceType to start video capture with the second camera.
        /// Call JoinChannelEx, and set publishSecondaryCameraTrack to true to publish the video stream captured by the second camera in the channel. If you want to disable multi-channel camera capture, use the following steps:
        /// Call StopCameraCapture.
        /// Call this method with enabled set to false. You can call this method before and after StartPreview [2/2] to enable multi-camera capture:
        /// If it is enabled before StartPreview [2/2], the local video preview shows the image captured by the two cameras at the same time.
        /// If it is enabled after StartPreview [2/2], the SDK stops the current camera capture first, and then enables the primary camera and the second camera. The local video preview appears black for a short time, and then automatically returns to normal. This method applies to iOS only. When using this function, ensure that the system version is 13.0 or later. The minimum iOS device types that support multi-camera capture are as follows:
        /// iPhone XR
        /// iPhone XS
        /// iPhone XS Max
        /// iPad Pro 3rd generation and later
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable multi-camera video capture mode: true : Enable multi-camera capture mode; the SDK uses multiple cameras to capture video. false : Disable multi-camera capture mode; the SDK uses a single camera to capture video. </param>
        ///
        /// <param name="config"> Capture configuration for the second camera. See CameraCapturerConfiguration. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableMultiCamera(bool enabled, CameraCapturerConfiguration config);

        ///
        /// <summary>
        /// Enables the video module.
        /// 
        /// The video module is disabled by default, call this method to enable it. If you need to disable the video module later, you need to call DisableVideo.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableVideo();

        ///
        /// <summary>
        /// Disables the video module.
        /// 
        /// This method is used to disable the video module.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DisableVideo();

        ///
        /// <summary>
        /// Enables the local video preview.
        /// 
        /// You can call this method to enable local video preview.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartPreview();

        ///
        /// <summary>
        /// Enables the local video preview and specifies the video source for the preview.
        /// 
        /// This method is used to start local video preview and specify the video source that appears in the preview screen.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartPreview(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Stops the local video preview.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopPreview();

        ///
        /// <summary>
        /// Stops the local video preview.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopPreview(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Starts the last mile network probe test.
        /// 
        /// This method starts the last-mile network probe test before joining a channel to get the uplink and downlink last mile network statistics, including the bandwidth, packet loss, jitter, and round-trip time (RTT). Once this method is enabled, the SDK returns the following callbacks: OnLastmileQuality : The SDK triggers this callback within two seconds depending on the network conditions. This callback rates the network conditions and is more closely linked to the user experience. OnLastmileProbeResult : The SDK triggers this callback within 30 seconds depending on the network conditions. This callback returns the real-time statistics of the network conditions and is more objective. This method must be called before joining the channel, and is used to judge and predict whether the current uplink network quality is good enough.
        /// Do not call other methods before receiving the OnLastmileQuality and OnLastmileProbeResult callbacks. Otherwise, the callbacks may be interrupted.
        /// A host should not call this method after joining a channel (when in a call).
        /// </summary>
        ///
        /// <param name="config"> The configurations of the last-mile network probe test. See LastmileProbeConfig. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartLastmileProbeTest(LastmileProbeConfig config);

        ///
        /// <summary>
        /// Stops the last mile network probe test.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopLastmileProbeTest();

        ///
        /// <summary>
        /// Sets the video encoder configuration.
        /// 
        /// Sets the encoder configuration for the local video. Each configuration profile corresponds to a set of video parameters, including the resolution, frame rate, and bitrate.
        /// </summary>
        ///
        /// <param name="config"> Video profile. See VideoEncoderConfiguration. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVideoEncoderConfiguration(VideoEncoderConfiguration config);

        ///
        /// <summary>
        /// Sets the image enhancement options.
        /// 
        /// Enables or disables image enhancement, and sets the options.
        /// Call this method after calling EnableVideo or StartPreview [2/2].
        /// This method relies on the image enhancement dynamic library libagora_clear_vision_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// This feature has high requirements on device performance. When calling this method, the SDK automatically checks the capabilities of the current device.
        /// </summary>
        ///
        /// <param name="type"> Source type of the extension. See MEDIA_SOURCE_TYPE. </param>
        ///
        /// <param name="enabled"> Whether to enable the image enhancement function: true : Enable the image enhancement function. false : (Default) Disable the image enhancement function. </param>
        ///
        /// <param name="options"> The image enhancement options. See BeautyOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -4: The current device does not support this feature. Possible reasons include:
        /// The current device capabilities do not meet the requirements for image enhancement. Agora recommends you replace it with a high-performance device.
        /// The current device version is lower than Android 5.0 and does not support this feature. Agora recommends you replace the device or upgrade the operating system.
        /// </returns>
        ///
        public abstract int SetBeautyEffectOptions(bool enabled, BeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// @ignore
        ///
        public abstract int SetFaceShapeBeautyOptions(bool enabled, FaceShapeBeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// @ignore
        ///
        public abstract int SetFaceShapeAreaOptions(FaceShapeAreaOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// @ignore
        ///
        public abstract int GetFaceShapeBeautyOptions(ref FaceShapeBeautyOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// @ignore
        ///
        public abstract int GetFaceShapeAreaOptions(FACE_SHAPE_AREA shapeArea, ref FaceShapeAreaOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Sets low-light enhancement.
        /// 
        /// The low-light enhancement feature can adaptively adjust the brightness value of the video captured in situations with low or uneven lighting, such as backlit, cloudy, or dark scenes. It restores or highlights the image details and improves the overall visual effect of the video. You can call this method to enable the color enhancement feature and set the options of the color enhancement effect.
        /// Call this method after calling EnableVideo.
        /// Dark light enhancement has certain requirements for equipment performance. The low-light enhancement feature has certain performance requirements on devices. If your device overheats after you enable low-light enhancement, Agora recommends modifying the low-light enhancement options to a less performance-consuming level or disabling low-light enhancement entirely.
        /// Both this method and SetExtensionProperty can turn on low-light enhancement:
        /// When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).
        /// When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.
        /// This method relies on the image enhancement dynamic library libagora_clear_vision_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable low-light enhancement: true : Enable low-light enhancement. false : (Default) Disable low-light enhancement. </param>
        ///
        /// <param name="options"> The low-light enhancement options. See LowlightEnhanceOptions. </param>
        ///
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLowlightEnhanceOptions(bool enabled, LowlightEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Sets video noise reduction.
        /// 
        /// Underlit environments and low-end video capture devices can cause video images to contain significant noise, which affects video quality. In real-time interactive scenarios, video noise also consumes bitstream resources and reduces encoding efficiency during encoding. You can call this method to enable the video noise reduction feature and set the options of the video noise reduction effect.
        /// Call this method after calling EnableVideo.
        /// Video noise reduction has certain requirements for equipment performance. If your device overheats after you enable video noise reduction, Agora recommends modifying the video noise reduction options to a less performance-consuming level or disabling video noise reduction entirely.
        /// Both this method and SetExtensionProperty can turn on video noise reduction function:
        /// When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).
        /// When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.
        /// This method relies on the image enhancement dynamic library libagora_clear_vision_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE. </param>
        ///
        /// <param name="enabled"> Whether to enable video noise reduction: true : Enable video noise reduction. false : (Default) Disable video noise reduction. </param>
        ///
        /// <param name="options"> The video noise reduction options. See VideoDenoiserOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVideoDenoiserOptions(bool enabled, VideoDenoiserOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Sets color enhancement.
        /// 
        /// The video images captured by the camera can have color distortion. The color enhancement feature intelligently adjusts video characteristics such as saturation and contrast to enhance the video color richness and color reproduction, making the video more vivid. You can call this method to enable the color enhancement feature and set the options of the color enhancement effect.
        /// Call this method after calling EnableVideo.
        /// The color enhancement feature has certain performance requirements on devices. With color enhancement turned on, Agora recommends that you change the color enhancement level to one that consumes less performance or turn off color enhancement if your device is experiencing severe heat problems.
        /// Both this method and SetExtensionProperty can enable color enhancement:
        /// When you use the SDK to capture video, Agora recommends this method (this method only works for video captured by the SDK).
        /// When you use an external video source to implement custom video capture, or send an external video source to the SDK, Agora recommends using SetExtensionProperty.
        /// This method relies on the image enhancement dynamic library libagora_clear_vision_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="type"> The type of the video source. See MEDIA_SOURCE_TYPE. </param>
        ///
        /// <param name="enabled"> Whether to enable color enhancement: true Enable color enhancement. false : (Default) Disable color enhancement. </param>
        ///
        /// <param name="options"> The color enhancement options. See ColorEnhanceOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetColorEnhanceOptions(bool enabled, ColorEnhanceOptions options, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Enables/Disables the virtual background.
        /// 
        /// The virtual background feature enables the local user to replace their original background with a static image, dynamic video, blurred background, or portrait-background segmentation to achieve picture-in-picture effect. Once the virtual background feature is enabled, all users in the channel can see the custom background. Call this method after calling EnableVideo or StartPreview [2/2].
        /// This feature has high requirements on device performance. When calling this method, the SDK automatically checks the capabilities of the current device. Agora recommends you use virtual background on devices with the following processors:
        /// Snapdragon 700 series 750G and later
        /// Snapdragon 800 series 835 and later
        /// Dimensity 700 series 720 and later
        /// Kirin 800 series 810 and later
        /// Kirin 900 series 980 and later
        /// Devices with an i5 CPU and better
        /// Devices with an A9 chip and better, as follows:
        /// iPhone 6S and later
        /// iPad Air 3rd generation and later
        /// iPad 5th generation and later
        /// iPad Pro 1st generation and later
        /// iPad mini 5th generation and later
        /// Agora recommends that you use this feature in scenarios that meet the following conditions:
        /// A high-definition camera device is used, and the environment is uniformly lit.
        /// There are few objects in the captured video. Portraits are half-length and unobstructed. Ensure that the background is a solid color that is different from the color of the user's clothing.
        /// This method relies on the virtual background dynamic library libagora_segmentation_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable virtual background: true : Enable virtual background. false : Disable virtual background. </param>
        ///
        /// <param name="backgroundSource"> The custom background. See VirtualBackgroundSource. To adapt the resolution of the custom background image to that of the video captured by the SDK, the SDK scales and crops the custom background image while ensuring that the content of the custom background image is not distorted. </param>
        ///
        /// <param name="segproperty"> Processing properties for background images. See SegmentationProperty. </param>
        ///
        /// <param name="type">
        /// The type of the video source. See MEDIA_SOURCE_TYPE. In this method, this parameter supports only the following two settings:
        /// The default value is PRIMARY_CAMERA_SOURCE.
        /// If you want to use the second camera to capture video, set this parameter to SECONDARY_CAMERA_SOURCE.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -4: The device capabilities do not meet the requirements for the virtual background feature. Agora recommends you try it on devices with higher performance.
        /// </returns>
        ///
        public abstract int EnableVirtualBackground(bool enabled, VirtualBackgroundSource backgroundSource, SegmentationProperty segproperty, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE);

        ///
        /// <summary>
        /// Initializes the video view of a remote user.
        /// 
        /// This method initializes the video view of a remote stream on the local device. It affects only the video view that the local user sees. Call this method to bind the remote video stream to a video view and to set the rendering and mirror modes of the video view. You need to specify the ID of the remote user in this method. If the remote user ID is unknown to the application, set it after the app receives the OnUserJoined callback. To unbind the remote user from the view, set the view parameter to NULL. Once the remote user leaves the channel, the SDK unbinds the remote user. In the scenarios of custom layout for mixed videos on the mobile end, you can call this method and set a separate view for rendering each sub-video stream of the mixed video stream.
        /// If you need to implement native window rendering, use this method; if you only need to render video images in your Unity project, use the methods in the VideoSurface class instead.
        /// To update the rendering or mirror mode of the remote video view during a call, use the SetRemoteRenderMode method.
        /// If you use the Agora recording function, the recording client joins the channel as a placeholder client, triggering the OnUserJoined callback. Do not bind the placeholder client to the app view because the placeholder client does not send any video streams. If your app does not recognize the placeholder client, bind the remote user to the view when the SDK triggers the OnFirstRemoteVideoDecoded callback.
        /// </summary>
        ///
        /// <param name="canvas"> The remote video view and settings. See VideoCanvas. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetupRemoteVideo(VideoCanvas canvas);

        ///
        /// <summary>
        /// Initializes the local video view.
        /// 
        /// This method initializes the video view of a local stream on the local device. It affects only the video view that the local user sees, not the published local video stream. Call this method to bind the local video stream to a video view (view) and to set the rendering and mirror modes of the video view. After initialization, call this method to set the local video and then join the channel. The local video still binds to the view after you leave the channel. To unbind the local video from the view, set the view parameter as NULL. In real-time interactive scenarios, if you need to simultaneously view multiple preview frames in the local video preview, and each frame is at a different observation position along the video link, you can repeatedly call this method to set different view s and set different observation positions for each view. For example, by setting the video source to the camera and then configuring two view s with position setting to POSITION_POST_CAPTURER_ORIGIN and POSITION_POST_CAPTURER, you can simultaneously preview the raw, unprocessed video frame and the video frame that has undergone preprocessing (image enhancement effects, virtual background, watermark) in the local video preview.
        /// If you need to implement native window rendering, use this method; if you only need to render video images in your Unity project, use the methods in the VideoSurface class instead.
        /// You can call this method either before or after joining a channel.
        /// To update the rendering or mirror mode of the local video view during a call, use the SetLocalRenderMode [2/2] method.
        /// </summary>
        ///
        /// <param name="canvas"> The local video view and settings. See VideoCanvas. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetupLocalVideo(VideoCanvas canvas);

        ///
        /// <summary>
        /// Sets video application scenarios.
        /// 
        /// After successfully calling this method, the SDK will automatically enable the best practice strategies and adjust key performance metrics based on the specified scenario, to optimize the video experience. Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="scenarioType">
        /// The type of video application scenario. See VIDEO_APPLICATION_SCENARIO_TYPE. If set to APPLICATION_SCENARIO_MEETING (1), the SDK automatically enables the following strategies:
        /// In meeting scenarios where low-quality video streams are required to have a high bitrate, the SDK automatically enables multiple technologies used to deal with network congestions, to enhance the performance of the low-quality streams and to ensure the smooth reception by subscribers.
        /// The SDK monitors the number of subscribers to the high-quality video stream in real time and dynamically adjusts its configuration based on the number of subscribers.
        /// If nobody subscribers to the high-quality stream, the SDK automatically reduces its bitrate and frame rate to save upstream bandwidth.
        /// If someone subscribes to the high-quality stream, the SDK resets the high-quality stream to the VideoEncoderConfiguration configuration used in the most recent calling of SetVideoEncoderConfiguration. If no configuration has been set by the user previously, the following values are used:
        /// Resolution: (Windows and macOS) 1280 × 720; (Android and iOS) 960 × 540
        /// Frame rate: 15 fps
        /// Bitrate: (Windows and macOS) 1600 Kbps; (Android and iOS) 1000 Kbps
        /// The SDK monitors the number of subscribers to the low-quality video stream in real time and dynamically enables or disables it based on the number of subscribers. If the user has called SetDualStreamMode [2/2] to set that never send low-quality video stream (DISABLE_SIMULCAST_STREAM), the dynamic adjustment of the low-quality stream in meeting scenarios will not take effect.
        /// If nobody subscribes to the low-quality stream, the SDK automatically disables it to save upstream bandwidth.
        /// If someone subscribes to the low-quality stream, the SDK enables the low-quality stream and resets it to the SimulcastStreamConfig configuration used in the most recent calling of SetDualStreamMode [2/2]. If no configuration has been set by the user previously, the following values are used:
        /// Resolution: 480 × 272
        /// Frame rate: 15 fps
        /// Bitrate: 500 Kbps
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -4: Video application scenarios are not supported. Possible reasons include that you use the Voice SDK instead of the Video SDK.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// </returns>
        ///
        public abstract int SetVideoScenario(VIDEO_APPLICATION_SCENARIO_TYPE scenarioType);

        ///
        /// @ignore
        ///
        public abstract int SetVideoQoEPreference(VIDEO_QOE_PREFERENCE_TYPE qoePreference);

        ///
        /// <summary>
        /// Enables the audio module.
        /// 
        /// The audio module is enabled by default After calling DisableAudio to disable the audio module, you can call this method to re-enable it.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableAudio();

        ///
        /// <summary>
        /// Disables the audio module.
        /// 
        /// The audio module is enabled by default, and you can call this method to disable the audio module.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DisableAudio();

        ///
        /// <summary>
        /// Sets the audio profile and audio scenario.
        /// 
        /// Deprecated: This method is deprecated. If you need to set the audio profile, use SetAudioProfile [2/2]; if you need to set the audio scenario, use SetAudioScenario.
        /// </summary>
        ///
        /// <param name="profile"> The audio profile, including the sampling rate, bitrate, encoding mode, and the number of channels. See AUDIO_PROFILE_TYPE. </param>
        ///
        /// <param name="scenario"> The audio scenarios. Under different audio scenarios, the device uses different volume types. See AUDIO_SCENARIO_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        [Obsolete("This method is deprecated. You can use the \ref IRtcEngine::setAudioProfile(AUDIO_PROFILE_TYPE) \"setAudioProfile\" method instead. To set the audio scenario, call the \ref IRtcEngine::initialize \"initialize\" method and pass value in the `audioScenario` member in the RtcEngineContext struct.")]
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile, AUDIO_SCENARIO_TYPE scenario);

        ///
        /// <summary>
        /// Sets audio profiles.
        /// 
        /// If you need to set the audio scenario, you can either call SetAudioScenario, or Initialize and set the audioScenario in RtcEngineContext.
        /// </summary>
        ///
        /// <param name="profile"> The audio profile, including the sampling rate, bitrate, encoding mode, and the number of channels. See AUDIO_PROFILE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioProfile(AUDIO_PROFILE_TYPE profile);

        ///
        /// <summary>
        /// Sets audio scenarios.
        /// </summary>
        ///
        /// <param name="scenario"> The audio scenarios. Under different audio scenarios, the device uses different volume types. See AUDIO_SCENARIO_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioScenario(AUDIO_SCENARIO_TYPE scenario);

        ///
        /// <summary>
        /// Enables or disables the local audio capture.
        /// 
        /// The audio function is enabled by default when users joining a channel. This method disables or re-enables the local audio function to stop or restart local audio capturing. The difference between this method and MuteLocalAudioStream are as follows: EnableLocalAudio : Disables or re-enables the local audio capturing and processing. If you disable or re-enable local audio capturing using the EnableLocalAudio method, the local user might hear a pause in the remote audio playback. MuteLocalAudioStream : Sends or stops sending the local audio streams without affecting the audio capture status.
        /// </summary>
        ///
        /// <param name="enabled"> true : (Default) Re-enable the local audio function, that is, to start the local audio capturing device (for example, the microphone). false : Disable the local audio function, that is, to stop local audio capturing. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLocalAudio(bool enabled);

        ///
        /// <summary>
        /// Stops or resumes publishing the local audio stream.
        /// 
        /// This method is used to control whether to publish the locally captured audio stream. If you call this method to stop publishing locally captured audio streams, the audio capturing device will still work and won't be affected.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop publishing the local audio stream: true : Stops publishing the local audio stream. false : (Default) Resumes publishing the local audio stream. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalAudioStream(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio streams of all remote users.
        /// 
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users. By default, the SDK subscribes to the audio streams of all remote users when joining a channel. To modify this behavior, you can set autoSubscribeAudio to false when calling JoinChannel [2/2] to join the channel, which will cancel the subscription to the audio streams of all users upon joining the channel.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users: true : Stops subscribing to the audio streams of all remote users. false : (Default) Subscribes to the audio streams of all remote users by default. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        ///
        /// @ignore
        ///
        [Obsolete("This method is deprecated. To set whether to receive remote audio streams by default, call \ref IRtcEngine::muteAllRemoteAudioStreams \"muteAllRemoteAudioStreams\" before calling `joinChannel`")]
        public abstract int SetDefaultMuteAllRemoteAudioStreams(bool mute);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio stream of a specified user.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the specified user. </param>
        ///
        /// <param name="mute"> Whether to subscribe to the specified remote user's audio stream. true : Stop subscribing to the audio stream of the specified user. false : (Default) Subscribe to the audio stream of the specified user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        ///
        /// <summary>
        /// Stops or resumes publishing the local video stream.
        /// 
        /// This method is used to control whether to publish the locally captured video stream. If you call this method to stop publishing locally captured video streams, the video capturing device will still work and won't be affected. Compared to EnableLocalVideo (false), which can also cancel the publishing of local video stream by turning off the local video stream capture, this method responds faster.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop publishing the local video stream. true : Stop publishing the local video stream. false : (Default) Publish the local video stream. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalVideoStream(bool mute);

        ///
        /// <summary>
        /// Enables/Disables the local video capture.
        /// 
        /// This method disables or re-enables the local video capture, and does not affect receiving the remote video stream. After calling EnableVideo, the local video capture is enabled by default. If you call EnableLocalVideo (false) to disable local video capture within the channel, it also simultaneously stops publishing the video stream within the channel. If you want to restart video catpure, you can call EnableLocalVideo (true) and then call UpdateChannelMediaOptions to set the options parameter to publish the locally captured video stream in the channel. After the local video capturer is successfully disabled or re-enabled, the SDK triggers the OnRemoteVideoStateChanged callback on the remote client.
        /// You can call this method either before or after joining a channel.
        /// This method enables the internal engine and is valid after leaving the channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the local video capture. true : (Default) Enable the local video capture. false : Disable the local video capture. Once the local video is disabled, the remote users cannot receive the video stream of the local user, while the local user can still receive the video streams of remote users. When set to false, this method does not require a local camera. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLocalVideo(bool enabled);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the video streams of all remote users.
        /// 
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users. By default, the SDK subscribes to the video streams of all remote users when joining a channel. To modify this behavior, you can set autoSubscribeVideo to false when calling JoinChannel [2/2] to join the channel, which will cancel the subscription to the video streams of all users upon joining the channel.
        /// </summary>
        ///
        /// <param name="mute"> Whether to stop subscribing to the video streams of all remote users. true : Stop subscribing to the video streams of all remote users. false : (Default) Subscribe to the audio streams of all remote users by default. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteVideoStreams(bool mute);

        ///
        /// @ignore
        ///
        [Obsolete("This method is deprecated. To set whether to receive remote video streams by default, call \ref IRtcEngine::muteAllRemoteVideoStreams \"muteAllRemoteVideoStreams\" before calling `joinChannel`.")]
        public abstract int SetDefaultMuteAllRemoteVideoStreams(bool mute);

        ///
        /// <summary>
        /// Sets the default video stream type to subscribe to.
        /// 
        /// The SDK will dynamically adjust the size of the corresponding video stream based on the size of the video window to save bandwidth and computing resources. The default aspect ratio of the low-quality video stream is the same as that of the high-quality video stream. According to the current aspect ratio of the high-quality video stream, the system will automatically allocate the resolution, frame rate, and bitrate of the low-quality video stream. The SDK defaults to enabling low-quality video stream adaptive mode (AUTO_SIMULCAST_STREAM) on the sending end, which means the sender does not actively send low-quality video stream. The receiver with the role of the host can initiate a low-quality video stream request by calling this method, and upon receiving the request, the sending end automatically starts sending the low-quality video stream.
        /// Call this method before joining a channel. The SDK does not support changing the default subscribed video stream type after joining a channel.
        /// If you call both this method and SetRemoteVideoStreamType, the setting of SetRemoteVideoStreamType takes effect.
        /// </summary>
        ///
        /// <param name="streamType"> The default video-stream type. See VIDEO_STREAM_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteDefaultVideoStreamType(VIDEO_STREAM_TYPE streamType);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the video stream of a specified user.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the specified user. </param>
        ///
        /// <param name="mute"> Whether to subscribe to the specified remote user's video stream. true : Stop subscribing to the video streams of the specified user. false : (Default) Subscribe to the video stream of the specified user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteVideoStream(uint uid, bool mute);

        ///
        /// <summary>
        /// Sets the video stream type to subscribe to.
        /// 
        /// The SDK defaults to enabling low-quality video stream adaptive mode (AUTO_SIMULCAST_STREAM) on the sending end, which means the sender does not actively send low-quality video stream. The receiver with the role of the host can initiate a low-quality video stream request by calling this method, and upon receiving the request, the sending end automatically starts sending the low-quality video stream. The SDK will dynamically adjust the size of the corresponding video stream based on the size of the video window to save bandwidth and computing resources. The default aspect ratio of the low-quality video stream is the same as that of the high-quality video stream. According to the current aspect ratio of the high-quality video stream, the system will automatically allocate the resolution, frame rate, and bitrate of the low-quality video stream.
        /// You can call this method either before or after joining a channel.
        /// If the publisher has already called SetDualStreamMode [2/2] and set mode to DISABLE_SIMULCAST_STREAM (never send low-quality video stream), calling this method will not take effect, you should call SetDualStreamMode [2/2] again on the sending end and adjust the settings.
        /// Calling this method on the receiving end of the audience role will not take effect.
        /// If you call both SetRemoteVideoStreamType and SetRemoteDefaultVideoStreamType, the settings in SetRemoteVideoStreamType take effect.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. </param>
        ///
        /// <param name="streamType"> The video stream type, see VIDEO_STREAM_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVideoStreamType(uint uid, VIDEO_STREAM_TYPE streamType);

        ///
        /// <summary>
        /// Options for subscribing to remote video streams.
        /// 
        /// When a remote user has enabled dual-stream mode, you can call this method to choose the option for subscribing to the video streams sent by the remote user.
        /// If you only register one IVideoFrameObserver object, the SDK subscribes to the raw video data and encoded video data by default (the effect is equivalent to setting encodedFrameOnly to false).
        /// If you only register one IVideoEncodedFrameObserver object, the SDK only subscribes to the encoded video data by default (the effect is equivalent to setting encodedFrameOnly to true).
        /// If you register one IVideoFrameObserver object and one IVideoEncodedFrameObserver object successively, the SDK subscribes to the encoded video data by default (the effect is equivalent to setting encodedFrameOnly to false).
        /// If you call this method first with the options parameter set, and then register one IVideoFrameObserver or IVideoEncodedFrameObserver object, you need to call this method again and set the options parameter as described in the above two items to get the desired results. Agora recommends the following steps:
        /// Set autoSubscribeVideo to false when calling JoinChannel [2/2] to join a channel.
        /// Call this method after receiving the OnUserJoined callback to set the subscription options for the specified remote user's video stream.
        /// Call the MuteRemoteVideoStream method to resume subscribing to the video stream of the specified remote user. If you set encodedFrameOnly to true in the previous step, the SDK triggers the OnEncodedVideoFrameReceived callback locally to report the received encoded video frame information.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="options"> The video subscription options. See VideoSubscriptionOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVideoSubscriptionOptions(uint uid, VideoSubscriptionOptions options);

        ///
        /// <summary>
        /// Set the blocklist of subscriptions for audio streams.
        /// 
        /// You can call this method to specify the audio streams of a user that you do not want to subscribe to.
        /// You can call this method either before or after joining a channel.
        /// The blocklist is not affected by the setting in MuteRemoteAudioStream, MuteAllRemoteAudioStreams, and autoSubscribeAudio in ChannelMediaOptions.
        /// Once the blocklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.
        /// </summary>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to. If you want to specify the audio streams of a user that you do not want to subscribe to, add the user ID in this list. If you want to remove a user from the blocklist, you need to call the SetSubscribeAudioBlocklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list. </param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioBlocklist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Sets the allowlist of subscriptions for audio streams.
        /// 
        /// You can call this method to specify the audio streams of a user that you want to subscribe to.
        /// If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.
        /// You can call this method either before or after joining a channel.
        /// The allowlist is not affected by the setting in MuteRemoteAudioStream, MuteAllRemoteAudioStreams and autoSubscribeAudio in ChannelMediaOptions.
        /// Once the allowlist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// </summary>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to. If you want to specify the audio streams of a user for subscription, add the user ID in this list. If you want to remove a user from the allowlist, you need to call the SetSubscribeAudioAllowlist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list. </param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioAllowlist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Set the blocklist of subscriptions for video streams.
        /// 
        /// You can call this method to specify the video streams of a user that you do not want to subscribe to.
        /// If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.
        /// Once the blocklist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// You can call this method either before or after joining a channel.
        /// The blocklist is not affected by the setting in MuteRemoteVideoStream, MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions.
        /// </summary>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list. </param>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to. If you want to specify the video streams of a user that you do not want to subscribe to, add the user ID of that user in this list. If you want to remove a user from the blocklist, you need to call the SetSubscribeVideoBlocklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoBlocklist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Set the allowlist of subscriptions for video streams.
        /// 
        /// You can call this method to specify the video streams of a user that you want to subscribe to.
        /// If a user is added in the allowlist and blocklist at the same time, only the blocklist takes effect.
        /// Once the allowlist of subscriptions is set, it is effective even if you leave the current channel and rejoin the channel.
        /// You can call this method either before or after joining a channel.
        /// The allowlist is not affected by the setting in MuteRemoteVideoStream, MuteAllRemoteVideoStreams and autoSubscribeAudio in ChannelMediaOptions.
        /// </summary>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list. </param>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to. If you want to specify the video streams of a user for subscription, add the user ID of that user in this list. If you want to remove a user from the allowlist, you need to call the SetSubscribeVideoAllowlist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeVideoAllowlist(uint[] uidList, int uidNumber);

        ///
        /// <summary>
        /// Enables the reporting of users' volume indication.
        /// 
        /// This method enables the SDK to regularly report the volume information to the app of the local user who sends a stream and remote users (three users at most) whose instantaneous volumes are the highest.
        /// </summary>
        ///
        /// <param name="interval">
        /// Sets the time interval between two consecutive volume indications:
        /// ≤ 0: Disables the volume indication.
        /// > 0: Time interval (ms) between two consecutive volume indications. Ensure this parameter is set to a value greater than 10, otherwise you will not receive the OnAudioVolumeIndication callback. Agora recommends that this value is set as greater than 100.
        /// </param>
        ///
        /// <param name="smooth"> The smoothing factor that sets the sensitivity of the audio volume indicator. The value ranges between 0 and 10. The recommended value is 3. The greater the value, the more sensitive the indicator. </param>
        ///
        /// <param name="reportVad"> true : Enables the voice activity detection of the local user. Once it is enabled, the vad parameter of the OnAudioVolumeIndication callback reports the voice activity status of the local user. false : (Default) Disables the voice activity detection of the local user. Once it is disabled, the vad parameter of the OnAudioVolumeIndication callback does not report the voice activity status of the local user, except for the scenario where the engine automatically detects the voice activity of the local user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableAudioVolumeIndication(int interval, int smooth, bool reportVad);

        ///
        /// <summary>
        /// Starts audio recording on the client.
        /// 
        /// The sample rate of recording is 32 kHz by default and cannot be modified. The Agora SDK allows recording during a call. This method records the audio of all the users in the channel and generates an audio recording file. Supported formats of the recording file are as follows:.wav : Large file size with high fidelity..aac : Small file size with low fidelity. Ensure that the directory for the recording file exists and is writable. This method should be called after the JoinChannel [2/2] method. The recording automatically stops when you call the LeaveChannel [2/2] method.
        /// </summary>
        ///
        /// <param name="filePath"> The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.aac. Ensure that the directory for the log files exists and is writable. </param>
        ///
        /// <param name="quality"> Audio recording quality. See AUDIO_RECORDING_QUALITY_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality);

        ///
        /// <summary>
        /// Starts audio recording on the client and sets the sample rate of recording.
        /// 
        /// The Agora SDK allows recording during a call. After successfully calling this method, you can record the audio of all the users in the channel and get an audio recording file. Supported formats of the recording file are as follows:
        /// .wav: Large file size with high fidelity.
        /// .aac: Small file size with low fidelity.
        /// Ensure that the directory you use to save the recording file exists and is writable.
        /// This method should be called after the JoinChannel [2/2] method. The recording automatically stops when you call the LeaveChannel [2/2] method.
        /// For better recording effects, set quality to AUDIO_RECORDING_QUALITY_MEDIUM or AUDIO_RECORDING_QUALITY_HIGH when sampleRate is 44.1 kHz or 48 kHz.
        /// </summary>
        ///
        /// <param name="filePath"> The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.aac. Ensure that the directory for the log files exists and is writable. </param>
        ///
        /// <param name="sampleRate">
        /// The sample rate (kHz) of the recording file. Supported values are as follows:
        /// 16000
        /// (Default) 32000
        /// 44100
        /// 48000
        /// </param>
        ///
        /// <param name="quality"> Recording quality. See AUDIO_RECORDING_QUALITY_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        ///
        /// <summary>
        /// Starts audio recording on the client and sets recording configurations.
        /// 
        /// The Agora SDK allows recording during a call. After successfully calling this method, you can record the audio of users in the channel and get an audio recording file. Supported formats of the recording file are as follows:
        /// WAV: High-fidelity files with typically larger file sizes. For example, if the sample rate is 32,000 Hz, the file size for 10-minute recording is approximately 73 MB.
        /// AAC: Low-fidelity files with typically smaller file sizes. For example, if the sample rate is 32,000 Hz and the recording quality is AUDIO_RECORDING_QUALITY_MEDIUM, the file size for 10-minute recording is approximately 2 MB. Once the user leaves the channel, the recording automatically stops. Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="config"> Recording configurations. See AudioFileRecordingConfig. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioRecording(AudioRecordingConfiguration config);

        ///
        /// <summary>
        /// Registers an encoded audio observer.
        /// 
        /// Call this method after joining a channel.
        /// You can call this method or StartAudioRecording [3/3] to set the recording type and quality of audio files, but Agora does not recommend using this method and StartAudioRecording [3/3] at the same time. Only the method called later will take effect.
        /// </summary>
        ///
        /// <param name="config"> Observer settings for the encoded audio. See AudioEncodedFrameObserverConfig. </param>
        ///
        /// <param name="observer"> The encoded audio observer. See IAudioEncodedFrameObserver. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterAudioEncodedFrameObserver(AudioEncodedFrameObserverConfig config, IAudioEncodedFrameObserver observer);

        ///
        /// <summary>
        /// Stops the audio recording on the client.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopAudioRecording();

        ///
        /// <summary>
        /// Creates a media player instance.
        /// </summary>
        ///
        /// <returns>
        /// The IMediaPlayer instance, if the method call succeeds.
        /// An empty pointer, if the method call fails.
        /// </returns>
        ///
        public abstract IMediaPlayer CreateMediaPlayer();

        ///
        /// <summary>
        /// Destroys the media player instance.
        /// </summary>
        ///
        /// <param name="mediaPlayer"> One IMediaPlayer object. </param>
        ///
        /// <returns>
        /// ≥ 0: Success. Returns the ID of media player instance.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DestroyMediaPlayer(IMediaPlayer media_player);

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
        /// Starts playing the music file.
        /// 
        /// This method mixes the specified local or online audio file with the audio from the microphone, or replaces the microphone's audio with the specified local or remote audio file. A successful method call triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback. When the audio mixing file playback finishes, the SDK triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_STOPPED) callback on the local client.
        /// You can call this method either before or after joining a channel. If you need to call StartAudioMixing [1/2] multiple times, ensure that the time interval between calling this method is more than 500 ms.
        /// If the local music file does not exist, the SDK does not support the file format, or the the SDK cannot access the music file URL, the SDK reports 701.
        /// On Android, there are following considerations:
        /// To use this method, ensure that the Android device is v4.2 or later, and the API version is v16 or later.
        /// If you need to play an online music file, Agora does not recommend using the redirected URL address. Some Android devices may fail to open a redirected URL address.
        /// If you call this method on an emulator, ensure that the music file is in the /sdcard/ directory and the format is MP3.
        /// </summary>
        ///
        /// <param name="filePath"> If you have preloaded an audio effect into memory by calling PreloadEffect, ensure that the value of this parameter is the same as that of filePath in PreloadEffect. </param>
        ///
        /// <param name="loopback"> Whether to only play music files on the local client: true : Only play music files on the local client so that only the local user can hear the music. false : Publish music files to remote clients so that both the local user and remote users can hear the music. </param>
        ///
        /// <param name="cycle">
        /// The number of times the music file plays.
        /// ≥ 0: The number of playback times. For example, 0 means that the SDK does not play the music file while 1 means that the SDK plays once.
        /// -1: Play the audio file in an infinite loop.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle);

        ///
        /// <summary>
        /// Starts playing the music file.
        /// 
        /// This method mixes the specified local or online audio file with the audio from the microphone, or replaces the microphone's audio with the specified local or remote audio file. A successful method call triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback. When the audio mixing file playback finishes, the SDK triggers the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_STOPPED) callback on the local client.
        /// On Android, there are following considerations:
        /// To use this method, ensure that the Android device is v4.2 or later, and the API version is v16 or later.
        /// If you need to play an online music file, Agora does not recommend using the redirected URL address. Some Android devices may fail to open a redirected URL address.
        /// If you call this method on an emulator, ensure that the music file is in the /sdcard/ directory and the format is MP3.
        /// You can call this method either before or after joining a channel. If you need to call StartAudioMixing [2/2] multiple times, ensure that the time interval between calling this method is more than 500 ms.
        /// If the local music file does not exist, the SDK does not support the file format, or the the SDK cannot access the music file URL, the SDK reports 701.
        /// For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.
        /// </summary>
        ///
        /// <param name="filePath">
        /// File path:
        /// Android: The file path, which needs to be accurate to the file name and suffix. Agora supports URL addresses, absolute paths, or file paths that start with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example : content://com.android.providers.media.documents/document/audio%3A14441
        /// Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example : C:\music\audio.mp4.
        /// iOS or macOS: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: /var/mobile/Containers/Data/audio.mp4.
        /// </param>
        ///
        /// <param name="loopback"> Whether to only play music files on the local client: true : Only play music files on the local client so that only the local user can hear the music. false : Publish music files to remote clients so that both the local user and remote users can hear the music. </param>
        ///
        /// <param name="cycle">
        /// The number of times the music file plays.
        /// ≥ 0: The number of playback times. For example, 0 means that the SDK does not play the music file while 1 means that the SDK plays once.
        /// -1: Play the audio file in an infinite loop.
        /// </param>
        ///
        /// <param name="startPos"> The playback position (ms) of the music file. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// -3: The SDK is not ready.
        /// The audio module is disabled.
        /// The program is not complete.
        /// The initialization of IRtcEngine fails. Reinitialize the IRtcEngine.
        /// </returns>
        ///
        public abstract int StartAudioMixing(string filePath, bool loopback, int cycle, int startPos);

        ///
        /// <summary>
        /// Stops playing and mixing the music file.
        /// 
        /// This method stops the audio mixing. Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopAudioMixing();

        ///
        /// <summary>
        /// Pauses playing and mixing the music file.
        /// 
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAudioMixing();

        ///
        /// <summary>
        /// Resumes playing and mixing the music file.
        /// 
        /// This method resumes playing and mixing the music file. Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeAudioMixing();

        ///
        /// <summary>
        /// Selects the audio track used during playback.
        /// 
        /// After getting the track index of the audio file, you can call this method to specify any track to play. For example, if different tracks of a multi-track file store songs in different languages, you can call this method to set the playback language.
        /// For the supported formats of audio files, see.
        /// You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="index"> The audio track you want to specify. The value range is [0, GetAudioTrackCount ()]. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SelectAudioTrack(int index);

        ///
        /// <summary>
        /// Gets the index of audio tracks of the current music file.
        /// 
        /// You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// The SDK returns the index of the audio tracks if the method call succeeds.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioTrackCount();

        ///
        /// <summary>
        /// Adjusts the volume during audio mixing.
        /// 
        /// This method adjusts the audio mixing volume on both the local client and remote clients.
        /// Call this method after StartAudioMixing [2/2].
        /// </summary>
        ///
        /// <param name="volume"> Audio mixing volume. The value ranges between 0 and 100. The default value is 100, which means the original volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustAudioMixingVolume(int volume);

        ///
        /// <summary>
        /// Adjusts the volume of audio mixing for publishing.
        /// 
        /// This method adjusts the volume of audio mixing for publishing (sending to other users). Call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="volume"> The volume of audio mixing for local playback. The value ranges between 0 and 100 (default). 100 represents the original volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustAudioMixingPublishVolume(int volume);

        ///
        /// <summary>
        /// Retrieves the audio mixing volume for publishing.
        /// 
        /// This method helps troubleshoot audio volume‑related issues. You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The audio mixing volume, if this method call succeeds. The value range is [0,100].
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingPublishVolume();

        ///
        /// <summary>
        /// Adjusts the volume of audio mixing for local playback.
        /// 
        /// Call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="volume"> The volume of audio mixing for local playback. The value ranges between 0 and 100 (default). 100 represents the original volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustAudioMixingPlayoutVolume(int volume);

        ///
        /// <summary>
        /// Retrieves the audio mixing volume for local playback.
        /// 
        /// This method helps troubleshoot audio volume‑related issues. You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The audio mixing volume, if this method call succeeds. The value range is [0,100].
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingPlayoutVolume();

        ///
        /// <summary>
        /// Retrieves the duration (ms) of the music file.
        /// 
        /// Retrieves the total duration (ms) of the audio. You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The audio mixing duration, if this method call succeeds.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingDuration();

        ///
        /// <summary>
        /// Retrieves the playback position (ms) of the music file.
        /// 
        /// Retrieves the playback position (ms) of the audio. You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// If you need to call GetAudioMixingCurrentPosition multiple times, ensure that the time interval between calling this method is more than 500 ms.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The current playback position (ms) of the audio mixing, if this method call succeeds. 0 represents that the current music file does not start playing.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioMixingCurrentPosition();

        ///
        /// <summary>
        /// Sets the audio mixing position.
        /// 
        /// Call this method to set the playback position of the music file to a different starting position (the default plays from the beginning). You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="pos"> Integer. The playback position (ms). </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioMixingPosition(int pos);

        ///
        /// <summary>
        /// Sets the channel mode of the current audio file.
        /// 
        /// In a stereo music file, the left and right channels can store different audio data. According to your needs, you can set the channel mode to original mode, left channel mode, right channel mode, or mixed channel mode. For example, in the KTV scenario, the left channel of the music file stores the musical accompaniment, and the right channel stores the singing voice. If you only need to listen to the accompaniment, call this method to set the channel mode of the music file to left channel mode; if you need to listen to the accompaniment and the singing voice at the same time, call this method to set the channel mode to mixed channel mode.
        /// You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// This method only applies to stereo audio files.
        /// </summary>
        ///
        /// <param name="mode"> The channel mode. See AUDIO_MIXING_DUAL_MONO_MODE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioMixingDualMonoMode(AUDIO_MIXING_DUAL_MONO_MODE mode);

        ///
        /// <summary>
        /// Sets the pitch of the local music file.
        /// 
        /// When a local music file is mixed with a local human voice, call this method to set the pitch of the local music file only. You need to call this method after calling StartAudioMixing [2/2] and receiving the OnAudioMixingStateChanged (AUDIO_MIXING_STATE_PLAYING) callback.
        /// </summary>
        ///
        /// <param name="pitch"> Sets the pitch of the local music file by the chromatic scale. The default value is 0, which means keeping the original pitch. The value ranges from -12 to 12, and the pitch value between consecutive values is a chromatic value. The greater the absolute value of this parameter, the higher or lower the pitch of the local music file. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioMixingPitch(int pitch);

        ///
        /// <summary>
        /// Sets the playback speed of the current audio file.
        /// 
        /// Ensure you call this method after calling StartAudioMixing [2/2] receiving the OnAudioMixingStateChanged callback reporting the state as AUDIO_MIXING_STATE_PLAYING.
        /// </summary>
        ///
        /// <param name="speed">
        /// The playback speed. Agora recommends that you set this to a value between 50 and 400, defined as follows:
        /// 50: Half the original speed.
        /// 100: The original speed.
        /// 400: 4 times the original speed.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioMixingPlaybackSpeed(int speed);

        ///
        /// <summary>
        /// Retrieves the volume of the audio effects.
        /// 
        /// The volume is an integer ranging from 0 to 100. The default value is 100, which means the original volume. Call this method after PlayEffect.
        /// </summary>
        ///
        /// <returns>
        /// Volume of the audio effects, if this method call succeeds.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetEffectsVolume();

        ///
        /// <summary>
        /// Sets the volume of the audio effects.
        /// 
        /// Call this method after PlayEffect.
        /// </summary>
        ///
        /// <param name="volume"> The playback volume. The value range is [0, 100]. The default value is 100, which represents the original volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEffectsVolume(int volume);

        ///
        /// <summary>
        /// Preloads a specified audio effect file into the memory.
        /// 
        /// To ensure smooth communication, It is recommended that you limit the size of the audio effect file. You can call this method to preload the audio effect before calling JoinChannel [2/2]. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique. </param>
        ///
        /// <param name="filePath">
        /// File path:
        /// Android: The file path, which needs to be accurate to the file name and suffix. Agora supports URL addresses, absolute paths, or file paths that start with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example : content://com.android.providers.media.documents/document/audio%3A14441
        /// Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example : C:\music\audio.mp4.
        /// iOS or macOS: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: /var/mobile/Containers/Data/audio.mp4.
        /// </param>
        ///
        /// <param name="startPos"> The playback position (ms) of the audio effect file. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PreloadEffect(int soundId, string filePath, int startPos = 0);

        ///
        /// @ignore
        ///
        public abstract int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish = false, int startPos = 0);

        ///
        /// <summary>
        /// Plays all audio effect files.
        /// 
        /// After calling PreloadEffect multiple times to preload multiple audio effects into the memory, you can call this method to play all the specified audio effects for all users in the channel.
        /// </summary>
        ///
        /// <param name="loopCount">
        /// The number of times the audio effect loops:
        /// -1: Play the audio effect files in an indefinite loop until you call StopEffect or StopAllEffects.
        /// 0: Play the audio effect once.
        /// 1: Play the audio effect twice.
        /// </param>
        ///
        /// <param name="pitch"> The pitch of the audio effect. The value ranges between 0.5 and 2.0. The default value is 1.0 (original pitch). The lower the value, the lower the pitch. </param>
        ///
        /// <param name="pan">
        /// The spatial position of the audio effect. The value ranges between -1.0 and 1.0:
        /// -1.0: The audio effect shows on the left.
        /// 0: The audio effect shows ahead.
        /// 1.0: The audio effect shows on the right.
        /// </param>
        ///
        /// <param name="gain"> The volume of the audio effect. The value range is [0, 100]. The default value is 100 (original volume). The smaller the value, the lower the volume. </param>
        ///
        /// <param name="publish"> Whether to publish the audio effect to the remote users: true : Publish the audio effect to the remote users. Both the local user and remote users can hear the audio effect. false : (Default) Do not publish the audio effect to the remote users. Only the local user can hear the audio effect. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PlayAllEffects(int loopCount, double pitch, double pan, int gain, bool publish = false);

        ///
        /// <summary>
        /// Gets the volume of a specified audio effect file.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect file. </param>
        ///
        /// <returns>
        /// ≥ 0: Returns the volume of the specified audio effect, if the method call is successful. The value ranges between 0 and 100. 100 represents the original volume.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetVolumeOfEffect(int soundId);

        ///
        /// <summary>
        /// Sets the volume of a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect. The ID of each audio effect file is unique. </param>
        ///
        /// <param name="volume"> The playback volume. The value range is [0, 100]. The default value is 100, which represents the original volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVolumeOfEffect(int soundId, int volume);

        ///
        /// <summary>
        /// Pauses a specified audio effect file.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseEffect(int soundId);

        ///
        /// <summary>
        /// Pauses all audio effects.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAllEffects();

        ///
        /// <summary>
        /// Resumes playing a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeEffect(int soundId);

        ///
        /// <summary>
        /// Resumes playing all audio effect files.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeAllEffects();

        ///
        /// <summary>
        /// Stops playing a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect. Each audio effect has a unique ID. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopEffect(int soundId);

        ///
        /// <summary>
        /// Stops playing all audio effects.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopAllEffects();

        ///
        /// <summary>
        /// Releases a specified preloaded audio effect from the memory.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect. Each audio effect has a unique ID. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnloadEffect(int soundId);

        ///
        /// <summary>
        /// Releases a specified preloaded audio effect from the memory.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnloadAllEffects();

        ///
        /// <summary>
        /// Retrieves the duration of the audio effect file.
        /// 
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="filePath">
        /// File path:
        /// Android: The file path, which needs to be accurate to the file name and suffix. Agora supports URL addresses, absolute paths, or file paths that start with /assets/. You might encounter permission issues if you use an absolute path to access a local file, so Agora recommends using a URI address instead. For example : content://com.android.providers.media.documents/document/audio%3A14441
        /// Windows: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example : C:\music\audio.mp4.
        /// iOS or macOS: The absolute path or URL address (including the suffixes of the filename) of the audio effect file. For example: /var/mobile/Containers/Data/audio.mp4.
        /// </param>
        ///
        /// <returns>
        /// The total duration (ms) of the specified audio effect file, if the method call succeeds.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetEffectDuration(string filePath);

        ///
        /// <summary>
        /// Sets the playback position of an audio effect file.
        /// 
        /// After a successful setting, the local audio effect file starts playing at the specified position. Call this method after playEffect.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique. </param>
        ///
        /// <param name="pos"> The playback position (ms) of the audio effect file. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEffectPosition(int soundId, int pos);

        ///
        /// <summary>
        /// Retrieves the playback position of the audio effect file.
        /// 
        /// Call this method after PlayEffect.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique. </param>
        ///
        /// <returns>
        /// The playback position (ms) of the specified audio effect file, if the method call succeeds.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetEffectCurrentPosition(int soundId);

        ///
        /// <summary>
        /// Enables or disables stereo panning for remote users.
        /// 
        /// Ensure that you call this method before joining a channel to enable stereo panning for remote users so that the local user can track the position of a remote user by calling SetRemoteVoicePosition.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable stereo panning for remote users: true : Enable stereo panning. false : Disable stereo panning. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableSoundPositionIndication(bool enabled);

        ///
        /// <summary>
        /// Sets the 2D position (the position on the horizontal plane) of the remote user's voice.
        /// 
        /// This method sets the 2D position and volume of a remote user, so that the local user can easily hear and identify the remote user's position. When the local user calls this method to set the voice position of a remote user, the voice difference between the left and right channels allows the local user to track the real-time position of the remote user, creating a sense of space. This method applies to massive multiplayer online games, such as Battle Royale games.
        /// For this method to work, enable stereo panning for remote users by calling the EnableSoundPositionIndication method before joining a channel.
        /// For the best voice positioning, Agora recommends using a wired headset.
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="pan">
        /// The voice position of the remote user. The value ranges from -1.0 to 1.0:
        /// 0.0: (Default) The remote voice comes from the front.
        /// -1.0: The remote voice comes from the left.
        /// 1.0: The remote voice comes from the right.
        /// </param>
        ///
        /// <param name="gain"> The volume of the remote user. The value ranges from 0.0 to 100.0. The default value is 100.0 (the original volume of the remote user). The smaller the value, the lower the volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVoicePosition(uint uid, double pan, double gain);

        ///
        /// <summary>
        /// Enables or disables the spatial audio effect.
        /// 
        /// After enabling the spatial audio effect, you can call SetRemoteUserSpatialAudioParams to set the spatial audio effect parameters of the remote user.
        /// You can call this method either before or after joining a channel.
        /// This method relies on the spatial audio dynamic library libagora_spatial_audio_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the spatial audio effect: true : Enable the spatial audio effect. false : Disable the spatial audio effect. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableSpatialAudio(bool enabled);

        ///
        /// <summary>
        /// Sets the spatial audio effect parameters of the remote user.
        /// 
        /// Call this method after EnableSpatialAudio. After successfully setting the spatial audio effect parameters of the remote user, the local user can hear the remote user with a sense of space.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. This parameter must be the same as the user ID passed in when the user joined the channel. </param>
        ///
        /// <param name="param"> The spatial audio parameters. See SpatialAudioParams. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteUserSpatialAudioParams(uint uid, SpatialAudioParams @params);

        ///
        /// <summary>
        /// Sets a preset voice beautifier effect.
        /// 
        /// Call this method to set a preset voice beautifier effect for the local user who sends an audio stream. After setting a voice beautifier effect, all users in the channel can hear the effect. You can set different voice beautifier effects for different scenarios. To achieve better vocal effects, it is recommended that you call the following APIs before calling this method:
        /// Call SetAudioScenario to set the audio scenario to high-quality audio scenario, namely AUDIO_SCENARIO_GAME_STREAMING (3).
        /// Call SetAudioProfile [2/2] to set the profile parameter to AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5).
        /// You can call this method either before or after joining a channel.
        /// Do not set the profile parameter in SetAudioProfile [2/2] to AUDIO_PROFILE_SPEECH_STANDARD (1) or AUDIO_PROFILE_IOT (6), or the method does not take effect.
        /// This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.
        /// After calling SetVoiceBeautifierPreset, Agora does not recommend calling the following methods, otherwise the effect set by SetVoiceBeautifierPreset will be overwritten: SetAudioEffectPreset SetAudioEffectParameters SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset
        /// This method relies on the voice beautifier dynamic library libagora_audio_beauty_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="preset"> The preset voice beautifier effect options: VOICE_BEAUTIFIER_PRESET. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset);

        ///
        /// <summary>
        /// Sets an SDK preset audio effect.
        /// 
        /// To achieve better vocal effects, it is recommended that you call the following APIs before calling this method:
        /// Call SetAudioScenario to set the audio scenario to high-quality audio scenario, namely AUDIO_SCENARIO_GAME_STREAMING (3).
        /// Call SetAudioProfile [2/2] to set the profile parameter to AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5). Call this method to set an SDK preset audio effect for the local user who sends an audio stream. This audio effect does not change the gender characteristics of the original voice. After setting an audio effect, all users in the channel can hear the effect.
        /// Do not set the profile parameter in SetAudioProfile [2/2] to AUDIO_PROFILE_SPEECH_STANDARD (1) or AUDIO_PROFILE_IOT (6), or the method does not take effect.
        /// You can call this method either before or after joining a channel.
        /// If you call SetAudioEffectPreset and set enumerators except for ROOM_ACOUSTICS_3D_VOICE or PITCH_CORRECTION, do not call SetAudioEffectParameters; otherwise, SetAudioEffectPreset is overridden.
        /// After calling SetAudioEffectPreset, Agora does not recommend you to call the following methods, otherwise the effect set by SetAudioEffectPreset will be overwritten: SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset
        /// This method relies on the voice beautifier dynamic library libagora_audio_beauty_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="preset"> The options for SDK preset audio effects. See AUDIO_EFFECT_PRESET. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset);

        ///
        /// <summary>
        /// Sets a preset voice beautifier effect.
        /// 
        /// To achieve better vocal effects, it is recommended that you call the following APIs before calling this method:
        /// Call SetAudioScenario to set the audio scenario to high-quality audio scenario, namely AUDIO_SCENARIO_GAME_STREAMING (3).
        /// Call SetAudioProfile [2/2] to set the profile parameter to AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5). Call this method to set a preset voice beautifier effect for the local user who sends an audio stream. After setting an audio effect, all users in the channel can hear the effect. You can set different voice beautifier effects for different scenarios.
        /// Do not set the profile parameter in SetAudioProfile [2/2] to AUDIO_PROFILE_SPEECH_STANDARD (1) or AUDIO_PROFILE_IOT (6), or the method does not take effect.
        /// You can call this method either before or after joining a channel.
        /// This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.
        /// After calling SetVoiceConversionPreset, Agora does not recommend you to call the following methods, otherwise the effect set by SetVoiceConversionPreset will be overwritten: SetAudioEffectPreset SetAudioEffectParameters SetVoiceBeautifierPreset SetVoiceBeautifierParameters SetLocalVoicePitch SetLocalVoiceFormant SetLocalVoiceEqualization SetLocalVoiceReverb
        /// This method relies on the voice beautifier dynamic library libagora_audio_beauty_extension.dll. If the dynamic library is deleted, the function cannot be enabled normally.
        /// </summary>
        ///
        /// <param name="preset"> The options for the preset voice beautifier effects: VOICE_CONVERSION_PRESET. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVoiceConversionPreset(VOICE_CONVERSION_PRESET preset);

        ///
        /// <summary>
        /// Sets parameters for SDK preset audio effects.
        /// 
        /// To achieve better vocal effects, it is recommended that you call the following APIs before calling this method:
        /// Call SetAudioScenario to set the audio scenario to high-quality audio scenario, namely AUDIO_SCENARIO_GAME_STREAMING (3).
        /// Call SetAudioProfile [2/2] to set the profile parameter to AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5). Call this method to set the following parameters for the local user who sends an audio stream:
        /// 3D voice effect: Sets the cycle period of the 3D voice effect.
        /// Pitch correction effect: Sets the basic mode and tonic pitch of the pitch correction effect. Different songs have different modes and tonic pitches. Agora recommends bounding this method with interface elements to enable users to adjust the pitch correction interactively. After setting the audio parameters, all users in the channel can hear the effect.
        /// Do not set the profile parameter in SetAudioProfile [2/2] to AUDIO_PROFILE_SPEECH_STANDARD (1) or AUDIO_PROFILE_IOT (6), or the method does not take effect.
        /// You can call this method either before or after joining a channel.
        /// This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.
        /// After calling SetAudioEffectParameters, Agora does not recommend you to call the following methods, otherwise the effect set by SetAudioEffectParameters will be overwritten: SetAudioEffectPreset SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceBeautifierParameters SetVoiceConversionPreset
        /// </summary>
        ///
        /// <param name="preset">
        /// The options for SDK preset audio effects: ROOM_ACOUSTICS_3D_VOICE, 3D voice effect:
        /// You need to set the profile parameter in SetAudioProfile [2/2] to AUDIO_PROFILE_MUSIC_STANDARD_STEREO (3) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5) before setting this enumerator; otherwise, the enumerator setting does not take effect.
        /// If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect. PITCH_CORRECTION, Pitch correction effect:
        /// </param>
        ///
        /// <param name="param1">
        /// If you set preset to ROOM_ACOUSTICS_3D_VOICE, param1 sets the cycle period of the 3D voice effect. The value range is [1,60] and the unit is seconds. The default value is 10, indicating that the voice moves around you every 10 seconds.
        /// If you set preset to PITCH_CORRECTION, param1 indicates the basic mode of the pitch correction effect: 1 : (Default) Natural major scale. 2 : Natural minor scale. 3 : Japanese pentatonic scale.
        /// </param>
        ///
        /// <param name="param2">
        /// If you set preset to ROOM_ACOUSTICS_3D_VOICE , you need to set param2 to 0.
        /// If you set preset to PITCH_CORRECTION, param2 indicates the tonic pitch of the pitch correction effect: 1 : A 2 : A# 3 : B 4 : (Default) C 5 : C# 6 : D 7 : D# 8 : E 9 : F 10 : F# 11 : G 12 : G#
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2);

        ///
        /// <summary>
        /// Sets parameters for the preset voice beautifier effects.
        /// 
        /// To achieve better vocal effects, it is recommended that you call the following APIs before calling this method:
        /// Call SetAudioScenario to set the audio scenario to high-quality audio scenario, namely AUDIO_SCENARIO_GAME_STREAMING (3).
        /// Call SetAudioProfile [2/2] to set the profile parameter to AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO (5). Call this method to set a gender characteristic and a reverberation effect for the singing beautifier effect. This method sets parameters for the local user who sends an audio stream. After setting the audio parameters, all users in the channel can hear the effect.
        /// Do not set the profile parameter in SetAudioProfile [2/2] to AUDIO_PROFILE_SPEECH_STANDARD (1) or AUDIO_PROFILE_IOT (6), or the method does not take effect.
        /// You can call this method either before or after joining a channel.
        /// This method has the best effect on human voice processing, and Agora does not recommend calling this method to process audio data containing music.
        /// After calling SetVoiceBeautifierParameters, Agora does not recommend calling the following methods, otherwise the effect set by SetVoiceBeautifierParameters will be overwritten: SetAudioEffectPreset SetAudioEffectParameters SetVoiceBeautifierPreset SetLocalVoicePitch SetLocalVoiceEqualization SetLocalVoiceReverb SetVoiceConversionPreset
        /// </summary>
        ///
        /// <param name="preset"> The option for the preset audio effect: SINGING_BEAUTIFIER : The singing beautifier effect. </param>
        ///
        /// <param name="param1"> The gender characteristics options for the singing voice: 1 : A male-sounding voice. 2 : A female-sounding voice. </param>
        ///
        /// <param name="param2"> The reverberation effect options for the singing voice: 1 : The reverberation effect sounds like singing in a small room. 2 : The reverberation effect sounds like singing in a large room. 3 : The reverberation effect sounds like singing in a hall. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
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
        /// 
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="pitch"> The local voice pitch. The value range is [0.5,2.0]. The lower the value, the lower the pitch. The default value is 1.0 (no change to the pitch). </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoicePitch(double pitch);

        ///
        /// <summary>
        /// Set the formant ratio to change the timbre of human voice.
        /// 
        /// Formant ratio affects the timbre of voice. The smaller the value, the deeper the sound will be, and the larger, the sharper. You can call this method to set the formant ratio of local audio to change the timbre of human voice. After you set the formant ratio, all users in the channel can hear the changed voice. If you want to change the timbre and pitch of voice at the same time, Agora recommends using this method together with SetLocalVoicePitch. You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="formantRatio"> The formant ratio. The value range is [-1.0, 1.0]. The default value is 0.0, which means do not change the timbre of the voice. Agora recommends setting this value within the range of [-0.4, 0.6]. Otherwise, the voice may be seriously distorted. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoiceFormant(double formantRatio);

        ///
        /// <summary>
        /// Sets the local voice equalization effect.
        /// 
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="bandFrequency"> The band frequency. The value ranges between 0 and 9; representing the respective 10-band center frequencies of the voice effects, including 31, 62, 125, 250, 500, 1k, 2k, 4k, 8k, and 16k Hz. See AUDIO_EQUALIZATION_BAND_FREQUENCY. </param>
        ///
        /// <param name="bandGain"> The gain of each band in dB. The value ranges between -15 and 15. The default value is 0. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);

        ///
        /// <summary>
        /// Sets the local voice reverberation.
        /// 
        /// The SDK provides an easier-to-use method, SetAudioEffectPreset, to directly implement preset reverb effects for such as pop, R&B, and KTV. You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="reverbKey"> The reverberation key. Agora provides five reverberation keys, see AUDIO_REVERB_TYPE. </param>
        ///
        /// <param name="value"> The value of the reverberation key. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value);

        ///
        /// <summary>
        /// Sets the preset headphone equalization effect.
        /// 
        /// This method is mainly used in spatial audio effect scenarios. You can select the preset headphone equalizer to listen to the audio to achieve the expected audio experience. If the headphones you use already have a good equalization effect, you may not get a significant improvement when you call this method, and could even diminish the experience.
        /// </summary>
        ///
        /// <param name="preset"> The preset headphone equalization effect. See HEADPHONE_EQUALIZER_PRESET. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// </returns>
        ///
        public abstract int SetHeadphoneEQPreset(HEADPHONE_EQUALIZER_PRESET preset);

        ///
        /// <summary>
        /// Sets the low- and high-frequency parameters of the headphone equalizer.
        /// 
        /// In a spatial audio effect scenario, if the preset headphone equalization effect is not achieved after calling the SetHeadphoneEQPreset method, you can further adjust the headphone equalization effect by calling this method.
        /// </summary>
        ///
        /// <param name="lowGain"> The low-frequency parameters of the headphone equalizer. The value range is [-10,10]. The larger the value, the deeper the sound. </param>
        ///
        /// <param name="highGain"> The high-frequency parameters of the headphone equalizer. The value range is [-10,10]. The larger the value, the sharper the sound. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// </returns>
        ///
        public abstract int SetHeadphoneEQParameters(int lowGain, int highGain);

        ///
        /// @ignore
        ///
        public abstract int EnableVoiceAITuner(bool enabled, VOICE_AI_TUNER_TYPE type);

        ///
        /// <summary>
        /// Sets the log file.
        /// 
        /// Deprecated: Use the mLogConfig parameter in Initialize method instead. Specifies an SDK output log file. The log file records all log data for the SDK’s operation. Ensure that the directory for the log file exists and is writable. Ensure that you call Initialize immediately after calling the IRtcEngine method, or the output log may not be complete.
        /// </summary>
        ///
        /// <param name="filePath"> The complete path of the log files. These log files are encoded in UTF-8. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLogFile(string filePath);

        ///
        /// <summary>
        /// Sets the log output level of the SDK.
        /// 
        /// Deprecated: Use logConfig in Initialize instead.
        /// </summary>
        ///
        /// <param name="filter"> The output log level of the SDK. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLogFilter(uint filter);

        ///
        /// <summary>
        /// Sets the output log level of the SDK.
        /// 
        /// Deprecated: This method is deprecated. Use RtcEngineContext instead to set the log output level. Choose a level to see the logs preceding that level.
        /// </summary>
        ///
        /// <param name="level"> The log level: LOG_LEVEL. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLogLevel(LOG_LEVEL level);

        ///
        /// <summary>
        /// Sets the log file size.
        /// 
        /// Deprecated: Use the logConfig parameter in Initialize instead. By default, the SDK generates five SDK log files and five API call log files with the following rules:
        /// The SDK log files are: agorasdk.log, agorasdk.1.log, agorasdk.2.log, agorasdk.3.log, and agorasdk.4.log.
        /// The API call log files are: agoraapi.log, agoraapi.1.log, agoraapi.2.log, agoraapi.3.log, and agoraapi.4.log.
        /// The default size of each SDK log file and API log file is 2,048 KB. These log files are encoded in UTF-8.
        /// The SDK writes the latest logs in agorasdk.log or agoraapi.log.
        /// When agorasdk.log is full, the SDK processes the log files in the following order:
        /// Delete the agorasdk.4.log file (if any).
        /// Rename agorasdk.3.log to agorasdk.4.log.
        /// Rename agorasdk.2.log to agorasdk.3.log.
        /// Rename agorasdk.1.log to agorasdk.2.log.
        /// Create a new agorasdk.log file.
        /// The overwrite rules for the agoraapi.log file are the same as for agorasdk.log. This method is used to set the size of the agorasdk.log file only and does not effect the agoraapi.log file.
        /// </summary>
        ///
        /// <param name="fileSizeInKBytes"> The size (KB) of an agorasdk.log file. The value range is [128,20480]. The default value is 2,048 KB. If you set fileSizeInKByte smaller than 128 KB, the SDK automatically adjusts it to 128 KB; if you set fileSizeInKByte greater than 20,480 KB, the SDK automatically adjusts it to 20,480 KB. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLogFileSize(uint fileSizeInKBytes);

        ///
        /// @ignore
        ///
        public abstract int UploadLogFile(ref string requestId);

        ///
        /// @ignore
        ///
        public abstract int WriteLog(LOG_LEVEL level, string fmt);

        ///
        /// <summary>
        /// Sets the local video display mode.
        /// 
        /// Deprecated: This method is deprecated. Use SetLocalRenderMode [2/2] instead. Call this method to set the local video display mode. This method can be called multiple times during a call to change the display mode.
        /// </summary>
        ///
        /// <param name="renderMode"> The local video display mode. See RENDER_MODE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        ///
        /// <summary>
        /// Updates the display mode of the video view of a remote user.
        /// 
        /// After initializing the video view of a remote user, you can call this method to update its rendering and mirror modes. This method affects only the video view that the local user sees.
        /// During a call, you can call this method as many times as necessary to update the display mode of the video view of a remote user.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="renderMode"> The rendering mode of the remote user view. For details, see RENDER_MODE_TYPE. </param>
        ///
        /// <param name="mirrorMode"> The mirror mode of the remote user view. See VIDEO_MIRROR_MODE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteRenderMode(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        ///
        /// <summary>
        /// Updates the display mode of the local video view.
        /// 
        /// After initializing the local video view, you can call this method to update its rendering and mirror modes. It affects only the video view that the local user sees, not the published local video stream.
        /// Ensure that you have called the SetupLocalVideo method to initialize the local video view before calling this method.
        /// During a call, you can call this method as many times as necessary to update the display mode of the local video view.
        /// This method only takes effect on the primary camera (PRIMARY_CAMERA_SOURCE). In scenarios involving custom video capture or the use of alternative video sources, you need to use SetupLocalVideo instead of this method.
        /// </summary>
        ///
        /// <param name="renderMode"> The local video display mode. See RENDER_MODE_TYPE. </param>
        ///
        /// <param name="mirrorMode"> The mirror mode of the local video view. See VIDEO_MIRROR_MODE_TYPE. This parameter is only effective when rendering custom videos. If you want to mirror the video view, set the scaleX of the GameObject attached to the video view as -1 or +1. If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalRenderMode(RENDER_MODE_TYPE renderMode);

        ///
        /// <summary>
        /// Sets the local video mirror mode.
        /// 
        /// Deprecated: This method is deprecated. Use SetLocalRenderMode [2/2] instead.
        /// </summary>
        ///
        /// <param name="mirrorMode"> The local video mirror mode. See VIDEO_MIRROR_MODE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode);

        ///
        /// <summary>
        /// Enables or disables dual-stream mode on the sender side.
        /// 
        /// This method is applicable to all types of streams from the sender, including but not limited to video streams collected from cameras, screen sharing streams, and custom-collected video streams.
        /// If you need to enable dual video streams in a multi-channel scenario, you can call the EnableDualStreamModeEx method.
        /// You can call this method either before or after joining a channel. Deprecated: This method is deprecated as of v4.2.0. Use SetDualStreamMode [1/2] instead. Dual streams are a pairing of a high-quality video stream and a low-quality video stream:
        /// High-quality video stream: High bitrate, high resolution.
        /// Low-quality video stream: Low bitrate, low resolution. After you enable dual-stream mode, you can call SetRemoteVideoStreamType to choose to receive either the high-quality video stream or the low-quality video stream on the subscriber side.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode: true : Enable dual-stream mode. false : (Default) Disable dual-stream mode. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableDualStreamMode(bool enabled);

        ///
        /// <summary>
        /// Sets the dual-stream mode on the sender side and the low-quality video stream.
        /// 
        /// Deprecated: This method is deprecated as of v4.2.0. Use SetDualStreamMode [2/2] instead. You can call this method to enable or disable the dual-stream mode on the publisher side. Dual streams are a pairing of a high-quality video stream and a low-quality video stream:
        /// High-quality video stream: High bitrate, high resolution.
        /// Low-quality video stream: Low bitrate, low resolution. After you enable dual-stream mode, you can call SetRemoteVideoStreamType to choose to receive either the high-quality video stream or the low-quality video stream on the subscriber side.
        /// This method is applicable to all types of streams from the sender, including but not limited to video streams collected from cameras, screen sharing streams, and custom-collected video streams.
        /// If you need to enable dual video streams in a multi-channel scenario, you can call the EnableDualStreamModeEx method.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode: true : Enable dual-stream mode. false : (Default) Disable dual-stream mode. </param>
        ///
        /// <param name="streamConfig"> The configuration of the low-quality video stream. See SimulcastStreamConfig. When setting mode to DISABLE_SIMULCAST_STREAM, setting streamConfig will not take effect. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableDualStreamMode(bool enabled, SimulcastStreamConfig streamConfig);

        ///
        /// <summary>
        /// Sets the dual-stream mode on the sender side.
        /// 
        /// The SDK defaults to enabling low-quality video stream adaptive mode (AUTO_SIMULCAST_STREAM) on the sender side, which means the sender does not actively send low-quality video stream. The receiving end with the role of the host can initiate a low-quality video stream request by calling SetRemoteVideoStreamType, and upon receiving the request, the sending end automatically starts sending low-quality stream.
        /// If you want to modify this behavior, you can call this method and set mode to DISABLE_SIMULCAST_STREAM (never send low-quality video streams) or ENABLE_SIMULCAST_STREAM (always send low-quality video streams).
        /// If you want to restore the default behavior after making changes, you can call this method again with mode set to AUTO_SIMULCAST_STREAM. The difference and connection between this method and EnableDualStreamMode [1/2] is as follows:
        /// When calling this method and setting mode to DISABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamMode [1/2] (false).
        /// When calling this method and setting mode to ENABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamMode [1/2] (true).
        /// Both methods can be called before and after joining a channel. If both methods are used, the settings in the method called later takes precedence.
        /// </summary>
        ///
        /// <param name="mode"> The mode in which the video stream is sent. See SIMULCAST_STREAM_MODE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode);

        ///
        /// @ignore
        ///
        public abstract int SetSimulcastConfig(SimulcastConfig simulcastConfig);

        ///
        /// <summary>
        /// Sets dual-stream mode configuration on the sender side.
        /// 
        /// The SDK defaults to enabling low-quality video stream adaptive mode (AUTO_SIMULCAST_STREAM) on the sender side, which means the sender does not actively send low-quality video stream. The receiving end with the role of the host can initiate a low-quality video stream request by calling SetRemoteVideoStreamType, and upon receiving the request, the sending end automatically starts sending low-quality stream.
        /// If you want to modify this behavior, you can call this method and set mode to DISABLE_SIMULCAST_STREAM (never send low-quality video streams) or ENABLE_SIMULCAST_STREAM (always send low-quality video streams).
        /// If you want to restore the default behavior after making changes, you can call this method again with mode set to AUTO_SIMULCAST_STREAM. The difference between this method and SetDualStreamMode [1/2] is that this method can also configure the low-quality video stream, and the SDK sends the stream according to the configuration in streamConfig. The difference and connection between this method and EnableDualStreamMode [2/2] is as follows:
        /// When calling this method and setting mode to DISABLE_SIMULCAST_STREAM, it has the same effect as calling EnableDualStreamMode [2/2] and setting enabled to false.
        /// When calling this method and setting mode to ENABLE_SIMULCAST_STREAM, it has the same effect as calling EnableDualStreamMode [2/2] and setting enabled to true.
        /// Both methods can be called before and after joining a channel. If both methods are used, the settings in the method called later takes precedence.
        /// </summary>
        ///
        /// <param name="streamConfig"> The configuration of the low-quality video stream. See SimulcastStreamConfig. When setting mode to DISABLE_SIMULCAST_STREAM, setting streamConfig will not take effect. </param>
        ///
        /// <param name="mode"> The mode in which the video stream is sent. See SIMULCAST_STREAM_MODE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDualStreamMode(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig);

        ///
        /// <summary>
        /// Sets whether to enable the local playback of external audio source.
        /// 
        /// Ensure you have called the CreateCustomAudioTrack method to create a custom audio track before calling this method. After calling this method to enable the local playback of external audio source, if you need to stop local playback, you can call this method again and set enabled to false. You can call AdjustCustomAudioPlayoutVolume to adjust the local playback volume of the custom audio track.
        /// </summary>
        ///
        /// <param name="trackId"> The audio track ID. Set this parameter to the custom audio track ID returned in CreateCustomAudioTrack. </param>
        ///
        /// <param name="enabled"> Whether to play the external audio source: true : Play the external audio source. false : (Default) Do not play the external source. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableCustomAudioLocalPlayback(uint trackId, bool enabled);

        ///
        /// <summary>
        /// Sets the format of the captured raw audio data.
        /// 
        /// Sets the audio format for the OnRecordAudioFrame callback.
        /// Ensure that you call this method before joining a channel.
        /// The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method. Sample interval (sec) = samplePerCall /(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnRecordAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate returned in the OnRecordAudioFrame callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz. </param>
        ///
        /// <param name="channel">
        /// The number of channels returned in the OnRecordAudioFrame callback:
        /// 1: Mono.
        /// 2: Stereo.
        /// </param>
        ///
        /// <param name="mode"> The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE. </param>
        ///
        /// <param name="samplesPerCall"> The number of data samples returned in the OnRecordAudioFrame callback, such as 1024 for the Media Push. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        ///
        /// <summary>
        /// Sets the audio data format for playback.
        /// 
        /// Sets the data format for the OnPlaybackAudioFrame callback.
        /// Ensure that you call this method before joining a channel.
        /// The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method. Sample interval (sec) = samplePerCall /(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnPlaybackAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate returned in the OnPlaybackAudioFrame callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz. </param>
        ///
        /// <param name="channel">
        /// The number of channels returned in the OnPlaybackAudioFrame callback:
        /// 1: Mono.
        /// 2: Stereo.
        /// </param>
        ///
        /// <param name="mode"> The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE. </param>
        ///
        /// <param name="samplesPerCall"> The number of data samples returned in the OnPlaybackAudioFrame callback, such as 1024 for the Media Push. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        ///
        /// <summary>
        /// Sets the audio data format reported by OnMixedAudioFrame.
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate (Hz) of the audio data, which can be set as 8000, 16000, 32000, 44100, or 48000. </param>
        ///
        /// <param name="channel"> The number of channels of the audio data, which can be set as 1(Mono) or 2(Stereo). </param>
        ///
        /// <param name="samplesPerCall"> Sets the number of samples. In Media Push scenarios, set it as 1024. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetMixedAudioFrameParameters(int sampleRate, int channel, int samplesPerCall);

        ///
        /// <summary>
        /// Sets the format of the in-ear monitoring raw audio data.
        /// 
        /// This method is used to set the in-ear monitoring audio data format reported by the OnEarMonitoringAudioFrame callback.
        /// Before calling this method, you need to call EnableInEarMonitoring, and set includeAudioFilters to EAR_MONITORING_FILTER_BUILT_IN_AUDIO_FILTERS or EAR_MONITORING_FILTER_NOISE_SUPPRESSION.
        /// The SDK calculates the sampling interval based on the samplesPerCall, sampleRate and channel parameters set in this method. Sample interval (sec) = samplePerCall /(sampleRate × channel). Ensure that the sample interval ≥ 0.01 (s). The SDK triggers the OnEarMonitoringAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate of the audio data reported in the OnEarMonitoringAudioFrame callback, which can be set as 8,000, 16,000, 32,000, 44,100, or 48,000 Hz. </param>
        ///
        /// <param name="channel">
        /// The number of audio channels reported in the OnEarMonitoringAudioFrame callback.
        /// 1: Mono.
        /// 2: Stereo.
        /// </param>
        ///
        /// <param name="mode"> The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE. </param>
        ///
        /// <param name="samplesPerCall"> The number of data samples reported in the OnEarMonitoringAudioFrame callback, such as 1,024 for the Media Push. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEarMonitoringAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        ///
        /// <summary>
        /// Sets the audio data format reported by OnPlaybackAudioFrameBeforeMixing.
        /// </summary>
        ///
        /// <param name="sampleRate"> The sample rate (Hz) of the audio data, which can be set as 8000, 16000, 32000, 44100, or 48000. </param>
        ///
        /// <param name="channel"> The number of channels of the audio data, which can be set as 1 (Mono) or 2 (Stereo). </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlaybackAudioFrameBeforeMixingParameters(int sampleRate, int channel);

        ///
        /// <summary>
        /// Turns on audio spectrum monitoring.
        /// 
        /// If you want to obtain the audio spectrum data of local or remote users, you can register the audio spectrum observer and enable audio spectrum monitoring. You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="intervalInMS"> The interval (in milliseconds) at which the SDK triggers the OnLocalAudioSpectrum and OnRemoteAudioSpectrum callbacks. The default value is 100. Do not set this parameter to a value less than 10, otherwise calling this method would fail. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: Invalid parameters.
        /// </returns>
        ///
        public abstract int EnableAudioSpectrumMonitor(int intervalInMS = 100);

        ///
        /// <summary>
        /// Disables audio spectrum monitoring.
        /// 
        /// After calling EnableAudioSpectrumMonitor, if you want to disable audio spectrum monitoring, you can call this method. You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DisableAudioSpectrumMonitor();

        ///
        /// <summary>
        /// Register an audio spectrum observer.
        /// 
        /// After successfully registering the audio spectrum observer and calling EnableAudioSpectrumMonitor to enable the audio spectrum monitoring, the SDK reports the callback that you implement in the IAudioSpectrumObserver class according to the time interval you set. You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="observer"> The audio spectrum observer. See IAudioSpectrumObserver. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterAudioSpectrumObserver(IAudioSpectrumObserver observer);

        ///
        /// <summary>
        /// Unregisters the audio spectrum observer.
        /// 
        /// After calling RegisterAudioSpectrumObserver, if you want to disable audio spectrum monitoring, you can call this method. You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnregisterAudioSpectrumObserver();

        ///
        /// <summary>
        /// Adjusts the capturing signal volume.
        /// 
        /// If you only need to mute the audio signal, Agora recommends that you use MuteRecordingSignal instead.
        /// </summary>
        ///
        /// <param name="volume">
        /// The volume of the user. The value range is [0,400].
        /// 0: Mute.
        /// 100: (Default) The original volume.
        /// 400: Four times the original volume (amplifying the audio signals by four times).
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustRecordingSignalVolume(int volume);

        ///
        /// <summary>
        /// Whether to mute the recording signal.
        /// </summary>
        ///
        /// <param name="mute"> true : The media file is muted. false : (Default) Do not mute the recording signal. If you have already called AdjustRecordingSignalVolume to adjust the volume, then when you call this method and set it to true, the SDK will record the current volume and mute it. To restore the previous volume, call this method again and set it to false. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRecordingSignal(bool mute);

        ///
        /// <summary>
        /// Adjusts the playback signal volume of all remote users.
        /// 
        /// This method is used to adjust the signal volume of all remote users mixed and played locally. If you need to adjust the signal volume of a specified remote user played locally, it is recommended that you call AdjustUserPlaybackSignalVolume instead.
        /// </summary>
        ///
        /// <param name="volume">
        /// The volume of the user. The value range is [0,400].
        /// 0: Mute.
        /// 100: (Default) The original volume.
        /// 400: Four times the original volume (amplifying the audio signals by four times).
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustPlaybackSignalVolume(int volume);

        ///
        /// <summary>
        /// Adjusts the playback signal volume of a specified remote user.
        /// 
        /// You can call this method to adjust the playback volume of a specified remote user. To adjust the playback volume of different remote users, call the method as many times, once for each remote user.
        /// </summary>
        ///
        /// <param name="volume">
        /// The volume of the user. The value range is [0,400].
        /// 0: Mute.
        /// 100: (Default) The original volume.
        /// 400: Four times the original volume (amplifying the audio signals by four times).
        /// </param>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustUserPlaybackSignalVolume(uint uid, int volume);

        ///
        /// @ignore
        ///
        public abstract int SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option);

        ///
        /// <summary>
        /// Sets the fallback option for the subscribed video stream based on the network conditions.
        /// 
        /// An unstable network affects the audio and video quality in a video call or interactive live video streaming. If option is set as STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW or STREAM_FALLBACK_OPTION_AUDIO_ONLY, the SDK automatically switches the video from a high-quality stream to a low-quality stream or disables the video when the downlink network conditions cannot support both audio and video to guarantee the quality of the audio. Meanwhile, the SDK continuously monitors network quality and resumes subscribing to audio and video streams when the network quality improves. When the subscribed video stream falls back to an audio-only stream, or recovers from an audio-only stream to an audio-video stream, the SDK triggers the OnRemoteSubscribeFallbackToAudioOnly callback.
        /// </summary>
        ///
        /// <param name="option"> Fallback options for the subscribed stream. See STREAM_FALLBACK_OPTIONS. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option);

        ///
        /// @ignore
        ///
        public abstract int SetHighPriorityUserList(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option);

        ///
        /// @ignore
        ///
        public abstract int EnableExtension(string provider, string extension, ExtensionInfo extensionInfo, bool enable = true);

        ///
        /// @ignore
        ///
        public abstract int SetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, string value);

        ///
        /// @ignore
        ///
        public abstract int GetExtensionProperty(string provider, string extension, ExtensionInfo extensionInfo, string key, ref string value, int buf_len);

        ///
        /// <summary>
        /// Enables loopback audio capturing.
        /// 
        /// If you enable loopback audio capturing, the output of the sound card is mixed into the audio stream sent to the other end.
        /// This method applies to the macOS and Windows only.
        /// macOS does not support loopback audio capture of the default sound card. If you need to use this function, use a virtual sound card and pass its name to the deviceName parameter. Agora recommends using AgoraALD as the virtual sound card for audio capturing.
        /// You can call this method either before or after joining a channel.
        /// If you call the DisableAudio method to disable the audio module, audio capturing will be disabled as well. If you need to enable audio capturing, call the EnableAudio method to enable the audio module and then call the EnableLoopbackRecording method.
        /// </summary>
        ///
        /// <param name="enabled"> Sets whether to enable loopback audio capturing. true : Enable loopback audio capturing. false : (Default) Disable loopback audio capturing. </param>
        ///
        /// <param name="deviceName">
        /// macOS: The device name of the virtual sound card. The default value is set to NULL, which means using AgoraALD for loopback audio capturing.
        /// Windows: The device name of the sound card. The default is set to NULL, which means the SDK uses the sound card of your device for loopback audio capturing.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLoopbackRecording(bool enabled, string deviceName = "");

        ///
        /// <summary>
        /// Adjusts the volume of the signal captured by the sound card.
        /// 
        /// After calling EnableLoopbackRecording to enable loopback audio capturing, you can call this method to adjust the volume of the signal captured by the sound card.
        /// </summary>
        ///
        /// <param name="volume"> Audio mixing volume. The value ranges between 0 and 100. The default value is 100, which means the original volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustLoopbackSignalVolume(int volume);

        ///
        /// @ignore
        ///
        public abstract int GetLoopbackRecordingVolume();

        ///
        /// @ignore
        ///
        public abstract int EnableInEarMonitoring(bool enabled, int includeAudioFilters);

        ///
        /// <summary>
        /// Sets the volume of the in-ear monitor.
        /// </summary>
        ///
        /// <param name="volume">
        /// The volume of the user. The value range is [0,400].
        /// 0: Mute.
        /// 100: (Default) The original volume.
        /// 400: Four times the original volume (amplifying the audio signals by four times).
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: Invalid parameter settings, such as in-ear monitoring volume exceeding the valid range (&lt; 0 or &gt; 400).
        /// </returns>
        ///
        public abstract int SetInEarMonitoringVolume(int volume);

        ///
        /// <summary>
        /// Loads an extension.
        /// 
        /// This method is used to add extensions external to the SDK (such as those from Extensions Marketplace and SDK extensions) to the SDK.
        /// </summary>
        ///
        /// <param name="path"> The extension library path and name. For example: /library/libagora_segmentation_extension.dll. </param>
        ///
        /// <param name="unload_after_use"> Whether to uninstall the current extension when you no longer using it: true : Uninstall the extension when the IRtcEngine is destroyed. false : (Rcommended) Do not uninstall the extension until the process terminates. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LoadExtensionProvider(string path, bool unload_after_use = false);

        ///
        /// <summary>
        /// Sets the properties of the extension provider.
        /// 
        /// You can call this method to set the attributes of the extension provider and initialize the relevant parameters according to the type of the provider.
        /// </summary>
        ///
        /// <param name="value"> The value of the extension key. </param>
        ///
        /// <param name="key"> The key of the extension. </param>
        ///
        /// <param name="provider"> The name of the extension provider. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExtensionProviderProperty(string provider, string key, string value);

        ///
        /// <summary>
        /// Registers an extension.
        /// 
        /// For extensions external to the SDK (such as those from Extensions Marketplace and SDK Extensions), you need to load them before calling this method. Extensions internal to the SDK (those included in the full SDK package) are automatically loaded and registered after the initialization of IRtcEngine.
        /// </summary>
        ///
        /// <param name="type"> Source type of the extension. See MEDIA_SOURCE_TYPE. </param>
        ///
        /// <param name="extension"> The name of the extension. </param>
        ///
        /// <param name="provider"> The name of the extension provider. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -3: The extension library is not loaded. Agora recommends that you check the storage location or the name of the dynamic library.
        /// </returns>
        ///
        public abstract int RegisterExtension(string provider, string extension, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        ///
        /// <summary>
        /// Enables or disables extensions.
        /// </summary>
        ///
        /// <param name="extension"> The name of the extension. </param>
        ///
        /// <param name="provider"> The name of the extension provider. </param>
        ///
        /// <param name="enable"> Whether to enable the extension: true : Enable the extension. false : Disable the extension. </param>
        ///
        /// <param name="type"> Source type of the extension. See MEDIA_SOURCE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -3: The extension library is not loaded. Agora recommends that you check the storage location or the name of the dynamic library.
        /// </returns>
        ///
        public abstract int EnableExtension(string provider, string extension, bool enable = true, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        ///
        /// <summary>
        /// Sets the properties of the extension.
        /// 
        /// After enabling the extension, you can call this method to set the properties of the extension.
        /// </summary>
        ///
        /// <param name="type"> Source type of the extension. See MEDIA_SOURCE_TYPE. </param>
        ///
        /// <param name="provider"> The name of the extension provider. </param>
        ///
        /// <param name="extension"> The name of the extension. </param>
        ///
        /// <param name="key"> The key of the extension. </param>
        ///
        /// <param name="value"> The value of the extension key. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExtensionProperty(string provider, string extension, string key, string value, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        ///
        /// <summary>
        /// Gets detailed information on the extensions.
        /// </summary>
        ///
        /// <param name="provider"> An output parameter. The name of the extension provider. </param>
        ///
        /// <param name="extension"> An output parameter. The name of the extension. </param>
        ///
        /// <param name="key"> An output parameter. The key of the extension. </param>
        ///
        /// <param name="value"> An output parameter. The value of the extension key. </param>
        ///
        /// <param name="type"> Source type of the extension. See MEDIA_SOURCE_TYPE. </param>
        ///
        /// <param name="buf_len"> Maximum length of the JSON string indicating the extension property. The maximum value is 512 bytes. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetExtensionProperty(string provider, string extension, string key, ref string value, int buf_len, MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE);

        ///
        /// <summary>
        /// Sets the camera capture configuration.
        /// 
        /// This method is for Android and iOS only.
        /// Call this method before enabling local camera capture, such as before calling StartPreview [2/2] and JoinChannel [2/2].
        /// To adjust the camera focal length configuration, It is recommended to call QueryCameraFocalLengthCapability first to check the device's focal length capabilities, and then configure based on the query results.
        /// Due to limitations on some Android devices, even if you set the focal length type according to the results returned in QueryCameraFocalLengthCapability, the settings may not take effect.
        /// </summary>
        ///
        /// <param name="config"> The camera capture configuration. See CameraCapturerConfiguration. In this method, you do not need to set the deviceId parameter. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraCapturerConfiguration(CameraCapturerConfiguration config);

        ///
        /// <summary>
        /// Creates a custom video track.
        /// 
        /// To publish a custom video source, see the following steps:
        /// Call this method to create a video track and get the video track ID.
        /// Call JoinChannel [2/2] to join the channel. In ChannelMediaOptions, set customVideoTrackId to the video track ID that you want to publish, and set publishCustomVideoTrack to true.
        /// Call PushVideoFrame and specify videoTrackId as the video track ID set in step 2. You can then publish the corresponding custom video source in the channel.
        /// </summary>
        ///
        /// <returns>
        /// If the method call is successful, the video track ID is returned as the unique identifier of the video track.
        /// If the method call fails, a negative value is returned.
        /// </returns>
        ///
        public abstract uint CreateCustomVideoTrack();

        ///
        /// @ignore
        ///
        public abstract uint CreateCustomEncodedVideoTrack(SenderOptions sender_option);

        ///
        /// <summary>
        /// Destroys the specified video track.
        /// </summary>
        ///
        /// <param name="video_track_id"> The video track ID returned by calling the CreateCustomVideoTrack method. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DestroyCustomVideoTrack(uint video_track_id);

        ///
        /// @ignore
        ///
        public abstract int DestroyCustomEncodedVideoTrack(uint video_track_id);

        ///
        /// <summary>
        /// Switches between front and rear cameras.
        /// 
        /// You can call this method to dynamically switch cameras based on the actual camera availability during the app's runtime, without having to restart the video stream or reconfigure the video source.
        /// This method is for Android and iOS only.
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method only switches the camera for the video stream captured by the first camera, that is, the video source set to VIDEO_SOURCE_CAMERA (0) when calling StartCameraCapture.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SwitchCamera();

        ///
        /// <summary>
        /// Checks whether the device supports camera zoom.
        /// 
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true : The device supports camera zoom. false : The device does not support camera zoom.
        /// </returns>
        ///
        public abstract bool IsCameraZoomSupported();

        ///
        /// <summary>
        /// Checks whether the device camera supports face detection.
        /// 
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true : The device camera supports face detection. false : The device camera does not support face detection.
        /// </returns>
        ///
        public abstract bool IsCameraFaceDetectSupported();

        ///
        /// <summary>
        /// Checks whether the device supports camera flash.
        /// 
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// The app enables the front camera by default. If your front camera does not support flash, this method returns false. If you want to check whether the rear camera supports the flash function, call SwitchCamera before this method.
        /// On iPads with system version 15, even if IsCameraTorchSupported returns true, you might fail to successfully enable the flash by calling SetCameraTorchOn due to system issues.
        /// </summary>
        ///
        /// <returns>
        /// true : The device supports camera flash. false : The device does not support camera flash.
        /// </returns>
        ///
        public abstract bool IsCameraTorchSupported();

        ///
        /// <summary>
        /// Check whether the device supports the manual focus function.
        /// 
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true : The device supports the manual focus function. false : The device does not support the manual focus function.
        /// </returns>
        ///
        public abstract bool IsCameraFocusSupported();

        ///
        /// <summary>
        /// Checks whether the device supports the face auto-focus function.
        /// 
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true : The device supports the face auto-focus function. false : The device does not support the face auto-focus function.
        /// </returns>
        ///
        public abstract bool IsCameraAutoFocusFaceModeSupported();

        ///
        /// <summary>
        /// Sets the camera zoom factor.
        /// 
        /// For iOS devices equipped with multi-lens rear cameras, such as those featuring dual-camera (wide-angle and ultra-wide-angle) or triple-camera (wide-angle, ultra-wide-angle, and telephoto), you can call SetCameraCapturerConfiguration first to set the cameraFocalLengthType as CAMERA_FOCAL_LENGTH_DEFAULT (0) (standard lens). Then, adjust the camera zoom factor to a value less than 1.0. This configuration allows you to capture video with an ultra-wide-angle perspective.
        /// You must call this method after EnableVideo. The setting result will take effect after the camera is successfully turned on, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="factor"> The camera zoom factor. For devices that do not support ultra-wide-angle, the value ranges from 1.0 to the maximum zoom factor; for devices that support ultra-wide-angle, the value ranges from 0.5 to the maximum zoom factor. You can get the maximum zoom factor supported by the device by calling the GetCameraMaxZoomFactor method. </param>
        ///
        /// <returns>
        /// The camera zoom factor value, if successful.
        /// &lt; 0: if the method if failed.
        /// </returns>
        ///
        public abstract int SetCameraZoomFactor(float factor);

        ///
        /// <summary>
        /// Enables or disables face detection for the local user.
        /// 
        /// You can call this method either before or after joining a channel. This method is for Android and iOS only. Once face detection is enabled, the SDK triggers the OnFacePositionChanged callback to report the face information of the local user, which includes the following:
        /// The width and height of the local video.
        /// The position of the human face in the local view.
        /// The distance between the human face and the screen. This method needs to be called after the camera is started (for example, by calling StartPreview [2/2] or EnableVideo ).
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable face detection for the local user: true : Enable face detection. false : (Default) Disable face detection. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableFaceDetection(bool enabled);

        ///
        /// <summary>
        /// Gets the maximum zoom ratio supported by the camera.
        /// 
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
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
        /// 
        /// You must call this method after EnableVideo. The setting result will take effect after the camera is successfully turned on, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// After a successful method call, the SDK triggers the OnCameraFocusAreaChanged callback.
        /// </summary>
        ///
        /// <param name="positionX"> The horizontal coordinate of the touchpoint in the view. </param>
        ///
        /// <param name="positionY"> The vertical coordinate of the touchpoint in the view. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraFocusPositionInPreview(float positionX, float positionY);

        ///
        /// <summary>
        /// Enables the camera flash.
        /// 
        /// You must call this method after EnableVideo. The setting result will take effect after the camera is successfully turned on, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="isOn"> Whether to turn on the camera flash: true : Turn on the flash. false : (Default) Turn off the flash. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraTorchOn(bool isOn);

        ///
        /// <summary>
        /// Enables the camera auto-face focus function.
        /// 
        /// You must call this method after EnableVideo. The setting result will take effect after the camera is successfully turned on, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable face autofocus: true : Enable the camera auto-face focus function. false : Disable face autofocus. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraAutoFocusFaceModeEnabled(bool enabled);

        ///
        /// <summary>
        /// Checks whether the device supports manual exposure.
        /// 
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true : The device supports manual exposure. false : The device does not support manual exposure.
        /// </returns>
        ///
        public abstract bool IsCameraExposurePositionSupported();

        ///
        /// <summary>
        /// Sets the camera exposure position.
        /// 
        /// You must call this method after EnableVideo. The setting result will take effect after the camera is successfully turned on, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method is for Android and iOS only.
        /// After a successful method call, the SDK triggers the OnCameraExposureAreaChanged callback.
        /// </summary>
        ///
        /// <param name="positionXinView"> The horizontal coordinate of the touchpoint in the view. </param>
        ///
        /// <param name="positionYinView"> The vertical coordinate of the touchpoint in the view. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraExposurePosition(float positionXinView, float positionYinView);

        ///
        /// <summary>
        /// Queries whether the current camera supports adjusting exposure value.
        /// 
        /// This method is for Android and iOS only.
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// Before calling SetCameraExposureFactor, Agora recoomends that you call this method to query whether the current camera supports adjusting the exposure value.
        /// By calling this method, you adjust the exposure value of the currently active camera, that is, the camera specified when calling SetCameraCapturerConfiguration.
        /// </summary>
        ///
        /// <returns>
        /// true : Success. false : Failure.
        /// </returns>
        ///
        public abstract bool IsCameraExposureSupported();

        ///
        /// <summary>
        /// Sets the camera exposure value.
        /// 
        /// Insufficient or excessive lighting in the shooting environment can affect the image quality of video capture. To achieve optimal video quality, you can use this method to adjust the camera's exposure value.
        /// This method is for Android and iOS only.
        /// You must call this method after EnableVideo. The setting result will take effect after the camera is successfully turned on, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// Before calling this method, Agora recommends calling IsCameraExposureSupported to check whether the current camera supports adjusting the exposure value.
        /// By calling this method, you adjust the exposure value of the currently active camera, that is, the camera specified when calling SetCameraCapturerConfiguration.
        /// </summary>
        ///
        /// <param name="factor"> The camera exposure value. The default value is 0, which means using the default exposure of the camera. The larger the value, the greater the exposure. When the video image is overexposed, you can reduce the exposure value; when the video image is underexposed and the dark details are lost, you can increase the exposure value. If the exposure value you specified is beyond the range supported by the device, the SDK will automatically adjust it to the actual supported range of the device. On Android, the value range is [-20.0, 20.0]. On iOS, the value range is [-8.0, 8.0]. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraExposureFactor(float factor);

        ///
        /// <summary>
        /// Checks whether the device supports auto exposure.
        /// 
        /// This method must be called after the camera is successfully enabled, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method applies to iOS only.
        /// </summary>
        ///
        /// <returns>
        /// true : The device supports auto exposure. false : The device does not support auto exposure.
        /// </returns>
        ///
        public abstract bool IsCameraAutoExposureFaceModeSupported();

        ///
        /// <summary>
        /// Sets whether to enable auto exposure.
        /// 
        /// You must call this method after EnableVideo. The setting result will take effect after the camera is successfully turned on, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// This method applies to iOS only.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable auto exposure: true : Enable auto exposure. false : Disable auto exposure. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraAutoExposureFaceModeEnabled(bool enabled);

        ///
        /// <summary>
        /// Set the camera stabilization mode.
        /// 
        /// This method applies to iOS only. The camera stabilization mode is off by default. You need to call this method to turn it on and set the appropriate stabilization mode.
        /// </summary>
        ///
        /// <param name="mode"> Camera stabilization mode. See CAMERA_STABILIZATION_MODE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraStabilizationMode(CAMERA_STABILIZATION_MODE mode);

        ///
        /// <summary>
        /// Sets the default audio playback route.
        /// 
        /// This method is for Android and iOS only.
        /// Ensure that you call this method before joining a channel. If you need to change the audio route after joining a channel, call SetEnableSpeakerphone. Most mobile phones have two audio routes: an earpiece at the top, and a speakerphone at the bottom. The earpiece plays at a lower volume, and the speakerphone at a higher volume. When setting the default audio route, you determine whether audio playback comes through the earpiece or speakerphone when no external audio device is connected. In different scenarios, the default audio routing of the system is also different. See the following:
        /// Voice call: Earpiece.
        /// Audio broadcast: Speakerphone.
        /// Video call: Speakerphone.
        /// Video broadcast: Speakerphone. You can call this method to change the default audio route. After a successful method call, the SDK triggers the OnAudioRoutingChanged callback. The system audio route changes when an external audio device, such as a headphone or a Bluetooth audio device, is connected. See Audio Route for detailed change principles.
        /// </summary>
        ///
        /// <param name="defaultToSpeaker"> Whether to set the speakerphone as the default audio route: true : Set the speakerphone as the default audio route. false : Set the earpiece as the default audio route. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDefaultAudioRouteToSpeakerphone(bool defaultToSpeaker);

        ///
        /// <summary>
        /// Enables/Disables the audio route to the speakerphone.
        /// 
        /// If the default audio route of the SDK or the setting in SetDefaultAudioRouteToSpeakerphone cannot meet your requirements, you can call SetEnableSpeakerphone to switch the current audio route. After a successful method call, the SDK triggers the OnAudioRoutingChanged callback. For the default audio route in different scenarios, see Audio Route. This method only sets the audio route in the current channel and does not influence the default audio route. If the user leaves the current channel and joins another channel, the default audio route is used.
        /// This method is for Android and iOS only.
        /// Call this method after joining a channel.
        /// If the user uses an external audio playback device such as a Bluetooth or wired headset, this method does not take effect, and the SDK plays audio through the external device. When the user uses multiple external devices, the SDK plays audio through the last connected device.
        /// </summary>
        ///
        /// <param name="speakerOn"> Sets whether to enable the speakerphone or earpiece: true : Enable device state monitoring. The audio route is the speakerphone. false : Disable device state monitoring. The audio route is the earpiece. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetEnableSpeakerphone(bool speakerOn);

        ///
        /// <summary>
        /// Checks whether the speakerphone is enabled.
        /// 
        /// This method is for Android and iOS only.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// true : The speakerphone is enabled, and the audio plays from the speakerphone. false : The speakerphone is not enabled, and the audio plays from devices other than the speakerphone. For example, the headset or earpiece.
        /// </returns>
        ///
        public abstract bool IsSpeakerphoneEnabled();

        ///
        /// <summary>
        /// Selects the audio playback route in communication audio mode.
        /// 
        /// This method is used to switch the audio route from Bluetooth headphones to earpiece, wired headphones or speakers in communication audio mode (). After the method is called successfully, the SDK will trigger the OnAudioRoutingChanged callback to report the modified route.
        /// This method is for Android only.
        /// Using this method and the SetEnableSpeakerphone method at the same time may cause conflicts. Agora recommends that you use the SetRouteInCommunicationMode method alone.
        /// </summary>
        ///
        /// <param name="route">
        /// The audio playback route you want to use:
        /// -1: The default audio route.
        /// 0: Headphones with microphone.
        /// 1: Handset.
        /// 2: Headphones without microphone.
        /// 3: Device's built-in speaker.
        /// 4: (Not supported yet) External speakers.
        /// 5: Bluetooth headphones.
        /// 6: USB device.
        /// </param>
        ///
        /// <returns>
        /// Without practical meaning.
        /// </returns>
        ///
        public abstract int SetRouteInCommunicationMode(int route);

        ///
        /// <summary>
        /// Check if the camera supports portrait center stage.
        /// 
        /// This method is for iOS and macOS only. Before calling EnableCameraCenterStage to enable portrait center stage, it is recommended to call this method to check if the current device supports the feature.
        /// </summary>
        ///
        /// <returns>
        /// true : The current camera supports the portrait center stage. false : The current camera supports the portrait center stage.
        /// </returns>
        ///
        public abstract bool IsCameraCenterStageSupported();

        ///
        /// <summary>
        /// Enables or disables portrait center stage.
        /// 
        /// The portrait center stage feature is off by default. You need to call this method to turn it on. If you need to disable this feature, you need to call this method again and set enabled to false. This method is for iOS and macOS only.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the portrait center stage: true : Enable portrait center stage. false : Disable portrait center stage. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableCameraCenterStage(bool enabled);

        ///
        /// <summary>
        /// Gets a list of shareable screens and windows.
        /// 
        /// You can call this method before sharing a screen or window to get a list of shareable screens and windows, which enables a user to use thumbnails in the list to easily choose a particular screen or window to share. This list also contains important information such as window ID and screen ID, with which you can call StartScreenCaptureByWindowId or StartScreenCaptureByDisplayId to start the sharing. This method applies to macOS and Windows only.
        /// </summary>
        ///
        /// <param name="thumbSize"> The target size of the screen or window thumbnail (the width and height are in pixels). The SDK scales the original image to make the length of the longest side of the image the same as that of the target size without distorting the original image. For example, if the original image is 400 × 300 and thumbSize is 100 × 100, the actual size of the thumbnail is 100 × 75. If the target size is larger than the original size, the thumbnail is the original image and the SDK does not scale it. </param>
        ///
        /// <param name="iconSize"> The target size of the icon corresponding to the application program (the width and height are in pixels). The SDK scales the original image to make the length of the longest side of the image the same as that of the target size without distorting the original image. For example, if the original image is 400 × 300 and iconSize is 100 × 100, the actual size of the icon is 100 × 75. If the target size is larger than the original size, the icon is the original image and the SDK does not scale it. </param>
        ///
        /// <param name="includeScreen"> Whether the SDK returns the screen information in addition to the window information: true : The SDK returns screen and window information. false : The SDK returns window information only. </param>
        ///
        /// <returns>
        /// The ScreenCaptureSourceInfo array.
        /// </returns>
        ///
        public abstract ScreenCaptureSourceInfo[] GetScreenCaptureSources(SIZE thumbSize, SIZE iconSize, bool includeScreen);

        ///
        /// <summary>
        /// Sets the operational permission of the SDK on the audio session.
        /// 
        /// The SDK and the app can both configure the audio session by default. If you need to only use the app to configure the audio session, this method restricts the operational permission of the SDK on the audio session. You can call this method either before or after joining a channel. Once you call this method to restrict the operational permission of the SDK on the audio session, the restriction takes effect when the SDK needs to change the audio session.
        /// This method is only available for iOS platforms.
        /// This method does not restrict the operational permission of the app on the audio session.
        /// </summary>
        ///
        /// <param name="restriction"> The operational permission of the SDK on the audio session. See AUDIO_SESSION_OPERATION_RESTRICTION. This parameter is in bit mask format, and each bit corresponds to a permission. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioSessionOperationRestriction(AUDIO_SESSION_OPERATION_RESTRICTION restriction);

        ///
        /// <summary>
        /// Captures the screen by specifying the display ID.
        /// 
        /// Captures the video stream of a screen or a part of the screen area. This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="displayId"> The display ID of the screen to be shared. For the Windows platform, if you need to simultaneously share two screens (main screen and secondary screen), you can set displayId to -1 when calling this method. </param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. Pass in nil to share the entire screen. See Rectangle. </param>
        ///
        /// <param name="captureParams"> Screen sharing configurations. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByDisplayId(uint displayId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Captures the whole or part of a screen by specifying the screen rect.
        /// 
        /// You can call this method either before or after joining the channel, with the following differences:
        /// Call this method before joining a channel, and then call JoinChannel [2/2] to join a channel and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing.
        /// Call this method after joining a channel, and then call UpdateChannelMediaOptions to join a channel and set publishScreenTrack or publishSecondaryScreenTrack to true to start screen sharing. Deprecated: This method is deprecated. Use StartScreenCaptureByDisplayId instead. Agora strongly recommends using StartScreenCaptureByDisplayId if you need to start screen sharing on a device connected to another display. This method shares a screen or part of the screen. You need to specify the area of the screen to be shared. This method applies to Windows only.
        /// </summary>
        ///
        /// <param name="screenRect"> Sets the relative location of the screen to the virtual screen. </param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle. If the specified region overruns the screen, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen. </param>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video resolution is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect, ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Gets the audio device information.
        /// 
        /// After calling this method, you can get whether the audio device supports ultra-low-latency capture and playback.
        /// This method is for Android only.
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="deviceInfo"> Audio frame information. See DeviceInfoMobile. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetAudioDeviceInfo(ref DeviceInfoMobile deviceInfo);

        ///
        /// <summary>
        /// Captures the whole or part of a window by specifying the window ID.
        /// 
        /// This method captures a window or part of the window. You need to specify the ID of the window to be captured. This method applies to the macOS and Windows only. This method supports window sharing of UWP (Universal Windows Platform) applications. Agora tests the mainstream UWP applications by using the lastest SDK, see details as follows:
        /// </summary>
        ///
        /// <param name="windowId"> The ID of the window to be shared. </param>
        ///
        /// <param name="regionRect"> (Optional) Sets the relative location of the region to the screen. If you do not set this parameter, the SDK shares the whole screen. See Rectangle. If the specified region overruns the window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole window. </param>
        ///
        /// <param name="captureParams"> Screen sharing configurations. The default video resolution is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect, ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Sets the content hint for screen sharing.
        /// 
        /// A content hint suggests the type of the content being shared, so that the SDK applies different optimization algorithms to different types of content. If you don't call this method, the default content hint is CONTENT_HINT_NONE. You can call this method either before or after you start screen sharing.
        /// </summary>
        ///
        /// <param name="contentHint"> The content hint for screen sharing. See VIDEO_CONTENT_HINT. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int SetScreenCaptureContentHint(VIDEO_CONTENT_HINT contentHint);

        ///
        /// <summary>
        /// Updates the screen capturing region.
        /// 
        /// Call this method after starting screen sharing or window sharing.
        /// </summary>
        ///
        /// <param name="regionRect"> The relative location of the screen-share area to the screen or window. If you do not set this parameter, the SDK shares the whole screen or window. See Rectangle. If the specified region overruns the screen or window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen or window. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int UpdateScreenCaptureRegion(Rectangle regionRect);

        ///
        /// <summary>
        /// Updates the screen capturing parameters.
        /// 
        /// This method is for Windows and macOS only.
        /// Call this method after starting screen sharing or window sharing.
        /// </summary>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video resolution is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -8: The screen sharing state is invalid. Probably because you have shared other screens or windows. Try calling StopScreenCapture [1/2] to stop the current sharing and start sharing the screen again.
        /// </returns>
        ///
        public abstract int UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams);

        ///
        /// <summary>
        /// Starts screen capture.
        /// 
        /// This method is for Android and iOS only.
        /// The billing for the screen sharing stream is based on the dimensions in ScreenVideoParameters :
        /// When you do not pass in a value, Agora bills you at 1280 × 720.
        /// When you pass in a value, Agora bills you at that value. For billing examples, see.
        /// </summary>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video dimension is 1920 x 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters2. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2 (iOS platform): Empty parameter.
        /// -2 (Android platform): The system version is too low. Ensure that the Android API level is not lower than 21.
        /// -3 (Android platform): Unable to capture system audio. Ensure that the Android API level is not lower than 29.
        /// </returns>
        ///
        public abstract int StartScreenCapture(ScreenCaptureParameters2 captureParams);

        ///
        /// <summary>
        /// Updates the screen capturing parameters.
        /// 
        /// If the system audio is not captured when screen sharing is enabled, and then you want to update the parameter configuration and publish the system audio, you can refer to the following steps:
        /// Call this method, and set captureAudio to true.
        /// Call UpdateChannelMediaOptions, and set publishScreenCaptureAudio to true to publish the audio captured by the screen.
        /// This method is for Android and iOS only.
        /// On the iOS platform, screen sharing is only available on iOS 12.0 and later.
        /// </summary>
        ///
        /// <param name="captureParams"> The screen sharing encoding parameters. The default video resolution is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges. See ScreenCaptureParameters2. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
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
        /// The highest frame rate supported by the device, if the method is called successfully. See SCREEN_CAPTURE_FRAMERATE_CAPABILITY.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int QueryScreenCaptureCapability();

        ///
        /// <summary>
        /// Queries the focal length capability supported by the camera.
        /// 
        /// If you want to enable the wide-angle or ultra-wide-angle mode for camera capture, it is recommended to start by calling this method to check whether the device supports the required focal length capability. Then, adjust the camera's focal length configuration based on the query result by calling SetCameraCapturerConfiguration, ensuring the best camera capture performance. This method is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="focalLengthInfos"> An output parameter. After the method is executed, output an array of FocalLengthInfo objects containing camera focal length information. </param>
        ///
        /// <param name="size"> An output parameter. After the method is executed, output the number of focal length information items retrieved. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int QueryCameraFocalLengthCapability(ref FocalLengthInfo[] focalLengthInfos, ref int size);

        ///
        /// <summary>
        /// Sets the screen sharing scenario.
        /// 
        /// When you start screen sharing or window sharing, you can call this method to set the screen sharing scenario. The SDK adjusts the video quality and experience of the sharing according to the scenario. Agora recommends that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="screenScenario"> The screen sharing scenario. See SCREEN_SCENARIO_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetScreenCaptureScenario(SCREEN_SCENARIO_TYPE screenScenario);

        ///
        /// <summary>
        /// Stops screen capture.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopScreenCapture();

        ///
        /// <summary>
        /// Retrieves the call ID.
        /// 
        /// When a user joins a channel on a client, a callId is generated to identify the call from the client. You can call this method to get the callId parameter, and pass it in when calling methods such as Rate and Complain. Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="callId"> Output parameter, the current call ID. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetCallId(ref string callId);

        ///
        /// <summary>
        /// Allows a user to rate a call after the call ends.
        /// 
        /// Ensure that you call this method after leaving a channel.
        /// </summary>
        ///
        /// <param name="callId"> The current call ID. You can get the call ID by calling GetCallId. </param>
        ///
        /// <param name="rating"> The value is between 1 (the lowest score) and 5 (the highest score). </param>
        ///
        /// <param name="description"> (Optional) A description of the call. The string length should be less than 800 bytes. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// </returns>
        ///
        public abstract int Rate(string callId, int rating, string description);

        ///
        /// <summary>
        /// Allows a user to complain about the call quality after a call ends.
        /// 
        /// This method allows users to complain about the quality of the call. Call this method after the user leaves the channel.
        /// </summary>
        ///
        /// <param name="callId"> The current call ID. You can get the call ID by calling GetCallId. </param>
        ///
        /// <param name="description"> (Optional) A description of the call. The string length should be less than 800 bytes. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// -7: The method is called before IRtcEngine is initialized.
        /// </returns>
        ///
        public abstract int Complain(string callId, string description);

        ///
        /// <summary>
        /// Starts pushing media streams to a CDN without transcoding.
        /// 
        /// Call this method after joining a channel.
        /// Only hosts in the LIVE_BROADCASTING profile can call this method.
        /// If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push. Agora recommends that you use the server-side Media Push function. You can call this method to push an audio or video stream to the specified CDN address. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times. After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// </summary>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The URL or configuration of transcoding is invalid; check your URL and transcoding configurations.
        /// -7: The SDK is not initialized before calling this method.
        /// -19: The Media Push URL is already in use; use another URL instead.
        /// </returns>
        ///
        public abstract int StartRtmpStreamWithoutTranscoding(string url);

        ///
        /// <summary>
        /// Starts Media Push and sets the transcoding configuration.
        /// 
        /// Agora recommends that you use the server-side Media Push function. You can call this method to push a live audio-and-video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times. Under one Agora project, the maximum number of concurrent tasks to push media streams is 200 by default. If you need a higher quota, contact. After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// Call this method after joining a channel.
        /// Only hosts in the LIVE_BROADCASTING profile can call this method.
        /// If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
        /// </summary>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported. </param>
        ///
        /// <param name="transcoding"> The transcoding configuration for Media Push. See LiveTranscoding. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The URL or configuration of transcoding is invalid; check your URL and transcoding configurations.
        /// -7: The SDK is not initialized before calling this method.
        /// -19: The Media Push URL is already in use; use another URL instead.
        /// </returns>
        ///
        public abstract int StartRtmpStreamWithTranscoding(string url, LiveTranscoding transcoding);

        ///
        /// <summary>
        /// Updates the transcoding configuration.
        /// 
        /// Agora recommends that you use the server-side Media Push function. After you start pushing media streams to CDN with transcoding, you can dynamically update the transcoding configuration according to the scenario. The SDK triggers the OnTranscodingUpdated callback after the transcoding configuration is updated.
        /// </summary>
        ///
        /// <param name="transcoding"> The transcoding configuration for Media Push. See LiveTranscoding. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateRtmpTranscoding(LiveTranscoding transcoding);

        ///
        /// <summary>
        /// Starts the local video mixing.
        /// 
        /// After calling this method, you can merge multiple video streams into one video stream locally. For example, you can merge the video streams captured by the camera, screen sharing, media player, remote video, video files, images, etc. into one video stream, and then publish the mixed video stream to the channel.
        /// </summary>
        ///
        /// <param name="config">
        /// Configuration of the local video mixing, see LocalTranscoderConfiguration.
        /// The maximum resolution of each video stream participating in the local video mixing is 4096 × 2160. If this limit is exceeded, video mixing does not take effect.
        /// The maximum resolution of the mixed video stream is 4096 × 2160.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartLocalVideoTranscoder(LocalTranscoderConfiguration config);

        ///
        /// <summary>
        /// Updates the local video mixing configuration.
        /// 
        /// After calling StartLocalVideoTranscoder, call this method if you want to update the local video mixing configuration. If you want to update the video source type used for local video mixing, such as adding a second camera or screen to capture video, you need to call this method after StartCameraCapture or StartScreenCapture [2/2].
        /// </summary>
        ///
        /// <param name="config"> Configuration of the local video mixing, see LocalTranscoderConfiguration. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateLocalTranscoderConfiguration(LocalTranscoderConfiguration config);

        ///
        /// <summary>
        /// Stops pushing media streams to a CDN.
        /// 
        /// Agora recommends that you use the server-side Media Push function. You can call this method to stop the live stream on the specified CDN address. This method can stop pushing media streams to only one CDN address at a time, so if you need to stop pushing streams to multiple addresses, call this method multiple times. After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// </summary>
        ///
        /// <param name="url"> The address of Media Push. The format is RTMP or RTMPS. The character length cannot exceed 1024 bytes. Special characters such as Chinese characters are not supported. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopRtmpStream(string url);

        ///
        /// <summary>
        /// Stops the local video mixing.
        /// 
        /// After calling StartLocalVideoTranscoder, call this method if you want to stop the local video mixing.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopLocalVideoTranscoder();

        ///
        /// <summary>
        /// Starts camera capture.
        /// 
        /// You can call this method to start capturing video from one or more cameras by specifying sourceType. On the iOS platform, if you want to enable multi-camera capture, you need to call EnableMultiCamera and set enabled to true before calling this method.
        /// </summary>
        ///
        /// <param name="sourceType">
        /// The type of the video source. See VIDEO_SOURCE_TYPE.
        /// On iOS devices, you can capture video from up to 2 cameras, provided the device has multiple cameras or supports external cameras.
        /// On Android devices, you can capture video from up to 4 cameras, provided the device has multiple cameras or supports external cameras.
        /// On the desktop platforms, you can capture video from up to 4 cameras.
        /// </param>
        ///
        /// <param name="config"> The configuration of the video capture. See CameraCapturerConfiguration. On the iOS platform, this parameter has no practical function. Use the config parameter in EnableMultiCamera instead to set the video capture configuration. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartCameraCapture(VIDEO_SOURCE_TYPE sourceType, CameraCapturerConfiguration config);

        ///
        /// <summary>
        /// Stops camera capture.
        /// 
        /// After calling StartCameraCapture to start capturing video through one or more cameras, you can call this method and set the sourceType parameter to stop the capture from the specified cameras. On the iOS platform, if you want to disable multi-camera capture, you need to call EnableMultiCamera after calling this method and set enabled to false. If you are using the local video mixing function, calling this method can cause the local video mixing to be interrupted.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopCameraCapture(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Sets the rotation angle of the captured video.
        /// 
        /// This method applies to Windows only.
        /// You must call this method after EnableVideo. The setting result will take effect after the camera is successfully turned on, that is, after the SDK triggers the OnLocalVideoStateChanged callback and returns the local video state as LOCAL_VIDEO_STREAM_STATE_CAPTURING (1).
        /// When the video capture device does not have the gravity sensing function, you can call this method to manually adjust the rotation angle of the captured video.
        /// </summary>
        ///
        /// <param name="type"> The video source type. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <param name="orientation"> The clockwise rotation angle. See VIDEO_ORIENTATION. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetCameraDeviceOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        ///
        /// @ignore
        ///
        public abstract int SetScreenCaptureOrientation(VIDEO_SOURCE_TYPE type, VIDEO_ORIENTATION orientation);

        ///
        /// <summary>
        /// Starts screen capture from the specified video source.
        /// 
        /// This method applies to the macOS and Windows only.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE. On the macOS platform, this parameter can only be set to VIDEO_SOURCE_SCREEN (2). </param>
        ///
        /// <param name="config"> The configuration of the captured screen. See ScreenCaptureConfiguration. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartScreenCapture(VIDEO_SOURCE_TYPE sourceType, ScreenCaptureConfiguration config);

        ///
        /// <summary>
        /// Stops screen capture from the specified video source.
        /// 
        /// This method applies to the macOS and Windows only.
        /// </summary>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopScreenCapture(VIDEO_SOURCE_TYPE sourceType);

        ///
        /// <summary>
        /// Gets the current connection state of the SDK.
        /// 
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// The current connection state. See CONNECTION_STATE_TYPE.
        /// </returns>
        ///
        public abstract CONNECTION_STATE_TYPE GetConnectionState();

        ///
        /// @ignore
        ///
        public abstract int SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority);

        ///
        /// <summary>
        /// Enables or disables the built-in encryption.
        /// 
        /// In scenarios requiring high security, Agora recommends calling this method to enable the built-in encryption before joining a channel. All users in the same channel must use the same encryption mode and encryption key. After the user leaves the channel, the SDK automatically disables the built-in encryption. To enable the built-in encryption, call this method before the user joins the channel again. If you enable the built-in encryption, you cannot use the Media Push function.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable built-in encryption: true : Enable the built-in encryption. false : (Default) Disable the built-in encryption. </param>
        ///
        /// <param name="config"> Built-in encryption configurations. See EncryptionConfig. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: An invalid parameter is used. Set the parameter with a valid value.
        /// -4: The built-in encryption mode is incorrect or the SDK fails to load the external encryption library. Check the enumeration or reload the external encryption library.
        /// -7: The SDK is not initialized. Initialize the IRtcEngine instance before calling this method.
        /// </returns>
        ///
        public abstract int EnableEncryption(bool enabled, EncryptionConfig config);

        ///
        /// <summary>
        /// Creates a data stream.
        /// 
        /// Each user can create up to five data streams during the lifecycle of IRtcEngine. The data stream will be destroyed when leaving the channel, and the data stream needs to be recreated if needed.
        /// Call this method after joining a channel.
        /// Agora does not support setting reliable as true and ordered as false.
        /// </summary>
        ///
        /// <param name="streamId"> An output parameter; the ID of the data stream created. </param>
        ///
        /// <param name="reliable"> Whether or not the data stream is reliable: true : The recipients receive the data from the sender within five seconds. If the recipient does not receive the data within five seconds, the SDK triggers the OnStreamMessageError callback and returns an error code. false : There is no guarantee that the recipients receive the data stream within five seconds and no error message is reported for any delay or missing data stream. </param>
        ///
        /// <param name="ordered"> Whether or not the recipients receive the data stream in the sent order: true : The recipients receive the data in the sent order. false : The recipients do not receive the data in the sent order. </param>
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
        /// 
        /// Creates a data stream. Each user can create up to five data streams in a single channel. Compared with CreateDataStream [1/2], this method does not support data reliability. If a data packet is not received five seconds after it was sent, the SDK directly discards the data.
        /// </summary>
        ///
        /// <param name="streamId"> An output parameter; the ID of the data stream created. </param>
        ///
        /// <param name="config"> The configurations for the data stream. See DataStreamConfig. </param>
        ///
        /// <returns>
        /// 0: The data stream is successfully created.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int CreateDataStream(ref int streamId, DataStreamConfig config);

        ///
        /// <summary>
        /// Sends data stream messages.
        /// 
        /// Sends data stream messages to all users in a channel. The SDK has the following restrictions on this method:
        /// Up to 30 packets can be sent per second in a channel with each packet having a maximum size of 1 KB.
        /// Each client can send up to 6 KB of data per second.
        /// Each user can have up to five data streams simultaneously. A successful method call triggers the OnStreamMessage callback on the remote client, from which the remote user gets the stream message. A failed method call triggers the OnStreamMessageError callback on the remote client.
        /// Ensure that you call CreateDataStream [2/2] to create a data channel before calling this method.
        /// In live streaming scenarios, this method only applies to hosts.
        /// </summary>
        ///
        /// <param name="streamId"> The data stream ID. You can get the data stream ID by calling CreateDataStream [2/2]. </param>
        ///
        /// <param name="data"> The message to be sent. </param>
        ///
        /// <param name="length"> The length of the data. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SendStreamMessage(int streamId, byte[] data, uint length);

        ///
        /// <summary>
        /// Adds a watermark image to the local video.
        /// 
        /// Deprecated: This method is deprecated. Use AddVideoWatermark [2/2] instead. This method adds a PNG watermark image to the local video stream in a live streaming session. Once the watermark image is added, all the users in the channel (CDN audience included) and the video capturing device can see and capture it. If you only want to add a watermark to the CDN live streaming, see StartRtmpStreamWithTranscoding.
        /// The URL descriptions are different for the local video and CDN live streaming: In a local video stream, URL refers to the absolute path of the added watermark image file in the local video stream. In a CDN live stream, URL refers to the URL address of the added watermark image in the CDN live streaming.
        /// The source file of the watermark image must be in the PNG file format. If the width and height of the PNG file differ from your settings in this method, the PNG file will be cropped to conform to your settings.
        /// The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one.
        /// </summary>
        ///
        /// <param name="watermark"> The watermark image to be added to the local live streaming: RtcImage. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AddVideoWatermark(RtcImage watermark);

        ///
        /// <summary>
        /// Adds a watermark image to the local video.
        /// 
        /// This method adds a PNG watermark image to the local video in the live streaming. Once the watermark image is added, all the audience in the channel (CDN audience included), and the capturing device can see and capture it. The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one. The watermark coordinates are dependent on the settings in the SetVideoEncoderConfiguration method:
        /// If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed landscape mode or the adaptive landscape mode, the watermark uses the landscape orientation.
        /// If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed portrait mode or the adaptive portrait mode, the watermark uses the portrait orientation.
        /// When setting the watermark position, the region must be less than the dimensions set in the SetVideoEncoderConfiguration method; otherwise, the watermark image will be cropped.
        /// Ensure that calling this method after EnableVideo.
        /// If you only want to add a watermark to the media push, you can call this method or the StartRtmpStreamWithTranscoding method.
        /// This method supports adding a watermark image in the PNG file format only. Supported pixel formats of the PNG image are RGBA, RGB, Palette, Gray, and Alpha_gray.
        /// If the dimensions of the PNG image differ from your settings in this method, the image will be cropped or zoomed to conform to your settings.
        /// If you have enabled the mirror mode for the local video, the watermark on the local video is also mirrored. To avoid mirroring the watermark, Agora recommends that you do not use the mirror and watermark functions for the local video at the same time. You can implement the watermark function in your application layer.
        /// </summary>
        ///
        /// <param name="watermarkUrl"> The local file path of the watermark image to be added. This method supports adding a watermark image from the local absolute or relative file path. </param>
        ///
        /// <param name="options"> The options of the watermark image to be added. See WatermarkOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AddVideoWatermark(string watermarkUrl, WatermarkOptions options);

        ///
        /// <summary>
        /// Removes the watermark image from the video stream.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ClearVideoWatermarks();

        ///
        /// @ignore
        ///
        [Obsolete("Use disableAudio() instead.")]
        public abstract int PauseAudio();

        ///
        /// @ignore
        ///
        [Obsolete("Use enableAudio() instead.")]
        public abstract int ResumeAudio();

        ///
        /// <summary>
        /// Enables interoperability with the Agora Web SDK (applicable only in the live streaming scenarios).
        /// 
        /// Deprecated: The SDK automatically enables interoperability with the Web SDK, so you no longer need to call this method. You can call this method to enable or disable interoperability with the Agora Web SDK. If a channel has Web SDK users, ensure that you call this method, or the video of the Native user will be a black screen for the Web user. This method is only applicable in live streaming scenarios, and interoperability is enabled by default in communication scenarios.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable interoperability: true : Enable interoperability. false : (Default) Disable interoperability. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        [Obsolete("The Agora NG SDK enables the interoperablity with the Web SDK.")]
        public abstract int EnableWebSdkInteroperability(bool enabled);

        ///
        /// <summary>
        /// Reports customized messages.
        /// 
        /// Agora supports reporting and analyzing customized messages. This function is in the beta stage with a free trial. The ability provided in its beta test version is reporting a maximum of 10 message pieces within 6 seconds, with each message piece not exceeding 256 bytes and each string not exceeding 100 bytes. To try out this function, contact and discuss the format of customized messages with us.
        /// </summary>
        ///
        public abstract int SendCustomReportMessage(string id, string category, string @event, string label, int value);

        ///
        /// <summary>
        /// Registers the metadata observer.
        /// 
        /// You need to implement the IMetadataObserver class and specify the metadata type in this method. This method enables you to add synchronized metadata in the video stream for more diversified
        /// live interactive streaming, such as sending shopping links, digital coupons, and online quizzes. Call this method before JoinChannel [2/2].
        /// </summary>
        ///
        /// <param name="observer"> The metadata observer. See IMetadataObserver. </param>
        ///
        /// <param name="type"> The metadata type. The SDK currently only supports VIDEO_METADATA. See METADATA_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterMediaMetadataObserver(IMetadataObserver observer, METADATA_TYPE type);

        ///
        /// <summary>
        /// Unregisters the specified metadata observer.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnregisterMediaMetadataObserver();

        ///
        /// @ignore
        ///
        public abstract int StartAudioFrameDump(string channel_id, uint uid, string location, string uuid, string passwd, long duration_ms, bool auto_upload);

        ///
        /// @ignore
        ///
        public abstract int StopAudioFrameDump(string channel_id, uint uid, string location);

        ///
        /// <summary>
        /// Sets whether to enable the AI ​​noise suppression function and set the noise suppression mode.
        /// 
        /// You can call this method to enable AI noise suppression function. Once enabled, the SDK automatically detects and reduces stationary and non-stationary noise from your audio on the premise of ensuring the quality of human voice. Stationary noise refers to noise signal with constant average statistical properties and negligibly small fluctuations of level within the period of observation. Common sources of stationary noises are:
        /// Television;
        /// Air conditioner;
        /// Machinery, etc. Non-stationary noise refers to noise signal with huge fluctuations of level within the period of observation; common sources of non-stationary noises are:
        /// Thunder;
        /// Explosion;
        /// Cracking, etc.
        /// Agora does not recommend enabling this function on devices running Android 6.0 and below.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable the AI noise suppression function: true : Enable the AI noise suppression. false : (Default) Disable the AI noise suppression. </param>
        ///
        /// <param name="mode"> The AI noise suppression modes. See AUDIO_AINS_MODE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAINSMode(bool enabled, AUDIO_AINS_MODE mode);

        ///
        /// <summary>
        /// Registers a user account.
        /// 
        /// Once registered, the user account can be used to identify the local user when the user joins the channel. After the registration is successful, the user account can identify the identity of the local user, and the user can use it to join the channel. After the user successfully registers a user account, the SDK triggers the OnLocalUserRegistered callback on the local client, reporting the user ID and account of the local user. This method is optional. To join a channel with a user account, you can choose either of the following ways:
        /// Call RegisterLocalUserAccount to create a user account, and then call JoinChannelWithUserAccount [2/2] to join the channel.
        /// Call the JoinChannelWithUserAccount [2/2] method to join the channel. The difference between the two ways is that the time elapsed between calling the RegisterLocalUserAccount method and joining the channel is shorter than directly calling JoinChannelWithUserAccount [2/2].
        /// Ensure that you set the userAccount parameter; otherwise, this method does not take effect.
        /// Ensure that the userAccount is unique in the channel.
        /// To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// </summary>
        ///
        /// <param name="appId"> The App ID of your project on Agora Console. </param>
        ///
        /// <param name="userAccount">
        /// The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are as follow(89 in total):
        /// The 26 lowercase English letters: a to z.
        /// The 26 uppercase English letters: A to Z.
        /// All numeric characters: 0 to 9.
        /// Space
        /// "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterLocalUserAccount(string appId, string userAccount);

        ///
        /// <summary>
        /// Joins a channel with a User Account and Token.
        /// 
        /// This method allows a user to join the channel with the user account and a token. After the user successfully joins the channel, the SDK triggers the following callbacks:
        /// The local client: OnLocalUserRegistered, OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
        /// The remote client: OnUserJoined and OnUserInfoUpdated callbacks, if the user joining the channel is in the communication profile or is a host in the live streaming profile. Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.
        /// To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// If you choose the Testing Mode (using an App ID for authentication) for your project and call this method to join a channel, you will automatically exit the channel after 24 hours.
        /// </summary>
        ///
        /// <param name="userAccount">
        /// The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are as follows(89 in total):
        /// The 26 lowercase English letters: a to z.
        /// The 26 uppercase English letters: A to Z.
        /// All numeric characters: 0 to 9.
        /// Space
        /// "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
        /// </param>
        ///
        /// <param name="token"> The token generated on your server for authentication. If you need to join different channels at the same time or switch between channels, Agora recommends using a wildcard token so that you don't need to apply for a new token every time joining a channel. </param>
        ///
        /// <param name="channelId">
        /// The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters (89 characters in total):
        /// All lowercase English letters: a to z.
        /// All uppercase English letters: A to Z.
        /// All numeric characters: 0 to 9.
        /// Space
        /// "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -3: The initialization of the SDK fails. You can try to initialize the SDK again.
        /// -5: The request is rejected.
        /// -17: The request to join the channel is rejected. Since the SDK only supports users to join one IRtcEngine channel at a time; this error code will be returned when the user who has joined the IRtcEngine channel calls the join channel method in the IRtcEngine class again with a valid channel name.
        /// </returns>
        ///
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount);

        ///
        /// <summary>
        /// Joins the channel with a user account, and configures whether to automatically subscribe to audio or video streams after joining the channel.
        /// 
        /// To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the ID of the user is set to the same parameter type.
        /// If you choose the Testing Mode (using an App ID for authentication) for your project and call this method to join a channel, you will automatically exit the channel after 24 hours. This method allows a user to join the channel with the user account. After the user successfully joins the channel, the SDK triggers the following callbacks:
        /// The local client: OnLocalUserRegistered, OnJoinChannelSuccess and OnConnectionStateChanged callbacks.
        /// The remote client: The OnUserJoined callback, if the user is in the COMMUNICATION profile, and the OnUserInfoUpdated callback if the user is a host in the LIVE_BROADCASTING profile. Once a user joins the channel, the user subscribes to the audio and video streams of all the other users in the channel by default, giving rise to usage and billing calculation. To stop subscribing to a specified stream or all remote streams, call the corresponding mute methods.
        /// </summary>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions. </param>
        ///
        /// <param name="token"> The token generated on your server for authentication. If you need to join different channels at the same time or switch between channels, Agora recommends using a wildcard token so that you don't need to apply for a new token every time joining a channel. </param>
        ///
        /// <param name="channelId">
        /// The channel name. This parameter signifies the channel in which users engage in real-time audio and video interaction. Under the premise of the same App ID, users who fill in the same channel ID enter the same channel for audio and video interaction. The string length must be less than 64 bytes. Supported characters (89 characters in total):
        /// All lowercase English letters: a to z.
        /// All uppercase English letters: A to Z.
        /// All numeric characters: 0 to 9.
        /// Space
        /// "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
        /// </param>
        ///
        /// <param name="userAccount">
        /// The user account. This parameter is used to identify the user in the channel for real-time audio and video engagement. You need to set and manage user accounts yourself and ensure that each user account in the same channel is unique. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as NULL. Supported characters are as follows(89 in total):
        /// The 26 lowercase English letters: a to z.
        /// The 26 uppercase English letters: A to Z.
        /// All numeric characters: 0 to 9.
        /// Space
        /// "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~", ","
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid. For example, the token is invalid, the uid parameter is not set to an integer, or the value of a member in ChannelMediaOptions is invalid. You need to pass in a valid parameter and join the channel again.
        /// -3: Failes to initialize the IRtcEngine object. You need to reinitialize the IRtcEngine object.
        /// -7: The IRtcEngine object has not been initialized. You need to initialize the IRtcEngine object before calling this method.
        /// -8: The internal state of the IRtcEngine object is wrong. The typical cause is that you call this method to join the channel without calling StartEchoTest [3/3] to stop the test after calling StopEchoTest to start a call loop test. You need to call StopEchoTest before calling this method.
        /// -17: The request to join the channel is rejected. The typical cause is that the user is in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED (1) state.
        /// -102: The channel name is invalid. You need to pass in a valid channelname in channelId to rejoin the channel.
        /// -121: The user ID is invalid. You need to pass in a valid user ID in uid to rejoin the channel.
        /// </returns>
        ///
        public abstract int JoinChannelWithUserAccount(string token, string channelId, string userAccount, ChannelMediaOptions options);

        ///
        /// <summary>
        /// Gets the user information by passing in the user account.
        /// 
        /// After a remote user joins the channel, the SDK gets the user ID and account of the remote user, caches them in a mapping table object, and triggers the OnUserInfoUpdated callback on the local client. After receiving the callback, you can call this method to get the user account of the remote user from the UserInfo object by passing in the user ID.
        /// </summary>
        ///
        /// <param name="userInfo">
        /// Input and output parameter. The UserInfo object that identifies the user information.
        /// Input: A UserInfo object.
        /// Output: A UserInfo object that contains the user account and user ID of the user.
        /// </param>
        ///
        /// <param name="userAccount"> The user account. </param>
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
        /// 
        /// After a remote user joins the channel, the SDK gets the user ID and account of the remote user, caches them in a mapping table object, and triggers the OnUserInfoUpdated callback on the local client. After receiving the callback, you can call this method to get the user account of the remote user from the UserInfo object by passing in the user ID.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. </param>
        ///
        /// <param name="userInfo">
        /// Input and output parameter. The UserInfo object that identifies the user information.
        /// Input: A UserInfo object.
        /// Output: A UserInfo object that contains the user account and user ID of the user.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetUserInfoByUid(uint uid, ref UserInfo userInfo);

        ///
        /// <summary>
        /// Starts relaying media streams across channels or updates channels for media relay.
        /// 
        /// The first successful call to this method starts relaying media streams from the source channel to the destination channels. To relay the media stream to other channels, or exit one of the current media relays, you can call this method again to update the destination channels. This feature supports relaying media streams to a maximum of six destination channels. After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback, and this callback returns the state of the media stream relay. Common states are as follows:
        /// If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), it means that the SDK starts relaying media streams from the source channel to the destination channel.
        /// If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_FAILURE (3), an exception occurs during the media stream relay.
        /// Call this method after joining the channel.
        /// This method takes effect only when you are a host in a live streaming channel.
        /// The relaying media streams across channels function needs to be enabled by contacting.
        /// Agora does not support string user accounts in this API.
        /// </summary>
        ///
        /// <param name="configuration"> The configuration of the media stream relay. See ChannelMediaRelayConfiguration. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -1: A general error occurs (no specified reason).
        /// -2: The parameter is invalid.
        /// -7: The method call was rejected. It may be because the SDK has not been initialized successfully, or the user role is not a host.
        /// -8: Internal state error. Probably because the user is not a broadcaster.
        /// </returns>
        ///
        public abstract int StartOrUpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration);

        ///
        /// <summary>
        /// Stops the media stream relay. Once the relay stops, the host quits all the target channels.
        /// 
        /// After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback. If the callback reports RELAY_STATE_IDLE (0) and RELAY_OK (0), the host successfully stops the relay. If the method call fails, the SDK triggers the OnChannelMediaRelayStateChanged callback with the RELAY_ERROR_SERVER_NO_RESPONSE (2) or RELAY_ERROR_SERVER_CONNECTION_LOST (8) status code. You can call the LeaveChannel [2/2] method to leave the channel, and the media stream relay automatically stops.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopChannelMediaRelay();

        ///
        /// <summary>
        /// Pauses the media stream relay to all target channels.
        /// 
        /// After the cross-channel media stream relay starts, you can call this method to pause relaying media streams to all target channels; after the pause, if you want to resume the relay, call ResumeAllChannelMediaRelay. Call this method after StartOrUpdateChannelMediaRelay.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAllChannelMediaRelay();

        ///
        /// <summary>
        /// Resumes the media stream relay to all target channels.
        /// 
        /// After calling the PauseAllChannelMediaRelay method, you can call this method to resume relaying media streams to all destination channels. Call this method after PauseAllChannelMediaRelay.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeAllChannelMediaRelay();

        ///
        /// <summary>
        /// Sets the audio profile of the audio streams directly pushed to the CDN by the host.
        /// </summary>
        ///
        /// <param name="profile"> The audio profile, including the sampling rate, bitrate, encoding mode, and the number of channels. See AUDIO_PROFILE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDirectCdnStreamingAudioConfiguration(AUDIO_PROFILE_TYPE profile);

        ///
        /// <summary>
        /// Sets the video profile of the media streams directly pushed to the CDN by the host.
        /// 
        /// This method only affects video streams captured by cameras or screens, or from custom video capture sources. That is, when you set publishCameraTrack or publishCustomVideoTrack in DirectCdnStreamingMediaOptions as true to capture videos, you can call this method to set the video profiles. If your local camera does not support the video resolution you set,the SDK automatically adjusts the video resolution to a value that is closest to your settings for capture, encoding or streaming, with the same aspect ratio as the resolution you set. You can get the actual resolution of the video streams through the OnDirectCdnStreamingStats callback.
        /// </summary>
        ///
        /// <param name="config"> Video profile. See VideoEncoderConfiguration. During CDN live streaming, Agora only supports setting ORIENTATION_MODE as ORIENTATION_MODE_FIXED_LANDSCAPE or ORIENTATION_MODE_FIXED_PORTRAIT. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetDirectCdnStreamingVideoConfiguration(VideoEncoderConfiguration config);

        ///
        /// <summary>
        /// Starts pushing media streams to the CDN directly.
        /// 
        /// Aogra does not support pushing media streams to one URL repeatedly. Media options Agora does not support setting the value of publishCameraTrack and publishCustomVideoTrack as true, or the value of publishMicrophoneTrack and publishCustomAudioTrack as true at the same time. When choosing media setting options (DirectCdnStreamingMediaOptions), you can refer to the following examples: If you want to push audio and video streams published by the host to the CDN, the media setting options should be set as follows: publishCustomAudioTrack is set as true and call the PushAudioFrame method publishCustomVideoTrack is set as true and call the PushVideoFrame method publishCameraTrack is set as false (the default value) publishMicrophoneTrack is set as false (the default value) As of v4.2.0, Agora SDK supports audio-only live streaming. You can set publishCustomAudioTrack or publishMicrophoneTrack in DirectCdnStreamingMediaOptions as true and call PushAudioFrame to push audio streams. Agora only supports pushing one audio and video streams or one audio streams to CDN.
        /// </summary>
        ///
        /// <param name="publishUrl"> The CDN live streaming URL. </param>
        ///
        /// <param name="options"> The media setting options for the host. See DirectCdnStreamingMediaOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartDirectCdnStreaming(string publishUrl, DirectCdnStreamingMediaOptions options);

        ///
        /// <summary>
        /// Stops pushing media streams to the CDN directly.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopDirectCdnStreaming();

        ///
        /// @ignore
        ///
        public abstract int UpdateDirectCdnStreamingMediaOptions(DirectCdnStreamingMediaOptions options);

        ///
        /// <summary>
        /// Enables the virtual metronome.
        /// 
        /// In music education, physical education and other scenarios, teachers usually need to use a metronome so that students can practice with the correct beat. The meter is composed of a downbeat and upbeats. The first beat of each measure is called a downbeat, and the rest are called upbeats. In this method, you need to set the file path of the upbeat and downbeat, the number of beats per measure, the beat speed, and whether to send the sound of the metronome to remote users. After successfully calling this method, the SDK triggers the OnRhythmPlayerStateChanged callback locally to report the status of the virtual metronome.
        /// This method is for Android and iOS only.
        /// After enabling the virtual metronome, the SDK plays the specified audio effect file from the beginning, and controls the playback duration of each file according to beatsPerMinute you set in AgoraRhythmPlayerConfig. For example, if you set beatsPerMinute as 60, the SDK plays one beat every second. If the file duration exceeds the beat duration, the SDK only plays the audio within the beat duration.
        /// By default, the sound of the virtual metronome is published in the channel. If you do not want the sound to be heard by the remote users, you can set publishRhythmPlayerTrack in ChannelMediaOptions as false.
        /// </summary>
        ///
        /// <param name="sound1"> The absolute path or URL address (including the filename extensions) of the file for the downbeat. For example, C:\music\audio.mp4. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support. </param>
        ///
        /// <param name="sound2"> The absolute path or URL address (including the filename extensions) of the file for the upbeats. For example, C:\music\audio.mp4. For the audio file formats supported by this method, see What formats of audio files does the Agora RTC SDK support. </param>
        ///
        /// <param name="config"> The metronome configuration. See AgoraRhythmPlayerConfig. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -22: Cannot find audio effect files. Please set the correct paths for sound1 and sound2.
        /// </returns>
        ///
        public abstract int StartRhythmPlayer(string sound1, string sound2, AgoraRhythmPlayerConfig config);

        ///
        /// <summary>
        /// Disables the virtual metronome.
        /// 
        /// After calling StartRhythmPlayer, you can call this method to disable the virtual metronome. This method is for Android and iOS only.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopRhythmPlayer();

        ///
        /// <summary>
        /// Configures the virtual metronome.
        /// 
        /// This method is for Android and iOS only.
        /// After enabling the virtual metronome, the SDK plays the specified audio effect file from the beginning, and controls the playback duration of each file according to beatsPerMinute you set in AgoraRhythmPlayerConfig. For example, if you set beatsPerMinute as 60, the SDK plays one beat every second. If the file duration exceeds the beat duration, the SDK only plays the audio within the beat duration.
        /// By default, the sound of the virtual metronome is published in the channel. If you do not want the sound to be heard by the remote users, you can set publishRhythmPlayerTrack in ChannelMediaOptions as false. After calling StartRhythmPlayer, you can call this method to reconfigure the virtual metronome. After successfully calling this method, the SDK triggers the OnRhythmPlayerStateChanged callback locally to report the status of the virtual metronome.
        /// </summary>
        ///
        /// <param name="config"> The metronome configuration. See AgoraRhythmPlayerConfig. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ConfigRhythmPlayer(AgoraRhythmPlayerConfig config);

        ///
        /// <summary>
        /// Takes a snapshot of a video stream.
        /// 
        /// This method takes a snapshot of a video stream from the specified user, generates a JPG image, and saves it to the specified path. The method is asynchronous, and the SDK has not taken the snapshot when the method call returns. After a successful method call, the SDK triggers the OnSnapshotTaken callback to report whether the snapshot is successfully taken, as well as the details for that snapshot.
        /// Call this method after joining a channel.
        /// When used for local video snapshots, this method takes a snapshot for the video streams specified in ChannelMediaOptions.
        /// If the user's video has been preprocessed, for example, watermarked or beautified, the resulting snapshot includes the pre-processing effect.
        /// </summary>
        ///
        /// <param name="uid"> The user ID. Set uid as 0 if you want to take a snapshot of the local user's video. </param>
        ///
        /// <param name="filePath">
        /// The local path (including filename extensions) of the snapshot. For example:
        /// Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.jpg
        /// iOS: /App Sandbox/Library/Caches/example.jpg
        /// macOS: ～/Library/Logs/example.jpg
        /// Android: /storage/emulated/0/Android/data/<package name>/files/example.jpg Ensure that the path you specify exists and is writable.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int TakeSnapshot(uint uid, string filePath);

        ///
        /// <summary>
        /// Enables or disables video screenshot and upload.
        /// 
        /// When video screenshot and upload function is enabled, the SDK takes screenshots and uploads videos sent by local users based on the type and frequency of the module you set in ContentInspectConfig. After video screenshot and upload, the Agora server sends the callback notification to your app server in HTTPS requests and sends all screenshots to the third-party cloud storage service. Before calling this method, ensure that you have contacted to activate the video screenshot upload service.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable video screenshot and upload : true : Enables video screenshot and upload. false : Disables video screenshot and upload. </param>
        ///
        /// <param name="config"> Configuration of video screenshot and upload. See ContentInspectConfig. When the video moderation module is set to video moderation via Agora self-developed extension(CONTENT_INSPECT_SUPERVISION), the video screenshot and upload dynamic library libagora_content_inspect_extension.dll is required. Deleting this library disables the screenshot and upload feature. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableContentInspect(bool enabled, ContentInspectConfig config);

        ///
        /// <summary>
        /// Adjusts the volume of the custom audio track played remotely.
        /// 
        /// Ensure you have called the CreateCustomAudioTrack method to create a custom audio track before calling this method. If you want to change the volume of the audio played remotely, you need to call this method again.
        /// </summary>
        ///
        /// <param name="trackId"> The audio track ID. Set this parameter to the custom audio track ID returned in CreateCustomAudioTrack. </param>
        ///
        /// <param name="volume"> The volume of the audio source. The value can range from 0 to 100. 0 means mute; 100 means the original volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustCustomAudioPublishVolume(uint trackId, int volume);

        ///
        /// <summary>
        /// Adjusts the volume of the custom audio track played locally.
        /// 
        /// Ensure you have called the CreateCustomAudioTrack method to create a custom audio track before calling this method. If you want to change the volume of the audio to be played locally, you need to call this method again.
        /// </summary>
        ///
        /// <param name="volume"> The volume of the audio source. The value can range from 0 to 100. 0 means mute; 100 means the original volume. </param>
        ///
        /// <param name="trackId"> The audio track ID. Set this parameter to the custom audio track ID returned in CreateCustomAudioTrack. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustCustomAudioPlayoutVolume(uint trackId, int volume);

        ///
        /// <summary>
        /// Sets up cloud proxy service.
        /// 
        /// When users' network access is restricted by a firewall, configure the firewall to allow specific IP addresses and ports provided by Agora; then, call this method to enable the cloud proxyType and set the cloud proxy type with the proxyType parameter. After successfully connecting to the cloud proxy, the SDK triggers the OnConnectionStateChanged (CONNECTION_STATE_CONNECTING, CONNECTION_CHANGED_SETTING_PROXY_SERVER) callback. To disable the cloud proxy that has been set, call the SetCloudProxy (NONE_PROXY). To change the cloud proxy type that has been set, call the SetCloudProxy (NONE_PROXY) first, and then call the SetCloudProxy to set the proxyType you want.
        /// Agora recommends that you call this method after joining a channel.
        /// When a user is behind a firewall and uses the Force UDP cloud proxy, the services for Media Push and cohosting across channels are not available.
        /// When you use the Force TCP cloud proxy, note that an error would occur when calling the StartAudioMixing [2/2] method to play online music files in the HTTP protocol. The services for Media Push and cohosting across channels use the cloud proxy with the TCP protocol.
        /// </summary>
        ///
        /// <param name="proxyType"> The type of the cloud proxy. See CLOUD_PROXY_TYPE. This parameter is mandatory. The SDK reports an error if you do not pass in a value. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -2: The parameter is invalid.
        /// -7: The SDK is not initialized.
        /// </returns>
        ///
        public abstract int SetCloudProxy(CLOUD_PROXY_TYPE proxyType);

        ///
        /// @ignore
        ///
        public abstract int SetLocalAccessPoint(LocalAccessPointConfiguration config);

        ///
        /// <summary>
        /// Sets audio advanced options.
        /// 
        /// If you have advanced audio processing requirements, such as capturing and sending stereo audio, you can call this method to set advanced audio options. Call this method after calling JoinChannel [2/2], EnableAudio and EnableLocalAudio.
        /// </summary>
        ///
        /// <param name="options"> The advanced options for audio. See AdvancedAudioOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAdvancedAudioOptions(AdvancedAudioOptions options, int sourceType = 0);

        ///
        /// @ignore
        ///
        public abstract int SetAVSyncSource(string channelId, uint uid);

        ///
        /// <summary>
        /// Sets whether to replace the current video feeds with images when publishing video streams.
        /// 
        /// Agora recommends that you call this method after joining a channel. When publishing video streams, you can call this method to replace the current video feeds with custom images. Once you enable this function, you can select images to replace the video feeds through the ImageTrackOptions parameter. If you disable this function, the remote users see the video feeds that you publish.
        /// </summary>
        ///
        /// <param name="enable"> Whether to replace the current video feeds with custom images: true : Replace the current video feeds with custom images. false : (Default) Do not replace the current video feeds with custom images. </param>
        ///
        /// <param name="options"> Image configurations. See ImageTrackOptions. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableVideoImageSource(bool enable, ImageTrackOptions options);

        ///
        /// <summary>
        /// Gets the current Monotonic Time of the SDK.
        /// 
        /// Monotonic Time refers to a monotonically increasing time series whose value increases over time. The unit is milliseconds. In custom video capture and custom audio capture scenarios, in order to ensure audio and video synchronization, Agora recommends that you call this method to obtain the current Monotonic Time of the SDK, and then pass this value into the timestamp parameter in the captured video frame (VideoFrame) and audio frame (AudioFrame).
        /// </summary>
        ///
        /// <returns>
        /// ≥0: The method call is successful, and returns the current Monotonic Time of the SDK (in milliseconds).
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract long GetCurrentMonotonicTimeInMs();

        ///
        /// @ignore
        ///
        public abstract int EnableWirelessAccelerate(bool enabled);

        ///
        /// <summary>
        /// Gets the type of the local network connection.
        /// 
        /// You can use this method to get the type of network in use at any stage. You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The method call is successful, and the local network connection type is returned.
        /// 0: The SDK disconnects from the network.
        /// 1: The network type is LAN.
        /// 2: The network type is Wi-Fi (including hotspots).
        /// 3: The network type is mobile 2G.
        /// 4: The network type is mobile 3G.
        /// 5: The network type is mobile 4G.
        /// 6: The network type is mobile 5G.
        /// &lt; 0: The method call failed with an error code.
        /// -1: The network type is unknown.
        /// </returns>
        ///
        public abstract int GetNetworkType();

        ///
        /// <summary>
        /// Provides the technical preview functionalities or special customizations by configuring the SDK with JSON options.
        /// 
        /// Contact to get the JSON configuration method.
        /// </summary>
        ///
        /// <param name="parameters"> Pointer to the set parameters in a JSON string. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetParameters(string parameters);

        ///
        /// <summary>
        /// Enables tracing the video frame rendering process.
        /// 
        /// The SDK starts tracing the rendering status of the video frames in the channel from the moment this method is successfully called and reports information about the event through the OnVideoRenderingTracingResult callback.
        /// By default, the SDK starts tracing the video rendering event automatically when the local user successfully joins the channel. You can call this method at an appropriate time according to the actual application scenario to customize the tracing process.
        /// After the local user leaves the current channel, the SDK automatically resets the time point to the next time when the user successfully joins the channel.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -7: The method is called before IRtcEngine is initialized.
        /// </returns>
        ///
        public abstract int StartMediaRenderingTracing();

        ///
        /// <summary>
        /// Enables audio and video frame instant rendering.
        /// 
        /// After successfully calling this method, the SDK enables the instant frame rendering mode, which can speed up the first frame rendering speed after the user joins the channel.
        /// Once the instant rendering function is enabled, it can only be canceled by calling the Dispose method to destroy the IRtcEngine object.
        /// In this mode, the SDK uses Agora's custom encryption algorithm to shorten the time required to establish transmission links, and the security is reduced compared to the standard DTLS (Datagram Transport Layer Security). If the application scenario requires higher security standards, Agora recommends that you do not use this method.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// -7: The method is called before IRtcEngine is initialized.
        /// </returns>
        ///
        public abstract int EnableInstantMediaRendering();

        ///
        /// <summary>
        /// Gets the current NTP (Network Time Protocol) time.
        /// 
        /// In the real-time chorus scenario, especially when the downlink connections are inconsistent due to network issues among multiple receiving ends, you can call this method to obtain the current NTP time as the reference time, in order to align the lyrics and music of multiple receiving ends and achieve chorus synchronization.
        /// </summary>
        ///
        /// <returns>
        /// The Unix timestamp (ms) of the current NTP time.
        /// </returns>
        ///
        public abstract ulong GetNtpWallTimeInMs();

        ///
        /// <summary>
        /// Checks whether the device supports the specified advanced feature.
        /// 
        /// Checks whether the capabilities of the current device meet the requirements for advanced features such as virtual background and image enhancement.
        /// </summary>
        ///
        /// <param name="type"> The type of the advanced feature, see FeatureType. </param>
        ///
        /// <returns>
        /// true : The current device supports the specified feature. false : The current device does not support the specified feature.
        /// </returns>
        ///
        public abstract bool IsFeatureAvailableOnDevice(FeatureType type);

        ///
        /// @ignore
        ///
        public abstract int SendAudioMetadata(byte[] metadata, ulong length);
        #endregion terra IRtcEngine

        ///
        /// <summary>
        /// Registers a raw video frame observer object.
        /// 
        /// If you want to obtain the original video data of some remote users (referred to as group A) and the encoded video data of other remote users (referred to as group B), you can refer to the following steps:
        /// Call RegisterVideoFrameObserver to register the raw video frame observer before joining the channel.
        /// Call RegisterVideoEncodedFrameObserver to register the encoded video frame observer before joining the channel.
        /// After joining the channel, get the user IDs of group B users through OnUserJoined, and then call SetRemoteVideoSubscriptionOptions to set the encodedFrameOnly of this group of users to true.
        /// Call MuteAllRemoteVideoStreams (false) to start receiving the video streams of all remote users. Then:
        /// The raw video data of group A users can be obtained through the callback in IVideoFrameObserver, and the SDK renders the data by default.
        /// The encoded video data of group B users can be obtained through the callback in IVideoEncodedFrameObserver. If you want to observe raw video frames (such as YUV or RGBA format), Agora recommends that you implement one IVideoFrameObserver class with this method. When calling this method to register a video observer, you can register callbacks in the IVideoFrameObserver class as needed. After you successfully register the video frame observer, the SDK triggers the registered callbacks each time a video frame is received.
        /// Ensure that you call this method before joining a channel.
        /// When handling the video data returned in the callbacks, pay attention to the changes in the width and height parameters, which may be adapted under the following circumstances:
        /// When network conditions deteriorate, the video resolution decreases incrementally.
        /// If the user adjusts the video profile, the resolution of the video returned in the callbacks also changes.
        /// </summary>
        ///
        /// <param name="videoFrameObserver"> The observer instance. See IVideoFrameObserver. To release the instance, set the value as NULL. </param>
        ///
        /// <param name="mode"> The video data callback mode. See OBSERVER_MODE. </param>
        ///
        /// <param name="formatPreference"> The video frame type. See VIDEO_OBSERVER_FRAME_TYPE. </param>
        ///
        /// <param name="position"> A bit mask that controls the frame position of the video observer. See VIDEO_MODULE_POSITION. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterVideoFrameObserver(IVideoFrameObserver observer, VIDEO_OBSERVER_FRAME_TYPE formatPreference, VIDEO_MODULE_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters the video frame observer.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnRegisterVideoFrameObserver();

        ///
        /// <summary>
        /// Registers a receiver object for the encoded video image.
        /// 
        /// If you only want to observe encoded video frames (such as h.264 format) without decoding and rendering the video, Agora recommends that you implement one IVideoEncodedFrameObserver class through this method. If you want to obtain the original video data of some remote users (referred to as group A) and the encoded video data of other remote users (referred to as group B), you can refer to the following steps:
        /// Call RegisterVideoFrameObserver to register the raw video frame observer before joining the channel.
        /// Call RegisterVideoEncodedFrameObserver to register the encoded video frame observer before joining the channel.
        /// After joining the channel, get the user IDs of group B users through OnUserJoined, and then call SetRemoteVideoSubscriptionOptions to set the encodedFrameOnly of this group of users to true.
        /// Call MuteAllRemoteVideoStreams (false) to start receiving the video streams of all remote users. Then:
        /// The raw video data of group A users can be obtained through the callback in IVideoFrameObserver, and the SDK renders the data by default.
        /// The encoded video data of group B users can be obtained through the callback in IVideoEncodedFrameObserver.
        /// Call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="videoEncodedImageReceiver"> The video frame observer object. See IVideoEncodedFrameObserver. </param>
        ///
        /// <param name="mode"> The video data callback mode. See OBSERVER_MODE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterVideoEncodedFrameObserver(IVideoEncodedFrameObserver observer, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters a receiver object for the encoded video frame.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnRegisterVideoEncodedFrameObserver();

        ///
        /// <summary>
        /// Registers an audio frame observer object.
        /// 
        /// Call this method to register an audio frame observer object (register a callback). When you need the SDK to trigger OnMixedAudioFrame, OnRecordAudioFrame, OnPlaybackAudioFrame or OnEarMonitoringAudioFrame callback, you need to use this method to register the callbacks. Ensure that you call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="audioFrameObserver"> The observer instance. See IAudioFrameObserver. Set the value as NULL to release the instance. Agora recommends calling this method after receiving OnLeaveChannel to release the audio observer object. </param>
        ///
        /// <param name="mode"> The audio data callback mode. See OBSERVER_MODE. </param>
        ///
        /// <param name="position"> The frame position of the audio observer. AUDIO_FRAME_POSITION_PLAYBACK (0x0001): This position can observe the playback audio mixed by all remote users, corresponding to the OnPlaybackAudioFrame callback. AUDIO_FRAME_POSITION_RECORD (0x0002): This position can observe the collected local user's audio, corresponding to the OnRecordAudioFrame callback. AUDIO_FRAME_POSITION_MIXED (0x0004): This position can observe the playback audio mixed by the loacl user and all remote users, corresponding to the OnMixedAudioFrame callback. AUDIO_FRAME_POSITION_BEFORE_MIXING (0x0008): This position can observe the audio of a single remote user before mixing, corresponding to the OnPlaybackAudioFrameBeforeMixing callback. AUDIO_FRAME_POSITION_EAR_MONITORING (0x0010): This position can observe the in-ear monitoring audio of the local user, corresponding to the OnEarMonitoringAudioFrame callback. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR);

        ///
        /// <summary>
        /// Unregisters an audio frame observer.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnRegisterAudioFrameObserver();

        ///
        /// <summary>
        /// Unregisters a facial information observer.
        /// </summary>
        ///
        /// <param name="observer"> Facial information observer, see IFaceInfoObserver. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnRegisterFaceInfoObserver();

        #region terra IMediaEngine
        ///
        /// <summary>
        /// Registers a facial information observer.
        /// 
        /// You can call this method to register the OnFaceInfo callback to receive the facial information processed by Agora speech driven extension. When calling this method to register a facial information observer, you can register callbacks in the IFaceInfoObserver class as needed. After successfully registering the facial information observer, the SDK triggers the callback you have registered when it captures the facial information converted by the speech driven extension.
        /// Ensure that you call this method before joining a channel.
        /// Before calling this method, you need to make sure that the speech driven extension has been enabled by calling EnableExtension.
        /// </summary>
        ///
        /// <param name="observer"> Facial information observer, see IFaceInfoObserver. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterFaceInfoObserver(IFaceInfoObserver observer);

        ///
        /// <summary>
        /// Pushes the external audio frame.
        /// 
        /// Before calling this method to push external audio data, perform the following steps:
        /// Call CreateCustomAudioTrack to create a custom audio track and get the audio track ID.
        /// Call JoinChannel [2/2] to join the channel. In ChannelMediaOptions, set publishCustomAduioTrackId to the audio track ID that you want to publish, and set publishCustomAudioTrack to true.
        /// </summary>
        ///
        /// <param name="frame"> The external audio frame. See AudioFrame. </param>
        ///
        /// <param name="trackId"> The audio track ID. If you want to publish a custom external audio source, set this parameter to the ID of the corresponding custom audio track you want to publish. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PushAudioFrame(AudioFrame frame, uint trackId = 0);

        ///
        /// <summary>
        /// Pulls the remote audio data.
        /// 
        /// Before calling this method, call SetExternalAudioSink (enabled : true) to notify the app to enable and set the external audio rendering. After a successful call of this method, the app pulls the decoded and mixed audio data for playback.
        /// Call this method after joining a channel.
        /// Both this method and OnPlaybackAudioFrame callback can be used to get audio data after remote mixing. Note that after calling SetExternalAudioSink to enable external audio rendering, the app no longer receives data from the OnPlaybackAudioFrame callback. Therefore, you should choose between this method and the OnPlaybackAudioFrame callback based on your actual business requirements. The specific distinctions between them are as follows:
        /// After calling this method, the app automatically pulls the audio data from the SDK. By setting the audio data parameters, the SDK adjusts the frame buffer to help the app handle latency, effectively avoiding audio playback jitter.
        /// The SDK sends the audio data to the app through the OnPlaybackAudioFrame callback. Any delay in processing the audio frames may result in audio jitter.
        /// This method is only used for retrieving audio data after remote mixing. If you need to get audio data from different audio processing stages such as capture and playback, you can register the corresponding callbacks by calling RegisterAudioFrameObserver.
        /// </summary>
        ///
        /// <param name="frame"> Pointers to AudioFrame. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PullAudioFrame(AudioFrame frame);

        ///
        /// <summary>
        /// Configures the external video source.
        /// 
        /// Call this method before joining a channel.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to use the external video source: true : Use the external video source. The SDK prepares to accept the external video frame. false : (Default) Do not use the external video source. </param>
        ///
        /// <param name="useTexture"> Whether to use the external video frame in the Texture format. true : Use the external video frame in the Texture format. false : (Default) Do not use the external video frame in the Texture format. </param>
        ///
        /// <param name="sourceType"> Whether the external video frame is encoded. See EXTERNAL_VIDEO_SOURCE_TYPE. </param>
        ///
        /// <param name="encodedVideoOption"> Video encoding options. This parameter needs to be set if sourceType is ENCODED_VIDEO_FRAME. To set this parameter, contact. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExternalVideoSource(bool enabled, bool useTexture, EXTERNAL_VIDEO_SOURCE_TYPE sourceType, SenderOptions encodedVideoOption);

        ///
        /// @ignore
        ///
        [Obsolete("This method is deprecated. Use createCustomAudioTrack(rtc::AUDIO_TRACK_TYPE trackType, const rtc::AudioTrackConfig& config) instead.")]
        public abstract int SetExternalAudioSource(bool enabled, int sampleRate, int channels, bool localPlayback = false, bool publish = true);

        ///
        /// <summary>
        /// Creates a custom audio track.
        /// 
        /// Ensure that you call this method before joining a channel. To publish a custom audio source, see the following steps:
        /// Call this method to create a custom audio track and get the audio track ID.
        /// Call JoinChannel [2/2] to join the channel. In ChannelMediaOptions, set publishCustomAduioTrackId to the audio track ID that you want to publish, and set publishCustomAudioTrack to true.
        /// Call PushAudioFrame and specify trackId as the audio track ID set in step 2. You can then publish the corresponding custom audio source in the channel.
        /// </summary>
        ///
        /// <param name="trackType"> The type of the custom audio track. See AUDIO_TRACK_TYPE. If AUDIO_TRACK_DIRECT is specified for this parameter, you must set publishMicrophoneTrack to false in ChannelMediaOptions when calling JoinChannel [2/2] to join the channel; otherwise, joining the channel fails and returns the error code -2. </param>
        ///
        /// <param name="config"> The configuration of the custom audio track. See AudioTrackConfig. </param>
        ///
        /// <returns>
        /// If the method call is successful, the audio track ID is returned as the unique identifier of the audio track.
        /// If the method call fails, a negative value is returned.
        /// </returns>
        ///
        public abstract uint CreateCustomAudioTrack(AUDIO_TRACK_TYPE trackType, AudioTrackConfig config);

        ///
        /// <summary>
        /// Destroys the specified audio track.
        /// </summary>
        ///
        /// <param name="trackId"> The custom audio track ID returned in CreateCustomAudioTrack. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int DestroyCustomAudioTrack(uint trackId);

        ///
        /// <summary>
        /// Sets the external audio sink.
        /// 
        /// This method applies to scenarios where you want to use external audio data for playback. After you set the external audio sink, you can call PullAudioFrame to pull remote audio frames. The app can process the remote audio and play it with the audio effects that you want.
        /// </summary>
        ///
        /// <param name="enabled"> Whether to enable or disable the external audio sink: true : Enables the external audio sink. false : (Default) Disables the external audio sink. </param>
        ///
        /// <param name="sampleRate"> The sample rate (Hz) of the external audio sink, which can be set as 16000, 32000, 44100, or 48000. </param>
        ///
        /// <param name="channels">
        /// The number of audio channels of the external audio sink:
        /// 1: Mono.
        /// 2: Stereo.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetExternalAudioSink(bool enabled, int sampleRate, int channels);

        ///
        /// <summary>
        /// Pushes the external raw video frame to the SDK through video tracks.
        /// 
        /// To publish a custom video source, see the following steps:
        /// Call CreateCustomVideoTrack to create a video track and get the video track ID.
        /// Call JoinChannel [2/2] to join the channel. In ChannelMediaOptions, set customVideoTrackId to the video track ID that you want to publish, and set publishCustomVideoTrack to true.
        /// Call this method and specify videoTrackId as the video track ID set in step 2. You can then publish the corresponding custom video source in the channel. After calling this method, even if you stop pushing external video frames to the SDK, the custom video stream will still be counted as the video duration usage and incur charges. Agora recommends that you take appropriate measures based on the actual situation to avoid such video billing.
        /// If you no longer need to capture external video data, you can call DestroyCustomVideoTrack to destroy the custom video track.
        /// If you only want to use the external video data for local preview and not publish it in the channel, you can call MuteLocalVideoStream to cancel sending video stream or call UpdateChannelMediaOptions to set publishCustomVideoTrack to false.
        /// </summary>
        ///
        /// <param name="frame"> The external raw video frame to be pushed. See ExternalVideoFrame. </param>
        ///
        /// <param name="videoTrackId"> The video track ID returned by calling the CreateCustomVideoTrack method. The default value is 0. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PushVideoFrame(ExternalVideoFrame frame, uint videoTrackId = 0);

        ///
        /// @ignore
        ///
        public abstract int PushEncodedVideoImage(byte[] imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo, uint videoTrackId = 0);

        #endregion terra IMediaEngine
    };

}