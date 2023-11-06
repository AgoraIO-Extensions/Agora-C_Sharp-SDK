using System;
namespace Agora.Rtc
{
    public class AgoraEventType
    {
        #region terra IRtcEngineEventHandlerBase
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_EVENTHANDLERTYPE = "RtcEngineEventHandlerBase_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONERROR = "RtcEngineEventHandlerBase_onError";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONLASTMILEPROBERESULT = "RtcEngineEventHandlerBase_onLastmileProbeResult";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONLEAVECHANNEL = "RtcEngineEventHandlerBase_onLeaveChannel";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONRTCSTATS = "RtcEngineEventHandlerBase_onRtcStats";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIODEVICESTATECHANGED = "RtcEngineEventHandlerBase_onAudioDeviceStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOMIXINGPOSITIONCHANGED = "RtcEngineEventHandlerBase_onAudioMixingPositionChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOEFFECTFINISHED = "RtcEngineEventHandlerBase_onAudioEffectFinished";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONVIDEODEVICESTATECHANGED = "RtcEngineEventHandlerBase_onVideoDeviceStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONINTRAREQUESTRECEIVED = "RtcEngineEventHandlerBase_onIntraRequestReceived";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONUPLINKNETWORKINFOUPDATED = "RtcEngineEventHandlerBase_onUplinkNetworkInfoUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONDOWNLINKNETWORKINFOUPDATED = "RtcEngineEventHandlerBase_onDownlinkNetworkInfoUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONLASTMILEQUALITY = "RtcEngineEventHandlerBase_onLastmileQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONFIRSTLOCALVIDEOFRAME = "RtcEngineEventHandlerBase_onFirstLocalVideoFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONFIRSTLOCALVIDEOFRAMEPUBLISHED = "RtcEngineEventHandlerBase_onFirstLocalVideoFramePublished";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONLOCALVIDEOSTATECHANGED = "RtcEngineEventHandlerBase_onLocalVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONLOCALAUDIOSTATS = "RtcEngineEventHandlerBase_onLocalAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONCAMERAFOCUSAREACHANGED = "RtcEngineEventHandlerBase_onCameraFocusAreaChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONCAMERAEXPOSUREAREACHANGED = "RtcEngineEventHandlerBase_onCameraExposureAreaChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONFACEPOSITIONCHANGED = "RtcEngineEventHandlerBase_onFacePositionChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOMIXINGSTATECHANGED = "RtcEngineEventHandlerBase_onAudioMixingStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONRHYTHMPLAYERSTATECHANGED = "RtcEngineEventHandlerBase_onRhythmPlayerStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONCONNECTIONLOST = "RtcEngineEventHandlerBase_onConnectionLost";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONREQUESTTOKEN = "RtcEngineEventHandlerBase_onRequestToken";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONTOKENPRIVILEGEWILLEXPIRE = "RtcEngineEventHandlerBase_onTokenPrivilegeWillExpire";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONLICENSEVALIDATIONFAILURE = "RtcEngineEventHandlerBase_onLicenseValidationFailure";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONFIRSTLOCALAUDIOFRAMEPUBLISHED = "RtcEngineEventHandlerBase_onFirstLocalAudioFramePublished";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONLOCALAUDIOSTATECHANGED = "RtcEngineEventHandlerBase_onLocalAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONCONTENTINSPECTRESULT = "RtcEngineEventHandlerBase_onContentInspectResult";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONCLIENTROLECHANGED = "RtcEngineEventHandlerBase_onClientRoleChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONCLIENTROLECHANGEFAILED = "RtcEngineEventHandlerBase_onClientRoleChangeFailed";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIODEVICEVOLUMECHANGED = "RtcEngineEventHandlerBase_onAudioDeviceVolumeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONRTMPSTREAMINGSTATECHANGED = "RtcEngineEventHandlerBase_onRtmpStreamingStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONRTMPSTREAMINGEVENT = "RtcEngineEventHandlerBase_onRtmpStreamingEvent";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONTRANSCODINGUPDATED = "RtcEngineEventHandlerBase_onTranscodingUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOROUTINGCHANGED = "RtcEngineEventHandlerBase_onAudioRoutingChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONCHANNELMEDIARELAYSTATECHANGED = "RtcEngineEventHandlerBase_onChannelMediaRelayStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONLOCALPUBLISHFALLBACKTOAUDIOONLY = "RtcEngineEventHandlerBase_onLocalPublishFallbackToAudioOnly";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONCONNECTIONSTATECHANGED = "RtcEngineEventHandlerBase_onConnectionStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONWLACCMESSAGE = "RtcEngineEventHandlerBase_onWlAccMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONWLACCSTATS = "RtcEngineEventHandlerBase_onWlAccStats";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONNETWORKTYPECHANGED = "RtcEngineEventHandlerBase_onNetworkTypeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONENCRYPTIONERROR = "RtcEngineEventHandlerBase_onEncryptionError";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONPERMISSIONERROR = "RtcEngineEventHandlerBase_onPermissionError";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONUPLOADLOGRESULT = "RtcEngineEventHandlerBase_onUploadLogResult";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOPUBLISHSTATECHANGED = "RtcEngineEventHandlerBase_onAudioPublishStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONVIDEOPUBLISHSTATECHANGED = "RtcEngineEventHandlerBase_onVideoPublishStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONEXTENSIONEVENT = "RtcEngineEventHandlerBase_onExtensionEvent";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONEXTENSIONSTARTED = "RtcEngineEventHandlerBase_onExtensionStarted";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONEXTENSIONSTOPPED = "RtcEngineEventHandlerBase_onExtensionStopped";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONEXTENSIONERROR = "RtcEngineEventHandlerBase_onExtensionError";
        internal const string EVENT_RTCENGINEEVENTHANDLERBASE_ONSETRTMFLAGRESULT = "RtcEngineEventHandlerBase_onSetRtmFlagResult";
        #endregion terra IRtcEngineEventHandlerBase

        #region terra IRtcEngineEventHandler
        internal const string EVENT_RTCENGINEEVENTHANDLER_EVENTHANDLERTYPE = "RtcEngineEventHandler_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONJOINCHANNELSUCCESS = "RtcEngineEventHandler_onJoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREJOINCHANNELSUCCESS = "RtcEngineEventHandler_onRejoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONPROXYCONNECTED = "RtcEngineEventHandler_onProxyConnected";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOQUALITY = "RtcEngineEventHandler_onAudioQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOVOLUMEINDICATION = "RtcEngineEventHandler_onAudioVolumeIndication";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGFINISHED = "RtcEngineEventHandler_onAudioMixingFinished";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONNETWORKQUALITY = "RtcEngineEventHandler_onNetworkQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEVIDEODECODED = "RtcEngineEventHandler_onFirstRemoteVideoDecoded";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOSTATECHANGED = "RtcEngineEventHandler_onRemoteVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSIZECHANGED = "RtcEngineEventHandler_onVideoSizeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEVIDEOFRAME = "RtcEngineEventHandler_onFirstRemoteVideoFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERJOINED = "RtcEngineEventHandler_onUserJoined";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSEROFFLINE = "RtcEngineEventHandler_onUserOffline";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERMUTEAUDIO = "RtcEngineEventHandler_onUserMuteAudio";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERMUTEVIDEO = "RtcEngineEventHandler_onUserMuteVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERENABLEVIDEO = "RtcEngineEventHandler_onUserEnableVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERSTATECHANGED = "RtcEngineEventHandler_onUserStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERENABLELOCALVIDEO = "RtcEngineEventHandler_onUserEnableLocalVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOSTATS = "RtcEngineEventHandler_onRemoteAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATS = "RtcEngineEventHandler_onLocalVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOSTATS = "RtcEngineEventHandler_onRemoteVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCAMERAREADY = "RtcEngineEventHandler_onCameraReady";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSTOPPED = "RtcEngineEventHandler_onVideoStopped";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONINTERRUPTED = "RtcEngineEventHandler_onConnectionInterrupted";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONBANNED = "RtcEngineEventHandler_onConnectionBanned";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSTREAMMESSAGE = "RtcEngineEventHandler_onStreamMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSTREAMMESSAGEERROR = "RtcEngineEventHandler_onStreamMessageError";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEAUDIOFRAME = "RtcEngineEventHandler_onFirstRemoteAudioFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEAUDIODECODED = "RtcEngineEventHandler_onFirstRemoteAudioDecoded";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOSTATECHANGED = "RtcEngineEventHandler_onRemoteAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONACTIVESPEAKER = "RtcEngineEventHandler_onActiveSpeaker";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSNAPSHOTTAKEN = "RtcEngineEventHandler_onSnapshotTaken";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY = "RtcEngineEventHandler_onRemoteSubscribeFallbackToAudioOnly";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOTRANSPORTSTATS = "RtcEngineEventHandler_onRemoteAudioTransportStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOTRANSPORTSTATS = "RtcEngineEventHandler_onRemoteVideoTransportStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALUSERREGISTERED = "RtcEngineEventHandler_onLocalUserRegistered";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERINFOUPDATED = "RtcEngineEventHandler_onUserInfoUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERACCOUNTUPDATED = "RtcEngineEventHandler_onUserAccountUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOSUBSCRIBESTATECHANGED = "RtcEngineEventHandler_onAudioSubscribeStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSUBSCRIBESTATECHANGED = "RtcEngineEventHandler_onVideoSubscribeStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEORENDERINGTRACINGRESULT = "RtcEngineEventHandler_onVideoRenderingTracingResult";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOTRANSCODERERROR = "RtcEngineEventHandler_onLocalVideoTranscoderError";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOLAYOUTINFO = "RtcEngineEventHandler_onVideoLayoutInfo";
        #endregion terra IRtcEngineEventHandler

        #region terra IRtcEngineEventHandlerS
        internal const string EVENT_RTCENGINEEVENTHANDLERS_EVENTHANDLERTYPE = "RtcEngineEventHandlerS_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONJOINCHANNELSUCCESS = "RtcEngineEventHandlerS_onJoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONREJOINCHANNELSUCCESS = "RtcEngineEventHandlerS_onRejoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONPROXYCONNECTED = "RtcEngineEventHandlerS_onProxyConnected";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONAUDIOVOLUMEINDICATION = "RtcEngineEventHandlerS_onAudioVolumeIndication";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONNETWORKQUALITY = "RtcEngineEventHandlerS_onNetworkQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONREMOTEVIDEOSTATECHANGED = "RtcEngineEventHandlerS_onRemoteVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONVIDEOSIZECHANGED = "RtcEngineEventHandlerS_onVideoSizeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONFIRSTREMOTEVIDEOFRAME = "RtcEngineEventHandlerS_onFirstRemoteVideoFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONUSERJOINED = "RtcEngineEventHandlerS_onUserJoined";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONUSEROFFLINE = "RtcEngineEventHandlerS_onUserOffline";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONUSERMUTEAUDIO = "RtcEngineEventHandlerS_onUserMuteAudio";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONUSERMUTEVIDEO = "RtcEngineEventHandlerS_onUserMuteVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONUSERENABLEVIDEO = "RtcEngineEventHandlerS_onUserEnableVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONUSERSTATECHANGED = "RtcEngineEventHandlerS_onUserStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONREMOTEAUDIOSTATS = "RtcEngineEventHandlerS_onRemoteAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONLOCALVIDEOSTATS = "RtcEngineEventHandlerS_onLocalVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONREMOTEVIDEOSTATS = "RtcEngineEventHandlerS_onRemoteVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONSTREAMMESSAGE = "RtcEngineEventHandlerS_onStreamMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONSTREAMMESSAGEERROR = "RtcEngineEventHandlerS_onStreamMessageError";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONREMOTEAUDIOSTATECHANGED = "RtcEngineEventHandlerS_onRemoteAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONACTIVESPEAKER = "RtcEngineEventHandlerS_onActiveSpeaker";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONSNAPSHOTTAKEN = "RtcEngineEventHandlerS_onSnapshotTaken";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY = "RtcEngineEventHandlerS_onRemoteSubscribeFallbackToAudioOnly";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONAUDIOSUBSCRIBESTATECHANGED = "RtcEngineEventHandlerS_onAudioSubscribeStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONVIDEOSUBSCRIBESTATECHANGED = "RtcEngineEventHandlerS_onVideoSubscribeStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONVIDEORENDERINGTRACINGRESULT = "RtcEngineEventHandlerS_onVideoRenderingTracingResult";
        internal const string EVENT_RTCENGINEEVENTHANDLERS_ONLOCALVIDEOTRANSCODERERROR = "RtcEngineEventHandlerS_onLocalVideoTranscoderError";
        #endregion terra IRtcEngineEventHandlerS

        #region terra IRtcEngineEventHandlerEx
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_EVENTHANDLERTYPE = "RtcEngineEventHandlerEx_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONJOINCHANNELSUCCESS = "RtcEngineEventHandlerEx_onJoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREJOINCHANNELSUCCESS = "RtcEngineEventHandlerEx_onRejoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOQUALITY = "RtcEngineEventHandlerEx_onAudioQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOVOLUMEINDICATION = "RtcEngineEventHandlerEx_onAudioVolumeIndication";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLEAVECHANNEL = "RtcEngineEventHandlerEx_onLeaveChannel";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONRTCSTATS = "RtcEngineEventHandlerEx_onRtcStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKQUALITY = "RtcEngineEventHandlerEx_onNetworkQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONINTRAREQUESTRECEIVED = "RtcEngineEventHandlerEx_onIntraRequestReceived";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALVIDEOFRAMEPUBLISHED = "RtcEngineEventHandlerEx_onFirstLocalVideoFramePublished";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEODECODED = "RtcEngineEventHandlerEx_onFirstRemoteVideoDecoded";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEOSIZECHANGED = "RtcEngineEventHandlerEx_onVideoSizeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATECHANGED = "RtcEngineEventHandlerEx_onLocalVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATECHANGED = "RtcEngineEventHandlerEx_onRemoteVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEOFRAME = "RtcEngineEventHandlerEx_onFirstRemoteVideoFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERJOINED = "RtcEngineEventHandlerEx_onUserJoined";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSEROFFLINE = "RtcEngineEventHandlerEx_onUserOffline";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEAUDIO = "RtcEngineEventHandlerEx_onUserMuteAudio";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEVIDEO = "RtcEngineEventHandlerEx_onUserMuteVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLEVIDEO = "RtcEngineEventHandlerEx_onUserEnableVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLELOCALVIDEO = "RtcEngineEventHandlerEx_onUserEnableLocalVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERSTATECHANGED = "RtcEngineEventHandlerEx_onUserStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATS = "RtcEngineEventHandlerEx_onLocalAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATS = "RtcEngineEventHandlerEx_onRemoteAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATS = "RtcEngineEventHandlerEx_onLocalVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATS = "RtcEngineEventHandlerEx_onRemoteVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONLOST = "RtcEngineEventHandlerEx_onConnectionLost";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONINTERRUPTED = "RtcEngineEventHandlerEx_onConnectionInterrupted";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONBANNED = "RtcEngineEventHandlerEx_onConnectionBanned";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGE = "RtcEngineEventHandlerEx_onStreamMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGEERROR = "RtcEngineEventHandlerEx_onStreamMessageError";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREQUESTTOKEN = "RtcEngineEventHandlerEx_onRequestToken";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLICENSEVALIDATIONFAILURE = "RtcEngineEventHandlerEx_onLicenseValidationFailure";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONTOKENPRIVILEGEWILLEXPIRE = "RtcEngineEventHandlerEx_onTokenPrivilegeWillExpire";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALAUDIOFRAMEPUBLISHED = "RtcEngineEventHandlerEx_onFirstLocalAudioFramePublished";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIOFRAME = "RtcEngineEventHandlerEx_onFirstRemoteAudioFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIODECODED = "RtcEngineEventHandlerEx_onFirstRemoteAudioDecoded";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATECHANGED = "RtcEngineEventHandlerEx_onLocalAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATECHANGED = "RtcEngineEventHandlerEx_onRemoteAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONACTIVESPEAKER = "RtcEngineEventHandlerEx_onActiveSpeaker";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGED = "RtcEngineEventHandlerEx_onClientRoleChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGEFAILED = "RtcEngineEventHandlerEx_onClientRoleChangeFailed";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOTRANSPORTSTATS = "RtcEngineEventHandlerEx_onRemoteAudioTransportStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOTRANSPORTSTATS = "RtcEngineEventHandlerEx_onRemoteVideoTransportStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONSTATECHANGED = "RtcEngineEventHandlerEx_onConnectionStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCMESSAGE = "RtcEngineEventHandlerEx_onWlAccMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCSTATS = "RtcEngineEventHandlerEx_onWlAccStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKTYPECHANGED = "RtcEngineEventHandlerEx_onNetworkTypeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONENCRYPTIONERROR = "RtcEngineEventHandlerEx_onEncryptionError";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUPLOADLOGRESULT = "RtcEngineEventHandlerEx_onUploadLogResult";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERACCOUNTUPDATED = "RtcEngineEventHandlerEx_onUserAccountUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONSNAPSHOTTAKEN = "RtcEngineEventHandlerEx_onSnapshotTaken";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEORENDERINGTRACINGRESULT = "RtcEngineEventHandlerEx_onVideoRenderingTracingResult";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONSETRTMFLAGRESULT = "RtcEngineEventHandlerEx_onSetRtmFlagResult";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEOLAYOUTINFO = "RtcEngineEventHandlerEx_onVideoLayoutInfo";
        #endregion terra IRtcEngineEventHandlerEx

        #region terra IRtcEngineEventHandlerExS
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_EVENTHANDLERTYPE = "RtcEngineEventHandlerExS_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONJOINCHANNELSUCCESS = "RtcEngineEventHandlerExS_onJoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONREJOINCHANNELSUCCESS = "RtcEngineEventHandlerExS_onRejoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONAUDIOVOLUMEINDICATION = "RtcEngineEventHandlerExS_onAudioVolumeIndication";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONLEAVECHANNEL = "RtcEngineEventHandlerExS_onLeaveChannel";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONRTCSTATS = "RtcEngineEventHandlerExS_onRtcStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONNETWORKQUALITY = "RtcEngineEventHandlerExS_onNetworkQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONINTRAREQUESTRECEIVED = "RtcEngineEventHandlerExS_onIntraRequestReceived";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONFIRSTLOCALVIDEOFRAMEPUBLISHED = "RtcEngineEventHandlerExS_onFirstLocalVideoFramePublished";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONFIRSTREMOTEVIDEODECODED = "RtcEngineEventHandlerExS_onFirstRemoteVideoDecoded";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONVIDEOSIZECHANGED = "RtcEngineEventHandlerExS_onVideoSizeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONLOCALVIDEOSTATECHANGED = "RtcEngineEventHandlerExS_onLocalVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONREMOTEVIDEOSTATECHANGED = "RtcEngineEventHandlerExS_onRemoteVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONFIRSTREMOTEVIDEOFRAME = "RtcEngineEventHandlerExS_onFirstRemoteVideoFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERJOINED = "RtcEngineEventHandlerExS_onUserJoined";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONUSEROFFLINE = "RtcEngineEventHandlerExS_onUserOffline";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERMUTEAUDIO = "RtcEngineEventHandlerExS_onUserMuteAudio";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERMUTEVIDEO = "RtcEngineEventHandlerExS_onUserMuteVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERENABLEVIDEO = "RtcEngineEventHandlerExS_onUserEnableVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERSTATECHANGED = "RtcEngineEventHandlerExS_onUserStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONLOCALAUDIOSTATS = "RtcEngineEventHandlerExS_onLocalAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONREMOTEAUDIOSTATS = "RtcEngineEventHandlerExS_onRemoteAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONLOCALVIDEOSTATS = "RtcEngineEventHandlerExS_onLocalVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONREMOTEVIDEOSTATS = "RtcEngineEventHandlerExS_onRemoteVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONCONNECTIONLOST = "RtcEngineEventHandlerExS_onConnectionLost";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONCONNECTIONBANNED = "RtcEngineEventHandlerExS_onConnectionBanned";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONSTREAMMESSAGE = "RtcEngineEventHandlerExS_onStreamMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONSTREAMMESSAGEERROR = "RtcEngineEventHandlerExS_onStreamMessageError";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONREQUESTTOKEN = "RtcEngineEventHandlerExS_onRequestToken";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONLICENSEVALIDATIONFAILURE = "RtcEngineEventHandlerExS_onLicenseValidationFailure";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONTOKENPRIVILEGEWILLEXPIRE = "RtcEngineEventHandlerExS_onTokenPrivilegeWillExpire";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONFIRSTLOCALAUDIOFRAMEPUBLISHED = "RtcEngineEventHandlerExS_onFirstLocalAudioFramePublished";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONLOCALAUDIOSTATECHANGED = "RtcEngineEventHandlerExS_onLocalAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONREMOTEAUDIOSTATECHANGED = "RtcEngineEventHandlerExS_onRemoteAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONACTIVESPEAKER = "RtcEngineEventHandlerExS_onActiveSpeaker";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONCLIENTROLECHANGED = "RtcEngineEventHandlerExS_onClientRoleChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONCLIENTROLECHANGEFAILED = "RtcEngineEventHandlerExS_onClientRoleChangeFailed";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONCONNECTIONSTATECHANGED = "RtcEngineEventHandlerExS_onConnectionStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONWLACCMESSAGE = "RtcEngineEventHandlerExS_onWlAccMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONWLACCSTATS = "RtcEngineEventHandlerExS_onWlAccStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONNETWORKTYPECHANGED = "RtcEngineEventHandlerExS_onNetworkTypeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONENCRYPTIONERROR = "RtcEngineEventHandlerExS_onEncryptionError";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONUPLOADLOGRESULT = "RtcEngineEventHandlerExS_onUploadLogResult";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONSNAPSHOTTAKEN = "RtcEngineEventHandlerExS_onSnapshotTaken";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONVIDEORENDERINGTRACINGRESULT = "RtcEngineEventHandlerExS_onVideoRenderingTracingResult";
        internal const string EVENT_RTCENGINEEVENTHANDLEREXS_ONSETRTMFLAGRESULT = "RtcEngineEventHandlerExS_onSetRtmFlagResult";
        #endregion terra IRtcEngineEventHandlerExS

        #region terra IDirectCdnStreamingEventHandler
        internal const string EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATECHANGED = "DirectCdnStreamingEventHandler_onDirectCdnStreamingStateChanged";
        internal const string EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATS = "DirectCdnStreamingEventHandler_onDirectCdnStreamingStats";
        #endregion terra IDirectCdnStreamingEventHandler

        #region terra IAudioEncodedFrameObserver
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONRECORDAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_onRecordAudioEncodedFrame";
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONPLAYBACKAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_onPlaybackAudioEncodedFrame";
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONMIXEDAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_onMixedAudioEncodedFrame";
        #endregion terra IAudioEncodedFrameObserver

        #region terra IAudioFrameObserver
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING = "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing";
        #endregion terra IAudioFrameObserver

        #region terra IAudioFrameObserverBase
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_ONRECORDAUDIOFRAME = "AudioFrameObserverBase_onRecordAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_ONPLAYBACKAUDIOFRAME = "AudioFrameObserverBase_onPlaybackAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_ONMIXEDAUDIOFRAME = "AudioFrameObserverBase_onMixedAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_ONEARMONITORINGAUDIOFRAME = "AudioFrameObserverBase_onEarMonitoringAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_ONPLAYBACKAUDIOFRAMEBEFOREMIXING = "AudioFrameObserverBase_onPlaybackAudioFrameBeforeMixing";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_GETOBSERVEDAUDIOFRAMEPOSITION = "AudioFrameObserverBase_getObservedAudioFramePosition";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_GETPLAYBACKAUDIOPARAMS = "AudioFrameObserverBase_getPlaybackAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_GETRECORDAUDIOPARAMS = "AudioFrameObserverBase_getRecordAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_GETMIXEDAUDIOPARAMS = "AudioFrameObserverBase_getMixedAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVERBASE_GETEARMONITORINGAUDIOPARAMS = "AudioFrameObserverBase_getEarMonitoringAudioParams";
        #endregion terra IAudioFrameObserverBase

        #region terra IAudioSpectrumObserverBase
        internal const string EVENT_AUDIOSPECTRUMOBSERVERBASE_ONLOCALAUDIOSPECTRUM = "AudioSpectrumObserverBase_onLocalAudioSpectrum";
        #endregion terra IAudioSpectrumObserverBase

        #region terra IAudioSpectrumObserver
        internal const string EVENT_AUDIOSPECTRUMOBSERVER_ONREMOTEAUDIOSPECTRUM = "AudioSpectrumObserver_onRemoteAudioSpectrum";
        #endregion terra IAudioSpectrumObserver

        #region terra IAudioSpectrumObserverS
        internal const string EVENT_AUDIOSPECTRUMOBSERVERS_ONREMOTEAUDIOSPECTRUM = "AudioSpectrumObserverS_onRemoteAudioSpectrum";
        #endregion terra IAudioSpectrumObserverS

        #region terra IAudioPcmFrameSink
        internal const string EVENT_AUDIOPCMFRAMESINK_ONFRAME = "AudioPcmFrameSink_onFrame";
        #endregion terra IAudioPcmFrameSink

        #region terra IMediaPlayerCustomDataProvider
        internal const string EVENT_MEDIAPLAYERCUSTOMDATAPROVIDER_ONREADDATA = "MediaPlayerCustomDataProvider_onReadData";
        internal const string EVENT_MEDIAPLAYERCUSTOMDATAPROVIDER_ONSEEK = "MediaPlayerCustomDataProvider_onSeek";
        #endregion terra IMediaPlayerCustomDataProvider

        #region terra IMediaPlayerSourceObserver
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSOURCESTATECHANGED = "MediaPlayerSourceObserver_onPlayerSourceStateChanged";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPOSITIONCHANGED = "MediaPlayerSourceObserver_onPositionChanged";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYEREVENT = "MediaPlayerSourceObserver_onPlayerEvent";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONMETADATA = "MediaPlayerSourceObserver_onMetaData";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYBUFFERUPDATED = "MediaPlayerSourceObserver_onPlayBufferUpdated";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPRELOADEVENT = "MediaPlayerSourceObserver_onPreloadEvent";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONCOMPLETED = "MediaPlayerSourceObserver_onCompleted";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAGORACDNTOKENWILLEXPIRE = "MediaPlayerSourceObserver_onAgoraCDNTokenWillExpire";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSRCINFOCHANGED = "MediaPlayerSourceObserver_onPlayerSrcInfoChanged";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERINFOUPDATED = "MediaPlayerSourceObserver_onPlayerInfoUpdated";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERCACHESTATS = "MediaPlayerSourceObserver_onPlayerCacheStats";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERPLAYBACKSTATS = "MediaPlayerSourceObserver_onPlayerPlaybackStats";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAUDIOVOLUMEINDICATION = "MediaPlayerSourceObserver_onAudioVolumeIndication";
        #endregion terra IMediaPlayerSourceObserver

        #region terra IMediaRecorderObserver
        internal const string EVENT_MEDIARECORDEROBSERVER_ONRECORDERSTATECHANGED = "MediaRecorderObserver_onRecorderStateChanged";
        internal const string EVENT_MEDIARECORDEROBSERVER_ONRECORDERINFOUPDATED = "MediaRecorderObserver_onRecorderInfoUpdated";
        #endregion terra IMediaRecorderObserver

        #region terra IMediaRecorderObserverS
        internal const string EVENT_MEDIARECORDEROBSERVERS_ONRECORDERSTATECHANGED = "MediaRecorderObserverS_onRecorderStateChanged";
        internal const string EVENT_MEDIARECORDEROBSERVERS_ONRECORDERINFOUPDATED = "MediaRecorderObserverS_onRecorderInfoUpdated";
        #endregion terra IMediaRecorderObserverS

        #region terra IMetadataObserverBase
        internal const string EVENT_METADATAOBSERVERBASE_GETMAXMETADATASIZE = "MetadataObserverBase_getMaxMetadataSize";
        #endregion terra IMetadataObserverBase

        #region terra IMetadataObserver
        internal const string EVENT_METADATAOBSERVER_ONREADYTOSENDMETADATA = "MetadataObserver_onReadyToSendMetadata";
        internal const string EVENT_METADATAOBSERVER_ONMETADATARECEIVED = "MetadataObserver_onMetadataReceived";
        #endregion terra IMetadataObserver

        #region terra IMetadataObserverS
        internal const string EVENT_METADATAOBSERVERS_ONREADYTOSENDMETADATA = "MetadataObserverS_onReadyToSendMetadata";
        internal const string EVENT_METADATAOBSERVERS_ONMETADATARECEIVED = "MetadataObserverS_onMetadataReceived";
        #endregion terra IMetadataObserverS

        #region terra IMusicContentCenterEventHandler
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCHARTSRESULT = "MusicContentCenterEventHandler_onMusicChartsResult";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCOLLECTIONRESULT = "MusicContentCenterEventHandler_onMusicCollectionResult";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONLYRICRESULT = "MusicContentCenterEventHandler_onLyricResult";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONSONGSIMPLEINFORESULT = "MusicContentCenterEventHandler_onSongSimpleInfoResult";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONPRELOADEVENT = "MusicContentCenterEventHandler_onPreLoadEvent";
        #endregion terra IMusicContentCenterEventHandler

        #region terra IVideoEncodedFrameObserver
        internal const string EVENT_VIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED = "VideoEncodedFrameObserver_onEncodedVideoFrameReceived";
        #endregion terra IVideoEncodedFrameObserver

        #region terra IVideoEncodedFrameObserverS
        internal const string EVENT_VIDEOENCODEDFRAMEOBSERVERS_ONENCODEDVIDEOFRAMERECEIVED = "VideoEncodedFrameObserverS_onEncodedVideoFrameReceived";
        #endregion terra IVideoEncodedFrameObserverS

        #region terra IVideoFrameObserverBase
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_ONCAPTUREVIDEOFRAME = "VideoFrameObserverBase_onCaptureVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_ONPREENCODEVIDEOFRAME = "VideoFrameObserverBase_onPreEncodeVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_ONMEDIAPLAYERVIDEOFRAME = "VideoFrameObserverBase_onMediaPlayerVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_ONTRANSCODEDVIDEOFRAME = "VideoFrameObserverBase_onTranscodedVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_GETVIDEOFRAMEPROCESSMODE = "VideoFrameObserverBase_getVideoFrameProcessMode";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_GETVIDEOFORMATPREFERENCE = "VideoFrameObserverBase_getVideoFormatPreference";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_GETROTATIONAPPLIED = "VideoFrameObserverBase_getRotationApplied";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_GETMIRRORAPPLIED = "VideoFrameObserverBase_getMirrorApplied";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_GETOBSERVEDFRAMEPOSITION = "VideoFrameObserverBase_getObservedFramePosition";
        internal const string EVENT_VIDEOFRAMEOBSERVERBASE_ISEXTERNAL = "VideoFrameObserverBase_isExternal";
        #endregion terra IVideoFrameObserverBase

        #region terra IVideoFrameObserver
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONRENDERVIDEOFRAME = "VideoFrameObserver_onRenderVideoFrame";
        #endregion terra IVideoFrameObserver

        #region terra IVideoFrameObserverS
        internal const string EVENT_VIDEOFRAMEOBSERVERS_ONRENDERVIDEOFRAME = "VideoFrameObserverS_onRenderVideoFrame";
        #endregion terra IVideoFrameObserverS

        #region terra IH265TranscoderObserver
        internal const string EVENT_H265TRANSCODEROBSERVER_ONENABLETRANSCODE = "H265TranscoderObserver_onEnableTranscode";
        internal const string EVENT_H265TRANSCODEROBSERVER_ONQUERYCHANNEL = "H265TranscoderObserver_onQueryChannel";
        internal const string EVENT_H265TRANSCODEROBSERVER_ONTRIGGERTRANSCODE = "H265TranscoderObserver_onTriggerTranscode";
        #endregion terra IH265TranscoderObserver

        #region IRtmEventHandler
        internal const string EVENT_RTMEVENTHANDLER_ONMESSAGEEVENT = "RtmEventHandler_onMessageEvent";
        internal const string EVENT_RTMEVENTHANDLER_ONPRESENCEEVENT = "RtmEventHandler_onPresenceEvent";
        internal const string EVENT_RTMEVENTHANDLER_ONTOPICEVENT = "RtmEventHandler_onTopicEvent";
        internal const string EVENT_RTMEVENTHANDLER_ONLOCKEVENT = "RtmEventHandler_onLockEvent";
        internal const string EVENT_RTMEVENTHANDLER_ONSTORAGEEVENT = "RtmEventHandler_onStorageEvent";
        internal const string EVENT_RTMEVENTHANDLER_ONJOINRESULT = "RtmEventHandler_onJoinResult";
        internal const string EVENT_RTMEVENTHANDLER_ONLEAVERESULT = "RtmEventHandler_onLeaveResult";
        internal const string EVENT_RTMEVENTHANDLER_ONJOINTOPICRESULT = "RtmEventHandler_onJoinTopicResult";
        internal const string EVENT_RTMEVENTHANDLER_ONLEAVETOPICRESULT = "RtmEventHandler_onLeaveTopicResult";
        internal const string EVENT_RTMEVENTHANDLER_ONSUBSCRIBETOPICRESULT = "RtmEventHandler_onSubscribeTopicResult";
        internal const string EVENT_RTMEVENTHANDLER_ONCONNECTIONSTATECHANGE = "RtmEventHandler_onConnectionStateChange";
        internal const string EVENT_RTMEVENTHANDLER_ONTOKENPRIVILEGEWILLEXPIRE = "RtmEventHandler_onTokenPrivilegeWillExpire";
        internal const string EVENT_RTMEVENTHANDLER_ONSUBSCRIBERESULT = "RtmEventHandler_onSubscribeResult";
        internal const string EVENT_RTMEVENTHANDLER_ONPUBLISHRESULT = "RtmEventHandler_onPublishResult";
        internal const string EVENT_RTMEVENTHANDLER_ONLOGINRESULT = "RtmEventHandler_onLoginResult";
        internal const string EVENT_RTMEVENTHANDLER_ONSETCHANNELMETADATARESULT = "RtmEventHandler_onSetChannelMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONUPDATECHANNELMETADATARESULT = "RtmEventHandler_onUpdateChannelMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONREMOVECHANNELMETADATARESULT = "RtmEventHandler_onRemoveChannelMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONGETCHANNELMETADATARESULT = "RtmEventHandler_onGetChannelMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONSETUSERMETADATARESULT = "RtmEventHandler_onSetUserMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONUPDATEUSERMETADATARESULT = "RtmEventHandler_onUpdateUserMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONREMOVEUSERMETADATARESULT = "RtmEventHandler_onRemoveUserMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONGETUSERMETADATARESULT = "RtmEventHandler_onGetUserMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONSUBSCRIBEUSERMETADATARESULT = "RtmEventHandler_onSubscribeUserMetadataResult";
        internal const string EVENT_RTMEVENTHANDLER_ONSETLOCKRESULT = "RtmEventHandler_onSetLockResult";
        internal const string EVENT_RTMEVENTHANDLER_ONREMOVELOCKRESULT = "RtmEventHandler_onRemoveLockResult";
        internal const string EVENT_RTMEVENTHANDLER_ONRELEASELOCKRESULT = "RtmEventHandler_onReleaseLockResult";
        internal const string EVENT_RTMEVENTHANDLER_ONACQUIRELOCKRESULT = "RtmEventHandler_onAcquireLockResult";
        internal const string EVENT_RTMEVENTHANDLER_ONREVOKELOCKRESULT = "RtmEventHandler_onRevokeLockResult";
        internal const string EVENT_RTMEVENTHANDLER_ONGETLOCKSRESULT = "RtmEventHandler_onGetLocksResult";
        internal const string EVENT_RTMEVENTHANDLER_ONWHONOWRESULT = "RtmEventHandler_onWhoNowResult";
        internal const string EVENT_RTMEVENTHANDLER_ONWHERENOWRESULT = "RtmEventHandler_onWhereNowResult";
        internal const string EVENT_RTMEVENTHANDLER_ONPRESENCESETSTATERESULT = "RtmEventHandler_onPresenceSetStateResult";
        internal const string EVENT_RTMEVENTHANDLER_ONPRESENCEREMOVESTATERESULT = "RtmEventHandler_onPresenceRemoveStateResult";
        internal const string EVENT_RTMEVENTHANDLER_ONPRESENCEGETSTATERESULT = "RtmEventHandler_onPresenceGetStateResult";
        #endregion

    }
}
