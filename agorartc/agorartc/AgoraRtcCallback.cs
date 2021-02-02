using System;
using System.Runtime.InteropServices;

namespace agorartc
{
    [StructLayout(LayoutKind.Sequential)]
    internal class RtcEventHandler
    {
        internal FUNC_OnJoinChannelSuccess onJoinChannelSuccess;
        internal FUNC_OnReJoinChannelSuccess onReJoinChannelSuccess;
        internal FUNC_OnLeaveChannel onLeaveChannel;
        internal FUNC_OnConnectionLost onConnectionLost;
        internal FUNC_OnConnectionInterrupted onConnectionInterrupted;
        internal FUNC_OnRequestToken onRequestToken;
        internal FUNC_OnUserJoined onUserJoined;
        internal FUNC_OnUserOffline onUserOffline;
        internal FUNC_OnAudioVolumeIndication onAudioVolumeIndication;
        internal FUNC_OnUserMuteAudio onUserMuteAudio;
        internal FUNC_OnWarning onWarning;
        internal FUNC_OnError onError;
        internal FUNC_OnRtcStats onRtcStats;
        internal FUNC_OnAudioMixingFinished onAudioMixingFinished;
        internal FUNC_OnAudioRouteChanged onAudioRouteChanged;
        internal FUNC_OnFirstRemoteVideoDecoded onFirstRemoteVideoDecoded;
        internal FUNC_OnVideoSizeChanged onVideoSizeChanged;
        internal FUNC_OnClientRoleChanged onClientRoleChanged;
        internal FUNC_OnUserMuteVideo onUserMuteVideo;
        internal FUNC_OnMicrophoneEnabled onMicrophoneEnabled;
        internal FUNC_OnApiExecuted onApiCallExecuted;
        internal FUNC_OnFirstLocalAudioFrame onFirstLocalAudioFrame;
        internal FUNC_OnFirstRemoteAudioFrame onFirstRemoteAudioFrame;
        internal FUNC_OnLastmileQuality onLastmileQuality;
        internal FUNC_OnAudioQuality onAudioQuality;
        internal FUNC_OnStreamInjectedStatus onStreamInjectedStatus;
        internal FUNC_OnStreamUnpublished onStreamUnpublished;
        internal FUNC_OnStreamPublished onStreamPublished;
        internal FUNC_OnStreamMessageError onStreamMessageError;
        internal FUNC_OnStreamMessage onStreamMessage;
        internal FUNC_OnConnectionBanned onConnectionBanned;
        internal FUNC_OnRemoteVideoTransportStats onRemoteVideoTransportStats;
        internal FUNC_OnRemoteAudioTransportStats onRemoteAudioTransportStats;
        internal FUNC_OnTranscodingUpdated onTranscodingUpdated;
        internal FUNC_OnAudioDeviceVolumeChanged onAudioDeviceVolumeChanged;
        internal FUNC_OnActiveSpeaker onActiveSpeaker;
        internal FUNC_OnMediaEngineStartCallSuccess onMediaEngineStartCallSuccess;
        internal FUNC_OnMediaEngineLoadSuccess onMediaEngineLoadSuccess;
        internal FUNC_OnConnectionStateChanged onConnectionStateChanged;
        internal FUNC_OnRemoteSubscribeFallbackToAudioOnly onRemoteSubscribeFallbackToAudioOnly;
        internal FUNC_OnLocalPublishFallbackToAudioOnly onLocalPublishFallbackToAudioOnly;
        internal FUNC_OnUserEnableLocalVideo onUserEnableLocalVideo;
        internal FUNC_OnRemoteVideoStateChanged onRemoteVideoStateChanged;
        internal FUNC_OnVideoDeviceStateChanged onVideoDeviceStateChanged;
        internal FUNC_OnAudioEffectFinished onAudioEffectFinished;
        internal FUNC_OnRemoteAudioMixingEnd onRemoteAudioMixingEnd;
        internal FUNC_OnRemoteAudioMixingBegin onRemoteAudioMixingBegin;
        internal FUNC_OnCameraExposureAreaChanged onCameraExposureAreaChanged;
        internal FUNC_OnCameraFocusAreaChanged onCameraFocusAreaChanged;
        internal FUNC_OnCameraReady onCameraReady;
        internal FUNC_OnAudioDeviceStateChanged onAudioDeviceStateChanged;
        internal FUNC_OnUserEnableVideo onUserEnableVideo;
        internal FUNC_OnFirstRemoteVideoFrame onFirstRemoteVideoFrame;
        internal FUNC_OnFirstLocalVideoFrame onFirstLocalVideoFrame;
        internal FUNC_OnRemoteAudioStats onRemoteAudioStats;
        internal FUNC_OnRemoteVideoStats onRemoteVideoStats;
        internal FUNC_OnLocalVideoStats onLocalVideoStats;
        internal FUNC_OnNetworkQuality onNetworkQuality;
        internal FUNC_OnTokenPrivilegeWillExpire onTokenPrivilegeWillExpire;
        internal FUNC_OnVideoStopped onVideoStopped;
        internal FUNC_OnAudioMixingStateChanged onAudioMixingStateChanged;
        internal FUNC_OnFirstRemoteAudioDecoded onFirstRemoteAudioDecoded;
        internal FUNC_OnLocalVideoStateChanged onLocalVideoStateChanged;
        internal FUNC_OnNetworkTypeChanged onNetworkTypeChanged;
        internal FUNC_OnRtmpStreamingStateChanged onRtmpStreamingStateChanged;
        internal FUNC_OnLastmileProbeResult onLastmileProbeResult;
        internal FUNC_OnLocalUserRegistered onLocalUserRegistered;
        internal FUNC_OnUserInfoUpdated onUserInfoUpdated;
        internal FUNC_OnLocalAudioStateChanged onLocalAudioStateChanged;
        internal FUNC_OnRemoteAudioStateChanged onRemoteAudioStateChanged;
        internal FUNC_OnLocalAudioStats onLocalAudioStats;
        internal FUNC_OnChannelMediaRelayStateChanged onChannelMediaRelayStateChanged;
        internal FUNC_OnChannelMediaRelayEvent onChannelMediaRelayEvent;
        internal FUNC_OnFacePositionChanged onFacePositionChanged;
        internal FUNC_OnTestEnd onTestEnd;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class ChannelEventHandler
    {
        internal FUNC_OnChannelWarning onWarning;
        internal FUNC_OnChannelError onError;
        internal FUNC_OnChannelJoinChannelSuccess onJoinChannelSuccess;
        internal FUNC_OnChannelReJoinChannelSuccess onRejoinChannelSuccess;
        internal FUNC_OnChannelLeaveChannel onLeaveChannel;
        internal FUNC_OnChannelClientRoleChanged onClientRoleChanged;
        internal FUNC_OnChannelUserJoined onUserJoined;
        internal FUNC_OnChannelUserOffLine onUserOffLine;
        internal FUNC_OnChannelConnectionLost onConnectionLost;
        internal FUNC_OnChannelRequestToken onRequestToken;
        internal FUNC_OnChannelTokenPrivilegeWillExpire onTokenPrivilegeWillExpire;
        internal FUNC_OnChannelRtcStats onRtcStats;
        internal FUNC_OnChannelNetworkQuality onNetworkQuality;
        internal FUNC_OnChannelRemoteVideoStats onRemoteVideoStats;
        internal FUNC_OnChannelRemoteAudioStats onRemoteAudioStats;
        internal FUNC_OnChannelRemoteAudioStateChanged onRemoteAudioStateChanged;
        internal FUNC_OnChannelActiveSpeaker onActiveSpeaker;
        internal FUNC_OnChannelVideoSizeChanged onVideoSizeChanged;
        internal FUNC_OnChannelRemoteVideoStateChanged onRemoteVideoStateChanged;
        internal FUNC_OnChannelStreamMessage onStreamMessage;
        internal FUNC_OnChannelStreamMessageError onStreamMessageError;
        internal FUNC_OnChannelMediaRelayStateChanged2 onMediaRelayStateChanged;
        internal FUNC_OnChannelMediaRelayEvent2 onMediaRelayEvent;
        internal FUNC_OnChannelRtmpStreamingStateChanged onRtmpStreamingStateChanged;
        internal FUNC_OnChannelTranscodingUpdated onTranscodingUpdated;
        internal FUNC_OnChannelStreamInjectedStatus onStreamInjectedStatus;
        internal FUNC_OnChannelRemoteSubscribeFallbackToAudioOnly onRemoteSubscribeFallbackToAudioOnly;
        internal FUNC_OnChannelConnectionStateChanged onConnectionStateChanged;
        internal FUNC_OnChannelLocalPublishFallbackToAudioOnly onLocalPublishFallbackToAudioOnly;
        internal FUNC_OnChannelTestEnd onTestEnd;
    }

    public abstract class IRtcEngineEventHandlerBase
    {
        public virtual void OnJoinChannelSuccess(string namelessParameter1, uint uid, int elapsed)
        {
        }

        public virtual void OnReJoinChannelSuccess(string namelessParameter1, uint uid, int elapsed)
        {
        }

        public virtual void OnConnectionLost()
        {
        }

        public virtual void OnConnectionInterrupted()
        {
        }

        public virtual void OnLeaveChannel(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
            uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
            ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
            ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
            double cpuAppUsage,
            double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
            int memoryAppUsageInKbytes)
        {
        }

        public virtual void OnRequestToken()
        {
        }

        public virtual void OnUserJoined(uint uid, int elapsed)
        {
        }

        public virtual void OnUserOffline(uint uid, int offLineReason)
        {
        }

        public virtual void OnAudioVolumeIndication(ref uint uid, ref uint volume, ref uint vad,
            string[] channelId,
            int speakerNumber, int totalVolume)
        {
        }

        public virtual void OnUserMuteAudio(uint uid, int muted)
        {
        }

        public virtual void OnWarning(int warn, string msg)
        {
        }

        public virtual void OnError(int error, string msg)
        {
        }

        public virtual void OnRtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
            uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
            ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
            ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
            double cpuAppUsage,
            double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
            int memoryAppUsageInKbytes)
        {
        }

        public virtual void OnAudioMixingFinished()
        {
        }

        public virtual void OnAudioRouteChanged(int route)
        {
        }

        public virtual void OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed)
        {
        }

        public virtual void OnVideoSizeChanged(uint uid, int width, int height, int elapsed)
        {
        }

        public virtual void OnClientRoleChanged(int oldRole, int newRole)
        {
        }

        public virtual void OnUserMuteVideo(uint uid, int muted)
        {
        }

        public virtual void OnMicrophoneEnabled(int isEnabled)
        {
        }

        public virtual void OnApiExecuted(int err, string api, string result)
        {
        }

        public virtual void OnFirstLocalAudioFrame(int elapsed)
        {
        }

        public virtual void OnFirstRemoteAudioFrame(uint userId, int elapsed)
        {
        }

        public virtual void OnLastmileQuality(int quality)
        {
        }

        public virtual void OnAudioQuality(uint userId, int quality, ushort delay, ushort lost)
        {
        }

        public virtual void OnStreamInjectedStatus(string url, uint userId, int status)
        {
        }

        public virtual void OnStreamUnpublished(string url)
        {
        }

        public virtual void OnStreamPublished(string url, int error)
        {
        }

        public virtual void OnStreamMessageError(uint userId, int streamId, int code, int missed, int cached)
        {
        }

        public virtual void OnStreamMessage(uint userId, int streamId, string data, uint length)
        {
        }

        public virtual void OnConnectionBanned()
        {
        }


        public virtual void OnRemoteVideoTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }


        public virtual void OnRemoteAudioTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }


        public virtual void OnTranscodingUpdated()
        {
        }

        public virtual void OnAudioDeviceVolumeChanged(int deviceType, int volume, int muted)
        {
        }

        public virtual void OnActiveSpeaker(uint userId)
        {
        }

        public virtual void OnMediaEngineStartCallSuccess()
        {
        }

        public virtual void OnMediaEngineLoadSuccess()
        {
        }

        public virtual void OnVideoStopped()
        {
        }

        public virtual void OnTokenPrivilegeWillExpire(string token)
        {
        }

        public virtual void OnNetworkQuality(uint uid, int txQuality, int rxQuality)
        {
        }


        public virtual void OnLocalVideoStats(int sentBitrate, int sentFrameRate, int encoderOutputFrameRate,
            int rendererOutputFrameRate, int targetBitrate, int targetFrameRate, int qualityAdaptIndication,
            int encodedBitrate, int encodedFrameWidth, int encodedFrameHeight, int encodedFrameCount,
            int codecType)
        {
        }

        public virtual void OnRemoteVideoStats(uint uid, int delay, int width, int height,
            int receivedBitrate,
            int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate, int rxStreamType,
            int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
        }

        public virtual void OnRemoteAudioStats(uint uid, int quality, int networkTransportDelay,
            int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate,
            int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
        }

        public virtual void OnLocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate)
        {
        }

        public virtual void OnFirstLocalVideoFrame(int width, int height, int elapsed)
        {
        }

        public virtual void OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed)
        {
        }

        public virtual void OnUserEnableVideo(uint uid, int enabled)
        {
        }

        public virtual void OnAudioDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
        }

        public virtual void OnCameraReady()
        {
        }

        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
        }

        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
        }

        public virtual void OnRemoteAudioMixingBegin()
        {
        }

        public virtual void OnRemoteAudioMixingEnd()
        {
        }

        public virtual void OnAudioEffectFinished(int soundId)
        {
        }

        public virtual void OnVideoDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
        }

        public virtual void OnRemoteVideoStateChanged(uint uid, int state, int reason, int elapsed)
        {
        }

        public virtual void OnUserEnableLocalVideo(uint uid, int enabled)
        {
        }

        public virtual void OnLocalPublishFallbackToAudioOnly(int isFallbackOrRecover)
        {
        }

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, int isFallbackOrRecover)
        {
        }

        public virtual void OnConnectionStateChanged(int state, int reason)
        {
        }

        public virtual void OnRtmpStreamingStateChanged(string url, int state, int errCode)
        {
        }

        public virtual void OnLocalUserRegistered(uint uid, string userAccount)
        {
        }

        public virtual void OnUserInfoUpdated(uint uid, uint userUid, string userAccount)
        {
        }

        public virtual void OnLocalAudioStateChanged(int state, int error)
        {
        }

        public virtual void OnRemoteAudioStateChanged(uint uid, int state, int reason, int elapsed)
        {
        }

        public virtual void OnAudioMixingStateChanged(int audioMixingStateType, int audioMixingErrorType)
        {
        }

        public virtual void OnFirstRemoteAudioDecoded(uint uid, int elapsed)
        {
        }

        public virtual void OnLocalVideoStateChanged(int localVideoState, int error)
        {
        }

        public virtual void OnNetworkTypeChanged(int networkType)
        {
        }


        public virtual void OnLastmileProbeResult(int state, uint upLinkPacketLossRate, uint upLinkjitter,
            uint upLinkAvailableBandwidth, uint downLinkPacketLossRate, uint downLinkJitter,
            uint downLinkAvailableBandwidth, uint rtt)
        {
        }

        public virtual void OnChannelMediaRelayStateChanged(int state, int code)
        {
        }

        public virtual void OnChannelMediaRelayEvent(int code)
        {
        }


        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, int x, int y, int width,
            int height, int vecDistance, int numFaces)
        {
        }


        public virtual void OnTestEnd()
        {
        }
    }

    public abstract class IRtcChannelEventHandlerBase
    {
        public virtual void OnChannelWarning(string channelId, int warn, string msg)
        {
        }

        public virtual void OnChannelError(string channelId, int err, string msg)
        {
        }

        public virtual void OnChannelJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
        }

        public virtual void OnChannelReJoinChannelSuccess(string channelId, uint uid, int elapsed)
        {
        }


        public virtual void OnChannelLeaveChannel(string channelId, uint duration, uint txBytes, uint rxBytes,
            uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
            ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
            ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate,
            uint userCount,
            double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
            double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
        {
        }

        public virtual void OnChannelClientRoleChanged(string channelId, int oldRole, int newRole)
        {
        }

        public virtual void OnChannelUserJoined(string channelId, uint uid, int elapsed)
        {
        }

        public virtual void OnChannelUserOffLine(string channelId, uint uid, int reason)
        {
        }

        public virtual void OnChannelConnectionLost(string channelId)
        {
        }

        public virtual void OnChannelRequestToken(string channelId)
        {
        }

        public virtual void OnChannelTokenPrivilegeWillExpire(string channelId, string token)
        {
        }


        public virtual void OnChannelRtcStats(string channelId, uint duration, uint txBytes, uint rxBytes,
            uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
            ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
            ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate,
            uint userCount,
            double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
            double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
        {
        }

        public virtual void OnChannelNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
        {
        }


        public virtual void OnChannelRemoteVideoStats(string channelId, uint uid, int delay, int width,
            int height,
            int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
            int rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
        }

        public virtual void OnChannelRemoteAudioStats(string channelId, uint uid, int quality,
            int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels,
            int receivedSampleRate,
            int receivedBitrate, int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
        }

        public virtual void OnChannelRemoteAudioStateChanged(string channelId, uint uid, int state, int reason,
            int elapsed)
        {
        }

        public virtual void OnChannelActiveSpeaker(string channelId, uint uid)
        {
        }

        public virtual void
            OnChannelVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
        {
        }

        public virtual void OnChannelRemoteVideoStateChanged(string channelId, uint uid, int state, int reason,
            int elapsed)
        {
        }

        public virtual void
            OnChannelStreamMessage(string channelId, uint uid, int streamId, string data, uint length)
        {
        }

        public virtual void OnChannelStreamMessageError(string channelId, uint uid, int streamId, int code,
            int missed, int cached)
        {
        }

        public virtual void OnChannelMediaRelayStateChanged2(string channelId, int state, int code)
        {
        }

        public virtual void OnChannelMediaRelayEvent2(string channelId, int code)
        {
        }

        public virtual void OnChannelRtmpStreamingStateChanged(string channelId, string url, int state,
            int errCode)
        {
        }

        public virtual void OnChannelTranscodingUpdated(string channelId)
        {
        }

        public virtual void OnChannelStreamInjectedStatus(string channelId, string url, uint uid, int status)
        {
        }

        public virtual void OnChannelRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid,
            int isFallbackOrRecover)
        {
        }

        public virtual void OnChannelConnectionStateChanged(string channelId, int state, int reason)
        {
        }

        public virtual void OnChannelLocalPublishFallbackToAudioOnly(string channelId, int isFallbackOrRecover)
        {
        }

        public virtual void OnChannelTestEnd(string channelId)
        {
        }
    }
}