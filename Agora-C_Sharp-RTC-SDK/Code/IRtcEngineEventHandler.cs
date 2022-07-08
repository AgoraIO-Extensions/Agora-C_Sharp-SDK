using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The SDK uses the IRtcEngineEventHandler interface to send event notifications to your app. Your app can get those notifications through methods that inherit this interface.
    /// </summary>
    ///
    public abstract class IRtcEngineEventHandler
    {
        ///
        /// <summary>
        /// Occurs when a user joins a channel.
        /// This callback notifies the application that a user joins a specified channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.</param>
        ///
        public virtual void OnJoinChannelSuccess(RtcConnection connection, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when a user rejoins the channel.
        /// When a user loses connection with the server because of network problems, the SDK automatically tries to reconnect and triggers this callback upon reconnection.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user trying to rejoin the channel until the SDK triggers this callback.</param>
        ///
        public virtual void OnRejoinChannelSuccess(RtcConnection connection, int elapsed) { }

        public virtual void OnWarning(int warn, string msg) { }

        public virtual void OnError(int err, string msg) { }

        ///
        /// <summary>
        /// Reports the statistics of the audio stream from each remote user.
        /// Deprecated:
        /// Please use OnRemoteAudioStats instead. 
        /// The SDK triggers this callback once every two seconds to report the audio quality of each remote user/host sending an audio stream. If a channel has multiple users/hosts sending audio streams, the SDK triggers this callback as many times.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The user ID of the remote user sending the audio stream.</param>
        ///
        /// <param name="quality"> Audio quality of the user. 
        ///  QUALITY_UNKNOWN(0): The quality is unknown.
        ///  QUALITY_EXCELLENT(1): The quality is excellent.
        ///  QUALITY_GOOD(2): The network quality seems excellent, but the bitrate can be slightly lower than excellent.
        ///  QUALITY_POOR(3): Users can feel the communication is slightly impaired.
        ///  QUALITY_BAD(4): Users cannot communicate smoothly.
        ///  QUALITY_VBAD(5): The quality is so bad that users can barely communicate.
        ///  QUALITY_DOWN(6): The network is down, and users cannot communicate at all.
        ///  See QUALITY_TYPE .</param>
        ///
        /// <param name="delay"> The network delay (ms) from the sender to the receiver, including the delay caused by audio sampling pre-processing, network transmission, and network jitter buffering.</param>
        ///
        /// <param name="lost"> The packet loss rate (%) of the audio packet sent from the remote user.</param>
        ///
        public virtual void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, UInt16 delay, UInt16 lost) { }

        ///
        /// <summary>
        /// Reports the last mile network probe result.
        /// The SDK triggers this callback within 30 seconds after the app calls StartLastmileProbeTest .
        /// </summary>
        ///
        /// <param name="result"> The uplink and downlink last-mile network probe test result. See LastmileProbeResult .</param>
        ///
        public virtual void OnLastmileProbeResult(LastmileProbeResult result) { }

        ///
        /// <summary>
        /// Reports the volume information of users.
        /// By default, this callback is disabled. You can enable it by calling EnableAudioVolumeIndication . Once this callback is enabled and users send streams in the channel, the SDK triggers the OnAudioVolumeIndication callback at the time interval set in EnableAudioVolumeIndication. The SDK triggers two independent OnAudioVolumeIndication callbacks simultaneously, which separately report the volume information of the local user who sends a stream and the remote users (up to three) whose instantaneous volume is the highest.
        /// After you enable this callback, calling MuteLocalAudioStream affects the SDK's behavior as follows:
        /// If the local user stops publishing the audio stream, the SDK stops triggering the local user's callback.
        /// 20 seconds after a remote user whose volume is one of the three highest stops publishing the audio stream, the callback excludes this user's information; 20 seconds after all remote users stop publishing audio streams, the SDK stops triggering the callback for remote users.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="speakers"> The volume information of the users, see AudioVolumeInfo . Ifan empty speakers array in the callback indicates that no remote user is in the channel or sending a stream at the moment.</param>
        ///
        /// <param name="speakerNumber"> The total number of users.
        ///  In the local user's callback, when the local user sends a stream, speakerNumber is 1.
        ///  In the callback for remote users, the value range of speakerNumber is [0,3]. If the number of remote users who send streams is greater than or equal to three, the value of speakerNumber is 3. </param>
        ///
        /// <param name="totalVolume"> The volume of the speaker. The value ranges between 0 (lowest volume) and 255 (highest volume).
        ///  In the callback for the local user, totalVolume is the volume of the local user who sends a stream.
        ///  In the callback for remote users, totalVolume is the sum of the volume of all remote users (up to three) whose instantaneous volume is the highest. </param>
        ///
        public virtual void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume) { }

        ///
        /// <summary>
        /// Occurs when a user leaves a channel.
        /// This callback notifies the app that the user leaves the channel by calling LeaveChannel [1/2]
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="stats"> The statistics of the call. See RtcStats .</param>
        ///
        public virtual void OnLeaveChannel(RtcConnection connection, RtcStats stats) { }

        ///
        /// <summary>
        /// Reports the statistics of the current call. 
        /// The SDK triggers this callback once every two seconds after the user joins the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="stats"> Statistics of the RTC engine. See RtcStats . </param>
        ///
        public virtual void OnRtcStats(RtcConnection connection, RtcStats stats) { }

        //todo fix with dcg
        ///
        /// <summary>
        /// Occurs when the audio device state changes.
        /// This callback notifies the application that the system's audio device state is changed. For example, a headset is unplugged from the device.
        /// This method is for Windows and macOS only.
        /// </summary>
        ///
        /// <param name="deviceId"> The device ID.</param>
        ///
        /// <param name="deviceType"> The evice type. See MEDIA_DEVICE_TYPE .</param>
        ///
        /// <param name="deviceState"> The device state.
        ///  On macOS:
        ///  0: The device is ready for use.
        ///  8: The device is not connected. On Windows: see MEDIA_DEVICE_STATE_TYPE .</param>
        ///
        public virtual void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState) { }

        ///
        /// <summary>
        /// Occurs when the playback of the local music file finishes.
        /// Deprecated:
        /// Please use OnAudioMixingStateChanged instead. After you call StartAudioMixing [2/2] to play a local music file, this callback occurs when the playback finishes. If the call StartAudioMixing [2/2] fails, the error code WARN_AUDIO_MIXING_OPEN_ERROR is returned.
        /// </summary>
        ///
        [Obsolete("This method is deprecated, use onAudioMixingStateChanged instead")]
        public virtual void OnAudioMixingFinished() { }

        ///
        /// <summary>
        /// Occurs when the playback of the local music file finishes.
        /// This callback occurs when the local audio effect file finishes playing.
        /// </summary>
        ///
        /// <param name="soundId"> The audio effect ID. The ID of each audio effect file is unique.</param>
        ///
        public virtual void OnAudioEffectFinished(int soundId) { }

        //todo fix with dcg
        public virtual void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState) { }

        //todo fix with dcg
        public virtual void OnMediaDeviceChanged(MEDIA_DEVICE_TYPE deviceType) { }

        ///
        /// <summary>
        /// Reports the last mile network quality of each user in the channel.
        /// This callback reports the last mile network conditions of each user in the channel. Last mile refers to the connection between the local device and Agora's edge server.
        /// The SDK triggers this callback once every two seconds. If a channel includes multiple users, the SDK triggers this callback as many times.
        /// txQuality is UNKNOWNrxQuality is UNKNOWN
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The user ID. The network quality of the user with this user ID is reported.</param>
        ///
        /// <param name="txQuality"> Uplink network quality rating of the user in terms of the transmission bit rate, packet loss rate, average RTT (Round-Trip Time) and jitter of the uplink network. This parameter is a quality rating helping you understand how well the current uplink network conditions can support the selected video encoder configuration. For example, a 1000 Kbps uplink network may be adequate for video frames with a resolution of 640 × 480 and a frame rate of 15 fps in the LIVE_BROADCASTING profile, but may be inadequate for resolutions higher than 1280 × 720. 
        ///  QUALITY_UNKNOWN(0): The quality is unknown.
        ///  QUALITY_EXCELLENT(1): The quality is excellent.
        ///  QUALITY_GOOD(2): The network quality seems excellent, but the bitrate can be slightly lower than excellent.
        ///  QUALITY_POOR(3): Users can feel the communication is slightly impaired.
        ///  QUALITY_BAD(4): Users cannot communicate smoothly.
        ///  QUALITY_VBAD(5): The quality is so bad that users can barely communicate.
        ///  QUALITY_DOWN(6): The network is down, and users cannot communicate at all.
        ///  See QUALITY_TYPE .</param>
        ///
        /// <param name="rxQuality"> Downlink network quality rating of the user in terms of packet loss rate, average RTT, and jitter of the downlink network. 
        ///  QUALITY_UNKNOWN(0): The quality is unknown.
        ///  QUALITY_EXCELLENT(1): The quality is excellent.
        ///  QUALITY_GOOD(2): The network quality seems excellent, but the bitrate can be slightly lower than excellent.
        ///  QUALITY_POOR(3): Users can feel the communication is slightly impaired.
        ///  QUALITY_BAD(4): Users cannot communicate smoothly.
        ///  QUALITY_VBAD(5): The quality is so bad that users can barely communicate.
        ///  QUALITY_DOWN(6): The network is down, and users cannot communicate at all.
        ///  See QUALITY_TYPE .</param>
        ///
        public virtual void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality) { }

        public virtual void OnIntraRequestReceived(RtcConnection connection) { }

        ///
        /// <summary>
        /// Occurs when the uplink network information changes.
        /// The SDK triggers this callback when the uplink network information changes.
        /// This callback only applies to scenarios where you push externally encoded video data in H.264 format to the SDK.
        /// </summary>
        ///
        /// <param name="info"> The uplink network information. See UplinkNetworkInfo .</param>
        ///
        public virtual void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info) { }

        public virtual void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info) { }

        ///
        /// <summary>
        /// Reports the last-mile network quality of the local user.
        /// This callback reports the last-mile network conditions of the local user before the user joins the channel. Last mile refers to the connection between the local device and Agora's edge server.
        /// Before the user joins the channel, this callback is triggered by the SDK once StartLastmileProbeTest is called and reports the last-mile network conditions of the local user.
        /// </summary>
        ///
        /// <param name="quality"> The last-mile network quality. 
        ///  QUALITY_UNKNOWN(0): The quality is unknown.
        ///  QUALITY_EXCELLENT(1): The quality is excellent.
        ///  QUALITY_GOOD(2): The network quality seems excellent, but the bitrate can be slightly lower than excellent.
        ///  QUALITY_POOR(3): Users can feel the communication is slightly impaired.
        ///  QUALITY_BAD(4): Users cannot communicate smoothly.
        ///  QUALITY_VBAD(5): The quality is so bad that users can barely communicate.
        ///  QUALITY_DOWN(6): The network is down, and users cannot communicate at all.
        ///  See QUALITY_TYPE .</param>
        ///
        public virtual void OnLastmileQuality(int quality) { }

        ///
        /// <summary>
        /// Occurs when the first local video frame is displayed on the local video view.
        /// This callback is triggered when the first local video frame is displayed on the local view.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="width"> The width (px) of the first local video frame.</param>
        ///
        /// <param name="height"> The height (px) of the first local video frame.</param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback. If you call StartPreview JoinChannel [2/2], then this parameter is the time elapsed from calling the StartPreview </param>
        ///
        public virtual void OnFirstLocalVideoFrame(RtcConnection connection, int width, int height, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when the first video frame is published.
        /// The SDK triggers this callback under one of the following circumstances:
        /// The local client enables the video module and calls JoinChannel [2/2] successfully.
        /// The local client calls MuteLocalVideoStream (true) and MuteLocalVideoStream(false) in sequence.
        /// The local client calls DisableVideo and EnableVideo in sequence.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user calling the JoinChannel [2/2] method until this callback is triggered.</param>
        ///
        public virtual void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed) { }

        public virtual void OnVideoSourceFrameSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, int width, int height) { }

        ///
        /// <summary>
        /// Occurs when the first remote video frame is received and decoded.
        /// The SDK triggers this callback under one of the following circumstances:
        /// The remote user joins the channel and sends the video stream.
        /// The remote user stops sending the video stream and re-sends it after 15 seconds. Reasons for such an interruption include:
        /// The remote user leaves the channel.
        /// The remote user drops offline.
        /// The remote user calls MuteLocalVideoStream to stop sending the video stream.
        /// The remote user calls DisableVideo to disable video.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the video stream.</param>
        ///
        /// <param name="width"> The width (px) of the video stream.</param>
        ///
        /// <param name="height"> The height (px) of the video stream.</param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.</param>
        ///
        public virtual void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when the video size or rotation of a specified user changes.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The ID of the user whose video size or rotation changes. (The uid for the local user is 0. The video is the local user's video preview).</param>
        ///
        /// <param name="width"> New width (pixels) of the video.</param>
        ///
        /// <param name="height"> New height (pixels) of the video.</param>
        ///
        /// <param name="rotation"> New rotation of the video [0 to 360).</param>
        ///
        public virtual void OnVideoSizeChanged(RtcConnection connection, uint uid, int width, int height, int rotation) { }

        ///
        /// <summary>
        /// 鉴黄审核结果回调。
        /// 设置 ContentInspectConfig 中的 type 设为 ContentInspectModule 并调用 EnableContentInspect 开启鉴黄后，SDK 会触发 onContentInspectResult 回调，报告鉴黄结果。
        /// </summary>
        ///
        /// <param name="result"> 鉴黄结果。 See CONTENT_INSPECT_RESULT .</param>
        ///
        public virtual void OnContentInspectResult(CONTENT_INSPECT_RESULT result) { }


        ///
        /// <summary>
        /// Reports the result of taking a video snapshot.
        /// 成功调用 TakeSnapshot 后，SDK 触发该回调报告截图是否成功和获取截图的详情。
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="filePath"> 截图的本地保存路径。</param>
        ///
        /// <param name="width"> 图片宽度（px）。</param>
        ///
        /// <param name="height"> 图片高度（px）。</param>
        ///
        /// <param name="errCode"> 截图成功的提示或失败的原因。 
        ///  0：截图成功。
        ///  &lt; 0: 截图失败。 
        ///  -1：写入文件失败或 JPEG 编码失败。
        ///  -2：TakeSnapshot 方法调用成功后 1 秒内没有发现指定用户的视频流。 </param>
        ///
        public virtual void OnSnapshotTaken(string channel, uint uid, string filePath, int width, int height, int errCode) { }
        //todo fix with dcg
        public virtual void OnSnapshotTaken(RtcConnection connection, string filePath, int width, int height, int errCode) { }

        ///
        /// <summary>
        /// Occurs when the local video stream state changes.
        /// When the state of the local video stream changes, the SDK triggers this callback to report the current state. This callback indicates the state of the local video stream and allows you to troubleshoot issues when exceptions occur.
        /// The SDK triggers the OnLocalVideoStateChanged callback with the state code of LOCAL_VIDEO_STREAM_STATE_FAILED and error code of LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE in the following situations:
        /// The app switches to the background, and the system gets the camera resource.
        /// The camera starts normally, but does not output vide frames for four consecutive seconds. When the camera outputs the captured video frames, if the video frames are the same for 15 consecutive frames, the SDK triggers the OnLocalVideoStateChanged callback with the state code of LOCAL_VIDEO_STREAM_STATE_CAPTURING and error code of LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE. Note that the video frame duplication detection is only available for video frames with a resolution greater than 200 × 200, a frame rate greater than or equal to 10 fps, and a bitrate less than 20 Kbps.
        /// For some device models, the SDK does not trigger this callback when the state of the local video changes while the local video capturing device is in use, so you have to make your own timeout judgment.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="state"> The state of the local video. See LOCAL_VIDEO_STREAM_STATE .</param>
        ///
        /// <param name="errorCode"> </param>
        ///
        public virtual void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode) { }

        ///
        /// <summary>
        /// Occurs when the remote video stream state changes.
        /// This callback can be inaccurate when the number of users (in the communication profile) or hosts (in the live broadcasting profile) in a channel exceeds 17.
        /// </summary>
        ///
        /// <param name="connection"> The connection information.  RtcConnection </param>
        ///
        /// <param name="remoteUid"> The ID of the remote user whose video state changes.</param>
        ///
        /// <param name="state"> The state of the remote video, see REMOTE_VIDEO_STATE .</param>
        ///
        /// <param name="reason"> The reason for the remote video state change, see REMOTE_VIDEO_STATE_REASON .</param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user callingJoinChannel [2/2] the method until the SDK triggers this callback.</param>
        ///
        public virtual void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when the renderer receives the first frame of the remote video.
        /// </summary>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the video stream.</param>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="width"> The width (px) of the video stream.</param>
        ///
        /// <param name="height"> The height (px) of the video stream.</param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling JoinChannel [2/2] until the SDK triggers this callback.</param>
        ///
        public virtual void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when a remote user (in the communication profile)/ host (in the live streaming profile) leaves the channel.
        /// In a communication channel, this callback indicates that a remote user joins the channel. The SDK also triggers this callback to report the existing users in the channel when a user joins the channel.
        /// In a live-broadcast channel, this callback indicates that a host joins the channel. The SDK also triggers this callback to report the existing hosts in the channel when a host joins the channel. Agora recommends limiting the number of hosts to 17. The SDK triggers this callback under one of the following circumstances:
        /// A remote user/hostJoinChannel [2/2] joins the channel by calling the method.
        /// A remote user switches the user role to the host after joining the channel.
        /// A remote user/host rejoins the channel after a network interruption.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The ID of the user or host who joins the channel.</param>
        ///
        /// <param name="elapsed"> Time delay (ms) fromJoinChannel [2/2] the local user calling until this callback is triggered.</param>
        ///
        public virtual void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when a remote user (in the communication profile)/ host (in the live streaming profile) leaves the channel.
        /// There are two reasons for users to become offline:
        /// Leave the channel: When a user/host leaves the channel, the user/host sends a goodbye message. When this message is received, the SDK determines that the user/host leaves the channel.
        /// Drop offline: When no data packet of the user or host is received for a certain period of time (20 seconds for the communication profile, and more for the live broadcast profile), the SDK assumes that the user/host drops offline. A poor network connection may lead to false detections. It's recommended to use the Agora RTM SDK for reliable offline detection.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The ID of the user who leaves the channel or goes offline.</param>
        ///
        /// <param name="reason"> Reasons why the user goes offline: USER_OFFLINE_REASON_TYPE .</param>
        ///
        public virtual void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason) { }

        [Obsolete("Use onRemoteAudioStateChanged instead of")]
        public virtual void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted) { }

        [Obsolete("Use onRemoteVideoStateChanged instead of")]
        public virtual void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted) { }

        [Obsolete("Use onRemoteVideoStateChanged instead of")]
        public virtual void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled) { }

        [Obsolete("Use onRemoteVideoStateChanged instead of")]
        public virtual void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled) { }

        public virtual void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state) { }

        ///
        /// <summary>
        /// Occurs when a method is executed by the SDK.
        /// </summary>
        ///
        /// <param name="err"> The error code returned by the SDK when the method call fails. If the SDK returns 0, then the method call is successful.</param>
        ///
        /// <param name="api"> The method executed by the SDK.</param>
        ///
        /// <param name="result"> The result of the method call.</param>
        ///
        public virtual void OnApiCallExecuted(int err, string api, string result) { }

        ///
        /// <summary>
        /// Reports the statistics of the local audio stream.
        /// The SDK triggers this callback once every two seconds.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="stats"> Local audio statistics. See LocalAudioStats .</param>
        ///
        public virtual void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats) { }

        ///
        /// <summary>
        /// Reports the statistics of the audio stream sent by each remote users.
        /// The SDK triggers this callback once every two seconds. If a channel includes multiple users, the SDK triggers this callback as many times.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="stats"> Statistics of the received remote audio stream. See RemoteAudioStats .</param>
        ///
        public virtual void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats) { }

        ///
        /// <summary>
        /// Reports the statistics of the local video stream.
        /// The SDK triggers this callback once every two seconds to report the statistics of the local video stream.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="stats"> The statistics of the local video stream. See LocalVideoStats .</param>
        ///
        public virtual void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats) { }

        ///
        /// <summary>
        /// Reports the statistics of the video stream sent by each remote users.
        /// Reports the statistics of the video stream from the remote users. The SDK triggers this callback once every two seconds for each remote user. If a channel has multiple users/hosts sending video streams, the SDK triggers this callback as many times.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="stats"> Statistics of the remote video stream. </param>
        ///
        public virtual void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats) { }

        ///
        /// <summary>
        /// Occurs when the camera turns on and is ready to capture the video.
        /// Deprecated: Please use LOCAL_VIDEO_STREAM_STATE_CAPTURING(1) in OnLocalVideoStateChanged instead. 
        /// This callback indicates that the camera has been successfully turned on and you can start to capture video.
        /// </summary>
        ///
        public virtual void OnCameraReady() { }

        ///
        /// <summary>
        /// Occurs when the camera focus area changes.
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="x"> The x-coordinate of the changed focus area.</param>
        ///
        /// <param name="y"> The y-coordinate of the changed focus area.</param>
        ///
        /// <param name="width"> The width of the focus area that changes.</param>
        ///
        /// <param name="height"> The height of the focus area that changes.</param>
        ///
        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height) { }

        ///
        /// <summary>
        /// Occurs when the camera exposure area changes.
        /// </summary>
        ///
        /// <param name="x"> The x coordinate of the changed camera exposure area.</param>
        ///
        /// <param name="y"> The y coordinate of the changed camera exposure area.</param>
        ///
        /// <param name="width"> The width of the changed camera exposure area.</param>
        ///
        /// <param name="height"> The height of the changed exposure area.</param>
        ///
        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height) { }

        ///
        /// <summary>
        /// Reports the face detection result of the local user.
        /// Once you enable face detection by calling EnableFaceDetection (true), you can get the following information on the local user in real-time:
        /// The width and height of the local video.
        /// The position of the human face in the local view.
        /// The distance between the human face and the screen. This value is based on the fitting calculation of the local video size and the position of the human face. This callback is for Android and iOS only.
        /// When it is detected that the face in front of the camera disappears, the callback will be triggered immediately. When no human face is detected, the frequency of this callback to be rtriggered wil be decreased to reduce power consumption on the local device.
        /// The SDK stops triggering this callback when a human face is in close proximity to the screen.
        /// </summary>
        ///
        /// <param name="imageWidth"> The width (px) of the video image captured by the local camera.</param>
        ///
        /// <param name="imageHeight"> The height (px) of the video image captured by the local camera.</param>
        ///
        /// <param name="vecRectangle"> The information of the detected human face:
        ///  x: The x-coordinate (px) of the human face in the local view. Taking the top left corner of the view as the origin, the x-coordinate represents the horizontal position of the human face relative to the origin.
        ///  y: The y-coordinate (px) of the human face in the local view. Taking the top left corner of the view as the origin, the y-coordinate represents the vertical position of the human face relative to the origin.
        ///  width: The width (px) of the human face in the captured view.
        ///  height: The height (px) of the human face in the captured view. </param>
        ///
        /// <param name="vecDistance"> The distance between the human face and the device screen (cm).</param>
        ///
        /// <param name="numFaces"> The number of faces detected. If the value is 0, it means that no human face is detected.</param>
        ///
        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle vecRectangle, int[] vecDistance, int numFaces) { }

        ///
        /// <summary>
        /// Occurs when the video stops playing.
        /// Deprecated:
        /// Please use LOCAL_VIDEO_STREAM_STATE_STOPPED(0) in the OnLocalVideoStateChanged callback instead. The application can use this callback to change the configuration of the view (for example, displaying other pictures in the view) after the video stops playing.
        /// </summary>
        ///
        public virtual void OnVideoStopped() { }

        ///
        /// <summary>
        /// Occurs when the playback state of the music file changes.
        /// This callback occurs when the playback state of the music file changes, and reports the current state and error code.
        /// </summary>
        ///
        /// <param name="state"> The playback state of the music file. See AUDIO_MIXING_STATE_TYPE .</param>
        ///
        /// <param name="errorCode"> The error code. See AUDIO_MIXING_ERROR_TYPE .</param>
        ///
        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_ERROR_TYPE errorCode) { }

        public virtual void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode) { }

        ///
        /// <summary>
        /// Occurs when the SDK cannot reconnect to Agora's edge server 10 seconds after its connection to the server is interrupted.
        /// The SDK triggers this callback when it cannot connect to the server 10 seconds after calling the JoinChannel [2/2] method, regardless of whether it is in the channel. If the SDK fails to rejoin the channel within 20 minutes after disconnecting, the SDK will stop trying to reconnect.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        public virtual void OnConnectionLost(RtcConnection connection) { }

        ///
        /// <summary>
        /// Occurs when the connection between the SDK and the server is interrupted.
        /// Deprecated:
        /// Use OnConnectionStateChanged instead. The SDK triggers this callback when it loses connection with the server for more than four seconds after the connection is established. After triggering this callback, the SDK tries to reconnect to the server. You can use this callback to implement pop-up reminders. The difference between this callback and OnConnectionLost is:
        /// The SDK triggers the OnConnectionInterrupted callback when it loses connection with the server for more than four seconds after it successfully joins the channel.
        /// The SDK triggers the OnConnectionLost callback when it loses connection with the server for more than 10 seconds, whether or not it joins the channel.
        /// If the SDK fails to rejoin the channel 20 minutes after being disconnected from Agora's edge server, the SDK stops rejoining the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        public virtual void OnConnectionInterrupted(RtcConnection connection) { }

        ///
        /// <summary>
        /// Occurs when the connection is banned by the Agora server.
        /// Deprecated:
        /// Please use OnConnectionStateChanged instead.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        public virtual void OnConnectionBanned(RtcConnection connection) { }

        ///
        /// <summary>
        /// Occurs when the local user receives the data stream from the remote user.
        /// The SDK triggers this callback when the local user receives the stream message that the remote user sends by calling the SendStreamMessage method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the message.</param>
        ///
        /// <param name="streamId"> The stream ID of the received message.</param>
        ///
        /// <param name="data"> received data.</param>
        ///
        /// <param name="length"> The data length (byte).</param>
        ///
        /// <param name="sentTs"> The time when the data stream is sent.</param>
        ///
        public virtual void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, uint length, UInt64 sentTs) { }

        ///
        /// <summary>
        /// Occurs when the local user receives the data stream from the remote user.
        /// The SDK triggers this callback when the local user fails to receive the stream SendStreamMessage message that the remote user sends by calling the method.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the message.</param>
        ///
        /// <param name="streamId"> The stream ID of the received message.</param>
        ///
        /// <param name="code"> The error code.</param>
        ///
        /// <param name="missed"> The number of lost messages.</param>
        ///
        /// <param name="cached"> Number of incoming cached messages when the data stream is interrupted.</param>
        ///
        public virtual void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached) { }

        ///
        /// <summary>
        /// Occurs when the token expires.
        /// When the token expires during a call, the SDK triggers this callback to remind the app to renew the token.
        /// Once you receive this callback, generate a new token on your app server, and call to JoinChannel [2/2] rejoin the channel.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        public virtual void OnRequestToken(RtcConnection connection) { }

        ///
        /// <summary>
        /// Occurs when the token expires in 30 seconds.
        /// When the token is about to expire in 30 seconds, the SDK triggers this callback to remind the app to renew the token.
        /// Upon receiving this callback, generate a new token on your server, and call RenewToken to pass the new token to the SDK.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="token"> The token that expires in 30 seconds.</param>
        ///
        public virtual void OnTokenPrivilegeWillExpire(RtcConnection connection, string token) { }

        ///
        /// <summary>
        /// Occurs when the first audio frame is published.
        /// The SDK triggers this callback under one of the following circumstances:
        /// The local client enables the audio module and calls JoinChannel [2/2] successfully.
        /// The local client calls MuteLocalAudioStream (true) and MuteLocalAudioStream(false) in sequence.
        /// The local client calls DisableAudio and EnableAudio in sequence.
        /// The local client calls
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user calling the JoinChannel [2/2] method until this callback is triggered.</param>
        ///
        public virtual void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when the first audio frame sent by a specified remote user is received.
        /// Deprecated:
        /// Use instead. OnRemoteAudioStateChanged
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="userId"> The ID of the remote user sending the audio frames.</param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling the JoinChannel [2/2] method until the SDK triggers this callback.</param>
        ///
        public virtual void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when the first audio frame sent by a specified remote user is received.
        /// Deprecated:
        /// Use OnRemoteAudioStateChanged instead. The SDK triggers this callback under one of the following circumstances:
        /// The remote user joins the channel and sends the audio stream.
        /// The remote user stops sending the audio stream and re-sends it after 15 seconds, and the possible reasons include:
        /// The remote user leaves the channel.
        /// The remote user is offline.
        /// The remote user calls MuteLocalAudioStream to stop sending the video stream.
        /// The remote user calls DisableAudio to disable video.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="elapsed"> The time elapsed (ms) from the local user calling the JoinChannel [2/2] method until the SDK triggers this callback.</param>
        ///
        public virtual void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed) { }

        ///
        /// <summary>
        /// Occurs when the local audio stream state changes.
        /// When the state of the local audio stream changes (including the state of the audio capture and encoding), the SDK triggers this callback to report the current state. This callback indicates the state of the local audio stream, and allows you to troubleshoot issues when audio exceptions occur.
        /// When the state is LOCAL_AUDIO_STREAM_STATE_FAILED (3), you can view the error information in the error parameter.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="state"> The state of the local audio. See LOCAL_AUDIO_STREAM_STATE .</param>
        ///
        /// <param name="error"> Local audio state error codes. See LOCAL_AUDIO_STREAM_ERROR .</param>
        ///
        public virtual void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error) { }

        ///
        /// <summary>
        /// Occurs when the remote audio state changes. 
        /// This callback indicates the state change of the remote audio stream.
        /// This callback can be inaccurate when the number of users (in the communication profile) or hosts (in the live broadcasting profile) in a channel exceeds 17.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The ID of the remote user whose audio state changes.</param>
        ///
        /// <param name="state"> The state of the remote audio, see REMOTE_AUDIO_STATE .</param>
        ///
        /// <param name="reason"> The reason of the remote audio state change, see REMOTE_AUDIO_STATE_REASON .</param>
        ///
        /// <param name="elapsed"> Time elapsed (ms) from the local user calling the JoinChannel [2/2] method until the SDK triggers this callback.</param>
        ///
        public virtual void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed) { }

        //todo fix with dcg
        ///
        /// <summary>
        /// Occurs when the most active remote speaker is detected.
        /// After a successful call of EnableAudioVolumeIndication , the SDK continuously detects which remote user has the loudest volume. During the current period, the remote user, who is detected as the loudest for the most times, is the most active user.
        /// When the number of users is no less than two and an active remote speaker exists, the SDK triggers this callback and reports the uid of the most active remote speaker.
        /// If the most active remote speaker is always the same user, the SDK triggers the OnActiveSpeaker callback only once.
        /// If the most active remote speaker changes to another user, the SDK triggers this callback again and reports the uid of the new active remote speaker.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="uid"> The user ID of the most active remote speaker.</param>
        ///
        public virtual void OnActiveSpeaker(RtcConnection connection, uint uid) { }

        ///
        /// <summary>
        /// Occurs when the user role switches in the interactive live streaming.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="oldRole"> Role that the user switches from: 
        ///  CLIENT_ROLE_BROADCASTER(1): Broadcaster.
        ///  CLIENT_ROLE_AUDIENCE(2): Audience. 
        ///  CLIENT_ROLE_TYPE .</param>
        ///
        /// <param name="newRole"> Role that the user switches to: 
        ///  CLIENT_ROLE_BROADCASTER(1): Broadcaster.
        ///  CLIENT_ROLE_AUDIENCE(2): Audience. 
        ///  CLIENT_ROLE_TYPE .</param>
        ///
        public virtual void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole) { }

        public virtual void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole) { }

        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted) { }

        ///
        /// <summary>
        /// Occurs when the media push state changes.
        /// When the media push state changes, the SDK triggers this callback and reports the URL address and the current state of the media push. This callback indicates the state of the media push. When exceptions occur, you can troubleshoot issues by referring to the detailed error descriptions in the error code.
        /// </summary>
        ///
        /// <param name="url"> The URL address where the state of the media push changes.</param>
        ///
        /// <param name="state"> The current state of the media push. See RTMP_STREAM_PUBLISH_STATE .</param>
        ///
        /// <param name="errCode"> The detailed error information for the media push. See RTMP_STREAM_PUBLISH_ERROR_TYPE .</param>
        ///
        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode) { }

        ///
        /// <summary>
        /// Reports events during the media push.
        /// </summary>
        ///
        /// <param name="url"> The URL for media push.</param>
        ///
        /// <param name="eventCode"> The event code of media push. See RTMP_STREAMING_EVENT .</param>
        ///
        public virtual void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode) { }

        ///
        /// <summary>
        /// Occurs when an RTMP or RTMPS stream is published.
        /// Deprecated:
        /// Please use OnRtmpStreamingStateChanged instead. Reports the result of publishing an RTMP or RTMPS stream.
        /// </summary>
        ///
        /// <param name="url"> The CDN streaming URL.</param>
        ///
        /// <param name="error"> Error codes of the RTMP or RTMPS streaming.
        ///  ERR_OK (0): The publishing succeeds.
        ///  ERR_FAILED (1): The publishing fails.
        ///  ERR_INVALID_ARGUMENT (-2): Invalid argument used.
        ///  If you do not call SetLiveTranscoding to configure 
        ///  LiveTranscoding before calling AddPublishStreamUrl , the SDK reports
        ///  ERR_INVALID_ARGUMENT.
        ///  ERR_TIMEDOUT (10): The publishing timed out.
        ///  ERR_ALREADY_IN_USE (19): The chosen URL address is
        ///  already in use for CDN live streaming.
        ///  ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH (130): You
        ///  cannot publish an encrypted stream.
        ///  ERR_PUBLISH_STREAM_CDN_ERROR (151): CDN related
        ///  error. Remove the original URL address and add a new one by calling
        ///  the RemovePublishStreamUrl and AddPublishStreamUrl methods.
        ///  ERR_PUBLISH_STREAM_NUM_REACH_LIMIT (152): The host
        ///  manipulates more than 10 URLs. Delete the unnecessary URLs before
        ///  adding new ones.
        ///  ERR_PUBLISH_STREAM_NOT_AUTHORIZED (153): The host
        ///  manipulates other hosts' URLs. Please check your app logic.
        ///  ERR_PUBLISH_STREAM_INTERNAL_SERVER_ERROR (154): An
        ///  error occurs in Agora's streaming server. Call the RemovePublishStreamUrl method to publish the streaming
        ///  again.
        ///  ERR_PUBLISH_STREAM_FORMAT_NOT_SUPPORTED (156): The
        ///  format of the CDN streaming URL is not supported. Check whether the
        ///  URL format is correct. </param>
        ///
        public virtual void OnStreamPublished(string url, int error) { }

        [Obsolete("Use onRtmpStreamingStateChanged instead of")]
        public virtual void OnStreamUnpublished(string url) { }

        ///
        /// <summary>
        /// Occurs when the publisher's transcoding is updated.
        /// SetLiveTranscoding When the class in the method LiveTranscoding updates, theOnTranscodingUpdated SDK triggers the callback to report the update information.
        /// If you callSetLiveTranscoding the method to set the class for the first timeLiveTranscoding, the SDK does not trigger this callback.
        /// </summary>
        ///
        public virtual void OnTranscodingUpdated() { }

        ///
        /// <summary>
        /// Occurs when the local audio route changes.
        /// This method is for Android, iOS and macOS only.
        /// </summary>
        ///
        /// <param name="routing"> The current audio routing. See AudioRoute .</param>
        ///
        public virtual void OnAudioRoutingChanged(int routing) { }

        //todo delete with dcg
        //public virtual void OnAudioSessionRestrictionResume() { }

        ///
        /// <summary>
        /// Occurs when the state of the media stream relay changes.
        /// The SDK returns the state of the current media relay with any error message.
        /// </summary>
        ///
        /// <param name="state"> The state code. See CHANNEL_MEDIA_RELAY_STATE .</param>
        ///
        /// <param name="code"> The error code of the channel media relay. See CHANNEL_MEDIA_RELAY_ERROR .</param>
        ///
        public virtual void OnChannelMediaRelayStateChanged(int state, int code) { }

        ///
        /// <summary>
        /// Reports events during the media stream relay.
        /// </summary>
        ///
        /// <param name="code"> The event code of channel media relay. See CHANNEL_MEDIA_RELAY_EVENT .</param>
        ///
        public virtual void OnChannelMediaRelayEvent(int code) { }

        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover) { }

        ///
        /// <summary>
        /// 远端订阅流已回退为音频流回调。 
        /// 如果你调用了 
        /// SetRemoteSubscribeFallbackOption 
        /// 并将
        /// option
        /// 设置为
        /// STREAM_FALLBACK_OPTION_AUDIO_ONLY
        /// ，当下行网络环境不理想、仅接收远端音频流时，或当下行网络改善、恢复订阅音视频流时，会触发该回调。 远端订阅流因弱网环境不能同时满足音视频而回退为小流时，你可以使用 
        /// OnRemoteVideoStats 
        /// 来监控远端视频大小流的切换。
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="isFallbackOrRecover"> true: 由于网络环境不理想，远端订阅流已回退为音频流；
        ///  false: 由于网络环境改善，订阅的音频流已恢复为音视频流。</param>
        ///
        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover) { }

        ///
        /// <summary>
        /// Reports the transport-layer statistics of each remote audio stream.
        /// Deprecated:
        /// Please use OnRemoteAudioStats instead. 
        /// This callback reports the transport-layer statistics, such as the packet loss rate and network time delay, once every two seconds after the local user receives an audio packet from a remote user. During a call, when the user receives the video packet sent by the remote user/host, the callback is triggered every 2 seconds.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the audio packets.</param>
        ///
        /// <param name="delay"> The network delay (ms) from the sender to the receiver.</param>
        ///
        /// <param name="lost"> The packet loss rate (%) of the audio packet sent from the remote user.</param>
        ///
        /// <param name="rxKBitRate"> The bitrate of the received audio (Kbps).</param>
        ///
        public virtual void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate) { }

        ///
        /// <summary>
        /// Reports the transport-layer statistics of each remote video stream.
        /// Deprecated:
        /// This callback is deprecated, use OnRemoteVideoStats instead. This callback reports the transport-layer statistics, such as the packet loss rate and network time delay, once every two seconds after the local user receives a video packet from a remote user.
        /// During a call, when the user receives the video packet sent by the remote user/host, the callback is triggered every 2 seconds.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="remoteUid"> The ID of the remote user sending the video packets.</param>
        ///
        /// <param name="delay"> The network delay (ms) from the sender to the receiver.</param>
        ///
        /// <param name="lost"> The packet loss rate (%) of the video packet sent from the remote user.</param>
        ///
        /// <param name="rxKBitRate"> The bitrate of the received video (Kbps).</param>
        ///
        public virtual void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, UInt16 delay, UInt16 lost, UInt16 rxKBitRate) { }

        ///
        /// <summary>
        /// Occurs when the network connection state changes.
        /// When the network connection state changes, the SDK triggers this callback and reports the current connection state and the reason for the change.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="state"> The current connection state.  CONNECTION_STATE_TYPE </param>
        ///
        /// <param name="reason"> The reason for a connection state change. See CONNECTION_CHANGED_REASON_TYPE .</param>
        ///
        public virtual void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason) { }

        ///
        /// <summary>
        /// Occurs when the local network type changes.
        /// This callback occurs when the connection state of the local user changes. You can get the connection state and reason for the state change in this callback. When the network connection is interrupted, this callback indicates whether the interruption is caused by a network type change or poor network conditions.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="type"> Network types: See NETWORK_TYPE .</param>
        ///
        public virtual void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type) { }

        ///
        /// <summary>
        /// Reports the built-in encryption errors.
        /// When encryption is enabled by calling EnableEncryption , the SDK triggers this callback if an error occurs in encryption or decryption on the sender or the receiver side.
        /// </summary>
        ///
        /// <param name="connection"> The connection information. See RtcConnection .</param>
        ///
        /// <param name="errorType"> For details about the error type, see ENCRYPTION_ERROR_TYPE .</param>
        ///
        public virtual void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType) { }

        public virtual void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason) { }

        public virtual void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string userAccount) { }

        ///
        /// <summary>
        /// Occurs when the SDK cannot get the device permission.
        /// When the SDK fails to get the device permission, the SDK triggers this callback to report which device permission cannot be got.
        /// This method is for Android and iOS only.
        /// </summary>
        ///
        /// <param name="permissionType"> The type of the device permission. See PERMISSION_TYPE .</param>
        ///
        public virtual void OnPermissionError(PERMISSION_TYPE permissionType) { }

        ///
        /// <summary>
        /// Occurs when the local user registers a user account.
        /// After the local user successfully calls RegisterLocalUserAccount to register the user account or calls JoinChannelWithUserAccount [2/2] to join a channel, the SDK triggers the callback and informs the local user's UID and User Account.
        /// </summary>
        ///
        /// <param name="uid"> The ID of the local user.</param>
        ///
        /// <param name="userAccount"> The user account of the local user.</param>
        ///
        public virtual void OnLocalUserRegistered(uint uid, string userAccount) { }

        ///
        /// <summary>
        /// Occurs when the SDK gets the user ID and user account of the remote user.
        /// After a remote user joins the channel, the SDK gets the UID and user account of the remote user, caches them in a mapping table object, and triggers this callback on the local client.
        /// </summary>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="info"> The UserInfo object that contains the user ID and user account of the remote user. See for details UserInfo .</param>
        ///
        public virtual void OnUserInfoUpdated(uint uid, UserInfo info) { }

        ///
        /// <summary>
        /// Occurs when the audio subscribing state changes.
        /// </summary>
        ///
        /// <param name="channel"> The channel name.</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="oldState"> The previous subscribing status. See STREAM_SUBSCRIBE_STATE .</param>
        ///
        /// <param name="newState"> The current subscribing status. See STREAM_SUBSCRIBE_STATE.</param>
        ///
        /// <param name="elapseSinceLastState"> The time elapsed (ms) from the previous state to the current state.</param>
        ///
        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState) { }

        ///
        /// <summary>
        /// Occurs when the video subscribing state changes.
        /// </summary>
        ///
        /// <param name="channel"> The channel name.</param>
        ///
        /// <param name="uid"> The user ID of the remote user.</param>
        ///
        /// <param name="oldState"> The previous subscribing status. See STREAM_SUBSCRIBE_STATE .</param>
        ///
        /// <param name="newState"> The current subscribing status. See STREAM_SUBSCRIBE_STATE.</param>
        ///
        /// <param name="elapseSinceLastState"> The time elapsed (ms) from the previous state to the current state.</param>
        ///
        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState) { }

        ///
        /// <summary>
        /// Occurs when the audio publishing state changes.
        /// </summary>
        ///
        /// <param name="channel"> The channel name.</param>
        ///
        /// <param name="oldState"> The previous subscribing status. See STREAM_PUBLISH_STATE .</param>
        ///
        /// <param name="newState"> The current subscribing status. See STREAM_PUBLISH_STATE.</param>
        ///
        /// <param name="elapseSinceLastState"> The time elapsed (ms) from the previous state to the current state.</param>
        ///
        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState) { }

        ///
        /// <summary>
        /// Occurs when the video publishing state changes.
        /// </summary>
        ///
        /// <param name="channel"> The channel name.</param>
        ///
        /// <param name="oldState"> The previous subscribing status. See STREAM_PUBLISH_STATE .</param>
        ///
        /// <param name="newState"> The current subscribing status. See STREAM_PUBLISH_STATE.</param>
        ///
        /// <param name="elapseSinceLastState"> The time elapsed (ms) from the previous state to the current state.</param>
        ///
        public virtual void OnVideoPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState) { }

        ///
        /// <summary>
        /// The event callback of the extension.
        /// To listen for events while the extension is running, you need to register this callback.
        /// </summary>
        ///
        /// <param name="value"> The value of the extension key.</param>
        ///
        /// <param name="key"> The key of the extension.</param>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <param name="ext_name"> The name of the extension.</param>
        ///
        public virtual void OnExtensionEvent(string provider, string ext_name, string key, string value) { }

        ///
        /// <summary>
        /// Occurs when the extension is enabled.
        /// After a successful call of EnableExtension (true), this callback is triggered.
        /// </summary>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <param name="ext_name"> The name of the extension.</param>
        ///
        public virtual void OnExtensionStarted(string provider, string ext_name) { }

        ///
        /// <summary>
        /// Occurs when the extension is disabled.
        /// After a successful call of EnableExtension (false), this callback is triggered.
        /// </summary>
        ///
        /// <param name="ext_name"> The name of the extension.</param>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        public virtual void OnExtensionStopped(string provider, string ext_name) { }

        ///
        /// <summary>
        /// Occurs when the extension runs incorrectly.
        /// When calling EnableExtension (true) fails or the extension runs in error, the extension triggers this callback and reports the error code and reason.
        /// </summary>
        ///
        /// <param name="provider"> The name of the extension provider.</param>
        ///
        /// <param name="ext_name"> The name of the extension.</param>
        ///
        /// <param name="error"> The error code. For details, see the extension documentation provided by the extension provider.</param>
        ///
        /// <param name="msg"> Reason. For details, see the extension documentation provided by the extension provider.</param>
        ///
        public virtual void OnExtensionErrored(string provider, string ext_name, int error, string msg) { }

        ///
        /// <summary>
        /// Occurs when the CDN streaming state changes.
        /// When the host directly pushes streams to the CDN, if the streaming state changes, the SDK triggers this callback to report the changed streaming state, error codes, and other information. You can troubleshoot issues by referring to this callback.
        /// </summary>
        ///
        /// <param name="state"> The current CDN streaming state. See DIRECT_CDN_STREAMING_STATE .</param>
        ///
        /// <param name="error"> The reason for the CDN streaming error. See DIRECT_CDN_STREAMING_ERROR .</param>
        ///
        /// <param name="message"> The information about the changed streaming state.</param>
        ///
        public virtual void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message) { }

        ///
        /// <summary>
        /// Reports the CDN streaming statistics.
        /// When the host directly pushes streams to the CDN, the SDK triggers this callback every one second.
        /// </summary>
        ///
        /// <param name="stats"> The statistics of the current CDN streaming. See DirectCdnStreamingStats .</param>
        ///
        public virtual void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats) { }
    };

}