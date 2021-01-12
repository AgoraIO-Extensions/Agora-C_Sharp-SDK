using System;
using System.Collections.Generic;

namespace agorartc
{
    using uid_t = UInt32;
    using view_t = IntPtr;
    using IRtcChannelBridge_ptr = IntPtr;

    internal class NativeRtcChannelEventHandler
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

        internal static void OnChannelWarning(string channelId, int warn, string msg)
        {
            Channels[channelId]?.channelEventHandler?.OnChannelWarning(channelId, warn, msg);
        }

        internal static void OnChannelError(string channelId, int err, string msg)
        {
            Channels[channelId]?.channelEventHandler?.OnChannelError(channelId, err, msg);
        }

        internal static void OnChannelJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            Channels[channelId]?.channelEventHandler?.OnChannelJoinChannelSuccess(channelId, uid, elapsed);
        }

        internal static void OnChannelReJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
            Channels[channelId].channelEventHandler.OnChannelReJoinChannelSuccess(channelId, uid, elapsed);
        }

        internal static void OnChannelLeaveChannel(string channelId, uint duration, uint txBytes, uint rxBytes,
            uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
            ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
            ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate,
            uint userCount,
            double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
            double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
        {
            Channels[channelId].channelEventHandler.OnChannelLeaveChannel(channelId, duration, txBytes, rxBytes,
                txAudioBytes, txVideoBytes, rxAudioBytes, rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
                txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay, txPacketLossRate, rxPacketLossRate,
                userCount, cpuAppUsage, cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
                memoryAppUsageInKbytes);
        }

        internal static void OnChannelClientRoleChanged(string channelId, int oldRole, int newRole)
        {
            Channels[channelId].channelEventHandler.OnChannelClientRoleChanged(channelId, oldRole, newRole);
        }

        internal static void OnChannelUserJoined(string channelId, uint uid, int elapsed)
        {
            Channels[channelId].channelEventHandler.OnChannelUserJoined(channelId, uid, elapsed);
        }

        internal static void OnChannelUserOffLine(string channelId, uint uid, int reason)
        {
            Channels[channelId].channelEventHandler.OnChannelUserOffLine(channelId, uid, reason);
        }

        internal static void OnChannelConnectionLost(string channelId)
        {
            Channels[channelId].channelEventHandler.OnChannelConnectionLost(channelId);
        }

        internal static void OnChannelRequestToken(string channelId)
        {
            Channels[channelId].channelEventHandler.OnChannelRequestToken(channelId);
        }

        internal static void OnChannelTokenPrivilegeWillExpire(string channelId, string token)
        {
            Channels[channelId].channelEventHandler.OnChannelTokenPrivilegeWillExpire(channelId, token);
        }

        internal static void OnChannelRtcStats(string channelId, uint duration, uint txBytes, uint rxBytes,
            uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
            ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
            ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate,
            uint userCount,
            double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
            double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
        {
            Channels[channelId].channelEventHandler.OnChannelRtcStats(channelId, duration, txBytes, rxBytes,
                txAudioBytes, txVideoBytes, rxAudioBytes, rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate,
                txAudioKBitRate, rxVideoKBitRate, txVideoKBitRate, lastmileDelay, txPacketLossRate, rxPacketLossRate,
                userCount, cpuAppUsage, cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio,
                memoryAppUsageInKbytes);
        }

        internal static void OnChannelNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
        {
            Channels[channelId].channelEventHandler.OnChannelNetworkQuality(channelId, uid, txQuality, rxQuality);
        }

        internal static void OnChannelRemoteVideoStats(string channelId, uint uid, int delay, int width,
            int height,
            int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
            int rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
            Channels[channelId].channelEventHandler.OnChannelRemoteVideoStats(channelId, uid, delay, width, height,
                receivedBitrate, decoderOutputFrameRate, rendererOutputFrameRate, packetLossRate, rxStreamType,
                totalFrozenTime, frozenRate, totalActiveTime);
        }

        internal static void OnChannelRemoteAudioStats(string channelId, uint uid, int quality,
            int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels,
            int receivedSampleRate,
            int receivedBitrate, int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
            Channels[channelId].channelEventHandler.OnChannelRemoteAudioStats(channelId, uid, quality,
                networkTransportDelay, jitterBufferDelay, audioLossRate, numChannels, receivedSampleRate,
                receivedBitrate, totalFrozenTime, frozenRate, totalActiveTime);
        }

        internal static void OnChannelRemoteAudioStateChanged(string channelId, uint uid, int state, int reason,
            int elapsed)
        {
            Channels[channelId].channelEventHandler
                .OnChannelRemoteAudioStateChanged(channelId, uid, state, reason, elapsed);
        }

        internal static void OnChannelActiveSpeaker(string channelId, uint uid)
        {
            Channels[channelId].channelEventHandler.OnChannelActiveSpeaker(channelId, uid);
        }

        internal static void
            OnChannelVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
        {
            Channels[channelId].channelEventHandler.OnChannelVideoSizeChanged(channelId, uid, width, height, rotation);
        }

        internal static void OnChannelRemoteVideoStateChanged(string channelId, uint uid, int state, int reason,
            int elapsed)
        {
            Channels[channelId].channelEventHandler
                .OnChannelRemoteVideoStateChanged(channelId, uid, state, reason, elapsed);
        }

        internal static void
            OnChannelStreamMessage(string channelId, uint uid, int streamId, string data, uint length)
        {
            Channels[channelId].channelEventHandler.OnChannelStreamMessage(channelId, uid, streamId, data, length);
        }

        internal static void OnChannelStreamMessageError(string channelId, uint uid, int streamId, int code,
            int missed, int cached)
        {
            Channels[channelId].channelEventHandler
                .OnChannelStreamMessageError(channelId, uid, streamId, code, missed, cached);
        }

        internal static void OnChannelMediaRelayStateChanged2(string channelId, int state, int code)
        {
            Channels[channelId].channelEventHandler.OnChannelMediaRelayStateChanged2(channelId, state, code);
        }

        internal static void OnChannelMediaRelayEvent2(string channelId, int code)
        {
            Channels[channelId].channelEventHandler.OnChannelMediaRelayEvent2(channelId, code);
        }

        internal static void OnChannelRtmpStreamingStateChanged(string channelId, string url, int state,
            int errCode)
        {
            Channels[channelId].channelEventHandler.OnChannelRtmpStreamingStateChanged(channelId, url, state, errCode);
        }

        internal static void OnChannelTranscodingUpdated(string channelId)
        {
            Channels[channelId].channelEventHandler.OnChannelTranscodingUpdated(channelId);
        }

        internal static void OnChannelStreamInjectedStatus(string channelId, string url, uint uid, int status)
        {
            Channels[channelId].channelEventHandler.OnChannelStreamInjectedStatus(channelId, url, uid, status);
        }

        internal static void OnChannelRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid,
            int isFallbackOrRecover)
        {
            Channels[channelId].channelEventHandler
                .OnChannelRemoteSubscribeFallbackToAudioOnly(channelId, uid, isFallbackOrRecover);
        }

        internal static void OnChannelConnectionStateChanged(string channelId, int state, int reason)
        {
            Channels[channelId].channelEventHandler.OnChannelConnectionStateChanged(channelId, state, reason);
        }

        internal static void OnChannelLocalPublishFallbackToAudioOnly(string channelId, int isFallbackOrRecover)
        {
            Channels[channelId].channelEventHandler
                .OnChannelLocalPublishFallbackToAudioOnly(channelId, isFallbackOrRecover);
        }

        internal static void OnChannelTestEnd(string channelId)
        {
            Channels[channelId].channelEventHandler.OnChannelTestEnd(channelId);
        }
    }

    public class AgoraRtcChannel : IDisposable
    {
        private IRtcChannelBridge_ptr _channelHandler;
        private readonly string _channelId;
        private bool disposed = false;
        internal IRtcChannelEventHandlerBase channelEventHandler;

        public AgoraRtcChannel(IRtcChannelBridge_ptr handler, string id)
        {
            _channelHandler = handler;
            _channelId = id;
            NativeRtcChannelEventHandler.AddChannel(id, this);
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

            channel_remove_C_ChannelEventHandler();
            ReleaseChannel();

            disposed = true;
        }

        public void InitChannelEventHandler(IRtcChannelEventHandlerBase channelEventHandlerBase)
        {
            channelEventHandler = channelEventHandlerBase;
            var myHandler = new ChannelEventHandler
            {
                onWarning = NativeRtcChannelEventHandler.OnChannelWarning,
                onError = NativeRtcChannelEventHandler.OnChannelWarning,
                onJoinChannelSuccess = NativeRtcChannelEventHandler.OnChannelJoinChannelSuccess,
                onRejoinChannelSuccess = NativeRtcChannelEventHandler.OnChannelReJoinChannelSuccess,
                onLeaveChannel = NativeRtcChannelEventHandler.OnChannelLeaveChannel,
                onClientRoleChanged = NativeRtcChannelEventHandler.OnChannelClientRoleChanged,
                onUserJoined = NativeRtcChannelEventHandler.OnChannelUserJoined,
                onUserOffLine = NativeRtcChannelEventHandler.OnChannelUserOffLine,
                onConnectionLost = NativeRtcChannelEventHandler.OnChannelConnectionLost,
                onRequestToken = NativeRtcChannelEventHandler.OnChannelRequestToken,
                onTokenPrivilegeWillExpire = NativeRtcChannelEventHandler.OnChannelTokenPrivilegeWillExpire,
                onRtcStats = NativeRtcChannelEventHandler.OnChannelRtcStats,
                onNetworkQuality = NativeRtcChannelEventHandler.OnChannelNetworkQuality,
                onRemoteVideoStats = NativeRtcChannelEventHandler.OnChannelRemoteVideoStats,
                onRemoteAudioStats = NativeRtcChannelEventHandler.OnChannelRemoteAudioStats,
                onRemoteAudioStateChanged = NativeRtcChannelEventHandler.OnChannelRemoteAudioStateChanged,
                onActiveSpeaker = NativeRtcChannelEventHandler.OnChannelActiveSpeaker,
                onVideoSizeChanged = NativeRtcChannelEventHandler.OnChannelVideoSizeChanged,
                onRemoteVideoStateChanged = NativeRtcChannelEventHandler.OnChannelRemoteVideoStateChanged,
                onStreamMessage = NativeRtcChannelEventHandler.OnChannelStreamMessage,
                onStreamMessageError = NativeRtcChannelEventHandler.OnChannelStreamMessageError,
                onMediaRelayStateChanged = NativeRtcChannelEventHandler.OnChannelMediaRelayStateChanged2,
                onMediaRelayEvent = NativeRtcChannelEventHandler.OnChannelMediaRelayEvent2,
                onRtmpStreamingStateChanged = NativeRtcChannelEventHandler.OnChannelRtmpStreamingStateChanged,
                onTranscodingUpdated = NativeRtcChannelEventHandler.OnChannelTranscodingUpdated,
                onStreamInjectedStatus = NativeRtcChannelEventHandler.OnChannelStreamInjectedStatus,
                onRemoteSubscribeFallbackToAudioOnly =
                    NativeRtcChannelEventHandler.OnChannelRemoteSubscribeFallbackToAudioOnly,
                onConnectionStateChanged = NativeRtcChannelEventHandler.OnChannelConnectionStateChanged,
                onLocalPublishFallbackToAudioOnly =
                    NativeRtcChannelEventHandler.OnChannelLocalPublishFallbackToAudioOnly,
                onTestEnd = NativeRtcChannelEventHandler.OnChannelTestEnd
            };
            channel_add_C_ChannelEventHandler(myHandler);
        }

        private void channel_add_C_ChannelEventHandler(ChannelEventHandler channelEventHandler)
        {
            AgorartcNative.channel_add_C_ChannelEventHandler(_channelHandler, channelEventHandler);
        }

        private void channel_remove_C_ChannelEventHandler()
        {
            AgorartcNative.channel_remove_C_ChannelEventHandler(_channelHandler);
        }

        public ERROR_CODE channel_joinChannel(string token, string info, uid_t uid, ChannelMediaOptions options)
        {
            return AgorartcNative.channel_joinChannel(_channelHandler, token, info, uid, options);
        }

        public ERROR_CODE channel_joinChannelWithUserAccount(string token, string userAccount,
            ChannelMediaOptions options)
        {
            return AgorartcNative.channel_joinChannelWithUserAccount(_channelHandler, token, userAccount, options);
        }

        public ERROR_CODE channel_leaveChannel()
        {
            return AgorartcNative.channel_leaveChannel(_channelHandler);
        }

        public ERROR_CODE channel_publish()
        {
            return AgorartcNative.channel_publish(_channelHandler);
        }

        public ERROR_CODE channel_unpublish()
        {
            return AgorartcNative.channel_unpublish(_channelHandler);
        }

        public string channel_channelId()
        {
            return AgorartcNative.channel_channelId(_channelHandler);
        }

        public string channel_getCallId()
        {
            return AgorartcNative.channel_getCallId(_channelHandler);
        }

        public ERROR_CODE channel_renewToken(string token)
        {
            return AgorartcNative.channel_renewToken(_channelHandler, token);
        }

        public ERROR_CODE channel_setEncryptionSecret(string secret)
        {
            return AgorartcNative.channel_setEncryptionSecret(_channelHandler, secret);
        }

        public ERROR_CODE channel_setEncryptionMode(string encryptionMode)
        {
            return AgorartcNative.channel_setEncryptionMode(_channelHandler, encryptionMode);
        }

        public ERROR_CODE channel_setClientRole(CLIENT_ROLE_TYPE role)
        {
            return AgorartcNative.channel_setClientRole(_channelHandler, role);
        }

        public ERROR_CODE channel_setRemoteUserPriority(uid_t uid, PRIORITY_TYPE userPriority)
        {
            return AgorartcNative.channel_setRemoteUserPriority(_channelHandler, uid, userPriority);
        }

        public ERROR_CODE channel_setRemoteVoicePosition(uid_t uid, double pan, double gain)
        {
            return AgorartcNative.channel_setRemoteVoicePosition(_channelHandler, uid, pan, gain);
        }

        public ERROR_CODE channel_setRemoteRenderMode(uid_t userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return AgorartcNative.channel_setRemoteRenderMode(_channelHandler, userId, renderMode, mirrorMode);
        }

        public ERROR_CODE channel_setDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            return AgorartcNative.channel_setDefaultMuteAllRemoteAudioStreams(_channelHandler, mute ? 1 : 0);
        }

        public ERROR_CODE channel_setDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            return AgorartcNative.channel_setDefaultMuteAllRemoteVideoStreams(_channelHandler, mute ? 1 : 0);
        }

        public ERROR_CODE channel_muteAllRemoteAudioStreams(bool mute)
        {
            return AgorartcNative.channel_muteAllRemoteAudioStreams(_channelHandler, mute ? 1 : 0);
        }

        public ERROR_CODE channel_adjustUserPlaybackSignalVolume(uid_t userId, int volume)
        {
            return AgorartcNative.channel_adjustUserPlaybackSignalVolume(_channelHandler, userId, volume);
        }

        public ERROR_CODE channel_muteRemoteAudioStream(uid_t userId, bool mute)
        {
            return AgorartcNative.channel_muteRemoteAudioStream(_channelHandler, userId, mute ? 1 : 0);
        }

        public ERROR_CODE channel_muteAllRemoteVideoStreams(bool mute)
        {
            return AgorartcNative.channel_muteAllRemoteVideoStreams(_channelHandler, mute ? 1 : 0);
        }

        public ERROR_CODE channel_muteRemoteVideoStream(uid_t userId, bool mute)
        {
            return AgorartcNative.channel_muteRemoteVideoStream(_channelHandler, userId, mute ? 1 : 0);
        }

        public ERROR_CODE channel_setRemoteVideoStreamType(uid_t userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            return AgorartcNative.channel_setRemoteVideoStreamType(_channelHandler, userId, streamType);
        }

        public ERROR_CODE channel_setRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            return AgorartcNative.channel_setRemoteDefaultVideoStreamType(_channelHandler, streamType);
        }

        public ERROR_CODE channel_addPublishStreamUrl(string url, bool transcodingEnabled)
        {
            return AgorartcNative.channel_addPublishStreamUrl(_channelHandler, url, transcodingEnabled ? 1 : 0);
        }

        public ERROR_CODE channel_removePublishStreamUrl(string url)
        {
            return AgorartcNative.channel_removePublishStreamUrl(_channelHandler, url);
        }

        public ERROR_CODE channel_setLiveTranscoding(ref LiveTranscoding transcoding)
        {
            return AgorartcNative.channel_setLiveTranscoding(_channelHandler, ref transcoding);
        }

        public ERROR_CODE channel_addInjectStreamUrl(string url, InjectStreamConfig config)
        {
            return AgorartcNative.channel_addInjectStreamUrl(_channelHandler, url, config);
        }

        public ERROR_CODE channel_removeInjectStreamUrl(string url)
        {
            return AgorartcNative.channel_removeInjectStreamUrl(_channelHandler, url);
        }

        public ERROR_CODE channel_startChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return AgorartcNative.channel_startChannelMediaRelay(_channelHandler, configuration);
        }

        public ERROR_CODE channel_updateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return AgorartcNative.channel_updateChannelMediaRelay(_channelHandler, configuration);
        }

        public ERROR_CODE channel_stopChannelMediaRelay()
        {
            return AgorartcNative.channel_stopChannelMediaRelay(_channelHandler);
        }

        public ERROR_CODE channel_createDataStream(IntPtr streamId, bool reliable, bool ordered)
        {
            return AgorartcNative.channel_createDataStream(_channelHandler, streamId, reliable ? 1 : 0,
                ordered ? 1 : 0);
        }

        public ERROR_CODE channel_sendStreamMessage(int streamId, string data, long length)
        {
            return AgorartcNative.channel_sendStreamMessage(_channelHandler, streamId, data, length);
        }

        public CONNECTION_STATE_TYPE channel_getConnectionState()
        {
            return AgorartcNative.channel_getConnectionState(_channelHandler);
        }

        public void ReleaseChannel()
        {
            AgorartcNative.releaseChannel(_channelHandler);
            NativeRtcChannelEventHandler.RemoveChannel(_channelId);
            _channelHandler = IntPtr.Zero;
            channelEventHandler = null;
            AgoraRtcEngine.CreateRtcEngine().ReleaseChannel(_channelId);
        }

        ~AgoraRtcChannel()
        {
            Dispose(false);
        }
    }
}