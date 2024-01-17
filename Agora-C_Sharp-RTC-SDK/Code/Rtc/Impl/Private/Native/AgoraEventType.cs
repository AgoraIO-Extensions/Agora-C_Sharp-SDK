using System;
namespace Agora.Rtc
{
    internal static class AgoraEventType
    {
        #region terra IAudioEncodedFrameObserver
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONRECORDAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_onRecordAudioEncodedFrame_d930ddc";
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONPLAYBACKAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_onPlaybackAudioEncodedFrame_d930ddc";
        internal const string EVENT_AUDIOENCODEDFRAMEOBSERVER_ONMIXEDAUDIOENCODEDFRAME = "AudioEncodedFrameObserver_onMixedAudioEncodedFrame_d930ddc";
        #endregion terra IAudioEncodedFrameObserver

        #region terra IAudioFrameObserver
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONRECORDAUDIOFRAME = "AudioFrameObserver_onRecordAudioFrame_4c8de15";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAME = "AudioFrameObserver_onPlaybackAudioFrame_4c8de15";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONMIXEDAUDIOFRAME = "AudioFrameObserver_onMixedAudioFrame_4c8de15";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONEARMONITORINGAUDIOFRAME = "AudioFrameObserver_onEarMonitoringAudioFrame_5405a47";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING = "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing_9215cc7";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETOBSERVEDAUDIOFRAMEPOSITION = "AudioFrameObserver_getObservedAudioFramePosition";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETPLAYBACKAUDIOPARAMS = "AudioFrameObserver_getPlaybackAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETRECORDAUDIOPARAMS = "AudioFrameObserver_getRecordAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETMIXEDAUDIOPARAMS = "AudioFrameObserver_getMixedAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVER_GETEARMONITORINGAUDIOPARAMS = "AudioFrameObserver_getEarMonitoringAudioParams";
        internal const string EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING2 = "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing_85ec0fc";
        #endregion terra IAudioFrameObserver

        #region terra IAudioPcmFrameSink
        internal const string EVENT_AUDIOPCMFRAMESINK_ONFRAME = "AudioPcmFrameSink_onFrame_95f515a";
        #endregion terra IAudioPcmFrameSink

        #region terra IAudioSpectrumObserver
        internal const string EVENT_AUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM = "AudioSpectrumObserver_onLocalAudioSpectrum_5822fed";
        internal const string EVENT_AUDIOSPECTRUMOBSERVER_ONREMOTEAUDIOSPECTRUM = "AudioSpectrumObserver_onRemoteAudioSpectrum_8ea2cde";
        #endregion terra IAudioSpectrumObserver

        #region terra IH265TranscoderObserver
        internal const string EVENT_H265TRANSCODEROBSERVER_ONENABLETRANSCODE = "H265TranscoderObserver_onEnableTranscode_6ba6646";
        internal const string EVENT_H265TRANSCODEROBSERVER_ONQUERYCHANNEL = "H265TranscoderObserver_onQueryChannel_31ba3df";
        internal const string EVENT_H265TRANSCODEROBSERVER_ONTRIGGERTRANSCODE = "H265TranscoderObserver_onTriggerTranscode_6ba6646";
        #endregion terra IH265TranscoderObserver

        #region terra IMediaPlayerCustomDataProvider
        internal const string EVENT_MEDIAPLAYERCUSTOMDATAPROVIDER_ONREADDATA = "MediaPlayerCustomDataProvider_onReadData_6e75338";
        internal const string EVENT_MEDIAPLAYERCUSTOMDATAPROVIDER_ONSEEK = "MediaPlayerCustomDataProvider_onSeek_624d569";
        #endregion terra IMediaPlayerCustomDataProvider

        #region terra IMediaPlayerSourceObserver
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSOURCESTATECHANGED = "MediaPlayerSourceObserver_onPlayerSourceStateChanged_7fb38f1";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPOSITIONCHANGED = "MediaPlayerSourceObserver_onPositionChanged_303b92e";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYEREVENT = "MediaPlayerSourceObserver_onPlayerEvent_50f16fa";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONMETADATA = "MediaPlayerSourceObserver_onMetaData_469a01b";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYBUFFERUPDATED = "MediaPlayerSourceObserver_onPlayBufferUpdated_f631116";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPRELOADEVENT = "MediaPlayerSourceObserver_onPreloadEvent_a1e3596";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONCOMPLETED = "MediaPlayerSourceObserver_onCompleted";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAGORACDNTOKENWILLEXPIRE = "MediaPlayerSourceObserver_onAgoraCDNTokenWillExpire";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERSRCINFOCHANGED = "MediaPlayerSourceObserver_onPlayerSrcInfoChanged_54f3e5a";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERINFOUPDATED = "MediaPlayerSourceObserver_onPlayerInfoUpdated_0e902a8";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERCACHESTATS = "MediaPlayerSourceObserver_onPlayerCacheStats_0145940";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONPLAYERPLAYBACKSTATS = "MediaPlayerSourceObserver_onPlayerPlaybackStats_ffa466f";
        internal const string EVENT_MEDIAPLAYERSOURCEOBSERVER_ONAUDIOVOLUMEINDICATION = "MediaPlayerSourceObserver_onAudioVolumeIndication_46f8ab7";
        #endregion terra IMediaPlayerSourceObserver

        #region terra IMediaRecorderObserver
        internal const string EVENT_MEDIARECORDEROBSERVER_ONRECORDERSTATECHANGED = "MediaRecorderObserver_onRecorderStateChanged_c38849f";
        internal const string EVENT_MEDIARECORDEROBSERVER_ONRECORDERINFOUPDATED = "MediaRecorderObserver_onRecorderInfoUpdated_64fa74a";
        #endregion terra IMediaRecorderObserver

        #region terra IMetadataObserver
        internal const string EVENT_METADATAOBSERVER_GETMAXMETADATASIZE = "MetadataObserver_getMaxMetadataSize";
        internal const string EVENT_METADATAOBSERVER_ONREADYTOSENDMETADATA = "MetadataObserver_onReadyToSendMetadata_cbf4b59";
        internal const string EVENT_METADATAOBSERVER_ONMETADATARECEIVED = "MetadataObserver_onMetadataReceived_cb7661d";
        #endregion terra IMetadataObserver

        #region terra IMusicContentCenterEventHandler
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCHARTSRESULT = "MusicContentCenterEventHandler_onMusicChartsResult_fb18135";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONMUSICCOLLECTIONRESULT = "MusicContentCenterEventHandler_onMusicCollectionResult_c30c2e6";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONLYRICRESULT = "MusicContentCenterEventHandler_onLyricResult_9ad9c90";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONSONGSIMPLEINFORESULT = "MusicContentCenterEventHandler_onSongSimpleInfoResult_9ad9c90";
        internal const string EVENT_MUSICCONTENTCENTEREVENTHANDLER_ONPRELOADEVENT = "MusicContentCenterEventHandler_onPreLoadEvent_20170bc";
        #endregion terra IMusicContentCenterEventHandler

        #region terra IRtcEngineEventHandler
        internal const string EVENT_RTCENGINEEVENTHANDLER_EVENTHANDLERTYPE = "RtcEngineEventHandler_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONJOINCHANNELSUCCESS = "RtcEngineEventHandler_onJoinChannelSuccess_ee6b011";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREJOINCHANNELSUCCESS = "RtcEngineEventHandler_onRejoinChannelSuccess_ee6b011";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONPROXYCONNECTED = "RtcEngineEventHandler_onProxyConnected_9f89fd0";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONERROR = "RtcEngineEventHandler_onError_d26c0fd";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOQUALITY = "RtcEngineEventHandler_onAudioQuality_40aeca1";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEPROBERESULT = "RtcEngineEventHandler_onLastmileProbeResult_42b5843";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOVOLUMEINDICATION = "RtcEngineEventHandler_onAudioVolumeIndication_e9637c8";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLEAVECHANNEL = "RtcEngineEventHandler_onLeaveChannel_40ef426";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONRTCSTATS = "RtcEngineEventHandler_onRtcStats_40ef426";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICESTATECHANGED = "RtcEngineEventHandler_onAudioDeviceStateChanged_976d8c3";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGPOSITIONCHANGED = "RtcEngineEventHandler_onAudioMixingPositionChanged_f631116";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGFINISHED = "RtcEngineEventHandler_onAudioMixingFinished";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOEFFECTFINISHED = "RtcEngineEventHandler_onAudioEffectFinished_46f8ab7";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEODEVICESTATECHANGED = "RtcEngineEventHandler_onVideoDeviceStateChanged_976d8c3";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONNETWORKQUALITY = "RtcEngineEventHandler_onNetworkQuality_68a324c";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONINTRAREQUESTRECEIVED = "RtcEngineEventHandler_onIntraRequestReceived";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUPLINKNETWORKINFOUPDATED = "RtcEngineEventHandler_onUplinkNetworkInfoUpdated_cbb1856";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONDOWNLINKNETWORKINFOUPDATED = "RtcEngineEventHandler_onDownlinkNetworkInfoUpdated_e9d5bd9";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEQUALITY = "RtcEngineEventHandler_onLastmileQuality_46f8ab7";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTLOCALVIDEOFRAME = "RtcEngineEventHandler_onFirstLocalVideoFrame_ebdfd19";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTLOCALVIDEOFRAMEPUBLISHED = "RtcEngineEventHandler_onFirstLocalVideoFramePublished_2ad83d8";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEVIDEODECODED = "RtcEngineEventHandler_onFirstRemoteVideoDecoded_58b686c";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSIZECHANGED = "RtcEngineEventHandler_onVideoSizeChanged_5f7d8e3";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATECHANGED = "RtcEngineEventHandler_onLocalVideoStateChanged_a44228a";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOSTATECHANGED = "RtcEngineEventHandler_onRemoteVideoStateChanged_815ab69";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEVIDEOFRAME = "RtcEngineEventHandler_onFirstRemoteVideoFrame_58b686c";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERJOINED = "RtcEngineEventHandler_onUserJoined_88641bf";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSEROFFLINE = "RtcEngineEventHandler_onUserOffline_eb1e059";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERMUTEAUDIO = "RtcEngineEventHandler_onUserMuteAudio_dbdc15a";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERMUTEVIDEO = "RtcEngineEventHandler_onUserMuteVideo_dbdc15a";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERENABLEVIDEO = "RtcEngineEventHandler_onUserEnableVideo_dbdc15a";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERSTATECHANGED = "RtcEngineEventHandler_onUserStateChanged_c63723e";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERENABLELOCALVIDEO = "RtcEngineEventHandler_onUserEnableLocalVideo_dbdc15a";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOSTATS = "RtcEngineEventHandler_onRemoteAudioStats_4aba4cc";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALAUDIOSTATS = "RtcEngineEventHandler_onLocalAudioStats_8fcb8ec";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATS = "RtcEngineEventHandler_onLocalVideoStats_baa96c8";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOSTATS = "RtcEngineEventHandler_onRemoteVideoStats_e271890";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCAMERAREADY = "RtcEngineEventHandler_onCameraReady";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCAMERAFOCUSAREACHANGED = "RtcEngineEventHandler_onCameraFocusAreaChanged_41c5354";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCAMERAEXPOSUREAREACHANGED = "RtcEngineEventHandler_onCameraExposureAreaChanged_41c5354";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFACEPOSITIONCHANGED = "RtcEngineEventHandler_onFacePositionChanged_197b4a7";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSTOPPED = "RtcEngineEventHandler_onVideoStopped";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGSTATECHANGED = "RtcEngineEventHandler_onAudioMixingStateChanged_fd2c0a6";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONRHYTHMPLAYERSTATECHANGED = "RtcEngineEventHandler_onRhythmPlayerStateChanged_09360d2";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONLOST = "RtcEngineEventHandler_onConnectionLost";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONINTERRUPTED = "RtcEngineEventHandler_onConnectionInterrupted";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONBANNED = "RtcEngineEventHandler_onConnectionBanned";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSTREAMMESSAGE = "RtcEngineEventHandler_onStreamMessage_6f90bce";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSTREAMMESSAGEERROR = "RtcEngineEventHandler_onStreamMessageError_21e5c1a";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREQUESTTOKEN = "RtcEngineEventHandler_onRequestToken";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONTOKENPRIVILEGEWILLEXPIRE = "RtcEngineEventHandler_onTokenPrivilegeWillExpire_3a2037f";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLICENSEVALIDATIONFAILURE = "RtcEngineEventHandler_onLicenseValidationFailure_4518fcc";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTLOCALAUDIOFRAMEPUBLISHED = "RtcEngineEventHandler_onFirstLocalAudioFramePublished_46f8ab7";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEAUDIODECODED = "RtcEngineEventHandler_onFirstRemoteAudioDecoded_88641bf";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONFIRSTREMOTEAUDIOFRAME = "RtcEngineEventHandler_onFirstRemoteAudioFrame_88641bf";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALAUDIOSTATECHANGED = "RtcEngineEventHandler_onLocalAudioStateChanged_f33d789";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOSTATECHANGED = "RtcEngineEventHandler_onRemoteAudioStateChanged_f1532dd";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONACTIVESPEAKER = "RtcEngineEventHandler_onActiveSpeaker_c8d091a";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONTENTINSPECTRESULT = "RtcEngineEventHandler_onContentInspectResult_ba185c8";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSNAPSHOTTAKEN = "RtcEngineEventHandler_onSnapshotTaken_c495bf6";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCLIENTROLECHANGED = "RtcEngineEventHandler_onClientRoleChanged_938fb25";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCLIENTROLECHANGEFAILED = "RtcEngineEventHandler_onClientRoleChangeFailed_386f862";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICEVOLUMECHANGED = "RtcEngineEventHandler_onAudioDeviceVolumeChanged_55ab726";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGSTATECHANGED = "RtcEngineEventHandler_onRtmpStreamingStateChanged_1f07503";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGEVENT = "RtcEngineEventHandler_onRtmpStreamingEvent_2e48ef5";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONTRANSCODINGUPDATED = "RtcEngineEventHandler_onTranscodingUpdated";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOROUTINGCHANGED = "RtcEngineEventHandler_onAudioRoutingChanged_46f8ab7";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCHANNELMEDIARELAYSTATECHANGED = "RtcEngineEventHandler_onChannelMediaRelayStateChanged_4e92b3c";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALPUBLISHFALLBACKTOAUDIOONLY = "RtcEngineEventHandler_onLocalPublishFallbackToAudioOnly_5039d15";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY = "RtcEngineEventHandler_onRemoteSubscribeFallbackToAudioOnly_dbdc15a";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEAUDIOTRANSPORTSTATS = "RtcEngineEventHandler_onRemoteAudioTransportStats_bd01ada";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONREMOTEVIDEOTRANSPORTSTATS = "RtcEngineEventHandler_onRemoteVideoTransportStats_bd01ada";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONCONNECTIONSTATECHANGED = "RtcEngineEventHandler_onConnectionStateChanged_ec7c9c0";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONWLACCMESSAGE = "RtcEngineEventHandler_onWlAccMessage_333465b";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONWLACCSTATS = "RtcEngineEventHandler_onWlAccStats_94ee38e";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONNETWORKTYPECHANGED = "RtcEngineEventHandler_onNetworkTypeChanged_e85a70d";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONENCRYPTIONERROR = "RtcEngineEventHandler_onEncryptionError_a0d1b74";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONPERMISSIONERROR = "RtcEngineEventHandler_onPermissionError_f37c62b";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALUSERREGISTERED = "RtcEngineEventHandler_onLocalUserRegistered_1922dd1";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERINFOUPDATED = "RtcEngineEventHandler_onUserInfoUpdated_2120245";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUSERACCOUNTUPDATED = "RtcEngineEventHandler_onUserAccountUpdated_1922dd1";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEORENDERINGTRACINGRESULT = "RtcEngineEventHandler_onVideoRenderingTracingResult_76e2449";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOTRANSCODERERROR = "RtcEngineEventHandler_onLocalVideoTranscoderError_83e3a9c";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONUPLOADLOGRESULT = "RtcEngineEventHandler_onUploadLogResult_eef29d2";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOSUBSCRIBESTATECHANGED = "RtcEngineEventHandler_onAudioSubscribeStateChanged_e0ec28e";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSUBSCRIBESTATECHANGED = "RtcEngineEventHandler_onVideoSubscribeStateChanged_e0ec28e";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONAUDIOPUBLISHSTATECHANGED = "RtcEngineEventHandler_onAudioPublishStateChanged_2c13a28";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONVIDEOPUBLISHSTATECHANGED = "RtcEngineEventHandler_onVideoPublishStateChanged_5b45b6e";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONTRANSCODEDSTREAMLAYOUTINFO = "RtcEngineEventHandler_onTranscodedStreamLayoutInfo_3bfb91b";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONEVENT = "RtcEngineEventHandler_onExtensionEvent_062d13c";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTARTED = "RtcEngineEventHandler_onExtensionStarted_ccad422";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTOPPED = "RtcEngineEventHandler_onExtensionStopped_ccad422";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONERROR = "RtcEngineEventHandler_onExtensionError_bd3489b";
        internal const string EVENT_RTCENGINEEVENTHANDLER_ONSETRTMFLAGRESULT = "RtcEngineEventHandler_onSetRtmFlagResult_46f8ab7";
        #endregion terra IRtcEngineEventHandler

        #region terra IRtcEngineEventHandlerEx
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_EVENTHANDLERTYPE = "RtcEngineEventHandler_eventHandlerType";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONJOINCHANNELSUCCESS = "RtcEngineEventHandler_onJoinChannelSuccess_263e4cd";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREJOINCHANNELSUCCESS = "RtcEngineEventHandler_onRejoinChannelSuccess_263e4cd";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOQUALITY = "RtcEngineEventHandler_onAudioQuality_5c7294b";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOVOLUMEINDICATION = "RtcEngineEventHandler_onAudioVolumeIndication_781482a";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLEAVECHANNEL = "RtcEngineEventHandler_onLeaveChannel_c8e730d";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONRTCSTATS = "RtcEngineEventHandler_onRtcStats_c8e730d";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKQUALITY = "RtcEngineEventHandler_onNetworkQuality_34d8b3c";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONINTRAREQUESTRECEIVED = "RtcEngineEventHandler_onIntraRequestReceived_c81e1a4";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALVIDEOFRAMEPUBLISHED = "RtcEngineEventHandler_onFirstLocalVideoFramePublished_263e4cd";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEODECODED = "RtcEngineEventHandler_onFirstRemoteVideoDecoded_a68170a";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEOSIZECHANGED = "RtcEngineEventHandler_onVideoSizeChanged_99bf45c";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATECHANGED = "RtcEngineEventHandler_onLocalVideoStateChanged_b202b1b";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATECHANGED = "RtcEngineEventHandler_onRemoteVideoStateChanged_a14e9d1";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEOFRAME = "RtcEngineEventHandler_onFirstRemoteVideoFrame_a68170a";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERJOINED = "RtcEngineEventHandler_onUserJoined_c5499bd";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSEROFFLINE = "RtcEngineEventHandler_onUserOffline_0a32aac";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEAUDIO = "RtcEngineEventHandler_onUserMuteAudio_0aac2fe";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEVIDEO = "RtcEngineEventHandler_onUserMuteVideo_0aac2fe";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLEVIDEO = "RtcEngineEventHandler_onUserEnableVideo_0aac2fe";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLELOCALVIDEO = "RtcEngineEventHandler_onUserEnableLocalVideo_0aac2fe";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERSTATECHANGED = "RtcEngineEventHandler_onUserStateChanged_65f95a7";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATS = "RtcEngineEventHandler_onLocalAudioStats_5657f05";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATS = "RtcEngineEventHandler_onRemoteAudioStats_ffbde06";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATS = "RtcEngineEventHandler_onLocalVideoStats_3ac0eb4";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATS = "RtcEngineEventHandler_onRemoteVideoStats_2f43a70";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONLOST = "RtcEngineEventHandler_onConnectionLost_c81e1a4";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONINTERRUPTED = "RtcEngineEventHandler_onConnectionInterrupted_c81e1a4";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONBANNED = "RtcEngineEventHandler_onConnectionBanned_c81e1a4";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGE = "RtcEngineEventHandler_onStreamMessage_99898cb";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGEERROR = "RtcEngineEventHandler_onStreamMessageError_fe302fc";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREQUESTTOKEN = "RtcEngineEventHandler_onRequestToken_c81e1a4";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLICENSEVALIDATIONFAILURE = "RtcEngineEventHandler_onLicenseValidationFailure_5dfd95e";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONTOKENPRIVILEGEWILLEXPIRE = "RtcEngineEventHandler_onTokenPrivilegeWillExpire_8225ea3";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALAUDIOFRAMEPUBLISHED = "RtcEngineEventHandler_onFirstLocalAudioFramePublished_263e4cd";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIOFRAME = "RtcEngineEventHandler_onFirstRemoteAudioFrame_c5499bd";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIODECODED = "RtcEngineEventHandler_onFirstRemoteAudioDecoded_c5499bd";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATECHANGED = "RtcEngineEventHandler_onLocalAudioStateChanged_13b6c02";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATECHANGED = "RtcEngineEventHandler_onRemoteAudioStateChanged_056772e";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONACTIVESPEAKER = "RtcEngineEventHandler_onActiveSpeaker_dd67adc";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGED = "RtcEngineEventHandler_onClientRoleChanged_2acaf10";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGEFAILED = "RtcEngineEventHandler_onClientRoleChangeFailed_5a3af5b";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOTRANSPORTSTATS = "RtcEngineEventHandler_onRemoteAudioTransportStats_527a345";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOTRANSPORTSTATS = "RtcEngineEventHandler_onRemoteVideoTransportStats_527a345";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONSTATECHANGED = "RtcEngineEventHandler_onConnectionStateChanged_4075a9c";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCMESSAGE = "RtcEngineEventHandler_onWlAccMessage_2b9068e";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCSTATS = "RtcEngineEventHandler_onWlAccStats_b162607";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKTYPECHANGED = "RtcEngineEventHandler_onNetworkTypeChanged_388fd6f";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONENCRYPTIONERROR = "RtcEngineEventHandler_onEncryptionError_e7a65fe";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUPLOADLOGRESULT = "RtcEngineEventHandler_onUploadLogResult_3115804";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONUSERACCOUNTUPDATED = "RtcEngineEventHandler_onUserAccountUpdated_de1c015";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONSNAPSHOTTAKEN = "RtcEngineEventHandler_onSnapshotTaken_5a6a693";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEORENDERINGTRACINGRESULT = "RtcEngineEventHandler_onVideoRenderingTracingResult_813c0f4";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONSETRTMFLAGRESULT = "RtcEngineEventHandler_onSetRtmFlagResult_263e4cd";
        internal const string EVENT_RTCENGINEEVENTHANDLEREX_ONTRANSCODEDSTREAMLAYOUTINFO = "RtcEngineEventHandler_onTranscodedStreamLayoutInfo_48f6419";
        #endregion terra IRtcEngineEventHandlerEx

        #region terra IDirectCdnStreamingEventHandler
        internal const string EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATECHANGED = "DirectCdnStreamingEventHandler_onDirectCdnStreamingStateChanged_40f1fa3";
        internal const string EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATS = "DirectCdnStreamingEventHandler_onDirectCdnStreamingStats_d50595f";
        #endregion terra IDirectCdnStreamingEventHandler

        #region terra IVideoEncodedFrameObserver
        internal const string EVENT_VIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED = "VideoEncodedFrameObserver_onEncodedVideoFrameReceived_6922697";
        #endregion terra IVideoEncodedFrameObserver

        #region terra IVideoFrameObserver
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONCAPTUREVIDEOFRAME = "VideoFrameObserver_onCaptureVideoFrame_1673590";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONPREENCODEVIDEOFRAME = "VideoFrameObserver_onPreEncodeVideoFrame_1673590";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONMEDIAPLAYERVIDEOFRAME = "VideoFrameObserver_onMediaPlayerVideoFrame_e648e2c";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONRENDERVIDEOFRAME = "VideoFrameObserver_onRenderVideoFrame_43dcf82";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ONTRANSCODEDVIDEOFRAME = "VideoFrameObserver_onTranscodedVideoFrame_27754d8";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETVIDEOFRAMEPROCESSMODE = "VideoFrameObserver_getVideoFrameProcessMode";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETVIDEOFORMATPREFERENCE = "VideoFrameObserver_getVideoFormatPreference";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETROTATIONAPPLIED = "VideoFrameObserver_getRotationApplied";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETMIRRORAPPLIED = "VideoFrameObserver_getMirrorApplied";
        internal const string EVENT_VIDEOFRAMEOBSERVER_GETOBSERVEDFRAMEPOSITION = "VideoFrameObserver_getObservedFramePosition";
        internal const string EVENT_VIDEOFRAMEOBSERVER_ISEXTERNAL = "VideoFrameObserver_isExternal";
        #endregion terra IVideoFrameObserver

    }
}
