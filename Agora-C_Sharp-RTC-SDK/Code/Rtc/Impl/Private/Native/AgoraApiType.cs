#define AGORA_RTC
#define AGORA_RTM
using System;

namespace Agora.Rtc
{
    internal static class AgoraApiType
    {
        internal const string FUNC_RTCENGINEBASE_UNREGISTERAUDIOENCODEDFRAMEOBSERVER = "RtcEngineBase_unregisterAudioEncodedFrameObserver";
        internal const string FUNC_RTCENGINEBASE_SETAPPTYPE = "RtcEngineRtcEngineBase_setAppType";
        internal const string FUNC_RTCENGINEBASE_RELEASESCREENCAPTURESOURCES = "RtcEngineBase_releaseScreenCaptureSources";
        internal const string FUNC_RTCENGINEBASE_GETNATIVEHANDLE = "RtcEngineBase_getNativeHandle";
        internal const string FUNC_RTCENGINEBASE_SETMAXMETADATASIZE = "RtcEngineBase_setMaxMetadataSize";
        #region terra IRtcEngineBase

        internal const string FUNC_RTCENGINEBASE_RELEASE = "RtcEngineBase_release";
        internal const string FUNC_RTCENGINEBASE_QUERYINTERFACE = "RtcEngineBase_queryInterface";
        internal const string FUNC_RTCENGINEBASE_GETVERSION = "RtcEngineBase_getVersion";
        internal const string FUNC_RTCENGINEBASE_GETERRORDESCRIPTION = "RtcEngineBase_getErrorDescription";
        internal const string FUNC_RTCENGINEBASE_QUERYCODECCAPABILITY = "RtcEngineBase_queryCodecCapability";
        internal const string FUNC_RTCENGINEBASE_QUERYDEVICESCORE = "RtcEngineBase_queryDeviceScore";
        internal const string FUNC_RTCENGINEBASE_UPDATECHANNELMEDIAOPTIONS = "RtcEngineBase_updateChannelMediaOptions";
        internal const string FUNC_RTCENGINEBASE_LEAVECHANNEL = "RtcEngineBase_leaveChannel";
        internal const string FUNC_RTCENGINEBASE_LEAVECHANNEL2 = "RtcEngineBase_leaveChannel2";
        internal const string FUNC_RTCENGINEBASE_RENEWTOKEN = "RtcEngineBase_renewToken";
        internal const string FUNC_RTCENGINEBASE_SETCHANNELPROFILE = "RtcEngineBase_setChannelProfile";
        internal const string FUNC_RTCENGINEBASE_SETCLIENTROLE = "RtcEngineBase_setClientRole";
        internal const string FUNC_RTCENGINEBASE_SETCLIENTROLE2 = "RtcEngineBase_setClientRole2";
        internal const string FUNC_RTCENGINEBASE_STARTECHOTEST = "RtcEngineBase_startEchoTest";
        internal const string FUNC_RTCENGINEBASE_STARTECHOTEST2 = "RtcEngineBase_startEchoTest2";
        internal const string FUNC_RTCENGINEBASE_STARTECHOTEST3 = "RtcEngineBase_startEchoTest3";
        internal const string FUNC_RTCENGINEBASE_STOPECHOTEST = "RtcEngineBase_stopEchoTest";
        internal const string FUNC_RTCENGINEBASE_ENABLEMULTICAMERA = "RtcEngineBase_enableMultiCamera";
        internal const string FUNC_RTCENGINEBASE_ENABLEVIDEO = "RtcEngineBase_enableVideo";
        internal const string FUNC_RTCENGINEBASE_DISABLEVIDEO = "RtcEngineBase_disableVideo";
        internal const string FUNC_RTCENGINEBASE_STARTPREVIEW = "RtcEngineBase_startPreview";
        internal const string FUNC_RTCENGINEBASE_STARTPREVIEW2 = "RtcEngineBase_startPreview2";
        internal const string FUNC_RTCENGINEBASE_STOPPREVIEW = "RtcEngineBase_stopPreview";
        internal const string FUNC_RTCENGINEBASE_STOPPREVIEW2 = "RtcEngineBase_stopPreview2";
        internal const string FUNC_RTCENGINEBASE_STARTLASTMILEPROBETEST = "RtcEngineBase_startLastmileProbeTest";
        internal const string FUNC_RTCENGINEBASE_STOPLASTMILEPROBETEST = "RtcEngineBase_stopLastmileProbeTest";
        internal const string FUNC_RTCENGINEBASE_SETVIDEOENCODERCONFIGURATION = "RtcEngineBase_setVideoEncoderConfiguration";
        internal const string FUNC_RTCENGINEBASE_SETBEAUTYEFFECTOPTIONS = "RtcEngineBase_setBeautyEffectOptions";
        internal const string FUNC_RTCENGINEBASE_SETLOWLIGHTENHANCEOPTIONS = "RtcEngineBase_setLowlightEnhanceOptions";
        internal const string FUNC_RTCENGINEBASE_SETVIDEODENOISEROPTIONS = "RtcEngineBase_setVideoDenoiserOptions";
        internal const string FUNC_RTCENGINEBASE_SETCOLORENHANCEOPTIONS = "RtcEngineBase_setColorEnhanceOptions";
        internal const string FUNC_RTCENGINEBASE_ENABLEVIRTUALBACKGROUND = "RtcEngineBase_enableVirtualBackground";
        internal const string FUNC_RTCENGINEBASE_SETVIDEOSCENARIO = "RtcEngineBase_setVideoScenario";
        internal const string FUNC_RTCENGINEBASE_SETVIDEOQOEPREFERENCE = "RtcEngineBase_setVideoQoEPreference";
        internal const string FUNC_RTCENGINEBASE_ENABLEAUDIO = "RtcEngineBase_enableAudio";
        internal const string FUNC_RTCENGINEBASE_DISABLEAUDIO = "RtcEngineBase_disableAudio";
        internal const string FUNC_RTCENGINEBASE_SETAUDIOPROFILE = "RtcEngineBase_setAudioProfile";
        internal const string FUNC_RTCENGINEBASE_SETAUDIOSCENARIO = "RtcEngineBase_setAudioScenario";
        internal const string FUNC_RTCENGINEBASE_ENABLELOCALAUDIO = "RtcEngineBase_enableLocalAudio";
        internal const string FUNC_RTCENGINEBASE_MUTELOCALAUDIOSTREAM = "RtcEngineBase_muteLocalAudioStream";
        internal const string FUNC_RTCENGINEBASE_MUTEALLREMOTEAUDIOSTREAMS = "RtcEngineBase_muteAllRemoteAudioStreams";
        internal const string FUNC_RTCENGINEBASE_MUTELOCALVIDEOSTREAM = "RtcEngineBase_muteLocalVideoStream";
        internal const string FUNC_RTCENGINEBASE_ENABLELOCALVIDEO = "RtcEngineBase_enableLocalVideo";
        internal const string FUNC_RTCENGINEBASE_MUTEALLREMOTEVIDEOSTREAMS = "RtcEngineBase_muteAllRemoteVideoStreams";
        internal const string FUNC_RTCENGINEBASE_SETREMOTEDEFAULTVIDEOSTREAMTYPE = "RtcEngineBase_setRemoteDefaultVideoStreamType";
        internal const string FUNC_RTCENGINEBASE_ENABLEAUDIOVOLUMEINDICATION = "RtcEngineBase_enableAudioVolumeIndication";
        internal const string FUNC_RTCENGINEBASE_STARTAUDIORECORDING = "RtcEngineBase_startAudioRecording";
        internal const string FUNC_RTCENGINEBASE_STARTAUDIORECORDING2 = "RtcEngineBase_startAudioRecording2";
        internal const string FUNC_RTCENGINEBASE_STARTAUDIORECORDING3 = "RtcEngineBase_startAudioRecording3";
        internal const string FUNC_RTCENGINEBASE_REGISTERAUDIOENCODEDFRAMEOBSERVER = "RtcEngineBase_registerAudioEncodedFrameObserver";
        internal const string FUNC_RTCENGINEBASE_STOPAUDIORECORDING = "RtcEngineBase_stopAudioRecording";
        internal const string FUNC_RTCENGINEBASE_CREATEMEDIAPLAYER = "RtcEngineBase_createMediaPlayer";
        internal const string FUNC_RTCENGINEBASE_DESTROYMEDIAPLAYER = "RtcEngineBase_destroyMediaPlayer";
        internal const string FUNC_RTCENGINEBASE_STARTAUDIOMIXING = "RtcEngineBase_startAudioMixing";
        internal const string FUNC_RTCENGINEBASE_STARTAUDIOMIXING2 = "RtcEngineBase_startAudioMixing2";
        internal const string FUNC_RTCENGINEBASE_STOPAUDIOMIXING = "RtcEngineBase_stopAudioMixing";
        internal const string FUNC_RTCENGINEBASE_PAUSEAUDIOMIXING = "RtcEngineBase_pauseAudioMixing";
        internal const string FUNC_RTCENGINEBASE_RESUMEAUDIOMIXING = "RtcEngineBase_resumeAudioMixing";
        internal const string FUNC_RTCENGINEBASE_SELECTAUDIOTRACK = "RtcEngineBase_selectAudioTrack";
        internal const string FUNC_RTCENGINEBASE_GETAUDIOTRACKCOUNT = "RtcEngineBase_getAudioTrackCount";
        internal const string FUNC_RTCENGINEBASE_ADJUSTAUDIOMIXINGVOLUME = "RtcEngineBase_adjustAudioMixingVolume";
        internal const string FUNC_RTCENGINEBASE_ADJUSTAUDIOMIXINGPUBLISHVOLUME = "RtcEngineBase_adjustAudioMixingPublishVolume";
        internal const string FUNC_RTCENGINEBASE_GETAUDIOMIXINGPUBLISHVOLUME = "RtcEngineBase_getAudioMixingPublishVolume";
        internal const string FUNC_RTCENGINEBASE_ADJUSTAUDIOMIXINGPLAYOUTVOLUME = "RtcEngineBase_adjustAudioMixingPlayoutVolume";
        internal const string FUNC_RTCENGINEBASE_GETAUDIOMIXINGPLAYOUTVOLUME = "RtcEngineBase_getAudioMixingPlayoutVolume";
        internal const string FUNC_RTCENGINEBASE_GETAUDIOMIXINGDURATION = "RtcEngineBase_getAudioMixingDuration";
        internal const string FUNC_RTCENGINEBASE_GETAUDIOMIXINGCURRENTPOSITION = "RtcEngineBase_getAudioMixingCurrentPosition";
        internal const string FUNC_RTCENGINEBASE_SETAUDIOMIXINGPOSITION = "RtcEngineBase_setAudioMixingPosition";
        internal const string FUNC_RTCENGINEBASE_SETAUDIOMIXINGDUALMONOMODE = "RtcEngineBase_setAudioMixingDualMonoMode";
        internal const string FUNC_RTCENGINEBASE_SETAUDIOMIXINGPITCH = "RtcEngineBase_setAudioMixingPitch";
        internal const string FUNC_RTCENGINEBASE_GETEFFECTSVOLUME = "RtcEngineBase_getEffectsVolume";
        internal const string FUNC_RTCENGINEBASE_SETEFFECTSVOLUME = "RtcEngineBase_setEffectsVolume";
        internal const string FUNC_RTCENGINEBASE_PRELOADEFFECT = "RtcEngineBase_preloadEffect";
        internal const string FUNC_RTCENGINEBASE_PLAYEFFECT = "RtcEngineBase_playEffect";
        internal const string FUNC_RTCENGINEBASE_PLAYALLEFFECTS = "RtcEngineBase_playAllEffects";
        internal const string FUNC_RTCENGINEBASE_GETVOLUMEOFEFFECT = "RtcEngineBase_getVolumeOfEffect";
        internal const string FUNC_RTCENGINEBASE_SETVOLUMEOFEFFECT = "RtcEngineBase_setVolumeOfEffect";
        internal const string FUNC_RTCENGINEBASE_PAUSEEFFECT = "RtcEngineBase_pauseEffect";
        internal const string FUNC_RTCENGINEBASE_PAUSEALLEFFECTS = "RtcEngineBase_pauseAllEffects";
        internal const string FUNC_RTCENGINEBASE_RESUMEEFFECT = "RtcEngineBase_resumeEffect";
        internal const string FUNC_RTCENGINEBASE_RESUMEALLEFFECTS = "RtcEngineBase_resumeAllEffects";
        internal const string FUNC_RTCENGINEBASE_STOPEFFECT = "RtcEngineBase_stopEffect";
        internal const string FUNC_RTCENGINEBASE_STOPALLEFFECTS = "RtcEngineBase_stopAllEffects";
        internal const string FUNC_RTCENGINEBASE_UNLOADEFFECT = "RtcEngineBase_unloadEffect";
        internal const string FUNC_RTCENGINEBASE_UNLOADALLEFFECTS = "RtcEngineBase_unloadAllEffects";
        internal const string FUNC_RTCENGINEBASE_GETEFFECTDURATION = "RtcEngineBase_getEffectDuration";
        internal const string FUNC_RTCENGINEBASE_SETEFFECTPOSITION = "RtcEngineBase_setEffectPosition";
        internal const string FUNC_RTCENGINEBASE_GETEFFECTCURRENTPOSITION = "RtcEngineBase_getEffectCurrentPosition";
        internal const string FUNC_RTCENGINEBASE_ENABLESOUNDPOSITIONINDICATION = "RtcEngineBase_enableSoundPositionIndication";
        internal const string FUNC_RTCENGINEBASE_ENABLESPATIALAUDIO = "RtcEngineBase_enableSpatialAudio";
        internal const string FUNC_RTCENGINEBASE_SETVOICEBEAUTIFIERPRESET = "RtcEngineBase_setVoiceBeautifierPreset";
        internal const string FUNC_RTCENGINEBASE_SETAUDIOEFFECTPRESET = "RtcEngineBase_setAudioEffectPreset";
        internal const string FUNC_RTCENGINEBASE_SETVOICECONVERSIONPRESET = "RtcEngineBase_setVoiceConversionPreset";
        internal const string FUNC_RTCENGINEBASE_SETAUDIOEFFECTPARAMETERS = "RtcEngineBase_setAudioEffectParameters";
        internal const string FUNC_RTCENGINEBASE_SETVOICEBEAUTIFIERPARAMETERS = "RtcEngineBase_setVoiceBeautifierParameters";
        internal const string FUNC_RTCENGINEBASE_SETVOICECONVERSIONPARAMETERS = "RtcEngineBase_setVoiceConversionParameters";
        internal const string FUNC_RTCENGINEBASE_SETLOCALVOICEPITCH = "RtcEngineBase_setLocalVoicePitch";
        internal const string FUNC_RTCENGINEBASE_SETLOCALVOICEFORMANT = "RtcEngineBase_setLocalVoiceFormant";
        internal const string FUNC_RTCENGINEBASE_SETLOCALVOICEEQUALIZATION = "RtcEngineBase_setLocalVoiceEqualization";
        internal const string FUNC_RTCENGINEBASE_SETLOCALVOICEREVERB = "RtcEngineBase_setLocalVoiceReverb";
        internal const string FUNC_RTCENGINEBASE_SETHEADPHONEEQPRESET = "RtcEngineBase_setHeadphoneEQPreset";
        internal const string FUNC_RTCENGINEBASE_SETHEADPHONEEQPARAMETERS = "RtcEngineBase_setHeadphoneEQParameters";
        internal const string FUNC_RTCENGINEBASE_SETLOGFILE = "RtcEngineBase_setLogFile";
        internal const string FUNC_RTCENGINEBASE_SETLOGFILTER = "RtcEngineBase_setLogFilter";
        internal const string FUNC_RTCENGINEBASE_SETLOGLEVEL = "RtcEngineBase_setLogLevel";
        internal const string FUNC_RTCENGINEBASE_SETLOGFILESIZE = "RtcEngineBase_setLogFileSize";
        internal const string FUNC_RTCENGINEBASE_UPLOADLOGFILE = "RtcEngineBase_uploadLogFile";
        internal const string FUNC_RTCENGINEBASE_SETLOCALRENDERMODE = "RtcEngineBase_setLocalRenderMode";
        internal const string FUNC_RTCENGINEBASE_SETLOCALRENDERMODE2 = "RtcEngineBase_setLocalRenderMode2";
        internal const string FUNC_RTCENGINEBASE_SETLOCALVIDEOMIRRORMODE = "RtcEngineBase_setLocalVideoMirrorMode";
        internal const string FUNC_RTCENGINEBASE_ENABLEDUALSTREAMMODE = "RtcEngineBase_enableDualStreamMode";
        internal const string FUNC_RTCENGINEBASE_ENABLEDUALSTREAMMODE2 = "RtcEngineBase_enableDualStreamMode2";
        internal const string FUNC_RTCENGINEBASE_SETDUALSTREAMMODE = "RtcEngineBase_setDualStreamMode";
        internal const string FUNC_RTCENGINEBASE_SETDUALSTREAMMODE2 = "RtcEngineBase_setDualStreamMode2";
        internal const string FUNC_RTCENGINEBASE_ENABLECUSTOMAUDIOLOCALPLAYBACK = "RtcEngineBase_enableCustomAudioLocalPlayback";
        internal const string FUNC_RTCENGINEBASE_SETRECORDINGAUDIOFRAMEPARAMETERS = "RtcEngineBase_setRecordingAudioFrameParameters";
        internal const string FUNC_RTCENGINEBASE_SETPLAYBACKAUDIOFRAMEPARAMETERS = "RtcEngineBase_setPlaybackAudioFrameParameters";
        internal const string FUNC_RTCENGINEBASE_SETMIXEDAUDIOFRAMEPARAMETERS = "RtcEngineBase_setMixedAudioFrameParameters";
        internal const string FUNC_RTCENGINEBASE_SETEARMONITORINGAUDIOFRAMEPARAMETERS = "RtcEngineBase_setEarMonitoringAudioFrameParameters";
        internal const string FUNC_RTCENGINEBASE_SETPLAYBACKAUDIOFRAMEBEFOREMIXINGPARAMETERS = "RtcEngineBase_setPlaybackAudioFrameBeforeMixingParameters";
        internal const string FUNC_RTCENGINEBASE_ENABLEAUDIOSPECTRUMMONITOR = "RtcEngineBase_enableAudioSpectrumMonitor";
        internal const string FUNC_RTCENGINEBASE_DISABLEAUDIOSPECTRUMMONITOR = "RtcEngineBase_disableAudioSpectrumMonitor";
        internal const string FUNC_RTCENGINEBASE_ADJUSTRECORDINGSIGNALVOLUME = "RtcEngineBase_adjustRecordingSignalVolume";
        internal const string FUNC_RTCENGINEBASE_MUTERECORDINGSIGNAL = "RtcEngineBase_muteRecordingSignal";
        internal const string FUNC_RTCENGINEBASE_ADJUSTPLAYBACKSIGNALVOLUME = "RtcEngineBase_adjustPlaybackSignalVolume";
        internal const string FUNC_RTCENGINEBASE_SETLOCALPUBLISHFALLBACKOPTION = "RtcEngineBase_setLocalPublishFallbackOption";
        internal const string FUNC_RTCENGINEBASE_SETREMOTESUBSCRIBEFALLBACKOPTION = "RtcEngineBase_setRemoteSubscribeFallbackOption";
        internal const string FUNC_RTCENGINEBASE_ENABLELOOPBACKRECORDING = "RtcEngineBase_enableLoopbackRecording";
        internal const string FUNC_RTCENGINEBASE_ADJUSTLOOPBACKSIGNALVOLUME = "RtcEngineBase_adjustLoopbackSignalVolume";
        internal const string FUNC_RTCENGINEBASE_GETLOOPBACKRECORDINGVOLUME = "RtcEngineBase_getLoopbackRecordingVolume";
        internal const string FUNC_RTCENGINEBASE_ENABLEINEARMONITORING = "RtcEngineBase_enableInEarMonitoring";
        internal const string FUNC_RTCENGINEBASE_SETINEARMONITORINGVOLUME = "RtcEngineBase_setInEarMonitoringVolume";
        internal const string FUNC_RTCENGINEBASE_LOADEXTENSIONPROVIDER = "RtcEngineBase_loadExtensionProvider";
        internal const string FUNC_RTCENGINEBASE_SETEXTENSIONPROVIDERPROPERTY = "RtcEngineBase_setExtensionProviderProperty";
        internal const string FUNC_RTCENGINEBASE_REGISTEREXTENSION = "RtcEngineBase_registerExtension";
        internal const string FUNC_RTCENGINEBASE_ENABLEEXTENSION = "RtcEngineBase_enableExtension";
        internal const string FUNC_RTCENGINEBASE_SETEXTENSIONPROPERTY = "RtcEngineBase_setExtensionProperty";
        internal const string FUNC_RTCENGINEBASE_GETEXTENSIONPROPERTY = "RtcEngineBase_getExtensionProperty";
        internal const string FUNC_RTCENGINEBASE_SETCAMERACAPTURERCONFIGURATION = "RtcEngineBase_setCameraCapturerConfiguration";
        internal const string FUNC_RTCENGINEBASE_CREATECUSTOMVIDEOTRACK = "RtcEngineBase_createCustomVideoTrack";
        internal const string FUNC_RTCENGINEBASE_CREATECUSTOMENCODEDVIDEOTRACK = "RtcEngineBase_createCustomEncodedVideoTrack";
        internal const string FUNC_RTCENGINEBASE_DESTROYCUSTOMVIDEOTRACK = "RtcEngineBase_destroyCustomVideoTrack";
        internal const string FUNC_RTCENGINEBASE_DESTROYCUSTOMENCODEDVIDEOTRACK = "RtcEngineBase_destroyCustomEncodedVideoTrack";
        internal const string FUNC_RTCENGINEBASE_SWITCHCAMERA = "RtcEngineBase_switchCamera";
        internal const string FUNC_RTCENGINEBASE_ISCAMERAZOOMSUPPORTED = "RtcEngineBase_isCameraZoomSupported";
        internal const string FUNC_RTCENGINEBASE_ISCAMERAFACEDETECTSUPPORTED = "RtcEngineBase_isCameraFaceDetectSupported";
        internal const string FUNC_RTCENGINEBASE_ISCAMERATORCHSUPPORTED = "RtcEngineBase_isCameraTorchSupported";
        internal const string FUNC_RTCENGINEBASE_ISCAMERAFOCUSSUPPORTED = "RtcEngineBase_isCameraFocusSupported";
        internal const string FUNC_RTCENGINEBASE_ISCAMERAAUTOFOCUSFACEMODESUPPORTED = "RtcEngineBase_isCameraAutoFocusFaceModeSupported";
        internal const string FUNC_RTCENGINEBASE_SETCAMERAZOOMFACTOR = "RtcEngineBase_setCameraZoomFactor";
        internal const string FUNC_RTCENGINEBASE_ENABLEFACEDETECTION = "RtcEngineBase_enableFaceDetection";
        internal const string FUNC_RTCENGINEBASE_GETCAMERAMAXZOOMFACTOR = "RtcEngineBase_getCameraMaxZoomFactor";
        internal const string FUNC_RTCENGINEBASE_SETCAMERAFOCUSPOSITIONINPREVIEW = "RtcEngineBase_setCameraFocusPositionInPreview";
        internal const string FUNC_RTCENGINEBASE_SETCAMERATORCHON = "RtcEngineBase_setCameraTorchOn";
        internal const string FUNC_RTCENGINEBASE_SETCAMERAAUTOFOCUSFACEMODEENABLED = "RtcEngineBase_setCameraAutoFocusFaceModeEnabled";
        internal const string FUNC_RTCENGINEBASE_ISCAMERAEXPOSUREPOSITIONSUPPORTED = "RtcEngineBase_isCameraExposurePositionSupported";
        internal const string FUNC_RTCENGINEBASE_SETCAMERAEXPOSUREPOSITION = "RtcEngineBase_setCameraExposurePosition";
        internal const string FUNC_RTCENGINEBASE_ISCAMERAEXPOSURESUPPORTED = "RtcEngineBase_isCameraExposureSupported";
        internal const string FUNC_RTCENGINEBASE_SETCAMERAEXPOSUREFACTOR = "RtcEngineBase_setCameraExposureFactor";
        internal const string FUNC_RTCENGINEBASE_ISCAMERAAUTOEXPOSUREFACEMODESUPPORTED = "RtcEngineBase_isCameraAutoExposureFaceModeSupported";
        internal const string FUNC_RTCENGINEBASE_SETCAMERAAUTOEXPOSUREFACEMODEENABLED = "RtcEngineBase_setCameraAutoExposureFaceModeEnabled";
        internal const string FUNC_RTCENGINEBASE_SETDEFAULTAUDIOROUTETOSPEAKERPHONE = "RtcEngineBase_setDefaultAudioRouteToSpeakerphone";
        internal const string FUNC_RTCENGINEBASE_SETENABLESPEAKERPHONE = "RtcEngineBase_setEnableSpeakerphone";
        internal const string FUNC_RTCENGINEBASE_ISSPEAKERPHONEENABLED = "RtcEngineBase_isSpeakerphoneEnabled";
        internal const string FUNC_RTCENGINEBASE_SETROUTEINCOMMUNICATIONMODE = "RtcEngineBase_setRouteInCommunicationMode";
        internal const string FUNC_RTCENGINEBASE_GETSCREENCAPTURESOURCES = "RtcEngineBase_getScreenCaptureSources";
        internal const string FUNC_RTCENGINEBASE_SETAUDIOSESSIONOPERATIONRESTRICTION = "RtcEngineBase_setAudioSessionOperationRestriction";
        internal const string FUNC_RTCENGINEBASE_STARTSCREENCAPTUREBYDISPLAYID = "RtcEngineBase_startScreenCaptureByDisplayId";
        internal const string FUNC_RTCENGINEBASE_GETAUDIODEVICEINFO = "RtcEngineBase_getAudioDeviceInfo";
        internal const string FUNC_RTCENGINEBASE_STARTSCREENCAPTUREBYWINDOWID = "RtcEngineBase_startScreenCaptureByWindowId";
        internal const string FUNC_RTCENGINEBASE_SETSCREENCAPTURECONTENTHINT = "RtcEngineBase_setScreenCaptureContentHint";
        internal const string FUNC_RTCENGINEBASE_UPDATESCREENCAPTUREREGION = "RtcEngineBase_updateScreenCaptureRegion";
        internal const string FUNC_RTCENGINEBASE_UPDATESCREENCAPTUREPARAMETERS = "RtcEngineBase_updateScreenCaptureParameters";
        internal const string FUNC_RTCENGINEBASE_STARTSCREENCAPTURE = "RtcEngineBase_startScreenCapture";
        internal const string FUNC_RTCENGINEBASE_UPDATESCREENCAPTURE = "RtcEngineBase_updateScreenCapture";
        internal const string FUNC_RTCENGINEBASE_QUERYSCREENCAPTURECAPABILITY = "RtcEngineBase_queryScreenCaptureCapability";
        internal const string FUNC_RTCENGINEBASE_SETSCREENCAPTURESCENARIO = "RtcEngineBase_setScreenCaptureScenario";
        internal const string FUNC_RTCENGINEBASE_STOPSCREENCAPTURE = "RtcEngineBase_stopScreenCapture";
        internal const string FUNC_RTCENGINEBASE_GETCALLID = "RtcEngineBase_getCallId";
        internal const string FUNC_RTCENGINEBASE_RATE = "RtcEngineBase_rate";
        internal const string FUNC_RTCENGINEBASE_COMPLAIN = "RtcEngineBase_complain";
        internal const string FUNC_RTCENGINEBASE_STARTRTMPSTREAMWITHOUTTRANSCODING = "RtcEngineBase_startRtmpStreamWithoutTranscoding";
        internal const string FUNC_RTCENGINEBASE_STOPRTMPSTREAM = "RtcEngineBase_stopRtmpStream";
        internal const string FUNC_RTCENGINEBASE_STOPLOCALVIDEOTRANSCODER = "RtcEngineBase_stopLocalVideoTranscoder";
        internal const string FUNC_RTCENGINEBASE_STARTCAMERACAPTURE = "RtcEngineBase_startCameraCapture";
        internal const string FUNC_RTCENGINEBASE_STOPCAMERACAPTURE = "RtcEngineBase_stopCameraCapture";
        internal const string FUNC_RTCENGINEBASE_SETCAMERADEVICEORIENTATION = "RtcEngineBase_setCameraDeviceOrientation";
        internal const string FUNC_RTCENGINEBASE_SETSCREENCAPTUREORIENTATION = "RtcEngineBase_setScreenCaptureOrientation";
        internal const string FUNC_RTCENGINEBASE_STARTSCREENCAPTURE2 = "RtcEngineBase_startScreenCapture2";
        internal const string FUNC_RTCENGINEBASE_STOPSCREENCAPTURE2 = "RtcEngineBase_stopScreenCapture2";
        internal const string FUNC_RTCENGINEBASE_GETCONNECTIONSTATE = "RtcEngineBase_getConnectionState";
        internal const string FUNC_RTCENGINEBASE_REGISTERPACKETOBSERVER = "RtcEngineBase_registerPacketObserver";
        internal const string FUNC_RTCENGINEBASE_ENABLEENCRYPTION = "RtcEngineBase_enableEncryption";
        internal const string FUNC_RTCENGINEBASE_CREATEDATASTREAM = "RtcEngineBase_createDataStream";
        internal const string FUNC_RTCENGINEBASE_CREATEDATASTREAM2 = "RtcEngineBase_createDataStream2";
        internal const string FUNC_RTCENGINEBASE_SENDSTREAMMESSAGE = "RtcEngineBase_sendStreamMessage";
        internal const string FUNC_RTCENGINEBASE_ADDVIDEOWATERMARK = "RtcEngineBase_addVideoWatermark";
        internal const string FUNC_RTCENGINEBASE_CLEARVIDEOWATERMARKS = "RtcEngineBase_clearVideoWatermarks";
        internal const string FUNC_RTCENGINEBASE_SENDCUSTOMREPORTMESSAGE = "RtcEngineBase_sendCustomReportMessage";
        internal const string FUNC_RTCENGINEBASE_SETAINSMODE = "RtcEngineBase_setAINSMode";
        internal const string FUNC_RTCENGINEBASE_STOPCHANNELMEDIARELAY = "RtcEngineBase_stopChannelMediaRelay";
        internal const string FUNC_RTCENGINEBASE_PAUSEALLCHANNELMEDIARELAY = "RtcEngineBase_pauseAllChannelMediaRelay";
        internal const string FUNC_RTCENGINEBASE_RESUMEALLCHANNELMEDIARELAY = "RtcEngineBase_resumeAllChannelMediaRelay";
        internal const string FUNC_RTCENGINEBASE_SETDIRECTCDNSTREAMINGAUDIOCONFIGURATION = "RtcEngineBase_setDirectCdnStreamingAudioConfiguration";
        internal const string FUNC_RTCENGINEBASE_SETDIRECTCDNSTREAMINGVIDEOCONFIGURATION = "RtcEngineBase_setDirectCdnStreamingVideoConfiguration";
        internal const string FUNC_RTCENGINEBASE_STARTDIRECTCDNSTREAMING = "RtcEngineBase_startDirectCdnStreaming";
        internal const string FUNC_RTCENGINEBASE_STOPDIRECTCDNSTREAMING = "RtcEngineBase_stopDirectCdnStreaming";
        internal const string FUNC_RTCENGINEBASE_UPDATEDIRECTCDNSTREAMINGMEDIAOPTIONS = "RtcEngineBase_updateDirectCdnStreamingMediaOptions";
        internal const string FUNC_RTCENGINEBASE_STARTRHYTHMPLAYER = "RtcEngineBase_startRhythmPlayer";
        internal const string FUNC_RTCENGINEBASE_STOPRHYTHMPLAYER = "RtcEngineBase_stopRhythmPlayer";
        internal const string FUNC_RTCENGINEBASE_CONFIGRHYTHMPLAYER = "RtcEngineBase_configRhythmPlayer";
        internal const string FUNC_RTCENGINEBASE_ENABLECONTENTINSPECT = "RtcEngineBase_enableContentInspect";
        internal const string FUNC_RTCENGINEBASE_ADJUSTCUSTOMAUDIOPUBLISHVOLUME = "RtcEngineBase_adjustCustomAudioPublishVolume";
        internal const string FUNC_RTCENGINEBASE_ADJUSTCUSTOMAUDIOPLAYOUTVOLUME = "RtcEngineBase_adjustCustomAudioPlayoutVolume";
        internal const string FUNC_RTCENGINEBASE_SETCLOUDPROXY = "RtcEngineBase_setCloudProxy";
        internal const string FUNC_RTCENGINEBASE_SETLOCALACCESSPOINT = "RtcEngineBase_setLocalAccessPoint";
        internal const string FUNC_RTCENGINEBASE_SETADVANCEDAUDIOOPTIONS = "RtcEngineBase_setAdvancedAudioOptions";
        internal const string FUNC_RTCENGINEBASE_ENABLEVIDEOIMAGESOURCE = "RtcEngineBase_enableVideoImageSource";
        internal const string FUNC_RTCENGINEBASE_GETCURRENTMONOTONICTIMEINMS = "RtcEngineBase_getCurrentMonotonicTimeInMs";
        internal const string FUNC_RTCENGINEBASE_ENABLEWIRELESSACCELERATE = "RtcEngineBase_enableWirelessAccelerate";
        internal const string FUNC_RTCENGINEBASE_GETNETWORKTYPE = "RtcEngineBase_getNetworkType";
        internal const string FUNC_RTCENGINEBASE_SETPARAMETERS = "RtcEngineBase_setParameters";
        internal const string FUNC_RTCENGINEBASE_STARTMEDIARENDERINGTRACING = "RtcEngineBase_startMediaRenderingTracing";
        internal const string FUNC_RTCENGINEBASE_ENABLEINSTANTMEDIARENDERING = "RtcEngineBase_enableInstantMediaRendering";
        internal const string FUNC_RTCENGINEBASE_GETNTPWALLTIMEINMS = "RtcEngineBase_getNtpWallTimeInMs";
        internal const string FUNC_RTCENGINEBASE_ISFEATUREAVAILABLEONDEVICE = "RtcEngineBase_isFeatureAvailableOnDevice";
        #endregion terra IRtcEngineBase

        internal const string FUNC_RTCENGINE_SENDMETADATA = "RtcEngine_sendMetadata";
        #region terra IRtcEngine

        internal const string FUNC_RTCENGINE_INITIALIZE = "RtcEngine_initialize";
        internal const string FUNC_RTCENGINE_PRELOADCHANNEL = "RtcEngine_preloadChannel";
        internal const string FUNC_RTCENGINE_PRELOADCHANNEL2 = "RtcEngine_preloadChannel2";
        internal const string FUNC_RTCENGINE_UPDATEPRELOADCHANNELTOKEN = "RtcEngine_updatePreloadChannelToken";
        internal const string FUNC_RTCENGINE_JOINCHANNEL = "RtcEngine_joinChannel";
        internal const string FUNC_RTCENGINE_JOINCHANNEL2 = "RtcEngine_joinChannel2";
        internal const string FUNC_RTCENGINE_SETUPREMOTEVIDEO = "RtcEngine_setupRemoteVideo";
        internal const string FUNC_RTCENGINE_SETUPLOCALVIDEO = "RtcEngine_setupLocalVideo";
        internal const string FUNC_RTCENGINE_SETAUDIOPROFILE = "RtcEngine_setAudioProfile";
        internal const string FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEAUDIOSTREAMS = "RtcEngine_setDefaultMuteAllRemoteAudioStreams";
        internal const string FUNC_RTCENGINE_MUTEREMOTEAUDIOSTREAM = "RtcEngine_muteRemoteAudioStream";
        internal const string FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEVIDEOSTREAMS = "RtcEngine_setDefaultMuteAllRemoteVideoStreams";
        internal const string FUNC_RTCENGINE_MUTEREMOTEVIDEOSTREAM = "RtcEngine_muteRemoteVideoStream";
        internal const string FUNC_RTCENGINE_SETREMOTEVIDEOSTREAMTYPE = "RtcEngine_setRemoteVideoStreamType";
        internal const string FUNC_RTCENGINE_SETREMOTEVIDEOSUBSCRIPTIONOPTIONS = "RtcEngine_setRemoteVideoSubscriptionOptions";
        internal const string FUNC_RTCENGINE_SETSUBSCRIBEAUDIOBLOCKLIST = "RtcEngine_setSubscribeAudioBlocklist";
        internal const string FUNC_RTCENGINE_SETSUBSCRIBEAUDIOALLOWLIST = "RtcEngine_setSubscribeAudioAllowlist";
        internal const string FUNC_RTCENGINE_SETSUBSCRIBEVIDEOBLOCKLIST = "RtcEngine_setSubscribeVideoBlocklist";
        internal const string FUNC_RTCENGINE_SETSUBSCRIBEVIDEOALLOWLIST = "RtcEngine_setSubscribeVideoAllowlist";
        internal const string FUNC_RTCENGINE_CREATEMEDIARECORDER = "RtcEngine_createMediaRecorder";
        internal const string FUNC_RTCENGINE_DESTROYMEDIARECORDER = "RtcEngine_destroyMediaRecorder";
        internal const string FUNC_RTCENGINE_SETREMOTEVOICEPOSITION = "RtcEngine_setRemoteVoicePosition";
        internal const string FUNC_RTCENGINE_SETREMOTEUSERSPATIALAUDIOPARAMS = "RtcEngine_setRemoteUserSpatialAudioParams";
        internal const string FUNC_RTCENGINE_SETREMOTERENDERMODE = "RtcEngine_setRemoteRenderMode";
        internal const string FUNC_RTCENGINE_REGISTERAUDIOSPECTRUMOBSERVER = "RtcEngine_registerAudioSpectrumObserver";
        internal const string FUNC_RTCENGINE_UNREGISTERAUDIOSPECTRUMOBSERVER = "RtcEngine_unregisterAudioSpectrumObserver";
        internal const string FUNC_RTCENGINE_ADJUSTUSERPLAYBACKSIGNALVOLUME = "RtcEngine_adjustUserPlaybackSignalVolume";
        internal const string FUNC_RTCENGINE_SETHIGHPRIORITYUSERLIST = "RtcEngine_setHighPriorityUserList";
        internal const string FUNC_RTCENGINE_ENABLEEXTENSION = "RtcEngine_enableExtension";
        internal const string FUNC_RTCENGINE_SETEXTENSIONPROPERTY = "RtcEngine_setExtensionProperty";
        internal const string FUNC_RTCENGINE_GETEXTENSIONPROPERTY = "RtcEngine_getExtensionProperty";
        internal const string FUNC_RTCENGINE_STARTRTMPSTREAMWITHTRANSCODING = "RtcEngine_startRtmpStreamWithTranscoding";
        internal const string FUNC_RTCENGINE_UPDATERTMPTRANSCODING = "RtcEngine_updateRtmpTranscoding";
        internal const string FUNC_RTCENGINE_STARTLOCALVIDEOTRANSCODER = "RtcEngine_startLocalVideoTranscoder";
        internal const string FUNC_RTCENGINE_UPDATELOCALTRANSCODERCONFIGURATION = "RtcEngine_updateLocalTranscoderConfiguration";
        internal const string FUNC_RTCENGINE_REGISTEREVENTHANDLER = "RtcEngine_registerEventHandler";
        internal const string FUNC_RTCENGINE_UNREGISTEREVENTHANDLER = "RtcEngine_unregisterEventHandler";
        internal const string FUNC_RTCENGINE_SETREMOTEUSERPRIORITY = "RtcEngine_setRemoteUserPriority";
        internal const string FUNC_RTCENGINE_SETENCRYPTIONMODE = "RtcEngine_setEncryptionMode";
        internal const string FUNC_RTCENGINE_SETENCRYPTIONSECRET = "RtcEngine_setEncryptionSecret";
        internal const string FUNC_RTCENGINE_ADDVIDEOWATERMARK = "RtcEngine_addVideoWatermark";
        internal const string FUNC_RTCENGINE_PAUSEAUDIO = "RtcEngine_pauseAudio";
        internal const string FUNC_RTCENGINE_RESUMEAUDIO = "RtcEngine_resumeAudio";
        internal const string FUNC_RTCENGINE_ENABLEWEBSDKINTEROPERABILITY = "RtcEngine_enableWebSdkInteroperability";
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
        internal const string FUNC_RTCENGINE_STARTORUPDATECHANNELMEDIARELAY = "RtcEngine_startOrUpdateChannelMediaRelay";
        internal const string FUNC_RTCENGINE_STARTCHANNELMEDIARELAY = "RtcEngine_startChannelMediaRelay";
        internal const string FUNC_RTCENGINE_UPDATECHANNELMEDIARELAY = "RtcEngine_updateChannelMediaRelay";
        internal const string FUNC_RTCENGINE_TAKESNAPSHOT = "RtcEngine_takeSnapshot";
        internal const string FUNC_RTCENGINE_SETAVSYNCSOURCE = "RtcEngine_setAVSyncSource";
        internal const string FUNC_RTCENGINE_STARTSCREENCAPTUREBYSCREENRECT = "RtcEngine_startScreenCaptureByScreenRect";
        #endregion terra IRtcEngine

        #region terra IRtcEngineEx

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
        internal const string FUNC_RTCENGINEEX_ADJUSTRECORDINGSIGNALVOLUMEEX = "RtcEngineEx_adjustRecordingSignalVolumeEx";
        internal const string FUNC_RTCENGINEEX_MUTERECORDINGSIGNALEX = "RtcEngineEx_muteRecordingSignalEx";
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
        internal const string FUNC_RTCENGINEEX_STARTORUPDATECHANNELMEDIARELAYEX = "RtcEngineEx_startOrUpdateChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_STARTCHANNELMEDIARELAYEX = "RtcEngineEx_startChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_UPDATECHANNELMEDIARELAYEX = "RtcEngineEx_updateChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_STOPCHANNELMEDIARELAYEX = "RtcEngineEx_stopChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_PAUSEALLCHANNELMEDIARELAYEX = "RtcEngineEx_pauseAllChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_RESUMEALLCHANNELMEDIARELAYEX = "RtcEngineEx_resumeAllChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEX_GETUSERINFOBYUSERACCOUNTEX = "RtcEngineEx_getUserInfoByUserAccountEx";
        internal const string FUNC_RTCENGINEEX_GETUSERINFOBYUIDEX = "RtcEngineEx_getUserInfoByUidEx";
        internal const string FUNC_RTCENGINEEX_ENABLEDUALSTREAMMODEEX = "RtcEngineEx_enableDualStreamModeEx";
        internal const string FUNC_RTCENGINEEX_SETDUALSTREAMMODEEX = "RtcEngineEx_setDualStreamModeEx";
        internal const string FUNC_RTCENGINEEX_SETHIGHPRIORITYUSERLISTEX = "RtcEngineEx_setHighPriorityUserListEx";
        internal const string FUNC_RTCENGINEEX_TAKESNAPSHOTEX = "RtcEngineEx_takeSnapshotEx";
        internal const string FUNC_RTCENGINEEX_ENABLECONTENTINSPECTEX = "RtcEngineEx_enableContentInspectEx";
        internal const string FUNC_RTCENGINEEX_STARTMEDIARENDERINGTRACINGEX = "RtcEngineEx_startMediaRenderingTracingEx";
        internal const string FUNC_RTCENGINEEX_SETPARAMETERSEX = "RtcEngineEx_setParametersEx";
        #endregion terra IRtcEngineEx

        internal const string FUNC_RTCENGINES_SENDMETADATA = "RtcEngineS_sendMetadata";
        #region terra IRtcEngineS

        internal const string FUNC_RTCENGINES_PREPAREUSERACCOUNT = "RtcEngineS_prepareUserAccount";
        internal const string FUNC_RTCENGINES_INITIALIZE = "RtcEngineS_initialize";
        internal const string FUNC_RTCENGINES_JOINCHANNEL = "RtcEngineS_joinChannel";
        internal const string FUNC_RTCENGINES_JOINCHANNEL2 = "RtcEngineS_joinChannel2";
        internal const string FUNC_RTCENGINES_SETUPREMOTEVIDEO = "RtcEngineS_setupRemoteVideo";
        internal const string FUNC_RTCENGINES_SETUPLOCALVIDEO = "RtcEngineS_setupLocalVideo";
        internal const string FUNC_RTCENGINES_MUTEREMOTEAUDIOSTREAM = "RtcEngineS_muteRemoteAudioStream";
        internal const string FUNC_RTCENGINES_MUTEREMOTEVIDEOSTREAM = "RtcEngineS_muteRemoteVideoStream";
        internal const string FUNC_RTCENGINES_SETREMOTEVIDEOSTREAMTYPE = "RtcEngineS_setRemoteVideoStreamType";
        internal const string FUNC_RTCENGINES_SETREMOTEVIDEOSUBSCRIPTIONOPTIONS = "RtcEngineS_setRemoteVideoSubscriptionOptions";
        internal const string FUNC_RTCENGINES_SETSUBSCRIBEAUDIOBLOCKLIST = "RtcEngineS_setSubscribeAudioBlocklist";
        internal const string FUNC_RTCENGINES_SETSUBSCRIBEAUDIOALLOWLIST = "RtcEngineS_setSubscribeAudioAllowlist";
        internal const string FUNC_RTCENGINES_SETSUBSCRIBEVIDEOBLOCKLIST = "RtcEngineS_setSubscribeVideoBlocklist";
        internal const string FUNC_RTCENGINES_SETSUBSCRIBEVIDEOALLOWLIST = "RtcEngineS_setSubscribeVideoAllowlist";
        internal const string FUNC_RTCENGINES_CREATEMEDIARECORDER = "RtcEngineS_createMediaRecorder";
        internal const string FUNC_RTCENGINES_DESTROYMEDIARECORDER = "RtcEngineS_destroyMediaRecorder";
        internal const string FUNC_RTCENGINES_SETREMOTEVOICEPOSITION = "RtcEngineS_setRemoteVoicePosition";
        internal const string FUNC_RTCENGINES_SETREMOTEUSERSPATIALAUDIOPARAMS = "RtcEngineS_setRemoteUserSpatialAudioParams";
        internal const string FUNC_RTCENGINES_SETREMOTERENDERMODE = "RtcEngineS_setRemoteRenderMode";
        internal const string FUNC_RTCENGINES_REGISTERAUDIOSPECTRUMOBSERVER = "RtcEngineS_registerAudioSpectrumObserver";
        internal const string FUNC_RTCENGINES_UNREGISTERAUDIOSPECTRUMOBSERVER = "RtcEngineS_unregisterAudioSpectrumObserver";
        internal const string FUNC_RTCENGINES_ADJUSTUSERPLAYBACKSIGNALVOLUME = "RtcEngineS_adjustUserPlaybackSignalVolume";
        internal const string FUNC_RTCENGINES_SETHIGHPRIORITYUSERLIST = "RtcEngineS_setHighPriorityUserList";
        internal const string FUNC_RTCENGINES_ENABLEEXTENSION = "RtcEngineS_enableExtension";
        internal const string FUNC_RTCENGINES_SETEXTENSIONPROPERTY = "RtcEngineS_setExtensionProperty";
        internal const string FUNC_RTCENGINES_GETEXTENSIONPROPERTY = "RtcEngineS_getExtensionProperty";
        internal const string FUNC_RTCENGINES_STARTRTMPSTREAMWITHTRANSCODING = "RtcEngineS_startRtmpStreamWithTranscoding";
        internal const string FUNC_RTCENGINES_UPDATERTMPTRANSCODING = "RtcEngineS_updateRtmpTranscoding";
        internal const string FUNC_RTCENGINES_STARTLOCALVIDEOTRANSCODER = "RtcEngineS_startLocalVideoTranscoder";
        internal const string FUNC_RTCENGINES_UPDATELOCALTRANSCODERCONFIGURATION = "RtcEngineS_updateLocalTranscoderConfiguration";
        internal const string FUNC_RTCENGINES_REGISTEREVENTHANDLER = "RtcEngineS_registerEventHandler";
        internal const string FUNC_RTCENGINES_UNREGISTEREVENTHANDLER = "RtcEngineS_unregisterEventHandler";
        internal const string FUNC_RTCENGINES_SETREMOTEUSERPRIORITY = "RtcEngineS_setRemoteUserPriority";
        internal const string FUNC_RTCENGINES_REGISTERMEDIAMETADATAOBSERVER = "RtcEngineS_registerMediaMetadataObserver";
        internal const string FUNC_RTCENGINES_UNREGISTERMEDIAMETADATAOBSERVER = "RtcEngineS_unregisterMediaMetadataObserver";
        internal const string FUNC_RTCENGINES_STARTAUDIOFRAMEDUMP = "RtcEngineS_startAudioFrameDump";
        internal const string FUNC_RTCENGINES_STOPAUDIOFRAMEDUMP = "RtcEngineS_stopAudioFrameDump";
        internal const string FUNC_RTCENGINES_STARTORUPDATECHANNELMEDIARELAY = "RtcEngineS_startOrUpdateChannelMediaRelay";
        internal const string FUNC_RTCENGINES_TAKESNAPSHOT = "RtcEngineS_takeSnapshot";
        internal const string FUNC_RTCENGINES_SETAVSYNCSOURCE = "RtcEngineS_setAVSyncSource";
        #endregion terra IRtcEngineS

        #region terra IRtcEngineExS

        internal const string FUNC_RTCENGINEEXS_JOINCHANNELEX = "RtcEngineExS_joinChannelEx";
        internal const string FUNC_RTCENGINEEXS_LEAVECHANNELEX = "RtcEngineExS_leaveChannelEx";
        internal const string FUNC_RTCENGINEEXS_LEAVECHANNELEX2 = "RtcEngineExS_leaveChannelEx2";
        internal const string FUNC_RTCENGINEEXS_UPDATECHANNELMEDIAOPTIONSEX = "RtcEngineExS_updateChannelMediaOptionsEx";
        internal const string FUNC_RTCENGINEEXS_SETVIDEOENCODERCONFIGURATIONEX = "RtcEngineExS_setVideoEncoderConfigurationEx";
        internal const string FUNC_RTCENGINEEXS_SETUPREMOTEVIDEOEX = "RtcEngineExS_setupRemoteVideoEx";
        internal const string FUNC_RTCENGINEEXS_MUTEREMOTEAUDIOSTREAMEX = "RtcEngineExS_muteRemoteAudioStreamEx";
        internal const string FUNC_RTCENGINEEXS_MUTEREMOTEVIDEOSTREAMEX = "RtcEngineExS_muteRemoteVideoStreamEx";
        internal const string FUNC_RTCENGINEEXS_SETREMOTEVIDEOSTREAMTYPEEX = "RtcEngineExS_setRemoteVideoStreamTypeEx";
        internal const string FUNC_RTCENGINEEXS_MUTELOCALAUDIOSTREAMEX = "RtcEngineExS_muteLocalAudioStreamEx";
        internal const string FUNC_RTCENGINEEXS_MUTELOCALVIDEOSTREAMEX = "RtcEngineExS_muteLocalVideoStreamEx";
        internal const string FUNC_RTCENGINEEXS_MUTEALLREMOTEAUDIOSTREAMSEX = "RtcEngineExS_muteAllRemoteAudioStreamsEx";
        internal const string FUNC_RTCENGINEEXS_MUTEALLREMOTEVIDEOSTREAMSEX = "RtcEngineExS_muteAllRemoteVideoStreamsEx";
        internal const string FUNC_RTCENGINEEXS_SETSUBSCRIBEAUDIOBLOCKLISTEX = "RtcEngineExS_setSubscribeAudioBlocklistEx";
        internal const string FUNC_RTCENGINEEXS_SETSUBSCRIBEAUDIOALLOWLISTEX = "RtcEngineExS_setSubscribeAudioAllowlistEx";
        internal const string FUNC_RTCENGINEEXS_SETSUBSCRIBEVIDEOBLOCKLISTEX = "RtcEngineExS_setSubscribeVideoBlocklistEx";
        internal const string FUNC_RTCENGINEEXS_SETSUBSCRIBEVIDEOALLOWLISTEX = "RtcEngineExS_setSubscribeVideoAllowlistEx";
        internal const string FUNC_RTCENGINEEXS_SETREMOTEVIDEOSUBSCRIPTIONOPTIONSEX = "RtcEngineExS_setRemoteVideoSubscriptionOptionsEx";
        internal const string FUNC_RTCENGINEEXS_SETREMOTEVOICEPOSITIONEX = "RtcEngineExS_setRemoteVoicePositionEx";
        internal const string FUNC_RTCENGINEEXS_SETREMOTEUSERSPATIALAUDIOPARAMSEX = "RtcEngineExS_setRemoteUserSpatialAudioParamsEx";
        internal const string FUNC_RTCENGINEEXS_SETREMOTERENDERMODEEX = "RtcEngineExS_setRemoteRenderModeEx";
        internal const string FUNC_RTCENGINEEXS_ENABLELOOPBACKRECORDINGEX = "RtcEngineExS_enableLoopbackRecordingEx";
        internal const string FUNC_RTCENGINEEXS_ADJUSTRECORDINGSIGNALVOLUMEEX = "RtcEngineExS_adjustRecordingSignalVolumeEx";
        internal const string FUNC_RTCENGINEEXS_MUTERECORDINGSIGNALEX = "RtcEngineExS_muteRecordingSignalEx";
        internal const string FUNC_RTCENGINEEXS_ADJUSTUSERPLAYBACKSIGNALVOLUMEEX = "RtcEngineExS_adjustUserPlaybackSignalVolumeEx";
        internal const string FUNC_RTCENGINEEXS_GETCONNECTIONSTATEEX = "RtcEngineExS_getConnectionStateEx";
        internal const string FUNC_RTCENGINEEXS_ENABLEENCRYPTIONEX = "RtcEngineExS_enableEncryptionEx";
        internal const string FUNC_RTCENGINEEXS_CREATEDATASTREAMEX = "RtcEngineExS_createDataStreamEx";
        internal const string FUNC_RTCENGINEEXS_CREATEDATASTREAMEX2 = "RtcEngineExS_createDataStreamEx2";
        internal const string FUNC_RTCENGINEEXS_SENDSTREAMMESSAGEEX = "RtcEngineExS_sendStreamMessageEx";
        internal const string FUNC_RTCENGINEEXS_ADDVIDEOWATERMARKEX = "RtcEngineExS_addVideoWatermarkEx";
        internal const string FUNC_RTCENGINEEXS_CLEARVIDEOWATERMARKEX = "RtcEngineExS_clearVideoWatermarkEx";
        internal const string FUNC_RTCENGINEEXS_SENDCUSTOMREPORTMESSAGEEX = "RtcEngineExS_sendCustomReportMessageEx";
        internal const string FUNC_RTCENGINEEXS_ENABLEAUDIOVOLUMEINDICATIONEX = "RtcEngineExS_enableAudioVolumeIndicationEx";
        internal const string FUNC_RTCENGINEEXS_STARTRTMPSTREAMWITHOUTTRANSCODINGEX = "RtcEngineExS_startRtmpStreamWithoutTranscodingEx";
        internal const string FUNC_RTCENGINEEXS_STARTRTMPSTREAMWITHTRANSCODINGEX = "RtcEngineExS_startRtmpStreamWithTranscodingEx";
        internal const string FUNC_RTCENGINEEXS_UPDATERTMPTRANSCODINGEX = "RtcEngineExS_updateRtmpTranscodingEx";
        internal const string FUNC_RTCENGINEEXS_STOPRTMPSTREAMEX = "RtcEngineExS_stopRtmpStreamEx";
        internal const string FUNC_RTCENGINEEXS_STARTORUPDATECHANNELMEDIARELAYEX = "RtcEngineExS_startOrUpdateChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEXS_STOPCHANNELMEDIARELAYEX = "RtcEngineExS_stopChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEXS_PAUSEALLCHANNELMEDIARELAYEX = "RtcEngineExS_pauseAllChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEXS_RESUMEALLCHANNELMEDIARELAYEX = "RtcEngineExS_resumeAllChannelMediaRelayEx";
        internal const string FUNC_RTCENGINEEXS_ENABLEDUALSTREAMMODEEX = "RtcEngineExS_enableDualStreamModeEx";
        internal const string FUNC_RTCENGINEEXS_SETDUALSTREAMMODEEX = "RtcEngineExS_setDualStreamModeEx";
        internal const string FUNC_RTCENGINEEXS_SETHIGHPRIORITYUSERLISTEX = "RtcEngineExS_setHighPriorityUserListEx";
        internal const string FUNC_RTCENGINEEXS_TAKESNAPSHOTEX = "RtcEngineExS_takeSnapshotEx";
        internal const string FUNC_RTCENGINEEXS_STARTMEDIARENDERINGTRACINGEX = "RtcEngineExS_startMediaRenderingTracingEx";
        internal const string FUNC_RTCENGINEEXS_SETPARAMETERSEX = "RtcEngineExS_setParametersEx";
        #endregion terra IRtcEngineExS

        internal const string FUNC_MEDIAPLAYER_UNOPENWITHCUSTOMSOURCE = "MediaPlayer_unOpenWithCustomSource";
        internal const string FUNC_MEDIAPLAYER_UNOPENWITHMEDIASOURCE = "MediaPlayer_unOpenWithMediaSource";
        #region terra IMediaPlayer

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
        internal const string FUNC_MEDIAPLAYER_SELECTMULTIAUDIOTRACK = "MediaPlayer_selectMultiAudioTrack";
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
        #endregion terra IMediaPlayer

        internal const string FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEFAULTDEVICE = "AudioDeviceManager_getPlaybackDefaultDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEAFULTDEVICE = "AudioDeviceManager_getRecordingDefaultDevice";
        #region terra IAudioDeviceManager

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
        #endregion terra IAudioDeviceManager

        #region terra IVideoDeviceManager

        internal const string FUNC_VIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES = "VideoDeviceManager_enumerateVideoDevices";
        internal const string FUNC_VIDEODEVICEMANAGER_SETDEVICE = "VideoDeviceManager_setDevice";
        internal const string FUNC_VIDEODEVICEMANAGER_GETDEVICE = "VideoDeviceManager_getDevice";
        internal const string FUNC_VIDEODEVICEMANAGER_NUMBEROFCAPABILITIES = "VideoDeviceManager_numberOfCapabilities";
        internal const string FUNC_VIDEODEVICEMANAGER_GETCAPABILITY = "VideoDeviceManager_getCapability";
        internal const string FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST = "VideoDeviceManager_startDeviceTest";
        internal const string FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST = "VideoDeviceManager_stopDeviceTest";
        internal const string FUNC_VIDEODEVICEMANAGER_RELEASE = "VideoDeviceManager_release";
        #endregion terra IVideoDeviceManager

        #region terra ISpatialAudioEngineBase

        internal const string FUNC_SPATIALAUDIOENGINEBASE_RELEASE = "SpatialAudioEngineBase_release";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_SETMAXAUDIORECVCOUNT = "SpatialAudioEngineBase_setMaxAudioRecvCount";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_SETAUDIORECVRANGE = "SpatialAudioEngineBase_setAudioRecvRange";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_SETDISTANCEUNIT = "SpatialAudioEngineBase_setDistanceUnit";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_UPDATESELFPOSITION = "SpatialAudioEngineBase_updateSelfPosition";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_UPDATEPLAYERPOSITIONINFO = "SpatialAudioEngineBase_updatePlayerPositionInfo";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_SETPARAMETERS = "SpatialAudioEngineBase_setParameters";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_MUTELOCALAUDIOSTREAM = "SpatialAudioEngineBase_muteLocalAudioStream";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_MUTEALLREMOTEAUDIOSTREAMS = "SpatialAudioEngineBase_muteAllRemoteAudioStreams";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_SETZONES = "SpatialAudioEngineBase_setZones";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_SETPLAYERATTENUATION = "SpatialAudioEngineBase_setPlayerAttenuation";
        internal const string FUNC_SPATIALAUDIOENGINEBASE_CLEARREMOTEPOSITIONS = "SpatialAudioEngineBase_clearRemotePositions";
        #endregion terra ISpatialAudioEngineBase

        #region terra ILocalSpatialAudioEngine

        internal const string FUNC_LOCALSPATIALAUDIOENGINE_INITIALIZE = "LocalSpatialAudioEngine_initialize";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITION = "LocalSpatialAudioEngine_updateRemotePosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITIONEX = "LocalSpatialAudioEngine_updateRemotePositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITION = "LocalSpatialAudioEngine_removeRemotePosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITIONEX = "LocalSpatialAudioEngine_removeRemotePositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONSEX = "LocalSpatialAudioEngine_clearRemotePositionsEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITIONEX = "LocalSpatialAudioEngine_updateSelfPositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_MUTEREMOTEAUDIOSTREAM = "LocalSpatialAudioEngine_muteRemoteAudioStream";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETREMOTEAUDIOATTENUATION = "LocalSpatialAudioEngine_setRemoteAudioAttenuation";
        #endregion terra ILocalSpatialAudioEngine

        #region terra ILocalSpatialAudioEngineS

        internal const string FUNC_LOCALSPATIALAUDIOENGINES_INITIALIZE = "LocalSpatialAudioEngineS_initialize";
        internal const string FUNC_LOCALSPATIALAUDIOENGINES_UPDATEREMOTEPOSITION = "LocalSpatialAudioEngineS_updateRemotePosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINES_UPDATEREMOTEPOSITIONEX = "LocalSpatialAudioEngineS_updateRemotePositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINES_REMOVEREMOTEPOSITION = "LocalSpatialAudioEngineS_removeRemotePosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINES_REMOVEREMOTEPOSITIONEX = "LocalSpatialAudioEngineS_removeRemotePositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINES_CLEARREMOTEPOSITIONSEX = "LocalSpatialAudioEngineS_clearRemotePositionsEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINES_UPDATESELFPOSITIONEX = "LocalSpatialAudioEngineS_updateSelfPositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINES_MUTEREMOTEAUDIOSTREAM = "LocalSpatialAudioEngineS_muteRemoteAudioStream";
        internal const string FUNC_LOCALSPATIALAUDIOENGINES_SETREMOTEAUDIOATTENUATION = "LocalSpatialAudioEngineS_setRemoteAudioAttenuation";
        #endregion terra ILocalSpatialAudioEngineS

        #region terra IMediaEngineBase

        internal const string FUNC_MEDIAENGINEBASE_PUSHAUDIOFRAME = "MediaEngineBase_pushAudioFrame";
        internal const string FUNC_MEDIAENGINEBASE_PULLAUDIOFRAME = "MediaEngineBase_pullAudioFrame";
        internal const string FUNC_MEDIAENGINEBASE_SETEXTERNALVIDEOSOURCE = "MediaEngineBase_setExternalVideoSource";
        internal const string FUNC_MEDIAENGINEBASE_SETEXTERNALAUDIOSOURCE = "MediaEngineBase_setExternalAudioSource";
        internal const string FUNC_MEDIAENGINEBASE_CREATECUSTOMAUDIOTRACK = "MediaEngineBase_createCustomAudioTrack";
        internal const string FUNC_MEDIAENGINEBASE_DESTROYCUSTOMAUDIOTRACK = "MediaEngineBase_destroyCustomAudioTrack";
        internal const string FUNC_MEDIAENGINEBASE_SETEXTERNALAUDIOSINK = "MediaEngineBase_setExternalAudioSink";
        internal const string FUNC_MEDIAENGINEBASE_ENABLECUSTOMAUDIOLOCALPLAYBACK = "MediaEngineBase_enableCustomAudioLocalPlayback";
        internal const string FUNC_MEDIAENGINEBASE_PUSHVIDEOFRAME = "MediaEngineBase_pushVideoFrame";
        internal const string FUNC_MEDIAENGINEBASE_RELEASE = "MediaEngineBase_release";
        #endregion terra IMediaEngineBase

        internal const string FUNC_MEDIAENGINE_UNREGISTERAUDIOFRAMEOBSERVER = "MediaEngine_unregisterAudioFrameObserver";
        internal const string FUNC_MEDIAENGINE_UNREGISTERVIDEOFRAMEOBSERVER = "MediaEngine_unregisterVideoFrameObserver";
        internal const string FUNC_MEDIAENGINE_UNREGISTERVIDEOENCODEDFRAMEOBSERVER = "MediaEngine_unregisterVideoEncodedFrameObserver";
        #region terra IMediaEngine

        internal const string FUNC_MEDIAENGINE_REGISTERVIDEOFRAMEOBSERVER = "MediaEngine_registerVideoFrameObserver";
        internal const string FUNC_MEDIAENGINE_REGISTERAUDIOFRAMEOBSERVER = "MediaEngine_registerAudioFrameObserver";
        internal const string FUNC_MEDIAENGINE_REGISTERVIDEOENCODEDFRAMEOBSERVER = "MediaEngine_registerVideoEncodedFrameObserver";
        internal const string FUNC_MEDIAENGINE_PUSHENCODEDVIDEOIMAGE = "MediaEngine_pushEncodedVideoImage";

        #endregion terra IMediaEngine

        internal const string FUNC_MEDIAENGINES_UNREGISTERAUDIOFRAMEOBSERVER = "MediaEngineS_unregisterAudioFrameObserver";
        internal const string FUNC_MEDIAENGINES_UNREGISTERVIDEOFRAMEOBSERVER = "MediaEngineS_unregisterVideoFrameObserver";
        internal const string FUNC_MEDIAENGINES_UNREGISTERVIDEOENCODEDFRAMEOBSERVER = "MediaEngineS_unregisterVideoEncodedFrameObserver";
        #region terra IMediaEngineS

        internal const string FUNC_MEDIAENGINES_REGISTERVIDEOFRAMEOBSERVER = "MediaEngineS_registerVideoFrameObserver";
        internal const string FUNC_MEDIAENGINES_REGISTERAUDIOFRAMEOBSERVER = "MediaEngineS_registerAudioFrameObserver";
        internal const string FUNC_MEDIAENGINES_REGISTERVIDEOENCODEDFRAMEOBSERVER = "MediaEngineS_registerVideoEncodedFrameObserver";
        internal const string FUNC_MEDIAENGINES_PUSHENCODEDVIDEOIMAGE = "MediaEngineS_pushEncodedVideoImage";

        #endregion terra IMediaEngineS

        #region terra IMediaPlayerCacheManager

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
        #endregion terra IMediaPlayerCacheManager

        #region terra IMediaRecorderBase

        internal const string FUNC_MEDIARECORDERBASE_STARTRECORDING = "MediaRecorderBase_startRecording";
        internal const string FUNC_MEDIARECORDERBASE_STOPRECORDING = "MediaRecorderBase_stopRecording";
        #endregion terra IMediaRecorderBase

        internal const string FUNC_MEDIARECORDER_UNSETMEDIARECORDEROBSERVER = "MediaRecorder_unsetMediaRecorderObserver";
        #region terra IMediaRecorder
        internal const string FUNC_MEDIARECORDER_SETMEDIARECORDEROBSERVER = "MediaRecorder_setMediaRecorderObserver";
        #endregion terra IMediaRecorder

        internal const string FUNC_MEDIARECORDERS_UNSETMEDIARECORDEROBSERVER = "MediaRecorderS_unsetMediaRecorderObserver";
        #region terra IMediaRecorderS
        internal const string FUNC_MEDIARECORDERS_SETMEDIARECORDEROBSERVER = "MediaRecorderS_setMediaRecorderObserver";
        #endregion terra IMediaRecorderS

        internal const string FUNC_MUSICCONTENTCENTER_DESTROYMUSICPLAYER = "MusicContentCenter_destroyMusicPlayer";
        #region terra IMusicContentCenter

        internal const string FUNC_MUSICCONTENTCENTER_INITIALIZE = "MusicContentCenter_initialize";
        internal const string FUNC_MUSICCONTENTCENTER_RENEWTOKEN = "MusicContentCenter_renewToken";
        internal const string FUNC_MUSICCONTENTCENTER_RELEASE = "MusicContentCenter_release";
        internal const string FUNC_MUSICCONTENTCENTER_REGISTEREVENTHANDLER = "MusicContentCenter_registerEventHandler";
        internal const string FUNC_MUSICCONTENTCENTER_UNREGISTEREVENTHANDLER = "MusicContentCenter_unregisterEventHandler";
        internal const string FUNC_MUSICCONTENTCENTER_CREATEMUSICPLAYER = "MusicContentCenter_createMusicPlayer";
        internal const string FUNC_MUSICCONTENTCENTER_GETMUSICCHARTS = "MusicContentCenter_getMusicCharts";
        internal const string FUNC_MUSICCONTENTCENTER_GETMUSICCOLLECTIONBYMUSICCHARTID = "MusicContentCenter_getMusicCollectionByMusicChartId";
        internal const string FUNC_MUSICCONTENTCENTER_SEARCHMUSIC = "MusicContentCenter_searchMusic";
        internal const string FUNC_MUSICCONTENTCENTER_PRELOAD = "MusicContentCenter_preload";
        internal const string FUNC_MUSICCONTENTCENTER_PRELOAD2 = "MusicContentCenter_preload2";
        internal const string FUNC_MUSICCONTENTCENTER_REMOVECACHE = "MusicContentCenter_removeCache";
        internal const string FUNC_MUSICCONTENTCENTER_GETCACHES = "MusicContentCenter_getCaches";
        internal const string FUNC_MUSICCONTENTCENTER_ISPRELOADED = "MusicContentCenter_isPreloaded";
        internal const string FUNC_MUSICCONTENTCENTER_GETLYRIC = "MusicContentCenter_getLyric";
        internal const string FUNC_MUSICCONTENTCENTER_GETSONGSIMPLEINFO = "MusicContentCenter_getSongSimpleInfo";
        internal const string FUNC_MUSICCONTENTCENTER_GETINTERNALSONGCODE = "MusicContentCenter_getInternalSongCode";
        #endregion terra IMusicContentCenter

        #region terra IMusicPlayer
        internal const string FUNC_MUSICPLAYER_OPEN = "MusicPlayer_open";
        #endregion terra IMusicPlayer

        #region terra IH265TranscoderBase

        internal const string FUNC_H265TRANSCODERBASE_REGISTERTRANSCODEROBSERVER = "H265TranscoderBase_registerTranscoderObserver";
        internal const string FUNC_H265TRANSCODERBASE_UNREGISTERTRANSCODEROBSERVER = "H265TranscoderBase_unregisterTranscoderObserver";
        #endregion terra IH265TranscoderBase

        #region terra IH265Transcoder

        internal const string FUNC_H265TRANSCODER_ENABLETRANSCODE = "H265Transcoder_enableTranscode";
        internal const string FUNC_H265TRANSCODER_QUERYCHANNEL = "H265Transcoder_queryChannel";
        internal const string FUNC_H265TRANSCODER_TRIGGERTRANSCODE = "H265Transcoder_triggerTranscode";
        #endregion terra IH265Transcoder

        #region terra IH265TranscoderS

        internal const string FUNC_H265TRANSCODERS_ENABLETRANSCODE = "H265TranscoderS_enableTranscode";
        internal const string FUNC_H265TRANSCODERS_QUERYCHANNEL = "H265TranscoderS_queryChannel";
        internal const string FUNC_H265TRANSCODERS_TRIGGERTRANSCODE = "H265TranscoderS_triggerTranscode";
        #endregion terra IH265TranscoderS
    }
}