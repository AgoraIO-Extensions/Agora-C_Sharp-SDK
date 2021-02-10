using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace agorartc
{
    using uid_t = UInt32;
    using view_t = IntPtr;
    using IrisEnginePtr = IntPtr;
    
    using IrisDeviceManagerPtr = IntPtr;

    internal static class NativeRtcEngineEventHandler
    {
        internal static AgoraRtcEngine Rtc;

        internal static void OnEvent(string @event, string data)
        {
            switch (@event)
            {
                case "onWarning":
                    Rtc.engineEventHandler?.OnWarning((int) AgoraUtil.GetData<int>(data, "warn"),
                        (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onError":
                    Rtc.engineEventHandler?.OnError((int) AgoraUtil.GetData<int>(data, "err"),
                        (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onJoinChannelSuccess":
                    Rtc.engineEventHandler?.OnJoinChannelSuccess((string) AgoraUtil.GetData<string>(data, "channel"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onRejoinChannelSuccess":
                    Rtc.engineEventHandler?.OnReJoinChannelSuccess((string) AgoraUtil.GetData<string>(data, "channel"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onLeaveChannel":
                    Rtc.engineEventHandler?.OnLeaveChannel(AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onClientRoleChanged":
                    Rtc.engineEventHandler?.OnClientRoleChanged(
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "oldRole"),
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "newRole"));
                    break;
                case "onUserJoined":
                    Rtc.engineEventHandler?.OnUserJoined((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserOffline":
                    Rtc.engineEventHandler?.OnUserOffline((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (USER_OFFLINE_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onLastmileQuality":
                    Rtc.engineEventHandler?.OnLastmileQuality((int) AgoraUtil.GetData<int>(data, "quality"));
                    break;
                case "onLastmileProbeResult":
                    Rtc.engineEventHandler?.OnLastmileProbeResult(
                        AgoraUtil.JsonToStruct<LastmileProbeResult>(data, "result"));
                    break;
                case "onConnectionInterrupted":
                    Rtc.engineEventHandler?.OnConnectionInterrupted();
                    break;
                case "onConnectionLost":
                    Rtc.engineEventHandler?.OnConnectionLost();
                    break;
                case "onConnectionBanned":
                    Rtc.engineEventHandler?.OnConnectionBanned();
                    break;
                case "onApiCallExecuted":
                    Rtc.engineEventHandler?.OnApiCallExecuted((ERROR_CODE) AgoraUtil.GetData<int>(data, "err"),
                        (string) AgoraUtil.GetData<string>(data, "api"),
                        (string) AgoraUtil.GetData<string>(data, "result"));
                    break;
                case "onRequestToken":
                    Rtc.engineEventHandler?.OnRequestToken();
                    break;
                case "onTokenPrivilegeWillExpire":
                    Rtc.engineEventHandler?.OnTokenPrivilegeWillExpire(
                        (string) AgoraUtil.GetData<string>(data, "token"));
                    break;
                case "onAudioQuality":
                    Rtc.engineEventHandler?.OnAudioQuality((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "quality"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "delay"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "lost"));
                    break;
                case "onRtcStats":
                    Rtc.engineEventHandler?.OnRtcStats(AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onNetworkQuality":
                    Rtc.engineEventHandler?.OnNetworkQuality((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "txQuality"),
                        (int) AgoraUtil.GetData<int>(data, "rxQuality"));
                    break;
                case "onLocalVideoStats":
                    Rtc.engineEventHandler?.OnLocalVideoStats(AgoraUtil.JsonToStruct<LocalVideoStats>(data, "stats"));
                    break;
                case "onRemoteVideoStats":
                    Rtc.engineEventHandler?.OnRemoteVideoStats(AgoraUtil.JsonToStruct<RemoteVideoStats>(data, "stats"));
                    break;
                case "onLocalAudioStats":
                    Rtc.engineEventHandler?.OnLocalAudioStats(AgoraUtil.JsonToStruct<LocalAudioStats>(data, "stats"));
                    break;
                case "onRemoteAudioStats":
                    Rtc.engineEventHandler?.OnRemoteAudioStats(AgoraUtil.JsonToStruct<RemoteAudioStats>(data, "stats"));
                    break;
                case "onLocalAudioStateChanged":
                    Rtc.engineEventHandler?.OnLocalAudioStateChanged(
                        (LOCAL_AUDIO_STREAM_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (LOCAL_AUDIO_STREAM_ERROR) AgoraUtil.GetData<int>(data, "error"));
                    break;
                case "onRemoteAudioStateChanged":
                    Rtc.engineEventHandler?.OnRemoteAudioStateChanged((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_AUDIO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_AUDIO_STATE_REASON) AgoraUtil.GetData<int>(data, "error"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onVideoPublishStateChanged":
                    Rtc.engineEventHandler?.OnVideoPublishStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "channel"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onAudioSubscribeStateChanged":
                    Rtc.engineEventHandler?.OnAudioSubscribeStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "channel"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoSubscribeStateChanged":
                    Rtc.engineEventHandler?.OnVideoSubscribeStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "channel"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onAudioVolumeIndication":
                    var speakerNumber = (uint) AgoraUtil.GetData<uint>(data, "speakerNumber");
                    var speakers = AgoraUtil.JsonToStructArray<AudioVolumeInfo>(data, "speakers", speakerNumber);
                    var totalVolume = (int) AgoraUtil.GetData<int>(data, "totalVolume");
                    Rtc.engineEventHandler?.OnAudioVolumeIndication(speakers, speakerNumber, totalVolume);
                    break;
                case "onActiveSpeaker":
                    Rtc.engineEventHandler?.OnActiveSpeaker((uint) AgoraUtil.GetData<uint>(data, "uid"));
                    break;
                case "onVideoStopped":
                    Rtc.engineEventHandler?.OnVideoStopped();
                    break;
                case "onFirstLocalVideoFrame":
                    Rtc.engineEventHandler?.OnFirstLocalVideoFrame((int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstLocalVideoFramePublished":
                    Rtc.engineEventHandler?.OnFirstLocalVideoFramePublished(
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstRemoteVideoDecoded":
                    Rtc.engineEventHandler?.OnFirstRemoteVideoDecoded((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "width"), (int) AgoraUtil.GetData<int>(data, "height"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstRemoteVideoFrame":
                    Rtc.engineEventHandler?.OnFirstRemoteVideoFrame((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "width"), (int) AgoraUtil.GetData<int>(data, "height"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserMuteAudio":
                    Rtc.engineEventHandler?.OnUserMuteAudio((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "muted"));
                    break;
                case "onUserMuteVideo":
                    Rtc.engineEventHandler?.OnUserMuteVideo((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "muted"));
                    break;
                case "onUserEnableVideo":
                    Rtc.engineEventHandler?.OnUserEnableVideo((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "enabled"));
                    break;
                case "onAudioDeviceStateChanged":
                    Rtc.engineEventHandler?.OnAudioDeviceStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "deviceId"),
                        (MEDIA_DEVICE_TYPE) AgoraUtil.GetData<int>(data, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE) AgoraUtil.GetData<int>(data, "deviceState"));
                    break;
                case "onAudioDeviceVolumeChanged":
                    Rtc.engineEventHandler?.OnAudioDeviceVolumeChanged(
                        (MEDIA_DEVICE_TYPE) AgoraUtil.GetData<int>(data, "deviceType"),
                        (int) AgoraUtil.GetData<int>(data, "volume"),
                        (bool) AgoraUtil.GetData<bool>(data, "muted"));
                    break;
                case "onCameraReady":
                    Rtc.engineEventHandler?.OnCameraReady();
                    break;
                case "onCameraFocusAreaChanged":
                    Rtc.engineEventHandler?.OnCameraFocusAreaChanged((int) AgoraUtil.GetData<int>(data, "x"),
                        (int) AgoraUtil.GetData<int>(data, "y"), (int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"));
                    break;
                case "onCameraExposureAreaChanged":
                    Rtc.engineEventHandler?.OnCameraExposureAreaChanged((int) AgoraUtil.GetData<int>(data, "x"),
                        (int) AgoraUtil.GetData<int>(data, "y"), (int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"));
                    break;
                case "onAudioMixingFinished":
                    Rtc.engineEventHandler?.OnAudioMixingFinished();
                    break;
                case "onAudioMixingStateChanged":
                    Rtc.engineEventHandler?.OnAudioMixingStateChanged(
                        (AUDIO_MIXING_STATE_TYPE) AgoraUtil.GetData<int>(data, "state"),
                        (AUDIO_MIXING_ERROR_TYPE) AgoraUtil.GetData<int>(data, "errorCode"));
                    break;
                case "onRemoteAudioMixingBegin":
                    Rtc.engineEventHandler?.OnRemoteAudioMixingBegin();
                    break;
                case "onRemoteAudioMixingEnd":
                    Rtc.engineEventHandler?.OnRemoteAudioMixingEnd();
                    break;
                case "onAudioEffectFinished":
                    Rtc.engineEventHandler?.OnAudioEffectFinished((int) AgoraUtil.GetData<int>(data, "soundId"));
                    break;
                case "onFirstRemoteAudioDecoded":
                    Rtc.engineEventHandler?.OnFirstRemoteAudioDecoded((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onVideoDeviceStateChanged":
                    Rtc.engineEventHandler?.OnVideoDeviceStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "deviceId"),
                        (MEDIA_DEVICE_TYPE) AgoraUtil.GetData<int>(data, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE) AgoraUtil.GetData<int>(data, "deviceState"));
                    break;
                case "onLocalVideoStateChanged":
                    Rtc.engineEventHandler?.OnLocalVideoStateChanged(
                        (LOCAL_VIDEO_STREAM_STATE) AgoraUtil.GetData<int>(data, "localVideoState"),
                        (LOCAL_VIDEO_STREAM_ERROR) AgoraUtil.GetData<int>(data, "error"));
                    break;
                case "onVideoSizeChanged":
                    Rtc.engineEventHandler?.OnVideoSizeChanged((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "width"), (int) AgoraUtil.GetData<int>(data, "height"),
                        (int) AgoraUtil.GetData<int>(data, "rotation"));
                    break;
                case "onRemoteVideoStateChanged":
                    Rtc.engineEventHandler?.OnRemoteVideoStateChanged((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_VIDEO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_VIDEO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserEnableLocalVideo":
                    Rtc.engineEventHandler?.OnUserEnableLocalVideo((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "enabled"));
                    break;
                case "onStreamMessageError":
                    Rtc.engineEventHandler?.OnStreamMessageError((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "streamId"), (int) AgoraUtil.GetData<int>(data, "code"),
                        (int) AgoraUtil.GetData<int>(data, "missed"), (int) AgoraUtil.GetData<int>(data, "cached"));
                    break;
                case "onMediaEngineLoadSuccess":
                    Rtc.engineEventHandler?.OnMediaEngineLoadSuccess();
                    break;
                case "onMediaEngineStartCallSuccess":
                    Rtc.engineEventHandler?.OnMediaEngineStartCallSuccess();
                    break;
                case "onUserSuperResolutionEnabled":
                    Rtc.engineEventHandler?.onUserSuperResolutionEnabled((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "enabled"),
                        (SUPER_RESOLUTION_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onChannelMediaRelayStateChanged":
                    Rtc.engineEventHandler?.OnChannelMediaRelayStateChanged(
                        (CHANNEL_MEDIA_RELAY_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (CHANNEL_MEDIA_RELAY_ERROR) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onChannelMediaRelayEvent":
                    Rtc.engineEventHandler?.OnChannelMediaRelayEvent(
                        (CHANNEL_MEDIA_RELAY_EVENT) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onFirstLocalAudioFrame":
                    Rtc.engineEventHandler?.OnFirstLocalAudioFrame((int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstLocalAudioFramePublished":
                    Rtc.engineEventHandler?.OnFirstLocalAudioFramePublished(
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstRemoteAudioFrame":
                    Rtc.engineEventHandler?.OnFirstRemoteAudioFrame((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onRtmpStreamingStateChanged":
                    Rtc.engineEventHandler?.OnRtmpStreamingStateChanged((string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (RTMP_STREAM_PUBLISH_ERROR) AgoraUtil.GetData<int>(data, "errCode"));
                    break;
                case "onRtmpStreamingEvent":
                    Rtc.engineEventHandler?.OnRtmpStreamingEvent((string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAMING_EVENT) AgoraUtil.GetData<int>(data, "eventCode"));
                    break;
                case "onStreamPublished":
                    Rtc.engineEventHandler?.OnStreamPublished((string) AgoraUtil.GetData<string>(data, "url"),
                        (ERROR_CODE) AgoraUtil.GetData<int>(data, "error"));
                    break;
                case "onStreamUnpublished":
                    Rtc.engineEventHandler?.OnStreamUnpublished((string) AgoraUtil.GetData<string>(data, "url"));
                    break;
                case "onTranscodingUpdated":
                    Rtc.engineEventHandler?.OnTranscodingUpdated();
                    break;
                case "onStreamInjectedStatus":
                    Rtc.engineEventHandler?.OnStreamInjectedStatus((string) AgoraUtil.GetData<string>(data, "url"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "status"));
                    break;
                case "onAudioRouteChanged":
                    Rtc.engineEventHandler?.OnAudioRouteChanged(
                        (AUDIO_ROUTE_TYPE) AgoraUtil.GetData<int>(data, "routing"));
                    break;
                case "onLocalPublishFallbackToAudioOnly":
                    Rtc.engineEventHandler?.OnLocalPublishFallbackToAudioOnly(
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
                    Rtc.engineEventHandler?.OnRemoteSubscribeFallbackToAudioOnly(
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onRemoteAudioTransportStats":
                    Rtc.engineEventHandler?.OnRemoteAudioTransportStats(
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "delay"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "lost"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "rxKBitRate"));
                    break;
                case "onRemoteVideoTransportStats":
                    Rtc.engineEventHandler?.OnRemoteAudioTransportStats(
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "delay"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "lost"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "rxKBitRate"));
                    break;
                case "onMicrophoneEnabled":
                    Rtc.engineEventHandler?.OnMicrophoneEnabled((bool) AgoraUtil.GetData<bool>(data, "enabled"));
                    break;
                case "onConnectionStateChanged":
                    Rtc.engineEventHandler?.OnConnectionStateChanged(
                        (CONNECTION_STATE_TYPE) AgoraUtil.GetData<int>(data, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onNetworkTypeChanged":
                    Rtc.engineEventHandler?.OnNetworkTypeChanged((NETWORK_TYPE) AgoraUtil.GetData<int>(data, "type"));
                    break;
                case "onLocalUserRegistered":
                    Rtc.engineEventHandler?.OnLocalUserRegistered((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (string) AgoraUtil.GetData<string>(data, "userAccount"));
                    break;
                case "onUserInfoUpdated":
                    Rtc.engineEventHandler?.OnUserInfoUpdated((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        AgoraUtil.JsonToStruct<UserInfo>(data, "info"));
                    break;
            }
        }

        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer)
        {
            switch (@event)
            {
                case "onStreamMessage":
                    var length = (uint) AgoraUtil.GetData<uint>(data, "length");
                    var streamData = new byte[length];
                    Marshal.Copy(buffer, streamData, 0, (int) length);
                    Rtc.engineEventHandler?.OnStreamMessage((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "streamId"), streamData, length);
                    break;
            }
        }
    }

    public sealed class AgoraRtcEngine
    {
        private bool _disposed = false;
        private static AgoraRtcEngine _instance;
        private IrisEnginePtr _irisEngine = IntPtr.Zero;
        internal IRtcEngineEventHandlerBase engineEventHandler;
        private Dictionary<string, AgoraRtcChannel> _channels = new Dictionary<string, AgoraRtcChannel>();
        private AgoraVideoDeviceManager _videoDeviceManager = null;
        private AgoraAudioPlaybackDeviceManager _audioPlaybackDeviceManager = null;
        private AgoraAudioRecordingDeviceManager _audioRecordingDeviceManager = null;
        private char[] result = new char[512];

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                foreach (var (_, value) in _channels)
                {
                    value.Dispose();
                }
                _videoDeviceManager.Dispose();
                _audioRecordingDeviceManager.Dispose();
                _audioPlaybackDeviceManager.Dispose();
            }

            Release();
            _disposed = true;
        }

        public void InitEventHandler(IRtcEngineEventHandlerBase eventHandlerBase)
        {
            engineEventHandler = eventHandlerBase;
            NativeRtcEngineEventHandler.Rtc = _instance;
            var myHandler = new IrisCEventHandler
            {
                onEvent = NativeRtcEngineEventHandler.OnEvent,
                onEventWithBuffer = NativeRtcEngineEventHandler.OnEventWithBuffer
            };
            SetIrisEngineEventHandler(myHandler);
        }

        public static AgoraRtcEngine CreateRtcEngine()
        {
            return _instance ??= new AgoraRtcEngine
            {
                _irisEngine = AgorartcNative.CreateIrisEngine()
            };
        }

        private void Release()
        {
            AgorartcNative.DestroyIrisEngine(_irisEngine);
            engineEventHandler = null;
            _irisEngine = IntPtr.Zero;
        }

        public AgoraRtcChannel CreateChannel(string channelId)
        {
            if (_channels.Keys.Contains(channelId))
            {
                return _channels[channelId];
            }
            var ret = new AgoraRtcChannel(channelId);
            _channels.Add(channelId, ret);
            return ret;
        }

        internal void ReleaseChannel(string channelId)
        {
            _channels.Remove(channelId);
        }

        public AgoraAudioPlaybackDeviceManager CreateAudioPlaybackDeviceManager()
        {
            if (_audioPlaybackDeviceManager != null)
            {
                _audioPlaybackDeviceManager =
                    new AgoraAudioPlaybackDeviceManager(AgorartcNative.GetIrisDeviceManager(_irisEngine));
            }
            
            return _audioPlaybackDeviceManager;
        }

        internal void ReleaseAudioPlaybackDeviceManager()
        {
            _audioPlaybackDeviceManager = null;
        }

        public AgoraAudioRecordingDeviceManager CreateAudioRecordingDeviceManager()
        {
            if (_audioRecordingDeviceManager != null)
            {
                _audioRecordingDeviceManager =
                    new AgoraAudioRecordingDeviceManager(AgorartcNative.GetIrisDeviceManager(_irisEngine));
            }

            return _audioRecordingDeviceManager;
        }

        internal void ReleaseAudioRecordingDeviceManager()
        {
            _audioRecordingDeviceManager = null;
        }

        public AgoraVideoDeviceManager CreateVideoDeviceManager()
        {
            if (_videoDeviceManager != null)
            {
                _videoDeviceManager =
                    new AgoraVideoDeviceManager(AgorartcNative.GetIrisDeviceManager(_irisEngine));
            }

            return _videoDeviceManager;
        }

        public void ReleaseAgoraVideoDeviceManager()
        {
            _videoDeviceManager = null;
        }

        public ERROR_CODE Initialize(string appId, AREA_CODE areaCode)
        {
            var para = new
            {
                appId,
                areaCode = (int) areaCode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineInitialize,
                JsonSerializer.Serialize(para), result) * -1);
        }

        private void SetIrisEngineEventHandler(IrisCEventHandler handler)
        {
            AgorartcNative.SetIrisEngineEventHandler(_irisEngine, ref handler);
        }

        public ERROR_CODE SetChannelProfile(CHANNEL_PROFILE_TYPE channelProfileType)
        {
            var para = new
            {
                channelProfileType = (int) channelProfileType
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineSetChannelProfile,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetClientRole(CLIENT_ROLE_TYPE role)
        {
            var para = new
            {
                role = (int) role
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineSetClientRole,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE JoinChannel(string token, string channelId, string info, uint uid)
        {
            var para = new
            {
                token,
                channelId,
                info,
                uid
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineJoinChannel,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SwitchChannel(string token, string channelId)
        {
            var para = new
            {
                token,
                channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineSwitchChannel,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE LeaveChannel()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineLeaveChannel,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE RenewToken(string token)
        {
            var para = new
            {
                token
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineRenewToken,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE RegisterLocalUserAccount(string appId, string userAccount)
        {
            var para = new
            {
                appId,
                userAccount
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineRegisterLocalUserAccount, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            var para = new
            {
                token,
                channelId,
                userAccount
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineJoinChannelWithUserAccount, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo)
        {
            var para = new
            {
                userAccount
            };
            var ret = (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineGetUserInfoByUserAccount, JsonSerializer.Serialize(para), result) * -1);
            userInfo = AgoraUtil.JsonToStruct<UserInfo>(result);
            return ret;
        }

        public ERROR_CODE GetUserInfoByUid(uint uid, ref UserInfo userInfo)
        {
            var para = new
            {
                uid
            };
            var ret = (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineGetUserInfoByUid, JsonSerializer.Serialize(para), result) * -1);
            userInfo = AgoraUtil.JsonToStruct<UserInfo>(result);
            return ret;
        }

        public ERROR_CODE StartEchoTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartEchoTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartEchoTest(int intervalInSeconds)
        {
            var para = new
            {
                intervalInSeconds
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartEchoTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopEchoTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopEchoTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableVideo()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableVideo, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE DisableVideo()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineDisableVideo, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetVideoProfile(VIDEO_PROFILE_TYPE profile, bool swapWidthAndHeight)
        {
            var para = new
            {
                profile = (int) profile,
                swapWidthAndHeight
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetVideoProfile, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            var para = new
            {
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetVideoEncoderConfiguration, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            var para = new
            {
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetCameraCapturerConfiguration, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetupLocalVideo(VideoCanvas canvas)
        {
            var para = new
            {
                canvas
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetupLocalVideo, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetupRemoteVideo(VideoCanvas canvas)
        {
            var para = new
            {
                canvas
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetupRemoteVideo, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartPreview()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartPreview, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteUserPriority(uint uid, PRIORITY_TYPE userPriority)
        {
            var para = new
            {
                uid,
                userPriority = (int) userPriority
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetRemoteUserPriority, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopPreview()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopPreview, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableAudio()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableAudio, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableLocalAudio(bool enabled)
        {
            var para = new
            {
                enabled
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableLocalAudio, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE DisableAudio()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineDisableAudio, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetAudioProfile(AUDIO_PROFILE_TYPE profile,
            AUDIO_SCENARIO_TYPE scenario)
        {
            var para = new
            {
                profile = (int) profile,
                scenario = (int) scenario
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetAudioProfile, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteLocalAudioStream(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineMuteLocalAudioStream, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteAllRemoteAudioStreams(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineMuteAllRemoteAudioStreams, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                        CApiTypeEngine.kEngineSetDefaultMuteAllRemoteAudioStreams,
                        JsonSerializer.Serialize(para), result) * -1
                );
        }

        public ERROR_CODE AdjustUserPlaybackSignalVolume(uint uid, int volume)
        {
            var para = new
            {
                uid,
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAdjustUserPlaybackSignalVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteRemoteAudioStream(uint userId, bool mute)
        {
            var para = new
            {
                userId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineMuteRemoteAudioStream, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteLocalVideoStream(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineMuteLocalVideoStream, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableLocalVideo(bool enabled)
        {
            var para = new
            {
                enabled
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableLocalVideo, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteAllRemoteVideoStreams(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineMuteAllRemoteVideoStreams, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetDefaultMuteAllRemoteVideoStreams,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteRemoteVideoStream(uint userId, bool mute)
        {
            var para = new
            {
                userId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineMuteRemoteVideoStream, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteVideoStreamType(uint userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var para = new
            {
                userId,
                streamType = (int) streamType
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetRemoteVideoStreamType, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var para = new
            {
                streamType = (int) streamType
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetRemoteDefaultVideoStreamType, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableAudioVolumeIndication(int interval, int smooth, bool reportVad)
        {
            var para = new
            {
                interval,
                smooth,
                report_vad = reportVad
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableAudioVolumeIndication, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            var para = new
            {
                filePath,
                quality = (int) quality
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartAudioRecording, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartAudioRecording(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            var para = new
            {
                filePath,
                sampleRate,
                quality = (int) quality
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartAudioRecording, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopAudioRecording()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopAudioRecording, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteVoicePosition(uint uid, double pan, double gain)
        {
            var para = new
            {
                uid,
                pan,
                gain
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetRemoteVoicePosition, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLogFile(string file)
        {
            var para = new
            {
                file
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLogFile, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLogFilter(uint filter)
        {
            var para = new
            {
                filter
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLogFilter, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLogFileSize(uint fileSizeInKBytes)
        {
            var para = new
            {
                fileSizeInKBytes
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLogFileSize, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            var para = new
            {
                renderMode = (int) renderMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalRenderMode, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var para = new
            {
                renderMode = (int) renderMode,
                mirrorMode = (int) mirrorMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalRenderMode, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteRenderMode(uint userId, RENDER_MODE_TYPE renderMode)
        {
            var para = new
            {
                userId,
                renderMode = (int) renderMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetRemoteRenderMode, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteRenderMode2(uint userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var para = new
            {
                userId,
                renderMode = (int) renderMode,
                mirrorMode = (int) mirrorMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetRemoteRenderMode, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var para = new
            {
                mirrorMode = (int) mirrorMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalVideoMirrorMode, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableDualStreamMode(bool enabled)
        {
            var para = new
            {
                enabled
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableDualStreamMode, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AdjustRecordingSignalVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAdjustRecordingSignalVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AdjustPlaybackSignalVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAdjustPlaybackSignalVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableWebSdkInteroperability(bool enabled)
        {
            var para = new
            {
                enabled
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableWebSdkInteroperability, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetVideoQualityParameters(bool preferFrameRateOverImageQuality)
        {
            var para = new
            {
                preferFrameRateOverImageQuality
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetVideoQualityParameters, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            var para = new
            {
                option = (int) option
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalPublishFallbackOption, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            var para = new
            {
                option = (int) option
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetRemoteSubscribeFallbackOption, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableLoopbackRecording(bool enabled, string deviceName)
        {
            var para = new
            {
                enabled,
                deviceName
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableLoopBackRecording, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartScreenCaptureByScreenRect(Rectangle screenRect, Rectangle regionRect,
            ScreenCaptureParameters captureParams)
        {
            var para = new
            {
                screenRect,
                regionRect,
                captureParams
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartScreenCaptureByScreenRect, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartScreenCaptureByWindowId(view_t windowId, Rectangle regionRect,
            ScreenCaptureParameters captureParams)
        {
            var para = new
            {
                windowId,
                regionRect,
                captureParams
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartScreenCaptureByWindowId, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetScreenCaptureContentHint(VideoContentHint contentHint)
        {
            var para = new
            {
                contentHint = (int) contentHint
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetScreenCaptureContentHint, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE UpdateScreenCaptureParameters(ScreenCaptureParameters captureParams)
        {
            var para = new
            {
                captureParams
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineUpdateScreenCaptureParameters, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE UpdateScreenCaptureRegion(Rectangle regionRect)
        {
            var para = new
            {
                regionRect
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineUpdateScreenCaptureRegion, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopScreenCapture()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopScreenCapture, JsonSerializer.Serialize(para), result) * -1);
        }

        public string GetCallId()
        {
            var para = new { };
            return AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineGetCallId,
                JsonSerializer.Serialize(para), result) != 0
                ? "GetCallId Failed."
                : new string(result[..Array.IndexOf(result, '\0')]);
        }

        public ERROR_CODE Rate(string callId, int rating, string description)
        {
            var para = new
            {
                callId,
                rating,
                description
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineRate, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE Complain(string callId, string description)
        {
            var para = new
            {
                callId,
                description
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineComplain, JsonSerializer.Serialize(para), result) * -1);
        }

        public string GetVersion()
        {
            var para = new { };
            return AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineGetVersion,
                JsonSerializer.Serialize(para), result) != 0
                ? "GetVersion Failed."
                : new string(result[..Array.IndexOf(result, '\0')]);
        }

        public ERROR_CODE EnableLastmileTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableLastMileTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE DisableLastmileTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineDisableLastMileTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartLastmileProbeTest(LastmileProbeConfig config)
        {
            var para = new
            {
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartLastMileProbeTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopLastmileProbeTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopLastMileProbeTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public string GetErrorDescription(int code)
        {
            var para = new
            {
                code
            };
            return AgorartcNative.CallIrisEngineApi(_irisEngine, CApiTypeEngine.kEngineGetErrorDescription,
                JsonSerializer.Serialize(para), result) != 0
                ? "GetErrorDescription Failed."
                : new string(result[..Array.IndexOf(result, '\0')]);
        }

        public ERROR_CODE SetEncryptionSecret(string secret)
        {
            var para = new
            {
                secret
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetEncryptionSecret, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetEncryptionMode(string encryptionMode)
        {
            var para = new
            {
                encryptionMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetEncryptionMode, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            var para = new
            {
                reliable,
                ordered
            };
            var ret = (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineCreateDataStream, JsonSerializer.Serialize(para), result) * -1);
            // TODO: (CreateDataStream) streamId = 
            return ret;
        }

        public ERROR_CODE SendStreamMessage(int streamId, byte[] data)
        {
            var para = new
            {
                streamId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApiWithBuffer(_irisEngine,
                CApiTypeEngine.kEngineSendStreamMessage, JsonSerializer.Serialize(para), data) * -1);
        }

        public ERROR_CODE AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            var para = new
            {
                url,
                transcodingEnabled
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAddPublishStreamUrl, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE RemovePublishStreamUrl(string url)
        {
            var para = new
            {
                url
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineRemovePublishStreamUrl, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLiveTranscoding(LiveTranscoding transcoding)
        {
            var para = new
            {
                transcoding
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLiveTranscoding, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AddVideoWatermark(RtcImage watermark)
        {
            var para = new
            {
                watermark
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAddVideoWaterMark, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AddVideoWatermark(string watermarkUrl, WatermarkOptions options)
        {
            var para = new
            {
                watermarkUrl,
                options
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAddVideoWaterMark, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE ClearVideoWatermarks()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineClearVideoWaterMarks, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetBeautyEffectOptions(bool enabled, BeautyOptions options)
        {
            var para = new
            {
                enabled,
                options
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetBeautyEffectOptions, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            var para = new
            {
                url,
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAddInjectStreamUrl, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var para = new
            {
                configuration
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartChannelMediaRelay, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var para = new
            {
                configuration
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineUpdateChannelMediaRelay, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopChannelMediaRelay()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopChannelMediaRelay, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE RemoveInjectStreamUrl(string url)
        {
            var para = new
            {
                url
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineRemoveInjectStreamUrl, JsonSerializer.Serialize(para), result) * -1);
        }

        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            var para = new { };
            return (CONNECTION_STATE_TYPE) AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineGetConnectionState, JsonSerializer.Serialize(para), result);
        }

        public ERROR_CODE EnableRemoteSuperResolution(uint userId, string enable)
        {
            var para = new
            {
                userId,
                enable
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableRemoteSuperResolution, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE RegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var para = new
            {
                type
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineRegisterMediaMetadataObserver, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE UnRegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var para = new
            {
                type
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineUnRegisterMediaMetadataObserver, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE SetMaxMetadataSize(int size)
        {
            var para = new
            {
                size
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetMaxMetadataSize, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE SendMetadata(Metadata metadata)
        {
            var para = new
            {
                metadata = new
                {
                    metadata.uid,
                    metadata.size,
                    metadata.timeStampMs
                }
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApiWithBuffer(_irisEngine,
                CApiTypeEngine.kEngineSendMetadata, JsonSerializer.Serialize(para), metadata.buffer) * -1);
        }

        public ERROR_CODE SetParameters(string parameters)
        {
            var para = new
            {
                parameters
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetParameters, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetPlaybackDeviceVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetPlaybackDeviceVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        // API_TYPE_AUDIO_EFFECT

        public ERROR_CODE StartAudioMixing(string filePath, bool loopback, bool replace, int cycle)
        {
            var para = new
            {
                filePath,
                loopback,
                replace,
                cycle
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStartAudioMixing, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopAudioMixing()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopAudioMixing, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE PauseAudioMixing()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEnginePauseAudioMixing, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE ResumeAudioMixing()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineResumeAudioMixing, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetHighQualityAudioParameters(bool fullband, bool stereo, bool fullBitrate)
        {
            var para = new
            {
                fullband,
                stereo,
                fullBitrate
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetHighQualityAudioParameters, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AdjustAudioMixingVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAdjustAudioMixingVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AdjustAudioMixingPlayoutVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAdjustAudioMixingPlayoutVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE GetAudioMixingPlayoutVolume(ref int volume)
        {
            var para = new { };
            var ret = AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineGetAudioMixingPlayoutVolume, JsonSerializer.Serialize(para), result);
            volume = ret < 0 ? -1 : ret;
            return ret < 0 ? (ERROR_CODE) (ret * -1) : ERROR_CODE.ERR_OK;
        }

        public ERROR_CODE AdjustAudioMixingPublishVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineAdjustAudioMixingPublishVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE GetAudioMixingPublishVolume(ref int volume)
        {
            var para = new { };
            var ret = AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineGetAudioMixingPublishVolume, JsonSerializer.Serialize(para), result);
            volume = ret < 0 ? -1 : ret;
            return ret < 0 ? (ERROR_CODE) (ret * -1) : ERROR_CODE.ERR_OK;
        }

        public ERROR_CODE GetAudioMixingDuration(ref int duration)
        {
            var para = new { };
            var ret = AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineGetAudioMixingDuration, JsonSerializer.Serialize(para), result);
            duration = ret < 0 ? -1 : ret;
            return ret < 0 ? (ERROR_CODE) (ret * -1) : ERROR_CODE.ERR_OK;
        }

        public ERROR_CODE GetAudioMixingCurrentPosition(ref int pos)
        {
            var para = new { };
            var ret = AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineGetAudioMixingCurrentPosition, JsonSerializer.Serialize(para), result);
            pos = ret < 0 ? -1 : ret;
            return ret < 0 ? (ERROR_CODE) (ret * -1) : ERROR_CODE.ERR_OK;
        }

        public ERROR_CODE SetAudioMixingPosition(int pos /*in ms*/)
        {
            var para = new
            {
                pos
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetAudioMixingPosition, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetAudioMixingPitch(int pitch)
        {
            var para = new
            {
                pitch
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetAudioMixingPitch, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE GetEffectsVolume(ref int volume)
        {
            var para = new { };
            var ret = AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineGetEffectsVolume, JsonSerializer.Serialize(para), result);
            volume = ret < 0 ? -1 : ret;
            return ret < 0 ? (ERROR_CODE) (ret * -1) : ERROR_CODE.ERR_OK;
        }

        public ERROR_CODE SetEffectsVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetEffectsVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetVolumeOfEffect(int soundId, int volume)
        {
            var para = new
            {
                soundId,
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetVolumeOfEffect, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain,
            bool publish)
        {
            var para = new
            {
                soundId,
                filePath,
                loopCount,
                pitch,
                pan,
                gain,
                publish
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEnginePlayEffect, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopEffect(int soundId)
        {
            var para = new
            {
                soundId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopEffect, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopAllEffects()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineStopAllEffects, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE PreloadEffect(int soundId, string filePath)
        {
            var para = new
            {
                soundId,
                filePath
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEnginePreloadEffect, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE UnloadEffect(int soundId)
        {
            var para = new
            {
                soundId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineUnloadEffect, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE PauseEffect(int soundId)
        {
            var para = new
            {
                soundId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEnginePauseEffect, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE PauseAllEffects()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEnginePauseAllEffects, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE ResumeEffect(int soundId)
        {
            var para = new
            {
                soundId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineResumeEffect, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE ResumeAllEffects()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineResumeAllEffects, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE EnableSoundPositionIndication(bool enabled)
        {
            var para = new
            {
                enabled
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableSoundPositionIndication, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalVoicePitch(double pitch)
        {
            var para = new
            {
                pitch
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalVoicePitch, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            var para = new
            {
                bandFrequency = (int) bandFrequency,
                bandGain
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalVoiceEqualization, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            var para = new
            {
                reverbKey = (int) reverbKey,
                value
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalVoiceReverb, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger)
        {
            var para = new
            {
                voiceChanger = (int) voiceChanger
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalVoiceChanger, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset)
        {
            var para = new
            {
                reverbPreset = (int) reverbPreset
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetLocalVoiceReverbPreset, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetVoiceBeautifierPreset(VOICE_BEAUTIFIER_PRESET preset)
        {
            var para = new
            {
                preset = (int) preset
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetVoiceBeautifierPreset, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetAudioEffectPreset(AUDIO_EFFECT_PRESET preset)
        {
            var para = new
            {
                preset = (int) preset
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetAudioEffectPreset, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetAudioEffectParameters(AUDIO_EFFECT_PRESET preset, int param1, int param2)
        {
            var para = new
            {
                preset = (int) preset,
                param1,
                param2
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetAudioEffectParameters, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetExternalAudioSource(bool enabled, int sampleRate, int channels)
        {
            var para = new
            {
                enabled,
                sampleRate,
                channels
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetExternalAudioSource, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            var para = new
            {
                enabled,
                sampleRate,
                channels
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetExternalAudioSink, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRecordingAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            var para = new
            {
                sampleRate,
                channel,
                mode = (int) mode,
                samplesPerCall
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetRecordingAudioFrameParameters, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetPlaybackAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            var para = new
            {
                sampleRate,
                channel,
                mode = (int) mode,
                samplesPerCall
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetPlaybackAudioFrameParameters, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetMixedAudioFrameParameters(int sampleRate, int samplesPerCall)
        {
            var para = new
            {
                sampleRate,
                samplesPerCall
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSetMixedAudioFrameParameters, JsonSerializer.Serialize(para), result) * -1);
        }

        // TODO: PushAudioFrame/PullAudioFrame/SetExternalVideoSource/PushVideoFrame
        // public ERROR_CODE PushAudioFrame(MEDIA_SOURCE_TYPE type, ref AudioFrame frame, bool wrap)
        // {
        //     return AgorartcNative.pushAudioFrame(_apiBridge, type, ref frame, wrap ? 1 : 0);
        // }
        //
        // public ERROR_CODE PushAudioFrame2(ref AudioFrame frame)
        // {
        //     return AgorartcNative.pushAudioFrame2(_apiBridge, ref frame);
        // }
        //
        // public ERROR_CODE PullAudioFrame(ref AudioFrame frame)
        // {
        //     return AgorartcNative.pullAudioFrame(_apiBridge, ref frame);
        // }
        //
        // public ERROR_CODE SetExternalVideoSource(bool enable, bool useTexture)
        // {
        //     var para = new
        //     {
        //         enable,
        //         useTexture
        //     };
        //     return (ERROR_CODE) AgorartcNative.CallIrisEngineApi(_apiBridge,
        //         CApiTypeEngine.kEngineSetMixedAudioFrameParameters, JsonSerializer.Serialize(para), result);
        // }
        //
        // public ERROR_CODE PushVideoFrame(ref ExternalVideoFrame frame)
        // {
        //     return AgorartcNative.pushVideoFrame(_apiBridge, ref frame);
        // }

        public ERROR_CODE EnableEncryption(bool enabled, EncryptionConfig config)
        {
            var para = new
            {
                enabled,
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineEnableEncryption, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SendCustomReportMessage(string id, string category, string @event, string label, int value)
        {
            var para = new
            {
                id,
                category,
                @event,
                label,
                value
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisEngineApi(_irisEngine,
                CApiTypeEngine.kEngineSendCustomReportMessage, JsonSerializer.Serialize(para), result) * -1);
        }

        ~AgoraRtcEngine()
        {
            Dispose(false);
        }
    }
}