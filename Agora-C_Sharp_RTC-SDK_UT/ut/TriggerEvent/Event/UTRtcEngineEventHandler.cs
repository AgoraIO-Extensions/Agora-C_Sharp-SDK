using System;
using uid_t = System.UInt32;
namespace Agora.Rtc
{
    public class UTRtcEngineEventHandler : IRtcEngineEventHandler
    {

        #region terra IRtcEngineEventHandler

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
            if (ParamsHelper.Compare<int>(OnError_err, err) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnError_msg, msg) == false)
                return false;
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
            if (ParamsHelper.Compare<LastmileProbeResult>(OnLastmileProbeResult_result, result) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnAudioDeviceStateChanged_deviceId, deviceId) == false)
                return false;
            if (ParamsHelper.Compare<MEDIA_DEVICE_TYPE>(OnAudioDeviceStateChanged_deviceType, deviceType) == false)
                return false;
            if (ParamsHelper.Compare<MEDIA_DEVICE_STATE_TYPE>(OnAudioDeviceStateChanged_deviceState, deviceState) == false)
                return false;
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
            if (ParamsHelper.Compare<long>(OnAudioMixingPositionChanged_position, position) == false)
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
            if (ParamsHelper.Compare<int>(OnAudioEffectFinished_soundId, soundId) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnVideoDeviceStateChanged_deviceId, deviceId) == false)
                return false;
            if (ParamsHelper.Compare<MEDIA_DEVICE_TYPE>(OnVideoDeviceStateChanged_deviceType, deviceType) == false)
                return false;
            if (ParamsHelper.Compare<MEDIA_DEVICE_STATE_TYPE>(OnVideoDeviceStateChanged_deviceState, deviceState) == false)
                return false;
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
            if (ParamsHelper.Compare<UplinkNetworkInfo>(OnUplinkNetworkInfoUpdated_info, info) == false)
                return false;
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
            if (ParamsHelper.Compare<DownlinkNetworkInfo>(OnDownlinkNetworkInfoUpdated_info, info) == false)
                return false;
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
            if (ParamsHelper.Compare<int>(OnLastmileQuality_quality, quality) == false)
                return false;
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
            if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnFirstLocalVideoFrame_source, source) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalVideoFrame_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalVideoFrame_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalVideoFrame_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalVideoStateChanged_be_trigger = false;
        public VIDEO_SOURCE_TYPE OnLocalVideoStateChanged_source;
        public LOCAL_VIDEO_STREAM_STATE OnLocalVideoStateChanged_state;
        public LOCAL_VIDEO_STREAM_ERROR OnLocalVideoStateChanged_error;
        public override void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR error)
        {
            OnLocalVideoStateChanged_be_trigger = true;
            OnLocalVideoStateChanged_source = source;
            OnLocalVideoStateChanged_state = state;
            OnLocalVideoStateChanged_error = error;
        }

        public bool OnLocalVideoStateChangedPassed(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR error)
        {
            if (OnLocalVideoStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnLocalVideoStateChanged_source, source) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_STATE>(OnLocalVideoStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_ERROR>(OnLocalVideoStateChanged_error, error) == false)
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
            if (ParamsHelper.Compare<int>(OnCameraFocusAreaChanged_x, x) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnCameraFocusAreaChanged_y, y) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnCameraFocusAreaChanged_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnCameraFocusAreaChanged_height, height) == false)
                return false;
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
            if (ParamsHelper.Compare<int>(OnCameraExposureAreaChanged_x, x) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnCameraExposureAreaChanged_y, y) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnCameraExposureAreaChanged_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnCameraExposureAreaChanged_height, height) == false)
                return false;
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
            if (ParamsHelper.Compare<int>(OnFacePositionChanged_imageWidth, imageWidth) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFacePositionChanged_imageHeight, imageHeight) == false)
                return false;
            if (ParamsHelper.Compare<Rectangle[]>(OnFacePositionChanged_vecRectangle, vecRectangle) == false)
                return false;
            if (ParamsHelper.Compare<int[]>(OnFacePositionChanged_vecDistance, vecDistance) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFacePositionChanged_numFaces, numFaces) == false)
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
            if (ParamsHelper.Compare<AUDIO_MIXING_STATE_TYPE>(OnAudioMixingStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<AUDIO_MIXING_REASON_TYPE>(OnAudioMixingStateChanged_reason, reason) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRhythmPlayerStateChanged_be_trigger = false;
        public RHYTHM_PLAYER_STATE_TYPE OnRhythmPlayerStateChanged_state;
        public RHYTHM_PLAYER_ERROR_TYPE OnRhythmPlayerStateChanged_errorCode;
        public override void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
            OnRhythmPlayerStateChanged_be_trigger = true;
            OnRhythmPlayerStateChanged_state = state;
            OnRhythmPlayerStateChanged_errorCode = errorCode;
        }

        public bool OnRhythmPlayerStateChangedPassed(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
            if (OnRhythmPlayerStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RHYTHM_PLAYER_STATE_TYPE>(OnRhythmPlayerStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<RHYTHM_PLAYER_ERROR_TYPE>(OnRhythmPlayerStateChanged_errorCode, errorCode) == false)
                return false;
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
            if (ParamsHelper.Compare<CONTENT_INSPECT_RESULT>(OnContentInspectResult_result, result) == false)
                return false;
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
            if (ParamsHelper.Compare<MEDIA_DEVICE_TYPE>(OnAudioDeviceVolumeChanged_deviceType, deviceType) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioDeviceVolumeChanged_volume, volume) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnAudioDeviceVolumeChanged_muted, muted) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRtmpStreamingStateChanged_be_trigger = false;
        public string OnRtmpStreamingStateChanged_url;
        public RTMP_STREAM_PUBLISH_STATE OnRtmpStreamingStateChanged_state;
        public RTMP_STREAM_PUBLISH_ERROR_TYPE OnRtmpStreamingStateChanged_errCode;
        public override void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
            OnRtmpStreamingStateChanged_be_trigger = true;
            OnRtmpStreamingStateChanged_url = url;
            OnRtmpStreamingStateChanged_state = state;
            OnRtmpStreamingStateChanged_errCode = errCode;
        }

        public bool OnRtmpStreamingStateChangedPassed(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
            if (OnRtmpStreamingStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<string>(OnRtmpStreamingStateChanged_url, url) == false)
                return false;
            if (ParamsHelper.Compare<RTMP_STREAM_PUBLISH_STATE>(OnRtmpStreamingStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<RTMP_STREAM_PUBLISH_ERROR_TYPE>(OnRtmpStreamingStateChanged_errCode, errCode) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnRtmpStreamingEvent_url, url) == false)
                return false;
            if (ParamsHelper.Compare<RTMP_STREAMING_EVENT>(OnRtmpStreamingEvent_eventCode, eventCode) == false)
                return false;
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
            if (ParamsHelper.Compare<int>(OnAudioRoutingChanged_routing, routing) == false)
                return false;
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
            if (ParamsHelper.Compare<int>(OnChannelMediaRelayStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnChannelMediaRelayStateChanged_code, code) == false)
                return false;
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
            if (ParamsHelper.Compare<bool>(OnLocalPublishFallbackToAudioOnly_isFallbackOrRecover, isFallbackOrRecover) == false)
                return false;
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
            if (ParamsHelper.Compare<PERMISSION_TYPE>(OnPermissionError_permissionType, permissionType) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnAudioPublishStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_PUBLISH_STATE>(OnAudioPublishStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_PUBLISH_STATE>(OnAudioPublishStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioPublishStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;
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
            if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnVideoPublishStateChanged_source, source) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnVideoPublishStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_PUBLISH_STATE>(OnVideoPublishStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_PUBLISH_STATE>(OnVideoPublishStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoPublishStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnExtensionEvent_provider, provider) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnExtensionEvent_extension, extension) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnExtensionEvent_key, key) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnExtensionEvent_value, value) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnExtensionStarted_provider, provider) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnExtensionStarted_extension, extension) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnExtensionStopped_provider, provider) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnExtensionStopped_extension, extension) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnExtensionError_provider, provider) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnExtensionError_extension, extension) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnExtensionError_error, error) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnExtensionError_message, message) == false)
                return false;
            return true;
        }

        //////////////////

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
            if (ParamsHelper.Compare<string>(OnProxyConnected_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnProxyConnected_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<PROXY_TYPE>(OnProxyConnected_proxyType, proxyType) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnProxyConnected_localProxyIp, localProxyIp) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnProxyConnected_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<uint>(OnRemoteSubscribeFallbackToAudioOnly_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover, isFallbackOrRecover) == false)
                return false;
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
            if (ParamsHelper.Compare<uint>(OnLocalUserRegistered_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnLocalUserRegistered_userAccount, userAccount) == false)
                return false;
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
            if (ParamsHelper.Compare<uint>(OnUserInfoUpdated_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<UserInfo>(OnUserInfoUpdated_info, info) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnAudioSubscribeStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnAudioSubscribeStateChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnAudioSubscribeStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnAudioSubscribeStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;
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
            if (ParamsHelper.Compare<string>(OnVideoSubscribeStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnVideoSubscribeStateChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnVideoSubscribeStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnVideoSubscribeStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;
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
            if (ParamsHelper.Compare<TranscodingVideoStream>(OnLocalVideoTranscoderError_stream, stream) == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_TRANSCODER_ERROR>(OnLocalVideoTranscoderError_error, error) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnProxyConnected_be_trigger = false;
        public string OnProxyConnected_channel;
        public string OnProxyConnected_userAccount;
        public PROXY_TYPE OnProxyConnected_proxyType;
        public string OnProxyConnected_localProxyIp;
        public int OnProxyConnected_elapsed;
        public override void OnProxyConnected(string channel, string userAccount, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            OnProxyConnected_be_trigger = true;
            OnProxyConnected_channel = channel;
            OnProxyConnected_userAccount = userAccount;
            OnProxyConnected_proxyType = proxyType;
            OnProxyConnected_localProxyIp = localProxyIp;
            OnProxyConnected_elapsed = elapsed;
        }

        public bool OnProxyConnectedPassed(string channel, string userAccount, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
            if (OnProxyConnected_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<string>(OnProxyConnected_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnProxyConnected_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<PROXY_TYPE>(OnProxyConnected_proxyType, proxyType) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnProxyConnected_localProxyIp, localProxyIp) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnProxyConnected_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteSubscribeFallbackToAudioOnly_be_trigger = false;
        public string OnRemoteSubscribeFallbackToAudioOnly_userAccount;
        public bool OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover;
        public override void OnRemoteSubscribeFallbackToAudioOnly(string userAccount, bool isFallbackOrRecover)
        {
            OnRemoteSubscribeFallbackToAudioOnly_be_trigger = true;
            OnRemoteSubscribeFallbackToAudioOnly_userAccount = userAccount;
            OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover = isFallbackOrRecover;
        }

        public bool OnRemoteSubscribeFallbackToAudioOnlyPassed(string userAccount, bool isFallbackOrRecover)
        {
            if (OnRemoteSubscribeFallbackToAudioOnly_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<string>(OnRemoteSubscribeFallbackToAudioOnly_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnRemoteSubscribeFallbackToAudioOnly_isFallbackOrRecover, isFallbackOrRecover) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnAudioSubscribeStateChanged_be_trigger = false;
        public string OnAudioSubscribeStateChanged_channel;
        public string OnAudioSubscribeStateChanged_userAccount;
        public STREAM_SUBSCRIBE_STATE OnAudioSubscribeStateChanged_oldState;
        public STREAM_SUBSCRIBE_STATE OnAudioSubscribeStateChanged_newState;
        public int OnAudioSubscribeStateChanged_elapseSinceLastState;
        public override void OnAudioSubscribeStateChanged(string channel, string userAccount, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            OnAudioSubscribeStateChanged_be_trigger = true;
            OnAudioSubscribeStateChanged_channel = channel;
            OnAudioSubscribeStateChanged_userAccount = userAccount;
            OnAudioSubscribeStateChanged_oldState = oldState;
            OnAudioSubscribeStateChanged_newState = newState;
            OnAudioSubscribeStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnAudioSubscribeStateChangedPassed(string channel, string userAccount, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (OnAudioSubscribeStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<string>(OnAudioSubscribeStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnAudioSubscribeStateChanged_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnAudioSubscribeStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnAudioSubscribeStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoSubscribeStateChanged_be_trigger = false;
        public string OnVideoSubscribeStateChanged_channel;
        public string OnVideoSubscribeStateChanged_userAccount;
        public STREAM_SUBSCRIBE_STATE OnVideoSubscribeStateChanged_oldState;
        public STREAM_SUBSCRIBE_STATE OnVideoSubscribeStateChanged_newState;
        public int OnVideoSubscribeStateChanged_elapseSinceLastState;
        public override void OnVideoSubscribeStateChanged(string channel, string userAccount, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            OnVideoSubscribeStateChanged_be_trigger = true;
            OnVideoSubscribeStateChanged_channel = channel;
            OnVideoSubscribeStateChanged_userAccount = userAccount;
            OnVideoSubscribeStateChanged_oldState = oldState;
            OnVideoSubscribeStateChanged_newState = newState;
            OnVideoSubscribeStateChanged_elapseSinceLastState = elapseSinceLastState;
        }

        public bool OnVideoSubscribeStateChangedPassed(string channel, string userAccount, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
            if (OnVideoSubscribeStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<string>(OnVideoSubscribeStateChanged_channel, channel) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnVideoSubscribeStateChanged_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnVideoSubscribeStateChanged_oldState, oldState) == false)
                return false;
            if (ParamsHelper.Compare<STREAM_SUBSCRIBE_STATE>(OnVideoSubscribeStateChanged_newState, newState) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSubscribeStateChanged_elapseSinceLastState, elapseSinceLastState) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalVideoTranscoderError_be_trigger = false;
        public TranscodingVideoStreamS OnLocalVideoTranscoderError_streamS;
        public VIDEO_TRANSCODER_ERROR OnLocalVideoTranscoderError_error;
        public override void OnLocalVideoTranscoderError(TranscodingVideoStreamS streamS, VIDEO_TRANSCODER_ERROR error)
        {
            OnLocalVideoTranscoderError_be_trigger = true;
            OnLocalVideoTranscoderError_streamS = streamS;
            OnLocalVideoTranscoderError_error = error;
        }

        public bool OnLocalVideoTranscoderErrorPassed(TranscodingVideoStreamS streamS, VIDEO_TRANSCODER_ERROR error)
        {
            if (OnLocalVideoTranscoderError_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<TranscodingVideoStreamS>(OnLocalVideoTranscoderError_streamS, streamS) == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_TRANSCODER_ERROR>(OnLocalVideoTranscoderError_error, error) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnJoinChannelSuccess_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnJoinChannelSuccess_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRejoinChannelSuccess_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRejoinChannelSuccess_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnAudioQuality_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnAudioQuality_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioQuality_quality, quality) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnAudioQuality_delay, delay) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnAudioQuality_lost, lost) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnAudioVolumeIndication_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<AudioVolumeInfo[]>(OnAudioVolumeIndication_speakers, speakers) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnAudioVolumeIndication_speakerNumber, speakerNumber) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioVolumeIndication_totalVolume, totalVolume) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnLeaveChannel_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<RtcStats>(OnLeaveChannel_stats, stats) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRtcStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<RtcStats>(OnRtcStats_stats, stats) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnNetworkQuality_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnNetworkQuality_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnNetworkQuality_txQuality, txQuality) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnNetworkQuality_rxQuality, rxQuality) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnIntraRequestReceived_connection, connection) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnFirstLocalVideoFramePublished_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalVideoFramePublished_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteVideoDecoded_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnFirstRemoteVideoDecoded_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnVideoSizeChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnVideoSizeChanged_sourceType, sourceType) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnVideoSizeChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged_rotation, rotation) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalVideoStateChanged2_be_trigger = false;
        public RtcConnection OnLocalVideoStateChanged2_connection;
        public LOCAL_VIDEO_STREAM_STATE OnLocalVideoStateChanged2_state;
        public LOCAL_VIDEO_STREAM_ERROR OnLocalVideoStateChanged2_errorCode;
        public override void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            OnLocalVideoStateChanged2_be_trigger = true;
            OnLocalVideoStateChanged2_connection = connection;
            OnLocalVideoStateChanged2_state = state;
            OnLocalVideoStateChanged2_errorCode = errorCode;
        }

        public bool OnLocalVideoStateChanged2Passed(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            if (OnLocalVideoStateChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnLocalVideoStateChanged2_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_STATE>(OnLocalVideoStateChanged2_state, state) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_ERROR>(OnLocalVideoStateChanged2_errorCode, errorCode) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteVideoStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_VIDEO_STATE>(OnRemoteVideoStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_VIDEO_STATE_REASON>(OnRemoteVideoStateChanged_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRemoteVideoStateChanged_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteVideoFrame_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnFirstRemoteVideoFrame_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUserJoined_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserJoined_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnUserJoined_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUserOffline_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserOffline_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<USER_OFFLINE_REASON_TYPE>(OnUserOffline_reason, reason) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUserMuteAudio_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserMuteAudio_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserMuteAudio_muted, muted) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUserMuteVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserMuteVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserMuteVideo_muted, muted) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUserEnableVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserEnableVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserEnableVideo_enabled, enabled) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUserEnableLocalVideo_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserEnableLocalVideo_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserEnableLocalVideo_enabled, enabled) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUserStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserStateChanged_state, state) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnLocalAudioStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<LocalAudioStats>(OnLocalAudioStats_stats, stats) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<RemoteAudioStats>(OnRemoteAudioStats_stats, stats) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnLocalVideoStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<LocalVideoStats>(OnLocalVideoStats_stats, stats) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<RemoteVideoStats>(OnRemoteVideoStats_stats, stats) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnConnectionLost_connection, connection) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnConnectionInterrupted_connection, connection) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnConnectionBanned_connection, connection) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnStreamMessage_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnStreamMessage_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessage_streamId, streamId) == false)
                return false;
            if (ParamsHelper.Compare<byte[]>(OnStreamMessage_data, data) == false)
                return false;
            if (ParamsHelper.Compare<ulong>(OnStreamMessage_length, length) == false)
                return false;
            if (ParamsHelper.Compare<ulong>(OnStreamMessage_sentTs, sentTs) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnStreamMessageError_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnStreamMessageError_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError_streamId, streamId) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError_code, code) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError_missed, missed) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError_cached, cached) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRequestToken_connection, connection) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnLicenseValidationFailure_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<LICENSE_ERROR_TYPE>(OnLicenseValidationFailure_reason, reason) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnTokenPrivilegeWillExpire_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnTokenPrivilegeWillExpire_token, token) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnFirstLocalAudioFramePublished_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalAudioFramePublished_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteAudioFrame_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnFirstRemoteAudioFrame_userId, userId) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteAudioFrame_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnFirstRemoteAudioDecoded_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnFirstRemoteAudioDecoded_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteAudioDecoded_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalAudioStateChanged_be_trigger = false;
        public RtcConnection OnLocalAudioStateChanged_connection;
        public LOCAL_AUDIO_STREAM_STATE OnLocalAudioStateChanged_state;
        public LOCAL_AUDIO_STREAM_ERROR OnLocalAudioStateChanged_error;
        public override void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            OnLocalAudioStateChanged_be_trigger = true;
            OnLocalAudioStateChanged_connection = connection;
            OnLocalAudioStateChanged_state = state;
            OnLocalAudioStateChanged_error = error;
        }

        public bool OnLocalAudioStateChangedPassed(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            if (OnLocalAudioStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnLocalAudioStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_AUDIO_STREAM_STATE>(OnLocalAudioStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_AUDIO_STREAM_ERROR>(OnLocalAudioStateChanged_error, error) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteAudioStateChanged_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_AUDIO_STATE>(OnRemoteAudioStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_AUDIO_STATE_REASON>(OnRemoteAudioStateChanged_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRemoteAudioStateChanged_elapsed, elapsed) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnActiveSpeaker_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnActiveSpeaker_uid, uid) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnClientRoleChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChanged_oldRole, oldRole) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChanged_newRole, newRole) == false)
                return false;
            if (ParamsHelper.Compare<ClientRoleOptions>(OnClientRoleChanged_newRoleOptions, newRoleOptions) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnClientRoleChangeFailed_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_CHANGE_FAILED_REASON>(OnClientRoleChangeFailed_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChangeFailed_currentRole, currentRole) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteAudioTransportStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteAudioTransportStats_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_delay, delay) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_lost, lost) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteAudioTransportStats_rxKBitRate, rxKBitRate) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnRemoteVideoTransportStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteVideoTransportStats_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_delay, delay) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_lost, lost) == false)
                return false;
            if (ParamsHelper.Compare<ushort>(OnRemoteVideoTransportStats_rxKBitRate, rxKBitRate) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnConnectionStateChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<CONNECTION_STATE_TYPE>(OnConnectionStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<CONNECTION_CHANGED_REASON_TYPE>(OnConnectionStateChanged_reason, reason) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnWlAccMessage_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<WLACC_MESSAGE_REASON>(OnWlAccMessage_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<WLACC_SUGGEST_ACTION>(OnWlAccMessage_action, action) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnWlAccMessage_wlAccMsg, wlAccMsg) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnWlAccStats_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<WlAccStats>(OnWlAccStats_currentStats, currentStats) == false)
                return false;
            if (ParamsHelper.Compare<WlAccStats>(OnWlAccStats_averageStats, averageStats) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnNetworkTypeChanged_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<NETWORK_TYPE>(OnNetworkTypeChanged_type, type) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnEncryptionError_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<ENCRYPTION_ERROR_TYPE>(OnEncryptionError_errorType, errorType) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUploadLogResult_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUploadLogResult_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUploadLogResult_success, success) == false)
                return false;
            if (ParamsHelper.Compare<UPLOAD_ERROR_REASON>(OnUploadLogResult_reason, reason) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnUserAccountUpdated_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserAccountUpdated_remoteUid, remoteUid) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserAccountUpdated_remoteUserAccount, remoteUserAccount) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnSnapshotTaken_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnSnapshotTaken_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnSnapshotTaken_filePath, filePath) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken_errCode, errCode) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnVideoRenderingTracingResult_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnVideoRenderingTracingResult_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<MEDIA_TRACE_EVENT>(OnVideoRenderingTracingResult_currentEvent, currentEvent) == false)
                return false;
            if (ParamsHelper.Compare<VideoRenderingTracingInfo>(OnVideoRenderingTracingResult_tracingInfo, tracingInfo) == false)
                return false;
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
            if (ParamsHelper.Compare<RtcConnection>(OnSetRtmFlagResult_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSetRtmFlagResult_code, code) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoLayoutInfo_be_trigger = false;
        public RtcConnection OnVideoLayoutInfo_connection;
        public uint OnVideoLayoutInfo_uid;
        public int OnVideoLayoutInfo_width;
        public int OnVideoLayoutInfo_height;
        public int OnVideoLayoutInfo_layoutNumber;
        public VideoLayout[] OnVideoLayoutInfo_layoutlist;
        public override void OnVideoLayoutInfo(RtcConnection connection, uint uid, int width, int height, int layoutNumber, VideoLayout[] layoutlist)
        {
            OnVideoLayoutInfo_be_trigger = true;
            OnVideoLayoutInfo_connection = connection;
            OnVideoLayoutInfo_uid = uid;
            OnVideoLayoutInfo_width = width;
            OnVideoLayoutInfo_height = height;
            OnVideoLayoutInfo_layoutNumber = layoutNumber;
            OnVideoLayoutInfo_layoutlist = layoutlist;
        }

        public bool OnVideoLayoutInfoPassed(RtcConnection connection, uint uid, int width, int height, int layoutNumber, VideoLayout[] layoutlist)
        {
            if (OnVideoLayoutInfo_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnection>(OnVideoLayoutInfo_connection, connection) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnVideoLayoutInfo_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoLayoutInfo_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoLayoutInfo_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoLayoutInfo_layoutNumber, layoutNumber) == false)
                return false;
            if (ParamsHelper.Compare<VideoLayout[]>(OnVideoLayoutInfo_layoutlist, layoutlist) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnJoinChannelSuccess2_be_trigger = false;
        public RtcConnectionS OnJoinChannelSuccess2_connectionS;
        public int OnJoinChannelSuccess2_elapsed;
        public override void OnJoinChannelSuccess(RtcConnectionS connectionS, int elapsed)
        {
            OnJoinChannelSuccess2_be_trigger = true;
            OnJoinChannelSuccess2_connectionS = connectionS;
            OnJoinChannelSuccess2_elapsed = elapsed;
        }

        public bool OnJoinChannelSuccess2Passed(RtcConnectionS connectionS, int elapsed)
        {
            if (OnJoinChannelSuccess2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnJoinChannelSuccess2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnJoinChannelSuccess2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRejoinChannelSuccess2_be_trigger = false;
        public RtcConnectionS OnRejoinChannelSuccess2_connectionS;
        public int OnRejoinChannelSuccess2_elapsed;
        public override void OnRejoinChannelSuccess(RtcConnectionS connectionS, int elapsed)
        {
            OnRejoinChannelSuccess2_be_trigger = true;
            OnRejoinChannelSuccess2_connectionS = connectionS;
            OnRejoinChannelSuccess2_elapsed = elapsed;
        }

        public bool OnRejoinChannelSuccess2Passed(RtcConnectionS connectionS, int elapsed)
        {
            if (OnRejoinChannelSuccess2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRejoinChannelSuccess2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRejoinChannelSuccess2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnAudioVolumeIndication2_be_trigger = false;
        public RtcConnectionS OnAudioVolumeIndication2_connectionS;
        public AudioVolumeInfoS[] OnAudioVolumeIndication2_speakersS;
        public uint OnAudioVolumeIndication2_speakerNumber;
        public int OnAudioVolumeIndication2_totalVolume;
        public override void OnAudioVolumeIndication(RtcConnectionS connectionS, AudioVolumeInfoS[] speakersS, uint speakerNumber, int totalVolume)
        {
            OnAudioVolumeIndication2_be_trigger = true;
            OnAudioVolumeIndication2_connectionS = connectionS;
            OnAudioVolumeIndication2_speakersS = speakersS;
            OnAudioVolumeIndication2_speakerNumber = speakerNumber;
            OnAudioVolumeIndication2_totalVolume = totalVolume;
        }

        public bool OnAudioVolumeIndication2Passed(RtcConnectionS connectionS, AudioVolumeInfoS[] speakersS, uint speakerNumber, int totalVolume)
        {
            if (OnAudioVolumeIndication2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnAudioVolumeIndication2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<AudioVolumeInfoS[]>(OnAudioVolumeIndication2_speakersS, speakersS) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnAudioVolumeIndication2_speakerNumber, speakerNumber) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioVolumeIndication2_totalVolume, totalVolume) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLeaveChannel2_be_trigger = false;
        public RtcConnectionS OnLeaveChannel2_connectionS;
        public RtcStats OnLeaveChannel2_stats;
        public override void OnLeaveChannel(RtcConnectionS connectionS, RtcStats stats)
        {
            OnLeaveChannel2_be_trigger = true;
            OnLeaveChannel2_connectionS = connectionS;
            OnLeaveChannel2_stats = stats;
        }

        public bool OnLeaveChannel2Passed(RtcConnectionS connectionS, RtcStats stats)
        {
            if (OnLeaveChannel2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLeaveChannel2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<RtcStats>(OnLeaveChannel2_stats, stats) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRtcStats2_be_trigger = false;
        public RtcConnectionS OnRtcStats2_connectionS;
        public RtcStats OnRtcStats2_stats;
        public override void OnRtcStats(RtcConnectionS connectionS, RtcStats stats)
        {
            OnRtcStats2_be_trigger = true;
            OnRtcStats2_connectionS = connectionS;
            OnRtcStats2_stats = stats;
        }

        public bool OnRtcStats2Passed(RtcConnectionS connectionS, RtcStats stats)
        {
            if (OnRtcStats2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRtcStats2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<RtcStats>(OnRtcStats2_stats, stats) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnNetworkQuality2_be_trigger = false;
        public RtcConnectionS OnNetworkQuality2_connectionS;
        public string OnNetworkQuality2_remoteUserAccount;
        public int OnNetworkQuality2_txQuality;
        public int OnNetworkQuality2_rxQuality;
        public override void OnNetworkQuality(RtcConnectionS connectionS, string remoteUserAccount, int txQuality, int rxQuality)
        {
            OnNetworkQuality2_be_trigger = true;
            OnNetworkQuality2_connectionS = connectionS;
            OnNetworkQuality2_remoteUserAccount = remoteUserAccount;
            OnNetworkQuality2_txQuality = txQuality;
            OnNetworkQuality2_rxQuality = rxQuality;
        }

        public bool OnNetworkQuality2Passed(RtcConnectionS connectionS, string remoteUserAccount, int txQuality, int rxQuality)
        {
            if (OnNetworkQuality2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnNetworkQuality2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnNetworkQuality2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnNetworkQuality2_txQuality, txQuality) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnNetworkQuality2_rxQuality, rxQuality) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnIntraRequestReceived2_be_trigger = false;
        public RtcConnectionS OnIntraRequestReceived2_connectionS;
        public override void OnIntraRequestReceived(RtcConnectionS connectionS)
        {
            OnIntraRequestReceived2_be_trigger = true;
            OnIntraRequestReceived2_connectionS = connectionS;
        }

        public bool OnIntraRequestReceived2Passed(RtcConnectionS connectionS)
        {
            if (OnIntraRequestReceived2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnIntraRequestReceived2_connectionS, connectionS) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnFirstLocalVideoFramePublished2_be_trigger = false;
        public RtcConnectionS OnFirstLocalVideoFramePublished2_connectionS;
        public int OnFirstLocalVideoFramePublished2_elapsed;
        public override void OnFirstLocalVideoFramePublished(RtcConnectionS connectionS, int elapsed)
        {
            OnFirstLocalVideoFramePublished2_be_trigger = true;
            OnFirstLocalVideoFramePublished2_connectionS = connectionS;
            OnFirstLocalVideoFramePublished2_elapsed = elapsed;
        }

        public bool OnFirstLocalVideoFramePublished2Passed(RtcConnectionS connectionS, int elapsed)
        {
            if (OnFirstLocalVideoFramePublished2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnFirstLocalVideoFramePublished2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalVideoFramePublished2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnFirstRemoteVideoDecoded2_be_trigger = false;
        public RtcConnectionS OnFirstRemoteVideoDecoded2_connectionS;
        public string OnFirstRemoteVideoDecoded2_remoteUserAccount;
        public int OnFirstRemoteVideoDecoded2_width;
        public int OnFirstRemoteVideoDecoded2_height;
        public int OnFirstRemoteVideoDecoded2_elapsed;
        public override void OnFirstRemoteVideoDecoded(RtcConnectionS connectionS, string remoteUserAccount, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoDecoded2_be_trigger = true;
            OnFirstRemoteVideoDecoded2_connectionS = connectionS;
            OnFirstRemoteVideoDecoded2_remoteUserAccount = remoteUserAccount;
            OnFirstRemoteVideoDecoded2_width = width;
            OnFirstRemoteVideoDecoded2_height = height;
            OnFirstRemoteVideoDecoded2_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoDecoded2Passed(RtcConnectionS connectionS, string remoteUserAccount, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoDecoded2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnFirstRemoteVideoDecoded2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnFirstRemoteVideoDecoded2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded2_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded2_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoDecoded2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoSizeChanged2_be_trigger = false;
        public RtcConnectionS OnVideoSizeChanged2_connectionS;
        public VIDEO_SOURCE_TYPE OnVideoSizeChanged2_sourceType;
        public string OnVideoSizeChanged2_userAccount;
        public int OnVideoSizeChanged2_width;
        public int OnVideoSizeChanged2_height;
        public int OnVideoSizeChanged2_rotation;
        public override void OnVideoSizeChanged(RtcConnectionS connectionS, VIDEO_SOURCE_TYPE sourceType, string userAccount, int width, int height, int rotation)
        {
            OnVideoSizeChanged2_be_trigger = true;
            OnVideoSizeChanged2_connectionS = connectionS;
            OnVideoSizeChanged2_sourceType = sourceType;
            OnVideoSizeChanged2_userAccount = userAccount;
            OnVideoSizeChanged2_width = width;
            OnVideoSizeChanged2_height = height;
            OnVideoSizeChanged2_rotation = rotation;
        }

        public bool OnVideoSizeChanged2Passed(RtcConnectionS connectionS, VIDEO_SOURCE_TYPE sourceType, string userAccount, int width, int height, int rotation)
        {
            if (OnVideoSizeChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnVideoSizeChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnVideoSizeChanged2_sourceType, sourceType) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnVideoSizeChanged2_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged2_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged2_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnVideoSizeChanged2_rotation, rotation) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalVideoStateChanged2_be_trigger = false;
        public RtcConnectionS OnLocalVideoStateChanged2_connectionS;
        public LOCAL_VIDEO_STREAM_STATE OnLocalVideoStateChanged2_state;
        public LOCAL_VIDEO_STREAM_ERROR OnLocalVideoStateChanged2_errorCode;
        public override void OnLocalVideoStateChanged(RtcConnectionS connectionS, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            OnLocalVideoStateChanged2_be_trigger = true;
            OnLocalVideoStateChanged2_connectionS = connectionS;
            OnLocalVideoStateChanged2_state = state;
            OnLocalVideoStateChanged2_errorCode = errorCode;
        }

        public bool OnLocalVideoStateChanged2Passed(RtcConnectionS connectionS, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
            if (OnLocalVideoStateChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLocalVideoStateChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_STATE>(OnLocalVideoStateChanged2_state, state) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_VIDEO_STREAM_ERROR>(OnLocalVideoStateChanged2_errorCode, errorCode) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteVideoStateChanged2_be_trigger = false;
        public RtcConnectionS OnRemoteVideoStateChanged2_connectionS;
        public string OnRemoteVideoStateChanged2_userAccount;
        public REMOTE_VIDEO_STATE OnRemoteVideoStateChanged2_state;
        public REMOTE_VIDEO_STATE_REASON OnRemoteVideoStateChanged2_reason;
        public int OnRemoteVideoStateChanged2_elapsed;
        public override void OnRemoteVideoStateChanged(RtcConnectionS connectionS, string userAccount, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            OnRemoteVideoStateChanged2_be_trigger = true;
            OnRemoteVideoStateChanged2_connectionS = connectionS;
            OnRemoteVideoStateChanged2_userAccount = userAccount;
            OnRemoteVideoStateChanged2_state = state;
            OnRemoteVideoStateChanged2_reason = reason;
            OnRemoteVideoStateChanged2_elapsed = elapsed;
        }

        public bool OnRemoteVideoStateChanged2Passed(RtcConnectionS connectionS, string userAccount, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteVideoStateChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRemoteVideoStateChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnRemoteVideoStateChanged2_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_VIDEO_STATE>(OnRemoteVideoStateChanged2_state, state) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_VIDEO_STATE_REASON>(OnRemoteVideoStateChanged2_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRemoteVideoStateChanged2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnFirstRemoteVideoFrame2_be_trigger = false;
        public RtcConnectionS OnFirstRemoteVideoFrame2_connectionS;
        public string OnFirstRemoteVideoFrame2_userAccount;
        public int OnFirstRemoteVideoFrame2_width;
        public int OnFirstRemoteVideoFrame2_height;
        public int OnFirstRemoteVideoFrame2_elapsed;
        public override void OnFirstRemoteVideoFrame(RtcConnectionS connectionS, string userAccount, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoFrame2_be_trigger = true;
            OnFirstRemoteVideoFrame2_connectionS = connectionS;
            OnFirstRemoteVideoFrame2_userAccount = userAccount;
            OnFirstRemoteVideoFrame2_width = width;
            OnFirstRemoteVideoFrame2_height = height;
            OnFirstRemoteVideoFrame2_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoFrame2Passed(RtcConnectionS connectionS, string userAccount, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoFrame2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnFirstRemoteVideoFrame2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnFirstRemoteVideoFrame2_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame2_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame2_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstRemoteVideoFrame2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserJoined2_be_trigger = false;
        public RtcConnectionS OnUserJoined2_connectionS;
        public string OnUserJoined2_userAccount;
        public int OnUserJoined2_elapsed;
        public override void OnUserJoined(RtcConnectionS connectionS, string userAccount, int elapsed)
        {
            OnUserJoined2_be_trigger = true;
            OnUserJoined2_connectionS = connectionS;
            OnUserJoined2_userAccount = userAccount;
            OnUserJoined2_elapsed = elapsed;
        }

        public bool OnUserJoined2Passed(RtcConnectionS connectionS, string userAccount, int elapsed)
        {
            if (OnUserJoined2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserJoined2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserJoined2_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnUserJoined2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserOffline2_be_trigger = false;
        public RtcConnectionS OnUserOffline2_connectionS;
        public string OnUserOffline2_userAccount;
        public USER_OFFLINE_REASON_TYPE OnUserOffline2_reason;
        public override void OnUserOffline(RtcConnectionS connectionS, string userAccount, USER_OFFLINE_REASON_TYPE reason)
        {
            OnUserOffline2_be_trigger = true;
            OnUserOffline2_connectionS = connectionS;
            OnUserOffline2_userAccount = userAccount;
            OnUserOffline2_reason = reason;
        }

        public bool OnUserOffline2Passed(RtcConnectionS connectionS, string userAccount, USER_OFFLINE_REASON_TYPE reason)
        {
            if (OnUserOffline2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserOffline2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserOffline2_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<USER_OFFLINE_REASON_TYPE>(OnUserOffline2_reason, reason) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserMuteAudio2_be_trigger = false;
        public RtcConnectionS OnUserMuteAudio2_connectionS;
        public string OnUserMuteAudio2_remoteUserAccount;
        public bool OnUserMuteAudio2_muted;
        public override void OnUserMuteAudio(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            OnUserMuteAudio2_be_trigger = true;
            OnUserMuteAudio2_connectionS = connectionS;
            OnUserMuteAudio2_remoteUserAccount = remoteUserAccount;
            OnUserMuteAudio2_muted = muted;
        }

        public bool OnUserMuteAudio2Passed(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            if (OnUserMuteAudio2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserMuteAudio2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserMuteAudio2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserMuteAudio2_muted, muted) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserMuteVideo2_be_trigger = false;
        public RtcConnectionS OnUserMuteVideo2_connectionS;
        public string OnUserMuteVideo2_remoteUserAccount;
        public bool OnUserMuteVideo2_muted;
        public override void OnUserMuteVideo(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            OnUserMuteVideo2_be_trigger = true;
            OnUserMuteVideo2_connectionS = connectionS;
            OnUserMuteVideo2_remoteUserAccount = remoteUserAccount;
            OnUserMuteVideo2_muted = muted;
        }

        public bool OnUserMuteVideo2Passed(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            if (OnUserMuteVideo2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserMuteVideo2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserMuteVideo2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserMuteVideo2_muted, muted) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserEnableVideo2_be_trigger = false;
        public RtcConnectionS OnUserEnableVideo2_connectionS;
        public string OnUserEnableVideo2_remoteUserAccount;
        public bool OnUserEnableVideo2_enabled;
        public override void OnUserEnableVideo(RtcConnectionS connectionS, string remoteUserAccount, bool enabled)
        {
            OnUserEnableVideo2_be_trigger = true;
            OnUserEnableVideo2_connectionS = connectionS;
            OnUserEnableVideo2_remoteUserAccount = remoteUserAccount;
            OnUserEnableVideo2_enabled = enabled;
        }

        public bool OnUserEnableVideo2Passed(RtcConnectionS connectionS, string remoteUserAccount, bool enabled)
        {
            if (OnUserEnableVideo2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserEnableVideo2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserEnableVideo2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserEnableVideo2_enabled, enabled) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUserStateChanged2_be_trigger = false;
        public RtcConnectionS OnUserStateChanged2_connectionS;
        public string OnUserStateChanged2_remoteUserAccount;
        public uint OnUserStateChanged2_state;
        public override void OnUserStateChanged(RtcConnectionS connectionS, string remoteUserAccount, uint state)
        {
            OnUserStateChanged2_be_trigger = true;
            OnUserStateChanged2_connectionS = connectionS;
            OnUserStateChanged2_remoteUserAccount = remoteUserAccount;
            OnUserStateChanged2_state = state;
        }

        public bool OnUserStateChanged2Passed(RtcConnectionS connectionS, string remoteUserAccount, uint state)
        {
            if (OnUserStateChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserStateChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserStateChanged2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserStateChanged2_state, state) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalAudioStats2_be_trigger = false;
        public RtcConnectionS OnLocalAudioStats2_connectionS;
        public LocalAudioStats OnLocalAudioStats2_stats;
        public override void OnLocalAudioStats(RtcConnectionS connectionS, LocalAudioStats stats)
        {
            OnLocalAudioStats2_be_trigger = true;
            OnLocalAudioStats2_connectionS = connectionS;
            OnLocalAudioStats2_stats = stats;
        }

        public bool OnLocalAudioStats2Passed(RtcConnectionS connectionS, LocalAudioStats stats)
        {
            if (OnLocalAudioStats2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLocalAudioStats2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LocalAudioStats>(OnLocalAudioStats2_stats, stats) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteAudioStats2_be_trigger = false;
        public RtcConnectionS OnRemoteAudioStats2_connectionS;
        public RemoteAudioStatsS OnRemoteAudioStats2_statsS;
        public override void OnRemoteAudioStats(RtcConnectionS connectionS, RemoteAudioStatsS statsS)
        {
            OnRemoteAudioStats2_be_trigger = true;
            OnRemoteAudioStats2_connectionS = connectionS;
            OnRemoteAudioStats2_statsS = statsS;
        }

        public bool OnRemoteAudioStats2Passed(RtcConnectionS connectionS, RemoteAudioStatsS statsS)
        {
            if (OnRemoteAudioStats2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRemoteAudioStats2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<RemoteAudioStatsS>(OnRemoteAudioStats2_statsS, statsS) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalVideoStats2_be_trigger = false;
        public RtcConnectionS OnLocalVideoStats2_connectionS;
        public LocalVideoStatsS OnLocalVideoStats2_statsS;
        public override void OnLocalVideoStats(RtcConnectionS connectionS, LocalVideoStatsS statsS)
        {
            OnLocalVideoStats2_be_trigger = true;
            OnLocalVideoStats2_connectionS = connectionS;
            OnLocalVideoStats2_statsS = statsS;
        }

        public bool OnLocalVideoStats2Passed(RtcConnectionS connectionS, LocalVideoStatsS statsS)
        {
            if (OnLocalVideoStats2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLocalVideoStats2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LocalVideoStatsS>(OnLocalVideoStats2_statsS, statsS) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteVideoStats2_be_trigger = false;
        public RtcConnectionS OnRemoteVideoStats2_connectionS;
        public RemoteVideoStatsS OnRemoteVideoStats2_statsS;
        public override void OnRemoteVideoStats(RtcConnectionS connectionS, RemoteVideoStatsS statsS)
        {
            OnRemoteVideoStats2_be_trigger = true;
            OnRemoteVideoStats2_connectionS = connectionS;
            OnRemoteVideoStats2_statsS = statsS;
        }

        public bool OnRemoteVideoStats2Passed(RtcConnectionS connectionS, RemoteVideoStatsS statsS)
        {
            if (OnRemoteVideoStats2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRemoteVideoStats2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<RemoteVideoStatsS>(OnRemoteVideoStats2_statsS, statsS) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnConnectionLost2_be_trigger = false;
        public RtcConnectionS OnConnectionLost2_connectionS;
        public override void OnConnectionLost(RtcConnectionS connectionS)
        {
            OnConnectionLost2_be_trigger = true;
            OnConnectionLost2_connectionS = connectionS;
        }

        public bool OnConnectionLost2Passed(RtcConnectionS connectionS)
        {
            if (OnConnectionLost2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnConnectionLost2_connectionS, connectionS) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnConnectionBanned2_be_trigger = false;
        public RtcConnectionS OnConnectionBanned2_connectionS;
        public override void OnConnectionBanned(RtcConnectionS connectionS)
        {
            OnConnectionBanned2_be_trigger = true;
            OnConnectionBanned2_connectionS = connectionS;
        }

        public bool OnConnectionBanned2Passed(RtcConnectionS connectionS)
        {
            if (OnConnectionBanned2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnConnectionBanned2_connectionS, connectionS) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnStreamMessage2_be_trigger = false;
        public RtcConnectionS OnStreamMessage2_connectionS;
        public string OnStreamMessage2_remoteUserAccount;
        public int OnStreamMessage2_streamId;
        public byte[] OnStreamMessage2_data;
        public ulong OnStreamMessage2_length;
        public ulong OnStreamMessage2_sentTs;
        public override void OnStreamMessage(RtcConnectionS connectionS, string remoteUserAccount, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            OnStreamMessage2_be_trigger = true;
            OnStreamMessage2_connectionS = connectionS;
            OnStreamMessage2_remoteUserAccount = remoteUserAccount;
            OnStreamMessage2_streamId = streamId;
            OnStreamMessage2_data = data;
            OnStreamMessage2_length = length;
            OnStreamMessage2_sentTs = sentTs;
        }

        public bool OnStreamMessage2Passed(RtcConnectionS connectionS, string remoteUserAccount, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            if (OnStreamMessage2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnStreamMessage2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnStreamMessage2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessage2_streamId, streamId) == false)
                return false;
            if (ParamsHelper.Compare<byte[]>(OnStreamMessage2_data, data) == false)
                return false;
            if (ParamsHelper.Compare<ulong>(OnStreamMessage2_length, length) == false)
                return false;
            if (ParamsHelper.Compare<ulong>(OnStreamMessage2_sentTs, sentTs) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnStreamMessageError2_be_trigger = false;
        public RtcConnectionS OnStreamMessageError2_connectionS;
        public string OnStreamMessageError2_remoteUserAccount;
        public int OnStreamMessageError2_streamId;
        public int OnStreamMessageError2_code;
        public int OnStreamMessageError2_missed;
        public int OnStreamMessageError2_cached;
        public override void OnStreamMessageError(RtcConnectionS connectionS, string remoteUserAccount, int streamId, int code, int missed, int cached)
        {
            OnStreamMessageError2_be_trigger = true;
            OnStreamMessageError2_connectionS = connectionS;
            OnStreamMessageError2_remoteUserAccount = remoteUserAccount;
            OnStreamMessageError2_streamId = streamId;
            OnStreamMessageError2_code = code;
            OnStreamMessageError2_missed = missed;
            OnStreamMessageError2_cached = cached;
        }

        public bool OnStreamMessageError2Passed(RtcConnectionS connectionS, string remoteUserAccount, int streamId, int code, int missed, int cached)
        {
            if (OnStreamMessageError2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnStreamMessageError2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnStreamMessageError2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError2_streamId, streamId) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError2_code, code) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError2_missed, missed) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnStreamMessageError2_cached, cached) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRequestToken2_be_trigger = false;
        public RtcConnectionS OnRequestToken2_connectionS;
        public override void OnRequestToken(RtcConnectionS connectionS)
        {
            OnRequestToken2_be_trigger = true;
            OnRequestToken2_connectionS = connectionS;
        }

        public bool OnRequestToken2Passed(RtcConnectionS connectionS)
        {
            if (OnRequestToken2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRequestToken2_connectionS, connectionS) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLicenseValidationFailure2_be_trigger = false;
        public RtcConnectionS OnLicenseValidationFailure2_connectionS;
        public LICENSE_ERROR_TYPE OnLicenseValidationFailure2_reason;
        public override void OnLicenseValidationFailure(RtcConnectionS connectionS, LICENSE_ERROR_TYPE reason)
        {
            OnLicenseValidationFailure2_be_trigger = true;
            OnLicenseValidationFailure2_connectionS = connectionS;
            OnLicenseValidationFailure2_reason = reason;
        }

        public bool OnLicenseValidationFailure2Passed(RtcConnectionS connectionS, LICENSE_ERROR_TYPE reason)
        {
            if (OnLicenseValidationFailure2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLicenseValidationFailure2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LICENSE_ERROR_TYPE>(OnLicenseValidationFailure2_reason, reason) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnTokenPrivilegeWillExpire2_be_trigger = false;
        public RtcConnectionS OnTokenPrivilegeWillExpire2_connectionS;
        public string OnTokenPrivilegeWillExpire2_token;
        public override void OnTokenPrivilegeWillExpire(RtcConnectionS connectionS, string token)
        {
            OnTokenPrivilegeWillExpire2_be_trigger = true;
            OnTokenPrivilegeWillExpire2_connectionS = connectionS;
            OnTokenPrivilegeWillExpire2_token = token;
        }

        public bool OnTokenPrivilegeWillExpire2Passed(RtcConnectionS connectionS, string token)
        {
            if (OnTokenPrivilegeWillExpire2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnTokenPrivilegeWillExpire2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnTokenPrivilegeWillExpire2_token, token) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnFirstLocalAudioFramePublished2_be_trigger = false;
        public RtcConnectionS OnFirstLocalAudioFramePublished2_connectionS;
        public int OnFirstLocalAudioFramePublished2_elapsed;
        public override void OnFirstLocalAudioFramePublished(RtcConnectionS connectionS, int elapsed)
        {
            OnFirstLocalAudioFramePublished2_be_trigger = true;
            OnFirstLocalAudioFramePublished2_connectionS = connectionS;
            OnFirstLocalAudioFramePublished2_elapsed = elapsed;
        }

        public bool OnFirstLocalAudioFramePublished2Passed(RtcConnectionS connectionS, int elapsed)
        {
            if (OnFirstLocalAudioFramePublished2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnFirstLocalAudioFramePublished2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalAudioFramePublished2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnLocalAudioStateChanged2_be_trigger = false;
        public RtcConnectionS OnLocalAudioStateChanged2_connectionS;
        public LOCAL_AUDIO_STREAM_STATE OnLocalAudioStateChanged2_state;
        public LOCAL_AUDIO_STREAM_ERROR OnLocalAudioStateChanged2_error;
        public override void OnLocalAudioStateChanged(RtcConnectionS connectionS, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            OnLocalAudioStateChanged2_be_trigger = true;
            OnLocalAudioStateChanged2_connectionS = connectionS;
            OnLocalAudioStateChanged2_state = state;
            OnLocalAudioStateChanged2_error = error;
        }

        public bool OnLocalAudioStateChanged2Passed(RtcConnectionS connectionS, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            if (OnLocalAudioStateChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLocalAudioStateChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_AUDIO_STREAM_STATE>(OnLocalAudioStateChanged2_state, state) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_AUDIO_STREAM_ERROR>(OnLocalAudioStateChanged2_error, error) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnRemoteAudioStateChanged2_be_trigger = false;
        public RtcConnectionS OnRemoteAudioStateChanged2_connectionS;
        public string OnRemoteAudioStateChanged2_remoteUserAccount;
        public REMOTE_AUDIO_STATE OnRemoteAudioStateChanged2_state;
        public REMOTE_AUDIO_STATE_REASON OnRemoteAudioStateChanged2_reason;
        public int OnRemoteAudioStateChanged2_elapsed;
        public override void OnRemoteAudioStateChanged(RtcConnectionS connectionS, string remoteUserAccount, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            OnRemoteAudioStateChanged2_be_trigger = true;
            OnRemoteAudioStateChanged2_connectionS = connectionS;
            OnRemoteAudioStateChanged2_remoteUserAccount = remoteUserAccount;
            OnRemoteAudioStateChanged2_state = state;
            OnRemoteAudioStateChanged2_reason = reason;
            OnRemoteAudioStateChanged2_elapsed = elapsed;
        }

        public bool OnRemoteAudioStateChanged2Passed(RtcConnectionS connectionS, string remoteUserAccount, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteAudioStateChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRemoteAudioStateChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnRemoteAudioStateChanged2_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_AUDIO_STATE>(OnRemoteAudioStateChanged2_state, state) == false)
                return false;
            if (ParamsHelper.Compare<REMOTE_AUDIO_STATE_REASON>(OnRemoteAudioStateChanged2_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRemoteAudioStateChanged2_elapsed, elapsed) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnActiveSpeaker2_be_trigger = false;
        public RtcConnectionS OnActiveSpeaker2_connectionS;
        public string OnActiveSpeaker2_userAccount;
        public override void OnActiveSpeaker(RtcConnectionS connectionS, string userAccount)
        {
            OnActiveSpeaker2_be_trigger = true;
            OnActiveSpeaker2_connectionS = connectionS;
            OnActiveSpeaker2_userAccount = userAccount;
        }

        public bool OnActiveSpeaker2Passed(RtcConnectionS connectionS, string userAccount)
        {
            if (OnActiveSpeaker2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnActiveSpeaker2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnActiveSpeaker2_userAccount, userAccount) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnClientRoleChanged2_be_trigger = false;
        public RtcConnectionS OnClientRoleChanged2_connectionS;
        public CLIENT_ROLE_TYPE OnClientRoleChanged2_oldRole;
        public CLIENT_ROLE_TYPE OnClientRoleChanged2_newRole;
        public ClientRoleOptions OnClientRoleChanged2_newRoleOptions;
        public override void OnClientRoleChanged(RtcConnectionS connectionS, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            OnClientRoleChanged2_be_trigger = true;
            OnClientRoleChanged2_connectionS = connectionS;
            OnClientRoleChanged2_oldRole = oldRole;
            OnClientRoleChanged2_newRole = newRole;
            OnClientRoleChanged2_newRoleOptions = newRoleOptions;
        }

        public bool OnClientRoleChanged2Passed(RtcConnectionS connectionS, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            if (OnClientRoleChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnClientRoleChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChanged2_oldRole, oldRole) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChanged2_newRole, newRole) == false)
                return false;
            if (ParamsHelper.Compare<ClientRoleOptions>(OnClientRoleChanged2_newRoleOptions, newRoleOptions) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnClientRoleChangeFailed2_be_trigger = false;
        public RtcConnectionS OnClientRoleChangeFailed2_connectionS;
        public CLIENT_ROLE_CHANGE_FAILED_REASON OnClientRoleChangeFailed2_reason;
        public CLIENT_ROLE_TYPE OnClientRoleChangeFailed2_currentRole;
        public override void OnClientRoleChangeFailed(RtcConnectionS connectionS, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            OnClientRoleChangeFailed2_be_trigger = true;
            OnClientRoleChangeFailed2_connectionS = connectionS;
            OnClientRoleChangeFailed2_reason = reason;
            OnClientRoleChangeFailed2_currentRole = currentRole;
        }

        public bool OnClientRoleChangeFailed2Passed(RtcConnectionS connectionS, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            if (OnClientRoleChangeFailed2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnClientRoleChangeFailed2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_CHANGE_FAILED_REASON>(OnClientRoleChangeFailed2_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChangeFailed2_currentRole, currentRole) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnConnectionStateChanged2_be_trigger = false;
        public RtcConnectionS OnConnectionStateChanged2_connectionS;
        public CONNECTION_STATE_TYPE OnConnectionStateChanged2_state;
        public CONNECTION_CHANGED_REASON_TYPE OnConnectionStateChanged2_reason;
        public override void OnConnectionStateChanged(RtcConnectionS connectionS, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            OnConnectionStateChanged2_be_trigger = true;
            OnConnectionStateChanged2_connectionS = connectionS;
            OnConnectionStateChanged2_state = state;
            OnConnectionStateChanged2_reason = reason;
        }

        public bool OnConnectionStateChanged2Passed(RtcConnectionS connectionS, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            if (OnConnectionStateChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnConnectionStateChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<CONNECTION_STATE_TYPE>(OnConnectionStateChanged2_state, state) == false)
                return false;
            if (ParamsHelper.Compare<CONNECTION_CHANGED_REASON_TYPE>(OnConnectionStateChanged2_reason, reason) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnWlAccMessage2_be_trigger = false;
        public RtcConnectionS OnWlAccMessage2_connectionS;
        public WLACC_MESSAGE_REASON OnWlAccMessage2_reason;
        public WLACC_SUGGEST_ACTION OnWlAccMessage2_action;
        public string OnWlAccMessage2_wlAccMsg;
        public override void OnWlAccMessage(RtcConnectionS connectionS, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            OnWlAccMessage2_be_trigger = true;
            OnWlAccMessage2_connectionS = connectionS;
            OnWlAccMessage2_reason = reason;
            OnWlAccMessage2_action = action;
            OnWlAccMessage2_wlAccMsg = wlAccMsg;
        }

        public bool OnWlAccMessage2Passed(RtcConnectionS connectionS, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            if (OnWlAccMessage2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnWlAccMessage2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<WLACC_MESSAGE_REASON>(OnWlAccMessage2_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<WLACC_SUGGEST_ACTION>(OnWlAccMessage2_action, action) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnWlAccMessage2_wlAccMsg, wlAccMsg) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnWlAccStats2_be_trigger = false;
        public RtcConnectionS OnWlAccStats2_connectionS;
        public WlAccStats OnWlAccStats2_currentStats;
        public WlAccStats OnWlAccStats2_averageStats;
        public override void OnWlAccStats(RtcConnectionS connectionS, WlAccStats currentStats, WlAccStats averageStats)
        {
            OnWlAccStats2_be_trigger = true;
            OnWlAccStats2_connectionS = connectionS;
            OnWlAccStats2_currentStats = currentStats;
            OnWlAccStats2_averageStats = averageStats;
        }

        public bool OnWlAccStats2Passed(RtcConnectionS connectionS, WlAccStats currentStats, WlAccStats averageStats)
        {
            if (OnWlAccStats2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnWlAccStats2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<WlAccStats>(OnWlAccStats2_currentStats, currentStats) == false)
                return false;
            if (ParamsHelper.Compare<WlAccStats>(OnWlAccStats2_averageStats, averageStats) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnNetworkTypeChanged2_be_trigger = false;
        public RtcConnectionS OnNetworkTypeChanged2_connectionS;
        public NETWORK_TYPE OnNetworkTypeChanged2_type;
        public override void OnNetworkTypeChanged(RtcConnectionS connectionS, NETWORK_TYPE type)
        {
            OnNetworkTypeChanged2_be_trigger = true;
            OnNetworkTypeChanged2_connectionS = connectionS;
            OnNetworkTypeChanged2_type = type;
        }

        public bool OnNetworkTypeChanged2Passed(RtcConnectionS connectionS, NETWORK_TYPE type)
        {
            if (OnNetworkTypeChanged2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnNetworkTypeChanged2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<NETWORK_TYPE>(OnNetworkTypeChanged2_type, type) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnEncryptionError2_be_trigger = false;
        public RtcConnectionS OnEncryptionError2_connectionS;
        public ENCRYPTION_ERROR_TYPE OnEncryptionError2_errorType;
        public override void OnEncryptionError(RtcConnectionS connectionS, ENCRYPTION_ERROR_TYPE errorType)
        {
            OnEncryptionError2_be_trigger = true;
            OnEncryptionError2_connectionS = connectionS;
            OnEncryptionError2_errorType = errorType;
        }

        public bool OnEncryptionError2Passed(RtcConnectionS connectionS, ENCRYPTION_ERROR_TYPE errorType)
        {
            if (OnEncryptionError2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnEncryptionError2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<ENCRYPTION_ERROR_TYPE>(OnEncryptionError2_errorType, errorType) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnUploadLogResult2_be_trigger = false;
        public RtcConnectionS OnUploadLogResult2_connectionS;
        public string OnUploadLogResult2_requestId;
        public bool OnUploadLogResult2_success;
        public UPLOAD_ERROR_REASON OnUploadLogResult2_reason;
        public override void OnUploadLogResult(RtcConnectionS connectionS, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            OnUploadLogResult2_be_trigger = true;
            OnUploadLogResult2_connectionS = connectionS;
            OnUploadLogResult2_requestId = requestId;
            OnUploadLogResult2_success = success;
            OnUploadLogResult2_reason = reason;
        }

        public bool OnUploadLogResult2Passed(RtcConnectionS connectionS, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            if (OnUploadLogResult2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUploadLogResult2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUploadLogResult2_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUploadLogResult2_success, success) == false)
                return false;
            if (ParamsHelper.Compare<UPLOAD_ERROR_REASON>(OnUploadLogResult2_reason, reason) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnSnapshotTaken2_be_trigger = false;
        public RtcConnectionS OnSnapshotTaken2_connectionS;
        public string OnSnapshotTaken2_userAccount;
        public string OnSnapshotTaken2_filePath;
        public int OnSnapshotTaken2_width;
        public int OnSnapshotTaken2_height;
        public int OnSnapshotTaken2_errCode;
        public override void OnSnapshotTaken(RtcConnectionS connectionS, string userAccount, string filePath, int width, int height, int errCode)
        {
            OnSnapshotTaken2_be_trigger = true;
            OnSnapshotTaken2_connectionS = connectionS;
            OnSnapshotTaken2_userAccount = userAccount;
            OnSnapshotTaken2_filePath = filePath;
            OnSnapshotTaken2_width = width;
            OnSnapshotTaken2_height = height;
            OnSnapshotTaken2_errCode = errCode;
        }

        public bool OnSnapshotTaken2Passed(RtcConnectionS connectionS, string userAccount, string filePath, int width, int height, int errCode)
        {
            if (OnSnapshotTaken2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnSnapshotTaken2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnSnapshotTaken2_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnSnapshotTaken2_filePath, filePath) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken2_width, width) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken2_height, height) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSnapshotTaken2_errCode, errCode) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnVideoRenderingTracingResult2_be_trigger = false;
        public RtcConnectionS OnVideoRenderingTracingResult2_connectionS;
        public string OnVideoRenderingTracingResult2_userAccount;
        public MEDIA_TRACE_EVENT OnVideoRenderingTracingResult2_currentEvent;
        public VideoRenderingTracingInfo OnVideoRenderingTracingResult2_tracingInfo;
        public override void OnVideoRenderingTracingResult(RtcConnectionS connectionS, string userAccount, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            OnVideoRenderingTracingResult2_be_trigger = true;
            OnVideoRenderingTracingResult2_connectionS = connectionS;
            OnVideoRenderingTracingResult2_userAccount = userAccount;
            OnVideoRenderingTracingResult2_currentEvent = currentEvent;
            OnVideoRenderingTracingResult2_tracingInfo = tracingInfo;
        }

        public bool OnVideoRenderingTracingResult2Passed(RtcConnectionS connectionS, string userAccount, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            if (OnVideoRenderingTracingResult2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnVideoRenderingTracingResult2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnVideoRenderingTracingResult2_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<MEDIA_TRACE_EVENT>(OnVideoRenderingTracingResult2_currentEvent, currentEvent) == false)
                return false;
            if (ParamsHelper.Compare<VideoRenderingTracingInfo>(OnVideoRenderingTracingResult2_tracingInfo, tracingInfo) == false)
                return false;
            return true;
        }

        //////////////////

        public bool OnSetRtmFlagResult2_be_trigger = false;
        public RtcConnectionS OnSetRtmFlagResult2_connectionS;
        public int OnSetRtmFlagResult2_code;
        public override void OnSetRtmFlagResult(RtcConnectionS connectionS, int code)
        {
            OnSetRtmFlagResult2_be_trigger = true;
            OnSetRtmFlagResult2_connectionS = connectionS;
            OnSetRtmFlagResult2_code = code;
        }

        public bool OnSetRtmFlagResult2Passed(RtcConnectionS connectionS, int code)
        {
            if (OnSetRtmFlagResult2_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnSetRtmFlagResult2_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSetRtmFlagResult2_code, code) == false)
                return false;
            return true;
        }

        //////////////////
        #endregion terra IRtcEngineEventHandler
    }
}
