#define AGORA_STRING_UID
#define AGORA_NUMBER_UID

using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
using UnityEngine;
#endif

namespace Agora.Rtc
{
    internal static class RtcEngineEventHandlerNative
    {
        private static IRtcEngineEventHandlerBase rtcEngineEventHandler = null;

        internal static void SetEventHandler(IRtcEngineEventHandlerBase handler)
        {
            rtcEngineEventHandler = handler;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {

            if (rtcEngineEventHandler == null)
                return;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null)
                return;
#endif

            IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

            string @event = eventParam.@event;
            string data = eventParam.data;

            LitJson.JsonData jsonData = null;
            if (data != null)
            {
                jsonData = AgoraJson.ToObject(data);
            }

            if (@event.StartsWith("IRtcEngineEventHandlerBase"))
            {
                OnRtcEngineBaseEvent(@event, jsonData);
            }
#if AGORA_NUMBER_UID
            else if (@event.StartsWith("IRtcEngineEventHandler") || @event.StartsWith("IRtcEngineEventHandlerEx"))
            {
                OnRtcEngineEvent(@event, jsonData);
            }
#endif
#if AGORA_STRING_UID
            else if (@event.StartsWith("IRtcEngineEventHandlerS") || @event.StartsWith("IRtcEngineEventHandlerExS"))
            {
                OnRtcEngineSEvent(@event, jsonData);
            }
#endif
        }

        private static void OnRtcEngineBaseEvent(string @event, LitJson.JsonData jsonData)
        {
            switch (@event)
            {
                #region terra IRtcEngineEventHandlerBase

                case "RtcEngineEventHandlerBase_onError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnError(
                        (int)AgoraJson.GetData<int>(jsonData, "err"),
                        (string)AgoraJson.GetData<string>(jsonData, "msg")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onLastmileProbeResult":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLastmileProbeResult(
                        AgoraJson.JsonToStruct<LastmileProbeResult>(jsonData, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onAudioDeviceStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioDeviceStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "deviceId"),
                        (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onAudioMixingPositionChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioMixingPositionChanged(
                        (long)AgoraJson.GetData<long>(jsonData, "position")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onAudioEffectFinished":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioEffectFinished(
                        (int)AgoraJson.GetData<int>(jsonData, "soundId")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onVideoDeviceStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoDeviceStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "deviceId"),
                        (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceType"),
                        (MEDIA_DEVICE_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onUplinkNetworkInfoUpdated":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnUplinkNetworkInfoUpdated(
                        AgoraJson.JsonToStruct<UplinkNetworkInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onDownlinkNetworkInfoUpdated":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnDownlinkNetworkInfoUpdated(
                        AgoraJson.JsonToStruct<DownlinkNetworkInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onLastmileQuality":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLastmileQuality(
                        (int)AgoraJson.GetData<int>(jsonData, "quality")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onFirstLocalVideoFrame":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFirstLocalVideoFrame(
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "source"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onLocalVideoStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalVideoStateChanged(
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "source"),
                        (LOCAL_VIDEO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_VIDEO_STREAM_ERROR)AgoraJson.GetData<int>(jsonData, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onCameraFocusAreaChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnCameraFocusAreaChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "x"),
                        (int)AgoraJson.GetData<int>(jsonData, "y"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onCameraExposureAreaChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnCameraExposureAreaChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "x"),
                        (int)AgoraJson.GetData<int>(jsonData, "y"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onFacePositionChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnFacePositionChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "imageWidth"),
                        (int)AgoraJson.GetData<int>(jsonData, "imageHeight"),
                        AgoraJson.JsonToStructArray<Rectangle>(jsonData, "vecRectangle"),
                        AgoraJson.JsonToStructArray<int>(jsonData, "vecDistance"),
                        (int)AgoraJson.GetData<int>(jsonData, "numFaces")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onAudioMixingStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioMixingStateChanged(
                        (AUDIO_MIXING_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "state"),
                        (AUDIO_MIXING_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onRhythmPlayerStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRhythmPlayerStateChanged(
                        (RHYTHM_PLAYER_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "state"),
                        (RHYTHM_PLAYER_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onContentInspectResult":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnContentInspectResult(
                        (CONTENT_INSPECT_RESULT)AgoraJson.GetData<int>(jsonData, "result")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onAudioDeviceVolumeChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioDeviceVolumeChanged(
                        (MEDIA_DEVICE_TYPE)AgoraJson.GetData<int>(jsonData, "deviceType"),
                        (int)AgoraJson.GetData<int>(jsonData, "volume"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onRtmpStreamingStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRtmpStreamingStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "url"),
                        (RTMP_STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (RTMP_STREAM_PUBLISH_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "errCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onRtmpStreamingEvent":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnRtmpStreamingEvent(
                        (string)AgoraJson.GetData<string>(jsonData, "url"),
                        (RTMP_STREAMING_EVENT)AgoraJson.GetData<int>(jsonData, "eventCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onTranscodingUpdated":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnTranscodingUpdated(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onAudioRoutingChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioRoutingChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "routing")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onChannelMediaRelayStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnChannelMediaRelayStateChanged(
                        (int)AgoraJson.GetData<int>(jsonData, "state"),
                        (int)AgoraJson.GetData<int>(jsonData, "code")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onLocalPublishFallbackToAudioOnly":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnLocalPublishFallbackToAudioOnly(
                        (bool)AgoraJson.GetData<bool>(jsonData, "isFallbackOrRecover")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onPermissionError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnPermissionError(
                        (PERMISSION_TYPE)AgoraJson.GetData<int>(jsonData, "permissionType")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onAudioPublishStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnAudioPublishStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onVideoPublishStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnVideoPublishStateChanged(
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "source"),
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_PUBLISH_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onExtensionEvent":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnExtensionEvent(
                        (string)AgoraJson.GetData<string>(jsonData, "provider"),
                        (string)AgoraJson.GetData<string>(jsonData, "extension"),
                        (string)AgoraJson.GetData<string>(jsonData, "key"),
                        (string)AgoraJson.GetData<string>(jsonData, "value")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onExtensionStarted":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnExtensionStarted(
                        (string)AgoraJson.GetData<string>(jsonData, "provider"),
                        (string)AgoraJson.GetData<string>(jsonData, "extension")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onExtensionStopped":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnExtensionStopped(
                        (string)AgoraJson.GetData<string>(jsonData, "provider"),
                        (string)AgoraJson.GetData<string>(jsonData, "extension")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerBase_onExtensionError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnExtensionError(
                        (string)AgoraJson.GetData<string>(jsonData, "provider"),
                        (string)AgoraJson.GetData<string>(jsonData, "extension"),
                        (int)AgoraJson.GetData<int>(jsonData, "error"),
                        (string)AgoraJson.GetData<string>(jsonData, "message")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }
                    #endregion terra IRtcEngineEventHandlerBase
            }
        }

#if AGORA_NUMBER_UID
        private static void OnRtcEngineEvent(string @event, LitJson.JsonData jsonData)
        {
            switch (@event)
            {
                case "RtcEngineEventHandlerEx_onStreamMessage":
                    {
                        var byteLength = (uint)AgoraJson.GetData<uint>(jsonData, "length");
                        var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "data");
                        var byteData = new byte[byteLength];
                        if (byteLength != 0)
                        {
                            Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                        CallbackObject._CallbackQueue.EnQueue(() =>
                                                              {
#endif
                        if (rtcEngineEventHandler == null)
                            return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnStreamMessage(
                     AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                     (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                     (int)AgoraJson.GetData<int>(jsonData, "streamId"),
                     byteData,
                     byteLength,
                     (UInt64)AgoraJson.GetData<UInt64>(jsonData, "sentTs"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                              });
#endif
                        break;
                    }
                #region terra IRtcEngineEventHandler

                case "RtcEngineEventHandler_onProxyConnected":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnProxyConnected(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (PROXY_TYPE)AgoraJson.GetData<int>(jsonData, "proxyType"),
                        (string)AgoraJson.GetData<string>(jsonData, "localProxyIp"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onAudioMixingFinished":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnAudioMixingFinished(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onCameraReady":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnCameraReady(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onVideoStopped":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnVideoStopped(

                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onRemoteSubscribeFallbackToAudioOnly":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRemoteSubscribeFallbackToAudioOnly(
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "isFallbackOrRecover")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onLocalUserRegistered":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnLocalUserRegistered(
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onUserInfoUpdated":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserInfoUpdated(
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        AgoraJson.JsonToStruct<UserInfo>(jsonData, "info")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onAudioSubscribeStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnAudioSubscribeStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onVideoSubscribeStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnVideoSubscribeStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandler_onLocalVideoTranscoderError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnLocalVideoTranscoderError(
                        AgoraJson.JsonToStruct<TranscodingVideoStream>(jsonData, "stream"),
                        (VIDEO_TRANSCODER_ERROR)AgoraJson.GetData<int>(jsonData, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onJoinChannelSuccess":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnJoinChannelSuccess(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRejoinChannelSuccess":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRejoinChannelSuccess(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onAudioQuality":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnAudioQuality(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "quality"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "delay"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "lost")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onAudioVolumeIndication":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnAudioVolumeIndication(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStructArray<AudioVolumeInfo>(jsonData, "speakers"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "speakerNumber"),
                        (int)AgoraJson.GetData<int>(jsonData, "totalVolume")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onLeaveChannel":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnLeaveChannel(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRtcStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRtcStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onNetworkQuality":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnNetworkQuality(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "txQuality"),
                        (int)AgoraJson.GetData<int>(jsonData, "rxQuality")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onIntraRequestReceived":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnIntraRequestReceived(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onFirstLocalVideoFramePublished":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnFirstLocalVideoFramePublished(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onFirstRemoteVideoDecoded":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnFirstRemoteVideoDecoded(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onVideoSizeChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnVideoSizeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "sourceType"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "rotation")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onLocalVideoStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnLocalVideoStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (LOCAL_VIDEO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_VIDEO_STREAM_ERROR)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRemoteVideoStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRemoteVideoStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (REMOTE_VIDEO_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (REMOTE_VIDEO_STATE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onFirstRemoteVideoFrame":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnFirstRemoteVideoFrame(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUserJoined":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserJoined(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUserOffline":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserOffline(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (USER_OFFLINE_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUserMuteAudio":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserMuteAudio(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUserMuteVideo":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserMuteVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUserEnableVideo":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserEnableVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "enabled")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUserEnableLocalVideo":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserEnableLocalVideo(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "enabled")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUserStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "state")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onLocalAudioStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnLocalAudioStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<LocalAudioStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRemoteAudioStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRemoteAudioStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RemoteAudioStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onLocalVideoStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnLocalVideoStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<LocalVideoStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRemoteVideoStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRemoteVideoStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<RemoteVideoStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onConnectionLost":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnConnectionLost(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onConnectionInterrupted":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnConnectionInterrupted(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onConnectionBanned":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnConnectionBanned(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onStreamMessageError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnStreamMessageError(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (int)AgoraJson.GetData<int>(jsonData, "streamId"),
                        (int)AgoraJson.GetData<int>(jsonData, "code"),
                        (int)AgoraJson.GetData<int>(jsonData, "missed"),
                        (int)AgoraJson.GetData<int>(jsonData, "cached")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRequestToken":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRequestToken(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onLicenseValidationFailure":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnLicenseValidationFailure(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (LICENSE_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onTokenPrivilegeWillExpire":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnTokenPrivilegeWillExpire(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (string)AgoraJson.GetData<string>(jsonData, "token")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onFirstLocalAudioFramePublished":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnFirstLocalAudioFramePublished(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onFirstRemoteAudioFrame":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnFirstRemoteAudioFrame(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "userId"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onFirstRemoteAudioDecoded":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnFirstRemoteAudioDecoded(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onLocalAudioStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnLocalAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (LOCAL_AUDIO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_AUDIO_STREAM_ERROR)AgoraJson.GetData<int>(jsonData, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRemoteAudioStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRemoteAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (REMOTE_AUDIO_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (REMOTE_AUDIO_STATE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onActiveSpeaker":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnActiveSpeaker(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onClientRoleChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnClientRoleChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "oldRole"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "newRole"),
                        AgoraJson.JsonToStruct<ClientRoleOptions>(jsonData, "newRoleOptions")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onClientRoleChangeFailed":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnClientRoleChangeFailed(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CLIENT_ROLE_CHANGE_FAILED_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "currentRole")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRemoteAudioTransportStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRemoteAudioTransportStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "delay"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "lost"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "rxKBitRate")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onRemoteVideoTransportStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnRemoteVideoTransportStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "delay"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "lost"),
                        (ushort)AgoraJson.GetData<ushort>(jsonData, "rxKBitRate")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onConnectionStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnConnectionStateChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onWlAccMessage":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnWlAccMessage(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (WLACC_MESSAGE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (WLACC_SUGGEST_ACTION)AgoraJson.GetData<int>(jsonData, "action"),
                        (string)AgoraJson.GetData<string>(jsonData, "wlAccMsg")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onWlAccStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnWlAccStats(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        AgoraJson.JsonToStruct<WlAccStats>(jsonData, "currentStats"),
                        AgoraJson.JsonToStruct<WlAccStats>(jsonData, "averageStats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onNetworkTypeChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnNetworkTypeChanged(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (NETWORK_TYPE)AgoraJson.GetData<int>(jsonData, "type")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onEncryptionError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnEncryptionError(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (ENCRYPTION_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "errorType")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUploadLogResult":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUploadLogResult(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "success"),
                        (UPLOAD_ERROR_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onUserAccountUpdated":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnUserAccountUpdated(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "remoteUid"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onSnapshotTaken":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnSnapshotTaken(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (string)AgoraJson.GetData<string>(jsonData, "filePath"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "errCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onVideoRenderingTracingResult":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnVideoRenderingTracingResult(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (MEDIA_TRACE_EVENT)AgoraJson.GetData<int>(jsonData, "currentEvent"),
                        AgoraJson.JsonToStruct<VideoRenderingTracingInfo>(jsonData, "tracingInfo")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onSetRtmFlagResult":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnSetRtmFlagResult(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (int)AgoraJson.GetData<int>(jsonData, "code")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerEx_onVideoLayoutInfo":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandler)rtcEngineEventHandler).OnVideoLayoutInfo(
                        AgoraJson.JsonToStruct<RtcConnection>(jsonData, "connection"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "uid"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "layoutNumber"),
                        AgoraJson.JsonToStructArray<VideoLayout>(jsonData, "layoutlist")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }
                    #endregion terra IRtcEngineEventHandler
            }
        }
#endif

#if AGORA_STRING_UID
        private static void OnRtcEngineSEvent(string @event, LitJson.JsonData jsonData)
        {
            switch (@event)
            {

                case "RtcEngineEventHandlerExS_onStreamMessage":
                    {
                        var byteLength = (uint)AgoraJson.GetData<uint>(jsonData, "length");
                        var bufferPtr = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(jsonData, "data");
                        var byteData = new byte[byteLength];
                        if (byteLength != 0)
                        {
                            Marshal.Copy(bufferPtr, byteData, 0, (int)byteLength);
                        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                        CallbackObject._CallbackQueue.EnQueue(() =>
                                                              {
#endif
                        if (rtcEngineEventHandler == null)
                            return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnStreamMessage(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (int)AgoraJson.GetData<int>(jsonData, "streamId"),
                        byteData,
                        byteLength,
                        (UInt64)AgoraJson.GetData<UInt64>(jsonData, "sentTs"));
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
                                                              });
#endif
                        break;
                    }

                #region terra IRtcEngineEventHandlerS

                case "RtcEngineEventHandlerS_onProxyConnected":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnProxyConnected(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (PROXY_TYPE)AgoraJson.GetData<int>(jsonData, "proxyType"),
                        (string)AgoraJson.GetData<string>(jsonData, "localProxyIp"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerS_onRemoteSubscribeFallbackToAudioOnly":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnRemoteSubscribeFallbackToAudioOnly(
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "isFallbackOrRecover")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerS_onAudioSubscribeStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnAudioSubscribeStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerS_onVideoSubscribeStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnVideoSubscribeStateChanged(
                        (string)AgoraJson.GetData<string>(jsonData, "channel"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "oldState"),
                        (STREAM_SUBSCRIBE_STATE)AgoraJson.GetData<int>(jsonData, "newState"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapseSinceLastState")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerS_onLocalVideoTranscoderError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnLocalVideoTranscoderError(
                        AgoraJson.JsonToStruct<TranscodingVideoStreamS>(jsonData, "streamS"),
                        (VIDEO_TRANSCODER_ERROR)AgoraJson.GetData<int>(jsonData, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onJoinChannelSuccess":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnJoinChannelSuccess(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onRejoinChannelSuccess":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnRejoinChannelSuccess(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onAudioVolumeIndication":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnAudioVolumeIndication(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        AgoraJson.JsonToStructArray<AudioVolumeInfoS>(jsonData, "speakersS"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "speakerNumber"),
                        (int)AgoraJson.GetData<int>(jsonData, "totalVolume")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onLeaveChannel":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnLeaveChannel(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onRtcStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnRtcStats(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        AgoraJson.JsonToStruct<RtcStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onNetworkQuality":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnNetworkQuality(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (int)AgoraJson.GetData<int>(jsonData, "txQuality"),
                        (int)AgoraJson.GetData<int>(jsonData, "rxQuality")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onIntraRequestReceived":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnIntraRequestReceived(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onFirstLocalVideoFramePublished":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnFirstLocalVideoFramePublished(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onFirstRemoteVideoDecoded":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnFirstRemoteVideoDecoded(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onVideoSizeChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnVideoSizeChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (VIDEO_SOURCE_TYPE)AgoraJson.GetData<int>(jsonData, "sourceType"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "rotation")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onLocalVideoStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnLocalVideoStateChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (LOCAL_VIDEO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_VIDEO_STREAM_ERROR)AgoraJson.GetData<int>(jsonData, "errorCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onRemoteVideoStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnRemoteVideoStateChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (REMOTE_VIDEO_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (REMOTE_VIDEO_STATE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onFirstRemoteVideoFrame":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnFirstRemoteVideoFrame(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onUserJoined":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnUserJoined(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onUserOffline":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnUserOffline(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (USER_OFFLINE_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onUserMuteAudio":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnUserMuteAudio(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onUserMuteVideo":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnUserMuteVideo(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "muted")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onUserEnableVideo":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnUserEnableVideo(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "enabled")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onUserStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnUserStateChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (uint)AgoraJson.GetData<uint>(jsonData, "state")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onLocalAudioStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnLocalAudioStats(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        AgoraJson.JsonToStruct<LocalAudioStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onRemoteAudioStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnRemoteAudioStats(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        AgoraJson.JsonToStruct<RemoteAudioStatsS>(jsonData, "statsS")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onLocalVideoStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnLocalVideoStats(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        AgoraJson.JsonToStruct<LocalVideoStatsS>(jsonData, "statsS")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onRemoteVideoStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnRemoteVideoStats(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        AgoraJson.JsonToStruct<RemoteVideoStatsS>(jsonData, "statsS")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onConnectionLost":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnConnectionLost(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onConnectionBanned":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnConnectionBanned(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onStreamMessageError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnStreamMessageError(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (int)AgoraJson.GetData<int>(jsonData, "streamId"),
                        (int)AgoraJson.GetData<int>(jsonData, "code"),
                        (int)AgoraJson.GetData<int>(jsonData, "missed"),
                        (int)AgoraJson.GetData<int>(jsonData, "cached")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onRequestToken":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnRequestToken(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onLicenseValidationFailure":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnLicenseValidationFailure(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (LICENSE_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onTokenPrivilegeWillExpire":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnTokenPrivilegeWillExpire(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "token")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onFirstLocalAudioFramePublished":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnFirstLocalAudioFramePublished(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onLocalAudioStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnLocalAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (LOCAL_AUDIO_STREAM_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (LOCAL_AUDIO_STREAM_ERROR)AgoraJson.GetData<int>(jsonData, "error")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onRemoteAudioStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnRemoteAudioStateChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "remoteUserAccount"),
                        (REMOTE_AUDIO_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (REMOTE_AUDIO_STATE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (int)AgoraJson.GetData<int>(jsonData, "elapsed")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onActiveSpeaker":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnActiveSpeaker(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onClientRoleChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnClientRoleChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "oldRole"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "newRole"),
                        AgoraJson.JsonToStruct<ClientRoleOptions>(jsonData, "newRoleOptions")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onClientRoleChangeFailed":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnClientRoleChangeFailed(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (CLIENT_ROLE_CHANGE_FAILED_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (CLIENT_ROLE_TYPE)AgoraJson.GetData<int>(jsonData, "currentRole")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onConnectionStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnConnectionStateChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (CONNECTION_STATE_TYPE)AgoraJson.GetData<int>(jsonData, "state"),
                        (CONNECTION_CHANGED_REASON_TYPE)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onWlAccMessage":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnWlAccMessage(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (WLACC_MESSAGE_REASON)AgoraJson.GetData<int>(jsonData, "reason"),
                        (WLACC_SUGGEST_ACTION)AgoraJson.GetData<int>(jsonData, "action"),
                        (string)AgoraJson.GetData<string>(jsonData, "wlAccMsg")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onWlAccStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnWlAccStats(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        AgoraJson.JsonToStruct<WlAccStats>(jsonData, "currentStats"),
                        AgoraJson.JsonToStruct<WlAccStats>(jsonData, "averageStats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onNetworkTypeChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnNetworkTypeChanged(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (NETWORK_TYPE)AgoraJson.GetData<int>(jsonData, "type")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onEncryptionError":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnEncryptionError(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (ENCRYPTION_ERROR_TYPE)AgoraJson.GetData<int>(jsonData, "errorType")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onUploadLogResult":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnUploadLogResult(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "requestId"),
                        (bool)AgoraJson.GetData<bool>(jsonData, "success"),
                        (UPLOAD_ERROR_REASON)AgoraJson.GetData<int>(jsonData, "reason")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onSnapshotTaken":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnSnapshotTaken(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (string)AgoraJson.GetData<string>(jsonData, "filePath"),
                        (int)AgoraJson.GetData<int>(jsonData, "width"),
                        (int)AgoraJson.GetData<int>(jsonData, "height"),
                        (int)AgoraJson.GetData<int>(jsonData, "errCode")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onVideoRenderingTracingResult":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnVideoRenderingTracingResult(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (string)AgoraJson.GetData<string>(jsonData, "userAccount"),
                        (MEDIA_TRACE_EVENT)AgoraJson.GetData<int>(jsonData, "currentEvent"),
                        AgoraJson.JsonToStruct<VideoRenderingTracingInfo>(jsonData, "tracingInfo")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "RtcEngineEventHandlerExS_onSetRtmFlagResult":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        ((IRtcEngineEventHandlerS)rtcEngineEventHandler).OnSetRtmFlagResult(
                        AgoraJson.JsonToStruct<RtcConnectionS>(jsonData, "connectionS"),
                        (int)AgoraJson.GetData<int>(jsonData, "code")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }
                    #endregion terra IRtcEngineEventHandlerS
            }
        }
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEventForDirectCdnStreaming(IntPtr param)
        {
            if (rtcEngineEventHandler == null)
                return;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (CallbackObject == null || CallbackObject._CallbackQueue == null)
                return;
#endif

            IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

            string @event = eventParam.@event;
            string data = eventParam.data;

            LitJson.JsonData jsonData = null;
            if (data != null)
            {
                jsonData = AgoraJson.ToObject(data);
            }

            switch (@event)
            {

                #region terra IDirectCdnStreamingEventHandler

                case "DirectCdnStreamingEventHandler_onDirectCdnStreamingStateChanged":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnDirectCdnStreamingStateChanged(
                        (DIRECT_CDN_STREAMING_STATE)AgoraJson.GetData<int>(jsonData, "state"),
                        (DIRECT_CDN_STREAMING_ERROR)AgoraJson.GetData<int>(jsonData, "error"),
                        (string)AgoraJson.GetData<string>(jsonData, "message")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }

                case "DirectCdnStreamingEventHandler_onDirectCdnStreamingStats":
                    {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
CallbackObject._CallbackQueue.EnQueue(() => {
#endif
                        if (rtcEngineEventHandler == null) return;
                        rtcEngineEventHandler.OnDirectCdnStreamingStats(
                        AgoraJson.JsonToStruct<DirectCdnStreamingStats>(jsonData, "stats")
                        );
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
}); 
#endif
                        break;
                    }
                    #endregion terra IDirectCdnStreamingEventHandler
            }
        }
    }
}
