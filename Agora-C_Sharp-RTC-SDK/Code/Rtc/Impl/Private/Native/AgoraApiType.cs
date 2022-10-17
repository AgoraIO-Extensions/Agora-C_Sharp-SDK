namespace Agora.Rtc
{
    internal static class AgoraApiType
    {
        #region class IRtcEngine 
        internal const string FUNC_KEY_ERROR = "";
        internal const string FUNC_RTCENGINE_UNREGISTERAUDIOENCODEDFRAMEOBSERVER = "RtcEngine_unregisterAudioEncodedFrameObserver";
        internal const string FUNC_RTCENGINE_SETAPPTYPE = "RtcEngine_setAppType";
        internal const string FUNC_RTCENGINE_SETPARAMETERS = "RtcEngine_setParameters";
        internal const string FUNC_RTCENGINE_RELEASESCREENCAPTURESOURCES = "RtcEngine_releaseScreenCaptureSources";

        internal const string FUNC_RTCENGINE_RELEASE = "RtcEngine_release";
        internal const string FUNC_RTCENGINE_INITIALIZE = "RtcEngine_initialize";
        internal const string FUNC_RTCENGINE_QUERYINTERFACE = "RtcEngine_queryInterface";
        internal const string FUNC_RTCENGINE_GETVERSION = "RtcEngine_getVersion";
        internal const string FUNC_RTCENGINE_GETERRORDESCRIPTION = "RtcEngine_getErrorDescription";
        internal const string FUNC_RTCENGINE_JOINCHANNEL = "RtcEngine_joinChannel";
        internal const string FUNC_RTCENGINE_JOINCHANNEL2 = "RtcEngine_joinChannel2";
        internal const string FUNC_RTCENGINE_UPDATECHANNELMEDIAOPTIONS = "RtcEngine_updateChannelMediaOptions";
        internal const string FUNC_RTCENGINE_LEAVECHANNEL = "RtcEngine_leaveChannel";
        internal const string FUNC_RTCENGINE_LEAVECHANNEL2 = "RtcEngine_leaveChannel2";
        internal const string FUNC_RTCENGINE_RENEWTOKEN = "RtcEngine_renewToken";
        internal const string FUNC_RTCENGINE_SETCHANNELPROFILE = "RtcEngine_setChannelProfile";
        internal const string FUNC_RTCENGINE_SETCLIENTROLE = "RtcEngine_setClientRole";
        internal const string FUNC_RTCENGINE_SETCLIENTROLE2 = "RtcEngine_setClientRole2";
        internal const string FUNC_RTCENGINE_STARTECHOTEST = "RtcEngine_startEchoTest";
        internal const string FUNC_RTCENGINE_STARTECHOTEST2 = "RtcEngine_startEchoTest2";
        internal const string FUNC_RTCENGINE_STARTECHOTEST3 = "RtcEngine_startEchoTest3";
        internal const string FUNC_RTCENGINE_STOPECHOTEST = "RtcEngine_stopEchoTest";
        internal const string FUNC_RTCENGINE_ENABLEMULTICAMERA = "RtcEngine_enableMultiCamera";
        internal const string FUNC_RTCENGINE_ENABLEVIDEO = "RtcEngine_enableVideo";
        internal const string FUNC_RTCENGINE_DISABLEVIDEO = "RtcEngine_disableVideo";
        internal const string FUNC_RTCENGINE_STARTPREVIEW = "RtcEngine_startPreview";
        internal const string FUNC_RTCENGINE_STARTPREVIEW2 = "RtcEngine_startPreview2";
        internal const string FUNC_RTCENGINE_STOPPREVIEW = "RtcEngine_stopPreview";
        internal const string FUNC_RTCENGINE_STOPPREVIEW2 = "RtcEngine_stopPreview2";
        internal const string FUNC_RTCENGINE_STARTLASTMILEPROBETEST = "RtcEngine_startLastmileProbeTest";
        internal const string FUNC_RTCENGINE_STOPLASTMILEPROBETEST = "RtcEngine_stopLastmileProbeTest";
        internal const string FUNC_RTCENGINE_SETVIDEOENCODERCONFIGURATION = "RtcEngine_setVideoEncoderConfiguration";
        internal const string FUNC_RTCENGINE_SETBEAUTYEFFECTOPTIONS = "RtcEngine_setBeautyEffectOptions";
        internal const string FUNC_RTCENGINE_SETLOWLIGHTENHANCEOPTIONS = "RtcEngine_setLowlightEnhanceOptions";
        internal const string FUNC_RTCENGINE_SETVIDEODENOISEROPTIONS = "RtcEngine_setVideoDenoiserOptions";
        internal const string FUNC_RTCENGINE_SETCOLORENHANCEOPTIONS = "RtcEngine_setColorEnhanceOptions";
        internal const string FUNC_RTCENGINE_ENABLEVIRTUALBACKGROUND = "RtcEngine_enableVirtualBackground";
        internal const string FUNC_RTCENGINE_ENABLEREMOTESUPERRESOLUTION = "RtcEngine_enableRemoteSuperResolution";
        internal const string FUNC_RTCENGINE_SETUPREMOTEVIDEO = "RtcEngine_setupRemoteVideo";
        internal const string FUNC_RTCENGINE_SETUPLOCALVIDEO = "RtcEngine_setupLocalVideo";
        internal const string FUNC_RTCENGINE_ENABLEAUDIO = "RtcEngine_enableAudio";
        internal const string FUNC_RTCENGINE_DISABLEAUDIO = "RtcEngine_disableAudio";
        internal const string FUNC_RTCENGINE_SETAUDIOPROFILE = "RtcEngine_setAudioProfile";
        internal const string FUNC_RTCENGINE_SETAUDIOPROFILE2 = "RtcEngine_setAudioProfile2";
        internal const string FUNC_RTCENGINE_SETAUDIOSCENARIO = "RtcEngine_setAudioScenario";
        internal const string FUNC_RTCENGINE_ENABLELOCALAUDIO = "RtcEngine_enableLocalAudio";
        internal const string FUNC_RTCENGINE_MUTELOCALAUDIOSTREAM = "RtcEngine_muteLocalAudioStream";
        internal const string FUNC_RTCENGINE_MUTEALLREMOTEAUDIOSTREAMS = "RtcEngine_muteAllRemoteAudioStreams";
        internal const string FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEAUDIOSTREAMS = "RtcEngine_setDefaultMuteAllRemoteAudioStreams";
        internal const string FUNC_RTCENGINE_MUTEREMOTEAUDIOSTREAM = "RtcEngine_muteRemoteAudioStream";
        internal const string FUNC_RTCENGINE_MUTELOCALVIDEOSTREAM = "RtcEngine_muteLocalVideoStream";
        internal const string FUNC_RTCENGINE_ENABLELOCALVIDEO = "RtcEngine_enableLocalVideo";
        internal const string FUNC_RTCENGINE_MUTEALLREMOTEVIDEOSTREAMS = "RtcEngine_muteAllRemoteVideoStreams";
        internal const string FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEVIDEOSTREAMS = "RtcEngine_setDefaultMuteAllRemoteVideoStreams";
        internal const string FUNC_RTCENGINE_MUTEREMOTEVIDEOSTREAM = "RtcEngine_muteRemoteVideoStream";
        internal const string FUNC_RTCENGINE_SETREMOTEVIDEOSTREAMTYPE = "RtcEngine_setRemoteVideoStreamType";
        internal const string FUNC_RTCENGINE_SETREMOTEVIDEOSUBSCRIPTIONOPTIONS = "RtcEngine_setRemoteVideoSubscriptionOptions";
        internal const string FUNC_RTCENGINE_SETREMOTEDEFAULTVIDEOSTREAMTYPE = "RtcEngine_setRemoteDefaultVideoStreamType";
        internal const string FUNC_RTCENGINE_SETSUBSCRIBEAUDIOBLOCKLIST = "RtcEngine_setSubscribeAudioBlocklist";
        internal const string FUNC_RTCENGINE_SETSUBSCRIBEAUDIOALLOWLIST = "RtcEngine_setSubscribeAudioAllowlist";
        internal const string FUNC_RTCENGINE_SETSUBSCRIBEVIDEOBLOCKLIST = "RtcEngine_setSubscribeVideoBlocklist";
        internal const string FUNC_RTCENGINE_SETSUBSCRIBEVIDEOALLOWLIST = "RtcEngine_setSubscribeVideoAllowlist";
        internal const string FUNC_RTCENGINE_ENABLEAUDIOVOLUMEINDICATION = "RtcEngine_enableAudioVolumeIndication";
        internal const string FUNC_RTCENGINE_STARTAUDIORECORDING = "RtcEngine_startAudioRecording";
        internal const string FUNC_RTCENGINE_STARTAUDIORECORDING2 = "RtcEngine_startAudioRecording2";
        internal const string FUNC_RTCENGINE_STARTAUDIORECORDING3 = "RtcEngine_startAudioRecording3";
        internal const string FUNC_RTCENGINE_REGISTERAUDIOENCODEDFRAMEOBSERVER = "RtcEngine_registerAudioEncodedFrameObserver";
        internal const string FUNC_RTCENGINE_STOPAUDIORECORDING = "RtcEngine_stopAudioRecording";
        internal const string FUNC_RTCENGINE_CREATEMEDIAPLAYER = "RtcEngine_createMediaPlayer";
        internal const string FUNC_RTCENGINE_DESTROYMEDIAPLAYER = "RtcEngine_destroyMediaPlayer";
        internal const string FUNC_RTCENGINE_STARTAUDIOMIXING = "RtcEngine_startAudioMixing";
        internal const string FUNC_RTCENGINE_STARTAUDIOMIXING2 = "RtcEngine_startAudioMixing2";
        internal const string FUNC_RTCENGINE_STOPAUDIOMIXING = "RtcEngine_stopAudioMixing";
        internal const string FUNC_RTCENGINE_PAUSEAUDIOMIXING = "RtcEngine_pauseAudioMixing";
        internal const string FUNC_RTCENGINE_RESUMEAUDIOMIXING = "RtcEngine_resumeAudioMixing";
        internal const string FUNC_RTCENGINE_SELECTAUDIOTRACK = "RtcEngine_selectAudioTrack";
        internal const string FUNC_RTCENGINE_GETAUDIOTRACKCOUNT = "RtcEngine_getAudioTrackCount";
        internal const string FUNC_RTCENGINE_ADJUSTAUDIOMIXINGVOLUME = "RtcEngine_adjustAudioMixingVolume";
        internal const string FUNC_RTCENGINE_ADJUSTAUDIOMIXINGPUBLISHVOLUME = "RtcEngine_adjustAudioMixingPublishVolume";
        internal const string FUNC_RTCENGINE_GETAUDIOMIXINGPUBLISHVOLUME = "RtcEngine_getAudioMixingPublishVolume";
        internal const string FUNC_RTCENGINE_ADJUSTAUDIOMIXINGPLAYOUTVOLUME = "RtcEngine_adjustAudioMixingPlayoutVolume";
        internal const string FUNC_RTCENGINE_GETAUDIOMIXINGPLAYOUTVOLUME = "RtcEngine_getAudioMixingPlayoutVolume";
        internal const string FUNC_RTCENGINE_GETAUDIOMIXINGDURATION = "RtcEngine_getAudioMixingDuration";
        internal const string FUNC_RTCENGINE_GETAUDIOMIXINGCURRENTPOSITION = "RtcEngine_getAudioMixingCurrentPosition";
        internal const string FUNC_RTCENGINE_SETAUDIOMIXINGPOSITION = "RtcEngine_setAudioMixingPosition";
        internal const string FUNC_RTCENGINE_SETAUDIOMIXINGDUALMONOMODE = "RtcEngine_setAudioMixingDualMonoMode";
        internal const string FUNC_RTCENGINE_SETAUDIOMIXINGPITCH = "RtcEngine_setAudioMixingPitch";
        internal const string FUNC_RTCENGINE_GETEFFECTSVOLUME = "RtcEngine_getEffectsVolume";
        internal const string FUNC_RTCENGINE_SETEFFECTSVOLUME = "RtcEngine_setEffectsVolume";
        internal const string FUNC_RTCENGINE_PRELOADEFFECT = "RtcEngine_preloadEffect";
        internal const string FUNC_RTCENGINE_PLAYEFFECT = "RtcEngine_playEffect";
        internal const string FUNC_RTCENGINE_PLAYALLEFFECTS = "RtcEngine_playAllEffects";
        internal const string FUNC_RTCENGINE_GETVOLUMEOFEFFECT = "RtcEngine_getVolumeOfEffect";
        internal const string FUNC_RTCENGINE_SETVOLUMEOFEFFECT = "RtcEngine_setVolumeOfEffect";
        internal const string FUNC_RTCENGINE_PAUSEEFFECT = "RtcEngine_pauseEffect";
        internal const string FUNC_RTCENGINE_PAUSEALLEFFECTS = "RtcEngine_pauseAllEffects";
        internal const string FUNC_RTCENGINE_RESUMEEFFECT = "RtcEngine_resumeEffect";
        internal const string FUNC_RTCENGINE_RESUMEALLEFFECTS = "RtcEngine_resumeAllEffects";
        internal const string FUNC_RTCENGINE_STOPEFFECT = "RtcEngine_stopEffect";
        internal const string FUNC_RTCENGINE_STOPALLEFFECTS = "RtcEngine_stopAllEffects";
        internal const string FUNC_RTCENGINE_UNLOADEFFECT = "RtcEngine_unloadEffect";
        internal const string FUNC_RTCENGINE_UNLOADALLEFFECTS = "RtcEngine_unloadAllEffects";
        internal const string FUNC_RTCENGINE_GETEFFECTDURATION = "RtcEngine_getEffectDuration";
        internal const string FUNC_RTCENGINE_SETEFFECTPOSITION = "RtcEngine_setEffectPosition";
        internal const string FUNC_RTCENGINE_GETEFFECTCURRENTPOSITION = "RtcEngine_getEffectCurrentPosition";
        internal const string FUNC_RTCENGINE_ENABLESOUNDPOSITIONINDICATION = "RtcEngine_enableSoundPositionIndication";
        internal const string FUNC_RTCENGINE_SETREMOTEVOICEPOSITION = "RtcEngine_setRemoteVoicePosition";
        internal const string FUNC_RTCENGINE_ENABLESPATIALAUDIO = "RtcEngine_enableSpatialAudio";
        internal const string FUNC_RTCENGINE_SETREMOTEUSERSPATIALAUDIOPARAMS = "RtcEngine_setRemoteUserSpatialAudioParams";
        internal const string FUNC_RTCENGINE_SETVOICEBEAUTIFIERPRESET = "RtcEngine_setVoiceBeautifierPreset";
        internal const string FUNC_RTCENGINE_SETAUDIOEFFECTPRESET = "RtcEngine_setAudioEffectPreset";
        internal const string FUNC_RTCENGINE_SETVOICECONVERSIONPRESET = "RtcEngine_setVoiceConversionPreset";
        internal const string FUNC_RTCENGINE_SETAUDIOEFFECTPARAMETERS = "RtcEngine_setAudioEffectParameters";
        internal const string FUNC_RTCENGINE_SETVOICEBEAUTIFIERPARAMETERS = "RtcEngine_setVoiceBeautifierParameters";
        internal const string FUNC_RTCENGINE_SETVOICECONVERSIONPARAMETERS = "RtcEngine_setVoiceConversionParameters";
        internal const string FUNC_RTCENGINE_SETLOCALVOICEPITCH = "RtcEngine_setLocalVoicePitch";
        internal const string FUNC_RTCENGINE_SETLOCALVOICEEQUALIZATION = "RtcEngine_setLocalVoiceEqualization";
        internal const string FUNC_RTCENGINE_SETLOCALVOICEREVERB = "RtcEngine_setLocalVoiceReverb";
        internal const string FUNC_RTCENGINE_SETHEADPHONEEQPRESET = "RtcEngine_setHeadphoneEQPreset";
        internal const string FUNC_RTCENGINE_SETHEADPHONEEQPARAMETERS = "RtcEngine_setHeadphoneEQParameters";
        internal const string FUNC_RTCENGINE_SETLOGFILE = "RtcEngine_setLogFile";
        internal const string FUNC_RTCENGINE_SETLOGFILTER = "RtcEngine_setLogFilter";
        internal const string FUNC_RTCENGINE_SETLOGLEVEL = "RtcEngine_setLogLevel";
        internal const string FUNC_RTCENGINE_SETLOGFILESIZE = "RtcEngine_setLogFileSize";
        internal const string FUNC_RTCENGINE_UPLOADLOGFILE = "RtcEngine_uploadLogFile";
        internal const string FUNC_RTCENGINE_SETLOCALRENDERMODE = "RtcEngine_setLocalRenderMode";
        internal const string FUNC_RTCENGINE_SETREMOTERENDERMODE = "RtcEngine_setRemoteRenderMode";
        internal const string FUNC_RTCENGINE_SETLOCALRENDERMODE2 = "RtcEngine_setLocalRenderMode2";
        internal const string FUNC_RTCENGINE_SETLOCALVIDEOMIRRORMODE = "RtcEngine_setLocalVideoMirrorMode";
        internal const string FUNC_RTCENGINE_ENABLEDUALSTREAMMODE = "RtcEngine_enableDualStreamMode";
        internal const string FUNC_RTCENGINE_ENABLEDUALSTREAMMODE2 = "RtcEngine_enableDualStreamMode2";
        internal const string FUNC_RTCENGINE_SETDUALSTREAMMODE = "RtcEngine_setDualStreamMode";
        internal const string FUNC_RTCENGINE_SETDUALSTREAMMODE2 = "RtcEngine_setDualStreamMode2";
        internal const string FUNC_RTCENGINE_ENABLEECHOCANCELLATIONEXTERNAL = "RtcEngine_enableEchoCancellationExternal";
        internal const string FUNC_RTCENGINE_ENABLECUSTOMAUDIOLOCALPLAYBACK = "RtcEngine_enableCustomAudioLocalPlayback";
        internal const string FUNC_RTCENGINE_STARTPRIMARYCUSTOMAUDIOTRACK = "RtcEngine_startPrimaryCustomAudioTrack";
        internal const string FUNC_RTCENGINE_STOPPRIMARYCUSTOMAUDIOTRACK = "RtcEngine_stopPrimaryCustomAudioTrack";
        internal const string FUNC_RTCENGINE_STARTSECONDARYCUSTOMAUDIOTRACK = "RtcEngine_startSecondaryCustomAudioTrack";
        internal const string FUNC_RTCENGINE_STOPSECONDARYCUSTOMAUDIOTRACK = "RtcEngine_stopSecondaryCustomAudioTrack";
        internal const string FUNC_RTCENGINE_SETRECORDINGAUDIOFRAMEPARAMETERS = "RtcEngine_setRecordingAudioFrameParameters";
        internal const string FUNC_RTCENGINE_SETPLAYBACKAUDIOFRAMEPARAMETERS = "RtcEngine_setPlaybackAudioFrameParameters";
        internal const string FUNC_RTCENGINE_SETMIXEDAUDIOFRAMEPARAMETERS = "RtcEngine_setMixedAudioFrameParameters";
        internal const string FUNC_RTCENGINE_SETEARMONITORINGAUDIOFRAMEPARAMETERS = "RtcEngine_setEarMonitoringAudioFrameParameters";
        internal const string FUNC_RTCENGINE_SETPLAYBACKAUDIOFRAMEBEFOREMIXINGPARAMETERS = "RtcEngine_setPlaybackAudioFrameBeforeMixingParameters";
        internal const string FUNC_RTCENGINE_ENABLEAUDIOSPECTRUMMONITOR = "RtcEngine_enableAudioSpectrumMonitor";
        internal const string FUNC_RTCENGINE_DISABLEAUDIOSPECTRUMMONITOR = "RtcEngine_disableAudioSpectrumMonitor";
        internal const string FUNC_RTCENGINE_REGISTERAUDIOSPECTRUMOBSERVER = "RtcEngine_registerAudioSpectrumObserver";
        internal const string FUNC_RTCENGINE_UNREGISTERAUDIOSPECTRUMOBSERVER = "RtcEngine_unregisterAudioSpectrumObserver";
        internal const string FUNC_RTCENGINE_ADJUSTRECORDINGSIGNALVOLUME = "RtcEngine_adjustRecordingSignalVolume";
        internal const string FUNC_RTCENGINE_MUTERECORDINGSIGNAL = "RtcEngine_muteRecordingSignal";
        internal const string FUNC_RTCENGINE_ADJUSTPLAYBACKSIGNALVOLUME = "RtcEngine_adjustPlaybackSignalVolume";
        internal const string FUNC_RTCENGINE_ADJUSTUSERPLAYBACKSIGNALVOLUME = "RtcEngine_adjustUserPlaybackSignalVolume";
        internal const string FUNC_RTCENGINE_SETLOCALPUBLISHFALLBACKOPTION = "RtcEngine_setLocalPublishFallbackOption";
        internal const string FUNC_RTCENGINE_SETREMOTESUBSCRIBEFALLBACKOPTION = "RtcEngine_setRemoteSubscribeFallbackOption";
        internal const string FUNC_RTCENGINE_ENABLELOOPBACKRECORDING = "RtcEngine_enableLoopbackRecording";
        internal const string FUNC_RTCENGINE_ADJUSTLOOPBACKSIGNALVOLUME = "RtcEngine_adjustLoopbackSignalVolume";
        internal const string FUNC_RTCENGINE_GETLOOPBACKRECORDINGVOLUME = "RtcEngine_getLoopbackRecordingVolume";
        internal const string FUNC_RTCENGINE_ENABLEINEARMONITORING = "RtcEngine_enableInEarMonitoring";
        internal const string FUNC_RTCENGINE_SETINEARMONITORINGVOLUME = "RtcEngine_setInEarMonitoringVolume";
        internal const string FUNC_RTCENGINE_LOADEXTENSIONPROVIDER = "RtcEngine_loadExtensionProvider";
        internal const string FUNC_RTCENGINE_SETEXTENSIONPROVIDERPROPERTY = "RtcEngine_setExtensionProviderProperty";
        internal const string FUNC_RTCENGINE_ENABLEEXTENSION = "RtcEngine_enableExtension";
        internal const string FUNC_RTCENGINE_SETEXTENSIONPROPERTY = "RtcEngine_setExtensionProperty";
        internal const string FUNC_RTCENGINE_GETEXTENSIONPROPERTY = "RtcEngine_getExtensionProperty";
        internal const string FUNC_RTCENGINE_ENABLEEXTENSION2 = "RtcEngine_enableExtension2";
        internal const string FUNC_RTCENGINE_SETEXTENSIONPROPERTY2 = "RtcEngine_setExtensionProperty2";
        internal const string FUNC_RTCENGINE_GETEXTENSIONPROPERTY2 = "RtcEngine_getExtensionProperty2";
        internal const string FUNC_RTCENGINE_SETCAMERACAPTURERCONFIGURATION = "RtcEngine_setCameraCapturerConfiguration";
        internal const string FUNC_RTCENGINE_CREATECUSTOMVIDEOTRACK = "RtcEngine_createCustomVideoTrack";
        internal const string FUNC_RTCENGINE_CREATECUSTOMENCODEDVIDEOTRACK = "RtcEngine_createCustomEncodedVideoTrack";
        internal const string FUNC_RTCENGINE_DESTROYCUSTOMVIDEOTRACK = "RtcEngine_destroyCustomVideoTrack";
        internal const string FUNC_RTCENGINE_DESTROYCUSTOMENCODEDVIDEOTRACK = "RtcEngine_destroyCustomEncodedVideoTrack";
        internal const string FUNC_RTCENGINE_SWITCHCAMERA = "RtcEngine_switchCamera";
        internal const string FUNC_RTCENGINE_ISCAMERAZOOMSUPPORTED = "RtcEngine_isCameraZoomSupported";
        internal const string FUNC_RTCENGINE_ISCAMERAFACEDETECTSUPPORTED = "RtcEngine_isCameraFaceDetectSupported";
        internal const string FUNC_RTCENGINE_ISCAMERATORCHSUPPORTED = "RtcEngine_isCameraTorchSupported";
        internal const string FUNC_RTCENGINE_ISCAMERAFOCUSSUPPORTED = "RtcEngine_isCameraFocusSupported";
        internal const string FUNC_RTCENGINE_ISCAMERAAUTOFOCUSFACEMODESUPPORTED = "RtcEngine_isCameraAutoFocusFaceModeSupported";
        internal const string FUNC_RTCENGINE_SETCAMERAZOOMFACTOR = "RtcEngine_setCameraZoomFactor";
        internal const string FUNC_RTCENGINE_ENABLEFACEDETECTION = "RtcEngine_enableFaceDetection";
        internal const string FUNC_RTCENGINE_GETCAMERAMAXZOOMFACTOR = "RtcEngine_getCameraMaxZoomFactor";
        internal const string FUNC_RTCENGINE_SETCAMERAFOCUSPOSITIONINPREVIEW = "RtcEngine_setCameraFocusPositionInPreview";
        internal const string FUNC_RTCENGINE_SETCAMERATORCHON = "RtcEngine_setCameraTorchOn";
        internal const string FUNC_RTCENGINE_SETCAMERAAUTOFOCUSFACEMODEENABLED = "RtcEngine_setCameraAutoFocusFaceModeEnabled";
        internal const string FUNC_RTCENGINE_ISCAMERAEXPOSUREPOSITIONSUPPORTED = "RtcEngine_isCameraExposurePositionSupported";
        internal const string FUNC_RTCENGINE_SETCAMERAEXPOSUREPOSITION = "RtcEngine_setCameraExposurePosition";
        internal const string FUNC_RTCENGINE_ISCAMERAAUTOEXPOSUREFACEMODESUPPORTED = "RtcEngine_isCameraAutoExposureFaceModeSupported";
        internal const string FUNC_RTCENGINE_SETCAMERAAUTOEXPOSUREFACEMODEENABLED = "RtcEngine_setCameraAutoExposureFaceModeEnabled";
        internal const string FUNC_RTCENGINE_SETDEFAULTAUDIOROUTETOSPEAKERPHONE = "RtcEngine_setDefaultAudioRouteToSpeakerphone";
        internal const string FUNC_RTCENGINE_SETENABLESPEAKERPHONE = "RtcEngine_setEnableSpeakerphone";
        internal const string FUNC_RTCENGINE_ISSPEAKERPHONEENABLED = "RtcEngine_isSpeakerphoneEnabled";
        internal const string FUNC_RTCENGINE_GETSCREENCAPTURESOURCES = "RtcEngine_getScreenCaptureSources";
        internal const string FUNC_RTCENGINE_SETAUDIOSESSIONOPERATIONRESTRICTION = "RtcEngine_setAudioSessionOperationRestriction";
        internal const string FUNC_RTCENGINE_STARTSCREENCAPTUREBYDISPLAYID = "RtcEngine_startScreenCaptureByDisplayId";
        internal const string FUNC_RTCENGINE_STARTSCREENCAPTUREBYSCREENRECT = "RtcEngine_startScreenCaptureByScreenRect";
        internal const string FUNC_RTCENGINE_GETAUDIODEVICEINFO = "RtcEngine_getAudioDeviceInfo";
        internal const string FUNC_RTCENGINE_STARTSCREENCAPTUREBYWINDOWID = "RtcEngine_startScreenCaptureByWindowId";
        internal const string FUNC_RTCENGINE_SETSCREENCAPTURECONTENTHINT = "RtcEngine_setScreenCaptureContentHint";
        internal const string FUNC_RTCENGINE_SETSCREENCAPTURESCENARIO = "RtcEngine_setScreenCaptureScenario";
        internal const string FUNC_RTCENGINE_UPDATESCREENCAPTUREREGION = "RtcEngine_updateScreenCaptureRegion";
        internal const string FUNC_RTCENGINE_UPDATESCREENCAPTUREPARAMETERS = "RtcEngine_updateScreenCaptureParameters";
        internal const string FUNC_RTCENGINE_STARTSCREENCAPTURE = "RtcEngine_startScreenCapture";
        internal const string FUNC_RTCENGINE_UPDATESCREENCAPTURE = "RtcEngine_updateScreenCapture";
        internal const string FUNC_RTCENGINE_STOPSCREENCAPTURE = "RtcEngine_stopScreenCapture";
        internal const string FUNC_RTCENGINE_GETCALLID = "RtcEngine_getCallId";
        internal const string FUNC_RTCENGINE_RATE = "RtcEngine_rate";
        internal const string FUNC_RTCENGINE_COMPLAIN = "RtcEngine_complain";
        internal const string FUNC_RTCENGINE_STARTRTMPSTREAMWITHOUTTRANSCODING = "RtcEngine_startRtmpStreamWithoutTranscoding";
        internal const string FUNC_RTCENGINE_STARTRTMPSTREAMWITHTRANSCODING = "RtcEngine_startRtmpStreamWithTranscoding";
        internal const string FUNC_RTCENGINE_UPDATERTMPTRANSCODING = "RtcEngine_updateRtmpTranscoding";
        internal const string FUNC_RTCENGINE_STOPRTMPSTREAM = "RtcEngine_stopRtmpStream";
        internal const string FUNC_RTCENGINE_STARTLOCALVIDEOTRANSCODER = "RtcEngine_startLocalVideoTranscoder";
        internal const string FUNC_RTCENGINE_UPDATELOCALTRANSCODERCONFIGURATION = "RtcEngine_updateLocalTranscoderConfiguration";
        internal const string FUNC_RTCENGINE_STOPLOCALVIDEOTRANSCODER = "RtcEngine_stopLocalVideoTranscoder";
        internal const string FUNC_RTCENGINE_STARTPRIMARYCAMERACAPTURE = "RtcEngine_startPrimaryCameraCapture";
        internal const string FUNC_RTCENGINE_STARTSECONDARYCAMERACAPTURE = "RtcEngine_startSecondaryCameraCapture";
        internal const string FUNC_RTCENGINE_STOPPRIMARYCAMERACAPTURE = "RtcEngine_stopPrimaryCameraCapture";
        internal const string FUNC_RTCENGINE_STOPSECONDARYCAMERACAPTURE = "RtcEngine_stopSecondaryCameraCapture";
        internal const string FUNC_RTCENGINE_SETCAMERADEVICEORIENTATION = "RtcEngine_setCameraDeviceOrientation";
        internal const string FUNC_RTCENGINE_SETSCREENCAPTUREORIENTATION = "RtcEngine_setScreenCaptureOrientation";
        internal const string FUNC_RTCENGINE_STARTPRIMARYSCREENCAPTURE = "RtcEngine_startPrimaryScreenCapture";
        internal const string FUNC_RTCENGINE_STARTSECONDARYSCREENCAPTURE = "RtcEngine_startSecondaryScreenCapture";
        internal const string FUNC_RTCENGINE_STOPPRIMARYSCREENCAPTURE = "RtcEngine_stopPrimaryScreenCapture";
        internal const string FUNC_RTCENGINE_STOPSECONDARYSCREENCAPTURE = "RtcEngine_stopSecondaryScreenCapture";
        internal const string FUNC_RTCENGINE_GETCONNECTIONSTATE = "RtcEngine_getConnectionState";
        internal const string FUNC_RTCENGINE_REGISTEREVENTHANDLER = "RtcEngine_registerEventHandler";
        internal const string FUNC_RTCENGINE_UNREGISTEREVENTHANDLER = "RtcEngine_unregisterEventHandler";
        internal const string FUNC_RTCENGINE_SETREMOTEUSERPRIORITY = "RtcEngine_setRemoteUserPriority";
        internal const string FUNC_RTCENGINE_REGISTERPACKETOBSERVER = "RtcEngine_registerPacketObserver";
        internal const string FUNC_RTCENGINE_SETENCRYPTIONMODE = "RtcEngine_setEncryptionMode";
        internal const string FUNC_RTCENGINE_SETENCRYPTIONSECRET = "RtcEngine_setEncryptionSecret";
        internal const string FUNC_RTCENGINE_ENABLEENCRYPTION = "RtcEngine_enableEncryption";
        internal const string FUNC_RTCENGINE_CREATEDATASTREAM = "RtcEngine_createDataStream";
        internal const string FUNC_RTCENGINE_CREATEDATASTREAM2 = "RtcEngine_createDataStream2";
        internal const string FUNC_RTCENGINE_SENDSTREAMMESSAGE = "RtcEngine_sendStreamMessage";
        internal const string FUNC_RTCENGINE_ADDVIDEOWATERMARK = "RtcEngine_addVideoWatermark";
        internal const string FUNC_RTCENGINE_ADDVIDEOWATERMARK2 = "RtcEngine_addVideoWatermark2";
        internal const string FUNC_RTCENGINE_CLEARVIDEOWATERMARKS = "RtcEngine_clearVideoWatermarks";
        internal const string FUNC_RTCENGINE_PAUSEAUDIO = "RtcEngine_pauseAudio";
        internal const string FUNC_RTCENGINE_RESUMEAUDIO = "RtcEngine_resumeAudio";
        internal const string FUNC_RTCENGINE_ENABLEWEBSDKINTEROPERABILITY = "RtcEngine_enableWebSdkInteroperability";
        internal const string FUNC_RTCENGINE_SENDCUSTOMREPORTMESSAGE = "RtcEngine_sendCustomReportMessage";
        internal const string FUNC_RTCENGINE_REGISTERMEDIAMETADATAOBSERVER = "RtcEngine_registerMediaMetadataObserver";
        internal const string FUNC_RTCENGINE_UNREGISTERMEDIAMETADATAOBSERVER = "RtcEngine_unregisterMediaMetadataObserver";
        internal const string FUNC_RTCENGINE_STARTAUDIOFRAMEDUMP = "RtcEngine_startAudioFrameDump";
        internal const string FUNC_RTCENGINE_STOPAUDIOFRAMEDUMP = "RtcEngine_stopAudioFrameDump";
        internal const string FUNC_RTCENGINE_REGISTERLOCALUSERACCOUNT = "RtcEngine_registerLocalUserAccount";
        internal const string FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNT = "RtcEngine_joinChannelWithUserAccount";
        internal const string FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNT2 = "RtcEngine_joinChannelWithUserAccount2";
        internal const string FUNC_RTCENGINE_JOINCHANNELWITHUSERACCOUNTEX = "RtcEngine_joinChannelWithUserAccountEx";
        internal const string FUNC_RTCENGINE_GETUSERINFOBYUSERACCOUNT = "RtcEngine_getUserInfoByUserAccount";
        internal const string FUNC_RTCENGINE_GETUSERINFOBYUID = "RtcEngine_getUserInfoByUid";
        internal const string FUNC_RTCENGINE_STARTCHANNELMEDIARELAY = "RtcEngine_startChannelMediaRelay";
        internal const string FUNC_RTCENGINE_UPDATECHANNELMEDIARELAY = "RtcEngine_updateChannelMediaRelay";
        internal const string FUNC_RTCENGINE_STOPCHANNELMEDIARELAY = "RtcEngine_stopChannelMediaRelay";
        internal const string FUNC_RTCENGINE_PAUSEALLCHANNELMEDIARELAY = "RtcEngine_pauseAllChannelMediaRelay";
        internal const string FUNC_RTCENGINE_RESUMEALLCHANNELMEDIARELAY = "RtcEngine_resumeAllChannelMediaRelay";
        internal const string FUNC_RTCENGINE_SETDIRECTCDNSTREAMINGAUDIOCONFIGURATION = "RtcEngine_setDirectCdnStreamingAudioConfiguration";
        internal const string FUNC_RTCENGINE_SETDIRECTCDNSTREAMINGVIDEOCONFIGURATION = "RtcEngine_setDirectCdnStreamingVideoConfiguration";
        internal const string FUNC_RTCENGINE_STARTDIRECTCDNSTREAMING = "RtcEngine_startDirectCdnStreaming";
        internal const string FUNC_RTCENGINE_STOPDIRECTCDNSTREAMING = "RtcEngine_stopDirectCdnStreaming";
        internal const string FUNC_RTCENGINE_UPDATEDIRECTCDNSTREAMINGMEDIAOPTIONS = "RtcEngine_updateDirectCdnStreamingMediaOptions";
        internal const string FUNC_RTCENGINE_STARTRHYTHMPLAYER = "RtcEngine_startRhythmPlayer";
        internal const string FUNC_RTCENGINE_STOPRHYTHMPLAYER = "RtcEngine_stopRhythmPlayer";
        internal const string FUNC_RTCENGINE_CONFIGRHYTHMPLAYER = "RtcEngine_configRhythmPlayer";
        internal const string FUNC_RTCENGINE_TAKESNAPSHOT = "RtcEngine_takeSnapshot";
        internal const string FUNC_RTCENGINE_ENABLECONTENTINSPECT = "RtcEngine_enableContentInspect";
        internal const string FUNC_RTCENGINE_ADJUSTCUSTOMAUDIOPUBLISHVOLUME = "RtcEngine_adjustCustomAudioPublishVolume";
        internal const string FUNC_RTCENGINE_ADJUSTCUSTOMAUDIOPLAYOUTVOLUME = "RtcEngine_adjustCustomAudioPlayoutVolume";
        internal const string FUNC_RTCENGINE_SETCLOUDPROXY = "RtcEngine_setCloudProxy";
        internal const string FUNC_RTCENGINE_SETLOCALACCESSPOINT = "RtcEngine_setLocalAccessPoint";
        internal const string FUNC_RTCENGINE_SETADVANCEDAUDIOOPTIONS = "RtcEngine_setAdvancedAudioOptions";
        internal const string FUNC_RTCENGINE_SETAVSYNCSOURCE = "RtcEngine_setAVSyncSource";
        internal const string FUNC_RTCENGINE_ENABLEVIDEOIMAGESOURCE = "RtcEngine_enableVideoImageSource";
        internal const string FUNC_RTCENGINE_GETCURRENTMONOTONICTIMEINMS = "RtcEngine_getCurrentMonotonicTimeInMs";
        internal const string FUNC_RTCENGINE_ENABLEWIRELESSACCELERATE = "RtcEngine_enableWirelessAccelerate";
        internal const string FUNC_RTCENGINE_GETNETWORKTYPE = "RtcEngine_getNetworkType";
        #endregion

        #region IRtcEngineEx start

        internal const string FUNC_RTCENGINEEX_JOINCHANNELEX = "RtcEngineEx_joinChannelEx";
        internal const string FUNC_RTCENGINEEX_LEAVECHANNELEX = "RtcEngineEx_leaveChannelEx";
        internal const string FUNC_RTCENGINEEX_LEAVECHANNELEX2 = "RtcEngineEx_leaveChannelEx2";
        internal const string FUNC_RTCENGINEEX_UPDATECHANNELMEDIAOPTIONSEX = "RtcEngineEx_updateChannelMediaOptionsEx";
        internal const string FUNC_RTCENGINEEX_SETVIDEOENCODERCONFIGURATIONEX = "RtcEngineEx_setVideoEncoderConfigurationEx";
        internal const string FUNC_RTCENGINEEX_SETUPREMOTEVIDEOEX = "RtcEngineEx_setupRemoteVideoEx";
        internal const string FUNC_RTCENGINEEX_MUTEREMOTEAUDIOSTREAMEX = "RtcEngineEx_muteRemoteAudioStreamEx";
        internal const string FUNC_RTCENGINEEX_MUTEREMOTEVIDEOSTREAMEX = "RtcEngineEx_muteRemoteVideoStreamEx";
        internal const string FUNC_RTCENGINEEX_SETREMOTEVIDEOSTREAMTYPEEX = "RtcEngineEx_setRemoteVideoStreamTypeEx";
        internal const string FUNC_RTCENGINEEX_MUTELOCALAUDIOSTREAMEX = "RtcEngineEx_muteLocalAudioStreamEx";
        internal const string FUNC_RTCENGINEEX_MUTELOCALVIDEOSTREAMEX = "RtcEngineEx_muteLocalVideoStreamEx";
        internal const string FUNC_RTCENGINEEX_MUTEALLREMOTEAUDIOSTREAMSEX = "RtcEngineEx_muteAllRemoteAudioStreamsEx";
        internal const string FUNC_RTCENGINEEX_MUTEALLREMOTEVIDEOSTREAMSEX = "RtcEngineEx_muteAllRemoteVideoStreamsEx";
        internal const string FUNC_RTCENGINEEX_SETSUBSCRIBEAUDIOBLOCKLISTEX = "RtcEngineEx_setSubscribeAudioBlocklistEx";
        internal const string FUNC_RTCENGINEEX_SETSUBSCRIBEAUDIOALLOWLISTEX = "RtcEngineEx_setSubscribeAudioAllowlistEx";
        internal const string FUNC_RTCENGINEEX_SETSUBSCRIBEVIDEOBLOCKLISTEX = "RtcEngineEx_setSubscribeVideoBlocklistEx";
        internal const string FUNC_RTCENGINEEX_SETSUBSCRIBEVIDEOALLOWLISTEX = "RtcEngineEx_setSubscribeVideoAllowlistEx";
        internal const string FUNC_RTCENGINEEX_SETREMOTEVIDEOSUBSCRIPTIONOPTIONSEX = "RtcEngineEx_setRemoteVideoSubscriptionOptionsEx";
        internal const string FUNC_RTCENGINEEX_SETREMOTEVOICEPOSITIONEX = "RtcEngineEx_setRemoteVoicePositionEx";
        internal const string FUNC_RTCENGINEEX_SETREMOTEUSERSPATIALAUDIOPARAMSEX = "RtcEngineEx_setRemoteUserSpatialAudioParamsEx";
        internal const string FUNC_RTCENGINEEX_SETREMOTERENDERMODEEX = "RtcEngineEx_setRemoteRenderModeEx";
        internal const string FUNC_RTCENGINEEX_ENABLELOOPBACKRECORDINGEX = "RtcEngineEx_enableLoopbackRecordingEx";
        internal const string FUNC_RTCENGINEEX_ADJUSTUSERPLAYBACKSIGNALVOLUMEEX = "RtcEngineEx_adjustUserPlaybackSignalVolumeEx";
        internal const string FUNC_RTCENGINEEX_GETCONNECTIONSTATEEX = "RtcEngineEx_getConnectionStateEx";
        internal const string FUNC_RTCENGINEEX_ENABLEENCRYPTIONEX = "RtcEngineEx_enableEncryptionEx";
        internal const string FUNC_RTCENGINEEX_CREATEDATASTREAMEX = "RtcEngineEx_createDataStreamEx";
        internal const string FUNC_RTCENGINEEX_CREATEDATASTREAMEX2 = "RtcEngineEx_createDataStreamEx2";
        internal const string FUNC_RTCENGINEEX_SENDSTREAMMESSAGEEX = "RtcEngineEx_sendStreamMessageEx";
        internal const string FUNC_RTCENGINEEX_ADDVIDEOWATERMARKEX = "RtcEngineEx_addVideoWatermarkEx";
        internal const string FUNC_RTCENGINEEX_CLEARVIDEOWATERMARKEX = "RtcEngineEx_clearVideoWatermarkEx";
        internal const string FUNC_RTCENGINEEX_SENDCUSTOMREPORTMESSAGEEX = "RtcEngineEx_sendCustomReportMessageEx";
        internal const string FUNC_RTCENGINEEX_ENABLEAUDIOVOLUMEINDICATIONEX = "RtcEngineEx_enableAudioVolumeIndicationEx";
        internal const string FUNC_RTCENGINEEX_STARTRTMPSTREAMWITHOUTTRANSCODINGEX = "RtcEngineEx_startRtmpStreamWithoutTranscodingEx";
        internal const string FUNC_RTCENGINEEX_STARTRTMPSTREAMWITHTRANSCODINGEX = "RtcEngineEx_startRtmpStreamWithTranscodingEx";
        internal const string FUNC_RTCENGINEEX_UPDATERTMPTRANSCODINGEX = "RtcEngineEx_updateRtmpTranscodingEx";
        internal const string FUNC_RTCENGINEEX_STOPRTMPSTREAMEX = "RtcEngineEx_stopRtmpStreamEx";
        internal const string FUNC_RTCENGINEEX_STARTCHANNELMEDIARELAYEX = "RtcEngineEx_startChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_UPDATECHANNELMEDIARELAYEX = "RtcEngineEx_updateChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_STOPCHANNELMEDIARELAYEX = "RtcEngineEx_stopChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_PAUSEALLCHANNELMEDIARELAYEX = "RtcEngineEx_pauseAllChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_RESUMEALLCHANNELMEDIARELAYEX = "RtcEngineEx_resumeAllChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_GETUSERINFOBYUSERACCOUNTEX = "RtcEngineEx_getUserInfoByUserAccountEx";
        internal const string FUNC_RTCENGINEEX_GETUSERINFOBYUIDEX = "RtcEngineEx_getUserInfoByUidEx";
        internal const string FUNC_RTCENGINEEX_SETVIDEOPROFILEEX = "RtcEngineEx_setVideoProfileEx";
        internal const string FUNC_RTCENGINEEX_ENABLEDUALSTREAMMODEEX = "RtcEngineEx_enableDualStreamModeEx";
        internal const string FUNC_RTCENGINEEX_SETDUALSTREAMMODEEX = "RtcEngineEx_setDualStreamModeEx";
        internal const string FUNC_RTCENGINEEX_ENABLEWIRELESSACCELERATE = "RtcEngineEx_enableWirelessAccelerate";
        internal const string FUNC_RTCENGINEEX_TAKESNAPSHOTEX = "RtcEngineEx_takeSnapshotEx";
        #endregion

        #region IMediaPlayer start
        internal const string FUNC_MEDIAPLAYER_UNOPENWITHCUSTOMSOURCE = "MediaPlayer_unOpenWithCustomSource";
        internal const string FUNC_MEDIAPLAYER_UNOPENWITHMEDIASOURCE = "MediaPlayer_unOpenWithMediaSource";

        internal const string FUNC_MEDIAPLAYER_INITIALIZE = "MediaPlayer_initialize";
        internal const string FUNC_MEDIAPLAYER_GETMEDIAPLAYERID = "MediaPlayer_getMediaPlayerId";
        internal const string FUNC_MEDIAPLAYER_OPEN = "MediaPlayer_open";
        internal const string FUNC_MEDIAPLAYER_OPENWITHCUSTOMSOURCE = "MediaPlayer_openWithCustomSource";
        internal const string FUNC_MEDIAPLAYER_OPENWITHMEDIASOURCE = "MediaPlayer_openWithMediaSource";
        internal const string FUNC_MEDIAPLAYER_PLAY = "MediaPlayer_play";
        internal const string FUNC_MEDIAPLAYER_PAUSE = "MediaPlayer_pause";
        internal const string FUNC_MEDIAPLAYER_STOP = "MediaPlayer_stop";
        internal const string FUNC_MEDIAPLAYER_RESUME = "MediaPlayer_resume";
        internal const string FUNC_MEDIAPLAYER_SEEK = "MediaPlayer_seek";
        internal const string FUNC_MEDIAPLAYER_SETAUDIOPITCH = "MediaPlayer_setAudioPitch";
        internal const string FUNC_MEDIAPLAYER_GETDURATION = "MediaPlayer_getDuration";
        internal const string FUNC_MEDIAPLAYER_GETPLAYPOSITION = "MediaPlayer_getPlayPosition";
        internal const string FUNC_MEDIAPLAYER_GETSTREAMCOUNT = "MediaPlayer_getStreamCount";
        internal const string FUNC_MEDIAPLAYER_GETSTREAMINFO = "MediaPlayer_getStreamInfo";
        internal const string FUNC_MEDIAPLAYER_SETLOOPCOUNT = "MediaPlayer_setLoopCount";
        internal const string FUNC_MEDIAPLAYER_SETPLAYBACKSPEED = "MediaPlayer_setPlaybackSpeed";
        internal const string FUNC_MEDIAPLAYER_SELECTAUDIOTRACK = "MediaPlayer_selectAudioTrack";
        internal const string FUNC_MEDIAPLAYER_SETPLAYEROPTION = "MediaPlayer_setPlayerOption";
        internal const string FUNC_MEDIAPLAYER_SETPLAYEROPTION2 = "MediaPlayer_setPlayerOption2";
        internal const string FUNC_MEDIAPLAYER_TAKESCREENSHOT = "MediaPlayer_takeScreenshot";
        internal const string FUNC_MEDIAPLAYER_SELECTINTERNALSUBTITLE = "MediaPlayer_selectInternalSubtitle";
        internal const string FUNC_MEDIAPLAYER_SETEXTERNALSUBTITLE = "MediaPlayer_setExternalSubtitle";
        internal const string FUNC_MEDIAPLAYER_GETSTATE = "MediaPlayer_getState";
        internal const string FUNC_MEDIAPLAYER_MUTE = "MediaPlayer_mute";
        internal const string FUNC_MEDIAPLAYER_GETMUTE = "MediaPlayer_getMute";
        internal const string FUNC_MEDIAPLAYER_ADJUSTPLAYOUTVOLUME = "MediaPlayer_adjustPlayoutVolume";
        internal const string FUNC_MEDIAPLAYER_GETPLAYOUTVOLUME = "MediaPlayer_getPlayoutVolume";
        internal const string FUNC_MEDIAPLAYER_ADJUSTPUBLISHSIGNALVOLUME = "MediaPlayer_adjustPublishSignalVolume";
        internal const string FUNC_MEDIAPLAYER_GETPUBLISHSIGNALVOLUME = "MediaPlayer_getPublishSignalVolume";
        internal const string FUNC_MEDIAPLAYER_SETVIEW = "MediaPlayer_setView";
        internal const string FUNC_MEDIAPLAYER_SETRENDERMODE = "MediaPlayer_setRenderMode";
        internal const string FUNC_MEDIAPLAYER_REGISTERPLAYERSOURCEOBSERVER = "MediaPlayer_registerPlayerSourceObserver";
        internal const string FUNC_MEDIAPLAYER_UNREGISTERPLAYERSOURCEOBSERVER = "MediaPlayer_unregisterPlayerSourceObserver";
        internal const string FUNC_MEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER = "MediaPlayer_registerAudioFrameObserver";
        internal const string FUNC_MEDIAPLAYER_REGISTERAUDIOFRAMEOBSERVER2 = "MediaPlayer_registerAudioFrameObserver2";
        internal const string FUNC_MEDIAPLAYER_UNREGISTERAUDIOFRAMEOBSERVER = "MediaPlayer_unregisterAudioFrameObserver";
        internal const string FUNC_MEDIAPLAYER_REGISTERVIDEOFRAMEOBSERVER = "MediaPlayer_registerVideoFrameObserver";
        internal const string FUNC_MEDIAPLAYER_UNREGISTERVIDEOFRAMEOBSERVER = "MediaPlayer_unregisterVideoFrameObserver";
        internal const string FUNC_MEDIAPLAYER_REGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER = "MediaPlayer_registerMediaPlayerAudioSpectrumObserver";
        internal const string FUNC_MEDIAPLAYER_UNREGISTERMEDIAPLAYERAUDIOSPECTRUMOBSERVER = "MediaPlayer_unregisterMediaPlayerAudioSpectrumObserver";
        internal const string FUNC_MEDIAPLAYER_SETAUDIODUALMONOMODE = "MediaPlayer_setAudioDualMonoMode";
        internal const string FUNC_MEDIAPLAYER_GETPLAYERSDKVERSION = "MediaPlayer_getPlayerSdkVersion";
        internal const string FUNC_MEDIAPLAYER_GETPLAYSRC = "MediaPlayer_getPlaySrc";
        internal const string FUNC_MEDIAPLAYER_OPENWITHAGORACDNSRC = "MediaPlayer_openWithAgoraCDNSrc";
        internal const string FUNC_MEDIAPLAYER_GETAGORACDNLINECOUNT = "MediaPlayer_getAgoraCDNLineCount";
        internal const string FUNC_MEDIAPLAYER_SWITCHAGORACDNLINEBYINDEX = "MediaPlayer_switchAgoraCDNLineByIndex";
        internal const string FUNC_MEDIAPLAYER_GETCURRENTAGORACDNINDEX = "MediaPlayer_getCurrentAgoraCDNIndex";
        internal const string FUNC_MEDIAPLAYER_ENABLEAUTOSWITCHAGORACDN = "MediaPlayer_enableAutoSwitchAgoraCDN";
        internal const string FUNC_MEDIAPLAYER_RENEWAGORACDNSRCTOKEN = "MediaPlayer_renewAgoraCDNSrcToken";
        internal const string FUNC_MEDIAPLAYER_SWITCHAGORACDNSRC = "MediaPlayer_switchAgoraCDNSrc";
        internal const string FUNC_MEDIAPLAYER_SWITCHSRC = "MediaPlayer_switchSrc";
        internal const string FUNC_MEDIAPLAYER_PRELOADSRC = "MediaPlayer_preloadSrc";
        internal const string FUNC_MEDIAPLAYER_PLAYPRELOADEDSRC = "MediaPlayer_playPreloadedSrc";
        internal const string FUNC_MEDIAPLAYER_UNLOADSRC = "MediaPlayer_unloadSrc";
        internal const string FUNC_MEDIAPLAYER_SETSPATIALAUDIOPARAMS = "MediaPlayer_setSpatialAudioParams";
        internal const string FUNC_MEDIAPLAYER_SETSOUNDPOSITIONPARAMS = "MediaPlayer_setSoundPositionParams";
        #endregion

        #region IAudioDeviceManager start

        internal const string FUNC_AUDIODEVICEMANAGER_ENUMERATEPLAYBACKDEVICES = "AudioDeviceManager_enumeratePlaybackDevices";
        internal const string FUNC_AUDIODEVICEMANAGER_ENUMERATERECORDINGDEVICES = "AudioDeviceManager_enumerateRecordingDevices";
        internal const string FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICE = "AudioDeviceManager_setPlaybackDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICE = "AudioDeviceManager_getPlaybackDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEINFO = "AudioDeviceManager_getPlaybackDeviceInfo";
        internal const string FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEVOLUME = "AudioDeviceManager_setPlaybackDeviceVolume";
        internal const string FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEVOLUME = "AudioDeviceManager_getPlaybackDeviceVolume";
        internal const string FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICE = "AudioDeviceManager_setRecordingDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICE = "AudioDeviceManager_getRecordingDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEINFO = "AudioDeviceManager_getRecordingDeviceInfo";
        internal const string FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEVOLUME = "AudioDeviceManager_setRecordingDeviceVolume";
        internal const string FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEVOLUME = "AudioDeviceManager_getRecordingDeviceVolume";
        internal const string FUNC_AUDIODEVICEMANAGER_SETLOOPBACKDEVICE = "AudioDeviceManager_setLoopbackDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETLOOPBACKDEVICE = "AudioDeviceManager_getLoopbackDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEMUTE = "AudioDeviceManager_setPlaybackDeviceMute";
        internal const string FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEMUTE = "AudioDeviceManager_getPlaybackDeviceMute";
        internal const string FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEMUTE = "AudioDeviceManager_setRecordingDeviceMute";
        internal const string FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEMUTE = "AudioDeviceManager_getRecordingDeviceMute";
        internal const string FUNC_AUDIODEVICEMANAGER_STARTPLAYBACKDEVICETEST = "AudioDeviceManager_startPlaybackDeviceTest";
        internal const string FUNC_AUDIODEVICEMANAGER_STOPPLAYBACKDEVICETEST = "AudioDeviceManager_stopPlaybackDeviceTest";
        internal const string FUNC_AUDIODEVICEMANAGER_STARTRECORDINGDEVICETEST = "AudioDeviceManager_startRecordingDeviceTest";
        internal const string FUNC_AUDIODEVICEMANAGER_STOPRECORDINGDEVICETEST = "AudioDeviceManager_stopRecordingDeviceTest";
        internal const string FUNC_AUDIODEVICEMANAGER_STARTAUDIODEVICELOOPBACKTEST = "AudioDeviceManager_startAudioDeviceLoopbackTest";
        internal const string FUNC_AUDIODEVICEMANAGER_STOPAUDIODEVICELOOPBACKTEST = "AudioDeviceManager_stopAudioDeviceLoopbackTest";
        internal const string FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMPLAYBACKDEVICE = "AudioDeviceManager_followSystemPlaybackDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMRECORDINGDEVICE = "AudioDeviceManager_followSystemRecordingDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMLOOPBACKDEVICE = "AudioDeviceManager_followSystemLoopbackDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_RELEASE = "AudioDeviceManager_release";
        #endregion

        #region IVideoDeviceManager start

        internal const string FUNC_VIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES = "VideoDeviceManager_enumerateVideoDevices";
        internal const string FUNC_VIDEODEVICEMANAGER_SETDEVICE = "VideoDeviceManager_setDevice";
        internal const string FUNC_VIDEODEVICEMANAGER_GETDEVICE = "VideoDeviceManager_getDevice";
        internal const string FUNC_VIDEODEVICEMANAGER_NUMBEROFCAPABILITIES = "VideoDeviceManager_numberOfCapabilities";
        internal const string FUNC_VIDEODEVICEMANAGER_GETCAPABILITY = "VideoDeviceManager_getCapability";
        internal const string FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST = "VideoDeviceManager_startDeviceTest";
        internal const string FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST = "VideoDeviceManager_stopDeviceTest";
        internal const string FUNC_VIDEODEVICEMANAGER_RELEASE = "VideoDeviceManager_release";
        #endregion

        #region ICloudSpatialAudioEngine start
        #endregion

        #region ILocalSpatialAudioEngine start

        internal const string FUNC_LOCALSPATIALAUDIOENGINE_RELEASE = "LocalSpatialAudioEngine_release";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETMAXAUDIORECVCOUNT = "LocalSpatialAudioEngine_setMaxAudioRecvCount";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETAUDIORECVRANGE = "LocalSpatialAudioEngine_setAudioRecvRange";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETDISTANCEUNIT = "LocalSpatialAudioEngine_setDistanceUnit";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITION = "LocalSpatialAudioEngine_updateSelfPosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITIONEX = "LocalSpatialAudioEngine_updateSelfPositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATEPLAYERPOSITIONINFO = "LocalSpatialAudioEngine_updatePlayerPositionInfo";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETPARAMETERS = "LocalSpatialAudioEngine_setParameters";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_MUTELOCALAUDIOSTREAM = "LocalSpatialAudioEngine_muteLocalAudioStream";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_MUTEALLREMOTEAUDIOSTREAMS = "LocalSpatialAudioEngine_muteAllRemoteAudioStreams";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETZONES = "LocalSpatialAudioEngine_setZones";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETPLAYERATTENUATION = "LocalSpatialAudioEngine_setPlayerAttenuation";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_MUTEREMOTEAUDIOSTREAM = "LocalSpatialAudioEngine_muteRemoteAudioStream";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_INITIALIZE = "LocalSpatialAudioEngine_initialize";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITION = "LocalSpatialAudioEngine_updateRemotePosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITIONEX = "LocalSpatialAudioEngine_updateRemotePositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITION = "LocalSpatialAudioEngine_removeRemotePosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITIONEX = "LocalSpatialAudioEngine_removeRemotePositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONS = "LocalSpatialAudioEngine_clearRemotePositions";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONSEX = "LocalSpatialAudioEngine_clearRemotePositionsEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETREMOTEAUDIOATTENUATION = "LocalSpatialAudioEngine_setRemoteAudioAttenuation";
        #endregion

        #region IMediaEngine start
        internal const string FUNC_MEDIAENGINE_UNREGISTERAUDIOFRAMEOBSERVER = "MediaEngine_unregisterAudioFrameObserver";
        internal const string FUNC_MEDIAENGINE_UNREGISTERVIDEOFRAMEOBSERVER = "MediaEngine_unregisterVideoFrameObserver";
        internal const string FUNC_MEDIAENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER = "MediaEngine_unregisterVideoEncodedFrameObserver";

        internal const string FUNC_MEDIAENGINE_REGISTERAUDIOFRAMEOBSERVER = "MediaEngine_registerAudioFrameObserver";
        internal const string FUNC_MEDIAENGINE_REGISTERVIDEOFRAMEOBSERVER = "MediaEngine_registerVideoFrameObserver";
        internal const string FUNC_MEDIAENGINE_REGISTERVIDEOENCODEDFRAMEOBSERVER = "MediaEngine_registerVideoEncodedFrameObserver";
        internal const string FUNC_MEDIAENGINE_PUSHAUDIOFRAME = "MediaEngine_pushAudioFrame";
        internal const string FUNC_MEDIAENGINE_PUSHCAPTUREAUDIOFRAME = "MediaEngine_pushCaptureAudioFrame";
        internal const string FUNC_MEDIAENGINE_PUSHREVERSEAUDIOFRAME = "MediaEngine_pushReverseAudioFrame";
        internal const string FUNC_MEDIAENGINE_PUSHDIRECTAUDIOFRAME = "MediaEngine_pushDirectAudioFrame";
        internal const string FUNC_MEDIAENGINE_PULLAUDIOFRAME = "MediaEngine_pullAudioFrame";
        internal const string FUNC_MEDIAENGINE_SETEXTERNALVIDEOSOURCE = "MediaEngine_setExternalVideoSource";
        internal const string FUNC_MEDIAENGINE_SETEXTERNALAUDIOSOURCE = "MediaEngine_setExternalAudioSource";
        internal const string FUNC_MEDIAENGINE_SETEXTERNALAUDIOSINK = "MediaEngine_setExternalAudioSink";
        internal const string FUNC_MEDIAENGINE_ENABLECUSTOMAUDIOLOCALPLAYBACK = "MediaEngine_enableCustomAudioLocalPlayback";
        internal const string FUNC_MEDIAENGINE_SETDIRECTEXTERNALAUDIOSOURCE = "MediaEngine_setDirectExternalAudioSource";
        internal const string FUNC_MEDIAENGINE_PUSHVIDEOFRAME = "MediaEngine_pushVideoFrame";
        internal const string FUNC_MEDIAENGINE_PUSHENCODEDVIDEOIMAGE = "MediaEngine_pushEncodedVideoImage";
        internal const string FUNC_MEDIAENGINE_RELEASE = "MediaEngine_release";
        #endregion


        #region IMediaPlayerCacheManager start

        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_REMOVEALLCACHES = "MediaPlayerCacheManager_removeAllCaches";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_REMOVEOLDCACHE = "MediaPlayerCacheManager_removeOldCache";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_REMOVECACHEBYURI = "MediaPlayerCacheManager_removeCacheByUri";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_SETCACHEDIR = "MediaPlayerCacheManager_setCacheDir";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_SETMAXCACHEFILECOUNT = "MediaPlayerCacheManager_setMaxCacheFileCount";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_SETMAXCACHEFILESIZE = "MediaPlayerCacheManager_setMaxCacheFileSize";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_ENABLEAUTOREMOVECACHE = "MediaPlayerCacheManager_enableAutoRemoveCache";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_GETCACHEDIR = "MediaPlayerCacheManager_getCacheDir";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_GETMAXCACHEFILECOUNT = "MediaPlayerCacheManager_getMaxCacheFileCount";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_GETMAXCACHEFILESIZE = "MediaPlayerCacheManager_getMaxCacheFileSize";
        internal const string FUNC_MEDIAPLAYERCACHEMANAGER_GETCACHEFILECOUNT = "MediaPlayerCacheManager_getCacheFileCount";
        #endregion

        #region IMediaRecorder start

        internal const string FUNC_MEDIARECORDER_UNSETMEDIARECORDEROBSERVER = "MediaRecoMediaRecorder_unsetMediaRecorderObserverrder_un";


        internal const string FUNC_MEDIARECORDER_SETMEDIARECORDEROBSERVER = "MediaRecorder_setMediaRecorderObserver";
        internal const string FUNC_MEDIARECORDER_STARTRECORDING = "MediaRecorder_startRecording";
        internal const string FUNC_MEDIARECORDER_STOPRECORDING = "MediaRecorder_stopRecording";
        internal const string FUNC_MEDIARECORDER_RELEASE = "MediaRecorder_release";
        #endregion

        #region IMusicContentCenter start
        internal const string FUNC_MUSICCONTENTCENTER_DESTROYMUSICPLAYER = "MusicContentCenter_destroyMusicPlayer";

        internal const string FUNC_MUSICCONTENTCENTER_INITIALIZE = "MusicContentCenter_initialize";
        internal const string FUNC_MUSICCONTENTCENTER_RELEASE = "MusicContentCenter_release";
        internal const string FUNC_MUSICCONTENTCENTER_REGISTEREVENTHANDLER = "MusicContentCenter_registerEventHandler";
        internal const string FUNC_MUSICCONTENTCENTER_UNREGISTEREVENTHANDLER = "MusicContentCenter_unregisterEventHandler";
        internal const string FUNC_MUSICCONTENTCENTER_CREATEMUSICPLAYER = "MusicContentCenter_createMusicPlayer";
        internal const string FUNC_MUSICCONTENTCENTER_GETMUSICCHARTS = "MusicContentCenter_getMusicCharts";
        internal const string FUNC_MUSICCONTENTCENTER_GETMUSICCOLLECTIONBYMUSICCHARTID = "MusicContentCenter_getMusicCollectionByMusicChartId";
        internal const string FUNC_MUSICCONTENTCENTER_SEARCHMUSIC = "MusicContentCenter_searchMusic";
        internal const string FUNC_MUSICCONTENTCENTER_PRELOAD = "MusicContentCenter_preload";
        internal const string FUNC_MUSICCONTENTCENTER_ISPRELOADED = "MusicContentCenter_isPreloaded";
        internal const string FUNC_MUSICCONTENTCENTER_GETLYRIC = "MusicContentCenter_getLyric";
        #endregion

        #region IMusicPlayer start

        internal const string FUNC_MUSICPLAYER_OPEN = "MusicPlayer_open";
        #endregion
    }
}