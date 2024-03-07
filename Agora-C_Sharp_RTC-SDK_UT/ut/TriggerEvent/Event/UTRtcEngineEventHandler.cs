using System;
using uid_t = System.UInt32;
namespace Agora.Rtc.Ut
{
    public class UTRtcEngineEventHandler : IRtcEngineEventHandler
    {

        #region terra IRtcEngineEventHandler
        public bool OnProxyConnected_be_trigger = false;
        public string OnProxyConnected_channel;
        public uint OnProxyConnected_uid;
        public PROXY_TYPE OnProxyConnected_proxyType;
        public string OnProxyConnected_localProxyIp;
        public int OnProxyConnected_elapsed;
        public override void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            OnProxyConnected_be_trigger = true;
            OnProxyConnected_channel = channel;
            OnProxyConnected_uid = uid;
            OnProxyConnected_proxyType = proxyType;
            OnProxyConnected_localProxyIp = localProxyIp;
            OnProxyConnected_elapsed = elapsed;
        }

        public bool OnProxyConnectedPassed(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            if (OnProxyConnected_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnProxyConnected_channel, channel) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnProxyConnected_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<PROXY_TYPE>(OnProxyConnected_proxyType, proxyType) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnProxyConnected_localProxyIp, localProxyIp) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnProxyConnected_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnError_be_trigger = false;
        public int OnError_err;
        public string OnError_msg;
        public override void OnError(int err, string msg)
        {
            OnError_be_trigger = true;
            OnError_err = err;
            OnError_msg = msg;
        }

        public bool OnErrorPassed(int err, string msg)
        {
            if (OnError_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<int>(OnError_err, err) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnError_msg, msg) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLastmileProbeResult_be_trigger = false;
        public LastmileProbeResult OnLastmileProbeResult_result;
        public override void OnLastmileProbeResult(LastmileProbeResult result)
        {
            OnLastmileProbeResult_be_trigger = true;
            OnLastmileProbeResult_result = result;
        }

        public bool OnLastmileProbeResultPassed(LastmileProbeResult result)
        {
            if (OnLastmileProbeResult_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<LastmileProbeResult>(OnLastmileProbeResult_result, result) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioDeviceStateChanged_be_trigger = false;
        public string OnAudioDeviceStateChanged_deviceId;
        public MEDIA_DEVICE_TYPE OnAudioDeviceStateChanged_deviceType;
        public MEDIA_DEVICE_STATE_TYPE OnAudioDeviceStateChanged_deviceState;
        public override void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            OnAudioDeviceStateChanged_be_trigger = true;
            OnAudioDeviceStateChanged_deviceId = deviceId;
            OnAudioDeviceStateChanged_deviceType = deviceType;
            OnAudioDeviceStateChanged_deviceState = deviceState;
        }

        public bool OnAudioDeviceStateChangedPassed(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            if (OnAudioDeviceStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnAudioDeviceStateChanged_deviceId, deviceId) == false)
            //return false;
            //if (ParamsHelper.Compare<MEDIA_DEVICE_TYPE>(OnAudioDeviceStateChanged_deviceType, deviceType) == false)
            //return false;
            //if (ParamsHelper.Compare<MEDIA_DEVICE_STATE_TYPE>(OnAudioDeviceStateChanged_deviceState, deviceState) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioMixingPositionChanged_be_trigger = false;
        public long OnAudioMixingPositionChanged_position;
        public override void OnAudioMixingPositionChanged(long position)
        {
            OnAudioMixingPositionChanged_be_trigger = true;
            OnAudioMixingPositionChanged_position = position;
        }

        public bool OnAudioMixingPositionChangedPassed(long position)
        {
            if (OnAudioMixingPositionChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<long>(OnAudioMixingPositionChanged_position, position) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioMixingFinished_be_trigger = false;
        public override void OnAudioMixingFinished()
        {
            OnAudioMixingFinished_be_trigger = true;
        }

        public bool OnAudioMixingFinishedPassed()
        {
            if (OnAudioMixingFinished_be_trigger == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnAudioEffectFinished_be_trigger = false;
        public int OnAudioEffectFinished_soundId;
        public override void OnAudioEffectFinished(int soundId)
        {
            OnAudioEffectFinished_be_trigger = true;
            OnAudioEffectFinished_soundId = soundId;
        }

        public bool OnAudioEffectFinishedPassed(int soundId)
        {
            if (OnAudioEffectFinished_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<int>(OnAudioEffectFinished_soundId, soundId) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnVideoDeviceStateChanged_be_trigger = false;
        public string OnVideoDeviceStateChanged_deviceId;
        public MEDIA_DEVICE_TYPE OnVideoDeviceStateChanged_deviceType;
        public MEDIA_DEVICE_STATE_TYPE OnVideoDeviceStateChanged_deviceState;
        public override void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            OnVideoDeviceStateChanged_be_trigger = true;
            OnVideoDeviceStateChanged_deviceId = deviceId;
            OnVideoDeviceStateChanged_deviceType = deviceType;
            OnVideoDeviceStateChanged_deviceState = deviceState;
        }

        public bool OnVideoDeviceStateChangedPassed(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
            if (OnVideoDeviceStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnVideoDeviceStateChanged_deviceId, deviceId) == false)
            //return false;
            //if (ParamsHelper.Compare<MEDIA_DEVICE_TYPE>(OnVideoDeviceStateChanged_deviceType, deviceType) == false)
            //return false;
            //if (ParamsHelper.Compare<MEDIA_DEVICE_STATE_TYPE>(OnVideoDeviceStateChanged_deviceState, deviceState) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUplinkNetworkInfoUpdated_be_trigger = false;
        public UplinkNetworkInfo OnUplinkNetworkInfoUpdated_info;
        public override void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
            OnUplinkNetworkInfoUpdated_be_trigger = true;
            OnUplinkNetworkInfoUpdated_info = info;
        }

        public bool OnUplinkNetworkInfoUpdatedPassed(UplinkNetworkInfo info)
        {
            if (OnUplinkNetworkInfoUpdated_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<UplinkNetworkInfo>(OnUplinkNetworkInfoUpdated_info, info) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnDownlinkNetworkInfoUpdated_be_trigger = false;
        public DownlinkNetworkInfo OnDownlinkNetworkInfoUpdated_info;
        public override void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
            OnDownlinkNetworkInfoUpdated_be_trigger = true;
            OnDownlinkNetworkInfoUpdated_info = info;
        }

        public bool OnDownlinkNetworkInfoUpdatedPassed(DownlinkNetworkInfo info)
        {
            if (OnDownlinkNetworkInfoUpdated_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<DownlinkNetworkInfo>(OnDownlinkNetworkInfoUpdated_info, info) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLastmileQuality_be_trigger = false;
        public int OnLastmileQuality_quality;
        public override void OnLastmileQuality(int quality)
        {
            OnLastmileQuality_be_trigger = true;
            OnLastmileQuality_quality = quality;
        }

        public bool OnLastmileQualityPassed(int quality)
        {
            if (OnLastmileQuality_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<int>(OnLastmileQuality_quality, quality) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnFirstLocalVideoFrame_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnFirstLocalVideoFrame_source;
        public int OnFirstLocalVideoFrame_width;
        public int OnFirstLocalVideoFrame_height;
        public int OnFirstLocalVideoFrame_elapsed;
        public override void OnFirstLocalVideoFrame(VIDEO_SOURCE_TYPE source, int width, int height, int elapsed)
        {
            OnFirstLocalVideoFrame_be_trigger = true;
            OnFirstLocalVideoFrame_source = source;
            OnFirstLocalVideoFrame_width = width;
            OnFirstLocalVideoFrame_height = height;
            OnFirstLocalVideoFrame_elapsed = elapsed;
        }

        public bool OnFirstLocalVideoFramePassed(VIDEO_SOURCE_TYPE source, int width, int height, int elapsed)
        {
            if (OnFirstLocalVideoFrame_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnFirstLocalVideoFrame_source, source) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstLocalVideoFrame_width, width) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstLocalVideoFrame_height, height) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstLocalVideoFrame_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLocalVideoStateChanged_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnLocalVideoStateChanged_source;
        public LOCAL_VIDEO_STREAM_STATE OnLocalVideoStateChanged_state;
        public LOCAL_VIDEO_STREAM_REASON OnLocalVideoStateChanged_reason;
        public override void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
        {
            OnLocalVideoStateChanged_be_trigger = true;
            OnLocalVideoStateChanged_source = source;
            OnLocalVideoStateChanged_state = state;
            OnLocalVideoStateChanged_reason = reason;
        }

        public bool OnLocalVideoStateChangedPassed(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
        {
            if (OnLocalVideoStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnLocalVideoStateChanged_source, source) == false)
            //return false;
            //if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_STATE>(OnLocalVideoStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_REASON>(OnLocalVideoStateChanged_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnCameraReady_be_trigger = false;
        public override void OnCameraReady()
        {
            OnCameraReady_be_trigger = true;
        }

        public bool OnCameraReadyPassed()
        {
            if (OnCameraReady_be_trigger == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnCameraFocusAreaChanged_be_trigger = false;
        public int OnCameraFocusAreaChanged_x;
        public int OnCameraFocusAreaChanged_y;
        public int OnCameraFocusAreaChanged_width;
        public int OnCameraFocusAreaChanged_height;
        public override void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
            OnCameraFocusAreaChanged_be_trigger = true;
            OnCameraFocusAreaChanged_x = x;
            OnCameraFocusAreaChanged_y = y;
            OnCameraFocusAreaChanged_width = width;
            OnCameraFocusAreaChanged_height = height;
        }

        public bool OnCameraFocusAreaChangedPassed(int x, int y, int width, int height)
        {
            if (OnCameraFocusAreaChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<int>(OnCameraFocusAreaChanged_x, x) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnCameraFocusAreaChanged_y, y) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnCameraFocusAreaChanged_width, width) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnCameraFocusAreaChanged_height, height) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnCameraExposureAreaChanged_be_trigger = false;
        public int OnCameraExposureAreaChanged_x;
        public int OnCameraExposureAreaChanged_y;
        public int OnCameraExposureAreaChanged_width;
        public int OnCameraExposureAreaChanged_height;
        public override void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
            OnCameraExposureAreaChanged_be_trigger = true;
            OnCameraExposureAreaChanged_x = x;
            OnCameraExposureAreaChanged_y = y;
            OnCameraExposureAreaChanged_width = width;
            OnCameraExposureAreaChanged_height = height;
        }

        public bool OnCameraExposureAreaChangedPassed(int x, int y, int width, int height)
        {
            if (OnCameraExposureAreaChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<int>(OnCameraExposureAreaChanged_x, x) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnCameraExposureAreaChanged_y, y) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnCameraExposureAreaChanged_width, width) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnCameraExposureAreaChanged_height, height) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnFacePositionChanged_be_trigger = false;
        public int OnFacePositionChanged_imageWidth;
        public int OnFacePositionChanged_imageHeight;
        public Rectangle[] OnFacePositionChanged_vecRectangle;
        public int[] OnFacePositionChanged_vecDistance;
        public int OnFacePositionChanged_numFaces;
        public override void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle[] vecRectangle, int[] vecDistance, int numFaces)
        {
            OnFacePositionChanged_be_trigger = true;
            OnFacePositionChanged_imageWidth = imageWidth;
            OnFacePositionChanged_imageHeight = imageHeight;
            OnFacePositionChanged_vecRectangle = vecRectangle;
            OnFacePositionChanged_vecDistance = vecDistance;
            OnFacePositionChanged_numFaces = numFaces;
        }

        public bool OnFacePositionChangedPassed(int imageWidth, int imageHeight, Rectangle[] vecRectangle, int[] vecDistance, int numFaces)
        {
            if (OnFacePositionChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<int>(OnFacePositionChanged_imageWidth, imageWidth) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFacePositionChanged_imageHeight, imageHeight) == false)
            //return false;
            //if (ParamsHelper.Compare<Rectangle[]>(OnFacePositionChanged_vecRectangle, vecRectangle) == false)
            //return false;
            //if (ParamsHelper.Compare<int[]>(OnFacePositionChanged_vecDistance, vecDistance) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFacePositionChanged_numFaces, numFaces) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnVideoStopped_be_trigger = false;
        public override void OnVideoStopped()
        {
            OnVideoStopped_be_trigger = true;
        }

        public bool OnVideoStoppedPassed()
        {
            if (OnVideoStopped_be_trigger == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnAudioMixingStateChanged_be_trigger = false;
        public AUDIO_MIXING_STATE_TYPE OnAudioMixingStateChanged_state;
        public AUDIO_MIXING_REASON_TYPE OnAudioMixingStateChanged_reason;
        public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
            OnAudioMixingStateChanged_be_trigger = true;
            OnAudioMixingStateChanged_state = state;
            OnAudioMixingStateChanged_reason = reason;
        }

        public bool OnAudioMixingStateChangedPassed(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
            if (OnAudioMixingStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<AUDIO_MIXING_STATE_TYPE>(OnAudioMixingStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<AUDIO_MIXING_REASON_TYPE>(OnAudioMixingStateChanged_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRhythmPlayerStateChanged_be_trigger = false;
        public RHYTHM_PLAYER_STATE_TYPE OnRhythmPlayerStateChanged_state;
        public RHYTHM_PLAYER_REASON OnRhythmPlayerStateChanged_reason;
        public override void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_REASON reason)
        {
            OnRhythmPlayerStateChanged_be_trigger = true;
            OnRhythmPlayerStateChanged_state = state;
            OnRhythmPlayerStateChanged_reason = reason;
        }

        public bool OnRhythmPlayerStateChangedPassed(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_REASON reason)
        {
            if (OnRhythmPlayerStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RHYTHM_PLAYER_STATE_TYPE>(OnRhythmPlayerStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<RHYTHM_PLAYER_REASON>(OnRhythmPlayerStateChanged_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnContentInspectResult_be_trigger = false;
        public CONTENT_INSPECT_RESULT OnContentInspectResult_result;
        public override void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
            OnContentInspectResult_be_trigger = true;
            OnContentInspectResult_result = result;
        }

        public bool OnContentInspectResultPassed(CONTENT_INSPECT_RESULT result)
        {
            if (OnContentInspectResult_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<CONTENT_INSPECT_RESULT>(OnContentInspectResult_result, result) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioDeviceVolumeChanged_be_trigger = false;
        public MEDIA_DEVICE_TYPE OnAudioDeviceVolumeChanged_deviceType;
        public int OnAudioDeviceVolumeChanged_volume;
        public bool OnAudioDeviceVolumeChanged_muted;
        public override void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
            OnAudioDeviceVolumeChanged_be_trigger = true;
            OnAudioDeviceVolumeChanged_deviceType = deviceType;
            OnAudioDeviceVolumeChanged_volume = volume;
            OnAudioDeviceVolumeChanged_muted = muted;
        }

        public bool OnAudioDeviceVolumeChangedPassed(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
            if (OnAudioDeviceVolumeChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<MEDIA_DEVICE_TYPE>(OnAudioDeviceVolumeChanged_deviceType, deviceType) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnAudioDeviceVolumeChanged_volume, volume) == false)
            //return false;
            //if (ParamsHelper.Compare<bool>(OnAudioDeviceVolumeChanged_muted, muted) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRtmpStreamingStateChanged_be_trigger = false;
        public string OnRtmpStreamingStateChanged_url;
        public RTMP_STREAM_PUBLISH_STATE OnRtmpStreamingStateChanged_state;
        public RTMP_STREAM_PUBLISH_REASON OnRtmpStreamingStateChanged_reason;
        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_REASON reason)
        {
            OnRtmpStreamingStateChanged_be_trigger = true;
            OnRtmpStreamingStateChanged_url = url;
            OnRtmpStreamingStateChanged_state = state;
            OnRtmpStreamingStateChanged_reason = reason;
        }

        public bool OnRtmpStreamingStateChangedPassed(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_REASON reason)
        {
            if (OnRtmpStreamingStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnRtmpStreamingStateChanged_url, url) == false)
            //return false;
            //if (ParamsHelper.Compare<RTMP_STREAM_PUBLISH_STATE>(OnRtmpStreamingStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<RTMP_STREAM_PUBLISH_REASON>(OnRtmpStreamingStateChanged_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRtmpStreamingEvent_be_trigger = false;
        public string OnRtmpStreamingEvent_url;
        public RTMP_STREAMING_EVENT OnRtmpStreamingEvent_eventCode;
        public override void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
            OnRtmpStreamingEvent_be_trigger = true;
            OnRtmpStreamingEvent_url = url;
            OnRtmpStreamingEvent_eventCode = eventCode;
        }

        public bool OnRtmpStreamingEventPassed(string url, RTMP_STREAMING_EVENT eventCode)
        {
            if (OnRtmpStreamingEvent_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnRtmpStreamingEvent_url, url) == false)
            //return false;
            //if (ParamsHelper.Compare<RTMP_STREAMING_EVENT>(OnRtmpStreamingEvent_eventCode, eventCode) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnTranscodingUpdated_be_trigger = false;
        public override void OnTranscodingUpdated()
        {
            OnTranscodingUpdated_be_trigger = true;
        }

        public bool OnTranscodingUpdatedPassed()
        {
            if (OnTranscodingUpdated_be_trigger == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnAudioRoutingChanged_be_trigger = false;
        public int OnAudioRoutingChanged_routing;
        public override void OnAudioRoutingChanged(int routing)
        {
            OnAudioRoutingChanged_be_trigger = true;
            OnAudioRoutingChanged_routing = routing;
        }

        public bool OnAudioRoutingChangedPassed(int routing)
        {
            if (OnAudioRoutingChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<int>(OnAudioRoutingChanged_routing, routing) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnChannelMediaRelayStateChanged_be_trigger = false;
        public int OnChannelMediaRelayStateChanged_state;
        public int OnChannelMediaRelayStateChanged_code;
        public override void OnChannelMediaRelayStateChanged(int state, int code)
        {
            OnChannelMediaRelayStateChanged_be_trigger = true;
            OnChannelMediaRelayStateChanged_state = state;
            OnChannelMediaRelayStateChanged_code = code;
        }

        public bool OnChannelMediaRelayStateChangedPassed(int state, int code)
        {
            if (OnChannelMediaRelayStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<int>(OnChannelMediaRelayStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnChannelMediaRelayStateChanged_code, code) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLocalPublishFallbackToAudioOnly_be_trigger = false;
        public bool OnLocalPublishFallbackToAudioOnly_isFallbackOrRecover;
        public override void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
            OnLocalPublishFallbackToAudioOnly_be_trigger = true;
            OnLocalPublishFallbackToAudioOnly_isFallbackOrRecover = isFallbackOrRecover;
        }

        public bool OnLocalPublishFallbackToAudioOnlyPassed(bool isFallbackOrRecover)
        {
            if (OnLocalPublishFallbackToAudioOnly_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<bool>(OnLocalPublishFallbackToAudioOnly_isFallbackOrRecover, isFallbackOrRecover) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRemoteSubscribeFallbackToAudioOnly_be_trigger = false;
        public uint OnRemoteSubscribeFallbackToAudioOnly_uid;
        public bool OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover;
        public override void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
            OnRemoteSubscribeFallbackToAudioOnly_be_trigger = true;
            OnRemoteSubscribeFallbackToAudioOnly_uid = uid;
            OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover = isFallbackOrRecover;
        }

        public bool OnRemoteSubscribeFallbackToAudioOnlyPassed(uint uid, bool isFallbackOrRecover)
        {
            if (OnRemoteSubscribeFallbackToAudioOnly_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<uint>(OnRemoteSubscribeFallbackToAudioOnly_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<bool>(OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover, isFallbackOrRecover) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnPermissionError_be_trigger = false;
        public PERMISSION_TYPE OnPermissionError_permissionType;
        public override void OnPermissionError(PERMISSION_TYPE permissionType)
        {
            OnPermissionError_be_trigger = true;
            OnPermissionError_permissionType = permissionType;
        }

        public bool OnPermissionErrorPassed(PERMISSION_TYPE permissionType)
        {
            if (OnPermissionError_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<PERMISSION_TYPE>(OnPermissionError_permissionType, permissionType) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLocalUserRegistered_be_trigger = false;
        public uint OnLocalUserRegistered_uid;
        public string OnLocalUserRegistered_userAccount;
        public override void OnLocalUserRegistered(uint uid, string userAccount)
        {
            OnLocalUserRegistered_be_trigger = true;
            OnLocalUserRegistered_uid = uid;
            OnLocalUserRegistered_userAccount = userAccount;
        }

        public bool OnLocalUserRegisteredPassed(uint uid, string userAccount)
        {
            if (OnLocalUserRegistered_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<uint>(OnLocalUserRegistered_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnLocalUserRegistered_userAccount, userAccount) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserInfoUpdated_be_trigger = false;
        public uint OnUserInfoUpdated_uid;
        public UserInfo OnUserInfoUpdated_info;
        public override void OnUserInfoUpdated(uint uid, UserInfo info)
        {
            OnUserInfoUpdated_be_trigger = true;
            OnUserInfoUpdated_uid = uid;
            OnUserInfoUpdated_info = info;
        }

        public bool OnUserInfoUpdatedPassed(uint uid, UserInfo info)
        {
            if (OnUserInfoUpdated_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<uint>(OnUserInfoUpdated_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<UserInfo>(OnUserInfoUpdated_info, info) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLocalVideoTranscoderError_be_trigger = false;
        public TranscodingVideoStream OnLocalVideoTranscoderError_stream;
        public VIDEO_TRANSCODER_ERROR OnLocalVideoTranscoderError_error;
        public override void OnLocalVideoTranscoderError(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
            OnLocalVideoTranscoderError_be_trigger = true;
            OnLocalVideoTranscoderError_stream = stream;
            OnLocalVideoTranscoderError_error = error;
        }

        public bool OnLocalVideoTranscoderErrorPassed(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
            if (OnLocalVideoTranscoderError_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<TranscodingVideoStream>(OnLocalVideoTranscoderError_stream, stream) == false)
            //return false;
            //if (ParamsHelper.Compare<VIDEO_TRANSCODER_ERROR>(OnLocalVideoTranscoderError_error, error) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioSubscribeStateChanged_be_trigger = false;
        public string OnAudioSubscribeStateChanged_channel;
        public uint OnAudioSubscribeStateChanged_uid;
        public STREAM_SUBSCRIBE_STATE OnAudioSubscribeStateChanged_oldState;
        public STREAM_SUBSCRIBE_STATE OnAudioSubscribeStateChanged_newState;
        public int OnAudioSubscribeStateChanged_elapseSinceLastState;
        public override void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            OnAudioSubscribeStateChanged_be_trigger = true;
            OnAudioSubscribeStateChanged_channel = channel;
            OnAudioSubscribeStateChanged_uid = uid;
            OnAudioSubscribeStateChanged_oldState = oldState;
            OnAudioSubscribeStateChanged_newState = newState;
            OnAudioSubscribeStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnAudioSubscribeStateChangedPassed(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (OnAudioSubscribeStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnAudioSubscribeStateChanged_channel, channel) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnAudioSubscribeStateChanged_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnAudioSubscribeStateChanged_oldState, oldState) == false)
            //return false;
            //if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnAudioSubscribeStateChanged_newState, newState) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnAudioSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnVideoSubscribeStateChanged_be_trigger = false;
        public string OnVideoSubscribeStateChanged_channel;
        public uint OnVideoSubscribeStateChanged_uid;
        public STREAM_SUBSCRIBE_STATE OnVideoSubscribeStateChanged_oldState;
        public STREAM_SUBSCRIBE_STATE OnVideoSubscribeStateChanged_newState;
        public int OnVideoSubscribeStateChanged_elapseSinceLastState;
        public override void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            OnVideoSubscribeStateChanged_be_trigger = true;
            OnVideoSubscribeStateChanged_channel = channel;
            OnVideoSubscribeStateChanged_uid = uid;
            OnVideoSubscribeStateChanged_oldState = oldState;
            OnVideoSubscribeStateChanged_newState = newState;
            OnVideoSubscribeStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnVideoSubscribeStateChangedPassed(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (OnVideoSubscribeStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnVideoSubscribeStateChanged_channel, channel) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnVideoSubscribeStateChanged_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnVideoSubscribeStateChanged_oldState, oldState) == false)
            //return false;
            //if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnVideoSubscribeStateChanged_newState, newState) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnVideoSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioPublishStateChanged_be_trigger = false;
        public string OnAudioPublishStateChanged_channel;
        public STREAM_PUBLISH_STATE OnAudioPublishStateChanged_oldState;
        public STREAM_PUBLISH_STATE OnAudioPublishStateChanged_newState;
        public int OnAudioPublishStateChanged_elapseSinceLastState;
        public override void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            OnAudioPublishStateChanged_be_trigger = true;
            OnAudioPublishStateChanged_channel = channel;
            OnAudioPublishStateChanged_oldState = oldState;
            OnAudioPublishStateChanged_newState = newState;
            OnAudioPublishStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnAudioPublishStateChangedPassed(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            if (OnAudioPublishStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnAudioPublishStateChanged_channel, channel) == false)
            //return false;
            //if (ParamsHelper.Compare<STREAM_PUBLISH_STATE>(OnAudioPublishStateChanged_oldState, oldState) == false)
            //return false;
            //if (ParamsHelper.Compare<STREAM_PUBLISH_STATE>(OnAudioPublishStateChanged_newState, newState) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnAudioPublishStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnVideoPublishStateChanged_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnVideoPublishStateChanged_source;
        public string OnVideoPublishStateChanged_channel;
        public STREAM_PUBLISH_STATE OnVideoPublishStateChanged_oldState;
        public STREAM_PUBLISH_STATE OnVideoPublishStateChanged_newState;
        public int OnVideoPublishStateChanged_elapseSinceLastState;
        public override void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            OnVideoPublishStateChanged_be_trigger = true;
            OnVideoPublishStateChanged_source = source;
            OnVideoPublishStateChanged_channel = channel;
            OnVideoPublishStateChanged_oldState = oldState;
            OnVideoPublishStateChanged_newState = newState;
            OnVideoPublishStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnVideoPublishStateChangedPassed(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
            if (OnVideoPublishStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnVideoPublishStateChanged_source, source) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnVideoPublishStateChanged_channel, channel) == false)
            //return false;
            //if (ParamsHelper.Compare<STREAM_PUBLISH_STATE>(OnVideoPublishStateChanged_oldState, oldState) == false)
            //return false;
            //if (ParamsHelper.Compare<STREAM_PUBLISH_STATE>(OnVideoPublishStateChanged_newState, newState) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnVideoPublishStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnExtensionEvent_be_trigger = false;
        public string OnExtensionEvent_provider;
        public string OnExtensionEvent_extension;
        public string OnExtensionEvent_key;
        public string OnExtensionEvent_value;
        public override void OnExtensionEvent(string provider, string extension, string key, string value)
        {
            OnExtensionEvent_be_trigger = true;
            OnExtensionEvent_provider = provider;
            OnExtensionEvent_extension = extension;
            OnExtensionEvent_key = key;
            OnExtensionEvent_value = value;
        }

        public bool OnExtensionEventPassed(string provider, string extension, string key, string value)
        {
            if (OnExtensionEvent_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnExtensionEvent_provider, provider) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnExtensionEvent_extension, extension) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnExtensionEvent_key, key) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnExtensionEvent_value, value) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnExtensionStarted_be_trigger = false;
        public string OnExtensionStarted_provider;
        public string OnExtensionStarted_extension;
        public override void OnExtensionStarted(string provider, string extension)
        {
            OnExtensionStarted_be_trigger = true;
            OnExtensionStarted_provider = provider;
            OnExtensionStarted_extension = extension;
        }

        public bool OnExtensionStartedPassed(string provider, string extension)
        {
            if (OnExtensionStarted_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnExtensionStarted_provider, provider) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnExtensionStarted_extension, extension) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnExtensionStopped_be_trigger = false;
        public string OnExtensionStopped_provider;
        public string OnExtensionStopped_extension;
        public override void OnExtensionStopped(string provider, string extension)
        {
            OnExtensionStopped_be_trigger = true;
            OnExtensionStopped_provider = provider;
            OnExtensionStopped_extension = extension;
        }

        public bool OnExtensionStoppedPassed(string provider, string extension)
        {
            if (OnExtensionStopped_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnExtensionStopped_provider, provider) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnExtensionStopped_extension, extension) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnExtensionError_be_trigger = false;
        public string OnExtensionError_provider;
        public string OnExtensionError_extension;
        public int OnExtensionError_error;
        public string OnExtensionError_message;
        public override void OnExtensionError(string provider, string extension, int error, string message)
        {
            OnExtensionError_be_trigger = true;
            OnExtensionError_provider = provider;
            OnExtensionError_extension = extension;
            OnExtensionError_error = error;
            OnExtensionError_message = message;
        }

        public bool OnExtensionErrorPassed(string provider, string extension, int error, string message)
        {
            if (OnExtensionError_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnExtensionError_provider, provider) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnExtensionError_extension, extension) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnExtensionError_error, error) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnExtensionError_message, message) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnJoinChannelSuccess_be_trigger = false;
        public RtcConnection OnJoinChannelSuccess_connection;
        public int OnJoinChannelSuccess_elapsed;
        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            OnJoinChannelSuccess_be_trigger = true;
            OnJoinChannelSuccess_connection = connection;
            OnJoinChannelSuccess_elapsed = elapsed;
        }

        public bool OnJoinChannelSuccessPassed(RtcConnection connection, int elapsed)
        {
            if (OnJoinChannelSuccess_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnJoinChannelSuccess_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnJoinChannelSuccess_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRejoinChannelSuccess_be_trigger = false;
        public RtcConnection OnRejoinChannelSuccess_connection;
        public int OnRejoinChannelSuccess_elapsed;
        public override void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            OnRejoinChannelSuccess_be_trigger = true;
            OnRejoinChannelSuccess_connection = connection;
            OnRejoinChannelSuccess_elapsed = elapsed;
        }

        public bool OnRejoinChannelSuccessPassed(RtcConnection connection, int elapsed)
        {
            if (OnRejoinChannelSuccess_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRejoinChannelSuccess_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnRejoinChannelSuccess_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioQuality_be_trigger = false;
        public RtcConnection OnAudioQuality_connection;
        public uint OnAudioQuality_remoteUid;
        public int OnAudioQuality_quality;
        public ushort OnAudioQuality_delay;
        public ushort OnAudioQuality_lost;
        public override void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
            OnAudioQuality_be_trigger = true;
            OnAudioQuality_connection = connection;
            OnAudioQuality_remoteUid = remoteUid;
            OnAudioQuality_quality = quality;
            OnAudioQuality_delay = delay;
            OnAudioQuality_lost = lost;
        }

        public bool OnAudioQualityPassed(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
            if (OnAudioQuality_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnAudioQuality_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnAudioQuality_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnAudioQuality_quality, quality) == false)
            //return false;
            //if (ParamsHelper.Compare<ushort>(OnAudioQuality_delay, delay) == false)
            //return false;
            //if (ParamsHelper.Compare<ushort>(OnAudioQuality_lost, lost) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioVolumeIndication_be_trigger = false;
        public RtcConnection OnAudioVolumeIndication_connection;
        public AudioVolumeInfo[] OnAudioVolumeIndication_speakers;
        public uint OnAudioVolumeIndication_speakerNumber;
        public int OnAudioVolumeIndication_totalVolume;
        public override void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            OnAudioVolumeIndication_be_trigger = true;
            OnAudioVolumeIndication_connection = connection;
            OnAudioVolumeIndication_speakers = speakers;
            OnAudioVolumeIndication_speakerNumber = speakerNumber;
            OnAudioVolumeIndication_totalVolume = totalVolume;
        }

        public bool OnAudioVolumeIndicationPassed(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
            if (OnAudioVolumeIndication_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnAudioVolumeIndication_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<AudioVolumeInfo[]>(OnAudioVolumeIndication_speakers, speakers) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnAudioVolumeIndication_speakerNumber, speakerNumber) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnAudioVolumeIndication_totalVolume, totalVolume) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLeaveChannel_be_trigger = false;
        public RtcConnection OnLeaveChannel_connection;
        public RtcStats OnLeaveChannel_stats;
        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            OnLeaveChannel_be_trigger = true;
            OnLeaveChannel_connection = connection;
            OnLeaveChannel_stats = stats;
        }

        public bool OnLeaveChannelPassed(RtcConnection connection, RtcStats stats)
        {
            if (OnLeaveChannel_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnLeaveChannel_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<RtcStats>(OnLeaveChannel_stats, stats) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRtcStats_be_trigger = false;
        public RtcConnection OnRtcStats_connection;
        public RtcStats OnRtcStats_stats;
        public override void OnRtcStats(RtcConnection connection, RtcStats stats)
        {
            OnRtcStats_be_trigger = true;
            OnRtcStats_connection = connection;
            OnRtcStats_stats = stats;
        }

        public bool OnRtcStatsPassed(RtcConnection connection, RtcStats stats)
        {
            if (OnRtcStats_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRtcStats_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<RtcStats>(OnRtcStats_stats, stats) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnNetworkQuality_be_trigger = false;
        public RtcConnection OnNetworkQuality_connection;
        public uint OnNetworkQuality_remoteUid;
        public int OnNetworkQuality_txQuality;
        public int OnNetworkQuality_rxQuality;
        public override void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
            OnNetworkQuality_be_trigger = true;
            OnNetworkQuality_connection = connection;
            OnNetworkQuality_remoteUid = remoteUid;
            OnNetworkQuality_txQuality = txQuality;
            OnNetworkQuality_rxQuality = rxQuality;
        }

        public bool OnNetworkQualityPassed(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
            if (OnNetworkQuality_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnNetworkQuality_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnNetworkQuality_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnNetworkQuality_txQuality, txQuality) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnNetworkQuality_rxQuality, rxQuality) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnIntraRequestReceived_be_trigger = false;
        public RtcConnection OnIntraRequestReceived_connection;
        public override void OnIntraRequestReceived(RtcConnection connection)
        {
            OnIntraRequestReceived_be_trigger = true;
            OnIntraRequestReceived_connection = connection;
        }

        public bool OnIntraRequestReceivedPassed(RtcConnection connection)
        {
            if (OnIntraRequestReceived_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnIntraRequestReceived_connection, connection) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnFirstLocalVideoFramePublished_be_trigger = false;
        public RtcConnection OnFirstLocalVideoFramePublished_connection;
        public int OnFirstLocalVideoFramePublished_elapsed;
        public override void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)
        {
            OnFirstLocalVideoFramePublished_be_trigger = true;
            OnFirstLocalVideoFramePublished_connection = connection;
            OnFirstLocalVideoFramePublished_elapsed = elapsed;
        }

        public bool OnFirstLocalVideoFramePublishedPassed(RtcConnection connection, int elapsed)
        {
            if (OnFirstLocalVideoFramePublished_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnFirstLocalVideoFramePublished_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstLocalVideoFramePublished_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnFirstRemoteVideoDecoded_be_trigger = false;
        public RtcConnection OnFirstRemoteVideoDecoded_connection;
        public uint OnFirstRemoteVideoDecoded_remoteUid;
        public int OnFirstRemoteVideoDecoded_width;
        public int OnFirstRemoteVideoDecoded_height;
        public int OnFirstRemoteVideoDecoded_elapsed;
        public override void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoDecoded_be_trigger = true;
            OnFirstRemoteVideoDecoded_connection = connection;
            OnFirstRemoteVideoDecoded_remoteUid = remoteUid;
            OnFirstRemoteVideoDecoded_width = width;
            OnFirstRemoteVideoDecoded_height = height;
            OnFirstRemoteVideoDecoded_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoDecodedPassed(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoDecoded_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteVideoDecoded_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnFirstRemoteVideoDecoded_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_width, width) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_height, height) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnVideoSizeChanged_be_trigger = false;
        public RtcConnection OnVideoSizeChanged_connection;
        public VIDEO_SOURCE_TYPE OnVideoSizeChanged_sourceType;
        public uint OnVideoSizeChanged_uid;
        public int OnVideoSizeChanged_width;
        public int OnVideoSizeChanged_height;
        public int OnVideoSizeChanged_rotation;
        public override void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
            OnVideoSizeChanged_be_trigger = true;
            OnVideoSizeChanged_connection = connection;
            OnVideoSizeChanged_sourceType = sourceType;
            OnVideoSizeChanged_uid = uid;
            OnVideoSizeChanged_width = width;
            OnVideoSizeChanged_height = height;
            OnVideoSizeChanged_rotation = rotation;
        }

        public bool OnVideoSizeChangedPassed(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
            if (OnVideoSizeChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnVideoSizeChanged_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnVideoSizeChanged_sourceType, sourceType) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnVideoSizeChanged_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnVideoSizeChanged_width, width) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnVideoSizeChanged_height, height) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnVideoSizeChanged_rotation, rotation) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLocalVideoStateChanged2_be_trigger = false;
        public RtcConnection OnLocalVideoStateChanged2_connection;
        public LOCAL_VIDEO_STREAM_STATE OnLocalVideoStateChanged2_state;
        public LOCAL_VIDEO_STREAM_REASON OnLocalVideoStateChanged2_reason;
        public override void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
        {
            OnLocalVideoStateChanged2_be_trigger = true;
            OnLocalVideoStateChanged2_connection = connection;
            OnLocalVideoStateChanged2_state = state;
            OnLocalVideoStateChanged2_reason = reason;
        }

        public bool OnLocalVideoStateChanged2Passed(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_REASON reason)
        {
            if (OnLocalVideoStateChanged2_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnLocalVideoStateChanged2_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_STATE>(OnLocalVideoStateChanged2_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_REASON>(OnLocalVideoStateChanged2_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRemoteVideoStateChanged_be_trigger = false;
        public RtcConnection OnRemoteVideoStateChanged_connection;
        public uint OnRemoteVideoStateChanged_remoteUid;
        public REMOTE_VIDEO_STATE OnRemoteVideoStateChanged_state;
        public REMOTE_VIDEO_STATE_REASON OnRemoteVideoStateChanged_reason;
        public int OnRemoteVideoStateChanged_elapsed;
        public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            OnRemoteVideoStateChanged_be_trigger = true;
            OnRemoteVideoStateChanged_connection = connection;
            OnRemoteVideoStateChanged_remoteUid = remoteUid;
            OnRemoteVideoStateChanged_state = state;
            OnRemoteVideoStateChanged_reason = reason;
            OnRemoteVideoStateChanged_elapsed = elapsed;
        }

        public bool OnRemoteVideoStateChangedPassed(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteVideoStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoStateChanged_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnRemoteVideoStateChanged_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<REMOTE_VIDEO_STATE>(OnRemoteVideoStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<REMOTE_VIDEO_STATE_REASON>(OnRemoteVideoStateChanged_reason, reason) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnRemoteVideoStateChanged_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnFirstRemoteVideoFrame_be_trigger = false;
        public RtcConnection OnFirstRemoteVideoFrame_connection;
        public uint OnFirstRemoteVideoFrame_remoteUid;
        public int OnFirstRemoteVideoFrame_width;
        public int OnFirstRemoteVideoFrame_height;
        public int OnFirstRemoteVideoFrame_elapsed;
        public override void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoFrame_be_trigger = true;
            OnFirstRemoteVideoFrame_connection = connection;
            OnFirstRemoteVideoFrame_remoteUid = remoteUid;
            OnFirstRemoteVideoFrame_width = width;
            OnFirstRemoteVideoFrame_height = height;
            OnFirstRemoteVideoFrame_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoFramePassed(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoFrame_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteVideoFrame_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnFirstRemoteVideoFrame_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_width, width) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_height, height) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserJoined_be_trigger = false;
        public RtcConnection OnUserJoined_connection;
        public uint OnUserJoined_remoteUid;
        public int OnUserJoined_elapsed;
        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            OnUserJoined_be_trigger = true;
            OnUserJoined_connection = connection;
            OnUserJoined_remoteUid = remoteUid;
            OnUserJoined_elapsed = elapsed;
        }

        public bool OnUserJoinedPassed(RtcConnection connection, uint remoteUid, int elapsed)
        {
            if (OnUserJoined_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUserJoined_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserJoined_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnUserJoined_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserOffline_be_trigger = false;
        public RtcConnection OnUserOffline_connection;
        public uint OnUserOffline_remoteUid;
        public USER_OFFLINE_REASON_TYPE OnUserOffline_reason;
        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            OnUserOffline_be_trigger = true;
            OnUserOffline_connection = connection;
            OnUserOffline_remoteUid = remoteUid;
            OnUserOffline_reason = reason;
        }

        public bool OnUserOfflinePassed(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            if (OnUserOffline_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUserOffline_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserOffline_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<USER_OFFLINE_REASON_TYPE>(OnUserOffline_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserMuteAudio_be_trigger = false;
        public RtcConnection OnUserMuteAudio_connection;
        public uint OnUserMuteAudio_remoteUid;
        public bool OnUserMuteAudio_muted;
        public override void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)
        {
            OnUserMuteAudio_be_trigger = true;
            OnUserMuteAudio_connection = connection;
            OnUserMuteAudio_remoteUid = remoteUid;
            OnUserMuteAudio_muted = muted;
        }

        public bool OnUserMuteAudioPassed(RtcConnection connection, uint remoteUid, bool muted)
        {
            if (OnUserMuteAudio_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUserMuteAudio_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserMuteAudio_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<bool>(OnUserMuteAudio_muted, muted) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserMuteVideo_be_trigger = false;
        public RtcConnection OnUserMuteVideo_connection;
        public uint OnUserMuteVideo_remoteUid;
        public bool OnUserMuteVideo_muted;
        public override void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
            OnUserMuteVideo_be_trigger = true;
            OnUserMuteVideo_connection = connection;
            OnUserMuteVideo_remoteUid = remoteUid;
            OnUserMuteVideo_muted = muted;
        }

        public bool OnUserMuteVideoPassed(RtcConnection connection, uint remoteUid, bool muted)
        {
            if (OnUserMuteVideo_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUserMuteVideo_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserMuteVideo_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<bool>(OnUserMuteVideo_muted, muted) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserEnableVideo_be_trigger = false;
        public RtcConnection OnUserEnableVideo_connection;
        public uint OnUserEnableVideo_remoteUid;
        public bool OnUserEnableVideo_enabled;
        public override void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            OnUserEnableVideo_be_trigger = true;
            OnUserEnableVideo_connection = connection;
            OnUserEnableVideo_remoteUid = remoteUid;
            OnUserEnableVideo_enabled = enabled;
        }

        public bool OnUserEnableVideoPassed(RtcConnection connection, uint remoteUid, bool enabled)
        {
            if (OnUserEnableVideo_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUserEnableVideo_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserEnableVideo_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<bool>(OnUserEnableVideo_enabled, enabled) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserEnableLocalVideo_be_trigger = false;
        public RtcConnection OnUserEnableLocalVideo_connection;
        public uint OnUserEnableLocalVideo_remoteUid;
        public bool OnUserEnableLocalVideo_enabled;
        public override void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
            OnUserEnableLocalVideo_be_trigger = true;
            OnUserEnableLocalVideo_connection = connection;
            OnUserEnableLocalVideo_remoteUid = remoteUid;
            OnUserEnableLocalVideo_enabled = enabled;
        }

        public bool OnUserEnableLocalVideoPassed(RtcConnection connection, uint remoteUid, bool enabled)
        {
            if (OnUserEnableLocalVideo_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUserEnableLocalVideo_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserEnableLocalVideo_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<bool>(OnUserEnableLocalVideo_enabled, enabled) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserStateChanged_be_trigger = false;
        public RtcConnection OnUserStateChanged_connection;
        public uint OnUserStateChanged_remoteUid;
        public uint OnUserStateChanged_state;
        public override void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
            OnUserStateChanged_be_trigger = true;
            OnUserStateChanged_connection = connection;
            OnUserStateChanged_remoteUid = remoteUid;
            OnUserStateChanged_state = state;
        }

        public bool OnUserStateChangedPassed(RtcConnection connection, uint remoteUid, uint state)
        {
            if (OnUserStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUserStateChanged_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserStateChanged_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserStateChanged_state, state) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLocalAudioStats_be_trigger = false;
        public RtcConnection OnLocalAudioStats_connection;
        public LocalAudioStats OnLocalAudioStats_stats;
        public override void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)
        {
            OnLocalAudioStats_be_trigger = true;
            OnLocalAudioStats_connection = connection;
            OnLocalAudioStats_stats = stats;
        }

        public bool OnLocalAudioStatsPassed(RtcConnection connection, LocalAudioStats stats)
        {
            if (OnLocalAudioStats_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnLocalAudioStats_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<LocalAudioStats>(OnLocalAudioStats_stats, stats) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRemoteAudioStats_be_trigger = false;
        public RtcConnection OnRemoteAudioStats_connection;
        public RemoteAudioStats OnRemoteAudioStats_stats;
        public override void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
            OnRemoteAudioStats_be_trigger = true;
            OnRemoteAudioStats_connection = connection;
            OnRemoteAudioStats_stats = stats;
        }

        public bool OnRemoteAudioStatsPassed(RtcConnection connection, RemoteAudioStats stats)
        {
            if (OnRemoteAudioStats_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioStats_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<RemoteAudioStats>(OnRemoteAudioStats_stats, stats) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLocalVideoStats_be_trigger = false;
        public RtcConnection OnLocalVideoStats_connection;
        public LocalVideoStats OnLocalVideoStats_stats;
        public override void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
            OnLocalVideoStats_be_trigger = true;
            OnLocalVideoStats_connection = connection;
            OnLocalVideoStats_stats = stats;
        }

        public bool OnLocalVideoStatsPassed(RtcConnection connection, LocalVideoStats stats)
        {
            if (OnLocalVideoStats_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnLocalVideoStats_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<LocalVideoStats>(OnLocalVideoStats_stats, stats) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRemoteVideoStats_be_trigger = false;
        public RtcConnection OnRemoteVideoStats_connection;
        public RemoteVideoStats OnRemoteVideoStats_stats;
        public override void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
            OnRemoteVideoStats_be_trigger = true;
            OnRemoteVideoStats_connection = connection;
            OnRemoteVideoStats_stats = stats;
        }

        public bool OnRemoteVideoStatsPassed(RtcConnection connection, RemoteVideoStats stats)
        {
            if (OnRemoteVideoStats_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoStats_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<RemoteVideoStats>(OnRemoteVideoStats_stats, stats) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnConnectionLost_be_trigger = false;
        public RtcConnection OnConnectionLost_connection;
        public override void OnConnectionLost(RtcConnection connection)
        {
            OnConnectionLost_be_trigger = true;
            OnConnectionLost_connection = connection;
        }

        public bool OnConnectionLostPassed(RtcConnection connection)
        {
            if (OnConnectionLost_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnConnectionLost_connection, connection) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnConnectionInterrupted_be_trigger = false;
        public RtcConnection OnConnectionInterrupted_connection;
        public override void OnConnectionInterrupted(RtcConnection connection)
        {
            OnConnectionInterrupted_be_trigger = true;
            OnConnectionInterrupted_connection = connection;
        }

        public bool OnConnectionInterruptedPassed(RtcConnection connection)
        {
            if (OnConnectionInterrupted_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnConnectionInterrupted_connection, connection) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnConnectionBanned_be_trigger = false;
        public RtcConnection OnConnectionBanned_connection;
        public override void OnConnectionBanned(RtcConnection connection)
        {
            OnConnectionBanned_be_trigger = true;
            OnConnectionBanned_connection = connection;
        }

        public bool OnConnectionBannedPassed(RtcConnection connection)
        {
            if (OnConnectionBanned_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnConnectionBanned_connection, connection) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnStreamMessage_be_trigger = false;
        public RtcConnection OnStreamMessage_connection;
        public uint OnStreamMessage_remoteUid;
        public int OnStreamMessage_streamId;
        public byte[] OnStreamMessage_data;
        public ulong OnStreamMessage_length;
        public ulong OnStreamMessage_sentTs;
        public override void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            OnStreamMessage_be_trigger = true;
            OnStreamMessage_connection = connection;
            OnStreamMessage_remoteUid = remoteUid;
            OnStreamMessage_streamId = streamId;
            OnStreamMessage_data = data;
            OnStreamMessage_length = length;
            OnStreamMessage_sentTs = sentTs;
        }

        public bool OnStreamMessagePassed(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            if (OnStreamMessage_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnStreamMessage_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnStreamMessage_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnStreamMessage_streamId, streamId) == false)
            //return false;
            //if (ParamsHelper.Compare<byte[]>(OnStreamMessage_data, data) == false)
            //return false;
            //if (ParamsHelper.Compare<ulong>(OnStreamMessage_length, length) == false)
            //return false;
            //if (ParamsHelper.Compare<ulong>(OnStreamMessage_sentTs, sentTs) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnStreamMessageError_be_trigger = false;
        public RtcConnection OnStreamMessageError_connection;
        public uint OnStreamMessageError_remoteUid;
        public int OnStreamMessageError_streamId;
        public int OnStreamMessageError_code;
        public int OnStreamMessageError_missed;
        public int OnStreamMessageError_cached;
        public override void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
            OnStreamMessageError_be_trigger = true;
            OnStreamMessageError_connection = connection;
            OnStreamMessageError_remoteUid = remoteUid;
            OnStreamMessageError_streamId = streamId;
            OnStreamMessageError_code = code;
            OnStreamMessageError_missed = missed;
            OnStreamMessageError_cached = cached;
        }

        public bool OnStreamMessageErrorPassed(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
            if (OnStreamMessageError_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnStreamMessageError_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnStreamMessageError_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnStreamMessageError_streamId, streamId) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnStreamMessageError_code, code) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnStreamMessageError_missed, missed) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnStreamMessageError_cached, cached) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRequestToken_be_trigger = false;
        public RtcConnection OnRequestToken_connection;
        public override void OnRequestToken(RtcConnection connection)
        {
            OnRequestToken_be_trigger = true;
            OnRequestToken_connection = connection;
        }

        public bool OnRequestTokenPassed(RtcConnection connection)
        {
            if (OnRequestToken_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRequestToken_connection, connection) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLicenseValidationFailure_be_trigger = false;
        public RtcConnection OnLicenseValidationFailure_connection;
        public LICENSE_ERROR_TYPE OnLicenseValidationFailure_reason;
        public override void OnLicenseValidationFailure(RtcConnection connection, LICENSE_ERROR_TYPE reason)
        {
            OnLicenseValidationFailure_be_trigger = true;
            OnLicenseValidationFailure_connection = connection;
            OnLicenseValidationFailure_reason = reason;
        }

        public bool OnLicenseValidationFailurePassed(RtcConnection connection, LICENSE_ERROR_TYPE reason)
        {
            if (OnLicenseValidationFailure_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnLicenseValidationFailure_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<LICENSE_ERROR_TYPE>(OnLicenseValidationFailure_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnTokenPrivilegeWillExpire_be_trigger = false;
        public RtcConnection OnTokenPrivilegeWillExpire_connection;
        public string OnTokenPrivilegeWillExpire_token;
        public override void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
        {
            OnTokenPrivilegeWillExpire_be_trigger = true;
            OnTokenPrivilegeWillExpire_connection = connection;
            OnTokenPrivilegeWillExpire_token = token;
        }

        public bool OnTokenPrivilegeWillExpirePassed(RtcConnection connection, string token)
        {
            if (OnTokenPrivilegeWillExpire_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnTokenPrivilegeWillExpire_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnTokenPrivilegeWillExpire_token, token) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnFirstLocalAudioFramePublished_be_trigger = false;
        public RtcConnection OnFirstLocalAudioFramePublished_connection;
        public int OnFirstLocalAudioFramePublished_elapsed;
        public override void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)
        {
            OnFirstLocalAudioFramePublished_be_trigger = true;
            OnFirstLocalAudioFramePublished_connection = connection;
            OnFirstLocalAudioFramePublished_elapsed = elapsed;
        }

        public bool OnFirstLocalAudioFramePublishedPassed(RtcConnection connection, int elapsed)
        {
            if (OnFirstLocalAudioFramePublished_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnFirstLocalAudioFramePublished_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstLocalAudioFramePublished_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnFirstRemoteAudioFrame_be_trigger = false;
        public RtcConnection OnFirstRemoteAudioFrame_connection;
        public uint OnFirstRemoteAudioFrame_userId;
        public int OnFirstRemoteAudioFrame_elapsed;
        public override void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)
        {
            OnFirstRemoteAudioFrame_be_trigger = true;
            OnFirstRemoteAudioFrame_connection = connection;
            OnFirstRemoteAudioFrame_userId = userId;
            OnFirstRemoteAudioFrame_elapsed = elapsed;
        }

        public bool OnFirstRemoteAudioFramePassed(RtcConnection connection, uint userId, int elapsed)
        {
            if (OnFirstRemoteAudioFrame_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteAudioFrame_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnFirstRemoteAudioFrame_userId, userId) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstRemoteAudioFrame_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnFirstRemoteAudioDecoded_be_trigger = false;
        public RtcConnection OnFirstRemoteAudioDecoded_connection;
        public uint OnFirstRemoteAudioDecoded_uid;
        public int OnFirstRemoteAudioDecoded_elapsed;
        public override void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)
        {
            OnFirstRemoteAudioDecoded_be_trigger = true;
            OnFirstRemoteAudioDecoded_connection = connection;
            OnFirstRemoteAudioDecoded_uid = uid;
            OnFirstRemoteAudioDecoded_elapsed = elapsed;
        }

        public bool OnFirstRemoteAudioDecodedPassed(RtcConnection connection, uint uid, int elapsed)
        {
            if (OnFirstRemoteAudioDecoded_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteAudioDecoded_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnFirstRemoteAudioDecoded_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnFirstRemoteAudioDecoded_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnLocalAudioStateChanged_be_trigger = false;
        public RtcConnection OnLocalAudioStateChanged_connection;
        public LOCAL_AUDIO_STREAM_STATE OnLocalAudioStateChanged_state;
        public LOCAL_AUDIO_STREAM_REASON OnLocalAudioStateChanged_reason;
        public override void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_REASON reason)
        {
            OnLocalAudioStateChanged_be_trigger = true;
            OnLocalAudioStateChanged_connection = connection;
            OnLocalAudioStateChanged_state = state;
            OnLocalAudioStateChanged_reason = reason;
        }

        public bool OnLocalAudioStateChangedPassed(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_REASON reason)
        {
            if (OnLocalAudioStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnLocalAudioStateChanged_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<LOCAL_AUDIO_STREAM_STATE>(OnLocalAudioStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<LOCAL_AUDIO_STREAM_REASON>(OnLocalAudioStateChanged_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRemoteAudioStateChanged_be_trigger = false;
        public RtcConnection OnRemoteAudioStateChanged_connection;
        public uint OnRemoteAudioStateChanged_remoteUid;
        public REMOTE_AUDIO_STATE OnRemoteAudioStateChanged_state;
        public REMOTE_AUDIO_STATE_REASON OnRemoteAudioStateChanged_reason;
        public int OnRemoteAudioStateChanged_elapsed;
        public override void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            OnRemoteAudioStateChanged_be_trigger = true;
            OnRemoteAudioStateChanged_connection = connection;
            OnRemoteAudioStateChanged_remoteUid = remoteUid;
            OnRemoteAudioStateChanged_state = state;
            OnRemoteAudioStateChanged_reason = reason;
            OnRemoteAudioStateChanged_elapsed = elapsed;
        }

        public bool OnRemoteAudioStateChangedPassed(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteAudioStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioStateChanged_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnRemoteAudioStateChanged_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<REMOTE_AUDIO_STATE>(OnRemoteAudioStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<REMOTE_AUDIO_STATE_REASON>(OnRemoteAudioStateChanged_reason, reason) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnRemoteAudioStateChanged_elapsed, elapsed) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnActiveSpeaker_be_trigger = false;
        public RtcConnection OnActiveSpeaker_connection;
        public uint OnActiveSpeaker_uid;
        public override void OnActiveSpeaker(RtcConnection connection, uint uid)
        {
            OnActiveSpeaker_be_trigger = true;
            OnActiveSpeaker_connection = connection;
            OnActiveSpeaker_uid = uid;
        }

        public bool OnActiveSpeakerPassed(RtcConnection connection, uint uid)
        {
            if (OnActiveSpeaker_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnActiveSpeaker_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnActiveSpeaker_uid, uid) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnClientRoleChanged_be_trigger = false;
        public RtcConnection OnClientRoleChanged_connection;
        public CLIENT_ROLE_TYPE OnClientRoleChanged_oldRole;
        public CLIENT_ROLE_TYPE OnClientRoleChanged_newRole;
        public ClientRoleOptions OnClientRoleChanged_newRoleOptions;
        public override void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            OnClientRoleChanged_be_trigger = true;
            OnClientRoleChanged_connection = connection;
            OnClientRoleChanged_oldRole = oldRole;
            OnClientRoleChanged_newRole = newRole;
            OnClientRoleChanged_newRoleOptions = newRoleOptions;
        }

        public bool OnClientRoleChangedPassed(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            if (OnClientRoleChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnClientRoleChanged_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChanged_oldRole, oldRole) == false)
            //return false;
            //if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChanged_newRole, newRole) == false)
            //return false;
            //if (ParamsHelper.Compare<ClientRoleOptions>(OnClientRoleChanged_newRoleOptions, newRoleOptions) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnClientRoleChangeFailed_be_trigger = false;
        public RtcConnection OnClientRoleChangeFailed_connection;
        public CLIENT_ROLE_CHANGE_FAILED_REASON OnClientRoleChangeFailed_reason;
        public CLIENT_ROLE_TYPE OnClientRoleChangeFailed_currentRole;
        public override void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            OnClientRoleChangeFailed_be_trigger = true;
            OnClientRoleChangeFailed_connection = connection;
            OnClientRoleChangeFailed_reason = reason;
            OnClientRoleChangeFailed_currentRole = currentRole;
        }

        public bool OnClientRoleChangeFailedPassed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            if (OnClientRoleChangeFailed_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnClientRoleChangeFailed_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<CLIENT_ROLE_CHANGE_FAILED_REASON>(OnClientRoleChangeFailed_reason, reason) == false)
            //return false;
            //if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChangeFailed_currentRole, currentRole) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRemoteAudioTransportStats_be_trigger = false;
        public RtcConnection OnRemoteAudioTransportStats_connection;
        public uint OnRemoteAudioTransportStats_remoteUid;
        public ushort OnRemoteAudioTransportStats_delay;
        public ushort OnRemoteAudioTransportStats_lost;
        public ushort OnRemoteAudioTransportStats_rxKBitRate;
        public override void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            OnRemoteAudioTransportStats_be_trigger = true;
            OnRemoteAudioTransportStats_connection = connection;
            OnRemoteAudioTransportStats_remoteUid = remoteUid;
            OnRemoteAudioTransportStats_delay = delay;
            OnRemoteAudioTransportStats_lost = lost;
            OnRemoteAudioTransportStats_rxKBitRate = rxKBitRate;
        }

        public bool OnRemoteAudioTransportStatsPassed(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            if (OnRemoteAudioTransportStats_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioTransportStats_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnRemoteAudioTransportStats_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_delay, delay) == false)
            //return false;
            //if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_lost, lost) == false)
            //return false;
            //if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_rxKBitRate, rxKBitRate) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnRemoteVideoTransportStats_be_trigger = false;
        public RtcConnection OnRemoteVideoTransportStats_connection;
        public uint OnRemoteVideoTransportStats_remoteUid;
        public ushort OnRemoteVideoTransportStats_delay;
        public ushort OnRemoteVideoTransportStats_lost;
        public ushort OnRemoteVideoTransportStats_rxKBitRate;
        public override void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            OnRemoteVideoTransportStats_be_trigger = true;
            OnRemoteVideoTransportStats_connection = connection;
            OnRemoteVideoTransportStats_remoteUid = remoteUid;
            OnRemoteVideoTransportStats_delay = delay;
            OnRemoteVideoTransportStats_lost = lost;
            OnRemoteVideoTransportStats_rxKBitRate = rxKBitRate;
        }

        public bool OnRemoteVideoTransportStatsPassed(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            if (OnRemoteVideoTransportStats_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoTransportStats_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnRemoteVideoTransportStats_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_delay, delay) == false)
            //return false;
            //if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_lost, lost) == false)
            //return false;
            //if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_rxKBitRate, rxKBitRate) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnConnectionStateChanged_be_trigger = false;
        public RtcConnection OnConnectionStateChanged_connection;
        public CONNECTION_STATE_TYPE OnConnectionStateChanged_state;
        public CONNECTION_CHANGED_REASON_TYPE OnConnectionStateChanged_reason;
        public override void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            OnConnectionStateChanged_be_trigger = true;
            OnConnectionStateChanged_connection = connection;
            OnConnectionStateChanged_state = state;
            OnConnectionStateChanged_reason = reason;
        }

        public bool OnConnectionStateChangedPassed(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            if (OnConnectionStateChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnConnectionStateChanged_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<CONNECTION_STATE_TYPE>(OnConnectionStateChanged_state, state) == false)
            //return false;
            //if (ParamsHelper.Compare<CONNECTION_CHANGED_REASON_TYPE>(OnConnectionStateChanged_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnWlAccMessage_be_trigger = false;
        public RtcConnection OnWlAccMessage_connection;
        public WLACC_MESSAGE_REASON OnWlAccMessage_reason;
        public WLACC_SUGGEST_ACTION OnWlAccMessage_action;
        public string OnWlAccMessage_wlAccMsg;
        public override void OnWlAccMessage(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            OnWlAccMessage_be_trigger = true;
            OnWlAccMessage_connection = connection;
            OnWlAccMessage_reason = reason;
            OnWlAccMessage_action = action;
            OnWlAccMessage_wlAccMsg = wlAccMsg;
        }

        public bool OnWlAccMessagePassed(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            if (OnWlAccMessage_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnWlAccMessage_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<WLACC_MESSAGE_REASON>(OnWlAccMessage_reason, reason) == false)
            //return false;
            //if (ParamsHelper.Compare<WLACC_SUGGEST_ACTION>(OnWlAccMessage_action, action) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnWlAccMessage_wlAccMsg, wlAccMsg) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnWlAccStats_be_trigger = false;
        public RtcConnection OnWlAccStats_connection;
        public WlAccStats OnWlAccStats_currentStats;
        public WlAccStats OnWlAccStats_averageStats;
        public override void OnWlAccStats(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
            OnWlAccStats_be_trigger = true;
            OnWlAccStats_connection = connection;
            OnWlAccStats_currentStats = currentStats;
            OnWlAccStats_averageStats = averageStats;
        }

        public bool OnWlAccStatsPassed(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
            if (OnWlAccStats_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnWlAccStats_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<WlAccStats>(OnWlAccStats_currentStats, currentStats) == false)
            //return false;
            //if (ParamsHelper.Compare<WlAccStats>(OnWlAccStats_averageStats, averageStats) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnNetworkTypeChanged_be_trigger = false;
        public RtcConnection OnNetworkTypeChanged_connection;
        public NETWORK_TYPE OnNetworkTypeChanged_type;
        public override void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)
        {
            OnNetworkTypeChanged_be_trigger = true;
            OnNetworkTypeChanged_connection = connection;
            OnNetworkTypeChanged_type = type;
        }

        public bool OnNetworkTypeChangedPassed(RtcConnection connection, NETWORK_TYPE type)
        {
            if (OnNetworkTypeChanged_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnNetworkTypeChanged_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<NETWORK_TYPE>(OnNetworkTypeChanged_type, type) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnEncryptionError_be_trigger = false;
        public RtcConnection OnEncryptionError_connection;
        public ENCRYPTION_ERROR_TYPE OnEncryptionError_errorType;
        public override void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
            OnEncryptionError_be_trigger = true;
            OnEncryptionError_connection = connection;
            OnEncryptionError_errorType = errorType;
        }

        public bool OnEncryptionErrorPassed(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
            if (OnEncryptionError_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnEncryptionError_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<ENCRYPTION_ERROR_TYPE>(OnEncryptionError_errorType, errorType) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUploadLogResult_be_trigger = false;
        public RtcConnection OnUploadLogResult_connection;
        public string OnUploadLogResult_requestId;
        public bool OnUploadLogResult_success;
        public UPLOAD_ERROR_REASON OnUploadLogResult_reason;
        public override void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            OnUploadLogResult_be_trigger = true;
            OnUploadLogResult_connection = connection;
            OnUploadLogResult_requestId = requestId;
            OnUploadLogResult_success = success;
            OnUploadLogResult_reason = reason;
        }

        public bool OnUploadLogResultPassed(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            if (OnUploadLogResult_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUploadLogResult_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnUploadLogResult_requestId, requestId) == false)
            //return false;
            //if (ParamsHelper.Compare<bool>(OnUploadLogResult_success, success) == false)
            //return false;
            //if (ParamsHelper.Compare<UPLOAD_ERROR_REASON>(OnUploadLogResult_reason, reason) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnUserAccountUpdated_be_trigger = false;
        public RtcConnection OnUserAccountUpdated_connection;
        public uint OnUserAccountUpdated_remoteUid;
        public string OnUserAccountUpdated_remoteUserAccount;
        public override void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string remoteUserAccount)
        {
            OnUserAccountUpdated_be_trigger = true;
            OnUserAccountUpdated_connection = connection;
            OnUserAccountUpdated_remoteUid = remoteUid;
            OnUserAccountUpdated_remoteUserAccount = remoteUserAccount;
        }

        public bool OnUserAccountUpdatedPassed(RtcConnection connection, uint remoteUid, string remoteUserAccount)
        {
            if (OnUserAccountUpdated_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnUserAccountUpdated_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnUserAccountUpdated_remoteUid, remoteUid) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnUserAccountUpdated_remoteUserAccount, remoteUserAccount) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnSnapshotTaken_be_trigger = false;
        public RtcConnection OnSnapshotTaken_connection;
        public uint OnSnapshotTaken_uid;
        public string OnSnapshotTaken_filePath;
        public int OnSnapshotTaken_width;
        public int OnSnapshotTaken_height;
        public int OnSnapshotTaken_errCode;
        public override void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
            OnSnapshotTaken_be_trigger = true;
            OnSnapshotTaken_connection = connection;
            OnSnapshotTaken_uid = uid;
            OnSnapshotTaken_filePath = filePath;
            OnSnapshotTaken_width = width;
            OnSnapshotTaken_height = height;
            OnSnapshotTaken_errCode = errCode;
        }

        public bool OnSnapshotTakenPassed(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
            if (OnSnapshotTaken_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnSnapshotTaken_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnSnapshotTaken_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<string>(OnSnapshotTaken_filePath, filePath) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnSnapshotTaken_width, width) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnSnapshotTaken_height, height) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnSnapshotTaken_errCode, errCode) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnVideoRenderingTracingResult_be_trigger = false;
        public RtcConnection OnVideoRenderingTracingResult_connection;
        public uint OnVideoRenderingTracingResult_uid;
        public MEDIA_TRACE_EVENT OnVideoRenderingTracingResult_currentEvent;
        public VideoRenderingTracingInfo OnVideoRenderingTracingResult_tracingInfo;
        public override void OnVideoRenderingTracingResult(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            OnVideoRenderingTracingResult_be_trigger = true;
            OnVideoRenderingTracingResult_connection = connection;
            OnVideoRenderingTracingResult_uid = uid;
            OnVideoRenderingTracingResult_currentEvent = currentEvent;
            OnVideoRenderingTracingResult_tracingInfo = tracingInfo;
        }

        public bool OnVideoRenderingTracingResultPassed(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            if (OnVideoRenderingTracingResult_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnVideoRenderingTracingResult_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnVideoRenderingTracingResult_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<MEDIA_TRACE_EVENT>(OnVideoRenderingTracingResult_currentEvent, currentEvent) == false)
            //return false;
            //if (ParamsHelper.Compare<VideoRenderingTracingInfo>(OnVideoRenderingTracingResult_tracingInfo, tracingInfo) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnSetRtmFlagResult_be_trigger = false;
        public RtcConnection OnSetRtmFlagResult_connection;
        public int OnSetRtmFlagResult_code;
        public override void OnSetRtmFlagResult(RtcConnection connection, int code)
        {
            OnSetRtmFlagResult_be_trigger = true;
            OnSetRtmFlagResult_connection = connection;
            OnSetRtmFlagResult_code = code;
        }

        public bool OnSetRtmFlagResultPassed(RtcConnection connection, int code)
        {
            if (OnSetRtmFlagResult_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnSetRtmFlagResult_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnSetRtmFlagResult_code, code) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnTranscodedStreamLayoutInfo_be_trigger = false;
        public RtcConnection OnTranscodedStreamLayoutInfo_connection;
        public uint OnTranscodedStreamLayoutInfo_uid;
        public int OnTranscodedStreamLayoutInfo_width;
        public int OnTranscodedStreamLayoutInfo_height;
        public int OnTranscodedStreamLayoutInfo_layoutCount;
        public VideoLayout[] OnTranscodedStreamLayoutInfo_layoutlist;
        public override void OnTranscodedStreamLayoutInfo(RtcConnection connection, uint uid, int width, int height, int layoutCount, VideoLayout[] layoutlist)
        {
            OnTranscodedStreamLayoutInfo_be_trigger = true;
            OnTranscodedStreamLayoutInfo_connection = connection;
            OnTranscodedStreamLayoutInfo_uid = uid;
            OnTranscodedStreamLayoutInfo_width = width;
            OnTranscodedStreamLayoutInfo_height = height;
            OnTranscodedStreamLayoutInfo_layoutCount = layoutCount;
            OnTranscodedStreamLayoutInfo_layoutlist = layoutlist;
        }

        public bool OnTranscodedStreamLayoutInfoPassed(RtcConnection connection, uint uid, int width, int height, int layoutCount, VideoLayout[] layoutlist)
        {
            if (OnTranscodedStreamLayoutInfo_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnTranscodedStreamLayoutInfo_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnTranscodedStreamLayoutInfo_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnTranscodedStreamLayoutInfo_width, width) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnTranscodedStreamLayoutInfo_height, height) == false)
            //return false;
            //if (ParamsHelper.Compare<int>(OnTranscodedStreamLayoutInfo_layoutCount, layoutCount) == false)
            //return false;
            //if (ParamsHelper.Compare<VideoLayout[]>(OnTranscodedStreamLayoutInfo_layoutlist, layoutlist) == false)
            //return false;
            return true;
        }
        //////////////////

        public bool OnAudioMetadataReceived_be_trigger = false;
        public RtcConnection OnAudioMetadataReceived_connection;
        public uint OnAudioMetadataReceived_uid;
        public byte[] OnAudioMetadataReceived_metadata;
        public ulong OnAudioMetadataReceived_length;
        public override void OnAudioMetadataReceived(RtcConnection connection, uint uid, byte[] metadata, ulong length)
        {
            OnAudioMetadataReceived_be_trigger = true;
            OnAudioMetadataReceived_connection = connection;
            OnAudioMetadataReceived_uid = uid;
            OnAudioMetadataReceived_metadata = metadata;
            OnAudioMetadataReceived_length = length;
        }

        public bool OnAudioMetadataReceivedPassed(RtcConnection connection, uint uid, byte[] metadata, ulong length)
        {
            if (OnAudioMetadataReceived_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<RtcConnection>(OnAudioMetadataReceived_connection, connection) == false)
            //return false;
            //if (ParamsHelper.Compare<uint>(OnAudioMetadataReceived_uid, uid) == false)
            //return false;
            //if (ParamsHelper.Compare<byte[]>(OnAudioMetadataReceived_metadata, metadata) == false)
            //return false;
            //if (ParamsHelper.Compare<ulong>(OnAudioMetadataReceived_length, length) == false)
            //return false;
            return true;
        }
        //////////////////
        #endregion terra IRtcEngineEventHandler

        #region terra IDirectCdnStreamingEventHandler
        public bool OnDirectCdnStreamingStateChanged_be_trigger = false;
        public DIRECT_CDN_STREAMING_STATE OnDirectCdnStreamingStateChanged_state;
        public DIRECT_CDN_STREAMING_REASON OnDirectCdnStreamingStateChanged_reason;
        public string OnDirectCdnStreamingStateChanged_message;

        public override void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_REASON reason, string message)
        {
            OnDirectCdnStreamingStateChanged_be_trigger = true;
            OnDirectCdnStreamingStateChanged_state = state;
            OnDirectCdnStreamingStateChanged_reason = reason;
            OnDirectCdnStreamingStateChanged_message = message;

        }

        public bool OnDirectCdnStreamingStateChangedPassed(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_REASON reason, string message)
        {

            if (OnDirectCdnStreamingStateChanged_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<DIRECT_CDN_STREAMING_STATE>(OnDirectCdnStreamingStateChanged_state, state) == false)
            //return false;
            // if (ParamsHelper.Compare<DIRECT_CDN_STREAMING_REASON>(OnDirectCdnStreamingStateChanged_reason, reason) == false)
            //return false;
            // if (ParamsHelper.Compare<string>(OnDirectCdnStreamingStateChanged_message, message) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnDirectCdnStreamingStats_be_trigger = false;
        public DirectCdnStreamingStats OnDirectCdnStreamingStats_stats;

        public override void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
        {
            OnDirectCdnStreamingStats_be_trigger = true;
            OnDirectCdnStreamingStats_stats = stats;

        }

        public bool OnDirectCdnStreamingStatsPassed(DirectCdnStreamingStats stats)
        {

            if (OnDirectCdnStreamingStats_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<DirectCdnStreamingStats>(OnDirectCdnStreamingStats_stats, stats) == false)
            //return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IDirectCdnStreamingEventHandler

    }
}
