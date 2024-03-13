using System;
namespace Agora.Rtc
{
    public class AgoraEventType
    {
        #region IRtcEngineEventHandler Start
        internal const string EVENT_RTCENGINEEVENTHANDLER_EVENTHANDLERTYPE = "RtcEngineEventHandler_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONJOINCHANNELSUCCESS = "RtcEngineEventHandler_onJoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREJOINCHANNELSUCCESS = "RtcEngineEventHandler_onRejoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONPROXYCONNECTED = "RtcEngineEventHandler_onProxyConnected";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONERROR = "RtcEngineEventHandler_onError";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOQUALITY = "RtcEngineEventHandler_onAudioQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEPROBERESULT = "RtcEngineEventHandler_onLastmileProbeResult";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOVOLUMEINDICATION = "RtcEngineEventHandler_onAudioVolumeIndication";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLEAVECHANNEL = "RtcEngineEventHandler_onLeaveChannel";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONRTCSTATS = "RtcEngineEventHandler_onRtcStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICESTATECHANGED = "RtcEngineEventHandler_onAudioDeviceStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGPOSITIONCHANGED = "RtcEngineEventHandler_onAudioMixingPositionChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGFINISHED = "RtcEngineEventHandler_onAudioMixingFinished";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOEFFECTFINISHED = "RtcEngineEventHandler_onAudioEffectFinished";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEODEVICESTATECHANGED = "RtcEngineEventHandler_onVideoDeviceStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONNETWORKQUALITY = "RtcEngineEventHandler_onNetworkQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONINTRAREQUESTRECEIVED = "RtcEngineEventHandler_onIntraRequestReceived";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUPLINKNETWORKINFOUPDATED = "RtcEngineEventHandler_onUplinkNetworkInfoUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONDOWNLINKNETWORKINFOUPDATED = "RtcEngineEventHandler_onDownlinkNetworkInfoUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEQUALITY = "RtcEngineEventHandler_onLastmileQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTLOCALVIDEOFRAME = "RtcEngineEventHandler_onFirstLocalVideoFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTLOCALVIDEOFRAMEPUBLISHED = "RtcEngineEventHandler_onFirstLocalVideoFramePublished";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEVIDEODECODED = "RtcEngineEventHandler_onFirstRemoteVideoDecoded";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSIZECHANGED = "RtcEngineEventHandler_onVideoSizeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATECHANGED = "RtcEngineEventHandler_onLocalVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOSTATECHANGED = "RtcEngineEventHandler_onRemoteVideoStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEVIDEOFRAME = "RtcEngineEventHandler_onFirstRemoteVideoFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERJOINED = "RtcEngineEventHandler_onUserJoined";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSEROFFLINE = "RtcEngineEventHandler_onUserOffline";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERMUTEAUDIO = "RtcEngineEventHandler_onUserMuteAudio";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERMUTEVIDEO = "RtcEngineEventHandler_onUserMuteVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERENABLEVIDEO = "RtcEngineEventHandler_onUserEnableVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERSTATECHANGED = "RtcEngineEventHandler_onUserStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERENABLELOCALVIDEO = "RtcEngineEventHandler_onUserEnableLocalVideo";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAPICALLEXECUTED = "RtcEngineEventHandler_onApiCallExecuted";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALAUDIOSTATS = "RtcEngineEventHandler_onLocalAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOSTATS = "RtcEngineEventHandler_onRemoteAudioStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATS = "RtcEngineEventHandler_onLocalVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOSTATS = "RtcEngineEventHandler_onRemoteVideoStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCAMERAREADY = "RtcEngineEventHandler_onCameraReady";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCAMERAFOCUSAREACHANGED = "RtcEngineEventHandler_onCameraFocusAreaChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCAMERAEXPOSUREAREACHANGED = "RtcEngineEventHandler_onCameraExposureAreaChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFACEPOSITIONCHANGED = "RtcEngineEventHandler_onFacePositionChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSTOPPED = "RtcEngineEventHandler_onVideoStopped";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGSTATECHANGED = "RtcEngineEventHandler_onAudioMixingStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONRHYTHMPLAYERSTATECHANGED = "RtcEngineEventHandler_onRhythmPlayerStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONLOST = "RtcEngineEventHandler_onConnectionLost";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONINTERRUPTED = "RtcEngineEventHandler_onConnectionInterrupted";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONBANNED = "RtcEngineEventHandler_onConnectionBanned";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSTREAMMESSAGE = "RtcEngineEventHandler_onStreamMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSTREAMMESSAGEERROR = "RtcEngineEventHandler_onStreamMessageError";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREQUESTTOKEN = "RtcEngineEventHandler_onRequestToken";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONTOKENPRIVILEGEWILLEXPIRE = "RtcEngineEventHandler_onTokenPrivilegeWillExpire";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLICENSEVALIDATIONFAILURE = "RtcEngineEventHandler_onLicenseValidationFailure";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTLOCALAUDIOFRAMEPUBLISHED = "RtcEngineEventHandler_onFirstLocalAudioFramePublished";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEAUDIOFRAME = "RtcEngineEventHandler_onFirstRemoteAudioFrame";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEAUDIODECODED = "RtcEngineEventHandler_onFirstRemoteAudioDecoded";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALAUDIOSTATECHANGED = "RtcEngineEventHandler_onLocalAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOSTATECHANGED = "RtcEngineEventHandler_onRemoteAudioStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONACTIVESPEAKER = "RtcEngineEventHandler_onActiveSpeaker";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONTENTINSPECTRESULT = "RtcEngineEventHandler_onContentInspectResult";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSNAPSHOTTAKEN = "RtcEngineEventHandler_onSnapshotTaken";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCLIENTROLECHANGED = "RtcEngineEventHandler_onClientRoleChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCLIENTROLECHANGEFAILED = "RtcEngineEventHandler_onClientRoleChangeFailed";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICEVOLUMECHANGED = "RtcEngineEventHandler_onAudioDeviceVolumeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGSTATECHANGED = "RtcEngineEventHandler_onRtmpStreamingStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGEVENT = "RtcEngineEventHandler_onRtmpStreamingEvent";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONTRANSCODINGUPDATED = "RtcEngineEventHandler_onTranscodingUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOROUTINGCHANGED = "RtcEngineEventHandler_onAudioRoutingChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCHANNELMEDIARELAYSTATECHANGED = "RtcEngineEventHandler_onChannelMediaRelayStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCHANNELMEDIARELAYEVENT = "RtcEngineEventHandler_onChannelMediaRelayEvent";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALPUBLISHFALLBACKTOAUDIOONLY = "RtcEngineEventHandler_onLocalPublishFallbackToAudioOnly";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY = "RtcEngineEventHandler_onRemoteSubscribeFallbackToAudioOnly";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOTRANSPORTSTATS = "RtcEngineEventHandler_onRemoteAudioTransportStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOTRANSPORTSTATS = "RtcEngineEventHandler_onRemoteVideoTransportStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONSTATECHANGED = "RtcEngineEventHandler_onConnectionStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONWLACCMESSAGE = "RtcEngineEventHandler_onWlAccMessage";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONWLACCSTATS = "RtcEngineEventHandler_onWlAccStats";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONNETWORKTYPECHANGED = "RtcEngineEventHandler_onNetworkTypeChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONENCRYPTIONERROR = "RtcEngineEventHandler_onEncryptionError";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONPERMISSIONERROR = "RtcEngineEventHandler_onPermissionError";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALUSERREGISTERED = "RtcEngineEventHandler_onLocalUserRegistered";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERINFOUPDATED = "RtcEngineEventHandler_onUserInfoUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUPLOADLOGRESULT = "RtcEngineEventHandler_onUploadLogResult";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOSUBSCRIBESTATECHANGED = "RtcEngineEventHandler_onAudioSubscribeStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSUBSCRIBESTATECHANGED = "RtcEngineEventHandler_onVideoSubscribeStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOPUBLISHSTATECHANGED = "RtcEngineEventHandler_onAudioPublishStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOPUBLISHSTATECHANGED = "RtcEngineEventHandler_onVideoPublishStateChanged";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONEVENT = "RtcEngineEventHandler_onExtensionEvent";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTARTED = "RtcEngineEventHandler_onExtensionStarted";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTOPPED = "RtcEngineEventHandler_onExtensionStopped";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONERROR = "RtcEngineEventHandler_onExtensionError";

        internal const string EVENT_RTCENGINEEVENTHANDLER_onExtensionEventWithContext = "RtcEngineEventHandler_onExtensionEventWithContext";
        internal const string EVENT_RTCENGINEEVENTHANDLER_onExtensionStartedWithContext = "RtcEngineEventHandler_onExtensionStartedWithContext";
        internal const string EVENT_RTCENGINEEVENTHANDLER_onExtensionStoppedWithContext = "RtcEngineEventHandler_onExtensionStoppedWithContext";
        internal const string EVENT_RTCENGINEEVENTHANDLER_onExtensionErrorWithContext = "RtcEngineEventHandler_onExtensionErrorWithContext";



        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERACCOUNTUPDATED = "RtcEngineEventHandler_onUserAccountUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOTRANSCODERERROR = "RtcEngineEventHandler_onLocalVideoTranscoderError";
        #endregion

        #region IRtcEngineEventHandlerEx Start
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_EVENTHANDLERTYPE = "RtcEngineEventHandlerEx_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONJOINCHANNELSUCCESS = "RtcEngineEventHandlerEx_onJoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREJOINCHANNELSUCCESS = "RtcEngineEventHandlerEx_onRejoinChannelSuccess";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOQUALITY = "RtcEngineEventHandlerEx_onAudioQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOVOLUMEINDICATION = "RtcEngineEventHandlerEx_onAudioVolumeIndication";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLEAVECHANNEL = "RtcEngineEventHandlerEx_onLeaveChannel";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONRTCSTATS = "RtcEngineEventHandlerEx_onRtcStats";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKQUALITY = "RtcEngineEventHandlerEx_onNetworkQuality";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONINTRAREQUESTRECEIVED = "RtcEngineEventHandlerEx_onIntraRequestReceived";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALVIDEOFRAME = "RtcEngineEventHandlerEx_onFirstLocalVideoFrame";
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
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOMETADATARECEIVED = "RtcEngineEventHandlerEx_onAudioMetadataReceived";
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
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONTRANSCODEDSTREAMLAYOUTINFO = "RtcEngineEventHandlerEx_onTranscodedStreamLayoutInfo";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEORENDERINGTRACINGRESULT = "RtcEngineEventHandlerEx_onVideoRenderingTracingResult";
        #endregion

        #region
        internal const string EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATECHANGED = "DirectCdnStreamingEventHandler_onDirectCdnStreamingStateChanged";
        internal const string EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATS = "DirectCdnStreamingEventHandler_onDirectCdnStreamingStats";
        #endregion

        #region IAudioEncodedFrameObserver Start
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONRECORDAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_OnRecordAudioEncodedFrame";
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONPLAYBACKAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_OnPlaybackAudioEncodedFrame";
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONMIXEDAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_OnMixedAudioEncodedFrame";
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONPUBLISHAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_OnPublishAudioEncodedFrame";
        #endregion

        #region IAudioFrameObserver Start
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONRECORDAUDIOFRAME = "AudioFrameObserver_onRecordAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONPUBLISHAUDIOFRAME = "AudioFrameObserver_onPublishAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAME = "AudioFrameObserver_onPlaybackAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONMIXEDAUDIOFRAME = "AudioFrameObserver_onMixedAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONEARMONITORINGAUDIOFRAME = "AudioFrameObserver_onEarMonitoringAudioFrame";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING = "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING2 = "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing2";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETOBSERVEDAUDIOFRAMEPOSITION = "AudioFrameObserver_getObservedAudioFramePosition";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETPLAYBACKAUDIOPARAMS = "AudioFrameObserver_getPlaybackAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETPUBLISHAUDIOPARAMS = "AudioFrameObserver_getPublishAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETRECORDAUDIOPARAMS = "AudioFrameObserver_getRecordAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETMIXEDAUDIOPARAMS = "AudioFrameObserver_getMixedAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETEARMONITORINGAUDIOPARAMS = "AudioFrameObserver_getEarMonitoringAudioParams";

        #endregion

        #region IAudioSpectrumObserver Start
        internal const string EVENT_AUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM = "AudioSpectrumObserver_onLocalAudioSpectrum";
        internal const string EVENT_AUDIOSPECTRUMOBSERVER_ONREMOTEAUDIOSPECTRUM = "AudioSpectrumObserver_onRemoteAudioSpectrum";
        #endregion

        #region IMediaPlayerAudioFrameObserver Start
        internal const string EVENT_MEDIAPLAYERAUDIOFRAMEOBSERVER_ONFRAME = "MediaPlayerAudioFrameObserver_onFrame";
        #endregion

        #region IMediaPlayerCustomDataProvider Start
        internal const string EVENT_MEDIAPLAYERCUSTOMDATAPROVIDER_ONREADDATA = "MediaPlayerCustomDataProvider_onReadData";
        internal const string EVENT_MEDIAPLAYERCUSTOMDATAPROVIDER_ONSEEK = "MediaPlayerCustomDataProvider_onSeek";
        #endregion

        #region IMediaPlayerSourceObserver Start
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
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAUDIOVOLUMEINDICATION = "MediaPlayerSourceObserver_onAudioVolumeIndication";
        #endregion

        #region IMediaRecorderObserver Start
        internal const string EVENT_MEDIARECORDEROBSERVER_ONRECORDERSTATECHANGED = "MediaRecorderObserver_onRecorderStateChanged";
        internal const string EVENT_MEDIARECORDEROBSERVER_ONRECORDERINFOUPDATED = "MediaRecorderObserver_onRecorderInfoUpdated";
        #endregion

        #region IMetadataObserver Start
        internal const string EVENT_METADATAOBSERVER_GETMAXMETADATASIZE = "MetadataObserver_getMaxMetadataSize";
        internal const string EVENT_METADATAOBSERVER_ONREADYTOSENDMETADATA = "MetadataObserver_onReadyToSendMetadata";
        internal const string EVENT_METADATAOBSERVER_ONMETADATARECEIVED = "MetadataObserver_onMetadataReceived";
        #endregion

        #region IMusicContentCenterEventHandler Start
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCHARTSRESULT = "MusicContentCenterEventHandler_onMusicChartsResult";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCOLLECTIONRESULT = "MusicContentCenterEventHandler_onMusicCollectionResult";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONLYRICRESULT = "MusicContentCenterEventHandler_onLyricResult";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONSONGSIMPLEINFORESULT = "MusicContentCenterEventHandler_onSongSimpleInfoResult";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONPRELOADEVENT = "MusicContentCenterEventHandler_onPreLoadEvent";
        #endregion

        #region IVideoEncodedFrameObserver Start
        internal const string EVENT_VIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED = "VideoEncodedFrameObserver_onEncodedVideoFrameReceived";
        #endregion

        #region IVideoFrameObserver Start
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONCAPTUREVIDEOFRAME = "VideoFrameObserver_onCaptureVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONPREENCODEVIDEOFRAME = "VideoFrameObserver_onPreEncodeVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONSECONDARYCAMERACAPTUREVIDEOFRAME = "VideoFrameObserver_onSecondaryCameraCaptureVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONSECONDARYPREENCODECAMERAVIDEOFRAME = "VideoFrameObserver_onSecondaryPreEncodeCameraVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONSCREENCAPTUREVIDEOFRAME = "VideoFrameObserver_onScreenCaptureVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONPREENCODESCREENVIDEOFRAME = "VideoFrameObserver_onPreEncodeScreenVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONMEDIAPLAYERVIDEOFRAME = "VideoFrameObserver_onMediaPlayerVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONSECONDARYSCREENCAPTUREVIDEOFRAME = "VideoFrameObserver_onSecondaryScreenCaptureVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONSECONDARYPREENCODESCREENVIDEOFRAME = "VideoFrameObserver_onSecondaryPreEncodeScreenVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONRENDERVIDEOFRAME = "VideoFrameObserver_onRenderVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONTRANSCODEDVIDEOFRAME = "VideoFrameObserver_onTranscodedVideoFrame";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETVIDEOFRAMEPROCESSMODE = "VideoFrameObserver_getVideoFrameProcessMode";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETVIDEOFORMATPREFERENCE = "VideoFrameObserver_getVideoFormatPreference";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETROTATIONAPPLIED = "VideoFrameObserver_getRotationApplied";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETMIRRORAPPLIED = "VideoFrameObserver_getMirrorApplied";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETOBSERVEDFRAMEPOSITION = "VideoFrameObserver_getObservedFramePosition";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ISEXTERNAL = "VideoFrameObserver_isExternal";
        #endregion
    }
}
