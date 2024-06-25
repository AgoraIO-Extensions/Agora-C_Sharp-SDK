#define AGORA_RTC
#define AGORA_RTM
using System;
namespace Agora.Rtc
{

    ///
    /// <summary>
    /// This interface class contains multi-channel methods.
    /// 
    /// Inherited from IRtcEngine.
    /// </summary>
    ///
    public abstract class IRtcEngineEx : IRtcEngine
    {

        #region terra IRtcEngineEx
        ///
        /// <summary>
        /// Joins a channel with the connection ID.
        /// 
        /// You can call this method multiple times to join more than one channel.
        /// If you are already in a channel, you cannot rejoin it with the same user ID.
        /// If you want to join the same channel from different devices, ensure that the user IDs are different for all devices.
        /// Ensure that the App ID you use to generate the token is the same as the App ID used when creating the IRtcEngine instance.
        /// If you choose the Testing Mode (using an App ID for authentication) for your project and call this method to join a channel, you will automatically exit the channel after 24 hours.
        /// </summary>
        ///
        /// <param name="options"> The channel media options. See ChannelMediaOptions. </param>
        ///
        /// <param name="token"> The token generated on your server for authentication. If you need to join different channels at the same time or switch between channels, Agora recommends using a wildcard token so that you don't need to apply for a new token every time joining a channel. </param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int JoinChannelEx(string token, RtcConnection connection, ChannelMediaOptions options);

        ///
        /// <summary>
        /// Leaves a channel.
        /// 
        /// This method lets the user leave the channel, for example, by hanging up or exiting the call. After calling JoinChannelEx to join the channel, this method must be called to end the call before starting the next call. This method can be called whether or not a call is currently in progress. This method releases all resources related to the session. This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel. After you leave the channel, the SDK triggers the OnLeaveChannel callback. After actually leaving the channel, the local user triggers the OnLeaveChannel callback; after the user in the communication scenario and the host in the live streaming scenario leave the channel, the remote user triggers the OnUserOffline callback.
        /// If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.
        /// If you want to leave the channels that you joined by calling JoinChannel [2/2] and JoinChannelEx, call the LeaveChannel [1/2] method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LeaveChannelEx(RtcConnection connection);

        ///
        /// <summary>
        /// Sets channel options and leaves the channel.
        /// 
        /// This method lets the user leave the channel, for example, by hanging up or exiting the call. After calling JoinChannelEx to join the channel, this method must be called to end the call before starting the next call. This method can be called whether or not a call is currently in progress. This method releases all resources related to the session. This method call is asynchronous. When this method returns, it does not necessarily mean that the user has left the channel. After you leave the channel, the SDK triggers the OnLeaveChannel callback. After actually leaving the channel, the local user triggers the OnLeaveChannel callback; after the user in the communication scenario and the host in the live streaming scenario leave the channel, the remote user triggers the OnUserOffline callback.
        /// If you call Dispose immediately after calling this method, the SDK does not trigger the OnLeaveChannel callback.
        /// If you want to leave the channels that you joined by calling JoinChannel [2/2] and JoinChannelEx, call the LeaveChannel [2/2] method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="options"> The options for leaving the channel. See LeaveChannelOptions. This parameter only supports the stopMicrophoneRecording member in the LeaveChannelOptions settings; setting other members does not take effect. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int LeaveChannelEx(RtcConnection connection, LeaveChannelOptions options);

        ///
        /// <summary>
        /// Updates the channel media options after joining the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int UpdateChannelMediaOptionsEx(ChannelMediaOptions options, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the video encoder configuration.
        /// 
        /// Sets the encoder configuration for the local video. Each configuration profile corresponds to a set of video parameters, including the resolution, frame rate, and bitrate.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="config"> Video profile. See VideoEncoderConfiguration. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetVideoEncoderConfigurationEx(VideoEncoderConfiguration config, RtcConnection connection);

        ///
        /// <summary>
        /// Initializes the video view of a remote user.
        /// 
        /// This method initializes the video view of a remote stream on the local device. It affects only the video view that the local user sees. Call this method to bind the remote video stream to a video view and to set the rendering and mirror modes of the video view. The application specifies the uid of the remote video in the VideoCanvas method before the remote user joins the channel. If the remote uid is unknown to the application, set it after the application receives the OnUserJoined callback. If the Video Recording function is enabled, the Video Recording Service joins the channel as a dummy client, causing other clients to also receive the onUserJoined callback. Do not bind the dummy client to the application view because the dummy client does not send any video streams. To unbind the remote user from the view, set the view parameter to NULL. Once the remote user leaves the channel, the SDK unbinds the remote user. To update the rendering or mirror mode of the remote video view during a call, use the SetRemoteRenderModeEx method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="canvas"> The remote video view settings. See VideoCanvas. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetupRemoteVideoEx(VideoCanvas canvas, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes receiving the audio stream of a specified user.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid"> The ID of the specified user. </param>
        ///
        /// <param name="mute"> Whether to stop receiving the audio stream of the specified user: true : Stop receiving the audio stream of the specified user. false : (Default) Resume receiving the audio stream of the specified user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteAudioStreamEx(uint uid, bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes receiving the video stream of a specified user.
        /// 
        /// This method is used to stop or resume receiving the video stream of a specified user. You can call this method before or after joining a channel. If a user leaves a channel, the settings in this method become invalid.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="mute"> Whether to stop receiving the video stream of the specified user: true : Stop receiving the video stream of the specified user. false : (Default) Resume receiving the video stream of the specified user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteRemoteVideoStreamEx(uint uid, bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the video stream type to subscribe to.
        /// 
        /// The SDK will dynamically adjust the size of the corresponding video stream based on the size of the video window to save bandwidth and computing resources. The default aspect ratio of the low-quality video stream is the same as that of the high-quality video stream. According to the current aspect ratio of the high-quality video stream, the system will automatically allocate the resolution, frame rate, and bitrate of the low-quality video stream. The SDK defaults to enabling low-quality video stream adaptive mode (AUTO_SIMULCAST_STREAM) on the sending end, which means the sender does not actively send low-quality video stream. The receiver with the role of the host can initiate a low-quality video stream request by calling this method, and upon receiving the request, the sending end automatically starts sending the low-quality video stream.
        /// If the publisher has already called SetDualStreamModeEx and set mode to DISABLE_SIMULCAST_STREAM (never send low-quality video stream), calling this method will not take effect, you should call SetDualStreamModeEx again on the sending end and adjust the settings.
        /// Calling this method on the receiving end of the audience role will not take effect.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="streamType"> The video stream type, see VIDEO_STREAM_TYPE. </param>
        ///
        /// <param name="uid"> The user ID. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVideoStreamTypeEx(uint uid, VIDEO_STREAM_TYPE streamType, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes publishing the local audio stream.
        /// 
        /// This method does not affect any ongoing audio recording, because it does not disable the audio capture device. A successful call of this method triggers the OnUserMuteAudio and OnRemoteAudioStateChanged callbacks on the remote client.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="mute"> Whether to stop publishing the local audio stream: true : Stops publishing the local audio stream. false : (Default) Resumes publishing the local audio stream. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalAudioStreamEx(bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes publishing the local video stream.
        /// 
        /// A successful call of this method triggers the OnUserMuteVideo callback on the remote client.
        /// This method does not affect any ongoing video recording, because it does not disable the camera.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="mute"> Whether to stop publishing the local video stream. true : Stop publishing the local video stream. false : (Default) Publish the local video stream. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteLocalVideoStreamEx(bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the audio streams of all remote users.
        /// 
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including the ones join the channel subsequent to this call.
        /// Call this method after joining a channel.
        /// If you do not want to subscribe the audio streams of remote users before joining a channel, you can set autoSubscribeAudio as false when calling JoinChannel [2/2].
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="mute"> Whether to stop subscribing to the audio streams of all remote users: true : Stops subscribing to the audio streams of all remote users. false : (Default) Subscribes to the audio streams of all remote users by default. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteAudioStreamsEx(bool mute, RtcConnection connection);

        ///
        /// <summary>
        /// Stops or resumes subscribing to the video streams of all remote users.
        /// 
        /// After successfully calling this method, the local user stops or resumes subscribing to the audio streams of all remote users, including all subsequent users.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="mute"> Whether to stop subscribing to the video streams of all remote users. true : Stop subscribing to the video streams of all remote users. false : (Default) Subscribe to the audio streams of all remote users by default. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int MuteAllRemoteVideoStreamsEx(bool mute, RtcConnection connection);

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
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list. </param>
        ///
        /// <param name="uidList"> The user ID list of users that you do not want to subscribe to. If you want to specify the audio streams of a user that you do not want to subscribe to, add the user ID in this list. If you want to remove a user from the blocklist, you need to call the SetSubscribeAudioBlocklist method to update the user ID list; this means you only add the uid of users that you do not want to subscribe to in the new user ID list. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

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
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uidNumber"> The number of users in the user ID list. </param>
        ///
        /// <param name="uidList"> The user ID list of users that you want to subscribe to. If you want to specify the audio streams of a user for subscription, add the user ID in this list. If you want to remove a user from the allowlist, you need to call the SetSubscribeAudioAllowlist method to update the user ID list; this means you only add the uid of users that you want to subscribe to in the new user ID list. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSubscribeAudioAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);

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
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int SetSubscribeVideoBlocklistEx(uint[] uidList, int uidNumber, RtcConnection connection);

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
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int SetSubscribeVideoAllowlistEx(uint[] uidList, int uidNumber, RtcConnection connection);

        ///
        /// <summary>
        /// Options for subscribing to remote video streams.
        /// 
        /// When a remote user has enabled dual-stream mode, you can call this method to choose the option for subscribing to the video streams sent by the remote user.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="options"> The video subscription options. See VideoSubscriptionOptions. </param>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteVideoSubscriptionOptionsEx(uint uid, VideoSubscriptionOptions options, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the 2D position (the position on the horizontal plane) of the remote user's voice.
        /// 
        /// This method sets the voice position and volume of a remote user. When the local user calls this method to set the voice position of a remote user, the voice difference between the left and right channels allows the local user to track the real-time position of the remote user, creating a sense of space. This method applies to massive multiplayer online games, such as Battle Royale games.
        /// For the best voice positioning, Agora recommends using a wired headset.
        /// Call this method after joining a channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="pan">
        /// The voice position of the remote user. The value ranges from -1.0 to 1.0:
        /// -1.0: The remote voice comes from the left.
        /// 0.0: (Default) The remote voice comes from the front.
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
        public abstract int SetRemoteVoicePositionEx(uint uid, double pan, double gain, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SetRemoteUserSpatialAudioParamsEx(uint uid, SpatialAudioParams @params, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the video display mode of a specified remote user.
        /// 
        /// After initializing the video view of a remote user, you can call this method to update its rendering and mirror modes. This method affects only the video view that the local user sees.
        /// During a call, you can call this method as many times as necessary to update the display mode of the video view of a remote user.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="renderMode"> The video display mode of the remote user. See RENDER_MODE_TYPE. </param>
        ///
        /// <param name="mirrorMode"> The mirror mode of the remote user view. See VIDEO_MIRROR_MODE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRemoteRenderModeEx(uint uid, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode, RtcConnection connection);

        ///
        /// <summary>
        /// Enables loopback audio capturing.
        /// 
        /// If you enable loopback audio capturing, the output of the sound card is mixed into the audio stream sent to the other end.
        /// This method applies to the macOS and Windows only.
        /// macOS does not support loopback audio capture of the default sound card. If you need to use this function, use a virtual sound card and pass its name to the deviceName parameter. Agora recommends using AgoraALD as the virtual sound card for audio capturing.
        /// This method only supports using one sound card for audio capturing.
        /// </summary>
        ///
        /// <param name="deviceName">
        /// macOS: The device name of the virtual sound card. The default value is set to NULL, which means using AgoraALD for loopback audio capturing.
        /// Windows: The device name of the sound card. The default is set to NULL, which means the SDK uses the sound card of your device for loopback audio capturing.
        /// </param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="enabled"> Sets whether to enable loopback audio capture: true : Enable loopback audio capturing. false : (Default) Disable loopback audio capturing. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableLoopbackRecordingEx(RtcConnection connection, bool enabled, string deviceName = "");

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
        /// Adjusts the playback signal volume of a specified remote user.
        /// 
        /// You can call this method to adjust the playback volume of a specified remote user. To adjust the playback volume of different remote users, call the method as many times, once for each remote user.
        /// Call this method after joining a channel.
        /// The playback volume here refers to the mixed volume of a specified remote user.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int AdjustUserPlaybackSignalVolumeEx(uint uid, int volume, RtcConnection connection);

        ///
        /// <summary>
        /// Gets the current connection state of the SDK.
        /// 
        /// You can call this method either before or after joining a channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <returns>
        /// The current connection state. See CONNECTION_STATE_TYPE.
        /// </returns>
        ///
        public abstract CONNECTION_STATE_TYPE GetConnectionStateEx(RtcConnection connection);

        ///
        /// <summary>
        /// Enables or disables the built-in encryption.
        /// 
        /// All users in the same channel must use the same encryption mode and encryption key. After the user leaves the channel, the SDK automatically disables the built-in encryption. To enable the built-in encryption, call this method before the user joins the channel again. In scenarios requiring high security, Agora recommends calling this method to enable the built-in encryption before joining a channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="config"> Built-in encryption configurations. See EncryptionConfig. </param>
        ///
        /// <param name="enabled"> Whether to enable built-in encryption: true : Enable the built-in encryption. false : (Default) Disable the built-in encryption. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableEncryptionEx(RtcConnection connection, bool enabled, EncryptionConfig config);

        ///
        /// <summary>
        /// Creates a data stream.
        /// 
        /// Deprecated: This method is deprecated. Use CreateDataStreamEx [2/2] instead. You can call this method to create a data stream and improve the reliability and ordering of data transmission.
        /// Ensure that you set the same value for reliable and ordered.
        /// Each user can create up to five data streams during the lifecycle of IRtcEngine.
        /// The data channel allows a data delay of up to 5 seconds. If the receiver does not receive the data stream within 5 seconds, the data channel reports an error.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="streamId"> An output parameter; the ID of the data stream created. </param>
        ///
        /// <param name="reliable"> Sets whether the recipients are guaranteed to receive the data stream from the sender within five seconds: true : The recipients receive the data stream from the sender within five seconds. If the recipient does not receive the data stream within five seconds, an error is reported to the application. false : There is no guarantee that the recipients receive the data stream from the sender within five seconds. The SDK does not report errors if reception is delayed or data is lost. </param>
        ///
        /// <param name="ordered"> Sets whether the recipients receive the data stream in the sent order: true : The recipients receive the data stream in the sent order. false : There is no guarantee that the recipients receive the data stream in the sent order. </param>
        ///
        /// <returns>
        /// 0: The data stream is successfully created.
        /// &lt; 0: Fails to create the data stream.
        /// </returns>
        ///
        public abstract int CreateDataStreamEx(ref int streamId, bool reliable, bool ordered, RtcConnection connection);

        ///
        /// <summary>
        /// Creates a data stream.
        /// 
        /// Creates a data stream. Each user can create up to five data streams in a single channel. Compared with CreateDataStreamEx [1/2], this method does not support data reliability. If a data packet is not received five seconds after it was sent, the SDK directly discards the data.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int CreateDataStreamEx(ref int streamId, DataStreamConfig config, RtcConnection connection);

        ///
        /// <summary>
        /// Sends data stream messages.
        /// 
        /// After calling CreateDataStreamEx [2/2], you can call this method to send data stream messages to all users in the channel. The SDK has the following restrictions on this method:
        /// Up to 60 packets can be sent per second in a channel with each packet having a maximum size of 1 KB.
        /// Each client can send up to 30 KB of data per second.
        /// Each user can have up to five data streams simultaneously. A successful method call triggers the OnStreamMessage callback on the remote client, from which the remote user gets the stream message. A failed method call triggers the OnStreamMessageError callback on the remote client.
        /// Ensure that you call CreateDataStreamEx [2/2] to create a data channel before calling this method.
        /// This method applies only to the COMMUNICATION profile or to the hosts in the LIVE_BROADCASTING profile. If an audience in the LIVE_BROADCASTING profile calls this method, the audience may be switched to a host.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="streamId"> The data stream ID. You can get the data stream ID by calling CreateDataStreamEx [2/2]. </param>
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
        public abstract int SendStreamMessageEx(int streamId, byte[] data, uint length, RtcConnection connection);

        ///
        /// <summary>
        /// Adds a watermark image to the local video.
        /// 
        /// This method adds a PNG watermark image to the local video in the live streaming. Once the watermark image is added, all the audience in the channel (CDN audience included), and the capturing device can see and capture it. The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one. The watermark coordinates are dependent on the settings in the SetVideoEncoderConfigurationEx method:
        /// If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed landscape mode or the adaptive landscape mode, the watermark uses the landscape orientation.
        /// If the orientation mode of the encoding video (ORIENTATION_MODE) is fixed portrait mode or the adaptive portrait mode, the watermark uses the portrait orientation.
        /// When setting the watermark position, the region must be less than the dimensions set in the SetVideoEncoderConfigurationEx method; otherwise, the watermark image will be cropped.
        /// Ensure that you have called EnableVideo before calling this method.
        /// This method supports adding a watermark image in the PNG file format only. Supported pixel formats of the PNG image are RGBA, RGB, Palette, Gray, and Alpha_gray.
        /// If the dimensions of the PNG image differ from your settings in this method, the image will be cropped or zoomed to conform to your settings.
        /// If you have enabled the local video preview by calling the StartPreview [2/2] method, you can use the visibleInPreview member to set whether or not the watermark is visible in the preview.
        /// If you have enabled the mirror mode for the local video, the watermark on the local video is also mirrored. To avoid mirroring the watermark, Agora recommends that you do not use the mirror and watermark functions for the local video at the same time. You can implement the watermark function in your application layer.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="options"> The options of the watermark image to be added. See WatermarkOptions. </param>
        ///
        /// <param name="watermarkUrl"> The local file path of the watermark image to be added. This method supports adding a watermark image from the local absolute or relative file path. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AddVideoWatermarkEx(string watermarkUrl, WatermarkOptions options, RtcConnection connection);

        ///
        /// <summary>
        /// Removes the watermark image from the video stream.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ClearVideoWatermarkEx(RtcConnection connection);

        ///
        /// <summary>
        /// Agora supports reporting and analyzing customized messages.
        /// 
        /// Agora supports reporting and analyzing customized messages. This function is in the beta stage with a free trial. The ability provided in its beta test version is reporting a maximum of 10 message pieces within 6 seconds, with each message piece not exceeding 256 bytes and each string not exceeding 100 bytes. To try out this function, contact and discuss the format of customized messages with us.
        /// </summary>
        ///
        public abstract int SendCustomReportMessageEx(string id, string category, string @event, string label, int value, RtcConnection connection);

        ///
        /// <summary>
        /// Enables the reporting of users' volume indication.
        /// 
        /// This method enables the SDK to regularly report the volume information to the app of the local user who sends a stream and remote users (three users at most) whose instantaneous volumes are the highest. Once you call this method and users send streams in the channel, the SDK triggers the OnAudioVolumeIndication callback at the time interval set in this method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="reportVad"> true : Enables the voice activity detection of the local user. Once it is enabled, the vad parameter of the OnAudioVolumeIndication callback reports the voice activity status of the local user. false : (Default) Disables the voice activity detection of the local user. Once it is disabled, the vad parameter of the OnAudioVolumeIndication callback does not report the voice activity status of the local user, except for the scenario where the engine automatically detects the voice activity of the local user. </param>
        ///
        /// <param name="smooth"> The smoothing factor that sets the sensitivity of the audio volume indicator. The value ranges between 0 and 10. The recommended value is 3. The greater the value, the more sensitive the indicator. </param>
        ///
        /// <param name="interval">
        /// Sets the time interval between two consecutive volume indications:
        /// ≤ 0: Disables the volume indication.
        /// > 0: Time interval (ms) between two consecutive volume indications. Ensure this parameter is set to a value greater than 10, otherwise you will not receive the OnAudioVolumeIndication callback. Agora recommends that this value is set as greater than 100.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableAudioVolumeIndicationEx(int interval, int smooth, bool reportVad, RtcConnection connection);

        ///
        /// <summary>
        /// Starts pushing media streams to a CDN without transcoding.
        /// 
        /// Call this method after joining a channel.
        /// Only hosts in the LIVE_BROADCASTING profile can call this method.
        /// If you want to retry pushing streams after a failed push, make sure to call StopRtmpStream first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push. Agora recommends that you use the server-side Media Push function. You can call this method to push an audio or video stream to the specified CDN address. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times. After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int StartRtmpStreamWithoutTranscodingEx(string url, RtcConnection connection);

        ///
        /// <summary>
        /// Starts Media Push and sets the transcoding configuration.
        /// 
        /// Agora recommends that you use the server-side Media Push function. You can call this method to push a live audio-and-video stream to the specified CDN address and set the transcoding configuration. This method can push media streams to only one CDN address at a time, so if you need to push streams to multiple addresses, call this method multiple times. After you call this method, the SDK triggers the OnRtmpStreamingStateChanged callback on the local client to report the state of the streaming.
        /// Ensure that you enable the Media Push service before using this function.
        /// Call this method after joining a channel.
        /// Only hosts in the LIVE_BROADCASTING profile can call this method.
        /// If you want to retry pushing streams after a failed push, make sure to call StopRtmpStreamEx first, then call this method to retry pushing streams; otherwise, the SDK returns the same error code as the last failed push.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="transcoding"> The transcoding configuration for Media Push. See LiveTranscoding. </param>
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
        public abstract int StartRtmpStreamWithTranscodingEx(string url, LiveTranscoding transcoding, RtcConnection connection);

        ///
        /// <summary>
        /// Updates the transcoding configuration.
        /// 
        /// Agora recommends that you use the server-side Media Push function. After you start pushing media streams to CDN with transcoding, you can dynamically update the transcoding configuration according to the scenario. The SDK triggers the OnTranscodingUpdated callback after the transcoding configuration is updated.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="transcoding"> The transcoding configuration for Media Push. See LiveTranscoding. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UpdateRtmpTranscodingEx(LiveTranscoding transcoding, RtcConnection connection);

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
        public abstract int StopRtmpStreamEx(string url, RtcConnection connection);

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
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int StartOrUpdateChannelMediaRelayEx(ChannelMediaRelayConfiguration configuration, RtcConnection connection);

        ///
        /// <summary>
        /// Stops the media stream relay. Once the relay stops, the host quits all the target channels.
        /// 
        /// After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged callback. If the callback reports RELAY_STATE_IDLE (0) and RELAY_OK (0), the host successfully stops the relay. If the method call fails, the SDK triggers the OnChannelMediaRelayStateChanged callback with the RELAY_ERROR_SERVER_NO_RESPONSE (2) or RELAY_ERROR_SERVER_CONNECTION_LOST (8) status code. You can call the LeaveChannel [2/2] method to leave the channel, and the media stream relay automatically stops.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StopChannelMediaRelayEx(RtcConnection connection);

        ///
        /// <summary>
        /// Pauses the media stream relay to all target channels.
        /// 
        /// After the cross-channel media stream relay starts, you can call this method to pause relaying media streams to all target channels; after the pause, if you want to resume the relay, call ResumeAllChannelMediaRelay. Call this method after StartOrUpdateChannelMediaRelayEx.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PauseAllChannelMediaRelayEx(RtcConnection connection);

        ///
        /// <summary>
        /// Resumes the media stream relay to all target channels.
        /// 
        /// After calling the PauseAllChannelMediaRelayEx method, you can call this method to resume relaying media streams to all destination channels. Call this method after PauseAllChannelMediaRelayEx.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int ResumeAllChannelMediaRelayEx(RtcConnection connection);

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
        /// Enables or disables dual-stream mode on the sender side.
        /// 
        /// After you enable dual-stream mode, you can call SetRemoteVideoStreamType to choose to receive either the high-quality video stream or the low-quality video stream on the subscriber side. You can call this method to enable or disable the dual-stream mode on the publisher side. Dual streams are a pairing of a high-quality video stream and a low-quality video stream:
        /// High-quality video stream: High bitrate, high resolution.
        /// Low-quality video stream: Low bitrate, low resolution. Deprecated: This method is deprecated as of v4.2.0. Use SetDualStreamModeEx instead. This method is applicable to all types of streams from the sender, including but not limited to video streams collected from cameras, screen sharing streams, and custom-collected video streams.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="streamConfig"> The configuration of the low-quality video stream. See SimulcastStreamConfig. When setting mode to DISABLE_SIMULCAST_STREAM, setting streamConfig will not take effect. </param>
        ///
        /// <param name="enabled"> Whether to enable dual-stream mode: true : Enable dual-stream mode. false : (Default) Disable dual-stream mode. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        [Obsolete("v4.2.0. This method is deprecated. Use setDualStreamModeEx instead")]
        public abstract int EnableDualStreamModeEx(bool enabled, SimulcastStreamConfig streamConfig, RtcConnection connection);

        ///
        /// <summary>
        /// Sets the dual-stream mode on the sender side.
        /// 
        /// The SDK defaults to enabling low-quality video stream adaptive mode (AUTO_SIMULCAST_STREAM) on the sending end, which means the sender does not actively send low-quality video stream. The receiver with the role of the host can initiate a low-quality video stream request by calling SetRemoteVideoStreamTypeEx, and upon receiving the request, the sending end automatically starts sending the low-quality video stream.
        /// If you want to modify this behavior, you can call this method and set mode to DISABLE_SIMULCAST_STREAM (never send low-quality video streams) or ENABLE_SIMULCAST_STREAM (always send low-quality video streams).
        /// If you want to restore the default behavior after making changes, you can call this method again with mode set to AUTO_SIMULCAST_STREAM. The difference and connection between this method and EnableDualStreamModeEx is as follows:
        /// When calling this method and setting mode to DISABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamModeEx (false).
        /// When calling this method and setting mode to ENABLE_SIMULCAST_STREAM, it has the same effect as EnableDualStreamModeEx (true).
        /// Both methods can be called before and after joining a channel. If both methods are used, the settings in the method called later takes precedence.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
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
        public abstract int SetDualStreamModeEx(SIMULCAST_STREAM_MODE mode, SimulcastStreamConfig streamConfig, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SetSimulcastConfigEx(SimulcastConfig simulcastConfig, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SetHighPriorityUserListEx(uint[] uidList, int uidNum, STREAM_FALLBACK_OPTIONS option, RtcConnection connection);

        ///
        /// <summary>
        /// Takes a snapshot of a video stream.
        /// 
        /// The method is asynchronous, and the SDK has not taken the snapshot when the method call returns. After a successful method call, the SDK triggers the OnSnapshotTaken callback to report whether the snapshot is successfully taken, as well as the details for that snapshot. This method takes a snapshot of a video stream from the specified user, generates a JPG image, and saves it to the specified path.
        /// Call this method after the JoinChannelEx method.
        /// When used for local video snapshots, this method takes a snapshot for the video streams specified in ChannelMediaOptions.
        /// If the user's video has been preprocessed, for example, watermarked or beautified, the resulting snapshot includes the pre-processing effect.
        /// </summary>
        ///
        /// <param name="filePath">
        /// The local path (including filename extensions) of the snapshot. For example:
        /// Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.jpg
        /// iOS: /App Sandbox/Library/Caches/example.jpg
        /// macOS: ～/Library/Logs/example.jpg
        /// Android: /storage/emulated/0/Android/data/<package name>/files/example.jpg Ensure that the path you specify exists and is writable.
        /// </param>
        ///
        /// <param name="uid"> The user ID. Set uid as 0 if you want to take a snapshot of the local user's video. </param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int TakeSnapshotEx(RtcConnection connection, uint uid, string filePath);

        ///
        /// <summary>
        /// Enables or disables video screenshot and upload.
        /// 
        /// This method can take screenshots for multiple video streams and upload them. When video screenshot and upload function is enabled, the SDK takes screenshots and uploads videos sent by local users based on the type and frequency of the module you set in ContentInspectConfig. After video screenshot and upload, the Agora server sends the callback notification to your app server in HTTPS requests and sends all screenshots to the third-party cloud storage service. Before calling this method, ensure that you have contacted to activate the video screenshot upload service.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="config"> Configuration of video screenshot and upload. See ContentInspectConfig. When the video moderation module is set to video moderation via Agora self-developed extension(CONTENT_INSPECT_SUPERVISION), the video screenshot and upload dynamic library libagora_content_inspect_extension.dll is required. Deleting this library disables the screenshot and upload feature. </param>
        ///
        /// <param name="enabled"> Whether to enable video screenshot and upload : true : Enables video screenshot and upload. false : Disables video screenshot and upload. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableContentInspectEx(bool enabled, ContentInspectConfig config, RtcConnection connection);

        ///
        /// <summary>
        /// Enables tracing the video frame rendering process.
        /// 
        /// By default, the SDK starts tracing the video rendering event automatically when the local user successfully joins the channel. You can call this method at an appropriate time according to the actual application scenario to customize the tracing process.
        /// After the local user leaves the current channel, the SDK automatically resets the time point to the next time when the user successfully joins the channel. The SDK starts tracing the rendering status of the video frames in the channel from the moment this method is successfully called and reports information about the event through the OnVideoRenderingTracingResult callback.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int StartMediaRenderingTracingEx(RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SetParametersEx(RtcConnection connection, string parameters);

        ///
        /// <summary>
        /// Gets the call ID with the connection ID.
        /// 
        /// Call this method after joining a channel. When a user joins a channel on a client, a callId is generated to identify the call from the client. You can call this method to get the callId parameter, and pass it in when calling methods such as Rate and Complain.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="callId"> Output parameter, the current call ID. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetCallIdEx(ref string callId, RtcConnection connection);

        ///
        /// @ignore
        ///
        public abstract int SendAudioMetadataEx(RtcConnection connection, byte[] metadata, ulong length);
        #endregion terra IRtcEngineEx

        ///
        /// @ignore
        ///
        public abstract int SetParametersEx(RtcConnection connection, string key, object value);
    };

}