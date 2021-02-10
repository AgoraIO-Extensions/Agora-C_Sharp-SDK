using System;
using System.Runtime.InteropServices;

namespace agorartc
{

    using uid_t = UInt32;
    using view_t = IntPtr;
    using IRtcEngineBridge_ptr = IntPtr;
    using IRtcChannelBridge_ptr = IntPtr;
    using IVideoDeviceManager_ptr = IntPtr;
    using IAudioPlaybackDeviceManager_ptr = IntPtr;
    using IAudioRecordingDeviceManager_ptr = IntPtr;

    using IrisEnginePtr = IntPtr;
    using IrisChannelPtr = IntPtr;
    using IrisDeviceManagerPtr = IntPtr;


    internal enum CApiTypeEngine
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
        kEngineEnableSoundPositionIndication,
        kEngineSetRemoteVoicePosition,
        kEngineSetLocalVoicePitch,
        kEngineSetLocalVoiceEqualization,
        kEngineSetLocalVoiceReverb,
        kEngineSetLocalVoiceChanger,
        kEngineSetLocalVoiceReverbPreset,
        kEngineSetVoiceBeautifierPreset,
        kEngineSetAudioEffectPreset,
        kEngineSetAudioEffectParameters,
        kEngineSetLogFile,
        kEngineSetLogFilter,
        kEngineSetLogFileSize,
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
        kEngineEnableWebSdkInteroperability,
        kEngineSetVideoQualityParameters,
        kEngineSetLocalPublishFallbackOption,
        kEngineSetRemoteSubscribeFallbackOption,
        kEngineSwitchCamera,
        kEngineSetDefaultAudioRouteSpeakerPhone,
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
        kEngineAddInjectStreamUrl,
        kEngineStartChannelMediaRelay,
        kEngineUpdateChannelMediaRelay,
        kEngineStopChannelMediaRelay,
        kEngineRemoveInjectStreamUrl,
        kEngineSendCustomReportMessage,
        kEngineGetConnectionState,
        kEngineEnableRemoteSuperResolution,
        kEngineRegisterMediaMetadataObserver,
        kEngineUnRegisterMediaMetadataObserver,
        kEngineSetMaxMetadataSize,
        kEngineSendMetadata,
        kEngineSetParameters,
        kEngineSetPlaybackDeviceVolume,
    };

    internal enum CApiTypeChannel
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
        kChannelStopChannelMediaRelay,
        kChannelGetConnectionState,
        kChannelEnableRemoteSuperResolution,
    };

    internal enum CApiTypeAudioDeviceManager
    {
        kGetAudioPlaybackDeviceCount,
        kGetAudioPlaybackDeviceInfoByIndex,
        kSetCurrentAudioPlaybackDeviceId,
        kGetCurrentAudioPlaybackDeviceId,
        kGetCurrentAudioPlaybackDeviceInfo,
        kSetAudioPlaybackDeviceVolume,
        kGetAudioPlaybackDeviceVolume,
        kSetAudioPlaybackDeviceMute,
        kGetAudioPlaybackDeviceMute,
        kStartAudioPlaybackDeviceTest,
        kStopAudioPlaybackDeviceTest,

        kGetAudioRecordingDeviceCount,
        kGetAudioRecordingDeviceInfoByIndex,
        kSetCurrentAudioRecordingDeviceId,
        kGetCurrentAudioRecordingDeviceId,
        kGetCurrentAudioRecordingDeviceInfo,
        kSetAudioRecordingDeviceVolume,
        kGetAudioRecordingDeviceVolume,
        kSetAudioRecordingDeviceMute,
        kGetAudioRecordingDeviceMute,
        kStartAudioRecordingDeviceTest,
        kStopAudioRecordingDeviceTest,

        kStartAudioDeviceLoopbackTest,
        kStopAudioDeviceLoopbackTest,
    };

    internal enum CApiTypeVideoDeviceManager
    {
        kGetVideoDeviceCount,
        kGetVideoDeviceInfoByIndex,
        kSetCurrentVideoDeviceId,
        kGetCurrentVideoDeviceId,
        kStartVideoDeviceTest,
        kStopVideoDeviceTest,
    };

    internal static class AgorartcNative
    {
        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEnginePtr CreateIrisEngine();

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisEngine(IrisEnginePtr iris_engine);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetIrisEngineEventHandler(IrisEnginePtr iris_engine, ref IrisCEventHandler iris_c_event_handler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisEngineApi(IrisEnginePtr iris_engine, CApiTypeEngine api_type,
                      string para, char[] result);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisEngineApiWithBuffer(IrisEnginePtr iris_engine, CApiTypeEngine api_type,
                      string para, byte[] buffer);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisChannelPtr GetIrisChannel(IrisEnginePtr iris_engine);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetIrisChannelEventHandler(IrisChannelPtr iris_channel,
                                ref IrisCEventHandler iris_c_event_handler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisChannelApi(IrisChannelPtr iris_channel, CApiTypeChannel api_type,
                       string para, char[] result);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisChannelApiWithBuffer(IrisChannelPtr iris_channel,
                                 CApiTypeChannel api_type, string para, byte[] buffer);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisDeviceManagerPtr GetIrisDeviceManager(IrisEnginePtr iris_engine);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallAudioDeviceApi(IrisDeviceManagerPtr iris_device_manager,
                       CApiTypeAudioDeviceManager api_type, string paras, char[] result);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallVideoDeviceApi(IrisDeviceManagerPtr iris_device_manager,
                       CApiTypeVideoDeviceManager api_type, string para, char[] result);
    }
}