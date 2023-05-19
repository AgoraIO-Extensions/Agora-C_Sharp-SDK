﻿using System;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    using int64_t = Int64;
    using view_t = Int64;
    using uint64_t = UInt64;

    #region AgoraBase

    internal enum AppType
    {
        APP_TYPE_NATIVE = 0,
        APP_TYPE_COCOS = 1,
        APP_TYPE_UNITY = 2,
        APP_TYPE_ELECTRON = 3,
        APP_TYPE_FLUTTER = 4,
        APP_TYPE_UNREAL = 5,
        APP_TYPE_XAMARIN = 6,
        APP_TYPE_API_CLOUD = 7,
        APP_TYPE_REACT_NATIVE = 8,
        APP_TYPE_PYTHON = 9,
        APP_TYPE_COCOS_CREATOR = 10,
        APP_TYPE_RUST = 11,
        APP_TYPE_C_SHARP = 12,
        APP_TYPE_CEF = 13,
        APP_TYPE_UNI_APP = 14
    };

    ///
    /// <summary>
    /// The channel profile.
    /// </summary>
    ///
    public enum CHANNEL_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 0: Communication. Use this profile when there are only two users in the channel.
        /// </summary>
        ///
        CHANNEL_PROFILE_COMMUNICATION = 0,

        ///
        /// <summary>
        /// 1: Live streaming. Live streaming. Use this profile when there are more than two users in the channel.
        /// </summary>
        ///
        CHANNEL_PROFILE_LIVE_BROADCASTING = 1,

        [Obsolete]
        ///
        /// <summary>
        /// 2: Gaming. This profile is deprecated.
        /// </summary>
        ///
        CHANNEL_PROFILE_GAME = 2,

        [Obsolete]
        ///
        /// <summary>
        /// Cloud gaming. The scenario is optimized for latency. Use this profile if the use case requires frequent interactions between users.
        /// </summary>
        ///
        CHANNEL_PROFILE_CLOUD_GAMING = 3,

        [Obsolete]
        ///
        /// @ignore
        ///
        CHANNEL_PROFILE_COMMUNICATION_1v1 = 4,
    };

    ///
    /// @ignore
    ///
    public enum WARN_CODE_TYPE
    {
        ///
        /// @ignore
        ///
        WARN_INVALID_VIEW = 8,
        ///
        /// @ignore
        ///
        WARN_INIT_VIDEO = 16,
        ///
        /// @ignore
        ///
        WARN_PENDING = 20,
        ///
        /// @ignore
        ///
        WARN_NO_AVAILABLE_CHANNEL = 103,
        ///
        /// @ignore
        ///
        WARN_LOOKUP_CHANNEL_TIMEOUT = 104,
        ///
        /// @ignore
        ///
        WARN_LOOKUP_CHANNEL_REJECTED = 105,
        ///
        /// @ignore
        ///
        WARN_OPEN_CHANNEL_TIMEOUT = 106,
        ///
        /// @ignore
        ///
        WARN_OPEN_CHANNEL_REJECTED = 107,
        ///
        /// @ignore
        ///
        WARN_SWITCH_LIVE_VIDEO_TIMEOUT = 111,
        ///
        /// @ignore
        ///
        WARN_SET_CLIENT_ROLE_TIMEOUT = 118,
        ///
        /// @ignore
        ///
        WARN_OPEN_CHANNEL_INVALID_TICKET = 121,
        ///
        /// @ignore
        ///
        WARN_OPEN_CHANNEL_TRY_NEXT_VOS = 122,
        ///
        /// @ignore
        ///
        WARN_CHANNEL_CONNECTION_UNRECOVERABLE = 131,
        ///
        /// @ignore
        ///
        WARN_CHANNEL_CONNECTION_IP_CHANGED = 132,
        ///
        /// @ignore
        ///
        WARN_CHANNEL_CONNECTION_PORT_CHANGED = 133,
        ///
        /// @ignore
        ///
        WARN_CHANNEL_SOCKET_ERROR = 134,
        ///
        /// @ignore
        ///
        WARN_AUDIO_MIXING_OPEN_ERROR = 701,
        ///
        /// @ignore
        ///
        WARN_ADM_RUNTIME_PLAYOUT_WARNING = 1014,
        ///
        /// @ignore
        ///
        WARN_ADM_RUNTIME_RECORDING_WARNING = 1016,
        ///
        /// @ignore
        ///
        WARN_ADM_RECORD_AUDIO_SILENCE = 1019,
        ///
        /// @ignore
        ///
        WARN_ADM_PLAYOUT_MALFUNCTION = 1020,
        ///
        /// @ignore
        ///
        WARN_ADM_RECORD_MALFUNCTION = 1021,
        ///
        /// @ignore
        ///
        WARN_ADM_RECORD_AUDIO_LOWLEVEL = 1031,
        ///
        /// @ignore
        ///
        WARN_ADM_PLAYOUT_AUDIO_LOWLEVEL = 1032,
        ///
        /// @ignore
        ///
        WARN_ADM_WINDOWS_NO_DATA_READY_EVENT = 1040,
        ///
        /// @ignore
        ///
        WARN_APM_HOWLING = 1051,
        ///
        /// @ignore
        ///
        WARN_ADM_GLITCH_STATE = 1052,
        ///
        /// @ignore
        ///
        WARN_ADM_IMPROPER_SETTINGS = 1053,
        ///
        /// @ignore
        ///
        WARN_ADM_WIN_CORE_NO_RECORDING_DEVICE = 1322,
        ///
        /// @ignore
        ///
        WARN_ADM_WIN_CORE_NO_PLAYOUT_DEVICE = 1323,
        ///
        /// @ignore
        ///
        WARN_ADM_WIN_CORE_IMPROPER_CAPTURE_RELEASE = 1324,
    };

    ///
    /// <summary>
    /// Error codes.
    /// An error code indicates that the SDK encountered an unrecoverable error that requires application intervention. For example, an error is returned when the camera fails to open, and the app needs to inform the user that the camera cannot be used.
    /// </summary>
    ///
    public enum ERROR_CODE_TYPE
    {
        ///
        /// <summary>
        /// 0: No error.
        /// </summary>
        ///
        ERR_OK = 0,
        ///
        /// <summary>
        /// 1: General error with no classified reason. Try calling the method again.
        /// </summary>
        ///
        ERR_FAILED = 1,
        ///
        /// <summary>
        /// 2: An invalid parameter is used. For example, the specified channel name includes illegal characters. Reset the parameter.
        /// </summary>
        ///
        ERR_INVALID_ARGUMENT = 2,
        ///
        /// <summary>
        /// 3: The SDK is not ready. Possible reasons include the following:The initialization of IRtcEngine fails. Reinitialize the IRtcEngine.No user has joined the channel when the method is called. Check the code logic.The user has not left the channel when the Rate or Complain method is called. Check the code logic.The audio module is disabled.The program is not complete.
        /// </summary>
        ///
        ERR_NOT_READY = 3,
        ///
        /// <summary>
        /// 4: The IRtcEngine does not support the request. Possible reasons include the following:The built-in encryption mode is incorrect, or the SDK fails to load the external encryption library. Check the encryption mode setting, or reload the external encryption library.
        /// </summary>
        ///
        ERR_NOT_SUPPORTED = 4,
        ///
        /// <summary>
        /// 5: The request is rejected. Possible reasons include the following:The IRtcEngine initialization fails. Reinitialize the IRtcEngine.The channel name is set as the empty string "" when joining the channel. Reset the channel name.When the JoinChannelEx method is called to join multiple channels, the specified channel name is already in use. Reset the channel name.
        /// </summary>
        ///
        ERR_REFUSED = 5,
        ///
        /// <summary>
        /// 6: The buffer size is insufficient to store the returned data.
        /// </summary>
        ///
        ERR_BUFFER_TOO_SMALL = 6,
        ///
        /// <summary>
        /// 7: A method is called before the initialization of IRtcEngine. Ensure that the IRtcEngine object is initialized before using this method.
        /// </summary>
        ///
        ERR_NOT_INITIALIZED = 7,
        ///
        /// <summary>
        /// 8: Invalid state.
        /// </summary>
        ///
        ERR_INVALID_STATE = 8,
        ///
        /// <summary>
        /// 9: Permission to access is not granted. Check whether your app has access to the audio and video device.
        /// </summary>
        ///
        ERR_NO_PERMISSION = 9,
        ///
        /// <summary>
        /// 10: A timeout occurs. Some API calls require the SDK to return the execution result. This error occurs if the SDK takes too long (more than 10 seconds) to return the result.
        /// </summary>
        ///
        ERR_TIMEDOUT = 10,
        ///
        /// @ignore
        ///
        ERR_CANCELED = 11,
        ///
        /// @ignore
        ///
        ERR_TOO_OFTEN = 12,
        ///
        /// @ignore
        ///
        ERR_BIND_SOCKET = 13,
        ///
        /// @ignore
        ///
        ERR_NET_DOWN = 14,
        ///
        /// <summary>
        /// 17: The request to join the channel is rejected. Possible reasons include the following:The user is already in the channel. Agora recommends that you use the OnConnectionStateChanged callback to determine whether the user exists in the channel. Do not call this method to join the channel unless you receive the CONNECTION_STATE_DISCONNECTED(1) state.After calling StartEchoTest [3/3] for the call test, the user tries to join the channel without calling StopEchoTest to end the current test. To join a channel, the call test must be ended by calling StopEchoTest.
        /// </summary>
        ///
        ERR_JOIN_CHANNEL_REJECTED = 17,
        ///
        /// <summary>
        /// 18: Fails to leave the channel. Possible reasons include the following:The user has left the channel before calling the LeaveChannel [2/2] method. Stop calling this method to clear this error.The user calls the LeaveChannel [2/2] method to leave the channel before joining the channel. In this case, no extra operation is needed.
        /// </summary>
        ///
        ERR_LEAVE_CHANNEL_REJECTED = 18,
        ///
        /// <summary>
        /// 19: Resources are already in use.
        /// </summary>
        ///
        ERR_ALREADY_IN_USE = 19,
        ///
        /// <summary>
        /// 20: The request is abandoned by the SDK, possibly because the request has been sent too frequently.
        /// </summary>
        ///
        ERR_ABORTED = 20,
        ///
        /// <summary>
        /// 21: The IRtcEngine fails to initialize and has crashed because of specific Windows firewall settings.
        /// </summary>
        ///
        ERR_INIT_NET_ENGINE = 21,
        ///
        /// <summary>
        /// 22: The SDK fails to allocate resources because your app uses too many system resources or system resources are insufficient.
        /// </summary>
        ///
        ERR_RESOURCE_LIMITED = 22,
        ///
        /// <summary>
        /// 101: The specified App ID is invalid. Rejoin the channel with a valid App ID.
        /// </summary>
        ///
        ERR_INVALID_APP_ID = 101,
        ///
        /// <summary>
        /// 102: The specified channel name is invalid. A possible reason is that the parameter's data type is incorrect. Rejoin the channel with a valid channel name.
        /// </summary>
        ///
        ERR_INVALID_CHANNEL_NAME = 102,
        ///
        /// <summary>
        /// 103: Fails to get server resources in the specified region. Try another region when initializing IRtcEngine.
        /// </summary>
        ///
        ERR_NO_SERVER_RESOURCES = 103,
        ///
        /// <summary>
        /// 109: The current token has expired. Apply for a new token on the server and call RenewToken .Deprecated:This enumerator is deprecated. Use CONNECTION_CHANGED_TOKEN_EXPIRED(9) in the OnConnectionStateChanged callback instead.
        /// </summary>
        ///
        ERR_TOKEN_EXPIRED = 109,
        ///
        /// <summary>
        /// 110: Invalid token. Typical reasons include the following:App Certificate is enabled in Agora Console, but the code still uses App ID for authentication. Once App Certificate is enabled for a project, you must use token-based authentication.The uid used to generate the token is not the same as the uid used to join the channel.Deprecated:This enumerator is deprecated. Use CONNECTION_CHANGED_INVALID_TOKEN(8) in the OnConnectionStateChanged callback instead.
        /// </summary>
        ///
        ERR_INVALID_TOKEN = 110,
        ///
        /// <summary>
        /// 111: The network connection is interrupted. The SDK triggers this callback when it loses connection with the server for more than four seconds after the connection is established.
        /// </summary>
        ///
        ERR_CONNECTION_INTERRUPTED = 111,
        ///
        /// <summary>
        /// 112: The network connection is lost. Occurs when the SDK cannot reconnect to Agora's edge server 10 seconds after its connection to the server is interrupted.
        /// </summary>
        ///
        ERR_CONNECTION_LOST = 112,
        ///
        /// <summary>
        /// 113: The user is not in the channel when calling the SendStreamMessage method.
        /// </summary>
        ///
        ERR_NOT_IN_CHANNEL = 113,
        ///
        /// <summary>
        /// 114: The data size exceeds 1 KB when calling the SendStreamMessage method.
        /// </summary>
        ///
        ERR_SIZE_TOO_LARGE = 114,
        ///
        /// <summary>
        /// 115: The data bitrate exceeds 6 KB/s when calling the SendStreamMessage method.
        /// </summary>
        ///
        ERR_BITRATE_LIMIT = 115,
        ///
        /// <summary>
        /// 116: More than five data streams are created when calling the CreateDataStream [2/2] method.
        /// </summary>
        ///
        ERR_TOO_MANY_DATA_STREAMS = 116,
        ///
        /// <summary>
        /// 117: The data stream transmission times out.
        /// </summary>
        ///
        ERR_STREAM_MESSAGE_TIMEOUT = 117,
        ///
        /// <summary>
        /// 119: Switching roles fails, try rejoining the channel.
        /// </summary>
        ///
        ERR_SET_CLIENT_ROLE_NOT_AUTHORIZED = 119,
        ///
        /// <summary>
        /// 120: Decryption fails. The user might have entered an incorrect password to join the channel. Check the entered password, or tell the user to try rejoining the channel.
        /// </summary>
        ///
        ERR_DECRYPTION_FAILED = 120,
        ///
        /// <summary>
        /// 121: The user ID is invalid.
        /// </summary>
        ///
        ERR_INVALID_USER_ID = 121,
        ///
        /// <summary>
        /// 123: The user is banned from the server.
        /// </summary>
        ///
        ERR_CLIENT_IS_BANNED_BY_SERVER = 123,
        ///
        /// <summary>
        /// 130: The SDK does not support pushing encrypted streams to CDN.
        /// </summary>
        ///
        ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH = 130,
        ///
        /// @ignore
        ///
        ERR_LICENSE_CREDENTIAL_INVALID = 131,
        ///
        /// <summary>
        /// 134: The user account is invalid, possibly because it contains invalid parameters.
        /// </summary>
        ///
        ERR_INVALID_USER_ACCOUNT = 134,
        ///
        /// @ignore
        ///
        ERR_MODULE_NOT_FOUND = 157,
        ///
        /// @ignore
        ///
        ERR_CERT_RAW = 157,
        ///
        /// @ignore
        ///
        ERR_CERT_JSON_PART = 158,
        ///
        /// @ignore
        ///
        ERR_CERT_JSON_INVAL = 159,
        ///
        /// @ignore
        ///
        ERR_CERT_JSON_NOMEM = 160,
        ///
        /// @ignore
        ///
        ERR_CERT_CUSTOM = 161,
        ///
        /// @ignore
        ///
        ERR_CERT_CREDENTIAL = 162,
        ///
        /// @ignore
        ///
        ERR_CERT_SIGN = 163,
        ///
        /// @ignore
        ///
        ERR_CERT_FAIL = 164,
        ///
        /// @ignore
        ///
        ERR_CERT_BUF = 165,
        ///
        /// @ignore
        ///
        ERR_CERT_NULL = 166,
        ///
        /// @ignore
        ///
        ERR_CERT_DUEDATE = 167,
        ///
        /// @ignore
        ///
        ERR_CERT_REQUEST = 168,
        ///
        /// @ignore
        ///
        ERR_PCMSEND_FORMAT = 200,
        ///
        /// @ignore
        ///
        ERR_PCMSEND_BUFFEROVERFLOW = 201,
        ///
        /// @ignore
        ///
        ERR_LOGIN_ALREADY_LOGIN = 428,
        ///
        /// <summary>
        /// 1001: The SDK fails to load the media engine.
        /// </summary>
        ///
        ERR_LOAD_MEDIA_ENGINE = 1001,
        ///
        /// <summary>
        /// 1005: A general error occurs (no specified reason). Check whether the audio device is already in use by another app, or try rejoining the channel.
        /// </summary>
        ///
        ERR_ADM_GENERAL_ERROR = 1005,
        ///
        /// <summary>
        /// 1008: An error occurs when initializing the playback device. Check whether the playback device is already in use by another app, or try rejoining the channel.
        /// </summary>
        ///
        ERR_ADM_INIT_PLAYOUT = 1008,
        ///
        /// <summary>
        /// 1009: An error occurs when starting the playback device. Check the playback device.
        /// </summary>
        ///
        ERR_ADM_START_PLAYOUT = 1009,
        ///
        /// <summary>
        /// 1010: An error occurs when stopping the playback device.
        /// </summary>
        ///
        ERR_ADM_STOP_PLAYOUT = 1010,
        ///
        /// <summary>
        /// 1011: An error occurs when initializing the recording device. Check the recording device, or try rejoining the channel.
        /// </summary>
        ///
        ERR_ADM_INIT_RECORDING = 1011,
        ///
        /// <summary>
        /// 1012: An error occurs when starting the recording device. Check the recording device.
        /// </summary>
        ///
        ERR_ADM_START_RECORDING = 1012,
        ///
        /// <summary>
        /// 1013: An error occurs when stopping the recording device.
        /// </summary>
        ///
        ERR_ADM_STOP_RECORDING = 1013,
        ///
        /// <summary>
        /// 1501: Permission to access the camera is not granted. Check whether permission to access the camera permission is granted.
        /// </summary>
        ///
        ERR_VDM_CAMERA_NOT_AUTHORIZED = 1501,
    };


    ///
    /// @ignore
    ///
    public enum LICENSE_ERROR_TYPE
    {

        ///
        /// @ignore
        ///
        LICENSE_ERR_INVALID = 1,
        ///
        /// @ignore
        ///
        LICENSE_ERR_EXPIRE = 2,
        ///
        /// @ignore
        ///
        LICENSE_ERR_MINUTES_EXCEED = 3,
        ///
        /// @ignore
        ///
        LICENSE_ERR_LIMITED_PERIOD = 4,
        ///
        /// @ignore
        ///
        LICENSE_ERR_DIFF_DEVICES = 5,
        ///
        /// @ignore
        ///
        LICENSE_ERR_INTERNAL = 99,
    };

    ///
    /// <summary>
    /// The operation permissions of the SDK on the audio session.
    /// </summary>
    ///
    public enum AUDIO_SESSION_OPERATION_RESTRICTION
    {
        ///
        /// <summary>
        /// No restriction, the SDK can change the audio session.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_NONE = 0,

        ///
        /// <summary>
        /// The SDK cannot change the audio session category.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_SET_CATEGORY = 1,

        ///
        /// <summary>
        /// The SDK cannot change the audio session category, mode, or categoryOptions.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION = 1 << 1,

        ///
        /// <summary>
        /// The SDK keeps the audio session active when the user leaves the channel, for example, to play an audio file in the background.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_DEACTIVATE_SESSION = 1 << 2,

        ///
        /// <summary>
        /// Completely restricts the operation permissions of the SDK on the audio session; the SDK cannot change the audio session.
        /// </summary>
        ///
        AUDIO_SESSION_OPERATION_RESTRICTION_ALL = 1 << 7,
    };

    ///
    /// <summary>
    /// Reasons for a user being offline.
    /// </summary>
    ///
    public enum USER_OFFLINE_REASON_TYPE
    {
        ///
        /// <summary>
        /// 0: The user quits the call.
        /// </summary>
        ///
        USER_OFFLINE_QUIT = 0,

        ///
        /// <summary>
        /// 1: The SDK times out and the user drops offline because no data packet is received within a certain period of time.If the user quits the call and the message is not passed to the SDK (due to an unreliable channel), the SDK assumes the user dropped offline.
        /// </summary>
        ///
        USER_OFFLINE_DROPPED = 1,

        ///
        /// <summary>
        /// 2: The user switches the client role from the host to the audience.
        /// </summary>
        ///
        USER_OFFLINE_BECOME_AUDIENCE = 2,
    };

    ///
    /// <summary>
    /// Network quality types.
    /// </summary>
    ///
    public enum QUALITY_TYPE
    {
        [Obsolete("This member is deprecated")]
        ///
        /// <summary>
        /// 0: The network quality is unknown.
        /// </summary>
        ///
        QUALITY_UNKNOWN = 0,

        ///
        /// <summary>
        /// 1: The network quality is excellent.
        /// </summary>
        ///
        QUALITY_EXCELLENT = 1,

        ///
        /// <summary>
        /// 2: The network quality is quite good, but the bitrate may be slightly lower than excellent.
        /// </summary>
        ///
        QUALITY_GOOD = 2,

        ///
        /// <summary>
        /// 3: Users can feel the communication is slightly impaired.
        /// </summary>
        ///
        QUALITY_POOR = 3,

        ///
        /// <summary>
        /// 4: Users cannot communicate smoothly.
        /// </summary>
        ///
        QUALITY_BAD = 4,

        ///
        /// <summary>
        /// 5: The quality is so bad that users can barely communicate.
        /// </summary>
        ///
        QUALITY_VBAD = 5,

        ///
        /// <summary>
        /// 6: The network is down and users cannot communicate at all.
        /// </summary>
        ///
        QUALITY_DOWN = 6,

        ///
        /// <summary>
        /// 7: Users cannot detect the network quality (not in use).
        /// </summary>
        ///
        QUALITY_UNSUPPORTED = 7,

        ///
        /// <summary>
        /// 8: Detecting the network quality.
        /// </summary>
        ///
        QUALITY_DETECTING = 8
    };

    ///
    /// @ignore
    ///
    public enum FIT_MODE_TYPE
    {
        ///
        /// @ignore
        ///
        MODE_COVER = 1,

        ///
        /// @ignore
        ///
        MODE_CONTAIN = 2,
    };

    ///
    /// <summary>
    /// The clockwise rotation of the video.
    /// </summary>
    ///
    public enum VIDEO_ORIENTATION
    {
        ///
        /// <summary>
        /// 0: (Default) No rotation.
        /// </summary>
        ///
        VIDEO_ORIENTATION_0 = 0,

        ///
        /// <summary>
        /// 90: 90 degrees.
        /// </summary>
        ///
        VIDEO_ORIENTATION_90 = 90,

        ///
        /// <summary>
        /// 180: 180 degrees.
        /// </summary>
        ///
        VIDEO_ORIENTATION_180 = 180,

        ///
        /// <summary>
        /// 270: 270 degrees.
        /// </summary>
        ///
        VIDEO_ORIENTATION_270 = 270
    };

    ///
    /// <summary>
    /// The video frame rate.
    /// </summary>
    ///
    public enum FRAME_RATE
    {
        ///
        /// <summary>
        /// 1: 1 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_1 = 1,

        ///
        /// <summary>
        /// 7: 7 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_7 = 7,

        ///
        /// <summary>
        /// 10: 10 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_10 = 10,

        ///
        /// <summary>
        /// 15: 15 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_15 = 15,

        ///
        /// <summary>
        /// 24: 24 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_24 = 24,

        ///
        /// <summary>
        /// 30: 30 fps
        /// </summary>
        ///
        FRAME_RATE_FPS_30 = 30,

        ///
        /// <summary>
        /// 60: 60 fpsFor Windows and macOS only.
        /// </summary>
        ///
        FRAME_RATE_FPS_60 = 60,
    };

    ///
    /// @ignore
    ///
    public enum FRAME_WIDTH
    {
        ///
        /// @ignore
        ///
        FRAME_WIDTH_960 = 960,
    };

    ///
    /// @ignore
    ///
    public enum FRAME_HEIGHT
    {
        ///
        /// @ignore
        ///
        FRAME_HEIGHT_540 = 540,
    };

    ///
    /// <summary>
    /// The video frame type.
    /// </summary>
    ///
    public enum VIDEO_FRAME_TYPE
    {
        ///
        /// <summary>
        /// 0: A black frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_BLANK_FRAME = 0,

        ///
        /// <summary>
        /// 3: Key frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_KEY_FRAME = 3,

        ///
        /// <summary>
        /// 4: Delta frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_DELTA_FRAME = 4,

        ///
        /// <summary>
        /// 5: The B frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_B_FRAME = 5,

        ///
        /// <summary>
        /// 6: A discarded frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_DROPPABLE_FRAME = 6,

        ///
        /// <summary>
        /// Unknown frame.
        /// </summary>
        ///
        VIDEO_FRAME_TYPE_UNKNOW = 7
    };

    ///
    /// @ignore
    ///
    public enum VIDEO_FRAME_TYPE_NATIVE
    {
        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_BLANK_FRAME = 0,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_KEY_FRAME = 3,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_DELTA_FRAME = 4,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_B_FRAME = 5,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_DROPPABLE_FRAME = 6,

        ///
        /// @ignore
        ///
        VIDEO_FRAME_TYPE_UNKNOW = 7
    };

    ///
    /// <summary>
    /// Video output orientation mode.
    /// </summary>
    ///
    public enum ORIENTATION_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) The output video always follows the orientation of the captured video. The receiver takes the rotational information passed on from the video encoder. This mode applies to scenarios where video orientation can be adjusted on the receiver.If the captured video is in landscape mode, the output video is in landscape mode.If the captured video is in portrait mode, the output video is in portrait mode.
        /// </summary>
        ///
        ORIENTATION_MODE_ADAPTIVE = 0,

        ///
        /// <summary>
        /// 1: In this mode, the SDK always outputs videos in landscape (horizontal) mode. If the captured video is in portrait mode, the video encoder crops it to fit the output. Applies to situations where the receiving end cannot process the rotational information. For example, CDN live streaming.
        /// </summary>
        ///
        ORIENTATION_MODE_FIXED_LANDSCAPE = 1,

        ///
        /// <summary>
        /// 2: In this mode, the SDK always outputs video in portrait (portrait) mode. If the captured video is in landscape mode, the video encoder crops it to fit the output. Applies to situations where the receiving end cannot process the rotational information. For example, CDN live streaming.
        /// </summary>
        ///
        ORIENTATION_MODE_FIXED_PORTRAIT = 2,
    };

    ///
    /// <summary>
    /// Video degradation preferences when the bandwidth is a constraint.
    /// </summary>
    ///
    public enum DEGRADATION_PREFERENCE
    {
        ///
        /// <summary>
        /// 0: (Default) Prefers to reduce the video frame rate while maintaining video resolution during video encoding under limited bandwidth. This degradation preference is suitable for scenarios where video quality is prioritized.
        /// </summary>
        ///
        MAINTAIN_QUALITY = 0,

        ///
        /// <summary>
        /// 1: Reduces the video resolution while maintaining the video frame rate during video encoding under limited bandwidth. This degradation preference is suitable for scenarios where smoothness is prioritized and video quality is allowed to be reduced.
        /// </summary>
        ///
        MAINTAIN_FRAMERATE = 1,

        ///
        /// <summary>
        /// 2: Reduces the video frame rate and video resolution simultaneously during video encoding under limited bandwidth. The MAINTAIN_BALANCED has a lower reduction than MAINTAIN_QUALITY and MAINTAIN_FRAMERATE, and this preference is suitable for scenarios where both smoothness and video quality are a priority.The resolution of the video sent may change, so remote users need to handle this issue. See OnVideoSizeChanged .
        /// </summary>
        ///
        MAINTAIN_BALANCED = 2,

        ///
        /// <summary>
        /// 3: Reduces the video frame rate while maintaining the video resolution during video encoding under limited bandwidth. This degradation preference is suitable for scenarios where video quality is prioritized.
        /// </summary>
        ///
        MAINTAIN_RESOLUTION = 3,

        ///
        /// @ignore
        ///
        DISABLED = 100,
    };

    ///
    /// <summary>
    /// The video dimension.
    /// </summary>
    ///
    public class VideoDimensions
    {
        public VideoDimensions()
        {
            width = 640;
            height = 480;
        }

        public VideoDimensions(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        ///
        /// <summary>
        /// The width (pixels) of the video.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height (pixels) of the video.
        /// </summary>
        ///
        public int height;
    };

    ///
    /// <summary>
    /// The highest frame rate supported by the screen sharing device.
    /// </summary>
    ///
    public enum SCREEN_CAPTURE_FRAMERATE_CAPABILITY
    {
        ///
        /// <summary>
        /// 0: The device supports the frame rate of up to 15 fps.
        /// </summary>
        ///
        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_15_FPS = 0,
        ///
        /// <summary>
        /// 1: The device supports the frame rate of up to 30 fps.
        /// </summary>
        ///
        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_30_FPS = 1,
        ///
        /// <summary>
        /// 2: The device supports the frame rate of up to 60 fps.
        /// </summary>
        ///
        SCREEN_CAPTURE_FRAMERATE_CAPABILITY_60_FPS = 2,
    };

    ///
    /// <summary>
    /// The encoding bitrate of the video.
    /// </summary>
    ///
    public enum BITRATE
    {
        ///
        /// <summary>
        /// (Recommended) Standard bitrate mode. In this mode, the bitrates of the live broadcasting profile is higher than that of the communication profile.
        /// </summary>
        ///
        STANDARD_BITRATE = 0,

        ///
        /// <summary>
        /// Adaptive bitrate mode. In this mode, the bitrates of the live broadcasting profile equals that of the communication profile. If this mode is selected, the video frame rate of live broadcasting scenarios may be lower than the set value.
        /// </summary>
        ///
        COMPATIBLE_BITRATE = -1,

        ///
        /// @ignore
        ///
        DEFAULT_MIN_BITRATE = -1,

        ///
        /// @ignore
        ///
        DEFAULT_MIN_BITRATE_EQUAL_TO_TARGET_BITRATE = -2,
    };

    ///
    /// <summary>
    /// Video codec types.
    /// </summary>
    ///
    public enum VIDEO_CODEC_TYPE
    {
        ///
        /// @ignore
        ///
        VIDEO_CODEC_NONE = 0,

        ///
        /// <summary>
        /// 1: Standard VP8.
        /// </summary>
        ///
        VIDEO_CODEC_VP8 = 1,

        ///
        /// <summary>
        /// 2: (Default) Standard H.264.
        /// </summary>
        ///
        VIDEO_CODEC_H264 = 2,

        ///
        /// <summary>
        /// 3: Standard H.265.
        /// </summary>
        ///
        VIDEO_CODEC_H265 = 3,

        ///
        /// <summary>
        /// 6: Generic.This type is used for transmitting raw video data, such as encrypted video frames. The SDK returns this type of video frames in callbacks, and you need to decode and render the frames yourself.
        /// </summary>
        ///
        VIDEO_CODEC_GENERIC = 6,

        ///
        /// @ignore
        ///
        VIDEO_CODEC_GENERIC_H264 = 7,

        ///
        /// @ignore
        ///
        VIDEO_CODEC_AV1 = 12,

        ///
        /// @ignore
        ///
        VIDEO_CODEC_VP9 = 13,

        ///
        /// <summary>
        /// 20: Generic JPEG.This type consumes minimum computing resources and applies to IoT devices.
        /// </summary>
        ///
        VIDEO_CODEC_GENERIC_JPEG = 20,
    };

    ///
    /// @ignore
    ///
    public enum TCcMode
    {
        ///
        /// @ignore
        ///
        CC_ENABLED = 0,

        ///
        /// @ignore
        ///
        CC_DISABLED = 1,
    };

    ///
    /// @ignore
    ///
    public class SenderOptions
    {
        ///
        /// @ignore
        ///
        public TCcMode ccMode;

        ///
        /// @ignore
        ///
        public VIDEO_CODEC_TYPE codecType;

        ///
        /// @ignore
        ///
        public int targetBitrate;

        public SenderOptions()
        {
            ccMode = TCcMode.CC_ENABLED;
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_GENERIC_H264;
            targetBitrate = 6500;
        }
    };

    ///
    /// <summary>
    /// The codec type of audio.
    /// </summary>
    ///
    public enum AUDIO_CODEC_TYPE
    {
        ///
        /// <summary>
        /// 1: OPUS.
        /// </summary>
        ///
        AUDIO_CODEC_OPUS = 1,

        ///
        /// <summary>
        /// 3: PCMA.
        /// </summary>
        ///
        AUDIO_CODEC_PCMA = 3,

        ///
        /// <summary>
        /// 4: PCMU.
        /// </summary>
        ///
        AUDIO_CODEC_PCMU = 4,

        ///
        /// <summary>
        /// 5: G722.
        /// </summary>
        ///
        AUDIO_CODEC_G722 = 5,

        ///
        /// <summary>
        /// 8: LC-AAC.
        /// </summary>
        ///
        AUDIO_CODEC_AACLC = 8,

        ///
        /// <summary>
        /// 9: HE-AAC.
        /// </summary>
        ///
        AUDIO_CODEC_HEAAC = 9,

        ///
        /// <summary>
        /// 10: JC1.
        /// </summary>
        ///
        AUDIO_CODEC_JC1 = 10,

        ///
        /// <summary>
        /// 11: HE-AAC v2.
        /// </summary>
        ///
        AUDIO_CODEC_HEAAC2 = 11,

        ///
        /// @ignore
        ///
        AUDIO_CODEC_LPCNET = 12,
    };

    [Flags]
    ///
    /// <summary>
    /// Audio encoding type.
    /// </summary>
    ///
    public enum AUDIO_ENCODING_TYPE
    {
        ///
        /// <summary>
        /// AAC encoding format, 16000 Hz sampling rate, bass quality. A file with an audio duration of 10 minutes is approximately 1.2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_16000_LOW = 0x010101,

        ///
        /// <summary>
        /// AAC encoding format, 16000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_16000_MEDIUM = 0x010102,

        ///
        /// <summary>
        /// AAC encoding format, 32000 Hz sampling rate, bass quality. A file with an audio duration of 10 minutes is approximately 1.2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_32000_LOW = 0x010201,

        ///
        /// <summary>
        /// AAC encoding format, 32000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_32000_MEDIUM = 0x010202,

        ///
        /// <summary>
        /// AAC encoding format, 32000 Hz sampling rate, high sound quality. A file with an audio duration of 10 minutes is approximately 3.5 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_32000_HIGH = 0x010203,

        ///
        /// <summary>
        /// AAC encoding format, 48000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_48000_MEDIUM = 0x010302,

        ///
        /// <summary>
        /// AAC encoding format, 48000 Hz sampling rate, high sound quality. A file with an audio duration of 10 minutes is approximately 3.5 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_AAC_48000_HIGH = 0x010303,

        ///
        /// <summary>
        /// OPUS encoding format, 16000 Hz sampling rate, bass quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_OPUS_16000_LOW = 0x020101,

        ///
        /// <summary>
        /// OPUS encoding format, 16000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_OPUS_16000_MEDIUM = 0x020102,

        ///
        /// <summary>
        /// OPUS encoding format, 48000 Hz sampling rate, medium sound quality. A file with an audio duration of 10 minutes is approximately 2 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_OPUS_48000_MEDIUM = 0x020302,

        ///
        /// <summary>
        /// OPUS encoding format, 48000 Hz sampling rate, high sound quality. A file with an audio duration of 10 minutes is approximately 3.5 MB after encoding.
        /// </summary>
        ///
        AUDIO_ENCODING_TYPE_OPUS_48000_HIGH = 0x020303,
    };

    ///
    /// <summary>
    /// The adaptation mode of the watermark.
    /// </summary>
    ///
    public enum WATERMARK_FIT_MODE
    {
        ///
        /// <summary>
        /// Use the positionInLandscapeMode and positionInPortraitMode values you set in WatermarkOptions . The settings in WatermarkRatio are invalid.
        /// </summary>
        ///
        FIT_MODE_COVER_POSITION = 0,

        ///
        /// <summary>
        /// Use the value you set in WatermarkRatio . The settings in positionInLandscapeMode and positionInPortraitMode in WatermarkOptions are invalid.
        /// </summary>
        ///
        FIT_MODE_USE_IMAGE_RATIO = 1
    };

    ///
    /// @ignore
    ///
    public class EncodedAudioFrameAdvancedSettings
    {
        public EncodedAudioFrameAdvancedSettings()
        {
            speech = true;
            sendEvenIfEmpty = true;
        }

        ///
        /// @ignore
        ///
        public bool speech;

        ///
        /// @ignore
        ///
        public bool sendEvenIfEmpty;
    };

    ///
    /// <summary>
    /// Audio information after encoding.
    /// </summary>
    ///
    public class EncodedAudioFrameInfo
    {
        public EncodedAudioFrameInfo()
        {
            codec = AUDIO_CODEC_TYPE.AUDIO_CODEC_AACLC;
            sampleRateHz = 0;
            samplesPerChannel = 0;
            numberOfChannels = 0;
            captureTimeMs = 0;
            advancedSettings = new EncodedAudioFrameAdvancedSettings();
        }

        public EncodedAudioFrameInfo(ref EncodedAudioFrameInfo rhs)
        {
            codec = rhs.codec;
            sampleRateHz = rhs.sampleRateHz;
            samplesPerChannel = rhs.samplesPerChannel;
            numberOfChannels = rhs.numberOfChannels;
            advancedSettings = rhs.advancedSettings;
            captureTimeMs = rhs.captureTimeMs;
        }

        ///
        /// <summary>
        /// Audio Codec type: AUDIO_CODEC_TYPE .
        /// </summary>
        ///
        public AUDIO_CODEC_TYPE codec;

        ///
        /// <summary>
        /// Audio sample rate (Hz).
        /// </summary>
        ///
        public int sampleRateHz;

        ///
        /// <summary>
        /// The number of audio samples per channel.
        /// </summary>
        ///
        public int samplesPerChannel;

        ///
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        ///
        public int numberOfChannels;

        ///
        /// <summary>
        /// This function is currently not supported.
        /// </summary>
        ///
        public EncodedAudioFrameAdvancedSettings advancedSettings;

        ///
        /// <summary>
        /// The Unix timestamp (ms) for capturing the external encoded video frames.
        /// </summary>
        ///
        public int64_t captureTimeMs;
    };

    ///
    /// @ignore
    ///
    public class AudioPcmDataInfo
    {
        public AudioPcmDataInfo()
        {
            samplesPerChannel = 0;
            channelNum = 0;
            samplesOut = 0;
            elapsedTimeMs = 0;
            ntpTimeMs = 0;
        }

        public AudioPcmDataInfo(ref AudioPcmDataInfo rhs)
        {
            samplesPerChannel = rhs.samplesPerChannel;
            channelNum = rhs.channelNum;
            samplesOut = rhs.samplesOut;
            elapsedTimeMs = rhs.elapsedTimeMs;
            ntpTimeMs = rhs.ntpTimeMs;
        }

        ///
        /// @ignore
        ///
        public uint samplesPerChannel;

        ///
        /// @ignore
        ///
        public short channelNum;

        ///
        /// @ignore
        ///
        public uint samplesOut;

        ///
        /// @ignore
        ///
        public int64_t elapsedTimeMs;

        ///
        /// @ignore
        ///
        public int64_t ntpTimeMs;
    };

    ///
    /// @ignore
    ///
    public enum H264PacketizeMode
    {
        ///
        /// @ignore
        ///
        NonInterleaved = 0,

        ///
        /// @ignore
        ///
        SingleNalUnit = 1,
    };

    ///
    /// <summary>
    /// The type of video streams.
    /// </summary>
    ///
    public enum VIDEO_STREAM_TYPE
    {
        ///
        /// <summary>
        /// 0: High-quality video stream.
        /// </summary>
        ///
        VIDEO_STREAM_HIGH = 0,

        ///
        /// <summary>
        /// 1: Low-quality video stream.
        /// </summary>
        ///
        VIDEO_STREAM_LOW = 1,
    };

    ///
    /// <summary>
    /// Video subscription options.
    /// </summary>
    ///
    public class VideoSubscriptionOptions : OptionalJsonParse
    {
        ///
        /// <summary>
        /// The video stream type that you want to subscribe to. The default value is VIDEO_STREAM_HIGH, indicating that the high-quality video streams are subscribed. See VIDEO_STREAM_TYPE .
        /// </summary>
        ///
        public Optional<VIDEO_STREAM_TYPE> type = new Optional<VIDEO_STREAM_TYPE>();

        ///
        /// <summary>
        /// Whether to subscribe to encoded video frames only:true: Subscribe to the encoded video data (structured data) only; the SDK does not decode or render raw video data.false: (Default) Subscribe to both raw video data and encoded video data.
        /// </summary>
        ///
        public Optional<bool> encodedFrameOnly = new Optional<bool>();

        public VideoSubscriptionOptions()
        {

        }

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if (this.type.HasValue())
            {
                writer.WritePropertyName("type");
                this.WriteEnum(writer, this.type.GetValue());
            }

            if (this.encodedFrameOnly.HasValue())
            {
                writer.WritePropertyName("encodedFrameOnly");
                writer.Write(this.encodedFrameOnly.GetValue());
            }

            writer.WriteObjectEnd();
        }
    };

    ///
    /// <summary>
    /// Information about externally encoded video frames.
    /// </summary>
    ///
    public class EncodedVideoFrameInfo
    {
        public EncodedVideoFrameInfo()
        {
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            width = 0;
            height = 0;
            framesPerSecond = 0;
            frameType = VIDEO_FRAME_TYPE_NATIVE.VIDEO_FRAME_TYPE_BLANK_FRAME;
            rotation = VIDEO_ORIENTATION.VIDEO_ORIENTATION_0;
            trackId = 0;
            captureTimeMs = 0;
            decodeTimeMs = 0;
            uid = 0;
            streamType = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
        }

        public EncodedVideoFrameInfo(ref EncodedVideoFrameInfo rhs)
        {
            codecType = rhs.codecType;
            width = rhs.width;
            height = rhs.width;
            framesPerSecond = rhs.framesPerSecond;
            frameType = rhs.frameType;
            rotation = rhs.rotation;
            trackId = rhs.trackId;
            captureTimeMs = rhs.captureTimeMs;
            decodeTimeMs = rhs.decodeTimeMs;
            uid = rhs.uid;
            streamType = rhs.streamType;
        }

        ///
        /// <summary>
        /// The codec type of the local video stream. See VIDEO_CODEC_TYPE . The default value is VIDEO_CODEC_H264 (2).
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType;

        ///
        /// <summary>
        /// Width (pixel) of the video frame.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// Height (pixel) of the video frame.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// The number of video frames per second.When this parameter is not 0, you can use it to calculate the Unix timestamp of externally encoded video frames.
        /// </summary>
        ///
        public int framesPerSecond;

        ///
        /// <summary>
        /// The video frame type. See VIDEO_FRAME_TYPE .
        /// </summary>
        ///
        public VIDEO_FRAME_TYPE_NATIVE frameType;

        ///
        /// <summary>
        /// The rotation information of the video frame. See VIDEO_ORIENTATION .
        /// </summary>
        ///
        public VIDEO_ORIENTATION rotation;

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public int trackId;

        ///
        /// <summary>
        /// The Unix timestamp (ms) for capturing the external encoded video frames.
        /// </summary>
        ///
        public int64_t captureTimeMs;


        ///
        /// @ignore
        ///
        public int64_t decodeTimeMs;
        ///
        /// <summary>
        /// The user ID to push the externally encoded video frame.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The type of video streams. See VIDEO_STREAM_TYPE .
        /// </summary>
        ///
        public VIDEO_STREAM_TYPE streamType;
    };


    ///
    /// <summary>
    /// Compression preference for video encoding.
    /// </summary>
    ///
    public enum COMPRESSION_PREFERENCE
    {
        ///
        /// <summary>
        /// 0: Low latency preference. The SDK compresses video frames to reduce latency. This preference is suitable for scenarios where smoothness is prioritized and reduced video quality is acceptable.
        /// </summary>
        ///
        PREFER_LOW_LATENCY = 0,

        ///
        /// <summary>
        /// 1: (Default) High quality preference. The SDK compresses video frames while maintaining video quality. This preference is suitable for scenarios where video quality is prioritized.
        /// </summary>
        ///
        PREFER_QUALITY = 1
    };

    ///
    /// <summary>
    /// Video encoder preference.
    /// </summary>
    ///
    public enum ENCODING_PREFERENCE
    {
        ///
        /// <summary>
        /// -1: Adaptive preference. The SDK automatically selects the optimal encoding type for encoding based on factors such as platform and device type.
        /// </summary>
        ///
        PREFER_AUTO = -1,

        ///
        /// <summary>
        /// 0: Software coding preference. The SDK prefers software encoders for video encoding.
        /// </summary>
        ///
        PREFER_SOFTWARE = 0,

        ///
        /// <summary>
        /// 1: Hardware encoding preference. The SDK prefers a hardware encoder for video encoding. When the device does not support hardware encoding, the SDK automatically uses software encoding and reports the currently used video encoder type through hwEncoderAccelerating in the OnLocalVideoStats callback.
        /// </summary>
        ///
        PREFER_HARDWARE = 1,
    };

    ///
    /// <summary>
    /// Advanced options for video encoding.
    /// </summary>
    ///
    public class AdvanceOptions
    {
        ///
        /// <summary>
        /// Video encoder preference. See ENCODING_PREFERENCE .
        /// </summary>
        ///
        public ENCODING_PREFERENCE encodingPreference;
        ///
        /// <summary>
        /// Compression preference for video encoding. See COMPRESSION_PREFERENCE .
        /// </summary>
        ///
        public COMPRESSION_PREFERENCE compressionPreference;

        public AdvanceOptions()
        {
            encodingPreference = ENCODING_PREFERENCE.PREFER_AUTO;
            compressionPreference = COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY;
        }

        public AdvanceOptions(ENCODING_PREFERENCE encoding_preference, COMPRESSION_PREFERENCE compression_preference)
        {
            encodingPreference = encoding_preference;
            compressionPreference = compression_preference;
        }
    }
    ///
    /// <summary>
    /// Video mirror mode.
    /// </summary>
    ///
    public enum VIDEO_MIRROR_MODE_TYPE
    {
        ///
        /// <summary>
        /// 0: The SDK determines the mirror mode.For the mirror mode of the local video view: If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.For the remote user: The mirror mode is disabled by default.
        /// </summary>
        ///
        VIDEO_MIRROR_MODE_AUTO = 0,

        ///
        /// <summary>
        /// 1: Enable mirror mode.
        /// </summary>
        ///
        VIDEO_MIRROR_MODE_ENABLED = 1,

        ///
        /// <summary>
        /// 2: Disable mirror mode.
        /// </summary>
        ///
        VIDEO_MIRROR_MODE_DISABLED = 2,
    };

    ///
    /// <summary>
    /// The bit mask that indicates the device codec capability.
    /// </summary>
    ///
    public enum CODEC_CAP_MASK
    {

        ///
        /// <summary>
        /// (0): The device does not support encoding or decoding.
        /// </summary>
        ///
        CODEC_CAP_MASK_NONE = 0,

        ///
        /// <summary>
        /// (1 << 0): The device supports hardware decoding.
        /// </summary>
        ///
        CODEC_CAP_MASK_HW_DEC = 1 << 0,

        ///
        /// <summary>
        /// (1 << 1): The device supports hardware encoding.
        /// </summary>
        ///
        CODEC_CAP_MASK_HW_ENC = 1 << 1,

        ///
        /// <summary>
        /// (1 << 2): The device supports software decoding.
        /// </summary>
        ///
        CODEC_CAP_MASK_SW_DEC = 1 << 2,

        ///
        /// <summary>
        /// (1 << 3): The device supports software ecoding.
        /// </summary>
        ///
        CODEC_CAP_MASK_SW_ENC = 1 << 3,
    };

    ///
    /// <summary>
    /// The codec capability of the device.
    /// </summary>
    ///
    public class CodecCapInfo
    {
        ///
        /// <summary>
        /// The video codec types. See VIDEO_CODEC_TYPE .
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType;

        ///
        /// <summary>
        /// The bit mask of the codec type. See CODEC_CAP_MASK .
        /// </summary>
        ///
        public int codecCapMask;
    };

    ///
    /// <summary>
    /// Video encoder configurations.
    /// </summary>
    ///
    public class VideoEncoderConfiguration
    {
        ///
        /// <summary>
        /// The codec type of the local video stream. See VIDEO_CODEC_TYPE .
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType;

        ///
        /// <summary>
        /// The dimensions of the encoded video (px). See VideoDimensions . This parameter measures the video encoding quality in the format of length × width. The default value is 960 × 540. You can set a custom value.
        /// </summary>
        ///
        public VideoDimensions dimensions;

        ///
        /// <summary>
        /// The frame rate (fps) of the encoding video frame. The default value is 15. See FRAME_RATE .
        /// </summary>
        ///
        public int frameRate;

        ///
        /// <summary>
        /// The encoding bitrate (Kbps) of the video. See BITRATE .
        /// </summary>
        ///
        public int bitrate;

        ///
        /// <summary>
        /// The minimum encoding bitrate (Kbps) of the video.The SDK automatically adjusts the encoding bitrate to adapt to the network conditions. Using a value greater than the default value forces the video encoder to output high-quality images but may cause more packet loss and sacrifice the smoothness of the video transmission. Unless you have special requirements for image quality, Agora does not recommend changing this value.This parameter only applies to the interactive streaming profile.
        /// </summary>
        ///
        public int minBitrate;

        ///
        /// <summary>
        /// The orientation mode of the encoded video. See ORIENTATION_MODE .
        /// </summary>
        ///
        public ORIENTATION_MODE orientationMode;

        ///
        /// <summary>
        /// Video degradation preference under limited bandwidth. See DEGRADATION_PREFERENCE .
        /// </summary>
        ///
        public DEGRADATION_PREFERENCE degradationPreference;

        ///
        /// <summary>
        /// Sets the mirror mode of the published local video stream. It only affects the video that the remote user sees. See VIDEO_MIRROR_MODE_TYPE .By default, the video is not mirrored.
        /// </summary>
        ///
        public VIDEO_MIRROR_MODE_TYPE mirrorMode;


        ///
        /// <summary>
        /// Advanced options for video encoding. See AdvanceOptions .
        /// </summary>
        ///
        public AdvanceOptions advanceOptions;

        public VideoEncoderConfiguration(ref VideoDimensions d, int f, int b, ORIENTATION_MODE m, VIDEO_MIRROR_MODE_TYPE mirror = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED)
        {
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            dimensions = d;
            frameRate = f;
            bitrate = b;
            minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = m;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = mirror;
            advanceOptions = new AdvanceOptions(ENCODING_PREFERENCE.PREFER_AUTO, COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY);
        }

        public VideoEncoderConfiguration(int width, int height, int f, int b, ORIENTATION_MODE m, VIDEO_MIRROR_MODE_TYPE mirror = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED)
        {
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = m;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = mirror;
            advanceOptions = new AdvanceOptions(ENCODING_PREFERENCE.PREFER_AUTO, COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY);
        }

        public VideoEncoderConfiguration(ref VideoEncoderConfiguration config)
        {
            codecType = config.codecType;
            dimensions = config.dimensions;
            frameRate = config.frameRate;
            bitrate = config.bitrate;
            minBitrate = config.minBitrate;
            orientationMode = config.orientationMode;
            degradationPreference = config.degradationPreference;
            mirrorMode = config.mirrorMode;
            advanceOptions = new AdvanceOptions(config.advanceOptions.encodingPreference, config.advanceOptions.compressionPreference);
        }

        public VideoEncoderConfiguration()
        {
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            dimensions = new VideoDimensions((int)FRAME_WIDTH.FRAME_WIDTH_960, (int)FRAME_HEIGHT.FRAME_HEIGHT_540);
            frameRate = (int)FRAME_RATE.FRAME_RATE_FPS_15;
            bitrate = (int)BITRATE.STANDARD_BITRATE;
            minBitrate = (int)BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED;
            advanceOptions = new AdvanceOptions(ENCODING_PREFERENCE.PREFER_AUTO, COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY);
        }
    };

    ///
    /// <summary>
    /// The configurations for the data stream.
    /// The following table shows the SDK behaviors under different parameter settings:
    /// </summary>
    ///
    public class DataStreamConfig
    {
        ///
        /// <summary>
        /// Whether to synchronize the data packet with the published audio packet.true: Synchronize the data packet with the audio packet.false: Do not synchronize the data packet with the audio packet.When you set the data packet to synchronize with the audio, then if the data packet delay is within the audio delay, the SDK triggers the OnStreamMessage callback when the synchronized audio packet is played out. Do not set this parameter as true if you need the receiver to receive the data packet immediately. Agora recommends that you set this parameter to true only when you need to implement specific functions, for example, lyric synchronization.
        /// </summary>
        ///
        public bool syncWithAudio;

        ///
        /// <summary>
        /// Whether the SDK guarantees that the receiver receives the data in the sent order.true: Guarantee that the receiver receives the data in the sent order.false: Do not guarantee that the receiver receives the data in the sent order.Do not set this parameter as true if you need the receiver to receive the data packet immediately.
        /// </summary>
        ///
        public bool ordered;
    };

    ///
    /// <summary>
    /// The mode in which the video stream is sent.
    /// </summary>
    ///
    public enum SIMULCAST_STREAM_MODE
    {
        ///
        /// <summary>
        /// -1: By default, the low-quality video steam is not sent; the SDK automatically switches to low-quality video stream mode after it receives a request to subscribe to a low-quality video stream.
        /// </summary>
        ///
        AUTO_SIMULCAST_STREAM = -1,

        ///
        /// @ignore
        ///
        DISABLE_SIMULCAST_STREM = 0,

        ///
        /// <summary>
        /// 1: Always send low-quality video stream.
        /// </summary>
        ///
        ENABLE_SIMULCAST_STREAM = 1,
    };

    ///
    /// <summary>
    /// The configuration of the low-quality video stream.
    /// </summary>
    ///
    public class SimulcastStreamConfig
    {
        public SimulcastStreamConfig()
        {
            dimensions = new VideoDimensions(160, 120);
            kBitrate = 65;
            framerate = 5;
        }

        public SimulcastStreamConfig(VideoDimensions dimensions, int kBitrate, int framerate)
        {
            this.dimensions = dimensions;
            this.kBitrate = kBitrate;
            this.framerate = framerate;
        }

        ///
        /// <summary>
        /// The video dimension. See VideoDimensions . The default value is 160 × 120.
        /// </summary>
        ///
        public VideoDimensions dimensions;

        ///
        /// <summary>
        /// Video receive bitrate (Kbps), represented by an instantaneous value. The default value is 65.
        /// </summary>
        ///
        public int kBitrate;

        ///
        /// <summary>
        /// The frame rate (fps) of the local video. The default value is 5.
        /// </summary>
        ///
        public int framerate;
    };

    ///
    /// <summary>
    /// The location of the target area relative to the screen or window. If you do not set this parameter, the SDK selects the whole screen or window.
    /// </summary>
    ///
    public class Rectangle
    {
        public Rectangle()
        {
        }

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        ///
        /// <summary>
        /// The horizontal offset from the top-left corner.
        /// </summary>
        ///
        public int x;

        ///
        /// <summary>
        /// The vertical offset from the top-left corner.
        /// </summary>
        ///
        public int y;

        ///
        /// <summary>
        /// The width of the target area.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height of the target area.
        /// </summary>
        ///
        public int height;
    };

    ///
    /// <summary>
    /// The position and size of the watermark on the screen.
    /// The position and size of the watermark on the screen are determined by xRatio, yRatio, and widthRatio:(xRatio, yRatio) refers to the coordinates of the upper left corner of the watermark, which determines the distance from the upper left corner of the watermark to the upper left corner of the screen.The widthRatio determines the width of the watermark.
    /// </summary>
    ///
    public class WatermarkRatio
    {
        public WatermarkRatio()
        {
            xRatio = 0.0f;
            yRatio = 0.0f;
            widthRatio = 0.0f;
        }

        public WatermarkRatio(float x, float y, float width)
        {
            xRatio = x;
            yRatio = y;
            widthRatio = width;
        }

        ///
        /// <summary>
        /// The x-coordinate of the upper left corner of the watermark. The horizontal position relative to the origin, where the upper left corner of the screen is the origin, and the x-coordinate is the upper left corner of the watermark. The value range is [0.0,1.0], and the default value is 0.
        /// </summary>
        ///
        public float xRatio;

        ///
        /// <summary>
        /// The y-coordinate of the upper left corner of the watermark. The vertical position relative to the origin, where the upper left corner of the screen is the origin, and the y-coordinate is the upper left corner of the screen. The value range is [0.0,1.0], and the default value is 0.
        /// </summary>
        ///
        public float yRatio;

        ///
        /// <summary>
        /// The width of the watermark. The SDK calculates the height of the watermark proportionally according to this parameter value to ensure that the enlarged or reduced watermark image is not distorted. The value range is [0,1], and the default value is 0, which means no watermark is displayed.
        /// </summary>
        ///
        public float widthRatio;
    };

    ///
    /// <summary>
    /// Configurations of the watermark image.
    /// </summary>
    ///
    public class WatermarkOptions
    {
        public WatermarkOptions()
        {
            visibleInPreview = false;
            positionInLandscapeMode = new Rectangle(0, 0, 0, 0);
            positionInPortraitMode = new Rectangle(0, 0, 0, 0);
            watermarkRatio = new WatermarkRatio();
            mode = WATERMARK_FIT_MODE.FIT_MODE_COVER_POSITION;
        }

        public WatermarkOptions(bool visibleInPreview, Rectangle positionInLandscapeMode,
            Rectangle positionInPortraitMode, WatermarkRatio ratio, WATERMARK_FIT_MODE mode)
        {
            this.visibleInPreview = visibleInPreview;
            this.positionInLandscapeMode = positionInLandscapeMode ?? new Rectangle();
            this.positionInPortraitMode = positionInPortraitMode ?? new Rectangle();
            this.watermarkRatio = ratio ?? new WatermarkRatio();
            this.mode = mode;
        }

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public bool visibleInPreview;

        ///
        /// <summary>
        /// When the adaptation mode of the watermark is FIT_MODE_COVER_POSITION, it is used to set the area of the watermark image in landscape mode. See Rectangle .
        /// </summary>
        ///
        public Rectangle positionInLandscapeMode;

        ///
        /// <summary>
        /// When the adaptation mode of the watermark is FIT_MODE_COVER_POSITION, it is used to set the area of the watermark image in portrait mode. See Rectangle .
        /// </summary>
        ///
        public Rectangle positionInPortraitMode;

        ///
        /// <summary>
        /// When the watermark adaptation mode is FIT_MODE_USE_IMAGE_RATIO, this parameter is used to set the watermark coordinates. See WatermarkRatio .
        /// </summary>
        ///
        public WatermarkRatio watermarkRatio;

        ///
        /// <summary>
        /// The adaptation mode of the watermark. See WATERMARK_FIT_MODE .
        /// </summary>
        ///
        public WATERMARK_FIT_MODE mode;
    };

    ///
    /// <summary>
    /// Statistics of a call session.
    /// </summary>
    ///
    public class RtcStats
    {
        public RtcStats()
        {
        }

        public RtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes, uint txVideoBytes,
            uint rxAudioBytes, uint rxVideoBytes, UInt16 txKBitRate, UInt16 rxKBitRate, UInt16 rxAudioKBitRate,
            UInt16 txAudioKBitRate, UInt16 rxVideoKBitRate, UInt16 txVideoKBitRate, UInt16 lastmileDelay,
            uint userCount, double cpuAppUsage, double cpuTotalUsage, int gatewayRtt,
            double memoryAppUsageRatio, double memoryTotalUsageRatio, int memoryAppUsageInKbytes, int connectTimeMs,
            int firstAudioPacketDuration, int firstVideoPacketDuration, int firstVideoKeyFramePacketDuration,
            int packetsBeforeFirstKeyFramePacket, int firstAudioPacketDurationAfterUnmute, int firstVideoPacketDurationAfterUnmute,
            int firstVideoKeyFramePacketDurationAfterUnmute, int firstVideoKeyFrameDecodedDurationAfterUnmute,
            int firstVideoKeyFrameRenderedDurationAfterUnmute, int txPacketLossRate, int rxPacketLossRate)
        {
            this.duration = duration;
            this.txBytes = txBytes;
            this.rxBytes = rxBytes;
            this.txAudioBytes = txAudioBytes;
            this.txVideoBytes = txVideoBytes;
            this.rxAudioBytes = rxAudioBytes;
            this.rxVideoBytes = rxVideoBytes;
            this.txKBitRate = txKBitRate;
            this.rxKBitRate = rxKBitRate;
            this.rxAudioKBitRate = rxAudioKBitRate;
            this.txAudioKBitRate = txAudioKBitRate;
            this.rxVideoKBitRate = rxVideoKBitRate;
            this.txVideoKBitRate = txVideoKBitRate;
            this.lastmileDelay = lastmileDelay;
            this.userCount = userCount;
            this.cpuAppUsage = cpuAppUsage;
            this.cpuTotalUsage = cpuTotalUsage;
            this.gatewayRtt = gatewayRtt;
            this.memoryAppUsageRatio = memoryAppUsageRatio;
            this.memoryTotalUsageRatio = memoryTotalUsageRatio;
            this.memoryAppUsageInKbytes = memoryAppUsageInKbytes;
            this.connectTimeMs = connectTimeMs;
            this.firstAudioPacketDuration = firstAudioPacketDuration;
            this.firstVideoPacketDuration = firstVideoPacketDuration;
            this.firstVideoKeyFramePacketDuration = firstVideoKeyFramePacketDuration;
            this.packetsBeforeFirstKeyFramePacket = packetsBeforeFirstKeyFramePacket;
            this.firstAudioPacketDurationAfterUnmute = firstAudioPacketDurationAfterUnmute;
            this.firstVideoPacketDurationAfterUnmute = firstVideoPacketDurationAfterUnmute;
            this.firstVideoKeyFramePacketDurationAfterUnmute = firstVideoKeyFramePacketDurationAfterUnmute;
            this.firstVideoKeyFrameDecodedDurationAfterUnmute = firstVideoKeyFrameDecodedDurationAfterUnmute;
            this.firstVideoKeyFrameRenderedDurationAfterUnmute = firstVideoKeyFrameRenderedDurationAfterUnmute;
            this.txPacketLossRate = txPacketLossRate;
            this.rxPacketLossRate = rxPacketLossRate;
        }

        ///
        /// <summary>
        /// Call duration of the local user in seconds, represented by an aggregate value.
        /// </summary>
        ///
        public uint duration;

        ///
        /// <summary>
        /// The number of bytes sent.
        /// </summary>
        ///
        public uint txBytes;

        ///
        /// <summary>
        /// The number of bytes received.
        /// </summary>
        ///
        public uint rxBytes;

        ///
        /// <summary>
        /// The total number of audio bytes sent, represented by an aggregate value.
        /// </summary>
        ///
        public uint txAudioBytes;

        ///
        /// <summary>
        /// The total number of video bytes sent, represented by an aggregate value.
        /// </summary>
        ///
        public uint txVideoBytes;

        ///
        /// <summary>
        /// The total number of audio bytes received, represented by an aggregate value.
        /// </summary>
        ///
        public uint rxAudioBytes;

        ///
        /// <summary>
        /// The total number of video bytes received, represented by an aggregate value.
        /// </summary>
        ///
        public uint rxVideoBytes;

        ///
        /// <summary>
        /// Video transmission bitrate (Kbps), represented by an instantaneous value.
        /// </summary>
        ///
        public ushort txKBitRate;

        ///
        /// <summary>
        /// The receiving bitrate (Kbps), represented by an instantaneous value.
        /// </summary>
        ///
        public ushort rxKBitRate;

        ///
        /// <summary>
        /// The bitrate (Kbps) of receiving the audio.
        /// </summary>
        ///
        public ushort rxAudioKBitRate;

        ///
        /// <summary>
        /// The bitrate (Kbps) of sending the audio packet.
        /// </summary>
        ///
        public ushort txAudioKBitRate;

        ///
        /// <summary>
        /// The bitrate (Kbps) of receiving the video.
        /// </summary>
        ///
        public ushort rxVideoKBitRate;

        ///
        /// <summary>
        /// The bitrate (Kbps) of sending the video.
        /// </summary>
        ///
        public ushort txVideoKBitRate;

        ///
        /// <summary>
        /// The client-to-server delay (milliseconds).
        /// </summary>
        ///
        public ushort lastmileDelay;

        ///
        /// <summary>
        /// The number of users in the channel.
        /// </summary>
        ///
        public uint userCount;

        ///
        /// <summary>
        /// Application CPU usage (%).The value of cpuAppUsage is always reported as 0 in the OnLeaveChannel callback.As of Android 8.1, you cannot get the CPU usage from this attribute due to system limitations.
        /// </summary>
        ///
        public double cpuAppUsage;

        ///
        /// <summary>
        /// The system CPU usage (%).For Windows, in the multi-kernel environment, this member represents the average CPU usage. The value = (100 - System Idle Progress in Task Manager)/100.The value of cpuTotalUsage is always reported as 0 in the OnLeaveChannel callback.As of Android 8.1, you cannot get the CPU usage from this attribute due to system limitations.
        /// </summary>
        ///
        public double cpuTotalUsage;

        ///
        /// <summary>
        /// The round-trip time delay (ms) from the client to the local router.This property is disabled on devices running iOS 14 or later, and enabled on devices running versions earlier than iOS 14 by default. To enable this property on devices running iOS 14 or later, .On Android, to get gatewayRtt, ensure that you add the android.permission.ACCESS_WIFI_STATE permission after </application> in the AndroidManifest.xml file in your project.
        /// </summary>
        ///
        public int gatewayRtt;

        ///
        /// <summary>
        /// The memory ratio occupied by the app (%).This value is for reference only. Due to system limitations, you may not get this value.
        /// </summary>
        ///
        public double memoryAppUsageRatio;

        ///
        /// <summary>
        /// The memory occupied by the system (%).This value is for reference only. Due to system limitations, you may not get this value.
        /// </summary>
        ///
        public double memoryTotalUsageRatio;

        ///
        /// <summary>
        /// The memory size occupied by the app (KB).This value is for reference only. Due to system limitations, you may not get this value.
        /// </summary>
        ///
        public int memoryAppUsageInKbytes;

        ///
        /// <summary>
        /// The duration (ms) between the SDK starts connecting and the connection is established. If the value reported is 0, it means invalid.
        /// </summary>
        ///
        public int connectTimeMs;

        ///
        /// @ignore
        ///
        public int firstAudioPacketDuration;

        ///
        /// @ignore
        ///
        public int firstVideoPacketDuration;

        ///
        /// @ignore
        ///
        public int firstVideoKeyFramePacketDuration;

        ///
        /// @ignore
        ///
        public int packetsBeforeFirstKeyFramePacket;

        ///
        /// @ignore
        ///
        public int firstAudioPacketDurationAfterUnmute;

        ///
        /// @ignore
        ///
        public int firstVideoPacketDurationAfterUnmute;

        ///
        /// @ignore
        ///
        public int firstVideoKeyFramePacketDurationAfterUnmute;

        ///
        /// @ignore
        ///
        public int firstVideoKeyFrameDecodedDurationAfterUnmute;

        ///
        /// @ignore
        ///
        public int firstVideoKeyFrameRenderedDurationAfterUnmute;

        ///
        /// <summary>
        /// The packet loss rate (%) from the client to the Agora server before applying the anti-packet-loss algorithm.
        /// </summary>
        ///
        public int txPacketLossRate;

        ///
        /// <summary>
        /// The packet loss rate (%) from the Agora server to the client before using the anti-packet-loss method.
        /// </summary>
        ///
        public int rxPacketLossRate;
    };


    ///
    /// <summary>
    /// The user role in the interactive live streaming.
    /// </summary>
    ///
    public enum CLIENT_ROLE_TYPE
    {
        ///
        /// <summary>
        /// 1: Host. A host can both send and receive streams.
        /// </summary>
        ///
        CLIENT_ROLE_BROADCASTER = 1,

        ///
        /// <summary>
        /// 2: (Default) Audience. An audience member can only receive streams.
        /// </summary>
        ///
        CLIENT_ROLE_AUDIENCE = 2,
    };

    ///
    /// <summary>
    /// Quality change of the local video in terms of target frame rate and target bit rate since last count.
    /// </summary>
    ///
    public enum QUALITY_ADAPT_INDICATION
    {
        ///
        /// <summary>
        /// 0: The local video quality stays the same.
        /// </summary>
        ///
        ADAPT_NONE = 0,

        ///
        /// <summary>
        /// 1: The local video quality improves because the network bandwidth increases.
        /// </summary>
        ///
        ADAPT_UP_BANDWIDTH = 1,

        ///
        /// <summary>
        /// 2: The local video quality deteriorates because the network bandwidth decreases.
        /// </summary>
        ///
        ADAPT_DOWN_BANDWIDTH = 2,
    };

    ///
    /// <summary>
    /// The latency level of an audience member in interactive live streaming. This enum takes effect only when the user role is set to CLIENT_ROLE_AUDIENCE .
    /// </summary>
    ///
    public enum AUDIENCE_LATENCY_LEVEL_TYPE
    {
        ///
        /// <summary>
        /// 1: Low latency.
        /// </summary>
        ///
        AUDIENCE_LATENCY_LEVEL_LOW_LATENCY = 1,

        ///
        /// <summary>
        /// 2: (Default) Ultra low latency.
        /// </summary>
        ///
        AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY = 2,
    };

    ///
    /// <summary>
    /// Setting of user role properties.
    /// </summary>
    ///
    public class ClientRoleOptions
    {
        public ClientRoleOptions()
        {
            audienceLatencyLevel = AUDIENCE_LATENCY_LEVEL_TYPE.AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY;
        }

        ///
        /// <summary>
        /// The latency level of an audience member in interactive live streaming. See AUDIENCE_LATENCY_LEVEL_TYPE .
        /// </summary>
        ///
        public AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel;
    };

    ///
    /// <summary>
    /// The Quality of Experience (QoE) of the local user when receiving a remote audio stream.
    /// </summary>
    ///
    public enum EXPERIENCE_QUALITY_TYPE
    {
        ///
        /// <summary>
        /// 0: The QoE of the local user is good.
        /// </summary>
        ///
        EXPERIENCE_QUALITY_GOOD = 0,

        ///
        /// <summary>
        /// 1: The QoE of the local user is poor.
        /// </summary>
        ///
        EXPERIENCE_QUALITY_BAD = 1,
    };

    ///
    /// <summary>
    /// Reasons why the QoE of the local user when receiving a remote audio stream is poor.
    /// </summary>
    ///
    public enum EXPERIENCE_POOR_REASON
    {
        ///
        /// <summary>
        /// 0: No reason, indicating a good QoE of the local user.
        /// </summary>
        ///
        EXPERIENCE_REASON_NONE = 0,

        ///
        /// <summary>
        /// 1: The remote user's network quality is poor.
        /// </summary>
        ///
        REMOTE_NETWORK_QUALITY_POOR = 1,

        ///
        /// <summary>
        /// 2: The local user's network quality is poor.
        /// </summary>
        ///
        LOCAL_NETWORK_QUALITY_POOR = 2,

        ///
        /// <summary>
        /// 4: The local user's Wi-Fi or mobile network signal is weak.
        /// </summary>
        ///
        WIRELESS_SIGNAL_POOR = 4,

        ///
        /// <summary>
        /// 8: The local user enables both Wi-Fi and bluetooth, and their signals interfere with each other. As a result, audio transmission quality is undermined.
        /// </summary>
        ///
        WIFI_BLUETOOTH_COEXIST = 8,
    };

    ///
    /// <summary>
    /// AI noise reduction modes.
    /// </summary>
    ///
    public enum AUDIO_AINS_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) Balance mode. This mode allows for a balanced performance on noice reduction and time delay.
        /// </summary>
        ///
        AINS_MODE_BALANCED = 0,

        ///
        /// <summary>
        /// 1: Aggressive mode. In scenarios where high performance on noise reduction is required, such as live streaming outdoor events, This mode reduces nosies more dramatically, but may sometimes affect the original character of the audio.
        /// </summary>
        ///
        AINS_MODE_AGGRESSIVE = 1,

        ///
        /// <summary>
        /// 2: Aggressive mode with low latency. The noise reduction delay of this mode is about only half of that of the balance and aggressive modes. It is suitable for scenarios that have high requirements on noise reduction with low latency, such as sing together online in real time.
        /// </summary>
        ///
        AINS_MODE_ULTRALOWLATENCY = 2
    };

    ///
    /// <summary>
    /// The audio profile.
    /// </summary>
    ///
    public enum AUDIO_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 0: The default audio profile.For the interactive streaming profile: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 64 Kbps.For the communication profile: Windows: A sample rate of 16 kHz, audio encoding, mono, and a bitrate of up to 16 Kbps.Android/macOS/iOS:
        /// </summary>
        ///
        AUDIO_PROFILE_DEFAULT = 0,

        ///
        /// <summary>
        /// 1: A sample rate of 32 kHz, audio encoding, mono, and a bitrate of up to 18 Kbps.
        /// </summary>
        ///
        AUDIO_PROFILE_SPEECH_STANDARD = 1,

        ///
        /// <summary>
        /// 2: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 64 Kbps.
        /// </summary>
        ///
        AUDIO_PROFILE_MUSIC_STANDARD = 2,

        ///
        /// <summary>
        /// 3: A sample rate of 48 kHz, music encoding, stereo, and a bitrate of up to 80 Kbps.To implement stereo audio, you also need to call SetAdvancedAudioOptions and set audioProcessingChannels to AUDIO_PROCESSING_STEREO in AdvancedAudioOptions.
        /// </summary>
        ///
        AUDIO_PROFILE_MUSIC_STANDARD_STEREO = 3,

        ///
        /// <summary>
        /// 4: A sample rate of 48 kHz, music encoding, mono, and a bitrate of up to 96 Kbps.
        /// </summary>
        ///
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY = 4,

        ///
        /// <summary>
        /// 5: A sample rate of 48 kHz, music encoding, stereo, and a bitrate of up to 128 Kbps.To implement stereo audio, you also need to call SetAdvancedAudioOptions and set audioProcessingChannels to AUDIO_PROCESSING_STEREO in AdvancedAudioOptions.
        /// </summary>
        ///
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO = 5,

        ///
        /// <summary>
        /// 6: A sample rate of 16 kHz, audio encoding, mono, and Acoustic Echo Cancellation (AES) enabled.
        /// </summary>
        ///
        AUDIO_PROFILE_IOT = 6,

        ///
        /// <summary>
        /// Enumerator boundary.
        /// </summary>
        ///
        AUDIO_PROFILE_NUM = 7
    };

    ///
    /// <summary>
    /// The audio scenarios.
    /// </summary>
    ///
    public enum AUDIO_SCENARIO_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) Automatic scenario match, where the SDK chooses the appropriate audio quality according to the user role and audio route.
        /// </summary>
        ///
        AUDIO_SCENARIO_DEFAULT = 0,

        ///
        /// <summary>
        /// 3: High-quality audio scenario, where users mainly play music. For example, instrument tutoring.
        /// </summary>
        ///
        AUDIO_SCENARIO_GAME_STREAMING = 3,

        ///
        /// <summary>
        /// 5: Chatroom scenario, where users need to frequently switch the user role or mute and unmute the microphone. For example, education scenarios. In this scenario, audience members receive a pop-up window to request permission of using microphones.
        /// </summary>
        ///
        AUDIO_SCENARIO_CHATROOM = 5,

        ///
        /// <summary>
        /// 7: Real-time chorus scenario, where users have good network conditions and require ultra-low latency.
        /// </summary>
        ///
        AUDIO_SCENARIO_CHORUS = 7,

        ///
        /// <summary>
        /// 8: Meeting scenario that mainly contains the human voice.
        /// </summary>
        ///
        AUDIO_SCENARIO_MEETING = 8,

        ///
        /// <summary>
        /// The number of enumerations.
        /// </summary>
        ///
        AUDIO_SCENARIO_NUM = 9,
    };


    ///
    /// @ignore
    ///
    public enum OPTIONAL_ENUM_SIZE_T
    {
        ///
        /// @ignore
        ///
        kMaxWidthInPixels = 3840,
        ///
        /// @ignore
        ///
        kMaxHeightInPixels = 2160,
        ///
        /// @ignore
        ///
        kMaxFps = 60,
    };

    ///
    /// <summary>
    /// The format of the video frame.
    /// </summary>
    ///
    public class VideoFormat
    {

        public VideoFormat()
        {
            width = (int)FRAME_WIDTH.FRAME_WIDTH_960;
            height = (int)FRAME_HEIGHT.FRAME_HEIGHT_540;
            fps = (int)FRAME_RATE.FRAME_RATE_FPS_15;
        }

        public VideoFormat(int w, int h, int f)
        {
            this.width = w;
            this.height = h;
            this.fps = f;
        }

        ///
        /// <summary>
        /// The width (px) of the video frame.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height (px) of the video frame.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// The video frame rate (fps).
        /// </summary>
        ///
        public int fps;
    };

    ///
    /// <summary>
    /// The content hint for screen sharing.
    /// </summary>
    ///
    public enum VIDEO_CONTENT_HINT
    {
        ///
        /// <summary>
        /// (Default) No content hint.
        /// </summary>
        ///
        CONTENT_HINT_NONE = 0,

        ///
        /// <summary>
        /// Motion-intensive content. Choose this option if you prefer smoothness or when you are sharing a video clip, movie, or video game.
        /// </summary>
        ///
        CONTENT_HINT_MOTION = 1,

        ///
        /// <summary>
        /// Motionless content. Choose this option if you prefer sharpness or when you are sharing a picture, PowerPoint slides, or texts.
        /// </summary>
        ///
        CONTENT_HINT_DETAILS = 2
    };

    ///
    /// <summary>
    /// The screen sharing scenario.
    /// </summary>
    ///
    public enum SCREEN_SCENARIO_TYPE
    {
        ///
        /// <summary>
        /// 1: (Default) Document. This scenario prioritizes the video quality of screen sharing and reduces the latency of the shared video for the receiver. If you share documents, slides, and tables, you can set this scenario.
        /// </summary>
        ///
        SCREEN_SCENARIO_DOCUMENT = 1,

        ///
        /// <summary>
        /// 2: Game. This scenario prioritizes the smoothness of screen sharing. If you share games, you can set this scenario.
        /// </summary>
        ///
        SCREEN_SCENARIO_GAMING = 2,

        ///
        /// <summary>
        /// 3: Video. This scenario prioritizes the smoothness of screen sharing. If you share movies or live videos, you can set this scenario.
        /// </summary>
        ///
        SCREEN_SCENARIO_VIDEO = 3,

        ///
        /// <summary>
        /// 4: Remote control. This scenario prioritizes the video quality of screen sharing and reduces the latency of the shared video for the receiver. If you share the device desktop being remotely controlled, you can set this scenario.
        /// </summary>
        ///
        SCREEN_SCENARIO_RDC = 4,
    };


    ///
    /// <summary>
    /// The video application scenarios.
    /// </summary>
    ///
    public enum VIDEO_APPLICATION_SCENARIO_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) The general scenario.
        /// </summary>
        ///
        APPLICATION_SCENARIO_GENERAL = 0,

        ///
        /// <summary>
        /// If set to APPLICATION_SCENARIO_MEETING (1), the SDK automatically enables the following strategies:In meeting scenarios where low-quality video streams are required to have a high bitrate, the SDK automatically enables multiple technologies used to deal with network congestions, to enhance the performance of the low-quality streams and to ensure the smooth reception by subscribers.The SDK monitors the number of subscribers to the high-quality video stream in real time and dynamically adjusts its configuration based on the number of subscribers.If nobody subscribers to the high-quality stream, the SDK automatically reduces its bitrate and frame rate to save upstream bandwidth.If someone subscribes to the high-quality stream, the SDK resets the high-quality stream to the VideoEncoderConfiguration configuration used in the most recent calling of SetVideoEncoderConfiguration . If no configuration has been set by the user previously, the following values are used:Resolution: (Windows and macOS) 1280 × 720; (Android and iOS) 960 × 540Frame rate: 15 fpsBitrate: (Windows and macOS) 1600 Kbps; (Android and iOS) 1000 KbpsThe SDK monitors the number of subscribers to the low-quality video stream in real time and dynamically enables or disables it based on the number of subscribers.If the user has called SetDualStreamMode [2/2] to set that never send low-quality video stream (DISABLE_SIMULCAST_STREAM), the dynamic adjustment of the low-quality stream in meeting scenarios will not take effect.If nobody subscribes to the low-quality stream, the SDK automatically disables it to save upstream bandwidth.If someone subscribes to the low-quality stream, the SDK enables the low-quality stream and resets it to the SimulcastStreamConfig configuration used in the most recent calling of SetDualStreamMode [2/2]. If no configuration has been set by the user previously, the following values are used:Resolution: 480 × 272Frame rate: 15 fpsBitrate: 500 Kbps1: The meeting scenario.
        /// </summary>
        ///
        APPLICATION_SCENARIO_MEETING = 1,
    };

    ///
    /// <summary>
    /// The brightness level of the video image captured by the local camera.
    /// </summary>
    ///
    public enum CAPTURE_BRIGHTNESS_LEVEL_TYPE
    {
        ///
        /// <summary>
        /// -1: The SDK does not detect the brightness level of the video image. Wait a few seconds to get the brightness level from captureBrightnessLevel in the next callback.
        /// </summary>
        ///
        CAPTURE_BRIGHTNESS_LEVEL_INVALID = -1,

        ///
        /// <summary>
        /// 0: The brightness level of the video image is normal.
        /// </summary>
        ///
        CAPTURE_BRIGHTNESS_LEVEL_NORMAL = 0,

        ///
        /// <summary>
        /// 1: The brightness level of the video image is too bright.
        /// </summary>
        ///
        CAPTURE_BRIGHTNESS_LEVEL_BRIGHT = 1,

        ///
        /// <summary>
        /// 2: The brightness level of the video image is too dark.
        /// </summary>
        ///
        CAPTURE_BRIGHTNESS_LEVEL_DARK = 2,
    };


    ///
    /// <summary>
    /// The state of the local audio.
    /// </summary>
    ///
    public enum LOCAL_AUDIO_STREAM_STATE
    {
        ///
        /// <summary>
        /// 0: The local audio is in the initial state.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The local audio capturing device starts successfully.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_RECORDING = 1,

        ///
        /// <summary>
        /// 2: The first audio frame encodes successfully.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_ENCODING = 2,

        ///
        /// <summary>
        /// 3: The local audio fails to start.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_STATE_FAILED = 3
    };

    ///
    /// <summary>
    /// Local audio state error codes.
    /// </summary>
    ///
    public enum LOCAL_AUDIO_STREAM_ERROR
    {
        ///
        /// <summary>
        /// 0: The local audio is normal.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_OK = 0,

        ///
        /// <summary>
        /// 1: No specified reason for the local audio failure. Remind your users to try to rejoin the channel.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_FAILURE = 1,

        ///
        /// <summary>
        /// 2: No permission to use the local audio capturing device. Remind your users to grant permission.Deprecated:This enumerator is deprecated. Please use RECORD_AUDIO in the OnPermissionError callback instead.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        ///
        /// <summary>
        /// 3: (Android and iOS only) The local audio capture device is used. Remind your users to check whether another application occupies the microphone. Local audio capture automatically resumes after the microphone is idle for about five seconds. You can also try to rejoin the channel after the microphone is idle.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_BUSY = 3,

        ///
        /// <summary>
        /// 4: The local audio capture fails.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE = 4,

        ///
        /// <summary>
        /// 5: The local audio encoding fails.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE = 5,

        ///
        /// <summary>
        /// 6: (Windows only) The application cannot find the local audio capture device. Remind your users to check whether the microphone is connected to the device properly in the control plane of the device or if the microphone is working properly.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_NO_RECORDING_DEVICE = 6,

        ///
        /// <summary>
        /// 7: (Windows only) The application cannot find the local audio playback device. Remind your users to check whether the speaker is connected to the device properly in the control plane of the device or if the speaker is working properly.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_NO_PLAYOUT_DEVICE = 7,

        ///
        /// <summary>
        /// 8: (Android and iOS only) The local audio capture is interrupted by a system call, Siri, or alarm clock. Remind your users to end the phone call, Siri, or alarm clock if the local audio capture is required.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_INTERRUPTED = 8,

        ///
        /// <summary>
        /// 9: (Windows only) The ID of the local audio-capture device is invalid. Check the audio capture device ID.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_RECORD_INVALID_ID = 9,

        ///
        /// <summary>
        /// 10: (Windows only) The ID of the local audio-playback device is invalid. Check the audio playback device ID.
        /// </summary>
        ///
        LOCAL_AUDIO_STREAM_ERROR_PLAYOUT_INVALID_ID = 10,
    };

    ///
    /// <summary>
    /// Local video state types.
    /// </summary>
    ///
    public enum LOCAL_VIDEO_STREAM_STATE
    {
        ///
        /// <summary>
        /// 0: The local video is in the initial state.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The local video capturing device starts successfully. The SDK also reports this state when you call StartScreenCaptureByWindowId to share a maximized window.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_STATE_CAPTURING = 1,

        ///
        /// <summary>
        /// 2: The first video frame is successfully encoded.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_STATE_ENCODING = 2,

        ///
        /// <summary>
        /// 3: Fails to start the local video.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_STATE_FAILED = 3
    };

    ///
    /// <summary>
    /// Local video state error codes.
    /// </summary>
    ///
    public enum LOCAL_VIDEO_STREAM_ERROR
    {
        ///
        /// <summary>
        /// 0: The local video is normal.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_OK = 0,

        ///
        /// <summary>
        /// 1: No specified reason for the local video failure.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_FAILURE = 1,

        ///
        /// <summary>
        /// 2: No permission to use the local video capturing device. Remind the user to grant permissions and rejoin the channel.Deprecated:This enumerator is deprecated. Please use CAMERA in the OnPermissionError callback instead.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        ///
        /// <summary>
        /// 3: The local video capturing device is in use. Remind the user to check whether another application occupies the camera.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY = 3,

        ///
        /// <summary>
        /// 4: The local video capture fails. Remind your user to check whether the video capture device is working properly, whether the camera is occupied by another application, or try to rejoin the channel.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE = 4,

        ///
        /// <summary>
        /// 5: The local video encoding fails.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_ENCODE_FAILURE = 5,

        ///
        /// <summary>
        /// 6: (For iOS only) The app is in the background. Remind the user that video capture cannot be performed normally when the app is in the background.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_INBACKGROUND = 6,

        ///
        /// <summary>
        /// 7: (For iOS only) The current application window is running in Slide Over, Split View, or Picture in Picture mode, and another app is occupying the camera. Remind the user that the application cannot capture video properly when the app is running in Slide Over, Split View, or Picture in Picture mode and another app is occupying the camera.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_MULTIPLE_FOREGROUND_APPS = 7,

        ///
        /// <summary>
        /// 8: Fails to find a local video capture device. Remind the user to check whether the camera is connected to the device properly or the camera is working properly, and then to rejoin the channel.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NOT_FOUND = 8,

        ///
        /// <summary>
        /// 9:(For macOS only) The video capture device currently in use is disconnected (such as being unplugged).
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_DISCONNECTED = 9,

        ///
        /// <summary>
        /// 10: (For macOS and Windows only) The SDK cannot find the video device in the video device list. Check whether the ID of the video device is valid.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_INVALID_ID = 10,

        ///
        /// <summary>
        /// 101: The current video capture device is unavailable due to excessive system pressure.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_SYSTEM_PRESSURE = 101,

        ///
        /// <summary>
        /// 11: (For macOS only) The shared window is minimized when you call StartScreenCaptureByWindowId to share a window. The SDK cannot share a minimized window. You can cancel the minimization of this window at the application layer, for example by maximizing this window.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED = 11,

        ///
        /// <summary>
        /// 12: (For macOS and Windows only) The error code indicates that a window shared by the window ID has been closed or a full-screen window shared by the window ID has exited full-screen mode. After exiting full-screen mode, remote users cannot see the shared window. To prevent remote users from seeing a black screen, Agora recommends that you immediately stop screen sharing.Common scenarios for reporting this error code:When the local user closes the shared window, the SDK reports this error code.The local user shows some slides in full-screen mode first, and then shares the windows of the slides. After the user exits full-screen mode, the SDK reports this error code.The local user watches a web video or reads a web document in full-screen mode first, and then shares the window of the web video or document. After the user exits full-screen mode, the SDK reports this error code.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_CLOSED = 12,

        ///
        /// <summary>
        /// 13: (For Windows only) The window being shared is overlapped by another window, so the overlapped area is blacked out by the SDK during window sharing.
        /// </summary>
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_OCCLUDED = 13,

        ///
        /// @ignore
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_NOT_SUPPORTED = 20,

        ///
        /// @ignore
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_FAILURE = 21,
        ///
        /// @ignore
        ///
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_NO_PERMISSION = 22,
    };

    ///
    /// <summary>
    /// Remote audio states.
    /// </summary>
    ///
    public enum REMOTE_AUDIO_STATE
    {
        ///
        /// <summary>
        /// 0: The local audio is in the initial state. The SDK reports this state in the case of REMOTE_AUDIO_REASON_LOCAL_MUTED, REMOTE_AUDIO_REASON_REMOTE_MUTED or REMOTE_AUDIO_REASON_REMOTE_OFFLINE.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The first remote audio packet is received.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_STARTING = 1,

        ///
        /// <summary>
        /// 2: The remote audio stream is decoded and plays normally. The SDK reports this state in the case of REMOTE_AUDIO_REASON_NETWORK_RECOVERY, REMOTE_AUDIO_REASON_LOCAL_UNMUTED or REMOTE_AUDIO_REASON_REMOTE_UNMUTED.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_DECODING = 2,

        ///
        /// <summary>
        /// 3: The remote audio is frozen. The SDK reports this state in the case of REMOTE_AUDIO_REASON_NETWORK_CONGESTION.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_FROZEN = 3,

        ///
        /// <summary>
        /// 4: The remote audio fails to start. The SDK reports this state in the case of REMOTE_AUDIO_REASON_INTERNAL.
        /// </summary>
        ///
        REMOTE_AUDIO_STATE_FAILED = 4,
    };

    ///
    /// <summary>
    /// The reason for the remote audio state change.
    /// </summary>
    ///
    public enum REMOTE_AUDIO_STATE_REASON
    {
        ///
        /// <summary>
        /// 0: The SDK reports this reason when the audio state changes.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_INTERNAL = 0,

        ///
        /// <summary>
        /// 1: Network congestion.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_NETWORK_CONGESTION = 1,

        ///
        /// <summary>
        /// 2: Network recovery.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_NETWORK_RECOVERY = 2,

        ///
        /// <summary>
        /// 3: The local user stops receiving the remote audio stream or disables the audio module.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_LOCAL_MUTED = 3,

        ///
        /// <summary>
        /// 4: The local user resumes receiving the remote audio stream or enables the audio module.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_LOCAL_UNMUTED = 4,

        ///
        /// <summary>
        /// 5: The remote user stops sending the audio stream or disables the audio module.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_REMOTE_MUTED = 5,

        ///
        /// <summary>
        /// 6: The remote user resumes sending the audio stream or enables the audio module.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_REMOTE_UNMUTED = 6,

        ///
        /// <summary>
        /// 7: The remote user leaves the channel.
        /// </summary>
        ///
        REMOTE_AUDIO_REASON_REMOTE_OFFLINE = 7,
    };

    ///
    /// <summary>
    /// The state of the remote video stream.
    /// </summary>
    ///
    public enum REMOTE_VIDEO_STATE
    {
        ///
        /// <summary>
        /// 0: The remote video is in the initial state. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED, REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED, or REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_STOPPED = 0,

        ///
        /// <summary>
        /// 1: The first remote video packet is received.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_STARTING = 1,

        ///
        /// <summary>
        /// 2: The remote video stream is decoded and plays normally. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY, REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED, REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED, or REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_DECODING = 2,

        ///
        /// <summary>
        /// 3: The remote video is frozen. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION or REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_FROZEN = 3,

        ///
        /// <summary>
        /// 4: The remote video fails to start. The SDK reports this state in the case of REMOTE_VIDEO_STATE_REASON_INTERNAL.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_FAILED = 4,
    };

    ///
    /// <summary>
    /// The reason for the remote video state change.
    /// </summary>
    ///
    public enum REMOTE_VIDEO_STATE_REASON
    {
        ///
        /// <summary>
        /// 0: The SDK reports this reason when the video state changes.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_INTERNAL = 0,

        ///
        /// <summary>
        /// 1: Network congestion.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION = 1,

        ///
        /// <summary>
        /// 2: Network is recovered.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY = 2,

        ///
        /// <summary>
        /// 3: The local user stops receiving the remote video stream or disables the video module.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED = 3,

        ///
        /// <summary>
        /// 4: The local user resumes receiving the remote video stream or enables the video module.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED = 4,

        ///
        /// <summary>
        /// 5: The remote user stops sending the video stream or disables the video module.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED = 5,

        ///
        /// <summary>
        /// 6: The remote user resumes sending the video stream or enables the video module.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED = 6,

        ///
        /// <summary>
        /// 7: The remote user leaves the channel.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE = 7,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK = 8,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY = 9,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_LOW = 10,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_VIDEO_STREAM_TYPE_CHANGE_TO_HIGH = 11,

        ///
        /// <summary>
        /// 12: (iOS only) The remote user's app has switched to the background.
        /// </summary>
        ///
        REMOTE_VIDEO_STATE_REASON_SDK_IN_BACKGROUND = 12,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_STATE_REASON_CODEC_NOT_SUPPORT = 13,
    };

    [Flags]
    ///
    /// @ignore
    ///
    public enum REMOTE_USER_STATE
    {
        ///
        /// @ignore
        ///
        USER_STATE_MUTE_AUDIO = (1 << 0),

        ///
        /// @ignore
        ///
        USER_STATE_MUTE_VIDEO = (1 << 1),

        ///
        /// @ignore
        ///
        USER_STATE_ENABLE_VIDEO = (1 << 4),

        ///
        /// @ignore
        ///
        USER_STATE_ENABLE_LOCAL_VIDEO = (1 << 8),
    };

    ///
    /// @ignore
    ///
    public class VideoTrackInfo
    {
        public VideoTrackInfo()
        {
            isLocal = false;
            ownerUid = 0;
            trackId = 0;
            channelId = null;
            streamType = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
            codecType = VIDEO_CODEC_TYPE.VIDEO_CODEC_H264;
            encodedFrameOnly = false;
            sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            observationPosition = (uint)VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER;
        }

        public VideoTrackInfo(bool isLocal, uint ownerUid, uint trackId,
                              string channelId, VIDEO_STREAM_TYPE streamType,
                              VIDEO_CODEC_TYPE codecType, bool encodedFrameOnly,
                              VIDEO_SOURCE_TYPE sourceType, uint observationPosition)
        {
            this.isLocal = isLocal;
            this.ownerUid = ownerUid;
            this.trackId = trackId;
            this.channelId = channelId;
            this.streamType = streamType;
            this.codecType = codecType;
            this.encodedFrameOnly = encodedFrameOnly;
            this.sourceType = sourceType;
            this.observationPosition = observationPosition;
        }

        ///
        /// @ignore
        ///
        public bool isLocal;

        ///
        /// @ignore
        ///
        public uint ownerUid;

        ///
        /// @ignore
        ///
        public uint trackId;

        ///
        /// @ignore
        ///
        public string channelId;

        ///
        /// @ignore
        ///
        public VIDEO_STREAM_TYPE streamType;

        ///
        /// @ignore
        ///
        public VIDEO_CODEC_TYPE codecType;

        ///
        /// @ignore
        ///
        public bool encodedFrameOnly;

        ///
        /// @ignore
        ///
        public VIDEO_SOURCE_TYPE sourceType;

        ///
        /// @ignore
        ///
        public uint observationPosition;
    };

    ///
    /// @ignore
    ///
    public enum REMOTE_VIDEO_DOWNSCALE_LEVEL
    {
        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE = 0,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_1 = 1,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_2 = 2,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_3 = 3,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_DOWNSCALE_LEVEL_4 = 4,
    };

    ///
    /// <summary>
    /// The volume information of users.
    /// </summary>
    ///
    public class AudioVolumeInfo
    {
        public AudioVolumeInfo()
        {
            uid = 0;
            volume = 0;
            vad = 0;
            voicePitch = 0.0;
        }

        public AudioVolumeInfo(uint uid, uint volume, uint vad, double voicePitch)
        {
            this.uid = uid;
            this.volume = volume;
            this.vad = vad;
            this.voicePitch = voicePitch;
        }

        ///
        /// <summary>
        /// The user ID.In the local user's callback, uid is 0.In the remote users' callback, uid is the user ID of a remote user whose instantaneous volume is the highest.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The volume of the user. The value ranges between 0 (the lowest volume) and 255 (the highest volume). If the local user enables audio capturing and calls MuteLocalAudioStream and set it as true to mute, the value of volume indicates the volume of locally captured audio signal.
        /// </summary>
        ///
        public uint volume;

        ///
        /// <summary>
        /// Voice activity status of the local user.0: The local user is not speaking.1: The local user is speaking.The vad parameter does not report the voice activity status of remote users. In a remote user's callback, the value of vad is always 1.To use this parameter, you must set reportVad to true when calling EnableAudioVolumeIndication .
        /// </summary>
        ///
        public uint vad;

        ///
        /// <summary>
        /// The voice pitch of the local user. The value ranges between 0.0 and 4000.0.The voicePitch parameter does not report the voice pitch of remote users. In the remote users' callback, the value of voicePitch is always 0.0.
        /// </summary>
        ///
        public double voicePitch;
    };


    ///
    /// <summary>
    /// The audio device information.
    /// This class is for Android only.
    /// </summary>
    ///
    public class DeviceInfoMobile
    {
        ///
        /// <summary>
        /// Whether the audio device supports ultra-low-latency capture and playback:true: The device supports ultra-low-latency capture and playback.false: The device does not support ultra-low-latency capture and playback.
        /// </summary>
        ///
        public bool isLowLatencyAudioSupported;
    };
    ///
    /// <summary>
    /// The DeviceInfo class that contains the ID and device name of the video devices.
    /// </summary>
    ///
    public class DeviceInfo
    {
        ///
        /// <summary>
        /// The device name.
        /// </summary>
        ///
        public string deviceName;

        ///
        /// <summary>
        /// The device ID.
        /// </summary>
        ///
        public string deviceId;
    };

    ///
    /// <summary>
    /// The audio sampling rate of the stream to be pushed to the CDN.
    /// </summary>
    ///
    public enum AUDIO_SAMPLE_RATE_TYPE
    {
        ///
        /// <summary>
        /// 32000: 32 kHz
        /// </summary>
        ///
        AUDIO_SAMPLE_RATE_32000 = 32000,

        ///
        /// <summary>
        /// 44100: 44.1 kHz
        /// </summary>
        ///
        AUDIO_SAMPLE_RATE_44100 = 44100,

        ///
        /// <summary>
        /// 48000: (Default) 48 kHz
        /// </summary>
        ///
        AUDIO_SAMPLE_RATE_48000 = 48000,
    };
    ///
    /// <summary>
    /// The codec type of the output video.
    /// </summary>
    ///
    public enum VIDEO_CODEC_TYPE_FOR_STREAM
    {
        ///
        /// <summary>
        /// 1: (Default) H.264.
        /// </summary>
        ///
        VIDEO_CODEC_H264_FOR_STREAM = 1,

        ///
        /// <summary>
        /// 2: H.265.
        /// </summary>
        ///
        VIDEO_CODEC_H265_FOR_STREAM = 2,
    };

    ///
    /// <summary>
    /// Video codec profile types.
    /// </summary>
    ///
    public enum VIDEO_CODEC_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 66: Baseline video codec profile; generally used for video calls on mobile phones.
        /// </summary>
        ///
        VIDEO_CODEC_PROFILE_BASELINE = 66,

        ///
        /// <summary>
        /// 77: Main video codec profile; generally used in mainstream electronics such as MP4 players, portable video players, PSP, and iPads.
        /// </summary>
        ///
        VIDEO_CODEC_PROFILE_MAIN = 77,

        ///
        /// <summary>
        /// 100: (Default) High video codec profile; generally used in high-resolution live streaming or television.
        /// </summary>
        ///
        VIDEO_CODEC_PROFILE_HIGH = 100,
    };

    ///
    /// <summary>
    /// Self-defined audio codec profile.
    /// </summary>
    ///
    public enum AUDIO_CODEC_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) LC-AAC.
        /// </summary>
        ///
        AUDIO_CODEC_PROFILE_LC_AAC = 0,

        ///
        /// <summary>
        /// 1: HE-AAC.
        /// </summary>
        ///
        AUDIO_CODEC_PROFILE_HE_AAC = 1,

        ///
        /// <summary>
        /// 2: HE-AAC v2.
        /// </summary>
        ///
        AUDIO_CODEC_PROFILE_HE_AAC_V2 = 2,
    };

    ///
    /// <summary>
    /// Local audio statistics.
    /// </summary>
    ///
    public class LocalAudioStats
    {
        public LocalAudioStats()
        {
        }

        public LocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate, int internalCodec, ushort txPacketLossRate, int audioDeviceDelay)
        {
            this.numChannels = numChannels;
            this.sentSampleRate = sentSampleRate;
            this.sentBitrate = sentBitrate;
            this.internalCodec = internalCodec;
            this.txPacketLossRate = txPacketLossRate;
            this.audioDeviceDelay = audioDeviceDelay;
        }

        ///
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        ///
        public int numChannels;

        ///
        /// <summary>
        /// The sampling rate (Hz) of sending the local user's audio stream.
        /// </summary>
        ///
        public int sentSampleRate;

        ///
        /// <summary>
        /// The average bitrate (Kbps) of sending the local user's audio stream.
        /// </summary>
        ///
        public int sentBitrate;

        ///
        /// <summary>
        /// The internal payload codec.
        /// </summary>
        ///
        public int internalCodec;

        ///
        /// <summary>
        /// The packet loss rate (%) from the local client to the Agora server before applying the anti-packet loss strategies.
        /// </summary>
        ///
        public ushort txPacketLossRate;

        ///
        /// <summary>
        /// The delay of the audio device module when playing or recording audio.
        /// </summary>
        ///
        public int audioDeviceDelay;
    }

    ///
    /// <summary>
    /// States of the Media Push.
    /// </summary>
    ///
    public enum RTMP_STREAM_PUBLISH_STATE
    {
        ///
        /// <summary>
        /// 0: The Media Push has not started or has ended.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: The streaming server and CDN server are being connected.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_CONNECTING = 1,

        ///
        /// <summary>
        /// 2: The RTMP or RTMPS streaming publishes. The SDK successfully publishes the RTMP or RTMPS streaming and returns this state.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_RUNNING = 2,

        ///
        /// <summary>
        /// 3: The RTMP or RTMPS streaming is recovering. When exceptions occur to the CDN, or the streaming is interrupted, the SDK tries to resume RTMP or RTMPS streaming and returns this state.If the SDK successfully resumes the streaming, RTMP_STREAM_PUBLISH_STATE_RUNNING(2) returns.If the streaming does not resume within 60 seconds or server errors occur, RTMP_STREAM_PUBLISH_STATE_FAILURE(4) returns. If you feel that 60 seconds is too long, you can also actively try to reconnect.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        ///
        /// <summary>
        /// 4: The RTMP or RTMPS streaming fails. After a failure, you can troubleshoot the cause of the error through the returned error code.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,

        ///
        /// <summary>
        /// 5: The SDK is disconnecting from the Agora streaming server and CDN. When you call StopRtmpStream to stop the Media Push normally, the SDK reports the Media Push state as RTMP_STREAM_PUBLISH_STATE_DISCONNECTING and RTMP_STREAM_PUBLISH_STATE_IDLE in sequence.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_STATE_DISCONNECTING = 5,
    };

    ///
    /// <summary>
    /// Error codes of the RTMP or RTMPS streaming.
    /// </summary>
    ///
    public enum RTMP_STREAM_PUBLISH_ERROR_TYPE
    {
        ///
        /// <summary>
        /// 0: The RTMP or RTMPS streaming has not started or has ended.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_OK = 0,

        ///
        /// <summary>
        /// 1: Invalid argument used. Check the parameter setting.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_INVALID_ARGUMENT = 1,

        ///
        /// <summary>
        /// 2: The RTMP or RTMPS streaming is encrypted and cannot be published.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_ENCRYPTED_STREAM_NOT_ALLOWED = 2,

        ///
        /// <summary>
        /// 3: Timeout for the RTMP or RTMPS streaming.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT = 3,

        ///
        /// <summary>
        /// 4: An error occurs in Agora's streaming server.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_INTERNAL_SERVER_ERROR = 4,

        ///
        /// <summary>
        /// 5: An error occurs in the CDN server.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_RTMP_SERVER_ERROR = 5,

        ///
        /// <summary>
        /// 6: The RTMP or RTMPS streaming publishes too frequently.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_TOO_OFTEN = 6,

        ///
        /// <summary>
        /// 7: The host publishes more than 10 URLs. Delete the unnecessary URLs before adding new ones.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_REACH_LIMIT = 7,

        ///
        /// <summary>
        /// 8: The host manipulates other hosts' URLs. For example, the host updates or stops other hosts' streams. Check your app logic.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_NOT_AUTHORIZED = 8,

        ///
        /// <summary>
        /// 9: Agora's server fails to find the RTMP or RTMPS streaming.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_STREAM_NOT_FOUND = 9,

        ///
        /// <summary>
        /// 10: The format of the RTMP or RTMPS streaming URL is not supported. Check whether the URL format is correct.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_FORMAT_NOT_SUPPORTED = 10,

        ///
        /// <summary>
        /// 11: The user role is not host, so the user cannot use the CDN live streaming function. Check your application code logic.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_NOT_BROADCASTER = 11,

        ///
        /// <summary>
        /// 13: The UpdateRtmpTranscoding method is called to update the transcoding configuration in a scenario where there is streaming without transcoding. Check your application code logic.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_TRANSCODING_NO_MIX_STREAM = 13,

        ///
        /// <summary>
        /// 14: Errors occurred in the host's network.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_NET_DOWN = 14,

        ///
        /// @ignore
        ///
        RTMP_STREAM_PUBLISH_ERROR_INVALID_APPID = 15,

        ///
        /// <summary>
        /// 16: Your project does not have permission to use streaming services. Refer to Media Push to enable the Media Push permission.
        /// </summary>
        ///
        RTMP_STREAM_PUBLISH_ERROR_INVALID_PRIVILEGE = 16,

        ///
        /// <summary>
        /// 100: The streaming has been stopped normally. After you stop the Media Push, the SDK returns this value.
        /// </summary>
        ///
        RTMP_STREAM_UNPUBLISH_ERROR_OK = 100,
    };

    ///
    /// <summary>
    /// Events during the Media Push.
    /// </summary>
    ///
    public enum RTMP_STREAMING_EVENT
    {
        ///
        /// <summary>
        /// 1: An error occurs when you add a background image or a watermark image in the Media Push.
        /// </summary>
        ///
        RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE = 1,

        ///
        /// <summary>
        /// 2: The streaming URL is already being used for Media Push. If you want to start new streaming, use a new streaming URL.
        /// </summary>
        ///
        RTMP_STREAMING_EVENT_URL_ALREADY_IN_USE = 2,

        ///
        /// <summary>
        /// 3: The feature is not supported.
        /// </summary>
        ///
        RTMP_STREAMING_EVENT_ADVANCED_FEATURE_NOT_SUPPORT = 3,

        ///
        /// <summary>
        /// 4: Reserved.
        /// </summary>
        ///
        RTMP_STREAMING_EVENT_REQUEST_TOO_OFTEN = 4,
    };

    ///
    /// <summary>
    /// Image properties.
    /// This class sets the properties of the watermark and background images in the live video.
    /// </summary>
    ///
    public class RtcImage
    {
        public RtcImage()
        {
            url = null;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            zOrder = 0;
            alpha = 1.0;
        }

        public RtcImage(string url, int x, int y, int width, int height, int zOrder, double alpha)
        {
            this.url = url;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
        }

        ///
        /// <summary>
        /// The HTTP/HTTPS URL address of the image in the live video. The maximum length of this parameter is 1024 bytes.
        /// </summary>
        ///
        public string url;

        ///
        /// <summary>
        /// The x coordinate (pixel) of the image on the video frame (taking the upper left corner of the video frame as the origin).
        /// </summary>
        ///
        public int x;

        ///
        /// <summary>
        /// The y coordinate (pixel) of the image on the video frame (taking the upper left corner of the video frame as the origin).
        /// </summary>
        ///
        public int y;

        ///
        /// <summary>
        /// The width (pixel) of the image on the video frame.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height (pixel) of the image on the video frame.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// The layer index of the watermark or background image. When you use the watermark array to add a watermark or multiple watermarks, you must pass a value to zOrder in the range [1,255]; otherwise, the SDK reports an error. In other cases, zOrder can optionally be passed in the range [0,255], with 0 being the default value. 0 means the bottom layer and 255 means the top layer.
        /// </summary>
        ///
        public int zOrder;

        ///
        /// <summary>
        /// The transparency of the watermark or background image. The range of the value is [0.0,1.0]:0.0: Completely transparent.1.0: (Default) Opaque.
        /// </summary>
        ///
        public double alpha;
    };

    ///
    /// <summary>
    /// The configuration for advanced features of the RTMP or RTMPS streaming with transcoding.
    /// If you want to enable the advanced features of streaming with transcoding, contact .
    /// </summary>
    ///
    public class LiveStreamAdvancedFeature
    {
        public LiveStreamAdvancedFeature()
        {
            featureName = null;
            opened = false;
        }

        public LiveStreamAdvancedFeature(string feat_name, bool open)
        {
            featureName = feat_name;
            opened = open;
        }

        ///
        /// <summary>
        /// The feature names, including LBHQ (high-quality video with a lower bitrate) and VEO (optimized video encoder).
        /// </summary>
        ///
        public string featureName;

        ///
        /// <summary>
        /// Whether to enable the advanced features of streaming with transcoding:true: Enable the advanced features.false: (Default) Do not enable the advanced features.
        /// </summary>
        ///
        public bool opened;
    };

    ///
    /// <summary>
    /// Connection states.
    /// </summary>
    ///
    public enum CONNECTION_STATE_TYPE
    {
        ///
        /// <summary>
        /// 1: The SDK is disconnected from the Agora edge server. The state indicates the SDK is in one of the following phases:Theinitial state before calling the JoinChannel [2/2] method.The app calls the LeaveChannel [1/2]
        /// </summary>
        ///
        CONNECTION_STATE_DISCONNECTED = 1,

        ///
        /// <summary>
        /// 2: The SDK is connecting to the Agora edge server. This state indicates that the SDK is establishing a connection with the specified channel after the app calls JoinChannel [2/2].If the SDK successfully joins the channel, it triggers the OnConnectionStateChanged callback and the connection state switches to CONNECTION_STATE_CONNECTED.After the connection is established, the SDK also initializes the media and triggers OnJoinChannelSuccess when everything is ready.
        /// </summary>
        ///
        CONNECTION_STATE_CONNECTING = 2,

        ///
        /// <summary>
        /// 3: The SDK is connected to the Agora edge server. This state also indicates that the user has joined a channel and can now publish or subscribe to a media stream in the channel. If the connection to the channel is lost because, for example, if the network is down or switched, the SDK automatically tries to reconnect and triggers OnConnectionStateChanged callback, notifying that the current network state becomes CONNECTION_STATE_RECONNECTING.
        /// </summary>
        ///
        CONNECTION_STATE_CONNECTED = 3,

        ///
        /// <summary>
        /// 4: The SDK keeps reconnecting to the Agora edge server. The SDK keeps rejoining the channel after being disconnected from a joined channel because of network issues.If the SDK cannot rejoin the channel within 10 seconds, it triggers OnConnectionLost , stays in the CONNECTION_STATE_RECONNECTING state, and keeps rejoining the channel.If the SDK fails to rejoin the channel 20 minutes after being disconnected from the Agora edge server, the SDK triggers the OnConnectionStateChanged callback, switches to the CONNECTION_STATE_FAILED state, and stops rejoining the channel.
        /// </summary>
        ///
        CONNECTION_STATE_RECONNECTING = 4,

        ///
        /// <summary>
        /// 5: The SDK fails to connect to the Agora edge server or join the channel. This state indicates that the SDK stops trying to rejoin the channel. You must call LeaveChannel [1/2] You can call JoinChannel [2/2] to rejoin the channel.If the SDK is banned from joining the channel by the Agora edge server through the RESTful API, the SDK triggers the OnConnectionStateChanged callback.
        /// </summary>
        ///
        CONNECTION_STATE_FAILED = 5,
    };

    ///
    /// <summary>
    /// Transcoding configurations of each host.
    /// </summary>
    ///
    public class TranscodingUser
    {
        public TranscodingUser()
        {
            uid = 0;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            zOrder = 0;
            alpha = 1.0;
            audioChannel = 0;
        }

        public TranscodingUser(uint uid, int x, int y, int width, int height, int zOrder, double alpha,
            int audioChannel)
        {
            this.uid = uid;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
            this.audioChannel = audioChannel;
        }

        ///
        /// <summary>
        /// The user ID of the host.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The x coordinate (pixel) of the host's video on the output video frame (taking the upper left corner of the video frame as the origin). The value range is [0, width], where width is the width set in LiveTranscoding .
        /// </summary>
        ///
        public int x;

        ///
        /// <summary>
        /// The y coordinate (pixel) of the host's video on the output video frame (taking the upper left corner of the video frame as the origin). The value range is [0, height], where height is the height set in LiveTranscoding .
        /// </summary>
        ///
        public int y;

        ///
        /// <summary>
        /// The width (pixel) of the host's video.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height (pixel) of the host's video.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// The layer index number of the host's video. The value range is [0, 100].0: (Default) The host's video is the bottom layer.100: The host's video is the top layer.If the value is less than 0 or greater than 100, ERR_INVALID_ARGUMENT error is returned.Setting zOrder to 0 is supported.
        /// </summary>
        ///
        public int zOrder;

        ///
        /// <summary>
        /// The transparency of the host's video. The value range is [0.0,1.0].0.0: Completely transparent.1.0: (Default) Opaque.
        /// </summary>
        ///
        public double alpha;

        ///
        /// <summary>
        /// The audio channel used by the host's audio in the output audio. The default value is 0, and the value range is [0, 5].0: (Recommended) The defaut setting, which supports dual channels at most and depends on the upstream of the host.1: The host's audio uses the FL audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.2: The host's audio uses the FC audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.3: The host's audio uses the FR audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.4: The host's audio uses the BL audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.5: The host's audio uses the BR audio channel. If the host's upstream uses multiple audio channels, the Agora server mixes them into mono first.0xFF or a value greater than 5: The host's audio is muted, and the Agora server removes the host's audio.If the value is not 0, a special player is required.
        /// </summary>
        ///
        public int audioChannel;
    };

    ///
    /// <summary>
    /// Transcoding configurations for Media Push.
    /// </summary>
    ///
    public class LiveTranscoding
    {
        public LiveTranscoding()
        {
            width = 360;
            height = 640;
            videoBitrate = 400;
            videoFramerate = 15;
            lowLatency = false;
            videoGop = 30;
            videoCodecProfile = VIDEO_CODEC_PROFILE_TYPE.VIDEO_CODEC_PROFILE_HIGH;
            backgroundColor = 0x000000;
            videoCodecType = VIDEO_CODEC_TYPE_FOR_STREAM.VIDEO_CODEC_H264_FOR_STREAM;
            userCount = 0;
            transcodingUsers = new TranscodingUser[0];
            transcodingExtraInfo = null;
            metadata = null;
            watermark = new RtcImage[0];
            watermarkCount = 0;
            backgroundImage = new RtcImage[0];
            backgroundImageCount = 0;
            audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            audioBitrate = 48;
            audioChannels = 1;
            audioCodecProfile = AUDIO_CODEC_PROFILE_TYPE.AUDIO_CODEC_PROFILE_LC_AAC;
            advancedFeatures = new LiveStreamAdvancedFeature[0];
            advancedFeatureCount = 0;
        }

        public LiveTranscoding(int width, int height, int videoBitrate, int videoFramerate, bool lowLatency,
            int videoGop, VIDEO_CODEC_PROFILE_TYPE videoCodecProfile, uint backgroundColor,
            VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType, uint userCount, TranscodingUser[] transcodingUsers,
            string transcodingExtraInfo, string metadata, RtcImage[] watermark, uint watermarkCount,
            RtcImage[] backgroundImage, uint backgroundImageCount,
            AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels,
            AUDIO_CODEC_PROFILE_TYPE audioCodecProfile, LiveStreamAdvancedFeature[] advancedFeatures, uint advancedFeatureCount)
        {
            this.width = width;
            this.height = height;
            this.videoBitrate = videoBitrate;
            this.videoFramerate = videoFramerate;
            this.lowLatency = lowLatency;
            this.videoGop = videoGop;
            this.videoCodecProfile = videoCodecProfile;
            this.backgroundColor = backgroundColor;
            this.videoCodecType = videoCodecType;
            this.userCount = userCount;
            this.transcodingUsers = transcodingUsers;
            this.transcodingExtraInfo = transcodingExtraInfo;
            this.metadata = metadata;
            this.watermark = watermark;
            this.watermarkCount = watermarkCount;
            this.backgroundImage = backgroundImage;
            this.backgroundImageCount = backgroundImageCount;
            this.audioSampleRate = audioSampleRate;
            this.audioBitrate = audioBitrate;
            this.audioChannels = audioChannels;
            this.audioCodecProfile = audioCodecProfile;
            this.advancedFeatures = advancedFeatures;
            this.advancedFeatureCount = advancedFeatureCount;
        }

        ///
        /// <summary>
        /// The width of the video in pixels. The default value is 360.When pushing video streams to the CDN, the value range of width is [64,1920]. If the value is less than 64, Agora server automatically adjusts it to 64; if the value is greater than 1920, Agora server automatically adjusts it to 1920.When pushing audio streams to the CDN, set width and height as 0.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height of the video in pixels. The default value is 640.When pushing video streams to the CDN, the value range of height is [64,1080]. If the value is less than 64, Agora server automatically adjusts it to 64; if the value is greater than 1080, Agora server automatically adjusts it to 1080.When pushing audio streams to the CDN, set width and height as 0.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// Bitrate of the output video stream for Media Push in Kbps. The default value is 400 Kbps.
        /// </summary>
        ///
        public int videoBitrate;

        ///
        /// <summary>
        /// Frame rate (fps) of the output video stream set for Media Push. The default value is 15. The value range is (0,30].The Agora server adjusts any value over 30 to 30.
        /// </summary>
        ///
        public int videoFramerate;

        ///
        /// <summary>
        /// DeprecatedThis member is deprecated.Latency mode:true: Low latency with unassured quality.false: (Default) High latency with assured quality.
        /// </summary>
        ///
        public bool lowLatency;

        ///
        /// <summary>
        /// GOP (Group of Pictures) in fps of the video frames for Media Push. The default value is 30.
        /// </summary>
        ///
        public int videoGop;

        ///
        /// <summary>
        /// Video codec profile type for Media Push. Set it as 66, 77, or 100 (default). See VIDEO_CODEC_PROFILE_TYPE for details.If you set this parameter to any other value, Agora adjusts it to the default value.
        /// </summary>
        ///
        public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile;

        ///
        /// <summary>
        /// The background color in RGB hex value. Value only. Do not include a preceeding #. For example, 0xFFB6C1 (light pink). The default value is 0x000000 (black).
        /// </summary>
        ///
        public uint backgroundColor;

        ///
        /// <summary>
        /// Video codec profile types for Media Push. See VIDEO_CODEC_TYPE_FOR_STREAM .
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType;

        ///
        /// <summary>
        /// The number of users in the Media Push. The value range is [0,17].
        /// </summary>
        ///
        public uint userCount;

        ///
        /// <summary>
        /// Manages the user layout configuration in the Media Push. Agora supports a maximum of 17 transcoding users in a Media Push channel. See TranscodingUser .
        /// </summary>
        ///
        public TranscodingUser[] transcodingUsers;

        ///
        /// <summary>
        /// Reserved property. Extra user-defined information to send SEI for the H.264/H.265 video stream to the CDN live client. Maximum length: 4096 bytes. For more information on SEI, see SEI-related questions.
        /// </summary>
        ///
        public string transcodingExtraInfo;

        ///
        /// <summary>
        /// DeprecatedObsolete and not recommended for use.The metadata sent to the CDN client.
        /// </summary>
        ///
        public string metadata;

        ///
        /// <summary>
        /// The watermark on the live video. The image format needs to be PNG. See RtcImage .You can add one watermark, or add multiple watermarks using an array. This parameter is used with watermarkCount.
        /// </summary>
        ///
        public RtcImage[] watermark;

        ///
        /// <summary>
        /// The number of watermarks on the live video. The total number of watermarks and background images can range from 0 to 10. This parameter is used with watermark.
        /// </summary>
        ///
        public uint watermarkCount;

        ///
        /// <summary>
        /// The number of background images on the live video. The image format needs to be PNG. See RtcImage .You can add a background image or use an array to add multiple background images. This parameter is used with backgroundImageCount.
        /// </summary>
        ///
        public RtcImage[] backgroundImage;

        ///
        /// <summary>
        /// The number of background images on the live video. The total number of watermarks and background images can range from 0 to 10. This parameter is used with backgroundImage.
        /// </summary>
        ///
        public uint backgroundImageCount;

        ///
        /// <summary>
        /// The audio sampling rate (Hz) of the output media stream. See AUDIO_SAMPLE_RATE_TYPE .
        /// </summary>
        ///
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate;

        ///
        /// <summary>
        /// Bitrate (Kbps) of the audio output stream for Media Push. The default value is 48, and the highest value is 128.
        /// </summary>
        ///
        public int audioBitrate;

        ///
        /// <summary>
        /// The number of audio channels for Media Push. Agora recommends choosing 1 (mono), or 2 (stereo) audio channels. Special players are required if you choose 3, 4, or 5.1: (Default) Mono2: Stereo.3: Three audio channels.4: Four audio channels.5: Five audio channels.
        /// </summary>
        ///
        public int audioChannels;

        ///
        /// <summary>
        /// Audio codec profile type for Media Push. See AUDIO_CODEC_PROFILE_TYPE .
        /// </summary>
        ///
        public AUDIO_CODEC_PROFILE_TYPE audioCodecProfile;

        ///
        /// <summary>
        /// Advanced features of the Media Push with transcoding. See LiveStreamAdvancedFeature .
        /// </summary>
        ///
        public LiveStreamAdvancedFeature[] advancedFeatures;

        ///
        /// <summary>
        /// The number of enabled advanced features. The default value is 0.
        /// </summary>
        ///
        public uint advancedFeatureCount;
    };

    ///
    /// <summary>
    /// The video streams for local video mixing.
    /// </summary>
    ///
    public class TranscodingVideoStream
    {
        public TranscodingVideoStream()
        {
            sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            remoteUserUid = 0;
            imageUrl = null;
            mediaPlayerId = 0;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            zOrder = 0;
            alpha = 1.0;
            mirror = false;
        }

        public TranscodingVideoStream(VIDEO_SOURCE_TYPE sourceType, uint remoteUserUid,
            string imageUrl, int mediaPlayerId, int x, int y, int width, int height, int zOrder, double alpha,
            bool mirror)
        {
            this.sourceType = sourceType;
            this.remoteUserUid = remoteUserUid;
            this.imageUrl = imageUrl;
            this.mediaPlayerId = mediaPlayerId;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
            this.mirror = mirror;
        }

        ///
        /// <summary>
        /// The video source type for local video mixing. See VIDEO_SOURCE_TYPE .
        /// </summary>
        ///
        public VIDEO_SOURCE_TYPE sourceType;

        ///
        /// <summary>
        /// The user ID of the remote user.Use this parameter only when the source type is VIDEO_SOURCE_REMOTE for local video mixing.
        /// </summary>
        ///
        public uint remoteUserUid;

        ///
        /// <summary>
        /// The URL of the image.Use this parameter only when the source type is the image for local video mixing.
        /// </summary>
        ///
        public string imageUrl;

        ///
        /// <summary>
        /// (Optional) Media player ID. Use the parameter only when you set sourceType to VIDEO_SOURCE_MEDIA_PLAYER.
        /// </summary>
        ///
        public int mediaPlayerId;
        ///
        /// <summary>
        /// The relative lateral displacement of the top left corner of the video for local video mixing to the origin (the top left corner of the canvas).
        /// </summary>
        ///
        public int x;

        ///
        /// <summary>
        /// The relative longitudinal displacement of the top left corner of the captured video to the origin (the top left corner of the canvas).
        /// </summary>
        ///
        public int y;

        ///
        /// <summary>
        /// The width (px) of the video for local video mixing on the canvas.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height (px) of the video for local video mixing on the canvas.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// The number of the layer to which the video for the local video mixing belongs. The value range is [0, 100].0: (Default) The layer is at the bottom.100: The layer is at the top.
        /// </summary>
        ///
        public int zOrder;

        ///
        /// <summary>
        /// The transparency of the video for local video mixing. The value range is [0.0, 1.0]. 0.0 indicates that the video is completely transparent, and 1.0 indicates that it is opaque.
        /// </summary>
        ///
        public double alpha;

        ///
        /// <summary>
        /// Whether to mirror the video for the local video mixing.true: Mirror the video for the local video mixing.false: (Default) Do not mirror the video for the local video mixing.This parameter only takes effect on video source types that are cameras.
        /// </summary>
        ///
        public bool mirror;
    };

    ///
    /// <summary>
    /// The configuration of the video mixing on the local client.
    /// </summary>
    ///
    public class LocalTranscoderConfiguration
    {
        public LocalTranscoderConfiguration()
        {
            streamCount = 0;
            videoInputStreams = null;
            videoOutputConfiguration = new VideoEncoderConfiguration();
            syncWithPrimaryCamera = true;
        }

        public LocalTranscoderConfiguration(uint streamCount, TranscodingVideoStream[] VideoInputStreams,
                                            VideoEncoderConfiguration videoOutputConfiguration)
        {
            this.streamCount = streamCount;
            this.videoInputStreams = VideoInputStreams;
            this.videoOutputConfiguration = videoOutputConfiguration;
        }

        ///
        /// <summary>
        /// The number of the video streams for the video mixing on the local client.
        /// </summary>
        ///
        public uint streamCount;

        ///
        /// <summary>
        /// The video streams for local video mixing. See TranscodingVideoStream .
        /// </summary>
        ///
        public TranscodingVideoStream[] videoInputStreams;

        ///
        /// <summary>
        /// The encoding configuration of the mixed video stream after the local video mixing. See VideoEncoderConfiguration .
        /// </summary>
        ///
        public VideoEncoderConfiguration videoOutputConfiguration;

        ///
        /// @ignore
        ///
        public bool syncWithPrimaryCamera;
    };


    ///
    /// <summary>
    /// The error code of the local video mixing failure.
    /// </summary>
    ///
    public enum VIDEO_TRANSCODER_ERROR
    {
        ///
        /// @ignore
        ///
        VT_ERR_OK = 0,

        ///
        /// <summary>
        /// 1: The selected video source has not started video capture. You need to create a video track for it and start video capture.
        /// </summary>
        ///
        VT_ERR_VIDEO_SOURCE_NOT_READY = 1,

        ///
        /// <summary>
        /// 2: The video source type is invalid. You need to re-specify the supported video source type.
        /// </summary>
        ///
        VT_ERR_INVALID_VIDEO_SOURCE_TYPE = 2,

        ///
        /// <summary>
        /// 3: The image path is invalid. You need to re-specify the correct image path.
        /// </summary>
        ///
        VT_ERR_INVALID_IMAGE_PATH = 3,

        ///
        /// <summary>
        /// 4: The image format is invalid. Make sure the image format is one of PNG, JPEG, or GIF.
        /// </summary>
        ///
        VT_ERR_UNSUPPORT_IMAGE_FORMAT = 4,

        ///
        /// <summary>
        /// 5: The video encoding resolution after video mixing is invalid.
        /// </summary>
        ///
        VT_ERR_INVALID_LAYOUT = 5,

        ///
        /// <summary>
        /// 20: Unknown internal error.
        /// </summary>
        ///
        VT_ERR_INTERNAL = 20
    };

    ///
    /// <summary>
    /// Configurations of the last-mile network test.
    /// </summary>
    ///
    public class LastmileProbeConfig
    {
        public LastmileProbeConfig()
        {
        }

        public LastmileProbeConfig(bool probeUplink, bool probeDownlink, uint expectedUplinkBitrate,
            uint expectedDownlinkBitrate)
        {
            this.probeUplink = probeUplink;
            this.probeDownlink = probeDownlink;
            this.expectedUplinkBitrate = expectedUplinkBitrate;
            this.expectedDownlinkBitrate = expectedDownlinkBitrate;
        }

        ///
        /// <summary>
        /// Sets whether to test the uplink network. Some users, for example, the audience members in a LIVE_BROADCASTING channel, do not need such a test.true: Test the uplink network.false: Do not test the uplink network.
        /// </summary>
        ///
        public bool probeUplink;

        ///
        /// <summary>
        /// Sets whether to test the downlink network:true: Test the downlink network.false: Do not test the downlink network.
        /// </summary>
        ///
        public bool probeDownlink;

        ///
        /// <summary>
        /// The expected maximum uplink bitrate (bps) of the local user. The value range is [100000, 5000000]. Agora recommends referring to SetVideoEncoderConfiguration to set the value.
        /// </summary>
        ///
        public uint expectedUplinkBitrate;

        ///
        /// <summary>
        /// The expected maximum downlink bitrate (bps) of the local user. The value range is [100000,5000000].
        /// </summary>
        ///
        public uint expectedDownlinkBitrate;
    };

    ///
    /// <summary>
    /// The status of the last-mile probe test.
    /// </summary>
    ///
    public enum LASTMILE_PROBE_RESULT_STATE
    {
        ///
        /// <summary>
        /// 1: The last-mile network probe test is complete.
        /// </summary>
        ///
        LASTMILE_PROBE_RESULT_COMPLETE = 1,

        ///
        /// <summary>
        /// 2: The last-mile network probe test is incomplete because the bandwidth estimation is not available due to limited test resources. One possible reason is that testing resources are temporarily limited.
        /// </summary>
        ///
        LASTMILE_PROBE_RESULT_INCOMPLETE_NO_BWE = 2,

        ///
        /// <summary>
        /// 3: The last-mile network probe test is not carried out. Probably due to poor network conditions.
        /// </summary>
        ///
        LASTMILE_PROBE_RESULT_UNAVAILABLE = 3
    };

    ///
    /// <summary>
    /// Results of the uplink or downlink last-mile network test.
    /// </summary>
    ///
    public class LastmileProbeOneWayResult
    {
        public LastmileProbeOneWayResult()
        {
        }

        public LastmileProbeOneWayResult(uint packetLossRate, uint jitter, uint availableBandwidth)
        {
            this.packetLossRate = packetLossRate;
            this.jitter = jitter;
            this.availableBandwidth = availableBandwidth;
        }

        ///
        /// <summary>
        /// The packet loss rate (%).
        /// </summary>
        ///
        public uint packetLossRate;

        ///
        /// <summary>
        /// The network jitter (ms).
        /// </summary>
        ///
        public uint jitter;

        ///
        /// <summary>
        /// The estimated available bandwidth (bps).
        /// </summary>
        ///
        public uint availableBandwidth;
    };

    ///
    /// <summary>
    /// Results of the uplink and downlink last-mile network tests.
    /// </summary>
    ///
    public class LastmileProbeResult
    {
        public LastmileProbeResult()
        {
            state = LASTMILE_PROBE_RESULT_STATE.LASTMILE_PROBE_RESULT_UNAVAILABLE;
            rtt = 0;
            uplinkReport = new LastmileProbeOneWayResult();
            downlinkReport = new LastmileProbeOneWayResult();
        }

        public LastmileProbeResult(LASTMILE_PROBE_RESULT_STATE state, LastmileProbeOneWayResult uplinkReport,
            LastmileProbeOneWayResult downlinkReport, uint rtt)
        {
            this.state = state;
            this.uplinkReport = uplinkReport;
            this.downlinkReport = downlinkReport;
            this.rtt = rtt;
        }

        ///
        /// <summary>
        /// The status of the last-mile network tests. See LASTMILE_PROBE_RESULT_STATE .
        /// </summary>
        ///
        public LASTMILE_PROBE_RESULT_STATE state;

        ///
        /// <summary>
        /// Results of the uplink last-mile network test. See LastmileProbeOneWayResult .
        /// </summary>
        ///
        public LastmileProbeOneWayResult uplinkReport;

        ///
        /// <summary>
        /// Results of the downlink last-mile network test. See LastmileProbeOneWayResult .
        /// </summary>
        ///
        public LastmileProbeOneWayResult downlinkReport;

        ///
        /// <summary>
        /// The round-trip time (ms).
        /// </summary>
        ///
        public uint rtt;
    };

    ///
    /// <summary>
    /// Reasons causing the change of the connection state.
    /// </summary>
    ///
    public enum CONNECTION_CHANGED_REASON_TYPE
    {
        ///
        /// <summary>
        /// 0: The SDK is connecting to the Agora edge server.
        /// </summary>
        ///
        CONNECTION_CHANGED_CONNECTING = 0,

        ///
        /// <summary>
        /// 1: The SDK has joined the channel successfully.
        /// </summary>
        ///
        CONNECTION_CHANGED_JOIN_SUCCESS = 1,

        ///
        /// <summary>
        /// 2: The connection between the SDK and the Agora edge server is interrupted.
        /// </summary>
        ///
        CONNECTION_CHANGED_INTERRUPTED = 2,

        ///
        /// <summary>
        /// 3: The connection between the SDK and the Agora edge server is banned by the Agora edge server. This error occurs when the user is kicked out of the channel by the server.
        /// </summary>
        ///
        CONNECTION_CHANGED_BANNED_BY_SERVER = 3,

        ///
        /// <summary>
        /// 4: The SDK fails to join the channel. When the SDK fails to join the channel for more than 20 minutes, this error occurs and the SDK stops reconnecting to the channel.
        /// </summary>
        ///
        CONNECTION_CHANGED_JOIN_FAILED = 4,

        ///
        /// <summary>
        /// 5: The SDK has left the channel.
        /// </summary>
        ///
        CONNECTION_CHANGED_LEAVE_CHANNEL = 5,

        ///
        /// <summary>
        /// 6: The connection failed because the App ID is not valid. Please rejoin the channel with a valid App ID.
        /// </summary>
        ///
        CONNECTION_CHANGED_INVALID_APP_ID = 6,

        ///
        /// <summary>
        /// 7: The connection failed since channel name is not valid. Rejoin the channel with a valid channel name.
        /// </summary>
        ///
        CONNECTION_CHANGED_INVALID_CHANNEL_NAME = 7,

        ///
        /// <summary>
        /// 8: The connection failed because the token is not valid. Possible reasons are as follows:The App Certificate for the project is enabled in Agora Console, but you do not use a token when joining the channel. If you enable the App Certificate, you must use a token to join the channel.The uid specified when calling JoinChannel [2/2] to join the channel is inconsistent with the uid passed in when generating the token.
        /// </summary>
        ///
        CONNECTION_CHANGED_INVALID_TOKEN = 8,

        ///
        /// <summary>
        /// 9: The connection failed since token is expired.
        /// </summary>
        ///
        CONNECTION_CHANGED_TOKEN_EXPIRED = 9,

        ///
        /// <summary>
        /// 10: The connection is rejected by server. Possible reasons are as follows:The user is already in the channel and still calls a method, for example, JoinChannel [2/2], to join the channel. Stop calling this method to clear this error.The user tries to join a channel while a test call is in progress. The user needs to join the channel after the call test ends.
        /// </summary>
        ///
        CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,

        ///
        /// <summary>
        /// 11: The connection state changed to reconnecting because the SDK has set a proxy server.
        /// </summary>
        ///
        CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,

        ///
        /// <summary>
        /// 12: The connection state changed because the token is renewed.
        /// </summary>
        ///
        CONNECTION_CHANGED_RENEW_TOKEN = 12,

        ///
        /// <summary>
        /// 13: The IP address of the client has changed, possibly because the network type, IP address, or port has been changed.
        /// </summary>
        ///
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,

        ///
        /// <summary>
        /// 14: Timeout for the keep-alive of the connection between the SDK and the Agora edge server. The connection state changes to .
        /// </summary>
        ///
        CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,

        ///
        /// <summary>
        /// 15: The user has rejoined the channel successfully.
        /// </summary>
        ///
        CONNECTION_CHANGED_REJOIN_SUCCESS = 15,

        ///
        /// <summary>
        /// 16: The connection between the SDK and the server is lost.
        /// </summary>
        ///
        CONNECTION_CHANGED_LOST = 16,

        ///
        /// <summary>
        /// 17: The connection state changes due to the echo test.
        /// </summary>
        ///
        CONNECTION_CHANGED_ECHO_TEST = 17,

        ///
        /// <summary>
        /// 18: The local IP address was changed by the user.
        /// </summary>
        ///
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED_BY_USER = 18,

        ///
        /// <summary>
        /// 19: The user joined the same channel from different devices with the same UID.
        /// </summary>
        ///
        CONNECTION_CHANGED_SAME_UID_LOGIN = 19,

        ///
        /// <summary>
        /// 20: The number of hosts in the channel has reached the upper limit.
        /// </summary>
        ///
        CONNECTION_CHANGED_TOO_MANY_BROADCASTERS = 20,

        ///
        /// @ignore
        ///
        CONNECTION_CHANGED_LICENSE_VALIDATION_FAILURE = 21
    };

    ///
    /// <summary>
    /// The reason for a user role switch failure.
    /// </summary>
    ///
    public enum CLIENT_ROLE_CHANGE_FAILED_REASON
    {
        ///
        /// <summary>
        /// 1: The number of hosts in the channel is already at the upper limit.This enumerator is reported only when the support for 128 users is enabled. The maximum number of hosts is based on the actual number of hosts configured when you enable the 128-user feature.
        /// </summary>
        ///
        CLIENT_ROLE_CHANGE_FAILED_TOO_MANY_BROADCASTERS = 1,

        ///
        /// <summary>
        /// 2: The request is rejected by the Agora server. Agora recommends you prompt the user to try to switch their user role again.
        /// </summary>
        ///
        CLIENT_ROLE_CHANGE_FAILED_NOT_AUTHORIZED = 2,

        ///
        /// <summary>
        /// 3: The request is timed out. Agora recommends you prompt the user to check the network connection and try to switch their user role again.
        /// </summary>
        ///
        CLIENT_ROLE_CHANGE_FAILED_REQUEST_TIME_OUT = 3,

        ///
        /// <summary>
        /// 4: The SDK connection fails. You can use reason reported in the OnConnectionStateChanged callback to troubleshoot the failure.
        /// </summary>
        ///
        CLIENT_ROLE_CHANGE_FAILED_CONNECTION_FAILED = 4,
    };

    ///
    /// @ignore
    ///
    public enum WLACC_MESSAGE_REASON
    {
        ///
        /// @ignore
        ///
        WLACC_MESSAGE_REASON_WEAK_SIGNAL = 0,

        ///
        /// @ignore
        ///
        WLACC_MESSAGE_REASON_CHANNEL_CONGESTION = 1,
    };

    ///
    /// @ignore
    ///
    public enum WLACC_SUGGEST_ACTION
    {
        ///
        /// @ignore
        ///
        WLACC_SUGGEST_ACTION_CLOSE_TO_WIFI = 0,

        ///
        /// @ignore
        ///
        WLACC_SUGGEST_ACTION_CONNECT_SSID = 1,

        ///
        /// @ignore
        ///
        WLACC_SUGGEST_ACTION_CHECK_5G = 2,

        ///
        /// @ignore
        ///
        WLACC_SUGGEST_ACTION_MODIFY_SSID = 3,
    };

    ///
    /// @ignore
    ///
    public class WlAccStats
    {
        ///
        /// @ignore
        ///
        public ushort e2eDelayPercent;

        ///
        /// @ignore
        ///
        public ushort frozenRatioPercent;

        ///
        /// @ignore
        ///
        public ushort lossRatePercent;
    };

    ///
    /// <summary>
    /// Network type.
    /// </summary>
    ///
    public enum NETWORK_TYPE
    {
        ///
        /// <summary>
        /// -1: The network type is unknown.
        /// </summary>
        ///
        NETWORK_TYPE_UNKNOWN = -1,

        ///
        /// <summary>
        /// 0: The SDK disconnects from the network.
        /// </summary>
        ///
        NETWORK_TYPE_DISCONNECTED = 0,

        ///
        /// <summary>
        /// 1: The network type is LAN.
        /// </summary>
        ///
        NETWORK_TYPE_LAN = 1,

        ///
        /// <summary>
        /// 2: The network type is Wi-Fi (including hotspots).
        /// </summary>
        ///
        NETWORK_TYPE_WIFI = 2,

        ///
        /// <summary>
        /// 3: The network type is mobile 2G.
        /// </summary>
        ///
        NETWORK_TYPE_MOBILE_2G = 3,

        ///
        /// <summary>
        /// 4: The network type is mobile 3G.
        /// </summary>
        ///
        NETWORK_TYPE_MOBILE_3G = 4,

        ///
        /// <summary>
        /// 5: The network type is mobile 4G.
        /// </summary>
        ///
        NETWORK_TYPE_MOBILE_4G = 5,
    };

    ///
    /// <summary>
    /// Setting mode of the view.
    /// </summary>
    ///
    public enum VIDEO_VIEW_SETUP_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) Replaces a view.
        /// </summary>
        ///
        VIDEO_VIEW_SETUP_REPLACE = 0,

        ///
        /// <summary>
        /// 1: Adds a view.
        /// </summary>
        ///
        VIDEO_VIEW_SETUP_ADD = 1,

        ///
        /// <summary>
        /// 2: Deletes a view.
        /// </summary>
        ///
        VIDEO_VIEW_SETUP_REMOVE = 2,
    };

    ///
    /// <summary>
    /// Attributes of the video canvas object.
    /// </summary>
    ///
    public class VideoCanvas
    {
        public VideoCanvas()
        {
            view = 0;
            uid = 0;
            renderMode = RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;

            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
            setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
            sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            mediaPlayerId = -(int)ERROR_CODE_TYPE.ERR_NOT_READY;
            cropArea = new Rectangle();
            enableAlphaMask = false;

        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt, uint u)
        {
            this.view = v;
            this.renderMode = m;
            this.mirrorMode = mt;
            this.uid = u;
            setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
            sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            mediaPlayerId = -(int)ERROR_CODE_TYPE.ERR_NOT_READY;
            cropArea = new Rectangle();
            enableAlphaMask = false;
        }

        public VideoCanvas(view_t v, RENDER_MODE_TYPE m, VIDEO_MIRROR_MODE_TYPE mt, string u)
        {
            this.view = v;
            this.renderMode = m;
            this.mirrorMode = mt;
            this.uid = 0;
            setupMode = VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
            sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
            mediaPlayerId = -(int)ERROR_CODE_TYPE.ERR_NOT_READY;
            cropArea = new Rectangle();
            enableAlphaMask = false;
        }

        ///
        /// <summary>
        /// Video display window.
        /// </summary>
        ///
        public view_t view;



        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The rendering mode of the video. See RENDER_MODE_TYPE .
        /// </summary>
        ///
        public RENDER_MODE_TYPE renderMode;

        ///
        /// <summary>
        /// The mirror mode of the view. See VIDEO_MIRROR_MODE_TYPE .For the mirror mode of the local video view: If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.For the remote user: The mirror mode is disabled by default.
        /// </summary>
        ///
        public VIDEO_MIRROR_MODE_TYPE mirrorMode;



        ///
        /// <summary>
        /// Setting mode of the view. See VIDEO_VIEW_SETUP_MODE .
        /// </summary>
        ///
        public VIDEO_VIEW_SETUP_MODE setupMode;

        ///
        /// <summary>
        /// The type of the video source. See VIDEO_SOURCE_TYPE .
        /// </summary>
        ///
        public VIDEO_SOURCE_TYPE sourceType;

        ///
        /// <summary>
        /// The ID of the media player. You can get the Device ID by calling GetId .
        /// </summary>
        ///
        public int mediaPlayerId;

        ///
        /// <summary>
        /// (Optional) Display area of the video frame, see Rectangle . width and height represent the video pixel width and height of the area. The default value is null (width or height is 0), which means that the actual resolution of the video frame is displayed.
        /// </summary>
        ///
        public Rectangle cropArea;

        ///
        /// <summary>
        /// (Optional) Whether the receiver enables alpha mask rendering:true: The receiver enables alpha mask rendering.false: (default) The receiver disables alpha mask rendering.Alpha mask rendering can create images with transparent effects and extract portraits from videos. When used in combination with other methods, you can implement effects such as picture-in-picture and watermarking.This property applies to macOS only.The receiver can render alpha channel information only when the sender enables alpha transmission.To enable alpha transmission, .
        /// </summary>
        ///
        public bool enableAlphaMask;
    };

    ///
    /// <summary>
    /// The contrast level.
    /// </summary>
    ///
    public enum LIGHTENING_CONTRAST_LEVEL
    {
        ///
        /// <summary>
        /// 0: Low contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_LOW = 0,

        ///
        /// <summary>
        /// 1: (Default) Normal contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_NORMAL = 1,

        ///
        /// <summary>
        /// 2: High contrast level.
        /// </summary>
        ///
        LIGHTENING_CONTRAST_HIGH = 2
    };

    ///
    /// <summary>
    /// Image enhancement options.
    /// </summary>
    ///
    public class BeautyOptions
    {
        public BeautyOptions()
        {
            lighteningContrastLevel = LIGHTENING_CONTRAST_LEVEL.LIGHTENING_CONTRAST_NORMAL;
            this.lighteningLevel = 0;
            this.smoothnessLevel = 0;
            this.rednessLevel = 0;
            this.sharpnessLevel = 0;
        }

        public BeautyOptions(
            LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel, float lighteningLevel, float smoothnessLevel,
            float rednessLevel, float sharpnessLevel)
        {
            this.lighteningContrastLevel = lighteningContrastLevel;
            this.lighteningLevel = lighteningLevel;
            this.smoothnessLevel = smoothnessLevel;
            this.rednessLevel = rednessLevel;
            this.sharpnessLevel = sharpnessLevel;
        }

        ///
        /// <summary>
        /// The contrast level, used with the lighteningLevel parameter. The larger the value, the greater the contrast between light and dark. See LIGHTENING_CONTRAST_LEVEL .
        /// </summary>
        ///
        public LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel;

        ///
        /// <summary>
        /// The brightening level, in the range [0.0,1.0], where 0.0 means the original brightening. The default value is 0.0. The higher the value, the greater the degree of brightening.
        /// </summary>
        ///
        public float lighteningLevel;

        ///
        /// <summary>
        /// The smoothness level, in the range [0.0,1.0], where 0.0 means the original smoothness. The default value is 0.0. The greater the value, the greater the smoothness level.
        /// </summary>
        ///
        public float smoothnessLevel;

        ///
        /// <summary>
        /// The redness level, in the range [0.0,1.0], where 0.0 means the original redness. The default value is 0.0. The larger the value, the greater the redness level.
        /// </summary>
        ///
        public float rednessLevel;

        ///
        /// <summary>
        /// The sharpness level, in the range [0.0,1.0], where 0.0 means the original sharpness. The default value is 0.0. The larger the value, the greater the sharpness level.
        /// </summary>
        ///
        public float sharpnessLevel;
    };

    ///
    /// <summary>
    /// The low-light enhancement mode.
    /// </summary>
    ///
    public enum LOW_LIGHT_ENHANCE_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) Automatic mode. The SDK automatically enables or disables the low-light enhancement feature according to the ambient light to compensate for the lighting level or prevent overexposure, as necessary.
        /// </summary>
        ///
        LOW_LIGHT_ENHANCE_AUTO = 0,

        ///
        /// <summary>
        /// 1: Manual mode. Users need to enable or disable the low-light enhancement feature manually.
        /// </summary>
        ///
        LOW_LIGHT_ENHANCE_MANUAL = 1
    };

    ///
    /// <summary>
    /// The low-light enhancement level.
    /// </summary>
    ///
    public enum LOW_LIGHT_ENHANCE_LEVEL
    {
        ///
        /// <summary>
        /// 0: (Default) Promotes video quality during low-light enhancement. It processes the brightness, details, and noise of the video image. The performance consumption is moderate, the processing speed is moderate, and the overall video quality is optimal.
        /// </summary>
        ///
        LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY = 0,

        ///
        /// <summary>
        /// 1: Promotes performance during low-light enhancement. It processes the brightness and details of the video image. The processing speed is faster.
        /// </summary>
        ///
        LOW_LIGHT_ENHANCE_LEVEL_FAST = 1
    };

    ///
    /// <summary>
    /// The low-light enhancement options.
    /// </summary>
    ///
    public class LowlightEnhanceOptions
    {
        ///
        /// <summary>
        /// The low-light enhancement mode. See LOW_LIGHT_ENHANCE_MODE .
        /// </summary>
        ///
        public LOW_LIGHT_ENHANCE_MODE mode;

        ///
        /// <summary>
        /// The low-light enhancement level. See LOW_LIGHT_ENHANCE_LEVEL .
        /// </summary>
        ///
        public LOW_LIGHT_ENHANCE_LEVEL level;

        public LowlightEnhanceOptions(LOW_LIGHT_ENHANCE_MODE lowlightMode, LOW_LIGHT_ENHANCE_LEVEL lowlightLevel)
        {
            mode = lowlightMode;
            level = lowlightLevel;
        }

        public LowlightEnhanceOptions()
        {
            mode = LOW_LIGHT_ENHANCE_MODE.LOW_LIGHT_ENHANCE_AUTO;
            level = LOW_LIGHT_ENHANCE_LEVEL.LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY;
        }
    };

    ///
    /// <summary>
    /// Video noise reduction mode.
    /// </summary>
    ///
    public enum VIDEO_DENOISER_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) Automatic mode. The SDK automatically enables or disables the video noise reduction feature according to the ambient light.
        /// </summary>
        ///
        VIDEO_DENOISER_AUTO = 0,

        ///
        /// <summary>
        /// 1: Manual mode. Users need to enable or disable the video noise reduction feature manually.
        /// </summary>
        ///
        VIDEO_DENOISER_MANUAL = 1
    };

    ///
    /// <summary>
    /// The video noise reduction level.
    /// </summary>
    ///
    public enum VIDEO_DENOISER_LEVEL
    {
        ///
        /// <summary>
        /// 0: (Default) Promotes video quality during video noise reduction. balances performance consumption and video noise reduction quality. The performance consumption is moderate, the video noise reduction speed is moderate, and the overall video quality is optimal.
        /// </summary>
        ///
        VIDEO_DENOISER_LEVEL_HIGH_QUALITY = 0,

        ///
        /// <summary>
        /// 1: Promotes reducing performance consumption during video noise reduction. prioritizes reducing performance consumption over video noise reduction quality. The performance consumption is lower, and the video noise reduction speed is faster. To avoid a noticeable shadowing effect (shadows trailing behind moving objects) in the processed video, Agora recommends that you use this settinging when the camera is fixed.
        /// </summary>
        ///
        VIDEO_DENOISER_LEVEL_FAST = 1,

        ///
        /// <summary>
        /// 2: Enhanced video noise reduction. prioritizes video noise reduction quality over reducing performance consumption. The performance consumption is higher, the video noise reduction speed is slower, and the video noise reduction quality is better. If VIDEO_DENOISER_LEVEL_HIGH_QUALITY is not enough for your video noise reduction needs, you can use this enumerator.
        /// </summary>
        ///
        VIDEO_DENOISER_LEVEL_STRENGTH = 2
    };

    ///
    /// <summary>
    /// Video noise reduction options.
    /// </summary>
    ///
    public class VideoDenoiserOptions
    {
        ///
        /// <summary>
        /// Video noise reduction mode.
        /// </summary>
        ///
        public VIDEO_DENOISER_MODE mode;

        ///
        /// <summary>
        /// Video noise reduction level.
        /// </summary>
        ///
        public VIDEO_DENOISER_LEVEL level;

        public VideoDenoiserOptions(VIDEO_DENOISER_MODE denoiserMode, VIDEO_DENOISER_LEVEL denoiserLevel)
        {
            mode = denoiserMode;
            level = denoiserLevel;
        }

        public VideoDenoiserOptions()
        {
            mode = VIDEO_DENOISER_MODE.VIDEO_DENOISER_AUTO;
            level = VIDEO_DENOISER_LEVEL.VIDEO_DENOISER_LEVEL_HIGH_QUALITY;
        }
    };

    ///
    /// <summary>
    /// The color enhancement options.
    /// </summary>
    ///
    public class ColorEnhanceOptions
    {
        ///
        /// <summary>
        /// The level of color enhancement. The value range is [0.0, 1.0]. 0.0 is the default value, which means no color enhancement is applied to the video. The higher the value, the higher the level of color enhancement. The default value is 0.5.
        /// </summary>
        ///
        public float strengthLevel;

        ///
        /// <summary>
        /// The level of skin tone protection. The value range is [0.0, 1.0]. 0.0 means no skin tone protection. The higher the value, the higher the level of skin tone protection. The default value is 1.0.When the level of color enhancement is higher, the portrait skin tone can be significantly distorted, so you need to set the level of skin tone protection.When the level of skin tone protection is higher, the color enhancement effect can be slightly reduced.Therefore, to get the best color enhancement effect, Agora recommends that you adjust strengthLevel and skinProtectLevel to get the most appropriate values.
        /// </summary>
        ///
        public float skinProtectLevel;

        public ColorEnhanceOptions(float stength, float skinProtect)
        {
            strengthLevel = stength;
            skinProtectLevel = skinProtect;
        }

        public ColorEnhanceOptions()
        {
            strengthLevel = 0;
            skinProtectLevel = 1;
        }
    };

    ///
    /// <summary>
    /// The custom background.
    /// </summary>
    ///
    public enum BACKGROUND_SOURCE_TYPE
    {
        ///
        /// <summary>
        /// 0: Process the background as alpha information without replacement, only separating the portrait and the background. After setting this value, you can call StartLocalVideoTranscoder to implement the picture-in-picture effect.
        /// </summary>
        ///
        BACKGROUND_NONE = 0,
        ///
        /// <summary>
        /// 1: (Default) The background image is a solid color.
        /// </summary>
        ///
        BACKGROUND_COLOR = 1,

        ///
        /// <summary>
        /// 2: The background is an image in PNG or JPG format.
        /// </summary>
        ///
        BACKGROUND_IMG = 2,

        ///
        /// <summary>
        /// 3: The background is a blurred version of the original background.
        /// </summary>
        ///
        BACKGROUND_BLUR = 3,

        ///
        /// <summary>
        /// 4: The background is a local video in MP4, AVI, MKV, FLV, or other supported formats.
        /// </summary>
        ///
        BACKGROUND_VIDEO = 4,
    };

    ///
    /// <summary>
    /// The degree of blurring applied to the custom background image.
    /// </summary>
    ///
    public enum BACKGROUND_BLUR_DEGREE
    {
        ///
        /// <summary>
        /// 1: The degree of blurring applied to the custom background image is low. The user can almost see the background clearly.
        /// </summary>
        ///
        BLUR_DEGREE_LOW = 1,

        ///
        /// <summary>
        /// 2: The degree of blurring applied to the custom background image is medium. It is difficult for the user to recognize details in the background.
        /// </summary>
        ///
        BLUR_DEGREE_MEDIUM = 2,

        ///
        /// <summary>
        /// 3: (Default) The degree of blurring applied to the custom background image is high. The user can barely see any distinguishing features in the background.
        /// </summary>
        ///
        BLUR_DEGREE_HIGH = 3,
    };

    ///
    /// <summary>
    /// The custom background.
    /// </summary>
    ///
    public class VirtualBackgroundSource
    {
        public VirtualBackgroundSource()
        {
            background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_COLOR;
            color = 0xffffff;
            source = "";
            blur_degree = BACKGROUND_BLUR_DEGREE.BLUR_DEGREE_HIGH;
        }

        ///
        /// <summary>
        /// The custom background. See BACKGROUND_SOURCE_TYPE .
        /// </summary>
        ///
        public BACKGROUND_SOURCE_TYPE background_source_type;

        ///
        /// <summary>
        /// The type of the custom background image. The color of the custom background image. The format is a hexadecimal integer defined by RGB, without the # sign, such as 0xFFB6C1 for light pink. The default value is 0xFFFFFF, which signifies white. The value range is [0x000000, 0xffffff]. If the value is invalid, the SDK replaces the original background image with a white background image.This parameter takes effect only when the type of the custom background image is BACKGROUND_COLOR.
        /// </summary>
        ///
        public uint color;

        ///
        /// <summary>
        /// The local absolute path of the custom background image. PNG and JPG formats are supported. If the path is invalid, the SDK replaces the original background image with a white background image.This parameter takes effect only when the type of the custom background image is BACKGROUND_IMG.
        /// </summary>
        ///
        public string source;

        ///
        /// <summary>
        /// The degree of blurring applied to the custom background image. See BACKGROUND_BLUR_DEGREE .This parameter takes effect only when the type of the custom background image is BACKGROUND_BLUR.
        /// </summary>
        ///
        public BACKGROUND_BLUR_DEGREE blur_degree;
    };

    ///
    /// <summary>
    /// The type of algorithms to user for background processing.
    /// </summary>
    ///
    public enum SEG_MODEL_TYPE
    {
        ///
        /// <summary>
        /// 1: (Default) Use the algorithm suitable for all scenarios.
        /// </summary>
        ///
        SEG_MODEL_AI = 1,

        ///
        /// <summary>
        /// 2: Use the algorithm designed specifically for scenarios with a green screen background.
        /// </summary>
        ///
        SEG_MODEL_GREEN = 2
    };

    ///
    /// <summary>
    /// Processing properties for background images.
    /// </summary>
    ///
    public class SegmentationProperty
    {
        ///
        /// <summary>
        /// The type of algorithms to user for background processing. See SEG_MODEL_TYPE .
        /// </summary>
        ///
        public SEG_MODEL_TYPE modelType;
        ///
        /// <summary>
        /// The range of accuracy for identifying green colors (different shades of green) in the view. The value range is [0,1], and the default value is 0.5. The larger the value, the wider the range of identifiable shades of green. When the value of this parameter is too large, the edge of the portrait and the green color in the portrait range are also detected. Agora recommends that you dynamically adjust the value of this parameter according to the actual effect.This parameter only takes effect when modelType is set to SEG_MODEL_GREEN.
        /// </summary>
        ///
        public float greenCapacity;

        public SegmentationProperty()
        {
            modelType = SEG_MODEL_TYPE.SEG_MODEL_AI;
            greenCapacity = 0.5f;
        }
    };

    ///
    /// <summary>
    /// The type of the audio track.
    /// </summary>
    ///
    public enum AUDIO_TRACK_TYPE
    {
        ///
        /// @ignore
        ///
        AUDIO_TRACK_INVALID = -1,

        ///
        /// <summary>
        /// 0: Mixable audio tracks. You can publish multiple mixable audio tracks in one channel, and SDK will automatically mix these tracks into one. The latency of mixable audio tracks is higher than that of direct audio tracks.
        /// </summary>
        ///
        AUDIO_TRACK_MIXABLE = 0,

        ///
        /// <summary>
        /// 1: Direct audio tracks. When creating multiple audio tracks of this type, each direct audio track can only be published in one channel and cannot be mixed with others. The latency of direct audio tracks is lower than that of mixable audio tracks.
        /// </summary>
        ///
        AUDIO_TRACK_DIRECT = 1,
    };

    ///
    /// <summary>
    /// The configuration of custom audio tracks.
    /// </summary>
    ///
    public class AudioTrackConfig
    {
        ///
        /// <summary>
        /// Whether to enable the local audio-playback device:true: (Default) Enable the local audio-playback device.false: Do not enable the local audio-playback device.
        /// </summary>
        ///
        public bool enableLocalPlayback;

        public AudioTrackConfig(bool enableLocalPlayback)
        {
            this.enableLocalPlayback = enableLocalPlayback;
        }

        public AudioTrackConfig()
        {
            enableLocalPlayback = true;
        }

    };

    [Flags]
    ///
    /// <summary>
    /// The options for SDK preset voice beautifier effects.
    /// </summary>
    ///
    public enum VOICE_BEAUTIFIER_PRESET
    {
        ///
        /// <summary>
        /// Turn off voice beautifier effects and use the original voice.
        /// </summary>
        ///
        VOICE_BEAUTIFIER_OFF = 0x00000000,

        ///
        /// <summary>
        /// A more magnetic voice.Agora recommends using this enumerator to process a male-sounding voice; otherwise, you may experience vocal distortion.
        /// </summary>
        ///
        CHAT_BEAUTIFIER_MAGNETIC = 0x01010100,

        ///
        /// <summary>
        /// A fresher voice.Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion.
        /// </summary>
        ///
        CHAT_BEAUTIFIER_FRESH = 0x01010200,

        ///
        /// <summary>
        /// A more vital voice.Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion.
        /// </summary>
        ///
        CHAT_BEAUTIFIER_VITALITY = 0x01010300,

        ///
        /// <summary>
        /// Singing beautifier effect.If you call SetVoiceBeautifierPreset (SINGING_BEAUTIFIER), you can beautify a male-sounding voice and add a reverberation effect that sounds like singing in a small room. Agora recommends using this enumerator to process a male-sounding voice; otherwise, you might experience vocal distortion.If you call SetVoiceBeautifierParameters (SINGING_BEAUTIFIER, param1, param2), you can beautify a male or female-sounding voice and add a reverberation effect.
        /// </summary>
        ///
        SINGING_BEAUTIFIER = 0x01020100,

        ///
        /// <summary>
        /// A more vigorous voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_VIGOROUS = 0x01030100,

        ///
        /// <summary>
        /// A deep voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_DEEP = 0x01030200,

        ///
        /// <summary>
        /// A mellower voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_MELLOW = 0x01030300,

        ///
        /// <summary>
        /// Falsetto.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_FALSETTO = 0x01030400,

        ///
        /// <summary>
        /// A fuller voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_FULL = 0x01030500,

        ///
        /// <summary>
        /// A clearer voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_CLEAR = 0x01030600,

        ///
        /// <summary>
        /// A more resounding voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_RESOUNDING = 0x01030700,

        ///
        /// <summary>
        /// A more ringing voice.
        /// </summary>
        ///
        TIMBRE_TRANSFORMATION_RINGING = 0x01030800,

        ///
        /// <summary>
        /// A ultra-high quality voice, which makes the audio clearer and restores more details.To achieve better audio effect quality, Agora recommends that you set the profile of SetAudioProfile [2/2] to AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4) or AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5) and scenario to AUDIO_SCENARIO_GAME_STREAMING(3) before calling SetVoiceBeautifierPreset .If you have an audio capturing device that can already restore audio details to a high degree, Agora recommends that you do not enable ultra-high quality; otherwise, the SDK may over-restore audio details, and you may not hear the anticipated voice effect.
        /// </summary>
        ///
        ULTRA_HIGH_QUALITY_VOICE = 0x01040100
    };

    [Flags]
    ///
    /// <summary>
    /// Preset audio effects.
    /// To get better audio effects, Agora recommends calling SetAudioProfile [1/2] and setting the profile parameter as recommended below before using the preset audio effects.
    /// </summary>
    ///
    public enum AUDIO_EFFECT_PRESET
    {
        ///
        /// <summary>
        /// Turn off voice effects, that is, use the original voice.
        /// </summary>
        ///
        AUDIO_EFFECT_OFF = 0x00000000,

        ///
        /// <summary>
        /// The voice effect typical of a KTV venue.
        /// </summary>
        ///
        ROOM_ACOUSTICS_KTV = 0x02010100,

        ///
        /// <summary>
        /// The voice effect typical of a concert hall.
        /// </summary>
        ///
        ROOM_ACOUSTICS_VOCAL_CONCERT = 0x02010200,

        ///
        /// <summary>
        /// The voice effect typical of a recording studio.
        /// </summary>
        ///
        ROOM_ACOUSTICS_STUDIO = 0x02010300,

        ///
        /// <summary>
        /// The voice effect typical of a vintage phonograph.
        /// </summary>
        ///
        ROOM_ACOUSTICS_PHONOGRAPH = 0x02010400,

        ///
        /// <summary>
        /// The virtual stereo effect, which renders monophonic audio as stereo audio.
        /// </summary>
        ///
        ROOM_ACOUSTICS_VIRTUAL_STEREO = 0x02010500,

        ///
        /// <summary>
        /// A more spatial voice effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_SPACIAL = 0x02010600,

        ///
        /// <summary>
        /// A more ethereal voice effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_ETHEREAL = 0x02010700,

        ///
        /// <summary>
        /// A 3D voice effect that makes the voice appear to be moving around the user. The default cycle period is 10 seconds. After setting this effect, you can call SetAudioEffectParameters to modify the movement period.If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_3D_VOICE = 0x02010800,

        ///
        /// <summary>
        /// Virtual surround sound, that is, the SDK generates a simulated surround sound field on the basis of stereo channels, thereby creating a surround sound effect.If the virtual surround sound is enabled, users need to use stereo audio playback devices to hear the anticipated audio effect.
        /// </summary>
        ///
        ROOM_ACOUSTICS_VIRTUAL_SURROUND_SOUND = 0x02010900,

        ///
        /// <summary>
        /// A middle-aged man's voice.Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_UNCLE = 0x02020100,

        ///
        /// <summary>
        /// An older man's voice.Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_OLDMAN = 0x02020200,

        ///
        /// <summary>
        /// A boy's voice.Agora recommends using this preset to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_BOY = 0x02020300,

        ///
        /// <summary>
        /// A young woman's voice.Agora recommends using this preset to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_SISTER = 0x02020400,

        ///
        /// <summary>
        /// A girl's voice.Agora recommends using this preset to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_GIRL = 0x02020500,

        ///
        /// <summary>
        /// The voice of Pig King, a character in Journey to the West who has a voice like a growling bear.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_PIGKING = 0x02020600,

        ///
        /// <summary>
        /// The Hulk's voice.
        /// </summary>
        ///
        VOICE_CHANGER_EFFECT_HULK = 0x02020700,

        ///
        /// <summary>
        /// The voice effect typical of R&B music.
        /// </summary>
        ///
        STYLE_TRANSFORMATION_RNB = 0x02030100,

        ///
        /// <summary>
        /// The voice effect typical of popular music.
        /// </summary>
        ///
        STYLE_TRANSFORMATION_POPULAR = 0x02030200,

        ///
        /// <summary>
        /// A pitch correction effect that corrects the user's pitch based on the pitch of the natural C major scale. After setting this voice effect, you can call SetAudioEffectParameters to adjust the basic mode of tuning and the pitch of the main tone.
        /// </summary>
        ///
        PITCH_CORRECTION = 0x02040100,
    };

    [Flags]
    ///
    /// <summary>
    /// The options for SDK preset voice conversion effects.
    /// </summary>
    ///
    public enum VOICE_CONVERSION_PRESET
    {
        ///
        /// <summary>
        /// Turn off voice conversion effects and use the original voice.
        /// </summary>
        ///
        VOICE_CONVERSION_OFF = 0x00000000,

        ///
        /// <summary>
        /// A gender-neutral voice. To avoid audio distortion, ensure that you use this enumerator to process a female-sounding voice.
        /// </summary>
        ///
        VOICE_CHANGER_NEUTRAL = 0x03010100,

        ///
        /// <summary>
        /// A sweet voice. To avoid audio distortion, ensure that you use this enumerator to process a female-sounding voice.
        /// </summary>
        ///
        VOICE_CHANGER_SWEET = 0x03010200,

        ///
        /// <summary>
        /// A steady voice. To avoid audio distortion, ensure that you use this enumerator to process a male-sounding voice.
        /// </summary>
        ///
        VOICE_CHANGER_SOLID = 0x03010300,

        ///
        /// <summary>
        /// A deep voice. To avoid audio distortion, ensure that you use this enumerator to process a male-sounding voice.
        /// </summary>
        ///
        VOICE_CHANGER_BASS = 0x03010400,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_CARTOON = 0x03010500,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_CHILDLIKE = 0x03010600,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_PHONE_OPERATOR = 0x03010700,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_MONSTER = 0x03010800,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_TRANSFORMERS = 0x03010900,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_GROOT = 0x03010A00,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_DARTH_VADER = 0x03010B00,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_IRON_LADY = 0x03010C00,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_SHIN_CHAN = 0x03010D00,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_GIRLISH_MAN = 0x03010E00,

        ///
        /// @ignore
        ///
        VOICE_CHANGER_CHIPMUNK = 0x03010F00,
    };

    ///
    /// <summary>
    /// Preset headphone equalizer types.
    /// </summary>
    ///
    public enum HEADPHONE_EQUALIZER_PRESET
    {
        ///
        /// <summary>
        /// The headphone equalizer is disabled, and the original audio is heard.
        /// </summary>
        ///
        HEADPHONE_EQUALIZER_OFF = 0x00000000,

        ///
        /// <summary>
        /// An equalizer is used for headphones.
        /// </summary>
        ///
        HEADPHONE_EQUALIZER_OVEREAR = 0x04000001,

        ///
        /// <summary>
        /// An equalizer is used for in-ear headphones.
        /// </summary>
        ///
        HEADPHONE_EQUALIZER_INEAR = 0x04000002
    };

    ///
    /// <summary>
    /// Screen sharing configurations.
    /// </summary>
    ///
    public class ScreenCaptureParameters
    {
        public ScreenCaptureParameters()
        {
            dimensions = new VideoDimensions(1920, 1080);
            frameRate = 5;
            bitrate = (int)BITRATE.STANDARD_BITRATE;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
        }

        public ScreenCaptureParameters(ref VideoDimensions d, int f, int b)
        {
            dimensions = new VideoDimensions(d.width, d.height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, bool cur, bool fcs)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = cur;
            windowFocus = fcs;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, view_t[] ex, int cnt)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = ex;
            excludeWindowCount = cnt;
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
        }

        public ScreenCaptureParameters(int width, int height, int f, int b, bool cur, bool fcs, view_t[] ex, int cnt)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = f;
            bitrate = b;
            captureMouseCursor = cur;
            windowFocus = fcs;
            excludeWindowList = ex;
            excludeWindowCount = cnt;
            highLightWidth = 0;
            highLightColor = 0;
            enableHighLight = false;
        }

        ///
        /// <summary>
        /// The video encoding resolution of the shared screen stream. See VideoDimensions . The default value is 1920 × 1080, that is, 2,073,600 pixels. Agora uses the value of this parameter to calculate the charges.If the screen dimensions are different from the value of this parameter, Agora applies the following strategies for encoding. Suppose dimensions is set to 1920 × 1080:If the value of the screen dimensions is lower than that of dimensions, for example, 1000 × 1000 pixels, the SDK uses the screen dimensions, that is, 1000 × 1000 pixels, for encoding.If the value of the screen dimensions is higher than that of dimensions, for example, 2000 × 1500, the SDK uses the maximum value under dimensions with the aspect ratio of the screen dimension (4:3) for encoding, that is, 1440 × 1080.
        /// </summary>
        ///
        public VideoDimensions dimensions;

        ///
        /// <summary>
        /// On Windows and macOS, this represents the video encoding frame rate (fps) of the shared screen stream. The frame rate (fps) of the shared region. The default value is 5. Agora does not recommend setting this to a value greater than 15.
        /// </summary>
        ///
        public int frameRate;

        ///
        /// <summary>
        /// The bitrate of the shared region. On Windows and macOS, this represents the video encoding bitrate of the shared screen stream. The bitrate (Kbps) of the shared region. The default value is 0 (the SDK works out a bitrate according to the dimensions of the current screen).
        /// </summary>
        ///
        public int bitrate;

        ///
        /// <summary>
        /// Whether to capture the mouse in screen sharing:true: (Default) Capture the mouse.false: Do not capture the mouse.
        /// </summary>
        ///
        public bool captureMouseCursor;

        ///
        /// <summary>
        /// Whether to bring the window to the front when calling the StartScreenCaptureByWindowId method to share it:true: Bring the window to the front.false: (Default) Do not bring the window to the front.
        /// </summary>
        ///
        public bool windowFocus;

        ///
        /// <summary>
        /// The ID list of the windows to be blocked. When calling StartScreenCaptureByDisplayId to start screen sharing, you can use this parameter to block a specified window. When calling UpdateScreenCaptureParameters to update screen sharing configurations, you can use this parameter to dynamically block a specified window.
        /// </summary>
        ///
        public view_t[] excludeWindowList;

        ///
        /// <summary>
        /// The number of windows to be excluded.On the Windows platform, the maximum value of this parameter is 24; if this value is exceeded, excluding the window fails.
        /// </summary>
        ///
        public int excludeWindowCount;

        ///
        /// <summary>
        /// (For macOS and Windows only) The width (px) of the border. The default value is 5, and the value range is (0, 50].This parameter only takes effect when highLighted is set to true.
        /// </summary>
        ///
        public int highLightWidth;

        ///
        /// <summary>
        /// (For macOS and Windows only)On Windows platforms, the color of the border in ARGB format. The default value is 0xFF8CBF26.On macOS, COLOR_CLASS refers to NSColor.
        /// </summary>
        ///
        public uint highLightColor;

        ///
        /// <summary>
        /// (For macOS and Windows only) Whether to place a border around the shared window or screen:true: Place a border.false: (Default) Do not place a border.When you share a part of a window or screen, the SDK places a border around the entire window or screen if you set this parameter to true.
        /// </summary>
        ///
        public bool enableHighLight;
    };

    ///
    /// <summary>
    /// Recording quality.
    /// </summary>
    ///
    public enum AUDIO_RECORDING_QUALITY_TYPE
    {
        ///
        /// <summary>
        /// 0: Low quality. The sample rate is 32 kHz, and the file size is around 1.2 MB after 10 minutes of recording.
        /// </summary>
        ///
        AUDIO_RECORDING_QUALITY_LOW = 0,

        ///
        /// <summary>
        /// 1: Medium quality. The sample rate is 32 kHz, and the file size is around 2 MB after 10 minutes of recording.
        /// </summary>
        ///
        AUDIO_RECORDING_QUALITY_MEDIUM = 1,

        ///
        /// <summary>
        /// 2: High quality. The sample rate is 32 kHz, and the file size is around 3.75 MB after 10 minutes of recording.
        /// </summary>
        ///
        AUDIO_RECORDING_QUALITY_HIGH = 2,

        ///
        /// <summary>
        /// 3: Ultra high quality. The sample rate is 32 kHz, and the file size is around 7.5 MB after 10 minutes of recording.
        /// </summary>
        ///
        AUDIO_RECORDING_QUALITY_ULTRA_HIGH = 3,
    };

    ///
    /// <summary>
    /// Recording content. Set in StartAudioRecording [3/3] .
    /// </summary>
    ///
    public enum AUDIO_FILE_RECORDING_TYPE
    {
        ///
        /// <summary>
        /// 1: Only records the audio of the local user.
        /// </summary>
        ///
        AUDIO_FILE_RECORDING_MIC = 1,

        ///
        /// <summary>
        /// 2: Only records the audio of all remote users.
        /// </summary>
        ///
        AUDIO_FILE_RECORDING_PLAYBACK = 2,

        ///
        /// <summary>
        /// 3: Records the mixed audio of the local and all remote users.
        /// </summary>
        ///
        AUDIO_FILE_RECORDING_MIXED = 3,
    };

    ///
    /// <summary>
    /// Audio profile.
    /// </summary>
    ///
    public enum AUDIO_ENCODED_FRAME_OBSERVER_POSITION
    {
        ///
        /// <summary>
        /// 1: Only records the audio of the local user.
        /// </summary>
        ///
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_RECORD = 1,

        ///
        /// <summary>
        /// 2: Only records the audio of all remote users.
        /// </summary>
        ///
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK = 2,

        ///
        /// <summary>
        /// 3: Records the mixed audio of the local and all remote users.
        /// </summary>
        ///
        AUDIO_ENCODED_FRAME_OBSERVER_POSITION_MIXED = 3,
    };

    ///
    /// <summary>
    /// Recording configurations.
    /// </summary>
    ///
    public class AudioRecordingConfiguration
    {
        public AudioRecordingConfiguration()
        {
            filePath = "";
            encode = false;
            sampleRate = 32000;
            fileRecordingType = AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIXED;
            quality = AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_LOW;
            recordingChannel = 1;
        }

        public AudioRecordingConfiguration(string file_path, int sample_rate, AUDIO_RECORDING_QUALITY_TYPE quality_type, int channel)
        {
            this.filePath = file_path;
            this.encode = false;
            this.sampleRate = sample_rate;
            this.fileRecordingType = AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIXED;
            this.quality = quality_type;
            recordingChannel = channel;
        }

        public AudioRecordingConfiguration(string file_path, bool enc, int sample_rate,
                                        AUDIO_FILE_RECORDING_TYPE type, AUDIO_RECORDING_QUALITY_TYPE quality_type, int channel)
        {
            this.filePath = file_path;
            this.encode = enc;
            this.sampleRate = sample_rate;
            this.fileRecordingType = type;
            this.quality = quality_type;
            this.recordingChannel = channel;
        }

        ///
        /// <summary>
        /// The absolute path (including the filename extensions) of the recording file. For example: C:\music\audio.mp4.Ensure that the directory for the log files exists and is writable.
        /// </summary>
        ///
        public string filePath;

        ///
        /// <summary>
        /// Whether to encode the audio data:true: Encode audio data in AAC.false: (Default) Do not encode audio data, but save the recorded audio data directly.
        /// </summary>
        ///
        public bool encode;

        ///
        /// <summary>
        /// Recording sample rate (Hz).16000(Default) 320004410048000If you set this parameter to 44100 or 48000, Agora recommends recording WAV files, or AAC files with quality set as AUDIO_RECORDING_QUALITY_MEDIUM or AUDIO_RECORDING_QUALITY_HIGH for better recording quality.
        /// </summary>
        ///
        public int sampleRate;

        ///
        /// <summary>
        /// The recording content. See AUDIO_FILE_RECORDING_TYPE .
        /// </summary>
        ///
        public AUDIO_FILE_RECORDING_TYPE fileRecordingType;

        ///
        /// <summary>
        /// Recording quality. See AUDIO_RECORDING_QUALITY_TYPE .Note: This parameter applies to AAC files only.
        /// </summary>
        ///
        public AUDIO_RECORDING_QUALITY_TYPE quality;

        ///
        /// <summary>
        /// The audio channel of recording: The parameter supports the following values:1: (Default) Mono.2: Stereo.The actual recorded audio channel is related to the audio channel that you capture.If the captured audio is mono and recordingChannel is 2, the recorded audio is the dual-channel data that is copied from mono data, not stereo.If the captured audio is dual channel and recordingChannel is 1, the recorded audio is the mono data that is mixed by dual-channel data.The integration scheme also affects the final recorded audio channel. If you need to record in stereo, contact .
        /// </summary>
        ///
        public int recordingChannel;
    };

    ///
    /// <summary>
    /// Observer settings for the encoded audio.
    /// </summary>
    ///
    public class AudioEncodedFrameObserverConfig
    {
        public AudioEncodedFrameObserverConfig()
        {
            postionType = AUDIO_ENCODED_FRAME_OBSERVER_POSITION.AUDIO_ENCODED_FRAME_OBSERVER_POSITION_PLAYBACK;
            encodingType = AUDIO_ENCODING_TYPE.AUDIO_ENCODING_TYPE_OPUS_48000_MEDIUM;
        }

        public AudioEncodedFrameObserverConfig(AUDIO_ENCODED_FRAME_OBSERVER_POSITION postionType,
                                                AUDIO_ENCODING_TYPE encodingType)
        {
            this.encodingType = encodingType;
            this.postionType = postionType;
        }

        ///
        /// <summary>
        /// Audio profile. See AUDIO_ENCODED_FRAME_OBSERVER_POSITION .
        /// </summary>
        ///
        public AUDIO_ENCODED_FRAME_OBSERVER_POSITION postionType;

        ///
        /// <summary>
        /// Audio encoding type. See AUDIO_ENCODING_TYPE .
        /// </summary>
        ///
        public AUDIO_ENCODING_TYPE encodingType;
    };

    ///
    /// <summary>
    /// The region for connection, which is the region where the server the SDK connects to is located.
    /// </summary>
    ///
    public enum AREA_CODE : uint
    {
        ///
        /// <summary>
        /// Mainland China.
        /// </summary>
        ///
        AREA_CODE_CN = 0x00000001,

        ///
        /// <summary>
        /// North America.
        /// </summary>
        ///
        AREA_CODE_NA = 0x00000002,

        ///
        /// <summary>
        /// Europe.
        /// </summary>
        ///
        AREA_CODE_EU = 0x00000004,

        ///
        /// <summary>
        /// Asia, excluding Mainland China.
        /// </summary>
        ///
        AREA_CODE_AS = 0x00000008,

        ///
        /// <summary>
        /// Japan.
        /// </summary>
        ///
        AREA_CODE_JP = 0x00000010,

        ///
        /// <summary>
        /// India.
        /// </summary>
        ///
        AREA_CODE_IN = 0x00000020,

        ///
        /// <summary>
        /// Global.
        /// </summary>
        ///
        AREA_CODE_GLOB = 0xFFFFFFFF
    };

    ///
    /// @ignore
    ///
    public enum AREA_CODE_EX : uint
    {
        ///
        /// @ignore
        ///
        AREA_CODE_OC = 0x00000040,

        ///
        /// @ignore
        ///
        AREA_CODE_SA = 0x00000080,

        ///
        /// @ignore
        ///
        AREA_CODE_AF = 0x00000100,

        ///
        /// @ignore
        ///
        AREA_CODE_KR = 0x00000200,

        ///
        /// @ignore
        ///
        AREA_CODE_HKMC = 0x00000400,

        ///
        /// @ignore
        ///
        AREA_CODE_US = 0x00000800,

        ///
        /// @ignore
        ///
        AREA_CODE_OVS = 0xFFFFFFFE
    };

    ///
    /// <summary>
    /// The error code of the channel media relay.
    /// </summary>
    ///
    public enum CHANNEL_MEDIA_RELAY_ERROR
    {
        ///
        /// <summary>
        /// 0: No error.
        /// </summary>
        ///
        RELAY_OK = 0,

        ///
        /// <summary>
        /// 1: An error occurs in the server response.
        /// </summary>
        ///
        RELAY_ERROR_SERVER_ERROR_RESPONSE = 1,

        ///
        /// <summary>
        /// 2: No server response.You can call LeaveChannel [1/2] This error can also occur if your project has not enabled co-host token authentication. You can to enable the service for cohosting across channels before starting a channel media relay.
        /// </summary>
        ///
        RELAY_ERROR_SERVER_NO_RESPONSE = 2,

        ///
        /// <summary>
        /// 3: The SDK fails to access the service, probably due to limited resources of the server.
        /// </summary>
        ///
        RELAY_ERROR_NO_RESOURCE_AVAILABLE = 3,

        ///
        /// <summary>
        /// 4: Fails to send the relay request.
        /// </summary>
        ///
        RELAY_ERROR_FAILED_JOIN_SRC = 4,

        ///
        /// <summary>
        /// 5: Fails to accept the relay request.
        /// </summary>
        ///
        RELAY_ERROR_FAILED_JOIN_DEST = 5,

        ///
        /// <summary>
        /// 6: The server fails to receive the media stream.
        /// </summary>
        ///
        RELAY_ERROR_FAILED_PACKET_RECEIVED_FROM_SRC = 6,

        ///
        /// <summary>
        /// 7: The server fails to send the media stream.
        /// </summary>
        ///
        RELAY_ERROR_FAILED_PACKET_SENT_TO_DEST = 7,

        ///
        /// <summary>
        /// 8: The SDK disconnects from the server due to poor network connections. You can call LeaveChannel [1/2]
        /// </summary>
        ///
        RELAY_ERROR_SERVER_CONNECTION_LOST = 8,

        ///
        /// <summary>
        /// 9: An internal error occurs in the server.
        /// </summary>
        ///
        RELAY_ERROR_INTERNAL_ERROR = 9,

        ///
        /// <summary>
        /// 10: The token of the source channel has expired.
        /// </summary>
        ///
        RELAY_ERROR_SRC_TOKEN_EXPIRED = 10,

        ///
        /// <summary>
        /// 11: The token of the destination channel has expired.
        /// </summary>
        ///
        RELAY_ERROR_DEST_TOKEN_EXPIRED = 11,
    };

    ///
    /// <summary>
    /// The event code of channel media relay.
    /// </summary>
    ///
    public enum CHANNEL_MEDIA_RELAY_EVENT
    {
        ///
        /// <summary>
        /// 0: The user disconnects from the server due to a poor network connection.
        /// </summary>
        ///
        RELAY_EVENT_NETWORK_DISCONNECTED = 0,

        ///
        /// <summary>
        /// 1: The user is connected to the server.
        /// </summary>
        ///
        RELAY_EVENT_NETWORK_CONNECTED = 1,

        ///
        /// <summary>
        /// 2: The user joins the source channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_JOINED_SRC_CHANNEL = 2,

        ///
        /// <summary>
        /// 3: The user joins the target channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_JOINED_DEST_CHANNEL = 3,

        ///
        /// <summary>
        /// 4: The SDK starts relaying the media stream to the target channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL = 4,

        ///
        /// <summary>
        /// 5: The server receives the audio stream from the source channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_RECEIVED_VIDEO_FROM_SRC = 5,

        ///
        /// <summary>
        /// 6: The server receives the audio stream from the source channel.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_RECEIVED_AUDIO_FROM_SRC = 6,

        ///
        /// <summary>
        /// 7: The target channel is updated.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL = 7,

        ///
        /// @ignore
        ///
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_REFUSED = 8,

        ///
        /// <summary>
        /// 9: The target channel does not change, which means that the target channel fails to be updated.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_NOT_CHANGE = 9,

        ///
        /// <summary>
        /// 10: The target channel name is NULL.
        /// </summary>
        ///
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_IS_NULL = 10,

        ///
        /// <summary>
        /// 11: The video profile is sent to the server.
        /// </summary>
        ///
        RELAY_EVENT_VIDEO_PROFILE_UPDATE = 11,

        ///
        /// <summary>
        /// 12: The SDK successfully pauses relaying the media stream to target channels.
        /// </summary>
        ///
        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 12,

        ///
        /// <summary>
        /// 13: The SDK fails to pause relaying the media stream to target channels.
        /// </summary>
        ///
        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 13,

        ///
        /// <summary>
        /// 14: The SDK successfully resumes relaying the media stream to target channels.
        /// </summary>
        ///
        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 14,

        ///
        /// <summary>
        /// 15: The SDK fails to resume relaying the media stream to target channels.
        /// </summary>
        ///
        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 15,
    };

    ///
    /// <summary>
    /// The state code of the channel media relay.
    /// </summary>
    ///
    public enum CHANNEL_MEDIA_RELAY_STATE
    {
        ///
        /// <summary>
        /// 0: The initial state. After you successfully stop the channel media relay by calling StopChannelMediaRelay , the OnChannelMediaRelayStateChanged callback returns this state.
        /// </summary>
        ///
        RELAY_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: The SDK tries to relay the media stream to the destination channel.
        /// </summary>
        ///
        RELAY_STATE_CONNECTING = 1,

        ///
        /// <summary>
        /// 2: The SDK successfully relays the media stream to the destination channel.
        /// </summary>
        ///
        RELAY_STATE_RUNNING = 2,

        ///
        /// <summary>
        /// 3: An error occurs. See code in OnChannelMediaRelayStateChanged for the error code.
        /// </summary>
        ///
        RELAY_STATE_FAILURE = 3,
    };

    ///
    /// <summary>
    /// Channel media information.
    /// </summary>
    ///
    public class ChannelMediaInfo
    {
        public ChannelMediaInfo()
        {
        }

        public ChannelMediaInfo(string channelName, string token, uint uid)
        {
            this.channelName = channelName;
            this.token = token;
            this.uid = uid;
        }

        ///
        /// <summary>
        /// The channel name.
        /// </summary>
        ///
        public string channelName;

        ///
        /// <summary>
        /// The token that enables the user to join the channel.
        /// </summary>
        ///
        public string token;

        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint uid;
    };

    ///
    /// <summary>
    /// Configuration of cross channel media relay.
    /// </summary>
    ///
    public class ChannelMediaRelayConfiguration
    {
        public ChannelMediaRelayConfiguration()
        {
            srcInfo = null;
            destInfos = new ChannelMediaInfo[0];
            destCount = 0;
        }

        public ChannelMediaRelayConfiguration(ChannelMediaInfo srcInfo, ChannelMediaInfo[] destInfos, int destCount)
        {
            this.srcInfo = srcInfo;
            this.destInfos = destInfos ?? new ChannelMediaInfo[0];
            this.destCount = destCount;
        }

        ///
        /// <summary>
        /// The information of the source channel. See ChannelMediaInfo . It contains the following members:channelName: The name of the source channel. The default value is NULL, which means the SDK applies the name of the current channel.token: The token for joining the source channel. This token is generated with the channelName and uid you set in srcInfo.If you have not enabled the App Certificate, set this parameter as the default value NULL, which means the SDK applies the App ID.If you have enabled the App Certificate, you must use the token generated with the channelName and uid, and the uid must be set as 0.uid: The unique user ID to identify the relay stream in the source channel. Agora recommends leaving the default value of 0 unchanged.
        /// </summary>
        ///
        public ChannelMediaInfo srcInfo;

        ///
        /// <summary>
        /// The information of the target channel ChannelMediaInfo. It contains the following members:channelName: The name of the target channel.token: The token for joining the target channel. It is generated with the channelName and uid you set in destInfos.If you have not enabled the App Certificate, set this parameter as the default value NULL, which means the SDK applies the App ID.If you have enabled the App Certificate, you must use the token generated with the channelName and uid.If the token of any target channel expires, the whole media relay stops; hence Agora recommends that you specify the same expiration time for the tokens of all the target channels.uid: The unique user ID to identify the relay stream in the target channel. The value ranges from 0 to (2 32-1). To avoid user ID conflicts, this user ID must be different from any other user ID in the target channel. The default value is 0, which means the SDK generates a random user ID.
        /// </summary>
        ///
        public ChannelMediaInfo[] destInfos;

        ///
        /// <summary>
        /// The number of target channels. The default value is 0, and the value range is from 0 to 4. Ensure that the value of this parameter corresponds to the number of ChannelMediaInfo structs you define in destInfo.
        /// </summary>
        ///
        public int destCount;
    };

    ///
    /// <summary>
    /// The uplink network information.
    /// </summary>
    ///
    public class UplinkNetworkInfo
    {
        public UplinkNetworkInfo()
        {
            video_encoder_target_bitrate_bps = 0;
        }

        public UplinkNetworkInfo(int video_encoder_target_bitrate_bps)
        {
            this.video_encoder_target_bitrate_bps = video_encoder_target_bitrate_bps;
        }

        ///
        /// <summary>
        /// The target video encoder bitrate (bps).
        /// </summary>
        ///
        public int video_encoder_target_bitrate_bps;
    };

    ///
    /// @ignore
    ///
    public class PeerDownlinkInfo
    {
        public PeerDownlinkInfo()
        {
            uid = "";
            stream_type = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
            current_downscale_level = REMOTE_VIDEO_DOWNSCALE_LEVEL.REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE;
            expected_bitrate_bps = -1;
        }

        public PeerDownlinkInfo(string uid, VIDEO_STREAM_TYPE stream_type,
                                REMOTE_VIDEO_DOWNSCALE_LEVEL current_downscale_level, int expected_bitrate_bps)
        {
            this.uid = uid;
            this.stream_type = stream_type;
            this.current_downscale_level = current_downscale_level;
            this.expected_bitrate_bps = expected_bitrate_bps;
        }
        ///
        /// @ignore
        ///
        public string uid;

        ///
        /// @ignore
        ///
        public VIDEO_STREAM_TYPE stream_type;

        ///
        /// @ignore
        ///
        public REMOTE_VIDEO_DOWNSCALE_LEVEL current_downscale_level;

        ///
        /// @ignore
        ///
        public int expected_bitrate_bps;
    };

    ///
    /// @ignore
    ///
    public class DownlinkNetworkInfo
    {
        public DownlinkNetworkInfo()
        {
            lastmile_buffer_delay_time_ms = -1;
            bandwidth_estimation_bps = -1;
            total_downscale_level_count = -1;
            peer_downlink_info = null;
            total_received_video_count = -1;
        }

        public DownlinkNetworkInfo(ref DownlinkNetworkInfo info)
        {
            lastmile_buffer_delay_time_ms = info.lastmile_buffer_delay_time_ms;
            bandwidth_estimation_bps = info.bandwidth_estimation_bps;
            total_downscale_level_count = info.total_downscale_level_count;
            peer_downlink_info = null;
            total_received_video_count = info.total_received_video_count;

            if (total_received_video_count <= 0) return;
            peer_downlink_info = new PeerDownlinkInfo[total_received_video_count];
            for (int i = 0; i < total_received_video_count; i++)
            {
                peer_downlink_info[i] = info.peer_downlink_info[i];
            }
        }

        public DownlinkNetworkInfo(int lastmile_buffer_delay_time_ms, int bandwidth_estimation_bps,
                                int total_downscale_level_count, PeerDownlinkInfo[] peer_downlink_info,
                                int total_received_video_count)
        {
            this.lastmile_buffer_delay_time_ms = lastmile_buffer_delay_time_ms;
            this.bandwidth_estimation_bps = bandwidth_estimation_bps;
            this.total_downscale_level_count = total_downscale_level_count;
            this.peer_downlink_info = peer_downlink_info;
            this.total_received_video_count = total_received_video_count;
        }

        ///
        /// @ignore
        ///
        public int lastmile_buffer_delay_time_ms;

        ///
        /// @ignore
        ///
        public int bandwidth_estimation_bps;

        ///
        /// @ignore
        ///
        public int total_downscale_level_count;

        ///
        /// @ignore
        ///
        public PeerDownlinkInfo[] peer_downlink_info;

        ///
        /// @ignore
        ///
        public int total_received_video_count;
    };

    ///
    /// <summary>
    /// The built-in encryption mode.
    /// Agora recommends using AES_128_GCM2 or AES_256_GCM2 encrypted mode. These two modes support the use of salt for higher security.
    /// </summary>
    ///
    public enum ENCRYPTION_MODE
    {
        ///
        /// <summary>
        /// 1: 128-bit AES encryption, XTS mode.
        /// </summary>
        ///
        AES_128_XTS = 1,

        ///
        /// <summary>
        /// 2: 128-bit AES encryption, ECB mode.
        /// </summary>
        ///
        AES_128_ECB = 2,

        ///
        /// <summary>
        /// 3: 256-bit AES encryption, XTS mode.
        /// </summary>
        ///
        AES_256_XTS = 3,

        ///
        /// <summary>
        /// 4: 128-bit SM4 encryption, ECB mode.
        /// </summary>
        ///
        SM4_128_ECB = 4,

        ///
        /// <summary>
        /// 5: 128-bit AES encryption, GCM mode.
        /// </summary>
        ///
        AES_128_GCM = 5,

        ///
        /// <summary>
        /// 6: 256-bit AES encryption, GCM mode.
        /// </summary>
        ///
        AES_256_GCM = 6,

        ///
        /// <summary>
        /// 7: (Default) 128-bit AES encryption, GCM mode. This encryption mode requires the setting of salt (encryptionKdfSalt).
        /// </summary>
        ///
        AES_128_GCM2 = 7,

        ///
        /// <summary>
        /// 8: 256-bit AES encryption, GCM mode. This encryption mode requires the setting of salt (encryptionKdfSalt).
        /// </summary>
        ///
        AES_256_GCM2 = 8,

        ///
        /// <summary>
        /// Enumerator boundary.
        /// </summary>
        ///
        MODE_END = 9,
    };

    ///
    /// <summary>
    /// Built-in encryption configurations.
    /// </summary>
    ///
    public class EncryptionConfig
    {
        public EncryptionConfig()
        {
            encryptionMode = ENCRYPTION_MODE.MODE_END;
            encryptionKey = "";
            encryptionKdfSalt = new byte[32];
        }

        public EncryptionConfig(ENCRYPTION_MODE encryptionMode, string encryptionKey, byte[] encryptionKdfSalt)
        {
            this.encryptionMode = encryptionMode;
            this.encryptionKey = encryptionKey;
            this.encryptionKdfSalt = encryptionKdfSalt;
        }

        public string getEncryptionString()
        {
            switch (encryptionMode)
            {
                case ENCRYPTION_MODE.AES_128_XTS:
                    return "aes-128-xts";
                case ENCRYPTION_MODE.AES_128_ECB:
                    return "aes-128-ecb";
                case ENCRYPTION_MODE.AES_256_XTS:
                    return "aes-256-xts";
                case ENCRYPTION_MODE.SM4_128_ECB:
                    return "sm4-128-ecb";
                case ENCRYPTION_MODE.AES_128_GCM:
                    return "aes-128-gcm";
                case ENCRYPTION_MODE.AES_256_GCM:
                    return "aes-256-gcm";
                case ENCRYPTION_MODE.AES_128_GCM2:
                    return "aes-128-gcm-2";
                case ENCRYPTION_MODE.AES_256_GCM2:
                    return "aes-256-gcm-2";
                default:
                    return "aes-128-gcm-2";
            }
        }

        ///
        /// <summary>
        /// The built-in encryption mode. See ENCRYPTION_MODE . Agora recommends using AES_128_GCM2 or AES_256_GCM2 encrypted mode. These two modes support the use of salt for higher security.
        /// </summary>
        ///
        public ENCRYPTION_MODE encryptionMode;

        ///
        /// <summary>
        /// Encryption key in string type with unlimited length. Agora recommends using a 32-byte key.If you do not set an encryption key or set it as NULL, you cannot use the built-in encryption, and the SDK returns -2.
        /// </summary>
        ///
        public string encryptionKey;

        private byte[] encryptionKdfSalt32 = new byte[32];

        public byte[] encryptionKdfSalt
        {
            set { Buffer.BlockCopy(value, 0, encryptionKdfSalt32, 0, 32); }

            get { return encryptionKdfSalt32; }
        }
    };

    ///
    /// <summary>
    /// Encryption error type.
    /// </summary>
    ///
    public enum ENCRYPTION_ERROR_TYPE
    {
        ///
        /// <summary>
        /// 0: Internal reason.
        /// </summary>
        ///
        ENCRYPTION_ERROR_INTERNAL_FAILURE = 0,

        ///
        /// <summary>
        /// 1: Decryption errors. Ensure that the receiver and the sender use the same encryption mode and key.
        /// </summary>
        ///
        ENCRYPTION_ERROR_DECRYPTION_FAILURE = 1,

        ///
        /// <summary>
        /// 2: Encryption errors.
        /// </summary>
        ///
        ENCRYPTION_ERROR_ENCRYPTION_FAILURE = 2,
    };

    ///
    /// @ignore
    ///
    public enum UPLOAD_ERROR_REASON
    {
        ///
        /// @ignore
        ///
        UPLOAD_SUCCESS = 0,

        ///
        /// @ignore
        ///
        UPLOAD_NET_ERROR = 1,

        ///
        /// @ignore
        ///
        UPLOAD_SERVER_ERROR = 2,
    };

    ///
    /// <summary>
    /// The type of the device permission.
    /// </summary>
    ///
    public enum PERMISSION_TYPE
    {
        ///
        /// <summary>
        /// 0: Permission for the audio capture device.
        /// </summary>
        ///
        RECORD_AUDIO = 0,

        ///
        /// <summary>
        /// 1: Permission for the camera.
        /// </summary>
        ///
        CAMERA = 1,

        ///
        /// <summary>
        /// (For Android only) 2: Permission for screen sharing.
        /// </summary>
        ///
        SCREEN_CAPTURE = 2,
    };

    ///
    /// <summary>
    /// The maximum length of the user account.
    /// </summary>
    ///
    public enum MAX_USER_ACCOUNT_LENGTH_TYPE
    {
        ///
        /// <summary>
        /// The maximum length of the user account is 256 bytes.
        /// </summary>
        ///
        MAX_USER_ACCOUNT_LENGTH = 256
    };

    ///
    /// <summary>
    /// The subscribing state.
    /// </summary>
    ///
    public enum STREAM_SUBSCRIBE_STATE
    {
        ///
        /// <summary>
        /// 0: The initial publishing state after joining the channel.
        /// </summary>
        ///
        SUB_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: Fails to subscribe to the remote stream. Possible reasons:The remote user:Calls MuteLocalAudioStream (true) or MuteLocalVideoStream (true) to stop sending local media stream.Calls DisableAudio or DisableVideo to disable the local audio or video module.Calls EnableLocalAudio (false) or EnableLocalVideo (false) to disable local audio or video capture.The role of the remote user is audience.The local user calls the following methods to stop receiving remote streams:Call MuteRemoteAudioStream (true) or MuteAllRemoteAudioStreams (true) to stop receiving the remote audio stream.Call MuteRemoteVideoStream (true) or MuteAllRemoteVideoStreams (true) to stop receiving the remote video stream.
        /// </summary>
        ///
        SUB_STATE_NO_SUBSCRIBED = 1,

        ///
        /// <summary>
        /// 2: Subscribing.
        /// </summary>
        ///
        SUB_STATE_SUBSCRIBING = 2,

        ///
        /// <summary>
        /// 3: The remote stream is received, and the subscription is successful.
        /// </summary>
        ///
        SUB_STATE_SUBSCRIBED = 3
    };

    ///
    /// <summary>
    /// The publishing state.
    /// </summary>
    ///
    public enum STREAM_PUBLISH_STATE
    {
        ///
        /// <summary>
        /// 0: The initial publishing state after joining the channel.
        /// </summary>
        ///
        PUB_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: Fails to publish the local stream. Possible reasons:The local user calls MuteLocalAudioStream (true) or MuteLocalVideoStream (true) to stop sending local media streams.The local user calls DisableAudio or DisableVideo to disable the local audio or video module.The local user calls EnableLocalAudio (false) or EnableLocalVideo (false) to disable the local audio or video capture.The role of the local user is audience.
        /// </summary>
        ///
        PUB_STATE_NO_PUBLISHED = 1,

        ///
        /// <summary>
        /// 2: Publishing.
        /// </summary>
        ///
        PUB_STATE_PUBLISHING = 2,

        ///
        /// <summary>
        /// 3: Publishes successfully.
        /// </summary>
        ///
        PUB_STATE_PUBLISHED = 3
    };

    ///
    /// <summary>
    /// The configuration of the audio and video call loop test.
    /// </summary>
    ///
    public class EchoTestConfiguration
    {
        ///
        /// <summary>
        /// The view used to render the local user's video. This parameter is only applicable to scenarios testing video devices, that is, when enableVideo is true.
        /// </summary>
        ///
        public view_t view;

        ///
        /// <summary>
        /// Whether to enable the audio device for the loop test:true: (Default) Enable the audio device. To test the audio device, set this parameter as true.false: Disable the audio device.
        /// </summary>
        ///
        public bool enableAudio;

        ///
        /// <summary>
        /// Whether to enable the video device for the loop test:true: (Default) Enable the video device. To test the video device, set this parameter as true.false: Disable the video device.
        /// </summary>
        ///
        public bool enableVideo;

        ///
        /// <summary>
        /// The token used to secure the audio and video call loop test. If you do not enable App Certificate in Agora Console, you do not need to pass a value in this parameter; if you have enabled App Certificate in Agora Console, you must pass a token in this parameter; the uid used when you generate the token must be 0xFFFFFFFF, and the channel name used must be the channel name that identifies each audio and video call loop tested. For server-side token generation, see .
        /// </summary>
        ///
        public string token;

        ///
        /// <summary>
        /// The channel name that identifies each audio and video call loop. To ensure proper loop test functionality, the channel name passed in to identify each loop test cannot be the same when users of the same project (App ID) perform audio and video call loop tests on different devices.
        /// </summary>
        ///
        public string channelId;

        ///
        /// <summary>
        /// The time interval (s) between when you start the call and when the recording plays back. The value range is [2, 10], and the default value is 2.
        /// </summary>
        ///
        public int intervalInSeconds;

        public EchoTestConfiguration(view_t v, bool ea, bool ev, string t, string c, int @is)
        {
            view = v;
            enableAudio = ea;
            enableVideo = ev;
            token = t;
            channelId = c;
            intervalInSeconds = @is;
        }

        public EchoTestConfiguration()
        {
            view = 0;
            enableAudio = true;
            enableVideo = true;
            token = "";
            channelId = "";
            intervalInSeconds = 2;
        }
    };

    ///
    /// <summary>
    /// The information of the user.
    /// </summary>
    ///
    public class UserInfo
    {
        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// User account. The maximum data length is MAX_USER_ACCOUNT_LENGTH_TYPE .
        /// </summary>
        ///
        public string userAccount;

        public UserInfo()
        {
            uid = 0;
            userAccount = "";
        }
    };

    [Flags]
    ///
    /// <summary>
    /// The audio filter of in-ear monitoring.
    /// </summary>
    ///
    public enum EAR_MONITORING_FILTER_TYPE
    {
        ///
        /// <summary>
        /// 1<<0: Do not add an audio filter to the in-ear monitor.
        /// </summary>
        ///
        EAR_MONITORING_FILTER_NONE = (1 << 0),

        ///
        /// <summary>
        /// 1<<1: Add an audio filter to the in-ear monitor. If you implement functions such as voice beautifier and audio effect, users can hear the voice after adding these effects.
        /// </summary>
        ///
        EAR_MONITORING_FILTER_BUILT_IN_AUDIO_FILTERS = (1 << 1),

        ///
        /// <summary>
        /// 1<<2: Enable noise suppression to the in-ear monitor.
        /// </summary>
        ///
        EAR_MONITORING_FILTER_NOISE_SUPPRESSION = (1 << 2)
    };

    ///
    /// @ignore
    ///
    public enum THREAD_PRIORITY_TYPE
    {
        ///
        /// @ignore
        ///
        LOWEST = 0,

        ///
        /// @ignore
        ///
        LOW = 1,

        ///
        /// @ignore
        ///
        NORMAL = 2,

        ///
        /// @ignore
        ///
        HIGH = 3,

        ///
        /// @ignore
        ///
        HIGHEST = 4,

        ///
        /// @ignore
        ///
        CRITICAL = 5,
    };

    ///
    /// <summary>
    /// The video configuration for the shared screen stream.
    /// </summary>
    ///
    public class ScreenVideoParameters
    {
        ///
        /// <summary>
        /// The video encoding dimension. The default value is 1280 × 720.
        /// </summary>
        ///
        public VideoDimensions dimensions;

        ///
        /// <summary>
        /// The video encoding frame rate (fps). The default value is 15.
        /// </summary>
        ///
        public int frameRate;

        ///
        /// <summary>
        /// The video encoding bitrate (Kbps).
        /// </summary>
        ///
        public int bitrate;

        public VIDEO_CONTENT_HINT contentHint = VIDEO_CONTENT_HINT.CONTENT_HINT_MOTION;

        public ScreenVideoParameters()
        {
            dimensions = new VideoDimensions(1280, 720);
            frameRate = 15;
        }
    };

    ///
    /// <summary>
    /// The audio configuration for the shared screen stream.
    /// Only available where captureAudio is true.
    /// </summary>
    ///
    public class ScreenAudioParameters
    {
        ///
        /// <summary>
        /// Audio sample rate (Hz). The default value is 16000.
        /// </summary>
        ///
        public int sampleRate;

        ///
        /// <summary>
        /// The number of audio channels. The default value is 2, which means stereo.
        /// </summary>
        ///
        public int channels;

        ///
        /// <summary>
        /// The volume of the captured system audio. The value range is [0, 100]. The default value is 100.
        /// </summary>
        ///
        public int captureSignalVolume;

        public ScreenAudioParameters()
        {
            sampleRate = 16000;
            channels = 2;
            captureSignalVolume = 100;
        }
    };

    ///
    /// <summary>
    /// Screen sharing configurations.
    /// </summary>
    ///
    public class ScreenCaptureParameters2
    {
        ///
        /// <summary>
        /// Determines whether to capture system audio during screen sharing:true: Capture system audio.false: (Default) Do not capture system audio.Due to system limitations, capturing system audio is only applicable to Android API level 29 and later (that is, Android 10 and later).
        /// </summary>
        ///
        public bool captureAudio;

        ///
        /// <summary>
        /// The audio configuration for the shared screen stream. See ScreenAudioParameters .This parameter only takes effect when captureAudio is true.
        /// </summary>
        ///
        public ScreenAudioParameters audioParams;

        ///
        /// <summary>
        /// Whether to capture the screen when screen sharing:true: (Default) Capture the screen.false: Do not capture the screen.Due to system limitations, the capture screen is only applicable to Android API level 21 and above, that is, Android 5 and above.
        /// </summary>
        ///
        public bool captureVideo;

        ///
        /// <summary>
        /// The video configuration for the shared screen stream. See ScreenVideoParameters .This parameter only takes effect when captureVideo is true.
        /// </summary>
        ///
        public ScreenVideoParameters videoParams;

        public ScreenCaptureParameters2()
        {
            captureAudio = false;
            audioParams = new ScreenAudioParameters();
            captureAudio = true;
            videoParams = new ScreenVideoParameters();
        }
    };

    ///
    /// <summary>
    /// The rendering state of the media frame.`
    /// </summary>
    ///
    public enum MEDIA_TRACE_EVENT
    {
         
        ///
        /// <summary>
        /// 0: The video frame has been rendered.
        /// </summary>
        ///
        MEDIA_TRACE_EVENT_VIDEO_RENDERED = 0,
         
        ///
        /// <summary>
        /// 1: The video frame has been decoded.
        /// </summary>
        ///
        MEDIA_TRACE_EVENT_VIDEO_DECODED = 1,
    };

     
    ///
    /// <summary>
    /// Indicators during video frame rendering progress.
    /// </summary>
    ///
    public class VideoRenderingTracingInfo
    {
         
        ///
        /// <summary>
        /// The time interval from calling the StartMediaRenderingTracing method to SDK triggering the OnVideoRenderingTracingResult callback. The unit is milliseconds. Agora recommends you call StartMediaRenderingTracing before joining a channel.
        /// </summary>
        ///
        public int elapsedTime;
         
        ///
        /// <summary>
        /// The time interval from calling StartMediaRenderingTracing to calling JoinChannel [2/2] . The unit is milliseconds. A negative number means to call JoinChannel [2/2] after calling StartMediaRenderingTracing.
        /// </summary>
        ///
        public int start2JoinChannel;
         
        ///
        /// <summary>
        /// Time interval from calling JoinChannel [2/2] to successfully joining the channel. The unit is milliseconds.
        /// </summary>
        ///
        public int join2JoinSuccess;
         
        ///
        /// <summary>
        /// If the local user calls StartMediaRenderingTracing before successfully joining the channel, this value is the time interval from the local user successfully joining the channel to the remote user joining the channel. The unit is milliseconds.If the local user calls StartMediaRenderingTracing after successfully joining the channel, the value is the time interval from calling StartMediaRenderingTracing to when the remote user joins the channel. The unit is milliseconds.If the local user calls StartMediaRenderingTracing after the remote user joins the channel, the value is 0 and meaningless.In order to reduce the time of rendering the first frame for remote users, Agora recommends that the local user joins the channel when the remote user is in the channel to reduce this value.
        /// </summary>
        ///
        public int joinSuccess2RemoteJoined;
         
        ///
        /// <summary>
        /// If the local user calls StartMediaRenderingTracing before the remote user joins the channel, this value is the time interval from when the remote user joins the channel to when the local user sets the remote view. The unit is milliseconds.If the local user calls StartMediaRenderingTracing after the remote user joins the channel, this value is the time interval from calling StartMediaRenderingTracing to setting the remote view. The unit is milliseconds.If the local user calls StartMediaRenderingTracing after setting the remote view, the value is 0 and has no effect.In order to reduce the time of rendering the first frame for remote users, Agora recommends that the local user sets the remote view before the remote user joins the channel, or sets the remote view immediately after the remote user joins the channel to reduce this value.
        /// </summary>
        ///
        public int remoteJoined2SetView;
         
        ///
        /// <summary>
        /// If the local user calls StartMediaRenderingTracing before the remote user joins the channel, this value is the time interval from the remote user joining the channel to subscribing to the remote video stream. The unit is milliseconds.If the local user calls StartMediaRenderingTracing after the remote user joins the channel, this value is the time interval from calling StartMediaRenderingTracing to subscribing to the remote video stream. The unit is milliseconds.If the local user calls StartMediaRenderingTracing after subscribing to the remote video stream, the value is 0 and has no effect.In order to reduce the time of rendering the first frame for remote users, Agora recommends that after the remote user joins the channel, the local user immediately subscribes to the remote video stream to reduce this value.
        /// </summary>
        ///
        public int remoteJoined2UnmuteVideo;
         
        ///
        /// <summary>
        /// If the local user calls StartMediaRenderingTracing before the remote user joins the channel, this value is the time interval from when the remote user joins the channel to when the local user receives the remote video stream. The unit is milliseconds.If the local user calls StartMediaRenderingTracing after the remote user joins the channel, this value is the time interval from calling StartMediaRenderingTracing to receiving the remote video stream. The unit is milliseconds.If the local user calls StartMediaRenderingTracing after receiving the remote video stream, the value is 0 and has no effect.In order to reduce the time of rendering the first frame for remote users, Agora recommends that the remote user publishes video streams immediately after joining the channel, and the local user immediately subscribes to remote video streams to reduce this value.
        /// </summary>
        ///
        public int remoteJoined2PacketReceived;
    };


    ///
    /// <summary>
    /// The information about the media streams to be recorded.
    /// </summary>
    ///
    public class RecorderStreamInfo
    {
        public RecorderStreamInfo()
        {
            channelId = "";
            uid = 0;
        }

        public RecorderStreamInfo(string channelId, uint uid)
        {
            this.channelId = channelId;
            this.uid = uid;
        }

         
        ///
        /// <summary>
        /// The name of the channel in which the media streams publish.
        /// </summary>
        ///
        public string channelId;
         
        ///
        /// <summary>
        /// The ID of the user whose media streams you want to record.
        /// </summary>
        ///
        public uint uid;

    };

    ///
    /// <summary>
    /// The spatial audio parameters.
    /// </summary>
    ///
    public class SpatialAudioParams : OptionalJsonParse
    {
        ///
        /// <summary>
        /// The azimuth angle of the remote user or media player relative to the local user. The value range is [0,360], and the unit is degrees, The values are as follows:0: (Default) 0 degrees, which means directly in front on the horizontal plane.90: 90 degrees, which means directly to the left on the horizontal plane.180: 180 degrees, which means directly behind on the horizontal plane.270: 270 degrees, which means directly to the right on the horizontal plane.360: 360 degrees, which means directly in front on the horizontal plane.
        /// </summary>
        ///
        public Optional<double> speaker_azimuth = new Optional<double>();

        ///
        /// <summary>
        /// The elevation angle of the remote user or media player relative to the local user. The value range is [-90,90], and the unit is degrees, The values are as follows:0: (Default) 0 degrees, which means that the horizontal plane is not rotated.-90: -90 degrees, which means that the horizontal plane is rotated 90 degrees downwards.90: 90 degrees, which means that the horizontal plane is rotated 90 degrees upwards.
        /// </summary>
        ///
        public Optional<double> speaker_elevation = new Optional<double>();

        ///
        /// <summary>
        /// The distance of the remote user or media player relative to the local user. The value range is [1,50], and the unit is meters. The default value is 1 meter.
        /// </summary>
        ///
        public Optional<double> speaker_distance = new Optional<double>();

        ///
        /// <summary>
        /// The orientation of the remote user or media player relative to the local user. The value range is [0,180], and the unit is degrees, The values are as follows:0: (Default) 0 degrees, which means that the sound source and listener face the same direction.180: 180 degrees, which means that the sound source and listener face each other.
        /// </summary>
        ///
        public Optional<int> speaker_orientation = new Optional<int>();

        ///
        /// <summary>
        /// Whether to enable audio blurring:true: Enable audio blurring.false: (Default) Disable audio blurring.
        /// </summary>
        ///
        public Optional<bool> enable_blur = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to enable air absorption, that is, to simulate the sound attenuation effect of sound transmitting in the air; under a certain transmission distance, the attenuation speed of high-frequency sound is fast, and the attenuation speed of low-frequency sound is slow.true: (Default) Enable air absorption. Make sure that the value of speaker_attenuation is not 0; otherwise, this setting does not take effect.false: Disable air absorption.
        /// </summary>
        ///
        public Optional<bool> enable_air_absorb = new Optional<bool>();

        ///
        /// <summary>
        /// The sound attenuation coefficient of the remote user or media player. The value range is [0,1]. The values are as follows:0: Broadcast mode, where the volume and timbre are not attenuated with distance, and the volume and timbre heard by local users do not change regardless of distance.(0,0.5): Weak attenuation mode, where the volume and timbre only have a weak attenuation during the propagation, and the sound can travel farther than that in a real environment. enable_air_absorb needs to be enabled at the same time. 0.5: (Default) Simulates the attenuation of the volume in the real environment; the effect is equivalent to not setting the speaker_attenuation parameter.(0.5,1]: Strong attenuation mode, where volume and timbre attenuate rapidly during the propagation. enable_air_absorb needs to be enabled at the same time.
        /// </summary>
        ///
        public Optional<double> speaker_attenuation = new Optional<double>();

        ///
        /// <summary>
        /// Whether to enable the Doppler effect: When there is a relative displacement between the sound source and the receiver of the sound source, the tone heard by the receiver changes.true: Enable the Doppler effect.false: (Default) Disable the Doppler effect.This parameter is suitable for scenarios where the sound source is moving at high speed (for example, racing games). It is not recommended for common audio and video interactive scenarios (for example, voice chat, cohosting, or online KTV).When this parameter is enabled, Agora recommends that you set a regular period (such as 30 ms), and then call the UpdatePlayerPositionInfo , UpdateSelfPosition , and UpdateRemotePosition methods to continuously update the relative distance between the sound source and the receiver. The following factors can cause the Doppler effect to be unpredictable or the sound to be jittery: the period of updating the distance is too long, the updating period is irregular, or the distance information is lost due to network packet loss or delay.
        /// </summary>
        ///
        public Optional<bool> enable_doppler = new Optional<bool>();

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.speaker_azimuth.HasValue())
            {
                writer.WritePropertyName("speaker_azimuth");
                writer.Write(this.speaker_azimuth.GetValue());
            }

            if (this.speaker_elevation.HasValue())
            {
                writer.WritePropertyName("speaker_elevation");
                writer.Write(this.speaker_elevation.GetValue());
            }

            if (this.speaker_distance.HasValue())
            {
                writer.WritePropertyName("speaker_distance");
                writer.Write(this.speaker_distance.GetValue());
            }

            if (this.speaker_orientation.HasValue())
            {
                writer.WritePropertyName("speaker_orientation");
                writer.Write(this.speaker_orientation.GetValue());
            }

            if (this.enable_blur.HasValue())
            {
                writer.WritePropertyName("enable_blur");
                writer.Write(this.enable_blur.GetValue());
            }

            if (this.enable_air_absorb.HasValue())
            {
                writer.WritePropertyName("enable_air_absorb");
                writer.Write(this.enable_air_absorb.GetValue());
            }

            if (this.speaker_attenuation.HasValue())
            {
                writer.WritePropertyName("speaker_attenuation");
                writer.Write(this.speaker_attenuation.GetValue());
            }

            if (this.enable_doppler.HasValue())
            {
                writer.WritePropertyName("enable_doppler");
                writer.Write(this.enable_doppler.GetValue());
            }


            writer.WriteObjectEnd();
        }
    };

    #endregion
}