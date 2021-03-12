using System;
using System.Text.Json;
using agorartc;

namespace RtcChannelEventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelEventHandler = new MyEventHandler();
            var channelEventTest = new AgoraRtcChannelEventTest(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\test\\test_result\\channel_event_test_result.json",
                channelEventHandler, AgoraRtcEngine.CreateRtcEngine());
            channelEventHandler.Rtc = channelEventTest;
            channelEventTest.BeginEventTestByFile(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\iris\\case\\ChannelEventTest.json");
        }
    }

    internal class MyEventHandler : IRtcChannelEventHandlerBase
    {
        internal AgoraRtcChannelEventTest Rtc;
        
        public override void OnChannelWarning(string channelId, int warn, string msg)
        {
            var para = new
            {
                channelId,
                warn,
                msg
            };
            Rtc.OnEventReceived("onChannelWarning", JsonSerializer.Serialize(para));
        }

        public override void OnChannelError(string channelId, int err, string msg)
        {
            var para = new
            {
                channelId,
                err,
                msg
            };
            Rtc.OnEventReceived("onChannelError", JsonSerializer.Serialize(para));
        }

        public override void OnChannelJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            var para = new
            {
                channelId,
                uid,
                elapsed
            };
            Rtc.OnEventReceived("onJoinChannelSuccess", JsonSerializer.Serialize(para));
        }

        public override void OnChannelReJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            var para = new
            {
                channelId,
                uid,
                elapsed
            };
            Rtc.OnEventReceived("onRejoinChannelSuccess", JsonSerializer.Serialize(para));
        }


        public override void OnChannelLeaveChannel(string channelId, RtcStats stats)
        {
            var para = new
            {
                channelId,
                stats
            };
            Rtc.OnEventReceived("onLeaveChannel", JsonSerializer.Serialize(para));
        }

        public override void OnChannelClientRoleChanged(string channelId, CLIENT_ROLE_TYPE oldRole,
            CLIENT_ROLE_TYPE newRole)
        {
            var para = new
            {
                channelId,
                oldRole,
                newRole
            };
            Rtc.OnEventReceived("onClientRoleChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelUserJoined(string channelId, uint uid, int elapsed)
        {
            var para = new
            {
                channelId,
                uid,
                elapsed
            };
            Rtc.OnEventReceived("onUserJoined", JsonSerializer.Serialize(para));
        }

        public override void OnChannelUserOffLine(string channelId, uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            var para = new
            {
                channelId,
                uid,
                reason
            };
            Rtc.OnEventReceived("onUserOffline", JsonSerializer.Serialize(para));
        }

        public override void OnChannelConnectionLost(string channelId)
        {
            var para = new
            {
                channelId
            };
            Rtc.OnEventReceived("onConnectionLost", JsonSerializer.Serialize(para));
        }

        public override void OnChannelRequestToken(string channelId)
        {
            var para = new
            {
                channelId
            };
            Rtc.OnEventReceived("onRequestToken", JsonSerializer.Serialize(para));
        }

        public override void OnChannelTokenPrivilegeWillExpire(string channelId, string token)
        {
            var para = new
            {
                channelId,
                token
            };
            Rtc.OnEventReceived("onTokenPrivilegeWillExpire", JsonSerializer.Serialize(para));
        }


        public override void OnChannelRtcStats(string channelId, RtcStats stats)
        {
            var para = new
            {
                channelId,
                stats
            };
            Rtc.OnEventReceived("onRtcStats", JsonSerializer.Serialize(para));
        }

        public override void OnChannelNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
        {
            var para = new
            {
                channelId,
                uid,
                txQuality,
                rxQuality
            };
            Rtc.OnEventReceived("onNetworkQuality", JsonSerializer.Serialize(para));
        }


        public override void OnChannelRemoteVideoStats(string channelId, RemoteVideoStats stats)
        {
            var para = new
            {
                channelId,
                stats
            };
            Rtc.OnEventReceived("onRemoteVideoStats", JsonSerializer.Serialize(para));
        }

        public override void OnChannelRemoteAudioStats(string channelId, RemoteAudioStats stats)
        {
            var para = new
            {
                channelId,
                stats
            };
            Rtc.OnEventReceived("onRemoteAudioStats", JsonSerializer.Serialize(para));
        }

        public override void OnChannelRemoteAudioStateChanged(string channelId, uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            var para = new
            {
                channelId,
                uid,
                state,
                reason,
                elapsed
            };
            Rtc.OnEventReceived("onRemoteAudioStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelAudioPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            var para = new
            {
                channelId,
                oldState,
                newState,
                elapseSinceLastState
            };
            Rtc.OnEventReceived("onAudioPublishStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelVideoPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            var para = new
            {
                channelId,
                oldState,
                newState,
                elapseSinceLastState
            };
            Rtc.OnEventReceived("onVideoPublishStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelAudioSubscribeStateChanged(string channelId, uint uid,
            STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            var para = new
            {
                channelId,
                uid,
                oldState,
                newState,
                elapseSinceLastState
            };
            Rtc.OnEventReceived("onAudioSubscribeStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelVideoSubscribeStateChanged(string channelId, uint uid,
            STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            var para = new
            {
                channelId,
                uid,
                oldState,
                newState,
                elapseSinceLastState
            };
            Rtc.OnEventReceived("onVideoSubscribeStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelUserSuperResolutionEnabled(string channelId, uint uid, bool enabled,
            SUPER_RESOLUTION_STATE_REASON reason)
        {
            var para = new
            {
                channelId,
                uid,
                enabled,
                reason
            };
            Rtc.OnEventReceived("onUserSuperResolutionEnabled", JsonSerializer.Serialize(para));
        }

        public override void OnChannelActiveSpeaker(string channelId, uint uid)
        {
            var para = new
            {
                channelId,
                uid
            };
            Rtc.OnEventReceived("onActiveSpeaker", JsonSerializer.Serialize(para));
        }

        public override void
            OnChannelVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
        {
            var para = new
            {
                channelId,
                uid,
                width,
                height,
                rotation
            };
            Rtc.OnEventReceived("onVideoSizeChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelRemoteVideoStateChanged(string channelId, uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            var para = new
            {
                channelId,
                uid,
                state,
                reason,
                elapsed
            };
            Rtc.OnEventReceived("onRemoteVideoStateChanged", JsonSerializer.Serialize(para));
        }

        public override void
            OnChannelStreamMessage(string channelId, uint uid, int streamId, byte[] data, uint length)
        {
            var para = new
            {
                channelId,
                uid,
                streamId,
                length
            };
            Rtc.OnEventReceived("onStreamMessage", JsonSerializer.Serialize(para));
        }

        public override void OnChannelStreamMessageError(string channelId, uint uid, int streamId, int code,
            int missed, int cached)
        {
            var para = new
            {
                channelId,
                uid,
                streamId,
                code,
                missed,
                cached
            };
            Rtc.OnEventReceived("onStreamMessageError", JsonSerializer.Serialize(para));
        }

        public override void OnChannelMediaRelayStateChanged(string channelId, CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
            var para = new
            {
                channelId,
                state,
                code
            };
            Rtc.OnEventReceived("onChannelMediaRelayStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelMediaRelayEvent(string channelId, CHANNEL_MEDIA_RELAY_EVENT code)
        {
            var para = new
            {
                channelId,
                code
            };
            Rtc.OnEventReceived("onChannelMediaRelayEvent", JsonSerializer.Serialize(para));
        }

        public override void OnChannelRtmpStreamingStateChanged(string channelId, string url,
            RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR errCode)
        {
            var para = new
            {
                channelId,
                url,
                state,
                errCode
            };
            Rtc.OnEventReceived("onRtmpStreamingStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelRtmpStreamingEvent(string channelId, string url, RTMP_STREAMING_EVENT eventCode)
        {
            var para = new
            {
                channelId,
                url,
                eventCode
            };
            Rtc.OnEventReceived("onRtmpStreamingEvent", JsonSerializer.Serialize(para));
        }

        public override void OnChannelTranscodingUpdated(string channelId)
        {
            var para = new
            {
                channelId
            };
            Rtc.OnEventReceived("onTranscodingUpdated", JsonSerializer.Serialize(para));
        }

        public override void OnChannelStreamInjectedStatus(string channelId, string url, uint uid, int status)
        {
            var para = new
            {
                channelId,
                url,
                uid,
                status
            };
            Rtc.OnEventReceived("onStreamInjectedStatus", JsonSerializer.Serialize(para));
        }

        public override void OnChannelRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid,
            bool isFallbackOrRecover)
        {
            var para = new
            {
                channelId,
                uid,
                isFallbackOrRecover
            };
            Rtc.OnEventReceived("onRemoteSubscribeFallbackToAudioOnly", JsonSerializer.Serialize(para));
        }

        public override void OnChannelConnectionStateChanged(string channelId, CONNECTION_STATE_TYPE state,
            CONNECTION_CHANGED_REASON_TYPE reason)
        {
            var para = new
            {
                channelId,
                state,
                reason
            };
            Rtc.OnEventReceived("onConnectionStateChanged", JsonSerializer.Serialize(para));
        }

        public override void OnChannelLocalPublishFallbackToAudioOnly(string channelId, bool isFallbackOrRecover)
        {
            var para = new
            {
                channelId,
                isFallbackOrRecover
            };
            Rtc.OnEventReceived("onLocalPublishFallbackToAudioOnly", JsonSerializer.Serialize(para));
        }
    }
}
