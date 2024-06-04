using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The SDK uses the IRtcEngineEventHandler interface to send event notifications to your app. Your app can get those notifications through methods that inherit this interface.
    /// 
    /// All methods in this interface have default (empty) implementation. You can choose to inherit events related to your app scenario.
    ///  In the callbacks, avoid implementing time-consuming tasks or calling APIs that may cause thread blocking (such as sendMessage). Otherwise, the SDK may not work properly.
    ///  The SDK no longer catches exceptions in the code logic that developers implement themselves in IRtcEngineEventHandler class. You need to handle this exception yourself, otherwise the app may crash when the exception occurs.
    /// </summary>
    ///
    public abstract class IRtcEngineEventHandler
    {

        #region terra IRtcEngineEventHandler
        ///
        /// <summary>
        /// Reports the proxy connection state.
        /// 
        /// You can use this callback to listen for the state of the SDK connecting to a proxy. For example, when a user calls SetCloudProxy and joins a channel successfully, the SDK triggers this callback to report the user ID, the proxy type connected, and the time elapsed fromthe user calling JoinChannel [2/2] until this callback is triggered.
        /// </summary>
        ///
        /// <param name="channel"> The channel name. </param>
        ///
        /// <param name="uid"> The user ID. </param>
        ///
        /// <param name="proxyType"> The proxy type connected. See PROXY_TYPE. </param>
        ///
        /// <param name="localProxyIp"> Reserved for future use. </param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the user calling JoinChannel [2/2] until this callback is triggered. </param>
        ///
        public virtual void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Reports an error during SDK runtime.
        /// 
        /// This callback indicates that an error (concerning network or media) occurs during SDK runtime. In most cases, the SDK cannot fix the issue and resume running. The SDK requires the app to take action or informs the user about the issue.
        /// </summary>
        ///
        /// <param name="err"> Error code. See ERROR_CODE_TYPE. </param>
        ///
        /// <param name="msg"> The error message. </param>
        ///
        public virtual void OnError(int err, string msg)
        {
        }

        ///
        /// <summary>
        /// Reports the last mile network probe result.
        /// 
        /// The SDK triggers this callback within 30 seconds after the app calls StartLastmileProbeTest.
        /// </summary>
        ///
        /// <param name="result"> The uplink and downlink last-mile network probe test result. See LastmileProbeResult. </param>
        ///
        public virtual void OnLastmileProbeResult(LastmileProbeResult result)
        {
        }

        ///
        /// <summary>
        /// Occurs when the audio device state changes.
        /// 
        /// This callback notifies the application that the system's audio device state is changed. For example, a headset is unplugged from the device. This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> The device ID. </param>
        ///
        /// <param name="deviceType"> The device type. See MEDIA_DEVICE_TYPE. </param>
        ///
        /// <param name="deviceState"> The device state. See MEDIA_DEVICE_STATE_TYPE. </param>
        ///
        public virtual void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        ///
        /// <summary>
        /// Reports the playback progress of a music file.
        /// 
        /// After you called the StartAudioMixing [2/2] method to play a music file, the SDK triggers this callback every two seconds to report the playback progress.
        /// </summary>
        ///
        /// <param name="position"> The playback progress (ms). </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public virtual void OnAudioMixingPositionChanged(long position)
        {
        }

        ///
        /// <summary>
        /// Occurs when the playback of the local music file finishes.
        /// 
        /// Deprecated: Use OnAudioMixingStateChanged instead. After you call StartAudioMixing [2/2] to play a local music file, this callback occurs when the playback finishes. If the call of StartAudioMixing [2/2] fails, the error code WARN_AUDIO_MIXING_OPEN_ERROR is returned.
        /// </summary>
        ///
        public virtual void OnAudioMixingFinished()
        {
        }

        ///
        /// <summary>
        /// Occurs when the playback of the local music file finishes.
        /// 
        /// This callback occurs when the local audio effect file finishes playing.
        /// </summary>
        ///
        /// <param name="soundId"> The ID of the audio effect. The ID of each audio effect file is unique. </param>
        ///
        public virtual void OnAudioEffectFinished(int soundId)
        {
        }

        ///
        /// <summary>
        /// Occurs when the video device state changes.
        /// 
        /// This callback reports the change of system video devices, such as being unplugged or removed. On a Windows device with an external camera for video capturing, the video disables once the external camera is unplugged. This callback is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> The device ID. </param>
        ///
        /// <param name="deviceType"> Media device types. See MEDIA_DEVICE_TYPE. </param>
        ///
        /// <param name="deviceState"> Media device states. See MEDIA_DEVICE_STATE_TYPE. </param>
        ///
        public virtual void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        ///
        /// <summary>
        /// Occurs when the uplink network information changes.
        /// 
        /// The SDK triggers this callback when the uplink network information changes. This callback only applies to scenarios where you push externally encoded video data in H.264 format to the SDK.
        /// </summary>
        ///
        /// <param name="info"> The uplink network information. See UplinkNetworkInfo. </param>
        ///
        public virtual void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
        }

        ///
        /// <summary>
        /// Reports the last-mile network quality of the local user.
        /// 
        /// This callback reports the last-mile network conditions of the local user before the user joins the channel. Last mile refers to the connection between the local device and Agora's edge server. Before the user joins the channel, this callback is triggered by the SDK once StartLastmileProbeTest is called and reports the last-mile network conditions of the local user.
        /// </summary>
        ///
        /// <param name="quality"> The last-mile network quality. QUALITY_UNKNOWN (0): The quality is unknown. QUALITY_EXCELLENT (1): The quality is excellent. QUALITY_GOOD (2): The network quality seems excellent, but the bitrate can be slightly lower than excellent. QUALITY_POOR (3): Users can feel the communication is slightly impaired. QUALITY_BAD (4): Users cannot communicate smoothly. QUALITY_VBAD (5): The quality is so bad that users can barely communicate. QUALITY_DOWN (6): The network is down, and users cannot communicate at all. See QUALITY_TYPE. </param>
        ///
        public virtual void OnLastmileQuality(int quality)
        {
        }

        ///
        /// <summary>
        /// Occurs when the first local video frame is displayed on the local video view.
        /// 
        /// The SDK triggers this callback when the first local video frame is displayed on the local video view.
        /// </summary>
        ///
        /// <param name="source"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <param name="width"> The width (px) of the first local video frame. </param>
        ///
        /// <param name="height"> The height (px) of the first local video frame. </param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [1/2] or JoinChannel [2/2] to join the channel to when the SDK triggers this callback. If StartPreview [1/2] / StartPreview [2/2] is called before joining the channel, this parameter indicates the time elapsed from calling StartPreview [1/2] or StartPreview [2/2] to when this event occurred. </param>
        ///
        public virtual void OnFirstLocalVideoFrame(VIDEO_SOURCE_TYPE source, int width, int height, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when the local video stream state changes.
        /// 
        /// When the status of the local video changes, the SDK triggers this callback to report the current local video state and the reason for the state change.
        /// </summary>
        ///
        /// <param name="source"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <param name="state"> The state of the local video, see LOCAL_VIDEO_STREAM_STATE. </param>
        ///
        /// <param name="reason"> The reasons for changes in local video state. See LOCAL_VIDEO_STREAM_REASON. </param>
        ///
        public virtual void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
        {
        }

        ///
        /// <summary>
        /// Occurs when the camera turns on and is ready to capture the video.
        /// 
        /// Deprecated: Use LOCAL_VIDEO_STREAM_STATE_CAPTURING (1) in OnLocalVideoStateChanged instead. This callback indicates that the camera has been successfully turned on and you can start to capture video.
        /// </summary>
        ///
        public virtual void OnCameraReady()
        {
        }

        ///
        /// <summary>
        /// Occurs when the camera focus area changes.
        /// 
        /// The SDK triggers this callback when the local user changes the camera focus position by calling SetCameraFocusPositionInPreview. This callback is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="x"> The x-coordinate of the changed camera focus area. </param>
        ///
        /// <param name="y"> The y-coordinate of the changed camera focus area. </param>
        ///
        /// <param name="width"> The width of the changed camera focus area. </param>
        ///
        /// <param name="height"> The height of the changed camera focus area. </param>
        ///
        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
        }

        ///
        /// <summary>
        /// Occurs when the camera exposure area changes.
        /// </summary>
        ///
        /// <param name="x"> The x coordinate of the changed camera exposure area. </param>
        ///
        /// <param name="y"> The y coordinate of the changed camera exposure area. </param>
        ///
        /// <param name="width"> The width of the changed camera exposure area. </param>
        ///
        /// <param name="height"> The height of the changed exposure area. </param>
        ///
        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
        }

        ///
        /// <summary>
        /// Reports the face detection result of the local user.
        /// 
        /// Once you enable face detection by calling EnableFaceDetection (true), you can get the following information on the local user in real-time:
        /// The width and height of the local video.
        /// The position of the human face in the local view.
        /// The distance between the human face and the screen. This value is based on the fitting calculation of the local video size and the position of the human face.
        /// This callback is for Android and iOS only.
        /// When it is detected that the face in front of the camera disappears, the callback will be triggered immediately. When no human face is detected, the frequency of this callback to be triggered wil be decreased to reduce power consumption on the local device.
        /// The SDK stops triggering this callback when a human face is in close proximity to the screen.
        /// </summary>
        ///
        /// <param name="imageWidth"> The width (px) of the video image captured by the local camera. </param>
        ///
        /// <param name="imageHeight"> The height (px) of the video image captured by the local camera. </param>
        ///
        /// <param name="vecRectangle"> The information of the detected human face. See Rectangle. </param>
        ///
        /// <param name="vecDistance"> The distance between the human face and the device screen (cm). </param>
        ///
        /// <param name="numFaces"> The number of faces detected. If the value is 0, it means that no human face is detected. </param>
        ///
        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle[] vecRectangle, int[] vecDistance, int numFaces)
        {
        }

        ///
        /// <summary>
        /// Occurs when the video stops playing.
        /// 
        /// Deprecated: Use LOCAL_VIDEO_STREAM_STATE_STOPPED (0) in the OnLocalVideoStateChanged callback instead. The application can use this callback to change the configuration of the view (for example, displaying other pictures in the view) after the video stops playing.
        /// </summary>
        ///
        public virtual void OnVideoStopped()
        {
        }

        ///
        /// <summary>
        /// Occurs when the playback state of the music file changes.
        /// 
        /// This callback occurs when the playback state of the music file changes, and reports the current state and error code.
        /// </summary>
        ///
        /// <param name="state"> The playback state of the music file. See AUDIO_MIXING_STATE_TYPE. </param>
        ///
        /// <param name="reason"> Error code. See AUDIO_MIXING_REASON_TYPE. </param>
        ///
        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
        }

        ///
        /// <summary>
        /// Occurs when the state of virtual metronome changes.
        /// 
        /// When the state of the virtual metronome changes, the SDK triggers this callback to report the current state of the virtual metronome. This callback indicates the state of the local audio stream and enables you to troubleshoot issues when audio exceptions occur. This callback is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="state"> For the current virtual metronome status, see RHYTHM_PLAYER_STATE_TYPE. </param>
        ///
        /// <param name="errorCode"> For the error codes and error messages related to virtual metronome errors, see RHYTHM_PLAYER_REASON. </param>
        ///
        public virtual void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_REASON reason)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
        }

        ///
        /// <summary>
        /// Reports the volume change of the audio device or app.
        /// 
        /// Occurs when the volume on the playback device, audio capture device, or the volume of the app changes. This callback is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceType"> The device type. See MEDIA_DEVICE_TYPE. </param>
        ///
        /// <param name="volume"> The volume value. The range is [0, 255]. </param>
        ///
        /// <param name="muted"> Whether the audio device is muted: true : The audio device is muted. false : The audio device is not muted. </param>
        ///
        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
        }

        ///
        /// <summary>
        /// Occurs when the state of Media Push changes.
        /// 
        /// When the state of Media Push changes, the SDK triggers this callback and reports the URL address and the current state of the Media Push. This callback indicates the state of the Media Push. When exceptions occur, you can troubleshoot issues by referring to the detailed error descriptions in the error code parameter.
        /// </summary>
        ///
        /// <param name="url"> The URL address where the state of the Media Push changes. </param>
        ///
        /// <param name="state"> The current state of the Media Push. See RTMP_STREAM_PUBLISH_STATE. </param>
        ///
        /// <param name="reason"> Reasons for the changes in the Media Push status. See RTMP_STREAM_PUBLISH_REASON. </param>
        ///
        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_REASON reason)
        {
        }

        ///
        /// <summary>
        /// Reports events during the Media Push.
        /// </summary>
        ///
        /// <param name="url"> The URL for Media Push. </param>
        ///
        /// <param name="eventCode"> The event code of Media Push. See RTMP_STREAMING_EVENT. </param>
        ///
        public virtual void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        ///
        /// <summary>
        /// Occurs when the publisher's transcoding is updated.
        /// 
        /// When the LiveTranscoding class in the StartRtmpStreamWithTranscoding method updates, the SDK triggers the OnTranscodingUpdated callback to report the update information. If you call the StartRtmpStreamWithTranscoding method to set the LiveTranscoding class for the first time, the SDK does not trigger this callback.
        /// </summary>
        ///
        public virtual void OnTranscodingUpdated()
        {
        }

        ///
        /// <summary>
        /// Occurs when the local audio route changes.
        /// 
        /// This method is for Android, iOS and macOS only.
        /// </summary>
        ///
        /// <param name="routing"> The current audio routing. See AudioRoute. </param>
        ///
        public virtual void OnAudioRoutingChanged(int routing)
        {
        }

        ///
        /// <summary>
        /// Occurs when the state of the media stream relay changes.
        /// 
        /// The SDK returns the state of the current media relay with any error message.
        /// </summary>
        ///
        /// <param name="state"> The state code. See CHANNEL_MEDIA_RELAY_STATE. </param>
        ///
        /// <param name="code"> The error code of the channel media relay. See CHANNEL_MEDIA_RELAY_ERROR. </param>
        ///
        public virtual void OnChannelMediaRelayStateChanged(int state, int code)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
        }

        ///
        /// <summary>
        /// Occurs when the remote media stream falls back to the audio-only stream due to poor network conditions or switches back to the video stream after the network conditions improve.
        /// 
        /// If you call SetRemoteSubscribeFallbackOption and set option to STREAM_FALLBACK_OPTION_AUDIO_ONLY, the SDK triggers this callback in the following situations:
        /// The downstream network condition is poor, and the subscribed video stream is downgraded to audio-only stream.
        /// The downstream network condition has improved, and the subscribed stream has been restored to video stream. Once the remote media stream switches to the low-quality video stream due to weak network conditions, you can monitor the stream switch between a high-quality and low-quality stream in the OnRemoteVideoStats callback.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="isFallbackOrRecover"> true : The subscribed media stream falls back to audio-only due to poor network conditions. false : The subscribed media stream switches back to the video stream after the network conditions improve. </param>
        ///
        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
        }

        ///
        /// <summary>
        /// Occurs when the SDK cannot get the device permission.
        /// 
        /// When the SDK fails to get the device permission, the SDK triggers this callback to report which device permission cannot be got.
        /// </summary>
        ///
        /// <param name="permissionType"> The type of the device permission. See PERMISSION_TYPE. </param>
        ///
        public virtual void OnPermissionError(PERMISSION_TYPE permissionType)
        {
        }

        ///
        /// <summary>
        /// Occurs when the local user registers a user account.
        /// 
        /// After the local user successfully calls RegisterLocalUserAccount to register the user account or calls JoinChannelWithUserAccount [2/2] to join a channel, the SDK triggers the callback and informs the local user's UID and User Account.
        /// </summary>
        ///
        /// <param name="uid"> The ID of the local user. </param>
        ///
        /// <param name="userAccount"> The user account of the local user. </param>
        ///
        public virtual void OnLocalUserRegistered(uint uid, string userAccount)
        {
        }

        ///
        /// <summary>
        /// Occurs when the SDK gets the user ID and user account of the remote user.
        /// 
        /// After a remote user joins the channel, the SDK gets the UID and user account of the remote user, caches them in a mapping table object, and triggers this callback on the local client.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="info"> The UserInfo object that contains the user ID and user account of the remote user. See UserInfo for details. </param>
        ///
        public virtual void OnUserInfoUpdated(uint uid, UserInfo info)
        {
        }

        ///
        /// <summary>
        /// Occurs when there's an error during the local video mixing.
        /// 
        /// When you fail to call StartLocalVideoTranscoder or UpdateLocalTranscoderConfiguration, the SDK triggers this callback to report the reason.
        /// </summary>
        ///
        /// <param name="stream"> The video streams that cannot be mixed during video mixing. See TranscodingVideoStream. </param>
        ///
        /// <param name="error"> The reason for local video mixing error. See VIDEO_TRANSCODER_ERROR. </param>
        ///
        public virtual void OnLocalVideoTranscoderError(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
        }

        ///
        /// <summary>
        /// Occurs when the audio subscribing state changes.
        /// </summary>
        ///
        /// <param name="channel"> The channel name. </param>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="oldState"> The previous subscribing status. See STREAM_SUBSCRIBE_STATE. </param>
        ///
        /// <param name="newState"> The current subscribing status. See STREAM_SUBSCRIBE_STATE. </param>
        ///
        /// <param name="elapseSinceLastState"> The time elapsed (ms) from the previous state to the current state. </param>
        ///
        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        ///
        /// <summary>
        /// Occurs when the video subscribing state changes.
        /// </summary>
        ///
        /// <param name="channel"> The channel name. </param>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="oldState"> The previous subscribing status. See STREAM_SUBSCRIBE_STATE. </param>
        ///
        /// <param name="newState"> The current subscribing status. See STREAM_SUBSCRIBE_STATE. </param>
        ///
        /// <param name="elapseSinceLastState"> The time elapsed (ms) from the previous state to the current state. </param>
        ///
        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        ///
        /// <summary>
        /// Occurs when the audio publishing state changes.
        /// </summary>
        ///
        /// <param name="channel"> The channel name. </param>
        ///
        /// <param name="oldState"> The previous publishing state. See STREAM_PUBLISH_STATE. </param>
        ///
        /// <param name="newState"> The current publishing stat. See STREAM_PUBLISH_STATE. </param>
        ///
        /// <param name="elapseSinceLastState"> The time elapsed (ms) from the previous state to the current state. </param>
        ///
        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        ///
        /// <summary>
        /// Occurs when the video publishing state changes.
        /// </summary>
        ///
        /// <param name="channel"> The channel name. </param>
        ///
        /// <param name="source"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <param name="oldState"> The previous publishing state. See STREAM_PUBLISH_STATE. </param>
        ///
        /// <param name="newState"> The current publishing stat. See STREAM_PUBLISH_STATE. </param>
        ///
        /// <param name="elapseSinceLastState"> The time elapsed (ms) from the previous state to the current state. </param>
        ///
        public virtual void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        ///
        /// <summary>
        /// The event callback of the extension.
        /// 
        /// To listen for events while the extension is running, you need to register this callback.
        /// </summary>
        ///
        /// <param name="value"> The value of the extension key. </param>
        ///
        /// <param name="key"> The key of the extension. </param>
        ///
        /// <param name="provider"> The name of the extension provider. </param>
        ///
        /// <param name="extension"> The name of the extension. </param>
        ///
        public virtual void OnExtensionEvent(string provider, string extension, string key, string value)
        {
        }

        ///
        /// <summary>
        /// Occurs when the extension is enabled.
        /// 
        /// The extension triggers this callback after it is successfully enabled.
        /// </summary>
        ///
        /// <param name="provider"> The name of the extension provider. </param>
        ///
        /// <param name="extension"> The name of the extension. </param>
        ///
        public virtual void OnExtensionStarted(string provider, string extension)
        {
        }

        ///
        /// <summary>
        /// Occurs when the extension is disabled.
        /// 
        /// The extension triggers this callback after it is successfully destroyed.
        /// </summary>
        ///
        /// <param name="extension"> The name of the extension. </param>
        ///
        /// <param name="provider"> The name of the extension provider. </param>
        ///
        public virtual void OnExtensionStopped(string provider, string extension)
        {
        }

        ///
        /// <summary>
        /// Occurs when the extension runs incorrectly.
        /// 
        /// In case of extension enabling failure or runtime errors, the extension triggers this callback and reports the error code along with the reasons.
        /// </summary>
        ///
        /// <param name="provider"> The name of the extension provider. </param>
        ///
        /// <param name="extension"> The name of the extension. </param>
        ///
        /// <param name="error"> Error code. For details, see the extension documentation provided by the extension provider. </param>
        ///
        /// <param name="message"> Reason. For details, see the extension documentation provided by the extension provider. </param>
        ///
        public virtual void OnExtensionError(string provider, string extension, int error, string message)
        {
        }

        ///
        /// <summary>
        /// Occurs when a user joins a channel.
        /// 
        /// This callback notifies the application that a user joins a specified channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback. </param>
        ///
        public virtual void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when a user rejoins the channel.
        /// 
        /// When a user loses connection with the server because of network problems, the SDK automatically tries to reconnect and triggers this callback upon reconnection.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback. </param>
        ///
        public virtual void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Reports the statistics of the audio stream sent by each remote user.
        /// 
        /// Deprecated: Use OnRemoteAudioStats instead. The SDK triggers this callback once every two seconds to report the audio quality of each remote user who is sending an audio stream. If a channel has multiple users sending audio streams, the SDK triggers this callback as many times.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The user ID of the remote user sending the audio stream. </param>
        ///
        /// <param name="quality"> Audio quality of the user. See QUALITY_TYPE. </param>
        ///
        /// <param name="delay"> The network delay (ms) from the sender to the receiver, including the delay caused by audio sampling pre-processing, network transmission, and network jitter buffering. </param>
        ///
        /// <param name="lost"> The packet loss rate (%) of the audio packet sent from the remote user to the receiver. </param>
        ///
        public virtual void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
        }

        ///
        /// <summary>
        /// Reports the volume information of users.
        /// 
        /// By default, this callback is disabled. You can enable it by calling EnableAudioVolumeIndication. Once this callback is enabled and users send streams in the channel, the SDK triggers the OnAudioVolumeIndication callback according to the time interval set in EnableAudioVolumeIndication. The SDK triggers two independent OnAudioVolumeIndication callbacks simultaneously, which separately report the volume information of the local user who sends a stream and the remote users (up to three) whose instantaneous volume is the highest. Once this callback is enabled, if the local user calls the MuteLocalAudioStream method to mute, the SDK continues to report the volume indication of the local user. If a remote user whose volume is one of the three highest in the channel stops publishing the audio stream for 20 seconds, the callback excludes this user's information; if all remote users stop publishing audio streams for 20 seconds, the SDK stops triggering the callback for remote users.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="speakers"> The volume information of the users. See AudioVolumeInfo. An empty speakers array in the callback indicates that no remote user is in the channel or is sending a stream. </param>
        ///
        /// <param name="speakerNumber">
        /// The total number of users.
        /// In the callback for the local user, if the local user is sending streams, the value of speakerNumber is 1.
        /// In the callback for remote users, the value range of speakerNumber is [0,3]. If the number of remote users who send streams is greater than or equal to three, the value of speakerNumber is 3.
        /// </param>
        ///
        /// <param name="totalVolume">
        /// The volume of the speaker. The value range is [0,255].
        /// In the callback for the local user, totalVolume is the volume of the local user who sends a stream. In the callback for remote users, totalVolume is the sum of the volume of all remote users (up to three) whose instantaneous volume is the highest.
        /// </param>
        ///
        public virtual void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
        }

        ///
        /// <summary>
        /// Occurs when a user leaves a channel.
        /// 
        /// This callback notifies the app that the user leaves the channel by calling LeaveChannel [2/2]. From this callback, the app can get information such as the call duration and statistics.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="stats"> The statistics of the call. See RtcStats. </param>
        ///
        public virtual void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
        }

        ///
        /// <summary>
        /// Reports the statistics about the current call.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="stats"> Statistics of the RTC engine. See RtcStats. </param>
        ///
        public virtual void OnRtcStats(RtcConnection connection, RtcStats stats)
        {
        }

        ///
        /// <summary>
        /// Reports the last mile network quality of each user in the channel.
        /// 
        /// This callback reports the last mile network conditions of each user in the channel. Last mile refers to the connection between the local device and Agora's edge server. The SDK triggers this callback once every two seconds. If a channel includes multiple users, the SDK triggers this callback as many times. txQuality is UNKNOWN when the user is not sending a stream; rxQuality is UNKNOWN when the user is not receiving a stream.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The user ID. The network quality of the user with this user ID is reported. If the uid is 0, the local network quality is reported. </param>
        ///
        /// <param name="txQuality"> Uplink network quality rating of the user in terms of the transmission bit rate, packet loss rate, average RTT (Round-Trip Time) and jitter of the uplink network. This parameter is a quality rating helping you understand how well the current uplink network conditions can support the selected video encoder configuration. For example, a 1000 Kbps uplink network may be adequate for video frames with a resolution of 640 × 480 and a frame rate of 15 fps in the LIVE_BROADCASTING profile, but might be inadequate for resolutions higher than 1280 × 720. See QUALITY_TYPE. </param>
        ///
        /// <param name="rxQuality"> Downlink network quality rating of the user in terms of packet loss rate, average RTT, and jitter of the downlink network. See QUALITY_TYPE. </param>
        ///
        public virtual void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnIntraRequestReceived(RtcConnection connection)
        {
        }

        ///
        /// <summary>
        /// Occurs when the first video frame is published.
        /// 
        /// The SDK triggers this callback under one of the following circumstances:
        /// The local client enables the video module and calls JoinChannel [1/2] or JoinChannel [2/2] to join the channel successfully.
        /// The local client calls MuteLocalVideoStream (true) and MuteLocalVideoStream (false) in sequence.
        /// The local client calls DisableVideo and EnableVideo in sequence.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user calling JoinChannel [1/2] or JoinChannel [2/2] until this callback is triggered. </param>
        ///
        public virtual void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when the first remote video frame is received and decoded.
        /// 
        /// The SDK triggers this callback under one of the following circumstances:
        /// The remote user joins the channel and sends the video stream.
        /// The remote user stops sending the video stream and re-sends it after 15 seconds. Reasons for such an interruption include:
        /// The remote user leaves the channel.
        /// The remote user drops offline.
        /// The remote user calls DisableVideo to disable video.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The user ID of the remote user sending the video stream. </param>
        ///
        /// <param name="width"> The width (px) of the video stream. </param>
        ///
        /// <param name="height"> The height (px) of the video stream. </param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [1/2] or JoinChannel [2/2] until the SDK triggers this callback. </param>
        ///
        public virtual void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when the video size or rotation of a specified user changes.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="sourceType"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        /// <param name="uid"> The ID of the user whose video size or rotation changes. (The uid for the local user is 0. The video is the local user's video preview). </param>
        ///
        /// <param name="width"> The width (pixels) of the video stream. </param>
        ///
        /// <param name="height"> The height (pixels) of the video stream. </param>
        ///
        /// <param name="rotation"> The rotation information. The value range is [0,360). On the iOS platform, the parameter value is always 0. </param>
        ///
        public virtual void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
        {
        }

        ///
        /// <summary>
        /// Occurs when the remote video stream state changes.
        /// 
        /// This callback does not work properly when the number of users (in the communication profile) or hosts (in the live streaming channel) in a channel exceeds 17.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The ID of the remote user whose video state changes. </param>
        ///
        /// <param name="state"> The state of the remote video. See REMOTE_VIDEO_STATE. </param>
        ///
        /// <param name="reason"> The reason for the remote video state change. See REMOTE_VIDEO_STATE_REASON. </param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user calling the JoinChannel [2/2] method until the SDK triggers this callback. </param>
        ///
        public virtual void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when the renderer receives the first frame of the remote video.
        /// </summary>
        ///
        /// <param name="remoteUid"> The user ID of the remote user sending the video stream. </param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="width"> The width (px) of the video stream. </param>
        ///
        /// <param name="height"> The height (px) of the video stream. </param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [1/2] or JoinChannel [2/2] until the SDK triggers this callback. </param>
        ///
        public virtual void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when a remote user (in the communication profile)/ host (in the live streaming profile) joins the channel.
        /// 
        /// In a communication channel, this callback indicates that a remote user joins the channel. The SDK also triggers this callback to report the existing users in the channel when a user joins the channel.
        /// In a live-broadcast channel, this callback indicates that a host joins the channel. The SDK also triggers this callback to report the existing hosts in the channel when a host joins the channel. Agora recommends limiting the number of hosts to 17. The SDK triggers this callback under one of the following circumstances:
        /// A remote user/host joins the channel.
        /// A remote user switches the user role to the host after joining the channel.
        /// A remote user/host rejoins the channel after a network interruption.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The ID of the user or host who joins the channel. </param>
        ///
        /// <param name="elapsed"> Time delay (ms) from the local user calling JoinChannel [2/2] until this callback is triggered. </param>
        ///
        public virtual void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when a remote user (in the communication profile)/ host (in the live streaming profile) leaves the channel.
        /// 
        /// There are two reasons for users to become offline:
        /// Leave the channel: When a user/host leaves the channel, the user/host sends a goodbye message. When this message is received, the SDK determines that the user/host leaves the channel.
        /// Drop offline: When no data packet of the user or host is received for a certain period of time (20 seconds for the communication profile, and more for the live broadcast profile), the SDK assumes that the user/host drops offline. A poor network connection may lead to false detections. It's recommended to use the Agora RTM SDK for reliable offline detection.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The ID of the user who leaves the channel or goes offline. </param>
        ///
        /// <param name="reason"> Reasons why the user goes offline: USER_OFFLINE_REASON_TYPE. </param>
        ///
        public virtual void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        ///
        /// <summary>
        /// Occurs when a remote user (in the communication profile) or a host (in the live streaming profile) stops/resumes sending the audio stream.
        /// 
        /// The SDK triggers this callback when the remote user stops or resumes sending the audio stream by calling the MuteLocalAudioStream method. This callback does not work properly when the number of users (in the communication profile) or hosts (in the live streaming channel) in a channel exceeds 17.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The user ID. </param>
        ///
        /// <param name="muted"> Whether the remote user's audio stream is muted: true : User's audio stream is muted. false : User's audio stream is unmuted. </param>
        ///
        public virtual void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)
        {
        }

        ///
        /// <summary>
        /// Occurs when a remote user stops or resumes publishing the video stream.
        /// 
        /// When a remote user calls MuteLocalVideoStream to stop or resume publishing the video stream, the SDK triggers this callback to report to the local user the state of the streams published by the remote user. This callback can be inaccurate when the number of users (in the communication profile) or hosts (in the live streaming profile) in a channel exceeds 17.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The user ID of the remote user. </param>
        ///
        /// <param name="muted"> Whether the remote user stops publishing the video stream: true : The remote user stops publishing the video stream. false : The remote user resumes publishing the video stream. </param>
        ///
        public virtual void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
        }

        ///
        /// <summary>
        /// Occurs when a remote user enables or disables the video module.
        /// 
        /// Once the video module is disabled, the user can only use a voice call. The user cannot send or receive any video. The SDK triggers this callback when a remote user enables or disables the video module by calling the EnableVideo or DisableVideo method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The user ID of the remote user. </param>
        ///
        /// <param name="enabled"> true : The video module is enabled. false : The video module is disabled. </param>
        ///
        public virtual void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
        }

        ///
        /// <summary>
        /// Occurs when a specific remote user enables/disables the local video capturing function.
        /// 
        /// Deprecated: This callback is deprecated, use the following enumerations in the OnRemoteVideoStateChanged callback: REMOTE_VIDEO_STATE_STOPPED (0) and REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED (5). REMOTE_VIDEO_STATE_DECODING (2) and REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED (6). The SDK triggers this callback when the remote user resumes or stops capturing the video stream by calling the EnableLocalVideo method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The user ID of the remote user. </param>
        ///
        /// <param name="enabled"> Whether the specified remote user enables/disables local video capturing: true : The video module is enabled. Other users in the channel can see the video of this remote user. false : The video module is disabled. Other users in the channel can no longer receive the video stream from this remote user, while this remote user can still receive the video streams from other users. </param>
        ///
        public virtual void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
        }

        ///
        /// <summary>
        /// Reports the statistics of the local audio stream.
        /// 
        /// The SDK triggers this callback once every two seconds.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="stats"> Local audio statistics. See LocalAudioStats. </param>
        ///
        public virtual void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)
        {
        }

        ///
        /// <summary>
        /// Reports the transport-layer statistics of each remote audio stream.
        /// 
        /// The SDK triggers this callback once every two seconds for each remote user who is sending audio streams. If a channel includes multiple remote users, the SDK triggers this callback as many times.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="stats"> The statistics of the received remote audio streams. See RemoteAudioStats. </param>
        ///
        public virtual void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
        }

        ///
        /// <summary>
        /// Reports the statistics of the local video stream.
        /// 
        /// The SDK triggers this callback once every two seconds to report the statistics of the local video stream.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="stats"> The statistics of the local video stream. See LocalVideoStats. </param>
        ///
        public virtual void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
        }

        ///
        /// <summary>
        /// Reports the statistics of the video stream sent by each remote users.
        /// 
        /// Reports the statistics of the video stream from the remote users. The SDK triggers this callback once every two seconds for each remote user. If a channel has multiple users/hosts sending video streams, the SDK triggers this callback as many times.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="stats"> Statistics of the remote video stream. See RemoteVideoStats. </param>
        ///
        public virtual void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
        }

        ///
        /// <summary>
        /// Occurs when the SDK cannot reconnect to Agora's edge server 10 seconds after its connection to the server is interrupted.
        /// 
        /// The SDK triggers this callback when it cannot connect to the server 10 seconds after calling the JoinChannel [2/2] method, regardless of whether it is in the channel. If the SDK fails to rejoin the channel 20 minutes after being disconnected from Agora's edge server, the SDK stops rejoining the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        public virtual void OnConnectionLost(RtcConnection connection)
        {
        }

        ///
        /// <summary>
        /// Occurs when the connection between the SDK and the server is interrupted.
        /// 
        /// Deprecated: Use OnConnectionStateChanged instead. The SDK triggers this callback when it loses connection with the server for more than four seconds after the connection is established. After triggering this callback, the SDK tries to reconnect to the server. You can use this callback to implement pop-up reminders. The differences between this callback and OnConnectionLost are as follow:
        /// The SDK triggers the OnConnectionInterrupted callback when it loses connection with the server for more than four seconds after it successfully joins the channel.
        /// The SDK triggers the OnConnectionLost callback when it loses connection with the server for more than 10 seconds, whether or not it joins the channel. If the SDK fails to rejoin the channel 20 minutes after being disconnected from Agora's edge server, the SDK stops rejoining the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        public virtual void OnConnectionInterrupted(RtcConnection connection)
        {
        }

        ///
        /// <summary>
        /// Occurs when the connection is banned by the Agora server.
        /// 
        /// Deprecated: Use OnConnectionStateChanged instead.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        public virtual void OnConnectionBanned(RtcConnection connection)
        {
        }

        ///
        /// <summary>
        /// Occurs when the local user receives the data stream from the remote user.
        /// 
        /// The SDK triggers this callback when the local user receives the stream message that the remote user sends by calling the SendStreamMessage method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the message. </param>
        ///
        /// <param name="streamId"> The stream ID of the received message. </param>
        ///
        /// <param name="data"> The data received. </param>
        ///
        /// <param name="length"> The data length (byte). </param>
        ///
        /// <param name="sentTs"> The time when the data stream is sent. </param>
        ///
        public virtual void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
        }

        ///
        /// <summary>
        /// Occurs when the local user does not receive the data stream from the remote user.
        /// 
        /// The SDK triggers this callback when the local user fails to receive the stream message that the remote user sends by calling the SendStreamMessage method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the message. </param>
        ///
        /// <param name="streamId"> The stream ID of the received message. </param>
        ///
        /// <param name="code"> The error code. </param>
        ///
        /// <param name="missed"> The number of lost messages. </param>
        ///
        /// <param name="cached"> Number of incoming cached messages when the data stream is interrupted. </param>
        ///
        public virtual void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
        }

        ///
        /// <summary>
        /// Occurs when the token expires.
        /// 
        /// The SDK triggers this callback if the token expires. When receiving this callback, you need to generate a new token on your token server and you can renew your token through one of the following ways:
        /// In scenarios involving one channel:
        /// Call RenewToken to pass in the new token.
        /// Call LeaveChannel [2/2] to leave the current channel and then pass in the new token when you call JoinChannel [2/2] to join a channel.
        /// In scenarios involving mutiple channels: Call UpdateChannelMediaOptionsEx to pass in the new token.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        public virtual void OnRequestToken(RtcConnection connection)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnLicenseValidationFailure(RtcConnection connection, LICENSE_ERROR_TYPE reason)
        {
        }

        ///
        /// <summary>
        /// Occurs when the token expires in 30 seconds.
        /// 
        /// When receiving this callback, you need to generate a new token on your token server and you can renew your token through one of the following ways:
        /// In scenarios involving one channel:
        /// Call RenewToken to pass in the new token.
        /// Call LeaveChannel [2/2] to leave the current channel and then pass in the new token when you call JoinChannel [2/2] to join a channel.
        /// In scenarios involving mutiple channels: Call UpdateChannelMediaOptionsEx to pass in the new token.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="token"> The token that is about to expire. </param>
        ///
        public virtual void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
        {
        }

        ///
        /// <summary>
        /// Occurs when the first audio frame is published.
        /// 
        /// The SDK triggers this callback under one of the following circumstances:
        /// The local client enables the audio module and calls JoinChannel [2/2] successfully.
        /// The local client calls MuteLocalAudioStream (true) and MuteLocalAudioStream (false) in sequence.
        /// The local client calls DisableAudio and EnableAudio in sequence.
        /// The local client calls PushAudioFrame to successfully push the audio frame to the SDK.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback. </param>
        ///
        public virtual void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when the SDK receives the first audio frame from a specific remote user.
        /// 
        /// Deprecated: Use OnRemoteAudioStateChanged instead.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="userId"> The user ID of the remote user. </param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback. </param>
        ///
        public virtual void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when the SDK decodes the first remote audio frame for playback.
        /// 
        /// Deprecated: Use OnRemoteAudioStateChanged instead. The SDK triggers this callback under one of the following circumstances:
        /// The remote user joins the channel and sends the audio stream for the first time.
        /// The remote user's audio is offline and then goes online to re-send audio. It means the local user cannot receive audio in 15 seconds. Reasons for such an interruption include:
        /// The remote user leaves channel.
        /// The remote user drops offline.
        /// The remote user calls MuteLocalAudioStream to stop sending the audio stream.
        /// The remote user calls DisableAudio to disable audio.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid"> The user ID of the remote user. </param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback. </param>
        ///
        public virtual void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when the local audio stream state changes.
        /// 
        /// When the state of the local audio stream changes (including the state of the audio capture and encoding), the SDK triggers this callback to report the current state. This callback indicates the state of the local audio stream, and allows you to troubleshoot issues when audio exceptions occur. When the state is LOCAL_AUDIO_STREAM_STATE_FAILED (3), you can view the error information in the error parameter.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="state"> The state of the local audio. See LOCAL_AUDIO_STREAM_STATE. </param>
        ///
        /// <param name="reason"> Reasons for local audio state changes. See LOCAL_AUDIO_STREAM_REASON. </param>
        ///
        public virtual void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_REASON reason)
        {
        }

        ///
        /// <summary>
        /// Occurs when the remote audio state changes.
        /// 
        /// When the audio state of a remote user (in a voice/video call channel) or host (in a live streaming channel) changes, the SDK triggers this callback to report the current state of the remote audio stream. This callback does not work properly when the number of users (in the communication profile) or hosts (in the live streaming channel) in a channel exceeds 17.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The ID of the remote user whose audio state changes. </param>
        ///
        /// <param name="state"> The state of the remote audio. See REMOTE_AUDIO_STATE. </param>
        ///
        /// <param name="reason"> The reason of the remote audio state change. See REMOTE_AUDIO_STATE_REASON. </param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user calling the JoinChannel [2/2] method until the SDK triggers this callback. </param>
        ///
        public virtual void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        ///
        /// <summary>
        /// Occurs when the most active remote speaker is detected.
        /// 
        /// After a successful call of EnableAudioVolumeIndication, the SDK continuously detects which remote user has the loudest volume. During the current period, the remote user whose volume is detected as the loudest for the most times, is the most active user. When the number of users is no less than two and an active remote speaker exists, the SDK triggers this callback and reports the uid of the most active remote speaker.
        /// If the most active remote speaker is always the same user, the SDK triggers the OnActiveSpeaker callback only once.
        /// If the most active remote speaker changes to another user, the SDK triggers this callback again and reports the uid of the new active remote speaker.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid"> The user ID of the most active speaker. </param>
        ///
        public virtual void OnActiveSpeaker(RtcConnection connection, uint uid)
        {
        }

        ///
        /// <summary>
        /// Occurs when the user role switches during the interactive live streaming.
        /// 
        /// The SDK triggers this callback when the local user switches their user role by calling SetClientRole [2/2] after joining the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="oldRole"> Role that the user switches from: CLIENT_ROLE_TYPE. </param>
        ///
        /// <param name="newRole"> Role that the user switches to: CLIENT_ROLE_TYPE. </param>
        ///
        /// <param name="newRoleOptions"> Properties of the role that the user switches to. See ClientRoleOptions. </param>
        ///
        public virtual void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
        }

        ///
        /// <summary>
        /// Occurs when the user role switching fails in the interactive live streaming.
        /// 
        /// In the live broadcasting channel profile, when the local user calls SetClientRole [2/2] to switch the user role after joining the channel but the switch fails, the SDK triggers this callback to report the reason for the failure and the current user role.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="reason"> The reason for a user role switch failure. See CLIENT_ROLE_CHANGE_FAILED_REASON. </param>
        ///
        /// <param name="currentRole"> Current user role. See CLIENT_ROLE_TYPE. </param>
        ///
        public virtual void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
        }

        ///
        /// <summary>
        /// Reports the transport-layer statistics of each remote audio stream.
        /// 
        /// Deprecated: Use OnRemoteAudioStats instead. This callback reports the transport-layer statistics, such as the packet loss rate and network time delay after the local user receives an audio packet from a remote user. During a call, when the user receives the audio packet sent by the remote user, the callback is triggered every 2 seconds.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the audio streams. </param>
        ///
        /// <param name="delay"> The network delay (ms) from the remote user to the receiver. </param>
        ///
        /// <param name="lost"> The packet loss rate (%) of the audio packet sent from the remote user to the receiver. </param>
        ///
        /// <param name="rxKBitrate"> The bitrate of the received audio (Kbps). </param>
        ///
        public virtual void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        ///
        /// <summary>
        /// Reports the transport-layer statistics of each remote video stream.
        /// 
        /// Deprecated: This callback is deprecated. Use OnRemoteVideoStats instead. This callback reports the transport-layer statistics, such as the packet loss rate and network time delay after the local user receives a video packet from a remote user. During a call, when the user receives the video packet sent by the remote user/host, the callback is triggered every 2 seconds.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the video packets. </param>
        ///
        /// <param name="delay"> The network delay (ms) from the sender to the receiver. </param>
        ///
        /// <param name="lost"> The packet loss rate (%) of the video packet sent from the remote user. </param>
        ///
        /// <param name="rxKBitRate"> The bitrate of the received video (Kbps). </param>
        ///
        public virtual void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        ///
        /// <summary>
        /// Occurs when the network connection state changes.
        /// 
        /// When the network connection state changes, the SDK triggers this callback and reports the current connection state and the reason for the change.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="state"> The current connection state. See CONNECTION_STATE_TYPE. </param>
        ///
        /// <param name="reason"> The reason for a connection state change. See CONNECTION_CHANGED_REASON_TYPE. </param>
        ///
        public virtual void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnWlAccMessage(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnWlAccStats(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
        }

        ///
        /// <summary>
        /// Occurs when the local network type changes.
        /// 
        /// This callback occurs when the connection state of the local user changes. You can get the connection state and reason for the state change in this callback. When the network connection is interrupted, this callback indicates whether the interruption is caused by a network type change or poor network conditions.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="type"> The type of the local network connection. See NETWORK_TYPE. </param>
        ///
        public virtual void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)
        {
        }

        ///
        /// <summary>
        /// Reports the built-in encryption errors.
        /// 
        /// When encryption is enabled by calling EnableEncryption, the SDK triggers this callback if an error occurs in encryption or decryption on the sender or the receiver side.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="errorType"> Details about the error type. See ENCRYPTION_ERROR_TYPE. </param>
        ///
        public virtual void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string remoteUserAccount)
        {
        }

        ///
        /// <summary>
        /// Reports the result of taking a video snapshot.
        /// 
        /// After a successful TakeSnapshot method call, the SDK triggers this callback to report whether the snapshot is successfully taken as well as the details for the snapshot taken.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid"> The user ID. One uid of 0 indicates the local user. </param>
        ///
        /// <param name="filePath"> The local path of the snapshot. </param>
        ///
        /// <param name="width"> The width (px) of the snapshot. </param>
        ///
        /// <param name="height"> The height (px) of the snapshot. </param>
        ///
        /// <param name="errCode">
        /// The message that confirms success or gives the reason why the snapshot is not successfully taken:
        /// 0: Success.
        /// < 0: Failure:
        /// -1: The SDK fails to write data to a file or encode a JPEG image.
        /// -2: The SDK does not find the video stream of the specified user within one second after the TakeSnapshot method call succeeds. The possible reasons are: local capture stops, remote end stops publishing, or video data processing is blocked.
        /// -3: Calling the TakeSnapshot method too frequently.
        /// </param>
        ///
        public virtual void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
        }

        ///
        /// <summary>
        /// Video frame rendering event callback.
        /// 
        /// After calling the StartMediaRenderingTracing method or joining the channel, the SDK triggers this callback to report the events of video frame rendering and the indicators during the rendering process. Developers can optimize the indicators to improve the efficiency of the first video frame rendering.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid"> The user ID. </param>
        ///
        /// <param name="currentEvent"> The current video frame rendering event. See MEDIA_TRACE_EVENT. </param>
        ///
        /// <param name="tracingInfo"> The indicators during the video frame rendering process. Developers need to reduce the value of indicators as much as possible in order to improve the efficiency of the first video frame rendering. See VideoRenderingTracingInfo. </param>
        ///
        public virtual void OnVideoRenderingTracingResult(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnSetRtmFlagResult(RtcConnection connection, int code)
        {
        }

        ///
        /// <summary>
        /// Occurs when the local user receives a mixed video stream carrying layout information.
        /// 
        /// When the local user receives a mixed video stream sent by the video mixing server for the first time, or when there is a change in the layout information of the mixed stream, the SDK triggers this callback, reporting the layout information of each sub-video stream within the mixed video stream. This callback is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection. </param>
        ///
        /// <param name="uid">  </param>
        ///
        public virtual void OnTranscodedStreamLayoutInfo(RtcConnection connection, uint uid, int width, int height, int layoutCount, VideoLayout[] layoutlist)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnAudioMetadataReceived(RtcConnection connection, uint uid, byte[] metadata, ulong length)
        {
        }
        #endregion terra IRtcEngineEventHandler

        #region terra IDirectCdnStreamingEventHandler
        ///
        /// <summary>
        /// Occurs when the CDN streaming state changes.
        /// 
        /// When the host directly pushes streams to the CDN, if the streaming state changes, the SDK triggers this callback to report the changed streaming state, error codes, and other information. You can troubleshoot issues by referring to this callback.
        /// </summary>
        ///
        /// <param name="state"> The current CDN streaming state. See DIRECT_CDN_STREAMING_STATE. </param>
        ///
        /// <param name="reason"> Reasons for changes in the status of CDN streaming. See DIRECT_CDN_STREAMING_REASON. </param>
        ///
        /// <param name="message"> The information about the changed streaming state. </param>
        ///
        public virtual void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_REASON reason, string message)
        {
        }

        ///
        /// <summary>
        /// Reports the CDN streaming statistics.
        /// 
        /// When the host directly pushes media streams to the CDN, the SDK triggers this callback every one second.
        /// </summary>
        ///
        /// <param name="stats"> The statistics of the current CDN streaming. See DirectCdnStreamingStats. </param>
        ///
        public virtual void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
        {
        }
        #endregion terra IDirectCdnStreamingEventHandler
    };
}