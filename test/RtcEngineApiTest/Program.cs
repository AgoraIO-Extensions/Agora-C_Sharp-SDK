using System;
using System.Text;
using System.Text.Json;
using agorartc;

namespace RtcEngineApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var engineApiTest = new AgoraRtcEngineApiTest(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\test\\test_result\\engine_api_test_result.json",
                new MyEventHandler(), AgoraRtcEngine.CreateRtcEngine());
            engineApiTest.BeginApiTestByFile(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\iris\\case\\ApiTest.json");
        }
    }

    internal class MyEventHandler : IRtcEngineEventHandlerBase
    {
        public override void OnApiTest(int apiType, string @params)
        {
            var apiTypeEnum = (CApiTypeEngine) apiType;
            switch (apiTypeEnum)
            {
                case CApiTypeEngine.kEngineInitialize:
                    var context = (string) AgoraUtil.GetData<object>(@params, "context");
                    AgoraRtcEngine.CreateRtcEngine().Initialize(new RtcEngineContext(
                        (string) AgoraUtil.GetData<string>(context, "appId"),
                        (AREA_CODE) AgoraUtil.GetData<uint>(context, "areaCode")));
                    break;
                case CApiTypeEngine.kEngineSetChannelProfile:
                    AgoraRtcEngine.CreateRtcEngine()
                        .SetChannelProfile((CHANNEL_PROFILE_TYPE) AgoraUtil.GetData<int>(@params, "profile"));
                    break;
                case CApiTypeEngine.kEngineSetClientRole:
                    AgoraRtcEngine.CreateRtcEngine().SetClientRole(
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(@params, "role"));
                    break;
                case CApiTypeEngine.kEngineJoinChannel:
                    AgoraRtcEngine.CreateRtcEngine().JoinChannel(
                        (string) AgoraUtil.GetData<string>(@params, "token"),
                        (string) AgoraUtil.GetData<string>(@params, "channelId"),
                        (string) AgoraUtil.GetData<string>(@params, "info"),
                        (uint) AgoraUtil.GetData<uint>(@params, "uid"));
                    break;
                case CApiTypeEngine.kEngineSwitchChannel:
                    AgoraRtcEngine.CreateRtcEngine().SwitchChannel(
                        (string) AgoraUtil.GetData<string>(@params, "token"),
                        (string) AgoraUtil.GetData<string>(@params, "channelId"));
                    break;
                case CApiTypeEngine.kEngineLeaveChannel:
                    AgoraRtcEngine.CreateRtcEngine().LeaveChannel();
                    break;
                case CApiTypeEngine.kEngineRenewToken:
                    AgoraRtcEngine.CreateRtcEngine().RenewToken(
                        (string) AgoraUtil.GetData<string>(@params, "token"));
                    break;
                case CApiTypeEngine.kEngineRegisterLocalUserAccount:
                    AgoraRtcEngine.CreateRtcEngine().RegisterLocalUserAccount(
                        (string) AgoraUtil.GetData<string>(@params, "appId"),
                        (string) AgoraUtil.GetData<string>(@params, "userAccount"));
                    break;
                case CApiTypeEngine.kEngineJoinChannelWithUserAccount:
                    AgoraRtcEngine.CreateRtcEngine().JoinChannelWithUserAccount(
                        (string) AgoraUtil.GetData<string>(@params, "token"),
                        (string) AgoraUtil.GetData<string>(@params, "channelId"),
                        (string) AgoraUtil.GetData<string>(@params, "userAccount"));
                    break;
                case CApiTypeEngine.kEngineGetUserInfoByUserAccount:
                    AgoraRtcEngine.CreateRtcEngine().GetUserInfoByUserAccount(
                        (string) AgoraUtil.GetData<string>(@params, "userAccount"),
                        out var userInfo1);
                    Console.WriteLine(">>> \"GetUserInfoByUserAccount\" userInfo: {0}", JsonSerializer.Serialize(userInfo1));
                    break;
                case CApiTypeEngine.kEngineGetUserInfoByUid:
                    AgoraRtcEngine.CreateRtcEngine().GetUserInfoByUid(
                        (uint) AgoraUtil.GetData<uint>(@params, "uid"),
                        out var userInfo2);
                    Console.WriteLine(">>> \"GetUserInfoByUid\" userInfo: {0}", JsonSerializer.Serialize(userInfo2));
                    break;
                case CApiTypeEngine.kEngineStartEchoTest:
                    if (@params == "{}")
                    {
                        AgoraRtcEngine.CreateRtcEngine().StartEchoTest();
                    }
                    else
                    {
                        AgoraRtcEngine.CreateRtcEngine().StartEchoTest(
                            (int) AgoraUtil.GetData<int>(@params, "intervalInSeconds"));
                    }
                    break;
                case CApiTypeEngine.kEngineStopEchoTest:
                    AgoraRtcEngine.CreateRtcEngine().StopEchoTest();
                    break;
                case CApiTypeEngine.kEngineEnableVideo:
                    AgoraRtcEngine.CreateRtcEngine().EnableVideo();
                    break;
                case CApiTypeEngine.kEngineDisableVideo:
                    AgoraRtcEngine.CreateRtcEngine().DisableVideo();
                    break;
                case CApiTypeEngine.kEngineSetVideoProfile:
                    AgoraRtcEngine.CreateRtcEngine().SetVideoProfile(
                        (VIDEO_PROFILE_TYPE) AgoraUtil.GetData<int>(@params, "profile"),
                        (bool) AgoraUtil.GetData<bool>(@params, "swapWidthAndHeight"));
                    break;
                case CApiTypeEngine.kEngineSetVideoEncoderConfiguration:
                    AgoraRtcEngine.CreateRtcEngine().SetVideoEncoderConfiguration(
                        AgoraUtil.JsonToStruct<VideoEncoderConfiguration>(@params, "config"));
                    break;
                case CApiTypeEngine.kEngineSetCameraCapturerConfiguration:
                    AgoraRtcEngine.CreateRtcEngine().SetCameraCapturerConfiguration(
                        AgoraUtil.JsonToStruct<CameraCapturerConfiguration>(@params, "config"));
                    break;
                case CApiTypeEngine.kEngineSetupLocalVideo:
                    AgoraRtcEngine.CreateRtcEngine().SetupLocalVideo(
                        AgoraUtil.JsonToStruct<VideoCanvas>(@params, "canvas"));
                    break;
                case CApiTypeEngine.kEngineSetupRemoteVideo:
                    AgoraRtcEngine.CreateRtcEngine().SetupRemoteVideo(
                        AgoraUtil.JsonToStruct<VideoCanvas>(@params, "canvas"));
                    break;
                case CApiTypeEngine.kEngineStartPreview:
                    AgoraRtcEngine.CreateRtcEngine().StartPreview();
                    break;
                case CApiTypeEngine.kEngineSetRemoteUserPriority:
                    AgoraRtcEngine.CreateRtcEngine().SetRemoteUserPriority(
                        (uint) AgoraUtil.GetData<uint>(@params, "uid"),
                        (PRIORITY_TYPE) AgoraUtil.GetData<int>(@params, "userPriority"));
                    break;
                case CApiTypeEngine.kEngineStopPreview:
                    AgoraRtcEngine.CreateRtcEngine().StopPreview();
                    break;
                case CApiTypeEngine.kEngineEnableAudio:
                    AgoraRtcEngine.CreateRtcEngine().EnableAudio();
                    break;
                case CApiTypeEngine.kEngineEnableLocalAudio:
                    AgoraRtcEngine.CreateRtcEngine().EnableLocalAudio(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"));
                    break;
                case CApiTypeEngine.kEngineDisableAudio:
                    AgoraRtcEngine.CreateRtcEngine().DisableAudio();
                    break;
                case CApiTypeEngine.kEngineSetAudioProfile:
                    AgoraRtcEngine.CreateRtcEngine().SetAudioProfile(
                        (AUDIO_PROFILE_TYPE) AgoraUtil.GetData<int>(@params, "profile"),
                        (AUDIO_SCENARIO_TYPE) AgoraUtil.GetData<int>(@params, "scenario"));
                    break;
                case CApiTypeEngine.kEngineMuteLocalAudioStream:
                    AgoraRtcEngine.CreateRtcEngine().MuteLocalAudioStream(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeEngine.kEngineMuteAllRemoteAudioStreams:
                    AgoraRtcEngine.CreateRtcEngine().MuteAllRemoteAudioStreams(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeEngine.kEngineSetDefaultMuteAllRemoteAudioStreams:
                    AgoraRtcEngine.CreateRtcEngine().SetDefaultMuteAllRemoteAudioStreams(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeEngine.kEngineAdjustUserPlaybackSignalVolume:
                    AgoraRtcEngine.CreateRtcEngine().AdjustUserPlaybackSignalVolume(
                        (uint) AgoraUtil.GetData<uint>(@params, "uid"),
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineMuteRemoteAudioStream:
                    AgoraRtcEngine.CreateRtcEngine().MuteRemoteAudioStream(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeEngine.kEngineMuteLocalVideoStream:
                    AgoraRtcEngine.CreateRtcEngine().MuteLocalVideoStream(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeEngine.kEngineEnableLocalVideo:
                    AgoraRtcEngine.CreateRtcEngine().EnableLocalVideo(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"));
                    break;
                case CApiTypeEngine.kEngineMuteAllRemoteVideoStreams:
                    AgoraRtcEngine.CreateRtcEngine().MuteAllRemoteVideoStreams(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeEngine.kEngineSetDefaultMuteAllRemoteVideoStreams:
                    AgoraRtcEngine.CreateRtcEngine().SetDefaultMuteAllRemoteVideoStreams(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeEngine.kEngineMuteRemoteVideoStream:
                    AgoraRtcEngine.CreateRtcEngine().MuteRemoteVideoStream(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeEngine.kEngineSetRemoteVideoStreamType:
                    AgoraRtcEngine.CreateRtcEngine().SetRemoteVideoStreamType(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (REMOTE_VIDEO_STREAM_TYPE) AgoraUtil.GetData<int>(@params, "streamType"));
                    break;
                case CApiTypeEngine.kEngineSetRemoteDefaultVideoStreamType:
                    AgoraRtcEngine.CreateRtcEngine().SetRemoteDefaultVideoStreamType(
                        (REMOTE_VIDEO_STREAM_TYPE) AgoraUtil.GetData<int>(@params, "streamType"));
                    break;
                case CApiTypeEngine.kEngineEnableAudioVolumeIndication:
                    AgoraRtcEngine.CreateRtcEngine().EnableAudioVolumeIndication(
                        (int) AgoraUtil.GetData<int>(@params, "interval"),
                        (int) AgoraUtil.GetData<int>(@params, "smooth"),
                        (bool) AgoraUtil.GetData<bool>(@params, "report_vad"));
                    break;
                case CApiTypeEngine.kEngineStartAudioRecording:
                    AgoraRtcEngine.CreateRtcEngine().StartAudioRecording(
                        (string) AgoraUtil.GetData<string>(@params, "filePath"),
                        (int) AgoraUtil.GetData<int>(@params, "sampleRate"),
                        (AUDIO_RECORDING_QUALITY_TYPE) AgoraUtil.GetData<int>(@params, "quality"));
                    break;
                case CApiTypeEngine.kEngineStopAudioRecording:
                    AgoraRtcEngine.CreateRtcEngine().StopAudioRecording();
                    break;
                case CApiTypeEngine.kEngineStartAudioMixing:
                    AgoraRtcEngine.CreateRtcEngine().StartAudioMixing(
                        (string) AgoraUtil.GetData<string>(@params, "filePath"),
                        (bool) AgoraUtil.GetData<bool>(@params, "loopback"),
                        (bool) AgoraUtil.GetData<bool>(@params, "replace"),
                        (int) AgoraUtil.GetData<int>(@params, "cycle"));
                    break;
                case CApiTypeEngine.kEngineStopAudioMixing:
                    AgoraRtcEngine.CreateRtcEngine().StopAudioMixing();
                    break;
                case CApiTypeEngine.kEnginePauseAudioMixing:
                    AgoraRtcEngine.CreateRtcEngine().PauseAudioMixing();
                    break;
                case CApiTypeEngine.kEngineResumeAudioMixing:
                    AgoraRtcEngine.CreateRtcEngine().ResumeAudioMixing();
                    break;
                case CApiTypeEngine.kEngineSetHighQualityAudioParameters:
                    AgoraRtcEngine.CreateRtcEngine().SetHighQualityAudioParameters(
                        (bool) AgoraUtil.GetData<bool>(@params, "fullband"),
                        (bool) AgoraUtil.GetData<bool>(@params, "stereo"),
                        (bool) AgoraUtil.GetData<bool>(@params, "fullBitrate"));
                    break;
                case CApiTypeEngine.kEngineAdjustAudioMixingVolume:
                    AgoraRtcEngine.CreateRtcEngine().AdjustAudioMixingVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineAdjustAudioMixingPlayoutVolume:
                    AgoraRtcEngine.CreateRtcEngine().AdjustAudioMixingPlayoutVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineGetAudioMixingPlayoutVolume:
                    AgoraRtcEngine.CreateRtcEngine().GetAudioMixingPlayoutVolume(out var mixingPlayoutVolume);
                    Console.WriteLine(">>> \"GetAudioMixingPlayoutVolume\" mixingPlayoutVolume: {0}", mixingPlayoutVolume);
                    break;
                case CApiTypeEngine.kEngineAdjustAudioMixingPublishVolume:
                    AgoraRtcEngine.CreateRtcEngine().AdjustAudioMixingPublishVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineGetAudioMixingPublishVolume:
                    AgoraRtcEngine.CreateRtcEngine().GetAudioMixingPublishVolume(out var mixingPublishVolume);
                    Console.WriteLine(">>> \"GetAudioMixingPublishVolume\" mixingPublishVolume: {0}", mixingPublishVolume);
                    break;
                case CApiTypeEngine.kEngineGetAudioMixingDuration:
                    AgoraRtcEngine.CreateRtcEngine().GetAudioMixingDuration(out var mixingDuration);
                    Console.WriteLine(">>> \"GetAudioMixingDuration\" mixingDuration: {0}", mixingDuration);
                    break;
                case CApiTypeEngine.kEngineGetAudioMixingCurrentPosition:
                    AgoraRtcEngine.CreateRtcEngine().GetAudioMixingCurrentPosition(out var mixingCurrentPosition);
                    Console.WriteLine(">>> \"GetAudioMixingCurrentPosition\" mixingCurrentPosition: {0}", mixingCurrentPosition);
                    break;
                case CApiTypeEngine.kEngineSetAudioMixingPosition:
                    AgoraRtcEngine.CreateRtcEngine().SetAudioMixingPosition(
                        (int) AgoraUtil.GetData<int>(@params, "pos"));
                    break;
                case CApiTypeEngine.kEngineSetAudioMixingPitch:
                    AgoraRtcEngine.CreateRtcEngine().SetAudioMixingPitch(
                        (int) AgoraUtil.GetData<int>(@params, "pitch"));
                    break;
                case CApiTypeEngine.kEngineGetEffectsVolume:
                    AgoraRtcEngine.CreateRtcEngine().GetEffectsVolume(out var effectVolume);
                    Console.WriteLine(">>> \"GetEffectsVolume\" effectVolume: {0}", effectVolume);
                    break;
                case CApiTypeEngine.kEngineSetEffectsVolume:
                    AgoraRtcEngine.CreateRtcEngine().SetEffectsVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineSetVolumeOfEffect:
                    AgoraRtcEngine.CreateRtcEngine().SetVolumeOfEffect(
                        (int) AgoraUtil.GetData<int>(@params, "soundId"),
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineEnableFaceDetection:
                    break;
                case CApiTypeEngine.kEnginePlayEffect:
                    AgoraRtcEngine.CreateRtcEngine().PlayEffect(
                        (int) AgoraUtil.GetData<int>(@params, "soundId"),
                        (string) AgoraUtil.GetData<string>(@params, "filePath"),
                        (int) AgoraUtil.GetData<int>(@params, "loopCount"),
                        (double) AgoraUtil.GetData<double>(@params, "pitch"),
                        (double) AgoraUtil.GetData<double>(@params, "pan"),
                        (int) AgoraUtil.GetData<int>(@params, "gain"),
                        (bool) AgoraUtil.GetData<bool>(@params, "publish"));
                    break;
                case CApiTypeEngine.kEngineStopEffect:
                    AgoraRtcEngine.CreateRtcEngine().StopEffect(
                        (int) AgoraUtil.GetData<int>(@params, "soundId"));
                    break;
                case CApiTypeEngine.kEngineStopAllEffects:
                    AgoraRtcEngine.CreateRtcEngine().StopAllEffects();
                    break;
                case CApiTypeEngine.kEnginePreloadEffect:
                    AgoraRtcEngine.CreateRtcEngine().PreloadEffect(
                        (int) AgoraUtil.GetData<int>(@params, "soundId"),
                        (string) AgoraUtil.GetData<string>(@params, "filePath"));
                    break;
                case CApiTypeEngine.kEngineUnloadEffect:
                    AgoraRtcEngine.CreateRtcEngine().UnloadEffect(
                        (int) AgoraUtil.GetData<int>(@params, "soundId"));
                    break;
                case CApiTypeEngine.kEnginePauseEffect:
                    AgoraRtcEngine.CreateRtcEngine().PauseEffect(
                        (int) AgoraUtil.GetData<int>(@params, "soundId"));
                    break;
                case CApiTypeEngine.kEnginePauseAllEffects:
                    AgoraRtcEngine.CreateRtcEngine().PauseAllEffects();
                    break;
                case CApiTypeEngine.kEngineResumeEffect:
                    AgoraRtcEngine.CreateRtcEngine().ResumeEffect(
                        (int) AgoraUtil.GetData<int>(@params, "soundId"));
                    break;
                case CApiTypeEngine.kEngineResumeAllEffects:
                    AgoraRtcEngine.CreateRtcEngine().ResumeAllEffects();
                    break;
                case CApiTypeEngine.kEngineEnableSoundPositionIndication:
                    AgoraRtcEngine.CreateRtcEngine().EnableSoundPositionIndication(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"));
                    break;
                case CApiTypeEngine.kEngineSetRemoteVoicePosition:
                    AgoraRtcEngine.CreateRtcEngine().SetRemoteVoicePosition(
                        (uint) AgoraUtil.GetData<uint>(@params, "uid"),
                        (double) AgoraUtil.GetData<double>(@params, "pan"),
                        (double) AgoraUtil.GetData<double>(@params, "gain"));
                    break;
                case CApiTypeEngine.kEngineSetLocalVoicePitch:
                    AgoraRtcEngine.CreateRtcEngine().SetLocalVoicePitch(
                        (double) AgoraUtil.GetData<double>(@params, "pitch"));
                    break;
                case CApiTypeEngine.kEngineSetLocalVoiceEqualization:
                    AgoraRtcEngine.CreateRtcEngine().SetLocalVoiceEqualization(
                        (AUDIO_EQUALIZATION_BAND_FREQUENCY) AgoraUtil.GetData<int>(@params, "bandFrequency"),
                        (int) AgoraUtil.GetData<int>(@params, "bandGain"));
                    break;
                case CApiTypeEngine.kEngineSetLocalVoiceReverb:
                    AgoraRtcEngine.CreateRtcEngine().SetLocalVoiceReverb(
                        (AUDIO_REVERB_TYPE) AgoraUtil.GetData<int>(@params, "reverbKey"),
                        (int) AgoraUtil.GetData<int>(@params, "value"));
                    break;
                case CApiTypeEngine.kEngineSetLocalVoiceChanger:
                    AgoraRtcEngine.CreateRtcEngine().SetLocalVoiceChanger(
                        (VOICE_CHANGER_PRESET) AgoraUtil.GetData<int>(@params, "voiceChanger"));
                    break;
                case CApiTypeEngine.kEngineSetLocalVoiceReverbPreset:
                    AgoraRtcEngine.CreateRtcEngine().SetLocalVoiceReverbPreset(
                        (AUDIO_REVERB_PRESET) AgoraUtil.GetData<int>(@params, "reverbPreset"));
                    break;
                case CApiTypeEngine.kEngineSetVoiceBeautifierPreset:
                    AgoraRtcEngine.CreateRtcEngine().SetVoiceBeautifierPreset(
                        (VOICE_BEAUTIFIER_PRESET) AgoraUtil.GetData<int>(@params, "preset"));
                    break;
                case CApiTypeEngine.kEngineSetAudioEffectPreset:
                    AgoraRtcEngine.CreateRtcEngine().SetAudioEffectPreset(
                        (AUDIO_EFFECT_PRESET) AgoraUtil.GetData<int>(@params, "preset"));
                    break;
                case CApiTypeEngine.kEngineSetAudioEffectParameters:
                    AgoraRtcEngine.CreateRtcEngine().SetAudioEffectParameters(
                        (AUDIO_EFFECT_PRESET) AgoraUtil.GetData<int>(@params, "preset"),
                        (int) AgoraUtil.GetData<int>(@params, "param1"),
                        (int) AgoraUtil.GetData<int>(@params, "param2"));
                    break;
                case CApiTypeEngine.kEngineSetLogFile:
                    AgoraRtcEngine.CreateRtcEngine().SetLogFile(
                        (string) AgoraUtil.GetData<string>(@params, "filePath"));
                    break;
                case CApiTypeEngine.kEngineSetLogFilter:
                    AgoraRtcEngine.CreateRtcEngine().SetLogFilter(
                        (uint) AgoraUtil.GetData<uint>(@params, "filter"));
                    break;
                case CApiTypeEngine.kEngineSetLogFileSize:
                    AgoraRtcEngine.CreateRtcEngine().SetLogFileSize(
                        (uint) AgoraUtil.GetData<uint>(@params, "fileSizeInKBytes"));
                    break;
                case CApiTypeEngine.kEngineSetLocalRenderMode:
                    if (JsonDocument.Parse(@params).RootElement.TryGetProperty("mirrorMode", out _))
                    {
                        AgoraRtcEngine.CreateRtcEngine().SetLocalRenderMode(
                            (RENDER_MODE_TYPE) AgoraUtil.GetData<int>(@params, "renderMode"),
                            (VIDEO_MIRROR_MODE_TYPE) AgoraUtil.GetData<int>(@params, "mirrorMode"));
                    }
                    else
                    {
                        AgoraRtcEngine.CreateRtcEngine().SetLocalRenderMode(
                            (RENDER_MODE_TYPE) AgoraUtil.GetData<int>(@params, "renderMode"));
                    }
                    break;
                case CApiTypeEngine.kEngineSetRemoteRenderMode:
                    if (JsonDocument.Parse(@params).RootElement.TryGetProperty("mirrorMode", out _))
                    {
                        AgoraRtcEngine.CreateRtcEngine().SetRemoteRenderMode(
                            (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                            (RENDER_MODE_TYPE) AgoraUtil.GetData<int>(@params, "renderMode"),
                            (VIDEO_MIRROR_MODE_TYPE) AgoraUtil.GetData<int>(@params, "mirrorMode"));
                    }
                    else
                    {
                        AgoraRtcEngine.CreateRtcEngine().SetRemoteRenderMode(
                            (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                            (RENDER_MODE_TYPE) AgoraUtil.GetData<int>(@params, "renderMode"));
                    }
                    break;
                case CApiTypeEngine.kEngineSetLocalVideoMirrorMode:
                    AgoraRtcEngine.CreateRtcEngine().SetLocalVideoMirrorMode(
                        (VIDEO_MIRROR_MODE_TYPE) AgoraUtil.GetData<int>(@params, "mirrorMode"));
                    break;
                case CApiTypeEngine.kEngineEnableDualStreamMode:
                    AgoraRtcEngine.CreateRtcEngine().EnableDualStreamMode(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"));
                    break;
                case CApiTypeEngine.kEngineSetExternalAudioSource:
                    AgoraRtcEngine.CreateRtcEngine().SetExternalAudioSource(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"),
                        (int) AgoraUtil.GetData<int>(@params, "sampleRate"), 
                        (int) AgoraUtil.GetData<int>(@params, "channels"));
                    break;
                case CApiTypeEngine.kEngineSetExternalAudioSink:
                    AgoraRtcEngine.CreateRtcEngine().SetExternalAudioSink(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"),
                        (int) AgoraUtil.GetData<int>(@params, "sampleRate"),
                        (int) AgoraUtil.GetData<int>(@params, "channels"));
                    break;
                case CApiTypeEngine.kEngineSetRecordingAudioFrameParameters:
                    AgoraRtcEngine.CreateRtcEngine().SetRecordingAudioFrameParameters(
                        (int) AgoraUtil.GetData<int>(@params, "sampleRate"),
                        (int) AgoraUtil.GetData<int>(@params, "channel"),
                        (RAW_AUDIO_FRAME_OP_MODE_TYPE) AgoraUtil.GetData<int>(@params, "mode"),
                        (int) AgoraUtil.GetData<int>(@params, "samplesPerCall"));
                    break;
                case CApiTypeEngine.kEngineSetPlaybackAudioFrameParameters:
                    AgoraRtcEngine.CreateRtcEngine().SetPlaybackAudioFrameParameters(
                        (int) AgoraUtil.GetData<int>(@params, "sampleRate"),
                        (int) AgoraUtil.GetData<int>(@params, "channel"),
                        (RAW_AUDIO_FRAME_OP_MODE_TYPE) AgoraUtil.GetData<int>(@params, "mode"),
                        (int) AgoraUtil.GetData<int>(@params, "samplesPerCall"));
                    break;
                case CApiTypeEngine.kEngineSetMixedAudioFrameParameters:
                    AgoraRtcEngine.CreateRtcEngine().SetMixedAudioFrameParameters(
                        (int) AgoraUtil.GetData<int>(@params, "sampleRate"),
                        (int) AgoraUtil.GetData<int>(@params, "samplesPerCall"));
                    break;
                case CApiTypeEngine.kEngineAdjustRecordingSignalVolume:
                    AgoraRtcEngine.CreateRtcEngine().AdjustRecordingSignalVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineAdjustPlaybackSignalVolume:
                    AgoraRtcEngine.CreateRtcEngine().AdjustPlaybackSignalVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineEnableWebSdkInteroperability:
                    AgoraRtcEngine.CreateRtcEngine().EnableWebSdkInteroperability(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"));
                    break;
                case CApiTypeEngine.kEngineSetVideoQualityParameters:
                    AgoraRtcEngine.CreateRtcEngine().SetVideoQualityParameters(
                        (bool) AgoraUtil.GetData<bool>(@params, "preferFrameRateOverImageQuality"));
                    break;
                case CApiTypeEngine.kEngineSetLocalPublishFallbackOption:
                    AgoraRtcEngine.CreateRtcEngine().SetLocalPublishFallbackOption(
                        (STREAM_FALLBACK_OPTIONS) AgoraUtil.GetData<int>(@params, "option"));
                    break;
                case CApiTypeEngine.kEngineSetRemoteSubscribeFallbackOption:
                    AgoraRtcEngine.CreateRtcEngine().SetRemoteSubscribeFallbackOption(
                        (STREAM_FALLBACK_OPTIONS) AgoraUtil.GetData<int>(@params, "option"));
                    break;
                case CApiTypeEngine.kEngineSwitchCamera:
                    break;
                case CApiTypeEngine.kEngineSetDefaultAudioRouteSpeakerPhone:
                    break;
                case CApiTypeEngine.kEngineSetEnableSpeakerPhone:
                    break;
                case CApiTypeEngine.kEngineEnableInEarMonitoring:
                    break;
                case CApiTypeEngine.kEngineSetInEarMonitoringVolume:
                    break;
                case CApiTypeEngine.kEngineIsSpeakerPhoneEnabled:
                    break;
                case CApiTypeEngine.kEngineSetAudioSessionOperationRestriction:
                    break;
                case CApiTypeEngine.kEngineEnableLoopBackRecording:
                    AgoraRtcEngine.CreateRtcEngine().EnableLoopbackRecording(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"),
                        (string) AgoraUtil.GetData<string>(@params, "deviceName"));
                    break;
                case CApiTypeEngine.kEngineStartScreenCaptureByDisplayId:
                    break;
                case CApiTypeEngine.kEngineStartScreenCaptureByScreenRect:
                    AgoraRtcEngine.CreateRtcEngine().StartScreenCaptureByScreenRect(
                        AgoraUtil.JsonToStruct<Rectangle>(@params, "screenRect"),
                        AgoraUtil.JsonToStruct<Rectangle>(@params, "regionRect"),
                        AgoraUtil.JsonToStruct<ScreenCaptureParameters>(@params, "captureParams"));
                    break;
                case CApiTypeEngine.kEngineStartScreenCaptureByWindowId:
                    AgoraRtcEngine.CreateRtcEngine().StartScreenCaptureByWindowId(
                        (ulong) AgoraUtil.GetData<ulong>(@params, "windowId"),
                        AgoraUtil.JsonToStruct<Rectangle>(@params, "regionRect"),
                        AgoraUtil.JsonToStruct<ScreenCaptureParameters>(@params, "captureParams"));
                    break;
                case CApiTypeEngine.kEngineSetScreenCaptureContentHint:
                    AgoraRtcEngine.CreateRtcEngine().SetScreenCaptureContentHint(
                        (VideoContentHint) AgoraUtil.GetData<int>(@params, "contentHint"));
                    break;
                case CApiTypeEngine.kEngineUpdateScreenCaptureParameters:
                    AgoraRtcEngine.CreateRtcEngine().UpdateScreenCaptureParameters(
                        AgoraUtil.JsonToStruct<ScreenCaptureParameters>(@params, "captureParams"));
                    break;
                case CApiTypeEngine.kEngineUpdateScreenCaptureRegion:
                    AgoraRtcEngine.CreateRtcEngine().UpdateScreenCaptureRegion(
                        AgoraUtil.JsonToStruct<Rectangle>(@params, "regionRect"));
                    break;
                case CApiTypeEngine.kEngineStopScreenCapture:
                    AgoraRtcEngine.CreateRtcEngine().StopScreenCapture();
                    break;
                case CApiTypeEngine.kEngineStartScreenCapture:
                    break;
                case CApiTypeEngine.kEngineGetCallId:
                    AgoraRtcEngine.CreateRtcEngine().GetCallId();
                    break;
                case CApiTypeEngine.kEngineRate:
                    AgoraRtcEngine.CreateRtcEngine().Rate(
                        (string) AgoraUtil.GetData<string>(@params, "callId"),
                        (int) AgoraUtil.GetData<int>(@params, "rating"),
                        (string) AgoraUtil.GetData<string>(@params, "description"));
                    break;
                case CApiTypeEngine.kEngineComplain:
                    AgoraRtcEngine.CreateRtcEngine().Complain(
                        (string) AgoraUtil.GetData<string>(@params, "callId"),
                        (string) AgoraUtil.GetData<string>(@params, "description"));
                    break;
                case CApiTypeEngine.kEngineGetVersion:
                    AgoraRtcEngine.CreateRtcEngine().GetVersion();
                    break;
                case CApiTypeEngine.kEngineEnableLastMileTest:
                    AgoraRtcEngine.CreateRtcEngine().EnableLastmileTest();
                    break;
                case CApiTypeEngine.kEngineDisableLastMileTest:
                    AgoraRtcEngine.CreateRtcEngine().DisableLastmileTest();
                    break;
                case CApiTypeEngine.kEngineStartLastMileProbeTest:
                    AgoraRtcEngine.CreateRtcEngine().StartLastmileProbeTest(
                        AgoraUtil.JsonToStruct<LastmileProbeConfig>(@params, "config"));
                    break;
                case CApiTypeEngine.kEngineStopLastMileProbeTest:
                    AgoraRtcEngine.CreateRtcEngine().StopLastmileProbeTest();
                    break;
                case CApiTypeEngine.kEngineGetErrorDescription:
                    AgoraRtcEngine.CreateRtcEngine().GetErrorDescription(
                        (int) AgoraUtil.GetData<int>(@params, "code"));
                    break;
                case CApiTypeEngine.kEngineSetEncryptionSecret:
                    AgoraRtcEngine.CreateRtcEngine().SetEncryptionSecret(
                        (string) AgoraUtil.GetData<string>(@params, "secret"));
                    break;
                case CApiTypeEngine.kEngineSetEncryptionMode:
                    AgoraRtcEngine.CreateRtcEngine().SetEncryptionMode(
                        (string) AgoraUtil.GetData<string>(@params, "encryptionMode"));
                    break;
                case CApiTypeEngine.kEngineEnableEncryption:
                    AgoraRtcEngine.CreateRtcEngine().EnableEncryption(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"),
                        AgoraUtil.JsonToStruct<EncryptionConfig>(@params, "config"));
                    break;
                case CApiTypeEngine.kEngineRegisterPacketObserver:
                    break;
                case CApiTypeEngine.kEngineCreateDataStream:
                    AgoraRtcEngine.CreateRtcEngine().CreateDataStream(
                        out var streamId,
                        (bool) AgoraUtil.GetData<bool>(@params, "reliable"),
                        (bool) AgoraUtil.GetData<bool>(@params, "ordered"));
                    Console.WriteLine(">>> \"CreateDataStream\" streamId: {0}", streamId);
                    break;
                case CApiTypeEngine.kEngineSendStreamMessage:
                    AgoraRtcEngine.CreateRtcEngine().SendStreamMessage(
                        (int) AgoraUtil.GetData<int>(@params, "streamId"),
                        Encoding.ASCII.GetBytes("abc"));
                    break;
                case CApiTypeEngine.kEngineAddPublishStreamUrl:
                    AgoraRtcEngine.CreateRtcEngine().AddPublishStreamUrl(
                        (string) AgoraUtil.GetData<string>(@params, "url"),
                        (bool) AgoraUtil.GetData<bool>(@params, "transcodingEnabled"));
                    break;
                case CApiTypeEngine.kEngineRemovePublishStreamUrl:
                    AgoraRtcEngine.CreateRtcEngine().RemovePublishStreamUrl(
                        (string) AgoraUtil.GetData<string>(@params, "url"));
                    break;
                case CApiTypeEngine.kEngineSetLiveTranscoding:
                    AgoraRtcEngine.CreateRtcEngine().SetLiveTranscoding(
                        AgoraUtil.JsonToStruct<LiveTranscoding>(@params, "transcoding"));
                    break;
                case CApiTypeEngine.kEngineAddVideoWaterMark:
                    if (JsonDocument.Parse(@params).RootElement.TryGetProperty("options", out _))
                    {
                        AgoraRtcEngine.CreateRtcEngine().AddVideoWatermark(
                            (string) AgoraUtil.GetData<string>(@params, "watermarkUrl"),
                            AgoraUtil.JsonToStruct<WatermarkOptions>(@params, "options"));
                    }
                    else
                    {
                        AgoraRtcEngine.CreateRtcEngine().AddVideoWatermark(
                            AgoraUtil.JsonToStruct<RtcImage>(@params, "watermark"));
                    }
                    break;
                case CApiTypeEngine.kEngineClearVideoWaterMarks:
                    AgoraRtcEngine.CreateRtcEngine().ClearVideoWatermarks();
                    break;
                case CApiTypeEngine.kEngineSetBeautyEffectOptions:
                    AgoraRtcEngine.CreateRtcEngine().SetBeautyEffectOptions(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"),
                        AgoraUtil.JsonToStruct<BeautyOptions>(@params, "options"));
                    break;
                case CApiTypeEngine.kEngineAddInjectStreamUrl:
                    AgoraRtcEngine.CreateRtcEngine().AddInjectStreamUrl(
                        (string) AgoraUtil.GetData<string>(@params, "url"),
                        AgoraUtil.JsonToStruct<InjectStreamConfig>(@params, "config"));
                    break;
                case CApiTypeEngine.kEngineStartChannelMediaRelay:
                    AgoraRtcEngine.CreateRtcEngine().StartChannelMediaRelay(
                        AgoraUtil.JsonToStruct<ChannelMediaRelayConfiguration>(@params, "configuration"));
                    break;
                case CApiTypeEngine.kEngineUpdateChannelMediaRelay:
                    AgoraRtcEngine.CreateRtcEngine().UpdateChannelMediaRelay(
                        AgoraUtil.JsonToStruct<ChannelMediaRelayConfiguration>(@params, "configuration"));
                    break;
                case CApiTypeEngine.kEngineStopChannelMediaRelay:
                    AgoraRtcEngine.CreateRtcEngine().StopChannelMediaRelay();
                    break;
                case CApiTypeEngine.kEngineRemoveInjectStreamUrl:
                    AgoraRtcEngine.CreateRtcEngine().RemoveInjectStreamUrl(
                        (string) AgoraUtil.GetData<string>(@params, "url"));
                    break;
                case CApiTypeEngine.kEngineSendCustomReportMessage:
                    AgoraRtcEngine.CreateRtcEngine().SendCustomReportMessage(
                        (string) AgoraUtil.GetData<string>(@params, "id"),
                        (string) AgoraUtil.GetData<string>(@params, "category"),
                        (string) AgoraUtil.GetData<string>(@params, "event"),
                        (string) AgoraUtil.GetData<string>(@params, "label"),
                        (int) AgoraUtil.GetData<int>(@params, "value"));
                    break;
                case CApiTypeEngine.kEngineGetConnectionState:
                    AgoraRtcEngine.CreateRtcEngine().GetConnectionState();
                    break;
                case CApiTypeEngine.kEngineEnableRemoteSuperResolution:
                    AgoraRtcEngine.CreateRtcEngine().EnableRemoteSuperResolution(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (bool) AgoraUtil.GetData<bool>(@params, "enable"));
                    break;
                case CApiTypeEngine.kEngineRegisterMediaMetadataObserver:
                    AgoraRtcEngine.CreateRtcEngine().RegisterMediaMetadataObserver(
                        (METADATA_TYPE) AgoraUtil.GetData<int>(@params, "type"));
                    break;
                case CApiTypeEngine.kEngineUnRegisterMediaMetadataObserver:
                    AgoraRtcEngine.CreateRtcEngine().UnRegisterMediaMetadataObserver(
                        (METADATA_TYPE) AgoraUtil.GetData<int>(@params, "type"));
                    break;
                case CApiTypeEngine.kEngineSetMaxMetadataSize:
                    AgoraRtcEngine.CreateRtcEngine().SetMaxMetadataSize(
                        (int) AgoraUtil.GetData<int>(@params, "size"));
                    break;
                case CApiTypeEngine.kEngineSendMetadata:
                    var metadataJson = (string) AgoraUtil.GetData<object>(@params, "metadata");
                    var metadata = new Metadata();
                    metadata.uid = (uint) AgoraUtil.GetData<uint>(metadataJson, "uid");
                    metadata.size = (uint) AgoraUtil.GetData<uint>(metadataJson, "size");
                    metadata.timeStampMs = (long) AgoraUtil.GetData<long>(metadataJson, "timeStampMs");
                    metadata.buffer = Encoding.ASCII.GetBytes("abc");
                    AgoraRtcEngine.CreateRtcEngine().SendMetadata(metadata);
                    break;
                case CApiTypeEngine.kEngineSetParameters:
                    AgoraRtcEngine.CreateRtcEngine().SetParameters(
                        (string) AgoraUtil.GetData<string>(@params, "parameters"));
                    break;
                case CApiTypeEngine.kEngineSetPlaybackDeviceVolume:
                    AgoraRtcEngine.CreateRtcEngine().SetPlaybackDeviceVolume(
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeEngine.kEngineSetAppType:
                    break;
                case CApiTypeEngine.kMediaPushAudioFrame:
                    var frameJson = (string) AgoraUtil.GetData<object>(@params, "frame");
                    var frame = new AudioFrame();
                    frame.samplesPerSec = (int) AgoraUtil.GetData<int>(frameJson, "samplesPerSec");
                    frame.renderTimeMs = (long) AgoraUtil.GetData<long>(frameJson, "renderTimeMs");
                    frame.bytesPerSample = (int) AgoraUtil.GetData<int>(frameJson, "bytesPerSample");
                    frame.type = (AUDIO_FRAME_TYPE) AgoraUtil.GetData<int>(frameJson, "type");
                    frame.samples = (int) AgoraUtil.GetData<int>(frameJson, "samples");
                    frame.channels = (int) AgoraUtil.GetData<int>(frameJson, "channels");
                    frame.buffer = Encoding.ASCII.GetBytes("");
                    frame.avsync_type = (int) AgoraUtil.GetData<int>(frameJson, "avsync_type");
                    if (JsonDocument.Parse(@params).RootElement.TryGetProperty("type", out _))
                    {
                        AgoraRtcEngine.CreateRtcEngine().PushAudioFrame(
                            (MEDIA_SOURCE_TYPE) AgoraUtil.GetData<int>(@params, "type"),
                            frame,
                            (bool) AgoraUtil.GetData<bool>(@params, "wrap"));
                    }
                    else
                    {
                        AgoraRtcEngine.CreateRtcEngine().PushAudioFrame(frame);
                    }
                    break;
                case CApiTypeEngine.kMediaPullAudioFrame:
                    var audioFrame = new AudioFrame();
                    AgoraRtcEngine.CreateRtcEngine().PullAudioFrame(ref audioFrame);
                    Console.WriteLine(">>> \"PullAudioFrame\" audioFrame: {0}", JsonSerializer.Serialize(audioFrame));
                    break;
                case CApiTypeEngine.kMediaSetExternalVideoSource:
                    AgoraRtcEngine.CreateRtcEngine().SetExternalVideoSource(
                        (bool) AgoraUtil.GetData<bool>(@params, "enable"),
                        (bool) AgoraUtil.GetData<bool>(@params, "useTexture"));
                    break;
                case CApiTypeEngine.kMediaPushVideoFrame:
                    var videoFrameJson = (string) AgoraUtil.GetData<object>(@params, "frame");
                    var videoFrame = new ExternalVideoFrame();
                    videoFrame.cropTop = (int) AgoraUtil.GetData<int>(videoFrameJson, "cropTop");
                    videoFrame.cropBottom = (int) AgoraUtil.GetData<int>(videoFrameJson, "cropBottom");
                    videoFrame.cropLeft = (int) AgoraUtil.GetData<int>(videoFrameJson, "cropLeft");
                    videoFrame.cropRight = (int) AgoraUtil.GetData<int>(videoFrameJson, "cropRight");
                    videoFrame.type = (VIDEO_BUFFER_TYPE) AgoraUtil.GetData<int>(videoFrameJson, "type");
                    videoFrame.timestamp = (long) AgoraUtil.GetData<long>(videoFrameJson, "timestamp");
                    videoFrame.stride = (int) AgoraUtil.GetData<int>(videoFrameJson, "stride");
                    videoFrame.rotation = (int) AgoraUtil.GetData<int>(videoFrameJson, "rotation");
                    videoFrame.height = (int) AgoraUtil.GetData<int>(videoFrameJson, "height");
                    videoFrame.format = (VIDEO_PIXEL_FORMAT) AgoraUtil.GetData<int>(videoFrameJson, "format");
                    videoFrame.buffer = Encoding.ASCII.GetBytes("abc");
                    AgoraRtcEngine.CreateRtcEngine().PushVideoFrame(videoFrame);
                    break;
                case CApiTypeEngine.kEngineRelease:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}