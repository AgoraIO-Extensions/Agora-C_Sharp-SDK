//  AgoraApiBase.cs
//
//  Created by YuGuo Chen on September 27, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
    internal static class AgoraApiType
    {
        // class IVideoDeviceManager start
        internal const string FUNC_VIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES = "VideoDeviceManager_enumerateVideoDevices";
        internal const string FUNC_VIDEODEVICEMANAGER_SETDEVICE = "VideoDeviceManager_setDevice";
        internal const string FUNC_VIDEODEVICEMANAGER_GETDEVICE = "VideoDeviceManager_getDevice";
        internal const string FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST = "VideoDeviceManager_startDeviceTest";
        internal const string FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST = "VideoDeviceManager_stopDeviceTest";
        internal const string FUNC_VIDEODEVICEMANAGER_RELEASE = "VideoDeviceManager_release";
        // class IVideoDeviceManager end

        // class IMediaPlayer start
        // class IMediaPlayer end

        // class IRtcEngine start
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
        internal const string FUNC_RTCENGINE_STOPECHOTEST = "RtcEngine_stopEchoTest";
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
        internal const string FUNC_RTCENGINE_ENABLEVIRTUALBACKGROUND = "RtcEngine_enableVirtualBackground";
        internal const string FUNC_RTCENGINE_ENABLEREMOTESUPERRESOLUTION = "RtcEngine_enableRemoteSuperResolution";
        internal const string FUNC_RTCENGINE_SETUPREMOTEVIDEO = "RtcEngine_setupRemoteVideo";
        internal const string FUNC_RTCENGINE_SETUPLOCALVIDEO = "RtcEngine_setupLocalVideo";
        internal const string FUNC_RTCENGINE_ENABLEAUDIO = "RtcEngine_enableAudio";
        internal const string FUNC_RTCENGINE_DISABLEAUDIO = "RtcEngine_disableAudio";
        internal const string FUNC_RTCENGINE_SETAUDIOPROFILE = "RtcEngine_setAudioProfile";
        internal const string FUNC_RTCENGINE_SETAUDIOPROFILE2 = "RtcEngine_setAudioProfile2";
        internal const string FUNC_RTCENGINE_ENABLELOCALAUDIO = "RtcEngine_enableLocalAudio";
        internal const string FUNC_RTCENGINE_MUTELOCALAUDIOSTREAM = "RtcEngine_muteLocalAudioStream";
        internal const string FUNC_RTCENGINE_MUTEALLREMOTEAUDIOSTREAMS= "RtcEngine_muteAllRemoteAudioStreams";
        internal const string FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEAUDIOSTREAMS = "RtcEngine_setDefaultMuteAllRemoteAudioStreams";
        internal const string FUNC_RTCENGINE_MUTEREMOTEAUDIOSTREAM = "RtcEngine_muteRemoteAudioStream";
        internal const string FUNC_RTCENGINE_MUTELOCALVIDEOSTREAM = "RtcEngine_muteLocalVideoStream";
        internal const string FUNC_RTCENGINE_ENABLELOCALVIDEO = "RtcEngine_enableLocalVideo";
        internal const string FUNC_RTCENGINE_MUTEALLREMOTEVIDEOSTREAMS= "RtcEngine_muteAllRemoteVideoStreams";
        internal const string FUNC_RTCENGINE_SETDEFAULTMUTEALLREMOTEVIDEOSTREAMS = "RtcEngine_setDefaultMuteAllRemoteVideoStreams";
        internal const string FUNC_RTCENGINE_MUTEREMOTEVIDEOSTREAM = "RtcEngine_muteRemoteVideoStream";
        internal const string FUNC_RTCENGINE_SETREMOTEVIDEOSTREAMTYPE = "RtcEngine_setRemoteVideoStreamType";
        internal const string FUNC_RTCENGINE_SETREMOTEDEFAULTVIDEOSTREAMTYPE = "RtcEngine_setRemoteDefaultVideoStreamType";
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
        internal const string FUNC_RTCENGINE_ADJUSTAUDIOMIXINGVOLUME = "RtcEngine_adjustAudioMixingVolume";
        internal const string FUNC_RTCENGINE_ADJUSTAUDIOMIXINGPUBLISHVOLUME = "RtcEngine_adjustAudioMixingPublishVolume";
        internal const string FUNC_RTCENGINE_GETAUDIOMIXINGPUBLISHVOLUME = "RtcEngine_getAudioMixingPublishVolume";
        internal const string FUNC_RTCENGINE_ADJUSTAUDIOMIXINGPLAYOUTVOLUME = "RtcEngine_adjustAudioMixingPlayoutVolume";
        internal const string FUNC_RTCENGINE_GETAUDIOMIXINGPLAYOUTVOLUME = "RtcEngine_getAudioMixingPlayoutVolume";
        internal const string FUNC_RTCENGINE_GETAUDIOMIXINGDURATION = "RtcEngine_getAudioMixingDuration";
        internal const string FUNC_RTCENGINE_GETAUDIOMIXINGCURRENTPOSITION = "RtcEngine_getAudioMixingCurrentPosition";
        internal const string FUNC_RTCENGINE_SETAUDIOMIXINGPOSITION = "RtcEngine_setAudioMixingPosition";
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
        internal const string FUNC_RTCENGINE_SETLOCALVOICEEQUALIZATION= "RtcEngine_setLocalVoiceEqualization";
        internal const string FUNC_RTCENGINE_SETLOCALVOICEREVERB = "RtcEngine_setLocalVoiceReverb";
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
        internal const string FUNC_RTCENGINE_ENABLEDUALSTREAMMODE3 = "RtcEngine_enableDualStreamMode3";
        internal const string FUNC_RTCENGINE_ENABLEECHOCANCELLATIONEXTERNAL = "RtcEngine_enableEchoCancellationExternal";
        internal const string FUNC_RTCENGINE_ENABLECUSTOMAUDIOLOCALPLAYBACK = "RtcEngine_enableCustomAudioLocalPlayback";
        internal const string FUNC_RTCENGINE_STARTPRIMARYCUSTOMAUDIOTRACK = "RtcEngine_startPrimaryCustomAudioTrack";
        internal const string FUNC_RTCENGINE_STOPPRIMARYCUSTOMAUDIOTRACK = "RtcEngine_stopPrimaryCustomAudioTrack";
        internal const string FUNC_RTCENGINE_STARTSECONDARYCUSTOMAUDIOTRACK = "RtcEngine_startSecondaryCustomAudioTrack";
        internal const string FUNC_RTCENGINE_STOPSECONDARYCUSTOMAUDIOTRACK = "RtcEngine_stopSecondaryCustomAudioTrack";
        internal const string FUNC_RTCENGINE_SETRECORDINGAUDIOFRAMEPARAMETERS = "RtcEngine_setRecordingAudioFrameParameters";
        internal const string FUNC_RTCENGINE_SETPLAYBACKAUDIOFRAMEPARAMETERS = "RtcEngine_setPlaybackAudioFrameParameters";
        internal const string FUNC_RTCENGINE_SETMIXEDAUDIOFRAMEPARAMETERS = "RtcEngine_setMixedAudioFrameParameters";
        internal const string FUNC_RTCENGINE_SETPLAYBACKAUDIOFRAMEBEFOREMIXINGPARAMETERS = "RtcEngine_setPlaybackAudioFrameBeforeMixingParameters";
        internal const string FUNC_RTCENGINE_ENABLEAUDIOSPECTRUMMONITOR
 = "RtcEngine_enableAudioSpectrumMonitor";
        internal const string FUNC_RTCENGINE_DISABLEAUDIOSPECTRUMMONITOR = "RtcEngine_disableAudioSpectrumMonitor";
        internal const string FUNC_RTCENGINE_REGISTERAUDIOSPECTRUMOBSERVER = "RtcEngine_registerAudioSpectrumObserver";
        internal const string FUNC_RTCENGINE_UNREGISTERAUDIOSPECTRUMOBSERVER = "RtcEngine_unregisterAudioSpectrumObserver";
        internal const string FUNC_RTCENGINE_ADJUSTRECORDINGSIGNALVOLUME = "RtcEngine_adjustRecordingSignalVolume";
        internal const string FUNC_RTCENGINE_MUTERECORDINGSIGNAL = "RtcEngine_muteRecordingSignal";
        internal const string FUNC_RTCENGINE_ADJUSTPLAYBACKSIGNALVOLUME
 = "RtcEngine_adjustPlaybackSignalVolume";
        internal const string FUNC_RTCENGINE_ADJUSTUSERPLAYBACKSIGNALVOLUME = "RtcEngine_adjustUserPlaybackSignalVolume";
        internal const string FUNC_RTCENGINE_SETLOCALPUBLISHFALLBACKOPTION = "RtcEngine_setLocalPublishFallbackOption";
        internal const string FUNC_RTCENGINE_SETREMOTESUBSCRIBEFALLBACKOPTION = "RtcEngine_setRemoteSubscribeFallbackOption";
        internal const string FUNC_RTCENGINE_ENABLELOOPBACKRECORDING = "RtcEngine_enableLoopbackRecording";
        internal const string FUNC_RTCENGINE_ADJUSTLOOPBACKRECORDINGVOLUME = "RtcEngine_adjustLoopbackRecordingVolume";
        internal const string FUNC_RTCENGINE_GETLOOPBACKRECORDINGVOLUME
 = "RtcEngine_getLoopbackRecordingVolume";
        internal const string FUNC_RTCENGINE_ENABLEINEARMONITORING = "RtcEngine_enableInEarMonitoring";
        internal const string FUNC_RTCENGINE_SETINEARMONITORINGVOLUME = "RtcEngine_setInEarMonitoringVolume";
        internal const string FUNC_RTCENGINE_LOADEXTENSIONPROVIDER = "RtcEngine_loadExtensionProvider";
        internal const string FUNC_RTCENGINE_SETEXTENSIONPROVIDERPROPERTY = "RtcEngine_setExtensionProviderProperty";
        internal const string FUNC_RTCENGINE_ENABLEEXTENSION = "RtcEngine_enableExtension";
        internal const string FUNC_RTCENGINE_SETEXTENSIONPROPERTY = "RtcEngine_setExtensionProperty";
        internal const string FUNC_RTCENGINE_GETEXTENSIONPROPERTY = "RtcEngine_getExtensionProperty";
        internal const string FUNC_RTCENGINE_SETCAMERACAPTURERCONFIGURATION = "RtcEngine_setCameraCapturerConfiguration";
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
        internal const string FUNC_RTCENGINE_SETCAMERAEXPOSUREPOSITION= "RtcEngine_setCameraExposurePosition";
        internal const string FUNC_RTCENGINE_ISCAMERAAUTOEXPOSUREFACEMODESUPPORTED = "RtcEngine_isCameraAutoExposureFaceModeSupported";
        internal const string FUNC_RTCENGINE_SETCAMERAAUTOEXPOSUREFACEMODEENABLED = "RtcEngine_setCameraAutoExposureFaceModeEnabled";
        internal const string FUNC_RTCENGINE_SETDEFAULTAUDIOROUTETOSPEAKERPHONE = "RtcEngine_setDefaultAudioRouteToSpeakerphone";
        internal const string FUNC_RTCENGINE_SETENABLESPEAKERPHONE = "RtcEngine_setEnableSpeakerphone";
        internal const string FUNC_RTCENGINE_ISSPEAKERPHONEENABLED = "RtcEngine_isSpeakerphoneEnabled";
        internal const string FUNC_RTCENGINE_GETSCREENCAPTURESOURCES = "RtcEngine_getScreenCaptureSources";
        internal const string FUNC_RTCENGINE_STARTSCREENCAPTUREBYSCREENRECT = "RtcEngine_startScreenCaptureByScreenRect";
        internal const string FUNC_RTCENGINE_STARTSCREENCAPTURE = "RtcEngine_startScreenCapture";
        internal const string FUNC_RTCENGINE_GETAUDIODEVICEINFO = "RtcEngine_getAudioDeviceInfo";
        internal const string FUNC_RTCENGINE_STARTSCREENCAPTUREBYWINDOWID = "RtcEngine_startScreenCaptureByWindowId";
        internal const string FUNC_RTCENGINE_SETSCREENCAPTURECONTENTHINT = "RtcEngine_setScreenCaptureContentHint";
        internal const string FUNC_RTCENGINE_UPDATESCREENCAPTUREREGION= "RtcEngine_updateScreenCaptureRegion";
        internal const string FUNC_RTCENGINE_UPDATESCREENCAPTUREPARAMETERS = "RtcEngine_updateScreenCaptureParameters";
        internal const string FUNC_RTCENGINE_STOPSCREENCAPTURE = "RtcEngine_stopScreenCapture";
        internal const string FUNC_RTCENGINE_GETCALLID = "RtcEngine_getCallId";
        internal const string FUNC_RTCENGINE_RATE = "RtcEngine_rate";
        internal const string FUNC_RTCENGINE_COMPLAIN = "RtcEngine_complain";
        internal const string FUNC_RTCENGINE_ADDPUBLISHSTREAMURL = "RtcEngine_addPublishStreamUrl";
        internal const string FUNC_RTCENGINE_REMOVEPUBLISHSTREAMURL = "RtcEngine_removePublishStreamUrl";
        internal const string FUNC_RTCENGINE_SETLIVETRANSCODING = "RtcEngine_setLiveTranscoding";
        internal const string FUNC_RTCENGINE_STARTRTMPSTREAMWITHOUTTRANSCODING = "RtcEngine_startRtmpStreamWithoutTranscoding";
        internal const string FUNC_RTCENGINE_STARTRTMPSTREAMWITHTRANSCODING = "RtcEngine_startRtmpStreamWithTranscoding";
        internal const string FUNC_RTCENGINE_UPDATERTMPTRANSCODING = "RtcEngine_updateRtmpTranscoding";
        internal const string FUNC_RTCENGINE_STOPRTMPSTREAM = "RtcEngine_stopRtmpStream";
        internal const string FUNC_RTCENGINE_STARTLOCALVIDEOTRANSCODER= "RtcEngine_startLocalVideoTranscoder";
        internal const string FUNC_RTCENGINE_UPDATELOCALTRANSCODERCONFIGURATION = "RtcEngine_updateLocalTranscoderConfiguration";
        internal const string FUNC_RTCENGINE_STOPLOCALVIDEOTRANSCODER = "RtcEngine_stopLocalVideoTranscoder";
        internal const string FUNC_RTCENGINE_STARTPRIMARYCAMERACAPTURE= "RtcEngine_startPrimaryCameraCapture";
        internal const string FUNC_RTCENGINE_STARTSECONDARYCAMERACAPTURE = "RtcEngine_startSecondaryCameraCapture";
        internal const string FUNC_RTCENGINE_STOPPRIMARYCAMERACAPTURE = "RtcEngine_stopPrimaryCameraCapture";
        internal const string FUNC_RTCENGINE_STOPSECONDARYCAMERACAPTURE
 = "RtcEngine_stopSecondaryCameraCapture";
        internal const string FUNC_RTCENGINE_SETCAMERADEVICEORIENTATION
 = "RtcEngine_setCameraDeviceOrientation";
        internal const string FUNC_RTCENGINE_SETSCREENCAPTUREORIENTATION = "RtcEngine_setScreenCaptureOrientation";
        internal const string FUNC_RTCENGINE_STARTPRIMARYSCREENCAPTURE= "RtcEngine_startPrimaryScreenCapture";
        internal const string FUNC_RTCENGINE_STARTSECONDARYSCREENCAPTURE = "RtcEngine_startSecondaryScreenCapture";
        internal const string FUNC_RTCENGINE_STOPPRIMARYSCREENCAPTURE = "RtcEngine_stopPrimaryScreenCapture";
        internal const string FUNC_RTCENGINE_STOPSECONDARYSCREENCAPTURE
 = "RtcEngine_stopSecondaryScreenCapture";
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
        internal const string FUNC_RTCENGINE_CLEARVIDEOWATERMARK = "RtcEngine_clearVideoWatermark";
        internal const string FUNC_RTCENGINE_CLEARVIDEOWATERMARKS = "RtcEngine_clearVideoWatermarks";
        internal const string FUNC_RTCENGINE_ADDINJECTSTREAMURL = "RtcEngine_addInjectStreamUrl";
        internal const string FUNC_RTCENGINE_REMOVEINJECTSTREAMURL = "RtcEngine_removeInjectStreamUrl";
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
        internal const string FUNC_RTCENGINE_PUSHDIRECTCDNSTREAMINGCUSTOMVIDEOFRAME= "RtcEngine_pushDirectCdnStreamingCustomVideoFrame";
        internal const string FUNC_RTCENGINE_TAKESNAPSHOT = "RtcEngine_takeSnapshot";
        internal const string FUNC_RTCENGINE_SETCONTENTINSPECT = "RtcEngine_SetContentInspect";
        internal const string FUNC_RTCENGINE_SWITCHCHANNEL = "RtcEngine_switchChannel";
        internal const string FUNC_RTCENGINE_STARTRHYTHMPLAYER = "RtcEngine_startRhythmPlayer";
        internal const string FUNC_RTCENGINE_STOPRHYTHMPLAYER = "RtcEngine_stopRhythmPlayer";
        internal const string FUNC_RTCENGINE_CONFIGRHYTHMPLAYER = "RtcEngine_configRhythmPlayer";
        internal const string FUNC_RTCENGINE_ADJUSTCUSTOMAUDIOPUBLISHVOLUME = "RtcEngine_adjustCustomAudioPublishVolume";
        internal const string FUNC_RTCENGINE_ADJUSTCUSTOMAUDIOPLAYOUTVOLUME = "RtcEngine_adjustCustomAudioPlayoutVolume";
        internal const string FUNC_RTCENGINE_SETCLOUDPROXY = "RtcEngine_setCloudProxy";
        internal const string FUNC_RTCENGINE_SETLOCALACCESSPOINT = "RtcEngine_setLocalAccessPoint";
        internal const string FUNC_RTCENGINE_ENABLEFISHCORRECTION = "RtcEngine_enableFishCorrection";
        internal const string FUNC_RTCENGINE_SETADVANCEDAUDIOOPTIONS = "RtcEngine_setAdvancedAudioOptions";
        internal const string FUNC_RTCENGINE_SETAVSYNCSOURCE = "RtcEngine_setAVSyncSource";
        // class IRtcEngine end

        // class IMediaPlayer start
        internal const string FUNC_MEDIAPLAYER_INITIALIZE = "MediaPlayer_initialize";
        internal const string FUNC_MEDIAPLAYER_GETMEDIAPLAYERID = "MediaPlayer_getMediaPlayerId";
        internal const string FUNC_MEDIAPLAYER_OPEN = "MediaPlayer_open";
        internal const string FUNC_MEDIAPLAYER_OPENWITHCUSTOMSOURCE = "MediaPlayer_openWithCustomSource";
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
        internal const string FUNC_MEDIAPLAYER_MUTEAUDIO = "MediaPlayer_muteAudio";
        internal const string FUNC_MEDIAPLAYER_ISAUDIOMUTED = "MediaPlayer_isAudioMuted";
        internal const string FUNC_MEDIAPLAYER_MUTEVIDEO = "MediaPlayer_muteVideo";
        internal const string FUNC_MEDIAPLAYER_ISVIDEOMUTED = "MediaPlayer_isVideoMuted";
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
        internal const string FUNC_MEDIAPLAYER_GETCURRENTAGORACDNINDEX= "MediaPlayer_getCurrentAgoraCDNIndex";
        internal const string FUNC_MEDIAPLAYER_ENABLEAUTOSWITCHAGORACDN
 = "MediaPlayer_enableAutoSwitchAgoraCDN";
        internal const string FUNC_MEDIAPLAYER_RENEWAGORACDNSRCTOKEN = "MediaPlayer_renewAgoraCDNSrcToken";
        internal const string FUNC_MEDIAPLAYER_SWITCHAGORACDNSRC = "MediaPlayer_switchAgoraCDNSrc";
        internal const string FUNC_MEDIAPLAYER_SWITCHSRC = "MediaPlayer_switchSrc";
        internal const string FUNC_MEDIAPLAYER_PRELOADSRC = "MediaPlayer_preloadSrc";
        internal const string FUNC_MEDIAPLAYER_PLAYPRELOADEDSRC = "MediaPlayer_playPreloadedSrc";
        internal const string FUNC_MEDIAPLAYER_UNLOADSRC = "MediaPlayer_unloadSrc";
        internal const string FUNC_MEDIAPLAYER_SETSPATIALAUDIOPARAMS = "MediaPlayer_setSpatialAudioParams";
        // class IMediaPlayer end

        // class IAudioDeviceManager start
        internal const string FUNC_AUDIODEVICEMANAGER_ENUMERATEPLAYBACKDEVICES = "AudioDeviceManager_enumeratePlaybackDevices";
        internal const string FUNC_AUDIODEVICEMANAGER_ENUMERATERECORDINGDEVICES = "AudioDeviceManager_enumerateRecordingDevices";
        internal const string FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICE
 = "AudioDeviceManager_setPlaybackDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICE
 = "AudioDeviceManager_getPlaybackDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEINFO = "AudioDeviceManager_getPlaybackDeviceInfo";
        internal const string FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEVOLUME = "AudioDeviceManager_setPlaybackDeviceVolume";
        internal const string FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEVOLUME = "AudioDeviceManager_getPlaybackDeviceVolume";
        internal const string FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICE = "AudioDeviceManager_setRecordingDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICE = "AudioDeviceManager_getRecordingDevice";
        internal const string FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEINFO = "AudioDeviceManager_getRecordingDeviceInfo";
        internal const string FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEVOLUME = "AudioDeviceManager_setRecordingDeviceVolume";
        internal const string FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEVOLUME = "AudioDeviceManager_getRecordingDeviceVolume";
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
        internal const string FUNC_AUDIODEVICEMANAGER_RELEASE = "AudioDeviceManager_release";
        // class IAudioDeviceManager end

        // class ICloudSpatialAudioEngine start
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_SETMAXAUDIORECVCOUNT = "CloudSpatialAudioEngine_setMaxAudioRecvCount";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_SETAUDIORECVRANGE = "CloudSpatialAudioEngine_setAudioRecvRange";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_SETDISTANCEUNIT = "CloudSpatialAudioEngine_setDistanceUnit";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_UPDATESELFPOSITION = "CloudSpatialAudioEngine_updateSelfPosition";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_UPDATESELFPOSITIONEX = "CloudSpatialAudioEngine_updateSelfPositionEx";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_UPDATEPLAYERPOSITIONINFO= "CloudSpatialAudioEngine_updatePlayerPositionInfo";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_SETPARAMETERS = "CloudSpatialAudioEngine_setParameters";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_INITIALIZE = "CloudSpatialAudioEngine_initialize";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_ADDEVENTHANDLER = "CloudSpatialAudioEngine_addEventHandler";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_REMOVEEVENTHANDLER = "CloudSpatialAudioEngine_removeEventHandler";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_ENABLESPATIALIZER = "CloudSpatialAudioEngine_enableSpatializer";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_SETTEAMID = "CloudSpatialAudioEngine_setTeamId";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_SETAUDIORANGEMODE = "CloudSpatialAudioEngine_setAudioRangeMode";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_ENTERROOM = "CloudSpatialAudioEngine_enterRoom";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_RENEWTOKEN = "CloudSpatialAudioEngine_renewToken";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_EXITROOM = "CloudSpatialAudioEngine_exitRoom";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_GETTEAMMATES
 = "CloudSpatialAudioEngine_getTeammates";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_MUTELOCALAUDIOSTREAM = "CloudSpatialAudioEngine_muteLocalAudioStream";
        internal const string FUNC_CLOUDSPATIALAUDIOENGINE_MUTEALLREMOTEAUDIOSTREAMS
 = "CloudSpatialAudioEngine_muteAllRemoteAudioStreams";
        // class ICloudSpatialAudioEngine end

        // class ILocalSpatialAudioEngine start
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETMAXAUDIORECVCOUNT = "LocalSpatialAudioEngine_setMaxAudioRecvCount";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETAUDIORECVRANGE = "LocalSpatialAudioEngine_setAudioRecvRange";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETDISTANCEUNIT = "LocalSpatialAudioEngine_setDistanceUnit";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITION = "LocalSpatialAudioEngine_updateSelfPosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITIONEX = "LocalSpatialAudioEngine_updateSelfPositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATEPLAYERPOSITIONINFO= "LocalSpatialAudioEngine_updatePlayerPositionInfo";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_SETPARAMETERS = "LocalSpatialAudioEngine_setParameters";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITION = "LocalSpatialAudioEngine_updateRemotePosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITION = "LocalSpatialAudioEngine_removeRemotePosition";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONS = "LocalSpatialAudioEngine_clearRemotePositions";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITIONEX = "LocalSpatialAudioEngine_updateRemotePositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITIONEX = "LocalSpatialAudioEngine_removeRemotePositionEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONSEX = "LocalSpatialAudioEngine_clearRemotePositionsEx";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_MUTELOCALAUDIOSTREAM = "LocalSpatialAudioEngine_muteLocalAudioStream";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_MUTEALLREMOTEAUDIOSTREAMS
 = "LocalSpatialAudioEngine_muteAllRemoteAudioStreams";
        internal const string FUNC_LOCALSPATIALAUDIOENGINE_INITIALIZE = "LocalSpatialAudioEngine_initialize";
        // class ILocalSpatialAudioEngine end

        // class RtcRawDataPluginManager start
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_REGISTERPLUGIN = "RtcRawDataPluginManager_registerPlugin";
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_GETPLUGINPARAMETER = "RtcRawDataPluginManager_getPluginParameter";
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_UNREGISTERPLUGIN = "RtcRawDataPluginManager_unRegisterPlugin";
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_HASPLUGIN = "RtcRawDataPluginManager_hasPlugin";
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_ENABLEPLUGIN
 = "RtcRawDataPluginManager_enablePlugin";
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_DELETEPLUGIN
 = "RtcRawDataPluginManager_deletePlugin";
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_GETPLUGINS = "RtcRawDataPluginManager_getPlugins";
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_SETPLUGINPARAMETER = "RtcRawDataPluginManager_setPluginParameter";
        internal const string FUNC_RTCRAWDATAPLUGINMANAGER_REMOVEALLPLUGINS = "RtcRawDataPluginManager_removeAllPlugins";
        // class RtcRawDataPluginManager end

        // class RtcRawData start
        internal const string FUNC_RTCRAWDATA_REGISTERAUDIOFRAMEOBSERVER = "RtcRawData_registerAudioFrameObserver";
        internal const string FUNC_RTCRAWDATA_UNREGISTERAUDIOFRAMEOBSERVER = "RtcRawData_unRegisterAudioFrameObserver";
        internal const string FUNC_RTCRAWDATA_REGISTERVIDEOFRAMEOBSERVER = "RtcRawData_registerVideoFrameObserver";
        internal const string FUNC_RTCRAWDATA_UNREGISTERVIDEOFRAMEOBSERVER = "RtcRawData_unRegisterVideoFrameObserver";
        internal const string FUNC_RTCRAWDATA_REGISTERVIDEOENCODEDIMAGERECEIVER = "RtcRawData_registerVideoEncodedImageReceiver";
        internal const string FUNC_RTCRAWDATA_UNREGISTERVIDEOENCODEDIMAGERECEIVER = "RtcRawData_unRegisterVideoEncodedImageReceiver";
        internal const string FUNC_RTCRAWDATA_REGISTERAUDIOENCODEDFRAMEOBSERVER = "RtcRawData_registerAudioEncodedFrameObserver";
        internal const string FUNC_RTCRAWDATA_UNREGISTERAUDIOENCODEDFRAMEOBSERVER = "RtcRawData_unRegisterAudioEncodedFrameObserver";
        internal const string FUNC_RTCRAWDATA_ATTACH = "RtcRawData_attach";
        internal const string FUNC_RTCRAWDATA_DETACH = "RtcRawData_detach";
    // class RtcRawData
    }
}