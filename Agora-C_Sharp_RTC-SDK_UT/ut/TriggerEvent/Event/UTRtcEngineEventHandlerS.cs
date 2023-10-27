using System;
using uid_t = System.UInt32;
namespace Agora.Rtc
{
    public class UTRtcEngineEventHandlerS : IRtcEngineEventHandlerS
    {

        #region terra IRtcEngineEventHandlerS

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
        public RtcConnectionS OnJoinChannelSuccess_connectionS;
        public int OnJoinChannelSuccess_elapsed;
        public override void OnJoinChannelSuccess(RtcConnectionS connectionS, int elapsed)
        {
            OnJoinChannelSuccess_be_trigger = true;
            OnJoinChannelSuccess_connectionS = connectionS;
            OnJoinChannelSuccess_elapsed = elapsed;
        }

        public bool OnJoinChannelSuccessPassed(RtcConnectionS connectionS, int elapsed)
        {
            if (OnJoinChannelSuccess_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnJoinChannelSuccess_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnJoinChannelSuccess_elapsed, elapsed) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnRejoinChannelSuccess_be_trigger = false;
        public RtcConnectionS OnRejoinChannelSuccess_connectionS;
        public int OnRejoinChannelSuccess_elapsed;
        public override void OnRejoinChannelSuccess(RtcConnectionS connectionS, int elapsed)
        {
            OnRejoinChannelSuccess_be_trigger = true;
            OnRejoinChannelSuccess_connectionS = connectionS;
            OnRejoinChannelSuccess_elapsed = elapsed;
        }

        public bool OnRejoinChannelSuccessPassed(RtcConnectionS connectionS, int elapsed)
        {
            if (OnRejoinChannelSuccess_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRejoinChannelSuccess_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnRejoinChannelSuccess_elapsed, elapsed) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnAudioVolumeIndication_be_trigger = false;
        public RtcConnectionS OnAudioVolumeIndication_connectionS;
        public AudioVolumeInfoS[] OnAudioVolumeIndication_speakersS;
        public uint OnAudioVolumeIndication_speakerNumber;
        public int OnAudioVolumeIndication_totalVolume;
        public override void OnAudioVolumeIndication(RtcConnectionS connectionS, AudioVolumeInfoS[] speakersS, uint speakerNumber, int totalVolume)
        {
            OnAudioVolumeIndication_be_trigger = true;
            OnAudioVolumeIndication_connectionS = connectionS;
            OnAudioVolumeIndication_speakersS = speakersS;
            OnAudioVolumeIndication_speakerNumber = speakerNumber;
            OnAudioVolumeIndication_totalVolume = totalVolume;
        }

        public bool OnAudioVolumeIndicationPassed(RtcConnectionS connectionS, AudioVolumeInfoS[] speakersS, uint speakerNumber, int totalVolume)
        {
            if (OnAudioVolumeIndication_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnAudioVolumeIndication_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<AudioVolumeInfoS[]>(OnAudioVolumeIndication_speakersS, speakersS) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnAudioVolumeIndication_speakerNumber, speakerNumber) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnAudioVolumeIndication_totalVolume, totalVolume) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnLeaveChannel_be_trigger = false;
        public RtcConnectionS OnLeaveChannel_connectionS;
        public RtcStats OnLeaveChannel_stats;
        public override void OnLeaveChannel(RtcConnectionS connectionS, RtcStats stats)
        {
            OnLeaveChannel_be_trigger = true;
            OnLeaveChannel_connectionS = connectionS;
            OnLeaveChannel_stats = stats;
        }

        public bool OnLeaveChannelPassed(RtcConnectionS connectionS, RtcStats stats)
        {
            if (OnLeaveChannel_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLeaveChannel_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<RtcStats>(OnLeaveChannel_stats, stats) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnRtcStats_be_trigger = false;
        public RtcConnectionS OnRtcStats_connectionS;
        public RtcStats OnRtcStats_stats;
        public override void OnRtcStats(RtcConnectionS connectionS, RtcStats stats)
        {
            OnRtcStats_be_trigger = true;
            OnRtcStats_connectionS = connectionS;
            OnRtcStats_stats = stats;
        }

        public bool OnRtcStatsPassed(RtcConnectionS connectionS, RtcStats stats)
        {
            if (OnRtcStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRtcStats_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<RtcStats>(OnRtcStats_stats, stats) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnNetworkQuality_be_trigger = false;
        public RtcConnectionS OnNetworkQuality_connectionS;
        public string OnNetworkQuality_remoteUserAccount;
        public int OnNetworkQuality_txQuality;
        public int OnNetworkQuality_rxQuality;
        public override void OnNetworkQuality(RtcConnectionS connectionS, string remoteUserAccount, int txQuality, int rxQuality)
        {
            OnNetworkQuality_be_trigger = true;
            OnNetworkQuality_connectionS = connectionS;
            OnNetworkQuality_remoteUserAccount = remoteUserAccount;
            OnNetworkQuality_txQuality = txQuality;
            OnNetworkQuality_rxQuality = rxQuality;
        }

        public bool OnNetworkQualityPassed(RtcConnectionS connectionS, string remoteUserAccount, int txQuality, int rxQuality)
        {
            if (OnNetworkQuality_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnNetworkQuality_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnNetworkQuality_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnNetworkQuality_txQuality, txQuality) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnNetworkQuality_rxQuality, rxQuality) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnIntraRequestReceived_be_trigger = false;
        public RtcConnectionS OnIntraRequestReceived_connectionS;
        public override void OnIntraRequestReceived(RtcConnectionS connectionS)
        {
            OnIntraRequestReceived_be_trigger = true;
            OnIntraRequestReceived_connectionS = connectionS;
        }

        public bool OnIntraRequestReceivedPassed(RtcConnectionS connectionS)
        {
            if (OnIntraRequestReceived_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnIntraRequestReceived_connectionS, connectionS) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnFirstLocalVideoFramePublished_be_trigger = false;
        public RtcConnectionS OnFirstLocalVideoFramePublished_connectionS;
        public int OnFirstLocalVideoFramePublished_elapsed;
        public override void OnFirstLocalVideoFramePublished(RtcConnectionS connectionS, int elapsed)
        {
            OnFirstLocalVideoFramePublished_be_trigger = true;
            OnFirstLocalVideoFramePublished_connectionS = connectionS;
            OnFirstLocalVideoFramePublished_elapsed = elapsed;
        }

        public bool OnFirstLocalVideoFramePublishedPassed(RtcConnectionS connectionS, int elapsed)
        {
            if (OnFirstLocalVideoFramePublished_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnFirstLocalVideoFramePublished_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalVideoFramePublished_elapsed, elapsed) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnFirstRemoteVideoDecoded_be_trigger = false;
        public RtcConnectionS OnFirstRemoteVideoDecoded_connectionS;
        public string OnFirstRemoteVideoDecoded_remoteUserAccount;
        public int OnFirstRemoteVideoDecoded_width;
        public int OnFirstRemoteVideoDecoded_height;
        public int OnFirstRemoteVideoDecoded_elapsed;
        public override void OnFirstRemoteVideoDecoded(RtcConnectionS connectionS, string remoteUserAccount, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoDecoded_be_trigger = true;
            OnFirstRemoteVideoDecoded_connectionS = connectionS;
            OnFirstRemoteVideoDecoded_remoteUserAccount = remoteUserAccount;
            OnFirstRemoteVideoDecoded_width = width;
            OnFirstRemoteVideoDecoded_height = height;
            OnFirstRemoteVideoDecoded_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoDecodedPassed(RtcConnectionS connectionS, string remoteUserAccount, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoDecoded_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnFirstRemoteVideoDecoded_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnFirstRemoteVideoDecoded_remoteUserAccount, remoteUserAccount) == false)
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
        public RtcConnectionS OnVideoSizeChanged_connectionS;
        public VIDEO_SOURCE_TYPE OnVideoSizeChanged_sourceType;
        public string OnVideoSizeChanged_userAccount;
        public int OnVideoSizeChanged_width;
        public int OnVideoSizeChanged_height;
        public int OnVideoSizeChanged_rotation;
        public override void OnVideoSizeChanged(RtcConnectionS connectionS, VIDEO_SOURCE_TYPE sourceType, string userAccount, int width, int height, int rotation)
        {
            OnVideoSizeChanged_be_trigger = true;
            OnVideoSizeChanged_connectionS = connectionS;
            OnVideoSizeChanged_sourceType = sourceType;
            OnVideoSizeChanged_userAccount = userAccount;
            OnVideoSizeChanged_width = width;
            OnVideoSizeChanged_height = height;
            OnVideoSizeChanged_rotation = rotation;
        }

        public bool OnVideoSizeChangedPassed(RtcConnectionS connectionS, VIDEO_SOURCE_TYPE sourceType, string userAccount, int width, int height, int rotation)
        {
            if (OnVideoSizeChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnVideoSizeChanged_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<VIDEO_SOURCE_TYPE>(OnVideoSizeChanged_sourceType, sourceType) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnVideoSizeChanged_userAccount, userAccount) == false)
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

        public bool OnRemoteVideoStateChanged_be_trigger = false;
        public RtcConnectionS OnRemoteVideoStateChanged_connectionS;
        public string OnRemoteVideoStateChanged_userAccount;
        public REMOTE_VIDEO_STATE OnRemoteVideoStateChanged_state;
        public REMOTE_VIDEO_STATE_REASON OnRemoteVideoStateChanged_reason;
        public int OnRemoteVideoStateChanged_elapsed;
        public override void OnRemoteVideoStateChanged(RtcConnectionS connectionS, string userAccount, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            OnRemoteVideoStateChanged_be_trigger = true;
            OnRemoteVideoStateChanged_connectionS = connectionS;
            OnRemoteVideoStateChanged_userAccount = userAccount;
            OnRemoteVideoStateChanged_state = state;
            OnRemoteVideoStateChanged_reason = reason;
            OnRemoteVideoStateChanged_elapsed = elapsed;
        }

        public bool OnRemoteVideoStateChangedPassed(RtcConnectionS connectionS, string userAccount, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteVideoStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRemoteVideoStateChanged_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnRemoteVideoStateChanged_userAccount, userAccount) == false)
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
        public RtcConnectionS OnFirstRemoteVideoFrame_connectionS;
        public string OnFirstRemoteVideoFrame_userAccount;
        public int OnFirstRemoteVideoFrame_width;
        public int OnFirstRemoteVideoFrame_height;
        public int OnFirstRemoteVideoFrame_elapsed;
        public override void OnFirstRemoteVideoFrame(RtcConnectionS connectionS, string userAccount, int width, int height, int elapsed)
        {
            OnFirstRemoteVideoFrame_be_trigger = true;
            OnFirstRemoteVideoFrame_connectionS = connectionS;
            OnFirstRemoteVideoFrame_userAccount = userAccount;
            OnFirstRemoteVideoFrame_width = width;
            OnFirstRemoteVideoFrame_height = height;
            OnFirstRemoteVideoFrame_elapsed = elapsed;
        }

        public bool OnFirstRemoteVideoFramePassed(RtcConnectionS connectionS, string userAccount, int width, int height, int elapsed)
        {
            if (OnFirstRemoteVideoFrame_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnFirstRemoteVideoFrame_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnFirstRemoteVideoFrame_userAccount, userAccount) == false)
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
        public RtcConnectionS OnUserJoined_connectionS;
        public string OnUserJoined_userAccount;
        public int OnUserJoined_elapsed;
        public override void OnUserJoined(RtcConnectionS connectionS, string userAccount, int elapsed)
        {
            OnUserJoined_be_trigger = true;
            OnUserJoined_connectionS = connectionS;
            OnUserJoined_userAccount = userAccount;
            OnUserJoined_elapsed = elapsed;
        }

        public bool OnUserJoinedPassed(RtcConnectionS connectionS, string userAccount, int elapsed)
        {
            if (OnUserJoined_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserJoined_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserJoined_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnUserJoined_elapsed, elapsed) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnUserOffline_be_trigger = false;
        public RtcConnectionS OnUserOffline_connectionS;
        public string OnUserOffline_userAccount;
        public USER_OFFLINE_REASON_TYPE OnUserOffline_reason;
        public override void OnUserOffline(RtcConnectionS connectionS, string userAccount, USER_OFFLINE_REASON_TYPE reason)
        {
            OnUserOffline_be_trigger = true;
            OnUserOffline_connectionS = connectionS;
            OnUserOffline_userAccount = userAccount;
            OnUserOffline_reason = reason;
        }

        public bool OnUserOfflinePassed(RtcConnectionS connectionS, string userAccount, USER_OFFLINE_REASON_TYPE reason)
        {
            if (OnUserOffline_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserOffline_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserOffline_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<USER_OFFLINE_REASON_TYPE>(OnUserOffline_reason, reason) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnUserMuteAudio_be_trigger = false;
        public RtcConnectionS OnUserMuteAudio_connectionS;
        public string OnUserMuteAudio_remoteUserAccount;
        public bool OnUserMuteAudio_muted;
        public override void OnUserMuteAudio(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            OnUserMuteAudio_be_trigger = true;
            OnUserMuteAudio_connectionS = connectionS;
            OnUserMuteAudio_remoteUserAccount = remoteUserAccount;
            OnUserMuteAudio_muted = muted;
        }

        public bool OnUserMuteAudioPassed(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            if (OnUserMuteAudio_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserMuteAudio_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserMuteAudio_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserMuteAudio_muted, muted) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnUserMuteVideo_be_trigger = false;
        public RtcConnectionS OnUserMuteVideo_connectionS;
        public string OnUserMuteVideo_remoteUserAccount;
        public bool OnUserMuteVideo_muted;
        public override void OnUserMuteVideo(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            OnUserMuteVideo_be_trigger = true;
            OnUserMuteVideo_connectionS = connectionS;
            OnUserMuteVideo_remoteUserAccount = remoteUserAccount;
            OnUserMuteVideo_muted = muted;
        }

        public bool OnUserMuteVideoPassed(RtcConnectionS connectionS, string remoteUserAccount, bool muted)
        {
            if (OnUserMuteVideo_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserMuteVideo_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserMuteVideo_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserMuteVideo_muted, muted) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnUserEnableVideo_be_trigger = false;
        public RtcConnectionS OnUserEnableVideo_connectionS;
        public string OnUserEnableVideo_remoteUserAccount;
        public bool OnUserEnableVideo_enabled;
        public override void OnUserEnableVideo(RtcConnectionS connectionS, string remoteUserAccount, bool enabled)
        {
            OnUserEnableVideo_be_trigger = true;
            OnUserEnableVideo_connectionS = connectionS;
            OnUserEnableVideo_remoteUserAccount = remoteUserAccount;
            OnUserEnableVideo_enabled = enabled;
        }

        public bool OnUserEnableVideoPassed(RtcConnectionS connectionS, string remoteUserAccount, bool enabled)
        {
            if (OnUserEnableVideo_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserEnableVideo_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserEnableVideo_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<bool>(OnUserEnableVideo_enabled, enabled) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnUserStateChanged_be_trigger = false;
        public RtcConnectionS OnUserStateChanged_connectionS;
        public string OnUserStateChanged_remoteUserAccount;
        public uint OnUserStateChanged_state;
        public override void OnUserStateChanged(RtcConnectionS connectionS, string remoteUserAccount, uint state)
        {
            OnUserStateChanged_be_trigger = true;
            OnUserStateChanged_connectionS = connectionS;
            OnUserStateChanged_remoteUserAccount = remoteUserAccount;
            OnUserStateChanged_state = state;
        }

        public bool OnUserStateChangedPassed(RtcConnectionS connectionS, string remoteUserAccount, uint state)
        {
            if (OnUserStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUserStateChanged_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnUserStateChanged_remoteUserAccount, remoteUserAccount) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnUserStateChanged_state, state) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnLocalAudioStats_be_trigger = false;
        public RtcConnectionS OnLocalAudioStats_connectionS;
        public LocalAudioStats OnLocalAudioStats_stats;
        public override void OnLocalAudioStats(RtcConnectionS connectionS, LocalAudioStats stats)
        {
            OnLocalAudioStats_be_trigger = true;
            OnLocalAudioStats_connectionS = connectionS;
            OnLocalAudioStats_stats = stats;
        }

        public bool OnLocalAudioStatsPassed(RtcConnectionS connectionS, LocalAudioStats stats)
        {
            if (OnLocalAudioStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLocalAudioStats_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LocalAudioStats>(OnLocalAudioStats_stats, stats) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnRemoteAudioStats_be_trigger = false;
        public RtcConnectionS OnRemoteAudioStats_connectionS;
        public RemoteAudioStatsS OnRemoteAudioStats_statsS;
        public override void OnRemoteAudioStats(RtcConnectionS connectionS, RemoteAudioStatsS statsS)
        {
            OnRemoteAudioStats_be_trigger = true;
            OnRemoteAudioStats_connectionS = connectionS;
            OnRemoteAudioStats_statsS = statsS;
        }

        public bool OnRemoteAudioStatsPassed(RtcConnectionS connectionS, RemoteAudioStatsS statsS)
        {
            if (OnRemoteAudioStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRemoteAudioStats_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<RemoteAudioStatsS>(OnRemoteAudioStats_statsS, statsS) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnLocalVideoStats_be_trigger = false;
        public RtcConnectionS OnLocalVideoStats_connectionS;
        public LocalVideoStatsS OnLocalVideoStats_statsS;
        public override void OnLocalVideoStats(RtcConnectionS connectionS, LocalVideoStatsS statsS)
        {
            OnLocalVideoStats_be_trigger = true;
            OnLocalVideoStats_connectionS = connectionS;
            OnLocalVideoStats_statsS = statsS;
        }

        public bool OnLocalVideoStatsPassed(RtcConnectionS connectionS, LocalVideoStatsS statsS)
        {
            if (OnLocalVideoStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLocalVideoStats_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LocalVideoStatsS>(OnLocalVideoStats_statsS, statsS) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnRemoteVideoStats_be_trigger = false;
        public RtcConnectionS OnRemoteVideoStats_connectionS;
        public RemoteVideoStatsS OnRemoteVideoStats_statsS;
        public override void OnRemoteVideoStats(RtcConnectionS connectionS, RemoteVideoStatsS statsS)
        {
            OnRemoteVideoStats_be_trigger = true;
            OnRemoteVideoStats_connectionS = connectionS;
            OnRemoteVideoStats_statsS = statsS;
        }

        public bool OnRemoteVideoStatsPassed(RtcConnectionS connectionS, RemoteVideoStatsS statsS)
        {
            if (OnRemoteVideoStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRemoteVideoStats_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<RemoteVideoStatsS>(OnRemoteVideoStats_statsS, statsS) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnConnectionLost_be_trigger = false;
        public RtcConnectionS OnConnectionLost_connectionS;
        public override void OnConnectionLost(RtcConnectionS connectionS)
        {
            OnConnectionLost_be_trigger = true;
            OnConnectionLost_connectionS = connectionS;
        }

        public bool OnConnectionLostPassed(RtcConnectionS connectionS)
        {
            if (OnConnectionLost_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnConnectionLost_connectionS, connectionS) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnConnectionBanned_be_trigger = false;
        public RtcConnectionS OnConnectionBanned_connectionS;
        public override void OnConnectionBanned(RtcConnectionS connectionS)
        {
            OnConnectionBanned_be_trigger = true;
            OnConnectionBanned_connectionS = connectionS;
        }

        public bool OnConnectionBannedPassed(RtcConnectionS connectionS)
        {
            if (OnConnectionBanned_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnConnectionBanned_connectionS, connectionS) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnStreamMessage_be_trigger = false;
        public RtcConnectionS OnStreamMessage_connectionS;
        public string OnStreamMessage_remoteUserAccount;
        public int OnStreamMessage_streamId;
        public byte[] OnStreamMessage_data;
        public ulong OnStreamMessage_length;
        public ulong OnStreamMessage_sentTs;
        public override void OnStreamMessage(RtcConnectionS connectionS, string remoteUserAccount, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            OnStreamMessage_be_trigger = true;
            OnStreamMessage_connectionS = connectionS;
            OnStreamMessage_remoteUserAccount = remoteUserAccount;
            OnStreamMessage_streamId = streamId;
            OnStreamMessage_data = data;
            OnStreamMessage_length = length;
            OnStreamMessage_sentTs = sentTs;
        }

        public bool OnStreamMessagePassed(RtcConnectionS connectionS, string remoteUserAccount, int streamId, byte[] data, ulong length, ulong sentTs)
        {
            if (OnStreamMessage_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnStreamMessage_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnStreamMessage_remoteUserAccount, remoteUserAccount) == false)
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
        public RtcConnectionS OnStreamMessageError_connectionS;
        public string OnStreamMessageError_remoteUserAccount;
        public int OnStreamMessageError_streamId;
        public int OnStreamMessageError_code;
        public int OnStreamMessageError_missed;
        public int OnStreamMessageError_cached;
        public override void OnStreamMessageError(RtcConnectionS connectionS, string remoteUserAccount, int streamId, int code, int missed, int cached)
        {
            OnStreamMessageError_be_trigger = true;
            OnStreamMessageError_connectionS = connectionS;
            OnStreamMessageError_remoteUserAccount = remoteUserAccount;
            OnStreamMessageError_streamId = streamId;
            OnStreamMessageError_code = code;
            OnStreamMessageError_missed = missed;
            OnStreamMessageError_cached = cached;
        }

        public bool OnStreamMessageErrorPassed(RtcConnectionS connectionS, string remoteUserAccount, int streamId, int code, int missed, int cached)
        {
            if (OnStreamMessageError_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnStreamMessageError_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnStreamMessageError_remoteUserAccount, remoteUserAccount) == false)
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
        public RtcConnectionS OnRequestToken_connectionS;
        public override void OnRequestToken(RtcConnectionS connectionS)
        {
            OnRequestToken_be_trigger = true;
            OnRequestToken_connectionS = connectionS;
        }

        public bool OnRequestTokenPassed(RtcConnectionS connectionS)
        {
            if (OnRequestToken_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRequestToken_connectionS, connectionS) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnLicenseValidationFailure_be_trigger = false;
        public RtcConnectionS OnLicenseValidationFailure_connectionS;
        public LICENSE_ERROR_TYPE OnLicenseValidationFailure_reason;
        public override void OnLicenseValidationFailure(RtcConnectionS connectionS, LICENSE_ERROR_TYPE reason)
        {
            OnLicenseValidationFailure_be_trigger = true;
            OnLicenseValidationFailure_connectionS = connectionS;
            OnLicenseValidationFailure_reason = reason;
        }

        public bool OnLicenseValidationFailurePassed(RtcConnectionS connectionS, LICENSE_ERROR_TYPE reason)
        {
            if (OnLicenseValidationFailure_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLicenseValidationFailure_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LICENSE_ERROR_TYPE>(OnLicenseValidationFailure_reason, reason) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnTokenPrivilegeWillExpire_be_trigger = false;
        public RtcConnectionS OnTokenPrivilegeWillExpire_connectionS;
        public string OnTokenPrivilegeWillExpire_token;
        public override void OnTokenPrivilegeWillExpire(RtcConnectionS connectionS, string token)
        {
            OnTokenPrivilegeWillExpire_be_trigger = true;
            OnTokenPrivilegeWillExpire_connectionS = connectionS;
            OnTokenPrivilegeWillExpire_token = token;
        }

        public bool OnTokenPrivilegeWillExpirePassed(RtcConnectionS connectionS, string token)
        {
            if (OnTokenPrivilegeWillExpire_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnTokenPrivilegeWillExpire_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnTokenPrivilegeWillExpire_token, token) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnFirstLocalAudioFramePublished_be_trigger = false;
        public RtcConnectionS OnFirstLocalAudioFramePublished_connectionS;
        public int OnFirstLocalAudioFramePublished_elapsed;
        public override void OnFirstLocalAudioFramePublished(RtcConnectionS connectionS, int elapsed)
        {
            OnFirstLocalAudioFramePublished_be_trigger = true;
            OnFirstLocalAudioFramePublished_connectionS = connectionS;
            OnFirstLocalAudioFramePublished_elapsed = elapsed;
        }

        public bool OnFirstLocalAudioFramePublishedPassed(RtcConnectionS connectionS, int elapsed)
        {
            if (OnFirstLocalAudioFramePublished_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnFirstLocalAudioFramePublished_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnFirstLocalAudioFramePublished_elapsed, elapsed) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnLocalAudioStateChanged_be_trigger = false;
        public RtcConnectionS OnLocalAudioStateChanged_connectionS;
        public LOCAL_AUDIO_STREAM_STATE OnLocalAudioStateChanged_state;
        public LOCAL_AUDIO_STREAM_ERROR OnLocalAudioStateChanged_error;
        public override void OnLocalAudioStateChanged(RtcConnectionS connectionS, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            OnLocalAudioStateChanged_be_trigger = true;
            OnLocalAudioStateChanged_connectionS = connectionS;
            OnLocalAudioStateChanged_state = state;
            OnLocalAudioStateChanged_error = error;
        }

        public bool OnLocalAudioStateChangedPassed(RtcConnectionS connectionS, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
            if (OnLocalAudioStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnLocalAudioStateChanged_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_AUDIO_STREAM_STATE>(OnLocalAudioStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<LOCAL_AUDIO_STREAM_ERROR>(OnLocalAudioStateChanged_error, error) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnRemoteAudioStateChanged_be_trigger = false;
        public RtcConnectionS OnRemoteAudioStateChanged_connectionS;
        public string OnRemoteAudioStateChanged_remoteUserAccount;
        public REMOTE_AUDIO_STATE OnRemoteAudioStateChanged_state;
        public REMOTE_AUDIO_STATE_REASON OnRemoteAudioStateChanged_reason;
        public int OnRemoteAudioStateChanged_elapsed;
        public override void OnRemoteAudioStateChanged(RtcConnectionS connectionS, string remoteUserAccount, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            OnRemoteAudioStateChanged_be_trigger = true;
            OnRemoteAudioStateChanged_connectionS = connectionS;
            OnRemoteAudioStateChanged_remoteUserAccount = remoteUserAccount;
            OnRemoteAudioStateChanged_state = state;
            OnRemoteAudioStateChanged_reason = reason;
            OnRemoteAudioStateChanged_elapsed = elapsed;
        }

        public bool OnRemoteAudioStateChangedPassed(RtcConnectionS connectionS, string remoteUserAccount, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
            if (OnRemoteAudioStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnRemoteAudioStateChanged_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnRemoteAudioStateChanged_remoteUserAccount, remoteUserAccount) == false)
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
        public RtcConnectionS OnActiveSpeaker_connectionS;
        public string OnActiveSpeaker_userAccount;
        public override void OnActiveSpeaker(RtcConnectionS connectionS, string userAccount)
        {
            OnActiveSpeaker_be_trigger = true;
            OnActiveSpeaker_connectionS = connectionS;
            OnActiveSpeaker_userAccount = userAccount;
        }

        public bool OnActiveSpeakerPassed(RtcConnectionS connectionS, string userAccount)
        {
            if (OnActiveSpeaker_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnActiveSpeaker_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnActiveSpeaker_userAccount, userAccount) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnClientRoleChanged_be_trigger = false;
        public RtcConnectionS OnClientRoleChanged_connectionS;
        public CLIENT_ROLE_TYPE OnClientRoleChanged_oldRole;
        public CLIENT_ROLE_TYPE OnClientRoleChanged_newRole;
        public ClientRoleOptions OnClientRoleChanged_newRoleOptions;
        public override void OnClientRoleChanged(RtcConnectionS connectionS, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            OnClientRoleChanged_be_trigger = true;
            OnClientRoleChanged_connectionS = connectionS;
            OnClientRoleChanged_oldRole = oldRole;
            OnClientRoleChanged_newRole = newRole;
            OnClientRoleChanged_newRoleOptions = newRoleOptions;
        }

        public bool OnClientRoleChangedPassed(RtcConnectionS connectionS, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
            if (OnClientRoleChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnClientRoleChanged_connectionS, connectionS) == false)
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
        public RtcConnectionS OnClientRoleChangeFailed_connectionS;
        public CLIENT_ROLE_CHANGE_FAILED_REASON OnClientRoleChangeFailed_reason;
        public CLIENT_ROLE_TYPE OnClientRoleChangeFailed_currentRole;
        public override void OnClientRoleChangeFailed(RtcConnectionS connectionS, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            OnClientRoleChangeFailed_be_trigger = true;
            OnClientRoleChangeFailed_connectionS = connectionS;
            OnClientRoleChangeFailed_reason = reason;
            OnClientRoleChangeFailed_currentRole = currentRole;
        }

        public bool OnClientRoleChangeFailedPassed(RtcConnectionS connectionS, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
            if (OnClientRoleChangeFailed_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnClientRoleChangeFailed_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_CHANGE_FAILED_REASON>(OnClientRoleChangeFailed_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<CLIENT_ROLE_TYPE>(OnClientRoleChangeFailed_currentRole, currentRole) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnConnectionStateChanged_be_trigger = false;
        public RtcConnectionS OnConnectionStateChanged_connectionS;
        public CONNECTION_STATE_TYPE OnConnectionStateChanged_state;
        public CONNECTION_CHANGED_REASON_TYPE OnConnectionStateChanged_reason;
        public override void OnConnectionStateChanged(RtcConnectionS connectionS, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            OnConnectionStateChanged_be_trigger = true;
            OnConnectionStateChanged_connectionS = connectionS;
            OnConnectionStateChanged_state = state;
            OnConnectionStateChanged_reason = reason;
        }

        public bool OnConnectionStateChangedPassed(RtcConnectionS connectionS, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
            if (OnConnectionStateChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnConnectionStateChanged_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<CONNECTION_STATE_TYPE>(OnConnectionStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<CONNECTION_CHANGED_REASON_TYPE>(OnConnectionStateChanged_reason, reason) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnWlAccMessage_be_trigger = false;
        public RtcConnectionS OnWlAccMessage_connectionS;
        public WLACC_MESSAGE_REASON OnWlAccMessage_reason;
        public WLACC_SUGGEST_ACTION OnWlAccMessage_action;
        public string OnWlAccMessage_wlAccMsg;
        public override void OnWlAccMessage(RtcConnectionS connectionS, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            OnWlAccMessage_be_trigger = true;
            OnWlAccMessage_connectionS = connectionS;
            OnWlAccMessage_reason = reason;
            OnWlAccMessage_action = action;
            OnWlAccMessage_wlAccMsg = wlAccMsg;
        }

        public bool OnWlAccMessagePassed(RtcConnectionS connectionS, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
            if (OnWlAccMessage_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnWlAccMessage_connectionS, connectionS) == false)
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
        public RtcConnectionS OnWlAccStats_connectionS;
        public WlAccStats OnWlAccStats_currentStats;
        public WlAccStats OnWlAccStats_averageStats;
        public override void OnWlAccStats(RtcConnectionS connectionS, WlAccStats currentStats, WlAccStats averageStats)
        {
            OnWlAccStats_be_trigger = true;
            OnWlAccStats_connectionS = connectionS;
            OnWlAccStats_currentStats = currentStats;
            OnWlAccStats_averageStats = averageStats;
        }

        public bool OnWlAccStatsPassed(RtcConnectionS connectionS, WlAccStats currentStats, WlAccStats averageStats)
        {
            if (OnWlAccStats_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnWlAccStats_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<WlAccStats>(OnWlAccStats_currentStats, currentStats) == false)
                return false;
            if (ParamsHelper.Compare<WlAccStats>(OnWlAccStats_averageStats, averageStats) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnNetworkTypeChanged_be_trigger = false;
        public RtcConnectionS OnNetworkTypeChanged_connectionS;
        public NETWORK_TYPE OnNetworkTypeChanged_type;
        public override void OnNetworkTypeChanged(RtcConnectionS connectionS, NETWORK_TYPE type)
        {
            OnNetworkTypeChanged_be_trigger = true;
            OnNetworkTypeChanged_connectionS = connectionS;
            OnNetworkTypeChanged_type = type;
        }

        public bool OnNetworkTypeChangedPassed(RtcConnectionS connectionS, NETWORK_TYPE type)
        {
            if (OnNetworkTypeChanged_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnNetworkTypeChanged_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<NETWORK_TYPE>(OnNetworkTypeChanged_type, type) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnEncryptionError_be_trigger = false;
        public RtcConnectionS OnEncryptionError_connectionS;
        public ENCRYPTION_ERROR_TYPE OnEncryptionError_errorType;
        public override void OnEncryptionError(RtcConnectionS connectionS, ENCRYPTION_ERROR_TYPE errorType)
        {
            OnEncryptionError_be_trigger = true;
            OnEncryptionError_connectionS = connectionS;
            OnEncryptionError_errorType = errorType;
        }

        public bool OnEncryptionErrorPassed(RtcConnectionS connectionS, ENCRYPTION_ERROR_TYPE errorType)
        {
            if (OnEncryptionError_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnEncryptionError_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<ENCRYPTION_ERROR_TYPE>(OnEncryptionError_errorType, errorType) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnUploadLogResult_be_trigger = false;
        public RtcConnectionS OnUploadLogResult_connectionS;
        public string OnUploadLogResult_requestId;
        public bool OnUploadLogResult_success;
        public UPLOAD_ERROR_REASON OnUploadLogResult_reason;
        public override void OnUploadLogResult(RtcConnectionS connectionS, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            OnUploadLogResult_be_trigger = true;
            OnUploadLogResult_connectionS = connectionS;
            OnUploadLogResult_requestId = requestId;
            OnUploadLogResult_success = success;
            OnUploadLogResult_reason = reason;
        }

        public bool OnUploadLogResultPassed(RtcConnectionS connectionS, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
            if (OnUploadLogResult_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnUploadLogResult_connectionS, connectionS) == false)
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

        public bool OnSnapshotTaken_be_trigger = false;
        public RtcConnectionS OnSnapshotTaken_connectionS;
        public string OnSnapshotTaken_userAccount;
        public string OnSnapshotTaken_filePath;
        public int OnSnapshotTaken_width;
        public int OnSnapshotTaken_height;
        public int OnSnapshotTaken_errCode;
        public override void OnSnapshotTaken(RtcConnectionS connectionS, string userAccount, string filePath, int width, int height, int errCode)
        {
            OnSnapshotTaken_be_trigger = true;
            OnSnapshotTaken_connectionS = connectionS;
            OnSnapshotTaken_userAccount = userAccount;
            OnSnapshotTaken_filePath = filePath;
            OnSnapshotTaken_width = width;
            OnSnapshotTaken_height = height;
            OnSnapshotTaken_errCode = errCode;
        }

        public bool OnSnapshotTakenPassed(RtcConnectionS connectionS, string userAccount, string filePath, int width, int height, int errCode)
        {
            if (OnSnapshotTaken_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnSnapshotTaken_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnSnapshotTaken_userAccount, userAccount) == false)
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
        public RtcConnectionS OnVideoRenderingTracingResult_connectionS;
        public string OnVideoRenderingTracingResult_userAccount;
        public MEDIA_TRACE_EVENT OnVideoRenderingTracingResult_currentEvent;
        public VideoRenderingTracingInfo OnVideoRenderingTracingResult_tracingInfo;
        public override void OnVideoRenderingTracingResult(RtcConnectionS connectionS, string userAccount, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            OnVideoRenderingTracingResult_be_trigger = true;
            OnVideoRenderingTracingResult_connectionS = connectionS;
            OnVideoRenderingTracingResult_userAccount = userAccount;
            OnVideoRenderingTracingResult_currentEvent = currentEvent;
            OnVideoRenderingTracingResult_tracingInfo = tracingInfo;
        }

        public bool OnVideoRenderingTracingResultPassed(RtcConnectionS connectionS, string userAccount, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
            if (OnVideoRenderingTracingResult_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnVideoRenderingTracingResult_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnVideoRenderingTracingResult_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<MEDIA_TRACE_EVENT>(OnVideoRenderingTracingResult_currentEvent, currentEvent) == false)
                return false;
            if (ParamsHelper.Compare<VideoRenderingTracingInfo>(OnVideoRenderingTracingResult_tracingInfo, tracingInfo) == false)
                return false;
            return true;
        }
        //////////////////

        public bool OnSetRtmFlagResult_be_trigger = false;
        public RtcConnectionS OnSetRtmFlagResult_connectionS;
        public int OnSetRtmFlagResult_code;
        public override void OnSetRtmFlagResult(RtcConnectionS connectionS, int code)
        {
            OnSetRtmFlagResult_be_trigger = true;
            OnSetRtmFlagResult_connectionS = connectionS;
            OnSetRtmFlagResult_code = code;
        }

        public bool OnSetRtmFlagResultPassed(RtcConnectionS connectionS, int code)
        {
            if (OnSetRtmFlagResult_be_trigger == false)
                return false;
            if (ParamsHelper.Compare<RtcConnectionS>(OnSetRtmFlagResult_connectionS, connectionS) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSetRtmFlagResult_code, code) == false)
                return false;
            return true;
        }
        //////////////////
        #endregion terra IRtcEngineEventHandlerS

        #region terra IDirectCdnStreamingEventHandler

        public bool OnDirectCdnStreamingStateChanged_be_trigger = false;
        public DIRECT_CDN_STREAMING_STATE OnDirectCdnStreamingStateChanged_state;
        public DIRECT_CDN_STREAMING_ERROR OnDirectCdnStreamingStateChanged_error;
        public string OnDirectCdnStreamingStateChanged_message;

        public override void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
        {
            OnDirectCdnStreamingStateChanged_be_trigger = true;
            OnDirectCdnStreamingStateChanged_state = state;
            OnDirectCdnStreamingStateChanged_error = error;
            OnDirectCdnStreamingStateChanged_message = message;

        }

        public bool OnDirectCdnStreamingStateChangedPassed(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
        {

            if (OnDirectCdnStreamingStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<DIRECT_CDN_STREAMING_STATE>(OnDirectCdnStreamingStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<DIRECT_CDN_STREAMING_ERROR>(OnDirectCdnStreamingStateChanged_error, error) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnDirectCdnStreamingStateChanged_message, message) == false)
                return false;

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

            if (ParamsHelper.Compare<DirectCdnStreamingStats>(OnDirectCdnStreamingStats_stats, stats) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IDirectCdnStreamingEventHandler
    }
}
