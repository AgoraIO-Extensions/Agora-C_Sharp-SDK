//  IrisRtcBase.cs
//
//  Created by Yiqing Huang on May 25, 2021.
//  Modified by Yiqing Huang on June 26, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
    internal enum EngineType
    {
        kEngineTypeNormal,
        kEngineTypeSubProcess,
    }

    internal enum ApiTypeEngine
    {
        kEngineInitialize,
        kEngineRelease,
        kEngineSetChannelProfile,
        kEngineSetClientRole,
        kEngineJoinChannel,
        kEngineSwitchChannel,
        kEngineLeaveChannel,
        kEngineRenewToken,
        kEngineRegisterLocalUserAccount,
        kEngineJoinChannelWithUserAccount,
        kEngineGetUserInfoByUserAccount,
        kEngineGetUserInfoByUid,
        kEngineStartEchoTest,
        kEngineStopEchoTest,
        kEngineSetCloudProxy,
        kEngineEnableVideo,
        kEngineDisableVideo,
        kEngineSetVideoProfile,
        kEngineSetVideoEncoderConfiguration,
        kEngineSetCameraCapturerConfiguration,
        kEngineSetupLocalVideo,
        kEngineSetupRemoteVideo,
        kEngineStartPreview,
        kEngineSetRemoteUserPriority,
        kEngineStopPreview,
        kEngineEnableAudio,
        kEngineEnableLocalAudio,
        kEngineDisableAudio,
        kEngineSetAudioProfile,
        kEngineMuteLocalAudioStream,
        kEngineMuteAllRemoteAudioStreams,
        kEngineSetDefaultMuteAllRemoteAudioStreams,
        kEngineAdjustUserPlaybackSignalVolume,
        kEngineMuteRemoteAudioStream,
        kEngineMuteLocalVideoStream,
        kEngineEnableLocalVideo,
        kEngineMuteAllRemoteVideoStreams,
        kEngineSetDefaultMuteAllRemoteVideoStreams,
        kEngineMuteRemoteVideoStream,
        kEngineSetRemoteVideoStreamType,
        kEngineSetRemoteDefaultVideoStreamType,
        kEngineEnableAudioVolumeIndication,
        kEngineStartAudioRecording,
        kEngineStopAudioRecording,
        kEngineStartAudioMixing,
        kEngineStopAudioMixing,
        kEnginePauseAudioMixing,
        kEngineResumeAudioMixing,
        kEngineSetHighQualityAudioParameters,
        kEngineAdjustAudioMixingVolume,
        kEngineAdjustAudioMixingPlayoutVolume,
        kEngineGetAudioMixingPlayoutVolume,
        kEngineAdjustAudioMixingPublishVolume,
        kEngineGetAudioMixingPublishVolume,
        kEngineGetAudioMixingDuration,
        kEngineGetAudioMixingCurrentPosition,
        kEngineSetAudioMixingPosition,
        kEngineSetAudioMixingPitch,
        kEngineGetEffectsVolume,
        kEngineSetEffectsVolume,
        kEngineSetVolumeOfEffect,
        kEngineEnableFaceDetection,
        kEnginePlayEffect,
        kEngineStopEffect,
        kEngineStopAllEffects,
        kEnginePreloadEffect,
        kEngineUnloadEffect,
        kEnginePauseEffect,
        kEnginePauseAllEffects,
        kEngineResumeEffect,
        kEngineResumeAllEffects,
        kEngineGetEffectDuration,
        kEngineSetEffectPosition,
        kEngineGetEffectCurrentPosition,
        kEngineEnableDeepLearningDenoise,
        kEngineEnableSoundPositionIndication,
        kEngineSetRemoteVoicePosition,
        kEngineSetLocalVoicePitch,
        kEngineSetLocalVoiceEqualization,
        kEngineSetLocalVoiceReverb,
        kEngineSetLocalVoiceChanger,
        kEngineSetLocalVoiceReverbPreset,
        kEngineSetVoiceBeautifierPreset,
        kEngineSetAudioEffectPreset,
        kEngineSetVoiceConversionPreset,
        kEngineSetAudioEffectParameters,
        kEngineSetVoiceBeautifierParameters,
        kEngineSetLogFile,
        kEngineSetLogFilter,
        kEngineSetLogFileSize,
        kEngineUploadLogFile,
        kEngineSetLocalRenderMode,
        kEngineSetRemoteRenderMode,
        kEngineSetLocalVideoMirrorMode,
        kEngineEnableDualStreamMode,
        kEngineSetExternalAudioSource,
        kEngineSetExternalAudioSink,
        kEngineSetRecordingAudioFrameParameters,
        kEngineSetPlaybackAudioFrameParameters,
        kEngineSetMixedAudioFrameParameters,
        kEngineAdjustRecordingSignalVolume,
        kEngineAdjustPlaybackSignalVolume,
        kEngineAdjustLoopBackRecordingSignalVolume,
        kEngineEnableWebSdkInteroperability,
        kEngineSetVideoQualityParameters,
        kEngineSetLocalPublishFallbackOption,
        kEngineSetRemoteSubscribeFallbackOption,
        kEngineSwitchCamera,
        kEngineSetDefaultAudioRouteToSpeakerPhone,
        kEngineSetEnableSpeakerPhone,
        kEngineEnableInEarMonitoring,
        kEngineSetInEarMonitoringVolume,
        kEngineIsSpeakerPhoneEnabled,
        kEngineSetAudioSessionOperationRestriction,
        kEngineEnableLoopBackRecording,
        kEngineStartScreenCaptureByDisplayId,
        kEngineStartScreenCaptureByScreenRect,
        kEngineStartScreenCaptureByWindowId,
        kEngineSetScreenCaptureContentHint,
        kEngineUpdateScreenCaptureParameters,
        kEngineUpdateScreenCaptureRegion,
        kEngineStopScreenCapture,
        kEngineStartScreenCapture,
        kEngineSetVideoSource,
        kEngineGetCallId,
        kEngineRate,
        kEngineComplain,
        kEngineGetVersion,
        kEngineEnableLastMileTest,
        kEngineDisableLastMileTest,
        kEngineStartLastMileProbeTest,
        kEngineStopLastMileProbeTest,
        kEngineGetErrorDescription,
        kEngineSetEncryptionSecret,
        kEngineSetEncryptionMode,
        kEngineEnableEncryption,
        kEngineRegisterPacketObserver,
        kEngineCreateDataStream,
        kEngineSendStreamMessage,
        kEngineAddPublishStreamUrl,
        kEngineRemovePublishStreamUrl,
        kEngineSetLiveTranscoding,
        kEngineAddVideoWaterMark,
        kEngineClearVideoWaterMarks,
        kEngineSetBeautyEffectOptions,
        kEngineEnableVirtualBackground,
        kEngineAddInjectStreamUrl,
        kEngineStartChannelMediaRelay,
        kEngineUpdateChannelMediaRelay,
        kEnginePauseAllChannelMediaRelay,
        kEngineResumeAllChannelMediaRelay,
        kEngineStopChannelMediaRelay,
        kEngineRemoveInjectStreamUrl,
        kEngineSendCustomReportMessage,
        kEngineGetConnectionState,
        kEngineEnableRemoteSuperResolution,
        kEngineRegisterMediaMetadataObserver,
        kEngineSetParameters,
        kEngineSetLocalAccessPoint,

        kEngineUnRegisterMediaMetadataObserver,
        kEngineSetMaxMetadataSize,
        kEngineSendMetadata,
        kEngineSetAppType,

        kMediaPushAudioFrame,
        kMediaPullAudioFrame,
        kMediaSetExternalVideoSource,
        kMediaPushVideoFrame,

        kEngineSetAudioMixingPlaybackSpeed,
        kEngineSelectAudioTrack,
        kEngineGetAudioTrackCount,
        kEngineSetAudioMixingDualMonoMode,
        kEngineGetAudioFileInfo,
        kEngineSetVideoProfileEx,
        kMediaSetExternalAudioSourceVolume,
        kEngineSetLogWriter,
        kEngineReleaseLogWriter,
        kEngineSetLocalVideoRenderer,
        kEngineSetRemoteVideoRenderer,
        kEngineSetCameraTorchOn,
        kEngineIsCameraTorchSupported,

        kEngineGetCameraMaxZoomFactor,
        kEngineIsCameraAutoFocusFaceModeSupported,
        kEngineIsCameraExposurePositionSupported,
        kEngineIsCameraFocusSupported,
        kEngineIsCameraZoomSupported,
        kEngineSetCameraAutoFocusFaceModeEnabled,
        kEngineSetCameraExposurePosition,
        kEngineSetCameraFocusPositionInPreview,
        kEngineSetCameraZoomFactor,
        kEngineStartRhythmPlayer,
        kEngineStopRhythmPlayer,
        kEngineConfigRhythmPlayer,
        kEngineGetNativeHandle,


        kEngineGetScreenCaptureSources,
        kEngineTakeSnapshot,
        kEngineEnableContentInspect,

        kEngineSetAVSyncSource = 196,
        kEngineStartRtmpStreamWithoutTranscoding = 197,
        kEngineStartRtmpStreamWithTranscoding = 198,
        kEngineUpdateRtmpTranscoding = 199,
        kEngineStopRtmpStream = 200,
        kEngineSetLowlightEnhanceOptions = 201,
        kEngineSetVideoDenoiserOptions = 202,
        kEngineSetColorEnhanceOptions = 203,
        kEngineEnableWirelessAccelerate = 204,
        kEngineMediaRecorderStart = 205,
        kEngineMediaRecorderStop = 206,
        kEngineMediaRecorderRelease = 207,
    }


    internal enum ApiTypeChannel
    {
        kChannelCreateChannel,
        kChannelRelease,
        kChannelJoinChannel,
        kChannelJoinChannelWithUserAccount,
        kChannelLeaveChannel,
        kChannelPublish,
        kChannelUnPublish,
        kChannelChannelId,
        kChannelGetCallId,
        kChannelRenewToken,
        kChannelSetEncryptionSecret,
        kChannelSetEncryptionMode,
        kChannelEnableEncryption,
        kChannelRegisterPacketObserver,
        kChannelRegisterMediaMetadataObserver,
        kChannelUnRegisterMediaMetadataObserver,
        kChannelSetMaxMetadataSize,
        kChannelSendMetadata,
        kChannelSetClientRole,
        kChannelSetRemoteUserPriority,
        kChannelSetRemoteVoicePosition,
        kChannelSetRemoteRenderMode,
        kChannelSetDefaultMuteAllRemoteAudioStreams,
        kChannelSetDefaultMuteAllRemoteVideoStreams,
        kChannelMuteLocalAudioStream,
        kChannelMuteLocalVideoStream,
        kChannelMuteAllRemoteAudioStreams,
        kChannelAdjustUserPlaybackSignalVolume,
        kChannelMuteRemoteAudioStream,
        kChannelMuteAllRemoteVideoStreams,
        kChannelMuteRemoteVideoStream,
        kChannelSetRemoteVideoStreamType,
        kChannelSetRemoteDefaultVideoStreamType,
        kChannelCreateDataStream,
        kChannelSendStreamMessage,
        kChannelAddPublishStreamUrl,
        kChannelRemovePublishStreamUrl,
        kChannelSetLiveTranscoding,
        kChannelAddInjectStreamUrl,
        kChannelRemoveInjectStreamUrl,
        kChannelStartChannelMediaRelay,
        kChannelUpdateChannelMediaRelay,
        kChannelPauseAllChannelMediaRelay,
        kChannelResumeAllChannelMediaRelay,
        kChannelStopChannelMediaRelay,
        kChannelGetConnectionState,
        kChannelEnableRemoteSuperResolution,
        kChannelSetAVSyncSource = 47,
        kChannelStartRtmpStreamWithoutTranscoding = 48,
        kChannelStartRtmpStreamWithTranscoding = 49,
        kChannelUpdateRtmpTranscoding = 50,
        kChannelStopRtmpStream = 51,
    }

    internal enum ApiTypeAudioDeviceManager
    {
        kADMEnumeratePlaybackDevices,
        kADMSetPlaybackDevice,
        kADMGetPlaybackDevice,
        kADMGetPlaybackDeviceInfo,
        kADMSetPlaybackDeviceVolume,
        kADMGetPlaybackDeviceVolume,
        kADMSetPlaybackDeviceMute,
        kADMGetPlaybackDeviceMute,
        kADMStartPlaybackDeviceTest,
        kADMStopPlaybackDeviceTest,

        kADMEnumerateRecordingDevices,
        kADMSetRecordingDevice,
        kADMGetRecordingDevice,
        kADMGetRecordingDeviceInfo,
        kADMSetRecordingDeviceVolume,
        kADMGetRecordingDeviceVolume,
        kADMSetRecordingDeviceMute,
        kADMGetRecordingDeviceMute,
        kADMStartRecordingDeviceTest,
        kADMStopRecordingDeviceTest,

        kADMStartAudioDeviceLoopbackTest,
        kADMStopAudioDeviceLoopbackTest,
        kADMFollowSystemPlaybackDevice = 22,
        kADMFollowSystemRecordingDevice = 23,
    }

    internal enum ApiTypeVideoDeviceManager
    {
        kVDMEnumerateVideoDevices,
        kVDMSetDevice,
        kVDMGetDevice,
        kVDMStartDeviceTest,
        kVDMStopDeviceTest,
    }

    internal enum ApiTypeRawDataPluginManager
    {
        kRDPMRegisterPlugin,
        kRDPMUnregisterPlugin,
        kRDPMHasPlugin,
        kRDPMEnablePlugin,
        kRDPMGetPlugins,
        kRDPMSetPluginParameter,
        kRDPMGetPluginParameter,
        kRDPMRelease
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcAudioFrame
    {
        internal AUDIO_FRAME_TYPE type;
        internal int samples;
        internal int bytes_per_sample;
        internal int channels;
        internal int samples_per_sec;
        internal IntPtr buffer;
        internal uint buffer_length;
        internal long render_time_ms;
        internal int av_sync_type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisVideoFrame
    {
        internal VIDEO_FRAME_TYPE type;
        internal int width;
        internal int height;
        internal int y_stride;
        internal int u_stride;
        internal int v_stride;
        internal IntPtr y_buffer;
        internal IntPtr u_buffer;
        internal IntPtr v_buffer;
        internal uint y_buffer_length;
        internal uint u_buffer_length;
        internal uint v_buffer_length;
        internal int rotation;
        internal long render_time_ms;
        internal int av_sync_type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisWindowCollection
    {
        internal IntPtr windows;
        internal uint length;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisDisplayCollection
    {
        internal IntPtr displays;
        internal int length;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisWindow
    {
        internal ulong id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string name;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        internal string owner_name;

        internal IrisRect bounds;
        internal IrisRect work_area;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisDisplay
    {
        internal uint id;
        internal float scale;
        internal IrisRect bounds;
        internal IrisRect work_area;
        internal int rotation;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRect
    {
        internal double x;
        internal double y;
        internal double width;
        internal double height;
    }
}