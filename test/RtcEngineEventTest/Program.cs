using System;
using System.Text.Json;
using agorartc;

namespace RtcEngineEventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var engineEventHandler = new MyEventHandler();
            var engineEventTest = new AgoraRtcEngineEventTest(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\test\\test_result\\engine_event_test_result.json",
                engineEventHandler, AgoraRtcEngine.CreateRtcEngine());
            engineEventHandler.Rtc = engineEventTest;
            engineEventTest.BeginEventTestByFile(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\iris\\case\\EventTest.json");
        }
    }

    internal class MyEventHandler : IRtcEngineEventHandlerBase
    {
        internal AgoraRtcEngineEventTest Rtc;

        public override void OnJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            var para = new
            {
                channel,
                uid,
                elapsed
            };
            Rtc.OnEventReceived("onJoinChannelSuccess", JsonSerializer.Serialize(para));
        }

        public override void OnReJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            var para = new
            {
                channel,
                uid,
                elapsed
            };
            Rtc.OnEventReceived("onRejoinChannelSuccess", JsonSerializer.Serialize(para));
        }

        public override void OnConnectionLost()
        {
            var para = new { };
            Rtc.OnEventReceived("onConnectionLost", JsonSerializer.Serialize(para));
        }

        public override void OnConnectionInterrupted()
        {
            var para = new { };
            Rtc.OnEventReceived("onConnectionInterrupted", JsonSerializer.Serialize(para));
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            var para = new
            {
                stats
            };
            Rtc.OnEventReceived("onLeaveChannel", JsonSerializer.Serialize(para));
        }

        public override void OnRequestToken()
        {
            var para = new { };
            Rtc.OnEventReceived("onRequestToken", JsonSerializer.Serialize(para));
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            var para = new
            {
                uid,
                elapsed
            };
            Rtc.OnEventReceived("onUserJoined", JsonSerializer.Serialize(para));
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            var para = new
            {
                uid,
                reason
            };
            Rtc.OnEventReceived("onUserOffline", JsonSerializer.Serialize(para));
        }

        public override void OnAudioVolumeIndication(AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            var para = new
            {
                speakers,
                speakerNumber,
                totalVolume
            };
            Rtc.OnEventReceived("onAudioVolumeIndication", JsonSerializer.Serialize(para));
        }

        public override void OnUserMuteAudio(uint uid, bool muted)
        {
            var para = new
            {
                uid,
                muted
            };
            Rtc.OnEventReceived("onUserMuteAudio", JsonSerializer.Serialize(para));
        }

        public override void OnWarning(WARN_CODE_TYPE warn, string msg)
        {
            var para = new
            {
                warn,
                msg
            };
            Rtc.OnEventReceived("onWarning", JsonSerializer.Serialize(para));
        }

        public override void OnError(ERROR_CODE error, string msg)
        {
            var para = new
            {
                err = error,
                msg
            };
            Rtc.OnEventReceived("onError", JsonSerializer.Serialize(para));
        }

        public override void OnRtcStats(RtcStats stats)
        {
            var para = new
            {
                stats
            };
            Rtc.OnEventReceived("onRtcStats", JsonSerializer.Serialize(para));
        }

        public override void OnAudioMixingFinished()
        {
            var para = new { };
            Rtc.OnEventReceived("onAudioMixingFinished", JsonSerializer.Serialize(para));
        }

        public override void OnAudioRouteChanged(AUDIO_ROUTE_TYPE routing)
        {
            var para = new
            {
                routing
            };
            Rtc.OnEventReceived("onAudioRouteChanged", JsonSerializer.Serialize(para));
        }

        public override void OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed)
        {
            var para = new
            {
                uid,
                width,
                height,
                elapsed
            };
            Rtc.OnEventReceived("onFirstRemoteVideoDecoded", JsonSerializer.Serialize(para));
        }

        public override void OnVideoSizeChanged(uint uid, int width, int height, int rotation)
        {
            var para = new
            {
                uid,
                width,
                height,
                rotation
            };
            Rtc.OnEventReceived("onVideoSizeChanged", JsonSerializer.Serialize(para));
        }

        public override void OnClientRoleChanged(CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
            var para = new
            {
                oldRole,
                newRole
            };
            Rtc.OnEventReceived("onClientRoleChanged", JsonSerializer.Serialize(para));
        }

        public override void OnUserMuteVideo(uint uid, bool muted)
        {
            var para = new
            {
                uid,
                muted
            };
            Rtc.OnEventReceived("onUserMuteVideo", JsonSerializer.Serialize(para));
        }

        public override void OnMicrophoneEnabled(bool enabled)
        {
            var para = new
            {
                enabled
            };
            Rtc.OnEventReceived("onMicrophoneEnabled", JsonSerializer.Serialize(para));
        }

        public override void OnApiCallExecuted(ERROR_CODE err, string api, string result)
        {
            var para = new
            {
                err,
                api,
                result
            };
            Rtc.OnEventReceived("onApiCallExecuted", JsonSerializer.Serialize(para));
        }

        public override void OnFirstLocalAudioFrame(int elapsed)
        {
            var para = new
            {
                elapsed
            };
            Rtc.OnEventReceived("onFirstLocalAudioFrame", JsonSerializer.Serialize(para));
        }

        public override void OnFirstLocalAudioFramePublished(int elapsed)
        {
            var para = new
            {
                elapsed
            };
            Rtc.OnEventReceived("onFirstLocalAudioFramePublished", JsonSerializer.Serialize(para));
        }

        public override void OnFirstRemoteAudioFrame(uint uid, int elapsed)
        {
            var para = new
            {
                uid,
                elapsed
            };
            Rtc.OnEventReceived("onFirstRemoteAudioFrame", JsonSerializer.Serialize(para));
        }

        public override void OnLastmileQuality(int quality)
        {
            var para = new
            {
                quality
            };
            Rtc.OnEventReceived("onLastmileQuality", JsonSerializer.Serialize(para));
        }

        public override void OnAudioQuality(uint uid, int quality, ushort delay, ushort lost)
        {
            var para = new
            {
                uid,
                quality,
                delay,
                lost
            };
            Rtc.OnEventReceived("onAudioQuality", JsonSerializer.Serialize(para));
        }

        public override void OnStreamInjectedStatus(string url, uint uid, int status)
        {
            var para = new
            {
                url,
                uid,
                status
            };
            Rtc.OnEventReceived("onStreamInjectedStatus", JsonSerializer.Serialize(para));
        }

        public override void OnStreamUnpublished(string url)
        {
            var para = new
            {
                url
            };
            Rtc.OnEventReceived("onStreamUnpublished", JsonSerializer.Serialize(para));
        }

        public override void OnStreamPublished(string url, ERROR_CODE error)
        {
            var para = new
            {
                url,
                error
            };
            Rtc.OnEventReceived("onStreamPublished", JsonSerializer.Serialize(para));
        }

        public override void OnStreamMessageError(uint uid, int streamId, int code, int missed, int cached)
        {
            var para = new
            {
                uid,
                streamId,
                code,
                missed,
                cached
            };
            Rtc.OnEventReceived("onStreamMessageError", JsonSerializer.Serialize(para));
        }

        public override void OnStreamMessage(uint uid, int streamId, byte[] data, uint length)
        {
            var para = new
            {
                uid,
                streamId,
                length
            };
            Rtc.OnEventReceived("onStreamMessage", JsonSerializer.Serialize(para));
        }

        public override void OnConnectionBanned()
        {
            var para = new { };
            Rtc.OnEventReceived("onConnectionBanned", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteVideoTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            var para = new
            {
                uid,
                delay,
                lost,
                rxKBitRate
            };
            Rtc.OnEventReceived("onRemoteVideoTransportStats", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteAudioTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            var para = new
            {
                uid,
                delay,
                lost,
                rxKBitRate
            };
            Rtc.OnEventReceived("onRemoteAudioTransportStats", JsonSerializer.Serialize(para));
        }

        public override void OnTranscodingUpdated()
        {
            var para = new { };
            Rtc.OnEventReceived("onTranscodingUpdated", JsonSerializer.Serialize(para));
        }

        public override void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
            var para = new
            {
                deviceType,
                volume,
                muted
            };
            Rtc.OnEventReceived("onAudioDeviceVolumeChanged", JsonSerializer.Serialize(para));
        }

        public override void OnActiveSpeaker(uint uid)
        {
            var para = new
            {
                uid
            };
            Rtc.OnEventReceived("onActiveSpeaker", JsonSerializer.Serialize(para));
        }

        public override void OnMediaEngineStartCallSuccess()
        {
            var para = new { };
            Rtc.OnEventReceived("onMediaEngineStartCallSuccess", JsonSerializer.Serialize(para));
        }

        public override void OnUserSuperResolutionEnabled(uint uid, bool enabled, SUPER_RESOLUTION_STATE_REASON reason)
        {
            var para = new
            {
                uid,
                enabled,
                reason
            };
            Rtc.OnEventReceived("onUserSuperResolutionEnabled", JsonSerializer.Serialize(para));
        }

        public override void OnMediaEngineLoadSuccess()
        {
            var para = new { };
            Rtc.OnEventReceived("onMediaEngineLoadSuccess", JsonSerializer.Serialize(para));
        }

        public override void OnVideoStopped()
        {
            var para = new { };
            Rtc.OnEventReceived("onVideoStopped", JsonSerializer.Serialize(para));
        }

        public override void OnTokenPrivilegeWillExpire(string token)
        {
            var para = new
            {
                token
            };
            Rtc.OnEventReceived("onTokenPrivilegeWillExpire", JsonSerializer.Serialize(para));
        }

        public override void OnNetworkQuality(uint uid, int txQuality, int rxQuality)
        {
            var para = new
            {
                uid,
                txQuality,
                rxQuality
            };
            Rtc.OnEventReceived("onNetworkQuality", JsonSerializer.Serialize(para));
        }

        public override void OnLocalVideoStats(LocalVideoStats stats)
        {
            var para = new
            {
                stats
            };
            Rtc.OnEventReceived("onLocalVideoStats", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteVideoStats(RemoteVideoStats stats)
        {
            var para = new
            {
                stats
            };
            Rtc.OnEventReceived("onRemoteVideoStats", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteAudioStats(RemoteAudioStats stats)
        {
            var para = new
            {
                stats
            };
            Rtc.OnEventReceived("onRemoteAudioStats", JsonSerializer.Serialize(para));
        }

        public override void OnLocalAudioStats(LocalAudioStats stats)
        {
            var para = new
            {
                stats
            };
            Rtc.OnEventReceived("onLocalAudioStats", JsonSerializer.Serialize(para));
        }

        public override void OnFirstLocalVideoFrame(int width, int height, int elapsed)
        {
            var para = new
            {
                width,
                height,
                elapsed
            };
            Rtc.OnEventReceived("onFirstLocalVideoFrame", JsonSerializer.Serialize(para));
        }

        public override void OnFirstLocalVideoFramePublished(int elapsed)
        {
            var para = new
            {
                elapsed
            };
            Rtc.OnEventReceived("onFirstLocalVideoFramePublished", JsonSerializer.Serialize(para));
        }

        public override void OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed)
        {
            var para = new
            {
                uid,
                width,
                height,
                elapsed
            };
            Rtc.OnEventReceived("onFirstRemoteVideoFrame", JsonSerializer.Serialize(para));
        }

        public override void OnUserEnableVideo(uint uid, bool enabled)
        {
            var para = new
            {
                uid,
                enabled
            };
            Rtc.OnEventReceived("onUserEnableVideo", JsonSerializer.Serialize(para));
        }

        public override void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType,
            MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            var para = new
            {
                deviceId,
                deviceType,
                deviceState
            };
            Rtc.OnEventReceived("onAudioDeviceStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnCameraReady()
        {
            var para = new { };
            Rtc.OnEventReceived("onCameraReady", JsonSerializer.Serialize(para));
        }

        public override void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
            var para = new
            {
                x,
                y,
                width,
                height
            };
            Rtc.OnEventReceived("onCameraFocusAreaChanged", JsonSerializer.Serialize(para));
        }

        public override void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
            var para = new
            {
                x,
                y,
                width,
                height
            };
            Rtc.OnEventReceived("onCameraExposureAreaChanged", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteAudioMixingBegin()
        {
            var para = new { };
            Rtc.OnEventReceived("onRemoteAudioMixingBegin", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteAudioMixingEnd()
        {
            var para = new { };
            Rtc.OnEventReceived("onRemoteAudioMixingEnd", JsonSerializer.Serialize(para));
        }

        public override void OnAudioEffectFinished(int soundId)
        {
            var para = new
            {
                soundId
            };
            Rtc.OnEventReceived("onAudioEffectFinished", JsonSerializer.Serialize(para));
        }

        public override void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType,
            MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            var para = new
            {
                deviceId,
                deviceType,
                deviceState
            };
            Rtc.OnEventReceived("onVideoDeviceStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteVideoStateChanged(uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            var para = new
            {
                uid,
                state,
                reason,
                elapsed
            };
            Rtc.OnEventReceived("onRemoteVideoStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnUserEnableLocalVideo(uint uid, bool enabled)
        {
            var para = new
            {
                uid,
                enabled
            };
            Rtc.OnEventReceived("onUserEnableLocalVideo", JsonSerializer.Serialize(para));
        }

        public override void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
            var para = new
            {
                isFallbackOrRecover
            };
            Rtc.OnEventReceived("onLocalPublishFallbackToAudioOnly", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
            var para = new
            {
                uid,
                isFallbackOrRecover
            };
            Rtc.OnEventReceived("onRemoteSubscribeFallbackToAudioOnly", JsonSerializer.Serialize(para));
        }

        public override void OnConnectionStateChanged(CONNECTION_STATE_TYPE state,
            CONNECTION_CHANGED_REASON_TYPE reason)
        {
            var para = new
            {
                state,
                reason
            };
            Rtc.OnEventReceived("onConnectionStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state,
            RTMP_STREAM_PUBLISH_ERROR errCode)
        {
            var para = new
            {
                url,
                state,
                errCode
            };
            Rtc.OnEventReceived("onRtmpStreamingStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnLocalUserRegistered(uint uid, string userAccount)
        {
            var para = new
            {
                uid,
                userAccount
            };
            Rtc.OnEventReceived("onLocalUserRegistered", JsonSerializer.Serialize(para));
        }

        public override void OnUserInfoUpdated(uint uid, UserInfo info)
        {
            var para = new
            {
                uid,
                info
            };
            Rtc.OnEventReceived("onUserInfoUpdated", JsonSerializer.Serialize(para));
        }

        public override void OnLocalAudioStateChanged(LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            var para = new
            {
                state,
                error
            };
            Rtc.OnEventReceived("onLocalAudioStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnRemoteAudioStateChanged(uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            var para = new
            {
                uid,
                state,
                reason,
                elapsed
            };
            Rtc.OnEventReceived("onRemoteAudioStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            var para = new
            {
                channel,
                oldState,
                newState,
                elapseSinceLastState
            };
            Rtc.OnEventReceived("onAudioPublishStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnVideoPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            var para = new
            {
                channel,
                oldState,
                newState,
                elapseSinceLastState
            };
            Rtc.OnEventReceived("onVideoPublishStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state,
            AUDIO_MIXING_ERROR_TYPE errorCode)
        {
            var para = new
            {
                state,
                errorCode
            };
            Rtc.OnEventReceived("onAudioMixingStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnFirstRemoteAudioDecoded(uint uid, int elapsed)
        {
            var para = new
            {
                uid,
                elapsed
            };
            Rtc.OnEventReceived("onFirstRemoteAudioDecoded", JsonSerializer.Serialize(para));
        }

        public override void OnLocalVideoStateChanged(LOCAL_VIDEO_STREAM_STATE localVideoState,
            LOCAL_VIDEO_STREAM_ERROR error)
        {
            var para = new
            {
                localVideoState,
                error
            };
            Rtc.OnEventReceived("onLocalVideoStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnNetworkTypeChanged(NETWORK_TYPE type)
        {
            var para = new
            {
                type
            };
            Rtc.OnEventReceived("onNetworkTypeChanged", JsonSerializer.Serialize(para));
        }

        public override void OnLastmileProbeResult(LastmileProbeResult result)
        {
            var para = new
            {
                result
            };
            Rtc.OnEventReceived("onLastmileProbeResult", JsonSerializer.Serialize(para));
        }

        public override void OnChannelMediaRelayStateChanged(CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
            var para = new
            {
                state ,
                code
            };
            Rtc.OnEventReceived("onChannelMediaRelayStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelMediaRelayEvent(CHANNEL_MEDIA_RELAY_EVENT code)
        {
            var para = new
            {
                code
            };
            Rtc.OnEventReceived("onChannelMediaRelayEvent", JsonSerializer.Serialize(para));
        }
    }
}