using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The SDK uses the IRtcEngineEventHandler interface to send event notifications to your app. Your app can get those notifications through methods that inherit this interface.
    /// </summary>
    ///
    public abstract class IRtcEngineEventHandlerBase
    {
        #region terra IRtcEngineEventHandlerBase
        public virtual void OnError(int err, string msg)
        {
        }

        public virtual void OnLastmileProbeResult(LastmileProbeResult result)
        {
        }

        public virtual void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        public virtual void OnAudioMixingPositionChanged(long position)
        {
        }

        public virtual void OnAudioEffectFinished(int soundId)
        {
        }

        public virtual void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        public virtual void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
        }

        public virtual void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
        }

        public virtual void OnLastmileQuality(int quality)
        {
        }

        public virtual void OnFirstLocalVideoFrame(VIDEO_SOURCE_TYPE source, int width, int height, int elapsed)
        {
        }

        public virtual void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR error)
        {
        }

        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
        }

        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
        }

        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle[] vecRectangle, int[] vecDistance, int numFaces)
        {
        }

        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
        }

        public virtual void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
        }

        public virtual void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
        }

        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
        }

        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
        }

        public virtual void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        public virtual void OnTranscodingUpdated()
        {
        }

        public virtual void OnAudioRoutingChanged(int routing)
        {
        }

        public virtual void OnChannelMediaRelayStateChanged(int state, int code)
        {
        }

        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
        }

        public virtual void OnPermissionError(PERMISSION_TYPE permissionType)
        {
        }

        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        public virtual void OnExtensionEvent(string provider, string extension, string key, string value)
        {
        }

        public virtual void OnExtensionStarted(string provider, string extension)
        {
        }

        public virtual void OnExtensionStopped(string provider, string extension)
        {
        }

        public virtual void OnExtensionError(string provider, string extension, int error, string message)
        {
        }
        #endregion terra IRtcEngineEventHandlerBase

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