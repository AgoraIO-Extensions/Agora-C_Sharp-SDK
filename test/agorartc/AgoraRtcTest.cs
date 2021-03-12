using System;
using System.Runtime.InteropServices;

namespace agorartc
{
    using IrisTestPtr = IntPtr;

    internal static class NativeRtcEngineApiTestHandler
    {
        internal static AgoraRtcEngineApiTest RtcEngineApiTest;

        internal static void OnEvent(string @event, string data)
        {
            switch (@event)
            {
                case "onApiTest":
                    RtcEngineApiTest.engineEventHandler?.OnApiTest((int) AgoraUtil.GetData<int>(data, "apiType"),
                        (string) AgoraUtil.GetData<object>(data, "params"));
                    break;
            }
        }
    }

    public class AgoraRtcEngineApiTest : IDisposable
    {
        private IrisTestPtr _irisTest;
        internal IRtcEngineEventHandlerBase engineEventHandler;
        private IrisCEventHandler _CEventHandler;
        private bool disposed = false;

        public AgoraRtcEngineApiTest(string dumpFilePath, IRtcEngineEventHandlerBase eventHandlerBase, AgoraRtcEngine rtcEngine)
        {
            _irisTest = AgorartcNative.CreateIrisTest(dumpFilePath);
            AgorartcNative.SetProxy(_irisTest, rtcEngine.GetNativeHandler());
            NativeRtcEngineApiTestHandler.RtcEngineApiTest = this;
            engineEventHandler = eventHandlerBase;
            _CEventHandler = new IrisCEventHandler()
            {
                onEvent = NativeRtcEngineApiTestHandler.OnEvent
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            Release();

            disposed = true;
        }

        public void BeginApiTestByFile(string caseFilePath)
        {
            AgorartcNative.BeginApiTestByFile(_irisTest, caseFilePath, ref _CEventHandler);
        }

        public void BeginApiTest(string caseContent)
        {
            AgorartcNative.BeginApiTest(_irisTest, caseContent, ref _CEventHandler);
        }

        private void Release()
        {
            AgorartcNative.DestroyIrisTest(_irisTest);
            engineEventHandler = null;
            _irisTest = IntPtr.Zero;
        }

        ~AgoraRtcEngineApiTest()
        {
            Dispose(false);
        }
    }
    
    internal static class NativeRtcChannelApiTestHandler
    {
        internal static AgoraRtcChannelApiTest RtcChannelApiTest;

        internal static void OnEvent(string @event, string data)
        {
            switch (@event)
            {
                case "onApiTest":
                    RtcChannelApiTest.channelEventHandler?.OnChannelApiTest((int) AgoraUtil.GetData<int>(data, "apiType"),
                        (string) AgoraUtil.GetData<object>(data, "params"));
                    break;
            }
        }
    }
    
    public class AgoraRtcChannelApiTest : IDisposable
    {
        private IrisTestPtr _irisTest;
        internal IRtcChannelEventHandlerBase channelEventHandler;
        private IrisCEventHandler _CEventHandler;
        private bool disposed = false;

        public AgoraRtcChannelApiTest(string dumpFilePath, IRtcChannelEventHandlerBase eventHandlerBase, AgoraRtcEngine rtcEngine)
        {
            _irisTest = AgorartcNative.CreateIrisTest(dumpFilePath);
            AgorartcNative.SetProxy(_irisTest, rtcEngine.GetNativeHandler());
            NativeRtcChannelApiTestHandler.RtcChannelApiTest = this;
            channelEventHandler = eventHandlerBase;
            _CEventHandler = new IrisCEventHandler()
            {
                onEvent = NativeRtcChannelApiTestHandler.OnEvent
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            Release();

            disposed = true;
        }

        public void BeginApiTestByFile(string caseFilePath)
        {
            AgorartcNative.BeginApiTestByFile(_irisTest, caseFilePath, ref _CEventHandler);
        }

        public void BeginApiTest(string caseContent)
        {
            AgorartcNative.BeginApiTest(_irisTest, caseContent, ref _CEventHandler);
        }

        private void Release()
        {
            AgorartcNative.DestroyIrisTest(_irisTest);
            channelEventHandler = null;
            _irisTest = IntPtr.Zero;
        }

        ~AgoraRtcChannelApiTest()
        {
            Dispose(false);
        }
    }

    internal static class NativeRtcEngineEventTestHandler
    {
        internal static AgoraRtcEngineEventTest RtcEngineEventTest;

        internal static void OnEvent(string @event, string data)
        {
            switch (@event)
            {
                case "onWarning":
                    RtcEngineEventTest.engineEventHandler?.OnWarning((WARN_CODE_TYPE) AgoraUtil.GetData<int>(data, "warn"),
                        (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onError":
                    RtcEngineEventTest.engineEventHandler?.OnError((ERROR_CODE) AgoraUtil.GetData<int>(data, "err"),
                        (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onJoinChannelSuccess":
                    RtcEngineEventTest.engineEventHandler?.OnJoinChannelSuccess((string) AgoraUtil.GetData<string>(data, "channel"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onRejoinChannelSuccess":
                    RtcEngineEventTest.engineEventHandler?.OnReJoinChannelSuccess((string) AgoraUtil.GetData<string>(data, "channel"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onLeaveChannel":
                    RtcEngineEventTest.engineEventHandler?.OnLeaveChannel(AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onClientRoleChanged":
                    RtcEngineEventTest.engineEventHandler?.OnClientRoleChanged(
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "oldRole"),
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "newRole"));
                    break;
                case "onUserJoined":
                    RtcEngineEventTest.engineEventHandler?.OnUserJoined((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserOffline":
                    RtcEngineEventTest.engineEventHandler?.OnUserOffline((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (USER_OFFLINE_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onLastmileQuality":
                    RtcEngineEventTest.engineEventHandler?.OnLastmileQuality((int) AgoraUtil.GetData<int>(data, "quality"));
                    break;
                case "onLastmileProbeResult":
                    RtcEngineEventTest.engineEventHandler?.OnLastmileProbeResult(
                        AgoraUtil.JsonToStruct<LastmileProbeResult>(data, "result"));
                    break;
                case "onConnectionInterrupted":
                    RtcEngineEventTest.engineEventHandler?.OnConnectionInterrupted();
                    break;
                case "onConnectionLost":
                    RtcEngineEventTest.engineEventHandler?.OnConnectionLost();
                    break;
                case "onConnectionBanned":
                    RtcEngineEventTest.engineEventHandler?.OnConnectionBanned();
                    break;
                case "onApiCallExecuted":
                    RtcEngineEventTest.engineEventHandler?.OnApiCallExecuted((ERROR_CODE) AgoraUtil.GetData<int>(data, "err"),
                        (string) AgoraUtil.GetData<string>(data, "api"),
                        (string) AgoraUtil.GetData<string>(data, "result"));
                    break;
                case "onRequestToken":
                    RtcEngineEventTest.engineEventHandler?.OnRequestToken();
                    break;
                case "onTokenPrivilegeWillExpire":
                    RtcEngineEventTest.engineEventHandler?.OnTokenPrivilegeWillExpire(
                        (string) AgoraUtil.GetData<string>(data, "token"));
                    break;
                case "onAudioQuality":
                    RtcEngineEventTest.engineEventHandler?.OnAudioQuality((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "quality"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "delay"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "lost"));
                    break;
                case "onRtcStats":
                    RtcEngineEventTest.engineEventHandler?.OnRtcStats(AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onNetworkQuality":
                    RtcEngineEventTest.engineEventHandler?.OnNetworkQuality((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "txQuality"),
                        (int) AgoraUtil.GetData<int>(data, "rxQuality"));
                    break;
                case "onLocalVideoStats":
                    RtcEngineEventTest.engineEventHandler?.OnLocalVideoStats(AgoraUtil.JsonToStruct<LocalVideoStats>(data, "stats"));
                    break;
                case "onRemoteVideoStats":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteVideoStats(AgoraUtil.JsonToStruct<RemoteVideoStats>(data, "stats"));
                    break;
                case "onLocalAudioStats":
                    RtcEngineEventTest.engineEventHandler?.OnLocalAudioStats(AgoraUtil.JsonToStruct<LocalAudioStats>(data, "stats"));
                    break;
                case "onRemoteAudioStats":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteAudioStats(AgoraUtil.JsonToStruct<RemoteAudioStats>(data, "stats"));
                    break;
                case "onLocalAudioStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnLocalAudioStateChanged(
                        (LOCAL_AUDIO_STREAM_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (LOCAL_AUDIO_STREAM_ERROR) AgoraUtil.GetData<int>(data, "error"));
                    break;
                case "onRemoteAudioStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteAudioStateChanged((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_AUDIO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_AUDIO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onAudioPublishStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnAudioPublishStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "channel"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoPublishStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnVideoPublishStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "channel"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onAudioSubscribeStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnAudioSubscribeStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "channel"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoSubscribeStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnVideoSubscribeStateChanged(
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
                    RtcEngineEventTest.engineEventHandler?.OnAudioVolumeIndication(speakers, speakerNumber, totalVolume);
                    break;
                case "onActiveSpeaker":
                    RtcEngineEventTest.engineEventHandler?.OnActiveSpeaker((uint) AgoraUtil.GetData<uint>(data, "uid"));
                    break;
                case "onVideoStopped":
                    RtcEngineEventTest.engineEventHandler?.OnVideoStopped();
                    break;
                case "onFirstLocalVideoFrame":
                    RtcEngineEventTest.engineEventHandler?.OnFirstLocalVideoFrame((int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstLocalVideoFramePublished":
                    RtcEngineEventTest.engineEventHandler?.OnFirstLocalVideoFramePublished(
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstRemoteVideoDecoded":
                    RtcEngineEventTest.engineEventHandler?.OnFirstRemoteVideoDecoded((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "width"), (int) AgoraUtil.GetData<int>(data, "height"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstRemoteVideoFrame":
                    RtcEngineEventTest.engineEventHandler?.OnFirstRemoteVideoFrame((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "width"), (int) AgoraUtil.GetData<int>(data, "height"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserMuteAudio":
                    RtcEngineEventTest.engineEventHandler?.OnUserMuteAudio((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "muted"));
                    break;
                case "onUserMuteVideo":
                    RtcEngineEventTest.engineEventHandler?.OnUserMuteVideo((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "muted"));
                    break;
                case "onUserEnableVideo":
                    RtcEngineEventTest.engineEventHandler?.OnUserEnableVideo((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "enabled"));
                    break;
                case "onAudioDeviceStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnAudioDeviceStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "deviceId"),
                        (MEDIA_DEVICE_TYPE) AgoraUtil.GetData<int>(data, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE) AgoraUtil.GetData<int>(data, "deviceState"));
                    break;
                case "onAudioDeviceVolumeChanged":
                    RtcEngineEventTest.engineEventHandler?.OnAudioDeviceVolumeChanged(
                        (MEDIA_DEVICE_TYPE) AgoraUtil.GetData<int>(data, "deviceType"),
                        (int) AgoraUtil.GetData<int>(data, "volume"),
                        (bool) AgoraUtil.GetData<bool>(data, "muted"));
                    break;
                case "onCameraReady":
                    RtcEngineEventTest.engineEventHandler?.OnCameraReady();
                    break;
                case "onCameraFocusAreaChanged":
                    RtcEngineEventTest.engineEventHandler?.OnCameraFocusAreaChanged((int) AgoraUtil.GetData<int>(data, "x"),
                        (int) AgoraUtil.GetData<int>(data, "y"), (int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"));
                    break;
                case "onCameraExposureAreaChanged":
                    RtcEngineEventTest.engineEventHandler?.OnCameraExposureAreaChanged((int) AgoraUtil.GetData<int>(data, "x"),
                        (int) AgoraUtil.GetData<int>(data, "y"), (int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"));
                    break;
                case "onAudioMixingFinished":
                    RtcEngineEventTest.engineEventHandler?.OnAudioMixingFinished();
                    break;
                case "onAudioMixingStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnAudioMixingStateChanged(
                        (AUDIO_MIXING_STATE_TYPE) AgoraUtil.GetData<int>(data, "state"),
                        (AUDIO_MIXING_ERROR_TYPE) AgoraUtil.GetData<int>(data, "errorCode"));
                    break;
                case "onRemoteAudioMixingBegin":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteAudioMixingBegin();
                    break;
                case "onRemoteAudioMixingEnd":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteAudioMixingEnd();
                    break;
                case "onAudioEffectFinished":
                    RtcEngineEventTest.engineEventHandler?.OnAudioEffectFinished((int) AgoraUtil.GetData<int>(data, "soundId"));
                    break;
                case "onFirstRemoteAudioDecoded":
                    RtcEngineEventTest.engineEventHandler?.OnFirstRemoteAudioDecoded((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onVideoDeviceStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnVideoDeviceStateChanged(
                        (string) AgoraUtil.GetData<string>(data, "deviceId"),
                        (MEDIA_DEVICE_TYPE) AgoraUtil.GetData<int>(data, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE) AgoraUtil.GetData<int>(data, "deviceState"));
                    break;
                case "onLocalVideoStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnLocalVideoStateChanged(
                        (LOCAL_VIDEO_STREAM_STATE) AgoraUtil.GetData<int>(data, "localVideoState"),
                        (LOCAL_VIDEO_STREAM_ERROR) AgoraUtil.GetData<int>(data, "error"));
                    break;
                case "onVideoSizeChanged":
                    RtcEngineEventTest.engineEventHandler?.OnVideoSizeChanged((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "width"), (int) AgoraUtil.GetData<int>(data, "height"),
                        (int) AgoraUtil.GetData<int>(data, "rotation"));
                    break;
                case "onRemoteVideoStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteVideoStateChanged((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_VIDEO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_VIDEO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserEnableLocalVideo":
                    RtcEngineEventTest.engineEventHandler?.OnUserEnableLocalVideo((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "enabled"));
                    break;
                case "onStreamMessageError":
                    RtcEngineEventTest.engineEventHandler?.OnStreamMessageError((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "streamId"), (int) AgoraUtil.GetData<int>(data, "code"),
                        (int) AgoraUtil.GetData<int>(data, "missed"), (int) AgoraUtil.GetData<int>(data, "cached"));
                    break;
                case "onMediaEngineLoadSuccess":
                    RtcEngineEventTest.engineEventHandler?.OnMediaEngineLoadSuccess();
                    break;
                case "onMediaEngineStartCallSuccess":
                    RtcEngineEventTest.engineEventHandler?.OnMediaEngineStartCallSuccess();
                    break;
                case "onUserSuperResolutionEnabled":
                    RtcEngineEventTest.engineEventHandler?.OnUserSuperResolutionEnabled((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "enabled"),
                        (SUPER_RESOLUTION_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onChannelMediaRelayStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnChannelMediaRelayStateChanged(
                        (CHANNEL_MEDIA_RELAY_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (CHANNEL_MEDIA_RELAY_ERROR) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onChannelMediaRelayEvent":
                    RtcEngineEventTest.engineEventHandler?.OnChannelMediaRelayEvent(
                        (CHANNEL_MEDIA_RELAY_EVENT) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onFirstLocalAudioFrame":
                    RtcEngineEventTest.engineEventHandler?.OnFirstLocalAudioFrame((int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstLocalAudioFramePublished":
                    RtcEngineEventTest.engineEventHandler?.OnFirstLocalAudioFramePublished(
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onFirstRemoteAudioFrame":
                    RtcEngineEventTest.engineEventHandler?.OnFirstRemoteAudioFrame((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onRtmpStreamingStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnRtmpStreamingStateChanged((string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (RTMP_STREAM_PUBLISH_ERROR) AgoraUtil.GetData<int>(data, "errCode"));
                    break;
                case "onRtmpStreamingEvent":
                    RtcEngineEventTest.engineEventHandler?.OnRtmpStreamingEvent((string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAMING_EVENT) AgoraUtil.GetData<int>(data, "eventCode"));
                    break;
                case "onStreamPublished":
                    RtcEngineEventTest.engineEventHandler?.OnStreamPublished((string) AgoraUtil.GetData<string>(data, "url"),
                        (ERROR_CODE) AgoraUtil.GetData<int>(data, "error"));
                    break;
                case "onStreamUnpublished":
                    RtcEngineEventTest.engineEventHandler?.OnStreamUnpublished((string) AgoraUtil.GetData<string>(data, "url"));
                    break;
                case "onTranscodingUpdated":
                    RtcEngineEventTest.engineEventHandler?.OnTranscodingUpdated();
                    break;
                case "onStreamInjectedStatus":
                    RtcEngineEventTest.engineEventHandler?.OnStreamInjectedStatus((string) AgoraUtil.GetData<string>(data, "url"),
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "status"));
                    break;
                case "onAudioRouteChanged":
                    RtcEngineEventTest.engineEventHandler?.OnAudioRouteChanged(
                        (AUDIO_ROUTE_TYPE) AgoraUtil.GetData<int>(data, "routing"));
                    break;
                case "onLocalPublishFallbackToAudioOnly":
                    RtcEngineEventTest.engineEventHandler?.OnLocalPublishFallbackToAudioOnly(
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteSubscribeFallbackToAudioOnly(
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onRemoteAudioTransportStats":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteAudioTransportStats(
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "delay"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "lost"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "rxKBitRate"));
                    break;
                case "onRemoteVideoTransportStats":
                    RtcEngineEventTest.engineEventHandler?.OnRemoteVideoTransportStats(
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "delay"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "lost"),
                        (ushort) AgoraUtil.GetData<ushort>(data, "rxKBitRate"));
                    break;
                case "onMicrophoneEnabled":
                    RtcEngineEventTest.engineEventHandler?.OnMicrophoneEnabled((bool) AgoraUtil.GetData<bool>(data, "enabled"));
                    break;
                case "onConnectionStateChanged":
                    RtcEngineEventTest.engineEventHandler?.OnConnectionStateChanged(
                        (CONNECTION_STATE_TYPE) AgoraUtil.GetData<int>(data, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onNetworkTypeChanged":
                    RtcEngineEventTest.engineEventHandler?.OnNetworkTypeChanged((NETWORK_TYPE) AgoraUtil.GetData<int>(data, "type"));
                    break;
                case "onLocalUserRegistered":
                    RtcEngineEventTest.engineEventHandler?.OnLocalUserRegistered((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (string) AgoraUtil.GetData<string>(data, "userAccount"));
                    break;
                case "onUserInfoUpdated":
                    RtcEngineEventTest.engineEventHandler?.OnUserInfoUpdated((uint) AgoraUtil.GetData<uint>(data, "uid"),
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
                    if (buffer != IntPtr.Zero) Marshal.Copy(buffer, streamData, 0, (int) length);
                    RtcEngineEventTest.engineEventHandler?.OnStreamMessage((uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "streamId"), streamData, length);
                    break;
            }
        }
    }
    
    public class AgoraRtcEngineEventTest : IDisposable
    {
        private IrisTestPtr _irisTest;
        internal IRtcEngineEventHandlerBase engineEventHandler;
        private IrisCEventHandler _CEventHandler;
        private bool disposed = false;

        public AgoraRtcEngineEventTest(string dumpFilePath, IRtcEngineEventHandlerBase eventHandlerBase, AgoraRtcEngine rtcEngine)
        {
            _irisTest = AgorartcNative.CreateIrisTest(dumpFilePath);
            AgorartcNative.SetProxy(_irisTest, rtcEngine.GetNativeHandler());
            NativeRtcEngineEventTestHandler.RtcEngineEventTest = this;
            engineEventHandler = eventHandlerBase;
            _CEventHandler = new IrisCEventHandler()
            {
                onEvent = NativeRtcEngineEventTestHandler.OnEvent,
                onEventWithBuffer = NativeRtcEngineEventTestHandler.OnEventWithBuffer
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            Release();

            disposed = true;
        }

        public void BeginEventTestByFile(string caseFilePath)
        {
            AgorartcNative.BeginEventTestByFile(_irisTest, caseFilePath, ref _CEventHandler);
        }

        public void BeginEventTest(string caseContent)
        {
            AgorartcNative.BeginApiTest(_irisTest, caseContent, ref _CEventHandler);
        }

        public void OnEventReceived(string @event, string data)
        {
            AgorartcNative.OnEventReceived(_irisTest, @event, data);
        }

        private void Release()
        {
            AgorartcNative.DestroyIrisTest(_irisTest);
            engineEventHandler = null;
            _irisTest = IntPtr.Zero;
        }

        ~AgoraRtcEngineEventTest()
        {
            Dispose(false);
        }
    }
    
    internal static class NativeRtcChannelTestEventHandler
    {
        internal static AgoraRtcChannelEventTest RtcChannelEventTest;

        internal static void OnEvent(string @event, string data)
        {
            var channelId = (string) AgoraUtil.GetData<string>(data, "channelId");
            switch (@event)
            {
                case "onChannelWarning":
                    RtcChannelEventTest.channelEventHandler?.OnChannelWarning(channelId,
                        (int) AgoraUtil.GetData<int>(data, "warn"), (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onChannelError":
                    RtcChannelEventTest.channelEventHandler?.OnChannelError(channelId,
                        (int) AgoraUtil.GetData<int>(data, "err"), (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onJoinChannelSuccess":
                    RtcChannelEventTest.channelEventHandler?.OnChannelJoinChannelSuccess(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onRejoinChannelSuccess":
                    RtcChannelEventTest.channelEventHandler?.OnChannelReJoinChannelSuccess(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onLeaveChannel":
                    RtcChannelEventTest.channelEventHandler?.OnChannelLeaveChannel(channelId,
                        AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onClientRoleChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelClientRoleChanged(channelId,
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "oldRole"),
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "newRole"));
                    break;
                case "onUserJoined":
                    RtcChannelEventTest.channelEventHandler?.OnChannelUserJoined(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserOffline":
                    RtcChannelEventTest.channelEventHandler?.OnChannelUserOffLine(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (USER_OFFLINE_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onConnectionLost":
                    RtcChannelEventTest.channelEventHandler?.OnChannelConnectionLost(channelId);
                    break;
                case "onRequestToken":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRequestToken(channelId);
                    break;
                case "onTokenPrivilegeWillExpire":
                    RtcChannelEventTest.channelEventHandler?.OnChannelTokenPrivilegeWillExpire(channelId,
                        (string) AgoraUtil.GetData<string>(data, "token"));
                    break;
                case "onRtcStats":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRtcStats(channelId,
                        AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onNetworkQuality":
                    RtcChannelEventTest.channelEventHandler?.OnChannelNetworkQuality(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "txQuality"),
                        (int) AgoraUtil.GetData<int>(data, "rxQuality"));
                    break;
                case "onRemoteVideoStats":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRemoteVideoStats(channelId,
                        AgoraUtil.JsonToStruct<RemoteVideoStats>(data, "stats"));
                    break;
                case "onRemoteAudioStats":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRemoteAudioStats(channelId,
                        AgoraUtil.JsonToStruct<RemoteAudioStats>(data, "stats"));
                    break;
                case "onRemoteAudioStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRemoteAudioStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_AUDIO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_AUDIO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onAudioPublishStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelAudioPublishStateChanged(channelId,
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoPublishStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelVideoPublishStateChanged(channelId,
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onAudioSubscribeStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelAudioSubscribeStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoSubscribeStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelVideoSubscribeStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onUserSuperResolutionEnabled":
                    RtcChannelEventTest.channelEventHandler?.OnChannelUserSuperResolutionEnabled(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (bool) AgoraUtil.GetData<bool>(data, "enabled"),
                        (SUPER_RESOLUTION_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onActiveSpeaker":
                    RtcChannelEventTest.channelEventHandler?.OnChannelActiveSpeaker(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"));
                    break;
                case "onVideoSizeChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelVideoSizeChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"), (int) AgoraUtil.GetData<int>(data, "rotation"));
                    break;
                case "onRemoteVideoStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRemoteVideoStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_VIDEO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_VIDEO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onStreamMessageError":
                    RtcChannelEventTest.channelEventHandler?.OnChannelStreamMessageError(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "streamId"),
                        (int) AgoraUtil.GetData<int>(data, "code"), (int) AgoraUtil.GetData<int>(data, "missed"),
                        (int) AgoraUtil.GetData<int>(data, "cached"));
                    break;
                case "onChannelMediaRelayStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelMediaRelayStateChanged(channelId,
                        (CHANNEL_MEDIA_RELAY_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (CHANNEL_MEDIA_RELAY_ERROR) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onChannelMediaRelayEvent":
                    RtcChannelEventTest.channelEventHandler?.OnChannelMediaRelayEvent(channelId,
                        (CHANNEL_MEDIA_RELAY_EVENT) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onRtmpStreamingStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRtmpStreamingStateChanged(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (RTMP_STREAM_PUBLISH_ERROR) AgoraUtil.GetData<int>(data, "errCode"));
                    break;
                case "onRtmpStreamingEvent":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRtmpStreamingEvent(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAMING_EVENT) AgoraUtil.GetData<int>(data, "eventCode"));
                    break;
                case "onTranscodingUpdated":
                    RtcChannelEventTest.channelEventHandler?.OnChannelTranscodingUpdated(channelId);
                    break;
                case "onStreamInjectedStatus":
                    RtcChannelEventTest.channelEventHandler?.OnChannelStreamInjectedStatus(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"), (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "status"));
                    break;
                case "onLocalPublishFallbackToAudioOnly":
                    RtcChannelEventTest.channelEventHandler?.OnChannelLocalPublishFallbackToAudioOnly(channelId,
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
                    RtcChannelEventTest.channelEventHandler?.OnChannelRemoteSubscribeFallbackToAudioOnly(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onConnectionStateChanged":
                    RtcChannelEventTest.channelEventHandler?.OnChannelConnectionStateChanged(channelId,
                        (CONNECTION_STATE_TYPE) AgoraUtil.GetData<int>(data, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
            }
        }

        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer)
        {
            var channelId = (string) AgoraUtil.GetData<string>(data, "channelId");
            switch (@event)
            {
                case "onStreamMessage":
                    var length = (uint) AgoraUtil.GetData<uint>(data, "length");
                    var streamData = new byte[length];
                    if (buffer != IntPtr.Zero) Marshal.Copy(buffer, streamData, 0, (int) length);
                    RtcChannelEventTest.channelEventHandler?.OnChannelStreamMessage(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "streamId"),
                        streamData, length);
                    break;
            }
        }
    }
    
    public class AgoraRtcChannelEventTest : IDisposable
    {
        private IrisTestPtr _irisTest;
        internal IRtcChannelEventHandlerBase channelEventHandler;
        private IrisCEventHandler _CEventHandler;
        private bool disposed = false;

        public AgoraRtcChannelEventTest(string dumpFilePath, IRtcChannelEventHandlerBase eventHandlerBase, AgoraRtcEngine rtcEngine)
        {
            _irisTest = AgorartcNative.CreateIrisTest(dumpFilePath);
            AgorartcNative.SetProxy(_irisTest, rtcEngine.GetNativeHandler());
            NativeRtcChannelTestEventHandler.RtcChannelEventTest = this;
            channelEventHandler = eventHandlerBase;
            _CEventHandler = new IrisCEventHandler()
            {
                onEvent = NativeRtcChannelTestEventHandler.OnEvent,
                onEventWithBuffer = NativeRtcChannelTestEventHandler.OnEventWithBuffer
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            Release();

            disposed = true;
        }

        public void BeginEventTestByFile(string caseFilePath)
        {
            AgorartcNative.BeginEventTestByFile(_irisTest, caseFilePath, ref _CEventHandler);
        }

        public void BeginEventTest(string caseContent)
        {
            AgorartcNative.BeginApiTest(_irisTest, caseContent, ref _CEventHandler);
        }
        
        public void OnEventReceived(string @event, string data)
        {
            AgorartcNative.OnEventReceived(_irisTest, @event, data);
        }

        private void Release()
        {
            AgorartcNative.DestroyIrisTest(_irisTest);
            channelEventHandler = null;
            _irisTest = IntPtr.Zero;
        }

        ~AgoraRtcChannelEventTest()
        {
            Dispose(false);
        }
    }
    
    internal static class NativeRtcAudioDeviceManagerApiTestHandler
    {
        internal static AgoraRtcAudioDeviceManagerApiTest RtcAudioDeviceManagerApiTest;

        internal static void OnEvent(string @event, string data)
        {
            switch (@event)
            {
                case "onApiTest":
                    RtcAudioDeviceManagerApiTest.engineEventHandler?.OnApiTest((int) AgoraUtil.GetData<int>(data, "apiType"),
                        (string) AgoraUtil.GetData<object>(data, "params"));
                    break;
            }
        }
    }

    public class AgoraRtcAudioDeviceManagerApiTest : IDisposable
    {
        private IrisTestPtr _irisTest;
        internal IRtcEngineEventHandlerBase engineEventHandler;
        private IrisCEventHandler _CEventHandler;
        private bool disposed = false;

        public AgoraRtcAudioDeviceManagerApiTest(string dumpFilePath, IRtcEngineEventHandlerBase eventHandlerBase, AgoraRtcEngine rtcEngine)
        {
            _irisTest = AgorartcNative.CreateIrisTest(dumpFilePath);
            AgorartcNative.SetProxy(_irisTest, rtcEngine.GetNativeHandler());
            NativeRtcAudioDeviceManagerApiTestHandler.RtcAudioDeviceManagerApiTest = this;
            engineEventHandler = eventHandlerBase;
            _CEventHandler = new IrisCEventHandler()
            {
                onEvent = NativeRtcAudioDeviceManagerApiTestHandler.OnEvent
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            Release();

            disposed = true;
        }

        public void BeginApiTestByFile(string caseFilePath)
        {
            AgorartcNative.BeginApiTestByFile(_irisTest, caseFilePath, ref _CEventHandler);
        }

        public void BeginApiTest(string caseContent)
        {
            AgorartcNative.BeginApiTest(_irisTest, caseContent, ref _CEventHandler);
        }

        private void Release()
        {
            AgorartcNative.DestroyIrisTest(_irisTest);
            engineEventHandler = null;
            _irisTest = IntPtr.Zero;
        }

        ~AgoraRtcAudioDeviceManagerApiTest()
        {
            Dispose(false);
        }
    }
    
    internal static class NativeRtcVideoDeviceManagerApiTestHandler
    {
        internal static AgoraRtcVideoDeviceManagerApiTest RtcVideoDeviceManagerApiTest;

        internal static void OnEvent(string @event, string data)
        {
            switch (@event)
            {
                case "onApiTest":
                    RtcVideoDeviceManagerApiTest.engineEventHandler?.OnApiTest((int) AgoraUtil.GetData<int>(data, "apiType"),
                        (string) AgoraUtil.GetData<object>(data, "params"));
                    break;
            }
        }
    }

    public class AgoraRtcVideoDeviceManagerApiTest : IDisposable
    {
        private IrisTestPtr _irisTest;
        internal IRtcEngineEventHandlerBase engineEventHandler;
        private IrisCEventHandler _CEventHandler;
        private bool disposed = false;

        public AgoraRtcVideoDeviceManagerApiTest(string dumpFilePath, IRtcEngineEventHandlerBase eventHandlerBase, AgoraRtcEngine rtcEngine)
        {
            _irisTest = AgorartcNative.CreateIrisTest(dumpFilePath);
            AgorartcNative.SetProxy(_irisTest, rtcEngine.GetNativeHandler());
            NativeRtcVideoDeviceManagerApiTestHandler.RtcVideoDeviceManagerApiTest = this;
            engineEventHandler = eventHandlerBase;
            _CEventHandler = new IrisCEventHandler()
            {
                onEvent = NativeRtcVideoDeviceManagerApiTestHandler.OnEvent
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            Release();

            disposed = true;
        }

        public void BeginApiTestByFile(string caseFilePath)
        {
            AgorartcNative.BeginApiTestByFile(_irisTest, caseFilePath, ref _CEventHandler);
        }

        public void BeginApiTest(string caseContent)
        {
            AgorartcNative.BeginApiTest(_irisTest, caseContent, ref _CEventHandler);
        }

        private void Release()
        {
            AgorartcNative.DestroyIrisTest(_irisTest);
            engineEventHandler = null;
            _irisTest = IntPtr.Zero;
        }

        ~AgoraRtcVideoDeviceManagerApiTest()
        {
            Dispose(false);
        }
    }
}