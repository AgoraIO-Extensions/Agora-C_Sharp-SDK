//
//  Created by Yiqing Huang on 2020/12/15.
//  Copyright © 2020 Agora. All rights reserved.
//

namespace agorartc
{
    /** Warning code.
     */
    public enum WARN_CODE_TYPE
    {
        /** 8: The specified view is invalid. Specify a view when using the video call function.
		 */
        WARN_INVALID_VIEW = 8,

        /** 16: Failed to initialize the video function, possibly caused by a lack of resources. The users cannot see the video while the voice communication is not affected.
		 */
        WARN_INIT_VIDEO = 16,

        /** 20: The request is pending, usually due to some module not being ready, and the SDK postponed processing the request.
		 */
        WARN_PENDING = 20,

        /** 103: No channel resources are available. Maybe because the server cannot allocate any channel resource.
		 */
        WARN_NO_AVAILABLE_CHANNEL = 103,

        /** 104: A timeout occurs when looking up the channel. When joining a channel, the SDK looks up the specified channel. This warning usually occurs when the network condition is too poor for the SDK to connect to the server.
		 */
        WARN_LOOKUP_CHANNEL_TIMEOUT = 104,

        /** **DEPRECATED** 105: The server rejects the request to look up the channel. The server cannot process this request or the request is illegal.

		 Deprecated as of v2.4.1. Use CONNECTION_CHANGED_REJECTED_BY_SERVER(10) in the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback instead.
		 */
        WARN_LOOKUP_CHANNEL_REJECTED = 105,

        /** 106: A timeout occurs when opening the channel. Once the specific channel is found, the SDK opens the channel. This warning usually occurs when the network condition is too poor for the SDK to connect to the server.
		 */
        WARN_OPEN_CHANNEL_TIMEOUT = 106,

        /** 107: The server rejects the request to open the channel. The server cannot process this request or the request is illegal.
		 */
        WARN_OPEN_CHANNEL_REJECTED = 107,

        // sdk: 100~1000
        /** 111: A timeout occurs when switching to the live video.
		 */
        WARN_SWITCH_LIVE_VIDEO_TIMEOUT = 111,

        /** 118: A timeout occurs when setting the client role in the live interactive streaming profile.
		 */
        WARN_SET_CLIENT_ROLE_TIMEOUT = 118,

        /** 121: The ticket to open the channel is invalid.
		 */
        WARN_OPEN_CHANNEL_INVALID_TICKET = 121,

        /** 122: Try connecting to another server.
		 */
        WARN_OPEN_CHANNEL_TRY_NEXT_VOS = 122,

        /** 131: The channel connection cannot be recovered.
		 */
        WARN_CHANNEL_CONNECTION_UNRECOVERABLE = 131,

        /** 132: The IP address has changed.
		 */
        WARN_CHANNEL_CONNECTION_IP_CHANGED = 132,

        /** 133: The port has changed.
		 */
        WARN_CHANNEL_CONNECTION_PORT_CHANGED = 133,

        /** 134: The socket error occurs, try to rejoin channel.
		 */
        WARN_CHANNEL_SOCKET_ERROR = 134,

        /** 701: An error occurs in opening the audio mixing file.
		 */
        WARN_AUDIO_MIXING_OPEN_ERROR = 701,

        /** 1014: Audio Device Module: A warning occurs in the playback device.
		 */
        WARN_ADM_RUNTIME_PLAYOUT_WARNING = 1014,

        /** 1016: Audio Device Module: a warning occurs in the recording device.
		 */
        WARN_ADM_RUNTIME_RECORDING_WARNING = 1016,

        /** 1019: Audio Device Module: no valid audio data is recorded.
		 */
        WARN_ADM_RECORD_AUDIO_SILENCE = 1019,

        /** 1020: Audio device module: The audio playback frequency is abnormal, which may cause audio freezes. This abnormality is caused by high CPU usage. Agora recommends stopping other apps.
		 */
        WARN_ADM_PLAYOUT_MALFUNCTION = 1020,

        /** 1021: Audio device module: the audio recording frequency is abnormal, which may cause audio freezes. This abnormality is caused by high CPU usage. Agora recommends stopping other apps.
		 */
        WARN_ADM_RECORD_MALFUNCTION = 1021,

        /** 1025: The audio playback or recording is interrupted by system events (such as a phone call).
		 */
        WARN_ADM_CALL_INTERRUPTION = 1025,

        /** 1029: During a call, the audio session category should be set to
		 * AVAudioSessionCategoryPlayAndRecord, and RtcEngine monitors this value.
		 * If the audio session category is set to other values, this warning code
		 * is triggered and RtcEngine will forcefully set it back to
		 * AVAudioSessionCategoryPlayAndRecord.
		 */
        WARN_ADM_IOS_CATEGORY_NOT_PLAYANDRECORD = 1029,

        /** 1031: Audio Device Module: The recorded audio voice is too low.
		 */
        WARN_ADM_RECORD_AUDIO_LOWLEVEL = 1031,

        /** 1032: Audio Device Module: The playback audio voice is too low.
		 */
        WARN_ADM_PLAYOUT_AUDIO_LOWLEVEL = 1032,

        /** 1033: Audio device module: The audio recording device is occupied.
		 */
        WARN_ADM_RECORD_AUDIO_IS_ACTIVE = 1033,

        /** 1040: Audio device module: An exception occurs with the audio drive.
		 * Solutions:
		 * - Disable or re-enable the audio device.
		 * - Re-enable your device.
		 * - Update the sound card drive.
		 */
        WARN_ADM_WINDOWS_NO_DATA_READY_EVENT = 1040,

        /** 1042: Audio device module: The audio recording device is different from the audio playback device,
		 * which may cause echoes problem. Agora recommends using the same audio device to record and playback
		 * audio.
		 */
        WARN_ADM_INCONSISTENT_AUDIO_DEVICE = 1042,

        /** 1051: (Communication profile only) Audio processing module: A howling sound is detected when recording the audio data.
		 */
        WARN_APM_HOWLING = 1051,

        /** 1052: Audio Device Module: The device is in the glitch state.
		 */
        WARN_ADM_GLITCH_STATE = 1052,

        /** 1053: Audio Processing Module: A residual echo is detected, which may be caused by the belated scheduling of system threads or the signal overflow.
		 */
        WARN_APM_RESIDUAL_ECHO = 1053,

        // @cond
        WARN_ADM_WIN_CORE_NO_RECORDING_DEVICE = 1322,

        // @endcond
        /** 1323: Audio device module: No available playback device.
         * Solution: Plug in the audio device.
         */
        WARN_ADM_WIN_CORE_NO_PLAYOUT_DEVICE = 1323,

        /** Audio device module: The capture device is released improperly.
		 * Solutions:
		 * - Disable or re-enable the audio device.
		 * - Re-enable your device.
		 * - Update the sound card drive.
		 */
        WARN_ADM_WIN_CORE_IMPROPER_CAPTURE_RELEASE = 1324,

        /** 1610: The origin resolution of the remote video is beyond the range where the super-resolution algorithm can be applied.
		 */
        WARN_SUPER_RESOLUTION_STREAM_OVER_LIMITATION = 1610,

        /** 1611: Another user is already using the super-resolution algorithm.
		 */
        WARN_SUPER_RESOLUTION_USER_COUNT_OVER_LIMITATION = 1611,

        /** 1612: The device does not support the super-resolution algorithm.
		 */
        WARN_SUPER_RESOLUTION_DEVICE_NOT_SUPPORTED = 1612,

        // @cond
        WARN_RTM_LOGIN_TIMEOUT = 2005,

        WARN_RTM_KEEP_ALIVE_TIMEOUT = 2009
        // @endcond
    };

    /** Error code.
	 */
    public enum ERROR_CODE
    {
        /** 0: No error occurs.
		 */
        ERR_OK = 0,

        //1~1000
        /** 1: A general error occurs (no specified reason).
		 */
        ERR_FAILED = 1,

        /** 2: An invalid parameter is used. For example, the specific channel name includes illegal characters.
		 */
        ERR_INVALID_ARGUMENT = 2,

        /** 3: The SDK module is not ready. Possible solutions:

		 - Check the audio device.
		 - Check the completeness of the application.
		 - Re-initialize the RTC engine.
		 */
        ERR_NOT_READY = 3,

        /** 4: The SDK does not support this function.
		 */
        ERR_NOT_SUPPORTED = 4,

        /** 5: The request is rejected.
		 */
        ERR_REFUSED = 5,

        /** 6: The buffer size is not big enough to store the returned data.
		 */
        ERR_BUFFER_TOO_SMALL = 6,

        /** 7: The SDK is not initialized before calling this method.
		 */
        ERR_NOT_INITIALIZED = 7,

        /** 9: No permission exists. Check if the user has granted access to the audio or video device.
		 */
        ERR_NO_PERMISSION = 9,

        /** 10: An API method timeout occurs. Some API methods require the SDK to return the execution result, and this error occurs if the request takes too long (more than 10 seconds) for the SDK to process.
		 */
        ERR_TIMEDOUT = 10,

        /** 11: The request is canceled. This is for internal SDK use only, and it does not return to the application through any method or callback.
		 */
        ERR_CANCELED = 11,

        /** 12: The method is called too often. This is for internal SDK use only, and it does not return to the application through any method or callback.
		 */
        ERR_TOO_OFTEN = 12,

        /** 13: The SDK fails to bind to the network socket. This is for internal SDK use only, and it does not return to the application through any method or callback.
		 */
        ERR_BIND_SOCKET = 13,

        /** 14: The network is unavailable. This is for internal SDK use only, and it does not return to the application through any method or callback.
		 */
        ERR_NET_DOWN = 14,

        /** 15: No network buffers are available. This is for internal SDK internal use only, and it does not return to the application through any method or callback.
		 */
        ERR_NET_NOBUFS = 15,

        /** 17: The request to join the channel is rejected.
		 *
		 * - This error usually occurs when the user is already in the channel, and still calls the method to join the
		 * channel, for example, \ref agora::rtc::IRtcEngine::joinChannel "joinChannel".
		 * - This error usually occurs when the user tries to join a channel
		 * during \ref agora::rtc::IRtcEngine::startEchoTest "startEchoTest". Once you
		 * call \ref agora::rtc::IRtcEngine::startEchoTest "startEchoTest", you need to
		 * call \ref agora::rtc::IRtcEngine::stopEchoTest "stopEchoTest" before joining a channel.
		 * - The user tries to join the channel with a token that is expired.
		 */
        ERR_JOIN_CHANNEL_REJECTED = 17,

        /** 18: The request to leave the channel is rejected.

		 This error usually occurs:

		 - When the user has left the channel and still calls \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" to leave the channel. In this case, stop calling \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel".
		 - When the user has not joined the channel and still calls \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" to leave the channel. In this case, no extra operation is needed.
		 */
        ERR_LEAVE_CHANNEL_REJECTED = 18,

        /** 19: Resources are occupied and cannot be reused.
		 */
        ERR_ALREADY_IN_USE = 19,

        /** 20: The SDK gives up the request due to too many requests.
		 */
        ERR_ABORTED = 20,

        /** 21: In Windows, specific firewall settings can cause the SDK to fail to initialize and crash.
		 */
        ERR_INIT_NET_ENGINE = 21,

        /** 22: The application uses too much of the system resources and the SDK fails to allocate the resources.
		 */
        ERR_RESOURCE_LIMITED = 22,

        /** 101: The specified App ID is invalid. Please try to rejoin the channel with a valid App ID.
		 */
        ERR_INVALID_APP_ID = 101,

        /** 102: The specified channel name is invalid. Please try to rejoin the channel with a valid channel name.
		 */
        ERR_INVALID_CHANNEL_NAME = 102,

        /** 103: Fails to get server resources in the specified region. Please try to specify another region when calling \ref agora::rtc::IRtcEngine::initialize "initialize".
		 */
        ERR_NO_SERVER_RESOURCES = 103,

        /** **DEPRECATED** 109: Deprecated as of v2.4.1. Use CONNECTION_CHANGED_TOKEN_EXPIRED(9) in the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback instead.

		 The token expired due to one of the following reasons:

		 - Authorized Timestamp expired: The timestamp is represented by the number of seconds elapsed since 1/1/1970. The user can use the Token to access the Agora service within 24 hours after the Token is generated. If the user does not access the Agora service after 24 hours, this Token is no longer valid.
		 - Call Expiration Timestamp expired: The timestamp is the exact time when a user can no longer use the Agora service (for example, when a user is forced to leave an ongoing call). When a value is set for the Call Expiration Timestamp, it does not mean that the token will expire, but that the user will be banned from the channel.
		 */
        ERR_TOKEN_EXPIRED = 109,

        /** **DEPRECATED** 110: Deprecated as of v2.4.1. Use CONNECTION_CHANGED_INVALID_TOKEN(8) in the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback instead.

		 The token is invalid due to one of the following reasons:

		 - The App Certificate for the project is enabled in Console, but the user is still using the App ID. Once the App Certificate is enabled, the user must use a token.
		 - The uid is mandatory, and users must set the same uid as the one set in the \ref agora::rtc::IRtcEngine::joinChannel "joinChannel" method.
		 */
        ERR_INVALID_TOKEN = 110,

        /** 111: The internet connection is interrupted. This applies to the Agora Web SDK only.
		 */
        ERR_CONNECTION_INTERRUPTED = 111, // only used in web sdk

        /** 112: The internet connection is lost. This applies to the Agora Web SDK only.
		 */
        ERR_CONNECTION_LOST = 112, // only used in web sdk

        /** 113: The user is not in the channel when calling the method.
		 */
        ERR_NOT_IN_CHANNEL = 113,

        /** 114: The size of the sent data is over 1024 bytes when the user calls the \ref agora::rtc::IRtcEngine::sendStreamMessage "sendStreamMessage" method.
		 */
        ERR_SIZE_TOO_LARGE = 114,

        /** 115: The bitrate of the sent data exceeds the limit of 6 Kbps when the user calls the \ref agora::rtc::IRtcEngine::sendStreamMessage "sendStreamMessage" method.
		 */
        ERR_BITRATE_LIMIT = 115,

        /** 116: Too many data streams (over 5 streams) are created when the user calls the \ref agora::rtc::IRtcEngine::createDataStream "createDataStream" method.
		 */
        ERR_TOO_MANY_DATA_STREAMS = 116,

        /** 117: The data stream transmission timed out.
		 */
        ERR_STREAM_MESSAGE_TIMEOUT = 117,

        /** 119: Switching roles fail. Please try to rejoin the channel.
		 */
        ERR_SET_CLIENT_ROLE_NOT_AUTHORIZED = 119,

        /** 120: Decryption fails. The user may have used a different encryption password to join the channel. Check your settings or try rejoining the channel.
		 */
        ERR_DECRYPTION_FAILED = 120,

        /** 123: The user is banned by the server. This error occurs when the user is kicked off the channel from the server.
		 */
        ERR_CLIENT_IS_BANNED_BY_SERVER = 123,

        /** 124: Incorrect watermark file parameter.
		 */
        ERR_WATERMARK_PARAM = 124,

        /** 125: Incorrect watermark file path.
		 */
        ERR_WATERMARK_PATH = 125,

        /** 126: Incorrect watermark file format.
		 */
        ERR_WATERMARK_PNG = 126,

        /** 127: Incorrect watermark file information.
		 */
        ERR_WATERMARKR_INFO = 127,

        /** 128: Incorrect watermark file data format.
		 */
        ERR_WATERMARK_ARGB = 128,

        /** 129: An error occurs in reading the watermark file.
		 */
        ERR_WATERMARK_READ = 129,

        /** 130: Encryption is enabled when the user calls the \ref agora::rtc::IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method (CDN live streaming does not support encrypted streams).
	     */
        ERR_ENCRYPTED_STREAM_NOT_ALLOWED_PUBLISH = 130,

        /** 134: The user account is invalid. */
        ERR_INVALID_USER_ACCOUNT = 134,

        /** 151: CDN related errors. Remove the original URL address and add a new one by calling the \ref agora::rtc::IRtcEngine::removePublishStreamUrl "removePublishStreamUrl" and \ref agora::rtc::IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" methods.
		 */
        ERR_PUBLISH_STREAM_CDN_ERROR = 151,

        /** 152: The host publishes more than 10 URLs. Delete the unnecessary URLs before adding new ones.
		 */
        ERR_PUBLISH_STREAM_NUM_REACH_LIMIT = 152,

        /** 153: The host manipulates other hosts' URLs. Check your app logic.
		 */
        ERR_PUBLISH_STREAM_NOT_AUTHORIZED = 153,

        /** 154: An error occurs in Agora's streaming server. Call the addPublishStreamUrl method to publish the streaming again.
		 */
        ERR_PUBLISH_STREAM_INTERNAL_SERVER_ERROR = 154,

        /** 155: The server fails to find the stream.
		 */
        ERR_PUBLISH_STREAM_NOT_FOUND = 155,

        /** 156: The format of the RTMP stream URL is not supported. Check whether the URL format is correct.
		 */
        ERR_PUBLISH_STREAM_FORMAT_NOT_SUPPORTED = 156,

        //signaling: 400~600
        ERR_LOGOUT_OTHER = 400, //
        ERR_LOGOUT_USER = 401, // logout by user
        ERR_LOGOUT_NET = 402, // network failure
        ERR_LOGOUT_KICKED = 403, // login in other device
        ERR_LOGOUT_PACKET = 404, //
        ERR_LOGOUT_TOKEN_EXPIRED = 405, // token expired
        ERR_LOGOUT_OLDVERSION = 406, //
        ERR_LOGOUT_TOKEN_WRONG = 407,
        ERR_LOGOUT_ALREADY_LOGOUT = 408,
        ERR_LOGIN_OTHER = 420,
        ERR_LOGIN_NET = 421,
        ERR_LOGIN_FAILED = 422,
        ERR_LOGIN_CANCELED = 423,
        ERR_LOGIN_TOKEN_EXPIRED = 424,
        ERR_LOGIN_OLD_VERSION = 425,
        ERR_LOGIN_TOKEN_WRONG = 426,
        ERR_LOGIN_TOKEN_KICKED = 427,
        ERR_LOGIN_ALREADY_LOGIN = 428,
        ERR_JOIN_CHANNEL_OTHER = 440,
        ERR_SEND_MESSAGE_OTHER = 440,
        ERR_SEND_MESSAGE_TIMEOUT = 441,
        ERR_QUERY_USERNUM_OTHER = 450,
        ERR_QUERY_USERNUM_TIMEOUT = 451,
        ERR_QUERY_USERNUM_BYUSER = 452,
        ERR_LEAVE_CHANNEL_OTHER = 460,
        ERR_LEAVE_CHANNEL_KICKED = 461,
        ERR_LEAVE_CHANNEL_BYUSER = 462,
        ERR_LEAVE_CHANNEL_LOGOUT = 463,
        ERR_LEAVE_CHANNEL_DISCONNECTED = 464,
        ERR_INVITE_OTHER = 470,
        ERR_INVITE_REINVITE = 471,
        ERR_INVITE_NET = 472,
        ERR_INVITE_PEER_OFFLINE = 473,
        ERR_INVITE_TIMEOUT = 474,
        ERR_INVITE_CANT_RECV = 475,


        //1001~2000
        /** 1001: Fails to load the media engine.
		 */
        ERR_LOAD_MEDIA_ENGINE = 1001,

        /** 1002: Fails to start the call after enabling the media engine.
		 */
        ERR_START_CALL = 1002,

        /** **DEPRECATED** 1003: Fails to start the camera.

		 Deprecated as of v2.4.1. Use LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE(4) in the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback instead.
		 */
        ERR_START_CAMERA = 1003,

        /** 1004: Fails to start the video rendering module.
		 */
        ERR_START_VIDEO_RENDER = 1004,

        /** 1005: A general error occurs in the Audio Device Module (no specified reason). Check if the audio device is used by another application, or try rejoining the channel.
		 */
        ERR_ADM_GENERAL_ERROR = 1005,

        /** 1006: Audio Device Module: An error occurs in using the Java resources.
		 */
        ERR_ADM_JAVA_RESOURCE = 1006,

        /** 1007: Audio Device Module: An error occurs in setting the sampling frequency.
		 */
        ERR_ADM_SAMPLE_RATE = 1007,

        /** 1008: Audio Device Module: An error occurs in initializing the playback device.
		 */
        ERR_ADM_INIT_PLAYOUT = 1008,

        /** 1009: Audio Device Module: An error occurs in starting the playback device.
		 */
        ERR_ADM_START_PLAYOUT = 1009,

        /** 1010: Audio Device Module: An error occurs in stopping the playback device.
		 */
        ERR_ADM_STOP_PLAYOUT = 1010,

        /** 1011: Audio Device Module: An error occurs in initializing the recording device.
		 */
        ERR_ADM_INIT_RECORDING = 1011,

        /** 1012: Audio Device Module: An error occurs in starting the recording device.
		 */
        ERR_ADM_START_RECORDING = 1012,

        /** 1013: Audio Device Module: An error occurs in stopping the recording device.
		 */
        ERR_ADM_STOP_RECORDING = 1013,

        /** 1015: Audio Device Module: A playback error occurs. Check your playback device and try rejoining the channel.
		 */
        ERR_ADM_RUNTIME_PLAYOUT_ERROR = 1015,

        /** 1017: Audio Device Module: A recording error occurs.
		 */
        ERR_ADM_RUNTIME_RECORDING_ERROR = 1017,

        /** 1018: Audio Device Module: Fails to record.
		 */
        ERR_ADM_RECORD_AUDIO_FAILED = 1018,

        /** 1022: Audio Device Module: An error occurs in initializing the
		 * loopback device.
		 */
        ERR_ADM_INIT_LOOPBACK = 1022,

        /** 1023: Audio Device Module: An error occurs in starting the loopback
		 * device.
		 */
        ERR_ADM_START_LOOPBACK = 1023,

        /** 1027: Audio Device Module: No recording permission exists. Check if the
		 *  recording permission is granted.
			 */
        ERR_ADM_NO_PERMISSION = 1027,

        /** 1033: Audio device module: The device is occupied.
		 */
        ERR_ADM_RECORD_AUDIO_IS_ACTIVE = 1033,

        /** 1101: Audio device module: A fatal exception occurs.
		 */
        ERR_ADM_ANDROID_JNI_JAVA_RESOURCE = 1101,

        /** 1108: Audio device module: The recording frequency is lower than 50.
		 * 0 indicates that the recording is not yet started. We recommend
		 * checking your recording permission.
		 */
        ERR_ADM_ANDROID_JNI_NO_RECORD_FREQUENCY = 1108,

        /** 1109: The playback frequency is lower than 50. 0 indicates that the
		 * playback is not yet started. We recommend checking if you have created
		 * too many AudioTrack instances.
		 */
        ERR_ADM_ANDROID_JNI_NO_PLAYBACK_FREQUENCY = 1109,

        /** 1111: Audio device module: AudioRecord fails to start up. A ROM system
		 * error occurs. We recommend the following options to debug:
		 * - Restart your App.
		 * - Restart your cellphone.
		 * - Check your recording permission.
		 */
        ERR_ADM_ANDROID_JNI_JAVA_START_RECORD = 1111,

        /** 1112: Audio device module: AudioTrack fails to start up. A ROM system
		 * error occurs. We recommend the following options to debug:
		 * - Restart your App.
		 * - Restart your cellphone.
		 * - Check your playback permission.
		 */
        ERR_ADM_ANDROID_JNI_JAVA_START_PLAYBACK = 1112,

        /** 1115: Audio device module: AudioRecord returns error. The SDK will
		 * automatically restart AudioRecord. */
        ERR_ADM_ANDROID_JNI_JAVA_RECORD_ERROR = 1115,

        /** **DEPRECATED** */
        ERR_ADM_ANDROID_OPENSL_CREATE_ENGINE = 1151,

        /** **DEPRECATED** */
        ERR_ADM_ANDROID_OPENSL_CREATE_AUDIO_RECORDER = 1153,

        /** **DEPRECATED** */
        ERR_ADM_ANDROID_OPENSL_START_RECORDER_THREAD = 1156,

        /** **DEPRECATED** */
        ERR_ADM_ANDROID_OPENSL_CREATE_AUDIO_PLAYER = 1157,

        /** **DEPRECATED** */
        ERR_ADM_ANDROID_OPENSL_START_PLAYER_THREAD = 1160,

        /** 1201: Audio device module: The current device does not support audio
		 * input, possibly because you have mistakenly configured the audio session
		 *  category, or because some other app is occupying the input device. We
		 * recommend terminating all background apps and re-joining the channel. */
        ERR_ADM_IOS_INPUT_NOT_AVAILABLE = 1201,

        /** 1206: Audio device module: Cannot activate the Audio Session.*/
        ERR_ADM_IOS_ACTIVATE_SESSION_FAIL = 1206,

        /** 1210: Audio device module: Fails to initialize the audio device,
		 * normally because the audio device parameters are wrongly set.*/
        ERR_ADM_IOS_VPIO_INIT_FAIL = 1210,

        /** 1213: Audio device module: Fails to re-initialize the audio device,
		 * normally because the audio device parameters are wrongly set.*/
        ERR_ADM_IOS_VPIO_REINIT_FAIL = 1213,

        /** 1214: Fails to re-start up the Audio Unit, possibly because the audio
		 * session category is not compatible with the settings of the Audio Unit.
			*/
        ERR_ADM_IOS_VPIO_RESTART_FAIL = 1214,

        ERR_ADM_IOS_SET_RENDER_CALLBACK_FAIL = 1219,

        /** **DEPRECATED** */
        ERR_ADM_IOS_SESSION_SAMPLERATR_ZERO = 1221,

        /** 1301: Audio device module: An audio driver abnormality or a
		 * compatibility issue occurs. Solutions: Disable and restart the audio
		 * device, or reboot the system.*/
        ERR_ADM_WIN_CORE_INIT = 1301,

        /** 1303: Audio device module: A recording driver abnormality or a
		 * compatibility issue occurs. Solutions: Disable and restart the audio
		 * device, or reboot the system. */
        ERR_ADM_WIN_CORE_INIT_RECORDING = 1303,

        /** 1306: Audio device module: A playout driver abnormality or a
		 * compatibility issue occurs. Solutions: Disable and restart the audio
		 * device, or reboot the system. */
        ERR_ADM_WIN_CORE_INIT_PLAYOUT = 1306,

        /** 1307: Audio device module: No audio device is available. Solutions:
		 * Plug in a proper audio device. */
        ERR_ADM_WIN_CORE_INIT_PLAYOUT_NULL = 1307,

        /** 1309: Audio device module: An audio driver abnormality or a
		 * compatibility issue occurs. Solutions: Disable and restart the audio
		 * device, or reboot the system. */
        ERR_ADM_WIN_CORE_START_RECORDING = 1309,

        /** 1311: Audio device module: Insufficient system memory or poor device
		 * performance. Solutions: Reboot the system or replace the device.
		 */
        ERR_ADM_WIN_CORE_CREATE_REC_THREAD = 1311,

        /** 1314: Audio device module: An audio driver abnormality occurs.
		 * Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Upgrade your audio card driver.*/
        ERR_ADM_WIN_CORE_CAPTURE_NOT_STARTUP = 1314,

        /** 1319: Audio device module: Insufficient system memory or poor device
		 * performance. Solutions: Reboot the system or replace the device. */
        ERR_ADM_WIN_CORE_CREATE_RENDER_THREAD = 1319,

        /** 1320: Audio device module: An audio driver abnormality occurs.
		 * Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Replace the device. */
        ERR_ADM_WIN_CORE_RENDER_NOT_STARTUP = 1320,

        /** 1322: Audio device module: No audio sampling device is available.
		 * Solutions: Plug in a proper recording device. */
        ERR_ADM_WIN_CORE_NO_RECORDING_DEVICE = 1322,

        /** 1323: Audio device module: No audio playout device is available.
		 * Solutions: Plug in a proper playback device.*/
        ERR_ADM_WIN_CORE_NO_PLAYOUT_DEVICE = 1323,

        /** 1351: Audio device module: An audio driver abnormality or a
		 * compatibility issue occurs. Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Upgrade your audio card driver. */
        ERR_ADM_WIN_WAVE_INIT = 1351,

        /** 1353: Audio device module: An audio driver abnormality occurs.
		 * Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Upgrade your audio card driver. */
        ERR_ADM_WIN_WAVE_INIT_RECORDING = 1353,

        /** 1354: Audio device module: An audio driver abnormality occurs.
		 * Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Upgrade your audio card driver. */
        ERR_ADM_WIN_WAVE_INIT_MICROPHONE = 1354,

        /** 1355: Audio device module: An audio driver abnormality occurs.
		 * Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Upgrade your audio card driver. */
        ERR_ADM_WIN_WAVE_INIT_PLAYOUT = 1355,

        /** 1356: Audio device module: An audio driver abnormality occurs.
		 * Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Upgrade your audio card driver. */
        ERR_ADM_WIN_WAVE_INIT_SPEAKER = 1356,

        /** 1357: Audio device module: An audio driver abnormality occurs.
		 * Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Upgrade your audio card driver. */
        ERR_ADM_WIN_WAVE_START_RECORDING = 1357,

        /** 1358: Audio device module: An audio driver abnormality occurs.
		 * Solutions:
		 * - Disable and then re-enable the audio device.
		 * - Reboot the system.
		 * - Upgrade your audio card driver.*/
        ERR_ADM_WIN_WAVE_START_PLAYOUT = 1358,

        /** 1359: Audio Device Module: No recording device exists.
		 */
        ERR_ADM_NO_RECORDING_DEVICE = 1359,

        /** 1360: Audio Device Module: No playback device exists.
		 */
        ERR_ADM_NO_PLAYOUT_DEVICE = 1360,

        // VDM error code starts from 1500
        /** 1501: Video Device Module: The camera is unauthorized.
		 */
        ERR_VDM_CAMERA_NOT_AUTHORIZED = 1501,

        // VDM error code starts from 1500
        /** **DEPRECATED** 1502: Video Device Module: The camera in use.

		 Deprecated as of v2.4.1. Use LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY(3) in the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback instead.
		 */
        ERR_VDM_WIN_DEVICE_IN_USE = 1502,

        // VCM error code starts from 1600
        /** 1600: Video Device Module: An unknown error occurs.
		 */
        ERR_VCM_UNKNOWN_ERROR = 1600,

        /** 1601: Video Device Module: An error occurs in initializing the video encoder.
		 */
        ERR_VCM_ENCODER_INIT_ERROR = 1601,

        /** 1602: Video Device Module: An error occurs in encoding.
		 */
        ERR_VCM_ENCODER_ENCODE_ERROR = 1602,

        /** 1603: Video Device Module: An error occurs in setting the video encoder.
		 */
        ERR_VCM_ENCODER_SET_ERROR = 1603,
    };

    public enum DEVICE_TYPE
    {
        PLAYBACK_DEVICE = 0,
        RECORDING_DEVICE = 1,
    }

    /** Maximum length of the device ID.
	 */
    public enum MAX_DEVICE_ID_LENGTH_TYPE
    {
        /** The maximum length of the device ID is 512 bytes.
		 */
        MAX_DEVICE_ID_LENGTH = 512
    }

    /** Maximum length of user account.
	 */
    public enum MAX_USER_ACCOUNT_LENGTH_TYPE
    {
        /** The maximum length of user account is 255 bytes.
		 */
        MAX_USER_ACCOUNT_LENGTH = 256
    }

    /** Maximum length of channel ID.
	 */
    public enum MAX_CHANNEL_ID_LENGTH_TYPE
    {
        /** The maximum length of channel id is 64 bytes.
		 */
        MAX_CHANNEL_ID_LENGTH = 65
    }

    /** Formats of the quality report.
	 */
    public enum QUALITY_REPORT_FORMAT_TYPE
    {
        /** 0: The quality report in JSON format,
		 */
        QUALITY_REPORT_JSON = 0,

        /** 1: The quality report in HTML format.
		 */
        QUALITY_REPORT_HTML = 1,
    }

    public enum MEDIA_ENGINE_EVENT_CODE_TYPE
    {
        /** 0: For internal use only.
		 */
        MEDIA_ENGINE_RECORDING_ERROR = 0,

        /** 1: For internal use only.
		 */
        MEDIA_ENGINE_PLAYOUT_ERROR = 1,

        /** 2: For internal use only.
		 */
        MEDIA_ENGINE_RECORDING_WARNING = 2,

        /** 3: For internal use only.
		 */
        MEDIA_ENGINE_PLAYOUT_WARNING = 3,

        /** 10: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_FILE_MIX_FINISH = 10,

        /** 12: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_FAREND_MUSIC_BEGINS = 12,

        /** 13: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_FAREND_MUSIC_ENDS = 13,

        /** 14: For internal use only.
		 */
        MEDIA_ENGINE_LOCAL_AUDIO_RECORD_ENABLED = 14,

        /** 15: For internal use only.
		*/
        MEDIA_ENGINE_LOCAL_AUDIO_RECORD_DISABLED = 15,

        // media engine role changed
        /** 20: For internal use only.
		 */
        MEDIA_ENGINE_ROLE_BROADCASTER_SOLO = 20,

        /** 21: For internal use only.
		 */
        MEDIA_ENGINE_ROLE_BROADCASTER_INTERACTIVE = 21,

        /** 22: For internal use only.
		 */
        MEDIA_ENGINE_ROLE_AUDIENCE = 22,

        /** 23: For internal use only.
		 */
        MEDIA_ENGINE_ROLE_COMM_PEER = 23,

        /** 24: For internal use only.
		 */
        MEDIA_ENGINE_ROLE_GAME_PEER = 24,

        // iOS adm sample rate changed
        /** 110: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_ADM_REQUIRE_RESTART = 110,

        /** 111: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_ADM_SPECIAL_RESTART = 111,

        /** 112: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_ADM_USING_COMM_PARAMS = 112,

        /** 113: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_ADM_USING_NORM_PARAMS = 113,

        // audio mix state
        /** 710: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_EVENT_MIXING_PLAY = 710,

        /** 711: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_EVENT_MIXING_PAUSED = 711,

        /** 712: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_EVENT_MIXING_RESTART = 712,

        /** 713: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_EVENT_MIXING_STOPPED = 713,

        /** 714: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_EVENT_MIXING_ERROR = 714,

        //Mixing error codes
        /** 701: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_ERROR_MIXING_OPEN = 701,

        /** 702: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_ERROR_MIXING_TOO_FREQUENT = 702,

        /** 703: The audio mixing file playback is interrupted. For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_ERROR_MIXING_INTERRUPTED_EOF = 703,

        /** 0: For internal use only.
		 */
        MEDIA_ENGINE_AUDIO_ERROR_MIXING_NO_ERROR = 0,
    }

    /** The states of the local user's audio mixing file.
	 */
    public enum AUDIO_MIXING_STATE_TYPE
    {
        /** 710: The audio mixing file is playing.
		 */
        AUDIO_MIXING_STATE_PLAYING = 710,

        /** 711: The audio mixing file pauses playing.
		 */
        AUDIO_MIXING_STATE_PAUSED = 711,

        /** 713: The audio mixing file stops playing.
		 */
        AUDIO_MIXING_STATE_STOPPED = 713,

        /** 714: An exception occurs when playing the audio mixing file. See #AUDIO_MIXING_ERROR_TYPE.
		 */
        AUDIO_MIXING_STATE_FAILED = 714,
    }

    /** The error codes of the local user's audio mixing file.
	 */
    public enum AUDIO_MIXING_ERROR_TYPE
    {
        /** 701: The SDK cannot open the audio mixing file.
		 */
        AUDIO_MIXING_ERROR_CAN_NOT_OPEN = 701,

        /** 702: The SDK opens the audio mixing file too frequently.
		 */
        AUDIO_MIXING_ERROR_TOO_FREQUENT_CALL = 702,

        /** 703: The audio mixing file playback is interrupted.
		 */
        AUDIO_MIXING_ERROR_INTERRUPTED_EOF = 703,

        /** 0: The SDK can open the audio mixing file.
		 */
        AUDIO_MIXING_ERROR_OK = 0,
    }

    /** Media device states.
	 */
    public enum MEDIA_DEVICE_STATE_TYPE
    {
        /** 1: The device is active.
		 */
        MEDIA_DEVICE_STATE_ACTIVE = 1,

        /** 2: The device is disabled.
		 */
        MEDIA_DEVICE_STATE_DISABLED = 2,

        /** 4: The device is not present.
		 */
        MEDIA_DEVICE_STATE_NOT_PRESENT = 4,

        /** 8: The device is unplugged.
		 */
        MEDIA_DEVICE_STATE_UNPLUGGED = 8
    }

    /** Media device types.
	 */
    public enum MEDIA_DEVICE_TYPE
    {
        /** -1: Unknown device type.
		 */
        UNKNOWN_AUDIO_DEVICE = -1,

        /** 0: Audio playback device.
		 */
        AUDIO_PLAYOUT_DEVICE = 0,

        /** 1: Audio recording device.
		 */
        AUDIO_RECORDING_DEVICE = 1,

        /** 2: Video renderer.
		 */
        VIDEO_RENDER_DEVICE = 2,

        /** 3: Video capturer.
		 */
        VIDEO_CAPTURE_DEVICE = 3,

        /** 4: Application audio playback device.
		 */
        AUDIO_APPLICATION_PLAYOUT_DEVICE = 4,
    }

    /** Local video state types
	 */
    public enum LOCAL_VIDEO_STREAM_STATE
    {
        /** 0: Initial state */
        LOCAL_VIDEO_STREAM_STATE_STOPPED = 0,

        /** 1: The local video capturing device starts successfully.
		 *
		 * The SDK also reports this state when you share a maximized window by calling \ref IRtcEngine::startScreenCaptureByWindowId "startScreenCaptureByWindowId".
		 */
        LOCAL_VIDEO_STREAM_STATE_CAPTURING = 1,

        /** 2: The first video frame is successfully encoded. */
        LOCAL_VIDEO_STREAM_STATE_ENCODING = 2,

        /** 3: The local video fails to start. */
        LOCAL_VIDEO_STREAM_STATE_FAILED = 3
    }

    /** Local video state error codes
	 */
    public enum LOCAL_VIDEO_STREAM_ERROR
    {
        /** 0: The local video is normal. */
        LOCAL_VIDEO_STREAM_ERROR_OK = 0,

        /** 1: No specified reason for the local video failure. */
        LOCAL_VIDEO_STREAM_ERROR_FAILURE = 1,

        /** 2: No permission to use the local video capturing device. */
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        /** 3: The local video capturing device is in use. */
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY = 3,

        /** 4: The local video capture fails. Check whether the capturing device is working properly. */
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE = 4,

        /** 5: The local video encoding fails. */
        LOCAL_VIDEO_STREAM_ERROR_ENCODE_FAILURE = 5,

        /** 11: The shared window is minimized when you call \ref IRtcEngine::startScreenCaptureByWindowId "startScreenCaptureByWindowId" to share a window.
		 */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED = 11,
    }

    /** Local audio state types.
	 */
    public enum LOCAL_AUDIO_STREAM_STATE
    {
        /** 0: The local audio is in the initial state.
		 */
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        /** 1: The recording device starts successfully.
		 */
        LOCAL_AUDIO_STREAM_STATE_RECORDING = 1,

        /** 2: The first audio frame encodes successfully.
		 */
        LOCAL_AUDIO_STREAM_STATE_ENCODING = 2,

        /** 3: The local audio fails to start.
		 */
        LOCAL_AUDIO_STREAM_STATE_FAILED = 3
    }

    /** Local audio state error codes.
	 */
    public enum LOCAL_AUDIO_STREAM_ERROR
    {
        /** 0: The local audio is normal.
		 */
        LOCAL_AUDIO_STREAM_ERROR_OK = 0,

        /** 1: No specified reason for the local audio failure.
		 */
        LOCAL_AUDIO_STREAM_ERROR_FAILURE = 1,

        /** 2: No permission to use the local audio device.
		 */
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_NO_PERMISSION = 2,

        /** 3: The microphone is in use.
		 */
        LOCAL_AUDIO_STREAM_ERROR_DEVICE_BUSY = 3,

        /** 4: The local audio recording fails. Check whether the recording device
		 * is working properly.
		 */
        LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE = 4,

        /** 5: The local audio encoding fails.
		 */
        LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE = 5
    }

    /** Audio recording qualities.
	 */
    public enum AUDIO_RECORDING_QUALITY_TYPE
    {
        /** 0: Low quality. The sample rate is 32 kHz, and the file size is around
		 * 1.2 MB after 10 minutes of recording.
		 */
        AUDIO_RECORDING_QUALITY_LOW = 0,

        /** 1: Medium quality. The sample rate is 32 kHz, and the file size is
		 * around 2 MB after 10 minutes of recording.
		 */
        AUDIO_RECORDING_QUALITY_MEDIUM = 1,

        /** 2: High quality. The sample rate is 32 kHz, and the file size is
		 * around 3.75 MB after 10 minutes of recording.
		 */
        AUDIO_RECORDING_QUALITY_HIGH = 2,
    }

    /** Network quality types. */
    public enum QUALITY_TYPE
    {
        /** 0: The network quality is unknown. */
        QUALITY_UNKNOWN = 0,

        /**  1: The network quality is excellent. */
        QUALITY_EXCELLENT = 1,

        /** 2: The network quality is quite good, but the bitrate may be slightly lower than excellent. */
        QUALITY_GOOD = 2,

        /** 3: Users can feel the communication slightly impaired. */
        QUALITY_POOR = 3,

        /** 4: Users cannot communicate smoothly. */
        QUALITY_BAD = 4,

        /** 5: The network is so bad that users can barely communicate. */
        QUALITY_VBAD = 5,

        /** 6: The network is down and users cannot communicate at all. */
        QUALITY_DOWN = 6,

        /** 7: Users cannot detect the network quality. (Not in use.) */
        QUALITY_UNSUPPORTED = 7,

        /** 8: Detecting the network quality. */
        QUALITY_DETECTING = 8,
    }

    /** Video display modes. */
    public enum RENDER_MODE_TYPE
    {
        /**
		 1: Uniformly scale the video until it fills the visible boundaries (cropped). One dimension of the video may have clipped contents.
		 */
        RENDER_MODE_HIDDEN = 1,

        /**
		 2: Uniformly scale the video until one of its dimension fits the boundary (zoomed to fit). Areas that are not filled due to disparity in the aspect ratio are filled with black.
		 */
        RENDER_MODE_FIT = 2,

        /** **DEPRECATED** 3: This mode is deprecated.
		 */
        RENDER_MODE_ADAPTIVE = 3,

        /**
		 4: The fill mode. In this mode, the SDK stretches or zooms the video to fill the display window.
		 */
        RENDER_MODE_FILL = 4,
    }

    /** Video mirror modes. */
    public enum VIDEO_MIRROR_MODE_TYPE
    {
        /** 0: (Default) The SDK enables the mirror mode.
		 */
        VIDEO_MIRROR_MODE_AUTO = 0, //determined by SDK

        /** 1: Enable mirror mode. */
        VIDEO_MIRROR_MODE_ENABLED = 1, //enabled mirror

        /** 2: Disable mirror mode. */
        VIDEO_MIRROR_MODE_DISABLED = 2, //disable mirror
    }

    /** **DEPRECATED** Video profiles. */
    public enum VIDEO_PROFILE_TYPE
    {
        /** 0: 160 * 120, frame rate 15 fps, bitrate 65 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_120P = 0,

        /** 2: 120 * 120, frame rate 15 fps, bitrate 50 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_120P_3 = 2,

        /** 10: 320*180, frame rate 15 fps, bitrate 140 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_180P = 10,

        /** 12: 180 * 180, frame rate 15 fps, bitrate 100 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_180P_3 = 12,

        /** 13: 240 * 180, frame rate 15 fps, bitrate 120 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_180P_4 = 13,

        /** 20: 320 * 240, frame rate 15 fps, bitrate 200 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_240P = 20,

        /** 22: 240 * 240, frame rate 15 fps, bitrate 140 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_240P_3 = 22,

        /** 23: 424 * 240, frame rate 15 fps, bitrate 220 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_240P_4 = 23,

        /** 30: 640 * 360, frame rate 15 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_360P = 30,

        /** 32: 360 * 360, frame rate 15 fps, bitrate 260 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_360P_3 = 32,

        /** 33: 640 * 360, frame rate 30 fps, bitrate 600 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_360P_4 = 33,

        /** 35: 360 * 360, frame rate 30 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_360P_6 = 35,

        /** 36: 480 * 360, frame rate 15 fps, bitrate 320 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_360P_7 = 36,

        /** 37: 480 * 360, frame rate 30 fps, bitrate 490 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_360P_8 = 37,

        /** 38: 640 * 360, frame rate 15 fps, bitrate 800 Kbps.
		 @note `LIVE_BROADCASTING` profile only.
		 */
        VIDEO_PROFILE_LANDSCAPE_360P_9 = 38,

        /** 39: 640 * 360, frame rate 24 fps, bitrate 800 Kbps.
		 @note `LIVE_BROADCASTING` profile only.
		 */
        VIDEO_PROFILE_LANDSCAPE_360P_10 = 39,

        /** 100: 640 * 360, frame rate 24 fps, bitrate 1000 Kbps.
		 @note `LIVE_BROADCASTING` profile only.
		 */
        VIDEO_PROFILE_LANDSCAPE_360P_11 = 100,

        /** 40: 640 * 480, frame rate 15 fps, bitrate 500 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_480P = 40,

        /** 42: 480 * 480, frame rate 15 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_480P_3 = 42,

        /** 43: 640 * 480, frame rate 30 fps, bitrate 750 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_480P_4 = 43,

        /** 45: 480 * 480, frame rate 30 fps, bitrate 600 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_480P_6 = 45,

        /** 47: 848 * 480, frame rate 15 fps, bitrate 610 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_480P_8 = 47,

        /** 48: 848 * 480, frame rate 30 fps, bitrate 930 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_480P_9 = 48,

        /** 49: 640 * 480, frame rate 10 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_480P_10 = 49,

        /** 50: 1280 * 720, frame rate 15 fps, bitrate 1130 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_720P = 50,

        /** 52: 1280 * 720, frame rate 30 fps, bitrate 1710 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_720P_3 = 52,

        /** 54: 960 * 720, frame rate 15 fps, bitrate 910 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_720P_5 = 54,

        /** 55: 960 * 720, frame rate 30 fps, bitrate 1380 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_720P_6 = 55,

        /** 60: 1920 * 1080, frame rate 15 fps, bitrate 2080 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_1080P = 60,

        /** 62: 1920 * 1080, frame rate 30 fps, bitrate 3150 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_1080P_3 = 62,

        /** 64: 1920 * 1080, frame rate 60 fps, bitrate 4780 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_1080P_5 = 64,

        /** 66: 2560 * 1440, frame rate 30 fps, bitrate 4850 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_1440P = 66,

        /** 67: 2560 * 1440, frame rate 60 fps, bitrate 6500 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_1440P_2 = 67,

        /** 70: 3840 * 2160, frame rate 30 fps, bitrate 6500 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_4K = 70,

        /** 72: 3840 * 2160, frame rate 60 fps, bitrate 6500 Kbps. */
        VIDEO_PROFILE_LANDSCAPE_4K_3 = 72,

        /** 1000: 120 * 160, frame rate 15 fps, bitrate 65 Kbps. */
        VIDEO_PROFILE_PORTRAIT_120P = 1000,

        /** 1002: 120 * 120, frame rate 15 fps, bitrate 50 Kbps. */
        VIDEO_PROFILE_PORTRAIT_120P_3 = 1002,

        /** 1010: 180 * 320, frame rate 15 fps, bitrate 140 Kbps. */
        VIDEO_PROFILE_PORTRAIT_180P = 1010,

        /** 1012: 180 * 180, frame rate 15 fps, bitrate 100 Kbps. */
        VIDEO_PROFILE_PORTRAIT_180P_3 = 1012,

        /** 1013: 180 * 240, frame rate 15 fps, bitrate 120 Kbps. */
        VIDEO_PROFILE_PORTRAIT_180P_4 = 1013,

        /** 1020: 240 * 320, frame rate 15 fps, bitrate 200 Kbps. */
        VIDEO_PROFILE_PORTRAIT_240P = 1020,

        /** 1022: 240 * 240, frame rate 15 fps, bitrate 140 Kbps. */
        VIDEO_PROFILE_PORTRAIT_240P_3 = 1022,

        /** 1023: 240 * 424, frame rate 15 fps, bitrate 220 Kbps. */
        VIDEO_PROFILE_PORTRAIT_240P_4 = 1023,

        /** 1030: 360 * 640, frame rate 15 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_PORTRAIT_360P = 1030,

        /** 1032: 360 * 360, frame rate 15 fps, bitrate 260 Kbps. */
        VIDEO_PROFILE_PORTRAIT_360P_3 = 1032,

        /** 1033: 360 * 640, frame rate 30 fps, bitrate 600 Kbps. */
        VIDEO_PROFILE_PORTRAIT_360P_4 = 1033,

        /** 1035: 360 * 360, frame rate 30 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_PORTRAIT_360P_6 = 1035,

        /** 1036: 360 * 480, frame rate 15 fps, bitrate 320 Kbps. */
        VIDEO_PROFILE_PORTRAIT_360P_7 = 1036,

        /** 1037: 360 * 480, frame rate 30 fps, bitrate 490 Kbps. */
        VIDEO_PROFILE_PORTRAIT_360P_8 = 1037,

        /** 1038: 360 * 640, frame rate 15 fps, bitrate 800 Kbps.
		 @note `LIVE_BROADCASTING` profile only.
		 */
        VIDEO_PROFILE_PORTRAIT_360P_9 = 1038,

        /** 1039: 360 * 640, frame rate 24 fps, bitrate 800 Kbps.
		 @note `LIVE_BROADCASTING` profile only.
		 */
        VIDEO_PROFILE_PORTRAIT_360P_10 = 1039,

        /** 1100: 360 * 640, frame rate 24 fps, bitrate 1000 Kbps.
		 @note `LIVE_BROADCASTING` profile only.
		 */
        VIDEO_PROFILE_PORTRAIT_360P_11 = 1100,

        /** 1040: 480 * 640, frame rate 15 fps, bitrate 500 Kbps. */
        VIDEO_PROFILE_PORTRAIT_480P = 1040,

        /** 1042: 480 * 480, frame rate 15 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_PORTRAIT_480P_3 = 1042,

        /** 1043: 480 * 640, frame rate 30 fps, bitrate 750 Kbps. */
        VIDEO_PROFILE_PORTRAIT_480P_4 = 1043,

        /** 1045: 480 * 480, frame rate 30 fps, bitrate 600 Kbps. */
        VIDEO_PROFILE_PORTRAIT_480P_6 = 1045,

        /** 1047: 480 * 848, frame rate 15 fps, bitrate 610 Kbps. */
        VIDEO_PROFILE_PORTRAIT_480P_8 = 1047,

        /** 1048: 480 * 848, frame rate 30 fps, bitrate 930 Kbps. */
        VIDEO_PROFILE_PORTRAIT_480P_9 = 1048,

        /** 1049: 480 * 640, frame rate 10 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_PORTRAIT_480P_10 = 1049,

        /** 1050: 720 * 1280, frame rate 15 fps, bitrate 1130 Kbps. */
        VIDEO_PROFILE_PORTRAIT_720P = 1050,

        /** 1052: 720 * 1280, frame rate 30 fps, bitrate 1710 Kbps. */
        VIDEO_PROFILE_PORTRAIT_720P_3 = 1052,

        /** 1054: 720 * 960, frame rate 15 fps, bitrate 910 Kbps. */
        VIDEO_PROFILE_PORTRAIT_720P_5 = 1054,

        /** 1055: 720 * 960, frame rate 30 fps, bitrate 1380 Kbps. */
        VIDEO_PROFILE_PORTRAIT_720P_6 = 1055,

        /** 1060: 1080 * 1920, frame rate 15 fps, bitrate 2080 Kbps. */
        VIDEO_PROFILE_PORTRAIT_1080P = 1060,

        /** 1062: 1080 * 1920, frame rate 30 fps, bitrate 3150 Kbps. */
        VIDEO_PROFILE_PORTRAIT_1080P_3 = 1062,

        /** 1064: 1080 * 1920, frame rate 60 fps, bitrate 4780 Kbps. */
        VIDEO_PROFILE_PORTRAIT_1080P_5 = 1064,

        /** 1066: 1440 * 2560, frame rate 30 fps, bitrate 4850 Kbps. */
        VIDEO_PROFILE_PORTRAIT_1440P = 1066,

        /** 1067: 1440 * 2560, frame rate 60 fps, bitrate 6500 Kbps. */
        VIDEO_PROFILE_PORTRAIT_1440P_2 = 1067,

        /** 1070: 2160 * 3840, frame rate 30 fps, bitrate 6500 Kbps. */
        VIDEO_PROFILE_PORTRAIT_4K = 1070,

        /** 1072: 2160 * 3840, frame rate 60 fps, bitrate 6500 Kbps. */
        VIDEO_PROFILE_PORTRAIT_4K_3 = 1072,

        /** Default 640 * 360, frame rate 15 fps, bitrate 400 Kbps. */
        VIDEO_PROFILE_DEFAULT = VIDEO_PROFILE_LANDSCAPE_360P,
    }

    /** Audio profiles.
	 Sets the sample rate, bitrate, encoding mode, and the number of channels:
	 */
    public enum AUDIO_PROFILE_TYPE // sample rate, bit rate, mono/stereo, speech/music codec
    {
        /**
		 0: Default audio profile:
		 - For the interactive streaming profile: A sample rate of 48 KHz, music encoding, mono, and a bitrate of up to 64 Kbps.
		 - For the `COMMUNICATION` profile:
		    - Windows: A sample rate of 16 KHz, music encoding, mono, and a bitrate of up to 16 Kbps.
		    - Android/macOS/iOS: A sample rate of 32 KHz, music encoding, mono, and a bitrate of up to 18 Kbps.
		 */
        AUDIO_PROFILE_DEFAULT = 0, // use default settings

        /**
		 1: A sample rate of 32 KHz, audio encoding, mono, and a bitrate of up to 18 Kbps.
		 */
        AUDIO_PROFILE_SPEECH_STANDARD = 1, // 32Khz, 18Kbps, mono, speech

        /**
		 2: A sample rate of 48 KHz, music encoding, mono, and a bitrate of up to 64 Kbps.
		 */
        AUDIO_PROFILE_MUSIC_STANDARD = 2, // 48Khz, 48Kbps, mono, music

        /**
		 3: A sample rate of 48 KHz, music encoding, stereo, and a bitrate of up to 80 Kbps.
		 */
        AUDIO_PROFILE_MUSIC_STANDARD_STEREO = 3, // 48Khz, 56Kbps, stereo, music

        /**
		 4: A sample rate of 48 KHz, music encoding, mono, and a bitrate of up to 96 Kbps.
		 */
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY = 4, // 48Khz, 128Kbps, mono, music

        /**
		 5: A sample rate of 48 KHz, music encoding, stereo, and a bitrate of up to 128 Kbps.
		 */
        AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO = 5, // 48Khz, 192Kbps, stereo, music

        /**
		 6: A sample rate of 16 KHz, audio encoding, mono, and Acoustic Echo Cancellation (AES) enabled.
		 */
        AUDIO_PROFILE_IOT = 6,
        AUDIO_PROFILE_NUM = 7,
    }

    /** Audio application scenarios.
	 */
    public enum AUDIO_SCENARIO_TYPE // set a suitable scenario for your app type
    {
        /** 0: Default. */
        AUDIO_SCENARIO_DEFAULT = 0,

        /** 1: Entertainment scenario, supporting voice during gameplay. */
        AUDIO_SCENARIO_CHATROOM_ENTERTAINMENT = 1,

        /** 2: Education scenario, prioritizing smoothness and stability. */
        AUDIO_SCENARIO_EDUCATION = 2,

        /** 3: Live gaming scenario, enabling the gaming audio effects in the speaker mode in the interactive live streaming scenario. Choose this scenario for high-fidelity music playback. */
        AUDIO_SCENARIO_GAME_STREAMING = 3,

        /** 4: Showroom scenario, optimizing the audio quality with external professional equipment. */
        AUDIO_SCENARIO_SHOWROOM = 4,

        /** 5: Gaming scenario. */
        AUDIO_SCENARIO_CHATROOM_GAMING = 5,

        /** 6: Applicable to the IoT scenario. */
        AUDIO_SCENARIO_IOT = 6,
        AUDIO_SCENARIO_NUM = 7,
    }

    /** The channel profile.
	 */
    public enum CHANNEL_PROFILE_TYPE
    {
        /** (Default) Communication. This profile applies to scenarios such as an audio call or video call,
		 * where all users can publish and subscribe to streams.
		 */
        CHANNEL_PROFILE_COMMUNICATION = 0,

        /** Live streaming. In this profile, uses have roles, namely, host and audience (default).
		 * A host both publishes and subscribes to streams, while an audience subscribes to streams only.
		 * This profile applies to scenarios such as a chat room or interactive video streaming.
		 */
        CHANNEL_PROFILE_LIVE_BROADCASTING = 1,

        /** 2: Gaming. This profile uses a codec with a lower bitrate and consumes less power. Applies to the gaming scenario, where all game players can talk freely.
		 */
        CHANNEL_PROFILE_GAME = 2,
    }

    /** Client roles in the live interactive streaming. */
    public enum CLIENT_ROLE_TYPE
    {
        /** 1: Host. A host can both send and receive streams. */
        CLIENT_ROLE_BROADCASTER = 1,

        /** 2: Audience, the default role. An audience can only receive streams. */
        CLIENT_ROLE_AUDIENCE = 2,
    }

    /** The latency level of an audience member in a live interactive streaming.
	*
	* @note Takes effect only when the user role is `CLIENT_ROLE_BROADCASTER`.
	 */
    public enum AUDIENCE_LATENCY_LEVEL_TYPE
    {
        /** 1: Low latency. */
        AUDIENCE_LATENCY_LEVEL_LOW_LATENCY = 1,

        /** 2: (Default) Ultra low latency. */
        AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY = 2,
    };

    // @cond
    /** The reason why the super-resolution algorithm is not successfully enabled. */
    public enum SUPER_RESOLUTION_STATE_REASON
    {
        /** 0: The super-resolution algorithm is successfully enabled. */
        SR_STATE_REASON_SUCCESS = 0,

        /** 1: The origin resolution of the remote video is beyond the range where
		* the super-resolution algorithm can be applied.
		 */
        SR_STATE_REASON_STREAM_OVER_LIMITATION = 1,

        /** 2: Another user is already using the super-resolution algorithm.
		 */
        SR_STATE_REASON_USER_COUNT_OVER_LIMITATION = 2,

        /** 3: The device does not support the super-resolution algorithm.
		 */
        SR_STATE_REASON_DEVICE_NOT_SUPPORTED = 3,
    };
    // @endcond

    /** Reasons for a user being offline. */
    public enum USER_OFFLINE_REASON_TYPE
    {
        /** 0: The user quits the call. */
        USER_OFFLINE_QUIT = 0,

        /** 1: The SDK times out and the user drops offline because no data packet is received within a certain period of time. If the user quits the call and the message is not passed to the SDK (due to an unreliable channel), the SDK assumes the user dropped offline. */
        USER_OFFLINE_DROPPED = 1,

        /** 2: (`LIVE_BROADCASTING` only.) The client role switched from the host to the audience. */
        USER_OFFLINE_BECOME_AUDIENCE = 2,
    }

    /**
	 States of the RTMP streaming.
	 */
    public enum RTMP_STREAM_PUBLISH_STATE
    {
        /** The RTMP streaming has not started or has ended. This state is also triggered after you remove an RTMP address from the CDN by calling removePublishStreamUrl.
		 */
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        /** The SDK is connecting to Agora's streaming server and the RTMP server. This state is triggered after you call the \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method.
		 */
        RTMP_STREAM_PUBLISH_STATE_CONNECTING = 1,

        /** The RTMP streaming publishes. The SDK successfully publishes the RTMP streaming and returns this state.
		 */
        RTMP_STREAM_PUBLISH_STATE_RUNNING = 2,

        /** The RTMP streaming is recovering. When exceptions occur to the CDN, or the streaming is interrupted, the SDK tries to resume RTMP streaming and returns this state.

		 - If the SDK successfully resumes the streaming, #RTMP_STREAM_PUBLISH_STATE_RUNNING (2) returns.
		 - If the streaming does not resume within 60 seconds or server errors occur, #RTMP_STREAM_PUBLISH_STATE_FAILURE (4) returns. You can also reconnect to the server by calling the \ref IRtcEngine::removePublishStreamUrl "removePublishStreamUrl" and \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" methods.
		 */
        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        /** The RTMP streaming fails. See the errCode parameter for the detailed error information. You can also call the \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method to publish the RTMP streaming again.
		 */
        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,
    }

    /**
	 Error codes of the RTMP streaming.
	 */
    public enum RTMP_STREAM_PUBLISH_ERROR
    {
        /** The RTMP streaming publishes successfully. */
        RTMP_STREAM_PUBLISH_ERROR_OK = 0,

        /** Invalid argument used. If, for example, you do not call the \ref IRtcEngine::setLiveTranscoding "setLiveTranscoding" method to configure the LiveTranscoding parameters before calling the addPublishStreamUrl method, the SDK returns this error. Check whether you set the parameters in the *setLiveTranscoding* method properly. */
        RTMP_STREAM_PUBLISH_ERROR_INVALID_ARGUMENT = 1,

        /** The RTMP streaming is encrypted and cannot be published. */
        RTMP_STREAM_PUBLISH_ERROR_ENCRYPTED_STREAM_NOT_ALLOWED = 2,

        /** Timeout for the RTMP streaming. Call the \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method to publish the streaming again. */
        RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT = 3,

        /** An error occurs in Agora's streaming server. Call the addPublishStreamUrl method to publish the streaming again. */
        RTMP_STREAM_PUBLISH_ERROR_INTERNAL_SERVER_ERROR = 4,

        /** An error occurs in the RTMP server. */
        RTMP_STREAM_PUBLISH_ERROR_RTMP_SERVER_ERROR = 5,

        /** The RTMP streaming publishes too frequently. */
        RTMP_STREAM_PUBLISH_ERROR_TOO_OFTEN = 6,

        /** The host publishes more than 10 URLs. Delete the unnecessary URLs before adding new ones. */
        RTMP_STREAM_PUBLISH_ERROR_REACH_LIMIT = 7,

        /** The host manipulates other hosts' URLs. Check your app logic. */
        RTMP_STREAM_PUBLISH_ERROR_NOT_AUTHORIZED = 8,

        /** Agora's server fails to find the RTMP streaming. */
        RTMP_STREAM_PUBLISH_ERROR_STREAM_NOT_FOUND = 9,

        /** The format of the RTMP streaming URL is not supported. Check whether the URL format is correct. */
        RTMP_STREAM_PUBLISH_ERROR_FORMAT_NOT_SUPPORTED = 10,
    }

    /** Events during the RTMP streaming. */
    public enum RTMP_STREAMING_EVENT
    {
        /** An error occurs when you add a background image or a watermark image to the RTMP stream.
		 */
        RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE = 1,
    }

    /** States of importing an external video stream in the live interactive streaming. */
    public enum INJECT_STREAM_STATUS
    {
        /** 0: The external video stream imported successfully. */
        INJECT_STREAM_STATUS_START_SUCCESS = 0,

        /** 1: The external video stream already exists. */
        INJECT_STREAM_STATUS_START_ALREADY_EXISTS = 1,

        /** 2: The external video stream to be imported is unauthorized. */
        INJECT_STREAM_STATUS_START_UNAUTHORIZED = 2,

        /** 3: Import external video stream timeout. */
        INJECT_STREAM_STATUS_START_TIMEDOUT = 3,

        /** 4: Import external video stream failed. */
        INJECT_STREAM_STATUS_START_FAILED = 4,

        /** 5: The external video stream stopped importing successfully. */
        INJECT_STREAM_STATUS_STOP_SUCCESS = 5,

        /** 6: No external video stream is found. */
        INJECT_STREAM_STATUS_STOP_NOT_FOUND = 6,

        /** 7: The external video stream to be stopped importing is unauthorized. */
        INJECT_STREAM_STATUS_STOP_UNAUTHORIZED = 7,

        /** 8: Stop importing external video stream timeout. */
        INJECT_STREAM_STATUS_STOP_TIMEDOUT = 8,

        /** 9: Stop importing external video stream failed. */
        INJECT_STREAM_STATUS_STOP_FAILED = 9,

        /** 10: The external video stream is corrupted. */
        INJECT_STREAM_STATUS_BROKEN = 10,
    }

    /** Remote video stream types. */
    public enum REMOTE_VIDEO_STREAM_TYPE
    {
        /** 0: High-stream video. */
        REMOTE_VIDEO_STREAM_HIGH = 0,

        /** 1: Low-stream video. */
        REMOTE_VIDEO_STREAM_LOW = 1,
    }

    /** The use mode of the audio data in the \ref media::IAudioFrameObserver::onRecordAudioFrame "onRecordAudioFrame" or \ref media::IAudioFrameObserver::onPlaybackAudioFrame "onPlaybackAudioFrame" callback.
	 */
    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        /** 0: Read-only mode: Users only read the \ref agora::media::IAudioFrameObserver::AudioFrame "AudioFrame" data without modifying anything. For example, when users acquire the data with the Agora SDK, then push the RTMP streams. */
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        /** 1: Write-only mode: Users replace the \ref agora::media::IAudioFrameObserver::AudioFrame "AudioFrame" data with their own data and pass the data to the SDK for encoding. For example, when users acquire the data. */
        RAW_AUDIO_FRAME_OP_MODE_WRITE_ONLY = 1,

        /** 2: Read and write mode: Users read the data from \ref agora::media::IAudioFrameObserver::AudioFrame "AudioFrame", modify it, and then play it. For example, when users have their own sound-effect processing module and perform some voice pre-processing, such as a voice change. */
        RAW_AUDIO_FRAME_OP_MODE_READ_WRITE = 2,
    }

    /** Audio-sample rates. */
    public enum AUDIO_SAMPLE_RATE_TYPE
    {
        /** 32000: 32 kHz */
        AUDIO_SAMPLE_RATE_32000 = 32000,

        /** 44100: 44.1 kHz */
        AUDIO_SAMPLE_RATE_44100 = 44100,

        /** 48000: 48 kHz */
        AUDIO_SAMPLE_RATE_48000 = 48000,
    }

    /** Video codec profile types. */
    public enum VIDEO_CODEC_PROFILE_TYPE
    {
        //* 66: Baseline video codec profile. Generally used in video calls on mobile phones.
        VIDEO_CODEC_PROFILE_BASELINE = 66,

        /** 77: Main video codec profile. Generally used in mainstream electronics such as MP4 players, portable video players, PSP, and iPads. */
        VIDEO_CODEC_PROFILE_MAIN = 77,

        /** 100: (Default) High video codec profile. Generally used in high-resolution live streaming or television. */
        VIDEO_CODEC_PROFILE_HIGH = 100,
    }

    /** Video codec types */
    public enum VIDEO_CODEC_TYPE
    {
        /** Standard VP8 */
        VIDEO_CODEC_VP8 = 1,

        /** Standard H264 */
        VIDEO_CODEC_H264 = 2,

        /** Enhanced VP8 */
        VIDEO_CODEC_EVP = 3,

        /** Enhanced H264 */
        VIDEO_CODEC_E264 = 4,
    }

    /** Audio equalization band frequencies. */
    public enum AUDIO_EQUALIZATION_BAND_FREQUENCY
    {
        /** 0: 31 Hz */
        AUDIO_EQUALIZATION_BAND_31 = 0,

        /** 1: 62 Hz */
        AUDIO_EQUALIZATION_BAND_62 = 1,

        /** 2: 125 Hz */
        AUDIO_EQUALIZATION_BAND_125 = 2,

        /** 3: 250 Hz */
        AUDIO_EQUALIZATION_BAND_250 = 3,

        /** 4: 500 Hz */
        AUDIO_EQUALIZATION_BAND_500 = 4,

        /** 5: 1 kHz */
        AUDIO_EQUALIZATION_BAND_1K = 5,

        /** 6: 2 kHz */
        AUDIO_EQUALIZATION_BAND_2K = 6,

        /** 7: 4 kHz */
        AUDIO_EQUALIZATION_BAND_4K = 7,

        /** 8: 8 kHz */
        AUDIO_EQUALIZATION_BAND_8K = 8,

        /** 9: 16 kHz */
        AUDIO_EQUALIZATION_BAND_16K = 9,
    }

    /** Audio reverberation types. */
    public enum AUDIO_REVERB_TYPE
    {
        /** 0: The level of the dry signal (db). The value is between -20 and 10. */
        AUDIO_REVERB_DRY_LEVEL = 0, // (dB, [-20,10]), the level of the dry signal

        /** 1: The level of the early reflection signal (wet signal) (dB). The value is between -20 and 10. */
        AUDIO_REVERB_WET_LEVEL = 1, // (dB, [-20,10]), the level of the early reflection signal (wet signal)

        /** 2: The room size of the reflection. The value is between 0 and 100. */
        AUDIO_REVERB_ROOM_SIZE = 2, // ([0,100]), the room size of the reflection

        /** 3: The length of the initial delay of the wet signal (ms). The value is between 0 and 200. */
        AUDIO_REVERB_WET_DELAY = 3, // (ms, [0,200]), the length of the initial delay of the wet signal in ms

        /** 4: The reverberation strength. The value is between 0 and 100. */
        AUDIO_REVERB_STRENGTH = 4, // ([0,100]), the strength of the reverberation
    }

    /**
	 * Local voice changer options.
	 */
    public enum VOICE_CHANGER_PRESET
    {
        /**
		 * The original voice (no local voice change).
		 */
        VOICE_CHANGER_OFF = 0x00000000, //Turn off the voice changer

        /**
		 * The voice of an old man.
		 */
        VOICE_CHANGER_OLDMAN = 0x00000001,

        /**
		 * The voice of a little boy.
		 */
        VOICE_CHANGER_BABYBOY = 0x00000002,

        /**
		 * The voice of a little girl.
		 */
        VOICE_CHANGER_BABYGIRL = 0x00000003,

        /**
		 * The voice of Zhu Bajie, a character in Journey to the West who has a voice like that of a growling bear.
		 */
        VOICE_CHANGER_ZHUBAJIE = 0x00000004,

        /**
		 * The ethereal voice.
		 */
        VOICE_CHANGER_ETHEREAL = 0x00000005,

        /**
		 * The voice of Hulk.
		 */
        VOICE_CHANGER_HULK = 0x00000006,

        /**
		 * A more vigorous voice.
		 */
        VOICE_BEAUTY_VIGOROUS = 0x00100001, //7,

        /**
		 * A deeper voice.
		 */
        VOICE_BEAUTY_DEEP = 0x00100002,

        /**
		 * A mellower voice.
		 */
        VOICE_BEAUTY_MELLOW = 0x00100003,

        /**
		 * Falsetto.
		 */
        VOICE_BEAUTY_FALSETTO = 0x00100004,

        /**
		 * A fuller voice.
		 */
        VOICE_BEAUTY_FULL = 0x00100005,

        /**
		 * A clearer voice.
		 */
        VOICE_BEAUTY_CLEAR = 0x00100006,

        /**
		 * A more resounding voice.
		 */
        VOICE_BEAUTY_RESOUNDING = 0x00100007,

        /**
		 * A more ringing voice.
		 */
        VOICE_BEAUTY_RINGING = 0x00100008,

        /**
		 * A more spatially resonant voice.
		 */
        VOICE_BEAUTY_SPACIAL = 0x00100009,

        /**
		 * (For male only) A more magnetic voice. Do not use it when the speaker is a female; otherwise, voice distortion occurs.
		 */
        GENERAL_BEAUTY_VOICE_MALE_MAGNETIC = 0x00200001,

        /**
		 * (For female only) A fresher voice. Do not use it when the speaker is a male; otherwise, voice distortion occurs.
		 */
        GENERAL_BEAUTY_VOICE_FEMALE_FRESH = 0x00200002,

        /**
		 * 	(For female only) A more vital voice. Do not use it when the speaker is a male; otherwise, voice distortion occurs.
		 */
        GENERAL_BEAUTY_VOICE_FEMALE_VITALITY = 0x00200003
    }

    /** Local voice reverberation presets. */
    public enum AUDIO_REVERB_PRESET
    {
        /**
		 * Turn off local voice reverberation, that is, to use the original voice.
		 */
        AUDIO_REVERB_OFF = 0x00000000, // Turn off audio reverb

        /**
		 * The reverberation style typical of a KTV venue (enhanced).
		 */
        AUDIO_REVERB_FX_KTV = 0x00100001,

        /**
		 * The reverberation style typical of a concert hall (enhanced).
		 */
        AUDIO_REVERB_FX_VOCAL_CONCERT = 0x00100002,

        /**
		 * The reverberation style typical of an uncle's voice.
		 */
        AUDIO_REVERB_FX_UNCLE = 0x00100003,

        /**
		 * The reverberation style typical of a little sister's voice.
		 */
        AUDIO_REVERB_FX_SISTER = 0x00100004,

        /**
		 * The reverberation style typical of a recording studio (enhanced).
		 */
        AUDIO_REVERB_FX_STUDIO = 0x00100005,

        /**
		 * The reverberation style typical of popular music (enhanced).
		 */
        AUDIO_REVERB_FX_POPULAR = 0x00100006,

        /**
		 * The reverberation style typical of R&B music (enhanced).
		 */
        AUDIO_REVERB_FX_RNB = 0x00100007,

        /**
		 * The reverberation style typical of the vintage phonograph.
		 */
        AUDIO_REVERB_FX_PHONOGRAPH = 0x00100008,

        /**
		 * The reverberation style typical of popular music.
		 */
        AUDIO_REVERB_POPULAR = 0x00000001,

        /**
		 * The reverberation style typical of R&B music.
		 */
        AUDIO_REVERB_RNB = 0x00000002,

        /**
		 * The reverberation style typical of rock music.
		 */
        AUDIO_REVERB_ROCK = 0x00000003,

        /**
		 * The reverberation style typical of hip-hop music.
		 */
        AUDIO_REVERB_HIPHOP = 0x00000004,

        /**
		 * The reverberation style typical of a concert hall.
		 */
        AUDIO_REVERB_VOCAL_CONCERT = 0x00000005,

        /**
		 * The reverberation style typical of a KTV venue.
		 */
        AUDIO_REVERB_KTV = 0x00000006,

        /**
		 * The reverberation style typical of a recording studio.
		 */
        AUDIO_REVERB_STUDIO = 0x00000007,

        /**
		 * The reverberation of the virtual stereo. The virtual stereo is an effect that renders the monophonic
		 * audio as the stereo audio, so that all users in the channel can hear the stereo voice effect.
		 * To achieve better virtual stereo reverberation, Agora recommends setting `profile` in `setAudioProfile`
		 * as `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`.
		 */
        AUDIO_VIRTUAL_STEREO = 0x00200001,

        /** 1: Electronic Voice.*/
        AUDIO_ELECTRONIC_VOICE = 0x00300001,

        /** 1: 3D Voice.*/
        AUDIO_THREEDIM_VOICE = 0x00400001
    }

    /** The options for SDK preset voice beautifier effects.
	 */
    public enum VOICE_BEAUTIFIER_PRESET
    {
        /** Turn off voice beautifier effects and use the original voice.
		 */
        VOICE_BEAUTIFIER_OFF = 0x00000000,

        /** A more magnetic voice.
		 *
		 * @note Agora recommends using this enumerator to process a male-sounding voice; otherwise, you may experience vocal distortion.
		 */
        CHAT_BEAUTIFIER_MAGNETIC = 0x01010100,

        /** A fresher voice.
		 *
		 * @note Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion.
		 */
        CHAT_BEAUTIFIER_FRESH = 0x01010200,

        /** A more vital voice.
		 *
		 * @note Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may experience vocal distortion.
		 */
        CHAT_BEAUTIFIER_VITALITY = 0x01010300,

        /** A more vigorous voice.
		 */
        TIMBRE_TRANSFORMATION_VIGOROUS = 0x01030100,

        /** A deeper voice.
		 */
        TIMBRE_TRANSFORMATION_DEEP = 0x01030200,

        /** A mellower voice.
		 */
        TIMBRE_TRANSFORMATION_MELLOW = 0x01030300,

        /** A falsetto voice.
		 */
        TIMBRE_TRANSFORMATION_FALSETTO = 0x01030400,

        /** A falsetto voice.
		 */
        TIMBRE_TRANSFORMATION_FULL = 0x01030500,

        /** A clearer voice.
		 */
        TIMBRE_TRANSFORMATION_CLEAR = 0x01030600,

        /** A more resounding voice.
		 */
        TIMBRE_TRANSFORMATION_RESOUNDING = 0x01030700,

        /** A more ringing voice.
		 */
        TIMBRE_TRANSFORMATION_RINGING = 0x01030800
    };

    /** The options for SDK preset audio effects.
	 */
    public enum AUDIO_EFFECT_PRESET
	    {
	        /** Turn off audio effects and use the original voice.
			 */
	        AUDIO_EFFECT_OFF = 0x00000000,

	        /** An audio effect typical of a KTV venue.
			 *
			 * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile"
			 * and setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`
			 * before setting this enumerator.
			 */
	        ROOM_ACOUSTICS_KTV = 0x02010100,

	        /** An audio effect typical of a concert hall.
			 *
			 * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile"
			 * and setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`
			 * before setting this enumerator.
			 */
	        ROOM_ACOUSTICS_VOCAL_CONCERT = 0x02010200,

	        /** An audio effect typical of a recording studio.
			 *
			 * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile"
			 * and setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`
			 * before setting this enumerator.
			 */
	        ROOM_ACOUSTICS_STUDIO = 0x02010300,

	        /** An audio effect typical of a vintage phonograph.
			 *
			 * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile"
			 * and setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`
			 * before setting this enumerator.
			 */
	        ROOM_ACOUSTICS_PHONOGRAPH = 0x02010400,

	        /** A virtual stereo effect that renders monophonic audio as stereo audio.
			 *
			 * @note Call \ref IRtcEngine::setAudioProfile "setAudioProfile" and set the `profile` parameter to
			 * `AUDIO_PROFILE_MUSIC_STANDARD_STEREO(3)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before setting this
			 * enumerator; otherwise, the enumerator setting does not take effect.
			 */
	        ROOM_ACOUSTICS_VIRTUAL_STEREO = 0x02010500,

	        /** A more spatial audio effect.
			 *
			 * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile"
	     * and setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`
	     * before setting this enumerator.
	     */
	        ROOM_ACOUSTICS_SPACIAL = 0x02010600,

	        /** A more ethereal audio effect.
	     *
	     * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile"
	     * and setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`
	     * before setting this enumerator.
	     */
	        ROOM_ACOUSTICS_ETHEREAL = 0x02010700,

	        /** A 3D voice effect that makes the voice appear to be moving around the user. The default cycle period of the 3D
	     * voice effect is 10 seconds. To change the cycle period, call \ref IRtcEngine::setAudioEffectParameters "setAudioEffectParameters"
	     * after this method.
	     *
	     * @note
	     * - Call \ref IRtcEngine::setAudioProfile "setAudioProfile" and set the `profile` parameter to `AUDIO_PROFILE_MUSIC_STANDARD_STEREO(3)`
	     * or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before setting this enumerator; otherwise, the enumerator setting does not take effect.
	     * - If the 3D voice effect is enabled, users need to use stereo audio playback devices to hear the anticipated voice effect.
	     */
	        ROOM_ACOUSTICS_3D_VOICE = 0x02010800,

	        /** The voice of an uncle.
	     *
	     * @note
	     * - Agora recommends using this enumerator to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
	     * - To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and
	     * setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
	     * setting this enumerator.
	     */
	        VOICE_CHANGER_EFFECT_UNCLE = 0x02020100,

	        /** The voice of an old man.
	     *
	     * @note
	     * - Agora recommends using this enumerator to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
	     * - To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and setting
	     * the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before setting
	     * this enumerator.
	     */
	        VOICE_CHANGER_EFFECT_OLDMAN = 0x02020200,

	        /** The voice of a boy.
	     *
	     * @note
	     * - Agora recommends using this enumerator to process a male-sounding voice; otherwise, you may not hear the anticipated voice effect.
	     * - To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and setting
	     * the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
	     * setting this enumerator.
	     */
	        VOICE_CHANGER_EFFECT_BOY = 0x02020300,

	        /** The voice of a young woman.
	     *
	     * @note
	     * - Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect.
	     * - To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and setting
	     * the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
	     * setting this enumerator.
	     */
	        VOICE_CHANGER_EFFECT_SISTER = 0x02020400,

	        /** The voice of a girl.
	     *
	     * @note
	     * - Agora recommends using this enumerator to process a female-sounding voice; otherwise, you may not hear the anticipated voice effect.
	     * - To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and setting
	     * the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
	     * setting this enumerator.
	     */
	        VOICE_CHANGER_EFFECT_GIRL = 0x02020500,

	        /** The voice of Pig King, a character in Journey to the West who has a voice like a growling bear.
	     *
	     * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and
	     * setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
	     * setting this enumerator.
	     */
	        VOICE_CHANGER_EFFECT_PIGKING = 0x02020600,

	        /** The voice of Hulk.
	     *
	     * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and
	     * setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
	     * setting this enumerator.
	     */
	        VOICE_CHANGER_EFFECT_HULK = 0x02020700,

	        /** An audio effect typical of R&B music.
	     *
	     * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and
	     * setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
	     * setting this enumerator.
	     */
	        STYLE_TRANSFORMATION_RNB = 0x02030100,

	        /** An audio effect typical of popular music.
			 *
			 * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and
			 * setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
			 * setting this enumerator.
			 */
	        STYLE_TRANSFORMATION_POPULAR = 0x02030200,

	        /** A pitch correction effect that corrects the user's pitch based on the pitch of the natural C major scale.
			 * To change the basic mode and tonic pitch, call \ref IRtcEngine::setAudioEffectParameters "setAudioEffectParameters" after this method.
			 *
			 * @note To achieve better audio effect quality, Agora recommends calling \ref IRtcEngine::setAudioProfile "setAudioProfile" and
			 * setting the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
			 * setting this enumerator.
			 */
	        PITCH_CORRECTION = 0x02040100
    };

    /** Audio codec profile types. The default value is LC_ACC. */
    public enum AUDIO_CODEC_PROFILE_TYPE
    {
        /** 0: LC-AAC, which is the low-complexity audio codec type. */
        AUDIO_CODEC_PROFILE_LC_AAC = 0,

        /** 1: HE-AAC, which is the high-efficiency audio codec type. */
        AUDIO_CODEC_PROFILE_HE_AAC = 1,
    }

    /** Remote audio states.
	 */
    public enum REMOTE_AUDIO_STATE
    {
        /** 0: The remote audio is in the default state, probably due to
		 * #REMOTE_AUDIO_REASON_LOCAL_MUTED (3),
		 * #REMOTE_AUDIO_REASON_REMOTE_MUTED (5), or
		 * #REMOTE_AUDIO_REASON_REMOTE_OFFLINE (7).
		 */
        REMOTE_AUDIO_STATE_STOPPED = 0, // Default state, audio is started or remote user disabled/muted audio stream

        /** 1: The first remote audio packet is received.
		 */
        REMOTE_AUDIO_STATE_STARTING = 1, // The first audio frame packet has been received

        /** 2: The remote audio stream is decoded and plays normally, probably
		 * due to #REMOTE_AUDIO_REASON_NETWORK_RECOVERY (2),
		 * #REMOTE_AUDIO_REASON_LOCAL_UNMUTED (4), or
		 * #REMOTE_AUDIO_REASON_REMOTE_UNMUTED (6).
		 */
        REMOTE_AUDIO_STATE_DECODING = 2, // The first remote audio frame has been decoded or fronzen state ends

        /** 3: The remote audio is frozen, probably due to
		 * #REMOTE_AUDIO_REASON_NETWORK_CONGESTION (1).
		 */
        REMOTE_AUDIO_STATE_FROZEN = 3, // Remote audio is frozen, probably due to network issue

        /** 4: The remote audio fails to start, probably due to
		 * #REMOTE_AUDIO_REASON_INTERNAL (0).
		 */
        REMOTE_AUDIO_STATE_FAILED = 4, // Remote audio play failed
    }

    /** Remote audio state reasons.
	 */
    public enum REMOTE_AUDIO_STATE_REASON
    {
        /** 0: Internal reasons.
		 */
        REMOTE_AUDIO_REASON_INTERNAL = 0,

        /** 1: Network congestion.
		 */
        REMOTE_AUDIO_REASON_NETWORK_CONGESTION = 1,

        /** 2: Network recovery.
		 */
        REMOTE_AUDIO_REASON_NETWORK_RECOVERY = 2,

        /** 3: The local user stops receiving the remote audio stream or
		 * disables the audio module.
		 */
        REMOTE_AUDIO_REASON_LOCAL_MUTED = 3,

        /** 4: The local user resumes receiving the remote audio stream or
		 * enables the audio module.
		 */
        REMOTE_AUDIO_REASON_LOCAL_UNMUTED = 4,

        /** 5: The remote user stops sending the audio stream or disables the
		 * audio module.
		 */
        REMOTE_AUDIO_REASON_REMOTE_MUTED = 5,

        /** 6: The remote user resumes sending the audio stream or enables the
		 * audio module.
		 */
        REMOTE_AUDIO_REASON_REMOTE_UNMUTED = 6,

        /** 7: The remote user leaves the channel.
		 */
        REMOTE_AUDIO_REASON_REMOTE_OFFLINE = 7,
    }

    /** Remote video states. */
    // enum REMOTE_VIDEO_STATE
    // {
    //     // REMOTE_VIDEO_STATE_STOPPED is not used at this version. Ignore this value.
    //     // REMOTE_VIDEO_STATE_STOPPED = 0,  // Default state, video is started or remote user disabled/muted video stream
    //       /** 1: The remote video is playing. */
    //       REMOTE_VIDEO_STATE_RUNNING = 1,  // Running state, remote video can be displayed normally
    //       /** 2: The remote video is frozen. */
    //       REMOTE_VIDEO_STATE_FROZEN = 2,    // Remote video is frozen, probably due to network issue.
    // };

    /** The state of the remote video. */
    public enum REMOTE_VIDEO_STATE
    {
        /** 0: The remote video is in the default state, probably due to #REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED (3), #REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED (5), or #REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE (7).
		 */
        REMOTE_VIDEO_STATE_STOPPED = 0,

        /** 1: The first remote video packet is received.
		 */
        REMOTE_VIDEO_STATE_STARTING = 1,

        /** 2: The remote video stream is decoded and plays normally, probably due to #REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY (2), #REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED (4), #REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED (6), or #REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY (9).
		 */
        REMOTE_VIDEO_STATE_DECODING = 2,

        /** 3: The remote video is frozen, probably due to #REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION (1) or #REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK (8).
		 */
        REMOTE_VIDEO_STATE_FROZEN = 3,

        /** 4: The remote video fails to start, probably due to #REMOTE_VIDEO_STATE_REASON_INTERNAL (0).
		 */
        REMOTE_VIDEO_STATE_FAILED = 4
    }

    /** The publishing state.
	 */
    public enum STREAM_PUBLISH_STATE
    {
        /** 0: The initial publishing state after joining the channel.
		 */
        PUB_STATE_IDLE = 0,

        /** 1: Fails to publish the local stream. Possible reasons:
		 * - The local user calls \ref IRtcEngine::muteLocalAudioStream "muteLocalAudioStream(true)" or \ref IRtcEngine::muteLocalVideoStream "muteLocalVideoStream(true)" to stop sending local streams.
		 * - The local user calls \ref IRtcEngine::disableAudio "disableAudio" or \ref IRtcEngine::disableVideo "disableVideo" to disable the entire audio or video module.
		 * - The local user calls \ref IRtcEngine::enableLocalAudio "enableLocalAudio(false)" or \ref IRtcEngine::enableLocalVideo "enableLocalVideo(false)" to disable the local audio sampling or video capturing.
		 * - The role of the local user is `AUDIENCE`.
		 */
        PUB_STATE_NO_PUBLISHED = 1,

        /** 2: Publishing.
		 */
        PUB_STATE_PUBLISHING = 2,

        /** 3: Publishes successfully.
		 */
        PUB_STATE_PUBLISHED = 3
    }

    /** The subscribing state.
	 */
    public enum STREAM_SUBSCRIBE_STATE
    {
        /** 0: The initial subscribing state after joining the channel.
		 */
        SUB_STATE_IDLE = 0,

        /** 1: Fails to subscribe to the remote stream. Possible reasons:
		 * - The remote user:
		 *  - Calls \ref IRtcEngine::muteLocalAudioStream "muteLocalAudioStream(true)" or \ref IRtcEngine::muteLocalVideoStream "muteLocalVideoStream(true)" to stop sending local streams.
		 *  - Calls \ref IRtcEngine::disableAudio "disableAudio" or \ref IRtcEngine::disableVideo "disableVideo" to disable the entire audio or video modules.
		 *  - Calls \ref IRtcEngine::enableLocalAudio "enableLocalAudio(false)" or \ref IRtcEngine::enableLocalVideo "enableLocalVideo(false)" to disable the local audio sampling or video capturing.
		 *  - The role of the remote user is `AUDIENCE`.
		 * - The local user calls the following methods to stop receiving remote streams:
		 *  - Calls \ref IRtcEngine::muteRemoteAudioStream "muteRemoteAudioStream(true)", \ref IRtcEngine::muteAllRemoteAudioStreams "muteAllRemoteAudioStreams(true)", or \ref IRtcEngine::setDefaultMuteAllRemoteAudioStreams "setDefaultMuteAllRemoteAudioStreams(true)" to stop receiving remote audio streams.
		 *  - Calls \ref IRtcEngine::muteRemoteVideoStream "muteRemoteVideoStream(true)", \ref IRtcEngine::muteAllRemoteVideoStreams "muteAllRemoteVideoStreams(true)", or \ref IRtcEngine::setDefaultMuteAllRemoteVideoStreams "setDefaultMuteAllRemoteVideoStreams(true)" to stop receiving remote video streams.
		 */
        SUB_STATE_NO_SUBSCRIBED = 1,

        /** 2: Subscribing.
		 */
        SUB_STATE_SUBSCRIBING = 2,

        /** 3: Subscribes to and receives the remote stream successfully.
		 */
        SUB_STATE_SUBSCRIBED = 3
    }

    /** The reason for the remote video state change. */
    public enum REMOTE_VIDEO_STATE_REASON
    {
        /** 0: Internal reasons.
		 */
        REMOTE_VIDEO_STATE_REASON_INTERNAL = 0,

        /** 1: Network congestion.
		 */
        REMOTE_VIDEO_STATE_REASON_NETWORK_CONGESTION = 1,

        /** 2: Network recovery.
		 */
        REMOTE_VIDEO_STATE_REASON_NETWORK_RECOVERY = 2,

        /** 3: The local user stops receiving the remote video stream or disables the video module.
		 */
        REMOTE_VIDEO_STATE_REASON_LOCAL_MUTED = 3,

        /** 4: The local user resumes receiving the remote video stream or enables the video module.
		 */
        REMOTE_VIDEO_STATE_REASON_LOCAL_UNMUTED = 4,

        /** 5: The remote user stops sending the video stream or disables the video module.
		 */
        REMOTE_VIDEO_STATE_REASON_REMOTE_MUTED = 5,

        /** 6: The remote user resumes sending the video stream or enables the video module.
		 */
        REMOTE_VIDEO_STATE_REASON_REMOTE_UNMUTED = 6,

        /** 7: The remote user leaves the channel.
		 */
        REMOTE_VIDEO_STATE_REASON_REMOTE_OFFLINE = 7,

        /** 8: The remote audio-and-video stream falls back to the audio-only stream due to poor network conditions.
		 */
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK = 8,

        /** 9: The remote audio-only stream switches back to the audio-and-video stream after the network conditions improve.
		 */
        REMOTE_VIDEO_STATE_REASON_AUDIO_FALLBACK_RECOVERY = 9
    }

    /** Video frame rates. */
    public enum FRAME_RATE
    {
        /** 1: 1 fps */
        FRAME_RATE_FPS_1 = 1,

        /** 7: 7 fps */
        FRAME_RATE_FPS_7 = 7,

        /** 10: 10 fps */
        FRAME_RATE_FPS_10 = 10,

        /** 15: 15 fps */
        FRAME_RATE_FPS_15 = 15,

        /** 24: 24 fps */
        FRAME_RATE_FPS_24 = 24,

        /** 30: 30 fps */
        FRAME_RATE_FPS_30 = 30,

        /** 60: 60 fps (Windows and macOS only) */
        FRAME_RATE_FPS_60 = 60,
    }

    /** Video output orientation modes.
	 */
    public enum ORIENTATION_MODE
    {
        /** 0: (Default) Adaptive mode.

		 The video encoder adapts to the orientation mode of the video input device.

		 - If the width of the captured video from the SDK is greater than the height, the encoder sends the video in landscape mode. The encoder also sends the rotational information of the video, and the receiver uses the rotational information to rotate the received video.
		 - When you use a custom video source, the output video from the encoder inherits the orientation of the original video. If the original video is in portrait mode, the output video from the encoder is also in portrait mode. The encoder also sends the rotational information of the video to the receiver.
		 */
        ORIENTATION_MODE_ADAPTIVE = 0,

        /** 1: Landscape mode.

		 The video encoder always sends the video in landscape mode. The video encoder rotates the original video before sending it and the rotational infomation is 0. This mode applies to scenarios involving CDN live streaming.
		 */
        ORIENTATION_MODE_FIXED_LANDSCAPE = 1,

        /** 2: Portrait mode.

		 The video encoder always sends the video in portrait mode. The video encoder rotates the original video before sending it and the rotational infomation is 0. This mode applies to scenarios involving CDN live streaming.
		 */
        ORIENTATION_MODE_FIXED_PORTRAIT = 2,
    }

    /** Video degradation preferences when the bandwidth is a constraint. */
    public enum DEGRADATION_PREFERENCE
    {
        /** 0: (Default) Degrade the frame rate in order to maintain the video quality. */
        MAINTAIN_QUALITY = 0,

        /** 1: Degrade the video quality in order to maintain the frame rate. */
        MAINTAIN_FRAMERATE = 1,

        /** 2: (For future use) Maintain a balance between the frame rate and video quality. */
        MAINTAIN_BALANCED = 2,
    }

    /** Stream fallback options. */
    public enum STREAM_FALLBACK_OPTIONS
    {
        /** 0: No fallback behavior for the local/remote video stream when the uplink/downlink network conditions are poor. The quality of the stream is not guaranteed. */
        STREAM_FALLBACK_OPTION_DISABLED = 0,

        /** 1: Under poor downlink network conditions, the remote video stream, to which you subscribe, falls back to the low-stream (low resolution and low bitrate) video. You can set this option only in the \ref IRtcEngine::setRemoteSubscribeFallbackOption "setRemoteSubscribeFallbackOption" method. Nothing happens when you set this in the \ref IRtcEngine::setLocalPublishFallbackOption "setLocalPublishFallbackOption" method. */
        STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW = 1,

        /** 2: Under poor uplink network conditions, the published video stream falls back to audio only.

		 Under poor downlink network conditions, the remote video stream, to which you subscribe, first falls back to the low-stream (low resolution and low bitrate) video; and then to an audio-only stream if the network conditions worsen.*/
        STREAM_FALLBACK_OPTION_AUDIO_ONLY = 2,
    }

    /** Camera capturer configuration.
	 */
    public enum CAPTURER_OUTPUT_PREFERENCE
    {
        /** 0: (Default) self-adapts the camera output parameters to the system performance and network conditions to balance CPU consumption and video preview quality.
		 */
        CAPTURER_OUTPUT_PREFERENCE_AUTO = 0,

        /** 1: Prioritizes the system performance. The SDK chooses the dimension and frame rate of the local camera capture closest to those set by \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration".
		 */
        CAPTURER_OUTPUT_PREFERENCE_PERFORMANCE = 1,

        /** 2: Prioritizes the local preview quality. The SDK chooses higher camera output parameters to improve the local video preview quality. This option requires extra CPU and RAM usage for video pre-processing.
		 */
        CAPTURER_OUTPUT_PREFERENCE_PREVIEW = 2,
    }

    /** The priority of the remote user.
	 */
    public enum PRIORITY_TYPE
    {
        /** 50: The user's priority is high.
		 */
        PRIORITY_HIGH = 50,

        /** 100: (Default) The user's priority is normal.
		 */
        PRIORITY_NORMAL = 100,
    }

    /** Connection states. */
    public enum CONNECTION_STATE_TYPE
    {
        /** 1: The SDK is disconnected from Agora's edge server.

		 - This is the initial state before calling the \ref agora::rtc::IRtcEngine::joinChannel "joinChannel" method.
		 - The SDK also enters this state when the application calls the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method.
		 */
        CONNECTION_STATE_DISCONNECTED = 1,

        /** 2: The SDK is connecting to Agora's edge server.

		 - When the application calls the \ref agora::rtc::IRtcEngine::joinChannel "joinChannel" method, the SDK starts to establish a connection to the specified channel, triggers the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback, and switches to the #CONNECTION_STATE_CONNECTING state.
		 - When the SDK successfully joins the channel, it triggers the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback and switches to the #CONNECTION_STATE_CONNECTED state.
		 - After the SDK joins the channel and when it finishes initializing the media engine, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onJoinChannelSuccess "onJoinChannelSuccess" callback.
		 */
        CONNECTION_STATE_CONNECTING = 2,

        /** 3: The SDK is connected to Agora's edge server and has joined a channel. You can now publish or subscribe to a media stream in the channel.

		 If the connection to the channel is lost because, for example, if the network is down or switched, the SDK automatically tries to reconnect and triggers:
		 - The \ref agora::rtc::IRtcEngineEventHandler::onConnectionInterrupted "onConnectionInterrupted" callback (deprecated).
		 - The \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback and switches to the #CONNECTION_STATE_RECONNECTING state.
		 */
        CONNECTION_STATE_CONNECTED = 3,

        /** 4: The SDK keeps rejoining the channel after being disconnected from a joined channel because of network issues.

		 - If the SDK cannot rejoin the channel within 10 seconds after being disconnected from Agora's edge server, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onConnectionLost "onConnectionLost" callback, stays in the #CONNECTION_STATE_RECONNECTING state, and keeps rejoining the channel.
		 - If the SDK fails to rejoin the channel 20 minutes after being disconnected from Agora's edge server, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback, switches to the #CONNECTION_STATE_FAILED state, and stops rejoining the channel.
		 */
        CONNECTION_STATE_RECONNECTING = 4,

        /** 5: The SDK fails to connect to Agora's edge server or join the channel.

		 You must call the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method to leave this state, and call the \ref agora::rtc::IRtcEngine::joinChannel "joinChannel" method again to rejoin the channel.

		 If the SDK is banned from joining the channel by Agora's edge server (through the RESTful API), the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onConnectionBanned "onConnectionBanned" (deprecated) and \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callbacks.
		 */
        CONNECTION_STATE_FAILED = 5,
    }

    /** Reasons for a connection state change. */
    public enum CONNECTION_CHANGED_REASON_TYPE
    {
        /** 0: The SDK is connecting to Agora's edge server. */
        CONNECTION_CHANGED_CONNECTING = 0,

        /** 1: The SDK has joined the channel successfully. */
        CONNECTION_CHANGED_JOIN_SUCCESS = 1,

        /** 2: The connection between the SDK and Agora's edge server is interrupted. */
        CONNECTION_CHANGED_INTERRUPTED = 2,

        /** 3: The connection between the SDK and Agora's edge server is banned by Agora's edge server. */
        CONNECTION_CHANGED_BANNED_BY_SERVER = 3,

        /** 4: The SDK fails to join the channel for more than 20 minutes and stops reconnecting to the channel. */
        CONNECTION_CHANGED_JOIN_FAILED = 4,

        /** 5: The SDK has left the channel. */
        CONNECTION_CHANGED_LEAVE_CHANNEL = 5,

        /** 6: The connection failed since Appid is not valid. */
        CONNECTION_CHANGED_INVALID_APP_ID = 6,

        /** 7: The connection failed since channel name is not valid. */
        CONNECTION_CHANGED_INVALID_CHANNEL_NAME = 7,

        /** 8: The connection failed since token is not valid, possibly because:

		 - The App Certificate for the project is enabled in Console, but you do not use Token when joining the channel. If you enable the App Certificate, you must use a token to join the channel.
		 - The uid that you specify in the \ref agora::rtc::IRtcEngine::joinChannel "joinChannel" method is different from the uid that you pass for generating the token.
		 */
        CONNECTION_CHANGED_INVALID_TOKEN = 8,

        /** 9: The connection failed since token is expired. */
        CONNECTION_CHANGED_TOKEN_EXPIRED = 9,

        /** 10: The connection is rejected by server. */
        CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,

        /** 11: The connection changed to reconnecting since SDK has set a proxy server. */
        CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,

        /** 12: When SDK is in connection failed, the renew token operation will make it connecting. */
        CONNECTION_CHANGED_RENEW_TOKEN = 12,

        /** 13: The IP Address of SDK client has changed. i.e., Network type or IP/Port changed by network operator might change client IP address. */
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,

        /** 14: Timeout for the keep-alive of the connection between the SDK and Agora's edge server. The connection state changes to CONNECTION_STATE_RECONNECTING(4). */
        CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,
    }

    /** Network type. */
    public enum NETWORK_TYPE
    {
        /** -1: The network type is unknown. */
        NETWORK_TYPE_UNKNOWN = -1,

        /** 0: The SDK disconnects from the network. */
        NETWORK_TYPE_DISCONNECTED = 0,

        /** 1: The network type is LAN. */
        NETWORK_TYPE_LAN = 1,

        /** 2: The network type is Wi-Fi(including hotspots). */
        NETWORK_TYPE_WIFI = 2,

        /** 3: The network type is mobile 2G. */
        NETWORK_TYPE_MOBILE_2G = 3,

        /** 4: The network type is mobile 3G. */
        NETWORK_TYPE_MOBILE_3G = 4,

        /** 5: The network type is mobile 4G. */
        NETWORK_TYPE_MOBILE_4G = 5,
    }

    /** States of the last-mile network probe test. */
    public enum LASTMILE_PROBE_RESULT_STATE
    {
        /** 1: The last-mile network probe test is complete. */
        LASTMILE_PROBE_RESULT_COMPLETE = 1,

        /** 2: The last-mile network probe test is incomplete and the bandwidth estimation is not available, probably due to limited test resources. */
        LASTMILE_PROBE_RESULT_INCOMPLETE_NO_BWE = 2,

        /** 3: The last-mile network probe test is not carried out, probably due to poor network conditions. */
        LASTMILE_PROBE_RESULT_UNAVAILABLE = 3
    }

    /** Audio output routing. */
    public enum AUDIO_ROUTE_TYPE
    {
        /** Default.
		 */
        AUDIO_ROUTE_DEFAULT = -1,

        /** Headset.
		 */
        AUDIO_ROUTE_HEADSET = 0,

        /** Earpiece.
		 */
        AUDIO_ROUTE_EARPIECE = 1,

        /** Headset with no microphone.
		 */
        AUDIO_ROUTE_HEADSET_NO_MIC = 2,

        /** Speakerphone.
		 */
        AUDIO_ROUTE_SPEAKERPHONE = 3,

        /** Loudspeaker.
		 */
        AUDIO_ROUTE_LOUDSPEAKER = 4,

        /** Bluetooth headset.
		 */
        AUDIO_ROUTE_BLUETOOTH = 5,

        /** USB peripheral.
		 */
        AUDIO_ROUTE_USB = 6,

        /** HDMI peripheral.
		 */
        AUDIO_ROUTE_HDMI = 7,

        /** DisplayPort peripheral.
		 */
        AUDIO_ROUTE_DISPLAYPORT = 8,

        /** Apple AirPlay.
		 */
        AUDIO_ROUTE_AIRPLAY = 9,
    }

    /** Quality change of the local video in terms of target frame rate and target bit rate since last count.
	 */
    public enum QUALITY_ADAPT_INDICATION
    {
        /** The quality of the local video stays the same. */
        ADAPT_NONE = 0,

        /** The quality improves because the network bandwidth increases. */
        ADAPT_UP_BANDWIDTH = 1,

        /** The quality worsens because the network bandwidth decreases. */
        ADAPT_DOWN_BANDWIDTH = 2,
    }

    /** The error code in CHANNEL_MEDIA_RELAY_ERROR. */
    public enum CHANNEL_MEDIA_RELAY_ERROR
    {
        /** 0: The state is normal.
		 */
        RELAY_OK = 0,

        /** 1: An error occurs in the server response.
		 */
        RELAY_ERROR_SERVER_ERROR_RESPONSE = 1,

        /** 2: No server response. You can call the
		 * \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method to
		 * leave the channel.
		 */
        RELAY_ERROR_SERVER_NO_RESPONSE = 2,

        /** 3: The SDK fails to access the service, probably due to limited
		 * resources of the server.
		 */
        RELAY_ERROR_NO_RESOURCE_AVAILABLE = 3,

        /** 4: Fails to send the relay request.
		 */
        RELAY_ERROR_FAILED_JOIN_SRC = 4,

        /** 5: Fails to accept the relay request.
		 */
        RELAY_ERROR_FAILED_JOIN_DEST = 5,

        /** 6: The server fails to receive the media stream.
		 */
        RELAY_ERROR_FAILED_PACKET_RECEIVED_FROM_SRC = 6,

        /** 7: The server fails to send the media stream.
		 */
        RELAY_ERROR_FAILED_PACKET_SENT_TO_DEST = 7,

        /** 8: The SDK disconnects from the server due to poor network
		 * connections. You can call the \ref agora::rtc::IRtcEngine::leaveChannel
		 * "leaveChannel" method to leave the channel.
		 */
        RELAY_ERROR_SERVER_CONNECTION_LOST = 8,

        /** 9: An internal error occurs in the server.
		 */
        RELAY_ERROR_INTERNAL_ERROR = 9,

        /** 10: The token of the source channel has expired.
		 */
        RELAY_ERROR_SRC_TOKEN_EXPIRED = 10,

        /** 11: The token of the destination channel has expired.
		 */
        RELAY_ERROR_DEST_TOKEN_EXPIRED = 11,
    }

    /** The event code in CHANNEL_MEDIA_RELAY_EVENT. */
    public enum CHANNEL_MEDIA_RELAY_EVENT
    {
        /** 0: The user disconnects from the server due to poor network
		 * connections.
		 */
        RELAY_EVENT_NETWORK_DISCONNECTED = 0,

        /** 1: The network reconnects.
		 */
        RELAY_EVENT_NETWORK_CONNECTED = 1,

        /** 2: The user joins the source channel.
		 */
        RELAY_EVENT_PACKET_JOINED_SRC_CHANNEL = 2,

        /** 3: The user joins the destination channel.
		 */
        RELAY_EVENT_PACKET_JOINED_DEST_CHANNEL = 3,

        /** 4: The SDK starts relaying the media stream to the destination channel.
		 */
        RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL = 4,

        /** 5: The server receives the video stream from the source channel.
		 */
        RELAY_EVENT_PACKET_RECEIVED_VIDEO_FROM_SRC = 5,

        /** 6: The server receives the audio stream from the source channel.
		 */
        RELAY_EVENT_PACKET_RECEIVED_AUDIO_FROM_SRC = 6,

        /** 7: The destination channel is updated.
		 */
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL = 7,

        /** 8: The destination channel update fails due to internal reasons.
		 */
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_REFUSED = 8,

        /** 9: The destination channel does not change, which means that the
		 * destination channel fails to be updated.
		 */
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_NOT_CHANGE = 9,

        /** 10: The destination channel name is NULL.
		 */
        RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL_IS_NULL = 10,

        /** 11: The video profile is sent to the server.
		 */
        RELAY_EVENT_VIDEO_PROFILE_UPDATE = 11,
    }

    /** The state code in CHANNEL_MEDIA_RELAY_STATE. */
    public enum CHANNEL_MEDIA_RELAY_STATE
    {
        /** 0: The SDK is initializing.
		 */
        RELAY_STATE_IDLE = 0,

        /** 1: The SDK tries to relay the media stream to the destination channel.
		 */
        RELAY_STATE_CONNECTING = 1,

        /** 2: The SDK successfully relays the media stream to the destination
		 * channel.
		 */
        RELAY_STATE_RUNNING = 2,

        /** 3: A failure occurs. See the details in code.
		 */
        RELAY_STATE_FAILURE = 3,
    }

    /**  **DEPRECATED** Lifecycle of the CDN live video stream.
	 */
    public enum RTMP_STREAM_LIFE_CYCLE_TYPE
    {
        /** Bind to the channel lifecycle. If all hosts leave the channel, the CDN live streaming stops after 30 seconds.
		 */
        RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL = 1,

        /** Bind to the owner of the RTMP stream. If the owner leaves the channel, the CDN live streaming stops immediately.
		 */
        RTMP_STREAM_LIFE_CYCLE_BIND2OWNER = 2,
    }

    /** Content hints for screen sharing.
	 */
    public enum VideoContentHint
    {
        /** (Default) No content hint.
		 */
        CONTENT_HINT_NONE = 0,

        /** Motion-intensive content. Choose this option if you prefer smoothness or when you are sharing a video clip, movie, or video game.
		 */
        CONTENT_HINT_MOTION = 1,

        /** Motionless content. Choose this option if you prefer sharpness or when you are sharing a picture, PowerPoint slide, or text.
		 */
        CONTENT_HINT_DETAILS = 2
    }

    /** The contrast level, used with the @p lightening parameter.
	 */
    public enum LIGHTENING_CONTRAST_LEVEL
    {
        /** Low contrast level. */
        LIGHTENING_CONTRAST_LOW = 0,

        /** (Default) Normal contrast level. */
        LIGHTENING_CONTRAST_NORMAL,

        /** High contrast level. */
        LIGHTENING_CONTRAST_HIGH
    }

    /**
	 * IP areas.
	 */
    public enum AREA_CODE: uint
    {
        /**
		 * Mainland China.
		 */
        AREA_CODE_CN = (1 << 0),

        /**
		 * North America.
		 */
        AREA_CODE_NA = (1 << 1),

        /**
		 * Europe.
		 */
        AREA_CODE_EUR = (1 << 2),

        /**
		 * Asia, excluding Mainland China.
		 */
        AREA_CODE_AS = (1 << 3),

        /**
		 * Japan.
		 */
        AREA_CODE_JAPAN = (1 << 4),

        /**
		 * India.
		 */
        AREA_CODE_INDIA = (1 << 5),

        /**
		 * (Default) Global.
		 */
        AREA_CODE_GLOBAL = 0xFFFFFFFF
    }

    public enum ENCRYPTION_CONFIG
    {
        /**
		 * - 1: Force set master key and mode;
		 * - 0: Not force set, checking whether encryption plugin exists
		 */
        ENCRYPTION_FORCE_SETTING = (1 << 0),

        /**
		 * - 1: Force not encrypting packet;
		 * - 0: Not force encrypting;
		 */
        ENCRYPTION_FORCE_DISABLE_PACKET = (1 << 1)
    }

    public enum AUDIO_FRAME_TYPE
    {
        /** 0: PCM16. */
        FRAME_TYPE_PCM16 = 0, // PCM 16bit little endian
    }

    /** The video buffer type.
	 */
    public enum VIDEO_BUFFER_TYPE
    {
        /** 1: The video buffer in the format of raw data.
		 */
        VIDEO_BUFFER_RAW_DATA = 1,
    }

    /** The video pixel format.
	 */
    public enum VIDEO_PIXEL_FORMAT
    {
        /** 0: The video pixel format is unknown.
		 */
        VIDEO_PIXEL_UNKNOWN = 0,

        /** 1: The video pixel format is I420.
		 */
        VIDEO_PIXEL_I420 = 1,

        /** 2: The video pixel format is BGRA.
		 */
        VIDEO_PIXEL_BGRA = 2,

        /** 3: The video pixel format is NV21.
		 */
        VIDEO_PIXEL_NV21 = 3,

        /** 4: The video pixel format is RGBA.
		 */
        VIDEO_PIXEL_RGBA = 4,

        /** 5: The video pixel format is IMC2.
		 */
        VIDEO_PIXEL_IMC2 = 5,

        /** 7: The video pixel format is ARGB.
		 */
        VIDEO_PIXEL_ARGB = 7,

        /** 8: The video pixel format is NV12.
		 */
        VIDEO_PIXEL_NV12 = 8,

        /** 16: The video pixel format is I422.
		 */
        VIDEO_PIXEL_I422 = 16,
    }

    public enum MEDIA_SOURCE_TYPE
    {
        /** Audio playback device.
		 */
        AUDIO_PLAYOUT_SOURCE = 0,

        /** Microphone.
		 */
        AUDIO_RECORDING_SOURCE = 1,
    }

    /** Encryption mode.
	 */
    public enum ENCRYPTION_MODE
    {
        /** 1: (Default) 128-bit AES encryption, XTS mode.
		 */
        AES_128_XTS = 1,

        /** 2: 128-bit AES encryption, ECB mode.
		 */
        AES_128_ECB = 2,

        /** 3: 256-bit AES encryption, XTS mode.
		 */
        AES_256_XTS = 3,

        /** 4: 128-bit SM4 encryption, ECB mode.
		 */
        SM4_128_ECB = 4,

        /** Enumerator boundary.
		 */
        MODE_END,
    }

    public enum BITRATE
    {
        /* (Recommended) The standard bitrate set in the \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method.
    
         In this mode, the bitrates differ between the live interactive streaming and communication profiles:
    
         - `COMMUNICATION` profile: The video bitrate is the same as the base bitrate.
         - `LIVE_BROADCASTING` profile: The video bitrate is twice the base bitrate.
    
         */
        STANDARD_BITRATE = 0,

        /* The compatible bitrate set in the \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method.
        
         The bitrate remains the same regardless of the channel profile. If you choose this mode in the `LIVE_BROADCASTING` profile, the video frame rate may be lower than the set value.
         */
        COMPATIBLE_BITRATE = -1,

        /* Use the default minimum bitrate.
         */
        DEFAULT_MIN_BITRATE = -1
    }
    
    public enum METADATA_TYPE
    {
	    /** -1: the metadata type is unknown.
         */
	    UNKNOWN_METADATA = -1,
	    /** 0: the metadata type is video.
         */
	    VIDEO_METADATA = 0,
    };
    
    internal enum AppType {
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
	    APP_TYPE_UNI_APP = 14,
    };
}