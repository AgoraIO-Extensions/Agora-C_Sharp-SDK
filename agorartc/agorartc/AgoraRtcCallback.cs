//
//  Created by Yiqing Huang on 2020/12/15.
//  Copyright © 2020 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agorartc
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnEvent(string @event, string data);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnEventWithBuffer(string @event, string data, IntPtr buffer);

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventHandler
    {
        internal FUNC_OnEvent onEvent;
        internal FUNC_OnEventWithBuffer onEventWithBuffer;
    }

    public abstract class IRtcEngineEventHandlerBase
    {
        public virtual void OnJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
        }

        public virtual void OnReJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
        }

        public virtual void OnConnectionLost()
        {
        }

        public virtual void OnConnectionInterrupted()
        {
        }

        public virtual void OnLeaveChannel(RtcStats stats)
        {
        }

        public virtual void OnRequestToken()
        {
        }

        public virtual void OnUserJoined(uint uid, int elapsed)
        {
        }

        public virtual void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        public virtual void OnAudioVolumeIndication(AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
        }

        public virtual void OnUserMuteAudio(uint uid, bool muted)
        {
        }

        public virtual void OnWarning(WARN_CODE_TYPE warn, string msg)
        {
        }

        public virtual void OnError(ERROR_CODE error, string msg)
        {
        }

        public virtual void OnRtcStats(RtcStats stats)
        {
        }

        public virtual void OnAudioMixingFinished()
        {
        }

        public virtual void OnAudioRouteChanged(AUDIO_ROUTE_TYPE routing)
        {
        }

        public virtual void OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed)
        {
        }

        public virtual void OnVideoSizeChanged(uint uid, int width, int height, int rotation)
        {
        }

        public virtual void OnClientRoleChanged(CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole)
        {
        }

        public virtual void OnUserMuteVideo(uint uid, bool muted)
        {
        }

        public virtual void OnMicrophoneEnabled(bool enabled)
        {
        }

        public virtual void OnApiCallExecuted(ERROR_CODE err, string api, string result)
        {
        }

        public virtual void OnFirstLocalAudioFrame(int elapsed)
        {
        }

        public virtual void OnFirstLocalAudioFramePublished(int elapsed)
        {
        }

        public virtual void OnFirstRemoteAudioFrame(uint uid, int elapsed)
        {
        }

        public virtual void OnLastmileQuality(int quality)
        {
        }

        public virtual void OnAudioQuality(uint uid, int quality, ushort delay, ushort lost)
        {
        }

        public virtual void OnStreamInjectedStatus(string url, uint uid, int status)
        {
        }

        public virtual void OnStreamUnpublished(string url)
        {
        }

        public virtual void OnStreamPublished(string url, ERROR_CODE error)
        {
        }

        public virtual void OnStreamMessageError(uint uid, int streamId, int code, int missed, int cached)
        {
        }

        public virtual void OnStreamMessage(uint uid, int streamId, byte[] data, uint length)
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

        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
        }

        public virtual void OnActiveSpeaker(uint uid)
        {
        }

        public virtual void OnMediaEngineStartCallSuccess()
        {
        }

        public virtual void OnUserSuperResolutionEnabled(uint uid, bool enabled, SUPER_RESOLUTION_STATE_REASON reason)
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


        public virtual void OnLocalVideoStats(LocalVideoStats stats)
        {
        }

        public virtual void OnRemoteVideoStats(RemoteVideoStats stats)
        {
        }

        public virtual void OnRemoteAudioStats(RemoteAudioStats stats)
        {
        }

        public virtual void OnLocalAudioStats(LocalAudioStats stats)
        {
        }

        public virtual void OnFirstLocalVideoFrame(int width, int height, int elapsed)
        {
        }

        public virtual void OnFirstLocalVideoFramePublished(int elapsed)
        {
        }

        public virtual void OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed)
        {
        }

        public virtual void OnUserEnableVideo(uint uid, bool enabled)
        {
        }

        public virtual void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType,
            MEDIA_DEVICE_STATE_TYPE deviceState)
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

        public virtual void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType,
            MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        public virtual void OnRemoteVideoStateChanged(uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnUserEnableLocalVideo(uint uid, bool enabled)
        {
        }

        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
        }

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
        }

        public virtual void OnConnectionStateChanged(CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state,
            RTMP_STREAM_PUBLISH_ERROR errCode)
        {
        }

        public virtual void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        public virtual void OnLocalUserRegistered(uint uid, string userAccount)
        {
        }

        public virtual void OnUserInfoUpdated(uint uid, UserInfo info)
        {
        }

        public virtual void OnLocalAudioStateChanged(LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
        }

        public virtual void OnRemoteAudioStateChanged(uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state,
            AUDIO_MIXING_ERROR_TYPE errorCode)
        {
        }

        public virtual void OnFirstRemoteAudioDecoded(uint uid, int elapsed)
        {
        }

        public virtual void OnLocalVideoStateChanged(LOCAL_VIDEO_STREAM_STATE localVideoState,
            LOCAL_VIDEO_STREAM_ERROR error)
        {
        }

        public virtual void OnNetworkTypeChanged(NETWORK_TYPE networkType)
        {
        }


        public virtual void OnLastmileProbeResult(LastmileProbeResult result)
        {
        }

        public virtual void OnChannelMediaRelayStateChanged(CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
        }

        public virtual void OnChannelMediaRelayEvent(CHANNEL_MEDIA_RELAY_EVENT code)
        {
        }

        public virtual void OnApiTest(int apiType, string @params)
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


        public virtual void OnChannelLeaveChannel(string channelId, RtcStats stats)
        {
        }

        public virtual void OnChannelClientRoleChanged(string channelId, CLIENT_ROLE_TYPE oldRole,
            CLIENT_ROLE_TYPE newRole)
        {
        }

        public virtual void OnChannelUserJoined(string channelId, uint uid, int elapsed)
        {
        }

        public virtual void OnChannelUserOffLine(string channelId, uint uid, USER_OFFLINE_REASON_TYPE reason)
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


        public virtual void OnChannelRtcStats(string channelId, RtcStats stats)
        {
        }

        public virtual void OnChannelNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality)
        {
        }


        public virtual void OnChannelRemoteVideoStats(string channelId, RemoteVideoStats stats)
        {
        }

        public virtual void OnChannelRemoteAudioStats(string channelId, RemoteAudioStats stats)
        {
        }

        public virtual void OnChannelRemoteAudioStateChanged(string channelId, uint uid, REMOTE_AUDIO_STATE state,
            REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnChannelAudioPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnChannelVideoPublishStateChanged(string channelId, STREAM_PUBLISH_STATE oldState,
            STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnChannelAudioSubscribeStateChanged(string channelId, uint uid,
            STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnChannelVideoSubscribeStateChanged(string channelId, uint uid,
            STREAM_SUBSCRIBE_STATE oldState,
            STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnChannelUserSuperResolutionEnabled(string channelId, uint uid, bool enabled,
            SUPER_RESOLUTION_STATE_REASON reason)
        {
        }

        public virtual void OnChannelActiveSpeaker(string channelId, uint uid)
        {
        }

        public virtual void
            OnChannelVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation)
        {
        }

        public virtual void OnChannelRemoteVideoStateChanged(string channelId, uint uid, REMOTE_VIDEO_STATE state,
            REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void
            OnChannelStreamMessage(string channelId, uint uid, int streamId, byte[] data, uint length)
        {
        }

        public virtual void OnChannelStreamMessageError(string channelId, uint uid, int streamId, int code,
            int missed, int cached)
        {
        }

        public virtual void OnChannelMediaRelayStateChanged(string channelId, CHANNEL_MEDIA_RELAY_STATE state,
            CHANNEL_MEDIA_RELAY_ERROR code)
        {
        }

        public virtual void OnChannelMediaRelayEvent(string channelId, CHANNEL_MEDIA_RELAY_EVENT code)
        {
        }

        public virtual void OnChannelRtmpStreamingStateChanged(string channelId, string url,
            RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR errCode)
        {
        }

        public virtual void OnChannelRtmpStreamingEvent(string channelId, string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        public virtual void OnChannelTranscodingUpdated(string channelId)
        {
        }

        public virtual void OnChannelStreamInjectedStatus(string channelId, string url, uint uid, int status)
        {
        }

        public virtual void OnChannelRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid,
            bool isFallbackOrRecover)
        {
        }

        public virtual void OnChannelConnectionStateChanged(string channelId, CONNECTION_STATE_TYPE state,
            CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        public virtual void OnChannelLocalPublishFallbackToAudioOnly(string channelId, bool isFallbackOrRecover)
        {
        }
        
        public virtual void OnChannelApiTest(int apiType, string @params)
        {
        }
    }
}