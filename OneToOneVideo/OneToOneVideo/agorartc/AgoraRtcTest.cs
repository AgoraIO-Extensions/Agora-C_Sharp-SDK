using System.Runtime.InteropServices;

namespace agorartc
{
    public enum API_TYPE
    {
        INITIALIZE = 0,
        RELEASE = 1,
        SET_CHANNEL_PROFILE = 2,
        SET_CLIENT_ROLE = 3,
        JOIN_CHANNEL = 4,
        SWITCH_CHANNEL = 5,
        LEAVE_CHANNEL = 6,
        RE_NEW_TOKEN = 7,
        REGISTER_LOCAL_USER_ACCOUNT = 8,
        JOIN_CHANNEL_WITH_USER_ACCOUNT = 9,
        GET_USER_INFO_BY_USER_ACCOUNT = 10,
        GET_USER_INFO_BY_UID = 11,
        START_ECHO_TEST = 12,
        START_ECHO_TEST_2 = 13,
        STOP_ECHO_TEST = 14,
        ENABLE_VIDEO = 15,
        DISABLE_VIDEO = 16,
        SET_VIDEO_PROFILE = 17,
        SET_VIDEO_ENCODER_CONFIGURATION = 18,
        SET_CAMERA_CAPTURER_CONFIGURATION = 19,
        SET_UP_LOCAL_VIDEO = 20,
        SET_UP_REMOTE_VIDEO = 21,
        START_PREVIEW = 22,
        SET_REMOTE_USER_PRIORITY = 23,
        STOP_PREVIEW = 24,
        ENABLE_AUDIO = 25,
        ENABLE_LOCAL_AUDIO = 26,
        DISABLE_AUDIO = 27,
        SET_AUDIO_PROFILE = 28,
        MUTE_LOCAL_AUDIO_STREAM = 29,
        MUTE_ALL_REMOTE_AUDIO_STREAMS = 30,
        SET_DEFAULT_MUTE_ALL_REMOTE_AUDIO_STREAMS = 31,
        ADJUST_USER_PLAYBACK_SIGNAL_VOLUME = 32,
        MUTE_REMOTE_AUDIO_STREAM = 33,
        MUTE_LOCAL_VIDEO_STREAM = 34,
        ENABLE_LOCAL_VIDEO = 35,
        MUTE_ALL_REMOTE_VIDEO_STREAMS = 36,
        SET_DEFAULT_MUTE_ALL_REMOTE_VIDEO_STREAMS = 37,
        MUTE_REMOTE_VIDEO_STREAM = 38,
        SET_REMOTE_VIDEO_STREAM_TYPE = 39,
        SET_REMOTE_DEFAULT_VIDEO_STREAM_TYPE = 40,
        ENABLE_AUDIO_VOLUME_INDICATION = 41,
        START_AUDIO_RECORDING = 42,
        START_AUDIO_RECORDING2 = 43,
        STOP_AUDIO_RECORDING = 44,
        ENABLE_FACE_DETECTION = 62,
        SET_REMOTE_VOICE_POSITIONN = 73,
        SET_LOG_FILE = 79,
        SET_LOG_FILTER = 80,
        SET_LOG_FILE_SIZE = 81,
        SET_LOCAL_RENDER_MODE = 82,
        SET_LOCAL_RENDER_MODE_2 = 83,
        SET_REMOTE_RENDER_MODE = 84,
        SET_REMOTE_RENDER_MODE_2 = 85,
        SET_LOCAL_VIDEO_MIRROR_MODE = 86,
        ENABLE_DUAL_STREAM_MODE = 87,
        ADJUST_RECORDING_SIGNAL_VOLUME = 93,
        ADJUST_PLAYBACK_SIGNAL_VOLUME = 94,
        ENABLE_WEB_SDK_INTEROPER_ABILITY = 95,
        SET_VIDEO_QUALITY_PARAMETERS = 96,
        SET_LOCAL_PUBLISH_FALLBACK_OPTION = 97,
        SET_REMOTE_SUBSCRIBE_FALLBACK_OPTION = 98,
        SWITCH_CAMERA = 99,
        SWITCH_CAMERA_2 = 100,
        SET_DEFAULT_AUDIO_ROUTE_SPEAKER_PHONE = 101,
        SET_ENABLE_SPEAKER_PHONE = 102,
        ENABLE_IN_EAR_MONITORING = 103,
        SET_IN_EAR_MONITORING_VOLUME = 104,
        IS_SPEAKER_PHONE_ENABLED = 105,
        SET_AUDIO_SESSION_OPERATION_RESTRICTION = 106,
        ENABLE_LOOP_BACK_RECORDING = 107,
        START_SCREEN_CAPTURE_BY_DISPLAY_ID = 108,
        START_SCREEN_CAPTURE_BY_SCREEN_RECT = 109,
        START_SCREEN_CAPTURE_BY_WINDOW_ID = 110,
        SET_SCREEN_CAPTURE_CONTENT_HINT = 111,
        UPDATE_SCREEN_CAPTURE_PARAMETERS = 112,
        UPDATE_SCREEN_CAPTURE_REGION = 113,
        STOP_SCREEN_CAPTURE = 114,
        GET_CALL_ID = 117,
        RATE = 118,
        COMPLAIN = 119,
        GET_VERSION = 120,
        ENABLE_LAST_MILE_TEST = 121,
        DISABLE_LAST_MILE_TEST = 122,
        START_LAST_MILE_PROBE_TEST = 123,
        STOP_LAST_MILE_PROBE_TEST = 124,
        GET_ERROR_DESCRIPTION = 125,
        SET_ENCRYPTION_SECTRT = 126,
        SET_ENCRYPTION_MODE = 127,
        REGISTER_PACKET_OBSERVER = 128,
        CREATE_DATA_STREAM = 129,
        SEND_STREAM_MESSAGE = 130,
        ADD_PUBLISH_STREAM_URL = 131,
        REMOVE_PUBLISH_STREAM_URL = 132,
        SET_LIVE_TRANSCODING = 133,
        ADD_VIDEO_WATER_MARK = 134,
        ADD_VIDEO_WATER_MARK_2 = 135,
        CLEAR_VIDEO_WATER_MARKS = 136,
        SET_BEAUTY_EFFECT_OPTIONS = 137,
        ADD_INJECT_STREAM_URL = 138,
        START_CHANNEL_MEDIA_RELAY = 139,
        UPDATE_CHANNEL_MEDIA_RELAY = 140,
        STOP_CHANNEL_MEDIA_RELAY = 141,
        REMOVE_INJECT_STREAM_URL = 142,
        GET_CONNECTION_STATE = 143,
        REGISTER_MEDIA_META_DATA_OBSERVER = 144,
        SET_PARAMETERS = 145,
        SET_PLAYBACK_DEVICE_VOLUME = 146,
        PUBLISH = 147,
        UNPUBLISH = 148,
        CHANNEL_ID = 149,
        SEND_METADATA = 150,
        SET_MAX_META_SIZE = 151,
        PUSH_AUDIO_FRAME = 152,
        PUSH_AUDIO_FRAME_2 = 153,
        PULL_AUDIO_FRAME = 154,
        SET_EXTERN_VIDEO_SOURCE = 155,
        PUSH_VIDEO_FRAME = 156
    }

    public enum API_TYPE_AUDIO_EFFECT
    {
        START_AUDIO_MIXING = 45,
        STOP_AUDIO_MIXING = 46,
        PAUSE_AUDIO_MIXING = 47,
        RESUME_AUDIO_MIXING = 48,
        SET_HIGH_QUALITY_AUDIO_PARAMETERS = 49,
        ADJUST_AUDIO_MIXING_VOLUME = 50,
        ADJUST_AUDIO_MIXING_PLAYOUT_VOLUME = 51,
        GET_AUDIO_MIXING_PLAYOUT_VOLUME = 52,
        ADJUST_AUDIO_MIXING_PUBLISH_VOLUME = 53,
        GET_AUDIO_MIXING_PUBLISH_VOLUME = 54,
        GET_AUDIO_MIXING_DURATION = 55,
        GET_AUDIO_MIXING_CURRENT_POSITION = 56,
        SET_AUDIO_MIXING_POSITION = 57,
        SET_AUDIO_MIXING_PITCH = 58,
        GET_EFFECTS_VOLUME = 59,
        SET_EFFECTS_VOLUME = 60,
        SET_VOLUME_OF_EFFECT = 61,
        PLAY_EFFECT = 63,
        STOP_EFFECT = 64,
        STOP_ALL_EFFECTS = 65,
        PRE_LOAD_EFFECT = 66,
        UN_LOAD_EFFECT = 67,
        PAUSE_EFFECT = 68,
        PAUSE_ALL_EFFECTS = 69,
        RESUME_EFFECT = 70,
        RESUME_ALL_EFFECTS = 71,
        ENABLE_SOUND_POSITION_INDICATION = 72,
        SET_LOCAL_VOICE_PITCH = 74,
        SET_LOCAL_VOICE_EQUALIZATION = 75,
        SET_LOCAL_VOICE_REVERB = 76,
        SET_LOCAL_VOICE_CHANGER = 77,
        SET_LOCAL_VOICE_REVERB_PRESET = 78,
        SET_EXTERNAL_AUDIO_SOURCE = 88,
        SET_EXTERNAL_AUDIO_SINK = 89,
        SET_RECORDING_AUDIO_FRAME_PARAMETERS = 90,
        SET_PLAYBACK_AUDIO_FRAME_PARAMETERS = 91,
        SET_MIXED_AUDIO_FRAME_PARAMETERS = 92,
    }

    public enum API_TYPE_DEVICE_MANAGER
    {
        GET_COUNT = 151,
        GET_DEVICE = 152,
        GET_CURRENT_DEVICE = 153,
        GET_CURRENT_DEVICE_INFO = 154,
        SET_DEVICE = 155,
        SET_DEVICE_VOLUME = 156,
        GET_DEVICE_VOLUME = 157,
        SET_DEVICE_MUTE = 158,
        GET_DEVICE_MUTE = 159,
        START_DEVICE_TEST = 160,
        STOP_DEVICE_TEST = 161,
        START_AUDIO_DEVICE_LOOP_BACK_TEST = 162,
        STOP_AUDIO_DEVICE_LOOP_BACK_TEST = 163
    }

    public static class Test
    {
        public static void begin_api_test(string caseFilePath, FUNC_APICaseHandler apiCaseHandler)
        {
            AgorartcNative.begin_api_test(caseFilePath, apiCaseHandler);
        }

        public static void compare_and_dump_api_test_result(string caseFilePath, string dumpFilePath,
            FUNC_APICaseHandler apiCaseHandler)
        {
            AgorartcNative.compare_and_dump_api_test_result(caseFilePath, dumpFilePath, apiCaseHandler);
        }

        public static void begin_rtc_engine_event_test(string caseFilePath, IRtcEngineEventHandlerBase eventHandlerBase)
        {
            TestNativeRtcEventHandler.engineEventHandler = eventHandlerBase;
            var eventHandler = new RtcEventHandler()
            {
                onJoinChannelSuccess = TestNativeRtcEventHandler.OnJoinChannelSuccess,
                onReJoinChannelSuccess = TestNativeRtcEventHandler.OnReJoinChannelSuccess,
                onLeaveChannel = TestNativeRtcEventHandler.OnLeaveChannel,
                onConnectionLost = TestNativeRtcEventHandler.OnConnectionLost,
                onConnectionInterrupted = TestNativeRtcEventHandler.OnConnectionInterrupted,
                onRequestToken = TestNativeRtcEventHandler.OnRequestToken,
                onUserJoined = TestNativeRtcEventHandler.OnUserJoined,
                onUserOffline = TestNativeRtcEventHandler.OnUserOffline,
                onAudioVolumeIndication = TestNativeRtcEventHandler.OnAudioVolumeIndication,
                onUserMuteAudio = TestNativeRtcEventHandler.OnUserMuteAudio,
                onWarning = TestNativeRtcEventHandler.OnWarning,
                onError = TestNativeRtcEventHandler.OnError,
                onRtcStats = TestNativeRtcEventHandler.OnRtcStats,
                onAudioMixingFinished = TestNativeRtcEventHandler.OnAudioMixingFinished,
                onAudioRouteChanged = TestNativeRtcEventHandler.OnAudioRouteChanged,
                onFirstRemoteVideoDecoded = TestNativeRtcEventHandler.OnFirstRemoteVideoDecoded,
                onVideoSizeChanged = TestNativeRtcEventHandler.OnVideoSizeChanged,
                onClientRoleChanged = TestNativeRtcEventHandler.OnClientRoleChanged,
                onUserMuteVideo = TestNativeRtcEventHandler.OnUserMuteVideo,
                onMicrophoneEnabled = TestNativeRtcEventHandler.OnMicrophoneEnabled,
                onApiCallExecuted = TestNativeRtcEventHandler.OnApiExecuted,
                onFirstLocalAudioFrame = TestNativeRtcEventHandler.OnFirstLocalAudioFrame,
                onFirstRemoteAudioFrame = TestNativeRtcEventHandler.OnFirstRemoteAudioFrame,
                onLastmileQuality = TestNativeRtcEventHandler.OnLastmileQuality,
                onAudioQuality = TestNativeRtcEventHandler.OnAudioQuality,
                onStreamInjectedStatus = TestNativeRtcEventHandler.OnStreamInjectedStatus,
                onStreamUnpublished = TestNativeRtcEventHandler.OnStreamUnpublished,
                onStreamPublished = TestNativeRtcEventHandler.OnStreamPublished,
                onStreamMessageError = TestNativeRtcEventHandler.OnStreamMessageError,
                onStreamMessage = TestNativeRtcEventHandler.OnStreamMessage,
                onConnectionBanned = TestNativeRtcEventHandler.OnConnectionBanned,
                onRemoteVideoTransportStats = TestNativeRtcEventHandler.OnRemoteVideoTransportStats,
                onRemoteAudioTransportStats = TestNativeRtcEventHandler.OnRemoteAudioTransportStats,
                onTranscodingUpdated = TestNativeRtcEventHandler.OnTranscodingUpdated,
                onAudioDeviceVolumeChanged = TestNativeRtcEventHandler.OnAudioDeviceVolumeChanged,
                onActiveSpeaker = TestNativeRtcEventHandler.OnActiveSpeaker,
                onMediaEngineStartCallSuccess = TestNativeRtcEventHandler.OnMediaEngineStartCallSuccess,
                onMediaEngineLoadSuccess = TestNativeRtcEventHandler.OnMediaEngineLoadSuccess,
                onConnectionStateChanged = TestNativeRtcEventHandler.OnConnectionStateChanged,
                onRemoteSubscribeFallbackToAudioOnly = TestNativeRtcEventHandler.OnRemoteSubscribeFallbackToAudioOnly,
                onLocalPublishFallbackToAudioOnly = TestNativeRtcEventHandler.OnLocalPublishFallbackToAudioOnly,
                onUserEnableLocalVideo = TestNativeRtcEventHandler.OnUserEnableLocalVideo,
                onRemoteVideoStateChanged = TestNativeRtcEventHandler.OnRemoteVideoStateChanged,
                onVideoDeviceStateChanged = TestNativeRtcEventHandler.OnVideoDeviceStateChanged,
                onAudioEffectFinished = TestNativeRtcEventHandler.OnAudioEffectFinished,
                onRemoteAudioMixingEnd = TestNativeRtcEventHandler.OnRemoteAudioMixingEnd,
                onRemoteAudioMixingBegin = TestNativeRtcEventHandler.OnRemoteAudioMixingBegin,
                onCameraExposureAreaChanged = TestNativeRtcEventHandler.OnCameraExposureAreaChanged,
                onCameraFocusAreaChanged = TestNativeRtcEventHandler.OnCameraFocusAreaChanged,
                onCameraReady = TestNativeRtcEventHandler.OnCameraReady,
                onAudioDeviceStateChanged = TestNativeRtcEventHandler.OnAudioDeviceStateChanged,
                onUserEnableVideo = TestNativeRtcEventHandler.OnUserEnableVideo,
                onFirstRemoteVideoFrame = TestNativeRtcEventHandler.OnFirstRemoteVideoFrame,
                onFirstLocalVideoFrame = TestNativeRtcEventHandler.OnFirstLocalVideoFrame,
                onRemoteAudioStats = TestNativeRtcEventHandler.OnRemoteAudioStats,
                onRemoteVideoStats = TestNativeRtcEventHandler.OnRemoteVideoStats,
                onLocalVideoStats = TestNativeRtcEventHandler.OnLocalVideoStats,
                onNetworkQuality = TestNativeRtcEventHandler.OnNetworkQuality,
                onTokenPrivilegeWillExpire = TestNativeRtcEventHandler.OnTokenPrivilegeWillExpire,
                onVideoStopped = TestNativeRtcEventHandler.OnVideoStopped,
                onAudioMixingStateChanged = TestNativeRtcEventHandler.OnAudioMixingStateChanged,
                onFirstRemoteAudioDecoded = TestNativeRtcEventHandler.OnFirstRemoteAudioDecoded,
                onLocalVideoStateChanged = TestNativeRtcEventHandler.OnLocalVideoStateChanged,
                onNetworkTypeChanged = TestNativeRtcEventHandler.OnNetworkTypeChanged,
                onRtmpStreamingStateChanged = TestNativeRtcEventHandler.OnRtmpStreamingStateChanged,
                onLastmileProbeResult = TestNativeRtcEventHandler.OnLastmileProbeResult,
                onLocalUserRegistered = TestNativeRtcEventHandler.OnLocalUserRegistered,
                onUserInfoUpdated = TestNativeRtcEventHandler.OnUserInfoUpdated,
                onLocalAudioStateChanged = TestNativeRtcEventHandler.OnLocalAudioStateChanged,
                onRemoteAudioStateChanged = TestNativeRtcEventHandler.OnRemoteAudioStateChanged,
                onLocalAudioStats = TestNativeRtcEventHandler.OnLocalAudioStats,
                onChannelMediaRelayStateChanged = TestNativeRtcEventHandler.OnChannelMediaRelayStateChanged,
                onChannelMediaRelayEvent = TestNativeRtcEventHandler.OnChannelMediaRelayEvent,
                onFacePositionChanged = TestNativeRtcEventHandler.OnFacePositionChanged,
                onTestEnd = TestNativeRtcEventHandler.OnTestEnd,
            };
            AgorartcNative.begin_rtc_engine_event_test(caseFilePath, eventHandler);
        }

        public static void compare_dump_rtc_engine_event_test_result(string caseFilePath, string dumpFilePath,
            IRtcEngineEventHandlerBase eventHandlerBase)
        {
            TestNativeRtcEventHandler.engineEventHandler = eventHandlerBase;
            var eventHandler = new RtcEventHandler()
            {
                onJoinChannelSuccess = TestNativeRtcEventHandler.OnJoinChannelSuccess,
                onReJoinChannelSuccess = TestNativeRtcEventHandler.OnReJoinChannelSuccess,
                onLeaveChannel = TestNativeRtcEventHandler.OnLeaveChannel,
                onConnectionLost = TestNativeRtcEventHandler.OnConnectionLost,
                onConnectionInterrupted = TestNativeRtcEventHandler.OnConnectionInterrupted,
                onRequestToken = TestNativeRtcEventHandler.OnRequestToken,
                onUserJoined = TestNativeRtcEventHandler.OnUserJoined,
                onUserOffline = TestNativeRtcEventHandler.OnUserOffline,
                onAudioVolumeIndication = TestNativeRtcEventHandler.OnAudioVolumeIndication,
                onUserMuteAudio = TestNativeRtcEventHandler.OnUserMuteAudio,
                onWarning = TestNativeRtcEventHandler.OnWarning,
                onError = TestNativeRtcEventHandler.OnError,
                onRtcStats = TestNativeRtcEventHandler.OnRtcStats,
                onAudioMixingFinished = TestNativeRtcEventHandler.OnAudioMixingFinished,
                onAudioRouteChanged = TestNativeRtcEventHandler.OnAudioRouteChanged,
                onFirstRemoteVideoDecoded = TestNativeRtcEventHandler.OnFirstRemoteVideoDecoded,
                onVideoSizeChanged = TestNativeRtcEventHandler.OnVideoSizeChanged,
                onClientRoleChanged = TestNativeRtcEventHandler.OnClientRoleChanged,
                onUserMuteVideo = TestNativeRtcEventHandler.OnUserMuteVideo,
                onMicrophoneEnabled = TestNativeRtcEventHandler.OnMicrophoneEnabled,
                onApiCallExecuted = TestNativeRtcEventHandler.OnApiExecuted,
                onFirstLocalAudioFrame = TestNativeRtcEventHandler.OnFirstLocalAudioFrame,
                onFirstRemoteAudioFrame = TestNativeRtcEventHandler.OnFirstRemoteAudioFrame,
                onLastmileQuality = TestNativeRtcEventHandler.OnLastmileQuality,
                onAudioQuality = TestNativeRtcEventHandler.OnAudioQuality,
                onStreamInjectedStatus = TestNativeRtcEventHandler.OnStreamInjectedStatus,
                onStreamUnpublished = TestNativeRtcEventHandler.OnStreamUnpublished,
                onStreamPublished = TestNativeRtcEventHandler.OnStreamPublished,
                onStreamMessageError = TestNativeRtcEventHandler.OnStreamMessageError,
                onStreamMessage = TestNativeRtcEventHandler.OnStreamMessage,
                onConnectionBanned = TestNativeRtcEventHandler.OnConnectionBanned,
                onRemoteVideoTransportStats = TestNativeRtcEventHandler.OnRemoteVideoTransportStats,
                onRemoteAudioTransportStats = TestNativeRtcEventHandler.OnRemoteAudioTransportStats,
                onTranscodingUpdated = TestNativeRtcEventHandler.OnTranscodingUpdated,
                onAudioDeviceVolumeChanged = TestNativeRtcEventHandler.OnAudioDeviceVolumeChanged,
                onActiveSpeaker = TestNativeRtcEventHandler.OnActiveSpeaker,
                onMediaEngineStartCallSuccess = TestNativeRtcEventHandler.OnMediaEngineStartCallSuccess,
                onMediaEngineLoadSuccess = TestNativeRtcEventHandler.OnMediaEngineLoadSuccess,
                onConnectionStateChanged = TestNativeRtcEventHandler.OnConnectionStateChanged,
                onRemoteSubscribeFallbackToAudioOnly = TestNativeRtcEventHandler.OnRemoteSubscribeFallbackToAudioOnly,
                onLocalPublishFallbackToAudioOnly = TestNativeRtcEventHandler.OnLocalPublishFallbackToAudioOnly,
                onUserEnableLocalVideo = TestNativeRtcEventHandler.OnUserEnableLocalVideo,
                onRemoteVideoStateChanged = TestNativeRtcEventHandler.OnRemoteVideoStateChanged,
                onVideoDeviceStateChanged = TestNativeRtcEventHandler.OnVideoDeviceStateChanged,
                onAudioEffectFinished = TestNativeRtcEventHandler.OnAudioEffectFinished,
                onRemoteAudioMixingEnd = TestNativeRtcEventHandler.OnRemoteAudioMixingEnd,
                onRemoteAudioMixingBegin = TestNativeRtcEventHandler.OnRemoteAudioMixingBegin,
                onCameraExposureAreaChanged = TestNativeRtcEventHandler.OnCameraExposureAreaChanged,
                onCameraFocusAreaChanged = TestNativeRtcEventHandler.OnCameraFocusAreaChanged,
                onCameraReady = TestNativeRtcEventHandler.OnCameraReady,
                onAudioDeviceStateChanged = TestNativeRtcEventHandler.OnAudioDeviceStateChanged,
                onUserEnableVideo = TestNativeRtcEventHandler.OnUserEnableVideo,
                onFirstRemoteVideoFrame = TestNativeRtcEventHandler.OnFirstRemoteVideoFrame,
                onFirstLocalVideoFrame = TestNativeRtcEventHandler.OnFirstLocalVideoFrame,
                onRemoteAudioStats = TestNativeRtcEventHandler.OnRemoteAudioStats,
                onRemoteVideoStats = TestNativeRtcEventHandler.OnRemoteVideoStats,
                onLocalVideoStats = TestNativeRtcEventHandler.OnLocalVideoStats,
                onNetworkQuality = TestNativeRtcEventHandler.OnNetworkQuality,
                onTokenPrivilegeWillExpire = TestNativeRtcEventHandler.OnTokenPrivilegeWillExpire,
                onVideoStopped = TestNativeRtcEventHandler.OnVideoStopped,
                onAudioMixingStateChanged = TestNativeRtcEventHandler.OnAudioMixingStateChanged,
                onFirstRemoteAudioDecoded = TestNativeRtcEventHandler.OnFirstRemoteAudioDecoded,
                onLocalVideoStateChanged = TestNativeRtcEventHandler.OnLocalVideoStateChanged,
                onNetworkTypeChanged = TestNativeRtcEventHandler.OnNetworkTypeChanged,
                onRtmpStreamingStateChanged = TestNativeRtcEventHandler.OnRtmpStreamingStateChanged,
                onLastmileProbeResult = TestNativeRtcEventHandler.OnLastmileProbeResult,
                onLocalUserRegistered = TestNativeRtcEventHandler.OnLocalUserRegistered,
                onUserInfoUpdated = TestNativeRtcEventHandler.OnUserInfoUpdated,
                onLocalAudioStateChanged = TestNativeRtcEventHandler.OnLocalAudioStateChanged,
                onRemoteAudioStateChanged = TestNativeRtcEventHandler.OnRemoteAudioStateChanged,
                onLocalAudioStats = TestNativeRtcEventHandler.OnLocalAudioStats,
                onChannelMediaRelayStateChanged = TestNativeRtcEventHandler.OnChannelMediaRelayStateChanged,
                onChannelMediaRelayEvent = TestNativeRtcEventHandler.OnChannelMediaRelayEvent,
                onFacePositionChanged = TestNativeRtcEventHandler.OnFacePositionChanged,
                onTestEnd = TestNativeRtcEventHandler.OnTestEnd,
            };
            AgorartcNative.compare_dump_rtc_engine_event_test_result(caseFilePath, dumpFilePath, eventHandler);
        }

        public static void log_engine_event_case(string eventType, string parameter)
        {
            AgorartcNative.log_engine_event_case(eventType, parameter);
        }

        public static void begin_channel_event_test(string caseFilePath, string channelId,
            IRtcChannelEventHandlerBase eventHandlerBase)
        {
            TestNativeRtcChannelEventHandler.channelEventHandler = eventHandlerBase;
            var eventHandler = new ChannelEventHandler
            {
                onWarning = TestNativeRtcChannelEventHandler.OnChannelWarning,
                onError = TestNativeRtcChannelEventHandler.OnChannelWarning,
                onJoinChannelSuccess = TestNativeRtcChannelEventHandler.OnChannelJoinChannelSuccess,
                onRejoinChannelSuccess = TestNativeRtcChannelEventHandler.OnChannelReJoinChannelSuccess,
                onLeaveChannel = TestNativeRtcChannelEventHandler.OnChannelLeaveChannel,
                onClientRoleChanged = TestNativeRtcChannelEventHandler.OnChannelClientRoleChanged,
                onUserJoined = TestNativeRtcChannelEventHandler.OnChannelUserJoined,
                onUserOffLine = TestNativeRtcChannelEventHandler.OnChannelUserOffLine,
                onConnectionLost = TestNativeRtcChannelEventHandler.OnChannelConnectionLost,
                onRequestToken = TestNativeRtcChannelEventHandler.OnChannelRequestToken,
                onTokenPrivilegeWillExpire = TestNativeRtcChannelEventHandler.OnChannelTokenPrivilegeWillExpire,
                onRtcStats = TestNativeRtcChannelEventHandler.OnChannelRtcStats,
                onNetworkQuality = TestNativeRtcChannelEventHandler.OnChannelNetworkQuality,
                onRemoteVideoStats = TestNativeRtcChannelEventHandler.OnChannelRemoteVideoStats,
                onRemoteAudioStats = TestNativeRtcChannelEventHandler.OnChannelRemoteAudioStats,
                onRemoteAudioStateChanged = TestNativeRtcChannelEventHandler.OnChannelRemoteAudioStateChanged,
                onActiveSpeaker = TestNativeRtcChannelEventHandler.OnChannelActiveSpeaker,
                onVideoSizeChanged = TestNativeRtcChannelEventHandler.OnChannelVideoSizeChanged,
                onRemoteVideoStateChanged = TestNativeRtcChannelEventHandler.OnChannelRemoteVideoStateChanged,
                onStreamMessage = TestNativeRtcChannelEventHandler.OnChannelStreamMessage,
                onStreamMessageError = TestNativeRtcChannelEventHandler.OnChannelStreamMessageError,
                onMediaRelayStateChanged = TestNativeRtcChannelEventHandler.OnChannelMediaRelayStateChanged2,
                onMediaRelayEvent = TestNativeRtcChannelEventHandler.OnChannelMediaRelayEvent2,
                onRtmpStreamingStateChanged = TestNativeRtcChannelEventHandler.OnChannelRtmpStreamingStateChanged,
                onTranscodingUpdated = TestNativeRtcChannelEventHandler.OnChannelTranscodingUpdated,
                onStreamInjectedStatus = TestNativeRtcChannelEventHandler.OnChannelStreamInjectedStatus,
                onRemoteSubscribeFallbackToAudioOnly =
                    TestNativeRtcChannelEventHandler.OnChannelRemoteSubscribeFallbackToAudioOnly,
                onConnectionStateChanged = NativeRtcChannelEventHandler.OnChannelConnectionStateChanged,
                onLocalPublishFallbackToAudioOnly =
                    TestNativeRtcChannelEventHandler.OnChannelLocalPublishFallbackToAudioOnly,
                onTestEnd = TestNativeRtcChannelEventHandler.OnChannelTestEnd
            };
            AgorartcNative.begin_channel_event_test(caseFilePath, channelId, eventHandler);
        }

        public static void compare_dump_channel_event_test_result(string caseFilePath, string dumpFilePath,
            string channelId, IRtcChannelEventHandlerBase eventHandlerBase)
        {
            TestNativeRtcChannelEventHandler.channelEventHandler = eventHandlerBase;
            var eventHandler = new ChannelEventHandler
            {
                onWarning = TestNativeRtcChannelEventHandler.OnChannelWarning,
                onError = TestNativeRtcChannelEventHandler.OnChannelWarning,
                onJoinChannelSuccess = TestNativeRtcChannelEventHandler.OnChannelJoinChannelSuccess,
                onRejoinChannelSuccess = TestNativeRtcChannelEventHandler.OnChannelReJoinChannelSuccess,
                onLeaveChannel = TestNativeRtcChannelEventHandler.OnChannelLeaveChannel,
                onClientRoleChanged = TestNativeRtcChannelEventHandler.OnChannelClientRoleChanged,
                onUserJoined = TestNativeRtcChannelEventHandler.OnChannelUserJoined,
                onUserOffLine = TestNativeRtcChannelEventHandler.OnChannelUserOffLine,
                onConnectionLost = TestNativeRtcChannelEventHandler.OnChannelConnectionLost,
                onRequestToken = TestNativeRtcChannelEventHandler.OnChannelRequestToken,
                onTokenPrivilegeWillExpire = TestNativeRtcChannelEventHandler.OnChannelTokenPrivilegeWillExpire,
                onRtcStats = TestNativeRtcChannelEventHandler.OnChannelRtcStats,
                onNetworkQuality = TestNativeRtcChannelEventHandler.OnChannelNetworkQuality,
                onRemoteVideoStats = TestNativeRtcChannelEventHandler.OnChannelRemoteVideoStats,
                onRemoteAudioStats = TestNativeRtcChannelEventHandler.OnChannelRemoteAudioStats,
                onRemoteAudioStateChanged = TestNativeRtcChannelEventHandler.OnChannelRemoteAudioStateChanged,
                onActiveSpeaker = TestNativeRtcChannelEventHandler.OnChannelActiveSpeaker,
                onVideoSizeChanged = TestNativeRtcChannelEventHandler.OnChannelVideoSizeChanged,
                onRemoteVideoStateChanged = TestNativeRtcChannelEventHandler.OnChannelRemoteVideoStateChanged,
                onStreamMessage = TestNativeRtcChannelEventHandler.OnChannelStreamMessage,
                onStreamMessageError = TestNativeRtcChannelEventHandler.OnChannelStreamMessageError,
                onMediaRelayStateChanged = TestNativeRtcChannelEventHandler.OnChannelMediaRelayStateChanged2,
                onMediaRelayEvent = TestNativeRtcChannelEventHandler.OnChannelMediaRelayEvent2,
                onRtmpStreamingStateChanged = TestNativeRtcChannelEventHandler.OnChannelRtmpStreamingStateChanged,
                onTranscodingUpdated = TestNativeRtcChannelEventHandler.OnChannelTranscodingUpdated,
                onStreamInjectedStatus = TestNativeRtcChannelEventHandler.OnChannelStreamInjectedStatus,
                onRemoteSubscribeFallbackToAudioOnly =
                    TestNativeRtcChannelEventHandler.OnChannelRemoteSubscribeFallbackToAudioOnly,
                onConnectionStateChanged = NativeRtcChannelEventHandler.OnChannelConnectionStateChanged,
                onLocalPublishFallbackToAudioOnly =
                    TestNativeRtcChannelEventHandler.OnChannelLocalPublishFallbackToAudioOnly,
                onTestEnd = TestNativeRtcChannelEventHandler.OnChannelTestEnd
            };
            AgorartcNative.compare_dump_channel_event_test_result(caseFilePath, dumpFilePath, channelId,
                eventHandler);
        }

        public static void log_channel_event_case(string eventType, string parameter)
        {
            AgorartcNative.log_channel_event_case(eventType, parameter);
        }

        private static class TestNativeRtcEventHandler
        {
            internal static IRtcEngineEventHandlerBase engineEventHandler;

            internal static void OnJoinChannelSuccess(string namelessParameter1, uint uid, int elapsed)
            {
                engineEventHandler.OnJoinChannelSuccess(namelessParameter1, uid, elapsed);
            }

            internal static void OnReJoinChannelSuccess(string namelessParameter1, uint uid, int elapsed)
            {
                engineEventHandler.OnReJoinChannelSuccess(namelessParameter1, uid, elapsed);
            }

            internal static void OnConnectionLost()
            {
                engineEventHandler.OnConnectionLost();
            }

            internal static void OnConnectionInterrupted()
            {
                engineEventHandler.OnConnectionInterrupted();
            }

            internal static void OnLeaveChannel(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
                uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
                ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
                ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
                double cpuAppUsage,
                double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
                int memoryAppUsageInKbytes)
            {
                engineEventHandler.OnLeaveChannel(duration, txBytes, rxBytes, txAudioBytes, txVideoBytes,
                    rxAudioBytes,
                    rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate, txAudioKBitRate, rxVideoKBitRate,
                    txVideoKBitRate, lastmileDelay, txPacketLossRate, rxPacketLossRate, userCount, cpuAppUsage,
                    cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio, memoryAppUsageInKbytes);
            }

            internal static void OnRequestToken()
            {
                engineEventHandler.OnRequestToken();
            }

            internal static void OnUserJoined(uint uid, int elapsed)
            {
                engineEventHandler.OnUserJoined(uid, elapsed);
            }

            internal static void OnUserOffline(uint uid, int offLineReason)
            {
                engineEventHandler.OnUserOffline(uid, offLineReason);
            }

            internal static void OnAudioVolumeIndication(System.IntPtr uid, System.IntPtr volume, System.IntPtr vad,
                string[] channelId,
                int speakerNumber, int totalVolume)
            {
                if (speakerNumber <= 0) return;
                var uids = new int[speakerNumber];
                var volumes = new int[speakerNumber];
                var vads = new int[speakerNumber];
                Marshal.Copy(uid, uids, 0, speakerNumber);
                Marshal.Copy(volume, volumes, 0, speakerNumber);
                Marshal.Copy(vad, vads, 0, speakerNumber);

                engineEventHandler.OnAudioVolumeIndication(uids, volumes, vads, speakerNumber, totalVolume);
            }

            internal static void OnUserMuteAudio(uint uid, int muted)
            {
                engineEventHandler.OnUserMuteAudio(uid, muted);
            }

            internal static void OnWarning(int warn, string msg)
            {
                engineEventHandler.OnWarning(warn, msg);
            }

            internal static void OnError(int error, string msg)
            {
                engineEventHandler.OnError(error, msg);
            }

            internal static void OnRtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
                uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
                ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
                ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
                double cpuAppUsage,
                double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
                int memoryAppUsageInKbytes)
            {
                engineEventHandler.OnRtcStats(duration, txBytes, rxBytes, txAudioBytes, txVideoBytes, rxAudioBytes,
                    rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate, txAudioKBitRate, rxVideoKBitRate,
                    txVideoKBitRate, lastmileDelay, txPacketLossRate, rxPacketLossRate, userCount, cpuAppUsage,
                    cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio, memoryAppUsageInKbytes);
            }

            internal static void OnAudioMixingFinished()
            {
                engineEventHandler.OnAudioMixingFinished();
            }

            internal static void OnAudioRouteChanged(int route)
            {
                engineEventHandler.OnAudioRouteChanged(route);
            }

            internal static void OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed)
            {
                engineEventHandler.OnFirstRemoteVideoDecoded(uid, width, height, elapsed);
            }

            internal static void OnVideoSizeChanged(uint uid, int width, int height, int elapsed)
            {
                engineEventHandler.OnVideoSizeChanged(uid, width, height, elapsed);
            }

            internal static void OnClientRoleChanged(int oldRole, int newRole)
            {
                engineEventHandler.OnClientRoleChanged(oldRole, newRole);
            }

            internal static void OnUserMuteVideo(uint uid, int muted)
            {
                engineEventHandler.OnUserMuteVideo(uid, muted);
            }

            internal static void OnMicrophoneEnabled(int isEnabled)
            {
                engineEventHandler.OnMicrophoneEnabled(isEnabled);
            }

            internal static void OnApiExecuted(int err, string api, string result)
            {
                engineEventHandler.OnApiExecuted(err, api, result);
            }

            internal static void OnFirstLocalAudioFrame(int elapsed)
            {
                engineEventHandler.OnFirstLocalAudioFrame(elapsed);
            }

            internal static void OnFirstRemoteAudioFrame(uint userId, int elapsed)
            {
                engineEventHandler.OnFirstRemoteAudioFrame(userId, elapsed);
            }

            internal static void OnLastmileQuality(int quality)
            {
                engineEventHandler.OnLastmileQuality(quality);
            }

            internal static void OnAudioQuality(uint userId, int quality, ushort delay, ushort lost)
            {
                engineEventHandler.OnAudioQuality(userId, quality, delay, lost);
            }

            internal static void OnStreamInjectedStatus(string url, uint userId, int status)
            {
                engineEventHandler.OnStreamInjectedStatus(url, userId, status);
            }

            internal static void OnStreamUnpublished(string url)
            {
                engineEventHandler.OnStreamUnpublished(url);
            }

            internal static void OnStreamPublished(string url, int error)
            {
                engineEventHandler.OnStreamPublished(url, error);
            }

            internal static void OnStreamMessageError(uint userId, int streamId, int code, int missed, int cached)
            {
                engineEventHandler.OnStreamMessageError(userId, streamId, code, missed, cached);
            }

            internal static void OnStreamMessage(uint userId, int streamId, string data, uint length)
            {
                engineEventHandler.OnStreamMessage(userId, streamId, data, length);
            }

            internal static void OnConnectionBanned()
            {
                engineEventHandler.OnConnectionBanned();
            }

            internal static void OnRemoteVideoTransportStats(uint uid, ushort delay, ushort lost,
                ushort rxKBitRate)
            {
                engineEventHandler.OnRemoteVideoTransportStats(uid, delay, lost, rxKBitRate);
            }

            internal static void OnRemoteAudioTransportStats(uint uid, ushort delay, ushort lost,
                ushort rxKBitRate)
            {
                engineEventHandler.OnRemoteAudioTransportStats(uid, delay, lost, rxKBitRate);
            }

            internal static void OnTranscodingUpdated()
            {
                engineEventHandler.OnTranscodingUpdated();
            }

            internal static void OnAudioDeviceVolumeChanged(int deviceType, int volume, int muted)
            {
                engineEventHandler.OnAudioDeviceVolumeChanged(deviceType, volume, muted);
            }

            internal static void OnActiveSpeaker(uint userId)
            {
                engineEventHandler.OnActiveSpeaker(userId);
            }

            internal static void OnMediaEngineStartCallSuccess()
            {
                engineEventHandler.OnMediaEngineStartCallSuccess();
            }

            internal static void OnMediaEngineLoadSuccess()
            {
                engineEventHandler.OnMediaEngineLoadSuccess();
            }

            internal static void OnVideoStopped()
            {
                engineEventHandler.OnVideoStopped();
            }

            internal static void OnTokenPrivilegeWillExpire(string token)
            {
                engineEventHandler.OnTokenPrivilegeWillExpire(token);
            }

            internal static void OnNetworkQuality(uint uid, int txQuality, int rxQuality)
            {
                engineEventHandler.OnNetworkQuality(uid, txQuality, rxQuality);
            }

            internal static void OnLocalVideoStats(int sentBitrate, int sentFrameRate, int encoderOutputFrameRate,
                int rendererOutputFrameRate, int targetBitrate, int targetFrameRate, int qualityAdaptIndication,
                int encodedBitrate, int encodedFrameWidth, int encodedFrameHeight, int encodedFrameCount,
                int codecType)
            {
                engineEventHandler.OnLocalVideoStats(sentBitrate, sentFrameRate, encoderOutputFrameRate,
                    rendererOutputFrameRate, targetBitrate, targetFrameRate, qualityAdaptIndication, encodedBitrate,
                    encodedFrameWidth, encodedFrameHeight, encodedFrameCount, codecType);
            }

            internal static void OnRemoteVideoStats(uint uid, int delay, int width, int height,
                int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
                int rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime)
            {
                engineEventHandler.OnRemoteVideoStats(uid, delay, width, height, receivedBitrate,
                    decoderOutputFrameRate, rendererOutputFrameRate, packetLossRate, rxStreamType, totalFrozenTime,
                    frozenRate, totalActiveTime);
            }

            internal static void OnRemoteAudioStats(uint uid, int quality, int networkTransportDelay,
                int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate,
                int totalFrozenTime, int frozenRate, int totalActiveTime)
            {
                engineEventHandler.OnRemoteAudioStats(uid, quality, networkTransportDelay, jitterBufferDelay,
                    audioLossRate, numChannels, receivedSampleRate, receivedBitrate, totalFrozenTime, frozenRate,
                    totalActiveTime);
            }

            internal static void OnLocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate)
            {
                engineEventHandler.OnLocalAudioStats(numChannels, sentSampleRate, sentBitrate);
            }

            internal static void OnFirstLocalVideoFrame(int width, int height, int elapsed)
            {
                engineEventHandler.OnFirstLocalVideoFrame(width, height, elapsed);
            }

            internal static void OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed)
            {
                engineEventHandler.OnFirstRemoteVideoFrame(uid, width, height, elapsed);
            }

            internal static void OnUserEnableVideo(uint uid, int enabled)
            {
                engineEventHandler.OnUserEnableVideo(uid, enabled);
            }

            internal static void OnAudioDeviceStateChanged(string deviceId, int deviceType, int deviceState)
            {
                engineEventHandler.OnAudioDeviceStateChanged(deviceId, deviceType, deviceState);
            }

            internal static void OnCameraReady()
            {
                engineEventHandler.OnCameraReady();
            }

            internal static void OnCameraFocusAreaChanged(int x, int y, int width, int height)
            {
                engineEventHandler.OnCameraFocusAreaChanged(x, y, width, height);
            }

            internal static void OnCameraExposureAreaChanged(int x, int y, int width, int height)
            {
                engineEventHandler.OnCameraExposureAreaChanged(x, y, width, height);
            }

            internal static void OnRemoteAudioMixingBegin()
            {
                engineEventHandler.OnRemoteAudioMixingBegin();
            }

            internal static void OnRemoteAudioMixingEnd()
            {
                engineEventHandler.OnRemoteAudioMixingEnd();
            }

            internal static void OnAudioEffectFinished(int soundId)
            {
                engineEventHandler.OnAudioEffectFinished(soundId);
            }

            internal static void OnVideoDeviceStateChanged(string deviceId, int deviceType, int deviceState)
            {
                engineEventHandler.OnVideoDeviceStateChanged(deviceId, deviceType, deviceState);
            }

            internal static void OnRemoteVideoStateChanged(uint uid, int state, int reason, int elapsed)
            {
                engineEventHandler.OnRemoteVideoStateChanged(uid, state, reason, elapsed);
            }

            internal static void OnUserEnableLocalVideo(uint uid, int enabled)
            {
                engineEventHandler.OnUserEnableLocalVideo(uid, enabled);
            }

            internal static void OnLocalPublishFallbackToAudioOnly(int isFallbackOrRecover)
            {
                engineEventHandler.OnLocalPublishFallbackToAudioOnly(isFallbackOrRecover);
            }

            internal static void OnRemoteSubscribeFallbackToAudioOnly(uint uid, int isFallbackOrRecover)
            {
                engineEventHandler.OnRemoteSubscribeFallbackToAudioOnly(uid, isFallbackOrRecover);
            }

            internal static void OnConnectionStateChanged(int state, int reason)
            {
                engineEventHandler.OnConnectionStateChanged(state, reason);
            }

            internal static void OnRtmpStreamingStateChanged(string url, int state, int errCode)
            {
                engineEventHandler.OnRtmpStreamingStateChanged(url, state, errCode);
            }

            internal static void OnLocalUserRegistered(uint uid, string userAccount)
            {
                engineEventHandler.OnLocalUserRegistered(uid, userAccount);
            }

            internal static void OnUserInfoUpdated(uint uid, uint userUid, string userAccount)
            {
                engineEventHandler.OnUserInfoUpdated(uid, userUid, userAccount);
            }

            internal static void OnLocalAudioStateChanged(int state, int error)
            {
                engineEventHandler.OnLocalAudioStateChanged(state, error);
            }

            internal static void OnRemoteAudioStateChanged(uint uid, int state, int reason, int elapsed)
            {
                engineEventHandler.OnRemoteAudioStateChanged(uid, state, reason, elapsed);
            }

            internal static void OnAudioMixingStateChanged(int audioMixingStateType, int audioMixingErrorType)
            {
                engineEventHandler.OnAudioMixingStateChanged(audioMixingStateType, audioMixingErrorType);
            }

            internal static void OnFirstRemoteAudioDecoded(uint uid, int elapsed)
            {
                engineEventHandler.OnFirstRemoteAudioDecoded(uid, elapsed);
            }

            internal static void OnLocalVideoStateChanged(int localVideoState, int error)
            {
                engineEventHandler.OnLocalVideoStateChanged(localVideoState, error);
            }

            internal static void OnNetworkTypeChanged(int networkType)
            {
                engineEventHandler.OnNetworkTypeChanged(networkType);
            }

            internal static void OnLastmileProbeResult(int state, uint upLinkPacketLossRate, uint upLinkjitter,
                uint upLinkAvailableBandwidth, uint downLinkPacketLossRate, uint downLinkJitter,
                uint downLinkAvailableBandwidth, uint rtt)
            {
                engineEventHandler.OnLastmileProbeResult(state, upLinkPacketLossRate, upLinkjitter,
                    upLinkAvailableBandwidth, downLinkPacketLossRate, downLinkJitter, downLinkAvailableBandwidth, rtt);
            }

            internal static void OnChannelMediaRelayStateChanged(int state, int code)
            {
                engineEventHandler.OnChannelMediaRelayStateChanged(state, code);
            }

            internal static void OnChannelMediaRelayEvent(int code)
            {
                engineEventHandler.OnChannelMediaRelayEvent(code);
            }

            internal static void OnFacePositionChanged(int imageWidth, int imageHeight, int x, int y, int width,
                int height, int vecDistance, int numFaces)
            {
                engineEventHandler.OnFacePositionChanged(imageWidth, imageHeight, x, y, width, height, vecDistance,
                    numFaces);
            }

            internal static void OnTestEnd()
            {
                engineEventHandler.OnTestEnd();
            }
        }

        private static class TestNativeRtcChannelEventHandler
        {
            internal static IRtcChannelEventHandlerBase channelEventHandler;

            internal static void OnChannelWarning(string channelId, int warn, string msg)
            {
                channelEventHandler.OnChannelWarning(channelId, warn, msg);
            }

            internal static void OnChannelError(string channelId, int err, string msg)
            {
                channelEventHandler.OnChannelError(channelId, err, msg);
            }

            internal static void OnChannelJoinChannelSuccess(string channelId, uint uid, int elapsed)
            {
                channelEventHandler.OnChannelJoinChannelSuccess(channelId, uid, elapsed);
            }

            internal static void OnChannelReJoinChannelSuccess(string channelId, uint uid, int elapsed)
            {
                channelEventHandler.OnChannelReJoinChannelSuccess(channelId, uid, elapsed);
            }

            internal static void OnChannelLeaveChannel(string channelId, uint duration, uint txBytes, uint rxBytes,
                uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
                ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
                ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate,
                uint userCount,
                double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
                double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
            {
                channelEventHandler.OnChannelLeaveChannel(channelId, duration, txBytes, rxBytes,
                    txAudioBytes, txVideoBytes, rxAudioBytes, rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
                    txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay, txPacketLossRate,
                    rxPacketLossRate,
                    userCount, cpuAppUsage, cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
                    memoryAppUsageInKbytes);
            }

            internal static void OnChannelClientRoleChanged(string channelId, int oldRole, int newRole)
            {
                channelEventHandler.OnChannelClientRoleChanged(channelId, oldRole, newRole);
            }

            internal static void OnChannelUserJoined(string channelId, uint uid, int elapsed)
            {
                channelEventHandler.OnChannelUserJoined(channelId, uid, elapsed);
            }

            internal static void OnChannelUserOffLine(string channelId, uint uid, int reason)
            {
                channelEventHandler.OnChannelUserOffLine(channelId, uid, reason);
            }

            internal static void OnChannelConnectionLost(string channelId)
            {
                channelEventHandler.OnChannelConnectionLost(channelId);
            }

            internal static void OnChannelRequestToken(string channelId)
            {
                channelEventHandler.OnChannelRequestToken(channelId);
            }

            internal static void OnChannelTokenPrivilegeWillExpire(string channelId, string token)
            {
                channelEventHandler.OnChannelTokenPrivilegeWillExpire(channelId, token);
            }

            internal static void OnChannelRtcStats(string channelId, uint duration, uint txBytes, uint rxBytes,
                uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
                ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
                ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate,
                uint userCount,
                double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
                double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
            {
                channelEventHandler.OnChannelRtcStats(channelId, duration, txBytes, rxBytes,
                    txAudioBytes, txVideoBytes, rxAudioBytes, rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
                    txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay, txPacketLossRate,
                    rxPacketLossRate,
                    userCount, cpuAppUsage, cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
                    memoryAppUsageInKbytes);
            }

            internal static void OnChannelNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
            {
                channelEventHandler.OnChannelNetworkQuality(channelId, uid, txQuality, rxQuality);
            }

            internal static void OnChannelRemoteVideoStats(string channelId, uint uid, int delay, int width,
                int height,
                int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
                int rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime)
            {
                channelEventHandler.OnChannelRemoteVideoStats(channelId, uid, delay, width, height,
                    receivedBitrate, decoderOutputFrameRate, rendererOutputFrameRate, packetLossRate, rxStreamType,
                    totalFrozenTime, frozenRate, totalActiveTime);
            }

            internal static void OnChannelRemoteAudioStats(string channelId, uint uid, int quality,
                int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels,
                int receivedSampleRate,
                int receivedBitrate, int totalFrozenTime, int frozenRate, int totalActiveTime)
            {
                channelEventHandler.OnChannelRemoteAudioStats(channelId, uid, quality,
                    networkTransportDelay, jitterBufferDelay, audioLossRate, numChannels, receivedSampleRate,
                    receivedBitrate, totalFrozenTime, frozenRate, totalActiveTime);
            }

            internal static void OnChannelRemoteAudioStateChanged(string channelId, uint uid, int state, int reason,
                int elapsed)
            {
                channelEventHandler
                    .OnChannelRemoteAudioStateChanged(channelId, uid, state, reason, elapsed);
            }

            internal static void OnChannelActiveSpeaker(string channelId, uint uid)
            {
                channelEventHandler.OnChannelActiveSpeaker(channelId, uid);
            }

            internal static void
                OnChannelVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
            {
                channelEventHandler.OnChannelVideoSizeChanged(channelId, uid, width, height, rotation);
            }

            internal static void OnChannelRemoteVideoStateChanged(string channelId, uint uid, int state, int reason,
                int elapsed)
            {
                channelEventHandler
                    .OnChannelRemoteVideoStateChanged(channelId, uid, state, reason, elapsed);
            }

            internal static void
                OnChannelStreamMessage(string channelId, uint uid, int streamId, string data, uint length)
            {
                channelEventHandler.OnChannelStreamMessage(channelId, uid, streamId, data, length);
            }

            internal static void OnChannelStreamMessageError(string channelId, uint uid, int streamId, int code,
                int missed, int cached)
            {
                channelEventHandler
                    .OnChannelStreamMessageError(channelId, uid, streamId, code, missed, cached);
            }

            internal static void OnChannelMediaRelayStateChanged2(string channelId, int state, int code)
            {
                channelEventHandler.OnChannelMediaRelayStateChanged2(channelId, state, code);
            }

            internal static void OnChannelMediaRelayEvent2(string channelId, int code)
            {
                channelEventHandler.OnChannelMediaRelayEvent2(channelId, code);
            }

            internal static void OnChannelRtmpStreamingStateChanged(string channelId, string url, int state,
                int errCode)
            {
                channelEventHandler.OnChannelRtmpStreamingStateChanged(channelId, url, state, errCode);
            }

            internal static void OnChannelTranscodingUpdated(string channelId)
            {
                channelEventHandler.OnChannelTranscodingUpdated(channelId);
            }

            internal static void OnChannelStreamInjectedStatus(string channelId, string url, uint uid, int status)
            {
                channelEventHandler.OnChannelStreamInjectedStatus(channelId, url, uid, status);
            }

            internal static void OnChannelRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid,
                int isFallbackOrRecover)
            {
                channelEventHandler
                    .OnChannelRemoteSubscribeFallbackToAudioOnly(channelId, uid, isFallbackOrRecover);
            }

            internal static void OnChannelConnectionStateChanged(string channelId, int state, int reason)
            {
                channelEventHandler.OnChannelConnectionStateChanged(channelId, state, reason);
            }

            internal static void OnChannelLocalPublishFallbackToAudioOnly(string channelId, int isFallbackOrRecover)
            {
                channelEventHandler
                    .OnChannelLocalPublishFallbackToAudioOnly(channelId, isFallbackOrRecover);
            }

            internal static void OnChannelTestEnd(string channelId)
            {
                channelEventHandler.OnChannelTestEnd(channelId);
            }
        }
    }
}