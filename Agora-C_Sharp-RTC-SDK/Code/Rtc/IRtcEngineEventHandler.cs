using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The SDK uses the IRtcEngineEventHandler interface to send event notifications to your app. Your app can get those notifications through methods that inherit this interface.
    /// </summary>
    ///
    public abstract class IRtcEngineEventHandler
    {

        #region terra IRtcEngineEventHandler

        public virtual void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
        }

        public virtual void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
        }

        public virtual void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
        }

        public virtual void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
        }

        public virtual void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
        }

        public virtual void OnAudioMixingFinished()
        {
        }

        public virtual void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
        }

        public virtual void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
        }

        public virtual void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
        }

        public virtual void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
        }

        public virtual void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
        }

        public virtual void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        public virtual void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)
        {
        }

        public virtual void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
        }

        public virtual void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
        }

        public virtual void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
        }

        public virtual void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
        }

        public virtual void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
        }

        public virtual void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
        }

        public virtual void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
        }

        public virtual void OnCameraReady()
        {
        }

        public virtual void OnVideoStopped()
        {
        }

        public virtual void OnConnectionInterrupted(RtcConnection connection)
        {
        }

        public virtual void OnConnectionBanned(RtcConnection connection)
        {
        }

        public virtual void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
        }

        public virtual void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
        }

        public virtual void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)
        {
        }

        public virtual void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)
        {
        }

        public virtual void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        public virtual void OnActiveSpeaker(RtcConnection connection, uint uid)
        {
        }

        public virtual void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
        }

        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
        }

        public virtual void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        public virtual void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        public virtual void OnLocalUserRegistered(uint uid, string userAccount)
        {
        }

        public virtual void OnUserInfoUpdated(uint uid, UserInfo info)
        {
        }

        public virtual void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string remoteUserAccount)
        {
        }

        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoRenderingTracingResult(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
        }

        public virtual void OnLocalVideoTranscoderError(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
        }

        public virtual void OnVideoLayoutInfo(RtcConnection connection, uint uid, int width, int height, int layoutNumber, VideoLayout const* layoutlist){
 }
    #endregion terra IRtcEngineEventHandler

    #region terra IDirectCdnStreamingEventHandler

    public virtual void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
    {
    }

    public virtual void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
    {
    }
    #endregion terra IDirectCdnStreamingEventHandler
};
}