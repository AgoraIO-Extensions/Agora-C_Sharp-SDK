//  AgoraEnums.cs
//
//  Created by Yiqing Huang on May 25, 2021.
//  Modified by Yiqing Huang on July 21, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    using uid_t = UInt32;
    using view_t = UInt64;

    /** Warning code. */
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

        /** 118: A timeout occurs when setting the client role in the interactive live streaming profile.
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

        /** 1016: Audio Device Module: A warning occurs in the audio capturing device.
         */
        WARN_ADM_RUNTIME_RECORDING_WARNING = 1016,

        /** 1019: Audio Device Module: No valid audio data is captured.
         */
        WARN_ADM_RECORD_AUDIO_SILENCE = 1019,

        /** 1020: Audio device module: The audio playback frequency is abnormal, which may cause audio freezes. This abnormality is caused by high CPU usage. Agora recommends stopping other apps.
         */
        WARN_ADM_PLAYOUT_MALFUNCTION = 1020,

        /** 1021: Audio device module: the audio capturing frequency is abnormal, which may cause audio freezes. This abnormality is caused by high CPU usage. Agora recommends stopping other apps.
         */
        WARN_ADM_RECORD_MALFUNCTION = 1021,

        /** 1025: The audio playback or capturing is interrupted by system events (such as a phone call).
         */
        WARN_ADM_CALL_INTERRUPTION = 1025,

        /** 1029: During a call, the audio session category should be set to
          * AVAudioSessionCategoryPlayAndRecord, and RtcEngine monitors this value.
          * If the audio session category is set to other values, this warning code
          * is triggered and RtcEngine will forcefully set it back to
          * AVAudioSessionCategoryPlayAndRecord.
         */
        WARN_ADM_IOS_CATEGORY_NOT_PLAYANDRECORD = 1029,

        /** 1031: Audio Device Module: The captured audio voice is too low.
         */
        WARN_ADM_RECORD_AUDIO_LOWLEVEL = 1031,

        /** 1032: Audio Device Module: The playback audio voice is too low.
         */
        WARN_ADM_PLAYOUT_AUDIO_LOWLEVEL = 1032,

        /** 1033: Audio device module: The audio capturing device is occupied.
          */
        WARN_ADM_RECORD_AUDIO_IS_ACTIVE = 1033,

        /** 1040: Audio device module: An exception occurs with the audio drive.
          * Solutions:
          * - Disable or re-enable the audio device.
          * - Re-enable your device.
          * - Update the sound card drive.
          */
        WARN_ADM_WINDOWS_NO_DATA_READY_EVENT = 1040,

        /** 1042: Audio device module: The audio capturing device is different from the audio playback device,
          * which may cause echoes problem. Agora recommends using the same audio device to capture and playback
          * audio.
          */
        WARN_ADM_INCONSISTENT_AUDIO_DEVICE = 1042,

        /** 1051: (Communication profile only) Audio processing module: A howling sound is detected when capturing the audio data.
         */
        WARN_APM_HOWLING = 1051,

        /** 1052: Audio Device Module: The device is in the glitch state.
         */
        WARN_ADM_GLITCH_STATE = 1052,

        /** 1053: Audio Processing Module: A residual echo is detected, which may be caused by the belated scheduling of system threads or the signal overflow.
         */
        WARN_APM_RESIDUAL_ECHO = 1053,

        /// @cond
        WARN_ADM_WIN_CORE_NO_RECORDING_DEVICE = 1322,

        /// @endcond
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

        /// @cond
        WARN_RTM_LOGIN_TIMEOUT = 2005,

        WARN_RTM_KEEP_ALIVE_TIMEOUT = 2009
        /// @endcond
    }

    /** Error code. */
    public enum ERROR_CODE_TYPE
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

        /** 12: The method is called too often.
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

        /** 123: The user is banned by the server. This error occurs when the user is kicked out the channel from the server.
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

        /** 156: The format of the RTMP or RTMPS stream URL is not supported. Check whether the URL format is correct.
         */
        ERR_PUBLISH_STREAM_FORMAT_NOT_SUPPORTED = 156,

        /** 157: The necessary dynamical library is not integrated. For example, if you call
         * the \ref agora::rtc::IRtcEngine::enableDeepLearningDenoise "enableDeepLearningDenoise" but do not integrate the dynamical
         * library for the deep-learning noise reduction into your project, the SDK reports this error code.
         *
         */
        ERR_MODULE_NOT_FOUND = 157,

        /// @cond
        /** 158: The dynamical library for the super-resolution algorithm is not integrated.
         * When you call the \ref agora::rtc::IRtcEngine::enableRemoteSuperResolution "enableRemoteSuperResolution" method but
         * do not integrate the dynamical library for the super-resolution algorithm
         * into your project, the SDK reports this error code.
         */
        ERR_MODULE_SUPER_RESOLUTION_NOT_FOUND = 158,

        /// @endcond
        /** 160: The recording operation has been performed.
   */
        ERR_ALREADY_IN_RECORDING = 160,

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

         *Deprecated as of v2.4.1. Use LOCAL_VIDEO_STREAM_ERROR_CAPTURE_FAILURE(4) in the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback instead.
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

        /** 1011: Audio Device Module: An error occurs in initializing the capturing device.
         */
        ERR_ADM_INIT_RECORDING = 1011,

        /** 1012: Audio Device Module: An error occurs in starting the capturing device.
         */
        ERR_ADM_START_RECORDING = 1012,

        /** 1013: Audio Device Module: An error occurs in stopping the capturing device.
         */
        ERR_ADM_STOP_RECORDING = 1013,

        /** 1015: Audio Device Module: A playback error occurs. Check your playback device and try rejoining the channel.
         */
        ERR_ADM_RUNTIME_PLAYOUT_ERROR = 1015,

        /** 1017: Audio Device Module: A capturing error occurs.
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

        /** 1108: Audio device module: The capturing frequency is lower than 50.
         * 0 indicates that the capturing is not yet started. We recommend
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
         * Solutions: Plug in a proper capturing device. */
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

        /** 1359: Audio Device Module: No capturing device exists.
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

         * Deprecated as of v2.4.1. Use LOCAL_VIDEO_STREAM_ERROR_DEVICE_BUSY(3) in the \ref agora::rtc::IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" callback instead.
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
    }

    /** Output log filter level. */
    [Flags]
    public enum LOG_FILTER_TYPE
    {
        /** 0: Do not output any log information. */
        LOG_FILTER_OFF = 0,

        /** 0x080f: Output all log information.
         * Set your log filter as debug if you want to get the most complete log file.      */
        LOG_FILTER_DEBUG = 0x080f,

        /** 0x000f: Output CRITICAL, ERROR, WARNING, and INFO level log information.
         * We recommend setting your log filter as this level.
         */
        LOG_FILTER_INFO = 0x000f,

        /** 0x000e: Outputs CRITICAL, ERROR, and WARNING level log information.
         */
        LOG_FILTER_WARN = 0x000e,

        /** 0x000c: Outputs CRITICAL and ERROR level log information. */
        LOG_FILTER_ERROR = 0x000c,

        /** 0x0008: Outputs CRITICAL level log information. */
        LOG_FILTER_CRITICAL = 0x0008,

        /// @cond
        LOG_FILTER_MASK = 0x80f,
        /// @endcond
    }

    /** The output log level of the SDK.
     *
     * @since v3.3.0
     */
    [Flags]
    public enum LOG_LEVEL
    {
        /** 0: Do not output any log. */
        LOG_LEVEL_NONE = 0x0000,

        /** 0x0001: (Default) Output logs of the FATAL, ERROR, WARN and INFO level. We recommend setting your log filter as this level.
         */
        LOG_LEVEL_INFO = 0x0001,

        /** 0x0002: Output logs of the FATAL, ERROR and WARN level.
         */
        LOG_LEVEL_WARN = 0x0002,

        /** 0x0004: Output logs of the FATAL and ERROR level.  */
        LOG_LEVEL_ERROR = 0x0004,

        /** 0x0008: Output logs of the FATAL level.  */
        LOG_LEVEL_FATAL = 0x0008,
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
    public enum MAX_USER_ACCOUNT_LENGTH_T
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

        /** 114: For internal use only.
     */
         MEDIA_ENGINE_AUDIO_ADM_ROUTING_UPDATE = 114,

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
        /** 710: The audio mixing file is playing after the method call of
     * \ref IRtcEngine::startAudioMixing "startAudioMixing" or \ref IRtcEngine::resumeAudioMixing "resumeAudioMixing" succeeds.
     */
        AUDIO_MIXING_STATE_PLAYING = 710,

        /** 711: The audio mixing file pauses playing after the method call of \ref IRtcEngine::pauseAudioMixing "pauseAudioMixing" succeeds.
    */
        AUDIO_MIXING_STATE_PAUSED = 711,

        /** 713: The audio mixing file stops playing after the method call of \ref IRtcEngine::stopAudioMixing "stopAudioMixing" succeeds.
    */
        AUDIO_MIXING_STATE_STOPPED = 713,

        /** 714: An exception occurs during the playback of the audio mixing file. See the `errorCode` for details.
    */
        AUDIO_MIXING_STATE_FAILED = 714,
    }

    /** The reason of audio mixing state change.
 */
    public enum AUDIO_MIXING_REASON_TYPE
    {
        /** 701: The SDK cannot open the audio mixing file.
   */
        AUDIO_MIXING_REASON_CAN_NOT_OPEN = 701,

        /** 702: The SDK opens the audio mixing file too frequently.
   */
        AUDIO_MIXING_REASON_TOO_FREQUENT_CALL = 702,

        /** 703: The audio mixing file playback is interrupted.
   */
        AUDIO_MIXING_REASON_INTERRUPTED_EOF = 703,

        /** 720: The audio mixing is started by user.
   */
        AUDIO_MIXING_REASON_STARTED_BY_USER = 720,

        /** 721: The audio mixing file is played once.
   */
        AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED = 721,

        /** 722: The audio mixing file is playing in a new loop.
   */
        AUDIO_MIXING_REASON_START_NEW_LOOP = 722,

        /** 723: The audio mixing file is all played out.
   */
        AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED = 723,

        /** 724: Playing of audio file is stopped by user.
   */
        AUDIO_MIXING_REASON_STOPPED_BY_USER = 724,

        /** 725: Playing of audio file is paused by user.
   */
        AUDIO_MIXING_REASON_PAUSED_BY_USER = 725,

        /** 726: Playing of audio file is resumed by user.
   */
        AUDIO_MIXING_REASON_RESUMED_BY_USER = 726,
    }

    /** Media device states.
 */
    public enum MEDIA_DEVICE_STATE_TYPE
    {
        /** 0: The device is idle.
   */
        MEDIA_DEVICE_STATE_IDLE = 0,

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
        MEDIA_DEVICE_STATE_UNPLUGGED = 8,

        /** 16: The device is not recommended.
    */
        MEDIA_DEVICE_STATE_UNRECOMMENDED = 16
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

        /** 1: Audio capturing device.
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

        /** 6: capture InBackground. */
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_INBACKGROUND = 6,

        /** 7:capture MultipleForegroundApps.  */
        LOCAL_VIDEO_STREAM_ERROR_CAPTURE_MULTIPLE_FOREGROUND_APPS = 7,

        /** 8:capture not found*/
        LOCAL_VIDEO_STREAM_ERROR_DEVICE_NOT_FOUND = 8,

        /** 11: The shared window is minimized when you call \ref IRtcEngine::startScreenCaptureByWindowId "startScreenCaptureByWindowId" to share a window.
     */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_MINIMIZED = 11,

        /** 12: The error code indicates that a window shared by the window ID has been closed, or a full-screen window
     * shared by the window ID has exited full-screen mode.
     * After exiting full-screen mode, remote users cannot see the shared window. To prevent remote users from seeing a
     * black screen, Agora recommends that you immediately stop screen sharing.
     *
     * Common scenarios for reporting this error code:
     * - When the local user closes the shared window, the SDK reports this error code.
     * - The local user shows some slides in full-screen mode first, and then shares the windows of the slides. After
     * the user exits full-screen mode, the SDK reports this error code.
     * - The local user watches web video or reads web document in full-screen mode first, and then shares the window of
     * the web video or document. After the user exits full-screen mode, the SDK reports this error code.
     */
        LOCAL_VIDEO_STREAM_ERROR_SCREEN_CAPTURE_WINDOW_CLOSED = 12,
    }

    /** Local audio state types.
 */
    public enum LOCAL_AUDIO_STREAM_STATE
    {
        /** 0: The local audio is in the initial state.
     */
        LOCAL_AUDIO_STREAM_STATE_STOPPED = 0,

        /** 1: The capturing device starts successfully.
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

        /** 4: The local audio capturing fails. Check whether the capturing device
     * is working properly.
     */
        LOCAL_AUDIO_STREAM_ERROR_RECORD_FAILURE = 4,

        /** 5: The local audio encoding fails.
     */
        LOCAL_AUDIO_STREAM_ERROR_ENCODE_FAILURE = 5,

        /** 6: No recording audio device.
   */
        LOCAL_AUDIO_STREAM_ERROR_NO_RECORDING_DEVICE = 6,

        /** 7: No playout audio device.
   */
        LOCAL_AUDIO_STREAM_ERROR_NO_PLAYOUT_DEVICE = 7,

        LOCAL_AUDIO_STREAM_ERROR_RECORD_INVALID_ID = 9,

        LOCAL_AUDIO_STREAM_ERROR_PLAYOUT_INVALID_ID = 10
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

Sets the sample rate, bitrate, encoding mode, and the number of channels:*/
    public enum AUDIO_PROFILE_TYPE // sample rate, bit rate, mono/stereo, speech/music codec
    {
        /**
     0: Default audio profile:
     - For the `LIVE_BROADCASTING` profile: A sample rate of 48 KHz, music encoding, mono, and a bitrate of up to 64 Kbps.
     - For the `COMMUNICATION` profile:
        - Windows: A sample rate of 16 KHz, audio encoding, mono, and a bitrate of up to 16 Kbps.
        - Android/macOS/iOS: A sample rate of 32 KHz, audio encoding, mono, and a bitrate of up to 18 Kbps.
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
        /** 0: Default audio scenario. */
        AUDIO_SCENARIO_DEFAULT = 0,

        /** 1: Entertainment scenario where users need to frequently switch the user role. */
        AUDIO_SCENARIO_CHATROOM_ENTERTAINMENT = 1,

        /** 2: Education scenario where users want smoothness and stability. */
        AUDIO_SCENARIO_EDUCATION = 2,

        /** 3: High-quality audio chatroom scenario where hosts mainly play music. */
        AUDIO_SCENARIO_GAME_STREAMING = 3,

        /** 4: Showroom scenario where a single host wants high-quality audio. */
        AUDIO_SCENARIO_SHOWROOM = 4,

        /** 5: Gaming scenario for group chat that only contains the human voice. */
        AUDIO_SCENARIO_CHATROOM_GAMING = 5,

        /** 6: IoT (Internet of Things) scenario where users use IoT devices with low power consumption. */
        AUDIO_SCENARIO_IOT = 6,

        /** 8: Meeting scenario that mainly contains the human voice.
     *
     * @since v3.2.0
     */
        AUDIO_SCENARIO_MEETING = 8,

        /** The number of elements in the enumeration.
     */
        AUDIO_SCENARIO_NUM = 9,
    }

    /** The channel profile.
 */
    public enum CHANNEL_PROFILE_TYPE
    {
        /** Communication. This profile applies to scenarios such as an audio call or video call,
    * where all users can publish and subscribe to streams.
    */
        CHANNEL_PROFILE_COMMUNICATION = 0,

        /** Live streaming. In this profile, uses have roles, namely, host and audience (default).
    * A host both publishes and subscribes to streams, while an audience subscribes to streams only.
    * This profile applies to scenarios such as a chat room or interactive video streaming.
    */
        CHANNEL_PROFILE_LIVE_BROADCASTING = 1,

        /** 2: Gaming. This profile uses a codec with a lower bitrate and consumes less power. Applies to the gaming scenario, where all game players can talk freely.
    *
    * @note Agora does not recommend using this setting.
    */
        CHANNEL_PROFILE_GAME = 2,
    }

    /** The role of a user in interactive live streaming. */
    public enum CLIENT_ROLE_TYPE
    {
        /** 1: Host. A host can both send and receive streams. */
        CLIENT_ROLE_BROADCASTER = 1,

        /** 2: (Default) Audience. An `audience` member can only receive streams. */
        CLIENT_ROLE_AUDIENCE = 2,
    }

    /** The latency level of an audience member in interactive live streaming.
 *
 * @note Takes effect only when the user role is `CLIENT_ROLE_AUDIENCE`.
 */
    public enum AUDIENCE_LATENCY_LEVEL_TYPE
    {
        /** 1: Low latency. */
        AUDIENCE_LATENCY_LEVEL_LOW_LATENCY = 1,

        /** 2: (Default) Ultra low latency. */
        AUDIENCE_LATENCY_LEVEL_ULTRA_LOW_LATENCY = 2,
    }

    /**
   * The reason why super resolution is not successfully enabled or the message
   * that confirms success.
   *
   * @since v3.5.1
   */
    public enum SUPER_RESOLUTION_STATE_REASON
    {
        /** 0: The super-resolution algorithm is successfully enabled.
     */
        SR_STATE_REASON_SUCCESS = 0,

        /** 1: The original resolution of the remote video is beyond the range where
      *  super resolution can be applied.
     */
        SR_STATE_REASON_STREAM_OVER_LIMITATION = 1,

        /** 2: Super resolution is already being used to boost another remote user's video.
     */
        SR_STATE_REASON_USER_COUNT_OVER_LIMITATION = 2,

        /** 3: The device does not support using super resolution.
     */
        SR_STATE_REASON_DEVICE_NOT_SUPPORTED = 3,
    }

    /// @endcond
    public enum VIRTUAL_BACKGROUND_SOURCE_STATE_REASON
    {
        VIRTUAL_BACKGROUND_SOURCE_STATE_REASON_SUCCESS = 0,

        // background image does not exist
        VIRTUAL_BACKGROUND_SOURCE_STATE_REASON_IMAGE_NOT_EXIST = 1,

        // color format is not supported
        VIRTUAL_BACKGROUND_SOURCE_STATE_REASON_COLOR_FORMAT_NOT_SUPPORTED = 2,

        // The device is not supported
        VIRTUAL_BACKGROUND_SOURCE_STATE_REASON_DEVICE_NOT_SUPPORTED = 3,
    }

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
 States of the RTMP or RTMPS streaming.
 */
    public enum RTMP_STREAM_PUBLISH_STATE
    {
        /** The RTMP or RTMPS streaming has not started or has ended. This state is also triggered after you remove an RTMP or RTMPS stream from the CDN by calling `removePublishStreamUrl`.
   */
        RTMP_STREAM_PUBLISH_STATE_IDLE = 0,

        /** The SDK is connecting to Agora's streaming server and the CDN server. This state is triggered after you call the \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method.
   */
        RTMP_STREAM_PUBLISH_STATE_CONNECTING = 1,

        /** The RTMP or RTMPS streaming publishes. The SDK successfully publishes the RTMP or RTMPS streaming and returns this state.
   */
        RTMP_STREAM_PUBLISH_STATE_RUNNING = 2,

        /** The RTMP or RTMPS streaming is recovering. When exceptions occur to the CDN, or the streaming is interrupted, the SDK tries to resume RTMP or RTMPS streaming and returns this state.

   - If the SDK successfully resumes the streaming, #RTMP_STREAM_PUBLISH_STATE_RUNNING (2) returns.
   - If the streaming does not resume within 60 seconds or server errors occur, #RTMP_STREAM_PUBLISH_STATE_FAILURE (4) returns. You can also reconnect to the server by calling the \ref IRtcEngine::removePublishStreamUrl "removePublishStreamUrl" and \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" methods.
   */
        RTMP_STREAM_PUBLISH_STATE_RECOVERING = 3,

        /** The RTMP or RTMPS streaming fails. See the errCode parameter for the detailed error information. You can also call the \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method to publish the RTMP or RTMPS streaming again.
   */
        RTMP_STREAM_PUBLISH_STATE_FAILURE = 4,
    }

    /**
 Error codes of the RTMP or RTMPS streaming.
 */
    public enum RTMP_STREAM_PUBLISH_ERROR
    {
        /** The RTMP or RTMPS streaming publishes successfully. */
        RTMP_STREAM_PUBLISH_ERROR_OK = 0,

        /** Invalid argument used. If, for example, you do not call the \ref IRtcEngine::setLiveTranscoding "setLiveTranscoding" method to configure the LiveTranscoding parameters before calling the addPublishStreamUrl method, the SDK returns this error. Check whether you set the parameters in the *setLiveTranscoding* method properly. */
        RTMP_STREAM_PUBLISH_ERROR_INVALID_ARGUMENT = 1,

        /** The RTMP or RTMPS streaming is encrypted and cannot be published. */
        RTMP_STREAM_PUBLISH_ERROR_ENCRYPTED_STREAM_NOT_ALLOWED = 2,

        /** Timeout for the RTMP or RTMPS streaming. Call the \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method to publish the streaming again. */
        RTMP_STREAM_PUBLISH_ERROR_CONNECTION_TIMEOUT = 3,

        /** An error occurs in Agora's streaming server. Call the `addPublishStreamUrl` method to publish the streaming again. */
        RTMP_STREAM_PUBLISH_ERROR_INTERNAL_SERVER_ERROR = 4,

        /** An error occurs in the CDN server. */
        RTMP_STREAM_PUBLISH_ERROR_RTMP_SERVER_ERROR = 5,

        /** The RTMP or RTMPS streaming publishes too frequently. */
        RTMP_STREAM_PUBLISH_ERROR_TOO_OFTEN = 6,

        /** The host publishes more than 10 URLs. Delete the unnecessary URLs before adding new ones. */
        RTMP_STREAM_PUBLISH_ERROR_REACH_LIMIT = 7,

        /** The host manipulates other hosts' URLs. Check your app logic. */
        RTMP_STREAM_PUBLISH_ERROR_NOT_AUTHORIZED = 8,

        /** Agora's server fails to find the RTMP or RTMPS streaming. */
        RTMP_STREAM_PUBLISH_ERROR_STREAM_NOT_FOUND = 9,

        /** The format of the RTMP or RTMPS streaming URL is not supported. Check whether the URL format is correct. */
        RTMP_STREAM_PUBLISH_ERROR_FORMAT_NOT_SUPPORTED = 10,

        /** The RTMP streaming unpublishes successfully. */
        RTMP_STREAM_UNPUBLISH_ERROR_OK = 100,
    }

    /** Events during the RTMP or RTMPS streaming. */
    public enum RTMP_STREAMING_EVENT
    {
        /** An error occurs when you add a background image or a watermark image to the RTMP or RTMPS stream.
   */
        RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE = 1,

        /** The chosen URL address is already in use for CDN live streaming.
   */
        RTMP_STREAMING_EVENT_URL_ALREADY_IN_USE = 2,
    }

    /** States of importing an external video stream in the interactive live streaming. */
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

    /** The brightness level of the video image captured by the local camera.
 *
 * @since v3.3.0
 */
    public enum CAPTURE_BRIGHTNESS_LEVEL_TYPE
    {
        /** -1: The SDK does not detect the brightness level of the video image.
     * Wait a few seconds to get the brightness level from `CAPTURE_BRIGHTNESS_LEVEL_TYPE` in the next callback.
     */
        CAPTURE_BRIGHTNESS_LEVEL_INVALID = -1,

        /** 0: The brightness level of the video image is normal.
     */
        CAPTURE_BRIGHTNESS_LEVEL_NORMAL = 0,

        /** 1: The brightness level of the video image is too bright.
     */
        CAPTURE_BRIGHTNESS_LEVEL_BRIGHT = 1,

        /** 2: The brightness level of the video image is too dark.
     */
        CAPTURE_BRIGHTNESS_LEVEL_DARK = 2,
    }

    /** The use mode of the audio data in the \ref media::IAudioFrameObserver::onRecordAudioFrame "onRecordAudioFrame" or \ref media::IAudioFrameObserver::onPlaybackAudioFrame "onPlaybackAudioFrame" callback.
 */
    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        /** 0: Read-only mode: Users only read the \ref agora::media::IAudioFrameObserver::AudioFrame "AudioFrame" data without modifying anything. For example, when users acquire the data with the Agora SDK, then push the RTMP or RTMPS streams. */
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
        /** 66: Baseline video codec profile. Generally used in video calls on mobile phones. */
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

    /** Video Codec types for publishing streams. */
    public enum VIDEO_CODEC_TYPE_FOR_STREAM
    {
        VIDEO_CODEC_H264_FOR_STREAM = 1,
        VIDEO_CODEC_H265_FOR_STREAM = 2,
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
 * @deprecated Deprecated from v3.2.0.
 *
 * Local voice changer options.
 */
    [Flags]
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

    /** @deprecated Deprecated from v3.2.0.
 *
 *  Local voice reverberation presets.
 */
    [Flags]
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
    [Flags]
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

        /**
     * @since v3.3.0
     *
     * Singing beautifier effect.
     * - If you call \ref IRtcEngine::setVoiceBeautifierPreset "setVoiceBeautifierPreset" (SINGING_BEAUTIFIER), you can beautify a male-sounding voice and add a reverberation
     * effect that sounds like singing in a small room. Agora recommends not using \ref IRtcEngine::setVoiceBeautifierPreset "setVoiceBeautifierPreset" (SINGING_BEAUTIFIER)
     * to process a female-sounding voice; otherwise, you may experience vocal distortion.
     * - If you call \ref IRtcEngine::setVoiceBeautifierParameters "setVoiceBeautifierParameters"(SINGING_BEAUTIFIER, param1, param2), you can beautify a male- or
     * female-sounding voice and add a reverberation effect.
     */
        SINGING_BEAUTIFIER = 0x01020100,

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

        /** A fuller voice.
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
    }

    /** The options for SDK preset audio effects.
 */
    [Flags]
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
     * @note Call \ref IRtcEngine::setAudioProfile "setAudioProfile" and
     * set the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
     * setting this enumerator; otherwise, the enumerator setting does not take effect.
     */
        STYLE_TRANSFORMATION_RNB = 0x02030100,

        /** An audio effect typical of popular music.
     *
     * @note Call \ref IRtcEngine::setAudioProfile "setAudioProfile" and
     * set the `profile` parameter to `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)` before
     * setting this enumerator; otherwise, the enumerator setting does not take effect.
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
    }

    [Flags]
    public enum VOICE_CONVERSION_PRESET
    {
        VOICE_CONVERSION_OFF = 0x00000000,
        VOICE_CHANGER_NEUTRAL = 0x03010100,
        VOICE_CHANGER_SWEET = 0x03010200,
        VOICE_CHANGER_SOLID = 0x03010300,
        VOICE_CHANGER_BASS = 0x03010400
    }

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
        /** 0: The SDK reports this reason when the audio state changes.
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

    /** The remote video frozen type. */
    public enum XLA_REMOTE_VIDEO_FROZEN_TYPE
    {
        /** 0: 500ms video frozen type.
     */
        XLA_REMOTE_VIDEO_FROZEN_500MS = 0,

        /** 1: 200ms video frozen type.
     */
        XLA_REMOTE_VIDEO_FROZEN_200MS = 1,

        /** 2: 600ms video frozen type.
     */
        XLA_REMOTE_VIDEO_FROZEN_600MS = 2,

        /** 3: max video frozen type.
     */
        XLA_REMOTE_VIDEO_FROZEN_TYPE_MAX = 3,
    }

    /** The remote audio frozen type. */
    public enum XLA_REMOTE_AUDIO_FROZEN_TYPE
    {
        /** 0: 80ms audio frozen.
     */
        XLA_REMOTE_AUDIO_FROZEN_80MS = 0,

        /** 1: 200ms audio frozen.
     */
        XLA_REMOTE_AUDIO_FROZEN_200MS = 1,

        /** 2: max audio frozen type.
     */
        XLA_REMOTE_AUDIO_FROZEN_TYPE_MAX = 2,
    }

    /** The reason for the remote video state change. */
    public enum REMOTE_VIDEO_STATE_REASON
    {
        /** 0: The SDK reports this reason when the video state changes.
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

    /** Camera capture preference.
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

        /** 3: Allows you to customize the width and height of the video image captured by the local camera.
      *
      * @since v3.3.0
      */
        CAPTURER_OUTPUT_PREFERENCE_MANUAL = 3,
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

        /** 3: The user is banned by the server. This error occurs when the user is kicked out the channel from the server. */
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

        /** 10: The connection is rejected by server. This error usually occurs in the following situations:
   * - When the user is already in the channel, and still calls the method to join the channel, for example,
   * \ref IRtcEngine::joinChannel "joinChannel".
   * - When the user tries to join a channel during \ref IRtcEngine::startEchoTest "startEchoTest". Once you
   * call \ref IRtcEngine::startEchoTest "startEchoTest", you need to call \ref IRtcEngine::stopEchoTest "stopEchoTest" before joining a channel.
   *
   */
        CONNECTION_CHANGED_REJECTED_BY_SERVER = 10,

        /** 11: The connection changed to reconnecting since SDK has set a proxy server. */
        CONNECTION_CHANGED_SETTING_PROXY_SERVER = 11,

        /** 12: When SDK is in connection failed, the renew token operation will make it connecting. */
        CONNECTION_CHANGED_RENEW_TOKEN = 12,

        /** 13: The IP Address of SDK client has changed. i.e., Network type or IP/Port changed by network operator might change client IP address. */
        CONNECTION_CHANGED_CLIENT_IP_ADDRESS_CHANGED = 13,

        /** 14: Timeout for the keep-alive of the connection between the SDK and Agora's edge server. The connection state changes to CONNECTION_STATE_RECONNECTING(4). */
        CONNECTION_CHANGED_KEEP_ALIVE_TIMEOUT = 14,

        /** 15: In cloud proxy mode, the proxy server connection interrupted. */
        CONNECTION_CHANGED_PROXY_SERVER_INTERRUPTED = 15,
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

        /** 2: The network type is Wi-Fi (including hotspots). */
        NETWORK_TYPE_WIFI = 2,

        /** 3: The network type is mobile 2G. */
        NETWORK_TYPE_MOBILE_2G = 3,

        /** 4: The network type is mobile 3G. */
        NETWORK_TYPE_MOBILE_3G = 4,

        /** 5: The network type is mobile 4G. */
        NETWORK_TYPE_MOBILE_4G = 5,

        NETWORK_TYPE_MOBILE_5G = 6
    }

    /// @cond
    /**
     * The reason for the upload failure.
     *
     * @since v3.3.0
     */
    public enum UPLOAD_ERROR_REASON
    {
        /** 0: The log file is successfully uploaded.
     */
        UPLOAD_SUCCESS = 0,

        /**
     * 1: Network error. Check the network connection and call \ref IRtcEngine::uploadLogFile "uploadLogFile" again to upload the log file.
     */
        UPLOAD_NET_ERROR = 1,

        /**
     * 2: An error occurs in the Agora server. Try uploading the log files later.
     */
        UPLOAD_SERVER_ERROR = 2,
    }

    /// @endcond
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

        /** USB peripheral (macOS only).
     */
        AUDIO_ROUTE_USB = 6,

        /** HDMI peripheral (macOS only).
     */
        AUDIO_ROUTE_HDMI = 7,

        /** DisplayPort peripheral (macOS only).
     */
        AUDIO_ROUTE_DISPLAYPORT = 8,

        /** Apple AirPlay (macOS only).
     */
        AUDIO_ROUTE_AIRPLAY = 9,
    }

    /** The cloud proxy type.
 *
 * @since v3.3.0
 */
    public enum CLOUD_PROXY_TYPE
    {
        /** 0: Do not use the cloud proxy.
   */
        NONE_PROXY = 0,

        /** 1: The cloud proxy for the UDP protocol.
   */
        UDP_PROXY = 1,

        /// @cond
        /** 2: The cloud proxy for the TCP (encrypted) protocol.
         */
        TCP_PROXY = 2,
        /// @endcond
    }

    /** Audio session restriction. */
    [Flags]
    public enum AUDIO_SESSION_OPERATION_RESTRICTION
    {
        /** No restriction, the SDK has full control of the audio session operations. */
        AUDIO_SESSION_OPERATION_RESTRICTION_NONE = 0,

        /** The SDK does not change the audio session category. */
        AUDIO_SESSION_OPERATION_RESTRICTION_SET_CATEGORY = 1,

        /** The SDK does not change any setting of the audio session (category, mode, categoryOptions). */
        AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION = 1 << 1,

        /** The SDK keeps the audio session active when leaving a channel. */
        AUDIO_SESSION_OPERATION_RESTRICTION_DEACTIVATE_SESSION = 1 << 2,

        /** The SDK does not configure the audio session anymore. */
        AUDIO_SESSION_OPERATION_RESTRICTION_ALL = 1 << 7,
    }

    public enum CAMERA_DIRECTION
    {
        /** The rear camera. */
        CAMERA_REAR = 0,

        /** The front camera. */
        CAMERA_FRONT = 1,
    }

    /** The uplink or downlink last-mile network probe test result. */
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

        /** The packet loss rate (%). */
        public uint packetLossRate { set; get; }

        /** The network jitter (ms). */
        public uint jitter { set; get; }

        /* The estimated available bandwidth (bps). */
        public uint availableBandwidth { set; get; }
    }

    /** The uplink and downlink last-mile network probe test result. */
    public class LastmileProbeResult
    {
        public LastmileProbeResult()
        {
        }

        public LastmileProbeResult(LASTMILE_PROBE_RESULT_STATE state, LastmileProbeOneWayResult uplinkReport,
            LastmileProbeOneWayResult downlinkReport, uint rtt)
        {
            this.state = state;
            this.uplinkReport = uplinkReport;
            this.downlinkReport = downlinkReport;
            this.rtt = rtt;
        }

        /** The state of the probe test. */
        public LASTMILE_PROBE_RESULT_STATE state { set; get; }

        /** The uplink last-mile network probe test result. */
        public LastmileProbeOneWayResult uplinkReport { set; get; }

        /** The downlink last-mile network probe test result. */
        public LastmileProbeOneWayResult downlinkReport { set; get; }

        /** The round-trip delay time (ms). */
        public uint rtt { set; get; }
    }

    /** Configurations of the last-mile network probe test. */
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

        /** Sets whether or not to test the uplink network. Some users, for example, the audience in a `LIVE_BROADCASTING` channel, do not need such a test:
		 - true: test.
		 - false: do not test. */
        public bool probeUplink { set; get; }

        /** Sets whether or not to test the downlink network:
		 - true: test.
		 - false: do not test. */
        public bool probeDownlink { set; get; }

        /** The expected maximum sending bitrate (bps) of the local user. The value ranges between 100000 and 5000000. We recommend setting this parameter according to the bitrate value set by \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration". */
        public uint expectedUplinkBitrate { set; get; }

        /** The expected maximum receiving bitrate (bps) of the local user. The value ranges between 100000 and 5000000. */
        public uint expectedDownlinkBitrate { set; get; }
    }

    /** Properties of the audio volume information.
	 An array containing the user ID and volume information for each speaker.
	 */
    public class AudioVolumeInfo
    {
        public AudioVolumeInfo()
        {
        }

        public AudioVolumeInfo(uint uid, uint volume, uint vad, string channelId)
        {
            this.uid = uid;
            this.volume = volume;
            this.vad = vad;
            this.channelId = channelId;
        }

        /**
		 User ID of the speaker. The uid of the local user is 0.
		 */
        public uint uid { set; get; }

        /** The volume of the speaker. The volume ranges between 0 (lowest volume) and 255 (highest volume).
		 */
        public uint volume { set; get; }

        /** Voice activity status of the local user.
     * - `0`: The local user is not speaking.
     * - `1`: The local user is speaking.
     *
     * @note
     * - The `vad` parameter cannot report the voice activity status of remote users.
     * In the remote users' callback, `vad` is always `0`.
     * - To use this parameter, you must set the `report_vad` parameter to `true`
     * when calling \ref agora::rtc::IRtcEngine::enableAudioVolumeIndication(int, int, bool) "enableAudioVolumeIndication".
     */
        public uint vad { set; get; }


        /** The channel ID, which indicates which channel the speaker is in.
		 */
        public string channelId { set; get; }
    }

    /** The detailed options of a user.
 */
    public class ClientRoleOptions
    {
        public ClientRoleOptions()
        {
            audienceLatencyLevel = AUDIENCE_LATENCY_LEVEL_TYPE.AUDIENCE_LATENCY_LEVEL_LOW_LATENCY;
        }

        public ClientRoleOptions(AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel)
        {
            this.audienceLatencyLevel = audienceLatencyLevel;
        }

        /** The latency level of an audience member in interactive live streaming. See #AUDIENCE_LATENCY_LEVEL_TYPE.
     */
        public AUDIENCE_LATENCY_LEVEL_TYPE audienceLatencyLevel;
    }

    /** Statistics of the channel.
	 */
    public class RtcStats
    {
        public RtcStats()
        {
        }

        public RtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes, uint txVideoBytes,
            uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate, ushort rxAudioKBitRate,
            ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate, ushort lastmileDelay,
            ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount, double cpuAppUsage, double cpuTotalUsage,
            int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
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
            this.txPacketLossRate = txPacketLossRate;
            this.rxPacketLossRate = rxPacketLossRate;
            this.userCount = userCount;
            this.cpuAppUsage = cpuAppUsage;
            this.cpuTotalUsage = cpuTotalUsage;
            this.gatewayRtt = gatewayRtt;
            this.memoryAppUsageRatio = memoryAppUsageRatio;
            this.memoryTotalUsageRatio = memoryTotalUsageRatio;
            this.memoryAppUsageInKbytes = memoryAppUsageInKbytes;
        }

        /**
		 Call duration (s), represented by an aggregate value.
		 */
        public uint duration { set; get; }

        /**
		 Total number of bytes transmitted, represented by an aggregate value.
		 */
        public uint txBytes { set; get; }

        /**
		 Total number of bytes received, represented by an aggregate value.
		 */
        public uint rxBytes { set; get; }

        /** Total number of audio bytes sent (bytes), represented
		 * by an aggregate value.
		 */
        public uint txAudioBytes { set; get; }

        /** Total number of video bytes sent (bytes), represented
		 * by an aggregate value.
		 */
        public uint txVideoBytes { set; get; }

        /** Total number of audio bytes received (bytes) before
		 * network countermeasures, represented by an aggregate value.
		 */
        public uint rxAudioBytes { set; get; }

        /** Total number of video bytes received (bytes),
		 * represented by an aggregate value.
		 */
        public uint rxVideoBytes { set; get; }

        /**
		 Transmission bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort txKBitRate { set; get; }

        /**
		 Receive bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort rxKBitRate { set; get; }

        /**
		 Audio receive bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort rxAudioKBitRate { set; get; }

        /**
		 Audio transmission bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort txAudioKBitRate { set; get; }

        /**
		 Video receive bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort rxVideoKBitRate { set; get; }

        /**
		 Video transmission bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort txVideoKBitRate { set; get; }

        /** Client-server latency (ms)
		 */
        public ushort lastmileDelay { set; get; }

        /** The packet loss rate (%) from the local client to Agora's edge server,
		 * before using the anti-packet-loss method.
		 */
        public ushort txPacketLossRate { set; get; }

        /** The packet loss rate (%) from Agora's edge server to the local client,
		 * before using the anti-packet-loss method.
		 */
        public ushort rxPacketLossRate { set; get; }

        /** Number of users in the channel.
		 - `COMMUNICATION` profile: The number of users in the channel.
		 - `LIVE_BROADCASTING` profile:
		     -  If the local user is an audience: The number of users in the channel = The number of hosts in the channel + 1.
		     -  If the user is a host: The number of users in the channel = The number of hosts in the channel.
		 */
        public uint userCount { set; get; }

        /**
		 Application CPU usage (%).
		 */
        public double cpuAppUsage { set; get; }

        /**
		 System CPU usage (%).
		 In the multi-kernel environment, this member represents the average CPU usage.
		 The value **=** 100 **-** System Idle Progress in Task Manager (%).
		 */
        public double cpuTotalUsage { set; get; }

        /** The round-trip time delay from the client to the local router.
		 */
        public int gatewayRtt { set; get; }

        /**
		 The memory usage ratio of the app (%).
		 @note This value is for reference only. Due to system limitations, you may not get the value of this member.
		 */
        public double memoryAppUsageRatio { set; get; }

        /**
		 The memory usage ratio of the system (%).
		 @note This value is for reference only. Due to system limitations, you may not get the value of this member.
		 */
        public double memoryTotalUsageRatio { set; get; }

        /**
		 The memory usage of the app (KB).
		 @note This value is for reference only. Due to system limitations, you may not get the value of this member.
		 */
        public int memoryAppUsageInKbytes { set; get; }
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

    /** Quality of experience (QoE) of the local user when receiving a remote audio stream.
 *
 * @since v3.3.0
 */
    public enum EXPERIENCE_QUALITY_TYPE
    {
        /** 0: QoE of the local user is good.  */
        EXPERIENCE_QUALITY_GOOD = 0,

        /** 1: QoE of the local user is poor.  */
        EXPERIENCE_QUALITY_BAD = 1,
    }

    /**
 * The reason for poor QoE of the local user when receiving a remote audio stream.
 *
 * @since v3.3.0
 */
    public enum EXPERIENCE_POOR_REASON
    {
        /** 0: No reason, indicating good QoE of the local user.
     */
        EXPERIENCE_REASON_NONE = 0,

        /** 1: The remote user's network quality is poor.
     */
        REMOTE_NETWORK_QUALITY_POOR = 1,

        /** 2: The local user's network quality is poor.
     */
        LOCAL_NETWORK_QUALITY_POOR = 2,

        /** 4: The local user's Wi-Fi or mobile network signal is weak.
     */
        WIRELESS_SIGNAL_POOR = 4,

        /** 8: The local user enables both Wi-Fi and bluetooth, and their signals interfere with each other.
     * As a result, audio transmission quality is undermined.
     */
        WIFI_BLUETOOTH_COEXIST = 8,
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

        /** 2: No server response.
     *
     * You can call the
     * \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method to
     * leave the channel.
     *
     * This error can also occur if your project has not enabled co-host token
     * authentication. Contact support@agora.io to enable the co-host token
     * authentication service before starting a channel media relay.
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

        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 12,

        RELAY_EVENT_PAUSE_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 13,

        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_SUCCESS = 14,

        RELAY_EVENT_RESUME_SEND_PACKET_TO_DEST_CHANNEL_FAILED = 15
    }

    /** The state code in CHANNEL_MEDIA_RELAY_STATE. */
    public enum CHANNEL_MEDIA_RELAY_STATE
    {
        /** 0: The initial state. After you successfully stop the channel media
     * relay by calling \ref IRtcEngine::stopChannelMediaRelay "stopChannelMediaRelay",
     * the \ref IRtcEngineEventHandler::onChannelMediaRelayStateChanged "onChannelMediaRelayStateChanged" callback returns this state.
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

    /** Statistics of the local video stream.
	 */
    public class LocalVideoStats
    {
        public LocalVideoStats()
        {
        }

        public LocalVideoStats(int sentBitrate, int sentFrameRate, int encoderOutputFrameRate,
            int rendererOutputFrameRate, int targetBitrate, int targetFrameRate,
            QUALITY_ADAPT_INDICATION qualityAdaptIndication, int encodedBitrate, int encodedFrameWidth,
            int encodedFrameHeight, int encodedFrameCount, VIDEO_CODEC_TYPE codecType, ushort txPacketLossRate,
            int captureFrameRate)
        {
            this.sentBitrate = sentBitrate;
            this.sentFrameRate = sentFrameRate;
            this.encoderOutputFrameRate = encoderOutputFrameRate;
            this.rendererOutputFrameRate = rendererOutputFrameRate;
            this.targetBitrate = targetBitrate;
            this.targetFrameRate = targetFrameRate;
            this.qualityAdaptIndication = qualityAdaptIndication;
            this.encodedBitrate = encodedBitrate;
            this.encodedFrameWidth = encodedFrameWidth;
            this.encodedFrameHeight = encodedFrameHeight;
            this.encodedFrameCount = encodedFrameCount;
            this.codecType = codecType;
            this.txPacketLossRate = txPacketLossRate;
            this.captureFrameRate = captureFrameRate;
        }

        /** Bitrate (Kbps) sent in the reported interval, which does not include
		 * the bitrate of the retransmission video after packet loss.
		 */
        public int sentBitrate { set; get; }

        /** Frame rate (fps) sent in the reported interval, which does not include
		 * the frame rate of the retransmission video after packet loss.
		 */
        public int sentFrameRate { set; get; }

        /** The encoder output frame rate (fps) of the local video.
		 */
        public int encoderOutputFrameRate { set; get; }

        /** The render output frame rate (fps) of the local video.
		 */
        public int rendererOutputFrameRate { set; get; }

        /** The target bitrate (Kbps) of the current encoder. This value is estimated by the SDK based on the current network conditions.
		 */
        public int targetBitrate { set; get; }

        /** The target frame rate (fps) of the current encoder.
		 */
        public int targetFrameRate { set; get; }

        /** Quality change of the local video in terms of target frame rate and
		 * target bit rate in this reported interval. See #QUALITY_ADAPT_INDICATION.
		 */
        public QUALITY_ADAPT_INDICATION qualityAdaptIndication { set; get; }

        /** The encoding bitrate (Kbps), which does not include the bitrate of the
		 * re-transmission video after packet loss.
		 */
        public int encodedBitrate { set; get; }

        /** The width of the encoding frame (px).
		 */
        public int encodedFrameWidth { set; get; }

        /** The height of the encoding frame (px).
		 */
        public int encodedFrameHeight { set; get; }

        /** The value of the sent frames, represented by an aggregate value.
		 */
        public int encodedFrameCount { set; get; }

        /** The codec type of the local video:
		 * - VIDEO_CODEC_VP8 = 1: VP8.
		 * - VIDEO_CODEC_H264 = 2: (Default) H.264.
		 */
        public VIDEO_CODEC_TYPE codecType { set; get; }

        /** The video packet loss rate (%) from the local client to the Agora edge server before applying the anti-packet loss strategies.
		 */
        public ushort txPacketLossRate { set; get; }

        /** The capture frame rate (fps) of the local video.
		 */
        public int captureFrameRate { set; get; }
    }

    /** Statistics of the remote video stream.
	 */
    public class RemoteVideoStats
    {
        public RemoteVideoStats()
        {
        }

        public RemoteVideoStats(uint uid, int delay, int width, int height, int receivedBitrate,
            int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
            REMOTE_VIDEO_STREAM_TYPE rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime,
            int publishDuration)
        {
            this.uid = uid;
            this.delay = delay;
            this.width = width;
            this.height = height;
            this.receivedBitrate = receivedBitrate;
            this.decoderOutputFrameRate = decoderOutputFrameRate;
            this.rendererOutputFrameRate = rendererOutputFrameRate;
            this.packetLossRate = packetLossRate;
            this.rxStreamType = rxStreamType;
            this.totalFrozenTime = totalFrozenTime;
            this.frozenRate = frozenRate;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
        }

        /**
		 User ID of the remote user sending the video streams.
		 */
        public uint uid { set; get; }

        /** **DEPRECATED** Time delay (ms).
		 *
		 * In scenarios where audio and video is synchronized, you can use the value of
		 * `networkTransportDelay` and `jitterBufferDelay` in `RemoteAudioStats` to know the delay statistics of the remote video.
		 */
        public int delay { set; get; }

        /** Width (pixels) of the video stream.
		 */
        public int width { set; get; }

        /**
		 Height (pixels) of the video stream.
		 */
        public int height { set; get; }

        /**
		 Bitrate (Kbps) received since the last count.
		 */
        public int receivedBitrate { set; get; }

        /** The decoder output frame rate (fps) of the remote video.
		 */
        public int decoderOutputFrameRate { set; get; }

        /** The render output frame rate (fps) of the remote video.
		 */
        public int rendererOutputFrameRate { set; get; }

        /** Packet loss rate (%) of the remote video stream after using the anti-packet-loss method.
		 */
        public int packetLossRate { set; get; }

        /** The type of the remote video stream: #REMOTE_VIDEO_STREAM_TYPE
		 */
        public REMOTE_VIDEO_STREAM_TYPE rxStreamType { set; get; }

        /**
		 The total freeze time (ms) of the remote video stream after the remote user joins the channel.
		 In a video session where the frame rate is set to no less than 5 fps, video freeze occurs when
		 the time interval between two adjacent renderable video frames is more than 500 ms.
		 */
        public int totalFrozenTime { set; get; }

        /**
		 The total video freeze time as a percentage (%) of the total time when the video is available.
		 */
        public int frozenRate { set; get; }

        /**
		 The total time (ms) when the remote user in the Communication profile or the remote
		 broadcaster in the Live-broadcast profile neither stops sending the video stream nor
		 disables the video module after joining the channel.
		 @since v3.0.1
		*/
        public int totalActiveTime { set; get; }

        /**
		 * The total publish duration (ms) of the remote video stream.
		 */
        public int publishDuration { set; get; }
    }

    /** Audio statistics of the local user */
    public class LocalAudioStats
    {
        public LocalAudioStats()
        {
        }

        public LocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate, ushort txPacketLossRate)
        {
            this.numChannels = numChannels;
            this.sentSampleRate = sentSampleRate;
            this.sentBitrate = sentBitrate;
            this.txPacketLossRate = txPacketLossRate;
        }

        /** The number of channels.
		 */
        public int numChannels { set; get; }

        /** The sample rate (Hz).
		 */
        public int sentSampleRate { set; get; }

        /** The average sending bitrate (Kbps).
		 */
        public int sentBitrate { set; get; }

        /** The audio packet loss rate (%) from the local client to the Agora edge server before applying the anti-packet loss strategies.
		 */
        public ushort txPacketLossRate { set; get; }
    }

    /** Audio statistics of a remote user */
    public class RemoteAudioStats
    {
        public RemoteAudioStats()
        {
        }

        public RemoteAudioStats(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay,
            int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime,
            int frozenRate, int totalActiveTime, int publishDuration, int qoeQuality, int qualityChangedReason,
            int mosValue)
        {
            this.uid = uid;
            this.quality = quality;
            this.networkTransportDelay = networkTransportDelay;
            this.jitterBufferDelay = jitterBufferDelay;
            this.audioLossRate = audioLossRate;
            this.numChannels = numChannels;
            this.receivedSampleRate = receivedSampleRate;
            this.receivedBitrate = receivedBitrate;
            this.totalFrozenTime = totalFrozenTime;
            this.frozenRate = frozenRate;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
            this.qoeQuality = qoeQuality;
            this.qualityChangedReason = qualityChangedReason;
            this.mosValue = mosValue;
        }

        /** User ID of the remote user sending the audio streams.
		 *
		 */
        public uint uid { set; get; }

        /** Audio quality received by the user: #QUALITY_TYPE.
		 */
        public int quality { set; get; }

        /** Network delay (ms) from the sender to the receiver.
		 */
        public int networkTransportDelay { set; get; }

        /** Network delay (ms) from the receiver to the jitter buffer.
		 */
        public int jitterBufferDelay { set; get; }

        /** The audio frame loss rate in the reported interval.
		 */
        public int audioLossRate { set; get; }

        /** The number of channels.
		 */
        public int numChannels { set; get; }

        /** The sample rate (Hz) of the received audio stream in the reported
		 * interval.
		 */
        public int receivedSampleRate { set; get; }

        /** The average bitrate (Kbps) of the received audio stream in the
		 * reported interval. */
        public int receivedBitrate { set; get; }

        /** The total freeze time (ms) of the remote audio stream after the remote user joins the channel. In a session, audio freeze occurs when the audio frame loss rate reaches 4%.
		 */
        public int totalFrozenTime { set; get; }

        /** The total audio freeze time as a percentage (%) of the total time when the audio is available. */
        public int frozenRate { set; get; }

        /** The total time (ms) when the remote user in the `COMMUNICATION` profile or the remote host in
		 the `LIVE_BROADCASTING` profile neither stops sending the audio stream nor disables the audio module after joining the channel.
		 */
        public int totalActiveTime { set; get; }

        /**
		 * The total publish duration (ms) of the remote audio stream.
		 */
        public int publishDuration { set; get; }

        /**
     * Quality of experience (QoE) of the local user when receiving a remote audio stream. See #EXPERIENCE_QUALITY_TYPE.
     *
     * @since v3.3.0
     */
        public int qoeQuality { set; get; }

        /**
     * The reason for poor QoE of the local user when receiving a remote audio stream. See #EXPERIENCE_POOR_REASON.
     *
     * @since v3.3.0
     */
        public int qualityChangedReason { set; get; }

        /**
     * The mos value of remote audio.
     */
        public int mosValue { set; get; }
    }

    /**
	 * Video dimensions.
	 */
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

        /** Width (pixels) of the video. */
        public int width { set; get; }

        /** Height (pixels) of the video. */
        public int height { set; get; }
    }


    public enum BITRATE
    {
        /** (Recommended) The standard bitrate set in the \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method.

        In this mode, the bitrates differ between the interactive live streaming and communication profiles:

        - `COMMUNICATION` profile: The video bitrate is the same as the base bitrate.
        - `LIVE_BROADCASTING` profile: The video bitrate is twice the base bitrate.

        */
        STANDARD_BITRATE = 0,

        /** The compatible bitrate set in the \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method.
    
     The bitrate remains the same regardless of the channel profile. If you choose this mode in the `LIVE_BROADCASTING` profile, the video frame rate may be lower than the set value.
     */
        COMPATIBLE_BITRATE = -1,

        /** Use the default minimum bitrate.
     */
        DEFAULT_MIN_BITRATE = -1
    }


    /** Video encoder configurations.
	 */
    public class VideoEncoderConfiguration
    {
        public VideoEncoderConfiguration()
        {
            dimensions = null;
            frameRate = FRAME_RATE.FRAME_RATE_FPS_15;
            minBitrate = -1;
            bitrate = (int) BITRATE.STANDARD_BITRATE;
            minBitrate = (int) BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public VideoEncoderConfiguration(VideoDimensions dimensions,
            FRAME_RATE frameRate = FRAME_RATE.FRAME_RATE_FPS_15, int minFrameRate = -1,
            BITRATE bitrate = BITRATE.STANDARD_BITRATE, BITRATE minBitrate = BITRATE.DEFAULT_MIN_BITRATE,
            ORIENTATION_MODE orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE,
            DEGRADATION_PREFERENCE degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            this.dimensions = dimensions ?? new VideoDimensions();
            this.frameRate = frameRate;
            this.minFrameRate = minFrameRate;
            this.bitrate = (int) bitrate;
            this.minBitrate = (int) minBitrate;
            this.orientationMode = orientationMode;
            this.degradationPreference = degradationPreference;
            this.mirrorMode = mirrorMode;
        }

        public VideoEncoderConfiguration(int width, int height, FRAME_RATE frameRate = FRAME_RATE.FRAME_RATE_FPS_15,
            int minFrameRate = -1, BITRATE bitrate = BITRATE.STANDARD_BITRATE,
            BITRATE minBitrate = BITRATE.DEFAULT_MIN_BITRATE,
            ORIENTATION_MODE orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE,
            DEGRADATION_PREFERENCE degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            dimensions = new VideoDimensions(width, height);
            this.frameRate = frameRate;
            this.minFrameRate = minFrameRate;
            this.bitrate = (int) bitrate;
            this.minBitrate = (int) minBitrate;
            this.orientationMode = orientationMode;
            this.degradationPreference = degradationPreference;
            this.mirrorMode = mirrorMode;
        }

        /** The video frame dimensions (px) used to specify the video quality and measured by the total number of pixels along a frame's width and height: VideoDimensions. The default value is 640 x 360.
		 */
        public VideoDimensions dimensions { set; get; }

        /** The frame rate of the video: #FRAME_RATE. The default value is 15.
		 Note that we do not recommend setting this to a value greater than 30.
		 */
        public FRAME_RATE frameRate { set; get; }

        /** The minimum frame rate of the video. The default value is -1.
		 */
        public int minFrameRate { set; get; }

        /** The video encoding bitrate (Kbps).
		 Choose one of the following options:
		 - #STANDARD_BITRATE: (Recommended) The standard bitrate.
		    - the `COMMUNICATION` profile: the encoding bitrate equals the base bitrate.
		    - the `LIVE_BROADCASTING` profile: the encoding bitrate is twice the base bitrate.
		 - #COMPATIBLE_BITRATE: The compatible bitrate: the bitrate stays the same regardless of the profile.
		 the `COMMUNICATION` profile prioritizes smoothness, while the `LIVE_BROADCASTING` profile prioritizes video quality (requiring a higher bitrate). We recommend setting the bitrate mode as #STANDARD_BITRATE to address this difference.
		 The following table lists the recommended video encoder configurations, where the base bitrate applies to the `COMMUNICATION` profile. Set your bitrate based on this table. If you set a bitrate beyond the proper range, the SDK automatically sets it to within the range.
		 @note
		 In the following table, **Base Bitrate** applies to the `COMMUNICATION` profile, and **Live Bitrate** applies to the `LIVE_BROADCASTING` profile.
		 | Resolution             | Frame Rate (fps) | Base Bitrate (Kbps)                    | Live Bitrate (Kbps)                    |
		 |------------------------|------------------|----------------------------------------|----------------------------------------|
		 | 160 * 120              | 15               | 65                                     | 130                                    |
		 | 120 * 120              | 15               | 50                                     | 100                                    |
		 | 320 * 180              | 15               | 140                                    | 280                                    |
		 | 180 * 180              | 15               | 100                                    | 200                                    |
		 | 240 * 180              | 15               | 120                                    | 240                                    |
		 | 320 * 240              | 15               | 200                                    | 400                                    |
		 | 240 * 240              | 15               | 140                                    | 280                                    |
		 | 424 * 240              | 15               | 220                                    | 440                                    |
		 | 640 * 360              | 15               | 400                                    | 800                                    |
		 | 360 * 360              | 15               | 260                                    | 520                                    |
		 | 640 * 360              | 30               | 600                                    | 1200                                   |
		 | 360 * 360              | 30               | 400                                    | 800                                    |
		 | 480 * 360              | 15               | 320                                    | 640                                    |
		 | 480 * 360              | 30               | 490                                    | 980                                    |
		 | 640 * 480              | 15               | 500                                    | 1000                                   |
		 | 480 * 480              | 15               | 400                                    | 800                                    |
		 | 640 * 480              | 30               | 750                                    | 1500                                   |
		 | 480 * 480              | 30               | 600                                    | 1200                                   |
		 | 848 * 480              | 15               | 610                                    | 1220                                   |
		 | 848 * 480              | 30               | 930                                    | 1860                                   |
		 | 640 * 480              | 10               | 400                                    | 800                                    |
		 | 1280 * 720             | 15               | 1130                                   | 2260                                   |
		 | 1280 * 720             | 30               | 1710                                   | 3420                                   |
		 | 960 * 720              | 15               | 910                                    | 1820                                   |
		 | 960 * 720              | 30               | 1380                                   | 2760                                   |
		 | 1920 * 1080            | 15               | 2080                                   | 4160                                   |
		 | 1920 * 1080            | 30               | 3150                                   | 6300                                   |
		 | 1920 * 1080            | 60               | 4780                                   | 6500                                   |
		 | 2560 * 1440            | 30               | 4850                                   | 6500                                   |
		 | 2560 * 1440            | 60               | 6500                                   | 6500                                   |
		 | 3840 * 2160            | 30               | 6500                                   | 6500                                   |
		 | 3840 * 2160            | 60               | 6500                                   | 6500                                   |
		 */
        public int bitrate { set; get; }

        /** The minimum encoding bitrate (Kbps).
		 The SDK automatically adjusts the encoding bitrate to adapt to the network conditions. Using a value greater than the default value forces the video encoder to output high-quality images but may cause more packet loss and hence sacrifice the smoothness of the video transmission. That said, unless you have special requirements for image quality, Agora does not recommend changing this value.
		 @note This parameter applies only to the `LIVE_BROADCASTING` profile.
		 */
        public int minBitrate { set; get; }

        /** The video orientation mode of the video: #ORIENTATION_MODE.
		 */
        public ORIENTATION_MODE orientationMode { set; get; }

        /** The video encoding degradation preference under limited bandwidth: #DEGRADATION_PREFERENCE.
		 */
        public DEGRADATION_PREFERENCE degradationPreference { set; get; }

        /** Sets the mirror mode of the published local video stream. It only affects the video that the remote user sees. See #VIDEO_MIRROR_MODE_TYPE
		 @note: The SDK disables the mirror mode by default.
		 */
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }
    }

    /** Audio recording configurations.
 */
    public class AudioRecordingConfiguration
    {
        public AudioRecordingConfiguration()
        {
            filePath = null;
            recordingQuality = AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_MEDIUM;
            recordingPosition = AUDIO_RECORDING_POSITION.AUDIO_RECORDING_POSITION_MIXED_RECORDING_AND_PLAYBACK;
            recordingSampleRate = 32000;
        }

        public AudioRecordingConfiguration(string filePath, AUDIO_RECORDING_QUALITY_TYPE recordingQuality,
            AUDIO_RECORDING_POSITION recordingPosition, int recordingSampleRate)
        {
            this.filePath = filePath;
            this.recordingQuality = recordingQuality;
            this.recordingPosition = recordingPosition;
            this.recordingSampleRate = recordingSampleRate;
        }

        /** Pointer to the absolute file path of the recording file. The string of the file name is in UTF-8.

   The SDK determines the storage format of the recording file by the file name suffix:

   - .wav: Large file size with high fidelity.
   - .aac: Small file size with low fidelity.

   Ensure that the directory to save the recording file exists and is writable.
   */
        public string filePath { set; get; }

        /** Sets the audio recording quality. See #AUDIO_RECORDING_QUALITY_TYPE.

   @note It is effective only when the recording format is AAC.
   */
        public AUDIO_RECORDING_QUALITY_TYPE recordingQuality { set; get; }

        /** Sets the audio recording position. See #AUDIO_RECORDING_POSITION.
   */
        public AUDIO_RECORDING_POSITION recordingPosition { set; get; }

        /** Sets the sample rate (Hz) of the recording file. Supported values are as follows:
         * - 16000
         * - (Default) 32000
         * - 44100
         * - 48000
         */
        public int recordingSampleRate { set; get; }
    }

    /** Audio recording position. */
    public enum AUDIO_RECORDING_POSITION
    {
        /** The SDK will record the voices of all users in the channel. */
        AUDIO_RECORDING_POSITION_MIXED_RECORDING_AND_PLAYBACK = 0,

        /** The SDK will record the voice of the local user. */
        AUDIO_RECORDING_POSITION_RECORDING = 1,

        /** The SDK will record the voices of remote users. */
        AUDIO_RECORDING_POSITION_MIXED_PLAYBACK = 2,
    };

    /** The video and audio properties of the user displaying the video in the CDN live. Agora supports a maximum of 17 transcoding users in a CDN streaming channel.
	 */
    public class TranscodingUser
    {
        public TranscodingUser()
        {
            alpha = 1.0;
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

        /** User ID of the user displaying the video in the CDN live.
		 */
        public uint uid { set; get; }

        /** Horizontal position (pixel) of the video frame relative to the top left corner.
		 */
        public int x { set; get; }

        /** Vertical position (pixel) of the video frame relative to the top left corner.
		 */
        public int y { set; get; }

        /** Width (pixel) of the video frame. The default value is 360.
		 */
        public int width { set; get; }

        /** Height (pixel) of the video frame. The default value is 640.
		 */
        public int height { set; get; }

        /** The layer index of the video frame. An integer. The value range is [0, 100].
		 - 0: (Default) Bottom layer.
		 - 100: Top layer.
		 @note
		 - If zOrder is beyond this range, the SDK reports #ERR_INVALID_ARGUMENT.
		 - As of v2.3, the SDK supports zOrder = 0.
		 */
        public int zOrder { set; get; }

        /** The transparency level of the user's video. The value ranges between 0 and 1.0:
		 - 0: Completely transparent
		 - 1.0: (Default) Opaque
		 */
        public double alpha { set; get; }

        /** The audio channel of the sound. The default value is 0:
		 - 0: (Default) Supports dual channels at most, depending on the upstream of the host.
		 - 1: The audio stream of the host uses the FL audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - 2: The audio stream of the host uses the FC audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - 3: The audio stream of the host uses the FR audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - 4: The audio stream of the host uses the BL audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - 5: The audio stream of the host uses the BR audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - `0xFF` or a value greater than `5`: The host's audio is muted. The Agora server removes the host's audio.
		 
		 @note If your setting is not 0, you may need a specialized player.
		 */
        public int audioChannel { set; get; }
    }

    /** Image properties.
	 The properties of the watermark and background images.
	 */
    public class RtcImage
    {
        public RtcImage()
        {
        }

        public RtcImage(string url, int x, int y, int width, int height)
        {
            this.url = url;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /** HTTP/HTTPS URL address of the image on the live video. The maximum length of this parameter is 1024 bytes. */
        public string url { set; get; }

        /** Horizontal position of the image from the upper left of the live video. */
        public int x { set; get; }

        /** Vertical position of the image from the upper left of the live video. */
        public int y { set; get; }

        /** Width of the image on the live video. */
        public int width { set; get; }

        /** Height of the image on the live video. */
        public int height { set; get; }
    }


    /** The configuration for advanced features of the RTMP streaming with transcoding.
	 */
    public class LiveStreamAdvancedFeature
    {
        public LiveStreamAdvancedFeature()
        {
            LBHQ = "lbhq";
            VEO = "veo";
        }

        public LiveStreamAdvancedFeature(string featureName, bool opened = false)
        {
            LBHQ = "lbhq";
            VEO = "veo";
            this.featureName = featureName;
            this.opened = opened;
        }

        /** The advanced feature for high-quality video with a lower bitrate. */
        public string LBHQ { set; get; }

        /** The advanced feature for the optimized video encoder. */
        public string VEO { set; get; }

        /** The name of the advanced feature. It contains LBHQ and VEO.
		 */
        public string featureName { set; get; }

        /** Whether to enable the advanced feature:
		 * - true: Enable the advanced feature.
		 * - false: (Default) Disable the advanced feature.
		 */
        public bool opened { set; get; }
    }


    /** A class for managing CDN live audio/video transcoding settings.
	 */
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
            watermark = null;
            backgroundImage = null;
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
            string transcodingExtraInfo, string metadata, RtcImage watermark, RtcImage backgroundImage,
            AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels,
            AUDIO_CODEC_PROFILE_TYPE audioCodecProfile, LiveStreamAdvancedFeature[] advancedFeatures,
            uint advancedFeatureCount)
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
            this.backgroundImage = backgroundImage;
            this.audioSampleRate = audioSampleRate;
            this.audioBitrate = audioBitrate;
            this.audioChannels = audioChannels;
            this.audioCodecProfile = audioCodecProfile;
            this.advancedFeatures = advancedFeatures;
            this.advancedFeatureCount = advancedFeatureCount;
        }

        /** The width of the video in pixels. The default value is 360.
		 * - When pushing video streams to the CDN, ensure that `width` is at least 64; otherwise, the Agora server adjusts the value to 64.
		 * - When pushing audio streams to the CDN, set `width` and `height` as 0.
		 */
        public int width { set; get; }

        /** The height of the video in pixels. The default value is 640.
		 * - When pushing video streams to the CDN, ensure that `height` is at least 64; otherwise, the Agora server adjusts the value to 64.
		 * - When pushing audio streams to the CDN, set `width` and `height` as 0.
		 */
        public int height { set; get; }

        /** Bitrate of the CDN live output video stream. The default value is 400 Kbps.
		 Set this parameter according to the Video Bitrate Table. If you set a bitrate beyond the proper range, the SDK automatically adapts it to a value within the range.
		 */
        public int videoBitrate { set; get; }

        /** Frame rate of the output video stream set for the CDN live streaming. The default value is 15 fps, and the value range is (0,30].
		 @note The Agora server adjusts any value over 30 to 30.
		 */
        public int videoFramerate { set; get; }

        /** **DEPRECATED** Latency mode:
		 - true: Low latency with unassured quality.
		 - false: (Default) High latency with assured quality.
		 */
        public bool lowLatency { set; get; }

        /** Video GOP in frames. The default value is 30 fps.
		 */
        public int videoGop { set; get; }

        /** Self-defined video codec profile: #VIDEO_CODEC_PROFILE_TYPE.
		 @note If you set this parameter to other values, Agora adjusts it to the default value of 100.
		 */
        public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile { set; get; }

        /** The background color in RGB hex value. Value only. Do not include a preceeding #. For example, 0xFFB6C1 (light pink). The default value is 0x000000 (black).
		 */
        public uint backgroundColor { set; get; }

        /** video codec type */
        public VIDEO_CODEC_TYPE_FOR_STREAM videoCodecType { set; get; }

        /** The number of users in the live interactive streaming.
		 */
        public uint userCount { set; get; }

        /** TranscodingUser
		 */
        public TranscodingUser[] transcodingUsers { set; get; }

        /** Reserved property. Extra user-defined information to send SEI for the H.264/H.265 video stream to the CDN live client. Maximum length: 4096 Bytes.
		 For more information on SEI frame, see [SEI-related questions](https://docs.agora.io/en/faq/sei).
		 */
        public string transcodingExtraInfo { set; get; }

        /** **DEPRECATED** The metadata sent to the CDN live client defined by the RTMP or HTTP-FLV metadata.
		 */
        public string metadata { set; get; }

        /** The watermark image added to the CDN live publishing stream.
		 Ensure that the format of the image is PNG. Once a watermark image is added, the audience of the CDN live publishing stream can see the watermark image. See RtcImage.
		 */
        public RtcImage watermark { set; get; }

        /** The background image added to the CDN live publishing stream.
		 Once a background image is added, the audience of the CDN live publishing stream can see the background image. See RtcImage.
		 */
        public RtcImage backgroundImage { set; get; }

        /** Self-defined audio-sample rate: #AUDIO_SAMPLE_RATE_TYPE.
		 */
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        /** Bitrate of the CDN live audio output stream. The default value is 48 Kbps, and the highest value is 128.
		 */
        public int audioBitrate { set; get; }

        /** The numbder of audio channels for the CDN live stream. Agora recommends choosing 1 (mono), or 2 (stereo) audio channels. Special players are required if you choose option 3, 4, or 5:
		 - 1: (Default) Mono.
		 - 2: Stereo.
		 - 3: Three audio channels.
		 - 4: Four audio channels.
		 - 5: Five audio channels.
		 */
        public int audioChannels { set; get; }

        /** Self-defined audio codec profile: #AUDIO_CODEC_PROFILE_TYPE.
		 */
        public AUDIO_CODEC_PROFILE_TYPE audioCodecProfile { set; get; }

        /** Advanced features of the RTMP streaming with transcoding. See LiveStreamAdvancedFeature.
		 *
		 * @since v3.1.0
		 */
        public LiveStreamAdvancedFeature[] advancedFeatures { set; get; }

        /** The number of enabled advanced features. The default value is 0. */
        public uint advancedFeatureCount { set; get; }
    }

    /** Camera capturer configuration.
	 */
    public class CameraCapturerConfiguration
    {
        public CameraCapturerConfiguration()
        {
            preference = CAPTURER_OUTPUT_PREFERENCE.CAPTURER_OUTPUT_PREFERENCE_AUTO;
            captureWidth = 640;
            captureHeight = 480;
            cameraDirection = null;
        }

        public CameraCapturerConfiguration(int captureWidth, int captureHeight,
            CAMERA_DIRECTION? cameraDirection = null)
        {
            preference = CAPTURER_OUTPUT_PREFERENCE.CAPTURER_OUTPUT_PREFERENCE_MANUAL;
            this.captureWidth = captureWidth;
            this.captureHeight = captureHeight;
            this.cameraDirection = cameraDirection;
        }

        public CameraCapturerConfiguration(CAPTURER_OUTPUT_PREFERENCE preference, int captureWidth, int captureHeight,
            CAMERA_DIRECTION? cameraDirection = null)
        {
            this.preference = preference;
            this.captureWidth = captureWidth;
            this.captureHeight = captureHeight;
            this.cameraDirection = cameraDirection;
        }

        /** Camera capturer preference settings. See: #CAPTURER_OUTPUT_PREFERENCE. */
        public CAPTURER_OUTPUT_PREFERENCE preference { set; get; }

        /** The width (px) of the video image captured by the local camera.
      * To customize the width of the video image, set `preference` as #CAPTURER_OUTPUT_PREFERENCE_MANUAL (3) first,
      * and then use `captureWidth`.
      *
      * @since v3.3.0
      */
        int captureWidth { set; get; }

        /** The height (px) of the video image captured by the local camera.
      * To customize the height of the video image, set `preference` as #CAPTURER_OUTPUT_PREFERENCE_MANUAL (3) first,
      * and then use `captureHeight`.
      *
      * @since v3.3.0
      */
        int captureHeight { set; get; }

        /** Camera direction settings (for Android/iOS only). See: #CAMERA_DIRECTION. */
        CAMERA_DIRECTION? cameraDirection { set; get; }
    }

    /** The configurations for the data stream.
 *
 * @since v3.3.0
 *
 * |`syncWithAudio` |`ordered`| SDK behaviors|
 * |--------------|--------|-------------|
 * | false   |  false   |The SDK triggers the `onStreamMessage` callback immediately after the receiver receives a data packet      |
 * | true |  false | <p>If the data packet delay is within the audio delay, the SDK triggers the `onStreamMessage` callback when the synchronized audio packet is played out.</p><p>If the data packet delay exceeds the audio delay, the SDK triggers the `onStreamMessage` callback as soon as the data packet is received. In this case, the data packet is not synchronized with the audio packet.</p>   |
 * | false  |  true | <p>If the delay of a data packet is within five seconds, the SDK corrects the order of the data packet.</p><p>If the delay of a data packet exceeds five seconds, the SDK discards the data packet.</p>     |
 * |  true  |  true   | <p>If the delay of a data packet is within the audio delay, the SDK corrects the order of the data packet.</p><p>If the delay of a data packet exceeds the audio delay, the SDK discards this data packet.</p>     |
 */
    public class DataStreamConfig
    {
        public DataStreamConfig()
        {
        }

        public DataStreamConfig(bool syncWithAudio, bool ordered)
        {
            this.syncWithAudio = syncWithAudio;
            this.ordered = ordered;
        }

        /** Whether to synchronize the data packet with the published audio packet.
     *
     * - true: Synchronize the data packet with the audio packet.
     * - false: Do not synchronize the data packet with the audio packet.
     *
     * When you set the data packet to synchronize with the audio, then if the data
     * packet delay is within the audio delay, the SDK triggers the `onStreamMessage` callback when
     * the synchronized audio packet is played out. Do not set this parameter as `true` if you
     * need the receiver to receive the data packet immediately. Agora recommends that you set
     * this parameter to `true` only when you need to implement specific functions, for example
     * lyric synchronization.
     */
        public bool syncWithAudio { set; get; }

        /** Whether the SDK guarantees that the receiver receives the data in the sent order.
     *
     * - true: Guarantee that the receiver receives the data in the sent order.
     * - false: Do not guarantee that the receiver receives the data in the sent order.
     *
     * Do not set this parameter to `true` if you need the receiver to receive the data immediately.
     */
        public bool ordered { set; get; }
    }

    /** Configuration of the injected media stream.
	 */
    public class InjectStreamConfig
    {
        public InjectStreamConfig()
        {
            width = 0;
            height = 0;
            videoGop = 30;
            videoFramerate = 15;
            videoBitrate = 400;
            audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            audioBitrate = 48;
            audioChannels = 1;
        }

        public InjectStreamConfig(int width, int height, int videoGop, int videoFramerate, int videoBitrate,
            AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels)
        {
            this.width = width;
            this.height = height;
            this.videoGop = videoGop;
            this.videoFramerate = videoFramerate;
            this.videoBitrate = videoBitrate;
            this.audioSampleRate = audioSampleRate;
            this.audioBitrate = audioBitrate;
            this.audioChannels = audioChannels;
        }

        /** Width of the injected stream in the live interactive streaming. The default value is 0 (same width as the original stream).
		 */
        public int width { set; get; }

        /** Height of the injected stream in the live interactive streaming. The default value is 0 (same height as the original stream).
		 */
        public int height { set; get; }

        /** Video GOP (in frames) of the injected stream in the live interactive streaming. The default value is 30 fps.
		 */
        public int videoGop { set; get; }

        /** Video frame rate of the injected stream in the live interactive streaming. The default value is 15 fps.
		 */
        public int videoFramerate { set; get; }

        /** Video bitrate of the injected stream in the live interactive streaming. The default value is 400 Kbps.
		 @note The setting of the video bitrate is closely linked to the resolution. If the video bitrate you set is beyond a reasonable range, the SDK sets it within a reasonable range.
		 */
        public int videoBitrate { set; get; }

        /** Audio-sample rate of the injected stream in the live interactive streaming: #AUDIO_SAMPLE_RATE_TYPE. The default value is 48000 Hz.
		 @note We recommend setting the default value.
		 */
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        /** Audio bitrate of the injected stream in the live interactive streaming. The default value is 48.
		 @note We recommend setting the default value.
		 */
        public int audioBitrate { set; get; }

        /** Audio channels in the live interactive streaming.
		 - 1: (Default) Mono
		 - 2: Two-channel stereo
		 @note We recommend setting the default value.
		 */
        public int audioChannels { set; get; }
    }

    /** The definition of ChannelMediaInfo.
	 */
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

        /** The channel name.
		 */
        public string channelName { set; get; }

        /** The token that enables the user to join the channel.
		 */
        public string token { set; get; }

        /** The user ID.
		 */
        public uint uid { set; get; }
    }

    /** The definition of ChannelMediaRelayConfiguration.
	 */
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

        /** Pointer to the information of the source channel: ChannelMediaInfo. It contains the following members:
		 * - `channelName`: The name of the source channel. The default value is `NULL`, which means the SDK applies the name of the current channel.
		 * - `uid`: ID of the host whose media stream you want to relay. The default value is 0, which means the SDK generates a random UID. You must set it as 0.
		 * - `token`: The token for joining the source channel. It is generated with the `channelName` and `uid` you set in `srcInfo`.
		 *   - If you have not enabled the App Certificate, set this parameter as the default value `NULL`, which means the SDK applies the App ID.
		 *   - If you have enabled the App Certificate, you must use the `token` generated with the `channelName` and `uid`, and the `uid` must be set as 0.
		 */
        public ChannelMediaInfo srcInfo { set; get; }

        /** Pointer to the information of the destination channel: ChannelMediaInfo. It contains the following members:
		 * - `channelName`: The name of the destination channel.
		 * - `uid`: ID of the host in the destination channel. The value ranges from 0 to (2<sup>32</sup>-1). To avoid UID conflicts, this `uid` must be different from any other UIDs in the destination channel. The default value is 0, which means the SDK generates a random UID.
		 * - `token`: The token for joining the destination channel. It is generated with the `channelName` and `uid` you set in `destInfos`.
		 *   - If you have not enabled the App Certificate, set this parameter as the default value `NULL`, which means the SDK applies the App ID.
		 *   - If you have enabled the App Certificate, you must use the `token` generated with the `channelName` and `uid`.
		 */
        public ChannelMediaInfo[] destInfos { set; get; }

        /** The number of destination channels. The default value is 0, and the
		 * value range is [0,4). Ensure that the value of this parameter
		 * corresponds to the number of ChannelMediaInfo classs you define in
		 * `destInfos`.
		 */
        public int destCount { set; get; }
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
        CONTENT_HINT_NONE,

        /** Motion-intensive content. Choose this option if you prefer smoothness or when you are sharing a video clip, movie, or video game.
     */
        CONTENT_HINT_MOTION,

        /** Motionless content. Choose this option if you prefer sharpness or when you are sharing a picture, PowerPoint slide, or text.
     */
        CONTENT_HINT_DETAILS
    }

    /** The relative location of the region to the screen or window.
	 */
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

        /** The horizontal offset from the top-left corner.
		 */
        public int x { set; get; }

        /** The vertical offset from the top-left corner.
		 */
        public int y { set; get; }

        /** The width of the region.
		 */
        public int width { set; get; }

        /** The height of the region.
		 */
        public int height { set; get; }
    }

    /**  **DEPRECATED** Definition of the rectangular region. */
    [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, false)]
    public class Rect
    {
        public Rect()
        {
        }

        public Rect(int top, int left, int bottom, int right)
        {
            this.top = top;
            this.left = left;
            this.bottom = bottom;
            this.right = right;
        }

        /** Y-axis of the top line.
		 */
        public int top { set; get; }

        /** X-axis of the left line.
		 */
        public int left { set; get; }

        /** Y-axis of the bottom line.
		 */
        public int bottom { set; get; }

        /** X-axis of the right line.
		 */
        public int right { set; get; }
    }

    /** The options of the watermark image to be added. */
    public class WatermarkOptions
    {
        public WatermarkOptions()
        {
            visibleInPreview = true;
            positionInLandscapeMode = new Rectangle();
            positionInPortraitMode = new Rectangle();
        }

        public WatermarkOptions(bool visibleInPreview, Rectangle positionInLandscapeMode,
            Rectangle positionInPortraitMode)
        {
            this.visibleInPreview = visibleInPreview;
            this.positionInLandscapeMode = positionInLandscapeMode ?? new Rectangle();
            this.positionInPortraitMode = positionInPortraitMode ?? new Rectangle();
        }

        /** Sets whether or not the watermark image is visible in the local video preview:
		 * - true: (Default) The watermark image is visible in preview.
		 * - false: The watermark image is not visible in preview.
		 */
        public bool visibleInPreview { set; get; }

        /**
		 * The watermark position in the landscape mode. See Rectangle.
		 * For detailed information on the landscape mode, see the advanced guide *Video Rotation*.
		 */
        public Rectangle positionInLandscapeMode { set; get; }

        /**
		 * The watermark position in the portrait mode. See Rectangle.
		 * For detailed information on the portrait mode, see the advanced guide *Video Rotation*.
		 */
        public Rectangle positionInPortraitMode { set; get; }
    }

    /** Screen sharing encoding parameters.
	 */
    public class ScreenCaptureParameters
    {
        public ScreenCaptureParameters()
        {
            dimensions = new VideoDimensions(1920, 1080);
            frameRate = 5;
            bitrate = (int) BITRATE.STANDARD_BITRATE;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = new view_t[0];
            excludeWindowCount = 0;
        }

        public ScreenCaptureParameters(int width, int height, int frameRate, BITRATE bitrate, bool captureMouseCursor,
            bool windowFocus, view_t[] excludeWindowList = null, int excludeWindowCount = 0)
        {
            dimensions = new VideoDimensions(width, height);
            this.frameRate = frameRate;
            this.bitrate = (int) bitrate;
            this.captureMouseCursor = captureMouseCursor;
            this.windowFocus = windowFocus;
            this.excludeWindowList = excludeWindowList ?? new view_t[0];
            this.excludeWindowCount = excludeWindowCount;
        }

        public ScreenCaptureParameters(VideoDimensions dimensions, int frameRate, BITRATE bitrate,
            bool captureMouseCursor, bool windowFocus, view_t[] excludeWindowList = null, int excludeWindowCount = 0)
        {
            this.dimensions = dimensions;
            this.frameRate = frameRate;
            this.bitrate = (int) bitrate;
            this.captureMouseCursor = captureMouseCursor;
            this.windowFocus = windowFocus;
            this.excludeWindowList = excludeWindowList ?? new view_t[0];
            this.excludeWindowCount = excludeWindowCount;
        }

        /** The maximum encoding dimensions of the shared region in terms of width * height.
		 The default value is 1920 * 1080 pixels, that is, 2073600 pixels. Agora uses the value of this parameter to calculate the charges.
		 If the aspect ratio is different between the encoding dimensions and screen dimensions, Agora applies the following algorithms for encoding. Suppose the encoding dimensions are 1920 x 1080:
		 - If the value of the screen dimensions is lower than that of the encoding dimensions, for example, 1000 * 1000, the SDK uses 1000 * 1000 for encoding.
		 - If the value of the screen dimensions is higher than that of the encoding dimensions, for example, 2000 * 1500, the SDK uses the maximum value under 1920 * 1080 with the aspect ratio of the screen dimension (4:3) for encoding, that is, 1440 * 1080.
		 */
        public VideoDimensions dimensions { set; get; }

        /** The frame rate (fps) of the shared region.
		 The default value is 5. We do not recommend setting this to a value greater than 15.
		 */
        public int frameRate { set; get; }

        /** The bitrate (Kbps) of the shared region.
		 The default value is 0 (the SDK works out a bitrate according to the dimensions of the current screen).
		 */
        public int bitrate { set; get; }

        /** Sets whether or not to capture the mouse for screen sharing:
		 - true: (Default) Capture the mouse.
		 - false: Do not capture the mouse.
		 */
        public bool captureMouseCursor { set; get; }

        /** Whether to bring the window to the front when calling \ref IRtcEngine::startScreenCaptureByWindowId "startScreenCaptureByWindowId" to share the window:
		 * - true: Bring the window to the front.
		 * - false: (Default) Do not bring the window to the front.
		 */
        public bool windowFocus { set; get; }

        /** A list of IDs of windows to be blocked.
		 *
		 * When calling \ref IRtcEngine::startScreenCaptureByScreenRect "startScreenCaptureByScreenRect" to start screen sharing, you can use this parameter to block the specified windows.
		 * When calling \ref IRtcEngine::updateScreenCaptureParameters "updateScreenCaptureParameters" to update the configuration for screen sharing, you can use this parameter to dynamically block the specified windows during screen sharing.
		 */
        public view_t[] excludeWindowList { set; get; }

        /** The number of windows to be blocked.
		 */
        public int excludeWindowCount { set; get; }
    }

    /** Video display settings of the VideoCanvas class.
	 */
    public class VideoCanvas
    {
        public VideoCanvas()
        {
            view = 0;
            renderMode = (int) RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
            channelId = "";
            uid = 0;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public VideoCanvas(view_t? view, RENDER_MODE_TYPE renderMode, string channelId = "", uint uid = 0,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            this.view = view ?? 0;
            this.renderMode = (int) renderMode;
            this.channelId = channelId;
            this.uid = uid;
            this.mirrorMode = mirrorMode;
        }

        /** Video display window (view).
		 */
        public view_t view { set; get; }

        /** The rendering mode of the video view. See RENDER_MODE_TYPE
		 */
        public int renderMode { set; get; }

        /** The unique channel name for the AgoraRTC session in the string format. The string length must be less than 64 bytes. Supported character scopes are:
		 - All lowercase English letters: a to z.
		 - All uppercase English letters: A to Z.
		 - All numeric characters: 0 to 9.
		 - The space character.
		 - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
		 @note
		 - The default value is the empty string "". Use the default value if the user joins the channel using the \ref IRtcEngine::joinChannel "joinChannel" method in the IRtcEngine class. The `VideoCanvas` class defines the video canvas of the user in the channel.
		 - If the user joins the channel using the \ref IRtcEngine::joinChannel "joinChannel" method in the IChannel class, set this parameter as the `channelId` of the `IChannel` object. The `VideoCanvas` class defines the video canvas of the user in the channel with the specified channel ID.
		 */
        // TODO: Check if `VideoCanvas.channdlId` works when defined as a string type.
        public string channelId { set; get; }

        /** The user ID. */
        public uint uid { set; get; }

        /** The mirror mode of the video view. See VIDEO_MIRROR_MODE_TYPE
		 @note
		 - For the mirror mode of the local video view: If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.
		 - For the mirror mode of the remote video view: The SDK disables the mirror mode by default.
		*/
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }
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

    /** Image enhancement options.
	 */
    public class BeautyOptions
    {
        public BeautyOptions()
        {
            lighteningContrastLevel = LIGHTENING_CONTRAST_LEVEL.LIGHTENING_CONTRAST_NORMAL;
        }

        public BeautyOptions(
            LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel, float lighteningLevel, float smoothnessLevel,
            float rednessLevel)
        {
            this.lighteningContrastLevel = lighteningContrastLevel;
            this.lighteningLevel = lighteningLevel;
            this.smoothnessLevel = smoothnessLevel;
            this.rednessLevel = rednessLevel;
        }

        /** The contrast level, used with the @p lightening parameter.
		 */
        public LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel { set; get; }

        /** The brightness level. The value ranges from 0.0 (original) to 1.0. */
        public float lighteningLevel { set; get; }

        /** The sharpness level. The value ranges between 0 (original) and 1. This parameter is usually used to remove blemishes.
		 */
        public float smoothnessLevel { set; get; }

        /** The redness level. The value ranges between 0 (original) and 1. This parameter adjusts the red saturation level.
		 */
        public float rednessLevel { set; get; }
    }

    /** Background substitutoin meta data.
 */
    public class VirtualBackgroundSource
    {
        public VirtualBackgroundSource()
        {
            color = 0xFFFFFF;
            source = null;
            background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_COLOR;
        }

        /** The source type used to substitude capture image background.
   */
        public BACKGROUND_SOURCE_TYPE background_source_type { set; get; }

        /** The background color in RGB hex value. Value only. Do not include a preceeding #. For example, 0xFFB6C1 (light pink). The default value is 0xffffff (white).
   */
        public uint color { set; get; }

        /** image file path */
        public string source { set; get; }

        public BACKGROUND_BLUR_DEGREE blur_degree { set; get; }
    }

    /** The source used to substitude image background(foreground is portrait area).
   */
    public enum BACKGROUND_SOURCE_TYPE
    {
        /** Background source is pure color*/
        BACKGROUND_COLOR = 1,

        /** Background source is image path, only support png and jpg format*/
        BACKGROUND_IMG,

        BACKGROUND_BLUR
    }

    public enum BACKGROUND_BLUR_DEGREE
    {
       BLUR_DEGREE_LOW = 1,
       BLUR_DEGREE_MEDIUM,
       BLUR_DEGREE_HIGH
    }

    /**
	 * The UserInfo class.
	 */
    public class UserInfo
    {
        public UserInfo()
        {
            userAccount = "";
        }

        public UserInfo(uint uid = 0, string userAccount = "")
        {
            this.uid = uid;
            this.userAccount = userAccount;
        }

        /**
		 * The user ID.
		 */
        public uint uid { set; get; }

        /**
		 * The user account.
		 */
        public string userAccount { set; get; }
    }

    /**
 *  Regions for connetion.
 */
    [Flags]
    public enum AREA_CODE : uint
    {
        /**
     * Mainland China.
     */
        AREA_CODE_CN = 0x00000001,

        /**
     * North America.
     */
        AREA_CODE_NA = 0x00000002,

        /**
     * Europe.
     */
        AREA_CODE_EU = 0x00000004,

        /**
     * Asia, excluding Mainland China.
     */
        AREA_CODE_AS = 0x00000008,

        /**
     * Japan.
     */
        AREA_CODE_JP = 0x00000010,

        /**
     * India.
     */
        AREA_CODE_IN = 0x00000020,

        /**
     * (Default) Global.
     */
        AREA_CODE_GLOB = 0xFFFFFFFF
    }

    [Flags]
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
        APP_TYPE_UNI_APP = 14,
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

    /** The video frame type. */
    public enum VIDEO_FRAME_TYPE
    {
        /**
     * 0: YUV420
     */
        FRAME_TYPE_YUV420 = 0, // YUV 420 format

        /**
     * 1: YUV422
     */
        FRAME_TYPE_YUV422 = 1, // YUV 422 format

        /**
     * 2: RGBA
     */
        FRAME_TYPE_RGBA = 2, // RGBA format
    };

    /**
   * The frame position of the video observer.
   */
    [Flags]
    public enum VIDEO_OBSERVER_POSITION
    {
        /**USER_OFFLINE_REASON_TYPE
     * 1: The post-capturer position, which corresponds to the video data in the onCaptureVideoFrame callback.
     */
        POSITION_POST_CAPTURER = 1 << 0,

        /**
     * 2: The pre-renderer position, which corresponds to the video data in the onRenderVideoFrame callback.
     */
        POSITION_PRE_RENDERER = 1 << 1,

        /**
     * 4: The pre-encoder position, which corresponds to the video data in the onPreEncodeVideoFrame callback.
     */
        POSITION_PRE_ENCODER = 1 << 2,
    };

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
        /** 1: 128-bit AES encryption, XTS mode.
   */
        AES_128_XTS = 1,

        /** 2: 128-bit AES encryption, ECB mode.
   */
        AES_128_ECB = 2,

        /** 3: 256-bit AES encryption, XTS mode.
   */
        AES_256_XTS = 3,

        /// @cond
        /** 4: 128-bit SM4 encryption, ECB mode.
         */
        SM4_128_ECB = 4,

        /// @endcond
        /** 5: 128-bit AES encryption, GCM mode.
         *
         * @since v3.3.1
         */
        AES_128_GCM = 5,

        /** 6: 256-bit AES encryption, GCM mode.
   *
   * @since v3.3.1
   */
        AES_256_GCM = 6,

        /** 7: (Default) 128-bit AES encryption, GCM mode, with custom KDF salt.
   *
   * @since v3.4.1
   */
        AES_128_GCM2 = 7,

        /** 8: 256-bit AES encryption, GCM mode, with custom KDF salt.
   *
   * @since v3.4.1
   */
        AES_256_GCM2 = 8,

        /** Enumerator boundary.
   */
        MODE_END,
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

    /** Definition of AudioFrame */
    public class AudioFrame
    {
        public AudioFrame()
        {
        }

        public AudioFrame(AUDIO_FRAME_TYPE type, int samples, int bytesPerSample, int channels, int samplesPerSec,
            byte[] buffer, long renderTimeMs, int avsync_type)
        {
            this.type = type;
            this.samples = samples;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.buffer = buffer;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
        }

        /** The type of the audio frame. See #AUDIO_FRAME_TYPE
		 */
        public AUDIO_FRAME_TYPE type { set; get; }

        /** The number of samples per channel in the audio frame.
		 */
        public int samples { set; get; } //number of samples for each channel in this frame

        /**The number of bytes per audio sample, which is usually 16-bit (2-byte).
		 */
        public int bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

        /** The number of audio channels.
		 - 1: Mono
		 - 2: Stereo (the data is interleaved)
		 */
        public int channels { set; get; } //number of channels (data are interleaved if stereo)

        /** The sample rate.
		 */
        public int samplesPerSec { set; get; } //sampling rate

        /** The data buffer of the audio frame. When the audio frame uses a stereo channel, the data buffer is interleaved.
		 The size of the data buffer is as follows: `buffer` = `samples` × `channels` × `bytesPerSample`.
		 */
        public byte[] buffer { set; get; } //data buffer

        public IntPtr bufferPtr { set; get; }

        /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
		 - Restore the order of the captured audio frame.
		 - Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
		 */
        public long renderTimeMs { set; get; }

        /** Reserved parameter.
		 */
        public int avsync_type { set; get; }
    }

    internal class AudioFrameWithoutBuffer
    {
        public AudioFrameWithoutBuffer()
        {
        }

        public AudioFrameWithoutBuffer(AUDIO_FRAME_TYPE type, int samples, int bytesPerSample, int channels,
            int samplesPerSec, long renderTimeMs, int avsync_type)
        {
            this.type = type;
            this.samples = samples;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
        }

        /** The type of the audio frame. See #AUDIO_FRAME_TYPE
		 */
        public AUDIO_FRAME_TYPE type { set; get; }

        /** The number of samples per channel in the audio frame.
		 */
        public int samples { set; get; } //number of samples for each channel in this frame

        /**The number of bytes per audio sample, which is usually 16-bit (2-byte).
		 */
        public int bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

        /** The number of audio channels.
		 - 1: Mono
		 - 2: Stereo (the data is interleaved)
		 */
        public int channels { set; get; } //number of channels (data are interleaved if stereo)

        /** The sample rate.
		 */
        public int samplesPerSec { set; get; } //sampling rate

        /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
		 - Restore the order of the captured audio frame.
		 - Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
		 */
        public long renderTimeMs { set; get; }

        /** Reserved parameter.
		 */
        public int avsync_type { set; get; }
    }

    public struct DeviceInfo
    {
        public string deviceName { set; get; }
        public string deviceId { set; get; }
    }

    /** The external video frame.
	 */
    public class ExternalVideoFrame
    {
        public ExternalVideoFrame()
        {
        }

        public ExternalVideoFrame(VIDEO_BUFFER_TYPE type, VIDEO_PIXEL_FORMAT format, byte[] buffer, int stride,
            int height, long timestamp, int cropLeft = 0, int cropTop = 0, int cropRight = 0, int cropBottom = 0,
            int rotation = 0)
        {
            this.type = type;
            this.format = format;
            this.buffer = buffer;
            this.stride = stride;
            this.height = height;
            this.cropLeft = cropLeft;
            this.cropTop = cropTop;
            this.cropRight = cropRight;
            this.cropBottom = cropBottom;
            this.rotation = rotation;
            this.timestamp = timestamp;
        }

        /** The buffer type. See #VIDEO_BUFFER_TYPE
		 */
        public VIDEO_BUFFER_TYPE type { set; get; }

        /** The pixel format. See #VIDEO_PIXEL_FORMAT
		 */
        public VIDEO_PIXEL_FORMAT format { set; get; }

        /** The video buffer.
		 */
        public byte[] buffer { set; get; }

        /** Line spacing of the incoming video frame, which must be in pixels instead of bytes. For textures, it is the width of the texture.
		 */
        public int stride { set; get; }

        /** Height of the incoming video frame.
		 */
        public int height { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the left. The default value is 0.
		 */
        public int cropLeft { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the top. The default value is 0.
		 */
        public int cropTop { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the right. The default value is 0.
		 */
        public int cropRight { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the bottom. The default value is 0.
		 */
        public int cropBottom { set; get; }

        /** [Raw data related parameter] The clockwise rotation of the video frame. You can set the rotation angle as 0, 90, 180, or 270. The default value is 0.
		 */
        public int rotation { set; get; }

        /** Timestamp of the incoming video frame (ms). An incorrect timestamp results in frame loss or unsynchronized audio and video.
		 */
        public long timestamp { set; get; }
    }

    /** Video frame containing the Agora RTC SDK's encoded video data. */
    public class VideoFrame
    {
        /** The video frame type: #VIDEO_FRAME_TYPE. */
        public VIDEO_FRAME_TYPE type;

        /** Width (pixel) of the video frame.*/
        public int width;

        /** Height (pixel) of the video frame. */
        public int height;

        /** Line span of the Y buffer within the YUV data.
     */
        public int yStride; //stride of Y data buffer

        /** Line span of the U buffer within the YUV data.
     */
        public int uStride; //stride of U data buffer

        /** Line span of the V buffer within the YUV data.
     */
        public int vStride; //stride of V data buffer

        /** Pointer to the Y buffer pointer within the YUV data.
     */
        public byte[] yBuffer; //Y data buffer

        public IntPtr yBufferPtr;

        /** Pointer to the U buffer pointer within the YUV data.
     */
        public byte[] uBuffer; //U data buffer

        public IntPtr uBufferPtr;

        /** Pointer to the V buffer pointer within the YUV data.
     */
        public byte[] vBuffer; //V data buffer

        public IntPtr vBufferPtr;

        /** Set the rotation of this frame before rendering the video. Supports 0, 90, 180, 270 degrees clockwise.
     */
        /** Set the rotation of this frame before rendering the video. Supports 0, 90, 180, 270 degrees clockwise.
         */
        public int rotation; // rotation of this frame (0, 90, 180, 270)

        /** The timestamp of the external audio frame. It is mandatory. You can use this parameter for the following purposes:
         * - Restore the order of the captured audio frame.
         * - Synchronize audio and video frames in video-related scenarios, including scenarios where external video sources are used.
         * @note This timestamp is for rendering the video stream, and not for capturing the video stream.
         */
        public long renderTimeMs;

        /** Reserved for future use. */
        public int avsync_type;
    };

    public class ChannelMediaOptions
    {
        public ChannelMediaOptions()
        {
            autoSubscribeAudio = true;
            autoSubscribeVideo = true;
            publishLocalAudio = true;
            publishLocalVideo = true;
        }

        public ChannelMediaOptions(bool autoSubscribeAudio, bool autoSubscribeVideo, bool publishLocalAudio,
            bool publishLocalVideo)
        {
            this.autoSubscribeAudio = autoSubscribeAudio;
            this.autoSubscribeVideo = autoSubscribeVideo;
            this.publishLocalAudio = publishLocalAudio;
            this.publishLocalVideo = publishLocalVideo;
        }

        /** Determines whether to subscribe to audio streams when the user joins the channel:
		 - true: (Default) Subscribe.
		 - false: Do not subscribe.
		 This member serves a similar function to the \ref agora::rtc::IChannel::muteAllRemoteAudioStreams "muteAllRemoteAudioStreams" method. After joining the channel,
		 you can call the `muteAllRemoteAudioStreams` method to set whether to subscribe to audio streams in the channel.
		 */
        public bool autoSubscribeAudio { set; get; }

        /** Determines whether to subscribe to video streams when the user joins the channel:
		 - true: (Default) Subscribe.
		 - false: Do not subscribe.
		 This member serves a similar function to the \ref agora::rtc::IChannel::muteAllRemoteVideoStreams "muteAllRemoteVideoStreams" method. After joining the channel,
		 you can call the `muteAllRemoteVideoStreams` method to set whether to subscribe to video streams in the channel.
		 */
        public bool autoSubscribeVideo { set; get; }

        /** Determines whether to publish audio stream when the user joins a channel:
         - true: (Default) publish.
         - false: Do not publish.

         This member serves a similar function to the `muteLocalAudioStream` method. After joining the channel,
         you can call the `muteLocalAudioStream` method to set whether to publish audio stream in the channel.
         */
        public bool publishLocalAudio { set; get; }

        /** Determines whether to publish video stream when the user joins a channel:
         - true: (Default) publish.
         - false: Do not publish.

         This member serves a similar function to the `muteLocalVideoStream` method. After joining the channel,
         you can call the `muteLocalVideoStream` method to set whether to publish video stream in the channel.
         */
        public bool publishLocalVideo { set; get; }
    }


    /** Configurations of built-in encryption schemas. */
    public class EncryptionConfig
    {
        public EncryptionConfig()
        {
            encryptionMode = ENCRYPTION_MODE.AES_128_XTS;
            encryptionKey = "";
            encryptionKdfSalt = new byte[32];
        }

        public EncryptionConfig(ENCRYPTION_MODE encryptionMode, string encryptionKey, byte[] encryptionKdfSalt)
        {
            this.encryptionMode = encryptionMode;
            this.encryptionKey = encryptionKey;
            this.encryptionKdfSalt = encryptionKdfSalt;
        }

        /**
		 * Encryption mode. The default encryption mode is `AES_128_XTS`. See #ENCRYPTION_MODE.
		 */
        public ENCRYPTION_MODE encryptionMode { set; get; }

        /**
		 * Encryption key in string type.
		 *
		 * @note If you do not set an encryption key or set it as NULL, you cannot use the built-in encryption, and the SDK returns #ERR_INVALID_ARGUMENT (-2).
		 */
        public string encryptionKey { set; get; }

        private byte[] encryptionKdfSalt32 = new byte[32];

        public byte[] encryptionKdfSalt
        {
            set { Buffer.BlockCopy(encryptionKdfSalt, 0, encryptionKdfSalt32, 0, 32); }

            get { return encryptionKdfSalt32; }
        }
    }

    public class Metadata
    {
        public Metadata()
        {
            buffer = new byte[0];
        }

        public Metadata(uint uid, uint size, byte[] buffer, long timeStampMs)
        {
            this.uid = uid;
            this.size = size;
            this.buffer = buffer;
            this.timeStampMs = timeStampMs;
        }

        /** The User ID.
         - For the receiver: the ID of the user who sent the metadata.
         - For the sender: ignore it.
         */
        public uint uid { set; get; }

        /** Buffer size of the sent or received Metadata.
         */
        public uint size { set; get; }

        /** Buffer address of the sent or received Metadata.
         */
        public byte[] buffer { set; get; }

        /** Timestamp (ms) of the frame following the metadata.
         */
        public long timeStampMs { set; get; }
    };

    /** Definition of Packet.
     */
    public class Packet
    {
        public Packet()
        {
            buffer = new byte[0];
        }

        public Packet(byte[] buffer, uint size)
        {
            this.buffer = buffer;
            this.size = size;
        }

        /** Buffer address of the sent or received data.
         * @note Agora recommends that the value of buffer is more than 2048 bytes, otherwise, you may meet
         * undefined behaviors such as a crash.
         */
        public byte[] buffer { set; get; }

        /** Buffer size of the sent or received data.
         */
        public uint size { set; get; }
    }

    /** The configuration of the log files.
     *
     * @since v3.3.0
     */
    public class LogConfig
    {
        public LogConfig()
        {
            filePath = null;
            fileSize = -1;
            level = LOG_LEVEL.LOG_LEVEL_INFO;
        }

        public LogConfig(string filePath, int fileSize = 1024, LOG_LEVEL level = LOG_LEVEL.LOG_LEVEL_INFO)
        {
            this.filePath = filePath;
            this.fileSize = fileSize;
            this.level = level;
        }

        /** The absolute path of log files.
         *
         * The default file path is:
         * - Android: `/storage/emulated/0/Android/data/<package name>/files/agorasdk.log`
         * - iOS: `App Sandbox/Library/caches/agorasdk.log`
         * - macOS:
         *  - Sandbox enabled: `App Sandbox/Library/Logs/agorasdk.log`, such as `/Users/<username>/Library/Containers/<App Bundle Identifier>/Data/Library/Logs/agorasdk.log`.
         *  - Sandbox disabled: `～/Library/Logs/agorasdk.log`.
         * - Windows: `C:\Users\<user_name>\AppData\Local\Agora\<process_name>\agorasdk.log`
         *
         * Ensure that the directory for the log files exists and is writable. You can use this parameter to rename the log files.
         */
        public string filePath { set; get; }

        /** The size (KB) of a log file. The default value is 1024 KB. If you set `fileSize` to 1024 KB, the SDK outputs at most 5 MB log files;
         * if you set it to less than 1024 KB, the setting is invalid, and the maximum size of a log file is still 1024 KB.
         */
        public int fileSize { set; get; }

        /** The output log level of the SDK. See #LOG_LEVEL.
         *
         * For example, if you set the log level to WARN, the SDK outputs the logs within levels FATAL, ERROR, and WARN.
         */
        public LOG_LEVEL level { set; get; }
    };

    /** Configurations for the `IRtcEngine` instance.
     */
    [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, false)]
    public class RtcEngineConfig
    {
        /** The App ID issued to you by Agora. See [How to get the App ID](https://docs.agora.io/en/Agora%20Platform/token#getappid).
         * Only users in apps with the same App ID can join the same channel and communicate with each other. Use an 
         * App ID to initialize only one `IRtcEngine` instance. To change your App ID, call 
         * {@link agora.rtc.IRtcEngine.Destroy Destroy} to destroy the current `IRtcEngine` instance and then 
         * call this method to initialize an `IRtcEngine` instance with the new App ID.
         */
        public string appId { get; set; }

        /** The region for connection. This advanced feature applies to scenarios that have regional restrictions.
         *
         * For the regions that Agora supports, see #AREA_CODE. After specifying the region, the SDK connects to the 
         * Agora servers within that region.
         */
        public AREA_CODE areaCode { get; set; }

        /** The configuration of the log files that the SDK outputs. See {@link agora.rtc.LogConfig LogConfig}.
         * 
         * @since v3.3.1
         * 
         * By default, the SDK outputs five log files, `agorasdk.log`, `agorasdk_1.log`, 
         * `agorasdk_2.log`, `agorasdk_3.log`, `agorasdk_4.log`, each with a default 
         * size of 1024 KB. These log files are encoded in UTF-8. The SDK writes the 
         * latest logs in `agorasdk.log`. When `agorasdk.log` is full, the SDK deletes 
         * the log file with the earliest modification time among the other four, 
         * renames `agorasdk.log` to the name of the deleted log file, and creates a 
         * new `agorasdk.log` to record latest logs.
         */
        public LogConfig logConfig { get; set; }

        /** Configurations for the `IRtcEngine` instance.
         */
        public RtcEngineConfig(string mAppId, LogConfig config, AREA_CODE mAreaCode = AREA_CODE.AREA_CODE_GLOB)
        {
            appId = mAppId;
            areaCode = mAreaCode;
            logConfig = config;
        }
    }

    /** Definition of RtcEngineContext.
	 */
    public class RtcEngineContext
    {
        public RtcEngineContext(string appId, AREA_CODE areaCode = AREA_CODE.AREA_CODE_GLOB,
            LogConfig logConfig = null)
        {
            this.appId = appId;
            _areaCode = (uint) areaCode;
            this.logConfig = logConfig ?? new LogConfig();
        }

        /**
		 * The App ID issued to you by Agora. See [How to get the App ID](https://docs.agora.io/en/Agora%20Platform/token#get-an-app-id).
		 * Only users in apps with the same App ID can join the same channel and communicate with each other. Use an App ID to create only
		 * one `IRtcEngine` instance. To change your App ID, call `release` to destroy the current `IRtcEngine` instance and then call `createAgoraRtcEngine`
		 * and `initialize` to create an `IRtcEngine` instance with the new App ID.
		 */
        public string appId { set; get; }

        /**
		 * The region for connection. This advanced feature applies to scenarios that have regional restrictions.
		 *
		 * For the regions that Agora supports, see #AREA_CODE. After specifying the region, the SDK connects to the Agora servers within that region.
		 *
		 * @note The SDK supports specify only one region.
		 */
        private uint _areaCode;

        public LogConfig logConfig { set; get; }

        public AREA_CODE areaCode
        {
            get { return (AREA_CODE) _areaCode; }
            set { _areaCode = (uint) areaCode; }
        }
    };

    public enum AUDIO_MIXING_DUAL_MONO_MODE
    {
       AUDIO_MIXING_DUAL_MONO_AUTO,
       AUDIO_MIXING_DUAL_MONO_L,
       AUDIO_MIXING_DUAL_MONO_R,
       AUDIO_MIXING_DUAL_MONO_MIX
    }

    public struct AudioFileInfo {
      /** The file path.
         */
      public string filePath;
      /** The file duration (ms).
         */
      public int durationMs;
   };

   public enum AUDIO_FILE_INFO_ERROR {
      /** 0: Successfully get the information of an audio file.
         */
      AUDIO_FILE_INFO_ERROR_OK = 0,

      /** 1: Fail to get the information of an audio file.
         */
      AUDIO_FILE_INFO_ERROR_FAILURE = 1
   };

   /*
    * @since v3.5.2
    */
    public enum CONTENT_INSPECT_RESULT {
        CONTENT_INSPECT_NEUTRAL = 1,
        CONTENT_INSPECT_SEXY = 2,
        CONTENT_INSPECT_PORN = 3
    };

    /**
    * The EchoTestConfiguration struct.
    * @since v3.5.2
    */
    public struct EchoTestConfiguration {
        public IntPtr view;
        public bool enableAudio;
        public bool enableVideo;
        public string token;
        public string channelId;
    };

    /** Definition of ContentInspectModule.
    * @since v3.5.2
    */
    public struct ContentInspectModule {
        /**
        * The content inspect module type.
        * the module type can be 0 to 31.
        * kContentInspectInvalid(0)
        * kContentInspectModeration(1)
        * kContentInspectSupervise(2)
        */
        public int type;
        /**The content inspect frequency, default is 0 second.
        * the frequency <= 0 is invalid.
        */
        public int interval;
    };

    /** Definition of ContentInspectConfig.
    * @since v3.5.2
    */
    public struct ContentInspectConfig {
        /** The extra information, max length of extraInfo is 1024.
        *  The extra information will send to server with content(image).
        */
        public string extraInfo;
        /**The content inspect modules, max length of modules is 32.
        * the content(snapshot of send video stream, image) can be used to max of 32 types functions.
        */
        public ContentInspectModule[] modules;
        /**The content inspect module count.
        */
        public int moduleCount;
    };

    public enum AVDATA_TYPE {
        /** 0: the metadata type is unknown.
        */
        AVDATA_UNKNOWN = 0,
        /** 1: the metadata type is video.
        */
        AVDATA_VIDEO = 1,
        /** 2: the metadata type is video.
        */
        AVDATA_AUDIO = 2
    };

    public enum CODEC_VIDEO {
        /** 0: h264 avc codec.
        */
        CODEC_VIDEO_AVC = 0,
        /** 1: h265 hevc codec.
        */
        CODEC_VIDEO_HEVC = 1,
        /** 2: vp8 codec.
        */
        CODEC_VIDEO_VP8 = 2
    };

    public enum CODEC_AUDIO {
        /** 0: PCM audio codec.
        */
        CODEC_AUDIO_PCM = 0,
        /** 1: aac audio codec.
        */
        CODEC_AUDIO_AAC = 1,
        /** 2: G711 audio codec.
        */
        CODEC_AUDIO_G722 = 2
    };

    public class VDataInfo {
        public uint codec;
        public uint width;
        public uint height;
        public int frameType;
        public int rotation;
        public bool equal(VDataInfo vinfo) { return codec == vinfo.codec && width == vinfo.width && height == vinfo.height && rotation == vinfo.rotation; }
    };

    public class ADataInfo {
        public uint codec;
        public uint bitwidth;
        public uint sample_rate;
        public uint channel;
        public uint sample_size;

        public bool equal(ADataInfo ainfo) { return codec == ainfo.codec && bitwidth == ainfo.bitwidth && sample_rate == ainfo.sample_rate && channel == ainfo.channel; }
    };

    public struct AVData {
        /** The User ID. reserved
        - For the receiver: the ID of the user who owns the data.
        */
        public uint uid;
        /**
        - data type, audio / video.
        */
        public AVDATA_TYPE type;
        /** Buffer size of the sent or received Metadata.
        */
        public uint size;
        /** Buffer address of the sent or received Metadata.
        */
        public byte[] buffer;
        /** Time statmp of the frame following the metadata.
        */
        public uint timestamp;
        /**
        * Video frame info
        */
        public VDataInfo vinfo;
        /**
        * Audio frame info
        */
        public ADataInfo ainfo;
    };

    public enum MediaRecorderContainerFormat {
        FORMAT_MP4 = 1,
        FORMAT_FLV = 2
    };

    public enum MediaRecorderStreamType {
        STREAM_TYPE_AUDIO = 0x01,
        STREAM_TYPE_VIDEO = 0x02,
        STREAM_TYPE_BOTH = STREAM_TYPE_AUDIO | STREAM_TYPE_VIDEO
    };

    public enum RecorderState {
        RECORDER_STATE_ERROR = -1,
        RECORDER_STATE_START = 2,
        RECORDER_STATE_STOP = 3
    };

    public enum RecorderErrorCode {
        RECORDER_ERROR_NONE = 0,
        RECORDER_ERROR_WRITE_FAILED = 1,
        RECORDER_ERROR_NO_STREAM = 2,
        RECORDER_ERROR_OVER_MAX_DURATION = 3,
        RECORDER_ERROR_CONFIG_CHANGED = 4,
        RECORDER_ERROR_CUSTOM_STREAM_DETECTED = 5
    };

    public struct MediaRecorderConfiguration {
        public string storagePath;
        public MediaRecorderContainerFormat containerFormat;
        public MediaRecorderStreamType streamType;
        public int maxDurationMs;
        public int recorderInfoUpdateInterval;
    };

    public struct RecorderInfo {
        public string fileName;
        public uint durationMs;
        public uint fileSize;
    };

    public enum AgoraEngineType
    {
        MainProcess,
        SubProcess
    }

    internal static partial class ObsoleteMethodWarning
    {
    }
}