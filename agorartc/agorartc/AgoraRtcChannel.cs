using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace agorartc
{
    using uid_t = UInt32;
    using view_t = IntPtr;
    using IrisChannelPtr = IntPtr;

    internal static class NativeRtcChannelEventHandler
    {
        // private static readonly Dictionary<string, AgoraRtcChannel> Channels =
        //     AgoraRtcEngine.CreateRtcEngine()._channels;

        private static readonly Dictionary<string, AgoraRtcChannel> Channels =
            new Dictionary<string, AgoraRtcChannel>();

        internal static void AddChannel(string channelId, AgoraRtcChannel _Channel)
        {
            Channels.Add(channelId, _Channel);
        }

        internal static void RemoveChannel(string channelId)
        {
            Channels.Remove(channelId);
        }

        internal static void OnEvent(string @event, string data)
        {
            var channelId = (string) AgoraUtil.GetData<string>(data, "channelId");
            switch (@event)
            {
                case "onChannelWarning":
                    Channels[channelId]?.channelEventHandler?.OnChannelWarning(channelId,
                        (int) AgoraUtil.GetData<int>(data, "warn"), (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onChannelError":
                    Channels[channelId]?.channelEventHandler?.OnChannelError(channelId,
                        (int) AgoraUtil.GetData<int>(data, "err"), (string) AgoraUtil.GetData<string>(data, "msg"));
                    break;
                case "onJoinChannelSuccess":
                    Channels[channelId]?.channelEventHandler?.OnChannelJoinChannelSuccess(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onRejoinChannelSuccess":
                    Channels[channelId]?.channelEventHandler?.OnChannelReJoinChannelSuccess(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onLeaveChannel":
                    Channels[channelId]?.channelEventHandler?.OnChannelReJoinChannelSuccess(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onClientRoleChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelClientRoleChanged(channelId,
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "oldRole"),
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(data, "newRole"));
                    break;
                case "onUserJoined":
                    Channels[channelId]?.channelEventHandler?.OnChannelUserJoined(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onUserOffline":
                    Channels[channelId]?.channelEventHandler?.OnChannelUserOffLine(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (USER_OFFLINE_REASON_TYPE) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onConnectionLost":
                    Channels[channelId]?.channelEventHandler?.OnChannelConnectionLost(channelId);
                    break;
                case "onRequestToken":
                    Channels[channelId]?.channelEventHandler?.OnChannelRequestToken(channelId);
                    break;
                case "onTokenPrivilegeWillExpire":
                    Channels[channelId]?.channelEventHandler?.OnChannelTokenPrivilegeWillExpire(channelId,
                        (string) AgoraUtil.GetData<string>(data, "token"));
                    break;
                case "onRtcStats":
                    Channels[channelId]?.channelEventHandler?.OnChannelRtcStats(channelId,
                        AgoraUtil.JsonToStruct<RtcStats>(data, "stats"));
                    break;
                case "onNetworkQuality":
                    Channels[channelId]?.channelEventHandler?.OnChannelNetworkQuality(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "txQuality"),
                        (int) AgoraUtil.GetData<int>(data, "rxQuality"));
                    break;
                case "onRemoteVideoStats":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteVideoStats(channelId,
                        AgoraUtil.JsonToStruct<RemoteVideoStats>(data, "stats"));
                    break;
                case "onRemoteAudioStats":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteAudioStats(channelId,
                        AgoraUtil.JsonToStruct<RemoteAudioStats>(data, "stats"));
                    break;
                case "onRemoteAudioStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteAudioStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_AUDIO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_AUDIO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onAudioPublishStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelAudioPublishStateChanged(channelId,
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoPublishStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelVideoPublishStateChanged(channelId,
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onAudioSubscribeStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelAudioSubscribeStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onVideoSubscribeStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelVideoSubscribeStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "oldState"),
                        (STREAM_SUBSCRIBE_STATE) AgoraUtil.GetData<int>(data, "newState"),
                        (int) AgoraUtil.GetData<int>(data, "elapseSinceLastState"));
                    break;
                case "onUserSuperResolutionEnabled":
                    Channels[channelId]?.channelEventHandler?.OnChannelUserSuperResolutionEnabled(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (bool) AgoraUtil.GetData<bool>(data, "enabled"),
                        (SUPER_RESOLUTION_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"));
                    break;
                case "onActiveSpeaker":
                    Channels[channelId]?.channelEventHandler?.OnChannelActiveSpeaker(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"));
                    break;
                case "onVideoSizeChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelVideoSizeChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "width"),
                        (int) AgoraUtil.GetData<int>(data, "height"), (int) AgoraUtil.GetData<int>(data, "rotation"));
                    break;
                case "onRemoteVideoStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteVideoStateChanged(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (REMOTE_VIDEO_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (REMOTE_VIDEO_STATE_REASON) AgoraUtil.GetData<int>(data, "reason"),
                        (int) AgoraUtil.GetData<int>(data, "elapsed"));
                    break;
                case "onStreamMessageError":
                    Channels[channelId]?.channelEventHandler?.OnChannelStreamMessageError(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "streamId"),
                        (int) AgoraUtil.GetData<int>(data, "code"), (int) AgoraUtil.GetData<int>(data, "missed"),
                        (int) AgoraUtil.GetData<int>(data, "cached"));
                    break;
                case "onChannelMediaRelayStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelMediaRelayStateChanged(channelId,
                        (CHANNEL_MEDIA_RELAY_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (CHANNEL_MEDIA_RELAY_ERROR) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onChannelMediaRelayEvent":
                    Channels[channelId]?.channelEventHandler?.OnChannelMediaRelayEvent(channelId,
                        (CHANNEL_MEDIA_RELAY_EVENT) AgoraUtil.GetData<int>(data, "code"));
                    break;
                case "onRtmpStreamingStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelRtmpStreamingStateChanged(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAM_PUBLISH_STATE) AgoraUtil.GetData<int>(data, "state"),
                        (RTMP_STREAM_PUBLISH_ERROR) AgoraUtil.GetData<int>(data, "errCode"));
                    break;
                case "onRtmpStreamingEvent":
                    Channels[channelId]?.channelEventHandler?.OnChannelRtmpStreamingEvent(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"),
                        (RTMP_STREAMING_EVENT) AgoraUtil.GetData<int>(data, "eventCode"));
                    break;
                case "onTranscodingUpdated":
                    Channels[channelId]?.channelEventHandler?.OnChannelTranscodingUpdated(channelId);
                    break;
                case "onStreamInjectedStatus":
                    Channels[channelId]?.channelEventHandler?.OnChannelStreamInjectedStatus(channelId,
                        (string) AgoraUtil.GetData<string>(data, "url"), (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (int) AgoraUtil.GetData<int>(data, "status"));
                    break;
                case "onLocalPublishFallbackToAudioOnly":
                    Channels[channelId]?.channelEventHandler?.OnChannelLocalPublishFallbackToAudioOnly(channelId,
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onRemoteSubscribeFallbackToAudioOnly":
                    Channels[channelId]?.channelEventHandler?.OnChannelRemoteSubscribeFallbackToAudioOnly(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"),
                        (bool) AgoraUtil.GetData<bool>(data, "isFallbackOrRecover"));
                    break;
                case "onConnectionStateChanged":
                    Channels[channelId]?.channelEventHandler?.OnChannelConnectionStateChanged(channelId,
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
                    Marshal.Copy(buffer, streamData, 0, (int) length);
                    Channels[channelId]?.channelEventHandler?.OnChannelStreamMessage(channelId,
                        (uint) AgoraUtil.GetData<uint>(data, "uid"), (int) AgoraUtil.GetData<int>(data, "streamId"),
                        streamData, length);
                    break;
            }
        }
    }

    public class AgoraRtcChannel : IDisposable
    {
        private IrisChannelPtr _irisChannel;
        private readonly string _channelId;
        private bool disposed = false;
        internal IRtcChannelEventHandlerBase channelEventHandler;
        private char[] result = new char[512];

        public AgoraRtcChannel(string id)
        {
            _channelId = id;
            _irisChannel = AgorartcNative.GetIrisChannel(AgorartcNative.CreateIrisEngine());
            var para = new
            {
                channelId = _channelId
            };
            AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelCreateChannel,
                JsonSerializer.Serialize(para), result);
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

            ReleaseChannel();

            disposed = true;
        }

        public void InitChannelEventHandler(IRtcChannelEventHandlerBase channelEventHandlerBase)
        {
            channelEventHandler = channelEventHandlerBase;
            NativeRtcChannelEventHandler.AddChannel(_channelId, this);
            var myHandler = new IrisCEventHandler()
            {
                onEvent = NativeRtcEngineEventHandler.OnEvent,
                onEventWithBuffer = NativeRtcEngineEventHandler.OnEventWithBuffer
            };
            SetIrisChannelEventHandler(myHandler);
        }

        private void SetIrisChannelEventHandler(IrisCEventHandler handler)
        {
            AgorartcNative.SetIrisEngineEventHandler(_irisChannel, ref handler);
        }

        public ERROR_CODE JoinChannel(string token, string info, uid_t uid, ChannelMediaOptions options)
        {
            var para = new
            {
                channelId = _channelId,
                token,
                info,
                uid,
                options
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelJoinChannel,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE JoinChannelWithUserAccount(string token, string userAccount,
            ChannelMediaOptions options)
        {
            var para = new
            {
                channelId = _channelId,
                token,
                userAccount,
                options
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelJoinChannelWithUserAccount, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE LeaveChannel()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelLeaveChannel,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE Publish()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelPublish,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE Unpublish()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelUnPublish,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public string ChannelId()
        {
            return _channelId;
        }

        public string GetCallId()
        {
            var para = new
            {
                channelId = _channelId
            };
            return AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelGetCallId,
                JsonSerializer.Serialize(para), result) != 0
                ? "GetCallId Failed."
                : new string(result[..Array.IndexOf(result, '\0')]);
        }

        public ERROR_CODE RenewToken(string token)
        {
            var para = new
            {
                channelId = _channelId,
                token
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelRenewToken,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetEncryptionSecret(string secret)
        {
            var para = new
            {
                channelId = _channelId,
                secret
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetEncryptionSecret, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetEncryptionMode(string encryptionMode)
        {
            var para = new
            {
                channelId = _channelId,
                encryptionMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetEncryptionMode, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE EnableEncryption(bool enabled, EncryptionConfig config)
        {
            var para = new
            {
                channelId = _channelId,
                enabled,
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelEnableEncryption, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE RegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var para = new
            {
                channelId = _channelId,
                type
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelRegisterMediaMetadataObserver, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE UnRegisterMediaMetadataObserver(METADATA_TYPE type)
        {
            var para = new
            {
                channelId = _channelId,
                type
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelUnRegisterMediaMetadataObserver, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE SetMaxMetadataSize(int size)
        {
            var para = new
            {
                channelId = _channelId,
                size
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetMaxMetadataSize, JsonSerializer.Serialize(para), result) * -1);
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
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApiWithBuffer(_irisChannel,
                CApiTypeChannel.kChannelSendMetadata, JsonSerializer.Serialize(para), metadata.buffer) * -1);
        }

        public ERROR_CODE SetClientRole(CLIENT_ROLE_TYPE role)
        {
            var para = new
            {
                channelId = _channelId,
                role = (int) role
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelSetClientRole,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteUserPriority(uid_t uid, PRIORITY_TYPE userPriority)
        {
            var para = new
            {
                channelId = _channelId,
                uid,
                userPriority = (int) userPriority
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteUserPriority, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteVoicePosition(uid_t uid, double pan, double gain)
        {
            var para = new
            {
                channelId = _channelId,
                uid,
                pan,
                gain
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteVoicePosition, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteRenderMode(uid_t userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                renderMode = (int) renderMode,
                mirrorMode = (int) mirrorMode
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteRenderMode, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetDefaultMuteAllRemoteAudioStreams,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetDefaultMuteAllRemoteVideoStreams,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteAllRemoteAudioStreams(bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelMuteAllRemoteAudioStreams, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AdjustUserPlaybackSignalVolume(uid_t uid, int volume)
        {
            var para = new
            {
                channelId = _channelId,
                uid,
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelAdjustUserPlaybackSignalVolume, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteRemoteAudioStream(uid_t userId, bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelMuteRemoteAudioStream, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteAllRemoteVideoStreams(bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelMuteAllRemoteVideoStreams, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE MuteRemoteVideoStream(uid_t userId, bool mute)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelMuteRemoteVideoStream, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteVideoStreamType(uid_t userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                streamType = (int) streamType
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteVideoStreamType, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            var para = new
            {
                channelId = _channelId,
                streamType = (int) streamType
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetRemoteDefaultVideoStreamType, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            var para = new
            {
                channelId = _channelId,
                url,
                transcodingEnabled
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelAddPublishStreamUrl, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE RemovePublishStreamUrl(string url)
        {
            var para = new
            {
                channelId = _channelId,
                url
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelRemovePublishStreamUrl, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetLiveTranscoding(LiveTranscoding transcoding)
        {
            var para = new
            {
                channelId = _channelId,
                transcoding
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelSetLiveTranscoding, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            var para = new
            {
                channelId = _channelId,
                url,
                config
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelAddInjectStreamUrl, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE RemoveInjectStreamUrl(string url)
        {
            var para = new
            {
                channelId = _channelId,
                url
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelRemoveInjectStreamUrl, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var para = new
            {
                channelId = _channelId,
                configuration
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelStartChannelMediaRelay, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            var para = new
            {
                channelId = _channelId,
                configuration
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelUpdateChannelMediaRelay, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopChannelMediaRelay()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelStopChannelMediaRelay, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE CreateDataStream(ref int streamId, bool reliable, bool ordered)
        {
            var para = new
            {
                channelId = _channelId,
                reliable,
                ordered
            };
            var ret = (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelCreateDataStream, JsonSerializer.Serialize(para), result) * -1);
            // TODO: (CreateDataStream) streamId = 
            return ret;
        }

        public ERROR_CODE SendStreamMessage(int streamId, byte[] data, long length)
        {
            var para = new
            {
                channelId = _channelId,
                streamId,
                length
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApiWithBuffer(_irisChannel,
                CApiTypeChannel.kChannelSendStreamMessage, JsonSerializer.Serialize(para), data) * -1);
        }

        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            var para = new
            {
                channelId = _channelId
            };
            return (CONNECTION_STATE_TYPE) AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelGetConnectionState, JsonSerializer.Serialize(para), result);
        }

        public ERROR_CODE EnableRemoteSuperResolution(uint userId, string enable)
        {
            var para = new
            {
                channelId = _channelId,
                userId,
                enable
            };
            return (ERROR_CODE) (AgorartcNative.CallIrisChannelApi(_irisChannel,
                CApiTypeChannel.kChannelEnableRemoteSuperResolution, JsonSerializer.Serialize(para), result) * -1);
        }

        private void ReleaseChannel()
        {
            var para = new
            {
                channelId = _channelId
            };
            AgorartcNative.CallIrisChannelApi(_irisChannel, CApiTypeChannel.kChannelRelease,
                JsonSerializer.Serialize(para), result);
            NativeRtcChannelEventHandler.RemoveChannel(_channelId);
            _irisChannel = IntPtr.Zero;
            channelEventHandler = null;
            AgoraRtcEngine.CreateRtcEngine().ReleaseChannel(_channelId);
        }

        ~AgoraRtcChannel()
        {
            Dispose(false);
        }
    }
}