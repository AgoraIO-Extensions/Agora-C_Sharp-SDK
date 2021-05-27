//
//  Created by Yiqing Huang on 2020/12/15.
//  Copyright © 2020 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agorartc
{
    using IrisEnginePtr = IntPtr;
    using IrisChannelPtr = IntPtr;
    using IrisDeviceManagerPtr = IntPtr;
    using IrisTestPtr = IntPtr;


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
        kEngineSetAppType,

        kMediaPushAudioFrame,
        kMediaPullAudioFrame,
        kMediaSetExternalVideoSource,
        kMediaPushVideoFrame,
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
        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEnginePtr CreateIrisEngine();

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisEngine(IrisEnginePtr iris_engine);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetIrisEngineEventHandler(IrisEnginePtr iris_engine,
            ref IrisCEventHandler iris_c_event_handler);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisEngineApi(IrisEnginePtr iris_engine, CApiTypeEngine api_type,
            byte[] para, out CharArrayAssistant result);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisEngineApiWithBuffer(IrisEnginePtr iris_engine, CApiTypeEngine api_type,
            byte[] para, byte[] buffer, out CharArrayAssistant result);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisChannelPtr GetIrisChannel(IrisEnginePtr iris_engine);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetIrisChannelEventHandler(IrisChannelPtr iris_channel,
            ref IrisCEventHandler iris_c_event_handler);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisChannelApi(IrisChannelPtr iris_channel, CApiTypeChannel api_type,
            byte[] para, out CharArrayAssistant result);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisChannelApiWithBuffer(IrisChannelPtr iris_channel,
            CApiTypeChannel api_type, byte[] para, byte[] buffer, out CharArrayAssistant result);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisDeviceManagerPtr GetIrisDeviceManager(IrisEnginePtr iris_engine);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallAudioDeviceApi(IrisDeviceManagerPtr iris_device_manager,
            CApiTypeAudioDeviceManager api_type, byte[] paras, out CharArrayAssistant result);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallVideoDeviceApi(IrisDeviceManagerPtr iris_device_manager,
            CApiTypeVideoDeviceManager api_type, byte[] para, out CharArrayAssistant result);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisTestPtr CreateIrisTest(string dump_file_path);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisTest(IrisTestPtr iris_test);
        
        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetProxy(IrisTestPtr iris_test, IrisEnginePtr iris_engine);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void BeginApiTestByFile(IrisTestPtr iris_test, string case_file_path,
            ref IrisCEventHandler iris_c_event_handler);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void BeginApiTest(IrisTestPtr iris_test, string case_content,
            ref IrisCEventHandler iris_c_event_handler);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void BeginEventTestByFile(IrisTestPtr iris_test, string case_file_path,
            ref IrisCEventHandler iris_c_event_handler);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void BeginEventTest(IrisTestPtr iris_test, string case_content,
            ref IrisCEventHandler iris_c_event_handler);

        [DllImport("iris.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void OnEventReceived(IrisTestPtr iris_test, string @event, string data);
    }
}